using Microsoft.EntityFrameworkCore;
using ParcialCiudadanosSanos.Models;

namespace ParcialCiudadanosSanos.Data
{
    public class ParcialCiudadanosSanosContext : DbContext
    {
        public ParcialCiudadanosSanosContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<ConsultaMedica> ConsultaMedica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ParcialCiudadanosSanosDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
