using System;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CCustomerIndicator : IComponentData
	{
		public bool HasPatience;

		public float Patience;

		public PatienceReason PatienceReason;

		public DrinkData Drink;

		public bool WantsDrink;

		public DisplayedPatienceFactor PatienceFactors;
	}
}
