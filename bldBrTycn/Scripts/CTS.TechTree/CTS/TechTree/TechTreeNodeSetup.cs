using System;
using CTS.BBT.TechTree;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS.TechTree
{
	public class TechTreeNodeSetup : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private PaletteData _blueColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private PaletteData _redColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private PaletteData _whiteColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private PaletteData _greyColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public bool IgnoreAllRequirements;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Component Links")]
		private Button _buttonComponent;

		[SerializeField]
		[BoxGroup("Component Links")]
		private Image _technologyIcon;

		[SerializeField]
		[BoxGroup("Component Links")]
		private Image _technologyBorder;

		[SerializeField]
		[BoxGroup("Component Links")]
		private Image _buttonBackgroundColor;

		[SerializeField]
		[BoxGroup("Component Links")]
		private Image _fillBackgroundColor;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private GameObject _technologyPointsRequiredGameObject;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TMP_Text _technologyPointsRequiredText;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _padlockVisualGameObject;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Debug View")]
		[ReadOnly]
		public TechTreeTechnologySO TechnologySO;

		[SerializeField]
		[BoxGroup("Debug View")]
		private bool _debugMode;

		private ENodeState _currentState;

		private ToolTipsShower _toolTipsShower;

		private LocalizedString _localizationTechnologySONameKey;

		private LocalizedString _localizationTechnologySODescriptionKey;

		private ETechTreeTechnologyLevel _technologyCurrentLevel;

		private ETechTreeTechnologyLevel _technologyMaxLevelsCount;

		private int _currentTechTreePoints;

		private int _techPointsRequired;

		private bool _isInteractable;

		private bool _isLock;

		private float _fillAmountIncrementation;

		public static event Action TechnoUnlock;

		public static event Action TechUnlockFull;

		public static event Action TechUnlockSound;

		private void OnDisable()
		{
			SubscribeToEvents(subscribe: false);
			_buttonComponent.onClick.RemoveListener(TryToResearch);
		}

		public ENodeState GetState()
		{
			return _currentState;
		}

		public void CheckState()
		{
			if (_currentState != ENodeState.FullyResearched)
			{
				UpdateCurrentStateVariables();
				if (AreTheRequirementsDeliberatelyIgnored())
				{
					SwitchState(ENodeState.CanBeResearched);
				}
				else if (IsFullyResearched())
				{
					SwitchState(ENodeState.FullyResearched);
					TechTreeNodeSetup.TechUnlockFull?.Invoke();
				}
				else if (!AreRequirementsMet())
				{
					SwitchState(ENodeState.Locked);
				}
				else
				{
					SwitchState((!NeedMorePoints()) ? ENodeState.CanBeResearched : ENodeState.NeedPoints);
				}
			}
		}

		private void NewTechnologyResearched(TechTreeTechnologySO value)
		{
			if (value == TechnologySO || AreRequirementsMet())
			{
				CheckState();
			}
		}

		private void OnTechConditionChanged()
		{
			CheckState();
		}

		private void SetTechnologyIgnoreRequirements(TechTreeTechnologySO value)
		{
			if (!(value != TechnologySO))
			{
				IgnoreAllRequirements = true;
				CheckState();
			}
		}

		private void SubscribeToEvents(bool subscribe)
		{
			if (subscribe)
			{
				_buttonComponent.onClick.AddListener(TryToResearch);
				TechTreePoints.OnGainResearchPoints += CheckState;
				TechTreePoints.OnLooseResearchPoints += CheckState;
				TechTreeManager.OnTechnologyResearched += NewTechnologyResearched;
				TechTreeManager.OnTechnologyIgnoreRequirements += SetTechnologyIgnoreRequirements;
				if ((bool)TechnologySO.UnlockCondition)
				{
					TechnologySO.UnlockCondition.ConditionChanged += OnTechConditionChanged;
				}
			}
			else
			{
				_buttonComponent.onClick.RemoveListener(TryToResearch);
				TechTreePoints.OnGainResearchPoints -= CheckState;
				TechTreePoints.OnLooseResearchPoints -= CheckState;
				TechTreeManager.OnTechnologyResearched -= NewTechnologyResearched;
				TechTreeManager.OnTechnologyIgnoreRequirements -= SetTechnologyIgnoreRequirements;
				if ((bool)TechnologySO.UnlockCondition)
				{
					TechnologySO.UnlockCondition.ConditionChanged -= OnTechConditionChanged;
				}
			}
		}

		private void InitializeToolTips()
		{
			_toolTipsShower = GetComponent<ToolTipsShower>();
			_toolTipsShower.SetTootipsInfo(_localizationTechnologySONameKey, _localizationTechnologySODescriptionKey);
		}

		private void TryToResearch()
		{
			if (TechTreeManager.AttemptToResearchTechnology(TechnologySO))
			{
				IgnoreAllRequirements = false;
			}
		}

		private void UpdateCurrentStateVariables()
		{
			_currentTechTreePoints = TechTreeManager.GetCurrentPoints;
			ETechTreeTechnologyLevel technologyResearchLevel = TechTreeManager.GetTechnologyResearchLevel(TechnologySO);
			if (_technologyCurrentLevel == ETechTreeTechnologyLevel.Level0 && technologyResearchLevel == ETechTreeTechnologyLevel.Level1)
			{
				TechTreeNodeSetup.TechUnlockSound?.Invoke();
			}
			_technologyCurrentLevel = technologyResearchLevel;
			_fillBackgroundColor.fillAmount = _fillAmountIncrementation * (float)_technologyCurrentLevel;
			_techPointsRequired = (byte)((_technologyCurrentLevel != _technologyMaxLevelsCount) ? TechnologySO.ResearchPointsLevels[_technologyCurrentLevel + 1] : 0);
			_technologyPointsRequiredText.text = $"{_techPointsRequired}";
		}

		private bool AreTheRequirementsDeliberatelyIgnored()
		{
			if (IgnoreAllRequirements)
			{
				return _technologyCurrentLevel > ETechTreeTechnologyLevel.Level0;
			}
			return false;
		}

		private bool IsFullyResearched()
		{
			if (_technologyCurrentLevel == _technologyMaxLevelsCount && _currentState == ENodeState.CanBeResearched && TechTreeManager.CheckIfAllRequirementsAreResearched(TechnologySO))
			{
				return TechTreeManager.FirstLevelHasBeenResearched(TechnologySO);
			}
			return false;
		}

		private bool AreRequirementsMet()
		{
			if ((bool)TechnologySO.UnlockCondition && !TechnologySO.UnlockCondition.IsConditionValid())
			{
				return false;
			}
			return TechTreeManager.CheckIfAllRequirementsAreResearched(TechnologySO);
		}

		private bool NeedMorePoints()
		{
			return _currentTechTreePoints < _techPointsRequired;
		}

		private void SwitchState(ENodeState newState)
		{
			if (_currentState == ENodeState.Locked && newState == ENodeState.CanBeResearched)
			{
				TechTreeNodeSetup.TechnoUnlock?.Invoke();
			}
			_currentState = newState;
			_isInteractable = newState != ENodeState.NeedPoints && newState != ENodeState.Locked;
			_isLock = newState == ENodeState.Locked;
			bool flag = TechTreeManager.FirstLevelHasBeenResearched(TechnologySO);
			_technologyIcon.color = (flag ? _whiteColor : _greyColor);
			if (!_isInteractable)
			{
				_technologyBorder.color = (flag ? _redColor : _blueColor);
			}
			else if (flag)
			{
				_technologyBorder.color = ((_currentState == ENodeState.FullyResearched) ? _redColor : _whiteColor);
			}
			else
			{
				_technologyBorder.color = _greyColor;
			}
			_buttonBackgroundColor.color = (flag ? _redColor : _blueColor);
			_buttonComponent.interactable = _isInteractable;
			_padlockVisualGameObject.SetActive(_isLock);
			if (_currentState == ENodeState.NeedPoints)
			{
				_technologyPointsRequiredGameObject.SetActive(value: true);
			}
			else if (_currentState == ENodeState.CanBeResearched)
			{
				_technologyPointsRequiredGameObject.SetActive(value: true);
			}
			else
			{
				_technologyPointsRequiredGameObject.SetActive(value: false);
			}
			if (_currentState == ENodeState.FullyResearched)
			{
				_fillBackgroundColor.fillAmount = 1f;
			}
		}

		public void Setup()
		{
			_technologyIcon.sprite = TechnologySO.TechnologyIcon;
			_localizationTechnologySONameKey = TechnologySO.LocalizationTechnologySONameKey;
			_localizationTechnologySODescriptionKey = TechnologySO.LocalizationTechnologySODescriptionKey;
			_technologyMaxLevelsCount = TechTreeManager.GetTechnologyMaxResearchLevel(TechnologySO);
			_fillBackgroundColor.fillAmount = 0f;
			_fillAmountIncrementation = 1f / (float)_technologyMaxLevelsCount;
			InitializeToolTips();
			SubscribeToEvents(subscribe: true);
			TechTreeManager.ResearchATechnology(TechnologySO, TechnologySO.DefaultLevel);
		}
	}
}
