using System;
using System.Runtime.InteropServices;

internal class DhKZEJsPBJYRErtPATSOJZVKdOdB : IDisposable
{
	internal enum tSttnrYenkcSxkQyaYFeaFnFWeQPA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr cNDaVZmCMETpQjYAxBbNvwNQzQHD(int nCode, IntPtr wParam, IntPtr lParam);

	private const int CfpclCXagGfclmldkbGwjstjMXtx = 4;

	private IntPtr viBaDfjWlrPHOpcLdXlMupFmmfJH = IntPtr.Zero;

	private cNDaVZmCMETpQjYAxBbNvwNQzQHD CCcdVrefysKUROqxmfrmJJoueBaDA;

	private Action<IntPtr, IntPtr, uint, uint> yOmySpVEEIXRKhjxdiyceEWCmuYQ;

	private bool gkoMsXdQgxyLGbIPmNNDVLkdZTiy;

	public void gxcfUtDfGxIHogEAQPcMPJtpkbQlA(Action<IntPtr, IntPtr, uint, uint> P_0, tSttnrYenkcSxkQyaYFeaFnFWeQPA P_1)
	{
		yOmySpVEEIXRKhjxdiyceEWCmuYQ = P_0;
		CCcdVrefysKUROqxmfrmJJoueBaDA = FPBGaJezpTcQEBCpUecyYkkzgUjM;
		uint num = 0u;
		if (P_1 == tSttnrYenkcSxkQyaYFeaFnFWeQPA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		viBaDfjWlrPHOpcLdXlMupFmmfJH = mnFaAItNGZNxSUnrxXigaMvrnVzC(4, CCcdVrefysKUROqxmfrmJJoueBaDA, IntPtr.Zero, num);
		_ = viBaDfjWlrPHOpcLdXlMupFmmfJH == IntPtr.Zero;
	}

	public void myARaaFOQVBQpvIRBKzhxPBcAuAQ()
	{
		if (!(viBaDfjWlrPHOpcLdXlMupFmmfJH == IntPtr.Zero) && ZYViOcKoTmkGvYixCcNgSFVnNTRr(viBaDfjWlrPHOpcLdXlMupFmmfJH))
		{
			viBaDfjWlrPHOpcLdXlMupFmmfJH = IntPtr.Zero;
		}
	}

	private IntPtr FPBGaJezpTcQEBCpUecyYkkzgUjM(int P_0, IntPtr P_1, IntPtr P_2)
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
			yOmySpVEEIXRKhjxdiyceEWCmuYQ(arg, arg2, arg3, arg4);
		}
		return HFdfAYIOfuwyTyqndMdUshGOEMkDA(viBaDfjWlrPHOpcLdXlMupFmmfJH, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		jrJBHwAgXYMzCyACNOHXYJUfrptF(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void KFnSTbuIcBcHeuAJQAxmfnaEqzpCb()
	{
		try
		{
			jrJBHwAgXYMzCyACNOHXYJUfrptF(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void jrJBHwAgXYMzCyACNOHXYJUfrptF(bool P_0)
	{
		if (!gkoMsXdQgxyLGbIPmNNDVLkdZTiy)
		{
			myARaaFOQVBQpvIRBKzhxPBcAuAQ();
			gkoMsXdQgxyLGbIPmNNDVLkdZTiy = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr mnFaAItNGZNxSUnrxXigaMvrnVzC(int P_0, cNDaVZmCMETpQjYAxBbNvwNQzQHD P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool ZYViOcKoTmkGvYixCcNgSFVnNTRr(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr HFdfAYIOfuwyTyqndMdUshGOEMkDA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
