using Events.UI.Overlays;
using Presentation.UI.Menus.MenuEvents.MenuData;

namespace Presentation.UI.Menus.MenuEvents.ModalDialogData
{
	public class UIModaldialogData : AbstractUIModalDialogData
	{
		public readonly ModalDialogDto Dto;

		public UIModaldialogData(ModalDialogDto dto)
		{
			Dto = dto;
		}
	}
}
