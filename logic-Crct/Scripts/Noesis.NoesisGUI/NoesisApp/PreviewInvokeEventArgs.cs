using System;
using Noesis;

namespace NoesisApp
{
	public class PreviewInvokeEventArgs : Noesis.EventArgs
	{
		public bool Cancelling { get; set; }

		public PreviewInvokeEventArgs()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}
	}
}
