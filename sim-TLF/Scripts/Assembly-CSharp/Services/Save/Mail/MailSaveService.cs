using System.Collections.Generic;
using Computer.Services;
using Cysharp.Threading.Tasks;
using Data;
using Data.Save;
using Loxodon.Framework.Binding;
using Mail;
using Michsky.DreamOS;
using Services.Missions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Services.Save.Mail
{
	public class MailSaveService : ISaveable, ILateDisposable, IInitializable
	{
		private readonly ISaveService _saveService;

		private readonly IMailService _mailService;

		private readonly MailManager _mailManager;

		private readonly IMissionService _missionService;

		private readonly DiContainer _diContainer;

		public string SaveKey => "MailService";

		public int Priority => 15;

		public MailSaveService(ISaveService saveService, IMailService mailService, MailManager mailManager, IMissionService missionService, DiContainer diContainer)
		{
			_saveService = saveService;
			_mailService = mailService;
			_mailManager = mailManager;
			_missionService = missionService;
			_diContainer = diContainer;
			_saveService.Register(this);
		}

		public void OnSave()
		{
			List<MailItemSaveData> list = new List<MailItemSaveData>();
			foreach (MailManager.MailAsset mail in _mailManager.mailList)
			{
				MailItem mailAsset = mail.mailAsset;
				if (!(mailAsset == null))
				{
					string key = mailAsset.subject + mailAsset.date;
					_mailService.CustomContentKeys.TryGetValue(key, out var value);
					_mailService.MissionIDs.TryGetValue(key, out var value2);
					list.Add(new MailItemSaveData
					{
						Title = mail.itemTitle,
						From = mailAsset.from,
						FromName = mailAsset.fromName,
						To = mailAsset.to,
						Subject = mailAsset.subject,
						MailContent = mailAsset.mailContent,
						Date = mailAsset.date,
						Time = mailAsset.time,
						MailFolder = mailAsset.mailFolder,
						CustomContentAddressable = value,
						MissionId = value2
					});
				}
			}
			_saveService.Write(SaveKey, new MailSaveData
			{
				Mails = list
			});
		}

		public async UniTask OnLoad()
		{
			Debug.Log("[MailSaveService] OnLoad started.");
			if (!_saveService.TryRead<MailSaveData>(SaveKey, out var data) || data.Mails == null)
			{
				Debug.Log("[MailSaveService] No save data found or Mails list is null. Skipping load.");
				return;
			}
			Debug.Log($"[MailSaveService] Found {data.Mails.Count} mail(s) to restore.");
			_mailManager.mailList.Clear();
			Debug.Log("[MailSaveService] mailList cleared.");
			for (int i = 0; i < data.Mails.Count; i++)
			{
				MailItemSaveData mailData = data.Mails[i];
				Debug.Log($"[MailSaveService] Processing mail [{i}]: Subject='{mailData.Subject}', From='{mailData.From}', Folder='{mailData.MailFolder}', CustomContentAddressable='{mailData.CustomContentAddressable}', MissionId='{mailData.MissionId}'");
				GameObject gameObject = null;
				if (!string.IsNullOrEmpty(mailData.CustomContentAddressable))
				{
					Debug.Log($"[MailSaveService] Mail [{i}]: Loading addressable prefab '{mailData.CustomContentAddressable}'...");
					GameObject gameObject2 = await Addressables.LoadAssetAsync<GameObject>(mailData.CustomContentAddressable);
					if (gameObject2 == null)
					{
						Debug.LogError($"[MailSaveService] Mail [{i}]: Addressables returned NULL for key '{mailData.CustomContentAddressable}'!");
					}
					else
					{
						Debug.Log($"[MailSaveService] Mail [{i}]: Addressable loaded OK — '{gameObject2.name}'. Instantiating...");
					}
					gameObject = ((gameObject2 != null) ? _diContainer.InstantiatePrefab(gameObject2) : null);
					if (gameObject == null)
					{
						Debug.LogError($"[MailSaveService] Mail [{i}]: Instantiate returned NULL for addressable '{mailData.CustomContentAddressable}'!");
					}
					else
					{
						Debug.Log($"[MailSaveService] Mail [{i}]: prefabInstance instantiated OK — '{gameObject.name}'.");
					}
				}
				else
				{
					Debug.Log($"[MailSaveService] Mail [{i}]: No CustomContentAddressable — prefabInstance stays null.");
				}
				MailObject mailObject = new MailObject
				{
					Title = mailData.Title,
					From = mailData.From,
					FromName = mailData.FromName,
					To = mailData.To,
					Subject = mailData.Subject,
					MailContent = mailData.MailContent,
					Date = mailData.Date,
					Time = mailData.Time,
					MailFolder = mailData.MailFolder,
					UseCustomContent = (gameObject != null),
					CustomContentPrefab = gameObject,
					CustomContentAddressableKey = mailData.CustomContentAddressable,
					MissionId = mailData.MissionId
				};
				Debug.Log(string.Format("[MailSaveService] Mail [{0}]: Calling SendMail. UseCustomContent={1}, CustomContentPrefab={2}", i, mailObject.UseCustomContent, (mailObject.CustomContentPrefab == null) ? "NULL" : mailObject.CustomContentPrefab.name));
				_mailService.SendMail(mailObject);
				Debug.Log($"[MailSaveService] Mail [{i}]: SendMail returned OK.");
				if (gameObject != null && !string.IsNullOrEmpty(mailData.MissionId))
				{
					Debug.Log($"[MailSaveService] Mail [{i}]: Setting up MailMissionContentView for MissionId='{mailData.MissionId}'.");
					MailMissionContentView component = gameObject.GetComponent<MailMissionContentView>();
					if (component == null)
					{
						Debug.LogError($"[MailSaveService] Mail [{i}]: MailMissionContentView component NOT found on '{gameObject.name}'!");
					}
					MissionDefinition missionDefinition = _missionService.Get(mailData.MissionId)?.Definition;
					if (missionDefinition == null)
					{
						Debug.LogError($"[MailSaveService] Mail [{i}]: MissionDefinition is NULL for MissionId='{mailData.MissionId}'!");
					}
					if (component != null && missionDefinition != null)
					{
						MailMissionContentViewModel dataContext = _diContainer.Instantiate<MailMissionContentViewModel>(new object[1] { missionDefinition });
						Debug.Log($"[MailSaveService] Mail [{i}]: ViewModel instantiated. Binding...");
						component.MissionId = missionDefinition.MissionId;
						component.SetDataContext(dataContext);
						component.CreateBinding();
						Debug.Log($"[MailSaveService] Mail [{i}]: Binding complete.");
					}
				}
			}
			Debug.Log("[MailSaveService] OnLoad finished.");
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}

		public void Initialize()
		{
			OnLoad().Forget();
		}
	}
}
