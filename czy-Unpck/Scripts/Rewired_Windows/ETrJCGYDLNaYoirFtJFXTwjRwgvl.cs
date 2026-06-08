using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class ETrJCGYDLNaYoirFtJFXTwjRwgvl<T>
{
	private enum FpnURStQejVCfULATmNVYNgpZoD
	{
		qhpRgTSBpsOALeACGQvFkstXFKHA = 0,
		uCrJdsqjRvmcYLlpXGLpaJByYVK = 1,
		hOEDCqKPdPQjuPfureStaQOKiKih = 2
	}

	private static class bgIPcwSnuVeLjkqQUuhZKLBEnzJX
	{
		private class uVSajbFqsxGdOxtBWsIqmCdKXuGp : IDisposable
		{
			private sealed class edzajFTanQyiqKHviiqSeAszcNf
			{
				public ManualResetEvent ESIiMwBmCzsGgKonZhweWwiWoIj;

				public uVSajbFqsxGdOxtBWsIqmCdKXuGp xvYPGRaXRVZlwecANemUYNIlHnq;

				public void AhTPkbtWgmIcLutwNkwdjNmqtYM()
				{
					ESIiMwBmCzsGgKonZhweWwiWoIj.Set();
					xvYPGRaXRVZlwecANemUYNIlHnq.wcGYRPGqDrlIWMdHhKfzLiyVbHLj();
				}
			}

			private readonly object VscpWqBWzuDusblaKBCJNvlmplv;

			private List<WaitCallback> JDBoYRYwpyAUPtpchVKRvxjDGOl;

			private List<WaitCallback> TPybbyBjfxCVwOiNiHhhhskFYaec;

			private Thread irmdVrQGOFlqwdAuFYGyeAWFQiF;

			private AutoResetEvent KFWGRjFBiMlbwjBukYxOjySrbHDf;

			private bool bzydplFUvCQuLOENSPCjjUVEqYIA;

			private bool ExQGLjQuGDBsMvcoTpXALSCUULj;

			private bool BNPYZdoaDcBYqoBxhfPPkAReudI;

			private bool inweGjIgYacXYohFlYRlpMFkgKMi;

			public uVSajbFqsxGdOxtBWsIqmCdKXuGp()
			{
				VscpWqBWzuDusblaKBCJNvlmplv = new object();
				JDBoYRYwpyAUPtpchVKRvxjDGOl = new List<WaitCallback>();
				TPybbyBjfxCVwOiNiHhhhskFYaec = new List<WaitCallback>();
				KFWGRjFBiMlbwjBukYxOjySrbHDf = new AutoResetEvent(initialState: false);
			}

			public void MyxYctDTQIDmPyFGyfSmfpxlMGl(WaitCallback P_0)
			{
				if (XcqbVqdtLKNrEHBlIGziwanWbzsI())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (VscpWqBWzuDusblaKBCJNvlmplv)
					{
						JDBoYRYwpyAUPtpchVKRvxjDGOl.Add(P_0);
					}
					KFWGRjFBiMlbwjBukYxOjySrbHDf.Set();
				}
			}

			public void XQRagOICwWgBdxmesydJGWBMFuof()
			{
				gZlNqJNCmrCVNLAuvZcaeBHPiJgJ();
			}

			public bool EsoCoViNGnlmiCnejoKMpfdflIEq()
			{
				return XcqbVqdtLKNrEHBlIGziwanWbzsI();
			}

			private bool XcqbVqdtLKNrEHBlIGziwanWbzsI()
			{
				if (BNPYZdoaDcBYqoBxhfPPkAReudI)
				{
					return false;
				}
				if (ExQGLjQuGDBsMvcoTpXALSCUULj)
				{
					return false;
				}
				if (bzydplFUvCQuLOENSPCjjUVEqYIA)
				{
					return true;
				}
				if (irmdVrQGOFlqwdAuFYGyeAWFQiF != null)
				{
					return true;
				}
				try
				{
					edzajFTanQyiqKHviiqSeAszcNf edzajFTanQyiqKHviiqSeAszcNf2 = new edzajFTanQyiqKHviiqSeAszcNf();
					edzajFTanQyiqKHviiqSeAszcNf2.xvYPGRaXRVZlwecANemUYNIlHnq = this;
					edzajFTanQyiqKHviiqSeAszcNf2.ESIiMwBmCzsGgKonZhweWwiWoIj = new ManualResetEvent(initialState: false);
					irmdVrQGOFlqwdAuFYGyeAWFQiF = new Thread(edzajFTanQyiqKHviiqSeAszcNf2.AhTPkbtWgmIcLutwNkwdjNmqtYM);
					irmdVrQGOFlqwdAuFYGyeAWFQiF.Start();
					edzajFTanQyiqKHviiqSeAszcNf2.ESIiMwBmCzsGgKonZhweWwiWoIj.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					irmdVrQGOFlqwdAuFYGyeAWFQiF = null;
					BNPYZdoaDcBYqoBxhfPPkAReudI = true;
					return false;
				}
			}

			private void wcGYRPGqDrlIWMdHhKfzLiyVbHLj()
			{
				bzydplFUvCQuLOENSPCjjUVEqYIA = true;
				while (!ExQGLjQuGDBsMvcoTpXALSCUULj)
				{
					KFWGRjFBiMlbwjBukYxOjySrbHDf.WaitOne();
					if (ExQGLjQuGDBsMvcoTpXALSCUULj)
					{
						break;
					}
					lock (VscpWqBWzuDusblaKBCJNvlmplv)
					{
						MiscTools.Swap(ref JDBoYRYwpyAUPtpchVKRvxjDGOl, ref TPybbyBjfxCVwOiNiHhhhskFYaec);
					}
					List<WaitCallback> tPybbyBjfxCVwOiNiHhhhskFYaec = TPybbyBjfxCVwOiNiHhhhskFYaec;
					int count = tPybbyBjfxCVwOiNiHhhhskFYaec.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							tPybbyBjfxCVwOiNiHhhhskFYaec[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					tPybbyBjfxCVwOiNiHhhhskFYaec.Clear();
				}
				lock (VscpWqBWzuDusblaKBCJNvlmplv)
				{
					JDBoYRYwpyAUPtpchVKRvxjDGOl.Clear();
					TPybbyBjfxCVwOiNiHhhhskFYaec.Clear();
				}
				ExQGLjQuGDBsMvcoTpXALSCUULj = false;
				bzydplFUvCQuLOENSPCjjUVEqYIA = false;
			}

			private void gbStDpUXXWGpFeeqjUqfWGKBGyy()
			{
				irmdVrQGOFlqwdAuFYGyeAWFQiF = null;
				BNPYZdoaDcBYqoBxhfPPkAReudI = false;
				ExQGLjQuGDBsMvcoTpXALSCUULj = true;
			}

			private void gZlNqJNCmrCVNLAuvZcaeBHPiJgJ()
			{
				gbStDpUXXWGpFeeqjUqfWGKBGyy();
				try
				{
					KFWGRjFBiMlbwjBukYxOjySrbHDf.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
				GC.SuppressFinalize(this);
			}

			~uVSajbFqsxGdOxtBWsIqmCdKXuGp()
			{
				WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
			}

			protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
			{
				if (!inweGjIgYacXYohFlYRlpMFkgKMi)
				{
					gZlNqJNCmrCVNLAuvZcaeBHPiJgJ();
					inweGjIgYacXYohFlYRlpMFkgKMi = true;
				}
			}
		}

		private static uVSajbFqsxGdOxtBWsIqmCdKXuGp edCzCbblegXjOfCncPcbxJaoxzD;

		private static int XRFMpLYPzXDxeIcRrZAkevlqgIP;

		private static uVSajbFqsxGdOxtBWsIqmCdKXuGp queue => edCzCbblegXjOfCncPcbxJaoxzD ?? (edCzCbblegXjOfCncPcbxJaoxzD = new uVSajbFqsxGdOxtBWsIqmCdKXuGp());

		static bgIPcwSnuVeLjkqQUuhZKLBEnzJX()
		{
			XRFMpLYPzXDxeIcRrZAkevlqgIP = 0;
			AppDomain.CurrentDomain.DomainUnload -= PvmOuXggNaRowCGrOIRTxKHYBwL;
			AppDomain.CurrentDomain.DomainUnload += PvmOuXggNaRowCGrOIRTxKHYBwL;
		}

		private static void PvmOuXggNaRowCGrOIRTxKHYBwL(object P_0, EventArgs P_1)
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
			AppDomain.CurrentDomain.DomainUnload -= PvmOuXggNaRowCGrOIRTxKHYBwL;
		}

		public static void eJjPxGnfLbHjqDgCklQMmLLmLpfL()
		{
			XRFMpLYPzXDxeIcRrZAkevlqgIP++;
		}

		public static void KDXasMbtUWeLyKkNduXaGITPefL()
		{
			XRFMpLYPzXDxeIcRrZAkevlqgIP--;
			if (XRFMpLYPzXDxeIcRrZAkevlqgIP < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (XRFMpLYPzXDxeIcRrZAkevlqgIP == 0)
			{
				WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
			}
		}

		public static void MyxYctDTQIDmPyFGyfSmfpxlMGl(WaitCallback P_0)
		{
			queue.MyxYctDTQIDmPyFGyfSmfpxlMGl(P_0);
		}

		public static void XQRagOICwWgBdxmesydJGWBMFuof()
		{
			queue.XQRagOICwWgBdxmesydJGWBMFuof();
		}

		public static bool EsoCoViNGnlmiCnejoKMpfdflIEq()
		{
			return queue.EsoCoViNGnlmiCnejoKMpfdflIEq();
		}

		private static void WYoEhOBxiSjIYKwbsCHdGOUBXDbi()
		{
			if (edCzCbblegXjOfCncPcbxJaoxzD != null)
			{
				edCzCbblegXjOfCncPcbxJaoxzD.Dispose();
			}
			edCzCbblegXjOfCncPcbxJaoxzD = null;
			XRFMpLYPzXDxeIcRrZAkevlqgIP = 0;
		}
	}

	private FpnURStQejVCfULATmNVYNgpZoD bRSaVDiLdftvbsOhRkmehBOGqanm;

	private T mIminKtcVaeellAqJGeLaSGnKleG;

	private WaitCallback fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	private object qIQlBFFGDiShOcCyrfZvJAVTChJ;

	private Func<T> rLPaoTxgEZWsuQfUdoenQBpZfZhb;

	private bool GlbbImoIxmjRQWrjWEjTQDPfrMb;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public bool isRunning
	{
		get
		{
			if (bRSaVDiLdftvbsOhRkmehBOGqanm != FpnURStQejVCfULATmNVYNgpZoD.uCrJdsqjRvmcYLlpXGLpaJByYVK)
			{
				return bRSaVDiLdftvbsOhRkmehBOGqanm == FpnURStQejVCfULATmNVYNgpZoD.hOEDCqKPdPQjuPfureStaQOKiKih;
			}
			return true;
		}
	}

	public T result => mIminKtcVaeellAqJGeLaSGnKleG;

	public bool uIPQYCOyPijpbHfLzGABZERoRaI()
	{
		bool flag = bRSaVDiLdftvbsOhRkmehBOGqanm == FpnURStQejVCfULATmNVYNgpZoD.hOEDCqKPdPQjuPfureStaQOKiKih;
		if (flag)
		{
			bRSaVDiLdftvbsOhRkmehBOGqanm = FpnURStQejVCfULATmNVYNgpZoD.qhpRgTSBpsOALeACGQvFkstXFKHA;
		}
		return flag;
	}

	public ETrJCGYDLNaYoirFtJFXTwjRwgvl(bool useSharedThread, Func<T> resultDelegate)
	{
		GlbbImoIxmjRQWrjWEjTQDPfrMb = useSharedThread;
		if (resultDelegate == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		rLPaoTxgEZWsuQfUdoenQBpZfZhb = resultDelegate;
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = rvANDghnOCniwCjhSpbZDVsMveV;
		qIQlBFFGDiShOcCyrfZvJAVTChJ = new object();
		bRSaVDiLdftvbsOhRkmehBOGqanm = FpnURStQejVCfULATmNVYNgpZoD.qhpRgTSBpsOALeACGQvFkstXFKHA;
		if (useSharedThread)
		{
			bgIPcwSnuVeLjkqQUuhZKLBEnzJX.eJjPxGnfLbHjqDgCklQMmLLmLpfL();
		}
	}

	public bool LgoJHLCBitFthTodNHJlYroGYaX()
	{
		lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
		{
			if (bRSaVDiLdftvbsOhRkmehBOGqanm == FpnURStQejVCfULATmNVYNgpZoD.uCrJdsqjRvmcYLlpXGLpaJByYVK)
			{
				return false;
			}
			mIminKtcVaeellAqJGeLaSGnKleG = default(T);
			bRSaVDiLdftvbsOhRkmehBOGqanm = FpnURStQejVCfULATmNVYNgpZoD.uCrJdsqjRvmcYLlpXGLpaJByYVK;
		}
		if (GlbbImoIxmjRQWrjWEjTQDPfrMb)
		{
			bgIPcwSnuVeLjkqQUuhZKLBEnzJX.MyxYctDTQIDmPyFGyfSmfpxlMGl(fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(fqbGqHjzpkWVQgbYWnLpGdohkzDz, this);
		}
		return true;
	}

	public void ibajyEOvcZaAVvqbaVIEPkwcIqx()
	{
		lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
		{
			mIminKtcVaeellAqJGeLaSGnKleG = default(T);
			bRSaVDiLdftvbsOhRkmehBOGqanm = FpnURStQejVCfULATmNVYNgpZoD.qhpRgTSBpsOALeACGQvFkstXFKHA;
		}
	}

	private void rvANDghnOCniwCjhSpbZDVsMveV(object P_0)
	{
		lock (qIQlBFFGDiShOcCyrfZvJAVTChJ)
		{
			if (bRSaVDiLdftvbsOhRkmehBOGqanm == FpnURStQejVCfULATmNVYNgpZoD.uCrJdsqjRvmcYLlpXGLpaJByYVK)
			{
				mIminKtcVaeellAqJGeLaSGnKleG = rLPaoTxgEZWsuQfUdoenQBpZfZhb();
				bRSaVDiLdftvbsOhRkmehBOGqanm = FpnURStQejVCfULATmNVYNgpZoD.hOEDCqKPdPQjuPfureStaQOKiKih;
			}
		}
	}

	public void WYoEhOBxiSjIYKwbsCHdGOUBXDbi()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~ETrJCGYDLNaYoirFtJFXTwjRwgvl()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			if (P_0)
			{
				ibajyEOvcZaAVvqbaVIEPkwcIqx();
			}
			if (GlbbImoIxmjRQWrjWEjTQDPfrMb)
			{
				bgIPcwSnuVeLjkqQUuhZKLBEnzJX.KDXasMbtUWeLyKkNduXaGITPefL();
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}
}
