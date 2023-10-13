﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DimFrontDiamond
{

    public class GMw
    {
        public Int64 gmid { get; set; }
        public Int32 etid { get; set; }
        public Int32 m { get; set; }
        public Int64 gtv { get; set; }
        public String ename { get; set; }
        public Int64 cid { get; set; }
        public String cname { get; set; }
        public Boolean iplay { get; set; }
        public String gtype { get; set; }
        public Boolean f1 { get; set; }
        public Boolean f { get; set; }
        public Boolean bm { get; set; }
        public Boolean tv { get; set; }
        public Int32 scard { get; set; }
        public Int32 iscc { get; set; }
        public String stime { get; set; }
        public Int64 mod { get; set; }
    }

    public class GameMasterw
    {
      
        public List<GMw> t1 { get; set; }

    }
}
