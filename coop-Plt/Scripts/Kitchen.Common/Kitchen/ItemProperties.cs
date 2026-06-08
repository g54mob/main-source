using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public static class ItemProperties
	{
		public static void Add(EntityContext ctx, Entity e, Item item)
		{
			if (item.Properties == null)
			{
				return;
			}
			foreach (IItemProperty property in item.Properties)
			{
				if (!(property is CPreventItemTransfer data))
				{
					if (!(property is CPreventItemMerge data2))
					{
						if (property is CSlowPlayer data3)
						{
							ctx.Set(e, data3);
						}
					}
					else
					{
						ctx.Set(e, data2);
					}
				}
				else
				{
					ctx.Set(e, data);
				}
			}
			if (item.IsMergeableSide)
			{
				ctx.Set(e, new CPreventItemMerge
				{
					Condition = MergeCondition.AsSide
				});
			}
		}

		public static void Clear(EntityContext ctx, Entity e)
		{
			ctx.Remove<CPreventItemTransfer>(e);
			ctx.Remove<CPreventItemMerge>(e);
		}
	}
}
