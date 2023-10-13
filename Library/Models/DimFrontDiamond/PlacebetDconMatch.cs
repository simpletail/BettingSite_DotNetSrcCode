using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DimFrontDiamond
{
    public class PlacebetDconMatch
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "userid is empty.")]
        public Int64 uid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "marketid is empty.")]
        public Int64 mid { get; set; }
        [Required(ErrorMessage = "sectionid is empty.")]
        public String sid { get; set; }
        [Range(0.01, Double.MaxValue, ErrorMessage = "userrate is empty.")]
        public Double urate { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "amount is empty.")]
        public Double amt { get; set; }
        [Required(ErrorMessage = "bettype is empty.")]
        public String btype { get; set; }
    }
}
