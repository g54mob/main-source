using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyReportPanel : Panel
{
	public interface Context : IPanelContext
	{
		int DayIndex { get; }
	}

	[SerializeField]
	private Button _previousButton;

	[SerializeField]
	private Button _nextButton;

	[SerializeField]
	private TextMeshProUGUI _dayText;

	[SerializeField]
	private LocalizedString _daysString = null;

	[Header("Data")]
	[SerializeField]
	private DailyReportDataUI _foodReportData;

	[SerializeField]
	private DailyReportDataUI _waterReportData;

	[SerializeField]
	private DailyReportDataUI _energyReportData;

	[SerializeField]
	private DailyReportResourcesSlots _gatheredResourcePanel;

	[SerializeField]
	private DailyReportResourcesSlots _craftingResourcePanel;

	[SerializeField]
	private DailyReportResourcesSlots _farmedResourcePanel;

	[SerializeField]
	private TextMeshProUGUI _travelledDistanceText;

	[SerializeField]
	private LocalizedString _travelledDistanceString = null;

	[SerializeField]
	private TextMeshProUGUI _experienceText;

	[SerializeField]
	private LocalizedString _experienceString = null;

	[SerializeField]
	private TextMeshProUGUI _researchPointsText;

	[SerializeField]
	private LocalizedString _researchPointsString = null;

	private DailyReport _currentReport;

	private int _currentDayIndex = -1;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.DayEnded, OnNewDay);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, OnNewDay);
		if (_currentReport != null)
		{
			RemoveListeners(_currentReport);
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		int num = _currentDayIndex;
		if (context is Context context2)
		{
			num = context2.DayIndex;
		}
		else if (_currentDayIndex == -1 && (bool)GameManager.TimeManager && GameManager.TimeManager.Days != null)
		{
			num = GameManager.TimeManager.Days.Count - 1;
		}
		if (-1 < num && base.Open(id, context))
		{
			OpenReport(num);
			return true;
		}
		return false;
	}

	public void OpenReport(int index)
	{
		base.gameObject.SetActive(value: true);
		_currentDayIndex = index;
		_dayText.text = ReturnDay();
		_previousButton.interactable = _currentDayIndex > 0;
		_nextButton.interactable = _currentDayIndex < GameManager.TimeManager.Days.Count - 1;
		SetCurrentReport();
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
	}

	private void OnNewDay(GameEvent gameEvent)
	{
		_previousButton.interactable = _currentDayIndex > 0;
		_nextButton.interactable = _currentDayIndex < GameManager.TimeManager.Days.Count - 1;
	}

	private void AddListeners(DailyReport report)
	{
		_currentReport.OnCraftedResourceUpdate.AddListener(UpdateCraftedResources);
		_currentReport.OnGatheredResourceUpdate.AddListener(UpdateGatheredResources);
		_currentReport.OnFarmedResourcesUpdate.AddListener(UpdateFarmedResources);
		_currentReport.FoodData.ValueUpdatedEvent.AddListener(UpdateFoodReportData);
		_currentReport.WaterData.ValueUpdatedEvent.AddListener(UpdateWaterReportData);
		_currentReport.EnergyData.ValueUpdatedEvent.AddListener(UpdateEnergyReportData);
		_currentReport.OnDistanceTravelledUpdate.AddListener(UpdateDistanceTravelled);
		_currentReport.OnCommunityExperienceUpdate.AddListener(UpdateCommunityExperience);
		_currentReport.OnResearchPointUpdate.AddListener(UpdateResearchPoints);
	}

	private void RemoveListeners(DailyReport report)
	{
		_currentReport.OnCraftedResourceUpdate.RemoveListener(UpdateCraftedResources);
		_currentReport.OnGatheredResourceUpdate.RemoveListener(UpdateGatheredResources);
		_currentReport.OnFarmedResourcesUpdate.RemoveListener(UpdateFarmedResources);
		_currentReport.FoodData.ValueUpdatedEvent.RemoveListener(UpdateFoodReportData);
		_currentReport.WaterData.ValueUpdatedEvent.RemoveListener(UpdateWaterReportData);
		_currentReport.EnergyData.ValueUpdatedEvent.RemoveListener(UpdateEnergyReportData);
		_currentReport.OnDistanceTravelledUpdate.RemoveListener(UpdateDistanceTravelled);
		_currentReport.OnCommunityExperienceUpdate.RemoveListener(UpdateCommunityExperience);
		_currentReport.OnResearchPointUpdate.RemoveListener(UpdateCommunityExperience);
	}

	private void SetCurrentReport()
	{
		if (_currentReport != null)
		{
			RemoveListeners(_currentReport);
		}
		_currentReport = GameManager.TimeManager.Days[_currentDayIndex].Report;
		AddListeners(_currentReport);
		UpdateCraftedResources();
		UpdateGatheredResources();
		UpdateFarmedResources();
		UpdateFoodReportData();
		UpdateWaterReportData();
		UpdateEnergyReportData();
		UpdateDistanceTravelled();
		UpdateCommunityExperience();
		UpdateResearchPoints();
	}

	public void PreviousReport()
	{
		if (0 < _currentDayIndex)
		{
			_currentDayIndex--;
			_previousButton.interactable = 0 < _currentDayIndex;
			_nextButton.interactable = true;
			_dayText.text = ReturnDay();
			SetCurrentReport();
		}
	}

	public void NextReport()
	{
		int num = GameManager.TimeManager.Days.Count - 1;
		if (_currentDayIndex < num)
		{
			_currentDayIndex++;
			_previousButton.interactable = true;
			_nextButton.interactable = _currentDayIndex < num;
			_dayText.text = ReturnDay();
			SetCurrentReport();
		}
	}

	private void UpdateGatheredResources()
	{
		_gatheredResourcePanel.UpdateItems(_currentReport.GatheredResources);
	}

	private void UpdateCraftedResources()
	{
		_craftingResourcePanel.UpdateItems(_currentReport.CraftedResources);
	}

	private void UpdateFarmedResources()
	{
		_farmedResourcePanel.UpdateItems(_currentReport.FarmedResources);
	}

	private void UpdateFoodReportData()
	{
		_foodReportData.UpdateReport(_currentReport.FoodData);
	}

	private void UpdateWaterReportData()
	{
		_waterReportData.UpdateReport(_currentReport.WaterData);
	}

	private void UpdateEnergyReportData()
	{
		_energyReportData.UpdateReport(_currentReport.EnergyData);
	}

	private void UpdateDistanceTravelled()
	{
		_travelledDistanceText.text = _travelledDistanceString.ToString().Replace("%DISTANCE%", _currentReport.TravelledDistance.ToString("F0"));
	}

	private void UpdateCommunityExperience()
	{
		_experienceText.text = Mathf.RoundToInt(_currentReport.ExperienceGained) + " " + _experienceString.ToString();
	}

	private void UpdateResearchPoints()
	{
		_researchPointsText.text = _currentReport.ResearchPointsGained + " " + _researchPointsString.ToString();
	}

	private string ReturnDay()
	{
		return _daysString.ToString().Replace("%DAY%", (_currentDayIndex + 1).ToString());
	}
}
