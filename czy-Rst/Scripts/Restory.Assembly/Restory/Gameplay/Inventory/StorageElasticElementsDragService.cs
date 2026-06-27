using System;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.UserInterface;
using Restory.StorageSystem.StorageElements;
using Restory.UI.Presenters.Inventory.StorageSlotElements;
using Zenject;

namespace Restory.Gameplay.Inventory
{
	public class StorageElasticElementsDragService : IInitializable, IDisposable
	{
		private enum DragState
		{
			Disabled = 0,
			SlotActive = 1,
			ElementActive = 2
		}

		private enum DragMode
		{
			None = 0,
			DragFromInventory = 1,
			DragToInventory = 2
		}

		private readonly IPlayerInput playerInput;

		private readonly ElementService elementService;

		private readonly IInventory inventory;

		private readonly DragElementRegistrator dragElementRegistrator;

		private readonly GUI_ItemDragCanvas itemDragCanvas;

		private readonly ElementPlacementController placementController;

		private readonly DisassembleStateMachine disassembleStateMachine;

		private bool isInventoryOpen;

		private bool isPointerOverInventory;

		private DragState dragState;

		private DragMode dragMode;

		private StorageSlotElement draggedSlot;

		private ElementBase draggedElement;

		private StorageItemElement draggedItem;

		private int draggedSlotIndex;

		public bool IsInventoryOpen
		{
			set
			{
				isInventoryOpen = value;
				if (!isInventoryOpen)
				{
					IsPointerOverInventory = false;
				}
				else if ((bool)dragElementRegistrator.DraggingElement)
				{
					TryStartDragToInventory();
				}
			}
		}

		public bool IsPointerOverInventory
		{
			get
			{
				return isPointerOverInventory;
			}
			set
			{
				isPointerOverInventory = value;
				if (isPointerOverInventory && dragState == DragState.ElementActive)
				{
					SwitchToSlotActiveState();
				}
				else if (!isPointerOverInventory && dragState == DragState.SlotActive)
				{
					SwitchToElementActiveState();
				}
			}
		}

		[Inject]
		public StorageElasticElementsDragService(IPlayerInput playerInput, ElementService elementService, IInventory inventory, DragElementRegistrator dragElementRegistrator, GUI_ItemDragCanvas itemDragCanvas, CursorDetectorService cursorDetectorService, ElementPlacementController placementController, DisassembleStateMachine disassembleStateMachine)
		{
			this.playerInput = playerInput;
			this.elementService = elementService;
			this.inventory = inventory;
			this.dragElementRegistrator = dragElementRegistrator;
			this.itemDragCanvas = itemDragCanvas;
			this.placementController = placementController;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void Initialize()
		{
			dragElementRegistrator.OnElementStartDrag += TryStartDragToInventory;
		}

		public void OnUpdate()
		{
			if (dragState == DragState.SlotActive)
			{
				itemDragCanvas.DragItem(playerInput.GetMousePosition());
			}
		}

		public void Dispose()
		{
			dragElementRegistrator.OnElementStartDrag -= TryStartDragToInventory;
			Clear();
		}

		public void StartDragFromInventory(StorageSlotElement slot)
		{
			if (slot.Item.Item is StorageItemElement storageItemElement && playerInput.GetButton(71))
			{
				dragState = DragState.SlotActive;
				dragMode = DragMode.DragFromInventory;
				InitDraggedFromInventorySlot(slot, storageItemElement);
				InitDraggedFromInventoryElement(storageItemElement);
				SwitchToSlotActiveState();
				if (!isPointerOverInventory)
				{
					SwitchToElementActiveState();
				}
			}
		}

		public void StopDrag()
		{
			SwitchToDisabledState();
		}

		private void TryStartDragToInventory()
		{
			if (!isInventoryOpen || (bool)draggedElement)
			{
				return;
			}
			ElementBase draggingElement = dragElementRegistrator.DraggingElement;
			if ((bool)draggingElement)
			{
				dragState = DragState.ElementActive;
				dragMode = DragMode.DragToInventory;
				InitDraggedToInventoryItem(draggingElement);
				if (isPointerOverInventory)
				{
					SwitchToSlotActiveState();
				}
			}
		}

		private void InitDraggedFromInventorySlot(StorageSlotElement slot, StorageItemElement itemElement)
		{
			slot.Hide();
			draggedSlot = slot;
			draggedSlotIndex = draggedSlot.Item.Index;
			itemDragCanvas.StartDragItem(itemElement);
		}

		private void InitDraggedFromInventoryElement(StorageItemElement storageItemElement)
		{
			draggedElement = elementService.CreateElementOnSurface(storageItemElement.ElementData.Clone());
			draggedElement.gameObject.SetActive(value: false);
			draggedElement.transform.rotation = draggedElement.PlacementPositionHandler.PlacementPositionData.PlacementRotation;
			disassembleStateMachine.Enter<DraggingDisassembleState, ElementBase>(draggedElement);
			draggedElement.Activate();
		}

		private void InitDraggedToInventoryItem(ElementBase element)
		{
			draggedElement = element;
			draggedItem = new StorageItemElement(draggedElement.ConditionHandler.ElementData);
			itemDragCanvas.StartDragItem(draggedItem);
			itemDragCanvas.HideItem();
		}

		private void SwitchToSlotActiveState()
		{
			dragState = DragState.SlotActive;
			draggedElement.gameObject.SetActive(value: false);
			itemDragCanvas.ShowItem(playerInput.GetMousePosition());
		}

		private void SwitchToElementActiveState()
		{
			dragState = DragState.ElementActive;
			itemDragCanvas.HideItem();
			placementController.SetPlacementPosition();
			draggedElement.gameObject.SetActive(value: true);
		}

		private void SwitchToDisabledState()
		{
			if (dragState == DragState.Disabled)
			{
				return;
			}
			switch (dragMode)
			{
			case DragMode.DragFromInventory:
				StopDragFromInventory();
				break;
			case DragMode.DragToInventory:
				StopDragToInventory();
				if (disassembleStateMachine.ActiveState is ElementToInventoryConfirmationDialogueDisassembleState)
				{
					dragState = DragState.Disabled;
					return;
				}
				break;
			}
			itemDragCanvas.StopDrag();
			dragState = DragState.Disabled;
			dragMode = DragMode.None;
			Clear();
		}

		private void StopDragFromInventory()
		{
			switch (dragState)
			{
			case DragState.SlotActive:
				draggedSlot.Show();
				elementService.DestroyElement(draggedElement);
				break;
			case DragState.ElementActive:
				if (draggedSlot.Item == null)
				{
					inventory.StorageElements.ClearItem(draggedSlotIndex);
				}
				else
				{
					inventory.StorageElements.ClearItem(draggedSlot.Item.Index);
				}
				break;
			}
		}

		private void StopDragToInventory()
		{
			if (dragState == DragState.SlotActive)
			{
				if (draggedElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
				{
					SwitchToElementActiveState();
				}
				else
				{
					TransferDraggedItemToInventory();
				}
			}
		}

		private void TransferDraggedItemToInventory()
		{
			elementService.DestroyElement(draggedElement);
			inventory.StorageElements.AddItem(draggedItem);
		}

		public void FinalizeTransferToInventory()
		{
			TransferDraggedItemToInventory();
			itemDragCanvas.StopDrag();
			dragState = DragState.Disabled;
			dragMode = DragMode.None;
			Clear();
		}

		private void CancelTransferToInventory()
		{
			itemDragCanvas.StopDrag();
			draggedElement.gameObject.SetActive(value: true);
			draggedElement.BehaviorSwitcher.SwitchToPlacedBehavior();
			dragState = DragState.Disabled;
			dragMode = DragMode.None;
			Clear();
		}

		private void Clear()
		{
			draggedSlot = null;
			draggedElement = null;
			draggedItem = null;
			draggedSlotIndex = 0;
		}
	}
}
