using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	public class CosmeticGridMenu : GridMenu<PlayerCosmetic>
	{
		public CosmeticGridMenu(List<PlayerCosmetic> cosmetics, Transform container, int player, bool has_back)
			: base(cosmetics, container, player, has_back)
		{
		}

		protected override void SetupElement(PlayerCosmetic item, GridMenuElement element)
		{
			element.Set(item);
		}

		protected override void OnSelect(PlayerCosmetic cosmetic)
		{
			if (Player != 0 && cosmetic != null)
			{
				ProfileAccessor.SetCosmetic(Player, cosmetic);
			}
		}
	}
}
