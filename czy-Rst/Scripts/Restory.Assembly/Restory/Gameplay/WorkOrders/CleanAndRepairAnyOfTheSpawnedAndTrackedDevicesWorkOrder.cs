using System;
using System.Collections.Generic;
using Restory.Data.Devices.Condition;

namespace Restory.Gameplay.WorkOrders
{
	[Serializable]
	public class CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrder : CleanAndRepairAnyOfTheDevicesWorkOrder
	{
		public List<DeviceCondition> DeviceConditions;
	}
}
