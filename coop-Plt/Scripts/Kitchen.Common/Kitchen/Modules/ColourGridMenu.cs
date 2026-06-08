using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ColourGridMenu : GridMenu<Color>
	{
		protected override int RowLength => 10;

		protected override int ColumnLength => 4;

		protected override float ElementWidth => 0.2f;

		protected override float ElementHeight => 0.25f;

		protected override float Padding => 0.01f;

		public ColourGridMenu(List<Color> colours, Transform container, int player, bool has_back)
			: base(colours, container, player, has_back)
		{
		}

		protected override GridMenuElement GetPrefab()
		{
			return ModuleDirectory.Main.GetPrefab<GridMenuMiniElement>();
		}

		protected override void SetupElement(Color item, GridMenuElement element)
		{
			if (element is GridMenuMiniElement gridMenuMiniElement)
			{
				if (item == Color.black)
				{
					gridMenuMiniElement.SetSelectable(selectable: false);
					gridMenuMiniElement.SetVisible(visible: false);
				}
				else
				{
					gridMenuMiniElement.Set(item);
				}
			}
		}

		protected override void OnSelect(Color colour)
		{
			if (Player != 0 && colour.a > 0.1f)
			{
				ProfileAccessor.SetColour(Player, colour);
				Panel.SetColour(colour);
			}
		}
	}
}
