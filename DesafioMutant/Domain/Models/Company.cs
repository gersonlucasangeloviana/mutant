using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Company
    {
        protected Company()
        {

        }
        public int CompanyId { get; set; }
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }
}
