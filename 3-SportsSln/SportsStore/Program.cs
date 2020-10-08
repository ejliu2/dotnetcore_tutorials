using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // CreateHostBuilder(args).Build().MigrateDatabase<StoreDbContext>().Run();
            // https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/april/data-points-ef-core-in-a-docker-containerized-app
            // https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/may/data-points-ef-core-in-a-docker-containerized-app-part-2
            // https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/june/data-points-ef-core-in-a-docker-containerized-app-part-3
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
