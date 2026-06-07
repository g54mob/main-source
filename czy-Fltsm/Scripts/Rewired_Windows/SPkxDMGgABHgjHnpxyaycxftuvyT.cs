using System;
using System.Runtime.InteropServices;

internal class SPkxDMGgABHgjHnpxyaycxftuvyT
{
	private int geIEwxAQpdgVpqbnPrUaUOpBgXDt;

	private byte[] dACeyBHpcfRzDvdSrPPNHsFrATHu;

	public virtual int cXxbOJdOwEpnKwCHzgLxJnCfVGSx => geIEwxAQpdgVpqbnPrUaUOpBgXDt;

	protected SPkxDMGgABHgjHnpxyaycxftuvyT()
	{
	}

	internal SPkxDMGgABHgjHnpxyaycxftuvyT(int P_0, IntPtr P_1)
	{
		fagVxQiRxJKFMpUgudxsKchLMEYS(P_0, P_1);
	}

	private unsafe void fagVxQiRxJKFMpUgudxsKchLMEYS(int P_0, IntPtr P_1)
	{
		geIEwxAQpdgVpqbnPrUaUOpBgXDt = P_0;
		if (geIEwxAQpdgVpqbnPrUaUOpBgXDt > 0 && P_1 != IntPtr.Zero)
		{
			dACeyBHpcfRzDvdSrPPNHsFrATHu = new byte[P_0];
			fixed (byte* ptr = dACeyBHpcfRzDvdSrPPNHsFrATHu)
			{
				qxcVmGprUKQYlnqWDgYoPbSYiwBQ.SLqTOazZKJnjvIMWFgYbNIplONWs((IntPtr)ptr, P_1, geIEwxAQpdgVpqbnPrUaUOpBgXDt);
			}
		}
	}

	protected virtual SPkxDMGgABHgjHnpxyaycxftuvyT xVhOBBzINSOBCVKnWdcUFTMSUJqVA(int P_0, IntPtr P_1)
	{
		fagVxQiRxJKFMpUgudxsKchLMEYS(P_0, P_1);
		return this;
	}

	internal virtual void MPTAmcAeDDBMXZXBTipKlzFPmwEv(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr dQHKWNMrrkqzEbDBgrugPwtKcMrn()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (geIEwxAQpdgVpqbnPrUaUOpBgXDt > 0 && dACeyBHpcfRzDvdSrPPNHsFrATHu != null)
		{
			intPtr = Marshal.AllocHGlobal(geIEwxAQpdgVpqbnPrUaUOpBgXDt);
			fixed (byte* ptr = dACeyBHpcfRzDvdSrPPNHsFrATHu)
			{
				qxcVmGprUKQYlnqWDgYoPbSYiwBQ.SLqTOazZKJnjvIMWFgYbNIplONWs(intPtr, (IntPtr)ptr, geIEwxAQpdgVpqbnPrUaUOpBgXDt);
			}
		}
		return intPtr;
	}

	public unsafe _0001 zXCUBMjpjbwEqvCjDRpChpNxFrcd<_0001>() where _0001 : SPkxDMGgABHgjHnpxyaycxftuvyT, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(SPkxDMGgABHgjHnpxyaycxftuvyT))
		{
			fixed (byte* ptr = dACeyBHpcfRzDvdSrPPNHsFrATHu)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().xVhOBBzINSOBCVKnWdcUFTMSUJqVA(geIEwxAQpdgVpqbnPrUaUOpBgXDt, (IntPtr)ptr2);
			}
		}
		return null;
	}
}
