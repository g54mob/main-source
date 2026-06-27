using Restory.Data.GuiElementTypes;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public interface IFocusedPanelChecker
	{
		bool IsPanelFocused(Transform panel);

		bool IsPanelFocused(GuiElementType elementType);
	}
}
