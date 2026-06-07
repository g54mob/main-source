using System;
using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Resources;
using Data.Variables.Drones;
using Events;
using Events.FactoryFloor.Buildings;
using Events.FactoryFloor.Tools;
using Events.Generic;
using Events.UI.Overlays;
using Logic.FactoryTools;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews;
using Presentation.UI.Buttons;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.HarvesterPad
{
	public class HarvesterPadUI : FactoryPanelUIMenu
	{
		[Header("UI Refs")]
		[SerializeField]
		private TextMeshProUGUI _assignedDronesText;

		[SerializeField]
		private Transform _buttonContainer;

		[SerializeField]
		private Button _linkBuildingBtn;

		[SerializeField]
		private Button _unlinkBuildingBtn;

		[SerializeField]
		private Button _unlinkAllBuildingsBtn;

		[SerializeField]
		private ButtonEnabler _linkBuildingBtnEnabler;

		[SerializeField]
		private ButtonEnabler _unlinkBuildingBtnEnabler;

		[SerializeField]
		private ButtonEnabler _unlinkAllBuildingsBtnEnabler;

		[SerializeField]
		private TextMeshProUGUI _resourceAmountText;

		[SerializeField]
		[LocaKey]
		private string _resourceAmountLocaKey;

		[SerializeField]
		private DroneMaxAmountPerHarvesterPadData _droneMaxAmountPerHarvesterPadData;

		[Header("Select Tool Refs")]
		[SerializeField]
		private SelectFactoryObjectTool _selectFactoryObjectTool;

		[SerializeField]
		private SelectFactoryObjectToolEvent _selectFactoryObjectToolEvent;

		[SerializeField]
		private SelectFactoryObjectEvent _selectFactoryObjectEvent;

		[SerializeField]
		private BaseEvent _selectFactoryObjectCancelledEvent;

		[SerializeField]
		private Texture2D _linkingCursorTexture;

		[SerializeField]
		private Texture2D _blockedCursorTexture;

		[SerializeField]
		[LocaKey]
		private string _cantLinkWrongResourceTextKey;

		[SerializeField]
		[LocaKey]
		private string _cantLinkAlreadyLinkedTextKey;

		[SerializeField]
		[LocaKey]
		private string _outsideRangeLinkTextKey;

		[SerializeField]
		[LocaKey]
		private string _linkedBuildingsLocaKey;

		[SerializeField]
		[LocaKey]
		private string _differentResourceLinkedLocaKey;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[Header("Estimated Output")]
		[SerializeField]
		private GameObject _estimatedOutputPanel;

		[SerializeField]
		[LocaKey]
		private string _estimatedOutputHoverLocaKey;

		[SerializeField]
		private LocalizedTMPText _estimatedOutputText;

		[SerializeField]
		private TextInfoPanelContent _estimatedOutputHoverTextPanel;

		[Header("Collecting resource")]
		[SerializeField]
		private GameObject _collectingResourceParent;

		[SerializeField]
		private Image _collectingResourceImage;

		[SerializeField]
		private TextMeshProUGUI _collectingResourceText;

		[SerializeField]
		private ResourceInfoPanelContent _resourceInfoPanelContent;

		[SerializeField]
		private Image _capacityFillBar;

		[SerializeField]
		private TextMeshProUGUI _currentAmountText;

		[SerializeField]
		private TextMeshProUGUI _maxAmountText;

		[SerializeField]
		private Sprite _noSpecificResourceSprite;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _linkButtonClickedEvent;

		[SerializeField]
		private BuildingResourceEvent _showBuildingResources;

		[SerializeField]
		private BuildingResourceEvent _hideBuildingResources;

		[SerializeField]
		private SetCursorEvent _setCursorEvent;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		private readonly List<Type> _neededBehaviourTypes = new List<Type>
		{
			typeof(BuildingBehaviour),
			typeof(ReferenceFactoryObjectBehaviour)
		};

		private readonly List<Type> _excludedBehaviourTypes = new List<Type>
		{
			typeof(MonumentBuildingBehaviour),
			typeof(OverclockStationBehaviour),
			typeof(GNNGateBehaviour)
		};

		private BuildingBehaviour _hoveredBuilding;

		private HarvesterPadBehaviour _behaviour;

		private ReferenceBehaviourLinksView _linksView;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private bool _isShowingLinkLine;

		private FactoryObject _lastLinkLineObject;

		private bool _hoverTargetIsValid;

		private bool _hoverTargetIsInRange;

		protected override void HandleOnAwake()
		{
			_selectFactoryObjectCancelledEvent.Register(StopSelectTool);
		}

		protected override void HandleOnDestroy()
		{
			_selectFactoryObjectCancelledEvent.UnRegister(StopSelectTool);
			_selectFactoryObjectCancelledEvent.UnRegister(ShowButtons);
		}

		private void StartLinking()
		{
			_showBuildingResources.Fire((_behaviour.LinkedBuildingsCount > 0) ? _behaviour.ResourceData : null);
			_linksView.ShowLinks();
			_selectFactoryObjectTool.OnHoverOverObject += LinkingHoverOverObject;
		}

		private void StartUnlinking()
		{
			_linksView.ShowLinks();
			_selectFactoryObjectTool.OnHoverOverObject += UnlinkingHoverOverObject;
			_updateSelectionBoxColor.Fire(new Color(1f, 0.2f, 0.2f, 1f));
		}

		private void StopSelectTool()
		{
			if (_hoveredBuilding != null)
			{
				_hoveredBuilding.BuildingLandingPad.HideLandingPadPreview();
			}
			_hoveredBuilding = null;
			_selectFactoryObjectTool.OnHoverOverObject -= UpdateLandingPadPreview;
			_hideBuildingResources.Fire((_behaviour.LinkedBuildingsCount > 0) ? _behaviour.ResourceData : null);
			_linksView.HideLinks();
			_selectFactoryObjectTool.OnHoverOverObject -= LinkingHoverOverObject;
			_selectFactoryObjectTool.OnHoverOverObject -= UnlinkingHoverOverObject;
		}

		public void ShowAllUnlinks()
		{
			foreach (ReferenceFactoryObjectBehaviour referencedObject in _referenceBehaviour.ReferencedObjects)
			{
				_linksView.ShowLineToFactoryObjectOverrideColor(referencedObject.FactoryObject, 1.15f, new Color(1f, 0.2f, 0.2f, 1f));
				_linksView.OverrideIsShowingLinks(isShowingLinks: false);
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(referencedObject.FactoryObject.CreatedId, out var view))
				{
					view.Select();
					if (view.TryGetComponent<HighlightOutline>(out var component))
					{
						component.SetColor(new Color(1f, 0.2f, 0.2f, 1f));
					}
				}
			}
			_linksView.OverrideIsShowingLinks(isShowingLinks: true);
		}

		public void HideAllUnlinks()
		{
			_linksView.HideLinks();
			foreach (ReferenceFactoryObjectBehaviour referencedObject in _referenceBehaviour.ReferencedObjects)
			{
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(referencedObject.FactoryObject.CreatedId, out var view))
				{
					view.DeSelect();
				}
			}
		}

		private void LinkingHoverOverObject(FactoryObject factoryObject, bool isNotNull)
		{
			if (!isNotNull && _isShowingLinkLine)
			{
				_linksView.HideLinks();
				_linksView.ShowLinks();
				_isShowingLinkLine = false;
				_lastLinkLineObject = null;
			}
			else if (factoryObject != _lastLinkLineObject && _hoverTargetIsValid)
			{
				_linksView.HideLinks();
				_linksView.ShowLinks();
				_linksView.ShowLineToFactoryObject(factoryObject, 0.7f, new Color(1f, 1f, 1f, 0.6f));
				_lastLinkLineObject = factoryObject;
				_isShowingLinkLine = true;
			}
		}

		private void UnlinkingHoverOverObject(FactoryObject factoryObject, bool isNotNull)
		{
			ReferenceFactoryObjectBehaviour behaviour;
			if (!isNotNull && _isShowingLinkLine)
			{
				_linksView.HideLinks();
				_linksView.ShowLinks();
				_isShowingLinkLine = false;
				_lastLinkLineObject = null;
			}
			else if (factoryObject != _lastLinkLineObject && factoryObject.TryGetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>(out behaviour) && _referenceBehaviour.ReferencedObjects.Contains(behaviour))
			{
				_linksView.HideLinks();
				_linksView.ShowLineToFactoryObjectOverrideColor(factoryObject, 1.15f, new Color(1f, 0.2f, 0.2f, 1f));
				_linksView.OverrideIsShowingLinks(isShowingLinks: false);
				_linksView.ShowLinks();
				_lastLinkLineObject = factoryObject;
				_isShowingLinkLine = true;
			}
		}

		private void LinkedBuildingsCountChanged(int linkedBuildings)
		{
			UpdateCollectingResourceUI();
			UpdateButtonsState(linkedBuildings);
			UpdateEstimatedOutputUI(linkedBuildings);
			UpdateLinkedBuildingsText(linkedBuildings);
		}

		private void UpdateButtonsState(int linkedBuildings)
		{
			_linkBuildingBtnEnabler.Interactable = linkedBuildings < _behaviour.MaxLinkedBuildings;
			_unlinkBuildingBtnEnabler.Interactable = linkedBuildings > 0;
			_unlinkAllBuildingsBtnEnabler.Interactable = linkedBuildings > 0;
		}

		private void ShowButtons()
		{
			if (_buttonContainer == null || _buttonContainer.gameObject == null)
			{
				_selectFactoryObjectCancelledEvent.UnRegister(ShowButtons);
			}
			else
			{
				_buttonContainer.gameObject.SetActive(value: true);
			}
		}

		private void HideButtons()
		{
			_buttonContainer.gameObject.SetActive(value: false);
		}

		private void UpdateLinkedBuildingsText(int linkedBuildings)
		{
			_assignedDronesText.SetText($"{LocalizationUtility.GetLocalizedText(_linkedBuildingsLocaKey)} <color=#e02f54>{linkedBuildings}</color>/{_behaviour.MaxLinkedBuildings}");
		}

		private void LinkSelectedBuilding(FactoryObject factoryObject)
		{
			if (!_hoverTargetIsValid)
			{
				return;
			}
			BuildingBehaviour factoryObjectBehaviour = factoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
			if (_behaviour.HasSpecificResource && factoryObjectBehaviour.BuildingObjectData.ResourceOutputs[0].ResourceData != _behaviour.ResourceData)
			{
				ModalDialogDto dto = new ModalDialogDto(new ModalDialogContent(_differentResourceLinkedLocaKey), Sizes.M, delegate
				{
					ClearPadAndLinkSelectedBuilding(factoryObject);
				}, showCancelButton: true);
				_showModalDialogEvent.Fire(new UIModaldialogData(dto));
			}
			else
			{
				TryLinkSelectedBuilding(factoryObject);
			}
		}

		private void ClearPadAndLinkSelectedBuilding(FactoryObject factoryObject)
		{
			_behaviour.ClearHarvesterPadResources();
			TryLinkSelectedBuilding(factoryObject);
		}

		private void TryLinkSelectedBuilding(FactoryObject factoryObject)
		{
			_selectFactoryObjectTool.OnHoverOverObject -= UpdateLandingPadPreview;
			factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>().AddReference(_referenceBehaviour);
			ShowButtons();
			StopSelectTool();
			if (_behaviour.LinkedBuildingsCount < _behaviour.MaxLinkedBuildings)
			{
				LinkBuildingBtnPressed();
			}
			else
			{
				_selectFactoryObjectTool.CallOnComplete();
			}
			_audioManagerLocator.AudioManager.PlayLinkBuilding(factoryObject.Position);
		}

		private void UnLinkSelectedBuilding(FactoryObject factoryObject)
		{
			if (_hoverTargetIsValid)
			{
				StopSelectTool();
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view) && view.TryGetComponent<ReferenceBehaviourLinksView>(out var component))
				{
					component.HideLinks();
				}
				factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>().RemoveReference(_referenceBehaviour);
				if (_behaviour.LinkedBuildingsCount <= 0)
				{
					_selectFactoryObjectTool.CallOnComplete();
				}
				else
				{
					StartUnlinking();
				}
				_audioManagerLocator.AudioManager.PlayUnlinkBuilding(factoryObject.Position);
			}
		}

		private void LinkBuildingBtnPressed()
		{
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.HarvesterPadLinking");
			_selectFactoryObjectToolEvent.Fire(_neededBehaviourTypes);
			_selectFactoryObjectTool.SetExcludedFactoryObjectBehaviours(_excludedBehaviourTypes);
			_selectFactoryObjectTool.OnHoverOverObject += UpdateLandingPadPreview;
			_selectFactoryObjectEvent.Register(LinkSelectedBuilding);
			StartLinking();
			HideButtons();
			HideMenu();
			_linkButtonClickedEvent.Fire();
		}

		private void UnlinkBuildingBtnPressed()
		{
			_selectFactoryObjectTool.SetCursor();
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.HarvesterPadUnlinking");
			_selectFactoryObjectToolEvent.Fire(_neededBehaviourTypes);
			_selectFactoryObjectTool.SetExcludedFactoryObjectBehaviours(_excludedBehaviourTypes);
			_selectFactoryObjectTool.OnHoverOverObject += UpdateUnlinkingState;
			_selectFactoryObjectEvent.Register(UnLinkSelectedBuilding);
			StartUnlinking();
			HideButtons();
			HideMenu();
		}

		private void UnlinkAllBuildingsBtnPressed()
		{
			foreach (ReferenceFactoryObjectBehaviour referencedObject in _referenceBehaviour.ReferencedObjects)
			{
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(referencedObject.FactoryObject.CreatedId, out var view))
				{
					view.DeSelect();
				}
			}
			_behaviour.UnlinkFromAllBuildings();
			_linksView.HideLinks();
			_audioManagerLocator.AudioManager.PlayUnlinkBuilding(_linksView.transform.position);
		}

		private void UpdateUnlinkingState(FactoryObject factoryObject, bool isValid)
		{
			_selectFactoryObjectTool.SetCursor();
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.HarvesterPadUnlinking");
			_hoverTargetIsValid = isValid;
		}

		private void UpdateLandingPadPreview(FactoryObject factoryObject, bool isValid)
		{
			_selectFactoryObjectTool.SetCursor();
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.HarvesterPadLinking");
			_hoverTargetIsValid = isValid;
			BuildingBehaviour buildingBehaviour = null;
			if (_hoverTargetIsValid)
			{
				buildingBehaviour = factoryObject.GetFactoryObjectBehaviour<BuildingBehaviour>();
				if (_behaviour.LinkedBuildingsCount > 0 && _behaviour.ResourceData != buildingBehaviour.BuildingObjectData.ResourceOutputs[0].ResourceData)
				{
					_hoverTargetIsValid = false;
					if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view) && view.TryGetComponent<FactoryObjectSelectedVisuals>(out var component))
					{
						component.ValidPositionChanged(isValid: false);
					}
					_setCursorEvent.Fire((_blockedCursorTexture, LocalizationUtility.GetLocalizedText(_cantLinkWrongResourceTextKey), Vector2.zero));
				}
			}
			if (!_hoverTargetIsValid)
			{
				if (_hoveredBuilding != null)
				{
					_hoveredBuilding.BuildingLandingPad.HideLandingPadPreview();
				}
				_hoveredBuilding = null;
			}
			else if (buildingBehaviour.BuildingLandingPad.Exists)
			{
				if (_hoveredBuilding != null)
				{
					_hoveredBuilding.BuildingLandingPad.HideLandingPadPreview();
				}
				_setCursorEvent.Fire((_blockedCursorTexture, LocalizationUtility.GetLocalizedText(_cantLinkAlreadyLinkedTextKey), Vector2.zero));
				_hoverTargetIsValid = false;
			}
			else if (!_behaviour.IsPointInsideLinkingDistance(factoryObject.Position))
			{
				if (_hoveredBuilding != null)
				{
					_hoveredBuilding.BuildingLandingPad.HideLandingPadPreview();
				}
				_setCursorEvent.Fire((_blockedCursorTexture, LocalizationUtility.GetLocalizedText(_outsideRangeLinkTextKey), Vector2.zero));
				_hoverTargetIsValid = false;
			}
			else if (!(_hoveredBuilding == buildingBehaviour))
			{
				if (_hoveredBuilding != null)
				{
					_hoveredBuilding.BuildingLandingPad.HideLandingPadPreview();
				}
				_hoveredBuilding = buildingBehaviour;
				buildingBehaviour.BuildingLandingPad.ShowLandingPadPreview(_behaviour.Position);
				_setCursorEvent.Fire((_linkingCursorTexture, string.Empty, Vector2.zero));
			}
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as HarvesterPadBehaviour;
			_referenceBehaviour = _factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(_factoryObject.CreatedId, out var view))
			{
				view.TryGetComponent<ReferenceBehaviourLinksView>(out _linksView);
			}
			_behaviour.OnLinkedBuildingsCountChanged.RegisterMainThread(LinkedBuildingsCountChanged);
			_behaviour.OnResourceCountChanged.RegisterMainThread(UpdateResourceAmount);
			_linkBuildingBtn.onClick.AddListener(LinkBuildingBtnPressed);
			_unlinkBuildingBtn.onClick.AddListener(UnlinkBuildingBtnPressed);
			_unlinkAllBuildingsBtn.onClick.AddListener(UnlinkAllBuildingsBtnPressed);
			_selectFactoryObjectCancelledEvent.Register(ShowButtons);
			UpdateCollectingResourceUI();
			UpdateResourceAmount();
			UpdateEstimatedOutputUI(_behaviour.LinkedBuildingsCount);
			LinkedBuildingsCountChanged(_behaviour.LinkedBuildingsCount);
			ShowButtons();
			_resourceAmountText.text = string.Format(LocalizationUtility.GetLocalizedText(_resourceAmountLocaKey), _droneMaxAmountPerHarvesterPadData.Value);
		}

		public override void HideMenu()
		{
			_behaviour.OnLinkedBuildingsCountChanged.UnRegisterMainThread(LinkedBuildingsCountChanged);
			_behaviour.OnResourceCountChanged.UnRegisterMainThread(UpdateResourceAmount);
			_linkBuildingBtn.onClick.RemoveListener(LinkBuildingBtnPressed);
			_unlinkBuildingBtn.onClick.RemoveListener(UnlinkBuildingBtnPressed);
			_unlinkAllBuildingsBtn.onClick.RemoveListener(UnlinkAllBuildingsBtnPressed);
			_selectFactoryObjectCancelledEvent.UnRegister(ShowButtons);
			_behaviour.OperatorStateBehaviour.ResetState();
			base.HideMenu();
		}

		private void UpdateCollectingResourceUI()
		{
			if (_behaviour.HasSpecificResource)
			{
				NonShapeResourceDataSO nonShapeResourceDataSO = _behaviour.ResourceData as NonShapeResourceDataSO;
				_collectingResourceImage.sprite = nonShapeResourceDataSO.Sprite;
				_collectingResourceText.SetText(LocalizationUtility.GetLocalizedText(nonShapeResourceDataSO.NameLocaKey));
				_resourceInfoPanelContent.UpdateContent(nonShapeResourceDataSO);
				_resourceInfoPanelContent.enabled = true;
			}
			else
			{
				_collectingResourceImage.sprite = _noSpecificResourceSprite;
				_collectingResourceText.SetText(string.Empty);
				_resourceInfoPanelContent.ClearContent();
				_resourceInfoPanelContent.enabled = false;
			}
		}

		private void UpdateEstimatedOutputUI(int linkedBuildings)
		{
			_estimatedOutputPanel.SetActive(linkedBuildings > 0);
			if (!_estimatedOutputPanel.activeSelf)
			{
				return;
			}
			double num = 0.0;
			foreach (BuildingBehaviour linkedBuilding in _behaviour.LinkedBuildings)
			{
				num += linkedBuilding.CalculateEstimatedOutputSpeed();
			}
			string replacementText = string.Empty;
			if (_behaviour.HasSpecificResource)
			{
				replacementText = LocalizationUtility.GetLocalizedText((_behaviour.ResourceData as NonShapeResourceDataSO).NameLocaKey);
			}
			_estimatedOutputText.SetArguments(num.ToString());
			_estimatedOutputHoverTextPanel.UpdateContent(_estimatedOutputHoverLocaKey, num.ToString(), replacementText);
		}

		private void UpdateResourceAmount()
		{
			int currentResourceCount = _behaviour.CurrentResourceCount;
			float fillAmount = Mathf.Clamp01((float)currentResourceCount / (float)_behaviour.MaxStorage);
			_capacityFillBar.fillAmount = fillAmount;
			_currentAmountText.SetText(currentResourceCount.ToString());
			_maxAmountText.SetText($"/{_behaviour.MaxStorage}");
			if (currentResourceCount >= _behaviour.MaxStorage && _isOpen)
			{
				_behaviour.OperatorStateBehaviour.SetStateHarvesterPadFull();
			}
			else
			{
				_behaviour.OperatorStateBehaviour.ResetState();
			}
		}
	}
}
