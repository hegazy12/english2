using Gp1.model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gp1.model
{
    public class DB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;
                                          Database=Englearn11;
                                          Trusted_Connection=True");
        }
        
        public DbSet<user> users { get; set; }
        public DbSet<QuestionAnswers> questionAnswers { get; set; }
        public DbSet<SentenceAnswers> sentenceAnswers { get; set; }
        public DbSet<Video> videos {get; set;}
        public DbSet<Questions> questions {get; set;}
        public DbSet<SpokenSentence> spokenSentences {get; set; }
        public DbSet<comment> comments {get; set;}
        public DbSet<Views>  Views {get; set;}
    } 

    public class user
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public int deleteState { get; set; }
        public string CreationTime { get; set; }
        public virtual List<QuestionAnswers> QuestionAnswers { get; set; }
        public virtual List<SentenceAnswers> SentenceAnswers { get; set; }
        public virtual List<comment> Comments { get; set; }
        public virtual List<Views> Views { get; set; }
    }
    public class QuestionAnswers
    {
        public int Id {get; set;}
        public string Answers {get; set;}
        public string CorrectAnswer  {get; set;}
        public int IsCorrectAnswer {get; set;}
        public virtual Questions Question {get; set;}
        public virtual user User {get; set;}
        public string CreationTime {get; set;}

    }
    
    public class SentenceAnswers
    {
        public int Id {get; set;}
        public string Answers {get; set;}
        public string CorrectAnswer {get; set;}
        public int CorrectAnswePercentage {get; set;}
        public string CreationTime {get; set;}
        public virtual SpokenSentence Sentence {get; set;}
        public virtual user User {get; set;}
    }
    
    public class Video
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Link_Vid { get; set; }
        public string section {get; set;}
        public int deleteState {get; set;}
        public string CreationTime {get; set;}
        public virtual List<Questions> Questions {get; set;}
        public virtual List<SpokenSentence> SpokenSentences {get; set;}
        public virtual List<comment> Comments {get; set;}
        public virtual List<Views> Views {get; set;}
    }
    
    public class Views
    {
        public int id {get; set;}
        public virtual Video Video {get; set;}
        public virtual user User {get; set;}
    }
    public class Questions{
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
        public string CreationTime { get; set; }
        public int deleteState { get; set; }

        public virtual Video Video { get; set; }
        public virtual List<QuestionAnswers> QuestionAnswer { get; set; }
    }
    public class SpokenSentence 
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public int deleteState { get; set; }
        public string CreationTime { get; set; }
        public virtual Video Video { get; set; }
        public virtual List<SentenceAnswers> SentenceAnswers { get; set; }
    }
    public class comment {
        public int Id {get; set;}
        public string comm {get; set;}
        public string CreationTime { get; set; }
        public int deleteState {get; set;}
        public virtual user User {get; set;}
        public virtual Video Video {get; set;}
    }

}