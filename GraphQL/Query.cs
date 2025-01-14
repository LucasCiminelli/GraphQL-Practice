using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Video> GetVideos([Service] ApiDbContext context)
        {

            return context.Videos!;

        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Director> GetDirectors([Service] ApiDbContext context) 
        {
            return context.Directores!;        
        }

    }
}
