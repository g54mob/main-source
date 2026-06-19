using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class McjQlNxEMWbTtbUlrizSwucUAAoO<_0001>
{
	private enum LCuIeqeuDyvuJmxuIBrQIKCVZiNmA
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class TjsssTMPMQvInXJlitxPDWozEVEf
	{
		private class DdvTZcgindSRwHdjKUBmdCdsBkccA : IDisposable
		{
			private sealed class HzaJtOWYtbnwFBdMghKxLaTJmNxU
			{
				public DdvTZcgindSRwHdjKUBmdCdsBkccA HeULOShTgnCZgNhQwkPpDfTfBMniA;

				public ManualResetEvent nWzEbBjmUDgRVbKaffaoCNsjUKguD;

				internal void zoqVrhkXkMjVSdHGNCmvLCfvJHoi()
				{
					nWzEbBjmUDgRVbKaffaoCNsjUKguD.Set();
					HeULOShTgnCZgNhQwkPpDfTfBMniA.DDXgDHioYzfxwYYNhkTBPxSMATRC();
				}
			}

			private readonly object rBKkHLuhreRRRkBHOGqYgzuCyQgo;

			private List<WaitCallback> wzJFtUdyPVPoGRKwvmuYAbJPJPby;

			private List<WaitCallback> jLICWCYceLKLLKCzMFevHJZXkcAbA;

			private Thread roHhzbafFaXoHSRcIQJeTKiZQrFk;

			private AutoResetEvent hBnfvjNgWWwzjbCYuaoxIqldlOcM;

			private bool UKQyWEZmSvsfMdyoiSQWUiiVddDl;

			private bool iAjgiMoviXHCYKpUiSDkwdhCqFiR;

			private bool LySEpzqgtZzjMMboUpMisLPQAlvi;

			private bool LxgjJniEDvVxFgGRNAhYUTWaRyVC;

			public DdvTZcgindSRwHdjKUBmdCdsBkccA()
			{
				rBKkHLuhreRRRkBHOGqYgzuCyQgo = new object();
				wzJFtUdyPVPoGRKwvmuYAbJPJPby = new List<WaitCallback>();
				jLICWCYceLKLLKCzMFevHJZXkcAbA = new List<WaitCallback>();
				hBnfvjNgWWwzjbCYuaoxIqldlOcM = new AutoResetEvent(initialState: false);
			}

			public void zsKscupuKxDIIIKRfbSUAoGxSzafA(WaitCallback P_0)
			{
				if (jgOXUEgkCydlgsvEBYRsHqXDHuZc())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (rBKkHLuhreRRRkBHOGqYgzuCyQgo)
					{
						wzJFtUdyPVPoGRKwvmuYAbJPJPby.Add(P_0);
					}
					hBnfvjNgWWwzjbCYuaoxIqldlOcM.Set();
				}
			}

			public void FaLXFugaZlZZGlmrWnUaYeiAoXZc()
			{
				YwZwneabLyprFORZGgElewDIzjsiA();
			}

			public bool atlolBSjYOnPLnUStavFwbTnfOhC()
			{
				return jgOXUEgkCydlgsvEBYRsHqXDHuZc();
			}

			private bool jgOXUEgkCydlgsvEBYRsHqXDHuZc()
			{
				if (LySEpzqgtZzjMMboUpMisLPQAlvi)
				{
					return false;
				}
				if (iAjgiMoviXHCYKpUiSDkwdhCqFiR)
				{
					return false;
				}
				if (UKQyWEZmSvsfMdyoiSQWUiiVddDl)
				{
					return true;
				}
				if (roHhzbafFaXoHSRcIQJeTKiZQrFk != null)
				{
					return true;
				}
				return ROGmNrbeiwLqrhqiKXbBxcuVgyUcA();
			}

			private bool ROGmNrbeiwLqrhqiKXbBxcuVgyUcA()
			{
				HzaJtOWYtbnwFBdMghKxLaTJmNxU hzaJtOWYtbnwFBdMghKxLaTJmNxU = new HzaJtOWYtbnwFBdMghKxLaTJmNxU();
				hzaJtOWYtbnwFBdMghKxLaTJmNxU.HeULOShTgnCZgNhQwkPpDfTfBMniA = this;
				try
				{
					hzaJtOWYtbnwFBdMghKxLaTJmNxU.nWzEbBjmUDgRVbKaffaoCNsjUKguD = new ManualResetEvent(initialState: false);
					roHhzbafFaXoHSRcIQJeTKiZQrFk = new Thread(hzaJtOWYtbnwFBdMghKxLaTJmNxU.zoqVrhkXkMjVSdHGNCmvLCfvJHoi);
					roHhzbafFaXoHSRcIQJeTKiZQrFk.Start();
					hzaJtOWYtbnwFBdMghKxLaTJmNxU.nWzEbBjmUDgRVbKaffaoCNsjUKguD.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					roHhzbafFaXoHSRcIQJeTKiZQrFk = null;
					LySEpzqgtZzjMMboUpMisLPQAlvi = true;
					return false;
				}
			}

			private void DDXgDHioYzfxwYYNhkTBPxSMATRC()
			{
				UKQyWEZmSvsfMdyoiSQWUiiVddDl = true;
				while (!iAjgiMoviXHCYKpUiSDkwdhCqFiR)
				{
					hBnfvjNgWWwzjbCYuaoxIqldlOcM.WaitOne();
					if (iAjgiMoviXHCYKpUiSDkwdhCqFiR)
					{
						break;
					}
					lock (rBKkHLuhreRRRkBHOGqYgzuCyQgo)
					{
						MiscTools.Swap(ref wzJFtUdyPVPoGRKwvmuYAbJPJPby, ref jLICWCYceLKLLKCzMFevHJZXkcAbA);
					}
					List<WaitCallback> list = jLICWCYceLKLLKCzMFevHJZXkcAbA;
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
				lock (rBKkHLuhreRRRkBHOGqYgzuCyQgo)
				{
					wzJFtUdyPVPoGRKwvmuYAbJPJPby.Clear();
					jLICWCYceLKLLKCzMFevHJZXkcAbA.Clear();
				}
				iAjgiMoviXHCYKpUiSDkwdhCqFiR = false;
				UKQyWEZmSvsfMdyoiSQWUiiVddDl = false;
			}

			private void IHJbapOvkWTeZYBkxBAGIbhkhTWO()
			{
				roHhzbafFaXoHSRcIQJeTKiZQrFk = null;
				LySEpzqgtZzjMMboUpMisLPQAlvi = false;
				iAjgiMoviXHCYKpUiSDkwdhCqFiR = true;
			}

			private void YwZwneabLyprFORZGgElewDIzjsiA()
			{
				IHJbapOvkWTeZYBkxBAGIbhkhTWO();
				try
				{
					hBnfvjNgWWwzjbCYuaoxIqldlOcM.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				nOxwEYlDvpCnHYGEMdSlHfqgCaxe(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void tljmmDMgpcEtvxJnWctDuHcSppct()
			{
				try
				{
					nOxwEYlDvpCnHYGEMdSlHfqgCaxe(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void nOxwEYlDvpCnHYGEMdSlHfqgCaxe(bool P_0)
			{
				if (!LxgjJniEDvVxFgGRNAhYUTWaRyVC)
				{
					YwZwneabLyprFORZGgElewDIzjsiA();
					LxgjJniEDvVxFgGRNAhYUTWaRyVC = true;
				}
			}
		}

		private static TjsssTMPMQvInXJlitxPDWozEVEf uksBVuARWhIhgdXdXaniDSKGusFC;

		private DdvTZcgindSRwHdjKUBmdCdsBkccA rJEDUYzaHKeLlIqOBIkSlfVefuCf;

		private int rDIxucajVMciuAfluwxXfISXyunJA;

		private bool ecagfIwpFPBcffoVwptsfIAJcOrt;

		private static TjsssTMPMQvInXJlitxPDWozEVEf PjsACRCcuheFqjJHGbhvODJWwyii => uksBVuARWhIhgdXdXaniDSKGusFC ?? new TjsssTMPMQvInXJlitxPDWozEVEf();

		private DdvTZcgindSRwHdjKUBmdCdsBkccA tlAFBXJEUqMgzQESSptuPJxMheqcA => rJEDUYzaHKeLlIqOBIkSlfVefuCf ?? (rJEDUYzaHKeLlIqOBIkSlfVefuCf = new DdvTZcgindSRwHdjKUBmdCdsBkccA());

		private TjsssTMPMQvInXJlitxPDWozEVEf()
		{
			uksBVuARWhIhgdXdXaniDSKGusFC?.TbeGgvgcjTzcYiMYhGfpJdYjWkDKA();
			uksBVuARWhIhgdXdXaniDSKGusFC = this;
		}

		private void AawHfACBOHPlzLXnzUwJegUHdcJtA()
		{
			rDIxucajVMciuAfluwxXfISXyunJA++;
		}

		private void FnNEhRekbkqSCzzfPXeAxlebHlxfb()
		{
			rDIxucajVMciuAfluwxXfISXyunJA--;
			if (rDIxucajVMciuAfluwxXfISXyunJA < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (rDIxucajVMciuAfluwxXfISXyunJA == 0)
			{
				TbeGgvgcjTzcYiMYhGfpJdYjWkDKA();
			}
		}

		private void bqOToMAfUdTHoapGOeDvEaAZyhISA(WaitCallback P_0)
		{
			tlAFBXJEUqMgzQESSptuPJxMheqcA.zsKscupuKxDIIIKRfbSUAoGxSzafA(P_0);
		}

		private void tsSvjnOSUcKvnZAezEsIjolXlXEO()
		{
			tlAFBXJEUqMgzQESSptuPJxMheqcA.FaLXFugaZlZZGlmrWnUaYeiAoXZc();
		}

		private bool kyISxgEboKFHYgWrVAiGewVDLyru()
		{
			return tlAFBXJEUqMgzQESSptuPJxMheqcA.atlolBSjYOnPLnUStavFwbTnfOhC();
		}

		private void TbeGgvgcjTzcYiMYhGfpJdYjWkDKA()
		{
			FSqDZAFJdUMSccZaGGmKXdQSqfFyA(true);
			GC.SuppressFinalize(this);
		}

		protected void JTTBMEamoLcDuQaCITpdXIPDpAtX()
		{
			try
			{
				FSqDZAFJdUMSccZaGGmKXdQSqfFyA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void FSqDZAFJdUMSccZaGGmKXdQSqfFyA(bool P_0)
		{
			if (!ecagfIwpFPBcffoVwptsfIAJcOrt)
			{
				if (P_0 && rJEDUYzaHKeLlIqOBIkSlfVefuCf != null)
				{
					rJEDUYzaHKeLlIqOBIkSlfVefuCf.Dispose();
					rJEDUYzaHKeLlIqOBIkSlfVefuCf = null;
				}
				rDIxucajVMciuAfluwxXfISXyunJA = 0;
				if (uksBVuARWhIhgdXdXaniDSKGusFC == this)
				{
					uksBVuARWhIhgdXdXaniDSKGusFC = null;
				}
				ecagfIwpFPBcffoVwptsfIAJcOrt = true;
			}
		}

		public static void RPHxyICYyHJLsXjOlRztmQfPNuQR()
		{
			PjsACRCcuheFqjJHGbhvODJWwyii.AawHfACBOHPlzLXnzUwJegUHdcJtA();
		}

		public static void BnolBEwuJlcHWthVVsKYGcTdwnHC()
		{
			uksBVuARWhIhgdXdXaniDSKGusFC?.FnNEhRekbkqSCzzfPXeAxlebHlxfb();
		}

		public static void NfAkfrkWoZInrYaOclBRTHvaDYmp(WaitCallback P_0)
		{
			PjsACRCcuheFqjJHGbhvODJWwyii.bqOToMAfUdTHoapGOeDvEaAZyhISA(P_0);
		}
	}

	private LCuIeqeuDyvuJmxuIBrQIKCVZiNmA sHbEQuKEGDVQjwIgUgKjKetSCJSS;

	private _0001 hGrncsLNftKuUxgMvIoNBlsQirCXA;

	private WaitCallback kRpTwHWlEkqNrSQYQiUIPCkYNfbR;

	private object vfKWkkECZLSjqpxcgIpCOORkeahk;

	private Func<_0001> EGRdqDONqUgSXaJRtKtPxxXLrRcfA;

	private bool spgVBdsuhYyJeCHUOWsRPmGBPEee;

	private bool KXXeDbcFLXzVKlbofqfgAqijvEEdB;

	public bool rYnfxXQpvqMpOJxdAcMymuXfVPdJ
	{
		get
		{
			if (sHbEQuKEGDVQjwIgUgKjKetSCJSS != LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.AwaitingResult)
			{
				return sHbEQuKEGDVQjwIgUgKjKetSCJSS == LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.ResultReceived;
			}
			return true;
		}
	}

	public _0001 pIVDjHonGkoGmUlIarmyWTCFlTfh => hGrncsLNftKuUxgMvIoNBlsQirCXA;

	public bool hRRQBhRlrNLlIwAAvCWMAegGhfdIA()
	{
		bool num = sHbEQuKEGDVQjwIgUgKjKetSCJSS == LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.ResultReceived;
		if (num)
		{
			sHbEQuKEGDVQjwIgUgKjKetSCJSS = LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.Idle;
		}
		return num;
	}

	public McjQlNxEMWbTtbUlrizSwucUAAoO(bool P_0, Func<_0001> P_1)
	{
		spgVBdsuhYyJeCHUOWsRPmGBPEee = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		EGRdqDONqUgSXaJRtKtPxxXLrRcfA = P_1;
		kRpTwHWlEkqNrSQYQiUIPCkYNfbR = yqtWzmiMTRaLAcJnWgcZDZMTwaXo;
		vfKWkkECZLSjqpxcgIpCOORkeahk = new object();
		sHbEQuKEGDVQjwIgUgKjKetSCJSS = LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.Idle;
		if (P_0)
		{
			TjsssTMPMQvInXJlitxPDWozEVEf.RPHxyICYyHJLsXjOlRztmQfPNuQR();
		}
	}

	public bool ZRNxDcQZRiFYRKxfnaKLNAFnscDt()
	{
		lock (vfKWkkECZLSjqpxcgIpCOORkeahk)
		{
			if (sHbEQuKEGDVQjwIgUgKjKetSCJSS == LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.AwaitingResult)
			{
				return false;
			}
			hGrncsLNftKuUxgMvIoNBlsQirCXA = default(_0001);
			sHbEQuKEGDVQjwIgUgKjKetSCJSS = LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.AwaitingResult;
		}
		if (spgVBdsuhYyJeCHUOWsRPmGBPEee)
		{
			TjsssTMPMQvInXJlitxPDWozEVEf.NfAkfrkWoZInrYaOclBRTHvaDYmp(kRpTwHWlEkqNrSQYQiUIPCkYNfbR);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(kRpTwHWlEkqNrSQYQiUIPCkYNfbR, this);
		}
		return true;
	}

	public void xnbcVceCutMoVtiQkYEiIptfhcNmA()
	{
		lock (vfKWkkECZLSjqpxcgIpCOORkeahk)
		{
			hGrncsLNftKuUxgMvIoNBlsQirCXA = default(_0001);
			sHbEQuKEGDVQjwIgUgKjKetSCJSS = LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.Idle;
		}
	}

	private void yqtWzmiMTRaLAcJnWgcZDZMTwaXo(object P_0)
	{
		lock (vfKWkkECZLSjqpxcgIpCOORkeahk)
		{
			if (sHbEQuKEGDVQjwIgUgKjKetSCJSS == LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.AwaitingResult)
			{
				hGrncsLNftKuUxgMvIoNBlsQirCXA = EGRdqDONqUgSXaJRtKtPxxXLrRcfA();
				sHbEQuKEGDVQjwIgUgKjKetSCJSS = LCuIeqeuDyvuJmxuIBrQIKCVZiNmA.ResultReceived;
			}
		}
	}

	public void mkQAsPQkdBLuRVdsGBfjsPGJgaIJ()
	{
		hEYyNJNBPojeiIlxHUXQhmEtuBQ(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void TQbakHbAFNNiXlaAZHUBABtdECrO()
	{
		try
		{
			hEYyNJNBPojeiIlxHUXQhmEtuBQ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hEYyNJNBPojeiIlxHUXQhmEtuBQ(bool P_0)
	{
		if (!KXXeDbcFLXzVKlbofqfgAqijvEEdB)
		{
			if (P_0)
			{
				xnbcVceCutMoVtiQkYEiIptfhcNmA();
			}
			if (spgVBdsuhYyJeCHUOWsRPmGBPEee)
			{
				TjsssTMPMQvInXJlitxPDWozEVEf.BnolBEwuJlcHWthVVsKYGcTdwnHC();
			}
			KXXeDbcFLXzVKlbofqfgAqijvEEdB = true;
		}
	}
}
