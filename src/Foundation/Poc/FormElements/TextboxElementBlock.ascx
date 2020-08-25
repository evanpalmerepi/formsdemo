<%--
    ====================================
    Version: 4.5.0.0. Modified: 20170321
    ====================================
--%>

<%@ import namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ control language="C#" inherits="ViewUserControl<TextboxElementBlock>" %>

<%
    var formElement = Model.FormElement; 
    var labelText = Model.Label;
%>

<style>

    #employer_inputs label {
        display: inline-block;
        width: 350px;
        font-size: 1.1rem;
    }

    #employer_inputs input {
        display: inline-block;
        width: 375px;
        font-size: 1.1rem;
    }

    #smartgroup_form .FormRange .Form__Element__Caption {
        font-size: 1.1rem;
        padding-right: 310px;
        width: 350px;
        display: inline-block;
    }

</style>

<div id="employer_inputs">
    <% using(Html.BeginElement(Model, new { @class="FormTextbox form-group" + Model.GetValidationCssClasses(), data_f_type="textbox" })) { %>
        <label for="<%: formElement.Guid %>"><%: labelText %></label>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" 
            placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%: Html.Raw(Model.AttributesString) %> data-f-datainput />

        <%= Html.ValidationMessageFor(Model) %>
        <%= Model.RenderDataList() %>
    <% } %>
</div>