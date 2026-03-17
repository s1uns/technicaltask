namespace todos_technical_backend.BuildExtensions
{
    internal static class CorsInjection
    {
        internal static string PolicyName => "AllowLocalhost";

        internal static void AddSetCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy(PolicyName,
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:5174") 
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
        }
    }
}
