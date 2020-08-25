<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" 
    CodeBehind="~/Poc/FormElements/EachBenefitElementBlock.ascx.cs"
    Inherits="ViewUserControl<Foundation.Cms.Poc.FormElements.Test.EachBenefitElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
    var domElements = Model.GetBenefitDomElements();
%>

<div id="benefit_inputs">
    <div class="heading">Please enter the amount you would like to package to each benefit per year.</div>
    
    <div id="benefit_errors">
        <div class="benefits_error" id="benefit_error_numeric" style="display: none">
            All benefits must be numeric
        </div>
        <div class="benefits_error" id="benefit_error_low" style="display: none">
            All benefits must be greater than zero
        </div>
        <div class="benefits_error" id="benefit_error_high" style="display: none">
            All benefits must be less than 5000
        </div>
    </div>

    <div>
        <%= domElements %>
    </div>
</div>

<% if (!Model.GetInPageEditingMode())
    { %>
    <script type="text/javascript">

        window.onload = function () {
            $("form").submit(function (event) {
                var errors = {};

                $("#benefit_inputs input").each(function (index) {
                    console.log(index + ": " + $(this).val());
                    var benefitAmount = $(this).val();
                    if (benefitAmount === "") return;

                    if (!$.isNumeric(benefitAmount)) {
                        errors["numeric"] = true;
                        console.log(errors["numeric"]);
                    }
                    if (benefitAmount < 0) {
                        errors["low"] = true;
                        console.log(errors["low"]);
                    }
                    if (benefitAmount > 5000) {
                        errors["high"] = true;
                        console.log(errors["high"]);
                    }
                });

                if (errors["low"]) {
                    $("#benefit_error_low").css("display", "block");
                    event.preventDefault();
                } else {
                    $("#benefit_error_low").css("display", "none");
                }
                if (errors["high"]) {
                    $("#benefit_error_high").css("display", "block");
                    event.preventDefault();
                } else {
                    $("#benefit_error_high").css("display", "none");
                }
                if (errors["numeric"]) {
                    $("#benefit_error_numeric").css("display", "block");
                    event.preventDefault();
                } else {
                    $("#benefit_error_numeric").css("display", "none");
                }
            });
        };
    </script>

<% } %>
