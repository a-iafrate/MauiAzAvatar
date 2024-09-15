namespace MauiAzAvatar
{
    public partial class MainPage : ContentPage
    {
        public static string Region = "westeurope";
        public static string Key = "xxxxxxxxxxxxxxxxxxxxxx";
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
#if ANDROID
        var androidWebview = webViewAvatar.Handler.PlatformView as Android.Webkit.WebView;
        //androidWebview.Settings.UseWideViewPort = true;
            androidWebview.Settings.MediaPlaybackRequiresUserGesture = false;
            //androidWebview.Settings.LoadWithOverviewMode = true;
#endif
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;


        }

        private void buttonSpeak_Clicked(object sender, EventArgs e)
        {
            webViewAvatar.EvaluateJavaScriptAsync($"speakMaui('{entrySentence.Text}');");
        }

        private void buttonStartSession_Clicked(object sender, EventArgs e)
        {
            webViewAvatar.EvaluateJavaScriptAsync($"startSessionMaui('{Region}','{Key}');");
        }

        private void buttonStopSpeaking_Clicked(object sender, EventArgs e)
        {
            webViewAvatar.EvaluateJavaScriptAsync($"stopSpeaking();");
        }

        private void buttonStopSession_Clicked(object sender, EventArgs e)
        {
            webViewAvatar.EvaluateJavaScriptAsync($"stopSession();");
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            //Stop session on close page
            webViewAvatar.EvaluateJavaScriptAsync($"stopSession();");
        }
    }
}
