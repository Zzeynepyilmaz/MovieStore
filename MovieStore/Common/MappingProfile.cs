using AutoMapper;
using MovieStore.Application.ActorOperations.GetActorDetail;
using MovieStore.Application.ActorOperations.GetActors;
using MovieStore.Entities;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<int, Actor>().ForMember(c => c.ActorId, c => c.MapFrom(c => c));
            CreateMap<int, Movie>().ForMember(c => c.MovieId, c => c.MapFrom(c => c));

            CreateMap<Actor, ActorViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.MovieName).ToList()));
            CreateMap<Actor, ActorsViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.MovieName).ToList()));
        }
    }
}
