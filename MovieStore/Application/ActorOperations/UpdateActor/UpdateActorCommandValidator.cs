using FluentValidation;

namespace MovieStore.Application.ActorOperations.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(c => c.ActorId).GreaterThan(0);
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.LastName).NotEmpty();
        }
    }
}
