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

internal class NebFbjcyIYuVGyepRxTmZTEcCkKG : IDisposable
{
	private abstract class vYMmHawofZEhCAhtPJKFxtiyqdnfA : IDisposable, IPoolableObject, IPoolableObject_Internal
	{
		[CompilerGenerated]
		private IObjectPool CnmdJRaEfhweGpWtvrkSDTYzHRvx;

		IObjectPool IPoolableObject_Internal.pool
		{
			[CompilerGenerated]
			get
			{
				return CnmdJRaEfhweGpWtvrkSDTYzHRvx;
			}
			[CompilerGenerated]
			set
			{
				CnmdJRaEfhweGpWtvrkSDTYzHRvx = value;
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
	}

	private class tOGkTtrMfwXIaOOPnXpdkfMfBvGD : vYMmHawofZEhCAhtPJKFxtiyqdnfA
	{
		public KjCHeFcNkYjJzESIKPSiBBloOtLf BCEJAizXSvucuShEhCivWcsNuuyl;

		public dpAQVaQJEhyBbqThhjtzRWIlvUBi dquVbpLOjjHPmaiZcuBhEZTKpYnNA;

		public double YxFdZozJytryXOxcRaQAmySLFHVc;

		protected virtual void DwNKXiEShimVDUzntAObjUXyaFmo()
		{
			BCEJAizXSvucuShEhCivWcsNuuyl = null;
			dquVbpLOjjHPmaiZcuBhEZTKpYnNA = default(dpAQVaQJEhyBbqThhjtzRWIlvUBi);
			YxFdZozJytryXOxcRaQAmySLFHVc = 0.0;
		}
	}

	private sealed class aIYAaOjwFkvPzunWYkcMbYCaLdlIB : vYMmHawofZEhCAhtPJKFxtiyqdnfA
	{
		public KjCHeFcNkYjJzESIKPSiBBloOtLf BCEJAizXSvucuShEhCivWcsNuuyl;

		public qYblfIKWTJCcUzwzMzhWLaymennH vLlHrmnGGJSZXlWTFWaAmxkRefQH;

		protected void DwNKXiEShimVDUzntAObjUXyaFmo()
		{
			BCEJAizXSvucuShEhCivWcsNuuyl = null;
			vLlHrmnGGJSZXlWTFWaAmxkRefQH = default(qYblfIKWTJCcUzwzMzhWLaymennH);
		}
	}

	[Serializable]
	private sealed class GCLjQoHrezImqTDbDdioiPsrfjYr
	{
		public static readonly GCLjQoHrezImqTDbDdioiPsrfjYr _003C_003E9 = new GCLjQoHrezImqTDbDdioiPsrfjYr();

		public static Func<tOGkTtrMfwXIaOOPnXpdkfMfBvGD> _003C_003E9__19_0;

		public static Func<aIYAaOjwFkvPzunWYkcMbYCaLdlIB> _003C_003E9__19_1;

		internal tOGkTtrMfwXIaOOPnXpdkfMfBvGD NVmEaKfZBPpGDEriUmzParZiDNDk()
		{
			return new tOGkTtrMfwXIaOOPnXpdkfMfBvGD();
		}

		internal aIYAaOjwFkvPzunWYkcMbYCaLdlIB RhZclvFApVJGOeLbGVnEUlhFyfAXB()
		{
			return new aIYAaOjwFkvPzunWYkcMbYCaLdlIB();
		}
	}

	private readonly List<pzZEzDdoMuZGgUNhqysbzQlOheWD> oDGGMlwWRuwiMzIFBtUjyGGWNDXU;

	private readonly ReadOnlyCollection<pzZEzDdoMuZGgUNhqysbzQlOheWD> wvvOlGqmcFbONiKrehvkkyTpzpgcA;

	private readonly List<KjCHeFcNkYjJzESIKPSiBBloOtLf> ssmhPMipKKdyncQTNLPowAAeLqyzA;

	private readonly Func<int> AksmqfPLXyRqAZbivmadrMNlYZtf;

	private readonly Rewired.Utils.Classes.Utility.SpinLock WgZhBWCLumVsLEsOVbfyJfRTyTwG = new Rewired.Utils.Classes.Utility.SpinLock();

	private readonly Rewired.Utils.Classes.Utility.SpinLock tiKoMPJejkauYrftkKKkFMzCDMjDA = new Rewired.Utils.Classes.Utility.SpinLock();

	private RingBuffer<tOGkTtrMfwXIaOOPnXpdkfMfBvGD> cBFgREPvpbDDDOrmsxcaIEaLcAlIA;

	private RingBuffer<aIYAaOjwFkvPzunWYkcMbYCaLdlIB> hIFfJFXIWOWUlcHfldCJaEdCwfeu;

	private bool xhJKgJuhFOPEpnVzWdMTBCnMpdeW;

	private readonly ThreadSafeObjectPool<tOGkTtrMfwXIaOOPnXpdkfMfBvGD> lmzVybjcIgBscdnSVGTgwDnCQqGQ;

	private readonly ThreadSafeObjectPool<aIYAaOjwFkvPzunWYkcMbYCaLdlIB> msMUCiTNxvedJzCgtbrvutwcBGmc;

	private readonly List<pzZEzDdoMuZGgUNhqysbzQlOheWD> EvCzkSjJAirHjROUrweMckEXbLtC;

	private RingBuffer<tOGkTtrMfwXIaOOPnXpdkfMfBvGD> IyWAoJabBpJZUgmgMBAklRdjmVtMA;

	private RingBuffer<aIYAaOjwFkvPzunWYkcMbYCaLdlIB> ZSjYoKUngAmPIpWUkheEYWKYBbyX;

	private bool VgaKzInlsWfbRkZBqVIORqBNEKeHA;

	private Action<KjCHeFcNkYjJzESIKPSiBBloOtLf, qYblfIKWTJCcUzwzMzhWLaymennH> LHEbvGlGSYCrdJXyBWTXbDyLIXJK;

	[CompilerGenerated]
	private Action m_eYENURNiLdjNLHPgGqToUCsgEvbx;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	private static Guid[] GIkAAmBPUoLQJKnEitgUJnQeWzUV;

	private static string[] sporgdpUnerCErJHNdJbKdqqupeSA;

	private static string[] aqqbGImYirwDTvsEhowTLXHCIaEL;

	public event Action eYENURNiLdjNLHPgGqToUCsgEvbx
	{
		[CompilerGenerated]
		add
		{
			Action action = this.m_eYENURNiLdjNLHPgGqToUCsgEvbx;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, b);
				action = Interlocked.CompareExchange(ref this.m_eYENURNiLdjNLHPgGqToUCsgEvbx, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = this.m_eYENURNiLdjNLHPgGqToUCsgEvbx;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value3);
				action = Interlocked.CompareExchange(ref this.m_eYENURNiLdjNLHPgGqToUCsgEvbx, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public NebFbjcyIYuVGyepRxTmZTEcCkKG(Func<int> P_0)
	{
		AksmqfPLXyRqAZbivmadrMNlYZtf = P_0;
		LHEbvGlGSYCrdJXyBWTXbDyLIXJK = YvfcFXiGvIlVYpUUciNdgUycVuWwb;
		oDGGMlwWRuwiMzIFBtUjyGGWNDXU = new List<pzZEzDdoMuZGgUNhqysbzQlOheWD>();
		EvCzkSjJAirHjROUrweMckEXbLtC = new List<pzZEzDdoMuZGgUNhqysbzQlOheWD>();
		wvvOlGqmcFbONiKrehvkkyTpzpgcA = new ReadOnlyCollection<pzZEzDdoMuZGgUNhqysbzQlOheWD>(oDGGMlwWRuwiMzIFBtUjyGGWNDXU);
		ssmhPMipKKdyncQTNLPowAAeLqyzA = new List<KjCHeFcNkYjJzESIKPSiBBloOtLf>();
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)YMIsqNPkWjrdLcJvEeLWjHNzddLY.BKENsSJCwPFOTXkHKUNFIlpBJfYC * 32f) + 1;
		lmzVybjcIgBscdnSVGTgwDnCQqGQ = new ThreadSafeObjectPool<tOGkTtrMfwXIaOOPnXpdkfMfBvGD>(num, GCLjQoHrezImqTDbDdioiPsrfjYr._003C_003E9.NVmEaKfZBPpGDEriUmzParZiDNDk);
		msMUCiTNxvedJzCgtbrvutwcBGmc = new ThreadSafeObjectPool<aIYAaOjwFkvPzunWYkcMbYCaLdlIB>(128, GCLjQoHrezImqTDbDdioiPsrfjYr._003C_003E9.RhZclvFApVJGOeLbGVnEUlhFyfAXB);
		cBFgREPvpbDDDOrmsxcaIEaLcAlIA = new RingBuffer<tOGkTtrMfwXIaOOPnXpdkfMfBvGD>(num);
		hIFfJFXIWOWUlcHfldCJaEdCwfeu = new RingBuffer<aIYAaOjwFkvPzunWYkcMbYCaLdlIB>(128);
		IyWAoJabBpJZUgmgMBAklRdjmVtMA = new RingBuffer<tOGkTtrMfwXIaOOPnXpdkfMfBvGD>(num);
		ZSjYoKUngAmPIpWUkheEYWKYBbyX = new RingBuffer<aIYAaOjwFkvPzunWYkcMbYCaLdlIB>(128);
		KjCHeFcNkYjJzESIKPSiBBloOtLf.OaYsLjKSplJAeLCKxGYjJEfrIZXeA += yDATsQtksCeYsugKuRLmLJvHJzcQ;
		KjCHeFcNkYjJzESIKPSiBBloOtLf.lwRwFlPpiMccpeYDWZjPUyIaWBDjA += IUXlwmiFPOTpKtgtlBClOeYPKSvR;
		YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent += fxLwxYXNDeWmgTDmiAmUsGsoIgsu;
		YMIsqNPkWjrdLcJvEeLWjHNzddLY.unrfEQlddjGfPMFnGuoLscUgiQqR.ThreadUpdateEvent += OhCauHdFBDaPcQNeCIrGOfJDmDOy;
		ReInput.ApplicationFocusChangedEvent += orUMILCIqROwyBKfAAnTVqdZfYkj;
		ReInput.ApplicationPauseChangedEvent += TNcWPrbERDuIJOeRurmdoMrAbUeN;
		KjCHeFcNkYjJzESIKPSiBBloOtLf.sXJldihOTtQuAobmFasPIcWImTtk();
		TaXyyMyGvAuvuTnqJYFAkBuGsLMR();
	}

	public void mefhGqvTkcrETnFSidhNngFjAYNV()
	{
		bool flag = false;
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			if (VgaKzInlsWfbRkZBqVIORqBNEKeHA)
			{
				VgaKzInlsWfbRkZBqVIORqBNEKeHA = false;
				flag = true;
			}
		}
		if (flag)
		{
			TaXyyMyGvAuvuTnqJYFAkBuGsLMR();
		}
	}

	public void OBEYSjRjLIWTDPJJuJgIZZuPDcZo()
	{
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			MiscTools.Swap(ref cBFgREPvpbDDDOrmsxcaIEaLcAlIA, ref IyWAoJabBpJZUgmgMBAklRdjmVtMA);
		}
		while (cBFgREPvpbDDDOrmsxcaIEaLcAlIA.Count > 0)
		{
			tOGkTtrMfwXIaOOPnXpdkfMfBvGD tOGkTtrMfwXIaOOPnXpdkfMfBvGD2 = cBFgREPvpbDDDOrmsxcaIEaLcAlIA.Dequeue();
			int num = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(oDGGMlwWRuwiMzIFBtUjyGGWNDXU, tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.BCEJAizXSvucuShEhCivWcsNuuyl);
			if (num >= 0)
			{
				oDGGMlwWRuwiMzIFBtUjyGGWNDXU[num].biVimzifKYhPASSMiMszQGhHToFB(tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.dquVbpLOjjHPmaiZcuBhEZTKpYnNA, tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.YxFdZozJytryXOxcRaQAmySLFHVc);
			}
			tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.Return();
		}
	}

	private void YvfcFXiGvIlVYpUUciNdgUycVuWwb(KjCHeFcNkYjJzESIKPSiBBloOtLf P_0, qYblfIKWTJCcUzwzMzhWLaymennH P_1)
	{
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			return;
		}
		using (tiKoMPJejkauYrftkKKkFMzCDMjDA.Lock())
		{
			aIYAaOjwFkvPzunWYkcMbYCaLdlIB aIYAaOjwFkvPzunWYkcMbYCaLdlIB2 = msMUCiTNxvedJzCgtbrvutwcBGmc.Get();
			aIYAaOjwFkvPzunWYkcMbYCaLdlIB2.BCEJAizXSvucuShEhCivWcsNuuyl = P_0;
			aIYAaOjwFkvPzunWYkcMbYCaLdlIB2.vLlHrmnGGJSZXlWTFWaAmxkRefQH = P_1;
			hIFfJFXIWOWUlcHfldCJaEdCwfeu.Enqueue(aIYAaOjwFkvPzunWYkcMbYCaLdlIB2);
		}
	}

	public IList<pzZEzDdoMuZGgUNhqysbzQlOheWD> LRVtwyTWSgrntlaZRBVqrFfsbLRz()
	{
		return wvvOlGqmcFbONiKrehvkkyTpzpgcA;
	}

	private void TaXyyMyGvAuvuTnqJYFAkBuGsLMR()
	{
		bool flag = false;
		List<KjCHeFcNkYjJzESIKPSiBBloOtLf> list = ssmhPMipKKdyncQTNLPowAAeLqyzA;
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			KjCHeFcNkYjJzESIKPSiBBloOtLf.RhWUpMcyTJfUoIvxkzQIcguUCxGf(list);
			for (int num = EvCzkSjJAirHjROUrweMckEXbLtC.Count - 1; num >= 0; num--)
			{
				if (!ecSZEwttGfkQfToParxnBfHCGISs(list, EvCzkSjJAirHjROUrweMckEXbLtC[num].BCEJAizXSvucuShEhCivWcsNuuyl))
				{
					EvCzkSjJAirHjROUrweMckEXbLtC[num].BCEJAizXSvucuShEhCivWcsNuuyl.hldVlmZiYtOAMBUhZgNvxGgZETbs();
					EvCzkSjJAirHjROUrweMckEXbLtC[num].Dispose();
					EvCzkSjJAirHjROUrweMckEXbLtC.RemoveAt(num);
					flag = true;
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				KjCHeFcNkYjJzESIKPSiBBloOtLf kjCHeFcNkYjJzESIKPSiBBloOtLf = list[num2];
				if (KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(kjCHeFcNkYjJzESIKPSiBBloOtLf, null))
				{
					list.RemoveAt(num2);
				}
				else
				{
					int num3 = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(EvCzkSjJAirHjROUrweMckEXbLtC, kjCHeFcNkYjJzESIKPSiBBloOtLf);
					if (num3 >= 0)
					{
						list[num2].hldVlmZiYtOAMBUhZgNvxGgZETbs();
						list[num2] = EvCzkSjJAirHjROUrweMckEXbLtC[num3].BCEJAizXSvucuShEhCivWcsNuuyl;
					}
					else
					{
						EvCzkSjJAirHjROUrweMckEXbLtC.Add(new pzZEzDdoMuZGgUNhqysbzQlOheWD(kjCHeFcNkYjJzESIKPSiBBloOtLf, AksmqfPLXyRqAZbivmadrMNlYZtf(), LHEbvGlGSYCrdJXyBWTXbDyLIXJK));
						flag = true;
					}
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				KjCHeFcNkYjJzESIKPSiBBloOtLf kjCHeFcNkYjJzESIKPSiBBloOtLf2 = list[num4];
				int num5 = oIZRqqhhcNLckNTOGNWcXEsLzPfQ(EvCzkSjJAirHjROUrweMckEXbLtC, kjCHeFcNkYjJzESIKPSiBBloOtLf2);
				if (num5 >= 0)
				{
					pzZEzDdoMuZGgUNhqysbzQlOheWD item = EvCzkSjJAirHjROUrweMckEXbLtC[num5];
					EvCzkSjJAirHjROUrweMckEXbLtC.RemoveAt(num5);
					EvCzkSjJAirHjROUrweMckEXbLtC.Insert(0, item);
				}
			}
			oDGGMlwWRuwiMzIFBtUjyGGWNDXU.Clear();
			for (int i = 0; i < EvCzkSjJAirHjROUrweMckEXbLtC.Count; i++)
			{
				oDGGMlwWRuwiMzIFBtUjyGGWNDXU.Add(EvCzkSjJAirHjROUrweMckEXbLtC[i]);
			}
		}
		list.Clear();
		if (flag)
		{
			this.eYENURNiLdjNLHPgGqToUCsgEvbx?.Invoke();
		}
	}

	private void orUMILCIqROwyBKfAAnTVqdZfYkj(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
			{
				cBFgREPvpbDDDOrmsxcaIEaLcAlIA.Clear();
			}
		}
	}

	private void TNcWPrbERDuIJOeRurmdoMrAbUeN(bool P_0)
	{
		xhJKgJuhFOPEpnVzWdMTBCnMpdeW = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
			{
				cBFgREPvpbDDDOrmsxcaIEaLcAlIA.Clear();
			}
		}
	}

	private void fxLwxYXNDeWmgTDmiAmUsGsoIgsu()
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc || !xhJKgJuhFOPEpnVzWdMTBCnMpdeW)
		{
			return;
		}
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			int count = EvCzkSjJAirHjROUrweMckEXbLtC.Count;
			for (int i = 0; i < count; i++)
			{
				tOGkTtrMfwXIaOOPnXpdkfMfBvGD tOGkTtrMfwXIaOOPnXpdkfMfBvGD2 = lmzVybjcIgBscdnSVGTgwDnCQqGQ.Get();
				tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.BCEJAizXSvucuShEhCivWcsNuuyl = EvCzkSjJAirHjROUrweMckEXbLtC[i].BCEJAizXSvucuShEhCivWcsNuuyl;
				tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.dquVbpLOjjHPmaiZcuBhEZTKpYnNA = tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.BCEJAizXSvucuShEhCivWcsNuuyl.qIentWFneqFZrwJhbfDxqIanAiWc();
				tOGkTtrMfwXIaOOPnXpdkfMfBvGD2.YxFdZozJytryXOxcRaQAmySLFHVc = ReInput.realTime;
				IyWAoJabBpJZUgmgMBAklRdjmVtMA.Enqueue(tOGkTtrMfwXIaOOPnXpdkfMfBvGD2);
			}
		}
	}

	private void OhCauHdFBDaPcQNeCIrGOfJDmDOy()
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		using (tiKoMPJejkauYrftkKKkFMzCDMjDA.Lock())
		{
			MiscTools.Swap(ref hIFfJFXIWOWUlcHfldCJaEdCwfeu, ref ZSjYoKUngAmPIpWUkheEYWKYBbyX);
		}
		while (ZSjYoKUngAmPIpWUkheEYWKYBbyX.Count > 0)
		{
			aIYAaOjwFkvPzunWYkcMbYCaLdlIB aIYAaOjwFkvPzunWYkcMbYCaLdlIB2 = ZSjYoKUngAmPIpWUkheEYWKYBbyX.Dequeue();
			try
			{
				aIYAaOjwFkvPzunWYkcMbYCaLdlIB2.BCEJAizXSvucuShEhCivWcsNuuyl.neQxlYnEyEaZhAOllmdjXIpIwFLIA = aIYAaOjwFkvPzunWYkcMbYCaLdlIB2.vLlHrmnGGJSZXlWTFWaAmxkRefQH;
			}
			catch
			{
			}
			aIYAaOjwFkvPzunWYkcMbYCaLdlIB2.Return();
		}
	}

	private void yDATsQtksCeYsugKuRLmLJvHJzcQ(KjCHeFcNkYjJzESIKPSiBBloOtLf P_0)
	{
		P_0.hldVlmZiYtOAMBUhZgNvxGgZETbs();
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			VgaKzInlsWfbRkZBqVIORqBNEKeHA = true;
		}
	}

	private void IUXlwmiFPOTpKtgtlBClOeYPKSvR(KjCHeFcNkYjJzESIKPSiBBloOtLf P_0)
	{
		P_0.hldVlmZiYtOAMBUhZgNvxGgZETbs();
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
		{
			VgaKzInlsWfbRkZBqVIORqBNEKeHA = true;
		}
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		if (P_0)
		{
			ReInput.ApplicationFocusChangedEvent -= orUMILCIqROwyBKfAAnTVqdZfYkj;
			ReInput.ApplicationPauseChangedEvent -= TNcWPrbERDuIJOeRurmdoMrAbUeN;
			KjCHeFcNkYjJzESIKPSiBBloOtLf.OaYsLjKSplJAeLCKxGYjJEfrIZXeA -= yDATsQtksCeYsugKuRLmLJvHJzcQ;
			KjCHeFcNkYjJzESIKPSiBBloOtLf.lwRwFlPpiMccpeYDWZjPUyIaWBDjA -= IUXlwmiFPOTpKtgtlBClOeYPKSvR;
			YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent -= fxLwxYXNDeWmgTDmiAmUsGsoIgsu;
			YMIsqNPkWjrdLcJvEeLWjHNzddLY.unrfEQlddjGfPMFnGuoLscUgiQqR.ThreadUpdateEvent -= OhCauHdFBDaPcQNeCIrGOfJDmDOy;
			using (WgZhBWCLumVsLEsOVbfyJfRTyTwG.Lock())
			{
				for (int i = 0; i < EvCzkSjJAirHjROUrweMckEXbLtC.Count; i++)
				{
					try
					{
						EvCzkSjJAirHjROUrweMckEXbLtC[i].Dispose();
						EvCzkSjJAirHjROUrweMckEXbLtC[i].BCEJAizXSvucuShEhCivWcsNuuyl.hldVlmZiYtOAMBUhZgNvxGgZETbs();
					}
					catch
					{
					}
				}
				EvCzkSjJAirHjROUrweMckEXbLtC.Clear();
				oDGGMlwWRuwiMzIFBtUjyGGWNDXU.Clear();
			}
			try
			{
				KjCHeFcNkYjJzESIKPSiBBloOtLf.VisNutFgRAqdwkdUOFjAHMWYoNjQA();
			}
			catch
			{
			}
		}
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
	}

	private static bool ecSZEwttGfkQfToParxnBfHCGISs(IList<pzZEzDdoMuZGgUNhqysbzQlOheWD> P_0, KjCHeFcNkYjJzESIKPSiBBloOtLf P_1)
	{
		return oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, P_1) >= 0;
	}

	private static bool ecSZEwttGfkQfToParxnBfHCGISs(IList<KjCHeFcNkYjJzESIKPSiBBloOtLf> P_0, KjCHeFcNkYjJzESIKPSiBBloOtLf P_1)
	{
		return oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0, P_1) >= 0;
	}

	private static int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(IList<pzZEzDdoMuZGgUNhqysbzQlOheWD> P_0, KjCHeFcNkYjJzESIKPSiBBloOtLf P_1)
	{
		if (P_0 == null || KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i] != null && KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_0[i].BCEJAizXSvucuShEhCivWcsNuuyl, P_1))
			{
				return i;
			}
		}
		return -1;
	}

	private static int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(IList<KjCHeFcNkYjJzESIKPSiBBloOtLf> P_0, KjCHeFcNkYjJzESIKPSiBBloOtLf P_1)
	{
		if (P_0 == null || KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_1, null))
		{
			return -1;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (!KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_0[i], null) && KjCHeFcNkYjJzESIKPSiBBloOtLf.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_0[i], P_1))
			{
				return i;
			}
		}
		return -1;
	}

	static NebFbjcyIYuVGyepRxTmZTEcCkKG()
	{
		GIkAAmBPUoLQJKnEitgUJnQeWzUV = new Guid[1]
		{
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		sporgdpUnerCErJHNdJbKdqqupeSA = new string[1] { "Xbox Bluetooth Gamepad" };
		aqqbGImYirwDTvsEhowTLXHCIaEL = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool nPJebSIDKqCalbSyJkXNJJpjvLEAD(string P_0, string P_1, ushort P_2, ushort P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < sporgdpUnerCErJHNdJbKdqqupeSA.Length; i++)
			{
				if (P_1.Equals(sporgdpUnerCErJHNdJbKdqqupeSA[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < aqqbGImYirwDTvsEhowTLXHCIaEL.Length; j++)
			{
				if (Regex.IsMatch(P_1, aqqbGImYirwDTvsEhowTLXHCIaEL[j], RegexOptions.IgnoreCase))
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
