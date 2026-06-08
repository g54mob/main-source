using System;
using System.Net;
using System.Net.Mail;

namespace AiUnity.NLog.Core.Internal
{
	internal class MySmtpClient : SmtpClient, ISmtpClient, IDisposable
	{
		string ISmtpClient.Host
		{
			get
			{
				return base.Host;
			}
			set
			{
				base.Host = value;
			}
		}

		int ISmtpClient.Port
		{
			get
			{
				return base.Port;
			}
			set
			{
				base.Port = value;
			}
		}

		int ISmtpClient.Timeout
		{
			get
			{
				return base.Timeout;
			}
			set
			{
				base.Timeout = value;
			}
		}

		ICredentialsByHost ISmtpClient.Credentials
		{
			get
			{
				return base.Credentials;
			}
			set
			{
				base.Credentials = value;
			}
		}

		bool ISmtpClient.EnableSsl
		{
			get
			{
				return base.EnableSsl;
			}
			set
			{
				base.EnableSsl = value;
			}
		}

		public new void Dispose()
		{
		}

		void ISmtpClient.Send(MailMessage msg)
		{
			Send(msg);
		}
	}
}
