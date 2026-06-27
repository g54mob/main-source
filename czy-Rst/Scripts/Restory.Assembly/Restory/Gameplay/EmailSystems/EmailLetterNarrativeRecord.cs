using System;
using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems
{
	[Serializable]
	public class EmailLetterNarrativeRecord : IEmailLetterRecord
	{
		public IEmailMessage Message;

		public PressedEmailButtons PressedButton;

		public EmailContact SenderContactInfo => Message.Sender;

		public DateTime ReceivedDateTime { get; set; } = DateTime.MaxValue;

		public DateTime ReadDateTime { get; set; } = DateTime.MaxValue;

		public string SubjectLocalizationKey => Message.SubjectLocalizationKey;

		public string BodyLocalizationKey => Message.BodyLocalizationKey;

		public EmailFolders InitialReceivingFolder => Message.FolderToSendMessageTo;
	}
}
