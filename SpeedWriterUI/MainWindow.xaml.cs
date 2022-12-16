using Microsoft.UI.Xaml;
using SpeedWriterUI.Pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SpeedWriterUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
        }


        private void Guest_OnClick(object sender, RoutedEventArgs e)
        {
            Buttons.Visibility = Visibility.Collapsed;
            NextFrame.Navigate(typeof(TypeWritePage));
        }
    }
}
