using TMPro;
using UnityEngine;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_PaintingPalettesDropdownOptionData : TMP_Dropdown.OptionData
	{
		private readonly Color[] paletteColors;

		public Color[] PaletteColors => paletteColors;

		public GUI_PaintingPalettesDropdownOptionData(string paletteName, Color[] paletteColors)
		{
			this.paletteColors = paletteColors;
			base.text = paletteName;
		}
	}
}
