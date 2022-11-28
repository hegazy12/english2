using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gp1.model;
using Microsoft.EntityFrameworkCore;

namespace Gp1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MyAnswerController : ControllerBase
    {
        private DB db = new DB();

        [HttpGet]
        public List<QuestionAnswers> Get_Question_Answers(int? IdUser)
        {

            List<QuestionAnswers> 
                 questionAnswers 
                 = 
                 db
                 .questionAnswers
                 .Include("Question")
                 .Where(m => m.User.Id == IdUser)
                 .ToList();
           
            return questionAnswers;
        }

        [HttpGet]
        public int Get_Question_Answers_Count(int IdUser)
        {
            return db.questionAnswers.Where(m => m.User.Id == IdUser).ToList().Count;
        }

        [HttpGet]
        public int Get_Question_Answers_Count_mistake(int IdUser)
        {
            return db.
                    questionAnswers.
                    Where(m => m.User.Id == IdUser && m.IsCorrectAnswer == 0).
                    ToList().
                    Count;
        }

        [HttpGet]
        public int Get_Question_Answers_Count_Right(int IdUser)
        {
            return db.
                   questionAnswers.
                   Where(m => m.User.Id == IdUser && m.IsCorrectAnswer == 1).
                   ToList().
                   Count;
        }

        [HttpGet]
        public List<SentenceAnswers> Get_Sentence_Answers(int IdUser)
        {
            return db.
                   sentenceAnswers.
                   Include("SpokenSentence").
                   Where(m => m.User.Id == IdUser).
                   ToList();
        }

        [HttpGet]
        public int Get_Sentence_Answers_count(int IdUser)
        {
            return db.
                   sentenceAnswers.
                   Include("Sentence").
                   Where(m => m.User.Id == IdUser).
                   ToList().Count;
        }

        [HttpGet]
        public int Get_Sentence_Answers_count_mistake(int IdUser)
        {
            return db
                .sentenceAnswers
                .Where(m => m.User.Id == IdUser && m.CorrectAnswePercentage==89).ToList().Count;
        }

    }
}