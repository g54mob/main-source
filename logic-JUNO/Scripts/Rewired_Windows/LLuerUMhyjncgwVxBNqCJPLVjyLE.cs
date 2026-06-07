using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class LLuerUMhyjncgwVxBNqCJPLVjyLE<_0001>
{
	private enum CPneOjZTkPCIMfRGijNCzEjQeFacA
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class CkfYVQvxdtJbmGcDWPePgLNgdfpJ
	{
		private class AQetxbPoEGEjrKFTgmhkEgElaBZZ : IDisposable
		{
			private sealed class KtjbZHxOOICZWbGkOWadMyqSkeYjA
			{
				public AQetxbPoEGEjrKFTgmhkEgElaBZZ AUHYeZCONSkrbKoaMejriDusZjIw;

				public ManualResetEvent uVcFLMBPxyRfYZuEDAVckEJLIlZP;

				internal void qxhnegJPYvJFQksOjqbIkOAqwhLe()
				{
					uVcFLMBPxyRfYZuEDAVckEJLIlZP.Set();
					AUHYeZCONSkrbKoaMejriDusZjIw.EqAGKIFjnIZYzDLaHOIXecUPbroo();
				}
			}

			private readonly object aQPClYHUOTzjOterkyMUSRZJmjDs;

			private List<WaitCallback> lzCCXHFWiuWYXQkIJGYKahaUSaKSA;

			private List<WaitCallback> mBVaeDhHHedDCLfPeYHfgneEFBdH;

			private Thread meSFNseRqVBCMtBGuvncdgBYkdmnA;

			private AutoResetEvent amHBeHctfNLiXyuYZQrSjCcWdJsA;

			private bool HjHMQJubaWUaPefEOoTUdILIQUqI;

			private bool zXseIXBBPsFiTZTiCNhoDJWFloHzA;

			private bool OoFcYaBeSuNMLZWYoHIuVhqRjoGI;

			private bool EPrDeqVLmGxjGjUgpcIElioxfsko;

			public AQetxbPoEGEjrKFTgmhkEgElaBZZ()
			{
				aQPClYHUOTzjOterkyMUSRZJmjDs = new object();
				lzCCXHFWiuWYXQkIJGYKahaUSaKSA = new List<WaitCallback>();
				mBVaeDhHHedDCLfPeYHfgneEFBdH = new List<WaitCallback>();
				amHBeHctfNLiXyuYZQrSjCcWdJsA = new AutoResetEvent(initialState: false);
			}

			public void egRsWvABzCLqJPChPhyIBZzwzOTVA(WaitCallback P_0)
			{
				if (sMRlSFPwDDBldlvRhuUgaaRWaAgJ())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (aQPClYHUOTzjOterkyMUSRZJmjDs)
					{
						lzCCXHFWiuWYXQkIJGYKahaUSaKSA.Add(P_0);
					}
					amHBeHctfNLiXyuYZQrSjCcWdJsA.Set();
				}
			}

			public void MtMjkrLrmIbvBqvAcHawdkRHZqgJ()
			{
				RdCoDnHJkJkZCPylgNalLckNOMXw();
			}

			public bool pSuAFEfQrdDTIkUwDGBDFsWeWnOJ()
			{
				return sMRlSFPwDDBldlvRhuUgaaRWaAgJ();
			}

			private bool sMRlSFPwDDBldlvRhuUgaaRWaAgJ()
			{
				if (OoFcYaBeSuNMLZWYoHIuVhqRjoGI)
				{
					return false;
				}
				if (zXseIXBBPsFiTZTiCNhoDJWFloHzA)
				{
					return false;
				}
				if (HjHMQJubaWUaPefEOoTUdILIQUqI)
				{
					return true;
				}
				if (meSFNseRqVBCMtBGuvncdgBYkdmnA != null)
				{
					return true;
				}
				return SfBbbkIwXJcWiGaUaCDRVWLUCTjyA();
			}

			private bool SfBbbkIwXJcWiGaUaCDRVWLUCTjyA()
			{
				KtjbZHxOOICZWbGkOWadMyqSkeYjA ktjbZHxOOICZWbGkOWadMyqSkeYjA = new KtjbZHxOOICZWbGkOWadMyqSkeYjA();
				ktjbZHxOOICZWbGkOWadMyqSkeYjA.AUHYeZCONSkrbKoaMejriDusZjIw = this;
				try
				{
					ktjbZHxOOICZWbGkOWadMyqSkeYjA.uVcFLMBPxyRfYZuEDAVckEJLIlZP = new ManualResetEvent(initialState: false);
					meSFNseRqVBCMtBGuvncdgBYkdmnA = new Thread(ktjbZHxOOICZWbGkOWadMyqSkeYjA.qxhnegJPYvJFQksOjqbIkOAqwhLe);
					meSFNseRqVBCMtBGuvncdgBYkdmnA.Start();
					ktjbZHxOOICZWbGkOWadMyqSkeYjA.uVcFLMBPxyRfYZuEDAVckEJLIlZP.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					meSFNseRqVBCMtBGuvncdgBYkdmnA = null;
					OoFcYaBeSuNMLZWYoHIuVhqRjoGI = true;
					return false;
				}
			}

			private void EqAGKIFjnIZYzDLaHOIXecUPbroo()
			{
				HjHMQJubaWUaPefEOoTUdILIQUqI = true;
				while (!zXseIXBBPsFiTZTiCNhoDJWFloHzA)
				{
					amHBeHctfNLiXyuYZQrSjCcWdJsA.WaitOne();
					if (zXseIXBBPsFiTZTiCNhoDJWFloHzA)
					{
						break;
					}
					lock (aQPClYHUOTzjOterkyMUSRZJmjDs)
					{
						MiscTools.Swap(ref lzCCXHFWiuWYXQkIJGYKahaUSaKSA, ref mBVaeDhHHedDCLfPeYHfgneEFBdH);
					}
					List<WaitCallback> list = mBVaeDhHHedDCLfPeYHfgneEFBdH;
					int count = list.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							list[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					list.Clear();
				}
				lock (aQPClYHUOTzjOterkyMUSRZJmjDs)
				{
					lzCCXHFWiuWYXQkIJGYKahaUSaKSA.Clear();
					mBVaeDhHHedDCLfPeYHfgneEFBdH.Clear();
				}
				zXseIXBBPsFiTZTiCNhoDJWFloHzA = false;
				HjHMQJubaWUaPefEOoTUdILIQUqI = false;
			}

			private void XlWFqijAOzHrGZdWLXzCzpIhHalO()
			{
				meSFNseRqVBCMtBGuvncdgBYkdmnA = null;
				OoFcYaBeSuNMLZWYoHIuVhqRjoGI = false;
				zXseIXBBPsFiTZTiCNhoDJWFloHzA = true;
			}

			private void RdCoDnHJkJkZCPylgNalLckNOMXw()
			{
				XlWFqijAOzHrGZdWLXzCzpIhHalO();
				try
				{
					amHBeHctfNLiXyuYZQrSjCcWdJsA.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				mDiIlZCakIesQRoeuXRlueCjuxCu(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void whwAcIfWrXPoFyNGaVLrDTXLQNRb()
			{
				try
				{
					mDiIlZCakIesQRoeuXRlueCjuxCu(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void mDiIlZCakIesQRoeuXRlueCjuxCu(bool P_0)
			{
				if (!EPrDeqVLmGxjGjUgpcIElioxfsko)
				{
					RdCoDnHJkJkZCPylgNalLckNOMXw();
					EPrDeqVLmGxjGjUgpcIElioxfsko = true;
				}
			}
		}

		private static CkfYVQvxdtJbmGcDWPePgLNgdfpJ dDdbEnlEcCKsxyDvjRWuiOjTLNyQ;

		private AQetxbPoEGEjrKFTgmhkEgElaBZZ eJBjwXCFqrGSqZMefuzCOostKJhh;

		private int wvBNCdPBejyCzeXBQHFTxEdSCPGcA;

		private bool pWbENZbFiqsKoNyvQqVwpApMJvOSA;

		private static CkfYVQvxdtJbmGcDWPePgLNgdfpJ MKfiNEdETIIOxgIvkfLlGluBMNVgb => dDdbEnlEcCKsxyDvjRWuiOjTLNyQ ?? new CkfYVQvxdtJbmGcDWPePgLNgdfpJ();

		private AQetxbPoEGEjrKFTgmhkEgElaBZZ iGHHlQhjnJTCkFdimyDksqWJWNRn => eJBjwXCFqrGSqZMefuzCOostKJhh ?? (eJBjwXCFqrGSqZMefuzCOostKJhh = new AQetxbPoEGEjrKFTgmhkEgElaBZZ());

		private CkfYVQvxdtJbmGcDWPePgLNgdfpJ()
		{
			dDdbEnlEcCKsxyDvjRWuiOjTLNyQ?.AYfeOejFOkqSLItcXlXlQWxkVHoSA();
			dDdbEnlEcCKsxyDvjRWuiOjTLNyQ = this;
		}

		private void XRlfNPmKzacBmQSDTDEDXnbWEPikA()
		{
			wvBNCdPBejyCzeXBQHFTxEdSCPGcA++;
		}

		private void UmWFRIPVETfgDuJZhiCMKUPumWCt()
		{
			wvBNCdPBejyCzeXBQHFTxEdSCPGcA--;
			if (wvBNCdPBejyCzeXBQHFTxEdSCPGcA < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (wvBNCdPBejyCzeXBQHFTxEdSCPGcA == 0)
			{
				AYfeOejFOkqSLItcXlXlQWxkVHoSA();
			}
		}

		private void cCTtERhNxQdttfYaoLzlPMlKcMhy(WaitCallback P_0)
		{
			iGHHlQhjnJTCkFdimyDksqWJWNRn.egRsWvABzCLqJPChPhyIBZzwzOTVA(P_0);
		}

		private void eGRpLqralBQscKRINhWIGKEQkuxnA()
		{
			iGHHlQhjnJTCkFdimyDksqWJWNRn.MtMjkrLrmIbvBqvAcHawdkRHZqgJ();
		}

		private bool hPFcxjjDepjVMzVrzEGiNsNUDKOB()
		{
			return iGHHlQhjnJTCkFdimyDksqWJWNRn.pSuAFEfQrdDTIkUwDGBDFsWeWnOJ();
		}

		private void AYfeOejFOkqSLItcXlXlQWxkVHoSA()
		{
			ObrjtJojKfHexCQYgnWMdSbTTCoCA(true);
			GC.SuppressFinalize(this);
		}

		protected void QIOcNPHZkrjhARigJTriacEynKQA()
		{
			try
			{
				ObrjtJojKfHexCQYgnWMdSbTTCoCA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void ObrjtJojKfHexCQYgnWMdSbTTCoCA(bool P_0)
		{
			if (!pWbENZbFiqsKoNyvQqVwpApMJvOSA)
			{
				if (P_0 && eJBjwXCFqrGSqZMefuzCOostKJhh != null)
				{
					eJBjwXCFqrGSqZMefuzCOostKJhh.Dispose();
					eJBjwXCFqrGSqZMefuzCOostKJhh = null;
				}
				wvBNCdPBejyCzeXBQHFTxEdSCPGcA = 0;
				if (dDdbEnlEcCKsxyDvjRWuiOjTLNyQ == this)
				{
					dDdbEnlEcCKsxyDvjRWuiOjTLNyQ = null;
				}
				pWbENZbFiqsKoNyvQqVwpApMJvOSA = true;
			}
		}

		public static void ACSPOFrrFysdvWCeVXFpJFEGcVdiA()
		{
			MKfiNEdETIIOxgIvkfLlGluBMNVgb.XRlfNPmKzacBmQSDTDEDXnbWEPikA();
		}

		public static void WGrXLZXCXCFMNqmLdwMWdUZmrTir()
		{
			dDdbEnlEcCKsxyDvjRWuiOjTLNyQ?.UmWFRIPVETfgDuJZhiCMKUPumWCt();
		}

		public static void KMZCJgaJBkzDyfJsOPfFdaGrxtBnA(WaitCallback P_0)
		{
			MKfiNEdETIIOxgIvkfLlGluBMNVgb.cCTtERhNxQdttfYaoLzlPMlKcMhy(P_0);
		}
	}

	private CPneOjZTkPCIMfRGijNCzEjQeFacA nkecczxLfwxDefBWgbYdpxSXoqxM;

	private _0001 mssxMloEMOOCZemwNaIDaKDHnWbdA;

	private WaitCallback pBstQEzEnTfziLtmqAmMutHXBSYAA;

	private object wNVuDtvslycliiYjGeaUjaMfDNQE;

	private Func<_0001> RGMYYOtHhzoMsCnnVXDoOeiUgZCc;

	private bool tezrLuVEBdQxzXcbiaucsYBCkcPW;

	private bool DAMglkkSoilVHwEMRBFaBrJqCzxT;

	public bool snsDQUpOcRaGRKbTkYpwRvywuGYh
	{
		get
		{
			if (nkecczxLfwxDefBWgbYdpxSXoqxM != CPneOjZTkPCIMfRGijNCzEjQeFacA.AwaitingResult)
			{
				return nkecczxLfwxDefBWgbYdpxSXoqxM == CPneOjZTkPCIMfRGijNCzEjQeFacA.ResultReceived;
			}
			return true;
		}
	}

	public _0001 adAzQMLivFAMfDeoAKPmjfzQvGQr => mssxMloEMOOCZemwNaIDaKDHnWbdA;

	public bool iuGaMmcGKafyNfJkNqVWhILJWPAm()
	{
		bool num = nkecczxLfwxDefBWgbYdpxSXoqxM == CPneOjZTkPCIMfRGijNCzEjQeFacA.ResultReceived;
		if (num)
		{
			nkecczxLfwxDefBWgbYdpxSXoqxM = CPneOjZTkPCIMfRGijNCzEjQeFacA.Idle;
		}
		return num;
	}

	public LLuerUMhyjncgwVxBNqCJPLVjyLE(bool P_0, Func<_0001> P_1)
	{
		tezrLuVEBdQxzXcbiaucsYBCkcPW = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		RGMYYOtHhzoMsCnnVXDoOeiUgZCc = P_1;
		pBstQEzEnTfziLtmqAmMutHXBSYAA = rdoqBhTqqwRdZhdVcMIJuljIiReBA;
		wNVuDtvslycliiYjGeaUjaMfDNQE = new object();
		nkecczxLfwxDefBWgbYdpxSXoqxM = CPneOjZTkPCIMfRGijNCzEjQeFacA.Idle;
		if (P_0)
		{
			CkfYVQvxdtJbmGcDWPePgLNgdfpJ.ACSPOFrrFysdvWCeVXFpJFEGcVdiA();
		}
	}

	public bool SgOnxhdhoJMkOXBTPqeBcreyDTgn()
	{
		lock (wNVuDtvslycliiYjGeaUjaMfDNQE)
		{
			if (nkecczxLfwxDefBWgbYdpxSXoqxM == CPneOjZTkPCIMfRGijNCzEjQeFacA.AwaitingResult)
			{
				return false;
			}
			mssxMloEMOOCZemwNaIDaKDHnWbdA = default(_0001);
			nkecczxLfwxDefBWgbYdpxSXoqxM = CPneOjZTkPCIMfRGijNCzEjQeFacA.AwaitingResult;
		}
		if (tezrLuVEBdQxzXcbiaucsYBCkcPW)
		{
			CkfYVQvxdtJbmGcDWPePgLNgdfpJ.KMZCJgaJBkzDyfJsOPfFdaGrxtBnA(pBstQEzEnTfziLtmqAmMutHXBSYAA);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(pBstQEzEnTfziLtmqAmMutHXBSYAA, this);
		}
		return true;
	}

	public void gmaIrfraLSFEAKpuADuceEGDgZoWb()
	{
		lock (wNVuDtvslycliiYjGeaUjaMfDNQE)
		{
			mssxMloEMOOCZemwNaIDaKDHnWbdA = default(_0001);
			nkecczxLfwxDefBWgbYdpxSXoqxM = CPneOjZTkPCIMfRGijNCzEjQeFacA.Idle;
		}
	}

	private void rdoqBhTqqwRdZhdVcMIJuljIiReBA(object P_0)
	{
		lock (wNVuDtvslycliiYjGeaUjaMfDNQE)
		{
			if (nkecczxLfwxDefBWgbYdpxSXoqxM == CPneOjZTkPCIMfRGijNCzEjQeFacA.AwaitingResult)
			{
				mssxMloEMOOCZemwNaIDaKDHnWbdA = RGMYYOtHhzoMsCnnVXDoOeiUgZCc();
				nkecczxLfwxDefBWgbYdpxSXoqxM = CPneOjZTkPCIMfRGijNCzEjQeFacA.ResultReceived;
			}
		}
	}

	public void bkHmwKfdIczaMGhYiGtzFjzCYJlw()
	{
		iOLCsEmQuyZOdpMVTgvNzfRPhBiP(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void SBwMeESuwehaWiuktlRRfQScbQIJ()
	{
		try
		{
			iOLCsEmQuyZOdpMVTgvNzfRPhBiP(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void iOLCsEmQuyZOdpMVTgvNzfRPhBiP(bool P_0)
	{
		if (!DAMglkkSoilVHwEMRBFaBrJqCzxT)
		{
			if (P_0)
			{
				gmaIrfraLSFEAKpuADuceEGDgZoWb();
			}
			if (tezrLuVEBdQxzXcbiaucsYBCkcPW)
			{
				CkfYVQvxdtJbmGcDWPePgLNgdfpJ.WGrXLZXCXCFMNqmLdwMWdUZmrTir();
			}
			DAMglkkSoilVHwEMRBFaBrJqCzxT = true;
		}
	}
}
