using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DimFrontDiamond
{
    public class GameData
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        public Int32 m { get; set; }
    }
    public class Gamedata2oldD
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "eventtypeid is empty.")]
        public Int64 etid { get; set; }
        public Int32 m { get; set; }
    }
    public class Gamedata2oldDA
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "eventtypeid is empty.")]
        public Int64 etid { get; set; }
        [Required(ErrorMessage = "marketid is empty.")]
        public String mid { get; set; }
        public Int32 m { get; set; }
    }
    public class GameDataopen
    {
        [Range(1, Int64.MaxValue, ErrorMessage = "gameid is empty.")]
        public Int64 gmid { get; set; }
        [Range(1, Int64.MaxValue, ErrorMessage = "eventtypeid is empty.")]
        public Int32 etid { get; set; }
        public String tablename { get; set; }
    }
}
