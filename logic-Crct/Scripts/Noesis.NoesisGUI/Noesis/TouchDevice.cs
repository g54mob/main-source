using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TouchDevice : InputDevice
	{
		public ulong Id { get; private set; }

		public UIElement DirectlyOver => null;

		public CaptureMode CaptureMode => default(CaptureMode);

		public UIElement Captured => null;

		internal TouchDevice(UIElement target, ulong id)
			: base(null)
		{
		}

		[PreserveSig]
		private static extern IntPtr TouchDevice_GetCaptured(HandleRef target, ulong id);
	}
}
