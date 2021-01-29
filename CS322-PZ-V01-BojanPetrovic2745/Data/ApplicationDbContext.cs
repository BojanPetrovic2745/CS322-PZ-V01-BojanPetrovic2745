using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CS322_PZ_V01_BojanPetrovic2745.Models;

namespace CS322_PZ_V01_BojanPetrovic2745.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CS322_PZ_V01_BojanPetrovic2745.Models.Patient> Patient { get; set; }
        public DbSet<CS322_PZ_V01_BojanPetrovic2745.Models.Kontrola> Kontrola { get; set; }
        public DbSet<CS322_PZ_V01_BojanPetrovic2745.Models.Patient_Kontrola> Patient_Kontrola { get; set; }
    }
}
