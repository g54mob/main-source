using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Workshop
{
	public class SteamWorkshopQuery
	{
		public bool HasResult;

		public uint NumberOfResults;

		public uint TotalNumberOfResults;

		public uint PageNumber;

		public uint TotalNumberOfPages;

		public List<WorkshopItemResult> Results;

		public IEnumerator StartUser(EUserUGCListSortOrder query, EUserUGCList list, uint page, string searchText, List<string> tags = null)
		{
			HasResult = false;
			Results = new List<WorkshopItemResult>();
			if (page != 0 && SteamManager.Initialized)
			{
				UGCQueryHandle_t queryHandle = SteamUGC.CreateQueryUserUGCRequest(SteamUser.GetSteamID().GetAccountID(), list, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, query, SteamManager.AppId, SteamManager.MainAppId, page);
				yield return StartQuery(queryHandle, page, searchText, tags);
			}
			yield return true;
		}

		public IEnumerator Start(EUGCQuery query, uint page, string searchText, List<string> tags = null)
		{
			HasResult = false;
			Results = new List<WorkshopItemResult>();
			if (SteamManager.Initialized)
			{
				UGCQueryHandle_t queryHandle = SteamUGC.CreateQueryAllUGCRequest(query, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, SteamManager.AppId, SteamManager.MainAppId, page);
				yield return StartQuery(queryHandle, page, searchText, tags);
			}
			yield return true;
		}

		private IEnumerator StartQuery(UGCQueryHandle_t queryHandle, uint page, string searchText, List<string> tags = null)
		{
			SteamUGC.AddRequiredTag(queryHandle, "Drone");
			SteamUGC.SetMatchAnyTag(queryHandle, false);
			SteamUGC.SetReturnLongDescription(queryHandle, true);
			SteamUGC.SetReturnMetadata(queryHandle, true);
			if (!string.IsNullOrEmpty(searchText))
			{
				SteamUGC.SetSearchText(queryHandle, searchText);
			}
			if (tags != null)
			{
				foreach (string tag in tags)
				{
					SteamUGC.AddRequiredTag(queryHandle, tag);
				}
			}
			SteamCallbackCoroutine<SteamUGCQueryCompleted_t> sendQuery = new SteamCallbackCoroutine<SteamUGCQueryCompleted_t>();
			SteamAPICall_t handle = SteamUGC.SendQueryUGCRequest(queryHandle);
			IEnumerator enumerator2 = sendQuery.Start(handle, 20f);
			while (enumerator2.MoveNext())
			{
				yield return enumerator2.Current;
			}
			if (sendQuery.HasResult)
			{
				if (sendQuery.Result.m_eResult != EResult.k_EResultOK)
				{
					Debug.Log(sendQuery.Result.m_eResult);
				}
				PageNumber = page;
				TotalNumberOfResults = sendQuery.Result.m_unTotalMatchingResults;
				TotalNumberOfPages = (uint)Mathf.CeilToInt((float)sendQuery.Result.m_unTotalMatchingResults / 50f);
				NumberOfResults = sendQuery.Result.m_unNumResultsReturned;
				Debug.Log(NumberOfResults);
				for (uint num = 0u; num < NumberOfResults; num++)
				{
					SteamUGCDetails_t pDetails;
					if (!SteamUGC.GetQueryUGCResult(queryHandle, num, out pDetails))
					{
						continue;
					}
					WorkshopItemResult workshopItemResult = new WorkshopItemResult();
					ulong pStatValue;
					if (SteamUGC.GetQueryUGCStatistic(queryHandle, num, EItemStatistic.k_EItemStatistic_NumSubscriptions, out pStatValue))
					{
						workshopItemResult.NumberOfDownloads = pStatValue;
					}
					workshopItemResult.FileId = pDetails.m_nPublishedFileId;
					workshopItemResult.Tags = tags;
					workshopItemResult.OwnerId = pDetails.m_ulSteamIDOwner;
					workshopItemResult.Title = pDetails.m_rgchTitle;
					workshopItemResult.Description = pDetails.m_rgchDescription;
					workshopItemResult.UpVotes = pDetails.m_unVotesUp;
					workshopItemResult.DownVotes = pDetails.m_unVotesDown;
					workshopItemResult.Score = pDetails.m_flScore;
					string pchMetadata;
					System.Version result;
					if (SteamUGC.GetQueryUGCMetadata(queryHandle, num, out pchMetadata, 1000u) && System.Version.TryParse(pchMetadata, out result))
					{
						workshopItemResult.Version = result;
					}
					workshopItemResult.IsDownloaded = false;
					ulong punSizeOnDisk;
					string pchFolder;
					uint punTimeStamp;
					if (SteamUGC.GetItemInstallInfo(pDetails.m_nPublishedFileId, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp) && Directory.Exists(pchFolder))
					{
						EItemState itemState = (EItemState)SteamUGC.GetItemState(pDetails.m_nPublishedFileId);
						if (itemState.Contains(EItemState.k_EItemStateSubscribed) && itemState.Contains(EItemState.k_EItemStateInstalled))
						{
							workshopItemResult.IsDownloaded = true;
						}
					}
					workshopItemResult.CanBeEdited = pDetails.m_ulSteamIDOwner == SteamUser.GetSteamID().m_SteamID;
					if (!pDetails.m_bBanned && pDetails.m_eResult == EResult.k_EResultOK)
					{
						SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.StartCoroutine(DownloadImage(workshopItemResult, pDetails));
						Results.Add(workshopItemResult);
					}
				}
				HasResult = true;
				SteamUGC.ReleaseQueryUGCRequest(queryHandle);
			}
			yield return true;
		}

		private IEnumerator DownloadImage(WorkshopItemResult result, SteamUGCDetails_t itemDetails)
		{
			int tries = 0;
			bool shouldEnd = false;
			while (tries < 3 && !shouldEnd)
			{
				SteamCallbackCoroutine<RemoteStorageDownloadUGCResult_t> downloadImage = new SteamCallbackCoroutine<RemoteStorageDownloadUGCResult_t>();
				SteamAPICall_t handle = SteamRemoteStorage.UGCDownload(itemDetails.m_hPreviewFile, 0u);
				IEnumerator enumerator = downloadImage.Start(handle, 10f);
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
				if (downloadImage.HasResult && downloadImage.Result.m_eResult == EResult.k_EResultOK)
				{
					int nSizeInBytes = downloadImage.Result.m_nSizeInBytes;
					byte[] array = new byte[nSizeInBytes];
					if (SteamRemoteStorage.UGCRead(downloadImage.Result.m_hFile, array, nSizeInBytes, 0u, EUGCReadAction.k_EUGCRead_Close) > 0)
					{
						if (result.Version <= new System.Version(1, 0, 0))
						{
							result.PreviewImage = new Texture2D(1, 1, TextureFormat.ARGB32, false, true);
						}
						else
						{
							result.PreviewImage = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
						}
						result.PreviewImage.LoadImage(array);
						result.PreviewImage.Apply(true);
						result.PreviewImage.wrapMode = TextureWrapMode.Clamp;
						shouldEnd = true;
					}
				}
				tries++;
				yield return true;
			}
		}
	}
}
