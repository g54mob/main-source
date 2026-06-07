#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.FeatureFlags.Validators;
using Data.Variables;
using Events.Generic;
using Events.Integrations;
using GameAnalyticsSDK;
using Integrations.Interfaces;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Integrations
{
	public class IntegrationManager : MonoBehaviour
	{
		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		[SerializeField]
		private TitleDataAvailableEvent _titleDataAvailable;

		[SerializeField]
		private SupportersEditionActivationModeSelectorSO _supportersEditionActivationModeSelector;

		[SerializeField]
		private StringVariableSO _supportersEditionAppId;

		[SerializeField]
		private EnableSteamSocialFeaturesValidator _steamSocialFeaturesValidator;

		[SerializeField]
		private EnableDiscordSocialFeaturesValidator _discordSocialFeaturesValidator;

		[SerializeField]
		private float _loginRetryDelay = 5f;

		[SerializeField]
		private int _loginRetryAttemptsLimit = 5;

		[SerializeField]
		private ZenModeVariableSO _zenModeVariableSO;

		[SerializeField]
		private BoolEvent _levelFinishedLoadingZenModeEvent;

		[SerializeField]
		private RankConfigSO _rankConfigSO;

		[SerializeField]
		private BoolVariableSO _hasDeluxeEditionSO;

		private int _loginRetryAttempts;

		private IPlatformHandler _platform;

		private ICloudServiceHandler _cloudService;

		private readonly ICollection<ISocialHandler> _socialHandlers = new List<ISocialHandler>();

		private IDownloadHandler _downloadHandler;

		public Action OnSocialPlatformsReady { get; set; }

		public IPlatformHandler Platform => _platform;

		public ICloudServiceHandler CloudService => _cloudService;

		private void Awake()
		{
			if (_integrationManagerLocator.Integration != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			_integrationManagerLocator.SetIntegrationManager(this);
			SetupPlatformHandler();
			SetupCloudServiceHandler();
			SetupSocialHandlers();
			SetupDownloadHandler();
			IPlatformHandler platform = _platform;
			platform.OnPlatformReady = (Action)Delegate.Combine(platform.OnPlatformReady, new Action(OnServiceReady));
			ICloudServiceHandler cloudService = _cloudService;
			cloudService.OnCloudServiceReady = (Action)Delegate.Combine(cloudService.OnCloudServiceReady, new Action(OnServiceReady));
			ICloudServiceHandler cloudService2 = _cloudService;
			cloudService2.OnCloudServiceDataReceived = (Action<bool>)Delegate.Combine(cloudService2.OnCloudServiceDataReceived, new Action<bool>(OnCloudServiceDataReceived));
			ICloudServiceHandler cloudService3 = _cloudService;
			cloudService3.OnCloudServiceLoginFailed = (Action)Delegate.Combine(cloudService3.OnCloudServiceLoginFailed, new Action(OnCloudServiceLoginFailed));
			base.transform.SetParent(null);
			UnityEngine.Object.DontDestroyOnLoad(this);
			_levelFinishedLoadingZenModeEvent.Register(HandleFinishedLoadingLevelEvent);
		}

		private void SetupPlatformHandler()
		{
			_platform = base.gameObject.AddComponent<SteamHandler>();
			_platform.SetSupportersEditionAppId(_supportersEditionAppId.Value);
		}

		private void SetupCloudServiceHandler()
		{
			_cloudService = base.gameObject.AddComponent<PlayFabHandler>();
			_cloudService.SetTitleDataAvailableEvent(_titleDataAvailable);
			_cloudService.SetServiceConnector(SetupPlatformCloudServiceConnector());
		}

		private void SetupSocialHandlers()
		{
			if (_discordSocialFeaturesValidator.IsEnabledFeatureFlag())
			{
				DiscordHandler discordHandler = base.gameObject.AddComponent<DiscordHandler>();
				discordHandler.OnSocialReady = (Action)Delegate.Combine(discordHandler.OnSocialReady, new Action(OnSocialPlatformReady));
				_socialHandlers.Add(discordHandler);
			}
			if (_steamSocialFeaturesValidator.IsEnabledFeatureFlag() && _platform is ISocialHandler socialHandler)
			{
				socialHandler.OnSocialReady = (Action)Delegate.Combine(socialHandler.OnSocialReady, new Action(OnSocialPlatformReady));
				_socialHandlers.Add(socialHandler);
			}
		}

		private void OnSocialPlatformReady()
		{
			if (_socialHandlers.All((ISocialHandler s) => s.Ready))
			{
				OnSocialPlatformsReady?.Invoke();
			}
		}

		private void SetupDownloadHandler()
		{
			_downloadHandler = base.gameObject.AddComponent<DownloadHandler>();
		}

		private IPlatformCloudServiceConnector SetupPlatformCloudServiceConnector()
		{
			return new SteamPlayFabConnector(_platform);
		}

		private void OnDestroy()
		{
			ClearExistingCredentials();
			if (_platform != null)
			{
				IPlatformHandler platform = _platform;
				platform.OnPlatformReady = (Action)Delegate.Remove(platform.OnPlatformReady, new Action(OnServiceReady));
			}
			if (_cloudService != null)
			{
				ICloudServiceHandler cloudService = _cloudService;
				cloudService.OnCloudServiceReady = (Action)Delegate.Remove(cloudService.OnCloudServiceReady, new Action(OnServiceReady));
				ICloudServiceHandler cloudService2 = _cloudService;
				cloudService2.OnCloudServiceDataReceived = (Action<bool>)Delegate.Remove(cloudService2.OnCloudServiceDataReceived, new Action<bool>(OnCloudServiceDataReceived));
				ICloudServiceHandler cloudService3 = _cloudService;
				cloudService3.OnCloudServiceLoginFailed = (Action)Delegate.Remove(cloudService3.OnCloudServiceLoginFailed, new Action(OnCloudServiceLoginFailed));
			}
			_levelFinishedLoadingZenModeEvent?.UnRegister(HandleFinishedLoadingLevelEvent);
		}

		private void OnCloudServiceLoginFailed()
		{
			ClearExistingCredentials();
			if (_loginRetryAttempts < _loginRetryAttemptsLimit)
			{
				this.Log($"Login sequence failed {_loginRetryAttempts + 1} times for player " + $"{_cloudService.GetCloudServiceUserId()}. Retrying in {_loginRetryDelay} seconds", "OnCloudServiceLoginFailed", 155);
				Invoke("LoginToCloudService", _loginRetryDelay);
				_loginRetryAttempts++;
			}
			else
			{
				this.Log($"Login sequence failed more than {_loginRetryAttemptsLimit} times for player " + _cloudService.GetCloudServiceUserId() + ". Stopping login sequence", "OnCloudServiceLoginFailed", 162);
			}
		}

		private void LoginToCloudService()
		{
			_cloudService.Login();
		}

		private void OnServiceReady()
		{
			if (_platform.Ready && _cloudService.Ready)
			{
				_cloudService.Login();
			}
		}

		private void OnCloudServiceDataReceived(bool cloudServiceDataCacheUpdated)
		{
			if (!cloudServiceDataCacheUpdated)
			{
				return;
			}
			foreach (DownloadQueue downloadQueue in _cloudService.GetDownloadQueues())
			{
				_downloadHandler.ProcessDownloadQueue(downloadQueue);
			}
		}

		public Dictionary<string, string> GatherFeedbackMetaData()
		{
			this.Log("Using gameAnalyticsUserId " + GameAnalytics.GetUserId(), "GatherFeedbackMetaData", 197);
			return new Dictionary<string, string>
			{
				{
					"versionNumber",
					Application.version
				},
				{
					"platformUserId",
					Platform.GetUserId()
				},
				{
					"platformUserName",
					Platform.GetUserName()
				},
				{
					"cloudServiceUserId",
					CloudService.GetCloudServiceUserId()
				},
				{
					"deviceModel",
					SystemInfo.deviceModel
				},
				{
					"processorType",
					SystemInfo.processorType
				},
				{
					"systemMemorySize",
					SystemInfo.systemMemorySize.ToString()
				},
				{
					"graphicsDeviceName",
					SystemInfo.graphicsDeviceName
				},
				{
					"gameAnalyticsUserId",
					GameAnalytics.GetUserId()
				}
			};
		}

		public void UpdateSocialPresenceBasedOnRank(int rank)
		{
			foreach (ISocialHandler socialHandler in _socialHandlers)
			{
				socialHandler.UpdateSocialPresenceBasedOnRank(rank);
			}
		}

		private void UpdateSocialPresenceInZenMode()
		{
			foreach (ISocialHandler socialHandler in _socialHandlers)
			{
				socialHandler.UpdateSocialPresenceCreativeMode();
			}
		}

		public void UpdateSocialPresenceIdleInMainMenu()
		{
			foreach (ISocialHandler socialHandler in _socialHandlers)
			{
				socialHandler.UpdateSocialPresenceMainMenu();
			}
		}

		public void ClearSocialPresence()
		{
			foreach (ISocialHandler socialHandler in _socialHandlers)
			{
				socialHandler.ClearPresence();
			}
		}

		private void HandleFinishedLoadingLevelEvent(bool isZenMode)
		{
			if (isZenMode || _zenModeVariableSO.Value)
			{
				UpdateSocialPresenceInZenMode();
			}
			else
			{
				UpdateSocialPresenceBasedOnRank(_rankConfigSO.GetCurrentRank());
			}
		}

		public bool IsSupportersEdition()
		{
			bool flag = _supportersEditionActivationModeSelector.SupportersEditionActivationMode switch
			{
				SupportersEditionActivationMode.ForceOn => true, 
				SupportersEditionActivationMode.ForceOff => false, 
				SupportersEditionActivationMode.Platform => _platform.HasSupportersEdition(), 
				_ => false, 
			};
			_hasDeluxeEditionSO.SetValue(flag);
			return flag;
		}

		private void ClearExistingCredentials()
		{
			this.Log("ClearExistingCredentials", "ClearExistingCredentials", 274);
			_cloudService?.ClearCredentials();
			_platform?.CancelAuthToken();
		}
	}
}
