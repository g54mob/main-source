using System;
using Restory.Data.Email;

namespace Restory.Gameplay.EmailSystems
{
	public interface IEmailLetterRecord
	{
		EmailContact SenderContactInfo { get; }

		DateTime ReceivedDateTime { get; }

		DateTime ReadDateTime { get; set; }

		string SubjectLocalizationKey { get; }

		string BodyLocalizationKey { get; }
	}
}
