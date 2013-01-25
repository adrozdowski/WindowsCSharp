using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace BundledFun
{
    public partial class Quiz
    {
        public static List<Question> WszystkieIMG = new List<Question>();
        public static List<Question> WszystkieTrailer = new List<Question>();
        public static List<Question> WszystkieSong = new List<Question>();


        public void DodajIMG()
        {
            Question question = new Question();
            question.Image = new BitmapImage(new Uri("Images/adobe.png", UriKind.Relative));
            question.Text = "Is an American multinational computer software company founded in 1982 and headquartered in San Jose, California, United States.";
            question.A = "Gimp";
            question.B = "Adobe Systems";
            question.C = "Microsoft";
            question.Answer = "Adobe Systems";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/aclogo.png", UriKind.Relative));
            question.Text = "This is a sign of famous order which fights against Templars. This sign belongst to:";
            question.A = "Crusaders";
            question.B = "Assassins";
            question.C = "Green Lantern";
            question.Answer = "Assassins";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/BillGates.png", UriKind.Relative));
            question.Text = "The man in the picture is a founder of Microsoft. What is his name?";
            question.A = "Steve Jobs";
            question.B = "Kevin Mitnick";
            question.C = "Bill Gates";
            question.Answer = "Bill Gates";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/Konoha.png", UriKind.Relative));
            question.Text = "This symbol represents one of Great Nations in Naruto anime. Which one?";
            question.A = "Konohagakure - Hidden Leaf";
            question.B = "Sunagakure - Hidden Sand";
            question.C = "Iwagakure - Hidden Rock";
            question.Answer = "Konohagakure - Hidden Leaf";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/liberty.jpeg", UriKind.Relative));
            question.Text = "The Statue of Liberty is a gift from?:";
            question.A = "French";
            question.B = "Russians";
            question.C = "Italians";
            question.Answer = "French";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/pacyfka.jpg", UriKind.Relative));
            question.Text = "This sign was popular among Amercian hippie subculture during the war in Vietnam. What was this sign's meaning?";
            question.A = "Peace and war must exist together";
            question.B = "War is necessary";
            question.C = "Peace in the whole world";
            question.Answer = "Peace in the whole world";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/microsoft.jpg", UriKind.Relative));
            question.Text = "The name of 'Microsoft' comes from 2 words. Which ones?";
            question.A = "microbe and softball";
            question.B = "microcomputer and software";
            question.C = "micorvolt and softback";
            question.Answer = "microcomputer and software";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/fblogo.png", UriKind.Relative));
            question.Text = "Why did Mark Zuckerberg decide to drop 'the' from the name of his social network?";
            question.A = "He conducted a vote among students";
            question.B = "His investors ordered him to do it";
            question.C = "He listened to Sean Parker's advice";
            question.Answer = "He listened to Sean Parker's advice";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/superman.jpg", UriKind.Relative));
            question.Text = "The true name of superman is?";
            question.A = "Clark Kent";
            question.B = "Peter Parker";
            question.C = "Stanley Ipkiss";
            question.Answer = "Clark Kent";
            question.Timer = 30;
            WszystkieIMG.Add(question);

            question = new Question();
            question.Image = new BitmapImage(new Uri("Images/integral.jpg", UriKind.Relative));
            question.Text = "What is the name of a following mathematical symbol?";
            question.A = "plus";
            question.B = "integral";
            question.C = "derivative";
            question.Answer = "integral";
            question.Timer = 30;
            WszystkieIMG.Add(question);
        }

        private void DodajTrailery()
        {
            Question question = new Question();
            question.Trailer = "3idiots.wmv";
            question.Text = "Is a 2009 Indian comedy film directed by Rajkumar Hirani";
            question.A = "4 Idiots";
            question.B = "3 Idiots";
            question.C = "2 Idiots";
            question.Answer = "3 Idiots";
            question.Timer = 30;
            WszystkieTrailer.Add(question);

            question = new Question();
            question.Trailer = "skyfall.wmv";
            question.Text = "What is the name of new movie with James Bond?";
            question.A = "Casino Royal";
            question.B = "Quantum of Solace";
            question.C = "Skyfall";
            question.Answer = "Skyfall";
            question.Timer = 30;
            WszystkieTrailer.Add(question);

            question = new Question();
            question.Trailer = "avatar.wmv";
            question.Text = "What is the name of planet where an action takes place?";
            question.A = "Atena";
            question.B = "Pandora";
            question.C = "Helene";
            question.Answer = "Pandora";
            question.Timer = 30;
            WszystkieTrailer.Add(question);

            question = new Question();
            question.Trailer = "thrones.wmv";
            question.Text = "Who is an author and scenarist of 'Game of Thrones' ?";
            question.A = "J.K Rowling";
            question.B = "George R.R. Martin";
            question.C = "J.R.R Tolkien";
            question.Answer = "George R.R. Martin";
            question.Timer = 30;
            WszystkieTrailer.Add(question);

            question = new Question();
            question.Trailer = "rasen.wmv";
            question.Text = "What is the name of technique which uses Naruto from Naruto anime ?";
            question.A = "Chidori";
            question.B = "Futon: Rasen Shuriken";
            question.C = "Rasengan";
            question.Answer = "Futon: Rasen Shuriken";
            question.Timer = 30;
            WszystkieTrailer.Add(question);
        }

        private void DodajSong()
        {
            Question question = new Question
                                    {
                                        Song = "always.mp3",
                                        Text =
                                            "Is a power ballad by Bon Jovi. It was released as a single from their 1994 album, Cross Road and went on to become their best selling single, with 3 million copies sold in the U.S. and more than 10 million worldwide.",
                                        A = "Always",
                                        B = "Never Say Goodbye",
                                        C = "Edge of a Broken Heart",
                                        Answer = "Always",
                                        Timer = 60
                                    };
            WszystkieSong.Add(question);

            question = new Question
                           {
                               Song = "teach-me-how-to-dougie.mp3",
                               Text =
                                   "Teach me how to dougie is a song of American hip hop group named Cali Swag District. What is the name of a album which this song from?",
                               A = "Showtime",
                               B = "The Kickback",
                               C = "Runaways",
                               Answer = "The Kickback",
                               Timer = 60
                           };
            WszystkieSong.Add(question);

            question = new Question
                           {
                               Song = "what-ihave-done.mp3",
                               Text = "Which rock band is a perfomancer of 'What I have done?' ",
                               A = "Red Hot Chilli Peppers",
                               B = "Linkin Park",
                               C = "The Rasmus",
                               Answer = "Linkin Park",
                               Timer = 60
                           };
            WszystkieSong.Add(question);

            question = new Question
                           {
                               Song = "amy-slowitdown.mp3",
                               Text = "What nationality is Amy McDonald? ",
                               A = "American",
                               B = "Polish",
                               C = "Scottish",
                               Answer = "Scottish",
                               Timer = 60
                           };
            WszystkieSong.Add(question);

            question = new Question
                           {
                               Song = "woodkid-iron.mp3",
                               Text = "'Iron' by Woodkid is a trailer song. Which game?",
                               A = "Need For Speed Most Wanted",
                               B = "Assassins Creed Revelations",
                               C = "FIFA 13",
                               Answer = "Assassins Creed Revelations",
                               Timer = 60
                           };
            WszystkieSong.Add(question);

            question = new Question();
            question.Song = "naruto-1st.mp3";
            question.Text = "This song is an opening of Naruto Shippuuden anime. 'Heroes come back' is:";
            question.A = "First opening";
            question.B = "Second Opening";
            question.C = "Third opening";
            question.Answer = "First opening";
            question.Timer = 60;
            WszystkieSong.Add(question);

            question = new Question();
            question.Song = "gossip-direct.mp3";
            question.Text = "Who is a vocalist of Gossip band?:";
            question.A = "Brace Paine";
            question.B = "Hannah Bililie";
            question.C = "Beth Ditto";
            question.Answer = "Beth Ditto";
            question.Timer = 60;
            WszystkieSong.Add(question);

            question = new Question();
            question.Song = "she-wolf.mp3";
            question.Text = "Who, besides David Guetta, is a second perfomancer of 'She Wolf'";
            question.A = "Dhany";
            question.B = "Sia";
            question.C = "Ale Blake";
            question.Answer = "Sia";
            question.Timer = 60;
            WszystkieSong.Add(question);

            question = new Question();
            question.Song = "kravitz-fly.mp3";
            question.Text = "The perfomancer of this song is Lenny Kravitz. What is the name of this song?";
            question.A = "Go Away";
            question.B = "Fly Away";
            question.C = "No Way";
            question.Answer = "Fly Away";
            question.Timer = 60;
            WszystkieSong.Add(question);

            question = new Question();
            question.Song = "shadows.mp3";
            question.Text = "The perfomancer of this song is The Rasmus. What is the name of this song?";
            question.A = "Guilty";
            question.B = "Shot";
            question.C = "In the shadows";
            question.Answer = "In the shadows";
            question.Timer = 60;
            WszystkieSong.Add(question);
        }

    }
}
