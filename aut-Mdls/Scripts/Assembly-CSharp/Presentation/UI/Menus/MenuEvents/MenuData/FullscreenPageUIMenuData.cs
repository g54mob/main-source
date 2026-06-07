using Presentation.UI.Menus.FullscreenPage;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class FullscreenPageUIMenuData : AbstractUIMenuData
	{
		public readonly FullPagesEnum PageToOpen;

		public FullscreenPageUIMenuData(UIMenu uiMenu, FullPagesEnum pageToOpen)
			: base(uiMenu, UIDomain.Page, ToggleTypes.HideHUD | ToggleTypes.DisableFactoryActions | ToggleTypes.HideTopHUD)
		{
			PageToOpen = pageToOpen;
		}
	}
}
