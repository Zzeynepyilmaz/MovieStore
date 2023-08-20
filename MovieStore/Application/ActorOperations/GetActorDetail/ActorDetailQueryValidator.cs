using FluentValidation;

namespace MovieStore.Application.ActorOperations.GetActorDetail
{
    public class ActorDetailQueryValidator : AbstractValidator<ActorDetailQuery>
    {
        public ActorDetailQueryValidator()
        {
            RuleFor(c => c.ActorId).GreaterThan(0);
        }
    }
}
