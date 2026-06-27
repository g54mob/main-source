using Restory.Data.Equipment;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.InventoryNotification;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.StorageSystem.StorageElements;

namespace Restory.Gameplay.Inventory
{
	public class InteractiveObjectsToObjectConsumersDragHandlingService
	{
		private readonly IInventory inventory;

		private readonly InventoryBoxDetector inventoryDetector;

		private readonly InventoryBox inventoryBox;

		private readonly PaintingToolWorkplaceItem paintingToolWorkplaceItem;

		private readonly PaintingToolWorkplaceItemDetector paintingToolWorkplaceItemDetector;

		private readonly AvailablePaintingPalettesTrackingService availablePaintingPalettesTracker;

		private readonly InventoryNotificationService inventoryNotificationService;

		public InteractiveObjectsToObjectConsumersDragHandlingService(IInventory inventory, InventoryBoxDetector inventoryDetector, InventoryBox inventoryBox, PaintingToolWorkplaceItem paintingToolWorkplaceItem, PaintingToolWorkplaceItemDetector paintingToolWorkplaceItemDetector, AvailablePaintingPalettesTrackingService availablePaintingPalettesTracker, InventoryNotificationService inventoryNotificationService)
		{
			this.inventory = inventory;
			this.inventoryDetector = inventoryDetector;
			this.inventoryBox = inventoryBox;
			this.paintingToolWorkplaceItem = paintingToolWorkplaceItem;
			this.paintingToolWorkplaceItemDetector = paintingToolWorkplaceItemDetector;
			this.availablePaintingPalettesTracker = availablePaintingPalettesTracker;
			this.inventoryNotificationService = inventoryNotificationService;
		}

		public bool TryToDropDraggedObjectIntoInventory(InteractiveObject interactiveObject)
		{
			InventoryBoxDetector inventoryBoxDetector = inventoryDetector;
			if (inventoryBoxDetector == null || !inventoryBoxDetector.IsDetected)
			{
				return false;
			}
			if (interactiveObject.TryGetComponent<ElementsContainer>(out var component))
			{
				foreach (HeldElement heldElement in component.HeldElements)
				{
					inventory.StorageElements.AddItem(new StorageItemElement(heldElement.ElementData), heldElement.HeldAmount);
				}
				inventoryNotificationService.ShowElements(component.HeldElements);
				inventoryBox.HandleItemAdded();
				return true;
			}
			if (interactiveObject.TryGetComponent<ElementsBox>(out var component2))
			{
				HeldElements heldElements = new HeldElements();
				foreach (ElementData element in component2.Elements)
				{
					heldElements.AddElement(element);
					inventory.StorageElements.AddItem(new StorageItemElement(element));
				}
				inventoryNotificationService.ShowElements(heldElements.AllHeldElements);
				inventoryBox.HandleItemAdded();
				return true;
			}
			return false;
		}

		public bool TryToDropDraggedObjectIntoPaintingTool(InteractiveObject interactiveObject)
		{
			PaintingToolWorkplaceItemDetector paintingToolWorkplaceItemDetector = this.paintingToolWorkplaceItemDetector;
			if (paintingToolWorkplaceItemDetector == null || !paintingToolWorkplaceItemDetector.IsDetected || !interactiveObject.TryGetComponent<PaintingPalettesContainer>(out var component))
			{
				return false;
			}
			foreach (PaintingPaletteInfo containedPalette in component.ContainedPalettes)
			{
				availablePaintingPalettesTracker.AddPalette(containedPalette);
			}
			paintingToolWorkplaceItem.HandlePalettesAdded();
			return true;
		}
	}
}
