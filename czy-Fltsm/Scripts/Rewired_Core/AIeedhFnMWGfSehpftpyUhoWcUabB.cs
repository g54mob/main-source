using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class AIeedhFnMWGfSehpftpyUhoWcUabB : IDisposable
{
	public enum RIXubQImtmFJkURJgcapIjbkAuxoA
	{
		Connected = 0,
		Disconnected = 1
	}

	private class WGVvleyUXWCSakxunjhDGfCKHEdv
	{
		public ADictionary<int, InputBehavior> HxJPtcXCANRjKIpAxiKLzAUavffE;

		public List<InputBehavior> fcisbjOhlpeaqSIQcShnCvaYyPH;

		public IList<InputBehavior> mZpvbOVlenEsadGmczSuEoQvesDHA;

		public WGVvleyUXWCSakxunjhDGfCKHEdv(List<InputBehavior> P_0)
		{
			fcisbjOhlpeaqSIQcShnCvaYyPH = new List<InputBehavior>(P_0.Count);
			HxJPtcXCANRjKIpAxiKLzAUavffE = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				HxJPtcXCANRjKIpAxiKLzAUavffE.Add(P_0[i].id, inputBehavior);
				fcisbjOhlpeaqSIQcShnCvaYyPH.Add(inputBehavior);
				num++;
			}
			mZpvbOVlenEsadGmczSuEoQvesDHA = new ReadOnlyCollection<InputBehavior>(fcisbjOhlpeaqSIQcShnCvaYyPH);
		}

		public InputBehavior hUZELacbBZryGxYILgAGdQnTPXQQA(int P_0)
		{
			if (fcisbjOhlpeaqSIQcShnCvaYyPH.Count == 0)
			{
				return null;
			}
			HxJPtcXCANRjKIpAxiKLzAUavffE.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return fcisbjOhlpeaqSIQcShnCvaYyPH[0];
			}
			return value;
		}
	}

	private sealed class SsPiFCsKCalDuLiijKMMtcBoaLgP : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int eWxPRTTSLfkhJFcZwlMaTUEfQCAy;

		private CustomController OyKRwOYSJOMbMRgAsqGrSvmSfuyK;

		private int vHCZJENyqoakdTGJhpxXANenodpG;

		public AIeedhFnMWGfSehpftpyUhoWcUabB qjhLfhrYAzVvoSEonFiyFHkzKQbJA;

		private int NZCxaFuWQtOnSzWSVNwknaemsdTe;

		public int xOnAtvDYrRNSGRUIcDDqAGybixySB;

		private int TaXoCMQZruiHRwfsodcstCwzQoUb;

		private int RUacUGOWqkyUosvNzVNOdqchAFVCA;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return OyKRwOYSJOMbMRgAsqGrSvmSfuyK;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return OyKRwOYSJOMbMRgAsqGrSvmSfuyK;
			}
		}

		[DebuggerHidden]
		public SsPiFCsKCalDuLiijKMMtcBoaLgP(int P_0)
		{
			eWxPRTTSLfkhJFcZwlMaTUEfQCAy = P_0;
			vHCZJENyqoakdTGJhpxXANenodpG = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			eWxPRTTSLfkhJFcZwlMaTUEfQCAy = -2;
		}

		private bool MoveNext()
		{
			int num = eWxPRTTSLfkhJFcZwlMaTUEfQCAy;
			AIeedhFnMWGfSehpftpyUhoWcUabB aIeedhFnMWGfSehpftpyUhoWcUabB = qjhLfhrYAzVvoSEonFiyFHkzKQbJA;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				eWxPRTTSLfkhJFcZwlMaTUEfQCAy = -1;
				goto IL_007d;
			}
			eWxPRTTSLfkhJFcZwlMaTUEfQCAy = -1;
			TaXoCMQZruiHRwfsodcstCwzQoUb = aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
			RUacUGOWqkyUosvNzVNOdqchAFVCA = 0;
			goto IL_008d;
			IL_007d:
			RUacUGOWqkyUosvNzVNOdqchAFVCA++;
			goto IL_008d;
			IL_008d:
			if (RUacUGOWqkyUosvNzVNOdqchAFVCA < TaXoCMQZruiHRwfsodcstCwzQoUb)
			{
				if (aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB[RUacUGOWqkyUosvNzVNOdqchAFVCA].sourceControllerId == NZCxaFuWQtOnSzWSVNwknaemsdTe)
				{
					OyKRwOYSJOMbMRgAsqGrSvmSfuyK = aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB[RUacUGOWqkyUosvNzVNOdqchAFVCA];
					eWxPRTTSLfkhJFcZwlMaTUEfQCAy = 1;
					return true;
				}
				goto IL_007d;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			SsPiFCsKCalDuLiijKMMtcBoaLgP ssPiFCsKCalDuLiijKMMtcBoaLgP;
			if (eWxPRTTSLfkhJFcZwlMaTUEfQCAy == -2 && vHCZJENyqoakdTGJhpxXANenodpG == Environment.CurrentManagedThreadId)
			{
				eWxPRTTSLfkhJFcZwlMaTUEfQCAy = 0;
				ssPiFCsKCalDuLiijKMMtcBoaLgP = this;
			}
			else
			{
				ssPiFCsKCalDuLiijKMMtcBoaLgP = new SsPiFCsKCalDuLiijKMMtcBoaLgP(0);
				ssPiFCsKCalDuLiijKMMtcBoaLgP.qjhLfhrYAzVvoSEonFiyFHkzKQbJA = qjhLfhrYAzVvoSEonFiyFHkzKQbJA;
			}
			ssPiFCsKCalDuLiijKMMtcBoaLgP.NZCxaFuWQtOnSzWSVNwknaemsdTe = xOnAtvDYrRNSGRUIcDDqAGybixySB;
			return ssPiFCsKCalDuLiijKMMtcBoaLgP;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class QCVwKoYXVyFyVDrtDUvOszdCHjCT : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int lxmFUrMUMtwhnCfGlNIxRYocTbGH;

		private CustomController fCpfVMDHpVTbaDHpyawPCOwSXHPL;

		private int UOCERdWOuCbGYpXcQLEvacKHlrrl;

		public AIeedhFnMWGfSehpftpyUhoWcUabB zwTKWwsqBnNTOojKZhLCmIGRXCes;

		private string HkkYxsaVBgOVVBjHPHpOcdBjWdeu;

		public string ZXqqhMLPZBWCGcTxTBmZSYVuckGk;

		private int KpXSjHhIotgxmhPEhEqPfhnuvMQdA;

		private int rvsYVGKdjPhmKNzUcClkBYvnnaEn;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return fCpfVMDHpVTbaDHpyawPCOwSXHPL;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return fCpfVMDHpVTbaDHpyawPCOwSXHPL;
			}
		}

		[DebuggerHidden]
		public QCVwKoYXVyFyVDrtDUvOszdCHjCT(int P_0)
		{
			lxmFUrMUMtwhnCfGlNIxRYocTbGH = P_0;
			UOCERdWOuCbGYpXcQLEvacKHlrrl = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			lxmFUrMUMtwhnCfGlNIxRYocTbGH = -2;
		}

		private bool MoveNext()
		{
			int num = lxmFUrMUMtwhnCfGlNIxRYocTbGH;
			AIeedhFnMWGfSehpftpyUhoWcUabB aIeedhFnMWGfSehpftpyUhoWcUabB = zwTKWwsqBnNTOojKZhLCmIGRXCes;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				lxmFUrMUMtwhnCfGlNIxRYocTbGH = -1;
				goto IL_0083;
			}
			lxmFUrMUMtwhnCfGlNIxRYocTbGH = -1;
			KpXSjHhIotgxmhPEhEqPfhnuvMQdA = aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
			rvsYVGKdjPhmKNzUcClkBYvnnaEn = 0;
			goto IL_0093;
			IL_0083:
			rvsYVGKdjPhmKNzUcClkBYvnnaEn++;
			goto IL_0093;
			IL_0093:
			if (rvsYVGKdjPhmKNzUcClkBYvnnaEn < KpXSjHhIotgxmhPEhEqPfhnuvMQdA)
			{
				if (aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB[rvsYVGKdjPhmKNzUcClkBYvnnaEn].tag.Equals(HkkYxsaVBgOVVBjHPHpOcdBjWdeu, StringComparison.OrdinalIgnoreCase))
				{
					fCpfVMDHpVTbaDHpyawPCOwSXHPL = aIeedhFnMWGfSehpftpyUhoWcUabB.RLchXLhEDVIYNGMlqENNIPqfAXbnB[rvsYVGKdjPhmKNzUcClkBYvnnaEn];
					lxmFUrMUMtwhnCfGlNIxRYocTbGH = 1;
					return true;
				}
				goto IL_0083;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			QCVwKoYXVyFyVDrtDUvOszdCHjCT qCVwKoYXVyFyVDrtDUvOszdCHjCT;
			if (lxmFUrMUMtwhnCfGlNIxRYocTbGH == -2 && UOCERdWOuCbGYpXcQLEvacKHlrrl == Environment.CurrentManagedThreadId)
			{
				lxmFUrMUMtwhnCfGlNIxRYocTbGH = 0;
				qCVwKoYXVyFyVDrtDUvOszdCHjCT = this;
			}
			else
			{
				qCVwKoYXVyFyVDrtDUvOszdCHjCT = new QCVwKoYXVyFyVDrtDUvOszdCHjCT(0);
				qCVwKoYXVyFyVDrtDUvOszdCHjCT.zwTKWwsqBnNTOojKZhLCmIGRXCes = zwTKWwsqBnNTOojKZhLCmIGRXCes;
			}
			qCVwKoYXVyFyVDrtDUvOszdCHjCT.HkkYxsaVBgOVVBjHPHpOcdBjWdeu = ZXqqhMLPZBWCGcTxTBmZSYVuckGk;
			return qCVwKoYXVyFyVDrtDUvOszdCHjCT;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> NDpJxXvYCNJKoqMFUImLtdUmdfVZ;

	private List<Joystick> yTpjvNKBTrHDbltzcbPsiAcoWLAS;

	private List<CustomController> RLchXLhEDVIYNGMlqENNIPqfAXbnB;

	private List<Controller> rpeuwfhEvCHBTxrQcBajZcISmATE;

	private ReadOnlyCollection<Controller> xBEHSICoNTNktFyYHwnuEFmWsVAMb;

	private Keyboard VeTJUNkhWGQtgImKAkUWIjBIfRzCA;

	private Mouse mqsSoHwfAFQfvHOWEKMnmCxCSOMA;

	private ConfigVars YnQhHMyrwNsdCEdnMllCGgLHAHbdA;

	private lXvJAREcFJqTwbpbVaXyWnOsESQEA[] mZGdPfvcATxNBHWYQHHfKlJoXfnH;

	private lXvJAREcFJqTwbpbVaXyWnOsESQEA[] DOZbHhiJhwcrxPLodvipogkjiBzp;

	private lXvJAREcFJqTwbpbVaXyWnOsESQEA[,] AfMlgkFJZonAXTZfgguNfwpxiUBQ;

	private hDRjlPfDOtRlfpMOOkqkYoBqMUPDA IzgcdwmeJbFTTATvDAQJSsIuCjsib;

	private XAxeWKBTpmhGlemygQQKqbyPshCG bFRDjOFzDfLHmRXUOpUYXTzWbmnd;

	private XAxeWKBTpmhGlemygQQKqbyPshCG[] pFfzhhhyjLERhYQzduDfzyzMoHHw;

	private global::vVEPpXcualaRdQEuiaXKpUBZsyXv<ActiveControllerChangedDelegate> QZuraXLFXOAHWfhAeEPfIIjVjjsuA;

	private global::vVEPpXcualaRdQEuiaXKpUBZsyXv<PlayerActiveControllerChangedDelegate> lAwJiIgBYugXKvRMfCmKGZOLscLvA;

	private global::vVEPpXcualaRdQEuiaXKpUBZsyXv<PlayerActiveControllerChangedDelegate>[] bEalUNMbBgUkQrkuDUhNLHjBJFvq;

	private ADictionary<int, WGVvleyUXWCSakxunjhDGfCKHEdv> WRmcYAMzhmVnAEBESiLPiygmfwVN;

	private readonly WbtTwlDPwwjUlDmYIZawuYHsCcBA xaScHozvHVICKvVRXEZMbeaVXWKw;

	private IList<Joystick> muxTPmvljubzzhGgsBklwPiPrReZ;

	private IList<CustomController> sTLdXxADNjHSdavcaNdzdnuiHdEiD;

	private int dTremBqiQPGvyGpmcgzKbeDeqsfYA;

	private bool NGpLNVKggcvARAERXxtqupGFcryD;

	private bool YDMacOWLsjSaVdAGjGApLeCGpTIC;

	private bool MNhnzyuPQrjhAchEBlQeFmMUGgDt;

	private IUnifiedKeyboardSource eIKDbEzZjkiQVKvfhaOxSgnEWbMW;

	private IUnifiedMouseSource cRGtyEeyNwydFRopwnsxdtUzrUTb;

	private int AtFDzVIdHHkHTNzdcbhTqbRDageo;

	private ControllerType NHloQSKQJbfoEfrOqmMrVXlhoGov;

	private double FXcOGDiDkhrzMVWjsusqZLzLYPvt;

	private int UbDLYxdTlBFtuFFSJpcKCeymTTX;

	private CyDvJIEcvrEMxaEuIJlUHZHwTRMo urFYgHdkvFdZTPSaFnxtLXEOKfxh;

	private eRfSfYfcNJSmLRCFhmMQAqNbCscG phradCjIejilCZpqeYSnYsWjgoKV;

	private int tvycUiUCWjWtUfnymFXWFQPOoBobA;

	private int WCpCZGaOkzjvLaxicsgmVVHMfmfFA;

	private Action<int, ControllerDataUpdater> jsuSHBjzKIBbMNyOnhOAgkcxOLSB;

	private Action<bool, int, int> USrczUEkeGoUPSajfDuXgRTCzMwd;

	private Action<ControllerStatusChangedEventArgs> eUtiKNUBhYdHtjAEBLbUlMSPfOobA;

	private Action<ControllerType, int> OdlOyoYfbFpSeqEEkpyKtammkaWh;

	private bool kmjrBOqBelEtvFOeqTruCALWEBKvA;

	public IList<Joystick> aTDAanYgsxAziebHbMuodwRRawcC => muxTPmvljubzzhGgsBklwPiPrReZ;

	public List<Joystick> cpNdTuaRngFNLYEfEFIzHjkHKxxQb => NDpJxXvYCNJKoqMFUImLtdUmdfVZ;

	public int eoBdhxXkFRcCpTZAvInYZHzHfdAP => NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;

	public Mouse QRdffiyBXZIwyIaPCjnZBUdIBmik => mqsSoHwfAFQfvHOWEKMnmCxCSOMA;

	public Keyboard IeYgCxBcbnFZhKaxGJMqKHnEVRHi => VeTJUNkhWGQtgImKAkUWIjBIfRzCA;

	public IList<CustomController> KbVTmGudneBycajQqiiCMqSOgtMpA => sTLdXxADNjHSdavcaNdzdnuiHdEiD;

	public List<CustomController> wbAkTszNGfttsDQOZiQKkfAabZhdA => RLchXLhEDVIYNGMlqENNIPqfAXbnB;

	public int PsjwTZKfSMplrvqshESSZRCHWDSx => RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;

	public IList<Controller> fohMKRyovgefmeRThMOoFsVQVDtNA => xBEHSICoNTNktFyYHwnuEFmWsVAMb;

	public int dhULUdhbafxgPurKrwINoSNnDVIU => rpeuwfhEvCHBTxrQcBajZcISmATE.Count;

	private int LQrBdPJpwJTapEceIPQCfhjSXlYk
	{
		get
		{
			int ubDLYxdTlBFtuFFSJpcKCeymTTX = UbDLYxdTlBFtuFFSJpcKCeymTTX;
			UbDLYxdTlBFtuFFSJpcKCeymTTX++;
			if (UbDLYxdTlBFtuFFSJpcKCeymTTX >= int.MaxValue)
			{
				UbDLYxdTlBFtuFFSJpcKCeymTTX = 0;
			}
			return ubDLYxdTlBFtuFFSJpcKCeymTTX;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> wgtMEaFcbuBrERLDbhlCIrNopBmdb
	{
		add
		{
			eUtiKNUBhYdHtjAEBLbUlMSPfOobA = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(eUtiKNUBhYdHtjAEBLbUlMSPfOobA, b);
		}
		remove
		{
			eUtiKNUBhYdHtjAEBLbUlMSPfOobA = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(eUtiKNUBhYdHtjAEBLbUlMSPfOobA, value2);
		}
	}

	public event Action<ControllerType, int> EsWpIcPMLnEDQIbqcvLkHJATuaLeA
	{
		add
		{
			OdlOyoYfbFpSeqEEkpyKtammkaWh = (Action<ControllerType, int>)Delegate.Combine(OdlOyoYfbFpSeqEEkpyKtammkaWh, b);
		}
		remove
		{
			OdlOyoYfbFpSeqEEkpyKtammkaWh = (Action<ControllerType, int>)Delegate.Remove(OdlOyoYfbFpSeqEEkpyKtammkaWh, value2);
		}
	}

	public AIeedhFnMWGfSehpftpyUhoWcUabB(ConfigVars P_0, PlatformInputManager P_1)
	{
		YnQhHMyrwNsdCEdnMllCGgLHAHbdA = P_0;
		dTremBqiQPGvyGpmcgzKbeDeqsfYA = 0;
		NGpLNVKggcvARAERXxtqupGFcryD = UnityTools.isAndroidPlatform;
		rpeuwfhEvCHBTxrQcBajZcISmATE = new List<Controller>(10);
		xBEHSICoNTNktFyYHwnuEFmWsVAMb = new ReadOnlyCollection<Controller>(rpeuwfhEvCHBTxrQcBajZcISmATE);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (eIKDbEzZjkiQVKvfhaOxSgnEWbMW = new UnityUnifiedKeyboardSource());
		}
		VeTJUNkhWGQtgImKAkUWIjBIfRzCA = new Keyboard("Keyboard", unifiedKeyboardSource);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Add(VeTJUNkhWGQtgImKAkUWIjBIfRzCA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (cRGtyEeyNwydFRopwnsxdtUzrUTb = new UnityUnifiedMouseSource());
		}
		mqsSoHwfAFQfvHOWEKMnmCxCSOMA = new Mouse("Mouse", unifiedMouseSource);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Add(mqsSoHwfAFQfvHOWEKMnmCxCSOMA);
		IzgcdwmeJbFTTATvDAQJSsIuCjsib = new hDRjlPfDOtRlfpMOOkqkYoBqMUPDA(P_0.updateLoop, VeTJUNkhWGQtgImKAkUWIjBIfRzCA);
		VeTJUNkhWGQtgImKAkUWIjBIfRzCA.BaxIjLbHPaxcPYIMCfZOBTYdQVZab += NpxgeOufoiISagUPhlgNdSqihwvB;
		VeTJUNkhWGQtgImKAkUWIjBIfRzCA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		mqsSoHwfAFQfvHOWEKMnmCxCSOMA.enabled = !P_0.GetPlatformVar_disableMouse();
		XQbPBhlyQFBGpNmlFgFIDEslKZJP.BQweCAtphicwgHuQORPSKCoEoqW();
		xaScHozvHVICKvVRXEZMbeaVXWKw = new WbtTwlDPwwjUlDmYIZawuYHsCcBA(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		xaScHozvHVICKvVRXEZMbeaVXWKw.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(VeTJUNkhWGQtgImKAkUWIjBIfRzCA);
		xaScHozvHVICKvVRXEZMbeaVXWKw.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(mqsSoHwfAFQfvHOWEKMnmCxCSOMA);
		ReInput.ApplicationFocusChangedEvent += XVCRvgTPSTdVzoAvCQFttZfKoDLE;
	}

	public void hHOxschWrmLvskqXlCUvlLVLCYXX(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		jsuSHBjzKIBbMNyOnhOAgkcxOLSB = P_0;
		DePSpmalxHDjxSmJCVcijTKXWbPx(P_1);
	}

	public void HxlMrDZBLqBGMkXlDvSppnBsJzst(UpdateLoopType P_0)
	{
		XQbPBhlyQFBGpNmlFgFIDEslKZJP.MLAwTXIwADpEAApeNJbvBhLZrvx(P_0);
		if (VeTJUNkhWGQtgImKAkUWIjBIfRzCA.enabled)
		{
			IzgcdwmeJbFTTATvDAQJSsIuCjsib.PBIHfiikorHibkYrToyfflNCXOwI(P_0);
		}
		dnEYVTCqJGEvGSZANifWsWYbOPlP(P_0);
		PgZfpjZNLTiaxJhDxCFADsVrGEOR(P_0);
		XQbPBhlyQFBGpNmlFgFIDEslKZJP.KmaMezywuRDQogkAzHEyGTmEiBskA(P_0, ReInput.currentFrame);
		if (MNhnzyuPQrjhAchEBlQeFmMUGgDt)
		{
			UvGAFSChEmJAKLoasHgJZRlqQUMhA();
		}
	}

	public lXvJAREcFJqTwbpbVaXyWnOsESQEA yLGNSfUwPfuUzLFYtyWCODvdszHP(int P_0, string P_1, bool P_2)
	{
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.GUBPPhmqZCglriHZbaAZukoqMhrUA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return DOZbHhiJhwcrxPLodvipogkjiBzp[num];
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return null;
		}
		return AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, num];
	}

	public lXvJAREcFJqTwbpbVaXyWnOsESQEA QHFuKKuEdmbuZhdfgZkffCESrqCA(int P_0, int P_1, bool P_2)
	{
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.JhlDaGJYzfnrxwSiGQiEnISqUoWv(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return DOZbHhiJhwcrxPLodvipogkjiBzp[num];
		}
		return AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, num];
	}

	public void TKufUXoboKgMCCjsXhPkiHjVxHlS(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			RIXubQImtmFJkURJgcapIjbkAuxoA rIXubQImtmFJkURJgcapIjbkAuxoA = RIXubQImtmFJkURJgcapIjbkAuxoA.Connected;
			int num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0.sourceJoystick.rewiredId, rIXubQImtmFJkURJgcapIjbkAuxoA);
			if (num < 0)
			{
				rIXubQImtmFJkURJgcapIjbkAuxoA = RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected;
				num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0.sourceJoystick.rewiredId, rIXubQImtmFJkURJgcapIjbkAuxoA);
			}
			if (num >= 0)
			{
				((rIXubQImtmFJkURJgcapIjbkAuxoA == RIXubQImtmFJkURJgcapIjbkAuxoA.Connected) ? NDpJxXvYCNJKoqMFUImLtdUmdfVZ[num] : yTpjvNKBTrHDbltzcbPsiAcoWLAS[num]).NmVbsZBAgbIDJdtUnWiZxNfwSFqX(P_0);
			}
		}
	}

	public bool JengPYHyAomLJCdooRscPiQfpkSV(int P_0, RIXubQImtmFJkURJgcapIjbkAuxoA P_1)
	{
		return OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0, P_1) >= 0;
	}

	public int OmVUAmJBSQrkfqnizgiCwmICkSDU(int P_0, RIXubQImtmFJkURJgcapIjbkAuxoA P_1)
	{
		switch (P_1)
		{
		case RIXubQImtmFJkURJgcapIjbkAuxoA.Connected:
		{
			int count2 = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
			for (int j = 0; j < count2; j++)
			{
				if (NDpJxXvYCNJKoqMFUImLtdUmdfVZ[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected:
		{
			int count = yTpjvNKBTrHDbltzcbPsiAcoWLAS.Count;
			for (int i = 0; i < count; i++)
			{
				if (yTpjvNKBTrHDbltzcbPsiAcoWLAS[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int JYspWtnFSdhYEdnHbbYbmKflJMut(Guid P_0, RIXubQImtmFJkURJgcapIjbkAuxoA P_1)
	{
		switch (P_1)
		{
		case RIXubQImtmFJkURJgcapIjbkAuxoA.Connected:
		{
			int count2 = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
			for (int j = 0; j < count2; j++)
			{
				if (NDpJxXvYCNJKoqMFUImLtdUmdfVZ[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected:
		{
			int count = yTpjvNKBTrHDbltzcbPsiAcoWLAS.Count;
			for (int i = 0; i < count; i++)
			{
				if (yTpjvNKBTrHDbltzcbPsiAcoWLAS[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool EMYPoxKpUEHJFbEXaRpyhfoAMstL(int P_0)
	{
		return IFGRDsJdDNukQIBqJsPAYlznbszCA(P_0) >= 0;
	}

	public int IFGRDsJdDNukQIBqJsPAYlznbszCA(int P_0)
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		for (int i = 0; i < count; i++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int XFFhgndwpwcWARkHJJiGCWZLzsLqA(Guid P_0)
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		for (int i = 0; i < count; i++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void tSbgJnXNlwUEfhPxrfDURxycaCuhA(BridgedController P_0)
	{
		iWQLhXRgKNCwEXbOsanTCMUVtpvwA(P_0);
	}

	public void gRFaXBoICFRzHDolWHkSoCyyzqVH(int P_0)
	{
		int num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0, RIXubQImtmFJkURJgcapIjbkAuxoA.Connected);
		dsuozhsoCLPPuYiZGNbIQGaINAFA(num);
	}

	public int XPueGFlzrTTDfolLkaGbPaDbuBrh()
	{
		return dTremBqiQPGvyGpmcgzKbeDeqsfYA++;
	}

	public IList<InputBehavior> BUHchcVExxcLLVISomzDIDkZWYHs(int P_0)
	{
		if (!WRmcYAMzhmVnAEBESiLPiygmfwVN.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return WRmcYAMzhmVnAEBESiLPiygmfwVN[P_0].mZpvbOVlenEsadGmczSuEoQvesDHA;
	}

	public InputBehavior KSWKFupatZtHQrFKolbYiPjSGdhh(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return ZSaXaWxiHUTBOKAFUdCciNmpaevcA(P_0, inputBehaviorId);
	}

	public InputBehavior ZSaXaWxiHUTBOKAFUdCciNmpaevcA(int P_0, int P_1)
	{
		if (!WRmcYAMzhmVnAEBESiLPiygmfwVN.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> mZpvbOVlenEsadGmczSuEoQvesDHA = WRmcYAMzhmVnAEBESiLPiygmfwVN[P_0].mZpvbOVlenEsadGmczSuEoQvesDHA;
		for (int i = 0; i < mZpvbOVlenEsadGmczSuEoQvesDHA.Count; i++)
		{
			if (mZpvbOVlenEsadGmczSuEoQvesDHA[i].id == P_1)
			{
				return mZpvbOVlenEsadGmczSuEoQvesDHA[i];
			}
		}
		return null;
	}

	public Joystick xVDcTIAXBrOtROlyxNNOhlGQNowqA(int P_0, bool P_1 = false)
	{
		int num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0, RIXubQImtmFJkURJgcapIjbkAuxoA.Connected);
		if (num >= 0)
		{
			return NDpJxXvYCNJKoqMFUImLtdUmdfVZ[num];
		}
		if (P_1)
		{
			num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0, RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected);
			if (num >= 0)
			{
				return yTpjvNKBTrHDbltzcbPsiAcoWLAS[num];
			}
		}
		return null;
	}

	public Joystick gDlRtsqIYCUNFnrhmSFyYmcOVopP(Guid P_0, bool P_1 = false)
	{
		int num = JYspWtnFSdhYEdnHbbYbmKflJMut(P_0, RIXubQImtmFJkURJgcapIjbkAuxoA.Connected);
		if (num >= 0)
		{
			return NDpJxXvYCNJKoqMFUImLtdUmdfVZ[num];
		}
		if (P_1)
		{
			num = JYspWtnFSdhYEdnHbbYbmKflJMut(P_0, RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected);
			if (num >= 0)
			{
				return yTpjvNKBTrHDbltzcbPsiAcoWLAS[num];
			}
		}
		return null;
	}

	public Joystick[] dOsaTeFHGZLdISSDRxRMUftKBnTcA()
	{
		int count = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i];
		}
		return array;
	}

	public string[] qQnNcixYGlqMdriBgpXuVIsFSsxb()
	{
		int count = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i].name;
		}
		return array;
	}

	public CustomController PeWLEoKTTGbofJQCWeTcZfvcnjPy(int P_0)
	{
		int num = IFGRDsJdDNukQIBqJsPAYlznbszCA(P_0);
		if (num < 0)
		{
			return null;
		}
		return RLchXLhEDVIYNGMlqENNIPqfAXbnB[num];
	}

	public CustomController IvGjgSNItvOJLYIEjzxXsNpVJxsg(Guid P_0)
	{
		int num = XFFhgndwpwcWARkHJJiGCWZLzsLqA(P_0);
		if (num < 0)
		{
			return null;
		}
		return RLchXLhEDVIYNGMlqENNIPqfAXbnB[num];
	}

	public CustomController[] UxQpiyrLGaaabQqScYxqriUZuQyC()
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RLchXLhEDVIYNGMlqENNIPqfAXbnB[i];
		}
		return array;
	}

	public string[] bWPGfQTrLvAbZJlkfamZgaZdANCGB()
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RLchXLhEDVIYNGMlqENNIPqfAXbnB[i].name;
		}
		return array;
	}

	public CustomController NprxOsPQZmIODMrEVTJSdqAawKNH(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int aPkIxRmZmsXulBxCxpKtjCFNdFhI = LQrBdPJpwJTapEceIPQCfhjSXlYk;
		CustomController customController = new CustomController(new mqPhMngUOCoKlpBKyQYRthlEEQXL
		{
			hPmyndiXkJrvbzgToNVRHpfzSoBO = InputSource.Custom,
			EqfmgsMFrzzIlxYrBIQejdXRTHTO = customControllerById.descriptiveName,
			cemhyouVznfmflbwfaEFmtkJtirL = customControllerById.name,
			iZrPzmqRbzHAVyYufnkhwYySQigO = customControllerById.axisCount,
			RPofuoVXVweopJJOFZyqJsKDWnMIA = customControllerById.buttonCount,
			aPkIxRmZmsXulBxCxpKtjCFNdFhI = aPkIxRmZmsXulBxCxpKtjCFNdFhI,
			eWLAyERXGypSzNqxHYnGoyfVmLEm = customControllerById.id,
			XGbLzThtLsuZPPsuLihTCkFECnHGA = customControllerById.typeGuid,
			oUdwtjKckScokjAYAyVwamJCaTqI = customControllerById.id.ToString(),
			PayEJivmCQGkMfwbYfCXcSXDsnzxb = customControllerById.CreateGameHardwareMap()
		});
		PdLAcdSRcngjhOPdcUcocfpXDIZX(customController);
		return customController;
	}

	public bool qoZabUfocoUlmIzaNPofEkUWbSrv(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return NhbseXKpsIEmWEirsomWOfKwFFpCb(P_0);
	}

	public CustomController cXNrtcUrQlRKGIQfqPgrMXDvELyF(int P_0)
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		for (int i = 0; i < count; i++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[i].sourceControllerId == P_0)
			{
				return RLchXLhEDVIYNGMlqENNIPqfAXbnB[i];
			}
		}
		return null;
	}

	public CustomController HHTFVZaetQFpMLtbzCIslssQpklVA(string P_0)
	{
		int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		for (int i = 0; i < count; i++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return RLchXLhEDVIYNGMlqENNIPqfAXbnB[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(SsPiFCsKCalDuLiijKMMtcBoaLgP))]
	public IEnumerable<CustomController> fRUUDeWfuYtnNGgLAgATFsdYAdGiA(int P_0)
	{
		return new SsPiFCsKCalDuLiijKMMtcBoaLgP(-2)
		{
			qjhLfhrYAzVvoSEonFiyFHkzKQbJA = this,
			xOnAtvDYrRNSGRUIcDDqAGybixySB = P_0
		};
	}

	[IteratorStateMachine(typeof(QCVwKoYXVyFyVDrtDUvOszdCHjCT))]
	public IEnumerable<CustomController> cpbpFtJcLBHHKKpkNKIzRoKsTudc(string P_0)
	{
		return new QCVwKoYXVyFyVDrtDUvOszdCHjCT(-2)
		{
			zwTKWwsqBnNTOojKZhLCmIGRXCes = this,
			ZXqqhMLPZBWCGcTxTBmZSYVuckGk = P_0
		};
	}

	public Controller DFkLoOraYKZxPsJxXLcjqacSAAGg(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => xVDcTIAXBrOtROlyxNNOhlGQNowqA(P_1, P_2), 
			ControllerType.Keyboard => VeTJUNkhWGQtgImKAkUWIjBIfRzCA, 
			ControllerType.Mouse => mqsSoHwfAFQfvHOWEKMnmCxCSOMA, 
			ControllerType.Custom => PeWLEoKTTGbofJQCWeTcZfvcnjPy(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller VleibMOfPIZqdSMNAKofMqlggTDd(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return ofNCJKseEYuNhHiRHBbtAhhGmOcT(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return DFkLoOraYKZxPsJxXLcjqacSAAGg(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller ofNCJKseEYuNhHiRHBbtAhhGmOcT(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (VeTJUNkhWGQtgImKAkUWIjBIfRzCA.deviceInstanceGuid == P_0)
		{
			return VeTJUNkhWGQtgImKAkUWIjBIfRzCA;
		}
		if (mqsSoHwfAFQfvHOWEKMnmCxCSOMA.deviceInstanceGuid == P_0)
		{
			return mqsSoHwfAFQfvHOWEKMnmCxCSOMA;
		}
		Controller result;
		if ((result = gDlRtsqIYCUNFnrhmSFyYmcOVopP(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = IvGjgSNItvOJLYIEjzxXsNpVJxsg(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] ebFEFZglxpSIxigLxRBFreLSebCDA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => dOsaTeFHGZLdISSDRxRMUftKBnTcA(), 
			ControllerType.Keyboard => new Controller[1] { VeTJUNkhWGQtgImKAkUWIjBIfRzCA }, 
			ControllerType.Mouse => new Controller[1] { mqsSoHwfAFQfvHOWEKMnmCxCSOMA }, 
			ControllerType.Custom => UxQpiyrLGaaabQqScYxqriUZuQyC(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] aoRDqItoKxIasmFabCIdQcibDmNC(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => qQnNcixYGlqMdriBgpXuVIsFSsxb(), 
			ControllerType.Keyboard => new string[1] { VeTJUNkhWGQtgImKAkUWIjBIfRzCA.name }, 
			ControllerType.Mouse => new string[1] { mqsSoHwfAFQfvHOWEKMnmCxCSOMA.name }, 
			ControllerType.Custom => bWPGfQTrLvAbZJlkfamZgaZdANCGB(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void aqgUnKWIiTAvsXXXJXLPGtXMGkmK(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.wKasYrvMczYUldqoKZRAbQdSPLxG(P_1, P_2, InputActionEventType.Update, null);
	}

	public void YzwDPDEulUeIbXAejJrihiSLIIBO(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.GEEQOJiOddPLKUrEaCzqncktpAVj(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void UQGGVGCaExJtHobIygHdGxtRBPwVA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_3);
		if (num >= 0)
		{
			YzwDPDEulUeIbXAejJrihiSLIIBO(P_0, P_1, P_2, num);
		}
	}

	public void CKQXkzqZatMhVaJsZoNfQAbaqqsL(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.wKasYrvMczYUldqoKZRAbQdSPLxG(P_1, P_2, P_3, P_4);
	}

	public void HjNWYhELCEqeUuEgJHbjwxflDMDj(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.GEEQOJiOddPLKUrEaCzqncktpAVj(P_1, P_2, P_3, P_4, P_5);
	}

	public void KYBwBcdxOlZvNIxyGAmmIKqQFYCE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			YDMacOWLsjSaVdAGjGApLeCGpTIC = true;
		}
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_4);
		if (num >= 0)
		{
			HjNWYhELCEqeUuEgJHbjwxflDMDj(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void GiFVsBvqhyrjWdkRKniMqBvidGbV(int P_0, Action<InputActionEventData> P_1)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.heiGzYotuBgUHMLuokWCNJFoQsHc(P_1);
	}

	public void GWnNWYxKppAtezaHLImqIPwgxhAoA(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.laZBFwhAUJiEdXiRYceCSwvKUGIeA(P_1, P_2);
	}

	public void dwPznqvAvbkGHSyRIXESzKubtIOK(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_2);
		if (num >= 0)
		{
			GWnNWYxKppAtezaHLImqIPwgxhAoA(P_0, P_1, num);
		}
	}

	public void wwlztUdzlQzFjtCgvPmExbspBaPe(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.zePRzIvQZHWyTVBgYINyDBdRXclc(P_1, P_2);
	}

	public void zYGimPQmaRBbmIhUQwXDpOcFrfAbb(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.opjdqTebTMptPGWAYFgxaQQjSVRZA(P_1, P_2);
	}

	public void XafEMybRlEZQvsFyfaDsUvIZusBd(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.gtLUndzKbIRAcYPFXdhXgkmyuOQC(P_1, P_2, P_3);
	}

	public void sFlfTfGReSFncXYgBOpogxPYrQTwA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_3);
		if (num >= 0)
		{
			XafEMybRlEZQvsFyfaDsUvIZusBd(P_0, P_1, P_2, num);
		}
	}

	public void xxUnDwoscGdfClXhNaxYIyiPvCDP(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.SiYsIRSVSpLzxXZJLbLqXnFkAAJBA(P_1, P_2, P_3);
	}

	public void iRDhOVEKMXRXfpbnQOMYZSsOzdle(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_3);
		if (num >= 0)
		{
			xxUnDwoscGdfClXhNaxYIyiPvCDP(P_0, P_1, P_2, num);
		}
	}

	public void fhjiMNgrypbwMRCfnzuKOQfKvTzv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.CWfKtmUxDjJeTOhlTsbWYiBSEVOF(P_1, P_2, P_3);
	}

	public void hOapnBVPvmJYrTZQBOxurcUDBdLv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.uqBHIcrfNCudZpVruNfnQdnacDpY(P_1, P_2, P_3, P_4);
	}

	public void BmRLwMEoApTEHIouHCyvHBIcvSHJA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH.dmYQlGLkZgonreWukheZbeHXtLFC(P_4);
		if (num >= 0)
		{
			hOapnBVPvmJYrTZQBOxurcUDBdLv(P_0, P_1, P_2, P_3, num);
		}
	}

	public void HwflNHcrppPpGiGoEcxjzBosIwUh(int P_0)
	{
		isuweknrNtneLljfjXnHFwUDLWFq(P_0)?.ZpkTOvlNFIGDxqziVygJQiZdffDN();
	}

	public bool qfpXhjfjlYYkePIpHDLQoLKWBrRh(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].IPBglEDiskLyDaFoCmNkHNTILvkoD())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].IPBglEDiskLyDaFoCmNkHNTILvkoD())
			{
				return true;
			}
		}
		return false;
	}

	public bool aLFewbsSRKTevbkDwJKnaUEoVhEF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].riuGhwaMOAdFGDFRYDzUUxYehYkQ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].riuGhwaMOAdFGDFRYDzUUxYehYkQ())
			{
				return true;
			}
		}
		return false;
	}

	public bool pDtbvuVIiYvWApoDKoxqfFNJzLoF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].bSwJemwUEXGGBhhqyxFRvLmWIqGY())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].bSwJemwUEXGGBhhqyxFRvLmWIqGY())
			{
				return true;
			}
		}
		return false;
	}

	public bool vwxyvUDOvuAmhVAeHauaKJLGtoDO(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].nEpMkgAlUKaHmxrXsfKeYHsLoBLs())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].nEpMkgAlUKaHmxrXsfKeYHsLoBLs())
			{
				return true;
			}
		}
		return false;
	}

	public bool nvalaqICANEbLAMkUCPeuioeDCAD(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].EVDaaHKwprBiqlvanCLDzZZcIJDp())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].EVDaaHKwprBiqlvanCLDzZZcIJDp())
			{
				return true;
			}
		}
		return false;
	}

	public bool sDFSvvrgLZVbOvNMdKQzsoxBDPQh(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].KhxBPpPiOXgSvGNtPRGOvHsskrZq())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].KhxBPpPiOXgSvGNtPRGOvHsskrZq())
			{
				return true;
			}
		}
		return false;
	}

	public bool yJpVtbiNHVKuWuwrhrneCQbIDpps(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].BljscRLzpNviyYundTExtmvpLKYc())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].BljscRLzpNviyYundTExtmvpLKYc())
			{
				return true;
			}
		}
		return false;
	}

	public bool PsezMEgvboHOLnQudCEJXuFTNgKA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < DOZbHhiJhwcrxPLodvipogkjiBzp.Length; i++)
			{
				if (DOZbHhiJhwcrxPLodvipogkjiBzp[i].wmkdKpTjlGQnDOmTMMrTrHwnIdMn())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			return false;
		}
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		for (int j = 0; j < num; j++)
		{
			if (AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_0, j].wmkdKpTjlGQnDOmTMMrTrHwnIdMn())
			{
				return true;
			}
		}
		return false;
	}

	public bool KNEyiQrUUmKSHvMcOwNcDbQFazvE()
	{
		if (!fkMqkhpvJGEboEYUBJoXUXqlVqwq(mqsSoHwfAFQfvHOWEKMnmCxCSOMA) && !ZRdGFNfzfQPpayjdbTPFFAIjIHAiA(NDpJxXvYCNJKoqMFUImLtdUmdfVZ) && !fkMqkhpvJGEboEYUBJoXUXqlVqwq(VeTJUNkhWGQtgImKAkUWIjBIfRzCA))
		{
			return ZRdGFNfzfQPpayjdbTPFFAIjIHAiA(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		}
		return true;
	}

	public bool zwppiviaMutHRVTmCrXnUryKgAYv(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ZRdGFNfzfQPpayjdbTPFFAIjIHAiA(NDpJxXvYCNJKoqMFUImLtdUmdfVZ), 
			ControllerType.Keyboard => fkMqkhpvJGEboEYUBJoXUXqlVqwq(VeTJUNkhWGQtgImKAkUWIjBIfRzCA), 
			ControllerType.Mouse => fkMqkhpvJGEboEYUBJoXUXqlVqwq(mqsSoHwfAFQfvHOWEKMnmCxCSOMA), 
			ControllerType.Custom => ZRdGFNfzfQPpayjdbTPFFAIjIHAiA(RLchXLhEDVIYNGMlqENNIPqfAXbnB), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool tCBSElNbGWwRoCZdSkntGCmrPqAw()
	{
		if (!xbYuwQNCFBLMWoXQDMNCbVxeAQUv(mqsSoHwfAFQfvHOWEKMnmCxCSOMA) && !pjoHvDYADYhuKHnYlIYTfWuhJCtmb(NDpJxXvYCNJKoqMFUImLtdUmdfVZ) && !xbYuwQNCFBLMWoXQDMNCbVxeAQUv(VeTJUNkhWGQtgImKAkUWIjBIfRzCA))
		{
			return pjoHvDYADYhuKHnYlIYTfWuhJCtmb(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		}
		return true;
	}

	public bool mwyjsYMBUAxpMyGDSzZOpAaLEoGF(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => pjoHvDYADYhuKHnYlIYTfWuhJCtmb(NDpJxXvYCNJKoqMFUImLtdUmdfVZ), 
			ControllerType.Keyboard => xbYuwQNCFBLMWoXQDMNCbVxeAQUv(VeTJUNkhWGQtgImKAkUWIjBIfRzCA), 
			ControllerType.Mouse => xbYuwQNCFBLMWoXQDMNCbVxeAQUv(mqsSoHwfAFQfvHOWEKMnmCxCSOMA), 
			ControllerType.Custom => pjoHvDYADYhuKHnYlIYTfWuhJCtmb(RLchXLhEDVIYNGMlqENNIPqfAXbnB), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool MRlweYAfzwKdHzFZAGbXjYtjnoBMA()
	{
		if (!jUmxHNkSZYsBHGZUKXUHNUUXWgYd(mqsSoHwfAFQfvHOWEKMnmCxCSOMA) && !KjwGydjEzOjubkTfzPIQaulxFsri(NDpJxXvYCNJKoqMFUImLtdUmdfVZ) && !jUmxHNkSZYsBHGZUKXUHNUUXWgYd(VeTJUNkhWGQtgImKAkUWIjBIfRzCA))
		{
			return KjwGydjEzOjubkTfzPIQaulxFsri(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		}
		return true;
	}

	public bool mcMdqzINIWUBqQMUmotPDTjbaErM(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => KjwGydjEzOjubkTfzPIQaulxFsri(NDpJxXvYCNJKoqMFUImLtdUmdfVZ), 
			ControllerType.Keyboard => jUmxHNkSZYsBHGZUKXUHNUUXWgYd(VeTJUNkhWGQtgImKAkUWIjBIfRzCA), 
			ControllerType.Mouse => jUmxHNkSZYsBHGZUKXUHNUUXWgYd(mqsSoHwfAFQfvHOWEKMnmCxCSOMA), 
			ControllerType.Custom => KjwGydjEzOjubkTfzPIQaulxFsri(RLchXLhEDVIYNGMlqENNIPqfAXbnB), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool JJLJgXGHvBzWzINHmwSxSHdPBDhW()
	{
		if (!BprYmmgRHPLwhcyDvxjHObKKpIKA(mqsSoHwfAFQfvHOWEKMnmCxCSOMA) && !vwSHGUjjfxCaxklfEtPDAIaKviTPA(NDpJxXvYCNJKoqMFUImLtdUmdfVZ) && !BprYmmgRHPLwhcyDvxjHObKKpIKA(VeTJUNkhWGQtgImKAkUWIjBIfRzCA))
		{
			return vwSHGUjjfxCaxklfEtPDAIaKviTPA(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		}
		return true;
	}

	public bool YfxBSLAJCUpAiqfWwcAksvFnohzY(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => vwSHGUjjfxCaxklfEtPDAIaKviTPA(NDpJxXvYCNJKoqMFUImLtdUmdfVZ), 
			ControllerType.Keyboard => BprYmmgRHPLwhcyDvxjHObKKpIKA(VeTJUNkhWGQtgImKAkUWIjBIfRzCA), 
			ControllerType.Mouse => BprYmmgRHPLwhcyDvxjHObKKpIKA(mqsSoHwfAFQfvHOWEKMnmCxCSOMA), 
			ControllerType.Custom => vwSHGUjjfxCaxklfEtPDAIaKviTPA(RLchXLhEDVIYNGMlqENNIPqfAXbnB), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool kFrfUrGAVJRZeFuuvCBNhkJnKFEO()
	{
		if (!yakAmvbpODAxycqCXSBIcLmiYzYwB(mqsSoHwfAFQfvHOWEKMnmCxCSOMA) && !CXlMGXeYZUuPTrfmDxFuKHCYbEvd(NDpJxXvYCNJKoqMFUImLtdUmdfVZ) && !yakAmvbpODAxycqCXSBIcLmiYzYwB(VeTJUNkhWGQtgImKAkUWIjBIfRzCA))
		{
			return CXlMGXeYZUuPTrfmDxFuKHCYbEvd(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		}
		return true;
	}

	public bool huZqQwFDCTHlbjpfeOSBkGXnooOL(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => CXlMGXeYZUuPTrfmDxFuKHCYbEvd(NDpJxXvYCNJKoqMFUImLtdUmdfVZ), 
			ControllerType.Keyboard => yakAmvbpODAxycqCXSBIcLmiYzYwB(VeTJUNkhWGQtgImKAkUWIjBIfRzCA), 
			ControllerType.Mouse => yakAmvbpODAxycqCXSBIcLmiYzYwB(mqsSoHwfAFQfvHOWEKMnmCxCSOMA), 
			ControllerType.Custom => CXlMGXeYZUuPTrfmDxFuKHCYbEvd(RLchXLhEDVIYNGMlqENNIPqfAXbnB), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool ZRdGFNfzfQPpayjdbTPFFAIjIHAiA<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	private bool fkMqkhpvJGEboEYUBJoXUXqlVqwq(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool pjoHvDYADYhuKHnYlIYTfWuhJCtmb<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	private bool xbYuwQNCFBLMWoXQDMNCbVxeAQUv(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool KjwGydjEzOjubkTfzPIQaulxFsri<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	private bool jUmxHNkSZYsBHGZUKXUHNUUXWgYd(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool vwSHGUjjfxCaxklfEtPDAIaKviTPA<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	private bool BprYmmgRHPLwhcyDvxjHObKKpIKA(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool CXlMGXeYZUuPTrfmDxFuKHCYbEvd<_0001>(IList<_0001> P_0) where _0001 : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			_0001 val = P_0[i];
			if (val != null && val.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	private bool yakAmvbpODAxycqCXSBIcLmiYzYwB(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller HtLGncGfefHXdaZjvhJIvDPtklQrA()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(mqsSoHwfAFQfvHOWEKMnmCxCSOMA, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(VeTJUNkhWGQtgImKAkUWIjBIfRzCA, ref lastController, ref lastTime);
		IList<Joystick> nDpJxXvYCNJKoqMFUImLtdUmdfVZ = NDpJxXvYCNJKoqMFUImLtdUmdfVZ;
		for (int i = 0; i < eoBdhxXkFRcCpTZAvInYZHzHfdAP; i++)
		{
			InputTools.CompareLastActiveController(nDpJxXvYCNJKoqMFUImLtdUmdfVZ[i], ref lastController, ref lastTime);
		}
		IList<CustomController> rLchXLhEDVIYNGMlqENNIPqfAXbnB = RLchXLhEDVIYNGMlqENNIPqfAXbnB;
		for (int j = 0; j < PsjwTZKfSMplrvqshESSZRCHWDSx; j++)
		{
			InputTools.CompareLastActiveController(rLchXLhEDVIYNGMlqENNIPqfAXbnB[j], ref lastController, ref lastTime);
		}
		if (AtFDzVIdHHkHTNzdcbhTqbRDageo >= 0)
		{
			Controller controller = DFkLoOraYKZxPsJxXLcjqacSAAGg(NHloQSKQJbfoEfrOqmMrVXlhoGov, AtFDzVIdHHkHTNzdcbhTqbRDageo);
			if (controller != null && FXcOGDiDkhrzMVWjsusqZLzLYPvt >= lastTime)
			{
				lastController = controller;
				lastTime = FXcOGDiDkhrzMVWjsusqZLzLYPvt;
			}
		}
		if (lastController == null)
		{
			lastController = VeTJUNkhWGQtgImKAkUWIjBIfRzCA;
		}
		return lastController;
	}

	public Controller lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(NDpJxXvYCNJKoqMFUImLtdUmdfVZ[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return IeYgCxBcbnFZhKaxGJMqKHnEVRHi;
		case ControllerType.Mouse:
			return QRdffiyBXZIwyIaPCjnZBUdIBmik;
		case ControllerType.Custom:
		{
			int count = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(RLchXLhEDVIYNGMlqENNIPqfAXbnB[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		if (AtFDzVIdHHkHTNzdcbhTqbRDageo >= 0 && P_0 == NHloQSKQJbfoEfrOqmMrVXlhoGov)
		{
			Controller controller = DFkLoOraYKZxPsJxXLcjqacSAAGg(NHloQSKQJbfoEfrOqmMrVXlhoGov, AtFDzVIdHHkHTNzdcbhTqbRDageo);
			if (controller != null && FXcOGDiDkhrzMVWjsusqZLzLYPvt >= lastTime)
			{
				lastController = controller;
				lastTime = FXcOGDiDkhrzMVWjsusqZLzLYPvt;
			}
		}
		return lastController;
	}

	public _0001 HtLGncGfefHXdaZjvhJIvDPtklQrA<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType btFlqWrcTtUpdTMuRDtjFfxPQeDBA()
	{
		return HtLGncGfefHXdaZjvhJIvDPtklQrA()?.type ?? ControllerType.Keyboard;
	}

	public bool UamZCAbGkJIHLNomaeJGYFVSPclP(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!rpeuwfhEvCHBTxrQcBajZcISmATE.Contains(P_0))
		{
			return false;
		}
		AtFDzVIdHHkHTNzdcbhTqbRDageo = P_0.id;
		NHloQSKQJbfoEfrOqmMrVXlhoGov = P_0.type;
		FXcOGDiDkhrzMVWjsusqZLzLYPvt = ReInput.unscaledTime;
		return true;
	}

	public void tYFPBPHPJijfDCAXIZBksPRBEcakA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			MNhnzyuPQrjhAchEBlQeFmMUGgDt = true;
			QZuraXLFXOAHWfhAeEPfIIjVjjsuA.IkvKhlgZmStkvhePhwGieSeDuGpi(P_0);
		}
	}

	public void PtgppDVJLkEuShCeWVhcZfiUcMep(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			MNhnzyuPQrjhAchEBlQeFmMUGgDt = true;
			QZuraXLFXOAHWfhAeEPfIIjVjjsuA.RsydjPMaQILtCEvOGppKRGPDtram(P_0, P_1);
		}
	}

	public void GjmcroDwJuLcfTGGIByTIhhTCZpt(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			QZuraXLFXOAHWfhAeEPfIIjVjjsuA.hSnWFMKIUYonyQaQgEzilBEKNeSf(P_0);
		}
	}

	public void FcUABuVVEPvfaBaCfGYtvwyEnULy(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			QZuraXLFXOAHWfhAeEPfIIjVjjsuA.uYynjEtosEUFHRqnohnXuCsLzxCv(P_0, P_1);
		}
	}

	public void dhZwBQxnEWxHNvsKCdYOrBeaFChm()
	{
		QZuraXLFXOAHWfhAeEPfIIjVjjsuA.bLXcnobWntAWKhHBYgNsmWXyUHY();
	}

	public void VWYqmbYHyEBrPpqrhBLhPKemXtFk(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			lAwJiIgBYugXKvRMfCmKGZOLscLvA.IkvKhlgZmStkvhePhwGieSeDuGpi(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)tvycUiUCWjWtUfnymFXWFQPOoBobA)
			{
				return;
			}
			bEalUNMbBgUkQrkuDUhNLHjBJFvq[P_0].IkvKhlgZmStkvhePhwGieSeDuGpi(P_1);
		}
		MNhnzyuPQrjhAchEBlQeFmMUGgDt = true;
	}

	public void cqtWpxzNeUbCSyXVLBSdrJULliPJ(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			lAwJiIgBYugXKvRMfCmKGZOLscLvA.RsydjPMaQILtCEvOGppKRGPDtram(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)tvycUiUCWjWtUfnymFXWFQPOoBobA)
			{
				return;
			}
			bEalUNMbBgUkQrkuDUhNLHjBJFvq[P_0].RsydjPMaQILtCEvOGppKRGPDtram(P_1, P_2);
		}
		MNhnzyuPQrjhAchEBlQeFmMUGgDt = true;
	}

	public void MlBBuxyQfgImUapsxiiUPTMAfRogb(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				lAwJiIgBYugXKvRMfCmKGZOLscLvA.hSnWFMKIUYonyQaQgEzilBEKNeSf(P_1);
			}
			else if ((uint)P_0 < (uint)tvycUiUCWjWtUfnymFXWFQPOoBobA)
			{
				bEalUNMbBgUkQrkuDUhNLHjBJFvq[P_0].hSnWFMKIUYonyQaQgEzilBEKNeSf(P_1);
			}
		}
	}

	public void ClYlSTVINRFNWmcAUSIVxMhfIDUE(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				lAwJiIgBYugXKvRMfCmKGZOLscLvA.uYynjEtosEUFHRqnohnXuCsLzxCv(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)tvycUiUCWjWtUfnymFXWFQPOoBobA)
			{
				bEalUNMbBgUkQrkuDUhNLHjBJFvq[P_0].uYynjEtosEUFHRqnohnXuCsLzxCv(P_1, P_2);
			}
		}
	}

	public void TbDOVSvIGUfMKFibPbaiyLktppFr(int P_0)
	{
		if (P_0 == 9999999)
		{
			lAwJiIgBYugXKvRMfCmKGZOLscLvA.bLXcnobWntAWKhHBYgNsmWXyUHY();
		}
		else if ((uint)P_0 < (uint)tvycUiUCWjWtUfnymFXWFQPOoBobA)
		{
			bEalUNMbBgUkQrkuDUhNLHjBJFvq[P_0].bLXcnobWntAWKhHBYgNsmWXyUHY();
		}
	}

	private void UvGAFSChEmJAKLoasHgJZRlqQUMhA()
	{
		if (QZuraXLFXOAHWfhAeEPfIIjVjjsuA.UAbRRvIJlewrujzBDmegiAuyjqix > 0)
		{
			QZuraXLFXOAHWfhAeEPfIIjVjjsuA.IgTclfFhEholAoMYmVaMulkKZXje(-1, HtLGncGfefHXdaZjvhJIvDPtklQrA(), lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Joystick), lDhhoxieuhVAsUlmNcwvjgDbdIZOA(ControllerType.Custom));
		}
		if (lAwJiIgBYugXKvRMfCmKGZOLscLvA.UAbRRvIJlewrujzBDmegiAuyjqix > 0)
		{
			Player.ControllerHelper controllers = phradCjIejilCZpqeYSnYsWjgoKV.JnxxdHKLKTWWOGpjgTpkAKLMeRjbA().controllers;
			lAwJiIgBYugXKvRMfCmKGZOLscLvA.IgTclfFhEholAoMYmVaMulkKZXje(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < tvycUiUCWjWtUfnymFXWFQPOoBobA; i++)
		{
			if (bEalUNMbBgUkQrkuDUhNLHjBJFvq[i].UAbRRvIJlewrujzBDmegiAuyjqix != 0)
			{
				Player.ControllerHelper controllers2 = phradCjIejilCZpqeYSnYsWjgoKV.OmYguzUKrHvxxCFFPKBkcRLCHHsW[i].controllers;
				bEalUNMbBgUkQrkuDUhNLHjBJFvq[i].IgTclfFhEholAoMYmVaMulkKZXje(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void mNjEcwFTnkaBTFqIwMvHIyLmSqGQ(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count; i++)
		{
			if (NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i] != null)
			{
				NXgFrXBoFFxRmMVkGlDdoelRlbjG(NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i], P_0);
			}
		}
		for (int j = 0; j < yTpjvNKBTrHDbltzcbPsiAcoWLAS.Count; j++)
		{
			if (yTpjvNKBTrHDbltzcbPsiAcoWLAS[j] != null)
			{
				NXgFrXBoFFxRmMVkGlDdoelRlbjG(yTpjvNKBTrHDbltzcbPsiAcoWLAS[j], P_0);
			}
		}
		for (int k = 0; k < PsjwTZKfSMplrvqshESSZRCHWDSx; k++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[k] != null)
			{
				NXgFrXBoFFxRmMVkGlDdoelRlbjG(RLchXLhEDVIYNGMlqENNIPqfAXbnB[k], P_0);
			}
		}
		NXgFrXBoFFxRmMVkGlDdoelRlbjG(mqsSoHwfAFQfvHOWEKMnmCxCSOMA, P_0);
	}

	private void NXgFrXBoFFxRmMVkGlDdoelRlbjG(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].aWgdabdFXKHTbUDLyoVfrwOlgFah._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> HjnXZsHhoQJsVuLwTSdQAZgWfLUA<_0001>() where _0001 : IControllerTemplate
	{
		return xaScHozvHVICKvVRXEZMbeaVXWKw.MHQnzUbHMBcCPeeKTudObjnLDeRbA<_0001>();
	}

	private void DePSpmalxHDjxSmJCVcijTKXWbPx(List<InputBehavior> P_0)
	{
		urFYgHdkvFdZTPSaFnxtLXEOKfxh = ReInput.puvsCcoEkpSrGAnbdVqxjXrCengH;
		phradCjIejilCZpqeYSnYsWjgoKV = ReInput.BmmzPGNuZrdZxdhYqgOOCPaOiRrkA;
		NDpJxXvYCNJKoqMFUImLtdUmdfVZ = new List<Joystick>();
		yTpjvNKBTrHDbltzcbPsiAcoWLAS = new List<Joystick>();
		RLchXLhEDVIYNGMlqENNIPqfAXbnB = new List<CustomController>();
		WCpCZGaOkzjvLaxicsgmVVHMfmfFA = urFYgHdkvFdZTPSaFnxtLXEOKfxh.bckRRJzTFliiXHIVPBVFqqmIRafV;
		tvycUiUCWjWtUfnymFXWFQPOoBobA = phradCjIejilCZpqeYSnYsWjgoKV.KAOhRVBrBYwCtoNeiOpilaTceGbbA;
		USrczUEkeGoUPSajfDuXgRTCzMwd = FLOhbNVGhSZKtIcIYdEjMvmpGqRy;
		UbDLYxdTlBFtuFFSJpcKCeymTTX = 0;
		WRmcYAMzhmVnAEBESiLPiygmfwVN = new ADictionary<int, WGVvleyUXWCSakxunjhDGfCKHEdv>();
		WRmcYAMzhmVnAEBESiLPiygmfwVN.Add(ReInput.players.GetSystemPlayer().id, new WGVvleyUXWCSakxunjhDGfCKHEdv(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			WRmcYAMzhmVnAEBESiLPiygmfwVN.Add(players[i].id, new WGVvleyUXWCSakxunjhDGfCKHEdv(P_0));
		}
		muxTPmvljubzzhGgsBklwPiPrReZ = new ReadOnlyCollection<Joystick>(NDpJxXvYCNJKoqMFUImLtdUmdfVZ);
		sTLdXxADNjHSdavcaNdzdnuiHdEiD = new ReadOnlyCollection<CustomController>(RLchXLhEDVIYNGMlqENNIPqfAXbnB);
		lXvJAREcFJqTwbpbVaXyWnOsESQEA.NMlkFRMJiiZMLehFQWHoGfTcSKQH(YnQhHMyrwNsdCEdnMllCGgLHAHbdA);
		mZGdPfvcATxNBHWYQHHfKlJoXfnH = new lXvJAREcFJqTwbpbVaXyWnOsESQEA[(tvycUiUCWjWtUfnymFXWFQPOoBobA + 1) * WCpCZGaOkzjvLaxicsgmVVHMfmfFA];
		int num = 0;
		DOZbHhiJhwcrxPLodvipogkjiBzp = new lXvJAREcFJqTwbpbVaXyWnOsESQEA[WCpCZGaOkzjvLaxicsgmVVHMfmfFA];
		for (int j = 0; j < WCpCZGaOkzjvLaxicsgmVVHMfmfFA; j++)
		{
			InputAction inputAction = urFYgHdkvFdZTPSaFnxtLXEOKfxh.uqYYtgClUWJVgNOIYRTOBfbTgekg(j);
			InputBehavior inputBehavior = WRmcYAMzhmVnAEBESiLPiygmfwVN[9999999].hUZELacbBZryGxYILgAGdQnTPXQQA(inputAction.behaviorId);
			lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = new lXvJAREcFJqTwbpbVaXyWnOsESQEA(9999999, inputAction, inputBehavior, YnQhHMyrwNsdCEdnMllCGgLHAHbdA);
			DOZbHhiJhwcrxPLodvipogkjiBzp[j] = lXvJAREcFJqTwbpbVaXyWnOsESQEA2;
			mZGdPfvcATxNBHWYQHHfKlJoXfnH[num] = lXvJAREcFJqTwbpbVaXyWnOsESQEA2;
			num++;
		}
		AfMlgkFJZonAXTZfgguNfwpxiUBQ = new lXvJAREcFJqTwbpbVaXyWnOsESQEA[tvycUiUCWjWtUfnymFXWFQPOoBobA, WCpCZGaOkzjvLaxicsgmVVHMfmfFA];
		for (int k = 0; k < tvycUiUCWjWtUfnymFXWFQPOoBobA; k++)
		{
			for (int l = 0; l < WCpCZGaOkzjvLaxicsgmVVHMfmfFA; l++)
			{
				InputAction inputAction2 = urFYgHdkvFdZTPSaFnxtLXEOKfxh.uqYYtgClUWJVgNOIYRTOBfbTgekg(l);
				InputBehavior inputBehavior2 = WRmcYAMzhmVnAEBESiLPiygmfwVN[players[k].id].hUZELacbBZryGxYILgAGdQnTPXQQA(inputAction2.behaviorId);
				lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA3 = new lXvJAREcFJqTwbpbVaXyWnOsESQEA(k, inputAction2, inputBehavior2, YnQhHMyrwNsdCEdnMllCGgLHAHbdA);
				AfMlgkFJZonAXTZfgguNfwpxiUBQ[k, l] = lXvJAREcFJqTwbpbVaXyWnOsESQEA3;
				mZGdPfvcATxNBHWYQHHfKlJoXfnH[num] = lXvJAREcFJqTwbpbVaXyWnOsESQEA3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.CqaNhCrdUVQUcSQVbyoNlYtceigM;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < list.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = list[m].startingCustomControllers;
			if (startingCustomControllers == null)
			{
				continue;
			}
			for (int n = 0; n < startingCustomControllers.Count; n++)
			{
				CustomController customController = NprxOsPQZmIODMrEVTJSdqAawKNH(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					phradCjIejilCZpqeYSnYsWjgoKV.SsVuigQhQtABwxcDHPRhTnSsVBJh(num2)?.controllers.tUpQztgzMvrGeWQbWPjNmBYocgiw(customController, false);
				}
			}
		}
		bFRDjOFzDfLHmRXUOpUYXTzWbmnd = new XAxeWKBTpmhGlemygQQKqbyPshCG();
		pFfzhhhyjLERhYQzduDfzyzMoHHw = new XAxeWKBTpmhGlemygQQKqbyPshCG[tvycUiUCWjWtUfnymFXWFQPOoBobA];
		for (int num3 = 0; num3 < tvycUiUCWjWtUfnymFXWFQPOoBobA; num3++)
		{
			pFfzhhhyjLERhYQzduDfzyzMoHHw[num3] = new XAxeWKBTpmhGlemygQQKqbyPshCG();
		}
		QZuraXLFXOAHWfhAeEPfIIjVjjsuA = new global::vVEPpXcualaRdQEuiaXKpUBZsyXv<ActiveControllerChangedDelegate>();
		lAwJiIgBYugXKvRMfCmKGZOLscLvA = new global::vVEPpXcualaRdQEuiaXKpUBZsyXv<PlayerActiveControllerChangedDelegate>();
		bEalUNMbBgUkQrkuDUhNLHjBJFvq = new global::vVEPpXcualaRdQEuiaXKpUBZsyXv<PlayerActiveControllerChangedDelegate>[phradCjIejilCZpqeYSnYsWjgoKV.KAOhRVBrBYwCtoNeiOpilaTceGbbA];
		ArrayTools.Populate(bEalUNMbBgUkQrkuDUhNLHjBJFvq);
	}

	private void dnEYVTCqJGEvGSZANifWsWYbOPlP(UpdateLoopType P_0)
	{
		int count = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i];
			if (joystick.enabled)
			{
				jsuSHBjzKIBbMNyOnhOAgkcxOLSB(joystick.YHQQnmlLemgNtqWLdALHczyIyJWBA, joystick.vAJlxjrsCepUBGzroHjWcArmXQkU);
				joystick.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
			}
		}
		if (VeTJUNkhWGQtgImKAkUWIjBIfRzCA.enabled)
		{
			VeTJUNkhWGQtgImKAkUWIjBIfRzCA.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
		}
		else if (NGpLNVKggcvARAERXxtqupGFcryD)
		{
			VeTJUNkhWGQtgImKAkUWIjBIfRzCA.BnDgWknNlTdmzTWfhXkCAbHeAmuQ(P_0);
		}
		if (mqsSoHwfAFQfvHOWEKMnmCxCSOMA.enabled)
		{
			mqsSoHwfAFQfvHOWEKMnmCxCSOMA.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
		}
		int count2 = RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = RLchXLhEDVIYNGMlqENNIPqfAXbnB[j];
			if (customController.enabled)
			{
				customController.tiVXVcOoctHMEhKKWwEDjvyLJHQxA();
				customController.SSAuafxQNvPbHvrzmnbTGwbAWFNW(P_0);
			}
		}
	}

	private void PgZfpjZNLTiaxJhDxCFADsVrGEOR(UpdateLoopType P_0)
	{
		lXvJAREcFJqTwbpbVaXyWnOsESQEA.rhfsIOZgFjqJHGaUKluSvUSDtwff(P_0);
		Player[] array = phradCjIejilCZpqeYSnYsWjgoKV.JAvTLYlvaBhSZQAuqeeozNmITTyT;
		int num = array.Length;
		bool enabled = VeTJUNkhWGQtgImKAkUWIjBIfRzCA.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = array[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						IzgcdwmeJbFTTATvDAQJSsIuCjsib.EsBeoLbmYUztEahrlZfOLFnjFYuhA(maps[j]);
					}
				}
			}
		}
		bool enabled2 = mqsSoHwfAFQfvHOWEKMnmCxCSOMA.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.mYjFmbIOwNlJfBZCXYiXsgDEiXdd(USrczUEkeGoUPSajfDuXgRTCzMwd);
			if (enabled || NGpLNVKggcvARAERXxtqupGFcryD)
			{
				controllers.FMVuajrXjATxmmToWcysWcqOCVMeA(VeTJUNkhWGQtgImKAkUWIjBIfRzCA, IzgcdwmeJbFTTATvDAQJSsIuCjsib, USrczUEkeGoUPSajfDuXgRTCzMwd);
			}
			if (enabled2)
			{
				controllers.PoZFjRDtojkUvqrMFOxsMSKfKyFE(mqsSoHwfAFQfvHOWEKMnmCxCSOMA, USrczUEkeGoUPSajfDuXgRTCzMwd);
			}
			controllers.BCNHLDCvTkkKgrheRTuBozLwyWVp(USrczUEkeGoUPSajfDuXgRTCzMwd);
		}
		for (int l = 0; l < mZGdPfvcATxNBHWYQHHfKlJoXfnH.Length; l++)
		{
			if (mZGdPfvcATxNBHWYQHHfKlJoXfnH[l].DQvudLTsOmnvZgNOnemtHoScpAHLA != lXvJAREcFJqTwbpbVaXyWnOsESQEA.SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled)
			{
				mZGdPfvcATxNBHWYQHHfKlJoXfnH[l].JvrOmaaEiOtVPDHhZJADKqjIcAXH();
			}
		}
		lXvJAREcFJqTwbpbVaXyWnOsESQEA.nixqjcAcHwIpmyRKZsjmytSNcSUl();
		if (!YDMacOWLsjSaVdAGjGApLeCGpTIC)
		{
			return;
		}
		if (bFRDjOFzDfLHmRXUOpUYXTzWbmnd.uskholhiOMnSsgUISoyhlEFbhHiAA > 0)
		{
			for (int m = 0; m < WCpCZGaOkzjvLaxicsgmVVHMfmfFA; m++)
			{
				lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA2 = DOZbHhiJhwcrxPLodvipogkjiBzp[m];
				if (lXvJAREcFJqTwbpbVaXyWnOsESQEA2.DQvudLTsOmnvZgNOnemtHoScpAHLA != lXvJAREcFJqTwbpbVaXyWnOsESQEA.SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled)
				{
					bFRDjOFzDfLHmRXUOpUYXTzWbmnd.tHceBCiJjxseLCuiHLSFjdEbjpnAb(lXvJAREcFJqTwbpbVaXyWnOsESQEA2, P_0);
				}
			}
		}
		for (int n = 0; n < tvycUiUCWjWtUfnymFXWFQPOoBobA; n++)
		{
			XAxeWKBTpmhGlemygQQKqbyPshCG xAxeWKBTpmhGlemygQQKqbyPshCG = pFfzhhhyjLERhYQzduDfzyzMoHHw[n];
			if (xAxeWKBTpmhGlemygQQKqbyPshCG.uskholhiOMnSsgUISoyhlEFbhHiAA == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < WCpCZGaOkzjvLaxicsgmVVHMfmfFA; num2++)
			{
				lXvJAREcFJqTwbpbVaXyWnOsESQEA lXvJAREcFJqTwbpbVaXyWnOsESQEA3 = AfMlgkFJZonAXTZfgguNfwpxiUBQ[n, num2];
				if (lXvJAREcFJqTwbpbVaXyWnOsESQEA3.DQvudLTsOmnvZgNOnemtHoScpAHLA != lXvJAREcFJqTwbpbVaXyWnOsESQEA.SNwohbMULvtsqCoYLGoptSyIlJqI.Disabled)
				{
					xAxeWKBTpmhGlemygQQKqbyPshCG.tHceBCiJjxseLCuiHLSFjdEbjpnAb(lXvJAREcFJqTwbpbVaXyWnOsESQEA3, P_0);
				}
			}
		}
	}

	private void FLOhbNVGhSZKtIcIYdEjMvmpGqRy(bool P_0, int P_1, int P_2)
	{
		int num = urFYgHdkvFdZTPSaFnxtLXEOKfxh.JhlDaGJYzfnrxwSiGQiEnISqUoWv(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				DOZbHhiJhwcrxPLodvipogkjiBzp[num].yIrELBjsOnHeYGHAADOiWSZOtwEiB(P_0);
			}
			else
			{
				AfMlgkFJZonAXTZfgguNfwpxiUBQ[P_1, num].yIrELBjsOnHeYGHAADOiWSZOtwEiB(P_0);
			}
		}
	}

	private void iWQLhXRgKNCwEXbOsanTCMUVtpvwA(BridgedController P_0)
	{
		int num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0.sourceJoystick.rewiredId, RIXubQImtmFJkURJgcapIjbkAuxoA.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = OmVUAmJBSQrkfqnizgiCwmICkSDU(P_0.sourceJoystick.rewiredId, RIXubQImtmFJkURJgcapIjbkAuxoA.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = yTpjvNKBTrHDbltzcbPsiAcoWLAS[num];
			yTpjvNKBTrHDbltzcbPsiAcoWLAS.RemoveAt(num);
			joystick.KewBnJhzvfHEwUjrZjkQaAjlCPMbA(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Add(joystick);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Add(joystick);
		NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Sort(Joystick.fIMgGJVXnVEjrEUWSYjsiYRorXVmA);
		xaScHozvHVICKvVRXEZMbeaVXWKw.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(joystick);
	}

	private void dsuozhsoCLPPuYiZGNbIQGaINAFA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = NDpJxXvYCNJKoqMFUImLtdUmdfVZ[P_0];
		joystick.isConnected = false;
		if (eUtiKNUBhYdHtjAEBLbUlMSPfOobA != null)
		{
			eUtiKNUBhYdHtjAEBLbUlMSPfOobA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (OdlOyoYfbFpSeqEEkpyKtammkaWh != null)
		{
			OdlOyoYfbFpSeqEEkpyKtammkaWh(joystick.type, joystick.id);
		}
		NDpJxXvYCNJKoqMFUImLtdUmdfVZ.RemoveAt(P_0);
		yTpjvNKBTrHDbltzcbPsiAcoWLAS.Add(joystick);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Remove(joystick);
		xaScHozvHVICKvVRXEZMbeaVXWKw.XwKsqBusctndNwTHULgAVhQaVOrh(joystick);
		joystick.ufAgwGoHxawiKAxEmPcnTrGkJWTF();
	}

	private void uIGChhnCAiVRKkRCRoLmaoctaXov()
	{
		for (int num = NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count - 1; num >= 0; num--)
		{
			dsuozhsoCLPPuYiZGNbIQGaINAFA(num);
		}
	}

	private bool PdLAcdSRcngjhOPdcUcocfpXDIZX(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count; i++)
		{
			if (RLchXLhEDVIYNGMlqENNIPqfAXbnB[i] == P_0)
			{
				return true;
			}
		}
		RLchXLhEDVIYNGMlqENNIPqfAXbnB.Add(P_0);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Add(P_0);
		xaScHozvHVICKvVRXEZMbeaVXWKw.sepIsMCbMHhyQkEJtNDWjuEZmYMBA(P_0);
		return true;
	}

	private bool NhbseXKpsIEmWEirsomWOfKwFFpCb(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		xaScHozvHVICKvVRXEZMbeaVXWKw.XwKsqBusctndNwTHULgAVhQaVOrh(P_0);
		rpeuwfhEvCHBTxrQcBajZcISmATE.Remove(P_0);
		return RLchXLhEDVIYNGMlqENNIPqfAXbnB.Remove(P_0);
	}

	private XAxeWKBTpmhGlemygQQKqbyPshCG isuweknrNtneLljfjXnHFwUDLWFq(int P_0)
	{
		if (P_0 == 9999999)
		{
			return bFRDjOFzDfLHmRXUOpUYXTzWbmnd;
		}
		if (P_0 < 0 || P_0 >= ReInput.BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.KAOhRVBrBYwCtoNeiOpilaTceGbbA)
		{
			return null;
		}
		return pFfzhhhyjLERhYQzduDfzyzMoHHw[P_0];
	}

	private void NpxgeOufoiISagUPhlgNdSqihwvB(bool P_0)
	{
		if (!P_0)
		{
			IzgcdwmeJbFTTATvDAQJSsIuCjsib.gKONPLUsedyHqxfnAohSzTqtkBhk();
		}
	}

	private void XVCRvgTPSTdVzoAvCQFttZfKoDLE(bool P_0)
	{
		VeTJUNkhWGQtgImKAkUWIjBIfRzCA.ynvWXRFBEHELOcvmGFbfaRmNjJwMA(P_0);
		mqsSoHwfAFQfvHOWEKMnmCxCSOMA.ynvWXRFBEHELOcvmGFbfaRmNjJwMA(P_0);
		for (int i = 0; i < NDpJxXvYCNJKoqMFUImLtdUmdfVZ.Count; i++)
		{
			NDpJxXvYCNJKoqMFUImLtdUmdfVZ[i].ynvWXRFBEHELOcvmGFbfaRmNjJwMA(P_0);
		}
		for (int j = 0; j < RLchXLhEDVIYNGMlqENNIPqfAXbnB.Count; j++)
		{
			RLchXLhEDVIYNGMlqENNIPqfAXbnB[j].ynvWXRFBEHELOcvmGFbfaRmNjJwMA(P_0);
		}
	}

	public void Dispose()
	{
		prefNzJKrvxkSBRXRBtGeInsYHmo(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void NqryrZIzItPykOANobgnpmwqAuAd()
	{
		try
		{
			prefNzJKrvxkSBRXRBtGeInsYHmo(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void prefNzJKrvxkSBRXRBtGeInsYHmo(bool P_0)
	{
		if (kmjrBOqBelEtvFOeqTruCALWEBKvA)
		{
			return;
		}
		if (P_0)
		{
			if (eIKDbEzZjkiQVKvfhaOxSgnEWbMW is IDisposable)
			{
				(eIKDbEzZjkiQVKvfhaOxSgnEWbMW as IDisposable).Dispose();
			}
			if (cRGtyEeyNwydFRopwnsxdtUzrUTb is IDisposable)
			{
				(cRGtyEeyNwydFRopwnsxdtUzrUTb as IDisposable).Dispose();
			}
		}
		kmjrBOqBelEtvFOeqTruCALWEBKvA = true;
	}
}
