using System;
using System.Runtime.InteropServices;

internal class RTnGcYiGrSCuGNYrztKqRUAigBoM
{
	internal enum amDfjrVMAAhFfakTTyMXKHlLzuUL
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	private static IntPtr TmzPdxozABuGHJWcJFkAfOhVkGkn = IntPtr.Zero;

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr lhUsXyZnWpBVuFkfHdSpHkqdymLkA(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr UmeoAqbBYyydzoLBtIWYiphJjDKm(string P_0);

	public static IntPtr qYTOIQmmJYzkHblXusbbzGFYZIkd(IntPtr P_0, amDfjrVMAAhFfakTTyMXKHlLzuUL P_1)
	{
		if (IntPtr.Size == 4)
		{
			return nbQMJuPdjBGgCkcKHdIXuiCkNNrWA(P_0, P_1);
		}
		return kOkchwjhAOjBnMUCdldfcQbDtAEcB(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr nbQMJuPdjBGgCkcKHdIXuiCkNNrWA(IntPtr P_0, amDfjrVMAAhFfakTTyMXKHlLzuUL P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr kOkchwjhAOjBnMUCdldfcQbDtAEcB(IntPtr P_0, amDfjrVMAAhFfakTTyMXKHlLzuUL P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool qptCvUFPbBsniLqpAbjCKhiXmlpi(IntPtr P_0);
}
