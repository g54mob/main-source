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

internal sealed class FNKIgOISFgsKyonqFvBnwwgKMXdU : IDisposable
{
	public enum IYbNebxPqSEkIPoKSOrooynWnKqH
	{
		Connected = 0,
		Disconnected = 1
	}

	private class LXxoPXXaQwfqMprlPFDIPESeBXiV
	{
		public ADictionary<int, InputBehavior> ChfJEnxaCSMBJEcUlaFghoMrBRWJA;

		public List<InputBehavior> cPjATKEFVnoncvVPaNUIGdXjNrirA;

		public IList<InputBehavior> tvksJKRIjKVWpQMVfLvICsDBlFGo;

		public LXxoPXXaQwfqMprlPFDIPESeBXiV(List<InputBehavior> P_0)
		{
			cPjATKEFVnoncvVPaNUIGdXjNrirA = new List<InputBehavior>(P_0.Count);
			ChfJEnxaCSMBJEcUlaFghoMrBRWJA = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < P_0.Count; i++)
			{
				InputBehavior inputBehavior = P_0[i].Clone();
				ChfJEnxaCSMBJEcUlaFghoMrBRWJA.Add(P_0[i].id, inputBehavior);
				cPjATKEFVnoncvVPaNUIGdXjNrirA.Add(inputBehavior);
				num++;
			}
			tvksJKRIjKVWpQMVfLvICsDBlFGo = new ReadOnlyCollection<InputBehavior>(cPjATKEFVnoncvVPaNUIGdXjNrirA);
		}

		public InputBehavior HQYwOeYdSBGzNDEfGZWGRsPuenav(int P_0)
		{
			if (cPjATKEFVnoncvVPaNUIGdXjNrirA.Count == 0)
			{
				return null;
			}
			ChfJEnxaCSMBJEcUlaFghoMrBRWJA.TryGetValue(P_0, out var value);
			if (value == null)
			{
				return cPjATKEFVnoncvVPaNUIGdXjNrirA[0];
			}
			return value;
		}
	}

	private sealed class XObUUrRvGQbfnoEIEyUHSiSiUBjk : IEnumerable<CustomController>, IDisposable, IEnumerator<CustomController>, IEnumerable, IEnumerator
	{
		private int hMnbMujJvihgLcBmOvURwCGCKZDT;

		private CustomController vjnbYLtrPMftzpjohNfommerCnGo;

		private int AyagikQIJAatoHzFlyaifyWyaTktA;

		public FNKIgOISFgsKyonqFvBnwwgKMXdU zITtixdgVFWlEnpDnrTdnZsdTFkt;

		private int QyiBEPEroPUafhLJCrUdHEIOhJuB;

		public int DwkfDGQYbOTJcOOCPFXYcMGzyuMsA;

		private int jonEAGCBHrpBGiMTiiyTwtxzfXHP;

		private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return vjnbYLtrPMftzpjohNfommerCnGo;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return vjnbYLtrPMftzpjohNfommerCnGo;
			}
		}

		[DebuggerHidden]
		public XObUUrRvGQbfnoEIEyUHSiSiUBjk(int P_0)
		{
			hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
			AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
			FNKIgOISFgsKyonqFvBnwwgKMXdU fNKIgOISFgsKyonqFvBnwwgKMXdU = zITtixdgVFWlEnpDnrTdnZsdTFkt;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				goto IL_007d;
			}
			hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
			jonEAGCBHrpBGiMTiiyTwtxzfXHP = fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
			PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
			goto IL_008d;
			IL_007d:
			PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
			goto IL_008d;
			IL_008d:
			if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < jonEAGCBHrpBGiMTiiyTwtxzfXHP)
			{
				if (fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].sourceControllerId == QyiBEPEroPUafhLJCrUdHEIOhJuB)
				{
					vjnbYLtrPMftzpjohNfommerCnGo = fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
			XObUUrRvGQbfnoEIEyUHSiSiUBjk xObUUrRvGQbfnoEIEyUHSiSiUBjk;
			if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
				xObUUrRvGQbfnoEIEyUHSiSiUBjk = this;
			}
			else
			{
				xObUUrRvGQbfnoEIEyUHSiSiUBjk = new XObUUrRvGQbfnoEIEyUHSiSiUBjk(0);
				xObUUrRvGQbfnoEIEyUHSiSiUBjk.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
			}
			xObUUrRvGQbfnoEIEyUHSiSiUBjk.QyiBEPEroPUafhLJCrUdHEIOhJuB = DwkfDGQYbOTJcOOCPFXYcMGzyuMsA;
			return xObUUrRvGQbfnoEIEyUHSiSiUBjk;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private sealed class FkpmURPawLqaVUWVmLEMFqnfvhLN : IEnumerable<CustomController>, IDisposable, IEnumerator<CustomController>, IEnumerable, IEnumerator
	{
		private int hMnbMujJvihgLcBmOvURwCGCKZDT;

		private CustomController vjnbYLtrPMftzpjohNfommerCnGo;

		private int AyagikQIJAatoHzFlyaifyWyaTktA;

		public FNKIgOISFgsKyonqFvBnwwgKMXdU zITtixdgVFWlEnpDnrTdnZsdTFkt;

		private string GiYDMCcMONvVCiaWWsZIuJqycBAR;

		public string tvTXNTppqPDhYkrUlpahZVEoTeDc;

		private int jonEAGCBHrpBGiMTiiyTwtxzfXHP;

		private int PrfhaiCANHhjwtWLxlpNIHvkLSmF;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return vjnbYLtrPMftzpjohNfommerCnGo;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return vjnbYLtrPMftzpjohNfommerCnGo;
			}
		}

		[DebuggerHidden]
		public FkpmURPawLqaVUWVmLEMFqnfvhLN(int P_0)
		{
			hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
			AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
			FNKIgOISFgsKyonqFvBnwwgKMXdU fNKIgOISFgsKyonqFvBnwwgKMXdU = zITtixdgVFWlEnpDnrTdnZsdTFkt;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				goto IL_0083;
			}
			hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
			jonEAGCBHrpBGiMTiiyTwtxzfXHP = fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
			PrfhaiCANHhjwtWLxlpNIHvkLSmF = 0;
			goto IL_0093;
			IL_0083:
			PrfhaiCANHhjwtWLxlpNIHvkLSmF++;
			goto IL_0093;
			IL_0093:
			if (PrfhaiCANHhjwtWLxlpNIHvkLSmF < jonEAGCBHrpBGiMTiiyTwtxzfXHP)
			{
				if (fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI[PrfhaiCANHhjwtWLxlpNIHvkLSmF].tag.Equals(GiYDMCcMONvVCiaWWsZIuJqycBAR, StringComparison.OrdinalIgnoreCase))
				{
					vjnbYLtrPMftzpjohNfommerCnGo = fNKIgOISFgsKyonqFvBnwwgKMXdU.PfiuLhoSFPKXbIhGTBbdTzJWQpgI[PrfhaiCANHhjwtWLxlpNIHvkLSmF];
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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
			FkpmURPawLqaVUWVmLEMFqnfvhLN fkpmURPawLqaVUWVmLEMFqnfvhLN;
			if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
				fkpmURPawLqaVUWVmLEMFqnfvhLN = this;
			}
			else
			{
				fkpmURPawLqaVUWVmLEMFqnfvhLN = new FkpmURPawLqaVUWVmLEMFqnfvhLN(0);
				fkpmURPawLqaVUWVmLEMFqnfvhLN.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
			}
			fkpmURPawLqaVUWVmLEMFqnfvhLN.GiYDMCcMONvVCiaWWsZIuJqycBAR = tvTXNTppqPDhYkrUlpahZVEoTeDc;
			return fkpmURPawLqaVUWVmLEMFqnfvhLN;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}
	}

	private List<Joystick> iDZyvUlNOIxTktdkqatGasLcxZRL;

	private List<Joystick> ZcxjGpfaFuISfLJABlODzoPvhCCU;

	private List<CustomController> PfiuLhoSFPKXbIhGTBbdTzJWQpgI;

	private List<Controller> JoPfFIxqeMqEHpCPvbTUSObrwtgC;

	private ReadOnlyCollection<Controller> VYZdlGXoIyyZOrkKBqTcKMAFHrTh;

	private Keyboard srFBkeklMLkzixCmDIziDiekVvFLc;

	private Mouse THVedgpUrWBoBPyOJDjeuRVtdWvh;

	private ConfigVars DMXabkqQUJPnibCwPIPncbvzMVgD;

	private oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[] GYjdwIKHHJkqkXvAcUrlbSgKIwsF;

	private oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[] ZkcANfmqIgMoqnwbEtMyprtXsIUB;

	private oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[,] oHdAGAfLdgJSnEKYvsqllEINzSFkA;

	private qhdGsmuaRZPOXBEZmmGhxzHSRVAx DIlympNEUqGsUcKNxjoYXioqIqBNA;

	private QqVvPboyrQKVDvvGWuoTtoXflELE iTnpLgOxUPIEnqEUuPgFxbyweatGA;

	private QqVvPboyrQKVDvvGWuoTtoXflELE[] hErdhrwDhOcQhdLnUuIfxxymPogZ;

	private qMqSqeRRfNPTXXedAQnRuVTbClCw<ActiveControllerChangedDelegate> TLwPAejERSfVDfKAiYQPIMRYCwUg;

	private qMqSqeRRfNPTXXedAQnRuVTbClCw<PlayerActiveControllerChangedDelegate> FBRamjBOwQEdjafxgqjYowTCxCfcD;

	private qMqSqeRRfNPTXXedAQnRuVTbClCw<PlayerActiveControllerChangedDelegate>[] PutGmXieYNKiRgXraGCvGQiauhqV;

	private ADictionary<int, LXxoPXXaQwfqMprlPFDIPESeBXiV> TaFGHJHXxbAodvESaAxHunsLfxiB;

	private readonly XPTCKTooCGCKcMxzkZtfjnOrnRvn WKPQYqlNclnKBgRtFDmKjqOuBDsSA;

	private IList<Joystick> eMJMtZmZFEFzeqMCGkpamcAksTYy;

	private IList<CustomController> eDAcHhiAMTDmYyUtDfFSMYtpbufb;

	private int NexxvzEKLwAunbJEaPqbKKLRDfsb;

	private bool WBshyHSrEYgqcTwjPvVfrvvhUmXF;

	private bool FWIoLKHqHscanYzwXIEcScSmxlVN;

	private bool HnWgRpFUeADOhBgCxMUiEFXMPvmab;

	private IUnifiedKeyboardSource XGGieMPbYXXpMqQXBjjgLtOuoacv;

	private IUnifiedMouseSource egzoIoWzVRBgCrBiGZKLLDNYcPGg;

	private int oJHQiUiGvtqBzBOwrMBtQqqajTcI;

	private ZMpcfnbkMDhQJzdCqDCNEGJIOILI oLBbvsaIpIbSBPWdHzABkcRnEFqPA;

	private zKNNZnSHSthbvEKCDSDTTqBJXGfm LmvhkTCrnWKGfgMggYILVjKvuRWf;

	private int kLtKHYOKyHabTdaYNJSDSbiURQrCA;

	private int AYaeikGbAWJSxAusdDGtShFwSvkHb;

	private Action<int, ControllerDataUpdater> NVtJcRSprxSkhLZoNdAjoqGEJZdi;

	private Action<bool, int, int> BGhAkVGbNyPkvrcCFFjRrIqhhdYDb;

	private Action<ControllerStatusChangedEventArgs> UfevDfxCqyFDBiJoCdUExUjWZFQwA;

	private Action<ControllerType, int> XZYnZqzMUswxdtbrMJFVLsBzXPpL;

	private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

	public IList<Joystick> dqbLSAyEdKRYtfOmwCVufVUOhfaN => eMJMtZmZFEFzeqMCGkpamcAksTYy;

	public List<Joystick> fgRNkONYHwMEPcqrunpRnOIQVZKu => iDZyvUlNOIxTktdkqatGasLcxZRL;

	public int wfXcGbTMFLTAwDvEytkMGYATlJxS => iDZyvUlNOIxTktdkqatGasLcxZRL.Count;

	public Mouse PFBHIEavSNmCtRpAbjOJnbVrdybGA => THVedgpUrWBoBPyOJDjeuRVtdWvh;

	public Keyboard ksIrgmIMxbskrWvzAPRFSsoyIedU => srFBkeklMLkzixCmDIziDiekVvFLc;

	public IList<CustomController> nXskdlIEaHeWrNhncZFmhjuqgJCE => eDAcHhiAMTDmYyUtDfFSMYtpbufb;

	public List<CustomController> mHhkYUEctkIGnqSZTSZcffgnSSJI => PfiuLhoSFPKXbIhGTBbdTzJWQpgI;

	public int wBbxrMLeCcnzzcTBhwMHzHnZVhfg => PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;

	public IList<Controller> dfNtogKfzQPVfHOqaceybelwlhei => VYZdlGXoIyyZOrkKBqTcKMAFHrTh;

	public int bjUBfnMXpSPAKDJOeQJqyYUYNCXb => JoPfFIxqeMqEHpCPvbTUSObrwtgC.Count;

	private int bxobLpicBBAXeZFPlozidyLbvdYaA
	{
		get
		{
			int result = oJHQiUiGvtqBzBOwrMBtQqqajTcI;
			oJHQiUiGvtqBzBOwrMBtQqqajTcI++;
			if (oJHQiUiGvtqBzBOwrMBtQqqajTcI >= int.MaxValue)
			{
				oJHQiUiGvtqBzBOwrMBtQqqajTcI = 0;
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> StXxLYlyOaBiSphJveVAkAiMktzR
	{
		add
		{
			UfevDfxCqyFDBiJoCdUExUjWZFQwA = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(UfevDfxCqyFDBiJoCdUExUjWZFQwA, b);
		}
		remove
		{
			UfevDfxCqyFDBiJoCdUExUjWZFQwA = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(UfevDfxCqyFDBiJoCdUExUjWZFQwA, value2);
		}
	}

	public event Action<ControllerType, int> UCTggyfbGAIPtFTzlHEtuldKRzEJ
	{
		add
		{
			XZYnZqzMUswxdtbrMJFVLsBzXPpL = (Action<ControllerType, int>)Delegate.Combine(XZYnZqzMUswxdtbrMJFVLsBzXPpL, b);
		}
		remove
		{
			XZYnZqzMUswxdtbrMJFVLsBzXPpL = (Action<ControllerType, int>)Delegate.Remove(XZYnZqzMUswxdtbrMJFVLsBzXPpL, value2);
		}
	}

	public FNKIgOISFgsKyonqFvBnwwgKMXdU(ConfigVars P_0, PlatformInputManager P_1)
	{
		DMXabkqQUJPnibCwPIPncbvzMVgD = P_0;
		NexxvzEKLwAunbJEaPqbKKLRDfsb = 0;
		WBshyHSrEYgqcTwjPvVfrvvhUmXF = UnityTools.isAndroidPlatform;
		JoPfFIxqeMqEHpCPvbTUSObrwtgC = new List<Controller>(10);
		VYZdlGXoIyyZOrkKBqTcKMAFHrTh = new ReadOnlyCollection<Controller>(JoPfFIxqeMqEHpCPvbTUSObrwtgC);
		IUnifiedKeyboardSource unifiedKeyboardSource = P_1.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (XGGieMPbYXXpMqQXBjjgLtOuoacv = new UnityUnifiedKeyboardSource());
		}
		srFBkeklMLkzixCmDIziDiekVvFLc = new Keyboard("Keyboard", unifiedKeyboardSource);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Add(srFBkeklMLkzixCmDIziDiekVvFLc);
		IUnifiedMouseSource unifiedMouseSource = P_1.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (egzoIoWzVRBgCrBiGZKLLDNYcPGg = new UnityUnifiedMouseSource());
		}
		THVedgpUrWBoBPyOJDjeuRVtdWvh = new Mouse("Mouse", unifiedMouseSource);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Add(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		DIlympNEUqGsUcKNxjoYXioqIqBNA = new qhdGsmuaRZPOXBEZmmGhxzHSRVAx(P_0.updateLoop, srFBkeklMLkzixCmDIziDiekVvFLc);
		srFBkeklMLkzixCmDIziDiekVvFLc.dnIMGTNXLhdyZHTiJNpLPCYsUwfp += ghuvqIdfASgEYNmKFDVdHxVJdCdH;
		srFBkeklMLkzixCmDIziDiekVvFLc.enabled = !P_0.GetPlatformVar_disableKeyboard();
		THVedgpUrWBoBPyOJDjeuRVtdWvh.enabled = !P_0.GetPlatformVar_disableMouse();
		WYNKNWIFczeVHUyRjGlNScqXANMC.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA = new XPTCKTooCGCKcMxzkZtfjnOrnRvn(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(srFBkeklMLkzixCmDIziDiekVvFLc);
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		ReInput.ApplicationFocusChangedEvent += LkQTpFBeyUXMAddalyNJQqSBAfDB;
	}

	public void TlzckGoQDITHcUYaslQXPQBOhTwq(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		NVtJcRSprxSkhLZoNdAjoqGEJZdi = P_0;
		TlzckGoQDITHcUYaslQXPQBOhTwq(P_1);
	}

	public void DsDuSUaDcVanpNAhDLIRqjKndMGi(UpdateLoopType P_0)
	{
		WYNKNWIFczeVHUyRjGlNScqXANMC.JWFebvhzvQAAorlOmNEaEKvHKbdFA(P_0);
		if (srFBkeklMLkzixCmDIziDiekVvFLc.enabled)
		{
			DIlympNEUqGsUcKNxjoYXioqIqBNA.DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0);
		}
		PKJRuCXeFVbzXoijHEWniJCFiKUlA(P_0);
		esQVFcDfFLQAFeYdbLipgyfQoAKi(P_0);
		WYNKNWIFczeVHUyRjGlNScqXANMC.bGmoUimdmfdGLWSXOgeEiOJuUsWfA(P_0, ReInput.currentFrame);
		if (HnWgRpFUeADOhBgCxMUiEFXMPvmab)
		{
			cTFyVBpGJQMWnEyXJxahMhGqKEqD();
		}
	}

	public oQRCFcJpUjLqOkwwnIxnfTMKhLJWA spuIPZtVjMmDKIpmbCpwlvidgLqV(int P_0, string P_1, bool P_2)
	{
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return ZkcANfmqIgMoqnwbEtMyprtXsIUB[num];
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return null;
		}
		return oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, num];
	}

	public oQRCFcJpUjLqOkwwnIxnfTMKhLJWA spuIPZtVjMmDKIpmbCpwlvidgLqV(int P_0, int P_1, bool P_2)
	{
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.PujFpIgnaejxCcbCzrcoRIpZaecab(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return ZkcANfmqIgMoqnwbEtMyprtXsIUB[num];
		}
		return oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, num];
	}

	public void RVKAUvgycSVPewVLbYhIRjVBrtIe(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 != null && P_0.sourceJoystick != null)
		{
			IYbNebxPqSEkIPoKSOrooynWnKqH ybNebxPqSEkIPoKSOrooynWnKqH = IYbNebxPqSEkIPoKSOrooynWnKqH.Connected;
			int num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0.sourceJoystick.rewiredId, ybNebxPqSEkIPoKSOrooynWnKqH);
			if (num < 0)
			{
				ybNebxPqSEkIPoKSOrooynWnKqH = IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected;
				num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0.sourceJoystick.rewiredId, ybNebxPqSEkIPoKSOrooynWnKqH);
			}
			if (num >= 0)
			{
				((ybNebxPqSEkIPoKSOrooynWnKqH == IYbNebxPqSEkIPoKSOrooynWnKqH.Connected) ? iDZyvUlNOIxTktdkqatGasLcxZRL[num] : ZcxjGpfaFuISfLJABlODzoPvhCCU[num]).oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(P_0);
			}
		}
	}

	public bool gkGgKEcMRFPOBGhpxffOOBNuinUAb(int P_0, IYbNebxPqSEkIPoKSOrooynWnKqH P_1)
	{
		if (TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int TwgunmnyKeVEjSpcyZODwqvafMkF(int P_0, IYbNebxPqSEkIPoKSOrooynWnKqH P_1)
	{
		switch (P_1)
		{
		case IYbNebxPqSEkIPoKSOrooynWnKqH.Connected:
		{
			int count2 = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
			for (int j = 0; j < count2; j++)
			{
				if (iDZyvUlNOIxTktdkqatGasLcxZRL[j].id == P_0)
				{
					return j;
				}
			}
			break;
		}
		case IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected:
		{
			int count = ZcxjGpfaFuISfLJABlODzoPvhCCU.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZcxjGpfaFuISfLJABlODzoPvhCCU[i].id == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public int TwgunmnyKeVEjSpcyZODwqvafMkF(Guid P_0, IYbNebxPqSEkIPoKSOrooynWnKqH P_1)
	{
		switch (P_1)
		{
		case IYbNebxPqSEkIPoKSOrooynWnKqH.Connected:
		{
			int count2 = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
			for (int j = 0; j < count2; j++)
			{
				if (iDZyvUlNOIxTktdkqatGasLcxZRL[j].deviceInstanceGuid == P_0)
				{
					return j;
				}
			}
			break;
		}
		case IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected:
		{
			int count = ZcxjGpfaFuISfLJABlODzoPvhCCU.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZcxjGpfaFuISfLJABlODzoPvhCCU[i].deviceInstanceGuid == P_0)
				{
					return i;
				}
			}
			break;
		}
		}
		return -1;
	}

	public bool uPoeuBruDomHyyLREpgSVxeKfoul(int P_0)
	{
		if (xsTvJUhThkmmUawOmXEfnogPuaAI(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int xsTvJUhThkmmUawOmXEfnogPuaAI(int P_0)
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		for (int i = 0; i < count; i++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i].id == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public int xsTvJUhThkmmUawOmXEfnogPuaAI(Guid P_0)
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		for (int i = 0; i < count; i++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i].deviceInstanceGuid == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	public void BCTLZQnARumowWrfyBZJTuGYtuHO(BridgedController P_0)
	{
		fbLNhEBlSWrcKvHrnqtzvCOvBMdh(P_0);
	}

	public void vJyBZTBAkGLQndXFEnedryYvMetn(int P_0)
	{
		int num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, IYbNebxPqSEkIPoKSOrooynWnKqH.Connected);
		yWIkOUkJtijgeeoctYLltqhxeKIP(num);
	}

	public int NYsffresRDKwCZdUqinajwfUIwoYA()
	{
		return NexxvzEKLwAunbJEaPqbKKLRDfsb++;
	}

	public IList<InputBehavior> BLmglDisFscRMEbYRzrZHWrhAOln(int P_0)
	{
		if (!TaFGHJHXxbAodvESaAxHunsLfxiB.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return TaFGHJHXxbAodvESaAxHunsLfxiB[P_0].tvksJKRIjKVWpQMVfLvICsDBlFGo;
	}

	public InputBehavior SFJZdklJEKfUiGPbWOYRazmyxtQuA(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return SFJZdklJEKfUiGPbWOYRazmyxtQuA(P_0, inputBehaviorId);
	}

	public InputBehavior SFJZdklJEKfUiGPbWOYRazmyxtQuA(int P_0, int P_1)
	{
		if (!TaFGHJHXxbAodvESaAxHunsLfxiB.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> tvksJKRIjKVWpQMVfLvICsDBlFGo = TaFGHJHXxbAodvESaAxHunsLfxiB[P_0].tvksJKRIjKVWpQMVfLvICsDBlFGo;
		for (int i = 0; i < tvksJKRIjKVWpQMVfLvICsDBlFGo.Count; i++)
		{
			if (tvksJKRIjKVWpQMVfLvICsDBlFGo[i].id == P_1)
			{
				return tvksJKRIjKVWpQMVfLvICsDBlFGo[i];
			}
		}
		return null;
	}

	public Joystick EPOGytyJCWylBVHKoFQXhUyQAprcb(int P_0, bool P_1 = false)
	{
		int num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, IYbNebxPqSEkIPoKSOrooynWnKqH.Connected);
		if (num >= 0)
		{
			return iDZyvUlNOIxTktdkqatGasLcxZRL[num];
		}
		if (P_1)
		{
			num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected);
			if (num >= 0)
			{
				return ZcxjGpfaFuISfLJABlODzoPvhCCU[num];
			}
		}
		return null;
	}

	public Joystick EPOGytyJCWylBVHKoFQXhUyQAprcb(Guid P_0, bool P_1 = false)
	{
		int num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, IYbNebxPqSEkIPoKSOrooynWnKqH.Connected);
		if (num >= 0)
		{
			return iDZyvUlNOIxTktdkqatGasLcxZRL[num];
		}
		if (P_1)
		{
			num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0, IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected);
			if (num >= 0)
			{
				return ZcxjGpfaFuISfLJABlODzoPvhCCU[num];
			}
		}
		return null;
	}

	public Joystick[] rbBlhjrovprRnObkmkKQytErKEiN()
	{
		int count = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = iDZyvUlNOIxTktdkqatGasLcxZRL[i];
		}
		return array;
	}

	public string[] ChiAoYAlHmAoqFwfKRSCgJmfFJPKA()
	{
		int count = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = iDZyvUlNOIxTktdkqatGasLcxZRL[i].name;
		}
		return array;
	}

	public CustomController ivkRKvvGYxrHvXDUIEhQMQamHUeC(int P_0)
	{
		int num = xsTvJUhThkmmUawOmXEfnogPuaAI(P_0);
		if (num < 0)
		{
			return null;
		}
		return PfiuLhoSFPKXbIhGTBbdTzJWQpgI[num];
	}

	public CustomController ivkRKvvGYxrHvXDUIEhQMQamHUeC(Guid P_0)
	{
		int num = xsTvJUhThkmmUawOmXEfnogPuaAI(P_0);
		if (num < 0)
		{
			return null;
		}
		return PfiuLhoSFPKXbIhGTBbdTzJWQpgI[num];
	}

	public CustomController[] JiVocbhbmNrpHMfMFXnEaiLHBunCA()
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i];
		}
		return array;
	}

	public string[] VVPDliKZZldKAZTZFKJjHUkfbmeCc()
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i].name;
		}
		return array;
	}

	public CustomController REFjFzjqVfBzOqUbhgBnBtJFDRDQb(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int poDKkXNZKOoZdyxGaKFAmJnBpZjC = bxobLpicBBAXeZFPlozidyLbvdYaA;
		CustomController customController = new CustomController(new nglusGJXMgLJZiPxWsApahSkNMcB
		{
			HXvQzPApsqliDaJnhjuqaWlQGmel = InputSource.Custom,
			LhuRrfwUPjAvVlMldFuefsAzsjXEb = customControllerById.descriptiveName,
			nboorIDxkYmnlTDtCiHMGRkezuKF = customControllerById.name,
			MXkNViMtSkCXhVAqsNOXkqgyAXmH = customControllerById.axisCount,
			JUTanEOVBHbwVHQHKsAHkvZOyxmj = customControllerById.buttonCount,
			PoDKkXNZKOoZdyxGaKFAmJnBpZjC = poDKkXNZKOoZdyxGaKFAmJnBpZjC,
			wBSTLjhpdiHRmEEkZOkkaQsqkqoP = customControllerById.id,
			oIiVjZhLzkOGISxkurAyuQUtJZSA = customControllerById.typeGuid,
			mYDXvdZiNyDHBPtnhOwhGhxHttvt = customControllerById.id.ToString(),
			OzUAkEAoBUdTsTYzBynAISLBcyKN = customControllerById.CreateGameHardwareMap()
		});
		UkDCStQxuTTzKRfUCpNqHNkmXkEG(customController);
		return customController;
	}

	public bool BWwCkvQolrBhAUEVnxBcpzwLMbpG(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return YpPprTyCjXINuDdRSIPPjCHwrQiRA(P_0);
	}

	public CustomController OfkJqbQgXtexMBtznwjseMqgxqbM(int P_0)
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		for (int i = 0; i < count; i++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i].sourceControllerId == P_0)
			{
				return PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i];
			}
		}
		return null;
	}

	public CustomController TGqzjJzOivrSagsCKEKvjIIrwvfJA(string P_0)
	{
		int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		for (int i = 0; i < count; i++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i];
			}
		}
		return null;
	}

	public IEnumerable<CustomController> WscepHGvdSvomDaSfbHuVBaFDyGy(int P_0)
	{
		return new XObUUrRvGQbfnoEIEyUHSiSiUBjk(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
			DwkfDGQYbOTJcOOCPFXYcMGzyuMsA = P_0
		};
	}

	public IEnumerable<CustomController> gkPTLDzKywBjLjvsYlUYXYaegPyq(string P_0)
	{
		return new FkpmURPawLqaVUWVmLEMFqnfvhLN(-2)
		{
			zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
			tvTXNTppqPDhYkrUlpahZVEoTeDc = P_0
		};
	}

	public Controller gAPABsuepoxQLaHJJhjKlywBeNAd(ControllerType P_0, int P_1, bool P_2 = false)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return EPOGytyJCWylBVHKoFQXhUyQAprcb(P_1, P_2);
		case ControllerType.Keyboard:
			return srFBkeklMLkzixCmDIziDiekVvFLc;
		case ControllerType.Mouse:
			return THVedgpUrWBoBPyOJDjeuRVtdWvh;
		case ControllerType.Custom:
			return ivkRKvvGYxrHvXDUIEhQMQamHUeC(P_1);
		default:
			throw new NotImplementedException();
		}
	}

	public Controller gAPABsuepoxQLaHJJhjKlywBeNAd(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return gAPABsuepoxQLaHJJhjKlywBeNAd(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return gAPABsuepoxQLaHJJhjKlywBeNAd(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller gAPABsuepoxQLaHJJhjKlywBeNAd(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (srFBkeklMLkzixCmDIziDiekVvFLc.deviceInstanceGuid == P_0)
		{
			return srFBkeklMLkzixCmDIziDiekVvFLc;
		}
		if (THVedgpUrWBoBPyOJDjeuRVtdWvh.deviceInstanceGuid == P_0)
		{
			return THVedgpUrWBoBPyOJDjeuRVtdWvh;
		}
		Controller result;
		if ((result = EPOGytyJCWylBVHKoFQXhUyQAprcb(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = ivkRKvvGYxrHvXDUIEhQMQamHUeC(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] RdbrZaSeRjDaVJQGByOntZRScMlG(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return rbBlhjrovprRnObkmkKQytErKEiN();
		case ControllerType.Keyboard:
			return new Controller[1] { srFBkeklMLkzixCmDIziDiekVvFLc };
		case ControllerType.Mouse:
			return new Controller[1] { THVedgpUrWBoBPyOJDjeuRVtdWvh };
		case ControllerType.Custom:
			return JiVocbhbmNrpHMfMFXnEaiLHBunCA();
		default:
			throw new NotImplementedException();
		}
	}

	public string[] oLiHoScHhSofapBlXVSPeydcjsMy(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return ChiAoYAlHmAoqFwfKRSCgJmfFJPKA();
		case ControllerType.Keyboard:
			return new string[1] { srFBkeklMLkzixCmDIziDiekVvFLc.name };
		case ControllerType.Mouse:
			return new string[1] { THVedgpUrWBoBPyOJDjeuRVtdWvh.name };
		case ControllerType.Custom:
			return VVPDliKZZldKAZTZFKJjHUkfbmeCc();
		default:
			throw new NotImplementedException();
		}
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.fyeqCafQbFyflbNbajUvornPxfgy(P_1, P_2, InputActionEventType.Update, null);
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.fyeqCafQbFyflbNbajUvornPxfgy(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_3);
		if (num >= 0)
		{
			FRKOkrggsFUysyoSQRSawmtATWQH(P_0, P_1, P_2, num);
		}
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.fyeqCafQbFyflbNbajUvornPxfgy(P_1, P_2, P_3, P_4);
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.fyeqCafQbFyflbNbajUvornPxfgy(P_1, P_2, P_3, P_4, P_5);
	}

	public void FRKOkrggsFUysyoSQRSawmtATWQH(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			FWIoLKHqHscanYzwXIEcScSmxlVN = true;
		}
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_4);
		if (num >= 0)
		{
			FRKOkrggsFUysyoSQRSawmtATWQH(P_0, P_1, P_2, P_3, num, P_5);
		}
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_2);
		if (num >= 0)
		{
			QGnlTvJhyLAlRpEjXeLnweJnwVst(P_0, P_1, num);
		}
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2, P_3);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_3);
		if (num >= 0)
		{
			QGnlTvJhyLAlRpEjXeLnweJnwVst(P_0, P_1, P_2, num);
		}
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2, P_3);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_3);
		if (num >= 0)
		{
			QGnlTvJhyLAlRpEjXeLnweJnwVst(P_0, P_1, P_2, num);
		}
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2, P_3);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.QCWdrwUdFoEQDLjAeGnqtGDjBvyCA(P_1, P_2, P_3, P_4);
	}

	public void QGnlTvJhyLAlRpEjXeLnweJnwVst(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA.LdMwxkpmOahQpxrdWsSafRVVeUPg(P_4);
		if (num >= 0)
		{
			QGnlTvJhyLAlRpEjXeLnweJnwVst(P_0, P_1, P_2, P_3, num);
		}
	}

	public void RTipuxHoXnMqsfhIfxhgSsynkdqH(int P_0)
	{
		bNxWAwnIoatFItyoDhgEaMsrDrdp(P_0)?.wJjPIIRJfHhEbGedUconecGfiwzgB();
	}

	public bool qUrTyDHTIgqTctTvrtbwBHLaBFwy(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].aBjKkYedffJMBNyjOkVFOWaUaAhq())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].aBjKkYedffJMBNyjOkVFOWaUaAhq())
			{
				return true;
			}
		}
		return false;
	}

	public bool aEUyVOBuXYFDinYfgLbRvsUvMkLv(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].jYWxpmOgglOGuxLGHjZnFKAvkMEVA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].jYWxpmOgglOGuxLGHjZnFKAvkMEVA())
			{
				return true;
			}
		}
		return false;
	}

	public bool jtBwSKTmuecbdEtqRZNsystzKhTF(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].NSCNnosVEfppjSDmbInqdnhriOUCb())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].NSCNnosVEfppjSDmbInqdnhriOUCb())
			{
				return true;
			}
		}
		return false;
	}

	public bool slkeuaEzXgYgYFQvyTdkJJsbNEViA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].qveZUhnPEVcbIJyEhVLiIhpjriCfA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].qveZUhnPEVcbIJyEhVLiIhpjriCfA())
			{
				return true;
			}
		}
		return false;
	}

	public bool IhqYotTsPxnlgOhvBpnLINHiBeop(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].BUDvRzCDOdNgSDFFXUnYMQiVSgEo())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].BUDvRzCDOdNgSDFFXUnYMQiVSgEo())
			{
				return true;
			}
		}
		return false;
	}

	public bool OZpskBRqCuiruaOykOqXAFdESsYOb(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].HelmxrCyZjEmODVCgMtGwDwOrjHf())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].HelmxrCyZjEmODVCgMtGwDwOrjHf())
			{
				return true;
			}
		}
		return false;
	}

	public bool jNcBwoAokpEjcPAoSMPLskMeYEOVA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].MwMEOSDIIFPGmIGayVPhiNpATkQH())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].MwMEOSDIIFPGmIGayVPhiNpATkQH())
			{
				return true;
			}
		}
		return false;
	}

	public bool pGsCXnCUqHHyHZECiHeOhbZepYShA(int P_0)
	{
		if (P_0 == 9999999)
		{
			for (int i = 0; i < ZkcANfmqIgMoqnwbEtMyprtXsIUB.Length; i++)
			{
				if (ZkcANfmqIgMoqnwbEtMyprtXsIUB[i].QjvTGGincqjqIbxSLkbGWDLjDQuqA())
				{
					return true;
				}
			}
			return false;
		}
		if (P_0 < 0 || P_0 >= kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return false;
		}
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		for (int j = 0; j < num; j++)
		{
			if (oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_0, j].QjvTGGincqjqIbxSLkbGWDLjDQuqA())
			{
				return true;
			}
		}
		return false;
	}

	public bool bEjCYdHONuNmFNifoIjBdDLELqbUB()
	{
		if (!bEjCYdHONuNmFNifoIjBdDLELqbUB(THVedgpUrWBoBPyOJDjeuRVtdWvh) && !bEjCYdHONuNmFNifoIjBdDLELqbUB(iDZyvUlNOIxTktdkqatGasLcxZRL) && !bEjCYdHONuNmFNifoIjBdDLELqbUB(srFBkeklMLkzixCmDIziDiekVvFLc))
		{
			return bEjCYdHONuNmFNifoIjBdDLELqbUB(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		}
		return true;
	}

	public bool bEjCYdHONuNmFNifoIjBdDLELqbUB(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return bEjCYdHONuNmFNifoIjBdDLELqbUB(iDZyvUlNOIxTktdkqatGasLcxZRL);
		case ControllerType.Keyboard:
			return bEjCYdHONuNmFNifoIjBdDLELqbUB(srFBkeklMLkzixCmDIziDiekVvFLc);
		case ControllerType.Mouse:
			return bEjCYdHONuNmFNifoIjBdDLELqbUB(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		case ControllerType.Custom:
			return bEjCYdHONuNmFNifoIjBdDLELqbUB(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		default:
			throw new NotImplementedException();
		}
	}

	public bool xjuauQbieLHzeLjZSJxPDbVcfiWUA()
	{
		if (!xjuauQbieLHzeLjZSJxPDbVcfiWUA(THVedgpUrWBoBPyOJDjeuRVtdWvh) && !xjuauQbieLHzeLjZSJxPDbVcfiWUA(iDZyvUlNOIxTktdkqatGasLcxZRL) && !xjuauQbieLHzeLjZSJxPDbVcfiWUA(srFBkeklMLkzixCmDIziDiekVvFLc))
		{
			return xjuauQbieLHzeLjZSJxPDbVcfiWUA(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		}
		return true;
	}

	public bool xjuauQbieLHzeLjZSJxPDbVcfiWUA(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return xjuauQbieLHzeLjZSJxPDbVcfiWUA(iDZyvUlNOIxTktdkqatGasLcxZRL);
		case ControllerType.Keyboard:
			return xjuauQbieLHzeLjZSJxPDbVcfiWUA(srFBkeklMLkzixCmDIziDiekVvFLc);
		case ControllerType.Mouse:
			return xjuauQbieLHzeLjZSJxPDbVcfiWUA(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		case ControllerType.Custom:
			return xjuauQbieLHzeLjZSJxPDbVcfiWUA(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		default:
			throw new NotImplementedException();
		}
	}

	public bool LibGTMQwNuWAvjYUKltqGokLHoYN()
	{
		if (!LibGTMQwNuWAvjYUKltqGokLHoYN(THVedgpUrWBoBPyOJDjeuRVtdWvh) && !LibGTMQwNuWAvjYUKltqGokLHoYN(iDZyvUlNOIxTktdkqatGasLcxZRL) && !LibGTMQwNuWAvjYUKltqGokLHoYN(srFBkeklMLkzixCmDIziDiekVvFLc))
		{
			return LibGTMQwNuWAvjYUKltqGokLHoYN(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		}
		return true;
	}

	public bool LibGTMQwNuWAvjYUKltqGokLHoYN(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return LibGTMQwNuWAvjYUKltqGokLHoYN(iDZyvUlNOIxTktdkqatGasLcxZRL);
		case ControllerType.Keyboard:
			return LibGTMQwNuWAvjYUKltqGokLHoYN(srFBkeklMLkzixCmDIziDiekVvFLc);
		case ControllerType.Mouse:
			return LibGTMQwNuWAvjYUKltqGokLHoYN(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		case ControllerType.Custom:
			return LibGTMQwNuWAvjYUKltqGokLHoYN(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		default:
			throw new NotImplementedException();
		}
	}

	public bool INzAnNFORDuGjMBqYDhPMwqXDFIcA()
	{
		if (!INzAnNFORDuGjMBqYDhPMwqXDFIcA(THVedgpUrWBoBPyOJDjeuRVtdWvh) && !INzAnNFORDuGjMBqYDhPMwqXDFIcA(iDZyvUlNOIxTktdkqatGasLcxZRL) && !INzAnNFORDuGjMBqYDhPMwqXDFIcA(srFBkeklMLkzixCmDIziDiekVvFLc))
		{
			return INzAnNFORDuGjMBqYDhPMwqXDFIcA(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		}
		return true;
	}

	public bool INzAnNFORDuGjMBqYDhPMwqXDFIcA(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return INzAnNFORDuGjMBqYDhPMwqXDFIcA(iDZyvUlNOIxTktdkqatGasLcxZRL);
		case ControllerType.Keyboard:
			return INzAnNFORDuGjMBqYDhPMwqXDFIcA(srFBkeklMLkzixCmDIziDiekVvFLc);
		case ControllerType.Mouse:
			return INzAnNFORDuGjMBqYDhPMwqXDFIcA(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		case ControllerType.Custom:
			return INzAnNFORDuGjMBqYDhPMwqXDFIcA(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		default:
			throw new NotImplementedException();
		}
	}

	public bool LYjgMPcRTohNXetfcTxkFoUCGEDLE()
	{
		if (!LYjgMPcRTohNXetfcTxkFoUCGEDLE(THVedgpUrWBoBPyOJDjeuRVtdWvh) && !LYjgMPcRTohNXetfcTxkFoUCGEDLE(iDZyvUlNOIxTktdkqatGasLcxZRL) && !LYjgMPcRTohNXetfcTxkFoUCGEDLE(srFBkeklMLkzixCmDIziDiekVvFLc))
		{
			return LYjgMPcRTohNXetfcTxkFoUCGEDLE(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		}
		return true;
	}

	public bool LYjgMPcRTohNXetfcTxkFoUCGEDLE(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return LYjgMPcRTohNXetfcTxkFoUCGEDLE(iDZyvUlNOIxTktdkqatGasLcxZRL);
		case ControllerType.Keyboard:
			return LYjgMPcRTohNXetfcTxkFoUCGEDLE(srFBkeklMLkzixCmDIziDiekVvFLc);
		case ControllerType.Mouse:
			return LYjgMPcRTohNXetfcTxkFoUCGEDLE(THVedgpUrWBoBPyOJDjeuRVtdWvh);
		case ControllerType.Custom:
			return LYjgMPcRTohNXetfcTxkFoUCGEDLE(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		default:
			throw new NotImplementedException();
		}
	}

	private bool bEjCYdHONuNmFNifoIjBdDLELqbUB<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool bEjCYdHONuNmFNifoIjBdDLELqbUB(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool xjuauQbieLHzeLjZSJxPDbVcfiWUA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool xjuauQbieLHzeLjZSJxPDbVcfiWUA(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool LibGTMQwNuWAvjYUKltqGokLHoYN<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool LibGTMQwNuWAvjYUKltqGokLHoYN(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool INzAnNFORDuGjMBqYDhPMwqXDFIcA<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool INzAnNFORDuGjMBqYDhPMwqXDFIcA(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool LYjgMPcRTohNXetfcTxkFoUCGEDLE<_0001>(IList<_0001> P_0) where _0001 : Controller
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

	private bool LYjgMPcRTohNXetfcTxkFoUCGEDLE(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller XGXtEHrvpvOZguxwYxxfpdPmfXDv()
	{
		Controller lastController = null;
		double lastTime = 0.0;
		InputTools.CompareLastActiveController(THVedgpUrWBoBPyOJDjeuRVtdWvh, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(srFBkeklMLkzixCmDIziDiekVvFLc, ref lastController, ref lastTime);
		IList<Joystick> list = iDZyvUlNOIxTktdkqatGasLcxZRL;
		for (int i = 0; i < wfXcGbTMFLTAwDvEytkMGYATlJxS; i++)
		{
			InputTools.CompareLastActiveController(list[i], ref lastController, ref lastTime);
		}
		IList<CustomController> pfiuLhoSFPKXbIhGTBbdTzJWQpgI = PfiuLhoSFPKXbIhGTBbdTzJWQpgI;
		for (int j = 0; j < wBbxrMLeCcnzzcTBhwMHzHnZVhfg; j++)
		{
			InputTools.CompareLastActiveController(pfiuLhoSFPKXbIhGTBbdTzJWQpgI[j], ref lastController, ref lastTime);
		}
		if (lastController == null)
		{
			lastController = srFBkeklMLkzixCmDIziDiekVvFLc;
		}
		return lastController;
	}

	public Controller XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		switch (P_0)
		{
		case ControllerType.Joystick:
		{
			int count = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(iDZyvUlNOIxTktdkqatGasLcxZRL[j], ref lastController, ref lastTime);
			}
			break;
		}
		case ControllerType.Keyboard:
			return ksIrgmIMxbskrWvzAPRFSsoyIedU;
		case ControllerType.Mouse:
			return PFBHIEavSNmCtRpAbjOJnbVrdybGA;
		case ControllerType.Custom:
		{
			int count = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i], ref lastController, ref lastTime);
			}
			break;
		}
		default:
			throw new NotImplementedException();
		}
		return lastController;
	}

	public _0001 XGXtEHrvpvOZguxwYxxfpdPmfXDv<_0001>() where _0001 : Controller
	{
		Type typeFromHandle = typeof(_0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Joystick) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Keyboard) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Custom) as _0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Mouse) as _0001;
		}
		throw new NotImplementedException();
	}

	public ControllerType XjqcOqHEhncFEkanEHcOMXYANZbOA()
	{
		return XGXtEHrvpvOZguxwYxxfpdPmfXDv()?.type ?? ControllerType.Keyboard;
	}

	public void BvWzsmEDKXHJdamXSxHkvlEaBMPC(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			HnWgRpFUeADOhBgCxMUiEFXMPvmab = true;
			TLwPAejERSfVDfKAiYQPIMRYCwUg.ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_0);
		}
	}

	public void BvWzsmEDKXHJdamXSxHkvlEaBMPC(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			HnWgRpFUeADOhBgCxMUiEFXMPvmab = true;
			TLwPAejERSfVDfKAiYQPIMRYCwUg.ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_0, P_1);
		}
	}

	public void HdlHQrgKTRKuUNntUzSxdjLVFDaK(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			TLwPAejERSfVDfKAiYQPIMRYCwUg.qqVlANPKfhQEENrgXylRygaPEIO(P_0);
		}
	}

	public void spPQKaELvVdlXntYRhNUlhWqieoL(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			TLwPAejERSfVDfKAiYQPIMRYCwUg.qqVlANPKfhQEENrgXylRygaPEIO(P_0, P_1);
		}
	}

	public void uVdGGwwgzyMStSFKWTNiNKHqwfHD()
	{
		TLwPAejERSfVDfKAiYQPIMRYCwUg.wJjPIIRJfHhEbGedUconecGfiwzgB();
	}

	public void BvWzsmEDKXHJdamXSxHkvlEaBMPC(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			FBRamjBOwQEdjafxgqjYowTCxCfcD.ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_1);
		}
		else
		{
			if ((uint)P_0 >= (uint)kLtKHYOKyHabTdaYNJSDSbiURQrCA)
			{
				return;
			}
			PutGmXieYNKiRgXraGCvGQiauhqV[P_0].ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_1);
		}
		HnWgRpFUeADOhBgCxMUiEFXMPvmab = true;
	}

	public void BvWzsmEDKXHJdamXSxHkvlEaBMPC(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		if (P_0 == 9999999)
		{
			FBRamjBOwQEdjafxgqjYowTCxCfcD.ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_1, P_2);
		}
		else
		{
			if ((uint)P_0 >= (uint)kLtKHYOKyHabTdaYNJSDSbiURQrCA)
			{
				return;
			}
			PutGmXieYNKiRgXraGCvGQiauhqV[P_0].ZgwOeBRlTsfdRMYnSYruJlwWpbx(P_1, P_2);
		}
		HnWgRpFUeADOhBgCxMUiEFXMPvmab = true;
	}

	public void HdlHQrgKTRKuUNntUzSxdjLVFDaK(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				FBRamjBOwQEdjafxgqjYowTCxCfcD.qqVlANPKfhQEENrgXylRygaPEIO(P_1);
			}
			else if ((uint)P_0 < (uint)kLtKHYOKyHabTdaYNJSDSbiURQrCA)
			{
				PutGmXieYNKiRgXraGCvGQiauhqV[P_0].qqVlANPKfhQEENrgXylRygaPEIO(P_1);
			}
		}
	}

	public void HdlHQrgKTRKuUNntUzSxdjLVFDaK(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				FBRamjBOwQEdjafxgqjYowTCxCfcD.qqVlANPKfhQEENrgXylRygaPEIO(P_1, P_2);
			}
			else if ((uint)P_0 < (uint)kLtKHYOKyHabTdaYNJSDSbiURQrCA)
			{
				PutGmXieYNKiRgXraGCvGQiauhqV[P_0].qqVlANPKfhQEENrgXylRygaPEIO(P_1, P_2);
			}
		}
	}

	public void uVdGGwwgzyMStSFKWTNiNKHqwfHD(int P_0)
	{
		if (P_0 == 9999999)
		{
			FBRamjBOwQEdjafxgqjYowTCxCfcD.wJjPIIRJfHhEbGedUconecGfiwzgB();
		}
		else if ((uint)P_0 < (uint)kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			PutGmXieYNKiRgXraGCvGQiauhqV[P_0].wJjPIIRJfHhEbGedUconecGfiwzgB();
		}
	}

	private void cTFyVBpGJQMWnEyXJxahMhGqKEqD()
	{
		if (TLwPAejERSfVDfKAiYQPIMRYCwUg.HUGETXLaMQOfZWTXzbkOahiCPYfA > 0)
		{
			TLwPAejERSfVDfKAiYQPIMRYCwUg.CFdBIxelCLAPBBOddBADhJrRLZWib(-1, XGXtEHrvpvOZguxwYxxfpdPmfXDv(), XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Joystick), XGXtEHrvpvOZguxwYxxfpdPmfXDv(ControllerType.Custom));
		}
		if (FBRamjBOwQEdjafxgqjYowTCxCfcD.HUGETXLaMQOfZWTXzbkOahiCPYfA > 0)
		{
			Player.ControllerHelper controllers = LmvhkTCrnWKGfgMggYILVjKvuRWf.POqlaIweLUrFjDIOnEPRqRFLSGgs().controllers;
			FBRamjBOwQEdjafxgqjYowTCxCfcD.CFdBIxelCLAPBBOddBADhJrRLZWib(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < kLtKHYOKyHabTdaYNJSDSbiURQrCA; i++)
		{
			if (PutGmXieYNKiRgXraGCvGQiauhqV[i].HUGETXLaMQOfZWTXzbkOahiCPYfA != 0)
			{
				Player.ControllerHelper controllers2 = LmvhkTCrnWKGfgMggYILVjKvuRWf.lHbfkpyWIowAIkuHlIjyOnmSjjyP[i].controllers;
				PutGmXieYNKiRgXraGCvGQiauhqV[i].CFdBIxelCLAPBBOddBADhJrRLZWib(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	public void JHJrjaTuTPIAogiDzwUgNKpOouie(ThrottleCalibrationMode P_0)
	{
		for (int i = 0; i < iDZyvUlNOIxTktdkqatGasLcxZRL.Count; i++)
		{
			if (iDZyvUlNOIxTktdkqatGasLcxZRL[i] != null)
			{
				JHJrjaTuTPIAogiDzwUgNKpOouie(iDZyvUlNOIxTktdkqatGasLcxZRL[i], P_0);
			}
		}
		for (int j = 0; j < ZcxjGpfaFuISfLJABlODzoPvhCCU.Count; j++)
		{
			if (ZcxjGpfaFuISfLJABlODzoPvhCCU[j] != null)
			{
				JHJrjaTuTPIAogiDzwUgNKpOouie(ZcxjGpfaFuISfLJABlODzoPvhCCU[j], P_0);
			}
		}
		for (int k = 0; k < wBbxrMLeCcnzzcTBhwMHzHnZVhfg; k++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[k] != null)
			{
				JHJrjaTuTPIAogiDzwUgNKpOouie(PfiuLhoSFPKXbIhGTBbdTzJWQpgI[k], P_0);
			}
		}
		JHJrjaTuTPIAogiDzwUgNKpOouie(THVedgpUrWBoBPyOJDjeuRVtdWvh, P_0);
	}

	private void JHJrjaTuTPIAogiDzwUgNKpOouie(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		for (int i = 0; i < P_0.axisCount; i++)
		{
			if (axes[i].wzuKsMAQzNUDQMPTfMKsvinBDhokA._specialAxisType == SpecialAxisType.Throttle)
			{
				P_0.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
			}
		}
	}

	public IList<_0001> QrDUPafwVxtEzHrVlDyAXKiCvaOt<_0001>() where _0001 : IControllerTemplate
	{
		return WKPQYqlNclnKBgRtFDmKjqOuBDsSA.EThRTrEQTiAbwrmxuQKaeHxocOdfA<_0001>();
	}

	private void TlzckGoQDITHcUYaslQXPQBOhTwq(List<InputBehavior> P_0)
	{
		oLBbvsaIpIbSBPWdHzABkcRnEFqPA = ReInput.oLBbvsaIpIbSBPWdHzABkcRnEFqPA;
		LmvhkTCrnWKGfgMggYILVjKvuRWf = ReInput.LmvhkTCrnWKGfgMggYILVjKvuRWf;
		iDZyvUlNOIxTktdkqatGasLcxZRL = new List<Joystick>();
		ZcxjGpfaFuISfLJABlODzoPvhCCU = new List<Joystick>();
		PfiuLhoSFPKXbIhGTBbdTzJWQpgI = new List<CustomController>();
		AYaeikGbAWJSxAusdDGtShFwSvkHb = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.AYaeikGbAWJSxAusdDGtShFwSvkHb;
		kLtKHYOKyHabTdaYNJSDSbiURQrCA = LmvhkTCrnWKGfgMggYILVjKvuRWf.kLtKHYOKyHabTdaYNJSDSbiURQrCA;
		BGhAkVGbNyPkvrcCFFjRrIqhhdYDb = OSQEsqnIDSKMuQVHpIulCsZpEgeF;
		oJHQiUiGvtqBzBOwrMBtQqqajTcI = 0;
		TaFGHJHXxbAodvESaAxHunsLfxiB = new ADictionary<int, LXxoPXXaQwfqMprlPFDIPESeBXiV>();
		TaFGHJHXxbAodvESaAxHunsLfxiB.Add(ReInput.players.GetSystemPlayer().id, new LXxoPXXaQwfqMprlPFDIPESeBXiV(P_0));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			TaFGHJHXxbAodvESaAxHunsLfxiB.Add(players[i].id, new LXxoPXXaQwfqMprlPFDIPESeBXiV(P_0));
		}
		eMJMtZmZFEFzeqMCGkpamcAksTYy = new ReadOnlyCollection<Joystick>(iDZyvUlNOIxTktdkqatGasLcxZRL);
		eDAcHhiAMTDmYyUtDfFSMYtpbufb = new ReadOnlyCollection<CustomController>(PfiuLhoSFPKXbIhGTBbdTzJWQpgI);
		oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.wSEPYoBuPPNuBtirLLSxHUCdGzoE(DMXabkqQUJPnibCwPIPncbvzMVgD);
		GYjdwIKHHJkqkXvAcUrlbSgKIwsF = new oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[(kLtKHYOKyHabTdaYNJSDSbiURQrCA + 1) * AYaeikGbAWJSxAusdDGtShFwSvkHb];
		int num = 0;
		ZkcANfmqIgMoqnwbEtMyprtXsIUB = new oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[AYaeikGbAWJSxAusdDGtShFwSvkHb];
		for (int j = 0; j < AYaeikGbAWJSxAusdDGtShFwSvkHb; j++)
		{
			InputAction inputAction = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.StmVcaqiZXHRSPDLwwObvLYPgxbr(j);
			InputBehavior inputBehavior = TaFGHJHXxbAodvESaAxHunsLfxiB[9999999].HQYwOeYdSBGzNDEfGZWGRsPuenav(inputAction.behaviorId);
			oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = new oQRCFcJpUjLqOkwwnIxnfTMKhLJWA(9999999, inputAction, inputBehavior, DMXabkqQUJPnibCwPIPncbvzMVgD);
			ZkcANfmqIgMoqnwbEtMyprtXsIUB[j] = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2;
			GYjdwIKHHJkqkXvAcUrlbSgKIwsF[num] = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2;
			num++;
		}
		oHdAGAfLdgJSnEKYvsqllEINzSFkA = new oQRCFcJpUjLqOkwwnIxnfTMKhLJWA[kLtKHYOKyHabTdaYNJSDSbiURQrCA, AYaeikGbAWJSxAusdDGtShFwSvkHb];
		for (int k = 0; k < kLtKHYOKyHabTdaYNJSDSbiURQrCA; k++)
		{
			for (int l = 0; l < AYaeikGbAWJSxAusdDGtShFwSvkHb; l++)
			{
				InputAction inputAction2 = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.StmVcaqiZXHRSPDLwwObvLYPgxbr(l);
				InputBehavior inputBehavior2 = TaFGHJHXxbAodvESaAxHunsLfxiB[players[k].id].HQYwOeYdSBGzNDEfGZWGRsPuenav(inputAction2.behaviorId);
				oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3 = new oQRCFcJpUjLqOkwwnIxnfTMKhLJWA(k, inputAction2, inputBehavior2, DMXabkqQUJPnibCwPIPncbvzMVgD);
				oHdAGAfLdgJSnEKYvsqllEINzSFkA[k, l] = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3;
				GYjdwIKHHJkqkXvAcUrlbSgKIwsF[num] = oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.yhcwtnieSsbrJKctPqNEcbZsdLgXA;
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
				CustomController customController = REFjFzjqVfBzOqUbhgBnBtJFDRDQb(startingCustomControllers[n].sourceId);
				if (customController != null)
				{
					customController.tag = startingCustomControllers[n].tag;
					int num2 = ((m == 0) ? 9999999 : (m - 1));
					LmvhkTCrnWKGfgMggYILVjKvuRWf.GMfdPhKaTGGvREtYKUxukZZFdgrwA(num2)?.controllers.UkDCStQxuTTzKRfUCpNqHNkmXkEG(customController, false);
				}
			}
		}
		iTnpLgOxUPIEnqEUuPgFxbyweatGA = new QqVvPboyrQKVDvvGWuoTtoXflELE();
		hErdhrwDhOcQhdLnUuIfxxymPogZ = new QqVvPboyrQKVDvvGWuoTtoXflELE[kLtKHYOKyHabTdaYNJSDSbiURQrCA];
		for (int num3 = 0; num3 < kLtKHYOKyHabTdaYNJSDSbiURQrCA; num3++)
		{
			hErdhrwDhOcQhdLnUuIfxxymPogZ[num3] = new QqVvPboyrQKVDvvGWuoTtoXflELE();
		}
		TLwPAejERSfVDfKAiYQPIMRYCwUg = new qMqSqeRRfNPTXXedAQnRuVTbClCw<ActiveControllerChangedDelegate>();
		FBRamjBOwQEdjafxgqjYowTCxCfcD = new qMqSqeRRfNPTXXedAQnRuVTbClCw<PlayerActiveControllerChangedDelegate>();
		PutGmXieYNKiRgXraGCvGQiauhqV = new qMqSqeRRfNPTXXedAQnRuVTbClCw<PlayerActiveControllerChangedDelegate>[LmvhkTCrnWKGfgMggYILVjKvuRWf.kLtKHYOKyHabTdaYNJSDSbiURQrCA];
		ArrayTools.Populate(PutGmXieYNKiRgXraGCvGQiauhqV);
	}

	private void PKJRuCXeFVbzXoijHEWniJCFiKUlA(UpdateLoopType P_0)
	{
		int count = iDZyvUlNOIxTktdkqatGasLcxZRL.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = iDZyvUlNOIxTktdkqatGasLcxZRL[i];
			if (joystick.enabled)
			{
				NVtJcRSprxSkhLZoNdAjoqGEJZdi(joystick.LxOFdbFfzMSZsGHKiEkdFHVjeyWVB, joystick.fcpRkkeLOqieJylVwWSUEEJhOXpJ);
				joystick.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			}
		}
		if (srFBkeklMLkzixCmDIziDiekVvFLc.enabled)
		{
			srFBkeklMLkzixCmDIziDiekVvFLc.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
		}
		else if (WBshyHSrEYgqcTwjPvVfrvvhUmXF)
		{
			srFBkeklMLkzixCmDIziDiekVvFLc.fJNKoWgTsiTKBYlvYSrPTkQDMyXC(P_0);
		}
		if (THVedgpUrWBoBPyOJDjeuRVtdWvh.enabled)
		{
			THVedgpUrWBoBPyOJDjeuRVtdWvh.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
		}
		int count2 = PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = PfiuLhoSFPKXbIhGTBbdTzJWQpgI[j];
			if (customController.enabled)
			{
				customController.TTmlLbNbxWaHEgWSRqkIYAtJGFFkA();
				customController.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			}
		}
	}

	private void esQVFcDfFLQAFeYdbLipgyfQoAKi(UpdateLoopType P_0)
	{
		oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.jDjOtwSFCdaYNqJDbUOtnOrNCVbCA(P_0);
		Player[] array = LmvhkTCrnWKGfgMggYILVjKvuRWf.fxZfvknkcbAODIobmbPnsRZAgxtg;
		int num = array.Length;
		bool enabled = srFBkeklMLkzixCmDIziDiekVvFLc.enabled;
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
						DIlympNEUqGsUcKNxjoYXioqIqBNA.hkRySjxCMKJHCrFpoPCVPoucjAGQ(maps[j]);
					}
				}
			}
		}
		bool enabled2 = THVedgpUrWBoBPyOJDjeuRVtdWvh.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.wBRIUXiElXioypFpFtqzzuddeLqv(BGhAkVGbNyPkvrcCFFjRrIqhhdYDb);
			if (enabled || WBshyHSrEYgqcTwjPvVfrvvhUmXF)
			{
				controllers.HumsPpwGPmDwPqsPrVFAUXEKJiYK(srFBkeklMLkzixCmDIziDiekVvFLc, DIlympNEUqGsUcKNxjoYXioqIqBNA, BGhAkVGbNyPkvrcCFFjRrIqhhdYDb);
			}
			if (enabled2)
			{
				controllers.SXUBxgwfTURelJBIWZLOBaLGIqKC(THVedgpUrWBoBPyOJDjeuRVtdWvh, BGhAkVGbNyPkvrcCFFjRrIqhhdYDb);
			}
			controllers.caETbsyyCqXguvCilhhJafEbFVkb(BGhAkVGbNyPkvrcCFFjRrIqhhdYDb);
		}
		for (int l = 0; l < GYjdwIKHHJkqkXvAcUrlbSgKIwsF.Length; l++)
		{
			if (GYjdwIKHHJkqkXvAcUrlbSgKIwsF[l].WSiFyknCdwoDKykAQqkPoTQWXuRD != oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.ZuKhsEteQVAOQJXBtcLouEmkCsnV.Disabled)
			{
				GYjdwIKHHJkqkXvAcUrlbSgKIwsF[l].eqybETITBcMQKdKzkksDkJBfQhKUd();
			}
		}
		oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.gVAoqpVluqlYjWCGXHQydDnUNDVrA();
		if (!FWIoLKHqHscanYzwXIEcScSmxlVN)
		{
			return;
		}
		if (iTnpLgOxUPIEnqEUuPgFxbyweatGA.bsAehNdEpnVKupYvQvQtJltgYgtLA > 0)
		{
			for (int m = 0; m < AYaeikGbAWJSxAusdDGtShFwSvkHb; m++)
			{
				oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2 = ZkcANfmqIgMoqnwbEtMyprtXsIUB[m];
				if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2.WSiFyknCdwoDKykAQqkPoTQWXuRD != oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.ZuKhsEteQVAOQJXBtcLouEmkCsnV.Disabled)
				{
					iTnpLgOxUPIEnqEUuPgFxbyweatGA.WzfEHiRbIfIOuCEwgAnvNCmNMKFbA(oQRCFcJpUjLqOkwwnIxnfTMKhLJWA2, P_0);
				}
			}
		}
		for (int n = 0; n < kLtKHYOKyHabTdaYNJSDSbiURQrCA; n++)
		{
			QqVvPboyrQKVDvvGWuoTtoXflELE qqVvPboyrQKVDvvGWuoTtoXflELE = hErdhrwDhOcQhdLnUuIfxxymPogZ[n];
			if (qqVvPboyrQKVDvvGWuoTtoXflELE.bsAehNdEpnVKupYvQvQtJltgYgtLA == 0)
			{
				continue;
			}
			for (int num2 = 0; num2 < AYaeikGbAWJSxAusdDGtShFwSvkHb; num2++)
			{
				oQRCFcJpUjLqOkwwnIxnfTMKhLJWA oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3 = oHdAGAfLdgJSnEKYvsqllEINzSFkA[n, num2];
				if (oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3.WSiFyknCdwoDKykAQqkPoTQWXuRD != oQRCFcJpUjLqOkwwnIxnfTMKhLJWA.ZuKhsEteQVAOQJXBtcLouEmkCsnV.Disabled)
				{
					qqVvPboyrQKVDvvGWuoTtoXflELE.WzfEHiRbIfIOuCEwgAnvNCmNMKFbA(oQRCFcJpUjLqOkwwnIxnfTMKhLJWA3, P_0);
				}
			}
		}
	}

	private void OSQEsqnIDSKMuQVHpIulCsZpEgeF(bool P_0, int P_1, int P_2)
	{
		int num = oLBbvsaIpIbSBPWdHzABkcRnEFqPA.PujFpIgnaejxCcbCzrcoRIpZaecab(P_2);
		if (num >= 0)
		{
			if (P_1 == 9999999)
			{
				ZkcANfmqIgMoqnwbEtMyprtXsIUB[num].jKcbLNkGNrgEzVrPJSKKVStZUFOZ(P_0);
			}
			else
			{
				oHdAGAfLdgJSnEKYvsqllEINzSFkA[P_1, num].jKcbLNkGNrgEzVrPJSKKVStZUFOZ(P_0);
			}
		}
	}

	private void fbLNhEBlSWrcKvHrnqtzvCOvBMdh(BridgedController P_0)
	{
		int num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0.sourceJoystick.rewiredId, IYbNebxPqSEkIPoKSOrooynWnKqH.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = TwgunmnyKeVEjSpcyZODwqvafMkF(P_0.sourceJoystick.rewiredId, IYbNebxPqSEkIPoKSOrooynWnKqH.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = ZcxjGpfaFuISfLJABlODzoPvhCCU[num];
			ZcxjGpfaFuISfLJABlODzoPvhCCU.RemoveAt(num);
			joystick.oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(P_0);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(P_0);
		}
		iDZyvUlNOIxTktdkqatGasLcxZRL.Add(joystick);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Add(joystick);
		iDZyvUlNOIxTktdkqatGasLcxZRL.Sort(Joystick.tokKHgLQblWASmEMXrniBxPYzYjd);
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(joystick);
	}

	private void yWIkOUkJtijgeeoctYLltqhxeKIP(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (P_0 >= iDZyvUlNOIxTktdkqatGasLcxZRL.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = iDZyvUlNOIxTktdkqatGasLcxZRL[P_0];
		joystick.isConnected = false;
		if (UfevDfxCqyFDBiJoCdUExUjWZFQwA != null)
		{
			UfevDfxCqyFDBiJoCdUExUjWZFQwA(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (XZYnZqzMUswxdtbrMJFVLsBzXPpL != null)
		{
			XZYnZqzMUswxdtbrMJFVLsBzXPpL(joystick.type, joystick.id);
		}
		iDZyvUlNOIxTktdkqatGasLcxZRL.RemoveAt(P_0);
		ZcxjGpfaFuISfLJABlODzoPvhCCU.Add(joystick);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Remove(joystick);
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(joystick);
		joystick.wJjPIIRJfHhEbGedUconecGfiwzgB();
	}

	private void PZGzqdLweQSZYDNJOrCJeHwLohCe()
	{
		for (int num = iDZyvUlNOIxTktdkqatGasLcxZRL.Count - 1; num >= 0; num--)
		{
			yWIkOUkJtijgeeoctYLltqhxeKIP(num);
		}
	}

	private bool UkDCStQxuTTzKRfUCpNqHNkmXkEG(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count; i++)
		{
			if (PfiuLhoSFPKXbIhGTBbdTzJWQpgI[i] == P_0)
			{
				return true;
			}
		}
		PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Add(P_0);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Add(P_0);
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.GXYfOFJtEarnZyYbwQfGKoAqjIOO(P_0);
		return true;
	}

	private bool YpPprTyCjXINuDdRSIPPjCHwrQiRA(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		WKPQYqlNclnKBgRtFDmKjqOuBDsSA.zaBdfgpdaOdEOaceIWYVHDxywmNx(P_0);
		JoPfFIxqeMqEHpCPvbTUSObrwtgC.Remove(P_0);
		return PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Remove(P_0);
	}

	private QqVvPboyrQKVDvvGWuoTtoXflELE bNxWAwnIoatFItyoDhgEaMsrDrdp(int P_0)
	{
		if (P_0 == 9999999)
		{
			return iTnpLgOxUPIEnqEUuPgFxbyweatGA;
		}
		if (P_0 < 0 || P_0 >= ReInput.LmvhkTCrnWKGfgMggYILVjKvuRWf.kLtKHYOKyHabTdaYNJSDSbiURQrCA)
		{
			return null;
		}
		return hErdhrwDhOcQhdLnUuIfxxymPogZ[P_0];
	}

	private void ghuvqIdfASgEYNmKFDVdHxVJdCdH(bool P_0)
	{
		if (!P_0)
		{
			DIlympNEUqGsUcKNxjoYXioqIqBNA.jOzDnUFgdpxtcCytponbUMtjonO();
		}
	}

	private void LkQTpFBeyUXMAddalyNJQqSBAfDB(bool P_0)
	{
		srFBkeklMLkzixCmDIziDiekVvFLc.LkQTpFBeyUXMAddalyNJQqSBAfDB(P_0);
		THVedgpUrWBoBPyOJDjeuRVtdWvh.LkQTpFBeyUXMAddalyNJQqSBAfDB(P_0);
		for (int i = 0; i < iDZyvUlNOIxTktdkqatGasLcxZRL.Count; i++)
		{
			iDZyvUlNOIxTktdkqatGasLcxZRL[i].LkQTpFBeyUXMAddalyNJQqSBAfDB(P_0);
		}
		for (int j = 0; j < PfiuLhoSFPKXbIhGTBbdTzJWQpgI.Count; j++)
		{
			PfiuLhoSFPKXbIhGTBbdTzJWQpgI[j].LkQTpFBeyUXMAddalyNJQqSBAfDB(P_0);
		}
	}

	public void Dispose()
	{
		IqfGwssNeOuHmhjiKHsCvtuZOnrU(true);
		GC.SuppressFinalize(this);
	}

	protected void ANNKHugeDGzbmYmFyhvbuPpYVvpn()
	{
		try
		{
			IqfGwssNeOuHmhjiKHsCvtuZOnrU(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void IqfGwssNeOuHmhjiKHsCvtuZOnrU(bool P_0)
	{
		if (wFtxnVROnubhehGUBaPWAtQsiPAD)
		{
			return;
		}
		if (P_0)
		{
			if (XGGieMPbYXXpMqQXBjjgLtOuoacv is IDisposable)
			{
				(XGGieMPbYXXpMqQXBjjgLtOuoacv as IDisposable).Dispose();
			}
			if (egzoIoWzVRBgCrBiGZKLLDNYcPGg is IDisposable)
			{
				(egzoIoWzVRBgCrBiGZKLLDNYcPGg as IDisposable).Dispose();
			}
		}
		wFtxnVROnubhehGUBaPWAtQsiPAD = true;
	}
}
