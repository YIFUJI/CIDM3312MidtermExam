using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace exam
{
    public class AppDbContext : DbContext 
    {
        private const string ConnectionString = @"Data Source=Exam.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlite(ConnectionString); 
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}