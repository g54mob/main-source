using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Overlays;

namespace Presentation.UI.ModuleViewer
{
	public class ModuleViewerMaxUIMenuData : AbstractUIModalDialogData
	{
		public (ModuleViewerData, int) DataAndIndex;

		public ModuleViewerMaxUIMenuData(UIModalDialog uiModal, (ModuleViewerData, int) dataAndIndex)
		{
			UIModal = uiModal;
			DataAndIndex = dataAndIndex;
		}
	}
}
