using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Sample.Models.SampleDb;

[assembly: FunctionsStartup(typeof(Sample.Function.Startup))]

namespace Sample.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            FunctionsHostBuilderContext context = builder.GetContext();
            
            builder.Services.AddDbContext<SampleDbContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("SampleDb"))
            );
        }
    }
}