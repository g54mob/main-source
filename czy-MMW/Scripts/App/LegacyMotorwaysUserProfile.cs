using System.Collections.Generic;
using Motorways;
using Motorways.Processes;

public class LegacyMotorwaysUserProfile : LegacyBaseUserProfile
{
	private readonly List<MotorwaysCityStatistics> _allCityStatistics = new List<MotorwaysCityStatistics>();

	private TutorialProgressionProcess.TutorialType _completedTutorials;

	private bool _isColorblindModeEnabled;

	private bool _isSkipTransitionsEnabled;

	private static string ColorblindModeKey = "ColorBlindMode";

	private static string SkipTransitionsKey = "SkipTransitions";

	private static string CityStatisticsKey = "allCityStatistics";

	private static string CompletedTutorialsKey = "completedTutorials";

	public bool IsColorblindModeEnabled
	{
		get
		{
			return _isColorblindModeEnabled;
		}
		set
		{
			if (_isColorblindModeEnabled != value)
			{
				_isColorblindModeEnabled = value;
				OnValueChanged();
			}
		}
	}

	public bool IsSkipTransitionsEnabled
	{
		get
		{
			return _isSkipTransitionsEnabled;
		}
		set
		{
			if (_isSkipTransitionsEnabled != value)
			{
				_isSkipTransitionsEnabled = value;
				OnValueChanged();
			}
		}
	}

	public int TotalPlayTime
	{
		get
		{
			int num = 0;
			foreach (MotorwaysCityStatistics allCityStatistic in _allCityStatistics)
			{
				num += allCityStatistic.TotalPlayTime;
			}
			return num;
		}
	}

	protected override void LoadFromJson(JSON.Dictionary jsonDictionary)
	{
		base.LoadFromJson(jsonDictionary);
		JSON.Array array = jsonDictionary.GetArray(CityStatisticsKey);
		if (array != null)
		{
			for (int i = 0; i < array.Count; i++)
			{
				MotorwaysCityStatistics motorwaysCityStatistics = _scope.Get<MotorwaysCityStatistics>();
				motorwaysCityStatistics.DataChanged += OnCityStatisticsChanged;
				motorwaysCityStatistics.InitFromJson(array[i] as JSON.Dictionary);
				_allCityStatistics.Add(motorwaysCityStatistics);
			}
		}
		_completedTutorials = (TutorialProgressionProcess.TutorialType)jsonDictionary.GetInt(CompletedTutorialsKey);
		_isColorblindModeEnabled = jsonDictionary.GetBool(ColorblindModeKey);
		_isSkipTransitionsEnabled = jsonDictionary.GetBool(SkipTransitionsKey);
	}

	protected override void SaveToJson(Dictionary<string, object> jsonDictionary)
	{
		base.SaveToJson(jsonDictionary);
		List<object> list = new List<object>();
		foreach (MotorwaysCityStatistics allCityStatistic in _allCityStatistics)
		{
			list.Add(allCityStatistic.ToJson());
		}
		jsonDictionary[CityStatisticsKey] = list;
		jsonDictionary[CompletedTutorialsKey] = (int)_completedTutorials;
		jsonDictionary[ColorblindModeKey] = _isColorblindModeEnabled;
		jsonDictionary[SkipTransitionsKey] = _isSkipTransitionsEnabled;
	}

	protected override void MergeValues(ForwardCompatibleJsonSaveData otherSaveData)
	{
		base.MergeValues(otherSaveData);
		if (!(otherSaveData is LegacyMotorwaysUserProfile legacyMotorwaysUserProfile))
		{
			return;
		}
		IsColorblindModeEnabled = ChooseLatest(_isColorblindModeEnabled, legacyMotorwaysUserProfile._isColorblindModeEnabled, legacyMotorwaysUserProfile.UtcTimestamp);
		IsSkipTransitionsEnabled = ChooseLatest(_isSkipTransitionsEnabled, legacyMotorwaysUserProfile._isSkipTransitionsEnabled, legacyMotorwaysUserProfile.UtcTimestamp);
		TutorialProgressionProcess.TutorialType completedTutorials = _completedTutorials;
		_completedTutorials |= legacyMotorwaysUserProfile._completedTutorials;
		if (_completedTutorials != completedTutorials)
		{
			OnValueChanged();
		}
		foreach (MotorwaysCityStatistics allCityStatistic in legacyMotorwaysUserProfile._allCityStatistics)
		{
			GetCityStatisticsForCity(allCityStatistic.CityId, allCityStatistic.Mode, createIfNecessary: true).Merge(allCityStatistic);
		}
	}

	public void SetTutorialTypeComplete(TutorialProgressionProcess.TutorialType completedType)
	{
		if ((_completedTutorials & completedType) == 0)
		{
			_completedTutorials |= completedType;
			OnValueChanged();
		}
	}

	public bool IsTutorialTypeCompleted(TutorialProgressionProcess.TutorialType completedType)
	{
		return (_completedTutorials & completedType) == completedType;
	}

	public bool IsAnyTutorialCompleted()
	{
		return _completedTutorials != TutorialProgressionProcess.TutorialType.None;
	}

	public void ClearTutorialCompletion()
	{
		_completedTutorials = TutorialProgressionProcess.TutorialType.None;
	}

	public MotorwaysCityStatistics GetCityStatisticsForCity(string cityId, GameMode mode, bool createIfNecessary = false)
	{
		for (int i = 0; i < _allCityStatistics.Count; i++)
		{
			if (_allCityStatistics[i].CityId == cityId && _allCityStatistics[i].Mode == mode)
			{
				return _allCityStatistics[i];
			}
		}
		MotorwaysCityStatistics motorwaysCityStatistics = null;
		if (createIfNecessary)
		{
			motorwaysCityStatistics = _scope.Get<MotorwaysCityStatistics>();
			motorwaysCityStatistics.DataChanged += OnCityStatisticsChanged;
			motorwaysCityStatistics.InitWithCityIdAndMode(cityId, mode);
			_allCityStatistics.Add(motorwaysCityStatistics);
		}
		return motorwaysCityStatistics;
	}

	public override void RecordGameStatistics(IGameStatistics gameStatistics)
	{
		if (gameStatistics is MotorwaysGameStatistics motorwaysGameStatistics)
		{
			MotorwaysCityStatistics cityStatisticsForCity = GetCityStatisticsForCity(motorwaysGameStatistics.CityId, motorwaysGameStatistics.Mode, createIfNecessary: true);
			if (!motorwaysGameStatistics.Challenge.HasChallenges)
			{
				cityStatisticsForCity.RecordGameStatistics(motorwaysGameStatistics);
			}
			else
			{
				cityStatisticsForCity.RecordCumulativeGameStatistics(motorwaysGameStatistics);
			}
		}
	}

	public void ClearCityStatistics()
	{
		_allCityStatistics.Clear();
	}

	private void OnCityStatisticsChanged(MotorwaysCityStatistics changedCityStatistics)
	{
		OnValueChanged();
	}
}
