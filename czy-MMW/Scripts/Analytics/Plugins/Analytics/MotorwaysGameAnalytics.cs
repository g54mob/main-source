using System.Collections.Generic;
using DinoPoloClub;
using com.dinopoloclub.analytics;

namespace Plugins.Analytics
{
	public class MotorwaysGameAnalytics
	{
		private MotorwaysAnalytics _motorwaysAnalytics;

		private AnalyticsTypes _analyticsTypes;

		public void Initialise(AnalyticsService.ConsentState userAnalyticsConsent, IAnalyticsStorageProvider storageProvider)
		{
			_motorwaysAnalytics = new MotorwaysAnalytics(storageProvider, userAnalyticsConsent, null);
			_analyticsTypes = new AnalyticsTypes();
		}

		private void SendEvent(Dictionary<AnalyticsTypes.DataType, object> eventData, AnalyticsTypes.EventType eventType)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<AnalyticsTypes.DataType, object> eventDatum in eventData)
			{
				dictionary.Add(_analyticsTypes.GetDataString(eventDatum.Key), eventDatum.Value);
			}
			_motorwaysAnalytics?.SendEvent(_analyticsTypes.GetEventString(eventType), "1.0", dictionary);
		}

		private AnalyticsService.ConsentState GetAnalyticsServiceConsentState(AnalyticsService.ConsentState analyticsConsent)
		{
			AnalyticsService.ConsentState result = AnalyticsService.ConsentState.NotYetGiven;
			switch (analyticsConsent)
			{
			case AnalyticsService.ConsentState.Accepted:
				result = AnalyticsService.ConsentState.Accepted;
				break;
			case AnalyticsService.ConsentState.Declined:
				result = AnalyticsService.ConsentState.Declined;
				break;
			}
			return result;
		}

		public void SetUserAnalyticsConsent(AnalyticsService.ConsentState analyticsConsent)
		{
			_motorwaysAnalytics.SetUserAnalyticsConsent(GetAnalyticsServiceConsentState(analyticsConsent));
		}

		public void SendLevelStartEvent(string name, string mode)
		{
			Dictionary<AnalyticsTypes.DataType, object> eventData = new Dictionary<AnalyticsTypes.DataType, object>
			{
				{
					AnalyticsTypes.DataType.LevelID,
					name
				},
				{
					AnalyticsTypes.DataType.GameMode,
					mode
				}
			};
			SendEvent(eventData, AnalyticsTypes.EventType.LevelStart);
		}

		public void SendLevelEndEvent(string name, string mode, string gameEndReason, int score)
		{
			Dictionary<AnalyticsTypes.DataType, object> eventData = new Dictionary<AnalyticsTypes.DataType, object>
			{
				{
					AnalyticsTypes.DataType.LevelID,
					name
				},
				{
					AnalyticsTypes.DataType.GameMode,
					mode
				},
				{
					AnalyticsTypes.DataType.LevelEndReason,
					gameEndReason
				},
				{
					AnalyticsTypes.DataType.PlayerScore,
					score
				}
			};
			SendEvent(eventData, AnalyticsTypes.EventType.LevelEnd);
		}
	}
}
