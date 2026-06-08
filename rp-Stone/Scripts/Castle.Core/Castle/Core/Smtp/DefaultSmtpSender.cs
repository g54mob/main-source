using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Permissions;
using Castle.Core.Internal;

namespace Castle.Core.Smtp
{
	public class DefaultSmtpSender : IEmailSender
	{
		private bool asyncSend;

		private readonly string hostname;

		private int port = 25;

		private int? timeout;

		private bool useSsl;

		private readonly NetworkCredential credentials = new NetworkCredential();

		public int Port
		{
			get
			{
				return port;
			}
			set
			{
				port = value;
			}
		}

		public string Hostname => hostname;

		public bool AsyncSend
		{
			get
			{
				return asyncSend;
			}
			set
			{
				asyncSend = value;
			}
		}

		public int Timeout
		{
			get
			{
				if (!timeout.HasValue)
				{
					return 0;
				}
				return timeout.Value;
			}
			set
			{
				timeout = value;
			}
		}

		public bool UseSsl
		{
			get
			{
				return useSsl;
			}
			set
			{
				useSsl = value;
			}
		}

		public string Domain
		{
			get
			{
				return credentials.Domain;
			}
			set
			{
				credentials.Domain = value;
			}
		}

		public string UserName
		{
			get
			{
				return credentials.UserName;
			}
			set
			{
				credentials.UserName = value;
			}
		}

		public string Password
		{
			get
			{
				return credentials.Password;
			}
			set
			{
				credentials.Password = value;
			}
		}

		private bool HasCredentials => !string.IsNullOrEmpty(credentials.UserName);

		public DefaultSmtpSender()
		{
		}

		public DefaultSmtpSender(string hostname)
		{
			this.hostname = hostname;
		}

		[SecuritySafeCritical]
		public void Send(string from, string to, string subject, string messageText)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to");
			}
			if (subject == null)
			{
				throw new ArgumentNullException("subject");
			}
			if (messageText == null)
			{
				throw new ArgumentNullException("messageText");
			}
			Send(new MailMessage(from, to, subject, messageText));
		}

		[SecuritySafeCritical]
		public void Send(MailMessage message)
		{
			InternalSend(message);
		}

		[SecurityCritical]
		private void InternalSend(MailMessage message)
		{
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			if (asyncSend)
			{
				SmtpClient smtpClient = CreateSmtpClient();
				Guid msgGuid = default(Guid);
				SendCompletedEventHandler sceh = null;
				sceh = delegate(object sender, AsyncCompletedEventArgs e)
				{
					if (msgGuid == (Guid)e.UserState)
					{
						message.Dispose();
					}
					smtpClient.SendCompleted -= sceh;
				};
				smtpClient.SendCompleted += sceh;
				smtpClient.SendAsync(message, msgGuid);
				return;
			}
			using (message)
			{
				CreateSmtpClient().Send(message);
			}
		}

		[SecuritySafeCritical]
		public void Send(IEnumerable<MailMessage> messages)
		{
			foreach (MailMessage message in messages)
			{
				Send(message);
			}
		}

		[SecurityCritical]
		protected virtual void Configure(SmtpClient smtpClient)
		{
			smtpClient.Credentials = null;
			if (CanAccessCredentials() && HasCredentials)
			{
				smtpClient.Credentials = credentials;
			}
			if (timeout.HasValue)
			{
				smtpClient.Timeout = timeout.Value;
			}
			if (useSsl)
			{
				smtpClient.EnableSsl = useSsl;
			}
		}

		[SecuritySafeCritical]
		private SmtpClient CreateSmtpClient()
		{
			if (string.IsNullOrEmpty(hostname))
			{
				return new SmtpClient();
			}
			SmtpClient smtpClient = new SmtpClient(hostname, port);
			Configure(smtpClient);
			return smtpClient;
		}

		private static bool CanAccessCredentials()
		{
			return new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).IsGranted();
		}
	}
}
