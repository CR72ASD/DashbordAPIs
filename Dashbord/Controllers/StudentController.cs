using Entity.Contexts;
using Entity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opration.InterFaces;

namespace Dashbord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DBAContext _context;
        private readonly IGenericRepository<Student> _repository;

        public StudentController(DBAContext context, IGenericRepository<Student> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("AddNew")]
        public async Task<ActionResult<Student>> AddNew([FromBody] Student student)
        {
            var result = await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Student>> GetByID(int Id)
        {
            var result = await _repository.GetByIdAsync(Id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var deleteData = await _repository.GetByIdAsync(id);
            if (deleteData is null)
                return NotFound();
            _repository.Delete(deleteData);
            await _context.SaveChangesAsync();
            return Ok(deleteData);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Student>> Update([FromBody]Student student)
        {
            var updateData = await _repository.GetAllAsync();
            if (student is null)
                return NotFound();
            _repository.Update(student);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
