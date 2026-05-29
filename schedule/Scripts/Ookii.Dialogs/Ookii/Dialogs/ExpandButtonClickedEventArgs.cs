using System;

namespace Ookii.Dialogs
{
	public class ExpandButtonClickedEventArgs : EventArgs
	{
		private bool _expanded;

		public bool Expanded => false;

		public ExpandButtonClickedEventArgs(bool expanded)
		{
		}
	}
}
