using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Recycle;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Shipment;
using Restory.Gameplay.Shredders;
using UnityEngine;

namespace Restory.Gameplay.Work.Dragging
{
	public class DragResolver
	{
		private readonly InteractiveObjectService interactiveObjectService;

		private readonly DeviceService deviceService;

		private readonly DevicePacker devicePacker;

		private readonly RecycleService recycleService;

		private readonly ShredderService shredderService;

		private readonly EquipmentService equipmentService;

		private readonly ShipmentService shipmentService;

		private readonly LicensesService licensesService;

		private readonly InteractiveObjectsToObjectConsumersDragHandlingService dragToObjectConsumersHandler;

		private readonly DragObjectInitialDataHolder initialDataHolder;

		private readonly DragHandler dragHandler;

		private readonly GameWarningDatabase gameWarningDatabase;

		private readonly GameWarningService gameWarningService;

		private readonly CashMoneyObjectFactory cashMoneyFactory;

		private readonly CashMoneyObjectRegistry cashMoneyRegistry;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly TransferCashMoneyFromCashRegisterService transferCashMoneyFromCashRegisterService;

		private readonly DeviceReplacementHandler deviceReplacementHandler;

		private InteractiveObject selectedObject;

		public DragResolver(InteractiveObjectService interactiveObjectService, DeviceService deviceService, DevicePacker devicePacker, RecycleService recycleService, ShredderService shredderService, EquipmentService equipmentService, ShipmentService shipmentService, LicensesService licensesService, InteractiveObjectsToObjectConsumersDragHandlingService dragToObjectConsumersHandler, DragObjectInitialDataHolder initialDataHolder, DragHandler dragHandler, GameWarningDatabase gameWarningDatabase, GameWarningService gameWarningService, CashMoneyObjectFactory cashMoneyFactory, CashMoneyObjectRegistry cashMoneyRegistry, InteractiveObjectRegistry interactiveObjectRegistry, TransferCashMoneyFromCashRegisterService transferCashMoneyFromCashRegisterService, DeviceReplacementHandler deviceReplacementHandler)
		{
			this.dragToObjectConsumersHandler = dragToObjectConsumersHandler;
			this.interactiveObjectService = interactiveObjectService;
			this.deviceService = deviceService;
			this.devicePacker = devicePacker;
			this.recycleService = recycleService;
			this.shredderService = shredderService;
			this.equipmentService = equipmentService;
			this.shipmentService = shipmentService;
			this.licensesService = licensesService;
			this.initialDataHolder = initialDataHolder;
			this.dragHandler = dragHandler;
			this.gameWarningDatabase = gameWarningDatabase;
			this.gameWarningService = gameWarningService;
			this.cashMoneyFactory = cashMoneyFactory;
			this.cashMoneyRegistry = cashMoneyRegistry;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.transferCashMoneyFromCashRegisterService = transferCashMoneyFromCashRegisterService;
			this.deviceReplacementHandler = deviceReplacementHandler;
		}

		public void Init(InteractiveObject selectedObject)
		{
			this.selectedObject = selectedObject;
		}

		public void Cleanup()
		{
			selectedObject = null;
		}

		public void ResolveDragResult()
		{
			if ((bool)dragHandler.GuiRegularPayment)
			{
				ResolveDragToGuiRegularPayment();
			}
			else if (dragHandler.IsOverShipment && shipmentService.TryToShipInteractiveObject(selectedObject))
			{
				CompleteDrag();
				selectedObject.CompleteDrag();
			}
			else if (recycleService.TryToRecycleInteractiveObject(selectedObject) || shredderService.TryToShredInteractiveObject(selectedObject) || equipmentService.TryToApplyInteractiveObject(selectedObject) || dragToObjectConsumersHandler.TryToDropDraggedObjectIntoInventory(selectedObject) || dragToObjectConsumersHandler.TryToDropDraggedObjectIntoPaintingTool(selectedObject))
			{
				CompleteDrag();
				selectedObject.CompleteDrag();
			}
			else if ((bool)dragHandler.ParentStorage)
			{
				ResolveDragToStorage();
			}
			else if (dragHandler.IsOverSurface)
			{
				ResolveDragToSurface();
			}
			else
			{
				CancelDrag();
			}
		}

		private void ResolveDragToStorage()
		{
			if (selectedObject.DragState != InteractiveObjectDragState.Storable)
			{
				CancelDrag();
			}
			else
			{
				CompleteDragToStorage();
			}
		}

		private void ResolveDragToSurface()
		{
			if (!selectedObject.IsPlaceable)
			{
				if (selectedObject.TryGetComponent<RegularPaymentObject>(out var _))
				{
					gameWarningService.ShowWarning(gameWarningDatabase.NotBestPlaceForPapersWarning);
				}
				CancelDrag();
				return;
			}
			if (selectedObject is DeviceContainer deviceContainer)
			{
				if (!licensesService.IsLicensed(deviceContainer.Device.Info))
				{
					gameWarningService.ShowWarning(gameWarningDatabase.LicenseRequired, deviceContainer.Device.Info);
					CancelDrag();
					return;
				}
				if ((bool)deviceContainer.Package)
				{
					devicePacker.UnpackDeviceContainer(deviceContainer);
				}
			}
			if ((bool)deviceService.PlacedDeviceContainer)
			{
				if (deviceReplacementHandler.TryToReplaceDevice())
				{
					CompleteDragToSurface();
				}
				else
				{
					CancelDrag();
				}
			}
			else if (!equipmentService.IsReadyToDisassemble || interactiveObjectService.AnyObjectOnSurface)
			{
				if (selectedObject.TryGetComponent<DeviceContainer>(out var _))
				{
					gameWarningService.ShowWarning(gameWarningDatabase.CleanUpTheTableWarning);
				}
				CancelDrag();
			}
			else
			{
				CompleteDragToSurface();
			}
		}

		private void ResolveDragToGuiRegularPayment()
		{
			if (!selectedObject.TryGetComponent<CashMoneyObject>(out var component))
			{
				CancelDrag();
				return;
			}
			selectedObject.gameObject.SetActive(value: true);
			if (!transferCashMoneyFromCashRegisterService.IsTakingMoney || transferCashMoneyFromCashRegisterService.TakenCashMoneyObject != component)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.CanNotPayRegularPaymentOutsideCashRegisterWarning);
				dragHandler.GuiRegularPayment.HideMoney();
				CancelDrag();
			}
			else if (!dragHandler.GuiRegularPayment.PayRegularPayment(component))
			{
				dragHandler.GuiRegularPayment.HideMoney();
				CancelDrag();
			}
			else
			{
				CompleteDrag();
				selectedObject.CompleteDrag();
				cashMoneyRegistry.Unregister(component);
				interactiveObjectRegistry.Unregister(selectedObject);
				cashMoneyFactory.Destroy(component);
			}
		}

		private void CompleteDragToStorage()
		{
			CompleteDrag();
			selectedObject.SetState(InteractiveObjectState.Stored);
			selectedObject.transform.parent = dragHandler.ParentStorage;
			selectedObject.CompleteDrag();
		}

		private void CompleteDragToSurface()
		{
			CompleteDrag();
			selectedObject.transform.rotation = dragHandler.SelectedObjectTargetRotation;
			PlaceSelectedObject();
			selectedObject.CompleteDrag();
		}

		private void CompleteDrag()
		{
			if (initialDataHolder.State == InteractiveObjectState.Delivery && (bool)initialDataHolder.DevicesStorage)
			{
				initialDataHolder.DevicesStorage.RemoveDeviceFromStorage(selectedObject);
			}
		}

		private void CancelDrag()
		{
			selectedObject.transform.position = initialDataHolder.Position;
			selectedObject.transform.rotation = initialDataHolder.Rotation;
			selectedObject.CancelDrag();
			switch (selectedObject.State)
			{
			case InteractiveObjectState.Placed:
				PlaceSelectedObject();
				break;
			case InteractiveObjectState.Stored:
				if (selectedObject is DeviceContainer deviceContainer2)
				{
					deviceContainer2.SetStoragePoint();
				}
				break;
			case InteractiveObjectState.Delivery:
				if (selectedObject is DeviceContainer deviceContainer)
				{
					deviceContainer.SetStoragePoint();
				}
				break;
			case InteractiveObjectState.Shipment:
				ReshipSelectedObject();
				break;
			}
		}

		private void PlaceSelectedObject()
		{
			InteractiveObject interactiveObject = selectedObject;
			if (!(interactiveObject is DeviceContainer deviceContainer))
			{
				if (interactiveObject is DevicePack devicePack)
				{
					deviceService.PlaceDeviceContainer(devicePack);
				}
			}
			else
			{
				deviceContainer.SetPlacementPoint();
				deviceService.PlaceDeviceContainer(deviceContainer);
			}
		}

		private void ReshipSelectedObject()
		{
			selectedObject.DragState = InteractiveObjectDragState.Shippable;
			if (!shipmentService.TryToShipInteractiveObject(selectedObject))
			{
				Debug.LogError("Failed to return retrieved selectedObject back to shipmentService");
			}
		}
	}
}
