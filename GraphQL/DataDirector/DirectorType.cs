using GraphQLDirector.Data;
using GraphQLDirector.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GraphQLDirector.GraphQL.DataDirector
{
    public class DirectorType : ObjectType<Director>
    {

        protected override void Configure(IObjectTypeDescriptor<Director> descriptor)
        {
            descriptor.Description("Este modelo representa la data del director");

            descriptor.Field(x => x.Videos)
                .ResolveWith<Resolvers>(x => x.GetVideos(default!, default!))
                .Description("Representa la colección de videos de este director");

            descriptor
                .Field("nombreCompleto")
                .ResolveWith<Resolvers>(x => x.GetNombreCompleto(default!, default!))
                .Description("Representa una concatenación entre el nombre y el apellido del usuario");
        }

        private class Resolvers
        {
            public IQueryable<Video> GetVideos(Director director, [Service] ApiDbContext context)
            {
                return context.Videos!.Where(x => x.DirectorId == director.Id);
            }

            public string GetNombreCompleto([Parent] Director director, [Service] ApiDbContext context)
            {
                return $"{director.Nombre} {director.Apellido}";
            }
        }
    }
}
