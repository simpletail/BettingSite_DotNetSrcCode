using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DimFront
{
    public class MgetuPaytype
    {
        public Int64 uid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "paymentid is empty.")]
        public Int64 pid { get; set; }
    }
    public class Uaddpayment
    {
        public Int64 uid { get; set; }
        public String psid { get; set; }
        public String imgpath { get; set; }
        public String amt { get; set; }
        public String ptype { get; set; }
    }
    public class MPaymentRpt
    {
        [Required(ErrorMessage = "fromdate is empty.")]
        public String fdt { get; set; }
        [Required(ErrorMessage = "todate is empty.")]
        public String tdt { get; set; }
        public Int32 type { get; set; }
        public String uid { get; set; }
    }
   
}
