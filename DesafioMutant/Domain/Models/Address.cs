using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Address
    {
        protected Address()
        {

        }
        public int AddressId { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }
}
