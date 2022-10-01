using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MicrosoftTeams.OutgoingWebhook;

public static class Program
{
    public static void Main()
    {
        CreateHostBuilder(null).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
