using System;
using System.Runtime.InteropServices;

internal class VTNoVjlIVCacGhRTygXykaAUrCpx : IDisposable
{
	internal enum dNsPIUXDfjjeiAMYONBIVkkHIPpmA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr qnCDZmxTENfFypJkPRYdScnWAYaf(int nCode, IntPtr wParam, IntPtr lParam);

	private const int uMIyXvtutQnjurvNUMIBOdzfsAVN = 4;

	private IntPtr qxjBeqjPsljGofcFCHvFzPkEHUtjc = IntPtr.Zero;

	private qnCDZmxTENfFypJkPRYdScnWAYaf dnbckGakYuxXjdVTWFGOHMMxuQtEb;

	private Action<IntPtr, IntPtr, uint, uint> BbhfluLguGLVocTpKVCljhCKcGCg;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public void CewYRNFeLZahFxSUTTlHnZubdlxB(Action<IntPtr, IntPtr, uint, uint> P_0, dNsPIUXDfjjeiAMYONBIVkkHIPpmA P_1)
	{
		BbhfluLguGLVocTpKVCljhCKcGCg = P_0;
		dnbckGakYuxXjdVTWFGOHMMxuQtEb = TqSWuZHmogdATAARzFtREkvGGbKfb;
		uint num = 0u;
		if (P_1 == dNsPIUXDfjjeiAMYONBIVkkHIPpmA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		qxjBeqjPsljGofcFCHvFzPkEHUtjc = rkxUtCVFSlqznwrihhFaBssVOPMs(4, dnbckGakYuxXjdVTWFGOHMMxuQtEb, IntPtr.Zero, num);
		_ = qxjBeqjPsljGofcFCHvFzPkEHUtjc == IntPtr.Zero;
	}

	public void TjvgUpcHnLAfNugOvdfpqXRnYboQA()
	{
		if (!(qxjBeqjPsljGofcFCHvFzPkEHUtjc == IntPtr.Zero) && svGSytvrsAVUSfHmqIbvPHtkOrRj(qxjBeqjPsljGofcFCHvFzPkEHUtjc))
		{
			qxjBeqjPsljGofcFCHvFzPkEHUtjc = IntPtr.Zero;
		}
	}

	private IntPtr TqSWuZHmogdATAARzFtREkvGGbKfb(int P_0, IntPtr P_1, IntPtr P_2)
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
			BbhfluLguGLVocTpKVCljhCKcGCg(arg, arg2, arg3, arg4);
		}
		return JLhGHNrNPBsrkgZtfwIZdTeFUIcE(qxjBeqjPsljGofcFCHvFzPkEHUtjc, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			TjvgUpcHnLAfNugOvdfpqXRnYboQA();
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr rkxUtCVFSlqznwrihhFaBssVOPMs(int P_0, qnCDZmxTENfFypJkPRYdScnWAYaf P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool svGSytvrsAVUSfHmqIbvPHtkOrRj(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr JLhGHNrNPBsrkgZtfwIZdTeFUIcE(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
