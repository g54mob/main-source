using System;
using System.Windows.Forms;

namespace Ookii.Dialogs.Interop
{
	internal class WindowHandleWrapper : IWin32Window
	{
		private IntPtr _handle;

		public IntPtr Handle => (IntPtr)0;

		public WindowHandleWrapper(IntPtr handle)
		{
		}
	}
}
