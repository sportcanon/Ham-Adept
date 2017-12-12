using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HamAdept.HAM
{
    public class Statistics
    {
        #region Constructor

        private List<int> _mistakenQuestionIds = new List<int>();
        private List<QuestionStatistic> _viewedQuestions = new List<QuestionStatistic>();

        public Statistics()
        {
            
        }

        #endregion

        // properties
        #region @ MistakenQuestionIds

        public List<int> MistakenQuestionIds
        {
            get { return _mistakenQuestionIds; }
            set { _mistakenQuestionIds = value; }
        }

        #endregion	
        #region @ ViewedQuestions

        public List<QuestionStatistic> ViewedQuestions
        {
            get { return _viewedQuestions; }
            set { _viewedQuestions = value; }
        }

        #endregion	

        // methods
        #region Serialize

        public string Serialize()
        {
            var serializer = new XmlSerializer(typeof(Statistics));
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true }))
                {
                    serializer.Serialize(writer, this);
                    writer.Flush();
                    return stringWriter.ToString().Replace("utf-16", "utf-8");
                }
            }
        }

        #endregion
        #region Save

        public void Save()
        {
            File.WriteAllText(@".\Resources\Statistics.xml", Serialize());
        }

        #endregion
        #region Load

        public static Statistics Load()
        {
            var path = @".\Resources\Statistics.xml";
            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                {
                    var serializer = new XmlSerializer(typeof (Statistics));
                    return serializer.Deserialize(stream) as Statistics;
                }
            }
            return new Statistics();
        }

        #endregion
    }
}
