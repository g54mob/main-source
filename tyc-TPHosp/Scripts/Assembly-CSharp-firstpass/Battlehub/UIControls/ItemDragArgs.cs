using System;

namespace Battlehub.UIControls
{
	public class ItemDragArgs : EventArgs
	{
		public object DragItem { get; private set; }

		public ItemDragArgs(object[] dragItem)
		{
			DragItem = dragItem;
		}
	}
}
