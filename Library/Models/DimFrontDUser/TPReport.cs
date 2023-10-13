using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DimFrontDUser
{

    public partial class TPReport
    {
        public Int32 uid { get; set; }
        [Required(ErrorMessage = "casinotype is empty.")]
        public String ctype { get; set; }
    }
}
