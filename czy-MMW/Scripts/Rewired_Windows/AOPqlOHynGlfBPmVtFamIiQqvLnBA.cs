using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class AOPqlOHynGlfBPmVtFamIiQqvLnBA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr kKlyeenvssAcHUTsgbgkaNksqgIu(int nCode, IntPtr wParam, IntPtr lParam);

	private struct QDmycyWhgiUBecydsAZmJZWJrqQW
	{
		public IntPtr gIMeIwJxcUTNwclDPkDyunKKjEAab;

		public IntPtr EtrMXSpOOCEyVZoJgFZaafOiwHZW;

		public uint elpIRtKBqOfGqnLKvhUqCTPDJfzz;

		public IntPtr EnscnzcueZNWABkNGeAYcYEMNFCJ;
	}

	private static AOPqlOHynGlfBPmVtFamIiQqvLnBA FCVDHNTQnKgpFeDjGAMnEkTdAuuSA;

	private IntPtr nsBpSUiDyylXeibujwuLAVMEclwj = IntPtr.Zero;

	private kKlyeenvssAcHUTsgbgkaNksqgIu gnTzSmFwGuqSbodWjzDebgBgfOqQ;

	private Action<HcRBSzHiTzbGMALvAEsXZexPXEBZ, oymhsAPIfMyZRMQaeDTCWtiWVvgh, uint, IntPtr> pTbbGKeiLbRbWleOyqWBYdAfZIugA;

	private byte[] hSpYoglDMsyMvqGDShnmRgwatEce;

	private readonly bool qQXOfTsDWiDksLNSAUaWtyUdODRl;

	private QDmycyWhgiUBecydsAZmJZWJrqQW VokmHBBFCOIbzSidMcaMSxjmzjFp;

	private bool qWihJySfRRgvlbLIXCUtwSCDVuGnA;

	public AOPqlOHynGlfBPmVtFamIiQqvLnBA()
	{
		if (FCVDHNTQnKgpFeDjGAMnEkTdAuuSA != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		FCVDHNTQnKgpFeDjGAMnEkTdAuuSA = this;
		qQXOfTsDWiDksLNSAUaWtyUdODRl = IntPtr.Size == 8;
		hSpYoglDMsyMvqGDShnmRgwatEce = new byte[IntPtr.Size * 3 + 4];
	}

	public void plUslHmSZsbRLrpVSVOAzQLjIDMb(Action<HcRBSzHiTzbGMALvAEsXZexPXEBZ, oymhsAPIfMyZRMQaeDTCWtiWVvgh, uint, IntPtr> P_0, bool P_1)
	{
		pTbbGKeiLbRbWleOyqWBYdAfZIugA = P_0;
		gnTzSmFwGuqSbodWjzDebgBgfOqQ = RdFarpWZhdMrTfuPsoASBJmVGLvj;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		nsBpSUiDyylXeibujwuLAVMEclwj = ASFpgqnglHWFmUUBcaXnfgQnPIMy(4, gnTzSmFwGuqSbodWjzDebgBgfOqQ, IntPtr.Zero, num);
		if (nsBpSUiDyylXeibujwuLAVMEclwj == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void ipjbFBItXRdTzTgzlUGhgeQYFrBuA()
	{
		if (!(nsBpSUiDyylXeibujwuLAVMEclwj == IntPtr.Zero))
		{
			if (!eIGVHUrNkTTimccczJccKTtrkSWP(nsBpSUiDyylXeibujwuLAVMEclwj))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				nsBpSUiDyylXeibujwuLAVMEclwj = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(kKlyeenvssAcHUTsgbgkaNksqgIu))]
	private static IntPtr RdFarpWZhdMrTfuPsoASBJmVGLvj(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, 0, FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce.Length);
		int num = 0;
		FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.gIMeIwJxcUTNwclDPkDyunKKjEAab = HcRBSzHiTzbGMALvAEsXZexPXEBZ.WkKmSDBqDFoXCMFhycRbkxUzcAe(HcRBSzHiTzbGMALvAEsXZexPXEBZ.fUQicADzxXIQrkxzHoyafEzebDHj(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, num));
		num += HcRBSzHiTzbGMALvAEsXZexPXEBZ.IabIDFFXuzTzMKLlKXhbFJMnNlAAb;
		FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.EtrMXSpOOCEyVZoJgFZaafOiwHZW = oymhsAPIfMyZRMQaeDTCWtiWVvgh.dwVkMnBykzultIstPbxUETXpOOGX(oymhsAPIfMyZRMQaeDTCWtiWVvgh.naAYQfrsWipUxkPhVtsEBasdCbFN(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, num));
		num += oymhsAPIfMyZRMQaeDTCWtiWVvgh.cpvgOWECUQEUFAOhISCaGGnWusfjB;
		FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.elpIRtKBqOfGqnLKvhUqCTPDJfzz = BitConverter.ToUInt32(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, num);
		num += 4;
		if (FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.qQXOfTsDWiDksLNSAUaWtyUdODRl)
		{
			FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.EnscnzcueZNWABkNGeAYcYEMNFCJ = new IntPtr(BitConverter.ToInt32(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, num + 4));
		}
		else
		{
			FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.EnscnzcueZNWABkNGeAYcYEMNFCJ = new IntPtr(BitConverter.ToInt32(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.hSpYoglDMsyMvqGDShnmRgwatEce, num));
		}
		if (P_0 >= 0)
		{
			FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.pTbbGKeiLbRbWleOyqWBYdAfZIugA(HcRBSzHiTzbGMALvAEsXZexPXEBZ.hWZgqaHVSypUmdJEsvIjORzlXnweA(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.gIMeIwJxcUTNwclDPkDyunKKjEAab), oymhsAPIfMyZRMQaeDTCWtiWVvgh.ImXPaiHLtatbwmhHshHWSHnnThoF(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.EtrMXSpOOCEyVZoJgFZaafOiwHZW), FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.elpIRtKBqOfGqnLKvhUqCTPDJfzz, FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.VokmHBBFCOIbzSidMcaMSxjmzjFp.EnscnzcueZNWABkNGeAYcYEMNFCJ);
		}
		return nopjTWajLarHwRhIvIrULuGnYSfW(FCVDHNTQnKgpFeDjGAMnEkTdAuuSA.nsBpSUiDyylXeibujwuLAVMEclwj, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		TdFEcJohNygONAzfLJBznZxqMbTgA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void jknmWVegzfEKIdgGXtRlgFazSrSj()
	{
		try
		{
			TdFEcJohNygONAzfLJBznZxqMbTgA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void TdFEcJohNygONAzfLJBznZxqMbTgA(bool P_0)
	{
		if (!qWihJySfRRgvlbLIXCUtwSCDVuGnA)
		{
			ipjbFBItXRdTzTgzlUGhgeQYFrBuA();
			if (FCVDHNTQnKgpFeDjGAMnEkTdAuuSA == this)
			{
				FCVDHNTQnKgpFeDjGAMnEkTdAuuSA = null;
			}
			qWihJySfRRgvlbLIXCUtwSCDVuGnA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr ASFpgqnglHWFmUUBcaXnfgQnPIMy(int P_0, kKlyeenvssAcHUTsgbgkaNksqgIu P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool eIGVHUrNkTTimccczJccKTtrkSWP(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr nopjTWajLarHwRhIvIrULuGnYSfW(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
