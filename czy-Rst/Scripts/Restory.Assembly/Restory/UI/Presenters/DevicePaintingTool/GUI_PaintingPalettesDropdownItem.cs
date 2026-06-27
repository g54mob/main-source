using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_PaintingPalettesDropdownItem : UIBehaviour
	{
		[SerializeField]
		private GUI_PaintingMiniPalette miniPalette;

		[SerializeField]
		private TMP_Text paletteNameText;

		public void Setup(GUI_PaintingPalettesDropdownOptionData paintingPalettesDropdownOptionData)
		{
			paletteNameText.text = paintingPalettesDropdownOptionData.text;
			miniPalette.SetColors(paintingPalettesDropdownOptionData.PaletteColors);
		}
	}
}
