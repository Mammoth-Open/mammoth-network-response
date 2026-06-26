var builder = DistributedApplication.CreateBuilder(args);
var redis = builder.AddRedis("redis");
var kurrentDb = builder.AddKurrentDB("kurrentdb");

var username = builder.AddParameter("username", secret: true, value: "postgres");
var password = builder.AddParameter("password", secret: true, value: "postgres");


var server = builder.AddPostgres("application-server")
              .WithPgAdmin(pgAdmin => pgAdmin.WithHostPort(5050));

var applicationDb = server.AddDatabase("application-db");
var keycloakDb = builder.AddPostgres("keycloak-db");

// Keycloak container
var keycloak = builder.AddContainer("keycloak", "quay.io/keycloak/keycloak", "25.0")
    .WithReference(keycloakDb)
    .WithEnvironment(context =>
    {
           context.EnvironmentVariables["KC_DB"] = "postgres";
           context.EnvironmentVariables["KC_DB_USERNAME"] = username.Resource.Default.GetDefaultValue();
           context.EnvironmentVariables["KC_DB_PASSWORD"] = password.Resource.Default.GetDefaultValue();
           context.EnvironmentVariables["KEYCLOAK_ADMIN"] = "admin";
           context.EnvironmentVariables["KEYCLOAK_ADMIN_PASSWORD"] = "admin";
    })
    .WithArgs("start-dev", "--import-realm")
    .WithHttpEndpoint(port: 8080, targetPort: 8080, name: "http")
    .WaitFor(keycloakDb);

builder.AddProject("VolunteerService", "../services/volunteer-service/src/Mammoth.VolunteerService.csproj")
       .WithReference(applicationDb)
       .WithReference(redis)
       .WaitFor(applicationDb);

builder.AddProject("Gateway", "../gateway/src/Mammoth.Gateway.csproj")
       .WaitFor(applicationDb);

var app = builder.Build();

await app.RunAsync();
