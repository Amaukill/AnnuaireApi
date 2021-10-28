using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuaireApi.Model
{
    public class Contact
    {
        public Guid Guid { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}
