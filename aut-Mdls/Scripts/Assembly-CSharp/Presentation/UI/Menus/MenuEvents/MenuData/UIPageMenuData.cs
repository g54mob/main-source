using System.Collections.Generic;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class UIPageMenuData : AbstractUIMenuData
	{
		public UIPageMenuData(UIMenu uiMenu, ToggleTypes toggles = ToggleTypes.HideHUD, List<GoBackSourceSO> ignoredSources = null)
			: base(uiMenu, UIDomain.Page, toggles, ignoredSources)
		{
		}
	}
}
