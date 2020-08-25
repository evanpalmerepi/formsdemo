using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Poc.FormElements.Models
{
    public class Car
    {
        public int Id { get; set; }
        public double VehicleValue { get; set; }
        public double AnnualRunningCostIncFinance { get; set; }
        public string LeaseTerm { get; set; }
    }

    public class Benefit
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        private string name;
        public string Name 
        {
            get { return name ?? string.Empty; }
            set { name = value; }
        }
        public double AnnualCost { get; set; }
    }

    public class RequestRoot
    {
        public string EmployerType { get; set; }
        public string EmployerCode { get; set; }
        public double AnnualGrossSalary { get; set; }
        public bool HasHECSDebt { get; set; }
        public bool IsNSWHealthEmployee { get; set; }
        public List<Car> Cars { get; set; }
        public List<Benefit> Benefits { get; set; }
    }
    // -----------------

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class WithSalaryPackaging
    {
        public double PreTaxDeductions { get; set; }
        public double TaxableIncome { get; set; }
        public double FBTPayable { get; set; }
        public double PAYGTax { get; set; }
        public double MedicareLevy { get; set; }
        public double ContributionTax { get; set; }
        public double TakeHomePay { get; set; }
        public double PostTaxDeductions { get; set; }
        public double HECSRepayment { get; set; }
        public double DisposableIncome { get; set; }
    }

    public class WithoutSalaryPackaging
    {
        public double PreTaxDeductions { get; set; }
        public double TaxableIncome { get; set; }
        public double FBTPayable { get; set; }
        public double PAYGTax { get; set; }
        public double MedicareLevy { get; set; }
        public double ContributionTax { get; set; }
        public double TakeHomePay { get; set; }
        public double PostTaxDeductions { get; set; }
        public double HECSRepayment { get; set; }
        public double DisposableIncome { get; set; }
    }

    public class CalculationResult
    {
        public double AnnualTaxSavings { get; set; }
        public double AnnualGrossSalary { get; set; }
        public double TakeHomePercentage { get; set; }
        public double EquivalentGrossSalary { get; set; }
        public bool HasSaveshare { get; set; }
        public double SaveshareContribution { get; set; }
        public WithSalaryPackaging WithSalaryPackaging { get; set; }
        public WithoutSalaryPackaging WithoutSalaryPackaging { get; set; }
    }

    public class ResponseRoot
    {
        public List<CalculationResult> MyArray { get; set; }
    }


}