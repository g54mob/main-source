using System;
using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways;
using Motorways.Leaderboards;
using Motorways.Models;
using NotificationService.Events;
using UnityEngine;

public class MotorwaysExtendedUserProfile : BaseExtendedUserProfile, ICreatedInScopeHandler
{
	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MotorwaysExtendedUserProfile");

	private bool _isTapDrawEnabled;

	private const string IsTapDrawEnabledKey = "IsTapDraw";

	private const int DefaultControllerSensitivity = 2;

	private int _controllerSensitivity = 2;

	private const string ControllerSensitivityKey = "ControllerSensitivity";

	private bool _isDrawModeToggleEnabled;

	private const string IsDrawModeToggleEnabledKey = "IsDrawModeToggleEnabled";

	private bool _isTelemetryEnabled = true;

	private const string IsTelemetryEnabledKey = "IsTelemetryEnabled";

	private bool _doesHudStartLocked;

	private const string DoesHudStartLockedKey = "DoesHudStartLockedKey";

	private AchievementStatistics _achievementStatistics = new AchievementStatistics();

	private const string AchievementStatsKey = "AchievementStats";

	private const string PlayerColorblindPaletteIndexesKey = "PlayerColorblindPaletteIndexes";

	private List<int> _playerColorblindPaletteIndexes = new List<int> { 0, 1, 2, 3, 4, 5 };

	private readonly Dictionary<MapChallenge.ChallengeType, MotorwaysTimedChallengeScore> _allChallengeScores = new Dictionary<MapChallenge.ChallengeType, MotorwaysTimedChallengeScore>();

	private const string ChallengeScoreKey = "AllChallengeScores";

	private readonly List<CityChallengeStatistics> _cityChallengeStatistics = new List<CityChallengeStatistics>();

	private const string CityChallengeScoreKey = "AllCityChallengeScores";

	private readonly Dictionary<LeaderboardId, (int score, LeaderboardScoreState state)> _unsubmittedScores = new Dictionary<LeaderboardId, (int, LeaderboardScoreState)>();

	private readonly string UnsubmittedScoresKey = Caesar("UnsubmittedScores", 22);

	private const int StringDecodeKey = 22;

	private const int ScoreDecodeKey = 17;

	private NotificationEvent? _latestNotificationEvent;

	private List<NotificationEvent> _notificationEvents = new List<NotificationEvent>();

	private bool _areMenuMessagesEnabled = true;

	private const string AreMenuMessagesEnabledKey = "AreMenuMessagesEnabled";

	public bool IsTapDrawEnabled
	{
		get
		{
			return _isTapDrawEnabled;
		}
		set
		{
			if (_isTapDrawEnabled != value)
			{
				_isTapDrawEnabled = value;
				OnValueChanged();
			}
		}
	}

	public int ControllerSensitivity
	{
		get
		{
			return _controllerSensitivity;
		}
		set
		{
			if (_controllerSensitivity != value)
			{
				_controllerSensitivity = value;
				OnValueChanged();
			}
		}
	}

	public bool IsDrawModeToggleEnabled
	{
		get
		{
			return _isDrawModeToggleEnabled;
		}
		set
		{
			if (_isDrawModeToggleEnabled != value)
			{
				_isDrawModeToggleEnabled = value;
				OnValueChanged();
			}
		}
	}

	public bool IsTelemetryEnabled
	{
		get
		{
			return _isTelemetryEnabled;
		}
		set
		{
			if (_isTelemetryEnabled != value)
			{
				_isTelemetryEnabled = value;
				OnValueChanged();
			}
		}
	}

	public bool DoesHudStartLocked
	{
		get
		{
			return _doesHudStartLocked;
		}
		set
		{
			if (_doesHudStartLocked != value)
			{
				_doesHudStartLocked = value;
				OnValueChanged();
			}
		}
	}

	public AchievementStatistics AchievementStatistics
	{
		get
		{
			return _achievementStatistics;
		}
		set
		{
			_achievementStatistics = value;
		}
	}

	public List<int> PlayerColorblindPaletteIndexes
	{
		get
		{
			return _playerColorblindPaletteIndexes;
		}
		set
		{
			_playerColorblindPaletteIndexes = value;
			OnValueChanged();
		}
	}

	public IEnumerable<CityChallengeStatistics> CityChallengeStatisticsEnumerator => _cityChallengeStatistics;

	public NotificationEvent? LatestNotificationEvent => _latestNotificationEvent;

	public List<NotificationEvent> NotificationEvents => _notificationEvents;

	public bool AreMenuMessagesEnabled
	{
		get
		{
			return _areMenuMessagesEnabled;
		}
		set
		{
			if (_areMenuMessagesEnabled != value)
			{
				_areMenuMessagesEnabled = value;
				OnValueChanged();
			}
		}
	}

	protected override void LoadFromJson(JSON.Dictionary jsonDictionary)
	{
		base.LoadFromJson(jsonDictionary);
		JSON.Dictionary dictionary = jsonDictionary.GetDictionary("AllChallengeScores");
		LoadChallengeOfType(dictionary, MapChallenge.ChallengeType.Daily);
		LoadChallengeOfType(dictionary, MapChallenge.ChallengeType.Weekly);
		_areMenuMessagesEnabled = jsonDictionary.GetBool("AreMenuMessagesEnabled");
		_isTapDrawEnabled = jsonDictionary.GetBool("IsTapDraw");
		_controllerSensitivity = jsonDictionary.GetInt("ControllerSensitivity", 2);
		_isDrawModeToggleEnabled = jsonDictionary.GetBool("IsDrawModeToggleEnabled");
		_isTelemetryEnabled = jsonDictionary.GetBool("IsTelemetryEnabled", defaultValue: true);
		_doesHudStartLocked = jsonDictionary.GetBool("DoesHudStartLockedKey");
		LoadColorblindPaletteIndexFromJson(jsonDictionary.GetArray("PlayerColorblindPaletteIndexes"));
		LoadCityChallengeScoresFromJson(jsonDictionary.GetArray("AllCityChallengeScores"));
		LoadUnsubmittedScoresFromJson(jsonDictionary.GetDictionary(UnsubmittedScoresKey));
		JSON.Array array = jsonDictionary.GetArray("_notificationEvents");
		LoadGameNotificationEvents(array);
		JSON.Dictionary dictionary2 = jsonDictionary.GetDictionary("AchievementStats");
		_achievementStatistics.LoadFromJson(dictionary2);
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		base.SaveToJson(jsonDictionary);
		jsonDictionary["AllChallengeScores"] = GenerateChallengeScoreJson();
		jsonDictionary["_notificationEvents"] = GenerateGameNotificationJson();
		jsonDictionary["AreMenuMessagesEnabled"] = _areMenuMessagesEnabled;
		jsonDictionary["IsTapDraw"] = _isTapDrawEnabled;
		jsonDictionary["ControllerSensitivity"] = _controllerSensitivity;
		jsonDictionary["IsDrawModeToggleEnabled"] = _isDrawModeToggleEnabled;
		jsonDictionary["IsTelemetryEnabled"] = _isTelemetryEnabled;
		jsonDictionary["DoesHudStartLockedKey"] = _doesHudStartLocked;
		jsonDictionary["PlayerColorblindPaletteIndexes"] = _playerColorblindPaletteIndexes;
		jsonDictionary["AllCityChallengeScores"] = GenerateCityChallengeScoresJson();
		jsonDictionary["AchievementStats"] = _achievementStatistics.Save();
		jsonDictionary[UnsubmittedScoresKey] = GenerateUnsubmittedScoresJson();
	}

	public void LoadColorblindPaletteIndexFromJson(JSON.Array indexArray)
	{
		if (indexArray != null && indexArray.Count > 0)
		{
			_playerColorblindPaletteIndexes.Clear();
			for (int i = 0; i < indexArray.Count; i++)
			{
				int item = indexArray.GetInt(i);
				_playerColorblindPaletteIndexes.Add(item);
			}
		}
	}

	private void LoadChallengeOfType(JSON.Dictionary statsJson, MapChallenge.ChallengeType challengeType)
	{
		MotorwaysTimedChallengeScore motorwaysTimedChallengeScore = _scope.Get<MotorwaysTimedChallengeScore>();
		motorwaysTimedChallengeScore.DataChanged += OnChallengeScoreChanged;
		JSON.Dictionary dictionary = statsJson?.GetDictionary(challengeType.ToString());
		if (dictionary != null)
		{
			motorwaysTimedChallengeScore.InitFromJson(dictionary, challengeType);
		}
		_allChallengeScores[challengeType] = motorwaysTimedChallengeScore;
	}

	private void OnChallengeScoreChanged(MotorwaysTimedChallengeScore _)
	{
		OnValueChanged();
	}

	[NotNull]
	public MotorwaysTimedChallengeScore GetChallengeScore(MapChallenge.ChallengeType challengeType, int expiry)
	{
		if (_allChallengeScores.TryGetValue(challengeType, out var value))
		{
			if (value.Expiry < expiry)
			{
				value.Init(challengeType, expiry);
			}
			return value;
		}
		MotorwaysTimedChallengeScore motorwaysTimedChallengeScore = _scope.Get<MotorwaysTimedChallengeScore>();
		motorwaysTimedChallengeScore.DataChanged += OnChallengeScoreChanged;
		motorwaysTimedChallengeScore.Init(challengeType, expiry);
		_allChallengeScores[challengeType] = motorwaysTimedChallengeScore;
		return motorwaysTimedChallengeScore;
	}

	private Dictionary<string, object> GenerateChallengeScoreJson()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<MapChallenge.ChallengeType, MotorwaysTimedChallengeScore> allChallengeScore in _allChallengeScores)
		{
			if (!allChallengeScore.Value.HasScoreExpired)
			{
				dictionary[allChallengeScore.Key.ToString()] = allChallengeScore.Value.ToJson();
			}
		}
		return dictionary;
	}

	public CityChallengeStatistics GetCityChallengeScore(string cityId, GameMode mode, int challengeIndex, bool createIfEmpty = true)
	{
		foreach (CityChallengeStatistics cityChallengeStatistic in _cityChallengeStatistics)
		{
			if (cityChallengeStatistic.CityId == cityId && cityChallengeStatistic.Mode == mode && cityChallengeStatistic.ChallengeIndex == challengeIndex)
			{
				return cityChallengeStatistic;
			}
		}
		if (createIfEmpty)
		{
			CityChallengeStatistics cityChallengeStatistics = new CityChallengeStatistics(cityId, mode, challengeIndex);
			cityChallengeStatistics.DataChanged += base.OnValueChanged;
			_cityChallengeStatistics.Add(cityChallengeStatistics);
			return cityChallengeStatistics;
		}
		return null;
	}

	public IEnumerable<CityChallengeStatistics> GetCityChallengeScores(string cityId, GameMode mode)
	{
		foreach (CityChallengeStatistics cityChallengeStatistic in _cityChallengeStatistics)
		{
			if (cityChallengeStatistic.CityId == cityId && cityChallengeStatistic.Mode == mode)
			{
				yield return cityChallengeStatistic;
			}
		}
	}

	public void LoadCityChallengeScoresFromJson(JSON.Array challengeScores)
	{
		if (challengeScores != null)
		{
			for (int i = 0; i < challengeScores.Count; i++)
			{
				CityChallengeStatistics cityChallengeStatistics = CityChallengeStatistics.InitFromJson(challengeScores[i] as JSON.Dictionary);
				cityChallengeStatistics.DataChanged += base.OnValueChanged;
				_cityChallengeStatistics.Add(cityChallengeStatistics);
			}
		}
	}

	public List<object> GenerateCityChallengeScoresJson()
	{
		List<object> list = new List<object>();
		foreach (CityChallengeStatistics cityChallengeStatistic in _cityChallengeStatistics)
		{
			list.Add(cityChallengeStatistic.ToJson());
		}
		return list;
	}

	public void LogUnsubmittedScore(LeaderboardId leaderboardId, int scoreToSubmitLater, LeaderboardScoreState state)
	{
		if (_unsubmittedScores.TryGetValue(leaderboardId, out (int, LeaderboardScoreState) value))
		{
			if (value.Item2 != LeaderboardScoreState.Locked)
			{
				_unsubmittedScores[leaderboardId] = (Mathf.Max(scoreToSubmitLater, value.Item1), state);
			}
		}
		else
		{
			_unsubmittedScores.Add(leaderboardId, (scoreToSubmitLater, state));
		}
		OnValueChanged();
	}

	public IEnumerable<(LeaderboardId, int, LeaderboardScoreState)> GetAndClearUnsubmittedScores()
	{
		List<(LeaderboardId, int, LeaderboardScoreState)> list = new List<(LeaderboardId, int, LeaderboardScoreState)>();
		foreach (KeyValuePair<LeaderboardId, (int, LeaderboardScoreState)> unsubmittedScore in _unsubmittedScores)
		{
			LeaderboardId key = unsubmittedScore.Key;
			bool flag = true;
			if (key is RecurringLeaderboardId recurringLeaderboardId)
			{
				flag = recurringLeaderboardId.IsLeaderboardOpen();
			}
			if (flag)
			{
				list.Add((key, unsubmittedScore.Value.Item1, unsubmittedScore.Value.Item2));
			}
		}
		_unsubmittedScores.Clear();
		OnValueChanged();
		return list;
	}

	public IEnumerable<(LeaderboardId, int, LeaderboardScoreState)> GetUnsubmittedScores()
	{
		foreach (KeyValuePair<LeaderboardId, (int, LeaderboardScoreState)> unsubmittedScore in _unsubmittedScores)
		{
			yield return (unsubmittedScore.Key, unsubmittedScore.Value.Item1, unsubmittedScore.Value.Item2);
		}
	}

	public void MarkScoreAsSubmitted(LeaderboardId leaderboardId)
	{
		if (_unsubmittedScores.ContainsKey(leaderboardId))
		{
			_unsubmittedScores.Remove(leaderboardId);
			OnValueChanged();
		}
	}

	private Dictionary<string, object> GenerateUnsubmittedScoresJson()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<LeaderboardId, (int, LeaderboardScoreState)> unsubmittedScore in _unsubmittedScores)
		{
			string text = Caesar(unsubmittedScore.Value.Item1.ToString(), 17);
			dictionary.Add(Caesar(unsubmittedScore.Key.SerializedString, 22), new object[2]
			{
				text,
				(int)unsubmittedScore.Value.Item2
			});
		}
		return dictionary;
	}

	private void LoadUnsubmittedScoresFromJson(JSON.Dictionary unsubmittedScoresJson)
	{
		if (unsubmittedScoresJson == null)
		{
			return;
		}
		_unsubmittedScores.Clear();
		foreach (string key in unsubmittedScoresJson.Keys)
		{
			JSON.Array array = unsubmittedScoresJson.GetArray(key);
			if (array == null || array.Count != 2)
			{
				continue;
			}
			string text = array.GetString(0);
			if (text == null)
			{
				continue;
			}
			text = Caesar(text, -17);
			LeaderboardScoreState item = (LeaderboardScoreState)array.GetInt(1);
			if (int.TryParse(text, out var result) && result > 0)
			{
				LeaderboardId leaderboardId = LeaderboardId.Deserialize(Caesar(key, -22));
				if (leaderboardId != null)
				{
					_unsubmittedScores.Add(leaderboardId, (result, item));
				}
			}
		}
	}

	public void ClearOldNotificationEvents()
	{
	}

	public void AddGameNotificationEvent(NotificationEvent notificationEvent)
	{
		notificationEvent.Id = _notificationEvents.Count;
		_notificationEvents.Add(notificationEvent);
		UpdateLatestEvent(notificationEvent);
		OnValueChanged();
	}

	public void UpdateGameNotificationEventWithId(int id, NotificationEvent updatedNotificationEvent)
	{
		updatedNotificationEvent.Id = id;
		_notificationEvents[id] = updatedNotificationEvent;
		UpdateLatestEvent(updatedNotificationEvent);
		OnValueChanged();
	}

	public void RemoveAllGameNotificationsEvents()
	{
		_latestNotificationEvent = null;
		_notificationEvents.Clear();
		OnValueChanged();
	}

	private void UpdateLatestEvent(NotificationEvent newNotificationEvent)
	{
		if (!_latestNotificationEvent.HasValue)
		{
			_latestNotificationEvent = newNotificationEvent;
		}
		else if (newNotificationEvent.OccuredAt > _latestNotificationEvent.Value.OccuredAt)
		{
			_latestNotificationEvent = newNotificationEvent;
		}
	}

	private void LoadGameNotificationEvents(JSON.Array jsonArray)
	{
		if (jsonArray == null)
		{
			return;
		}
		for (int i = 0; i < jsonArray.Count; i++)
		{
			if (jsonArray[i] is JSON.Dictionary jsonDictionary)
			{
				NotificationEvent? notificationEvent = LoadGameNotificationEvent(jsonDictionary);
				if (notificationEvent.HasValue)
				{
					NotificationEvent value = notificationEvent.Value;
					value.Id = _notificationEvents.Count;
					_notificationEvents.Add(value);
					UpdateLatestEvent(value);
				}
			}
		}
	}

	private NotificationEvent? LoadGameNotificationEvent(JSON.Dictionary jsonDictionary)
	{
		if (!jsonDictionary.ContainsKey("OccuredAt") || !jsonDictionary.ContainsKey("EventType"))
		{
			Log.Warn("OccuredAt or EventType not saved with notification event. Skipping...");
			return null;
		}
		DateTime dateTime = jsonDictionary.GetDateTime("OccuredAt");
		string text = jsonDictionary.GetString("EventType");
		Type type = Type.GetType(text);
		if (type == null)
		{
			Log.Warn("Unknown eventType {0} when loading game notification event. Skipping...", text);
			return null;
		}
		INotificationEventType notificationEventType = Activator.CreateInstance(type) as INotificationEventType;
		if (notificationEventType is INotificationEventTypeWithData notificationEventTypeWithData && !notificationEventTypeWithData.InitFromJson(jsonDictionary))
		{
			Log.Warn("Error while loading data for notification event {0}. Skipping...", text);
			return null;
		}
		NotificationEvent value = new NotificationEvent(dateTime, notificationEventType);
		value.Id = _notificationEvents.Count;
		return value;
	}

	private List<object> GenerateGameNotificationJson()
	{
		List<object> list = new List<object>();
		foreach (NotificationEvent notificationEvent in _notificationEvents)
		{
			Dictionary<string, object> json = new Dictionary<string, object>
			{
				["EventType"] = notificationEvent.EventType.GetType().FullName,
				["OccuredAt"] = notificationEvent.OccuredAt
			};
			if (notificationEvent.EventType is INotificationEventTypeWithData notificationEventTypeWithData)
			{
				notificationEventTypeWithData.ToJson(ref json);
			}
			list.Add(json);
		}
		return list;
	}

	public override void RecordGameStatistics(IGameStatistics gameStatistics)
	{
		if (gameStatistics is MotorwaysGameStatistics { Challenge: not null } motorwaysGameStatistics && motorwaysGameStatistics.Challenge.HasChallenges && (motorwaysGameStatistics.Challenge.challengeType == MapChallenge.ChallengeType.Daily || motorwaysGameStatistics.Challenge.challengeType == MapChallenge.ChallengeType.Weekly))
		{
			ActiveChallengesModel challenge = motorwaysGameStatistics.Challenge;
			if (challenge.IsActive)
			{
				GetChallengeScore(challenge.challengeType, challenge.timeEnd).UpdateGameScore(motorwaysGameStatistics.TotalTrips, motorwaysGameStatistics.GameEndReason);
			}
		}
	}

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		base.MergeValues(otherSaveData);
		if (!(otherSaveData is MotorwaysExtendedUserProfile motorwaysExtendedUserProfile))
		{
			return;
		}
		foreach (KeyValuePair<MapChallenge.ChallengeType, MotorwaysTimedChallengeScore> allChallengeScore in motorwaysExtendedUserProfile._allChallengeScores)
		{
			GetChallengeScore(allChallengeScore.Key, allChallengeScore.Value.Expiry).Merge(allChallengeScore.Value);
		}
		foreach (CityChallengeStatistics cityChallengeStatistic in motorwaysExtendedUserProfile._cityChallengeStatistics)
		{
			GetCityChallengeScore(cityChallengeStatistic.CityId, cityChallengeStatistic.Mode, cityChallengeStatistic.ChallengeIndex).Merge(cityChallengeStatistic);
		}
		foreach (KeyValuePair<LeaderboardId, (int, LeaderboardScoreState)> unsubmittedScore in motorwaysExtendedUserProfile._unsubmittedScores)
		{
			if (_unsubmittedScores.TryGetValue(unsubmittedScore.Key, out (int, LeaderboardScoreState) value))
			{
				if ((value.Item2 != LeaderboardScoreState.Locked || unsubmittedScore.Value.Item2 == LeaderboardScoreState.Locked) && (value.Item1 < unsubmittedScore.Value.Item1 || unsubmittedScore.Value.Item2 == LeaderboardScoreState.Locked))
				{
					_unsubmittedScores[unsubmittedScore.Key] = (unsubmittedScore.Value.Item1, unsubmittedScore.Value.Item2);
				}
			}
			else
			{
				_unsubmittedScores.Add(unsubmittedScore.Key, (unsubmittedScore.Value.Item1, unsubmittedScore.Value.Item2));
			}
		}
		int count = _notificationEvents.Count;
		foreach (NotificationEvent notificationEvent2 in motorwaysExtendedUserProfile._notificationEvents)
		{
			bool flag = true;
			for (int i = 0; i < count; i++)
			{
				NotificationEvent notificationEvent = _notificationEvents[i];
				if (notificationEvent2.OccuredAt == notificationEvent.OccuredAt && notificationEvent2.EventType.Matches(notificationEvent.EventType))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				_notificationEvents.Add(notificationEvent2);
			}
		}
		AreMenuMessagesEnabled = ChooseLatest(_areMenuMessagesEnabled, motorwaysExtendedUserProfile._areMenuMessagesEnabled, motorwaysExtendedUserProfile.UtcTimestamp);
		DoesHudStartLocked = ChooseLatest(_doesHudStartLocked, motorwaysExtendedUserProfile._doesHudStartLocked, motorwaysExtendedUserProfile.UtcTimestamp);
		IsTapDrawEnabled = ChooseLatest(_isTapDrawEnabled, motorwaysExtendedUserProfile._isTapDrawEnabled, motorwaysExtendedUserProfile.UtcTimestamp);
		ControllerSensitivity = ChooseLatest(_controllerSensitivity, motorwaysExtendedUserProfile._controllerSensitivity, motorwaysExtendedUserProfile.UtcTimestamp);
		IsDrawModeToggleEnabled = ChooseLatest(_isDrawModeToggleEnabled, motorwaysExtendedUserProfile._isDrawModeToggleEnabled, motorwaysExtendedUserProfile.UtcTimestamp);
		IsTelemetryEnabled = ChooseLatest(_isTelemetryEnabled, motorwaysExtendedUserProfile._isTelemetryEnabled, motorwaysExtendedUserProfile.UtcTimestamp);
		PlayerColorblindPaletteIndexes = ChooseLatest(_playerColorblindPaletteIndexes, motorwaysExtendedUserProfile._playerColorblindPaletteIndexes, motorwaysExtendedUserProfile.UtcTimestamp);
		_achievementStatistics.Merge(motorwaysExtendedUserProfile.AchievementStatistics, base.UtcTimestamp, motorwaysExtendedUserProfile.UtcTimestamp);
	}

	public static string Caesar(string source, short shift)
	{
		int num = Convert.ToInt32('\uffff');
		int num2 = Convert.ToInt32('\0');
		char[] array = source.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			int num3 = Convert.ToInt32(array[i]) + shift;
			if (num3 > num)
			{
				num3 -= num;
			}
			else if (num3 < num2)
			{
				num3 += num;
			}
			array[i] = Convert.ToChar(num3);
		}
		return new string(array);
	}

	public void OnCreatedInScope(IScope scope)
	{
		_achievementStatistics.DataChanged += base.OnValueChanged;
	}
}
