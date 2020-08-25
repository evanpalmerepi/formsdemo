<%--
    ====================================
    Version: 4.5.0.0. Modified: 20170321
    ====================================
--%>

<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" Inherits="ViewUserControl<TextareaElementBlock>" %>

<%  var formElement = Model.FormElement; 
    var labelText = Model.Label;
%>
<style>

    #employer_inputs label {
        display: inline-block;
        width: 250px;
        padding-left: 40px;
    }

    #employer_inputs input {
        display: inline-block;
        width: 200px;
    }

</style>

<% using(Html.BeginElement(Model, new { @class="form-group FormTextbox FormTextbox--Textarea" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="textarea" })) { %>
    <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
    <textarea name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" 
        placeholder="<%: Model.PlaceHolder %>" data-f-label="<%: labelText %>" data-f-datainput
        <%= Model.AttributesString %> ><%: Model.GetDefaultValue() %></textarea>
    <%= Html.ValidationMessageFor(Model) %>
<% } %>
