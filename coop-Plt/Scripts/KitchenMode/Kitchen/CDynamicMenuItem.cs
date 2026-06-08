using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CDynamicMenuItem : IComponentData
	{
		public int Ingredient;

		public DynamicMenuType Type;

		public bool HasBeenProvided;
	}
}
