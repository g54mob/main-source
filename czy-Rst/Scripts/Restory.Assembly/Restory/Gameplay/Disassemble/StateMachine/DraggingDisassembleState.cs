using System;
using Restory.Constants;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.Ultrasonic;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.GameView;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.Recycle;
using Restory.Gameplay.Shredders;
using Restory.Gameplay.UserInterface;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Rewired;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class DraggingDisassembleState : IPayloadedState<ElementBase>, IExitableState, IDisposable, IUpdatableState, IRecycleRequester, IShredRequester
	{
		public class Factory : PlaceholderFactory<DraggingDisassembleState>
		{
		}

		private readonly RaycastHit[] raycastHits = new RaycastHit[8];

		private readonly IPlayerInput playerInput;

		private readonly CursorDetectorService cursorDetectorService;

		private readonly CursorSelectionService cursorSelectionService;

		private readonly CameraDirectionSwitcher cameraDirectionSwitcher;

		private readonly DisassembleRotationController rotationController;

		private readonly ElementPlacementController elementPlacementController;

		private readonly ElementAssembleController elementAssembleController;

		private readonly ElementService elementService;

		private readonly ElementCleaner elementCleaner;

		private readonly GUI_ElementCleanerPanel cleanerPanel;

		private readonly UltrasonicService ultrasonicService;

		private readonly RecycleService recycleService;

		private readonly ShredderService shredderService;

		private readonly DeviceService deviceService;

		private readonly DisassembleGameMode disassembleGameMode;

		private readonly StorageElasticElementsDragService storageElasticElementsDragService;

		private readonly DragElementRegistrator dragElementRegistrator;

		private readonly GameWarningService gameWarningService;

		private readonly GameWarningDatabase gameWarningDatabase;

		private readonly DisassembleStateMachine stateMachine;

		private readonly LayerMask draggingLayerMask;

		private ElementBase selectedElement;

		private bool isOverCleaner;

		private bool isOverInventory;

		private bool isOverSonicBath;

		private bool isOverDevice;

		private bool isRecycling;

		private bool isShredding;

		[Inject]
		public DraggingDisassembleState(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, CursorSelectionService cursorSelectionService, CameraDirectionSwitcher cameraDirectionSwitcher, DisassembleRotationController rotationController, ElementPlacementController elementPlacementController, ElementAssembleController elementAssembleController, ElementService elementService, ElementCleaner elementCleaner, GUI_ElementCleanerPanel cleanerPanel, UltrasonicService ultrasonicService, RecycleService recycleService, ShredderService shredderService, DeviceService deviceService, DisassembleGameMode disassembleGameMode, StorageElasticElementsDragService storageElasticElementsDragService, DragElementRegistrator dragElementRegistrator, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase, DisassembleStateMachine stateMachine)
		{
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.cursorSelectionService = cursorSelectionService;
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
			this.rotationController = rotationController;
			this.elementPlacementController = elementPlacementController;
			this.elementAssembleController = elementAssembleController;
			this.elementService = elementService;
			this.elementCleaner = elementCleaner;
			this.cleanerPanel = cleanerPanel;
			this.ultrasonicService = ultrasonicService;
			this.recycleService = recycleService;
			this.shredderService = shredderService;
			this.deviceService = deviceService;
			this.disassembleGameMode = disassembleGameMode;
			this.storageElasticElementsDragService = storageElasticElementsDragService;
			this.dragElementRegistrator = dragElementRegistrator;
			this.gameWarningService = gameWarningService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.stateMachine = stateMachine;
			draggingLayerMask = ProjectConstants.Layers.DeviceMask | ProjectConstants.Layers.PlacementMask | ProjectConstants.Layers.AssembleMask | ProjectConstants.Layers.EquipmentMask | ProjectConstants.Layers.TransferMask;
		}

		public void Enter(ElementBase selectedElement)
		{
			SubscribeInputEvents();
			elementCleaner.UpdateDraggingElementInitialCleaningData(selectedElement);
			dragElementRegistrator.RegisterDraggingElement(selectedElement);
			elementPlacementController.SetTargetElement(selectedElement);
			if (!playerInput.GetButton(71))
			{
				storageElasticElementsDragService.StopDrag();
				if (!elementPlacementController.TrySetPlacementPositionAndDropToSurface())
				{
					if (selectedElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
					{
						elementService.DestroyElement(selectedElement);
						return;
					}
					elementService.TrySendItemToStorage(selectedElement);
				}
				stateMachine.Enter<DetectionDisassembleState>();
				return;
			}
			if (!deviceService.PlacedDeviceContainer && !disassembleGameMode.TryCreateEmptyDevice(selectedElement.Info.SourceDevice.NameLocalizationKey))
			{
				storageElasticElementsDragService.StopDrag();
				elementService.TrySendItemToStorage(selectedElement);
				stateMachine.Enter<EmptyDisassembleState>();
				return;
			}
			elementAssembleController.StartDrag(selectedElement);
			this.selectedElement = selectedElement;
			this.selectedElement.IsDragging = true;
			this.selectedElement.ConditionHandler.ElementData.IsInspected = true;
			isRecycling = false;
			isShredding = false;
			cursorSelectionService.SetDetection(selectedElement.gameObject);
			if (elementCleaner.DraggingElementInitialCleaningData != null && deviceService.PlacedDeviceContainer.Device.Info == selectedElement.Info.SourceDevice as DeviceInfo)
			{
				elementCleaner.ToggleIndicator(isActive: true);
			}
		}

		public void OnUpdate(float deltaTime)
		{
			if (isRecycling || isShredding)
			{
				return;
			}
			cameraDirectionSwitcher.OnUpdate();
			storageElasticElementsDragService.OnUpdate();
			if ((bool)selectedElement && selectedElement.isActiveAndEnabled && selectedElement.IsDragging)
			{
				isOverCleaner = false;
				isOverInventory = false;
				isOverSonicBath = false;
				isOverDevice = false;
				if (cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), draggingLayerMask, raycastHits, out var hitCount))
				{
					HandleDetectionResult(hitCount);
				}
				bool flag = selectedElement.ConditionHandler.ElementData.Condition is DamagedElementCondition;
				bool flag2 = isOverCleaner || (isOverInventory && !flag);
				elementAssembleController.OnDrag(deltaTime, isOverDevice, flag2);
				selectedElement.IsOverCompatibleEquipment = flag2;
				if (!isOverSonicBath)
				{
					ultrasonicService.ResetElement();
				}
				rotationController.OnUpdate();
			}
		}

		public void Exit()
		{
			UnsubscribeInputEvents();
			dragElementRegistrator.UnregisterDraggingElement();
			ResetElement();
			elementCleaner.ToggleIndicator(isActive: false);
			cursorSelectionService.ClearDetection();
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

		private void HandleDetectionResult(int hitCount)
		{
			RaycastHit assembleHit = default(RaycastHit);
			RaycastHit equipmentHit = default(RaycastHit);
			RaycastHit raycastHit = default(RaycastHit);
			bool flag = false;
			for (int i = 0; i < hitCount; i++)
			{
				int layer = raycastHits[i].transform.gameObject.layer;
				if (layer == ProjectConstants.Layers.Assemble)
				{
					assembleHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.Equipment)
				{
					equipmentHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.Transfer)
				{
					raycastHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.Placement)
				{
					elementPlacementController.LastPlacementHit = raycastHits[i];
				}
				else if (layer == ProjectConstants.Layers.Device)
				{
					flag = true;
				}
			}
			RaycastHit collisionHit;
			if (flag)
			{
				HandleAssembleHit(assembleHit);
			}
			else if (!elementPlacementController.IsLastPlacementHitPositionAvailable(out collisionHit) && (bool)collisionHit.transform && !CheckDeviceCollision(assembleHit, collisionHit) && (!CheckEquipmentCollision(equipmentHit) || !isOverSonicBath || !ultrasonicService.TryFitElementToSonicBath(selectedElement, equipmentHit.point)) && (bool)raycastHit.transform)
			{
				selectedElement.transform.position = raycastHit.point;
			}
		}

		private void HandleAssembleHit(RaycastHit assembleHit)
		{
			if ((bool)assembleHit.transform)
			{
				elementAssembleController.AssemblePosition = assembleHit.point;
				isOverDevice = true;
			}
		}

		private bool CheckEquipmentCollision(RaycastHit equipmentHit)
		{
			if ((bool)equipmentHit.transform && (equipmentHit.transform.TryGetComponent<IElementInteractionEquipment>(out var component) || equipmentHit.transform.parent.TryGetComponent<IElementInteractionEquipment>(out component)))
			{
				if (!(component is ElementCleaner))
				{
					if (!(component is InventoryBox))
					{
						if (component is SonicBath)
						{
							isOverSonicBath = true;
						}
					}
					else
					{
						isOverInventory = true;
					}
				}
				else
				{
					isOverCleaner = true;
				}
				return true;
			}
			return false;
		}

		private bool CheckDeviceCollision(RaycastHit assembleHit, RaycastHit collisionHit)
		{
			if (!assembleHit.transform)
			{
				return false;
			}
			int layer = collisionHit.transform.gameObject.layer;
			if (layer != ProjectConstants.Layers.Device && layer != ProjectConstants.Layers.DeviceContainer)
			{
				return false;
			}
			HandleAssembleHit(assembleHit);
			return true;
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			storageElasticElementsDragService.StopDrag();
			if (isRecycling || isShredding || stateMachine.ActiveState is ElementToInventoryConfirmationDialogueDisassembleState)
			{
				return;
			}
			if (!selectedElement || !selectedElement.isActiveAndEnabled || TrySendElementToInventory() || TrySendElementToSonicBath())
			{
				if (deviceService.IsPlacedDeviceCompletelyDisassembled())
				{
					deviceService.DestroyDeviceContainer();
					stateMachine.Enter<EmptyDisassembleState>();
				}
				else
				{
					stateMachine.Enter<DetectionDisassembleState>();
				}
			}
			else if (IsIncompatibleElement())
			{
				HandleIncompatibleElement();
			}
			else if (!TrySendElementToCleaner())
			{
				if (recycleService.IsReadyToRecycle)
				{
					isRecycling = true;
					ElementRecycleRequest request = new ElementRecycleRequest(this, selectedElement);
					recycleService.SendRecycleRequest(request);
				}
				else if (shredderService.IsReadyToShred)
				{
					isShredding = true;
					ShredElementRequest request2 = new ShredElementRequest(this, selectedElement);
					shredderService.SendShredRequest(request2);
				}
				else
				{
					CompleteDrag();
				}
			}
		}

		private bool TrySendElementToInventory()
		{
			if (storageElasticElementsDragService.IsPointerOverInventory && selectedElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.BrokenElementWarning);
				return false;
			}
			if (isOverInventory)
			{
				return elementService.TrySendItemToStorage(selectedElement);
			}
			return false;
		}

		private bool TrySendElementToSonicBath()
		{
			if (!isOverSonicBath)
			{
				return false;
			}
			return ultrasonicService.TryInsertElementToSonicBath(selectedElement);
		}

		private bool IsIncompatibleElement()
		{
			if (deviceService.PlacedDeviceContainer.Device.Info == selectedElement.Info.SourceDevice as DeviceInfo)
			{
				return false;
			}
			if (selectedElement.Info is QuestItemInfo)
			{
				return false;
			}
			return true;
		}

		private void HandleIncompatibleElement()
		{
			if (ultrasonicService.TryReturnElementToSonicBath(selectedElement))
			{
				gameWarningService.ShowWarning(gameWarningDatabase.PartIsNotCompatibleWithDevice);
			}
			else
			{
				Debug.LogError("Element " + selectedElement.Info.ID + " not compatible with placed device, and will be stored in inventory");
				elementService.TrySendItemToStorage(selectedElement);
			}
			stateMachine.Enter<DetectionDisassembleState>();
		}

		private bool TrySendElementToCleaner()
		{
			if (!isOverCleaner)
			{
				return false;
			}
			if (elementCleaner.DraggingElementInitialCleaningData == null)
			{
				return false;
			}
			cleanerPanel.Init(selectedElement, elementCleaner.DraggingElementInitialCleaningData);
			cleanerPanel.Show();
			selectedElement.IsDragging = false;
			stateMachine.Enter<TransitionToCleaningDisassembleState, ElementBase>(selectedElement);
			ResetElement();
			return true;
		}

		private void CompleteDrag()
		{
			if ((bool)elementAssembleController.SelectedSocket)
			{
				elementAssembleController.SelectedSocket.AttachElement(selectedElement);
				if (deviceService.PlacedDeviceContainer.Device.CheckIntegrityAndIsInstalling())
				{
					stateMachine.Enter<CheckDeviceDisassembleState>();
					return;
				}
				ElementConditionBase condition = selectedElement.ConditionHandler.ElementData.Condition;
				if (!(condition is DamagedElementCondition))
				{
					if (condition is DirtyElementCondition)
					{
						if (selectedElement.ConditionHandler.ElementData.JustSolderingNeeded())
						{
							gameWarningService.ShowWarning(gameWarningDatabase.SolderingNeeded);
						}
						else
						{
							gameWarningService.ShowWarning(gameWarningDatabase.DirtyPartInstalled);
						}
					}
				}
				else
				{
					gameWarningService.ShowWarning(gameWarningDatabase.DamagedPartInstalled);
				}
			}
			stateMachine.Enter<DetectionDisassembleState>();
		}

		public void OnRecycleResponse(bool isCompleted)
		{
			ResolveDisposeResponse(isCompleted);
		}

		public void OnShredResponse(bool isCompleted)
		{
			ResolveDisposeResponse(isCompleted);
		}

		private void ResolveDisposeResponse(bool isCompleted)
		{
			if (!isCompleted)
			{
				CompleteDrag();
			}
			else if (deviceService.IsPlacedDeviceCompletelyDisassembled())
			{
				deviceService.DestroyDeviceContainer();
				stateMachine.Enter<EmptyDisassembleState>();
			}
			else
			{
				stateMachine.Enter<DetectionDisassembleState>();
			}
		}

		private void ResetElement()
		{
			if (!selectedElement)
			{
				return;
			}
			if (selectedElement.IsDragging && selectedElement.isActiveAndEnabled && !elementPlacementController.TrySetPlacementPositionAndDropToSurface())
			{
				if (selectedElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
				{
					elementService.DestroyElement(selectedElement);
					return;
				}
				elementService.TrySendItemToStorage(selectedElement);
			}
			elementPlacementController.Clear();
			elementAssembleController.Clear();
			selectedElement.IsDragging = false;
			selectedElement.IsOverCompatibleEquipment = false;
			selectedElement = null;
		}
	}
}
