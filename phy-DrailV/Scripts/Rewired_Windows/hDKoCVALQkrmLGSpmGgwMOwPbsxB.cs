using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class hDKoCVALQkrmLGSpmGgwMOwPbsxB<_0001>
{
	private enum sKRoYxLQEYVMYViJVSxeeCkEHWXl
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class uCXCSDvRcaVhqoWOrWLtfMXevcCd
	{
		private class eKQdpveFiJDzlBuYHJuWCTLGhFGid : IDisposable
		{
			private sealed class qMZwNRdciHZXKgGrvSdXrRzCFarX
			{
				public eKQdpveFiJDzlBuYHJuWCTLGhFGid AtldvTEkDsEewBZFaEtbawltdqhzb;

				public ManualResetEvent npHiqMBWUchourgUnlBBqFOQLsab;

				internal void WlnqVYABoLryJPmLgeuITQNxHKoQ()
				{
					npHiqMBWUchourgUnlBBqFOQLsab.Set();
					AtldvTEkDsEewBZFaEtbawltdqhzb.ZyjZwJEXBUKAQtJAineCzZBXkEYu();
				}
			}

			private readonly object eTRoskBdTVJraCzYFXNyrUomeHqE;

			private List<WaitCallback> kVmqAPQAsLpxKMWgmKUeZBOZlXkv;

			private List<WaitCallback> eYTHxcnjnUewmRUWhtcMShHEOdbO;

			private Thread FHPpHxCnKaLGyCOhYXRXIAfPGNKw;

			private AutoResetEvent nIfnorTbolQRoaitnfwbIlptuWCN;

			private bool WpTVLlOafzkXTzTERrFAaYaIAFJt;

			private bool nzKIeLILoepmaYqnnfsmJzzGUXQy;

			private bool kzyJwPsLsVkmKXTWmgkgWYzwtUyC;

			private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

			public eKQdpveFiJDzlBuYHJuWCTLGhFGid()
			{
				eTRoskBdTVJraCzYFXNyrUomeHqE = new object();
				kVmqAPQAsLpxKMWgmKUeZBOZlXkv = new List<WaitCallback>();
				eYTHxcnjnUewmRUWhtcMShHEOdbO = new List<WaitCallback>();
				nIfnorTbolQRoaitnfwbIlptuWCN = new AutoResetEvent(initialState: false);
			}

			public void jCGbqnXVKxhiReLLhCHLTHUnoFwuA(WaitCallback P_0)
			{
				if (sXJldihOTtQuAobmFasPIcWImTtk())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
					{
						kVmqAPQAsLpxKMWgmKUeZBOZlXkv.Add(P_0);
					}
					nIfnorTbolQRoaitnfwbIlptuWCN.Set();
				}
			}

			public void gyoMWQMegzAgtBmlxsywuLqQdxfs()
			{
				RCSjdDBVcMKwXNidcbxPmEoPGWhdb();
			}

			public bool tkNcQVBWUEcZyWOdviJvJZIxFBjq()
			{
				return sXJldihOTtQuAobmFasPIcWImTtk();
			}

			private bool sXJldihOTtQuAobmFasPIcWImTtk()
			{
				if (kzyJwPsLsVkmKXTWmgkgWYzwtUyC)
				{
					return false;
				}
				if (nzKIeLILoepmaYqnnfsmJzzGUXQy)
				{
					return false;
				}
				if (WpTVLlOafzkXTzTERrFAaYaIAFJt)
				{
					return true;
				}
				if (FHPpHxCnKaLGyCOhYXRXIAfPGNKw != null)
				{
					return true;
				}
				return wGlmWkZwlGzQrRfNTDihqBhEVdjg();
			}

			private bool wGlmWkZwlGzQrRfNTDihqBhEVdjg()
			{
				qMZwNRdciHZXKgGrvSdXrRzCFarX qMZwNRdciHZXKgGrvSdXrRzCFarX2 = new qMZwNRdciHZXKgGrvSdXrRzCFarX();
				qMZwNRdciHZXKgGrvSdXrRzCFarX2.AtldvTEkDsEewBZFaEtbawltdqhzb = this;
				try
				{
					qMZwNRdciHZXKgGrvSdXrRzCFarX2.npHiqMBWUchourgUnlBBqFOQLsab = new ManualResetEvent(initialState: false);
					FHPpHxCnKaLGyCOhYXRXIAfPGNKw = new Thread(qMZwNRdciHZXKgGrvSdXrRzCFarX2.WlnqVYABoLryJPmLgeuITQNxHKoQ);
					FHPpHxCnKaLGyCOhYXRXIAfPGNKw.Start();
					qMZwNRdciHZXKgGrvSdXrRzCFarX2.npHiqMBWUchourgUnlBBqFOQLsab.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					FHPpHxCnKaLGyCOhYXRXIAfPGNKw = null;
					kzyJwPsLsVkmKXTWmgkgWYzwtUyC = true;
					return false;
				}
			}

			private void ZyjZwJEXBUKAQtJAineCzZBXkEYu()
			{
				WpTVLlOafzkXTzTERrFAaYaIAFJt = true;
				while (!nzKIeLILoepmaYqnnfsmJzzGUXQy)
				{
					nIfnorTbolQRoaitnfwbIlptuWCN.WaitOne();
					if (nzKIeLILoepmaYqnnfsmJzzGUXQy)
					{
						break;
					}
					lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
					{
						MiscTools.Swap(ref kVmqAPQAsLpxKMWgmKUeZBOZlXkv, ref eYTHxcnjnUewmRUWhtcMShHEOdbO);
					}
					List<WaitCallback> list = eYTHxcnjnUewmRUWhtcMShHEOdbO;
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
				lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
				{
					kVmqAPQAsLpxKMWgmKUeZBOZlXkv.Clear();
					eYTHxcnjnUewmRUWhtcMShHEOdbO.Clear();
				}
				nzKIeLILoepmaYqnnfsmJzzGUXQy = false;
				WpTVLlOafzkXTzTERrFAaYaIAFJt = false;
			}

			private void VmvuJlCdTflhRDQhqzFWapfHLlbQ()
			{
				FHPpHxCnKaLGyCOhYXRXIAfPGNKw = null;
				kzyJwPsLsVkmKXTWmgkgWYzwtUyC = false;
				nzKIeLILoepmaYqnnfsmJzzGUXQy = true;
			}

			private void RCSjdDBVcMKwXNidcbxPmEoPGWhdb()
			{
				VmvuJlCdTflhRDQhqzFWapfHLlbQ();
				try
				{
					nIfnorTbolQRoaitnfwbIlptuWCN.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
			{
				try
				{
					vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
			{
				if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
				{
					RCSjdDBVcMKwXNidcbxPmEoPGWhdb();
					JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
				}
			}
		}

		private static uCXCSDvRcaVhqoWOrWLtfMXevcCd EToGUeeDPOyHneDVvjOghKGIXvYPB;

		private eKQdpveFiJDzlBuYHJuWCTLGhFGid RJdubdxUkLMQYSwKfnHQJcPsoxKJ;

		private int cuoXDRGhUmIdqndQoJhREwIkXoQG;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		private static uCXCSDvRcaVhqoWOrWLtfMXevcCd FLjSDKyIWPhCZpjiAxtfnKHffHbK => EToGUeeDPOyHneDVvjOghKGIXvYPB ?? new uCXCSDvRcaVhqoWOrWLtfMXevcCd();

		private eKQdpveFiJDzlBuYHJuWCTLGhFGid SZoFLECUnmmJZAcOwvbWIuacVoMYA => RJdubdxUkLMQYSwKfnHQJcPsoxKJ ?? (RJdubdxUkLMQYSwKfnHQJcPsoxKJ = new eKQdpveFiJDzlBuYHJuWCTLGhFGid());

		private uCXCSDvRcaVhqoWOrWLtfMXevcCd()
		{
			EToGUeeDPOyHneDVvjOghKGIXvYPB?.vCBFvIdHsbAnKBZkroQOsRrLIAyV();
			EToGUeeDPOyHneDVvjOghKGIXvYPB = this;
		}

		private void uRoDDoDpaWZDrXjMXpozOPmgzQIO()
		{
			cuoXDRGhUmIdqndQoJhREwIkXoQG++;
		}

		private void WNqBIvJrnWYqAodjdlAjvYKvMyeEA()
		{
			cuoXDRGhUmIdqndQoJhREwIkXoQG--;
			if (cuoXDRGhUmIdqndQoJhREwIkXoQG < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (cuoXDRGhUmIdqndQoJhREwIkXoQG == 0)
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV();
			}
		}

		private void hBOyWVBooqDgimviRMQAYpFOybro(WaitCallback P_0)
		{
			SZoFLECUnmmJZAcOwvbWIuacVoMYA.jCGbqnXVKxhiReLLhCHLTHUnoFwuA(P_0);
		}

		private void ugwcOIwOvUElzGhFuluMKcvDuFXi()
		{
			SZoFLECUnmmJZAcOwvbWIuacVoMYA.gyoMWQMegzAgtBmlxsywuLqQdxfs();
		}

		private bool ALTlgjhJZEGrEIvXsAdAdadqdIac()
		{
			return SZoFLECUnmmJZAcOwvbWIuacVoMYA.tkNcQVBWUEcZyWOdviJvJZIxFBjq();
		}

		private void vCBFvIdHsbAnKBZkroQOsRrLIAyV()
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
			GC.SuppressFinalize(this);
		}

		protected void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
		{
			try
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
		{
			if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				if (P_0 && RJdubdxUkLMQYSwKfnHQJcPsoxKJ != null)
				{
					RJdubdxUkLMQYSwKfnHQJcPsoxKJ.Dispose();
					RJdubdxUkLMQYSwKfnHQJcPsoxKJ = null;
				}
				cuoXDRGhUmIdqndQoJhREwIkXoQG = 0;
				if (EToGUeeDPOyHneDVvjOghKGIXvYPB == this)
				{
					EToGUeeDPOyHneDVvjOghKGIXvYPB = null;
				}
				JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			}
		}

		public static void PPSNREbdRECmgXDNbGJdjbokEuwBA()
		{
			FLjSDKyIWPhCZpjiAxtfnKHffHbK.uRoDDoDpaWZDrXjMXpozOPmgzQIO();
		}

		public static void nYuFGEhdKppkwunIcQvFPwoHIaYMA()
		{
			EToGUeeDPOyHneDVvjOghKGIXvYPB?.WNqBIvJrnWYqAodjdlAjvYKvMyeEA();
		}

		public static void jCGbqnXVKxhiReLLhCHLTHUnoFwuA(WaitCallback P_0)
		{
			FLjSDKyIWPhCZpjiAxtfnKHffHbK.hBOyWVBooqDgimviRMQAYpFOybro(P_0);
		}
	}

	private sKRoYxLQEYVMYViJVSxeeCkEHWXl CXrtwVFanUkAxpYoKExRvUtoJrcu;

	private _0001 LFHgWIfIRZdDjQrlSzromnntPqzw;

	private WaitCallback SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	private object BpzGDRTfGRflSHRbmBgWlnkTHLSfb;

	private Func<_0001> GQcgETajScpNmHjTowtQYsIPxKilA;

	private bool hNWRFaqnvDEGSjGqRULigbmplesT;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public bool RTnbdebLTdTeohXHDoBoLyQGImfWA
	{
		get
		{
			if (CXrtwVFanUkAxpYoKExRvUtoJrcu != sKRoYxLQEYVMYViJVSxeeCkEHWXl.AwaitingResult)
			{
				return CXrtwVFanUkAxpYoKExRvUtoJrcu == sKRoYxLQEYVMYViJVSxeeCkEHWXl.ResultReceived;
			}
			return true;
		}
	}

	public _0001 uSwyJUCsSdiGPcMJmfFpIGVFqnMMA => LFHgWIfIRZdDjQrlSzromnntPqzw;

	public bool TPcqcKWeqJnMdeNkqZXytbyidUBn()
	{
		bool num = CXrtwVFanUkAxpYoKExRvUtoJrcu == sKRoYxLQEYVMYViJVSxeeCkEHWXl.ResultReceived;
		if (num)
		{
			CXrtwVFanUkAxpYoKExRvUtoJrcu = sKRoYxLQEYVMYViJVSxeeCkEHWXl.Idle;
		}
		return num;
	}

	public hDKoCVALQkrmLGSpmGgwMOwPbsxB(bool P_0, Func<_0001> P_1)
	{
		hNWRFaqnvDEGSjGqRULigbmplesT = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		GQcgETajScpNmHjTowtQYsIPxKilA = P_1;
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = YEdbfcHlEncCqTvqTikoZzFWzeAdA;
		BpzGDRTfGRflSHRbmBgWlnkTHLSfb = new object();
		CXrtwVFanUkAxpYoKExRvUtoJrcu = sKRoYxLQEYVMYViJVSxeeCkEHWXl.Idle;
		if (P_0)
		{
			uCXCSDvRcaVhqoWOrWLtfMXevcCd.PPSNREbdRECmgXDNbGJdjbokEuwBA();
		}
	}

	public bool miPFrJiYaYbOloaoCfGOcsRcMhAoc()
	{
		lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
		{
			if (CXrtwVFanUkAxpYoKExRvUtoJrcu == sKRoYxLQEYVMYViJVSxeeCkEHWXl.AwaitingResult)
			{
				return false;
			}
			LFHgWIfIRZdDjQrlSzromnntPqzw = default(_0001);
			CXrtwVFanUkAxpYoKExRvUtoJrcu = sKRoYxLQEYVMYViJVSxeeCkEHWXl.AwaitingResult;
		}
		if (hNWRFaqnvDEGSjGqRULigbmplesT)
		{
			uCXCSDvRcaVhqoWOrWLtfMXevcCd.jCGbqnXVKxhiReLLhCHLTHUnoFwuA(SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(SmCbULdHvFnyCWdLLpSYHEPsMuCV, this);
		}
		return true;
	}

	public void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
		{
			LFHgWIfIRZdDjQrlSzromnntPqzw = default(_0001);
			CXrtwVFanUkAxpYoKExRvUtoJrcu = sKRoYxLQEYVMYViJVSxeeCkEHWXl.Idle;
		}
	}

	private void YEdbfcHlEncCqTvqTikoZzFWzeAdA(object P_0)
	{
		lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
		{
			if (CXrtwVFanUkAxpYoKExRvUtoJrcu == sKRoYxLQEYVMYViJVSxeeCkEHWXl.AwaitingResult)
			{
				LFHgWIfIRZdDjQrlSzromnntPqzw = GQcgETajScpNmHjTowtQYsIPxKilA();
				CXrtwVFanUkAxpYoKExRvUtoJrcu = sKRoYxLQEYVMYViJVSxeeCkEHWXl.ResultReceived;
			}
		}
	}

	public void vCBFvIdHsbAnKBZkroQOsRrLIAyV()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			if (P_0)
			{
				DwNKXiEShimVDUzntAObjUXyaFmo();
			}
			if (hNWRFaqnvDEGSjGqRULigbmplesT)
			{
				uCXCSDvRcaVhqoWOrWLtfMXevcCd.nYuFGEhdKppkwunIcQvFPwoHIaYMA();
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
