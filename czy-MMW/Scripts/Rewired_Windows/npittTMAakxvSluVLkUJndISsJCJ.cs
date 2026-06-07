using System;
using System.Collections.Generic;
using System.Threading;
using Rewired;
using Rewired.Utils;

internal class npittTMAakxvSluVLkUJndISsJCJ<_0001>
{
	private enum aqjITcNfjSMCwyoQskkNDMsXJUns
	{
		Idle = 0,
		AwaitingResult = 1,
		ResultReceived = 2
	}

	private sealed class wtfXQPhDkqFFSHXPSyNMAGQfyRmh
	{
		private class iUsxkqVtXLdRTTaTwAEjiCXiLCWx : IDisposable
		{
			private sealed class BMZAxHcSKSAXRDHrFFksAzsdrPkQE
			{
				public iUsxkqVtXLdRTTaTwAEjiCXiLCWx nmLgcmwXXOBpOUdDyfKADvVtkbMj;

				public ManualResetEvent NNCkCIjPaZPuYWaszNWTVVkkHoJs;

				internal void ZiTjLyqBKMDHAXtiPkfNjdfyHlDL()
				{
					NNCkCIjPaZPuYWaszNWTVVkkHoJs.Set();
					nmLgcmwXXOBpOUdDyfKADvVtkbMj.alEBNDTmBHJzTQqvNfhIWVjUccrG();
				}
			}

			private readonly object MTXcsPbLLUZraJeleypNuWCEceUGA;

			private List<WaitCallback> JNOdEUJOlrKGhnZSRpvBeBpROfTDA;

			private List<WaitCallback> KaTxUVbYUtbuLEPHgpekKfNLCwkC;

			private Thread CIOeOlILzYBCgECSdsGdGWYjPexRB;

			private AutoResetEvent SPiKAlikjiJfIbCgUvauHeLhCeEw;

			private bool vRXNrSsjeVUHljKKYJxRZQQVRWvI;

			private bool XmwDVQJrYrzitSzeABEbjnJSItWkA;

			private bool woPzSzDnFjJgnKDKkcVlzBrEKaBv;

			private bool wpbOZrLOvZxVwauuhVoDNcrokthy;

			public iUsxkqVtXLdRTTaTwAEjiCXiLCWx()
			{
				MTXcsPbLLUZraJeleypNuWCEceUGA = new object();
				JNOdEUJOlrKGhnZSRpvBeBpROfTDA = new List<WaitCallback>();
				KaTxUVbYUtbuLEPHgpekKfNLCwkC = new List<WaitCallback>();
				SPiKAlikjiJfIbCgUvauHeLhCeEw = new AutoResetEvent(initialState: false);
			}

			public void IfFAJqAAoZxaxwQhTUVHHhiddNUyA(WaitCallback P_0)
			{
				if (MsDqYCFhCKTwJcEBzVYjQFURfHfh())
				{
					if (P_0 == null)
					{
						throw new ArgumentNullException("waitCallback");
					}
					lock (MTXcsPbLLUZraJeleypNuWCEceUGA)
					{
						JNOdEUJOlrKGhnZSRpvBeBpROfTDA.Add(P_0);
					}
					SPiKAlikjiJfIbCgUvauHeLhCeEw.Set();
				}
			}

			private bool MsDqYCFhCKTwJcEBzVYjQFURfHfh()
			{
				BMZAxHcSKSAXRDHrFFksAzsdrPkQE bMZAxHcSKSAXRDHrFFksAzsdrPkQE = new BMZAxHcSKSAXRDHrFFksAzsdrPkQE();
				bMZAxHcSKSAXRDHrFFksAzsdrPkQE.nmLgcmwXXOBpOUdDyfKADvVtkbMj = this;
				if (woPzSzDnFjJgnKDKkcVlzBrEKaBv)
				{
					return false;
				}
				if (XmwDVQJrYrzitSzeABEbjnJSItWkA)
				{
					return false;
				}
				if (vRXNrSsjeVUHljKKYJxRZQQVRWvI)
				{
					return true;
				}
				if (CIOeOlILzYBCgECSdsGdGWYjPexRB != null)
				{
					return true;
				}
				try
				{
					bMZAxHcSKSAXRDHrFFksAzsdrPkQE.NNCkCIjPaZPuYWaszNWTVVkkHoJs = new ManualResetEvent(initialState: false);
					CIOeOlILzYBCgECSdsGdGWYjPexRB = new Thread(bMZAxHcSKSAXRDHrFFksAzsdrPkQE.ZiTjLyqBKMDHAXtiPkfNjdfyHlDL);
					CIOeOlILzYBCgECSdsGdGWYjPexRB.Start();
					bMZAxHcSKSAXRDHrFFksAzsdrPkQE.NNCkCIjPaZPuYWaszNWTVVkkHoJs.WaitOne();
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred trying to initialize the thread pool.\n" + ex, requiredThreadSafety: true);
					CIOeOlILzYBCgECSdsGdGWYjPexRB = null;
					woPzSzDnFjJgnKDKkcVlzBrEKaBv = true;
					return false;
				}
			}

			private void alEBNDTmBHJzTQqvNfhIWVjUccrG()
			{
				vRXNrSsjeVUHljKKYJxRZQQVRWvI = true;
				while (!XmwDVQJrYrzitSzeABEbjnJSItWkA)
				{
					SPiKAlikjiJfIbCgUvauHeLhCeEw.WaitOne();
					if (XmwDVQJrYrzitSzeABEbjnJSItWkA)
					{
						break;
					}
					lock (MTXcsPbLLUZraJeleypNuWCEceUGA)
					{
						MiscTools.Swap(ref JNOdEUJOlrKGhnZSRpvBeBpROfTDA, ref KaTxUVbYUtbuLEPHgpekKfNLCwkC);
					}
					List<WaitCallback> kaTxUVbYUtbuLEPHgpekKfNLCwkC = KaTxUVbYUtbuLEPHgpekKfNLCwkC;
					int count = kaTxUVbYUtbuLEPHgpekKfNLCwkC.Count;
					if (count == 0)
					{
						continue;
					}
					for (int i = 0; i < count; i++)
					{
						try
						{
							kaTxUVbYUtbuLEPHgpekKfNLCwkC[i](null);
						}
						catch (Exception ex)
						{
							Logger.LogError("Exception occurred in thread pool callback.\n" + ex, requiredThreadSafety: true);
						}
					}
					kaTxUVbYUtbuLEPHgpekKfNLCwkC.Clear();
				}
				lock (MTXcsPbLLUZraJeleypNuWCEceUGA)
				{
					JNOdEUJOlrKGhnZSRpvBeBpROfTDA.Clear();
					KaTxUVbYUtbuLEPHgpekKfNLCwkC.Clear();
				}
				XmwDVQJrYrzitSzeABEbjnJSItWkA = false;
				vRXNrSsjeVUHljKKYJxRZQQVRWvI = false;
			}

			private void hvOCKxrtNeRfoYNIDzUXVFNqubyy()
			{
				CIOeOlILzYBCgECSdsGdGWYjPexRB = null;
				woPzSzDnFjJgnKDKkcVlzBrEKaBv = false;
				XmwDVQJrYrzitSzeABEbjnJSItWkA = true;
			}

			private void xDEqEiRMxORXmUwfqOXmxHlOnDYO()
			{
				hvOCKxrtNeRfoYNIDzUXVFNqubyy();
				try
				{
					SPiKAlikjiJfIbCgUvauHeLhCeEw.Set();
				}
				catch (ObjectDisposedException)
				{
				}
			}

			public void Dispose()
			{
				QCceLMUwrTSiuCkukWscOjXugkDz(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void CglJPLpXYzFAbxFqQkWTzOOWXCx()
			{
				try
				{
					QCceLMUwrTSiuCkukWscOjXugkDz(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void QCceLMUwrTSiuCkukWscOjXugkDz(bool P_0)
			{
				if (!wpbOZrLOvZxVwauuhVoDNcrokthy)
				{
					xDEqEiRMxORXmUwfqOXmxHlOnDYO();
					wpbOZrLOvZxVwauuhVoDNcrokthy = true;
				}
			}
		}

		private static wtfXQPhDkqFFSHXPSyNMAGQfyRmh VbteokdstPkNHxPlllIxAnyAExlh;

		private iUsxkqVtXLdRTTaTwAEjiCXiLCWx YSTsvUUSrsALGOOkzDTVgStuLXkh;

		private int KoJoDaTojwZOLtLLYgiYLlyXIOLs;

		private bool TPpDQEBxdzfGOBdfMSonfesLvsRvA;

		private static wtfXQPhDkqFFSHXPSyNMAGQfyRmh aTbdjJdcCJFKXInjmrgcnVfYPEGMA => VbteokdstPkNHxPlllIxAnyAExlh ?? new wtfXQPhDkqFFSHXPSyNMAGQfyRmh();

		private iUsxkqVtXLdRTTaTwAEjiCXiLCWx YYTiuNdKkAEKKHSoiWczqWXWmSMtA => YSTsvUUSrsALGOOkzDTVgStuLXkh ?? (YSTsvUUSrsALGOOkzDTVgStuLXkh = new iUsxkqVtXLdRTTaTwAEjiCXiLCWx());

		private wtfXQPhDkqFFSHXPSyNMAGQfyRmh()
		{
			VbteokdstPkNHxPlllIxAnyAExlh?.mLfDNjDHLhqAniykGDiogcifrWjbd();
			VbteokdstPkNHxPlllIxAnyAExlh = this;
		}

		private void pNpKUYkZmtTQYVdXNCjOhHyJtQfo()
		{
			KoJoDaTojwZOLtLLYgiYLlyXIOLs++;
		}

		private void oVCkQDXdVQMezxMTpGbZwpQndJBQ()
		{
			KoJoDaTojwZOLtLLYgiYLlyXIOLs--;
			if (KoJoDaTojwZOLtLLYgiYLlyXIOLs < 0)
			{
				Logger.LogError("SharedThread: Too many calls to Unregister.", requiredThreadSafety: true);
			}
			if (KoJoDaTojwZOLtLLYgiYLlyXIOLs == 0)
			{
				mLfDNjDHLhqAniykGDiogcifrWjbd();
			}
		}

		private void KEVlDErImRmdVcGaozUizPmDlDiQ(WaitCallback P_0)
		{
			YYTiuNdKkAEKKHSoiWczqWXWmSMtA.IfFAJqAAoZxaxwQhTUVHHhiddNUyA(P_0);
		}

		private void mLfDNjDHLhqAniykGDiogcifrWjbd()
		{
			sedgmEukJctqRLBSoPvRmXoCQTbt(true);
			GC.SuppressFinalize(this);
		}

		protected void gjQbjMHYFrnZJGyxisQwUjDVsjNd()
		{
			try
			{
				sedgmEukJctqRLBSoPvRmXoCQTbt(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		private void sedgmEukJctqRLBSoPvRmXoCQTbt(bool P_0)
		{
			if (!TPpDQEBxdzfGOBdfMSonfesLvsRvA)
			{
				if (P_0 && YSTsvUUSrsALGOOkzDTVgStuLXkh != null)
				{
					YSTsvUUSrsALGOOkzDTVgStuLXkh.Dispose();
					YSTsvUUSrsALGOOkzDTVgStuLXkh = null;
				}
				KoJoDaTojwZOLtLLYgiYLlyXIOLs = 0;
				if (VbteokdstPkNHxPlllIxAnyAExlh == this)
				{
					VbteokdstPkNHxPlllIxAnyAExlh = null;
				}
				TPpDQEBxdzfGOBdfMSonfesLvsRvA = true;
			}
		}

		public static void ghOoRAbMOfilPhZsBjgafpLDiGszA()
		{
			aTbdjJdcCJFKXInjmrgcnVfYPEGMA.pNpKUYkZmtTQYVdXNCjOhHyJtQfo();
		}

		public static void cZvdWYDfUXTWrdiJtUlVDsWniQdT()
		{
			VbteokdstPkNHxPlllIxAnyAExlh?.oVCkQDXdVQMezxMTpGbZwpQndJBQ();
		}

		public static void eaLEUfdDKtsVApMeOdEWvETefaEjb(WaitCallback P_0)
		{
			aTbdjJdcCJFKXInjmrgcnVfYPEGMA.KEVlDErImRmdVcGaozUizPmDlDiQ(P_0);
		}
	}

	private aqjITcNfjSMCwyoQskkNDMsXJUns TUmnewzAgtJtGkVAirdkVqDGlrsW;

	private _0001 AtetVekpHTASrvCuXblAgwQYVLsHA;

	private WaitCallback XHulPXbbiICpYOTygZLPWqMQmVFY;

	private object ERSpcczbbFsFZlUQdVNxNburOXiA;

	private Func<_0001> jSEPVenYleuitLjPBmYcipgHngID;

	private bool LclFclVpCgNCHKCdiXRfACANGbQz;

	private bool hHGjwfeBvfNfvvRGXCgdfVWvMyak;

	public bool QNkWrLdeVAqfzHLJahJtrCjbJhLT
	{
		get
		{
			if (TUmnewzAgtJtGkVAirdkVqDGlrsW != aqjITcNfjSMCwyoQskkNDMsXJUns.AwaitingResult)
			{
				return TUmnewzAgtJtGkVAirdkVqDGlrsW == aqjITcNfjSMCwyoQskkNDMsXJUns.ResultReceived;
			}
			return true;
		}
	}

	public _0001 EyIwVPNagGOHFKJkAaktBCeJeFLT => AtetVekpHTASrvCuXblAgwQYVLsHA;

	public bool OGYjjpkJopdcraeeXRZPVQYSFoHJ()
	{
		bool num = TUmnewzAgtJtGkVAirdkVqDGlrsW == aqjITcNfjSMCwyoQskkNDMsXJUns.ResultReceived;
		if (num)
		{
			TUmnewzAgtJtGkVAirdkVqDGlrsW = aqjITcNfjSMCwyoQskkNDMsXJUns.Idle;
		}
		return num;
	}

	public npittTMAakxvSluVLkUJndISsJCJ(bool P_0, Func<_0001> P_1)
	{
		LclFclVpCgNCHKCdiXRfACANGbQz = P_0;
		if (P_1 == null)
		{
			throw new ArgumentNullException("resultDelegate");
		}
		jSEPVenYleuitLjPBmYcipgHngID = P_1;
		XHulPXbbiICpYOTygZLPWqMQmVFY = VgyoGgNqbbkprgSRyprOEIkHDQrR;
		ERSpcczbbFsFZlUQdVNxNburOXiA = new object();
		TUmnewzAgtJtGkVAirdkVqDGlrsW = aqjITcNfjSMCwyoQskkNDMsXJUns.Idle;
		if (P_0)
		{
			wtfXQPhDkqFFSHXPSyNMAGQfyRmh.ghOoRAbMOfilPhZsBjgafpLDiGszA();
		}
	}

	public bool qAWTketRvCdmkOgJVrHCCVbnLSdx()
	{
		lock (ERSpcczbbFsFZlUQdVNxNburOXiA)
		{
			if (TUmnewzAgtJtGkVAirdkVqDGlrsW == aqjITcNfjSMCwyoQskkNDMsXJUns.AwaitingResult)
			{
				return false;
			}
			AtetVekpHTASrvCuXblAgwQYVLsHA = default(_0001);
			TUmnewzAgtJtGkVAirdkVqDGlrsW = aqjITcNfjSMCwyoQskkNDMsXJUns.AwaitingResult;
		}
		if (LclFclVpCgNCHKCdiXRfACANGbQz)
		{
			wtfXQPhDkqFFSHXPSyNMAGQfyRmh.eaLEUfdDKtsVApMeOdEWvETefaEjb(XHulPXbbiICpYOTygZLPWqMQmVFY);
		}
		else
		{
			ThreadPool.QueueUserWorkItem(XHulPXbbiICpYOTygZLPWqMQmVFY, this);
		}
		return true;
	}

	public void GwueoqldKDESkkscWQTdVaBdpUdEA()
	{
		lock (ERSpcczbbFsFZlUQdVNxNburOXiA)
		{
			AtetVekpHTASrvCuXblAgwQYVLsHA = default(_0001);
			TUmnewzAgtJtGkVAirdkVqDGlrsW = aqjITcNfjSMCwyoQskkNDMsXJUns.Idle;
		}
	}

	private void VgyoGgNqbbkprgSRyprOEIkHDQrR(object P_0)
	{
		lock (ERSpcczbbFsFZlUQdVNxNburOXiA)
		{
			if (TUmnewzAgtJtGkVAirdkVqDGlrsW == aqjITcNfjSMCwyoQskkNDMsXJUns.AwaitingResult)
			{
				AtetVekpHTASrvCuXblAgwQYVLsHA = jSEPVenYleuitLjPBmYcipgHngID();
				TUmnewzAgtJtGkVAirdkVqDGlrsW = aqjITcNfjSMCwyoQskkNDMsXJUns.ResultReceived;
			}
		}
	}

	public void ZsTnXJbLVbjRqPCSwHQgfEuNnYwm()
	{
		WpBvRDoGnfGwPwxVJDsKXbIGCGjK(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void gAyVLPGHrdhUevFwreEOTTHtkkVV()
	{
		try
		{
			WpBvRDoGnfGwPwxVJDsKXbIGCGjK(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void WpBvRDoGnfGwPwxVJDsKXbIGCGjK(bool P_0)
	{
		if (!hHGjwfeBvfNfvvRGXCgdfVWvMyak)
		{
			if (P_0)
			{
				GwueoqldKDESkkscWQTdVaBdpUdEA();
			}
			if (LclFclVpCgNCHKCdiXRfACANGbQz)
			{
				wtfXQPhDkqFFSHXPSyNMAGQfyRmh.cZvdWYDfUXTWrdiJtUlVDsWniQdT();
			}
			hHGjwfeBvfNfvvRGXCgdfVWvMyak = true;
		}
	}
}
