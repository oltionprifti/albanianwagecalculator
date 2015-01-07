using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace AlbTaxSalaryCalc
{
    public sealed partial class MainPage : Page
    {
        tax Tax;

        // Constructor
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Tax = new tax();

        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void amountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
           // salaryinput.Text = Tax.grossSalary;
        }

        
        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            salaryinput.Text = "";
            button_calculate.Content = "Calculate";
        }

        private void taxcalculation()
        {
            Tax.CalculatesalaryTax(salaryinput.Text);

            salaryinput.Text = Tax.grossSalary;
            progressiveTaxTextBlock.Text = Tax.progressiveTax;
            insuranceTaxTextBlock.Text = Tax.insuranceTax;
            healthTaxTextBlock.Text = Tax.healthTax;
            totaldeductionTextBlock.Text = Tax.totalTax;
            effectiveTaxRateTextBlock.Text = Tax.effectiveTaxRate;
            netSalaryTextBlock.Text = Tax.netSalary;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            taxcalculation();
            button_calculate.Content = "Restart";
        }

        

      

      
    }
}
