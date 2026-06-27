using System;
using Restory.Constants;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.GameView;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Recycle;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Shredders;
using Restory.Gameplay.Tooltips;
using Restory.Gameplay.Work.Dragging;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public class DraggingWorkState : IPayloadedState<InteractiveObject>, IExitableState, IDisposable, IUpdatableState
	{
		public class Factory : PlaceholderFactory<DraggingWorkState>
		{
		}

		private readonly RaycastHit[] raycastHits = new RaycastHit[4];

		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly WorkStateMachine stateMachine;

		private readonly DragObjectInitialDataHolder initialDataHolder;

		private readonly DragHandler dragHandler;

		private readonly DragResolver dragResolver;

		private readonly LayerMask draggingLayerMask;

		private InteractiveObject selectedObject;

		[Inject]
		public DraggingWorkState(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CameraDirectionSwitcher cameraDirectionSwitcher, InteractiveObjectService interactiveObjectService, DeviceService deviceService, DevicePacker devicePacker, RecycleService recycleService, ShredderService shredderService, EquipmentService equipmentService, InteractiveObjectsTooltipsService interactiveObjectsTooltipsService, ShipmentService shipmentService, LicensesService licensesService, ShipmentPackFactory shipmentPackFactory, InteractiveObjectsToObjectConsumersDragHandlingService dragToObjectConsumersHandler, DragObjectRegistrator dragObjectRegistrator, WorkStateMachine stateMachine, CashMoneyObjectFactory cashMoneyFactory, CashMoneyObjectRegistry cashMoneyRegistry, InteractiveObjectRegistry interactiveObjectRegistry, GameWarningDatabase gameWarningDatabase, GameWarningService gameWarningService, TransferCashMoneyFromCashRegisterService transferCashMoneyFromCashRegisterService, DeviceReplacementHandler deviceReplacementHandler)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.stateMachine = stateMachine;
			initialDataHolder = new DragObjectInitialDataHolder();
			dragHandler = new DragHandler(interactiveObjectsTooltipsService, shipmentService, shipmentPackFactory, raycastHits, initialDataHolder);
			dragResolver = new DragResolver(interactiveObjectService, deviceService, devicePacker, recycleService, shredderService, equipmentService, shipmentService, licensesService, dragToObjectConsumersHandler, initialDataHolder, dragHandler, gameWarningDatabase, gameWarningService, cashMoneyFactory, cashMoneyRegistry, interactiveObjectRegistry, transferCashMoneyFromCashRegisterService, deviceReplacementHandler);
			draggingLayerMask = ProjectConstants.Layers.TransferMask | ProjectConstants.Layers.StorageMask | ProjectConstants.Layers.PlacementMask | ProjectConstants.Layers.ShipmentMask | ProjectConstants.Layers.StorageBlockersMask;
		}

		public void Enter(InteractiveObject selectedObject)
		{
			SubscribeInputEvents();
			dragObjectRegistrator.RegisterDraggingObject(selectedObject);
			if (!playerInput.GetButton(71))
			{
				selectedObject.CancelDrag();
				stateMachine.Enter<DetectionWorkState>();
				return;
			}
			this.selectedObject = selectedObject;
			selectedObject.IsInteractable = false;
			if (selectedObject.State == InteractiveObjectState.Delivery && selectedObject is DeviceContainer deviceContainer)
			{
				deviceContainer.SetPlacementPoint();
			}
			initialDataHolder.Init(selectedObject);
			dragHandler.Init(selectedObject);
			dragResolver.Init(selectedObject);
		}

		public void OnUpdate(float deltaTime)
		{
			cameraDirectionSwitcher.OnUpdate();
			if ((bool)selectedObject)
			{
				if (cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), draggingLayerMask, raycastHits, out var hitCount))
				{
					dragHandler.HandleDetectionResult(hitCount);
					dragHandler.HandleObjectRotation(deltaTime);
				}
				cursorDetectorService.UIDetector.TryToDetect(playerInput.GetMousePosition(), out var hitObject);
				dragHandler.HandleUIDetectionResult(hitObject);
			}
		}

		public void Exit()
		{
			UnsubscribeInputEvents();
			dragObjectRegistrator.UnregisterDraggingObject();
			ResetSelectedObject();
		}

		public void Dispose()
		{
		}

		private void SubscribeInputEvents()
		{
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void UnsubscribeInputEvents()
		{
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 71);
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			if (!selectedObject)
			{
				Debug.LogError("InteractiveObject was lost");
			}
			else
			{
				dragResolver.ResolveDragResult();
			}
			stateMachine.Enter<DetectionWorkState>();
		}

		private void ResetSelectedObject()
		{
			if ((bool)selectedObject)
			{
				selectedObject.IsInteractable = true;
				selectedObject = null;
				initialDataHolder.Cleanup();
				dragHandler.Cleanup();
				dragResolver.Cleanup();
			}
		}
	}
}
