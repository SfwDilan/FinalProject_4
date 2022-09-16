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
            //A�a��daki 5 sat�r� ekledik. Autofac'i inject etmek i�in
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //AutoFac'i enjekte etmek  i�in bu  kodu yazd�k.Bunu bir defa yaz�caz bir daha yaz�lmaz.Sebebi .Net Core'in i�inde IOC yap�s� var ama biz onun yerine Autofac'i kullanmak i�in yazd�k bunu.
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

