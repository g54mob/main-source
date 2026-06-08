using Unity.Entities;

namespace Kitchen
{
	public struct SKitchenStatus : IComponentData
	{
		public int RemainingLives;

		public int TotalLives;
	}
}
