using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableIntro
{
#nullable enable 
    public class SurveyRun
    {
        private List<SurveyQuestion> surveyQuestions = new List<SurveyQuestion>();
        public IEnumerable<SurveyResponse> AllParticipants => (respondents ?? Enumerable.Empty<SurveyResponse>());
        public ICollection<SurveyQuestion> Questions => surveyQuestions;
        public SurveyQuestion GetQuestion(int index) => surveyQuestions[index];

        public void AddQuestion(SurveyQuestion question) => surveyQuestions.Add(question);
        public void AddQuestion(QuestionType type, string question) =>
           AddQuestion(new SurveyQuestion(type, question));

        private List<SurveyResponse>? respondents;

        public void PerformSurvey(int numberOfRespondents)
        {
            int respondentsConsenting = 0;
            respondents = new List<SurveyResponse>();
            while (respondentsConsenting < numberOfRespondents)
            {
                var respondent = SurveyResponse.GetRandomId();
                if(respondent.AnswerSurvey(surveyQuestions))
                {
                    respondentsConsenting++;
                }
                respondents.Add(respondent);
            }
        }
    }
}
