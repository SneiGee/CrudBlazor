var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.crudBlazor_ApiService>("apiservice");

builder.AddProject<Projects.crudBlazor_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
