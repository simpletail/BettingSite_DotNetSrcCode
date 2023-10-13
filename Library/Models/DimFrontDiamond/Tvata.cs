using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DimFrontDiamond
{

    public partial class Tvata
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        [Required(ErrorMessage = "mobiletype is empty.")]
        public String mtype { get; set; }
    }
}
