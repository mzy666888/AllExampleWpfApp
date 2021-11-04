using AllExampleWpfApp.Models;
using AllExampleWpfApp.Modules.ModuleName;
using AllExampleWpfApp.Services;
using AllExampleWpfApp.Services.Interfaces;
using AllExampleWpfApp.Views;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AllExampleWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public  IConfiguration _configuration;
        protected override Window CreateShell()
        {
            
            return Container.Resolve<MainWindow>();
        }

        

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSetting.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

            base.OnStartup(e);
           
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
            moduleCatalog.AddModule<FilterDataGridModule.FilterDataGridModule>();
            moduleCatalog.AddModule<ChromeTabsModule.ChromeTabsModule>();
        }
        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ProductContext>(options => options.UseSqlite(_configuration.GetConnectionString("SqlConnection")));

            //添加MediaR
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //添加日志输出log
            serviceCollection.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();
            });
            //注册AutoMapper服务
            //添加对AutoMapper的支持，会查找所有程序集中继承了Profile的类
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection));
        }

        
    }
}
