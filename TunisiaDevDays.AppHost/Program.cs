var builder = DistributedApplication.CreateBuilder(args);

var pubSub = builder.AddDaprPubSub("pubsub");


builder.AddProject<Projects.ServiceA>("servicea")
        .WithDaprSidecar();
//.WithReference(pubSub);


builder.AddProject<Projects.ServiceB>("serviceb")
      .WithDaprSidecar();
      //.WithReference(pubSub);

builder.Build().Run();
