﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumbers.Model
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
