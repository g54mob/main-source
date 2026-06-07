using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class LLwWBrlwrzAzBgxVkRCTkMClAyJ<T>
{
	private enum fISvCZukncdvvcYLzoIMuIkPrrm
	{
		rFobbojpJYIzanfETPcXNoEpUYjh = 0,
		pDmAWBTIDVZBnWKxYJyfiDyUMTa = 1,
		onNsFRyuVnGKDkqwwQZxGytEtYO = 2
	}

	private static class SeQwWIGiDYtqllJossYMxOuKrPx
	{
		private class AwGZWVvgsgdNJrBiTbTlfsIfyJy : IDisposable
		{
			private sealed class WOZyOIrVbWVmVxGuCsTuXVHFsJu
			{
				public ManualResetEvent DUJTLJypcFKjFFUzUppgOHZkcEZ;

				public AwGZWVvgsgdNJrBiTbTlfsIfyJy cRVMYqVhdfyBTxGUMpvYUoxDjzC;

				public void ThMAxMiSIEpXgRdgSSnttUPIiSch()
				{
					DUJTLJypcFKjFFUzUppgOHZkcEZ.Set();
					cRVMYqVhdfyBTxGUMpvYUoxDjzC.hRDXGuztELQRnDPuqaEtVVgbNSj();
				}
			}

			private readonly object OwdBRVkoLEeNZyygHCLZABIQljTX;

			private List<WaitCallback> WVOcdqdeESMtrcshmTGZlXKvGIJ;

			private List<WaitCallback> SyxpaTEbNBHyRbjBbNknpgXiroQe;

			private Thread tjbaiMrJifoIDiaaEAFkHcnphSvb;

			private AutoResetEvent XnXmEMyLMocEPKOmdGmUhmdRmHrS;

			private bool gohngYhiRgfBkFJRFnXhUcscROs;

			private bool LAuTHorXUliRFekupmkDXpnwQQl;

			private bool QAEJOaLDOSfoppCHoZgTiPpUQqZ;

			private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

			public AwGZWVvgsgdNJrBiTbTlfsIfyJy()
			{
				OwdBRVkoLEeNZyygHCLZABIQljTX = new object();
				WVOcdqdeESMtrcshmTGZlXKvGIJ = new List<WaitCallback>();
				SyxpaTEbNBHyRbjBbNknpgXiroQe = new List<WaitCallback>();
				XnXmEMyLMocEPKOmdGmUhmdRmHrS = new AutoResetEvent(false);
			}

			public void RZoXgCweZkubcxEHjLTmjQDJWlZ(WaitCallback P_0)
			{
				if (OXxfSVQgpwyQzMSlFTkamYYmQrW())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
					{
						WVOcdqdeESMtrcshmTGZlXKvGIJ.Add(P_0);
					}
					XnXmEMyLMocEPKOmdGmUhmdRmHrS.Set();
				}
			}

			public void SwQNhntQSgOcYlIglieTMwqyFkUA()
			{
				lbcUDcmRQZyNiOiSqzZkkqatLNY();
			}

			public bool JNpqtseTgVDsLidqlJBYdNCXmOC()
			{
				return OXxfSVQgpwyQzMSlFTkamYYmQrW();
			}

			private bool OXxfSVQgpwyQzMSlFTkamYYmQrW()
			{
				if (QAEJOaLDOSfoppCHoZgTiPpUQqZ)
				{
					return false;
				}
				if (LAuTHorXUliRFekupmkDXpnwQQl)
				{
					return false;
				}
				if (gohngYhiRgfBkFJRFnXhUcscROs)
				{
					return true;
				}
				if (tjbaiMrJifoIDiaaEAFkHcnphSvb != null)
				{
					return true;
				}
				try
				{
					WOZyOIrVbWVmVxGuCsTuXVHFsJu wOZyOIrVbWVmVxGuCsTuXVHFsJu = new WOZyOIrVbWVmVxGuCsTuXVHFsJu();
					wOZyOIrVbWVmVxGuCsTuXVHFsJu.cRVMYqVhdfyBTxGUMpvYUoxDjzC = this;
					wOZyOIrVbWVmVxGuCsTuXVHFsJu.DUJTLJypcFKjFFUzUppgOHZkcEZ = new ManualResetEvent(false);
					tjbaiMrJifoIDiaaEAFkHcnphSvb = new Thread(wOZyOIrVbWVmVxGuCsTuXVHFsJu.ThMAxMiSIEpXgRdgSSnttUPIiSch);
					tjbaiMrJifoIDiaaEAFkHcnphSvb.Start();
					wOZyOIrVbWVmVxGuCsTuXVHFsJu.DUJTLJypcFKjFFUzUppgOHZkcEZ.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, true);
					tjbaiMrJifoIDiaaEAFkHcnphSvb = null;
					QAEJOaLDOSfoppCHoZgTiPpUQqZ = true;
					return false;
				}
			}

			private void hRDXGuztELQRnDPuqaEtVVgbNSj()
			{
				gohngYhiRgfBkFJRFnXhUcscROs = true;
				while (!LAuTHorXUliRFekupmkDXpnwQQl)
				{
					XnXmEMyLMocEPKOmdGmUhmdRmHrS.WaitOne();
					if (LAuTHorXUliRFekupmkDXpnwQQl)
					{
						break;
					}
					lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
					{
						MiscTools.Swap(ref WVOcdqdeESMtrcshmTGZlXKvGIJ, ref SyxpaTEbNBHyRbjBbNknpgXiroQe);
					}
					List<WaitCallback> syxpaTEbNBHyRbjBbNknpgXiroQe = SyxpaTEbNBHyRbjBbNknpgXiroQe;
					int count = syxpaTEbNBHyRbjBbNknpgXiroQe.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							syxpaTEbNBHyRbjBbNknpgXiroQe[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, true);
						}
					}
					syxpaTEbNBHyRbjBbNknpgXiroQe.Clear();
				}
				lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
				{
					WVOcdqdeESMtrcshmTGZlXKvGIJ.Clear();
					SyxpaTEbNBHyRbjBbNknpgXiroQe.Clear();
				}
				LAuTHorXUliRFekupmkDXpnwQQl = false;
				gohngYhiRgfBkFJRFnXhUcscROs = false;
			}

			private void lXckUdfbsofgpEgwONtWzlzDuK()
			{
				tjbaiMrJifoIDiaaEAFkHcnphSvb = null;
				QAEJOaLDOSfoppCHoZgTiPpUQqZ = false;
				LAuTHorXUliRFekupmkDXpnwQQl = true;
			}

			private void lbcUDcmRQZyNiOiSqzZkkqatLNY()
			{
				lXckUdfbsofgpEgwONtWzlzDuK();
				try
				{
					XnXmEMyLMocEPKOmdGmUhmdRmHrS.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
				GC.SuppressFinalize(this);
			}

			~AwGZWVvgsgdNJrBiTbTlfsIfyJy()
			{
				JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
			}

			protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
			{
				if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
				{
					lbcUDcmRQZyNiOiSqzZkkqatLNY();
					nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
				}
			}
		}

		private static AwGZWVvgsgdNJrBiTbTlfsIfyJy tiDFHUUbUEPKhkwftJvpnCRKlbt;

		private static int WaYgmwGxPxfQBTNRcdJkfwUEwAnd;

		private static AwGZWVvgsgdNJrBiTbTlfsIfyJy queue
		{
			get
			{
				return tiDFHUUbUEPKhkwftJvpnCRKlbt ?? (tiDFHUUbUEPKhkwftJvpnCRKlbt = new AwGZWVvgsgdNJrBiTbTlfsIfyJy());
			}
		}

		static SeQwWIGiDYtqllJossYMxOuKrPx()
		{
			WaYgmwGxPxfQBTNRcdJkfwUEwAnd = 0;
			AppDomain.CurrentDomain.DomainUnload -= UfbaRaRWxIOqJPKtRYXHzGcgQDr;
			AppDomain.CurrentDomain.DomainUnload += UfbaRaRWxIOqJPKtRYXHzGcgQDr;
		}

		private static void UfbaRaRWxIOqJPKtRYXHzGcgQDr(object P_0, EventArgs P_1)
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ();
			AppDomain.CurrentDomain.DomainUnload -= UfbaRaRWxIOqJPKtRYXHzGcgQDr;
		}

		public static void bssFklbWbNpIXrhWvOPUCZaOkbTj()
		{
			WaYgmwGxPxfQBTNRcdJkfwUEwAnd++;
		}

		public static void XvQjSzWsSmwcTFKXuxgmOlebnyr()
		{
			WaYgmwGxPxfQBTNRcdJkfwUEwAnd--;
			if (WaYgmwGxPxfQBTNRcdJkfwUEwAnd < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", true);
			}
			if (WaYgmwGxPxfQBTNRcdJkfwUEwAnd == 0)
			{
				JGfOaxGMMubjxaprhTWpWgtvAPZ();
			}
		}

		public static void RZoXgCweZkubcxEHjLTmjQDJWlZ(WaitCallback P_0)
		{
			queue.RZoXgCweZkubcxEHjLTmjQDJWlZ(P_0);
		}

		public static void SwQNhntQSgOcYlIglieTMwqyFkUA()
		{
			queue.SwQNhntQSgOcYlIglieTMwqyFkUA();
		}

		public static bool JNpqtseTgVDsLidqlJBYdNCXmOC()
		{
			return queue.JNpqtseTgVDsLidqlJBYdNCXmOC();
		}

		private static void JGfOaxGMMubjxaprhTWpWgtvAPZ()
		{
			if (tiDFHUUbUEPKhkwftJvpnCRKlbt != null)
			{
				tiDFHUUbUEPKhkwftJvpnCRKlbt.Dispose();
			}
			tiDFHUUbUEPKhkwftJvpnCRKlbt = null;
			WaYgmwGxPxfQBTNRcdJkfwUEwAnd = 0;
		}
	}

	private fISvCZukncdvvcYLzoIMuIkPrrm sWPNMgaxJTfWEHLbOUfiDDxIPgJ;

	private T dYpjEhQFlEPsKuxeQlORCpnPfnS;

	private WaitCallback uQapxaGEDQOujgaUJWGffIJYTlv;

	private object jkLokmyNuOlUdpUyyeSnDVevISp;

	private Func<T> oJIhrsKkuhBjTBoYkhUtCOQpTiB;

	private bool RkwccRJjJMICfThbRFXTBWyLNrBM;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public bool isRunning
	{
		get
		{
			if (sWPNMgaxJTfWEHLbOUfiDDxIPgJ != fISvCZukncdvvcYLzoIMuIkPrrm.pDmAWBTIDVZBnWKxYJyfiDyUMTa)
			{
				return sWPNMgaxJTfWEHLbOUfiDDxIPgJ == fISvCZukncdvvcYLzoIMuIkPrrm.onNsFRyuVnGKDkqwwQZxGytEtYO;
			}
			return true;
		}
	}

	public T result
	{
		get
		{
			return dYpjEhQFlEPsKuxeQlORCpnPfnS;
		}
	}

	public bool xRKBBblbOUOOMSzhwnDVTLoUIDwi()
	{
		bool flag = sWPNMgaxJTfWEHLbOUfiDDxIPgJ == fISvCZukncdvvcYLzoIMuIkPrrm.onNsFRyuVnGKDkqwwQZxGytEtYO;
		if (flag)
		{
			sWPNMgaxJTfWEHLbOUfiDDxIPgJ = fISvCZukncdvvcYLzoIMuIkPrrm.rFobbojpJYIzanfETPcXNoEpUYjh;
		}
		return flag;
	}

	public LLwWBrlwrzAzBgxVkRCTkMClAyJ(bool useSharedThread, Func<T> resultDelegate)
	{
		RkwccRJjJMICfThbRFXTBWyLNrBM = useSharedThread;
		if (resultDelegate == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		oJIhrsKkuhBjTBoYkhUtCOQpTiB = resultDelegate;
		uQapxaGEDQOujgaUJWGffIJYTlv = aXBEkLWkGgKhNFHjXgsTDiTstTf;
		jkLokmyNuOlUdpUyyeSnDVevISp = new object();
		sWPNMgaxJTfWEHLbOUfiDDxIPgJ = fISvCZukncdvvcYLzoIMuIkPrrm.rFobbojpJYIzanfETPcXNoEpUYjh;
		if (useSharedThread)
		{
			SeQwWIGiDYtqllJossYMxOuKrPx.bssFklbWbNpIXrhWvOPUCZaOkbTj();
		}
	}

	public bool SFnUlcdGONKjYCbrEBAjYDBcYmz()
	{
		lock (jkLokmyNuOlUdpUyyeSnDVevISp)
		{
			if (sWPNMgaxJTfWEHLbOUfiDDxIPgJ == fISvCZukncdvvcYLzoIMuIkPrrm.pDmAWBTIDVZBnWKxYJyfiDyUMTa)
			{
				return false;
			}
			dYpjEhQFlEPsKuxeQlORCpnPfnS = default(T);
			sWPNMgaxJTfWEHLbOUfiDDxIPgJ = fISvCZukncdvvcYLzoIMuIkPrrm.pDmAWBTIDVZBnWKxYJyfiDyUMTa;
		}
		if (RkwccRJjJMICfThbRFXTBWyLNrBM)
		{
			SeQwWIGiDYtqllJossYMxOuKrPx.RZoXgCweZkubcxEHjLTmjQDJWlZ(uQapxaGEDQOujgaUJWGffIJYTlv);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(uQapxaGEDQOujgaUJWGffIJYTlv, this);
		}
		return true;
	}

	public void fWzuAFjFXxdRoqxypOAIFkBEHOX()
	{
		lock (jkLokmyNuOlUdpUyyeSnDVevISp)
		{
			dYpjEhQFlEPsKuxeQlORCpnPfnS = default(T);
			sWPNMgaxJTfWEHLbOUfiDDxIPgJ = fISvCZukncdvvcYLzoIMuIkPrrm.rFobbojpJYIzanfETPcXNoEpUYjh;
		}
	}

	private void aXBEkLWkGgKhNFHjXgsTDiTstTf(object P_0)
	{
		lock (jkLokmyNuOlUdpUyyeSnDVevISp)
		{
			if (sWPNMgaxJTfWEHLbOUfiDDxIPgJ == fISvCZukncdvvcYLzoIMuIkPrrm.pDmAWBTIDVZBnWKxYJyfiDyUMTa)
			{
				dYpjEhQFlEPsKuxeQlORCpnPfnS = oJIhrsKkuhBjTBoYkhUtCOQpTiB();
				sWPNMgaxJTfWEHLbOUfiDDxIPgJ = fISvCZukncdvvcYLzoIMuIkPrrm.onNsFRyuVnGKDkqwwQZxGytEtYO;
			}
		}
	}

	public void JGfOaxGMMubjxaprhTWpWgtvAPZ()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~LLwWBrlwrzAzBgxVkRCTkMClAyJ()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			if (P_0)
			{
				fWzuAFjFXxdRoqxypOAIFkBEHOX();
			}
			if (RkwccRJjJMICfThbRFXTBWyLNrBM)
			{
				SeQwWIGiDYtqllJossYMxOuKrPx.XvQjSzWsSmwcTFKXuxgmOlebnyr();
			}
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}
	}
}
