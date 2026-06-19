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

internal class mMRnaCZByBQHZrOOfOAEzqjppACA : IDisposable
{
	private abstract class zjAgEmXOBNuzreAOofdErehbGfvt : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool tMPHJdpgjJmZhYYvGMNDYcXauiZV;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return tMPHJdpgjJmZhYYvGMNDYcXauiZV;
			}
			[CompilerGenerated]
			set
			{
				tMPHJdpgjJmZhYYvGMNDYcXauiZV = value;
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

	private class IffcEyOQBQwnztjzmbsPYRPgpeCs : zjAgEmXOBNuzreAOofdErehbGfvt
	{
		public jPxdIFDnOkTonljyRaQphHTzlDNB hUQwKQelSdaexIDzYBxSJrhQdVdFb;

		public UEhDjvAzZPVreaJMknILCleqWCHcA atbfPghAjGInZZGCEoGQikHKzLtz;

		public double UOemmTwCHuHFVNPWSmLetasaUXRd;

		protected virtual void YLKbuXbXEyxWQWKtwRAMsTlbUGUQ()
		{
			hUQwKQelSdaexIDzYBxSJrhQdVdFb = null;
			atbfPghAjGInZZGCEoGQikHKzLtz = default(UEhDjvAzZPVreaJMknILCleqWCHcA);
			UOemmTwCHuHFVNPWSmLetasaUXRd = 0.0;
		}
	}

	private sealed class ucUTWkkJVjApaTNWBhxLgCkmpBXr : zjAgEmXOBNuzreAOofdErehbGfvt
	{
		public jPxdIFDnOkTonljyRaQphHTzlDNB aGHDeyeEQsjujMzSyBCxJQJXAfoF;

		public PnWZbRpKCvwNHCKoFStsrOitTtdC mjpSwetvsXyAkiigoxDhsufdiNTc;

		protected void CPteUHCxUzijRToRttfBEafjgPSAb()
		{
			aGHDeyeEQsjujMzSyBCxJQJXAfoF = null;
			mjpSwetvsXyAkiigoxDhsufdiNTc = default(PnWZbRpKCvwNHCKoFStsrOitTtdC);
		}
	}

	[Serializable]
	private sealed class vjeBarqxSJurSiSCKReCYOdgWUYC
	{
		public static readonly vjeBarqxSJurSiSCKReCYOdgWUYC _003C_003E9 = new vjeBarqxSJurSiSCKReCYOdgWUYC();

		public static Func<IffcEyOQBQwnztjzmbsPYRPgpeCs> _003C_003E9__19_0;

		public static Func<ucUTWkkJVjApaTNWBhxLgCkmpBXr> _003C_003E9__19_1;

		internal IffcEyOQBQwnztjzmbsPYRPgpeCs GTDknrzqkWTeDuSLyvQrJJfLgUZgA()
		{
			return new IffcEyOQBQwnztjzmbsPYRPgpeCs();
		}

		internal ucUTWkkJVjApaTNWBhxLgCkmpBXr BrDhanjGsPLFCefsIXIFywIXmbTib()
		{
			return new ucUTWkkJVjApaTNWBhxLgCkmpBXr();
		}
	}

	private readonly List<IUicmISErEcjrpTynhPRVCoDnMAQ> sCihmDJvMmAMlOajXBhMBONdseNpB;

	private readonly ReadOnlyCollection<IUicmISErEcjrpTynhPRVCoDnMAQ> uBEIGjBpDwNgtmiNiQCyRVVRCjMaA;

	private readonly List<jPxdIFDnOkTonljyRaQphHTzlDNB> PqXdxUEJehtJVKWXKNfHgvqhlBbTA;

	private readonly Func<int> orwwsqIXCQMnNohxgejuoYTePOfD;

	private readonly Rewired.Utils.Classes.Utility.SpinLock PGLcgLAmKmLhJIjOwRxtzDvNCJngb = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock cEQWdudVFAEdXwHwPvSZxOzjvstq = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<IffcEyOQBQwnztjzmbsPYRPgpeCs> aiOPUQatLruDormZLGHZVnWzRtKg;

	private RingBuffer<ucUTWkkJVjApaTNWBhxLgCkmpBXr> TziXYOnpabIUbtyhmCMFMQLGEzEdA;

	private bool uMkXFZmzgaOxfqidwEujxtDDjuqr;

	private readonly ThreadSafeObjectPool<IffcEyOQBQwnztjzmbsPYRPgpeCs> hfpGIWZaOLjdQjObRoNARfCVCwdtA;

	private readonly ThreadSafeObjectPool<ucUTWkkJVjApaTNWBhxLgCkmpBXr> pyRGQYgNNGqqqiJjeucINZrfYPyp;

	private readonly List<IUicmISErEcjrpTynhPRVCoDnMAQ> xdJkaitJBKRckojFHCjnxmogEBOCA;

	private RingBuffer<IffcEyOQBQwnztjzmbsPYRPgpeCs> NfFNmRmHfRLYanKATEOozDAapzKo;

	private RingBuffer<ucUTWkkJVjApaTNWBhxLgCkmpBXr> kngIbXcpUgYNMVTnhUHdrpakrhFd;

	private bool ytXWjtWvhOPEdJxNtacDWGXfHAxj;

	private Action<jPxdIFDnOkTonljyRaQphHTzlDNB, PnWZbRpKCvwNHCKoFStsrOitTtdC> zBedHMkTckurjFQuFsdfLIVOEQLiA;

	[CompilerGenerated]
	private Action m_JpkqnXiIouVWpWmZZNWYMQVTIhtp;

	private bool ehPNMIKTZcGGfYFdDwCQITTwEmME;

	private static Guid[] CZxjkiILzlQABlCORKSkMhwsaRbB;

	private static string[] djwEgKFvOYMSeJHXBBtvTdDRQnRD;

	private static string[] xnnrKSUKEgLULKIFwYLJFRcRIcF;

	public event Action JpkqnXiIouVWpWmZZNWYMQVTIhtp
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_JpkqnXiIouVWpWmZZNWYMQVTIhtp;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_JpkqnXiIouVWpWmZZNWYMQVTIhtp, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_JpkqnXiIouVWpWmZZNWYMQVTIhtp;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_JpkqnXiIouVWpWmZZNWYMQVTIhtp, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public mMRnaCZByBQHZrOOfOAEzqjppACA(Func<int> P_0)
	{
		orwwsqIXCQMnNohxgejuoYTePOfD = P_0;
		zBedHMkTckurjFQuFsdfLIVOEQLiA = dBoiDaeVbXHQQvryQxASFWQZLNHD;
		sCihmDJvMmAMlOajXBhMBONdseNpB = new List<IUicmISErEcjrpTynhPRVCoDnMAQ>();
		xdJkaitJBKRckojFHCjnxmogEBOCA = new List<IUicmISErEcjrpTynhPRVCoDnMAQ>();
		uBEIGjBpDwNgtmiNiQCyRVVRCjMaA = new ReadOnlyCollection<IUicmISErEcjrpTynhPRVCoDnMAQ>(sCihmDJvMmAMlOajXBhMBONdseNpB);
		PqXdxUEJehtJVKWXKNfHgvqhlBbTA = new List<jPxdIFDnOkTonljyRaQphHTzlDNB>();
		uMkXFZmzgaOxfqidwEujxtDDjuqr = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)rGfCWQcoVBNNMLBCPGciUTleuQNNA.jBtHaTgeNpmGYIOhRQexVaFAnUZE * 32f) + 1;
		hfpGIWZaOLjdQjObRoNARfCVCwdtA = new ThreadSafeObjectPool<IffcEyOQBQwnztjzmbsPYRPgpeCs>(num, vjeBarqxSJurSiSCKReCYOdgWUYC._003C_003E9.GTDknrzqkWTeDuSLyvQrJJfLgUZgA);
		pyRGQYgNNGqqqiJjeucINZrfYPyp = new ThreadSafeObjectPool<ucUTWkkJVjApaTNWBhxLgCkmpBXr>(128, vjeBarqxSJurSiSCKReCYOdgWUYC._003C_003E9.BrDhanjGsPLFCefsIXIFywIXmbTib);
		aiOPUQatLruDormZLGHZVnWzRtKg = new RingBuffer<IffcEyOQBQwnztjzmbsPYRPgpeCs>(num);
		TziXYOnpabIUbtyhmCMFMQLGEzEdA = new RingBuffer<ucUTWkkJVjApaTNWBhxLgCkmpBXr>(128);
		NfFNmRmHfRLYanKATEOozDAapzKo = new RingBuffer<IffcEyOQBQwnztjzmbsPYRPgpeCs>(num);
		kngIbXcpUgYNMVTnhUHdrpakrhFd = new RingBuffer<ucUTWkkJVjApaTNWBhxLgCkmpBXr>(128);
		jPxdIFDnOkTonljyRaQphHTzlDNB.HtQKnrYBQcftmkctTKTFcaVbQwGz += KgLylFiIoIspktlneWqjeyNefGUH;
		jPxdIFDnOkTonljyRaQphHTzlDNB.twKfQijGOzhlqIWuvgWVqcTOXDIIA += IEGkEPjIHIPgTlmhGdNijrTziEMbA;
		rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent += xjKCLtgIMFSbyBtvGEhtEzhurchMA;
		rGfCWQcoVBNNMLBCPGciUTleuQNNA.IQHdtlmEcHWkbcxkRQYEKZGhVkzr.ThreadUpdateEvent += qISPoShCFyISFicnSPARkXkfmyYOA;
		ReInput.ApplicationFocusChangedEvent += hFNVpIlyMtAaSHhaHiiwanFwnjuKA;
		ReInput.ApplicationPauseChangedEvent += fwrUkRcHxldyoUdOytqgzopvKztI;
		jPxdIFDnOkTonljyRaQphHTzlDNB.ulBsTBfntoGcKAvyYBNcxucYDqhxA();
		GkRCVzTWRLYqvGVegNVvAJlcIHlg();
	}

	public void hxsbCTVTVmnLJPiomImCFyiMbphY()
	{
		bool flag = false;
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			if (ytXWjtWvhOPEdJxNtacDWGXfHAxj)
			{
				ytXWjtWvhOPEdJxNtacDWGXfHAxj = false;
				flag = true;
			}
		}
		if (flag)
		{
			GkRCVzTWRLYqvGVegNVvAJlcIHlg();
		}
	}

	public void vjvabnzAeTzquyxILLrQrCZkHpQ()
	{
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			MiscTools.Swap(ref aiOPUQatLruDormZLGHZVnWzRtKg, ref NfFNmRmHfRLYanKATEOozDAapzKo);
		}
		while (aiOPUQatLruDormZLGHZVnWzRtKg.Count > 0)
		{
			IffcEyOQBQwnztjzmbsPYRPgpeCs iffcEyOQBQwnztjzmbsPYRPgpeCs = aiOPUQatLruDormZLGHZVnWzRtKg.Dequeue();
			int num = fRkBkneEUWLiAxEBrOWdwAgTfwamA(sCihmDJvMmAMlOajXBhMBONdseNpB, iffcEyOQBQwnztjzmbsPYRPgpeCs.hUQwKQelSdaexIDzYBxSJrhQdVdFb);
			if (num >= 0)
			{
				sCihmDJvMmAMlOajXBhMBONdseNpB[num].fyELHMXiRZejmUTvmheMTiOxqOXF(iffcEyOQBQwnztjzmbsPYRPgpeCs.atbfPghAjGInZZGCEoGQikHKzLtz, iffcEyOQBQwnztjzmbsPYRPgpeCs.UOemmTwCHuHFVNPWSmLetasaUXRd);
			}
			iffcEyOQBQwnztjzmbsPYRPgpeCs.Return();
		}
	}

	private void dBoiDaeVbXHQQvryQxASFWQZLNHD(jPxdIFDnOkTonljyRaQphHTzlDNB P_0, PnWZbRpKCvwNHCKoFStsrOitTtdC P_1)
	{
		if (!uMkXFZmzgaOxfqidwEujxtDDjuqr)
		{
			return;
		}
		using (cEQWdudVFAEdXwHwPvSZxOzjvstq.Lock())
		{
			ucUTWkkJVjApaTNWBhxLgCkmpBXr ucUTWkkJVjApaTNWBhxLgCkmpBXr2 = pyRGQYgNNGqqqiJjeucINZrfYPyp.Get();
			ucUTWkkJVjApaTNWBhxLgCkmpBXr2.aGHDeyeEQsjujMzSyBCxJQJXAfoF = P_0;
			ucUTWkkJVjApaTNWBhxLgCkmpBXr2.mjpSwetvsXyAkiigoxDhsufdiNTc = P_1;
			TziXYOnpabIUbtyhmCMFMQLGEzEdA.Enqueue(ucUTWkkJVjApaTNWBhxLgCkmpBXr2);
		}
	}

	public IList<IUicmISErEcjrpTynhPRVCoDnMAQ> uhpSHNjkldxjeyXPOjdTQFkwLbCx()
	{
		return uBEIGjBpDwNgtmiNiQCyRVVRCjMaA;
	}

	private void GkRCVzTWRLYqvGVegNVvAJlcIHlg()
	{
		bool flag = false;
		List<jPxdIFDnOkTonljyRaQphHTzlDNB> pqXdxUEJehtJVKWXKNfHgvqhlBbTA = PqXdxUEJehtJVKWXKNfHgvqhlBbTA;
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			jPxdIFDnOkTonljyRaQphHTzlDNB.vCZblSgHgmJZCGfkYrFottbvNUMs(pqXdxUEJehtJVKWXKNfHgvqhlBbTA);
			for (int num = xdJkaitJBKRckojFHCjnxmogEBOCA.Count - 1; num >= 0; num--)
			{
				if (!PjMciSXwWqibDlpyhsLwenSerafx(pqXdxUEJehtJVKWXKNfHgvqhlBbTA, xdJkaitJBKRckojFHCjnxmogEBOCA[num].PFjTpLsFCCfACBZhuAncIRyMiMBrA))
				{
					xdJkaitJBKRckojFHCjnxmogEBOCA[num].PFjTpLsFCCfACBZhuAncIRyMiMBrA.YqPgfquagCvtuXgqdzmPqbfJNTyO();
					xdJkaitJBKRckojFHCjnxmogEBOCA[num].Dispose();
					xdJkaitJBKRckojFHCjnxmogEBOCA.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = pqXdxUEJehtJVKWXKNfHgvqhlBbTA.Count - 1; num2 >= 0; num2--)
			{
				jPxdIFDnOkTonljyRaQphHTzlDNB jPxdIFDnOkTonljyRaQphHTzlDNB2 = pqXdxUEJehtJVKWXKNfHgvqhlBbTA[num2];
				if (jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(jPxdIFDnOkTonljyRaQphHTzlDNB2, null))
				{
					pqXdxUEJehtJVKWXKNfHgvqhlBbTA.RemoveAt(num2);
				}
				else
				{
					int num3 = fRkBkneEUWLiAxEBrOWdwAgTfwamA(xdJkaitJBKRckojFHCjnxmogEBOCA, jPxdIFDnOkTonljyRaQphHTzlDNB2);
					if (num3 >= 0)
					{
						pqXdxUEJehtJVKWXKNfHgvqhlBbTA[num2].YqPgfquagCvtuXgqdzmPqbfJNTyO();
						pqXdxUEJehtJVKWXKNfHgvqhlBbTA[num2] = xdJkaitJBKRckojFHCjnxmogEBOCA[num3].PFjTpLsFCCfACBZhuAncIRyMiMBrA;
					}
					else
					{
						xdJkaitJBKRckojFHCjnxmogEBOCA.Add(new IUicmISErEcjrpTynhPRVCoDnMAQ(jPxdIFDnOkTonljyRaQphHTzlDNB2, orwwsqIXCQMnNohxgejuoYTePOfD(), zBedHMkTckurjFQuFsdfLIVOEQLiA));
						flag = true;
					}
				}
			}
			for (int num4 = pqXdxUEJehtJVKWXKNfHgvqhlBbTA.Count - 1; num4 >= 0; num4--)
			{
				jPxdIFDnOkTonljyRaQphHTzlDNB jPxdIFDnOkTonljyRaQphHTzlDNB3 = pqXdxUEJehtJVKWXKNfHgvqhlBbTA[num4];
				int num5 = fRkBkneEUWLiAxEBrOWdwAgTfwamA(xdJkaitJBKRckojFHCjnxmogEBOCA, jPxdIFDnOkTonljyRaQphHTzlDNB3);
				if (num5 >= 0)
				{
					IUicmISErEcjrpTynhPRVCoDnMAQ item = xdJkaitJBKRckojFHCjnxmogEBOCA[num5];
					xdJkaitJBKRckojFHCjnxmogEBOCA.RemoveAt(num5);
					xdJkaitJBKRckojFHCjnxmogEBOCA.Insert(0, item);
				}
			}
			sCihmDJvMmAMlOajXBhMBONdseNpB.Clear();
			for (int i = 0; i < xdJkaitJBKRckojFHCjnxmogEBOCA.Count; i++)
			{
				sCihmDJvMmAMlOajXBhMBONdseNpB.Add(xdJkaitJBKRckojFHCjnxmogEBOCA[i]);
			}
		}
		pqXdxUEJehtJVKWXKNfHgvqhlBbTA.Clear();
		if (flag)
		{
			this.JpkqnXiIouVWpWmZZNWYMQVTIhtp?.Invoke();
		}
	}

	private void hFNVpIlyMtAaSHhaHiiwanFwnjuKA(bool P_0)
	{
		uMkXFZmzgaOxfqidwEujxtDDjuqr = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!uMkXFZmzgaOxfqidwEujxtDDjuqr)
		{
			using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
			{
				aiOPUQatLruDormZLGHZVnWzRtKg.Clear();
			}
		}
	}

	private void fwrUkRcHxldyoUdOytqgzopvKztI(bool P_0)
	{
		uMkXFZmzgaOxfqidwEujxtDDjuqr = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!uMkXFZmzgaOxfqidwEujxtDDjuqr)
		{
			using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
			{
				aiOPUQatLruDormZLGHZVnWzRtKg.Clear();
			}
		}
	}

	private void xjKCLtgIMFSbyBtvGEhtEzhurchMA()
	{
		if (ehPNMIKTZcGGfYFdDwCQITTwEmME || !uMkXFZmzgaOxfqidwEujxtDDjuqr)
		{
			return;
		}
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			int count = xdJkaitJBKRckojFHCjnxmogEBOCA.Count;
			for (int i = 0; i < count; i++)
			{
				IffcEyOQBQwnztjzmbsPYRPgpeCs iffcEyOQBQwnztjzmbsPYRPgpeCs = hfpGIWZaOLjdQjObRoNARfCVCwdtA.Get();
				iffcEyOQBQwnztjzmbsPYRPgpeCs.hUQwKQelSdaexIDzYBxSJrhQdVdFb = xdJkaitJBKRckojFHCjnxmogEBOCA[i].PFjTpLsFCCfACBZhuAncIRyMiMBrA;
				iffcEyOQBQwnztjzmbsPYRPgpeCs.atbfPghAjGInZZGCEoGQikHKzLtz = iffcEyOQBQwnztjzmbsPYRPgpeCs.hUQwKQelSdaexIDzYBxSJrhQdVdFb.cGNLlKTEJfXyweigPzFkofrfGhcj();
				iffcEyOQBQwnztjzmbsPYRPgpeCs.UOemmTwCHuHFVNPWSmLetasaUXRd = ReInput.realTime;
				NfFNmRmHfRLYanKATEOozDAapzKo.Enqueue(iffcEyOQBQwnztjzmbsPYRPgpeCs);
			}
		}
	}

	private void qISPoShCFyISFicnSPARkXkfmyYOA()
	{
		if (ehPNMIKTZcGGfYFdDwCQITTwEmME)
		{
			return;
		}
		using (cEQWdudVFAEdXwHwPvSZxOzjvstq.Lock())
		{
			MiscTools.Swap(ref TziXYOnpabIUbtyhmCMFMQLGEzEdA, ref kngIbXcpUgYNMVTnhUHdrpakrhFd);
		}
		while (kngIbXcpUgYNMVTnhUHdrpakrhFd.Count > 0)
		{
			ucUTWkkJVjApaTNWBhxLgCkmpBXr ucUTWkkJVjApaTNWBhxLgCkmpBXr2 = kngIbXcpUgYNMVTnhUHdrpakrhFd.Dequeue();
			try
			{
				ucUTWkkJVjApaTNWBhxLgCkmpBXr2.aGHDeyeEQsjujMzSyBCxJQJXAfoF.XiHevxeqEzXdyfHRcjuabBNsDGZk = ucUTWkkJVjApaTNWBhxLgCkmpBXr2.mjpSwetvsXyAkiigoxDhsufdiNTc;
			}
			catch
			{
			}
			ucUTWkkJVjApaTNWBhxLgCkmpBXr2.Return();
		}
	}

	private void KgLylFiIoIspktlneWqjeyNefGUH(jPxdIFDnOkTonljyRaQphHTzlDNB P_0)
	{
		P_0.YqPgfquagCvtuXgqdzmPqbfJNTyO();
		if (ehPNMIKTZcGGfYFdDwCQITTwEmME)
		{
			return;
		}
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			ytXWjtWvhOPEdJxNtacDWGXfHAxj = true;
		}
	}

	private void IEGkEPjIHIPgTlmhGdNijrTziEMbA(jPxdIFDnOkTonljyRaQphHTzlDNB P_0)
	{
		P_0.YqPgfquagCvtuXgqdzmPqbfJNTyO();
		if (ehPNMIKTZcGGfYFdDwCQITTwEmME)
		{
			return;
		}
		using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
		{
			ytXWjtWvhOPEdJxNtacDWGXfHAxj = true;
		}
	}

	public void Dispose()
	{
		GMzJuyCWPIeKajAjudWmSfqeDHah(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void qhoFpNNpneyOatOeEfTUjjLawaic()
	{
		try
		{
			GMzJuyCWPIeKajAjudWmSfqeDHah(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void GMzJuyCWPIeKajAjudWmSfqeDHah(bool P_0)
	{
		if (ehPNMIKTZcGGfYFdDwCQITTwEmME)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= hFNVpIlyMtAaSHhaHiiwanFwnjuKA;
			ReInput.ApplicationPauseChangedEvent -= fwrUkRcHxldyoUdOytqgzopvKztI;
			jPxdIFDnOkTonljyRaQphHTzlDNB.HtQKnrYBQcftmkctTKTFcaVbQwGz -= KgLylFiIoIspktlneWqjeyNefGUH;
			jPxdIFDnOkTonljyRaQphHTzlDNB.twKfQijGOzhlqIWuvgWVqcTOXDIIA -= IEGkEPjIHIPgTlmhGdNijrTziEMbA;
			rGfCWQcoVBNNMLBCPGciUTleuQNNA.ReTQukjOlRfIJKzAIFnxdbenkGseb.ThreadUpdateEvent -= xjKCLtgIMFSbyBtvGEhtEzhurchMA;
			rGfCWQcoVBNNMLBCPGciUTleuQNNA.IQHdtlmEcHWkbcxkRQYEKZGhVkzr.ThreadUpdateEvent -= qISPoShCFyISFicnSPARkXkfmyYOA;
			using (PGLcgLAmKmLhJIjOwRxtzDvNCJngb.Lock())
			{
				for (int i = 0; i < xdJkaitJBKRckojFHCjnxmogEBOCA.Count; i++)
				{
					try
					{
						xdJkaitJBKRckojFHCjnxmogEBOCA[i].Dispose();
						xdJkaitJBKRckojFHCjnxmogEBOCA[i].PFjTpLsFCCfACBZhuAncIRyMiMBrA.YqPgfquagCvtuXgqdzmPqbfJNTyO();
					}
					catch
					{
					}
				}
				xdJkaitJBKRckojFHCjnxmogEBOCA.Clear();
				sCihmDJvMmAMlOajXBhMBONdseNpB.Clear();
			}
			try
			{
				jPxdIFDnOkTonljyRaQphHTzlDNB.CoIDICVxfOhxfHRMHCcFIxAtsBRt();
			}
			catch
			{
			}
		}
		ehPNMIKTZcGGfYFdDwCQITTwEmME = true;
	}

	private static bool SiEVvAtvOMlHclgCrkgPVgSdFjmT(IList<IUicmISErEcjrpTynhPRVCoDnMAQ> P_0, jPxdIFDnOkTonljyRaQphHTzlDNB P_1)
	{
		return fRkBkneEUWLiAxEBrOWdwAgTfwamA(P_0, P_1) >= 0;
	}

	private static bool PjMciSXwWqibDlpyhsLwenSerafx(IList<jPxdIFDnOkTonljyRaQphHTzlDNB> P_0, jPxdIFDnOkTonljyRaQphHTzlDNB P_1)
	{
		return dPpfBhayDTVPqhHEyCIhCZGbklvMB(P_0, P_1) >= 0;
	}

	private static int fRkBkneEUWLiAxEBrOWdwAgTfwamA(IList<IUicmISErEcjrpTynhPRVCoDnMAQ> P_0, jPxdIFDnOkTonljyRaQphHTzlDNB P_1)
	{
		if (P_0 == null || jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_0[i].PFjTpLsFCCfACBZhuAncIRyMiMBrA, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int dPpfBhayDTVPqhHEyCIhCZGbklvMB(IList<jPxdIFDnOkTonljyRaQphHTzlDNB> P_0, jPxdIFDnOkTonljyRaQphHTzlDNB P_1)
	{
		if (P_0 == null || jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_0[i], null) && jPxdIFDnOkTonljyRaQphHTzlDNB.tvIHWdMiscXDqBHRJsYWZGOFUrad(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static mMRnaCZByBQHZrOOfOAEzqjppACA()
	{
		CZxjkiILzlQABlCORKSkMhwsaRbB = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		djwEgKFvOYMSeJHXBBtvTdDRQnRD = new string[1] { "Xbox Bluetooth Gamepad" };
		xnnrKSUKEgLULKIFwYLJFRcRIcF = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool HWgOpRkLgagaosrsLsvUFwsfHzar(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < djwEgKFvOYMSeJHXBBtvTdDRQnRD.Length; i++)
			{
				if (P_1.Equals(djwEgKFvOYMSeJHXBBtvTdDRQnRD[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < xnnrKSUKEgLULKIFwYLJFRcRIcF.Length; j++)
			{
				if (Regex.IsMatch(P_1, xnnrKSUKEgLULKIFwYLJFRcRIcF[j], RegexOptions.IgnoreCase))
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
