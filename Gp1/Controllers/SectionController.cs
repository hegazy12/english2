using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private DB db = new DB();
        
        [HttpGet]
        public List<Video> GitVideo(string name)
        {
           return db.videos.Where(m => m.section == name).ToList();
        }
    }
}