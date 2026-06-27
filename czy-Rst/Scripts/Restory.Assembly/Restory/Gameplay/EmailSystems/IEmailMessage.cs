using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Data.NPCs;

namespace Restory.Gameplay.EmailSystems
{
	public interface IEmailMessage
	{
		string ID { get; }

		EmailContact Sender { get; }

		string SubjectLocalizationKey { get; }

		string BodyLocalizationKey { get; }

		EmailFolders FolderToSendMessageTo { get; }

		EmailButtonsOptions EmailButtons { get; }

		string OkButtonLocalizationKey { get; }

		string YesButtonLocalizationKey { get; }

		string NoButtonLocalizationKey { get; }

		IReadOnlyList<EmailButtonSettingsBase> OkButtonPressActions { get; }

		IReadOnlyList<EmailButtonSettingsBase> YesButtonPressActions { get; }

		IReadOnlyList<EmailButtonSettingsBase> NoButtonPressActions { get; }

		StoryNpcInfo NpcToVisitAfterEmailIsRead { get; }

		TimeSpan DelayBeforeVisit { get; }

		TimeSpan? DelayAfterVisit { get; }

		string NpcTextureID { get; }

		EmailMessageImageAttachmentInfo AttachedImage { get; }
	}
}
