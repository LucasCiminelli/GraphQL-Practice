using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL.Streamers
{
    public class StreamersType : ObjectType<Streamer>
    {


        protected override void Configure(IObjectTypeDescriptor<Streamer> descriptor)
        {
            descriptor.Description("Este modelo representa la compañia de streamer");
        }


    }
}
