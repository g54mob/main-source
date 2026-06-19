using System;
using System.Runtime.InteropServices;

internal class oRMAhacdQFLtvsTgkVGUMnZMGrlw : IDisposable
{
	internal enum GmzrNFKnkihdJJFnKOCoGSfBBulxA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr VJDKvfeUTCuwZcDBPOIHmpoEnmal(int nCode, IntPtr wParam, IntPtr lParam);

	private const int dShQHwDfcYDEDnJaEPaapfrjGLYP = 4;

	private IntPtr OaTEYTpBitkGgivYHEAOjRLgiPgk = IntPtr.Zero;

	private VJDKvfeUTCuwZcDBPOIHmpoEnmal dyzrJokriAbtlLoCleybCiBkNJLc;

	private Action<IntPtr, IntPtr, uint, uint> RsuCDfNPdAmagaqbZrucvWQAoqjE;

	private bool ZdmZSjtkbndyafcYYnKNoGevpHRuA;

	public void ZgyfsTJRBtbmQDNVmtpIHEtAfpjhc(Action<IntPtr, IntPtr, uint, uint> P_0, GmzrNFKnkihdJJFnKOCoGSfBBulxA P_1)
	{
		RsuCDfNPdAmagaqbZrucvWQAoqjE = P_0;
		dyzrJokriAbtlLoCleybCiBkNJLc = wSHgodwuVHTWwUyMmpCqTsFtSLQC;
		uint num = 0u;
		if (P_1 == GmzrNFKnkihdJJFnKOCoGSfBBulxA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		OaTEYTpBitkGgivYHEAOjRLgiPgk = DuLCqojbUPeooRPsHiGmdzQvKtQM(4, dyzrJokriAbtlLoCleybCiBkNJLc, IntPtr.Zero, num);
		_ = OaTEYTpBitkGgivYHEAOjRLgiPgk == IntPtr.Zero;
	}

	public void TzIjeQRiTXeRHgPGvosdwdBgocfL()
	{
		if (!(OaTEYTpBitkGgivYHEAOjRLgiPgk == IntPtr.Zero) && kPNCmCAYMaCtLMTwwXGsvJFvPBsUA(OaTEYTpBitkGgivYHEAOjRLgiPgk))
		{
			OaTEYTpBitkGgivYHEAOjRLgiPgk = IntPtr.Zero;
		}
	}

	private IntPtr wSHgodwuVHTWwUyMmpCqTsFtSLQC(int P_0, IntPtr P_1, IntPtr P_2)
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
			RsuCDfNPdAmagaqbZrucvWQAoqjE(arg, arg2, arg3, arg4);
		}
		return gyzfycBSccqNdhzoBSsScnWCTQJgA(OaTEYTpBitkGgivYHEAOjRLgiPgk, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		WgNfIKMOYWramdHXtHGTHUMbpnQi(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void rClqeXmlwZwcOnMSeuDgygLQbUEd()
	{
		try
		{
			WgNfIKMOYWramdHXtHGTHUMbpnQi(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void WgNfIKMOYWramdHXtHGTHUMbpnQi(bool P_0)
	{
		if (!ZdmZSjtkbndyafcYYnKNoGevpHRuA)
		{
			TzIjeQRiTXeRHgPGvosdwdBgocfL();
			ZdmZSjtkbndyafcYYnKNoGevpHRuA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr DuLCqojbUPeooRPsHiGmdzQvKtQM(int P_0, VJDKvfeUTCuwZcDBPOIHmpoEnmal P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool kPNCmCAYMaCtLMTwwXGsvJFvPBsUA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr gyzfycBSccqNdhzoBSsScnWCTQJgA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
