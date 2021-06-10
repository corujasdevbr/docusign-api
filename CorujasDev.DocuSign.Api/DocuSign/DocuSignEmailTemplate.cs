namespace CorujasDev.DocuSign.Api.DocuSign
{
    public class DocuSignEmailTemplate
    {
        public DocuSignEmailTemplate(string subject, string messageBody)
        {
            this.Subject = subject;
            this.MessageBody = messageBody;
        }

        public string Subject { get; set; }

        public string MessageBody { get; set; }
    }
}
