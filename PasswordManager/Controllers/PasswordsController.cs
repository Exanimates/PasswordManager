using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;

namespace PasswordManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordsController : ControllerBase
    {
        PasswordsContext db;
        public PasswordsController(PasswordsContext context)
        {
            db = context;
            if (!db.Passwords.Any())
            {
                db.Passwords.Add(new Password { Name = "Pass1", Login = "Igor", Pass = "123", Comment = "EasyPassword", Tags = "Easy"});
                db.Passwords.Add(new Password { Name = "Pass2", Login = "Andrey", Pass = "1234", Comment = "HardPassword", Tags = "NotEasy" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Password> Get()
        {
            return db.Passwords.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Password> Get(int id)
        {
            Password user = db.Passwords.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Password> Post(Password password)
        {
            if (password == null)
            {
                return BadRequest();
            }

            db.Passwords.Add(password);
            db.SaveChanges();
            return Ok(password);
        }

        // PUT api/users/
        [HttpPut]
        public ActionResult<Password> Put(Password password)
        {
            if (password == null)
            {
                return BadRequest();
            }
            if (!db.Passwords.Any(x => x.Id == password.Id))
            {
                return NotFound();
            }

            db.Update(password);
            db.SaveChanges();
            return Ok(password);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Password> Delete(int id)
        {
            Password user = db.Passwords.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Passwords.Remove(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}
