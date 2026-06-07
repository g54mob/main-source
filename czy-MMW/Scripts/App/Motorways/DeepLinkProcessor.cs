using System;
using System.Collections.Generic;
using System.Net;
using Factory;
using UnityEngine;

namespace Motorways
{
	public class DeepLinkProcessor : ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		private const string FALLBACK_URL = "https://api.dinopoloclub.com/1/minimotorways/start-challenge/";

		private const string STRIPPED_FALLBACK_URL = "https//api.dinopoloclub.com/1/minimotorways/start-challenge/";

		private const string CHALLENGE_PREFIX = "grp.dinopoloclub.minimotorways.challenges.";

		private const string ACTIVITY_PARAMETER = "a";

		private string _deepLinkURL;

		private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

		public bool hasChallengeToUse;

		public string challengeMap;

		public GameMode challengeMode;

		[Dependency]
		private PlayTogetherChallengeDatabase challengeDatabase;

		public void OnCreatedInScope(IScope scope)
		{
			Diagnostics.Log.Info("DeepLinkProcessor", "OnCreatedInScope(), Subscribing to callback");
			Application.deepLinkActivated += OnDeepLinkActivated;
			if (!string.IsNullOrEmpty(Application.absoluteURL))
			{
				OnDeepLinkActivated(Application.absoluteURL);
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			Application.deepLinkActivated -= OnDeepLinkActivated;
		}

		public void OnDeepLinkActivated(string url)
		{
			_deepLinkURL = url;
			hasChallengeToUse = false;
			parameters.Clear();
			Diagnostics.Log.Info("DeepLinkProcessor", "Deeplink url received {0}", url);
			if (url.Contains("https://api.dinopoloclub.com/1/minimotorways/start-challenge/") || url.Contains("https//api.dinopoloclub.com/1/minimotorways/start-challenge/"))
			{
				ExtractParametersFromUrl();
				ProcessParameters();
			}
		}

		private void ExtractParametersFromUrl()
		{
			string[] array = new Uri(_deepLinkURL).Query.TrimStart('?').Split('&');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=');
				if (array2.Length == 2)
				{
					parameters.Add(array2[0], WebUtility.UrlDecode(array2[1]));
					Diagnostics.Log.Info("DeepLinkProcessor", "Parameter found: {0} {1}", array2[0], array2[0]);
				}
			}
		}

		private void ProcessParameters()
		{
			if (!parameters.TryGetValue("a", out var value))
			{
				Diagnostics.Log.Warn("DeepLinkProcessor", "activity parameter invalid. Expected {0}", "a");
				return;
			}
			if (challengeDatabase == null)
			{
				Diagnostics.Log.Error("DeepLinkProcessor", "challengeDatabase is null");
				return;
			}
			if (!challengeDatabase.TryGetChallenge(value, out var challenge))
			{
				Diagnostics.Log.Warn("DeepLinkProcessor", "unrecognized activityName {0}", value);
				return;
			}
			Diagnostics.Log.Info("DeepLinkProcessor", $"challenge found {challenge.ChallengeId} {challenge.MapName} ({challenge.GameMode})");
			hasChallengeToUse = true;
			challengeMap = challenge.MapName;
			challengeMode = challenge.GameMode;
		}
	}
}
