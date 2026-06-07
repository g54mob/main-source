using System;
using System.Collections.Generic;
using DinoPoloClub;
using UnityEngine;
using com.dinopoloclub.analytics;

namespace Plugins.Analytics
{
	public class MotorwaysAnalytics
	{
		private readonly AnalyticsService _analyticsService;

		private const string AnalyticsUrlPattern = "https://{0}/applications/{1}/events";

		private const string AnalyticsDefaultDomain = "hy9wus1ccg.execute-api.ap-southeast-2.amazonaws.com";

		private const string AnalyticsDefaultApplicationId = "b9493e23-5675-4b8a-96e6-20232751bf46";

		private const string AnalyticsDefaultApiKey = "lw9rsjwKsUA95XOq7Z2//aMwpgmqFSj4NFyAsFqkCcgPQix/DG3lm5QxUR04TlnOSVcObNndZJtI3LdCRiuNHw==";

		private const string AnalyticsDomain = "hhgsybanje.execute-api.ap-southeast-2.amazonaws.com/prod";

		private const string AnalyticsApplicationId = "3bddb638-6e29-40b5-b488-f0b5cfb044c1";

		private const string AnalyticsApiKey = "vAYxZ6XLushplKdAenAv8yNziUGTDkir0Kf4PWrdOctTViOBiXlyf3HM0Nt9axzXAWqOOpDz2XhEp1V3DGPzmQ==";

		private const string ApplicationVersion = "1.0.0.3";

		private readonly AnalyticsService.ISession _session;

		public MotorwaysAnalytics(IAnalyticsStorageProvider storageProvider, AnalyticsService.ConsentState consentState, Dictionary<string, object> sessionStartData)
		{
			string arg = "hy9wus1ccg.execute-api.ap-southeast-2.amazonaws.com";
			if (Environment.GetEnvironmentVariable("AnalyticsDomain") != null)
			{
				arg = Environment.GetEnvironmentVariable("AnalyticsDomain");
			}
			else if (!string.IsNullOrWhiteSpace("hhgsybanje.execute-api.ap-southeast-2.amazonaws.com/prod"))
			{
				arg = "hhgsybanje.execute-api.ap-southeast-2.amazonaws.com/prod";
			}
			string text = "b9493e23-5675-4b8a-96e6-20232751bf46";
			if (Environment.GetEnvironmentVariable("AnalyticsApplicationId") != null)
			{
				text = Environment.GetEnvironmentVariable("AnalyticsApplicationId");
			}
			else if (!string.IsNullOrWhiteSpace("3bddb638-6e29-40b5-b488-f0b5cfb044c1"))
			{
				text = "3bddb638-6e29-40b5-b488-f0b5cfb044c1";
			}
			string apiKey = "lw9rsjwKsUA95XOq7Z2//aMwpgmqFSj4NFyAsFqkCcgPQix/DG3lm5QxUR04TlnOSVcObNndZJtI3LdCRiuNHw==";
			if (Environment.GetEnvironmentVariable("AnalyticsApiKey") != null)
			{
				apiKey = Environment.GetEnvironmentVariable("AnalyticsApiKey");
			}
			else if (!string.IsNullOrWhiteSpace("vAYxZ6XLushplKdAenAv8yNziUGTDkir0Kf4PWrdOctTViOBiXlyf3HM0Nt9axzXAWqOOpDz2XhEp1V3DGPzmQ=="))
			{
				apiKey = "vAYxZ6XLushplKdAenAv8yNziUGTDkir0Kf4PWrdOctTViOBiXlyf3HM0Nt9axzXAWqOOpDz2XhEp1V3DGPzmQ==";
			}
			string analyticsUrl = $"https://{arg}/applications/{text}/events";
			_analyticsService = new AnalyticsService(storageProvider, apiKey, text, "1.0.0.3", analyticsUrl, consentState);
			_session = _analyticsService.CreateSession();
		}

		public void SetUserAnalyticsConsent(AnalyticsService.ConsentState userConsentState)
		{
			_analyticsService.SetUserAnalyticsConsent(userConsentState);
		}

		public void SendEvent(string eventName, string eventVersion, Dictionary<string, object> data)
		{
			if (_session == null)
			{
				Debug.LogWarning("MotorwaysAnalytics.SendEvent called, but no session started.");
			}
			else
			{
				_session.SendEvent(eventName, eventVersion, data);
			}
		}
	}
}
