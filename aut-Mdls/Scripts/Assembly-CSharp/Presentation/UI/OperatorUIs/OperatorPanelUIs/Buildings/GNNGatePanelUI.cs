using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Data.Shapes;
using Events.UI.ModuleViewer;
using FMODUnity;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Toolbar;
using Presentation.UI.LayoutElements;
using Presentation.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Buildings
{
	public class GNNGatePanelUI : FactoryPanelUIMenu
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

		[Header("GNN")]
		[SerializeField]
		private TextMeshProUGUI _phaseText;

		[SerializeField]
		[LocaKey]
		private string _phaseTextLocaKey;

		[Header("Refs")]
		[SerializeField]
		private ShowBuildingModulesEvent _showBuildingModulesEvent;

		[SerializeField]
		private CurrencyPersistentSO _currency;

		[Header("Status")]
		[SerializeField]
		private Transform _progressBarContainer;

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
		private GameObject _inputModulesPanel;

		[SerializeField]
		private Transform _inputResourcesGrid;

		[SerializeField]
		private InputResourceUI _inputResourceUIPrefab;

		[SerializeField]
		private Transform _inputModulesGrid;

		[SerializeField]
		private ModuleContainer _inputModuleContainerPrefab;

		[Header("Stats")]
		[SerializeField]
		private GameObject _statsPanel;

		[SerializeField]
		private TextMeshProUGUI _statsFloorsText;

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

		[Header("UI Behaviour")]
		[SerializeField]
		private GameObject _actionsPanel;

		[SerializeField]
		private Button _upgradeButton;

		[SerializeField]
		private Button _cancelUpgradeButton;

		[SerializeField]
		private FactoryToolLockedView _upgradeButtonLockView;

		[SerializeField]
		private UpgradeInfoPanelContent _upgradeButtonInfoPanel;

		[SerializeField]
		private TextInfoPanelContent _infoButtonInfoPanel;

		[Header("Audio")]
		[SerializeField]
		private EventReference _activateAudioEvent;

		[SerializeField]
		private EventReference _deactivateAudioEvent;

		private GNNGateBehaviour _behaviour;

		private Dictionary<BuildingStatus, BuildingUIData> _statusContent;

		private BuildingStatus _currentStatus;

		private bool _isBuildingComplete;

		private ResourceCost _currentUpgradeCost;

		private readonly List<ModuleContainer> _moduleContainers = new List<ModuleContainer>();

		private readonly List<InputResourceUI> _inputResources = new List<InputResourceUI>();

		private ActiveBuildingVFX _activeBuildingVFX;

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
			_statusSwitch.OnValueChanged.AddListener(SetActiveState);
			_showBuildingModulesEvent.Register(OnClickModuleButton);
			_upgradeButton.onClick.AddListener(Upgrade);
			_cancelUpgradeButton.onClick.AddListener(CancelUpgrade);
		}

		private void Update()
		{
			if (!(_behaviour == null) && _behaviour.CurrentBuildingStage > 0 && _behaviour.CurrentBuildingStage <= _behaviour.BuildingObjectData.Upgrades.Count)
			{
				_currentUpgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				_upgradeButtonLockView.IsVisuallyUnavailable = !_currency.HasEnoughResources(_currentUpgradeCost) || _behaviour.MaxLockedBuildingStageReached;
			}
		}

		protected override void HandleOnDestroy()
		{
			_statusSwitch.OnValueChanged.RemoveListener(SetActiveState);
			_showBuildingModulesEvent.UnRegister(OnClickModuleButton);
			_upgradeButton.onClick.RemoveListener(Upgrade);
			_cancelUpgradeButton.onClick.RemoveListener(CancelUpgrade);
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
			BuildInput();
			UpdateUI();
		}

		private void ResourcesCleared()
		{
			UpdateInput();
		}

		private void BuildUI()
		{
			SetStatus();
			BuildInput();
		}

		protected override void SetTexts()
		{
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_behaviour.BuildingObjectData.NameLocKey));
		}

		private void UpdateUI()
		{
			SetStatus();
			UpdateOutput();
			UpdateInput();
			UpdateStatusUI();
			SetUpgradePanelsActiveState();
			_statusSwitch.SetIsOnWithoutNotify(_behaviour.IsBuildingActive);
		}

		private void SetUpgradePanelsActiveState()
		{
			_upgradeButton.gameObject.SetActive(_currentStatus == BuildingStatus.Producing && !_isBuildingComplete);
			_cancelUpgradeButton.gameObject.SetActive(_currentStatus == BuildingStatus.Upgrading && !_isBuildingComplete);
			_actionsPanel.SetActive(_upgradeButton.gameObject.activeSelf || _cancelUpgradeButton.gameObject.activeSelf);
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
			string upgradeLevelCurrent = _behaviour.BuildingObjectData.GetProductionLevelAtStage(_behaviour.CurrentBuildingStage).ToString();
			string upgradeLevelNew = _behaviour.BuildingObjectData.GetProductionLevelAtStage(_behaviour.CurrentBuildingStage + 1).ToString();
			UpdateStats();
			if (_behaviour.CurrentBuildingStage > 0 && _behaviour.CurrentBuildingStage <= _behaviour.BuildingObjectData.Upgrades.Count)
			{
				ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
				bool hasOutput = _behaviour.BuildingObjectData.ResourceOutputs.Count > 0;
				_upgradeButtonInfoPanel.UpdateContent(upgradeCost, upgradeLevelCurrent, upgradeLevelNew, hasOutput, _iconProduction, $"x{0}");
				_upgradeButtonInfoPanel.enabled = !_behaviour.MaxLockedBuildingStageReached;
				_infoButtonInfoPanel.enabled = _behaviour.MaxLockedBuildingStageReached;
			}
		}

		private void UpdateStats()
		{
			_statsPanel.SetActive(_currentStatus != BuildingStatus.UnderConstruction && !_behaviour.MaxBuildingStageReached);
			_statsFloorsText.SetText($"{_behaviour.CurrentBuildingStage}/{_behaviour.MaxBuildingStage}");
			_behaviour.GetCurrentPhaseAndFloor(out var phase, out var floor, out var _);
			string text = string.Format(LocalizationUtility.GetLocalizedText(_phaseTextLocaKey), phase, floor);
			_phaseText.SetText(text);
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

		private void OnShapeAdded(ShapeData data, int arg2)
		{
			UpdateInput();
		}

		private void UpdateInput()
		{
			List<InputResourceUI> list = new List<InputResourceUI>();
			int moduleIndex = 0;
			int resourceIndex = 0;
			bool hasResourceInput = false;
			hasResourceInput = ShowBuildRequirements(moduleIndex, resourceIndex, hasResourceInput, list);
			foreach (InputResourceUI inputResource in _inputResources)
			{
				bool flag = list.Contains(inputResource);
				if (inputResource.gameObject.activeInHierarchy != flag)
				{
					inputResource.gameObject.SetActive(flag);
				}
			}
			bool isUpgrading = _behaviour.IsUpgrading;
			_inputResourcePanel.SetActive(hasResourceInput && isUpgrading);
			_inputModulesPanel.SetActive(isUpgrading);
			UpdateFillBar();
		}

		private bool ShowBuildRequirements(int moduleIndex, int resourceIndex, bool hasResourceInput, List<InputResourceUI> shouldStayActive)
		{
			for (int i = 0; i < _behaviour.BuildRequirements.Count; i++)
			{
				BuildingConstructionResource buildingConstructionResource = _behaviour.BuildRequirements[i];
				if (buildingConstructionResource is ShapeConstructionResource)
				{
					if (i < _moduleContainers.Count)
					{
						_moduleContainers[i].UpdateAmounts(buildingConstructionResource.Count, buildingConstructionResource.Max);
					}
					moduleIndex++;
					continue;
				}
				InputResourceUI inputResourceUI;
				if (resourceIndex >= _inputResources.Count)
				{
					inputResourceUI = Object.Instantiate(_inputResourceUIPrefab, _inputResourcesGrid);
					_inputResources.Add(inputResourceUI);
					shouldStayActive.Add(inputResourceUI);
				}
				else
				{
					inputResourceUI = _inputResources[resourceIndex];
					shouldStayActive.Add(inputResourceUI);
				}
				inputResourceUI.SetResource(buildingConstructionResource.ResourceData as NonShapeResourceDataSO);
				inputResourceUI.SetAmount(buildingConstructionResource.Count, $"/{buildingConstructionResource.Max}");
				resourceIndex++;
				hasResourceInput = true;
			}
			return hasResourceInput;
		}

		private void UpdateFillBar()
		{
			_progressBarContainer.gameObject.SetActive(!_isBuildingComplete);
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
					UpdateUI();
					_behaviour.CallCanReceiveNewResources();
				}
			}
		}

		public void CancelUpgrade()
		{
			ResourceCost upgradeCost = _behaviour.BuildingObjectData.Upgrades[_behaviour.CurrentBuildingStage - 1].UpgradeCost;
			_currency.AddResources(upgradeCost);
			_behaviour.StopUpgrading();
			UpdateUI();
		}

		private void OnClickModuleButton((BuildingObjectData, int) dataAndIndex)
		{
			if (base.gameObject.activeSelf)
			{
				HideMenu();
			}
		}

		private void OnUpgradeStateChanged(bool _)
		{
			BuildInput();
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as GNNGateBehaviour;
			FactoryObjectViewManager.Instance.TryGetFactoryObjectView(_factoryObjectBehaviour.FactoryObject.CreatedId, out var view);
			_behaviour.OnShapeAdded.RegisterMainThread(OnShapeAdded);
			_behaviour.OnStageCompleted.RegisterMainThread(StageCompleted);
			_behaviour.OnClearedResources.RegisterMainThread(ResourcesCleared);
			_behaviour.OnUpgradeStateChanged.RegisterMainThread(OnUpgradeStateChanged);
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
			_behaviour.OnShapeAdded.UnRegisterMainThread(OnShapeAdded);
			_behaviour.OnStageCompleted.UnRegisterMainThread(StageCompleted);
			_behaviour.OnClearedResources.UnRegisterMainThread(ResourcesCleared);
			_behaviour.OnUpgradeStateChanged.UnRegisterMainThread(OnUpgradeStateChanged);
			if (_activeBuildingVFX != null)
			{
				_activeBuildingVFX.Hide();
				_activeBuildingVFX = null;
			}
			base.HideMenu();
		}
	}
}
