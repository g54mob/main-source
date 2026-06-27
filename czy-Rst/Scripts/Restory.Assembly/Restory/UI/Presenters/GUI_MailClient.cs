using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Data.PC;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.EmailSystems.NarrativeEmailButtons;
using Restory.UI.Presenters.PC.Apps;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_MailClient : GUI_PcAppBase
	{
		[SerializeField]
		private GUI_MailClientView view;

		[SerializeField]
		private GUI_MailClientFoldersPanel folders;

		[SerializeField]
		private GUI_MailClientEmailButtonsInFolderPanel messages;

		[SerializeField]
		private GUI_MailClientEmailContentsPanel selectedEmail;

		private EmailService emailService;

		private NarrativeEmailLettersButtonAvailabilityChecker narrativeEmailLettersButtonAvailabilityChecker;

		private readonly Dictionary<EmailFolders, List<IEmailLetterRecord>> emailsInFoldersDictionary = new Dictionary<EmailFolders, List<IEmailLetterRecord>>();

		[Inject]
		private void Construct(EmailService emailService, NarrativeEmailLettersButtonAvailabilityChecker narrativeEmailLettersButtonAvailabilityChecker)
		{
			this.emailService = emailService;
			this.narrativeEmailLettersButtonAvailabilityChecker = narrativeEmailLettersButtonAvailabilityChecker;
		}

		protected override void LaunchProcess(PcAppInfo appInfo)
		{
			base.LaunchProcess(appInfo);
			RefreshMessagesInFoldersList();
			emailService.OnLettersReadStatusChanged += ResolveLettersRead;
			UpdateUnreadMessagesInFolders();
			UpdateTakenOrdersFolderNumber();
			folders.SetInitialState();
			folders.Activate();
			ShowMessagesInSelectedFolder();
			ShowSelectedMessage();
			view.Show();
			folders.OnFolderSelectionChanged += ResolveFolderSelectionChanged;
			messages.OnEmailSelected += ResolveMessageSelectionChanged;
			selectedEmail.OnTakeOrderButtonClicked += ResolveTakeOrderRequested;
			selectedEmail.OnOkButtonClicked += ResolveMailOkButtonClicked;
			selectedEmail.OnYesButtonClicked += ResolveMailYesButtonClicked;
			selectedEmail.OnNoButtonClicked += ResolveMailNoButtonClicked;
			emailService.OnContentsChanged += ResolveChangesInEmailServiceDetected;
			selectedEmail.Init();
		}

		protected override void StopProcess()
		{
			folders.Deactivate();
			emailService.OnContentsChanged -= ResolveChangesInEmailServiceDetected;
			emailService.OnLettersReadStatusChanged -= ResolveLettersRead;
			folders.OnFolderSelectionChanged -= ResolveFolderSelectionChanged;
			messages.OnEmailSelected -= ResolveMessageSelectionChanged;
			selectedEmail.OnTakeOrderButtonClicked -= ResolveTakeOrderRequested;
			selectedEmail.OnOkButtonClicked -= ResolveMailOkButtonClicked;
			selectedEmail.OnYesButtonClicked -= ResolveMailYesButtonClicked;
			selectedEmail.OnNoButtonClicked -= ResolveMailNoButtonClicked;
			selectedEmail.Clear();
			view.Hide();
			base.StopProcess();
		}

		private void RefreshMessagesInFoldersList()
		{
			emailService.FillEmailsInFoldersDictionary(emailsInFoldersDictionary);
		}

		private void ShowMessagesInSelectedFolder()
		{
			messages.Clear();
			if (emailsInFoldersDictionary.TryGetValue(folders.CurrentlySelectedFolder, out var value))
			{
				messages.ShowMessagesList(value, emailService.WasMessageRead);
				messages.SetInitialState();
			}
			view.SwitchEmptyFolderNotificationVisibility(value == null || value.Count == 0);
		}

		private void RebuildMessagesInSelectedFolder()
		{
			messages.ClearMessagesList();
			if (emailsInFoldersDictionary.TryGetValue(folders.CurrentlySelectedFolder, out var value))
			{
				messages.ShowMessagesList(value, emailService.WasMessageRead);
				messages.TryToRestoreButtonSelection();
			}
			view.SwitchEmptyFolderNotificationVisibility(value == null || value.Count == 0);
		}

		private void ShowSelectedMessage()
		{
			IEmailLetterRecord currentlySelectedLetter = messages.CurrentlySelectedLetter;
			if (currentlySelectedLetter == null)
			{
				view.SwitchNoMessageSelectedNotificationVisibility(shouldShowNotification: true);
				selectedEmail.SetNoMessageSelectedState();
				return;
			}
			view.SwitchNoMessageSelectedNotificationVisibility(shouldShowNotification: false);
			emailService.TryToMarkEmailAsRead(currentlySelectedLetter);
			if (currentlySelectedLetter is EmailLetterOrderRecord emailLetterOrderRecord)
			{
				selectedEmail.SetUpOrderMessage(emailService.Settings.SubjectNameLocalizationKey, currentlySelectedLetter.SubjectLocalizationKey, currentlySelectedLetter.SenderContactInfo.NameLocalizationKey, currentlySelectedLetter.SenderContactInfo.EmailAddress, currentlySelectedLetter.BodyLocalizationKey, emailLetterOrderRecord.DeviceCondition.DeviceInfo.NameLocalizationKey, emailLetterOrderRecord.WorkTypes, emailLetterOrderRecord.Payment, GetOrderState(emailLetterOrderRecord));
			}
			else
			{
				selectedEmail.SetUpNonOrderMessage(emailService.Settings.SubjectNameLocalizationKey, currentlySelectedLetter.SubjectLocalizationKey, currentlySelectedLetter.SenderContactInfo.NameLocalizationKey, currentlySelectedLetter.SenderContactInfo.EmailAddress, currentlySelectedLetter.BodyLocalizationKey, GetNonOrderMessageButtonsState(currentlySelectedLetter, out var disabledButtonsExplanationLocalization), GetNonOrderMessageButtonsLocalisation(currentlySelectedLetter, disabledButtonsExplanationLocalization), (currentlySelectedLetter is EmailLetterNarrativeRecord emailLetterNarrativeRecord) ? emailLetterNarrativeRecord.Message.AttachedImage : null);
			}
		}

		private EmailOrderStates GetOrderState(EmailLetterOrderRecord emailOrder)
		{
			switch (emailService.GetFolderForEmailMessage(emailOrder))
			{
			case EmailFolders.None:
				return EmailOrderStates.None;
			case EmailFolders.OrdersInbox:
				return EmailOrderStates.CanBeTaken;
			case EmailFolders.OrdersTaken:
				if (!emailService.IsOrderAwaitingDeliveryFromClient(emailOrder))
				{
					return EmailOrderStates.TakenAndInWork;
				}
				return EmailOrderStates.TakenAndAwaitingDelivery;
			case EmailFolders.GeneralInbox:
			case EmailFolders.SpamInbox:
				return EmailOrderStates.None;
			case EmailFolders.RecycleBin:
				return EmailOrderStates.Completed;
			default:
				throw new NotImplementedException();
			}
		}

		private EmailButtonsStates GetNonOrderMessageButtonsState(IEmailLetterRecord selectedLetter, out EmailButtonsLocalisationKeys disabledButtonsExplanationLocalization)
		{
			if (!(selectedLetter is EmailLetterNarrativeRecord emailLetterNarrativeRecord))
			{
				disabledButtonsExplanationLocalization = default(EmailButtonsLocalisationKeys);
				return EmailButtonsStates.None;
			}
			switch (emailLetterNarrativeRecord.Message.EmailButtons)
			{
			case EmailButtonsOptions.None:
				disabledButtonsExplanationLocalization = default(EmailButtonsLocalisationKeys);
				return EmailButtonsStates.None;
			case EmailButtonsOptions.OkButton:
			{
				if (emailLetterNarrativeRecord.PressedButton == PressedEmailButtons.OkButton)
				{
					disabledButtonsExplanationLocalization = default(EmailButtonsLocalisationKeys);
					return EmailButtonsStates.OkButton_Pressed;
				}
				if (narrativeEmailLettersButtonAvailabilityChecker.ShouldButtonBeEnabled(emailLetterNarrativeRecord, PressedEmailButtons.OkButton, out var disabledButtonExplanationLocalizationKey3))
				{
					disabledButtonsExplanationLocalization = default(EmailButtonsLocalisationKeys);
					return EmailButtonsStates.OkButton_NotPressed;
				}
				disabledButtonsExplanationLocalization = new EmailButtonsLocalisationKeys
				{
					OkButtonLocalisationKey = disabledButtonExplanationLocalizationKey3
				};
				return EmailButtonsStates.OkButton_Disabled;
			}
			case EmailButtonsOptions.YesNoButtons:
			{
				EmailButtonsStates emailButtonsStates = emailLetterNarrativeRecord.PressedButton switch
				{
					PressedEmailButtons.YesButton => EmailButtonsStates.YesNoButtons_YesButtonPressed, 
					PressedEmailButtons.NoButton => EmailButtonsStates.YesNoButtons_NoButtonPressed, 
					_ => EmailButtonsStates.YesNoButtons_NotPressed, 
				};
				if (emailButtonsStates != EmailButtonsStates.YesNoButtons_NotPressed)
				{
					disabledButtonsExplanationLocalization = default(EmailButtonsLocalisationKeys);
					return emailButtonsStates;
				}
				string disabledButtonExplanationLocalizationKey;
				bool num = narrativeEmailLettersButtonAvailabilityChecker.ShouldButtonBeEnabled(emailLetterNarrativeRecord, PressedEmailButtons.YesButton, out disabledButtonExplanationLocalizationKey);
				string disabledButtonExplanationLocalizationKey2;
				bool flag = narrativeEmailLettersButtonAvailabilityChecker.ShouldButtonBeEnabled(emailLetterNarrativeRecord, PressedEmailButtons.NoButton, out disabledButtonExplanationLocalizationKey2);
				disabledButtonsExplanationLocalization = new EmailButtonsLocalisationKeys
				{
					YesButtonLocalisationKey = disabledButtonExplanationLocalizationKey,
					NoButtonLocalisationKey = disabledButtonExplanationLocalizationKey2
				};
				if (num)
				{
					if (!flag)
					{
						return EmailButtonsStates.YesNoButtons_NoButtonDisabled;
					}
					return EmailButtonsStates.YesNoButtons_NotPressed;
				}
				if (!flag)
				{
					return EmailButtonsStates.YesNoButtons_BothButtonsDisabled;
				}
				return EmailButtonsStates.YesNoButtons_YesButtonDisabled;
			}
			default:
				throw new NotImplementedException();
			}
		}

		private EmailButtonsLocalisationKeys GetNonOrderMessageButtonsLocalisation(IEmailLetterRecord selectedLetter, EmailButtonsLocalisationKeys disabledButtonsExplanationLocalizationKeys)
		{
			if (selectedLetter is EmailLetterNarrativeRecord emailLetterNarrativeRecord)
			{
				return new EmailButtonsLocalisationKeys
				{
					OkButtonLocalisationKey = (string.IsNullOrEmpty(disabledButtonsExplanationLocalizationKeys.OkButtonLocalisationKey) ? emailLetterNarrativeRecord.Message.OkButtonLocalizationKey : disabledButtonsExplanationLocalizationKeys.OkButtonLocalisationKey),
					YesButtonLocalisationKey = (string.IsNullOrEmpty(disabledButtonsExplanationLocalizationKeys.YesButtonLocalisationKey) ? emailLetterNarrativeRecord.Message.YesButtonLocalizationKey : disabledButtonsExplanationLocalizationKeys.YesButtonLocalisationKey),
					NoButtonLocalisationKey = (string.IsNullOrEmpty(disabledButtonsExplanationLocalizationKeys.NoButtonLocalisationKey) ? emailLetterNarrativeRecord.Message.NoButtonLocalizationKey : disabledButtonsExplanationLocalizationKeys.NoButtonLocalisationKey)
				};
			}
			return default(EmailButtonsLocalisationKeys);
		}

		private void ResolveFolderSelectionChanged()
		{
			ShowMessagesInSelectedFolder();
			ShowSelectedMessage();
		}

		private void ResolveMessageSelectionChanged()
		{
			ShowSelectedMessage();
		}

		private void ResolveLettersRead()
		{
			UpdateUnreadMessagesInFolders();
			messages.RefreshExistingMessagesButtons(emailService.WasMessageRead);
		}

		private void ResolveChangesInEmailServiceDetected()
		{
			RefreshMessagesInFoldersList();
			UpdateUnreadMessagesInFolders();
			UpdateTakenOrdersFolderNumber();
			RebuildMessagesInSelectedFolder();
			ShowSelectedMessage();
		}

		private void UpdateUnreadMessagesInFolders()
		{
			Dictionary<EmailFolders, int> value;
			using (CollectionPool<Dictionary<EmailFolders, int>, KeyValuePair<EmailFolders, int>>.Get(out value))
			{
				foreach (KeyValuePair<EmailFolders, List<IEmailLetterRecord>> item in emailsInFoldersDictionary)
				{
					int num = 0;
					foreach (IEmailLetterRecord item2 in item.Value)
					{
						if (!emailService.WasMessageRead(item2))
						{
							num++;
						}
					}
					value.Add(item.Key, num);
				}
				folders.UpdateUnreadMessagesInFolders(value);
			}
		}

		private void UpdateTakenOrdersFolderNumber()
		{
			folders.UpdateOrdersInProgressCountInTakenOrdersFolder(emailsInFoldersDictionary.TryGetValue(EmailFolders.OrdersTaken, out var value) ? value.Count : 0);
		}

		private void ResolveTakeOrderRequested()
		{
			if (messages.CurrentlySelectedLetter is EmailLetterOrderRecord orderToSend)
			{
				emailService.AcceptOrder(orderToSend);
			}
		}

		private void ResolveMailOkButtonClicked()
		{
			if (messages.CurrentlySelectedLetter is EmailLetterNarrativeRecord letterRecord)
			{
				emailService.MarkNarrativeLetterButtonAsPressed(letterRecord, PressedEmailButtons.OkButton);
			}
		}

		private void ResolveMailYesButtonClicked()
		{
			if (messages.CurrentlySelectedLetter is EmailLetterNarrativeRecord letterRecord)
			{
				emailService.MarkNarrativeLetterButtonAsPressed(letterRecord, PressedEmailButtons.YesButton);
			}
		}

		private void ResolveMailNoButtonClicked()
		{
			if (messages.CurrentlySelectedLetter is EmailLetterNarrativeRecord letterRecord)
			{
				emailService.MarkNarrativeLetterButtonAsPressed(letterRecord, PressedEmailButtons.NoButton);
			}
		}
	}
}
