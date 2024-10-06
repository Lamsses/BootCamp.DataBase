using BootCamp.DataBase.DataAccess;
using BootCamp.DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BootCamp.DataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly OTContext _context;
        public UserController(OTContext context)
        {
            _context = context;
        }




        [HttpGet("GetAllUsers")]

        public List<User> GetAllUsers()
        {

            return _context.Set<User>().ToList();

        }
        [HttpGet("GetUser/{name}")]
        public async Task<ActionResult<List<User>>> GetUser(string name)
        {
            var user = await _context.Set<User>().Where(u => u.Name == name).ToListAsync();
            return Ok(user);
        }

        [HttpPost("AddUser")]
        public User CreateUser(User addUser)
        {
            var user = _context.Set<User>().Add(addUser);
            _context.SaveChanges();

            return user.Entity;
        }
        [HttpPut("UpdateUser/{id}")]
        public User UpdateUser(User updateUser, int id)
        {

            var user = _context.Set<User>().AsNoTracking().FirstOrDefault( user => user.Id == id);
            updateUser.Id = user.Id;
            user = updateUser;
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Set<User>().AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
        
            _context.Remove(user);
            _context.SaveChanges();

            

            return Ok();
        }

    }
}
