using System;
using Restory.Data.Devices.Condition;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class InitialDeviceConditionProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		public IDeviceCondition deviceCondition;

		public IDeviceCondition DeviceCondition => deviceCondition;

		public InitialDeviceConditionProperty(IDeviceCondition deviceCondition)
		{
			this.deviceCondition = deviceCondition;
		}
	}
}
