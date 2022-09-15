using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using SpeedWriterLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SpeedWriterUI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TypeWritePage : Page
    {
        private List<string> _preparedWords;
        private readonly TypeTestResult _typeTestResult = new();
        public string TextView;

        public TypeWritePage()
        {
            InitializeComponent();
            PrepareWords();
            TextView = string.Join(" ", _preparedWords);
        }

        private void PrepareWords()
        {
            _preparedWords = new List<string>();
            var rand = new Random();
            var totalCount = App.WordHelper.Words.Count() - 1;

            while (_preparedWords.Count < 2000)
            {
                int index = rand.Next(0, totalCount);
                _preparedWords.Add(App.WordHelper.Words.ElementAt(index));
            }
        }

        private void TypeWriter_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.OriginalKey == Windows.System.VirtualKey.Space)
            {
                _typeTestResult.TotalWord++;
                if (!TypeWriter.Text.Replace(" ", "").Equals(_preparedWords.First()))
                {
                    _typeTestResult.CountMistakes++;
                }

                _preparedWords.RemoveAt(0);
                TextView = string.Join(" ", _preparedWords);
                // TO-DO: Think about why bind doesn't update text.
                TextTest.Text = TextView;
                TypeWriter.Text = string.Empty;
            }
        }
    }
}
