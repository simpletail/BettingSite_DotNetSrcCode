using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DimFrontDUser
{
    public class Login
    {
        [Required(ErrorMessage = "username is empty.")]
        public String uname { get; set; }
        [Required(ErrorMessage = "password is empty.")]
        public String pass { get; set; }
        [Required(ErrorMessage = "webdomain is empty.")]
        [RegularExpression("^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\\.)+[A-Za-z]{2,6}$", ErrorMessage = "invalid domain.")]
        public String webdom { get; set; }
        [Required(ErrorMessage = "ip is empty.")]
        public String ip { get; set; }
        [Required(ErrorMessage = "browserdetail is empty.")]
        public String bdetail { get; set; }
    }
}
