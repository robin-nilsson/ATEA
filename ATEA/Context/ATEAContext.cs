using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ATEA.Models;

namespace ATEA.Context
{
    public class ATEAContext : DbContext
    {
        public ATEAContext() : base("AteaDb")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}