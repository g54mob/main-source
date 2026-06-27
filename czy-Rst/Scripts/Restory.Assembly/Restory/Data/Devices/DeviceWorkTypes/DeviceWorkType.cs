using System;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Data.Devices.DeviceWorkTypes
{
	[Serializable]
	public abstract class DeviceWorkType : IRandomnessWeightHolder, ICloneable
	{
		public bool IsAvailable;

		public string LocalizationKey;

		[SerializeField]
		protected int randomnessWeight;

		public int Weight => randomnessWeight;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
