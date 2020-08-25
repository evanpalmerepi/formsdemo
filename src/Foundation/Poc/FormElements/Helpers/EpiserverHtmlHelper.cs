using Foundation.Poc.FormElements.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foundation.Poc.FormElements
{
    public class EpiserverHtmlHelper
    {
        public static string ConvertToHtml(CalculationResult benefits)
        {
            var elements = "";

            //foreach (var benefit in benefits)
            //{
            //    elements += "<div><label>" + benefit.Name + "<label><input name=\"Benefit_" + benefit.Id + "_" + benefit.TypeId + "\" /></div>";
            //}

            return elements;
        }

        public static string ConvertToHtml(List<Benefit> benefits)
        {
            var elements = "";

            foreach (var benefit in benefits)
            {
                elements += "<div class=\"benefit\"><label>" + benefit.Name + "</label><input placeholder=\"$\" " +
                                                                        "id=\"Benefit_" + benefit.Id + "_" + benefit.TypeId + "\" " +
                                                                        "name=\"Benefit_" + benefit.Id + "_" + benefit.TypeId + "\" /></div>";
            }

            return elements;
        }
    }
}