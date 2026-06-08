using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct CFranchiseItem : IComponentData
	{
		public FixedString64 Name;

		public DataObjectList Cards;

		public Seed MapSeed;
	}
}
