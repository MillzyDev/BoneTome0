using AspNetStatic;

namespace BoneTome0;

internal static class StaticResourcesInfo
{
    public static StaticResourcesInfoProvider GetProvider()
    {
        var provider = new StaticResourcesInfoProvider();

        provider.Add(GetPageResources());
        provider.Add(GetCssResources());
        provider.Add(GetBinaryResources());

        return provider;
    }

    private static IEnumerable<PageResource> GetPageResources() =>
        new PageResource[]
        {
            new("/") { OutFile = "Index.html" },
            new("/Weather"),
        };

    private static IEnumerable<CssResource> GetCssResources() =>
        new CssResource[]
        {
            new("/bootstrap/bootstrap.min.css"),
            new("/app.css"),
            new("/Sample.BlazorSSG.styles.css")
        };

    private static IEnumerable<BinResource> GetBinaryResources() =>
        new BinResource[]
        {
            new("/favicon.png"),
        };

}