using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Powerball2
{
    public partial class CSorter : Form
    {
        private int[] numbers;
        private int currentIndex;
        System.Windows.Forms.Timer timer;

        public CSorter()
        {
            InitializeComponent();
            InitializeNumbers();

            this.Paint += new PaintEventHandler(CSorter_Paint);


            
            Button btnSort = new Button();
            btnSort.Text = "Sort";
            btnSort.Location = new Point(100, 300);
            btnSort.Click += new EventHandler(btnSort_Click);
            this.Controls.Add(btnSort);

            Button reset = new Button();
            reset.Text = "Reset";
            reset.Location = new Point(300, 300); 
            reset.Click += new EventHandler(resetSort);
            this.Controls.Add(reset);

        
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void InitializeNumbers()
        {
            Random random = new Random();
            numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(10, 100); // Generates random numbers between 10 and 100
            }
            currentIndex = 0;
        }

        private void BubbleSortStep()
        {
            if (currentIndex < numbers.Length - 1)
            {
                if (numbers[currentIndex] > numbers[currentIndex + 1])
                {
                    int temp = numbers[currentIndex];
                    numbers[currentIndex] = numbers[currentIndex + 1];
                    numbers[currentIndex + 1] = temp;
                }
                currentIndex++;
                RefreshDisplay();
            }
            else
            {
                currentIndex = 0;
                RefreshDisplay();
                timer.Stop();
            }
        }

        private void RefreshDisplay()
        {
            this.Refresh();
            System.Threading.Thread.Sleep(100); // Adjust the delay for visualization speed
        }

        private void CSorter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int startX = 100;
            int startY = 200;
            int barWidth = 50;
            int barSpacing = 20;

            for (int i = 0; i < numbers.Length; i++)
            {
                int barHeight = numbers[i] * 2;
                g.FillRectangle(Brushes.Blue, startX + i * (barWidth + barSpacing), startY - barHeight, barWidth, barHeight);
                g.DrawString(numbers[i].ToString(), this.Font, Brushes.Black, startX + i * (barWidth + barSpacing), startY + 10);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void resetSort(object sender, EventArgs e)
        {
            InitializeNumbers();
            this.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BubbleSortStep();
        }
    }
}

