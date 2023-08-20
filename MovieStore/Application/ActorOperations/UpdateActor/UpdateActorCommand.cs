using MovieStore.DbOperations;

namespace MovieStore.Application.ActorOperations.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly MovieStoreDbContext _context;
        public UpdateActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public async Task Handle()
        {
            var actor = _context.Actors.FirstOrDefault(c => c.ActorId == ActorId);
            if (actor == null)
                throw new InvalidOperationException("Not Exist");

            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.LastName = Model.LastName != default ? Model.LastName : actor.LastName;
            await _context.SaveChangesAsync();
        }
    }
    public class UpdateActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}

