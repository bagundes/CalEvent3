using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CalEvent3
{
    public class DBEvent : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}