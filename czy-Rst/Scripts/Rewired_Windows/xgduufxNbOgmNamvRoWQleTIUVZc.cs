using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class xgduufxNbOgmNamvRoWQleTIUVZc<_0001>
{
	private enum uKkEGOerMuRHxhtlufeCPHMXlmeq
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class ypwIShQVkYOwFMgeUqOXSsthMahC
	{
		private class oLntzOuzalggAKJimPKeuJfgKmPn : IDisposable
		{
			private sealed class qoqbRsdWunvUtNEHInPjkEJHALQib
			{
				public oLntzOuzalggAKJimPKeuJfgKmPn gZOYoglcrzmoKIMFYaIjCDNluOUy;

				public ManualResetEvent AhlFDzgMDXDefbZpBYxekUuGkMROA;

				internal void QSyzXVkbTOGqpkZjzVChEzDbZyTd()
				{
					AhlFDzgMDXDefbZpBYxekUuGkMROA.Set();
					gZOYoglcrzmoKIMFYaIjCDNluOUy.gvJWJtgiXpUvQPALZpZVSovCQckk();
				}
			}

			private readonly object WBMdfncceyhcbvdYmWfMsagUNULpA;

			private List<WaitCallback> JeTERuitALQTiwYrNClWgHFjPDUrB;

			private List<WaitCallback> AxEkqzCfTJehMZovgxrFCHsTunyb;

			private Thread GzTDXHhsUexBxtDfmaAiGGikRSqhb;

			private AutoResetEvent CfJVXVJVMbMJiuTSgvdBTjpcYRbA;

			private bool xNESssJJJfJLwmhHGZqKNkOHxIiD;

			private bool XCjGGomwtBGlgbPPCIIsPhhSiXTlA;

			private bool ejMwYLmCkDWXgHjvuizyhgPUYMWF;

			private bool mkyTdBqnQbcZzteLjJqKBxPyJHsf;

			public oLntzOuzalggAKJimPKeuJfgKmPn()
			{
				WBMdfncceyhcbvdYmWfMsagUNULpA = new object();
				JeTERuitALQTiwYrNClWgHFjPDUrB = new List<WaitCallback>();
				AxEkqzCfTJehMZovgxrFCHsTunyb = new List<WaitCallback>();
				CfJVXVJVMbMJiuTSgvdBTjpcYRbA = new AutoResetEvent(initialState: false);
			}

			public void YUOSCEpCDhvtoLDKJDTUDlYvvlXJA(WaitCallback P_0)
			{
				if (GbMxGmgEfygUInUencXuAToHkPiw())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (WBMdfncceyhcbvdYmWfMsagUNULpA)
					{
						JeTERuitALQTiwYrNClWgHFjPDUrB.Add(P_0);
					}
					CfJVXVJVMbMJiuTSgvdBTjpcYRbA.Set();
				}
			}

			public void eINrtGysWfuYsyhrsuDiZloYkiwE()
			{
				tiBONUqUUiAAvLhSgYRdzzPGVtBY();
			}

			public bool FEdWhpUpNKScditBXhITlczjzmEf()
			{
				return GbMxGmgEfygUInUencXuAToHkPiw();
			}

			private bool GbMxGmgEfygUInUencXuAToHkPiw()
			{
				if (ejMwYLmCkDWXgHjvuizyhgPUYMWF)
				{
					return false;
				}
				if (XCjGGomwtBGlgbPPCIIsPhhSiXTlA)
				{
					return false;
				}
				if (xNESssJJJfJLwmhHGZqKNkOHxIiD)
				{
					return true;
				}
				if (GzTDXHhsUexBxtDfmaAiGGikRSqhb != null)
				{
					return true;
				}
				return aqAznDxadqQBXmipkfiNqwcXDmxZ();
			}

			private bool aqAznDxadqQBXmipkfiNqwcXDmxZ()
			{
				qoqbRsdWunvUtNEHInPjkEJHALQib qoqbRsdWunvUtNEHInPjkEJHALQib2 = new qoqbRsdWunvUtNEHInPjkEJHALQib();
				qoqbRsdWunvUtNEHInPjkEJHALQib2.gZOYoglcrzmoKIMFYaIjCDNluOUy = this;
				try
				{
					qoqbRsdWunvUtNEHInPjkEJHALQib2.AhlFDzgMDXDefbZpBYxekUuGkMROA = new ManualResetEvent(initialState: false);
					GzTDXHhsUexBxtDfmaAiGGikRSqhb = new Thread(qoqbRsdWunvUtNEHInPjkEJHALQib2.QSyzXVkbTOGqpkZjzVChEzDbZyTd);
					GzTDXHhsUexBxtDfmaAiGGikRSqhb.Start();
					qoqbRsdWunvUtNEHInPjkEJHALQib2.AhlFDzgMDXDefbZpBYxekUuGkMROA.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					GzTDXHhsUexBxtDfmaAiGGikRSqhb = null;
					ejMwYLmCkDWXgHjvuizyhgPUYMWF = true;
					return false;
				}
			}

			private void gvJWJtgiXpUvQPALZpZVSovCQckk()
			{
				xNESssJJJfJLwmhHGZqKNkOHxIiD = true;
				while (!XCjGGomwtBGlgbPPCIIsPhhSiXTlA)
				{
					CfJVXVJVMbMJiuTSgvdBTjpcYRbA.WaitOne();
					if (XCjGGomwtBGlgbPPCIIsPhhSiXTlA)
					{
						break;
					}
					lock (WBMdfncceyhcbvdYmWfMsagUNULpA)
					{
						MiscTools.Swap(ref JeTERuitALQTiwYrNClWgHFjPDUrB, ref AxEkqzCfTJehMZovgxrFCHsTunyb);
					}
					List<WaitCallback> axEkqzCfTJehMZovgxrFCHsTunyb = AxEkqzCfTJehMZovgxrFCHsTunyb;
					int count = axEkqzCfTJehMZovgxrFCHsTunyb.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							axEkqzCfTJehMZovgxrFCHsTunyb[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					axEkqzCfTJehMZovgxrFCHsTunyb.Clear();
				}
				lock (WBMdfncceyhcbvdYmWfMsagUNULpA)
				{
					JeTERuitALQTiwYrNClWgHFjPDUrB.Clear();
					AxEkqzCfTJehMZovgxrFCHsTunyb.Clear();
				}
				XCjGGomwtBGlgbPPCIIsPhhSiXTlA = false;
				xNESssJJJfJLwmhHGZqKNkOHxIiD = false;
			}

			private void xPPDPZEckMasrXBnZbUYhRvaFBvxA()
			{
				GzTDXHhsUexBxtDfmaAiGGikRSqhb = null;
				ejMwYLmCkDWXgHjvuizyhgPUYMWF = false;
				XCjGGomwtBGlgbPPCIIsPhhSiXTlA = true;
			}

			private void tiBONUqUUiAAvLhSgYRdzzPGVtBY()
			{
				xPPDPZEckMasrXBnZbUYhRvaFBvxA();
				try
				{
					CfJVXVJVMbMJiuTSgvdBTjpcYRbA.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				KSbGKizbOxbvbRsBgeydFIjaEWEGb(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void EwpGBzIoLuIbRwwmgcsRhmQUvHPe()
			{
				try
				{
					KSbGKizbOxbvbRsBgeydFIjaEWEGb(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void KSbGKizbOxbvbRsBgeydFIjaEWEGb(bool P_0)
			{
				if (!mkyTdBqnQbcZzteLjJqKBxPyJHsf)
				{
					tiBONUqUUiAAvLhSgYRdzzPGVtBY();
					mkyTdBqnQbcZzteLjJqKBxPyJHsf = true;
				}
			}
		}

		private static ypwIShQVkYOwFMgeUqOXSsthMahC PygpqEKwYjzfOmKUjlHeIfGMHguO;

		private oLntzOuzalggAKJimPKeuJfgKmPn ApIbxmnGMQJMZNZxfHZSgBEirUfC;

		private int OJWqUQiMMIEZAmVmGfoNNSSHgiScA;

		private bool BLaGDksSIVXNTwwIGFsksRQXQSOV;

		private static ypwIShQVkYOwFMgeUqOXSsthMahC upmgnvGdnlVXAgAImHedXzJScXHK => PygpqEKwYjzfOmKUjlHeIfGMHguO ?? new ypwIShQVkYOwFMgeUqOXSsthMahC();

		private oLntzOuzalggAKJimPKeuJfgKmPn McYhdxKGHyzBFJcZuzooEsbIgcDN => ApIbxmnGMQJMZNZxfHZSgBEirUfC ?? (ApIbxmnGMQJMZNZxfHZSgBEirUfC = new oLntzOuzalggAKJimPKeuJfgKmPn());

		private ypwIShQVkYOwFMgeUqOXSsthMahC()
		{
			PygpqEKwYjzfOmKUjlHeIfGMHguO?.gDahEXGsuJkPuUxRJLolBmWdewwRA();
			PygpqEKwYjzfOmKUjlHeIfGMHguO = this;
		}

		private void fDcfHwDVHDgYZEFgNarHtOWBoSkK()
		{
			OJWqUQiMMIEZAmVmGfoNNSSHgiScA++;
		}

		private void mRZfJpaQywRjwsiirGtEgxkperCs()
		{
			OJWqUQiMMIEZAmVmGfoNNSSHgiScA--;
			if (OJWqUQiMMIEZAmVmGfoNNSSHgiScA < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (OJWqUQiMMIEZAmVmGfoNNSSHgiScA == 0)
			{
				gDahEXGsuJkPuUxRJLolBmWdewwRA();
			}
		}

		private void ENMQOySwJthqMdxXupWtxwQRwtbW(WaitCallback P_0)
		{
			McYhdxKGHyzBFJcZuzooEsbIgcDN.YUOSCEpCDhvtoLDKJDTUDlYvvlXJA(P_0);
		}

		private void MlOPJDMMNubvXIqnHDrAqVjJCHrFA()
		{
			McYhdxKGHyzBFJcZuzooEsbIgcDN.eINrtGysWfuYsyhrsuDiZloYkiwE();
		}

		private bool RkEaUDGzzMggLvgWhnAGnHgDeCEd()
		{
			return McYhdxKGHyzBFJcZuzooEsbIgcDN.FEdWhpUpNKScditBXhITlczjzmEf();
		}

		private void gDahEXGsuJkPuUxRJLolBmWdewwRA()
		{
			mwahbuXVoKLfQAEhsntGmTEEPpgP(true);
			GC.SuppressFinalize(this);
		}

		protected void wJsnwiTdXeYQPhHambhSvRRInCL()
		{
			try
			{
				mwahbuXVoKLfQAEhsntGmTEEPpgP(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void mwahbuXVoKLfQAEhsntGmTEEPpgP(bool P_0)
		{
			if (!BLaGDksSIVXNTwwIGFsksRQXQSOV)
			{
				if (P_0 && ApIbxmnGMQJMZNZxfHZSgBEirUfC != null)
				{
					ApIbxmnGMQJMZNZxfHZSgBEirUfC.Dispose();
					ApIbxmnGMQJMZNZxfHZSgBEirUfC = null;
				}
				OJWqUQiMMIEZAmVmGfoNNSSHgiScA = 0;
				if (PygpqEKwYjzfOmKUjlHeIfGMHguO == this)
				{
					PygpqEKwYjzfOmKUjlHeIfGMHguO = null;
				}
				BLaGDksSIVXNTwwIGFsksRQXQSOV = true;
			}
		}

		public static void oXTNYsKcvRAySFYTVYmhlhzRradjA()
		{
			upmgnvGdnlVXAgAImHedXzJScXHK.fDcfHwDVHDgYZEFgNarHtOWBoSkK();
		}

		public static void iViRmigedrCLwoKozPfENZapoTak()
		{
			PygpqEKwYjzfOmKUjlHeIfGMHguO?.mRZfJpaQywRjwsiirGtEgxkperCs();
		}

		public static void kiGdDVCadNmWRBJTHYIDGAdduANhc(WaitCallback P_0)
		{
			upmgnvGdnlVXAgAImHedXzJScXHK.ENMQOySwJthqMdxXupWtxwQRwtbW(P_0);
		}
	}

	private uKkEGOerMuRHxhtlufeCPHMXlmeq FPdsfIOnFFkpNtoditOdTCvYTZbj;

	private _0001 YWrXCCZTkvFFoanBXYhByMaGIhtDA;

	private WaitCallback HnnQWrGRHqlcLBXBaDDACloIHzUY;

	private object OtCkhCSUpTbBKafmUPQQJBtuuPMC;

	private Func<_0001> fcVIfTMlCKrhsEKTDcTbmRALNAZD;

	private bool RtabMLqizCgPAJDSeaVmeCqByTXTA;

	private bool nPVgfZFDOTUiykPxBAqohnabiQriA;

	public bool YibZslQejybegMCwglLcbMXjXREh
	{
		get
		{
			if (FPdsfIOnFFkpNtoditOdTCvYTZbj != uKkEGOerMuRHxhtlufeCPHMXlmeq.AwaitingResult)
			{
				return FPdsfIOnFFkpNtoditOdTCvYTZbj == uKkEGOerMuRHxhtlufeCPHMXlmeq.ResultReceived;
			}
			return true;
		}
	}

	public _0001 IOFddxkEPgJuSBEVGkKcRMAZvCAm => YWrXCCZTkvFFoanBXYhByMaGIhtDA;

	public bool QPPcnXHfsXuMerWBTRMGFYgQdvAf()
	{
		bool num = FPdsfIOnFFkpNtoditOdTCvYTZbj == uKkEGOerMuRHxhtlufeCPHMXlmeq.ResultReceived;
		if (num)
		{
			FPdsfIOnFFkpNtoditOdTCvYTZbj = uKkEGOerMuRHxhtlufeCPHMXlmeq.Idle;
		}
		return num;
	}

	public xgduufxNbOgmNamvRoWQleTIUVZc(bool P_0, Func<_0001> P_1)
	{
		RtabMLqizCgPAJDSeaVmeCqByTXTA = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		fcVIfTMlCKrhsEKTDcTbmRALNAZD = P_1;
		HnnQWrGRHqlcLBXBaDDACloIHzUY = LyjNZAqvGVCasfBkkNnVKnQJCiuQ;
		OtCkhCSUpTbBKafmUPQQJBtuuPMC = new object();
		FPdsfIOnFFkpNtoditOdTCvYTZbj = uKkEGOerMuRHxhtlufeCPHMXlmeq.Idle;
		if (P_0)
		{
			ypwIShQVkYOwFMgeUqOXSsthMahC.oXTNYsKcvRAySFYTVYmhlhzRradjA();
		}
	}

	public bool gVRMdQUdMoWjfTCoTwRPEnVbhauCA()
	{
		lock (OtCkhCSUpTbBKafmUPQQJBtuuPMC)
		{
			if (FPdsfIOnFFkpNtoditOdTCvYTZbj == uKkEGOerMuRHxhtlufeCPHMXlmeq.AwaitingResult)
			{
				return false;
			}
			YWrXCCZTkvFFoanBXYhByMaGIhtDA = default(_0001);
			FPdsfIOnFFkpNtoditOdTCvYTZbj = uKkEGOerMuRHxhtlufeCPHMXlmeq.AwaitingResult;
		}
		if (RtabMLqizCgPAJDSeaVmeCqByTXTA)
		{
			ypwIShQVkYOwFMgeUqOXSsthMahC.kiGdDVCadNmWRBJTHYIDGAdduANhc(HnnQWrGRHqlcLBXBaDDACloIHzUY);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(HnnQWrGRHqlcLBXBaDDACloIHzUY, this);
		}
		return true;
	}

	public void MbxlxWAPjhnJbxoHACPkdinfnmabb()
	{
		lock (OtCkhCSUpTbBKafmUPQQJBtuuPMC)
		{
			YWrXCCZTkvFFoanBXYhByMaGIhtDA = default(_0001);
			FPdsfIOnFFkpNtoditOdTCvYTZbj = uKkEGOerMuRHxhtlufeCPHMXlmeq.Idle;
		}
	}

	private void LyjNZAqvGVCasfBkkNnVKnQJCiuQ(object P_0)
	{
		lock (OtCkhCSUpTbBKafmUPQQJBtuuPMC)
		{
			if (FPdsfIOnFFkpNtoditOdTCvYTZbj == uKkEGOerMuRHxhtlufeCPHMXlmeq.AwaitingResult)
			{
				YWrXCCZTkvFFoanBXYhByMaGIhtDA = fcVIfTMlCKrhsEKTDcTbmRALNAZD();
				FPdsfIOnFFkpNtoditOdTCvYTZbj = uKkEGOerMuRHxhtlufeCPHMXlmeq.ResultReceived;
			}
		}
	}

	public void FOYyubOeaZiQjSwliSBfnAKTjoxy()
	{
		YtCCarNdCPFPYvvgFBTNATkKXqiMA(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void eQpKDpdQMJmwnmtHzAhLJebfcCOr()
	{
		try
		{
			YtCCarNdCPFPYvvgFBTNATkKXqiMA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void YtCCarNdCPFPYvvgFBTNATkKXqiMA(bool P_0)
	{
		if (!nPVgfZFDOTUiykPxBAqohnabiQriA)
		{
			if (P_0)
			{
				MbxlxWAPjhnJbxoHACPkdinfnmabb();
			}
			if (RtabMLqizCgPAJDSeaVmeCqByTXTA)
			{
				ypwIShQVkYOwFMgeUqOXSsthMahC.iViRmigedrCLwoKozPfENZapoTak();
			}
			nPVgfZFDOTUiykPxBAqohnabiQriA = true;
		}
	}
}
