using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using HashesLibrary;
using Microsoft.Win32;

namespace HashChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void openDialogueBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                openFileDialogueTxt.Text = "";
                generatedHashTxt.Text = "";
                pastedInHashTxt.Text = "";
                openFileDialogueTxt.Text = open.FileName;
                
            }
        }

        private void GenerateHashFromFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var chosenComboItem = hashCombo.Text;
            string hashSwitch = chosenComboItem;
            string inputFromTextBox = openFileDialogueTxt.Text;
            HashesGenerator hashGen = new HashesGenerator();
            

            if (string.IsNullOrEmpty(chosenComboItem))
            {
                MessageBox.Show("Please pick a hash from the dropdown menu", "No hash selected", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                switch (hashSwitch)
                {
                    case "MD5":                        
                        generatedHashTxt.Text = hashGen.CreateMD5Hash(inputFromTextBox);
                        break;
                    case "SHA1":
                        generatedHashTxt.Text = hashGen.CreateSHA1Hash(inputFromTextBox);
                        break;
                    case "SHA256":
                        generatedHashTxt.Text = hashGen.CreateSHA256Hash(inputFromTextBox);
                        break;
                    case "SHA384":
                        generatedHashTxt.Text = hashGen.CreateSHA384Hash(inputFromTextBox);
                        break;
                    case "SHA512":
                        generatedHashTxt.Text = hashGen.CreateSHA512Hash(inputFromTextBox);
                        break;
                }
            }
        }

        private void CompareHashValues_Click(object sender, RoutedEventArgs e)
        {
            string textBoxPaste = pastedInHashTxt.Text;
            string textBoxGenHash = generatedHashTxt.Text;
            if (string.IsNullOrEmpty(textBoxPaste) || string.IsNullOrWhiteSpace(textBoxPaste))
            {
                MessageBox.Show("No hash string to compare with provided", "Missing compare hash string", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(textBoxGenHash)|| string.IsNullOrWhiteSpace(textBoxGenHash))
            {
                MessageBox.Show("No hash generated yet to compare with", "Missing compare hash string", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBoxGenHash == textBoxPaste)
                {
                    MatchFieldTxt.Text = "Hash strings match \u2713";
                }
                else
                {
                    MatchFieldTxt.Text = "Hash strings do not match \u2573";
                }
            }
        }
    }
}
