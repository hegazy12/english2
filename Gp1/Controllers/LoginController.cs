using Gp1.model;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private DB db = new DB();

        [HttpPost]
        public int login([FromForm] string username, [FromForm] string pass)
        {
            user user = db.users.Where(m => m.username == username && m.password == pass).First();
            if(user == null)
            {
                return 0;
            }
            return user.Id;
        }
    }
}
