using Presentation.UI.Overlays;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public abstract class AbstractUIModalDialogData
	{
		public UIModalDialog UIModal;

		protected AbstractUIModalDialogData()
		{
		}

		protected AbstractUIModalDialogData(UIModalDialog uiModal)
		{
			UIModal = uiModal;
		}
	}
}
