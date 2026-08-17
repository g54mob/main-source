using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI;

public class AutomationPopup : BasePopup
{
	protected Button _Close;

	protected Button _Confirm;

	protected Button _QuickStart;

	private RectTransform _AutomationContainer;

	private RectTransform _SettingsContainer;

	private DataManager _dataManager;

	private GameObject _TickboxPrefab;

	private GameObject _SliderPrefab;

	private GameObject _ButtonPrefab;

	private GameObject _DropdownPrefab;

	private GameObject _MultipleChoicePrefab;

	private GameObject _TickboxSmallPrefab;

	private GameObject _LabelPrefab;

	private List<ISelectableUI> _automationElements;

	private List<IUIObject> _spawnedElements;

	private List<IUIObject> _settingElements;

	private List<TickBoxUI> _allStageChoices;

	private bool _stageOptionsActive;

	private List<string> _allStages;

	private List<StageType> _allStageTypes;

	public AutomationPopup()
	{
		List<ISelectableUI> automationElements = new List<ISelectableUI>();
		_automationElements = automationElements;
		_spawnedElements = new List<IUIObject>();
		_settingElements = new List<IUIObject>();
		_allStageChoices = new List<TickBoxUI>();
		base._002Ector();
	}
}
