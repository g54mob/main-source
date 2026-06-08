using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItem : IComponentData
	{
		public int ID;

		public bool IsPartial;

		public bool IsTransient;

		public bool IsGroup;

		public ItemList Items;

		public ItemCategory Category;

		public static implicit operator CItem(int t)
		{
			return new CItem
			{
				ID = t
			};
		}

		public static implicit operator int(CItem h)
		{
			return h.ID;
		}

		public bool Satisfies(Item request)
		{
			bool flag = false;
			foreach (Item item in request.SatisfiedBy)
			{
				if (item.ID == ID)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
			ItemList items = Items;
			foreach (Item needsIngredient in request.NeedsIngredients)
			{
				bool flag2 = false;
				for (int i = 0; i < items.Count; i++)
				{
					if (items[i] == needsIngredient.ID)
					{
						items[i] = 0;
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return false;
				}
			}
			return true;
		}
	}
}
