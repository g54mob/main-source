#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.Linq;
using Data.Analytics;
using Data.FeatureFlags;
using Data.Variables;
using Events;
using Events.Analytics;
using GameAnalyticsSDK;
using UnityEngine;

namespace Utils.Analytics
{
	public class GameAnalyticsHandler : MonoBehaviour
	{
		[SerializeField]
		private AnalyticsSettings _analyticsSettings;

		[SerializeField]
		protected FeatureFlags _featureFlags;

		[Header("Analytics Events")]
		[SerializeField]
		private AnalyticsDesignEvent _analyticsDesignEvent;

		[SerializeField]
		private AnalyticsResourceEvent _analyticsResourceEvent;

		[SerializeField]
		private AnalyticsProgressionEvent _analyticsProgressionEvent;

		[SerializeField]
		private AnalyticsProgressionTimedEvent _analyticsProgressionTimedEvent;

		[SerializeField]
		private AnalyticsQueueEvent _analyticsQueueEvent;

		[SerializeField]
		private BaseEvent _clearQueueEvent;

		[SerializeField]
		private BaseEvent _finishedSavingEvent;

		[SerializeField]
		private DataCollectionVariableSO _dataCollectionOptOut;

		private bool _initialized;

		private static GameAnalyticsHandler _instance;

		private List<(string, float)> _queue = new List<(string, float)>();

		private void Awake()
		{
			if (_instance != null)
			{
				this.Log("Destroying Duplicate Handler instance", "Awake", 40);
				UnityEngine.Object.Destroy(this);
				return;
			}
			_instance = this;
			if (GameAnalytics.SettingsGA == null)
			{
				this.LogError("SettingsGA is null", "Awake", 49);
			}
			SetEnvironment();
			SetVersion();
		}

		private void Start()
		{
			if (!GameAnalytics.Initialized)
			{
				GameAnalytics.onInitialize += OnGameAnalyticsInitialized;
				GameAnalytics.Initialize();
			}
			else
			{
				Initialize();
			}
		}

		private void OnGameAnalyticsInitialized(object sender, bool e)
		{
			Initialize();
		}

		private void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				GameAnalytics.onInitialize -= OnGameAnalyticsInitialized;
				_analyticsDesignEvent.Register(OnDesignEvent);
				_analyticsResourceEvent.Register(OnResourceEvent);
				_analyticsProgressionEvent.Register(OnProgressionEvent);
				_analyticsProgressionTimedEvent.Register(OnProgressionTimedEvent);
				_analyticsQueueEvent.Register(OnQueueEvent);
				_clearQueueEvent.Register(OnClearQueueEvent);
				_finishedSavingEvent.Register(OnSendQueueEvent);
				this.Log("UserID: " + GameAnalytics.GetUserId(), "Initialize", 93);
				Application.logMessageReceived += HandleLogMessage;
			}
		}

		private void SetEnvironment()
		{
			if (_featureFlags.Current.UseTestGATitle)
			{
				this.Log("Using test config", "SetEnvironment", 101);
				GameAnalytics.SettingsGA.UpdateGameKey(0, _analyticsSettings.GameAnalyticsTestGameKey);
				GameAnalytics.SettingsGA.UpdateSecretKey(0, _analyticsSettings.GameAnalyticsTestSecretKey);
			}
			else
			{
				this.Log("Using DEMO config", "SetEnvironment", 108);
				GameAnalytics.SettingsGA.UpdateGameKey(0, _analyticsSettings.GameAnalyticsDemoGameKey);
				GameAnalytics.SettingsGA.UpdateSecretKey(0, _analyticsSettings.GameAnalyticsDemoSecretKey);
			}
		}

		private void SetVersion()
		{
			GameAnalytics.SetBuildAllPlatforms(string.Join(".", (Application.version?.Split("+").FirstOrDefault())?.Split(".").Take(3) ?? Array.Empty<string>()).Trim());
		}

		private void OnDestroy()
		{
			_analyticsDesignEvent.UnRegister(OnDesignEvent);
			_analyticsResourceEvent.UnRegister(OnResourceEvent);
			_analyticsProgressionEvent.UnRegister(OnProgressionEvent);
			_analyticsProgressionTimedEvent.UnRegister(OnProgressionTimedEvent);
			_analyticsQueueEvent.UnRegister(OnQueueEvent);
			_clearQueueEvent.UnRegister(OnClearQueueEvent);
			_finishedSavingEvent.UnRegister(OnSendQueueEvent);
			GameAnalytics.onInitialize -= OnGameAnalyticsInitialized;
			Application.logMessageReceived -= HandleLogMessage;
		}

		private void HandleLogMessage(string condition, string stacktrace, LogType type)
		{
			switch (type)
			{
			case LogType.Error:
				OnErrorEvent(GAErrorSeverity.Error, condition + "\n" + stacktrace);
				break;
			case LogType.Exception:
				OnErrorEvent(GAErrorSeverity.Critical, condition + "\n" + stacktrace);
				break;
			case LogType.Assert:
			case LogType.Warning:
			case LogType.Log:
				break;
			}
		}

		private void OnErrorEvent(GAErrorSeverity severity, string message)
		{
			if (!_dataCollectionOptOut.Value)
			{
				GameAnalytics.NewErrorEvent(severity, message);
			}
		}

		private void OnProgressionTimedEvent((GAProgressionStatus status, string tutorial, string quest, string subQuest, int time) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				this.Log($"Timed Progression Event: {arg.status}, {arg.tutorial}, {arg.quest}, {arg.subQuest}, {arg.time}", "OnProgressionTimedEvent", 186);
				GameAnalytics.NewProgressionEvent(arg.status, arg.tutorial, arg.quest, arg.subQuest, arg.time);
			}
		}

		private void OnProgressionEvent((GAProgressionStatus status, string tutorial, string quest, string subQuest) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				GameAnalytics.NewProgressionEvent(arg.status, arg.tutorial, arg.quest, arg.subQuest);
			}
		}

		private void OnDesignEvent((string key, float value) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				GameAnalytics.NewDesignEvent(arg.key, arg.value);
			}
		}

		private void OnResourceEvent((GAResourceFlowType flowType, string itemType, string itemId, float amount, string resourceCurrency) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				GameAnalytics.NewResourceEvent(arg.flowType, arg.resourceCurrency, arg.amount, arg.itemType, arg.itemId);
			}
		}

		private void OnQueueEvent(List<(string, float)> queuedData)
		{
			_queue.AddRange(queuedData);
		}

		private void OnSendQueueEvent()
		{
			if (!_dataCollectionOptOut.Value)
			{
				for (int i = 0; i < _queue.Count; i++)
				{
					GameAnalytics.NewDesignEvent(_queue[i].Item1, _queue[i].Item2);
				}
				_queue.Clear();
			}
		}

		private void OnClearQueueEvent()
		{
			_queue.Clear();
		}
	}
}
