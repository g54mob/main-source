using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CCustomerSpawnModifier : IComponentData
	{
		public Factor BaseCustomerMultiplier;

		public Factor PerDayCustomerMultiplier;
	}
}
