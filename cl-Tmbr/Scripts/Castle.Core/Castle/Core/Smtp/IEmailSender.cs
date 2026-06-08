using System.Collections.Generic;
using System.Net.Mail;

namespace Castle.Core.Smtp
{
	public interface IEmailSender
	{
		void Send(string from, string to, string subject, string messageText);

		void Send(MailMessage message);

		void Send(IEnumerable<MailMessage> messages);
	}
}
