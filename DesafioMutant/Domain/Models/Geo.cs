using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Geo
    {
        protected Geo()
        {

        }
        public int GeoId { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
    }
}
