using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        { 
            serviceCollection.AddMemoryCache();  //cache injection için --redis veya başka cache toollarını kullnırsan bunu yazmaya gerek yok
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();   //cache injection için
            serviceCollection.AddSingleton<Stopwatch>(); //PerformanceAspect'deki Stopwatch için 
        }
    }
}
