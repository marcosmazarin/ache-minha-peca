var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ache_minha_peca_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.ache_minha_peca_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
