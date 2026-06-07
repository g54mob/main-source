using System.Collections.Generic;

namespace Gh.Tk
{
	public class ContextMenuInteractable3DUIView : BaseInteractable3DUIView, IContextMenuProvider
	{
		public List<ContextMenuItem> contextMenuItems;

		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}
	}
}
