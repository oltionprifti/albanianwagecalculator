using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbTaxSalaryCalc
{
    public class tax
    {
        public string grossSalary { get; set; }
        public string progressiveTax { get; set; }
        public string insuranceTax { get; set; }
        public string healthTax { get; set; }
        public string totalTax { get; set; }
        public string netSalary { get; set; }
        public string effectiveTaxRate { get; set; }


        public tax()
        {
            this.grossSalary = String.Empty;
            this.progressiveTax = String.Empty;
            this.insuranceTax = String.Empty;
            this.healthTax = String.Empty;
            this.totalTax = String.Empty;
            this.netSalary = String.Empty;
            this.effectiveTaxRate = String.Empty;
        }

        public void CalculatesalaryTax(string salaryinput)
        {
            double grossSalary = 0.0;
            double progressiveTax = 0.0;
            double insuranceTax = 0.0;
            double healthTax = 0.0;
            double totalTax = 0.0;
            double netSalary = 0.0;
            double effectiveTaxRate = 0.0;


            if (double.TryParse(salaryinput.Replace('L', ' '), out grossSalary))
                if (grossSalary <= 30000)
                {
                    progressiveTax = 0;
                    insuranceTax = (grossSalary * 9.5) / 100;
                    healthTax = (grossSalary * 1.7) / 100;
                    totalTax = progressiveTax + insuranceTax + healthTax;
                    netSalary = grossSalary - totalTax;
                    effectiveTaxRate = (totalTax / grossSalary);
                }
                else if (grossSalary <= 95130)
                {
                    progressiveTax = (13 * (grossSalary - 30000) / 100);
                    insuranceTax = (grossSalary * 9.5) / 100;
                    healthTax = (grossSalary * 1.7) / 100;
                    totalTax = progressiveTax + insuranceTax + healthTax;
                    netSalary = grossSalary - totalTax;
                    effectiveTaxRate = (totalTax / grossSalary);
                }

                else if (grossSalary <= 130000)
                {
                    progressiveTax = (13 * (grossSalary - 30000) / 100);
                    insuranceTax = 9037.35;
                    healthTax = (grossSalary * 1.7) / 100;
                    totalTax = progressiveTax + insuranceTax + healthTax;
                    netSalary = grossSalary - totalTax;
                    effectiveTaxRate = (totalTax / grossSalary);
                }

                else
                {
                    progressiveTax = ((23 * (grossSalary - 130000) / 100) + 13000);
                    insuranceTax = 9037.35;
                    healthTax = (grossSalary * 1.7) / 100;
                    totalTax = progressiveTax + insuranceTax + healthTax;
                    netSalary = grossSalary - totalTax;
                    effectiveTaxRate = (totalTax / grossSalary);
                }

           CultureInfo alb = CultureInfo.ReadOnly(new CultureInfo("sq-AL"));
           this.grossSalary = String.Format(alb, @"{0:C}", grossSalary);
            this.progressiveTax = String.Format(alb, @"{0:C}", progressiveTax);
            this.insuranceTax = String.Format(alb, @"{0:C}", insuranceTax);
            this.healthTax = String.Format(alb, @"{0:C}", healthTax);
            this.totalTax = String.Format(alb, @"{0:C}", totalTax);
            this.netSalary = String.Format(alb, @"{0:C}", netSalary);
            this.effectiveTaxRate = String.Format("{0:P}", effectiveTaxRate);

        }
    }
}
