using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    public class commentform
    {
        public int IdUser {get; set;}
        public int IdVid {get; set;}
        public string strcoment { get; set;}
    }


    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private DB db = new DB();

        [HttpPost]
        public string PutComment(commentform commentform)
        {
            user user = db.users.Find(commentform.IdUser);

            Video video = db.videos.Find(commentform.IdVid);

            comment comment = new comment
            {
                CreationTime = DateTime.Now.ToString("y:M:dd:h:mm:ss tt"),
                User = user,
                Video = video,
                comm= commentform.strcoment
            };

            db.comments.Add(comment);
            db.SaveChanges();
            return "good job";
        }

        [HttpDelete]
        public string deletecomm(int id)
        {
             
            comment comment = db.comments.Find(id);
            db.comments.Remove(comment);
            db.SaveChanges();
            return "is deleted";
        }
    }
}





