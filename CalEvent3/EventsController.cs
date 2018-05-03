using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalEvent3
{
    public class EventsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Event> Get()
        {
            using (var dbase = new DBEvent())
            {
                return dbase.Events.ToList();
            }
                

           // return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Event Get(int id)
        {
            using (var dbase = new DBEvent())
            {
                return dbase.Events.Where(a => a.id == id).First();
            }
        }

        public IEnumerable<Event> Get(string dtIni, string dtEnd)
        {

            DateTime dtIni1 = DateTime.ParseExact(dtIni.Replace("-", ""), "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime dtEnd1 = DateTime.ParseExact(dtEnd.Replace("-", ""), "yyyyMMdd", CultureInfo.InvariantCulture);

            
            using (var dbase = new DBEvent())
            {
                //var foo = dbase.Events.Where(a => a.dtIni >= dtIni1).ToList();
                return dbase.Events.Where(a => a.dtIni >= dtIni1 && a.dtEnd <= dtEnd1).ToList();
            }
        }

        // POST api/<controller>
        public void Post([FromBody]Event value)
        {
            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotModified);

            using (var dbase = new DBEvent())
            {
                dbase.Events.Add(value);
                dbase.SaveChanges();
            }

        }

        // PUT api/<controller>
        public void Put(int id, [FromBody]Event value)
        {
            using (var dbase = new DBEvent())
            {
                var oEvent = dbase.Events.Where(a => a.id == id).First();
                oEvent.name = value.name;
                oEvent.description = value.description;
                oEvent.dtIni = value.dtIni;
                oEvent.dtEnd = value.dtEnd;

                dbase.Entry(oEvent).State = EntityState.Modified;

                dbase.SaveChanges();
                return;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var oEvent = new Event { id = id };
            using (var dbase = new DBEvent())
            {
                dbase.Entry(oEvent).State = EntityState.Deleted;
                dbase.SaveChanges();
            }
        }
    }
}