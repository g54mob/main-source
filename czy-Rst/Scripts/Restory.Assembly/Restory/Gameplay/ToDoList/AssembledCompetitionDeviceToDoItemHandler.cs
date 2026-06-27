using Restory.Data.ToDoList;
using Restory.Gameplay.DeviceSales;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.ToDoList
{
	public sealed class AssembledCompetitionDeviceToDoItemHandler : ToDoItemHandler
	{
		private FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService;

		private AssembledCompetitionDeviceToDoItem assembledCompetitionDeviceToDoItem;

		[Inject]
		private void Construct(FreeSaleShippingDevicesTrackingService freeSaleShippingDevicesTrackingService)
		{
			this.freeSaleShippingDevicesTrackingService = freeSaleShippingDevicesTrackingService;
		}

		public override void Initialize(ToDoItem item, ToDoListService toDoListService)
		{
			base.Initialize(item, toDoListService);
			if (!(item is AssembledCompetitionDeviceToDoItem assembledCompetitionDeviceToDoItem))
			{
				Debug.LogError("[AssembledCompetitionDeviceToDoItemHandler] tried to initialize, but the supplied item is not [AssembledCompetitionDeviceToDoItem], but [" + item.GetType().Name + "] instead!");
				return;
			}
			this.assembledCompetitionDeviceToDoItem = assembledCompetitionDeviceToDoItem;
			freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc += ResolveOnPreDevicePackClaimedByNpc;
		}

		public override void Dispose()
		{
			if (freeSaleShippingDevicesTrackingService.MonoShellExists())
			{
				freeSaleShippingDevicesTrackingService.OnPreDevicePackClaimedByNpc -= ResolveOnPreDevicePackClaimedByNpc;
			}
			assembledCompetitionDeviceToDoItem = null;
			base.Dispose();
		}

		private void ResolveOnPreDevicePackClaimedByNpc(ShipmentDevicePack devicePack)
		{
			if ((bool)assembledCompetitionDeviceToDoItem && (bool)devicePack && (bool)devicePack.DeviceContainer && (bool)devicePack.DeviceContainer.Device && devicePack.DeviceContainer.AdditionalProperties.TryToGetProperty<InitialDeviceConditionProperty>(out var foundProperty) && foundProperty.DeviceCondition.IsPartOfCompetition && (assembledCompetitionDeviceToDoItem.Any || assembledCompetitionDeviceToDoItem.DeviceInfo == devicePack.DeviceContainer.Device.Info))
			{
				base.ToDoListService.CompleteItem(base.Item);
			}
		}
	}
}
