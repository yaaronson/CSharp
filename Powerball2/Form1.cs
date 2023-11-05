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

        TextBox[] numInputBox = new TextBox[6];
        Label displayResult;

        private void InitializeUI()
        {
            this.Text = "Powerball Number Checker";
            this.Size = new System.Drawing.Size(650, 650);

            
            Label instructions = new Label();
            instructions.Text = "Enter Numbers:";
            instructions.Location = new System.Drawing.Point(20, 20);
            instructions.Size = new System.Drawing.Size(250, 30);
            this.Controls.Add(instructions);

            
            for (int i = 0; i < 6; i++)
            {
                TextBox InputBox = new TextBox();
                numInputBox[i] = InputBox;
                InputBox.Location = new System.Drawing.Point(20 + i * 100, 50);
                InputBox.Size = new System.Drawing.Size(80, 30); 
                this.Controls.Add(InputBox);
            }

            
            Button checkButton = new Button();
            checkButton.Text = "Check Numbers";
            checkButton.Location = new System.Drawing.Point(20, 90);
            checkButton.Size = new System.Drawing.Size(100, 30);
            checkButton.Click += new EventHandler(checkButton_Click);
            this.Controls.Add(checkButton);

            displayResult = new Label();
            displayResult.Size = new System.Drawing.Size(100, 300);
            displayResult.Text = "  ";
            displayResult.Location = new System.Drawing.Point(120, 120);
            this.Controls.Add(displayResult);
        }


        int[] match = new int[6];

        private void checkButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++) {


                if (numInputBox[i].Text == null)
                {
                    displayResult.Text = "Invalid Formatting, ReDo Please";
                    return;
                }

                if (numInputBox[i].Text.Length >= 2)
                {
                    displayResult.Text = "Only 1 digit per input box is allowed";
                    return;
                }

                if (!int.TryParse(numInputBox[i].Text, out _))
                {
                    displayResult.Text = "Invalid Formatting, ReDo Please";
                    return;
                }

            }
           

            Random numbers = new Random();

            for (int i = 0; i < 6; i++)
            {
                match[i] = numbers.Next() % 10;
            }

            if (CheckIfMatch(match) == true)
            {

                displayResult.Text = "Your Numbers are A Match!";

            }
            else
            {

                displayResult.Text = "Your Numbers Do NOT Match";

            }
        }

        private bool CheckIfMatch(int[] match)
        {

            for (int i = 0; i < 6; i++)
            {
                if (Int32.Parse(numInputBox[i].Text) == match[i])
                {

                }
                else { return false; }

            }

            return true;

        }
    }
}


