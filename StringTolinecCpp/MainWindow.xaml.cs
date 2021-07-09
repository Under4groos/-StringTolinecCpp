using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StringTolinecCpp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string used_f = "";
        private string name_per = "";
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in new List<string>()
            {
                "string","int","List<char>",
                "List<string>","List<int>"
            })
            {
                Usedg.Items.Add(item);

            }

            Usedg.SelectionChanged += (o, e) =>
            {

                object select_item = Usedg.Items[Usedg.SelectedIndex];
                if (select_item is string)
                {
                    used_f = select_item as string;
                    NAme.Text = name_per = used_f.mul_replace(new List<string> { "<", ">" }, "_").ToUpper();
                    Convert();
                }
            };
            Usedg.SelectedIndex = 0;
        }


        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Convert();
        }

        public void Convert()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text_all = richTextBox.GetText();

            string ret_all = "";
            if (richTextBox1 == null)
                return;

            switch (used_f)
            {
                case "string":
                    ret_all = $"string {name_per} = \"\";\n";
                    foreach (string item in text_all.Split(new char[] { '\n' }))
                    {
                        if (!item.is_vlaid_string())
                        {

                            string t = item.mul_replace(new List<string> { Properties.Resources.test }, "");
                            if (t.Length >= 1)
                            {
                                ret_all += $" {name_per} += \" { t.Replace("\"", "\\\"") } \";\n";
                            }

                        }
                    }
                    break;
                case "int":
                    ret_all = $"int {name_per} = 0 ;\n";
                    foreach (string item in text_all.Split(new char[] { '\n' }))
                    {
                        if (!item.is_vlaid_string())
                        {

                            string t = item.mul_replace(new List<string> { Properties.Resources.test, " " }, "");
                            if (t.Length >= 1)
                                ret_all += $"{name_per} += { t.GetTextNumber() };\n";
                        }
                    }
                    break;
                case "List<char>":
                    ret_all = $"List<char> {name_per} = {"new List<char>\n{\n"}";

                    foreach (string item in text_all.Split(new char[] { '\n' }))
                    {

                        if (item.is_vlaid_string() == false)
                        {

                            string t = item.mul_replace(new List<string> { Properties.Resources.test, " " }, "");

                            foreach (var char_c in t)
                            {
                                ret_all += $"\'{ char_c }\',";

                            }

                            if (t != "")
                                ret_all += "\n";
                        }
                    }
                    ret_all += "};"; 
                    break;
                case "List<string>":
                    ret_all = $"List<string> {name_per} = {"new List<string>\n{\n"}";




                    foreach (string item in text_all.Split(new char[] { '\n' }))
                    {

                        if (item.is_vlaid_string() == false)
                        {

                            string t = item.mul_replace(new List<string> { Properties.Resources.test, " " }, "");
                            if (t.Length >= 1)
                                ret_all += $"\"{ t.Replace("\"", "\\\"") }\",";
                            if (t != "")
                                ret_all += "\n";
                        }
                    }
                    ret_all += "};";
                    break;
                case "List<int>":
                    ret_all = $"List<int> {name_per} = {"new List<int>\n{\n"}";
                    foreach (string item in text_all.Split(new char[] { '\n' }))
                    {
                        if (item.is_vlaid_string() == false)
                        {
                            string t = item.mul_replace(new List<string> { Properties.Resources.test, " " }, "");
                            if (t.Length >= 1)
                                ret_all += $"{ t.GetTextNumber() },\n";

                        }
                    }
                    ret_all += "};";
                    break;
                case "test":
                    break;
                default:

                    break;
            }


            ret_all = ret_all.mul_replace(new List<string> { Properties.Resources.test }, "");
            richTextBox1.SetText(ret_all);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            this.Title = String.Format("Hours: {0:00} Minutes: {1:00} Seconds: {2:00} Milliseconds: {3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }
        private void NAme_TextChanged(object sender, TextChangedEventArgs e)
        {
            name_per = (sender as TextBox).Text;
            Convert();
        }

        private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
