using System;
using Presentation.UI.Menus.MenuEvents.MenuData;

namespace Presentation.UI.Menus
{
	public class UnlockIslandDialogDto : AbstractUIMenuData
	{
		public ResourceCost ResourceCost;

		public bool IsAvaliable;

		public Action SuccessCallback;

		public Action CancelCallback;

		public UnlockIslandDialogDto(ResourceCost resourceCost, bool isAvaliable, UIMenu uiMenu, ToggleTypes toggles, Action successCallback, Action cancelCallback)
			: base(uiMenu, UIDomain.Factory, toggles)
		{
			ResourceCost = resourceCost;
			IsAvaliable = isAvaliable;
			SuccessCallback = successCallback;
			CancelCallback = cancelCallback;
		}
	}
}
