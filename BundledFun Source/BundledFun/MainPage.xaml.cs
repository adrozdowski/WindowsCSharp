using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Coding4Fun.Phone.Controls;
using System.Windows.Controls.Primitives;

namespace BundledFun
{
    public partial class MainPage
    {
        public static bool CanMusic = false;
        public MainPage()
        {
            InitializeComponent();
            MessageBoxResult r = MessageBox.Show("Do you want to play application sounds?", "Playing sounds",
                                                 MessageBoxButton.OKCancel);
            if (r == MessageBoxResult.OK)
                CanMusic = true;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new Uri("/Quiz.xaml", UriKind.Relative));
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutPrompt about = new AboutPrompt();
            about.Title = "About BundledFun";
            about.Footer = "drozd001@gmail.com\n";
            about.VersionNumber = "Version 1.0";
            about.Body = new TextBlock 
            {
                Text = "BundledFun is a fun quiz game for Windows Phone. \n\nIt supports Image, Text, Audio and Video types of questions.\n\n It is targeted for happy users :)", 
                TextWrapping = TextWrapping.Wrap 
            };
            about.Show();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            AboutPrompt howToPlay = new AboutPrompt();
            howToPlay.Title = "How to Play";
            howToPlay.Footer = "drozd001@gmail.com\n";
            howToPlay.VersionNumber = "Version 1.0";
            howToPlay.Body = new TextBlock
            {
                Text = "To earn points: just click on the right answer. :)\n\nTo navigate to other types of questions: Just simply swipe from left to right or from right to left.\n\nIf you want to quit: just click on the Windows Start Button",
                TextWrapping = TextWrapping.Wrap
            };
            howToPlay.Show();
        }

        private void BtnHighScoreClick1(object sender, RoutedEventArgs e)
        {
            AboutPrompt p = new AboutPrompt { Title = string.Empty, VersionNumber = string.Empty, Body = new HighScores() };
            p.Show();
        }
    }
}