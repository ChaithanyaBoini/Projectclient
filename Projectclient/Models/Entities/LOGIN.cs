using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projectclient.Models.Entities
{
    public class LOGIN
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
      
         public string type { get; set; }
    }
}