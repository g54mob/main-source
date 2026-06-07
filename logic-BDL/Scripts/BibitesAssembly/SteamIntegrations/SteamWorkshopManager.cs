using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace SteamIntegrations
{
	public class SteamWorkshopManager : MonoBehaviour
	{
		public static SteamWorkshopManager instance;

		private static bool callbacksLinked = false;

		public static string workshopSharingPath = "";

		[NonSerialized]
		public UnityEvent<WorkshopItem> onWorkshopItemCreated = new UnityEvent<WorkshopItem>();

		[NonSerialized]
		public UnityEvent<PublishedFileId_t> onWorkshopItemDestroyed = new UnityEvent<PublishedFileId_t>();

		[NonSerialized]
		public UnityEvent<EResult, WorkshopItem> onWorkshopItemSubmitResult = new UnityEvent<EResult, WorkshopItem>();

		[NonSerialized]
		public UnityEvent<WorkshopItem> onWorkshopItemUnSubscribed = new UnityEvent<WorkshopItem>();

		[NonSerialized]
		public UnityEvent<WorkshopItem> onWorkshopItemUpdated = new UnityEvent<WorkshopItem>();

		protected Callback<ItemInstalled_t> itemInstalled;

		protected Callback<DownloadItemResult_t> downloadItemResult;

		protected Callback<UserSubscribedItemsListChanged_t> userSubscribedItemsListChanged;

		protected Callback<PersonaStateChange_t> personaStateChange;

		private CallResult<CreateItemResult_t> createItemCallResult;

		private CallResult<SubmitItemUpdateResult_t> updateItemCallResult;

		private CallResult<SteamUGCQueryCompleted_t> itemDetailsQueryCompleted;

		private CallResult<DeleteItemResult_t> deleteItemCallResult;

		private CallResult<RemoteStorageUnsubscribePublishedFileResult_t> unsubscribeItemCallResult;

		private CallResult<WorkshopEULAStatus_t> workshopEULAStatusCallResult;

		private CallResult<SteamUGCRequestUGCDetailsResult_t> itemsDetailsCallResult;

		private Vector2 m_ScrollPos;

		private PublishedFileId_t testFileId;

		private WorkshopItem tempItem;

		public List<WorkshopItem> sharedItems = new List<WorkshopItem>();

		public List<WorkshopItem> subscribedItems = new List<WorkshopItem>();

		private List<WorkshopItem> allItems = new List<WorkshopItem>();

		public List<WorkshopItem> bibiteItems = new List<WorkshopItem>();

		public List<WorkshopItem> saveItems = new List<WorkshopItem>();

		public List<WorkshopItem> scenarioItems = new List<WorkshopItem>();

		[Header("Type Sprites")]
		[SerializeField]
		private Sprite bibiteIcon;

		[SerializeField]
		private Sprite saveIcon;

		[SerializeField]
		private Sprite scenarioIcon;

		[SerializeField]
		private Sprite challengeIcon;

		[NonSerialized]
		public Dictionary<PublishedFileId_t, string> sourceFiles = new Dictionary<PublishedFileId_t, string>();

		private List<ulong> userIdsToRequestInfo = new List<ulong>();

		private List<PublishedFileId_t> subscribedIDs = new List<PublishedFileId_t>();

		private bool testItemSubmitted;

		private string pathToItemToShare;

		private string sharedSourcesFilesPath => Path.Combine(workshopSharingPath, "sharedFiles.json");

		public static string tempImgPath => Path.Combine(workshopSharingPath, "tempImg.png");

		public Sprite GetSpriteOfType(WorkshopItemType type)
		{
			return type switch
			{
				WorkshopItemType.Bibite => bibiteIcon, 
				WorkshopItemType.Scenario => scenarioIcon, 
				WorkshopItemType.Challenge => challengeIcon, 
				WorkshopItemType.Save => saveIcon, 
				_ => null, 
			};
		}

		public string SourceFileOfItemRelative(PublishedFileId_t id)
		{
			return Path.Combine("~", sourceFiles[id]);
		}

		public string SourceFileOfItem(PublishedFileId_t id)
		{
			if (!sourceFiles.ContainsKey(id))
			{
				return pathToItemToShare;
			}
			return Path.Combine(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), sourceFiles[id]);
		}

		public bool ItemIsShared(string localPath)
		{
			return sourceFiles.Any((KeyValuePair<PublishedFileId_t, string> p) => p.Value.Contains($"{Path.DirectorySeparatorChar}{localPath}"));
		}

		public WorkshopItem GetSharedItem(string localPath)
		{
			return sharedItems.FirstOrDefault((WorkshopItem i) => i.id == sourceFiles.FirstOrDefault((KeyValuePair<PublishedFileId_t, string> p) => p.Value.Contains($"{Path.DirectorySeparatorChar}{localPath}")).Key);
		}

		public void InitializeWorkshop()
		{
			instance = this;
			workshopSharingPath = Path.Combine(Application.persistentDataPath, "Workshop", "Sharing");
			if (!Directory.Exists(workshopSharingPath))
			{
				Directory.CreateDirectory(workshopSharingPath);
			}
			if (!callbacksLinked)
			{
				OnEnable();
			}
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
			numSubscribedItems = SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			subscribedIDs = array.ToList();
			List<PublishedFileId_t> list = array.ToList();
			ReadSharedFiles();
			subscribedItems.Clear();
			bibiteItems.Clear();
			saveItems.Clear();
			scenarioItems.Clear();
			PublishedFileId_t[] array2 = array;
			foreach (PublishedFileId_t publishedFileId_t in array2)
			{
				ulong punSizeOnDisk;
				string pchFolder;
				uint punTimeStamp;
				bool itemInstallInfo = SteamUGC.GetItemInstallInfo(publishedFileId_t, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp);
				Debug.Log($"[{publishedFileId_t} - GetItemInstallInfo - {itemInstallInfo}] - {punSizeOnDisk} -- {pchFolder} -- {punTimeStamp}");
				if (!itemInstallInfo)
				{
					RequestDownloadItem(publishedFileId_t);
				}
				WorkshopItem workshopItem = new WorkshopItem(pchFolder);
				if (workshopItem.isValid)
				{
					subscribedItems.Add(workshopItem);
					if (workshopItem.type == WorkshopItemType.Bibite)
					{
						bibiteItems.Add(workshopItem);
					}
					else if (workshopItem.type == WorkshopItemType.Save)
					{
						saveItems.Add(workshopItem);
					}
					else
					{
						scenarioItems.Add(workshopItem);
					}
				}
			}
			sharedItems.Clear();
			string[] directories = Directory.GetDirectories(workshopSharingPath);
			for (int i = 0; i < directories.Length; i++)
			{
				WorkshopItem workshopItem2 = new WorkshopItem(directories[i]);
				if (workshopItem2.isValid && sourceFiles.ContainsKey(workshopItem2.id))
				{
					sharedItems.Add(workshopItem2);
					allItems.Add(workshopItem2);
					list.Add(workshopItem2.id);
					continue;
				}
				if (sourceFiles.ContainsKey(workshopItem2.id))
				{
					sourceFiles.Remove(workshopItem2.id);
					WriteSharedToFiles();
				}
				workshopItem2.Delete();
			}
			Debug.Log($"Subscribed items: {numSubscribedItems}\t\tShared Items: {sharedItems.Count}");
			RequestItemsDetail(list);
		}

		private void OnEnable()
		{
			if (!callbacksLinked)
			{
				itemInstalled = Callback<ItemInstalled_t>.Create(OnItemInstalled);
				downloadItemResult = Callback<DownloadItemResult_t>.Create(OnDownloadItemResult);
				userSubscribedItemsListChanged = Callback<UserSubscribedItemsListChanged_t>.Create(OnUserSubscribedItemsListChanged);
				personaStateChange = Callback<PersonaStateChange_t>.Create(OnUserInfoChange);
				createItemCallResult = CallResult<CreateItemResult_t>.Create(OnCreateItemResult);
				updateItemCallResult = CallResult<SubmitItemUpdateResult_t>.Create(OnSubmitItemUpdateResult);
				deleteItemCallResult = CallResult<DeleteItemResult_t>.Create(OnDeleteItemResult);
				unsubscribeItemCallResult = new CallResult<RemoteStorageUnsubscribePublishedFileResult_t>(OnUnsubscribeItemResult);
				itemDetailsQueryCompleted = CallResult<SteamUGCQueryCompleted_t>.Create(OnUGCQueryCompleted);
				workshopEULAStatusCallResult = CallResult<WorkshopEULAStatus_t>.Create(OnWorkshopEULAStatus);
				callbacksLinked = true;
			}
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift))
			{
				if (tempItem == null)
				{
					RequestCreateItem("C:\\Users\\LeoCaus\\AppData\\LocalLow\\The Bibites\\The Bibites\\Scenarios\\Apocalypse.zip");
				}
				else if (!testItemSubmitted)
				{
					tempItem.SetVisibility(ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityUnlisted);
					tempItem.SubmitItemUpdate();
					testItemSubmitted = true;
				}
			}
		}

		public void RequestCreateItem(string fromObjectPath)
		{
			pathToItemToShare = fromObjectPath;
			SteamAPICall_t steamAPICall_t = SteamUGC.CreateItem(SteamManager.AppID, EWorkshopFileType.k_EWorkshopFileTypeFirst);
			createItemCallResult.Set(steamAPICall_t);
			string[] obj = new string[6]
			{
				"SteamUGC.CreateItem(",
				SteamManager.AppID.ToString(),
				", ",
				EWorkshopFileType.k_EWorkshopFileTypeFirst.ToString(),
				") : ",
				null
			};
			SteamAPICall_t steamAPICall_t2 = steamAPICall_t;
			obj[5] = steamAPICall_t2.ToString();
			MonoBehaviour.print(string.Concat(obj));
		}

		public void SubmitItemUpdate(WorkshopItem item, string changeNote = "")
		{
			SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(item.itemUpdateHandle, changeNote);
			updateItemCallResult.Set(hAPICall);
		}

		public void RequestDownloadItem(PublishedFileId_t item)
		{
			bool flag = SteamUGC.DownloadItem(item, bHighPriority: true);
			string[] obj = new string[6] { "SteamUGC.DownloadItem(", null, null, null, null, null };
			PublishedFileId_t publishedFileId_t = item;
			obj[1] = publishedFileId_t.ToString();
			obj[2] = ", ";
			obj[3] = true.ToString();
			obj[4] = ") : ";
			obj[5] = flag.ToString();
			MonoBehaviour.print(string.Concat(obj));
		}

		public void RequestItemsDetail(IEnumerable<PublishedFileId_t> ids)
		{
			PublishedFileId_t[] array = ids.ToArray();
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(SteamUGC.CreateQueryUGCDetailsRequest(array, (uint)array.Length));
			itemDetailsQueryCompleted.Set(hAPICall);
		}

		public void RequestItemDetails(PublishedFileId_t id)
		{
			PublishedFileId_t[] obj = new PublishedFileId_t[1] { id };
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(SteamUGC.CreateQueryUGCDetailsRequest(obj, (uint)obj.Length));
			itemDetailsQueryCompleted.Set(hAPICall);
		}

		public bool CheckItemNeedUpdate(PublishedFileId_t item)
		{
			uint itemState = SteamUGC.GetItemState(item);
			if ((itemState & 4) != 0)
			{
				return (itemState & 8) != 0;
			}
			return false;
		}

		public void RequestDeleteItem(WorkshopItem item)
		{
			SteamAPICall_t hAPICall = SteamUGC.DeleteItem(item.id);
			deleteItemCallResult.Set(hAPICall);
		}

		public void RequestUnsubscribe(WorkshopItem item)
		{
			SteamAPICall_t hAPICall = SteamUGC.UnsubscribeItem(item.id);
			unsubscribeItemCallResult.Set(hAPICall);
		}

		public void OnUserInfoChange(PersonaStateChange_t pCallback)
		{
			Debug.Log($"[{304} - UserInfoChange] - {pCallback.m_ulSteamID} -- {pCallback.m_nChangeFlags}");
		}

		private void OnCreateItemResult(CreateItemResult_t pCallback, bool bIOFailure)
		{
			string[] obj = new string[8]
			{
				"[",
				3403.ToString(),
				" - CreateItemResult] - ",
				pCallback.m_eResult.ToString(),
				" -- ",
				null,
				null,
				null
			};
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[5] = nPublishedFileId.ToString();
			obj[6] = " -- ";
			obj[7] = pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement.ToString();
			Debug.Log(string.Concat(obj));
			testFileId = pCallback.m_nPublishedFileId;
			tempItem = new WorkshopItem(testFileId, pathToItemToShare);
			if (tempItem.isValid)
			{
				onWorkshopItemCreated.Invoke(tempItem);
				sourceFiles.Add(testFileId, pathToItemToShare.Replace(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), "").Remove(0, 1));
				WriteSharedToFiles();
			}
			else
			{
				tempItem.Delete();
				tempItem = null;
			}
		}

		private void OnUGCQueryCompleted(SteamUGCQueryCompleted_t pCallback, bool bIOFailure)
		{
			Debug.Log("[" + 3401 + " - SteamUGCQueryCompleted] - " + pCallback.m_eResult.ToString() + " -- returned: " + pCallback.m_unNumResultsReturned + " -- total: " + pCallback.m_unTotalMatchingResults);
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < pCallback.m_unNumResultsReturned; i++)
			{
				bool queryUGCResult = SteamUGC.GetQueryUGCResult(pCallback.m_handle, (uint)i, out var details);
				uint itemState = SteamUGC.GetItemState(details.m_nPublishedFileId);
				string[] obj = new string[14]
				{
					"[GetItemState(", null, null, null, null, null, null, null, null, null,
					null, null, null, null
				};
				PublishedFileId_t nPublishedFileId = details.m_nPublishedFileId;
				obj[1] = nPublishedFileId.ToString();
				obj[2] = ") -- ";
				obj[3] = details.m_eResult.ToString();
				obj[4] = " -- returned: ";
				obj[5] = itemState.ToString();
				obj[6] = "  --  ";
				obj[7] = (((itemState & 1) != 0) ? "Subscribed   " : "");
				obj[8] = (((itemState & 2) != 0) ? "Legacy   " : "");
				obj[9] = (((itemState & 4) != 0) ? "Installed   " : "");
				obj[10] = (((itemState & 8) != 0) ? "NeedsUpdate   " : "");
				obj[11] = (((itemState & 0x10) != 0) ? "Downloading   " : "");
				obj[12] = (((itemState & 0x20) != 0) ? "DownloadPending   " : "");
				obj[13] = (((itemState & 0x40) != 0) ? "DisabledLocally   " : "");
				Debug.Log(string.Concat(obj));
				if (details.m_eResult == EResult.k_EResultFileNotFound)
				{
					WorkshopItem workshopItem = sharedItems.FirstOrDefault((WorkshopItem t) => t.id == details.m_nPublishedFileId);
					if (workshopItem != null)
					{
						sourceFiles.Remove(workshopItem.id);
						WriteSharedToFiles();
						sharedItems.Remove(workshopItem);
						allItems.Remove(workshopItem);
						onWorkshopItemDestroyed.Invoke(workshopItem.id);
						workshopItem.Delete();
						continue;
					}
				}
				if (!queryUGCResult || details.m_eResult != EResult.k_EResultOK)
				{
					continue;
				}
				WorkshopItem workshopItem2 = sharedItems.FirstOrDefault((WorkshopItem t) => t.id == details.m_nPublishedFileId);
				if (workshopItem2 != null)
				{
					workshopItem2.SetItemDetails(details);
				}
				else
				{
					if (!subscribedIDs.Contains(details.m_nPublishedFileId))
					{
						continue;
					}
					workshopItem2 = subscribedItems.FirstOrDefault((WorkshopItem t) => t.id == details.m_nPublishedFileId);
					if (workshopItem2 == null)
					{
						if (subscribedItems.Any((WorkshopItem t) => t.id == details.m_nPublishedFileId))
						{
							subscribedItems.FirstOrDefault((WorkshopItem t) => t.id == details.m_nPublishedFileId).SetItemDetails(details);
						}
						else
						{
							string[] array = details.m_rgchTags.Split(",");
							WorkshopItemType itemType = ((!string.IsNullOrEmpty(array[0])) ? Enum.Parse<WorkshopItemType>(array[0]) : WorkshopItemType.Bibite);
							queryUGCResult = SteamUGC.GetItemInstallInfo(details.m_nPublishedFileId, out var _, out var pchFolder, 1024u, out var _);
							workshopItem2 = new WorkshopItem(details.m_nPublishedFileId, details, itemType, pchFolder);
							subscribedItems.Add(workshopItem2);
							allItems.Add(workshopItem2);
						}
					}
					else
					{
						workshopItem2.SetItemDetails(details);
					}
					if (!list.Contains(details.m_ulSteamIDOwner))
					{
						list.Add(details.m_ulSteamIDOwner);
					}
				}
			}
			SteamUGC.ReleaseQueryUGCRequest(pCallback.m_handle);
			foreach (ulong item in list)
			{
				SteamFriends.RequestUserInformation(new CSteamID(item), bRequireNameOnly: true);
			}
		}

		private void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIOFailure)
		{
			string[] obj = new string[8]
			{
				"[",
				3404.ToString(),
				" - SubmitItemUpdateResult] - ",
				pCallback.m_eResult.ToString(),
				" -- ",
				pCallback.m_bUserNeedsToAcceptWorkshopLegalAgreement.ToString(),
				" -- ",
				null
			};
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[7] = nPublishedFileId.ToString();
			Debug.Log(string.Concat(obj));
			WorkshopItem workshopItem = sharedItems.FirstOrDefault((WorkshopItem i) => i.id == pCallback.m_nPublishedFileId);
			if (workshopItem == null && tempItem.id == pCallback.m_nPublishedFileId)
			{
				workshopItem = tempItem;
				if (pCallback.m_eResult == EResult.k_EResultOK)
				{
					sharedItems.Add(workshopItem);
					if (!sourceFiles.ContainsKey(testFileId))
					{
						sourceFiles.Add(testFileId, pathToItemToShare.Replace(Application.persistentDataPath.Replace('/', Path.DirectorySeparatorChar), "").Remove(0, 1));
						WriteSharedToFiles();
					}
					testItemSubmitted = false;
					tempItem = null;
				}
			}
			onWorkshopItemSubmitResult.Invoke(pCallback.m_eResult, workshopItem);
		}

		private void OnItemInstalled(ItemInstalled_t pCallback)
		{
			string[] obj = new string[10]
			{
				"[",
				3405.ToString(),
				" - ItemInstalled] - ",
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			AppId_t unAppID = pCallback.m_unAppID;
			obj[3] = unAppID.ToString();
			obj[4] = " -- ";
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[5] = nPublishedFileId.ToString();
			obj[6] = " -- ";
			UGCHandle_t hLegacyContent = pCallback.m_hLegacyContent;
			obj[7] = hLegacyContent.ToString();
			obj[8] = " -- ";
			obj[9] = pCallback.m_unManifestID.ToString();
			Debug.Log(string.Concat(obj));
		}

		private void OnDownloadItemResult(DownloadItemResult_t pCallback)
		{
			string[] obj = new string[8]
			{
				"[",
				3406.ToString(),
				" - DownloadItemResult] - ",
				null,
				null,
				null,
				null,
				null
			};
			AppId_t unAppID = pCallback.m_unAppID;
			obj[3] = unAppID.ToString();
			obj[4] = " -- ";
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[5] = nPublishedFileId.ToString();
			obj[6] = " -- ";
			obj[7] = pCallback.m_eResult.ToString();
			Debug.Log(string.Concat(obj));
			PublishedFileId_t item = pCallback.m_nPublishedFileId;
			uint itemState = SteamUGC.GetItemState(item);
			string[] obj2 = new string[12]
			{
				"[GetItemState(", null, null, null, null, null, null, null, null, null,
				null, null
			};
			nPublishedFileId = pCallback.m_nPublishedFileId;
			obj2[1] = nPublishedFileId.ToString();
			obj2[2] = ") -- returned: ";
			obj2[3] = itemState.ToString();
			obj2[4] = "  --  ";
			obj2[5] = (((itemState & 1) != 0) ? "Subscribed   " : "");
			obj2[6] = (((itemState & 2) != 0) ? "Legacy   " : "");
			obj2[7] = (((itemState & 4) != 0) ? "Installed   " : "");
			obj2[8] = (((itemState & 8) != 0) ? "NeedsUpdate   " : "");
			obj2[9] = (((itemState & 0x10) != 0) ? "Downloading   " : "");
			obj2[10] = (((itemState & 0x20) != 0) ? "DownloadPending   " : "");
			obj2[11] = (((itemState & 0x40) != 0) ? "DisabledLocally   " : "");
			Debug.Log(string.Concat(obj2));
			ulong punSizeOnDisk;
			string pchFolder;
			uint punTimeStamp;
			bool itemInstallInfo = SteamUGC.GetItemInstallInfo(item, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp);
			Debug.Log($"[{item} - GetItemInstallInfo - {itemInstallInfo}] - {punSizeOnDisk} -- {pchFolder} -- {punTimeStamp}");
			WorkshopItem workshopItem = subscribedItems.FirstOrDefault((WorkshopItem i) => i.id == item);
			if (workshopItem != null)
			{
				workshopItem.ReUpdateAfterDownload(pchFolder);
				onWorkshopItemUpdated.Invoke(workshopItem);
			}
		}

		private void OnDeleteItemResult(DeleteItemResult_t pCallback, bool bIOFailure)
		{
			string[] obj = new string[6]
			{
				"[",
				3417.ToString(),
				" - DeleteItemResult] - ",
				pCallback.m_eResult.ToString(),
				" -- ",
				null
			};
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[5] = nPublishedFileId.ToString();
			Debug.Log(string.Concat(obj));
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				WorkshopItem item = sharedItems.FirstOrDefault((WorkshopItem i) => i.id == pCallback.m_nPublishedFileId);
				sharedItems.Remove(item);
				onWorkshopItemDestroyed.Invoke(pCallback.m_nPublishedFileId);
				if (sourceFiles.ContainsKey(pCallback.m_nPublishedFileId))
				{
					sourceFiles.Remove(pCallback.m_nPublishedFileId);
					WriteSharedToFiles();
				}
				if (tempItem.id == pCallback.m_nPublishedFileId)
				{
					tempItem.Delete();
				}
			}
		}

		private void OnUnsubscribeItemResult(RemoteStorageUnsubscribePublishedFileResult_t pCallback, bool bIOFailure)
		{
			string[] obj = new string[6]
			{
				"[",
				1315.ToString(),
				" - UnsubscribeItemResult] - ",
				pCallback.m_eResult.ToString(),
				" -- ",
				null
			};
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			obj[5] = nPublishedFileId.ToString();
			Debug.Log(string.Concat(obj));
			if (pCallback.m_eResult == EResult.k_EResultOK)
			{
				WorkshopItem workshopItem = subscribedItems.FirstOrDefault((WorkshopItem i) => i.id == pCallback.m_nPublishedFileId);
				subscribedItems.Remove(workshopItem);
				if (workshopItem.type == WorkshopItemType.Bibite)
				{
					bibiteItems.Remove(workshopItem);
				}
				else if (workshopItem.type == WorkshopItemType.Save)
				{
					saveItems.Remove(workshopItem);
				}
				else
				{
					scenarioItems.Remove(workshopItem);
				}
				onWorkshopItemUnSubscribed.Invoke(workshopItem);
			}
			else
			{
				PopupManager.DisplayError("Unsubscribing Error", "Unsubscribing from this item failed:\n" + pCallback.m_eResult.ToString() + pCallback.m_eResult.GetDetails());
			}
		}

		private void OnUserSubscribedItemsListChanged(UserSubscribedItemsListChanged_t pCallback)
		{
			string text = 3418.ToString();
			AppId_t nAppID = pCallback.m_nAppID;
			Debug.Log("[" + text + " - UserSubscribedItemsListChanged] - " + nAppID.ToString());
		}

		private void OnWorkshopEULAStatus(WorkshopEULAStatus_t pCallback, bool bIOFailure)
		{
			string[] obj = new string[14]
			{
				"[",
				3420.ToString(),
				" - WorkshopEULAStatus] - ",
				pCallback.m_eResult.ToString(),
				" -- ",
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			AppId_t nAppID = pCallback.m_nAppID;
			obj[5] = nAppID.ToString();
			obj[6] = " -- ";
			obj[7] = pCallback.m_unVersion.ToString();
			obj[8] = " -- ";
			RTime32 rtAction = pCallback.m_rtAction;
			obj[9] = rtAction.ToString();
			obj[10] = " -- ";
			obj[11] = pCallback.m_bAccepted.ToString();
			obj[12] = " -- ";
			obj[13] = pCallback.m_bNeedsAction.ToString();
			Debug.Log(string.Concat(obj));
		}

		private void ReadSharedFiles()
		{
			if (!File.Exists(sharedSourcesFilesPath))
			{
				return;
			}
			JObject jObject = JObject.Parse(File.ReadAllText(sharedSourcesFilesPath));
			sourceFiles.Clear();
			foreach (KeyValuePair<string, JToken> item in jObject)
			{
				ulong value = ulong.Parse(item.Key);
				string value2 = item.Value.ToString();
				sourceFiles.Add(new PublishedFileId_t(value), value2);
			}
		}

		private void WriteSharedToFiles()
		{
			JObject jObject = new JObject();
			foreach (KeyValuePair<PublishedFileId_t, string> sourceFile in sourceFiles)
			{
				jObject[sourceFile.Key.ToString()] = sourceFile.Value;
			}
			if (File.Exists(sharedSourcesFilesPath))
			{
				File.Delete(sharedSourcesFilesPath);
			}
			File.WriteAllText(sharedSourcesFilesPath, jObject.ToString());
		}

		private void OnApplicationQuit()
		{
			if (tempItem != null)
			{
				sourceFiles.Remove(tempItem.id);
				tempItem.Delete();
			}
			WriteSharedToFiles();
		}
	}
}
