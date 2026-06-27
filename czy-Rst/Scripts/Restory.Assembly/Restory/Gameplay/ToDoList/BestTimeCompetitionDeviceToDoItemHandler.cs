using Restory.Data.ToDoList;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.DeviceSales;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class BestTimeCompetitionDeviceToDoItemHandler : ToDoItemHandler
	{
		private FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService;

		private CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker;

		private BestTimeCompetitionDeviceToDoItem bestTimeCompetitionDeviceToDoItem;

		[Inject]
		private void Construct(FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService, CompetitionsDeviceContainersTrackingService competitionsDeviceContainersTracker)
		{
			this.freeSaleShippingDevicesTrackingService = freeSaleShippingDevicesTrackingService;
			this.competitionsDeviceContainersTracker = competitionsDeviceContainersTracker;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			if (!(item is BestTimeCompetitionDeviceToDoItem bestTimeCompetitionDeviceToDoItem))
			{
				Debug.LogError("[BestTimeCompetitionDeviceToDoItemHandler] tried to initialize, but the supplied item is not [BestTimeCompetitionDeviceToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.bestTimeCompetitionDeviceToDoItem = bestTimeCompetitionDeviceToDoItem;
			freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc += ResolveOnPreDevicePackClaimedByNpc;
		}

		public override void Dispose()
		{
			if (freeSaleShippingDevicesTrackingService.MonoShellExists())
			{
				freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc -= ResolveOnPreDevicePackClaimedByNpc;
			}
			bestTimeCompetitionDeviceToDoItem = null;
			base.Dispose();
		}

		private void ResolveOnPreDevicePackClaimedByNpc(ShipmentDevicePack devicePack)
		{
			if ((bool)bestTimeCompetitionDeviceToDoItem && (bool)devicePack && (bool)devicePack.DeviceContainer && (bool)devicePack.DeviceContainer.Device && devicePack.DeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition && competitionsDeviceContainersTracker.WasPreviousTimeBeaten(devicePack.DeviceContainer) && (bestTimeCompetitionDeviceToDoItem.Any || bestTimeCompetitionDeviceToDoItem.DeviceInfo == devicePack.DeviceContainer.Device.Info))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
