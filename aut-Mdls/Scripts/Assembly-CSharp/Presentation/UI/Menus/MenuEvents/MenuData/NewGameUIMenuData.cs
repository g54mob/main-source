namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class NewGameUIMenuData : AbstractUIMenuData
	{
		public readonly bool ZenMode;

		public NewGameUIMenuData(UIMenu uiMenu, bool zenMode = false, ToggleTypes toggles = ToggleTypes.HideHUD)
			: base(uiMenu, UIDomain.Menu, toggles)
		{
			ZenMode = zenMode;
		}
	}
}
