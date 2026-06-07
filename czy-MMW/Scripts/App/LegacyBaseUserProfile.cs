using System;
using System.Collections.Generic;
using Factory;

public abstract class LegacyBaseUserProfile : ForwardCompatibleJsonSaveData, ILegacyUserProfile, IJsonSerializableSaveData, IStorable
{
	public enum UserProfileSerializationVersion
	{
		InitialVersion = 0,
		Latest = 1
	}

	private List<Achievement> _achievements = new List<Achievement>();

	[Dependency]
	protected IScope _scope;

	[Dependency]
	protected IAchievementHandler _achievementHandler;

	private static string VersionKey = "_version";

	private static string AchievementsKey = "_achievements";

	private static string VibrationKey = "IsVibrationEnabled";

	private bool _isVibrationEnabled;

	private int _version = 1;

	public const string DisplayAchievementDialogBoxEditorPref = "DisplayAchievementDialogBoxEditorPref";

	public List<Achievement> Achievements => _achievements;

	public Player Player { get; set; }

	public bool IsVibrationEnabled
	{
		get
		{
			return _isVibrationEnabled;
		}
		set
		{
			if (_isVibrationEnabled != value)
			{
				_isVibrationEnabled = value;
				OnValueChanged();
			}
		}
	}

	public int Version => _version;

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		if (!(otherSaveData is LegacyBaseUserProfile legacyBaseUserProfile))
		{
			return;
		}
		IsVibrationEnabled = ChooseLatest(_isVibrationEnabled, legacyBaseUserProfile._isVibrationEnabled, legacyBaseUserProfile.UtcTimestamp);
		foreach (Achievement theirAchievement in legacyBaseUserProfile._achievements)
		{
			Achievement achievement = _achievements.Find((Achievement achievement2) => achievement2.Id == theirAchievement.Id);
			if (achievement != null)
			{
				if (achievement.Merge(theirAchievement))
				{
					OnValueChanged();
				}
			}
			else
			{
				_achievements.Add(theirAchievement);
				OnValueChanged();
			}
		}
	}

	protected override void LoadFromJson(JSON.Dictionary jsonDictionary)
	{
		_version = jsonDictionary.GetInt(VersionKey);
		JSON.Array array = jsonDictionary.GetArray(AchievementsKey);
		if (array != null)
		{
			_achievements = new List<Achievement>(array.Count);
			for (int i = 0; i < array.Count; i++)
			{
				Achievement achievement = _scope.Get<Achievement>();
				achievement.InitFromJson(array.GetDictionary(i));
				_achievements.Add(achievement);
			}
		}
		_isVibrationEnabled = jsonDictionary.GetBool(VibrationKey, defaultValue: true);
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		jsonDictionary[VersionKey] = _version;
		List<object> list = new List<object>();
		for (int i = 0; i < _achievements.Count; i++)
		{
			list.Add(_achievements[i].ToJson());
		}
		jsonDictionary[AchievementsKey] = list;
		jsonDictionary[VibrationKey] = _isVibrationEnabled;
	}

	public bool IsAchievementCompleted(AchievementDefinition achievementDefinition)
	{
		for (int i = 0; i < _achievements.Count; i++)
		{
			if (_achievements[i].Id.Equals(achievementDefinition.Id, StringComparison.InvariantCultureIgnoreCase))
			{
				return _achievements[i].IsComplete();
			}
		}
		return false;
	}

	public void CompleteAchievement(AchievementDefinition achievementDefinition, bool showNotification)
	{
		Achievement achievement = null;
		for (int i = 0; i < _achievements.Count; i++)
		{
			if (_achievements[i].Id.Equals(achievementDefinition.Id, StringComparison.InvariantCultureIgnoreCase))
			{
				achievement = _achievements[i];
				break;
			}
		}
		if (achievement == null)
		{
			achievement = _scope.Get<Achievement>();
			achievement.InitFromDefinition(achievementDefinition);
			_achievements.Add(achievement);
		}
		if (!achievement.IsComplete())
		{
			achievement.SetComplete(isComplete: true);
			OnValueChanged();
		}
		if (!_achievementHandler.IsAchievementCompleted(achievement.Definition))
		{
			_achievementHandler.CompleteAchievement(achievement, showNotification);
		}
	}

	public void RemoveAchievement(AchievementDefinition achievementDefinition)
	{
		Achievement achievement = null;
		for (int i = 0; i < _achievements.Count; i++)
		{
			if (_achievements[i].Id.Equals(achievementDefinition.Id, StringComparison.InvariantCultureIgnoreCase))
			{
				achievement = _achievements[i];
				break;
			}
		}
		if (achievement != null && achievement.IsComplete())
		{
			achievement.SetComplete(isComplete: false);
			OnValueChanged();
		}
	}

	public abstract void RecordGameStatistics(IGameStatistics gameStatistics);
}
