﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedeSocial.Domain.Account
{
    public class Account : IdentityUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DtBirthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
