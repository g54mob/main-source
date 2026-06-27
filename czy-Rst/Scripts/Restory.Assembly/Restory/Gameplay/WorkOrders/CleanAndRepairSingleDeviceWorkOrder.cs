using System;
using UnityEngine;

namespace Restory.Gameplay.WorkOrders
{
	[Serializable]
	public class CleanAndRepairSingleDeviceWorkOrder : WorkOrderBase
	{
		public DeviceInWorkOrder Device;

		[SerializeField]
		private bool isOrderClaimingVisitAlreadyScheduled;

		public override bool IsOrderClaimingVisitAlreadyScheduled => isOrderClaimingVisitAlreadyScheduled;

		public void SetOrderClaimingVisitStatus(bool isVisitScheduled)
		{
			isOrderClaimingVisitAlreadyScheduled = isVisitScheduled;
		}
	}
}
