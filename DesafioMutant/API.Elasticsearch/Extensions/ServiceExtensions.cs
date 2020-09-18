using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Elasticsearch.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            //services.AddDbContext<DesafioMutantDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            
        }
    }
}
