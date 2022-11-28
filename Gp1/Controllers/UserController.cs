using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{

    public class UserForm
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? repassword { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? email { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DB db = new DB();

        [HttpPost]
        public string CreateUser([FromForm] UserForm userform)
        {
            if (userform.password != userform.repassword)
            {
                return "your Password not matched";
            }

            user user = new user();
            user.Fname = userform.Fname;
            user.Lname = userform.Lname;
            user.username = userform.username;
            user.password = userform.password;
            user.age = (int) userform.age;
            user.gender = userform.gender;
            user.email = userform.email;
            user.CreationTime = DateTime.Now.ToString("y:M:dd:h:mm:ss tt");
            db.users.Add(user);
            db.SaveChanges();
            return "User Is Created";
        }

        [HttpGet]
        public List<user> GetAllUsers()
        {
           return db.users.ToList();
        }

        [HttpGet]
        public user GetUser(int? id){

            int idint =Convert.ToInt32(id);
            return db.users.Find(idint);
        }

        [HttpDelete]
        public string DeleteUesr(int id)
        {
            try
            {
                user user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
                return "Is Deleted";
            }
            catch 
            {
                return "Isnot Deleted";
            }
        }
    }
}
