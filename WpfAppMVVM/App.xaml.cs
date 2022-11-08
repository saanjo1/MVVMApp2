using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppMVVM.Services;

namespace WpfAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<MainWindow>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            MainWindow window = serviceProvider.GetService<MainWindow>();
            window.Show();
        }

    }
}
