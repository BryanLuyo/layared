using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            new RouteConfig
            {
                RouteId = "brand_route",
                ClusterId = "brand_cluster",
                Match = new RouteMatch {{ Path = "/brands/{**catchall}" }}
            },
            new RouteConfig
            {
                RouteId = "dealer_route",
                ClusterId = "dealer_cluster",
                Match = new RouteMatch {{ Path = "/dealers/{**catchall}" }}
            }
        },
        new[]
        {
            new ClusterConfig
            {
                ClusterId = "brand_cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    ["dest1"] = new DestinationConfig { Address = "http://localhost:5001" }
                }
            },
            new ClusterConfig
            {
                ClusterId = "dealer_cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    ["dest1"] = new DestinationConfig { Address = "http://localhost:5002" }
                }
            }
        });

var app = builder.Build();

app.MapReverseProxy();

app.Run();
