using System.Collections.Generic;
using DinoPoloClub;
using UnityEngine;

namespace com.dinopoloclub.analytics
{
	public class AnalyticsService
	{
		public enum ConsentState
		{
			NotYetGiven = 0,
			Accepted = 1,
			Declined = 2
		}

		public interface ISession
		{
			void SendEvent(string eventName, string eventVersion, Dictionary<string, object> data = null);
		}

		private readonly AnalyticsServiceInternal _analyticsServiceInternal;

		public AnalyticsService(IAnalyticsStorageProvider storageProvider, string apiKey, string applicationId, string applicationVersion, string analyticsUrl, ConsentState consentState)
		{
			GameObject gameObject = new GameObject("DinoPoloClub.Analytics");
			AnalyticsServiceInternal analyticsServiceInternal = gameObject.AddComponent<AnalyticsServiceInternal>();
			analyticsServiceInternal.Initialize(storageProvider, apiKey, applicationId, applicationVersion, analyticsUrl, consentState);
			Object.DontDestroyOnLoad(gameObject);
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			analyticsServiceInternal.hideFlags = HideFlags.HideAndDontSave;
			_analyticsServiceInternal = analyticsServiceInternal;
		}

		public ISession CreateSession()
		{
			if (_analyticsServiceInternal == null)
			{
				Debug.LogError("StartSession called before an analytics instance was created!");
				return null;
			}
			return _analyticsServiceInternal.CreateSession();
		}

		public void SetUserAnalyticsConsent(ConsentState doesUserConsent)
		{
			if (_analyticsServiceInternal == null)
			{
				Debug.LogError("SetUserAnalyticsConsent called before an analytics instance was created!");
			}
			else
			{
				_analyticsServiceInternal.SetUserAnalyticsConsent(doesUserConsent);
			}
		}
	}
}
