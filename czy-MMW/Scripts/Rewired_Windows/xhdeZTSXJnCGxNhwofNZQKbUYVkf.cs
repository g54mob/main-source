using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal static class xhdeZTSXJnCGxNhwofNZQKbUYVkf
{
	private static IntPtr OyNTFLUiwGzxhOfwzPbDJmWBROkf = IntPtr.Zero;

	private static int qUZWwPIplMVXzDiYTQhoSZwvqdlJ;

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	public static extern IntPtr ZrSJGcZVCwiYvRcQlAijaRRBSRYBA();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	public static extern bool IwjPJrzhDiIWdknrjXKCQJAwYDvP(IntPtr P_0, out bool P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr SYDEfxBHNEOelGmRkCIyUziTxipI();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	public static extern IntPtr jSsEoyCiXeWymrQCCFHpQUxMZmYnA();

	public static IntPtr IjbQBSTwFTKwLzTSkhcPPWCIlHkF(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return NJJAUxuveQICAxMXlNYEMdMREeNo(P_0, P_1);
		}
		return qespGHykrGssykXpvkmVJgzlAtkjA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	private static extern IntPtr NJJAUxuveQICAxMXlNYEMdMREeNo(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	private static extern IntPtr qespGHykrGssykXpvkmVJgzlAtkjA(IntPtr P_0, int P_1);

	public static IntPtr PDZlNXLkufbQVEgmlxvLtYuCvzRx(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return atLtPbkQdsfOidRRxIYLLXBtnLrgA(P_0, P_1, P_2);
		}
		return RsPBLAfjoBZUGIzLhmUiltLZIDyDb(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	private static extern IntPtr RsPBLAfjoBZUGIzLhmUiltLZIDyDb(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	private static extern IntPtr atLtPbkQdsfOidRRxIYLLXBtnLrgA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	public static extern uint jBwaqdTJbitTyFTlFngjEsHsiOmR(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	public static extern uint DePHAwEHBFoEOrAwVKvdVCbXdUTm(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	public static extern int EefkximbqHQaFfSrCnmuADmMjmCt(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	public static extern bool BQGoKeTmKtxozOFnXVxHqPFSovXo(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	public static extern int FiQztJUluIQTMypGcNiAChsoOgYN(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	public static extern bool giJorwpiJJWErkwtXpTOZjLfXrcC(out NvuwChWsrdBgBqtkBKgIsEdeBSDFA P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	public static extern IntPtr ZPfBRCEaRaDPsyjHiyKTWxsTAtiy(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	public static extern short qczMURwLEHoqJSNURokiXFZhpwPg(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	public static extern short cVVJPofbNekbUkvAkavPgHjEfZgZ(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	public static extern bool jSyKrPhtezLHGZBrtetWtsudALZIA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	public static extern bool NHcZnwyeQmaCxpwyVHnwhzKjCZRP(IntPtr P_0, out NvuwChWsrdBgBqtkBKgIsEdeBSDFA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	public static extern bool PnQDnlPvuSLRcxyPBbYoYfsiIjMH(IntPtr P_0, out qNliJNWDKfHiZYSTOzmCOyDFhWuE P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	public static extern bool vawwOkBMVVyDZAPkdpXpdGtucsBD(IntPtr P_0, out qNliJNWDKfHiZYSTOzmCOyDFhWuE P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	public static extern uint FfoulXbKZXsZqPtneqmjdkTGQUpS(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	public static extern IntPtr nizNcWabHkRXAuqTvPOsfLqiHrhR(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	public static extern bool HkyeKbCcBtzyqzwTGbrQeAjgKnCh(IntPtr P_0);

	public static IntPtr dMoylxvxjKLqXzqYCFnxmvNlHmFFA()
	{
		if (!UnityTools.isEditor && OyNTFLUiwGzxhOfwzPbDJmWBROkf != IntPtr.Zero)
		{
			return OyNTFLUiwGzxhOfwzPbDJmWBROkf;
		}
		return OyNTFLUiwGzxhOfwzPbDJmWBROkf = SYDEfxBHNEOelGmRkCIyUziTxipI();
	}

	public static bool dYPoIGjWailnaVPTrbYXWFaUOXJL()
	{
		try
		{
			if (qUZWwPIplMVXzDiYTQhoSZwvqdlJ == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					qUZWwPIplMVXzDiYTQhoSZwvqdlJ = 2;
				}
				else if (IwjPJrzhDiIWdknrjXKCQJAwYDvP(ZrSJGcZVCwiYvRcQlAijaRRBSRYBA(), out flag))
				{
					if (flag)
					{
						qUZWwPIplMVXzDiYTQhoSZwvqdlJ = 2;
					}
					else
					{
						qUZWwPIplMVXzDiYTQhoSZwvqdlJ = 1;
					}
				}
			}
		}
		catch
		{
			qUZWwPIplMVXzDiYTQhoSZwvqdlJ = 1;
		}
		return qUZWwPIplMVXzDiYTQhoSZwvqdlJ == 2;
	}
}
