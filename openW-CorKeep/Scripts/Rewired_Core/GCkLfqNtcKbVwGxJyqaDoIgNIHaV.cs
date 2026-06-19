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

internal sealed class GCkLfqNtcKbVwGxJyqaDoIgNIHaV : IDisposable
{
	public enum LFBQhPqZDgVXYtdjhOnCisdXRbjt
	{
		Connected = 0,
		Disconnected = 1
	}

	private class OjZrrlCIvIWhQTySouHoNAWxEHfu
	{
		public ADictionary<int, InputBehavior> FvDRiwpyyVFDwfqBypNwoeEDkadI;

		public List<InputBehavior> rcecyyRxDnFhYTleParGcopLiBThA;

		public IList<InputBehavior> iwfMjPpkEjomYWSQpMDJZyCMuxNT;

		public OjZrrlCIvIWhQTySouHoNAWxEHfu(List<InputBehavior> P_0)
		{
			rcecyyRxDnFhYTleParGcopLiBThA = new List<InputBehavior>(P_0.Count);
			FvDRiwpyyVFDwfqBypNwoeEDkadI = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				FvDRiwpyyVFDwfqBypNwoeEDkadI.Add(P_0[i].id, inputBehavior);
				rcecyyRxDnFhYTleParGcopLiBThA.Add(inputBehavior);
				num++;
			}
			iwfMjPpkEjomYWSQpMDJZyCMuxNT = new ReadOnlyCollection<InputBehavior>(rcecyyRxDnFhYTleParGcopLiBThA);
		}

		public InputBehavior doRHTrXNrHhcybhiUuVrXvhyiCCV(int P_0)
		{
			if (rcecyyRxDnFhYTleParGcopLiBThA.Count == 0)
			{
				return null;
			}
			FvDRiwpyyVFDwfqBypNwoeEDkadI.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return rcecyyRxDnFhYTleParGcopLiBThA[0];
			}
			return value;
		}
	}

	private sealed class UFLYFoADGGFAlhuMpcXmwmDSMjpz : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int CadarzGnoGJIOIGbkKzsqdrjfoNxB;

		private CustomController sfaSujOSrhTsttIqefifCneICCVjb;

		private int QTaUnUtMZNPzACAvemFltbwhEaZcA;

		public GCkLfqNtcKbVwGxJyqaDoIgNIHaV RLDBxXOVhMnOVIhEGuCCzTWtirPq;

		private int qdiXnrkZcaHOUDGxwLIFcmeKIIXW;

		public int DUuxqJwWWsRCKSjNmAZmahFZgbJUA;

		private int sfJvhhOXANYfNyYvFVaaEtGfDVzI;

		private int GKAcYPXONvlhuMcxsxckKGVZfrGQ;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return sfaSujOSrhTsttIqefifCneICCVjb;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return sfaSujOSrhTsttIqefifCneICCVjb;
			}
		}

		[DebuggerHidden]
		public UFLYFoADGGFAlhuMpcXmwmDSMjpz(int P_0)
		{
			CadarzGnoGJIOIGbkKzsqdrjfoNxB = P_0;
			QTaUnUtMZNPzACAvemFltbwhEaZcA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			CadarzGnoGJIOIGbkKzsqdrjfoNxB = -2;
		}

		private bool MoveNext()
		{
			int cadarzGnoGJIOIGbkKzsqdrjfoNxB = CadarzGnoGJIOIGbkKzsqdrjfoNxB;
			GCkLfqNtcKbVwGxJyqaDoIgNIHaV rLDBxXOVhMnOVIhEGuCCzTWtirPq = RLDBxXOVhMnOVIhEGuCCzTWtirPq;
			if (cadarzGnoGJIOIGbkKzsqdrjfoNxB != 0)
			{
				if (cadarzGnoGJIOIGbkKzsqdrjfoNxB != 1)
				{
					return false;
				}
				CadarzGnoGJIOIGbkKzsqdrjfoNxB = -1;
				goto IL_007d;
			}
			CadarzGnoGJIOIGbkKzsqdrjfoNxB = -1;
			sfJvhhOXANYfNyYvFVaaEtGfDVzI = rLDBxXOVhMnOVIhEGuCCzTWtirPq.LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
			GKAcYPXONvlhuMcxsxckKGVZfrGQ = 0;
			goto IL_008d;
			IL_007d:
			GKAcYPXONvlhuMcxsxckKGVZfrGQ++;
			goto IL_008d;
			IL_008d:
			if (GKAcYPXONvlhuMcxsxckKGVZfrGQ < sfJvhhOXANYfNyYvFVaaEtGfDVzI)
			{
				if (rLDBxXOVhMnOVIhEGuCCzTWtirPq.LMaEHSPgxLTEntaTzvCuYYmfQGhs[GKAcYPXONvlhuMcxsxckKGVZfrGQ].sourceControllerId == qdiXnrkZcaHOUDGxwLIFcmeKIIXW)
				{
					sfaSujOSrhTsttIqefifCneICCVjb = rLDBxXOVhMnOVIhEGuCCzTWtirPq.LMaEHSPgxLTEntaTzvCuYYmfQGhs[GKAcYPXONvlhuMcxsxckKGVZfrGQ];
					CadarzGnoGJIOIGbkKzsqdrjfoNxB = 1;
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
			UFLYFoADGGFAlhuMpcXmwmDSMjpz uFLYFoADGGFAlhuMpcXmwmDSMjpz;
			if (CadarzGnoGJIOIGbkKzsqdrjfoNxB == -2 && QTaUnUtMZNPzACAvemFltbwhEaZcA == Environment.CurrentManagedThreadId)
			{
				CadarzGnoGJIOIGbkKzsqdrjfoNxB = 0;
				uFLYFoADGGFAlhuMpcXmwmDSMjpz = this;
			}
			else
			{
				uFLYFoADGGFAlhuMpcXmwmDSMjpz = new UFLYFoADGGFAlhuMpcXmwmDSMjpz(0);
				uFLYFoADGGFAlhuMpcXmwmDSMjpz.RLDBxXOVhMnOVIhEGuCCzTWtirPq = RLDBxXOVhMnOVIhEGuCCzTWtirPq;
			}
			uFLYFoADGGFAlhuMpcXmwmDSMjpz.qdiXnrkZcaHOUDGxwLIFcmeKIIXW = DUuxqJwWWsRCKSjNmAZmahFZgbJUA;
			return uFLYFoADGGFAlhuMpcXmwmDSMjpz;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class MORMRxCATzGDRKmyZNjggHtiUbIEA : IEnumerable<CustomController>, IEnumerable, IEnumerator<CustomController>, IEnumerator, IDisposable
	{
		private int bRYQNtaJOkIdBiamLBnQymHVlwmb;

		private CustomController BBDtwmNLjnpgHXzQuuJYhKUnAsrX;

		private int UgTDgAKLSeCrGhxbIHHpyZxPpGRQ;

		public GCkLfqNtcKbVwGxJyqaDoIgNIHaV ngWFOsFHiFXwyJJUrvZnoGyUHPhqA;

		private string GyQIMuOGiiHheEIFluWmtAeCcjigb;

		public string zVaHidGNakBLMApWkfKLHpPJvgwQ;

		private int uUYLcsfQivNKttDUKvqgUMMMqavo;

		private int qqNCHNSfseouOtyFsyZuyDckNlSA;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return BBDtwmNLjnpgHXzQuuJYhKUnAsrX;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return BBDtwmNLjnpgHXzQuuJYhKUnAsrX;
			}
		}

		[DebuggerHidden]
		public MORMRxCATzGDRKmyZNjggHtiUbIEA(int P_0)
		{
			bRYQNtaJOkIdBiamLBnQymHVlwmb = P_0;
			UgTDgAKLSeCrGhxbIHHpyZxPpGRQ = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			bRYQNtaJOkIdBiamLBnQymHVlwmb = -2;
		}

		private bool MoveNext()
		{
			int num = bRYQNtaJOkIdBiamLBnQymHVlwmb;
			GCkLfqNtcKbVwGxJyqaDoIgNIHaV gCkLfqNtcKbVwGxJyqaDoIgNIHaV = ngWFOsFHiFXwyJJUrvZnoGyUHPhqA;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				bRYQNtaJOkIdBiamLBnQymHVlwmb = -1;
				goto IL_0083;
			}
			bRYQNtaJOkIdBiamLBnQymHVlwmb = -1;
			uUYLcsfQivNKttDUKvqgUMMMqavo = gCkLfqNtcKbVwGxJyqaDoIgNIHaV.LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
			qqNCHNSfseouOtyFsyZuyDckNlSA = 0;
			goto IL_0093;
			IL_0083:
			qqNCHNSfseouOtyFsyZuyDckNlSA++;
			goto IL_0093;
			IL_0093:
			if (qqNCHNSfseouOtyFsyZuyDckNlSA < uUYLcsfQivNKttDUKvqgUMMMqavo)
			{
				if (gCkLfqNtcKbVwGxJyqaDoIgNIHaV.LMaEHSPgxLTEntaTzvCuYYmfQGhs[qqNCHNSfseouOtyFsyZuyDckNlSA].tag.Equals(GyQIMuOGiiHheEIFluWmtAeCcjigb, StringComparison.OrdinalIgnoreCase))
				{
					BBDtwmNLjnpgHXzQuuJYhKUnAsrX = gCkLfqNtcKbVwGxJyqaDoIgNIHaV.LMaEHSPgxLTEntaTzvCuYYmfQGhs[qqNCHNSfseouOtyFsyZuyDckNlSA];
					bRYQNtaJOkIdBiamLBnQymHVlwmb = 1;
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
			MORMRxCATzGDRKmyZNjggHtiUbIEA mORMRxCATzGDRKmyZNjggHtiUbIEA;
			if (bRYQNtaJOkIdBiamLBnQymHVlwmb == -2 && UgTDgAKLSeCrGhxbIHHpyZxPpGRQ == Environment.CurrentManagedThreadId)
			{
				bRYQNtaJOkIdBiamLBnQymHVlwmb = 0;
				mORMRxCATzGDRKmyZNjggHtiUbIEA = this;
			}
			else
			{
				mORMRxCATzGDRKmyZNjggHtiUbIEA = new MORMRxCATzGDRKmyZNjggHtiUbIEA(0);
				mORMRxCATzGDRKmyZNjggHtiUbIEA.ngWFOsFHiFXwyJJUrvZnoGyUHPhqA = ngWFOsFHiFXwyJJUrvZnoGyUHPhqA;
			}
			mORMRxCATzGDRKmyZNjggHtiUbIEA.GyQIMuOGiiHheEIFluWmtAeCcjigb = zVaHidGNakBLMApWkfKLHpPJvgwQ;
			return mORMRxCATzGDRKmyZNjggHtiUbIEA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> RitZnURmkFkWEVCfDVjikgOXCgXY;

	private List<Joystick> cbVzSewflFZFAUJBlQNhdsuPWCJc;

	private List<CustomController> LMaEHSPgxLTEntaTzvCuYYmfQGhs;

	private List<Controller> ltwgMwNKkOPlpGSPnKlMQfehgdDx;

	private ReadOnlyCollection<Controller> zBIHKZMQtBFoNRXqdSsXWmoTUEGS;

	private Keyboard PkPZMMCFmSdnSCxyJRXfrBJhZMroA;

	private Mouse iTkQsdOFPUfKLaRwPuJdniEIuZOn;

	private ConfigVars USOEXNKqMLedechDDjghvJLsJEnAb;

	private fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[] oCUpFgROsDhbtgLwTCmOZSJDIuhI;

	private fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[] PmDvNiKVJkufXquQygjEfZqEGqjJ;

	private fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[,] OcAzyvdYfuERtwDFpbXcuvrOHpBk;

	private tdFhvYnMcljrBbWwTZbXrjFZQZDt KwvzpGGrJdBjKwVtUJwpvMsLgagB;

	private BCxuTLhLYqllXBOElLIjjeywjrCf tKHcPozVNfrXAsYvLmspYvTngefT;

	private BCxuTLhLYqllXBOElLIjjeywjrCf[] pipLdkJyHRGPDdhZcGQQJsrxHYBdb;

	private global::hSATvCUkYzwQNlbWnASxkQVqqbRw<ActiveControllerChangedDelegate> AbmzxYnzWSRToQeAfODCRIlsoqag;

	private global::hSATvCUkYzwQNlbWnASxkQVqqbRw<PlayerActiveControllerChangedDelegate> fGkZuFMBgaIHodEmmpfxJOQiIfFwA;

	private global::hSATvCUkYzwQNlbWnASxkQVqqbRw<PlayerActiveControllerChangedDelegate>[] pIyhAOaNzwWhgQYvIZZsCjLiMBfC;

	private ADictionary<int, OjZrrlCIvIWhQTySouHoNAWxEHfu> SlgQZjqHGmBFexewLAqipumNjCXE;

	private readonly YTvdJthXdoAvuaeWVmMDxzYuGHkq fwQJBzTkbJwCmMOrKtWjjrsyABSN;

	private IList<Joystick> owtNPvDnTuOfRvYKzPhSGVmqUUio;

	private IList<CustomController> onVFLifHbbmINKSQWfyUimkktaqt;

	private int fVzeMoWuFJzUKjGWlgvIhZeJxItC;

	private bool BlzPLGszGatVrtNyQoZPfohizzyf;

	private bool YjGuoNezllWUCYlqiPyIQRojeOEj;

	private bool OSzVltEcqxtbqXteMLWFWCMnEjZr;

	private IUnifiedKeyboardSource cIWFdZBJZsYMfnzBkLZUHNjxswYhA;

	private IUnifiedMouseSource qQOlPjWfCqcUHyzQvsZRcWdYsVQg;

	private int IdxcFJJzrlSZXTxjXmoJFbmTYXDk;

	private IsRfGTyTEbMSFXGhXufpYZyPCKjB smFNyINwNBDJrcWCSuSCEiCtFVnv;

	private qolSwVLcvXSMneGdcvjdFoTKDPcf zidunNXKnrdgqgGrjLiIBbIGdIYK;

	private int byzElucovkjkQKUbrOvgJBfMWgMA;

	private int SydKJHEqOtulzGXQfgjTYBNpQrrs;

	private Action<int, ControllerDataUpdater> lTcbKOZkHMDDXgjIVuethOcSdFFO;

	private Action<bool, int, int> GPviCVwOOIwetrpSmYfexOPlikmj;

	private Action<ControllerStatusChangedEventArgs> qvjwYOmNiYDGZWoKAkOxmCyuZBie;

	private Action<ControllerType, int> IadKsleFZNpqSJDgdsZvoiwXlXYg;

	private bool ikxUDRSNGbCjLIfWhCsRVVLfhYGTA;

	public IList<Joystick> yrPEeoylGtUTYBrNmPdLuBuginuS => owtNPvDnTuOfRvYKzPhSGVmqUUio;

	public List<Joystick> ypLKPzbdXaMPvhYTTKHCiBglCadkA => RitZnURmkFkWEVCfDVjikgOXCgXY;

	public int qHNpazdlcHQNVocnmulXYfyMuYzA => RitZnURmkFkWEVCfDVjikgOXCgXY.Count;

	public Mouse MojdWfKBpNKzYvgrFqSyOknzCmgl => iTkQsdOFPUfKLaRwPuJdniEIuZOn;

	public Keyboard WbGyhovABrZvNbHXBQtDZzjtIeFm => PkPZMMCFmSdnSCxyJRXfrBJhZMroA;

	public IList<CustomController> IfTvqDIDVwBeMcQkrHzvybKdhoIAb => onVFLifHbbmINKSQWfyUimkktaqt;

	public List<CustomController> kFMaJbkFczBlGomeUGBtubUHNWjcA => LMaEHSPgxLTEntaTzvCuYYmfQGhs;

	public int VoblREuvmSdxTWYQiDXrETWyuEMy => LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;

	public IList<Controller> ltjvSYGqPasbUgqxiBZNzVFbRElq => zBIHKZMQtBFoNRXqdSsXWmoTUEGS;

	public int dEIZKiBpKfKatNkoeKJarxNAGWCV => ltwgMwNKkOPlpGSPnKlMQfehgdDx.Count;

	private int NOpLTSlNWBLCJjiCHCvfwDzfEzEJ
	{
		get
		{
			int idxcFJJzrlSZXTxjXmoJFbmTYXDk = IdxcFJJzrlSZXTxjXmoJFbmTYXDk;
			IdxcFJJzrlSZXTxjXmoJFbmTYXDk++;
			if (IdxcFJJzrlSZXTxjXmoJFbmTYXDk >= int.MaxValue)
			{
				IdxcFJJzrlSZXTxjXmoJFbmTYXDk = 0;
			}
			return idxcFJJzrlSZXTxjXmoJFbmTYXDk;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ecpSelzTdcjrgarOicRdqZNJUAyG
	{
		add
		{
			qvjwYOmNiYDGZWoKAkOxmCyuZBie = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(qvjwYOmNiYDGZWoKAkOxmCyuZBie, b);
		}
		remove
		{
			qvjwYOmNiYDGZWoKAkOxmCyuZBie = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(qvjwYOmNiYDGZWoKAkOxmCyuZBie, value2);
		}
	}

	public event Action<ControllerType, int> EOCtYlholfvBgCDSpWIFYJSofdLFA
	{
		add
		{
			IadKsleFZNpqSJDgdsZvoiwXlXYg = (Action<ControllerType, int>)Delegate.Combine(IadKsleFZNpqSJDgdsZvoiwXlXYg, b);
		}
		remove
		{
			IadKsleFZNpqSJDgdsZvoiwXlXYg = (Action<ControllerType, int>)Delegate.Remove(IadKsleFZNpqSJDgdsZvoiwXlXYg, value2);
		}
	}

	public GCkLfqNtcKbVwGxJyqaDoIgNIHaV(ConfigVars P_0, PlatformInputManager P_1)
	{
		USOEXNKqMLedechDDjghvJLsJEnAb = P_0;
		fVzeMoWuFJzUKjGWlgvIhZeJxItC = 0;
		BlzPLGszGatVrtNyQoZPfohizzyf = UnityTools.isAndroidPlatform;
		ltwgMwNKkOPlpGSPnKlMQfehgdDx = new List<Controller>(10);
		zBIHKZMQtBFoNRXqdSsXWmoTUEGS = new ReadOnlyCollection<Controller>(ltwgMwNKkOPlpGSPnKlMQfehgdDx);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (cIWFdZBJZsYMfnzBkLZUHNjxswYhA = new UnityUnifiedKeyboardSource());
		}
		PkPZMMCFmSdnSCxyJRXfrBJhZMroA = new Keyboard("Keyboard", unifiedKeyboardSource);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Add(PkPZMMCFmSdnSCxyJRXfrBJhZMroA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (qQOlPjWfCqcUHyzQvsZRcWdYsVQg = new UnityUnifiedMouseSource());
		}
		iTkQsdOFPUfKLaRwPuJdniEIuZOn = new Mouse("Mouse", unifiedMouseSource);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Add(iTkQsdOFPUfKLaRwPuJdniEIuZOn);
		KwvzpGGrJdBjKwVtUJwpvMsLgagB = new tdFhvYnMcljrBbWwTZbXrjFZQZDt(P_0.updateLoop, PkPZMMCFmSdnSCxyJRXfrBJhZMroA);
		PkPZMMCFmSdnSCxyJRXfrBJhZMroA.TyrbvYABhmDwrDzwCNMrxYWfCIFLc += FNjcGpOdFaEOsHJwkkgFuhWDemkL;
		PkPZMMCFmSdnSCxyJRXfrBJhZMroA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		iTkQsdOFPUfKLaRwPuJdniEIuZOn.enabled = !P_0.GetPlatformVar_disableMouse();
		LmbZyiZanDTITkLTIvRrQkCQStTE.NiGBeDwrLfxeKBuYRdGuDRAXOrqy();
		fwQJBzTkbJwCmMOrKtWjjrsyABSN = new YTvdJthXdoAvuaeWVmMDxzYuGHkq(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.qevgkVDPuVaeixjpkpKzloScNZWQ(PkPZMMCFmSdnSCxyJRXfrBJhZMroA);
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.qevgkVDPuVaeixjpkpKzloScNZWQ(iTkQsdOFPUfKLaRwPuJdniEIuZOn);
		ReInput.ApplicationFocusChangedEvent += ZZSBajzKzHvUJJrgPHxugTBrtnHi;
	}

	public void vIWmohVWJemnAVYzgdBIoXReqZHk(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		lTcbKOZkHMDDXgjIVuethOcSdFFO = P_0;
		FhVwrhGxFTgzNnCjVIvNuLQsHyLV(P_1);
	}

	public void BbmWCLpfikSsFBRKUVCaaDxJicAc(UpdateLoopType P_0)
	{
		LmbZyiZanDTITkLTIvRrQkCQStTE.EFLBiUbVOEdtezRPfcMKgkraamrIA(P_0);
		if (PkPZMMCFmSdnSCxyJRXfrBJhZMroA.enabled)
		{
			KwvzpGGrJdBjKwVtUJwpvMsLgagB.DzCLvdWwQlNzRXUTMbuOatJrObuJ(P_0);
		}
		zjENPUcCfKtncrryYEqjnnAAAKzCA(P_0);
		RfVfpsBzbZbaReileoYvvQRnERGmB(P_0);
		LmbZyiZanDTITkLTIvRrQkCQStTE.KJqXauMWCZgOKHpeevLFLBsbtEex(P_0, ReInput.currentFrame);
		if (OSzVltEcqxtbqXteMLWFWCMnEjZr)
		{
			WxUiDZNBemmCcLQKdlfkCxbDiVCu();
		}
	}

	public fDpcCKCuzPiJSPYRYUOXoNEJrNYcb ypYyOaaWnlwKLoPcynBpNzdUHaJT(int P_0, string P_1, bool P_2)
	{
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.WrZSPgWrjCWtZyTdqRRgtIkFBkbkA(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return PmDvNiKVJkufXquQygjEfZqEGqjJ[num];
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return null;
		}
		return OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, num];
	}

	public fDpcCKCuzPiJSPYRYUOXoNEJrNYcb SgLBiPuumpLfMmbFqGSJJoAhcmcNA(int P_0, int P_1, bool P_2)
	{
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.BHxFaZjfRzTlJULUJJhdhsCeRfErb(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return PmDvNiKVJkufXquQygjEfZqEGqjJ[num];
		}
		return OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, num];
	}

	public void VGmbOSIbQCiZyhjWWADFhhheOuxk(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			LFBQhPqZDgVXYtdjhOnCisdXRbjt lFBQhPqZDgVXYtdjhOnCisdXRbjt = LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected;
			int num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0.sourceJoystick.rewiredId, lFBQhPqZDgVXYtdjhOnCisdXRbjt);
			if (num < 0)
			{
				lFBQhPqZDgVXYtdjhOnCisdXRbjt = LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected;
				num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0.sourceJoystick.rewiredId, lFBQhPqZDgVXYtdjhOnCisdXRbjt);
			}
			if (num >= 0)
			{
				((lFBQhPqZDgVXYtdjhOnCisdXRbjt == LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected) ? RitZnURmkFkWEVCfDVjikgOXCgXY[num] : cbVzSewflFZFAUJBlQNhdsuPWCJc[num]).LhNaCDtQBlFhlOmjcxEuebnJKMyh(P_0);
			}
		}
	}

	public bool BEriRThvsuxVrbWOvDvRiOEKZhIGA(int P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt P_1)
	{
		return OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0, P_1) >= 0;
	}

	public int OPPrEjvbaCuwFNdEctjpvBAdwRHw(int P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt P_1)
	{
		switch (P_1)
		{
		case LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected:
		{
			int count2 = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
			for (int j = 0; j < count2; j++)
			{
				if (RitZnURmkFkWEVCfDVjikgOXCgXY[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected:
		{
			int count = cbVzSewflFZFAUJBlQNhdsuPWCJc.Count;
			for (int i = 0; i < count; i++)
			{
				if (cbVzSewflFZFAUJBlQNhdsuPWCJc[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int DmspsWZirgEkpIreFTEBpjAAXeXB(Guid P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt P_1)
	{
		switch (P_1)
		{
		case LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected:
		{
			int count2 = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
			for (int j = 0; j < count2; j++)
			{
				if (RitZnURmkFkWEVCfDVjikgOXCgXY[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected:
		{
			int count = cbVzSewflFZFAUJBlQNhdsuPWCJc.Count;
			for (int i = 0; i < count; i++)
			{
				if (cbVzSewflFZFAUJBlQNhdsuPWCJc[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool EqMFJugCmOJKtQFzrGhByFsnBDzK(int P_0)
	{
		return UiGSHxzCvDswcdoQUEGbFbzYyxlP(P_0) >= 0;
	}

	public int UiGSHxzCvDswcdoQUEGbFbzYyxlP(int P_0)
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int ZFZhwcCUFmhEoJilQyhvXnHyHzZs(Guid P_0)
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void vQjbZetmLkfYVDGXwrKvBGoRGBgfb(BridgedController P_0)
	{
		erCPjYtqaFsDgwewrwVwNdOastdf(P_0);
	}

	public void kvHiGWEGuRVLxqRNVYkhnieHqCNl(int P_0)
	{
		int num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected);
		rjqBsuJsGYLTfLqGMgICTvYDuQMs(num);
	}

	public int LpwmTUTWDFRRFNkJdjpWWAuAEhdx()
	{
		return fVzeMoWuFJzUKjGWlgvIhZeJxItC++;
	}

	public IList<InputBehavior> NvFilYvRjbHxgmgfnyIyVkaoPTTE(int P_0)
	{
		if (!SlgQZjqHGmBFexewLAqipumNjCXE.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return SlgQZjqHGmBFexewLAqipumNjCXE[P_0].iwfMjPpkEjomYWSQpMDJZyCMuxNT;
	}

	public InputBehavior OyKOFlNzKDxseCZpbakxpSXhTRdF(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return VpuNDZZuzINQmbsfHDcBrOyCzwtf(P_0, inputBehaviorId);
	}

	public InputBehavior VpuNDZZuzINQmbsfHDcBrOyCzwtf(int P_0, int P_1)
	{
		if (!SlgQZjqHGmBFexewLAqipumNjCXE.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> iwfMjPpkEjomYWSQpMDJZyCMuxNT = SlgQZjqHGmBFexewLAqipumNjCXE[P_0].iwfMjPpkEjomYWSQpMDJZyCMuxNT;
		for (int i = 0; i < iwfMjPpkEjomYWSQpMDJZyCMuxNT.Count; i++)
		{
			if (iwfMjPpkEjomYWSQpMDJZyCMuxNT[i].id == P_1)
			{
				return iwfMjPpkEjomYWSQpMDJZyCMuxNT[i];
			}
		}
		return null;
	}

	public Joystick jXDhPVbEhpTlzUnGofGzsIWldtafA(int P_0, bool P_1 = false)
	{
		int num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected);
		if (num >= 0)
		{
			return RitZnURmkFkWEVCfDVjikgOXCgXY[num];
		}
		if (P_1)
		{
			num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected);
			if (num >= 0)
			{
				return cbVzSewflFZFAUJBlQNhdsuPWCJc[num];
			}
		}
		return null;
	}

	public Joystick yHjtltGHeYIRvIAZdBOLLXonqjtpA(Guid P_0, bool P_1 = false)
	{
		int num = DmspsWZirgEkpIreFTEBpjAAXeXB(P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected);
		if (num >= 0)
		{
			return RitZnURmkFkWEVCfDVjikgOXCgXY[num];
		}
		if (P_1)
		{
			num = DmspsWZirgEkpIreFTEBpjAAXeXB(P_0, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected);
			if (num >= 0)
			{
				return cbVzSewflFZFAUJBlQNhdsuPWCJc[num];
			}
		}
		return null;
	}

	public Joystick[] zJeKNppoaNzdyzqdCmEpNcnbckVbA()
	{
		int count = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RitZnURmkFkWEVCfDVjikgOXCgXY[i];
		}
		return array;
	}

	public string[] eyCBLpVKiCUiiMNUnzokMXQwGBqp()
	{
		int count = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = RitZnURmkFkWEVCfDVjikgOXCgXY[i].name;
		}
		return array;
	}

	public CustomController BdCZAtyTlYbsPszaTDYTUbxFoSBl(int P_0)
	{
		int num = UiGSHxzCvDswcdoQUEGbFbzYyxlP(P_0);
		if (num < 0)
		{
			return null;
		}
		return LMaEHSPgxLTEntaTzvCuYYmfQGhs[num];
	}

	public CustomController IRExXPziLzCixzsnekyoltXqMOwC(Guid P_0)
	{
		int num = ZFZhwcCUFmhEoJilQyhvXnHyHzZs(P_0);
		if (num < 0)
		{
			return null;
		}
		return LMaEHSPgxLTEntaTzvCuYYmfQGhs[num];
	}

	public CustomController[] KaKhnbDlvkqXFpwGjVJByxoezpqg()
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = LMaEHSPgxLTEntaTzvCuYYmfQGhs[i];
		}
		return array;
	}

	public string[] vxLEzDhWxtBdpAXSsqxujGTdtAMO()
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = LMaEHSPgxLTEntaTzvCuYYmfQGhs[i].name;
		}
		return array;
	}

	public CustomController NLzlMtxpmeUuvzoGWKnjaIzBvDLD(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int mqiYkAYAhyJmNmgmakdIgXfgwjpf = NOpLTSlNWBLCJjiCHCvfwDzfEzEJ;
		CustomController customController = new CustomController(new mMNvwuYacSiZPCcCtPVisdtjTKJD
		{
			rLkPryMvIVTnTIjtvBUqOyjQQrXM = InputSource.Custom,
			ITxWwbyjVtkYJUqTGJBJcNFokEXq = customControllerById.descriptiveName,
			oGmrUpIPjfrADOhUgrfqxNessFtK = customControllerById.name,
			uwptlhSDRbsEdFMQmYlSbnmtCfwz = customControllerById.axisCount,
			JjgiitdApkRoLilwSQpJtyIguXGL = customControllerById.buttonCount,
			mqiYkAYAhyJmNmgmakdIgXfgwjpf = mqiYkAYAhyJmNmgmakdIgXfgwjpf,
			mVbaHtfyiAKBowTOjHxkzdqUxUW = customControllerById.id,
			BErYfWBtnmsJfuVSYhosBZHxsmVV = customControllerById.typeGuid,
			uXtaZeecSWilMSjaDflFzhHfdxkR = customControllerById.id.ToString(),
			XiVTfDNqcUekfBDcZZogRVEHcefC = customControllerById.CreateGameHardwareMap()
		});
		JaXYjaaFEbewZhEBbRCFtynoJuHH(customController);
		return customController;
	}

	public bool qOPpbDRWYqtMKjOlKdrWHKXxRkfC(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return FLztcUwCAYhoiJRLfovtVmKZjIdsA(P_0);
	}

	public CustomController caTzebsfovZvwbPDlGKAHiBSbZgV(int P_0)
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[i].sourceControllerId == P_0)
			{
				return LMaEHSPgxLTEntaTzvCuYYmfQGhs[i];
			}
		}
		return null;
	}

	public CustomController VIPDJKMeZMlpcOfJqrFLhHupRrdy(string P_0)
	{
		int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return LMaEHSPgxLTEntaTzvCuYYmfQGhs[i];
			}
		}
		return null;
	}

	[IteratorStateMachine(typeof(UFLYFoADGGFAlhuMpcXmwmDSMjpz))]
	public IEnumerable<CustomController> dTOrHbgFCEVtxdqpFUPkEffxrgSU(int P_0)
	{
		return new UFLYFoADGGFAlhuMpcXmwmDSMjpz(-2)
		{
			RLDBxXOVhMnOVIhEGuCCzTWtirPq = this,
			DUuxqJwWWsRCKSjNmAZmahFZgbJUA = P_0
		};
	}

	[IteratorStateMachine(typeof(MORMRxCATzGDRKmyZNjggHtiUbIEA))]
	public IEnumerable<CustomController> cOltHAjcAXDTpnBJMSDfQcoBUIkw(string P_0)
	{
		return new MORMRxCATzGDRKmyZNjggHtiUbIEA(-2)
		{
			ngWFOsFHiFXwyJJUrvZnoGyUHPhqA = this,
			zVaHidGNakBLMApWkfKLHpPJvgwQ = P_0
		};
	}

	public Controller FJiNERFMwUDilNHrWEgQjOqbPMAh(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => jXDhPVbEhpTlzUnGofGzsIWldtafA(P_1, P_2), 
			ControllerType.Keyboard => PkPZMMCFmSdnSCxyJRXfrBJhZMroA, 
			ControllerType.Mouse => iTkQsdOFPUfKLaRwPuJdniEIuZOn, 
			ControllerType.Custom => BdCZAtyTlYbsPszaTDYTUbxFoSBl(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller NJmAcFapVCMDPfbaZNDUXOgZErLS(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return aiBUeNCQmCinTyWrWqwCZkvlTnmF(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return FJiNERFMwUDilNHrWEgQjOqbPMAh(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller aiBUeNCQmCinTyWrWqwCZkvlTnmF(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (PkPZMMCFmSdnSCxyJRXfrBJhZMroA.deviceInstanceGuid == P_0)
		{
			return PkPZMMCFmSdnSCxyJRXfrBJhZMroA;
		}
		if (iTkQsdOFPUfKLaRwPuJdniEIuZOn.deviceInstanceGuid == P_0)
		{
			return iTkQsdOFPUfKLaRwPuJdniEIuZOn;
		}
		Controller result;
		if ((result = yHjtltGHeYIRvIAZdBOLLXonqjtpA(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = IRExXPziLzCixzsnekyoltXqMOwC(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] ccRPGFMXznQZjLthcGkEkZbrghCe(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => zJeKNppoaNzdyzqdCmEpNcnbckVbA(), 
			ControllerType.Keyboard => new Controller[1] { PkPZMMCFmSdnSCxyJRXfrBJhZMroA }, 
			ControllerType.Mouse => new Controller[1] { iTkQsdOFPUfKLaRwPuJdniEIuZOn }, 
			ControllerType.Custom => KaKhnbDlvkqXFpwGjVJByxoezpqg(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] uRTNGJPlIxItEVRvuPpYReqGCVJj(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => eyCBLpVKiCUiiMNUnzokMXQwGBqp(), 
			ControllerType.Keyboard => new string[1] { PkPZMMCFmSdnSCxyJRXfrBJhZMroA.name }, 
			ControllerType.Mouse => new string[1] { iTkQsdOFPUfKLaRwPuJdniEIuZOn.name }, 
			ControllerType.Custom => vxLEzDhWxtBdpAXSsqxujGTdtAMO(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void eTuovLeKSLolQuzzUMTgDzZfTMqh(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.uFqqgoHAUxQlTUOQXGOzgqdbGydg(P_1, P_2, InputActionEventType.Update, null);
	}

	public void CbeBrCoZbOcBDegIyYMNgAvuVxFd(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.SaYSvOCCFxTyuzbgnBwPsDgAgnBI(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void MCZCFiluduntJXihuMUmOnuCSeKA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_3);
		if (num >= 0)
		{
			CbeBrCoZbOcBDegIyYMNgAvuVxFd(P_0, P_1, P_2, num);
		}
	}

	public void MEEBIiUEGlCnnTEOUzWQBbeBpjcg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.uFqqgoHAUxQlTUOQXGOzgqdbGydg(P_1, P_2, P_3, P_4);
	}

	public void HMVQbwmexMCysJKAAUKYvOzUXWPT(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.SaYSvOCCFxTyuzbgnBwPsDgAgnBI(P_1, P_2, P_3, P_4, P_5);
	}

	public void EELaozXnNfKZhpoVBEVVTKEhIOWs(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			YjGuoNezllWUCYlqiPyIQRojeOEj = true;
		}
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_4);
		if (num >= 0)
		{
			HMVQbwmexMCysJKAAUKYvOzUXWPT(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void QlTPMGVDJktyiUIpRiIlxdlZdFxT(int P_0, Action<InputActionEventData> P_1)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.jGkBWgeSNqpwexvvptzxWYHPWFqQ(P_1);
	}

	public void SuhuIBJZHfAnUQzhQWhDAGeHfgOdA(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.lBBOBjgNcZDUDdRpTbhbjbhBfTGzB(P_1, P_2);
	}

	public void fzLtHlNnTpwpjbJrTCMrcpoIEcSkA(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_2);
		if (num >= 0)
		{
			SuhuIBJZHfAnUQzhQWhDAGeHfgOdA(P_0, P_1, num);
		}
	}

	public void wTdzuNZKTYxMNWdmqEvzuFfGbUZr(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.vJFcDcPGyXLAMkqxJIFgUiRqWKyr(P_1, P_2);
	}

	public void xWSasEfsUHAzIsQcRNUqJxqoEgABA(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.wQpKkCZjnSdjrHhgLHbWmDCAKUBpA(P_1, P_2);
	}

	public void LEzEXpVCfQeDJLqlajbRNUdmsfRN(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.iXvcCqRkwMYBghfdQDuqhtmXCvOEA(P_1, P_2, P_3);
	}

	public void eFhfJkfWQITpMdfMAryLurDbxTJw(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_3);
		if (num >= 0)
		{
			LEzEXpVCfQeDJLqlajbRNUdmsfRN(P_0, P_1, P_2, num);
		}
	}

	public void vvOTDpWQYOPdeUgDYMsdLMyaSBHr(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.CFIrUUqVufJjNoOhIcKVKzDDQBNq(P_1, P_2, P_3);
	}

	public void ivTxRMewqXBuVMFVXPidSIYlEurw(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_3);
		if (num >= 0)
		{
			vvOTDpWQYOPdeUgDYMsdLMyaSBHr(P_0, P_1, P_2, num);
		}
	}

	public void xnpFUWCCKdMgcGmXyFpvEBzkfIlrb(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.QTfQUfkULnTnltxJSjexJtFlLLSh(P_1, P_2, P_3);
	}

	public void lskXvSnmRsYIDsOsWTSXuaKmbaNu(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.aVJEUraTbOFxxgWHxJkGhPbhZOnTB(P_1, P_2, P_3, P_4);
	}

	public void PjHzgFqMqvDYtDpQQNlCqSGFEPVWA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX.pQQSNZfrGqsKTZGyjgGiauouofZl(P_4);
		if (num >= 0)
		{
			lskXvSnmRsYIDsOsWTSXuaKmbaNu(P_0, P_1, P_2, P_3, num);
		}
	}

	public void RrfzlOIPKhLSsNAePlNYoahTHpCe(int P_0)
	{
		soulelFShhAanYCHayieWSSkVVLp(P_0)?.JLuRkuTrxESkZZGWSlpoVTsMegRC();
	}

	public bool kjjRXcJVTQOmCmaRCMIrpUUnATRF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].QjFgvPKGEeCadAwWpAOVbYVEwiocc())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].QjFgvPKGEeCadAwWpAOVbYVEwiocc())
			{
				return true;
			}
		}
		return false;
	}

	public bool apXwMaSMmUJbNWqYzONWlCCXOrEh(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].tkgMQvUaqSzRkgPvBglpNsGXRHuK())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].tkgMQvUaqSzRkgPvBglpNsGXRHuK())
			{
				return true;
			}
		}
		return false;
	}

	public bool fGbvvdpOKGpEgMvcHhBDwcTsyjsh(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].pQiccvFOkHaSfeEAGxAyBgsphfSic())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].pQiccvFOkHaSfeEAGxAyBgsphfSic())
			{
				return true;
			}
		}
		return false;
	}

	public bool vYxysVnPasMQPcAEAbjVViPtzKHi(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].xBfyujgxwYPkKCzxfLPLJMmuQzPG())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].xBfyujgxwYPkKCzxfLPLJMmuQzPG())
			{
				return true;
			}
		}
		return false;
	}

	public bool bUuxipqfwNcIpdmaZUPRncuFFWYfA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].MZVcABaPnzwSAYScLIsjwTNwITCA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].MZVcABaPnzwSAYScLIsjwTNwITCA())
			{
				return true;
			}
		}
		return false;
	}

	public bool yGVCaoVSjNJNeGukeVPWxqbkGnQF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].IlnDwsriqNmIJnrVMGHpsxuVmCDk())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].IlnDwsriqNmIJnrVMGHpsxuVmCDk())
			{
				return true;
			}
		}
		return false;
	}

	public bool injsnuCXzBikmBaNcEcVBLvfImpRA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].PkjAuEhiLFblGFpEoLUSgkwdAWMPc())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].PkjAuEhiLFblGFpEoLUSgkwdAWMPc())
			{
				return true;
			}
		}
		return false;
	}

	public bool DGcdjNqELnAXkeiqvQJhfCqswOgjA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < PmDvNiKVJkufXquQygjEfZqEGqjJ.Length; i++)
			{
				if (PmDvNiKVJkufXquQygjEfZqEGqjJ[i].ahgIigrJpIhpTnxlRkyDggCAkbSe())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			return false;
		}
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		for (int j = 0; j < num; j++)
		{
			if (OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_0, j].ahgIigrJpIhpTnxlRkyDggCAkbSe())
			{
				return true;
			}
		}
		return false;
	}

	public bool YMOkWPBFkuAOvEbuJqxTUUpcGpdU()
	{
		if (!xoAuuiPHfKtfIdmuWUhwThoMfribA(iTkQsdOFPUfKLaRwPuJdniEIuZOn) && !JrnbXYGVRMllUjXPkLAkHOAAMYKoB(RitZnURmkFkWEVCfDVjikgOXCgXY) && !xoAuuiPHfKtfIdmuWUhwThoMfribA(PkPZMMCFmSdnSCxyJRXfrBJhZMroA))
		{
			return JrnbXYGVRMllUjXPkLAkHOAAMYKoB(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		}
		return true;
	}

	public bool bUltwaEQmsjZteCIJcYQbZwnDZGqA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => JrnbXYGVRMllUjXPkLAkHOAAMYKoB(RitZnURmkFkWEVCfDVjikgOXCgXY), 
			ControllerType.Keyboard => xoAuuiPHfKtfIdmuWUhwThoMfribA(PkPZMMCFmSdnSCxyJRXfrBJhZMroA), 
			ControllerType.Mouse => xoAuuiPHfKtfIdmuWUhwThoMfribA(iTkQsdOFPUfKLaRwPuJdniEIuZOn), 
			ControllerType.Custom => JrnbXYGVRMllUjXPkLAkHOAAMYKoB(LMaEHSPgxLTEntaTzvCuYYmfQGhs), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool zFHwAolbyCTREdOBNkeWZnyKdtAU()
	{
		if (!vfWVmXzqpPASuLBqIAErgxxXDqCk(iTkQsdOFPUfKLaRwPuJdniEIuZOn) && !dPwEhOhmnUBcaFUsBkXwyLwryBnnb(RitZnURmkFkWEVCfDVjikgOXCgXY) && !vfWVmXzqpPASuLBqIAErgxxXDqCk(PkPZMMCFmSdnSCxyJRXfrBJhZMroA))
		{
			return dPwEhOhmnUBcaFUsBkXwyLwryBnnb(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		}
		return true;
	}

	public bool czwlATmomEnmkTdbVkVpmkwaFQKh(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => dPwEhOhmnUBcaFUsBkXwyLwryBnnb(RitZnURmkFkWEVCfDVjikgOXCgXY), 
			ControllerType.Keyboard => vfWVmXzqpPASuLBqIAErgxxXDqCk(PkPZMMCFmSdnSCxyJRXfrBJhZMroA), 
			ControllerType.Mouse => vfWVmXzqpPASuLBqIAErgxxXDqCk(iTkQsdOFPUfKLaRwPuJdniEIuZOn), 
			ControllerType.Custom => dPwEhOhmnUBcaFUsBkXwyLwryBnnb(LMaEHSPgxLTEntaTzvCuYYmfQGhs), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool AuzPaDohBsldrIExVgkofTlOZrXKA()
	{
		if (!zayrsKUAqIeuxhlvZOwkKgCqiTOo(iTkQsdOFPUfKLaRwPuJdniEIuZOn) && !EgwSsgDEHApiBXZDkWihjnlOOipj(RitZnURmkFkWEVCfDVjikgOXCgXY) && !zayrsKUAqIeuxhlvZOwkKgCqiTOo(PkPZMMCFmSdnSCxyJRXfrBJhZMroA))
		{
			return EgwSsgDEHApiBXZDkWihjnlOOipj(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		}
		return true;
	}

	public bool kWiAkgSeMXGSldyxbysQftQaDlN(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => EgwSsgDEHApiBXZDkWihjnlOOipj(RitZnURmkFkWEVCfDVjikgOXCgXY), 
			ControllerType.Keyboard => zayrsKUAqIeuxhlvZOwkKgCqiTOo(PkPZMMCFmSdnSCxyJRXfrBJhZMroA), 
			ControllerType.Mouse => zayrsKUAqIeuxhlvZOwkKgCqiTOo(iTkQsdOFPUfKLaRwPuJdniEIuZOn), 
			ControllerType.Custom => EgwSsgDEHApiBXZDkWihjnlOOipj(LMaEHSPgxLTEntaTzvCuYYmfQGhs), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool NoXZwEolZVJIBzKhpjDIFDxanCvJA()
	{
		if (!TzdMTfOcfRGTSJYCWMqWPLlpLoOW(iTkQsdOFPUfKLaRwPuJdniEIuZOn) && !nUCAULeJTvMwZcQTfZUsKHyUbzLmB(RitZnURmkFkWEVCfDVjikgOXCgXY) && !TzdMTfOcfRGTSJYCWMqWPLlpLoOW(PkPZMMCFmSdnSCxyJRXfrBJhZMroA))
		{
			return nUCAULeJTvMwZcQTfZUsKHyUbzLmB(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		}
		return true;
	}

	public bool KbdJOOjeiWuCOSScbiTJiKVAdgdN(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => nUCAULeJTvMwZcQTfZUsKHyUbzLmB(RitZnURmkFkWEVCfDVjikgOXCgXY), 
			ControllerType.Keyboard => TzdMTfOcfRGTSJYCWMqWPLlpLoOW(PkPZMMCFmSdnSCxyJRXfrBJhZMroA), 
			ControllerType.Mouse => TzdMTfOcfRGTSJYCWMqWPLlpLoOW(iTkQsdOFPUfKLaRwPuJdniEIuZOn), 
			ControllerType.Custom => nUCAULeJTvMwZcQTfZUsKHyUbzLmB(LMaEHSPgxLTEntaTzvCuYYmfQGhs), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool mFxEIeqXbBgHEbqGoYMqPwVKfYIjA()
	{
		if (!iUcaCgRcHZvZIXcnMKqzSyDjuHCg(iTkQsdOFPUfKLaRwPuJdniEIuZOn) && !GdxGrMYFcQaghKRBAmceZSZviknL(RitZnURmkFkWEVCfDVjikgOXCgXY) && !iUcaCgRcHZvZIXcnMKqzSyDjuHCg(PkPZMMCFmSdnSCxyJRXfrBJhZMroA))
		{
			return GdxGrMYFcQaghKRBAmceZSZviknL(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		}
		return true;
	}

	public bool tWPkxtpDeHBzFYgDvDlcvdXAbdSn(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => GdxGrMYFcQaghKRBAmceZSZviknL(RitZnURmkFkWEVCfDVjikgOXCgXY), 
			ControllerType.Keyboard => iUcaCgRcHZvZIXcnMKqzSyDjuHCg(PkPZMMCFmSdnSCxyJRXfrBJhZMroA), 
			ControllerType.Mouse => iUcaCgRcHZvZIXcnMKqzSyDjuHCg(iTkQsdOFPUfKLaRwPuJdniEIuZOn), 
			ControllerType.Custom => GdxGrMYFcQaghKRBAmceZSZviknL(LMaEHSPgxLTEntaTzvCuYYmfQGhs), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool JrnbXYGVRMllUjXPkLAkHOAAMYKoB<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool xoAuuiPHfKtfIdmuWUhwThoMfribA(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool dPwEhOhmnUBcaFUsBkXwyLwryBnnb<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool vfWVmXzqpPASuLBqIAErgxxXDqCk(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool EgwSsgDEHApiBXZDkWihjnlOOipj<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool zayrsKUAqIeuxhlvZOwkKgCqiTOo(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool nUCAULeJTvMwZcQTfZUsKHyUbzLmB<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool TzdMTfOcfRGTSJYCWMqWPLlpLoOW(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool GdxGrMYFcQaghKRBAmceZSZviknL<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool iUcaCgRcHZvZIXcnMKqzSyDjuHCg(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller RsLBpxiiSzdFDOgFeSCbhQNASkMCb()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(iTkQsdOFPUfKLaRwPuJdniEIuZOn, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(PkPZMMCFmSdnSCxyJRXfrBJhZMroA, ref lastController, ref lastTime);
		IList<Joystick> ritZnURmkFkWEVCfDVjikgOXCgXY = RitZnURmkFkWEVCfDVjikgOXCgXY;
		for (int i = 0; i < qHNpazdlcHQNVocnmulXYfyMuYzA; i++)
		{
			InputTools.CompareLastActiveController(ritZnURmkFkWEVCfDVjikgOXCgXY[i], ref lastController, ref lastTime);
		}
		IList<CustomController> lMaEHSPgxLTEntaTzvCuYYmfQGhs = LMaEHSPgxLTEntaTzvCuYYmfQGhs;
		for (int j = 0; j < VoblREuvmSdxTWYQiDXrETWyuEMy; j++)
		{
			InputTools.CompareLastActiveController(lMaEHSPgxLTEntaTzvCuYYmfQGhs[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = PkPZMMCFmSdnSCxyJRXfrBJhZMroA;
		}
		return lastController;
	}

	public Controller zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(RitZnURmkFkWEVCfDVjikgOXCgXY[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return WbGyhovABrZvNbHXBQtDZzjtIeFm;
		case ControllerType.Mouse:
			return MojdWfKBpNKzYvgrFqSyOknzCmgl;
		case ControllerType.Custom:
		{
			int count = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(LMaEHSPgxLTEntaTzvCuYYmfQGhs[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 RsLBpxiiSzdFDOgFeSCbhQNASkMCb<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType hyFwmTPcrfXrXwMYSRuQqSvsRfLq()
	{
		return RsLBpxiiSzdFDOgFeSCbhQNASkMCb()?.type ?? ControllerType.Keyboard;
	}

	public void fWBTJGdozotbfdLvZyOPxHDsudkw(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			OSzVltEcqxtbqXteMLWFWCMnEjZr = true;
			AbmzxYnzWSRToQeAfODCRIlsoqag.EFzQGuAQTGbLuEvfmjFZxyWujhtE(P_0);
		}
	}

	public void DXwrTYrhtsWroWDCFChPKZgtVNiI(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			OSzVltEcqxtbqXteMLWFWCMnEjZr = true;
			AbmzxYnzWSRToQeAfODCRIlsoqag.XvebCQiMoKTByvwqJytxKbTocCaK(P_0, P_1);
		}
	}

	public void GMakonxJliVqNqokVtWyPGjkCOzi(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			AbmzxYnzWSRToQeAfODCRIlsoqag.hpjGAPqUmGuoIzjOfNKTgyPzEQMg(P_0);
		}
	}

	public void TdOAMfrooNnMsyqDcXcUginnLUDD(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			AbmzxYnzWSRToQeAfODCRIlsoqag.cWkTbFXPSQkDlqlJlUikphscxuEu(P_0, P_1);
		}
	}

	public void xDLcJXRbgQpxtSmwPuXpwkhVCQjd()
	{
		AbmzxYnzWSRToQeAfODCRIlsoqag.ntBdccHaofMCaSstYpfctGEgaXLaA();
	}

	public void BrOiqvyGyKjhnWZmTAAcAqIVEJXb(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			fGkZuFMBgaIHodEmmpfxJOQiIfFwA.EFzQGuAQTGbLuEvfmjFZxyWujhtE(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)byzElucovkjkQKUbrOvgJBfMWgMA)
			{
				return;
			}
			pIyhAOaNzwWhgQYvIZZsCjLiMBfC[P_0].EFzQGuAQTGbLuEvfmjFZxyWujhtE(P_1);
		}
		OSzVltEcqxtbqXteMLWFWCMnEjZr = true;
	}

	public void wKtOmwFQxSdGcDdOGAhCiAAsasPi(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			fGkZuFMBgaIHodEmmpfxJOQiIfFwA.XvebCQiMoKTByvwqJytxKbTocCaK(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)byzElucovkjkQKUbrOvgJBfMWgMA)
			{
				return;
			}
			pIyhAOaNzwWhgQYvIZZsCjLiMBfC[P_0].XvebCQiMoKTByvwqJytxKbTocCaK(P_1, P_2);
		}
		OSzVltEcqxtbqXteMLWFWCMnEjZr = true;
	}

	public void MFRIiiUwBqJseQyEacdlKPWnyUoT(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				fGkZuFMBgaIHodEmmpfxJOQiIfFwA.hpjGAPqUmGuoIzjOfNKTgyPzEQMg(P_1);
			}
			else if ((uint)P_0 < (uint)byzElucovkjkQKUbrOvgJBfMWgMA)
			{
				pIyhAOaNzwWhgQYvIZZsCjLiMBfC[P_0].hpjGAPqUmGuoIzjOfNKTgyPzEQMg(P_1);
			}
		}
	}

	public void EqSxISdReDBnmRFMTTkouHOYJtKK(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				fGkZuFMBgaIHodEmmpfxJOQiIfFwA.cWkTbFXPSQkDlqlJlUikphscxuEu(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)byzElucovkjkQKUbrOvgJBfMWgMA)
			{
				pIyhAOaNzwWhgQYvIZZsCjLiMBfC[P_0].cWkTbFXPSQkDlqlJlUikphscxuEu(P_1, P_2);
			}
		}
	}

	public void FeTCZPXIyIlZgenBOpYHdiuCygLi(int P_0)
	{
		if (P_0 == 9999999)
		{
			fGkZuFMBgaIHodEmmpfxJOQiIfFwA.ntBdccHaofMCaSstYpfctGEgaXLaA();
		}
		else if ((uint)P_0 < (uint)byzElucovkjkQKUbrOvgJBfMWgMA)
		{
			pIyhAOaNzwWhgQYvIZZsCjLiMBfC[P_0].ntBdccHaofMCaSstYpfctGEgaXLaA();
		}
	}

	private void WxUiDZNBemmCcLQKdlfkCxbDiVCu()
	{
		if (AbmzxYnzWSRToQeAfODCRIlsoqag.GXrSRuaiLkgnUhUtYtlXlxsXXpgy > 0)
		{
			AbmzxYnzWSRToQeAfODCRIlsoqag.IERaAcnbZdeqqVforLIntIhnZIzO(-1, RsLBpxiiSzdFDOgFeSCbhQNASkMCb(), zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Joystick), zEbHmcCgAzCYMFSKEBlUblRaUBXWB(ControllerType.Custom));
		}
		if (fGkZuFMBgaIHodEmmpfxJOQiIfFwA.GXrSRuaiLkgnUhUtYtlXlxsXXpgy > 0)
		{
			Player.ControllerHelper controllers = zidunNXKnrdgqgGrjLiIBbIGdIYK.TjnOdGcnoTiIujHJzGeRHFXfoKtbb().controllers;
			fGkZuFMBgaIHodEmmpfxJOQiIfFwA.IERaAcnbZdeqqVforLIntIhnZIzO(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < byzElucovkjkQKUbrOvgJBfMWgMA; i++)
		{
			if (pIyhAOaNzwWhgQYvIZZsCjLiMBfC[i].GXrSRuaiLkgnUhUtYtlXlxsXXpgy != 0)
			{
				Player.ControllerHelper controllers2 = zidunNXKnrdgqgGrjLiIBbIGdIYK.GRMgmqBsZTglRSltAPKVZlJlPGmKA[i].controllers;
				pIyhAOaNzwWhgQYvIZZsCjLiMBfC[i].IERaAcnbZdeqqVforLIntIhnZIzO(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void oSxeerbdZuiFfoUevYuwJpLZPtMP(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < RitZnURmkFkWEVCfDVjikgOXCgXY.Count; i++)
		{
			if (RitZnURmkFkWEVCfDVjikgOXCgXY[i] != null)
			{
				XUwVuWnPADvZMdktPguAdwvaibff(RitZnURmkFkWEVCfDVjikgOXCgXY[i], P_0);
			}
		}
		for (int j = 0; j < cbVzSewflFZFAUJBlQNhdsuPWCJc.Count; j++)
		{
			if (cbVzSewflFZFAUJBlQNhdsuPWCJc[j] != null)
			{
				XUwVuWnPADvZMdktPguAdwvaibff(cbVzSewflFZFAUJBlQNhdsuPWCJc[j], P_0);
			}
		}
		for (int k = 0; k < VoblREuvmSdxTWYQiDXrETWyuEMy; k++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[k] != null)
			{
				XUwVuWnPADvZMdktPguAdwvaibff(LMaEHSPgxLTEntaTzvCuYYmfQGhs[k], P_0);
			}
		}
		XUwVuWnPADvZMdktPguAdwvaibff(iTkQsdOFPUfKLaRwPuJdniEIuZOn, P_0);
	}

	private void XUwVuWnPADvZMdktPguAdwvaibff(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].ebyrXyRCdWERLtGljixMusqSBzocA._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> ZYbaHWzSNwwTMLNxlkTIPBRDBiVGA<_0001>() where _0001 : IControllerTemplate
	{
		return fwQJBzTkbJwCmMOrKtWjjrsyABSN.IgIylPTTuRBEtTXkGHmhoOzerfFQ<_0001>();
	}

	private void FhVwrhGxFTgzNnCjVIvNuLQsHyLV(List<InputBehavior> P_0)
	{
		smFNyINwNBDJrcWCSuSCEiCtFVnv = ReInput.lQrqwhCfIfIgktHXoHKYyChngzyX;
		zidunNXKnrdgqgGrjLiIBbIGdIYK = ReInput.BIeoRJtgpppJNOjultHrXTwltUhx;
		RitZnURmkFkWEVCfDVjikgOXCgXY = new List<Joystick>();
		cbVzSewflFZFAUJBlQNhdsuPWCJc = new List<Joystick>();
		LMaEHSPgxLTEntaTzvCuYYmfQGhs = new List<CustomController>();
		SydKJHEqOtulzGXQfgjTYBNpQrrs = smFNyINwNBDJrcWCSuSCEiCtFVnv.hfitTKBgvpRyxgDrUNUsfsirTdhU;
		byzElucovkjkQKUbrOvgJBfMWgMA = zidunNXKnrdgqgGrjLiIBbIGdIYK.MAShPKKnbATAFLRWtWcZveXJQFbZ;
		GPviCVwOOIwetrpSmYfexOPlikmj = FpEfGEnfXOGVPnyeJONGRxmGEpRW;
		IdxcFJJzrlSZXTxjXmoJFbmTYXDk = 0;
		SlgQZjqHGmBFexewLAqipumNjCXE = new ADictionary<int, OjZrrlCIvIWhQTySouHoNAWxEHfu>();
		SlgQZjqHGmBFexewLAqipumNjCXE.Add(ReInput.players.GetSystemPlayer().id, new OjZrrlCIvIWhQTySouHoNAWxEHfu(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			SlgQZjqHGmBFexewLAqipumNjCXE.Add(players[i].id, new OjZrrlCIvIWhQTySouHoNAWxEHfu(P_0));
		}
		owtNPvDnTuOfRvYKzPhSGVmqUUio = new ReadOnlyCollection<Joystick>(RitZnURmkFkWEVCfDVjikgOXCgXY);
		onVFLifHbbmINKSQWfyUimkktaqt = new ReadOnlyCollection<CustomController>(LMaEHSPgxLTEntaTzvCuYYmfQGhs);
		fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.DQdaxKmwQwNmnZddBBORBDDRLxKI(USOEXNKqMLedechDDjghvJLsJEnAb);
		oCUpFgROsDhbtgLwTCmOZSJDIuhI = new fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[(byzElucovkjkQKUbrOvgJBfMWgMA + 1) * SydKJHEqOtulzGXQfgjTYBNpQrrs];
		int num = 0;
		PmDvNiKVJkufXquQygjEfZqEGqjJ = new fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[SydKJHEqOtulzGXQfgjTYBNpQrrs];
		for (int j = 0; j < SydKJHEqOtulzGXQfgjTYBNpQrrs; j++)
		{
			InputAction inputAction = smFNyINwNBDJrcWCSuSCEiCtFVnv.yTKMdleDUKDXUckqZKRbMrQknuoC(j);
			InputBehavior inputBehavior = SlgQZjqHGmBFexewLAqipumNjCXE[9999999].doRHTrXNrHhcybhiUuVrXvhyiCCV(inputAction.behaviorId);
			fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = new fDpcCKCuzPiJSPYRYUOXoNEJrNYcb(9999999, inputAction, inputBehavior, USOEXNKqMLedechDDjghvJLsJEnAb);
			PmDvNiKVJkufXquQygjEfZqEGqjJ[j] = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2;
			oCUpFgROsDhbtgLwTCmOZSJDIuhI[num] = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2;
			num++;
		}
		OcAzyvdYfuERtwDFpbXcuvrOHpBk = new fDpcCKCuzPiJSPYRYUOXoNEJrNYcb[byzElucovkjkQKUbrOvgJBfMWgMA, SydKJHEqOtulzGXQfgjTYBNpQrrs];
		for (int k = 0; k < byzElucovkjkQKUbrOvgJBfMWgMA; k++)
		{
			for (int l = 0; l < SydKJHEqOtulzGXQfgjTYBNpQrrs; l++)
			{
				InputAction inputAction2 = smFNyINwNBDJrcWCSuSCEiCtFVnv.yTKMdleDUKDXUckqZKRbMrQknuoC(l);
				InputBehavior inputBehavior2 = SlgQZjqHGmBFexewLAqipumNjCXE[players[k].id].doRHTrXNrHhcybhiUuVrXvhyiCCV(inputAction2.behaviorId);
				fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3 = new fDpcCKCuzPiJSPYRYUOXoNEJrNYcb(k, inputAction2, inputBehavior2, USOEXNKqMLedechDDjghvJLsJEnAb);
				OcAzyvdYfuERtwDFpbXcuvrOHpBk[k, l] = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3;
				oCUpFgROsDhbtgLwTCmOZSJDIuhI[num] = fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.EviYdZZAcXSKWfhzsldcaszNDheN;
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
				CustomController customController = NLzlMtxpmeUuvzoGWKnjaIzBvDLD(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					zidunNXKnrdgqgGrjLiIBbIGdIYK.UvJedjalXzUlKEDfIYQQGGlTWIFK(num2)?.controllers.lzlUhqMkgvSdKtQXViQghcMPojmX(customController, false);
				}
			}
		}
		tKHcPozVNfrXAsYvLmspYvTngefT = new BCxuTLhLYqllXBOElLIjjeywjrCf();
		pipLdkJyHRGPDdhZcGQQJsrxHYBdb = new BCxuTLhLYqllXBOElLIjjeywjrCf[byzElucovkjkQKUbrOvgJBfMWgMA];
		for (int num3 = 0; num3 < byzElucovkjkQKUbrOvgJBfMWgMA; num3++)
		{
			pipLdkJyHRGPDdhZcGQQJsrxHYBdb[num3] = new BCxuTLhLYqllXBOElLIjjeywjrCf();
		}
		AbmzxYnzWSRToQeAfODCRIlsoqag = new global::hSATvCUkYzwQNlbWnASxkQVqqbRw<ActiveControllerChangedDelegate>();
		fGkZuFMBgaIHodEmmpfxJOQiIfFwA = new global::hSATvCUkYzwQNlbWnASxkQVqqbRw<PlayerActiveControllerChangedDelegate>();
		pIyhAOaNzwWhgQYvIZZsCjLiMBfC = new global::hSATvCUkYzwQNlbWnASxkQVqqbRw<PlayerActiveControllerChangedDelegate>[zidunNXKnrdgqgGrjLiIBbIGdIYK.MAShPKKnbATAFLRWtWcZveXJQFbZ];
		ArrayTools.Populate(pIyhAOaNzwWhgQYvIZZsCjLiMBfC);
	}

	private void zjENPUcCfKtncrryYEqjnnAAAKzCA(UpdateLoopType P_0)
	{
		int count = RitZnURmkFkWEVCfDVjikgOXCgXY.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = RitZnURmkFkWEVCfDVjikgOXCgXY[i];
			if (joystick.enabled)
			{
				lTcbKOZkHMDDXgjIVuethOcSdFFO(joystick.AlMUvvTnIgrTRXyrwbEgurgdFIKr, joystick.zfVdfqKDuqZKjafBdqgdinjRQNeGb);
				joystick.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
			}
		}
		if (PkPZMMCFmSdnSCxyJRXfrBJhZMroA.enabled)
		{
			PkPZMMCFmSdnSCxyJRXfrBJhZMroA.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
		}
		else if (BlzPLGszGatVrtNyQoZPfohizzyf)
		{
			PkPZMMCFmSdnSCxyJRXfrBJhZMroA.PiJegrHBDJdMBsHBkIOpZqNVApwP(P_0);
		}
		if (iTkQsdOFPUfKLaRwPuJdniEIuZOn.enabled)
		{
			iTkQsdOFPUfKLaRwPuJdniEIuZOn.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
		}
		int count2 = LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = LMaEHSPgxLTEntaTzvCuYYmfQGhs[j];
			if (customController.enabled)
			{
				customController.flDnNlkPWbTQkpbmTXPywdioEIOaA();
				customController.KvONimPsnvghlMkZzyXoBEjvJCHX(P_0);
			}
		}
	}

	private void RfVfpsBzbZbaReileoYvvQRnERGmB(UpdateLoopType P_0)
	{
		fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.hmpoYRnSnruhjlgwNyttwfWiBwdo(P_0);
		Player[] array = zidunNXKnrdgqgGrjLiIBbIGdIYK.TBpNyBPMLBhkxjATrrlDocidIume;
		int num = array.Length;
		bool enabled = PkPZMMCFmSdnSCxyJRXfrBJhZMroA.enabled;
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
						KwvzpGGrJdBjKwVtUJwpvMsLgagB.WyPDmIfDsOajkRTJqLgzRUbCfTgfb(maps[j]);
					}
				}
			}
		}
		bool enabled2 = iTkQsdOFPUfKLaRwPuJdniEIuZOn.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.ixzXWswlmXttFeghQHkgbzqpdItI(GPviCVwOOIwetrpSmYfexOPlikmj);
			if (enabled || BlzPLGszGatVrtNyQoZPfohizzyf)
			{
				controllers.ZjZqckTJJWCjMbHENznRqXwlBUGsA(PkPZMMCFmSdnSCxyJRXfrBJhZMroA, KwvzpGGrJdBjKwVtUJwpvMsLgagB, GPviCVwOOIwetrpSmYfexOPlikmj);
			}
			if (enabled2)
			{
				controllers.PRHHNIprLhiABFXDKZlPRlYOFjDI(iTkQsdOFPUfKLaRwPuJdniEIuZOn, GPviCVwOOIwetrpSmYfexOPlikmj);
			}
			controllers.LDHiTKPPbwFQICLIWIxaaqXPuTPdA(GPviCVwOOIwetrpSmYfexOPlikmj);
		}
		for (int l = 0; l < oCUpFgROsDhbtgLwTCmOZSJDIuhI.Length; l++)
		{
			if (oCUpFgROsDhbtgLwTCmOZSJDIuhI[l].FSbofMtEeszlbNlowrhQrgSXeBVAA != fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.GrieQykFnpbjMrRwWBqEsLereTsH.Disabled)
			{
				oCUpFgROsDhbtgLwTCmOZSJDIuhI[l].PyfIGdArGYvGrqlFOAvcLhjxvMVI();
			}
		}
		fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.nClkjwghjkzACVeaWeoVfMmsfAAC();
		if (!YjGuoNezllWUCYlqiPyIQRojeOEj)
		{
			return;
		}
		if (tKHcPozVNfrXAsYvLmspYvTngefT.mQuBsyAHuWgGMgVseLjUOaPECQufc > 0)
		{
			for (int m = 0; m < SydKJHEqOtulzGXQfgjTYBNpQrrs; m++)
			{
				fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2 = PmDvNiKVJkufXquQygjEfZqEGqjJ[m];
				if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2.FSbofMtEeszlbNlowrhQrgSXeBVAA != fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.GrieQykFnpbjMrRwWBqEsLereTsH.Disabled)
				{
					tKHcPozVNfrXAsYvLmspYvTngefT.pdqLFPnoJpIypJUIQYBegAEIzwlQ(fDpcCKCuzPiJSPYRYUOXoNEJrNYcb2, P_0);
				}
			}
		}
		for (int n = 0; n < byzElucovkjkQKUbrOvgJBfMWgMA; n++)
		{
			BCxuTLhLYqllXBOElLIjjeywjrCf bCxuTLhLYqllXBOElLIjjeywjrCf = pipLdkJyHRGPDdhZcGQQJsrxHYBdb[n];
			if (bCxuTLhLYqllXBOElLIjjeywjrCf.mQuBsyAHuWgGMgVseLjUOaPECQufc == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < SydKJHEqOtulzGXQfgjTYBNpQrrs; num2++)
			{
				fDpcCKCuzPiJSPYRYUOXoNEJrNYcb fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3 = OcAzyvdYfuERtwDFpbXcuvrOHpBk[n, num2];
				if (fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3.FSbofMtEeszlbNlowrhQrgSXeBVAA != fDpcCKCuzPiJSPYRYUOXoNEJrNYcb.GrieQykFnpbjMrRwWBqEsLereTsH.Disabled)
				{
					bCxuTLhLYqllXBOElLIjjeywjrCf.pdqLFPnoJpIypJUIQYBegAEIzwlQ(fDpcCKCuzPiJSPYRYUOXoNEJrNYcb3, P_0);
				}
			}
		}
	}

	private void FpEfGEnfXOGVPnyeJONGRxmGEpRW(bool P_0, int P_1, int P_2)
	{
		int num = smFNyINwNBDJrcWCSuSCEiCtFVnv.BHxFaZjfRzTlJULUJJhdhsCeRfErb(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				PmDvNiKVJkufXquQygjEfZqEGqjJ[num].sJvEVKSkyfouwaTmUuVPXwRMfhKn(P_0);
			}
			else
			{
				OcAzyvdYfuERtwDFpbXcuvrOHpBk[P_1, num].sJvEVKSkyfouwaTmUuVPXwRMfhKn(P_0);
			}
		}
	}

	private void erCPjYtqaFsDgwewrwVwNdOastdf(BridgedController P_0)
	{
		int num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0.sourceJoystick.rewiredId, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = OPPrEjvbaCuwFNdEctjpvBAdwRHw(P_0.sourceJoystick.rewiredId, LFBQhPqZDgVXYtdjhOnCisdXRbjt.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = cbVzSewflFZFAUJBlQNhdsuPWCJc[num];
			cbVzSewflFZFAUJBlQNhdsuPWCJc.RemoveAt(num);
			joystick.IcncIVaTpJCUlQRYUlrjJjSEQQCA(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		RitZnURmkFkWEVCfDVjikgOXCgXY.Add(joystick);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Add(joystick);
		RitZnURmkFkWEVCfDVjikgOXCgXY.Sort(Joystick.dIAeAKtMNNvvJzlcRCiRITZPdWRXA);
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.qevgkVDPuVaeixjpkpKzloScNZWQ(joystick);
	}

	private void rjqBsuJsGYLTfLqGMgICTvYDuQMs(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= RitZnURmkFkWEVCfDVjikgOXCgXY.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = RitZnURmkFkWEVCfDVjikgOXCgXY[P_0];
		joystick.isConnected = false;
		if (qvjwYOmNiYDGZWoKAkOxmCyuZBie != null)
		{
			qvjwYOmNiYDGZWoKAkOxmCyuZBie(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (IadKsleFZNpqSJDgdsZvoiwXlXYg != null)
		{
			IadKsleFZNpqSJDgdsZvoiwXlXYg(joystick.type, joystick.id);
		}
		RitZnURmkFkWEVCfDVjikgOXCgXY.RemoveAt(P_0);
		cbVzSewflFZFAUJBlQNhdsuPWCJc.Add(joystick);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Remove(joystick);
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.XVEqIlUIOtfUtTWfTYpbORGLUmrF(joystick);
		joystick.scCwpLEHFiuvitLgzEfOOpCTYgPj();
	}

	private void sUqdcPCisVPyRfyAXGZfcwSmUkT()
	{
		for (int num = RitZnURmkFkWEVCfDVjikgOXCgXY.Count - 1; num >= 0; num--)
		{
			rjqBsuJsGYLTfLqGMgICTvYDuQMs(num);
		}
	}

	private bool JaXYjaaFEbewZhEBbRCFtynoJuHH(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count; i++)
		{
			if (LMaEHSPgxLTEntaTzvCuYYmfQGhs[i] == P_0)
			{
				return true;
			}
		}
		LMaEHSPgxLTEntaTzvCuYYmfQGhs.Add(P_0);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Add(P_0);
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.qevgkVDPuVaeixjpkpKzloScNZWQ(P_0);
		return true;
	}

	private bool FLztcUwCAYhoiJRLfovtVmKZjIdsA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		fwQJBzTkbJwCmMOrKtWjjrsyABSN.XVEqIlUIOtfUtTWfTYpbORGLUmrF(P_0);
		ltwgMwNKkOPlpGSPnKlMQfehgdDx.Remove(P_0);
		return LMaEHSPgxLTEntaTzvCuYYmfQGhs.Remove(P_0);
	}

	private BCxuTLhLYqllXBOElLIjjeywjrCf soulelFShhAanYCHayieWSSkVVLp(int P_0)
	{
		if (P_0 == 9999999)
		{
			return tKHcPozVNfrXAsYvLmspYvTngefT;
		}
		if (P_0 < 0 || P_0 >= ReInput.BIeoRJtgpppJNOjultHrXTwltUhx.MAShPKKnbATAFLRWtWcZveXJQFbZ)
		{
			return null;
		}
		return pipLdkJyHRGPDdhZcGQQJsrxHYBdb[P_0];
	}

	private void FNjcGpOdFaEOsHJwkkgFuhWDemkL(bool P_0)
	{
		if (!P_0)
		{
			KwvzpGGrJdBjKwVtUJwpvMsLgagB.mPGVQCqUYnmrGOePLjdjonqAdohL();
		}
	}

	private void ZZSBajzKzHvUJJrgPHxugTBrtnHi(bool P_0)
	{
		PkPZMMCFmSdnSCxyJRXfrBJhZMroA.crbQLMpBgFCTkCHGXdkEoAiefEsyA(P_0);
		iTkQsdOFPUfKLaRwPuJdniEIuZOn.crbQLMpBgFCTkCHGXdkEoAiefEsyA(P_0);
		for (int i = 0; i < RitZnURmkFkWEVCfDVjikgOXCgXY.Count; i++)
		{
			RitZnURmkFkWEVCfDVjikgOXCgXY[i].crbQLMpBgFCTkCHGXdkEoAiefEsyA(P_0);
		}
		for (int j = 0; j < LMaEHSPgxLTEntaTzvCuYYmfQGhs.Count; j++)
		{
			LMaEHSPgxLTEntaTzvCuYYmfQGhs[j].crbQLMpBgFCTkCHGXdkEoAiefEsyA(P_0);
		}
	}

	public void Dispose()
	{
		hWkCToEpNpgswNknUxybsjxHFCoyA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected void DnxoIAqlBvZeKtjutfsOozoPFLKv()
	{
		try
		{
			hWkCToEpNpgswNknUxybsjxHFCoyA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void hWkCToEpNpgswNknUxybsjxHFCoyA(bool P_0)
	{
		if (ikxUDRSNGbCjLIfWhCsRVVLfhYGTA)
		{
			return;
		}
		if (P_0)
		{
			if (cIWFdZBJZsYMfnzBkLZUHNjxswYhA is IDisposable)
			{
				(cIWFdZBJZsYMfnzBkLZUHNjxswYhA as IDisposable).Dispose();
			}
			if (qQOlPjWfCqcUHyzQvsZRcWdYsVQg is IDisposable)
			{
				(qQOlPjWfCqcUHyzQvsZRcWdYsVQg as IDisposable).Dispose();
			}
		}
		ikxUDRSNGbCjLIfWhCsRVVLfhYGTA = true;
	}
}
