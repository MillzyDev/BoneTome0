using AspNetStatic;

namespace BoneTome0;

internal static class StaticResourcesInfo
{
    public static StaticResourcesInfoProvider GetProvider()
    {
        var provider = new StaticResourcesInfoProvider();

        provider.Add(GetPageResources());
        provider.Add(GetCssResources());
        provider.Add(GetJsResources());
        provider.Add(GetBinaryResources());

        return provider;
    }

    private static IEnumerable<PageResource> GetPageResources() =>
        new PageResource[]
        {
            new("/") { OutFile = "index.html" },
            new("/mods")
        };

    private static IEnumerable<CssResource> GetCssResources() =>
        new CssResource[]
        {
            new("/bootstrap/bootstrap.min.css"),
            new("/app.css"),
            new("/BoneTome0.styles.css")
        };

    private static IEnumerable<JsResource> GetJsResources() =>
        new JsResource[]
        {
            new("_framework/blazor.web.js")
        };

    private static IEnumerable<BinResource> GetBinaryResources() =>
        new BinResource[]
        {
            new("/favicon.png"),
            new("/modsicon.svg")
        };

}