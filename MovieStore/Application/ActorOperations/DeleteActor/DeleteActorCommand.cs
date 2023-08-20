using MovieStore.DbOperations;

namespace MovieStore.Application.ActorOperations.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly MovieStoreDbContext _context;

        public DeleteActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public async Task Handle()
        {
            var actor = _context.Actors.FirstOrDefault(c => c.ActorId == ActorId);
            if (actor == null)
                throw new InvalidOperationException("Not exist");

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
