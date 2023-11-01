using System;
using System.Windows.Forms;

namespace Powerball2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }

        TextBox numInputBox;
        Label displayResult;

        private void InitializeUI()
        {
            this.Text = "Powerball Number Checker";
            this.Size = new System.Drawing.Size(600, 650);

            // Label
            Label instructions = new Label();
            instructions.Text = "Enter Numbers:";
            instructions.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(instructions);

            // Number Input Box
            numInputBox = new TextBox();
            numInputBox.Location = new System.Drawing.Point(20, 50);
            numInputBox.Size = new System.Drawing.Size(250, 30);
            this.Controls.Add(numInputBox);

            // Check Numbers Button
            Button checkButton = new Button();
            checkButton.Text = "Check Numbers";
            checkButton.Location = new System.Drawing.Point(20, 90);
            checkButton.Size = new System.Drawing.Size(100, 30);
            checkButton.Click += new EventHandler(checkButton_Click);
            this.Controls.Add(checkButton);

            displayResult = new Label();
            displayResult.Size = new System.Drawing.Size(100, 68);
            displayResult.Text = "  ";
            displayResult.Location = new System.Drawing.Point(120, 120);
            this.Controls.Add(displayResult);

        }

        int[] match = new int[6];

        private void checkButton_Click(object sender, EventArgs e)
        {

            String convertNum = numInputBox.Text;

            if (convertNum.Length != 6 || !int.TryParse(convertNum, out _))
            {
                displayResult.Text = "Invalid Formatting, ReDo Please";
                return;
            }

            Random numbers = new Random();

            for (int i = 0; i < 6; i++)
            {
                match[i] = numbers.Next() % 10;
            }

            if (CheckIfMatch(match) == true) {

                displayResult.Text = "Your Numbers are A Match!";

            }
            else {

                displayResult.Text = "Your Numbers Do NOT Match";
                    
             }
        } 

        private bool CheckIfMatch(int[] match) {

                String convertNum = numInputBox.Text;

                for (int i = 0; i < 6; i++)
                {
                    if (convertNum[i] == match[i])
                    {
                        
                    }else { return false; }

                }

                return true;

        }
    }
}
