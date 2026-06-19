using System;

namespace Battlehub.UIControls
{
	public class ItemAddEventArgs : EventArgs
	{
		public int Index { get; private set; }

		public ItemAddEventArgs(int index)
		{
			Index = index;
		}
	}
}
