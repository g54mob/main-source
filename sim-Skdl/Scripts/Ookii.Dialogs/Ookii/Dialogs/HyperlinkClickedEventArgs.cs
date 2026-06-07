using System;

namespace Ookii.Dialogs
{
	public class HyperlinkClickedEventArgs : EventArgs
	{
		private string _href;

		public string Href => null;

		public HyperlinkClickedEventArgs(string href)
		{
		}
	}
}
