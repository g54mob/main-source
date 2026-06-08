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

internal sealed class IEFDteeOKlelVDYGidTLyloAfeYs : IDisposable
{
	public enum jzNdcCxegIibzZgLQVureOMBAWA
	{
		CjmYXcdCBXiHQDcAZjTOavgjOlNM = 0,
		rnhzNdsbKFAFzIutEGSzJlLtLIdQ = 1
	}

	private class fjiypClzXjxyicfzTrljpXKAlJV
	{
		public ADictionary<int, InputBehavior> ZXmCvDfLDDrtmgBgFDRMaBCKoyr;

		public List<InputBehavior> lHkKGuRVUujSXfGbWAKucaVOVCTV;

		public IList<InputBehavior> qPxVGoLvcNcvOyKfPLdoFLJokgv;

		public fjiypClzXjxyicfzTrljpXKAlJV(List<InputBehavior> behaviors)
		{
			lHkKGuRVUujSXfGbWAKucaVOVCTV = new List<InputBehavior>(behaviors.Count);
			ZXmCvDfLDDrtmgBgFDRMaBCKoyr = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < behaviors.Count; i++)
			{
				InputBehavior inputBehavior = behaviors[i].Clone();
				ZXmCvDfLDDrtmgBgFDRMaBCKoyr.Add(behaviors[i].id, inputBehavior);
				lHkKGuRVUujSXfGbWAKucaVOVCTV.Add(inputBehavior);
				num++;
			}
			qPxVGoLvcNcvOyKfPLdoFLJokgv = new ReadOnlyCollection<InputBehavior>(lHkKGuRVUujSXfGbWAKucaVOVCTV);
		}

		public InputBehavior CVXqNEOSFYRCujjZqAGoCXBHsWP(int P_0)
		{
			if (lHkKGuRVUujSXfGbWAKucaVOVCTV.Count == 0)
			{
				goto IL_000d;
			}
			InputBehavior value = default(InputBehavior);
			ZXmCvDfLDDrtmgBgFDRMaBCKoyr.TryGetValue(P_0, out value);
			int num = 1629673303;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x6122D755)
				{
				case 0:
					break;
				case 3:
					return null;
				case 2:
					if (value == null)
					{
						goto IL_004a;
					}
					return value;
				default:
					return lHkKGuRVUujSXfGbWAKucaVOVCTV[0];
				}
				break;
				IL_004a:
				num = 1629673300;
			}
			goto IL_000d;
			IL_000d:
			num = 1629673302;
			goto IL_0012;
		}
	}

	private sealed class oEZZFXKWOLBFagwflzltguBtfuQ : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController ubyTdixGSFKGaFQFZdQnpwgWIvJ;

		private int isaqVUvqwfWYqOUtovbpbCbxgPc;

		private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

		public IEFDteeOKlelVDYGidTLyloAfeYs syCPfFbHYMDOvEPjTnPLBqiOhsPv;

		public int RZpaGoURsrmvLHolzvbcAMOdjQy;

		public int CexEWqeCqHUiTkkgdoNiVZMYAHpU;

		public int cLwGXyQnAejaxSufAJotkbhWkaoY;

		public int WhgwdOUlEIMyBTjrFhGbNEbNklB;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			oEZZFXKWOLBFagwflzltguBtfuQ oEZZFXKWOLBFagwflzltguBtfuQ2;
			if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
				oEZZFXKWOLBFagwflzltguBtfuQ2 = this;
			}
			else
			{
				while (true)
				{
					oEZZFXKWOLBFagwflzltguBtfuQ2 = new oEZZFXKWOLBFagwflzltguBtfuQ(0);
					int num = -86445443;
					while (true)
					{
						switch (num ^ -86445443)
						{
						case 2:
							num = -86445442;
							continue;
						case 3:
							break;
						case 0:
							oEZZFXKWOLBFagwflzltguBtfuQ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
							num = -86445444;
							continue;
						default:
							goto end_IL_0049;
						}
						break;
					}
					continue;
					end_IL_0049:
					break;
				}
			}
			oEZZFXKWOLBFagwflzltguBtfuQ2.RZpaGoURsrmvLHolzvbcAMOdjQy = CexEWqeCqHUiTkkgdoNiVZMYAHpU;
			return oEZZFXKWOLBFagwflzltguBtfuQ2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int num;
			switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
			{
			default:
				num = 2124705848;
				goto IL_001a;
			case 0:
				goto IL_00a2;
			case 1:
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = 2124705850;
					goto IL_001a;
				}
				IL_001a:
				while (true)
				{
					switch (num ^ 0x7EA4703F)
					{
					case 4:
						break;
					case 2:
						cLwGXyQnAejaxSufAJotkbhWkaoY = syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
						WhgwdOUlEIMyBTjrFhGbNEbNklB = 0;
						num = 2124705849;
						continue;
					case 6:
						num = 2124705854;
						continue;
					case 7:
						num = 2124705852;
						continue;
					case 1:
						goto IL_0080;
					case 0:
						goto IL_00a2;
					case 8:
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV[WhgwdOUlEIMyBTjrFhGbNEbNklB].sourceControllerId == RZpaGoURsrmvLHolzvbcAMOdjQy)
						{
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV[WhgwdOUlEIMyBTjrFhGbNEbNklB];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						}
						goto case 5;
					case 5:
						WhgwdOUlEIMyBTjrFhGbNEbNklB++;
						num = 2124705854;
						continue;
					default:
						return false;
					}
					break;
					IL_0080:
					int num2;
					if (WhgwdOUlEIMyBTjrFhGbNEbNklB < cLwGXyQnAejaxSufAJotkbhWkaoY)
					{
						num = 2124705847;
						num2 = num;
					}
					else
					{
						num = 2124705852;
						num2 = num;
					}
				}
				goto default;
				IL_00a2:
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				num = 2124705853;
				goto IL_001a;
			}
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

		void IDisposable.Dispose()
		{
		}

		[DebuggerHidden]
		public oEZZFXKWOLBFagwflzltguBtfuQ(int _003C_003E1__state)
		{
			while (true)
			{
				int num = 1926759175;
				while (true)
				{
					switch (num ^ 0x72D80306)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 0:
						return;
					}
					break;
					IL_0024:
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
					num = 1926759174;
				}
			}
		}
	}

	private sealed class pskMqVsGKRCpPzGZGZpOPtBQjJA : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController ubyTdixGSFKGaFQFZdQnpwgWIvJ;

		private int isaqVUvqwfWYqOUtovbpbCbxgPc;

		private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

		public IEFDteeOKlelVDYGidTLyloAfeYs syCPfFbHYMDOvEPjTnPLBqiOhsPv;

		public string JVLDNyGwHUmytBYkmhDmirmDmexz;

		public string mroBMnpLwxbiAaSJwonEBCTLKqFQ;

		public int ArNoUtDCXqNywkmCYFVtIAzhrUD;

		public int hiVyGFBHBEUrTbjNbbkGOXgGryf;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			pskMqVsGKRCpPzGZGZpOPtBQjJA pskMqVsGKRCpPzGZGZpOPtBQjJA2;
			if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
				pskMqVsGKRCpPzGZGZpOPtBQjJA2 = this;
				goto IL_0025;
			}
			goto IL_0052;
			IL_002a:
			int num;
			while (true)
			{
				switch (num ^ -519371004)
				{
				case 2:
					break;
				case 3:
					num = -519371008;
					continue;
				case 0:
					goto IL_0052;
				case 1:
					pskMqVsGKRCpPzGZGZpOPtBQjJA2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -519371008;
					continue;
				default:
					pskMqVsGKRCpPzGZGZpOPtBQjJA2.JVLDNyGwHUmytBYkmhDmirmDmexz = mroBMnpLwxbiAaSJwonEBCTLKqFQ;
					return pskMqVsGKRCpPzGZGZpOPtBQjJA2;
				}
				break;
			}
			goto IL_0025;
			IL_0052:
			pskMqVsGKRCpPzGZGZpOPtBQjJA2 = new pskMqVsGKRCpPzGZGZpOPtBQjJA(0);
			num = -519371003;
			goto IL_002a;
			IL_0025:
			num = -519371001;
			goto IL_002a;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
			while (true)
			{
				int num2 = -1215702900;
				while (true)
				{
					switch (num2 ^ -1215702899)
					{
					case 3:
						break;
					case 1:
						switch (num)
						{
						default:
							num2 = -1215702903;
							continue;
						case 0:
							break;
						case 1:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							num2 = -1215702897;
							continue;
						}
						goto case 6;
					case 6:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num2 = -1215702902;
						continue;
					case 7:
						ArNoUtDCXqNywkmCYFVtIAzhrUD = syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
						hiVyGFBHBEUrTbjNbbkGOXgGryf = 0;
						num2 = -1215702899;
						continue;
					case 5:
						if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV[hiVyGFBHBEUrTbjNbbkGOXgGryf].tag.Equals(JVLDNyGwHUmytBYkmhDmirmDmexz, StringComparison.OrdinalIgnoreCase))
						{
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.EZflvLyfMEnIWwDonfZVCrLfDzV[hiVyGFBHBEUrTbjNbbkGOXgGryf];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						}
						goto case 2;
					case 2:
						hiVyGFBHBEUrTbjNbbkGOXgGryf++;
						num2 = -1215702899;
						continue;
					case 0:
					{
						int num3;
						if (hiVyGFBHBEUrTbjNbbkGOXgGryf < ArNoUtDCXqNywkmCYFVtIAzhrUD)
						{
							num2 = -1215702904;
							num3 = num2;
						}
						else
						{
							num2 = -1215702903;
							num3 = num2;
						}
						continue;
					}
					default:
						return false;
					}
					break;
				}
			}
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

		void IDisposable.Dispose()
		{
		}

		[DebuggerHidden]
		public pskMqVsGKRCpPzGZGZpOPtBQjJA(int _003C_003E1__state)
		{
			isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
			TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private List<Joystick> fWCliwnkNTDOHFCYEMfqdLBZkus;

	private List<Joystick> MvskRqvCtzrQOtaBjGjRwDGQrzs;

	private List<CustomController> EZflvLyfMEnIWwDonfZVCrLfDzV;

	private List<Controller> OKSwjlddjZcPuRKkVMhqRMQQFXV;

	private ReadOnlyCollection<Controller> WsAgliJPptXOrJsFjuhCZjUomfu;

	private Keyboard hkIjbGtLZQFWDsQGrYzEdMkoBQo;

	private Mouse QsKjzCdyrVeEepaejRwEtsXGCvQ;

	private ConfigVars MgGtJKaHLSyjHLoGfGQLvKxEfrJ;

	private juUkCOtINcePpkOEZitZVEIfgiwq[] VnuuOkMeAITOJtiiGCSTkakpTpN;

	private juUkCOtINcePpkOEZitZVEIfgiwq[] MSlCVrkKlxPxDZQWkkjqyGnqdVvA;

	private juUkCOtINcePpkOEZitZVEIfgiwq[,] xZciHuXCgzsxWmLyXliLNdWkenqe;

	private lEqIvUBoSMJpmdhdOxUZgvBhdmff GRinbNRIBfEZvcsfFmgmhhcJeDeZ;

	private RcSeSPqNxZpeyVpTsiApgswOCre hoctQAMMDSSlMKekCSwlcmkXBZM;

	private RcSeSPqNxZpeyVpTsiApgswOCre[] oaKsRFokNJlGdfFskYZNgyNhHFb;

	private global::tsjplABEcSjkmdpDoXtjUbHAmKnE<ActiveControllerChangedDelegate> WShAfCdbOHIKoXoeMBArAXRldrro;

	private global::tsjplABEcSjkmdpDoXtjUbHAmKnE<PlayerActiveControllerChangedDelegate> IKSpbTOFfNSGMVWDSAlcrGFKSlZ;

	private global::tsjplABEcSjkmdpDoXtjUbHAmKnE<PlayerActiveControllerChangedDelegate>[] YLmBxfdwRWpDwNGXWPILvBqBUYJS;

	private ADictionary<int, fjiypClzXjxyicfzTrljpXKAlJV> OnSBTbDyKqgnNJsyOlEFvIvyIMY;

	private readonly YMJTjGoZkTzBiaTeMxLHaYkKcGZ BgCxDGjbjyGhqKEBjduwAnAERoLD;

	private IList<Joystick> jTQvwbszYZHADMZsikvWjvMZqqr;

	private IList<CustomController> zsWdfjwIHDdiHaEgLfpnzDSQvAFk;

	private int GBieqLWkRjvhJZclMNZKVjCuhqW;

	private bool DQnwvjIBzLNvHhHKjrxTcxvEtjs;

	private bool KhXuOsPpGzJHMqbKjXYWPjUNHAg;

	private bool GfZgGXZMtDapQSXyPcAECrHpSQL;

	private IUnifiedKeyboardSource KDTHrwEDDYgItRGhlwfYIGOBBVNF;

	private IUnifiedMouseSource vmofcEAmkOcrbNOYuHJhWCJvTeh;

	private int jvGLYqeWwaPCWxbEVCSZXIyDAALJ;

	private GzivFFngdYeSyLbVIOLpLzJrrzu lUCgcEIquFfuykgBneGrfARQlcR;

	private aQEMIPEePyEmScvmvEQnOdVcwpE WhcqAfYYqNfRCEGkYApjWYGKVjr;

	private int lHodAmkQtMDSknGmlYIxpakpInYX;

	private int JGperUdlNDVxAScSttWLqbZvOIB;

	private Action<int, ControllerDataUpdater> WpkIllEBqoxBInpEvnLFrPOhsWM;

	private Action<bool, int, int> IYoilpdmEtqNOAPsfslhBMmUhCz;

	private Action<ControllerStatusChangedEventArgs> NpbRYFrtrrOckxCMaiUgeLntnqve;

	private Action<ControllerType, int> KETaXMnBLpNaEVVeuNtnGPwEcdW;

	private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

	public IList<Joystick> Joysticks_readOnly => jTQvwbszYZHADMZsikvWjvMZqqr;

	public List<Joystick> Joysticks_orig => fWCliwnkNTDOHFCYEMfqdLBZkus;

	public int joystickCount => fWCliwnkNTDOHFCYEMfqdLBZkus.Count;

	public Mouse Mouse => QsKjzCdyrVeEepaejRwEtsXGCvQ;

	public Keyboard Keyboard => hkIjbGtLZQFWDsQGrYzEdMkoBQo;

	public IList<CustomController> CustomControllers_readOnly => zsWdfjwIHDdiHaEgLfpnzDSQvAFk;

	public List<CustomController> CustomControllers_orig => EZflvLyfMEnIWwDonfZVCrLfDzV;

	public int customControllerCount => EZflvLyfMEnIWwDonfZVCrLfDzV.Count;

	public IList<Controller> Controllers => WsAgliJPptXOrJsFjuhCZjUomfu;

	public int controllerCount => OKSwjlddjZcPuRKkVMhqRMQQFXV.Count;

	private int nextCustomControllerId
	{
		get
		{
			int result = jvGLYqeWwaPCWxbEVCSZXIyDAALJ;
			jvGLYqeWwaPCWxbEVCSZXIyDAALJ++;
			if (jvGLYqeWwaPCWxbEVCSZXIyDAALJ >= int.MaxValue)
			{
				jvGLYqeWwaPCWxbEVCSZXIyDAALJ = 0;
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ControllerDisconnectStartedEvent
	{
		add
		{
			NpbRYFrtrrOckxCMaiUgeLntnqve = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(NpbRYFrtrrOckxCMaiUgeLntnqve, value);
		}
		remove
		{
			NpbRYFrtrrOckxCMaiUgeLntnqve = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(NpbRYFrtrrOckxCMaiUgeLntnqve, value);
		}
	}

	public event Action<ControllerType, int> JustBeforeControllerFullyDisconnectedEvent
	{
		add
		{
			KETaXMnBLpNaEVVeuNtnGPwEcdW = (Action<ControllerType, int>)Delegate.Combine(KETaXMnBLpNaEVVeuNtnGPwEcdW, value);
		}
		remove
		{
			KETaXMnBLpNaEVVeuNtnGPwEcdW = (Action<ControllerType, int>)Delegate.Remove(KETaXMnBLpNaEVVeuNtnGPwEcdW, value);
		}
	}

	public IEFDteeOKlelVDYGidTLyloAfeYs(ConfigVars configVars, PlatformInputManager inputManager)
	{
		MgGtJKaHLSyjHLoGfGQLvKxEfrJ = configVars;
		GBieqLWkRjvhJZclMNZKVjCuhqW = 0;
		DQnwvjIBzLNvHhHKjrxTcxvEtjs = UnityTools.isAndroidPlatform;
		OKSwjlddjZcPuRKkVMhqRMQQFXV = new List<Controller>(10);
		WsAgliJPptXOrJsFjuhCZjUomfu = new ReadOnlyCollection<Controller>(OKSwjlddjZcPuRKkVMhqRMQQFXV);
		IUnifiedKeyboardSource unifiedKeyboardSource = inputManager.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (KDTHrwEDDYgItRGhlwfYIGOBBVNF = new UnityUnifiedKeyboardSource());
		}
		hkIjbGtLZQFWDsQGrYzEdMkoBQo = new Keyboard("Keyboard", unifiedKeyboardSource);
		OKSwjlddjZcPuRKkVMhqRMQQFXV.Add(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
		IUnifiedMouseSource unifiedMouseSource = inputManager.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (vmofcEAmkOcrbNOYuHJhWCJvTeh = new UnityUnifiedMouseSource());
		}
		QsKjzCdyrVeEepaejRwEtsXGCvQ = new Mouse("Mouse", unifiedMouseSource);
		OKSwjlddjZcPuRKkVMhqRMQQFXV.Add(QsKjzCdyrVeEepaejRwEtsXGCvQ);
		GRinbNRIBfEZvcsfFmgmhhcJeDeZ = new lEqIvUBoSMJpmdhdOxUZgvBhdmff(configVars.updateLoop, hkIjbGtLZQFWDsQGrYzEdMkoBQo);
		hkIjbGtLZQFWDsQGrYzEdMkoBQo.EnabledStateChangedEvent += rMjiygzGVFDrzhLunXkROlXeGkG;
		hkIjbGtLZQFWDsQGrYzEdMkoBQo.enabled = !configVars.GetPlatformVar_disableKeyboard();
		TPMFcoEHIkgRwgYCZiOxPisuuhx.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
		BgCxDGjbjyGhqKEBjduwAnAERoLD = new YMJTjGoZkTzBiaTeMxLHaYkKcGZ(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		BgCxDGjbjyGhqKEBjduwAnAERoLD.BvPfHvHLNzqGeTIHCnrafZGRLbzd(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
		BgCxDGjbjyGhqKEBjduwAnAERoLD.BvPfHvHLNzqGeTIHCnrafZGRLbzd(QsKjzCdyrVeEepaejRwEtsXGCvQ);
		ReInput.ApplicationFocusChangedEvent += MmtcKTFjtpegfEXXVAshFJeAqfIR;
	}

	public void SdmfoteCDVoXNaSlWEvRMBbwmDy(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		WpkIllEBqoxBInpEvnLFrPOhsWM = P_0;
		while (true)
		{
			int num = 1982758237;
			while (true)
			{
				switch (num ^ 0x762E7D5C)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0025;
				case 2:
					return;
				}
				break;
				IL_0025:
				SdmfoteCDVoXNaSlWEvRMBbwmDy(P_1);
				num = 1982758238;
			}
		}
	}

	public void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
	{
		TPMFcoEHIkgRwgYCZiOxPisuuhx.MJKeyPzowNIhJJpcApIOHNnaGYC(P_0);
		if (hkIjbGtLZQFWDsQGrYzEdMkoBQo.enabled)
		{
			GRinbNRIBfEZvcsfFmgmhhcJeDeZ.GzCliicOSMFLMvKajLgvnmGSSrh(P_0);
			goto IL_001f;
		}
		goto IL_0041;
		IL_0041:
		YqOSpcBQAKIAuYTTxcIXbWWwglrp(P_0);
		niVIXEDcAExPiSZvVRxHbzndTyh(P_0);
		int num = 1254934534;
		goto IL_0024;
		IL_001f:
		num = 1254934532;
		goto IL_0024;
		IL_0024:
		while (true)
		{
			switch (num ^ 0x4ACCC805)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0041;
			case 3:
				TPMFcoEHIkgRwgYCZiOxPisuuhx.yMpzPEgRxuylucHrikwaTLDBNvx(P_0, ReInput.currentFrame);
				if (GfZgGXZMtDapQSXyPcAECrHpSQL)
				{
					rSABlrtdXFUfxybUfcvCiJlVJdN();
					num = 1254934533;
					continue;
				}
				return;
			case 0:
				return;
			}
			break;
		}
		goto IL_001f;
	}

	public juUkCOtINcePpkOEZitZVEIfgiwq hclDKzezyJcwtJoSXLrWuaySJmJS(int P_0, string P_1, bool P_2)
	{
		int num = lUCgcEIquFfuykgBneGrfARQlcR.KhufsiHazfkStoHkXbcGhTzBsNFW(P_1, P_2);
		while (true)
		{
			int num2 = -1590393235;
			while (true)
			{
				switch (num2 ^ -1590393236)
				{
				case 3:
					break;
				case 1:
					if (num < 0)
					{
						return null;
					}
					if (P_0 == 9999999)
					{
						num2 = -1590393236;
						continue;
					}
					if (P_0 >= 0)
					{
						if (P_0 >= lHodAmkQtMDSknGmlYIxpakpInYX)
						{
							num2 = -1590393234;
							continue;
						}
						return xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num];
					}
					goto default;
				case 0:
					return MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num];
				default:
					return null;
				}
				break;
			}
		}
	}

	public juUkCOtINcePpkOEZitZVEIfgiwq hclDKzezyJcwtJoSXLrWuaySJmJS(int P_0, int P_1, bool P_2)
	{
		int num = lUCgcEIquFfuykgBneGrfARQlcR.KhufsiHazfkStoHkXbcGhTzBsNFW(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num];
		}
		return xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num];
	}

	public void IRJFWJaOnDcODSfXHIEgWEnaWif(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0039;
		IL_0003:
		int num = -422566277;
		goto IL_0008;
		IL_0008:
		switch (num ^ -422566273)
		{
		case 2:
			break;
		case 1:
			goto IL_002d;
		case 0:
			goto IL_0039;
		case 5:
			goto IL_0049;
		case 4:
			return;
		default:
			goto IL_0086;
		}
		goto IL_0003;
		IL_0039:
		if (P_0.sourceJoystick == null)
		{
			return;
		}
		goto IL_0049;
		IL_0049:
		jzNdcCxegIibzZgLQVureOMBAWA jzNdcCxegIibzZgLQVureOMBAWA2 = jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM;
		int num2 = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0.sourceJoystick.rewiredId, jzNdcCxegIibzZgLQVureOMBAWA2);
		if (num2 < 0)
		{
			jzNdcCxegIibzZgLQVureOMBAWA2 = jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ;
			num2 = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0.sourceJoystick.rewiredId, jzNdcCxegIibzZgLQVureOMBAWA2);
			num = -422566274;
			goto IL_0008;
		}
		goto IL_002d;
		IL_002d:
		if (num2 < 0)
		{
			return;
		}
		goto IL_0086;
		IL_0086:
		Joystick joystick = ((jzNdcCxegIibzZgLQVureOMBAWA2 != jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM) ? (joystick = MvskRqvCtzrQOtaBjGjRwDGQrzs[num2]) : (joystick = fWCliwnkNTDOHFCYEMfqdLBZkus[num2]));
		joystick.UpdateControllerInfo(P_0);
	}

	public bool tnLDZgAASYLxkNVLJxbcOjNVEQv(int P_0, jzNdcCxegIibzZgLQVureOMBAWA P_1)
	{
		if (AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int AOhxOVnRebcHMuIuCTGlzvDPOHD(int P_0, jzNdcCxegIibzZgLQVureOMBAWA P_1)
	{
		int count = default(int);
		int num = default(int);
		if (P_1 == jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM)
		{
			count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
			num = 0;
			goto IL_0014;
		}
		goto IL_00d3;
		IL_00d3:
		int count2 = default(int);
		int num2;
		if (P_1 == jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ)
		{
			count2 = MvskRqvCtzrQOtaBjGjRwDGQrzs.Count;
			num2 = -1023634887;
			goto IL_0019;
		}
		goto IL_00ed;
		IL_0014:
		num2 = -1023634883;
		goto IL_0019;
		IL_0019:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -1023634882)
			{
			case 2:
				break;
			case 7:
				num3 = 0;
				num2 = -1023634885;
				continue;
			case 8:
				return num3;
			case 5:
				goto IL_0067;
			case 9:
				goto IL_007c;
			case 3:
				num2 = -1023634881;
				continue;
			case 0:
				goto IL_00a1;
			case 1:
				if (num >= count)
				{
					num2 = -1023634888;
					continue;
				}
				goto IL_00a1;
			case 4:
				goto IL_00d3;
			default:
				goto IL_00ed;
			}
			break;
			IL_00a1:
			if (fWCliwnkNTDOHFCYEMfqdLBZkus[num].id == P_0)
			{
				return num;
			}
			num++;
			num2 = -1023634881;
			continue;
			IL_007c:
			if (MvskRqvCtzrQOtaBjGjRwDGQrzs[num3].id != P_0)
			{
				num3++;
				num2 = -1023634885;
			}
			else
			{
				num2 = -1023634890;
			}
			continue;
			IL_0067:
			int num4;
			if (num3 >= count2)
			{
				num2 = -1023634888;
				num4 = num2;
			}
			else
			{
				num2 = -1023634889;
				num4 = num2;
			}
		}
		goto IL_0014;
		IL_00ed:
		return -1;
	}

	public int AOhxOVnRebcHMuIuCTGlzvDPOHD(Guid P_0, jzNdcCxegIibzZgLQVureOMBAWA P_1)
	{
		int count = default(int);
		int num = default(int);
		if (P_1 == jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM)
		{
			count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
			num = 0;
			goto IL_0011;
		}
		goto IL_004e;
		IL_0104:
		return -1;
		IL_0011:
		int num2 = 948757424;
		goto IL_0016;
		IL_0016:
		int num3 = default(int);
		int count2 = default(int);
		while (true)
		{
			switch (num2 ^ 0x388CE3B6)
			{
			case 8:
				break;
			case 5:
				goto IL_004e;
			case 9:
				goto IL_006a;
			case 7:
				num2 = 948757430;
				continue;
			case 2:
				goto IL_0086;
			case 1:
				return num;
			case 6:
				num2 = 948757439;
				continue;
			case 3:
				goto IL_00c3;
			case 4:
				goto IL_00ec;
			default:
				goto IL_0104;
			}
			break;
			IL_00ec:
			int num4;
			if (num3 < count2)
			{
				num2 = 948757429;
				num4 = num2;
			}
			else
			{
				num2 = 948757430;
				num4 = num2;
			}
			continue;
			IL_0086:
			if (fWCliwnkNTDOHFCYEMfqdLBZkus[num].deviceInstanceGuid == P_0)
			{
				num2 = 948757431;
				continue;
			}
			num++;
			num2 = 948757439;
			continue;
			IL_006a:
			int num5;
			if (num >= count)
			{
				num2 = 948757425;
				num5 = num2;
			}
			else
			{
				num2 = 948757428;
				num5 = num2;
			}
			continue;
			IL_00c3:
			if (MvskRqvCtzrQOtaBjGjRwDGQrzs[num3].deviceInstanceGuid == P_0)
			{
				return num3;
			}
			num3++;
			num2 = 948757426;
		}
		goto IL_0011;
		IL_004e:
		if (P_1 == jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ)
		{
			count2 = MvskRqvCtzrQOtaBjGjRwDGQrzs.Count;
			num3 = 0;
			num2 = 948757426;
			goto IL_0016;
		}
		goto IL_0104;
	}

	public bool zYjbsxhOkjBnDWxCedVsAaOdEYR(int P_0)
	{
		if (wgSiTgnyJhHfzOuHSDfLsEoqBDl(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int wgSiTgnyJhHfzOuHSDfLsEoqBDl(int P_0)
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 1347125838;
			while (true)
			{
				switch (num ^ 0x504B824F)
				{
				case 0:
					break;
				case 1:
					num2 = 0;
					num = 1347125837;
					continue;
				case 3:
					if (EZflvLyfMEnIWwDonfZVCrLfDzV[num2].id == P_0)
					{
						return num2;
					}
					num2++;
					num = 1347125837;
					continue;
				default:
					if (num2 >= count)
					{
						return -1;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	public int wgSiTgnyJhHfzOuHSDfLsEoqBDl(Guid P_0)
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -1296770400;
				num3 = num2;
			}
			else
			{
				num2 = -1296770397;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1296770399)
				{
				case 4:
					num2 = -1296770400;
					continue;
				case 3:
					break;
				case 0:
					return num;
				case 1:
					if (!(EZflvLyfMEnIWwDonfZVCrLfDzV[num].deviceInstanceGuid == P_0))
					{
						num++;
						num2 = -1296770398;
					}
					else
					{
						num2 = -1296770399;
					}
					continue;
				default:
					return -1;
				}
				break;
			}
		}
	}

	public void MJWeKyBbClPTNAqHSJTnvQCzNPib(BridgedController P_0)
	{
		oSICIgLhcTfMfZQZLgpVkdASkeG(P_0);
	}

	public void obzYfvJpmNnOeHtquiLiyGzGVCm(int P_0)
	{
		int num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM);
		doNCJmsSgzaLVJAOFXLXeifKQzla(num);
	}

	public int GqtHeLqyYUhXhHTyUCxQvvzbhJH()
	{
		return GBieqLWkRjvhJZclMNZKVjCuhqW++;
	}

	public IList<InputBehavior> SdbImvkWEfIudHcibMpfTKnAQlYO(int P_0)
	{
		if (!OnSBTbDyKqgnNJsyOlEFvIvyIMY.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return OnSBTbDyKqgnNJsyOlEFvIvyIMY[P_0].qPxVGoLvcNcvOyKfPLdoFLJokgv;
	}

	public InputBehavior TTAmgCjlFFXrThWPqNCvwWqLrMf(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return TTAmgCjlFFXrThWPqNCvwWqLrMf(P_0, inputBehaviorId);
	}

	public InputBehavior TTAmgCjlFFXrThWPqNCvwWqLrMf(int P_0, int P_1)
	{
		if (!OnSBTbDyKqgnNJsyOlEFvIvyIMY.ContainsKey(P_0))
		{
			goto IL_000e;
		}
		IList<InputBehavior> qPxVGoLvcNcvOyKfPLdoFLJokgv = OnSBTbDyKqgnNJsyOlEFvIvyIMY[P_0].qPxVGoLvcNcvOyKfPLdoFLJokgv;
		int num = 0;
		int num2 = 1290084169;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num2 ^ 0x4CE51F48)
			{
			case 0:
				break;
			case 2:
				return null;
			case 3:
				if (qPxVGoLvcNcvOyKfPLdoFLJokgv[num].id != P_1)
				{
					goto IL_0064;
				}
				return qPxVGoLvcNcvOyKfPLdoFLJokgv[num];
			default:
				if (num >= qPxVGoLvcNcvOyKfPLdoFLJokgv.Count)
				{
					return null;
				}
				goto case 3;
			}
			break;
			IL_0064:
			num++;
			num2 = 1290084169;
		}
		goto IL_000e;
		IL_000e:
		num2 = 1290084170;
		goto IL_0013;
	}

	public Joystick JCDhdBcaJPtIabIaCiOxBLwtJEKK(int P_0, bool P_1 = false)
	{
		int num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM);
		int num2;
		if (num < 0)
		{
			if (P_1)
			{
				num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ);
				if (num >= 0)
				{
					num2 = -18556095;
					goto IL_0012;
				}
			}
			return null;
		}
		goto IL_000d;
		IL_0012:
		switch (num2 ^ -18556095)
		{
		case 2:
			break;
		case 1:
			return fWCliwnkNTDOHFCYEMfqdLBZkus[num];
		default:
			return MvskRqvCtzrQOtaBjGjRwDGQrzs[num];
		}
		goto IL_000d;
		IL_000d:
		num2 = -18556096;
		goto IL_0012;
	}

	public Joystick JCDhdBcaJPtIabIaCiOxBLwtJEKK(Guid P_0, bool P_1 = false)
	{
		int num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM);
		if (num >= 0)
		{
			return fWCliwnkNTDOHFCYEMfqdLBZkus[num];
		}
		if (P_1)
		{
			num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0, jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ);
			if (num >= 0)
			{
				return MvskRqvCtzrQOtaBjGjRwDGQrzs[num];
			}
		}
		return null;
	}

	public Joystick[] ynWdqHhVsmcAWewMQEUmudUWEbPd()
	{
		int count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		int num2 = default(int);
		while (true)
		{
			int num = 716417878;
			while (true)
			{
				switch (num ^ 0x2AB3AB52)
				{
				case 0:
					break;
				case 4:
					num2 = 0;
					num = 716417873;
					continue;
				case 2:
					array[num2] = fWCliwnkNTDOHFCYEMfqdLBZkus[num2];
					num = 716417875;
					continue;
				case 1:
					num2++;
					num = 716417873;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public string[] LzprbeIUmpBuFpLzcWjsheSUqTc()
	{
		int count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
		string[] array = default(string[]);
		int num2 = default(int);
		while (true)
		{
			int num = 794085180;
			while (true)
			{
				switch (num ^ 0x2F54C73D)
				{
				case 3:
					break;
				case 1:
					if (count == 0)
					{
						return EmptyObjects<string>.array;
					}
					array = new string[count];
					num2 = 0;
					num = 794085181;
					continue;
				case 2:
					array[num2] = fWCliwnkNTDOHFCYEMfqdLBZkus[num2].name;
					num2++;
					num = 794085181;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public CustomController nmdAXHdbPyfIGxYnapMeXnMTymF(int P_0)
	{
		int num = wgSiTgnyJhHfzOuHSDfLsEoqBDl(P_0);
		if (num < 0)
		{
			return null;
		}
		return EZflvLyfMEnIWwDonfZVCrLfDzV[num];
	}

	public CustomController nmdAXHdbPyfIGxYnapMeXnMTymF(Guid P_0)
	{
		int num = wgSiTgnyJhHfzOuHSDfLsEoqBDl(P_0);
		if (num < 0)
		{
			return null;
		}
		return EZflvLyfMEnIWwDonfZVCrLfDzV[num];
	}

	public CustomController[] AeUBzTrNjCYIgsFwrvdurqXcrHG()
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				array[num] = EZflvLyfMEnIWwDonfZVCrLfDzV[num];
				int num2 = 2096372521;
				while (true)
				{
					switch (num2 ^ 0x7CF41B29)
					{
					case 3:
						num2 = 2096372520;
						continue;
					case 1:
						break;
					case 0:
						num++;
						num2 = 2096372523;
						continue;
					default:
						goto end_IL_0042;
					}
					break;
				}
				continue;
				end_IL_0042:
				break;
			}
		}
		return array;
	}

	public string[] YIUDaKDOYiYtfxTdvhBDLSkENBX()
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		int num2 = default(int);
		while (true)
		{
			int num = -2052598820;
			while (true)
			{
				switch (num ^ -2052598817)
				{
				case 0:
					break;
				case 3:
					num2 = 0;
					num = -2052598818;
					continue;
				case 2:
					array[num2] = EZflvLyfMEnIWwDonfZVCrLfDzV[num2].name;
					num2++;
					num = -2052598818;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public CustomController WhUGCBoKUaVEhcUVTTDVyELczky(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			goto IL_0012;
		}
		int uKCDHORBCFHBoYLTIFGoDfJwMEGs = nextCustomControllerId;
		gRkhIkZmWhiFsWWreyOyrrlNsjt gRkhIkZmWhiFsWWreyOyrrlNsjt2 = new gRkhIkZmWhiFsWWreyOyrrlNsjt();
		gRkhIkZmWhiFsWWreyOyrrlNsjt2.QhiXIzSBnzSGaWwDVddQlyhdvkF = InputSource.Custom;
		gRkhIkZmWhiFsWWreyOyrrlNsjt2.QRjtmXoRMaFOuRnBPiyKhJYUVUo = customControllerById.descriptiveName;
		gRkhIkZmWhiFsWWreyOyrrlNsjt2.eljtncJIlHPyIbsJcoSaVogBOjz = customControllerById.name;
		gRkhIkZmWhiFsWWreyOyrrlNsjt2.RGhWgMAfPjfICjXGWTZxnPoNdWD = customControllerById.axisCount;
		int num = 2067936437;
		goto IL_0017;
		IL_0017:
		CustomController customController = default(CustomController);
		while (true)
		{
			switch (num ^ 0x7B4234B1)
			{
			case 3:
				break;
			case 0:
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.tYAFBJEJtsymrXHTcEZPbTaOjI = customControllerById.id.ToString();
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.DsPKrmcvILysVaeTrBlwFLBsuFp = customControllerById.YucBUGhcNFqNsPLYijVdDVqvADJR();
				num = 2067936432;
				continue;
			case 4:
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.SeOhWaCQLSUYyhdokorrnPTrNGB = customControllerById.buttonCount;
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.UKCDHORBCFHBoYLTIFGoDfJwMEGs = uKCDHORBCFHBoYLTIFGoDfJwMEGs;
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.dMLvOHnSyvaMRsfCrfmGjKwFJVL = customControllerById.id;
				gRkhIkZmWhiFsWWreyOyrrlNsjt2.npTbYRtEOyhplyNZKAfaHlInTuqH = customControllerById.typeGuid;
				num = 2067936433;
				continue;
			case 1:
			{
				gRkhIkZmWhiFsWWreyOyrrlNsjt data = gRkhIkZmWhiFsWWreyOyrrlNsjt2;
				customController = new CustomController(data);
				VoEDDsKnWYkfZfofupKrQyuXgzI(customController);
				num = 2067936435;
				continue;
			}
			case 5:
				return null;
			default:
				return customController;
			}
			break;
		}
		goto IL_0012;
		IL_0012:
		num = 2067936436;
		goto IL_0017;
	}

	public bool SsbVARSFfeFqnyEkTXfEirtgsbK(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return DWWXsjaPmOBkVDVbcwVtOBPDVdXv(P_0);
	}

	public CustomController DsrZtBCOWkxAvxTTVlXGvEyPDHG(int P_0)
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				if (EZflvLyfMEnIWwDonfZVCrLfDzV[num].sourceControllerId == P_0)
				{
					return EZflvLyfMEnIWwDonfZVCrLfDzV[num];
				}
				num++;
				int num2 = -342316929;
				while (true)
				{
					switch (num2 ^ -342316930)
					{
					case 0:
						num2 = -342316932;
						continue;
					case 2:
						break;
					default:
						goto end_IL_002e;
					}
					break;
				}
				continue;
				end_IL_002e:
				break;
			}
		}
		return null;
	}

	public CustomController CQnLgttbpkMrBARmscALfVKSeAKr(string P_0)
	{
		int count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				if (EZflvLyfMEnIWwDonfZVCrLfDzV[num].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					num2 = 1378614177;
				}
				else
				{
					num++;
					num2 = 1378614178;
				}
				while (true)
				{
					switch (num2 ^ 0x522BFBA1)
					{
					case 2:
						num2 = 1378614176;
						continue;
					case 1:
						break;
					case 0:
						return EZflvLyfMEnIWwDonfZVCrLfDzV[num];
					default:
						goto end_IL_0032;
					}
					break;
				}
				continue;
				end_IL_0032:
				break;
			}
		}
		return null;
	}

	public IEnumerable<CustomController> XgxlKdOopPOhRpdeDRwQIAkcNjv(int P_0)
	{
		oEZZFXKWOLBFagwflzltguBtfuQ oEZZFXKWOLBFagwflzltguBtfuQ2 = new oEZZFXKWOLBFagwflzltguBtfuQ(-2);
		oEZZFXKWOLBFagwflzltguBtfuQ2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
		oEZZFXKWOLBFagwflzltguBtfuQ2.CexEWqeCqHUiTkkgdoNiVZMYAHpU = P_0;
		return oEZZFXKWOLBFagwflzltguBtfuQ2;
	}

	public IEnumerable<CustomController> zTENOlfKphGOkPVColUsEnmBBmR(string P_0)
	{
		pskMqVsGKRCpPzGZGZpOPtBQjJA pskMqVsGKRCpPzGZGZpOPtBQjJA2 = new pskMqVsGKRCpPzGZGZpOPtBQjJA(-2);
		pskMqVsGKRCpPzGZGZpOPtBQjJA2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
		pskMqVsGKRCpPzGZGZpOPtBQjJA2.mroBMnpLwxbiAaSJwonEBCTLKqFQ = P_0;
		return pskMqVsGKRCpPzGZGZpOPtBQjJA2;
	}

	public Controller lRKToUyChtEIyMHppndqwlmeZVh(ControllerType P_0, int P_1, bool P_2 = false)
	{
		while (true)
		{
			int num = -1276506621;
			while (true)
			{
				switch (num ^ -1276506624)
				{
				case 0:
					break;
				case 3:
					switch (P_0)
					{
					default:
						goto IL_003b;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return hkIjbGtLZQFWDsQGrYzEdMkoBQo;
					case ControllerType.Mouse:
						return QsKjzCdyrVeEepaejRwEtsXGCvQ;
					case ControllerType.Custom:
						return nmdAXHdbPyfIGxYnapMeXnMTymF(P_1);
					}
					goto default;
				default:
					return JCDhdBcaJPtIabIaCiOxBLwtJEKK(P_1, P_2);
				case 2:
					throw new NotImplementedException();
				}
				break;
				IL_003b:
				num = -1276506622;
			}
		}
	}

	public Controller lRKToUyChtEIyMHppndqwlmeZVh(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return lRKToUyChtEIyMHppndqwlmeZVh(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return lRKToUyChtEIyMHppndqwlmeZVh(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller lRKToUyChtEIyMHppndqwlmeZVh(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (hkIjbGtLZQFWDsQGrYzEdMkoBQo.deviceInstanceGuid == P_0)
		{
			return hkIjbGtLZQFWDsQGrYzEdMkoBQo;
		}
		if (QsKjzCdyrVeEepaejRwEtsXGCvQ.deviceInstanceGuid == P_0)
		{
			return QsKjzCdyrVeEepaejRwEtsXGCvQ;
		}
		Controller result;
		if ((result = JCDhdBcaJPtIabIaCiOxBLwtJEKK(P_0, P_1)) != null)
		{
			return result;
		}
		if ((result = nmdAXHdbPyfIGxYnapMeXnMTymF(P_0)) != null)
		{
			return result;
		}
		return null;
	}

	public Controller[] AxkkgCMCQqcIsfDohiuFmbZlGJKB(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return ynWdqHhVsmcAWewMQEUmudUWEbPd();
		case ControllerType.Keyboard:
			return new Controller[1] { hkIjbGtLZQFWDsQGrYzEdMkoBQo };
		case ControllerType.Mouse:
			return new Controller[1] { QsKjzCdyrVeEepaejRwEtsXGCvQ };
		case ControllerType.Custom:
			return AeUBzTrNjCYIgsFwrvdurqXcrHG();
		default:
			throw new NotImplementedException();
		}
	}

	public string[] rzxEheGawXeGHOFLrCKbhzzXRLzc(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return LzprbeIUmpBuFpLzcWjsheSUqTc();
		case ControllerType.Keyboard:
			return new string[1] { hkIjbGtLZQFWDsQGrYzEdMkoBQo.name };
		case ControllerType.Mouse:
			return new string[1] { QsKjzCdyrVeEepaejRwEtsXGCvQ.name };
		case ControllerType.Custom:
			return YIUDaKDOYiYtfxTdvhBDLSkENBX();
		default:
			throw new NotImplementedException();
		}
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			goto IL_0008;
		}
		goto IL_004d;
		IL_0008:
		int num = 791983697;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x2F34B653)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
				num = 791983696;
				continue;
			case 4:
				goto IL_003c;
			case 3:
				goto IL_004d;
			case 1:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_003c:
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = default(RcSeSPqNxZpeyVpTsiApgswOCre);
		rcSeSPqNxZpeyVpTsiApgswOCre.molwHYloiMfWCHJFERCRuvnmrARS(P_1, P_2, InputActionEventType.Update, null);
		num = 791983698;
		goto IL_000d;
		IL_004d:
		rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			return;
		}
		goto IL_003c;
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			goto IL_0008;
		}
		goto IL_003e;
		IL_0008:
		int num = 384439904;
		goto IL_000d;
		IL_000d:
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = default(RcSeSPqNxZpeyVpTsiApgswOCre);
		while (true)
		{
			switch (num ^ 0x16EA1661)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 5:
				goto IL_003e;
			case 6:
				rcSeSPqNxZpeyVpTsiApgswOCre.molwHYloiMfWCHJFERCRuvnmrARS(P_1, P_2, InputActionEventType.Update, P_3, null);
				num = 384439909;
				continue;
			case 3:
				goto IL_0060;
			case 1:
				KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
				num = 384439908;
				continue;
			case 4:
				return;
			}
			break;
			IL_0060:
			int num2;
			if (rcSeSPqNxZpeyVpTsiApgswOCre != null)
			{
				num = 384439911;
				num2 = num;
			}
			else
			{
				num = 384439907;
				num2 = num;
			}
		}
		goto IL_0008;
		IL_003e:
		rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		num = 384439906;
		goto IL_000d;
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
			goto IL_000f;
		}
		goto IL_0031;
		IL_0031:
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_3);
		int num2;
		int num3;
		if (num < 0)
		{
			num2 = -1706447026;
			num3 = num2;
		}
		else
		{
			num2 = -1706447025;
			num3 = num2;
		}
		goto IL_0014;
		IL_000f:
		num2 = -1706447027;
		goto IL_0014;
		IL_0014:
		switch (num2 ^ -1706447026)
		{
		case 2:
			break;
		case 3:
			goto IL_0031;
		case 0:
			return;
		default:
			OxTVBNgxzWpxVOCiqNgKtfbbCqp(P_0, P_1, P_2, num);
			return;
		}
		goto IL_000f;
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
			goto IL_000f;
		}
		goto IL_0031;
		IL_0031:
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		int num;
		int num2;
		if (rcSeSPqNxZpeyVpTsiApgswOCre != null)
		{
			num = 1797512938;
			num2 = num;
		}
		else
		{
			num = 1797512937;
			num2 = num;
		}
		goto IL_0014;
		IL_000f:
		num = 1797512936;
		goto IL_0014;
		IL_0014:
		switch (num ^ 0x6B23DEEB)
		{
		case 0:
			break;
		case 3:
			goto IL_0031;
		case 2:
			return;
		default:
			rcSeSPqNxZpeyVpTsiApgswOCre.molwHYloiMfWCHJFERCRuvnmrARS(P_1, P_2, P_3, P_4);
			return;
		}
		goto IL_000f;
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
			goto IL_000f;
		}
		goto IL_0039;
		IL_0039:
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		int num = -703113607;
		goto IL_0014;
		IL_000f:
		num = -703113601;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ -703113605)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				goto IL_0039;
			case 2:
				goto IL_0048;
			case 5:
				rcSeSPqNxZpeyVpTsiApgswOCre.molwHYloiMfWCHJFERCRuvnmrARS(P_1, P_2, P_3, P_4, P_5);
				num = -703113606;
				continue;
			case 3:
				return;
			case 1:
				return;
			}
			break;
			IL_0048:
			int num2;
			if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
			{
				num = -703113608;
				num2 = num;
			}
			else
			{
				num = -703113602;
				num2 = num;
			}
		}
		goto IL_000f;
	}

	public void OxTVBNgxzWpxVOCiqNgKtfbbCqp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
		{
			KhXuOsPpGzJHMqbKjXYWPjUNHAg = true;
			goto IL_000f;
		}
		goto IL_0056;
		IL_0056:
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_4);
		int num2 = -249085497;
		goto IL_0014;
		IL_000f:
		num2 = -249085504;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -249085500)
			{
			case 2:
				break;
			default:
				return;
			case 0:
				return;
			case 3:
				goto IL_0041;
			case 4:
				goto IL_0056;
			case 5:
				OxTVBNgxzWpxVOCiqNgKtfbbCqp(P_0, P_1, P_2, P_3, num, P_5);
				num2 = -249085499;
				continue;
			case 1:
				return;
			}
			break;
			IL_0041:
			int num3;
			if (num >= 0)
			{
				num2 = -249085503;
				num3 = num2;
			}
			else
			{
				num2 = -249085500;
				num3 = num2;
			}
		}
		goto IL_000f;
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			return;
		}
		while (true)
		{
			rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1);
			int num = -998063813;
			while (true)
			{
				switch (num ^ -998063814)
				{
				case 0:
					goto IL_000c;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_000c:
				num = -998063816;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		while (true)
		{
			int num = -369393154;
			while (true)
			{
				switch (num ^ -369393156)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (rcSeSPqNxZpeyVpTsiApgswOCre != null)
					{
						goto IL_0035;
					}
					return;
				case 1:
					goto IL_0035;
				case 3:
					return;
				}
				break;
				IL_0035:
				rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2);
				num = -369393153;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_2);
		if (num >= 0)
		{
			HxwwGTTLdGhliTDVpCXBghVWscHv(P_0, P_1, num);
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			while (true)
			{
				switch (-1354703474 ^ -1354703476)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2);
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		while (true)
		{
			int num = 1175343526;
			while (true)
			{
				switch (num ^ 0x460E51A4)
				{
				case 0:
					break;
				case 2:
				{
					int num2;
					if (rcSeSPqNxZpeyVpTsiApgswOCre != null)
					{
						num = 1175343525;
						num2 = num;
					}
					else
					{
						num = 1175343527;
						num2 = num;
					}
					continue;
				}
				case 3:
					return;
				default:
					rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2);
					return;
				}
				break;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		sxuQPWlavjokjLaCtVqmppwApUA(P_0)?.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2, P_3);
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_3);
		if (num < 0)
		{
			return;
		}
		while (true)
		{
			HxwwGTTLdGhliTDVpCXBghVWscHv(P_0, P_1, P_2, num);
			int num2 = 531179085;
			while (true)
			{
				switch (num2 ^ 0x1FA9264F)
				{
				case 0:
					goto IL_0013;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0013:
				num2 = 531179086;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			return;
		}
		while (true)
		{
			rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2, P_3);
			int num = 2097387338;
			while (true)
			{
				switch (num ^ 0x7D03974A)
				{
				case 2:
					goto IL_000c;
				default:
					return;
				case 1:
					break;
				case 0:
					return;
				}
				break;
				IL_000c:
				num = 2097387339;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_3);
		while (true)
		{
			int num2 = 701783996;
			while (true)
			{
				switch (num2 ^ 0x29D45FBD)
				{
				case 3:
					break;
				case 1:
				{
					int num3;
					if (num >= 0)
					{
						num2 = 701783999;
						num3 = num2;
					}
					else
					{
						num2 = 701783997;
						num3 = num2;
					}
					continue;
				}
				case 0:
					return;
				default:
					HxwwGTTLdGhliTDVpCXBghVWscHv(P_0, P_1, P_2, num);
					return;
				}
				break;
			}
		}
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		sxuQPWlavjokjLaCtVqmppwApUA(P_0)?.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2, P_3);
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			while (true)
			{
				switch (-210387177 ^ -210387178)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		rcSeSPqNxZpeyVpTsiApgswOCre.TsDqYOIbChtRedvmCnjKwRJSExZ(P_1, P_2, P_3, P_4);
	}

	public void HxwwGTTLdGhliTDVpCXBghVWscHv(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(P_4);
		if (num >= 0)
		{
			HxwwGTTLdGhliTDVpCXBghVWscHv(P_0, P_1, P_2, P_3, num);
		}
	}

	public void QHzwpTBMEmfRVVuaHzhEFFsIZjX(int P_0)
	{
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = sxuQPWlavjokjLaCtVqmppwApUA(P_0);
		if (rcSeSPqNxZpeyVpTsiApgswOCre == null)
		{
			return;
		}
		while (true)
		{
			rcSeSPqNxZpeyVpTsiApgswOCre.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			int num = 515900769;
			while (true)
			{
				switch (num ^ 0x1EC00563)
				{
				case 0:
					goto IL_000c;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_000c:
				num = 515900770;
			}
		}
	}

	public bool pfaqddHCNpxyDBsLVVxEYRBPTeV(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_006a;
		}
		int actionCount = default(int);
		int num2 = default(int);
		int num3;
		if (P_0 >= 0)
		{
			if (P_0 < lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num2 = 0;
				num3 = 1147628294;
			}
			else
			{
				num3 = 1147628293;
			}
			goto IL_0011;
		}
		goto IL_0053;
		IL_006a:
		if (num >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
		{
			return false;
		}
		goto IL_003d;
		IL_003d:
		if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].jFcZHuafkqlzijBvuFElJkopdfY())
		{
			num3 = 1147628288;
		}
		else
		{
			num++;
			num3 = 1147628295;
		}
		goto IL_0011;
		IL_0053:
		return false;
		IL_0011:
		while (true)
		{
			switch (num3 ^ 0x44676B05)
			{
			case 4:
				num3 = 1147628291;
				continue;
			case 6:
				break;
			case 0:
				goto IL_0053;
			case 2:
				goto IL_006a;
			case 5:
				return true;
			case 1:
				goto IL_009b;
			default:
				if (num2 >= actionCount)
				{
					return false;
				}
				goto IL_009b;
			}
			break;
			IL_009b:
			if (xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num2].jFcZHuafkqlzijBvuFElJkopdfY())
			{
				return true;
			}
			num2++;
			num3 = 1147628294;
		}
		goto IL_003d;
	}

	public bool htPnQmHXURAeJHyVMLdhgFSYtRi(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_000b;
		}
		int actionCount = default(int);
		int num = default(int);
		int num2;
		if (P_0 >= 0)
		{
			if (P_0 < lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num = 0;
				num2 = 193610738;
			}
			else
			{
				num2 = 193610736;
			}
			goto IL_0010;
		}
		goto IL_0044;
		IL_0010:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ 0xB8A43F5)
			{
			case 3:
				break;
			case 5:
				goto IL_0044;
			case 1:
				goto IL_005b;
			case 8:
				goto IL_0076;
			case 2:
				goto IL_0095;
			case 0:
				return true;
			case 4:
				return false;
			case 6:
				num3 = 0;
				num2 = 193610749;
				continue;
			default:
				if (num >= actionCount)
				{
					return false;
				}
				goto IL_005b;
			}
			break;
			IL_0095:
			if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num3].onTOiISwdiwnVPNqdGBZbNYGehbR())
			{
				return true;
			}
			num3++;
			num2 = 193610749;
			continue;
			IL_0076:
			int num4;
			if (num3 < MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
			{
				num2 = 193610743;
				num4 = num2;
			}
			else
			{
				num2 = 193610737;
				num4 = num2;
			}
			continue;
			IL_005b:
			if (xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num].onTOiISwdiwnVPNqdGBZbNYGehbR())
			{
				num2 = 193610741;
				continue;
			}
			num++;
			num2 = 193610738;
		}
		goto IL_000b;
		IL_000b:
		num2 = 193610739;
		goto IL_0010;
		IL_0044:
		return false;
	}

	public bool ihQnogTzNrLDGeCbhZgWbjqWrdu(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_0072;
		}
		int num2;
		int actionCount = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				num2 = -26322244;
			}
			else
			{
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num2 = -26322243;
			}
			goto IL_0011;
		}
		goto IL_00b5;
		IL_0072:
		if (num >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
		{
			return false;
		}
		goto IL_0096;
		IL_0096:
		if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].QNRTkSkGFuwIIacWXFtSgclWddbW())
		{
			return true;
		}
		num++;
		num2 = -26322245;
		goto IL_0011;
		IL_0011:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -26322243)
			{
			case 4:
				num2 = -26322241;
				continue;
			case 7:
				return true;
			case 0:
				num3 = 0;
				num2 = -26322248;
				continue;
			case 3:
				break;
			case 6:
				goto end_IL_0011;
			case 2:
				goto IL_0096;
			case 1:
				goto IL_00b5;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				break;
			}
			if (!xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num3].QNRTkSkGFuwIIacWXFtSgclWddbW())
			{
				num3++;
				num2 = -26322248;
			}
			else
			{
				num2 = -26322246;
			}
			continue;
			end_IL_0011:
			break;
		}
		goto IL_0072;
		IL_00b5:
		return false;
	}

	public bool bDpLbAryWtSDjytRMlfAKaqMqdi(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_000a;
		}
		int num2;
		int num3;
		if (P_0 < 0)
		{
			num2 = -955896683;
			num3 = num2;
		}
		else
		{
			num2 = -955896682;
			num3 = num2;
		}
		goto IL_000f;
		IL_000a:
		num2 = -955896687;
		goto IL_000f;
		IL_000f:
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num2 ^ -955896686)
			{
			case 6:
				break;
			case 5:
				if (xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num4].zzfmTHlfPMxAtELqZGBGFqlGwNnV())
				{
					num2 = -955896688;
					continue;
				}
				num4++;
				num2 = -955896677;
				continue;
			case 2:
				return true;
			case 0:
				if (num >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
				{
					return false;
				}
				goto case 1;
			case 8:
				return true;
			case 1:
				if (!MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].zzfmTHlfPMxAtELqZGBGFqlGwNnV())
				{
					num++;
					num2 = -955896686;
				}
				else
				{
					num2 = -955896678;
				}
				continue;
			case 3:
				num2 = -955896686;
				continue;
			case 7:
				return false;
			case 4:
				if (P_0 < lHodAmkQtMDSknGmlYIxpakpInYX)
				{
					actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
					num4 = 0;
					num2 = -955896677;
				}
				else
				{
					num2 = -955896683;
				}
				continue;
			default:
				if (num4 >= actionCount)
				{
					return false;
				}
				goto case 5;
			}
			break;
		}
		goto IL_000a;
	}

	public bool NqrlnDPkKcvEHiGFhplhPoFHTZP(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00c6;
		}
		int actionCount = default(int);
		int num2 = default(int);
		int num3;
		if (P_0 >= 0)
		{
			if (P_0 < lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num2 = 0;
				num3 = -910662705;
			}
			else
			{
				num3 = -910662707;
			}
			goto IL_0014;
		}
		goto IL_004c;
		IL_004c:
		return false;
		IL_00c6:
		int num4;
		if (num >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
		{
			num3 = -910662708;
			num4 = num3;
		}
		else
		{
			num3 = -910662706;
			num4 = num3;
		}
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num3 ^ -910662708)
			{
			case 8:
				num3 = -910662706;
				continue;
			case 1:
				break;
			case 9:
				return true;
			case 0:
				return false;
			case 7:
				goto IL_0086;
			case 3:
				num3 = -910662711;
				continue;
			case 5:
				goto IL_00ae;
			case 4:
				goto IL_00c6;
			case 2:
				goto IL_00e5;
			default:
				return false;
			}
			break;
			IL_00e5:
			if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].GjQmURQfLsUJtlDpxsliLlcucXv())
			{
				return true;
			}
			num++;
			num3 = -910662712;
			continue;
			IL_00ae:
			int num5;
			if (num2 < actionCount)
			{
				num3 = -910662709;
				num5 = num3;
			}
			else
			{
				num3 = -910662710;
				num5 = num3;
			}
			continue;
			IL_0086:
			if (!xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num2].GjQmURQfLsUJtlDpxsliLlcucXv())
			{
				num2++;
				num3 = -910662711;
			}
			else
			{
				num3 = -910662715;
			}
		}
		goto IL_004c;
	}

	public bool BlsVzbDEDfbOVawQOrqljEfvAVfG(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00e1;
		}
		int num2;
		int num3;
		if (P_0 < 0)
		{
			num2 = 1827563329;
			num3 = num2;
		}
		else
		{
			num2 = 1827563328;
			num3 = num2;
		}
		goto IL_0014;
		IL_00e1:
		int num4;
		if (num >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
		{
			num2 = 1827563333;
			num4 = num2;
		}
		else
		{
			num2 = 1827563332;
			num4 = num2;
		}
		goto IL_0014;
		IL_0014:
		int actionCount = default(int);
		int num5 = default(int);
		while (true)
		{
			switch (num2 ^ 0x6CEE6745)
			{
			case 8:
				num2 = 1827563332;
				continue;
			case 0:
				return false;
			case 6:
				return true;
			case 1:
				if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].GispJZAEfezEtdemUKdarjXvYVi())
				{
					return true;
				}
				num++;
				num2 = 1827563335;
				continue;
			case 5:
				if (P_0 >= lHodAmkQtMDSknGmlYIxpakpInYX)
				{
					num2 = 1827563329;
					continue;
				}
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num5 = 0;
				num2 = 1827563340;
				continue;
			case 4:
				return false;
			case 9:
				num2 = 1827563330;
				continue;
			case 3:
				if (!xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num5].GispJZAEfezEtdemUKdarjXvYVi())
				{
					num5++;
					num2 = 1827563330;
				}
				else
				{
					num2 = 1827563331;
				}
				continue;
			case 2:
				break;
			default:
				if (num5 >= actionCount)
				{
					return false;
				}
				goto case 3;
			}
			break;
		}
		goto IL_00e1;
	}

	public bool iRnGfQeSvsCSXuEGmPFtbKSPDth(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_000b;
		}
		int num;
		int num2;
		if (P_0 < 0)
		{
			num = -123744700;
			num2 = num;
		}
		else
		{
			num = -123744702;
			num2 = num;
		}
		goto IL_0010;
		IL_000b:
		num = -123744701;
		goto IL_0010;
		IL_0010:
		int num3 = default(int);
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num ^ -123744699)
			{
			case 4:
				break;
			case 2:
				num3 = 0;
				num = -123744704;
				continue;
			case 9:
				if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num4].ZrNBCoHGXMCmZyMECcLNhxpdYovR())
				{
					return true;
				}
				num4++;
				num = -123744698;
				continue;
			case 3:
			{
				int num5;
				if (num4 >= MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
				{
					num = -123744691;
					num5 = num;
				}
				else
				{
					num = -123744692;
					num5 = num;
				}
				continue;
			}
			case 7:
				if (P_0 >= lHodAmkQtMDSknGmlYIxpakpInYX)
				{
					num = -123744700;
					continue;
				}
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num = -123744697;
				continue;
			case 8:
				return false;
			case 6:
				num4 = 0;
				num = -123744698;
				continue;
			case 1:
				return false;
			case 0:
				if (xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num3].ZrNBCoHGXMCmZyMECcLNhxpdYovR())
				{
					return true;
				}
				num3++;
				num = -123744704;
				continue;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				goto case 0;
			}
			break;
		}
		goto IL_000b;
	}

	public bool qxrAFAKnQmBkxngSPsgLaZHjvpd(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00bb;
		}
		int num2;
		int actionCount = default(int);
		int num3 = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				num2 = -1781728869;
			}
			else
			{
				actionCount = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
				num3 = 0;
				num2 = -1781728865;
			}
			goto IL_0014;
		}
		goto IL_0076;
		IL_0076:
		return false;
		IL_00bb:
		int num4;
		if (num < MSlCVrkKlxPxDZQWkkjqyGnqdVvA.Length)
		{
			num2 = -1781728867;
			num4 = num2;
		}
		else
		{
			num2 = -1781728866;
			num4 = num2;
		}
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -1781728865)
			{
			case 6:
				num2 = -1781728867;
				continue;
			case 2:
				break;
			case 1:
				return false;
			case 4:
				goto end_IL_0014;
			case 3:
				goto IL_008d;
			case 7:
				return true;
			case 5:
				goto IL_00bb;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				goto IL_008d;
			}
			if (MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].FyoNDogMdbcLjbRknabaNMHMibXI())
			{
				return true;
			}
			num++;
			num2 = -1781728870;
			continue;
			IL_008d:
			if (xZciHuXCgzsxWmLyXliLNdWkenqe[P_0, num3].FyoNDogMdbcLjbRknabaNMHMibXI())
			{
				num2 = -1781728872;
				continue;
			}
			num3++;
			num2 = -1781728865;
			continue;
			end_IL_0014:
			break;
		}
		goto IL_0076;
	}

	public bool qMmkNDOMQzXPyMTDEAjnCqJcDZM()
	{
		if (!qMmkNDOMQzXPyMTDEAjnCqJcDZM(QsKjzCdyrVeEepaejRwEtsXGCvQ) && !qMmkNDOMQzXPyMTDEAjnCqJcDZM(fWCliwnkNTDOHFCYEMfqdLBZkus) && !qMmkNDOMQzXPyMTDEAjnCqJcDZM(hkIjbGtLZQFWDsQGrYzEdMkoBQo))
		{
			return qMmkNDOMQzXPyMTDEAjnCqJcDZM(EZflvLyfMEnIWwDonfZVCrLfDzV);
		}
		return true;
	}

	public bool qMmkNDOMQzXPyMTDEAjnCqJcDZM(ControllerType P_0)
	{
		while (true)
		{
			switch (0x4542B7BD ^ 0x4542B7BC)
			{
			case 0:
				continue;
			case 1:
				switch (P_0)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return qMmkNDOMQzXPyMTDEAjnCqJcDZM(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
				case ControllerType.Mouse:
					return qMmkNDOMQzXPyMTDEAjnCqJcDZM(QsKjzCdyrVeEepaejRwEtsXGCvQ);
				case ControllerType.Custom:
					return qMmkNDOMQzXPyMTDEAjnCqJcDZM(EZflvLyfMEnIWwDonfZVCrLfDzV);
				default:
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return qMmkNDOMQzXPyMTDEAjnCqJcDZM(fWCliwnkNTDOHFCYEMfqdLBZkus);
	}

	public bool iWvHticXrAdWZFLviBzvsGPLFsf()
	{
		if (!iWvHticXrAdWZFLviBzvsGPLFsf(QsKjzCdyrVeEepaejRwEtsXGCvQ) && !iWvHticXrAdWZFLviBzvsGPLFsf(fWCliwnkNTDOHFCYEMfqdLBZkus) && !iWvHticXrAdWZFLviBzvsGPLFsf(hkIjbGtLZQFWDsQGrYzEdMkoBQo))
		{
			return iWvHticXrAdWZFLviBzvsGPLFsf(EZflvLyfMEnIWwDonfZVCrLfDzV);
		}
		return true;
	}

	public bool iWvHticXrAdWZFLviBzvsGPLFsf(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return iWvHticXrAdWZFLviBzvsGPLFsf(fWCliwnkNTDOHFCYEMfqdLBZkus);
		case ControllerType.Keyboard:
			return iWvHticXrAdWZFLviBzvsGPLFsf(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
		case ControllerType.Mouse:
			return iWvHticXrAdWZFLviBzvsGPLFsf(QsKjzCdyrVeEepaejRwEtsXGCvQ);
		case ControllerType.Custom:
			return iWvHticXrAdWZFLviBzvsGPLFsf(EZflvLyfMEnIWwDonfZVCrLfDzV);
		default:
			throw new NotImplementedException();
		}
	}

	public bool YEsIScIAGladATFwkFhUTFweJNvB()
	{
		if (!YEsIScIAGladATFwkFhUTFweJNvB(QsKjzCdyrVeEepaejRwEtsXGCvQ) && !YEsIScIAGladATFwkFhUTFweJNvB(fWCliwnkNTDOHFCYEMfqdLBZkus) && !YEsIScIAGladATFwkFhUTFweJNvB(hkIjbGtLZQFWDsQGrYzEdMkoBQo))
		{
			return YEsIScIAGladATFwkFhUTFweJNvB(EZflvLyfMEnIWwDonfZVCrLfDzV);
		}
		return true;
	}

	public bool YEsIScIAGladATFwkFhUTFweJNvB(ControllerType P_0)
	{
		while (true)
		{
			switch (-118607358 ^ -118607357)
			{
			case 2:
				continue;
			case 1:
				switch (P_0)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return YEsIScIAGladATFwkFhUTFweJNvB(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
				case ControllerType.Mouse:
					return YEsIScIAGladATFwkFhUTFweJNvB(QsKjzCdyrVeEepaejRwEtsXGCvQ);
				case ControllerType.Custom:
					return YEsIScIAGladATFwkFhUTFweJNvB(EZflvLyfMEnIWwDonfZVCrLfDzV);
				default:
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return YEsIScIAGladATFwkFhUTFweJNvB(fWCliwnkNTDOHFCYEMfqdLBZkus);
	}

	public bool DresfhJUXCtTWmWJwjrlJqaymvp()
	{
		if (!DresfhJUXCtTWmWJwjrlJqaymvp(QsKjzCdyrVeEepaejRwEtsXGCvQ) && !DresfhJUXCtTWmWJwjrlJqaymvp(fWCliwnkNTDOHFCYEMfqdLBZkus) && !DresfhJUXCtTWmWJwjrlJqaymvp(hkIjbGtLZQFWDsQGrYzEdMkoBQo))
		{
			return DresfhJUXCtTWmWJwjrlJqaymvp(EZflvLyfMEnIWwDonfZVCrLfDzV);
		}
		return true;
	}

	public bool DresfhJUXCtTWmWJwjrlJqaymvp(ControllerType P_0)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				int num = 2083602692;
				while (true)
				{
					switch (num ^ 0x7C314105)
					{
					case 3:
						break;
					case 1:
						goto IL_0036;
					default:
						goto end_IL_0014;
					case 0:
						throw new NotImplementedException();
					}
					break;
					IL_0036:
					if (P_0 != ControllerType.Custom)
					{
						num = 2083602693;
						continue;
					}
					return DresfhJUXCtTWmWJwjrlJqaymvp(EZflvLyfMEnIWwDonfZVCrLfDzV);
				}
				continue;
				end_IL_0014:
				break;
			}
			goto case ControllerType.Joystick;
		case ControllerType.Joystick:
			return DresfhJUXCtTWmWJwjrlJqaymvp(fWCliwnkNTDOHFCYEMfqdLBZkus);
		case ControllerType.Keyboard:
			return DresfhJUXCtTWmWJwjrlJqaymvp(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
		case ControllerType.Mouse:
			return DresfhJUXCtTWmWJwjrlJqaymvp(QsKjzCdyrVeEepaejRwEtsXGCvQ);
		}
	}

	public bool EqwgBzPiElvyaDTFfPlGplGnudu()
	{
		if (!EqwgBzPiElvyaDTFfPlGplGnudu(QsKjzCdyrVeEepaejRwEtsXGCvQ) && !EqwgBzPiElvyaDTFfPlGplGnudu(fWCliwnkNTDOHFCYEMfqdLBZkus) && !EqwgBzPiElvyaDTFfPlGplGnudu(hkIjbGtLZQFWDsQGrYzEdMkoBQo))
		{
			return EqwgBzPiElvyaDTFfPlGplGnudu(EZflvLyfMEnIWwDonfZVCrLfDzV);
		}
		return true;
	}

	public bool EqwgBzPiElvyaDTFfPlGplGnudu(ControllerType P_0)
	{
		while (true)
		{
			int num = 1749955788;
			while (true)
			{
				switch (num ^ 0x684E34CD)
				{
				case 3:
					break;
				case 1:
					switch (P_0)
					{
					default:
						goto IL_003b;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return EqwgBzPiElvyaDTFfPlGplGnudu(hkIjbGtLZQFWDsQGrYzEdMkoBQo);
					case ControllerType.Mouse:
						return EqwgBzPiElvyaDTFfPlGplGnudu(QsKjzCdyrVeEepaejRwEtsXGCvQ);
					case ControllerType.Custom:
						return EqwgBzPiElvyaDTFfPlGplGnudu(EZflvLyfMEnIWwDonfZVCrLfDzV);
					}
					goto default;
				default:
					return EqwgBzPiElvyaDTFfPlGplGnudu(fWCliwnkNTDOHFCYEMfqdLBZkus);
				case 2:
					throw new NotImplementedException();
				}
				break;
				IL_003b:
				num = 1749955791;
			}
		}
	}

	private bool qMmkNDOMQzXPyMTDEAjnCqJcDZM<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = -1560160739;
			while (true)
			{
				switch (num2 ^ -1560160740)
				{
				case 4:
					break;
				case 0:
				{
					int num3;
					if (num < count)
					{
						num2 = -1560160737;
						num3 = num2;
					}
					else
					{
						num2 = -1560160743;
						num3 = num2;
					}
					continue;
				}
				case 3:
				{
					T val = P_0[num];
					if (val != null && val.GetAnyButton())
					{
						num2 = -1560160738;
						continue;
					}
					num++;
					num2 = -1560160740;
					continue;
				}
				case 1:
					num2 = -1560160740;
					continue;
				case 2:
					return true;
				default:
					return false;
				}
				break;
			}
		}
	}

	private bool qMmkNDOMQzXPyMTDEAjnCqJcDZM(Controller P_0)
	{
		return P_0?.GetAnyButton() ?? false;
	}

	private bool iWvHticXrAdWZFLviBzvsGPLFsf<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 663076851;
		goto IL_0008;
		IL_0008:
		int num2 = default(int);
		T val = default(T);
		while (true)
		{
			switch (num ^ 0x2785BFF6)
			{
			case 0:
				break;
			case 3:
				return false;
			case 1:
			{
				int num3;
				if (num2 < count)
				{
					num = 663076852;
					num3 = num;
				}
				else
				{
					num = 663076850;
					num3 = num;
				}
				continue;
			}
			case 2:
				val = P_0[num2];
				if (val != null)
				{
					num = 663076848;
					continue;
				}
				goto IL_007e;
			case 6:
				if (val.GetAnyButtonDown())
				{
					return true;
				}
				goto IL_007e;
			case 5:
				num2 = 0;
				num = 663076855;
				continue;
			default:
				{
					return false;
				}
				IL_007e:
				num2++;
				num = 663076855;
				continue;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num = 663076853;
		goto IL_0008;
	}

	private bool iWvHticXrAdWZFLviBzvsGPLFsf(Controller P_0)
	{
		return P_0?.GetAnyButtonDown() ?? false;
	}

	private bool YEsIScIAGladATFwkFhUTFweJNvB<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				T val = P_0[num];
				int num2 = 427638407;
				while (true)
				{
					switch (num2 ^ 0x197D3E84)
					{
					case 0:
						num2 = 427638405;
						continue;
					case 2:
						return true;
					case 3:
						break;
					case 1:
						goto end_IL_0015;
					default:
						goto end_IL_0061;
					}
					if (val == null || !val.GetAnyButtonUp())
					{
						num++;
						num2 = 427638400;
					}
					else
					{
						num2 = 427638406;
					}
					continue;
					end_IL_0015:
					break;
				}
				continue;
				end_IL_0061:
				break;
			}
		}
		return false;
	}

	private bool YEsIScIAGladATFwkFhUTFweJNvB(Controller P_0)
	{
		return P_0?.GetAnyButtonUp() ?? false;
	}

	private bool DresfhJUXCtTWmWJwjrlJqaymvp<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				T val = P_0[num];
				int num2;
				if (val != null)
				{
					num2 = -1528834306;
					goto IL_0015;
				}
				goto IL_005a;
				IL_0049:
				if (val.GetAnyButtonChanged())
				{
					return true;
				}
				goto IL_005a;
				IL_005a:
				num++;
				num2 = -1528834305;
				goto IL_0015;
				IL_0015:
				while (true)
				{
					switch (num2 ^ -1528834306)
					{
					case 2:
						num2 = -1528834307;
						continue;
					case 3:
						break;
					case 0:
						goto IL_0049;
					default:
						goto end_IL_0032;
					}
					break;
				}
				continue;
				end_IL_0032:
				break;
			}
		}
		return false;
	}

	private bool DresfhJUXCtTWmWJwjrlJqaymvp(Controller P_0)
	{
		return P_0?.GetAnyButtonChanged() ?? false;
	}

	private bool EqwgBzPiElvyaDTFfPlGplGnudu<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 0;
		int num2 = -2077233604;
		goto IL_0008;
		IL_0008:
		T val = default(T);
		while (true)
		{
			switch (num2 ^ -2077233602)
			{
			case 0:
				break;
			case 3:
				return false;
			case 4:
				if (val.GetAnyButtonPrev())
				{
					return true;
				}
				goto IL_004c;
			case 1:
				val = P_0[num];
				if (val != null)
				{
					num2 = -2077233606;
					continue;
				}
				goto IL_004c;
			default:
				{
					if (num >= count)
					{
						return false;
					}
					goto case 1;
				}
				IL_004c:
				num++;
				num2 = -2077233604;
				continue;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = -2077233603;
		goto IL_0008;
	}

	private bool EqwgBzPiElvyaDTFfPlGplGnudu(Controller P_0)
	{
		return P_0?.GetAnyButtonPrev() ?? false;
	}

	public Controller GAMsTblJkcwwHOWGaarBuZDFDmq()
	{
		Controller lastController = null;
		int num3 = default(int);
		IList<CustomController> eZflvLyfMEnIWwDonfZVCrLfDzV = default(IList<CustomController>);
		double lastTime = default(double);
		int num2 = default(int);
		IList<Joystick> list = default(IList<Joystick>);
		while (true)
		{
			int num = -1562522859;
			while (true)
			{
				switch (num ^ -1562522860)
				{
				case 4:
					break;
				case 2:
					if (num3 < customControllerCount)
					{
						goto case 6;
					}
					if (lastController == null)
					{
						lastController = hkIjbGtLZQFWDsQGrYzEdMkoBQo;
						num = -1562522857;
						continue;
					}
					goto default;
				case 6:
					InputTools.CompareLastActiveController(eZflvLyfMEnIWwDonfZVCrLfDzV[num3], ref lastController, ref lastTime);
					num3++;
					num = -1562522858;
					continue;
				case 5:
					if (num2 >= joystickCount)
					{
						eZflvLyfMEnIWwDonfZVCrLfDzV = EZflvLyfMEnIWwDonfZVCrLfDzV;
						num3 = 0;
						num = -1562522858;
						continue;
					}
					goto case 0;
				case 0:
					InputTools.CompareLastActiveController(list[num2], ref lastController, ref lastTime);
					num2++;
					num = -1562522863;
					continue;
				case 1:
					lastTime = 0.0;
					InputTools.CompareLastActiveController(QsKjzCdyrVeEepaejRwEtsXGCvQ, ref lastController, ref lastTime);
					InputTools.CompareLastActiveController(hkIjbGtLZQFWDsQGrYzEdMkoBQo, ref lastController, ref lastTime);
					list = fWCliwnkNTDOHFCYEMfqdLBZkus;
					num2 = 0;
					num = -1562522863;
					continue;
				default:
					return lastController;
				}
				break;
			}
		}
	}

	public Controller GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType P_0)
	{
		Controller lastController = null;
		double lastTime = 0.0;
		int count;
		int num;
		int num2 = default(int);
		int num3 = default(int);
		switch (P_0)
		{
		case ControllerType.Joystick:
			count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
			num = 1575436198;
			goto IL_0035;
		default:
			goto IL_00f7;
		case ControllerType.Keyboard:
			goto IL_0145;
		case ControllerType.Mouse:
			return Mouse;
		case ControllerType.Custom:
			{
				count = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
				num = 1575436204;
				goto IL_0035;
			}
			IL_0035:
			while (true)
			{
				switch (num ^ 0x5DE73FAF)
				{
				case 0:
					num = 1575436206;
					continue;
				case 14:
					InputTools.CompareLastActiveController(fWCliwnkNTDOHFCYEMfqdLBZkus[num2], ref lastController, ref lastTime);
					num = 1575436199;
					continue;
				case 3:
					num3 = 0;
					num = 1575436205;
					continue;
				case 7:
					break;
				case 15:
					num = 1575436200;
					continue;
				case 5:
					num = 1575436194;
					continue;
				case 6:
					num = 1575436194;
					continue;
				case 1:
					goto end_IL_0035;
				case 10:
					goto IL_00f7;
				case 11:
					num3++;
					num = 1575436205;
					continue;
				case 4:
					InputTools.CompareLastActiveController(EZflvLyfMEnIWwDonfZVCrLfDzV[num3], ref lastController, ref lastTime);
					num = 1575436196;
					continue;
				case 8:
					num2++;
					num = 1575436200;
					continue;
				case 12:
					goto IL_0145;
				case 2:
					goto IL_0169;
				case 9:
					num2 = 0;
					num = 1575436192;
					continue;
				default:
					return lastController;
				}
				int num4;
				if (num2 >= count)
				{
					num = 1575436201;
					num4 = num;
				}
				else
				{
					num = 1575436193;
					num4 = num;
				}
				continue;
				IL_0169:
				int num5;
				if (num3 >= count)
				{
					num = 1575436202;
					num5 = num;
				}
				else
				{
					num = 1575436203;
					num5 = num;
				}
				continue;
				end_IL_0035:
				break;
			}
			goto case ControllerType.Joystick;
			IL_0145:
			return Keyboard;
			IL_00f7:
			throw new NotImplementedException();
		}
	}

	public T GAMsTblJkcwwHOWGaarBuZDFDmq<T>() where T : Controller
	{
		Type typeFromHandle = typeof(T);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			goto IL_001d;
		}
		int num;
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			num = -33652392;
		}
		else
		{
			if (!ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
			{
				if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
				{
					return GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Mouse) as T;
				}
				throw new NotImplementedException();
			}
			num = -33652389;
		}
		goto IL_0022;
		IL_0022:
		switch (num ^ -33652392)
		{
		case 2:
			break;
		case 1:
			return GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Joystick) as T;
		case 0:
			return GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Keyboard) as T;
		default:
			return GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Custom) as T;
		}
		goto IL_001d;
		IL_001d:
		num = -33652391;
		goto IL_0022;
	}

	public ControllerType WbfNMrBsIgebvERgcaqLCWaveDQ()
	{
		Controller controller = GAMsTblJkcwwHOWGaarBuZDFDmq();
		while (true)
		{
			int num = 1474927289;
			while (true)
			{
				switch (num ^ 0x57E99AB8)
				{
				case 2:
					break;
				case 1:
					if (controller != null)
					{
						goto IL_0028;
					}
					return ControllerType.Keyboard;
				default:
					return controller.type;
				}
				break;
				IL_0028:
				num = 1474927288;
			}
		}
	}

	public void MqDqxGWuOCyWAIdIkzOEoctTCyo(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_002d;
		IL_0003:
		int num = 838722356;
		goto IL_0008;
		IL_0008:
		switch (num ^ 0x31FDE335)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			return;
		case 0:
			goto IL_002d;
		case 3:
			return;
		}
		goto IL_0003;
		IL_002d:
		GfZgGXZMtDapQSXyPcAECrHpSQL = true;
		WShAfCdbOHIKoXoeMBArAXRldrro.ShfbJAREaAXGCzKoNvYJdibXSuU(P_0);
		num = 838722358;
		goto IL_0008;
	}

	public void MqDqxGWuOCyWAIdIkzOEoctTCyo(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 != null)
		{
			GfZgGXZMtDapQSXyPcAECrHpSQL = true;
			WShAfCdbOHIKoXoeMBArAXRldrro.ShfbJAREaAXGCzKoNvYJdibXSuU(P_0, P_1);
		}
	}

	public void SocWXTmgYYhVxfPvwjxVyFCgcBN(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			WShAfCdbOHIKoXoeMBArAXRldrro.rRpAocLnHgxXpkcFGqTXOCiBhht(P_0);
		}
	}

	public void piCLvCEoDQKNaLuLzlawqKmTZAV(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (0x4A6AC03E ^ 0x4A6AC03C)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		WShAfCdbOHIKoXoeMBArAXRldrro.rRpAocLnHgxXpkcFGqTXOCiBhht(P_0, P_1);
	}

	public void jIyPROmihxCpKwLjsbBzIhGZEHmh()
	{
		WShAfCdbOHIKoXoeMBArAXRldrro.tAgADqjTsMUxSqYXeDyJIdETYRAp();
	}

	public void MqDqxGWuOCyWAIdIkzOEoctTCyo(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			IL_0050:
			int num;
			if (P_0 == 9999999)
			{
				IKSpbTOFfNSGMVWDSAlcrGFKSlZ.ShfbJAREaAXGCzKoNvYJdibXSuU(P_1);
				num = 1315952901;
				goto IL_0009;
			}
			goto IL_003f;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x4E6FD901)
				{
				case 2:
					num = 1315952896;
					continue;
				case 0:
					break;
				case 3:
					goto IL_003f;
				case 1:
					goto IL_0050;
				default:
					GfZgGXZMtDapQSXyPcAECrHpSQL = true;
					return;
				}
				break;
			}
			goto IL_002a;
			IL_003f:
			if ((uint)P_0 >= (uint)lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				break;
			}
			goto IL_002a;
			IL_002a:
			YLmBxfdwRWpDwNGXWPILvBqBUYJS[P_0].ShfbJAREaAXGCzKoNvYJdibXSuU(P_1);
			num = 1315952901;
			goto IL_0009;
		}
	}

	public void MqDqxGWuOCyWAIdIkzOEoctTCyo(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (P_0 != 9999999)
			{
				num = 1571107432;
				num2 = num;
			}
			else
			{
				num = 1571107438;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x5DA5326C)
				{
				case 3:
					num = 1571107433;
					continue;
				default:
					return;
				case 5:
					break;
				case 0:
					GfZgGXZMtDapQSXyPcAECrHpSQL = true;
					num = 1571107435;
					continue;
				case 1:
					YLmBxfdwRWpDwNGXWPILvBqBUYJS[P_0].ShfbJAREaAXGCzKoNvYJdibXSuU(P_1, P_2);
					num = 1571107436;
					continue;
				case 4:
				{
					int num3;
					if ((uint)P_0 >= (uint)lHodAmkQtMDSknGmlYIxpakpInYX)
					{
						num = 1571107434;
						num3 = num;
					}
					else
					{
						num = 1571107437;
						num3 = num;
					}
					continue;
				}
				case 2:
					IKSpbTOFfNSGMVWDSAlcrGFKSlZ.ShfbJAREaAXGCzKoNvYJdibXSuU(P_1, P_2);
					num = 1571107436;
					continue;
				case 6:
					return;
				case 7:
					return;
				}
				break;
			}
		}
	}

	public void SocWXTmgYYhVxfPvwjxVyFCgcBN(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 != null)
		{
			if (P_0 == 9999999)
			{
				IKSpbTOFfNSGMVWDSAlcrGFKSlZ.rRpAocLnHgxXpkcFGqTXOCiBhht(P_1);
			}
			else if ((uint)P_0 < (uint)lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				YLmBxfdwRWpDwNGXWPILvBqBUYJS[P_0].rRpAocLnHgxXpkcFGqTXOCiBhht(P_1);
			}
		}
	}

	public void SocWXTmgYYhVxfPvwjxVyFCgcBN(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			if (P_0 == 9999999)
			{
				IKSpbTOFfNSGMVWDSAlcrGFKSlZ.rRpAocLnHgxXpkcFGqTXOCiBhht(P_1, P_2);
				int num = -339441945;
				while (true)
				{
					switch (num ^ -339441945)
					{
					case 4:
						num = -339441946;
						continue;
					case 1:
						break;
					case 2:
						goto IL_0046;
					case 0:
						return;
					default:
						goto end_IL_002a;
					}
					break;
				}
				continue;
			}
			goto IL_0046;
			IL_0046:
			if ((uint)P_0 < (uint)lHodAmkQtMDSknGmlYIxpakpInYX)
			{
				break;
			}
			return;
			continue;
			end_IL_002a:
			break;
		}
		YLmBxfdwRWpDwNGXWPILvBqBUYJS[P_0].rRpAocLnHgxXpkcFGqTXOCiBhht(P_1, P_2);
	}

	public void jIyPROmihxCpKwLjsbBzIhGZEHmh(int P_0)
	{
		if (P_0 == 9999999)
		{
			IKSpbTOFfNSGMVWDSAlcrGFKSlZ.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			return;
		}
		while ((uint)P_0 < (uint)lHodAmkQtMDSknGmlYIxpakpInYX)
		{
			while (true)
			{
				IL_0047:
				YLmBxfdwRWpDwNGXWPILvBqBUYJS[P_0].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				int num = 2086695786;
				while (true)
				{
					switch (num ^ 0x7C60736A)
					{
					case 3:
						num = 2086695787;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						goto IL_0047;
					case 0:
						return;
					}
					break;
				}
				break;
			}
		}
	}

	private void rSABlrtdXFUfxybUfcvCiJlVJdN()
	{
		if (WShAfCdbOHIKoXoeMBArAXRldrro.YoRcPvJoxTitOrMhbbdCJZhPEsh > 0)
		{
			goto IL_0011;
		}
		goto IL_009c;
		IL_0011:
		int num = 1841800542;
		goto IL_0016;
		IL_0016:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x6DC7A55B)
			{
			case 3:
				break;
			case 6:
				num2++;
				num = 1841800538;
				continue;
			case 2:
				if (YLmBxfdwRWpDwNGXWPILvBqBUYJS[num2].YoRcPvJoxTitOrMhbbdCJZhPEsh != 0)
				{
					Player.ControllerHelper controllers = WhcqAfYYqNfRCEGkYApjWYGKVjr.Players_orig[num2].controllers;
					YLmBxfdwRWpDwNGXWPILvBqBUYJS[num2].RymGNNjXLQmacarJhvEtYIveMwv(num2, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
					num = 1841800541;
					continue;
				}
				goto case 6;
			case 0:
				goto IL_009c;
			case 4:
				goto IL_00ea;
			case 5:
				WShAfCdbOHIKoXoeMBArAXRldrro.RymGNNjXLQmacarJhvEtYIveMwv(-1, GAMsTblJkcwwHOWGaarBuZDFDmq(), GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Joystick), GAMsTblJkcwwHOWGaarBuZDFDmq(ControllerType.Custom));
				num = 1841800539;
				continue;
			default:
				if (num2 >= lHodAmkQtMDSknGmlYIxpakpInYX)
				{
					return;
				}
				goto case 2;
			}
			break;
		}
		goto IL_0011;
		IL_009c:
		if (IKSpbTOFfNSGMVWDSAlcrGFKSlZ.YoRcPvJoxTitOrMhbbdCJZhPEsh > 0)
		{
			Player.ControllerHelper controllers2 = WhcqAfYYqNfRCEGkYApjWYGKVjr.SJbqFeuTGPOUMrjgHHxfbLJovAZ().controllers;
			IKSpbTOFfNSGMVWDSAlcrGFKSlZ.RymGNNjXLQmacarJhvEtYIveMwv(9999999, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			num = 1841800543;
			goto IL_0016;
		}
		goto IL_00ea;
		IL_00ea:
		num2 = 0;
		num = 1841800538;
		goto IL_0016;
	}

	public void IDEywWFxxQnkLUsYVchGCtQvPNH(ThrottleCalibrationMode P_0)
	{
		int num = 0;
		int num2 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num3;
			if (num >= fWCliwnkNTDOHFCYEMfqdLBZkus.Count)
			{
				num2 = 0;
				num3 = -2136372005;
				goto IL_000c;
			}
			goto IL_0158;
			IL_000c:
			while (true)
			{
				switch (num3 ^ -2136372006)
				{
				case 9:
					num3 = -2136372002;
					continue;
				case 8:
					if (EZflvLyfMEnIWwDonfZVCrLfDzV[num4] != null)
					{
						IDEywWFxxQnkLUsYVchGCtQvPNH(EZflvLyfMEnIWwDonfZVCrLfDzV[num4], P_0);
						num3 = -2136372009;
						continue;
					}
					goto case 13;
				case 12:
					num4 = 0;
					num3 = -2136372006;
					continue;
				case 14:
					break;
				case 13:
					num4++;
					num3 = -2136372004;
					continue;
				case 7:
					IDEywWFxxQnkLUsYVchGCtQvPNH(MvskRqvCtzrQOtaBjGjRwDGQrzs[num2], P_0);
					num3 = -2136372008;
					continue;
				case 0:
					num3 = -2136372004;
					continue;
				case 2:
					num2++;
					num3 = -2136372015;
					continue;
				case 11:
					goto IL_00e9;
				case 3:
					num++;
					num3 = -2136372012;
					continue;
				case 10:
					IDEywWFxxQnkLUsYVchGCtQvPNH(fWCliwnkNTDOHFCYEMfqdLBZkus[num], P_0);
					num3 = -2136372007;
					continue;
				case 5:
					goto IL_0136;
				case 4:
					goto IL_0158;
				case 1:
					num3 = -2136372015;
					continue;
				default:
					if (num4 >= customControllerCount)
					{
						IDEywWFxxQnkLUsYVchGCtQvPNH(QsKjzCdyrVeEepaejRwEtsXGCvQ, P_0);
						return;
					}
					goto case 8;
				}
				break;
				IL_0136:
				int num5;
				if (MvskRqvCtzrQOtaBjGjRwDGQrzs[num2] != null)
				{
					num3 = -2136372003;
					num5 = num3;
				}
				else
				{
					num3 = -2136372008;
					num5 = num3;
				}
				continue;
				IL_00e9:
				int num6;
				if (num2 < MvskRqvCtzrQOtaBjGjRwDGQrzs.Count)
				{
					num3 = -2136372001;
					num6 = num3;
				}
				else
				{
					num3 = -2136372010;
					num6 = num3;
				}
			}
			continue;
			IL_0158:
			int num7;
			if (fWCliwnkNTDOHFCYEMfqdLBZkus[num] == null)
			{
				num3 = -2136372007;
				num7 = num3;
			}
			else
			{
				num3 = -2136372016;
				num7 = num3;
			}
			goto IL_000c;
		}
	}

	private void IDEywWFxxQnkLUsYVchGCtQvPNH(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < P_0.axisCount)
			{
				num2 = 890424936;
				num3 = num2;
			}
			else
			{
				num2 = 890424938;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x3512CE69)
				{
				case 2:
					num2 = 890424936;
					continue;
				default:
					return;
				case 5:
					num++;
					num2 = 890424941;
					continue;
				case 0:
					P_0.calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
					num2 = 890424940;
					continue;
				case 4:
					break;
				case 1:
				{
					int num4;
					if (axes[num].fLnddiiYsQMexRarBgYYAedEaIXb._specialAxisType != SpecialAxisType.Throttle)
					{
						num2 = 890424940;
						num4 = num2;
					}
					else
					{
						num2 = 890424937;
						num4 = num2;
					}
					continue;
				}
				case 3:
					return;
				}
				break;
			}
		}
	}

	public IList<T> FgQQMUzgEuQzAhjlHgysYegnaLn<T>() where T : IControllerTemplate
	{
		return BgCxDGjbjyGhqKEBjduwAnAERoLD.VZqSGZQOIbFUZVzJGEEYrQpJptG<T>();
	}

	private void SdmfoteCDVoXNaSlWEvRMBbwmDy(List<InputBehavior> P_0)
	{
		lUCgcEIquFfuykgBneGrfARQlcR = ReInput.lUCgcEIquFfuykgBneGrfARQlcR;
		int num6 = default(int);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		int num2 = default(int);
		int num3 = default(int);
		CustomController customController = default(CustomController);
		List<Player_Editor.CreateControllerInfo> startingCustomControllers = default(List<Player_Editor.CreateControllerInfo>);
		int num8 = default(int);
		int num10 = default(int);
		IList<Player> players = default(IList<Player>);
		int num7 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		Player player = default(Player);
		while (true)
		{
			int num = -2075970501;
			while (true)
			{
				switch (num ^ -2075970523)
				{
				case 23:
					break;
				case 7:
					if (num6 >= players_readOnly.Count)
					{
						hoctQAMMDSSlMKekCSwlcmkXBZM = new RcSeSPqNxZpeyVpTsiApgswOCre();
						oaKsRFokNJlGdfFskYZNgyNhHFb = new RcSeSPqNxZpeyVpTsiApgswOCre[lHodAmkQtMDSknGmlYIxpakpInYX];
						num2 = 0;
						num = -2075970508;
						continue;
					}
					goto case 5;
				case 2:
					num3 = 0;
					num = -2075970507;
					continue;
				case 6:
					if (customController != null)
					{
						customController.tag = startingCustomControllers[num8].tag;
						num = -2075970527;
						continue;
					}
					goto case 13;
				case 18:
					if (num10 >= players.Count)
					{
						jTQvwbszYZHADMZsikvWjvMZqqr = new ReadOnlyCollection<Joystick>(fWCliwnkNTDOHFCYEMfqdLBZkus);
						num = -2075970515;
						continue;
					}
					goto case 21;
				case 27:
					JGperUdlNDVxAScSttWLqbZvOIB = lUCgcEIquFfuykgBneGrfARQlcR.actionCount;
					num = -2075970518;
					continue;
				case 5:
				{
					startingCustomControllers = players_readOnly[num6].startingCustomControllers;
					int num12;
					if (startingCustomControllers != null)
					{
						num = -2075970509;
						num12 = num;
					}
					else
					{
						num = -2075970500;
						num12 = num;
					}
					continue;
				}
				case 19:
					MvskRqvCtzrQOtaBjGjRwDGQrzs = new List<Joystick>();
					EZflvLyfMEnIWwDonfZVCrLfDzV = new List<CustomController>();
					num = -2075970498;
					continue;
				case 9:
					customController = WhUGCBoKUaVEhcUVTTDVyELczky(startingCustomControllers[num8].sourceId);
					num = -2075970525;
					continue;
				case 28:
					num6 = 0;
					num = -2075970526;
					continue;
				case 10:
				{
					int num13;
					if (num7 < lHodAmkQtMDSknGmlYIxpakpInYX)
					{
						num = -2075970555;
						num13 = num;
					}
					else
					{
						num = -2075970499;
						num13 = num;
					}
					continue;
				}
				case 22:
					num8 = 0;
					num = -2075970523;
					continue;
				case 0:
				{
					int num11;
					if (num8 >= startingCustomControllers.Count)
					{
						num = -2075970500;
						num11 = num;
					}
					else
					{
						num = -2075970516;
						num11 = num;
					}
					continue;
				}
				case 16:
					num = -2075970517;
					continue;
				case 3:
					jvGLYqeWwaPCWxbEVCSZXIyDAALJ = 0;
					OnSBTbDyKqgnNJsyOlEFvIvyIMY = new ADictionary<int, fjiypClzXjxyicfzTrljpXKAlJV>();
					OnSBTbDyKqgnNJsyOlEFvIvyIMY.Add(ReInput.players.GetSystemPlayer().id, new fjiypClzXjxyicfzTrljpXKAlJV(P_0));
					players = ReInput.players.Players;
					num10 = 0;
					num = -2075970504;
					continue;
				case 26:
				{
					InputAction inputAction2 = lUCgcEIquFfuykgBneGrfARQlcR.VMlKZYsEyUgtddhSCWgBqIUwGOE(num3);
					InputBehavior inputBehavior2 = OnSBTbDyKqgnNJsyOlEFvIvyIMY[9999999].CVXqNEOSFYRCujjZqAGoCXBHsWP(inputAction2.behaviorId);
					juUkCOtINcePpkOEZitZVEIfgiwq juUkCOtINcePpkOEZitZVEIfgiwq3 = new juUkCOtINcePpkOEZitZVEIfgiwq(9999999, inputAction2, inputBehavior2, MgGtJKaHLSyjHLoGfGQLvKxEfrJ);
					MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num3] = juUkCOtINcePpkOEZitZVEIfgiwq3;
					VnuuOkMeAITOJtiiGCSTkakpTpN[num4] = juUkCOtINcePpkOEZitZVEIfgiwq3;
					num4++;
					num3++;
					num = -2075970517;
					continue;
				}
				case 13:
					num8++;
					num = -2075970523;
					continue;
				case 29:
					num = -2075970505;
					continue;
				case 1:
				{
					InputAction inputAction = lUCgcEIquFfuykgBneGrfARQlcR.VMlKZYsEyUgtddhSCWgBqIUwGOE(num5);
					InputBehavior inputBehavior = OnSBTbDyKqgnNJsyOlEFvIvyIMY[players[num7].id].CVXqNEOSFYRCujjZqAGoCXBHsWP(inputAction.behaviorId);
					juUkCOtINcePpkOEZitZVEIfgiwq juUkCOtINcePpkOEZitZVEIfgiwq2 = new juUkCOtINcePpkOEZitZVEIfgiwq(num7, inputAction, inputBehavior, MgGtJKaHLSyjHLoGfGQLvKxEfrJ);
					xZciHuXCgzsxWmLyXliLNdWkenqe[num7, num5] = juUkCOtINcePpkOEZitZVEIfgiwq2;
					VnuuOkMeAITOJtiiGCSTkakpTpN[num4] = juUkCOtINcePpkOEZitZVEIfgiwq2;
					num4++;
					num5++;
					num = -2075970519;
					continue;
				}
				case 14:
					if (num3 >= JGperUdlNDVxAScSttWLqbZvOIB)
					{
						xZciHuXCgzsxWmLyXliLNdWkenqe = new juUkCOtINcePpkOEZitZVEIfgiwq[lHodAmkQtMDSknGmlYIxpakpInYX, JGperUdlNDVxAScSttWLqbZvOIB];
						num7 = 0;
						num = -2075970514;
						continue;
					}
					goto case 26;
				case 21:
					OnSBTbDyKqgnNJsyOlEFvIvyIMY.Add(players[num10].id, new fjiypClzXjxyicfzTrljpXKAlJV(P_0));
					num10++;
					num = -2075970505;
					continue;
				case 30:
					WhcqAfYYqNfRCEGkYApjWYGKVjr = ReInput.WhcqAfYYqNfRCEGkYApjWYGKVjr;
					fWCliwnkNTDOHFCYEMfqdLBZkus = new List<Joystick>();
					num = -2075970506;
					continue;
				case 4:
				{
					int num9 = ((num6 == 0) ? 9999999 : (num6 - 1));
					player = WhcqAfYYqNfRCEGkYApjWYGKVjr.LwwGNDEKhVGiAVsVapAOKLGgPGB(num9);
					num = -2075970511;
					continue;
				}
				case 20:
					if (player != null)
					{
						player.controllers.VoEDDsKnWYkfZfofupKrQyuXgzI(customController, false);
						num = -2075970520;
						continue;
					}
					goto case 13;
				case 12:
					if (num5 >= JGperUdlNDVxAScSttWLqbZvOIB)
					{
						num7++;
						num = -2075970513;
						continue;
					}
					goto case 1;
				case 15:
					lHodAmkQtMDSknGmlYIxpakpInYX = WhcqAfYYqNfRCEGkYApjWYGKVjr.gamePlayerCount;
					IYoilpdmEtqNOAPsfslhBMmUhCz = NnHNlQbUETdoXgkrXUGDVNTSbLJ;
					num = -2075970522;
					continue;
				case 31:
					oaKsRFokNJlGdfFskYZNgyNhHFb[num2] = new RcSeSPqNxZpeyVpTsiApgswOCre();
					num2++;
					num = -2075970508;
					continue;
				case 25:
					num6++;
					num = -2075970526;
					continue;
				case 11:
					num = -2075970513;
					continue;
				case 24:
					players_readOnly = ReInput.UserData.Players_readOnly;
					if (players_readOnly == null)
					{
						throw new ArgumentNullException("Players cannot be null!");
					}
					goto case 28;
				case 32:
					num5 = 0;
					num = -2075970519;
					continue;
				case 8:
					zsWdfjwIHDdiHaEgLfpnzDSQvAFk = new ReadOnlyCollection<CustomController>(EZflvLyfMEnIWwDonfZVCrLfDzV);
					juUkCOtINcePpkOEZitZVEIfgiwq.ziLMcIXSpSwrwJNOpROVKIUOpOZ(MgGtJKaHLSyjHLoGfGQLvKxEfrJ);
					VnuuOkMeAITOJtiiGCSTkakpTpN = new juUkCOtINcePpkOEZitZVEIfgiwq[(lHodAmkQtMDSknGmlYIxpakpInYX + 1) * JGperUdlNDVxAScSttWLqbZvOIB];
					num4 = 0;
					MSlCVrkKlxPxDZQWkkjqyGnqdVvA = new juUkCOtINcePpkOEZitZVEIfgiwq[JGperUdlNDVxAScSttWLqbZvOIB];
					num = -2075970521;
					continue;
				default:
					if (num2 >= lHodAmkQtMDSknGmlYIxpakpInYX)
					{
						WShAfCdbOHIKoXoeMBArAXRldrro = new global::tsjplABEcSjkmdpDoXtjUbHAmKnE<ActiveControllerChangedDelegate>();
						IKSpbTOFfNSGMVWDSAlcrGFKSlZ = new global::tsjplABEcSjkmdpDoXtjUbHAmKnE<PlayerActiveControllerChangedDelegate>();
						YLmBxfdwRWpDwNGXWPILvBqBUYJS = new global::tsjplABEcSjkmdpDoXtjUbHAmKnE<PlayerActiveControllerChangedDelegate>[WhcqAfYYqNfRCEGkYApjWYGKVjr.gamePlayerCount];
						ArrayTools.Populate(YLmBxfdwRWpDwNGXWPILvBqBUYJS);
						return;
					}
					goto case 31;
				}
				break;
			}
		}
	}

	private void YqOSpcBQAKIAuYTTxcIXbWWwglrp(UpdateLoopType P_0)
	{
		int count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
		CustomController customController = default(CustomController);
		int num3 = default(int);
		int num2 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num = -282498997;
			while (true)
			{
				switch (num ^ -282499001)
				{
				case 3:
					break;
				case 1:
					if (customController.enabled)
					{
						customController.FillData();
						customController.kckuoUXEwQcigNbCseRHnXueOkT(P_0);
						num = -282499005;
						continue;
					}
					goto case 4;
				case 2:
					if (num3 >= count)
					{
						if (hkIjbGtLZQFWDsQGrYzEdMkoBQo.enabled)
						{
							hkIjbGtLZQFWDsQGrYzEdMkoBQo.kckuoUXEwQcigNbCseRHnXueOkT(P_0);
							num = -282498996;
							continue;
						}
						goto case 0;
					}
					goto case 5;
				case 0:
				{
					int num4;
					if (!DQnwvjIBzLNvHhHKjrxTcxvEtjs)
					{
						num = -282498996;
						num4 = num;
					}
					else
					{
						num = -282498995;
						num4 = num;
					}
					continue;
				}
				case 7:
					customController = EZflvLyfMEnIWwDonfZVCrLfDzV[num2];
					num = -282499002;
					continue;
				case 5:
				{
					Joystick joystick = fWCliwnkNTDOHFCYEMfqdLBZkus[num3];
					if (joystick.enabled)
					{
						WpkIllEBqoxBInpEvnLFrPOhsWM(joystick.inputManagerId, joystick.cMcAtEwaThLpgGZfIIRmVCJQjDU);
						joystick.kckuoUXEwQcigNbCseRHnXueOkT(P_0);
						num = -282498993;
						continue;
					}
					goto case 8;
				}
				case 11:
					if (QsKjzCdyrVeEepaejRwEtsXGCvQ.enabled)
					{
						QsKjzCdyrVeEepaejRwEtsXGCvQ.kckuoUXEwQcigNbCseRHnXueOkT(P_0);
						num = -282498994;
						continue;
					}
					goto case 9;
				case 10:
					hkIjbGtLZQFWDsQGrYzEdMkoBQo.UpdateData_AndroidKeyboardDisabled(P_0);
					num = -282498996;
					continue;
				case 12:
					num3 = 0;
					num = -282499003;
					continue;
				case 8:
					num3++;
					num = -282499003;
					continue;
				case 9:
					count2 = EZflvLyfMEnIWwDonfZVCrLfDzV.Count;
					num2 = 0;
					num = -282499007;
					continue;
				case 4:
					num2++;
					num = -282499007;
					continue;
				default:
					if (num2 >= count2)
					{
						return;
					}
					goto case 7;
				}
				break;
			}
		}
	}

	private void niVIXEDcAExPiSZvVRxHbzndTyh(UpdateLoopType P_0)
	{
		juUkCOtINcePpkOEZitZVEIfgiwq.iHiXgKQPKkdDwIvWNGiRuAvewAW(P_0);
		Player[] allPlayers_orig = WhcqAfYYqNfRCEGkYApjWYGKVjr.AllPlayers_orig;
		Player.ControllerHelper controllers = default(Player.ControllerHelper);
		int num5 = default(int);
		int num13 = default(int);
		bool enabled2 = default(bool);
		int num10 = default(int);
		int num6 = default(int);
		int num8 = default(int);
		juUkCOtINcePpkOEZitZVEIfgiwq juUkCOtINcePpkOEZitZVEIfgiwq2 = default(juUkCOtINcePpkOEZitZVEIfgiwq);
		RcSeSPqNxZpeyVpTsiApgswOCre rcSeSPqNxZpeyVpTsiApgswOCre = default(RcSeSPqNxZpeyVpTsiApgswOCre);
		IList<KeyboardMap> maps = default(IList<KeyboardMap>);
		int num2 = default(int);
		int count = default(int);
		int num7 = default(int);
		int num3 = default(int);
		bool enabled = default(bool);
		while (true)
		{
			int num = 1538673855;
			while (true)
			{
				switch (num ^ 0x5BB64CB9)
				{
				case 3:
					break;
				default:
					return;
				case 22:
					controllers = allPlayers_orig[num5].controllers;
					num = 1538673827;
					continue;
				case 25:
				{
					juUkCOtINcePpkOEZitZVEIfgiwq juUkCOtINcePpkOEZitZVEIfgiwq3 = MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num13];
					if (juUkCOtINcePpkOEZitZVEIfgiwq3.LFjEkChFNlIHcQOEePsxvVBzeeq != juUkCOtINcePpkOEZitZVEIfgiwq.iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx)
					{
						hoctQAMMDSSlMKekCSwlcmkXBZM.VRoGSIfXLonnVCkEUMpLUDgeolgZ(juUkCOtINcePpkOEZitZVEIfgiwq3, P_0);
						num = 1538673848;
						continue;
					}
					goto case 1;
				}
				case 13:
				{
					int num17;
					if (!enabled2)
					{
						num = 1538673837;
						num17 = num;
					}
					else
					{
						num = 1538673838;
						num17 = num;
					}
					continue;
				}
				case 16:
				{
					int num11;
					if (num10 < lHodAmkQtMDSknGmlYIxpakpInYX)
					{
						num = 1538673842;
						num11 = num;
					}
					else
					{
						num = 1538673816;
						num11 = num;
					}
					continue;
				}
				case 8:
					num6++;
					num = 1538673825;
					continue;
				case 0:
				{
					int num16;
					if (num8 < JGperUdlNDVxAScSttWLqbZvOIB)
					{
						num = 1538673846;
						num16 = num;
					}
					else
					{
						num = 1538673840;
						num16 = num;
					}
					continue;
				}
				case 15:
					juUkCOtINcePpkOEZitZVEIfgiwq2 = xZciHuXCgzsxWmLyXliLNdWkenqe[num10, num8];
					num = 1538673847;
					continue;
				case 11:
					rcSeSPqNxZpeyVpTsiApgswOCre = oaKsRFokNJlGdfFskYZNgyNhHFb[num10];
					if (rcSeSPqNxZpeyVpTsiApgswOCre.uvLjcnQqosrrPsERyMWJozjFDBK != 0)
					{
						num8 = 0;
						num = 1538673849;
						continue;
					}
					goto case 9;
				case 17:
					maps = allPlayers_orig[num2].controllers.maps.GetMaps<KeyboardMap>(0);
					count = maps.Count;
					num7 = 0;
					num = 1538673853;
					continue;
				case 7:
					controllers.EOzrhLmwGhilqSHzRDSaLwQjiQp(hkIjbGtLZQFWDsQGrYzEdMkoBQo, GRinbNRIBfEZvcsfFmgmhhcJeDeZ, IYoilpdmEtqNOAPsfslhBMmUhCz);
					num = 1538673844;
					continue;
				case 32:
					if (VnuuOkMeAITOJtiiGCSTkakpTpN[num6].LFjEkChFNlIHcQOEePsxvVBzeeq != juUkCOtINcePpkOEZitZVEIfgiwq.iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx)
					{
						VnuuOkMeAITOJtiiGCSTkakpTpN[num6].tIzIDvReItXvpclLGxghMMTtfSbf();
						num = 1538673841;
						continue;
					}
					goto case 8;
				case 9:
					num10++;
					num = 1538673833;
					continue;
				case 18:
					if (maps[num7].enabled)
					{
						GRinbNRIBfEZvcsfFmgmhhcJeDeZ.sxUbFNrPaRsClXkJWQRrCpsZzJv(maps[num7]);
						num = 1538673831;
						continue;
					}
					goto case 30;
				case 19:
				{
					int num18;
					if (num13 >= JGperUdlNDVxAScSttWLqbZvOIB)
					{
						num = 1538673836;
						num18 = num;
					}
					else
					{
						num = 1538673824;
						num18 = num;
					}
					continue;
				}
				case 23:
					controllers.DDFOCAesmXqXGhsbiTLeQcclpvd(QsKjzCdyrVeEepaejRwEtsXGCvQ, IYoilpdmEtqNOAPsfslhBMmUhCz);
					num = 1538673837;
					continue;
				case 10:
					num2 = 0;
					num = 1538673828;
					continue;
				case 12:
					if (hoctQAMMDSSlMKekCSwlcmkXBZM.uvLjcnQqosrrPsERyMWJozjFDBK > 0)
					{
						num13 = 0;
						num = 1538673834;
						continue;
					}
					goto case 21;
				case 31:
				{
					int num15;
					if (!KhXuOsPpGzJHMqbKjXYWPjUNHAg)
					{
						num = 1538673816;
						num15 = num;
					}
					else
					{
						num = 1538673845;
						num15 = num;
					}
					continue;
				}
				case 6:
				{
					num3 = allPlayers_orig.Length;
					enabled = hkIjbGtLZQFWDsQGrYzEdMkoBQo.enabled;
					int num14;
					if (!enabled)
					{
						num = 1538673826;
						num14 = num;
					}
					else
					{
						num = 1538673843;
						num14 = num;
					}
					continue;
				}
				case 27:
					enabled2 = QsKjzCdyrVeEepaejRwEtsXGCvQ.enabled;
					num5 = 0;
					num = 1538673852;
					continue;
				case 4:
					if (num7 >= count)
					{
						num2++;
						num = 1538673828;
						continue;
					}
					goto case 18;
				case 5:
					if (num5 >= num3)
					{
						num6 = 0;
						num = 1538673825;
						continue;
					}
					goto case 22;
				case 30:
					num7++;
					num = 1538673853;
					continue;
				case 1:
					num13++;
					num = 1538673834;
					continue;
				case 20:
					controllers.fNRcMPkitrakTLtkHhnVHbhEbsmb(IYoilpdmEtqNOAPsfslhBMmUhCz);
					num5++;
					num = 1538673852;
					continue;
				case 24:
				{
					int num12;
					if (num6 < VnuuOkMeAITOJtiiGCSTkakpTpN.Length)
					{
						num = 1538673817;
						num12 = num;
					}
					else
					{
						num = 1538673851;
						num12 = num;
					}
					continue;
				}
				case 26:
					controllers.nkQBHleqQCTiJDAJviIXigpOEqZ(IYoilpdmEtqNOAPsfslhBMmUhCz);
					if (!enabled)
					{
						int num9;
						if (DQnwvjIBzLNvHhHKjrxTcxvEtjs)
						{
							num = 1538673854;
							num9 = num;
						}
						else
						{
							num = 1538673844;
							num9 = num;
						}
						continue;
					}
					goto case 7;
				case 28:
					num8++;
					num = 1538673849;
					continue;
				case 21:
					num10 = 0;
					num = 1538673833;
					continue;
				case 2:
					juUkCOtINcePpkOEZitZVEIfgiwq.pLPulFDYtrqfGsPqpfOAGAjfzaoL();
					num = 1538673830;
					continue;
				case 14:
					if (juUkCOtINcePpkOEZitZVEIfgiwq2.LFjEkChFNlIHcQOEePsxvVBzeeq != juUkCOtINcePpkOEZitZVEIfgiwq.iIesQmHJYNaOjZySNFbyVCRRARUD.gQycyAxmUbprXJvfcdLMRodEACx)
					{
						rcSeSPqNxZpeyVpTsiApgswOCre.VRoGSIfXLonnVCkEUMpLUDgeolgZ(juUkCOtINcePpkOEZitZVEIfgiwq2, P_0);
						num = 1538673829;
						continue;
					}
					goto case 28;
				case 29:
				{
					int num4;
					if (num2 >= num3)
					{
						num = 1538673826;
						num4 = num;
					}
					else
					{
						num = 1538673832;
						num4 = num;
					}
					continue;
				}
				case 33:
					return;
				}
				break;
			}
		}
	}

	private void NnHNlQbUETdoXgkrXUGDVNTSbLJ(bool P_0, int P_1, int P_2)
	{
		int num = lUCgcEIquFfuykgBneGrfARQlcR.KhufsiHazfkStoHkXbcGhTzBsNFW(P_2);
		while (true)
		{
			int num2 = -1959917278;
			while (true)
			{
				switch (num2 ^ -1959917279)
				{
				case 2:
					break;
				case 3:
				{
					int num3;
					if (num >= 0)
					{
						num2 = -1959917275;
						num3 = num2;
					}
					else
					{
						num2 = -1959917279;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (P_1 == 9999999)
					{
						MSlCVrkKlxPxDZQWkkjqyGnqdVvA[num].ySbgAzYkAyfjIJZnfyAuXolwUwb(P_0);
						return;
					}
					goto default;
				case 0:
					return;
				default:
					xZciHuXCgzsxWmLyXliLNdWkenqe[P_1, num].ySbgAzYkAyfjIJZnfyAuXolwUwb(P_0);
					return;
				}
				break;
			}
		}
	}

	private void oSICIgLhcTfMfZQZLgpVkdASkeG(BridgedController P_0)
	{
		int num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0.sourceJoystick.rewiredId, jzNdcCxegIibzZgLQVureOMBAWA.CjmYXcdCBXiHQDcAZjTOavgjOlNM);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		while (true)
		{
			IL_006c:
			num = AOhxOVnRebcHMuIuCTGlzvDPOHD(P_0.sourceJoystick.rewiredId, jzNdcCxegIibzZgLQVureOMBAWA.rnhzNdsbKFAFzIutEGSzJlLtLIdQ);
			Joystick joystick;
			int num2;
			if (num >= 0)
			{
				joystick = MvskRqvCtzrQOtaBjGjRwDGQrzs[num];
				num2 = -142686037;
				goto IL_0027;
			}
			goto IL_005e;
			IL_0027:
			while (true)
			{
				switch (num2 ^ -142686039)
				{
				case 0:
					num2 = -142686035;
					continue;
				default:
					return;
				case 3:
					num2 = -142686040;
					continue;
				case 7:
					break;
				case 4:
					goto IL_006c;
				case 2:
					MvskRqvCtzrQOtaBjGjRwDGQrzs.RemoveAt(num);
					joystick.UpdateControllerInfo(P_0);
					joystick.isConnected = true;
					num2 = -142686038;
					continue;
				case 1:
					fWCliwnkNTDOHFCYEMfqdLBZkus.Add(joystick);
					OKSwjlddjZcPuRKkVMhqRMQQFXV.Add(joystick);
					num2 = -142686036;
					continue;
				case 5:
					fWCliwnkNTDOHFCYEMfqdLBZkus.Sort(Joystick.CompareById_Ascending);
					BgCxDGjbjyGhqKEBjduwAnAERoLD.BvPfHvHLNzqGeTIHCnrafZGRLbzd(joystick);
					num2 = -142686033;
					continue;
				case 6:
					return;
				}
				break;
			}
			goto IL_005e;
			IL_005e:
			joystick = new Joystick(P_0);
			num2 = -142686040;
			goto IL_0027;
		}
	}

	private void doNCJmsSgzaLVJAOFXLXeifKQzla(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		Joystick joystick = default(Joystick);
		while (true)
		{
			int num;
			int num2;
			if (P_0 >= fWCliwnkNTDOHFCYEMfqdLBZkus.Count)
			{
				num = 846797978;
				num2 = num;
			}
			else
			{
				num = 846797976;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x32791C99)
				{
				case 0:
					num = 846797981;
					continue;
				default:
					return;
				case 4:
					break;
				case 3:
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				case 7:
					joystick.isConnected = false;
					if (NpbRYFrtrrOckxCMaiUgeLntnqve != null)
					{
						NpbRYFrtrrOckxCMaiUgeLntnqve(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
						num = 846797979;
						continue;
					}
					goto case 2;
				case 1:
					joystick = fWCliwnkNTDOHFCYEMfqdLBZkus[P_0];
					num = 846797982;
					continue;
				case 2:
					if (KETaXMnBLpNaEVVeuNtnGPwEcdW != null)
					{
						KETaXMnBLpNaEVVeuNtnGPwEcdW(joystick.type, joystick.id);
						num = 846797983;
						continue;
					}
					goto case 6;
				case 6:
					fWCliwnkNTDOHFCYEMfqdLBZkus.RemoveAt(P_0);
					MvskRqvCtzrQOtaBjGjRwDGQrzs.Add(joystick);
					OKSwjlddjZcPuRKkVMhqRMQQFXV.Remove(joystick);
					BgCxDGjbjyGhqKEBjduwAnAERoLD.utEyQKdpAPrHxIeSoECnMypLPFi(joystick);
					joystick.tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num = 846797980;
					continue;
				case 5:
					return;
				}
				break;
			}
		}
	}

	private void IlRitHLxbVlxvbnzyxJltFJoHGn()
	{
		int count = fWCliwnkNTDOHFCYEMfqdLBZkus.Count;
		int num = count - 1;
		while (true)
		{
			int num2 = 488008614;
			while (true)
			{
				switch (num2 ^ 0x1D166BA2)
				{
				case 2:
					break;
				default:
					return;
				case 5:
					num--;
					num2 = 488008611;
					continue;
				case 3:
					doNCJmsSgzaLVJAOFXLXeifKQzla(num);
					num2 = 488008615;
					continue;
				case 1:
				{
					int num3;
					if (num >= 0)
					{
						num2 = 488008609;
						num3 = num2;
					}
					else
					{
						num2 = 488008610;
						num3 = num2;
					}
					continue;
				}
				case 4:
					num2 = 488008611;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private bool VoEDDsKnWYkfZfofupKrQyuXgzI(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			IL_006a:
			int num2;
			if (num >= EZflvLyfMEnIWwDonfZVCrLfDzV.Count)
			{
				EZflvLyfMEnIWwDonfZVCrLfDzV.Add(P_0);
				num2 = 952487497;
				goto IL_000e;
			}
			goto IL_002f;
			IL_000e:
			while (true)
			{
				switch (num2 ^ 0x38C5CE4B)
				{
				case 4:
					num2 = 952487498;
					continue;
				case 1:
					break;
				case 2:
					OKSwjlddjZcPuRKkVMhqRMQQFXV.Add(P_0);
					BgCxDGjbjyGhqKEBjduwAnAERoLD.BvPfHvHLNzqGeTIHCnrafZGRLbzd(P_0);
					num2 = 952487499;
					continue;
				case 3:
					goto IL_006a;
				default:
					return true;
				}
				break;
			}
			goto IL_002f;
			IL_002f:
			if (EZflvLyfMEnIWwDonfZVCrLfDzV[num] == P_0)
			{
				break;
			}
			num++;
			num2 = 952487496;
			goto IL_000e;
		}
		return true;
	}

	private bool DWWXsjaPmOBkVDVbcwVtOBPDVdXv(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		BgCxDGjbjyGhqKEBjduwAnAERoLD.utEyQKdpAPrHxIeSoECnMypLPFi(P_0);
		OKSwjlddjZcPuRKkVMhqRMQQFXV.Remove(P_0);
		return EZflvLyfMEnIWwDonfZVCrLfDzV.Remove(P_0);
	}

	private RcSeSPqNxZpeyVpTsiApgswOCre sxuQPWlavjokjLaCtVqmppwApUA(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_0008;
		}
		int num;
		int num2;
		if (P_0 < 0)
		{
			num = 1148282454;
			num2 = num;
		}
		else
		{
			num = 1148282455;
			num2 = num;
		}
		goto IL_000d;
		IL_0008:
		num = 1148282452;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x44716655)
			{
			case 0:
				break;
			case 1:
				return hoctQAMMDSSlMKekCSwlcmkXBZM;
			case 2:
				if (P_0 >= ReInput.WhcqAfYYqNfRCEGkYApjWYGKVjr.gamePlayerCount)
				{
					goto IL_0053;
				}
				return oaKsRFokNJlGdfFskYZNgyNhHFb[P_0];
			default:
				return null;
			}
			break;
			IL_0053:
			num = 1148282454;
		}
		goto IL_0008;
	}

	private void rMjiygzGVFDrzhLunXkROlXeGkG(bool P_0)
	{
		if (!P_0)
		{
			GRinbNRIBfEZvcsfFmgmhhcJeDeZ.wGXBINGyfkkYSWBIVpoJcwYKKPQ();
		}
	}

	private void MmtcKTFjtpegfEXXVAshFJeAqfIR(bool P_0)
	{
		if (P_0 || ReInput.applicationRunInBackground)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			int num2 = -852972107;
			while (true)
			{
				switch (num2 ^ -852972106)
				{
				case 0:
					break;
				default:
					return;
				case 2:
				{
					int num3;
					if (num < fWCliwnkNTDOHFCYEMfqdLBZkus.Count)
					{
						num2 = -852972105;
						num3 = num2;
					}
					else
					{
						num2 = -852972110;
						num3 = num2;
					}
					continue;
				}
				case 1:
					fWCliwnkNTDOHFCYEMfqdLBZkus[num].StopVibration();
					num++;
					num2 = -852972108;
					continue;
				case 3:
					num2 = -852972108;
					continue;
				case 4:
					return;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		XUyPrOkreNDOTTMFamEakBsuIHM(true);
		GC.SuppressFinalize(this);
	}

	~IEFDteeOKlelVDYGidTLyloAfeYs()
	{
		XUyPrOkreNDOTTMFamEakBsuIHM(false);
	}

	private void XUyPrOkreNDOTTMFamEakBsuIHM(bool P_0)
	{
		if (xRygqjRmTtURDPiwlgMmFcdNBrr)
		{
			goto IL_0008;
		}
		goto IL_003e;
		IL_0008:
		int num = 163815132;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x9C39ED9)
			{
			case 3:
				break;
			default:
				return;
			case 5:
				return;
			case 0:
				goto IL_003e;
			case 2:
				if (vmofcEAmkOcrbNOYuHJhWCJvTeh is IDisposable)
				{
					(vmofcEAmkOcrbNOYuHJhWCJvTeh as IDisposable).Dispose();
					num = 163815135;
					continue;
				}
				goto IL_009d;
			case 4:
				(KDTHrwEDDYgItRGhlwfYIGOBBVNF as IDisposable).Dispose();
				num = 163815131;
				continue;
			case 6:
				goto IL_009d;
			case 1:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_003e:
		if (P_0)
		{
			int num2;
			if (!(KDTHrwEDDYgItRGhlwfYIGOBBVNF is IDisposable))
			{
				num = 163815131;
				num2 = num;
			}
			else
			{
				num = 163815133;
				num2 = num;
			}
			goto IL_000d;
		}
		goto IL_009d;
		IL_009d:
		xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		num = 163815128;
		goto IL_000d;
	}
}
