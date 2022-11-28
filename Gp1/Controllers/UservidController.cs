using Gp1.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VidUserController : ControllerBase
    {
        private DB db = new DB();

        [HttpGet]
        public Video GetVideo(int? id)
        {
            int videoId = Convert.ToInt32(id);
            return db.videos.Include("Questions")
                            .Include("SpokenSentences")
                            .Include("Comments")
                            .FirstOrDefault(c => c.id == videoId);
        }
    }
}
