using ERM.DAL;
using ERM.DAL.EntityCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERM.Services.Sample
{
    public class Startup : Service.Startup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
            Registry.UseDAL<EFDALContainer>();
        }
    }
}
