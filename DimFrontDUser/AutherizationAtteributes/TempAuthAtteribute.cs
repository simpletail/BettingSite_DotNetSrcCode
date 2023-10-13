﻿using Common;
using DimFrontDUser.Providers;
using Services.CacheManager;
using Services.RedisManager;
using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DimFrontDUser.AutherizationAtteributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TempAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (!IsUserAuthorized(filterContext))
            {
                var responseDTO = new { status = 401, message = "Unauthorized access" };
                var container = Ioc.Initialize();
                //var _cache = container.GetInstance<IRedis1>();
                // if (_cache.IsExist("ismain", ConfigItems.Redismain))
                // {
                //     filterContext.Response =
                //filterContext.Request.CreateResponse(HttpStatusCode.OK, new { status = 402, msg = "System under maintenance" });
                // }
                // else
                // {
                //     filterContext.Response =
                //                     filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, responseDTO);
                // }
                filterContext.Response =
                filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, responseDTO);
                return;
            }
            base.OnAuthorization(filterContext);
        }

        public bool IsUserAuthorized(HttpActionContext actionContext)
        {
            var authHeader = FetchFromHeader(actionContext);

            if (authHeader != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

                var issuer = tokenS.Claims.First(claim => claim.Type == "iss").Value;
                var unique_name = tokenS.Claims.First(claim => claim.Type == "saguid").Value;
                var audienceId = tokenS.Claims.First(claim => claim.Type == "aud").Value;
                var expireTime = tokenS.Claims.First(claim => claim.Type == "exp").Value;

                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var time2 = epoch.AddSeconds(Convert.ToDouble(expireTime));

                Guid uu_id;
                bool res = Guid.TryParse(unique_name, out uu_id);

                if (!res)
                    return false;

                var container = Ioc.Initialize();
                var _cacheManager = container.GetInstance<IRedisManager>();
                var accesstoken = string.Format(GlobalCacheKey.UserTempAccessToken, uu_id);

                if (_cacheManager.IsExist(accesstoken, ConfigItems.RedisAuthdb))
                {
                    if (!authHeader.Equals(_cacheManager.Get<string>(accesstoken, ConfigItems.RedisAuthdb)))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                if (issuer.Equals(ConfigItems.JwtIssuer) && audienceId.Equals(ConfigItems.AudienceId) && DateTime.UtcNow < time2)
                {
                    return true;
                }
            }

            return false;
        }
        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null)
            {
                requestToken = authRequest.Parameter;
            }

            return requestToken;
        }

        //private string FetchFromHeader(HttpActionContext actionContext)
        //{
        //    string requestToken = null;
        //    var authRequest = actionContext.Request.Headers.Authorization;

        //    if (authRequest != null)
        //    {
        //        requestToken = authRequest.Parameter;
        //    }
        //    var ec = ED.DecryptString(ConfigItems.FrontSecret, requestToken);
        //    return ec;
        //}
    }
}