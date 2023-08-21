using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace WebApplication3.Controllers
{
    public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ActionResult> EnviarEmail()
        {
            var apiKey = _configuration["AppSettings:SendGridApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("claudiarincon@uol.com.br", "Claudia");
            var to = new EmailAddress("clauzinhando@gmail.com", "Clauzinhando");
            var assunto = "Assunto do Email";
            var mensagem = "Conteúdo do Email";

            var msg = MailHelper.CreateSingleEmail(from, to, assunto, mensagem, mensagem);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine($"Enviado");
            return View();
        }
    }
}
