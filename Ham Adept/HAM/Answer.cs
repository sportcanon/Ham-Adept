namespace HamAdept.HAM
{
    public class Answer
    {
        #region Constructor

        public Answer()
        {

        }

        public Answer(int answerId, string text, bool isCorrect)
        {
            AnswerId = answerId;
            Text = text;
            IsCorrect = isCorrect;
        }

        #endregion

        // properties
        #region @ AnswerId

        public int AnswerId { get; set; }

        #endregion
        #region  @ Text

        public string Text { get; set; }

        #endregion
        #region  @ IsCorrect

        public bool IsCorrect { get; set; }

        #endregion

    }
}