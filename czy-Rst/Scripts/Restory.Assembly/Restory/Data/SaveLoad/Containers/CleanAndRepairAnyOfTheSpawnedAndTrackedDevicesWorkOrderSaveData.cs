using System;
using Restory.Data.Devices.Condition;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CleanAndRepairAnyOfTheSpawnedAndTrackedDevicesWorkOrderSaveData : CleanAndRepairAnyOfTheDevicesWorkOrderSaveData
	{
		public DeviceCondition[] DeviceConditions;
	}
}
