using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonSendEmailLetterHandler : EmailButtonHandlerBase<EmailButtonSendEmailLetterSettings>
	{
		private const float MINUTES_IN_HOUR = 60f;

		private readonly EmailService emailService;

		public EmailButtonSendEmailLetterHandler(EmailService emailService)
		{
			this.emailService = emailService;
		}

		protected override void HandleButtonPress(EmailButtonSendEmailLetterSettings buttonSettings)
		{
			emailService.SendEmailMessageToPlayer(buttonSettings.LetterToSend, buttonSettings.InGameHoursBeforeSendingLetter * 60f, out var _);
		}
	}
}
