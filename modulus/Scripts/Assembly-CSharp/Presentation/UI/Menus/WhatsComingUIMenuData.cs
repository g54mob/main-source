using Presentation.UI.Menus.MenuEvents.MenuData;

namespace Presentation.UI.Menus
{
	public class WhatsComingUIMenuData : AbstractUIMenuData
	{
		public readonly bool ProceedToExit;

		public WhatsComingUIMenuData(UIMenu uiMenu, bool proceedToExit, ToggleTypes toggles = ToggleTypes.HideHUD)
			: base(uiMenu, UIDomain.Page, toggles)
		{
			ProceedToExit = proceedToExit;
		}
	}
}
