using Microsoft.AspNetCore.Components.WebView.Maui;

using Microsoft.Extensions.Logging;

namespace Admin_DASM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont(
                        "OpenSans-Regular.ttf",
                        "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // API CONNECTION
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress =
                        new Uri("http://10.123.35.251:5043/")
                });

            // SERVICES
           // builder.Services.AddScoped<UserService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}