using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizLab
{
    internal class QuizClass
    {
        // Переменные
        Label cntr = new Label();
        bool IsStarted = false;
        bool PicturesAreLoaded = false;
        int i = new int();
        int Chances = 5;
        int CounterOfCorrectAnswers = 0;
        string CorrectAnswer = "";
        List<int> NumOfBts = new List<int>() { 0, 1, 2 };
        Button[] butts = new Button[3];
        Button TutorialButton= new Button();
        Button StartStopButton = new Button();
        static Random rnd = new Random();
        static Random rnd_bt = new Random();

        List<string> PhotoNames = new List<string>();
        string[] kekw = Directory.GetFiles("..\\..\\..\\Photos\\");

    public void PictureLoad(PictureBox pb) // Рандомная вставка картинок
        {
            if (IsStarted == true)
            {
                if (PicturesAreLoaded == false)
                {
                    foreach (var photoName in kekw)
                    {
                        PhotoNames.Add(Path.GetFileName(photoName));
                    }
                }

                PicturesAreLoaded = true;
                i = rnd.Next(0, PhotoNames.Count);
                pb.Image = Image.FromFile("..\\..\\..\\Photos\\" + PhotoNames[i]);
                CorrectAnswer = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4);
            }
        }
        public void buttons(System.Windows.Forms.Control parentControl, System.EventHandler QuizButton_Click) // Метод чтобы делать кнопки блин вот так
        {
            if (IsStarted == true)
            {
                NumOfBts = new List<int>() { 0, 1, 2 };
                Chances = 5;
                CounterOfCorrectAnswers = 0;
                for (int j = 0; j <= 2; j++)
                {
                    butts[j] = new System.Windows.Forms.Button();
                    butts[j].Location = new System.Drawing.Point(337, 142 + j * 75);
                    butts[j].BackColor = Color.White;
                    butts[j].Size = new System.Drawing.Size(233, 53);
                    butts[j].Click += new System.EventHandler(QuizButton_Click);
                    butts[j].Anchor = AnchorStyles.Top;
                    butts[j].Font = new Font("Gilroy Light", 16);
                    butts[j].Padding = new Padding(10);
                    butts[j].AutoSize = true;
                    butts[j].TabStop = false;
                    parentControl.Controls.Add(butts[j]);
                }
                int c = rnd.Next(0, NumOfBts.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Правильный ответ
                string CorrectAnswer = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4);
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

                c = rnd.Next(0, NumOfBts.Count);
                i = rnd_bt.Next(0, PhotoNames.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Фэк 1
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

                c = rnd.Next(0, NumOfBts.Count);
                i = rnd_bt.Next(0, PhotoNames.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Фэк 2
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

                cntr = new Label();
                cntr.Location = new System.Drawing.Point(550, 450);
                cntr.Text = "Осталось вопросов: " + Chances;
                cntr.Font = new Font("Gilroy Light", 16);
                cntr.AutoSize = true;
                parentControl.Controls.Add(cntr);
            }
            else
            {
                butts[0].Dispose();
                butts[1].Dispose();
                butts[2].Dispose();
                cntr.Dispose();
                PicturesAreLoaded = false;
                PhotoNames.Clear();
            }
        }

        public void AnswerChecker(Button bt, PictureBox pb) // Проверяет правильность ответа, вызывается при нажатии на кнопку с вариантом ответа
        {
            Chances--;
            if (bt.Text == CorrectAnswer)
            {
                CounterOfCorrectAnswers++;
            }
            cntr.Text = "Осталось вопросов: " + Chances;
            if (Chances > 0)
            {
                PictureLoad(pb);

                NumOfBts = new List<int>() { 0, 1, 2 };

                int c = rnd.Next(0, NumOfBts.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Правильный ответ
                CorrectAnswer = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4);
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

                c = rnd.Next(0, NumOfBts.Count);
                i = rnd_bt.Next(0, PhotoNames.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Фэк 1
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

                c = rnd.Next(0, NumOfBts.Count);
                i = rnd_bt.Next(0, PhotoNames.Count);
                butts[NumOfBts[c]].Text = PhotoNames[i].Substring(0, PhotoNames[i].Length - 4); // Фэк 2
                PhotoNames.RemoveAt(i);
                NumOfBts.RemoveAt(c);

            }
            else 
            { 
                if (CounterOfCorrectAnswers >= 5)
                {
                    MessageBox.Show("Вау! Да ты, видимо, про-игрок!\nНабрано 5 баллов из 5, поздравляю!");
                }
                else
                {
                    MessageBox.Show("Ты допустил ошибку.");
                }
            }
        }
        public void _TutorialButton(System.Windows.Forms.Control parentControl, System.EventHandler TutorialButton_Click) // Запускает обучение, вызывается при нажатии на кнопку начала обучения
        {
            TutorialButton = new System.Windows.Forms.Button();
            TutorialButton.Location = new System.Drawing.Point(420, 200);
            TutorialButton.BackColor = Color.White;
            TutorialButton.Size = new System.Drawing.Size(270, 100);
            TutorialButton.Click += new System.EventHandler(TutorialButton_Click);
            TutorialButton.Anchor = AnchorStyles.Top;
            TutorialButton.Font = new Font("Gilroy Light", 16);
            TutorialButton.Padding = new Padding(10);
            TutorialButton.AutoSize = true;
            TutorialButton.TabStop = false;
            TutorialButton.Text = "Пройти обучение";
            parentControl.Controls.Add(TutorialButton);
        }

        public void Tutorial(System.Windows.Forms.Control parentControl)
        {
            IsStarted = true;
        }
        public void _StartStopButton(System.Windows.Forms.Control parentControl, System.EventHandler StartStopButton_Click)
        {
            if (IsStarted == false)
            {
                StartStopButton = new System.Windows.Forms.Button();
                StartStopButton.Location = new System.Drawing.Point(130, 200);
                StartStopButton.BackColor = Color.White;
                StartStopButton.Size = new System.Drawing.Size(100, 100);
                StartStopButton.Click += new System.EventHandler(StartStopButton_Click);
                StartStopButton.Anchor = AnchorStyles.Top;
                StartStopButton.Font = new Font("Gilroy Light", 16);
                StartStopButton.Padding = new Padding(10);
                StartStopButton.AutoSize = true;
                StartStopButton.TabStop = false;
                StartStopButton.Text = "Начать тестирование";
                parentControl.Controls.Add(StartStopButton);
            }
            else
            {
                StartStopButton = new System.Windows.Forms.Button();
                StartStopButton.Location = new System.Drawing.Point(680, 60);
                StartStopButton.BackColor = Color.White;
                StartStopButton.Size = new System.Drawing.Size(70, 50);
                StartStopButton.Click += new System.EventHandler(StartStopButton_Click);
                StartStopButton.Anchor = AnchorStyles.Top;
                StartStopButton.Font = new Font("Gilroy Light", 16);
                StartStopButton.Padding = new Padding(10);
                StartStopButton.AutoSize = true;
                StartStopButton.TabStop = false;
                StartStopButton.Text = "Стоп";
                parentControl.Controls.Add(StartStopButton);
            }
        }
        public void StartStop()
        {
            if (IsStarted == false)
            {
                StartStopButton.Text = "Стоп";
                IsStarted = true;
                TutorialButton.Dispose();

                StartStopButton.Location = new System.Drawing.Point(680, 60);
                StartStopButton.Size = new System.Drawing.Size(70, 50);
            }
            else
            {
                StartStopButton.Location = new System.Drawing.Point(130, 200);
                StartStopButton.Size = new System.Drawing.Size(100, 100);
                StartStopButton.Text = "Начать тестирование";
                IsStarted = false; 
            }
        }
    }
}
