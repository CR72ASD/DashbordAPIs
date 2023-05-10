using Entity.Contexts;
using Entity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opration.InterFaces;

namespace Dashbord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Session> _repository;

        public SessionController(DBAContext context, IGenericRepository<Session> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Session>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<Session>> AddNew([FromBody] Session session)
        {
            var result = await _context.AddAsync(session);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Session>> GetByID(int Id)
        {
            var result = await _repository.GetByIdAsync(Id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Session>> Delete(int id)
        {
            var deleteData = await _repository.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _repository.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Session>> Update([FromBody] Session session)
        {
            var updateData = await _repository.GetAllAsync();
            if (session is null)
                return NotFound();
            _repository.Update(session);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
