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

internal sealed class UgrefFwqJPPdjZGiGDKKCkBeaSXZ : IDisposable
{
	public enum TEYausDVqvCfFgmSDBFZSoAmKmEY
	{
		Connected = 0,
		Disconnected = 1
	}

	private class WwIAgEjtQZwqLmEjSRQbxprMJQKlA
	{
		public ADictionary<int, InputBehavior> ZpARAHGOXSSlzgTwCAXbIlfwjhAP;

		public List<InputBehavior> pFjPdViCogEFTFOBnUFBqGKgMOuaA;

		public IList<InputBehavior> wLybigCZnaWYRRahRyvEduddbkmp;

		public WwIAgEjtQZwqLmEjSRQbxprMJQKlA(List<InputBehavior> P_0)
		{
			pFjPdViCogEFTFOBnUFBqGKgMOuaA = new List<InputBehavior>(P_0.Count);
			ZpARAHGOXSSlzgTwCAXbIlfwjhAP = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				ZpARAHGOXSSlzgTwCAXbIlfwjhAP.Add(P_0[i].id, inputBehavior);
				pFjPdViCogEFTFOBnUFBqGKgMOuaA.Add(inputBehavior);
				num++;
			}
			wLybigCZnaWYRRahRyvEduddbkmp = new ReadOnlyCollection<InputBehavior>(pFjPdViCogEFTFOBnUFBqGKgMOuaA);
		}

		public InputBehavior fSOSkOssGGQndgTPmtMmrqGPLwph(int P_0)
		{
			if (pFjPdViCogEFTFOBnUFBqGKgMOuaA.Count == 0)
			{
				return null;
			}
			ZpARAHGOXSSlzgTwCAXbIlfwjhAP.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return pFjPdViCogEFTFOBnUFBqGKgMOuaA[0];
			}
			return value;
		}
	}

	private sealed class KdMOHnthbRkyrrbUZzpKOcxbkIoB : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int CsTcMMrTZHwPVHOyrRdDMQYJpsw;

		private CustomController swrveMpUBwOOumFQECegBBWpJAqG;

		private int UHtoBbAmIANxTVKoOxEgBNuSdzce;

		public UgrefFwqJPPdjZGiGDKKCkBeaSXZ VTIMyanHALggMJnfociZeDnElwmgb;

		private int oAfkMbNVZhuHrMYnCiONALHtFaWc;

		public int ZtsdcAXzbSeVuFsGohrgBywvooMA;

		private int qCAuqWxpvIPgQlqKpdnfeXdUWSMl;

		private int YtDFxemGwgsXpVeQCVLvcvwsncbY;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return swrveMpUBwOOumFQECegBBWpJAqG;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return swrveMpUBwOOumFQECegBBWpJAqG;
			}
		}

		[DebuggerHidden]
		public KdMOHnthbRkyrrbUZzpKOcxbkIoB(int P_0)
		{
			CsTcMMrTZHwPVHOyrRdDMQYJpsw = P_0;
			UHtoBbAmIANxTVKoOxEgBNuSdzce = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int csTcMMrTZHwPVHOyrRdDMQYJpsw = CsTcMMrTZHwPVHOyrRdDMQYJpsw;
			UgrefFwqJPPdjZGiGDKKCkBeaSXZ vTIMyanHALggMJnfociZeDnElwmgb = VTIMyanHALggMJnfociZeDnElwmgb;
			if (csTcMMrTZHwPVHOyrRdDMQYJpsw != 0)
			{
				if (csTcMMrTZHwPVHOyrRdDMQYJpsw != 1)
				{
					return false;
				}
				CsTcMMrTZHwPVHOyrRdDMQYJpsw = -1;
				goto IL_007d;
			}
			CsTcMMrTZHwPVHOyrRdDMQYJpsw = -1;
			qCAuqWxpvIPgQlqKpdnfeXdUWSMl = vTIMyanHALggMJnfociZeDnElwmgb.RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
			YtDFxemGwgsXpVeQCVLvcvwsncbY = 0;
			goto IL_008d;
			IL_007d:
			YtDFxemGwgsXpVeQCVLvcvwsncbY++;
			goto IL_008d;
			IL_008d:
			if (YtDFxemGwgsXpVeQCVLvcvwsncbY < qCAuqWxpvIPgQlqKpdnfeXdUWSMl)
			{
				if (vTIMyanHALggMJnfociZeDnElwmgb.RwtEDvyeWKcquySsRnujsTTOXXSK[YtDFxemGwgsXpVeQCVLvcvwsncbY].sourceControllerId == oAfkMbNVZhuHrMYnCiONALHtFaWc)
				{
					swrveMpUBwOOumFQECegBBWpJAqG = vTIMyanHALggMJnfociZeDnElwmgb.RwtEDvyeWKcquySsRnujsTTOXXSK[YtDFxemGwgsXpVeQCVLvcvwsncbY];
					CsTcMMrTZHwPVHOyrRdDMQYJpsw = 1;
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
			KdMOHnthbRkyrrbUZzpKOcxbkIoB kdMOHnthbRkyrrbUZzpKOcxbkIoB;
			if (CsTcMMrTZHwPVHOyrRdDMQYJpsw == -2 && UHtoBbAmIANxTVKoOxEgBNuSdzce == Environment.CurrentManagedThreadId)
			{
				CsTcMMrTZHwPVHOyrRdDMQYJpsw = 0;
				kdMOHnthbRkyrrbUZzpKOcxbkIoB = this;
			}
			else
			{
				kdMOHnthbRkyrrbUZzpKOcxbkIoB = new KdMOHnthbRkyrrbUZzpKOcxbkIoB(0);
				kdMOHnthbRkyrrbUZzpKOcxbkIoB.VTIMyanHALggMJnfociZeDnElwmgb = VTIMyanHALggMJnfociZeDnElwmgb;
			}
			kdMOHnthbRkyrrbUZzpKOcxbkIoB.oAfkMbNVZhuHrMYnCiONALHtFaWc = ZtsdcAXzbSeVuFsGohrgBywvooMA;
			return kdMOHnthbRkyrrbUZzpKOcxbkIoB;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class AOKBECplymblQnUFfODdrcABuopW : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int fRFVRgRVwdMssxoZtYrgKJDyxeVw;

		private CustomController LeEzONugKqISAAUpOVzLZQpEshKS;

		private int IaMrNhdfdhJXLmPSqDrmGLUqiTsV;

		public UgrefFwqJPPdjZGiGDKKCkBeaSXZ tBZVvTkVaWUQtAfsJtKykJbtOEQf;

		private string YKRFbDnWLtXdzBTsBqXhwvXfwwTg;

		public string nFzpHCnVLrjoLZlhYesCvlqcnXZG;

		private int qKRdpPYyJoWeyoItmYAtartvvRGm;

		private int oqjzPyzoUtJYlwlTvaMOYziTFECp;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return LeEzONugKqISAAUpOVzLZQpEshKS;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return LeEzONugKqISAAUpOVzLZQpEshKS;
			}
		}

		[DebuggerHidden]
		public AOKBECplymblQnUFfODdrcABuopW(int P_0)
		{
			fRFVRgRVwdMssxoZtYrgKJDyxeVw = P_0;
			IaMrNhdfdhJXLmPSqDrmGLUqiTsV = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = fRFVRgRVwdMssxoZtYrgKJDyxeVw;
			UgrefFwqJPPdjZGiGDKKCkBeaSXZ ugrefFwqJPPdjZGiGDKKCkBeaSXZ = tBZVvTkVaWUQtAfsJtKykJbtOEQf;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				fRFVRgRVwdMssxoZtYrgKJDyxeVw = -1;
				goto IL_0083;
			}
			fRFVRgRVwdMssxoZtYrgKJDyxeVw = -1;
			qKRdpPYyJoWeyoItmYAtartvvRGm = ugrefFwqJPPdjZGiGDKKCkBeaSXZ.RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
			oqjzPyzoUtJYlwlTvaMOYziTFECp = 0;
			goto IL_0093;
			IL_0083:
			oqjzPyzoUtJYlwlTvaMOYziTFECp++;
			goto IL_0093;
			IL_0093:
			if (oqjzPyzoUtJYlwlTvaMOYziTFECp < qKRdpPYyJoWeyoItmYAtartvvRGm)
			{
				if (ugrefFwqJPPdjZGiGDKKCkBeaSXZ.RwtEDvyeWKcquySsRnujsTTOXXSK[oqjzPyzoUtJYlwlTvaMOYziTFECp].tag.Equals(YKRFbDnWLtXdzBTsBqXhwvXfwwTg, StringComparison.OrdinalIgnoreCase))
				{
					LeEzONugKqISAAUpOVzLZQpEshKS = ugrefFwqJPPdjZGiGDKKCkBeaSXZ.RwtEDvyeWKcquySsRnujsTTOXXSK[oqjzPyzoUtJYlwlTvaMOYziTFECp];
					fRFVRgRVwdMssxoZtYrgKJDyxeVw = 1;
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
			AOKBECplymblQnUFfODdrcABuopW aOKBECplymblQnUFfODdrcABuopW;
			if (fRFVRgRVwdMssxoZtYrgKJDyxeVw == -2 && IaMrNhdfdhJXLmPSqDrmGLUqiTsV == Environment.CurrentManagedThreadId)
			{
				fRFVRgRVwdMssxoZtYrgKJDyxeVw = 0;
				aOKBECplymblQnUFfODdrcABuopW = this;
			}
			else
			{
				aOKBECplymblQnUFfODdrcABuopW = new AOKBECplymblQnUFfODdrcABuopW(0);
				aOKBECplymblQnUFfODdrcABuopW.tBZVvTkVaWUQtAfsJtKykJbtOEQf = tBZVvTkVaWUQtAfsJtKykJbtOEQf;
			}
			aOKBECplymblQnUFfODdrcABuopW.YKRFbDnWLtXdzBTsBqXhwvXfwwTg = nFzpHCnVLrjoLZlhYesCvlqcnXZG;
			return aOKBECplymblQnUFfODdrcABuopW;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> PZmyqdmKNAwyBKdArLpjYcxezWck;

	private List<Joystick> yueyahBsCaOnCTucFquMXXFgFPfH;

	private List<CustomController> RwtEDvyeWKcquySsRnujsTTOXXSK;

	private List<Controller> vPvinXoOBVcvuRmoTHgByZDIwTsK;

	private ReadOnlyCollection<Controller> nZHLkupISKELASjTPWLKwHPiBRnX;

	private Keyboard TaGFbzfQVPDpDeaDlhJwxvaKXXMF;

	private Mouse yQnOJAvJsPlkQllDpipekNrjGEvfb;

	private ConfigVars QMRQRezhgSRlfqujhAiebgwRVYMi;

	private dhgRPzBCLEtjJBicagpEtUtuCThf[] oDVJsTkCBAiJscjVjCiJLbqmDPWbb;

	private dhgRPzBCLEtjJBicagpEtUtuCThf[] VRGgwTrJmlvOIhMpAUIHNnRpnPOV;

	private dhgRPzBCLEtjJBicagpEtUtuCThf[,] WJTrCgEOCdkiwreaRXvaWYCjIKqC;

	private rACoEbOYRqZwIwjFrZCMRTeoChil ACrygCvmUcabyrCamNnbHPpmcfXr;

	private LdsHxqbGmxTBArOjZEjqxDHHBqlCb pUInCHSNsuLdTpDUpvAyqJsGapQkA;

	private LdsHxqbGmxTBArOjZEjqxDHHBqlCb[] tciFoVqJyYwxMsniWVcPYFEAVTsn;

	private global::vqRgKlhjAkQfIyJbTmmyECcRkuof<ActiveControllerChangedDelegate> GEpgylhAYPZntUFXXUkNLrYRAxVXA;

	private global::vqRgKlhjAkQfIyJbTmmyECcRkuof<PlayerActiveControllerChangedDelegate> jWfbOahBNthYlLbDSTCaoyzNiGkj;

	private global::vqRgKlhjAkQfIyJbTmmyECcRkuof<PlayerActiveControllerChangedDelegate>[] rvtKcfDHKfskrZbraUvpaPEBrTMu;

	private ADictionary<int, WwIAgEjtQZwqLmEjSRQbxprMJQKlA> OvnVLwVzwxodzmSTvqwpTlHswkku;

	private readonly OjcmMGKoEtsDrpMbbivWBgdDESNv biTWUEsIUUcYrPaSwwPcHcPVfMjS;

	private IList<Joystick> yGsaGQkDyztRCqDhXgPFAyDFlDJUA;

	private IList<CustomController> woOIyLYnIgeACXDziEIHCuLHrXHm;

	private int dlywzvxIFSOLPyNjXHKqGVcwaeESA;

	private bool DZuqSvDZdrMTkgOBqhYEFHUTCmLhb;

	private bool IwDQbwTjWoWqTRbLQWbXyhRIanfN;

	private bool SIsuQjbRAqRejMRsohUCcrrGaDuC;

	private IUnifiedKeyboardSource gUBomosoJpyXookwKzBLjGGAfthe;

	private IUnifiedMouseSource qTLQaUjhfzTOOxNjFhKGhSOzBhxrA;

	private int WEynWkeDAqRzEUAWltKSjQHeRJcR;

	private WLWSoyDOcyXgCSdvhMUaohkmMBdU uQAadzgzgAvpijpbkCWRiZzUHIKq;

	private msekTewPMCDuklrYGYDofSmhfOLW hZygvgGedcIRpwzvVvvDzLbnZavp;

	private int fjfYJMXmJyPNxVofTIggCxcUuJFTA;

	private int MKiAaunPhkBIqDWrXDNOkYuGgmEF;

	private Action<int, ControllerDataUpdater> tQdOBjsnkXGjCbxfpBImqRRnqKmeb;

	private Action<bool, int, int> UtuIdkZRjPIIqsSzOcuhVDoYKnHr;

	private Action<ControllerStatusChangedEventArgs> mlkVplVTqZgnIDxNwAYgGjfTBEXx;

	private Action<ControllerType, int> YfgCHYbLgCPZRgEXJoQoItNkFcbCA;

	private bool wTuWkFrzlqXEYavuHYWlhcdATGpe;

	public IList<Joystick> ikOjVBXpdongTItkQQnQWQZRdaPN => yGsaGQkDyztRCqDhXgPFAyDFlDJUA;

	public List<Joystick> imQOZKYuRzrXqawwfnNBUXhCzYuc => PZmyqdmKNAwyBKdArLpjYcxezWck;

	public int obOzcVKdOQfqEztHMjSkGgIZihnGb => PZmyqdmKNAwyBKdArLpjYcxezWck.Count;

	public Mouse QsgkmYvQGAwyNumMjGEvekEAbBLHA => yQnOJAvJsPlkQllDpipekNrjGEvfb;

	public Keyboard IHPfnLMrgyTtYeIwxJsMlnCYMDst => TaGFbzfQVPDpDeaDlhJwxvaKXXMF;

	public IList<CustomController> WYMrctzupfMBLPDIFFyqRlYSzlRb => woOIyLYnIgeACXDziEIHCuLHrXHm;

	public List<CustomController> yxHOrCyFwqNCRnjRijcmTBxaHLQW => RwtEDvyeWKcquySsRnujsTTOXXSK;

	public int POwcKpDhFJhDAAFrECdiOevTaPjPA => RwtEDvyeWKcquySsRnujsTTOXXSK.Count;

	public IList<Controller> bIgFfXlkvbTJmfSGQfQmDyRWFErB => nZHLkupISKELASjTPWLKwHPiBRnX;

	public int bcHPTPmdVaQiZGZCAfxQFgqzFdcb => vPvinXoOBVcvuRmoTHgByZDIwTsK.Count;

	private int VRmJMvClkGglEbglvhkcZWOWXRvpA
	{
		get
		{
			int wEynWkeDAqRzEUAWltKSjQHeRJcR = WEynWkeDAqRzEUAWltKSjQHeRJcR;
			WEynWkeDAqRzEUAWltKSjQHeRJcR++;
			if (WEynWkeDAqRzEUAWltKSjQHeRJcR >= int.MaxValue)
			{
				WEynWkeDAqRzEUAWltKSjQHeRJcR = 0;
			}
			return wEynWkeDAqRzEUAWltKSjQHeRJcR;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> wGsUXUWPerTHhxpGICYuOTegATHKA
	{
		add
		{
			mlkVplVTqZgnIDxNwAYgGjfTBEXx = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(mlkVplVTqZgnIDxNwAYgGjfTBEXx, b);
		}
		remove
		{
			mlkVplVTqZgnIDxNwAYgGjfTBEXx = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(mlkVplVTqZgnIDxNwAYgGjfTBEXx, value2);
		}
	}

	public event Action<ControllerType, int> GnTPGYSKpqxHjXdNRwoKopMXccyG
	{
		add
		{
			YfgCHYbLgCPZRgEXJoQoItNkFcbCA = (Action<ControllerType, int>)Delegate.Combine(YfgCHYbLgCPZRgEXJoQoItNkFcbCA, b);
		}
		remove
		{
			YfgCHYbLgCPZRgEXJoQoItNkFcbCA = (Action<ControllerType, int>)Delegate.Remove(YfgCHYbLgCPZRgEXJoQoItNkFcbCA, value2);
		}
	}

	public UgrefFwqJPPdjZGiGDKKCkBeaSXZ(ConfigVars P_0, PlatformInputManager P_1)
	{
		QMRQRezhgSRlfqujhAiebgwRVYMi = P_0;
		dlywzvxIFSOLPyNjXHKqGVcwaeESA = 0;
		DZuqSvDZdrMTkgOBqhYEFHUTCmLhb = UnityTools.isAndroidPlatform;
		vPvinXoOBVcvuRmoTHgByZDIwTsK = new List<Controller>(10);
		nZHLkupISKELASjTPWLKwHPiBRnX = new ReadOnlyCollection<Controller>(vPvinXoOBVcvuRmoTHgByZDIwTsK);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (gUBomosoJpyXookwKzBLjGGAfthe = new UnityUnifiedKeyboardSource());
		}
		TaGFbzfQVPDpDeaDlhJwxvaKXXMF = new Keyboard("Keyboard", unifiedKeyboardSource);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Add(TaGFbzfQVPDpDeaDlhJwxvaKXXMF);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (qTLQaUjhfzTOOxNjFhKGhSOzBhxrA = new UnityUnifiedMouseSource());
		}
		yQnOJAvJsPlkQllDpipekNrjGEvfb = new Mouse("Mouse", unifiedMouseSource);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Add(yQnOJAvJsPlkQllDpipekNrjGEvfb);
		ACrygCvmUcabyrCamNnbHPpmcfXr = new rACoEbOYRqZwIwjFrZCMRTeoChil(P_0.updateLoop, TaGFbzfQVPDpDeaDlhJwxvaKXXMF);
		TaGFbzfQVPDpDeaDlhJwxvaKXXMF.PmmyLpgcEdGkgyLPrwPauXxdXHmj += HsgrrSrlqnhihSATIMKKKaxwrfDw;
		TaGFbzfQVPDpDeaDlhJwxvaKXXMF.enabled = !P_0.GetPlatformVar_disableKeyboard();
		yQnOJAvJsPlkQllDpipekNrjGEvfb.enabled = !P_0.GetPlatformVar_disableMouse();
		ZVeDITCkNUczQyzeiCRedgPnAJmWA.RcLpnsFsgeNWBWYrxBojnJbaIcFFA();
		biTWUEsIUUcYrPaSwwPcHcPVfMjS = new OjcmMGKoEtsDrpMbbivWBgdDESNv(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.mcsxbweWRGUKtgrASoFyRmtDKWxj(TaGFbzfQVPDpDeaDlhJwxvaKXXMF);
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.mcsxbweWRGUKtgrASoFyRmtDKWxj(yQnOJAvJsPlkQllDpipekNrjGEvfb);
		ReInput.ApplicationFocusChangedEvent += HjRKIWApWQpHMIxXvfzfILsKTyus;
	}

	public void tuRbdYelwtrBJOgOSotFKvwDQumk(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		tQdOBjsnkXGjCbxfpBImqRRnqKmeb = P_0;
		XBScaOxqiMRtQuGLxHfCSzSNdViE(P_1);
	}

	public void DOwxRxMOYvFkbGCciqpJHYssufZXA(UpdateLoopType P_0)
	{
		ZVeDITCkNUczQyzeiCRedgPnAJmWA.IXQMnpMnfPvFvwuwJdwZAfOBSdUr(P_0);
		if (TaGFbzfQVPDpDeaDlhJwxvaKXXMF.enabled)
		{
			ACrygCvmUcabyrCamNnbHPpmcfXr.HfFfKYfjfkrxWQimaWRBYZeGaHNp(P_0);
		}
		jwBaWpRGALMFnegPkqIwTgflVZAw(P_0);
		PCUcgTMIYUKJMrcESoHgkWqvIydG(P_0);
		ZVeDITCkNUczQyzeiCRedgPnAJmWA.SdIlTjrnDAqFOUJGQxfYhLdGXePd(P_0, ReInput.currentFrame);
		if (SIsuQjbRAqRejMRsohUCcrrGaDuC)
		{
			MGXWMicMFnixzGJhHTSbyhAyGRff();
		}
	}

	public dhgRPzBCLEtjJBicagpEtUtuCThf cDsZNOLAeniGJlXONhiinQbijkWA(int P_0, string P_1, bool P_2)
	{
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.KpOIGZtIuRNCEjCCCtdlFGTylpOl(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return VRGgwTrJmlvOIhMpAUIHNnRpnPOV[num];
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return null;
		}
		return WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, num];
	}

	public dhgRPzBCLEtjJBicagpEtUtuCThf SzQMjqFNTiRRVtTiIQeEKTlKMdBW(int P_0, int P_1, bool P_2)
	{
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.HdyzUsIgYoZMEAvhvRqeQdmcylrC(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return VRGgwTrJmlvOIhMpAUIHNnRpnPOV[num];
		}
		return WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, num];
	}

	public void NDrcszHtvXXAjRglcGmSLHUNLPIhb(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			TEYausDVqvCfFgmSDBFZSoAmKmEY tEYausDVqvCfFgmSDBFZSoAmKmEY = TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected;
			int num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0.sourceJoystick.rewiredId, tEYausDVqvCfFgmSDBFZSoAmKmEY);
			if (num < 0)
			{
				tEYausDVqvCfFgmSDBFZSoAmKmEY = TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected;
				num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0.sourceJoystick.rewiredId, tEYausDVqvCfFgmSDBFZSoAmKmEY);
			}
			if (num >= 0)
			{
				((tEYausDVqvCfFgmSDBFZSoAmKmEY == TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected) ? PZmyqdmKNAwyBKdArLpjYcxezWck[num] : yueyahBsCaOnCTucFquMXXFgFPfH[num]).XzSvdbMJroolkHnVGNshOjOwXTXk(P_0);
			}
		}
	}

	public bool JDwCIoYLPfxBuibYXHjGwxpzqqdD(int P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY P_1)
	{
		if (OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int OUQJFWEYJFGmAGtROXIgBajWKNqj(int P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY P_1)
	{
		switch (P_1)
		{
		case TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected:
		{
			int count2 = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
			for (int j = 0; j < count2; j++)
			{
				if (PZmyqdmKNAwyBKdArLpjYcxezWck[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected:
		{
			int count = yueyahBsCaOnCTucFquMXXFgFPfH.Count;
			for (int i = 0; i < count; i++)
			{
				if (yueyahBsCaOnCTucFquMXXFgFPfH[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int ZpnYyXeNFiCovPjMGnvFDBCzEYXK(Guid P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY P_1)
	{
		switch (P_1)
		{
		case TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected:
		{
			int count2 = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
			for (int j = 0; j < count2; j++)
			{
				if (PZmyqdmKNAwyBKdArLpjYcxezWck[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected:
		{
			int count = yueyahBsCaOnCTucFquMXXFgFPfH.Count;
			for (int i = 0; i < count; i++)
			{
				if (yueyahBsCaOnCTucFquMXXFgFPfH[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool AsRbSXHBPHpjmlNKBgkCEIFKXOSXA(int P_0)
	{
		if (GAZIrYMCXYKfcydHcgsVnMdluICc(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int GAZIrYMCXYKfcydHcgsVnMdluICc(int P_0)
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		for (int i = 0; i < count; i++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int HdYxuDhpgpmNpSJIiVsqdJgLiTiG(Guid P_0)
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		for (int i = 0; i < count; i++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void rOeYlZWmWxcGQLDmWqlyiEFwIURm(BridgedController P_0)
	{
		cKJtWxCLBMVCfdpJBbIlFbdNPhEeA(P_0);
	}

	public void aKMCjrtXNIYnspgofYkkVGXkxjmX(int P_0)
	{
		int num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected);
		nbrpdFctbRhfmEXjifaXdCderFln(num);
	}

	public int XvvpptongKtzGONyHhHDeRVbyuOP()
	{
		return dlywzvxIFSOLPyNjXHKqGVcwaeESA++;
	}

	public IList<InputBehavior> RlKvfUYTewvvmbMXFjOtndRBcIeAA(int P_0)
	{
		if (!OvnVLwVzwxodzmSTvqwpTlHswkku.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return OvnVLwVzwxodzmSTvqwpTlHswkku[P_0].wLybigCZnaWYRRahRyvEduddbkmp;
	}

	public InputBehavior WhFrPEcblINBrBoGPgGyBBcAnAKib(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return HTrjSoiJIJXjtkLAhefMBsTvgqWT(P_0, inputBehaviorId);
	}

	public InputBehavior HTrjSoiJIJXjtkLAhefMBsTvgqWT(int P_0, int P_1)
	{
		if (!OvnVLwVzwxodzmSTvqwpTlHswkku.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> wLybigCZnaWYRRahRyvEduddbkmp = OvnVLwVzwxodzmSTvqwpTlHswkku[P_0].wLybigCZnaWYRRahRyvEduddbkmp;
		for (int i = 0; i < wLybigCZnaWYRRahRyvEduddbkmp.Count; i++)
		{
			if (wLybigCZnaWYRRahRyvEduddbkmp[i].id == P_1)
			{
				return wLybigCZnaWYRRahRyvEduddbkmp[i];
			}
		}
		return null;
	}

	public Joystick bGYAryEoCaDPuVhlQuucCjbIkmFG(int P_0, bool P_1 = false)
	{
		int num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected);
		if (num >= 0)
		{
			return PZmyqdmKNAwyBKdArLpjYcxezWck[num];
		}
		if (P_1)
		{
			num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected);
			if (num >= 0)
			{
				return yueyahBsCaOnCTucFquMXXFgFPfH[num];
			}
		}
		return null;
	}

	public Joystick iYcqIIfBMJhYwPujDqwCtTkCieQh(Guid P_0, bool P_1 = false)
	{
		int num = ZpnYyXeNFiCovPjMGnvFDBCzEYXK(P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected);
		if (num >= 0)
		{
			return PZmyqdmKNAwyBKdArLpjYcxezWck[num];
		}
		if (P_1)
		{
			num = ZpnYyXeNFiCovPjMGnvFDBCzEYXK(P_0, TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected);
			if (num >= 0)
			{
				return yueyahBsCaOnCTucFquMXXFgFPfH[num];
			}
		}
		return null;
	}

	public Joystick[] hzhGYAUfHKLUpqoOkmrkddUCjqck()
	{
		int count = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PZmyqdmKNAwyBKdArLpjYcxezWck[i];
		}
		return array;
	}

	public string[] ymJMKGmfXFIQhLkzVjEnamrBAKHgA()
	{
		int count = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PZmyqdmKNAwyBKdArLpjYcxezWck[i].name;
		}
		return array;
	}

	public CustomController HNRLIINMKXKEWxBotcMpkWOuhiXB(int P_0)
	{
		int num = GAZIrYMCXYKfcydHcgsVnMdluICc(P_0);
		if (num < 0)
		{
			return null;
		}
		return RwtEDvyeWKcquySsRnujsTTOXXSK[num];
	}

	public CustomController AMDkiiYNasiecmSXIfMjHiKXfDJY(Guid P_0)
	{
		int num = HdYxuDhpgpmNpSJIiVsqdJgLiTiG(P_0);
		if (num < 0)
		{
			return null;
		}
		return RwtEDvyeWKcquySsRnujsTTOXXSK[num];
	}

	public CustomController[] ABNIuMmbYdbWUeUtLGvYhUVXKeJIb()
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RwtEDvyeWKcquySsRnujsTTOXXSK[i];
		}
		return array;
	}

	public string[] neGuFcGgYmHXeXczWdFfaLoOLJpRA()
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RwtEDvyeWKcquySsRnujsTTOXXSK[i].name;
		}
		return array;
	}

	public CustomController BRugcGeISrSegSkXsKuwCEfyEwuDb(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int oSttNjzSxlAlOhMXEYOREwyFifUr = VRmJMvClkGglEbglvhkcZWOWXRvpA;
		CustomController customController = new CustomController(new ySKFuDcpZZqSGDRTHYdpwWAEQEmeA
		{
			rYniVPfIzOVHCLGKPdelkGMlLcqU = InputSource.Custom,
			AKwfAaDkpokCMTyHudUbAqaNVfwD = customControllerById.descriptiveName,
			uwlFsUGdyabHAXNbKLJhPFTDJjGyA = customControllerById.name,
			ikekJAfynwkkqKbmSDFwVJaGwEVd = customControllerById.axisCount,
			VxfvLAGvUjKLWdGTqJRWZunFdynI = customControllerById.buttonCount,
			oSttNjzSxlAlOhMXEYOREwyFifUr = oSttNjzSxlAlOhMXEYOREwyFifUr,
			sNGzxiChNzscGjgumLbuJkEXOkvs = customControllerById.id,
			HcoonNaYgnhyKzdarSfXlsSEvmzA = customControllerById.typeGuid,
			mIqKjXXdpNDOJGTZbFFQoXwCeePxA = customControllerById.id.ToString(),
			JedYMQqxBBBSzKqodufttUkatlMu = customControllerById.CreateGameHardwareMap()
		});
		ZfYdXNAZpaJAMDcgLnjIwTYPgQqNA(customController);
		return customController;
	}

	public bool qRWucmegvhBZDeuvsYPHjndYsAWNA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return FSszjjFheTQTvCkFDDbqUjtcFPUj(P_0);
	}

	public CustomController kdSEaKdDNshvdKeuPqeNypmznIRPA(int P_0)
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		for (int i = 0; i < count; i++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[i].sourceControllerId == P_0)
			{
				return RwtEDvyeWKcquySsRnujsTTOXXSK[i];
			}
		}
		return null;
	}

	public CustomController RSKIArpbiXfDvXviUgvQTxZSneCT(string P_0)
	{
		int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		for (int i = 0; i < count; i++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return RwtEDvyeWKcquySsRnujsTTOXXSK[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(KdMOHnthbRkyrrbUZzpKOcxbkIoB))]
	public IEnumerable<CustomController> brRGFENXtZJdiuNQdtlzeXEChmfK(int P_0)
	{
		return new KdMOHnthbRkyrrbUZzpKOcxbkIoB(-2)
		{
			VTIMyanHALggMJnfociZeDnElwmgb = this,
			ZtsdcAXzbSeVuFsGohrgBywvooMA = P_0
		};
	}

	[IteratorStateMachine(typeof(AOKBECplymblQnUFfODdrcABuopW))]
	public IEnumerable<CustomController> eriRonQDrEGxacuiiDjaggNqaTTNA(string P_0)
	{
		return new AOKBECplymblQnUFfODdrcABuopW(-2)
		{
			tBZVvTkVaWUQtAfsJtKykJbtOEQf = this,
			nFzpHCnVLrjoLZlhYesCvlqcnXZG = P_0
		};
	}

	public Controller DxfjMakBNHsfwQIMeHaXPCHSdWpiA(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => bGYAryEoCaDPuVhlQuucCjbIkmFG(P_1, P_2), 
			ControllerType.Keyboard => TaGFbzfQVPDpDeaDlhJwxvaKXXMF, 
			ControllerType.Mouse => yQnOJAvJsPlkQllDpipekNrjGEvfb, 
			ControllerType.Custom => HNRLIINMKXKEWxBotcMpkWOuhiXB(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller VAlQpaBUkFQpIiwBvElJlkBqweyN(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return ewWILanVJBOOUvNSccKRGzIYpCDZ(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return DxfjMakBNHsfwQIMeHaXPCHSdWpiA(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller ewWILanVJBOOUvNSccKRGzIYpCDZ(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (TaGFbzfQVPDpDeaDlhJwxvaKXXMF.deviceInstanceGuid == P_0)
		{
			return TaGFbzfQVPDpDeaDlhJwxvaKXXMF;
		}
		if (yQnOJAvJsPlkQllDpipekNrjGEvfb.deviceInstanceGuid == P_0)
		{
			return yQnOJAvJsPlkQllDpipekNrjGEvfb;
		}
		Controller result;
		if ((result = iYcqIIfBMJhYwPujDqwCtTkCieQh(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = AMDkiiYNasiecmSXIfMjHiKXfDJY(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] eEQyQdjWmoPyAEaKASepUOgMnrdX(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => hzhGYAUfHKLUpqoOkmrkddUCjqck(), 
			ControllerType.Keyboard => new Controller[1] { TaGFbzfQVPDpDeaDlhJwxvaKXXMF }, 
			ControllerType.Mouse => new Controller[1] { yQnOJAvJsPlkQllDpipekNrjGEvfb }, 
			ControllerType.Custom => ABNIuMmbYdbWUeUtLGvYhUVXKeJIb(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] mOQhAugBzkxgNYSKQnSNzYVbJyog(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ymJMKGmfXFIQhLkzVjEnamrBAKHgA(), 
			ControllerType.Keyboard => new string[1] { TaGFbzfQVPDpDeaDlhJwxvaKXXMF.name }, 
			ControllerType.Mouse => new string[1] { yQnOJAvJsPlkQllDpipekNrjGEvfb.name }, 
			ControllerType.Custom => neGuFcGgYmHXeXczWdFfaLoOLJpRA(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void gmvAqoNbzAuRVbsAoAwhnaoGdAXkA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.qZtChTEmlalmGAZddPoslSIGmVQab(P_1, P_2, InputActionEventType.Update, null);
	}

	public void KczjIfgZmFZCOgdjYlkEkYlDxOyQA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.OkFbXbxroeIzfdsXNnvEDSPdDhoCb(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void UrTyPcJGVyaXyHKFVAsRoCGXHDVeb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_3);
		if (num >= 0)
		{
			KczjIfgZmFZCOgdjYlkEkYlDxOyQA(P_0, P_1, P_2, num);
		}
	}

	public void UBNVULzDbyIisGIxcgVVapKBagTJc(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.qZtChTEmlalmGAZddPoslSIGmVQab(P_1, P_2, P_3, P_4);
	}

	public void VwCeBVPhYLGQbKoryCsNcFSxCFoab(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.OkFbXbxroeIzfdsXNnvEDSPdDhoCb(P_1, P_2, P_3, P_4, P_5);
	}

	public void EDIqnKapemarmdmonNxUDzlBQVpHb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			IwDQbwTjWoWqTRbLQWbXyhRIanfN = true;
		}
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_4);
		if (num >= 0)
		{
			VwCeBVPhYLGQbKoryCsNcFSxCFoab(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void OWWBWdFkavRVfATYarUqGPAcuUgUC(int P_0, Action<InputActionEventData> P_1)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.dzrMPFHAelvClsaAHjPibyakoOJiA(P_1);
	}

	public void ShyVkXysYsRTSRCKwHCxwTqephGb(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.tIUdKOFJPSGeYSNSnEXuXXUCfSjy(P_1, P_2);
	}

	public void xJGJuIcpegBMqkjUpZwoEaVtNtfr(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_2);
		if (num >= 0)
		{
			ShyVkXysYsRTSRCKwHCxwTqephGb(P_0, P_1, num);
		}
	}

	public void ikefwaqbaDAJQINVEimkoUYlDFslA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.ttKnOPeIFADyHvJSrYvlgomTBXFW(P_1, P_2);
	}

	public void jlJpRdBavUZTDNNJtyhnbVBFfkhH(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.inujYnaKUPFQaoZUpZAHdalfPRuI(P_1, P_2);
	}

	public void TFwPLSoKQNHvQEXCOJTMrtAXkqsS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.yMclJTmSJLEvvovGiNMdBeRkykdo(P_1, P_2, P_3);
	}

	public void cbyAFRQcdDEDXgalmuIYUJcKdGmR(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_3);
		if (num >= 0)
		{
			TFwPLSoKQNHvQEXCOJTMrtAXkqsS(P_0, P_1, P_2, num);
		}
	}

	public void lILWaGhfMJNLhZiwuQbenXHJAzqe(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.AfNJQdLHNuhJCziCkRcGoFyaTMsv(P_1, P_2, P_3);
	}

	public void wISGyjJMHQKtMNLujijsuMxUzHKk(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_3);
		if (num >= 0)
		{
			lILWaGhfMJNLhZiwuQbenXHJAzqe(P_0, P_1, P_2, num);
		}
	}

	public void rPqVwbhlRaSWrbwsIDLurMjWDLSC(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.SkkfLWREiqaruheyanJsjpsIZQrpA(P_1, P_2, P_3);
	}

	public void ztguvYSkvCgCetFwKtYdGbJEjsxA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.gpGPsMuQHHNfcRuHRIJRfEkeFwKD(P_1, P_2, P_3, P_4);
	}

	public void TSJpoXNDmvqmTojaPVZJmhkYCesA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(P_4);
		if (num >= 0)
		{
			ztguvYSkvCgCetFwKtYdGbJEjsxA(P_0, P_1, P_2, P_3, num);
		}
	}

	public void RoagorIhsiazzzWhlzBBSGDcHShYA(int P_0)
	{
		uOrCrKsXAqSUgDyqEnAtqKxJQGuw(P_0)?.FRvFCFAoARGaEFKfdaJvixmXpdmnB();
	}

	public bool aSkFSZcJqLreBjrkkTkqHznORRms(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].MxEcNwtqdlIeerRnDukWeLuLhuJf())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].MxEcNwtqdlIeerRnDukWeLuLhuJf())
			{
				return true;
			}
		}
		return false;
	}

	public bool gMUidRrAJBVfQXwzFgOBRHdmiDnV(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].rXrZPQfPVJBUbrjAjiOwpsbsoMBx())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].rXrZPQfPVJBUbrjAjiOwpsbsoMBx())
			{
				return true;
			}
		}
		return false;
	}

	public bool jWyfoGfUnNiFrhZEghPKISabVpZxc(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].rrhxDOjcPWqQgLfbTarpEkBOkrpI())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].rrhxDOjcPWqQgLfbTarpEkBOkrpI())
			{
				return true;
			}
		}
		return false;
	}

	public bool nLufdwkEohyuAlrbcHZUXnkIkaihA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].liXbUFHVCBpFhLWTDlKOjLPFBciB())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].liXbUFHVCBpFhLWTDlKOjLPFBciB())
			{
				return true;
			}
		}
		return false;
	}

	public bool jNpRuMFZZAHiussLdkzGZNDqeNnO(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].UmCYrzZMweTSJRYbCywvSFwqDXcv())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].UmCYrzZMweTSJRYbCywvSFwqDXcv())
			{
				return true;
			}
		}
		return false;
	}

	public bool mUOKHNwMMYtprLvHEhhFDWYTQRjx(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].SXkkCHQJRMzOMmxushyoGBTkBdoIA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].SXkkCHQJRMzOMmxushyoGBTkBdoIA())
			{
				return true;
			}
		}
		return false;
	}

	public bool ysomKHpiWEBEtWEuSCSGixYYdbSnA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].TagQxdEpgEJNLcLxWDqJBKBfzXpOA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].TagQxdEpgEJNLcLxWDqJBKBfzXpOA())
			{
				return true;
			}
		}
		return false;
	}

	public bool FzhLsuTQgoJrztoBTfbcivRJcDHEA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < VRGgwTrJmlvOIhMpAUIHNnRpnPOV.Length; i++)
			{
				if (VRGgwTrJmlvOIhMpAUIHNnRpnPOV[i].cZhWZRGqyHFnygvAvSMnAcTrdhlJ())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			return false;
		}
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		for (int j = 0; j < num; j++)
		{
			if (WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_0, j].cZhWZRGqyHFnygvAvSMnAcTrdhlJ())
			{
				return true;
			}
		}
		return false;
	}

	public bool MSRPliqyXxPccJwFvhNUukORZcQP()
	{
		if (!jUXpaPyATLNHTiDkyDEdnJpzqBBF(yQnOJAvJsPlkQllDpipekNrjGEvfb) && !ZoiQJtygsLZVDUnwWeoriuxzPbbi(PZmyqdmKNAwyBKdArLpjYcxezWck) && !jUXpaPyATLNHTiDkyDEdnJpzqBBF(TaGFbzfQVPDpDeaDlhJwxvaKXXMF))
		{
			return ZoiQJtygsLZVDUnwWeoriuxzPbbi(RwtEDvyeWKcquySsRnujsTTOXXSK);
		}
		return true;
	}

	public bool lhavKZtNSjfuobfafaUTfLNUQItC(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ZoiQJtygsLZVDUnwWeoriuxzPbbi(PZmyqdmKNAwyBKdArLpjYcxezWck), 
			ControllerType.Keyboard => jUXpaPyATLNHTiDkyDEdnJpzqBBF(TaGFbzfQVPDpDeaDlhJwxvaKXXMF), 
			ControllerType.Mouse => jUXpaPyATLNHTiDkyDEdnJpzqBBF(yQnOJAvJsPlkQllDpipekNrjGEvfb), 
			ControllerType.Custom => ZoiQJtygsLZVDUnwWeoriuxzPbbi(RwtEDvyeWKcquySsRnujsTTOXXSK), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool jAAZAXYVRVrBXuqjbUZXdHejgjvd()
	{
		if (!lYVjkoGKYQqpNSTEuadiGYyyYSpC(yQnOJAvJsPlkQllDpipekNrjGEvfb) && !dSzcrtXAnFCKlHJkUtUjtDmXEUPc(PZmyqdmKNAwyBKdArLpjYcxezWck) && !lYVjkoGKYQqpNSTEuadiGYyyYSpC(TaGFbzfQVPDpDeaDlhJwxvaKXXMF))
		{
			return dSzcrtXAnFCKlHJkUtUjtDmXEUPc(RwtEDvyeWKcquySsRnujsTTOXXSK);
		}
		return true;
	}

	public bool ckvKymTsZPfDxQRYpkGwALPDQStQ(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => dSzcrtXAnFCKlHJkUtUjtDmXEUPc(PZmyqdmKNAwyBKdArLpjYcxezWck), 
			ControllerType.Keyboard => lYVjkoGKYQqpNSTEuadiGYyyYSpC(TaGFbzfQVPDpDeaDlhJwxvaKXXMF), 
			ControllerType.Mouse => lYVjkoGKYQqpNSTEuadiGYyyYSpC(yQnOJAvJsPlkQllDpipekNrjGEvfb), 
			ControllerType.Custom => dSzcrtXAnFCKlHJkUtUjtDmXEUPc(RwtEDvyeWKcquySsRnujsTTOXXSK), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool CQyfLyNyihDDwBCIdIEvtJAtbgku()
	{
		if (!fkvriflTRBMGgohUdjsvevzTkEfw(yQnOJAvJsPlkQllDpipekNrjGEvfb) && !AcbdPFdcePYNExKwOKswEFGjJPSFA(PZmyqdmKNAwyBKdArLpjYcxezWck) && !fkvriflTRBMGgohUdjsvevzTkEfw(TaGFbzfQVPDpDeaDlhJwxvaKXXMF))
		{
			return AcbdPFdcePYNExKwOKswEFGjJPSFA(RwtEDvyeWKcquySsRnujsTTOXXSK);
		}
		return true;
	}

	public bool wdHczPVSPPBfXDaHDmKlQgCjAIMDb(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => AcbdPFdcePYNExKwOKswEFGjJPSFA(PZmyqdmKNAwyBKdArLpjYcxezWck), 
			ControllerType.Keyboard => fkvriflTRBMGgohUdjsvevzTkEfw(TaGFbzfQVPDpDeaDlhJwxvaKXXMF), 
			ControllerType.Mouse => fkvriflTRBMGgohUdjsvevzTkEfw(yQnOJAvJsPlkQllDpipekNrjGEvfb), 
			ControllerType.Custom => AcbdPFdcePYNExKwOKswEFGjJPSFA(RwtEDvyeWKcquySsRnujsTTOXXSK), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool RwQpppPJkOoyIaWEZljJzBYVGTQq()
	{
		if (!PlapPIbkCGMhJEDjiyAJvUIEEdts(yQnOJAvJsPlkQllDpipekNrjGEvfb) && !bIXNRisIeoWqSXEqjykpzPLCwWoI(PZmyqdmKNAwyBKdArLpjYcxezWck) && !PlapPIbkCGMhJEDjiyAJvUIEEdts(TaGFbzfQVPDpDeaDlhJwxvaKXXMF))
		{
			return bIXNRisIeoWqSXEqjykpzPLCwWoI(RwtEDvyeWKcquySsRnujsTTOXXSK);
		}
		return true;
	}

	public bool AAeZtfARBTykFZfXJjmCKTshlFEL(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => bIXNRisIeoWqSXEqjykpzPLCwWoI(PZmyqdmKNAwyBKdArLpjYcxezWck), 
			ControllerType.Keyboard => PlapPIbkCGMhJEDjiyAJvUIEEdts(TaGFbzfQVPDpDeaDlhJwxvaKXXMF), 
			ControllerType.Mouse => PlapPIbkCGMhJEDjiyAJvUIEEdts(yQnOJAvJsPlkQllDpipekNrjGEvfb), 
			ControllerType.Custom => bIXNRisIeoWqSXEqjykpzPLCwWoI(RwtEDvyeWKcquySsRnujsTTOXXSK), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool wcwLeTRgGWrmJtHnSqabErihRtfI()
	{
		if (!wolurBgZLSJJJMQTuSgcyWFMRbpW(yQnOJAvJsPlkQllDpipekNrjGEvfb) && !ECwrTjtJDXfEkLXwezKlhIyERhYy(PZmyqdmKNAwyBKdArLpjYcxezWck) && !wolurBgZLSJJJMQTuSgcyWFMRbpW(TaGFbzfQVPDpDeaDlhJwxvaKXXMF))
		{
			return ECwrTjtJDXfEkLXwezKlhIyERhYy(RwtEDvyeWKcquySsRnujsTTOXXSK);
		}
		return true;
	}

	public bool nhIkfQUXTOkpCBkiXIzjTusbFofs(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => ECwrTjtJDXfEkLXwezKlhIyERhYy(PZmyqdmKNAwyBKdArLpjYcxezWck), 
			ControllerType.Keyboard => wolurBgZLSJJJMQTuSgcyWFMRbpW(TaGFbzfQVPDpDeaDlhJwxvaKXXMF), 
			ControllerType.Mouse => wolurBgZLSJJJMQTuSgcyWFMRbpW(yQnOJAvJsPlkQllDpipekNrjGEvfb), 
			ControllerType.Custom => ECwrTjtJDXfEkLXwezKlhIyERhYy(RwtEDvyeWKcquySsRnujsTTOXXSK), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool ZoiQJtygsLZVDUnwWeoriuxzPbbi<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool jUXpaPyATLNHTiDkyDEdnJpzqBBF(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool dSzcrtXAnFCKlHJkUtUjtDmXEUPc<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool lYVjkoGKYQqpNSTEuadiGYyyYSpC(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool AcbdPFdcePYNExKwOKswEFGjJPSFA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool fkvriflTRBMGgohUdjsvevzTkEfw(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool bIXNRisIeoWqSXEqjykpzPLCwWoI<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool PlapPIbkCGMhJEDjiyAJvUIEEdts(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool ECwrTjtJDXfEkLXwezKlhIyERhYy<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool wolurBgZLSJJJMQTuSgcyWFMRbpW(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller PPGgmKTcxkbgSzuwUyxyspgbxexJ()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(yQnOJAvJsPlkQllDpipekNrjGEvfb, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(TaGFbzfQVPDpDeaDlhJwxvaKXXMF, ref lastController, ref lastTime);
		IList<Joystick> pZmyqdmKNAwyBKdArLpjYcxezWck = PZmyqdmKNAwyBKdArLpjYcxezWck;
		for (int i = 0; i < obOzcVKdOQfqEztHMjSkGgIZihnGb; i++)
		{
			InputTools.CompareLastActiveController(pZmyqdmKNAwyBKdArLpjYcxezWck[i], ref lastController, ref lastTime);
		}
		IList<CustomController> rwtEDvyeWKcquySsRnujsTTOXXSK = RwtEDvyeWKcquySsRnujsTTOXXSK;
		for (int j = 0; j < POwcKpDhFJhDAAFrECdiOevTaPjPA; j++)
		{
			InputTools.CompareLastActiveController(rwtEDvyeWKcquySsRnujsTTOXXSK[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = TaGFbzfQVPDpDeaDlhJwxvaKXXMF;
		}
		return lastController;
	}

	public Controller jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(PZmyqdmKNAwyBKdArLpjYcxezWck[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return IHPfnLMrgyTtYeIwxJsMlnCYMDst;
		case ControllerType.Mouse:
			return QsgkmYvQGAwyNumMjGEvekEAbBLHA;
		case ControllerType.Custom:
		{
			int count = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(RwtEDvyeWKcquySsRnujsTTOXXSK[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 PPGgmKTcxkbgSzuwUyxyspgbxexJ<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType fDExmMeQJqVODjbIsKBNWINFgWae()
	{
		return PPGgmKTcxkbgSzuwUyxyspgbxexJ()?.type ?? ControllerType.Keyboard;
	}

	public void dkQIkdUMBhJRayMormxQTqFDgVXC(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			SIsuQjbRAqRejMRsohUCcrrGaDuC = true;
			GEpgylhAYPZntUFXXUkNLrYRAxVXA.CbcVXZblpJsFGZEQWNPWPEXLUsGy(P_0);
		}
	}

	public void DGvJgrUJOhCqhBTdvUsOFiNIPURgb(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			SIsuQjbRAqRejMRsohUCcrrGaDuC = true;
			GEpgylhAYPZntUFXXUkNLrYRAxVXA.PgfIgzPLVZIzdsEFfLKuoRsJPvPU(P_0, P_1);
		}
	}

	public void WXjBrASwWjXxEruHtFHdzKYPgJOz(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			GEpgylhAYPZntUFXXUkNLrYRAxVXA.zTcKDeNaXDRSHgLnRujGKSiAfTfQ(P_0);
		}
	}

	public void RENIXGCCZSwTJNfLKBvDvETWpCaQA(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			GEpgylhAYPZntUFXXUkNLrYRAxVXA.akhcAsghMPtgSdabHGcjLVdXrflf(P_0, P_1);
		}
	}

	public void nzSbvuHaDNSPcIJLEzKcPKTveHCdc()
	{
		GEpgylhAYPZntUFXXUkNLrYRAxVXA.xJILpFkRPsCizXtIkANhCNxVoEagb();
	}

	public void HKTTrRHibBJVyaZqSouJhcDeBXirA(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			jWfbOahBNthYlLbDSTCaoyzNiGkj.CbcVXZblpJsFGZEQWNPWPEXLUsGy(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)fjfYJMXmJyPNxVofTIggCxcUuJFTA)
			{
				return;
			}
			rvtKcfDHKfskrZbraUvpaPEBrTMu[P_0].CbcVXZblpJsFGZEQWNPWPEXLUsGy(P_1);
		}
		SIsuQjbRAqRejMRsohUCcrrGaDuC = true;
	}

	public void mssgDBdmbLhHnAQMgcuPnUhZQfidb(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			jWfbOahBNthYlLbDSTCaoyzNiGkj.PgfIgzPLVZIzdsEFfLKuoRsJPvPU(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)fjfYJMXmJyPNxVofTIggCxcUuJFTA)
			{
				return;
			}
			rvtKcfDHKfskrZbraUvpaPEBrTMu[P_0].PgfIgzPLVZIzdsEFfLKuoRsJPvPU(P_1, P_2);
		}
		SIsuQjbRAqRejMRsohUCcrrGaDuC = true;
	}

	public void YVQdcJlswpQYfZifMRqocozGRlZH(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				jWfbOahBNthYlLbDSTCaoyzNiGkj.zTcKDeNaXDRSHgLnRujGKSiAfTfQ(P_1);
			}
			else if ((uint)P_0 < (uint)fjfYJMXmJyPNxVofTIggCxcUuJFTA)
			{
				rvtKcfDHKfskrZbraUvpaPEBrTMu[P_0].zTcKDeNaXDRSHgLnRujGKSiAfTfQ(P_1);
			}
		}
	}

	public void CLVHynSjFWTzxAZfhfQzUblfEOps(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				jWfbOahBNthYlLbDSTCaoyzNiGkj.akhcAsghMPtgSdabHGcjLVdXrflf(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)fjfYJMXmJyPNxVofTIggCxcUuJFTA)
			{
				rvtKcfDHKfskrZbraUvpaPEBrTMu[P_0].akhcAsghMPtgSdabHGcjLVdXrflf(P_1, P_2);
			}
		}
	}

	public void ZcOnLgmAXFOJxxCycKNMXUNvuzgU(int P_0)
	{
		if (P_0 == 9999999)
		{
			jWfbOahBNthYlLbDSTCaoyzNiGkj.xJILpFkRPsCizXtIkANhCNxVoEagb();
		}
		else if ((uint)P_0 < (uint)fjfYJMXmJyPNxVofTIggCxcUuJFTA)
		{
			rvtKcfDHKfskrZbraUvpaPEBrTMu[P_0].xJILpFkRPsCizXtIkANhCNxVoEagb();
		}
	}

	private void MGXWMicMFnixzGJhHTSbyhAyGRff()
	{
		if (GEpgylhAYPZntUFXXUkNLrYRAxVXA.UlgCGHVyHzPzRNCMkXhYDHbggETE > 0)
		{
			GEpgylhAYPZntUFXXUkNLrYRAxVXA.CxYDnVUCgmzWnIoJVAayJNKMvVAu(-1, PPGgmKTcxkbgSzuwUyxyspgbxexJ(), jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Joystick), jBwhtNdOtuqbHFBfqGZNTWctnAiW(ControllerType.Custom));
		}
		if (jWfbOahBNthYlLbDSTCaoyzNiGkj.UlgCGHVyHzPzRNCMkXhYDHbggETE > 0)
		{
			Player.ControllerHelper controllers = hZygvgGedcIRpwzvVvvDzLbnZavp.TwkaSnHIHKDqhuSmBQQQfkiEADGX().controllers;
			jWfbOahBNthYlLbDSTCaoyzNiGkj.CxYDnVUCgmzWnIoJVAayJNKMvVAu(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < fjfYJMXmJyPNxVofTIggCxcUuJFTA; i++)
		{
			if (rvtKcfDHKfskrZbraUvpaPEBrTMu[i].UlgCGHVyHzPzRNCMkXhYDHbggETE != 0)
			{
				Player.ControllerHelper controllers2 = hZygvgGedcIRpwzvVvvDzLbnZavp.CLRvmHDqKULeIoFAmoISFEsSaXTQ[i].controllers;
				rvtKcfDHKfskrZbraUvpaPEBrTMu[i].CxYDnVUCgmzWnIoJVAayJNKMvVAu(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void uksbbIUHgnfyidRTFQJzlytusznd(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < PZmyqdmKNAwyBKdArLpjYcxezWck.Count; i++)
		{
			if (PZmyqdmKNAwyBKdArLpjYcxezWck[i] != null)
			{
				HLdfYjYrlOfXTcwWfpSXTYLZolIM(PZmyqdmKNAwyBKdArLpjYcxezWck[i], P_0);
			}
		}
		for (int j = 0; j < yueyahBsCaOnCTucFquMXXFgFPfH.Count; j++)
		{
			if (yueyahBsCaOnCTucFquMXXFgFPfH[j] != null)
			{
				HLdfYjYrlOfXTcwWfpSXTYLZolIM(yueyahBsCaOnCTucFquMXXFgFPfH[j], P_0);
			}
		}
		for (int k = 0; k < POwcKpDhFJhDAAFrECdiOevTaPjPA; k++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[k] != null)
			{
				HLdfYjYrlOfXTcwWfpSXTYLZolIM(RwtEDvyeWKcquySsRnujsTTOXXSK[k], P_0);
			}
		}
		HLdfYjYrlOfXTcwWfpSXTYLZolIM(yQnOJAvJsPlkQllDpipekNrjGEvfb, P_0);
	}

	private void HLdfYjYrlOfXTcwWfpSXTYLZolIM(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].ecxPoTuiSHhzEinOJuPZQXPtumTW._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> JLeNUbSEefotDUhSPxlXjTqsizqn<_0001>() where _0001 : IControllerTemplate
	{
		return biTWUEsIUUcYrPaSwwPcHcPVfMjS.SCJuuKoJjCugoMTQgClkGCmJsHoD<_0001>();
	}

	private void XBScaOxqiMRtQuGLxHfCSzSNdViE(List<InputBehavior> P_0)
	{
		uQAadzgzgAvpijpbkCWRiZzUHIKq = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS;
		hZygvgGedcIRpwzvVvvDzLbnZavp = ReInput.NUfAUcWLCevjCFPFNKrevODCEJAs;
		PZmyqdmKNAwyBKdArLpjYcxezWck = new List<Joystick>();
		yueyahBsCaOnCTucFquMXXFgFPfH = new List<Joystick>();
		RwtEDvyeWKcquySsRnujsTTOXXSK = new List<CustomController>();
		MKiAaunPhkBIqDWrXDNOkYuGgmEF = uQAadzgzgAvpijpbkCWRiZzUHIKq.fWdSJncAgqWKojGWkiexBNsAiSOd;
		fjfYJMXmJyPNxVofTIggCxcUuJFTA = hZygvgGedcIRpwzvVvvDzLbnZavp.UJTUqhYGWFaEOAtpDKAOMicqQsWF;
		UtuIdkZRjPIIqsSzOcuhVDoYKnHr = BpNEodUKyRCbEidBjCbHkjHrIyyoA;
		WEynWkeDAqRzEUAWltKSjQHeRJcR = 0;
		OvnVLwVzwxodzmSTvqwpTlHswkku = new ADictionary<int, WwIAgEjtQZwqLmEjSRQbxprMJQKlA>();
		OvnVLwVzwxodzmSTvqwpTlHswkku.Add(ReInput.players.GetSystemPlayer().id, new WwIAgEjtQZwqLmEjSRQbxprMJQKlA(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			OvnVLwVzwxodzmSTvqwpTlHswkku.Add(players[i].id, new WwIAgEjtQZwqLmEjSRQbxprMJQKlA(P_0));
		}
		yGsaGQkDyztRCqDhXgPFAyDFlDJUA = new ReadOnlyCollection<Joystick>(PZmyqdmKNAwyBKdArLpjYcxezWck);
		woOIyLYnIgeACXDziEIHCuLHrXHm = new ReadOnlyCollection<CustomController>(RwtEDvyeWKcquySsRnujsTTOXXSK);
		dhgRPzBCLEtjJBicagpEtUtuCThf.BqiFtfNXtnrduWRWvMrOpPwejYdt(QMRQRezhgSRlfqujhAiebgwRVYMi);
		oDVJsTkCBAiJscjVjCiJLbqmDPWbb = new dhgRPzBCLEtjJBicagpEtUtuCThf[(fjfYJMXmJyPNxVofTIggCxcUuJFTA + 1) * MKiAaunPhkBIqDWrXDNOkYuGgmEF];
		int num = 0;
		VRGgwTrJmlvOIhMpAUIHNnRpnPOV = new dhgRPzBCLEtjJBicagpEtUtuCThf[MKiAaunPhkBIqDWrXDNOkYuGgmEF];
		for (int j = 0; j < MKiAaunPhkBIqDWrXDNOkYuGgmEF; j++)
		{
			InputAction inputAction = uQAadzgzgAvpijpbkCWRiZzUHIKq.ojNcNKHVaHIdBanHhjakowYXRcVZA(j);
			InputBehavior inputBehavior = OvnVLwVzwxodzmSTvqwpTlHswkku[9999999].fSOSkOssGGQndgTPmtMmrqGPLwph(inputAction.behaviorId);
			dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = new dhgRPzBCLEtjJBicagpEtUtuCThf(9999999, inputAction, inputBehavior, QMRQRezhgSRlfqujhAiebgwRVYMi);
			VRGgwTrJmlvOIhMpAUIHNnRpnPOV[j] = dhgRPzBCLEtjJBicagpEtUtuCThf2;
			oDVJsTkCBAiJscjVjCiJLbqmDPWbb[num] = dhgRPzBCLEtjJBicagpEtUtuCThf2;
			num++;
		}
		WJTrCgEOCdkiwreaRXvaWYCjIKqC = new dhgRPzBCLEtjJBicagpEtUtuCThf[fjfYJMXmJyPNxVofTIggCxcUuJFTA, MKiAaunPhkBIqDWrXDNOkYuGgmEF];
		for (int k = 0; k < fjfYJMXmJyPNxVofTIggCxcUuJFTA; k++)
		{
			for (int l = 0; l < MKiAaunPhkBIqDWrXDNOkYuGgmEF; l++)
			{
				InputAction inputAction2 = uQAadzgzgAvpijpbkCWRiZzUHIKq.ojNcNKHVaHIdBanHhjakowYXRcVZA(l);
				InputBehavior inputBehavior2 = OvnVLwVzwxodzmSTvqwpTlHswkku[players[k].id].fSOSkOssGGQndgTPmtMmrqGPLwph(inputAction2.behaviorId);
				dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf3 = new dhgRPzBCLEtjJBicagpEtUtuCThf(k, inputAction2, inputBehavior2, QMRQRezhgSRlfqujhAiebgwRVYMi);
				WJTrCgEOCdkiwreaRXvaWYCjIKqC[k, l] = dhgRPzBCLEtjJBicagpEtUtuCThf3;
				oDVJsTkCBAiJscjVjCiJLbqmDPWbb[num] = dhgRPzBCLEtjJBicagpEtUtuCThf3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.WhOmmIcRUFeHIqIDYZllQSPokJqb;
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
				CustomController customController = BRugcGeISrSegSkXsKuwCEfyEwuDb(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					hZygvgGedcIRpwzvVvvDzLbnZavp.MgIIdYJCmureJBUYamqZmJEeOVwP(num2)?.controllers.bCgofTxPFyNtRkcVhedbRvowccTD(customController, false);
				}
			}
		}
		pUInCHSNsuLdTpDUpvAyqJsGapQkA = new LdsHxqbGmxTBArOjZEjqxDHHBqlCb();
		tciFoVqJyYwxMsniWVcPYFEAVTsn = new LdsHxqbGmxTBArOjZEjqxDHHBqlCb[fjfYJMXmJyPNxVofTIggCxcUuJFTA];
		for (int num3 = 0; num3 < fjfYJMXmJyPNxVofTIggCxcUuJFTA; num3++)
		{
			tciFoVqJyYwxMsniWVcPYFEAVTsn[num3] = new LdsHxqbGmxTBArOjZEjqxDHHBqlCb();
		}
		GEpgylhAYPZntUFXXUkNLrYRAxVXA = new global::vqRgKlhjAkQfIyJbTmmyECcRkuof<ActiveControllerChangedDelegate>();
		jWfbOahBNthYlLbDSTCaoyzNiGkj = new global::vqRgKlhjAkQfIyJbTmmyECcRkuof<PlayerActiveControllerChangedDelegate>();
		rvtKcfDHKfskrZbraUvpaPEBrTMu = new global::vqRgKlhjAkQfIyJbTmmyECcRkuof<PlayerActiveControllerChangedDelegate>[hZygvgGedcIRpwzvVvvDzLbnZavp.UJTUqhYGWFaEOAtpDKAOMicqQsWF];
		ArrayTools.Populate(rvtKcfDHKfskrZbraUvpaPEBrTMu);
	}

	private void jwBaWpRGALMFnegPkqIwTgflVZAw(UpdateLoopType P_0)
	{
		int count = PZmyqdmKNAwyBKdArLpjYcxezWck.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = PZmyqdmKNAwyBKdArLpjYcxezWck[i];
			if (joystick.enabled)
			{
				tQdOBjsnkXGjCbxfpBImqRRnqKmeb(joystick.EtFueYsjftfBCOSfOwdxIAFSFqpL, joystick.jaSaHPudVtcyecnoPKkgZIAqgGJr);
				joystick.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
			}
		}
		if (TaGFbzfQVPDpDeaDlhJwxvaKXXMF.enabled)
		{
			TaGFbzfQVPDpDeaDlhJwxvaKXXMF.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
		}
		else if (DZuqSvDZdrMTkgOBqhYEFHUTCmLhb)
		{
			TaGFbzfQVPDpDeaDlhJwxvaKXXMF.TcIfnUdqgUkRCynaQhayszccQyNGA(P_0);
		}
		if (yQnOJAvJsPlkQllDpipekNrjGEvfb.enabled)
		{
			yQnOJAvJsPlkQllDpipekNrjGEvfb.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
		}
		int count2 = RwtEDvyeWKcquySsRnujsTTOXXSK.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = RwtEDvyeWKcquySsRnujsTTOXXSK[j];
			if (customController.enabled)
			{
				customController.dUWBIKXavsOefswHnnzpGMLZFsrl();
				customController.WpPadHsJSmWHmPNyDjEbriEWORwq(P_0);
			}
		}
	}

	private void PCUcgTMIYUKJMrcESoHgkWqvIydG(UpdateLoopType P_0)
	{
		dhgRPzBCLEtjJBicagpEtUtuCThf.bUuFfoIoKgCSuiIZzKPkUbtFgjWU(P_0);
		Player[] array = hZygvgGedcIRpwzvVvvDzLbnZavp.NgmgAgHubQJNcfshkZPYpCFVWTBJB;
		int num = array.Length;
		bool enabled = TaGFbzfQVPDpDeaDlhJwxvaKXXMF.enabled;
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
						ACrygCvmUcabyrCamNnbHPpmcfXr.QEOvXbgTvRVAfGsNSUsokGWfQeZc(maps[j]);
					}
				}
			}
		}
		bool enabled2 = yQnOJAvJsPlkQllDpipekNrjGEvfb.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.sLcDWLPBVKCTODdQsSzxhTLYVcIHA(UtuIdkZRjPIIqsSzOcuhVDoYKnHr);
			if (enabled || DZuqSvDZdrMTkgOBqhYEFHUTCmLhb)
			{
				controllers.HYCtoLyFwTaRVGqzlBBEjsDWTtxL(TaGFbzfQVPDpDeaDlhJwxvaKXXMF, ACrygCvmUcabyrCamNnbHPpmcfXr, UtuIdkZRjPIIqsSzOcuhVDoYKnHr);
			}
			if (enabled2)
			{
				controllers.POKgQdGHwsVMMCmyozzMtbxtxGuW(yQnOJAvJsPlkQllDpipekNrjGEvfb, UtuIdkZRjPIIqsSzOcuhVDoYKnHr);
			}
			controllers.VaCGzzeLWzaTBFxroNYhMMikEzuj(UtuIdkZRjPIIqsSzOcuhVDoYKnHr);
		}
		for (int l = 0; l < oDVJsTkCBAiJscjVjCiJLbqmDPWbb.Length; l++)
		{
			if (oDVJsTkCBAiJscjVjCiJLbqmDPWbb[l].HnaAgvQQBdGLsOOVScXDCZvgLMgFA != dhgRPzBCLEtjJBicagpEtUtuCThf.ATpZhXBHYmAXTaLDqGnLIAXQvrTm.Disabled)
			{
				oDVJsTkCBAiJscjVjCiJLbqmDPWbb[l].TieJFMfDnDhHeatukNmxfsYQfykCA();
			}
		}
		dhgRPzBCLEtjJBicagpEtUtuCThf.zYoTpYJcSfcXTEEDkpMUTLzHZgtNA();
		if (!IwDQbwTjWoWqTRbLQWbXyhRIanfN)
		{
			return;
		}
		if (pUInCHSNsuLdTpDUpvAyqJsGapQkA.yOnjoPaBDNywJUmXvRAZOrofPUFF > 0)
		{
			for (int m = 0; m < MKiAaunPhkBIqDWrXDNOkYuGgmEF; m++)
			{
				dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf2 = VRGgwTrJmlvOIhMpAUIHNnRpnPOV[m];
				if (dhgRPzBCLEtjJBicagpEtUtuCThf2.HnaAgvQQBdGLsOOVScXDCZvgLMgFA != dhgRPzBCLEtjJBicagpEtUtuCThf.ATpZhXBHYmAXTaLDqGnLIAXQvrTm.Disabled)
				{
					pUInCHSNsuLdTpDUpvAyqJsGapQkA.rFtUdyOpkeEzmCkhaxJjErxppjSh(dhgRPzBCLEtjJBicagpEtUtuCThf2, P_0);
				}
			}
		}
		for (int n = 0; n < fjfYJMXmJyPNxVofTIggCxcUuJFTA; n++)
		{
			LdsHxqbGmxTBArOjZEjqxDHHBqlCb ldsHxqbGmxTBArOjZEjqxDHHBqlCb = tciFoVqJyYwxMsniWVcPYFEAVTsn[n];
			if (ldsHxqbGmxTBArOjZEjqxDHHBqlCb.yOnjoPaBDNywJUmXvRAZOrofPUFF == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < MKiAaunPhkBIqDWrXDNOkYuGgmEF; num2++)
			{
				dhgRPzBCLEtjJBicagpEtUtuCThf dhgRPzBCLEtjJBicagpEtUtuCThf3 = WJTrCgEOCdkiwreaRXvaWYCjIKqC[n, num2];
				if (dhgRPzBCLEtjJBicagpEtUtuCThf3.HnaAgvQQBdGLsOOVScXDCZvgLMgFA != dhgRPzBCLEtjJBicagpEtUtuCThf.ATpZhXBHYmAXTaLDqGnLIAXQvrTm.Disabled)
				{
					ldsHxqbGmxTBArOjZEjqxDHHBqlCb.rFtUdyOpkeEzmCkhaxJjErxppjSh(dhgRPzBCLEtjJBicagpEtUtuCThf3, P_0);
				}
			}
		}
	}

	private void BpNEodUKyRCbEidBjCbHkjHrIyyoA(bool P_0, int P_1, int P_2)
	{
		int num = uQAadzgzgAvpijpbkCWRiZzUHIKq.HdyzUsIgYoZMEAvhvRqeQdmcylrC(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				VRGgwTrJmlvOIhMpAUIHNnRpnPOV[num].muoSSvnqXsWAbhgNyjlYpNqbYsns(P_0);
			}
			else
			{
				WJTrCgEOCdkiwreaRXvaWYCjIKqC[P_1, num].muoSSvnqXsWAbhgNyjlYpNqbYsns(P_0);
			}
		}
	}

	private void cKJtWxCLBMVCfdpJBbIlFbdNPhEeA(BridgedController P_0)
	{
		int num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0.sourceJoystick.rewiredId, TEYausDVqvCfFgmSDBFZSoAmKmEY.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = OUQJFWEYJFGmAGtROXIgBajWKNqj(P_0.sourceJoystick.rewiredId, TEYausDVqvCfFgmSDBFZSoAmKmEY.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = yueyahBsCaOnCTucFquMXXFgFPfH[num];
			yueyahBsCaOnCTucFquMXXFgFPfH.RemoveAt(num);
			joystick.SEtagtKmskjgNLgkgrRkPVYxsBbwA(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		PZmyqdmKNAwyBKdArLpjYcxezWck.Add(joystick);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Add(joystick);
		PZmyqdmKNAwyBKdArLpjYcxezWck.Sort(Joystick.ftXXApYEgGdVSoRHnPUWfbgwOPoT);
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.mcsxbweWRGUKtgrASoFyRmtDKWxj(joystick);
	}

	private void nbrpdFctbRhfmEXjifaXdCderFln(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= PZmyqdmKNAwyBKdArLpjYcxezWck.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = PZmyqdmKNAwyBKdArLpjYcxezWck[P_0];
		joystick.isConnected = false;
		if (mlkVplVTqZgnIDxNwAYgGjfTBEXx != null)
		{
			mlkVplVTqZgnIDxNwAYgGjfTBEXx(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (YfgCHYbLgCPZRgEXJoQoItNkFcbCA != null)
		{
			YfgCHYbLgCPZRgEXJoQoItNkFcbCA(joystick.type, joystick.id);
		}
		PZmyqdmKNAwyBKdArLpjYcxezWck.RemoveAt(P_0);
		yueyahBsCaOnCTucFquMXXFgFPfH.Add(joystick);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Remove(joystick);
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.HOZrlIfnvifRuONAxZciwsfqtFKU(joystick);
		joystick.oiLcdkgzyxvAnauVHzgHdoryrXqiA();
	}

	private void iaBBmTImFxnvzEYTyZuCGBLhOFVNA()
	{
		for (int num = PZmyqdmKNAwyBKdArLpjYcxezWck.Count - 1; num >= 0; num--)
		{
			nbrpdFctbRhfmEXjifaXdCderFln(num);
		}
	}

	private bool ZfYdXNAZpaJAMDcgLnjIwTYPgQqNA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < RwtEDvyeWKcquySsRnujsTTOXXSK.Count; i++)
		{
			if (RwtEDvyeWKcquySsRnujsTTOXXSK[i] == P_0)
			{
				return true;
			}
		}
		RwtEDvyeWKcquySsRnujsTTOXXSK.Add(P_0);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Add(P_0);
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.mcsxbweWRGUKtgrASoFyRmtDKWxj(P_0);
		return true;
	}

	private bool FSszjjFheTQTvCkFDDbqUjtcFPUj(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		biTWUEsIUUcYrPaSwwPcHcPVfMjS.HOZrlIfnvifRuONAxZciwsfqtFKU(P_0);
		vPvinXoOBVcvuRmoTHgByZDIwTsK.Remove(P_0);
		return RwtEDvyeWKcquySsRnujsTTOXXSK.Remove(P_0);
	}

	private LdsHxqbGmxTBArOjZEjqxDHHBqlCb uOrCrKsXAqSUgDyqEnAtqKxJQGuw(int P_0)
	{
		if (P_0 == 9999999)
		{
			return pUInCHSNsuLdTpDUpvAyqJsGapQkA;
		}
		if (P_0 < 0 || P_0 >= ReInput.NUfAUcWLCevjCFPFNKrevODCEJAs.UJTUqhYGWFaEOAtpDKAOMicqQsWF)
		{
			return null;
		}
		return tciFoVqJyYwxMsniWVcPYFEAVTsn[P_0];
	}

	private void HsgrrSrlqnhihSATIMKKKaxwrfDw(bool P_0)
	{
		if (!P_0)
		{
			ACrygCvmUcabyrCamNnbHPpmcfXr.yLHGEbNaloqILZDsnNDiMnLjpeES();
		}
	}

	private void HjRKIWApWQpHMIxXvfzfILsKTyus(bool P_0)
	{
		TaGFbzfQVPDpDeaDlhJwxvaKXXMF.kmaQpzOvBKrdjELpnQNLefZBEXTR(P_0);
		yQnOJAvJsPlkQllDpipekNrjGEvfb.kmaQpzOvBKrdjELpnQNLefZBEXTR(P_0);
		for (int i = 0; i < PZmyqdmKNAwyBKdArLpjYcxezWck.Count; i++)
		{
			PZmyqdmKNAwyBKdArLpjYcxezWck[i].kmaQpzOvBKrdjELpnQNLefZBEXTR(P_0);
		}
		for (int j = 0; j < RwtEDvyeWKcquySsRnujsTTOXXSK.Count; j++)
		{
			RwtEDvyeWKcquySsRnujsTTOXXSK[j].kmaQpzOvBKrdjELpnQNLefZBEXTR(P_0);
		}
	}

	public void Dispose()
	{
		xNjYfTOuUwMEppfSaKbuVnOaPdLK(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void FTyHrpPpuqPhTwkBXsARUpPszYxN()
	{
		try
		{
			xNjYfTOuUwMEppfSaKbuVnOaPdLK(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void xNjYfTOuUwMEppfSaKbuVnOaPdLK(bool P_0)
	{
		if (wTuWkFrzlqXEYavuHYWlhcdATGpe)
		{
			return;
		}
		if (P_0)
		{
			if (gUBomosoJpyXookwKzBLjGGAfthe is IDisposable)
			{
				(gUBomosoJpyXookwKzBLjGGAfthe as IDisposable).Dispose();
			}
			if (qTLQaUjhfzTOOxNjFhKGhSOzBhxrA is IDisposable)
			{
				(qTLQaUjhfzTOOxNjFhKGhSOzBhxrA as IDisposable).Dispose();
			}
		}
		wTuWkFrzlqXEYavuHYWlhcdATGpe = true;
	}
}
