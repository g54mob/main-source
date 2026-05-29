using System;
using System.Windows.Forms;

namespace SFB
{
	public class WindowWrapper : IWin32Window
	{
		private IntPtr _hwnd;

		public IntPtr Handle => (IntPtr)0;

		public WindowWrapper(IntPtr handle)
		{
		}
	}
}
