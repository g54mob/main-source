using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class rYcHdEeFHXdSOaPSvrmsYhfAgjun<_0001>
{
	private enum cgphpxhRKjhtskbBQZowDoFTIRHZA
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class ulzdACXYZTkFOMbUmajnlxrddSOK
	{
		private class FAjUJqPrekRmhRgrOolmBdbBdseb : IDisposable
		{
			private sealed class VvREHIeUdvemHUDmlPcRSRFpHKon
			{
				public FAjUJqPrekRmhRgrOolmBdbBdseb CkJlODENHLjHOpVTJtFbwVYqcuvm;

				public ManualResetEvent nCTZAsjvOrICEJYyJFdLwDwTHZgH;

				internal void zxShurLBoykgvxIhNgXYLSmrbDVZ()
				{
					nCTZAsjvOrICEJYyJFdLwDwTHZgH.Set();
					CkJlODENHLjHOpVTJtFbwVYqcuvm.JPRhFXmPPxFpoFZKbcAWFdyGQGUUA();
				}
			}

			private readonly object cCndHwpyhmiyUcAhGQdqlqtbgioX;

			private List<WaitCallback> oqCdjVeiwwNKwFmsdogaaZpDMFwOB;

			private List<WaitCallback> mdncvoHtUtDSvpUdiKBEOgyNbtne;

			private Thread DCpIopHmGZhjMikhGDdRfIQTMRCMc;

			private AutoResetEvent joJQgztfyAzPQGArqAbnOjOyjCSt;

			private bool QhleSxyDpMgmnRFQShWCajZHDwPl;

			private bool zJqVXNeAeFBDQmrnadUwglCDvBKpA;

			private bool ujAxPFIuieWVefiIlAYqCAKvJfuoA;

			private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

			public FAjUJqPrekRmhRgrOolmBdbBdseb()
			{
				cCndHwpyhmiyUcAhGQdqlqtbgioX = new object();
				oqCdjVeiwwNKwFmsdogaaZpDMFwOB = new List<WaitCallback>();
				mdncvoHtUtDSvpUdiKBEOgyNbtne = new List<WaitCallback>();
				joJQgztfyAzPQGArqAbnOjOyjCSt = new AutoResetEvent(initialState: false);
			}

			public void pHiiTxhNECVVdldNuunPNJvmRPux(WaitCallback P_0)
			{
				if (qPhGjuHRNEfrkMynCGIBKdbFaOxF())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
					{
						oqCdjVeiwwNKwFmsdogaaZpDMFwOB.Add(P_0);
					}
					joJQgztfyAzPQGArqAbnOjOyjCSt.Set();
				}
			}

			public void cFArMSkodGRrBblWeYKkcRHJpBzE()
			{
				XHsOSBvRatAPrFSjloXHvYXABGbjA();
			}

			public bool pBzxWNdMLjyMGydncxVfXziaTAvG()
			{
				return qPhGjuHRNEfrkMynCGIBKdbFaOxF();
			}

			private bool qPhGjuHRNEfrkMynCGIBKdbFaOxF()
			{
				VvREHIeUdvemHUDmlPcRSRFpHKon vvREHIeUdvemHUDmlPcRSRFpHKon = new VvREHIeUdvemHUDmlPcRSRFpHKon();
				vvREHIeUdvemHUDmlPcRSRFpHKon.CkJlODENHLjHOpVTJtFbwVYqcuvm = this;
				if (ujAxPFIuieWVefiIlAYqCAKvJfuoA)
				{
					return false;
				}
				if (zJqVXNeAeFBDQmrnadUwglCDvBKpA)
				{
					return false;
				}
				if (QhleSxyDpMgmnRFQShWCajZHDwPl)
				{
					return true;
				}
				if (DCpIopHmGZhjMikhGDdRfIQTMRCMc != null)
				{
					return true;
				}
				try
				{
					vvREHIeUdvemHUDmlPcRSRFpHKon.nCTZAsjvOrICEJYyJFdLwDwTHZgH = new ManualResetEvent(initialState: false);
					DCpIopHmGZhjMikhGDdRfIQTMRCMc = new Thread(vvREHIeUdvemHUDmlPcRSRFpHKon.zxShurLBoykgvxIhNgXYLSmrbDVZ);
					DCpIopHmGZhjMikhGDdRfIQTMRCMc.Start();
					vvREHIeUdvemHUDmlPcRSRFpHKon.nCTZAsjvOrICEJYyJFdLwDwTHZgH.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					DCpIopHmGZhjMikhGDdRfIQTMRCMc = null;
					ujAxPFIuieWVefiIlAYqCAKvJfuoA = true;
					return false;
				}
			}

			private void JPRhFXmPPxFpoFZKbcAWFdyGQGUUA()
			{
				QhleSxyDpMgmnRFQShWCajZHDwPl = true;
				while (!zJqVXNeAeFBDQmrnadUwglCDvBKpA)
				{
					joJQgztfyAzPQGArqAbnOjOyjCSt.WaitOne();
					if (zJqVXNeAeFBDQmrnadUwglCDvBKpA)
					{
						break;
					}
					lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
					{
						MiscTools.Swap(ref oqCdjVeiwwNKwFmsdogaaZpDMFwOB, ref mdncvoHtUtDSvpUdiKBEOgyNbtne);
					}
					List<WaitCallback> list = mdncvoHtUtDSvpUdiKBEOgyNbtne;
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
				lock (cCndHwpyhmiyUcAhGQdqlqtbgioX)
				{
					oqCdjVeiwwNKwFmsdogaaZpDMFwOB.Clear();
					mdncvoHtUtDSvpUdiKBEOgyNbtne.Clear();
				}
				zJqVXNeAeFBDQmrnadUwglCDvBKpA = false;
				QhleSxyDpMgmnRFQShWCajZHDwPl = false;
			}

			private void JUJHoxkjJKyYtxXjhvDGglQIbTjh()
			{
				DCpIopHmGZhjMikhGDdRfIQTMRCMc = null;
				ujAxPFIuieWVefiIlAYqCAKvJfuoA = false;
				zJqVXNeAeFBDQmrnadUwglCDvBKpA = true;
			}

			private void XHsOSBvRatAPrFSjloXHvYXABGbjA()
			{
				JUJHoxkjJKyYtxXjhvDGglQIbTjh();
				try
				{
					joJQgztfyAzPQGArqAbnOjOyjCSt.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
			{
				try
				{
					hIlanWXkrCYfgvCyascUuCUOCBcL(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
			{
				if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
				{
					XHsOSBvRatAPrFSjloXHvYXABGbjA();
					TExNvhkEWsBWipIUjadCDaTpNNDG = true;
				}
			}
		}

		private static ulzdACXYZTkFOMbUmajnlxrddSOK KYSmpmrTPxcxTjdZegwsSZlOlbOU;

		private FAjUJqPrekRmhRgrOolmBdbBdseb LRPDzQTsUipqgqqGmFJQRcnneFEG;

		private int kEQioHwhhLipCTNYfSfBMXnfnPIv;

		private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

		private static ulzdACXYZTkFOMbUmajnlxrddSOK NuBDdKUJCoFOxHtcBDZbzmwuhjdM => KYSmpmrTPxcxTjdZegwsSZlOlbOU ?? new ulzdACXYZTkFOMbUmajnlxrddSOK();

		private FAjUJqPrekRmhRgrOolmBdbBdseb CrANkAaLfTfipGOSpuVQtmLdluCBb => LRPDzQTsUipqgqqGmFJQRcnneFEG ?? (LRPDzQTsUipqgqqGmFJQRcnneFEG = new FAjUJqPrekRmhRgrOolmBdbBdseb());

		private ulzdACXYZTkFOMbUmajnlxrddSOK()
		{
			KYSmpmrTPxcxTjdZegwsSZlOlbOU?.hIlanWXkrCYfgvCyascUuCUOCBcL();
			KYSmpmrTPxcxTjdZegwsSZlOlbOU = this;
		}

		private void qdOyuafWmhcsZdqAUMQdCyHfmWUq()
		{
			kEQioHwhhLipCTNYfSfBMXnfnPIv++;
		}

		private void UVApndRafxrLiXOvwlmvYlvsBewIA()
		{
			kEQioHwhhLipCTNYfSfBMXnfnPIv--;
			if (kEQioHwhhLipCTNYfSfBMXnfnPIv < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (kEQioHwhhLipCTNYfSfBMXnfnPIv == 0)
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL();
			}
		}

		private void jGoDpZxOuTQLYUfeAPsKMXoXMhhq(WaitCallback P_0)
		{
			CrANkAaLfTfipGOSpuVQtmLdluCBb.pHiiTxhNECVVdldNuunPNJvmRPux(P_0);
		}

		private void cwQRgUWjNfboZmREhFYXYWCKuBXC()
		{
			CrANkAaLfTfipGOSpuVQtmLdluCBb.cFArMSkodGRrBblWeYKkcRHJpBzE();
		}

		private bool QhbMXgJsHovkPgHjSuBlpwTtllYJ()
		{
			return CrANkAaLfTfipGOSpuVQtmLdluCBb.pBzxWNdMLjyMGydncxVfXziaTAvG();
		}

		private void hIlanWXkrCYfgvCyascUuCUOCBcL()
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(true);
			GC.SuppressFinalize(this);
		}

		protected void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
		{
			try
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
		{
			if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
			{
				if (P_0 && LRPDzQTsUipqgqqGmFJQRcnneFEG != null)
				{
					LRPDzQTsUipqgqqGmFJQRcnneFEG.Dispose();
					LRPDzQTsUipqgqqGmFJQRcnneFEG = null;
				}
				kEQioHwhhLipCTNYfSfBMXnfnPIv = 0;
				if (KYSmpmrTPxcxTjdZegwsSZlOlbOU == this)
				{
					KYSmpmrTPxcxTjdZegwsSZlOlbOU = null;
				}
				TExNvhkEWsBWipIUjadCDaTpNNDG = true;
			}
		}

		public static void DaiamURlDnjrOGdDqTjvDxJxhmyKA()
		{
			NuBDdKUJCoFOxHtcBDZbzmwuhjdM.qdOyuafWmhcsZdqAUMQdCyHfmWUq();
		}

		public static void nnKPdCTRMWETSVTWhERByYBYowIl()
		{
			KYSmpmrTPxcxTjdZegwsSZlOlbOU?.UVApndRafxrLiXOvwlmvYlvsBewIA();
		}

		public static void pHiiTxhNECVVdldNuunPNJvmRPux(WaitCallback P_0)
		{
			NuBDdKUJCoFOxHtcBDZbzmwuhjdM.jGoDpZxOuTQLYUfeAPsKMXoXMhhq(P_0);
		}
	}

	private cgphpxhRKjhtskbBQZowDoFTIRHZA UEZMKFnhWlvuHXazRLoHrWwvjmgD;

	private _0001 LxjnnAZFJeEkZksnHlJkEuQHowfAc;

	private WaitCallback MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	private object TaTZuRxeAuSQyhVzlhSQxOBEALUr;

	private Func<_0001> SfCPfPPzMJvkKFqZrGBWqhnCCUwp;

	private bool nHqDishWdsntwRBoYLdkCqJIwyoqB;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public bool FjVRScdpFKyLClYRKhdeqgbPmktV
	{
		get
		{
			if (UEZMKFnhWlvuHXazRLoHrWwvjmgD != cgphpxhRKjhtskbBQZowDoFTIRHZA.AwaitingResult)
			{
				return UEZMKFnhWlvuHXazRLoHrWwvjmgD == cgphpxhRKjhtskbBQZowDoFTIRHZA.ResultReceived;
			}
			return true;
		}
	}

	public _0001 sXGDgYySYSTzdUeJrjzbYAsUFvMdA => LxjnnAZFJeEkZksnHlJkEuQHowfAc;

	public bool FAEdLIDaqiJrNwIazMvgidHfLWFNA()
	{
		bool num = UEZMKFnhWlvuHXazRLoHrWwvjmgD == cgphpxhRKjhtskbBQZowDoFTIRHZA.ResultReceived;
		if (num)
		{
			UEZMKFnhWlvuHXazRLoHrWwvjmgD = cgphpxhRKjhtskbBQZowDoFTIRHZA.Idle;
		}
		return num;
	}

	public rYcHdEeFHXdSOaPSvrmsYhfAgjun(bool P_0, Func<_0001> P_1)
	{
		nHqDishWdsntwRBoYLdkCqJIwyoqB = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		SfCPfPPzMJvkKFqZrGBWqhnCCUwp = P_1;
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = OJViIoVMUQFlYFWeWaYqbCsRpaMN;
		TaTZuRxeAuSQyhVzlhSQxOBEALUr = new object();
		UEZMKFnhWlvuHXazRLoHrWwvjmgD = cgphpxhRKjhtskbBQZowDoFTIRHZA.Idle;
		if (P_0)
		{
			ulzdACXYZTkFOMbUmajnlxrddSOK.DaiamURlDnjrOGdDqTjvDxJxhmyKA();
		}
	}

	public bool mPdlIFqjoxqpXUXmLokOkbcVfbGkA()
	{
		lock (TaTZuRxeAuSQyhVzlhSQxOBEALUr)
		{
			if (UEZMKFnhWlvuHXazRLoHrWwvjmgD == cgphpxhRKjhtskbBQZowDoFTIRHZA.AwaitingResult)
			{
				return false;
			}
			LxjnnAZFJeEkZksnHlJkEuQHowfAc = default(_0001);
			UEZMKFnhWlvuHXazRLoHrWwvjmgD = cgphpxhRKjhtskbBQZowDoFTIRHZA.AwaitingResult;
		}
		if (nHqDishWdsntwRBoYLdkCqJIwyoqB)
		{
			ulzdACXYZTkFOMbUmajnlxrddSOK.pHiiTxhNECVVdldNuunPNJvmRPux(MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(MsgdQZHArmPPyiCZWkdIRBkxqnWg, this);
		}
		return true;
	}

	public void PNnwosyJbZAkbwObisgdtMytZJol()
	{
		lock (TaTZuRxeAuSQyhVzlhSQxOBEALUr)
		{
			LxjnnAZFJeEkZksnHlJkEuQHowfAc = default(_0001);
			UEZMKFnhWlvuHXazRLoHrWwvjmgD = cgphpxhRKjhtskbBQZowDoFTIRHZA.Idle;
		}
	}

	private void OJViIoVMUQFlYFWeWaYqbCsRpaMN(object P_0)
	{
		lock (TaTZuRxeAuSQyhVzlhSQxOBEALUr)
		{
			if (UEZMKFnhWlvuHXazRLoHrWwvjmgD == cgphpxhRKjhtskbBQZowDoFTIRHZA.AwaitingResult)
			{
				LxjnnAZFJeEkZksnHlJkEuQHowfAc = SfCPfPPzMJvkKFqZrGBWqhnCCUwp();
				UEZMKFnhWlvuHXazRLoHrWwvjmgD = cgphpxhRKjhtskbBQZowDoFTIRHZA.ResultReceived;
			}
		}
	}

	public void hIlanWXkrCYfgvCyascUuCUOCBcL()
	{
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			if (P_0)
			{
				PNnwosyJbZAkbwObisgdtMytZJol();
			}
			if (nHqDishWdsntwRBoYLdkCqJIwyoqB)
			{
				ulzdACXYZTkFOMbUmajnlxrddSOK.nnKPdCTRMWETSVTWhERByYBYowIl();
			}
			TExNvhkEWsBWipIUjadCDaTpNNDG = true;
		}
	}
}
