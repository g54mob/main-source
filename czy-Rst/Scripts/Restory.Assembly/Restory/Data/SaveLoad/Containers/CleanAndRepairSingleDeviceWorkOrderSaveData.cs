using System;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class CleanAndRepairSingleDeviceWorkOrderSaveData : WorkOrderSaveData
	{
		public DeviceInWorkOrderSaveData Device;

		public bool IsOrderClaimingVisitAlreadyScheduled;
	}
}
