using System;
using System.Runtime.InteropServices;

internal class HjwWzKVGFAZRZPGbfMWAujjhayTs : IDisposable
{
	internal enum tFHgerhmvdWVzaNaHqSceDNqZbFS
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr eetnWJDdEJHCnXKMWqUXGSAnBmSO(int nCode, IntPtr wParam, IntPtr lParam);

	private const int IMDfYQmylFxYjUfpTBecPXVSUDeC = 4;

	private IntPtr nfbfhHMximQgOVViQQcYRzELzAAD = IntPtr.Zero;

	private eetnWJDdEJHCnXKMWqUXGSAnBmSO SPYMpxBDyvRIFkWvBsPoulOLAhll;

	private Action<IntPtr, IntPtr, uint, uint> kfWppfcWjJYuQPjpAfWgDeMxrCTg;

	private bool olKDtPGSambESHLVBVSZlaMUtYjgb;

	public void ouMUXryaAsdAwjyCrErKfuHYVqZz(Action<IntPtr, IntPtr, uint, uint> P_0, tFHgerhmvdWVzaNaHqSceDNqZbFS P_1)
	{
		kfWppfcWjJYuQPjpAfWgDeMxrCTg = P_0;
		SPYMpxBDyvRIFkWvBsPoulOLAhll = VYlTNKPdiOzcSxdihrBkrIXAJhmF;
		uint num = 0u;
		if (P_1 == tFHgerhmvdWVzaNaHqSceDNqZbFS.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		nfbfhHMximQgOVViQQcYRzELzAAD = ibppzMONZKKGIcptUQroDjyMikeF(4, SPYMpxBDyvRIFkWvBsPoulOLAhll, IntPtr.Zero, num);
		_ = nfbfhHMximQgOVViQQcYRzELzAAD == IntPtr.Zero;
	}

	public void seICkxeKGzWrEVBwgafjKfELzXlb()
	{
		if (!(nfbfhHMximQgOVViQQcYRzELzAAD == IntPtr.Zero) && HylYHgzvXhbHrqMrxoMulnbOnKSU(nfbfhHMximQgOVViQQcYRzELzAAD))
		{
			nfbfhHMximQgOVViQQcYRzELzAAD = IntPtr.Zero;
		}
	}

	private IntPtr VYlTNKPdiOzcSxdihrBkrIXAJhmF(int P_0, IntPtr P_1, IntPtr P_2)
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
			kfWppfcWjJYuQPjpAfWgDeMxrCTg(arg, arg2, arg3, arg4);
		}
		return HQLxTStUbnDrNULpOYeATJcrkHhU(nfbfhHMximQgOVViQQcYRzELzAAD, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		nbxEMsfMNRkDWMnEgDFLnngUBiur(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void UoLTLtBqCAIWkUDpdsCiOKCxstsH()
	{
		try
		{
			nbxEMsfMNRkDWMnEgDFLnngUBiur(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void nbxEMsfMNRkDWMnEgDFLnngUBiur(bool P_0)
	{
		if (!olKDtPGSambESHLVBVSZlaMUtYjgb)
		{
			seICkxeKGzWrEVBwgafjKfELzXlb();
			olKDtPGSambESHLVBVSZlaMUtYjgb = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr ibppzMONZKKGIcptUQroDjyMikeF(int P_0, eetnWJDdEJHCnXKMWqUXGSAnBmSO P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool HylYHgzvXhbHrqMrxoMulnbOnKSU(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr HQLxTStUbnDrNULpOYeATJcrkHhU(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
