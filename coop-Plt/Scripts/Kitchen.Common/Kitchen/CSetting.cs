using Unity.Entities;

namespace Kitchen
{
	public struct CSetting : IComponentData
	{
		public int RestaurantSetting;

		public Seed FixedSeed;
	}
}
