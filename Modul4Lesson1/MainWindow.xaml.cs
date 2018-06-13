using Microsoft.Win32;
using Modul4Lesson1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Modul4Lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ((Run)FirstParagraph.Inlines.FirstInline).Text = "Change text";
            // ((Run)FirstParagraph.Inlines.LastInline).Text = "Change text";
            //  ((Run)FirstParagraph.Inlines.ToList()[1]).Text = "Change text";

            Paragraph pa = new Paragraph();
            pa.FontWeight = FontWeights.Bold;
            pa.Inlines.Add("ALFAR");
            ListItem li = new ListItem(pa);
            ListHistory.ListItems.Add(li);


            shop db = new shop();
            foreach (Category item in db.Category.ToList())
            {
                Run r = new Run();
                r.Text = item.Cat_Name;

                Paragraph pa1 = new Paragraph();
                pa1.Inlines.Add(r);
                ListItem li1 = new ListItem(pa1);
                ListHistory.ListItems.Add(li1);
            }



            Run r2 = new Run();
            r2.Text = "Latypov";

            Paragraph pa2 = new Paragraph();
            pa2.Inlines.Add(r2);
            ListItem li2 = new ListItem(pa2);
            ListHistory.ListItems.Add(li2);

        }

        private void LoadDoc_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                TextRange documTextRange 
                    = new TextRange(MyRichTextBox.Document.ContentStart, MyRichTextBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFile.FileName, FileMode.Open))
                {
                    documTextRange.Load(fs, DataFormats.Rtf);
                }
            }
        }

        private void SaveDoc_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if(saveFile.ShowDialog() == true)
            {
                TextRange documTextRange
                   = new TextRange( 
                       MyRichTextBox.Document.ContentStart, 
                       MyRichTextBox.Document.ContentEnd);

                using (FileStream fs = File.Create(saveFile.FileName))
                {
                    documTextRange.Save(fs, DataFormats.Rtf);
                }
            }
        }
    }
}
