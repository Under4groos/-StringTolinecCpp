using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace StringTolinecCpp
{
    public static class StaticRichTextBox
    {
        public static void SetText(this RichTextBox rb , string text)
        {
            if (rb == null)
                return;
            rb.Document.Blocks.Clear();
            rb.Document.Blocks.Add(new Paragraph(new Run(text )));
        }
        public static string GetText(this RichTextBox rb)
        {
            if (rb == null)
                return "";
            return new TextRange(rb.Document.ContentStart, rb.Document.ContentEnd).Text;
        }
    }
}
