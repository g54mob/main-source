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

internal sealed class lCLAgzeBrhoeWjAjwfsCvCCcNbf : IDisposable
{
	public enum nZhbitNCKUHtixjXUCKWfBgoLsY
	{
		jikNtdRieZgCLIcbSBeRBnEBmcwg = 0,
		OlrsfcQzhPGAwvfQNjJivvrkJaM = 1
	}

	private class FQkjupqqspQonJvnwPKnCpDFtsT
	{
		public ADictionary<int, InputBehavior> kByLbWRXiXsWnZdJKBoJqLwPfkS;

		public List<InputBehavior> YDazdhpxhkRnASjKZzmrujnFLma;

		public IList<InputBehavior> ZivxtkxVNTcLITMeAKdXFjLbtMZ;

		public FQkjupqqspQonJvnwPKnCpDFtsT(List<InputBehavior> behaviors)
		{
			int num2 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = -1667904143;
				while (true)
				{
					switch (num ^ -1667904141)
					{
					case 6:
						break;
					default:
						return;
					case 4:
					{
						InputBehavior inputBehavior = behaviors[num2].Clone();
						kByLbWRXiXsWnZdJKBoJqLwPfkS.Add(behaviors[num2].id, inputBehavior);
						YDazdhpxhkRnASjKZzmrujnFLma.Add(inputBehavior);
						num4++;
						num2++;
						num = -1667904142;
						continue;
					}
					case 5:
						kByLbWRXiXsWnZdJKBoJqLwPfkS = new ADictionary<int, InputBehavior>();
						num4 = 0;
						num2 = 0;
						num = -1667904142;
						continue;
					case 3:
						ZivxtkxVNTcLITMeAKdXFjLbtMZ = new ReadOnlyCollection<InputBehavior>(YDazdhpxhkRnASjKZzmrujnFLma);
						num = -1667904141;
						continue;
					case 1:
					{
						int num3;
						if (num2 >= behaviors.Count)
						{
							num = -1667904144;
							num3 = num;
						}
						else
						{
							num = -1667904137;
							num3 = num;
						}
						continue;
					}
					case 2:
						YDazdhpxhkRnASjKZzmrujnFLma = new List<InputBehavior>(behaviors.Count);
						num = -1667904138;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public InputBehavior xwFckPipwCPHlCQsjNxlMtvGULy(int P_0)
		{
			if (YDazdhpxhkRnASjKZzmrujnFLma.Count == 0)
			{
				goto IL_000d;
			}
			InputBehavior value = default(InputBehavior);
			kByLbWRXiXsWnZdJKBoJqLwPfkS.TryGetValue(P_0, out value);
			int num = 585277299;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x22E29F72)
				{
				case 0:
					break;
				case 3:
					return null;
				case 1:
					if (value == null)
					{
						goto IL_004a;
					}
					return value;
				default:
					return YDazdhpxhkRnASjKZzmrujnFLma[0];
				}
				break;
				IL_004a:
				num = 585277296;
			}
			goto IL_000d;
			IL_000d:
			num = 585277297;
			goto IL_0012;
		}
	}

	private sealed class ghroXXFstlvjelMsuGPgKOZNLbz : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController RDkWcsTpvDaNZojjIZONnoEBXPC;

		private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

		private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

		public lCLAgzeBrhoeWjAjwfsCvCCcNbf ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

		public int cDnsjzqLLfMiCslAqgUjBQwehLTA;

		public int pBxznzuVLJfgWHNIseDtNacTYTS;

		public int NEuaOjoIpwrpmjCIDgVypnNNttD;

		public int hLyEHBmqlObPKirSGoIkRTZWolo;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return RDkWcsTpvDaNZojjIZONnoEBXPC;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return RDkWcsTpvDaNZojjIZONnoEBXPC;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
			{
				goto IL_001c;
			}
			goto IL_004e;
			IL_004e:
			ghroXXFstlvjelMsuGPgKOZNLbz ghroXXFstlvjelMsuGPgKOZNLbz2 = new ghroXXFstlvjelMsuGPgKOZNLbz(0);
			ghroXXFstlvjelMsuGPgKOZNLbz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
			int num = 1901660267;
			goto IL_0021;
			IL_001c:
			num = 1901660264;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x71590869)
				{
				case 0:
					break;
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					ghroXXFstlvjelMsuGPgKOZNLbz2 = this;
					num = 1901660267;
					continue;
				case 3:
					goto IL_004e;
				default:
					ghroXXFstlvjelMsuGPgKOZNLbz2.cDnsjzqLLfMiCslAqgUjBQwehLTA = pBxznzuVLJfgWHNIseDtNacTYTS;
					return ghroXXFstlvjelMsuGPgKOZNLbz2;
				}
				break;
			}
			goto IL_001c;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int num;
			switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
			{
			default:
				num = 1433224963;
				goto IL_001a;
			case 0:
				goto IL_0081;
			case 1:
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 1433224960;
					goto IL_001a;
				}
				IL_001a:
				while (true)
				{
					switch (num ^ 0x556D4702)
					{
					case 4:
						break;
					case 1:
						num = 1433224962;
						continue;
					case 2:
						hLyEHBmqlObPKirSGoIkRTZWolo++;
						num = 1433224961;
						continue;
					case 3:
						goto IL_0062;
					case 6:
						goto IL_0081;
					case 5:
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN[hLyEHBmqlObPKirSGoIkRTZWolo].sourceControllerId == cDnsjzqLLfMiCslAqgUjBQwehLTA)
						{
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN[hLyEHBmqlObPKirSGoIkRTZWolo];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						}
						goto case 2;
					default:
						return false;
					}
					break;
					IL_0062:
					int num2;
					if (hLyEHBmqlObPKirSGoIkRTZWolo < NEuaOjoIpwrpmjCIDgVypnNNttD)
					{
						num = 1433224967;
						num2 = num;
					}
					else
					{
						num = 1433224962;
						num2 = num;
					}
				}
				goto default;
				IL_0081:
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				NEuaOjoIpwrpmjCIDgVypnNNttD = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
				hLyEHBmqlObPKirSGoIkRTZWolo = 0;
				num = 1433224961;
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
		public ghroXXFstlvjelMsuGPgKOZNLbz(int _003C_003E1__state)
		{
			LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
			iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private sealed class yASJUUgxmIDcJgcLidJJkGZfAsU : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController RDkWcsTpvDaNZojjIZONnoEBXPC;

		private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

		private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

		public lCLAgzeBrhoeWjAjwfsCvCCcNbf ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

		public string gOLsIvUagYjTsnfFxoDrjCWKnIG;

		public string PqgqlyVpPbbxVBxonFUFLIlCcziX;

		public int vXNbZmnFvscYnPmPDBkSBGwagwbW;

		public int AgTnIUtazYaOYCcryVPEUUDXpKR;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return RDkWcsTpvDaNZojjIZONnoEBXPC;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return RDkWcsTpvDaNZojjIZONnoEBXPC;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
			{
				goto IL_0012;
			}
			goto IL_0052;
			IL_0012:
			int num = -1304210709;
			goto IL_0017;
			IL_0017:
			yASJUUgxmIDcJgcLidJJkGZfAsU yASJUUgxmIDcJgcLidJJkGZfAsU2 = default(yASJUUgxmIDcJgcLidJJkGZfAsU);
			while (true)
			{
				switch (num ^ -1304210710)
				{
				case 0:
					break;
				case 1:
					if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						yASJUUgxmIDcJgcLidJJkGZfAsU2 = this;
						num = -1304210706;
						continue;
					}
					goto IL_0052;
				case 3:
					goto IL_0052;
				case 4:
					num = -1304210712;
					continue;
				default:
					yASJUUgxmIDcJgcLidJJkGZfAsU2.gOLsIvUagYjTsnfFxoDrjCWKnIG = PqgqlyVpPbbxVBxonFUFLIlCcziX;
					return yASJUUgxmIDcJgcLidJJkGZfAsU2;
				}
				break;
			}
			goto IL_0012;
			IL_0052:
			yASJUUgxmIDcJgcLidJJkGZfAsU2 = new yASJUUgxmIDcJgcLidJJkGZfAsU(0);
			yASJUUgxmIDcJgcLidJJkGZfAsU2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
			num = -1304210712;
			goto IL_0017;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
			while (true)
			{
				int num = 80637847;
				while (true)
				{
					switch (num ^ 0x4CE6F92)
					{
					case 7:
						break;
					case 0:
						if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN[AgTnIUtazYaOYCcryVPEUUDXpKR].tag.Equals(gOLsIvUagYjTsnfFxoDrjCWKnIG, StringComparison.OrdinalIgnoreCase))
						{
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN[AgTnIUtazYaOYCcryVPEUUDXpKR];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						}
						goto case 6;
					case 2:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 80637846;
						continue;
					case 1:
					{
						int num2;
						if (AgTnIUtazYaOYCcryVPEUUDXpKR >= vXNbZmnFvscYnPmPDBkSBGwagwbW)
						{
							num = 80637841;
							num2 = num;
						}
						else
						{
							num = 80637842;
							num2 = num;
						}
						continue;
					}
					case 5:
						switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
						{
						case 1:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 80637844;
							continue;
						case 0:
							break;
						default:
							num = 80637841;
							continue;
						}
						goto case 2;
					case 4:
						vXNbZmnFvscYnPmPDBkSBGwagwbW = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
						AgTnIUtazYaOYCcryVPEUUDXpKR = 0;
						num = 80637843;
						continue;
					case 6:
						AgTnIUtazYaOYCcryVPEUUDXpKR++;
						num = 80637843;
						continue;
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
		public yASJUUgxmIDcJgcLidJJkGZfAsU(int _003C_003E1__state)
		{
			LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
			iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private List<Joystick> QsAVjdFzwBBIEaNvFSzfnbhSbwL;

	private List<Joystick> txiWVMTSpznmRIqXyBdcjgrBpyA;

	private List<CustomController> hBtIKAiElSFkNtDRgRmKCWbkUegN;

	private List<Controller> rJQlHuZSQNCSzonDICIjFLkTXWgT;

	private ReadOnlyCollection<Controller> hUCAFbttkxHWygiHueZVYFcfxhPt;

	private Keyboard SFYAuTPTwQDVYDMfiGzNbbQzFhV;

	private Mouse xuMdUThDXJJnvRMJqvyVfthJBBhD;

	private ConfigVars liMFOVAIkIPrOJivyHfIDbBCDeae;

	private CvKbBDBykgOtczqdWEjAImsohWR[] mUwGRhAqfGeUMXYZXHbEbaCqKiwF;

	private CvKbBDBykgOtczqdWEjAImsohWR[] tRpsseUjStqkQeJlxaKdeaJnHCWi;

	private CvKbBDBykgOtczqdWEjAImsohWR[,] MVymlrpVDhkWJLuVMNfWHQypaFV;

	private MXySRXOfmMgXrIAuZtBSajLexeQ xnyKNSfAwxCMcZnCWAZbtfQYBOXh;

	private sbGjBSYUCHFmdsRwzJKaaHSDFDN OmgpPaGkSscTxvFHKNkmXOGjAj;

	private sbGjBSYUCHFmdsRwzJKaaHSDFDN[] VOoSTAIrXRloZYIerDhCqmMUIMc;

	private global::ItvAIPvALEjnzMQurwGyhxzBLJS<ActiveControllerChangedDelegate> vWfklDVVhVIXzshDTlzkTcxgKkK;

	private global::ItvAIPvALEjnzMQurwGyhxzBLJS<PlayerActiveControllerChangedDelegate> dGEaYGcZYLDZJaVkNbUrlqhHiTe;

	private global::ItvAIPvALEjnzMQurwGyhxzBLJS<PlayerActiveControllerChangedDelegate>[] tJgUQmUwhQQSvfwPTzFQBcIUXea;

	private ADictionary<int, FQkjupqqspQonJvnwPKnCpDFtsT> nmUPqatzdoguCudPRBhWxuXdCLrE;

	private readonly nZMtauWkkREsICRoLuWSNkwPMlpF kSUuBeVOaugtZhencTbifmpEpsF;

	private IList<Joystick> CRAJsKEjWPTKilPYjUTblmqShQz;

	private IList<CustomController> ARUrCeMkoFdxWBlTCqIgCVqNNZkW;

	private int rAaSPKeLizUyGamANAuDNbapmjz;

	private bool mXnbDodmeHqYEXAgmqSCAqLZXiZe;

	private bool HTrjbVpbkEHVkbkenPcRqGNLFG;

	private bool rbLrKKlnCVgbRlVXExpTYHjqZTw;

	private IUnifiedKeyboardSource vWTAIrnHuKFLcfZGsOQDWoyKGEg;

	private IUnifiedMouseSource AQyfQTcKPEsnwqJtfBwgBYzoxYU;

	private int CuYIorUZBawGDYQjOdUKDXYSFUc;

	private vymLASJcQEATncxsXyaiNEjaYgR AQANKVsSPXqhjRcrczEkdvuTzzw;

	private ZxYDdEiisedLFBFHGsfeDMnmzxjo lGcKTymIVPnyTtnJFgbcUzeJcSS;

	private int UAitzniEqWVvtfBkcdBcuATsmUv;

	private int cCbIxTLaiLwjBvZtihnEixbuTKw;

	private Action<int, ControllerDataUpdater> zrqFfcgoVawyVJChujEYldemglxu;

	private Action<bool, int, int> dUaQQwLlbrCiThoTsItmPnKJFQO;

	private Action<ControllerStatusChangedEventArgs> aLzdxOFnYbpbtIgxhDrljDDcPbMa;

	private Action<ControllerType, int> vLFdJRJUytEANJaedIuoIIzFkfby;

	private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

	public IList<Joystick> Joysticks_readOnly
	{
		get
		{
			return CRAJsKEjWPTKilPYjUTblmqShQz;
		}
	}

	public List<Joystick> Joysticks_orig
	{
		get
		{
			return QsAVjdFzwBBIEaNvFSzfnbhSbwL;
		}
	}

	public int joystickCount
	{
		get
		{
			return QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
		}
	}

	public Mouse Mouse
	{
		get
		{
			return xuMdUThDXJJnvRMJqvyVfthJBBhD;
		}
	}

	public Keyboard Keyboard
	{
		get
		{
			return SFYAuTPTwQDVYDMfiGzNbbQzFhV;
		}
	}

	public IList<CustomController> CustomControllers_readOnly
	{
		get
		{
			return ARUrCeMkoFdxWBlTCqIgCVqNNZkW;
		}
	}

	public List<CustomController> CustomControllers_orig
	{
		get
		{
			return hBtIKAiElSFkNtDRgRmKCWbkUegN;
		}
	}

	public int customControllerCount
	{
		get
		{
			return hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		}
	}

	public IList<Controller> Controllers
	{
		get
		{
			return hUCAFbttkxHWygiHueZVYFcfxhPt;
		}
	}

	public int controllerCount
	{
		get
		{
			return rJQlHuZSQNCSzonDICIjFLkTXWgT.Count;
		}
	}

	private int nextCustomControllerId
	{
		get
		{
			int cuYIorUZBawGDYQjOdUKDXYSFUc = CuYIorUZBawGDYQjOdUKDXYSFUc;
			CuYIorUZBawGDYQjOdUKDXYSFUc++;
			if (CuYIorUZBawGDYQjOdUKDXYSFUc >= int.MaxValue)
			{
				CuYIorUZBawGDYQjOdUKDXYSFUc = 0;
			}
			return cuYIorUZBawGDYQjOdUKDXYSFUc;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ControllerDisconnectStartedEvent
	{
		add
		{
			aLzdxOFnYbpbtIgxhDrljDDcPbMa = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(aLzdxOFnYbpbtIgxhDrljDDcPbMa, value);
		}
		remove
		{
			aLzdxOFnYbpbtIgxhDrljDDcPbMa = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(aLzdxOFnYbpbtIgxhDrljDDcPbMa, value);
		}
	}

	public event Action<ControllerType, int> JustBeforeControllerFullyDisconnectedEvent
	{
		add
		{
			vLFdJRJUytEANJaedIuoIIzFkfby = (Action<ControllerType, int>)Delegate.Combine(vLFdJRJUytEANJaedIuoIIzFkfby, value);
		}
		remove
		{
			vLFdJRJUytEANJaedIuoIIzFkfby = (Action<ControllerType, int>)Delegate.Remove(vLFdJRJUytEANJaedIuoIIzFkfby, value);
		}
	}

	public lCLAgzeBrhoeWjAjwfsCvCCcNbf(ConfigVars configVars, PlatformInputManager inputManager)
	{
		liMFOVAIkIPrOJivyHfIDbBCDeae = configVars;
		rAaSPKeLizUyGamANAuDNbapmjz = 0;
		mXnbDodmeHqYEXAgmqSCAqLZXiZe = UnityTools.isAndroidPlatform;
		rJQlHuZSQNCSzonDICIjFLkTXWgT = new List<Controller>(10);
		hUCAFbttkxHWygiHueZVYFcfxhPt = new ReadOnlyCollection<Controller>(rJQlHuZSQNCSzonDICIjFLkTXWgT);
		IUnifiedKeyboardSource unifiedKeyboardSource = inputManager.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (vWTAIrnHuKFLcfZGsOQDWoyKGEg = new UnityUnifiedKeyboardSource());
		}
		SFYAuTPTwQDVYDMfiGzNbbQzFhV = new Keyboard("Keyboard", unifiedKeyboardSource);
		rJQlHuZSQNCSzonDICIjFLkTXWgT.Add(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		IUnifiedMouseSource unifiedMouseSource = inputManager.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (AQyfQTcKPEsnwqJtfBwgBYzoxYU = new UnityUnifiedMouseSource());
		}
		xuMdUThDXJJnvRMJqvyVfthJBBhD = new Mouse("Mouse", unifiedMouseSource);
		rJQlHuZSQNCSzonDICIjFLkTXWgT.Add(xuMdUThDXJJnvRMJqvyVfthJBBhD);
		xnyKNSfAwxCMcZnCWAZbtfQYBOXh = new MXySRXOfmMgXrIAuZtBSajLexeQ(configVars.updateLoop, SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		SFYAuTPTwQDVYDMfiGzNbbQzFhV.EnabledStateChangedEvent += KQnERtXqgFEKsKSFgqkCdGdjbBjx;
		SFYAuTPTwQDVYDMfiGzNbbQzFhV.enabled = !configVars.GetPlatformVar_disableKeyboard();
		qTKJmxoqbugShRsjWFlkNISfBeOh.xaGVjRxEvIdELjjBskoGFDUNmrm();
		kSUuBeVOaugtZhencTbifmpEpsF = new nZMtauWkkREsICRoLuWSNkwPMlpF(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		kSUuBeVOaugtZhencTbifmpEpsF.mNZqIqhDqfRYbzOcNOQjRKmCmuS(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		kSUuBeVOaugtZhencTbifmpEpsF.mNZqIqhDqfRYbzOcNOQjRKmCmuS(xuMdUThDXJJnvRMJqvyVfthJBBhD);
		ReInput.ApplicationFocusChangedEvent += xltRnWzfKredmaiyAQFcSDIhKcdz;
	}

	public void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		zrqFfcgoVawyVJChujEYldemglxu = P_0;
		dFyvOnKBbTYzKLbxHBbiIGdcrpeH(P_1);
	}

	public void rdEJYvExbWYUXSDuseVgzyXPBhA(UpdateLoopType P_0)
	{
		qTKJmxoqbugShRsjWFlkNISfBeOh.dKWTUOLIJHgJKecLFpnBDIVtNff(P_0);
		if (SFYAuTPTwQDVYDMfiGzNbbQzFhV.enabled)
		{
			xnyKNSfAwxCMcZnCWAZbtfQYBOXh.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0);
			goto IL_001f;
		}
		goto IL_0041;
		IL_0041:
		ObhCjFJhZIEApHxufzsoEcSKuXDF(P_0);
		dFKEfSrJBCfhknqJeAOwbilhqbZd(P_0);
		int num = 1052476816;
		goto IL_0024;
		IL_001f:
		num = 1052476819;
		goto IL_0024;
		IL_0024:
		while (true)
		{
			switch (num ^ 0x3EBB8591)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				goto IL_0041;
			case 1:
				qTKJmxoqbugShRsjWFlkNISfBeOh.BljuFFSOcakAvNhCvNvtTNfKYUO(P_0, ReInput.currentFrame);
				if (rbLrKKlnCVgbRlVXExpTYHjqZTw)
				{
					ORArIaDcoRucmNkrmxGPXbLKCaiI();
					num = 1052476817;
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

	public CvKbBDBykgOtczqdWEjAImsohWR OUnbwyZZsFhhoRnwAIfHsGBBrEe(int P_0, string P_1, bool P_2)
	{
		int num = AQANKVsSPXqhjRcrczEkdvuTzzw.tZuNWtSCplPhyqDRGNVBVrTnWqi(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return tRpsseUjStqkQeJlxaKdeaJnHCWi[num];
		}
		if (P_0 < 0 || P_0 >= UAitzniEqWVvtfBkcdBcuATsmUv)
		{
			return null;
		}
		return MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num];
	}

	public CvKbBDBykgOtczqdWEjAImsohWR OUnbwyZZsFhhoRnwAIfHsGBBrEe(int P_0, int P_1, bool P_2)
	{
		int num = AQANKVsSPXqhjRcrczEkdvuTzzw.tZuNWtSCplPhyqDRGNVBVrTnWqi(P_1, P_2);
		if (num < 0)
		{
			return null;
		}
		if (P_0 == 9999999)
		{
			return tRpsseUjStqkQeJlxaKdeaJnHCWi[num];
		}
		return MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num];
	}

	public void pQXjcKMGYFWhIbqKYqxvIuNhDSM(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		while (P_0.sourceJoystick != null)
		{
			while (true)
			{
				IL_008d:
				nZhbitNCKUHtixjXUCKWfBgoLsY nZhbitNCKUHtixjXUCKWfBgoLsY2 = nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg;
				int num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0.sourceJoystick.rewiredId, nZhbitNCKUHtixjXUCKWfBgoLsY2);
				int num2 = 1895620364;
				while (true)
				{
					switch (num2 ^ 0x70FCDF08)
					{
					case 0:
						num2 = 1895620365;
						continue;
					case 5:
						break;
					case 4:
						goto IL_0046;
					case 3:
						if (num < 0)
						{
							return;
						}
						goto default;
					case 1:
						nZhbitNCKUHtixjXUCKWfBgoLsY2 = nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM;
						num2 = 1895620362;
						continue;
					case 2:
						num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0.sourceJoystick.rewiredId, nZhbitNCKUHtixjXUCKWfBgoLsY2);
						num2 = 1895620363;
						continue;
					case 6:
						goto IL_008d;
					default:
					{
						Joystick joystick = ((nZhbitNCKUHtixjXUCKWfBgoLsY2 != nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg) ? (joystick = txiWVMTSpznmRIqXyBdcjgrBpyA[num]) : (joystick = QsAVjdFzwBBIEaNvFSzfnbhSbwL[num]));
						joystick.UpdateControllerInfo(P_0);
						return;
					}
					}
					break;
					IL_0046:
					int num3;
					if (num < 0)
					{
						num2 = 1895620361;
						num3 = num2;
					}
					else
					{
						num2 = 1895620363;
						num3 = num2;
					}
				}
				break;
			}
		}
	}

	public bool QoXuWditVGaBnyIgKMTrQMvORVG(int P_0, nZhbitNCKUHtixjXUCKWfBgoLsY P_1)
	{
		if (tQtXQZViknwzHLbzDVaijDZCPZi(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int tQtXQZViknwzHLbzDVaijDZCPZi(int P_0, nZhbitNCKUHtixjXUCKWfBgoLsY P_1)
	{
		if (P_1 == nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg)
		{
			goto IL_0006;
		}
		goto IL_00bd;
		IL_0006:
		int num = 1272068939;
		goto IL_000b;
		IL_000b:
		int count2 = default(int);
		int num3 = default(int);
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ 0x4BD23B4A)
			{
			case 5:
				break;
			case 8:
				goto IL_0047;
			case 7:
				goto IL_0062;
			case 3:
				count2 = txiWVMTSpznmRIqXyBdcjgrBpyA.Count;
				num3 = 0;
				num = 1272068928;
				continue;
			case 2:
				return num3;
			case 10:
				goto IL_00a5;
			case 4:
				goto IL_00bd;
			case 9:
				return num2;
			case 1:
				count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
				num2 = 0;
				num = 1272068938;
				continue;
			case 0:
				if (num2 >= count)
				{
					num = 1272068940;
					continue;
				}
				goto IL_0062;
			default:
				return -1;
			}
			break;
			IL_00a5:
			int num4;
			if (num3 >= count2)
			{
				num = 1272068940;
				num4 = num;
			}
			else
			{
				num = 1272068930;
				num4 = num;
			}
			continue;
			IL_0062:
			if (QsAVjdFzwBBIEaNvFSzfnbhSbwL[num2].id == P_0)
			{
				num = 1272068931;
				continue;
			}
			num2++;
			num = 1272068938;
			continue;
			IL_0047:
			if (txiWVMTSpznmRIqXyBdcjgrBpyA[num3].id == P_0)
			{
				num = 1272068936;
				continue;
			}
			num3++;
			num = 1272068928;
		}
		goto IL_0006;
		IL_00bd:
		int num5;
		if (P_1 != nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM)
		{
			num = 1272068940;
			num5 = num;
		}
		else
		{
			num = 1272068937;
			num5 = num;
		}
		goto IL_000b;
	}

	public int tQtXQZViknwzHLbzDVaijDZCPZi(Guid P_0, nZhbitNCKUHtixjXUCKWfBgoLsY P_1)
	{
		int count = default(int);
		if (P_1 == nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg)
		{
			count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
			goto IL_0012;
		}
		goto IL_0089;
		IL_0089:
		int count2 = default(int);
		int num = default(int);
		int num2;
		if (P_1 == nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM)
		{
			count2 = txiWVMTSpznmRIqXyBdcjgrBpyA.Count;
			num = 0;
			num2 = -1693051431;
			goto IL_0017;
		}
		goto IL_00fa;
		IL_0012:
		num2 = -1693051425;
		goto IL_0017;
		IL_0017:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -1693051426)
			{
			case 0:
				break;
			case 5:
				return num3;
			case 9:
				num2 = -1693051432;
				continue;
			case 4:
				goto IL_0063;
			case 2:
				goto IL_0089;
			case 8:
				goto IL_00a5;
			case 6:
				if (num3 >= count)
				{
					num2 = -1693051427;
					continue;
				}
				goto IL_00a5;
			case 7:
				goto IL_00d6;
			case 1:
				num3 = 0;
				num2 = -1693051433;
				continue;
			default:
				goto IL_00fa;
			}
			break;
			IL_00d6:
			int num4;
			if (num < count2)
			{
				num2 = -1693051430;
				num4 = num2;
			}
			else
			{
				num2 = -1693051427;
				num4 = num2;
			}
			continue;
			IL_00a5:
			if (!(QsAVjdFzwBBIEaNvFSzfnbhSbwL[num3].deviceInstanceGuid == P_0))
			{
				num3++;
				num2 = -1693051432;
			}
			else
			{
				num2 = -1693051429;
			}
			continue;
			IL_0063:
			if (txiWVMTSpznmRIqXyBdcjgrBpyA[num].deviceInstanceGuid == P_0)
			{
				return num;
			}
			num++;
			num2 = -1693051431;
		}
		goto IL_0012;
		IL_00fa:
		return -1;
	}

	public bool AbjeGwkBjjcYCElWanOtKWUqjLma(int P_0)
	{
		if (DNIbNpfTDbKAcBnTITcSogQbrSKz(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int DNIbNpfTDbKAcBnTITcSogQbrSKz(int P_0)
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = 1171301424;
				num3 = num2;
			}
			else
			{
				num2 = 1171301427;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x45D0A431)
				{
				case 0:
					num2 = 1171301424;
					continue;
				case 1:
					if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num].id == P_0)
					{
						return num;
					}
					num++;
					num2 = 1171301426;
					continue;
				case 3:
					break;
				default:
					return -1;
				}
				break;
			}
		}
	}

	public int DNIbNpfTDbKAcBnTITcSogQbrSKz(Guid P_0)
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num].deviceInstanceGuid == P_0)
				{
					num2 = 1742555081;
				}
				else
				{
					num++;
					num2 = 1742555082;
				}
				while (true)
				{
					switch (num2 ^ 0x67DD47CB)
					{
					case 0:
						num2 = 1742555080;
						continue;
					case 3:
						break;
					case 2:
						return num;
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
		return -1;
	}

	public void zhGxfbZxWjAFIPgTHcFcOdkiAPT(BridgedController P_0)
	{
		NWSLpzjARXAZockcSxXYkguBzrbQ(P_0);
	}

	public void RddwpyrUWFEoRsZUxnPYyeqToGd(int P_0)
	{
		int num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0, nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg);
		OLTyZrKXYzECMfpBGePUsNrPmKS(num);
	}

	public int tLjNNUMmtSAassYXZEJDlDDsGmw()
	{
		return rAaSPKeLizUyGamANAuDNbapmjz++;
	}

	public IList<InputBehavior> xAhFDuGUtlbNqDBBiBCcWEZTAixf(int P_0)
	{
		if (!nmUPqatzdoguCudPRBhWxuXdCLrE.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return nmUPqatzdoguCudPRBhWxuXdCLrE[P_0].ZivxtkxVNTcLITMeAKdXFjLbtMZ;
	}

	public InputBehavior cvAZIXVvcDmlIQeyvbGcyaWKBPG(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return cvAZIXVvcDmlIQeyvbGcyaWKBPG(P_0, inputBehaviorId);
	}

	public InputBehavior cvAZIXVvcDmlIQeyvbGcyaWKBPG(int P_0, int P_1)
	{
		if (!nmUPqatzdoguCudPRBhWxuXdCLrE.ContainsKey(P_0))
		{
			goto IL_000e;
		}
		IList<InputBehavior> zivxtkxVNTcLITMeAKdXFjLbtMZ = nmUPqatzdoguCudPRBhWxuXdCLrE[P_0].ZivxtkxVNTcLITMeAKdXFjLbtMZ;
		int num = -1592505197;
		goto IL_0013;
		IL_0013:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1592505199)
			{
			case 5:
				break;
			case 3:
				return null;
			case 1:
			{
				int num3;
				if (num2 >= zivxtkxVNTcLITMeAKdXFjLbtMZ.Count)
				{
					num = -1592505199;
					num3 = num;
				}
				else
				{
					num = -1592505195;
					num3 = num;
				}
				continue;
			}
			case 4:
				if (zivxtkxVNTcLITMeAKdXFjLbtMZ[num2].id == P_1)
				{
					return zivxtkxVNTcLITMeAKdXFjLbtMZ[num2];
				}
				num2++;
				num = -1592505200;
				continue;
			case 2:
				num2 = 0;
				num = -1592505200;
				continue;
			default:
				return null;
			}
			break;
		}
		goto IL_000e;
		IL_000e:
		num = -1592505198;
		goto IL_0013;
	}

	public Joystick oDPKIGALeDTydQUPLxZoBnImPhj(int P_0, bool P_1 = false)
	{
		int num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0, nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg);
		if (num >= 0)
		{
			return QsAVjdFzwBBIEaNvFSzfnbhSbwL[num];
		}
		if (P_1)
		{
			num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0, nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM);
			if (num >= 0)
			{
				return txiWVMTSpznmRIqXyBdcjgrBpyA[num];
			}
		}
		return null;
	}

	public Joystick oDPKIGALeDTydQUPLxZoBnImPhj(Guid P_0, bool P_1 = false)
	{
		int num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0, nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg);
		if (num >= 0)
		{
			goto IL_000d;
		}
		int num2;
		if (P_1)
		{
			num2 = 2022635291;
			goto IL_0012;
		}
		goto IL_005c;
		IL_005c:
		return null;
		IL_0042:
		num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0, nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM);
		if (num >= 0)
		{
			return txiWVMTSpznmRIqXyBdcjgrBpyA[num];
		}
		goto IL_005c;
		IL_000d:
		num2 = 2022635290;
		goto IL_0012;
		IL_0012:
		switch (num2 ^ 0x788EF71B)
		{
		case 2:
			break;
		case 1:
			return QsAVjdFzwBBIEaNvFSzfnbhSbwL[num];
		default:
			goto IL_0042;
		}
		goto IL_000d;
	}

	public Joystick[] LgSDfARcRmJiTVRtHrmjdSoFeYe()
	{
		int count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
		Joystick[] array = default(Joystick[]);
		int num2 = default(int);
		while (true)
		{
			int num = -1084739012;
			while (true)
			{
				switch (num ^ -1084739011)
				{
				case 2:
					break;
				case 4:
					array[num2] = QsAVjdFzwBBIEaNvFSzfnbhSbwL[num2];
					num2++;
					num = -1084739010;
					continue;
				case 0:
					num2 = 0;
					num = -1084739010;
					continue;
				case 1:
					if (count == 0)
					{
						return null;
					}
					array = new Joystick[count];
					num = -1084739011;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	public string[] ebrZMhoLdviQYAzurIbzzrUBFjP()
	{
		int count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
		string[] array = default(string[]);
		int num2 = default(int);
		while (true)
		{
			int num = -993302129;
			while (true)
			{
				switch (num ^ -993302133)
				{
				case 0:
					break;
				case 1:
					array[num2] = QsAVjdFzwBBIEaNvFSzfnbhSbwL[num2].name;
					num = -993302131;
					continue;
				case 5:
					return null;
				case 6:
					num2++;
					num = -993302135;
					continue;
				case 4:
					if (count != 0)
					{
						array = new string[count];
						num = -993302132;
					}
					else
					{
						num = -993302130;
					}
					continue;
				case 2:
				{
					int num3;
					if (num2 < count)
					{
						num = -993302134;
						num3 = num;
					}
					else
					{
						num = -993302136;
						num3 = num;
					}
					continue;
				}
				case 7:
					num2 = 0;
					num = -993302135;
					continue;
				default:
					return array;
				}
				break;
			}
		}
	}

	public CustomController CqvNvMDsuksRPQaUdVrxJQmSQnk(int P_0)
	{
		int num = DNIbNpfTDbKAcBnTITcSogQbrSKz(P_0);
		if (num < 0)
		{
			return null;
		}
		return hBtIKAiElSFkNtDRgRmKCWbkUegN[num];
	}

	public CustomController CqvNvMDsuksRPQaUdVrxJQmSQnk(Guid P_0)
	{
		int num = DNIbNpfTDbKAcBnTITcSogQbrSKz(P_0);
		if (num < 0)
		{
			return null;
		}
		return hBtIKAiElSFkNtDRgRmKCWbkUegN[num];
	}

	public CustomController[] vWGAgIZMhEZgzPXrkOErxEbnUNx()
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		CustomController[] array = default(CustomController[]);
		int num2 = default(int);
		while (true)
		{
			int num = 1039951269;
			while (true)
			{
				switch (num ^ 0x3DFC65A6)
				{
				case 2:
					break;
				case 3:
					if (count == 0)
					{
						num = 1039951266;
						continue;
					}
					array = new CustomController[count];
					num2 = 0;
					num = 1039951267;
					continue;
				case 1:
					array[num2] = hBtIKAiElSFkNtDRgRmKCWbkUegN[num2];
					num = 1039951270;
					continue;
				case 0:
					num2++;
					num = 1039951267;
					continue;
				case 4:
					return null;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public string[] fkSRaHvrnugBoMmQisjEZdMDIEo()
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		if (count == 0)
		{
			goto IL_000f;
		}
		string[] array = new string[count];
		int num = 0;
		int num2 = 995404707;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x3B54ABA0)
			{
			case 0:
				break;
			case 1:
				return null;
			case 2:
				goto IL_0043;
			default:
				if (num < count)
				{
					goto IL_0043;
				}
				return array;
			}
			break;
			IL_0043:
			array[num] = hBtIKAiElSFkNtDRgRmKCWbkUegN[num].name;
			num++;
			num2 = 995404707;
		}
		goto IL_000f;
		IL_000f:
		num2 = 995404705;
		goto IL_0014;
	}

	public CustomController niQrHAQljuFoiNkqEumUiOlpjNB(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int lJGmoPjWlZhCnfYmPrnrnNrpiFd = nextCustomControllerId;
		BQyGYxvmdrkvdxOAtdNlcnVGzxWK bQyGYxvmdrkvdxOAtdNlcnVGzxWK = default(BQyGYxvmdrkvdxOAtdNlcnVGzxWK);
		while (true)
		{
			int num = 650585332;
			while (true)
			{
				switch (num ^ 0x26C724F5)
				{
				case 4:
					break;
				case 2:
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.YiIUvWfzvblblULoEBxCZANzFXz = customControllerById.id.ToString();
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.wNPKZbISdRnlUJccaUfbBMfnSsA = customControllerById.fSqpRPKmvZEbSyvCnabcPGncEMe();
					num = 650585328;
					continue;
				case 3:
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.ztxLGYqvsFLrsKkETXDfycBhNF = customControllerById.descriptiveName;
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.LnnEMtEzQZNQVvMexVVfLUASaXWH = customControllerById.name;
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.ijxelHigybruBiYdNSiiNzGQTwsf = customControllerById.axisCount;
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.vgSbQnhkfGJDrjOShKPojdhsCSkQ = customControllerById.buttonCount;
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.lJGmoPjWlZhCnfYmPrnrnNrpiFd = lJGmoPjWlZhCnfYmPrnrnNrpiFd;
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.EFHfUkVHlpfMiRjveZJDpSTYIai = customControllerById.id;
					num = 650585333;
					continue;
				case 0:
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.ATDQbOTPxeHkkBLoRmWzxDgmajNA = customControllerById.typeGuid;
					num = 650585335;
					continue;
				case 1:
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK = new BQyGYxvmdrkvdxOAtdNlcnVGzxWK();
					bQyGYxvmdrkvdxOAtdNlcnVGzxWK.pjmDqcGcEdmXbvnkITKNjUFiEooD = InputSource.Custom;
					num = 650585334;
					continue;
				default:
				{
					BQyGYxvmdrkvdxOAtdNlcnVGzxWK data = bQyGYxvmdrkvdxOAtdNlcnVGzxWK;
					CustomController customController = new CustomController(data);
					eVEvqWwHYWffmAvFhiIHiCYQKtYI(customController);
					return customController;
				}
				}
				break;
			}
		}
	}

	public bool rrfKwKinUgPnkVRDGRIBwRBvdyl(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return aUKDbmOXgEhxGqWknoZkFlKUkao(P_0);
	}

	public CustomController ilnQPUornmBtuAyaCUdThiAEKyn(int P_0)
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num].sourceControllerId == P_0)
				{
					return hBtIKAiElSFkNtDRgRmKCWbkUegN[num];
				}
				num++;
				int num2 = 1974945152;
				while (true)
				{
					switch (num2 ^ 0x75B74582)
					{
					case 0:
						num2 = 1974945155;
						continue;
					case 1:
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

	public CustomController jMjXEiRIYuqWQbZXzbcYJgyFcBz(string P_0)
	{
		int count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = 1783992405;
				num3 = num2;
			}
			else
			{
				num2 = 1783992404;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x6A559056)
				{
				case 0:
					num2 = 1783992405;
					continue;
				case 3:
					if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return hBtIKAiElSFkNtDRgRmKCWbkUegN[num];
					}
					num++;
					num2 = 1783992407;
					continue;
				case 1:
					break;
				default:
					return null;
				}
				break;
			}
		}
	}

	public IEnumerable<CustomController> cNzaKqJoNJaTSOODCykXBIIhkAQG(int P_0)
	{
		ghroXXFstlvjelMsuGPgKOZNLbz ghroXXFstlvjelMsuGPgKOZNLbz2 = new ghroXXFstlvjelMsuGPgKOZNLbz(-2);
		ghroXXFstlvjelMsuGPgKOZNLbz2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
		ghroXXFstlvjelMsuGPgKOZNLbz2.pBxznzuVLJfgWHNIseDtNacTYTS = P_0;
		return ghroXXFstlvjelMsuGPgKOZNLbz2;
	}

	public IEnumerable<CustomController> KPMxtcTeWlhXbsEfrBxvfMIMhniv(string P_0)
	{
		yASJUUgxmIDcJgcLidJJkGZfAsU yASJUUgxmIDcJgcLidJJkGZfAsU2 = new yASJUUgxmIDcJgcLidJJkGZfAsU(-2);
		while (true)
		{
			int num = 2595923;
			while (true)
			{
				switch (num ^ 0x279C50)
				{
				case 0:
					break;
				case 3:
					yASJUUgxmIDcJgcLidJJkGZfAsU2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
					num = 2595921;
					continue;
				case 1:
					yASJUUgxmIDcJgcLidJJkGZfAsU2.PqgqlyVpPbbxVBxonFUFLIlCcziX = P_0;
					num = 2595922;
					continue;
				default:
					return yASJUUgxmIDcJgcLidJJkGZfAsU2;
				}
				break;
			}
		}
	}

	public Controller YVImgJAVYrCFxvRCiDMpssMfsKM(ControllerType P_0, int P_1, bool P_2 = false)
	{
		while (true)
		{
			int num = 2005709662;
			while (true)
			{
				switch (num ^ 0x778CB35F)
				{
				case 0:
					break;
				case 1:
					switch (P_0)
					{
					default:
						goto IL_0036;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return SFYAuTPTwQDVYDMfiGzNbbQzFhV;
					case ControllerType.Mouse:
						return xuMdUThDXJJnvRMJqvyVfthJBBhD;
					}
					goto default;
				case 2:
					if (P_0 == ControllerType.Custom)
					{
						return CqvNvMDsuksRPQaUdVrxJQmSQnk(P_1);
					}
					throw new NotImplementedException();
				default:
					return oDPKIGALeDTydQUPLxZoBnImPhj(P_1, P_2);
				}
				break;
				IL_0036:
				num = 2005709661;
			}
		}
	}

	public Controller YVImgJAVYrCFxvRCiDMpssMfsKM(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return YVImgJAVYrCFxvRCiDMpssMfsKM(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return YVImgJAVYrCFxvRCiDMpssMfsKM(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller YVImgJAVYrCFxvRCiDMpssMfsKM(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			goto IL_000d;
		}
		int num;
		Controller result = default(Controller);
		if (SFYAuTPTwQDVYDMfiGzNbbQzFhV.deviceInstanceGuid == P_0)
		{
			num = 93421670;
		}
		else
		{
			if (xuMdUThDXJJnvRMJqvyVfthJBBhD.deviceInstanceGuid == P_0)
			{
				return xuMdUThDXJJnvRMJqvyVfthJBBhD;
			}
			if ((result = oDPKIGALeDTydQUPLxZoBnImPhj(P_0, P_1)) == null)
			{
				if ((result = CqvNvMDsuksRPQaUdVrxJQmSQnk(P_0)) != null)
				{
					return result;
				}
				return null;
			}
			num = 93421669;
		}
		goto IL_0012;
		IL_000d:
		num = 93421668;
		goto IL_0012;
		IL_0012:
		switch (num ^ 0x5918065)
		{
		case 2:
			break;
		case 1:
			return null;
		case 3:
			return SFYAuTPTwQDVYDMfiGzNbbQzFhV;
		default:
			return result;
		}
		goto IL_000d;
	}

	public Controller[] zYeDZNDqbcUttGQRqODIiybceUtD(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return LgSDfARcRmJiTVRtHrmjdSoFeYe();
		case ControllerType.Keyboard:
		{
			Controller[] array = new Controller[1];
			int num = 1300336111;
			while (true)
			{
				switch (num ^ 0x4D818DEC)
				{
				case 0:
					num = 1300336110;
					continue;
				case 2:
					break;
				case 3:
					array[0] = SFYAuTPTwQDVYDMfiGzNbbQzFhV;
					num = 1300336109;
					continue;
				default:
					return array;
				}
				break;
			}
			goto case ControllerType.Joystick;
		}
		case ControllerType.Mouse:
			return new Controller[1] { xuMdUThDXJJnvRMJqvyVfthJBBhD };
		case ControllerType.Custom:
			return vWGAgIZMhEZgzPXrkOErxEbnUNx();
		default:
			throw new NotImplementedException();
		}
	}

	public string[] CsxMNxOCPPThAwZqmhOknsLIWNA(ControllerType P_0)
	{
		int num;
		string[] array2 = default(string[]);
		string[] array = default(string[]);
		switch (P_0)
		{
		default:
			num = 84824793;
			goto IL_0019;
		case ControllerType.Mouse:
			array2 = new string[1];
			num = 84824795;
			goto IL_0019;
		case ControllerType.Joystick:
			goto IL_0058;
		case ControllerType.Keyboard:
			{
				array = new string[1];
				num = 84824792;
				goto IL_0019;
			}
			IL_0019:
			switch (num ^ 0x50E52D8)
			{
			case 2:
				break;
			case 0:
				array[0] = SFYAuTPTwQDVYDMfiGzNbbQzFhV.name;
				return array;
			case 4:
				goto IL_0058;
			case 1:
				goto IL_006d;
			default:
				array2[0] = xuMdUThDXJJnvRMJqvyVfthJBBhD.name;
				return array2;
			}
			goto default;
			IL_006d:
			if (P_0 == ControllerType.Custom)
			{
				return fkSRaHvrnugBoMmQisjEZdMDIEo();
			}
			throw new NotImplementedException();
			IL_0058:
			return ebrZMhoLdviQYAzurIbzzrUBFjP();
		}
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			goto IL_0008;
		}
		goto IL_0047;
		IL_0008:
		int num = -1735559412;
		goto IL_000d;
		IL_000d:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = default(sbGjBSYUCHFmdsRwzJKaaHSDFDN);
		while (true)
		{
			switch (num ^ -1735559416)
			{
			case 0:
				break;
			case 4:
				HTrjbVpbkEHVkbkenPcRqGNLFG = true;
				num = -1735559414;
				continue;
			case 1:
				if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
				{
					return;
				}
				goto default;
			case 2:
				goto IL_0047;
			default:
				sbGjBSYUCHFmdsRwzJKaaHSDFDN2.VLruXdLRDGFfXmmERvMAbDydBTo(P_1, P_2, InputActionEventType.Update, null);
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0047:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		num = -1735559415;
		goto IL_000d;
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			HTrjbVpbkEHVkbkenPcRqGNLFG = true;
			while (true)
			{
				switch (0x5C998A7F ^ 0x5C998A7E)
				{
				case 2:
					break;
				case 1:
					goto end_IL_000f;
				default:
					goto IL_0040;
				}
				continue;
				end_IL_000f:
				break;
			}
		}
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
		{
			return;
		}
		goto IL_0040;
		IL_0040:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2.VLruXdLRDGFfXmmERvMAbDydBTo(P_1, P_2, InputActionEventType.Update, P_3, null);
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			HTrjbVpbkEHVkbkenPcRqGNLFG = true;
			goto IL_000f;
		}
		goto IL_0031;
		IL_004b:
		int num = default(int);
		jbRicOOoCAriKlLHtGcLHrLuonGp(P_0, P_1, P_2, num);
		int num2 = -1023477741;
		goto IL_0014;
		IL_000f:
		num2 = -1023477742;
		goto IL_0014;
		IL_0014:
		switch (num2 ^ -1023477741)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			goto IL_0031;
		case 3:
			goto IL_004b;
		case 0:
			return;
		}
		goto IL_000f;
		IL_0031:
		num = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_3);
		if (num < 0)
		{
			return;
		}
		goto IL_004b;
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			HTrjbVpbkEHVkbkenPcRqGNLFG = true;
			goto IL_000f;
		}
		goto IL_0031;
		IL_0044:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = default(sbGjBSYUCHFmdsRwzJKaaHSDFDN);
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2.VLruXdLRDGFfXmmERvMAbDydBTo(P_1, P_2, P_3, P_4);
		int num = 1433769340;
		goto IL_0014;
		IL_000f:
		num = 1433769342;
		goto IL_0014;
		IL_0014:
		switch (num ^ 0x5575957D)
		{
		case 0:
			break;
		default:
			return;
		case 3:
			goto IL_0031;
		case 2:
			goto IL_0044;
		case 1:
			return;
		}
		goto IL_000f;
		IL_0031:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
		{
			return;
		}
		goto IL_0044;
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			goto IL_0008;
		}
		goto IL_0051;
		IL_0008:
		int num = 1874893564;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x6FC09AFD)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				HTrjbVpbkEHVkbkenPcRqGNLFG = true;
				num = 1874893565;
				continue;
			case 4:
				goto IL_003c;
			case 0:
				goto IL_0051;
			case 2:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0051:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
		{
			return;
		}
		goto IL_003c;
		IL_003c:
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2.VLruXdLRDGFfXmmERvMAbDydBTo(P_1, P_2, P_3, P_4, P_5);
		num = 1874893567;
		goto IL_000d;
	}

	public void jbRicOOoCAriKlLHtGcLHrLuonGp(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!HTrjbVpbkEHVkbkenPcRqGNLFG)
		{
			goto IL_0008;
		}
		goto IL_0040;
		IL_0008:
		int num = -414829281;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -414829283)
			{
			case 4:
				break;
			default:
				return;
			case 2:
				HTrjbVpbkEHVkbkenPcRqGNLFG = true;
				num = -414829288;
				continue;
			case 5:
				goto IL_0040;
			case 1:
				if (num2 < 0)
				{
					return;
				}
				goto case 0;
			case 0:
				jbRicOOoCAriKlLHtGcLHrLuonGp(P_0, P_1, P_2, P_3, num2, P_5);
				num = -414829282;
				continue;
			case 3:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0040:
		num2 = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_4);
		num = -414829284;
		goto IL_000d;
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		while (true)
		{
			int num = 439073109;
			while (true)
			{
				switch (num ^ 0x1A2BB957)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
					{
						goto IL_0035;
					}
					return;
				case 3:
					goto IL_0035;
				case 1:
					return;
				}
				break;
				IL_0035:
				sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1);
				num = 439073110;
			}
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
		{
			sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2);
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_2);
		if (num >= 0)
		{
			sUstSfbWDGyCdmwokkHCprmTxlg(P_0, P_1, num);
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		while (true)
		{
			switch (-1708980361 ^ -1708980362)
			{
			case 2:
				continue;
			case 1:
				if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
				{
					return;
				}
				break;
			}
			break;
		}
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2);
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
		{
			while (true)
			{
				switch (0xF1BDF89 ^ 0xF1BDF88)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2);
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
		{
			sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2, P_3);
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_3);
		if (num < 0)
		{
			goto IL_0012;
		}
		goto IL_003c;
		IL_0012:
		int num2 = 1767876447;
		goto IL_0017;
		IL_0017:
		switch (num2 ^ 0x695FA75D)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			return;
		case 3:
			goto IL_003c;
		case 1:
			return;
		}
		goto IL_0012;
		IL_003c:
		sUstSfbWDGyCdmwokkHCprmTxlg(P_0, P_1, P_2, num);
		num2 = 1767876444;
		goto IL_0017;
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 == null)
		{
			return;
		}
		while (true)
		{
			sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2, P_3);
			int num = -564812231;
			while (true)
			{
				switch (num ^ -564812231)
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
				num = -564812232;
			}
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_3);
		while (true)
		{
			switch (-77903829 ^ -77903830)
			{
			case 0:
				continue;
			case 1:
				if (num < 0)
				{
					return;
				}
				break;
			}
			break;
		}
		sUstSfbWDGyCdmwokkHCprmTxlg(P_0, P_1, P_2, num);
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		while (true)
		{
			int num = 793952910;
			while (true)
			{
				switch (num ^ 0x2F52C28F)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
					{
						goto IL_0035;
					}
					return;
				case 0:
					goto IL_0035;
				case 3:
					return;
				}
				break;
				IL_0035:
				sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2, P_3);
				num = 793952908;
			}
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
		{
			sbGjBSYUCHFmdsRwzJKaaHSDFDN2.mwFDXXqitzdkdQJZVuGLgThFXxm(P_1, P_2, P_3, P_4);
		}
	}

	public void sUstSfbWDGyCdmwokkHCprmTxlg(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw.xYXbAPBVsnYFHcoavKDHwdxrYET(P_4);
		while (true)
		{
			switch (-1941421046 ^ -1941421048)
			{
			case 0:
				continue;
			case 2:
				if (num < 0)
				{
					return;
				}
				break;
			}
			break;
		}
		sUstSfbWDGyCdmwokkHCprmTxlg(P_0, P_1, P_2, P_3, num);
	}

	public void hOdaXEgdhycoWsyTWxITFTWFYTe(int P_0)
	{
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(P_0);
		while (true)
		{
			int num = -138636439;
			while (true)
			{
				switch (num ^ -138636440)
				{
				case 0:
					break;
				case 1:
				{
					int num2;
					if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2 != null)
					{
						num = -138636438;
						num2 = num;
					}
					else
					{
						num = -138636437;
						num2 = num;
					}
					continue;
				}
				case 3:
					return;
				default:
					sbGjBSYUCHFmdsRwzJKaaHSDFDN2.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					return;
				}
				break;
			}
		}
	}

	public bool IbmBAgzbupXnIyiaYFQJkCvIUhiE(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_003d;
		}
		int num2;
		int actionCount = default(int);
		int num3 = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				num2 = -277809415;
			}
			else
			{
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num3 = 0;
				num2 = -277809414;
			}
			goto IL_0011;
		}
		goto IL_00a5;
		IL_003d:
		if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
		{
			return false;
		}
		goto IL_008c;
		IL_008c:
		if (!tRpsseUjStqkQeJlxaKdeaJnHCWi[num].OMsDoddGLoMsnAOixNusrDCoKsdq())
		{
			num++;
			num2 = -277809413;
		}
		else
		{
			num2 = -277809411;
		}
		goto IL_0011;
		IL_00a5:
		return false;
		IL_0011:
		while (true)
		{
			switch (num2 ^ -277809413)
			{
			case 5:
				num2 = -277809409;
				continue;
			case 0:
				break;
			case 6:
				return true;
			case 3:
				goto IL_006b;
			case 4:
				goto IL_008c;
			case 2:
				goto IL_00a5;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				goto IL_006b;
			}
			break;
			IL_006b:
			if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num3].OMsDoddGLoMsnAOixNusrDCoKsdq())
			{
				return true;
			}
			num3++;
			num2 = -277809414;
		}
		goto IL_003d;
	}

	public bool WTLfMrjanLAdKiNsTbQoCaoPzGJ(int P_0)
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
			if (P_0 < UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num = 0;
				num2 = -283112446;
			}
			else
			{
				num2 = -283112447;
			}
			goto IL_0010;
		}
		goto IL_006c;
		IL_0010:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -283112442)
			{
			case 0:
				break;
			case 3:
				goto IL_0044;
			case 5:
				return true;
			case 7:
				goto IL_006c;
			case 8:
				goto IL_0083;
			case 1:
				return false;
			case 2:
				num3 = 0;
				num2 = -283112448;
				continue;
			case 6:
				goto IL_00c7;
			default:
				if (num >= actionCount)
				{
					return false;
				}
				goto IL_0044;
			}
			break;
			IL_00c7:
			int num4;
			if (num3 < tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
			{
				num2 = -283112434;
				num4 = num2;
			}
			else
			{
				num2 = -283112441;
				num4 = num2;
			}
			continue;
			IL_0083:
			if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num3].VoFALJiXKwwyQgLPqqsGLZcLBoM())
			{
				return true;
			}
			num3++;
			num2 = -283112448;
			continue;
			IL_0044:
			if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num].VoFALJiXKwwyQgLPqqsGLZcLBoM())
			{
				num2 = -283112445;
				continue;
			}
			num++;
			num2 = -283112446;
		}
		goto IL_000b;
		IL_000b:
		num2 = -283112444;
		goto IL_0010;
		IL_006c:
		return false;
	}

	public bool DoKaQnBjOrPOLANxAeqTBvFJNsPB(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_000d;
		}
		int num2;
		int num3;
		if (P_0 < 0)
		{
			num2 = 1006505029;
			num3 = num2;
		}
		else
		{
			num2 = 1006505031;
			num3 = num2;
		}
		goto IL_0012;
		IL_000d:
		num2 = 1006505025;
		goto IL_0012;
		IL_0012:
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num2 ^ 0x3BFE0C42)
			{
			case 0:
				break;
			case 7:
				return false;
			case 1:
				if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num].zZfNFOMmkwRPDTjWQEBszXZnyS())
				{
					return true;
				}
				num++;
				num2 = 1006505034;
				continue;
			case 6:
				if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num4].zZfNFOMmkwRPDTjWQEBszXZnyS())
				{
					num2 = 1006505035;
					continue;
				}
				num4++;
				num2 = 1006505024;
				continue;
			case 4:
				num2 = 1006505024;
				continue;
			case 9:
				return true;
			case 5:
				if (P_0 < UAitzniEqWVvtfBkcdBcuATsmUv)
				{
					actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
					num4 = 0;
					num2 = 1006505030;
				}
				else
				{
					num2 = 1006505029;
				}
				continue;
			case 8:
				if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
				{
					return false;
				}
				goto case 1;
			case 3:
				num2 = 1006505034;
				continue;
			default:
				if (num4 >= actionCount)
				{
					return false;
				}
				goto case 6;
			}
			break;
		}
		goto IL_000d;
	}

	public bool MzrETVLItnAswRlcRSPZYKWRiJT(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_000d;
		}
		int num2;
		int num3;
		if (P_0 >= 0)
		{
			num2 = -1122548186;
			num3 = num2;
		}
		else
		{
			num2 = -1122548180;
			num3 = num2;
		}
		goto IL_0012;
		IL_000d:
		num2 = -1122548185;
		goto IL_0012;
		IL_0012:
		int actionCount = default(int);
		int num4 = default(int);
		while (true)
		{
			switch (num2 ^ -1122548186)
			{
			case 6:
				break;
			case 9:
			{
				int num5;
				if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
				{
					num2 = -1122548191;
					num5 = num2;
				}
				else
				{
					num2 = -1122548188;
					num5 = num2;
				}
				continue;
			}
			case 2:
				if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num].AAdwUYLeaIBDydaNOceNayNTDMI())
				{
					return true;
				}
				num++;
				num2 = -1122548177;
				continue;
			case 1:
				num2 = -1122548177;
				continue;
			case 3:
				num2 = -1122548189;
				continue;
			case 0:
				if (P_0 >= UAitzniEqWVvtfBkcdBcuATsmUv)
				{
					num2 = -1122548180;
					continue;
				}
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num4 = 0;
				num2 = -1122548187;
				continue;
			case 8:
				return true;
			case 10:
				return false;
			case 4:
				if (!MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num4].AAdwUYLeaIBDydaNOceNayNTDMI())
				{
					num4++;
					num2 = -1122548189;
				}
				else
				{
					num2 = -1122548178;
				}
				continue;
			case 7:
				return false;
			default:
				if (num4 >= actionCount)
				{
					return false;
				}
				goto case 4;
			}
			break;
		}
		goto IL_000d;
	}

	public bool smtYkYbAfoIXOFLgsMvaVIhCaGq(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_000d;
		}
		int num2;
		int num3;
		if (P_0 < 0)
		{
			num2 = -852309998;
			num3 = num2;
		}
		else
		{
			num2 = -852309988;
			num3 = num2;
		}
		goto IL_0012;
		IL_000d:
		num2 = -852309989;
		goto IL_0012;
		IL_0012:
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num2 ^ -852309990)
			{
			case 2:
				break;
			case 1:
				num2 = -852309986;
				continue;
			case 7:
				if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num4].nkChpEwCeyIAcExUuFGdJLElwIA())
				{
					return true;
				}
				num4++;
				num2 = -852309991;
				continue;
			case 0:
				num4 = 0;
				num2 = -852309991;
				continue;
			case 8:
				return false;
			case 6:
				if (P_0 < UAitzniEqWVvtfBkcdBcuATsmUv)
				{
					actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
					num2 = -852309990;
				}
				else
				{
					num2 = -852309998;
				}
				continue;
			case 9:
				if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num].nkChpEwCeyIAcExUuFGdJLElwIA())
				{
					num2 = -852309985;
					continue;
				}
				num++;
				num2 = -852309986;
				continue;
			case 4:
				if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
				{
					return false;
				}
				goto case 9;
			case 5:
				return true;
			default:
				if (num4 >= actionCount)
				{
					return false;
				}
				goto case 7;
			}
			break;
		}
		goto IL_000d;
	}

	public bool ceqSaSruehBGyHlrFHomSLaiCDG(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00a1;
		}
		int actionCount = default(int);
		int num2;
		if (P_0 >= 0)
		{
			if (P_0 < UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num2 = -841993261;
			}
			else
			{
				num2 = -841993262;
			}
			goto IL_0017;
		}
		goto IL_0089;
		IL_00a1:
		if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
		{
			return false;
		}
		goto IL_0043;
		IL_0043:
		if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num].npsYQCyKleLimEhZDAdnaxnwlFNO())
		{
			return true;
		}
		num++;
		num2 = -841993257;
		goto IL_0017;
		IL_0017:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -841993263)
			{
			case 4:
				num2 = -841993264;
				continue;
			case 1:
				break;
			case 5:
				goto IL_005f;
			case 2:
				num3 = 0;
				num2 = -841993263;
				continue;
			case 3:
				goto IL_0089;
			case 6:
				goto IL_00a1;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				goto IL_005f;
			}
			break;
			IL_005f:
			if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num3].npsYQCyKleLimEhZDAdnaxnwlFNO())
			{
				return true;
			}
			num3++;
			num2 = -841993263;
		}
		goto IL_0043;
		IL_0089:
		return false;
	}

	public bool RszOFJKqEaBNMLlhxgigjCwSmHM(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00ae;
		}
		int num2;
		int num3;
		if (P_0 >= 0)
		{
			num2 = 2010291750;
			num3 = num2;
		}
		else
		{
			num2 = 2010291745;
			num3 = num2;
		}
		goto IL_0017;
		IL_00ae:
		if (num >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
		{
			return false;
		}
		goto IL_008f;
		IL_0017:
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num2 ^ 0x77D29E22)
			{
			case 2:
				num2 = 2010291749;
				continue;
			case 3:
				return false;
			case 6:
				break;
			case 4:
				goto IL_007f;
			case 7:
				goto end_IL_0017;
			case 0:
				goto IL_00ae;
			case 1:
				num2 = 2010291751;
				continue;
			default:
				if (num4 >= actionCount)
				{
					return false;
				}
				break;
			}
			if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num4].sqLJephBcMrzUHldDlcYpoVsgfQC())
			{
				return true;
			}
			num4++;
			num2 = 2010291751;
			continue;
			IL_007f:
			if (P_0 < UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num4 = 0;
				num2 = 2010291747;
			}
			else
			{
				num2 = 2010291745;
			}
			continue;
			end_IL_0017:
			break;
		}
		goto IL_008f;
		IL_008f:
		if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num].sqLJephBcMrzUHldDlcYpoVsgfQC())
		{
			return true;
		}
		num++;
		num2 = 2010291746;
		goto IL_0017;
	}

	public bool XqntfOcOEUEGnYUTXRNrcwnKKeW(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_000b;
		}
		int num;
		int actionCount = default(int);
		int num2 = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				num = 1494648502;
			}
			else
			{
				actionCount = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
				num2 = 0;
				num = 1494648499;
			}
			goto IL_0010;
		}
		goto IL_00d7;
		IL_0010:
		int num3 = default(int);
		while (true)
		{
			switch (num ^ 0x591686B7)
			{
			case 0:
				break;
			case 2:
				num3 = 0;
				num = 1494648500;
				continue;
			case 8:
				goto IL_0051;
			case 3:
				num = 1494648511;
				continue;
			case 7:
				goto IL_0074;
			case 4:
				num = 1494648498;
				continue;
			case 9:
				goto IL_009a;
			case 6:
				return false;
			case 1:
				goto IL_00d7;
			default:
				if (num2 >= actionCount)
				{
					return false;
				}
				goto IL_009a;
			}
			break;
			IL_009a:
			if (MVymlrpVDhkWJLuVMNfWHQypaFV[P_0, num2].gzqiXpQjOddOoitBcBObUOtREys())
			{
				return true;
			}
			num2++;
			num = 1494648498;
			continue;
			IL_0074:
			if (tRpsseUjStqkQeJlxaKdeaJnHCWi[num3].gzqiXpQjOddOoitBcBObUOtREys())
			{
				return true;
			}
			num3++;
			num = 1494648511;
			continue;
			IL_0051:
			int num4;
			if (num3 >= tRpsseUjStqkQeJlxaKdeaJnHCWi.Length)
			{
				num = 1494648497;
				num4 = num;
			}
			else
			{
				num = 1494648496;
				num4 = num;
			}
		}
		goto IL_000b;
		IL_000b:
		num = 1494648501;
		goto IL_0010;
		IL_00d7:
		return false;
	}

	public bool LIyeeMahnlUVtdgkFBEwAQnllGj()
	{
		if (!LIyeeMahnlUVtdgkFBEwAQnllGj(xuMdUThDXJJnvRMJqvyVfthJBBhD) && !LIyeeMahnlUVtdgkFBEwAQnllGj(QsAVjdFzwBBIEaNvFSzfnbhSbwL) && !LIyeeMahnlUVtdgkFBEwAQnllGj(SFYAuTPTwQDVYDMfiGzNbbQzFhV))
		{
			return LIyeeMahnlUVtdgkFBEwAQnllGj(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		}
		return true;
	}

	public bool LIyeeMahnlUVtdgkFBEwAQnllGj(ControllerType P_0)
	{
		while (true)
		{
			switch (0x7BABBD8B ^ 0x7BABBD8A)
			{
			case 2:
				continue;
			case 1:
				switch (P_0)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return LIyeeMahnlUVtdgkFBEwAQnllGj(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
				case ControllerType.Mouse:
					return LIyeeMahnlUVtdgkFBEwAQnllGj(xuMdUThDXJJnvRMJqvyVfthJBBhD);
				case ControllerType.Custom:
					return LIyeeMahnlUVtdgkFBEwAQnllGj(hBtIKAiElSFkNtDRgRmKCWbkUegN);
				default:
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return LIyeeMahnlUVtdgkFBEwAQnllGj(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
	}

	public bool PXhWNfUqKGRgGqQAjIeymqlWWgK()
	{
		if (!PXhWNfUqKGRgGqQAjIeymqlWWgK(xuMdUThDXJJnvRMJqvyVfthJBBhD) && !PXhWNfUqKGRgGqQAjIeymqlWWgK(QsAVjdFzwBBIEaNvFSzfnbhSbwL) && !PXhWNfUqKGRgGqQAjIeymqlWWgK(SFYAuTPTwQDVYDMfiGzNbbQzFhV))
		{
			return PXhWNfUqKGRgGqQAjIeymqlWWgK(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		}
		return true;
	}

	public bool PXhWNfUqKGRgGqQAjIeymqlWWgK(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return PXhWNfUqKGRgGqQAjIeymqlWWgK(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
		case ControllerType.Keyboard:
			return PXhWNfUqKGRgGqQAjIeymqlWWgK(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		case ControllerType.Mouse:
			return PXhWNfUqKGRgGqQAjIeymqlWWgK(xuMdUThDXJJnvRMJqvyVfthJBBhD);
		case ControllerType.Custom:
			return PXhWNfUqKGRgGqQAjIeymqlWWgK(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		default:
			throw new NotImplementedException();
		}
	}

	public bool fyepVroCjjqHJkuJjMHXPuIvCFS()
	{
		if (!fyepVroCjjqHJkuJjMHXPuIvCFS(xuMdUThDXJJnvRMJqvyVfthJBBhD) && !fyepVroCjjqHJkuJjMHXPuIvCFS(QsAVjdFzwBBIEaNvFSzfnbhSbwL) && !fyepVroCjjqHJkuJjMHXPuIvCFS(SFYAuTPTwQDVYDMfiGzNbbQzFhV))
		{
			return fyepVroCjjqHJkuJjMHXPuIvCFS(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		}
		return true;
	}

	public bool fyepVroCjjqHJkuJjMHXPuIvCFS(ControllerType P_0)
	{
		while (true)
		{
			switch (0x4E5AF815 ^ 0x4E5AF814)
			{
			case 0:
				continue;
			case 1:
				switch (P_0)
				{
				case ControllerType.Joystick:
					break;
				case ControllerType.Keyboard:
					return fyepVroCjjqHJkuJjMHXPuIvCFS(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
				case ControllerType.Mouse:
					return fyepVroCjjqHJkuJjMHXPuIvCFS(xuMdUThDXJJnvRMJqvyVfthJBBhD);
				case ControllerType.Custom:
					return fyepVroCjjqHJkuJjMHXPuIvCFS(hBtIKAiElSFkNtDRgRmKCWbkUegN);
				default:
					throw new NotImplementedException();
				}
				break;
			}
			break;
		}
		return fyepVroCjjqHJkuJjMHXPuIvCFS(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
	}

	public bool iyiXNefGzEbwVGNxvqGiWRIvdfAx()
	{
		if (!iyiXNefGzEbwVGNxvqGiWRIvdfAx(xuMdUThDXJJnvRMJqvyVfthJBBhD))
		{
			while (true)
			{
				int num = -1001007259;
				while (true)
				{
					switch (num ^ -1001007260)
					{
					case 0:
						break;
					case 1:
						goto IL_002c;
					default:
						return iyiXNefGzEbwVGNxvqGiWRIvdfAx(hBtIKAiElSFkNtDRgRmKCWbkUegN);
					}
					break;
					IL_002c:
					if (iyiXNefGzEbwVGNxvqGiWRIvdfAx(QsAVjdFzwBBIEaNvFSzfnbhSbwL) || iyiXNefGzEbwVGNxvqGiWRIvdfAx(SFYAuTPTwQDVYDMfiGzNbbQzFhV))
					{
						goto end_IL_000e;
					}
					num = -1001007258;
				}
				continue;
				end_IL_000e:
				break;
			}
		}
		return true;
	}

	public bool iyiXNefGzEbwVGNxvqGiWRIvdfAx(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return iyiXNefGzEbwVGNxvqGiWRIvdfAx(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
		case ControllerType.Keyboard:
			return iyiXNefGzEbwVGNxvqGiWRIvdfAx(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		case ControllerType.Mouse:
			return iyiXNefGzEbwVGNxvqGiWRIvdfAx(xuMdUThDXJJnvRMJqvyVfthJBBhD);
		case ControllerType.Custom:
			return iyiXNefGzEbwVGNxvqGiWRIvdfAx(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		default:
			throw new NotImplementedException();
		}
	}

	public bool vLugLglmrrfGnuxieKLTvkVukgB()
	{
		if (!vLugLglmrrfGnuxieKLTvkVukgB(xuMdUThDXJJnvRMJqvyVfthJBBhD))
		{
			while (true)
			{
				int num = -269650627;
				while (true)
				{
					switch (num ^ -269650628)
					{
					case 0:
						break;
					case 1:
						goto IL_002c;
					default:
						return vLugLglmrrfGnuxieKLTvkVukgB(hBtIKAiElSFkNtDRgRmKCWbkUegN);
					}
					break;
					IL_002c:
					if (vLugLglmrrfGnuxieKLTvkVukgB(QsAVjdFzwBBIEaNvFSzfnbhSbwL) || vLugLglmrrfGnuxieKLTvkVukgB(SFYAuTPTwQDVYDMfiGzNbbQzFhV))
					{
						goto end_IL_000e;
					}
					num = -269650626;
				}
				continue;
				end_IL_000e:
				break;
			}
		}
		return true;
	}

	public bool vLugLglmrrfGnuxieKLTvkVukgB(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return vLugLglmrrfGnuxieKLTvkVukgB(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
		case ControllerType.Keyboard:
			return vLugLglmrrfGnuxieKLTvkVukgB(SFYAuTPTwQDVYDMfiGzNbbQzFhV);
		case ControllerType.Mouse:
			return vLugLglmrrfGnuxieKLTvkVukgB(xuMdUThDXJJnvRMJqvyVfthJBBhD);
		case ControllerType.Custom:
			return vLugLglmrrfGnuxieKLTvkVukgB(hBtIKAiElSFkNtDRgRmKCWbkUegN);
		default:
			throw new NotImplementedException();
		}
	}

	private bool LIyeeMahnlUVtdgkFBEwAQnllGj<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 0;
		int num2 = 1401244606;
		goto IL_0008;
		IL_0008:
		T val = default(T);
		while (true)
		{
			switch (num2 ^ 0x53854BBF)
			{
			case 0:
				break;
			case 3:
				if (val.GetAnyButton())
				{
					return true;
				}
				goto IL_003e;
			case 4:
				if (val != null)
				{
					num2 = 1401244604;
					continue;
				}
				goto IL_003e;
			case 2:
				val = P_0[num];
				num2 = 1401244603;
				continue;
			case 5:
				return false;
			default:
				{
					if (num >= count)
					{
						return false;
					}
					goto case 2;
				}
				IL_003e:
				num++;
				num2 = 1401244606;
				continue;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = 1401244602;
		goto IL_0008;
	}

	private bool LIyeeMahnlUVtdgkFBEwAQnllGj(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButton();
	}

	private bool PXhWNfUqKGRgGqQAjIeymqlWWgK<T>(IList<T> P_0) where T : Controller
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
				int num2 = 1210250453;
				while (true)
				{
					switch (num2 ^ 0x4822F4D6)
					{
					case 2:
						num2 = 1210250455;
						continue;
					case 1:
						break;
					case 3:
						goto IL_0041;
					default:
						goto end_IL_0032;
					}
					break;
					IL_0041:
					if (val != null && val.GetAnyButtonDown())
					{
						return true;
					}
					num++;
					num2 = 1210250454;
				}
				continue;
				end_IL_0032:
				break;
			}
		}
		return false;
	}

	private bool PXhWNfUqKGRgGqQAjIeymqlWWgK(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonDown();
	}

	private bool fyepVroCjjqHJkuJjMHXPuIvCFS<T>(IList<T> P_0) where T : Controller
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
				int num2 = -474837542;
				while (true)
				{
					switch (num2 ^ -474837541)
					{
					case 3:
						num2 = -474837543;
						continue;
					case 2:
						break;
					case 1:
						goto IL_0045;
					case 4:
						return true;
					default:
						goto end_IL_0036;
					}
					break;
					IL_0045:
					if (val != null && val.GetAnyButtonUp())
					{
						num2 = -474837537;
						continue;
					}
					num++;
					num2 = -474837541;
				}
				continue;
				end_IL_0036:
				break;
			}
		}
		return false;
	}

	private bool fyepVroCjjqHJkuJjMHXPuIvCFS(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonUp();
	}

	private bool iyiXNefGzEbwVGNxvqGiWRIvdfAx<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 0;
		int num2 = -1279866960;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ -1279866958)
			{
			case 3:
				break;
			case 2:
			{
				int num3;
				if (num < count)
				{
					num2 = -1279866958;
					num3 = num2;
				}
				else
				{
					num2 = -1279866954;
					num3 = num2;
				}
				continue;
			}
			case 0:
			{
				T val = P_0[num];
				if (val != null && val.GetAnyButtonChanged())
				{
					return true;
				}
				num++;
				num2 = -1279866960;
				continue;
			}
			case 1:
				return false;
			default:
				return false;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = -1279866957;
		goto IL_0008;
	}

	private bool iyiXNefGzEbwVGNxvqGiWRIvdfAx(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonChanged();
	}

	private bool vLugLglmrrfGnuxieKLTvkVukgB<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 0;
		int num2 = -1627445330;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ -1627445329)
			{
			case 0:
				break;
			case 2:
				return false;
			case 3:
				return true;
			case 4:
			{
				T val = P_0[num];
				if (val == null || !val.GetAnyButtonPrev())
				{
					num++;
					num2 = -1627445330;
				}
				else
				{
					num2 = -1627445332;
				}
				continue;
			}
			default:
				if (num >= count)
				{
					return false;
				}
				goto case 4;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = -1627445331;
		goto IL_0008;
	}

	private bool vLugLglmrrfGnuxieKLTvkVukgB(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonPrev();
	}

	public Controller fWOauwDIDcWjYxShfcASqWxMgbX()
	{
		Controller lastController = null;
		float lastTime = 0f;
		InputTools.CompareLastActiveController(xuMdUThDXJJnvRMJqvyVfthJBBhD, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(SFYAuTPTwQDVYDMfiGzNbbQzFhV, ref lastController, ref lastTime);
		IList<Joystick> qsAVjdFzwBBIEaNvFSzfnbhSbwL = QsAVjdFzwBBIEaNvFSzfnbhSbwL;
		int num = 0;
		IList<CustomController> list = default(IList<CustomController>);
		int num3 = default(int);
		while (true)
		{
			int num2;
			if (num >= joystickCount)
			{
				list = hBtIKAiElSFkNtDRgRmKCWbkUegN;
				num2 = -942807247;
				goto IL_0036;
			}
			goto IL_00c6;
			IL_0036:
			while (true)
			{
				switch (num2 ^ -942807246)
				{
				case 0:
					num2 = -942807242;
					continue;
				case 8:
					break;
				case 6:
					num++;
					num2 = -942807238;
					continue;
				case 3:
					num3 = 0;
					num2 = -942807245;
					continue;
				case 1:
					goto IL_0097;
				case 2:
					if (lastController == null)
					{
						lastController = SFYAuTPTwQDVYDMfiGzNbbQzFhV;
						num2 = -942807243;
						continue;
					}
					goto default;
				case 4:
					goto IL_00c6;
				case 5:
					InputTools.CompareLastActiveController(list[num3], ref lastController, ref lastTime);
					num3++;
					num2 = -942807245;
					continue;
				default:
					return lastController;
				}
				break;
				IL_0097:
				int num4;
				if (num3 >= customControllerCount)
				{
					num2 = -942807248;
					num4 = num2;
				}
				else
				{
					num2 = -942807241;
					num4 = num2;
				}
			}
			continue;
			IL_00c6:
			InputTools.CompareLastActiveController(qsAVjdFzwBBIEaNvFSzfnbhSbwL[num], ref lastController, ref lastTime);
			num2 = -942807244;
			goto IL_0036;
		}
	}

	public Controller fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType P_0)
	{
		Controller lastController = null;
		float lastTime = 0f;
		int num3 = default(int);
		int count = default(int);
		int num2 = default(int);
		while (true)
		{
			int num = 2122233838;
			while (true)
			{
				switch (num ^ 0x7E7EB7E5)
				{
				case 2:
					break;
				case 8:
					if (num3 >= count)
					{
						num = 2122233832;
						continue;
					}
					goto case 9;
				case 6:
					return Keyboard;
				case 1:
					if (num2 >= count)
					{
						num = 2122233832;
						continue;
					}
					goto case 5;
				case 12:
					throw new NotImplementedException();
				case 10:
					num3++;
					num = 2122233837;
					continue;
				case 5:
					InputTools.CompareLastActiveController(QsAVjdFzwBBIEaNvFSzfnbhSbwL[num2], ref lastController, ref lastTime);
					num = 2122233825;
					continue;
				case 0:
					num = 2122233833;
					continue;
				case 11:
					switch (P_0)
					{
					case ControllerType.Keyboard:
						break;
					case ControllerType.Mouse:
						return Mouse;
					case ControllerType.Custom:
						goto IL_0075;
					default:
						goto IL_00fb;
					case ControllerType.Joystick:
						goto IL_0140;
					}
					goto case 6;
				case 9:
					InputTools.CompareLastActiveController(hBtIKAiElSFkNtDRgRmKCWbkUegN[num3], ref lastController, ref lastTime);
					num = 2122233839;
					continue;
				case 7:
					num3 = 0;
					num = 2122233837;
					continue;
				case 4:
					num2++;
					num = 2122233828;
					continue;
				case 3:
					goto IL_0140;
				default:
					{
						return lastController;
					}
					IL_0140:
					count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
					num2 = 0;
					num = 2122233828;
					continue;
					IL_00fb:
					num = 2122233829;
					continue;
					IL_0075:
					count = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
					num = 2122233826;
					continue;
				}
				break;
			}
		}
	}

	public T fWOauwDIDcWjYxShfcASqWxMgbX<T>() where T : Controller
	{
		Type typeFromHandle = typeof(T);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Joystick) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Keyboard) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Custom) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Mouse) as T;
		}
		throw new NotImplementedException();
	}

	public ControllerType pDhVwRlXXslzovKejqNtCKesixpi()
	{
		Controller controller = fWOauwDIDcWjYxShfcASqWxMgbX();
		if (controller != null)
		{
			return controller.type;
		}
		return ControllerType.Keyboard;
	}

	public void hpFIVZmRfUbbLvulxgYHsvREHbF(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 != null)
		{
			rbLrKKlnCVgbRlVXExpTYHjqZTw = true;
			vWfklDVVhVIXzshDTlzkTcxgKkK.zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_0);
		}
	}

	public void hpFIVZmRfUbbLvulxgYHsvREHbF(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			rbLrKKlnCVgbRlVXExpTYHjqZTw = true;
			vWfklDVVhVIXzshDTlzkTcxgKkK.zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_0, P_1);
			int num = -1507318883;
			while (true)
			{
				switch (num ^ -1507318883)
				{
				case 2:
					goto IL_0004;
				default:
					return;
				case 1:
					break;
				case 0:
					return;
				}
				break;
				IL_0004:
				num = -1507318884;
			}
		}
	}

	public void rnmefIEnbCCusFKatRSGRudhuhmA(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (-552812368 ^ -552812367)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		vWfklDVVhVIXzshDTlzkTcxgKkK.CVhpRdvLyyeigXbiDdVSIsEMkxU(P_0);
	}

	public void YkWbqHcwNGyNxcTHwcOtszqIEMc(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			vWfklDVVhVIXzshDTlzkTcxgKkK.CVhpRdvLyyeigXbiDdVSIsEMkxU(P_0, P_1);
			int num = -1502366290;
			while (true)
			{
				switch (num ^ -1502366289)
				{
				case 0:
					goto IL_0004;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_0004:
				num = -1502366291;
			}
		}
	}

	public void WHyoiTUpMrPmDVgChnkcKWiYlWX()
	{
		vWfklDVVhVIXzshDTlzkTcxgKkK.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
	}

	public void hpFIVZmRfUbbLvulxgYHsvREHbF(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			int num;
			if (P_0 == 9999999)
			{
				dGEaYGcZYLDZJaVkNbUrlqhHiTe.zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_1);
				num = -956909138;
				goto IL_0009;
			}
			goto IL_0066;
			IL_0009:
			while (true)
			{
				switch (num ^ -956909142)
				{
				case 3:
					num = -956909141;
					continue;
				case 1:
					break;
				case 5:
					return;
				case 0:
					tJgUQmUwhQQSvfwPTzFQBcIUXea[P_0].zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_1);
					num = -956909138;
					continue;
				case 2:
					goto IL_0066;
				default:
					rbLrKKlnCVgbRlVXExpTYHjqZTw = true;
					return;
				}
				break;
			}
			continue;
			IL_0066:
			int num2;
			if ((uint)P_0 < (uint)UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				num = -956909142;
				num2 = num;
			}
			else
			{
				num = -956909137;
				num2 = num;
			}
			goto IL_0009;
		}
	}

	public void hpFIVZmRfUbbLvulxgYHsvREHbF(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			IL_0055:
			int num;
			if (P_0 == 9999999)
			{
				dGEaYGcZYLDZJaVkNbUrlqhHiTe.zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_1, P_2);
				num = 1713899035;
				goto IL_0009;
			}
			goto IL_002e;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x6628061E)
				{
				case 0:
					num = 1713899034;
					continue;
				case 3:
					break;
				case 1:
					goto IL_003f;
				case 4:
					goto IL_0055;
				case 5:
					num = 1713899036;
					continue;
				default:
					rbLrKKlnCVgbRlVXExpTYHjqZTw = true;
					return;
				}
				break;
			}
			goto IL_002e;
			IL_002e:
			if ((uint)P_0 >= (uint)UAitzniEqWVvtfBkcdBcuATsmUv)
			{
				break;
			}
			goto IL_003f;
			IL_003f:
			tJgUQmUwhQQSvfwPTzFQBcIUXea[P_0].zgjQkPlbTEvDLUPBWHvAtcDAtNh(P_1, P_2);
			num = 1713899036;
			goto IL_0009;
		}
	}

	public void rnmefIEnbCCusFKatRSGRudhuhmA(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (P_0 != 9999999)
		{
			while (true)
			{
				IL_0046:
				if ((uint)P_0 >= (uint)UAitzniEqWVvtfBkcdBcuATsmUv)
				{
					return;
				}
				while (true)
				{
					IL_0057:
					tJgUQmUwhQQSvfwPTzFQBcIUXea[P_0].CVhpRdvLyyeigXbiDdVSIsEMkxU(P_1);
					int num = -1105572843;
					while (true)
					{
						switch (num ^ -1105572847)
						{
						case 2:
							num = -1105572848;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							goto IL_0046;
						case 3:
							goto IL_0057;
						case 4:
							return;
						}
						break;
					}
					break;
				}
				break;
			}
		}
		dGEaYGcZYLDZJaVkNbUrlqhHiTe.CVhpRdvLyyeigXbiDdVSIsEMkxU(P_1);
	}

	public void rnmefIEnbCCusFKatRSGRudhuhmA(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			goto IL_0003;
		}
		goto IL_004f;
		IL_0003:
		int num = -308442758;
		goto IL_0008;
		IL_0008:
		switch (num ^ -308442760)
		{
		case 4:
			break;
		case 3:
			return;
		case 0:
			goto IL_0035;
		case 1:
			goto IL_004f;
		case 2:
			return;
		default:
			tJgUQmUwhQQSvfwPTzFQBcIUXea[P_0].CVhpRdvLyyeigXbiDdVSIsEMkxU(P_1, P_2);
			return;
		}
		goto IL_0003;
		IL_004f:
		if (P_0 == 9999999)
		{
			dGEaYGcZYLDZJaVkNbUrlqhHiTe.CVhpRdvLyyeigXbiDdVSIsEMkxU(P_1, P_2);
			return;
		}
		goto IL_0035;
		IL_0035:
		int num2;
		if ((uint)P_0 < (uint)UAitzniEqWVvtfBkcdBcuATsmUv)
		{
			num = -308442755;
			num2 = num;
		}
		else
		{
			num = -308442757;
			num2 = num;
		}
		goto IL_0008;
	}

	public void WHyoiTUpMrPmDVgChnkcKWiYlWX(int P_0)
	{
		if (P_0 == 9999999)
		{
			while (true)
			{
				int num = 486869237;
				while (true)
				{
					switch (num ^ 0x1D0508F6)
					{
					case 4:
						break;
					case 3:
						dGEaYGcZYLDZJaVkNbUrlqhHiTe.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
						num = 486869239;
						continue;
					case 2:
						goto end_IL_0008;
					case 1:
						return;
					default:
						goto IL_0059;
					}
					break;
				}
				continue;
				end_IL_0008:
				break;
			}
		}
		if ((uint)P_0 >= (uint)UAitzniEqWVvtfBkcdBcuATsmUv)
		{
			return;
		}
		goto IL_0059;
		IL_0059:
		tJgUQmUwhQQSvfwPTzFQBcIUXea[P_0].QYwkAfdRMMgAPnyPzHFUdcsKUPp();
	}

	private void ORArIaDcoRucmNkrmxGPXbLKCaiI()
	{
		if (vWfklDVVhVIXzshDTlzkTcxgKkK.xsVRqidKOXHqRYCEunSFFWBYJvE > 0)
		{
			goto IL_0011;
		}
		goto IL_00ea;
		IL_0011:
		int num = 866399345;
		goto IL_0016;
		IL_0016:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x33A43476)
			{
			case 0:
				break;
			case 4:
			{
				int num3;
				if (tJgUQmUwhQQSvfwPTzFQBcIUXea[num2].xsVRqidKOXHqRYCEunSFFWBYJvE != 0)
				{
					num = 866399351;
					num3 = num;
				}
				else
				{
					num = 866399349;
					num3 = num;
				}
				continue;
			}
			case 1:
			{
				Player.ControllerHelper controllers2 = lGcKTymIVPnyTtnJFgbcUzeJcSS.Players_orig[num2].controllers;
				tJgUQmUwhQQSvfwPTzFQBcIUXea[num2].ouyaHWRMwYnOfXDiqdcqIYTxpOE(num2, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
				num = 866399349;
				continue;
			}
			case 6:
			{
				Player.ControllerHelper controllers = lGcKTymIVPnyTtnJFgbcUzeJcSS.ljtfDbQTnJBHJAjJCIcaEvxvpwaG().controllers;
				dGEaYGcZYLDZJaVkNbUrlqhHiTe.ouyaHWRMwYnOfXDiqdcqIYTxpOE(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
				num = 866399348;
				continue;
			}
			case 8:
				goto IL_00ea;
			case 3:
				num2++;
				num = 866399347;
				continue;
			case 2:
				num2 = 0;
				num = 866399347;
				continue;
			case 7:
				vWfklDVVhVIXzshDTlzkTcxgKkK.ouyaHWRMwYnOfXDiqdcqIYTxpOE(-1, fWOauwDIDcWjYxShfcASqWxMgbX(), fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Joystick), fWOauwDIDcWjYxShfcASqWxMgbX(ControllerType.Custom));
				num = 866399358;
				continue;
			default:
				if (num2 >= UAitzniEqWVvtfBkcdBcuATsmUv)
				{
					return;
				}
				goto case 4;
			}
			break;
		}
		goto IL_0011;
		IL_00ea:
		int num4;
		if (dGEaYGcZYLDZJaVkNbUrlqhHiTe.xsVRqidKOXHqRYCEunSFFWBYJvE <= 0)
		{
			num = 866399348;
			num4 = num;
		}
		else
		{
			num = 866399344;
			num4 = num;
		}
		goto IL_0016;
	}

	public void zcSNXJzzMCDeSlYnCUNDAPekdYyb(ThrottleCalibrationMode P_0)
	{
		int num = 0;
		int num2 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num3;
			if (num >= QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count)
			{
				num2 = 0;
				num3 = 2102196600;
				goto IL_0009;
			}
			goto IL_00a5;
			IL_010f:
			num++;
			num3 = 2102196604;
			goto IL_0009;
			IL_00a5:
			if (QsAVjdFzwBBIEaNvFSzfnbhSbwL[num] != null)
			{
				zcSNXJzzMCDeSlYnCUNDAPekdYyb(QsAVjdFzwBBIEaNvFSzfnbhSbwL[num], P_0);
				num3 = 2102196606;
				goto IL_0009;
			}
			goto IL_010f;
			IL_0009:
			while (true)
			{
				switch (num3 ^ 0x7D4CF974)
				{
				case 5:
					num3 = 2102196597;
					continue;
				case 8:
					break;
				case 3:
					num4++;
					num3 = 2102196594;
					continue;
				case 0:
					num2++;
					num3 = 2102196600;
					continue;
				case 2:
					if (txiWVMTSpznmRIqXyBdcjgrBpyA[num2] != null)
					{
						zcSNXJzzMCDeSlYnCUNDAPekdYyb(txiWVMTSpznmRIqXyBdcjgrBpyA[num2], P_0);
						num3 = 2102196596;
						continue;
					}
					goto case 0;
				case 1:
					goto IL_00a5;
				case 7:
					zcSNXJzzMCDeSlYnCUNDAPekdYyb(hBtIKAiElSFkNtDRgRmKCWbkUegN[num4], P_0);
					num3 = 2102196599;
					continue;
				case 9:
					goto IL_00ed;
				case 10:
					goto IL_010f;
				case 4:
					num4 = 0;
					num3 = 2102196594;
					continue;
				case 6:
					goto IL_0129;
				case 12:
					goto IL_0146;
				default:
					zcSNXJzzMCDeSlYnCUNDAPekdYyb(xuMdUThDXJJnvRMJqvyVfthJBBhD, P_0);
					return;
				}
				break;
				IL_0146:
				int num5;
				if (num2 < txiWVMTSpznmRIqXyBdcjgrBpyA.Count)
				{
					num3 = 2102196598;
					num5 = num3;
				}
				else
				{
					num3 = 2102196592;
					num5 = num3;
				}
				continue;
				IL_0129:
				int num6;
				if (num4 < customControllerCount)
				{
					num3 = 2102196605;
					num6 = num3;
				}
				else
				{
					num3 = 2102196607;
					num6 = num3;
				}
				continue;
				IL_00ed:
				int num7;
				if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num4] == null)
				{
					num3 = 2102196599;
					num7 = num3;
				}
				else
				{
					num3 = 2102196595;
					num7 = num3;
				}
			}
		}
	}

	private void zcSNXJzzMCDeSlYnCUNDAPekdYyb(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		int num = 0;
		while (true)
		{
			int num2 = 2139495146;
			while (true)
			{
				switch (num2 ^ 0x7F861AEB)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					num2 = 2139495144;
					continue;
				case 2:
				{
					int num4;
					if (axes[num].UelUYluZSYxsmPMMGpbRwJNlVXq._specialAxisType != SpecialAxisType.Throttle)
					{
						num2 = 2139495150;
						num4 = num2;
					}
					else
					{
						num2 = 2139495151;
						num4 = num2;
					}
					continue;
				}
				case 4:
					P_0.calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
					num2 = 2139495150;
					continue;
				case 3:
				{
					int num3;
					if (num < P_0.axisCount)
					{
						num2 = 2139495145;
						num3 = num2;
					}
					else
					{
						num2 = 2139495149;
						num3 = num2;
					}
					continue;
				}
				case 5:
					num++;
					num2 = 2139495144;
					continue;
				case 6:
					return;
				}
				break;
			}
		}
	}

	public IList<T> ghCBlVNkxiocFGjEGxVdIgEcuWW<T>() where T : IControllerTemplate
	{
		return kSUuBeVOaugtZhencTbifmpEpsF.wgMdGZgflBBAzqqJddLYhJOhqzK<T>();
	}

	private void dFyvOnKBbTYzKLbxHBbiIGdcrpeH(List<InputBehavior> P_0)
	{
		AQANKVsSPXqhjRcrczEkdvuTzzw = ReInput.AQANKVsSPXqhjRcrczEkdvuTzzw;
		int num7 = default(int);
		int num4 = default(int);
		List<Player_Editor.CreateControllerInfo> startingCustomControllers = default(List<Player_Editor.CreateControllerInfo>);
		IList<Player> players = default(IList<Player>);
		int num13 = default(int);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		int num2 = default(int);
		CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = default(CvKbBDBykgOtczqdWEjAImsohWR);
		CustomController customController = default(CustomController);
		int num3 = default(int);
		Player player = default(Player);
		InputBehavior inputBehavior = default(InputBehavior);
		int num8 = default(int);
		InputAction inputAction = default(InputAction);
		int num5 = default(int);
		int num6 = default(int);
		while (true)
		{
			int num = 820184836;
			while (true)
			{
				switch (num ^ 0x30E30705)
				{
				case 20:
					break;
				case 4:
					num = 820184853;
					continue;
				case 32:
					num7++;
					num = 820184835;
					continue;
				case 38:
				{
					int num11;
					if (num4 >= startingCustomControllers.Count)
					{
						num = 820184840;
						num11 = num;
					}
					else
					{
						num = 820184866;
						num11 = num;
					}
					continue;
				}
				case 41:
					nmUPqatzdoguCudPRBhWxuXdCLrE = new ADictionary<int, FQkjupqqspQonJvnwPKnCpDFtsT>();
					nmUPqatzdoguCudPRBhWxuXdCLrE.Add(ReInput.players.GetSystemPlayer().id, new FQkjupqqspQonJvnwPKnCpDFtsT(P_0));
					players = ReInput.players.Players;
					num13 = 0;
					num = 820184861;
					continue;
				case 27:
					players_readOnly = ReInput.UserData.Players_readOnly;
					if (players_readOnly == null)
					{
						throw new ArgumentNullException("Players cannot be null!");
					}
					goto case 23;
				case 0:
				{
					InputAction inputAction2 = AQANKVsSPXqhjRcrczEkdvuTzzw.oOpczXCLtYBpuQrKTCdEkiyzKNlF(num2);
					InputBehavior inputBehavior2 = nmUPqatzdoguCudPRBhWxuXdCLrE[9999999].xwFckPipwCPHlCQsjNxlMtvGULy(inputAction2.behaviorId);
					cvKbBDBykgOtczqdWEjAImsohWR = new CvKbBDBykgOtczqdWEjAImsohWR(9999999, inputAction2, inputBehavior2, liMFOVAIkIPrOJivyHfIDbBCDeae);
					tRpsseUjStqkQeJlxaKdeaJnHCWi[num2] = cvKbBDBykgOtczqdWEjAImsohWR;
					num = 820184856;
					continue;
				}
				case 39:
					customController = niQrHAQljuFoiNkqEumUiOlpjNB(startingCustomControllers[num4].sourceId);
					if (customController != null)
					{
						customController.tag = startingCustomControllers[num4].tag;
						int num10 = ((num3 == 0) ? 9999999 : (num3 - 1));
						player = lGcKTymIVPnyTtnJFgbcUzeJcSS.mGsUlCssxNPJpaIPjZSPUkhxHGhB(num10);
						num = 820184838;
						continue;
					}
					goto case 11;
				case 5:
					inputBehavior = nmUPqatzdoguCudPRBhWxuXdCLrE[players[num8].id].xwFckPipwCPHlCQsjNxlMtvGULy(inputAction.behaviorId);
					num = 820184868;
					continue;
				case 26:
					if (num5 >= cCbIxTLaiLwjBvZtihnEixbuTKw)
					{
						num8++;
						num = 820184854;
						continue;
					}
					goto case 15;
				case 24:
					num = 820184860;
					continue;
				case 35:
					mUwGRhAqfGeUMXYZXHbEbaCqKiwF = new CvKbBDBykgOtczqdWEjAImsohWR[(UAitzniEqWVvtfBkcdBcuATsmUv + 1) * cCbIxTLaiLwjBvZtihnEixbuTKw];
					num7 = 0;
					tRpsseUjStqkQeJlxaKdeaJnHCWi = new CvKbBDBykgOtczqdWEjAImsohWR[cCbIxTLaiLwjBvZtihnEixbuTKw];
					num = 820184847;
					continue;
				case 25:
					if (num13 >= players.Count)
					{
						CRAJsKEjWPTKilPYjUTblmqShQz = new ReadOnlyCollection<Joystick>(QsAVjdFzwBBIEaNvFSzfnbhSbwL);
						num = 820184858;
						continue;
					}
					goto case 2;
				case 28:
					OmgpPaGkSscTxvFHKNkmXOGjAj = new sbGjBSYUCHFmdsRwzJKaaHSDFDN();
					VOoSTAIrXRloZYIerDhCqmMUIMc = new sbGjBSYUCHFmdsRwzJKaaHSDFDN[UAitzniEqWVvtfBkcdBcuATsmUv];
					num = 820184852;
					continue;
				case 36:
				{
					int num14;
					if (num3 < players_readOnly.Count)
					{
						num = 820184871;
						num14 = num;
					}
					else
					{
						num = 820184857;
						num14 = num;
					}
					continue;
				}
				case 12:
					num = 820184865;
					continue;
				case 33:
				{
					CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR2 = new CvKbBDBykgOtczqdWEjAImsohWR(num8, inputAction, inputBehavior, liMFOVAIkIPrOJivyHfIDbBCDeae);
					MVymlrpVDhkWJLuVMNfWHQypaFV[num8, num5] = cvKbBDBykgOtczqdWEjAImsohWR2;
					mUwGRhAqfGeUMXYZXHbEbaCqKiwF[num7] = cvKbBDBykgOtczqdWEjAImsohWR2;
					num7++;
					num = 820184843;
					continue;
				}
				case 14:
					num5++;
					num = 820184863;
					continue;
				case 22:
				{
					int num12;
					if (num2 >= cCbIxTLaiLwjBvZtihnEixbuTKw)
					{
						num = 820184859;
						num12 = num;
					}
					else
					{
						num = 820184837;
						num12 = num;
					}
					continue;
				}
				case 3:
					if (player != null)
					{
						player.controllers.eVEvqWwHYWffmAvFhiIHiCYQKtYI(customController, false);
						num = 820184846;
						continue;
					}
					goto case 11;
				case 15:
					inputAction = AQANKVsSPXqhjRcrczEkdvuTzzw.oOpczXCLtYBpuQrKTCdEkiyzKNlF(num5);
					num = 820184832;
					continue;
				case 1:
					lGcKTymIVPnyTtnJFgbcUzeJcSS = ReInput.lGcKTymIVPnyTtnJFgbcUzeJcSS;
					QsAVjdFzwBBIEaNvFSzfnbhSbwL = new List<Joystick>();
					txiWVMTSpznmRIqXyBdcjgrBpyA = new List<Joystick>();
					num = 820184864;
					continue;
				case 23:
					num3 = 0;
					num = 820184841;
					continue;
				case 10:
					num2 = 0;
					num = 820184851;
					continue;
				case 19:
				{
					int num9;
					if (num8 >= UAitzniEqWVvtfBkcdBcuATsmUv)
					{
						num = 820184862;
						num9 = num;
					}
					else
					{
						num = 820184855;
						num9 = num;
					}
					continue;
				}
				case 9:
					VOoSTAIrXRloZYIerDhCqmMUIMc[num6] = new sbGjBSYUCHFmdsRwzJKaaHSDFDN();
					num6++;
					num = 820184853;
					continue;
				case 30:
					MVymlrpVDhkWJLuVMNfWHQypaFV = new CvKbBDBykgOtczqdWEjAImsohWR[UAitzniEqWVvtfBkcdBcuATsmUv, cCbIxTLaiLwjBvZtihnEixbuTKw];
					num8 = 0;
					num = 820184854;
					continue;
				case 18:
					num5 = 0;
					num = 820184877;
					continue;
				case 37:
					hBtIKAiElSFkNtDRgRmKCWbkUegN = new List<CustomController>();
					num = 820184834;
					continue;
				case 13:
					num3++;
					num = 820184865;
					continue;
				case 11:
					num4++;
					num = 820184867;
					continue;
				case 16:
					if (num6 >= UAitzniEqWVvtfBkcdBcuATsmUv)
					{
						vWfklDVVhVIXzshDTlzkTcxgKkK = new global::ItvAIPvALEjnzMQurwGyhxzBLJS<ActiveControllerChangedDelegate>();
						dGEaYGcZYLDZJaVkNbUrlqhHiTe = new global::ItvAIPvALEjnzMQurwGyhxzBLJS<PlayerActiveControllerChangedDelegate>();
						num = 820184845;
						continue;
					}
					goto case 9;
				case 29:
					mUwGRhAqfGeUMXYZXHbEbaCqKiwF[num7] = cvKbBDBykgOtczqdWEjAImsohWR;
					num = 820184869;
					continue;
				case 31:
					ARUrCeMkoFdxWBlTCqIgCVqNNZkW = new ReadOnlyCollection<CustomController>(hBtIKAiElSFkNtDRgRmKCWbkUegN);
					CvKbBDBykgOtczqdWEjAImsohWR.WmVfzBxTSAslrcbvyfyEhCgFIqkA(liMFOVAIkIPrOJivyHfIDbBCDeae);
					num = 820184870;
					continue;
				case 42:
					num = 820184867;
					continue;
				case 17:
					num6 = 0;
					num = 820184833;
					continue;
				case 34:
					startingCustomControllers = players_readOnly[num3].startingCustomControllers;
					if (startingCustomControllers != null)
					{
						num4 = 0;
						num = 820184879;
						continue;
					}
					goto case 13;
				case 7:
					cCbIxTLaiLwjBvZtihnEixbuTKw = AQANKVsSPXqhjRcrczEkdvuTzzw.actionCount;
					UAitzniEqWVvtfBkcdBcuATsmUv = lGcKTymIVPnyTtnJFgbcUzeJcSS.gamePlayerCount;
					num = 820184848;
					continue;
				case 6:
					num2++;
					num = 820184851;
					continue;
				case 40:
					num = 820184863;
					continue;
				case 21:
					dUaQQwLlbrCiThoTsItmPnKJFQO = omFggPRBtROiILrWOinQVLrBcau;
					CuYIorUZBawGDYQjOdUKDXYSFUc = 0;
					num = 820184876;
					continue;
				case 2:
					nmUPqatzdoguCudPRBhWxuXdCLrE.Add(players[num13].id, new FQkjupqqspQonJvnwPKnCpDFtsT(P_0));
					num13++;
					num = 820184860;
					continue;
				default:
					tJgUQmUwhQQSvfwPTzFQBcIUXea = new global::ItvAIPvALEjnzMQurwGyhxzBLJS<PlayerActiveControllerChangedDelegate>[lGcKTymIVPnyTtnJFgbcUzeJcSS.gamePlayerCount];
					ArrayTools.Populate(tJgUQmUwhQQSvfwPTzFQBcIUXea);
					return;
				}
				break;
			}
		}
	}

	private void ObhCjFJhZIEApHxufzsoEcSKuXDF(UpdateLoopType P_0)
	{
		int count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
		int num = 0;
		Joystick joystick = default(Joystick);
		int num4 = default(int);
		int count2 = default(int);
		CustomController customController = default(CustomController);
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -1602858086;
				num3 = num2;
			}
			else
			{
				num2 = -1602858094;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1602858092)
				{
				case 5:
					num2 = -1602858086;
					continue;
				default:
					return;
				case 8:
					num2 = -1602858082;
					continue;
				case 0:
					zrqFfcgoVawyVJChujEYldemglxu(joystick.inputManagerId, joystick.ROoGdHjYclVKlAjCTYtzRRhBjqvj);
					joystick.UpdateData(P_0);
					num2 = -1602858090;
					continue;
				case 10:
				{
					int num7;
					if (num4 < count2)
					{
						num2 = -1602858081;
						num7 = num2;
					}
					else
					{
						num2 = -1602858107;
						num7 = num2;
					}
					continue;
				}
				case 7:
					count2 = hBtIKAiElSFkNtDRgRmKCWbkUegN.Count;
					num2 = -1602858091;
					continue;
				case 13:
					if (xuMdUThDXJJnvRMJqvyVfthJBBhD.enabled)
					{
						xuMdUThDXJJnvRMJqvyVfthJBBhD.UpdateData(P_0);
						num2 = -1602858093;
						continue;
					}
					goto case 7;
				case 14:
				{
					joystick = QsAVjdFzwBBIEaNvFSzfnbhSbwL[num];
					int num8;
					if (!joystick.enabled)
					{
						num2 = -1602858090;
						num8 = num2;
					}
					else
					{
						num2 = -1602858092;
						num8 = num2;
					}
					continue;
				}
				case 15:
					SFYAuTPTwQDVYDMfiGzNbbQzFhV.UpdateData_AndroidKeyboardDisabled(P_0);
					num2 = -1602858087;
					continue;
				case 6:
					if (SFYAuTPTwQDVYDMfiGzNbbQzFhV.enabled)
					{
						SFYAuTPTwQDVYDMfiGzNbbQzFhV.UpdateData(P_0);
						num2 = -1602858087;
						continue;
					}
					goto case 9;
				case 16:
					customController.UpdateData(P_0);
					num2 = -1602858089;
					continue;
				case 3:
					num4++;
					num2 = -1602858082;
					continue;
				case 12:
					break;
				case 1:
					num4 = 0;
					num2 = -1602858084;
					continue;
				case 9:
				{
					int num6;
					if (!mXnbDodmeHqYEXAgmqSCAqLZXiZe)
					{
						num2 = -1602858087;
						num6 = num2;
					}
					else
					{
						num2 = -1602858085;
						num6 = num2;
					}
					continue;
				}
				case 4:
					customController.FillData();
					num2 = -1602858108;
					continue;
				case 2:
					num++;
					num2 = -1602858088;
					continue;
				case 11:
				{
					customController = hBtIKAiElSFkNtDRgRmKCWbkUegN[num4];
					int num5;
					if (customController.enabled)
					{
						num2 = -1602858096;
						num5 = num2;
					}
					else
					{
						num2 = -1602858089;
						num5 = num2;
					}
					continue;
				}
				case 17:
					return;
				}
				break;
			}
		}
	}

	private void dFKEfSrJBCfhknqJeAOwbilhqbZd(UpdateLoopType P_0)
	{
		CvKbBDBykgOtczqdWEjAImsohWR.ZouzsHmtgkHgzpqSGEdYaTNdgrhg(P_0);
		int num4 = default(int);
		bool enabled2 = default(bool);
		int num9 = default(int);
		int num2 = default(int);
		int num12 = default(int);
		int num11 = default(int);
		IList<KeyboardMap> maps = default(IList<KeyboardMap>);
		sbGjBSYUCHFmdsRwzJKaaHSDFDN sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = default(sbGjBSYUCHFmdsRwzJKaaHSDFDN);
		int count = default(int);
		Player.ControllerHelper controllers = default(Player.ControllerHelper);
		Player[] allPlayers_orig = default(Player[]);
		int num6 = default(int);
		int num7 = default(int);
		int num5 = default(int);
		bool enabled = default(bool);
		while (true)
		{
			int num = 321656688;
			while (true)
			{
				switch (num ^ 0x132C1765)
				{
				case 27:
					break;
				default:
					return;
				case 29:
					num4 = 0;
					num = 321656695;
					continue;
				case 26:
					if (enabled2)
					{
						num9 = 0;
						num = 321656684;
						continue;
					}
					goto case 8;
				case 31:
					num2 = 0;
					num = 321656679;
					continue;
				case 19:
				{
					int num15;
					if (enabled2)
					{
						num = 321656687;
						num15 = num;
					}
					else
					{
						num = 321656641;
						num15 = num;
					}
					continue;
				}
				case 33:
					num12++;
					num = 321656647;
					continue;
				case 23:
					num11 = 0;
					num = 321656681;
					continue;
				case 25:
					if (maps[num11].enabled)
					{
						xnyKNSfAwxCMcZnCWAZbtfQYBOXh.JeIBSOiPcFNzaouiBXruMGOQOwE(maps[num11]);
						num = 321656674;
						continue;
					}
					goto case 7;
				case 28:
					sbGjBSYUCHFmdsRwzJKaaHSDFDN2 = VOoSTAIrXRloZYIerDhCqmMUIMc[num2];
					if (sbGjBSYUCHFmdsRwzJKaaHSDFDN2.PwXHtiwRLoynEJlcjliQaMRCQlr != 0)
					{
						num12 = 0;
						num = 321656647;
						continue;
					}
					goto case 17;
				case 13:
					if (num11 >= count)
					{
						num9++;
						num = 321656684;
						continue;
					}
					goto case 25;
				case 36:
				{
					int num13;
					if (mXnbDodmeHqYEXAgmqSCAqLZXiZe)
					{
						num = 321656687;
						num13 = num;
					}
					else
					{
						num = 321656676;
						num13 = num;
					}
					continue;
				}
				case 0:
					controllers = allPlayers_orig[num6].controllers;
					controllers.AMGYwcIQXCKQOqpgsgBGHuJTxhe(dUaQQwLlbrCiThoTsItmPnKJFQO);
					num = 321656694;
					continue;
				case 35:
				{
					int num8;
					if (num6 >= num7)
					{
						num = 321656678;
						num8 = num;
					}
					else
					{
						num = 321656677;
						num8 = num;
					}
					continue;
				}
				case 17:
					num2++;
					num = 321656679;
					continue;
				case 4:
					num4++;
					num = 321656683;
					continue;
				case 10:
					controllers.vnnGGOCZvnIdjvfKAEonCPaictKn(SFYAuTPTwQDVYDMfiGzNbbQzFhV, xnyKNSfAwxCMcZnCWAZbtfQYBOXh, dUaQQwLlbrCiThoTsItmPnKJFQO);
					num = 321656676;
					continue;
				case 14:
				{
					int num18;
					if (num4 >= cCbIxTLaiLwjBvZtihnEixbuTKw)
					{
						num = 321656698;
						num18 = num;
					}
					else
					{
						num = 321656675;
						num18 = num;
					}
					continue;
				}
				case 24:
					num5++;
					num = 321656682;
					continue;
				case 8:
					enabled = xuMdUThDXJJnvRMJqvyVfthJBBhD.enabled;
					num = 321656686;
					continue;
				case 30:
					CvKbBDBykgOtczqdWEjAImsohWR.MNwIOrsKzPgPBsPiRbTUvNmUdL();
					if (HTrjbVpbkEHVkbkenPcRqGNLFG)
					{
						int num17;
						if (OmgpPaGkSscTxvFHKNkmXOGjAj.PwXHtiwRLoynEJlcjliQaMRCQlr <= 0)
						{
							num = 321656698;
							num17 = num;
						}
						else
						{
							num = 321656696;
							num17 = num;
						}
						continue;
					}
					return;
				case 11:
					num6 = 0;
					num = 321656646;
					continue;
				case 34:
				{
					int num16;
					if (num12 >= cCbIxTLaiLwjBvZtihnEixbuTKw)
					{
						num = 321656692;
						num16 = num;
					}
					else
					{
						num = 321656691;
						num16 = num;
					}
					continue;
				}
				case 22:
				{
					CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR2 = MVymlrpVDhkWJLuVMNfWHQypaFV[num2, num12];
					if (cvKbBDBykgOtczqdWEjAImsohWR2.cfbLtZVfchvCddmhvLrshzbsxkD != CvKbBDBykgOtczqdWEjAImsohWR.yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE)
					{
						sbGjBSYUCHFmdsRwzJKaaHSDFDN2.gPcrsTnkkceDCRqbBGlMPDCzcFT(cvKbBDBykgOtczqdWEjAImsohWR2, P_0);
						num = 321656644;
						continue;
					}
					goto case 33;
				}
				case 21:
					allPlayers_orig = lGcKTymIVPnyTtnJFgbcUzeJcSS.AllPlayers_orig;
					num7 = allPlayers_orig.Length;
					enabled2 = SFYAuTPTwQDVYDMfiGzNbbQzFhV.enabled;
					num = 321656703;
					continue;
				case 5:
					controllers.CMVRlSEEAtdzUcoRQBYSgtDBHbLD(dUaQQwLlbrCiThoTsItmPnKJFQO);
					num6++;
					num = 321656646;
					continue;
				case 15:
				{
					int num14;
					if (num5 < mUwGRhAqfGeUMXYZXHbEbaCqKiwF.Length)
					{
						num = 321656645;
						num14 = num;
					}
					else
					{
						num = 321656699;
						num14 = num;
					}
					continue;
				}
				case 1:
					if (enabled)
					{
						controllers.aHJFbZMfZZDtPYTKrBqdeEOoTiOE(xuMdUThDXJJnvRMJqvyVfthJBBhD, dUaQQwLlbrCiThoTsItmPnKJFQO);
						num = 321656672;
						continue;
					}
					goto case 5;
				case 7:
					num11++;
					num = 321656680;
					continue;
				case 6:
				{
					CvKbBDBykgOtczqdWEjAImsohWR cvKbBDBykgOtczqdWEjAImsohWR = tRpsseUjStqkQeJlxaKdeaJnHCWi[num4];
					if (cvKbBDBykgOtczqdWEjAImsohWR.cfbLtZVfchvCddmhvLrshzbsxkD != CvKbBDBykgOtczqdWEjAImsohWR.yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE)
					{
						OmgpPaGkSscTxvFHKNkmXOGjAj.gPcrsTnkkceDCRqbBGlMPDCzcFT(cvKbBDBykgOtczqdWEjAImsohWR, P_0);
						num = 321656673;
						continue;
					}
					goto case 4;
				}
				case 3:
					num5 = 0;
					num = 321656682;
					continue;
				case 16:
					maps = allPlayers_orig[num9].controllers.maps.GetMaps<KeyboardMap>(0);
					count = maps.Count;
					num = 321656690;
					continue;
				case 18:
					num = 321656683;
					continue;
				case 9:
				{
					int num10;
					if (num9 >= num7)
					{
						num = 321656685;
						num10 = num;
					}
					else
					{
						num = 321656693;
						num10 = num;
					}
					continue;
				}
				case 12:
					num = 321656680;
					continue;
				case 32:
					if (mUwGRhAqfGeUMXYZXHbEbaCqKiwF[num5].cfbLtZVfchvCddmhvLrshzbsxkD != CvKbBDBykgOtczqdWEjAImsohWR.yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE)
					{
						mUwGRhAqfGeUMXYZXHbEbaCqKiwF[num5].IEhczglOxbiQcBHgRNtgWwfaNlO();
						num = 321656701;
						continue;
					}
					goto case 24;
				case 2:
				{
					int num3;
					if (num2 < UAitzniEqWVvtfBkcdBcuATsmUv)
					{
						num = 321656697;
						num3 = num;
					}
					else
					{
						num = 321656689;
						num3 = num;
					}
					continue;
				}
				case 20:
					return;
				}
				break;
			}
		}
	}

	private void omFggPRBtROiILrWOinQVLrBcau(bool P_0, int P_1, int P_2)
	{
		int num = AQANKVsSPXqhjRcrczEkdvuTzzw.tZuNWtSCplPhyqDRGNVBVrTnWqi(P_2);
		if (num < 0)
		{
			return;
		}
		while (P_1 != 9999999)
		{
			while (true)
			{
				IL_0053:
				MVymlrpVDhkWJLuVMNfWHQypaFV[P_1, num].JpdhMasUpiuyJauEolnbBVPvfvE(P_0);
				int num2 = 1607309718;
				while (true)
				{
					switch (num2 ^ 0x5FCD9996)
					{
					case 3:
						num2 = 1607309719;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						goto IL_0053;
					case 0:
						return;
					}
					break;
				}
				break;
			}
		}
		tRpsseUjStqkQeJlxaKdeaJnHCWi[num].JpdhMasUpiuyJauEolnbBVPvfvE(P_0);
	}

	private void NWSLpzjARXAZockcSxXYkguBzrbQ(BridgedController P_0)
	{
		int num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0.sourceJoystick.rewiredId, nZhbitNCKUHtixjXUCKWfBgoLsY.jikNtdRieZgCLIcbSBeRBnEBmcwg);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			goto IL_0024;
		}
		goto IL_00a9;
		IL_00a9:
		num = tQtXQZViknwzHLbzDVaijDZCPZi(P_0.sourceJoystick.rewiredId, nZhbitNCKUHtixjXUCKWfBgoLsY.OlrsfcQzhPGAwvfQNjJivvrkJaM);
		Joystick joystick = default(Joystick);
		int num2;
		if (num >= 0)
		{
			joystick = txiWVMTSpznmRIqXyBdcjgrBpyA[num];
			txiWVMTSpznmRIqXyBdcjgrBpyA.RemoveAt(num);
			num2 = 569849498;
			goto IL_0029;
		}
		goto IL_0073;
		IL_0024:
		num2 = 569849496;
		goto IL_0029;
		IL_0029:
		while (true)
		{
			switch (num2 ^ 0x21F7369B)
			{
			case 8:
				break;
			case 9:
				joystick.isConnected = true;
				num2 = 569849503;
				continue;
			case 5:
				goto IL_0073;
			case 4:
				num2 = 569849499;
				continue;
			case 1:
				joystick.UpdateControllerInfo(P_0);
				num2 = 569849490;
				continue;
			case 6:
				rJQlHuZSQNCSzonDICIjFLkTXWgT.Add(joystick);
				num2 = 569849497;
				continue;
			case 10:
				goto IL_00a9;
			case 3:
				return;
			case 2:
				QsAVjdFzwBBIEaNvFSzfnbhSbwL.Sort(Joystick.CompareById_Ascending);
				num2 = 569849500;
				continue;
			case 0:
				QsAVjdFzwBBIEaNvFSzfnbhSbwL.Add(joystick);
				num2 = 569849501;
				continue;
			default:
				kSUuBeVOaugtZhencTbifmpEpsF.mNZqIqhDqfRYbzOcNOQjRKmCmuS(joystick);
				return;
			}
			break;
		}
		goto IL_0024;
		IL_0073:
		joystick = new Joystick(P_0);
		num2 = 569849499;
		goto IL_0029;
	}

	private void OLTyZrKXYzECMfpBGePUsNrPmKS(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		while (P_0 < QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count)
		{
			while (true)
			{
				IL_00e2:
				Joystick joystick = QsAVjdFzwBBIEaNvFSzfnbhSbwL[P_0];
				joystick.isConnected = false;
				int num = 1079560822;
				while (true)
				{
					switch (num ^ 0x4058CA72)
					{
					case 0:
						num = 1079560816;
						continue;
					default:
						return;
					case 2:
						break;
					case 7:
						kSUuBeVOaugtZhencTbifmpEpsF.BVEaBLFBCRqawBphbmpeyEBIxGHP(joystick);
						joystick.Clear();
						num = 1079560827;
						continue;
					case 8:
						aLzdxOFnYbpbtIgxhDrljDDcPbMa(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
						num = 1079560817;
						continue;
					case 4:
						goto IL_00af;
					case 1:
						rJQlHuZSQNCSzonDICIjFLkTXWgT.Remove(joystick);
						num = 1079560821;
						continue;
					case 6:
						goto IL_00e2;
					case 5:
						QsAVjdFzwBBIEaNvFSzfnbhSbwL.RemoveAt(P_0);
						txiWVMTSpznmRIqXyBdcjgrBpyA.Add(joystick);
						num = 1079560819;
						continue;
					case 3:
						if (vLFdJRJUytEANJaedIuoIIzFkfby != null)
						{
							vLFdJRJUytEANJaedIuoIIzFkfby(joystick.type, joystick.id);
							num = 1079560823;
							continue;
						}
						goto case 5;
					case 9:
						return;
					}
					break;
					IL_00af:
					int num2;
					if (aLzdxOFnYbpbtIgxhDrljDDcPbMa != null)
					{
						num = 1079560826;
						num2 = num;
					}
					else
					{
						num = 1079560817;
						num2 = num;
					}
				}
				break;
			}
		}
		Logger.LogError("Device was not in connected list! Cannot remove!");
	}

	private void tkRjJCjQEXSacAtUlpIgjgbdNQU()
	{
		int count = QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1209660181;
			while (true)
			{
				switch (num ^ -1209660182)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					num2 = count - 1;
					num = -1209660183;
					continue;
				case 3:
				{
					int num3;
					if (num2 >= 0)
					{
						num = -1209660184;
						num3 = num;
					}
					else
					{
						num = -1209660178;
						num3 = num;
					}
					continue;
				}
				case 2:
					OLTyZrKXYzECMfpBGePUsNrPmKS(num2);
					num2--;
					num = -1209660183;
					continue;
				case 4:
					return;
				}
				break;
			}
		}
	}

	private bool eVEvqWwHYWffmAvFhiIHiCYQKtYI(CustomController P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int num = 0;
		int num2 = 693118105;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ 0x2950249A)
			{
			case 0:
				break;
			case 1:
				return false;
			case 3:
			{
				int num3;
				if (num < hBtIKAiElSFkNtDRgRmKCWbkUegN.Count)
				{
					num2 = 693118104;
					num3 = num2;
				}
				else
				{
					num2 = 693118110;
					num3 = num2;
				}
				continue;
			}
			case 2:
				if (hBtIKAiElSFkNtDRgRmKCWbkUegN[num] == P_0)
				{
					return true;
				}
				num++;
				num2 = 693118105;
				continue;
			default:
				hBtIKAiElSFkNtDRgRmKCWbkUegN.Add(P_0);
				rJQlHuZSQNCSzonDICIjFLkTXWgT.Add(P_0);
				kSUuBeVOaugtZhencTbifmpEpsF.mNZqIqhDqfRYbzOcNOQjRKmCmuS(P_0);
				return true;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = 693118107;
		goto IL_0008;
	}

	private bool aUKDbmOXgEhxGqWknoZkFlKUkao(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		kSUuBeVOaugtZhencTbifmpEpsF.BVEaBLFBCRqawBphbmpeyEBIxGHP(P_0);
		while (true)
		{
			int num = 1133544348;
			while (true)
			{
				switch (num ^ 0x4390839D)
				{
				case 2:
					break;
				case 1:
					goto IL_002f;
				default:
					return hBtIKAiElSFkNtDRgRmKCWbkUegN.Remove(P_0);
				}
				break;
				IL_002f:
				rJQlHuZSQNCSzonDICIjFLkTXWgT.Remove(P_0);
				num = 1133544349;
			}
		}
	}

	private sbGjBSYUCHFmdsRwzJKaaHSDFDN VtgBmLFWEfEdmuBlgTNxbOOTgRnJ(int P_0)
	{
		if (P_0 == 9999999)
		{
			return OmgpPaGkSscTxvFHKNkmXOGjAj;
		}
		if (P_0 < 0 || P_0 >= ReInput.lGcKTymIVPnyTtnJFgbcUzeJcSS.gamePlayerCount)
		{
			return null;
		}
		return VOoSTAIrXRloZYIerDhCqmMUIMc[P_0];
	}

	private void KQnERtXqgFEKsKSFgqkCdGdjbBjx(bool P_0)
	{
		if (!P_0)
		{
			xnyKNSfAwxCMcZnCWAZbtfQYBOXh.PgZPlMozMoJLNxNdALvYkygDCFr();
		}
	}

	private void xltRnWzfKredmaiyAQFcSDIhKcdz(bool P_0)
	{
		if (P_0 || ReInput.applicationRunInBackground)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			int num = -840208193;
			while (true)
			{
				switch (num ^ -840208197)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					num2 = 0;
					num = -840208197;
					continue;
				case 2:
					QsAVjdFzwBBIEaNvFSzfnbhSbwL[num2].StopVibration();
					num2++;
					num = -840208197;
					continue;
				case 0:
				{
					int num3;
					if (num2 < QsAVjdFzwBBIEaNvFSzfnbhSbwL.Count)
					{
						num = -840208199;
						num3 = num;
					}
					else
					{
						num = -840208198;
						num3 = num;
					}
					continue;
				}
				case 1:
					return;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		yByeqDDEKPzAKiUpxfZrBkMpiHln(true);
		GC.SuppressFinalize(this);
	}

	~lCLAgzeBrhoeWjAjwfsCvCCcNbf()
	{
		yByeqDDEKPzAKiUpxfZrBkMpiHln(false);
	}

	private void yByeqDDEKPzAKiUpxfZrBkMpiHln(bool P_0)
	{
		if (QQqHByfwytAJSuMZiCPjJlZYHKG)
		{
			goto IL_0008;
		}
		goto IL_0062;
		IL_0008:
		int num = 1917879956;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x72508696)
			{
			case 5:
				break;
			default:
				return;
			case 4:
				goto IL_0036;
			case 0:
				goto IL_0044;
			case 1:
				goto IL_0062;
			case 3:
				(AQyfQTcKPEsnwqJtfBwgBYzoxYU as IDisposable).Dispose();
				num = 1917879954;
				continue;
			case 2:
				return;
			case 6:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0062:
		if (!P_0)
		{
			goto IL_0036;
		}
		if (vWTAIrnHuKFLcfZGsOQDWoyKGEg is IDisposable)
		{
			(vWTAIrnHuKFLcfZGsOQDWoyKGEg as IDisposable).Dispose();
			num = 1917879958;
			goto IL_000d;
		}
		goto IL_0044;
		IL_0036:
		QQqHByfwytAJSuMZiCPjJlZYHKG = true;
		num = 1917879952;
		goto IL_000d;
		IL_0044:
		int num2;
		if (!(AQyfQTcKPEsnwqJtfBwgBYzoxYU is IDisposable))
		{
			num = 1917879954;
			num2 = num;
		}
		else
		{
			num = 1917879957;
			num2 = num;
		}
		goto IL_000d;
	}
}
