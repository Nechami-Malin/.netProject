using Microsoft.EntityFrameworkCore;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data
{
    public class WeightWatcherContext:DbContext
    {
        public WeightWatcherContext(DbContextOptions<WeightWatcherContext> options):base(options)
        {

        }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<Card> Card { get; set; }
    }
}
