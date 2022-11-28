using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gp1.Controllers
{
    public class viewform
    {
        public int IdVideo {get; set;}
        public int IdUser {get; set;}
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private DB db = new DB();
        [HttpPost]
        public string AddView([FromForm] viewform viewform)
        {
            Views view = new Views();
            int idv = Convert.ToInt32(viewform.IdVideo);
            view.Video = db.videos.Find(idv);
            int idu = Convert.ToInt32(viewform.IdUser);
            view.User = db.users.Find(idu);
            db.Views.Add(view);
            db.SaveChanges();
            return "You Add view";
        }


        [HttpGet]
        public List<Views> GetViewsInvid(int idvid)
        {
            List<Views> views = db.Views.Include("User").Where(m=>m.Video.id == idvid).ToList();
            return views;
        }



        [HttpGet]
        public int Count_Views_In_Vid(int idvid)
        {
            List<Views> views = db.Views.Where(m => m.Video.id == idvid).ToList();
            return views.Count;
        }
        

        [HttpGet]
        public List<Views> Get_Views_with_user(int iduser)
        {
            List<Views> views = db.Views.Include("Video").Where(m => m.User.Id == iduser).ToList();
            return views;
        }

        [HttpGet]
        public int Count_Vid_Watched_by_User(int iduser)
        {
            List<Views> views = db.Views.Include("Video").Where(m => m.User.Id == iduser).ToList();
            return views.Count;
        }

    }
}
