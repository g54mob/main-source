using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<_0001>
{
	private enum wlAvJORZIhKWxDDpZfvYyOaePfhT
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class gESaJljMLJkRLcIihAdFcvIObLedb
	{
		private class aiBgqQZDscMhOcooBDXsBvJRqbYO : IDisposable
		{
			private sealed class wLQpAaxMacxZdsARjcOdhvtmjYBw
			{
				public aiBgqQZDscMhOcooBDXsBvJRqbYO sZsHxmYxlogjGqwJdAZnjNzCqBHX;

				public ManualResetEvent KRBwKjLfFGhtphxbqDwqipCxiFCsA;

				internal void KtUqaLZylVTisAwPGMkljjLSHCGu()
				{
					KRBwKjLfFGhtphxbqDwqipCxiFCsA.Set();
					sZsHxmYxlogjGqwJdAZnjNzCqBHX.sxpRtzTBNokNYvVLauuHxHBpEHxz();
				}
			}

			private readonly object SVelehDPsxnpjHMMFPeMZaKtiJCdA;

			private List<WaitCallback> XRbrQqIIOWbWqdcniCcWzsbgHQTDb;

			private List<WaitCallback> QwglCafbfYbVfvycTialtopedokI;

			private Thread CxtRGFDQEnIOhgzjJaBaDrAKqZrfc;

			private AutoResetEvent IGXIHXemTXBfZOxDzuNziaLEKJOP;

			private bool lDgAZmkJBmaQyCsprhUSyjEsqixm;

			private bool LQFRRkDsfMcaynATnlNgOzJzCMKn;

			private bool ahavPoRgFAVuArnyJfwoCfLbRLUB;

			private bool qiMQTJPOuovnqJDYQGAbknHPMgtd;

			public aiBgqQZDscMhOcooBDXsBvJRqbYO()
			{
				SVelehDPsxnpjHMMFPeMZaKtiJCdA = new object();
				XRbrQqIIOWbWqdcniCcWzsbgHQTDb = new List<WaitCallback>();
				QwglCafbfYbVfvycTialtopedokI = new List<WaitCallback>();
				IGXIHXemTXBfZOxDzuNziaLEKJOP = new AutoResetEvent(initialState: false);
			}

			public void UYqeFQQLDafgmhbGeDCOcMsQysMiA(WaitCallback P_0)
			{
				if (OsseaxBhBrVAJPaVCWuNdQmiOhQB())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (SVelehDPsxnpjHMMFPeMZaKtiJCdA)
					{
						XRbrQqIIOWbWqdcniCcWzsbgHQTDb.Add(P_0);
					}
					IGXIHXemTXBfZOxDzuNziaLEKJOP.Set();
				}
			}

			public void qKvsCCNSLipjiYhCTbgewbGhbezi()
			{
				fKvZUYVcYtQPlrvYVmItGrxtEeWx();
			}

			public bool FLRBnpjJWTPzSSNiQyNaWTBOwHGB()
			{
				return OsseaxBhBrVAJPaVCWuNdQmiOhQB();
			}

			private bool OsseaxBhBrVAJPaVCWuNdQmiOhQB()
			{
				if (ahavPoRgFAVuArnyJfwoCfLbRLUB)
				{
					return false;
				}
				if (LQFRRkDsfMcaynATnlNgOzJzCMKn)
				{
					return false;
				}
				if (lDgAZmkJBmaQyCsprhUSyjEsqixm)
				{
					return true;
				}
				if (CxtRGFDQEnIOhgzjJaBaDrAKqZrfc != null)
				{
					return true;
				}
				return yjcKuDSHjtWOFMWnRSxHLvGwLbkO();
			}

			private bool yjcKuDSHjtWOFMWnRSxHLvGwLbkO()
			{
				wLQpAaxMacxZdsARjcOdhvtmjYBw wLQpAaxMacxZdsARjcOdhvtmjYBw2 = new wLQpAaxMacxZdsARjcOdhvtmjYBw();
				wLQpAaxMacxZdsARjcOdhvtmjYBw2.sZsHxmYxlogjGqwJdAZnjNzCqBHX = this;
				try
				{
					wLQpAaxMacxZdsARjcOdhvtmjYBw2.KRBwKjLfFGhtphxbqDwqipCxiFCsA = new ManualResetEvent(initialState: false);
					CxtRGFDQEnIOhgzjJaBaDrAKqZrfc = new Thread(wLQpAaxMacxZdsARjcOdhvtmjYBw2.KtUqaLZylVTisAwPGMkljjLSHCGu);
					CxtRGFDQEnIOhgzjJaBaDrAKqZrfc.Start();
					wLQpAaxMacxZdsARjcOdhvtmjYBw2.KRBwKjLfFGhtphxbqDwqipCxiFCsA.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					CxtRGFDQEnIOhgzjJaBaDrAKqZrfc = null;
					ahavPoRgFAVuArnyJfwoCfLbRLUB = true;
					return false;
				}
			}

			private void sxpRtzTBNokNYvVLauuHxHBpEHxz()
			{
				lDgAZmkJBmaQyCsprhUSyjEsqixm = true;
				while (!LQFRRkDsfMcaynATnlNgOzJzCMKn)
				{
					IGXIHXemTXBfZOxDzuNziaLEKJOP.WaitOne();
					if (LQFRRkDsfMcaynATnlNgOzJzCMKn)
					{
						break;
					}
					lock (SVelehDPsxnpjHMMFPeMZaKtiJCdA)
					{
						MiscTools.Swap(ref XRbrQqIIOWbWqdcniCcWzsbgHQTDb, ref QwglCafbfYbVfvycTialtopedokI);
					}
					List<WaitCallback> qwglCafbfYbVfvycTialtopedokI = QwglCafbfYbVfvycTialtopedokI;
					int count = qwglCafbfYbVfvycTialtopedokI.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							qwglCafbfYbVfvycTialtopedokI[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					qwglCafbfYbVfvycTialtopedokI.Clear();
				}
				lock (SVelehDPsxnpjHMMFPeMZaKtiJCdA)
				{
					XRbrQqIIOWbWqdcniCcWzsbgHQTDb.Clear();
					QwglCafbfYbVfvycTialtopedokI.Clear();
				}
				LQFRRkDsfMcaynATnlNgOzJzCMKn = false;
				lDgAZmkJBmaQyCsprhUSyjEsqixm = false;
			}

			private void jejIgTvHoXthzdrpyBbMcUJVENqi()
			{
				CxtRGFDQEnIOhgzjJaBaDrAKqZrfc = null;
				ahavPoRgFAVuArnyJfwoCfLbRLUB = false;
				LQFRRkDsfMcaynATnlNgOzJzCMKn = true;
			}

			private void fKvZUYVcYtQPlrvYVmItGrxtEeWx()
			{
				jejIgTvHoXthzdrpyBbMcUJVENqi();
				try
				{
					IGXIHXemTXBfZOxDzuNziaLEKJOP.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				YwXZmkWKlqeDpxfDHjQlnsXJJFLj(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void SPPNilfqirZqNSUkBtZFOrObqkSj()
			{
				try
				{
					YwXZmkWKlqeDpxfDHjQlnsXJJFLj(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void YwXZmkWKlqeDpxfDHjQlnsXJJFLj(bool P_0)
			{
				if (!qiMQTJPOuovnqJDYQGAbknHPMgtd)
				{
					fKvZUYVcYtQPlrvYVmItGrxtEeWx();
					qiMQTJPOuovnqJDYQGAbknHPMgtd = true;
				}
			}
		}

		private static gESaJljMLJkRLcIihAdFcvIObLedb HvAkhQvKcuwIQKWpYiMmbqIrhAhg;

		private aiBgqQZDscMhOcooBDXsBvJRqbYO EbiysVASEBEVhtHWGMEJDhKDecxb;

		private int MraFVIgRCFaIMNUmrDlFVqwgatDcb;

		private bool FPWrCaPfGKUAXCWMdFhkDdkqwHPX;

		private static gESaJljMLJkRLcIihAdFcvIObLedb mcMlglzrUqGgAObOBpdxoVjbzMKH => HvAkhQvKcuwIQKWpYiMmbqIrhAhg ?? new gESaJljMLJkRLcIihAdFcvIObLedb();

		private aiBgqQZDscMhOcooBDXsBvJRqbYO EpkUklfNJzCSRHpZFypuJxHffrMnA => EbiysVASEBEVhtHWGMEJDhKDecxb ?? (EbiysVASEBEVhtHWGMEJDhKDecxb = new aiBgqQZDscMhOcooBDXsBvJRqbYO());

		private gESaJljMLJkRLcIihAdFcvIObLedb()
		{
			HvAkhQvKcuwIQKWpYiMmbqIrhAhg?.aqQrZTLruStSsPlZyMrzXgiGrntS();
			HvAkhQvKcuwIQKWpYiMmbqIrhAhg = this;
		}

		private void rNKxEukpNKMZTwAiymoJIOqcarvgA()
		{
			MraFVIgRCFaIMNUmrDlFVqwgatDcb++;
		}

		private void chvwKpJzufmWyAcmUGoUFmCOweDu()
		{
			MraFVIgRCFaIMNUmrDlFVqwgatDcb--;
			if (MraFVIgRCFaIMNUmrDlFVqwgatDcb < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (MraFVIgRCFaIMNUmrDlFVqwgatDcb == 0)
			{
				aqQrZTLruStSsPlZyMrzXgiGrntS();
			}
		}

		private void ClkfVwddHakdKgHLLMHllYiyaywfb(WaitCallback P_0)
		{
			EpkUklfNJzCSRHpZFypuJxHffrMnA.UYqeFQQLDafgmhbGeDCOcMsQysMiA(P_0);
		}

		private void ApibOXAdFdrqPrcjoAoGhXXsqKkbb()
		{
			EpkUklfNJzCSRHpZFypuJxHffrMnA.qKvsCCNSLipjiYhCTbgewbGhbezi();
		}

		private bool RdkfEUlNjBnKgXQuWyDIKGrsJnJu()
		{
			return EpkUklfNJzCSRHpZFypuJxHffrMnA.FLRBnpjJWTPzSSNiQyNaWTBOwHGB();
		}

		private void aqQrZTLruStSsPlZyMrzXgiGrntS()
		{
			sVQxseeTkFUsYoQfZAgQVcqxlchR(true);
			GC.SuppressFinalize(this);
		}

		protected void gOfxsuFpfEzCIxGJVcjtbmnsdNTHA()
		{
			try
			{
				sVQxseeTkFUsYoQfZAgQVcqxlchR(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void sVQxseeTkFUsYoQfZAgQVcqxlchR(bool P_0)
		{
			if (!FPWrCaPfGKUAXCWMdFhkDdkqwHPX)
			{
				if (P_0 && EbiysVASEBEVhtHWGMEJDhKDecxb != null)
				{
					EbiysVASEBEVhtHWGMEJDhKDecxb.Dispose();
					EbiysVASEBEVhtHWGMEJDhKDecxb = null;
				}
				MraFVIgRCFaIMNUmrDlFVqwgatDcb = 0;
				if (HvAkhQvKcuwIQKWpYiMmbqIrhAhg == this)
				{
					HvAkhQvKcuwIQKWpYiMmbqIrhAhg = null;
				}
				FPWrCaPfGKUAXCWMdFhkDdkqwHPX = true;
			}
		}

		public static void qyvfFsjllQvtQhcPqYlbVEFsQtkjA()
		{
			mcMlglzrUqGgAObOBpdxoVjbzMKH.rNKxEukpNKMZTwAiymoJIOqcarvgA();
		}

		public static void aYQSVyHxvaSAaOynYeQLiKdSfEvd()
		{
			HvAkhQvKcuwIQKWpYiMmbqIrhAhg?.chvwKpJzufmWyAcmUGoUFmCOweDu();
		}

		public static void gsyKCNXHxMJLVrqTfgZJfbBNSZYk(WaitCallback P_0)
		{
			mcMlglzrUqGgAObOBpdxoVjbzMKH.ClkfVwddHakdKgHLLMHllYiyaywfb(P_0);
		}
	}

	private wlAvJORZIhKWxDDpZfvYyOaePfhT DdDxKPpPGUtaPZfhLyFluHqxObcE;

	private _0001 IXVGBEqyeqQUsChJuayTVsKhEqcP;

	private WaitCallback DjLfDzGjBhnjBAbZIROQevGDlmIBD;

	private object KvipqGrTQOqOMWhrzEKMaezBVpTn;

	private Func<_0001> bobLabrtdTsudwfWuxNRZqhoQtKh;

	private bool TVImVJFtDJSuShOCJYXgfEryOFCE;

	private bool djbtcFsKWGpjoURzuMpgKUKMfHux;

	public bool IjDAOhjnupbeicWoJQcuMwlCNKJq
	{
		get
		{
			if (DdDxKPpPGUtaPZfhLyFluHqxObcE != wlAvJORZIhKWxDDpZfvYyOaePfhT.AwaitingResult)
			{
				return DdDxKPpPGUtaPZfhLyFluHqxObcE == wlAvJORZIhKWxDDpZfvYyOaePfhT.ResultReceived;
			}
			return true;
		}
	}

	public _0001 UYndadRIHdtACtFVjQfssImkfgZcA => IXVGBEqyeqQUsChJuayTVsKhEqcP;

	public bool IChbtFqxyAxpsLDDmkASsVKzMoVs()
	{
		bool num = DdDxKPpPGUtaPZfhLyFluHqxObcE == wlAvJORZIhKWxDDpZfvYyOaePfhT.ResultReceived;
		if (num)
		{
			DdDxKPpPGUtaPZfhLyFluHqxObcE = wlAvJORZIhKWxDDpZfvYyOaePfhT.Idle;
		}
		return num;
	}

	public tgFAlfAsXFDhZaOgiAxWJMIbRLIcA(bool P_0, Func<_0001> P_1)
	{
		TVImVJFtDJSuShOCJYXgfEryOFCE = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		bobLabrtdTsudwfWuxNRZqhoQtKh = P_1;
		DjLfDzGjBhnjBAbZIROQevGDlmIBD = ZXRFYAFLYGElkdPkVmsVgvqyWznCA;
		KvipqGrTQOqOMWhrzEKMaezBVpTn = new object();
		DdDxKPpPGUtaPZfhLyFluHqxObcE = wlAvJORZIhKWxDDpZfvYyOaePfhT.Idle;
		if (P_0)
		{
			gESaJljMLJkRLcIihAdFcvIObLedb.qyvfFsjllQvtQhcPqYlbVEFsQtkjA();
		}
	}

	public bool icnDcGzVOnAmxAhayFIDZrxYnhvMA()
	{
		lock (KvipqGrTQOqOMWhrzEKMaezBVpTn)
		{
			if (DdDxKPpPGUtaPZfhLyFluHqxObcE == wlAvJORZIhKWxDDpZfvYyOaePfhT.AwaitingResult)
			{
				return false;
			}
			IXVGBEqyeqQUsChJuayTVsKhEqcP = default(_0001);
			DdDxKPpPGUtaPZfhLyFluHqxObcE = wlAvJORZIhKWxDDpZfvYyOaePfhT.AwaitingResult;
		}
		if (TVImVJFtDJSuShOCJYXgfEryOFCE)
		{
			gESaJljMLJkRLcIihAdFcvIObLedb.gsyKCNXHxMJLVrqTfgZJfbBNSZYk(DjLfDzGjBhnjBAbZIROQevGDlmIBD);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(DjLfDzGjBhnjBAbZIROQevGDlmIBD, this);
		}
		return true;
	}

	public void QtFVeQtTlkQQbDQNpqQaZpNWShhT()
	{
		lock (KvipqGrTQOqOMWhrzEKMaezBVpTn)
		{
			IXVGBEqyeqQUsChJuayTVsKhEqcP = default(_0001);
			DdDxKPpPGUtaPZfhLyFluHqxObcE = wlAvJORZIhKWxDDpZfvYyOaePfhT.Idle;
		}
	}

	private void ZXRFYAFLYGElkdPkVmsVgvqyWznCA(object P_0)
	{
		lock (KvipqGrTQOqOMWhrzEKMaezBVpTn)
		{
			if (DdDxKPpPGUtaPZfhLyFluHqxObcE == wlAvJORZIhKWxDDpZfvYyOaePfhT.AwaitingResult)
			{
				IXVGBEqyeqQUsChJuayTVsKhEqcP = bobLabrtdTsudwfWuxNRZqhoQtKh();
				DdDxKPpPGUtaPZfhLyFluHqxObcE = wlAvJORZIhKWxDDpZfvYyOaePfhT.ResultReceived;
			}
		}
	}

	public void FBethkzoPOdpxwrHTNdcWabofFyD()
	{
		AumzitmCQKIRMVuwqAhLgFEddOrG(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void iHYVvIEIAJvfuIDOuVDiwDKYLBOA()
	{
		try
		{
			AumzitmCQKIRMVuwqAhLgFEddOrG(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void AumzitmCQKIRMVuwqAhLgFEddOrG(bool P_0)
	{
		if (!djbtcFsKWGpjoURzuMpgKUKMfHux)
		{
			if (P_0)
			{
				QtFVeQtTlkQQbDQNpqQaZpNWShhT();
			}
			if (TVImVJFtDJSuShOCJYXgfEryOFCE)
			{
				gESaJljMLJkRLcIihAdFcvIObLedb.aYQSVyHxvaSAaOynYeQLiKdSfEvd();
			}
			djbtcFsKWGpjoURzuMpgKUKMfHux = true;
		}
	}
}
