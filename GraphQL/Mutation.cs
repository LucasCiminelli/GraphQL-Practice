using GraphQLDirector.Data;
using GraphQLDirector.GraphQL.Streamers;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Mutation
    {

        public async Task<AddStreamerPayload> AddStreamerAsync(AddStreamerInput input, [Service] ApiDbContext context)
        {
            var streamer = new Streamer
            {
                Nombre = input.nombre,
                Url = input.url,
            };

            context.Streamers!.Add(streamer);
            await context.SaveChangesAsync();


            return new AddStreamerPayload(streamer);
        }

    }
}
