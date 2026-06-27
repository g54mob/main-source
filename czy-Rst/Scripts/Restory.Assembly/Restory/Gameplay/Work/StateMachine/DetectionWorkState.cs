using System;
using Restory.Constants;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Common;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.Equipment.Levers;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.GameView;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.NPCs;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Tips;
using Restory.Gameplay.Tooltips;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UI.Presenters.RegularPayment;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public class DetectionWorkState : IState, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<DetectionWorkState>
		{
		}

		private readonly RaycastHit[] raycastHits = new RaycastHit[4];

		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly GameViewController gameViewController;

		private readonly DeviceService deviceService;

		private readonly WorkStateMachine workStateMachine;

		private readonly InteractiveObjectsTooltipsService tooltipsService;

		private readonly WorkSurface workSurface;

		private readonly NpcServiceMain npcServiceMain;

		private readonly ShipmentService shipmentService;

		private readonly GameWarningDatabase gameWarningDatabase;

		private readonly GameWarningService gameWarningService;

		private readonly GUI_RegularPayment guiRegularPayment;

		private readonly TipBoxService tipBoxService;

		private readonly TransferCashMoneyFromCashRegisterService transferCashMoneyFromCashRegisterService;

		private readonly LayerMask detectionLayerMask;

		private InteractiveObject selectedObject;

		[Inject]
		public DetectionWorkState(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, CameraDirectionSwitcher cameraDirectionSwitcher, GameViewController gameViewController, DeviceService deviceService, WorkStateMachine workStateMachine, InteractiveObjectsTooltipsService tooltipsService, WorkSurface workSurface, NpcServiceMain npcServiceMain, ShipmentService shipmentService, GameWarningDatabase gameWarningDatabase, GameWarningService gameWarningService, GUI_RegularPayment guiRegularPayment, TipBoxService tipBoxService, TransferCashMoneyFromCashRegisterService transferCashMoneyFromCashRegisterService)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.gameViewController = gameViewController;
			this.deviceService = deviceService;
			this.workStateMachine = workStateMachine;
			this.tooltipsService = tooltipsService;
			this.workSurface = workSurface;
			this.npcServiceMain = npcServiceMain;
			this.shipmentService = shipmentService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.gameWarningService = gameWarningService;
			this.guiRegularPayment = guiRegularPayment;
			this.tipBoxService = tipBoxService;
			this.transferCashMoneyFromCashRegisterService = transferCashMoneyFromCashRegisterService;
			detectionLayerMask = ProjectConstants.Layers.InteractiveObjectsMask | ProjectConstants.Layers.ClickableObjectsMask | ProjectConstants.Layers.PlacementMask;
		}

		public void Enter()
		{
			SubscribeInputEvents();
		}

		public void Exit()
		{
			tooltipsService.HideAllTooltips();
			UnsubscribeInputEvents();
			ResetSelectedObject();
			cursorSelectionService.ClearDetection();
		}

		public void OnUpdate(float deltaTime)
		{
			cameraDirectionSwitcher.OnUpdate();
			if (!playerInput.GetButton(71) && !playerInput.GetButtonUp(71))
			{
				GameObject hitObject;
				int hitCount;
				if (DoesVisitsStateBlockDetection())
				{
					ResetSelectedObject();
				}
				else if (cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out hitObject))
				{
					ResetSelectedObject();
					cursorSelectionService.SetDetection(hitObject, uiObjectDetected: true);
				}
				else if (cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), detectionLayerMask, raycastHits, out hitCount))
				{
					HandleDetectionResult(hitCount);
				}
				else
				{
					ResetSelectedObject();
					cursorSelectionService.ClearDetection();
				}
			}
		}

		public void Dispose()
		{
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
			playerInput.AddInputEventDelegate(ResolveButtonJustShortPressed, InputActionEventType.ButtonJustShortPressed, 71);
			workSurface.OnClick += ResolveClickOnSurface;
		}

		private void UnsubscribeInputEvents()
		{
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 71);
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustShortPressed, InputActionEventType.ButtonJustShortPressed, 71);
			workSurface.OnClick -= ResolveClickOnSurface;
		}

		private void HandleDetectionResult(int hitCount)
		{
			if (hitCount == 0)
			{
				ResetSelectedObject();
				return;
			}
			RaycastHit raycastHit = default(RaycastHit);
			RaycastHit raycastHit2 = default(RaycastHit);
			RaycastHit placementHit = default(RaycastHit);
			for (int i = 0; i < hitCount; i++)
			{
				int layer = raycastHits[i].transform.gameObject.layer;
				if (layer == ProjectConstants.Layers.ClickableObjects)
				{
					raycastHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.InteractiveObjects)
				{
					if (!raycastHit2.transform || raycastHit2.distance > raycastHits[i].distance)
					{
						raycastHit2 = raycastHits[i];
					}
				}
				else if (layer == ProjectConstants.Layers.Placement)
				{
					placementHit = raycastHits[i];
				}
			}
			if ((bool)raycastHit.transform)
			{
				HandleClickableHit(raycastHit.transform.gameObject);
				return;
			}
			if ((bool)raycastHit2.transform && raycastHit2.transform.TryGetComponent<IInteractionTrigger>(out var component) && component.InteractiveObject.IsInteractable)
			{
				HandleInteractiveHit(component.InteractiveObject);
				return;
			}
			if ((bool)placementHit.transform)
			{
				HandlePlacementHit(placementHit);
				return;
			}
			ResetSelectedObject();
			cursorSelectionService.ClearDetection();
		}

		private void HandleClickableHit(GameObject clickableObject)
		{
			ResetSelectedObject();
			cursorSelectionService.SetDetection(clickableObject);
		}

		private void HandleInteractiveHit(InteractiveObject interactiveObject)
		{
			if (!(selectedObject == interactiveObject))
			{
				ResetSelectedObject();
				SelectDetectedObject(interactiveObject);
			}
		}

		private void HandlePlacementHit(RaycastHit placementHit)
		{
			if (!deviceService.PlacedDeviceContainer || (placementHit.point - deviceService.PlacedDeviceContainer.transform.position).sqrMagnitude > workSurface.MinPlacedDeviceDetectionSqrDistance)
			{
				ResetSelectedObject();
				cursorSelectionService.ClearDetection();
			}
			else if (!selectedObject || selectedObject.State != InteractiveObjectState.Placed)
			{
				if (deviceService.PlacedDeviceContainer.transform.parent.TryGetComponent<DismantledDevicePack>(out var component))
				{
					HandleInteractiveHit(component);
				}
				else
				{
					HandleInteractiveHit(deviceService.PlacedDeviceContainer);
				}
			}
		}

		private void SelectDetectedObject(InteractiveObject detectedObject)
		{
			selectedObject = detectedObject;
			selectedObject.Select();
			cursorSelectionService.SetDetection(detectedObject.gameObject);
			if (selectedObject.TryGetComponent<CashMoneyObject>(out var component))
			{
				tooltipsService.ShowTooltip(component);
				return;
			}
			if (selectedObject.TryGetComponent<DecorObject>(out var component2))
			{
				tooltipsService.ShowTooltip(component2);
				return;
			}
			if (selectedObject.TryGetComponent<RegularPaymentObject>(out var component3) && component3.IsOverdue())
			{
				tooltipsService.ShowOverdueBillTooltip(component3);
				return;
			}
			InteractiveObject interactiveObject = selectedObject;
			if (!(interactiveObject is ShipmentDevicePack deliveryPack))
			{
				if (!(interactiveObject is DecorShipmentPack decorPack))
				{
					if (!(interactiveObject is DevicePack devicePack))
					{
						if (interactiveObject is DeviceContainer deviceContainer)
						{
							tooltipsService.ShowTooltip(deviceContainer);
						}
					}
					else
					{
						tooltipsService.ShowTooltip(devicePack);
					}
				}
				else
				{
					tooltipsService.ShowTooltip(decorPack);
				}
			}
			else
			{
				tooltipsService.ShowTooltip(deliveryPack);
			}
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			if (DoesVisitsStateBlockDetection())
			{
				return;
			}
			IInteractiveObjectContainer component;
			if (!selectedObject || !selectedObject.IsInteractable)
			{
				if (!TryToStartLeverInteraction() && !TryCashRegistry())
				{
					TryTipBox();
				}
			}
			else if (selectedObject.TryGetComponent<IInteractiveObjectContainer>(out component) && !component.IsEmpty)
			{
				HandleObjectContainerInteraction(component);
			}
			else if (!selectedObject.IsActivatable)
			{
				ResolveButtonJustShortPressed(eventData);
			}
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			if ((bool)selectedObject && selectedObject.IsInteractable && selectedObject.IsActivatable && !DoesVisitsStateBlockDetection())
			{
				if (selectedObject is DismantledDevicePack devicePack)
				{
					selectedObject = deviceService.UnpackDevice(devicePack);
				}
				selectedObject.Activate();
			}
		}

		private void ResolveButtonJustShortPressed(InputActionEventData eventData)
		{
			if (!selectedObject || !selectedObject.IsInteractable || DoesVisitsStateBlockDetection())
			{
				return;
			}
			selectedObject.Deselect();
			if (selectedObject.State == InteractiveObjectState.Placed)
			{
				InteractiveObject interactiveObject = selectedObject;
				if (interactiveObject is DeviceContainer || interactiveObject is DismantledDevicePack)
				{
					selectedObject = deviceService.GrabPlacedDeviceContainer();
					goto IL_0087;
				}
			}
			if (selectedObject is IShipmentPack package)
			{
				selectedObject = shipmentService.RetrieveInteractiveObject(package);
			}
			goto IL_0087;
			IL_0087:
			selectedObject.StartDrag();
			workStateMachine.Enter<DraggingWorkState, InteractiveObject>(selectedObject);
		}

		private void ResolveClickOnSurface()
		{
			if (!deviceService.PlacedDeviceContainer)
			{
				gameViewController.ApplyDisassembleViewPreset();
			}
			else
			{
				Debug.LogError("WorkSurface ClickableTrigger is detectable while device on surface");
			}
		}

		private void HandleObjectContainerInteraction(IInteractiveObjectContainer objectContainer)
		{
			InteractiveObject containedObject = objectContainer.GetContainedObject();
			if ((bool)containedObject)
			{
				containedObject.StartDrag();
				workStateMachine.Enter<DraggingWorkState, InteractiveObject>(containedObject);
			}
			else
			{
				Debug.LogError("Failed to get contained object from objectContainer");
				ResetSelectedObject();
			}
		}

		private void ResetSelectedObject()
		{
			if ((bool)selectedObject)
			{
				selectedObject.Deselect();
				selectedObject = null;
				tooltipsService.HideAllTooltips();
			}
		}

		private bool TryCashRegistry()
		{
			if (!cursorSelectionService.DetectedGameObject)
			{
				return false;
			}
			if (!guiRegularPayment.IsVisible)
			{
				return false;
			}
			if (guiRegularPayment.RegularPaymentObject == null)
			{
				return false;
			}
			CashRegister componentInParent = cursorSelectionService.DetectedGameObject.GetComponentInParent<CashRegister>();
			if (!componentInParent)
			{
				return false;
			}
			if (guiRegularPayment.RegularPaymentObject.RegularPaymentInfo == null)
			{
				Debug.LogError("[DetectionWorkState] Attempted to interact with CashRegister while GUI_RegularPayment is open, but RegularPaymentInfo is null.");
				return false;
			}
			if (!transferCashMoneyFromCashRegisterService.TryStartTransfer(guiRegularPayment.RegularPaymentObject.RegularPaymentInfo.Sum, out var cashMoneyObject))
			{
				gameWarningService.ShowWarning(gameWarningDatabase.InsufficientMoneyToPayRegularPaymentWarning);
				return false;
			}
			cashMoneyObject.InteractiveObject.StartDrag();
			workStateMachine.Enter<DraggingWorkState, InteractiveObject>(cashMoneyObject.InteractiveObject);
			componentInParent.ToggleIndicator(isActive: false);
			return true;
		}

		private bool TryTipBox()
		{
			if (!cursorSelectionService.DetectedGameObject)
			{
				return false;
			}
			if (guiRegularPayment.IsVisible)
			{
				return false;
			}
			if (!cursorSelectionService.DetectedGameObject.transform.parent.TryGetComponent<TipBox>(out var _))
			{
				return false;
			}
			if (!tipBoxService.TryStartTransfer(out var cashMoneyObject))
			{
				return false;
			}
			cashMoneyObject.InteractiveObject.StartDrag();
			workStateMachine.Enter<DraggingWorkState, InteractiveObject>(cashMoneyObject.InteractiveObject);
			return true;
		}

		private bool TryToStartLeverInteraction()
		{
			if (!cursorSelectionService.DetectedGameObject)
			{
				return false;
			}
			VerticalLever componentInParent = cursorSelectionService.DetectedGameObject.transform.GetComponentInParent<VerticalLever>();
			if (!componentInParent)
			{
				return false;
			}
			componentInParent.TryToSwitchLeverPosition();
			return true;
		}

		private bool DoesVisitsStateBlockDetection()
		{
			CurrentVisitState currentVisitState = npcServiceMain.CurrentVisitState;
			return currentVisitState == CurrentVisitState.VisitWithInteraction_Starting || currentVisitState == CurrentVisitState.VisitWithNoInteraction_Starting || currentVisitState == CurrentVisitState.VisitWithInteraction_InteractionInProgress;
		}
	}
}
