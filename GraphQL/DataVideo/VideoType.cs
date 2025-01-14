using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL.DataVideo
{
    public class VideoType: ObjectType<Video>
    {

        protected override void Configure(IObjectTypeDescriptor<Video> descriptor)
        {

            descriptor.Description("Este modelo es usado como base para la información de videos");

            descriptor.Field(x => x.Director).Description("Este representa el director del video");


        }
    }
}
