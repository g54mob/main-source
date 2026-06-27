using System;
using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems
{
	[Serializable]
	public class EmailLetterRecord : IEmailLetterRecord
	{
		public EmailContact SenderContactInfo { get; set; }

		public DateTime ReceivedDateTime { get; set; } = DateTime.MaxValue;

		public DateTime ReadDateTime { get; set; } = DateTime.MaxValue;

		public string SubjectLocalizationKey { get; set; }

		public string BodyLocalizationKey
		{
			get
			{
				if (EmailComment != null)
				{
					return EmailComment.CommentLocalizationId;
				}
				return string.Empty;
			}
		}

		public EmailComment EmailComment { get; set; }
	}
}
