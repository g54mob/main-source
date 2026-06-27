using System;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CleanAndRepairAnyOfTheDevicesWorkOrderSaveData : WorkOrderSaveData
	{
		public DeviceInWorkOrderSaveData[] Devices;

		public string ShippingDeviceContainerID;
	}
}
