using System;
using System.Collections.Generic;
using Restory.Data.Base;
using Restory.Data.NPCs;
using Restory.Gameplay.EmailSystems;
using UnityEngine;

namespace Restory.Data.Email
{
	[CreateAssetMenu(menuName = "Restory/Email/NarrativeEmailMessage", fileName = "NarrativeEmailMessage - ")]
	public class EmailMessageInfo : RestoryEntityInfoBase, IEmailMessage
	{
		private static class Style
		{
			public const string ButtonsGroupName = "Buttons";

			public const string NpcVisitGroupName = "Npc Visit";

			public const string Resending = "Resending";
		}

		[SerializeField]
		private EmailContact sender;

		[SerializeField]
		private string subjectLocalizationKey;

		[SerializeField]
		private string bodyLocalizationKey;

		[SerializeField]
		private EmailMessageImageAttachmentInfo attachedImage;

		[SerializeField]
		private EmailFolders folderToSendMessageTo = EmailFolders.GeneralInbox;

		[SerializeField]
		private EmailResendOptions resendOption;

		[SerializeField]
		private int daysBeforeResendingLetter = 1;

		[SerializeField]
		private bool deletePreviousLetterWhenReceivedNew;

		[SerializeField]
		private EmailButtonsOptions emailButtons;

		[SerializeField]
		private string okButtonLocalizationKey;

		[SerializeField]
		private string yesButtonLocalizationKey;

		[SerializeField]
		private string noButtonLocalizationKey;

		[SerializeReference]
		private EmailButtonSettingsBase[] okButtonPressActions = new EmailButtonSettingsBase[0];

		[SerializeReference]
		private EmailButtonSettingsBase[] yesButtonPressActions;

		[SerializeReference]
		private EmailButtonSettingsBase[] noButtonPressActions;

		[SerializeField]
		private StoryNpcInfo npcToVisitAfterEmailIsRead;

		[SerializeField]
		private int delayBeforeVisitInGameMinutes;

		[SerializeField]
		private bool setMandatoryDelayAfterVisit;

		[SerializeField]
		private int delayAfterVisitInGameMinutes;

		[SerializeField]
		private string npcTextureID;

		public EmailContact Sender => sender;

		public string SubjectLocalizationKey => subjectLocalizationKey;

		public string BodyLocalizationKey => bodyLocalizationKey;

		public EmailFolders FolderToSendMessageTo => folderToSendMessageTo;

		public EmailButtonsOptions EmailButtons => emailButtons;

		public string OkButtonLocalizationKey => okButtonLocalizationKey;

		public string YesButtonLocalizationKey => yesButtonLocalizationKey;

		public string NoButtonLocalizationKey => noButtonLocalizationKey;

		public StoryNpcInfo NpcToVisitAfterEmailIsRead => npcToVisitAfterEmailIsRead;

		public TimeSpan DelayBeforeVisit => TimeSpan.FromMinutes(delayBeforeVisitInGameMinutes);

		public TimeSpan? DelayAfterVisit
		{
			get
			{
				if (!setMandatoryDelayAfterVisit)
				{
					return null;
				}
				return TimeSpan.FromMinutes(delayAfterVisitInGameMinutes);
			}
		}

		public string NpcTextureID => npcTextureID;

		public EmailResendOptions ResendOption => resendOption;

		public int DaysBeforeResendingLetter => daysBeforeResendingLetter;

		public bool DeletePreviousLetterWhenReceivedNew => deletePreviousLetterWhenReceivedNew;

		public IReadOnlyList<EmailButtonSettingsBase> OkButtonPressActions => okButtonPressActions;

		public IReadOnlyList<EmailButtonSettingsBase> YesButtonPressActions => yesButtonPressActions;

		public IReadOnlyList<EmailButtonSettingsBase> NoButtonPressActions => noButtonPressActions;

		public EmailMessageImageAttachmentInfo AttachedImage => attachedImage;
	}
}
