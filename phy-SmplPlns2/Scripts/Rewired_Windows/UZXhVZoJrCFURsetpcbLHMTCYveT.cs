using System;
using System.Runtime.InteropServices;

internal class UZXhVZoJrCFURsetpcbLHMTCYveT : IDisposable
{
	internal enum ershdgKANvjNdVsiZKbzZKzHNwuO
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr hTUQqWmmoLcUlkwGQInMvncKLrfq(int nCode, IntPtr wParam, IntPtr lParam);

	private const int PfyjyFgZEVlzrebfRVsdrcdlVRPmA = 4;

	private IntPtr gWOXeqvODqQWOgmFGjtXwkBkcthm = IntPtr.Zero;

	private hTUQqWmmoLcUlkwGQInMvncKLrfq LHpCBcamKxyLXOXhTFJjdZiFuZKhb;

	private Action<IntPtr, IntPtr, uint, uint> tvvdwsEXsNzMUkcvObCpYyWUbiobA;

	private bool lsdunEnhIyEiEmLDPnxMBfanLkKH;

	public void jDfCaoPkxaWHoTIjdITvJjhjxkSc(Action<IntPtr, IntPtr, uint, uint> P_0, ershdgKANvjNdVsiZKbzZKzHNwuO P_1)
	{
		tvvdwsEXsNzMUkcvObCpYyWUbiobA = P_0;
		LHpCBcamKxyLXOXhTFJjdZiFuZKhb = APSsQMoNROElCSqjzvEhUMkhxYVL;
		uint num = 0u;
		if (P_1 == ershdgKANvjNdVsiZKbzZKzHNwuO.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		gWOXeqvODqQWOgmFGjtXwkBkcthm = znCfgPxatACEMDFrQwhfRgWdSfPpA(4, LHpCBcamKxyLXOXhTFJjdZiFuZKhb, IntPtr.Zero, num);
		_ = gWOXeqvODqQWOgmFGjtXwkBkcthm == IntPtr.Zero;
	}

	public void zkFzNlDsqKrQfaRTmRJizABaNkwp()
	{
		if (!(gWOXeqvODqQWOgmFGjtXwkBkcthm == IntPtr.Zero) && YHEWpiUtrfJnJBjhdzDnIBmbVIrh(gWOXeqvODqQWOgmFGjtXwkBkcthm))
		{
			gWOXeqvODqQWOgmFGjtXwkBkcthm = IntPtr.Zero;
		}
	}

	private IntPtr APSsQMoNROElCSqjzvEhUMkhxYVL(int P_0, IntPtr P_1, IntPtr P_2)
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
			tvvdwsEXsNzMUkcvObCpYyWUbiobA(arg, arg2, arg3, arg4);
		}
		return AacYKROXprrGFhIhCRELepOKMPAm(gWOXeqvODqQWOgmFGjtXwkBkcthm, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		aqEOHjWBxLILOrKEoksGUxWvzWRg(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void PFeGYiasAAUWyTnJnHBlItucEfJqb()
	{
		try
		{
			aqEOHjWBxLILOrKEoksGUxWvzWRg(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void aqEOHjWBxLILOrKEoksGUxWvzWRg(bool P_0)
	{
		if (!lsdunEnhIyEiEmLDPnxMBfanLkKH)
		{
			zkFzNlDsqKrQfaRTmRJizABaNkwp();
			lsdunEnhIyEiEmLDPnxMBfanLkKH = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr znCfgPxatACEMDFrQwhfRgWdSfPpA(int P_0, hTUQqWmmoLcUlkwGQInMvncKLrfq P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool YHEWpiUtrfJnJBjhdzDnIBmbVIrh(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr AacYKROXprrGFhIhCRELepOKMPAm(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
