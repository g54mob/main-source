using System;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public class DevicePacker : IInitializable, IDisposable
	{
		private readonly DeviceFactory deviceFactory;

		private readonly DeviceRegistry deviceRegistry;

		private readonly WorkSurface workSurface;

		private readonly PlacedElementsHandler placedElementsHandler;

		private readonly DevicePriceEstimationService devicePriceEstimationService;

		private readonly CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker;

		private readonly WorkOrdersService workOrdersService;

		private readonly EmailOrdersService emailOrdersService;

		[Inject]
		public DevicePacker(DeviceFactory deviceFactory, DeviceRegistry deviceRegistry, WorkSurface workSurface, PlacedElementsHandler placedElementsHandler, DevicePriceEstimationService devicePriceEstimationService, CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker, WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService)
		{
			this.competitionsDeviceContainersTracker = competitionsDeviceContainersTracker;
			this.deviceFactory = deviceFactory;
			this.deviceRegistry = deviceRegistry;
			this.workSurface = workSurface;
			this.placedElementsHandler = placedElementsHandler;
			this.devicePriceEstimationService = devicePriceEstimationService;
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
		}

		public void Initialize()
		{
			deviceRegistry.OnDeviceRegistered += ResolveDeviceRegistered;
			emailOrdersService.OnOrderDelivered += ResolveEmailOrderDelivered;
			workOrdersService.OnOrderAdded += ResolveWorkOrderAdded;
			workOrdersService.OnOrderRestored += ResolveWorkOrderAdded;
		}

		public void Dispose()
		{
			deviceRegistry.OnDeviceRegistered -= ResolveDeviceRegistered;
			emailOrdersService.OnOrderDelivered -= ResolveEmailOrderDelivered;
			workOrdersService.OnOrderAdded -= ResolveWorkOrderAdded;
			workOrdersService.OnOrderRestored -= ResolveWorkOrderAdded;
		}

		public DeviceContainer UnpackDeviceContainer(DevicePack devicePack)
		{
			DeviceContainer deviceContainer = devicePack.DeviceContainer;
			deviceContainer.transform.parent = workSurface.DeviceSpawnPoint;
			deviceContainer.transform.position = workSurface.DeviceSpawnPoint.position;
			deviceContainer.gameObject.SetActive(value: true);
			if (devicePack is DismantledDevicePack dismantledDevicePack)
			{
				placedElementsHandler.UnpackPlacedElements(dismantledDevicePack.PlacedElements);
			}
			else if (devicePack is CompetitionDevicePack competitionDevicePack)
			{
				placedElementsHandler.UnpackPlacedElements(competitionDevicePack.PlacedElements, isDevicePartOfCompetition: true);
			}
			deviceFactory.DestroyDevicePack(devicePack, workSurface.DeviceSpawnPoint);
			return deviceContainer;
		}

		public DismantledDevicePack PackPlacedDismantledDeviceContainer(DeviceContainer deviceContainer)
		{
			DismantledDevicePack dismantledDevicePack = deviceFactory.CreateDismantledDevicePack(deviceContainer);
			PlacedElements placedElements = placedElementsHandler.PackPlacedElements(dismantledDevicePack);
			PackDismantledDevice(dismantledDevicePack, deviceContainer, placedElements);
			dismantledDevicePack.SetState(InteractiveObjectState.Placed);
			return dismantledDevicePack;
		}

		public CompetitionDevicePack PackPlacedCompetitionDeviceContainer(DeviceContainer deviceContainer)
		{
			CompetitionDevicePack competitionDevicePack = deviceFactory.CreateCompetitionDevicePack(deviceContainer);
			PlacedElements placedElements = placedElementsHandler.PackPlacedElements(competitionDevicePack);
			PackCompetitionDevice(competitionDevicePack, deviceContainer, placedElements);
			competitionDevicePack.SetState(InteractiveObjectState.Placed);
			return competitionDevicePack;
		}

		public DismantledDevicePack PackStoredDismantledDeviceContainer(DeviceContainer deviceContainer, PlacedElementsData placedElementsData)
		{
			DismantledDevicePack dismantledDevicePack = deviceFactory.CreateDismantledDevicePack(deviceContainer);
			PlacedElements placedElements = placedElementsHandler.CreateAndPackPlacedElements(dismantledDevicePack, placedElementsData);
			PackDismantledDevice(dismantledDevicePack, deviceContainer, placedElements);
			dismantledDevicePack.SetState(InteractiveObjectState.Stored);
			return dismantledDevicePack;
		}

		public CompetitionDevicePack PackStoredCompetitionDeviceContainer(DeviceContainer deviceContainer, PlacedElementsData placedElementsData)
		{
			CompetitionDevicePack competitionDevicePack = deviceFactory.CreateCompetitionDevicePack(deviceContainer);
			PlacedElements placedElements = placedElementsHandler.CreateAndPackPlacedElements(competitionDevicePack, placedElementsData);
			PackCompetitionDevice(competitionDevicePack, deviceContainer, placedElements);
			competitionDevicePack.SetState(InteractiveObjectState.Stored);
			return competitionDevicePack;
		}

		public void RepackLicensedDeviceContainer(DeviceContainer deviceContainer)
		{
			deviceContainer.AdditionalProperties.RemoveProperty<PackedAsUnlicensedObjectProperty>();
			if (!(deviceContainer.RemovePackage() is UnlicensedDevicePackage devicePackage))
			{
				Debug.LogError("devicePackage is not of type UnlicensedDevicePackage");
				return;
			}
			deviceFactory.DestroyDevicePackage(devicePackage, deviceContainer.DevicePreset);
			deviceContainer.AdditionalProperties.TryToAddProperty(new PackedAsLicensedObjectProperty());
			PackLicensedDeviceContainer(deviceContainer).PerformRepack();
		}

		public void UnpackDeviceContainer(DeviceContainer deviceContainer)
		{
			if (!(deviceContainer.Package is DevicePackageBase devicePackageBase))
			{
				Debug.LogError("Package is not of type DevicePackageBase");
				return;
			}
			deviceContainer.RemovePackage();
			if (!(devicePackageBase is UnlicensedDevicePackage devicePackage))
			{
				if (!(devicePackageBase is LicensedDevicePackage devicePackage2))
				{
					throw new ArgumentOutOfRangeException();
				}
				deviceContainer.AdditionalProperties.RemoveProperty<PackedAsLicensedObjectProperty>();
				deviceFactory.DestroyDevicePackage(devicePackage2, deviceContainer.DevicePreset);
			}
			else
			{
				deviceContainer.AdditionalProperties.RemoveProperty<PackedAsUnlicensedObjectProperty>();
				deviceFactory.DestroyDevicePackage(devicePackage, deviceContainer.DevicePreset);
				Debug.LogError("Unexpected unpacking behavior of UnlicensedDevicePackage");
			}
		}

		public ShipmentDevicePack PackStoredDeviceContainerForDelivery(DeviceContainer deviceContainer)
		{
			IPriceOverride foundProperty;
			int num = ((!deviceContainer.AdditionalProperties.TryToGetProperty<IPriceOverride>(out foundProperty) || foundProperty.PriceOverride < 0) ? devicePriceEstimationService.EstimateDevicePrice(deviceContainer) : foundProperty.PriceOverride);
			if (deviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty2) && foundProperty2.DeviceCondition.IsPartOfCompetition)
			{
				num = (competitionsDeviceContainersTracker.WasPreviousTimeBeaten(deviceContainer) ? num : 0);
			}
			ShipmentDevicePack shipmentDevicePack = deviceFactory.CreateCompletedOrderDevicePack(deviceContainer);
			shipmentDevicePack.Init(deviceContainer, num);
			shipmentDevicePack.SetState(InteractiveObjectState.Stored);
			deviceContainer.Device.transform.localPosition = Vector3.zero;
			deviceContainer.Device.transform.localRotation = Quaternion.identity;
			return shipmentDevicePack;
		}

		private void PackDismantledDevice(DismantledDevicePack devicePack, DeviceContainer deviceContainer, PlacedElements placedElements)
		{
			OrderCategory orderCategory = GetOrderCategory(deviceContainer);
			if (orderCategory == OrderCategory.WorkOrder)
			{
				Sprite customerIcon = GetCustomerIcon(deviceContainer);
				devicePack.Init(deviceContainer, placedElements, orderCategory, customerIcon);
			}
			else
			{
				devicePack.Init(deviceContainer, placedElements, orderCategory);
			}
		}

		private void PackCompetitionDevice(CompetitionDevicePack devicePack, DeviceContainer deviceContainer, PlacedElements placedElements)
		{
			devicePack.Init(deviceContainer, placedElements);
		}

		private OrderCategory GetOrderCategory(DeviceContainer deviceContainer)
		{
			if (workOrdersService.DoesOrderExistForDevice(deviceContainer))
			{
				return OrderCategory.WorkOrder;
			}
			if (emailOrdersService.DoesOrderExistForDevice(deviceContainer))
			{
				return OrderCategory.EmailOrder;
			}
			return OrderCategory.FreeSale;
		}

		private Sprite GetCustomerIcon(DeviceContainer deviceContainer)
		{
			if (workOrdersService.TryToGetWorkOrderForDeviceContainer(deviceContainer, out var workOrder))
			{
				return workOrder.NpcOriginalCustomer.Icon;
			}
			return null;
		}

		private void ResolveDeviceRegistered(DeviceContainer deviceContainer)
		{
			if (!deviceContainer.Package)
			{
				if (deviceContainer.AdditionalProperties.ContainsProperty<PackedAsUnlicensedObjectProperty>())
				{
					PackUnlicensedDeviceContainer(deviceContainer);
				}
				else if (deviceContainer.AdditionalProperties.ContainsProperty<PackedAsLicensedObjectProperty>())
				{
					PackLicensedDeviceContainer(deviceContainer);
				}
			}
		}

		private void ResolveEmailOrderDelivered(TrackedEmailOrder emailOrder)
		{
			if ((bool)emailOrder.DeviceContainer && emailOrder.DeviceContainer.Package is DevicePackageBase devicePackageBase)
			{
				devicePackageBase.UpdatePackLabel(OrderCategory.EmailOrder);
			}
		}

		private void ResolveWorkOrderAdded(WorkOrdersService _, WorkOrderBase workOrder)
		{
			if (!(workOrder is CleanAndRepairSingleDeviceWorkOrder workOrder2))
			{
				if (!(workOrder is CleanAndRepairAnyOfTheDevicesWorkOrder workOrder3))
				{
					throw new ArgumentOutOfRangeException("workOrder", workOrder, null);
				}
				ResolveCleanAndRepairAnyOfDevicesWorkOrderAdded(workOrder3);
			}
			else
			{
				ResolveCleanAndRepairSingleDeviceWorkOrderAdded(workOrder2);
			}
		}

		private void ResolveCleanAndRepairSingleDeviceWorkOrderAdded(CleanAndRepairSingleDeviceWorkOrder workOrder)
		{
			if (workOrder.Device.DeviceContainer.Package is DevicePackageBase devicePackageBase)
			{
				devicePackageBase.UpdatePackLabel(OrderCategory.WorkOrder, workOrder.NpcOriginalCustomer.Icon);
			}
		}

		private void ResolveCleanAndRepairAnyOfDevicesWorkOrderAdded(CleanAndRepairAnyOfTheDevicesWorkOrder workOrder)
		{
			foreach (DeviceInWorkOrder device in workOrder.Devices)
			{
				if (device.DeviceContainer.Package is DevicePackageBase devicePackageBase)
				{
					devicePackageBase.UpdatePackLabel(OrderCategory.WorkOrder, workOrder.NpcOriginalCustomer.Icon);
				}
			}
		}

		private UnlicensedDevicePackage PackUnlicensedDeviceContainer(DeviceContainer deviceContainer)
		{
			UnlicensedDevicePackage unlicensedDevicePackage = deviceFactory.CreateUnlicensedDevicePack(deviceContainer);
			PackDeviceContainer(unlicensedDevicePackage, deviceContainer);
			return unlicensedDevicePackage;
		}

		private LicensedDevicePackage PackLicensedDeviceContainer(DeviceContainer deviceContainer)
		{
			LicensedDevicePackage licensedDevicePackage = deviceFactory.CreateLicensedDevicePack(deviceContainer);
			PackDeviceContainer(licensedDevicePackage, deviceContainer);
			return licensedDevicePackage;
		}

		private void PackDeviceContainer(DevicePackageBase devicePackage, DeviceContainer deviceContainer)
		{
			deviceContainer.SetPackage(devicePackage);
			OrderCategory orderCategory = GetOrderCategory(deviceContainer);
			Sprite customerIcon = ((orderCategory == OrderCategory.WorkOrder) ? GetCustomerIcon(deviceContainer) : null);
			devicePackage.Init(deviceContainer, orderCategory, customerIcon);
		}
	}
}
