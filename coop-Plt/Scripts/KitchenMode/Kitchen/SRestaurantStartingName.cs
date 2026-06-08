using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct SRestaurantStartingName : IComponentData
	{
		public FixedString64 Name;
	}
}
