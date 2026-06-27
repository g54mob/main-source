using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.TimeSystems;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.EmailSystems
{
	public class EmailService : MonoBehaviour, ITimeChangeReceiver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private const string EMAIL_LETTER_RECORD_ID_PREFIX = "EmailLetterRecord_";

		private const int TOTAL_SECONDS_IN_ONE_DAY = 86400;

		[SerializeField]
		private EmailSettings mainSettings;

		private EmailOrdersService emailOrdersService;

		private RandomDevicesGenerationService randomDevicesGenerator;

		private EmailNamesService emailNamesProvider;

		private EmailCommentsService emailCommentsService;

		private DevicePriceEstimationService devicePriceEstimationService;

		private GameCalendar gameCalendar;

		private CurrentDayVisitsQueueService npcVisitsService;

		private readonly List<EmailLetterRecordInFolder> upcomingEmails = new List<EmailLetterRecordInFolder>();

		private readonly List<EmailLetterRecordInFolder> receivedEmails = new List<EmailLetterRecordInFolder>();

		private DateTime lastMailCheckTime = DateTime.MinValue;

		private MainDayTimes lastTrackedTime;

		public EmailSettings Settings => mainSettings;

		public event Action OnNewEmailReceived;

		public event Action OnLettersReadStatusChanged;

		public event Action OnContentsChanged;

		public event Action<EmailLetterNarrativeRecord> OnNarrativeLetterButtonPressed;

		private void OnEnable()
		{
			if ((bool)gameCalendar)
			{
				Init();
			}
		}

		[Inject]
		private void Construct(GameCalendar gameCalendar, RandomDevicesGenerationService randomDevicesGenerator, EmailNamesService emailNamesProvider, EmailCommentsService emailCommentsService, EmailOrdersService emailOrdersService, DevicePriceEstimationService devicePriceEstimationService, CurrentDayVisitsQueueService npcVisitsService)
		{
			this.gameCalendar = gameCalendar;
			this.randomDevicesGenerator = randomDevicesGenerator;
			this.emailNamesProvider = emailNamesProvider;
			this.emailCommentsService = emailCommentsService;
			this.emailOrdersService = emailOrdersService;
			this.devicePriceEstimationService = devicePriceEstimationService;
			this.npcVisitsService = npcVisitsService;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void Init()
		{
			gameCalendar.AddSubscriber(this);
			emailOrdersService.OnOrdersDelivered += ResolveEmailOrdersDelivered;
			emailOrdersService.OnOrdersShipped += ResolveEmailOrdersShipped;
		}

		private void OnDisable()
		{
			if (gameCalendar.MonoShellExists())
			{
				gameCalendar.RemoveSubscriber(this);
			}
			if (emailOrdersService.MonoShellExists())
			{
				emailOrdersService.OnOrdersDelivered -= ResolveEmailOrdersDelivered;
				emailOrdersService.OnOrdersShipped -= ResolveEmailOrdersShipped;
			}
		}

		public void ProcessTimeChanged()
		{
			if (gameCalendar.CurrentDateTime - lastMailCheckTime < TimeSpan.FromMinutes(mainSettings.MailCheckingIntervalInGameMinutes))
			{
				return;
			}
			bool flag = false;
			for (int num = upcomingEmails.Count - 1; num >= 0; num--)
			{
				EmailLetterRecordInFolder emailLetterRecordInFolder = upcomingEmails[num];
				if (emailLetterRecordInFolder.Email.ReceivedDateTime < gameCalendar.CurrentDateTime)
				{
					upcomingEmails.RemoveAt(num);
					DeleteNarrativeEmailLettersIfNecessary(emailLetterRecordInFolder);
					receivedEmails.Add(new EmailLetterRecordInFolder
					{
						Email = emailLetterRecordInFolder.Email,
						Folder = emailLetterRecordInFolder.Folder
					});
					Debug.Log("Received e-mail from " + emailLetterRecordInFolder.Email.SenderContactInfo.EmailAddress);
					flag = true;
				}
			}
			lastMailCheckTime = gameCalendar.CurrentDateTime;
			if (flag)
			{
				this.OnNewEmailReceived?.Invoke();
				this.OnContentsChanged?.Invoke();
			}
		}

		public void SetCurrentTime(MainDayTimes currentTime)
		{
			MainDayTimes mainDayTimes = lastTrackedTime;
			if ((mainDayTimes == MainDayTimes.None || mainDayTimes == MainDayTimes.AfterWork || mainDayTimes == MainDayTimes.StoreClosedTime) && currentTime == MainDayTimes.Morning)
			{
				GenerateEmailsForTheDay();
			}
			lastTrackedTime = currentTime;
		}

		private void GenerateEmailsForTheDay()
		{
			if (lastTrackedTime == MainDayTimes.None)
			{
				GenerateInitialEmails();
			}
			int random = mainSettings.DailyOrdersRange.GetRandom();
			HashSet<DeviceInfo> value;
			using (CollectionPool<HashSet<DeviceInfo>, DeviceInfo>.Get(out value))
			{
				for (int i = 0; i < random; i++)
				{
					if (!randomDevicesGenerator.TryGetRandomDeviceConditionForEmailOrderFromAvailableDevices(value, out var generatedDeviceCondition, out var workTypesForDeviceCondition))
					{
						break;
					}
					value.Add(generatedDeviceCondition.DeviceInfo);
					DateTime receivedDateTime = ((i == 0) ? GetRandomEmailReceiveTimeForFirstMorningLetter() : GetRandomEmailReceiveTime());
					EmailContact randomEmailContact = emailNamesProvider.GetRandomEmailContact();
					emailCommentsService.TryToGetRandomEmailComment(out var emailComment);
					EmailLetterOrderRecord email = new EmailLetterOrderRecord
					{
						SenderContactInfo = randomEmailContact,
						ReceivedDateTime = receivedDateTime,
						DeviceCondition = generatedDeviceCondition,
						WorkTypes = workTypesForDeviceCondition,
						EmailComment = emailComment,
						SubjectLocalizationKey = mainSettings.OrderSubjectLocalizationKey,
						Payment = devicePriceEstimationService.EstimateEmailOrderPayment(generatedDeviceCondition, workTypesForDeviceCondition),
						NumberDaysToComplete = mainSettings.NumberDaysToComplete
					};
					upcomingEmails.Add(new EmailLetterRecordInFolder
					{
						Email = email,
						Folder = EmailFolders.OrdersInbox
					});
				}
			}
		}

		public IEnumerable<IEmailLetterRecord> GetEmailsInFolder(EmailFolders folder)
		{
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Folder == folder)
				{
					yield return receivedEmail.Email;
				}
			}
		}

		public void FillEmailsInFoldersDictionary(Dictionary<EmailFolders, List<IEmailLetterRecord>> dictionary)
		{
			dictionary.Clear();
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (dictionary.ContainsKey(receivedEmail.Folder))
				{
					dictionary[receivedEmail.Folder].Add(receivedEmail.Email);
					continue;
				}
				dictionary.Add(receivedEmail.Folder, new List<IEmailLetterRecord> { receivedEmail.Email });
			}
		}

		public void FillAllReceivedEmailsList(List<IEmailLetterRecord> emailsList)
		{
			emailsList.Clear();
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				emailsList.Add(receivedEmail.Email);
			}
		}

		public bool TryToMarkEmailAsRead(IEmailLetterRecord email)
		{
			if (email == null || email.ReadDateTime <= gameCalendar.CurrentDateTime)
			{
				return false;
			}
			email.ReadDateTime = gameCalendar.CurrentDateTime;
			if (email is EmailLetterNarrativeRecord emailLetterNarrativeRecord && (bool)emailLetterNarrativeRecord.Message.NpcToVisitAfterEmailIsRead)
			{
				npcVisitsService.AddNewImmediateVisit(emailLetterNarrativeRecord.Message.NpcToVisitAfterEmailIsRead, emailLetterNarrativeRecord.Message.DelayBeforeVisit, delayAfterVisit: emailLetterNarrativeRecord.Message.DelayAfterVisit, npcTextureId: emailLetterNarrativeRecord.Message.NpcTextureID);
			}
			this.OnLettersReadStatusChanged?.Invoke();
			return true;
		}

		public bool WasMessageRead(IEmailLetterRecord email)
		{
			if (email != null)
			{
				return email.ReadDateTime <= gameCalendar.CurrentDateTime;
			}
			return false;
		}

		private void GenerateInitialEmails()
		{
			HashSet<DeviceInfo> value;
			using (CollectionPool<HashSet<DeviceInfo>, DeviceInfo>.Get(out value))
			{
				for (int i = 0; i < mainSettings.InitialEmailOrdersCount; i++)
				{
					if (!randomDevicesGenerator.TryGetRandomDeviceConditionForEmailOrderFromAvailableDevices(value, out var generatedDeviceCondition, out var workTypesForDeviceCondition))
					{
						break;
					}
					value.Add(generatedDeviceCondition.DeviceInfo);
					Debug.Log("GenerateInitialEmails(" + generatedDeviceCondition.DeviceInfo.NameLocalizationKey + ")");
					DateTime receivedDateTime = gameCalendar.CurrentDateTime - TimeSpan.FromSeconds(UnityEngine.Random.Range(0, 86400));
					EmailContact randomEmailContact = emailNamesProvider.GetRandomEmailContact();
					emailCommentsService.TryToGetRandomEmailComment(out var emailComment);
					EmailLetterOrderRecord email = new EmailLetterOrderRecord
					{
						SenderContactInfo = randomEmailContact,
						ReceivedDateTime = receivedDateTime,
						DeviceCondition = generatedDeviceCondition,
						WorkTypes = workTypesForDeviceCondition,
						EmailComment = emailComment,
						SubjectLocalizationKey = mainSettings.OrderSubjectLocalizationKey,
						Payment = devicePriceEstimationService.EstimateEmailOrderPayment(generatedDeviceCondition, workTypesForDeviceCondition),
						NumberDaysToComplete = mainSettings.NumberDaysToComplete
					};
					upcomingEmails.Add(new EmailLetterRecordInFolder
					{
						Email = email,
						Folder = EmailFolders.OrdersInbox
					});
				}
			}
		}

		private void MoveEmailOrderToInProgressFolder(EmailLetterOrderRecord order)
		{
			MoveReceivedEmailToFolder(order, EmailFolders.OrdersTaken);
		}

		private void MoveEmailOrderToBinFolder(EmailLetterOrderRecord order)
		{
			MoveReceivedEmailToFolder(order, EmailFolders.RecycleBin);
		}

		public void SendEmailMessageToPlayer(IEmailMessage emailMessageInfo, float minutesBeforeSending, out EmailLetterNarrativeRecord letterRecord)
		{
			letterRecord = new EmailLetterNarrativeRecord
			{
				Message = emailMessageInfo,
				ReadDateTime = DateTime.MaxValue,
				ReceivedDateTime = gameCalendar.CurrentDateTime + TimeSpan.FromMinutes(minutesBeforeSending)
			};
			upcomingEmails.Add(new EmailLetterRecordInFolder
			{
				Email = letterRecord,
				Folder = emailMessageInfo.FolderToSendMessageTo
			});
		}

		public void MarkNarrativeLetterButtonAsPressed(EmailLetterNarrativeRecord letterRecord, PressedEmailButtons pressedButton)
		{
			bool flag = false;
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email is EmailLetterNarrativeRecord emailLetterNarrativeRecord && emailLetterNarrativeRecord == letterRecord && letterRecord.PressedButton == PressedEmailButtons.None)
				{
					letterRecord.PressedButton = pressedButton;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this.OnNarrativeLetterButtonPressed?.Invoke(letterRecord);
				this.OnContentsChanged?.Invoke();
			}
		}

		public bool TryGetNarrativeEmailLetterRecordByID(string narrativeEmailMessageID, out EmailLetterNarrativeRecord foundLetterRecord)
		{
			foreach (EmailLetterRecordInFolder upcomingEmail in upcomingEmails)
			{
				if (upcomingEmail.Email is EmailLetterNarrativeRecord emailLetterNarrativeRecord && emailLetterNarrativeRecord.Message.ID == narrativeEmailMessageID)
				{
					foundLetterRecord = emailLetterNarrativeRecord;
					return true;
				}
			}
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email is EmailLetterNarrativeRecord emailLetterNarrativeRecord2 && emailLetterNarrativeRecord2.Message.ID == narrativeEmailMessageID)
				{
					foundLetterRecord = emailLetterNarrativeRecord2;
					return true;
				}
			}
			foundLetterRecord = null;
			return false;
		}

		public void DeleteAllEmailsInBinFolder()
		{
			bool flag = false;
			for (int num = receivedEmails.Count - 1; num >= 0; num--)
			{
				EmailLetterRecordInFolder emailLetterRecordInFolder = receivedEmails[num];
				if (emailLetterRecordInFolder.Folder == EmailFolders.RecycleBin)
				{
					if (emailLetterRecordInFolder.Email is EmailLetterNarrativeRecord emailLetterNarrativeRecord && emailLetterNarrativeRecord.Message is EmailMessageInfo)
					{
						emailLetterRecordInFolder.Folder = EmailFolders.Hidden;
					}
					else
					{
						receivedEmails.RemoveAt(num);
					}
					flag = true;
				}
			}
			if (flag)
			{
				this.OnContentsChanged?.Invoke();
			}
		}

		public void AcceptOrder(EmailLetterOrderRecord orderToSend)
		{
			emailOrdersService.SendToDelivery(orderToSend);
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email == orderToSend)
				{
					MoveEmailOrderToInProgressFolder(orderToSend);
					break;
				}
			}
		}

		public EmailFolders GetFolderForEmailMessage(EmailLetterOrderRecord emailOrder)
		{
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email == emailOrder)
				{
					return receivedEmail.Folder;
				}
			}
			return EmailFolders.None;
		}

		public bool IsOrderAwaitingDeliveryFromClient(EmailLetterOrderRecord emailOrder)
		{
			return emailOrdersService.IsOrderAwaitingDeliveryFromClient(emailOrder);
		}

		public int GetTotalUnreadLettersCount()
		{
			int num = 0;
			DateTime currentDateTime = gameCalendar.CurrentDateTime;
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email.ReadDateTime > currentDateTime)
				{
					num++;
				}
			}
			return num;
		}

		public void Debug_ReceiveAllEmailsOfTheDayImmediately()
		{
			if (upcomingEmails.Count == 0)
			{
				return;
			}
			foreach (EmailLetterRecordInFolder upcomingEmail in upcomingEmails)
			{
				receivedEmails.Add(new EmailLetterRecordInFolder
				{
					Email = upcomingEmail.Email,
					Folder = upcomingEmail.Folder
				});
				Debug.Log("Received e-mail from " + upcomingEmail.Email.SenderContactInfo.EmailAddress);
			}
			upcomingEmails.Clear();
			this.OnNewEmailReceived?.Invoke();
			this.OnContentsChanged?.Invoke();
		}

		private void MoveReceivedEmailToFolder(EmailLetterOrderRecord email, EmailFolders targetFolder)
		{
			if (email == null)
			{
				return;
			}
			foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
			{
				if (receivedEmail.Email == email && receivedEmail.Folder != targetFolder)
				{
					receivedEmail.Folder = targetFolder;
					this.OnContentsChanged?.Invoke();
					break;
				}
			}
		}

		private DateTime GetRandomEmailReceiveTime()
		{
			int num = mainSettings.MailCheckingIntervalInGameMinutes * 60;
			int num2 = UnityEngine.Random.Range(0, 86400 - num);
			return gameCalendar.CurrentDateTime + TimeSpan.FromSeconds(num2);
		}

		private DateTime GetRandomEmailReceiveTimeForFirstMorningLetter()
		{
			int num = mainSettings.MailCheckingIntervalInGameMinutes * 60;
			int num2 = UnityEngine.Random.Range(-num, 0);
			return gameCalendar.CurrentDateTime + TimeSpan.FromSeconds(num2);
		}

		private void ResolveEmailOrdersDelivered()
		{
			this.OnContentsChanged?.Invoke();
		}

		private void ResolveEmailOrdersShipped()
		{
			foreach (EmailLetterOrderRecord lastTimeShippedOrder in emailOrdersService.LastTimeShippedOrders)
			{
				foreach (EmailLetterRecordInFolder receivedEmail in receivedEmails)
				{
					if (receivedEmail.Email == lastTimeShippedOrder)
					{
						MoveEmailOrderToBinFolder(lastTimeShippedOrder);
						break;
					}
				}
			}
		}

		private void DeleteNarrativeEmailLettersIfNecessary(EmailLetterRecordInFolder email)
		{
			if (!(email.Email is EmailLetterNarrativeRecord { Message: EmailMessageInfo { DeletePreviousLetterWhenReceivedNew: not false } message }))
			{
				return;
			}
			for (int num = receivedEmails.Count - 1; num >= 0; num--)
			{
				if (receivedEmails[num].Email is EmailLetterNarrativeRecord { Message: EmailMessageInfo message2 } && message2.ID == message.ID)
				{
					receivedEmails.RemoveAt(num);
				}
			}
		}

		public object CaptureState()
		{
			try
			{
				return new EmailServiceSaveData
				{
					UpcomingEmails = upcomingEmails.ToArray(),
					ReceivedEmails = receivedEmails.ToArray(),
					LastTrackedTime = lastTrackedTime
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
				EmailServiceSaveData emailServiceSaveData = DataMigrationWizard.Migrate<EmailServiceSaveData>(state, base.gameObject);
				upcomingEmails.Clear();
				receivedEmails.Clear();
				upcomingEmails.AddRange(emailServiceSaveData.UpcomingEmails);
				receivedEmails.AddRange(emailServiceSaveData.ReceivedEmails);
				lastTrackedTime = emailServiceSaveData.LastTrackedTime;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
