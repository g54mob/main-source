using Restory.Data.Equipment;
using Restory.UI.Presenters.DevicePaintingTool;
using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopPaintingPaletteItemView : GUI_HomeDepotShopSingleUnitItemView
	{
		[SerializeField]
		private GUI_PaintingMiniPalette miniPalette;

		[SerializeField]
		private PresetName blockedPreset = PresetName.Blocked;

		public void SetupPaletteView(PaintingPaletteInfo paintingPalette, bool isBlocked)
		{
			miniPalette.SetColors(paintingPalette.Colors);
			if (isBlocked)
			{
				ApplyPreset(blockedPreset);
			}
		}
	}
}
