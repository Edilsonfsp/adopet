using adopet.domain.tutor;
using Microsoft.EntityFrameworkCore;

namespace adopet.infra.data;

public class ApplicationDbContext : DbContext
{

	public DbSet<Tutor> Tutors { get; set; }  //Aqui sao as tabelas

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<Tutor>()
			.Property(c => c.Name).IsRequired();

	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
	{
		configuration.Properties<string>().HaveMaxLength(100);
	}

}
