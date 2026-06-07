using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class SmnfRaZRTCRKUNzdKVQSwqJahva<T>
{
	private enum ieIiZvHzgSVEWGPZdohJOlvZdsX
	{
		oNnPbpRqvbqQfEhkdTyGohPkVZI = 0,
		sjvECGlhwmuwedRhiFKkapbDPIZ = 1,
		jiMgPMJEvAxfKwBQSDPqHQcKBJzw = 2
	}

	private sealed class LwrpDHobBHpPvvemtOUFUIbiMeW
	{
		private class YNvNvFRpFXuStQBHsZNuxXTlusa : IDisposable
		{
			private sealed class ATZgVkFUhGLVFBEzffcvwSACgfre
			{
				public ManualResetEvent MYIFHQKTWsOCGarDcQrfQXErEDq;

				public YNvNvFRpFXuStQBHsZNuxXTlusa jCCESxhkXKXRASiiyhhDQRyWTmj;

				public void YnZNxPazodasfIBKgFdshwERiVTh()
				{
					MYIFHQKTWsOCGarDcQrfQXErEDq.Set();
					jCCESxhkXKXRASiiyhhDQRyWTmj.owGDudTvLodSwmxQQwXsLIBmONA();
				}
			}

			private readonly object DYqmLYQWtnCkUZCOjwXSRkHXDqs;

			private List<WaitCallback> LxPdYpHscnUrqZTSWGQWbTbeNGu;

			private List<WaitCallback> FxuFgCeudkABECUnXieiDuIpRldR;

			private Thread mkmmuLREzAzMCXWZqBwjgaloTtM;

			private AutoResetEvent ImGeKJHQaXTlSifWLMmDdwoUhCIG;

			private bool zfuDaVhLbHWylIcbnlFaoUjfpPZJ;

			private bool GsnLfSHyJKHEkHGPXeQtJoOjDKq;

			private bool TRXZbndwqtNyqGfCCqGGgmPXtEu;

			private bool euujVPFzGztViWDbYvUutBvFQFP;

			public YNvNvFRpFXuStQBHsZNuxXTlusa()
			{
				DYqmLYQWtnCkUZCOjwXSRkHXDqs = new object();
				LxPdYpHscnUrqZTSWGQWbTbeNGu = new List<WaitCallback>();
				FxuFgCeudkABECUnXieiDuIpRldR = new List<WaitCallback>();
				ImGeKJHQaXTlSifWLMmDdwoUhCIG = new AutoResetEvent(initialState: false);
			}

			public void ORhDOLSTYBLkpUdmXRTvzqTETTm(WaitCallback P_0)
			{
				if (BVmTKMsAVVqdkfwNjSwlgNFzTsh())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
					{
						LxPdYpHscnUrqZTSWGQWbTbeNGu.Add(P_0);
					}
					ImGeKJHQaXTlSifWLMmDdwoUhCIG.Set();
				}
			}

			public void TXRFvoGNqHfLBTUKBQaQBWpddftx()
			{
				ittAOdUQomCDzgrOENrzyidePKlX();
			}

			public bool GLqFjpJWOmaiIIPQEPXLKjDgABxr()
			{
				return BVmTKMsAVVqdkfwNjSwlgNFzTsh();
			}

			private bool BVmTKMsAVVqdkfwNjSwlgNFzTsh()
			{
				if (TRXZbndwqtNyqGfCCqGGgmPXtEu)
				{
					return false;
				}
				if (GsnLfSHyJKHEkHGPXeQtJoOjDKq)
				{
					return false;
				}
				if (zfuDaVhLbHWylIcbnlFaoUjfpPZJ)
				{
					return true;
				}
				if (mkmmuLREzAzMCXWZqBwjgaloTtM != null)
				{
					return true;
				}
				try
				{
					ATZgVkFUhGLVFBEzffcvwSACgfre aTZgVkFUhGLVFBEzffcvwSACgfre = new ATZgVkFUhGLVFBEzffcvwSACgfre();
					aTZgVkFUhGLVFBEzffcvwSACgfre.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
					aTZgVkFUhGLVFBEzffcvwSACgfre.MYIFHQKTWsOCGarDcQrfQXErEDq = new ManualResetEvent(initialState: false);
					mkmmuLREzAzMCXWZqBwjgaloTtM = new Thread(aTZgVkFUhGLVFBEzffcvwSACgfre.YnZNxPazodasfIBKgFdshwERiVTh);
					mkmmuLREzAzMCXWZqBwjgaloTtM.Start();
					aTZgVkFUhGLVFBEzffcvwSACgfre.MYIFHQKTWsOCGarDcQrfQXErEDq.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					mkmmuLREzAzMCXWZqBwjgaloTtM = null;
					TRXZbndwqtNyqGfCCqGGgmPXtEu = true;
					return false;
				}
			}

			private void owGDudTvLodSwmxQQwXsLIBmONA()
			{
				zfuDaVhLbHWylIcbnlFaoUjfpPZJ = true;
				while (!GsnLfSHyJKHEkHGPXeQtJoOjDKq)
				{
					ImGeKJHQaXTlSifWLMmDdwoUhCIG.WaitOne();
					if (GsnLfSHyJKHEkHGPXeQtJoOjDKq)
					{
						break;
					}
					lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
					{
						MiscTools.Swap(ref LxPdYpHscnUrqZTSWGQWbTbeNGu, ref FxuFgCeudkABECUnXieiDuIpRldR);
					}
					List<WaitCallback> fxuFgCeudkABECUnXieiDuIpRldR = FxuFgCeudkABECUnXieiDuIpRldR;
					int count = fxuFgCeudkABECUnXieiDuIpRldR.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							fxuFgCeudkABECUnXieiDuIpRldR[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					fxuFgCeudkABECUnXieiDuIpRldR.Clear();
				}
				lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
				{
					LxPdYpHscnUrqZTSWGQWbTbeNGu.Clear();
					FxuFgCeudkABECUnXieiDuIpRldR.Clear();
				}
				GsnLfSHyJKHEkHGPXeQtJoOjDKq = false;
				zfuDaVhLbHWylIcbnlFaoUjfpPZJ = false;
			}

			private void ohSwRPToPZIEfMHUGRRiWGqiFxt()
			{
				mkmmuLREzAzMCXWZqBwjgaloTtM = null;
				TRXZbndwqtNyqGfCCqGGgmPXtEu = false;
				GsnLfSHyJKHEkHGPXeQtJoOjDKq = true;
			}

			private void ittAOdUQomCDzgrOENrzyidePKlX()
			{
				ohSwRPToPZIEfMHUGRRiWGqiFxt();
				try
				{
					ImGeKJHQaXTlSifWLMmDdwoUhCIG.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
				GC.SuppressFinalize(this);
			}

			~YNvNvFRpFXuStQBHsZNuxXTlusa()
			{
				KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
			}

			protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
			{
				if (!euujVPFzGztViWDbYvUutBvFQFP)
				{
					ittAOdUQomCDzgrOENrzyidePKlX();
					euujVPFzGztViWDbYvUutBvFQFP = true;
				}
			}
		}

		private static LwrpDHobBHpPvvemtOUFUIbiMeW vcPdtGGvPwkmRWvcNuQMsgPoctMc;

		private YNvNvFRpFXuStQBHsZNuxXTlusa cJAwPDmiwjgrmZsTHCjsBjQHyaEH;

		private int TYNrczNStGChAqXxYRTdkTPPRJG;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		private static LwrpDHobBHpPvvemtOUFUIbiMeW instance => vcPdtGGvPwkmRWvcNuQMsgPoctMc ?? new LwrpDHobBHpPvvemtOUFUIbiMeW();

		private YNvNvFRpFXuStQBHsZNuxXTlusa queue => cJAwPDmiwjgrmZsTHCjsBjQHyaEH ?? (cJAwPDmiwjgrmZsTHCjsBjQHyaEH = new YNvNvFRpFXuStQBHsZNuxXTlusa());

		private LwrpDHobBHpPvvemtOUFUIbiMeW()
		{
			vcPdtGGvPwkmRWvcNuQMsgPoctMc?.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
			vcPdtGGvPwkmRWvcNuQMsgPoctMc = this;
		}

		private void FXosUZAwgJeHfYnjVmBJqlfNSQc()
		{
			TYNrczNStGChAqXxYRTdkTPPRJG++;
		}

		private void fHLArJazfiiDuwwGNPABuGXCGmi()
		{
			TYNrczNStGChAqXxYRTdkTPPRJG--;
			if (TYNrczNStGChAqXxYRTdkTPPRJG < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (TYNrczNStGChAqXxYRTdkTPPRJG == 0)
			{
				KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
			}
		}

		private void QSljyjItkKTWYvAXfYLukHYhptj(WaitCallback P_0)
		{
			queue.ORhDOLSTYBLkpUdmXRTvzqTETTm(P_0);
		}

		private void JMDuTotOleIxVJfwWptgczggJuP()
		{
			queue.TXRFvoGNqHfLBTUKBQaQBWpddftx();
		}

		private bool fcsgSGoBNxtjBNJSvLKFZzjVBfS()
		{
			return queue.GLqFjpJWOmaiIIPQEPXLKjDgABxr();
		}

		private void KRgasgBmyLeCeDGJhNGqwMeOqCwJ()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
			GC.SuppressFinalize(this);
		}

		~LwrpDHobBHpPvvemtOUFUIbiMeW()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		private void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (!euujVPFzGztViWDbYvUutBvFQFP)
			{
				if (P_0 && cJAwPDmiwjgrmZsTHCjsBjQHyaEH != null)
				{
					cJAwPDmiwjgrmZsTHCjsBjQHyaEH.Dispose();
					cJAwPDmiwjgrmZsTHCjsBjQHyaEH = null;
				}
				TYNrczNStGChAqXxYRTdkTPPRJG = 0;
				if (vcPdtGGvPwkmRWvcNuQMsgPoctMc == this)
				{
					vcPdtGGvPwkmRWvcNuQMsgPoctMc = null;
				}
				euujVPFzGztViWDbYvUutBvFQFP = true;
			}
		}

		public static void wdtRiaqmTqYhAMLmXeLNhLzJJeuU()
		{
			instance.FXosUZAwgJeHfYnjVmBJqlfNSQc();
		}

		public static void CXTdVgahOHdHOeqfYwvbMhluTqY()
		{
			vcPdtGGvPwkmRWvcNuQMsgPoctMc?.fHLArJazfiiDuwwGNPABuGXCGmi();
		}

		public static void ORhDOLSTYBLkpUdmXRTvzqTETTm(WaitCallback P_0)
		{
			instance.QSljyjItkKTWYvAXfYLukHYhptj(P_0);
		}
	}

	private ieIiZvHzgSVEWGPZdohJOlvZdsX nYOFGdkAjsWrTVqPgOxznDsLxbyo;

	private T iPcCjgqELzbsHgRMsehQDQkCsyrA;

	private WaitCallback tIfcxbGihlHDauFsvXKgPfSPacGb;

	private object eQuodSQpbSdsKiGAacuPzpuZcE;

	private Func<T> jFZcbvyXMYLcAuZeWhduKdDywAw;

	private bool YExmSIdDrhhawcKZrBCSWczMfsy;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public bool isRunning
	{
		get
		{
			if (nYOFGdkAjsWrTVqPgOxznDsLxbyo != ieIiZvHzgSVEWGPZdohJOlvZdsX.sjvECGlhwmuwedRhiFKkapbDPIZ)
			{
				return nYOFGdkAjsWrTVqPgOxznDsLxbyo == ieIiZvHzgSVEWGPZdohJOlvZdsX.jiMgPMJEvAxfKwBQSDPqHQcKBJzw;
			}
			return true;
		}
	}

	public T result => iPcCjgqELzbsHgRMsehQDQkCsyrA;

	public bool wcZXiwBuSxlGFrbXURQEZElVWiH()
	{
		bool flag = nYOFGdkAjsWrTVqPgOxznDsLxbyo == ieIiZvHzgSVEWGPZdohJOlvZdsX.jiMgPMJEvAxfKwBQSDPqHQcKBJzw;
		if (flag)
		{
			nYOFGdkAjsWrTVqPgOxznDsLxbyo = ieIiZvHzgSVEWGPZdohJOlvZdsX.oNnPbpRqvbqQfEhkdTyGohPkVZI;
		}
		return flag;
	}

	public SmnfRaZRTCRKUNzdKVQSwqJahva(bool useSharedThread, Func<T> resultDelegate)
	{
		YExmSIdDrhhawcKZrBCSWczMfsy = useSharedThread;
		if (resultDelegate == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		jFZcbvyXMYLcAuZeWhduKdDywAw = resultDelegate;
		tIfcxbGihlHDauFsvXKgPfSPacGb = jpCSnUopIVpBQyqZzezYXOIbyIW;
		eQuodSQpbSdsKiGAacuPzpuZcE = new object();
		nYOFGdkAjsWrTVqPgOxznDsLxbyo = ieIiZvHzgSVEWGPZdohJOlvZdsX.oNnPbpRqvbqQfEhkdTyGohPkVZI;
		if (useSharedThread)
		{
			LwrpDHobBHpPvvemtOUFUIbiMeW.wdtRiaqmTqYhAMLmXeLNhLzJJeuU();
		}
	}

	public bool HnocEhRkacOxHhLLsmQmCGWhJlU()
	{
		lock (eQuodSQpbSdsKiGAacuPzpuZcE)
		{
			if (nYOFGdkAjsWrTVqPgOxznDsLxbyo == ieIiZvHzgSVEWGPZdohJOlvZdsX.sjvECGlhwmuwedRhiFKkapbDPIZ)
			{
				return false;
			}
			iPcCjgqELzbsHgRMsehQDQkCsyrA = default(T);
			nYOFGdkAjsWrTVqPgOxznDsLxbyo = ieIiZvHzgSVEWGPZdohJOlvZdsX.sjvECGlhwmuwedRhiFKkapbDPIZ;
		}
		if (YExmSIdDrhhawcKZrBCSWczMfsy)
		{
			LwrpDHobBHpPvvemtOUFUIbiMeW.ORhDOLSTYBLkpUdmXRTvzqTETTm(tIfcxbGihlHDauFsvXKgPfSPacGb);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(tIfcxbGihlHDauFsvXKgPfSPacGb, this);
		}
		return true;
	}

	public void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		lock (eQuodSQpbSdsKiGAacuPzpuZcE)
		{
			iPcCjgqELzbsHgRMsehQDQkCsyrA = default(T);
			nYOFGdkAjsWrTVqPgOxznDsLxbyo = ieIiZvHzgSVEWGPZdohJOlvZdsX.oNnPbpRqvbqQfEhkdTyGohPkVZI;
		}
	}

	private void jpCSnUopIVpBQyqZzezYXOIbyIW(object P_0)
	{
		lock (eQuodSQpbSdsKiGAacuPzpuZcE)
		{
			if (nYOFGdkAjsWrTVqPgOxznDsLxbyo == ieIiZvHzgSVEWGPZdohJOlvZdsX.sjvECGlhwmuwedRhiFKkapbDPIZ)
			{
				iPcCjgqELzbsHgRMsehQDQkCsyrA = jFZcbvyXMYLcAuZeWhduKdDywAw();
				nYOFGdkAjsWrTVqPgOxznDsLxbyo = ieIiZvHzgSVEWGPZdohJOlvZdsX.jiMgPMJEvAxfKwBQSDPqHQcKBJzw;
			}
		}
	}

	public void KRgasgBmyLeCeDGJhNGqwMeOqCwJ()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~SmnfRaZRTCRKUNzdKVQSwqJahva()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			if (P_0)
			{
				avkcOhFlGGeHrNSdTQlLZUnJDbw();
			}
			if (YExmSIdDrhhawcKZrBCSWczMfsy)
			{
				LwrpDHobBHpPvvemtOUFUIbiMeW.CXTdVgahOHdHOeqfYwvbMhluTqY();
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}
}
