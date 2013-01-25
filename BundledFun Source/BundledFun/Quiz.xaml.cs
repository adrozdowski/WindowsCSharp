using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Resources;
using Coding4Fun.Phone.Controls;
using System.Windows.Threading;

namespace BundledFun
{
    public partial class Quiz
    {
        public static IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;
        readonly List<int> wyniki = new List<int>();

        private static int score; 
        private Question pytanieIMG = new Question();
        private Question pytanieTrailer = new Question();
        private Question pytanieSong = new Question();

        public const int IleTypow = 3;
        public const int IleMinutGry = 5;

        private DateTime _startTime;
        private DispatcherTimer _timer = new DispatcherTimer();

        private readonly SoundEffect _correctSound;
        private readonly SoundEffect _wrongSound;

        public Quiz()
        {
            InitializeComponent();

            if (MainPage.CanMusic)
                FrameworkDispatcher.Update();
            _startTime = DateTime.Now;
            _timer.Tick += TimerTick;
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Start();

            SetScore(false, true);
            if (MainPage.CanMusic)
                LoadSound("correct.wav", out _correctSound);
            if (MainPage.CanMusic)
                LoadSound("wrong.wav", out _wrongSound);

            DodajIMG();
            DodajSong();
            DodajTrailery();
            LosujPytania();
            WyswietlPytania();

            wyniki.Add(0);
            wyniki.Add(0);
            wyniki.Add(0);
            LoadSettings();
        }

        // Losuje po jednym pytaniu z kazdej kategorii i zapisuje do zmiennych
        private void LosujPytania()
        {
            Random r = new Random();
            pytanieIMG = WszystkieIMG[r.Next(WszystkieIMG.Count)];
            pytanieTrailer = WszystkieTrailer[r.Next(WszystkieTrailer.Count)];
            pytanieSong = WszystkieSong[r.Next(WszystkieSong.Count)];
        }

        // Wyswietla pytania i mozliwe odpowiedzi, ustawia zrodla grafiki ;)
        private void WyswietlPytania()
        {
            txtQuestion1.Text = pytanieIMG.Text;
            txtQuestion2.Text = pytanieTrailer.Text;
            txtQuestion3.Text = pytanieSong.Text;

            Answer_1x1.Content = pytanieIMG.A;
            Answer_1x2.Content = pytanieIMG.B;
            Answer_1x3.Content = pytanieIMG.C;

            Answer_2x1.Content = pytanieTrailer.A;
            Answer_2x2.Content = pytanieTrailer.B;
            Answer_2x3.Content = pytanieTrailer.C;

            Answer_3x1.Content = pytanieSong.A;
            Answer_3x2.Content = pytanieSong.B;
            Answer_3x3.Content = pytanieSong.C;

            img.Source = pytanieIMG.Image;
            if(MainPage.CanMusic)
                MTrailer.Source = new Uri("Trailers/" + pytanieTrailer.Trailer, UriKind.Relative);
            if (MainPage.CanMusic)
                MSong.Source = new Uri("Songs3/" + pytanieSong.Song, UriKind.Relative);
        }


        private void LoadSound(String SoundFilePath, out SoundEffect Sound)
        {
            Sound = null;

            if (!MainPage.CanMusic)
                return;
            try
            {
                StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));
                Sound = SoundEffect.FromStream(SoundFileInfo.Stream);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Couldn't load sound " + SoundFilePath);
            }
        }

        

        private void PivotSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Przy zmianie strony wylaczamy wszystko co sie da...
            if(MainPage.CanMusic)
                MTrailer.Stop();
            if (MainPage.CanMusic)
                MSong.Stop();

            // .. i jezeli....
            if (pivot.SelectedIndex == 0) // Images - wyswietlamy ta strone to...
            {
                //odtwarzamy to, co jest na tej stronie...
            }
                
            else if (pivot.SelectedIndex == 1)// Trailers
            {
                if(MainPage.CanMusic)
                    MTrailer.Play();
            }
            else if (pivot.SelectedIndex == 2)// Songs
            {
                if (MainPage.CanMusic)
                    MSong.Play();
            }
        }

 

        private void SetScore(bool isPlus = true, bool clear = false)
        {
            if (isPlus)
                score++;

            if (clear && !isPlus)
                score = 0;

            txtCorrect1.Text = "Score: " + score;
            txtCorrect2.Text = "Score: " + score;
            txtCorrect3.Text = "Score: " + score;
        }
        


        #region Obsluga odpowiedzi
        private void SprawdzOdpowiedzClick(object sender, RoutedEventArgs e)
        {
            SprawdzOdpowiedz(sender);
        }



        #endregion

        // Blokuje przyciski odpowiedzi dla konkretnego pytania
        private void BlokowanieOdpowiedzi(int q)
        {
            for(int i = 1; i <= IleTypow; i++)
            {
                Button b = LayoutRoot.FindName("Answer_" + q + "x" + i) as Button;
                b.IsEnabled = false;
            }
        }

        // Metoda blokuje/odblokowuje wszystkie (!) przyciski w quizie
        private void BlokowanieOdpowiedzi(bool odblokowacWszystko = true)
        {
            for (int i = 1; i <= IleTypow; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Button b = LayoutRoot.FindName("Answer_" + j + "x" + i) as Button;
                    b.IsEnabled = odblokowacWszystko;
                }
            }
        }
        
        private void SprawdzOdpowiedz(object sender)
        {
            Question q = new Question();
            string answer = (sender as Button).Content.ToString();
            var messagePrompt = new MessagePrompt();

            switch ((sender as Button).Name[7])
            {
                case '1' :
                    q = pytanieIMG; break;
                case '2' :
                    q = pytanieTrailer; break;
                case '3':
                    q = pytanieSong; break;
            }

            if(answer.Equals(q.Answer))
            {
                if (MainPage.CanMusic)
                    _correctSound.Play();
                SetScore();
                messagePrompt.Title = "Correct Answer";
            }
            else
            {
                if (MainPage.CanMusic)
                    _wrongSound.Play();

                messagePrompt.Title = "Wrong Answer";
                messagePrompt.Message = "The correct answer is: " + q.Answer;

            }
            messagePrompt.OnCompleted(new PopUpEventArgs<string, PopUpResult>
            {
                Result = messagePrompt.Value,
                PopUpResult = PopUpResult.Ok
            });

            BlokowanieOdpowiedzi(int.Parse((sender as Button).Name[7].ToString()));

            messagePrompt.Completed += MessagePromptCompleted;
            messagePrompt.Show();

        }

        void TimerTick(object sender, EventArgs e)
        {
            TimeSpan tNow = DateTime.Now - _startTime;
            string ttext = "Time left: ";

            if((59- tNow.Seconds) < 10)
                ttext += (IleMinutGry-1 - tNow.Minutes).ToString() + ":0" + (59 - tNow.Seconds);
            else
                ttext += (IleMinutGry-1 - tNow.Minutes).ToString() + ":" + (59 - tNow.Seconds);

            if(tNow.Minutes >= IleMinutGry)
                KoniecGry();


            txtTimer1.Text = ttext;
            txtTimer2.Text = ttext;
            txtTimer3.Text = ttext;
        }

        private void KoniecGry()
        {
            _timer.Stop();
            SprawdzWyniki(score);
            
            MessageBoxResult r = MessageBox.Show("Game over.\nYour score: " + score);
            if(r == MessageBoxResult.OK)
            {
                if(NavigationService.CanGoBack)
                    NavigationService.GoBack();
            }
        }

        private void SprawdzWyniki(int s)
        {
            //jezeli obecne punkty są wieksz niz pierwszy z listy...
            if(score >= wyniki[0])
            {
                wyniki[2]= wyniki[1];
                wyniki[1] = wyniki[0];
                wyniki[0] = score;
            }

            if((score >= wyniki[1]) && (score < wyniki[0]))
            {
                wyniki[2] = wyniki[1];
                wyniki[1] = score;
            }
            
            if((score >= wyniki[2]) && (score < wyniki[1]))
            {
                wyniki[2] = score;
            }
            
            SaveSettings(); 
        }


        // Zapętlenie odtwarzania
        private void MElementMediaEnded(object sender, RoutedEventArgs e)
        {
            if (!MainPage.CanMusic) return;
            (sender as MediaElement).Position = TimeSpan.Zero;
            (sender as MediaElement).Play();
        }


        void MessagePromptCompleted(object sender, PopUpEventArgs<String, PopUpResult> e)
        {
            //Nieladne, ale dziala...
            if (!Answer_1x1.IsEnabled && !Answer_2x1.IsEnabled && !Answer_3x1.IsEnabled)
            {
                MessageBoxResult r = MessageBox.Show("Do you want continue game?", "Continue?",
                                                     MessageBoxButton.OKCancel);
                if (r == MessageBoxResult.OK)
                {
                    LosujPytania();
                    WyswietlPytania();
                    BlokowanieOdpowiedzi();
                }
                else
                {
                    KoniecGry();
                }
            }

            pivot.SelectedIndex = (pivot.SelectedIndex + 1)%3;
        }



        // Zapisywanie Ustawień
        public bool SaveSettings()
        {
            try
            {
                if (AppSettings.Contains("Wyn1"))
                    AppSettings["Wyn1"] = wyniki[0].ToString();
                else
                    AppSettings.Add("Wyn1", wyniki[0].ToString());


                if (AppSettings.Contains("Wyn2"))
                    AppSettings["Wyn2"] = wyniki[1].ToString();
                else
                    AppSettings.Add("Wyn2", wyniki[1].ToString());


                if (AppSettings.Contains("Wyn3"))
                    AppSettings["Wyn3"] = wyniki[2].ToString();
                else
                    AppSettings.Add("Wyn3", wyniki[2].ToString());

                return true;
            }
            catch { return false; }
        }



        //Odczytywanie wyniko
        private void LoadSettings()
        {
            try
            {
                if (AppSettings.Contains("Wyn1"))
                {
                    string result = (string) AppSettings["Wyn1"];
                    wyniki[0] = int.Parse(result);
                }
                else
                    wyniki[0] = 0;

                if (AppSettings.Contains("Wyn2"))
                {
                    string result = (string) AppSettings["Wyn2"];
                    wyniki[1] = int.Parse(result);
                }
                else
                    wyniki[1] = 0;

                if (AppSettings.Contains("Wyn3"))
                {
                    string result = (string) AppSettings["Wyn3"];
                    wyniki[2] = 0;
                }
                else
                    wyniki[2] = 0;
            }
            catch { return;}
        }



    }
}