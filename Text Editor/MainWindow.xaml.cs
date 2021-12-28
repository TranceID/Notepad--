using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TID_Library;
namespace Text_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Objects I should prob move
        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;
        Stream file;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            SetUpFileDialogs();
        }

        #region Menu Item Events
        // File items are done
        #region File Menu Item Events
        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(AskToSaveFile())
            {
                SaveFile();
                ClearRichTextBox();
                saveFileDialog.FileName = "";
            }     
        }

        private void NewWindow_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ClearRichTextBox();
            if (openFileDialog.ShowDialog() == true)
            {
                file = openFileDialog.OpenFile();
                richTextBox.AppendText(Read.ReadFile(file));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.FileName = "";
            SaveFile();
        }

        #region Print Events
        private void PageSetup_Click(object sender, RoutedEventArgs e)
        {
            // LATER, not needed
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            // LATER, not needed
        }
        #endregion
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (AskToSaveFile())
            {
                SaveFile();
            }
            this.Close();
        }
        #endregion
        // Edit mostly done aside from find box
        #region Edit Menu Item Events
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Undo();
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Copy();
        }

        private void InsertDate_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.AppendText(DateTime.Now.ToString().Split(' ')[0]);
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Paste();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            // Todo - figure out the find box

            // Open little box for user to type in what they want to find, then highlight all text they put in. Add checkbox for case senstive
            // Ad a drop down to this little box so they can replace with. Make this similar to c# find and replace

        }

        private void FindNext_Click(object sender, RoutedEventArgs e)
        {
            // Finds next occurence of the text they selected 
        }

        private void FindPrevious_Click(object sender, RoutedEventArgs e)
        {
            // Goes back to previous occurence
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            // Replaces text with whatever they put in
        }

        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            // idk yet
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.SelectAll();
        }

        #endregion
        // View Menu is kinda pointless
        #region View Menu Item Events
        private void WordWrap_Click(object sender, RoutedEventArgs e)
        {
            // Turns on word wrap. Probably not needed since this auto wraps
        }

        private void Font_Click(object sender, RoutedEventArgs e)
        {
            // Opens the settings box with the font area open
        }
        private void StatusBar_Click(object sender, RoutedEventArgs e)
        {
            // Turns off/on status bar which will contain lines, headers, view level, and whatever else you want
            if (fileStatusBar.IsEnabled)
            {
                fileStatusBar.Visibility = System.Windows.Visibility.Hidden; // Todo - Fix this
                                                                             //fileStatusBar.IsEnabled = false;
            }
            else
            {
                fileStatusBar.Visibility = System.Windows.Visibility.Visible;
                //fileStatusBar.IsEnabled = true;
            }
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            // I dont really need this so fuck all that. 
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            // Zooms out of file
        }

        private void DefaultZoom_Click(object sender, RoutedEventArgs e)
        {
            // Goes back to standard zoom
        }
        #endregion

        #region Settings Menu Item Events
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().Show();
        }
        private void MacrosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow(8).Show();
        }
        #endregion
        #endregion

        #region Other Events
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            StaticInformation.fileChanged = true;
            // could probably bind the name to file changed then append basic name.. might have to make a xaml lib for this and changing stuff based on certain things ..ie status bar being removed
            //Revert back to not changed if it goes back to empty from new file or previous saved context
        }
        #endregion

        // Todo - Separate out into lib classes Vv
        #region Methods for use in MainWindow
        private void OpenNewWindow() // Opens another window
        {
            new MainWindow().Show();
        }
        private bool AskToSaveFile()
        {
            return MessageBoxResult.Yes == MessageBox.Show(this, "Do you want to save your file?", "Save file?", MessageBoxButton.YesNo);
        }
        private void SaveFile() // Saves File using the path they've given with extension
        {
            if(saveFileDialog.FileName == String.Empty)
            {
                Write.SaveFile(saveFileDialog.FileName, GetRichTextBoxText());
            }
            else
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    SaveFile();
                }
            }
        }

        private void OpenFileDialog()
        {
            ClearRichTextBox(); 
            if (openFileDialog.ShowDialog() == true)
            {
                // Opens input file, assigns to global object, and puts in streamreader
                StreamReader inputFile = new StreamReader(file = openFileDialog.OpenFile());
                try
                {
                    // Reads through file and appends to textbox
                    while (!inputFile.EndOfStream)
                    {
                        richTextBox.AppendText(inputFile.ReadLine() + "\n");
                    }
                }
                catch { MessageBox.Show("Error opening file. It has to be a text file of some sort."); }
                inputFile.Close();
            }
        }
        #region Textbox Methods
        private string GetRichTextBoxText()
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }
        private void ClearRichTextBox()
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run("")));
        }

        #endregion
        #region Setup Dialogs
        private void SetUpFileDialogs()
        {
            // Sets up Save Dialog
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Open a file..";
            saveFileDialog.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";

            // Sets up Open Dialog
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open a file..";
            openFileDialog.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        #endregion
        #endregion

    }
}
