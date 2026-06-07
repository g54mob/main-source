using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using Motorways.Views;
using NotificationService.Events;
using UnityEngine;
using UnityEngine.Networking;

namespace Motorways
{
	public class InGameMessageService : ICreatedInScopeHandler, MainMenuScreen.IObserver
	{
		[Dependency]
		private Scope _scope;

		[Dependency]
		private MainMenuScreen _mainMenu;

		[Dependency]
		private InGameMessageUIManager _messenger;

		[Dependency]
		private ChallengeSystem _challengeSystem;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private INotificationEventSystem _events;

		[Dependency]
		private IPersistentStorageService _storage;

		[Dependency]
		private ISoftwareCapabilities _softwareCapabilities;

		[Serialize(false, null)]
		private HashSet<StringId> _messagesSeenThisSession = new HashSet<StringId>();

		private System.Version _appStoreVersion;

		private bool _hasShowniCloudWarning;

		public void OnCreatedInScope(IScope scope)
		{
			_mainMenu.Subscribe(this);
		}

		public void OnMainMenuTransitionedIn()
		{
			if (!_hasShowniCloudWarning && Application.platform == RuntimePlatform.tvOS)
			{
				if ((_storage.Status.issues & PersistentStorageServiceIssues.NotAuthenticated) == PersistentStorageServiceIssues.NotAuthenticated)
				{
					_messenger.DisplayMessage(StandaloneLocString.CreateString(_scope, StringId.iCloudNotLoggedIn));
					_hasShowniCloudWarning = true;
				}
				else if ((_storage.Status.issues & PersistentStorageServiceIssues.NotAvailable) == PersistentStorageServiceIssues.NotAvailable)
				{
					_messenger.DisplayMessage(StandaloneLocString.CreateString(_scope, StringId.iCloudNotConnectedToInternet));
					_hasShowniCloudWarning = true;
				}
				if (_hasShowniCloudWarning)
				{
					return;
				}
			}
			if (AreMenuMessagesEnabled())
			{
				_mainMenu.StartCoroutine(DoDisplayMessages());
			}
		}

		private bool AreMenuMessagesEnabled()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				return false;
			}
			return _player.AreMenuMessagesEnabled;
		}

		public void OnMainMenuTransitionOut()
		{
		}

		public void OnMainMenuExit()
		{
		}

		private IEnumerator DoDisplayMessages()
		{
			yield return _mainMenu.StartCoroutine(DoVersionUpdateCheck());
			if (HasMessageToDisplay(out var result))
			{
				_messenger.DisplayMessage(result);
			}
		}

		private IEnumerator DoVersionUpdateCheck()
		{
			string url = GetVersionCheckUrl();
			if (!Diagnostics.Verify(!string.IsNullOrEmpty(url), "No URL found for this platform"))
			{
				yield break;
			}
			UnityWebRequest webRequest = UnityWebRequest.Get(url);
			yield return webRequest.SendWebRequest();
			if (Diagnostics.Verify(webRequest.result == UnityWebRequest.Result.Success, "Failed to get request from {0} with error {1}", url, webRequest.error))
			{
				JSON.Dictionary dictionary = JSON.ToDictionary(JSON.LoadFromString(webRequest.downloadHandler.text))?.GetArray("results")?.GetDictionary(0);
				if (Diagnostics.Verify(dictionary != null, "Failed to find results in json: {0}", webRequest.downloadHandler.text))
				{
					_appStoreVersion = new System.Version(dictionary.GetString("version"));
				}
			}
		}

		private string GetVersionCheckUrl()
		{
			return string.Empty;
		}

		private bool HasMessageToDisplay(out StandaloneLocString result)
		{
			if (CheckForNewVersionMessage(out result) || CheckCreativeModeMessage(out result) || CheckResumeGameMessage(out result) || CheckWeeklyChallengeMessage(out result) || CheckDailyChallengeMessage(out result))
			{
				return true;
			}
			return false;
		}

		private bool CheckForNewVersionMessage(out StandaloneLocString message)
		{
			if (_appStoreVersion == null)
			{
				message = null;
				return false;
			}
			System.Version value = new System.Version(Application.version);
			if (_appStoreVersion.CompareTo(value) > 0 && !_messagesSeenThisSession.Contains(StringId.InGame_Messages_RecurringNewUpdate_Text))
			{
				message = StandaloneLocString.CreateString(_scope, StringId.InGame_Messages_RecurringNewUpdate_Text);
				_messagesSeenThisSession.Add(StringId.InGame_Messages_RecurringNewUpdate_Text);
				return true;
			}
			message = null;
			return false;
		}

		private bool CheckTutorialMessage(out StandaloneLocString message)
		{
			if (!_player.IsAnyTutorialCompleted && HasPlayedTutorialInLast30Days(out var datePlayed) && (datePlayed - GameDateTime.LocalToday).TotalDays > 1.0 && !_player.HasSeenNewContent("TutorialInGameMessagePromptKey"))
			{
				message = StandaloneLocString.CreateString(_scope, StringId.InGame_Messages_1OffTutorial1Day_Text);
				return true;
			}
			message = null;
			return false;
		}

		private bool HasPlayedTutorialInLast30Days(out DateTime datePlayed)
		{
			foreach (NotificationEvent allEvent in _events.AllEvents)
			{
				if (allEvent.EventType is PlayedMap { Map: MapDefinition.CityNames.None })
				{
					datePlayed = allEvent.OccuredAt;
					return true;
				}
			}
			datePlayed = GameDateTime.LocalToday;
			return false;
		}

		private bool CheckResumeGameMessage(out StandaloneLocString message)
		{
			if (_player.HasLocalSavedGame && !_messagesSeenThisSession.Contains(StringId.InGame_Messages_RecurringResumeSavedGame_Text) && (_player.LocalSavedGame.UtcTimestamp - GameDateTime.UtcToday).TotalDays > 3.0)
			{
				_messagesSeenThisSession.Add(StringId.InGame_Messages_RecurringResumeSavedGame_Text);
				message = StandaloneLocString.CreateString(_scope, StringId.InGame_Messages_RecurringResumeSavedGame_Text);
				return true;
			}
			message = null;
			return false;
		}

		private bool CheckCreativeModeMessage(out StandaloneLocString message)
		{
			if (_player.HasSeenCreativeInGameMessage)
			{
				message = null;
				return false;
			}
			_player.HasSeenCreativeInGameMessage = true;
			message = StandaloneLocString.CreateString(_scope, StringId.InGame_Messages_CreativeMode);
			return true;
		}

		private bool CheckWeeklyChallengeMessage(out StandaloneLocString message)
		{
			if (!_challengeSystem.AreChallengesUnlocked(_player) || !_softwareCapabilities.AllowsTimedChallengeMessages())
			{
				message = null;
				return false;
			}
			int timeEnd = _challengeSystem.WeeklyChallenge.TimeEnd;
			if (_player.GetChallengeScore(MapChallenge.ChallengeType.Weekly, timeEnd).Score > 0)
			{
				message = null;
				return false;
			}
			int num = _challengeSystem.WeeklyChallenge.SecondsLeft / 60 / 60;
			int num2 = num / 24;
			if (!_messagesSeenThisSession.Contains(StringId.Local_Notifications_RecurringWC1Day_Text) && num2 > 6)
			{
				_messagesSeenThisSession.Add(StringId.Local_Notifications_RecurringWC1Day_Text);
				message = StandaloneLocString.CreateString(_scope, StringId.Local_Notifications_RecurringWC1Day_Text);
				return true;
			}
			if (!_messagesSeenThisSession.Contains(StringId.InGame_Messages_RecurringWC6Days_Text) && num <= 24)
			{
				_messagesSeenThisSession.Add(StringId.InGame_Messages_RecurringWC6Days_Text);
				message = CreateStringKeyWithIntParameter(StringId.InGame_Messages_RecurringWC6Days_Text, StringParameterId.Hour, num);
				return true;
			}
			message = null;
			return false;
		}

		public bool CheckDailyChallengeMessage(out StandaloneLocString message)
		{
			if (!_challengeSystem.AreChallengesUnlocked(_player) || !_softwareCapabilities.AllowsTimedChallengeMessages())
			{
				message = null;
				return false;
			}
			int timeEnd = _challengeSystem.DailyChallenge.TimeEnd;
			if (_player.GetChallengeScore(MapChallenge.ChallengeType.Daily, timeEnd).Score > 0)
			{
				message = null;
				return false;
			}
			int num = _challengeSystem.DailyChallenge.SecondsLeft / 60 / 60;
			if (!_messagesSeenThisSession.Contains(StringId.InGame_Messages_RecurringDC3Hours_Text) && num < 3)
			{
				_messagesSeenThisSession.Add(StringId.InGame_Messages_RecurringDC3Hours_Text);
				message = StandaloneLocString.CreateString(_scope, StringId.InGame_Messages_RecurringDC3Hours_Text);
				return true;
			}
			if (!_messagesSeenThisSession.Contains(StringId.InGame_Messages_RecurringDC20Hours_Text) && num > 20)
			{
				_messagesSeenThisSession.Add(StringId.InGame_Messages_RecurringDC20Hours_Text);
				message = CreateStringKeyWithIntParameter(StringId.InGame_Messages_RecurringDC20Hours_Text, StringParameterId.Hour, num);
				return true;
			}
			message = null;
			return false;
		}

		public StandaloneLocString CreateStringKeyWithIntParameter(StringId stringId, StringParameterId parameterType, int value)
		{
			MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
			motorwaysStringKey.InitWithStringId(stringId, value, new Dictionary<string, string> { 
			{
				parameterType.ToString(),
				value.ToString()
			} });
			return StandaloneLocString.CreateString(_scope, motorwaysStringKey);
		}
	}
}
