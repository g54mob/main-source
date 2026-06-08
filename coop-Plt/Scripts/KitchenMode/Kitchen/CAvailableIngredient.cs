using Unity.Entities;

namespace Kitchen
{
	public struct CAvailableIngredient : IComponentData
	{
		public int MenuItem;

		public int Ingredient;

		public CAvailableIngredient(int menu_item, int ingredient)
		{
			MenuItem = menu_item;
			Ingredient = ingredient;
		}
	}
}
