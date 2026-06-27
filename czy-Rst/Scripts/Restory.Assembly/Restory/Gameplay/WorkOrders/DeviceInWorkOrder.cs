using System;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Gameplay.Devices;

namespace Restory.Gameplay.WorkOrders
{
	[Serializable]
	public class DeviceInWorkOrder
	{
		public DeviceContainer DeviceContainer;

		public DeviceWorkType[] WorkTypes = new DeviceWorkType[0];
	}
}
