using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	public class GenericGridMenu : GridMenu<IGridItem>
	{
		public GenericGridMenu(List<IGridItem> cosmetics, Transform container, int player, bool has_back)
			: base(cosmetics, container, player, has_back)
		{
		}

		protected override void SetupElement(IGridItem item, GridMenuElement element)
		{
			element.Set(item);
		}

		protected override void OnSelect(IGridItem item)
		{
			if (!(item is GridItemNavigation gridItemNavigation))
			{
				if (!(item is GridItemCosmetic gridItemCosmetic))
				{
					if (item is GridItemDish gridItemDish)
					{
						Request(gridItemDish.Dish);
					}
				}
				else if (Player != 0 && gridItemCosmetic.Cosmetic != null)
				{
					ProfileAccessor.SetCosmetic(Player, gridItemCosmetic.Cosmetic);
				}
			}
			else if (gridItemNavigation.Config != null)
			{
				RequestNewMenu(gridItemNavigation.Config);
			}
		}
	}
}
