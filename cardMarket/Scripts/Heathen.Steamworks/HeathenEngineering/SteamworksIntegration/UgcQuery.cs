using System;
using System.Collections.Generic;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	public class UgcQuery : IDisposable
	{
		public UGCQueryHandle_t handle;

		public uint matchedRecordCount;

		public uint pageCount = 1u;

		private bool isAllQuery;

		private bool isUserQuery;

		private EUserUGCList listType;

		private EUGCQuery queryType;

		private EUGCMatchingUGCType matchingType;

		private EUserUGCListSortOrder sortOrder;

		private AppId_t creatorApp;

		private AppId_t consumerApp;

		private AccountID_t account;

		private uint _Page = 1u;

		private UnityAction<UgcQuery> callback;

		public CallResult<SteamUGCQueryCompleted_t> m_SteamUGCQueryCompleted;

		public List<WorkshopItem> ResultsList = new List<WorkshopItem>();

		public uint Page
		{
			get
			{
				return _Page;
			}
			set
			{
				SetPage(value);
			}
		}

		private UgcQuery()
		{
			m_SteamUGCQueryCompleted = CallResult<SteamUGCQueryCompleted_t>.Create(HandleQueryCompleted);
		}

		public static UgcQuery Get(EUGCQuery queryType, EUGCMatchingUGCType matchingType, AppId_t creatorApp, AppId_t consumerApp)
		{
			return new UgcQuery
			{
				matchedRecordCount = 0u,
				pageCount = 1u,
				isAllQuery = true,
				isUserQuery = false,
				queryType = queryType,
				matchingType = matchingType,
				creatorApp = creatorApp,
				consumerApp = consumerApp,
				Page = 1u,
				handle = UserGeneratedContent.Client.CreateQueryAllRequest(queryType, matchingType, creatorApp, consumerApp, 1u)
			};
		}

		public static UgcQuery Get(params PublishedFileId_t[] fileIds)
		{
			if (fileIds == null || fileIds.Length < 1)
			{
				return null;
			}
			return new UgcQuery
			{
				matchedRecordCount = 0u,
				pageCount = 1u,
				isAllQuery = true,
				isUserQuery = false,
				Page = 1u,
				handle = UserGeneratedContent.Client.CreateQueryDetailsRequest(fileIds)
			};
		}

		public static UgcQuery Get(IEnumerable<PublishedFileId_t> fileIds)
		{
			List<PublishedFileId_t> list = new List<PublishedFileId_t>(fileIds);
			return new UgcQuery
			{
				matchedRecordCount = 0u,
				pageCount = 1u,
				isAllQuery = true,
				isUserQuery = false,
				Page = 1u,
				handle = UserGeneratedContent.Client.CreateQueryDetailsRequest(list.ToArray())
			};
		}

		public static UgcQuery Get(AccountID_t account, EUserUGCList listType, EUGCMatchingUGCType matchingType, EUserUGCListSortOrder sortOrder, AppId_t creatorApp, AppId_t consumerApp)
		{
			return new UgcQuery
			{
				matchedRecordCount = 0u,
				pageCount = 1u,
				isAllQuery = false,
				isUserQuery = true,
				listType = listType,
				sortOrder = sortOrder,
				matchingType = matchingType,
				creatorApp = creatorApp,
				consumerApp = consumerApp,
				account = account,
				Page = 1u,
				handle = UserGeneratedContent.Client.CreateQueryUserRequest(account, listType, matchingType, sortOrder, creatorApp, consumerApp, 1u)
			};
		}

		public static UgcQuery Get(UserData user, EUserUGCList listType, EUGCMatchingUGCType matchingType, EUserUGCListSortOrder sortOrder, AppId_t creatorApp, AppId_t consumerApp)
		{
			return new UgcQuery
			{
				matchedRecordCount = 0u,
				pageCount = 1u,
				isAllQuery = false,
				isUserQuery = true,
				listType = listType,
				sortOrder = sortOrder,
				matchingType = matchingType,
				creatorApp = creatorApp,
				consumerApp = consumerApp,
				account = user.AccountId,
				Page = 1u,
				handle = UserGeneratedContent.Client.CreateQueryUserRequest(user.AccountId, listType, matchingType, sortOrder, creatorApp, consumerApp, 1u)
			};
		}

		public static UgcQuery GetMyPublished()
		{
			UgcQuery ugcQuery = Get(UserData.Me, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderDesc, AppData.Me, AppData.Me);
			ugcQuery.SetReturnLongDescription(longDescription: true);
			ugcQuery.SetReturnMetadata(metadata: true);
			return ugcQuery;
		}

		public static UgcQuery GetMyPublished(AppData creatorApp, AppData consumerApp)
		{
			UgcQuery ugcQuery = Get(UserData.Me, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderDesc, creatorApp, consumerApp);
			ugcQuery.SetReturnLongDescription(longDescription: true);
			ugcQuery.SetReturnMetadata(metadata: true);
			return ugcQuery;
		}

		public static UgcQuery GetSubscribed()
		{
			return Get(UserGeneratedContent.Client.GetSubscribedItems());
		}

		public static UgcQuery GetSubscribed(bool withLongDescription, bool withMetadata, bool withKeyValueTags, bool withAdditionalPreviews, uint withPlayTimeStatsInDays)
		{
			UgcQuery ugcQuery = Get(UserGeneratedContent.Client.GetSubscribedItems());
			ugcQuery.SetReturnLongDescription(withLongDescription);
			ugcQuery.SetReturnMetadata(withMetadata);
			ugcQuery.SetReturnKeyValueTags(withKeyValueTags);
			if (withPlayTimeStatsInDays != 0)
			{
				ugcQuery.SetReturnPlaytimeStats(withPlayTimeStatsInDays);
			}
			ugcQuery.SetReturnAdditionalPreviews(withAdditionalPreviews);
			return ugcQuery;
		}

		public static UgcQuery GetPlayed()
		{
			UgcQuery ugcQuery = Get(UserData.Me, EUserUGCList.k_EUserUGCList_UsedOrPlayed, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_LastUpdatedDesc, AppData.Me, AppData.Me);
			ugcQuery.SetReturnLongDescription(longDescription: true);
			ugcQuery.SetReturnMetadata(metadata: true);
			return ugcQuery;
		}

		public static UgcQuery GetPlayed(AppData creatorApp, AppData consumerApp)
		{
			UgcQuery ugcQuery = Get(UserData.Me, EUserUGCList.k_EUserUGCList_UsedOrPlayed, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items_ReadyToUse, EUserUGCListSortOrder.k_EUserUGCListSortOrder_LastUpdatedDesc, creatorApp, consumerApp);
			ugcQuery.SetReturnLongDescription(longDescription: true);
			ugcQuery.SetReturnMetadata(metadata: true);
			return ugcQuery;
		}

		public bool AddExcludedTag(string tagName)
		{
			return UserGeneratedContent.Client.AddExcludedTag(handle, tagName);
		}

		public bool AddRequiredKeyValueTag(string key, string value)
		{
			return UserGeneratedContent.Client.AddRequiredKeyValueTag(handle, key, value);
		}

		public bool AddRequiredTag(string tagName)
		{
			return UserGeneratedContent.Client.AddRequiredTag(handle, tagName);
		}

		public bool SetAllowCachedResponse(uint maxAgeSeconds)
		{
			return UserGeneratedContent.Client.SetAllowCachedResponse(handle, maxAgeSeconds);
		}

		public bool SetCloudFileNameFilter(string fileName)
		{
			return UserGeneratedContent.Client.SetCloudFileNameFilter(handle, fileName);
		}

		public bool SetLanguage(string language)
		{
			return UserGeneratedContent.Client.SetLanguage(handle, language);
		}

		public bool SetMatchAnyTag(bool anyTag)
		{
			return UserGeneratedContent.Client.SetMatchAnyTag(handle, anyTag);
		}

		public bool SetRankedByTrendDays(uint days)
		{
			return UserGeneratedContent.Client.SetRankedByTrendDays(handle, days);
		}

		public bool SetReturnAdditionalPreviews(bool additionalPreviews)
		{
			return UserGeneratedContent.Client.SetReturnAdditionalPreviews(handle, additionalPreviews);
		}

		public bool SetReturnChildren(bool returnChildren)
		{
			return UserGeneratedContent.Client.SetReturnChildren(handle, returnChildren);
		}

		public bool SetReturnKeyValueTags(bool tags)
		{
			return UserGeneratedContent.Client.SetReturnKeyValueTags(handle, tags);
		}

		public bool SetReturnLongDescription(bool longDescription)
		{
			return UserGeneratedContent.Client.SetReturnLongDescription(handle, longDescription);
		}

		public bool SetReturnMetadata(bool metadata)
		{
			return UserGeneratedContent.Client.SetReturnMetadata(handle, metadata);
		}

		public bool SetReturnOnlyIDs(bool onlyIds)
		{
			return UserGeneratedContent.Client.SetReturnOnlyIDs(handle, onlyIds);
		}

		public bool SetReturnPlaytimeStats(uint days)
		{
			return UserGeneratedContent.Client.SetReturnPlaytimeStats(handle, days);
		}

		public bool SetReturnTotalOnly(bool totalOnly)
		{
			return UserGeneratedContent.Client.SetReturnTotalOnly(handle, totalOnly);
		}

		public bool SetSearchText(string text)
		{
			return UserGeneratedContent.Client.SetSearchText(handle, text);
		}

		public bool SetNextPage()
		{
			return SetPage((uint)Mathf.Clamp((int)(_Page + 1), 1f, pageCount));
		}

		public bool SetPreviousPage()
		{
			return SetPage((uint)Mathf.Clamp((int)(_Page - 1), 1f, pageCount));
		}

		public bool SetPage(uint page)
		{
			_Page = ((page == 0) ? 1u : page);
			if (isAllQuery)
			{
				ReleaseHandle();
				handle = UserGeneratedContent.Client.CreateQueryAllRequest(queryType, matchingType, creatorApp, consumerApp, Page);
				matchedRecordCount = 0u;
				return true;
			}
			if (isUserQuery)
			{
				ReleaseHandle();
				handle = UserGeneratedContent.Client.CreateQueryUserRequest(account, listType, matchingType, sortOrder, creatorApp, consumerApp, Page);
				matchedRecordCount = 0u;
				return true;
			}
			Debug.LogError("Pages are not supported by detail queries e.g. searching for specific file Ids");
			return false;
		}

		public bool Execute(UnityAction<UgcQuery> callback)
		{
			if (handle == UGCQueryHandle_t.Invalid)
			{
				Debug.LogError("Invalid handle, you must call CreateAll");
				return false;
			}
			ResultsList.Clear();
			this.callback = callback;
			UserGeneratedContent.Client.SendQueryUGCRequest(handle, HandleQueryCompleted);
			return true;
		}

		private void HandleQueryCompleted(SteamUGCQueryCompleted_t param, bool bIOFailure)
		{
			if (!bIOFailure)
			{
				if (param.m_eResult == EResult.k_EResultOK)
				{
					matchedRecordCount = param.m_unTotalMatchingResults;
					pageCount = (uint)Mathf.Clamp((int)matchedRecordCount / 50, 1, int.MaxValue);
					if (pageCount * 50 < matchedRecordCount)
					{
						pageCount++;
					}
					for (int i = 0; i < param.m_unNumResultsReturned; i++)
					{
						UserGeneratedContent.Client.GetQueryResult(param.m_handle, (uint)i, out var details);
						WorkshopItem workshopItem = new WorkshopItem(details);
						UserGeneratedContent.Client.GetQueryMetadata(param.m_handle, (uint)i, out workshopItem.metadata, 5000u);
						workshopItem.metadata?.Trim();
						uint queryNumKeyValueTags = UserGeneratedContent.Client.GetQueryNumKeyValueTags(param.m_handle, (uint)i);
						workshopItem.keyValueTags = new StringKeyValuePair[queryNumKeyValueTags];
						for (int j = 0; j < queryNumKeyValueTags; j++)
						{
							UserGeneratedContent.Client.GetQueryKeyValueTag(param.m_handle, (uint)i, (uint)j, out var key, 255u, out var value, 255u);
							workshopItem.keyValueTags[j].key = key?.Trim();
							workshopItem.keyValueTags[j].value = value?.Trim();
						}
						ResultsList.Add(workshopItem);
					}
					ReleaseHandle();
					if (callback != null)
					{
						callback(this);
					}
				}
				else
				{
					Debug.LogError("HeathenWorkitemQuery|HandleQueryCompleted Unexpected results, state = " + param.m_eResult);
				}
			}
			else
			{
				Debug.LogError("HeathenWorkitemQuery|HandleQueryCompleted failed.");
			}
		}

		public void ReleaseHandle()
		{
			if (handle != UGCQueryHandle_t.Invalid)
			{
				UserGeneratedContent.Client.ReleaseQueryRequest(handle);
				handle = UGCQueryHandle_t.Invalid;
			}
		}

		public void Dispose()
		{
			try
			{
				ReleaseHandle();
			}
			catch
			{
			}
		}
	}
}
