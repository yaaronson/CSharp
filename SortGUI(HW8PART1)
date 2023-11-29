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

        private static int[] numbers;
        private static int currentIndex;
        static System.Windows.Forms.Timer timer;

        Button btnSort;
        Button qs;
        Button rs;
        Button insertions;
        Button cs; 

        public CSorter()
        {
            InitializeComponent();
            InitializeNumbers();
            this.Size += new Size(200, 200);
            this.Paint += new PaintEventHandler(CSorter_Paint);

            btnSort = new Button();
            btnSort.Text = "Bubble Sort";
            btnSort.Location = new Point(100, 300);
            btnSort.Size = new Size(100, 50);
            btnSort.Click += new EventHandler(btnSortClick);
            this.Controls.Add(btnSort);

            qs = new Button();
            qs.Text = "Quick Sort";
            qs.Location = new Point(100, 350);
            qs.Size = new Size(100, 50);
            qs.Click += new EventHandler(btnSortClick);
            this.Controls.Add(qs);

            rs = new Button();
            rs.Text = "Radix Sort";
            rs.Location = new Point(100, 400);
            rs.Size = new Size(100, 50);
            rs.Click += new EventHandler(btnSortClick);
            this.Controls.Add(rs);

             insertions = new Button();
            insertions.Text = "Insertion Sort";
            insertions.Location = new Point(100, 450);
            insertions.Size = new Size(100, 50);
            insertions.Click += new EventHandler(btnSortClick);
            this.Controls.Add(insertions);

             cs = new Button();
            cs.Text = "Counting Sort";
            cs.Location = new Point(100, 500);
            cs.Size = new Size(100, 50);
            cs.Click += new EventHandler(btnSortClick);
            this.Controls.Add(cs);

            Button reset = new Button();
            reset.Text = "Reset";
            reset.Location = new Point(390, 300);
            reset.Size = new Size(100, 50);
            reset.Click += new EventHandler(resetSort);
            this.Controls.Add(reset);

        
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += new EventHandler(timerTick);
        }

        private void InitializeNumbers()
        {
            Random random = new Random();
            numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(10, 100); 
            }
            currentIndex = 0;
        }

        //bubble sort
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


       public  void Sort()
            {
                if (numbers == null || numbers.Length == 0)
                {
                    return;
                }
                QuickSortAlgorithm(numbers, 0, numbers.Length - 1);
            }

       private  void QuickSortAlgorithm(int[] numbers, int left, int right)
            {
                if (left >= right)
                {
                    return;
                }

                int pivot = Partition(numbers, left, right);
                QuickSortAlgorithm(numbers, left, pivot - 1);
                QuickSortAlgorithm(numbers, pivot + 1, right);
          
            timer.Stop();
        }

        private  int Partition(int[] numbers, int left, int right)
            {
                int pivot = numbers[right]; //  rightmost element as the pivot
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (numbers[j] < pivot)
                    {
                        i++;
                        Swap(numbers, i, j);
                        RefreshDisplay();
                       
                }
                }

                Swap(numbers, i + 1, right); // Placing the pivot element at its correct position
                RefreshDisplay();
           
            return i + 1;
            }

        private static void Swap(int[] numbers, int i, int j)
            {
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

        //radix sort

        public void RadixSort()
            {
                int max = GetMax(numbers);
                for (int exp = 1; max / exp > 0; exp *= 10)
                {
                    Count(numbers, exp);
                }
            }

           
       private int GetMax(int[] numbers)
            {
                int max = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                    }
                }
                return max;
            }

     
        private void Count(int[] numbers, int exp)
        {
            int n = numbers.Length;
            int[] output = new int[n];
            int[] count = new int[10]; // Count array 

            for (int i = 0; i < n; i++)
            {
                count[(numbers[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(numbers[i] / exp) % 10] - 1] = numbers[i];
                count[(numbers[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                numbers[i] = output[i];
            }

        }

        //insertion sort

        public void insertionSort()
        {
            int n = numbers.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = numbers[i];
                int j = i - 1;

                
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
                RefreshDisplay();
               
            }
            timer.Stop();
        }

        //counting Sort

        public void realCountingSort(int[] arr, int maxValue)
        {
            int[] count = new int[maxValue + 1];
            int[] output = new int[arr.Length];

           
            for (int i = 0; i <= maxValue; ++i)
            {
                count[i] = 0;
            }

            
            for (int i = 0; i < numbers.Length; ++i)
            {
                ++count[numbers[i]];
            }

 
            for (int i = 1; i <= maxValue; ++i)
            {
                count[i] += count[i - 1];
            }

            //  output array
            for (int i = numbers.Length - 1; i >= 0; --i)
            {
                output[count[numbers[i]] - 1] = numbers[i];
                --count[numbers[i]];
            }

            // Copy the sorted elements back to the original array
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = output[i];
                RefreshDisplay();
            }
            
        }


        private void RefreshDisplay()
        {
            this.Refresh();
            System.Threading.Thread.Sleep(100); 
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

        private void btnSortClick(object sender, EventArgs e)
        {

            if (sender == btnSort)
            {
                BubbleSortStep();
            }
            else if (sender == qs)
            {
                Sort();
            }else if (sender == rs) {

                RadixSort();
            }else if (sender == insertions)
            {
                insertionSort();
            }else if (sender == cs)
            {
                realCountingSort(numbers, numbers.Max());
            }

            timer.Start();

        }

        private void resetSort(object sender, EventArgs e)
        {
            InitializeNumbers();
            this.Refresh();
        }

        private void timerTick(object sender, EventArgs e)
        {
                BubbleSortStep();            
        }
    }
}
