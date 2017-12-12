using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HamAdept.HAM
{
    public static class HamDataHelper
    {
        // methods
        #region ImportData

        public static void ImportData(string directoryPath, ref int importedQuestionCount, ref int importedCategoryCount)
        {
            var questions = new List<Question>();
            var categories = new List<QuestionCategory>();
            var directoryInfo = new DirectoryInfo(directoryPath);
            foreach (var fileInfo in directoryInfo.GetFiles("*.ok2uec"))
            {
                var lines = File.ReadAllLines(fileInfo.FullName, Encoding.GetEncoding(1250));
                int categoryNumber = Convert.ToInt32(fileInfo.Name.Substring(0, fileInfo.Name.IndexOf('.')));
                var questionCount = (short) (lines.Length/4);
                var category = new QuestionCategory(GetCategoryName(categoryNumber), categoryNumber,
                    GetCategoryQuestionValue(categoryNumber), GetCategoryRequiredQuestionCount(categoryNumber),
                    questionCount, GetCategoryClass(categoryNumber));
                categories.Add(category);
                for (var i = 0; i < questionCount; i++)
                {
                    var questionText = lines[i*4];
                    var answer1 = new Answer(1, lines[i*4 + 1].Substring(1), lines[i*4 + 1].Substring(0, 1) == "1");
                    var answer2 = new Answer(2, lines[i*4 + 2].Substring(1), lines[i*4 + 2].Substring(0, 1) == "1");
                    var answer3 = new Answer(3, lines[i*4 + 3].Substring(1), lines[i*4 + 3].Substring(0, 1) == "1");
                    var question = new Question(categoryNumber*10000 + i, i, category.CategoryId, questionText,
                        new[] {answer1, answer2, answer3}.ToList());
                    questions.Add(question);
                }
            }
            var questionDataPath = Path.Combine(@".\Resources", "AllQuestions.xml");
            File.WriteAllText($"{questionDataPath}.tmp", Question.SerializeQuestions(questions));
            File.Replace($"{questionDataPath}.tmp", questionDataPath, $"{questionDataPath}.bak");
            importedQuestionCount = questions.Count;

            var categoriesDataPath = Path.Combine(@".\Resources", "QuestionCategories.xml");
            File.WriteAllText($"{categoriesDataPath}.tmp", QuestionCategory.SerializeCategories(categories));
            File.Replace($"{categoriesDataPath}.tmp", categoriesDataPath, $"{categoriesDataPath}.bak");
            importedCategoryCount = categories.Count;
        }

        #endregion
        #region GetCategoryClass

        public static CategoryClass GetCategoryClass(int categoryNumber)
        {
            var categoryClasses = CategoryClass.GetCategoryClasses();
            switch (categoryNumber)
            {
                case 1:
                case 2:
                case 3:
                    return categoryClasses.First(c => c.CategoryClassId == 1);
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return categoryClasses.First(c => c.CategoryClassId == 2);
                default:
                    return categoryClasses.First(c => c.CategoryClassId == 3);
            }
        }

        #endregion
        #region GetCategoryName

        public static string GetCategoryName(int categoryNumber)
        {
            switch (categoryNumber)
            {
                case 1:
                    return "Předpisy Mezinárodní telekomunikační unie (ITU)";
                case 2:
                    return "Předpisy Evropské konference poštovních a telekomunikačních správ (CEPT)";
                case 3:
                    return "Předpisy vycházející z legislativy České republiky";
                case 4:
                    return "Rozvrh kmitočtů a druhů provozu v radioamatérských pásmech";
                case 5:
                    return "Hláskovací abeceda (česká / mezinárodní)";
                case 6:
                    return "Provozní dovednosti";
                case 7:
                    return "Zkratky používané pro dotazy a sdělení (Q kódy)";
                case 8:
                    return "Zkratky používané v radioamatérské komunikaci";
                case 9:
                    return "Používání prefixů ve volacích značkách";
                case 10:
                    return "Elektrická, elektromagnetická a rádiová teorie";
                case 11:
                    return "Součástky";
                case 12:
                    return "Elektrické obvody";
                case 13:
                    return "Rádiové přijímače";
                case 14:
                    return "Rádiové vysílače";
                case 15:
                    return "Antény a napájecí vedení";
                case 16:
                    return "Šíření rádiových vln";
                case 17:
                    return "Měření elektrických veličin";
                case 18:
                    return "Rušení a odolnost proti rušení";
                case 19:
                    return "Bezpečnost elektrických zařízení";
                default:
                    return "Neznámá kategorie";
            }
        }

        #endregion
        #region GetCategoryRequiredQuestionCount

        public static short GetCategoryRequiredQuestionCount(int categoryNumber)
        {
            switch (categoryNumber)
            {
                case 1:
                    return 4;
                case 2:
                    return 4;
                case 3:
                    return 12;
                case 4:
                    return 10;
                case 5:
                    return 52;
                case 6:
                    return 10;
                case 7:
                    return 10;
                case 8:
                    return 45;
                case 9:
                    return 30;
                case 10:
                    return 6;
                case 11:
                    return 6;
                case 12:
                    return 5;
                case 13:
                    return 4;
                case 14:
                    return 4;
                case 15:
                    return 4;
                case 16:
                    return 4;
                case 17:
                    return 2;
                case 18:
                    return 2;
                case 19:
                    return 3;
                default:
                    return -1;
            }
        }

        #endregion
        #region GetCategoryQuestionValue

        public static short GetCategoryQuestionValue(int categoryNumber)
        {
            switch (categoryNumber)
            {
                case 4:
                    return 7;
                case 5:
                    return 1;
                case 6:
                    return 5;
                case 7:
                    return 5;
                case 8:
                    return 2;
                case 9:
                    return 2;
                default:
                    return 1;
            }
        }

        #endregion
    }
}
