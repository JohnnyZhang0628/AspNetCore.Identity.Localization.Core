using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Identity.Localization.Core
{
    public static class IdentityLocalizationExtensions
    {
        public static IServiceCollection AddIdentityLocalization(this IServiceCollection services)
        {
            return services.AddLocalization(options => options.ResourcesPath = "Resources");
        }

        public static IdentityBuilder AddIdentityErrorDescriber(this IdentityBuilder builder)
        {
            return builder.AddErrorDescriber<CustomIdentityErrorDescriber>();
        }

        /// <summary>
        /// set localization .default language supportedCultures[0]
        /// </summary>
        /// <param name="app"></param>
        /// <param name="supportedCultures">language array </param>
        /// <returns></returns>
        public static IApplicationBuilder UseIdentityLocalization(this IApplicationBuilder app, params string[] supportedCultures)
        {
            var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedUICultures(supportedCultures)
           .AddSupportedCultures(supportedCultures);

            return app.UseRequestLocalization(localizationOptions);
        }
    }
}