using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext([NotNullAttribute] DbContextOptions<FilmeContext> options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }


    }
}