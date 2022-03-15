using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class SeedDb{
         public static void SeedPopulation(IApplicationBuilder app){
             using (var serviceScope = app.ApplicationServices.CreateScope())
             {
                 SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
             }
         }

         private static void SeedData(AppDbContext context) {
             if (!context.Platforms.Any()){
                 Console.WriteLine("--> Seeding Db...");

                 context.Platforms.AddRange(
                     new Platform() {Name = "Dot Net", Publisher ="Microsoft", Cost="Free"},
                      new Platform() {Name = "PHP", Publisher ="Microsoft", Cost="Free"},
                       new Platform() {Name = "React.js", Publisher ="Facebook", Cost="Free"}
                 );

                 context.SaveChanges();

             }
             else{
                 Console.WriteLine("__> Got data in Db");
             }
         }
    }
}