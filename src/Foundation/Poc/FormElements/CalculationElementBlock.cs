using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using System;
using EPiServer.Forms.EditView;
using EPiServer.Forms.Implementation.Validation;
using EPiServer.Forms.EditView.DataAnnotations;
using Foundation.Poc.FormElements;
using Foundation.Poc.FormElements.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Foundation.Cms.Poc.FormElements.Test
{
    [ContentType(GUID = "{C71B1461-8985-428D-A63C-4BB683A833A8}",
        DisplayName = "Smartgroup Calculation",
        GroupName = ConstantsFormsUI.FormElementGroup,
        Order = 2230)]

    [AvailableValidatorTypes(Include = new Type[] { typeof(RequiredValidator) })]
    public class CalculationElementBlock : ElementBlockBase
    {
        private string AnnualTaxSavings;
        public string GetAnnualTaxSavings() {
            return AnnualTaxSavings;
        }
        private string AnnualGrossSalary;
        public string GetAnnualGrossSalary() 
        {
            return AnnualGrossSalary;
        }
        private string TakeHomePercentage;
        public string GetTakeHomePercentage() 
        {
            return TakeHomePercentage;
        }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
        }

        public void GetCalculationResultDomElements()
        {
            var benefits = SmartgroupFormHelper.Benefits;
            var annualGrossSalary = SmartgroupFormHelper.GetSalary;
            var employerCode = SmartgroupFormHelper.GetErCode;
            var employerType = "PUBLIC";

            var result = SmartgroupCalculatorHelper.DoCalculation(benefits, annualGrossSalary, employerCode, employerType);
            AnnualGrossSalary = result.AnnualGrossSalary.ToString();
            AnnualTaxSavings = result.AnnualTaxSavings.ToString();
            TakeHomePercentage = result.TakeHomePercentage.ToString();

            // EpiserverFomSubmissionHelper.Save(results);
            // this.SetValue("CustomProperty", new JavaScriptSerializer().Serialize(benefits));
            this.FormElement.Value = "Test Evan"; //new JavaScriptSerializer().Serialize(benefits);
        }
    }
}
