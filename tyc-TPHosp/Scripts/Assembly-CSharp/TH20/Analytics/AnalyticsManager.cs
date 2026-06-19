#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace TH20.Analytics
{
	[DontSave]
	public class AnalyticsManager : MustCallDestroy
	{
		private readonly MonoBehaviour _behaviourToRunCoroutinesOn;

		private readonly AnalyticsManagerConfig _config;

		private readonly string _appID;

		private readonly string _sessionID;

		private readonly bool _isPublicBuild;

		private readonly App _appRef;

		private bool _initAnalyticsSent;

		private string _userID;

		public AnalyticsManagerConfig Config => _config;

		public string CurrentUserID => _userID;

		public string SessionID => _sessionID;

		private string PlatformUserIDKey => "steamID";

		public AnalyticsManager(App app, AnalyticsManagerConfig analyticsManagerConfig, MonoBehaviour behaviourToRunCoroutinesOn, string appID, bool isPublicBuild)
		{
			Logging.Info(LogChannels.Analytics, "Starting AnalyticsManager");
			_appRef = app;
			_config = analyticsManagerConfig;
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			_isPublicBuild = isPublicBuild;
			_appID = appID;
			_sessionID = Guid.NewGuid().ToString("N");
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				Logging.Info(LogChannels.Analytics, "Not connected to Steam. Using null userID");
				_userID = null;
			}
			else
			{
				_userID = OnlineManager.GetLocalPlayerID().ToString();
			}
		}

		public static string ToFriendlyEventName(string name)
		{
			return Regex.Replace(name.Trim().ToLower(), "\\s+", "_");
		}

		public override void Destroy()
		{
			if (OnlineManager.IsInitialized())
			{
				SendShutdownAnalytics();
			}
			base.Destroy();
		}

		public void OnUserChanged(string newUserID)
		{
			if (!string.IsNullOrEmpty(_userID))
			{
				if (_userID.Equals(newUserID) && _initAnalyticsSent)
				{
					return;
				}
				SendShutdownAnalytics();
			}
			_userID = newUserID;
			if (!string.IsNullOrEmpty(_userID))
			{
				SendInitAnalytics();
			}
		}

		public void SendInitAnalytics()
		{
			if (!_initAnalyticsSent)
			{
				RecordEvent(new GameEvent(_config.GameSessionOpenInfo, 1).AddParam("system_processor", SystemInfo.processorType).AddParam("system_memory", ((long)SystemInfo.systemMemorySize * 1048576L).ToString()).AddParam("system_os", SystemInfo.operatingSystem)
					.AddParam("system_display", SystemInfo.graphicsDeviceName)
					.AddParam("system_display_memory", ((long)SystemInfo.graphicsMemorySize * 1048576L).ToString())
					.AddParam("hwid", GetSystemFingerPrint())
					.AddParam("crc", GetAppHash())
					.AddParam("game_version", GameVersionNumber.Version.VersionString)
					.AddParam(PlatformUserIDKey, _userID)
					.AddParam("language_selection", Preferences.LanguagePreferences.GetLanguageCode(_appRef.UserPreferences.Language.SelectedLanguage)));
				_initAnalyticsSent = true;
			}
		}

		private void SendShutdownAnalytics()
		{
			RecordEvent(new GameEvent(_config.GameSessionCloseInfo, 1));
			_initAnalyticsSent = false;
		}

		private static string GetSystemFingerPrint()
		{
			return SystemInfo.deviceUniqueIdentifier;
		}

		private static string GetAppHash()
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			string s = Application.genuine + Application.productName + GameVersionNumber.Version?.ToString() + Application.unityVersion + Application.genuineCheckAvailable;
			byte[] bytes = new ASCIIEncoding().GetBytes(s);
			return BitConverter.ToString(mD5CryptoServiceProvider.ComputeHash(bytes)).Replace("-", "");
		}

		public void RecordEvent(GameEvent gameEvent)
		{
			if (!gameEvent.IsEnabled)
			{
				Logging.Info(LogChannels.Analytics, "Event is disabled. Not sending event {0}.", gameEvent.AsDictionary()["eventName"]);
				return;
			}
			Logging.Info(LogChannels.Analytics, "Sending event {0}.", gameEvent.AsDictionary()["eventName"]);
			gameEvent.AddParam("sessionID", _sessionID);
			gameEvent.AddParam(PlatformUserIDKey, _userID);
			gameEvent.AddParam("gamecode", _appID);
			string jsonBlob = MiniJSONSerializer.Serialize(gameEvent.AsDictionary());
			_behaviourToRunCoroutinesOn.StartCoroutine(WaitForJsonRequest(jsonBlob, _isPublicBuild));
		}

		private static IEnumerator WaitForJsonRequest(string jsonBlob, bool isPublicBuild)
		{
			string url = (isPublicBuild ? "https://garry.sgaas.net/event" : "https://garry-sandbox.sgaas.net/event");
			byte[] bytes = Encoding.UTF8.GetBytes(jsonBlob);
			Dictionary<string, string> headers = new Dictionary<string, string> { { "Content-type", "application/json" } };
			yield return new WWW(url, bytes, headers);
		}
	}
}
