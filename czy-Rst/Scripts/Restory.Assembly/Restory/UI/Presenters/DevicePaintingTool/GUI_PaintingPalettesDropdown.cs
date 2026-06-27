using TMPro;
using UnityEngine;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_PaintingPalettesDropdown : GUI_RestoryDropdown
	{
		private int nextItemIndex;

		protected override GameObject CreateBlocker(Canvas rootCanvas)
		{
			nextItemIndex = 0;
			return base.CreateBlocker(rootCanvas);
		}

		protected override DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			DropdownItem dropdownItem = base.CreateItem(itemTemplate);
			if (!dropdownItem.TryGetComponent<GUI_PaintingPalettesDropdownItem>(out var component))
			{
				Debug.LogError("[GUI_PaintingPalettesDropdown] tried to set up a dropdown item, but the created item has no [GUI_PaintingPalettesDropdownItem] component!Check the supplied item template.");
				return dropdownItem;
			}
			int num = nextItemIndex;
			if (num < base.options.Count)
			{
				if (!(base.options[num] is GUI_PaintingPalettesDropdownOptionData paintingPalettesDropdownOptionData))
				{
					Debug.LogError("[GUI_PaintingPalettesDropdown] tried to set up a dropdown item, but its corresponding option data does not inherit from [GUI_PaintingPalettesDropdownOptionData]!");
				}
				else
				{
					component.Setup(paintingPalettesDropdownOptionData);
				}
			}
			else
			{
				Debug.LogError(string.Format("[{0}] tried to set up a dropdown item with index {1}, ", "GUI_PaintingPalettesDropdown", num) + $"but there's only {base.options.Count} options total!");
			}
			nextItemIndex++;
			return dropdownItem;
		}
	}
}
