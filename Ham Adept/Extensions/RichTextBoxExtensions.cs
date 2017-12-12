using System.Drawing;
using System.Windows.Forms;

namespace HamAdept.Extensions
{
    public static class RichTextBoxExtensions
    {
        #region PrependText

        public static void PrependText(this RichTextBox box, string text, Color color, bool strikeout = false)
        {
            box.PrependText(text);
            box.Select(0, text.TrimEnd('\n').TrimEnd('\r').Length);
            box.SelectionColor = color;
            box.SelectionFont = strikeout ? new Font(box.Font, FontStyle.Strikeout | box.Font.Style) : box.Font;
            box.Select(0, 0);
        }

        private static void PrependText(this TextBoxBase textBox, string text)
        {
            if (text.Length <= 0)
            {
                return;
            }

            var start = textBox.SelectionStart;
            var length = textBox.SelectionLength;
            try
            {
                textBox.Select(0, 0);
                textBox.SelectedText = text;
            }
            finally
            {
                if (textBox.Width == 0 || textBox.Height == 0)
                {
                    textBox.Select(start, length);
                }
                textBox.Select(0, 0);
            }
        }
        #endregion
    }
}