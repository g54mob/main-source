using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct SKitchenParameters : IComponentData
	{
		public KitchenParameters Parameters;

		public static readonly SKitchenParameters Defaults = new SKitchenParameters
		{
			Parameters = new KitchenParameters
			{
				CustomersPerHour = 1f,
				MinimumGroupSize = 1,
				MaximumGroupSize = 2
			}
		};
	}
}
