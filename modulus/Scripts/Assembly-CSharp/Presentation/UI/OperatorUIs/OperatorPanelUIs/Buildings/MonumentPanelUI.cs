using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags.Validators;
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
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Buildings
{
	public class MonumentPanelUI : FactoryPanelUIMenu
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
		private BaseEvent _currencyGainedEvent;

		[Header("Monument Variables")]
		[SerializeField]
		private GameObject _monumentEffectContainer;

		[SerializeField]
		private Image _monumentEffectImage;

		[SerializeField]
		private Image _monumentEffectBackgroundImage;

		[SerializeField]
		private CanvasGroup _monumentEffectImageCanvasGroup;

		[SerializeField]
		private TextMeshProUGUI _chargeText;

		[SerializeField]
		private TextMeshProUGUI _activeText;

		[SerializeField]
		private TextMeshProUGUI _consumingText;

		[SerializeField]
		private Transform _chargingContainer;

		[SerializeField]
		private Image _chargingDataShardImage;

		[SerializeField]
		private Image _chargingProgressBar;

		[SerializeField]
		private Transform _storageContainer;

		[SerializeField]
		private ModuleContainer _storageModuleContainer;

		[SerializeField]
		[LocaKey]
		private string _consumingTextLocaKey;

		[SerializeField]
		[LocaKey]
		private string _activeLocaKey;

		[SerializeField]
		[LocaKey]
		private string _inactiveLocaKey;

		[SerializeField]
		private Transform _monumentProgressBarContainer;

		[SerializeField]
		private Image _monumentProgressBar;

		[SerializeField]
		private Image _monumentProgressBarBorder;

		[SerializeField]
		private TextMeshProUGUI _cantChargeYetText;

		[Header("Status")]
		[SerializeField]
		private Transform _progressBarContainer;

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

		[Header("Stats")]
		[SerializeField]
		private GameObject _statsPanel;

		[SerializeField]
		private TextMeshProUGUI _statsFloorsText;

		[SerializeField]
		private TextMeshProUGUI _statsProductionLevelText;

		[Header("Settings")]
		[SerializeField]
		private GameObject _actionsPanel;

		[SerializeField]
		private Button _addCraneButton;

		[SerializeField]
		private Button _activateMonumentButton;

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

		private MonumentBuildingBehaviour _behaviour;

		private BuildingCranesBehaviour _buildingCranesBehaviour;

		private BuildingFamilyData _familyData;

		private Color _familyColor;

		private Dictionary<BuildingStatus, BuildingUIData> _statusContent;

		private BuildingStatus _currentStatus;

		private bool _isBuildingComplete;

		private List<ModuleContainer> _moduleContainers = new List<ModuleContainer>();

		private List<BuildingInputResourceUI> _inputResources = new List<BuildingInputResourceUI>();

		private ActiveBuildingVFX _activeBuildingVFX;

		private TextMeshProUGUI _addCraneButtonText;

		private Color _transparentChargeColor;

		private Color _transparentColor;

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
			_activateMonumentButton.onClick.AddListener(ActivateMonument);
			_activateMonumentButton.gameObject.SetActive(value: false);
			_statusSwitch.OnValueChanged.AddListener(SetActiveState);
			_showBuildingModulesEvent.Register(OnClickModuleButton);
		}

		protected override void HandleOnDestroy()
		{
			_addCraneButton.onClick.RemoveListener(AddCrane);
			_activateMonumentButton.onClick.RemoveListener(ActivateMonument);
			_behaviour.OnAllShapesReceived -= HandleMonumentAllShapesReceived;
			_statusSwitch.OnValueChanged.RemoveListener(SetActiveState);
			_showBuildingModulesEvent.UnRegister(OnClickModuleButton);
		}

		private void Update()
		{
			if (!(_behaviour == null))
			{
				UpdateMonumentChargeBar();
				if (_behaviour.MaxBuildingStageReached)
				{
					UpdateMonumentUIAmounts();
				}
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

		private void HandleMonumentAllShapesReceived()
		{
			if (!_factoryObjectBehaviour.FactoryObject.GetFactoryObjectBehaviour<MonumentBehaviour>().IsActivated)
			{
				_activateMonumentButton.gameObject.SetActive(value: true);
			}
		}

		private void ActivateMonument()
		{
			_factoryObjectBehaviour.FactoryObject.GetFactoryObjectBehaviour<MonumentBehaviour>().ActivateMonument();
			_activateMonumentButton.gameObject.SetActive(value: false);
		}

		private void StoppedPlacingCrane()
		{
			_placeCraneFromBuildingTool.OnStopPlacingCrane -= StoppedPlacingCrane;
			_showUIMenuEvent.Fire(new UIMenuBehaviourData(this, _factoryObject, _buildingPanelToggles, _behaviour));
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

		private void StageCompleted(int _)
		{
			UpdateUI();
		}

		private void ResourcesCleared()
		{
			UpdateInput();
		}

		private void BuildUI()
		{
			SetStatus();
			_familyData = _familyDatabase.GetBuildingFamilyDataWithId(_behaviour.BuildingObjectData.FamilyID);
			_familyColor = _familyData.Color;
			BuildInput();
			BuildCraneInfo();
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
			UpdateMonumentUI();
			if (_enableCraneLimitValidator.IsEnabledFeatureFlag())
			{
				UpdateAddCraneButton();
			}
			_statusSwitch.SetIsOnWithoutNotify(_behaviour.IsBuildingActive);
			UpdateActivateMonumentButton();
		}

		private void UpdateActivateMonumentButton()
		{
			bool isActivated = _factoryObjectBehaviour.FactoryObject.GetFactoryObjectBehaviour<MonumentBehaviour>().IsActivated;
			bool flag = _behaviour.AllRequirementsMet();
			_activateMonumentButton.gameObject.SetActive(!isActivated && flag);
		}

		private void UpdateMonumentUI()
		{
			_chargingContainer.gameObject.SetActive(_behaviour.MaxBuildingStageReached && _behaviour.CanMonumentBeCharged);
			_storageContainer.gameObject.SetActive(_behaviour.MaxBuildingStageReached && _behaviour.CanMonumentBeCharged);
			_monumentEffectContainer.gameObject.SetActive(!_behaviour.IsUpgrading && _behaviour.CanMonumentBeCharged);
			_cantChargeYetText.gameObject.SetActive(_behaviour.MaxBuildingStageReached && !_behaviour.CanMonumentBeCharged);
			_monumentEffectBackgroundImage.color = new Color(_behaviour.ChargeColor.r, _behaviour.ChargeColor.g, _behaviour.ChargeColor.b, 0.1f);
			_monumentEffectImage.sprite = _behaviour.ChargeIcon;
			_chargingDataShardImage.sprite = _behaviour.DataShardToCharge.Sprite;
			_storageModuleContainer.Build(_behaviour.DataShardToCharge.Sprite);
			int smallestAmountOfResources;
			int smallestMultiplier = _behaviour.GetSmallestMultiplier(out smallestAmountOfResources);
			_storageModuleContainer.UpdateAmounts(_behaviour.CurrentDataShardAmount, _behaviour.MaxStorageAmount, smallestAmountOfResources, smallestMultiplier);
			string localizedText = LocalizationUtility.GetLocalizedText(_consumingTextLocaKey);
			int num = Mathf.RoundToInt((float)FactoryUpdater.Instance.GetUnscaledStepsPerSecond() / (float)_behaviour.UpdateFrequencyForReducingDatashards * 60f);
			_consumingText.SetText(string.Format(localizedText, num));
			_chargeText.SetText(LocalizationUtility.GetLocalizedText(_behaviour.ChargeTextLocaKey));
			string key = (_behaviour.IsCharged ? _activeLocaKey : _inactiveLocaKey);
			_activeText.SetText(LocalizationUtility.GetLocalizedText(key));
		}

		private void UpdateMonumentUIAmounts()
		{
			int smallestAmountOfResources;
			int smallestMultiplier = _behaviour.GetSmallestMultiplier(out smallestAmountOfResources);
			_storageModuleContainer.UpdateAmounts(_behaviour.CurrentDataShardAmount, _behaviour.MaxStorageAmount, smallestAmountOfResources, smallestMultiplier);
			string key = (_behaviour.IsCharged ? _activeLocaKey : _inactiveLocaKey);
			_activeText.SetText(LocalizationUtility.GetLocalizedText(key));
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
			if (_currentStatus == BuildingStatus.Upgrading)
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

		private void UpdateOutput()
		{
			string productionLevel = _behaviour.BuildingObjectData.GetProductionLevelAtStage(_behaviour.CurrentBuildingStage).ToString();
			UpdateStats(productionLevel);
		}

		private void UpdateStats(string productionLevel)
		{
			_statsPanel.SetActive(_currentStatus != BuildingStatus.UnderConstruction && !_behaviour.MaxBuildingStageReached);
			_statsFloorsText.SetText($"{_behaviour.CurrentBuildingStage}/{_behaviour.MaxBuildingStage}");
			_statsProductionLevelText.SetText($"{productionLevel}/{_behaviour.BuildingObjectData.GetProductionLevelAtStageMax()}");
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
			_inputResourcePanel.SetActive(!_behaviour.MaxBuildingStageReached);
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

		private void UpdateFillBar()
		{
			bool flag = !_isBuildingComplete && _state == AbstractUIMenuData.UIMenuState.InfoMode;
			_progressBarContainer.gameObject.SetActive(!_isBuildingComplete);
			_monumentProgressBarContainer.gameObject.SetActive((_isBuildingComplete || flag) && _behaviour.CanMonumentBeCharged);
			_progressBar.fillAmount = _behaviour.CurrentProgress;
			if (flag)
			{
				_monumentProgressBar.fillAmount = _behaviour.CurrentProgress;
			}
		}

		private void UpdateMonumentChargeBar()
		{
			if (_isBuildingComplete || _state != AbstractUIMenuData.UIMenuState.InfoMode)
			{
				_monumentProgressBar.fillAmount = Mathf.Clamp01((float)_behaviour.CurrentStepsWithDataShards / (float)_behaviour.StepsForChargeToBegin);
			}
			_monumentProgressBar.color = (_behaviour.IsCharged ? _behaviour.ChargeColor : Color.white);
			_monumentEffectBackgroundImage.color = (_behaviour.IsCharged ? _transparentChargeColor : _transparentColor);
			_monumentEffectImageCanvasGroup.alpha = (_behaviour.IsCharged ? 1f : 0.5f);
		}

		public void Upgrade()
		{
			if (!_behaviour.MaxLockedBuildingStageReached)
			{
				ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				if (_currency.TryBuy(upgradeCost))
				{
					_behaviour.StartUpgrading();
					UpdateUI();
				}
			}
		}

		private void OnClickModuleButton((BuildingObjectData, int) dataAndIndex)
		{
			if (base.gameObject.activeSelf)
			{
				HideMenu();
			}
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as MonumentBuildingBehaviour;
			_transparentChargeColor = new Color(_behaviour.ChargeColor.r, _behaviour.ChargeColor.g, _behaviour.ChargeColor.b, 0.1f);
			_transparentColor = new Color(0f, 0f, 0f, 0f);
			FactoryObjectViewManager.Instance.TryGetFactoryObjectView(_factoryObjectBehaviour.FactoryObject.CreatedId, out var view);
			_behaviour.OnShapeAdded.RegisterMainThread(UpdateInput);
			_behaviour.OnStageCompleted.RegisterMainThread(StageCompleted);
			_behaviour.OnClearedResources.RegisterMainThread(ResourcesCleared);
			BuildUI();
			_behaviour.OnAllShapesReceived += HandleMonumentAllShapesReceived;
			if (_behaviour.AllRequirementsMet())
			{
				HandleMonumentAllShapesReceived();
			}
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
			_behaviour.OnStageCompleted.UnRegisterMainThread(StageCompleted);
			_behaviour.OnClearedResources.UnRegisterMainThread(ResourcesCleared);
			if (_activeBuildingVFX != null)
			{
				_activeBuildingVFX.Hide();
				_activeBuildingVFX = null;
			}
			base.HideMenu();
		}
	}
}
