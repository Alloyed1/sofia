using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sofia.Models
{
	public class ApplicationContext : IdentityDbContext<User>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			//builder.Entity<Favorite>().HasKey(k => new { k.Id, k.UserId });
		}
		public DbSet<Home> Homes { get; set; }
		public DbSet<Dop> Dops { get; set; }
        public DbSet<Photos> Photos { get; set; }

	}
}
