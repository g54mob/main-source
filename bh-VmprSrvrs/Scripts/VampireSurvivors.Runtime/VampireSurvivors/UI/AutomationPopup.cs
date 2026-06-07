using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class AutomationPopup : BasePopup
	{
		[SerializeField]
		protected Button _Close;

		[SerializeField]
		protected Button _Confirm;

		[SerializeField]
		protected Button _QuickStart;

		[SerializeField]
		private RectTransform _AutomationContainer;

		[SerializeField]
		private RectTransform _SettingsContainer;

		private DataManager _dataManager;

		[SerializeField]
		private GameObject _TickboxPrefab;

		[SerializeField]
		private GameObject _SliderPrefab;

		[SerializeField]
		private GameObject _ButtonPrefab;

		[SerializeField]
		private GameObject _DropdownPrefab;

		[SerializeField]
		private GameObject _MultipleChoicePrefab;

		[SerializeField]
		private GameObject _TickboxSmallPrefab;

		[SerializeField]
		private GameObject _LabelPrefab;

		private List<ISelectableUI> _automationElements;

		private List<IUIObject> _spawnedElements;

		private List<IUIObject> _settingElements;

		private List<TickBoxUI> _allStageChoices;

		private bool _stageOptionsActive;

		private List<string> _allStages;

		private List<StageType> _allStageTypes;
	}
}
