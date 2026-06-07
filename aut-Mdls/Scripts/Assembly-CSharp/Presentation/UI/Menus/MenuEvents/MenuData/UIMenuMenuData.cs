using System.Collections.Generic;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class UIMenuMenuData : AbstractUIMenuData
	{
		public UIMenuMenuData(UIMenu uiMenu, ToggleTypes toggles = ToggleTypes.HideHUD, List<GoBackSourceSO> ignoredSources = null)
			: base(uiMenu, UIDomain.Menu, toggles, ignoredSources)
		{
		}
	}
}
