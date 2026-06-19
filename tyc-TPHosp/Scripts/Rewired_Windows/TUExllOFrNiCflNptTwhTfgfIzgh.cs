using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class TUExllOFrNiCflNptTwhTfgfIzgh<T>
{
	private enum OBwyXzjlXcuDvRixeTiHkqBiPNu
	{
		lcELicSuRuYVUoIwSUjbTsetXSS = 0,
		jeSDuTDeNpraLxPTNwxTATOQkHJH = 1,
		wshnBPRNlNfrWfAbhbLJpBBIPjL = 2
	}

	private static class NiMdokZLCIHlByFdMdxUjGKyOtP
	{
		private class BplGdegbfeDYjLakqnvaZTKuCKtd : IDisposable
		{
			private sealed class iZXjgnAjdYnuGwvxIJGquLjNhzZ
			{
				public ManualResetEvent FhnbSZLauzaKlSUPLOJUzXnqqDw;

				public BplGdegbfeDYjLakqnvaZTKuCKtd atnkeqgXxTBLxuTqVeTupqRLlmp;

				public void JAaHsCvMGkcPQooIPVNZGglGDvF()
				{
					FhnbSZLauzaKlSUPLOJUzXnqqDw.Set();
					atnkeqgXxTBLxuTqVeTupqRLlmp.lHnqpiIbbhbzZCOnruWTPyxnQQK();
				}
			}

			private readonly object WfTbITFnDgahnloEWtIracmCfqy;

			private List<WaitCallback> UliZHeSGMgjUHdnDdigxRIazjFeB;

			private List<WaitCallback> ShNOcPdVFtVMrefWgOONPxwqvcp;

			private Thread pxZsAIIeiXffxhtGRXzEPyDdJBG;

			private AutoResetEvent XfEsIGZQfUztyZECeSwWXFRRSON;

			private bool aKXMYfSHmMiEeKnFIffNjGPoRKT;

			private bool HGEGfciUGRfJrvvGapGpzoHoKFWD;

			private bool EGqfjkJuEoKHNxyvfiMnGTVUmneE;

			private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

			public BplGdegbfeDYjLakqnvaZTKuCKtd()
			{
				WfTbITFnDgahnloEWtIracmCfqy = new object();
				UliZHeSGMgjUHdnDdigxRIazjFeB = new List<WaitCallback>();
				ShNOcPdVFtVMrefWgOONPxwqvcp = new List<WaitCallback>();
				XfEsIGZQfUztyZECeSwWXFRRSON = new AutoResetEvent(initialState: false);
			}

			public void BEYqpCBOsWaJIfeosClMpGoBpRaY(WaitCallback P_0)
			{
				if (EhDmNHbdNOhARNgJSMpMFgeqbsn())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (WfTbITFnDgahnloEWtIracmCfqy)
					{
						UliZHeSGMgjUHdnDdigxRIazjFeB.Add(P_0);
					}
					XfEsIGZQfUztyZECeSwWXFRRSON.Set();
				}
			}

			public void SjeFHtSMsWLEqmQOeYMhtWmsngz()
			{
				hdAjwyFmQptBELqMvPDOROQdXQv();
			}

			public bool ZWHXmzFoPzsdydQwCbiSIgZvLxH()
			{
				return EhDmNHbdNOhARNgJSMpMFgeqbsn();
			}

			private bool EhDmNHbdNOhARNgJSMpMFgeqbsn()
			{
				if (EGqfjkJuEoKHNxyvfiMnGTVUmneE)
				{
					return false;
				}
				if (HGEGfciUGRfJrvvGapGpzoHoKFWD)
				{
					return false;
				}
				if (aKXMYfSHmMiEeKnFIffNjGPoRKT)
				{
					return true;
				}
				if (pxZsAIIeiXffxhtGRXzEPyDdJBG != null)
				{
					return true;
				}
				try
				{
					iZXjgnAjdYnuGwvxIJGquLjNhzZ iZXjgnAjdYnuGwvxIJGquLjNhzZ2 = new iZXjgnAjdYnuGwvxIJGquLjNhzZ();
					iZXjgnAjdYnuGwvxIJGquLjNhzZ2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
					iZXjgnAjdYnuGwvxIJGquLjNhzZ2.FhnbSZLauzaKlSUPLOJUzXnqqDw = new ManualResetEvent(initialState: false);
					pxZsAIIeiXffxhtGRXzEPyDdJBG = new Thread(iZXjgnAjdYnuGwvxIJGquLjNhzZ2.JAaHsCvMGkcPQooIPVNZGglGDvF);
					pxZsAIIeiXffxhtGRXzEPyDdJBG.Start();
					iZXjgnAjdYnuGwvxIJGquLjNhzZ2.FhnbSZLauzaKlSUPLOJUzXnqqDw.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					pxZsAIIeiXffxhtGRXzEPyDdJBG = null;
					EGqfjkJuEoKHNxyvfiMnGTVUmneE = true;
					return false;
				}
			}

			private void lHnqpiIbbhbzZCOnruWTPyxnQQK()
			{
				aKXMYfSHmMiEeKnFIffNjGPoRKT = true;
				while (!HGEGfciUGRfJrvvGapGpzoHoKFWD)
				{
					XfEsIGZQfUztyZECeSwWXFRRSON.WaitOne();
					if (HGEGfciUGRfJrvvGapGpzoHoKFWD)
					{
						break;
					}
					lock (WfTbITFnDgahnloEWtIracmCfqy)
					{
						MiscTools.Swap(ref UliZHeSGMgjUHdnDdigxRIazjFeB, ref ShNOcPdVFtVMrefWgOONPxwqvcp);
					}
					List<WaitCallback> shNOcPdVFtVMrefWgOONPxwqvcp = ShNOcPdVFtVMrefWgOONPxwqvcp;
					int count = shNOcPdVFtVMrefWgOONPxwqvcp.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							shNOcPdVFtVMrefWgOONPxwqvcp[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					shNOcPdVFtVMrefWgOONPxwqvcp.Clear();
				}
				lock (WfTbITFnDgahnloEWtIracmCfqy)
				{
					UliZHeSGMgjUHdnDdigxRIazjFeB.Clear();
					ShNOcPdVFtVMrefWgOONPxwqvcp.Clear();
				}
				HGEGfciUGRfJrvvGapGpzoHoKFWD = false;
				aKXMYfSHmMiEeKnFIffNjGPoRKT = false;
			}

			private void jzdlSEQkdYtGUiGCfzvVrqTvoxz()
			{
				pxZsAIIeiXffxhtGRXzEPyDdJBG = null;
				EGqfjkJuEoKHNxyvfiMnGTVUmneE = false;
				HGEGfciUGRfJrvvGapGpzoHoKFWD = true;
			}

			private void hdAjwyFmQptBELqMvPDOROQdXQv()
			{
				jzdlSEQkdYtGUiGCfzvVrqTvoxz();
				try
				{
					XfEsIGZQfUztyZECeSwWXFRRSON.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				LLOFbzNISIbRkZTwkaVnsPpYig(true);
				GC.SuppressFinalize(this);
			}

			~BplGdegbfeDYjLakqnvaZTKuCKtd()
			{
				LLOFbzNISIbRkZTwkaVnsPpYig(false);
			}

			protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
			{
				if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
				{
					hdAjwyFmQptBELqMvPDOROQdXQv();
					dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
				}
			}
		}

		private static BplGdegbfeDYjLakqnvaZTKuCKtd fWjtOMdGxqnKVnBliJIDSAxCaYA;

		private static int OnqUvsUqDJlGzGsnbrjCZswYBZW;

		private static BplGdegbfeDYjLakqnvaZTKuCKtd queue => fWjtOMdGxqnKVnBliJIDSAxCaYA ?? (fWjtOMdGxqnKVnBliJIDSAxCaYA = new BplGdegbfeDYjLakqnvaZTKuCKtd());

		static NiMdokZLCIHlByFdMdxUjGKyOtP()
		{
			OnqUvsUqDJlGzGsnbrjCZswYBZW = 0;
			AppDomain.CurrentDomain.DomainUnload -= YhZsnucSjafPzGdXOpbjYyScqEE;
			AppDomain.CurrentDomain.DomainUnload += YhZsnucSjafPzGdXOpbjYyScqEE;
		}

		private static void YhZsnucSjafPzGdXOpbjYyScqEE(object P_0, EventArgs P_1)
		{
			LLOFbzNISIbRkZTwkaVnsPpYig();
			AppDomain.CurrentDomain.DomainUnload -= YhZsnucSjafPzGdXOpbjYyScqEE;
		}

		public static void lQMChnjWzldgfeRkgnvaevMEiWu()
		{
			OnqUvsUqDJlGzGsnbrjCZswYBZW++;
		}

		public static void VImjZhxewQJPdOVnvtPYfnEdNqE()
		{
			OnqUvsUqDJlGzGsnbrjCZswYBZW--;
			if (OnqUvsUqDJlGzGsnbrjCZswYBZW < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (OnqUvsUqDJlGzGsnbrjCZswYBZW == 0)
			{
				LLOFbzNISIbRkZTwkaVnsPpYig();
			}
		}

		public static void BEYqpCBOsWaJIfeosClMpGoBpRaY(WaitCallback P_0)
		{
			queue.BEYqpCBOsWaJIfeosClMpGoBpRaY(P_0);
		}

		public static void SjeFHtSMsWLEqmQOeYMhtWmsngz()
		{
			queue.SjeFHtSMsWLEqmQOeYMhtWmsngz();
		}

		public static bool ZWHXmzFoPzsdydQwCbiSIgZvLxH()
		{
			return queue.ZWHXmzFoPzsdydQwCbiSIgZvLxH();
		}

		private static void LLOFbzNISIbRkZTwkaVnsPpYig()
		{
			if (fWjtOMdGxqnKVnBliJIDSAxCaYA != null)
			{
				fWjtOMdGxqnKVnBliJIDSAxCaYA.Dispose();
			}
			fWjtOMdGxqnKVnBliJIDSAxCaYA = null;
			OnqUvsUqDJlGzGsnbrjCZswYBZW = 0;
		}
	}

	private OBwyXzjlXcuDvRixeTiHkqBiPNu oIdsheBRHvlCiGeNJVLKwnRSlNe;

	private T pAHLDxxKvwWemduSBABdrtRFvev;

	private WaitCallback iWJLmGxRkATRajaGxiTgAzQvcIb;

	private object zrvbWkHMkcXMNovKdrSHskCzaDOb;

	private Func<T> sVgGVmnucTqszULizCZTityxtYie;

	private bool VyUUADuRVoUhFAtNCvhdjDINZsa;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public bool isRunning
	{
		get
		{
			if (oIdsheBRHvlCiGeNJVLKwnRSlNe != OBwyXzjlXcuDvRixeTiHkqBiPNu.jeSDuTDeNpraLxPTNwxTATOQkHJH)
			{
				return oIdsheBRHvlCiGeNJVLKwnRSlNe == OBwyXzjlXcuDvRixeTiHkqBiPNu.wshnBPRNlNfrWfAbhbLJpBBIPjL;
			}
			return true;
		}
	}

	public T result => pAHLDxxKvwWemduSBABdrtRFvev;

	public bool lVgWjrQkCsFlsaFVzSjplyEWLEJg()
	{
		bool flag = oIdsheBRHvlCiGeNJVLKwnRSlNe == OBwyXzjlXcuDvRixeTiHkqBiPNu.wshnBPRNlNfrWfAbhbLJpBBIPjL;
		if (flag)
		{
			oIdsheBRHvlCiGeNJVLKwnRSlNe = OBwyXzjlXcuDvRixeTiHkqBiPNu.lcELicSuRuYVUoIwSUjbTsetXSS;
		}
		return flag;
	}

	public TUExllOFrNiCflNptTwhTfgfIzgh(bool useSharedThread, Func<T> resultDelegate)
	{
		VyUUADuRVoUhFAtNCvhdjDINZsa = useSharedThread;
		if (resultDelegate == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		sVgGVmnucTqszULizCZTityxtYie = resultDelegate;
		iWJLmGxRkATRajaGxiTgAzQvcIb = uBlQeVrgeMnhjMzHKpMdmznmLsE;
		zrvbWkHMkcXMNovKdrSHskCzaDOb = new object();
		oIdsheBRHvlCiGeNJVLKwnRSlNe = OBwyXzjlXcuDvRixeTiHkqBiPNu.lcELicSuRuYVUoIwSUjbTsetXSS;
		if (useSharedThread)
		{
			NiMdokZLCIHlByFdMdxUjGKyOtP.lQMChnjWzldgfeRkgnvaevMEiWu();
		}
	}

	public bool UyHkmeYMKxbRaLGZZmHNfcnwklW()
	{
		lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
		{
			if (oIdsheBRHvlCiGeNJVLKwnRSlNe == OBwyXzjlXcuDvRixeTiHkqBiPNu.jeSDuTDeNpraLxPTNwxTATOQkHJH)
			{
				return false;
			}
			pAHLDxxKvwWemduSBABdrtRFvev = default(T);
			oIdsheBRHvlCiGeNJVLKwnRSlNe = OBwyXzjlXcuDvRixeTiHkqBiPNu.jeSDuTDeNpraLxPTNwxTATOQkHJH;
		}
		if (VyUUADuRVoUhFAtNCvhdjDINZsa)
		{
			NiMdokZLCIHlByFdMdxUjGKyOtP.BEYqpCBOsWaJIfeosClMpGoBpRaY(iWJLmGxRkATRajaGxiTgAzQvcIb);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(iWJLmGxRkATRajaGxiTgAzQvcIb, this);
		}
		return true;
	}

	public void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
		{
			pAHLDxxKvwWemduSBABdrtRFvev = default(T);
			oIdsheBRHvlCiGeNJVLKwnRSlNe = OBwyXzjlXcuDvRixeTiHkqBiPNu.lcELicSuRuYVUoIwSUjbTsetXSS;
		}
	}

	private void uBlQeVrgeMnhjMzHKpMdmznmLsE(object P_0)
	{
		lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
		{
			if (oIdsheBRHvlCiGeNJVLKwnRSlNe == OBwyXzjlXcuDvRixeTiHkqBiPNu.jeSDuTDeNpraLxPTNwxTATOQkHJH)
			{
				pAHLDxxKvwWemduSBABdrtRFvev = sVgGVmnucTqszULizCZTityxtYie();
				oIdsheBRHvlCiGeNJVLKwnRSlNe = OBwyXzjlXcuDvRixeTiHkqBiPNu.wshnBPRNlNfrWfAbhbLJpBBIPjL;
			}
		}
	}

	public void LLOFbzNISIbRkZTwkaVnsPpYig()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~TUExllOFrNiCflNptTwhTfgfIzgh()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			if (P_0)
			{
				rKJfCRBWFLQsKCjGykmcumzKLPwE();
			}
			if (VyUUADuRVoUhFAtNCvhdjDINZsa)
			{
				NiMdokZLCIHlByFdMdxUjGKyOtP.VImjZhxewQJPdOVnvtPYfnEdNqE();
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}
}
