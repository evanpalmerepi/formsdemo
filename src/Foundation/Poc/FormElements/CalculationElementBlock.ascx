<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" 
    CodeBehind="~/Poc/FormElements/CalculationElementBlock.ascx.cs"
    Inherits="ViewUserControl<Foundation.Cms.Poc.FormElements.Test.CalculationElementBlock>" %>
<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
    Model.GetCalculationResultDomElements();
%>

<div id="calc">
    <h3>Result</h3>
    <div>
        <label class="sgtitle">Annual Gross Salary: </label>
        <label class="result">$<%= Model.GetAnnualGrossSalary() %></label>
    </div>
    <div>
        <label class="sgtitle">Annual Tax Savings: </label>
        <label class="result">$<%= Model.GetAnnualTaxSavings() %></label>
    </div>
    <div>
        <label class="sgtitle">Take Home Percentage: </label>
        <label class="result"><%= Model.GetTakeHomePercentage() %>%</label>
    </div>
</div>