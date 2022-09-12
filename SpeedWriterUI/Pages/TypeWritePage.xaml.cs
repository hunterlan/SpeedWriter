using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SpeedWriterUI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TypeWritePage : Page
    {
        private List<string> PreparedWords = new();
        public string TextView;

        public TypeWritePage()
        {
            InitializeComponent();
            BlockText.Background = TypeWriter.Background;
            PrepareWords();
            TextView = string.Join(" ", PreparedWords);
        }

        private void PrepareWords()
        {
            var rand = new Random();
            var totalCount = App.WordHelper.Words.Count() - 1;

            while (PreparedWords.Count < 2000)
            {
                int index = rand.Next(0, totalCount);
                PreparedWords.Add(App.WordHelper.Words.ElementAt(index));
            }
        }
    }
}
