using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using com.dinopoloclub.analytics;

public abstract class BaseExtendedUserProfile : ForwardCompatibleJsonSaveData, IExtendedUserProfile, IJsonSerializableSaveData, IStorable
{
	[Dependency]
	protected IScope _scope;

	public const int InvalidAvatarColorIndex = -1;

	public const int InvalidAvatarIconIndex = -1;

	private const string iCloudProvenanceKey = "iCloudProvenance";

	private const string ProfileBackgroundIndexKey = "ProfileBackgroundIndex";

	private const string ProfileIconIndexKey = "ProfileIconIndex";

	private const string LastTimeDailyChallengeSeenKey = "LastTimeDailyChallengeSeen";

	private const string LastTimeWeeklyChallengeSeenKey = "LastTimeWeeklyChallengeSeen";

	private const string CreativeInGameMessageSeenKey = "CreativeInGameMessageSeen";

	private const string AnalyticsConsentStateKey = "AnalyticsConsentState";

	private const string IsFirstSessionKey = "IsFirstSessionKey";

	private int _avatarColorIndex = -1;

	private int _avatarIconIndex = -1;

	private iCloudProvenance _iCloudProvenance;

	private int _lastTimeDailyChallengeSeen;

	private int _lastTimeWeeklyChallengeSeen;

	private bool _creativeInGameMessageSeen;

	private AnalyticsService.ConsentState _analyticsConsentState;

	private bool? _isFirstSession;

	private readonly HashSet<string> _seenNewContentIDs = new HashSet<string>();

	private readonly Dictionary<string, GameMode> _selectedGameMode = new Dictionary<string, GameMode>();

	public int Version { get; }

	public Player Player { get; set; }

	public int AvatarColorIndex
	{
		get
		{
			return _avatarColorIndex;
		}
		set
		{
			if (_avatarColorIndex != value)
			{
				_avatarColorIndex = value;
				OnValueChanged();
			}
		}
	}

	public int AvatarIconIndex
	{
		get
		{
			return _avatarIconIndex;
		}
		set
		{
			if (_avatarIconIndex != value)
			{
				_avatarIconIndex = value;
				OnValueChanged();
			}
		}
	}

	public iCloudProvenance iCloudProvenance
	{
		get
		{
			return _iCloudProvenance;
		}
		set
		{
			if (_iCloudProvenance != value)
			{
				_iCloudProvenance = value;
				OnValueChanged();
			}
		}
	}

	public int LastTimeDailyChallengeSeen
	{
		get
		{
			return _lastTimeDailyChallengeSeen;
		}
		set
		{
			if (_lastTimeDailyChallengeSeen != value)
			{
				_lastTimeDailyChallengeSeen = value;
				OnValueChanged();
			}
		}
	}

	public int LastTimeWeeklyChallengeSeen
	{
		get
		{
			return _lastTimeWeeklyChallengeSeen;
		}
		set
		{
			if (_lastTimeWeeklyChallengeSeen != value)
			{
				_lastTimeWeeklyChallengeSeen = value;
				OnValueChanged();
			}
		}
	}

	public bool CreativeInGameMessageSeen
	{
		get
		{
			return _creativeInGameMessageSeen;
		}
		set
		{
			if (_creativeInGameMessageSeen != value)
			{
				_creativeInGameMessageSeen = value;
				OnValueChanged();
			}
		}
	}

	public AnalyticsService.ConsentState AnalyticsConsentState
	{
		get
		{
			return _analyticsConsentState;
		}
		set
		{
			if (_analyticsConsentState != value)
			{
				_analyticsConsentState = value;
				OnValueChanged();
			}
		}
	}

	public bool? IsFirstSession
	{
		get
		{
			return _isFirstSession;
		}
		set
		{
			if (_isFirstSession != value)
			{
				_isFirstSession = value;
				OnValueChanged();
			}
		}
	}

	public bool HasSeenNewContent(string newContentId)
	{
		return _seenNewContentIDs.Contains(newContentId);
	}

	public GameMode GetSelectedModeForMap(string mapId)
	{
		if (_selectedGameMode.ContainsKey(mapId))
		{
			return _selectedGameMode[mapId];
		}
		_selectedGameMode[mapId] = GameMode.Normal;
		return _selectedGameMode[mapId];
	}

	public void SetSelectedGameModeForMap(string mapId, GameMode gameMode)
	{
		_selectedGameMode[mapId] = gameMode;
		OnValueChanged();
	}

	public void SetNewContentSeen(string newContentId)
	{
		if (!_seenNewContentIDs.Contains(newContentId))
		{
			_seenNewContentIDs.Add(newContentId);
			OnValueChanged();
		}
	}

	public void ClearNewContentSeen(string specificContent = null)
	{
		if (_seenNewContentIDs.Count > 0)
		{
			if (string.IsNullOrWhiteSpace(specificContent))
			{
				_seenNewContentIDs.Clear();
			}
			else
			{
				_seenNewContentIDs.Remove(specificContent);
			}
			OnValueChanged();
		}
	}

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		if (!(otherSaveData is BaseExtendedUserProfile baseExtendedUserProfile))
		{
			return;
		}
		iCloudProvenance = ChooseMax(_iCloudProvenance, baseExtendedUserProfile._iCloudProvenance);
		AvatarColorIndex = ChooseLatest(_avatarColorIndex, baseExtendedUserProfile._avatarColorIndex, baseExtendedUserProfile.UtcTimestamp);
		AvatarIconIndex = ChooseLatest(_avatarIconIndex, baseExtendedUserProfile._avatarIconIndex, baseExtendedUserProfile.UtcTimestamp);
		LastTimeDailyChallengeSeen = ChooseMax(_lastTimeDailyChallengeSeen, baseExtendedUserProfile._lastTimeDailyChallengeSeen);
		LastTimeWeeklyChallengeSeen = ChooseMax(_lastTimeWeeklyChallengeSeen, baseExtendedUserProfile._lastTimeWeeklyChallengeSeen);
		CreativeInGameMessageSeen = _creativeInGameMessageSeen || baseExtendedUserProfile._creativeInGameMessageSeen;
		AnalyticsConsentState = ChooseLatest(_analyticsConsentState, baseExtendedUserProfile._analyticsConsentState, baseExtendedUserProfile.UtcTimestamp);
		IsFirstSession = ChooseLatest(_isFirstSession, baseExtendedUserProfile._isFirstSession, baseExtendedUserProfile.UtcTimestamp);
		int count = _seenNewContentIDs.Count;
		_seenNewContentIDs.UnionWith(baseExtendedUserProfile._seenNewContentIDs);
		if (count != _seenNewContentIDs.Count)
		{
			OnValueChanged();
		}
		foreach (KeyValuePair<string, GameMode> item in baseExtendedUserProfile._selectedGameMode)
		{
			_selectedGameMode[item.Key] = item.Value;
		}
	}

	protected override void LoadFromJson(JSON.Dictionary jsonDictionary)
	{
		_iCloudProvenance = (iCloudProvenance)jsonDictionary.GetInt("iCloudProvenance");
		_avatarColorIndex = jsonDictionary.GetInt("ProfileBackgroundIndex");
		_avatarIconIndex = jsonDictionary.GetInt("ProfileIconIndex");
		_lastTimeDailyChallengeSeen = jsonDictionary.GetInt("LastTimeDailyChallengeSeen");
		_lastTimeWeeklyChallengeSeen = jsonDictionary.GetInt("LastTimeWeeklyChallengeSeen");
		_creativeInGameMessageSeen = jsonDictionary.GetBool("CreativeInGameMessageSeen");
		_analyticsConsentState = (AnalyticsService.ConsentState)jsonDictionary.GetInt("AnalyticsConsentState");
		_isFirstSession = jsonDictionary.GetBool("IsFirstSessionKey");
		JSON.Array array = jsonDictionary.GetArray("_seenNewContentIDs");
		if (array != null)
		{
			for (int i = 0; i < array.Count; i++)
			{
				string text = array.GetString(i);
				if (text != null && CanLoadSeenContentId(text))
				{
					_seenNewContentIDs.Add(text);
				}
			}
		}
		JSON.Dictionary dictionary = jsonDictionary.GetDictionary("_selectedGameMode");
		if (dictionary == null)
		{
			return;
		}
		foreach (string key in dictionary.Keys)
		{
			_selectedGameMode[key] = GameMode.Normal;
			string value = dictionary.GetString(key);
			if (!string.IsNullOrEmpty(value) && Diagnostics.Verify(Enum.TryParse<GameMode>(value, out var result), "{0} is not a valid game mode! Setting to Normal.", result))
			{
				_selectedGameMode[key] = result;
			}
		}
	}

	private bool CanLoadSeenContentId(string idString)
	{
		if (idString.StartsWith("NewWeeklyChallenge-"))
		{
			if (!long.TryParse(idString.Remove(0, "NewWeeklyChallenge-".Length), out var result))
			{
				return false;
			}
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(result);
			if (GameDateTime.UtcNow.Subtract(TimeSpan.FromDays(8.0)) > dateTimeOffset)
			{
				return false;
			}
		}
		else if (idString.StartsWith("NewDailyChallenge-"))
		{
			if (!long.TryParse(idString.Remove(0, "NewDailyChallenge-".Length), out var result2))
			{
				return false;
			}
			DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeSeconds(result2);
			if (GameDateTime.UtcNow.Subtract(TimeSpan.FromDays(2.0)) > dateTimeOffset2)
			{
				return false;
			}
		}
		return true;
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		jsonDictionary["iCloudProvenance"] = (int)_iCloudProvenance;
		jsonDictionary["ProfileBackgroundIndex"] = _avatarColorIndex;
		jsonDictionary["ProfileIconIndex"] = _avatarIconIndex;
		jsonDictionary["LastTimeDailyChallengeSeen"] = _lastTimeDailyChallengeSeen;
		jsonDictionary["LastTimeWeeklyChallengeSeen"] = _lastTimeWeeklyChallengeSeen;
		jsonDictionary["CreativeInGameMessageSeen"] = _creativeInGameMessageSeen;
		jsonDictionary["AnalyticsConsentState"] = (int)_analyticsConsentState;
		jsonDictionary["IsFirstSessionKey"] = _isFirstSession;
		List<object> list = new List<object>(_seenNewContentIDs.Count);
		foreach (string seenNewContentID in _seenNewContentIDs)
		{
			list.Add(seenNewContentID);
		}
		jsonDictionary["_seenNewContentIDs"] = list;
		jsonDictionary["_selectedGameMode"] = _selectedGameMode;
	}

	public abstract void RecordGameStatistics(IGameStatistics gameStatistics);
}
