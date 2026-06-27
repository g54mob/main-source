using System;
using System.Collections.Generic;
using Restory.Data.Devices.DeviceWorkTypes;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class PartOfWorkOrderInteractiveObjectProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		private int workOrderID;

		[SerializeField]
		private List<DeviceWorkType> workTypes;

		public int WorkOrderID => workOrderID;

		public IReadOnlyList<DeviceWorkType> WorkTypes => workTypes;

		public PartOfWorkOrderInteractiveObjectProperty(int workOrderID, IEnumerable<DeviceWorkType> assignedWorkTypes)
		{
			this.workOrderID = workOrderID;
			workTypes = new List<DeviceWorkType>(assignedWorkTypes);
		}
	}
}
