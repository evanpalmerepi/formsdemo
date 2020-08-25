using EPiServer.Find.Helpers.Text;
using Foundation.Poc.FormElements.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Foundation.Poc.FormElements
{
    public class SmartgroupFormHelper
    {
        public static string GetErCode
        {
            get
            {
                var erCode = "PUBLIC";

                var numberOfKeys = HttpContext.Current?.Request?.Form?.AllKeys?.Length;
                if (numberOfKeys.HasValue && numberOfKeys >= 6)
                {
                    var erCodeFromPost = HttpContext.Current?.Request?.Form?.Get(6);
                    if (erCodeFromPost != null)
                    {
                        erCode = erCodeFromPost;
                    }
                }

                return erCode;
            }
        }

        public static int GetSalary
        {
            get
            {
                int salary = 0;

                var numberOfKeys = HttpContext.Current?.Request?.Form?.AllKeys?.Length;
                if (numberOfKeys.HasValue && numberOfKeys >= 7)
                {
                    if (int.TryParse(HttpContext.Current?.Request?.Form?.Get(7), out int salaryFromPost))
                    {
                        salary = salaryFromPost;
                    }
                }

                return salary;
            }
        }

        internal static List<Benefit> Benefits
        {
            get 
            {
                var benefits = new List<Benefit>();
                var numberOfKeys = HttpContext.Current?.Request?.Form?.AllKeys?.Length;
                if (numberOfKeys.HasValue && numberOfKeys >= 0)
                {
                    foreach (var key in HttpContext.Current.Request.Form.AllKeys)
                    {
                        if (key.StartsWith("Benefit_"))
                        {
                            var value = HttpContext.Current?.Request?.Form.Get(key);
                            int annualCost = string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
                            var id = int.Parse(key.Split('_')[1]);
                            var typeId = int.Parse(key.Split('_')[2]);
                            if (annualCost > 0)
                            {
                                benefits.Add(new Benefit { Id = id, TypeId = typeId, AnnualCost = annualCost });
                            }
                        }
                    }
                }
                    
                return benefits;
            }
        }
    }
}