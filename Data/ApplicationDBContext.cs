using System;
using CodeHelpRepoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeHelpRepoWebApp.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
		{
		}

		public DbSet<Reference> References { set; get; }
	}
}

