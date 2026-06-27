using System;
using System.Collections.Generic;
using Restory.Gameplay.Devices;

namespace Restory.Gameplay.WorkOrders
{
	[Serializable]
	public class CleanAndRepairAnyOfTheDevicesWorkOrder : WorkOrderBase
	{
		public List<DeviceInWorkOrder> Devices;

		public DeviceContainer DevicePackedForShipment;

		public override bool IsOrderClaimingVisitAlreadyScheduled => DevicePackedForShipment;
	}
}
