using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

public class SteamWorkshopManager : MonoBehaviour
{
	private struct ItemInfosData
	{
		public ulong workshopId;

		public Action<string, float> callback;
	}

	private Callback<ItemInstalled_t> itemInstalledCallback;

	private bool isItemInfosRequestProcessing;

	private float itemInfosRequestTimeoutCounter;

	private bool isItemInfosProcessingCoroutineRunning;

	private Queue<ItemInfosData> itemInfosRequestsQueue;

	public static SteamWorkshopManager Instance => Singleton<SteamWorkshopManager>.Instance;

	public static bool Exist => Singleton<SteamWorkshopManager>.Exist;

	public event Action<string> OnWorkshopItemInstalled;

	private void Awake()
	{
		isItemInfosRequestProcessing = false;
		itemInfosRequestTimeoutCounter = 0f;
		isItemInfosProcessingCoroutineRunning = false;
		itemInfosRequestsQueue = new Queue<ItemInfosData>();
	}

	private void OnEnable()
	{
		itemInstalledCallback = Callback<ItemInstalled_t>.Create(ItemInstalledCallbackHandler);
	}

	private void ItemInstalledCallbackHandler(ItemInstalled_t param)
	{
		if (!(param.m_unAppID != SteamUtils.GetAppID()))
		{
			SteamUGC.GetItemInstallInfo(param.m_nPublishedFileId, out var _, out var pchFolder, 1024u, out var _);
			this.OnWorkshopItemInstalled?.Invoke(pchFolder);
		}
	}

	public List<string> GetListOfSubscribedItemsPaths()
	{
		PublishedFileId_t[] array = new PublishedFileId_t[SteamUGC.GetNumSubscribedItems()];
		SteamUGC.GetSubscribedItems(array, (uint)array.Length);
		ulong punSizeOnDisk = 0uL;
		string pchFolder = string.Empty;
		uint punTimeStamp = 0u;
		List<string> list = new List<string>();
		PublishedFileId_t[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			SteamUGC.GetItemInstallInfo(array2[i], out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp);
			list.Add(pchFolder);
		}
		return list;
	}

	public void GetItemInfos(ulong workshopId, Action<string, float> callback)
	{
		itemInfosRequestsQueue.Enqueue(new ItemInfosData
		{
			workshopId = workshopId,
			callback = callback
		});
		if (!isItemInfosProcessingCoroutineRunning)
		{
			StartCoroutine(ItemInfosProcessingHandler());
		}
	}

	private IEnumerator ItemInfosProcessingHandler()
	{
		isItemInfosProcessingCoroutineRunning = true;
		while (itemInfosRequestsQueue.Count != 0)
		{
			if (isItemInfosRequestProcessing)
			{
				itemInfosRequestTimeoutCounter += Time.unscaledDeltaTime;
				if (itemInfosRequestTimeoutCounter >= 3f)
				{
					Debug.LogWarning("Request Item Infos: TIMEOUT!");
					isItemInfosRequestProcessing = false;
				}
			}
			if (!isItemInfosRequestProcessing)
			{
				isItemInfosRequestProcessing = true;
				itemInfosRequestTimeoutCounter = 0f;
				ItemInfosData itemInfosData = itemInfosRequestsQueue.Peek();
				ulong workshopId = itemInfosData.workshopId;
				Action<string, float> callback = itemInfosData.callback;
				UGCQueryHandle_t query = SteamUGC.CreateQueryUGCDetailsRequest(new PublishedFileId_t[1]
				{
					new PublishedFileId_t(workshopId)
				}, 1u);
				CallResult<SteamUGCQueryCompleted_t> callResult = CallResult<SteamUGCQueryCompleted_t>.Create(delegate(SteamUGCQueryCompleted_t param, bool bIOFailure)
				{
					ItemInfosQueryCompletedHandler(param, bIOFailure, query, callback);
				});
				SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(query);
				callResult.Set(hAPICall);
				Debug.Log("Request Item Infos!");
			}
			yield return new WaitForEndOfFrame();
		}
		isItemInfosProcessingCoroutineRunning = false;
	}

	private void ItemInfosQueryCompletedHandler(SteamUGCQueryCompleted_t param, bool bIOFailure, UGCQueryHandle_t query, Action<string, float> callback)
	{
		if (bIOFailure || param.m_eResult != EResult.k_EResultOK)
		{
			isItemInfosRequestProcessing = false;
			Debug.Log($"Request Item Infos Failed: {param.m_eResult} ({bIOFailure})!");
			return;
		}
		string personaName = "";
		float score = 0f;
		if (SteamUGC.GetQueryUGCResult(query, 0u, out var pDetails))
		{
			CSteamID personaSteamID = new CSteamID(pDetails.m_ulSteamIDOwner);
			personaName = SteamFriends.GetFriendPersonaName(personaSteamID);
			score = pDetails.m_flScore;
			if (personaName == "" || personaName == "[unknown]")
			{
				Callback<PersonaStateChange_t>.Create(delegate(PersonaStateChange_t psc)
				{
					if (psc.m_ulSteamID == pDetails.m_ulSteamIDOwner)
					{
						personaName = SteamFriends.GetFriendPersonaName(personaSteamID);
						callback?.Invoke(personaName, score);
						Debug.Log($"Workshop Item Details: Requested User Infos ({personaName}, {psc.m_ulSteamID})!");
					}
				});
				SteamFriends.RequestUserInformation(personaSteamID, bRequireNameOnly: true);
			}
			Debug.Log($"Workshop Item Details: {pDetails.m_nPublishedFileId}, {pDetails.m_ulSteamIDOwner} ({personaName}), {pDetails.m_rtimeCreated}, {pDetails.m_flScore}");
		}
		SteamUGC.ReleaseQueryUGCRequest(query);
		callback?.Invoke(personaName, score);
		itemInfosRequestsQueue.Dequeue();
		isItemInfosRequestProcessing = false;
	}

	public void GetTrendsItems(Action<ulong[], string[], string[]> callback)
	{
		UGCQueryHandle_t query = SteamUGC.CreateQueryAllUGCRequest(EUGCQuery.k_EUGCQuery_RankedByTrend, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items, SteamUtils.GetAppID(), SteamUtils.GetAppID(), 1u);
		CallResult<SteamUGCQueryCompleted_t> callResult = CallResult<SteamUGCQueryCompleted_t>.Create(delegate(SteamUGCQueryCompleted_t param, bool bIOFailure)
		{
			TrendsItemsQueryCompletedHandler(param, bIOFailure, query, callback);
		});
		SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(query);
		callResult.Set(hAPICall);
	}

	private void TrendsItemsQueryCompletedHandler(SteamUGCQueryCompleted_t param, bool bIOFailure, UGCQueryHandle_t query, Action<ulong[], string[], string[]> callback)
	{
		if (bIOFailure || param.m_eResult != EResult.k_EResultOK)
		{
			Debug.Log($"Request Trends Items Failed: {param.m_eResult} ({bIOFailure})!");
			return;
		}
		List<ulong> list = new List<ulong>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		int num = Mathf.Clamp((int)param.m_unNumResultsReturned, 0, 8);
		for (uint num2 = 0u; num2 < num; num2++)
		{
			if (SteamUGC.GetQueryUGCResult(query, num2, out var pDetails))
			{
				string pchURL = "";
				SteamUGC.GetQueryUGCPreviewURL(query, num2, out pchURL, 512u);
				Debug.Log($"Trends Item Details: {pDetails.m_nPublishedFileId}, {pDetails.m_rgchTitle}, ({pchURL})");
				list.Add(pDetails.m_nPublishedFileId.m_PublishedFileId);
				list2.Add(pDetails.m_rgchTitle);
				list3.Add(pchURL);
			}
		}
		SteamUGC.ReleaseQueryUGCRequest(query);
		callback?.Invoke(list.ToArray(), list2.ToArray(), list3.ToArray());
	}
}
