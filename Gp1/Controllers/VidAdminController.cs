using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gp1.model;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VidAdminController : ControllerBase
    {
        private DB db = new DB();

        private readonly IWebHostEnvironment webHostEnv;

        public VidAdminController(IWebHostEnvironment webHostEnvironment)
        {
            webHostEnv = webHostEnvironment;
        }

        [HttpPost]
        public string uploadvideo([FromForm] IList<IFormFile> files, [FromForm] string name, [FromForm] string section)
        {
            if (files == null)
            {
                return "bad";
            }
            try
            {
                foreach (var file in files)
                {
                    string Pathvid = Path.Combine(webHostEnv.ContentRootPath, "vid");
                    Video vid;
                    string filepath = Path.Combine(Pathvid, file.FileName);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    vid = new Video();
                    vid.Name = name;
                    vid.section = section;
                    vid.Link_Vid = "/vid/" + file.FileName;
                    vid.CreationTime = DateTime.Now.ToString("y:M:dd:h:mm:ss tt");
                    db.videos.Add(vid);
                    db.SaveChanges();
                }
            }
            catch
            {
                return "bad";
            }
            return "ok";
        }

        [HttpGet]
        public List<Video> GetAllVideos()
        {
            return db.videos.ToList();
        }

        [HttpGet]
        public Video GetVideo(int? id) 
        {
            int idint = Convert.ToInt32(id);
            Video vid = db.videos.Where(s=>s.id==idint).Include(m=>m.Questions).First();
            return vid;
        }

        [HttpDelete]
        public string Deletevid(int? id)
        {
            try
            {
                int idint = Convert.ToInt32(id);
                Video vid = db.videos.Find(idint);
                db.videos.Remove(vid);
                db.SaveChanges();
                return "Good Job";
            }
            catch
            {
                return "Dad Job";
            }
        }

    }
}