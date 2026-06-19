using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Platforms;

internal class ilPVKwtdBpFeAVdxGdhaHfCOnenL : IDisposable, kmGJLhBGczepFRhbjHJJQHSaXgZ
{
	private static class DCfruwvmuQFSbGqFCimmvHaRWzK
	{
		private struct wktoYfCnmLPtEQtSabNFqVbCDtC
		{
			internal int MSHCgcyCMthFnRTIrchleRuEuVD;

			internal int iRDBaPEVaieckXkarvDPeiJZftGD;

			internal int vIJARJgljIoebHuPYkRuNPuGqJpx;

			internal Guid QiLCbYxoAzVtyvefbxqUNuKvKbc;

			internal short riVgOMKRfcmnDvgPBFvqnRIvZXZS;
		}

		private const int cPnvvIBdPHHrWGDPUtfpKeocNBad = 5;

		private const int UudUWyauWlncTxhHzVOkvpYWpPw = 0;

		private static readonly Guid DOFHttizHvQToguwcOiDmJiOIuN = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");

		private static IntPtr sSTGLlhnBhwtOmnVTRFGqloSrcx;

		private static bool AakFmsWtyOJJTGNcgQaQElovbci;

		public static void iOvWUWNWFmcwjhgsIMRNyXlphSO(IntPtr P_0)
		{
			wktoYfCnmLPtEQtSabNFqVbCDtC wktoYfCnmLPtEQtSabNFqVbCDtC2 = new wktoYfCnmLPtEQtSabNFqVbCDtC
			{
				iRDBaPEVaieckXkarvDPeiJZftGD = 5,
				vIJARJgljIoebHuPYkRuNPuGqJpx = 0,
				QiLCbYxoAzVtyvefbxqUNuKvKbc = DOFHttizHvQToguwcOiDmJiOIuN,
				riVgOMKRfcmnDvgPBFvqnRIvZXZS = 0
			};
			wktoYfCnmLPtEQtSabNFqVbCDtC2.MSHCgcyCMthFnRTIrchleRuEuVD = Marshal.SizeOf((object)wktoYfCnmLPtEQtSabNFqVbCDtC2);
			IntPtr intPtr = Marshal.AllocHGlobal(wktoYfCnmLPtEQtSabNFqVbCDtC2.MSHCgcyCMthFnRTIrchleRuEuVD);
			Marshal.StructureToPtr((object)wktoYfCnmLPtEQtSabNFqVbCDtC2, intPtr, true);
			sSTGLlhnBhwtOmnVTRFGqloSrcx = oddmOXIfLCVgQipwwOIjrKWNKMM(P_0, intPtr, 0);
			AakFmsWtyOJJTGNcgQaQElovbci = true;
		}

		public static void OuTrJouWnnbrDnFPQBBwdRLCchPR()
		{
			if (!(sSTGLlhnBhwtOmnVTRFGqloSrcx == IntPtr.Zero))
			{
				CtfsCegrHnTLPhGDKDyaMCtgijB(sSTGLlhnBhwtOmnVTRFGqloSrcx);
				AakFmsWtyOJJTGNcgQaQElovbci = false;
			}
		}

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "RegisterDeviceNotification", SetLastError = true)]
		private static extern IntPtr oddmOXIfLCVgQipwwOIjrKWNKMM(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnregisterDeviceNotification")]
		private static extern bool CtfsCegrHnTLPhGDKDyaMCtgijB(IntPtr P_0);
	}

	private const int nuQnUHLEpQgCHYrEfeBdzyKhhnD = 32771;

	private const int DJGAyNEfoqjThWgqMAJHkyaPJtp = 32772;

	private const int NlBEYiviJlWWCWOmNUEumpDBzlY = 32768;

	private const int ovMFiHZWYVemYOVNATZTUjWiemZ = 7;

	private const int apjYLNFEyEyShNewodtUEatlQGBL = 537;

	private const int WdyciRmFqTmetUxouxHYRArzkqA = 255;

	private Action<EventArgs> kpURPkxIkOwVHfamkZvWTlWemUQ;

	private Action<EventArgs> QfIIBRqaNAFNaiBeuUHLheFXurE;

	private Action<EventArgs> GefqGEvZVBfZiKGmvJLHmrBNpUT;

	private Action<EHIlksBYwvRxwUuMUPpiqnChUPW, NgzvGfQDisRTGMKXwIDhsRJTBuE> bXeWNCHtjGmBUWJgtOBPkKaKlcs;

	private IntPtr IFBXTUdMronKokXvgTMPrqZoEHX;

	private gudbfaHDolIOeGLfGDiSnMcgHGFv NdAqwXkWSPAOFdJLuXuISnLTYwv;

	private readonly bool DRXLJKNLPKWCwOywJSdSXWvcaxm;

	private static edTUHywUTXJFvcLrQjKxoJZxDUQ AJGntpdmfNcfICPBruLxMnoaQxl;

	private gudbfaHDolIOeGLfGDiSnMcgHGFv MwCtAuFpDcPibZObAzjfACTletX;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public IntPtr windowHandle => IFBXTUdMronKokXvgTMPrqZoEHX;

	public event Action<EventArgs> DeviceConnectedEvent
	{
		add
		{
			kpURPkxIkOwVHfamkZvWTlWemUQ = (Action<EventArgs>)Delegate.Combine(kpURPkxIkOwVHfamkZvWTlWemUQ, value);
		}
		remove
		{
			kpURPkxIkOwVHfamkZvWTlWemUQ = (Action<EventArgs>)Delegate.Remove(kpURPkxIkOwVHfamkZvWTlWemUQ, value);
		}
	}

	public event Action<EventArgs> DeviceDisconnectedEvent
	{
		add
		{
			QfIIBRqaNAFNaiBeuUHLheFXurE = (Action<EventArgs>)Delegate.Combine(QfIIBRqaNAFNaiBeuUHLheFXurE, value);
		}
		remove
		{
			QfIIBRqaNAFNaiBeuUHLheFXurE = (Action<EventArgs>)Delegate.Remove(QfIIBRqaNAFNaiBeuUHLheFXurE, value);
		}
	}

	public event Action<EventArgs> DeviceDisconnectPendingEvent
	{
		add
		{
			GefqGEvZVBfZiKGmvJLHmrBNpUT = (Action<EventArgs>)Delegate.Combine(GefqGEvZVBfZiKGmvJLHmrBNpUT, value);
		}
		remove
		{
			GefqGEvZVBfZiKGmvJLHmrBNpUT = (Action<EventArgs>)Delegate.Remove(GefqGEvZVBfZiKGmvJLHmrBNpUT, value);
		}
	}

	public event Action<EHIlksBYwvRxwUuMUPpiqnChUPW, NgzvGfQDisRTGMKXwIDhsRJTBuE> WindowFocusEvent
	{
		add
		{
			bXeWNCHtjGmBUWJgtOBPkKaKlcs = (Action<EHIlksBYwvRxwUuMUPpiqnChUPW, NgzvGfQDisRTGMKXwIDhsRJTBuE>)Delegate.Combine(bXeWNCHtjGmBUWJgtOBPkKaKlcs, value);
		}
		remove
		{
			bXeWNCHtjGmBUWJgtOBPkKaKlcs = (Action<EHIlksBYwvRxwUuMUPpiqnChUPW, NgzvGfQDisRTGMKXwIDhsRJTBuE>)Delegate.Remove(bXeWNCHtjGmBUWJgtOBPkKaKlcs, value);
		}
	}

	public ilPVKwtdBpFeAVdxGdhaHfCOnenL()
	{
		DRXLJKNLPKWCwOywJSdSXWvcaxm = ReInput.editorPlatform != EditorPlatform.None;
		try
		{
			EhDmNHbdNOhARNgJSMpMFgeqbsn();
		}
		catch
		{
			uQPqBISkswrGhilfkcaiZENHGmw();
			throw;
		}
	}

	public void uQPqBISkswrGhilfkcaiZENHGmw()
	{
		Dispose();
	}

	void kmGJLhBGczepFRhbjHJJQHSaXgZ.uQPqBISkswrGhilfkcaiZENHGmw()
	{
		//ILSpy generated this explicit interface implementation from .override directive in uQPqBISkswrGhilfkcaiZENHGmw
		this.uQPqBISkswrGhilfkcaiZENHGmw();
	}

	private void EhDmNHbdNOhARNgJSMpMFgeqbsn()
	{
		vqybFVVzaNsCWuTMtOMoOxoNMdU();
		iOvWUWNWFmcwjhgsIMRNyXlphSO();
		if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			MwCtAuFpDcPibZObAzjfACTletX = new gudbfaHDolIOeGLfGDiSnMcgHGFv();
			MwCtAuFpDcPibZObAzjfACTletX.sASeLylCSRoEAmHpJVCokmAOxVh(DvTXRPDHIrTIWFLkxIcoJieOkjke, true);
		}
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~ilPVKwtdBpFeAVdxGdhaHfCOnenL()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	private void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return;
		}
		if (DRXLJKNLPKWCwOywJSdSXWvcaxm)
		{
			OuTrJouWnnbrDnFPQBBwdRLCchPR();
			if (MwCtAuFpDcPibZObAzjfACTletX != null)
			{
				MwCtAuFpDcPibZObAzjfACTletX.Dispose();
			}
			if (AJGntpdmfNcfICPBruLxMnoaQxl != null)
			{
				AJGntpdmfNcfICPBruLxMnoaQxl.Dispose();
				AJGntpdmfNcfICPBruLxMnoaQxl = null;
			}
		}
		else
		{
			OuTrJouWnnbrDnFPQBBwdRLCchPR();
			if (NdAqwXkWSPAOFdJLuXuISnLTYwv != null)
			{
				NdAqwXkWSPAOFdJLuXuISnLTYwv.Dispose();
			}
		}
		dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
	}

	private void iOvWUWNWFmcwjhgsIMRNyXlphSO()
	{
		DCfruwvmuQFSbGqFCimmvHaRWzK.iOvWUWNWFmcwjhgsIMRNyXlphSO(IFBXTUdMronKokXvgTMPrqZoEHX);
	}

	private void OuTrJouWnnbrDnFPQBBwdRLCchPR()
	{
		DCfruwvmuQFSbGqFCimmvHaRWzK.OuTrJouWnnbrDnFPQBBwdRLCchPR();
	}

	private void xDTobxuSifAlSUAJWeFnMjgfqbl(lyjWWNFEUSvnzPXMgqNfIVDcTyv P_0, EHIlksBYwvRxwUuMUPpiqnChUPW P_1, uint P_2, IntPtr P_3)
	{
		switch (P_2)
		{
		case 537u:
		{
			int num = P_1.GumyXgoXjWccYPgLapqAZFRTzQs();
			if (P_3 == IFBXTUdMronKokXvgTMPrqZoEHX)
			{
				switch (num)
				{
				case 32768:
					kpURPkxIkOwVHfamkZvWTlWemUQ?.Invoke(null);
					break;
				case 32772:
					QfIIBRqaNAFNaiBeuUHLheFXurE?.Invoke(null);
					break;
				case 32771:
					GefqGEvZVBfZiKGmvJLHmrBNpUT?.Invoke(null);
					break;
				}
			}
			break;
		}
		case 7u:
		case 8u:
			if (bXeWNCHtjGmBUWJgtOBPkKaKlcs != null)
			{
				bXeWNCHtjGmBUWJgtOBPkKaKlcs(P_1, usQKsbAGCyboWkvovXGOmVypyoBn.TJSNwfgIBsuThpLJTnLlTwwEHsE(P_2));
			}
			break;
		}
	}

	private void DvTXRPDHIrTIWFLkxIcoJieOkjke(lyjWWNFEUSvnzPXMgqNfIVDcTyv P_0, EHIlksBYwvRxwUuMUPpiqnChUPW P_1, uint P_2, IntPtr P_3)
	{
		if (P_2 == 8 && bXeWNCHtjGmBUWJgtOBPkKaKlcs != null)
		{
			bXeWNCHtjGmBUWJgtOBPkKaKlcs(P_1, usQKsbAGCyboWkvovXGOmVypyoBn.TJSNwfgIBsuThpLJTnLlTwwEHsE(P_2));
		}
	}

	private void vqybFVVzaNsCWuTMtOMoOxoNMdU()
	{
		if (AJGntpdmfNcfICPBruLxMnoaQxl == null)
		{
			AJGntpdmfNcfICPBruLxMnoaQxl = new edTUHywUTXJFvcLrQjKxoJZxDUQ("RewiredWDMWindow", createMessageOnlyWindow: true, VwxUGsedhCyHzBHPdwTIokNAZAW);
			if (AJGntpdmfNcfICPBruLxMnoaQxl.Handle == IntPtr.Zero)
			{
				throw new Exception("Error creating window.");
			}
		}
		else
		{
			if (AJGntpdmfNcfICPBruLxMnoaQxl.Handle == IntPtr.Zero)
			{
				throw new Exception("Message window has invalid handle.");
			}
			AJGntpdmfNcfICPBruLxMnoaQxl.LzNvmTHDlLjfPnSqyouQUJetaZp(VwxUGsedhCyHzBHPdwTIokNAZAW);
		}
		IFBXTUdMronKokXvgTMPrqZoEHX = AJGntpdmfNcfICPBruLxMnoaQxl.Handle;
	}

	private IntPtr VwxUGsedhCyHzBHPdwTIokNAZAW(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		xDTobxuSifAlSUAJWeFnMjgfqbl(P_3, P_2, P_1, P_0);
		return IntPtr.Zero;
	}
}
