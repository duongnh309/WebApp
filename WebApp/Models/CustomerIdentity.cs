using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class CustomerIdentity
    {
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
