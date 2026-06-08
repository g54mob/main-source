using Unity.Entities;

namespace Kitchen
{
	public struct CDishChoice : IComponentData
	{
		public int Dish;

		public FixedDishReason Reason;
	}
}
