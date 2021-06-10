using System.Collections.Generic;

namespace CorujasDev.DocuSign.Api.DocuSign
{
    public class DocuSignTemplate
    {
        public DocuSignTemplate(string templateId, IList<string> templateRoleNames)
        {
            this.TemplateId = templateId;
            this.TemplateRoleNames = templateRoleNames;
        }

        public IList<string> TemplateRoleNames { get; set; }

        public string TemplateId { get; set; }
    }
}
