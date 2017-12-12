using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;
using HamAdept.HAM;
using HamAdept.Extensions;
using HamAdept.Localization;

namespace HamAdept
{
    public partial class Form1 : Form
    {
        #region Constructor

        private List<Question> _questions;
        private List<QuestionCategory> _categories;
        private readonly Random _random1 = new Random(Convert.ToInt32(DateTime.Now.Ticks % int.MaxValue));
        private readonly Random _random2 = new Random(Convert.ToInt32((DateTime.Now.Ticks + 1000) % int.MaxValue));
        private Question _actualQuestion;
        private Statistics _statistics;
        private string _categoryToBeTrained = "BTN_ALL";
        private bool _sequentionalTraining;
        private int _currentSequencePosition;
        private readonly LocalizedTexts _texts = new LocalizedTexts();

        public Form1()
        {
            InitializeComponent();
            InitializeData();
            InitializeMenu();
        }

        #endregion

        // methods
        #region ViewQuestion

        private void ViewQuestion()
        {
            var categoryId = -1;
            if (_categories.Any(c => c.CategoryId.ToString() == _categoryToBeTrained))
            {
                categoryId = _categories.First(c => c.CategoryId.ToString() == _categoryToBeTrained).CategoryId;
            }

            var chooseFromMistaken = !_sequentionalTraining && _statistics.MistakenQuestionIds.Any() &&
                                     (problematicToolButton.Checked || _random2.Next(1, 11)%7 == 0);
            if (problematicToolButton.Checked && !_statistics.MistakenQuestionIds.Any())
            {
                WriteLogMessage(_texts.GetLocalizedText("MSG_ProblematicEmpty"));
                WriteLogMessage(_texts.GetLocalizedText("MSG_SwitchingToAll"));
                problematicToolButton.Checked = false;
                allToolStripButton.Checked = true;
            }
            var question = chooseFromMistaken ? GetRandomFromMistakenQuestions() : GetNextQuestion(categoryId);

            _actualQuestion = question;
            var category = _categories.First(c => c.CategoryId == question.CategoryId);
            textBox1.Text = $"{category.CategoryName} [{category.CategoryClass.CategoryClassName}]";
            textBox2.Text = $"{question.Text}";
            WriteLogMessage(_texts.GetLocalizedText("MSG_SelectedQuestion", $"[T:{category.CategoryClass.CategoryClassId}/K:{category.CategoryId}/O:{question.InCategoryQuestionId}]"));
            var i = _random1.Next(1, 3);
            var answers = question.Answers.ToArray();
            radioButton1.Text = answers[i % 3].Text;
            var j = _random2.Next(1, 2);
            radioButton2.Text = answers[(i + j) % 3].Text;
            radioButton3.Text = answers[(i + j + 1) % 3].Text;
            EnableAnswering();
        }

        #endregion
        #region EnableAnswering

        private void EnableAnswering()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton1.CheckedChanged += OnCheckedChanged;
            radioButton2.CheckedChanged += OnCheckedChanged;
            radioButton3.CheckedChanged += OnCheckedChanged;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
        }

        #endregion
        #region DisableAnswering

        private void DisableAnswering()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton1.CheckedChanged -= OnCheckedChanged;
            radioButton2.CheckedChanged -= OnCheckedChanged;
            radioButton3.CheckedChanged -= OnCheckedChanged;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        #endregion
        #region WriteLogMessage

        private void WriteLogMessage(string message)
        {
            listBox1.Items.Insert(0, message);
        }

        #endregion
        #region InitializeData

        private void InitializeData()
        {
            _questions = Question.LoadQuestions();
            _categories = QuestionCategory.LoadQuestionCategories();
            _statistics = Statistics.Load();
        }

        #endregion
        #region InitializeMenu

        private void InitializeMenu()
        {
            allToolStripButton.Checked = true;
            problematicToolButton.Checked = false;
            _categories.Sort();
            foreach (var category in _categories)
            {
                trainingToolStripMenuItem.DropDownItems.Add(
                    new ToolStripButton($"{category.CategoryId}. {category.CategoryName}")
                    {
                        Tag = category.CategoryId.ToString(),
                        CheckOnClick = true
                    });
            }
            foreach (var menuItem in trainingToolStripMenuItem.DropDownItems.OfType<ToolStripButton>())
            {
                menuItem.Click += (sender, args) =>
                {
                    _categoryToBeTrained = (string) ((ToolStripButton) sender).Tag;
                    if (_categoryToBeTrained == "BTN_PROBLEMATIC" && _sequentionalTraining)
                    {
                        _sequentionalTraining = false;
                        WriteLogMessage(_texts.GetLocalizedText("MSG_BackToRandom"));
                    }
                    //if (_categoryToBeTrained.Contains(". "))
                    //{
                    //    var index = _categoryToBeTrained.IndexOf(". ", StringComparison.Ordinal);
                    //    _categoryToBeTrained = _categoryToBeTrained.Substring(index + 2);
                    //}
                    foreach (ToolStripButton button in ((ToolStripButton) sender).GetCurrentParent().Items)
                    {
                        if (button == sender) button.Checked = true;
                        if ((button != null) && (button != sender))
                        {
                            button.Checked = false;
                        }
                    }
                    ResetQuestion();
                };
            }
            foreach (var menuItem in questionOrderingToolStripMenuItem.DropDownItems.OfType<ToolStripButton>())
            {
                menuItem.Click += (sender, args) =>
                {
                    _sequentionalTraining = (string) ((ToolStripButton) sender).Tag == "BTN_SEQUENCE";
                    if (_categoryToBeTrained == "BTN_PROBLEMATIC" && _sequentionalTraining)
                    {
                        _sequentionalTraining = false;
                        WriteLogMessage(_texts.GetLocalizedText("MSG_BackToRandom"));
                        return;
                    }
                    foreach (ToolStripButton button in ((ToolStripButton) sender).GetCurrentParent().Items)
                    {
                        if (button == sender) button.Checked = true;
                        if ((button != null) && (button != sender))
                        {
                            button.Checked = false;
                        }
                    }
                    ResetQuestion();
                };
            }
        }

        #endregion
        #region ResetQuestion

        private void ResetQuestion()
        {
            Dispatcher.CurrentDispatcher.InvokeThreadSafe(() =>
            {
                _currentSequencePosition = 0;
                DisableAnswering();
                ViewQuestion();
            });
        }

        #endregion
        #region InformLoaded

        private void InformLoaded()
        {
            WriteLogMessage(_texts.GetLocalizedText("MSG_CategoriesLoaded", _categories.Count));
            WriteLogMessage(_texts.GetLocalizedText("MSG_QuestionsLoaded", _questions.Count));
        }

        #endregion
        #region GetNextQuestion

        private Question GetNextQuestion(int categoryId)
        {
            if (_sequentionalTraining)
            {
                var retQuestion = default(Question);
                if (categoryId < 0)
                {
                    if (_currentSequencePosition >= _questions.Count)
                    {
                        _currentSequencePosition = 0;
                    }
                    retQuestion = _questions[_currentSequencePosition];
                }
                if (_questions.Any(q => q.CategoryId == categoryId))
                {
                    if (_currentSequencePosition >= _questions.Count(q => q.CategoryId == categoryId))
                    {
                        _currentSequencePosition = 0;
                    }
                    retQuestion = _questions.Where(q => q.CategoryId == categoryId).ToArray()[_currentSequencePosition];
                }
                _currentSequencePosition++;
                return retQuestion;
            }
            return GetRandomQuestion(categoryId);
        }

        #endregion
        #region GetRandomQuestion

        private Question GetRandomQuestion(int categoryId)
        {
            if (categoryId < 0)
            {
                var i = _random1.Next(0, _questions.Count - 1);
                return _questions[i];
            }
            if (_questions.Any(q => q.CategoryId == categoryId))
            {
                var j = _random1.Next(0, _questions.Count(q => q.CategoryId == categoryId) - 1);

                return _questions.Where(q => q.CategoryId == categoryId).ToArray()[j];
            }
            return new Question();
        }

        #endregion
        #region ImportQuestionsMenuItemClick

        private void ImportQuestionsMenuItemClick(object sender, EventArgs e)
        {
            var questionCount = 0;
            var categoryCount = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileInfo = new FileInfo(openFileDialog1.FileName);
                HamDataHelper.ImportData(fileInfo.Directory?.FullName, ref questionCount, ref categoryCount);
            }
            WriteLogMessage(_texts.GetLocalizedText("MSG_CategoriesImported", _categories.Count));
            WriteLogMessage(_texts.GetLocalizedText("MSG_QuestionsImported", _questions.Count));
            try
            {
                InitializeData();
                InformLoaded();
            }
            catch (Exception exception)
            {
                WriteLogMessage(exception.Message);
            }
        }

        #endregion
        #region AnswerSelected

        private void AnswerSelected(string answerText)
        {
            var isCorrectlyAnswered = answerText == _actualQuestion.Answers.First(a => a.IsCorrect).Text;
            DisableAnswering();
            LogCurrentQuestionAndAnswer(isCorrectlyAnswered, answerText);
            ViewQuestion();
        }

        #endregion
        #region GetRandomFromMistakenQuestions

        private Question GetRandomFromMistakenQuestions()
        {
            WriteLogMessage(_texts.GetLocalizedText("MSG_SelectedFromProblematic"));
            var randomId =
                _statistics.MistakenQuestionIds.ToArray()[_random1.Next(0, _statistics.MistakenQuestionIds.Count)];
            _statistics.MistakenQuestionIds.Remove(randomId);
            _statistics.Save();
            return _questions.First(q => q.OverAllQuestionId == randomId);
        }

        #endregion
        #region LogCurrentQuestion

        private void LogCurrentQuestionAndAnswer(bool isCorrectlyAnswered, string answeredText)
        {
            if (!isCorrectlyAnswered)
            {
                if (!_statistics.MistakenQuestionIds.Contains(_actualQuestion.OverAllQuestionId))
                {
                    _statistics.MistakenQuestionIds.Add(_actualQuestion.OverAllQuestionId);
                }
            }
            if (_statistics.ViewedQuestions.All(s => s.QuestionId != _actualQuestion.OverAllQuestionId))
            {
                _statistics.ViewedQuestions.Add(new QuestionStatistic {QuestionId = _actualQuestion.OverAllQuestionId, Count = 1});
            }
            else
            {
                _statistics.ViewedQuestions.First(s => s.QuestionId == _actualQuestion.OverAllQuestionId).Count++;
            }
            _statistics.Save();
            var category = _categories.First(c => c.CategoryId == _actualQuestion.CategoryId);
            var doneText = isCorrectlyAnswered ? _texts.GetLocalizedText("MSG_Correct") : _texts.GetLocalizedText("MSG_Wrong");
            var doneColor = isCorrectlyAnswered ? Color.DarkGreen : Color.DarkRed;
            richTextBox1.PrependText("---\r\n", Color.LightGray);
            var answers = _actualQuestion.Answers.ToArray();
            foreach (var answer in answers.Reverse())
            {
                richTextBox1.PrependText($" - {answer.Text}\r\n", answer.IsCorrect ? Color.DarkGreen : richTextBox1.ForeColor, !isCorrectlyAnswered && answer.Text == answeredText);
            }
            richTextBox1.PrependText($"{_actualQuestion.Text}? ({category.CategoryName} [{category.CategoryClass.CategoryClassName}])\r\n", richTextBox1.ForeColor);
            richTextBox1.PrependText($"{doneText}: ", doneColor);
        }

        #endregion

        // method (events fired)
        #region OnForm1Load

        private void OnForm1Load(object sender, EventArgs e)
        {
            WriteLogMessage(_texts.GetLocalizedText("MSG_Welcome"));
            InformLoaded();
            ViewQuestion();
        }

        #endregion
        #region OnCheckedChanged

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            Dispatcher.CurrentDispatcher.InvokeThreadSafe(() => AnswerSelected(radioButton?.Text));
        }

        #endregion
        #region OnDeleteStatisticsToolStripMenuItemClick

        private void OnDeleteStatisticsToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(_texts.GetLocalizedText("MSG_DeletingStatistics"),
                _texts.GetLocalizedText("MSG_Warning"), MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            _statistics = new Statistics();
            _statistics.Save();
            WriteLogMessage(_texts.GetLocalizedText("MSG_StatisticsDeletingDone"));
        }

        #endregion
        #region OnAboutToolStripMenuItemClick

        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            MessageBox.Show(_texts.GetLocalizedText("MSG_AboutText"), _texts.GetLocalizedText("MSG_AboutCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
