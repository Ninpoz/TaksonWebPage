using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

public class KontaktaOss : Controller
{
    private readonly IConfiguration _configuration;

    public KontaktaOss(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Send(string name, string email, string subject, string message)
    {
        try
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration["Smtp:Email"]); // Din e-postadress
            mailMessage.ReplyToList.Add(new MailAddress(email)); // Användarens e-post som reply-to
            mailMessage.To.Add("testbergman2@gmail.com"); // Din e-post som tar emot meddelandet
            mailMessage.Subject = subject;
            mailMessage.Body = $"Meddelande från: {name}\nE-post: {email}\n\n{message}";
            mailMessage.IsBodyHtml = false;

            var smtpClient = new SmtpClient(_configuration["Smtp:Server"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Email"], _configuration["Smtp:Password"]),
                EnableSsl = true,
            };

            smtpClient.Send(mailMessage);
            ViewBag.Message = "Ditt meddelande har skickats framgångsrikt!";
        }
        catch (Exception ex)
        {
            ViewBag.Message = $"Ett fel uppstod: {ex.Message}";
        }

        return View("Index");
    }
}
