using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{

    public class Questionform
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
        public int Vid { get; set; }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private DB db = new DB();
        [HttpPost]
        public string SetQuestion([FromForm] Questionform questionform)
        {

            Questions question = new Questions();

            question.Question = questionform.Question;
            question.Answer1 = questionform.Answer1;
            question.Answer2 = questionform.Answer2;
            question.Answer3 = questionform.Answer3;
            question.Answer4 = questionform.Answer4;
            question.CorrectAnswer = questionform.CorrectAnswer;
           
            question.Video = db.videos.Find(questionform.Vid);
            question.CreationTime = DateTime.Now.ToString(" y:M:dd:h:mm:ss tt");
            db.questions.Add(question);
            db.SaveChanges();

            return "Ok";
        }

        [HttpGet]
        public List<Questions> GetAllQuestions()
        {
            return db.questions.ToList();
        }

        [HttpGet]
        public Questions GetQuestions(int? id)
        {
            int idint = Convert.ToInt32(id);
            return db.questions.Find(idint);
        }



        [HttpDelete]
        public string deleteQuestion(int? id)
        {
            int idint = Convert.ToInt32(id);
            Questions question = db.questions.Find(idint);
            db.questions.Remove(question);
            db.SaveChanges();
            return "ok";
        }
    }
}
