using Entity.Contexts;
using Entity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opration.InterFaces;

namespace Dashbord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Parent> _repository;

        public ParentController(DBAContext context,IGenericRepository<Parent> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Parent>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            if(result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<Parent>> AddNew([FromBody] Parent parent)
        {
            var result = await _context.AddAsync(parent);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Parent>> GetByID(int Id)
        {
            var result = await _repository.GetByIdAsync(Id);
            if(result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Parent>> Delete(int id)
        {
            var deleteData =await _repository.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _repository.Delete(deleteData);
           await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Parent>> Update([FromBody]Parent parent)
        {
            var updateData = await _repository.GetAllAsync();
            if (parent is null)
                return NotFound();
            _repository.Update(parent);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
