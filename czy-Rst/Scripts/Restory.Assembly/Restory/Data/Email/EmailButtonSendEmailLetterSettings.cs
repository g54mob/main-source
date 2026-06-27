using System;

namespace Restory.Data.Email
{
	[Serializable]
	public class EmailButtonSendEmailLetterSettings : EmailButtonSettingsBase
	{
		public EmailMessageInfo LetterToSend;

		public float InGameHoursBeforeSendingLetter;
	}
}
