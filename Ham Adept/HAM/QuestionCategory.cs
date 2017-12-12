using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HamAdept.HAM
{
    public class QuestionCategory : IComparable<QuestionCategory>
    {
        #region QuestionCategory

        public QuestionCategory()
        {

        }

        public QuestionCategory(string name, int id, short questionValue, short requiredCount, short totalCount, CategoryClass categoryClass)
        {
            CategoryName = name;
            CategoryId = id;
            CategoryQuestionValue = questionValue;
            CategoryRequiredQuestionCount = requiredCount;
            CategoryQuestionCount = totalCount;
            CategoryClass = categoryClass;
        }

        #endregion

        // properties
        #region @ CategoryName

        public string CategoryName { get; set; }

        #endregion
        #region @ CategoryId

        public int CategoryId { get; set; }

        #endregion
        #region @ CategoryQuestionValue

        public short CategoryQuestionValue { get; set; }

        #endregion
        #region @ CategoryRequiredQuestionCount

        public short CategoryRequiredQuestionCount { get; set; }

        #endregion
        #region @ CategoryQuestionCount

        public short CategoryQuestionCount { get; set; }

        #endregion
        #region @ CategoryClass

        public CategoryClass CategoryClass { get; set; }

        #endregion

        // methods
        #region SerializeCategories

        public static string SerializeCategories(List<QuestionCategory> categories)
        {
            var serializer = new XmlSerializer(typeof (List<QuestionCategory>));
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true }))
                {
                    serializer.Serialize(writer, categories);
                    writer.Flush();
                    return stringWriter.ToString().Replace("utf-16", "utf-8");
                }
            }
        }

        #endregion
        #region LoadQuestionCategories

        public static List<QuestionCategory> LoadQuestionCategories()
        {
            using (var stream = File.OpenRead(@".\Resources\QuestionCategories.xml"))
            {
                var serializer = new XmlSerializer(typeof (List<QuestionCategory>));
                return serializer.Deserialize(stream) as List<QuestionCategory>;
            }
        }

        #endregion
        #region CompareTo

        public int CompareTo(QuestionCategory other)
        {
            return other == null ? 1 : CategoryId.CompareTo(other.CategoryId);
        }

        #endregion
    }
}