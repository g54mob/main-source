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

internal sealed class FbTdHcsBNUVZtBghOGVsEuhLuePk : IDisposable
{
	public enum GYebaZJoqelXtmRHZJpNEwyRGKCc
	{
		Connected = 0,
		Disconnected = 1
	}

	private class LwmHjbfqYMEmHGUgSkAXhjTjrcEo
	{
		public ADictionary<int, InputBehavior> CLyVZuCpVTmjjuMhSnBXCaBVaTQdA;

		public List<InputBehavior> efPamidaibXHTcIUpTLjkUcJRscvA;

		public IList<InputBehavior> lHSpViCtcjOAFFimBbBilCFKSCol;

		public LwmHjbfqYMEmHGUgSkAXhjTjrcEo(List<InputBehavior> P_0)
		{
			efPamidaibXHTcIUpTLjkUcJRscvA = new List<InputBehavior>(P_0.Count);
			CLyVZuCpVTmjjuMhSnBXCaBVaTQdA = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				CLyVZuCpVTmjjuMhSnBXCaBVaTQdA.Add(P_0[i].id, inputBehavior);
				efPamidaibXHTcIUpTLjkUcJRscvA.Add(inputBehavior);
				num++;
			}
			lHSpViCtcjOAFFimBbBilCFKSCol = new ReadOnlyCollection<InputBehavior>(efPamidaibXHTcIUpTLjkUcJRscvA);
		}

		public InputBehavior yOgZUtiKKXGXdsQKmtASnAgurehK(int P_0)
		{
			if (efPamidaibXHTcIUpTLjkUcJRscvA.Count == 0)
			{
				return null;
			}
			CLyVZuCpVTmjjuMhSnBXCaBVaTQdA.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return efPamidaibXHTcIUpTLjkUcJRscvA[0];
			}
			return value;
		}
	}

	private sealed class FBaFVwpifEvuypmoNgfRaIAGMMCiA : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int HhIctbSrNIyePFxLqTLZVDmvbZkHA;

		private CustomController pcNkUvbcSvfAaqZUCuOAXEnCtfkP;

		private int HiRanWCCoDzXJNORCbjWPbztEVcDA;

		public FbTdHcsBNUVZtBghOGVsEuhLuePk AXmVpPdOAYbwAiBugNcpMZTltSeIA;

		private int bzNcbjZsNqWyLADLAZeyGmhYifgQ;

		public int AtPaVLHItwJkVZpbGPpDLpOJjEon;

		private int hikVjfdOlZqoCbuHdFrXoXBpSaIW;

		private int TXjcsBFyytXPtHcVOtRDuvWDFUxW;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return pcNkUvbcSvfAaqZUCuOAXEnCtfkP;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return pcNkUvbcSvfAaqZUCuOAXEnCtfkP;
			}
		}

		[DebuggerHidden]
		public FBaFVwpifEvuypmoNgfRaIAGMMCiA(int P_0)
		{
			HhIctbSrNIyePFxLqTLZVDmvbZkHA = P_0;
			HiRanWCCoDzXJNORCbjWPbztEVcDA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int hhIctbSrNIyePFxLqTLZVDmvbZkHA = HhIctbSrNIyePFxLqTLZVDmvbZkHA;
			FbTdHcsBNUVZtBghOGVsEuhLuePk aXmVpPdOAYbwAiBugNcpMZTltSeIA = AXmVpPdOAYbwAiBugNcpMZTltSeIA;
			if (hhIctbSrNIyePFxLqTLZVDmvbZkHA != 0)
			{
				if (hhIctbSrNIyePFxLqTLZVDmvbZkHA != 1)
				{
					return false;
				}
				HhIctbSrNIyePFxLqTLZVDmvbZkHA = -1;
				goto IL_007d;
			}
			HhIctbSrNIyePFxLqTLZVDmvbZkHA = -1;
			hikVjfdOlZqoCbuHdFrXoXBpSaIW = aXmVpPdOAYbwAiBugNcpMZTltSeIA.QxTFLYmUoZgUuidbTguPudElbPWe.Count;
			TXjcsBFyytXPtHcVOtRDuvWDFUxW = 0;
			goto IL_008d;
			IL_007d:
			TXjcsBFyytXPtHcVOtRDuvWDFUxW++;
			goto IL_008d;
			IL_008d:
			if (TXjcsBFyytXPtHcVOtRDuvWDFUxW < hikVjfdOlZqoCbuHdFrXoXBpSaIW)
			{
				if (aXmVpPdOAYbwAiBugNcpMZTltSeIA.QxTFLYmUoZgUuidbTguPudElbPWe[TXjcsBFyytXPtHcVOtRDuvWDFUxW].sourceControllerId == bzNcbjZsNqWyLADLAZeyGmhYifgQ)
				{
					pcNkUvbcSvfAaqZUCuOAXEnCtfkP = aXmVpPdOAYbwAiBugNcpMZTltSeIA.QxTFLYmUoZgUuidbTguPudElbPWe[TXjcsBFyytXPtHcVOtRDuvWDFUxW];
					HhIctbSrNIyePFxLqTLZVDmvbZkHA = 1;
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
			FBaFVwpifEvuypmoNgfRaIAGMMCiA fBaFVwpifEvuypmoNgfRaIAGMMCiA;
			if (HhIctbSrNIyePFxLqTLZVDmvbZkHA == -2 && HiRanWCCoDzXJNORCbjWPbztEVcDA == Environment.CurrentManagedThreadId)
			{
				HhIctbSrNIyePFxLqTLZVDmvbZkHA = 0;
				fBaFVwpifEvuypmoNgfRaIAGMMCiA = this;
			}
			else
			{
				fBaFVwpifEvuypmoNgfRaIAGMMCiA = new FBaFVwpifEvuypmoNgfRaIAGMMCiA(0);
				fBaFVwpifEvuypmoNgfRaIAGMMCiA.AXmVpPdOAYbwAiBugNcpMZTltSeIA = AXmVpPdOAYbwAiBugNcpMZTltSeIA;
			}
			fBaFVwpifEvuypmoNgfRaIAGMMCiA.bzNcbjZsNqWyLADLAZeyGmhYifgQ = AtPaVLHItwJkVZpbGPpDLpOJjEon;
			return fBaFVwpifEvuypmoNgfRaIAGMMCiA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class HksJtsziTpzWxhMVjXHbhaNyOnRB : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int sthrWZNjaaIuehBUlbvYCEtLmMVIb;

		private CustomController WykusQyGgpEQSKqWSvxuFDetFAXB;

		private int RdygaKjedqNdFsVNelwMSqyVvfci;

		public FbTdHcsBNUVZtBghOGVsEuhLuePk gBpSPoqZBVOurMBoVneYyonMuTOg;

		private string XgvAocbkHqPxdHTlFklDqbpGgKPM;

		public string okNqrddIVsbuNDdkGgJexuUHXIXK;

		private int zDbaczUHgjaqsmileGBAcViUJaId;

		private int rKHNGDbPCsvAlymWbCNoCgOmAwCQ;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return WykusQyGgpEQSKqWSvxuFDetFAXB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return WykusQyGgpEQSKqWSvxuFDetFAXB;
			}
		}

		[DebuggerHidden]
		public HksJtsziTpzWxhMVjXHbhaNyOnRB(int P_0)
		{
			sthrWZNjaaIuehBUlbvYCEtLmMVIb = P_0;
			RdygaKjedqNdFsVNelwMSqyVvfci = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = sthrWZNjaaIuehBUlbvYCEtLmMVIb;
			FbTdHcsBNUVZtBghOGVsEuhLuePk fbTdHcsBNUVZtBghOGVsEuhLuePk = gBpSPoqZBVOurMBoVneYyonMuTOg;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				sthrWZNjaaIuehBUlbvYCEtLmMVIb = -1;
				goto IL_0083;
			}
			sthrWZNjaaIuehBUlbvYCEtLmMVIb = -1;
			zDbaczUHgjaqsmileGBAcViUJaId = fbTdHcsBNUVZtBghOGVsEuhLuePk.QxTFLYmUoZgUuidbTguPudElbPWe.Count;
			rKHNGDbPCsvAlymWbCNoCgOmAwCQ = 0;
			goto IL_0093;
			IL_0083:
			rKHNGDbPCsvAlymWbCNoCgOmAwCQ++;
			goto IL_0093;
			IL_0093:
			if (rKHNGDbPCsvAlymWbCNoCgOmAwCQ < zDbaczUHgjaqsmileGBAcViUJaId)
			{
				if (fbTdHcsBNUVZtBghOGVsEuhLuePk.QxTFLYmUoZgUuidbTguPudElbPWe[rKHNGDbPCsvAlymWbCNoCgOmAwCQ].tag.Equals(XgvAocbkHqPxdHTlFklDqbpGgKPM, StringComparison.OrdinalIgnoreCase))
				{
					WykusQyGgpEQSKqWSvxuFDetFAXB = fbTdHcsBNUVZtBghOGVsEuhLuePk.QxTFLYmUoZgUuidbTguPudElbPWe[rKHNGDbPCsvAlymWbCNoCgOmAwCQ];
					sthrWZNjaaIuehBUlbvYCEtLmMVIb = 1;
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
			HksJtsziTpzWxhMVjXHbhaNyOnRB hksJtsziTpzWxhMVjXHbhaNyOnRB;
			if (sthrWZNjaaIuehBUlbvYCEtLmMVIb == -2 && RdygaKjedqNdFsVNelwMSqyVvfci == Environment.CurrentManagedThreadId)
			{
				sthrWZNjaaIuehBUlbvYCEtLmMVIb = 0;
				hksJtsziTpzWxhMVjXHbhaNyOnRB = this;
			}
			else
			{
				hksJtsziTpzWxhMVjXHbhaNyOnRB = new HksJtsziTpzWxhMVjXHbhaNyOnRB(0);
				hksJtsziTpzWxhMVjXHbhaNyOnRB.gBpSPoqZBVOurMBoVneYyonMuTOg = gBpSPoqZBVOurMBoVneYyonMuTOg;
			}
			hksJtsziTpzWxhMVjXHbhaNyOnRB.XgvAocbkHqPxdHTlFklDqbpGgKPM = okNqrddIVsbuNDdkGgJexuUHXIXK;
			return hksJtsziTpzWxhMVjXHbhaNyOnRB;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> WEUziCawJTwcDEaRbKVDMINTCHkHA;

	private List<Joystick> jpKOzGFQYxRvQTPnJoQiNDxNipbo;

	private List<CustomController> QxTFLYmUoZgUuidbTguPudElbPWe;

	private List<Controller> cvBfkuJkVEDjyKBxBQuvGclCjAwqb;

	private ReadOnlyCollection<Controller> uCpGvDbMaJCsGQWbTYdmqCvRrgtJ;

	private Keyboard KdgGMSjqXKFUDuQQbblYpDWdDvYy;

	private Mouse zTHyQdnkuGTcOtEOrfvIbZFKGqvFA;

	private ConfigVars RPvNIFbOxLHZbiTdtCFAlnYgdAQJ;

	private gjGAZYHMtBrBPTgtywbcfPTZqEdL[] tJtaxmAyRDjHsFpYnzmhslWDAdCNA;

	private gjGAZYHMtBrBPTgtywbcfPTZqEdL[] IPqBxocrumtIASrcUvKxIVzQlrSdb;

	private gjGAZYHMtBrBPTgtywbcfPTZqEdL[,] XarFcvIbIoOmghojTiRNGRmSkqwU;

	private qBmpMUOLStHEYgGorZQuTYzZgBuC PgZmhnvJSjfbaAptimpJFVJRSJFpA;

	private QCMhwFAkemVHUWtsLnxYTCvaAOlv oXqvLuINunuvJjNPxKGIsXUbgZIU;

	private QCMhwFAkemVHUWtsLnxYTCvaAOlv[] kbEruIksdNxKQirkKwrEKuvvvqvb;

	private global::qobntIdEvhcGMeooPLoKGQSmqCys<ActiveControllerChangedDelegate> FeNErWALOSctvRXQXnidnEgazLZo;

	private global::qobntIdEvhcGMeooPLoKGQSmqCys<PlayerActiveControllerChangedDelegate> yBDyMVpjJqbclHZOOXREcTBkYwif;

	private global::qobntIdEvhcGMeooPLoKGQSmqCys<PlayerActiveControllerChangedDelegate>[] cZFavYHHKeXevRPusDvPUgumRfYJA;

	private ADictionary<int, LwmHjbfqYMEmHGUgSkAXhjTjrcEo> XsJMGFRBmkRvnumGxscPZsjVcSgS;

	private readonly HiQYFvQnIapBdxxovqraTdXiGgLw idvLRdgjKRwPpNoBmcOENhruAaju;

	private IList<Joystick> djURClcoJuXGIcGuDROxyopwhFHK;

	private IList<CustomController> xluNdwCcMreWATwuyAYnUdCcRpJd;

	private int qOOQaUllBRSDPuoyJFQYARERuQGRA;

	private bool YbAxZIJPnyjVmobQcfUmJwyuXEPX;

	private bool LYpTqFTRIjJyPLfAWWvvyOnlrBfp;

	private bool LPYbdndIRxqVjCFAmnvugBNrQCyx;

	private IUnifiedKeyboardSource furddRoEakJicakzWjxzdcmvFDhDA;

	private IUnifiedMouseSource vPfwzjbKjunQQhcyHfQiAImMvZtPA;

	private int LEOBTVFiKlBnQPSDhRAwyxfHJniOA;

	private HGmrzRPfohKeKWRglmOSyhGDDlzFA nmfmSCoqXhdqnpsaTMnWuTdAwSNA;

	private hSQdAZAaMRJsyVvNAYTUQfKIxyBHA ubIgcZcYpphXxlemTyblzkDIvMbO;

	private int yjRLQdHMTxOFhZNmZFaYifCjMvJqA;

	private int XfIFpNdCxnPnkFQcBZmkodMlESYo;

	private Action<int, ControllerDataUpdater> auTYQSqqmAxVIdDavGIGLOfWdeuU;

	private Action<bool, int, int> ZrEEqTKZxGwQucpcOBoFTKKdCDReA;

	private Action<ControllerStatusChangedEventArgs> pPCRyELCkMYvIHZCaASYKIDyVsZw;

	private Action<ControllerType, int> NzGKMvHtuBPJZIjKNBKKiIfHkQjab;

	private bool nrQZIXtXdlXKWaFoBKKydKQpJjzr;

	public IList<Joystick> lKwdUsCXdtSuRQQrSNnwQMfcqIRXA => djURClcoJuXGIcGuDROxyopwhFHK;

	public List<Joystick> vqiHFnQcuglhicihtzKxSejtDJMR => WEUziCawJTwcDEaRbKVDMINTCHkHA;

	public int pwyKpsUfOHnkYjLOCiQAqFosrZvs => WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;

	public Mouse DSSddfFhMNEuZUeDpMEBaimidxHxB => zTHyQdnkuGTcOtEOrfvIbZFKGqvFA;

	public Keyboard DgfFcsFEypGvKCatIhkeSdaWtzwHc => KdgGMSjqXKFUDuQQbblYpDWdDvYy;

	public IList<CustomController> VciiLHzZwsMOLBgQDNuKLdDrPvph => xluNdwCcMreWATwuyAYnUdCcRpJd;

	public List<CustomController> rcpJMtenDjVGLnDKsKjGXeZVbvIiA => QxTFLYmUoZgUuidbTguPudElbPWe;

	public int OJSBCxBHDCPIwHiTOpUPcRusrxJc => QxTFLYmUoZgUuidbTguPudElbPWe.Count;

	public IList<Controller> gqOcGSxyswTTNjzDQfvsXtCfRjKw => uCpGvDbMaJCsGQWbTYdmqCvRrgtJ;

	public int kCjfQealhxhSiAHGGVnNNxKWgzdP => cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Count;

	private int QRYCLWaYaXUrAOiajKiOGOsfRflcA
	{
		get
		{
			int lEOBTVFiKlBnQPSDhRAwyxfHJniOA = LEOBTVFiKlBnQPSDhRAwyxfHJniOA;
			LEOBTVFiKlBnQPSDhRAwyxfHJniOA++;
			if (LEOBTVFiKlBnQPSDhRAwyxfHJniOA >= int.MaxValue)
			{
				LEOBTVFiKlBnQPSDhRAwyxfHJniOA = 0;
			}
			return lEOBTVFiKlBnQPSDhRAwyxfHJniOA;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> lCUuYvUDisNZzzaZIcCQiCWFCxPfb
	{
		add
		{
			pPCRyELCkMYvIHZCaASYKIDyVsZw = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(pPCRyELCkMYvIHZCaASYKIDyVsZw, b);
		}
		remove
		{
			pPCRyELCkMYvIHZCaASYKIDyVsZw = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(pPCRyELCkMYvIHZCaASYKIDyVsZw, value2);
		}
	}

	public event Action<ControllerType, int> NMtIsxMWGlrzzHjmHwogmBBcMlwK
	{
		add
		{
			NzGKMvHtuBPJZIjKNBKKiIfHkQjab = (Action<ControllerType, int>)Delegate.Combine(NzGKMvHtuBPJZIjKNBKKiIfHkQjab, b);
		}
		remove
		{
			NzGKMvHtuBPJZIjKNBKKiIfHkQjab = (Action<ControllerType, int>)Delegate.Remove(NzGKMvHtuBPJZIjKNBKKiIfHkQjab, value2);
		}
	}

	public FbTdHcsBNUVZtBghOGVsEuhLuePk(ConfigVars P_0, PlatformInputManager P_1)
	{
		RPvNIFbOxLHZbiTdtCFAlnYgdAQJ = P_0;
		qOOQaUllBRSDPuoyJFQYARERuQGRA = 0;
		YbAxZIJPnyjVmobQcfUmJwyuXEPX = UnityTools.isAndroidPlatform;
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb = new List<Controller>(10);
		uCpGvDbMaJCsGQWbTYdmqCvRrgtJ = new ReadOnlyCollection<Controller>(cvBfkuJkVEDjyKBxBQuvGclCjAwqb);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (furddRoEakJicakzWjxzdcmvFDhDA = new UnityUnifiedKeyboardSource());
		}
		KdgGMSjqXKFUDuQQbblYpDWdDvYy = new Keyboard("Keyboard", unifiedKeyboardSource);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Add(KdgGMSjqXKFUDuQQbblYpDWdDvYy);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (vPfwzjbKjunQQhcyHfQiAImMvZtPA = new UnityUnifiedMouseSource());
		}
		zTHyQdnkuGTcOtEOrfvIbZFKGqvFA = new Mouse("Mouse", unifiedMouseSource);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Add(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA);
		PgZmhnvJSjfbaAptimpJFVJRSJFpA = new qBmpMUOLStHEYgGorZQuTYzZgBuC(P_0.updateLoop, KdgGMSjqXKFUDuQQbblYpDWdDvYy);
		KdgGMSjqXKFUDuQQbblYpDWdDvYy.IIIhsSunUeAPwsOElcOCmgPSHxiU += UNEValtgkiXghWuIImEaCOVFwRBs;
		KdgGMSjqXKFUDuQQbblYpDWdDvYy.enabled = !P_0.GetPlatformVar_disableKeyboard();
		zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.enabled = !P_0.GetPlatformVar_disableMouse();
		MRKePyazVTmdOdidqsXOcYtQuvkU.KYpyiLRWepHOREXafEuLrfDJpMTP();
		idvLRdgjKRwPpNoBmcOENhruAaju = new HiQYFvQnIapBdxxovqraTdXiGgLw(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		idvLRdgjKRwPpNoBmcOENhruAaju.nfEkqZqZRNUInmTJUkYYXDLywkdD(KdgGMSjqXKFUDuQQbblYpDWdDvYy);
		idvLRdgjKRwPpNoBmcOENhruAaju.nfEkqZqZRNUInmTJUkYYXDLywkdD(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA);
		ReInput.ApplicationFocusChangedEvent += KndaPvECCTaZSaGMfrpLGEIdnOHeE;
	}

	public void ipDezDqkBwVXiSFhMdzDIOOywaDb(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		auTYQSqqmAxVIdDavGIGLOfWdeuU = P_0;
		CFefRfzEmBJRCmaNvwZsAJPeiFsR(P_1);
	}

	public void MlOpAQKRAybotEIhyWbnGpGVwDBr(UpdateLoopType P_0)
	{
		MRKePyazVTmdOdidqsXOcYtQuvkU.PxwxeMOoxWJDvemdJPqrEHomaNQCA(P_0);
		if (KdgGMSjqXKFUDuQQbblYpDWdDvYy.enabled)
		{
			PgZmhnvJSjfbaAptimpJFVJRSJFpA.IDlFBhEfrpOdEGInupPvGCQCjhTyB(P_0);
		}
		azwXGBLEETFlceYsLGQIDHGKhAGB(P_0);
		WBkpfkKFYVhOGjKPGBiYkwSAJapw(P_0);
		MRKePyazVTmdOdidqsXOcYtQuvkU.ByFcaqttpHJyDMxOSwpqpBrfthDT(P_0, ReInput.currentFrame);
		if (LPYbdndIRxqVjCFAmnvugBNrQCyx)
		{
			DizZoNaAJggDfKrcFHBXeJaJuCfL();
		}
	}

	public gjGAZYHMtBrBPTgtywbcfPTZqEdL pXjAKwLoAxucOfGKCbnMfuaMGTchA(int P_0, string P_1, bool P_2)
	{
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.FPoTsijAGQiZSfqTEonVRgnRBHCBA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return IPqBxocrumtIASrcUvKxIVzQlrSdb[num];
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return null;
		}
		return XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, num];
	}

	public gjGAZYHMtBrBPTgtywbcfPTZqEdL FVwxqLXNDbqPFnJzEdgojSDlcRBwA(int P_0, int P_1, bool P_2)
	{
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.WaOsqNIhktcJIChspDZEFYLNIIjmA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return IPqBxocrumtIASrcUvKxIVzQlrSdb[num];
		}
		return XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, num];
	}

	public void SxRkbErhvMRGlwEustkcZBagXdQX(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			GYebaZJoqelXtmRHZJpNEwyRGKCc gYebaZJoqelXtmRHZJpNEwyRGKCc = GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected;
			int num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0.sourceJoystick.rewiredId, gYebaZJoqelXtmRHZJpNEwyRGKCc);
			if (num < 0)
			{
				gYebaZJoqelXtmRHZJpNEwyRGKCc = GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected;
				num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0.sourceJoystick.rewiredId, gYebaZJoqelXtmRHZJpNEwyRGKCc);
			}
			if (num >= 0)
			{
				((gYebaZJoqelXtmRHZJpNEwyRGKCc == GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected) ? WEUziCawJTwcDEaRbKVDMINTCHkHA[num] : jpKOzGFQYxRvQTPnJoQiNDxNipbo[num]).UWknkCEkhjstkPKKGHTFOZkVrLTI(P_0);
			}
		}
	}

	public bool ICMNeHEzValGkkToLLkyktNEYAxj(int P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc P_1)
	{
		if (RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int RvqUxWCHxUMYHKmISPGKVBzvqQaD(int P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc P_1)
	{
		switch (P_1)
		{
		case GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected:
		{
			int count2 = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (WEUziCawJTwcDEaRbKVDMINTCHkHA[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected:
		{
			int count = jpKOzGFQYxRvQTPnJoQiNDxNipbo.Count;
			for (int i = 0; i < count; i++)
			{
				if (jpKOzGFQYxRvQTPnJoQiNDxNipbo[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int QkHotuuwZxPgbHODGlRhBHwOHqTo(Guid P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc P_1)
	{
		switch (P_1)
		{
		case GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected:
		{
			int count2 = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (WEUziCawJTwcDEaRbKVDMINTCHkHA[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected:
		{
			int count = jpKOzGFQYxRvQTPnJoQiNDxNipbo.Count;
			for (int i = 0; i < count; i++)
			{
				if (jpKOzGFQYxRvQTPnJoQiNDxNipbo[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool VujhBgLFBCOvgNmRVqVkCcpzHcAO(int P_0)
	{
		if (FenLWxUXQTUalycogDkMjbaIbOQiA(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int FenLWxUXQTUalycogDkMjbaIbOQiA(int P_0)
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		for (int i = 0; i < count; i++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int WeswsgrsRqeTlKJlmTUQpACwSSgC(Guid P_0)
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		for (int i = 0; i < count; i++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void clKFqwIKysanEZWrUeaCuefTbcVN(BridgedController P_0)
	{
		bijrZUYVBBdKzrnAZDENrvLsYROq(P_0);
	}

	public void xkmKkOpiPJfdujbpjveAfHrLNLgEb(int P_0)
	{
		int num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected);
		cYZxswwKbCabkeEwocaxspVVEprnA(num);
	}

	public int CrRsgImokLPbGOkrFjDfwLvCrGMQ()
	{
		return qOOQaUllBRSDPuoyJFQYARERuQGRA++;
	}

	public IList<InputBehavior> KPosqjUxyvnPglXSXWmDpcrqwcsK(int P_0)
	{
		if (!XsJMGFRBmkRvnumGxscPZsjVcSgS.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return XsJMGFRBmkRvnumGxscPZsjVcSgS[P_0].lHSpViCtcjOAFFimBbBilCFKSCol;
	}

	public InputBehavior ZJftCxyafRgHdKBNXPAUKBOxxqAiA(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return MrZdBRkTKSFptotNpZzmHmxWnIYX(P_0, inputBehaviorId);
	}

	public InputBehavior MrZdBRkTKSFptotNpZzmHmxWnIYX(int P_0, int P_1)
	{
		if (!XsJMGFRBmkRvnumGxscPZsjVcSgS.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> lHSpViCtcjOAFFimBbBilCFKSCol = XsJMGFRBmkRvnumGxscPZsjVcSgS[P_0].lHSpViCtcjOAFFimBbBilCFKSCol;
		for (int i = 0; i < lHSpViCtcjOAFFimBbBilCFKSCol.Count; i++)
		{
			if (lHSpViCtcjOAFFimBbBilCFKSCol[i].id == P_1)
			{
				return lHSpViCtcjOAFFimBbBilCFKSCol[i];
			}
		}
		return null;
	}

	public Joystick oisDKJWbKjPOgFFsCBsSMlVpdULY(int P_0, bool P_1 = false)
	{
		int num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected);
		if (num >= 0)
		{
			return WEUziCawJTwcDEaRbKVDMINTCHkHA[num];
		}
		if (P_1)
		{
			num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected);
			if (num >= 0)
			{
				return jpKOzGFQYxRvQTPnJoQiNDxNipbo[num];
			}
		}
		return null;
	}

	public Joystick vEMjSxbhJShbyRDbJGuoxWtvfOSjA(Guid P_0, bool P_1 = false)
	{
		int num = QkHotuuwZxPgbHODGlRhBHwOHqTo(P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected);
		if (num >= 0)
		{
			return WEUziCawJTwcDEaRbKVDMINTCHkHA[num];
		}
		if (P_1)
		{
			num = QkHotuuwZxPgbHODGlRhBHwOHqTo(P_0, GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected);
			if (num >= 0)
			{
				return jpKOzGFQYxRvQTPnJoQiNDxNipbo[num];
			}
		}
		return null;
	}

	public Joystick[] eUHZqjMCLNJbpsmFgevMpIqbDiej()
	{
		int count = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = WEUziCawJTwcDEaRbKVDMINTCHkHA[i];
		}
		return array;
	}

	public string[] pJlyPhggDGIMvGPiTkIHbwDadsPDb()
	{
		int count = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = WEUziCawJTwcDEaRbKVDMINTCHkHA[i].name;
		}
		return array;
	}

	public CustomController WZjCApZPCCEVYhDYjCkwqlyTROem(int P_0)
	{
		int num = FenLWxUXQTUalycogDkMjbaIbOQiA(P_0);
		if (num < 0)
		{
			return null;
		}
		return QxTFLYmUoZgUuidbTguPudElbPWe[num];
	}

	public CustomController JJpdhXjAsrvyoMiYOcEPrVmyzrJaA(Guid P_0)
	{
		int num = WeswsgrsRqeTlKJlmTUQpACwSSgC(P_0);
		if (num < 0)
		{
			return null;
		}
		return QxTFLYmUoZgUuidbTguPudElbPWe[num];
	}

	public CustomController[] PhjBzhagGkZWQIykZHpwNGjclUBgA()
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = QxTFLYmUoZgUuidbTguPudElbPWe[i];
		}
		return array;
	}

	public string[] wGqnLRCAShTniHgdCTFZJYxjnbzF()
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = QxTFLYmUoZgUuidbTguPudElbPWe[i].name;
		}
		return array;
	}

	public CustomController OnAhnnQHKixkcuMWkpqEUJNLAIkDA(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int tULpMEvsvmFbEKvUYhOpTQMeLHWbb = QRYCLWaYaXUrAOiajKiOGOsfRflcA;
		CustomController customController = new CustomController(new rLcHvetlHEOCUXxKJOdROkyhUscr
		{
			sPhrgWptXqBEBTRDXsBFkoEIYgMB = InputSource.Custom,
			TpQCcdPZonOaYNIdkxnuGNGckjmW = customControllerById.descriptiveName,
			zyFfblnamxnVQFngKeRVXUzwsBKO = customControllerById.name,
			lKEjuhtBshHmaMmqIlPhXMpxCIVHA = customControllerById.axisCount,
			WTLyQhSMIiIeAzHOyFCyRZNuPMrf = customControllerById.buttonCount,
			tULpMEvsvmFbEKvUYhOpTQMeLHWbb = tULpMEvsvmFbEKvUYhOpTQMeLHWbb,
			nieNuHKRLmMeCtqjczXCJHkqJCrV = customControllerById.id,
			ICSFvCapUauhyntyogCZzWEbSNwn = customControllerById.typeGuid,
			rOCacgdVrAxKNvFGxDXygNSbvWPYA = customControllerById.id.ToString(),
			CEPLBnsuBAwAlEbfrizRAtWZSPSrA = customControllerById.CreateGameHardwareMap()
		});
		MzqjSsVChbyEKeZnDGjkTjkysgeq(customController);
		return customController;
	}

	public bool vVaNtReLpaETTeJmaNXzneLjNwOq(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return KwEmiYLBnWGGbSBjRFLYWuTHYpWn(P_0);
	}

	public CustomController teyfxtHcBfhvpaslJtmzfxQUVcVeA(int P_0)
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		for (int i = 0; i < count; i++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[i].sourceControllerId == P_0)
			{
				return QxTFLYmUoZgUuidbTguPudElbPWe[i];
			}
		}
		return null;
	}

	public CustomController YVgBOQlieUBNhDhJIpLaBhPtUfMF(string P_0)
	{
		int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		for (int i = 0; i < count; i++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return QxTFLYmUoZgUuidbTguPudElbPWe[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(FBaFVwpifEvuypmoNgfRaIAGMMCiA))]
	public IEnumerable<CustomController> yqrTpxNlpMNoroFizbZaqytpPnuB(int P_0)
	{
		return new FBaFVwpifEvuypmoNgfRaIAGMMCiA(-2)
		{
			AXmVpPdOAYbwAiBugNcpMZTltSeIA = this,
			AtPaVLHItwJkVZpbGPpDLpOJjEon = P_0
		};
	}

	[IteratorStateMachine(typeof(HksJtsziTpzWxhMVjXHbhaNyOnRB))]
	public IEnumerable<CustomController> hNQVlAMhrTLbkunbgHrSeqpXifLq(string P_0)
	{
		return new HksJtsziTpzWxhMVjXHbhaNyOnRB(-2)
		{
			gBpSPoqZBVOurMBoVneYyonMuTOg = this,
			okNqrddIVsbuNDdkGgJexuUHXIXK = P_0
		};
	}

	public Controller QCDDZTfeTGMbmcEJicshLRdxImzvA(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => oisDKJWbKjPOgFFsCBsSMlVpdULY(P_1, P_2), 
			ControllerType.Keyboard => KdgGMSjqXKFUDuQQbblYpDWdDvYy, 
			ControllerType.Mouse => zTHyQdnkuGTcOtEOrfvIbZFKGqvFA, 
			ControllerType.Custom => WZjCApZPCCEVYhDYjCkwqlyTROem(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller IWHTkDTWwMdxIsaOjphjbpfVESum(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return baqeETblTONKYgfPwUMfZdcxhmHzA(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return QCDDZTfeTGMbmcEJicshLRdxImzvA(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller baqeETblTONKYgfPwUMfZdcxhmHzA(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (KdgGMSjqXKFUDuQQbblYpDWdDvYy.deviceInstanceGuid == P_0)
		{
			return KdgGMSjqXKFUDuQQbblYpDWdDvYy;
		}
		if (zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.deviceInstanceGuid == P_0)
		{
			return zTHyQdnkuGTcOtEOrfvIbZFKGqvFA;
		}
		Controller result;
		if ((result = vEMjSxbhJShbyRDbJGuoxWtvfOSjA(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = JJpdhXjAsrvyoMiYOcEPrVmyzrJaA(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] vHymXCtKkrGqQEWRSDiJEfInGXbGA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => eUHZqjMCLNJbpsmFgevMpIqbDiej(), 
			ControllerType.Keyboard => new Controller[1] { KdgGMSjqXKFUDuQQbblYpDWdDvYy }, 
			ControllerType.Mouse => new Controller[1] { zTHyQdnkuGTcOtEOrfvIbZFKGqvFA }, 
			ControllerType.Custom => PhjBzhagGkZWQIykZHpwNGjclUBgA(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] lwyfLXcmbpSkNMOPSJjvcrjMDxkSA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => pJlyPhggDGIMvGPiTkIHbwDadsPDb(), 
			ControllerType.Keyboard => new string[1] { KdgGMSjqXKFUDuQQbblYpDWdDvYy.name }, 
			ControllerType.Mouse => new string[1] { zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.name }, 
			ControllerType.Custom => wGqnLRCAShTniHgdCTFZJYxjnbzF(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void bMBlCBFzxJHlHzPxwktZdUrhaDZd(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.rSBfqyiorrSgUZpqdemCEZwxKjYQ(P_1, P_2, InputActionEventType.Update, null);
	}

	public void RDVgHOVVkWDWMdnyUKiqOgTgSkkV(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.XdfjOElOglXttuCMHpduSOhCfBuV(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void DOzOKLLENpsHwYnWLCorkYmoppRBA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_3);
		if (num >= 0)
		{
			RDVgHOVVkWDWMdnyUKiqOgTgSkkV(P_0, P_1, P_2, num);
		}
	}

	public void LzfRBcvhvzjmiQisimVvvPcZjCPdA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.rSBfqyiorrSgUZpqdemCEZwxKjYQ(P_1, P_2, P_3, P_4);
	}

	public void EbqGOyIHMSkOduOugMijjFmBSpoZb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.XdfjOElOglXttuCMHpduSOhCfBuV(P_1, P_2, P_3, P_4, P_5);
	}

	public void VIgUmduTexhbiqnjbszapKHdIvfO(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			LYpTqFTRIjJyPLfAWWvvyOnlrBfp = true;
		}
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_4);
		if (num >= 0)
		{
			EbqGOyIHMSkOduOugMijjFmBSpoZb(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void ZzcGBAoteqlTjXXLrkEMDniTBcWZ(int P_0, Action<InputActionEventData> P_1)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.uVXxCkXywkJUzwQTZuVQybGBjgHjA(P_1);
	}

	public void XhSAETyPejOHZRLLsHJgimtHmHlib(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.ykNLpRfJFZcUUTLlGRQJOwxYepx(P_1, P_2);
	}

	public void cNqbdjkmslcAmvcXhkoUkOnADDjQA(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_2);
		if (num >= 0)
		{
			XhSAETyPejOHZRLLsHJgimtHmHlib(P_0, P_1, num);
		}
	}

	public void viKFbRCcoMBXUfBGeWgKeKoCKfuuc(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.ozsvZcieTVbyZpIJbabNsFOmWrHN(P_1, P_2);
	}

	public void kJvqhSTntFTtVHAMrmwNhCvoPulj(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.joWkeUoHWKNWecRKzZGfpFPUAxmu(P_1, P_2);
	}

	public void OHUuKleGKYxnAWYNOkNkhxeasEqT(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.tjSzIuiqPMBrdjaHqxOTLFnJpAnbA(P_1, P_2, P_3);
	}

	public void nDIXiaKhvGJPBgLsiOteKWIzcpml(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_3);
		if (num >= 0)
		{
			OHUuKleGKYxnAWYNOkNkhxeasEqT(P_0, P_1, P_2, num);
		}
	}

	public void agfALxrwtQaXnJXduUuCjedeIyks(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.ZydQKCFJHxZXOrDemwwoyWeJuOcC(P_1, P_2, P_3);
	}

	public void jnwFrYGTTXHjYNtbhjlAFiPraLWAb(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_3);
		if (num >= 0)
		{
			agfALxrwtQaXnJXduUuCjedeIyks(P_0, P_1, P_2, num);
		}
	}

	public void wvIAjIbpzxWBrlIzMNzYryShfUWc(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.PiQFIxZrevGpiKsziHBEElIbxyfKb(P_1, P_2, P_3);
	}

	public void iQFvxIKYauoqAbPWupQoKBPsXtcG(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.xsaMKluLGKFdcBEfBFMflIuHBfSgA(P_1, P_2, P_3, P_4);
	}

	public void EXyceLTgNdhqgKiayrPxqoJJEogoA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB.urxGYFBOdknWEgSSRLCNrMdqeLifb(P_4);
		if (num >= 0)
		{
			iQFvxIKYauoqAbPWupQoKBPsXtcG(P_0, P_1, P_2, P_3, num);
		}
	}

	public void OHGGbCvlibDdnGNgzpBbSdnDrgrM(int P_0)
	{
		nJXmjWcQdUMohJdDAEJSmHhewfoe(P_0)?.KnRGVyiPMMgwKDCgygXNcxUhCTgbc();
	}

	public bool haEfTicuoCJaJBrzcccAWZTIjpiNc(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].FuonpZfnMsIoctilHoaxyYdyBhPe())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].FuonpZfnMsIoctilHoaxyYdyBhPe())
			{
				return true;
			}
		}
		return false;
	}

	public bool rtafuaHzVCVbOeVeVWwzqBRVThxQA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].mZHiYnhZVMTDhjZLvRUEntHJjuHw())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].mZHiYnhZVMTDhjZLvRUEntHJjuHw())
			{
				return true;
			}
		}
		return false;
	}

	public bool oySEjlYobOvDlDJLpzZkKyQklTRP(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].iqFazvtbRNuTyRjsZusNMBvfGFtk())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].iqFazvtbRNuTyRjsZusNMBvfGFtk())
			{
				return true;
			}
		}
		return false;
	}

	public bool eKOEuHOvqcFaAzoaeDXcvjOfEKst(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].eaIDsdFDPMpzBFuLLeduvIngcxyu())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].eaIDsdFDPMpzBFuLLeduvIngcxyu())
			{
				return true;
			}
		}
		return false;
	}

	public bool kmBvtfTMVVlqyupOvhdcHEtRFzzz(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].LJmoiCBrurlAHBkmMLoPOkULXlcW())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].LJmoiCBrurlAHBkmMLoPOkULXlcW())
			{
				return true;
			}
		}
		return false;
	}

	public bool xbycMseyCLktzoJOWbznmZqmHxzHA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].XBGdRySTTRFUMBwxafaWnApTtRmJA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].XBGdRySTTRFUMBwxafaWnApTtRmJA())
			{
				return true;
			}
		}
		return false;
	}

	public bool lSCnwYdMmXAxSGjTIEqLlyqzLUkb(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].YVCTqAOcuTWFVseiADubHQfIHfvNA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].YVCTqAOcuTWFVseiADubHQfIHfvNA())
			{
				return true;
			}
		}
		return false;
	}

	public bool OVLYdHHnuhvtzfzGBrxEeNzslnRQ(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < IPqBxocrumtIASrcUvKxIVzQlrSdb.Length; i++)
			{
				if (IPqBxocrumtIASrcUvKxIVzQlrSdb[i].lWFlSmMbcEHZkEyFhvQJUQnAIBhtA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			return false;
		}
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		for (int j = 0; j < num; j++)
		{
			if (XarFcvIbIoOmghojTiRNGRmSkqwU[P_0, j].lWFlSmMbcEHZkEyFhvQJUQnAIBhtA())
			{
				return true;
			}
		}
		return false;
	}

	public bool ROnSgHmAByOeqDoIhfJceJogSKMo()
	{
		if (!cztcpssAKIINHgMGsmTRnJrYfQXJA(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA) && !EkEPuMiVqOHqVYAlYqzVqNRKdZfJ(WEUziCawJTwcDEaRbKVDMINTCHkHA) && !cztcpssAKIINHgMGsmTRnJrYfQXJA(KdgGMSjqXKFUDuQQbblYpDWdDvYy))
		{
			return EkEPuMiVqOHqVYAlYqzVqNRKdZfJ(QxTFLYmUoZgUuidbTguPudElbPWe);
		}
		return true;
	}

	public bool eHKmQgpiFkgpcxJqhrelfjflvyll(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => EkEPuMiVqOHqVYAlYqzVqNRKdZfJ(WEUziCawJTwcDEaRbKVDMINTCHkHA), 
			ControllerType.Keyboard => cztcpssAKIINHgMGsmTRnJrYfQXJA(KdgGMSjqXKFUDuQQbblYpDWdDvYy), 
			ControllerType.Mouse => cztcpssAKIINHgMGsmTRnJrYfQXJA(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA), 
			ControllerType.Custom => EkEPuMiVqOHqVYAlYqzVqNRKdZfJ(QxTFLYmUoZgUuidbTguPudElbPWe), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool uGmKoyGwNInQDqPtpIUppOzIIepj()
	{
		if (!gCfehVQyGFgmdISYesMEYeVLailg(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA) && !cXTzLEJlOYUkvNrKMrxJnhbgmWCH(WEUziCawJTwcDEaRbKVDMINTCHkHA) && !gCfehVQyGFgmdISYesMEYeVLailg(KdgGMSjqXKFUDuQQbblYpDWdDvYy))
		{
			return cXTzLEJlOYUkvNrKMrxJnhbgmWCH(QxTFLYmUoZgUuidbTguPudElbPWe);
		}
		return true;
	}

	public bool bNHarTiTPAhZhYKJtKIEKIlwvcdrA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => cXTzLEJlOYUkvNrKMrxJnhbgmWCH(WEUziCawJTwcDEaRbKVDMINTCHkHA), 
			ControllerType.Keyboard => gCfehVQyGFgmdISYesMEYeVLailg(KdgGMSjqXKFUDuQQbblYpDWdDvYy), 
			ControllerType.Mouse => gCfehVQyGFgmdISYesMEYeVLailg(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA), 
			ControllerType.Custom => cXTzLEJlOYUkvNrKMrxJnhbgmWCH(QxTFLYmUoZgUuidbTguPudElbPWe), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool XQQqFUZwmHFieXVHdOPctoTWGsPb()
	{
		if (!imVtrIjRTUsEyulRbloBshDcUqhs(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA) && !PXPJEyoDiIFROhMlYKuMvHwCJzYCb(WEUziCawJTwcDEaRbKVDMINTCHkHA) && !imVtrIjRTUsEyulRbloBshDcUqhs(KdgGMSjqXKFUDuQQbblYpDWdDvYy))
		{
			return PXPJEyoDiIFROhMlYKuMvHwCJzYCb(QxTFLYmUoZgUuidbTguPudElbPWe);
		}
		return true;
	}

	public bool pgrNugLVHYQjJoZAFfKLauqMagKT(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => PXPJEyoDiIFROhMlYKuMvHwCJzYCb(WEUziCawJTwcDEaRbKVDMINTCHkHA), 
			ControllerType.Keyboard => imVtrIjRTUsEyulRbloBshDcUqhs(KdgGMSjqXKFUDuQQbblYpDWdDvYy), 
			ControllerType.Mouse => imVtrIjRTUsEyulRbloBshDcUqhs(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA), 
			ControllerType.Custom => PXPJEyoDiIFROhMlYKuMvHwCJzYCb(QxTFLYmUoZgUuidbTguPudElbPWe), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool CYauZSLioVcfSyqPFpklfhagEhOr()
	{
		if (!EOUyGvthKDvzBIqamLUdlLmdLPpQ(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA) && !aHtOhXySmjKjADizpDuNbyfnUVsk(WEUziCawJTwcDEaRbKVDMINTCHkHA) && !EOUyGvthKDvzBIqamLUdlLmdLPpQ(KdgGMSjqXKFUDuQQbblYpDWdDvYy))
		{
			return aHtOhXySmjKjADizpDuNbyfnUVsk(QxTFLYmUoZgUuidbTguPudElbPWe);
		}
		return true;
	}

	public bool HyICKCWCJEymZTvKBvxaGmUOZECH(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => aHtOhXySmjKjADizpDuNbyfnUVsk(WEUziCawJTwcDEaRbKVDMINTCHkHA), 
			ControllerType.Keyboard => EOUyGvthKDvzBIqamLUdlLmdLPpQ(KdgGMSjqXKFUDuQQbblYpDWdDvYy), 
			ControllerType.Mouse => EOUyGvthKDvzBIqamLUdlLmdLPpQ(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA), 
			ControllerType.Custom => aHtOhXySmjKjADizpDuNbyfnUVsk(QxTFLYmUoZgUuidbTguPudElbPWe), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool hbOEJkRHMDKhJxrgKeeROeYSuhpV()
	{
		if (!hjDqeogzBBLLFCECsUcIwHzdUPty(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA) && !ZEWtCGxmLYdOsPhfyAGLfQWhFNIK(WEUziCawJTwcDEaRbKVDMINTCHkHA) && !hjDqeogzBBLLFCECsUcIwHzdUPty(KdgGMSjqXKFUDuQQbblYpDWdDvYy))
		{
			return ZEWtCGxmLYdOsPhfyAGLfQWhFNIK(QxTFLYmUoZgUuidbTguPudElbPWe);
		}
		return true;
	}

	public bool qlgAgdgMZJsdYLTfVBxZCNAeGQhoc(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ZEWtCGxmLYdOsPhfyAGLfQWhFNIK(WEUziCawJTwcDEaRbKVDMINTCHkHA), 
			ControllerType.Keyboard => hjDqeogzBBLLFCECsUcIwHzdUPty(KdgGMSjqXKFUDuQQbblYpDWdDvYy), 
			ControllerType.Mouse => hjDqeogzBBLLFCECsUcIwHzdUPty(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA), 
			ControllerType.Custom => ZEWtCGxmLYdOsPhfyAGLfQWhFNIK(QxTFLYmUoZgUuidbTguPudElbPWe), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool EkEPuMiVqOHqVYAlYqzVqNRKdZfJ<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool cztcpssAKIINHgMGsmTRnJrYfQXJA(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool cXTzLEJlOYUkvNrKMrxJnhbgmWCH<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool gCfehVQyGFgmdISYesMEYeVLailg(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool PXPJEyoDiIFROhMlYKuMvHwCJzYCb<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool imVtrIjRTUsEyulRbloBshDcUqhs(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool aHtOhXySmjKjADizpDuNbyfnUVsk<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool EOUyGvthKDvzBIqamLUdlLmdLPpQ(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool ZEWtCGxmLYdOsPhfyAGLfQWhFNIK<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool hjDqeogzBBLLFCECsUcIwHzdUPty(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller KNabPxHPnbpKIbShSuiSwEAMATzN()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(KdgGMSjqXKFUDuQQbblYpDWdDvYy, ref lastController, ref lastTime);
		IList<Joystick> wEUziCawJTwcDEaRbKVDMINTCHkHA = WEUziCawJTwcDEaRbKVDMINTCHkHA;
		for (int i = 0; i < pwyKpsUfOHnkYjLOCiQAqFosrZvs; i++)
		{
			InputTools.CompareLastActiveController(wEUziCawJTwcDEaRbKVDMINTCHkHA[i], ref lastController, ref lastTime);
		}
		IList<CustomController> qxTFLYmUoZgUuidbTguPudElbPWe = QxTFLYmUoZgUuidbTguPudElbPWe;
		for (int j = 0; j < OJSBCxBHDCPIwHiTOpUPcRusrxJc; j++)
		{
			InputTools.CompareLastActiveController(qxTFLYmUoZgUuidbTguPudElbPWe[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = KdgGMSjqXKFUDuQQbblYpDWdDvYy;
		}
		return lastController;
	}

	public Controller iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(WEUziCawJTwcDEaRbKVDMINTCHkHA[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return DgfFcsFEypGvKCatIhkeSdaWtzwHc;
		case ControllerType.Mouse:
			return DSSddfFhMNEuZUeDpMEBaimidxHxB;
		case ControllerType.Custom:
		{
			int count = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(QxTFLYmUoZgUuidbTguPudElbPWe[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 KNabPxHPnbpKIbShSuiSwEAMATzN<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType klkdmRyLWxoBYnLgwfWtgSmkCEqUA()
	{
		return KNabPxHPnbpKIbShSuiSwEAMATzN()?.type ?? ControllerType.Keyboard;
	}

	public void iJaLTSIWMiBJwuPRtyisPAEiCdPl(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			LPYbdndIRxqVjCFAmnvugBNrQCyx = true;
			FeNErWALOSctvRXQXnidnEgazLZo.RYErYevDzOoDYLNHANTqLvzwpEIx(P_0);
		}
	}

	public void OKTafOYtYkbyrBFcpPuyvcbjqmJIA(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			LPYbdndIRxqVjCFAmnvugBNrQCyx = true;
			FeNErWALOSctvRXQXnidnEgazLZo.SmRBnSfJZUspddsQxWEMgtKygLBKA(P_0, P_1);
		}
	}

	public void RyPgcfOJYsFxGhnGfBBZFrwcZbMdA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			FeNErWALOSctvRXQXnidnEgazLZo.yQMcUBhDRMUWNqyaLujgqOGfXfpDA(P_0);
		}
	}

	public void GglhWnApFRtPPlzGUHvdArbbnswQ(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			FeNErWALOSctvRXQXnidnEgazLZo.hJBAbZwTzSEtupqbLhURVEvgxBbt(P_0, P_1);
		}
	}

	public void gViJcJyhHAmXyZCIrbQGCMpNPlCKA()
	{
		FeNErWALOSctvRXQXnidnEgazLZo.gImYykuEDnFsnDLFweTLBsFuNsmR();
	}

	public void WHxQayJoxWPGeZgfWCstmflFmniR(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			yBDyMVpjJqbclHZOOXREcTBkYwif.RYErYevDzOoDYLNHANTqLvzwpEIx(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
			{
				return;
			}
			cZFavYHHKeXevRPusDvPUgumRfYJA[P_0].RYErYevDzOoDYLNHANTqLvzwpEIx(P_1);
		}
		LPYbdndIRxqVjCFAmnvugBNrQCyx = true;
	}

	public void lNYGIccFnSFTrbWRgkerIENoLXgeb(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			yBDyMVpjJqbclHZOOXREcTBkYwif.SmRBnSfJZUspddsQxWEMgtKygLBKA(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
			{
				return;
			}
			cZFavYHHKeXevRPusDvPUgumRfYJA[P_0].SmRBnSfJZUspddsQxWEMgtKygLBKA(P_1, P_2);
		}
		LPYbdndIRxqVjCFAmnvugBNrQCyx = true;
	}

	public void DuugnkzhmgEPrLsqYFfQuwBttzVg(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				yBDyMVpjJqbclHZOOXREcTBkYwif.yQMcUBhDRMUWNqyaLujgqOGfXfpDA(P_1);
			}
			else if ((uint)P_0 < (uint)yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
			{
				cZFavYHHKeXevRPusDvPUgumRfYJA[P_0].yQMcUBhDRMUWNqyaLujgqOGfXfpDA(P_1);
			}
		}
	}

	public void JtrEzIbGFDmvrQtizjzHdSFYwexHA(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				yBDyMVpjJqbclHZOOXREcTBkYwif.hJBAbZwTzSEtupqbLhURVEvgxBbt(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
			{
				cZFavYHHKeXevRPusDvPUgumRfYJA[P_0].hJBAbZwTzSEtupqbLhURVEvgxBbt(P_1, P_2);
			}
		}
	}

	public void UiaCMZGsFEpDxRjjqLReaFhELLyIb(int P_0)
	{
		if (P_0 == 9999999)
		{
			yBDyMVpjJqbclHZOOXREcTBkYwif.gImYykuEDnFsnDLFweTLBsFuNsmR();
		}
		else if ((uint)P_0 < (uint)yjRLQdHMTxOFhZNmZFaYifCjMvJqA)
		{
			cZFavYHHKeXevRPusDvPUgumRfYJA[P_0].gImYykuEDnFsnDLFweTLBsFuNsmR();
		}
	}

	private void DizZoNaAJggDfKrcFHBXeJaJuCfL()
	{
		if (FeNErWALOSctvRXQXnidnEgazLZo.ZjCZxyXEwqFJXLiDeYBsDqvVUTNK > 0)
		{
			FeNErWALOSctvRXQXnidnEgazLZo.VXchgidYopiWtAESRzuSRgizZnWx(-1, KNabPxHPnbpKIbShSuiSwEAMATzN(), iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Joystick), iEQeTwznTlabRPoKsLBxXWhUgUsD(ControllerType.Custom));
		}
		if (yBDyMVpjJqbclHZOOXREcTBkYwif.ZjCZxyXEwqFJXLiDeYBsDqvVUTNK > 0)
		{
			Player.ControllerHelper controllers = ubIgcZcYpphXxlemTyblzkDIvMbO.UYvxAAXLLbizFcdHDYaOxGuhfKrc().controllers;
			yBDyMVpjJqbclHZOOXREcTBkYwif.VXchgidYopiWtAESRzuSRgizZnWx(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < yjRLQdHMTxOFhZNmZFaYifCjMvJqA; i++)
		{
			if (cZFavYHHKeXevRPusDvPUgumRfYJA[i].ZjCZxyXEwqFJXLiDeYBsDqvVUTNK != 0)
			{
				Player.ControllerHelper controllers2 = ubIgcZcYpphXxlemTyblzkDIvMbO.BrjataNvgVFVOmITmwEwVxOllNFI[i].controllers;
				cZFavYHHKeXevRPusDvPUgumRfYJA[i].VXchgidYopiWtAESRzuSRgizZnWx(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void vpYcAjODiwCjetgWTIQLfpMDqSbY(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < WEUziCawJTwcDEaRbKVDMINTCHkHA.Count; i++)
		{
			if (WEUziCawJTwcDEaRbKVDMINTCHkHA[i] != null)
			{
				SLTfRWiOnDYTXImVhxMvbRhouBQcA(WEUziCawJTwcDEaRbKVDMINTCHkHA[i], P_0);
			}
		}
		for (int j = 0; j < jpKOzGFQYxRvQTPnJoQiNDxNipbo.Count; j++)
		{
			if (jpKOzGFQYxRvQTPnJoQiNDxNipbo[j] != null)
			{
				SLTfRWiOnDYTXImVhxMvbRhouBQcA(jpKOzGFQYxRvQTPnJoQiNDxNipbo[j], P_0);
			}
		}
		for (int k = 0; k < OJSBCxBHDCPIwHiTOpUPcRusrxJc; k++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[k] != null)
			{
				SLTfRWiOnDYTXImVhxMvbRhouBQcA(QxTFLYmUoZgUuidbTguPudElbPWe[k], P_0);
			}
		}
		SLTfRWiOnDYTXImVhxMvbRhouBQcA(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA, P_0);
	}

	private void SLTfRWiOnDYTXImVhxMvbRhouBQcA(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].hGVuzmiWOAnhEmGFXjTzQspEcSPiA._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> KoGzTCYOaaUvFIYHVlftboOPBFeAA<_0001>() where _0001 : IControllerTemplate
	{
		return idvLRdgjKRwPpNoBmcOENhruAaju.HAdedHyoXZKkmMTAwgYAQrwqrIeW<_0001>();
	}

	private void CFefRfzEmBJRCmaNvwZsAJPeiFsR(List<InputBehavior> P_0)
	{
		nmfmSCoqXhdqnpsaTMnWuTdAwSNA = ReInput.ilKdcvAddvhstqcjWcabGGsfjMRZB;
		ubIgcZcYpphXxlemTyblzkDIvMbO = ReInput.ABDTVoIIjFlEZLKHRhISrlbClCcb;
		WEUziCawJTwcDEaRbKVDMINTCHkHA = new List<Joystick>();
		jpKOzGFQYxRvQTPnJoQiNDxNipbo = new List<Joystick>();
		QxTFLYmUoZgUuidbTguPudElbPWe = new List<CustomController>();
		XfIFpNdCxnPnkFQcBZmkodMlESYo = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.odNDRUwAOnhWgjLHmfyNZulfTYIm;
		yjRLQdHMTxOFhZNmZFaYifCjMvJqA = ubIgcZcYpphXxlemTyblzkDIvMbO.PgvVwCKqIMiCGICkPcSeOjADhiYHA;
		ZrEEqTKZxGwQucpcOBoFTKKdCDReA = KTrDxSgGaWLnSDgSezdrZtfEoKwpA;
		LEOBTVFiKlBnQPSDhRAwyxfHJniOA = 0;
		XsJMGFRBmkRvnumGxscPZsjVcSgS = new ADictionary<int, LwmHjbfqYMEmHGUgSkAXhjTjrcEo>();
		XsJMGFRBmkRvnumGxscPZsjVcSgS.Add(ReInput.players.GetSystemPlayer().id, new LwmHjbfqYMEmHGUgSkAXhjTjrcEo(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			XsJMGFRBmkRvnumGxscPZsjVcSgS.Add(players[i].id, new LwmHjbfqYMEmHGUgSkAXhjTjrcEo(P_0));
		}
		djURClcoJuXGIcGuDROxyopwhFHK = new ReadOnlyCollection<Joystick>(WEUziCawJTwcDEaRbKVDMINTCHkHA);
		xluNdwCcMreWATwuyAYnUdCcRpJd = new ReadOnlyCollection<CustomController>(QxTFLYmUoZgUuidbTguPudElbPWe);
		gjGAZYHMtBrBPTgtywbcfPTZqEdL.GXOcwCFwbmCdaCEBxLlmvXULdkngA(RPvNIFbOxLHZbiTdtCFAlnYgdAQJ);
		tJtaxmAyRDjHsFpYnzmhslWDAdCNA = new gjGAZYHMtBrBPTgtywbcfPTZqEdL[(yjRLQdHMTxOFhZNmZFaYifCjMvJqA + 1) * XfIFpNdCxnPnkFQcBZmkodMlESYo];
		int num = 0;
		IPqBxocrumtIASrcUvKxIVzQlrSdb = new gjGAZYHMtBrBPTgtywbcfPTZqEdL[XfIFpNdCxnPnkFQcBZmkodMlESYo];
		for (int j = 0; j < XfIFpNdCxnPnkFQcBZmkodMlESYo; j++)
		{
			InputAction inputAction = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.jLdKKhJcoSthDrlMlNcQsIemDYPCA(j);
			InputBehavior inputBehavior = XsJMGFRBmkRvnumGxscPZsjVcSgS[9999999].yOgZUtiKKXGXdsQKmtASnAgurehK(inputAction.behaviorId);
			gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = new gjGAZYHMtBrBPTgtywbcfPTZqEdL(9999999, inputAction, inputBehavior, RPvNIFbOxLHZbiTdtCFAlnYgdAQJ);
			IPqBxocrumtIASrcUvKxIVzQlrSdb[j] = gjGAZYHMtBrBPTgtywbcfPTZqEdL2;
			tJtaxmAyRDjHsFpYnzmhslWDAdCNA[num] = gjGAZYHMtBrBPTgtywbcfPTZqEdL2;
			num++;
		}
		XarFcvIbIoOmghojTiRNGRmSkqwU = new gjGAZYHMtBrBPTgtywbcfPTZqEdL[yjRLQdHMTxOFhZNmZFaYifCjMvJqA, XfIFpNdCxnPnkFQcBZmkodMlESYo];
		for (int k = 0; k < yjRLQdHMTxOFhZNmZFaYifCjMvJqA; k++)
		{
			for (int l = 0; l < XfIFpNdCxnPnkFQcBZmkodMlESYo; l++)
			{
				InputAction inputAction2 = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.jLdKKhJcoSthDrlMlNcQsIemDYPCA(l);
				InputBehavior inputBehavior2 = XsJMGFRBmkRvnumGxscPZsjVcSgS[players[k].id].yOgZUtiKKXGXdsQKmtASnAgurehK(inputAction2.behaviorId);
				gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL3 = new gjGAZYHMtBrBPTgtywbcfPTZqEdL(k, inputAction2, inputBehavior2, RPvNIFbOxLHZbiTdtCFAlnYgdAQJ);
				XarFcvIbIoOmghojTiRNGRmSkqwU[k, l] = gjGAZYHMtBrBPTgtywbcfPTZqEdL3;
				tJtaxmAyRDjHsFpYnzmhslWDAdCNA[num] = gjGAZYHMtBrBPTgtywbcfPTZqEdL3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.RsZazJyYPNugVeFNMaHRGPaHgKVT;
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
				CustomController customController = OnAhnnQHKixkcuMWkpqEUJNLAIkDA(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					ubIgcZcYpphXxlemTyblzkDIvMbO.RmeButhFmdxsBQPRyEgbZicZgdaPA(num2)?.controllers.mIQtmapFJfJNDwyvlheTDcPDoEPp(customController, false);
				}
			}
		}
		oXqvLuINunuvJjNPxKGIsXUbgZIU = new QCMhwFAkemVHUWtsLnxYTCvaAOlv();
		kbEruIksdNxKQirkKwrEKuvvvqvb = new QCMhwFAkemVHUWtsLnxYTCvaAOlv[yjRLQdHMTxOFhZNmZFaYifCjMvJqA];
		for (int num3 = 0; num3 < yjRLQdHMTxOFhZNmZFaYifCjMvJqA; num3++)
		{
			kbEruIksdNxKQirkKwrEKuvvvqvb[num3] = new QCMhwFAkemVHUWtsLnxYTCvaAOlv();
		}
		FeNErWALOSctvRXQXnidnEgazLZo = new global::qobntIdEvhcGMeooPLoKGQSmqCys<ActiveControllerChangedDelegate>();
		yBDyMVpjJqbclHZOOXREcTBkYwif = new global::qobntIdEvhcGMeooPLoKGQSmqCys<PlayerActiveControllerChangedDelegate>();
		cZFavYHHKeXevRPusDvPUgumRfYJA = new global::qobntIdEvhcGMeooPLoKGQSmqCys<PlayerActiveControllerChangedDelegate>[ubIgcZcYpphXxlemTyblzkDIvMbO.PgvVwCKqIMiCGICkPcSeOjADhiYHA];
		ArrayTools.Populate(cZFavYHHKeXevRPusDvPUgumRfYJA);
	}

	private void azwXGBLEETFlceYsLGQIDHGKhAGB(UpdateLoopType P_0)
	{
		int count = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = WEUziCawJTwcDEaRbKVDMINTCHkHA[i];
			if (joystick.enabled)
			{
				auTYQSqqmAxVIdDavGIGLOfWdeuU(joystick.TWprnxczdgloAAhDGCiNApfzfnlx, joystick.ucqtfsuOTseRsybfPGjEFawPmfNK);
				joystick.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
			}
		}
		if (KdgGMSjqXKFUDuQQbblYpDWdDvYy.enabled)
		{
			KdgGMSjqXKFUDuQQbblYpDWdDvYy.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
		}
		else if (YbAxZIJPnyjVmobQcfUmJwyuXEPX)
		{
			KdgGMSjqXKFUDuQQbblYpDWdDvYy.KvoFcjqdgLeXYvFnGgyQadAHjIRjb(P_0);
		}
		if (zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.enabled)
		{
			zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
		}
		int count2 = QxTFLYmUoZgUuidbTguPudElbPWe.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = QxTFLYmUoZgUuidbTguPudElbPWe[j];
			if (customController.enabled)
			{
				customController.ioVJltJbvZsnQwQxlbVHGzyzlvSA();
				customController.TphwDqkAytPBkZdmXYWPheGltdaf(P_0);
			}
		}
	}

	private void WBkpfkKFYVhOGjKPGBiYkwSAJapw(UpdateLoopType P_0)
	{
		gjGAZYHMtBrBPTgtywbcfPTZqEdL.qBYEsRjQWlnGgmmInXUAbSRiYTUDA(P_0);
		Player[] array = ubIgcZcYpphXxlemTyblzkDIvMbO.UhKEPLicjLTRaqjePDVyKtjrIvZbA;
		int num = array.Length;
		bool enabled = KdgGMSjqXKFUDuQQbblYpDWdDvYy.enabled;
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
						PgZmhnvJSjfbaAptimpJFVJRSJFpA.ZJgcgUmYVEFQxGxkMCIOqkqYuHXl(maps[j]);
					}
				}
			}
		}
		bool enabled2 = zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.vkGGBgCVTFJZUQvFctbLaHrhpICOb(ZrEEqTKZxGwQucpcOBoFTKKdCDReA);
			if (enabled || YbAxZIJPnyjVmobQcfUmJwyuXEPX)
			{
				controllers.AvgqAuqkqEXxZCcXbPrkthNffejD(KdgGMSjqXKFUDuQQbblYpDWdDvYy, PgZmhnvJSjfbaAptimpJFVJRSJFpA, ZrEEqTKZxGwQucpcOBoFTKKdCDReA);
			}
			if (enabled2)
			{
				controllers.EwaGZSQEeljCYkYnezbunpPOOqmiA(zTHyQdnkuGTcOtEOrfvIbZFKGqvFA, ZrEEqTKZxGwQucpcOBoFTKKdCDReA);
			}
			controllers.WAkDqYmIXisBbVcxgLHXKObHiseB(ZrEEqTKZxGwQucpcOBoFTKKdCDReA);
		}
		for (int l = 0; l < tJtaxmAyRDjHsFpYnzmhslWDAdCNA.Length; l++)
		{
			if (tJtaxmAyRDjHsFpYnzmhslWDAdCNA[l].MMGpAWKNNqXRsYWoKRnbTLENwwiD != gjGAZYHMtBrBPTgtywbcfPTZqEdL.ZSFiggVhWlFXVqhGedrlEubrEXLX.Disabled)
			{
				tJtaxmAyRDjHsFpYnzmhslWDAdCNA[l].KpObOrddbCHLaZfdaKcTFdkExYyVb();
			}
		}
		gjGAZYHMtBrBPTgtywbcfPTZqEdL.kxCQkpZDKiQHHCFWueKgbRDswWbCA();
		if (!LYpTqFTRIjJyPLfAWWvvyOnlrBfp)
		{
			return;
		}
		if (oXqvLuINunuvJjNPxKGIsXUbgZIU.vKXmnsaoHKwCVWoIpLcxGJMEprDJ > 0)
		{
			for (int m = 0; m < XfIFpNdCxnPnkFQcBZmkodMlESYo; m++)
			{
				gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL2 = IPqBxocrumtIASrcUvKxIVzQlrSdb[m];
				if (gjGAZYHMtBrBPTgtywbcfPTZqEdL2.MMGpAWKNNqXRsYWoKRnbTLENwwiD != gjGAZYHMtBrBPTgtywbcfPTZqEdL.ZSFiggVhWlFXVqhGedrlEubrEXLX.Disabled)
				{
					oXqvLuINunuvJjNPxKGIsXUbgZIU.aAVNjJKCgfMfgWCaubnZKAHMzRCU(gjGAZYHMtBrBPTgtywbcfPTZqEdL2, P_0);
				}
			}
		}
		for (int n = 0; n < yjRLQdHMTxOFhZNmZFaYifCjMvJqA; n++)
		{
			QCMhwFAkemVHUWtsLnxYTCvaAOlv qCMhwFAkemVHUWtsLnxYTCvaAOlv = kbEruIksdNxKQirkKwrEKuvvvqvb[n];
			if (qCMhwFAkemVHUWtsLnxYTCvaAOlv.vKXmnsaoHKwCVWoIpLcxGJMEprDJ == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < XfIFpNdCxnPnkFQcBZmkodMlESYo; num2++)
			{
				gjGAZYHMtBrBPTgtywbcfPTZqEdL gjGAZYHMtBrBPTgtywbcfPTZqEdL3 = XarFcvIbIoOmghojTiRNGRmSkqwU[n, num2];
				if (gjGAZYHMtBrBPTgtywbcfPTZqEdL3.MMGpAWKNNqXRsYWoKRnbTLENwwiD != gjGAZYHMtBrBPTgtywbcfPTZqEdL.ZSFiggVhWlFXVqhGedrlEubrEXLX.Disabled)
				{
					qCMhwFAkemVHUWtsLnxYTCvaAOlv.aAVNjJKCgfMfgWCaubnZKAHMzRCU(gjGAZYHMtBrBPTgtywbcfPTZqEdL3, P_0);
				}
			}
		}
	}

	private void KTrDxSgGaWLnSDgSezdrZtfEoKwpA(bool P_0, int P_1, int P_2)
	{
		int num = nmfmSCoqXhdqnpsaTMnWuTdAwSNA.WaOsqNIhktcJIChspDZEFYLNIIjmA(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				IPqBxocrumtIASrcUvKxIVzQlrSdb[num].zuYXTAtVUvSJdjSlmtAkhAUYUDvG(P_0);
			}
			else
			{
				XarFcvIbIoOmghojTiRNGRmSkqwU[P_1, num].zuYXTAtVUvSJdjSlmtAkhAUYUDvG(P_0);
			}
		}
	}

	private void bijrZUYVBBdKzrnAZDENrvLsYROq(BridgedController P_0)
	{
		int num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0.sourceJoystick.rewiredId, GYebaZJoqelXtmRHZJpNEwyRGKCc.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = RvqUxWCHxUMYHKmISPGKVBzvqQaD(P_0.sourceJoystick.rewiredId, GYebaZJoqelXtmRHZJpNEwyRGKCc.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = jpKOzGFQYxRvQTPnJoQiNDxNipbo[num];
			jpKOzGFQYxRvQTPnJoQiNDxNipbo.RemoveAt(num);
			joystick.BgROjKityvfsHuKfsJPWHhgGErrIA(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		WEUziCawJTwcDEaRbKVDMINTCHkHA.Add(joystick);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Add(joystick);
		WEUziCawJTwcDEaRbKVDMINTCHkHA.Sort(Joystick.sWtIoQSuiBNDCogUhCFavMKBjnaL);
		idvLRdgjKRwPpNoBmcOENhruAaju.nfEkqZqZRNUInmTJUkYYXDLywkdD(joystick);
	}

	private void cYZxswwKbCabkeEwocaxspVVEprnA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= WEUziCawJTwcDEaRbKVDMINTCHkHA.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = WEUziCawJTwcDEaRbKVDMINTCHkHA[P_0];
		joystick.isConnected = false;
		if (pPCRyELCkMYvIHZCaASYKIDyVsZw != null)
		{
			pPCRyELCkMYvIHZCaASYKIDyVsZw(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (NzGKMvHtuBPJZIjKNBKKiIfHkQjab != null)
		{
			NzGKMvHtuBPJZIjKNBKKiIfHkQjab(joystick.type, joystick.id);
		}
		WEUziCawJTwcDEaRbKVDMINTCHkHA.RemoveAt(P_0);
		jpKOzGFQYxRvQTPnJoQiNDxNipbo.Add(joystick);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Remove(joystick);
		idvLRdgjKRwPpNoBmcOENhruAaju.IlxVkhbJblcRsHURxmeSjqVJSnQRA(joystick);
		joystick.xbzMqJvVogJAviEMRocpklZVZryW();
	}

	private void tAxozcqyJmfwdOwSmiBsFrdGrBPI()
	{
		for (int num = WEUziCawJTwcDEaRbKVDMINTCHkHA.Count - 1; num >= 0; num--)
		{
			cYZxswwKbCabkeEwocaxspVVEprnA(num);
		}
	}

	private bool MzqjSsVChbyEKeZnDGjkTjkysgeq(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < QxTFLYmUoZgUuidbTguPudElbPWe.Count; i++)
		{
			if (QxTFLYmUoZgUuidbTguPudElbPWe[i] == P_0)
			{
				return true;
			}
		}
		QxTFLYmUoZgUuidbTguPudElbPWe.Add(P_0);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Add(P_0);
		idvLRdgjKRwPpNoBmcOENhruAaju.nfEkqZqZRNUInmTJUkYYXDLywkdD(P_0);
		return true;
	}

	private bool KwEmiYLBnWGGbSBjRFLYWuTHYpWn(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		idvLRdgjKRwPpNoBmcOENhruAaju.IlxVkhbJblcRsHURxmeSjqVJSnQRA(P_0);
		cvBfkuJkVEDjyKBxBQuvGclCjAwqb.Remove(P_0);
		return QxTFLYmUoZgUuidbTguPudElbPWe.Remove(P_0);
	}

	private QCMhwFAkemVHUWtsLnxYTCvaAOlv nJXmjWcQdUMohJdDAEJSmHhewfoe(int P_0)
	{
		if (P_0 == 9999999)
		{
			return oXqvLuINunuvJjNPxKGIsXUbgZIU;
		}
		if (P_0 < 0 || P_0 >= ReInput.ABDTVoIIjFlEZLKHRhISrlbClCcb.PgvVwCKqIMiCGICkPcSeOjADhiYHA)
		{
			return null;
		}
		return kbEruIksdNxKQirkKwrEKuvvvqvb[P_0];
	}

	private void UNEValtgkiXghWuIImEaCOVFwRBs(bool P_0)
	{
		if (!P_0)
		{
			PgZmhnvJSjfbaAptimpJFVJRSJFpA.rSbgHEhDljyCJRNvhUDOvUzEPGEab();
		}
	}

	private void KndaPvECCTaZSaGMfrpLGEIdnOHeE(bool P_0)
	{
		KdgGMSjqXKFUDuQQbblYpDWdDvYy.lpGHWOOJdXrtWGgitYfjarUifXfB(P_0);
		zTHyQdnkuGTcOtEOrfvIbZFKGqvFA.lpGHWOOJdXrtWGgitYfjarUifXfB(P_0);
		for (int i = 0; i < WEUziCawJTwcDEaRbKVDMINTCHkHA.Count; i++)
		{
			WEUziCawJTwcDEaRbKVDMINTCHkHA[i].lpGHWOOJdXrtWGgitYfjarUifXfB(P_0);
		}
		for (int j = 0; j < QxTFLYmUoZgUuidbTguPudElbPWe.Count; j++)
		{
			QxTFLYmUoZgUuidbTguPudElbPWe[j].lpGHWOOJdXrtWGgitYfjarUifXfB(P_0);
		}
	}

	public void Dispose()
	{
		oQNDYcQlsvUYrfjDyUOQFUkLjqTh(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void GuYZiMVokhQjPewKFeGvUWnTFgxm()
	{
		try
		{
			oQNDYcQlsvUYrfjDyUOQFUkLjqTh(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void oQNDYcQlsvUYrfjDyUOQFUkLjqTh(bool P_0)
	{
		if (nrQZIXtXdlXKWaFoBKKydKQpJjzr)
		{
			return;
		}
		if (P_0)
		{
			if (furddRoEakJicakzWjxzdcmvFDhDA is IDisposable)
			{
				(furddRoEakJicakzWjxzdcmvFDhDA as IDisposable).Dispose();
			}
			if (vPfwzjbKjunQQhcyHfQiAImMvZtPA is IDisposable)
			{
				(vPfwzjbKjunQQhcyHfQiAImMvZtPA as IDisposable).Dispose();
			}
		}
		nrQZIXtXdlXKWaFoBKKydKQpJjzr = true;
	}
}
