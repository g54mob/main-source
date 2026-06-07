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

internal sealed class IevfLhwIfTciNnbiFjVqslbhqjt : IDisposable
{
	public enum PyVbleShzFSJKsRyfexWiqUdCtoe
	{
		Connected = 0,
		Disconnected = 1
	}

	private class EqRmrQaGFnOJGWWwolzmXaPLiqgs
	{
		public ADictionary<int, InputBehavior> RVZfZNHOYeFWqiahqPssTaBbIFuUA;

		public List<InputBehavior> pcucuJHtdMCcOhSAiVwAYwsTzgCEb;

		public IList<InputBehavior> aPxbtcLJuUvOEVZmnKNLXANokMMx;

		public EqRmrQaGFnOJGWWwolzmXaPLiqgs(List<InputBehavior> P_0)
		{
			pcucuJHtdMCcOhSAiVwAYwsTzgCEb = new List<InputBehavior>(P_0.Count);
			RVZfZNHOYeFWqiahqPssTaBbIFuUA = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				RVZfZNHOYeFWqiahqPssTaBbIFuUA.Add(P_0[i].id, inputBehavior);
				pcucuJHtdMCcOhSAiVwAYwsTzgCEb.Add(inputBehavior);
				num++;
			}
			aPxbtcLJuUvOEVZmnKNLXANokMMx = new ReadOnlyCollection<InputBehavior>(pcucuJHtdMCcOhSAiVwAYwsTzgCEb);
		}

		public InputBehavior pVXDMApNduphikSGKASbHyhAhrLe(int P_0)
		{
			if (pcucuJHtdMCcOhSAiVwAYwsTzgCEb.Count == 0)
			{
				return null;
			}
			RVZfZNHOYeFWqiahqPssTaBbIFuUA.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return pcucuJHtdMCcOhSAiVwAYwsTzgCEb[0];
			}
			return value;
		}
	}

	private sealed class GZBRFZmnerLRtxaibKnaeGGmEkuf : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int OFfnzINfQfXzCJwVYuaolxaXLRMF;

		private CustomController oSiuxGclJKpiheMEgdMzbfxcdkII;

		private int IoglZvFRtwyVIXmRwWgvxelJENAO;

		public IevfLhwIfTciNnbiFjVqslbhqjt HQRaxkCaRvmDPCLcJCTOlhFYLUSMB;

		private int eXijAKQRMJNKCABToNfVcanchtCu;

		public int HvkoziWeiRXmANczqWgqrQGdOVGI;

		private int cZPfhSKwkaaNBrrNTZCmTCDVSiupA;

		private int OqISeettdKHsiVGZcwikEiOhuGZS;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return oSiuxGclJKpiheMEgdMzbfxcdkII;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return oSiuxGclJKpiheMEgdMzbfxcdkII;
			}
		}

		[DebuggerHidden]
		public GZBRFZmnerLRtxaibKnaeGGmEkuf(int P_0)
		{
			OFfnzINfQfXzCJwVYuaolxaXLRMF = P_0;
			IoglZvFRtwyVIXmRwWgvxelJENAO = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int oFfnzINfQfXzCJwVYuaolxaXLRMF = OFfnzINfQfXzCJwVYuaolxaXLRMF;
			IevfLhwIfTciNnbiFjVqslbhqjt hQRaxkCaRvmDPCLcJCTOlhFYLUSMB = HQRaxkCaRvmDPCLcJCTOlhFYLUSMB;
			if (oFfnzINfQfXzCJwVYuaolxaXLRMF != 0)
			{
				if (oFfnzINfQfXzCJwVYuaolxaXLRMF != 1)
				{
					return false;
				}
				OFfnzINfQfXzCJwVYuaolxaXLRMF = -1;
				goto IL_007d;
			}
			OFfnzINfQfXzCJwVYuaolxaXLRMF = -1;
			cZPfhSKwkaaNBrrNTZCmTCDVSiupA = hQRaxkCaRvmDPCLcJCTOlhFYLUSMB.FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
			OqISeettdKHsiVGZcwikEiOhuGZS = 0;
			goto IL_008d;
			IL_007d:
			OqISeettdKHsiVGZcwikEiOhuGZS++;
			goto IL_008d;
			IL_008d:
			if (OqISeettdKHsiVGZcwikEiOhuGZS < cZPfhSKwkaaNBrrNTZCmTCDVSiupA)
			{
				if (hQRaxkCaRvmDPCLcJCTOlhFYLUSMB.FZgNAlfJkmHypqjgpNzeGlHXpLsC[OqISeettdKHsiVGZcwikEiOhuGZS].sourceControllerId == eXijAKQRMJNKCABToNfVcanchtCu)
				{
					oSiuxGclJKpiheMEgdMzbfxcdkII = hQRaxkCaRvmDPCLcJCTOlhFYLUSMB.FZgNAlfJkmHypqjgpNzeGlHXpLsC[OqISeettdKHsiVGZcwikEiOhuGZS];
					OFfnzINfQfXzCJwVYuaolxaXLRMF = 1;
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
			GZBRFZmnerLRtxaibKnaeGGmEkuf gZBRFZmnerLRtxaibKnaeGGmEkuf;
			if (OFfnzINfQfXzCJwVYuaolxaXLRMF == -2 && IoglZvFRtwyVIXmRwWgvxelJENAO == Environment.CurrentManagedThreadId)
			{
				OFfnzINfQfXzCJwVYuaolxaXLRMF = 0;
				gZBRFZmnerLRtxaibKnaeGGmEkuf = this;
			}
			else
			{
				gZBRFZmnerLRtxaibKnaeGGmEkuf = new GZBRFZmnerLRtxaibKnaeGGmEkuf(0);
				gZBRFZmnerLRtxaibKnaeGGmEkuf.HQRaxkCaRvmDPCLcJCTOlhFYLUSMB = HQRaxkCaRvmDPCLcJCTOlhFYLUSMB;
			}
			gZBRFZmnerLRtxaibKnaeGGmEkuf.eXijAKQRMJNKCABToNfVcanchtCu = HvkoziWeiRXmANczqWgqrQGdOVGI;
			return gZBRFZmnerLRtxaibKnaeGGmEkuf;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class SHDVRKwbxAKYBbhMRmbqLyoEYgVh : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int xKCHEiKxtPnXpvuGLhCrotjrjIfs;

		private CustomController LHZaLRhTkClQTOaxkMtGbJLBVucE;

		private int UTLqCpymNLuYEcZSQUuxagIfptAe;

		public IevfLhwIfTciNnbiFjVqslbhqjt jYCArDdZYghGqAGmheApSMfycikU;

		private string QAGXBktGDecyBlzdBqqQcxiGmxj;

		public string njmsQnkUiRMKSXsvqJUDDUFnJAtg;

		private int aoEeLZFOvKPCheHsUtWqSpZePxcj;

		private int ytcjGegQXNWficDYJFfHioUGYciVA;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return LHZaLRhTkClQTOaxkMtGbJLBVucE;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return LHZaLRhTkClQTOaxkMtGbJLBVucE;
			}
		}

		[DebuggerHidden]
		public SHDVRKwbxAKYBbhMRmbqLyoEYgVh(int P_0)
		{
			xKCHEiKxtPnXpvuGLhCrotjrjIfs = P_0;
			UTLqCpymNLuYEcZSQUuxagIfptAe = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = xKCHEiKxtPnXpvuGLhCrotjrjIfs;
			IevfLhwIfTciNnbiFjVqslbhqjt ievfLhwIfTciNnbiFjVqslbhqjt = jYCArDdZYghGqAGmheApSMfycikU;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				xKCHEiKxtPnXpvuGLhCrotjrjIfs = -1;
				goto IL_0083;
			}
			xKCHEiKxtPnXpvuGLhCrotjrjIfs = -1;
			aoEeLZFOvKPCheHsUtWqSpZePxcj = ievfLhwIfTciNnbiFjVqslbhqjt.FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
			ytcjGegQXNWficDYJFfHioUGYciVA = 0;
			goto IL_0093;
			IL_0083:
			ytcjGegQXNWficDYJFfHioUGYciVA++;
			goto IL_0093;
			IL_0093:
			if (ytcjGegQXNWficDYJFfHioUGYciVA < aoEeLZFOvKPCheHsUtWqSpZePxcj)
			{
				if (ievfLhwIfTciNnbiFjVqslbhqjt.FZgNAlfJkmHypqjgpNzeGlHXpLsC[ytcjGegQXNWficDYJFfHioUGYciVA].tag.Equals(QAGXBktGDecyBlzdBqqQcxiGmxj, StringComparison.OrdinalIgnoreCase))
				{
					LHZaLRhTkClQTOaxkMtGbJLBVucE = ievfLhwIfTciNnbiFjVqslbhqjt.FZgNAlfJkmHypqjgpNzeGlHXpLsC[ytcjGegQXNWficDYJFfHioUGYciVA];
					xKCHEiKxtPnXpvuGLhCrotjrjIfs = 1;
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
			SHDVRKwbxAKYBbhMRmbqLyoEYgVh sHDVRKwbxAKYBbhMRmbqLyoEYgVh;
			if (xKCHEiKxtPnXpvuGLhCrotjrjIfs == -2 && UTLqCpymNLuYEcZSQUuxagIfptAe == Environment.CurrentManagedThreadId)
			{
				xKCHEiKxtPnXpvuGLhCrotjrjIfs = 0;
				sHDVRKwbxAKYBbhMRmbqLyoEYgVh = this;
			}
			else
			{
				sHDVRKwbxAKYBbhMRmbqLyoEYgVh = new SHDVRKwbxAKYBbhMRmbqLyoEYgVh(0);
				sHDVRKwbxAKYBbhMRmbqLyoEYgVh.jYCArDdZYghGqAGmheApSMfycikU = jYCArDdZYghGqAGmheApSMfycikU;
			}
			sHDVRKwbxAKYBbhMRmbqLyoEYgVh.QAGXBktGDecyBlzdBqqQcxiGmxj = njmsQnkUiRMKSXsvqJUDDUFnJAtg;
			return sHDVRKwbxAKYBbhMRmbqLyoEYgVh;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> FWbcnhfAKsZTQIrNXlsqskRjSZGn;

	private List<Joystick> uNhkbbQsJYbKTTFrzWJNxolhrdBU;

	private List<CustomController> FZgNAlfJkmHypqjgpNzeGlHXpLsC;

	private List<Controller> hMuUeVnrUzMIhLarxxNEQfjNiQSIA;

	private ReadOnlyCollection<Controller> ndCOkiyFbadQDIWVhnFFOtcfjQJE;

	private Keyboard FxNcIdqHMrMaWgeMBzAzXMMJFfmDA;

	private Mouse kNqdGWwtvvyFNtOEDMCfxJLkkiZm;

	private ConfigVars UtERKwcYqsmNympSVnYlLUrWjoVc;

	private pDpcIvKINqIAQeDxKXPLLXNhacXfb[] wkIyhRrbEiHwxGdGZyFSKXEhxpsiA;

	private pDpcIvKINqIAQeDxKXPLLXNhacXfb[] JyJxpNuEpJihVhxskXlElkvcunoN;

	private pDpcIvKINqIAQeDxKXPLLXNhacXfb[,] SVKqEARWNHHYpltzzeucujeqcaQK;

	private beXbfkRAyWuTdcGMFyRGnKNziCGb AgmJhOyhXSMCbzyfGUGezPXlCZrGA;

	private TWxrygPadDakJYMiziCpkvpWZYPZ fRZZLVPSzIGTUfWRRdOxGZUPXlgI;

	private TWxrygPadDakJYMiziCpkvpWZYPZ[] lVlblTjHbeWtFcEnyRPGeikXviSf;

	private global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<ActiveControllerChangedDelegate> UHkQplXUFxtYcRHKbUFQLoaMBXfDA;

	private global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<PlayerActiveControllerChangedDelegate> vticasmmMRNOwDAIkashfEHCXOMUA;

	private global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<PlayerActiveControllerChangedDelegate>[] zBqZpdAeHFRZsDvwUlYyWTiEexwP;

	private ADictionary<int, EqRmrQaGFnOJGWWwolzmXaPLiqgs> YyuhEeAsrJaYabaOFATyppxvHECmA;

	private readonly KFxALCKJXDMoaDpabVBRHjBbQelXc nQLWEzVamBYwPXBUVXvltHEaCZG;

	private IList<Joystick> ikzJXYpfpNqLRegRxidGEnmYbNle;

	private IList<CustomController> oHLPFNPNqSJiXLqqWfsGaxCOJLhe;

	private int dOjGqpigYgzeYgJurJhxrECrTGkn;

	private bool VFdjFviKyJhstNgWSvrBczaMwOrBA;

	private bool ACUImyHYNChPWSLOutQMkMlRqJBGb;

	private bool IFtxHAwpIKaRkYoYSGsLUtBNKfUK;

	private IUnifiedKeyboardSource yAAbjwzNrRyZvaavuFYWFDoBdLDxA;

	private IUnifiedMouseSource mqOgzAqjgXGzRBzmnHdNpwiklLHnA;

	private int MBfEDspxDCDOBJGFZjfTQJvpzbKVA;

	private SfPfxaQrjElDDUkmFFxxeUUjFvLIA euRiBvhhhqEItpauKhxQMqPLmkky;

	private cphySyblTqRHzdCDofohJZUaAidOA vCrScoluoCmuwxzovJYKRzNsWVVh;

	private int bCgJIGYJOQecqNGgzLLvVSALMllo;

	private int ErZbikycOumhVMateMVWeYVITwh;

	private Action<int, ControllerDataUpdater> tnaDMdidlvEIFqhyRNfdfxfalsEaA;

	private Action<bool, int, int> KqrzugKdczVpnyJuyrZstLWZSPvX;

	private Action<ControllerStatusChangedEventArgs> qOxhizSctttWJXBSYEtrjgFErgxfA;

	private Action<ControllerType, int> UYrMOMQnjyDiIUeItqbzgqvlXGLy;

	private bool mQjRLekpwQmOHkdsrjKLLBAVnePm;

	public IList<Joystick> qQPYUHGpeSYXIATfmfGHglnODAfiA => ikzJXYpfpNqLRegRxidGEnmYbNle;

	public List<Joystick> wRxNOjLdJZWlqotTxAIkwpFCNejb => FWbcnhfAKsZTQIrNXlsqskRjSZGn;

	public int wURgxTJZNaSLNnCGmXznMTsQiLRN => FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;

	public Mouse QOfynKyLBkjDOhsBLZngEUcDGzzy => kNqdGWwtvvyFNtOEDMCfxJLkkiZm;

	public Keyboard WNWSmXDJjWGCNaqhXgXPNVyPdtGgb => FxNcIdqHMrMaWgeMBzAzXMMJFfmDA;

	public IList<CustomController> OfXwvmendXziMZySnqEbdcVFcFXO => oHLPFNPNqSJiXLqqWfsGaxCOJLhe;

	public List<CustomController> yTOBLWhwUAAaYtsSIlEvbOPtzjqO => FZgNAlfJkmHypqjgpNzeGlHXpLsC;

	public int LizNnbYKXjebNHsTsYbvUTWOfEFG => FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;

	public IList<Controller> nffGlbsLrJqoOdKFcAYXpkOVtReh => ndCOkiyFbadQDIWVhnFFOtcfjQJE;

	public int rYGECVtoqMhAvYNYeARovaGodjFL => hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Count;

	private int HOryNjZPriuWVodoDgBhjciTOpVhA
	{
		get
		{
			int mBfEDspxDCDOBJGFZjfTQJvpzbKVA = MBfEDspxDCDOBJGFZjfTQJvpzbKVA;
			MBfEDspxDCDOBJGFZjfTQJvpzbKVA++;
			if (MBfEDspxDCDOBJGFZjfTQJvpzbKVA >= int.MaxValue)
			{
				MBfEDspxDCDOBJGFZjfTQJvpzbKVA = 0;
			}
			return mBfEDspxDCDOBJGFZjfTQJvpzbKVA;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> iAxiOOZnhZggwDpPulnrGoMfpldNb
	{
		add
		{
			qOxhizSctttWJXBSYEtrjgFErgxfA = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(qOxhizSctttWJXBSYEtrjgFErgxfA, b);
		}
		remove
		{
			qOxhizSctttWJXBSYEtrjgFErgxfA = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(qOxhizSctttWJXBSYEtrjgFErgxfA, value2);
		}
	}

	public event Action<ControllerType, int> CJOAvERqHMEBsNRqxPANMAPAeOKq
	{
		add
		{
			UYrMOMQnjyDiIUeItqbzgqvlXGLy = (Action<ControllerType, int>)Delegate.Combine(UYrMOMQnjyDiIUeItqbzgqvlXGLy, b);
		}
		remove
		{
			UYrMOMQnjyDiIUeItqbzgqvlXGLy = (Action<ControllerType, int>)Delegate.Remove(UYrMOMQnjyDiIUeItqbzgqvlXGLy, value2);
		}
	}

	public IevfLhwIfTciNnbiFjVqslbhqjt(ConfigVars P_0, PlatformInputManager P_1)
	{
		UtERKwcYqsmNympSVnYlLUrWjoVc = P_0;
		dOjGqpigYgzeYgJurJhxrECrTGkn = 0;
		VFdjFviKyJhstNgWSvrBczaMwOrBA = UnityTools.isAndroidPlatform;
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA = new List<Controller>(10);
		ndCOkiyFbadQDIWVhnFFOtcfjQJE = new ReadOnlyCollection<Controller>(hMuUeVnrUzMIhLarxxNEQfjNiQSIA);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (yAAbjwzNrRyZvaavuFYWFDoBdLDxA = new UnityUnifiedKeyboardSource());
		}
		FxNcIdqHMrMaWgeMBzAzXMMJFfmDA = new Keyboard("Keyboard", unifiedKeyboardSource);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Add(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (mqOgzAqjgXGzRBzmnHdNpwiklLHnA = new UnityUnifiedMouseSource());
		}
		kNqdGWwtvvyFNtOEDMCfxJLkkiZm = new Mouse("Mouse", unifiedMouseSource);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Add(kNqdGWwtvvyFNtOEDMCfxJLkkiZm);
		AgmJhOyhXSMCbzyfGUGezPXlCZrGA = new beXbfkRAyWuTdcGMFyRGnKNziCGb(P_0.updateLoop, FxNcIdqHMrMaWgeMBzAzXMMJFfmDA);
		FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.TSjdvvhiFDrnlwFUZIHtAcTaRjAq += TOlFiIcspDtZahIEyqfTuyNvBBtaA;
		FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		kNqdGWwtvvyFNtOEDMCfxJLkkiZm.enabled = !P_0.GetPlatformVar_disableMouse();
		ZzroRHnTCwjEFrMxSBybEKjuOhMOA.JISCwsGWvSIpUwYyRPDmAPXtgUdgb();
		nQLWEzVamBYwPXBUVXvltHEaCZG = new KFxALCKJXDMoaDpabVBRHjBbQelXc(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		nQLWEzVamBYwPXBUVXvltHEaCZG.qFpuCelGxwvwkiFIaRKpdJlSeoVD(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA);
		nQLWEzVamBYwPXBUVXvltHEaCZG.qFpuCelGxwvwkiFIaRKpdJlSeoVD(kNqdGWwtvvyFNtOEDMCfxJLkkiZm);
		ReInput.ApplicationFocusChangedEvent += DFMxJKNuVaCcLEQUVZUcqhSXMCQp;
	}

	public void dXEgTSdHfDwdGWXHuWbKsASChoQn(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		tnaDMdidlvEIFqhyRNfdfxfalsEaA = P_0;
		FIPpeKkGjgaqBsONXXqXwvVOfPMX(P_1);
	}

	public void HshKYrNOXVuRqESxIGQIeEGvHNrT(UpdateLoopType P_0)
	{
		ZzroRHnTCwjEFrMxSBybEKjuOhMOA.MeHCklKLabtaaxkpfOVQeioYIVetA(P_0);
		if (FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.enabled)
		{
			AgmJhOyhXSMCbzyfGUGezPXlCZrGA.VlGtLKgGyKBYRIMvKVcEqfGLjhdJA(P_0);
		}
		vPQBcjOdBbgVgsjUExGxfrLghKgG(P_0);
		FZZnGFZFBacrXxpJwRRlGmAagmBr(P_0);
		ZzroRHnTCwjEFrMxSBybEKjuOhMOA.ADyiJZsPmgJPSCHQyEkJHGtRfKfH(P_0, ReInput.currentFrame);
		if (IFtxHAwpIKaRkYoYSGsLUtBNKfUK)
		{
			MkOLuNxYmXFmQCoAzoawQydbwHCc();
		}
	}

	public pDpcIvKINqIAQeDxKXPLLXNhacXfb cqEWFPGTFKZWXfEMoSllBoqsXmIl(int P_0, string P_1, bool P_2)
	{
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.WLLVULumRpsTJtCNqGAyjxbbVSyG(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return JyJxpNuEpJihVhxskXlElkvcunoN[num];
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return null;
		}
		return SVKqEARWNHHYpltzzeucujeqcaQK[P_0, num];
	}

	public pDpcIvKINqIAQeDxKXPLLXNhacXfb GFHCguACECBmAcjhhkDLNaZRTRlkc(int P_0, int P_1, bool P_2)
	{
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.TZdqRkBElGhiTOcaFowdeDTzaUBEA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return JyJxpNuEpJihVhxskXlElkvcunoN[num];
		}
		return SVKqEARWNHHYpltzzeucujeqcaQK[P_0, num];
	}

	public void NhePbzmXatqlakJyGwDLbOcSaroBA(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			PyVbleShzFSJKsRyfexWiqUdCtoe pyVbleShzFSJKsRyfexWiqUdCtoe = PyVbleShzFSJKsRyfexWiqUdCtoe.Connected;
			int num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0.sourceJoystick.rewiredId, pyVbleShzFSJKsRyfexWiqUdCtoe);
			if (num < 0)
			{
				pyVbleShzFSJKsRyfexWiqUdCtoe = PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected;
				num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0.sourceJoystick.rewiredId, pyVbleShzFSJKsRyfexWiqUdCtoe);
			}
			if (num >= 0)
			{
				((pyVbleShzFSJKsRyfexWiqUdCtoe == PyVbleShzFSJKsRyfexWiqUdCtoe.Connected) ? FWbcnhfAKsZTQIrNXlsqskRjSZGn[num] : uNhkbbQsJYbKTTFrzWJNxolhrdBU[num]).FtXHkhBMwEbMbDPMsuoggYajIttx(P_0);
			}
		}
	}

	public bool NkzFpsPaMPDShgUkvpmJYCXyWSLR(int P_0, PyVbleShzFSJKsRyfexWiqUdCtoe P_1)
	{
		if (AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int AOFYWEBWibrmNOqkmqXbbJyLwWOD(int P_0, PyVbleShzFSJKsRyfexWiqUdCtoe P_1)
	{
		switch (P_1)
		{
		case PyVbleShzFSJKsRyfexWiqUdCtoe.Connected:
		{
			int count2 = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
			for (int j = 0; j < count2; j++)
			{
				if (FWbcnhfAKsZTQIrNXlsqskRjSZGn[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected:
		{
			int count = uNhkbbQsJYbKTTFrzWJNxolhrdBU.Count;
			for (int i = 0; i < count; i++)
			{
				if (uNhkbbQsJYbKTTFrzWJNxolhrdBU[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int DtyjtTtwIYdPyNdToGKAbbgaQybeA(Guid P_0, PyVbleShzFSJKsRyfexWiqUdCtoe P_1)
	{
		switch (P_1)
		{
		case PyVbleShzFSJKsRyfexWiqUdCtoe.Connected:
		{
			int count2 = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
			for (int j = 0; j < count2; j++)
			{
				if (FWbcnhfAKsZTQIrNXlsqskRjSZGn[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected:
		{
			int count = uNhkbbQsJYbKTTFrzWJNxolhrdBU.Count;
			for (int i = 0; i < count; i++)
			{
				if (uNhkbbQsJYbKTTFrzWJNxolhrdBU[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool EVQLBXSzAhTKhBrNnVDZoktVrqmr(int P_0)
	{
		if (GxYHWEJpTkvNkiamAPHhLTmiCugf(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int GxYHWEJpTkvNkiamAPHhLTmiCugf(int P_0)
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		for (int i = 0; i < count; i++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int HGJuJFipJZBmtCPjGepwFUGKQHQE(Guid P_0)
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		for (int i = 0; i < count; i++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void nlrdBPJxbHrPVPzluXttCBlluWzk(BridgedController P_0)
	{
		oeKfPjFjUiffaBtUtphseRVQYBwVA(P_0);
	}

	public void aoRpcnejKsMCdpTbHVJjvqppkHYQ(int P_0)
	{
		int num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0, PyVbleShzFSJKsRyfexWiqUdCtoe.Connected);
		vHmCsVdlwrCArWQoGyPCSJBxOdFSA(num);
	}

	public int LByEehKndcPABuWdbwiILAfacKafb()
	{
		return dOjGqpigYgzeYgJurJhxrECrTGkn++;
	}

	public IList<InputBehavior> VOFiqERXjAvCjjqOvJfeHzvMfmCv(int P_0)
	{
		if (!YyuhEeAsrJaYabaOFATyppxvHECmA.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return YyuhEeAsrJaYabaOFATyppxvHECmA[P_0].aPxbtcLJuUvOEVZmnKNLXANokMMx;
	}

	public InputBehavior SDMFAWCrgmleeoNXrjhdUhSXNceBA(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return HquYTqzJPbmOsyQHFsOTzKtmyUgP(P_0, inputBehaviorId);
	}

	public InputBehavior HquYTqzJPbmOsyQHFsOTzKtmyUgP(int P_0, int P_1)
	{
		if (!YyuhEeAsrJaYabaOFATyppxvHECmA.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> aPxbtcLJuUvOEVZmnKNLXANokMMx = YyuhEeAsrJaYabaOFATyppxvHECmA[P_0].aPxbtcLJuUvOEVZmnKNLXANokMMx;
		for (int i = 0; i < aPxbtcLJuUvOEVZmnKNLXANokMMx.Count; i++)
		{
			if (aPxbtcLJuUvOEVZmnKNLXANokMMx[i].id == P_1)
			{
				return aPxbtcLJuUvOEVZmnKNLXANokMMx[i];
			}
		}
		return null;
	}

	public Joystick lJNHwTBZiOepTHokyHvamZjJSanE(int P_0, bool P_1 = false)
	{
		int num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0, PyVbleShzFSJKsRyfexWiqUdCtoe.Connected);
		if (num >= 0)
		{
			return FWbcnhfAKsZTQIrNXlsqskRjSZGn[num];
		}
		if (P_1)
		{
			num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0, PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected);
			if (num >= 0)
			{
				return uNhkbbQsJYbKTTFrzWJNxolhrdBU[num];
			}
		}
		return null;
	}

	public Joystick uvflvCssSzWyhPednDjXJppRMjij(Guid P_0, bool P_1 = false)
	{
		int num = DtyjtTtwIYdPyNdToGKAbbgaQybeA(P_0, PyVbleShzFSJKsRyfexWiqUdCtoe.Connected);
		if (num >= 0)
		{
			return FWbcnhfAKsZTQIrNXlsqskRjSZGn[num];
		}
		if (P_1)
		{
			num = DtyjtTtwIYdPyNdToGKAbbgaQybeA(P_0, PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected);
			if (num >= 0)
			{
				return uNhkbbQsJYbKTTFrzWJNxolhrdBU[num];
			}
		}
		return null;
	}

	public Joystick[] rcgVAvJYOyccCeXMGXhtBgVRXAAb()
	{
		int count = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = FWbcnhfAKsZTQIrNXlsqskRjSZGn[i];
		}
		return array;
	}

	public string[] ojQaPWjwYdVhoZsqlkpyOjVMDkdn()
	{
		int count = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = FWbcnhfAKsZTQIrNXlsqskRjSZGn[i].name;
		}
		return array;
	}

	public CustomController XvAOcIKVJdrnVzxITFVLOOsfHCAH(int P_0)
	{
		int num = GxYHWEJpTkvNkiamAPHhLTmiCugf(P_0);
		if (num < 0)
		{
			return null;
		}
		return FZgNAlfJkmHypqjgpNzeGlHXpLsC[num];
	}

	public CustomController OSAyjuFGdWTTbcMWeOhcjpaObhtu(Guid P_0)
	{
		int num = HGJuJFipJZBmtCPjGepwFUGKQHQE(P_0);
		if (num < 0)
		{
			return null;
		}
		return FZgNAlfJkmHypqjgpNzeGlHXpLsC[num];
	}

	public CustomController[] OHYzbWhCDJedNHkyxeQJXazGAEfPA()
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = FZgNAlfJkmHypqjgpNzeGlHXpLsC[i];
		}
		return array;
	}

	public string[] jXDpqtDNAKwfhDcAksduzWKZzXRc()
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = FZgNAlfJkmHypqjgpNzeGlHXpLsC[i].name;
		}
		return array;
	}

	public CustomController JlfQnWRmJLDrniFGUGXtiLXbIAIO(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int swafEdmNyLmEZtiSitfCaBMKYBwW = HOryNjZPriuWVodoDgBhjciTOpVhA;
		CustomController customController = new CustomController(new gMHrfNmlAthdFHvMbEMkuLiDfcMw
		{
			jsehdJggeeoLNNCBjPweCpcqSeSk = InputSource.Custom,
			WGhiNOQWlUPYBFWdCWWVqcOGpCWL = customControllerById.descriptiveName,
			yZgrbUaSfIUkHRuwwrgejxhOQLaR = customControllerById.name,
			qQvnuMklpIVmpUgocgsKpDvFGWhM = customControllerById.axisCount,
			RQgyOdFZEFnEZdWMCwDRlVXMTVSb = customControllerById.buttonCount,
			swafEdmNyLmEZtiSitfCaBMKYBwW = swafEdmNyLmEZtiSitfCaBMKYBwW,
			wrXIeaLrSNGBTjSpCTSdlsgYuOTM = customControllerById.id,
			TYrtdrpvBVIXbhEcMrvqZDKRLKMl = customControllerById.typeGuid,
			yfnxcLKmsdErGCTAFkiDidAHlKjGA = customControllerById.id.ToString(),
			XhiJBSvyWljVyMvzNQMmNKEtFTeg = customControllerById.CreateGameHardwareMap()
		});
		VYHmSLIcmQwnZkoppBEZxrcOioChA(customController);
		return customController;
	}

	public bool avXDjqtUsROcOwdiGscGBuDLkXal(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return JzpasvUIojpAqImvpsBhyOBjfToI(P_0);
	}

	public CustomController ugHspKWCYOKYqoJhblJOVOOkAmpkA(int P_0)
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		for (int i = 0; i < count; i++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[i].sourceControllerId == P_0)
			{
				return FZgNAlfJkmHypqjgpNzeGlHXpLsC[i];
			}
		}
		return null;
	}

	public CustomController RwXTdvqtKvefkLtmoEHPnirBUDcL(string P_0)
	{
		int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		for (int i = 0; i < count; i++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return FZgNAlfJkmHypqjgpNzeGlHXpLsC[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(GZBRFZmnerLRtxaibKnaeGGmEkuf))]
	public IEnumerable<CustomController> puEXWMSeBjmVlqBULIqqQyoTZFDf(int P_0)
	{
		return new GZBRFZmnerLRtxaibKnaeGGmEkuf(-2)
		{
			HQRaxkCaRvmDPCLcJCTOlhFYLUSMB = this,
			HvkoziWeiRXmANczqWgqrQGdOVGI = P_0
		};
	}

	[IteratorStateMachine(typeof(SHDVRKwbxAKYBbhMRmbqLyoEYgVh))]
	public IEnumerable<CustomController> uNrfzbHTigEApugzKMGrCKlzopvtA(string P_0)
	{
		return new SHDVRKwbxAKYBbhMRmbqLyoEYgVh(-2)
		{
			jYCArDdZYghGqAGmheApSMfycikU = this,
			njmsQnkUiRMKSXsvqJUDDUFnJAtg = P_0
		};
	}

	public Controller RdwbZcApWxKMveONGCHALzbrDsZZb(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => lJNHwTBZiOepTHokyHvamZjJSanE(P_1, P_2), 
			ControllerType.Keyboard => FxNcIdqHMrMaWgeMBzAzXMMJFfmDA, 
			ControllerType.Mouse => kNqdGWwtvvyFNtOEDMCfxJLkkiZm, 
			ControllerType.Custom => XvAOcIKVJdrnVzxITFVLOOsfHCAH(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller HXqDyahUzpKQPuoAHBEQrHhlLEOiA(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return wcFBCyjiIvmzTBtLUndCPPmHJaxEb(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return RdwbZcApWxKMveONGCHALzbrDsZZb(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller wcFBCyjiIvmzTBtLUndCPPmHJaxEb(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.deviceInstanceGuid == P_0)
		{
			return FxNcIdqHMrMaWgeMBzAzXMMJFfmDA;
		}
		if (kNqdGWwtvvyFNtOEDMCfxJLkkiZm.deviceInstanceGuid == P_0)
		{
			return kNqdGWwtvvyFNtOEDMCfxJLkkiZm;
		}
		Controller result;
		if ((result = uvflvCssSzWyhPednDjXJppRMjij(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = OSAyjuFGdWTTbcMWeOhcjpaObhtu(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] oHNJFncyjYORPINFcBNmDgWNrLVpA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => rcgVAvJYOyccCeXMGXhtBgVRXAAb(), 
			ControllerType.Keyboard => new Controller[1] { FxNcIdqHMrMaWgeMBzAzXMMJFfmDA }, 
			ControllerType.Mouse => new Controller[1] { kNqdGWwtvvyFNtOEDMCfxJLkkiZm }, 
			ControllerType.Custom => OHYzbWhCDJedNHkyxeQJXazGAEfPA(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] ylZVVezfuQwRIKJJgWOQDPxuenMQ(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ojQaPWjwYdVhoZsqlkpyOjVMDkdn(), 
			ControllerType.Keyboard => new string[1] { FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.name }, 
			ControllerType.Mouse => new string[1] { kNqdGWwtvvyFNtOEDMCfxJLkkiZm.name }, 
			ControllerType.Custom => jXDpqtDNAKwfhDcAksduzWKZzXRc(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void oFelXaKkNgsIAhbTINhiNYYHaxpg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.itkpiJpsmAAPLLWgXpBhomoNAvagA(P_1, P_2, InputActionEventType.Update, null);
	}

	public void SVyPFpIjvpBxBbjoqPDLliNKpuGz(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.YnULYfgfnGWOiiHGzCUPCylcZRQm(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void QKKJAyIMQQZkjUwEhFXOqPsSSfpX(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_3);
		if (num >= 0)
		{
			SVyPFpIjvpBxBbjoqPDLliNKpuGz(P_0, P_1, P_2, num);
		}
	}

	public void EfUhBJgaeCIRxaSaWSoOsZczQOrsA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.itkpiJpsmAAPLLWgXpBhomoNAvagA(P_1, P_2, P_3, P_4);
	}

	public void VSJuATWjBzUzgWWwQcZKfQiulnSx(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.YnULYfgfnGWOiiHGzCUPCylcZRQm(P_1, P_2, P_3, P_4, P_5);
	}

	public void IkJGkCfvtWvMtswfHKMVnFBRCzNcb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			ACUImyHYNChPWSLOutQMkMlRqJBGb = true;
		}
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_4);
		if (num >= 0)
		{
			VSJuATWjBzUzgWWwQcZKfQiulnSx(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void KqLlRhtMpJjmmkRNJwhlHdqttkuQA(int P_0, Action<InputActionEventData> P_1)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.rfgCATbUdPGxemgZfharHOUpnonbb(P_1);
	}

	public void GNjGeyjezIEkKLxRQacFCqflHXZcA(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.fCTJiEYEUmVtVERXVmcndvwVeePI(P_1, P_2);
	}

	public void nGFYhIvEhSodpuoVZRXtmQrwQVTX(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_2);
		if (num >= 0)
		{
			GNjGeyjezIEkKLxRQacFCqflHXZcA(P_0, P_1, num);
		}
	}

	public void yGhtdclCfnZeFTRCkvDtwdeqylMU(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.fqXZXRhgKsRXYflPVtYcOXAMxAvK(P_1, P_2);
	}

	public void bREBwzCJokGmQDBMXRHuJxrAEZHP(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.wbcgjphHnXctdwQPleEfNZcZhKdA(P_1, P_2);
	}

	public void LmdhAGEhPjtSFKQHsvwBTDgKxSSAA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.ujfcGDfvGrOMmCoHSSfkcrpprKTiA(P_1, P_2, P_3);
	}

	public void uuzLgZXgyvymYioqIjnPqYPTmeCg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_3);
		if (num >= 0)
		{
			LmdhAGEhPjtSFKQHsvwBTDgKxSSAA(P_0, P_1, P_2, num);
		}
	}

	public void tpWVDQkzsruwwXqzUfBtFclYekCN(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.MYOQVhKEDQoGRrGPWDHBSpQvoJKh(P_1, P_2, P_3);
	}

	public void opXwtxWvKekKHNdxNXKnGPPLhDwjA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_3);
		if (num >= 0)
		{
			tpWVDQkzsruwwXqzUfBtFclYekCN(P_0, P_1, P_2, num);
		}
	}

	public void nmnIglcykUvJsjbdukobTWmBrhix(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.OGjtKCKmpINQvyznSfidDUKZBqBv(P_1, P_2, P_3);
	}

	public void nsulWnDcnVTHVltMQOiFkADEPWEK(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.uvPIKIjbFvbufBUbxglORkubMtio(P_1, P_2, P_3, P_4);
	}

	public void HDZmNyONUWVHbyFwIoyQQDxnijCG(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA.rJQWQoVIwBDhBfGWzPhuwWbIFFKdA(P_4);
		if (num >= 0)
		{
			nsulWnDcnVTHVltMQOiFkADEPWEK(P_0, P_1, P_2, P_3, num);
		}
	}

	public void VRrQzpklzYPEoEgmLCmGCqtfrsDFA(int P_0)
	{
		miwilMxABKnXjTPfijikGGRObeGP(P_0)?.XKwQXDlBRpLXDQOmGcSgHZUgNcGK();
	}

	public bool mpbSTLretjeJSjfvWhDdBnLTWpGXA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].YQHfsMysqVjztjwtrTJFEIeKPird())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].YQHfsMysqVjztjwtrTJFEIeKPird())
			{
				return true;
			}
		}
		return false;
	}

	public bool gjVUoBghExUEPTOkthVQGpDnmxVJA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].jrqnIQwfWvLcsfINFBfxTCLjSkbp())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].jrqnIQwfWvLcsfINFBfxTCLjSkbp())
			{
				return true;
			}
		}
		return false;
	}

	public bool jazTjWLpshzeiDTPPvoVeYAWQDzx(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].zXkcXAuzSiVuvHFqjJGyoytJKnVj())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].zXkcXAuzSiVuvHFqjJGyoytJKnVj())
			{
				return true;
			}
		}
		return false;
	}

	public bool ffxrkyZxdJqFZfduUFmRiDKJoUQvA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].lwjmXUEiKjWVAPRRtMBJTmfQpHIG())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].lwjmXUEiKjWVAPRRtMBJTmfQpHIG())
			{
				return true;
			}
		}
		return false;
	}

	public bool xTkfbCOtYygNhegWVfOPGbxlVjXgb(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].YPJJifGpzKGpOHFiwhVoQgKlzzCdA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].YPJJifGpzKGpOHFiwhVoQgKlzzCdA())
			{
				return true;
			}
		}
		return false;
	}

	public bool qbNZGHzkTsgUsPDYqYMOdbmONpJp(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].KeraHXgHMqVrTuinGHPvxuntPHYeA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].KeraHXgHMqVrTuinGHPvxuntPHYeA())
			{
				return true;
			}
		}
		return false;
	}

	public bool uLhlsDyPCsramYInopbVXOkJJNmG(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].PWnDobdZzmcwAbkseaPUoybpajTDc())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].PWnDobdZzmcwAbkseaPUoybpajTDc())
			{
				return true;
			}
		}
		return false;
	}

	public bool NFyDdsdYdMHUeNvIpZOxJMpGMzzgA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < JyJxpNuEpJihVhxskXlElkvcunoN.Length; i++)
			{
				if (JyJxpNuEpJihVhxskXlElkvcunoN[i].ySaGSRRDbrMediuPDkdswdvuaTRaA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			return false;
		}
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		for (int j = 0; j < num; j++)
		{
			if (SVKqEARWNHHYpltzzeucujeqcaQK[P_0, j].ySaGSRRDbrMediuPDkdswdvuaTRaA())
			{
				return true;
			}
		}
		return false;
	}

	public bool AzMccuIzYZCZxFPIZYeHUUsUCWyDA()
	{
		if (!nbAcqHbYBboTUoGSQsywJNvmSjfI(kNqdGWwtvvyFNtOEDMCfxJLkkiZm) && !ZKfdFzjmtrtyUOdxccVwIKTisvNr(FWbcnhfAKsZTQIrNXlsqskRjSZGn) && !nbAcqHbYBboTUoGSQsywJNvmSjfI(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA))
		{
			return ZKfdFzjmtrtyUOdxccVwIKTisvNr(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		}
		return true;
	}

	public bool pNhuVTerGZEDftSiNDYORvUZaYZd(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ZKfdFzjmtrtyUOdxccVwIKTisvNr(FWbcnhfAKsZTQIrNXlsqskRjSZGn), 
			ControllerType.Keyboard => nbAcqHbYBboTUoGSQsywJNvmSjfI(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA), 
			ControllerType.Mouse => nbAcqHbYBboTUoGSQsywJNvmSjfI(kNqdGWwtvvyFNtOEDMCfxJLkkiZm), 
			ControllerType.Custom => ZKfdFzjmtrtyUOdxccVwIKTisvNr(FZgNAlfJkmHypqjgpNzeGlHXpLsC), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool nhHQFBNdYhBYMcdfTzhWXJtcMIZw()
	{
		if (!dfOoTgNOTsDNyAMKSLmvswsnyCRi(kNqdGWwtvvyFNtOEDMCfxJLkkiZm) && !dpwzGpUBTvChuDTQcFQkRnnKHwwdA(FWbcnhfAKsZTQIrNXlsqskRjSZGn) && !dfOoTgNOTsDNyAMKSLmvswsnyCRi(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA))
		{
			return dpwzGpUBTvChuDTQcFQkRnnKHwwdA(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		}
		return true;
	}

	public bool ygqxtaQAAdUmiOFNFilzfwpKKqNwA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => dpwzGpUBTvChuDTQcFQkRnnKHwwdA(FWbcnhfAKsZTQIrNXlsqskRjSZGn), 
			ControllerType.Keyboard => dfOoTgNOTsDNyAMKSLmvswsnyCRi(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA), 
			ControllerType.Mouse => dfOoTgNOTsDNyAMKSLmvswsnyCRi(kNqdGWwtvvyFNtOEDMCfxJLkkiZm), 
			ControllerType.Custom => dpwzGpUBTvChuDTQcFQkRnnKHwwdA(FZgNAlfJkmHypqjgpNzeGlHXpLsC), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool GufsrcKjvTyDfDDYDpKoXuroANED()
	{
		if (!vGwfhxaoIxLbhIyBDGViZMFOtyNkA(kNqdGWwtvvyFNtOEDMCfxJLkkiZm) && !OfcpWPzOnfCyZWuhqGZhpXckjvao(FWbcnhfAKsZTQIrNXlsqskRjSZGn) && !vGwfhxaoIxLbhIyBDGViZMFOtyNkA(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA))
		{
			return OfcpWPzOnfCyZWuhqGZhpXckjvao(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		}
		return true;
	}

	public bool oWCImHAZWtcIGuoAnfdqFYskaognA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => OfcpWPzOnfCyZWuhqGZhpXckjvao(FWbcnhfAKsZTQIrNXlsqskRjSZGn), 
			ControllerType.Keyboard => vGwfhxaoIxLbhIyBDGViZMFOtyNkA(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA), 
			ControllerType.Mouse => vGwfhxaoIxLbhIyBDGViZMFOtyNkA(kNqdGWwtvvyFNtOEDMCfxJLkkiZm), 
			ControllerType.Custom => OfcpWPzOnfCyZWuhqGZhpXckjvao(FZgNAlfJkmHypqjgpNzeGlHXpLsC), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool ZCDEcfYdlmSHVwITtCVAZhqUdtam()
	{
		if (!DRddEWjmBgyUAWUsSgrEjRyNYXBGA(kNqdGWwtvvyFNtOEDMCfxJLkkiZm) && !fpYbCqdCxSknTBAfNsFiZlhRbAKV(FWbcnhfAKsZTQIrNXlsqskRjSZGn) && !DRddEWjmBgyUAWUsSgrEjRyNYXBGA(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA))
		{
			return fpYbCqdCxSknTBAfNsFiZlhRbAKV(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		}
		return true;
	}

	public bool IzuKpvDUtuTYJPKjYOHNoQiXVyAA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => fpYbCqdCxSknTBAfNsFiZlhRbAKV(FWbcnhfAKsZTQIrNXlsqskRjSZGn), 
			ControllerType.Keyboard => DRddEWjmBgyUAWUsSgrEjRyNYXBGA(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA), 
			ControllerType.Mouse => DRddEWjmBgyUAWUsSgrEjRyNYXBGA(kNqdGWwtvvyFNtOEDMCfxJLkkiZm), 
			ControllerType.Custom => fpYbCqdCxSknTBAfNsFiZlhRbAKV(FZgNAlfJkmHypqjgpNzeGlHXpLsC), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool sYxEIFSDJaUUGxbygfVieRIqftVM()
	{
		if (!oHaewTrhGwkgESGWYzNdCHhHrFNr(kNqdGWwtvvyFNtOEDMCfxJLkkiZm) && !SIvfQtDyYzznprVlMPfgrRAFLZwYA(FWbcnhfAKsZTQIrNXlsqskRjSZGn) && !oHaewTrhGwkgESGWYzNdCHhHrFNr(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA))
		{
			return SIvfQtDyYzznprVlMPfgrRAFLZwYA(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		}
		return true;
	}

	public bool nDVXsUJMOgKOHZEfxzUqbwUmOSDM(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => SIvfQtDyYzznprVlMPfgrRAFLZwYA(FWbcnhfAKsZTQIrNXlsqskRjSZGn), 
			ControllerType.Keyboard => oHaewTrhGwkgESGWYzNdCHhHrFNr(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA), 
			ControllerType.Mouse => oHaewTrhGwkgESGWYzNdCHhHrFNr(kNqdGWwtvvyFNtOEDMCfxJLkkiZm), 
			ControllerType.Custom => SIvfQtDyYzznprVlMPfgrRAFLZwYA(FZgNAlfJkmHypqjgpNzeGlHXpLsC), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool ZKfdFzjmtrtyUOdxccVwIKTisvNr<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool nbAcqHbYBboTUoGSQsywJNvmSjfI(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool dpwzGpUBTvChuDTQcFQkRnnKHwwdA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool dfOoTgNOTsDNyAMKSLmvswsnyCRi(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool OfcpWPzOnfCyZWuhqGZhpXckjvao<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool vGwfhxaoIxLbhIyBDGViZMFOtyNkA(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool fpYbCqdCxSknTBAfNsFiZlhRbAKV<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool DRddEWjmBgyUAWUsSgrEjRyNYXBGA(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool SIvfQtDyYzznprVlMPfgrRAFLZwYA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool oHaewTrhGwkgESGWYzNdCHhHrFNr(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller PmHCxACwyGCOFvVzcMTfWBGubFLGA()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(kNqdGWwtvvyFNtOEDMCfxJLkkiZm, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA, ref lastController, ref lastTime);
		IList<Joystick> fWbcnhfAKsZTQIrNXlsqskRjSZGn = FWbcnhfAKsZTQIrNXlsqskRjSZGn;
		for (int i = 0; i < wURgxTJZNaSLNnCGmXznMTsQiLRN; i++)
		{
			InputTools.CompareLastActiveController(fWbcnhfAKsZTQIrNXlsqskRjSZGn[i], ref lastController, ref lastTime);
		}
		IList<CustomController> fZgNAlfJkmHypqjgpNzeGlHXpLsC = FZgNAlfJkmHypqjgpNzeGlHXpLsC;
		for (int j = 0; j < LizNnbYKXjebNHsTsYbvUTWOfEFG; j++)
		{
			InputTools.CompareLastActiveController(fZgNAlfJkmHypqjgpNzeGlHXpLsC[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = FxNcIdqHMrMaWgeMBzAzXMMJFfmDA;
		}
		return lastController;
	}

	public Controller jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(FWbcnhfAKsZTQIrNXlsqskRjSZGn[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return WNWSmXDJjWGCNaqhXgXPNVyPdtGgb;
		case ControllerType.Mouse:
			return QOfynKyLBkjDOhsBLZngEUcDGzzy;
		case ControllerType.Custom:
		{
			int count = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(FZgNAlfJkmHypqjgpNzeGlHXpLsC[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 PmHCxACwyGCOFvVzcMTfWBGubFLGA<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType jkHoswdJNMmoRlmwAdfScmqOQaAm()
	{
		return PmHCxACwyGCOFvVzcMTfWBGubFLGA()?.type ?? ControllerType.Keyboard;
	}

	public void rqRFubVqBTsPtkmTTFQVjzOKEoxK(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			IFtxHAwpIKaRkYoYSGsLUtBNKfUK = true;
			UHkQplXUFxtYcRHKbUFQLoaMBXfDA.MefHOFwPqrDcRIRFiByZCvzbMCoyB(P_0);
		}
	}

	public void TdiyplLkVVQRqNCeXXZJGYpNAedT(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			IFtxHAwpIKaRkYoYSGsLUtBNKfUK = true;
			UHkQplXUFxtYcRHKbUFQLoaMBXfDA.BdgZhnItAhUXmqBGTJjdClSARZnp(P_0, P_1);
		}
	}

	public void IRyleYPvXLKxXzUQFwigTVoEjvyE(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			UHkQplXUFxtYcRHKbUFQLoaMBXfDA.vqjXOcKWCpifEkrujSSXyVIRzRRJ(P_0);
		}
	}

	public void JyKQYEFHOcCsCnSUcaQEkibJYySsA(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			UHkQplXUFxtYcRHKbUFQLoaMBXfDA.sqsvdofBgncMnnIdtrtovFpSOLDx(P_0, P_1);
		}
	}

	public void bCNoccdaIrispcRYXJrzYyjjtxiBA()
	{
		UHkQplXUFxtYcRHKbUFQLoaMBXfDA.xgZbuPfhIULHyDLJCOqeZpFlQyUvb();
	}

	public void DeSeyTYFgrwgdFvtiqXOQtfnDzOL(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			vticasmmMRNOwDAIkashfEHCXOMUA.MefHOFwPqrDcRIRFiByZCvzbMCoyB(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)bCgJIGYJOQecqNGgzLLvVSALMllo)
			{
				return;
			}
			zBqZpdAeHFRZsDvwUlYyWTiEexwP[P_0].MefHOFwPqrDcRIRFiByZCvzbMCoyB(P_1);
		}
		IFtxHAwpIKaRkYoYSGsLUtBNKfUK = true;
	}

	public void iLzqSDjPslaXiSDJEKRKaKRMVPKM(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			vticasmmMRNOwDAIkashfEHCXOMUA.BdgZhnItAhUXmqBGTJjdClSARZnp(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)bCgJIGYJOQecqNGgzLLvVSALMllo)
			{
				return;
			}
			zBqZpdAeHFRZsDvwUlYyWTiEexwP[P_0].BdgZhnItAhUXmqBGTJjdClSARZnp(P_1, P_2);
		}
		IFtxHAwpIKaRkYoYSGsLUtBNKfUK = true;
	}

	public void YVTgDjuhcZxaODqEaylQIZeNdfUb(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				vticasmmMRNOwDAIkashfEHCXOMUA.vqjXOcKWCpifEkrujSSXyVIRzRRJ(P_1);
			}
			else if ((uint)P_0 < (uint)bCgJIGYJOQecqNGgzLLvVSALMllo)
			{
				zBqZpdAeHFRZsDvwUlYyWTiEexwP[P_0].vqjXOcKWCpifEkrujSSXyVIRzRRJ(P_1);
			}
		}
	}

	public void SiMvrtBLGyGWgFWiViUqkeVcloTlA(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				vticasmmMRNOwDAIkashfEHCXOMUA.sqsvdofBgncMnnIdtrtovFpSOLDx(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)bCgJIGYJOQecqNGgzLLvVSALMllo)
			{
				zBqZpdAeHFRZsDvwUlYyWTiEexwP[P_0].sqsvdofBgncMnnIdtrtovFpSOLDx(P_1, P_2);
			}
		}
	}

	public void ZYNxQyhiUvbaslinKheXcrnmiXAab(int P_0)
	{
		if (P_0 == 9999999)
		{
			vticasmmMRNOwDAIkashfEHCXOMUA.xgZbuPfhIULHyDLJCOqeZpFlQyUvb();
		}
		else if ((uint)P_0 < (uint)bCgJIGYJOQecqNGgzLLvVSALMllo)
		{
			zBqZpdAeHFRZsDvwUlYyWTiEexwP[P_0].xgZbuPfhIULHyDLJCOqeZpFlQyUvb();
		}
	}

	private void MkOLuNxYmXFmQCoAzoawQydbwHCc()
	{
		if (UHkQplXUFxtYcRHKbUFQLoaMBXfDA.CstNvBWufBsIMBSVMwXHjTztSXlG > 0)
		{
			UHkQplXUFxtYcRHKbUFQLoaMBXfDA.QdTWyTRBdEYhySyGrvTnfiaBmzkP(-1, PmHCxACwyGCOFvVzcMTfWBGubFLGA(), jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Joystick), jflmIHcsvKPjKVoaEeCOheMyqMYK(ControllerType.Custom));
		}
		if (vticasmmMRNOwDAIkashfEHCXOMUA.CstNvBWufBsIMBSVMwXHjTztSXlG > 0)
		{
			Player.ControllerHelper controllers = vCrScoluoCmuwxzovJYKRzNsWVVh.LPpnIhYgEyRiiqljhjpHPsIBtMwL().controllers;
			vticasmmMRNOwDAIkashfEHCXOMUA.QdTWyTRBdEYhySyGrvTnfiaBmzkP(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < bCgJIGYJOQecqNGgzLLvVSALMllo; i++)
		{
			if (zBqZpdAeHFRZsDvwUlYyWTiEexwP[i].CstNvBWufBsIMBSVMwXHjTztSXlG != 0)
			{
				Player.ControllerHelper controllers2 = vCrScoluoCmuwxzovJYKRzNsWVVh.KsMyqZGefwiiNqZPSAVLfkWTitjv[i].controllers;
				zBqZpdAeHFRZsDvwUlYyWTiEexwP[i].QdTWyTRBdEYhySyGrvTnfiaBmzkP(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void uGhagEXrxHCGvjtOpDbwiRAKhWPKB(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count; i++)
		{
			if (FWbcnhfAKsZTQIrNXlsqskRjSZGn[i] != null)
			{
				HiqtTfVcmesmQoCVRQbOzVdYgNiU(FWbcnhfAKsZTQIrNXlsqskRjSZGn[i], P_0);
			}
		}
		for (int j = 0; j < uNhkbbQsJYbKTTFrzWJNxolhrdBU.Count; j++)
		{
			if (uNhkbbQsJYbKTTFrzWJNxolhrdBU[j] != null)
			{
				HiqtTfVcmesmQoCVRQbOzVdYgNiU(uNhkbbQsJYbKTTFrzWJNxolhrdBU[j], P_0);
			}
		}
		for (int k = 0; k < LizNnbYKXjebNHsTsYbvUTWOfEFG; k++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[k] != null)
			{
				HiqtTfVcmesmQoCVRQbOzVdYgNiU(FZgNAlfJkmHypqjgpNzeGlHXpLsC[k], P_0);
			}
		}
		HiqtTfVcmesmQoCVRQbOzVdYgNiU(kNqdGWwtvvyFNtOEDMCfxJLkkiZm, P_0);
	}

	private void HiqtTfVcmesmQoCVRQbOzVdYgNiU(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].mIchhRBlJrrWJwkTxxeMqxzcaKtO._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> XRreBdbBvDwUCdYLxSGEHDKbIPCCb<_0001>() where _0001 : IControllerTemplate
	{
		return nQLWEzVamBYwPXBUVXvltHEaCZG.SzWhVgbJYcDgvObEAFprenmWjSAdA<_0001>();
	}

	private void FIPpeKkGjgaqBsONXXqXwvVOfPMX(List<InputBehavior> P_0)
	{
		euRiBvhhhqEItpauKhxQMqPLmkky = ReInput.prxXuKwOwEjZuqOfmARKiCcLjOdAA;
		vCrScoluoCmuwxzovJYKRzNsWVVh = ReInput.VouJZmDPLGSEXPCTzKAxDlURnAgC;
		FWbcnhfAKsZTQIrNXlsqskRjSZGn = new List<Joystick>();
		uNhkbbQsJYbKTTFrzWJNxolhrdBU = new List<Joystick>();
		FZgNAlfJkmHypqjgpNzeGlHXpLsC = new List<CustomController>();
		ErZbikycOumhVMateMVWeYVITwh = euRiBvhhhqEItpauKhxQMqPLmkky.rteTWhhmTUbNhvGBYPwqrljVWpck;
		bCgJIGYJOQecqNGgzLLvVSALMllo = vCrScoluoCmuwxzovJYKRzNsWVVh.QgKBkzTWRhNyHSaqnbOBoqQdimmk;
		KqrzugKdczVpnyJuyrZstLWZSPvX = TvGTjdFYvrdCFoyMLFQCRlzcgYIu;
		MBfEDspxDCDOBJGFZjfTQJvpzbKVA = 0;
		YyuhEeAsrJaYabaOFATyppxvHECmA = new ADictionary<int, EqRmrQaGFnOJGWWwolzmXaPLiqgs>();
		YyuhEeAsrJaYabaOFATyppxvHECmA.Add(ReInput.players.GetSystemPlayer().id, new EqRmrQaGFnOJGWWwolzmXaPLiqgs(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			YyuhEeAsrJaYabaOFATyppxvHECmA.Add(players[i].id, new EqRmrQaGFnOJGWWwolzmXaPLiqgs(P_0));
		}
		ikzJXYpfpNqLRegRxidGEnmYbNle = new ReadOnlyCollection<Joystick>(FWbcnhfAKsZTQIrNXlsqskRjSZGn);
		oHLPFNPNqSJiXLqqWfsGaxCOJLhe = new ReadOnlyCollection<CustomController>(FZgNAlfJkmHypqjgpNzeGlHXpLsC);
		pDpcIvKINqIAQeDxKXPLLXNhacXfb.JWlSgvUToRRMlIFPTEAZeFChQwJZA(UtERKwcYqsmNympSVnYlLUrWjoVc);
		wkIyhRrbEiHwxGdGZyFSKXEhxpsiA = new pDpcIvKINqIAQeDxKXPLLXNhacXfb[(bCgJIGYJOQecqNGgzLLvVSALMllo + 1) * ErZbikycOumhVMateMVWeYVITwh];
		int num = 0;
		JyJxpNuEpJihVhxskXlElkvcunoN = new pDpcIvKINqIAQeDxKXPLLXNhacXfb[ErZbikycOumhVMateMVWeYVITwh];
		for (int j = 0; j < ErZbikycOumhVMateMVWeYVITwh; j++)
		{
			InputAction inputAction = euRiBvhhhqEItpauKhxQMqPLmkky.oMQPACIRpnYACfqGBeJpGOmEqEvHb(j);
			InputBehavior inputBehavior = YyuhEeAsrJaYabaOFATyppxvHECmA[9999999].pVXDMApNduphikSGKASbHyhAhrLe(inputAction.behaviorId);
			pDpcIvKINqIAQeDxKXPLLXNhacXfb pDpcIvKINqIAQeDxKXPLLXNhacXfb2 = new pDpcIvKINqIAQeDxKXPLLXNhacXfb(9999999, inputAction, inputBehavior, UtERKwcYqsmNympSVnYlLUrWjoVc);
			JyJxpNuEpJihVhxskXlElkvcunoN[j] = pDpcIvKINqIAQeDxKXPLLXNhacXfb2;
			wkIyhRrbEiHwxGdGZyFSKXEhxpsiA[num] = pDpcIvKINqIAQeDxKXPLLXNhacXfb2;
			num++;
		}
		SVKqEARWNHHYpltzzeucujeqcaQK = new pDpcIvKINqIAQeDxKXPLLXNhacXfb[bCgJIGYJOQecqNGgzLLvVSALMllo, ErZbikycOumhVMateMVWeYVITwh];
		for (int k = 0; k < bCgJIGYJOQecqNGgzLLvVSALMllo; k++)
		{
			for (int l = 0; l < ErZbikycOumhVMateMVWeYVITwh; l++)
			{
				InputAction inputAction2 = euRiBvhhhqEItpauKhxQMqPLmkky.oMQPACIRpnYACfqGBeJpGOmEqEvHb(l);
				InputBehavior inputBehavior2 = YyuhEeAsrJaYabaOFATyppxvHECmA[players[k].id].pVXDMApNduphikSGKASbHyhAhrLe(inputAction2.behaviorId);
				pDpcIvKINqIAQeDxKXPLLXNhacXfb pDpcIvKINqIAQeDxKXPLLXNhacXfb3 = new pDpcIvKINqIAQeDxKXPLLXNhacXfb(k, inputAction2, inputBehavior2, UtERKwcYqsmNympSVnYlLUrWjoVc);
				SVKqEARWNHHYpltzzeucujeqcaQK[k, l] = pDpcIvKINqIAQeDxKXPLLXNhacXfb3;
				wkIyhRrbEiHwxGdGZyFSKXEhxpsiA[num] = pDpcIvKINqIAQeDxKXPLLXNhacXfb3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.EUylEkfoKkBUEodVsyHiwCsvjWhO;
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
				CustomController customController = JlfQnWRmJLDrniFGUGXtiLXbIAIO(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					vCrScoluoCmuwxzovJYKRzNsWVVh.CdVzoIAGjOsZSBsVEHDGWSgvSrMu(num2)?.controllers.nzdlpZeTYGeEOshhRVOgjHBlWlxG(customController, false);
				}
			}
		}
		fRZZLVPSzIGTUfWRRdOxGZUPXlgI = new TWxrygPadDakJYMiziCpkvpWZYPZ();
		lVlblTjHbeWtFcEnyRPGeikXviSf = new TWxrygPadDakJYMiziCpkvpWZYPZ[bCgJIGYJOQecqNGgzLLvVSALMllo];
		for (int num3 = 0; num3 < bCgJIGYJOQecqNGgzLLvVSALMllo; num3++)
		{
			lVlblTjHbeWtFcEnyRPGeikXviSf[num3] = new TWxrygPadDakJYMiziCpkvpWZYPZ();
		}
		UHkQplXUFxtYcRHKbUFQLoaMBXfDA = new global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<ActiveControllerChangedDelegate>();
		vticasmmMRNOwDAIkashfEHCXOMUA = new global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<PlayerActiveControllerChangedDelegate>();
		zBqZpdAeHFRZsDvwUlYyWTiEexwP = new global::lnQrtrqUqMhpBinqxVNxyfOIGQGx<PlayerActiveControllerChangedDelegate>[vCrScoluoCmuwxzovJYKRzNsWVVh.QgKBkzTWRhNyHSaqnbOBoqQdimmk];
		ArrayTools.Populate(zBqZpdAeHFRZsDvwUlYyWTiEexwP);
	}

	private void vPQBcjOdBbgVgsjUExGxfrLghKgG(UpdateLoopType P_0)
	{
		int count = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = FWbcnhfAKsZTQIrNXlsqskRjSZGn[i];
			if (joystick.enabled)
			{
				tnaDMdidlvEIFqhyRNfdfxfalsEaA(joystick.MZCtZEbowVIlBMcZsRjgaqpVzpNg, joystick.rGVdhXruOTgLzoPtrwxfhKmroixX);
				joystick.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
			}
		}
		if (FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.enabled)
		{
			FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
		}
		else if (VFdjFviKyJhstNgWSvrBczaMwOrBA)
		{
			FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.BwTpcClexmNgVnZhgmPtFdErrEtr(P_0);
		}
		if (kNqdGWwtvvyFNtOEDMCfxJLkkiZm.enabled)
		{
			kNqdGWwtvvyFNtOEDMCfxJLkkiZm.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
		}
		int count2 = FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = FZgNAlfJkmHypqjgpNzeGlHXpLsC[j];
			if (customController.enabled)
			{
				customController.hyZPOQSauMHfukHKBKIsuFfWjbTQ();
				customController.EjKubThADKiQfHetvzpyLeiJitWy(P_0);
			}
		}
	}

	private void FZZnGFZFBacrXxpJwRRlGmAagmBr(UpdateLoopType P_0)
	{
		pDpcIvKINqIAQeDxKXPLLXNhacXfb.xQrswkXWPADlzsDKXhrtdeNSIDoMA(P_0);
		Player[] array = vCrScoluoCmuwxzovJYKRzNsWVVh.BJnQXsvCggAobdogrloHoqxDQfxkA;
		int num = array.Length;
		bool enabled = FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.enabled;
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
						AgmJhOyhXSMCbzyfGUGezPXlCZrGA.ElLAudxMQhhcgOpxeqrrUqaifmfjA(maps[j]);
					}
				}
			}
		}
		bool enabled2 = kNqdGWwtvvyFNtOEDMCfxJLkkiZm.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.sijUDNSCYgdaDbjDWiOmlxnPqYmKA(KqrzugKdczVpnyJuyrZstLWZSPvX);
			if (enabled || VFdjFviKyJhstNgWSvrBczaMwOrBA)
			{
				controllers.VBRwyPbnIhcWESmERmsFZtLHxaXD(FxNcIdqHMrMaWgeMBzAzXMMJFfmDA, AgmJhOyhXSMCbzyfGUGezPXlCZrGA, KqrzugKdczVpnyJuyrZstLWZSPvX);
			}
			if (enabled2)
			{
				controllers.PlXWZjDMvUIdTWIfQsUBHJPmGeUO(kNqdGWwtvvyFNtOEDMCfxJLkkiZm, KqrzugKdczVpnyJuyrZstLWZSPvX);
			}
			controllers.ZDFThfpXrBVnADmbYyqgsIXpcLSD(KqrzugKdczVpnyJuyrZstLWZSPvX);
		}
		for (int l = 0; l < wkIyhRrbEiHwxGdGZyFSKXEhxpsiA.Length; l++)
		{
			if (wkIyhRrbEiHwxGdGZyFSKXEhxpsiA[l].ZgrvynHUKRqAxICHkcgSxARjoZSI != pDpcIvKINqIAQeDxKXPLLXNhacXfb.KWsngVYJTImgQgDKWAEYbehTGJbQA.Disabled)
			{
				wkIyhRrbEiHwxGdGZyFSKXEhxpsiA[l].FfzyQKmZstToxbLhQQFeFMiRxWWV();
			}
		}
		pDpcIvKINqIAQeDxKXPLLXNhacXfb.zcdhaMUnPPbwKMjAMcbNbdVAjITVA();
		if (!ACUImyHYNChPWSLOutQMkMlRqJBGb)
		{
			return;
		}
		if (fRZZLVPSzIGTUfWRRdOxGZUPXlgI.kLaCoVbHCptLIYHQDrsQefYogvjY > 0)
		{
			for (int m = 0; m < ErZbikycOumhVMateMVWeYVITwh; m++)
			{
				pDpcIvKINqIAQeDxKXPLLXNhacXfb pDpcIvKINqIAQeDxKXPLLXNhacXfb2 = JyJxpNuEpJihVhxskXlElkvcunoN[m];
				if (pDpcIvKINqIAQeDxKXPLLXNhacXfb2.ZgrvynHUKRqAxICHkcgSxARjoZSI != pDpcIvKINqIAQeDxKXPLLXNhacXfb.KWsngVYJTImgQgDKWAEYbehTGJbQA.Disabled)
				{
					fRZZLVPSzIGTUfWRRdOxGZUPXlgI.bmSHoZIdYnxvAucGWAqmnBaBFuCA(pDpcIvKINqIAQeDxKXPLLXNhacXfb2, P_0);
				}
			}
		}
		for (int n = 0; n < bCgJIGYJOQecqNGgzLLvVSALMllo; n++)
		{
			TWxrygPadDakJYMiziCpkvpWZYPZ tWxrygPadDakJYMiziCpkvpWZYPZ = lVlblTjHbeWtFcEnyRPGeikXviSf[n];
			if (tWxrygPadDakJYMiziCpkvpWZYPZ.kLaCoVbHCptLIYHQDrsQefYogvjY == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < ErZbikycOumhVMateMVWeYVITwh; num2++)
			{
				pDpcIvKINqIAQeDxKXPLLXNhacXfb pDpcIvKINqIAQeDxKXPLLXNhacXfb3 = SVKqEARWNHHYpltzzeucujeqcaQK[n, num2];
				if (pDpcIvKINqIAQeDxKXPLLXNhacXfb3.ZgrvynHUKRqAxICHkcgSxARjoZSI != pDpcIvKINqIAQeDxKXPLLXNhacXfb.KWsngVYJTImgQgDKWAEYbehTGJbQA.Disabled)
				{
					tWxrygPadDakJYMiziCpkvpWZYPZ.bmSHoZIdYnxvAucGWAqmnBaBFuCA(pDpcIvKINqIAQeDxKXPLLXNhacXfb3, P_0);
				}
			}
		}
	}

	private void TvGTjdFYvrdCFoyMLFQCRlzcgYIu(bool P_0, int P_1, int P_2)
	{
		int num = euRiBvhhhqEItpauKhxQMqPLmkky.TZdqRkBElGhiTOcaFowdeDTzaUBEA(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				JyJxpNuEpJihVhxskXlElkvcunoN[num].aXtXIbwENIjHgrdYIQEBVESmEfRf(P_0);
			}
			else
			{
				SVKqEARWNHHYpltzzeucujeqcaQK[P_1, num].aXtXIbwENIjHgrdYIQEBVESmEfRf(P_0);
			}
		}
	}

	private void oeKfPjFjUiffaBtUtphseRVQYBwVA(BridgedController P_0)
	{
		int num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0.sourceJoystick.rewiredId, PyVbleShzFSJKsRyfexWiqUdCtoe.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = AOFYWEBWibrmNOqkmqXbbJyLwWOD(P_0.sourceJoystick.rewiredId, PyVbleShzFSJKsRyfexWiqUdCtoe.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = uNhkbbQsJYbKTTFrzWJNxolhrdBU[num];
			uNhkbbQsJYbKTTFrzWJNxolhrdBU.RemoveAt(num);
			joystick.EYikrxpnfSNNWknzAmyvpicqVjFt(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		FWbcnhfAKsZTQIrNXlsqskRjSZGn.Add(joystick);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Add(joystick);
		FWbcnhfAKsZTQIrNXlsqskRjSZGn.Sort(Joystick.jWCAdlZlNkwPBoECLxmLBEvfnIId);
		nQLWEzVamBYwPXBUVXvltHEaCZG.qFpuCelGxwvwkiFIaRKpdJlSeoVD(joystick);
	}

	private void vHmCsVdlwrCArWQoGyPCSJBxOdFSA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = FWbcnhfAKsZTQIrNXlsqskRjSZGn[P_0];
		joystick.isConnected = false;
		if (qOxhizSctttWJXBSYEtrjgFErgxfA != null)
		{
			qOxhizSctttWJXBSYEtrjgFErgxfA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (UYrMOMQnjyDiIUeItqbzgqvlXGLy != null)
		{
			UYrMOMQnjyDiIUeItqbzgqvlXGLy(joystick.type, joystick.id);
		}
		FWbcnhfAKsZTQIrNXlsqskRjSZGn.RemoveAt(P_0);
		uNhkbbQsJYbKTTFrzWJNxolhrdBU.Add(joystick);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Remove(joystick);
		nQLWEzVamBYwPXBUVXvltHEaCZG.PvAFaKDgcCoszaENHXDfaERHrlarc(joystick);
		joystick.gBKPqeqzjNmvysiIfrLGGzRfmdWS();
	}

	private void mDGLxJzLMRpAuOmIKEXJfqvmdlpx()
	{
		for (int num = FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count - 1; num >= 0; num--)
		{
			vHmCsVdlwrCArWQoGyPCSJBxOdFSA(num);
		}
	}

	private bool VYHmSLIcmQwnZkoppBEZxrcOioChA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count; i++)
		{
			if (FZgNAlfJkmHypqjgpNzeGlHXpLsC[i] == P_0)
			{
				return true;
			}
		}
		FZgNAlfJkmHypqjgpNzeGlHXpLsC.Add(P_0);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Add(P_0);
		nQLWEzVamBYwPXBUVXvltHEaCZG.qFpuCelGxwvwkiFIaRKpdJlSeoVD(P_0);
		return true;
	}

	private bool JzpasvUIojpAqImvpsBhyOBjfToI(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		nQLWEzVamBYwPXBUVXvltHEaCZG.PvAFaKDgcCoszaENHXDfaERHrlarc(P_0);
		hMuUeVnrUzMIhLarxxNEQfjNiQSIA.Remove(P_0);
		return FZgNAlfJkmHypqjgpNzeGlHXpLsC.Remove(P_0);
	}

	private TWxrygPadDakJYMiziCpkvpWZYPZ miwilMxABKnXjTPfijikGGRObeGP(int P_0)
	{
		if (P_0 == 9999999)
		{
			return fRZZLVPSzIGTUfWRRdOxGZUPXlgI;
		}
		if (P_0 < 0 || P_0 >= ReInput.VouJZmDPLGSEXPCTzKAxDlURnAgC.QgKBkzTWRhNyHSaqnbOBoqQdimmk)
		{
			return null;
		}
		return lVlblTjHbeWtFcEnyRPGeikXviSf[P_0];
	}

	private void TOlFiIcspDtZahIEyqfTuyNvBBtaA(bool P_0)
	{
		if (!P_0)
		{
			AgmJhOyhXSMCbzyfGUGezPXlCZrGA.kIAWTtWHiGEbERhpZeotDapeoUeGb();
		}
	}

	private void DFMxJKNuVaCcLEQUVZUcqhSXMCQp(bool P_0)
	{
		FxNcIdqHMrMaWgeMBzAzXMMJFfmDA.kPvFlhTMbqOrsGoGXbaCUFtGvwxE(P_0);
		kNqdGWwtvvyFNtOEDMCfxJLkkiZm.kPvFlhTMbqOrsGoGXbaCUFtGvwxE(P_0);
		for (int i = 0; i < FWbcnhfAKsZTQIrNXlsqskRjSZGn.Count; i++)
		{
			FWbcnhfAKsZTQIrNXlsqskRjSZGn[i].kPvFlhTMbqOrsGoGXbaCUFtGvwxE(P_0);
		}
		for (int j = 0; j < FZgNAlfJkmHypqjgpNzeGlHXpLsC.Count; j++)
		{
			FZgNAlfJkmHypqjgpNzeGlHXpLsC[j].kPvFlhTMbqOrsGoGXbaCUFtGvwxE(P_0);
		}
	}

	public void Dispose()
	{
		nKqDTRNBjOhtmzmDGtzrnDyjZzdM(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void JapXivOppMbGCkwElMpMLgpnEqFsA()
	{
		try
		{
			nKqDTRNBjOhtmzmDGtzrnDyjZzdM(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void nKqDTRNBjOhtmzmDGtzrnDyjZzdM(bool P_0)
	{
		if (mQjRLekpwQmOHkdsrjKLLBAVnePm)
		{
			return;
		}
		if (P_0)
		{
			if (yAAbjwzNrRyZvaavuFYWFDoBdLDxA is IDisposable)
			{
				(yAAbjwzNrRyZvaavuFYWFDoBdLDxA as IDisposable).Dispose();
			}
			if (mqOgzAqjgXGzRBzmnHdNpwiklLHnA is IDisposable)
			{
				(mqOgzAqjgXGzRBzmnHdNpwiklLHnA as IDisposable).Dispose();
			}
		}
		mQjRLekpwQmOHkdsrjKLLBAVnePm = true;
	}
}
