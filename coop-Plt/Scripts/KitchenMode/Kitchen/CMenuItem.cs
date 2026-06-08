using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CMenuItem : IComponentData
	{
		public int Item;

		public float Weight;

		public MenuPhase Phase;

		public int SourceDish;
	}
}
