using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DimFrontDiamond
{
    public class Horsedetail
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gametid is empty.")]
        public Int64 gmid { get; set; }
    }
}
