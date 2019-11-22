using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TshirtWebApp.Models;

namespace TshirtWebApp.Data
{
    public static class SeedData
    {
        public static void Initialize(TeesContext context)
        {
            if (!context.Tees.Any())
            {
                context.Tees.AddRange(
                    new Tee
                    {
                        Name = "Squeaky Bone",
                        Gender = "Male",
                        Color = "red",
                        Size = "M",
                        
                    },
                    new Tee
                    {
                        Name = "Knotted Rope",
                        Gender = "Female",
                        Color = "green",
                        Size = "S",
                        
                    }
                );
                context.SaveChanges();  
            }
        }
    }
}