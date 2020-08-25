using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Forms.Core;
using System;
using EPiServer.Forms.EditView;
using EPiServer.Forms.Implementation.Validation;
using EPiServer.Forms.EditView.DataAnnotations;
using Foundation.Poc.FormElements;
using EPiServer.Editor;

namespace Foundation.Cms.Poc.FormElements.Test
{
    [ContentType(GUID = "{C71B1461-8985-428D-A63C-4BB683A833A7}",
        DisplayName = "Smartgroup Each Benefit",
        GroupName = ConstantsFormsUI.FormElementGroup,
        Order = 2231)]
    [AvailableValidatorTypes(Include = new Type[] { typeof(RequiredValidator) })]
    public class EachBenefitElementBlock : ElementBlockBase
    {
        public string GetBenefitDomElements()
        {
            var benefits = SmartgroupCalculatorHelper.GetBenefits(SmartgroupFormHelper.GetErCode);
            return EpiserverHtmlHelper.ConvertToHtml(benefits);
        }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
        }

        public bool GetInPageEditingMode()
        { 
            return PageEditing.PageIsInEditMode;
        }
    }
}
