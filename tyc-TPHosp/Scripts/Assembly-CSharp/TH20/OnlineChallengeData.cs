using System;
using System.Collections.Generic;
using System.Linq;
using FullSerializerSave;
using MessagePack;
using UnityEngine;

namespace TH20
{
	[MessagePackObject(false)]
	public class OnlineChallengeData : ChallengeData, OnlineManager.IOnlineSerializable
	{
		[IgnoreMember]
		[fsProperty("_steamID")]
		[SerializeField]
		private OnlinePlayerID _playerID;

		[IgnoreMember]
		[SerializeField]
		private List<OnlineChallengeEvent> _eventStream = new List<OnlineChallengeEvent>();

		[IgnoreMember]
		[SerializeField]
		private int _challengeStartDate;

		[IgnoreMember]
		[SerializeField]
		private int _challengeLength;

		[IgnoreMember]
		[SerializeField]
		private List<OnlinePlayerID> _playersList = new List<OnlinePlayerID>();

		[IgnoreMember]
		[SerializeField]
		private uint _lastUpdateTime;

		[IgnoreMember]
		private List<OnlineChallengeEventScore> _scoreStream;

		[NonSerialized]
		[IgnoreMember]
		public Action<OnlineChallengeData> OnDataUpdated;

		[Key(1)]
		public OnlinePlayerID PlayerID
		{
			get
			{
				return _playerID;
			}
			set
			{
				_playerID = value;
			}
		}

		[Key(2)]
		public List<OnlineChallengeEvent> EventStream
		{
			get
			{
				return _eventStream;
			}
			set
			{
				_eventStream = value;
			}
		}

		[Key(3)]
		public List<OnlineChallengeEventScore> ScoreStream
		{
			get
			{
				return _scoreStream;
			}
			set
			{
				_scoreStream = value;
			}
		}

		[Key(4)]
		public int ChallengeStartDay
		{
			get
			{
				return _challengeStartDate;
			}
			set
			{
				_challengeStartDate = value;
			}
		}

		[Key(5)]
		public int ChallengeLength
		{
			get
			{
				return _challengeLength;
			}
			set
			{
				_challengeLength = value;
			}
		}

		[Key(6)]
		public uint LastUpdateTime
		{
			get
			{
				return _lastUpdateTime;
			}
			set
			{
				_lastUpdateTime = value;
			}
		}

		[IgnoreMember]
		public override int ScoreCount => _scoreStream.Count;

		[Key(7)]
		public List<OnlinePlayerID> PlayersList
		{
			get
			{
				return _playersList;
			}
			set
			{
				_playersList = value;
			}
		}

		[IgnoreMember]
		public int EventCount => _eventStream.Count;

		[IgnoreMember]
		public override OnlineChallengeEventScore this[int i] => _scoreStream[i];

		public OnlineChallengeData()
		{
		}

		public OnlineChallengeData(OnlinePlayerID playerID, int startDate, int length)
		{
			_playerID = playerID;
			_challengeStartDate = startDate;
			_challengeLength = length;
			_scoreStream = new List<OnlineChallengeEventScore>();
		}

		public void PrepareForUpload()
		{
			_lastUpdateTime = OnlineManager.GetServerTime();
		}

		public void RestoreAfterDownload()
		{
			_scoreStream = new List<OnlineChallengeEventScore>();
			Sort();
		}

		public List<OnlineChallengeEvent> GetEventsForDay(int day, bool excludeScores)
		{
			List<OnlineChallengeEvent> list = new List<OnlineChallengeEvent>();
			for (int i = 0; i < _eventStream.Count; i++)
			{
				if (_eventStream[i].Day == day && (!excludeScores || !(_eventStream[i] is OnlineChallengeEventScore)))
				{
					list.Add(_eventStream[i]);
				}
			}
			return list;
		}

		public List<OnlineChallengeEvent> GetEventsBetweenDays(int startDay, int finishDay, bool excludeScores)
		{
			List<OnlineChallengeEvent> list = new List<OnlineChallengeEvent>();
			for (int i = 0; i < _eventStream.Count; i++)
			{
				if (_eventStream[i].Day >= startDay && _eventStream[i].Day <= finishDay && (!excludeScores || !(_eventStream[i] is OnlineChallengeEventScore)))
				{
					list.Add(_eventStream[i]);
				}
			}
			return list;
		}

		public bool HasFinishedChallenge(out int finalScore)
		{
			finalScore = 0;
			OnlineChallengeEventScore lastEventOfType = GetLastEventOfType<OnlineChallengeEventScore>();
			if (lastEventOfType == null)
			{
				return false;
			}
			if (lastEventOfType.Day < _challengeLength - 1)
			{
				return false;
			}
			finalScore = lastEventOfType.Score;
			return true;
		}

		public int GetMostRecentDay()
		{
			if (_scoreStream.Count <= 0)
			{
				return -1;
			}
			return _scoreStream[_scoreStream.Count - 1].Day;
		}

		public T GetLastEventOfType<T>() where T : OnlineChallengeEvent
		{
			int num = _eventStream.FindLastIndex((OnlineChallengeEvent e) => e is T);
			if (num == -1)
			{
				return null;
			}
			return _eventStream[num] as T;
		}

		public T GetLastEventOfType<T>(OnlineChallengeEvent.Event eventType) where T : OnlineChallengeEvent
		{
			int num = _eventStream.FindLastIndex((OnlineChallengeEvent e) => e is T && e.Type == eventType);
			if (num == -1)
			{
				return null;
			}
			return _eventStream[num] as T;
		}

		public T GetMostRecentEventOfType<T>(int day) where T : OnlineChallengeEvent
		{
			int num = _eventStream.FindLastIndex((OnlineChallengeEvent e) => e is T && e.Day <= day);
			if (num == -1)
			{
				return null;
			}
			return _eventStream[num] as T;
		}

		public OnlineChallengeEvent GetMostRecentDisplayableEvent(int day)
		{
			int num = _eventStream.FindLastIndex((OnlineChallengeEvent e) => !(e is OnlineChallengeEventScore) && !(e is OnlineChallengeEventHospitalStatus) && e.Day <= day);
			if (num == -1)
			{
				return null;
			}
			return _eventStream[num];
		}

		public int CountEventsOfType(OnlineChallengeEvent.Event eventType)
		{
			return _eventStream.Count((OnlineChallengeEvent eventItem) => eventItem.Type == eventType);
		}

		private void RepopulateScoreStream()
		{
			_scoreStream.Clear();
			for (int i = 0; i < _eventStream.Count; i++)
			{
				if (_eventStream[i] is OnlineChallengeEventScore item)
				{
					_scoreStream.Add(item);
				}
			}
		}

		private void Sort()
		{
			if (_eventStream == null)
			{
				_eventStream = new List<OnlineChallengeEvent>();
			}
			_eventStream.Sort((OnlineChallengeEvent e1, OnlineChallengeEvent e2) => e1.Day.CompareTo(e2.Day));
			RepopulateScoreStream();
		}

		public void LogEventScore(int day, int score)
		{
			LogEvent(OnlineChallengeEventScore.Create(ClampChallengeDay(day), score));
		}

		public void LogEventStaffHired(int day, Staff staff)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.StaffHired, (int)staff.Definition._type));
		}

		public void LogEventStaffFired(int day, Staff staff)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.StaffFired, (int)staff.Definition._type));
		}

		public void LogEventStaffPromoted(int day, Staff staff)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.StaffPromoted, (int)staff.Definition._type));
		}

		public void LogEventPatientDeath(int day, IllnessDefinition illness)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientDeath, OnlineManager.AssetIDs.Reverse[illness]));
		}

		public void LogEventPatientRageQuit(int day)
		{
			LogEvent(OnlineChallengeEvent.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientRageQuit));
		}

		public void LogEventPatientCured(int day, IllnessDefinition illness)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientCured, OnlineManager.AssetIDs.Reverse[illness]));
		}

		public void LogEventPatientIneffetiveTreatment(int day, IllnessDefinition illness)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientCureIneffective, OnlineManager.AssetIDs.Reverse[illness]));
		}

		public void LogEventPatientDiagnosed(int day, IllnessDefinition illness)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientDiagnosed, OnlineManager.AssetIDs.Reverse[illness]));
		}

		public void LogEventPatientSentHome(int day)
		{
			LogEvent(OnlineChallengeEvent.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PatientSentHome));
		}

		public void LogEventPlotBought(int day, HospitalPlotDefinition plot)
		{
			LogEvent(OnlineChallengeEventString.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.PlotBought, plot.NameLocalised.ToString()));
		}

		public void LogEventRoomBuilt(int day, RoomDefinition room)
		{
			LogEvent(OnlineChallengeEventString.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.RoomBuilt, room.LocalisedName.Term));
		}

		public void LogEventLoanTaken(int day, LoanOffer loan)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.LoanTaken, loan.Amount));
		}

		public void LogEventChallenge(int day, VisitorDefinition visitor)
		{
			LogEvent(OnlineChallengeEventString.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.Challenge, visitor.Name.ToString()));
		}

		public void LogEventObjectiveStatus(int day, Objective.ObjectiveState state)
		{
			LogEvent(OnlineChallengeEventInt.Create(ClampChallengeDay(day), OnlineChallengeEvent.Event.ObjectiveStatus, (int)state));
		}

		public void LogEvent(OnlineChallengeEvent eventToLog)
		{
			EventStream.Add(eventToLog);
			if (eventToLog is OnlineChallengeEventScore item)
			{
				ScoreStream.Add(item);
			}
			OnDataUpdated.InvokeSafe(this);
		}

		public float GetScore(GameDate date)
		{
			int day = date.AsTotalDays() - _challengeStartDate;
			return GetScore(day);
		}

		public override float GetScore(int day)
		{
			int num = _scoreStream.FindLastIndex((OnlineChallengeEventScore data) => data.Day < day);
			if (num == -1)
			{
				num = 0;
			}
			if (num >= _scoreStream.Count)
			{
				return 0f;
			}
			return _scoreStream[num].Score;
		}

		public float GetInterpolatedScore(float completionFraction)
		{
			if (_scoreStream.Count == 0)
			{
				return 0f;
			}
			if (_scoreStream.Count == 1)
			{
				return _scoreStream[0].Score;
			}
			int num = _scoreStream.FindLastIndex((OnlineChallengeEventScore data) => (float)data.Day < completionFraction);
			if (num == -1)
			{
				num = 0;
			}
			if (num + 1 >= _scoreStream.Count)
			{
				num--;
			}
			OnlineChallengeEventScore onlineChallengeEventScore = _scoreStream[num];
			OnlineChallengeEventScore onlineChallengeEventScore2 = _scoreStream[num + 1];
			return Mathf.LerpUnclamped(t: Mathf.InverseLerp(onlineChallengeEventScore.Day, onlineChallengeEventScore2.Day, completionFraction), a: onlineChallengeEventScore.Score, b: onlineChallengeEventScore2.Score);
		}

		public float GetLastValidFrac()
		{
			if (_scoreStream.Count == 0)
			{
				return 0f;
			}
			return _scoreStream[_scoreStream.Count - 1].Day;
		}

		private int ClampChallengeDay(int day)
		{
			day = Mathf.Max(0, day);
			day = Mathf.Min(day, _challengeLength);
			return day;
		}
	}
}
