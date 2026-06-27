using System;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class GeneratedDeviceProperty : InteractiveObjectAdditionalProperty, IPriceOverride
	{
		[SerializeField]
		private string randomlyGeneratedDeviceConditionID;

		[SerializeField]
		private int priceOverride = -1;

		public string RandomlyGeneratedDeviceConditionID => randomlyGeneratedDeviceConditionID;

		public int PriceOverride => priceOverride;

		public GeneratedDeviceProperty(string conditionID)
		{
			randomlyGeneratedDeviceConditionID = conditionID;
		}

		public GeneratedDeviceProperty(string conditionID, int priceOverride)
		{
			randomlyGeneratedDeviceConditionID = conditionID;
			this.priceOverride = priceOverride;
		}
	}
}
