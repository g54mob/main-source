using System;
using System.Runtime.InteropServices;

internal class fjzrLyXfpeMwIwOuEfBRPfzDEBC : IDisposable
{
	internal enum KTzQnoSsWplllRhMZrKUHpHKJps
	{
		kNfsuRqifGXacKAdYqNZtBZKOom = 0,
		vvyijmZOzRFtTdippDQZhtsZhGJC = 1
	}

	private delegate IntPtr BMlaCGFRVRtQWKrnkcgAluoaRJMw(int nCode, IntPtr wParam, IntPtr lParam);

	private const int GToGAwRxNiGZwsDoiyxudwCcNkq = 4;

	private IntPtr ANRPjvfIQHGcwfqwnFRqooBAfRAc = IntPtr.Zero;

	private BMlaCGFRVRtQWKrnkcgAluoaRJMw TCNplHYomUEbzIIagJyzdbhcaBSy;

	private Action<IntPtr, IntPtr, uint, uint> vYDyIrldKuBzitCmacbGbKCTAfjl;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public void sNUVbIfmUnCXtcPdpvKSKByqonA(Action<IntPtr, IntPtr, uint, uint> P_0, KTzQnoSsWplllRhMZrKUHpHKJps P_1)
	{
		vYDyIrldKuBzitCmacbGbKCTAfjl = P_0;
		TCNplHYomUEbzIIagJyzdbhcaBSy = pSoFdClHUGFeNFUqDfHgFuQJfare;
		uint num = 0u;
		if (P_1 == KTzQnoSsWplllRhMZrKUHpHKJps.kNfsuRqifGXacKAdYqNZtBZKOom)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		ANRPjvfIQHGcwfqwnFRqooBAfRAc = XrTDeBbdcLYNfpkHTurDykDWfMhb(4, TCNplHYomUEbzIIagJyzdbhcaBSy, IntPtr.Zero, num);
		bool flag = ANRPjvfIQHGcwfqwnFRqooBAfRAc == IntPtr.Zero;
	}

	public void zdHTTidIHxvZLvYzVRBSuCyiEeR()
	{
		if (!(ANRPjvfIQHGcwfqwnFRqooBAfRAc == IntPtr.Zero) && SSaBLiNoDmtpUktqQMkAapEhbZs(ANRPjvfIQHGcwfqwnFRqooBAfRAc))
		{
			ANRPjvfIQHGcwfqwnFRqooBAfRAc = IntPtr.Zero;
		}
	}

	private IntPtr pSoFdClHUGFeNFUqDfHgFuQJfare(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			vYDyIrldKuBzitCmacbGbKCTAfjl(arg, arg2, arg3, arg4);
		}
		return jrZBLWDuxjYPmbvcXMlgWiwKTLJ(ANRPjvfIQHGcwfqwnFRqooBAfRAc, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~fjzrLyXfpeMwIwOuEfBRPfzDEBC()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			zdHTTidIHxvZLvYzVRBSuCyiEeR();
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr XrTDeBbdcLYNfpkHTurDykDWfMhb(int P_0, BMlaCGFRVRtQWKrnkcgAluoaRJMw P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool SSaBLiNoDmtpUktqQMkAapEhbZs(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr jrZBLWDuxjYPmbvcXMlgWiwKTLJ(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
