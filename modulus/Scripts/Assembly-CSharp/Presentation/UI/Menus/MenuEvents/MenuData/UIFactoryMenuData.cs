using System.Collections.Generic;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class UIFactoryMenuData : AbstractUIMenuData
	{
		public UIFactoryMenuData(UIMenu uiMenu, ToggleTypes toggles = ToggleTypes.HideHUD, List<GoBackSourceSO> ignoredSources = null)
			: base(uiMenu, UIDomain.Factory, toggles, ignoredSources)
		{
		}
	}
}
