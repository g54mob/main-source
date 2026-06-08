using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	[CreateAssetMenu(fileName = "Navigation Menu", menuName = "Kitchen/GridMenu/Navigation")]
	public class GridMenuNavigationConfig : GridMenuConfig
	{
		public List<GridMenuConfig> Links;

		public override GridMenu Instantiate(Transform container, int player, bool has_back)
		{
			return new NavigationGridMenu(Links, container, player, has_back);
		}
	}
}
