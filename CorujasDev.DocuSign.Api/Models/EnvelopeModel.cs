using System;

namespace CorujasDev.DocuSign.Api.Models
{
    public class EnvelopeModel
    {
        public DateTime CompletedDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public String EmailSubject { get; set; }
        public Guid EnvelopeId { get; set; }
        public DateTime SentDateTime { get; set; }
        public string Status { get; set; }
    }
}
