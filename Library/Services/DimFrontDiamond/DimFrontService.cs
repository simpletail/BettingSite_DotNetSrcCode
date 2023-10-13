using Common;
using Data;
using Models.DimFrontDiamond;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Services.DimFrontDiamond
{
    public class DimFrontService : IDimFrontService
    {
        #region Fields

        private readonly ISqlClientService _sqlClientService;

        #endregion

        #region Ctor

        public DimFrontService(ISqlClientService sqlClientService)
        {
            _sqlClientService = sqlClientService;
        }

        #endregion

        #region Methods
        public DataSet Gamedata2oldD(Gamedata2oldD gameData)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "gameid", Value = gameData.gmid });
                if (gameData.etid == 4)
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_Redis, parameters);
                }
                else if (gameData.etid == 1)
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_FootR, parameters);
                }
                else
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_OtherR, parameters);
                }
                //_errorLogService.WriteLog("Gamedata2+gamedata+userlogin", gameData + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet Gamedata2oldDA(Gamedata2oldDA gameData)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "gameid", Value = gameData.gmid });
                if (gameData.etid == 4)
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_Redis, parameters);
                }
                else if (gameData.etid == 1)
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_FootR, parameters);
                }
                else
                {
                    ds = _sqlClientService.Execute("gamedata", ConfigItems.Conn_OtherR, parameters);
                }
                //_errorLogService.WriteLog("Gamedata2+gamedata+userlogin", gameData + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet Gamedetail2oldD(GameDetail gameData)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "gameid", Value = gameData.gmid });
                if (gameData.etid == 4)
                {
                    ds = _sqlClientService.Execute("gamedetail", ConfigItems.Conn_Redis, parameters);
                }
                else if (gameData.etid == 1)
                {
                    ds = _sqlClientService.Execute("gamedetail", ConfigItems.Conn_FootR, parameters);
                }
                else
                {
                    ds = _sqlClientService.Execute("gamedetail", ConfigItems.Conn_OtherR, parameters);
                }
                //_errorLogService.WriteLog("Gamedata2+gamedata+userlogin", gameData + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet HighlightoldD(HighlightoldD gameData)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "eventtypeid", Value = gameData.etid });
                ds = _sqlClientService.Execute("highlightdata", ConfigItems.Conn_HighLightR, parameters);
                //_errorLogService.WriteLog("Gamedata2+gamedata+userlogin", gameData + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet Tvata(Tvata tvata)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "gameid", Value = tvata.gmid });
                parameters.Add(new SqlParameter() { ParameterName = "mobiletype", Value = tvata.mtype });
                parameters.Add(new SqlParameter() { ParameterName = "statement", Value = "getgametv" });
                ds = _sqlClientService.Execute("tv_userdata", ConfigItems.Conn_Odds, parameters);
                //_errorLogService.WriteLog("Tvata+tv_userdata", JsonConvert.SerializeObject(tvata) + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet PlacebetDconGK(PlacebetDconGK placebet)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter() { ParameterName = "gameid", Value = placebet.gmid });
                parameters2.Add(new SqlParameter() { ParameterName = "marketid", Value = placebet.mid });
                parameters2.Add(new SqlParameter() { ParameterName = "sectionid", Value = placebet.sid });
                parameters2.Add(new SqlParameter() { ParameterName = "userrate", Value = placebet.urate });
                parameters2.Add(new SqlParameter() { ParameterName = "amount", Value = placebet.amt });
                parameters2.Add(new SqlParameter() { ParameterName = "bettype", Value = placebet.btype });
                parameters2.Add(new SqlParameter() { ParameterName = "partnershiptype", Value = placebet.ptype });
                ds = _sqlClientService.Execute("dim_horseoddsconform", ConfigItems.Conn_Odds, parameters2);
                WriteLogAll("PlacebetDconGK+dim_horseoddsconform", "Req:" + JsonConvert.SerializeObject(placebet) + "Res" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                WriteLogAll("PlacebetGK" + ex.ToString(), JsonConvert.SerializeObject(placebet));

                throw ex;
            }

        }
        public DataSet PlacebetDconMatch(PlacebetDconMatch placebet)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter() { ParameterName = "userid", Value = placebet.uid });
                parameters2.Add(new SqlParameter() { ParameterName = "gameid", Value = placebet.gmid });
                parameters2.Add(new SqlParameter() { ParameterName = "marketid", Value = placebet.mid });
                parameters2.Add(new SqlParameter() { ParameterName = "sectionid", Value = placebet.sid });
                parameters2.Add(new SqlParameter() { ParameterName = "userrate", Value = placebet.urate });
                parameters2.Add(new SqlParameter() { ParameterName = "amount", Value = placebet.amt });
                parameters2.Add(new SqlParameter() { ParameterName = "bettype", Value = placebet.btype });
                ds = _sqlClientService.Execute("old_dim_Matchoddsconformdelay", ConfigItems.Conn_Odds, parameters2);
                WriteLogAll("PlacebetDconMatch+old_dim_Matchoddsconformdelay", "Req:" + JsonConvert.SerializeObject(placebet) + "Res" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                WriteLogAll("PlacebetDconMatch" + ex.ToString(), JsonConvert.SerializeObject(placebet));
                throw ex;
            }

        }
        public DataSet PlacebetFconMatch(PlacebetDconMatch placebet)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter() { ParameterName = "userid", Value = placebet.uid });
                parameters2.Add(new SqlParameter() { ParameterName = "gameid", Value = placebet.gmid });
                parameters2.Add(new SqlParameter() { ParameterName = "marketid", Value = placebet.mid });
                parameters2.Add(new SqlParameter() { ParameterName = "sectionid", Value = placebet.sid });
                parameters2.Add(new SqlParameter() { ParameterName = "userrate", Value = placebet.urate });
                parameters2.Add(new SqlParameter() { ParameterName = "amount", Value = placebet.amt });
                parameters2.Add(new SqlParameter() { ParameterName = "bettype", Value = placebet.btype });
                ds = _sqlClientService.Execute("old_dim_Matchoddsconformfinal", ConfigItems.Conn_Odds, parameters2);
                WriteLogAll("PlacebetFconMatch+old_dim_Matchoddsconformfinal", "Req:" + JsonConvert.SerializeObject(placebet) + "Res" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                WriteLogAll("PlacebetFconMatch" + ex.ToString(), JsonConvert.SerializeObject(placebet));
                throw ex;
            }

        }
        public DataSet PlacebetDconBM(PlacebetDconBM placebet)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter() { ParameterName = "userid", Value = placebet.uid });
                parameters2.Add(new SqlParameter() { ParameterName = "gameid", Value = placebet.gmid });
                parameters2.Add(new SqlParameter() { ParameterName = "marketid", Value = placebet.mid });
                parameters2.Add(new SqlParameter() { ParameterName = "sectionid", Value = placebet.sid });
                parameters2.Add(new SqlParameter() { ParameterName = "userrate", Value = placebet.urate });
                parameters2.Add(new SqlParameter() { ParameterName = "amount", Value = placebet.amt });
                parameters2.Add(new SqlParameter() { ParameterName = "bettype", Value = placebet.btype });
                parameters2.Add(new SqlParameter() { ParameterName = "usertype", Value = placebet.utype });
                ds = _sqlClientService.Execute("old_dim_Bookmakeroddsconformdelay", ConfigItems.Conn_Odds, parameters2);
                WriteLogAll("PlacebetDconBM+old_dim_Bookmakeroddsconformdelay", "Req:" + JsonConvert.SerializeObject(placebet) + "Res" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                WriteLogAll("PlacebetDconBM" + ex.ToString(), JsonConvert.SerializeObject(placebet));
                throw ex;
            }

        }
        public DataSet PlacebetFconBM(PlacebetDconBM placebet)
        {
            try
            {
                DataSet ds = new DataSet();
                var parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter() { ParameterName = "userid", Value = placebet.uid });
                parameters2.Add(new SqlParameter() { ParameterName = "gameid", Value = placebet.gmid });
                parameters2.Add(new SqlParameter() { ParameterName = "marketid", Value = placebet.mid });
                parameters2.Add(new SqlParameter() { ParameterName = "sectionid", Value = placebet.sid });
                parameters2.Add(new SqlParameter() { ParameterName = "userrate", Value = placebet.urate });
                parameters2.Add(new SqlParameter() { ParameterName = "amount", Value = placebet.amt });
                parameters2.Add(new SqlParameter() { ParameterName = "bettype", Value = placebet.btype });
                parameters2.Add(new SqlParameter() { ParameterName = "usertype", Value = placebet.utype });
                ds = _sqlClientService.Execute("old_dim_Bookmakeroddsconformfinal", ConfigItems.Conn_Odds, parameters2);
                WriteLogAll("PlacebetFconBM+old_dim_Bookmakeroddsconformfinal", "Req:" + JsonConvert.SerializeObject(placebet) + "Res" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                WriteLogAll("PlacebetFconBM" + ex.ToString(), JsonConvert.SerializeObject(placebet));
                throw ex;
            }

        }
        public DataSet Gamedetils(Int64 gmid)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "GameId", Value = gmid });
                parameters.Add(new SqlParameter() { ParameterName = "Statement", Value = "GetAllData" });
                return _sqlClientService.Execute("GetGameForRedis", ConfigItems.Conn_Odds, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataSet Horsedetail(Horsedetail paymentwith)
        {
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "gameid", Value = paymentwith.gmid });
                parameters.Add(new SqlParameter() { ParameterName = "Statement", Value = "selectdetail" });
                DataSet ds = _sqlClientService.Execute("sp_horsedetail", ConfigItems.Conn_Loggameodds, parameters);
                //WriteLogAll("Horsedetail+sp_horsedetail", JsonConvert.SerializeObject(paymentwith) + "Res:" + JsonConvert.SerializeObject(ds));
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void WriteLogAll(String str, String request = null)
        {
            try
            {
                if (ConfigItems.ErrorLog)
                {
                    string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Log/Service/Log_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".txt");
                    if (!File.Exists(path))
                    {
                        var myFile = File.Create(path);
                        myFile.Close();
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("---------------------------------------------------------------------------------------------");
                        //sw.Write(DateTime.Now);.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
                        sw.WriteLine(Environment.NewLine + str + Environment.NewLine + request);
                    }
                }
            }
            catch (Exception)
            { }
        }
        #endregion
    }
}
