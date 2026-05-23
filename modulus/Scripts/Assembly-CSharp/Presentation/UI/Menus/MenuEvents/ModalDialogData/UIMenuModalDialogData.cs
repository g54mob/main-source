using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.MenuData;

namespace Presentation.UI.Menus.MenuEvents.ModalDialogData
{
	public class UIMenuModalDialogData : AbstractUIModalDialogData
	{
		public readonly MenuModalDialogDto Dto;

		public UIMenuModalDialogData(MenuModalDialogDto dto)
		{
			Dto = dto;
		}
	}
}
