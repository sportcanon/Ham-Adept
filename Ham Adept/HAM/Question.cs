using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HamAdept.HAM
{
    public class Question
    {
        #region Constructor

        public Question()
        {

        }

        public Question(int overAllId, int inCategoryQuestionId, int categoryId, string text, List<Answer> answers)
        {
            OverAllQuestionId = overAllId;
            InCategoryQuestionId = inCategoryQuestionId;
            CategoryId = categoryId;
            Text = text;
            Answers = answers;
        }

        #endregion

        // properties
        #region @ OverAllQuestionId

        public int OverAllQuestionId { get; set; }

        #endregion
        #region @ InCategoryQuestionId

        public int InCategoryQuestionId { get; set; }

        #endregion
        #region @ CategoryId

        public int CategoryId { get; set; }

        #endregion
        #region @ Text

        public string Text { get; set; }

        #endregion
        #region @ Answers

        public List<Answer> Answers { get; set; }

        #endregion

        // methods
        #region SerializeQuestions

        public static string SerializeQuestions(List<Question> questions)
        {
            var serializer = new XmlSerializer(typeof (List<Question>));
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true}))
                {
                    serializer.Serialize(writer, questions);
                    writer.Flush();
                    return stringWriter.ToString().Replace("utf-16", "utf-8");
                }
            }
        }

        #endregion
        #region LoadQuestions

        public static List<Question> LoadQuestions()
        {
            using (var stream = File.OpenRead(@".\Resources\AllQuestions.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Question>));
                return serializer.Deserialize(stream) as List<Question>;
            }
        }

        #endregion

    }
}
