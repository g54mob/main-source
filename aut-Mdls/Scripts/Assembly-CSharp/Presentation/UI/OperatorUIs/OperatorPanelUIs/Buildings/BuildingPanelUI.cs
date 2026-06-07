#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using System.Linq;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags.Validators;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Shapes;
using Data.Variables;
using Events;
using Events.UI.ModuleViewer;
using FMODUnity;
using Logic.Factory;
using Logic.FactoryTools;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Toolbar;
using Presentation.UI.LayoutElements;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.OperatorUIs.OperatorHoverUIs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Buildings
{
	public class BuildingPanelUI : FactoryPanelUIMenu
	{
		private enum BuildingStatus
		{
			UnderConstruction = 0,
			Upgrading = 1,
			Producing = 2,
			Inactive = 3
		}

		private struct BuildingUIData
		{
			public string StatusTitle;

			public Color StatusColor;

			public Color StatusTextColor;

			public Sprite StatusIcon;

			public GameObject StatusBackground;

			public BuildingUIData(string statusTitle, Color statusColor, Color statusTextColor, Sprite statusIcon, GameObject statusBackground)
			{
				StatusTitle = statusTitle;
				StatusColor = statusColor;
				StatusTextColor = statusTextColor;
				StatusIcon = statusIcon;
				StatusBackground = statusBackground;
			}
		}

		[Header("Refs")]
		[SerializeField]
		private BuildingFamilyDatabase _familyDatabase;

		[SerializeField]
		private ShowBuildingModulesEvent _showBuildingModulesEvent;

		[SerializeField]
		private BaseEvent _placeCraneFromBuildingEvent;

		[SerializeField]
		private PlaceCraneFromBuildingTool _placeCraneFromBuildingTool;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private CurrencyPersistentSO _currency;

		[SerializeField]
		private OverclockInfoView _overclockInfoView;

		[Header("Output")]
		[SerializeField]
		private GameObject _fullOutputContainer;

		[SerializeField]
		private GameObject _output;

		[SerializeField]
		private GameObject _outputBox;

		[SerializeField]
		private GameObject _upgradeEffectBox;

		[SerializeField]
		private Image _outputImage;

		[SerializeField]
		private TextMeshProUGUI _outputAmountText;

		[SerializeField]
		private TextMeshProUGUI _outputNameText;

		[SerializeField]
		private TextMeshProUGUI _outputTitle;

		[SerializeField]
		private TextMeshProUGUI _currentLevelText;

		[SerializeField]
		private TextMeshProUGUI _newLevelText;

		[Header("Estimated")]
		[SerializeField]
		private GameObject _estimatedOutputPanel;

		[SerializeField]
		[LocaKey]
		private string _estimatedOutputHoverLocaKey;

		[SerializeField]
		private LocalizedTMPText _estimatedOutputText;

		[SerializeField]
		private TextInfoPanelContent _estimatedOutputHoverTextPanel;

		[Header("Status")]
		[SerializeField]
		private Image _hoverProgressBar;

		[SerializeField]
		private Image _progressBar;

		[SerializeField]
		private Image _progressBarBorder;

		[SerializeField]
		private Image _statusImage;

		[SerializeField]
		private TextMeshProUGUI _statusText;

		[SerializeField]
		private SwitchToggle _statusSwitch;

		[SerializeField]
		private GameObject _hoveredProgressBarWidget;

		[SerializeField]
		private FactoryObjectData _overclockStationData;

		[Header("Status Icon")]
		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private Sprite _iconConstruction;

		[SerializeField]
		private Sprite _iconUpgrading;

		[SerializeField]
		private Sprite _iconAutoUpgrading;

		[SerializeField]
		private Sprite _iconProduction;

		[SerializeField]
		private Sprite _iconInactive;

		[Header("Input")]
		[SerializeField]
		private GameObject _inputResourcePanel;

		[SerializeField]
		private Transform _inputResourcesGrid;

		[SerializeField]
		private BuildingInputResourceUI _inputResourceUIPrefab;

		[SerializeField]
		private Transform _inputModulesGrid;

		[SerializeField]
		private ModuleContainer _inputModuleContainerPrefab;

		[SerializeField]
		private VerticalLayoutGroup _inputModulesVerticalLayoutGroup;

		[SerializeField]
		private int _defaultInputModulesBottomPadding = 24;

		[SerializeField]
		private int _inputModulesBottomPadding = 24;

		[Header("Stats")]
		[SerializeField]
		private GameObject _statsPanel;

		[SerializeField]
		private TextMeshProUGUI _statsFloorsText;

		[SerializeField]
		private TextMeshProUGUI _statsProductionLevelText;

		[SerializeField]
		private RectTransform _statsProductionLevelContainer;

		[Header("Settings")]
		[SerializeField]
		private GameObject _actionsPanel;

		[SerializeField]
		private GameObject _settingsPanel;

		[SerializeField]
		private Button _upgradeButton;

		[SerializeField]
		private Button _cancelUpgradeButton;

		[SerializeField]
		private Button _addCraneButton;

		[SerializeField]
		private FactoryToolLockedView _upgradeButtonLockView;

		[SerializeField]
		private UpgradeInfoPanelContent _upgradeButtonInfoPanel;

		[SerializeField]
		private TextInfoPanelContent _infoButtonInfoPanel;

		[SerializeField]
		private Toggle _autoUpgradeToggle;

		[Header("Content")]
		[SerializeField]
		private Color _statusColorUnderConstruction;

		[SerializeField]
		private Color _statusColorUpgrading;

		[SerializeField]
		private Color _statusColorProducing;

		[SerializeField]
		private Color _statusColorInactive;

		[SerializeField]
		private Color _statusTextColorUnderConstruction;

		[SerializeField]
		private Color _statusTextColorUpgrading;

		[SerializeField]
		private Color _statusTextColorProducing;

		[SerializeField]
		private Color _statusTextColorInactive;

		[SerializeField]
		private GameObject _statusBackgroundUnderConstruction;

		[SerializeField]
		private GameObject _statusBackgroundUpgrading;

		[SerializeField]
		private GameObject _statusBackgroundProducing;

		[SerializeField]
		private GameObject _statusBackgroundInactive;

		[Header("Cranes")]
		[SerializeField]
		private TextInfoPanelContent _craneInfoPanel;

		[SerializeField]
		private FactoryToolLockedView _addCraneLockedView;

		[SerializeField]
		private IntVariableSO _factoryStepsPerSecond;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private FactoryObjectBehaviour _craneBehaviour;

		[SerializeField]
		private string _addCraneTextKey;

		[SerializeField]
		private string _addCraneLimitReachedTextKey;

		[Header("UI Behaviour")]
		[SerializeField]
		[EnumFlags]
		private AbstractUIMenuData.ToggleTypes _buildingPanelToggles;

		[Header("Audio")]
		[SerializeField]
		private EventReference _activateAudioEvent;

		[SerializeField]
		private EventReference _deactivateAudioEvent;

		[Header("Feature Flag Validators")]
		[SerializeField]
		private EnableCraneLimitValidator _enableCraneLimitValidator;

		private BuildingBehaviour _behaviour;

		private OperatorStateBehaviour _operatorStateBehaviour;

		private bool _hasOperatorStateBehaviour;

		private BuildingAutoUpgradeBehaviour _autoUpgradeBehaviour;

		private bool _hasAutoUpgradeBehaviour;

		private BuildingCranesBehaviour _buildingCranesBehaviour;

		private BuildingFamilyData _familyData;

		private Color _familyColor;

		private Dictionary<BuildingStatus, BuildingUIData> _statusContent;

		private BuildingStatus _currentStatus;

		private bool _isBuildingComplete;

		private readonly List<ModuleContainer> _moduleContainers = new List<ModuleContainer>();

		private readonly List<BuildingInputResourceUI> _inputResources = new List<BuildingInputResourceUI>();

		private ActiveBuildingVFX _activeBuildingVFX;

		private TextMeshProUGUI _addCraneButtonText;

		private ResourceCost _currentUpgradeCost;

		protected override void HandleOnAwake()
		{
			_currentStatus = BuildingStatus.UnderConstruction;
			_statusContent = new Dictionary<BuildingStatus, BuildingUIData>
			{
				{
					BuildingStatus.UnderConstruction,
					new BuildingUIData("BuildingStatus.UnderConstruction", _statusColorUnderConstruction, _statusTextColorUnderConstruction, _iconConstruction, _statusBackgroundUnderConstruction)
				},
				{
					BuildingStatus.Upgrading,
					new BuildingUIData("BuildingStatus.Upgrading", _statusColorUpgrading, _statusTextColorUpgrading, _iconUpgrading, _statusBackgroundUpgrading)
				},
				{
					BuildingStatus.Producing,
					new BuildingUIData("BuildingStatus.Producing", _statusColorProducing, _statusTextColorProducing, _iconProduction, _statusBackgroundProducing)
				},
				{
					BuildingStatus.Inactive,
					new BuildingUIData("BuildingStatus.Inactive", _statusColorInactive, _statusTextColorInactive, _iconInactive, _statusBackgroundInactive)
				}
			};
			_addCraneButtonText = _addCraneButton.GetComponentInChildren<TextMeshProUGUI>();
			_addCraneButton.onClick.AddListener(AddCrane);
			_upgradeButton.onClick.AddListener(Upgrade);
			_cancelUpgradeButton.onClick.AddListener(CancelUpgrade);
			_autoUpgradeToggle.onValueChanged.AddListener(SetAutoUpgrade);
			_statusSwitch.OnValueChanged.AddListener(SetActiveState);
			_showBuildingModulesEvent.Register(OnClickModuleButton);
		}

		protected override void HandleOnDestroy()
		{
			_addCraneButton.onClick.RemoveListener(AddCrane);
			_upgradeButton.onClick.RemoveListener(Upgrade);
			_cancelUpgradeButton.onClick.RemoveListener(CancelUpgrade);
			_autoUpgradeToggle.onValueChanged.RemoveListener(SetAutoUpgrade);
			_statusSwitch.OnValueChanged.RemoveListener(SetActiveState);
			_showBuildingModulesEvent.UnRegister(OnClickModuleButton);
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as BuildingBehaviour;
			_hasOperatorStateBehaviour = _behaviour.FactoryObject.TryGetFactoryObjectBehaviour<OperatorStateBehaviour>(out _operatorStateBehaviour);
			_hasAutoUpgradeBehaviour = _behaviour.FactoryObject.TryGetFactoryObjectBehaviour<BuildingAutoUpgradeBehaviour>(out _autoUpgradeBehaviour);
			FactoryObjectViewManager.Instance.TryGetFactoryObjectView(_factoryObjectBehaviour.FactoryObject.CreatedId, out var view);
			_behaviour.OnShapeAdded.RegisterMainThread(UpdateInput);
			_behaviour.OnStageCompleted.RegisterMainThread(OnStageCompleted);
			_behaviour.OnUpgradeStateChanged.RegisterMainThread(OnUpdateStateChanged);
			_behaviour.OnClearedResources.RegisterMainThread(OnResourcesCleared);
			BuildUI();
			if (view.TryGetComponent<ActiveBuildingVFX>(out var component))
			{
				_activeBuildingVFX = component;
				_activeBuildingVFX.Show();
			}
			UpdateUI();
		}

		public override void HideMenu()
		{
			_behaviour.OnShapeAdded.UnRegisterMainThread(UpdateInput);
			_behaviour.OnStageCompleted.UnRegisterMainThread(OnStageCompleted);
			_behaviour.OnUpgradeStateChanged.UnRegisterMainThread(OnUpdateStateChanged);
			_behaviour.OnClearedResources.UnRegisterMainThread(OnResourcesCleared);
			if (_activeBuildingVFX != null)
			{
				_activeBuildingVFX.Hide();
				_activeBuildingVFX = null;
			}
			_overclockInfoView.CloseOverclockInfo();
			base.HideMenu();
			UpdateHarvesterPadFullState();
		}

		private void Update()
		{
			if (!(_behaviour == null) && _behaviour.CurrentBuildingStage > 0 && _behaviour.CurrentBuildingStage <= _behaviour.BuildingObjectData.Upgrades.Count)
			{
				_currentUpgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				_upgradeButtonLockView.IsVisuallyUnavailable = !_currency.HasEnoughResources(_currentUpgradeCost) || _behaviour.MaxLockedBuildingStageReached;
			}
		}

		private void AddCrane()
		{
			if (!(_behaviour == null) && (!_enableCraneLimitValidator.IsEnabledFeatureFlag() || !_buildingCranesBehaviour.HasReachedCraneLimit))
			{
				_placeCraneFromBuildingEvent.Fire();
				_placeCraneFromBuildingTool.SetBuilding(_behaviour);
				_placeCraneFromBuildingTool.OnStopPlacingCrane += StoppedPlacingCrane;
				HideMenu();
			}
		}

		private void StoppedPlacingCrane()
		{
			_placeCraneFromBuildingTool.OnStopPlacingCrane -= StoppedPlacingCrane;
			_showUIMenuEvent.Fire(new UIMenuBehaviourData(this, _factoryObject, _buildingPanelToggles, _behaviour));
		}

		protected override void SetState(AbstractUIMenuData.UIMenuState state)
		{
			base.SetState(state);
			BuildingBehaviour buildingBehaviour = _factoryObjectBehaviour as BuildingBehaviour;
			bool flag = state == AbstractUIMenuData.UIMenuState.InfoMode;
			flag &= buildingBehaviour == null || buildingBehaviour.IsUpgrading || _factoryObject.FactoryObjectData.ID != _overclockStationData.ID;
			_hoveredProgressBarWidget.SetActive(flag);
		}

		private void SetStatus()
		{
			_isBuildingComplete = _behaviour.MaxBuildingStageReached;
			if (!_behaviour.IsBuildingActive)
			{
				_currentStatus = BuildingStatus.Inactive;
			}
			else if (_behaviour.IsUpgrading)
			{
				if (_behaviour.CurrentBuildingStage == 0)
				{
					_currentStatus = BuildingStatus.UnderConstruction;
				}
				else
				{
					_currentStatus = BuildingStatus.Upgrading;
				}
			}
			else
			{
				_currentStatus = BuildingStatus.Producing;
			}
		}

		private void SetActiveState(bool active)
		{
			_behaviour.SetBuildingActive(active);
			SetStatus();
			UpdateStatusUI();
			if (active)
			{
				_audioManagerLocator?.AudioManager.PlayBuildingStateSound(_activateAudioEvent);
			}
			else
			{
				_audioManagerLocator?.AudioManager.PlayBuildingStateSound(_deactivateAudioEvent);
			}
		}

		private void OnStageCompleted(int _)
		{
			UpdateUI();
		}

		private void OnUpdateStateChanged(bool _)
		{
			UpdateUI();
		}

		private void OnResourcesCleared()
		{
			UpdateInput();
			UpdateHarvesterPadFullState();
		}

		private void BuildUI()
		{
			SetStatus();
			_familyData = _familyDatabase.GetBuildingFamilyDataWithId(_behaviour.BuildingObjectData.FamilyID);
			_familyColor = _familyData.Color;
			BuildOutput();
			BuildInput();
			BuildCraneInfo();
			UpdateHarvesterPadFullState();
		}

		private void UpdateHarvesterPadFullState()
		{
			if (!(_behaviour == null) && _behaviour.BuildingLandingPad != null && _hasOperatorStateBehaviour && _behaviour.BuildingLandingPad.HasHarvesterPadBehaviour && _behaviour.BuildingLandingPad.Exists)
			{
				if (_isOpen && _behaviour.HasResources && !_behaviour.BuildingLandingPad.HarvesterPadBehaviour.CanReceiveResourcesCountingDrones())
				{
					_operatorStateBehaviour.SetStateLinkedHarvesterPadFull();
				}
				else
				{
					_operatorStateBehaviour.ResetState();
				}
			}
		}

		protected override void SetTexts()
		{
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_behaviour.BuildingObjectData.NameLocKey));
		}

		private void BuildCraneInfo()
		{
			float num = (float)_factoryStepsPerSecond.Value / (float)_craneBehaviour.VariableUpdateFrequency.Value * (float)_globalUpdateMultiplier.Value;
			_craneInfoPanel.UpdateContent("Factory.UpdateFrequency", (num * 60f).ToString(), "FrequencyUnitUI");
		}

		private void UpdateUI()
		{
			SetStatus();
			UpdateOutput();
			UpdateInput();
			UpdateStatusUI();
			UpdateAutoUpgradeState();
			SetUpgradePanelsActiveState();
			if (_enableCraneLimitValidator.IsEnabledFeatureFlag())
			{
				UpdateAddCraneButton();
			}
			_statusSwitch.SetIsOnWithoutNotify(_behaviour.IsBuildingActive);
			_overclockInfoView.UpdateOverclockInfo(_behaviour);
		}

		private void UpdateAutoUpgradeState()
		{
			if (!_hasAutoUpgradeBehaviour)
			{
				_settingsPanel.SetActive(value: false);
				_autoUpgradeToggle.SetIsOnWithoutNotify(value: false);
			}
			else
			{
				bool active = !_behaviour.MaxBuildingStageReached;
				_settingsPanel.SetActive(active);
				_autoUpgradeToggle.isOn = _autoUpgradeBehaviour.AutoUpgrade;
			}
		}

		private void UpdateAddCraneButton()
		{
			_buildingCranesBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>();
			_addCraneButtonText.SetText(string.Format(LocalizationUtility.GetLocalizedText(_buildingCranesBehaviour.HasReachedCraneLimit ? _addCraneLimitReachedTextKey : _addCraneTextKey), _buildingCranesBehaviour.Cranes.Count, _buildingCranesBehaviour.MaxAmountOfCranes));
			_addCraneLockedView.IsLocked = _buildingCranesBehaviour.HasReachedCraneLimit;
			_addCraneLockedView.IsForcedLock = _buildingCranesBehaviour.HasReachedCraneLimit;
		}

		private void UpdateStatusUI()
		{
			_output.SetActive(_currentStatus != BuildingStatus.UnderConstruction && _behaviour.BuildingObjectData.ResourceOutputs.Count > 0);
			if (_currentStatus == BuildingStatus.Upgrading && _autoUpgradeBehaviour.AutoUpgrade)
			{
				_statusIcon.sprite = _iconAutoUpgrading;
			}
			else
			{
				_statusIcon.sprite = _statusContent[_currentStatus].StatusIcon;
			}
			_statusImage.color = _statusContent[_currentStatus].StatusColor;
			_statusText.SetText(LocalizationUtility.GetLocalizedText(_statusContent[_currentStatus].StatusTitle));
			_statusText.color = _statusContent[_currentStatus].StatusTextColor;
			Color color = ((_currentStatus == BuildingStatus.Inactive) ? _statusContent[BuildingStatus.Inactive].StatusColor : Color.white);
			UpdateBackgroundImageForCurrentStatus();
			_titleText.color = color;
			_progressBar.color = color;
			_progressBarBorder.color = color;
		}

		private void UpdateBackgroundImageForCurrentStatus()
		{
			foreach (KeyValuePair<BuildingStatus, BuildingUIData> item in _statusContent)
			{
				item.Value.StatusBackground.SetActive(item.Key == _currentStatus);
			}
		}

		private void UpdateOutputEstimates()
		{
			bool flag = !_behaviour.IsUpgrading && _behaviour.GetCurrentOutputs().Any();
			_estimatedOutputPanel.SetActive(flag);
			_buildingCranesBehaviour = _behaviour.FactoryObject.GetFactoryObjectBehaviour<BuildingCranesBehaviour>();
			if (!flag && _buildingCranesBehaviour != null)
			{
				return;
			}
			int num = 0;
			foreach (BuildingConstructionResource buildRequirement in _behaviour.BuildRequirements)
			{
				num += buildRequirement.Max;
			}
			int count = _buildingCranesBehaviour.Cranes.Count;
			int item = _behaviour.GetCurrentOutputs().ElementAt(0).Item2;
			double num2 = (double)FactoryUpdater.Instance.GetUnscaledStepsPerSecond() / (double)_buildingCranesBehaviour.UpdateFrequency * 60.0;
			double num3 = _behaviour.CalculateEstimatedOutputSpeed();
			string replacementText = $"<color=#FFD926>{num2}</color> / (<color=#2AB1FF>{num}</color> / <color=#C43939>{count}</color>) * <color=#55C472>{item}</color> = {num3}";
			_estimatedOutputText.SetArguments(num3.ToString());
			_estimatedOutputHoverTextPanel.UpdateContent(_estimatedOutputHoverLocaKey, replacementText);
		}

		private void BuildOutput()
		{
			_output.SetActive(_behaviour.BuildingObjectData.ResourceOutputs.Count > 0);
			if (_behaviour.BuildingObjectData.ResourceOutputs.Count != 0)
			{
				NonShapeResourceDataSO nonShapeResourceDataSO = _behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData as NonShapeResourceDataSO;
				_outputNameText.SetText(LocalizationUtility.GetLocalizedText(nonShapeResourceDataSO.NameLocaKey));
				_outputImage.sprite = nonShapeResourceDataSO.Sprite;
				PaintResourceDataSO paintResourceDataSO = _behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData as PaintResourceDataSO;
				if (paintResourceDataSO != null)
				{
					Color color = paintResourceDataSO.Color;
					color.a = 1f;
					_outputNameText.color = color;
				}
				else
				{
					_outputNameText.color = _familyColor;
				}
				UpdateOutputEstimates();
			}
		}

		private void UpdateOutput()
		{
			_output.SetActive(_behaviour.BuildingObjectData.ResourceOutputs.Count > 0);
			_fullOutputContainer.SetActive((_behaviour.CurrentBuildingStage != 0 && _output.activeSelf) || _hoveredProgressBarWidget.activeSelf);
			ResourceDataSO resourceData = ((_behaviour.BuildingObjectData.ResourceOutputs.Count > 0) ? _behaviour.BuildingObjectData.ResourceOutputs[0].ResourceData : null);
			int resourceOutputAtStage = _behaviour.BuildingObjectData.GetResourceOutputAtStage(resourceData, _behaviour.CurrentBuildingStage + 1);
			double num = (double)Mathf.Floor((float)_behaviour.BuildingObjectData.GetResourceOutputAtStage(resourceData, _behaviour.CurrentBuildingStage) * _behaviour.OverclockData.OverclockMultiplier * 100f) * 0.01;
			_outputAmountText.SetText($"x{num}");
			_outputTitle.SetText(LocalizationUtility.GetLocalizedText((_currentStatus == BuildingStatus.Upgrading) ? "BuildingPanel.UpgradeEffectTitle" : "BuildingPanel.CreatesTitle"));
			string text = _behaviour.BuildingObjectData.GetProductionLevelAtStage(_behaviour.CurrentBuildingStage).ToString();
			string text2 = _behaviour.BuildingObjectData.GetProductionLevelAtStage(_behaviour.CurrentBuildingStage + 1).ToString();
			if (_currentStatus == BuildingStatus.Upgrading)
			{
				_currentLevelText.SetText(text);
				_newLevelText.SetText(text2);
			}
			_outputBox.SetActive(_currentStatus != BuildingStatus.Upgrading);
			_upgradeEffectBox.SetActive(_currentStatus == BuildingStatus.Upgrading);
			if (_behaviour.CurrentBuildingStage > 0 && _behaviour.CurrentBuildingStage <= _behaviour.BuildingObjectData.Upgrades.Count)
			{
				ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				bool hasOutput = _behaviour.BuildingObjectData.ResourceOutputs.Count > 0;
				_upgradeButtonInfoPanel.UpdateContent(upgradeCost, text, text2, hasOutput, _outputImage.sprite, $"x{resourceOutputAtStage}");
				_upgradeButtonInfoPanel.enabled = !_behaviour.MaxLockedBuildingStageReached;
				_infoButtonInfoPanel.enabled = _behaviour.MaxLockedBuildingStageReached;
			}
			UpdateStats(text);
			UpdateOutputEstimates();
		}

		private void UpdateStats(string productionLevel)
		{
			_statsPanel.SetActive(_currentStatus != BuildingStatus.UnderConstruction);
			_statsFloorsText.SetText($"{_behaviour.CurrentBuildingStage}/{_behaviour.MaxBuildingStage}");
			_statsProductionLevelText.SetText($"{productionLevel}/{_behaviour.BuildingObjectData.GetProductionLevelAtStageMax()}");
			_statsProductionLevelContainer.gameObject.SetActive(!_behaviour.BuildingObjectData.UIData.HideProductionLevelInUI);
		}

		private void BuildInput(int _ = 0)
		{
			for (int i = 0; i < _moduleContainers.Count; i++)
			{
				_moduleContainers[i].gameObject.SetActive(value: false);
			}
			int num = 0;
			for (int j = 0; j < _behaviour.BuildRequirements.Count; j++)
			{
				BuildingConstructionResource buildingConstructionResource = _behaviour.BuildRequirements[j];
				if (buildingConstructionResource is ShapeConstructionResource)
				{
					ModuleContainer moduleContainer;
					if (num >= _moduleContainers.Count)
					{
						moduleContainer = Object.Instantiate(_inputModuleContainerPrefab, _inputModulesGrid);
						_moduleContainers.Add(moduleContainer);
					}
					else
					{
						moduleContainer = _moduleContainers[num];
					}
					Texture2D gridIcon = (buildingConstructionResource as ShapeConstructionResource).ShapeData.GridIcon;
					moduleContainer.Build(gridIcon, _behaviour.BuildingObjectData.GetModuleViewerData, num);
					moduleContainer.gameObject.SetActive(value: true);
					num++;
				}
			}
			UpdateFillBar();
		}

		private void UpdateInput(ShapeData _ = null, int __ = 0)
		{
			List<InputResourceUI> list = new List<InputResourceUI>();
			int moduleIndex = 0;
			int resourceIndex = 0;
			bool hasResourceInput = false;
			hasResourceInput = ShowBuildRequirements(moduleIndex, resourceIndex, hasResourceInput, list);
			foreach (BuildingInputResourceUI inputResource in _inputResources)
			{
				bool flag = list.Contains(inputResource);
				if (inputResource.gameObject.activeInHierarchy != flag)
				{
					inputResource.gameObject.SetActive(flag);
				}
			}
			_inputResourcePanel.SetActive(hasResourceInput);
			_inputModulesVerticalLayoutGroup.padding.bottom = (_behaviour.ShowSpeedRequirementInUI ? _inputModulesBottomPadding : _defaultInputModulesBottomPadding);
			UpdateFillBar();
		}

		private bool ShowBuildRequirements(int moduleIndex, int resourceIndex, bool hasResourceInput, List<InputResourceUI> shouldStayActive)
		{
			int smallestAmountOfResources;
			int smallestMultiplier = _behaviour.GetSmallestMultiplier(out smallestAmountOfResources);
			for (int i = 0; i < _behaviour.BuildRequirements.Count; i++)
			{
				BuildingConstructionResource buildingConstructionResource = _behaviour.BuildRequirements[i];
				if (buildingConstructionResource is ShapeConstructionResource)
				{
					_moduleContainers[i].UpdateAmounts(buildingConstructionResource.Count, buildingConstructionResource.Max, smallestAmountOfResources, smallestMultiplier);
					moduleIndex++;
					if (_behaviour.ShowSpeedRequirementInUI)
					{
						_moduleContainers[i].ShowSpeedPerMin(buildingConstructionResource.Max, _behaviour.ProcessTicksToSupplyAllModules);
					}
					else
					{
						_moduleContainers[i].HideSpeedPerMin();
					}
					continue;
				}
				BuildingInputResourceUI buildingInputResourceUI;
				if (resourceIndex >= _inputResources.Count)
				{
					buildingInputResourceUI = Object.Instantiate(_inputResourceUIPrefab, _inputResourcesGrid);
					_inputResources.Add(buildingInputResourceUI);
					shouldStayActive.Add(buildingInputResourceUI);
				}
				else
				{
					buildingInputResourceUI = _inputResources[resourceIndex];
					shouldStayActive.Add(buildingInputResourceUI);
				}
				buildingInputResourceUI.SetResource(buildingConstructionResource.ResourceData as NonShapeResourceDataSO);
				buildingInputResourceUI.SetAmount(buildingConstructionResource.Count, buildingConstructionResource.Max, smallestAmountOfResources, smallestMultiplier);
				resourceIndex++;
				hasResourceInput = true;
			}
			return hasResourceInput;
		}

		private void SetUpgradePanelsActiveState()
		{
			_upgradeButton.gameObject.SetActive(_currentStatus == BuildingStatus.Producing && !_isBuildingComplete);
			_cancelUpgradeButton.gameObject.SetActive(_currentStatus == BuildingStatus.Upgrading && !_isBuildingComplete);
			_actionsPanel.SetActive(_upgradeButton.gameObject.activeSelf || _cancelUpgradeButton.gameObject.activeSelf || _addCraneButton.gameObject.activeSelf);
		}

		private void UpdateFillBar()
		{
			_progressBar.fillAmount = _behaviour.CurrentProgress;
			_hoverProgressBar.fillAmount = _behaviour.CurrentProgress;
		}

		public void Upgrade()
		{
			if (!_behaviour.MaxLockedBuildingStageReached)
			{
				ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				if (_currency.TryBuy(upgradeCost))
				{
					_behaviour.StartUpgrading();
				}
			}
		}

		public void CancelUpgrade()
		{
			ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
			_currency.AddResources(upgradeCost);
			_behaviour.StopUpgrading();
			SetAutoUpgrade(autoUpgrade: false);
		}

		public void SetAutoUpgrade(bool autoUpgrade)
		{
			if (!_hasAutoUpgradeBehaviour)
			{
				this.DevException("Failed because _autoUpgradeBehaviour is null", "SetAutoUpgrade", 717);
				_autoUpgradeToggle.SetIsOnWithoutNotify(value: false);
			}
			else
			{
				_autoUpgradeBehaviour.SetAutoUpgrade(autoUpgrade);
			}
		}

		private void OnClickModuleButton((BuildingObjectData, int) dataAndIndex)
		{
			if (base.gameObject.activeSelf)
			{
				HideMenu();
			}
		}
	}
}
