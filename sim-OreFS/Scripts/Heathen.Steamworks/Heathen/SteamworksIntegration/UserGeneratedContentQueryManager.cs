using System;
using System.Collections.Generic;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration
{
	public class UserGeneratedContentQueryManager : MonoBehaviour
	{
		[Serializable]
		public class ResultsEvent : UnityEvent<List<WorkshopItem>>
		{
		}

		[SerializeField]
		private AppId_t creatorAppId;

		public UgcQuery activeQuery;

		public ResultsEvent evtResultsReturned;

		public UserGeneratedContentItemQueryEvent evtQueryPrepared;

		public UnityEvent evtResultsUpdated;

		private string lastSearchString = "";

		public int CurrentFrom
		{
			get
			{
				if (activeQuery != null)
				{
					int num = (int)(activeQuery.Page * 50);
					if (num < activeQuery.matchedRecordCount)
					{
						return num - 49;
					}
					int num2 = (int)(activeQuery.matchedRecordCount % 50);
					num = num - 50 + num2;
					return num - num2 + 1;
				}
				return 0;
			}
		}

		public int CurrentTo
		{
			get
			{
				if (activeQuery != null)
				{
					int num = (int)(activeQuery.Page * 50);
					if (num < activeQuery.matchedRecordCount)
					{
						return num;
					}
					int num2 = (int)(activeQuery.matchedRecordCount % 50);
					return num - 50 + num2;
				}
				return 0;
			}
		}

		public int TotalCount
		{
			get
			{
				if (activeQuery == null)
				{
					return 0;
				}
				return (int)activeQuery.matchedRecordCount;
			}
		}

		public int CurrentPage
		{
			get
			{
				if (activeQuery == null)
				{
					return 0;
				}
				return (int)activeQuery.Page;
			}
		}

		public void SearchAll(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(EUGCQuery.k_EUGCQuery_RankedByTrend, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			if (activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogError("Steam was unable to create a query handle for this argument. Check your App ID and the App ID in the query manager.");
			}
		}

		public void PrepareSearchAll(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(EUGCQuery.k_EUGCQuery_RankedByTrend, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			if (activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				evtQueryPrepared.Invoke(activeQuery);
			}
			else
			{
				Debug.LogError("Steam was unable to create a query handle for this argument. Check your App ID and the App ID in the query manager.");
			}
		}

		public void SearchFavorites(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Favorited, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			if (activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogError("Steam was unable to create a query handle for this argument. Check your App ID and the App ID in the query manager.");
			}
		}

		public void PrepareSearchFavorites(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Favorited, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			if (activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				evtQueryPrepared.Invoke(activeQuery);
			}
			else
			{
				Debug.LogError("Steam was unable to create a query handle for this argument. Check your App ID and the App ID in the query manager.");
			}
		}

		public void SearchFollowed(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Followed, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			if (activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogError("Steam was unable to create a query handle for this argument. Check your App ID and the App ID in the query manager.");
			}
		}

		public void PrepareSearchFollowed(string filter)
		{
			lastSearchString = filter;
			activeQuery = UgcQuery.Get(SteamUser.GetSteamID().GetAccountID(), EUserUGCList.k_EUserUGCList_Followed, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_TitleAsc, creatorAppId, AppData.Me);
			if (!string.IsNullOrEmpty(filter))
			{
				UserGeneratedContent.Client.SetSearchText(activeQuery.handle, filter);
			}
			evtQueryPrepared.Invoke(activeQuery);
		}

		public void ExecuteSearch()
		{
			if (activeQuery != null && activeQuery.handle != UGCQueryHandle_t.Invalid)
			{
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogError("Attempted to execute a query with an invalid query handle.");
			}
		}

		public void SetNextSearchPage()
		{
			if (activeQuery != null)
			{
				activeQuery.SetNextPage();
				if (!string.IsNullOrEmpty(lastSearchString))
				{
					UserGeneratedContent.Client.SetSearchText(activeQuery.handle, lastSearchString);
				}
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogWarning("No active query or the query handle is invalid, you must call a Search or Prepare Search method before iterating over the pages");
			}
		}

		public void SetPreviousSearchPage()
		{
			if (activeQuery != null)
			{
				activeQuery.SetPreviousPage();
				if (!string.IsNullOrEmpty(lastSearchString))
				{
					UserGeneratedContent.Client.SetSearchText(activeQuery.handle, lastSearchString);
				}
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogWarning("No active query or the query handle is invalid, you must call a Search or Prepare Search method before iterating over the pages");
			}
		}

		public void SetSearchPage(uint page)
		{
			if (activeQuery != null)
			{
				activeQuery.SetPage(page);
				if (!string.IsNullOrEmpty(lastSearchString))
				{
					UserGeneratedContent.Client.SetSearchText(activeQuery.handle, lastSearchString);
				}
				activeQuery.Execute(HandleResults);
			}
			else
			{
				Debug.LogWarning("No active query or the query handle is invalid, you must call a Search or Prepare Search method before iterating over the pages");
			}
		}

		private void HandleResults(UgcQuery query)
		{
			evtResultsReturned.Invoke(query.ResultsList);
		}
	}
}
