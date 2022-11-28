using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    public class Sentenceform
    {
        public string Sentence { get; set; }
        public int Vid { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private DB db = new DB();

        [HttpPost]
        public string SetSentence([FromForm] Sentenceform sentenceform)
        {
            try
            {
                SpokenSentence spokenSentence = new SpokenSentence();
                spokenSentence.Sentence = sentenceform.Sentence;
                spokenSentence.Video = db.videos.Find(sentenceform.Vid);
                spokenSentence.CreationTime = DateTime.Now.ToString("y:M:dd:h:mm:ss tt");
                db.spokenSentences.Add(spokenSentence);
                db.SaveChanges();
            }
            catch
            {
                return "bad";
            }

            return "ok";
        }

        [HttpGet]
        public SpokenSentence GetSentence(int? id)
        {
            int idint = Convert.ToInt32(id);
            return db.spokenSentences.Find(idint);
        }

        [HttpGet]
        public List<SpokenSentence> GetAllSentences()
        {
            return db.spokenSentences.ToList();
        }
        
        [HttpDelete]
        public string DeleteSentence(int? id)
        {
            try
            {
                int idint = Convert.ToInt32(id);
                SpokenSentence ss = db.spokenSentences.Find(idint);
                db.spokenSentences.Remove(ss);
                db.SaveChanges();
                return "is deleted";
            }
            catch
            {
                return "isnot deleted";
            }
        }

    }
}
