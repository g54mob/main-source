using System;
using System.Collections.Generic;
using Restory.Data.Devices.DeviceWorkTypes;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class PartOfEmailOrderInteractiveObjectProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		private int emailOrderID;

		[SerializeField]
		private List<DeviceWorkType> workTypes;

		public int EmailOrderID => emailOrderID;

		public IReadOnlyCollection<DeviceWorkType> WorkTypes => workTypes;

		public PartOfEmailOrderInteractiveObjectProperty(int emailOrderID, IReadOnlyCollection<DeviceWorkType> workTypes)
		{
			this.emailOrderID = emailOrderID;
			this.workTypes = new List<DeviceWorkType>(workTypes);
		}
	}
}
