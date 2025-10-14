using Microsoft.AspNetCore.Builder;

namespace Shopping.Client
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient("ShoppingAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app)
        {
            
        }
    }
}
