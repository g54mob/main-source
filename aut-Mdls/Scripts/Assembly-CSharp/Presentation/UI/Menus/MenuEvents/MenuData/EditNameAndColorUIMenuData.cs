using System.Collections.Generic;
using Data;

namespace Presentation.UI.Menus.MenuEvents.MenuData
{
	public class EditNameAndColorUIMenuData : AbstractUIMenuData
	{
		private const ToggleTypes TOGGLES = ToggleTypes.HideHUD | ToggleTypes.DisableFactoryActions | ToggleTypes.DisableUIActions;

		public EditNameAndColorUIData EditNameAndColorUIData;

		public EditNameAndColorUIMenuData(UIMenu uiMenu, EditNameAndColorUIData editNameAndColorUIData, ToggleTypes toggles = ToggleTypes.HideHUD | ToggleTypes.DisableFactoryActions | ToggleTypes.DisableUIActions, List<GoBackSourceSO> ignoredSources = null)
			: base(uiMenu, UIDomain.Menu, toggles, ignoredSources)
		{
			EditNameAndColorUIData = editNameAndColorUIData;
		}
	}
}
