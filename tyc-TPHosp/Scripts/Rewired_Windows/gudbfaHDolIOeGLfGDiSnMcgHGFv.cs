using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class gudbfaHDolIOeGLfGDiSnMcgHGFv : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr JEcNRyonjHSoBLoojFeiAcWRzqNV(int nCode, IntPtr wParam, IntPtr lParam);

	private struct dMaLLsNfxGdarhjdsshMBcNkXbhc
	{
		public IntPtr QMymFPDgflaolCygguUbfrKiWpi;

		public IntPtr LFzugOzqQkdrWkNByPrQpPRKVhl;

		public uint RcjcoDCvgnimiBTmwEwFjlBmgfcZ;

		public IntPtr rSXoAyjNbABtqBCVvNSGbJqJwRri;
	}

	private const int OIcBfWGLZUNhJAggJWIGaZwzEGFr = 4;

	private static gudbfaHDolIOeGLfGDiSnMcgHGFv uTaGFFNbbnTiwgpkwPmhHnstCvU;

	private IntPtr ObNAIZDnCrqKLAtqkHtUcQtSiSni = IntPtr.Zero;

	private JEcNRyonjHSoBLoojFeiAcWRzqNV HQByIzQqoguPEGSeApCZNBVGIEf;

	private Action<lyjWWNFEUSvnzPXMgqNfIVDcTyv, EHIlksBYwvRxwUuMUPpiqnChUPW, uint, IntPtr> fJLFhPzOSMBwFvcJKHckewApynC;

	private byte[] aLZXiIUBDHilkUfDyGTzdzKFObGF;

	private readonly bool BkUdrPIUwGplwCKYlqooVJJDDJEj;

	private dMaLLsNfxGdarhjdsshMBcNkXbhc wtJnbfVaCKBnBFfmEcqORizUeUsf;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public gudbfaHDolIOeGLfGDiSnMcgHGFv()
	{
		if (uTaGFFNbbnTiwgpkwPmhHnstCvU != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		uTaGFFNbbnTiwgpkwPmhHnstCvU = this;
		BkUdrPIUwGplwCKYlqooVJJDDJEj = IntPtr.Size == 8;
		aLZXiIUBDHilkUfDyGTzdzKFObGF = new byte[IntPtr.Size * 3 + 4];
	}

	public void sASeLylCSRoEAmHpJVCokmAOxVh(Action<lyjWWNFEUSvnzPXMgqNfIVDcTyv, EHIlksBYwvRxwUuMUPpiqnChUPW, uint, IntPtr> P_0, bool P_1)
	{
		fJLFhPzOSMBwFvcJKHckewApynC = P_0;
		HQByIzQqoguPEGSeApCZNBVGIEf = nioFIkbhSsSCqcVenAbUAfsGbpIl;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		ObNAIZDnCrqKLAtqkHtUcQtSiSni = BHRgBdCdafkzKipZjQZdqGhsVHGc(4, HQByIzQqoguPEGSeApCZNBVGIEf, IntPtr.Zero, num);
		if (ObNAIZDnCrqKLAtqkHtUcQtSiSni == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void frBvaUxHJJKnyhFnbqhmIdSCXli()
	{
		if (!(ObNAIZDnCrqKLAtqkHtUcQtSiSni == IntPtr.Zero))
		{
			if (!UdouKTZHkQZvDmqywYswSykNUPa(ObNAIZDnCrqKLAtqkHtUcQtSiSni))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				ObNAIZDnCrqKLAtqkHtUcQtSiSni = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(JEcNRyonjHSoBLoojFeiAcWRzqNV))]
	private static IntPtr nioFIkbhSsSCqcVenAbUAfsGbpIl(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, 0, uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF.Length);
		int num = 0;
		uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.QMymFPDgflaolCygguUbfrKiWpi = lyjWWNFEUSvnzPXMgqNfIVDcTyv.XKnIdqweJtJnkdixUOPtfzefctU(uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, num);
		num += lyjWWNFEUSvnzPXMgqNfIVDcTyv.tnjnnszAeVgbCefqvSkKimCiVDd;
		uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.LFzugOzqQkdrWkNByPrQpPRKVhl = EHIlksBYwvRxwUuMUPpiqnChUPW.XKnIdqweJtJnkdixUOPtfzefctU(uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, num);
		num += EHIlksBYwvRxwUuMUPpiqnChUPW.tnjnnszAeVgbCefqvSkKimCiVDd;
		uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.RcjcoDCvgnimiBTmwEwFjlBmgfcZ = BitConverter.ToUInt32(uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, num);
		num += 4;
		if (uTaGFFNbbnTiwgpkwPmhHnstCvU.BkUdrPIUwGplwCKYlqooVJJDDJEj)
		{
			uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.rSXoAyjNbABtqBCVvNSGbJqJwRri = new IntPtr(BitConverter.ToInt32(uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, num + 4));
		}
		else
		{
			uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.rSXoAyjNbABtqBCVvNSGbJqJwRri = new IntPtr(BitConverter.ToInt32(uTaGFFNbbnTiwgpkwPmhHnstCvU.aLZXiIUBDHilkUfDyGTzdzKFObGF, num));
		}
		if (P_0 >= 0)
		{
			uTaGFFNbbnTiwgpkwPmhHnstCvU.fJLFhPzOSMBwFvcJKHckewApynC(uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.QMymFPDgflaolCygguUbfrKiWpi, uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.LFzugOzqQkdrWkNByPrQpPRKVhl, uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.RcjcoDCvgnimiBTmwEwFjlBmgfcZ, uTaGFFNbbnTiwgpkwPmhHnstCvU.wtJnbfVaCKBnBFfmEcqORizUeUsf.rSXoAyjNbABtqBCVvNSGbJqJwRri);
		}
		return hCDsMoDhPTuAXtuTbmjQajCuKza(uTaGFFNbbnTiwgpkwPmhHnstCvU.ObNAIZDnCrqKLAtqkHtUcQtSiSni, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~gudbfaHDolIOeGLfGDiSnMcgHGFv()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			frBvaUxHJJKnyhFnbqhmIdSCXli();
			if (uTaGFFNbbnTiwgpkwPmhHnstCvU == this)
			{
				uTaGFFNbbnTiwgpkwPmhHnstCvU = null;
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr BHRgBdCdafkzKipZjQZdqGhsVHGc(int P_0, JEcNRyonjHSoBLoojFeiAcWRzqNV P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool UdouKTZHkQZvDmqywYswSykNUPa(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr hCDsMoDhPTuAXtuTbmjQajCuKza(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
