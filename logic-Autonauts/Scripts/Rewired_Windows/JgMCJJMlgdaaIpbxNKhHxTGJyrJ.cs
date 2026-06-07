using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class JgMCJJMlgdaaIpbxNKhHxTGJyrJ<T>
{
	private enum fJOckHtfeoeQrXpUtgGLvpLChSH
	{
		lpCqsMGfRWqDlmFqiiyTlDQVdUxi = 0,
		hPOIFtghXLgQqJiRlOXrddyuPGe = 1,
		eHvMoxBFNxADQnNYDRHhRZlgGUC = 2
	}

	private static class gZAmrWNYTsKXjlxYaJDTwmSxFbM
	{
		private class LiNjEbifQsajImcXUEukFaKWeQzi : IDisposable
		{
			private sealed class htGqbJcledMCnQLeGteGhHlChkM
			{
				public ManualResetEvent DSxQenXqwTodQSNjnvzyXLOUYCF;

				public LiNjEbifQsajImcXUEukFaKWeQzi iidCZOgulnzjWMumhFnWTPbnqlMV;

				public void DnawPwxaGOUlxwPMpnTrkQPiGMg()
				{
					DSxQenXqwTodQSNjnvzyXLOUYCF.Set();
					iidCZOgulnzjWMumhFnWTPbnqlMV.tUfuSGSSfFBDqGVpTBotEjXBzZn();
				}
			}

			private readonly object QRRGShBaDEUaStPKcRtRWlMmzrR;

			private List<WaitCallback> AxyLeQSGOUVyafJHRGYFkZSDtMX;

			private List<WaitCallback> AWDvqxlbHBazMuGhGsqxruBUsuO;

			private Thread pkFrzcGUmtiFKdBAvOBotYhXbCn;

			private AutoResetEvent TmxcHeLHIiuVKZrOEgsAzMnjaHv;

			private bool eAVFrmSDFeqYhEJpmlPzZhgGIIsK;

			private bool LQWeAESFMztpExFMCEiFCYhMVWdF;

			private bool GrgFIQwoQUnlgielRpmLfGdoisFD;

			private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

			public LiNjEbifQsajImcXUEukFaKWeQzi()
			{
				QRRGShBaDEUaStPKcRtRWlMmzrR = new object();
				AxyLeQSGOUVyafJHRGYFkZSDtMX = new List<WaitCallback>();
				AWDvqxlbHBazMuGhGsqxruBUsuO = new List<WaitCallback>();
				TmxcHeLHIiuVKZrOEgsAzMnjaHv = new AutoResetEvent(false);
			}

			public void JRQuWwDeuiPzlgxmYtBgqOGlbUF(WaitCallback P_0)
			{
				if (GVPNrpnUrcRcuBVNsoUmnQYWdWW())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
					{
						AxyLeQSGOUVyafJHRGYFkZSDtMX.Add(P_0);
					}
					TmxcHeLHIiuVKZrOEgsAzMnjaHv.Set();
				}
			}

			public void UXmmhZSwOqdIHqpKUyMLRbkAHaQ()
			{
				rRQbDKaLEDqxnxHQBSnyElqLoXML();
			}

			public bool JLNyGUJfqBkWKpBQUvTKmlQdbACH()
			{
				return GVPNrpnUrcRcuBVNsoUmnQYWdWW();
			}

			private bool GVPNrpnUrcRcuBVNsoUmnQYWdWW()
			{
				if (GrgFIQwoQUnlgielRpmLfGdoisFD)
				{
					return false;
				}
				if (LQWeAESFMztpExFMCEiFCYhMVWdF)
				{
					return false;
				}
				if (eAVFrmSDFeqYhEJpmlPzZhgGIIsK)
				{
					return true;
				}
				if (pkFrzcGUmtiFKdBAvOBotYhXbCn != null)
				{
					return true;
				}
				try
				{
					htGqbJcledMCnQLeGteGhHlChkM htGqbJcledMCnQLeGteGhHlChkM2 = new htGqbJcledMCnQLeGteGhHlChkM();
					htGqbJcledMCnQLeGteGhHlChkM2.iidCZOgulnzjWMumhFnWTPbnqlMV = this;
					htGqbJcledMCnQLeGteGhHlChkM2.DSxQenXqwTodQSNjnvzyXLOUYCF = new ManualResetEvent(false);
					pkFrzcGUmtiFKdBAvOBotYhXbCn = new Thread(htGqbJcledMCnQLeGteGhHlChkM2.DnawPwxaGOUlxwPMpnTrkQPiGMg);
					pkFrzcGUmtiFKdBAvOBotYhXbCn.Start();
					htGqbJcledMCnQLeGteGhHlChkM2.DSxQenXqwTodQSNjnvzyXLOUYCF.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, true);
					pkFrzcGUmtiFKdBAvOBotYhXbCn = null;
					GrgFIQwoQUnlgielRpmLfGdoisFD = true;
					return false;
				}
			}

			private void tUfuSGSSfFBDqGVpTBotEjXBzZn()
			{
				eAVFrmSDFeqYhEJpmlPzZhgGIIsK = true;
				while (!LQWeAESFMztpExFMCEiFCYhMVWdF)
				{
					TmxcHeLHIiuVKZrOEgsAzMnjaHv.WaitOne();
					if (LQWeAESFMztpExFMCEiFCYhMVWdF)
					{
						break;
					}
					lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
					{
						MiscTools.Swap(ref AxyLeQSGOUVyafJHRGYFkZSDtMX, ref AWDvqxlbHBazMuGhGsqxruBUsuO);
					}
					List<WaitCallback> aWDvqxlbHBazMuGhGsqxruBUsuO = AWDvqxlbHBazMuGhGsqxruBUsuO;
					int count = aWDvqxlbHBazMuGhGsqxruBUsuO.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							aWDvqxlbHBazMuGhGsqxruBUsuO[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, true);
						}
					}
					aWDvqxlbHBazMuGhGsqxruBUsuO.Clear();
				}
				lock (QRRGShBaDEUaStPKcRtRWlMmzrR)
				{
					AxyLeQSGOUVyafJHRGYFkZSDtMX.Clear();
					AWDvqxlbHBazMuGhGsqxruBUsuO.Clear();
				}
				LQWeAESFMztpExFMCEiFCYhMVWdF = false;
				eAVFrmSDFeqYhEJpmlPzZhgGIIsK = false;
			}

			private void xMnYbqYifeiipudCHARhHVdFSuET()
			{
				pkFrzcGUmtiFKdBAvOBotYhXbCn = null;
				GrgFIQwoQUnlgielRpmLfGdoisFD = false;
				LQWeAESFMztpExFMCEiFCYhMVWdF = true;
			}

			private void rRQbDKaLEDqxnxHQBSnyElqLoXML()
			{
				xMnYbqYifeiipudCHARhHVdFSuET();
				try
				{
					TmxcHeLHIiuVKZrOEgsAzMnjaHv.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
				GC.SuppressFinalize(this);
			}

			~LiNjEbifQsajImcXUEukFaKWeQzi()
			{
				HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
			}

			protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
			{
				if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
				{
					rRQbDKaLEDqxnxHQBSnyElqLoXML();
					nNxUslIcGUpqKgpPZYhuimcvWyC = true;
				}
			}
		}

		private static LiNjEbifQsajImcXUEukFaKWeQzi zKdYBynAKUePorUFCVrrkhLqZnd;

		private static int UYujUOUDvnXNWCrfLLSilYqmIyr;

		private static LiNjEbifQsajImcXUEukFaKWeQzi queue
		{
			get
			{
				return zKdYBynAKUePorUFCVrrkhLqZnd ?? (zKdYBynAKUePorUFCVrrkhLqZnd = new LiNjEbifQsajImcXUEukFaKWeQzi());
			}
		}

		static gZAmrWNYTsKXjlxYaJDTwmSxFbM()
		{
			UYujUOUDvnXNWCrfLLSilYqmIyr = 0;
			AppDomain.CurrentDomain.DomainUnload -= KTHOOIeuhUqbUCNVeTXPkyeWVlt;
			AppDomain.CurrentDomain.DomainUnload += KTHOOIeuhUqbUCNVeTXPkyeWVlt;
		}

		private static void KTHOOIeuhUqbUCNVeTXPkyeWVlt(object P_0, EventArgs P_1)
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV();
			AppDomain.CurrentDomain.DomainUnload -= KTHOOIeuhUqbUCNVeTXPkyeWVlt;
		}

		public static void jcOfqZxvaNRAMiikALLOSesqxXT()
		{
			UYujUOUDvnXNWCrfLLSilYqmIyr++;
		}

		public static void XxcBsJKfsaHlIKEjLNxchRgiHjzC()
		{
			UYujUOUDvnXNWCrfLLSilYqmIyr--;
			if (UYujUOUDvnXNWCrfLLSilYqmIyr < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", true);
			}
			if (UYujUOUDvnXNWCrfLLSilYqmIyr == 0)
			{
				HtJdxRxaGggkmaMTSWUpHqjZLDV();
			}
		}

		public static void JRQuWwDeuiPzlgxmYtBgqOGlbUF(WaitCallback P_0)
		{
			queue.JRQuWwDeuiPzlgxmYtBgqOGlbUF(P_0);
		}

		public static void UXmmhZSwOqdIHqpKUyMLRbkAHaQ()
		{
			queue.UXmmhZSwOqdIHqpKUyMLRbkAHaQ();
		}

		public static bool JLNyGUJfqBkWKpBQUvTKmlQdbACH()
		{
			return queue.JLNyGUJfqBkWKpBQUvTKmlQdbACH();
		}

		private static void HtJdxRxaGggkmaMTSWUpHqjZLDV()
		{
			if (zKdYBynAKUePorUFCVrrkhLqZnd != null)
			{
				zKdYBynAKUePorUFCVrrkhLqZnd.Dispose();
			}
			zKdYBynAKUePorUFCVrrkhLqZnd = null;
			UYujUOUDvnXNWCrfLLSilYqmIyr = 0;
		}
	}

	private fJOckHtfeoeQrXpUtgGLvpLChSH yxlBhMVHZFbZVSWBrkbwIgfiZsZ;

	private T fqNeiHCrnGSOZNhUzMbTCLpxzxMb;

	private WaitCallback gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	private object jcpIvANnmImkcgQUNGcxgIqVBMvA;

	private Func<T> cKkBqUbxudmAATEqFFjjRXYVlLLS;

	private bool ZkWmfveFXAkTqGkDqHVZVkkvfxX;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public bool isRunning
	{
		get
		{
			if (yxlBhMVHZFbZVSWBrkbwIgfiZsZ != fJOckHtfeoeQrXpUtgGLvpLChSH.hPOIFtghXLgQqJiRlOXrddyuPGe)
			{
				return yxlBhMVHZFbZVSWBrkbwIgfiZsZ == fJOckHtfeoeQrXpUtgGLvpLChSH.eHvMoxBFNxADQnNYDRHhRZlgGUC;
			}
			return true;
		}
	}

	public T result
	{
		get
		{
			return fqNeiHCrnGSOZNhUzMbTCLpxzxMb;
		}
	}

	public bool xHkLCHGKEGSLVNAFPpLRGAkaRJs()
	{
		bool flag = yxlBhMVHZFbZVSWBrkbwIgfiZsZ == fJOckHtfeoeQrXpUtgGLvpLChSH.eHvMoxBFNxADQnNYDRHhRZlgGUC;
		if (flag)
		{
			yxlBhMVHZFbZVSWBrkbwIgfiZsZ = fJOckHtfeoeQrXpUtgGLvpLChSH.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
		}
		return flag;
	}

	public JgMCJJMlgdaaIpbxNKhHxTGJyrJ(bool useSharedThread, Func<T> resultDelegate)
	{
		ZkWmfveFXAkTqGkDqHVZVkkvfxX = useSharedThread;
		if (resultDelegate == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		cKkBqUbxudmAATEqFFjjRXYVlLLS = resultDelegate;
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = iPnuHjnhcayVMOnBaXkRQEDGEbtK;
		jcpIvANnmImkcgQUNGcxgIqVBMvA = new object();
		yxlBhMVHZFbZVSWBrkbwIgfiZsZ = fJOckHtfeoeQrXpUtgGLvpLChSH.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
		if (useSharedThread)
		{
			gZAmrWNYTsKXjlxYaJDTwmSxFbM.jcOfqZxvaNRAMiikALLOSesqxXT();
		}
	}

	public bool CNNCNIEIEPKDJVWLdcWrLrRIbyb()
	{
		lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
		{
			if (yxlBhMVHZFbZVSWBrkbwIgfiZsZ == fJOckHtfeoeQrXpUtgGLvpLChSH.hPOIFtghXLgQqJiRlOXrddyuPGe)
			{
				return false;
			}
			fqNeiHCrnGSOZNhUzMbTCLpxzxMb = default(T);
			yxlBhMVHZFbZVSWBrkbwIgfiZsZ = fJOckHtfeoeQrXpUtgGLvpLChSH.hPOIFtghXLgQqJiRlOXrddyuPGe;
		}
		if (ZkWmfveFXAkTqGkDqHVZVkkvfxX)
		{
			gZAmrWNYTsKXjlxYaJDTwmSxFbM.JRQuWwDeuiPzlgxmYtBgqOGlbUF(gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(gcSCuQrNDUgbabBuaIMfeSRwgnvd, this);
		}
		return true;
	}

	public void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
	{
		lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
		{
			fqNeiHCrnGSOZNhUzMbTCLpxzxMb = default(T);
			yxlBhMVHZFbZVSWBrkbwIgfiZsZ = fJOckHtfeoeQrXpUtgGLvpLChSH.lpCqsMGfRWqDlmFqiiyTlDQVdUxi;
		}
	}

	private void iPnuHjnhcayVMOnBaXkRQEDGEbtK(object P_0)
	{
		lock (jcpIvANnmImkcgQUNGcxgIqVBMvA)
		{
			if (yxlBhMVHZFbZVSWBrkbwIgfiZsZ == fJOckHtfeoeQrXpUtgGLvpLChSH.hPOIFtghXLgQqJiRlOXrddyuPGe)
			{
				fqNeiHCrnGSOZNhUzMbTCLpxzxMb = cKkBqUbxudmAATEqFFjjRXYVlLLS();
				yxlBhMVHZFbZVSWBrkbwIgfiZsZ = fJOckHtfeoeQrXpUtgGLvpLChSH.eHvMoxBFNxADQnNYDRHhRZlgGUC;
			}
		}
	}

	public void HtJdxRxaGggkmaMTSWUpHqjZLDV()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~JgMCJJMlgdaaIpbxNKhHxTGJyrJ()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			if (P_0)
			{
				bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
			}
			if (ZkWmfveFXAkTqGkDqHVZVkkvfxX)
			{
				gZAmrWNYTsKXjlxYaJDTwmSxFbM.XxcBsJKfsaHlIKEjLNxchRgiHjzC();
			}
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}
}
