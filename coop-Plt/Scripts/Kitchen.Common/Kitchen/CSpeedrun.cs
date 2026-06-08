using Unity.Entities;

namespace Kitchen
{
	public struct CSpeedrun : IComponentData
	{
		public Seed Seed;

		public int Year;

		public int Week;

		public int DishID;
	}
}
