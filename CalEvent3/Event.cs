using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CalEvent3
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [Column(TypeName = "date")]
        public DateTime dtIni { get; set; }
        [Column(TypeName = "date")]
        public DateTime dtEnd { get; set; }
    }
}