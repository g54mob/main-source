using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	[CreateAssetMenu(fileName = "GridMenuCosmeticConfig", menuName = "Kitchen/GridMenu/Cosmetic")]
	public class GridMenuCosmeticConfig : GridMenuConfig
	{
		public List<PlayerCosmetic> Cosmetics;

		public int DLC;

		public override GridMenu Instantiate(Transform container, int player, bool has_back)
		{
			return new CosmeticGridMenu(Cosmetics, container, player, has_back);
		}
	}
}
