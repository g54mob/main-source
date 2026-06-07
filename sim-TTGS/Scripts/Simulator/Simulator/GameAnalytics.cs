using System;
using System.Collections.Generic;
using Dhs5.Utility.Debuggers;
using GameAnalyticsSDK;

namespace Simulator
{
	public static class GameAnalytics
	{
		public struct DesignEvent
		{
			public readonly string eventName;

			public readonly float eventValue;

			public readonly IDictionary<string, object> customFields;

			public readonly bool mergeFields;

			public DesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields, bool mergeFields)
			{
				this.eventName = eventName;
				this.eventValue = eventValue;
				this.customFields = customFields;
				this.mergeFields = mergeFields;
			}
		}

		private static readonly Dictionary<string, DesignEvent> m_designEvents = new Dictionary<string, DesignEvent>(StringComparer.OrdinalIgnoreCase);

		public static void Initialize()
		{
			GameAnalyticsSDK.GameAnalytics.Initialize();
		}

		public static void NewBusinessEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			GameAnalyticsSDK.GameAnalytics.NewBusinessEvent(currency, amount, itemType, itemId, cartType, customFields, mergeFields);
		}

		public static void NewDesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields = null, bool mergeFields = false, bool sendOnDayEnd = false)
		{
			if (sendOnDayEnd)
			{
				m_designEvents[eventName] = new DesignEvent(eventName, eventValue, customFields, mergeFields);
			}
			else
			{
				GameAnalyticsSDK.GameAnalytics.NewDesignEvent(eventName, eventValue, customFields, mergeFields);
			}
		}

		public static void NewOrAddDesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			if (m_designEvents.ContainsKey(eventName))
			{
				AddDesignEvent(eventName, eventValue, customFields, mergeFields);
			}
			else
			{
				NewDesignEvent(eventName, eventValue, customFields, mergeFields, sendOnDayEnd: true);
			}
		}

		private static void AddDesignEvent(string eventName, float eventValue, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			DesignEvent value = new DesignEvent(eventName, m_designEvents[eventName].eventValue + eventValue, customFields, mergeFields);
			m_designEvents[eventName] = value;
		}

		public static void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03, int score, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(progressionStatus, progression01, progression02, progression03, score, customFields, mergeFields);
		}

		public static void NewResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			GameAnalyticsSDK.GameAnalytics.NewResourceEvent(flowType, currency, amount, itemType, itemId, customFields, mergeFields);
		}

		public static void NewAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			GameAnalyticsSDK.GameAnalytics.NewAdEvent(adAction, adType, adSdkName, adPlacement, duration, customFields, mergeFields);
		}

		public static void NewErrorEvent(GAErrorSeverity severity, string message, IDictionary<string, object> customFields = null, bool mergeFields = false)
		{
			GameAnalyticsSDK.GameAnalytics.NewErrorEvent(severity, message, customFields, mergeFields);
		}

		public static void ClearBatchEvents()
		{
			m_designEvents.Clear();
			Debugger<EDebugCategory>.Log(EDebugCategory.Analytics, "Cleared batch events");
		}

		public static void SendBatchEvents()
		{
			SendBatchDesignEvents();
			Debugger<EDebugCategory>.Log(EDebugCategory.Analytics, "Sent batch events");
		}

		private static void SendBatchDesignEvents()
		{
			foreach (KeyValuePair<string, DesignEvent> designEvent in m_designEvents)
			{
				NewDesignEvent(designEvent.Value.eventName, designEvent.Value.eventValue, designEvent.Value.customFields, designEvent.Value.mergeFields);
			}
			m_designEvents.Clear();
		}
	}
}
