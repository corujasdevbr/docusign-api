using CorujasDev.DocuSign.Api.DocuSign;
using CorujasDev.DocuSign.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CorujasDev.DocuSign.Api.Controllers
{
    [Route("v1/docusigns")]
    [ApiController]
    public class DocuSignController : ControllerBase
    {
        public readonly DocuSignCredentials _docuSignCredentials;

        public DocuSignController(DocuSignKeys docuSignKeys)
        {
            _docuSignCredentials = new DocuSignCredentials(docuSignKeys.Email, docuSignKeys.Password, docuSignKeys.ApiKey);
        }

        [HttpPost]
        public IActionResult Post(UserModel user)
        {
            var emailTemplate = new DocuSignEmailTemplate($"Contrato Clt {user.Nome}", "É um prazer ter você em nosso time, vamos entrar com o pé direito, assine este documento e estamos ansiosos para sua chegada ao elenco");

            var docuSignTemplate = new DocuSignTemplate("863f5063-dbb3-4a15-94b1-5fd72094827f", new List<string> { "Test Email Recipient" });

            var docuSignEnvelope = new DocuSignEnvelopes(_docuSignCredentials, emailTemplate, docuSignTemplate);

            var result = docuSignEnvelope.Create(user.Nome, user.Email);

            return Ok(result);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var docuSignEnvelope = new DocuSignEnvelopes(_docuSignCredentials);

            var result = docuSignEnvelope.List();

            return Ok(result);
        }

        [HttpGet("{envelopeId}")]
        public IActionResult Get(string envelopeId)
        {
            var docuSignEnvelope = new DocuSignEnvelopes(_docuSignCredentials);

            var result = docuSignEnvelope.Get(envelopeId);

            return Ok(result);
        }

        [HttpGet("{envelopeId}/download")]
        public IActionResult Download(string envelopeId)
        {
            var docuSignEnvelope = new DocuSignEnvelopes(_docuSignCredentials);

            var stream = docuSignEnvelope.Download(envelopeId);

            return Ok();
        }
    }
}
