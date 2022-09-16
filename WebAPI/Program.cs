using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //Aþaðýdaki 5 satýrý ekledik. Autofac'i inject etmek için
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //AutoFac'i enjekte etmek  için bu  kodu yazdýk.Bunu bir defa yazýcaz bir daha yazýlmaz.Sebebi .Net Core'in içinde IOC yapýsý var ama biz onun yerine Autofac'i kullanmak için yazdýk bunu.
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

