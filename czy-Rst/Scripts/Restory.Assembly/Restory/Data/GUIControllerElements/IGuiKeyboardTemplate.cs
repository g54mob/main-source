using Rewired;

namespace Restory.Data.GUIControllerElements
{
	public interface IGuiKeyboardTemplate : IGuiControllerTemplate
	{
		IGuiControllerTemplateElement GetElement(KeyboardKeyCode keycode);
	}
}
