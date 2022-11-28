using Gp1.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gp1.Controllers
{
    public class AnsQue
    {
        public int IdUser { get; set; }
        public int IdQue { get; set;}
        public string CorrectAns { get; set; }
        public string UserAns { get; set; }
        public int iscorrect { get; set; }
    }


    [Route("[controller]/[action]")]
    [ApiController]
    public class Question_Answers_LogController : ControllerBase
    {
        private DB db = new DB();

        [HttpPost]
        public string AnsQuePost([FromForm] AnsQue AnsQue)
        {
            user user = db.users.Find(AnsQue.IdUser);
            Questions questions = db.questions.Find(AnsQue.IdQue);

            QuestionAnswers questionAnswers = new QuestionAnswers
            {
                CreationTime = DateTime.Now.ToString("y:M:dd:h:mm:ss tt"),
                CorrectAnswer = AnsQue.CorrectAns,
                User = user,
                Question = questions,
                Answers = AnsQue.UserAns,
                IsCorrectAnswer = AnsQue.iscorrect
            };

            db.questionAnswers.Add(questionAnswers);
            db.SaveChanges();
            return "good jop";
        }
    }
}
