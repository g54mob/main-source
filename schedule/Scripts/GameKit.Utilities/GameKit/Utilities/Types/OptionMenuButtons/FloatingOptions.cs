using System.Collections.Generic;
using GameKit.Utilities.Types.CanvasContainers;

namespace GameKit.Utilities.Types.OptionMenuButtons
{
	public class FloatingOptions : CanvasGroupFader
	{
		protected List<ButtonData> Buttons;

		protected virtual void AddButtons(bool clearExisting, IEnumerable<ButtonData> buttonDatas)
		{
		}

		protected virtual void RemoveButtons()
		{
		}
	}
}
