using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class KXJXXXnDQjGQPAAMFoiVBLpsQMRWA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr hLhLJiBlZhIuaNeutHLyHqSbbjPiA(int nCode, IntPtr wParam, IntPtr lParam);

	private struct CUuoCdeORFBwwfWiAuHBmHzRpnqQ
	{
		public IntPtr idGMDkxPSlysCDLVscbqgVqDAMmC;

		public IntPtr zPNfArFXkkDvlbtsIelRmqUCvxllc;

		public uint nSRwGgqaQtokTIuPcRaWaoCXfbqKA;

		public IntPtr BbzHkHTDPIgjZeXavHITtGjVBPphb;
	}

	private const int uMIyXvtutQnjurvNUMIBOdzfsAVN = 4;

	private static KXJXXXnDQjGQPAAMFoiVBLpsQMRWA KYSmpmrTPxcxTjdZegwsSZlOlbOU;

	private IntPtr qxjBeqjPsljGofcFCHvFzPkEHUtjc = IntPtr.Zero;

	private hLhLJiBlZhIuaNeutHLyHqSbbjPiA dnbckGakYuxXjdVTWFGOHMMxuQtEb;

	private Action<TOLamCvimGvMrUyTkkygLOrPZdpB, cQgVBZlYElNaPNVdQLmdvIVQeESs, uint, IntPtr> BbhfluLguGLVocTpKVCljhCKcGCg;

	private byte[] EpdpgjgZrJbrRFAmaRsssVZefbYL;

	private readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	private CUuoCdeORFBwwfWiAuHBmHzRpnqQ EchLRUzCmEGxmduDYpaJazyevWugB;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public KXJXXXnDQjGQPAAMFoiVBLpsQMRWA()
	{
		if (KYSmpmrTPxcxTjdZegwsSZlOlbOU != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		KYSmpmrTPxcxTjdZegwsSZlOlbOU = this;
		vEcTZgibGOhMRTarrIojYoSggTYM = IntPtr.Size == 8;
		EpdpgjgZrJbrRFAmaRsssVZefbYL = new byte[IntPtr.Size * 3 + 4];
	}

	public void CewYRNFeLZahFxSUTTlHnZubdlxB(Action<TOLamCvimGvMrUyTkkygLOrPZdpB, cQgVBZlYElNaPNVdQLmdvIVQeESs, uint, IntPtr> P_0, bool P_1)
	{
		BbhfluLguGLVocTpKVCljhCKcGCg = P_0;
		dnbckGakYuxXjdVTWFGOHMMxuQtEb = TqSWuZHmogdATAARzFtREkvGGbKfb;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		qxjBeqjPsljGofcFCHvFzPkEHUtjc = rkxUtCVFSlqznwrihhFaBssVOPMs(4, dnbckGakYuxXjdVTWFGOHMMxuQtEb, IntPtr.Zero, num);
		if (qxjBeqjPsljGofcFCHvFzPkEHUtjc == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void TjvgUpcHnLAfNugOvdfpqXRnYboQA()
	{
		if (!(qxjBeqjPsljGofcFCHvFzPkEHUtjc == IntPtr.Zero))
		{
			if (!svGSytvrsAVUSfHmqIbvPHtkOrRj(qxjBeqjPsljGofcFCHvFzPkEHUtjc))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				qxjBeqjPsljGofcFCHvFzPkEHUtjc = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(hLhLJiBlZhIuaNeutHLyHqSbbjPiA))]
	private static IntPtr TqSWuZHmogdATAARzFtREkvGGbKfb(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, 0, KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL.Length);
		int num = 0;
		KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.idGMDkxPSlysCDLVscbqgVqDAMmC = TOLamCvimGvMrUyTkkygLOrPZdpB.hWHeOZGaMchoUxcjVNFKgCLOCcPd(TOLamCvimGvMrUyTkkygLOrPZdpB.pgVkRSYnyhTBzyKtKQklgjDSiBYd(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, num));
		num += TOLamCvimGvMrUyTkkygLOrPZdpB.FfDDSSPkoVyXSlRGlShrtpjBTkxH;
		KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.zPNfArFXkkDvlbtsIelRmqUCvxllc = cQgVBZlYElNaPNVdQLmdvIVQeESs.hWHeOZGaMchoUxcjVNFKgCLOCcPd(cQgVBZlYElNaPNVdQLmdvIVQeESs.pgVkRSYnyhTBzyKtKQklgjDSiBYd(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, num));
		num += cQgVBZlYElNaPNVdQLmdvIVQeESs.FfDDSSPkoVyXSlRGlShrtpjBTkxH;
		KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.nSRwGgqaQtokTIuPcRaWaoCXfbqKA = BitConverter.ToUInt32(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, num);
		num += 4;
		if (KYSmpmrTPxcxTjdZegwsSZlOlbOU.vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.BbzHkHTDPIgjZeXavHITtGjVBPphb = new IntPtr(BitConverter.ToInt32(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, num + 4));
		}
		else
		{
			KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.BbzHkHTDPIgjZeXavHITtGjVBPphb = new IntPtr(BitConverter.ToInt32(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EpdpgjgZrJbrRFAmaRsssVZefbYL, num));
		}
		if (P_0 >= 0)
		{
			KYSmpmrTPxcxTjdZegwsSZlOlbOU.BbhfluLguGLVocTpKVCljhCKcGCg(TOLamCvimGvMrUyTkkygLOrPZdpB.hWHeOZGaMchoUxcjVNFKgCLOCcPd(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.idGMDkxPSlysCDLVscbqgVqDAMmC), cQgVBZlYElNaPNVdQLmdvIVQeESs.hWHeOZGaMchoUxcjVNFKgCLOCcPd(KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.zPNfArFXkkDvlbtsIelRmqUCvxllc), KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.nSRwGgqaQtokTIuPcRaWaoCXfbqKA, KYSmpmrTPxcxTjdZegwsSZlOlbOU.EchLRUzCmEGxmduDYpaJazyevWugB.BbzHkHTDPIgjZeXavHITtGjVBPphb);
		}
		return JLhGHNrNPBsrkgZtfwIZdTeFUIcE(KYSmpmrTPxcxTjdZegwsSZlOlbOU.qxjBeqjPsljGofcFCHvFzPkEHUtjc, P_0, P_1, P_2);
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
			if (KYSmpmrTPxcxTjdZegwsSZlOlbOU == this)
			{
				KYSmpmrTPxcxTjdZegwsSZlOlbOU = null;
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr rkxUtCVFSlqznwrihhFaBssVOPMs(int P_0, hLhLJiBlZhIuaNeutHLyHqSbbjPiA P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool svGSytvrsAVUSfHmqIbvPHtkOrRj(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr JLhGHNrNPBsrkgZtfwIZdTeFUIcE(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}
