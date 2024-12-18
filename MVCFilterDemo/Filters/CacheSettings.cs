namespace MVCFilterDemo.Filters
{
    public class CacheSettings
    {

        public static void RegisterOutputCaching(WebApplication app) 
        {
            app.UseOutputCache();
        }
}
}
