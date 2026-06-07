using System.Collections.Generic;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class UIMenuEmptyData : AbstractUIMenuData
	{
		public UIMenuEmptyData(UIMenu uiMenu, UIDomain domain = UIDomain.Factory, ToggleTypes toggles = ToggleTypes.HideHUD, List<GoBackSourceSO> ignoredSources = null)
			: base(uiMenu, domain, toggles, ignoredSources)
		{
		}
	}
}
