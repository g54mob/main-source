using System.Collections.Generic;
using System.IO;
using NaughtyAttributes;
using Steamworks;
using UnityEngine;

public class SteamWorkshopController : MonoBehaviour
{
	private SteamWorkshopItem currentSteamWorkshopItem;

	private PublishedFileId_t publishedFileID;

	private static UGCUpdateHandle_t curUpdateHandle;

	private static string LocalDdsConfigPath;

	public List<SteamMod> subscribedMods;

	public ModSnapshot modSnapshot;

	public GameObject steamModeElementPrefab;

	public bool modConfigChanged;

	public List<WorkshopModEntryController> spawnedModElements;

	public ButtonController applyButton;

	public RectTransform modContentRect;

	private string itemContent;

	public bool fetchedContent;

	private UGCQueryHandle_t _ugcHandleT;

	public static SteamWorkshopController Instance { get; private set; }

	[Button(null, EButtonEnableMode.Always)]
	public List<string> GetListOfSubscribedItemsPaths()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void FindSnapshot()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TakeModSnapshot()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void QueryApiTesting()
	{
	}

	private void OnAvailableItemsComplete(SteamUGCQueryCompleted_t p_callback, bool failure)
	{
	}

	public void Execute<T>(SteamAPICall_t p_steamCall, CallResult<T>.APIDispatchDelegate p_onCompleted)
	{
	}

	public void Unsubscribe(PublishedFileId_t pubFileId)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TestUpload()
	{
	}

	public void UploadContent(string itemTitle, string itemDescription, string contentFolderPath, string[] tags, string previewImagePath)
	{
	}

	private void Start()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	private List<DirectoryInfo> LoadLocalDDSMods()
	{
		return null;
	}

	private void CreateItem()
	{
	}

	private void CreateItemResult(CreateItemResult_t param, bool bIOFailure)
	{
	}

	private void UpdateItem()
	{
	}

	private void DeleteItem(PublishedFileId_t publishedFileIdT)
	{
	}

	private void UpdateItemResult(SubmitItemUpdateResult_t param, bool bIOFailure)
	{
	}

	private List<DirectoryInfo> InitializeAndFetchLocalWorkshopDirectories()
	{
		return null;
	}
}
