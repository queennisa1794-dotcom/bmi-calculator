using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMRCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Calculate button click
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if any of the input fields are empty
            if (string.IsNullOrWhiteSpace(weightTextBox.Text) ||
                string.IsNullOrWhiteSpace(heightTextBox.Text) ||
                string.IsNullOrWhiteSpace(ageTextBox.Text))
            {
                resultTextBlock.Text = "Please fill in all the fields.";
                return;
            }

            // Try parsing input values as numbers
            if (!double.TryParse(weightTextBox.Text, out double weight) ||
                !double.TryParse(heightTextBox.Text, out double height) ||
                !int.TryParse(ageTextBox.Text, out int age))
            {
                resultTextBlock.Text = "Please enter valid numeric values.";
                return;
            }

            // Calculate BMR based on gender
            double bmr = 0;
            if (genderComboBox.SelectedIndex == 0) // Male
            {
                bmr = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else // Female
            {
                bmr = 10 * weight + 6.25 * height - 5 * age - 161;
            }

            // Display the calculated BMR
            resultTextBlock.Text = $"Your Basal Metabolic Rate (BMR) is: {bmr:F2} calories/day";
        }

        private void weightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}