using Restory.Data.Equipment;
using Restory.UI.Presenters.DevicePaintingTool;
using UnityEngine;

namespace Restory.UI.Views.Shops.HomeDepot
{
	public sealed class GUI_HomeDepotShopCartPanelPaintingPaletteItemView : GUI_HomeDepotShopCartPanelSingleUnitItemView
	{
		[SerializeField]
		private GUI_PaintingMiniPalette miniPalette;

		public void SetupPaletteView(PaintingPaletteInfo paintingPalette)
		{
			miniPalette.SetColors(paintingPalette.Colors);
		}
	}
}
