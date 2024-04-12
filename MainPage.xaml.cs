namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "";
        private double currentResult = 0;
        private char currentOperator;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentInput += button.Text;
            UpdateDisplay();
        }

       
        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentOperator = button.Text[0];
            currentResult = double.Parse(currentInput);
            currentInput = "";
            currentOperatorLabel.Text = button.Text;
        }

        // Method to handle equals button click
        private void OnEqualsClicked(object sender, EventArgs e)
        {
            double operand = double.Parse(currentInput);
            switch (currentOperator)
            {
                case '+':
                    currentResult += operand;
                    break;
                case '-':
                    currentResult -= operand;
                    break;
                case '*':
                    currentResult *= operand;
                    break;
                case '/':
                    currentResult /= operand;
                    break;
            }
            currentInput = currentResult.ToString();
            UpdateDisplay();
        }

        
        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = "";
            currentResult = 0;
            currentOperatorLabel.Text = "";

            UpdateDisplay();
        }

       
        private void OnBackspaceClicked(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                UpdateDisplay();
            }
        }

       
        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                currentInput += ".";
                UpdateDisplay();
            }
        }

        
        private void UpdateDisplay()
        {
            calcDisplay.Text = currentInput != "" ? currentInput : currentResult.ToString();
        }
    }

}
