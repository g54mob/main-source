using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class ItemHelpers
	{
		public static void AddItemComponents(EntityContext ctx, Entity e, Item item)
		{
			foreach (IItemProperty property in item.Properties)
			{
				ItemComponentHelpers.SetDynamic(ctx, e, property);
			}
		}
	}
}
