using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Foundation.Poc.FormElements.Models;

namespace Foundation.Poc.FormElements
{
    public class SmartgroupCalculatorHelper
    {
        public static CalculationResult DoCalculation(List<Benefit> benefits, int annualGrossSalary, string employerCode, string employerType)
        {
            var requestRoot = new RequestRoot() { 
                Benefits = benefits,
                AnnualGrossSalary = annualGrossSalary,
                EmployerCode = employerCode,
                EmployerType = employerType
            };

            var client = new RestClient("https://prodws.smartsalary.com.au/");
            var request = new RestRequest("v1/api/calculator", DataFormat.Json);
            request.AddJsonBody(new JavaScriptSerializer().Serialize(requestRoot));

            var response = client.Post(request);
            var data = new JavaScriptSerializer().Deserialize<CalculationResult>(response.Content);
            return data;
        }

        public static List<Benefit> GetBenefits(string erType)
        {
            var client = new RestClient("https://prodws.smartsalary.com.au/");
            var request = new RestRequest("v1/api/calculator/PUBLIC/benefits?erType=" + erType, DataFormat.Json);
            var response = client.Get(request);
            var root = new JavaScriptSerializer().Deserialize<List<Benefit>>(response.Content);
            return root;
        }
    }
}