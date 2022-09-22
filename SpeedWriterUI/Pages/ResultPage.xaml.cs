using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SpeedWriterLib.Models;
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
    public sealed partial class ResultPage : Page
    {
        private uint _charPerMin;
        private double _accuracy;

        public uint CharPerMin
        {
            get => _charPerMin;
            set => _charPerMin = value;
        }

        public double Accuracy
        {
            get => _accuracy;
            set => _accuracy = value;
        }

        public ResultPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var userResult = (TypeTestResult)e.Parameter;
            CharPerMin = (uint)(userResult.TotalCharacters / 60);
            Accuracy = (double)userResult.TotalWord / userResult.CountMistakes;
        }
    }
}
