#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using Events.Integrations;
using Integrations.Data;
using Integrations.Interfaces;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Utils;

namespace Integrations
{
	public class PlayFabHandler : MonoBehaviour, ICloudServiceHandler
	{
		private IPlatformCloudServiceConnector _serviceConnector;

		private string _cloudServiceUserId;

		private TitleData _titleData;

		private TitleDataAvailableEvent _titleDataAvailable;

		public bool Ready { get; set; }

		public bool LoggedIn { get; set; }

		public Action OnCloudServiceReady { get; set; }

		public Action OnCloudServiceLoggedIn { get; set; }

		public Action OnCloudServiceLoginFailed { get; set; }

		public Action<bool> OnCloudServiceDataReceived { get; set; }

		public Action OnScreenShotInfoAvailable { get; set; }

		private void Awake()
		{
			this.Log("Using DEMO config", "Awake", 41);
			PlayFabSettings.TitleId = "F6CF4";
		}

		private void Start()
		{
			GetDataCache();
			Ready = true;
			OnCloudServiceReady?.Invoke();
		}

		private void OnDestroy()
		{
			IPlatformCloudServiceConnector serviceConnector = _serviceConnector;
			serviceConnector.OnLoginSequenceComplete = (Action<bool, string>)Delegate.Remove(serviceConnector.OnLoginSequenceComplete, new Action<bool, string>(OnLoginSequenceComplete));
		}

		public string GetCloudServiceUserId()
		{
			if (LoggedIn)
			{
				return _cloudServiceUserId;
			}
			return null;
		}

		public void ClearCredentials()
		{
			PlayFabClientAPI.ForgetAllCredentials();
		}

		public void SetServiceConnector(IPlatformCloudServiceConnector serviceConnector)
		{
			_serviceConnector = serviceConnector;
			IPlatformCloudServiceConnector serviceConnector2 = _serviceConnector;
			serviceConnector2.OnLoginSequenceComplete = (Action<bool, string>)Delegate.Combine(serviceConnector2.OnLoginSequenceComplete, new Action<bool, string>(OnLoginSequenceComplete));
		}

		public void SetTitleDataAvailableEvent(TitleDataAvailableEvent titleDataAvailable)
		{
			_titleDataAvailable = titleDataAvailable;
		}

		public void Login()
		{
			this.Log("Attempting login sequence ...", "Login", 87);
			_serviceConnector.AttemptLogin();
		}

		private void OnLoginSequenceComplete(bool success, string cloudServiceUserId)
		{
			if (success)
			{
				this.Log("Completed login sequence successfully for player " + cloudServiceUserId, "OnLoginSequenceComplete", 95);
				LoggedIn = true;
				_cloudServiceUserId = cloudServiceUserId;
				OnCloudServiceLoggedIn?.Invoke();
				RenewDataCache();
			}
			else
			{
				OnCloudServiceLoginFailed?.Invoke();
			}
		}

		private void GetDataCache()
		{
			if (StorageHandler.TryGetCachedData<TitleData>(GetCloudServiceUserId(), "titledata", out var data))
			{
				_titleData = data;
				_titleData?.ScreenshotContestInfo?.GetCachedAssets();
				DownloadableAsset downloadableAsset = _titleData?.ScreenshotContestInfo?.ImageDownloadableAsset;
				if (downloadableAsset != null && downloadableAsset.Available)
				{
					_titleDataAvailable?.Fire(_titleData);
				}
			}
		}

		private void RenewDataCache()
		{
			this.Log("Retrieving player combined info for player " + GetCloudServiceUserId(), "RenewDataCache", 124);
			GetPlayerCombinedInfoRequestParams infoRequestParameters = new GetPlayerCombinedInfoRequestParams
			{
				GetTitleData = true
			};
			PlayFabClientAPI.GetPlayerCombinedInfo(new GetPlayerCombinedInfoRequest
			{
				PlayFabId = GetCloudServiceUserId(),
				InfoRequestParameters = infoRequestParameters
			}, OnGetPlayerCombinedInfoSuccess, OnGetPlayerCombinedInfoError);
		}

		private void OnGetPlayerCombinedInfoSuccess(GetPlayerCombinedInfoResult result)
		{
			if (result != null)
			{
				this.Log("Retrieved player combined info for player " + result.PlayFabId, "OnGetPlayerCombinedInfoSuccess", 146);
				bool flag;
				if (_titleData == null)
				{
					_titleData = new TitleData(result.InfoResultPayload.TitleData);
					flag = true;
				}
				else
				{
					flag = _titleData.TryUpdate(result.InfoResultPayload.TitleData);
				}
				if (flag)
				{
					StorageHandler.StoreCachedData(GetCloudServiceUserId(), "titledata", _titleData);
				}
				else
				{
					_titleDataAvailable?.Fire(_titleData);
				}
				OnCloudServiceDataReceived?.Invoke(flag);
			}
		}

		public List<DownloadQueue> GetDownloadQueues()
		{
			return new List<DownloadQueue>
			{
				new DownloadQueue(_titleData.GetInvalidatedCachedAssetsList(), delegate
				{
					_titleDataAvailable?.Fire(_titleData);
				})
			};
		}

		public TitleData GetTitleData()
		{
			this.Log("Getting info from title data cache with key ScreenshotContestInfo", "GetTitleData", 183);
			return _titleData;
		}

		private void OnGetPlayerCombinedInfoError(PlayFabError error)
		{
			this.Log($"Produced error with code {error.Error} when retrieving player combined info for player " + GetCloudServiceUserId() + ": " + error.ErrorMessage, "OnGetPlayerCombinedInfoError", 189);
		}
	}
}
