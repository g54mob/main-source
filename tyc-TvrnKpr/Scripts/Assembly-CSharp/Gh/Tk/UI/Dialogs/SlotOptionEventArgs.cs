using System;

namespace Gh.Tk.UI.Dialogs
{
	public class SlotOptionEventArgs : EventArgs
	{
		public int Hour { get; private set; }

		public SlotOption Option { get; private set; }

		public SlotOptionEventArgs(int hour, SlotOption option)
		{
		}
	}
}
