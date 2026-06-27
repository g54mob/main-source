using System;
using System.Collections.Generic;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Devices;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Tooltips;
using Restory.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public class ShipmentService : IInitializable, IDisposable
	{
		private readonly ShipmentTrigger shipmentTrigger;

		private readonly PackageStacker packageStacker;

		private readonly DeviceService deviceService;

		private readonly DevicePacker devicePacker;

		private readonly DecorPacker decorPacker;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly InteractiveObjectsTooltipsService interactiveObjectsTooltipsService;

		private readonly GameWarningDatabase gameWarningDatabase;

		private readonly GameWarningService gameWarningService;

		private readonly MainDayTimeSwitchingService mainDayTimeSwitchingService;

		public IReadOnlyCollection<IShipmentPack> ShipmentStorageContent => packageStacker.Packages;

		public event Action OnShipmentStorageContentChanged;

		[Inject]
		public ShipmentService(ShipmentTrigger shipmentTrigger, PackageStacker packageStacker, DeviceService deviceService, DevicePacker devicePacker, DecorPacker decorPacker, DragObjectRegistrator dragObjectRegistrator, InteractiveObjectsTooltipsService interactiveObjectsTooltipsService, GameWarningDatabase gameWarningDatabase, GameWarningService gameWarningService, MainDayTimeSwitchingService mainDayTimeSwitchingService)
		{
			this.shipmentTrigger = shipmentTrigger;
			this.packageStacker = packageStacker;
			this.deviceService = deviceService;
			this.devicePacker = devicePacker;
			this.decorPacker = decorPacker;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.interactiveObjectsTooltipsService = interactiveObjectsTooltipsService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.gameWarningService = gameWarningService;
			this.mainDayTimeSwitchingService = mainDayTimeSwitchingService;
		}

		public void Initialize()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			shipmentTrigger.IsActive = false;
		}

		public void Dispose()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
		}

		public bool IsInteractiveObjectCanBeShipped(InteractiveObject interactiveObject)
		{
			if (interactiveObject is DeviceContainer deviceContainer)
			{
				return IsDeviceCanBeShipped(deviceContainer);
			}
			if (interactiveObject is CompetitionDevicePack competitionDevicePack)
			{
				ShowTooltipForCompetitionDevice(competitionDevicePack);
				return false;
			}
			if (interactiveObject is DismantledDevicePack disassembledDevicePack)
			{
				ShowTooltipForDismantledDevice(disassembledDevicePack);
				return false;
			}
			if (interactiveObject.TryGetComponent<DecorObject>(out var component))
			{
				return IsDecorCanBeShipped(component);
			}
			return false;
		}

		public bool TryToShipInteractiveObject(InteractiveObject interactiveObject)
		{
			if (!packageStacker.HasAvailablePlace(out var availablePoint))
			{
				return false;
			}
			if (interactiveObject is DeviceContainer deviceContainer)
			{
				return TryToShipDevice(deviceContainer, availablePoint);
			}
			if (interactiveObject is DismantledDevicePack disassembledDevicePack)
			{
				ShowWarningForDismantledDevice(disassembledDevicePack);
				return false;
			}
			if (interactiveObject.DragState != InteractiveObjectDragState.Shippable)
			{
				return false;
			}
			if (interactiveObject.TryGetComponent<DecorObject>(out var component))
			{
				return TryToShipDecor(component, availablePoint);
			}
			Debug.LogError($"Not available object {interactiveObject.gameObject.name} has {InteractiveObjectDragState.Shippable} state");
			return false;
		}

		public void RestoreDevicePackInShipmentStorage(DeviceContainer deviceContainer)
		{
			if (!packageStacker.HasAvailablePlace(out var availablePoint))
			{
				Debug.LogError("packageStacker has no available place to restore");
				return;
			}
			ShipmentDevicePack shipmentDevicePack = devicePacker.PackStoredDeviceContainerForDelivery(deviceContainer);
			availablePoint.SetPackage(shipmentDevicePack);
			shipmentDevicePack.SetState(InteractiveObjectState.Shipment);
		}

		public bool TryRestoreDecorPackInShipmentStorage(DecorObject decorObject, out DecorShipmentPack decorPack)
		{
			decorPack = null;
			if (!packageStacker.HasAvailablePlace(out var availablePoint))
			{
				Debug.LogError("Failed to restore " + decorObject.Info.ID + " in shipment storage, there is no available place");
				return false;
			}
			decorPack = decorPacker.PackDecor(decorObject);
			decorPack.SetState(InteractiveObjectState.Shipment);
			availablePoint.SetPackage(decorPack);
			return true;
		}

		public InteractiveObject RetrieveInteractiveObject(IShipmentPack package)
		{
			packageStacker.RemovePackageFromStack(package);
			packageStacker.UpdateStacks();
			this.OnShipmentStorageContentChanged?.Invoke();
			if (!(package is DevicePack devicePack))
			{
				if (package is DecorShipmentPack decorPack)
				{
					return decorPacker.UnpackDecor(decorPack).InteractiveObject;
				}
				throw new ArgumentOutOfRangeException("package", package, null);
			}
			return deviceService.UnpackDevice(devicePack);
		}

		public void UpdateShipmentStorageState()
		{
			packageStacker.UpdateStacks();
		}

		private bool IsDeviceCanBeShipped(DeviceContainer deviceContainer)
		{
			if ((bool)deviceContainer.Package)
			{
				return false;
			}
			switch (deviceService.CheckDeviceReadyForShipment(deviceContainer))
			{
			case CheckDeviceReadyForShipmentResult.Fail_DeviceIsUniqueAndNotForSale:
				interactiveObjectsTooltipsService.ShowUniqueDeviceTooltip(deviceContainer);
				return false;
			case CheckDeviceReadyForShipmentResult.Fail_DeviceQualityUnknown:
				return false;
			case CheckDeviceReadyForShipmentResult.Fail_DeviceFromOrderIsNotOfIdealQuality:
				if (deviceContainer.HasCustomer)
				{
					interactiveObjectsTooltipsService.ShowNotIdealDeviceOfWorkOrderWarningTooltip(deviceContainer);
				}
				else
				{
					interactiveObjectsTooltipsService.ShowNotIdealDeviceWarningTooltip(deviceContainer);
				}
				return false;
			case CheckDeviceReadyForShipmentResult.Fail_DeviceIsPartOfAWorkOrderWithAnotherDeviceAlreadyInShipment:
				interactiveObjectsTooltipsService.ShowDeviceFromSameOrderIsAlreadyPackedForShipmentTooltip(deviceContainer);
				return false;
			case CheckDeviceReadyForShipmentResult.Fail_NotAllDeviceWorkTypesCompleted:
				interactiveObjectsTooltipsService.ShowNotAllDeviceWorkTypesCompletedWarningTooltip(deviceContainer);
				return false;
			default:
				throw new NotImplementedException();
			case CheckDeviceReadyForShipmentResult.Success:
			{
				if (!packageStacker.HasAvailablePlace(out var _))
				{
					return false;
				}
				return true;
			}
			}
		}

		private bool IsDecorCanBeShipped(DecorObject decorObject)
		{
			if (decorObject.Info.IsNotForSale)
			{
				return false;
			}
			if (!packageStacker.HasAvailablePlace(out var _))
			{
				return false;
			}
			return true;
		}

		private bool TryToShipDevice(DeviceContainer deviceContainer, PackagePoint availablePoint)
		{
			if (deviceContainer.DragState != InteractiveObjectDragState.Shippable)
			{
				if (deviceService.CheckDeviceReadyForShipment(deviceContainer) == CheckDeviceReadyForShipmentResult.Fail_DeviceFromOrderIsNotOfIdealQuality)
				{
					gameWarningService.ShowWarning(gameWarningDatabase.NotIdealDeviceWarning);
				}
				return false;
			}
			if (!deviceService.TryToGetPackedDeviceForShipment(deviceContainer, out var devicePack))
			{
				return false;
			}
			availablePoint.SetPackage(devicePack);
			devicePack.SetState(InteractiveObjectState.Shipment);
			devicePack.CompleteDrag();
			this.OnShipmentStorageContentChanged?.Invoke();
			if (mainDayTimeSwitchingService.CurrentDayTime == MainDayTimes.AfterWork)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.OrderWaitingUntilMorning);
			}
			return true;
		}

		private bool TryToShipDecor(DecorObject decorObject, PackagePoint availablePoint)
		{
			DecorShipmentPack decorShipmentPack = decorPacker.PackDecor(decorObject);
			availablePoint.SetPackage(decorShipmentPack);
			decorShipmentPack.SetState(InteractiveObjectState.Shipment);
			decorShipmentPack.CompleteDrag();
			this.OnShipmentStorageContentChanged?.Invoke();
			if (mainDayTimeSwitchingService.CurrentDayTime == MainDayTimes.AfterWork)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.OrderWaitingUntilMorning);
			}
			return true;
		}

		private void ShowTooltipForDismantledDevice(DismantledDevicePack disassembledDevicePack)
		{
			if (disassembledDevicePack.DeviceContainer.HasCustomer)
			{
				interactiveObjectsTooltipsService.ShowNotIdealDeviceInBoxWarningTooltip(disassembledDevicePack);
			}
			else
			{
				interactiveObjectsTooltipsService.ShowNotIdealDeviceInBoxFleamarketWarningTooltip(disassembledDevicePack);
			}
		}

		private void ShowTooltipForCompetitionDevice(CompetitionDevicePack competitionDevicePack)
		{
			interactiveObjectsTooltipsService.ShowUnfinishedCompetitionWarningTooltip(competitionDevicePack);
		}

		private void ShowWarningForDismantledDevice(DismantledDevicePack disassembledDevicePack)
		{
			switch (disassembledDevicePack.DeviceContainer.Device.CheckAssembleStatus())
			{
			case Device.AssembleStatus.None:
			case Device.AssembleStatus.Disassembled:
				gameWarningService.ShowWarning(gameWarningDatabase.NotIdealDeviceWarning);
				break;
			case Device.AssembleStatus.Assembled:
				if (disassembledDevicePack.PlacedElements.ElementsOnSurface.Count > 0)
				{
					gameWarningService.ShowWarning(gameWarningDatabase.RemoveExtraParts);
				}
				break;
			case Device.AssembleStatus.NotScrewed:
				gameWarningService.ShowWarning(gameWarningDatabase.NotScrewedParts);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if ((bool)dragObjectRegistrator.DraggingObject && dragObjectRegistrator.DraggingObject.State != InteractiveObjectState.Delivery && !dragObjectRegistrator.DraggingObject.TryGetComponent<CashMoneyObject>(out var _))
			{
				shipmentTrigger.IsActive = true;
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			shipmentTrigger.IsActive = false;
		}
	}
}
