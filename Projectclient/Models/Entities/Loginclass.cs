using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projectclient.Models.Entities
{
    public class Loginclass
    {
        [Required(ErrorMessage = "Email is required.")]

        public string email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
    }
}