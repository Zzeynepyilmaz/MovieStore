using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.ActorOperations.CreateActor;
using MovieStore.Application.ActorOperations.DeleteActor;
using MovieStore.Application.ActorOperations.GetActorDetail;
using MovieStore.Application.ActorOperations.GetActors;
using MovieStore.Application.ActorOperations.UpdateActor;
using MovieStore.DbOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetActorQuery query = new(_context, _mapper);
            var result = await query.Handle();
            return Ok(result);
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ActorDetailQuery query = new(_context, _mapper);
            query.ActorId = id;

            ActorDetailQueryValidator validator = new ActorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = await query.Handle();
            return Ok(result);
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new(_context, _mapper);
            command.Model = newActor;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateActorModel updateActor)
        {
            UpdateActorCommand command = new(_context);
            command.ActorId = id;
            command.Model = updateActor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteActorCommand command = new(_context);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);

            await command.Handle();
            return Ok();
        }

    }
}
