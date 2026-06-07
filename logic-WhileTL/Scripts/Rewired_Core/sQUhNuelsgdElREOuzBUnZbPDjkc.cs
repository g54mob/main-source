using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class sQUhNuelsgdElREOuzBUnZbPDjkc : IDisposable
{
	public enum rpdrpwFfKEBLcwJyfwMQnPKLzVeH
	{
		Connected = 0,
		Disconnected = 1
	}

	private class khlqfKxpusVMmYgTkYziUilpcTgr
	{
		public ADictionary<int, InputBehavior> rqzlMgBEqYlprpsgKizQkexqOZQq;

		public List<InputBehavior> PgtAQJhalbZOOqphFKgqwHgyQbao;

		public IList<InputBehavior> YyaCCXlhXGxgHjwlMRseRToWDlKg;

		public khlqfKxpusVMmYgTkYziUilpcTgr(List<InputBehavior> P_0)
		{
			PgtAQJhalbZOOqphFKgqwHgyQbao = new List<InputBehavior>(P_0.Count);
			rqzlMgBEqYlprpsgKizQkexqOZQq = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				rqzlMgBEqYlprpsgKizQkexqOZQq.Add(P_0[i].id, inputBehavior);
				PgtAQJhalbZOOqphFKgqwHgyQbao.Add(inputBehavior);
				num++;
			}
			YyaCCXlhXGxgHjwlMRseRToWDlKg = new ReadOnlyCollection<InputBehavior>(PgtAQJhalbZOOqphFKgqwHgyQbao);
		}

		public InputBehavior yTSFypaaqDQanuQXbqQkSUotvsej(int P_0)
		{
			if (PgtAQJhalbZOOqphFKgqwHgyQbao.Count == 0)
			{
				return null;
			}
			rqzlMgBEqYlprpsgKizQkexqOZQq.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return PgtAQJhalbZOOqphFKgqwHgyQbao[0];
			}
			return value;
		}
	}

	private sealed class mQfRXDfvFkYVFzBLjEUabbkYrpsI : IEnumerable<CustomController>, IDisposable, IEnumerator<CustomController>, IEnumerable, IEnumerator
	{
		private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

		private CustomController USjDTWbJtWhEBdYYYfLUglTcnnGrA;

		private int nOonfdwpqEUEASbbWObCvjhlCTmP;

		public sQUhNuelsgdElREOuzBUnZbPDjkc GZXxEqHwrHYIyUJtInpLwgTukJaY;

		private int zoiHITeHHutrGQznyRTuKhdHneZj;

		public int kMoGHUsPIEoIkxegTzmGNvqvyGWA;

		private int UEpLPksfBredyJjvXYRhpWcgLsVd;

		private int eolRghqutZOOIGqvOFTzJOGfYTsn;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
			}
		}

		[DebuggerHidden]
		public mQfRXDfvFkYVFzBLjEUabbkYrpsI(int P_0)
		{
			GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
			nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
			sQUhNuelsgdElREOuzBUnZbPDjkc gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
			if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
			{
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
				{
					return false;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				goto IL_007d;
			}
			GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
			UEpLPksfBredyJjvXYRhpWcgLsVd = gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
			eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
			goto IL_008d;
			IL_007d:
			eolRghqutZOOIGqvOFTzJOGfYTsn++;
			goto IL_008d;
			IL_008d:
			if (eolRghqutZOOIGqvOFTzJOGfYTsn < UEpLPksfBredyJjvXYRhpWcgLsVd)
			{
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat[eolRghqutZOOIGqvOFTzJOGfYTsn].sourceControllerId == zoiHITeHHutrGQznyRTuKhdHneZj)
				{
					USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat[eolRghqutZOOIGqvOFTzJOGfYTsn];
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
			mQfRXDfvFkYVFzBLjEUabbkYrpsI mQfRXDfvFkYVFzBLjEUabbkYrpsI2;
			if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
				mQfRXDfvFkYVFzBLjEUabbkYrpsI2 = this;
			}
			else
			{
				mQfRXDfvFkYVFzBLjEUabbkYrpsI2 = new mQfRXDfvFkYVFzBLjEUabbkYrpsI(0);
				mQfRXDfvFkYVFzBLjEUabbkYrpsI2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
			}
			mQfRXDfvFkYVFzBLjEUabbkYrpsI2.zoiHITeHHutrGQznyRTuKhdHneZj = kMoGHUsPIEoIkxegTzmGNvqvyGWA;
			return mQfRXDfvFkYVFzBLjEUabbkYrpsI2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class iAtPvQfUsFXtxbhbDezyOYOuhOFe : IEnumerable<CustomController>, IDisposable, IEnumerator<CustomController>, IEnumerable, IEnumerator
	{
		private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

		private CustomController USjDTWbJtWhEBdYYYfLUglTcnnGrA;

		private int nOonfdwpqEUEASbbWObCvjhlCTmP;

		public sQUhNuelsgdElREOuzBUnZbPDjkc GZXxEqHwrHYIyUJtInpLwgTukJaY;

		private string hIsTTgMcJDwwbFwfjrcyfPezNUQC;

		public string SdneKSDMLwNqVBTPrwJYGNkjUDeS;

		private int UEpLPksfBredyJjvXYRhpWcgLsVd;

		private int eolRghqutZOOIGqvOFTzJOGfYTsn;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
			}
		}

		[DebuggerHidden]
		public iAtPvQfUsFXtxbhbDezyOYOuhOFe(int P_0)
		{
			GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
			nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
			sQUhNuelsgdElREOuzBUnZbPDjkc gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
			if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
			{
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
				{
					return false;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				goto IL_0083;
			}
			GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
			UEpLPksfBredyJjvXYRhpWcgLsVd = gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
			eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
			goto IL_0093;
			IL_0083:
			eolRghqutZOOIGqvOFTzJOGfYTsn++;
			goto IL_0093;
			IL_0093:
			if (eolRghqutZOOIGqvOFTzJOGfYTsn < UEpLPksfBredyJjvXYRhpWcgLsVd)
			{
				if (gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat[eolRghqutZOOIGqvOFTzJOGfYTsn].tag.Equals(hIsTTgMcJDwwbFwfjrcyfPezNUQC, StringComparison.OrdinalIgnoreCase))
				{
					USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.kOeUzaAxrTTjHjJsuAnJIMiZdGat[eolRghqutZOOIGqvOFTzJOGfYTsn];
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
			iAtPvQfUsFXtxbhbDezyOYOuhOFe iAtPvQfUsFXtxbhbDezyOYOuhOFe2;
			if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
				iAtPvQfUsFXtxbhbDezyOYOuhOFe2 = this;
			}
			else
			{
				iAtPvQfUsFXtxbhbDezyOYOuhOFe2 = new iAtPvQfUsFXtxbhbDezyOYOuhOFe(0);
				iAtPvQfUsFXtxbhbDezyOYOuhOFe2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
			}
			iAtPvQfUsFXtxbhbDezyOYOuhOFe2.hIsTTgMcJDwwbFwfjrcyfPezNUQC = SdneKSDMLwNqVBTPrwJYGNkjUDeS;
			return iAtPvQfUsFXtxbhbDezyOYOuhOFe2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> JuRitPJrgSMAWSUYDTsgpTqpPALm;

	private List<Joystick> szfbyoEHroNfHCaaumoheusFcIKHc;

	private List<CustomController> kOeUzaAxrTTjHjJsuAnJIMiZdGat;

	private List<Controller> clJJgGHmUINNlMhgMrVgDvxkJicW;

	private ReadOnlyCollection<Controller> cVTxgVvNmcUHqSmugkCKRmxWANHt;

	private Keyboard THRtUdLBqPKCSvKIahLGAdLQOdVMA;

	private Mouse mEHvdpDSFOqqnkOaipXQzXsobfvk;

	private ConfigVars ojFvlpKzaZHmKUfEuuuNjYOwvQoW;

	private HuFUPnVcilGVsLkOQFTNYtvJAVLr[] hivTeFgZnTjTSeliLxeDstBRQIcU;

	private HuFUPnVcilGVsLkOQFTNYtvJAVLr[] mfifTKGNAuFdGBOUlQVuHsGEZyWgA;

	private HuFUPnVcilGVsLkOQFTNYtvJAVLr[,] TylDOBzcRcffJdHuSQWBLMxONAHS;

	private BxbbvKXhLYllwMlNukVwsgZhBIs gzxhDgphqicLqbTlEVWmvHZfIoJW;

	private lnDNmgCdAUoldOfPbHChIcFoEfFjb JkdIojqDoZbOFVpmZOJdkjXreNri;

	private lnDNmgCdAUoldOfPbHChIcFoEfFjb[] ABdiqcjGPOFjXCoPhncNYaRTxwiac;

	private ZdahRlzMRHmytynTlBGzlbkkdrOo<ActiveControllerChangedDelegate> svsnQpLpxAHWjGNkPJopXmwFbMOS;

	private ZdahRlzMRHmytynTlBGzlbkkdrOo<PlayerActiveControllerChangedDelegate> sEJtBycGSEfYZIpDDuXqvYeeFEan;

	private ZdahRlzMRHmytynTlBGzlbkkdrOo<PlayerActiveControllerChangedDelegate>[] oKzdgYKwAFDfpJBCZeBFNiPhfSeJ;

	private ADictionary<int, khlqfKxpusVMmYgTkYziUilpcTgr> oJReXMprxlfvAScuBrsTrAQMuldu;

	private readonly ozJCNCgYiYUtKitDXELFzszuhHbtA poHBjfNcWvllzJNNsERwbrPxRXyc;

	private IList<Joystick> FdVqxYUvpACPAZkfhNjUbghfNeQj;

	private IList<CustomController> FEVFjUIcuIeoMgNkAmZxVHlgfbecA;

	private int eNjegqeOwkgxMDAjDUrMRxpMAPnz;

	private bool jYeZsMeNsIJLGmlRwyPXaqKuUsHK;

	private bool enWIRBzErsHtNhmMquKMBRbbrnXg;

	private bool uqEOuwnDASzRJFFuQguSKkcNKviw;

	private IUnifiedKeyboardSource oAyvPljoNGQuBPxukPSgGbJpoolb;

	private IUnifiedMouseSource RCrTjdsPXBdeyCAKlBltMOiTkcWvA;

	private int HtTLBFYHFdHLTiyCMjwDiFBxdxsXA;

	private uwbgviXXIJPMnGJRVuzdFTgToYVv TcJeRjoAHWajdfxVaSabfTeqWDcy;

	private OHBxQeqzwpSOXtKiahobKGuCdFjeb ajnOsEopTWvzJZjeDpcpYppqmqOw;

	private int DpfYFosOsNWtCFkziqdksZeTEArD;

	private int jpqBhpZNsMGnDgHSymiPbcaZqtarA;

	private Action<int, ControllerDataUpdater> iflSSWozFbqbNyCUyERBdllZbLtdb;

	private Action<bool, int, int> ixxxqIXfpsCTHDWysaXtHsDeEnWx;

	private Action<ControllerStatusChangedEventArgs> nIwEdmHLGacxnyCQtcXmPGEPDySI;

	private Action<ControllerType, int> ojMXclRRguwDHCQZjTjpOeecWThO;

	private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

	public IList<Joystick> KGdLENWcPYxILUyAVplYwyvHjPaK => FdVqxYUvpACPAZkfhNjUbghfNeQj;

	public List<Joystick> OjXbsTbzocxOnVByDJBlivILTXEC => JuRitPJrgSMAWSUYDTsgpTqpPALm;

	public int NcFhTqaznBUbORimVwWyLExKyNzx => JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;

	public Mouse yBqJFIogVEdRIuiInajAqimbcbNA => mEHvdpDSFOqqnkOaipXQzXsobfvk;

	public Keyboard ZvUlvpaVsbPQTtRuvnrrPLgdkCtF => THRtUdLBqPKCSvKIahLGAdLQOdVMA;

	public IList<CustomController> IhmKpucosHmZRyANPvjCqzSpCkQy => FEVFjUIcuIeoMgNkAmZxVHlgfbecA;

	public List<CustomController> DErWjBsNXqtjTFvhmviSekXoeUBV => kOeUzaAxrTTjHjJsuAnJIMiZdGat;

	public int JYxquPbZseAQLTolMDAfwrOEyJru => kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;

	public IList<Controller> KBXpwdoMXEcoDkYoXNCAgTEltfun => cVTxgVvNmcUHqSmugkCKRmxWANHt;

	public int SsODYsoCnMZmmkJvPwoplcnNlBAv => clJJgGHmUINNlMhgMrVgDvxkJicW.Count;

	private int ENaSvyOwzBqjAkEjMPNOrDsiizGT
	{
		get
		{
			int htTLBFYHFdHLTiyCMjwDiFBxdxsXA = HtTLBFYHFdHLTiyCMjwDiFBxdxsXA;
			HtTLBFYHFdHLTiyCMjwDiFBxdxsXA++;
			if (HtTLBFYHFdHLTiyCMjwDiFBxdxsXA >= int.MaxValue)
			{
				HtTLBFYHFdHLTiyCMjwDiFBxdxsXA = 0;
			}
			return htTLBFYHFdHLTiyCMjwDiFBxdxsXA;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> zwLQnBPuyyNbeEdvWfIoruZHUzzK
	{
		add
		{
			nIwEdmHLGacxnyCQtcXmPGEPDySI = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(nIwEdmHLGacxnyCQtcXmPGEPDySI, b);
		}
		remove
		{
			nIwEdmHLGacxnyCQtcXmPGEPDySI = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(nIwEdmHLGacxnyCQtcXmPGEPDySI, value2);
		}
	}

	public event Action<ControllerType, int> jmRLvdXZkKvdTejFUipRjxOZcXKdA
	{
		add
		{
			ojMXclRRguwDHCQZjTjpOeecWThO = (Action<ControllerType, int>)Delegate.Combine(ojMXclRRguwDHCQZjTjpOeecWThO, b);
		}
		remove
		{
			ojMXclRRguwDHCQZjTjpOeecWThO = (Action<ControllerType, int>)Delegate.Remove(ojMXclRRguwDHCQZjTjpOeecWThO, value2);
		}
	}

	public sQUhNuelsgdElREOuzBUnZbPDjkc(ConfigVars P_0, PlatformInputManager P_1)
	{
		ojFvlpKzaZHmKUfEuuuNjYOwvQoW = P_0;
		eNjegqeOwkgxMDAjDUrMRxpMAPnz = 0;
		jYeZsMeNsIJLGmlRwyPXaqKuUsHK = UnityTools.isAndroidPlatform;
		clJJgGHmUINNlMhgMrVgDvxkJicW = new List<Controller>(10);
		cVTxgVvNmcUHqSmugkCKRmxWANHt = new ReadOnlyCollection<Controller>(clJJgGHmUINNlMhgMrVgDvxkJicW);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (oAyvPljoNGQuBPxukPSgGbJpoolb = new UnityUnifiedKeyboardSource());
		}
		THRtUdLBqPKCSvKIahLGAdLQOdVMA = new Keyboard("Keyboard", unifiedKeyboardSource);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Add(THRtUdLBqPKCSvKIahLGAdLQOdVMA);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (RCrTjdsPXBdeyCAKlBltMOiTkcWvA = new UnityUnifiedMouseSource());
		}
		mEHvdpDSFOqqnkOaipXQzXsobfvk = new Mouse("Mouse", unifiedMouseSource);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Add(mEHvdpDSFOqqnkOaipXQzXsobfvk);
		gzxhDgphqicLqbTlEVWmvHZfIoJW = new BxbbvKXhLYllwMlNukVwsgZhBIs(P_0.updateLoop, THRtUdLBqPKCSvKIahLGAdLQOdVMA);
		THRtUdLBqPKCSvKIahLGAdLQOdVMA.CDUVxEflSzPxxsCRoZnzGfSbmPlC += XDkSyJLmeCtHciFuwLtTWagOBrbz;
		THRtUdLBqPKCSvKIahLGAdLQOdVMA.enabled = !P_0.GetPlatformVar_disableKeyboard();
		mEHvdpDSFOqqnkOaipXQzXsobfvk.enabled = !P_0.GetPlatformVar_disableMouse();
		xiZMFJaKprrLjxtEMQahBCVGvYER.ooNidbhWzBcZZJydutNALDEuSswc();
		poHBjfNcWvllzJNNsERwbrPxRXyc = new ozJCNCgYiYUtKitDXELFzszuhHbtA(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(THRtUdLBqPKCSvKIahLGAdLQOdVMA);
		poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(mEHvdpDSFOqqnkOaipXQzXsobfvk);
		ReInput.ApplicationFocusChangedEvent += ciqEMkdNIetcwAdDEzSvXOVSVQfM;
	}

	public void gUxczTgMdKUcYRnCXamteWaCXJodc(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		iflSSWozFbqbNyCUyERBdllZbLtdb = P_0;
		gUxczTgMdKUcYRnCXamteWaCXJodc(P_1);
	}

	public void sOLNzBCCbZmFXkMugfndpShqgrUP(UpdateLoopType P_0)
	{
		xiZMFJaKprrLjxtEMQahBCVGvYER.qnNBomBkJGYbSCteHxwELVAYlhvy(P_0);
		if (THRtUdLBqPKCSvKIahLGAdLQOdVMA.enabled)
		{
			gzxhDgphqicLqbTlEVWmvHZfIoJW.sOLNzBCCbZmFXkMugfndpShqgrUP(P_0);
		}
		aBNtxHhzULMzbVNOykyDKzDCQgAf(P_0);
		ROYqYhzAjRxfpJdNSopNvNAPFsOs(P_0);
		xiZMFJaKprrLjxtEMQahBCVGvYER.OJwRTvWKOprkrbxNjAvuBwrxssUE(P_0, ReInput.currentFrame);
		if (uqEOuwnDASzRJFFuQguSKkcNKviw)
		{
			ZfZDpSDjmUjdkljSuTJYJHAjjIkkA();
		}
	}

	public HuFUPnVcilGVsLkOQFTNYtvJAVLr ZsaWCDZFDKmAivELYJiSgHxiXbiE(int P_0, string P_1, bool P_2)
	{
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return mfifTKGNAuFdGBOUlQVuHsGEZyWgA[num];
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return null;
		}
		return TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, num];
	}

	public HuFUPnVcilGVsLkOQFTNYtvJAVLr ZsaWCDZFDKmAivELYJiSgHxiXbiE(int P_0, int P_1, bool P_2)
	{
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return mfifTKGNAuFdGBOUlQVuHsGEZyWgA[num];
		}
		return TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, num];
	}

	public void efUlJwIYWClyAVZbCsumYvIMdtYx(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			rpdrpwFfKEBLcwJyfwMQnPKLzVeH rpdrpwFfKEBLcwJyfwMQnPKLzVeH2 = rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected;
			int num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0.sourceJoystick.rewiredId, rpdrpwFfKEBLcwJyfwMQnPKLzVeH2);
			if (num < 0)
			{
				rpdrpwFfKEBLcwJyfwMQnPKLzVeH2 = rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected;
				num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0.sourceJoystick.rewiredId, rpdrpwFfKEBLcwJyfwMQnPKLzVeH2);
			}
			if (num >= 0)
			{
				((rpdrpwFfKEBLcwJyfwMQnPKLzVeH2 == rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected) ? JuRitPJrgSMAWSUYDTsgpTqpPALm[num] : szfbyoEHroNfHCaaumoheusFcIKHc[num]).VbVBYliTbuvVNPetPsBZqFKmHxco(P_0);
			}
		}
	}

	public bool HAKDBHqOhPAjbUrLICVoUOyxWxSu(int P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH P_1)
	{
		if (oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int oFuZjfXOmafeFFnAJGxlabOgzbgFb(int P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH P_1)
	{
		switch (P_1)
		{
		case rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected:
		{
			int count2 = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
			for (int j = 0; j < count2; j++)
			{
				if (JuRitPJrgSMAWSUYDTsgpTqpPALm[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected:
		{
			int count = szfbyoEHroNfHCaaumoheusFcIKHc.Count;
			for (int i = 0; i < count; i++)
			{
				if (szfbyoEHroNfHCaaumoheusFcIKHc[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int oFuZjfXOmafeFFnAJGxlabOgzbgFb(Guid P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH P_1)
	{
		switch (P_1)
		{
		case rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected:
		{
			int count2 = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
			for (int j = 0; j < count2; j++)
			{
				if (JuRitPJrgSMAWSUYDTsgpTqpPALm[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected:
		{
			int count = szfbyoEHroNfHCaaumoheusFcIKHc.Count;
			for (int i = 0; i < count; i++)
			{
				if (szfbyoEHroNfHCaaumoheusFcIKHc[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool RzcwrWVkpiwZGTEdtCHuWLJBxzmq(int P_0)
	{
		if (EpLzgHZiTkaLkJRkBPvRUqRMxeGoA(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int EpLzgHZiTkaLkJRkBPvRUqRMxeGoA(int P_0)
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		for (int i = 0; i < count; i++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int EpLzgHZiTkaLkJRkBPvRUqRMxeGoA(Guid P_0)
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		for (int i = 0; i < count; i++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void oFLCjRHhraPnQvNXLbpUUzAVwaVe(BridgedController P_0)
	{
		YXZIANnIHIaQeGIPKAEBaopirXteb(P_0);
	}

	public void QtieAYcfOQNdZzYnbqKRkQzcwyds(int P_0)
	{
		int num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected);
		NaALcFCVHyHfEZYWEnIDsjKyAVUF(num);
	}

	public int sBwCuaOSnNILoUKqPGJScxAFJcoTA()
	{
		return eNjegqeOwkgxMDAjDUrMRxpMAPnz++;
	}

	public IList<InputBehavior> gqUiUBMjacceXtcqdHhhSMgwWdoB(int P_0)
	{
		if (!oJReXMprxlfvAScuBrsTrAQMuldu.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return oJReXMprxlfvAScuBrsTrAQMuldu[P_0].YyaCCXlhXGxgHjwlMRseRToWDlKg;
	}

	public InputBehavior fWPoynXPcUbbMgtVneKpoHRjctAr(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return fWPoynXPcUbbMgtVneKpoHRjctAr(P_0, inputBehaviorId);
	}

	public InputBehavior fWPoynXPcUbbMgtVneKpoHRjctAr(int P_0, int P_1)
	{
		if (!oJReXMprxlfvAScuBrsTrAQMuldu.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> yyaCCXlhXGxgHjwlMRseRToWDlKg = oJReXMprxlfvAScuBrsTrAQMuldu[P_0].YyaCCXlhXGxgHjwlMRseRToWDlKg;
		for (int i = 0; i < yyaCCXlhXGxgHjwlMRseRToWDlKg.Count; i++)
		{
			if (yyaCCXlhXGxgHjwlMRseRToWDlKg[i].id == P_1)
			{
				return yyaCCXlhXGxgHjwlMRseRToWDlKg[i];
			}
		}
		return null;
	}

	public Joystick tSIrwsOdwOFCroAaXNcrRqLZRblM(int P_0, bool P_1 = false)
	{
		int num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected);
		if (num >= 0)
		{
			return JuRitPJrgSMAWSUYDTsgpTqpPALm[num];
		}
		if (P_1)
		{
			num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected);
			if (num >= 0)
			{
				return szfbyoEHroNfHCaaumoheusFcIKHc[num];
			}
		}
		return null;
	}

	public Joystick tSIrwsOdwOFCroAaXNcrRqLZRblM(Guid P_0, bool P_1 = false)
	{
		int num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected);
		if (num >= 0)
		{
			return JuRitPJrgSMAWSUYDTsgpTqpPALm[num];
		}
		if (P_1)
		{
			num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected);
			if (num >= 0)
			{
				return szfbyoEHroNfHCaaumoheusFcIKHc[num];
			}
		}
		return null;
	}

	public Joystick[] AELkemHHDhODBzkAHuuepOzaSdeL()
	{
		int count = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = JuRitPJrgSMAWSUYDTsgpTqpPALm[i];
		}
		return array;
	}

	public string[] rqcAdHfaleaTEBcVKlyqifJUuZXNb()
	{
		int count = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = JuRitPJrgSMAWSUYDTsgpTqpPALm[i].name;
		}
		return array;
	}

	public CustomController BEujAwJXazSYZkephxsuXudfwVop(int P_0)
	{
		int num = EpLzgHZiTkaLkJRkBPvRUqRMxeGoA(P_0);
		if (num < 0)
		{
			return null;
		}
		return kOeUzaAxrTTjHjJsuAnJIMiZdGat[num];
	}

	public CustomController BEujAwJXazSYZkephxsuXudfwVop(Guid P_0)
	{
		int num = EpLzgHZiTkaLkJRkBPvRUqRMxeGoA(P_0);
		if (num < 0)
		{
			return null;
		}
		return kOeUzaAxrTTjHjJsuAnJIMiZdGat[num];
	}

	public CustomController[] aLFpVuDUVZIvkdsYwHmzjgOWkbIb()
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = kOeUzaAxrTTjHjJsuAnJIMiZdGat[i];
		}
		return array;
	}

	public string[] cMXbmnnuthNpieKxmWhTRyXoFguP()
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = kOeUzaAxrTTjHjJsuAnJIMiZdGat[i].name;
		}
		return array;
	}

	public CustomController eiZBKaQajfzCsvOZQPpHqLgKHDPAA(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int wKTIDzdbnMqFnJlBBeomtbaWsxjR = ENaSvyOwzBqjAkEjMPNOrDsiizGT;
		CustomController customController = new CustomController(new YCtNtFhGhsVodFBjxRMexOEjLQUl
		{
			yGdZHAmdUeDYveLTSINOCvUHtMoHA = InputSource.Custom,
			kXiencEahrSUtKlFEOwKvjtarZHH = customControllerById.descriptiveName,
			MKithPtgMWeNFboVvECkRPLhlfYjA = customControllerById.name,
			jhazYdoXweuxJmcAJnlflvXbFGyT = customControllerById.axisCount,
			yrHZhNoSpLMEzcgptuOphbaHHcuiA = customControllerById.buttonCount,
			wKTIDzdbnMqFnJlBBeomtbaWsxjR = wKTIDzdbnMqFnJlBBeomtbaWsxjR,
			HfMOkyPcPsuKGzdAsQPYtfVrhuyu = customControllerById.id,
			PgQDAaNkfzUtivkZBGNaxIzBnTBN = customControllerById.typeGuid,
			VvJgYeDfloTcrtoNAqSVgDQAMrjjb = customControllerById.id.ToString(),
			dCYtOPOydCabMdmRsHTqLvuIwxCG = customControllerById.CreateGameHardwareMap()
		});
		hhPdXeFwCFVkagwuxTRKvKHhjTMTA(customController);
		return customController;
	}

	public bool wFmmPwwEMdAsytXgWcRKBgWWGQhZA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return jSFqOYETANyBAUjypvvlDmVpEDmD(P_0);
	}

	public CustomController xVcdagcrTbKFoeXoYNuAfPalcuvC(int P_0)
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		for (int i = 0; i < count; i++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[i].sourceControllerId == P_0)
			{
				return kOeUzaAxrTTjHjJsuAnJIMiZdGat[i];
			}
		}
		return null;
	}

	public CustomController wxaqxAPsErzJAPFwbsMTBftidDjF(string P_0)
	{
		int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		for (int i = 0; i < count; i++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return kOeUzaAxrTTjHjJsuAnJIMiZdGat[i];
			}
		}
		return null;
	}

	public IEnumerable<CustomController> fpoxnQyFJYoWOgCaKHjMaYXOkqKsA(int P_0)
	{
		return new mQfRXDfvFkYVFzBLjEUabbkYrpsI(-2)
		{
			GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
			kMoGHUsPIEoIkxegTzmGNvqvyGWA = P_0
		};
	}

	public IEnumerable<CustomController> HAXWgOXwIgGpdKfGjhagSIPpCRqhA(string P_0)
	{
		return new iAtPvQfUsFXtxbhbDezyOYOuhOFe(-2)
		{
			GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
			SdneKSDMLwNqVBTPrwJYGNkjUDeS = P_0
		};
	}

	public Controller BXBKHrCmMwnClRajoDNsKgTWBgIcb(ControllerType P_0, int P_1, bool P_2 = false)
	{
		return P_0 switch
		{
			ControllerType.Joystick => tSIrwsOdwOFCroAaXNcrRqLZRblM(P_1, P_2), 
			ControllerType.Keyboard => THRtUdLBqPKCSvKIahLGAdLQOdVMA, 
			ControllerType.Mouse => mEHvdpDSFOqqnkOaipXQzXsobfvk, 
			ControllerType.Custom => BEujAwJXazSYZkephxsuXudfwVop(P_1), 
			_ => throw new NotImplementedException(), 
		};
	}

	public Controller BXBKHrCmMwnClRajoDNsKgTWBgIcb(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller BXBKHrCmMwnClRajoDNsKgTWBgIcb(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (THRtUdLBqPKCSvKIahLGAdLQOdVMA.deviceInstanceGuid == P_0)
		{
			return THRtUdLBqPKCSvKIahLGAdLQOdVMA;
		}
		if (mEHvdpDSFOqqnkOaipXQzXsobfvk.deviceInstanceGuid == P_0)
		{
			return mEHvdpDSFOqqnkOaipXQzXsobfvk;
		}
		Controller result;
		if ((result = tSIrwsOdwOFCroAaXNcrRqLZRblM(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = BEujAwJXazSYZkephxsuXudfwVop(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] cahWufwatdGsrbommnEHIowDgadTA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => AELkemHHDhODBzkAHuuepOzaSdeL(), 
			ControllerType.Keyboard => new Controller[1] { THRtUdLBqPKCSvKIahLGAdLQOdVMA }, 
			ControllerType.Mouse => new Controller[1] { mEHvdpDSFOqqnkOaipXQzXsobfvk }, 
			ControllerType.Custom => aLFpVuDUVZIvkdsYwHmzjgOWkbIb(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public string[] ZkTdNKSDYqOKcKLewenibQFfmOMB(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => rqcAdHfaleaTEBcVKlyqifJUuZXNb(), 
			ControllerType.Keyboard => new string[1] { THRtUdLBqPKCSvKIahLGAdLQOdVMA.name }, 
			ControllerType.Mouse => new string[1] { mEHvdpDSFOqqnkOaipXQzXsobfvk.name }, 
			ControllerType.Custom => cMXbmnnuthNpieKxmWhTRyXoFguP(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.ObmRPnBAXLGPNSMVFccJbPKCnMoh(P_1, P_2, InputActionEventType.Update, null);
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.ObmRPnBAXLGPNSMVFccJbPKCnMoh(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_3);
		if (num >= 0)
		{
			abWrLiCkIBdlWPdchohOrGKFiXObA(P_0, P_1, P_2, num);
		}
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.ObmRPnBAXLGPNSMVFccJbPKCnMoh(P_1, P_2, P_3, P_4);
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.ObmRPnBAXLGPNSMVFccJbPKCnMoh(P_1, P_2, P_3, P_4, P_5);
	}

	public void abWrLiCkIBdlWPdchohOrGKFiXObA(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			enWIRBzErsHtNhmMquKMBRbbrnXg = true;
		}
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_4);
		if (num >= 0)
		{
			abWrLiCkIBdlWPdchohOrGKFiXObA(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_2);
		if (num >= 0)
		{
			zxdATkhGiNhihCcZghZLxiRuTsiE(P_0, P_1, num);
		}
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2, P_3);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_3);
		if (num >= 0)
		{
			zxdATkhGiNhihCcZghZLxiRuTsiE(P_0, P_1, P_2, num);
		}
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2, P_3);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_3);
		if (num >= 0)
		{
			zxdATkhGiNhihCcZghZLxiRuTsiE(P_0, P_1, P_2, num);
		}
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2, P_3);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.hZGQqfkCleotngNoRVwWiwgaxpqJ(P_1, P_2, P_3, P_4);
	}

	public void zxdATkhGiNhihCcZghZLxiRuTsiE(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy.sZUzvhZEuuICVAuNpLMKkhgSakLkA(P_4);
		if (num >= 0)
		{
			zxdATkhGiNhihCcZghZLxiRuTsiE(P_0, P_1, P_2, P_3, num);
		}
	}

	public void yqqymcbAhhEzQBAmGSXCHsLkByobA(int P_0)
	{
		GQrTYdDgKuiEyUtEkWxkpaDatYnH(P_0)?.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
	}

	public bool ZlvhHCrmeggpCOfNIDXCQCunDzyG(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].PKxzXBSMXndnnwoVrPblHLVDZExv())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].PKxzXBSMXndnnwoVrPblHLVDZExv())
			{
				return true;
			}
		}
		return false;
	}

	public bool JvCQEBnihGgWAAjTHDJxmlzweJXl(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].WBIaBbghQpgzOEKyaCjXLOtiaWQP())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].WBIaBbghQpgzOEKyaCjXLOtiaWQP())
			{
				return true;
			}
		}
		return false;
	}

	public bool UPJyzJfSImIVFrUAgnlUdKEeyYFs(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].mjQmQdEkqdYvFzOGOLRYyQYeGhCg())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].mjQmQdEkqdYvFzOGOLRYyQYeGhCg())
			{
				return true;
			}
		}
		return false;
	}

	public bool ZoallhXCnkkFstxNDrZMEEPwpCHQ(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].BYuNmqXmcJEOqFjaSxNMkOUwwGWl())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].BYuNmqXmcJEOqFjaSxNMkOUwwGWl())
			{
				return true;
			}
		}
		return false;
	}

	public bool nXelWkdvbdInWlBJkKFtBSczQyqT(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].ilFAZwkIaxHKmyAvsBXuJQNIEkYs())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].ilFAZwkIaxHKmyAvsBXuJQNIEkYs())
			{
				return true;
			}
		}
		return false;
	}

	public bool zCvrNMlAaaEKYlmCVGMtYuQLoYCf(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].unhchykaxdiheOqgVQewBhsRIfZDA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].unhchykaxdiheOqgVQewBhsRIfZDA())
			{
				return true;
			}
		}
		return false;
	}

	public bool IesbutQVEpGxUrbMpdmhdfrpdEAs(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].fFYMTDlJiVbySbkKFktNzGIHtFWr())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].fFYMTDlJiVbySbkKFktNzGIHtFWr())
			{
				return true;
			}
		}
		return false;
	}

	public bool IDeHUsbeAVYZrkJqVAIcAymjnCGpA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < mfifTKGNAuFdGBOUlQVuHsGEZyWgA.Length; i++)
			{
				if (mfifTKGNAuFdGBOUlQVuHsGEZyWgA[i].vZjFXFEfAwXLmGsqgVakMDqwjAqm())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return false;
		}
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		for (int j = 0; j < num; j++)
		{
			if (TylDOBzcRcffJdHuSQWBLMxONAHS[P_0, j].vZjFXFEfAwXLmGsqgVakMDqwjAqm())
			{
				return true;
			}
		}
		return false;
	}

	public bool OHxXMywYjiPsrXEHFZZfKniKkHzH()
	{
		if (!OHxXMywYjiPsrXEHFZZfKniKkHzH(mEHvdpDSFOqqnkOaipXQzXsobfvk) && !OHxXMywYjiPsrXEHFZZfKniKkHzH(JuRitPJrgSMAWSUYDTsgpTqpPALm) && !OHxXMywYjiPsrXEHFZZfKniKkHzH(THRtUdLBqPKCSvKIahLGAdLQOdVMA))
		{
			return OHxXMywYjiPsrXEHFZZfKniKkHzH(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		}
		return true;
	}

	public bool OHxXMywYjiPsrXEHFZZfKniKkHzH(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => OHxXMywYjiPsrXEHFZZfKniKkHzH(JuRitPJrgSMAWSUYDTsgpTqpPALm), 
			ControllerType.Keyboard => OHxXMywYjiPsrXEHFZZfKniKkHzH(THRtUdLBqPKCSvKIahLGAdLQOdVMA), 
			ControllerType.Mouse => OHxXMywYjiPsrXEHFZZfKniKkHzH(mEHvdpDSFOqqnkOaipXQzXsobfvk), 
			ControllerType.Custom => OHxXMywYjiPsrXEHFZZfKniKkHzH(kOeUzaAxrTTjHjJsuAnJIMiZdGat), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool EaaAxLYuELeKAEpndFRxgUgxjgWDA()
	{
		if (!EaaAxLYuELeKAEpndFRxgUgxjgWDA(mEHvdpDSFOqqnkOaipXQzXsobfvk) && !EaaAxLYuELeKAEpndFRxgUgxjgWDA(JuRitPJrgSMAWSUYDTsgpTqpPALm) && !EaaAxLYuELeKAEpndFRxgUgxjgWDA(THRtUdLBqPKCSvKIahLGAdLQOdVMA))
		{
			return EaaAxLYuELeKAEpndFRxgUgxjgWDA(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		}
		return true;
	}

	public bool EaaAxLYuELeKAEpndFRxgUgxjgWDA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => EaaAxLYuELeKAEpndFRxgUgxjgWDA(JuRitPJrgSMAWSUYDTsgpTqpPALm), 
			ControllerType.Keyboard => EaaAxLYuELeKAEpndFRxgUgxjgWDA(THRtUdLBqPKCSvKIahLGAdLQOdVMA), 
			ControllerType.Mouse => EaaAxLYuELeKAEpndFRxgUgxjgWDA(mEHvdpDSFOqqnkOaipXQzXsobfvk), 
			ControllerType.Custom => EaaAxLYuELeKAEpndFRxgUgxjgWDA(kOeUzaAxrTTjHjJsuAnJIMiZdGat), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool yxDQHFstwJzFcOmHtPGbDLOSsGnc()
	{
		if (!yxDQHFstwJzFcOmHtPGbDLOSsGnc(mEHvdpDSFOqqnkOaipXQzXsobfvk) && !yxDQHFstwJzFcOmHtPGbDLOSsGnc(JuRitPJrgSMAWSUYDTsgpTqpPALm) && !yxDQHFstwJzFcOmHtPGbDLOSsGnc(THRtUdLBqPKCSvKIahLGAdLQOdVMA))
		{
			return yxDQHFstwJzFcOmHtPGbDLOSsGnc(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		}
		return true;
	}

	public bool yxDQHFstwJzFcOmHtPGbDLOSsGnc(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => yxDQHFstwJzFcOmHtPGbDLOSsGnc(JuRitPJrgSMAWSUYDTsgpTqpPALm), 
			ControllerType.Keyboard => yxDQHFstwJzFcOmHtPGbDLOSsGnc(THRtUdLBqPKCSvKIahLGAdLQOdVMA), 
			ControllerType.Mouse => yxDQHFstwJzFcOmHtPGbDLOSsGnc(mEHvdpDSFOqqnkOaipXQzXsobfvk), 
			ControllerType.Custom => yxDQHFstwJzFcOmHtPGbDLOSsGnc(kOeUzaAxrTTjHjJsuAnJIMiZdGat), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool xWtAwKhdrPUdHqlYhiXtqZRKBVQfb()
	{
		if (!xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(mEHvdpDSFOqqnkOaipXQzXsobfvk) && !xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(JuRitPJrgSMAWSUYDTsgpTqpPALm) && !xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(THRtUdLBqPKCSvKIahLGAdLQOdVMA))
		{
			return xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		}
		return true;
	}

	public bool xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(JuRitPJrgSMAWSUYDTsgpTqpPALm), 
			ControllerType.Keyboard => xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(THRtUdLBqPKCSvKIahLGAdLQOdVMA), 
			ControllerType.Mouse => xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(mEHvdpDSFOqqnkOaipXQzXsobfvk), 
			ControllerType.Custom => xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(kOeUzaAxrTTjHjJsuAnJIMiZdGat), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool uBbBZShepcHgpAYJmkFQzBdJCSDFA()
	{
		if (!uBbBZShepcHgpAYJmkFQzBdJCSDFA(mEHvdpDSFOqqnkOaipXQzXsobfvk) && !uBbBZShepcHgpAYJmkFQzBdJCSDFA(JuRitPJrgSMAWSUYDTsgpTqpPALm) && !uBbBZShepcHgpAYJmkFQzBdJCSDFA(THRtUdLBqPKCSvKIahLGAdLQOdVMA))
		{
			return uBbBZShepcHgpAYJmkFQzBdJCSDFA(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		}
		return true;
	}

	public bool uBbBZShepcHgpAYJmkFQzBdJCSDFA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Joystick => uBbBZShepcHgpAYJmkFQzBdJCSDFA(JuRitPJrgSMAWSUYDTsgpTqpPALm), 
			ControllerType.Keyboard => uBbBZShepcHgpAYJmkFQzBdJCSDFA(THRtUdLBqPKCSvKIahLGAdLQOdVMA), 
			ControllerType.Mouse => uBbBZShepcHgpAYJmkFQzBdJCSDFA(mEHvdpDSFOqqnkOaipXQzXsobfvk), 
			ControllerType.Custom => uBbBZShepcHgpAYJmkFQzBdJCSDFA(kOeUzaAxrTTjHjJsuAnJIMiZdGat), 
			_ => throw new NotImplementedException(), 
		};
	}

	private bool OHxXMywYjiPsrXEHFZZfKniKkHzH<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool OHxXMywYjiPsrXEHFZZfKniKkHzH(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool EaaAxLYuELeKAEpndFRxgUgxjgWDA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool EaaAxLYuELeKAEpndFRxgUgxjgWDA(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool yxDQHFstwJzFcOmHtPGbDLOSsGnc<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool yxDQHFstwJzFcOmHtPGbDLOSsGnc(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool xWtAwKhdrPUdHqlYhiXtqZRKBVQfb<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool xWtAwKhdrPUdHqlYhiXtqZRKBVQfb(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool uBbBZShepcHgpAYJmkFQzBdJCSDFA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool uBbBZShepcHgpAYJmkFQzBdJCSDFA(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller iXJHiSNtBnggULeIzHDLqRklUTBQ()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(mEHvdpDSFOqqnkOaipXQzXsobfvk, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(THRtUdLBqPKCSvKIahLGAdLQOdVMA, ref lastController, ref lastTime);
		IList<Joystick> juRitPJrgSMAWSUYDTsgpTqpPALm = JuRitPJrgSMAWSUYDTsgpTqpPALm;
		for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
		{
			InputTools.CompareLastActiveController(juRitPJrgSMAWSUYDTsgpTqpPALm[i], ref lastController, ref lastTime);
		}
		IList<CustomController> list = kOeUzaAxrTTjHjJsuAnJIMiZdGat;
		for (int j = 0; j < JYxquPbZseAQLTolMDAfwrOEyJru; j++)
		{
			InputTools.CompareLastActiveController(list[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = THRtUdLBqPKCSvKIahLGAdLQOdVMA;
		}
		return lastController;
	}

	public Controller iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(JuRitPJrgSMAWSUYDTsgpTqpPALm[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return ZvUlvpaVsbPQTtRuvnrrPLgdkCtF;
		case ControllerType.Mouse:
			return yBqJFIogVEdRIuiInajAqimbcbNA;
		case ControllerType.Custom:
		{
			int count = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(kOeUzaAxrTTjHjJsuAnJIMiZdGat[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 iXJHiSNtBnggULeIzHDLqRklUTBQ<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType sSocBrilXfIwcRtFxdAshYhHdFljA()
	{
		return iXJHiSNtBnggULeIzHDLqRklUTBQ()?.type ?? ControllerType.Keyboard;
	}

	public void seOLgneYbXEgZXaAbbHCDgUxbVJlA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			uqEOuwnDASzRJFFuQguSKkcNKviw = true;
			svsnQpLpxAHWjGNkPJopXmwFbMOS.gGagFzjGTHYALmdkMAqLzVKngtbcA(P_0);
		}
	}

	public void seOLgneYbXEgZXaAbbHCDgUxbVJlA(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			uqEOuwnDASzRJFFuQguSKkcNKviw = true;
			svsnQpLpxAHWjGNkPJopXmwFbMOS.gGagFzjGTHYALmdkMAqLzVKngtbcA(P_0, P_1);
		}
	}

	public void wZhqKwEuhTOxaksFvBZVcwiARRaN(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			svsnQpLpxAHWjGNkPJopXmwFbMOS.ZgiikPfCshnpypIHBhWHWVHzEYKt(P_0);
		}
	}

	public void BmVzFduGJLnSxYGeafLsmXpbIsudA(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			svsnQpLpxAHWjGNkPJopXmwFbMOS.ZgiikPfCshnpypIHBhWHWVHzEYKt(P_0, P_1);
		}
	}

	public void RfrIJnQlYqBtRxmhlHtbKUtvakBoA()
	{
		svsnQpLpxAHWjGNkPJopXmwFbMOS.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
	}

	public void seOLgneYbXEgZXaAbbHCDgUxbVJlA(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			sEJtBycGSEfYZIpDDuXqvYeeFEan.gGagFzjGTHYALmdkMAqLzVKngtbcA(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)DpfYFosOsNWtCFkziqdksZeTEArD)
			{
				return;
			}
			oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[P_0].gGagFzjGTHYALmdkMAqLzVKngtbcA(P_1);
		}
		uqEOuwnDASzRJFFuQguSKkcNKviw = true;
	}

	public void seOLgneYbXEgZXaAbbHCDgUxbVJlA(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			sEJtBycGSEfYZIpDDuXqvYeeFEan.gGagFzjGTHYALmdkMAqLzVKngtbcA(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)DpfYFosOsNWtCFkziqdksZeTEArD)
			{
				return;
			}
			oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[P_0].gGagFzjGTHYALmdkMAqLzVKngtbcA(P_1, P_2);
		}
		uqEOuwnDASzRJFFuQguSKkcNKviw = true;
	}

	public void wZhqKwEuhTOxaksFvBZVcwiARRaN(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				sEJtBycGSEfYZIpDDuXqvYeeFEan.ZgiikPfCshnpypIHBhWHWVHzEYKt(P_1);
			}
			else if ((uint)P_0 < (uint)DpfYFosOsNWtCFkziqdksZeTEArD)
			{
				oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[P_0].ZgiikPfCshnpypIHBhWHWVHzEYKt(P_1);
			}
		}
	}

	public void wZhqKwEuhTOxaksFvBZVcwiARRaN(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				sEJtBycGSEfYZIpDDuXqvYeeFEan.ZgiikPfCshnpypIHBhWHWVHzEYKt(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)DpfYFosOsNWtCFkziqdksZeTEArD)
			{
				oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[P_0].ZgiikPfCshnpypIHBhWHWVHzEYKt(P_1, P_2);
			}
		}
	}

	public void RfrIJnQlYqBtRxmhlHtbKUtvakBoA(int P_0)
	{
		if (P_0 == 9999999)
		{
			sEJtBycGSEfYZIpDDuXqvYeeFEan.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
		}
		else if ((uint)P_0 < (uint)DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[P_0].HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
		}
	}

	private void ZfZDpSDjmUjdkljSuTJYJHAjjIkkA()
	{
		if (svsnQpLpxAHWjGNkPJopXmwFbMOS.ggOELQfbMWVpRqqfkgHGATWfAHCZA > 0)
		{
			svsnQpLpxAHWjGNkPJopXmwFbMOS.pwvRIiZFyXcgvjXLwkzpOgUWBiEL(-1, iXJHiSNtBnggULeIzHDLqRklUTBQ(), iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Joystick), iXJHiSNtBnggULeIzHDLqRklUTBQ(ControllerType.Custom));
		}
		if (sEJtBycGSEfYZIpDDuXqvYeeFEan.ggOELQfbMWVpRqqfkgHGATWfAHCZA > 0)
		{
			Player.ControllerHelper controllers = ajnOsEopTWvzJZjeDpcpYppqmqOw.iLesuLOztWcIVeAaALdlvBgOQKgx().controllers;
			sEJtBycGSEfYZIpDDuXqvYeeFEan.pwvRIiZFyXcgvjXLwkzpOgUWBiEL(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < DpfYFosOsNWtCFkziqdksZeTEArD; i++)
		{
			if (oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[i].ggOELQfbMWVpRqqfkgHGATWfAHCZA != 0)
			{
				Player.ControllerHelper controllers2 = ajnOsEopTWvzJZjeDpcpYppqmqOw.WtobyiAcccrasNfUwVICLZaJveRb[i].controllers;
				oKzdgYKwAFDfpJBCZeBFNiPhfSeJ[i].pwvRIiZFyXcgvjXLwkzpOgUWBiEL(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void wQZGevvrMLHzUDzCAUZWIvSLcdmg(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < JuRitPJrgSMAWSUYDTsgpTqpPALm.Count; i++)
		{
			if (JuRitPJrgSMAWSUYDTsgpTqpPALm[i] != null)
			{
				wQZGevvrMLHzUDzCAUZWIvSLcdmg(JuRitPJrgSMAWSUYDTsgpTqpPALm[i], P_0);
			}
		}
		for (int j = 0; j < szfbyoEHroNfHCaaumoheusFcIKHc.Count; j++)
		{
			if (szfbyoEHroNfHCaaumoheusFcIKHc[j] != null)
			{
				wQZGevvrMLHzUDzCAUZWIvSLcdmg(szfbyoEHroNfHCaaumoheusFcIKHc[j], P_0);
			}
		}
		for (int k = 0; k < JYxquPbZseAQLTolMDAfwrOEyJru; k++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[k] != null)
			{
				wQZGevvrMLHzUDzCAUZWIvSLcdmg(kOeUzaAxrTTjHjJsuAnJIMiZdGat[k], P_0);
			}
		}
		wQZGevvrMLHzUDzCAUZWIvSLcdmg(mEHvdpDSFOqqnkOaipXQzXsobfvk, P_0);
	}

	private void wQZGevvrMLHzUDzCAUZWIvSLcdmg(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].LCaxfXkPMXiCslbaIiVAoElQhhmD._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> vHLSMnLTrxrfTqolEUmkUaFZkjGm<_0001>() where _0001 : IControllerTemplate
	{
		return poHBjfNcWvllzJNNsERwbrPxRXyc.tWtWyiwhraIpSCZoPgyYnIEdINde<_0001>();
	}

	private void gUxczTgMdKUcYRnCXamteWaCXJodc(List<InputBehavior> P_0)
	{
		TcJeRjoAHWajdfxVaSabfTeqWDcy = ReInput.TcJeRjoAHWajdfxVaSabfTeqWDcy;
		ajnOsEopTWvzJZjeDpcpYppqmqOw = ReInput.ajnOsEopTWvzJZjeDpcpYppqmqOw;
		JuRitPJrgSMAWSUYDTsgpTqpPALm = new List<Joystick>();
		szfbyoEHroNfHCaaumoheusFcIKHc = new List<Joystick>();
		kOeUzaAxrTTjHjJsuAnJIMiZdGat = new List<CustomController>();
		jpqBhpZNsMGnDgHSymiPbcaZqtarA = TcJeRjoAHWajdfxVaSabfTeqWDcy.jpqBhpZNsMGnDgHSymiPbcaZqtarA;
		DpfYFosOsNWtCFkziqdksZeTEArD = ajnOsEopTWvzJZjeDpcpYppqmqOw.DpfYFosOsNWtCFkziqdksZeTEArD;
		ixxxqIXfpsCTHDWysaXtHsDeEnWx = pcMQVdVJlWbpWjxrGLoJXesimCaN;
		HtTLBFYHFdHLTiyCMjwDiFBxdxsXA = 0;
		oJReXMprxlfvAScuBrsTrAQMuldu = new ADictionary<int, khlqfKxpusVMmYgTkYziUilpcTgr>();
		oJReXMprxlfvAScuBrsTrAQMuldu.Add(ReInput.players.GetSystemPlayer().id, new khlqfKxpusVMmYgTkYziUilpcTgr(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			oJReXMprxlfvAScuBrsTrAQMuldu.Add(players[i].id, new khlqfKxpusVMmYgTkYziUilpcTgr(P_0));
		}
		FdVqxYUvpACPAZkfhNjUbghfNeQj = new ReadOnlyCollection<Joystick>(JuRitPJrgSMAWSUYDTsgpTqpPALm);
		FEVFjUIcuIeoMgNkAmZxVHlgfbecA = new ReadOnlyCollection<CustomController>(kOeUzaAxrTTjHjJsuAnJIMiZdGat);
		HuFUPnVcilGVsLkOQFTNYtvJAVLr.RPOrQjzkAVfktAEEuWvFrMjkzMadA(ojFvlpKzaZHmKUfEuuuNjYOwvQoW);
		hivTeFgZnTjTSeliLxeDstBRQIcU = new HuFUPnVcilGVsLkOQFTNYtvJAVLr[(DpfYFosOsNWtCFkziqdksZeTEArD + 1) * jpqBhpZNsMGnDgHSymiPbcaZqtarA];
		int num = 0;
		mfifTKGNAuFdGBOUlQVuHsGEZyWgA = new HuFUPnVcilGVsLkOQFTNYtvJAVLr[jpqBhpZNsMGnDgHSymiPbcaZqtarA];
		for (int j = 0; j < jpqBhpZNsMGnDgHSymiPbcaZqtarA; j++)
		{
			InputAction inputAction = TcJeRjoAHWajdfxVaSabfTeqWDcy.hCeyAnYhpPoqgslzJPuFiLfEVrjy(j);
			InputBehavior inputBehavior = oJReXMprxlfvAScuBrsTrAQMuldu[9999999].yTSFypaaqDQanuQXbqQkSUotvsej(inputAction.behaviorId);
			HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = new HuFUPnVcilGVsLkOQFTNYtvJAVLr(9999999, inputAction, inputBehavior, ojFvlpKzaZHmKUfEuuuNjYOwvQoW);
			mfifTKGNAuFdGBOUlQVuHsGEZyWgA[j] = huFUPnVcilGVsLkOQFTNYtvJAVLr;
			hivTeFgZnTjTSeliLxeDstBRQIcU[num] = huFUPnVcilGVsLkOQFTNYtvJAVLr;
			num++;
		}
		TylDOBzcRcffJdHuSQWBLMxONAHS = new HuFUPnVcilGVsLkOQFTNYtvJAVLr[DpfYFosOsNWtCFkziqdksZeTEArD, jpqBhpZNsMGnDgHSymiPbcaZqtarA];
		for (int k = 0; k < DpfYFosOsNWtCFkziqdksZeTEArD; k++)
		{
			for (int l = 0; l < jpqBhpZNsMGnDgHSymiPbcaZqtarA; l++)
			{
				InputAction inputAction2 = TcJeRjoAHWajdfxVaSabfTeqWDcy.hCeyAnYhpPoqgslzJPuFiLfEVrjy(l);
				InputBehavior inputBehavior2 = oJReXMprxlfvAScuBrsTrAQMuldu[players[k].id].yTSFypaaqDQanuQXbqQkSUotvsej(inputAction2.behaviorId);
				HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr2 = new HuFUPnVcilGVsLkOQFTNYtvJAVLr(k, inputAction2, inputBehavior2, ojFvlpKzaZHmKUfEuuuNjYOwvQoW);
				TylDOBzcRcffJdHuSQWBLMxONAHS[k, l] = huFUPnVcilGVsLkOQFTNYtvJAVLr2;
				hivTeFgZnTjTSeliLxeDstBRQIcU[num] = huFUPnVcilGVsLkOQFTNYtvJAVLr2;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.JKsoUwCAgkKhpVANcbhaqhyjGJigA;
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
				CustomController customController = eiZBKaQajfzCsvOZQPpHqLgKHDPAA(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					ajnOsEopTWvzJZjeDpcpYppqmqOw.hwddIeJafOlGvnIklCDUFMkJMsvyB(num2)?.controllers.hhPdXeFwCFVkagwuxTRKvKHhjTMTA(customController, false);
				}
			}
		}
		JkdIojqDoZbOFVpmZOJdkjXreNri = new lnDNmgCdAUoldOfPbHChIcFoEfFjb();
		ABdiqcjGPOFjXCoPhncNYaRTxwiac = new lnDNmgCdAUoldOfPbHChIcFoEfFjb[DpfYFosOsNWtCFkziqdksZeTEArD];
		for (int num3 = 0; num3 < DpfYFosOsNWtCFkziqdksZeTEArD; num3++)
		{
			ABdiqcjGPOFjXCoPhncNYaRTxwiac[num3] = new lnDNmgCdAUoldOfPbHChIcFoEfFjb();
		}
		svsnQpLpxAHWjGNkPJopXmwFbMOS = new ZdahRlzMRHmytynTlBGzlbkkdrOo<ActiveControllerChangedDelegate>();
		sEJtBycGSEfYZIpDDuXqvYeeFEan = new ZdahRlzMRHmytynTlBGzlbkkdrOo<PlayerActiveControllerChangedDelegate>();
		oKzdgYKwAFDfpJBCZeBFNiPhfSeJ = new ZdahRlzMRHmytynTlBGzlbkkdrOo<PlayerActiveControllerChangedDelegate>[ajnOsEopTWvzJZjeDpcpYppqmqOw.DpfYFosOsNWtCFkziqdksZeTEArD];
		ArrayTools.Populate(oKzdgYKwAFDfpJBCZeBFNiPhfSeJ);
	}

	private void aBNtxHhzULMzbVNOykyDKzDCQgAf(UpdateLoopType P_0)
	{
		int count = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = JuRitPJrgSMAWSUYDTsgpTqpPALm[i];
			if (joystick.enabled)
			{
				iflSSWozFbqbNyCUyERBdllZbLtdb(joystick.qaWdomDkXYbyYcgkBEEJSjidPqMv, joystick.WlduKdCdymfJzhLxPcswpRugJOzgb);
				joystick.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			}
		}
		if (THRtUdLBqPKCSvKIahLGAdLQOdVMA.enabled)
		{
			THRtUdLBqPKCSvKIahLGAdLQOdVMA.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
		}
		else if (jYeZsMeNsIJLGmlRwyPXaqKuUsHK)
		{
			THRtUdLBqPKCSvKIahLGAdLQOdVMA.AtZsPRMlIyAwbhaBjgudEKPCjOTUA(P_0);
		}
		if (mEHvdpDSFOqqnkOaipXQzXsobfvk.enabled)
		{
			mEHvdpDSFOqqnkOaipXQzXsobfvk.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
		}
		int count2 = kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = kOeUzaAxrTTjHjJsuAnJIMiZdGat[j];
			if (customController.enabled)
			{
				customController.mQcCmiCxDWPcaRVyoGUaKDWMEZPOA();
				customController.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			}
		}
	}

	private void ROYqYhzAjRxfpJdNSopNvNAPFsOs(UpdateLoopType P_0)
	{
		HuFUPnVcilGVsLkOQFTNYtvJAVLr.WMxbDhBmyxWffpDfSiaRbaGHEFjTB(P_0);
		Player[] array = ajnOsEopTWvzJZjeDpcpYppqmqOw.EGPTipDFMnhdxCrFBVHXCjgFzgpaA;
		int num = array.Length;
		bool enabled = THRtUdLBqPKCSvKIahLGAdLQOdVMA.enabled;
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
						gzxhDgphqicLqbTlEVWmvHZfIoJW.UtJbzcEZwAYqcEGTRrozuIHvHYCEb(maps[j]);
					}
				}
			}
		}
		bool enabled2 = mEHvdpDSFOqqnkOaipXQzXsobfvk.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.PlFBNAjCNTWRECIVqiIHVkQyHLgYA(ixxxqIXfpsCTHDWysaXtHsDeEnWx);
			if (enabled || jYeZsMeNsIJLGmlRwyPXaqKuUsHK)
			{
				controllers.udeqtaQvveMctPjzIohkHolDJZEK(THRtUdLBqPKCSvKIahLGAdLQOdVMA, gzxhDgphqicLqbTlEVWmvHZfIoJW, ixxxqIXfpsCTHDWysaXtHsDeEnWx);
			}
			if (enabled2)
			{
				controllers.nUIrOpOZVYPmPcGzbrdcEqVHBGQgA(mEHvdpDSFOqqnkOaipXQzXsobfvk, ixxxqIXfpsCTHDWysaXtHsDeEnWx);
			}
			controllers.ZjOEKgUNGspsGGDiCATLelCyJLFdb(ixxxqIXfpsCTHDWysaXtHsDeEnWx);
		}
		for (int l = 0; l < hivTeFgZnTjTSeliLxeDstBRQIcU.Length; l++)
		{
			if (hivTeFgZnTjTSeliLxeDstBRQIcU[l].rPyjYnHNywhBrBsGdWEhpqiRTLBQ != HuFUPnVcilGVsLkOQFTNYtvJAVLr.mwXfHFowKvsuWMliBccedlNelJgzA.Disabled)
			{
				hivTeFgZnTjTSeliLxeDstBRQIcU[l].JGgRUOzgzgvOedILLCUxSsgHMdEs();
			}
		}
		HuFUPnVcilGVsLkOQFTNYtvJAVLr.LmObtodEOavBDnZaywHGCUGZNuTI();
		if (!enWIRBzErsHtNhmMquKMBRbbrnXg)
		{
			return;
		}
		if (JkdIojqDoZbOFVpmZOJdkjXreNri.SvUchSiwLtntKjNRdqNBkvIjahni > 0)
		{
			for (int m = 0; m < jpqBhpZNsMGnDgHSymiPbcaZqtarA; m++)
			{
				HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr = mfifTKGNAuFdGBOUlQVuHsGEZyWgA[m];
				if (huFUPnVcilGVsLkOQFTNYtvJAVLr.rPyjYnHNywhBrBsGdWEhpqiRTLBQ != HuFUPnVcilGVsLkOQFTNYtvJAVLr.mwXfHFowKvsuWMliBccedlNelJgzA.Disabled)
				{
					JkdIojqDoZbOFVpmZOJdkjXreNri.lzQtftFgrdhWxlSTZNBDDLGbQNu(huFUPnVcilGVsLkOQFTNYtvJAVLr, P_0);
				}
			}
		}
		for (int n = 0; n < DpfYFosOsNWtCFkziqdksZeTEArD; n++)
		{
			lnDNmgCdAUoldOfPbHChIcFoEfFjb lnDNmgCdAUoldOfPbHChIcFoEfFjb2 = ABdiqcjGPOFjXCoPhncNYaRTxwiac[n];
			if (lnDNmgCdAUoldOfPbHChIcFoEfFjb2.SvUchSiwLtntKjNRdqNBkvIjahni == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < jpqBhpZNsMGnDgHSymiPbcaZqtarA; num2++)
			{
				HuFUPnVcilGVsLkOQFTNYtvJAVLr huFUPnVcilGVsLkOQFTNYtvJAVLr2 = TylDOBzcRcffJdHuSQWBLMxONAHS[n, num2];
				if (huFUPnVcilGVsLkOQFTNYtvJAVLr2.rPyjYnHNywhBrBsGdWEhpqiRTLBQ != HuFUPnVcilGVsLkOQFTNYtvJAVLr.mwXfHFowKvsuWMliBccedlNelJgzA.Disabled)
				{
					lnDNmgCdAUoldOfPbHChIcFoEfFjb2.lzQtftFgrdhWxlSTZNBDDLGbQNu(huFUPnVcilGVsLkOQFTNYtvJAVLr2, P_0);
				}
			}
		}
	}

	private void pcMQVdVJlWbpWjxrGLoJXesimCaN(bool P_0, int P_1, int P_2)
	{
		int num = TcJeRjoAHWajdfxVaSabfTeqWDcy.oKnsZBCQtgEufGaLOKQQPSmAuaDB(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				mfifTKGNAuFdGBOUlQVuHsGEZyWgA[num].QbgUsKqanfFxLGvneDgkNXYUALSR(P_0);
			}
			else
			{
				TylDOBzcRcffJdHuSQWBLMxONAHS[P_1, num].QbgUsKqanfFxLGvneDgkNXYUALSR(P_0);
			}
		}
	}

	private void YXZIANnIHIaQeGIPKAEBaopirXteb(BridgedController P_0)
	{
		int num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0.sourceJoystick.rewiredId, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = oFuZjfXOmafeFFnAJGxlabOgzbgFb(P_0.sourceJoystick.rewiredId, rpdrpwFfKEBLcwJyfwMQnPKLzVeH.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = szfbyoEHroNfHCaaumoheusFcIKHc[num];
			szfbyoEHroNfHCaaumoheusFcIKHc.RemoveAt(num);
			joystick.VbVBYliTbuvVNPetPsBZqFKmHxco(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		JuRitPJrgSMAWSUYDTsgpTqpPALm.Add(joystick);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Add(joystick);
		JuRitPJrgSMAWSUYDTsgpTqpPALm.Sort(Joystick.IlwjNInzmxvVcBXkwDzCSGORdgzi);
		poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(joystick);
	}

	private void NaALcFCVHyHfEZYWEnIDsjKyAVUF(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= JuRitPJrgSMAWSUYDTsgpTqpPALm.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = JuRitPJrgSMAWSUYDTsgpTqpPALm[P_0];
		joystick.isConnected = false;
		if (nIwEdmHLGacxnyCQtcXmPGEPDySI != null)
		{
			nIwEdmHLGacxnyCQtcXmPGEPDySI(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (ojMXclRRguwDHCQZjTjpOeecWThO != null)
		{
			ojMXclRRguwDHCQZjTjpOeecWThO(joystick.type, joystick.id);
		}
		JuRitPJrgSMAWSUYDTsgpTqpPALm.RemoveAt(P_0);
		szfbyoEHroNfHCaaumoheusFcIKHc.Add(joystick);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Remove(joystick);
		poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(joystick);
		joystick.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
	}

	private void gjClishkKSFtuwapvcXlfgoCZiQN()
	{
		for (int num = JuRitPJrgSMAWSUYDTsgpTqpPALm.Count - 1; num >= 0; num--)
		{
			NaALcFCVHyHfEZYWEnIDsjKyAVUF(num);
		}
	}

	private bool hhPdXeFwCFVkagwuxTRKvKHhjTMTA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count; i++)
		{
			if (kOeUzaAxrTTjHjJsuAnJIMiZdGat[i] == P_0)
			{
				return true;
			}
		}
		kOeUzaAxrTTjHjJsuAnJIMiZdGat.Add(P_0);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Add(P_0);
		poHBjfNcWvllzJNNsERwbrPxRXyc.rGVWdbmPmKnjVBEVVakBlQfKAAd(P_0);
		return true;
	}

	private bool jSFqOYETANyBAUjypvvlDmVpEDmD(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		poHBjfNcWvllzJNNsERwbrPxRXyc.SxXykpNMIEhvyDiSjOwvEbWrniXR(P_0);
		clJJgGHmUINNlMhgMrVgDvxkJicW.Remove(P_0);
		return kOeUzaAxrTTjHjJsuAnJIMiZdGat.Remove(P_0);
	}

	private lnDNmgCdAUoldOfPbHChIcFoEfFjb GQrTYdDgKuiEyUtEkWxkpaDatYnH(int P_0)
	{
		if (P_0 == 9999999)
		{
			return JkdIojqDoZbOFVpmZOJdkjXreNri;
		}
		if (P_0 < 0 || P_0 >= ReInput.ajnOsEopTWvzJZjeDpcpYppqmqOw.DpfYFosOsNWtCFkziqdksZeTEArD)
		{
			return null;
		}
		return ABdiqcjGPOFjXCoPhncNYaRTxwiac[P_0];
	}

	private void XDkSyJLmeCtHciFuwLtTWagOBrbz(bool P_0)
	{
		if (!P_0)
		{
			gzxhDgphqicLqbTlEVWmvHZfIoJW.ChSGQysrQdGIBXwKGwUXspnaSifV();
		}
	}

	private void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
	{
		THRtUdLBqPKCSvKIahLGAdLQOdVMA.ciqEMkdNIetcwAdDEzSvXOVSVQfM(P_0);
		mEHvdpDSFOqqnkOaipXQzXsobfvk.ciqEMkdNIetcwAdDEzSvXOVSVQfM(P_0);
		for (int i = 0; i < JuRitPJrgSMAWSUYDTsgpTqpPALm.Count; i++)
		{
			JuRitPJrgSMAWSUYDTsgpTqpPALm[i].ciqEMkdNIetcwAdDEzSvXOVSVQfM(P_0);
		}
		for (int j = 0; j < kOeUzaAxrTTjHjJsuAnJIMiZdGat.Count; j++)
		{
			kOeUzaAxrTTjHjJsuAnJIMiZdGat[j].ciqEMkdNIetcwAdDEzSvXOVSVQfM(P_0);
		}
	}

	public void Dispose()
	{
		jZtwTxQjIMBZMEAKpWMmMcJOortz(true);
		GC.SuppressFinalize(this);
	}

	protected void hQVInFWrTMOWfdrNDZJGjCGXxatd()
	{
		try
		{
			jZtwTxQjIMBZMEAKpWMmMcJOortz(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void jZtwTxQjIMBZMEAKpWMmMcJOortz(bool P_0)
	{
		if (JChPmMbeaoLOGQvosPYqDDInSiCs)
		{
			return;
		}
		if (P_0)
		{
			if (oAyvPljoNGQuBPxukPSgGbJpoolb is IDisposable)
			{
				(oAyvPljoNGQuBPxukPSgGbJpoolb as IDisposable).Dispose();
			}
			if (RCrTjdsPXBdeyCAKlBltMOiTkcWvA is IDisposable)
			{
				(RCrTjdsPXBdeyCAKlBltMOiTkcWvA as IDisposable).Dispose();
			}
		}
		JChPmMbeaoLOGQvosPYqDDInSiCs = true;
	}
}
