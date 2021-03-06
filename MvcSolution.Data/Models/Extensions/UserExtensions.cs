﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcSolution.Data.Models;

namespace MvcSolution
{
    public static class UserExtensions
    {
        public static User Get(this IQueryable<User> query, string username)
        {
            return query.FirstOrDefault(x => x.Username == username);
        }
    }
}
