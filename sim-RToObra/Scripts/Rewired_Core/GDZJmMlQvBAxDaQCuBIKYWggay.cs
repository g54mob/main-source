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

internal sealed class GDZJmMlQvBAxDaQCuBIKYWggay : IDisposable
{
	public enum QHWSqSXjZtJVmIWvTGBJmFrgKKs
	{
		AVgeqanjsLChqjEayGcDNCMqTxtI = 0,
		dUltDdkivNhBBHvDthniWYpgMnZ = 1
	}

	private class JmBSvBweXerzSNIFAoWACPuzwA
	{
		public ADictionary<int, InputBehavior> LbwQyRfKuLNxSjFIaAsDJTuLixL;

		public List<InputBehavior> jwgCcmBYxaMijibFhczhZuzBgQli;

		public IList<InputBehavior> aNtiLqNHPNHiknBJkIyrwnQzmQZ;

		public JmBSvBweXerzSNIFAoWACPuzwA(List<InputBehavior> behaviors)
		{
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = -1716045216;
				while (true)
				{
					switch (num ^ -1716045214)
					{
					case 3:
						break;
					case 2:
						jwgCcmBYxaMijibFhczhZuzBgQli = new List<InputBehavior>(behaviors.Count);
						LbwQyRfKuLNxSjFIaAsDJTuLixL = new ADictionary<int, InputBehavior>();
						num3 = 0;
						num2 = 0;
						num = -1716045214;
						continue;
					case 1:
					{
						InputBehavior inputBehavior = behaviors[num2].Clone();
						LbwQyRfKuLNxSjFIaAsDJTuLixL.Add(behaviors[num2].id, inputBehavior);
						jwgCcmBYxaMijibFhczhZuzBgQli.Add(inputBehavior);
						num3++;
						num2++;
						num = -1716045214;
						continue;
					}
					default:
						if (num2 >= behaviors.Count)
						{
							aNtiLqNHPNHiknBJkIyrwnQzmQZ = new ReadOnlyCollection<InputBehavior>(jwgCcmBYxaMijibFhczhZuzBgQli);
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public InputBehavior GERpyUYtgAywOuExPtqvfhhASSd(int P_0)
		{
			if (jwgCcmBYxaMijibFhczhZuzBgQli.Count == 0)
			{
				return null;
			}
			InputBehavior value;
			LbwQyRfKuLNxSjFIaAsDJTuLixL.TryGetValue(P_0, out value);
			if (value == null)
			{
				return jwgCcmBYxaMijibFhczhZuzBgQli[0];
			}
			return value;
		}
	}

	private sealed class nZktPjeesrinVBbcnOuaDQrjBat : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController aimBzjfQfPyaeQqysAQJISCBhELB;

		private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

		private int HbSVCfYbFQknCSDIuBJpKcqKonb;

		public GDZJmMlQvBAxDaQCuBIKYWggay iKQXbXnVtIaMZEJNeigQJWAHqUx;

		public int TzjKccGuZpjFxSENEHYvdbmsmCSh;

		public int WxxaCeWPgDWOfrKEGwmhasjZNWV;

		public int oUkfgwYlMeCLZLBefJDeMFPHmJS;

		public int SymmMWQhfQFidGaRizMieCZMykl;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return aimBzjfQfPyaeQqysAQJISCBhELB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return aimBzjfQfPyaeQqysAQJISCBhELB;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			nZktPjeesrinVBbcnOuaDQrjBat nZktPjeesrinVBbcnOuaDQrjBat2;
			if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
				nZktPjeesrinVBbcnOuaDQrjBat2 = this;
			}
			else
			{
				while (true)
				{
					nZktPjeesrinVBbcnOuaDQrjBat2 = new nZktPjeesrinVBbcnOuaDQrjBat(0);
					nZktPjeesrinVBbcnOuaDQrjBat2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					int num = 738576334;
					while (true)
					{
						switch (num ^ 0x2C05C7CF)
						{
						case 0:
							num = 738576333;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0045;
						}
						break;
					}
					continue;
					end_IL_0045:
					break;
				}
			}
			nZktPjeesrinVBbcnOuaDQrjBat2.TzjKccGuZpjFxSENEHYvdbmsmCSh = WxxaCeWPgDWOfrKEGwmhasjZNWV;
			return nZktPjeesrinVBbcnOuaDQrjBat2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
			while (true)
			{
				int num2 = 430090983;
				while (true)
				{
					switch (num2 ^ 0x19A2AAE6)
					{
					case 0:
						break;
					case 1:
						switch (num)
						{
						default:
							num2 = 430090981;
							continue;
						case 0:
							break;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num2 = 430090980;
							continue;
						}
						goto case 5;
					case 2:
						SymmMWQhfQFidGaRizMieCZMykl++;
						num2 = 430090976;
						continue;
					case 5:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						oUkfgwYlMeCLZLBefJDeMFPHmJS = iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
						SymmMWQhfQFidGaRizMieCZMykl = 0;
						num2 = 430090976;
						continue;
					case 4:
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt[SymmMWQhfQFidGaRizMieCZMykl].sourceControllerId == TzjKccGuZpjFxSENEHYvdbmsmCSh)
						{
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt[SymmMWQhfQFidGaRizMieCZMykl];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						}
						goto case 2;
					case 6:
					{
						int num3;
						if (SymmMWQhfQFidGaRizMieCZMykl >= oUkfgwYlMeCLZLBefJDeMFPHmJS)
						{
							num2 = 430090977;
							num3 = num2;
						}
						else
						{
							num2 = 430090978;
							num3 = num2;
						}
						continue;
					}
					case 3:
						num2 = 430090977;
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
		public nZktPjeesrinVBbcnOuaDQrjBat(int _003C_003E1__state)
		{
			oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private sealed class pweWePWNjpWYtGljeBEcgSVAkQA : IDisposable, IEnumerator, IEnumerable, IEnumerable<CustomController>, IEnumerator<CustomController>
	{
		private CustomController aimBzjfQfPyaeQqysAQJISCBhELB;

		private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

		private int HbSVCfYbFQknCSDIuBJpKcqKonb;

		public GDZJmMlQvBAxDaQCuBIKYWggay iKQXbXnVtIaMZEJNeigQJWAHqUx;

		public string NOJlkeauWKQIBZKjVcBnYCWUgkB;

		public string wSagivdJDpAKobJbTLYNmfxUdevu;

		public int OJFWCzBMnqFdYrfUfLqOxAqiMto;

		public int bTPokZXhsGLjhsrtEFQDzjIRqOH;

		CustomController IEnumerator<CustomController>.Current
		{
			[DebuggerHidden]
			get
			{
				return aimBzjfQfPyaeQqysAQJISCBhELB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return aimBzjfQfPyaeQqysAQJISCBhELB;
			}
		}

		[DebuggerHidden]
		IEnumerator<CustomController> IEnumerable<CustomController>.GetEnumerator()
		{
			if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
			{
				goto IL_0012;
			}
			goto IL_0089;
			IL_0012:
			int num = 2131387435;
			goto IL_0017;
			IL_0017:
			pweWePWNjpWYtGljeBEcgSVAkQA pweWePWNjpWYtGljeBEcgSVAkQA2 = default(pweWePWNjpWYtGljeBEcgSVAkQA);
			while (true)
			{
				switch (num ^ 0x7F0A642E)
				{
				case 0:
					break;
				case 4:
					pweWePWNjpWYtGljeBEcgSVAkQA2 = this;
					num = 2131387437;
					continue;
				case 6:
					pweWePWNjpWYtGljeBEcgSVAkQA2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
					num = 2131387433;
					continue;
				case 5:
					goto IL_0060;
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					num = 2131387434;
					continue;
				case 2:
					goto IL_0089;
				case 3:
					num = 2131387433;
					continue;
				default:
					pweWePWNjpWYtGljeBEcgSVAkQA2.NOJlkeauWKQIBZKjVcBnYCWUgkB = wSagivdJDpAKobJbTLYNmfxUdevu;
					return pweWePWNjpWYtGljeBEcgSVAkQA2;
				}
				break;
				IL_0060:
				int num2;
				if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					num = 2131387439;
					num2 = num;
				}
				else
				{
					num = 2131387436;
					num2 = num;
				}
			}
			goto IL_0012;
			IL_0089:
			pweWePWNjpWYtGljeBEcgSVAkQA2 = new pweWePWNjpWYtGljeBEcgSVAkQA(0);
			num = 2131387432;
			goto IL_0017;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<CustomController>)this).GetEnumerator();
		}

		private bool MoveNext()
		{
			int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
			while (true)
			{
				int num2 = 1325420495;
				while (true)
				{
					switch (num2 ^ 0x4F004FC7)
					{
					case 0:
						break;
					case 3:
						bTPokZXhsGLjhsrtEFQDzjIRqOH = 0;
						num2 = 1325420482;
						continue;
					case 7:
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						OJFWCzBMnqFdYrfUfLqOxAqiMto = iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
						num2 = 1325420484;
						continue;
					case 8:
						switch (num)
						{
						case 0:
							break;
						default:
							num2 = 1325420481;
							continue;
						case 1:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num2 = 1325420483;
							continue;
						}
						goto case 7;
					case 2:
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt[bTPokZXhsGLjhsrtEFQDzjIRqOH].tag.Equals(NOJlkeauWKQIBZKjVcBnYCWUgkB, StringComparison.OrdinalIgnoreCase))
						{
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.SerYLNcBvSGLsDnWKlmIAbnbmflt[bTPokZXhsGLjhsrtEFQDzjIRqOH];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num2 = 1325420486;
							continue;
						}
						goto case 4;
					case 5:
					{
						int num3;
						if (bTPokZXhsGLjhsrtEFQDzjIRqOH >= OJFWCzBMnqFdYrfUfLqOxAqiMto)
						{
							num2 = 1325420481;
							num3 = num2;
						}
						else
						{
							num2 = 1325420485;
							num3 = num2;
						}
						continue;
					}
					case 4:
						bTPokZXhsGLjhsrtEFQDzjIRqOH++;
						num2 = 1325420482;
						continue;
					case 1:
						return true;
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
		public pweWePWNjpWYtGljeBEcgSVAkQA(int _003C_003E1__state)
		{
			oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
		}
	}

	private List<Joystick> ljUWisroiVgcxAxyrURnKFzSwIW;

	private List<Joystick> WOkGQHhtpdLVigwYGRvwGFhkDhLg;

	private List<CustomController> SerYLNcBvSGLsDnWKlmIAbnbmflt;

	private List<Controller> SZCeMxfPCTerGWEMwYOvsgmToRb;

	private ReadOnlyCollection<Controller> UKWvMiRNcbklNCkYADHBcqobYeYc;

	private Keyboard jXEbFYnmcSIgpclyYvQTdCKlRWYh;

	private Mouse QuOyRGrgPJAIWhsKWmyPcWlaLYok;

	private ConfigVars AzMyTQkqkOhQhSBeGZpAEMZVrzb;

	private pEQcyInzaqspNDwmuMYGrewsNaQ[] FtcxQsUplIIzzkBEldzOPtQshWz;

	private pEQcyInzaqspNDwmuMYGrewsNaQ[] SvjizdwKEpuZnQwaTMQhTsXvjJZ;

	private pEQcyInzaqspNDwmuMYGrewsNaQ[,] foeClgLCNvRZehESwXDKoKqlzhE;

	private dAsBJCqlFUZsWwFTjrjITxqcqDX EooLpHTnerlwDrVwyPBbECOAJgQ;

	private PCItYZcmQVbRIIUnLbZiPkYVRSE lzwmJEEwtQRUiNEXvXBgJIIYFZy;

	private PCItYZcmQVbRIIUnLbZiPkYVRSE[] qqeCWZfcZFjJuutpLYlCZqOUgFp;

	private global::lobHgULfDSIKOmolXbCuIWbZlIH<ActiveControllerChangedDelegate> AgfReQvZvDiaCGXCbpvggzxqAhH;

	private global::lobHgULfDSIKOmolXbCuIWbZlIH<PlayerActiveControllerChangedDelegate> MTCNBPMlOZiPgSSbnQOlMBrPbLl;

	private global::lobHgULfDSIKOmolXbCuIWbZlIH<PlayerActiveControllerChangedDelegate>[] KuAPdcgaHWxUITvApdIcoURMMfv;

	private ADictionary<int, JmBSvBweXerzSNIFAoWACPuzwA> WzMgptRXjmFPvUJSfynOIPTzDEq;

	private readonly COUAbpKeuXqLvBpbzwQGcJgjPueY VdYbRIfIAqVYCJnTMRUdCcFYmUp;

	private IList<Joystick> poUCnxmBnNufvZgOXkABYfeEyeL;

	private IList<CustomController> juQHBrmgiFgKrbVAwQAmAcgaZGvE;

	private int GDcIMXEHofUFbMLRxByZkXavcis;

	private bool BjfWKlABcPvhleltMQUKTCBPPhO;

	private bool WcPcCkNEfbxlknYuEvMHciqWYbQ;

	private bool EFRyjHXaGVTtiVFUebbPpghwPCf;

	private IUnifiedKeyboardSource IaJFakVcuQqRPXRTOUcPncNOHUh;

	private IUnifiedMouseSource jnwpLKAjJYsADMqwTXugbizunPZ;

	private int tIMqjoodLmiryAgugInUewIiEKvF;

	private ELmeHFhAEObgGMupfccwkercFbWz fsQBYUGDBZAPIrofCevqCtlZgkl;

	private aSOYcRCZqytuczbEAnlwvDhfgcsc YYmRYrIJJDlFmDKErJxqlPcJEZJ;

	private int joywuWQGYqpSFcUYCboBACmufu;

	private int DejVRMnZwHRZwPKsShsOBljwEkp;

	private Action<int, ControllerDataUpdater> QUkVarKxRmoXsssgEDMISvoeGki;

	private Action<bool, int, int> QMiCPxzJdlPxcFwOOrCyePONmUR;

	private Action<ControllerStatusChangedEventArgs> HYxyQVtTQdEAKmNoXhGfcCPuJkJ;

	private Action<ControllerType, int> GTBTISfJohKhcYpxTbauAjfRRick;

	private bool vsurYtRlepcrpAzAENwjqjJEZPT;

	public IList<Joystick> Joysticks_readOnly
	{
		get
		{
			return poUCnxmBnNufvZgOXkABYfeEyeL;
		}
	}

	public List<Joystick> Joysticks_orig
	{
		get
		{
			return ljUWisroiVgcxAxyrURnKFzSwIW;
		}
	}

	public int joystickCount
	{
		get
		{
			return ljUWisroiVgcxAxyrURnKFzSwIW.Count;
		}
	}

	public Mouse Mouse
	{
		get
		{
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok;
		}
	}

	public Keyboard Keyboard
	{
		get
		{
			return jXEbFYnmcSIgpclyYvQTdCKlRWYh;
		}
	}

	public IList<CustomController> CustomControllers_readOnly
	{
		get
		{
			return juQHBrmgiFgKrbVAwQAmAcgaZGvE;
		}
	}

	public List<CustomController> CustomControllers_orig
	{
		get
		{
			return SerYLNcBvSGLsDnWKlmIAbnbmflt;
		}
	}

	public int customControllerCount
	{
		get
		{
			return SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		}
	}

	public IList<Controller> Controllers
	{
		get
		{
			return UKWvMiRNcbklNCkYADHBcqobYeYc;
		}
	}

	public int controllerCount
	{
		get
		{
			return SZCeMxfPCTerGWEMwYOvsgmToRb.Count;
		}
	}

	private int nextCustomControllerId
	{
		get
		{
			int result = tIMqjoodLmiryAgugInUewIiEKvF;
			tIMqjoodLmiryAgugInUewIiEKvF++;
			if (tIMqjoodLmiryAgugInUewIiEKvF >= int.MaxValue)
			{
				while (true)
				{
					int num = -1121289202;
					while (true)
					{
						switch (num ^ -1121289204)
						{
						case 0:
							break;
						case 2:
							tIMqjoodLmiryAgugInUewIiEKvF = 0;
							num = -1121289203;
							continue;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return result;
		}
	}

	public event Action<ControllerStatusChangedEventArgs> ControllerDisconnectStartedEvent
	{
		add
		{
			HYxyQVtTQdEAKmNoXhGfcCPuJkJ = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(HYxyQVtTQdEAKmNoXhGfcCPuJkJ, value);
		}
		remove
		{
			HYxyQVtTQdEAKmNoXhGfcCPuJkJ = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(HYxyQVtTQdEAKmNoXhGfcCPuJkJ, value);
		}
	}

	public event Action<ControllerType, int> JustBeforeControllerFullyDisconnectedEvent
	{
		add
		{
			GTBTISfJohKhcYpxTbauAjfRRick = (Action<ControllerType, int>)Delegate.Combine(GTBTISfJohKhcYpxTbauAjfRRick, value);
		}
		remove
		{
			GTBTISfJohKhcYpxTbauAjfRRick = (Action<ControllerType, int>)Delegate.Remove(GTBTISfJohKhcYpxTbauAjfRRick, value);
		}
	}

	public GDZJmMlQvBAxDaQCuBIKYWggay(ConfigVars configVars, PlatformInputManager inputManager)
	{
		AzMyTQkqkOhQhSBeGZpAEMZVrzb = configVars;
		GDcIMXEHofUFbMLRxByZkXavcis = 0;
		BjfWKlABcPvhleltMQUKTCBPPhO = UnityTools.isAndroidPlatform;
		SZCeMxfPCTerGWEMwYOvsgmToRb = new List<Controller>(10);
		UKWvMiRNcbklNCkYADHBcqobYeYc = new ReadOnlyCollection<Controller>(SZCeMxfPCTerGWEMwYOvsgmToRb);
		IUnifiedKeyboardSource unifiedKeyboardSource = inputManager.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = (IaJFakVcuQqRPXRTOUcPncNOHUh = new UnityUnifiedKeyboardSource());
		}
		jXEbFYnmcSIgpclyYvQTdCKlRWYh = new Keyboard("Keyboard", unifiedKeyboardSource);
		SZCeMxfPCTerGWEMwYOvsgmToRb.Add(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		IUnifiedMouseSource unifiedMouseSource = inputManager.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = (jnwpLKAjJYsADMqwTXugbizunPZ = new UnityUnifiedMouseSource());
		}
		QuOyRGrgPJAIWhsKWmyPcWlaLYok = new Mouse("Mouse", unifiedMouseSource);
		SZCeMxfPCTerGWEMwYOvsgmToRb.Add(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		EooLpHTnerlwDrVwyPBbECOAJgQ = new dAsBJCqlFUZsWwFTjrjITxqcqDX(configVars.updateLoop, jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		jXEbFYnmcSIgpclyYvQTdCKlRWYh.EnabledStateChangedEvent += vNroSexmaJEzPHmQIpkWEjxjHIiJ;
		jXEbFYnmcSIgpclyYvQTdCKlRWYh.enabled = !configVars.GetPlatformVar_disableKeyboard();
		FtUOhuKrpcFhMbUykhhakrKdBrJc.EEGiMNPSMElaPgKQdmScoWLedfb();
		VdYbRIfIAqVYCJnTMRUdCcFYmUp = new COUAbpKeuXqLvBpbzwQGcJgjPueY(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		VdYbRIfIAqVYCJnTMRUdCcFYmUp.DQFfftDmidgQeZhyhKnTyuCofPy(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		VdYbRIfIAqVYCJnTMRUdCcFYmUp.DQFfftDmidgQeZhyhKnTyuCofPy(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		ReInput.ApplicationFocusChangedEvent += EyzHgLRlWvcWTAWdkRJsusIxnhij;
	}

	public void YJaAHaimrHWIfKrgfWxeihnqrcza(Action<int, ControllerDataUpdater> P_0, List<InputBehavior> P_1)
	{
		QUkVarKxRmoXsssgEDMISvoeGki = P_0;
		YJaAHaimrHWIfKrgfWxeihnqrcza(P_1);
	}

	public void UZSQFwoMfSAzsmmSKmseCCiJWWD(UpdateLoopType P_0)
	{
		FtUOhuKrpcFhMbUykhhakrKdBrJc.OxOMFHxDBJdXzWiIhdrXeiJbPOg(P_0);
		if (jXEbFYnmcSIgpclyYvQTdCKlRWYh.enabled)
		{
			EooLpHTnerlwDrVwyPBbECOAJgQ.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0);
			goto IL_001f;
		}
		goto IL_004d;
		IL_004d:
		xNnSiKXEXUWdMZfpXdaeKVSQkMIY(P_0);
		int num = 1203722578;
		goto IL_0024;
		IL_001f:
		num = 1203722579;
		goto IL_0024;
		IL_0024:
		while (true)
		{
			switch (num ^ 0x47BF5952)
			{
			case 6:
				break;
			default:
				return;
			case 1:
				goto IL_004d;
			case 0:
				UCSoyDBBPCcCFPmSSWMaVFflWoW(P_0);
				num = 1203722582;
				continue;
			case 4:
				FtUOhuKrpcFhMbUykhhakrKdBrJc.qUtdEAejAgLRObEPHBpzaevAeTR(P_0, ReInput.currentFrame);
				num = 1203722576;
				continue;
			case 5:
				hvYGHfdgiJvHHhiqYAABhqHARrpA();
				num = 1203722577;
				continue;
			case 2:
				goto IL_0088;
			case 3:
				return;
			}
			break;
			IL_0088:
			int num2;
			if (!EFRyjHXaGVTtiVFUebbPpghwPCf)
			{
				num = 1203722577;
				num2 = num;
			}
			else
			{
				num = 1203722583;
				num2 = num;
			}
		}
		goto IL_001f;
	}

	public pEQcyInzaqspNDwmuMYGrewsNaQ bjnqvpILJQKZbVguFAHRXYXTit(int P_0, string P_1, bool P_2)
	{
		int num = fsQBYUGDBZAPIrofCevqCtlZgkl.EAgOMouOjbslHCCsyBDLoGVrHcd(P_1, P_2);
		while (true)
		{
			int num2 = -1486545561;
			while (true)
			{
				switch (num2 ^ -1486545562)
				{
				case 2:
					break;
				case 1:
					if (num < 0)
					{
						return null;
					}
					if (P_0 == 9999999)
					{
						return SvjizdwKEpuZnQwaTMQhTsXvjJZ[num];
					}
					if (P_0 >= 0)
					{
						if (P_0 >= joywuWQGYqpSFcUYCboBACmufu)
						{
							goto IL_0050;
						}
						return foeClgLCNvRZehESwXDKoKqlzhE[P_0, num];
					}
					goto default;
				default:
					return null;
				}
				break;
				IL_0050:
				num2 = -1486545562;
			}
		}
	}

	public pEQcyInzaqspNDwmuMYGrewsNaQ bjnqvpILJQKZbVguFAHRXYXTit(int P_0, int P_1, bool P_2)
	{
		int num = fsQBYUGDBZAPIrofCevqCtlZgkl.EAgOMouOjbslHCCsyBDLoGVrHcd(P_1, P_2);
		while (true)
		{
			int num2 = 1585996899;
			while (true)
			{
				switch (num2 ^ 0x5E886462)
				{
				case 0:
					break;
				case 1:
					if (num < 0)
					{
						goto IL_0030;
					}
					if (P_0 == 9999999)
					{
						return SvjizdwKEpuZnQwaTMQhTsXvjJZ[num];
					}
					return foeClgLCNvRZehESwXDKoKqlzhE[P_0, num];
				default:
					return null;
				}
				break;
				IL_0030:
				num2 = 1585996896;
			}
		}
	}

	public void KvDObPgkKVXEfRCBiWbffrDzKAV(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_004d;
		IL_0003:
		int num = -1003135728;
		goto IL_0008;
		IL_0008:
		QHWSqSXjZtJVmIWvTGBJmFrgKKs qHWSqSXjZtJVmIWvTGBJmFrgKKs = default(QHWSqSXjZtJVmIWvTGBJmFrgKKs);
		int num2 = default(int);
		Joystick joystick = default(Joystick);
		while (true)
		{
			switch (num ^ -1003135725)
			{
			case 4:
				break;
			default:
				return;
			case 6:
				goto IL_0044;
			case 8:
				goto IL_004d;
			case 5:
				joystick = ((qHWSqSXjZtJVmIWvTGBJmFrgKKs != QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI) ? (joystick = WOkGQHhtpdLVigwYGRvwGFhkDhLg[num2]) : (joystick = ljUWisroiVgcxAxyrURnKFzSwIW[num2]));
				num = -1003135727;
				continue;
			case 7:
				num2 = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0.sourceJoystick.rewiredId, qHWSqSXjZtJVmIWvTGBJmFrgKKs);
				num = -1003135725;
				continue;
			case 0:
				goto IL_00a3;
			case 2:
				joystick.UpdateControllerInfo(P_0);
				num = -1003135718;
				continue;
			case 1:
				qHWSqSXjZtJVmIWvTGBJmFrgKKs = QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ;
				num2 = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0.sourceJoystick.rewiredId, qHWSqSXjZtJVmIWvTGBJmFrgKKs);
				num = -1003135719;
				continue;
			case 3:
				return;
			case 10:
				if (num2 < 0)
				{
					return;
				}
				goto case 5;
			case 9:
				return;
			}
			break;
			IL_00a3:
			int num3;
			if (num2 >= 0)
			{
				num = -1003135719;
				num3 = num;
			}
			else
			{
				num = -1003135726;
				num3 = num;
			}
		}
		goto IL_0003;
		IL_004d:
		if (P_0.sourceJoystick == null)
		{
			return;
		}
		goto IL_0044;
		IL_0044:
		qHWSqSXjZtJVmIWvTGBJmFrgKKs = QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI;
		num = -1003135724;
		goto IL_0008;
	}

	public bool dlZbucGebMaNWEppcwOttchMZEZ(int P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs P_1)
	{
		if (MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, P_1) < 0)
		{
			return false;
		}
		return true;
	}

	public int MVddJGenopCEgjpwBbgsGYNfGAJd(int P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs P_1)
	{
		int count = default(int);
		if (P_1 == QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI)
		{
			count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
			goto IL_000f;
		}
		goto IL_006e;
		IL_006e:
		int num;
		int num2;
		if (P_1 == QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ)
		{
			num = -1610615566;
			num2 = num;
		}
		else
		{
			num = -1610615567;
			num2 = num;
		}
		goto IL_0014;
		IL_000f:
		num = -1610615560;
		goto IL_0014;
		IL_0014:
		int count2 = default(int);
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -1610615565)
			{
			case 4:
				break;
			case 5:
				num = -1610615567;
				continue;
			case 1:
				count2 = WOkGQHhtpdLVigwYGRvwGFhkDhLg.Count;
				num = -1610615563;
				continue;
			case 0:
				goto IL_006e;
			case 11:
				num4 = 0;
				num = -1610615557;
				continue;
			case 8:
				goto IL_008c;
			case 7:
				num = -1610615558;
				continue;
			case 9:
				goto IL_00ae;
			case 10:
				goto IL_00c6;
			case 3:
				goto IL_00ea;
			case 6:
				num3 = 0;
				num = -1610615564;
				continue;
			default:
				return -1;
			}
			break;
			IL_00ea:
			if (WOkGQHhtpdLVigwYGRvwGFhkDhLg[num3].id == P_0)
			{
				return num3;
			}
			num3++;
			num = -1610615558;
			continue;
			IL_00ae:
			int num5;
			if (num3 >= count2)
			{
				num = -1610615567;
				num5 = num;
			}
			else
			{
				num = -1610615568;
				num5 = num;
			}
			continue;
			IL_008c:
			int num6;
			if (num4 >= count)
			{
				num = -1610615562;
				num6 = num;
			}
			else
			{
				num = -1610615559;
				num6 = num;
			}
			continue;
			IL_00c6:
			if (ljUWisroiVgcxAxyrURnKFzSwIW[num4].id == P_0)
			{
				return num4;
			}
			num4++;
			num = -1610615557;
		}
		goto IL_000f;
	}

	public int MVddJGenopCEgjpwBbgsGYNfGAJd(Guid P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs P_1)
	{
		int count = default(int);
		int num = default(int);
		if (P_1 == QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI)
		{
			count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
			num = 0;
			goto IL_0011;
		}
		goto IL_0077;
		IL_00e9:
		return -1;
		IL_0011:
		int num2 = -727008831;
		goto IL_0016;
		IL_0016:
		int num3 = default(int);
		int count2 = default(int);
		while (true)
		{
			switch (num2 ^ -727008825)
			{
			case 7:
				break;
			case 4:
				num2 = -727008830;
				continue;
			case 3:
				goto IL_0051;
			case 0:
				goto IL_0077;
			case 1:
				if (num >= count)
				{
					num2 = -727008827;
					continue;
				}
				goto IL_0051;
			case 5:
				goto IL_009e;
			case 8:
				goto IL_00b6;
			case 6:
				num2 = -727008826;
				continue;
			default:
				goto IL_00e9;
			}
			break;
			IL_00b6:
			if (WOkGQHhtpdLVigwYGRvwGFhkDhLg[num3].deviceInstanceGuid == P_0)
			{
				return num3;
			}
			num3++;
			num2 = -727008830;
			continue;
			IL_009e:
			int num4;
			if (num3 < count2)
			{
				num2 = -727008817;
				num4 = num2;
			}
			else
			{
				num2 = -727008827;
				num4 = num2;
			}
			continue;
			IL_0051:
			if (ljUWisroiVgcxAxyrURnKFzSwIW[num].deviceInstanceGuid == P_0)
			{
				return num;
			}
			num++;
			num2 = -727008826;
		}
		goto IL_0011;
		IL_0077:
		if (P_1 == QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ)
		{
			count2 = WOkGQHhtpdLVigwYGRvwGFhkDhLg.Count;
			num3 = 0;
			num2 = -727008829;
			goto IL_0016;
		}
		goto IL_00e9;
	}

	public bool lopuLzlLdjjrrfTVHPUvXpSqLYhe(int P_0)
	{
		if (aZETMgvqBdrjZRKEbRgQHXQbAPZ(P_0) < 0)
		{
			return false;
		}
		return true;
	}

	public int aZETMgvqBdrjZRKEbRgQHXQbAPZ(int P_0)
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num].id == P_0)
				{
					return num;
				}
				num++;
				int num2 = 330220217;
				while (true)
				{
					switch (num2 ^ 0x13AEC2BB)
					{
					case 0:
						num2 = 330220218;
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
		return -1;
	}

	public int aZETMgvqBdrjZRKEbRgQHXQbAPZ(Guid P_0)
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1301964352;
			while (true)
			{
				switch (num ^ -1301964351)
				{
				case 3:
					break;
				case 2:
				{
					int num3;
					if (num2 >= count)
					{
						num = -1301964351;
						num3 = num;
					}
					else
					{
						num = -1301964347;
						num3 = num;
					}
					continue;
				}
				case 4:
					if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num2].deviceInstanceGuid == P_0)
					{
						return num2;
					}
					num2++;
					num = -1301964349;
					continue;
				case 1:
					num2 = 0;
					num = -1301964349;
					continue;
				default:
					return -1;
				}
				break;
			}
		}
	}

	public void MUZomcvffRvxBbnbXumOjuySHCf(BridgedController P_0)
	{
		sHKhigLcFTAmJBMvavDUBReRBuoC(P_0);
	}

	public void kijbodcZCTsLoFANBiNEaBqeVJqy(int P_0)
	{
		int num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI);
		lTyhkulXbCdtDtysMmQBOBDZnP(num);
	}

	public int UQzWJBealOjhTSlSnpEFEtDicBl()
	{
		return GDcIMXEHofUFbMLRxByZkXavcis++;
	}

	public IList<InputBehavior> AZfCriglBpScRjCKKIHazXbFxQw(int P_0)
	{
		if (!WzMgptRXjmFPvUJSfynOIPTzDEq.ContainsKey(P_0))
		{
			return new List<InputBehavior>();
		}
		return WzMgptRXjmFPvUJSfynOIPTzDEq[P_0].aNtiLqNHPNHiknBJkIyrwnQzmQZ;
	}

	public InputBehavior PGOUkCbsoZNspmHpDpamPSYOIDN(int P_0, string P_1)
	{
		if (P_1 == null || P_1 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(P_1);
		return PGOUkCbsoZNspmHpDpamPSYOIDN(P_0, inputBehaviorId);
	}

	public InputBehavior PGOUkCbsoZNspmHpDpamPSYOIDN(int P_0, int P_1)
	{
		if (!WzMgptRXjmFPvUJSfynOIPTzDEq.ContainsKey(P_0))
		{
			return null;
		}
		IList<InputBehavior> aNtiLqNHPNHiknBJkIyrwnQzmQZ = WzMgptRXjmFPvUJSfynOIPTzDEq[P_0].aNtiLqNHPNHiknBJkIyrwnQzmQZ;
		int num2 = default(int);
		while (true)
		{
			int num = 332419085;
			while (true)
			{
				switch (num ^ 0x13D05009)
				{
				case 2:
					break;
				case 3:
					return aNtiLqNHPNHiknBJkIyrwnQzmQZ[num2];
				case 0:
					if (aNtiLqNHPNHiknBJkIyrwnQzmQZ[num2].id != P_1)
					{
						num2++;
						num = 332419080;
					}
					else
					{
						num = 332419082;
					}
					continue;
				case 4:
					num2 = 0;
					num = 332419080;
					continue;
				default:
					if (num2 >= aNtiLqNHPNHiknBJkIyrwnQzmQZ.Count)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public Joystick HdBPhTkbiFfgMcBErhvqAsSyrQkh(int P_0, bool P_1 = false)
	{
		int num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI);
		if (num >= 0)
		{
			goto IL_000d;
		}
		int num2;
		if (P_1)
		{
			num2 = -994323376;
			goto IL_0012;
		}
		goto IL_0067;
		IL_0012:
		while (true)
		{
			switch (num2 ^ -994323373)
			{
			case 0:
				break;
			case 1:
				return ljUWisroiVgcxAxyrURnKFzSwIW[num];
			case 3:
				goto IL_0046;
			default:
				return WOkGQHhtpdLVigwYGRvwGFhkDhLg[num];
			}
			break;
			IL_0046:
			num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ);
			if (num >= 0)
			{
				num2 = -994323375;
				continue;
			}
			goto IL_0067;
		}
		goto IL_000d;
		IL_0067:
		return null;
		IL_000d:
		num2 = -994323374;
		goto IL_0012;
	}

	public Joystick HdBPhTkbiFfgMcBErhvqAsSyrQkh(Guid P_0, bool P_1 = false)
	{
		int num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI);
		if (num >= 0)
		{
			goto IL_000d;
		}
		int num2;
		if (P_1)
		{
			num2 = 1762777762;
			goto IL_0012;
		}
		goto IL_0067;
		IL_0067:
		return null;
		IL_0056:
		if (num >= 0)
		{
			return WOkGQHhtpdLVigwYGRvwGFhkDhLg[num];
		}
		goto IL_0067;
		IL_000d:
		num2 = 1762777763;
		goto IL_0012;
		IL_0012:
		while (true)
		{
			switch (num2 ^ 0x6911DAA1)
			{
			case 0:
				break;
			case 2:
				return ljUWisroiVgcxAxyrURnKFzSwIW[num];
			case 3:
				num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0, QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ);
				num2 = 1762777760;
				continue;
			default:
				goto IL_0056;
			}
			break;
		}
		goto IL_000d;
	}

	public Joystick[] yARKJLpVwqykAxkbtlhhKaDMntB()
	{
		int count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
		if (count == 0)
		{
			goto IL_000f;
		}
		Joystick[] array = new Joystick[count];
		int num = 0;
		int num2 = 820658677;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x30EA41F5)
			{
			case 4:
				break;
			case 2:
				num++;
				num2 = 820658677;
				continue;
			case 1:
				array[num] = ljUWisroiVgcxAxyrURnKFzSwIW[num];
				num2 = 820658679;
				continue;
			case 3:
				return null;
			default:
				if (num >= count)
				{
					return array;
				}
				goto case 1;
			}
			break;
		}
		goto IL_000f;
		IL_000f:
		num2 = 820658678;
		goto IL_0014;
	}

	public string[] HgpEFuOTfjcrtkcfTZddAvYFekAH()
	{
		int count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
		string[] array = default(string[]);
		int num2 = default(int);
		while (true)
		{
			int num = 91462283;
			while (true)
			{
				switch (num ^ 0x5739A8A)
				{
				case 2:
					break;
				case 1:
					if (count == 0)
					{
						return null;
					}
					array = new string[count];
					num2 = 0;
					num = 91462281;
					continue;
				case 0:
					array[num2] = ljUWisroiVgcxAxyrURnKFzSwIW[num2].name;
					num2++;
					num = 91462281;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public CustomController dOxDsRbYgwssswpHNBlxDmcEQwpQ(int P_0)
	{
		int num = aZETMgvqBdrjZRKEbRgQHXQbAPZ(P_0);
		if (num < 0)
		{
			return null;
		}
		return SerYLNcBvSGLsDnWKlmIAbnbmflt[num];
	}

	public CustomController dOxDsRbYgwssswpHNBlxDmcEQwpQ(Guid P_0)
	{
		int num = aZETMgvqBdrjZRKEbRgQHXQbAPZ(P_0);
		if (num < 0)
		{
			return null;
		}
		return SerYLNcBvSGLsDnWKlmIAbnbmflt[num];
	}

	public CustomController[] EbYFOTvFKCuoEvFYAWZtKrYvFBq()
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		if (count == 0)
		{
			return null;
		}
		CustomController[] array = new CustomController[count];
		int num = 0;
		while (true)
		{
			int num2 = 1329660581;
			while (true)
			{
				switch (num2 ^ 0x4F4102A4)
				{
				case 3:
					break;
				case 1:
					num2 = 1329660580;
					continue;
				case 2:
					array[num] = SerYLNcBvSGLsDnWKlmIAbnbmflt[num];
					num++;
					num2 = 1329660580;
					continue;
				default:
					if (num >= count)
					{
						return array;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	public string[] QWKSlIFhfqeVPszZQFaCinOHgNd()
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		int num2 = default(int);
		string[] array = default(string[]);
		while (true)
		{
			int num = 1663987183;
			while (true)
			{
				switch (num ^ 0x632E6DEC)
				{
				case 5:
					break;
				case 2:
					num2 = 0;
					num = 1663987181;
					continue;
				case 4:
					return null;
				case 6:
					array[num2] = SerYLNcBvSGLsDnWKlmIAbnbmflt[num2].name;
					num = 1663987180;
					continue;
				case 3:
					if (count != 0)
					{
						array = new string[count];
						num = 1663987182;
					}
					else
					{
						num = 1663987176;
					}
					continue;
				case 0:
					num2++;
					num = 1663987181;
					continue;
				default:
					if (num2 >= count)
					{
						return array;
					}
					goto case 6;
				}
				break;
			}
		}
	}

	public CustomController CsSqgDydbucgPfMxmGgEHFxjOsCu(int P_0)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(P_0);
		if (customControllerById == null)
		{
			return null;
		}
		int yZYerWLyrZezITIzzsjvGpplKQw = nextCustomControllerId;
		kSarBqLUpbjSYJYRRnTdWDHCPuD kSarBqLUpbjSYJYRRnTdWDHCPuD2 = new kSarBqLUpbjSYJYRRnTdWDHCPuD();
		kSarBqLUpbjSYJYRRnTdWDHCPuD2.WVeuvvGVKxuwIVofyhIJOpLcDjb = InputSource.Custom;
		kSarBqLUpbjSYJYRRnTdWDHCPuD2.MMbWxTmxKwcWWMhVwLNlEkYBAMS = customControllerById.descriptiveName;
		CustomController customController = default(CustomController);
		while (true)
		{
			int num = -1023754404;
			while (true)
			{
				switch (num ^ -1023754406)
				{
				case 0:
					break;
				case 2:
				{
					kSarBqLUpbjSYJYRRnTdWDHCPuD data = kSarBqLUpbjSYJYRRnTdWDHCPuD2;
					customController = new CustomController(data);
					num = -1023754407;
					continue;
				}
				case 5:
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.vuToNXjJNzINjbcxQPiHIIiUPZb = customControllerById.id;
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.nrRGcDtTrsjNDnwfdqSbSUqyNkC = customControllerById.typeGuid;
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.rFUeqRiFdjyAEcgvioRQEeBxRMiT = customControllerById.id.ToString();
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.LsVaVuksnFAOffJvSNKbyOxlzXL = customControllerById.KDogQqmgPVdWpEwZDagggKagBxV();
					num = -1023754408;
					continue;
				case 1:
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.YZYerWLyrZezITIzzsjvGpplKQw = yZYerWLyrZezITIzzsjvGpplKQw;
					num = -1023754401;
					continue;
				case 3:
					NsKfrPICAOsMNxuGJtMJgtOYkyHW(customController);
					num = -1023754402;
					continue;
				case 6:
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.qavxNgFSMXrtkmTbLrBlcGAYqOV = customControllerById.name;
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.TwhUkSEboxGPsJgqbpmupSCMcvva = customControllerById.axisCount;
					kSarBqLUpbjSYJYRRnTdWDHCPuD2.SgYwVaEgtCZiUkgVDcTwJWbyDTtb = customControllerById.buttonCount;
					num = -1023754405;
					continue;
				default:
					return customController;
				}
				break;
			}
		}
	}

	public bool EVnpvZIrAcNODdZQaLMBXPDzApq(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return PDQUjpckXCQXzCfTVwQoaafKrYv(P_0);
	}

	public CustomController HlhFVHUxIasHZyxbsYPjOGYQVyz(int P_0)
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num].sourceControllerId == P_0)
				{
					return SerYLNcBvSGLsDnWKlmIAbnbmflt[num];
				}
				num++;
				int num2 = 782159364;
				while (true)
				{
					switch (num2 ^ 0x2E9ECE04)
					{
					case 2:
						num2 = 782159365;
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

	public CustomController KMbUIhdqGaPqbHDWNtKCkLsREzi(string P_0)
	{
		int count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
		int num = 0;
		while (true)
		{
			int num2 = -41287629;
			while (true)
			{
				switch (num2 ^ -41287630)
				{
				case 2:
					break;
				case 0:
				{
					int num3;
					if (num >= count)
					{
						num2 = -41287626;
						num3 = num2;
					}
					else
					{
						num2 = -41287631;
						num3 = num2;
					}
					continue;
				}
				case 3:
					if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num].tag.Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						return SerYLNcBvSGLsDnWKlmIAbnbmflt[num];
					}
					num++;
					num2 = -41287630;
					continue;
				case 1:
					num2 = -41287630;
					continue;
				default:
					return null;
				}
				break;
			}
		}
	}

	public IEnumerable<CustomController> BZdtHfYSFNaqjdiUuvmROjStEJNb(int P_0)
	{
		nZktPjeesrinVBbcnOuaDQrjBat nZktPjeesrinVBbcnOuaDQrjBat2 = new nZktPjeesrinVBbcnOuaDQrjBat(-2);
		nZktPjeesrinVBbcnOuaDQrjBat2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
		nZktPjeesrinVBbcnOuaDQrjBat2.WxxaCeWPgDWOfrKEGwmhasjZNWV = P_0;
		return nZktPjeesrinVBbcnOuaDQrjBat2;
	}

	public IEnumerable<CustomController> xqEqxbfLSxeLCMGiZbUzrwUOwzb(string P_0)
	{
		pweWePWNjpWYtGljeBEcgSVAkQA pweWePWNjpWYtGljeBEcgSVAkQA2 = new pweWePWNjpWYtGljeBEcgSVAkQA(-2);
		pweWePWNjpWYtGljeBEcgSVAkQA2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
		pweWePWNjpWYtGljeBEcgSVAkQA2.wSagivdJDpAKobJbTLYNmfxUdevu = P_0;
		return pweWePWNjpWYtGljeBEcgSVAkQA2;
	}

	public Controller lHAHnEiPErByQLPNWMxnJGMpiHF(ControllerType P_0, int P_1, bool P_2 = false)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				switch (0x59583821 ^ 0x59583820)
				{
				case 0:
					continue;
				case 1:
					if (P_0 == ControllerType.Custom)
					{
						return dOxDsRbYgwssswpHNBlxDmcEQwpQ(P_1);
					}
					throw new NotImplementedException();
				}
				break;
			}
			goto case ControllerType.Joystick;
		case ControllerType.Joystick:
			return HdBPhTkbiFfgMcBErhvqAsSyrQkh(P_1, P_2);
		case ControllerType.Keyboard:
			return jXEbFYnmcSIgpclyYvQTdCKlRWYh;
		case ControllerType.Mouse:
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok;
		}
	}

	public Controller lHAHnEiPErByQLPNWMxnJGMpiHF(ControllerIdentifier P_0, bool P_1 = false)
	{
		if (P_0.deviceInstanceGuid != Guid.Empty)
		{
			return lHAHnEiPErByQLPNWMxnJGMpiHF(P_0.deviceInstanceGuid);
		}
		if (P_0.controllerId >= 0)
		{
			return lHAHnEiPErByQLPNWMxnJGMpiHF(P_0.controllerType, P_0.controllerId, P_1);
		}
		return null;
	}

	public Controller lHAHnEiPErByQLPNWMxnJGMpiHF(Guid P_0, bool P_1 = false)
	{
		if (P_0 == Guid.Empty)
		{
			return null;
		}
		if (jXEbFYnmcSIgpclyYvQTdCKlRWYh.deviceInstanceGuid == P_0)
		{
			return jXEbFYnmcSIgpclyYvQTdCKlRWYh;
		}
		if (QuOyRGrgPJAIWhsKWmyPcWlaLYok.deviceInstanceGuid == P_0)
		{
			return QuOyRGrgPJAIWhsKWmyPcWlaLYok;
		}
		Controller result;
		if ((result = HdBPhTkbiFfgMcBErhvqAsSyrQkh(P_0, P_1)) != null)
		{
			goto IL_004f;
		}
		int num;
		if ((result = dOxDsRbYgwssswpHNBlxDmcEQwpQ(P_0)) != null)
		{
			num = -1494182243;
			goto IL_0054;
		}
		return null;
		IL_004f:
		num = -1494182242;
		goto IL_0054;
		IL_0054:
		switch (num ^ -1494182244)
		{
		case 0:
			break;
		case 2:
			return result;
		default:
			return result;
		}
		goto IL_004f;
	}

	public Controller[] OPcYGIKytcTOUigOIgZYDPtgITmB(ControllerType P_0)
	{
		Controller[] array = default(Controller[]);
		while (true)
		{
			int num = -1426599999;
			while (true)
			{
				switch (num ^ -1426599995)
				{
				case 0:
					break;
				case 1:
					if (P_0 != ControllerType.Custom)
					{
						num = -1426599993;
						continue;
					}
					return EbYFOTvFKCuoEvFYAWZtKrYvFBq();
				case 4:
					switch (P_0)
					{
					default:
						num = -1426599996;
						continue;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						array = new Controller[1];
						num = -1426599994;
						continue;
					case ControllerType.Mouse:
						return new Controller[1] { QuOyRGrgPJAIWhsKWmyPcWlaLYok };
					}
					goto case 5;
				case 5:
					return yARKJLpVwqykAxkbtlhhKaDMntB();
				case 3:
					array[0] = jXEbFYnmcSIgpclyYvQTdCKlRWYh;
					num = -1426599997;
					continue;
				default:
					return array;
				case 2:
					throw new NotImplementedException();
				}
				break;
			}
		}
	}

	public string[] lExTCkyJjLcgbMzvInagSFvQJfL(ControllerType P_0)
	{
		int num;
		string[] array = default(string[]);
		switch (P_0)
		{
		default:
			num = 395470527;
			goto IL_001e;
		case ControllerType.Joystick:
			goto IL_0044;
		case ControllerType.Keyboard:
			return new string[1] { jXEbFYnmcSIgpclyYvQTdCKlRWYh.name };
		case ControllerType.Mouse:
			array = new string[1];
			num = 395470525;
			goto IL_001e;
		case ControllerType.Custom:
			{
				return QWKSlIFhfqeVPszZQFaCinOHgNd();
			}
			IL_001e:
			switch (num ^ 0x179266BE)
			{
			case 2:
				break;
			case 0:
				goto IL_0044;
			default:
				array[0] = QuOyRGrgPJAIWhsKWmyPcWlaLYok.name;
				return array;
			case 1:
				throw new NotImplementedException();
			}
			goto default;
			IL_0044:
			return HgpEFuOTfjcrtkcfTZddAvYFekAH();
		}
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
			while (true)
			{
				switch (-173010615 ^ -173010613)
				{
				case 0:
					break;
				case 2:
					goto end_IL_000f;
				default:
					goto IL_0040;
				}
				continue;
				end_IL_000f:
				break;
			}
		}
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		goto IL_0040;
		IL_0040:
		pCItYZcmQVbRIIUnLbZiPkYVRSE.qlbbxAfDiGgDoAbvzdeYICHvGcx(P_1, P_2, InputActionEventType.Update, null);
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			goto IL_0008;
		}
		goto IL_004f;
		IL_0008:
		int num = -579077425;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -579077426)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
				num = -579077428;
				continue;
			case 4:
				goto IL_003c;
			case 2:
				goto IL_004f;
			case 0:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_003c:
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = default(PCItYZcmQVbRIIUnLbZiPkYVRSE);
		pCItYZcmQVbRIIUnLbZiPkYVRSE.qlbbxAfDiGgDoAbvzdeYICHvGcx(P_1, P_2, InputActionEventType.Update, P_3, null);
		num = -579077426;
		goto IL_000d;
		IL_004f:
		pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		goto IL_003c;
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
			goto IL_000f;
		}
		goto IL_0035;
		IL_0035:
		int num = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_3);
		int num2 = 1961811889;
		goto IL_0014;
		IL_000f:
		num2 = 1961811894;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x74EEDFB2)
			{
			case 2:
				break;
			default:
				return;
			case 4:
				goto IL_0035;
			case 0:
				YKLnjNiRIGOFrTqGHiyNEITwoaXS(P_0, P_1, P_2, num);
				num2 = 1961811891;
				continue;
			case 3:
				if (num < 0)
				{
					return;
				}
				goto case 0;
			case 1:
				return;
			}
			break;
		}
		goto IL_000f;
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, object[] P_4)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
			goto IL_000f;
		}
		goto IL_0035;
		IL_0035:
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		int num = 1665811067;
		goto IL_0014;
		IL_000f:
		num = 1665811064;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ 0x634A427B)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				goto IL_0035;
			case 4:
				pCItYZcmQVbRIIUnLbZiPkYVRSE.qlbbxAfDiGgDoAbvzdeYICHvGcx(P_1, P_2, P_3, P_4);
				num = 1665811066;
				continue;
			case 0:
				if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
				{
					return;
				}
				goto case 4;
			case 1:
				return;
			}
			break;
		}
		goto IL_000f;
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4, object[] P_5)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
			goto IL_000f;
		}
		goto IL_0035;
		IL_0035:
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		int num = 2039252782;
		goto IL_0014;
		IL_000f:
		num = 2039252783;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ 0x798C872E)
			{
			case 3:
				break;
			case 1:
				goto IL_0035;
			case 0:
				goto IL_0044;
			case 2:
				return;
			default:
				pCItYZcmQVbRIIUnLbZiPkYVRSE.qlbbxAfDiGgDoAbvzdeYICHvGcx(P_1, P_2, P_3, P_4, P_5);
				return;
			}
			break;
			IL_0044:
			int num2;
			if (pCItYZcmQVbRIIUnLbZiPkYVRSE != null)
			{
				num = 2039252778;
				num2 = num;
			}
			else
			{
				num = 2039252780;
				num2 = num;
			}
		}
		goto IL_000f;
	}

	public void YKLnjNiRIGOFrTqGHiyNEITwoaXS(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4, object[] P_5)
	{
		if (!WcPcCkNEfbxlknYuEvMHciqWYbQ)
		{
			goto IL_0008;
		}
		goto IL_0044;
		IL_0008:
		int num = 1881091421;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x701F2D5C)
			{
			case 3:
				break;
			case 1:
				WcPcCkNEfbxlknYuEvMHciqWYbQ = true;
				num = 1881091420;
				continue;
			case 2:
				return;
			case 0:
				goto IL_0044;
			default:
				YKLnjNiRIGOFrTqGHiyNEITwoaXS(P_0, P_1, P_2, P_3, num2, P_5);
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0044:
		num2 = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_4);
		int num3;
		if (num2 >= 0)
		{
			num = 1881091416;
			num3 = num;
		}
		else
		{
			num = 1881091422;
			num3 = num;
		}
		goto IL_000d;
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE != null)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1);
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, int P_2)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		while (true)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2);
			int num = 1969897597;
			while (true)
			{
				switch (num ^ 0x756A407D)
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
				num = 1969897596;
			}
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, string P_2)
	{
		int num = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_2);
		if (num < 0)
		{
			while (true)
			{
				switch (-983525559 ^ -983525557)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		LiagTLLASWBPEIOfOmwKQTlNckf(P_0, P_1, num);
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		while (true)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2);
			int num = -784420289;
			while (true)
			{
				switch (num ^ -784420290)
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
				num = -784420292;
			}
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE != null)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2);
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, int P_3)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			goto IL_000b;
		}
		goto IL_0035;
		IL_000b:
		int num = 1088664937;
		goto IL_0010;
		IL_0010:
		switch (num ^ 0x40E3B568)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			return;
		case 2:
			goto IL_0035;
		case 0:
			return;
		}
		goto IL_000b;
		IL_0035:
		pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2, P_3);
		num = 1088664936;
		goto IL_0010;
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, string P_3)
	{
		int num = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_3);
		if (num < 0)
		{
			goto IL_0012;
		}
		goto IL_003c;
		IL_0012:
		int num2 = 528820154;
		goto IL_0017;
		IL_0017:
		switch (num2 ^ 0x1F8527BB)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			return;
		case 0:
			goto IL_003c;
		case 3:
			return;
		}
		goto IL_0012;
		IL_003c:
		LiagTLLASWBPEIOfOmwKQTlNckf(P_0, P_1, P_2, num);
		num2 = 528820152;
		goto IL_0017;
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, int P_3)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		while (true)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2, P_3);
			int num = -1700041914;
			while (true)
			{
				switch (num ^ -1700041916)
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
				num = -1700041915;
			}
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, InputActionEventType P_2, string P_3)
	{
		int num = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_3);
		if (num < 0)
		{
			while (true)
			{
				switch (-64662485 ^ -64662486)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		LiagTLLASWBPEIOfOmwKQTlNckf(P_0, P_1, P_2, num);
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			return;
		}
		while (true)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2, P_3);
			int num = -1543701328;
			while (true)
			{
				switch (num ^ -1543701326)
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
				num = -1543701325;
			}
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, int P_4)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE != null)
		{
			pCItYZcmQVbRIIUnLbZiPkYVRSE.FJHNCYGYhfbNGgXMnQKRPLpDCwz(P_1, P_2, P_3, P_4);
		}
	}

	public void LiagTLLASWBPEIOfOmwKQTlNckf(int P_0, Action<InputActionEventData> P_1, UpdateLoopType P_2, InputActionEventType P_3, string P_4)
	{
		int num = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl.OkVwBQxkkfcwcKXrVPmXPjftVOE(P_4);
		if (num >= 0)
		{
			LiagTLLASWBPEIOfOmwKQTlNckf(P_0, P_1, P_2, P_3, num);
		}
	}

	public void EArvERNKxsCTljIEgKYHziKREBnf(int P_0)
	{
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = mGctvOjPMlQAZKTkOBGjOzSTOLw(P_0);
		if (pCItYZcmQVbRIIUnLbZiPkYVRSE == null)
		{
			while (true)
			{
				switch (0x390F3D0B ^ 0x390F3D0A)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		pCItYZcmQVbRIIUnLbZiPkYVRSE.nympziBLtYDUiPlWNRoEGqbSPfa();
	}

	public bool hbaVKdNiezaApCknihMJJxpKVmfr(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_0062;
		}
		int num2;
		int actionCount = default(int);
		int num3 = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= joywuWQGYqpSFcUYCboBACmufu)
			{
				num2 = 1947706495;
			}
			else
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num3 = 0;
				num2 = 1947706493;
			}
			goto IL_0011;
		}
		goto IL_00c4;
		IL_0062:
		if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
		{
			return false;
		}
		goto IL_00ab;
		IL_00ab:
		if (!SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].lvyTpewEByrJQaPpHiuasLSeNzw())
		{
			num++;
			num2 = 1947706490;
		}
		else
		{
			num2 = 1947706489;
		}
		goto IL_0011;
		IL_0011:
		while (true)
		{
			switch (num2 ^ 0x7417A47C)
			{
			case 0:
				num2 = 1947706491;
				continue;
			case 4:
				break;
			case 6:
				goto end_IL_0011;
			case 1:
				goto IL_0083;
			case 5:
				return true;
			case 7:
				goto IL_00ab;
			case 3:
				goto IL_00c4;
			default:
				return false;
			}
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num3].lvyTpewEByrJQaPpHiuasLSeNzw())
			{
				return true;
			}
			num3++;
			num2 = 1947706493;
			continue;
			IL_0083:
			int num4;
			if (num3 < actionCount)
			{
				num2 = 1947706488;
				num4 = num2;
			}
			else
			{
				num2 = 1947706494;
				num4 = num2;
			}
			continue;
			end_IL_0011:
			break;
		}
		goto IL_0062;
		IL_00c4:
		return false;
	}

	public bool hfDqqeRmdHKLfSIdjIWgZfqLBAK(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00b0;
		}
		int actionCount = default(int);
		int num2 = default(int);
		int num3;
		if (P_0 >= 0)
		{
			if (P_0 < joywuWQGYqpSFcUYCboBACmufu)
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num2 = 0;
				num3 = -661030888;
			}
			else
			{
				num3 = -661030887;
			}
			goto IL_0014;
		}
		goto IL_0048;
		IL_0048:
		return false;
		IL_00b0:
		int num4;
		if (num < SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
		{
			num3 = -661030881;
			num4 = num3;
		}
		else
		{
			num3 = -661030884;
			num4 = num3;
		}
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num3 ^ -661030888)
			{
			case 8:
				num3 = -661030881;
				continue;
			case 1:
				break;
			case 5:
				goto IL_005f;
			case 4:
				return false;
			case 3:
				return true;
			case 6:
				return true;
			case 2:
				goto IL_00b0;
			case 7:
				goto IL_00cf;
			default:
				if (num2 >= actionCount)
				{
					return false;
				}
				goto IL_005f;
			}
			break;
			IL_00cf:
			if (!SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].kmPAfEKnCyTirEYSWkaOedaLedN())
			{
				num++;
				num3 = -661030886;
			}
			else
			{
				num3 = -661030885;
			}
			continue;
			IL_005f:
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num2].kmPAfEKnCyTirEYSWkaOedaLedN())
			{
				num3 = -661030882;
				continue;
			}
			num2++;
			num3 = -661030888;
		}
		goto IL_0048;
	}

	public bool wZKSNoBWOpjrinXaUHeBIeBBBrKb(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_000a;
		}
		int num2;
		int actionCount = default(int);
		int num3 = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= joywuWQGYqpSFcUYCboBACmufu)
			{
				num2 = 1245755835;
			}
			else
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num3 = 0;
				num2 = 1245755831;
			}
			goto IL_000f;
		}
		goto IL_0064;
		IL_000f:
		while (true)
		{
			switch (num2 ^ 0x4A40B9BF)
			{
			case 6:
				break;
			case 0:
				if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
				{
					return false;
				}
				goto IL_00b0;
			case 4:
				goto IL_0064;
			case 7:
				num2 = 1245755839;
				continue;
			case 3:
				goto IL_0082;
			case 8:
				num2 = 1245755834;
				continue;
			case 1:
				goto IL_00b0;
			case 5:
				goto IL_00cf;
			default:
				return false;
			}
			break;
			IL_00cf:
			int num4;
			if (num3 < actionCount)
			{
				num2 = 1245755836;
				num4 = num2;
			}
			else
			{
				num2 = 1245755837;
				num4 = num2;
			}
			continue;
			IL_0082:
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num3].OyXGTSwiLyydixsXoAkXTFGBrMP())
			{
				return true;
			}
			num3++;
			num2 = 1245755834;
			continue;
			IL_00b0:
			if (SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].OyXGTSwiLyydixsXoAkXTFGBrMP())
			{
				return true;
			}
			num++;
			num2 = 1245755839;
		}
		goto IL_000a;
		IL_000a:
		num2 = 1245755832;
		goto IL_000f;
		IL_0064:
		return false;
	}

	public bool penbFOlYjlxbXpanrLSHnVWHljO(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00a7;
		}
		int actionCount = default(int);
		int num2;
		if (P_0 >= 0)
		{
			if (P_0 < joywuWQGYqpSFcUYCboBACmufu)
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num2 = 1234024041;
			}
			else
			{
				num2 = 1234024045;
			}
			goto IL_0017;
		}
		goto IL_0079;
		IL_00a7:
		if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
		{
			return false;
		}
		goto IL_008e;
		IL_008e:
		if (!SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].tInrXBfJiKwsRBkSagZTLPBXVbJ())
		{
			num++;
			num2 = 1234024047;
		}
		else
		{
			num2 = 1234024034;
		}
		goto IL_0017;
		IL_0079:
		return false;
		IL_0017:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ 0x498DB66A)
			{
			case 6:
				num2 = 1234024046;
				continue;
			case 2:
				break;
			case 8:
				return true;
			case 7:
				goto end_IL_0017;
			case 4:
				goto IL_008e;
			case 5:
				goto IL_00a7;
			case 1:
				goto IL_00cb;
			case 3:
				num3 = 0;
				num2 = 1234024043;
				continue;
			default:
				return false;
			}
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num3].tInrXBfJiKwsRBkSagZTLPBXVbJ())
			{
				return true;
			}
			num3++;
			num2 = 1234024043;
			continue;
			IL_00cb:
			int num4;
			if (num3 >= actionCount)
			{
				num2 = 1234024042;
				num4 = num2;
			}
			else
			{
				num2 = 1234024040;
				num4 = num2;
			}
			continue;
			end_IL_0017:
			break;
		}
		goto IL_0079;
	}

	public bool BnjZLXRKvowBxjadAdKeaHlGYHj(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_000b;
		}
		int num;
		int num2;
		if (P_0 < 0)
		{
			num = -119715172;
			num2 = num;
		}
		else
		{
			num = -119715171;
			num2 = num;
		}
		goto IL_0010;
		IL_000b:
		num = -119715179;
		goto IL_0010;
		IL_0010:
		int num5 = default(int);
		int actionCount = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -119715171)
			{
			case 5:
				break;
			case 2:
				if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num5].WvSmeLExuitBNiAVEhCleOWlTFR())
				{
					return true;
				}
				num5++;
				num = -119715180;
				continue;
			case 9:
			{
				int num6;
				if (num5 < actionCount)
				{
					num = -119715169;
					num6 = num;
				}
				else
				{
					num = -119715175;
					num6 = num;
				}
				continue;
			}
			case 3:
			{
				int num4;
				if (num3 >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
				{
					num = -119715173;
					num4 = num;
				}
				else
				{
					num = -119715174;
					num4 = num;
				}
				continue;
			}
			case 8:
				num3 = 0;
				num = -119715170;
				continue;
			case 1:
				return false;
			case 0:
				if (P_0 < joywuWQGYqpSFcUYCboBACmufu)
				{
					actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
					num5 = 0;
					num = -119715177;
				}
				else
				{
					num = -119715172;
				}
				continue;
			case 10:
				num = -119715180;
				continue;
			case 6:
				return false;
			case 7:
				if (SvjizdwKEpuZnQwaTMQhTsXvjJZ[num3].WvSmeLExuitBNiAVEhCleOWlTFR())
				{
					return true;
				}
				num3++;
				num = -119715170;
				continue;
			default:
				return false;
			}
			break;
		}
		goto IL_000b;
	}

	public bool NswBnbHsHjmAbdccbHKidIZwDLL(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_00a1;
		}
		int actionCount = default(int);
		int num2 = default(int);
		int num3;
		if (P_0 >= 0)
		{
			if (P_0 < joywuWQGYqpSFcUYCboBACmufu)
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num2 = 0;
				num3 = 527672994;
			}
			else
			{
				num3 = 527672999;
			}
			goto IL_0017;
		}
		goto IL_0043;
		IL_00a1:
		if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
		{
			return false;
		}
		goto IL_0088;
		IL_0088:
		if (!SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].EYuDJVDMraHBZVsAfWxxjYhezKIh())
		{
			num++;
			num3 = 527672992;
		}
		else
		{
			num3 = 527672993;
		}
		goto IL_0017;
		IL_0017:
		while (true)
		{
			switch (num3 ^ 0x1F73A6A1)
			{
			case 2:
				num3 = 527672996;
				continue;
			case 6:
				break;
			case 4:
				goto IL_005a;
			case 0:
				return true;
			case 5:
				goto IL_0088;
			case 1:
				goto IL_00a1;
			default:
				if (num2 >= actionCount)
				{
					return false;
				}
				goto IL_005a;
			}
			break;
			IL_005a:
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num2].EYuDJVDMraHBZVsAfWxxjYhezKIh())
			{
				return true;
			}
			num2++;
			num3 = 527672994;
		}
		goto IL_0043;
		IL_0043:
		return false;
	}

	public bool cphbBIiUQocipvoeVcwcEBuYilN(int P_0)
	{
		int num = default(int);
		if (P_0 == 9999999)
		{
			num = 0;
			goto IL_0059;
		}
		int num2;
		int actionCount = default(int);
		if (P_0 >= 0)
		{
			if (P_0 >= joywuWQGYqpSFcUYCboBACmufu)
			{
				num2 = -1650554340;
			}
			else
			{
				actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
				num2 = -1650554338;
			}
			goto IL_0011;
		}
		goto IL_00a7;
		IL_0059:
		if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
		{
			return false;
		}
		goto IL_003d;
		IL_003d:
		if (SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].RvVOlcFiiUoCnzwclOyOUWFywkR())
		{
			return true;
		}
		num++;
		num2 = -1650554342;
		goto IL_0011;
		IL_0011:
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ -1650554344)
			{
			case 0:
				num2 = -1650554341;
				continue;
			case 3:
				break;
			case 2:
				goto IL_0059;
			case 6:
				num3 = 0;
				num2 = -1650554343;
				continue;
			case 5:
				goto IL_0083;
			case 4:
				goto IL_00a7;
			default:
				if (num3 >= actionCount)
				{
					return false;
				}
				goto IL_0083;
			}
			break;
			IL_0083:
			if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num3].RvVOlcFiiUoCnzwclOyOUWFywkR())
			{
				return true;
			}
			num3++;
			num2 = -1650554343;
		}
		goto IL_003d;
		IL_00a7:
		return false;
	}

	public bool ystdwVOPGQAtKEyInCLdcHrkMxVl(int P_0)
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
			num2 = 713770107;
			num3 = num2;
		}
		else
		{
			num2 = 713770096;
			num3 = num2;
		}
		goto IL_0012;
		IL_000d:
		num2 = 713770111;
		goto IL_0012;
		IL_0012:
		int num4 = default(int);
		int actionCount = default(int);
		while (true)
		{
			switch (num2 ^ 0x2A8B447A)
			{
			case 6:
				break;
			case 5:
				num2 = 713770106;
				continue;
			case 9:
				if (SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].BlgxYmcQCnviNYPYAGDfxudXrYl())
				{
					return true;
				}
				num++;
				num2 = 713770106;
				continue;
			case 7:
				if (foeClgLCNvRZehESwXDKoKqlzhE[P_0, num4].BlgxYmcQCnviNYPYAGDfxudXrYl())
				{
					return true;
				}
				num4++;
				num2 = 713770110;
				continue;
			case 10:
				return false;
			case 0:
			{
				int num5;
				if (num >= SvjizdwKEpuZnQwaTMQhTsXvjJZ.Length)
				{
					num2 = 713770104;
					num5 = num2;
				}
				else
				{
					num2 = 713770099;
					num5 = num2;
				}
				continue;
			}
			case 2:
				return false;
			case 3:
				num4 = 0;
				num2 = 713770098;
				continue;
			case 1:
				if (P_0 < joywuWQGYqpSFcUYCboBACmufu)
				{
					actionCount = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
					num2 = 713770105;
				}
				else
				{
					num2 = 713770096;
				}
				continue;
			case 8:
				num2 = 713770110;
				continue;
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

	public bool wxwAjVCMxfwnKDPztUMmjYjdLJw()
	{
		if (!wxwAjVCMxfwnKDPztUMmjYjdLJw(QuOyRGrgPJAIWhsKWmyPcWlaLYok) && !wxwAjVCMxfwnKDPztUMmjYjdLJw(ljUWisroiVgcxAxyrURnKFzSwIW) && !wxwAjVCMxfwnKDPztUMmjYjdLJw(jXEbFYnmcSIgpclyYvQTdCKlRWYh))
		{
			return wxwAjVCMxfwnKDPztUMmjYjdLJw(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		}
		return true;
	}

	public bool wxwAjVCMxfwnKDPztUMmjYjdLJw(ControllerType P_0)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				switch (0x5566E6F4 ^ 0x5566E6F5)
				{
				case 0:
					continue;
				case 1:
					if (P_0 == ControllerType.Custom)
					{
						return wxwAjVCMxfwnKDPztUMmjYjdLJw(SerYLNcBvSGLsDnWKlmIAbnbmflt);
					}
					throw new NotImplementedException();
				}
				break;
			}
			goto case ControllerType.Joystick;
		case ControllerType.Joystick:
			return wxwAjVCMxfwnKDPztUMmjYjdLJw(ljUWisroiVgcxAxyrURnKFzSwIW);
		case ControllerType.Keyboard:
			return wxwAjVCMxfwnKDPztUMmjYjdLJw(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		case ControllerType.Mouse:
			return wxwAjVCMxfwnKDPztUMmjYjdLJw(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		}
	}

	public bool glxcPusUUKbgfOQXBoYoVafYsPV()
	{
		if (!glxcPusUUKbgfOQXBoYoVafYsPV(QuOyRGrgPJAIWhsKWmyPcWlaLYok) && !glxcPusUUKbgfOQXBoYoVafYsPV(ljUWisroiVgcxAxyrURnKFzSwIW) && !glxcPusUUKbgfOQXBoYoVafYsPV(jXEbFYnmcSIgpclyYvQTdCKlRWYh))
		{
			return glxcPusUUKbgfOQXBoYoVafYsPV(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		}
		return true;
	}

	public bool glxcPusUUKbgfOQXBoYoVafYsPV(ControllerType P_0)
	{
		switch (P_0)
		{
		default:
			while (true)
			{
				switch (0x212A1223 ^ 0x212A1221)
				{
				case 0:
					continue;
				case 2:
					throw new NotImplementedException();
				}
				break;
			}
			goto case ControllerType.Joystick;
		case ControllerType.Joystick:
			return glxcPusUUKbgfOQXBoYoVafYsPV(ljUWisroiVgcxAxyrURnKFzSwIW);
		case ControllerType.Keyboard:
			return glxcPusUUKbgfOQXBoYoVafYsPV(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		case ControllerType.Mouse:
			return glxcPusUUKbgfOQXBoYoVafYsPV(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		case ControllerType.Custom:
			return glxcPusUUKbgfOQXBoYoVafYsPV(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		}
	}

	public bool WbmqKuYbixTcQIAXJSPPyYMnVTN()
	{
		if (!WbmqKuYbixTcQIAXJSPPyYMnVTN(QuOyRGrgPJAIWhsKWmyPcWlaLYok) && !WbmqKuYbixTcQIAXJSPPyYMnVTN(ljUWisroiVgcxAxyrURnKFzSwIW) && !WbmqKuYbixTcQIAXJSPPyYMnVTN(jXEbFYnmcSIgpclyYvQTdCKlRWYh))
		{
			return WbmqKuYbixTcQIAXJSPPyYMnVTN(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		}
		return true;
	}

	public bool WbmqKuYbixTcQIAXJSPPyYMnVTN(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return WbmqKuYbixTcQIAXJSPPyYMnVTN(ljUWisroiVgcxAxyrURnKFzSwIW);
		case ControllerType.Keyboard:
			return WbmqKuYbixTcQIAXJSPPyYMnVTN(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		case ControllerType.Mouse:
			return WbmqKuYbixTcQIAXJSPPyYMnVTN(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		case ControllerType.Custom:
			return WbmqKuYbixTcQIAXJSPPyYMnVTN(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		default:
			throw new NotImplementedException();
		}
	}

	public bool HiefIrhLjQzJmIvyVCCsUeCbEcBX()
	{
		if (!HiefIrhLjQzJmIvyVCCsUeCbEcBX(QuOyRGrgPJAIWhsKWmyPcWlaLYok) && !HiefIrhLjQzJmIvyVCCsUeCbEcBX(ljUWisroiVgcxAxyrURnKFzSwIW))
		{
			while (true)
			{
				int num = 102830594;
				while (true)
				{
					switch (num ^ 0x6211200)
					{
					case 0:
						break;
					case 2:
						goto IL_003a;
					default:
						return HiefIrhLjQzJmIvyVCCsUeCbEcBX(SerYLNcBvSGLsDnWKlmIAbnbmflt);
					}
					break;
					IL_003a:
					if (HiefIrhLjQzJmIvyVCCsUeCbEcBX(jXEbFYnmcSIgpclyYvQTdCKlRWYh))
					{
						goto end_IL_001c;
					}
					num = 102830593;
				}
				continue;
				end_IL_001c:
				break;
			}
		}
		return true;
	}

	public bool HiefIrhLjQzJmIvyVCCsUeCbEcBX(ControllerType P_0)
	{
		while (true)
		{
			int num = -1060833012;
			while (true)
			{
				switch (num ^ -1060833009)
				{
				case 0:
					break;
				case 3:
					switch (P_0)
					{
					default:
						num = -1060833011;
						continue;
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return HiefIrhLjQzJmIvyVCCsUeCbEcBX(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
					case ControllerType.Mouse:
						return HiefIrhLjQzJmIvyVCCsUeCbEcBX(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
					}
					goto default;
				case 2:
					if (P_0 != ControllerType.Custom)
					{
						num = -1060833010;
						continue;
					}
					return HiefIrhLjQzJmIvyVCCsUeCbEcBX(SerYLNcBvSGLsDnWKlmIAbnbmflt);
				default:
					return HiefIrhLjQzJmIvyVCCsUeCbEcBX(ljUWisroiVgcxAxyrURnKFzSwIW);
				case 1:
					throw new NotImplementedException();
				}
				break;
			}
		}
	}

	public bool SQglktDadlKAIELzKYKROpimzpC()
	{
		if (!SQglktDadlKAIELzKYKROpimzpC(QuOyRGrgPJAIWhsKWmyPcWlaLYok))
		{
			while (true)
			{
				int num = -729419251;
				while (true)
				{
					switch (num ^ -729419249)
					{
					case 0:
						break;
					case 2:
						goto IL_002c;
					default:
						return SQglktDadlKAIELzKYKROpimzpC(SerYLNcBvSGLsDnWKlmIAbnbmflt);
					}
					break;
					IL_002c:
					if (SQglktDadlKAIELzKYKROpimzpC(ljUWisroiVgcxAxyrURnKFzSwIW) || SQglktDadlKAIELzKYKROpimzpC(jXEbFYnmcSIgpclyYvQTdCKlRWYh))
					{
						goto end_IL_000e;
					}
					num = -729419250;
				}
				continue;
				end_IL_000e:
				break;
			}
		}
		return true;
	}

	public bool SQglktDadlKAIELzKYKROpimzpC(ControllerType P_0)
	{
		switch (P_0)
		{
		case ControllerType.Joystick:
			return SQglktDadlKAIELzKYKROpimzpC(ljUWisroiVgcxAxyrURnKFzSwIW);
		case ControllerType.Keyboard:
			return SQglktDadlKAIELzKYKROpimzpC(jXEbFYnmcSIgpclyYvQTdCKlRWYh);
		case ControllerType.Mouse:
			return SQglktDadlKAIELzKYKROpimzpC(QuOyRGrgPJAIWhsKWmyPcWlaLYok);
		case ControllerType.Custom:
			return SQglktDadlKAIELzKYKROpimzpC(SerYLNcBvSGLsDnWKlmIAbnbmflt);
		default:
			throw new NotImplementedException();
		}
	}

	private bool wxwAjVCMxfwnKDPztUMmjYjdLJw<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1399915884;
			while (true)
			{
				switch (num ^ -1399915888)
				{
				case 5:
					break;
				case 4:
					num2 = 0;
					num = -1399915887;
					continue;
				case 6:
				{
					int num3;
					if (num2 < count)
					{
						num = -1399915888;
						num3 = num;
					}
					else
					{
						num = -1399915885;
						num3 = num;
					}
					continue;
				}
				case 0:
				{
					T val = P_0[num2];
					if (val != null && val.GetAnyButton())
					{
						num = -1399915886;
						continue;
					}
					num2++;
					num = -1399915882;
					continue;
				}
				case 1:
					num = -1399915882;
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

	private bool wxwAjVCMxfwnKDPztUMmjYjdLJw(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButton();
	}

	private bool glxcPusUUKbgfOQXBoYoVafYsPV<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int count = P_0.Count;
		int num = 0;
		int num2 = 1174430881;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ 0x460064A5)
			{
			case 3:
				break;
			case 2:
				return false;
			case 0:
			{
				T val = P_0[num];
				if (val != null && val.GetAnyButtonDown())
				{
					return true;
				}
				num++;
				num2 = 1174430880;
				continue;
			}
			case 4:
				num2 = 1174430880;
				continue;
			case 5:
			{
				int num3;
				if (num < count)
				{
					num2 = 1174430885;
					num3 = num2;
				}
				else
				{
					num2 = 1174430884;
					num3 = num2;
				}
				continue;
			}
			default:
				return false;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = 1174430887;
		goto IL_0008;
	}

	private bool glxcPusUUKbgfOQXBoYoVafYsPV(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonDown();
	}

	private bool WbmqKuYbixTcQIAXJSPPyYMnVTN<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num = 0;
		T val = default(T);
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = 645337718;
				num3 = num2;
			}
			else
			{
				num2 = 645337715;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x26771272)
				{
				case 2:
					num2 = 645337718;
					continue;
				case 0:
					break;
				case 3:
					if (val.GetAnyButtonUp())
					{
						return true;
					}
					goto IL_005c;
				case 4:
					val = P_0[num];
					if (val != null)
					{
						num2 = 645337713;
						continue;
					}
					goto IL_005c;
				default:
					{
						return false;
					}
					IL_005c:
					num++;
					num2 = 645337714;
					continue;
				}
				break;
			}
		}
	}

	private bool WbmqKuYbixTcQIAXJSPPyYMnVTN(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonUp();
	}

	private bool HiefIrhLjQzJmIvyVCCsUeCbEcBX<T>(IList<T> P_0) where T : Controller
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
				if (val != null && val.GetAnyButtonChanged())
				{
					num2 = 1428547085;
				}
				else
				{
					num++;
					num2 = 1428547087;
				}
				while (true)
				{
					switch (num2 ^ 0x5525E60F)
					{
					case 3:
						num2 = 1428547086;
						continue;
					case 1:
						break;
					case 2:
						return true;
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

	private bool HiefIrhLjQzJmIvyVCCsUeCbEcBX(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonChanged();
	}

	private bool SQglktDadlKAIELzKYKROpimzpC<T>(IList<T> P_0) where T : Controller
	{
		if (P_0 == null)
		{
			return false;
		}
		int count = P_0.Count;
		int num2 = default(int);
		T val = default(T);
		while (true)
		{
			int num = -1348194034;
			while (true)
			{
				switch (num ^ -1348194036)
				{
				case 0:
					break;
				case 2:
					num2 = 0;
					num = -1348194035;
					continue;
				case 4:
					val = P_0[num2];
					num = -1348194033;
					continue;
				case 3:
					if (val != null && val.GetAnyButtonPrev())
					{
						return true;
					}
					num2++;
					num = -1348194035;
					continue;
				default:
					if (num2 >= count)
					{
						return false;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private bool SQglktDadlKAIELzKYKROpimzpC(Controller P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		return P_0.GetAnyButtonPrev();
	}

	public Controller MnUtAvdYVqUUxTqmFSTMVJhWqFA()
	{
		Controller lastController = null;
		float lastTime = 0f;
		InputTools.CompareLastActiveController(QuOyRGrgPJAIWhsKWmyPcWlaLYok, ref lastController, ref lastTime);
		InputTools.CompareLastActiveController(jXEbFYnmcSIgpclyYvQTdCKlRWYh, ref lastController, ref lastTime);
		IList<Joystick> list = ljUWisroiVgcxAxyrURnKFzSwIW;
		int num = 0;
		IList<CustomController> serYLNcBvSGLsDnWKlmIAbnbmflt = default(IList<CustomController>);
		int num2 = default(int);
		while (true)
		{
			int num3;
			if (num >= joystickCount)
			{
				serYLNcBvSGLsDnWKlmIAbnbmflt = SerYLNcBvSGLsDnWKlmIAbnbmflt;
				num2 = 0;
				num3 = 1745196311;
				goto IL_0036;
			}
			goto IL_00d5;
			IL_0036:
			while (true)
			{
				switch (num3 ^ 0x68059510)
				{
				case 8:
					num3 = 1745196306;
					continue;
				case 1:
					break;
				case 3:
					lastController = jXEbFYnmcSIgpclyYvQTdCKlRWYh;
					num3 = 1745196304;
					continue;
				case 7:
					goto IL_008c;
				case 4:
					goto end_IL_0036;
				case 6:
					num2++;
					num3 = 1745196311;
					continue;
				case 2:
					goto IL_00d5;
				case 5:
					InputTools.CompareLastActiveController(serYLNcBvSGLsDnWKlmIAbnbmflt[num2], ref lastController, ref lastTime);
					num3 = 1745196310;
					continue;
				default:
					return lastController;
				}
				int num4;
				if (lastController != null)
				{
					num3 = 1745196304;
					num4 = num3;
				}
				else
				{
					num3 = 1745196307;
					num4 = num3;
				}
				continue;
				IL_008c:
				int num5;
				if (num2 < customControllerCount)
				{
					num3 = 1745196309;
					num5 = num3;
				}
				else
				{
					num3 = 1745196305;
					num5 = num3;
				}
				continue;
				end_IL_0036:
				break;
			}
			continue;
			IL_00d5:
			InputTools.CompareLastActiveController(list[num], ref lastController, ref lastTime);
			num++;
			num3 = 1745196308;
			goto IL_0036;
		}
	}

	public Controller MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType P_0)
	{
		Controller lastController = null;
		float lastTime = 0f;
		int num3 = default(int);
		int count = default(int);
		ControllerType controllerType = default(ControllerType);
		int num2 = default(int);
		while (true)
		{
			int num = -1977852991;
			while (true)
			{
				switch (num ^ -1977852990)
				{
				case 0:
					break;
				case 1:
					if (num3 >= count)
					{
						num = -1977852981;
						continue;
					}
					goto case 10;
				case 4:
					switch (controllerType)
					{
					case ControllerType.Joystick:
						goto IL_009b;
					case ControllerType.Keyboard:
						goto IL_00ce;
					case ControllerType.Mouse:
						return Mouse;
					case ControllerType.Custom:
						goto IL_00dc;
					}
					num = -1977852982;
					continue;
				case 6:
					InputTools.CompareLastActiveController(ljUWisroiVgcxAxyrURnKFzSwIW[num2], ref lastController, ref lastTime);
					num2++;
					num = -1977852987;
					continue;
				case 5:
					goto IL_009b;
				case 3:
					controllerType = P_0;
					num = -1977852986;
					continue;
				case 7:
					if (num2 >= count)
					{
						num = -1977852981;
						continue;
					}
					goto case 6;
				case 2:
					goto IL_00ce;
				case 10:
					InputTools.CompareLastActiveController(SerYLNcBvSGLsDnWKlmIAbnbmflt[num3], ref lastController, ref lastTime);
					num3++;
					num = -1977852989;
					continue;
				case 8:
					throw new NotImplementedException();
				default:
					{
						return lastController;
					}
					IL_00dc:
					count = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
					num3 = 0;
					num = -1977852989;
					continue;
					IL_00ce:
					return Keyboard;
					IL_009b:
					count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
					num2 = 0;
					num = -1977852987;
					continue;
				}
				break;
			}
		}
	}

	public T MnUtAvdYVqUUxTqmFSTMVJhWqFA<T>() where T : Controller
	{
		Type typeFromHandle = typeof(T);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Joystick) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Keyboard) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Custom) as T;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Mouse) as T;
		}
		throw new NotImplementedException();
	}

	public ControllerType CitapCgPRsgWFCRtIDVdDbmeisDk()
	{
		Controller controller = MnUtAvdYVqUUxTqmFSTMVJhWqFA();
		if (controller != null)
		{
			return controller.type;
		}
		return ControllerType.Keyboard;
	}

	public void EuDNOKQQzIdCcFEiVwCTXwPAkqU(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			EFRyjHXaGVTtiVFUebbPpghwPCf = true;
			AgfReQvZvDiaCGXCbpvggzxqAhH.MWjjnMHcNQzwqasMkjzAGzXOeAk(P_0);
			int num = -230652466;
			while (true)
			{
				switch (num ^ -230652468)
				{
				case 0:
					goto IL_0004;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0004:
				num = -230652467;
			}
		}
	}

	public void EuDNOKQQzIdCcFEiVwCTXwPAkqU(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (-798950353 ^ -798950354)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		EFRyjHXaGVTtiVFUebbPpghwPCf = true;
		AgfReQvZvDiaCGXCbpvggzxqAhH.MWjjnMHcNQzwqasMkjzAGzXOeAk(P_0, P_1);
	}

	public void QOkoyZqchKBZNfwdRGOYQFntOczh(ActiveControllerChangedDelegate P_0)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (-1236438547 ^ -1236438548)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		AgfReQvZvDiaCGXCbpvggzxqAhH.trfkSqRMsoaJTpShhLRChKMKxwR(P_0);
	}

	public void tbUwrCYKXMkMGCcKKARjHgyGEBp(ActiveControllerChangedDelegate P_0, ControllerType P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		while (true)
		{
			AgfReQvZvDiaCGXCbpvggzxqAhH.trfkSqRMsoaJTpShhLRChKMKxwR(P_0, P_1);
			int num = 1757854849;
			while (true)
			{
				switch (num ^ 0x68C6BC83)
				{
				case 0:
					goto IL_0004;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0004:
				num = 1757854850;
			}
		}
	}

	public void bUeEdQqqYxnZwxcDRoowfcoQXVW()
	{
		AgfReQvZvDiaCGXCbpvggzxqAhH.nympziBLtYDUiPlWNRoEGqbSPfa();
	}

	public void EuDNOKQQzIdCcFEiVwCTXwPAkqU(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (P_0 == 9999999)
			{
				num = -1839873183;
				num2 = num;
			}
			else
			{
				num = -1839873184;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -1839873180)
				{
				case 3:
					num = -1839873179;
					continue;
				case 2:
					KuAPdcgaHWxUITvApdIcoURMMfv[P_0].MWjjnMHcNQzwqasMkjzAGzXOeAk(P_1);
					num = -1839873180;
					continue;
				case 5:
					MTCNBPMlOZiPgSSbnQOlMBrPbLl.MWjjnMHcNQzwqasMkjzAGzXOeAk(P_1);
					num = -1839873180;
					continue;
				case 4:
					if ((uint)P_0 >= (uint)joywuWQGYqpSFcUYCboBACmufu)
					{
						return;
					}
					goto case 2;
				case 1:
					break;
				default:
					EFRyjHXaGVTtiVFUebbPpghwPCf = true;
					return;
				}
				break;
			}
		}
	}

	public void EuDNOKQQzIdCcFEiVwCTXwPAkqU(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
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
				MTCNBPMlOZiPgSSbnQOlMBrPbLl.MWjjnMHcNQzwqasMkjzAGzXOeAk(P_1, P_2);
				num = -1931318531;
				goto IL_0009;
			}
			goto IL_004e;
			IL_0009:
			while (true)
			{
				switch (num ^ -1931318535)
				{
				case 3:
					num = -1931318529;
					continue;
				case 6:
					break;
				case 2:
					goto IL_004e;
				case 4:
					num = -1931318536;
					continue;
				case 0:
					KuAPdcgaHWxUITvApdIcoURMMfv[P_0].MWjjnMHcNQzwqasMkjzAGzXOeAk(P_1, P_2);
					num = -1931318536;
					continue;
				case 5:
					return;
				default:
					EFRyjHXaGVTtiVFUebbPpghwPCf = true;
					return;
				}
				break;
			}
			continue;
			IL_004e:
			int num2;
			if ((uint)P_0 < (uint)joywuWQGYqpSFcUYCboBACmufu)
			{
				num = -1931318535;
				num2 = num;
			}
			else
			{
				num = -1931318532;
				num2 = num;
			}
			goto IL_0009;
		}
	}

	public void QOkoyZqchKBZNfwdRGOYQFntOczh(int P_0, PlayerActiveControllerChangedDelegate P_1)
	{
		if (P_1 == null)
		{
			goto IL_0003;
		}
		goto IL_0042;
		IL_0003:
		int num = 276779966;
		goto IL_0008;
		IL_0008:
		switch (num ^ 0x107F53B8)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_0031;
		case 5:
			goto IL_0042;
		case 6:
			return;
		case 4:
			return;
		case 1:
			goto IL_006d;
		case 3:
			return;
		}
		goto IL_0003;
		IL_0042:
		if (P_0 == 9999999)
		{
			MTCNBPMlOZiPgSSbnQOlMBrPbLl.trfkSqRMsoaJTpShhLRChKMKxwR(P_1);
			num = 276779964;
			goto IL_0008;
		}
		goto IL_0031;
		IL_0031:
		if ((uint)P_0 >= (uint)joywuWQGYqpSFcUYCboBACmufu)
		{
			return;
		}
		goto IL_006d;
		IL_006d:
		KuAPdcgaHWxUITvApdIcoURMMfv[P_0].trfkSqRMsoaJTpShhLRChKMKxwR(P_1);
		num = 276779963;
		goto IL_0008;
	}

	public void QOkoyZqchKBZNfwdRGOYQFntOczh(int P_0, PlayerActiveControllerChangedDelegate P_1, ControllerType P_2)
	{
		if (P_1 == null)
		{
			goto IL_0003;
		}
		goto IL_003d;
		IL_0003:
		int num = 1526357617;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ 0x5AFA5E72)
			{
			case 0:
				break;
			default:
				return;
			case 6:
				return;
			case 1:
				goto IL_003d;
			case 3:
				return;
			case 7:
				goto IL_0061;
			case 5:
				return;
			case 4:
				KuAPdcgaHWxUITvApdIcoURMMfv[P_0].trfkSqRMsoaJTpShhLRChKMKxwR(P_1, P_2);
				num = 1526357616;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_003d:
		if (P_0 == 9999999)
		{
			MTCNBPMlOZiPgSSbnQOlMBrPbLl.trfkSqRMsoaJTpShhLRChKMKxwR(P_1, P_2);
			num = 1526357623;
			goto IL_0008;
		}
		goto IL_0061;
		IL_0061:
		int num2;
		if ((uint)P_0 < (uint)joywuWQGYqpSFcUYCboBACmufu)
		{
			num = 1526357622;
			num2 = num;
		}
		else
		{
			num = 1526357620;
			num2 = num;
		}
		goto IL_0008;
	}

	public void bUeEdQqqYxnZwxcDRoowfcoQXVW(int P_0)
	{
		if (P_0 == 9999999)
		{
			MTCNBPMlOZiPgSSbnQOlMBrPbLl.nympziBLtYDUiPlWNRoEGqbSPfa();
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if ((uint)P_0 < (uint)joywuWQGYqpSFcUYCboBACmufu)
			{
				num = -147319839;
				num2 = num;
			}
			else
			{
				num = -147319837;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -147319839)
				{
				case 3:
					goto IL_0014;
				case 1:
					break;
				case 2:
					return;
				default:
					KuAPdcgaHWxUITvApdIcoURMMfv[P_0].nympziBLtYDUiPlWNRoEGqbSPfa();
					return;
				}
				break;
				IL_0014:
				num = -147319840;
			}
		}
	}

	private void hvYGHfdgiJvHHhiqYAABhqHARrpA()
	{
		if (AgfReQvZvDiaCGXCbpvggzxqAhH.OQXHthXNIXIVwmdJKmODaHHMweN > 0)
		{
			AgfReQvZvDiaCGXCbpvggzxqAhH.TLgbjVxvgMLQSbLhQjnmtuZpfeX(-1, MnUtAvdYVqUUxTqmFSTMVJhWqFA(), MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Joystick), MnUtAvdYVqUUxTqmFSTMVJhWqFA(ControllerType.Custom));
			goto IL_002f;
		}
		goto IL_0068;
		IL_0068:
		int num;
		int num2;
		if (MTCNBPMlOZiPgSSbnQOlMBrPbLl.OQXHthXNIXIVwmdJKmODaHHMweN <= 0)
		{
			num = -2081699845;
			num2 = num;
		}
		else
		{
			num = -2081699851;
			num2 = num;
		}
		goto IL_0034;
		IL_002f:
		num = -2081699852;
		goto IL_0034;
		IL_0034:
		int num3 = default(int);
		while (true)
		{
			switch (num ^ -2081699853)
			{
			case 4:
				break;
			default:
				return;
			case 7:
				goto IL_0068;
			case 6:
			{
				Player.ControllerHelper controllers2 = YYmRYrIJJDlFmDKErJxqlPcJEZJ.OAxOAmqPhXfcosjWwcgifExlsrf().controllers;
				MTCNBPMlOZiPgSSbnQOlMBrPbLl.TLgbjVxvgMLQSbLhQjnmtuZpfeX(9999999, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
				num = -2081699845;
				continue;
			}
			case 8:
				num3 = 0;
				num = -2081699855;
				continue;
			case 2:
				goto IL_00d3;
			case 3:
				goto IL_00f0;
			case 1:
				num3++;
				num = -2081699855;
				continue;
			case 0:
			{
				Player.ControllerHelper controllers = YYmRYrIJJDlFmDKErJxqlPcJEZJ.Players_orig[num3].controllers;
				KuAPdcgaHWxUITvApdIcoURMMfv[num3].TLgbjVxvgMLQSbLhQjnmtuZpfeX(num3, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
				num = -2081699854;
				continue;
			}
			case 5:
				return;
			}
			break;
			IL_00f0:
			int num4;
			if (KuAPdcgaHWxUITvApdIcoURMMfv[num3].OQXHthXNIXIVwmdJKmODaHHMweN == 0)
			{
				num = -2081699854;
				num4 = num;
			}
			else
			{
				num = -2081699853;
				num4 = num;
			}
			continue;
			IL_00d3:
			int num5;
			if (num3 < joywuWQGYqpSFcUYCboBACmufu)
			{
				num = -2081699856;
				num5 = num;
			}
			else
			{
				num = -2081699850;
				num5 = num;
			}
		}
		goto IL_002f;
	}

	public void YFYDYKXXYWFTpDjquQJNbFcgFXjF(ThrottleCalibrationMode P_0)
	{
		int num = 0;
		int num2 = default(int);
		int num4 = default(int);
		while (true)
		{
			IL_00ff:
			int num3;
			if (num >= ljUWisroiVgcxAxyrURnKFzSwIW.Count)
			{
				num2 = 0;
				num3 = -834996012;
				goto IL_000c;
			}
			goto IL_00a3;
			IL_000c:
			while (true)
			{
				switch (num3 ^ -834996007)
				{
				case 14:
					num3 = -834996005;
					continue;
				default:
					return;
				case 11:
					num2++;
					num3 = -834996003;
					continue;
				case 6:
					break;
				case 4:
					if (num2 >= WOkGQHhtpdLVigwYGRvwGFhkDhLg.Count)
					{
						num4 = 0;
						num3 = -834996002;
						continue;
					}
					goto case 0;
				case 2:
					goto end_IL_000c;
				case 9:
					goto IL_00c5;
				case 12:
					YFYDYKXXYWFTpDjquQJNbFcgFXjF(ljUWisroiVgcxAxyrURnKFzSwIW[num], P_0);
					num3 = -834996015;
					continue;
				case 15:
					goto IL_00ff;
				case 13:
					num3 = -834996003;
					continue;
				case 1:
					num4++;
					num3 = -834996016;
					continue;
				case 3:
					YFYDYKXXYWFTpDjquQJNbFcgFXjF(SerYLNcBvSGLsDnWKlmIAbnbmflt[num4], P_0);
					num3 = -834996008;
					continue;
				case 0:
					if (WOkGQHhtpdLVigwYGRvwGFhkDhLg[num2] != null)
					{
						YFYDYKXXYWFTpDjquQJNbFcgFXjF(WOkGQHhtpdLVigwYGRvwGFhkDhLg[num2], P_0);
						num3 = -834996014;
						continue;
					}
					goto case 11;
				case 8:
					num++;
					num3 = -834996010;
					continue;
				case 7:
					num3 = -834996016;
					continue;
				case 5:
					YFYDYKXXYWFTpDjquQJNbFcgFXjF(QuOyRGrgPJAIWhsKWmyPcWlaLYok, P_0);
					num3 = -834996013;
					continue;
				case 10:
					return;
				}
				int num5;
				if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num4] == null)
				{
					num3 = -834996008;
					num5 = num3;
				}
				else
				{
					num3 = -834996006;
					num5 = num3;
				}
				continue;
				IL_00c5:
				int num6;
				if (num4 >= customControllerCount)
				{
					num3 = -834996004;
					num6 = num3;
				}
				else
				{
					num3 = -834996001;
					num6 = num3;
				}
				continue;
				end_IL_000c:
				break;
			}
			goto IL_00a3;
			IL_00a3:
			int num7;
			if (ljUWisroiVgcxAxyrURnKFzSwIW[num] == null)
			{
				num3 = -834996015;
				num7 = num3;
			}
			else
			{
				num3 = -834996011;
				num7 = num3;
			}
			goto IL_000c;
		}
	}

	private void YFYDYKXXYWFTpDjquQJNbFcgFXjF(ControllerWithAxes P_0, ThrottleCalibrationMode P_1)
	{
		IList<Controller.Axis> axes = P_0.Axes;
		int num = 0;
		while (num < P_0.axisCount)
		{
			while (true)
			{
				int num2;
				int num3;
				if (axes[num].flIXmRKXOUURLlZiHjZlJLbgGru._specialAxisType != SpecialAxisType.Throttle)
				{
					num2 = -2036681974;
					num3 = num2;
				}
				else
				{
					num2 = -2036681972;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2036681976)
					{
					case 0:
						num2 = -2036681973;
						continue;
					case 3:
						break;
					case 4:
						P_0.calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(P_1);
						num2 = -2036681974;
						continue;
					case 2:
						num++;
						num2 = -2036681975;
						continue;
					default:
						goto end_IL_0031;
					}
					break;
				}
				continue;
				end_IL_0031:
				break;
			}
		}
	}

	public IList<T> BtGqVUfmhuZbsgOJoXXlpMKwJNJ<T>() where T : IControllerTemplate
	{
		return VdYbRIfIAqVYCJnTMRUdCcFYmUp.HheeqPSzhzsItAfizdvPAJfWzRo<T>();
	}

	private void YJaAHaimrHWIfKrgfWxeihnqrcza(List<InputBehavior> P_0)
	{
		fsQBYUGDBZAPIrofCevqCtlZgkl = ReInput.fsQBYUGDBZAPIrofCevqCtlZgkl;
		YYmRYrIJJDlFmDKErJxqlPcJEZJ = ReInput.YYmRYrIJJDlFmDKErJxqlPcJEZJ;
		ljUWisroiVgcxAxyrURnKFzSwIW = new List<Joystick>();
		WOkGQHhtpdLVigwYGRvwGFhkDhLg = new List<Joystick>();
		SerYLNcBvSGLsDnWKlmIAbnbmflt = new List<CustomController>();
		DejVRMnZwHRZwPKsShsOBljwEkp = fsQBYUGDBZAPIrofCevqCtlZgkl.actionCount;
		joywuWQGYqpSFcUYCboBACmufu = YYmRYrIJJDlFmDKErJxqlPcJEZJ.gamePlayerCount;
		QMiCPxzJdlPxcFwOOrCyePONmUR = FrHljCjHhXoVdtQLcEjKwtzDcvf;
		tIMqjoodLmiryAgugInUewIiEKvF = 0;
		int num3 = default(int);
		int num12 = default(int);
		IList<Player> players = default(IList<Player>);
		int num7 = default(int);
		IList<Player_Editor> players_readOnly = default(IList<Player_Editor>);
		int num11 = default(int);
		int num9 = default(int);
		Player player = default(Player);
		int num4 = default(int);
		int num8 = default(int);
		int num2 = default(int);
		CustomController customController = default(CustomController);
		List<Player_Editor.CreateControllerInfo> startingCustomControllers = default(List<Player_Editor.CreateControllerInfo>);
		int num6 = default(int);
		pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = default(pEQcyInzaqspNDwmuMYGrewsNaQ);
		while (true)
		{
			int num = 784379351;
			while (true)
			{
				switch (num ^ 0x2EC0ADD2)
				{
				case 31:
					break;
				default:
					return;
				case 6:
					num3++;
					num = 784379359;
					continue;
				case 22:
					WzMgptRXjmFPvUJSfynOIPTzDEq.Add(ReInput.players.GetSystemPlayer().id, new JmBSvBweXerzSNIFAoWACPuzwA(P_0));
					num = 784379377;
					continue;
				case 14:
					if (num12 >= players.Count)
					{
						poUCnxmBnNufvZgOXkABYfeEyeL = new ReadOnlyCollection<Joystick>(ljUWisroiVgcxAxyrURnKFzSwIW);
						juQHBrmgiFgKrbVAwQAmAcgaZGvE = new ReadOnlyCollection<CustomController>(SerYLNcBvSGLsDnWKlmIAbnbmflt);
						num = 784379357;
						continue;
					}
					goto case 1;
				case 19:
					if (num7 >= joywuWQGYqpSFcUYCboBACmufu)
					{
						players_readOnly = ReInput.UserData.Players_readOnly;
						int num13;
						if (players_readOnly != null)
						{
							num = 784379349;
							num13 = num;
						}
						else
						{
							num = 784379333;
							num13 = num;
						}
						continue;
					}
					goto case 21;
				case 34:
					if (num11 >= joywuWQGYqpSFcUYCboBACmufu)
					{
						AgfReQvZvDiaCGXCbpvggzxqAhH = new global::lobHgULfDSIKOmolXbCuIWbZlIH<ActiveControllerChangedDelegate>();
						MTCNBPMlOZiPgSSbnQOlMBrPbLl = new global::lobHgULfDSIKOmolXbCuIWbZlIH<PlayerActiveControllerChangedDelegate>();
						KuAPdcgaHWxUITvApdIcoURMMfv = new global::lobHgULfDSIKOmolXbCuIWbZlIH<PlayerActiveControllerChangedDelegate>[YYmRYrIJJDlFmDKErJxqlPcJEZJ.gamePlayerCount];
						ArrayTools.Populate(KuAPdcgaHWxUITvApdIcoURMMfv);
						num = 784379336;
						continue;
					}
					goto case 18;
				case 18:
					qqeCWZfcZFjJuutpLYlCZqOUgFp[num11] = new PCItYZcmQVbRIIUnLbZiPkYVRSE();
					num11++;
					num = 784379376;
					continue;
				case 4:
					SvjizdwKEpuZnQwaTMQhTsXvjJZ = new pEQcyInzaqspNDwmuMYGrewsNaQ[DejVRMnZwHRZwPKsShsOBljwEkp];
					num9 = 0;
					num = 784379338;
					continue;
				case 16:
				{
					player = YYmRYrIJJDlFmDKErJxqlPcJEZJ.BguZqZULdBNeIEfARdMNkptxqJou(num4);
					int num5;
					if (player != null)
					{
						num = 784379355;
						num5 = num;
					}
					else
					{
						num = 784379348;
						num5 = num;
					}
					continue;
				}
				case 32:
					num8++;
					num9++;
					num = 784379338;
					continue;
				case 12:
					num2++;
					num = 784379346;
					continue;
				case 35:
					players = ReInput.players.Players;
					num12 = 0;
					num = 784379356;
					continue;
				case 0:
					if (num2 >= players_readOnly.Count)
					{
						lzwmJEEwtQRUiNEXvXBgJIIYFZy = new PCItYZcmQVbRIIUnLbZiPkYVRSE();
						num = 784379334;
						continue;
					}
					goto case 10;
				case 20:
					qqeCWZfcZFjJuutpLYlCZqOUgFp = new PCItYZcmQVbRIIUnLbZiPkYVRSE[joywuWQGYqpSFcUYCboBACmufu];
					num11 = 0;
					num = 784379376;
					continue;
				case 2:
					num12++;
					num = 784379356;
					continue;
				case 15:
					pEQcyInzaqspNDwmuMYGrewsNaQ.lZDnsMFoECSQYMqgYReYfmsDWvn(AzMyTQkqkOhQhSBeGZpAEMZVrzb);
					num = 784379345;
					continue;
				case 5:
					WzMgptRXjmFPvUJSfynOIPTzDEq = new ADictionary<int, JmBSvBweXerzSNIFAoWACPuzwA>();
					num = 784379332;
					continue;
				case 9:
					player.controllers.NsKfrPICAOsMNxuGJtMJgtOYkyHW(customController, false);
					num = 784379348;
					continue;
				case 29:
					num4 = ((num2 == 0) ? 9999999 : (num2 - 1));
					num = 784379330;
					continue;
				case 28:
					customController = CsSqgDydbucgPfMxmGgEHFxjOsCu(startingCustomControllers[num3].sourceId);
					if (customController != null)
					{
						customController.tag = startingCustomControllers[num3].tag;
						num = 784379343;
						continue;
					}
					goto case 6;
				case 13:
				{
					int num10;
					if (num3 >= startingCustomControllers.Count)
					{
						num = 784379358;
						num10 = num;
					}
					else
					{
						num = 784379342;
						num10 = num;
					}
					continue;
				}
				case 33:
					num = 784379329;
					continue;
				case 24:
					if (num9 >= DejVRMnZwHRZwPKsShsOBljwEkp)
					{
						foeClgLCNvRZehESwXDKoKqlzhE = new pEQcyInzaqspNDwmuMYGrewsNaQ[joywuWQGYqpSFcUYCboBACmufu, DejVRMnZwHRZwPKsShsOBljwEkp];
						num7 = 0;
						num = 784379379;
						continue;
					}
					goto case 30;
				case 23:
					throw new ArgumentNullException("Players cannot be null!");
				case 3:
					FtcxQsUplIIzzkBEldzOPtQshWz = new pEQcyInzaqspNDwmuMYGrewsNaQ[(joywuWQGYqpSFcUYCboBACmufu + 1) * DejVRMnZwHRZwPKsShsOBljwEkp];
					num8 = 0;
					num = 784379350;
					continue;
				case 10:
					startingCustomControllers = players_readOnly[num2].startingCustomControllers;
					num = 784379339;
					continue;
				case 21:
					num6 = 0;
					num = 784379354;
					continue;
				case 1:
					WzMgptRXjmFPvUJSfynOIPTzDEq.Add(players[num12].id, new JmBSvBweXerzSNIFAoWACPuzwA(P_0));
					num = 784379344;
					continue;
				case 30:
				{
					InputAction inputAction2 = fsQBYUGDBZAPIrofCevqCtlZgkl.JRzscIiudObMLiNBxkbGXjgrgWu(num9);
					InputBehavior inputBehavior2 = WzMgptRXjmFPvUJSfynOIPTzDEq[9999999].GERpyUYtgAywOuExPtqvfhhASSd(inputAction2.behaviorId);
					pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ3 = new pEQcyInzaqspNDwmuMYGrewsNaQ(9999999, inputAction2, inputBehavior2, AzMyTQkqkOhQhSBeGZpAEMZVrzb);
					SvjizdwKEpuZnQwaTMQhTsXvjJZ[num9] = pEQcyInzaqspNDwmuMYGrewsNaQ3;
					FtcxQsUplIIzzkBEldzOPtQshWz[num8] = pEQcyInzaqspNDwmuMYGrewsNaQ3;
					num = 784379378;
					continue;
				}
				case 11:
				{
					InputAction inputAction = fsQBYUGDBZAPIrofCevqCtlZgkl.JRzscIiudObMLiNBxkbGXjgrgWu(num6);
					InputBehavior inputBehavior = WzMgptRXjmFPvUJSfynOIPTzDEq[players[num7].id].GERpyUYtgAywOuExPtqvfhhASSd(inputAction.behaviorId);
					pEQcyInzaqspNDwmuMYGrewsNaQ2 = new pEQcyInzaqspNDwmuMYGrewsNaQ(num7, inputAction, inputBehavior, AzMyTQkqkOhQhSBeGZpAEMZVrzb);
					foeClgLCNvRZehESwXDKoKqlzhE[num7, num6] = pEQcyInzaqspNDwmuMYGrewsNaQ2;
					num = 784379331;
					continue;
				}
				case 17:
					FtcxQsUplIIzzkBEldzOPtQshWz[num8] = pEQcyInzaqspNDwmuMYGrewsNaQ2;
					num8++;
					num6++;
					num = 784379354;
					continue;
				case 8:
					if (num6 >= DejVRMnZwHRZwPKsShsOBljwEkp)
					{
						num7++;
						num = 784379329;
						continue;
					}
					goto case 11;
				case 27:
					num = 784379346;
					continue;
				case 25:
					if (startingCustomControllers != null)
					{
						num3 = 0;
						num = 784379359;
						continue;
					}
					goto case 12;
				case 7:
					num2 = 0;
					num = 784379337;
					continue;
				case 26:
					return;
				}
				break;
			}
		}
	}

	private void xNnSiKXEXUWdMZfpXdaeKVSQkMIY(UpdateLoopType P_0)
	{
		int count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
		int num = 0;
		CustomController customController = default(CustomController);
		int num4 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -2038270511;
				num3 = num2;
			}
			else
			{
				num2 = -2038270510;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -2038270503)
				{
				case 3:
					num2 = -2038270511;
					continue;
				case 11:
				{
					int num7;
					if (jXEbFYnmcSIgpclyYvQTdCKlRWYh.enabled)
					{
						num2 = -2038270503;
						num7 = num2;
					}
					else
					{
						num2 = -2038270498;
						num7 = num2;
					}
					continue;
				}
				case 6:
					customController = SerYLNcBvSGLsDnWKlmIAbnbmflt[num4];
					if (customController.enabled)
					{
						customController.FillData();
						num2 = -2038270508;
						continue;
					}
					goto case 2;
				case 13:
					customController.UpdateData(P_0);
					num2 = -2038270501;
					continue;
				case 7:
				{
					int num6;
					if (BjfWKlABcPvhleltMQUKTCBPPhO)
					{
						num2 = -2038270504;
						num6 = num2;
					}
					else
					{
						num2 = -2038270507;
						num6 = num2;
					}
					continue;
				}
				case 14:
					break;
				case 12:
				{
					int num5;
					if (QuOyRGrgPJAIWhsKWmyPcWlaLYok.enabled)
					{
						num2 = -2038270506;
						num5 = num2;
					}
					else
					{
						num2 = -2038270499;
						num5 = num2;
					}
					continue;
				}
				case 15:
					QuOyRGrgPJAIWhsKWmyPcWlaLYok.UpdateData(P_0);
					num2 = -2038270499;
					continue;
				case 0:
					jXEbFYnmcSIgpclyYvQTdCKlRWYh.UpdateData(P_0);
					num2 = -2038270507;
					continue;
				case 10:
					num2 = -2038270512;
					continue;
				case 2:
					num4++;
					num2 = -2038270512;
					continue;
				case 1:
					jXEbFYnmcSIgpclyYvQTdCKlRWYh.UpdateData_AndroidKeyboardDisabled(P_0);
					num2 = -2038270507;
					continue;
				case 4:
					count2 = SerYLNcBvSGLsDnWKlmIAbnbmflt.Count;
					num4 = 0;
					num2 = -2038270509;
					continue;
				case 8:
				{
					Joystick joystick = ljUWisroiVgcxAxyrURnKFzSwIW[num];
					if (joystick.enabled)
					{
						QUkVarKxRmoXsssgEDMISvoeGki(joystick.inputManagerId, joystick.ybiZyKuVmvsrOHqZzdmfwidXkdm);
						joystick.UpdateData(P_0);
						num2 = -2038270500;
						continue;
					}
					goto case 5;
				}
				case 5:
					num++;
					num2 = -2038270505;
					continue;
				default:
					if (num4 >= count2)
					{
						return;
					}
					goto case 6;
				}
				break;
			}
		}
	}

	private void UCSoyDBBPCcCFPmSSWMaVFflWoW(UpdateLoopType P_0)
	{
		pEQcyInzaqspNDwmuMYGrewsNaQ.qXeEpEAMmybZAuBDccxUJFBbssgZ(P_0);
		Player[] allPlayers_orig = YYmRYrIJJDlFmDKErJxqlPcJEZJ.AllPlayers_orig;
		int num12 = default(int);
		Player.ControllerHelper controllers = default(Player.ControllerHelper);
		int num14 = default(int);
		int num10 = default(int);
		bool enabled2 = default(bool);
		int num5 = default(int);
		IList<KeyboardMap> maps = default(IList<KeyboardMap>);
		int num9 = default(int);
		int count = default(int);
		int num2 = default(int);
		int num16 = default(int);
		pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ2 = default(pEQcyInzaqspNDwmuMYGrewsNaQ);
		int num3 = default(int);
		PCItYZcmQVbRIIUnLbZiPkYVRSE pCItYZcmQVbRIIUnLbZiPkYVRSE = default(PCItYZcmQVbRIIUnLbZiPkYVRSE);
		bool enabled = default(bool);
		while (true)
		{
			int num = -486061971;
			while (true)
			{
				switch (num ^ -486061959)
				{
				case 11:
					break;
				default:
					return;
				case 34:
				{
					int num13;
					if (num12 >= DejVRMnZwHRZwPKsShsOBljwEkp)
					{
						num = -486061958;
						num13 = num;
					}
					else
					{
						num = -486061990;
						num13 = num;
					}
					continue;
				}
				case 8:
					controllers.WslLBNcDnxzGOLiXkFkbccuqAkTE(jXEbFYnmcSIgpclyYvQTdCKlRWYh, EooLpHTnerlwDrVwyPBbECOAJgQ, QMiCPxzJdlPxcFwOOrCyePONmUR);
					num = -486061964;
					continue;
				case 7:
					FtcxQsUplIIzzkBEldzOPtQshWz[num14].vwpczpTUhlmFVrpnviNuDtxiWGHg();
					num = -486061988;
					continue;
				case 20:
					num10 = allPlayers_orig.Length;
					num = -486061969;
					continue;
				case 31:
					enabled2 = QuOyRGrgPJAIWhsKWmyPcWlaLYok.enabled;
					num5 = 0;
					num = -486061976;
					continue;
				case 28:
					maps = allPlayers_orig[num9].controllers.maps.GetMaps<KeyboardMap>(0);
					count = maps.Count;
					num2 = 0;
					num = -486061981;
					continue;
				case 30:
				{
					int num8;
					if (WcPcCkNEfbxlknYuEvMHciqWYbQ)
					{
						num = -486061961;
						num8 = num;
					}
					else
					{
						num = -486061956;
						num8 = num;
					}
					continue;
				}
				case 24:
					if (num14 >= FtcxQsUplIIzzkBEldzOPtQshWz.Length)
					{
						pEQcyInzaqspNDwmuMYGrewsNaQ.dWJJRHZImnLwizGfWdMPhVpoivW();
						num = -486061977;
						continue;
					}
					goto case 25;
				case 29:
					num16 = 0;
					num = -486061992;
					continue;
				case 12:
					lzwmJEEwtQRUiNEXvXBgJIIYFZy.XnekMAFkyeDvwzoGtUMNgUUhjSf(pEQcyInzaqspNDwmuMYGrewsNaQ2, P_0);
					num = -486061960;
					continue;
				case 32:
					num9++;
					num = -486061953;
					continue;
				case 36:
					num = -486061989;
					continue;
				case 6:
				{
					int num11;
					if (num9 < num10)
					{
						num = -486061979;
						num11 = num;
					}
					else
					{
						num = -486061978;
						num11 = num;
					}
					continue;
				}
				case 25:
				{
					int num18;
					if (FtcxQsUplIIzzkBEldzOPtQshWz[num14].XErgmKvbqxuxWNjcDCZkUThgJqU != pEQcyInzaqspNDwmuMYGrewsNaQ.bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ)
					{
						num = -486061954;
						num18 = num;
					}
					else
					{
						num = -486061988;
						num18 = num;
					}
					continue;
				}
				case 10:
				{
					int num6;
					if (num3 < joywuWQGYqpSFcUYCboBACmufu)
					{
						num = -486061973;
						num6 = num;
					}
					else
					{
						num = -486061956;
						num6 = num;
					}
					continue;
				}
				case 2:
					controllers.hzXHiHclGzAMbdQKsGWYtSNRhgUN(QMiCPxzJdlPxcFwOOrCyePONmUR);
					num5++;
					num = -486061976;
					continue;
				case 15:
					num = -486061953;
					continue;
				case 18:
				{
					pCItYZcmQVbRIIUnLbZiPkYVRSE = qqeCWZfcZFjJuutpLYlCZqOUgFp[num3];
					int num19;
					if (pCItYZcmQVbRIIUnLbZiPkYVRSE.agHbGfItBitHhxopNafYNRHURry == 0)
					{
						num = -486061975;
						num19 = num;
					}
					else
					{
						num = -486061980;
						num19 = num;
					}
					continue;
				}
				case 4:
				{
					pEQcyInzaqspNDwmuMYGrewsNaQ pEQcyInzaqspNDwmuMYGrewsNaQ3 = foeClgLCNvRZehESwXDKoKqlzhE[num3, num16];
					if (pEQcyInzaqspNDwmuMYGrewsNaQ3.XErgmKvbqxuxWNjcDCZkUThgJqU != pEQcyInzaqspNDwmuMYGrewsNaQ.bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ)
					{
						pCItYZcmQVbRIIUnLbZiPkYVRSE.XnekMAFkyeDvwzoGtUMNgUUhjSf(pEQcyInzaqspNDwmuMYGrewsNaQ3, P_0);
						num = -486061974;
						continue;
					}
					goto case 19;
				}
				case 33:
				{
					int num17;
					if (num16 >= DejVRMnZwHRZwPKsShsOBljwEkp)
					{
						num = -486061975;
						num17 = num;
					}
					else
					{
						num = -486061955;
						num17 = num;
					}
					continue;
				}
				case 3:
					num3 = 0;
					num = -486061965;
					continue;
				case 17:
					if (num5 >= num10)
					{
						num14 = 0;
						num = -486061983;
						continue;
					}
					goto case 9;
				case 19:
					num16++;
					num = -486061992;
					continue;
				case 22:
					enabled = jXEbFYnmcSIgpclyYvQTdCKlRWYh.enabled;
					if (enabled)
					{
						num9 = 0;
						num = -486061962;
						continue;
					}
					goto case 31;
				case 26:
					num = -486061959;
					continue;
				case 13:
					if (enabled2)
					{
						controllers.HENpcWgIFRCGiusZHVwhlTSsldT(QuOyRGrgPJAIWhsKWmyPcWlaLYok, QMiCPxzJdlPxcFwOOrCyePONmUR);
						num = -486061957;
						continue;
					}
					goto case 2;
				case 35:
				{
					pEQcyInzaqspNDwmuMYGrewsNaQ2 = SvjizdwKEpuZnQwaTMQhTsXvjJZ[num12];
					int num15;
					if (pEQcyInzaqspNDwmuMYGrewsNaQ2.XErgmKvbqxuxWNjcDCZkUThgJqU != pEQcyInzaqspNDwmuMYGrewsNaQ.bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ)
					{
						num = -486061963;
						num15 = num;
					}
					else
					{
						num = -486061960;
						num15 = num;
					}
					continue;
				}
				case 1:
					num12++;
					num = -486061989;
					continue;
				case 27:
					num2++;
					num = -486061959;
					continue;
				case 37:
					num14++;
					num = -486061983;
					continue;
				case 14:
					if (lzwmJEEwtQRUiNEXvXBgJIIYFZy.agHbGfItBitHhxopNafYNRHURry > 0)
					{
						num12 = 0;
						num = -486061987;
						continue;
					}
					goto case 3;
				case 23:
					controllers.rbYFtbFaFEhrhgWrFWZWpRPDXwxr(QMiCPxzJdlPxcFwOOrCyePONmUR);
					if (!enabled)
					{
						int num7;
						if (!BjfWKlABcPvhleltMQUKTCBPPhO)
						{
							num = -486061964;
							num7 = num;
						}
						else
						{
							num = -486061967;
							num7 = num;
						}
						continue;
					}
					goto case 8;
				case 0:
				{
					int num4;
					if (num2 < count)
					{
						num = -486061972;
						num4 = num;
					}
					else
					{
						num = -486061991;
						num4 = num;
					}
					continue;
				}
				case 9:
					controllers = allPlayers_orig[num5].controllers;
					num = -486061970;
					continue;
				case 16:
					num3++;
					num = -486061965;
					continue;
				case 21:
					if (maps[num2].enabled)
					{
						EooLpHTnerlwDrVwyPBbECOAJgQ.oeGGRBHlkBLUZjWtfmjyRzOAmvDp(maps[num2]);
						num = -486061982;
						continue;
					}
					goto case 27;
				case 5:
					return;
				}
				break;
			}
		}
	}

	private void FrHljCjHhXoVdtQLcEjKwtzDcvf(bool P_0, int P_1, int P_2)
	{
		int num = fsQBYUGDBZAPIrofCevqCtlZgkl.EAgOMouOjbslHCCsyBDLoGVrHcd(P_2);
		while (true)
		{
			switch (-511196415 ^ -511196414)
			{
			case 0:
				continue;
			case 3:
				if (num < 0)
				{
					return;
				}
				goto case 1;
			case 1:
				if (P_1 == 9999999)
				{
					SvjizdwKEpuZnQwaTMQhTsXvjJZ[num].orpBerQnpiDZwFOFKwzrggRpZeZ(P_0);
					return;
				}
				break;
			}
			break;
		}
		foeClgLCNvRZehESwXDKoKqlzhE[P_1, num].orpBerQnpiDZwFOFKwzrggRpZeZ(P_0);
	}

	private void sHKhigLcFTAmJBMvavDUBReRBuoC(BridgedController P_0)
	{
		int num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0.sourceJoystick.rewiredId, QHWSqSXjZtJVmIWvTGBJmFrgKKs.AVgeqanjsLChqjEayGcDNCMqTxtI);
		if (num >= 0)
		{
			goto IL_0017;
		}
		goto IL_005a;
		IL_0017:
		int num2 = 1705964375;
		goto IL_001c;
		IL_001c:
		Joystick joystick = default(Joystick);
		while (true)
		{
			switch (num2 ^ 0x65AEF356)
			{
			case 5:
				break;
			case 0:
				joystick.isConnected = true;
				num2 = 1705964372;
				continue;
			case 3:
				goto IL_005a;
			case 4:
				return;
			case 1:
				Logger.LogError("Controller was already in connected list!");
				num2 = 1705964370;
				continue;
			case 6:
				joystick = WOkGQHhtpdLVigwYGRvwGFhkDhLg[num];
				WOkGQHhtpdLVigwYGRvwGFhkDhLg.RemoveAt(num);
				joystick.UpdateControllerInfo(P_0);
				num2 = 1705964374;
				continue;
			case 7:
				joystick = new Joystick(P_0);
				num2 = 1705964372;
				continue;
			default:
				ljUWisroiVgcxAxyrURnKFzSwIW.Add(joystick);
				SZCeMxfPCTerGWEMwYOvsgmToRb.Add(joystick);
				ljUWisroiVgcxAxyrURnKFzSwIW.Sort(Joystick.CompareById_Ascending);
				VdYbRIfIAqVYCJnTMRUdCcFYmUp.DQFfftDmidgQeZhyhKnTyuCofPy(joystick);
				return;
			}
			break;
		}
		goto IL_0017;
		IL_005a:
		num = MVddJGenopCEgjpwBbgsGYNfGAJd(P_0.sourceJoystick.rewiredId, QHWSqSXjZtJVmIWvTGBJmFrgKKs.dUltDdkivNhBBHvDthniWYpgMnZ);
		int num3;
		if (num < 0)
		{
			num2 = 1705964369;
			num3 = num2;
		}
		else
		{
			num2 = 1705964368;
			num3 = num2;
		}
		goto IL_001c;
	}

	private void lTyhkulXbCdtDtysMmQBOBDZnP(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		while (P_0 < ljUWisroiVgcxAxyrURnKFzSwIW.Count)
		{
			while (true)
			{
				IL_010d:
				Joystick joystick = ljUWisroiVgcxAxyrURnKFzSwIW[P_0];
				joystick.isConnected = false;
				int num = -597528975;
				while (true)
				{
					switch (num ^ -597528974)
					{
					case 4:
						num = -597528973;
						continue;
					case 3:
						break;
					case 5:
						WOkGQHhtpdLVigwYGRvwGFhkDhLg.Add(joystick);
						SZCeMxfPCTerGWEMwYOvsgmToRb.Remove(joystick);
						num = -597528966;
						continue;
					case 6:
						HYxyQVtTQdEAKmNoXhGfcCPuJkJ(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
						num = -597528976;
						continue;
					case 2:
						if (GTBTISfJohKhcYpxTbauAjfRRick != null)
						{
							GTBTISfJohKhcYpxTbauAjfRRick(joystick.type, joystick.id);
							num = -597528974;
							continue;
						}
						goto case 0;
					case 0:
						ljUWisroiVgcxAxyrURnKFzSwIW.RemoveAt(P_0);
						num = -597528969;
						continue;
					case 1:
						goto end_IL_0012;
					case 7:
						goto IL_010d;
					default:
						VdYbRIfIAqVYCJnTMRUdCcFYmUp.imOvIGjOATSBDNJuFHrmrpVSbPY(joystick);
						joystick.Clear();
						return;
					}
					int num2;
					if (HYxyQVtTQdEAKmNoXhGfcCPuJkJ == null)
					{
						num = -597528976;
						num2 = num;
					}
					else
					{
						num = -597528972;
						num2 = num;
					}
					continue;
					end_IL_0012:
					break;
				}
				break;
			}
		}
		Logger.LogError("Device was not in connected list! Cannot remove!");
	}

	private void IzDoCLFRSHRPZgcZZlEqKXbnDBF()
	{
		int count = ljUWisroiVgcxAxyrURnKFzSwIW.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1580468026;
			while (true)
			{
				switch (num ^ -1580468027)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					num2 = count - 1;
					num = -1580468028;
					continue;
				case 1:
				{
					int num3;
					if (num2 < 0)
					{
						num = -1580468031;
						num3 = num;
					}
					else
					{
						num = -1580468025;
						num3 = num;
					}
					continue;
				}
				case 2:
					lTyhkulXbCdtDtysMmQBOBDZnP(num2);
					num2--;
					num = -1580468028;
					continue;
				case 4:
					return;
				}
				break;
			}
		}
	}

	private bool NsKfrPICAOsMNxuGJtMJgtOYkyHW(CustomController P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		int num = 0;
		int num2 = -603659821;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num2 ^ -603659820)
			{
			case 0:
				break;
			case 5:
				SerYLNcBvSGLsDnWKlmIAbnbmflt.Add(P_0);
				num2 = -603659824;
				continue;
			case 2:
				if (SerYLNcBvSGLsDnWKlmIAbnbmflt[num] == P_0)
				{
					num2 = -603659817;
					continue;
				}
				num++;
				num2 = -603659821;
				continue;
			case 1:
				return false;
			case 3:
				return true;
			case 4:
				SZCeMxfPCTerGWEMwYOvsgmToRb.Add(P_0);
				VdYbRIfIAqVYCJnTMRUdCcFYmUp.DQFfftDmidgQeZhyhKnTyuCofPy(P_0);
				num2 = -603659822;
				continue;
			case 7:
			{
				int num3;
				if (num < SerYLNcBvSGLsDnWKlmIAbnbmflt.Count)
				{
					num2 = -603659818;
					num3 = num2;
				}
				else
				{
					num2 = -603659823;
					num3 = num2;
				}
				continue;
			}
			default:
				return true;
			}
			break;
		}
		goto IL_0003;
		IL_0003:
		num2 = -603659819;
		goto IL_0008;
	}

	private bool PDQUjpckXCQXzCfTVwQoaafKrYv(CustomController P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		VdYbRIfIAqVYCJnTMRUdCcFYmUp.imOvIGjOATSBDNJuFHrmrpVSbPY(P_0);
		SZCeMxfPCTerGWEMwYOvsgmToRb.Remove(P_0);
		return SerYLNcBvSGLsDnWKlmIAbnbmflt.Remove(P_0);
	}

	private PCItYZcmQVbRIIUnLbZiPkYVRSE mGctvOjPMlQAZKTkOBGjOzSTOLw(int P_0)
	{
		if (P_0 == 9999999)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 >= 0)
		{
			if (P_0 >= ReInput.YYmRYrIJJDlFmDKErJxqlPcJEZJ.gamePlayerCount)
			{
				num = -2015510806;
				goto IL_000d;
			}
			return qqeCWZfcZFjJuutpLYlCZqOUgFp[P_0];
		}
		goto IL_0045;
		IL_000d:
		switch (num ^ -2015510806)
		{
		case 2:
			break;
		case 1:
			return lzwmJEEwtQRUiNEXvXBgJIIYFZy;
		default:
			goto IL_0045;
		}
		goto IL_0008;
		IL_0008:
		num = -2015510805;
		goto IL_000d;
		IL_0045:
		return null;
	}

	private void vNroSexmaJEzPHmQIpkWEjxjHIiJ(bool P_0)
	{
		if (!P_0)
		{
			EooLpHTnerlwDrVwyPBbECOAJgQ.wWHIeZOvAcJogZJomCBAHnsZeBwE();
		}
	}

	private void EyzHgLRlWvcWTAWdkRJsusIxnhij(bool P_0)
	{
		if (P_0 || ReInput.applicationRunInBackground)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < ljUWisroiVgcxAxyrURnKFzSwIW.Count)
			{
				num2 = -1353237236;
				num3 = num2;
			}
			else
			{
				num2 = -1353237235;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1353237234)
				{
				case 0:
					num2 = -1353237236;
					continue;
				default:
					return;
				case 2:
					ljUWisroiVgcxAxyrURnKFzSwIW[num].StopVibration();
					num++;
					num2 = -1353237233;
					continue;
				case 1:
					break;
				case 3:
					return;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(true);
		GC.SuppressFinalize(this);
	}

	~GDZJmMlQvBAxDaQCuBIKYWggay()
	{
		DJeUzQoMEVOxbEpwDFXbTBWdIKu(false);
	}

	private void DJeUzQoMEVOxbEpwDFXbTBWdIKu(bool P_0)
	{
		if (vsurYtRlepcrpAzAENwjqjJEZPT)
		{
			return;
		}
		while (true)
		{
			if (!P_0)
			{
				goto IL_0056;
			}
			int num;
			if (IaJFakVcuQqRPXRTOUcPncNOHUh is IDisposable)
			{
				(IaJFakVcuQqRPXRTOUcPncNOHUh as IDisposable).Dispose();
				num = -1379127193;
				goto IL_000e;
			}
			goto IL_0064;
			IL_000e:
			while (true)
			{
				switch (num ^ -1379127193)
				{
				case 2:
					num = -1379127196;
					continue;
				default:
					return;
				case 3:
					break;
				case 1:
					goto IL_0056;
				case 0:
					goto IL_0064;
				case 4:
					return;
				}
				break;
			}
			continue;
			IL_0064:
			if (jnwpLKAjJYsADMqwTXugbizunPZ is IDisposable)
			{
				(jnwpLKAjJYsADMqwTXugbizunPZ as IDisposable).Dispose();
				num = -1379127194;
				goto IL_000e;
			}
			goto IL_0056;
			IL_0056:
			vsurYtRlepcrpAzAENwjqjJEZPT = true;
			num = -1379127197;
			goto IL_000e;
		}
	}
}
