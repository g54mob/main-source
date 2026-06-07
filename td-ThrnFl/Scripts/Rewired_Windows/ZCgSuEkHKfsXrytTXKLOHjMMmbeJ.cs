using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class ZCgSuEkHKfsXrytTXKLOHjMMmbeJ : IDisposable
{
	private abstract class CsoJsOsZUMUcBTjRldnQLFDSekBaA : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool UXhqgPUQiMvxTxpwDuDZmvjDhXtl;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return UXhqgPUQiMvxTxpwDuDZmvjDhXtl;
			}
			[CompilerGenerated]
			set
			{
				UXhqgPUQiMvxTxpwDuDZmvjDhXtl = value;
			}
		}

		protected abstract void Clear();

		void IPoolableObject_Internal.Clear()
		{
			Clear();
		}

		void IDisposable.Dispose()
		{
			Return();
		}

		public void Return()
		{
			((IPoolableObject_Internal)this).pool?.Return(this);
		}

		void IPoolableObject.Return()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Return
			this.Return();
		}
	}

	private class hpNvDUpSUZVHBWkqxgiDmOtLvKmH : CsoJsOsZUMUcBTjRldnQLFDSekBaA
	{
		public YiNGTscaFlfcYGbkCqpCNRhAgAbi WmmZdoTHReDCVimeJnxEbJNlSKZsA;

		public dPRXSTAtGIjVCqYJlEOTHkKLkTfM NBHwoUnHmLFHjAxZFQCUjClhcAXqA;

		public double rIGNfyDYhoftTaJNOiudXYBRHtUB;

		protected virtual void vvqvZdQFJfkyyvzczRWGEbXKaToaA()
		{
			WmmZdoTHReDCVimeJnxEbJNlSKZsA = null;
			NBHwoUnHmLFHjAxZFQCUjClhcAXqA = default(dPRXSTAtGIjVCqYJlEOTHkKLkTfM);
			rIGNfyDYhoftTaJNOiudXYBRHtUB = 0.0;
		}
	}

	private sealed class JIagzAPYQiXXGasXSfmZSInBOxxd : CsoJsOsZUMUcBTjRldnQLFDSekBaA
	{
		public YiNGTscaFlfcYGbkCqpCNRhAgAbi LYnyAWTJrjDSZhiUdBttzaiyFjSC;

		public gXscSvKVwaCJjrRAEGEwVgIGOxHD JVHhVEOcsUSjmBInrKdHQcUYRnpp;

		protected void lzTXpnIbHkTPzPGQgZjJUvXOKQwJ()
		{
			LYnyAWTJrjDSZhiUdBttzaiyFjSC = null;
			JVHhVEOcsUSjmBInrKdHQcUYRnpp = default(gXscSvKVwaCJjrRAEGEwVgIGOxHD);
		}
	}

	[Serializable]
	private sealed class WcEigLDsVYYCTNaFXBXCmTuNHVci
	{
		public static readonly WcEigLDsVYYCTNaFXBXCmTuNHVci _003C_003E9 = new WcEigLDsVYYCTNaFXBXCmTuNHVci();

		public static Func<hpNvDUpSUZVHBWkqxgiDmOtLvKmH> _003C_003E9__19_0;

		public static Func<JIagzAPYQiXXGasXSfmZSInBOxxd> _003C_003E9__19_1;

		internal hpNvDUpSUZVHBWkqxgiDmOtLvKmH nXxKKTSDfXZCrDxEtCUfzHFiEDru()
		{
			return new hpNvDUpSUZVHBWkqxgiDmOtLvKmH();
		}

		internal JIagzAPYQiXXGasXSfmZSInBOxxd wdhVLJbkzAzvqSTrMtGXUzkeCofT()
		{
			return new JIagzAPYQiXXGasXSfmZSInBOxxd();
		}
	}

	private readonly List<dAMJUizrgPTBRKExuFwRvYIoTEmL> FLWwRvYwRfQgXPKsMlrAeatNpvnl;

	private readonly ReadOnlyCollection<dAMJUizrgPTBRKExuFwRvYIoTEmL> XLqvhPMgCfsMJRYClFUcvWzaCcqt;

	private readonly List<YiNGTscaFlfcYGbkCqpCNRhAgAbi> yydXGwyAdaAzdehMLqpBHJYUNKNEb;

	private readonly Func<int> TAAHeUfAwXqfxXiGdkvqWqyVWFBC;

	private readonly Rewired.Utils.Classes.Utility.SpinLock yNpYRzRRLrCDnYxLhwnbtaPomANy = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock FPkFCGSTILeRbfRbIgQPQPJQtxJAA = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<hpNvDUpSUZVHBWkqxgiDmOtLvKmH> PmgsLiZjMyGEYGSMWFCTxCoCHQuFA;

	private RingBuffer<JIagzAPYQiXXGasXSfmZSInBOxxd> yoYdzkSNnyYsFQOchHKPqLbxMasN;

	private bool JiEDaleZvheoVhZyEvshjBbqmfORc;

	private readonly ThreadSafeObjectPool<hpNvDUpSUZVHBWkqxgiDmOtLvKmH> CMLslewOBYLVglOsIOHMNhcqZpPu;

	private readonly ThreadSafeObjectPool<JIagzAPYQiXXGasXSfmZSInBOxxd> CPvvrmyFQZZQOcjidnsIdPTSjCQp;

	private readonly List<dAMJUizrgPTBRKExuFwRvYIoTEmL> EinBIYAMvRdOCJQEYjrzVEJXQGqe;

	private RingBuffer<hpNvDUpSUZVHBWkqxgiDmOtLvKmH> wmjkLjXveCxiSWqPKrAuXwoLEsaQ;

	private RingBuffer<JIagzAPYQiXXGasXSfmZSInBOxxd> BsUvHZXejpcGhqUQyYdHRXSTsBvf;

	private bool DybbFxlquDlVdkusamHNcdMMKJOB;

	private Action<YiNGTscaFlfcYGbkCqpCNRhAgAbi, gXscSvKVwaCJjrRAEGEwVgIGOxHD> MtUqZaFbtvLaVkjjAnTlfuljFStg;

	[CompilerGenerated]
	private Action m_qCMhKpLyztkyPvAMKCOGJepqtsTz;

	private bool XyhgmolKGtcgszdIKegYstbJnHqN;

	private static Guid[] dfXKcEvhCkwHiYQXCYNAgrFHbdfi;

	private static string[] SBYnakeGkPozSmBESNZlvwNeBspm;

	private static string[] UTZWAspHDZSPqmuFYuUNzQfLEWSH;

	public event Action qCMhKpLyztkyPvAMKCOGJepqtsTz
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_qCMhKpLyztkyPvAMKCOGJepqtsTz;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_qCMhKpLyztkyPvAMKCOGJepqtsTz, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_qCMhKpLyztkyPvAMKCOGJepqtsTz;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_qCMhKpLyztkyPvAMKCOGJepqtsTz, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public ZCgSuEkHKfsXrytTXKLOHjMMmbeJ(Func<int> P_0)
	{
		TAAHeUfAwXqfxXiGdkvqWqyVWFBC = P_0;
		MtUqZaFbtvLaVkjjAnTlfuljFStg = IPOBLYVWYGdwKMmdVrYohuGaUdUB;
		FLWwRvYwRfQgXPKsMlrAeatNpvnl = new List<dAMJUizrgPTBRKExuFwRvYIoTEmL>();
		EinBIYAMvRdOCJQEYjrzVEJXQGqe = new List<dAMJUizrgPTBRKExuFwRvYIoTEmL>();
		XLqvhPMgCfsMJRYClFUcvWzaCcqt = new ReadOnlyCollection<dAMJUizrgPTBRKExuFwRvYIoTEmL>(FLWwRvYwRfQgXPKsMlrAeatNpvnl);
		yydXGwyAdaAzdehMLqpBHJYUNKNEb = new List<YiNGTscaFlfcYGbkCqpCNRhAgAbi>();
		JiEDaleZvheoVhZyEvshjBbqmfORc = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)WNDYrcPDOUObmqnBCmqijYTVsDhn.CPLaRrFzUcOrwvDuUKrdhlDtwzfD * 32f) + 1;
		CMLslewOBYLVglOsIOHMNhcqZpPu = new ThreadSafeObjectPool<hpNvDUpSUZVHBWkqxgiDmOtLvKmH>(num, WcEigLDsVYYCTNaFXBXCmTuNHVci._003C_003E9.nXxKKTSDfXZCrDxEtCUfzHFiEDru);
		CPvvrmyFQZZQOcjidnsIdPTSjCQp = new ThreadSafeObjectPool<JIagzAPYQiXXGasXSfmZSInBOxxd>(128, WcEigLDsVYYCTNaFXBXCmTuNHVci._003C_003E9.wdhVLJbkzAzvqSTrMtGXUzkeCofT);
		PmgsLiZjMyGEYGSMWFCTxCoCHQuFA = new RingBuffer<hpNvDUpSUZVHBWkqxgiDmOtLvKmH>(num);
		yoYdzkSNnyYsFQOchHKPqLbxMasN = new RingBuffer<JIagzAPYQiXXGasXSfmZSInBOxxd>(128);
		wmjkLjXveCxiSWqPKrAuXwoLEsaQ = new RingBuffer<hpNvDUpSUZVHBWkqxgiDmOtLvKmH>(num);
		BsUvHZXejpcGhqUQyYdHRXSTsBvf = new RingBuffer<JIagzAPYQiXXGasXSfmZSInBOxxd>(128);
		YiNGTscaFlfcYGbkCqpCNRhAgAbi.cYkLOXtrZxmLORxyITFLAUxGbtwp += rbDRdKDtPxYEsEwdjInfSrPOwoz;
		YiNGTscaFlfcYGbkCqpCNRhAgAbi.QbwPtMGvBumDYhDjqHUHHKfxFGotA += lSalhpIUMVGEtGxsRoZqTqrWSVmn;
		WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent += QfkbmRDdNMUBIPciRGbzxNNZebBeb;
		WNDYrcPDOUObmqnBCmqijYTVsDhn.nytSzNVIhUWoXZDzKGaUmjqGlQXF.ThreadUpdateEvent += JpgfRqKRGdmkvFgaPrKZlWAAtlso;
		ReInput.ApplicationFocusChangedEvent += WpzgUmbGPeeUerarEicyDBnNNgKrA;
		ReInput.ApplicationPauseChangedEvent += AITndnDsmyVYovRtnluITTVGZJzB;
		YiNGTscaFlfcYGbkCqpCNRhAgAbi.FGjGuxKZklLGwAulNcXwOKAtrvBS();
		vnrlVZyJbAsBvfWJnNtfmpxZHTob();
	}

	public void SKAzQpcmSrbwreWnxiQCIcWrslZi()
	{
		bool flag = false;
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			if (DybbFxlquDlVdkusamHNcdMMKJOB)
			{
				DybbFxlquDlVdkusamHNcdMMKJOB = false;
				flag = true;
			}
		}
		if (flag)
		{
			vnrlVZyJbAsBvfWJnNtfmpxZHTob();
		}
	}

	public void QhJTPZKBRpRxMPHcTVHzeygqAHZg()
	{
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			MiscTools.Swap(ref PmgsLiZjMyGEYGSMWFCTxCoCHQuFA, ref wmjkLjXveCxiSWqPKrAuXwoLEsaQ);
		}
		while (PmgsLiZjMyGEYGSMWFCTxCoCHQuFA.Count > 0)
		{
			hpNvDUpSUZVHBWkqxgiDmOtLvKmH hpNvDUpSUZVHBWkqxgiDmOtLvKmH2 = PmgsLiZjMyGEYGSMWFCTxCoCHQuFA.Dequeue();
			int num = OJSyLPrYLVqCavWKcLWzeuCmvrSJ(FLWwRvYwRfQgXPKsMlrAeatNpvnl, hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.WmmZdoTHReDCVimeJnxEbJNlSKZsA);
			if (num >= 0)
			{
				FLWwRvYwRfQgXPKsMlrAeatNpvnl[num].GoqyiOkQOESEsdShhxOqnaIthhNA(hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.NBHwoUnHmLFHjAxZFQCUjClhcAXqA, hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.rIGNfyDYhoftTaJNOiudXYBRHtUB);
			}
			hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.Return();
		}
	}

	private void IPOBLYVWYGdwKMmdVrYohuGaUdUB(YiNGTscaFlfcYGbkCqpCNRhAgAbi P_0, gXscSvKVwaCJjrRAEGEwVgIGOxHD P_1)
	{
		if (!JiEDaleZvheoVhZyEvshjBbqmfORc)
		{
			return;
		}
		using (FPkFCGSTILeRbfRbIgQPQPJQtxJAA.Lock())
		{
			JIagzAPYQiXXGasXSfmZSInBOxxd jIagzAPYQiXXGasXSfmZSInBOxxd = CPvvrmyFQZZQOcjidnsIdPTSjCQp.Get();
			jIagzAPYQiXXGasXSfmZSInBOxxd.LYnyAWTJrjDSZhiUdBttzaiyFjSC = P_0;
			jIagzAPYQiXXGasXSfmZSInBOxxd.JVHhVEOcsUSjmBInrKdHQcUYRnpp = P_1;
			yoYdzkSNnyYsFQOchHKPqLbxMasN.Enqueue(jIagzAPYQiXXGasXSfmZSInBOxxd);
		}
	}

	public IList<dAMJUizrgPTBRKExuFwRvYIoTEmL> ZZFDglbUoouXUFQCBynRiPKNkogu()
	{
		return XLqvhPMgCfsMJRYClFUcvWzaCcqt;
	}

	private void vnrlVZyJbAsBvfWJnNtfmpxZHTob()
	{
		bool flag = false;
		List<YiNGTscaFlfcYGbkCqpCNRhAgAbi> list = yydXGwyAdaAzdehMLqpBHJYUNKNEb;
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			YiNGTscaFlfcYGbkCqpCNRhAgAbi.KRhIbyNmjrtJanFzXJCsPsRWZRgH(list);
			for (int num = EinBIYAMvRdOCJQEYjrzVEJXQGqe.Count - 1; num >= 0; num--)
			{
				if (!wLuVewqJPxVJdADhaZHkAmoDhaDH(list, EinBIYAMvRdOCJQEYjrzVEJXQGqe[num].uBBfOfGHXDlcwFoafsxafvUrlDjhb))
				{
					EinBIYAMvRdOCJQEYjrzVEJXQGqe[num].uBBfOfGHXDlcwFoafsxafvUrlDjhb.lnlMCCHLhFMJKoetugaLbIDmCUULA();
					EinBIYAMvRdOCJQEYjrzVEJXQGqe[num].Dispose();
					EinBIYAMvRdOCJQEYjrzVEJXQGqe.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				YiNGTscaFlfcYGbkCqpCNRhAgAbi yiNGTscaFlfcYGbkCqpCNRhAgAbi = list[num2];
				if (YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(yiNGTscaFlfcYGbkCqpCNRhAgAbi, null))
				{
					list.RemoveAt(num2);
				}
				else
				{
					int num3 = OJSyLPrYLVqCavWKcLWzeuCmvrSJ(EinBIYAMvRdOCJQEYjrzVEJXQGqe, yiNGTscaFlfcYGbkCqpCNRhAgAbi);
					if (num3 >= 0)
					{
						list[num2].lnlMCCHLhFMJKoetugaLbIDmCUULA();
						list[num2] = EinBIYAMvRdOCJQEYjrzVEJXQGqe[num3].uBBfOfGHXDlcwFoafsxafvUrlDjhb;
					}
					else
					{
						EinBIYAMvRdOCJQEYjrzVEJXQGqe.Add(new dAMJUizrgPTBRKExuFwRvYIoTEmL(yiNGTscaFlfcYGbkCqpCNRhAgAbi, TAAHeUfAwXqfxXiGdkvqWqyVWFBC(), MtUqZaFbtvLaVkjjAnTlfuljFStg));
						flag = true;
					}
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				YiNGTscaFlfcYGbkCqpCNRhAgAbi yiNGTscaFlfcYGbkCqpCNRhAgAbi2 = list[num4];
				int num5 = OJSyLPrYLVqCavWKcLWzeuCmvrSJ(EinBIYAMvRdOCJQEYjrzVEJXQGqe, yiNGTscaFlfcYGbkCqpCNRhAgAbi2);
				if (num5 >= 0)
				{
					dAMJUizrgPTBRKExuFwRvYIoTEmL item = EinBIYAMvRdOCJQEYjrzVEJXQGqe[num5];
					EinBIYAMvRdOCJQEYjrzVEJXQGqe.RemoveAt(num5);
					EinBIYAMvRdOCJQEYjrzVEJXQGqe.Insert(0, item);
				}
			}
			FLWwRvYwRfQgXPKsMlrAeatNpvnl.Clear();
			for (int i = 0; i < EinBIYAMvRdOCJQEYjrzVEJXQGqe.Count; i++)
			{
				FLWwRvYwRfQgXPKsMlrAeatNpvnl.Add(EinBIYAMvRdOCJQEYjrzVEJXQGqe[i]);
			}
		}
		list.Clear();
		if (flag)
		{
			this.qCMhKpLyztkyPvAMKCOGJepqtsTz?.Invoke();
		}
	}

	private void WpzgUmbGPeeUerarEicyDBnNNgKrA(bool P_0)
	{
		JiEDaleZvheoVhZyEvshjBbqmfORc = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!JiEDaleZvheoVhZyEvshjBbqmfORc)
		{
			using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
			{
				PmgsLiZjMyGEYGSMWFCTxCoCHQuFA.Clear();
			}
		}
	}

	private void AITndnDsmyVYovRtnluITTVGZJzB(bool P_0)
	{
		JiEDaleZvheoVhZyEvshjBbqmfORc = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!JiEDaleZvheoVhZyEvshjBbqmfORc)
		{
			using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
			{
				PmgsLiZjMyGEYGSMWFCTxCoCHQuFA.Clear();
			}
		}
	}

	private void QfkbmRDdNMUBIPciRGbzxNNZebBeb()
	{
		if (XyhgmolKGtcgszdIKegYstbJnHqN || !JiEDaleZvheoVhZyEvshjBbqmfORc)
		{
			return;
		}
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			int count = EinBIYAMvRdOCJQEYjrzVEJXQGqe.Count;
			for (int i = 0; i < count; i++)
			{
				hpNvDUpSUZVHBWkqxgiDmOtLvKmH hpNvDUpSUZVHBWkqxgiDmOtLvKmH2 = CMLslewOBYLVglOsIOHMNhcqZpPu.Get();
				hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.WmmZdoTHReDCVimeJnxEbJNlSKZsA = EinBIYAMvRdOCJQEYjrzVEJXQGqe[i].uBBfOfGHXDlcwFoafsxafvUrlDjhb;
				hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.NBHwoUnHmLFHjAxZFQCUjClhcAXqA = hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.WmmZdoTHReDCVimeJnxEbJNlSKZsA.PrliiksTuelAUZhSWtccMDgMDbEE();
				hpNvDUpSUZVHBWkqxgiDmOtLvKmH2.rIGNfyDYhoftTaJNOiudXYBRHtUB = ReInput.realTime;
				wmjkLjXveCxiSWqPKrAuXwoLEsaQ.Enqueue(hpNvDUpSUZVHBWkqxgiDmOtLvKmH2);
			}
		}
	}

	private void JpgfRqKRGdmkvFgaPrKZlWAAtlso()
	{
		if (XyhgmolKGtcgszdIKegYstbJnHqN)
		{
			return;
		}
		using (FPkFCGSTILeRbfRbIgQPQPJQtxJAA.Lock())
		{
			MiscTools.Swap(ref yoYdzkSNnyYsFQOchHKPqLbxMasN, ref BsUvHZXejpcGhqUQyYdHRXSTsBvf);
		}
		while (BsUvHZXejpcGhqUQyYdHRXSTsBvf.Count > 0)
		{
			JIagzAPYQiXXGasXSfmZSInBOxxd jIagzAPYQiXXGasXSfmZSInBOxxd = BsUvHZXejpcGhqUQyYdHRXSTsBvf.Dequeue();
			try
			{
				jIagzAPYQiXXGasXSfmZSInBOxxd.LYnyAWTJrjDSZhiUdBttzaiyFjSC.uplXNVHzCkpKrKWfnnwiNbaRMhxC = jIagzAPYQiXXGasXSfmZSInBOxxd.JVHhVEOcsUSjmBInrKdHQcUYRnpp;
			}
			catch
			{
			}
			jIagzAPYQiXXGasXSfmZSInBOxxd.Return();
		}
	}

	private void rbDRdKDtPxYEsEwdjInfSrPOwoz(YiNGTscaFlfcYGbkCqpCNRhAgAbi P_0)
	{
		P_0.lnlMCCHLhFMJKoetugaLbIDmCUULA();
		if (XyhgmolKGtcgszdIKegYstbJnHqN)
		{
			return;
		}
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			DybbFxlquDlVdkusamHNcdMMKJOB = true;
		}
	}

	private void lSalhpIUMVGEtGxsRoZqTqrWSVmn(YiNGTscaFlfcYGbkCqpCNRhAgAbi P_0)
	{
		P_0.lnlMCCHLhFMJKoetugaLbIDmCUULA();
		if (XyhgmolKGtcgszdIKegYstbJnHqN)
		{
			return;
		}
		using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
		{
			DybbFxlquDlVdkusamHNcdMMKJOB = true;
		}
	}

	public void Dispose()
	{
		vEHsFEpDKPACMAHJxlspoLcZYKUc(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void BzPoFFkarcOaoKkHTdaHJFJFDbEr()
	{
		try
		{
			vEHsFEpDKPACMAHJxlspoLcZYKUc(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vEHsFEpDKPACMAHJxlspoLcZYKUc(bool P_0)
	{
		if (XyhgmolKGtcgszdIKegYstbJnHqN)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= WpzgUmbGPeeUerarEicyDBnNNgKrA;
			ReInput.ApplicationPauseChangedEvent -= AITndnDsmyVYovRtnluITTVGZJzB;
			YiNGTscaFlfcYGbkCqpCNRhAgAbi.cYkLOXtrZxmLORxyITFLAUxGbtwp -= rbDRdKDtPxYEsEwdjInfSrPOwoz;
			YiNGTscaFlfcYGbkCqpCNRhAgAbi.QbwPtMGvBumDYhDjqHUHHKfxFGotA -= lSalhpIUMVGEtGxsRoZqTqrWSVmn;
			WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent -= QfkbmRDdNMUBIPciRGbzxNNZebBeb;
			WNDYrcPDOUObmqnBCmqijYTVsDhn.nytSzNVIhUWoXZDzKGaUmjqGlQXF.ThreadUpdateEvent -= JpgfRqKRGdmkvFgaPrKZlWAAtlso;
			using (yNpYRzRRLrCDnYxLhwnbtaPomANy.Lock())
			{
				for (int i = 0; i < EinBIYAMvRdOCJQEYjrzVEJXQGqe.Count; i++)
				{
					try
					{
						EinBIYAMvRdOCJQEYjrzVEJXQGqe[i].Dispose();
						EinBIYAMvRdOCJQEYjrzVEJXQGqe[i].uBBfOfGHXDlcwFoafsxafvUrlDjhb.lnlMCCHLhFMJKoetugaLbIDmCUULA();
					}
					catch
					{
					}
				}
				EinBIYAMvRdOCJQEYjrzVEJXQGqe.Clear();
				FLWwRvYwRfQgXPKsMlrAeatNpvnl.Clear();
			}
			try
			{
				YiNGTscaFlfcYGbkCqpCNRhAgAbi.nkyrheqioVNHRgLHUTuJsCqMBYpX();
			}
			catch
			{
			}
		}
		XyhgmolKGtcgszdIKegYstbJnHqN = true;
	}

	private static bool zpeseAKkpJTQuWJotyBdtsGYwMFb(IList<dAMJUizrgPTBRKExuFwRvYIoTEmL> P_0, YiNGTscaFlfcYGbkCqpCNRhAgAbi P_1)
	{
		return OJSyLPrYLVqCavWKcLWzeuCmvrSJ(P_0, P_1) >= 0;
	}

	private static bool wLuVewqJPxVJdADhaZHkAmoDhaDH(IList<YiNGTscaFlfcYGbkCqpCNRhAgAbi> P_0, YiNGTscaFlfcYGbkCqpCNRhAgAbi P_1)
	{
		return EEXWaTTCIYwpSaJNbmIlzLoVfcHaA(P_0, P_1) >= 0;
	}

	private static int OJSyLPrYLVqCavWKcLWzeuCmvrSJ(IList<dAMJUizrgPTBRKExuFwRvYIoTEmL> P_0, YiNGTscaFlfcYGbkCqpCNRhAgAbi P_1)
	{
		if (P_0 == null || YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(P_0[i].uBBfOfGHXDlcwFoafsxafvUrlDjhb, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int EEXWaTTCIYwpSaJNbmIlzLoVfcHaA(IList<YiNGTscaFlfcYGbkCqpCNRhAgAbi> P_0, YiNGTscaFlfcYGbkCqpCNRhAgAbi P_1)
	{
		if (P_0 == null || YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(P_0[i], null) && YiNGTscaFlfcYGbkCqpCNRhAgAbi.SPgudXzfnrxGCqCEMqMClyReXHId(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static ZCgSuEkHKfsXrytTXKLOHjMMmbeJ()
	{
		dfXKcEvhCkwHiYQXCYNAgrFHbdfi = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		SBYnakeGkPozSmBESNZlvwNeBspm = new string[1] { "Xbox Bluetooth Gamepad" };
		UTZWAspHDZSPqmuFYuUNzQfLEWSH = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool yHUDGxTHdpCQEDlfSFfQxRYOmjQl(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < SBYnakeGkPozSmBESNZlvwNeBspm.Length; i++)
			{
				if (P_1.Equals(SBYnakeGkPozSmBESNZlvwNeBspm[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < UTZWAspHDZSPqmuFYuUNzQfLEWSH.Length; j++)
			{
				if (Regex.IsMatch(P_1, UTZWAspHDZSPqmuFYuUNzQfLEWSH[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		string[] array = P_0.Split('#');
		if (array.Length < 2)
		{
			return false;
		}
		for (int k = 0; k < array.Length; k++)
		{
			string text = array[k].ToLower();
			if (text.Contains("pid_"))
			{
				int num = text.IndexOf("vid_");
				if (num >= 0 && text.IndexOf("ig_") >= num)
				{
					return true;
				}
			}
		}
		return false;
	}
}
