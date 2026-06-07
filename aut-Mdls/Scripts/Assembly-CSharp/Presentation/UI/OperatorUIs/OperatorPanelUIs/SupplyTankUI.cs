using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Drones;
using Data.FactoryFloor.Resources;
using Data.FactoryFloor.Tools;
using Events;
using Events.FactoryFloor.Tools;
using Events.Generic;
using Logic.FactoryTools;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews;
using Presentation.UI.Buttons;
using Presentation.UI.Menus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class SupplyTankUI : FactoryPanelUIMenu
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
		private SupplyTankDroneBehaviour _supplyTankDroneBehaviour;

		[SerializeField]
		[LocaKey]
		private string _droneServiceTimeLocaKey;

		[SerializeField]
		private Texture2D _linkingCursorTexture;

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
		private TextMeshProUGUI _droneAmountText;

		[SerializeField]
		private Sprite _noSpecificResourceSprite;

		[Header("UX Refs")]
		[SerializeField]
		private BaseEvent _showSupplyTankRecipientHighlight;

		[SerializeField]
		private BaseEvent _hideSupplyTankRecipientHighlight;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private ToolColorLibrary _toolColorLibrary;

		[SerializeField]
		[LocaKey]
		private string _alreadyServicedLocaKey;

		[SerializeField]
		private SetCursorEvent _setCursorEvent;

		[SerializeField]
		private Texture2D _blockedCursorTexture;

		private readonly List<Type> _neededBehaviourTypes = new List<Type>
		{
			typeof(SupplyTankRecipientBehaviour),
			typeof(ReferenceFactoryObjectBehaviour)
		};

		private SupplyTankBehaviour _behaviour;

		private ReferenceBehaviourLinksView _linksView;

		private ReferenceFactoryObjectBehaviour _referenceBehaviour;

		private bool _isShowingLinkLine;

		private FactoryObject _lastLinkLineObject;

		protected override void HandleOnAwake()
		{
			_selectFactoryObjectCancelledEvent.Register(StopSelectTool);
		}

		protected override void HandleOnDestroy()
		{
			_selectFactoryObjectCancelledEvent.UnRegister(StopSelectTool);
		}

		private void StartLinking()
		{
			_showSupplyTankRecipientHighlight.Fire();
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
			_hideSupplyTankRecipientHighlight.Fire();
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
			_selectFactoryObjectTool.SetCursor();
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.SupplyTankLinking");
			if (!isNotNull)
			{
				if (_isShowingLinkLine)
				{
					_linksView.HideLinks();
					_linksView.ShowLinks();
					_isShowingLinkLine = false;
				}
				_lastLinkLineObject = null;
			}
			else
			{
				if (factoryObject == _lastLinkLineObject || !factoryObject.TryGetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>(out var behaviour))
				{
					return;
				}
				if (behaviour.ReferencedObjects.Count > 0)
				{
					_setCursorEvent.Fire((_blockedCursorTexture, LocalizationUtility.GetLocalizedText(_alreadyServicedLocaKey), Vector2.zero));
					_lastLinkLineObject = factoryObject;
					return;
				}
				if (factoryObject.TryGetFactoryObjectBehaviour<SupplyTankRecipientBehaviour>(out var behaviour2))
				{
					Vector3 freeDronePosition = _behaviour.GetFreeDronePosition();
					Vector3 dronePadPosition = behaviour2.GetDronePadPosition();
					_supplyTankDroneBehaviour.CalculateTotalFlyTimeOfADrone(freeDronePosition, dronePadPosition, out var _, out var totalTimeInSeconds);
					string item = $"{LocalizationUtility.GetLocalizedText(_droneServiceTimeLocaKey)}{totalTimeInSeconds:0.00}s";
					_setCursorEvent.Fire((_linkingCursorTexture, item, Vector2.zero));
				}
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

		private void LinkedRecipientsCountChanged(int linkedBuildings)
		{
			UpdateCollectingResourceUI();
			UpdateButtonsState(linkedBuildings);
			UpdateLinkedBuildingsText(linkedBuildings);
		}

		private void UpdateButtonsState(int linkedBuildings)
		{
			_linkBuildingBtnEnabler.Interactable = linkedBuildings < _behaviour.MaxLinkedRecipients;
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
			_assignedDronesText.SetText(string.Format("{0} <color=#e02f54>{1}</color>/{2}", LocalizationUtility.GetLocalizedText("SupplyTank.Assigned"), linkedBuildings, _behaviour.MaxLinkedRecipients));
			_droneAmountText.SetText(_behaviour.MaxLinkedRecipients.ToString());
		}

		private void LinkSelectedRecipient(FactoryObject factoryObject)
		{
			if (!_isShowingLinkLine)
			{
				return;
			}
			ReferenceFactoryObjectBehaviour factoryObjectBehaviour = factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			if (factoryObjectBehaviour.ReferencedObjects.Count <= 0)
			{
				factoryObjectBehaviour.AddReference(_referenceBehaviour);
				ShowButtons();
				StopSelectTool();
				if (_behaviour.LinkedRecipientsCount < _behaviour.MaxLinkedRecipients)
				{
					LinkRecipientBtnPressed();
				}
				else
				{
					_selectFactoryObjectTool.CallOnComplete();
				}
				_audioManagerLocator.AudioManager.PlayLinkBuilding(factoryObject.Position);
			}
		}

		private void UnLinkSelectedRecipient(FactoryObject factoryObject)
		{
			factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>().RemoveReference(_referenceBehaviour);
			ShowButtons();
			StopSelectTool();
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view) && view.TryGetComponent<ReferenceBehaviourLinksView>(out var component))
			{
				component.HideLinks();
			}
			if (_behaviour.LinkedRecipientsCount <= 0)
			{
				_selectFactoryObjectTool.CallOnComplete();
			}
			else
			{
				StartUnlinking();
			}
			_audioManagerLocator.AudioManager.PlayUnlinkBuilding(factoryObject.Position);
		}

		private void LinkRecipientBtnPressed()
		{
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.SupplyTankLinking");
			_selectFactoryObjectToolEvent.Fire(_neededBehaviourTypes);
			_selectFactoryObjectEvent.Register(LinkSelectedRecipient);
			StartLinking();
			HideButtons();
			HideMenu();
		}

		private void UnlinkBuildingBtnPressed()
		{
			_selectFactoryObjectTool.SetCursorTextKey("Cursor.SupplyTankUnlinking");
			_selectFactoryObjectToolEvent.Fire(_neededBehaviourTypes);
			_selectFactoryObjectEvent.Register(UnLinkSelectedRecipient);
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
			_behaviour.UnlinkAllRecipients();
			_linksView.HideLinks();
			_audioManagerLocator.AudioManager.PlayUnlinkBuilding(_linksView.transform.position);
		}

		protected override void Initialized()
		{
			_behaviour = _factoryObjectBehaviour as SupplyTankBehaviour;
			_referenceBehaviour = _factoryObject.GetFactoryObjectBehaviour<ReferenceFactoryObjectBehaviour>();
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(_factoryObject.CreatedId, out var view))
			{
				view.TryGetComponent<ReferenceBehaviourLinksView>(out _linksView);
			}
			_behaviour.OnLinkedRecipientsCountChanged.RegisterMainThread(LinkedRecipientsCountChanged);
			_behaviour.OnResourceCountChanged.RegisterMainThread(UpdateResourceAmount);
			_linkBuildingBtn.onClick.AddListener(LinkRecipientBtnPressed);
			_unlinkBuildingBtn.onClick.AddListener(UnlinkBuildingBtnPressed);
			_unlinkAllBuildingsBtn.onClick.AddListener(UnlinkAllBuildingsBtnPressed);
			_selectFactoryObjectCancelledEvent.Register(ShowButtons);
			UpdateCollectingResourceUI();
			UpdateResourceAmount();
			LinkedRecipientsCountChanged(_behaviour.LinkedRecipientsCount);
			ShowButtons();
		}

		public override void HideMenu()
		{
			_behaviour.OnLinkedRecipientsCountChanged.UnRegisterMainThread(LinkedRecipientsCountChanged);
			_behaviour.OnResourceCountChanged.UnRegisterMainThread(UpdateResourceAmount);
			_linkBuildingBtn.onClick.RemoveListener(LinkRecipientBtnPressed);
			_unlinkBuildingBtn.onClick.RemoveListener(UnlinkBuildingBtnPressed);
			_unlinkAllBuildingsBtn.onClick.RemoveListener(UnlinkAllBuildingsBtnPressed);
			_selectFactoryObjectCancelledEvent.UnRegister(ShowButtons);
			base.HideMenu();
		}

		private void UpdateCollectingResourceUI()
		{
			if (_behaviour.IsStoringResource)
			{
				NonShapeResourceDataSO nonShapeResourceDataSO = _behaviour.CurrentResourceData as NonShapeResourceDataSO;
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

		private void UpdateResourceAmount()
		{
			int currentResourceAmount = _behaviour.CurrentResourceAmount;
			float fillAmount = Mathf.Clamp01((float)currentResourceAmount / (float)_behaviour.MaxStorage);
			_capacityFillBar.fillAmount = fillAmount;
			_currentAmountText.SetText(currentResourceAmount.ToString());
			_maxAmountText.SetText($"/{_behaviour.MaxStorage}");
		}
	}
}
