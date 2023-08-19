using System.Text.RegularExpressions;
using Art.Models.Entities;
using MailKit.Net.Smtp;

class Methods
{
	

    public static string GenerateUrl(string Url)
	{
		string UrlPeplaceSpecialWords = Regex.Replace(Url, @"&quot;|['"",&?%\.!()@$^_+=*:#/\\-]", " ").Trim();
		string RemoveMutipleSpaces = Regex.Replace(UrlPeplaceSpecialWords, @"\s+", " ");
		string ReplaceDashes = RemoveMutipleSpaces.Replace(" ", "-");
		string seoUrl = ReplaceDashes.Replace("--", "-").ToLower();
		seoUrl = seoUrl.Replace("ş", "s");
		seoUrl = seoUrl.Replace("ı", "i");
		seoUrl = seoUrl.Replace("İ", "i");
		seoUrl = seoUrl.Replace("ç", "c");
		seoUrl = seoUrl.Replace("ğ", "g");
		seoUrl = seoUrl.Replace("ö", "o");
		seoUrl = seoUrl.Replace("ü", "u");	
		
		return seoUrl;
	}

	public static void sendEmail(MimeKit.MimeMessage message)
	{
		PmitLn2oqDb0001Context db = new PmitLn2oqDb0001Context()!;
		Smtp smtp = db.Smtps.First();

		using (var client = new SmtpClient())
		{
			client.Connect(smtp.Server, smtp.Port, smtp.Ssl);
			client.Authenticate(smtp.Email, smtp.Password);
			client.Send(message);
			client.Disconnect(true);
		}
	}
}