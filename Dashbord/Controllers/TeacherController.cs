using Entity.Contexts;
using Entity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opration.InterFaces;

namespace Dashbord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Teacher> _repository;

        public TeacherController(DBAContext context, IGenericRepository<Teacher> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Teacher>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<Teacher>> AddNew([FromBody] Teacher teacher)
        {
            var result = await _context.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Teacher>> GetByID(int Id)
        {
            var result = await _repository.GetByIdAsync(Id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Teacher>> Delete(int id)
        {
            var deleteData = await _repository.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _repository.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Teacher>> Update([FromBody] Teacher teacher)
        {
            var updateData = await _repository.GetAllAsync();
            if (teacher is null)
                return NotFound();
            _repository.Update(teacher);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
