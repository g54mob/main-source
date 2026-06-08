using Unity.Entities;

namespace Kitchen
{
	public struct CPossibleExtra : IComponentData
	{
		public int MenuItem;

		public int Ingredient;

		public CPossibleExtra(int menu_item, int ingredient)
		{
			MenuItem = menu_item;
			Ingredient = ingredient;
		}
	}
}
