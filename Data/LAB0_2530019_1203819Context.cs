using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LAB0_2530019_1203819.Models;

namespace LAB0_2530019_1203819.Data
{
    public class LAB0_2530019_1203819Context : DbContext
    {
        public LAB0_2530019_1203819Context (DbContextOptions<LAB0_2530019_1203819Context> options)
            : base(options)
        {
        }

        public DbSet<LAB0_2530019_1203819.Models.ClientModel> ClientModel { get; set; }
    }
}
