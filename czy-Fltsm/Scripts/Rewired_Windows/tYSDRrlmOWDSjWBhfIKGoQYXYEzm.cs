using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class tYSDRrlmOWDSjWBhfIKGoQYXYEzm<_0001>
{
	private enum kYNdwUuPEungDZHaQGcQSMqKqxSI
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class cpTGdfAqMMEohovbihOVdTWkSURsA
	{
		private class kxWEPYizlbUlwucnEmNyhfZziMzK : IDisposable
		{
			private sealed class kyHuxqGhrxoIBcaIkIbtFafYRRgS
			{
				public kxWEPYizlbUlwucnEmNyhfZziMzK aHbBForZovrWgkjCsTmpJgnumOgT;

				public ManualResetEvent YBUcatgFQZQBZfcuvHVkLyWNrOfN;

				internal void YmNQGVwzmGUeSQHCBNdpJMXiLTvW()
				{
					YBUcatgFQZQBZfcuvHVkLyWNrOfN.Set();
					aHbBForZovrWgkjCsTmpJgnumOgT.akekbrgpWhEwyBvOfuFVwFJJJEUNA();
				}
			}

			private readonly object MKlYhjiOlcEeXNONAVnUxyERSFdj;

			private List<WaitCallback> VXgwZuxSJTjvGsKutZVGUFdMNDsL;

			private List<WaitCallback> EOlqVmMPwHnUBvJnODDhJpxOUaBr;

			private Thread GIouUPeORsjsVrJuSykgZAOWAZAf;

			private AutoResetEvent MyQnyBDhWCHwzAjWwpVxMOVyaGlY;

			private bool zPfGtwHnIxxrWCOysBpGFMIOTfWoA;

			private bool HzCjzikPaHPRYxOMwsImqtXVFvzH;

			private bool qCveNJhihJTsYcbsMPQcqmlTrKoZ;

			private bool qBJdmRIeZzDWZMJQPJnQqSdvOBOab;

			public kxWEPYizlbUlwucnEmNyhfZziMzK()
			{
				MKlYhjiOlcEeXNONAVnUxyERSFdj = new object();
				VXgwZuxSJTjvGsKutZVGUFdMNDsL = new List<WaitCallback>();
				EOlqVmMPwHnUBvJnODDhJpxOUaBr = new List<WaitCallback>();
				MyQnyBDhWCHwzAjWwpVxMOVyaGlY = new AutoResetEvent(initialState: false);
			}

			public void QgxarMvaMdaHKflHljlUBqudqjvoB(WaitCallback P_0)
			{
				if (MfrgKmKmsysqerDfDEzgeLOWSJQcb())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (MKlYhjiOlcEeXNONAVnUxyERSFdj)
					{
						VXgwZuxSJTjvGsKutZVGUFdMNDsL.Add(P_0);
					}
					MyQnyBDhWCHwzAjWwpVxMOVyaGlY.Set();
				}
			}

			public void oZwFCCfePjCGYDGkiMAaBMGzLuCTb()
			{
				feicISuJaQyHBbHOQdtqthPxlxt();
			}

			public bool FiEdhlcYCGhiBnCAfQXXOwPodfunA()
			{
				return MfrgKmKmsysqerDfDEzgeLOWSJQcb();
			}

			private bool MfrgKmKmsysqerDfDEzgeLOWSJQcb()
			{
				if (qCveNJhihJTsYcbsMPQcqmlTrKoZ)
				{
					return false;
				}
				if (HzCjzikPaHPRYxOMwsImqtXVFvzH)
				{
					return false;
				}
				if (zPfGtwHnIxxrWCOysBpGFMIOTfWoA)
				{
					return true;
				}
				if (GIouUPeORsjsVrJuSykgZAOWAZAf != null)
				{
					return true;
				}
				return uXhMUBhdqyGbfSJaMQAVrmQSeoDCA();
			}

			private bool uXhMUBhdqyGbfSJaMQAVrmQSeoDCA()
			{
				kyHuxqGhrxoIBcaIkIbtFafYRRgS kyHuxqGhrxoIBcaIkIbtFafYRRgS2 = new kyHuxqGhrxoIBcaIkIbtFafYRRgS();
				kyHuxqGhrxoIBcaIkIbtFafYRRgS2.aHbBForZovrWgkjCsTmpJgnumOgT = this;
				try
				{
					kyHuxqGhrxoIBcaIkIbtFafYRRgS2.YBUcatgFQZQBZfcuvHVkLyWNrOfN = new ManualResetEvent(initialState: false);
					GIouUPeORsjsVrJuSykgZAOWAZAf = new Thread(kyHuxqGhrxoIBcaIkIbtFafYRRgS2.YmNQGVwzmGUeSQHCBNdpJMXiLTvW);
					GIouUPeORsjsVrJuSykgZAOWAZAf.Start();
					kyHuxqGhrxoIBcaIkIbtFafYRRgS2.YBUcatgFQZQBZfcuvHVkLyWNrOfN.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					GIouUPeORsjsVrJuSykgZAOWAZAf = null;
					qCveNJhihJTsYcbsMPQcqmlTrKoZ = true;
					return false;
				}
			}

			private void akekbrgpWhEwyBvOfuFVwFJJJEUNA()
			{
				zPfGtwHnIxxrWCOysBpGFMIOTfWoA = true;
				while (!HzCjzikPaHPRYxOMwsImqtXVFvzH)
				{
					MyQnyBDhWCHwzAjWwpVxMOVyaGlY.WaitOne();
					if (HzCjzikPaHPRYxOMwsImqtXVFvzH)
					{
						break;
					}
					lock (MKlYhjiOlcEeXNONAVnUxyERSFdj)
					{
						MiscTools.Swap(ref VXgwZuxSJTjvGsKutZVGUFdMNDsL, ref EOlqVmMPwHnUBvJnODDhJpxOUaBr);
					}
					List<WaitCallback> eOlqVmMPwHnUBvJnODDhJpxOUaBr = EOlqVmMPwHnUBvJnODDhJpxOUaBr;
					int count = eOlqVmMPwHnUBvJnODDhJpxOUaBr.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							eOlqVmMPwHnUBvJnODDhJpxOUaBr[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					eOlqVmMPwHnUBvJnODDhJpxOUaBr.Clear();
				}
				lock (MKlYhjiOlcEeXNONAVnUxyERSFdj)
				{
					VXgwZuxSJTjvGsKutZVGUFdMNDsL.Clear();
					EOlqVmMPwHnUBvJnODDhJpxOUaBr.Clear();
				}
				HzCjzikPaHPRYxOMwsImqtXVFvzH = false;
				zPfGtwHnIxxrWCOysBpGFMIOTfWoA = false;
			}

			private void rPcVaHMlxYrITvnctWyKUBTpIZPO()
			{
				GIouUPeORsjsVrJuSykgZAOWAZAf = null;
				qCveNJhihJTsYcbsMPQcqmlTrKoZ = false;
				HzCjzikPaHPRYxOMwsImqtXVFvzH = true;
			}

			private void feicISuJaQyHBbHOQdtqthPxlxt()
			{
				rPcVaHMlxYrITvnctWyKUBTpIZPO();
				try
				{
					MyQnyBDhWCHwzAjWwpVxMOVyaGlY.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				MIQWbwhKFhvHBncOYTAvDiFzvAqV(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void WcURtzATlsoifGftWWSBsUABaptv()
			{
				try
				{
					MIQWbwhKFhvHBncOYTAvDiFzvAqV(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void MIQWbwhKFhvHBncOYTAvDiFzvAqV(bool P_0)
			{
				if (!qBJdmRIeZzDWZMJQPJnQqSdvOBOab)
				{
					feicISuJaQyHBbHOQdtqthPxlxt();
					qBJdmRIeZzDWZMJQPJnQqSdvOBOab = true;
				}
			}
		}

		private static cpTGdfAqMMEohovbihOVdTWkSURsA PPRfGYHUHnSFkJSRPvDwtTgNoaSbA;

		private kxWEPYizlbUlwucnEmNyhfZziMzK ESnDKyErLKMprHrKcHnIJvntjvLxB;

		private int IThbgMsLQWlJsUlKmQdXIscKgfsg;

		private bool BvVoWkkLZVvkfENDcGeafncIYJqj;

		private static cpTGdfAqMMEohovbihOVdTWkSURsA wrJvZfUCuxQlmCWBIAQhCorVWeru => PPRfGYHUHnSFkJSRPvDwtTgNoaSbA ?? new cpTGdfAqMMEohovbihOVdTWkSURsA();

		private kxWEPYizlbUlwucnEmNyhfZziMzK WcfOlzWElilIjpWuGGseRHMJictD => ESnDKyErLKMprHrKcHnIJvntjvLxB ?? (ESnDKyErLKMprHrKcHnIJvntjvLxB = new kxWEPYizlbUlwucnEmNyhfZziMzK());

		private cpTGdfAqMMEohovbihOVdTWkSURsA()
		{
			PPRfGYHUHnSFkJSRPvDwtTgNoaSbA?.qZRlXFoNtJpOAVcMtfUznlwcIcEy();
			PPRfGYHUHnSFkJSRPvDwtTgNoaSbA = this;
		}

		private void xABazaHWyZwrnerbtNiJqcyCyhId()
		{
			IThbgMsLQWlJsUlKmQdXIscKgfsg++;
		}

		private void gMawAteKluFSEKfdRXKEvJUwnVeF()
		{
			IThbgMsLQWlJsUlKmQdXIscKgfsg--;
			if (IThbgMsLQWlJsUlKmQdXIscKgfsg < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (IThbgMsLQWlJsUlKmQdXIscKgfsg == 0)
			{
				qZRlXFoNtJpOAVcMtfUznlwcIcEy();
			}
		}

		private void AwzrqaKMcpKEkJCLGagnsoPQbwZC(WaitCallback P_0)
		{
			WcfOlzWElilIjpWuGGseRHMJictD.QgxarMvaMdaHKflHljlUBqudqjvoB(P_0);
		}

		private void OrGgNVQUyoBjbquItTIPzRVYRRVb()
		{
			WcfOlzWElilIjpWuGGseRHMJictD.oZwFCCfePjCGYDGkiMAaBMGzLuCTb();
		}

		private bool BOplFKOhkIPEAHmdVdRSgarAJcsHb()
		{
			return WcfOlzWElilIjpWuGGseRHMJictD.FiEdhlcYCGhiBnCAfQXXOwPodfunA();
		}

		private void qZRlXFoNtJpOAVcMtfUznlwcIcEy()
		{
			qJBOusVbvABnwaRcKPaUrYgZrZEi(true);
			GC.SuppressFinalize(this);
		}

		protected void cfgNHegreRdAkHhEYgOzhTpWSAgIb()
		{
			try
			{
				qJBOusVbvABnwaRcKPaUrYgZrZEi(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void qJBOusVbvABnwaRcKPaUrYgZrZEi(bool P_0)
		{
			if (!BvVoWkkLZVvkfENDcGeafncIYJqj)
			{
				if (P_0 && ESnDKyErLKMprHrKcHnIJvntjvLxB != null)
				{
					ESnDKyErLKMprHrKcHnIJvntjvLxB.Dispose();
					ESnDKyErLKMprHrKcHnIJvntjvLxB = null;
				}
				IThbgMsLQWlJsUlKmQdXIscKgfsg = 0;
				if (PPRfGYHUHnSFkJSRPvDwtTgNoaSbA == this)
				{
					PPRfGYHUHnSFkJSRPvDwtTgNoaSbA = null;
				}
				BvVoWkkLZVvkfENDcGeafncIYJqj = true;
			}
		}

		public static void iHmxguKubZWZmgUTdCUbiTeYmbTf()
		{
			wrJvZfUCuxQlmCWBIAQhCorVWeru.xABazaHWyZwrnerbtNiJqcyCyhId();
		}

		public static void qlXUomaAorIzKIrpPyRISoIavwQm()
		{
			PPRfGYHUHnSFkJSRPvDwtTgNoaSbA?.gMawAteKluFSEKfdRXKEvJUwnVeF();
		}

		public static void qebaHRuQuTyldbHIikLZVITtSpnf(WaitCallback P_0)
		{
			wrJvZfUCuxQlmCWBIAQhCorVWeru.AwzrqaKMcpKEkJCLGagnsoPQbwZC(P_0);
		}
	}

	private kYNdwUuPEungDZHaQGcQSMqKqxSI HQICNGQTOZFUbBLaAFFbwEHJWFJpA;

	private _0001 YeOCrAXpvfZxUOECruVDxnYFjQRk;

	private WaitCallback VtYjnzQYOsErplOEYxIhDCSVvyVb;

	private object WGlqLCUiBLVVeItmsnhWMWnlRisr;

	private Func<_0001> nIymdvQLgSaLTuyRrMEVhurIeDdv;

	private bool TjPUERucsMZbmtsZKGpeBCOOqLzv;

	private bool vnyIRXLDaXWwCOanxKCwscAuSlFh;

	public bool YASgmbEQfqbFGemfMILquknsdBcZA
	{
		get
		{
			if (HQICNGQTOZFUbBLaAFFbwEHJWFJpA != kYNdwUuPEungDZHaQGcQSMqKqxSI.AwaitingResult)
			{
				return HQICNGQTOZFUbBLaAFFbwEHJWFJpA == kYNdwUuPEungDZHaQGcQSMqKqxSI.ResultReceived;
			}
			return true;
		}
	}

	public _0001 GQeIAxmbSyejgKlIwwQaiAqYidcZA => YeOCrAXpvfZxUOECruVDxnYFjQRk;

	public bool CUmiTZTnrHmOILdUvpnQSdUBdzmgA()
	{
		bool num = HQICNGQTOZFUbBLaAFFbwEHJWFJpA == kYNdwUuPEungDZHaQGcQSMqKqxSI.ResultReceived;
		if (num)
		{
			HQICNGQTOZFUbBLaAFFbwEHJWFJpA = kYNdwUuPEungDZHaQGcQSMqKqxSI.Idle;
		}
		return num;
	}

	public tYSDRrlmOWDSjWBhfIKGoQYXYEzm(bool P_0, Func<_0001> P_1)
	{
		TjPUERucsMZbmtsZKGpeBCOOqLzv = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		nIymdvQLgSaLTuyRrMEVhurIeDdv = P_1;
		VtYjnzQYOsErplOEYxIhDCSVvyVb = LHQyfWoPzLCTYVjzAVpJNkYOmvWe;
		WGlqLCUiBLVVeItmsnhWMWnlRisr = new object();
		HQICNGQTOZFUbBLaAFFbwEHJWFJpA = kYNdwUuPEungDZHaQGcQSMqKqxSI.Idle;
		if (P_0)
		{
			cpTGdfAqMMEohovbihOVdTWkSURsA.iHmxguKubZWZmgUTdCUbiTeYmbTf();
		}
	}

	public bool iHiGIFABtyBNGjnHrdGZBnbyaQGe()
	{
		lock (WGlqLCUiBLVVeItmsnhWMWnlRisr)
		{
			if (HQICNGQTOZFUbBLaAFFbwEHJWFJpA == kYNdwUuPEungDZHaQGcQSMqKqxSI.AwaitingResult)
			{
				return false;
			}
			YeOCrAXpvfZxUOECruVDxnYFjQRk = default(_0001);
			HQICNGQTOZFUbBLaAFFbwEHJWFJpA = kYNdwUuPEungDZHaQGcQSMqKqxSI.AwaitingResult;
		}
		if (TjPUERucsMZbmtsZKGpeBCOOqLzv)
		{
			cpTGdfAqMMEohovbihOVdTWkSURsA.qebaHRuQuTyldbHIikLZVITtSpnf(VtYjnzQYOsErplOEYxIhDCSVvyVb);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(VtYjnzQYOsErplOEYxIhDCSVvyVb, this);
		}
		return true;
	}

	public void YYGEFUKeavnCFHfYobUgfZFmeDSI()
	{
		lock (WGlqLCUiBLVVeItmsnhWMWnlRisr)
		{
			YeOCrAXpvfZxUOECruVDxnYFjQRk = default(_0001);
			HQICNGQTOZFUbBLaAFFbwEHJWFJpA = kYNdwUuPEungDZHaQGcQSMqKqxSI.Idle;
		}
	}

	private void LHQyfWoPzLCTYVjzAVpJNkYOmvWe(object P_0)
	{
		lock (WGlqLCUiBLVVeItmsnhWMWnlRisr)
		{
			if (HQICNGQTOZFUbBLaAFFbwEHJWFJpA == kYNdwUuPEungDZHaQGcQSMqKqxSI.AwaitingResult)
			{
				YeOCrAXpvfZxUOECruVDxnYFjQRk = nIymdvQLgSaLTuyRrMEVhurIeDdv();
				HQICNGQTOZFUbBLaAFFbwEHJWFJpA = kYNdwUuPEungDZHaQGcQSMqKqxSI.ResultReceived;
			}
		}
	}

	public void VshDPveQjVqQFgogDGildcmcWyJLc()
	{
		GixxThFgBFmziNkjtwhXSgKPcmICA(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void mkCdvpHpLPESBWIIRYyNGQPscWyUA()
	{
		try
		{
			GixxThFgBFmziNkjtwhXSgKPcmICA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void GixxThFgBFmziNkjtwhXSgKPcmICA(bool P_0)
	{
		if (!vnyIRXLDaXWwCOanxKCwscAuSlFh)
		{
			if (P_0)
			{
				YYGEFUKeavnCFHfYobUgfZFmeDSI();
			}
			if (TjPUERucsMZbmtsZKGpeBCOOqLzv)
			{
				cpTGdfAqMMEohovbihOVdTWkSURsA.qlXUomaAorIzKIrpPyRISoIavwQm();
			}
			vnyIRXLDaXWwCOanxKCwscAuSlFh = true;
		}
	}
}
