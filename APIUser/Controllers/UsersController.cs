using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIUser.Models;
using Npgsql;
using System.Data;

namespace APIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUser()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Users = await _context.Users.FindAsync(id);

            if (Users == null)
            {
                return NotFound();
            }

            return Ok(Users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] Guid id, [FromBody] Users Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(Users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] Users Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(Users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = Users.UserId }, Users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Users = await _context.Users.FindAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(Users);
            await _context.SaveChangesAsync();

            return Ok(Users);
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        //private void connection()
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        // PostgeSQL-style connection string
        //        string connstring = String.Format("Server={0};Port={1};" +
        //            "Users Id={2};Password={3};Database={4};",
        //            "51.159.27.4", "35175", "ducklingSocial",
        //            "Epsi2019!", "UserDb");
        //        // Making connection with Npgsql provider
        //        NpgsqlConnection conn = new NpgsqlConnection(connstring);
        //        conn.Open();
        //        // quite complex sql statement
        //        string sql = "SELECT * FROM Users";
        //        // data adapter making request from our connection
        //        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
        //        // i always reset DataSet before i do
        //        // something with it.... i don't know why :-)
        //        ds.Reset();
        //        // filling DataSet with result from NpgsqlDataAdapter
        //        da.Fill(ds);
        //        // since it C# DataSet can handle multiple tables, we will select first
        //        dt = ds.Tables[0];
        //        // connect grid to DataTable
        //        conn.Close();
        //    }
        //    catch (Exception msg)
        //    {
        //        // something went wrong, and you wanna know why
        //        MessageBox.Show(msg.ToString());
        //        throw;
        //    }
        //}
    }
}