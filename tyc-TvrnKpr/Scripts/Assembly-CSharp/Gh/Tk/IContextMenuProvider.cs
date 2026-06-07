using System.Collections.Generic;

namespace Gh.Tk
{
	public interface IContextMenuProvider
	{
		IEnumerable<ContextMenuItem> GetContextMenuItems();
	}
}
