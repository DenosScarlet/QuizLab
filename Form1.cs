namespace QuizLab
{
    public partial class MainForm : Form
    {
        QuizClass quiz = new QuizClass();
        bool IsStarted = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PB.Visible = false;
            quiz._StartStopButton(this, StartStopButton_Click);
            quiz._TutorialButton(this, TutorialButton_Click);
        }
        private void QuizButton_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            quiz.AnswerChecker(bt, PB);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            quiz.StartStop();
            if (IsStarted == false)
            {
                PB.Visible = true;
                quiz.PictureLoad(PB);
                quiz.buttons(this, QuizButton_Click);
                IsStarted = true;
            }
            else
            {
                PB.Visible = false;
                //quiz.PictureLoad(PB);
                quiz.buttons(this, QuizButton_Click);
                quiz._TutorialButton(this, TutorialButton_Click);
                IsStarted = false;
            }
        }
        private void TutorialButton_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            if (IsStarted == false)
            {
                IsStarted = true;
                PB.Visible = true;
                quiz.Tutorial(this);
                quiz.PictureLoad(PB);
            }
            else
            {
                IsStarted = false;
                PB.Visible = false;

            }
            


        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}