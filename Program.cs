using GraphQL.Server.Ui.Voyager;
using GraphQLDirector.Data;
using GraphQLDirector.GraphQL;
using GraphQLDirector.GraphQL.DataVideo;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurar el DbContext y la cadena de conexi�n que cre� en appsetings.json
builder.Services.AddDbContext<ApiDbContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))

);


builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<VideoType>()
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager("/graphql-ui", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
});

app.MapControllers();

app.Run();
