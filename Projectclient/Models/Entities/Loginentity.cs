using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projectclient.Models.Entities
{
    public class Loginentity
    {
        
        public string email {  get; set; }
        public string password { get; set; }
        public string type { get; set; }
    }
}