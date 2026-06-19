using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class OnlineChallengeEventLog : MonoBehaviour
	{
		public class ActivityItem
		{
			public OnlineChallengeObjective.PlayerInfo PlayerInfo;

			public int Day;

			public string ActivityString;
		}

		[SerializeField]
		private GameObject _activityItemPrefab;

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private int _numDaysHistory;

		[SerializeField]
		private int _maxActivityItems;

		private OnlineChallengeObjective _levelObjective;

		private bool _dirty;

		private readonly List<ActivityItem> _activityList = new List<ActivityItem>();

		private readonly List<OnlineChallengeActivityItem> _activityItemsList = new List<OnlineChallengeActivityItem>();

		public void Setup(OnlineChallengeObjective levelObjective)
		{
			_levelObjective = levelObjective;
			for (int i = 0; i < _maxActivityItems; i++)
			{
				GameObject obj = Object.Instantiate(_activityItemPrefab);
				RectTransform rectTransform = obj.transform as RectTransform;
				if (rectTransform != null)
				{
					rectTransform.SetParent(_scroller.content.gameObject.transform, worldPositionStays: false);
				}
				OnlineChallengeActivityItem component = obj.GetComponent<OnlineChallengeActivityItem>();
				obj.SetActive(value: false);
				_activityItemsList.Add(component);
			}
		}

		private void OnDestroy()
		{
			for (int i = 0; i < _maxActivityItems; i++)
			{
				Object.Destroy(_activityItemsList[i]);
			}
		}

		public void OnFriendDataUpdated()
		{
			_activityList.Clear();
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in _levelObjective.PlayerInfoDictionary)
			{
				OnlineChallengeObjective.PlayerInfo value = item.Value;
				if (value == null || !(value.ChallengeData is OnlineChallengeData onlineChallengeData))
				{
					continue;
				}
				List<OnlineChallengeEvent> eventsBetweenDays = onlineChallengeData.GetEventsBetweenDays(_numDaysHistory - 1, _levelObjective.DaysElapsed - 1, excludeScores: true);
				for (int i = 0; i < eventsBetweenDays.Count; i++)
				{
					if (eventsBetweenDays[i].Type != OnlineChallengeEvent.Event.Challenge && eventsBetweenDays[i].Type != OnlineChallengeEvent.Event.Score)
					{
						_activityList.Add(new ActivityItem
						{
							PlayerInfo = value,
							Day = eventsBetweenDays[i].Day,
							ActivityString = CreateActivityLogString(value.PlayerName, value.IsLocalPlayer, eventsBetweenDays[i], showDay: true, colored: true)
						});
					}
				}
			}
			_activityList.Sort((ActivityItem activityA, ActivityItem activityB) => activityA.Day.CompareTo(activityB.Day));
			_dirty = true;
		}

		public void OnEventReceived(OnlinePlayerID playerID, OnlineChallengeEvent challengeEvent)
		{
			OnlineChallengeObjective.PlayerInfo playerInfo = _levelObjective.GetPlayerInfo(playerID);
			if (playerInfo != null && challengeEvent.Type != OnlineChallengeEvent.Event.Challenge && challengeEvent.Type != OnlineChallengeEvent.Event.Score && challengeEvent.Type != OnlineChallengeEvent.Event.ObjectiveStatus)
			{
				_activityList.Add(new ActivityItem
				{
					PlayerInfo = playerInfo,
					Day = challengeEvent.Day,
					ActivityString = CreateActivityLogString(playerInfo.PlayerName, playerInfo.IsLocalPlayer, challengeEvent, showDay: true, colored: true)
				});
				_dirty = true;
			}
		}

		public void Refresh()
		{
			int num = Mathf.Max(0, _activityList.Count - _activityItemsList.Count);
			for (int i = 0; i < _activityItemsList.Count; i++)
			{
				if (_activityList.Count <= i)
				{
					_activityItemsList[i].Setup(null);
					continue;
				}
				ActivityItem item = _activityList[num + i];
				_activityItemsList[i].Setup(item);
			}
		}

		public void OnTimelineUpdated()
		{
			if (_dirty)
			{
				_dirty = false;
				Refresh();
			}
		}

		public string CreateActivityLogString(string playerName, bool isLocalPlayer, OnlineChallengeEvent challengeEvent, bool showDay, bool colored)
		{
			string arg = string.Empty;
			if (showDay)
			{
				arg = GetChallengeEventDayString(challengeEvent.Day + 1, colored);
			}
			string arg2 = (isLocalPlayer ? $"<color=#00FFE8><b>{playerName}</b></color>" : $"<b>{playerName}</b>");
			return $"{arg} {arg2} {GetChallengeEventString(challengeEvent)}";
		}

		public static string GetChallengeEventDayString(int day, bool colored)
		{
			string text = string.Format(ScriptLocalization.Online.EventLog_Day_CS, day);
			if (colored)
			{
				return $"<color=#D5FF00>{text}</color>";
			}
			return text;
		}

		public static string GetChallengeEventString(OnlineChallengeEvent challengeEvent)
		{
			string result;
			switch (challengeEvent.Type)
			{
			case OnlineChallengeEvent.Event.PatientCured:
			{
				result = ScriptLocalization.Online.EventLog_CuredPatient_CS;
				string illnessTermForOnlineChallengeEvent3 = GetIllnessTermForOnlineChallengeEvent(challengeEvent);
				if (illnessTermForOnlineChallengeEvent3 != null && LocalizationManager.TryGetTranslation(illnessTermForOnlineChallengeEvent3, out var Translation5))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_CuredPatient_Specific_CS, Translation5);
				}
				break;
			}
			case OnlineChallengeEvent.Event.PatientCureIneffective:
			{
				result = ScriptLocalization.Online.EventLog_CuredPatientIneffective_CS;
				string illnessTermForOnlineChallengeEvent = GetIllnessTermForOnlineChallengeEvent(challengeEvent);
				if (illnessTermForOnlineChallengeEvent != null && LocalizationManager.TryGetTranslation(illnessTermForOnlineChallengeEvent, out var Translation))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_CuredPatientIneffective_Specific_CS, Translation);
				}
				break;
			}
			case OnlineChallengeEvent.Event.PatientDeath:
				result = ScriptLocalization.Online.EventLog_PatientDied_CS;
				break;
			case OnlineChallengeEvent.Event.PatientDiagnosed:
			{
				result = ScriptLocalization.Online.EventLog_PatientDiagnosed_CS;
				string illnessTermForOnlineChallengeEvent2 = GetIllnessTermForOnlineChallengeEvent(challengeEvent);
				if (illnessTermForOnlineChallengeEvent2 != null && LocalizationManager.TryGetTranslation(illnessTermForOnlineChallengeEvent2, out var Translation2))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_PatientDiagnosed_Specific_CS, Translation2);
				}
				break;
			}
			case OnlineChallengeEvent.Event.RoomBuilt:
				result = ScriptLocalization.Online.EventLog_RoomBuilt_CS;
				if (challengeEvent is OnlineChallengeEventString onlineChallengeEventString)
				{
					string translationPlural = LocalisedString.GetTranslationPlural(onlineChallengeEventString.Data, 1);
					if (!translationPlural.IsNullOrEmpty())
					{
						result = string.Format(ScriptLocalization.Online.EventLog_RoomBuilt_Specific_CS, translationPlural);
					}
				}
				break;
			case OnlineChallengeEvent.Event.PlotBought:
				result = ScriptLocalization.Online.EventLog_PlotBought_CS;
				break;
			case OnlineChallengeEvent.Event.StaffHired:
			{
				result = ScriptLocalization.Online.EventLog_StaffHired_CS;
				string staffTypeTermForOnlineChallengeEvent3 = GetStaffTypeTermForOnlineChallengeEvent(challengeEvent);
				if (staffTypeTermForOnlineChallengeEvent3 != null && LocalizationManager.TryGetTranslation(staffTypeTermForOnlineChallengeEvent3, out var Translation6))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_StaffHired_Specific_CS, Translation6);
				}
				break;
			}
			case OnlineChallengeEvent.Event.StaffFired:
			{
				result = ScriptLocalization.Online.EventLog_StaffFired_CS;
				string staffTypeTermForOnlineChallengeEvent2 = GetStaffTypeTermForOnlineChallengeEvent(challengeEvent);
				if (staffTypeTermForOnlineChallengeEvent2 != null && LocalizationManager.TryGetTranslation(staffTypeTermForOnlineChallengeEvent2, out var Translation4))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_StaffFired_Specific_CS, Translation4);
				}
				break;
			}
			case OnlineChallengeEvent.Event.StaffPromoted:
			{
				result = ScriptLocalization.Online.EventLog_StaffPromoted_CS;
				string staffTypeTermForOnlineChallengeEvent = GetStaffTypeTermForOnlineChallengeEvent(challengeEvent);
				if (staffTypeTermForOnlineChallengeEvent != null && LocalizationManager.TryGetTranslation(staffTypeTermForOnlineChallengeEvent, out var Translation3))
				{
					result = string.Format(ScriptLocalization.Online.EventLog_StaffPromoted_Specific_CS, Translation3);
				}
				break;
			}
			case OnlineChallengeEvent.Event.LoanTaken:
				result = ((!(challengeEvent is OnlineChallengeEventInt onlineChallengeEventInt)) ? ScriptLocalization.Online.EventLog_LoanTaken_CS : string.Format(ScriptLocalization.Online.EventLog_LoanTaken_Specific_CS, StringUtils.FormatCurrency(onlineChallengeEventInt.Data)));
				break;
			case OnlineChallengeEvent.Event.PatientRageQuit:
				result = ScriptLocalization.Online.EventLog_PatientRageQuit_CS;
				break;
			case OnlineChallengeEvent.Event.PatientSentHome:
				result = ScriptLocalization.Online.EventLog_PatientSentHome_CS;
				break;
			case OnlineChallengeEvent.Event.ObjectiveStatus:
				result = ScriptLocalization.Online.EventLog_ChallengeStatus_CS;
				break;
			default:
				result = challengeEvent.Type.ToString();
				break;
			}
			return result;
		}

		private static string GetIllnessTermForOnlineChallengeEvent(OnlineChallengeEvent challengeEvent)
		{
			if (!(challengeEvent is OnlineChallengeEventString onlineChallengeEventString))
			{
				if (challengeEvent is OnlineChallengeEventInt onlineChallengeEventInt && OnlineManager.AssetIDs.TryGetValue(onlineChallengeEventInt.Data, out var value) && value is IllnessDefinition illnessDefinition)
				{
					return illnessDefinition.Name.Term;
				}
				return null;
			}
			return onlineChallengeEventString.Data;
		}

		private static string GetStaffTypeTermForOnlineChallengeEvent(OnlineChallengeEvent challengeEvent)
		{
			if (!(challengeEvent is OnlineChallengeEventString onlineChallengeEventString))
			{
				if (challengeEvent is OnlineChallengeEventInt onlineChallengeEventInt)
				{
					return GameStringUtils.GetStaffTypeTextLocTerm((StaffDefinition.Type)onlineChallengeEventInt.Data);
				}
				return null;
			}
			return onlineChallengeEventString.Data;
		}
	}
}
