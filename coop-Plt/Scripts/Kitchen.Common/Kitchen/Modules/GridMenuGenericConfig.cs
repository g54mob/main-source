using System.Collections.Generic;
using System.Linq;
using Platforms;
using UnityEngine;

namespace Kitchen.Modules
{
	[CreateAssetMenu(fileName = "GridMenuGenericConfig", menuName = "Kitchen/GridMenu/Generic")]
	public class GridMenuGenericConfig : GridMenuConfig
	{
		public List<IGridItem> Items;

		public int DLC;

		public override GridMenu Instantiate(Transform container, int player, bool has_back)
		{
			int dlc_id = 0;
			return new GenericGridMenu(Items.Where(delegate(IGridItem x)
			{
				if (!(x is GridItemNavigation gridItemNavigation))
				{
					return true;
				}
				if (gridItemNavigation.Config is GridMenuCosmeticConfig gridMenuCosmeticConfig)
				{
					if (gridMenuCosmeticConfig.DLC == 0)
					{
						return true;
					}
					dlc_id = gridMenuCosmeticConfig.DLC;
				}
				else if (gridItemNavigation.Config is GridMenuGenericConfig gridMenuGenericConfig)
				{
					if (gridMenuGenericConfig.DLC == 0)
					{
						return true;
					}
					dlc_id = gridMenuGenericConfig.DLC;
				}
				return dlc_id == 0 || Platform.Current.HasDLC(dlc_id);
			}).ToList(), container, player, has_back);
		}
	}
}
