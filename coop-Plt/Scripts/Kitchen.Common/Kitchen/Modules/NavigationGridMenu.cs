using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	public class NavigationGridMenu : GridMenu<GridMenuConfig>
	{
		public NavigationGridMenu(List<GridMenuConfig> items, Transform container, int player, bool has_back)
			: base(items, container, player, has_back)
		{
		}

		protected override void SetupElement(GridMenuConfig item, GridMenuElement element)
		{
			element.Set(item.Icon);
		}

		protected override void OnSelect(GridMenuConfig item)
		{
			RequestNewMenu(item);
		}
	}
}
