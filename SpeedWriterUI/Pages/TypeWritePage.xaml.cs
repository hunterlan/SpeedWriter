using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using SpeedWriterLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Dispatching;
using System.ComponentModel;

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
        private static readonly uint SecondsForTest = 60;
        private readonly TypeTestResult _typeTestResult = new();
        private readonly DispatcherQueue _queue;
        private DispatcherQueueTimer _timer, _stopWatcher;
        private bool _isTimerStarted;

        public string TextView { get; set; }

        public uint SecondsLeft { get; set; }

        public TypeWritePage()
        {
            InitializeComponent();
            _queue = DispatcherQueue.GetForCurrentThread();
            InitializeTest();
        }

        private void InitializeTest()
        {
            _isTimerStarted = false;
            SecondsLeft = SecondsForTest;
            PrepareWords();
            TextView = string.Join(" ", _preparedWords);
            TextTest.Text = TextView;
            TimerCount.Text = "1:00";
            SetTimer();
        }

        private void SetTimer()
        {
            _timer = _queue.CreateTimer();
            _timer.Interval = new TimeSpan(0, 0, (int)SecondsForTest);
            _timer.IsRepeating = false;
            _timer.Tick += OnTimeout;

            _stopWatcher = _queue.CreateTimer();
            _stopWatcher.Interval = new TimeSpan(0, 0, 1);
            _stopWatcher.IsRepeating = true;
            _stopWatcher.Tick += UpdateTime;
        }

        private void UpdateTime(DispatcherQueueTimer sender, object args)
        {
            if (SecondsLeft > 0)
            {
                SecondsLeft--;
                TimerCount.Text = SecondsLeft.ToString();
            }
        }

        private void OnTimeout(DispatcherQueueTimer sender, object args)
        {
            _stopWatcher.Stop();
            throw new NotImplementedException();
        }

        private void PrepareWords()
        {
            _preparedWords = new List<string>();
            var rand = new Random();
            var totalCount = App.WordHelper.Words.Count() - 1;

            while (_preparedWords.Count < 2000)
            {
                var index = rand.Next(0, totalCount);
                _preparedWords.Add(App.WordHelper.Words.ElementAt(index));
            }
        }

        private void TypeWriter_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (!_isTimerStarted)
            {
                _timer.Start();
                _stopWatcher.Start();
                _isTimerStarted = true;
            }

            if (e.OriginalKey != Windows.System.VirtualKey.Space) return;
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

        private void Reset_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            _timer.Stop();
            _stopWatcher.Stop();
            InitializeTest();
        }
    }
}
