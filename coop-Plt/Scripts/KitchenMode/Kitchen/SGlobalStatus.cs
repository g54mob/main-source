using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct SGlobalStatus : IComponentData
	{
		public RestaurantStatus Status;

		public DecorationType Theme;
	}
}
