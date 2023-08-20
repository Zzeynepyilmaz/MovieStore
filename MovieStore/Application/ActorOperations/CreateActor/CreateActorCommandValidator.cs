using FluentValidation;

namespace MovieStore.Application.ActorOperations.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(c => c.Model.Name).NotEmpty();
            RuleFor(c => c.Model.LastName).NotEmpty();
        }
    }
}
