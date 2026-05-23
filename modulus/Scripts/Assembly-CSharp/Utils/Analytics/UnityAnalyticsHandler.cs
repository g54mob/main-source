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
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

namespace Utils.Analytics
{
	public class UnityAnalyticsHandler : MonoBehaviour
	{
		[SerializeField]
		private AnalyticsSettings _analyticsSettings;

		[SerializeField]
		private FeatureFlags _featureFlags;

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

		[SerializeField]
		private AnalyticsSetDimensionEvent _analyticsSetDimensionEvent;

		private bool _initialized;

		private static UnityAnalyticsHandler _instance;

		private readonly List<(string key, float value)> _queue = new List<(string, float)>();

		private readonly Dictionary<string, object> _dimensions = new Dictionary<string, object>();

		private readonly string[] _designParamNames = new string[4] { "category", "subcategory", "action", "label" };

		private readonly string[] _balanceParamNames = new string[4] { "type", "interval", "action", "label" };

		private void Awake()
		{
			if (_instance != null)
			{
				this.Log("Destroying Duplicate Handler instance", "Awake", 50);
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				_instance = this;
				base.transform.SetParent(null);
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		private async void Start()
		{
			if (!(this == null))
			{
				string environmentName = GetEnvironmentName();
				InitializationOptions options = new InitializationOptions().SetEnvironmentName(environmentName);
				this.Log("Unity Analytics initializing with environment: " + environmentName, "Start", 69);
				await UnityServices.InitializeAsync(options);
				Initialize();
				SetVersion();
			}
		}

		private void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				AnalyticsService.Instance.StartDataCollection();
				_analyticsDesignEvent.Register(OnDesignEvent);
				_analyticsResourceEvent.Register(OnResourceEvent);
				_analyticsProgressionEvent.Register(OnProgressionEvent);
				_analyticsProgressionTimedEvent.Register(OnProgressionTimedEvent);
				_analyticsQueueEvent.Register(OnQueueEvent);
				_clearQueueEvent.Register(OnClearQueueEvent);
				_finishedSavingEvent.Register(OnSendQueueEvent);
				_analyticsSetDimensionEvent.Register(OnSetDimensionEvent);
				Application.logMessageReceived += HandleLogMessage;
			}
		}

		private string GetEnvironmentName()
		{
			if (_featureFlags.Current.UseTestGATitle)
			{
				return _analyticsSettings.UnityAnalyticsTestEnvironment;
			}
			return _analyticsSettings.UnityAnalyticsDemoEnvironment;
		}

		private void SetVersion()
		{
			string value = string.Join(".", (Application.version?.Split("+").FirstOrDefault())?.Split(".").Take(3) ?? Array.Empty<string>()).Trim();
			_dimensions["buildVersion"] = value;
		}

		private void OnDestroy()
		{
			if (_instance == this)
			{
				_instance = null;
			}
			if (_initialized)
			{
				_analyticsDesignEvent.UnRegister(OnDesignEvent);
				_analyticsResourceEvent.UnRegister(OnResourceEvent);
				_analyticsProgressionEvent.UnRegister(OnProgressionEvent);
				_analyticsProgressionTimedEvent.UnRegister(OnProgressionTimedEvent);
				_analyticsQueueEvent.UnRegister(OnQueueEvent);
				_clearQueueEvent.UnRegister(OnClearQueueEvent);
				_finishedSavingEvent.UnRegister(OnSendQueueEvent);
				_analyticsSetDimensionEvent.UnRegister(OnSetDimensionEvent);
				Application.logMessageReceived -= HandleLogMessage;
			}
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
				OnErrorEvent("Assert", condition + "\n" + stacktrace);
				break;
			case LogType.Warning:
			case LogType.Log:
				break;
			}
		}

		private void OnSetDimensionEvent((string key, string value) arg)
		{
			_dimensions[arg.key] = arg.value;
		}

		private void OnErrorEvent(string severity, string message)
		{
			if (!_dataCollectionOptOut.Value)
			{
				CustomEvent customEvent = CreateEvent("mod-error");
				customEvent.Add(severity, message);
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
		}

		private void OnErrorEvent(GAErrorSeverity severity, string message)
		{
			OnErrorEvent(severity.ToString(), message);
		}

		private CustomEvent CreateEvent(string eventName)
		{
			CustomEvent customEvent = new CustomEvent(eventName);
			foreach (KeyValuePair<string, object> dimension in _dimensions)
			{
				customEvent.Add(dimension.Key, dimension.Value);
			}
			return customEvent;
		}

		private void OnProgressionEvent((GAProgressionStatus status, string quest, string subQuest, string action) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				CustomEvent customEvent = CreateEvent("mod-progression");
				customEvent.Add("status", arg.status.ToString());
				customEvent.Add("quest", arg.quest);
				customEvent.Add("subQuest", arg.subQuest);
				if (!string.IsNullOrEmpty(arg.action) && arg.action != "-")
				{
					customEvent.Add("action", arg.action);
				}
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
		}

		private void OnProgressionTimedEvent((GAProgressionStatus status, string quest, string subQuest, string action, int time) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				CustomEvent customEvent = CreateEvent("mod-progression-timed");
				customEvent.Add("status", arg.status.ToString());
				customEvent.Add("quest", arg.quest);
				customEvent.Add("subQuest", arg.subQuest);
				if (!string.IsNullOrEmpty(arg.action) && arg.action != "-")
				{
					customEvent.Add("action", arg.action);
				}
				customEvent.Add("time", arg.time);
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
		}

		private void OnDesignEvent((string key, float value) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				CustomEvent customEvent = CreateEvent("mod-design");
				AddEventParams(customEvent, arg.key, _designParamNames);
				customEvent.Add("value", arg.value);
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
		}

		private void OnResourceEvent((GAResourceFlowType flowType, string itemType, string itemId, float amount, string resourceCurrency) arg)
		{
			if (!_dataCollectionOptOut.Value)
			{
				CustomEvent customEvent = CreateEvent("mod-resource");
				customEvent.Add("flowType", arg.flowType.ToString());
				customEvent.Add("itemType", arg.itemType);
				customEvent.Add("itemId", arg.itemId);
				customEvent.Add("amount", arg.amount);
				customEvent.Add("currency", arg.resourceCurrency);
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
		}

		private void OnQueueEvent(List<(string, float)> queuedData)
		{
			_queue.AddRange(queuedData);
		}

		private void OnSendQueueEvent()
		{
			if (_dataCollectionOptOut.Value)
			{
				return;
			}
			foreach (var item3 in _queue)
			{
				string item = item3.key;
				float item2 = item3.value;
				CustomEvent customEvent = CreateEvent("mod-balance");
				AddEventParams(customEvent, item, _balanceParamNames);
				customEvent.Add("value", item2);
				AnalyticsService.Instance.RecordEvent(customEvent);
			}
			_queue.Clear();
		}

		private void OnClearQueueEvent()
		{
			_queue.Clear();
		}

		private void AddEventParams(CustomEvent customEvent, string key, string[] paramNames)
		{
			string[] array = key.Split(':');
			for (int i = 0; i < array.Length && i < paramNames.Length; i++)
			{
				customEvent.Add(paramNames[i], array[i]);
			}
		}
	}
}
