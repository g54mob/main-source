using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using DevConsole;
using Steamworks;
using UnityEngine;

public class SteamWorkshop : MonoBehaviour
{
	public static ulong UserID;

	protected CallResult<SteamUGCQueryCompleted_t> _UGCQuery;

	protected CallResult<CreateItemResult_t> _createItemResult;

	protected CallResult<SubmitItemUpdateResult_t> _submitItemResult;

	public static SteamWorkshop Instance;

	public static Dictionary<PublishedFileId_t, IWorkshopItem> WorkshopItems = new Dictionary<PublishedFileId_t, IWorkshopItem>();

	public static bool RunningQuery = false;

	public static bool DoneLoading = false;

	public static Queue<List<PublishedFileId_t>> QueryQueue = new Queue<List<PublishedFileId_t>>();

	public static string ChangeNotes = "";

	private static bool _init = false;

	public static bool HasFinished = false;

	private Dictionary<string, string> PreviousItems = new Dictionary<string, string>();

	private HashSet<string> FailedLoads = new HashSet<string>();

	private UGCUpdateHandle_t? CurrentUpdate;

	private IWorkshopItem UploadingItem;

	public Dictionary<PublishedFileId_t, KeyValuePair<string, ulong>> UnhandledUpdate = new Dictionary<PublishedFileId_t, KeyValuePair<string, ulong>>();

	private IEnumerator Start()
	{
		if (_init)
		{
			HasFinished = true;
			yield break;
		}
		_init = true;
		if (Instance != null)
		{
			HasFinished = true;
			UnityEngine.Object.Destroy(base.gameObject);
			yield break;
		}
		if (!SteamManager.Initialized)
		{
			DoneLoading = !SteamManager.Initialized;
			HasFinished = true;
			UnityEngine.Object.Destroy(base.gameObject);
			yield break;
		}
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		IEnumerator ws = LoadWorkshopCache();
		while (ws.MoveNext())
		{
			yield return ws.Current;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (SteamManager.Initialized)
		{
			_UGCQuery = CallResult<SteamUGCQueryCompleted_t>.Create(OnUGCquery);
			_createItemResult = CallResult<CreateItemResult_t>.Create(CreateItemResult);
			_submitItemResult = CallResult<SubmitItemUpdateResult_t>.Create(SubmitItemResult);
			UserID = SteamUser.GetSteamID().m_SteamID;
			List<PublishedFileId_t> list = new List<PublishedFileId_t>();
			CheckItems(GameData.ModPackages.OfType<IWorkshopItem>(), list);
			CheckItems(Localization.GetLanguages().OfType<IWorkshopItem>(), list);
			CheckItems(GameData.Blueprints.OfType<IWorkshopItem>(), list);
			CheckItems(RoomMaterialController.Instance.MaterialPacks.OfType<IWorkshopItem>(), list);
			CheckItems(ModController.Instance.Mods.OfType<IWorkshopItem>(), list);
			CheckItems(SaveGameManager.WorkshoppableGames.OfType<IWorkshopItem>(), list);
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
			numSubscribedItems = SteamUGC.GetSubscribedItems(array, numSubscribedItems);
			for (int i = 0; i < numSubscribedItems; i++)
			{
				ulong punSizeOnDisk;
				string pchFolder;
				uint punTimeStamp;
				if (SteamUGC.GetItemInstallInfo(array[i], out punSizeOnDisk, out pchFolder, 512u, out punTimeStamp))
				{
					IWorkshopItem workshopItem = LoadMod(GetModType(pchFolder), pchFolder, "Steam ID: " + Path.GetFileName(pchFolder), true);
					if (workshopItem != null)
					{
						UpdateItemStatus(workshopItem, array[i]);
					}
					list.Add(array[i]);
				}
			}
			if (list.Count > 0)
			{
				RunningQuery = true;
				SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(SteamUGC.CreateQueryUGCDetailsRequest(list.ToArray(), (uint)list.Count));
				_UGCQuery.Set(hAPICall);
			}
			LoadDebugger.AddInfo("Finished loading Steam Workshop");
		}
		HasFinished = true;
		DoneLoading = true;
	}

	public static void RecheckItems(IEnumerable<IWorkshopItem> items)
	{
		if (!(Instance != null))
		{
			return;
		}
		List<PublishedFileId_t> list = new List<PublishedFileId_t>();
		Instance.CheckItems(items, list);
		if (list.Count > 0)
		{
			if (RunningQuery)
			{
				QueryQueue.Enqueue(list);
				return;
			}
			Instance._UGCQuery = CallResult<SteamUGCQueryCompleted_t>.Create(Instance.OnUGCquery);
			RunningQuery = true;
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(SteamUGC.CreateQueryUGCDetailsRequest(list.ToArray(), (uint)list.Count));
			Instance._UGCQuery.Set(hAPICall);
		}
	}

	private IEnumerator LoadWorkshopCache()
	{
		if (!File.Exists("WorkshopCache.txt"))
		{
			yield break;
		}
		ConfigFile configFile;
		try
		{
			configFile = ConfigFile.Load(File.ReadAllLines("WorkshopCache.txt"));
		}
		catch (Exception)
		{
			yield break;
		}
		foreach (KeyValuePair<string, List<string>> value in configFile.Values)
		{
			bool flag = true;
			if (value.Value.Count == 0)
			{
				continue;
			}
			try
			{
				string text = value.Value[0];
				IWorkshopItem workshopItem = LoadMod(GetModType(text), text, value.Key, false);
				if (workshopItem != null && !(workshopItem is FailMod))
				{
					workshopItem.SetName(value.Key, true);
					workshopItem.UpdateSteam(false);
					PreviousItems[value.Key] = text;
				}
				else
				{
					FailedLoads.Add(NormalizePath(text));
				}
			}
			catch (Exception)
			{
				flag = false;
			}
			if (flag)
			{
				yield return new WaitForEndOfFrame();
			}
		}
	}

	private void RefreshWorkshopCache()
	{
		try
		{
			string value = NormalizePath(Path.GetFullPath("./"));
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> previousItem in PreviousItems)
			{
				if (Directory.Exists(previousItem.Value) && File.Exists(Path.Combine(previousItem.Value, "pubID.txt")))
				{
					dictionary[previousItem.Key] = previousItem.Value;
				}
			}
			foreach (KeyValuePair<PublishedFileId_t, IWorkshopItem> workshopItem in WorkshopItems)
			{
				if (!NormalizePath(workshopItem.Value.FolderPath()).StartsWith(value))
				{
					dictionary[workshopItem.Value.ItemTitle] = workshopItem.Value.FolderPath();
				}
			}
			if (dictionary.Count <= 0)
			{
				return;
			}
			ConfigFile configFile = new ConfigFile();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				configFile.Add(item.Key, item.Value);
			}
			File.WriteAllText("WorkshopCache.txt", configFile.Serialize());
		}
		catch (Exception)
		{
		}
	}

	private void CheckItems(IEnumerable<IWorkshopItem> items, List<PublishedFileId_t> pubIds)
	{
		foreach (IWorkshopItem item in items)
		{
			WriteModID(item);
			PublishedFileId_t? steamID = item.GetSteamID();
			if (steamID.HasValue)
			{
				UpdateItemStatus(item, steamID.Value);
				pubIds.Add(steamID.Value);
			}
		}
	}

	private void Update()
	{
		if (!(MainMenuController.Instance != null))
		{
			return;
		}
		if (CurrentUpdate.HasValue)
		{
			MainMenuController.Instance.pBarGO.SetActive(true);
			ulong punBytesProcessed;
			ulong punBytesTotal;
			switch (SteamUGC.GetItemUpdateProgress(CurrentUpdate.Value, out punBytesProcessed, out punBytesTotal))
			{
			case EItemUpdateStatus.k_EItemUpdateStatusInvalid:
				Debug.Log("Got invalid steam update status");
				WaitPanel(false);
				CurrentUpdate = null;
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig:
				MainMenuController.Instance.pBarText.text = "Preparing".Loc();
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusPreparingContent:
				MainMenuController.Instance.pBarText.text = "Preparing".Loc();
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusUploadingContent:
				MainMenuController.Instance.pBarText.text = "Uploading".Loc();
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile:
				MainMenuController.Instance.pBarText.text = "Uploading".Loc();
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges:
				MainMenuController.Instance.pBarText.text = "Committing".Loc();
				break;
			default:
				MainMenuController.Instance.pBarText.text = "";
				break;
			}
			MainMenuController.Instance.pBar.Value = ((punBytesTotal != 0) ? ((float)punBytesProcessed / (float)punBytesTotal) : 0f);
		}
		else
		{
			MainMenuController.Instance.pBarGO.SetActive(false);
		}
	}

	public void UpdateItemStatus(IWorkshopItem item, PublishedFileId_t id)
	{
		item.UpdateSteam(id, false);
		item.SetTitle = false;
		WorkshopItems[id] = item;
	}

	public static void PrepareMod(IWorkshopItem item)
	{
		string path = Path.Combine(item.FolderPath(), "TypeInfo.txt");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		File.WriteAllText(path, item.GetWorkshopType());
		path = Path.Combine(item.FolderPath(), "pubID.txt");
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	public static string CheckValid(string[] ext, string path)
	{
		if (Directory.Exists(path))
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				string text = Path.GetExtension(files[i]).ToLower();
				bool flag = false;
				for (int j = 0; j < ext.Length; j++)
				{
					if (text.EndsWith(ext[j]))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return "SteamUploadFileType".Loc(text);
				}
			}
			files = Directory.GetDirectories(path);
			foreach (string path2 in files)
			{
				string text2 = CheckValid(ext, path2);
				if (text2 != null)
				{
					return text2;
				}
			}
			return null;
		}
		return "SteamUploadDirectoryError".Loc(path);
	}

	public static string GetModType(string path)
	{
		string path2 = Path.Combine(path, "TypeInfo.txt");
		if (File.Exists(path2))
		{
			return File.ReadAllText(path2).Trim();
		}
		return null;
	}

	public static void WriteModID(IWorkshopItem item)
	{
		string text = item.FolderPath();
		if (text == null)
		{
			return;
		}
		string path = Path.Combine(text, "pubID.txt");
		if (File.Exists(path))
		{
			PublishedFileId_t value = new PublishedFileId_t(Convert.ToUInt64(File.ReadAllText(path).Trim()));
			if (item.UpdateSteam(value))
			{
				File.Delete(path);
			}
		}
	}

	public static IWorkshopItem LoadMod(string type, string path, string name, bool withDummy)
	{
		string p = NormalizePath(path);
		if (Instance != null && Instance.FailedLoads.Contains(p))
		{
			return null;
		}
		switch (type)
		{
		case "Mod":
		case "Data mod":
		{
			ModPackage modPackage = GameData.ModPackages.FirstOrDefault((ModPackage x) => x.SameRoot(p, true));
			if (modPackage == null)
			{
				float realtimeSinceStartup4 = Time.realtimeSinceStartup;
				IWorkshopItem result4 = GameData.LoadSteamMod(path, name);
				LoadDebugger.AddSteamInfo("Data mods", Time.realtimeSinceStartup - realtimeSinceStartup4);
				return result4;
			}
			return modPackage;
		}
		case "Localization":
		{
			Localization.Translation translation = Localization.GetLanguages().FirstOrDefault((Localization.Translation x) => x.SameRoot(p, true));
			if (translation == null)
			{
				float realtimeSinceStartup3 = Time.realtimeSinceStartup;
				IWorkshopItem result3 = Localization.LoadSteamLanguage(path, name);
				LoadDebugger.AddSteamInfo("Languages", Time.realtimeSinceStartup - realtimeSinceStartup3);
				return result3;
			}
			return translation;
		}
		case "Blueprint":
		{
			BlueprintGroup blueprintGroup = GameData.Blueprints.FirstOrDefault((BlueprintGroup x) => x.SameRoot(p, true));
			if (blueprintGroup == null)
			{
				float realtimeSinceStartup5 = Time.realtimeSinceStartup;
				IWorkshopItem result5 = GameData.LoadSteamPrefab(path, name);
				LoadDebugger.AddSteamInfo("Blueprints", Time.realtimeSinceStartup - realtimeSinceStartup5);
				return result5;
			}
			return blueprintGroup;
		}
		case "Furniture":
		{
			FurnitureMod furnitureMod = FurnitureLoader.LoadedFurniture.FirstOrDefault((FurnitureMod x) => x.SameRoot(p, true));
			if (furnitureMod == null)
			{
				bool errors = false;
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				IWorkshopItem result2 = FurnitureLoader.LoadFurnitureMod(path, ref errors, name);
				LoadDebugger.AddSteamInfo("Furniture mods", Time.realtimeSinceStartup - realtimeSinceStartup2);
				return result2;
			}
			return furnitureMod;
		}
		case "Material":
		{
			RoomMaterialPack roomMaterialPack = RoomMaterialController.Instance.MaterialPacks.FirstOrDefault((RoomMaterialPack x) => x.SameRoot(p, true));
			if (roomMaterialPack == null)
			{
				float realtimeSinceStartup7 = Time.realtimeSinceStartup;
				IWorkshopItem workshopItem2 = RoomMaterialPack.LoadPack(path, false, ref RoomMaterialController.ErrorsDuringLoad);
				RoomMaterialPack roomMaterialPack2 = workshopItem2 as RoomMaterialPack;
				if (roomMaterialPack2 != null)
				{
					RoomMaterialController.Instance.MaterialPacks.Add(roomMaterialPack2);
				}
				LoadDebugger.AddSteamInfo("Materials", Time.realtimeSinceStartup - realtimeSinceStartup7);
				return workshopItem2;
			}
			return roomMaterialPack;
		}
		case "Building":
		{
			SaveGame saveGame = SaveGameManager.WorkshoppableGames.FirstOrDefault((SaveGame x) => x.SameRoot(p, true));
			if (saveGame == null)
			{
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, "*.build");
					if (files.Length != 0)
					{
						float realtimeSinceStartup6 = Time.realtimeSinceStartup;
						IWorkshopItem workshopItem = SaveGameManager.LoadGameMeta(files[0], true, false);
						SaveGame saveGame2 = workshopItem as SaveGame;
						if (saveGame2 != null)
						{
							SaveGameManager.AddSave(saveGame2);
						}
						LoadDebugger.AddSteamInfo("Buildings", Time.realtimeSinceStartup - realtimeSinceStartup6);
						return workshopItem;
					}
				}
				return null;
			}
			return saveGame;
		}
		case "Code mod":
		{
			ModController.DLLMod dLLMod = ModController.Instance.Mods.FirstOrDefault((ModController.DLLMod x) => x.SameRoot(p, true));
			if (dLLMod == null)
			{
				if (Directory.Exists(path))
				{
					float realtimeSinceStartup = Time.realtimeSinceStartup;
					IWorkshopItem result = ModController.Instance.LoadMod(path, false, false, false, name);
					LoadDebugger.AddSteamInfo("Code mods", Time.realtimeSinceStartup - realtimeSinceStartup);
					return result;
				}
				return new FailMod("Code mod", p, name, "File not found");
			}
			return dLLMod;
		}
		default:
			return null;
		}
	}

	public static string NormalizePath(string path)
	{
		return Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToUpperInvariant();
	}

	public void UploadMod(IWorkshopItem mod)
	{
		if (!mod.CanUpload || UploadingItem != null)
		{
			return;
		}
		UploadingItem = mod;
		if (UploadingItem.GetSteamID().HasValue)
		{
			WindowManager.SpawnInputDialog("SteamWorkshopNotePrompt".Loc(), "Changenotes".Loc(), "", delegate(string x)
			{
				PrepareMod(UploadingItem);
				ChangeNotes = x;
				WaitPanel(true);
				UploadContent();
			}, delegate
			{
				UploadingItem = null;
			});
			return;
		}
		DialogWindow diag = WindowManager.SpawnDialog();
		diag.Show("SteamUploadConfirmation".Loc(), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
		{
			WaitPanel(true);
			SteamAPICall_t hAPICall = SteamUGC.CreateItem((AppId_t)362620u, EWorkshopFileType.k_EWorkshopFileTypeFirst);
			_createItemResult.Set(hAPICall);
			diag.Window.Close();
		}), new KeyValuePair<string, Action>("No", delegate
		{
			UploadingItem = null;
			diag.Window.Close();
		}));
	}

	private void UploadContent()
	{
		PublishedFileId_t? steamID = UploadingItem.GetSteamID();
		if (UploadingItem.CanUpload && UploadingItem != null && steamID.HasValue)
		{
			Debug.Log("Starting Steam workshop item upload for item: " + steamID.Value);
			UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate((AppId_t)362620u, steamID.Value);
			CurrentUpdate = uGCUpdateHandle_t;
			if (UploadingItem.SetTitle)
			{
				Debug.Log("Setting title: " + UploadingItem.ItemTitle);
				SteamUGC.SetItemTitle(uGCUpdateHandle_t, UploadingItem.ItemTitle);
			}
			string fullPath = Path.GetFullPath(UploadingItem.FolderPath());
			Debug.Log("Setting content folder: " + fullPath);
			SteamUGC.SetItemContent(uGCUpdateHandle_t, fullPath);
			List<string> list = new List<string>();
			list.Add(UploadingItem.GetWorkshopType());
			list.AddRange(UploadingItem.ExtraTags());
			Debug.Log("Setting tags: " + string.Join(", ", list.ToArray()));
			SteamUGC.SetItemTags(uGCUpdateHandle_t, list);
			string thumbnail = UploadingItem.GetThumbnail();
			if (thumbnail != null)
			{
				Debug.Log("Setting thumbnail " + thumbnail);
				SteamUGC.SetItemPreview(uGCUpdateHandle_t, thumbnail);
			}
			Debug.Log("Submitting to Steam and registering callback");
			SteamAPICall_t steamAPICall_t = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, ChangeNotes);
			if (steamAPICall_t == SteamAPICall_t.Invalid)
			{
				Debug.Log("Workshop update handle invalid");
				WindowManager.SpawnDialog("FailedSteamUpload".Loc("Update handle invalid"), true, DialogWindow.DialogType.Error);
				WaitPanel(false);
				CurrentUpdate = null;
				UploadingItem = null;
			}
			else
			{
				_submitItemResult.Set(steamAPICall_t);
			}
		}
		else
		{
			Debug.Log("Not authorized to upload this Workshop item");
			WindowManager.SpawnDialog("FailedSteamUpload".Loc("Not authorized to upload this item"), true, DialogWindow.DialogType.Error);
			WaitPanel(false);
			CurrentUpdate = null;
			UploadingItem = null;
		}
	}

	private void WaitPanel(bool show)
	{
		if (MainMenuController.Instance != null)
		{
			MainMenuController.Instance.WaitPanel.SetActive(show);
		}
	}

	private void SubmitItemResult(SubmitItemUpdateResult_t result, bool failure)
	{
		if (UploadingItem == null)
		{
			Debug.Log("Steam work item upload callback received for null");
			WindowManager.SpawnDialog("FailedSteamUpload".Loc(result.m_eResult.ToString()), true, DialogWindow.DialogType.Error);
			return;
		}
		Debug.Log("Steam work item upload callback received for " + UploadingItem.GetSteamID().Value);
		CurrentUpdate = null;
		WaitPanel(false);
		if (failure || result.m_eResult != EResult.k_EResultOK)
		{
			WindowManager.SpawnDialog("FailedSteamUpload".Loc(result.m_eResult.ToString()), true, DialogWindow.DialogType.Error);
		}
		else
		{
			WriteModID(UploadingItem);
			WorkshopItems[UploadingItem.GetSteamID().Value] = UploadingItem;
			WindowManager.SpawnDialog("SuccessSteamUpload".Loc(), true, DialogWindow.DialogType.Information);
			SteamFriends.ActivateGameOverlayToWebPage("steam://url/CommunityFilePage/" + UploadingItem.GetSteamID().Value.m_PublishedFileId);
		}
		UploadingItem = null;
	}

	private void CreateItemResult(CreateItemResult_t result, bool failure)
	{
		if (!failure && result.m_eResult == EResult.k_EResultOK)
		{
			if (result.m_bUserNeedsToAcceptWorkshopLegalAgreement)
			{
				SteamFriends.ActivateGameOverlayToWebPage("steam://url/CommunityFilePage/" + result.m_nPublishedFileId.m_PublishedFileId);
			}
			UploadingItem.UpdateSteam(result.m_nPublishedFileId);
			PrepareMod(UploadingItem);
			UploadingItem.UpdateSteam(result.m_nPublishedFileId);
			WorkshopItems[result.m_nPublishedFileId] = UploadingItem;
			UploadContent();
		}
		else
		{
			WaitPanel(false);
			WindowManager.SpawnDialog("FailedSteamUpload".Loc(result.m_eResult.ToString()), true, DialogWindow.DialogType.Error);
		}
	}

	private void OnUGCquery(SteamUGCQueryCompleted_t result, bool failure)
	{
		if (!failure && result.m_eResult == EResult.k_EResultOK)
		{
			for (uint num = 0u; num < result.m_unNumResultsReturned; num++)
			{
				SteamUGCDetails_t pDetails;
				SteamUGC.GetQueryUGCResult(result.m_handle, num, out pDetails);
				OnGameUGCRequest(pDetails);
			}
			RefreshWorkshopCache();
		}
		else
		{
			string text = "Failed running Steam query with error code " + result.m_eResult;
			Debug.Log(text);
			DevConsole.Console.LogError(text);
		}
		if (QueryQueue.Count > 0)
		{
			_UGCQuery = CallResult<SteamUGCQueryCompleted_t>.Create(OnUGCquery);
			List<PublishedFileId_t> list = QueryQueue.Dequeue();
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(SteamUGC.CreateQueryUGCDetailsRequest(list.ToArray(), (uint)list.Count));
			_UGCQuery.Set(hAPICall);
		}
		else
		{
			RunningQuery = false;
		}
	}

	private void OnGameUGCRequest(SteamUGCDetails_t result)
	{
		IWorkshopItem value;
		if (WorkshopItems.TryGetValue(result.m_nPublishedFileId, out value))
		{
			if (result.m_eResult == EResult.k_EResultFileNotFound)
			{
				value.UpdateSteam(true);
				value.SetTitle = true;
				WriteModID(value);
				WorkshopItems.Remove(result.m_nPublishedFileId);
				return;
			}
			if (value is DummyWorkshopItem || value is FailMod)
			{
				value.SetName(result.m_rgchTitle, true);
				return;
			}
			value.SetName(result.m_rgchTitle, true);
			value.SteamNameUpdated();
			value.UpdateSteam(UserID == result.m_ulSteamIDOwner);
			if (LanguageWindow.Instance != null)
			{
				LanguageWindow.Instance.Refresh();
			}
		}
		else
		{
			UnhandledUpdate[result.m_nPublishedFileId] = new KeyValuePair<string, ulong>(result.m_rgchTitle, result.m_ulSteamIDOwner);
		}
	}
}
