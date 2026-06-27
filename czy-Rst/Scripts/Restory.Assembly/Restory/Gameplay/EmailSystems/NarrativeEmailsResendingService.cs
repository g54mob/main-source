using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.EmailSystems
{
	public class NarrativeEmailsResendingService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, ITimeChangeReceiver
	{
		private GameCalendar gameCalendar;

		private EmailService emailService;

		private readonly List<RecurrentNarrativeEmailLetterData> recurrentEmails = new List<RecurrentNarrativeEmailLetterData>();

		[Inject]
		private void Construct(GameCalendar gameCalendar, EmailService emailService)
		{
			this.emailService = emailService;
			this.gameCalendar = gameCalendar;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)emailService && (bool)gameCalendar)
			{
				Init();
			}
		}

		private void Init()
		{
			emailService.OnNewEmailReceived += ResolveNewEmailReceived;
			emailService.OnNarrativeLetterButtonPressed += ResolveEmailButtonPressed;
			gameCalendar.AddSubscriber(this);
		}

		private void OnDisable()
		{
			if (emailService.MonoShellExists())
			{
				emailService.OnNewEmailReceived -= ResolveNewEmailReceived;
				emailService.OnNarrativeLetterButtonPressed -= ResolveEmailButtonPressed;
			}
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
		}

		public void ProcessTimeChanged()
		{
			for (int num = recurrentEmails.Count - 1; num >= 0; num--)
			{
				RecurrentNarrativeEmailLetterData recurrentNarrativeEmailLetterData = recurrentEmails[num];
				if (recurrentNarrativeEmailLetterData.ResendDateTime < gameCalendar.CurrentDateTime)
				{
					recurrentEmails.RemoveAt(num);
					emailService.SendEmailMessageToPlayer(recurrentNarrativeEmailLetterData.Message, 0f, out var _);
				}
			}
		}

		private void ResolveNewEmailReceived()
		{
			List<IEmailLetterRecord> value;
			using (CollectionPool<List<IEmailLetterRecord>, IEmailLetterRecord>.Get(out value))
			{
				emailService.FillAllReceivedEmailsList(value);
				foreach (IEmailLetterRecord item in value)
				{
					if (item is EmailLetterNarrativeRecord emailLetterNarrativeRecord && !IsNarrativeEmailAlreadyRegisteredAsRecurrent(emailLetterNarrativeRecord) && emailLetterNarrativeRecord.Message is EmailMessageInfo { ResendOption: EmailResendOptions.ResendAfterLetterIsReceived } emailMessageInfo)
					{
						recurrentEmails.Add(new RecurrentNarrativeEmailLetterData
						{
							Message = emailMessageInfo,
							ResendDateTime = gameCalendar.CurrentDateTime + TimeSpan.FromDays(emailMessageInfo.DaysBeforeResendingLetter)
						});
					}
				}
			}
		}

		private void ResolveEmailButtonPressed(EmailLetterNarrativeRecord letterWithPressedButton)
		{
			if (!IsNarrativeEmailAlreadyRegisteredAsRecurrent(letterWithPressedButton) && letterWithPressedButton.Message is EmailMessageInfo { ResendOption: EmailResendOptions.ResendAfterAnyButtonInLetterIsPressed } emailMessageInfo)
			{
				recurrentEmails.Add(new RecurrentNarrativeEmailLetterData
				{
					Message = emailMessageInfo,
					ResendDateTime = gameCalendar.CurrentDateTime + TimeSpan.FromDays(emailMessageInfo.DaysBeforeResendingLetter)
				});
			}
		}

		private bool IsNarrativeEmailAlreadyRegisteredAsRecurrent(EmailLetterNarrativeRecord letterToCheck)
		{
			foreach (RecurrentNarrativeEmailLetterData recurrentEmail in recurrentEmails)
			{
				if (letterToCheck.Message.ID == recurrentEmail.Message.ID)
				{
					return true;
				}
			}
			return false;
		}

		public object CaptureState()
		{
			try
			{
				return new NarrativeEmailsResendingServiceSaveData
				{
					RecurrentEmails = recurrentEmails.ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				NarrativeEmailsResendingServiceSaveData narrativeEmailsResendingServiceSaveData = DataMigrationWizard.Migrate<NarrativeEmailsResendingServiceSaveData>(state, base.gameObject);
				recurrentEmails.Clear();
				recurrentEmails.AddRange(narrativeEmailsResendingServiceSaveData.RecurrentEmails);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
