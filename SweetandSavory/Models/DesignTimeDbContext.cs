using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetandSavory.Models
{
  public class SweetandSavoryContextFactory : IDesignTimeDbContextFactory<SweetandSavoryContext>
  {

    SweetandSavoryContext IDesignTimeDbContextFactory<SweetandSavoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SweetandSavoryContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new SweetandSavoryContext(builder.Options);
    }
  }
}