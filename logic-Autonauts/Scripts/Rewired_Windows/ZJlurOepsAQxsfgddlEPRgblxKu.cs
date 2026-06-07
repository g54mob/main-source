using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Windows.RawInput;

internal class ZJlurOepsAQxsfgddlEPRgblxKu : PlatformInputManager, yLzSZCPmdJJGIPBHZlMHGMUViap
{
	private class zYKlnVPIidhlEGjgyEmNKwdfoPXo : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int XKdkawtumCxPyKPVBrWIuFkhbmb;

		private int CcAaBYTnhTzbmiXXmdIizsUxQeD;

		public Guid REezjTFCollnzcnDXouNnLNDkjk;

		public string HMaFDzCZyyJZjLhcCpVmgIggZoam;

		private readonly KchbyaIpiOUwIuFRWQOhqCekrdI FvpbthwqHsVfdlOKqyTxjSLrkXP;

		private readonly DeviceType PKcpZyZqpXABDjaGPUDXDEPgbQK;

		public string mHIfxFeuzrrprIjNQQttDcAWoJX;

		public string AOVTbdgjQpuvVXuOzJgmsvYOWec;

		public string ZODLrlcqYgYcHKPIQwZOreOIaYF;

		public int fSuJoZmgBMnbZWJgvPaTNrIBkjq;

		public int DqYErgUjFMUHxVkmrXzgfOxtEsC;

		public Guid cBDIfdqFvdWzxrFEMJqjLvTvIpG;

		public Guid qSJYeLiyjfTRCcMnvDOwuKWJouA;

		public Guid CgIVyXGyqTDPaUYRIwDzeLsZOit;

		public int ySxHACCmrqwNquIhkRqoFdufNKj;

		public int wqHuqGsJmegTaHkGmUKGpvcrfRfB;

		public int pIAPquXHYXQpPJRbLVGwvBFcXgk;

		public int jHaYXdTXWAJNlfIRTMsRGaqNBpK;

		public int qOBHYZBCAkYYTJoRDdsZoTyTELA;

		public int ByBfmUYbKOERmAjkpxrmtOAORFt;

		public bool KqmajqZRajQeRJHxvHBZhqVPgsd;

		public bool NxfPDLDjjkkAByWVYHnViSDRJzU;

		public bool mqRCOGhpUhuJIDFwlHJQROPEFMrC;

		public int bELhEeAWQmtfFIrLTgNSpwrpFSQN;

		private float[] ZRzHEnKZrARTmYSqzudcOoQkFLn;

		private float[] vqZyMIbiZNaMpemrDPhgsXmGAKrY;

		private bool[] qeGbNsgsdQFGjtYzwhQQpCumZFP;

		private HardwareJoystickMap_InputManager VjkWjnwoPItHtAfScAsiHywgzcu;

		private pORaxzeTYCRZPbhHycQGjGqbCdL XdgIhjPOvYiPrAnuSuMBIFLQhh;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

		private bool yRialUFBmVuFTOVrRxRadMBTRymj;

		private bool VOmckskOqMXuJcSBuIcPcvDRBIhH;

		private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

		[CompilerGenerated]
		private Controller.Extension WnCqlIZyXIlfyFNdNqixGkJpZiq;

		public bool hasDriver
		{
			get
			{
				if (FvpbthwqHsVfdlOKqyTxjSLrkXP == null)
				{
					return false;
				}
				return FvpbthwqHsVfdlOKqyTxjSLrkXP.Driver != null;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return XKdkawtumCxPyKPVBrWIuFkhbmb;
			}
			set
			{
				XKdkawtumCxPyKPVBrWIuFkhbmb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return CcAaBYTnhTzbmiXXmdIizsUxQeD;
			}
			set
			{
				CcAaBYTnhTzbmiXXmdIizsUxQeD = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (HMaFDzCZyyJZjLhcCpVmgIggZoam != "Unknown Controller")
				{
					goto IL_0012;
				}
				int num;
				if (NxfPDLDjjkkAByWVYHnViSDRJzU)
				{
					num = -12632785;
					goto IL_0017;
				}
				goto IL_0065;
				IL_0017:
				while (true)
				{
					switch (num ^ -12632787)
					{
					case 0:
						break;
					case 3:
						return HMaFDzCZyyJZjLhcCpVmgIggZoam;
					case 2:
						goto IL_004a;
					default:
						return ZODLrlcqYgYcHKPIQwZOreOIaYF;
					}
					break;
					IL_004a:
					if (!string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF))
					{
						num = -12632788;
						continue;
					}
					goto IL_0065;
				}
				goto IL_0012;
				IL_0065:
				return AOVTbdgjQpuvVXuOzJgmsvYOWec;
				IL_0012:
				num = -12632786;
				goto IL_0017;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				long? result = default(long?);
				if (CcAaBYTnhTzbmiXXmdIizsUxQeD < 0)
				{
					while (true)
					{
						int num = 2097014764;
						while (true)
						{
							switch (num ^ 0x7CFDE7ED)
							{
							case 0:
								break;
							case 1:
								goto IL_0027;
							default:
								return result;
							}
							break;
							IL_0027:
							result = null;
							num = 2097014767;
						}
					}
				}
				return CcAaBYTnhTzbmiXXmdIizsUxQeD;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return WnCqlIZyXIlfyFNdNqixGkJpZiq;
			}
			[CompilerGenerated]
			set
			{
				WnCqlIZyXIlfyFNdNqixGkJpZiq = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return cBDIfdqFvdWzxrFEMJqjLvTvIpG;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return instanceGuid;
			}
		}

		public bool IsValid
		{
			get
			{
				if (!nNxUslIcGUpqKgpPZYhuimcvWyC && FvpbthwqHsVfdlOKqyTxjSLrkXP != null)
				{
					return FvpbthwqHsVfdlOKqyTxjSLrkXP.IsValid;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			bool isValid = IsValid;
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			bool isValid = IsValid;
		}

		public zYKlnVPIidhlEGjgyEmNKwdfoPXo(KchbyaIpiOUwIuFRWQOhqCekrdI joystick, DeviceType riDeviceType, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			while (true)
			{
				int num = 1023143589;
				while (true)
				{
					switch (num ^ 0x3CFBEEA6)
					{
					case 0:
						break;
					case 3:
						FvpbthwqHsVfdlOKqyTxjSLrkXP = joystick;
						PKcpZyZqpXABDjaGPUDXDEPgbQK = riDeviceType;
						lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
						num = 1023143588;
						continue;
					case 2:
						CcAaBYTnhTzbmiXXmdIizsUxQeD = -1;
						num = 1023143591;
						continue;
					default:
						XKdkawtumCxPyKPVBrWIuFkhbmb = -1;
						return;
					}
					break;
				}
			}
		}

		public void qlRdJvJiKhLJLbmzJBHkcnXAtwPX()
		{
			if (!IsValid)
			{
				goto IL_000b;
			}
			goto IL_0119;
			IL_000b:
			int num = -1392787576;
			goto IL_0010;
			IL_0010:
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = default(HardwareJoystickMap.Platform_DirectInput_Base);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = default(HardwareJoystickMap.Platform_RawInput_Base);
			int num3 = default(int);
			InputPlatform platform = default(InputPlatform);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1392787560)
				{
				case 14:
					break;
				case 16:
					return;
				case 0:
					buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
					num = -1392787563;
					continue;
				case 6:
					goto IL_0090;
				case 7:
					XdgIhjPOvYiPrAnuSuMBIFLQhh = FvpbthwqHsVfdlOKqyTxjSLrkXP.AxesState;
					num = -1392787575;
					continue;
				case 10:
					buttons_orig = platform_RawInput_Base.Buttons_orig;
					num = -1392787557;
					continue;
				case 13:
					goto IL_00d6;
				case 3:
					if (buttons_orig != null)
					{
						num3 = 0;
						num = -1392787554;
						continue;
					}
					goto case 7;
				case 18:
					goto IL_00fd;
				case 1:
					goto IL_0119;
				case 8:
					num = -1392787574;
					continue;
				case 15:
					if (platform == InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba)
					{
						platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						num = -1392787566;
						continue;
					}
					goto case 4;
				case 9:
					qeGbNsgsdQFGjtYzwhQQpCumZFP[num2] = buttons_orig2[num2].buttonInfo.isPressureSensitive;
					num2++;
					num = -1392787574;
					continue;
				case 4:
					if (platform == InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh)
					{
						platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						num = -1392787560;
						continue;
					}
					goto case 7;
				case 12:
					qeGbNsgsdQFGjtYzwhQQpCumZFP = new bool[pIAPquXHYXQpPJRbLVGwvBFcXgk];
					num = -1392787558;
					continue;
				case 11:
					qeGbNsgsdQFGjtYzwhQQpCumZFP[num3] = buttons_orig[num3].buttonInfo.isPressureSensitive;
					num3++;
					num = -1392787554;
					continue;
				case 20:
					num = -1392787553;
					continue;
				case 5:
					goto IL_02a1;
				case 19:
					num2 = 0;
					num = -1392787568;
					continue;
				case 2:
					goto IL_02cb;
				case 21:
					platform = VjkWjnwoPItHtAfScAsiHywgzcu.map.platform;
					num = -1392787561;
					continue;
				default:
					Update();
					return;
				}
				break;
				IL_02cb:
				int num4;
				if (VjkWjnwoPItHtAfScAsiHywgzcu != null)
				{
					num = -1392787555;
					num4 = num;
				}
				else
				{
					num = -1392787553;
					num4 = num;
				}
				continue;
				IL_0090:
				int num5;
				if (num3 < buttons_orig.Length)
				{
					num = -1392787565;
					num5 = num;
				}
				else
				{
					num = -1392787572;
					num5 = num;
				}
				continue;
				IL_00fd:
				int num6;
				if (num2 >= buttons_orig2.Length)
				{
					num = -1392787553;
					num6 = num;
				}
				else
				{
					num = -1392787567;
					num6 = num;
				}
				continue;
				IL_02a1:
				int num7;
				if (pIAPquXHYXQpPJRbLVGwvBFcXgk <= 0)
				{
					num = -1392787553;
					num7 = num;
				}
				else
				{
					num = -1392787571;
					num7 = num;
				}
				continue;
				IL_00d6:
				int num8;
				if (buttons_orig2 != null)
				{
					num = -1392787573;
					num8 = num;
				}
				else
				{
					num = -1392787553;
					num8 = num;
				}
			}
			goto IL_000b;
			IL_0119:
			CgIVyXGyqTDPaUYRIwDzeLsZOit = MiscTools.CreateGuidHashSHA1(((!string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF)) ? ZODLrlcqYgYcHKPIQwZOreOIaYF : AOVTbdgjQpuvVXuOzJgmsvYOWec) + qSJYeLiyjfTRCcMnvDOwuKWJouA);
			wqHuqGsJmegTaHkGmUKGpvcrfRfB = jHaYXdTXWAJNlfIRTMsRGaqNBpK;
			pIAPquXHYXQpPJRbLVGwvBFcXgk = qOBHYZBCAkYYTJoRDdsZoTyTELA + ByBfmUYbKOERmAjkpxrmtOAORFt * 8;
			HUcWpSluxhNdngRwNRiLQuUWiQb();
			REezjTFCollnzcnDXouNnLNDkjk = VjkWjnwoPItHtAfScAsiHywgzcu.hardwareMapIdentifier.guid;
			HMaFDzCZyyJZjLhcCpVmgIggZoam = VjkWjnwoPItHtAfScAsiHywgzcu.controllerName;
			yRialUFBmVuFTOVrRxRadMBTRymj = ((REezjTFCollnzcnDXouNnLNDkjk == Guid.Empty) ? true : false);
			ZRzHEnKZrARTmYSqzudcOoQkFLn = new float[wqHuqGsJmegTaHkGmUKGpvcrfRfB];
			vqZyMIbiZNaMpemrDPhgsXmGAKrY = new float[pIAPquXHYXQpPJRbLVGwvBFcXgk];
			num = -1392787564;
			goto IL_0010;
		}

		public void qmxqFhOXPynIFVlddeYJeiHLrJIQ(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0)
		{
			if (!IsValid)
			{
				return;
			}
			int num4 = default(int);
			int num3 = default(int);
			while (P_0 != null)
			{
				while (true)
				{
					CcAaBYTnhTzbmiXXmdIizsUxQeD = P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD;
					XKdkawtumCxPyKPVBrWIuFkhbmb = P_0.XKdkawtumCxPyKPVBrWIuFkhbmb;
					int num = 0;
					int num2 = 226493653;
					while (true)
					{
						switch (num2 ^ 0xD8004DD)
						{
						case 9:
							num2 = 226493656;
							continue;
						case 6:
							num4 = 0;
							num2 = 226493654;
							continue;
						case 4:
							vqZyMIbiZNaMpemrDPhgsXmGAKrY[num] = P_0.vqZyMIbiZNaMpemrDPhgsXmGAKrY[num];
							num2 = 226493660;
							continue;
						case 2:
							break;
						case 11:
							num2 = 226493655;
							continue;
						case 10:
							if (num4 >= MathTools.Min(qeGbNsgsdQFGjtYzwhQQpCumZFP.Length, P_0.qeGbNsgsdQFGjtYzwhQQpCumZFP.Length))
							{
								num3 = 0;
								num2 = 226493649;
								continue;
							}
							goto case 3;
						case 3:
							qeGbNsgsdQFGjtYzwhQQpCumZFP[num4] = P_0.qeGbNsgsdQFGjtYzwhQQpCumZFP[num4];
							num4++;
							num2 = 226493655;
							continue;
						case 0:
							ZRzHEnKZrARTmYSqzudcOoQkFLn[num3] = P_0.ZRzHEnKZrARTmYSqzudcOoQkFLn[num3];
							num3++;
							num2 = 226493649;
							continue;
						case 5:
							goto end_IL_0075;
						case 1:
							num++;
							num2 = 226493653;
							continue;
						case 8:
							goto IL_0122;
						case 12:
							goto IL_014e;
						default:
							VOmckskOqMXuJcSBuIcPcvDRBIhH = P_0.VOmckskOqMXuJcSBuIcPcvDRBIhH;
							return;
						}
						break;
						IL_014e:
						int num5;
						if (num3 >= MathTools.Min(ZRzHEnKZrARTmYSqzudcOoQkFLn.Length, P_0.ZRzHEnKZrARTmYSqzudcOoQkFLn.Length))
						{
							num2 = 226493658;
							num5 = num2;
						}
						else
						{
							num2 = 226493661;
							num5 = num2;
						}
						continue;
						IL_0122:
						int num6;
						if (num >= MathTools.Min(vqZyMIbiZNaMpemrDPhgsXmGAKrY.Length, P_0.vqZyMIbiZNaMpemrDPhgsXmGAKrY.Length))
						{
							num2 = 226493659;
							num6 = num2;
						}
						else
						{
							num2 = 226493657;
							num6 = num2;
						}
					}
					continue;
					end_IL_0075:
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (!IsValid)
			{
				return;
			}
			while (true)
			{
				bool[] buttons = FvpbthwqHsVfdlOKqyTxjSLrkXP.Buttons;
				int[] hatValues = FvpbthwqHsVfdlOKqyTxjSLrkXP.HatValues;
				int num = 1450388214;
				while (true)
				{
					switch (num ^ 0x56732AF7)
					{
					case 0:
						num = 1450388212;
						continue;
					default:
						return;
					case 2:
						ntHkZnBwItpIoEGMjrBEabLTXFJ(buttons, hatValues);
						num = 1450388211;
						continue;
					case 1:
						QwjbBaCiqpyATADIBvDzRnxExBKA(buttons, hatValues);
						num = 1450388213;
						continue;
					case 3:
						break;
					case 4:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!IsValid)
			{
				return;
			}
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				IL_00ff:
				if (wqHuqGsJmegTaHkGmUKGpvcrfRfB == dataUpdater.axisCount)
				{
					int num;
					int num2;
					if (pIAPquXHYXQpPJRbLVGwvBFcXgk == dataUpdater.buttonCount)
					{
						num = 10029515;
						num2 = num;
					}
					else
					{
						num = 10029506;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x9909C7)
						{
						case 0:
							num = 10029508;
							continue;
						default:
							return;
						case 1:
							if (!dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = 10029518;
								continue;
							}
							return;
						case 7:
							if (num3 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
							{
								num4 = 0;
								num = 10029505;
								continue;
							}
							goto case 13;
						case 6:
							if (num4 >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
							{
								goto IL_0090;
							}
							goto case 4;
						case 12:
							num3 = 0;
							num = 10029504;
							continue;
						case 11:
							num4++;
							num = 10029505;
							continue;
						case 8:
							num = 10029516;
							continue;
						case 13:
							dataUpdater.axisValues[num3] = ZRzHEnKZrARTmYSqzudcOoQkFLn[num3];
							num = 10029517;
							continue;
						case 5:
							break;
						case 3:
							goto IL_00ff;
						case 2:
							dataUpdater.buttonValues[num4] = ((vqZyMIbiZNaMpemrDPhgsXmGAKrY[num4] > 0f) ? true : false);
							num = 10029516;
							continue;
						case 4:
							if (qeGbNsgsdQFGjtYzwhQQpCumZFP[num4])
							{
								dataUpdater.buttonPressureValues[num4] = vqZyMIbiZNaMpemrDPhgsXmGAKrY[num4];
								num = 10029519;
								continue;
							}
							goto case 2;
						case 10:
							num3++;
							num = 10029504;
							continue;
						case 9:
							return;
						}
						break;
						IL_0090:
						int num5;
						if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
						{
							num = 10029510;
							num5 = num;
						}
						else
						{
							num = 10029518;
							num5 = num;
						}
					}
				}
				throw new Exception("This controller signature does not match the data object!");
			}
		}

		public int CjIOgfYLwvzSovgYNuiXTTvJjBe(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0)
		{
			if (!IsValid)
			{
				return 0;
			}
			if (P_0.XKdkawtumCxPyKPVBrWIuFkhbmb == XKdkawtumCxPyKPVBrWIuFkhbmb)
			{
				return 2;
			}
			if (jHaYXdTXWAJNlfIRTMsRGaqNBpK != P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK)
			{
				return 0;
			}
			if (qOBHYZBCAkYYTJoRDdsZoTyTELA != P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA)
			{
				goto IL_0038;
			}
			if (ByBfmUYbKOERmAjkpxrmtOAORFt != P_0.ByBfmUYbKOERmAjkpxrmtOAORFt)
			{
				return 0;
			}
			int num;
			if (hasDriver != P_0.hasDriver)
			{
				num = -2012158478;
			}
			else
			{
				if (P_0.instanceGuid == instanceGuid)
				{
					return 2;
				}
				if (!(P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit == CgIVyXGyqTDPaUYRIwDzeLsZOit))
				{
					return 0;
				}
				num = -2012158479;
			}
			goto IL_003d;
			IL_003d:
			switch (num ^ -2012158477)
			{
			case 0:
				break;
			case 3:
				return 0;
			case 1:
				return 0;
			default:
				return 1;
			}
			goto IL_0038;
			IL_0038:
			num = -2012158480;
			goto IL_003d;
		}

		private BridgedControllerHWInfo XNhjnTKDnPIWYdspfSxvjnotCFBk()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!IsValid)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(XKdkawtumCxPyKPVBrWIuFkhbmb);
		}

		private void QwjbBaCiqpyATADIBvDzRnxExBKA(bool[] P_0, int[] P_1)
		{
			if (wqHuqGsJmegTaHkGmUKGpvcrfRfB <= 0)
			{
				goto IL_000c;
			}
			goto IL_0174;
			IL_000c:
			int num = -1001592418;
			goto IL_0011;
			IL_0011:
			InputPlatform platform = default(InputPlatform);
			HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = default(HardwareJoystickMap.Platform_InternalDriver_Base);
			int num4 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			int num3 = default(int);
			HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_InternalDriver_Base.Axis[]);
			int num2 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = default(HardwareJoystickMap.Platform_DirectInput_Base);
			while (true)
			{
				switch (num ^ -1001592423)
				{
				case 5:
					break;
				default:
					return;
				case 15:
					if (platform == InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR)
					{
						platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						num = -1001592432;
						continue;
					}
					return;
				case 18:
					num4++;
					num = -1001592438;
					continue;
				case 4:
					RllMKCBqlEnYHHyzXfDrYOpOkeB(axes_orig3[num3], num3, P_0, P_1);
					num3++;
					num = -1001592433;
					continue;
				case 21:
					HXUZKfgGQxQhzyngFLRJbOoVdRHe(axes_orig2[num2], num2, P_0, P_1);
					num = -1001592417;
					continue;
				case 10:
					num4 = 0;
					num = -1001592438;
					continue;
				case 11:
					RllMKCBqlEnYHHyzXfDrYOpOkeB(axes_orig[num4], num4, P_0, P_1);
					num = -1001592437;
					continue;
				case 1:
					return;
				case 17:
				{
					if (platform != InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba)
					{
						goto IL_0150;
					}
					HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
					axes_orig3 = platform_RawInput_Base.Axes_orig;
					if (axes_orig3 == null)
					{
						return;
					}
					goto case 0;
				}
				case 3:
					num2 = 0;
					num = -1001592434;
					continue;
				case 2:
					goto IL_0150;
				case 0:
					num3 = 0;
					num = -1001592433;
					continue;
				case 14:
					goto IL_0174;
				case 22:
					goto IL_018f;
				case 8:
					return;
				case 7:
					return;
				case 19:
					goto IL_01bf;
				case 9:
					axes_orig2 = platform_InternalDriver_Base.Axes_orig;
					if (axes_orig2 == null)
					{
						return;
					}
					goto case 3;
				case 20:
					goto IL_01f6;
				case 23:
					num = -1001592435;
					continue;
				case 13:
					platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
					num = -1001592427;
					continue;
				case 12:
					axes_orig = platform_DirectInput_Base.Axes_orig;
					if (axes_orig == null)
					{
						return;
					}
					goto case 10;
				case 6:
					num2++;
					num = -1001592435;
					continue;
				case 16:
					return;
				}
				break;
				IL_01f6:
				int num5;
				if (num2 >= axes_orig2.Length)
				{
					num = -1001592439;
					num5 = num;
				}
				else
				{
					num = -1001592436;
					num5 = num;
				}
				continue;
				IL_018f:
				int num6;
				if (num3 >= axes_orig3.Length)
				{
					num = -1001592431;
					num6 = num;
				}
				else
				{
					num = -1001592419;
					num6 = num;
				}
				continue;
				IL_0150:
				int num7;
				if (platform != InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh)
				{
					num = -1001592426;
					num7 = num;
				}
				else
				{
					num = -1001592428;
					num7 = num;
				}
				continue;
				IL_01bf:
				int num8;
				if (num4 < axes_orig.Length)
				{
					num = -1001592430;
					num8 = num;
				}
				else
				{
					num = -1001592424;
					num8 = num;
				}
			}
			goto IL_000c;
			IL_0174:
			platform = VjkWjnwoPItHtAfScAsiHywgzcu.map.platform;
			num = -1001592440;
			goto IL_0011;
		}

		private void ntHkZnBwItpIoEGMjrBEabLTXFJ(bool[] P_0, int[] P_1)
		{
			if (pIAPquXHYXQpPJRbLVGwvBFcXgk <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			int num = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num4 = default(int);
			HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig3 = default(HardwareJoystickMap.Platform_InternalDriver_Base.Button[]);
			int num3 = default(int);
			while (true)
			{
				IL_00f1:
				InputPlatform platform = VjkWjnwoPItHtAfScAsiHywgzcu.map.platform;
				if (platform == InputPlatform.cZjaGiccoOfQMydNsMdhkKrlxCba)
				{
					HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
					buttons_orig = platform_RawInput_Base.Buttons_orig;
					if (buttons_orig == null)
					{
						break;
					}
					goto IL_012f;
				}
				goto IL_01bc;
				IL_012f:
				num = 0;
				int num2 = -1158161928;
				goto IL_0012;
				IL_01bc:
				if (platform != InputPlatform.GqzyAlVbsTJEJeHcVvIVueUVgOh)
				{
					goto IL_00c2;
				}
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
				buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
				if (buttons_orig2 == null)
				{
					break;
				}
				goto IL_013b;
				IL_0012:
				while (true)
				{
					switch (num2 ^ -1158161927)
					{
					case 15:
						num2 = -1158161926;
						continue;
					default:
						return;
					case 16:
						if (num4 >= buttons_orig2.Length)
						{
							return;
						}
						goto case 12;
					case 7:
					{
						HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map;
						buttons_orig3 = platform_InternalDriver_Base.Buttons_orig;
						if (buttons_orig3 == null)
						{
							return;
						}
						goto case 4;
					}
					case 5:
						break;
					case 14:
						goto end_IL_0012;
					case 11:
						LcwcYjKajxFOmevKwcJVUOXnNQR(buttons_orig[num], num, P_0, P_1);
						num2 = -1158161933;
						continue;
					case 3:
						goto IL_00f1;
					case 2:
						goto IL_012f;
					case 13:
						goto IL_013b;
					case 8:
						if (num >= buttons_orig.Length)
						{
							return;
						}
						goto case 11;
					case 4:
						num3 = 0;
						num2 = -1158161924;
						continue;
					case 12:
						LcwcYjKajxFOmevKwcJVUOXnNQR(buttons_orig2[num4], num4, P_0, P_1);
						num4++;
						num2 = -1158161943;
						continue;
					case 1:
						num2 = -1158161935;
						continue;
					case 9:
						yGkMJBwnMntcRGbKyrjKgnsUCud(buttons_orig3[num3], num3, P_0, P_1);
						num3++;
						num2 = -1158161924;
						continue;
					case 10:
						num++;
						num2 = -1158161935;
						continue;
					case 6:
						goto IL_01bc;
					case 0:
						return;
					}
					int num5;
					if (num3 < buttons_orig3.Length)
					{
						num2 = -1158161936;
						num5 = num2;
					}
					else
					{
						num2 = -1158161927;
						num5 = num2;
					}
					continue;
					end_IL_0012:
					break;
				}
				goto IL_00c2;
				IL_00c2:
				int num6;
				if (platform != InputPlatform.sstGbYqotnUAodZSsTwHEEbgiSR)
				{
					num2 = -1158161927;
					num6 = num2;
				}
				else
				{
					num2 = -1158161922;
					num6 = num2;
				}
				goto IL_0012;
				IL_013b:
				num4 = 0;
				num2 = -1158161943;
				goto IL_0012;
			}
		}

		private void RllMKCBqlEnYHHyzXfDrYOpOkeB(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 872785280;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x3405A585)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
					num = 872785284;
					continue;
				case 3:
					goto IL_0041;
				case 5:
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				case 0:
					goto IL_007e;
				case 1:
					return;
				}
				break;
				IL_007e:
				int num2;
				if (ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] == 0f)
				{
					num = 872785284;
					num2 = num;
				}
				else
				{
					num = 872785287;
					num2 = num;
				}
			}
			goto IL_0009;
			IL_0041:
			ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] = MnqkSgUruMGpGEncQArrqhjEHzFC(P_0, P_2, P_3);
			int num3;
			if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
			{
				num = 872785284;
				num3 = num;
			}
			else
			{
				num = 872785285;
				num3 = num;
			}
			goto IL_000e;
		}

		private void LcwcYjKajxFOmevKwcJVUOXnNQR(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1] = odpuOJgHmnilGWRhqHPsTzrkUnQ(P_0, P_2, P_3);
				int num = 99495682;
				while (true)
				{
					switch (num ^ 0x5EE2F00)
					{
					case 0:
						num = 99495684;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
					{
						int num2;
						if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
						{
							num = 99495683;
							num2 = num;
						}
						else
						{
							num = 99495681;
							num2 = num;
						}
						continue;
					}
					case 1:
						if (vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1] != 0f)
						{
							VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
							num = 99495683;
							continue;
						}
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			int sourceAxis = default(int);
			int num;
			int sourceHat = default(int);
			int sourceButton = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				if (sourceAxis == 0)
				{
					goto IL_0019;
				}
				int num2;
				if (sourceAxis >= 1)
				{
					num = 423382426;
					num2 = num;
				}
				else
				{
					num = 423382425;
					num2 = num;
				}
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					sourceHat = P_0.sourceHat;
					int num3;
					if (sourceHat < 0)
					{
						num = 423382419;
						num3 = num;
					}
					else
					{
						num = 423382424;
						num3 = num;
					}
				}
				else
				{
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						return 0f;
					}
					num = 423382408;
				}
			}
			else
			{
				sourceButton = P_0.sourceButton;
				num = 423382421;
			}
			goto IL_001e;
			IL_001e:
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num5 = default(int);
			int num9 = default(int);
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = default(HardwareElementSourceTypeWithHat);
			float result = default(float);
			float num4 = default(float);
			HardwareJoystickMap.Platform_RawInput_Base.Axis axis = default(HardwareJoystickMap.Platform_RawInput_Base.Axis);
			while (true)
			{
				switch (num ^ 0x193C4D92)
				{
				case 12:
					break;
				case 22:
					return 0f;
				case 26:
					customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return 0f;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						num = 423382406;
						continue;
					}
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num5 = 0;
					num = 423382420;
					continue;
				case 1:
					return 0f;
				case 13:
					num9 = 0;
					num = 423382427;
					continue;
				case 14:
					if (customCalculationSourceData[num5] != null)
					{
						HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num5].sourceType;
						hardwareElementSourceTypeWithHat = sourceType;
						num = 423382407;
						continue;
					}
					goto case 15;
				case 6:
				{
					int num6;
					if (num5 >= customCalculationSourceData.Length)
					{
						num = 423382405;
						num6 = num;
					}
					else
					{
						num = 423382428;
						num6 = num;
					}
					continue;
				}
				case 3:
					return 0f;
				case 17:
					return 0f;
				case 21:
				{
					float item;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && SphXEVFIXUzhWZMGZUyIbdOXoiY(customCalculationSourceData[num5], out item))
					{
						customCalculation.AddData(item);
						num = 423382429;
						continue;
					}
					goto case 15;
				}
				case 11:
				{
					int num8;
					if (sourceAxis != 1000)
					{
						num = 423382416;
						num8 = num;
					}
					else
					{
						num = 423382402;
						num8 = num;
					}
					continue;
				}
				case 25:
					result = -1f;
					num = 423382422;
					continue;
				case 4:
					return result;
				case 8:
				{
					int num7;
					if (sourceAxis <= 11)
					{
						num = 423382431;
						num7 = num;
					}
					else
					{
						num = 423382425;
						num7 = num;
					}
					continue;
				}
				case 10:
					if (sourceHat < ByBfmUYbKOERmAjkpxrmtOAORFt)
					{
						if (sourceHat < 4)
						{
							int num10 = P_2[sourceHat];
							if (num10 < 0)
							{
								return 0f;
							}
							if (P_0.sourceHatDirection == AxisDirection.Horizontal)
							{
								num4 = zGynLZPNrxQpghHyIZzAUIHYsnd(num10, AxisDirection.Horizontal);
								if (P_0.sourceHatRange != AxisRange.Full)
								{
									if (P_0.sourceHatRange != AxisRange.Positive)
									{
										if (num4 > 0f)
										{
											num = 423382417;
											continue;
										}
									}
									else if (num4 < 0f)
									{
										num = 423382404;
										continue;
									}
								}
							}
							else
							{
								num4 = zGynLZPNrxQpghHyIZzAUIHYsnd(num10, AxisDirection.Vertical);
								if (P_0.sourceHatRange != AxisRange.Full)
								{
									if (P_0.sourceHatRange == AxisRange.Positive)
									{
										if (num4 < 0f)
										{
											return 0f;
										}
									}
									else if (num4 > 0f)
									{
										return 0f;
									}
								}
							}
							int num11;
							if (P_0.invert)
							{
								num = 423382423;
								num11 = num;
							}
							else
							{
								num = 423382410;
								num11 = num;
							}
						}
						else
						{
							num = 423382419;
						}
						continue;
					}
					goto case 1;
				case 0:
					if (axis == null)
					{
						return 0f;
					}
					num9 = axis.sourceOtherAxis;
					goto case 9;
				case 23:
					if (!customCalculation.Process())
					{
						num = 423382401;
						continue;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						return 0f;
					}
					return customCalculation.Result;
				case 27:
					return 0f;
				case 24:
					return num4;
				case 7:
					if (sourceButton < 0 || sourceButton >= qOBHYZBCAkYYTJoRDdsZoTyTELA)
					{
						goto case 17;
					}
					if (sourceButton < 256)
					{
						if (!P_1[sourceButton])
						{
							return 0f;
						}
						if (P_0.buttonAxisContribution == Pole.Positive)
						{
							result = 1f;
							num = 423382400;
							continue;
						}
						goto case 25;
					}
					num = 423382403;
					continue;
				case 18:
					num = 423382422;
					continue;
				case 20:
					return 0f;
				case 2:
					return 0f;
				case 9:
					return MnqkSgUruMGpGEncQArrqhjEHzFC((RawInputAxis)sourceAxis, num9);
				case 5:
					num4 *= -1f;
					num = 423382410;
					continue;
				case 16:
					axis = P_0 as HardwareJoystickMap.Platform_RawInput_Base.Axis;
					num = 423382418;
					continue;
				case 15:
					num5++;
					num = 423382420;
					continue;
				default:
					return 0f;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = 423382409;
			goto IL_001e;
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(RawInputAxis P_0, int P_1)
		{
			return lmyenCPLmUeYnxIapmEbpOtJtXT((XdgIhjPOvYiPrAnuSuMBIFLQhh as eUJOgRFwFEtBRdMBCiguyIbcaIX).MnqkSgUruMGpGEncQArrqhjEHzFC(P_0, P_1));
		}

		private float odpuOJgHmnilGWRhqHPsTzrkUnQ(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				goto IL_000b;
			}
			int sourceAxis = default(int);
			int num;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num3 = default(int);
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				if (sourceAxis == 0)
				{
					return 0f;
				}
				int num2;
				if (sourceAxis < 1)
				{
					num = -380157866;
					num2 = num;
				}
				else
				{
					num = -380157861;
					num2 = num;
				}
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_057b;
				}
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					num = -380157872;
				}
				else
				{
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num3 = 0;
					num = -380157888;
				}
			}
			else
			{
				sourceHat = P_0.sourceHat;
				num = -380157864;
			}
			goto IL_0010;
			IL_055b:
			if ((float)customCalculation.Result == 0f)
			{
				return 0f;
			}
			return 1f;
			IL_057b:
			return 0f;
			IL_0408:
			bool flag = default(bool);
			if (flag)
			{
				return 1f;
			}
			return 0f;
			IL_0010:
			int sourceButton = default(int);
			int num8 = default(int);
			float num5 = default(float);
			float num6 = default(float);
			float num7 = default(float);
			int num10 = default(int);
			while (true)
			{
				int num4;
				bool flag2;
				switch (num ^ -380157880)
				{
				case 0:
					break;
				case 29:
					goto IL_00a0;
				case 14:
					num = -380157869;
					continue;
				case 18:
					goto IL_00bf;
				case 23:
					goto IL_018c;
				case 11:
					return 0f;
				case 8:
					if (num3 >= customCalculationSourceData.Length)
					{
						goto IL_01f3;
					}
					goto case 20;
				case 1:
					return 0f;
				case 30:
					goto IL_024c;
				case 28:
					if (sourceButton >= 0)
					{
						goto IL_027f;
					}
					goto case 6;
				case 12:
					return 0f;
				case 9:
					goto IL_02c3;
				case 16:
					if (sourceHat < 0 || sourceHat >= ByBfmUYbKOERmAjkpxrmtOAORFt)
					{
						goto case 1;
					}
					goto IL_0312;
				case 20:
					if (customCalculationSourceData[num3] != null)
					{
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
							goto IL_0391;
						case HardwareElementSourceTypeWithHat.Axis:
							goto IL_04ee;
						}
						num = -380157877;
						continue;
					}
					goto case 3;
				case 3:
					num3++;
					num = -380157888;
					continue;
				case 26:
					if (P_0.ignoreIfButtonsActive)
					{
						num8 = 0;
						num = -380157882;
						continue;
					}
					goto IL_018c;
				case 15:
					return 0f;
				case 21:
					goto IL_0391;
				case 17:
					return 0f;
				case 6:
					return 0f;
				case 5:
					goto IL_03fd;
				case 4:
					return 0f;
				case 19:
					if (sourceAxis > 11)
					{
						goto IL_024c;
					}
					num4 = 0;
					goto IL_042e;
				case 13:
					goto IL_0465;
				case 2:
					customCalculation.AddData((num5 != 0f) ? 1f : 0f);
					num = -380157877;
					continue;
				case 22:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button button = P_0 as HardwareJoystickMap.Platform_RawInput_Base.Button;
					if (button == null)
					{
						return 0f;
					}
					num4 = button.sourceOtherAxis;
					goto IL_042e;
				}
				case 31:
					goto IL_04ce;
				case 25:
					goto IL_04ee;
				case 24:
					return 0f;
				case 27:
					goto IL_0536;
				default:
					return 0f;
				case 10:
					goto IL_057b;
					IL_0391:
					if (nkiUDWmqkoBdSdpkwhGLjZgLKfrF(customCalculationSourceData[num3], P_1, out flag2))
					{
						customCalculation.AddData(flag2 ? 1f : 0f);
						num = -380157877;
						continue;
					}
					goto case 3;
					IL_042e:
					num6 = MnqkSgUruMGpGEncQArrqhjEHzFC((RawInputAxis)sourceAxis, num4);
					num7 = MathTools.Abs(num6);
					num = -380157887;
					continue;
				}
				break;
				IL_0536:
				int num9;
				if (num8 >= P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num = -380157857;
					num9 = num;
				}
				else
				{
					num = -380157865;
					num9 = num;
				}
				continue;
				IL_018c:
				if (P_0.requireMultipleButtons)
				{
					flag = false;
					num10 = 0;
					num = -380157875;
				}
				else
				{
					sourceButton = P_0.sourceButton;
					num = -380157868;
				}
				continue;
				IL_027f:
				int num11;
				if (sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					num = -380157867;
					num11 = num;
				}
				else
				{
					num = -380157874;
					num11 = num;
				}
				continue;
				IL_04ce:
				if (P_1[P_0.ignoreIfButtonsActiveButtons[num8]])
				{
					return 0f;
				}
				num8++;
				num = -380157869;
				continue;
				IL_024c:
				int num12;
				if (sourceAxis == 1000)
				{
					num = -380157858;
					num12 = num;
				}
				else
				{
					num = -380157876;
					num12 = num;
				}
				continue;
				IL_00bf:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 0, P_0.sourceHatType);
				IL_03fd:
				if (num10 >= P_0.requiredButtons.Length)
				{
					goto IL_0408;
				}
				goto IL_0465;
				IL_0465:
				if (P_1[P_0.requiredButtons[num10]])
				{
					flag = true;
					num10++;
					num = -380157875;
				}
				else
				{
					num = -380157881;
				}
				continue;
				IL_00a0:
				if (sourceButton >= 256)
				{
					num = -380157874;
					continue;
				}
				if (P_1[sourceButton])
				{
					return 1f;
				}
				num = -380157885;
				continue;
				IL_01f3:
				if (!customCalculation.Process())
				{
					num = -380157863;
					continue;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					num = -380157873;
					continue;
				}
				goto IL_055b;
				IL_0312:
				if (sourceHat < 4)
				{
					switch (P_0.sourceHatDirection)
					{
					case HatDirection.Up:
						break;
					case HatDirection.UpRight:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 1, P_0.sourceHatType);
					case HatDirection.Right:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 2, P_0.sourceHatType);
					case HatDirection.DownRight:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 3, P_0.sourceHatType);
					case HatDirection.Down:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 4, P_0.sourceHatType);
					case HatDirection.DownLeft:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 5, P_0.sourceHatType);
					case HatDirection.Left:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 6, P_0.sourceHatType);
					case HatDirection.UpLeft:
						return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 7, P_0.sourceHatType);
					default:
						num = -380157886;
						continue;
					}
					goto IL_00bf;
				}
				num = -380157879;
				continue;
				IL_02c3:
				if (num7 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num6 < 0f)
					{
						return 0f;
					}
				}
				else if (num6 > 0f)
				{
					num = -380157884;
					continue;
				}
				return num7;
				IL_04ee:
				int num13;
				if (!SphXEVFIXUzhWZMGZUyIbdOXoiY(customCalculationSourceData[num3], out num5))
				{
					num = -380157877;
					num13 = num;
				}
				else
				{
					num = -380157878;
					num13 = num;
				}
			}
			goto IL_000b;
			IL_000b:
			num = -380157870;
			goto IL_0010;
		}

		private float lmyenCPLmUeYnxIapmEbpOtJtXT(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float eGcOhXofWxIUvicLZONhRAcJxsD(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (VjkWjnwoPItHtAfScAsiHywgzcu.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500;
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1427775050;
				while (true)
				{
					switch (num2 ^ 0x551A1E4F)
					{
					case 0:
						break;
					case 6:
						num4 = 27000;
						num2 = 1427775053;
						continue;
					case 3:
						num2 = 1427775054;
						continue;
					case 2:
						num5 = 9000;
						num2 = 1427775054;
						continue;
					case 1:
						if (P_1 == 0 && P_0 > num4)
						{
							P_0 -= 36000;
							num2 = 1427775051;
							continue;
						}
						goto default;
					case 5:
						num3 = num * P_1;
						if (P_2 == HatType.EightWay && P_0 != num3)
						{
							return 0f;
						}
						if (P_2 == HatType.EightWay)
						{
							num4 = 31500;
							num5 = 4500;
							num2 = 1427775052;
							continue;
						}
						goto case 6;
					default:
						if (P_0 < num3 + num5 && P_0 > num3 - num5)
						{
							return 1f;
						}
						return 0f;
					}
					break;
				}
			}
		}

		private float zGynLZPNrxQpghHyIZzAUIHYsnd(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				goto IL_000d;
			}
			int num;
			if (P_0 > 0)
			{
				num = 945913315;
				goto IL_0012;
			}
			goto IL_0077;
			IL_0069:
			if (P_0 < 18000)
			{
				return 1f;
			}
			goto IL_0077;
			IL_0077:
			if (P_0 > 18000)
			{
				num = 945913317;
				goto IL_0012;
			}
			return 0f;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x38617DE3)
				{
				case 5:
					break;
				case 4:
					if (P_0 <= 27000)
					{
						goto IL_0043;
					}
					goto case 2;
				case 1:
					return -1f;
				case 0:
					goto IL_0069;
				case 2:
					return 1f;
				case 3:
					goto IL_009e;
				default:
					return -1f;
				}
				break;
				IL_009e:
				if (P_0 > 9000)
				{
					num = 945913314;
					continue;
				}
				goto IL_0058;
				IL_0058:
				return 0f;
				IL_0043:
				if (P_0 < 9000)
				{
					num = 945913313;
					continue;
				}
				if (P_0 < 27000)
				{
					num = 945913312;
					continue;
				}
				goto IL_0058;
			}
			goto IL_000d;
			IL_000d:
			num = 945913319;
			goto IL_0012;
		}

		private bool nkiUDWmqkoBdSdpkwhGLjZgLKfrF(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			int sourceButton = default(int);
			while (true)
			{
				int num = -1551827711;
				while (true)
				{
					switch (num ^ -1551827707)
					{
					case 0:
						break;
					case 4:
					{
						if (P_0.sourceType != 0)
						{
							num = -1551827708;
							continue;
						}
						sourceButton = P_0.sourceButton;
						int num2;
						if (sourceButton < 0)
						{
							num = -1551827705;
							num2 = num;
						}
						else
						{
							num = -1551827706;
							num2 = num;
						}
						continue;
					}
					case 1:
						return false;
					case 3:
						if (sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
						{
							if (sourceButton >= 256)
							{
								num = -1551827705;
								continue;
							}
							P_2 = P_1[sourceButton];
							return true;
						}
						goto default;
					default:
						return false;
					}
					break;
				}
			}
		}

		private bool SphXEVFIXUzhWZMGZUyIbdOXoiY(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis == 0)
			{
				goto IL_001a;
			}
			P_1 = MnqkSgUruMGpGEncQArrqhjEHzFC((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
			AxisRange sourceAxisRange = P_0.sourceAxisRange;
			int num = -515175008;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				int num3;
				switch (num ^ -515174998)
				{
				case 0:
					break;
				case 1:
					return false;
				case 10:
					switch (sourceAxisRange)
					{
					case AxisRange.Positive:
						goto IL_011f;
					case AxisRange.Negative:
						goto IL_0195;
					}
					num = -515174995;
					continue;
				case 6:
					P_1 = 0f;
					num = -515174995;
					continue;
				case 2:
					P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
					num = -515175006;
					continue;
				case 4:
					if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
						num = -515175006;
						continue;
					}
					goto default;
				case 5:
					goto IL_011f;
				case 7:
					if (P_0.axisCalibrationType == AxisCalibrationType.Default)
					{
						P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
						num = -515175006;
						continue;
					}
					goto case 3;
				case 3:
				{
					int num2;
					if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
					{
						num = -515175000;
						num2 = num;
					}
					else
					{
						num = -515174994;
						num2 = num;
					}
					continue;
				}
				case 9:
					goto IL_0195;
				default:
					{
						return true;
					}
					IL_011f:
					if (P_1 < 0f)
					{
						P_1 = 0f;
						num = -515174995;
						continue;
					}
					goto case 7;
					IL_0195:
					if (P_1 <= 0f)
					{
						num = -515174995;
						num3 = num;
					}
					else
					{
						num = -515174996;
						num3 = num;
					}
					continue;
				}
				break;
			}
			goto IL_001a;
			IL_001a:
			num = -515174997;
			goto IL_001f;
		}

		private ControlDeviceType aMVagricxyfLWFIGSalBSkUrBQEe(DeviceType P_0)
		{
			if (P_0 == DeviceType.Keyboard)
			{
				goto IL_0004;
			}
			if (P_0 == DeviceType.Joystick)
			{
				return ControlDeviceType.PuCbofQgRbFngIhqGEvCTItySLuC;
			}
			if (P_0 == DeviceType.Gamepad)
			{
				return ControlDeviceType.OjRdrXVzVQaGEGzhFLzNjhrLLBZ;
			}
			if (P_0 == DeviceType.Mouse)
			{
				return ControlDeviceType.nLYuKjOBqUkoTONDQzckmzvJOpb;
			}
			int num;
			if (P_0 == DeviceType.MultiAxisController)
			{
				num = -1200399672;
				goto IL_0009;
			}
			return ControlDeviceType.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
			IL_0004:
			num = -1200399669;
			goto IL_0009;
			IL_0009:
			switch (num ^ -1200399670)
			{
			case 0:
				break;
			case 1:
				return ControlDeviceType.GHCARZcZuTQFTJwhHaaINSEOYrk;
			default:
				return ControlDeviceType.PuCbofQgRbFngIhqGEvCTItySLuC;
			}
			goto IL_0004;
		}

		private void HXUZKfgGQxQhzyngFLRJbOoVdRHe(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			while (true)
			{
				ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] = qxWPxytPBDjmFZzTDLfJlSdWAYo(P_0, P_2, P_3);
				if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
				{
					break;
				}
				int num;
				int num2;
				if (ZRzHEnKZrARTmYSqzudcOoQkFLn[P_1] == 0f)
				{
					num = 1212936616;
					num2 = num;
				}
				else
				{
					num = 1212936617;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x484BF1AA)
					{
					case 0:
						num = 1212936619;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
						num = 1212936616;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void yGkMJBwnMntcRGbKyrjKgnsUCud(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= pIAPquXHYXQpPJRbLVGwvBFcXgk)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1] = CYtIlCmYfBZnLABuBgaWWLtsoSm(P_0, P_2, P_3);
				int num;
				int num2;
				if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
				{
					num = 1510148022;
					num2 = num;
				}
				else
				{
					num = 1510148020;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5A0307B5)
					{
					case 0:
						num = 1510148023;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						if (vqZyMIbiZNaMpemrDPhgsXmGAKrY[P_1] != 0f)
						{
							VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
							num = 1510148022;
							continue;
						}
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private float qxWPxytPBDjmFZzTDLfJlSdWAYo(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			int sourceAxis = default(int);
			if (P_0.sourceType == 1)
			{
				sourceAxis = P_0.sourceAxis;
				goto IL_0013;
			}
			int sourceButton = default(int);
			int num;
			if (P_0.sourceType == 0)
			{
				sourceButton = P_0.sourceButton;
				int num2;
				if (sourceButton < 0)
				{
					num = -406471166;
					num2 = num;
				}
				else
				{
					num = -406471154;
					num2 = num;
				}
			}
			else
			{
				if (P_0.sourceType != 2)
				{
					return 0f;
				}
				num = -406471157;
			}
			goto IL_0018;
			IL_0013:
			num = -406471163;
			goto IL_0018;
			IL_0018:
			float result = default(float);
			float num3 = default(float);
			int sourceHat = default(int);
			int num5 = default(int);
			bool flag = default(bool);
			while (true)
			{
				switch (num ^ -406471153)
				{
				case 0:
					break;
				case 9:
					result = -1f;
					num = -406471156;
					continue;
				case 6:
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						num = -406471167;
						continue;
					}
					if (num3 > 0f)
					{
						return 0f;
					}
					goto IL_00da;
				case 16:
					if (sourceHat >= 0 && sourceHat < ByBfmUYbKOERmAjkpxrmtOAORFt)
					{
						if (sourceHat >= 4)
						{
							num = -406471158;
							continue;
						}
						num5 = P_2[sourceHat];
						num = -406471161;
						continue;
					}
					goto case 5;
				case 15:
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						if (num3 < 0f)
						{
							return 0f;
						}
					}
					else if (num3 > 0f)
					{
						return 0f;
					}
					goto IL_00da;
				case 13:
					return 0f;
				case 2:
					return 0f;
				case 3:
					return result;
				case 1:
					if (sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
					{
						if (sourceButton < 256)
						{
							flag = P_1[sourceButton];
							num = -406471164;
						}
						else
						{
							num = -406471166;
						}
						continue;
					}
					goto case 13;
				case 10:
				{
					int num4;
					if (sourceAxis < 0)
					{
						num = -406471155;
						num4 = num;
					}
					else
					{
						num = -406471160;
						num4 = num;
					}
					continue;
				}
				case 11:
					if (!flag)
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = -406471156;
						continue;
					}
					goto case 9;
				case 8:
					if (num5 < 0)
					{
						return 0f;
					}
					if (P_0.sourceHatDirection == AxisDirection.Horizontal)
					{
						num3 = zGynLZPNrxQpghHyIZzAUIHYsnd(num5, AxisDirection.Horizontal);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							num = -406471159;
							continue;
						}
					}
					else
					{
						num3 = zGynLZPNrxQpghHyIZzAUIHYsnd(num5, AxisDirection.Vertical);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							num = -406471168;
							continue;
						}
					}
					goto IL_00da;
				case 4:
					sourceHat = P_0.sourceHat;
					num = -406471137;
					continue;
				case 14:
					if (num3 < 0f)
					{
						return 0f;
					}
					goto IL_00da;
				case 7:
					if (sourceAxis < jHaYXdTXWAJNlfIRTMsRGaqNBpK)
					{
						if (sourceAxis < 56)
						{
							return qxWPxytPBDjmFZzTDLfJlSdWAYo(sourceAxis);
						}
						num = -406471155;
						continue;
					}
					goto case 2;
				case 5:
					return 0f;
				default:
					{
						return num3;
					}
					IL_00da:
					if (P_0.invert)
					{
						num3 *= -1f;
						num = -406471165;
						continue;
					}
					goto default;
				}
				break;
			}
			goto IL_0013;
		}

		private float qxWPxytPBDjmFZzTDLfJlSdWAYo(int P_0)
		{
			return (XdgIhjPOvYiPrAnuSuMBIFLQhh as iPRBYFToZLwSXJOnSrvnRmHihEH).MnqkSgUruMGpGEncQArrqhjEHzFC(P_0);
		}

		private float CYtIlCmYfBZnLABuBgaWWLtsoSm(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton >= 0 && sourceButton < qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					if (sourceButton < 256)
					{
						if (!P_1[sourceButton])
						{
							return 0f;
						}
						return 1f;
					}
					goto IL_0030;
				}
				goto IL_00d1;
			}
			int num;
			if (P_0.sourceType == 1)
			{
				num = -758368526;
			}
			else
			{
				if (P_0.sourceType != 2)
				{
					goto IL_0240;
				}
				num = -758368514;
			}
			goto IL_0035;
			IL_0240:
			return 0f;
			IL_0077:
			int sourceHat = default(int);
			switch (P_0.sourceHatDirection)
			{
			case HatDirection.Up:
				break;
			case HatDirection.UpRight:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 1, P_0.sourceHatType);
			case HatDirection.Right:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 2, P_0.sourceHatType);
			case HatDirection.DownRight:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 3, P_0.sourceHatType);
			case HatDirection.Down:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 4, P_0.sourceHatType);
			case HatDirection.DownLeft:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 5, P_0.sourceHatType);
			case HatDirection.Left:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 6, P_0.sourceHatType);
			case HatDirection.UpLeft:
				return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 7, P_0.sourceHatType);
			default:
				goto IL_0240;
			}
			goto IL_01b8;
			IL_00d1:
			return 0f;
			IL_00fb:
			float num2 = default(float);
			if (MathTools.Abs(num2) <= P_0.axisDeadZone)
			{
				return 0f;
			}
			if (P_0.sourceAxisPole == Pole.Positive)
			{
				if (num2 < 0f)
				{
					return 0f;
				}
			}
			else if (num2 > 0f)
			{
				return 0f;
			}
			return 1f;
			IL_0035:
			int sourceAxis = default(int);
			while (true)
			{
				switch (num ^ -758368520)
				{
				case 0:
					break;
				case 2:
					return 0f;
				case 9:
					goto IL_00b2;
				case 10:
					sourceAxis = P_0.sourceAxis;
					num = -758368519;
					continue;
				case 7:
					goto IL_00d1;
				case 4:
					goto IL_00fb;
				case 8:
					return 0f;
				case 6:
					sourceHat = P_0.sourceHat;
					num = -758368515;
					continue;
				case 1:
					if (sourceAxis < 0 || sourceAxis >= jHaYXdTXWAJNlfIRTMsRGaqNBpK)
					{
						goto case 8;
					}
					goto IL_0185;
				case 5:
					if (sourceHat < 0)
					{
						goto case 2;
					}
					goto IL_019b;
				default:
					goto IL_01b8;
				}
				break;
				IL_019b:
				int num3;
				if (sourceHat >= ByBfmUYbKOERmAjkpxrmtOAORFt)
				{
					num = -758368518;
					num3 = num;
				}
				else
				{
					num = -758368527;
					num3 = num;
				}
				continue;
				IL_0185:
				if (sourceAxis < 56)
				{
					num2 = qxWPxytPBDjmFZzTDLfJlSdWAYo(sourceAxis);
					num = -758368516;
				}
				else
				{
					num = -758368528;
				}
				continue;
				IL_00b2:
				if (sourceHat >= 4)
				{
					num = -758368518;
					continue;
				}
				goto IL_0077;
			}
			goto IL_0030;
			IL_01b8:
			return eGcOhXofWxIUvicLZONhRAcJxsD(P_2[sourceHat], 0, P_0.sourceHatType);
			IL_0030:
			num = -758368513;
			goto IL_0035;
		}

		private bool MkdUbgZcmdOBTUrbDnrCtXxQGgY(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			int num = 4500;
			int num6 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2 = -267010029;
				while (true)
				{
					switch (num2 ^ -267010030)
					{
					case 6:
						break;
					case 5:
						P_0 -= 36000;
						num2 = -267010022;
						continue;
					case 4:
					{
						int num7;
						if (P_0 > num6)
						{
							num2 = -267010025;
							num7 = num2;
						}
						else
						{
							num2 = -267010022;
							num7 = num2;
						}
						continue;
					}
					case 1:
						num3 = num * P_1;
						num2 = -267010027;
						continue;
					case 0:
						num6 = 27000;
						num4 = 9000;
						num2 = -267010031;
						continue;
					case 3:
					{
						int num5;
						if (P_1 == 0)
						{
							num2 = -267010026;
							num5 = num2;
						}
						else
						{
							num2 = -267010022;
							num5 = num2;
						}
						continue;
					}
					case 7:
						if (P_2 == HatType.EightWay && P_0 != num3)
						{
							num2 = -267010032;
							continue;
						}
						if (P_2 == HatType.EightWay)
						{
							num6 = 31500;
							num4 = 4500;
							num2 = -267010031;
							continue;
						}
						goto case 0;
					case 2:
						return false;
					default:
						if (P_0 < num3 + num4 && P_0 > num3 - num4)
						{
							return true;
						}
						return false;
					}
					break;
				}
			}
		}

		private float LtBbJWUeZObcsVezVLANJsiOEKW(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				goto IL_0004;
			}
			int num;
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 <= 27000)
				{
					if (P_0 >= 9000)
					{
						if (P_0 >= 27000)
						{
							goto IL_0074;
						}
						num = 1907575266;
					}
					else
					{
						num = 1907575267;
					}
					goto IL_0009;
				}
				goto IL_0039;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
			IL_0074:
			return 0f;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x71B349E3)
				{
				case 2:
					break;
				case 1:
					goto IL_002a;
				case 0:
					goto IL_0039;
				case 3:
					return 0f;
				default:
					return -1f;
				}
				break;
				IL_002a:
				if (P_0 > 9000)
				{
					num = 1907575271;
					continue;
				}
				goto IL_0074;
			}
			goto IL_0004;
			IL_0004:
			num = 1907575264;
			goto IL_0009;
			IL_0039:
			return 1f;
		}

		private void HUcWpSluxhNdngRwNRiLQuUWiQb()
		{
			VjkWjnwoPItHtAfScAsiHywgzcu = lzXAqTcTNwGXhyoMQqetZTTNJGjM(XNhjnTKDnPIWYdspfSxvjnotCFBk());
			while (true)
			{
				int num = -1286343488;
				while (true)
				{
					switch (num ^ -1286343485)
					{
					case 0:
						break;
					case 3:
						if (VjkWjnwoPItHtAfScAsiHywgzcu == null)
						{
							goto IL_0041;
						}
						goto default;
					case 2:
						return;
					default:
						wqHuqGsJmegTaHkGmUKGpvcrfRfB = VjkWjnwoPItHtAfScAsiHywgzcu.axisCount;
						pIAPquXHYXQpPJRbLVGwvBFcXgk = VjkWjnwoPItHtAfScAsiHywgzcu.buttonCount;
						return;
					}
					break;
					IL_0041:
					Logger.LogError("Default hardware map not found!");
					num = -1286343487;
				}
			}
		}

		private string VUjBBLGxogalucNHZqXfeETbZbu()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.RawInput, (NxfPDLDjjkkAByWVYHnViSDRJzU && !string.IsNullOrEmpty(ZODLrlcqYgYcHKPIQwZOreOIaYF)) ? ZODLrlcqYgYcHKPIQwZOreOIaYF : AOVTbdgjQpuvVXuOzJgmsvYOWec, fSuJoZmgBMnbZWJgvPaTNrIBkjq, qSJYeLiyjfTRCcMnvDOwuKWJouA));
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			while (true)
			{
				int num = -1023224441;
				while (true)
				{
					switch (num ^ -1023224446)
					{
					case 4:
						break;
					default:
						return;
					case 5:
						P_0.inputSource = FvpbthwqHsVfdlOKqyTxjSLrkXP.InputSource;
						P_0.deviceType = aMVagricxyfLWFIGSalBSkUrBQEe(PKcpZyZqpXABDjaGPUDXDEPgbQK);
						num = -1023224447;
						continue;
					case 1:
						P_0.hw_supportsVibration = mqRCOGhpUhuJIDFwlHJQROPEFMrC;
						P_0.hw_localVibrationMotorCount = bELhEeAWQmtfFIrLTgNSpwrpFSQN;
						num = -1023224446;
						continue;
					case 3:
						P_0.hardwareIdentifier = VUjBBLGxogalucNHZqXfeETbZbu();
						P_0.hardwareAxisCount = jHaYXdTXWAJNlfIRTMsRGaqNBpK;
						P_0.hardwareButtonCount = qOBHYZBCAkYYTJoRDdsZoTyTELA;
						P_0.hardwareHatCount = ByBfmUYbKOERmAjkpxrmtOAORFt;
						P_0.hw_productName = AOVTbdgjQpuvVXuOzJgmsvYOWec;
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_vendorId = DqYErgUjFMUHxVkmrXzgfOxtEsC;
						P_0.hw_productId = fSuJoZmgBMnbZWJgvPaTNrIBkjq;
						P_0.hw_pidVid = new PidVid(qSJYeLiyjfTRCcMnvDOwuKWJouA);
						P_0.hw_isBluetoothDevice = NxfPDLDjjkkAByWVYHnViSDRJzU;
						P_0.hw_bluetoothDeviceName = ZODLrlcqYgYcHKPIQwZOreOIaYF;
						num = -1023224445;
						continue;
					case 0:
						P_0.definitionMatchTag = FvpbthwqHsVfdlOKqyTxjSLrkXP.HWDefinitionMatchTag;
						num = -1023224448;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedController P_0)
		{
			qHHYDYGCGqOhLRBRJCdFmLOJpwE((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = VjkWjnwoPItHtAfScAsiHywgzcu.ToGameHardwareControllerMap();
			P_0.instanceName = mHIfxFeuzrrprIjNQQttDcAWoJX;
			P_0.productName = AOVTbdgjQpuvVXuOzJgmsvYOWec;
			while (true)
			{
				int num = -186169152;
				while (true)
				{
					switch (num ^ -186169149)
					{
					case 0:
						break;
					case 3:
						P_0.isXInputDevice = KqmajqZRajQeRJHxvHBZhqVPgsd;
						P_0.axisCount = wqHuqGsJmegTaHkGmUKGpvcrfRfB;
						P_0.buttonCount = pIAPquXHYXQpPJRbLVGwvBFcXgk;
						P_0.isButtonPressureSensitive = new bool[pIAPquXHYXQpPJRbLVGwvBFcXgk];
						Array.Copy(qeGbNsgsdQFGjtYzwhQQpCumZFP, P_0.isButtonPressureSensitive, pIAPquXHYXQpPJRbLVGwvBFcXgk);
						num = -186169151;
						continue;
					case 2:
						P_0.unknownControllerHats = BvrTDdaPBgTbGiflYTIoeNsJBMs();
						num = -186169150;
						continue;
					default:
						P_0.controllerTypeGuid = REezjTFCollnzcnDXouNnLNDkjk;
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		private void WGBBbflLjdHWFEHXzjqWltFbVJT()
		{
			int num = 0;
			int num4 = default(int);
			while (true)
			{
				int num2;
				int num3;
				if (num < pIAPquXHYXQpPJRbLVGwvBFcXgk)
				{
					num2 = 735034579;
					num3 = num2;
				}
				else
				{
					num2 = 735034581;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2BCFBCD6)
					{
					case 0:
						num2 = 735034579;
						continue;
					case 2:
						ZRzHEnKZrARTmYSqzudcOoQkFLn[num4] = 0f;
						num4++;
						num2 = 735034583;
						continue;
					case 3:
						num4 = 0;
						num2 = 735034583;
						continue;
					case 4:
						break;
					case 5:
						vqZyMIbiZNaMpemrDPhgsXmGAKrY[num] = 0f;
						num++;
						num2 = 735034578;
						continue;
					default:
						if (num4 >= wqHuqGsJmegTaHkGmUKGpvcrfRfB)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private UnknownControllerHat[] BvrTDdaPBgTbGiflYTIoeNsJBMs()
		{
			if (!yRialUFBmVuFTOVrRxRadMBTRymj)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int[] array2 = default(int[]);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -235402358;
				while (true)
				{
					switch (num ^ -235402366)
					{
					case 0:
						break;
					case 1:
					{
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num2] = new UnknownControllerHat(buttons);
						num2++;
						num = -235402364;
						continue;
					}
					case 6:
					{
						int num4;
						if (num2 >= 2)
						{
							num = -235402367;
							num4 = num;
						}
						else
						{
							num = -235402363;
							num4 = num;
						}
						continue;
					}
					case 2:
						array2[0] = num3;
						array2[1] = num3 + 1;
						num = -235402362;
						continue;
					case 4:
						array2[2] = num3 + 2;
						array2[3] = num3 + 3;
						array2[4] = num3 + 4;
						array2[5] = num3 + 5;
						array2[6] = num3 + 6;
						array2[7] = num3 + 7;
						num = -235402365;
						continue;
					case 7:
						num3 = 128 + num2 * 8;
						num = -235402361;
						continue;
					case 8:
						num2 = 0;
						num = -235402364;
						continue;
					case 5:
						array2 = new int[8];
						num = -235402368;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public void HtJdxRxaGggkmaMTSWUpHqjZLDV()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
			GC.SuppressFinalize(this);
		}

		~zYKlnVPIidhlEGjgyEmNKwdfoPXo()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
		}

		protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
		{
			if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			}
		}

		public static int KIbRqtvxhdlGNZbGlQYeWDzVgXY(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, zYKlnVPIidhlEGjgyEmNKwdfoPXo P_1)
		{
			if (P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD < P_1.CcAaBYTnhTzbmiXXmdIizsUxQeD)
			{
				goto IL_000e;
			}
			int num;
			if (P_0.CcAaBYTnhTzbmiXXmdIizsUxQeD > P_1.CcAaBYTnhTzbmiXXmdIizsUxQeD)
			{
				num = -461277475;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -461277476;
			goto IL_0013;
			IL_0013:
			switch (num ^ -461277475)
			{
			case 2:
				break;
			case 1:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}

		public static int YGXDKFCxtZualSpgecrIGagUJoxD(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, zYKlnVPIidhlEGjgyEmNKwdfoPXo P_1)
		{
			if (P_0.ySxHACCmrqwNquIhkRqoFdufNKj < P_1.ySxHACCmrqwNquIhkRqoFdufNKj)
			{
				return -1;
			}
			if (P_0.ySxHACCmrqwNquIhkRqoFdufNKj > P_1.ySxHACCmrqwNquIhkRqoFdufNKj)
			{
				return 1;
			}
			return 0;
		}
	}

	private class UwwjQFGBBMEmsVSwhFMwmrVrhtF
	{
		public enum SPJwSVFuFCjLQrdyDxCVxDwwJlu
		{
			hsqFwVabxTxZDbitiWOUsqWRrjW = 0,
			XSasYkIfXXTIuNYDajUSHAZXtRK = 1
		}

		public class OYSTavsNkFtmKAZpUdLgHuCEopI
		{
			public int InzpRLWBzesgNjVGacynCIMBDnJ;

			public Guid ODZHadYVuHkMcypYWKMRBQtiqnj;

			public Guid CgIVyXGyqTDPaUYRIwDzeLsZOit;

			public int WfZmTofniSsPbHKlehKQdLSahSv;

			public int jHaYXdTXWAJNlfIRTMsRGaqNBpK;

			public int qOBHYZBCAkYYTJoRDdsZoTyTELA;

			public int ByBfmUYbKOERmAjkpxrmtOAORFt;

			public int pIAPquXHYXQpPJRbLVGwvBFcXgk;

			public int wqHuqGsJmegTaHkGmUKGpvcrfRfB;

			public bool YPoHnLSGqzBRZHuYjIENcYxHqTgh;

			public bool CjIOgfYLwvzSovgYNuiXTTvJjBe(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, SPJwSVFuFCjLQrdyDxCVxDwwJlu P_1)
			{
				if (jHaYXdTXWAJNlfIRTMsRGaqNBpK != P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK)
				{
					return false;
				}
				if (qOBHYZBCAkYYTJoRDdsZoTyTELA != P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA)
				{
					return false;
				}
				if (ByBfmUYbKOERmAjkpxrmtOAORFt != P_0.ByBfmUYbKOERmAjkpxrmtOAORFt)
				{
					return false;
				}
				if (pIAPquXHYXQpPJRbLVGwvBFcXgk != P_0.pIAPquXHYXQpPJRbLVGwvBFcXgk)
				{
					return false;
				}
				if (wqHuqGsJmegTaHkGmUKGpvcrfRfB != P_0.wqHuqGsJmegTaHkGmUKGpvcrfRfB)
				{
					return false;
				}
				if (YPoHnLSGqzBRZHuYjIENcYxHqTgh != P_0.hasDriver)
				{
					return false;
				}
				if (P_0.rewiredId == InzpRLWBzesgNjVGacynCIMBDnJ)
				{
					return true;
				}
				switch (P_1)
				{
				case SPJwSVFuFCjLQrdyDxCVxDwwJlu.hsqFwVabxTxZDbitiWOUsqWRrjW:
					return ODZHadYVuHkMcypYWKMRBQtiqnj == P_0.instanceGuid;
				case SPJwSVFuFCjLQrdyDxCVxDwwJlu.XSasYkIfXXTIuNYDajUSHAZXtRK:
					return CgIVyXGyqTDPaUYRIwDzeLsZOit == P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit;
				default:
					throw new NotImplementedException();
				}
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				object[] array = new object[4];
				object[] array8 = default(object[]);
				object[] array4 = default(object[]);
				object obj2 = default(object);
				object[] array6 = default(object[]);
				object[] array2 = default(object[]);
				object obj5 = default(object);
				object obj6 = default(object);
				object[] array5 = default(object[]);
				object[] array7 = default(object[]);
				object obj7 = default(object);
				object obj4 = default(object);
				object[] array3 = default(object[]);
				while (true)
				{
					int num = 1423366191;
					while (true)
					{
						switch (num ^ 0x54D6D823)
						{
						case 6:
							break;
						case 9:
							array8 = new object[4];
							num = 1423366180;
							continue;
						case 19:
							array4[1] = "lastInputManagerId = ";
							num = 1423366179;
							continue;
						case 14:
							text = string.Concat(array);
							obj2 = text;
							num = 1423366193;
							continue;
						case 5:
							array8[2] = CgIVyXGyqTDPaUYRIwDzeLsZOit;
							array8[3] = "\n";
							text = string.Concat(array8);
							num = 1423366176;
							continue;
						case 16:
						{
							text = string.Concat(array6);
							object obj10 = text;
							array2 = new object[4] { obj10, null, null, null };
							num = 1423366184;
							continue;
						}
						case 10:
						{
							text = string.Concat(obj5, "hardwareAxisCount = ", jHaYXdTXWAJNlfIRTMsRGaqNBpK, "\n");
							object obj9 = text;
							text = string.Concat(obj9, "hardwareButtonCount = ", qOBHYZBCAkYYTJoRDdsZoTyTELA, "\n");
							obj6 = text;
							array5 = new object[4];
							num = 1423366194;
							continue;
						}
						case 2:
							array7[3] = "\n";
							text = string.Concat(array7);
							obj7 = text;
							array6 = new object[4];
							num = 1423366190;
							continue;
						case 7:
							array8[0] = obj4;
							array8[1] = "typeIdentifierGuid = ";
							num = 1423366182;
							continue;
						case 15:
						{
							array5[2] = ByBfmUYbKOERmAjkpxrmtOAORFt;
							array5[3] = "\n";
							text = string.Concat(array5);
							object obj8 = text;
							array7 = new object[4] { obj8, "gameButtonCount = ", pIAPquXHYXQpPJRbLVGwvBFcXgk, null };
							num = 1423366177;
							continue;
						}
						case 13:
							array6[0] = obj7;
							array6[1] = "gameAxisCount = ";
							array6[2] = wqHuqGsJmegTaHkGmUKGpvcrfRfB;
							array6[3] = "\n";
							num = 1423366195;
							continue;
						case 17:
							array5[0] = obj6;
							array5[1] = "hardwareHatCount = ";
							num = 1423366188;
							continue;
						case 1:
							array3[1] = "instanceGuid = ";
							num = 1423366187;
							continue;
						case 4:
							obj5 = text;
							num = 1423366185;
							continue;
						case 8:
							array3[2] = ODZHadYVuHkMcypYWKMRBQtiqnj;
							array3[3] = "\n";
							text = string.Concat(array3);
							obj4 = text;
							num = 1423366186;
							continue;
						case 0:
							array4[2] = WfZmTofniSsPbHKlehKQdLSahSv;
							array4[3] = "\n";
							text = string.Concat(array4);
							num = 1423366183;
							continue;
						case 3:
						{
							object obj3 = text;
							array4 = new object[4] { obj3, null, null, null };
							num = 1423366192;
							continue;
						}
						case 18:
							array3 = new object[4] { obj2, null, null, null };
							num = 1423366178;
							continue;
						case 12:
							array[0] = obj;
							array[1] = "rewiredId = ";
							array[2] = InzpRLWBzesgNjVGacynCIMBDnJ;
							array[3] = "\n";
							num = 1423366189;
							continue;
						default:
							array2[1] = "hasDriver = ";
							array2[2] = YPoHnLSGqzBRZHuYjIENcYxHqTgh;
							array2[3] = "\n";
							return string.Concat(array2);
						}
						break;
					}
				}
			}
		}

		private List<OYSTavsNkFtmKAZpUdLgHuCEopI> hrPXQonAeODgYLqpGRybHDStLgN;

		public UwwjQFGBBMEmsVSwhFMwmrVrhtF()
		{
			while (true)
			{
				int num = -396751660;
				while (true)
				{
					switch (num ^ -396751658)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					hrPXQonAeODgYLqpGRybHDStLgN = new List<OYSTavsNkFtmKAZpUdLgHuCEopI>();
					num = -396751657;
				}
			}
		}

		public void twVDKshQikIuavgehoSXWHaPlJad(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
				int num = 0;
				int num2 = -1928586243;
				while (true)
				{
					switch (num2 ^ -1928586241)
					{
					case 7:
						num2 = -1928586242;
						continue;
					case 1:
						break;
					case 6:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, SPJwSVFuFCjLQrdyDxCVxDwwJlu.hsqFwVabxTxZDbitiWOUsqWRrjW))
						{
							hrPXQonAeODgYLqpGRybHDStLgN[num].InzpRLWBzesgNjVGacynCIMBDnJ = P_0.rewiredId;
							hrPXQonAeODgYLqpGRybHDStLgN[num].ODZHadYVuHkMcypYWKMRBQtiqnj = P_0.instanceGuid;
							hrPXQonAeODgYLqpGRybHDStLgN[num].CgIVyXGyqTDPaUYRIwDzeLsZOit = P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit;
							hrPXQonAeODgYLqpGRybHDStLgN[num].WfZmTofniSsPbHKlehKQdLSahSv = P_0.inputManagerId;
							hrPXQonAeODgYLqpGRybHDStLgN[num].jHaYXdTXWAJNlfIRTMsRGaqNBpK = P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK;
							hrPXQonAeODgYLqpGRybHDStLgN[num].qOBHYZBCAkYYTJoRDdsZoTyTELA = P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA;
							hrPXQonAeODgYLqpGRybHDStLgN[num].ByBfmUYbKOERmAjkpxrmtOAORFt = P_0.ByBfmUYbKOERmAjkpxrmtOAORFt;
							hrPXQonAeODgYLqpGRybHDStLgN[num].pIAPquXHYXQpPJRbLVGwvBFcXgk = P_0.pIAPquXHYXQpPJRbLVGwvBFcXgk;
							hrPXQonAeODgYLqpGRybHDStLgN[num].wqHuqGsJmegTaHkGmUKGpvcrfRfB = P_0.wqHuqGsJmegTaHkGmUKGpvcrfRfB;
							num2 = -1928586249;
							continue;
						}
						goto case 5;
					case 0:
					{
						int num3;
						if (num >= count)
						{
							num2 = -1928586245;
							num3 = num2;
						}
						else
						{
							num2 = -1928586247;
							num3 = num2;
						}
						continue;
					}
					case 8:
						hrPXQonAeODgYLqpGRybHDStLgN[num].YPoHnLSGqzBRZHuYjIENcYxHqTgh = P_0.hasDriver;
						HyJvDRidjTBxfFeRuBIqVHqhepWi(P_0.rewiredId, P_0.instanceGuid, num);
						return;
					case 5:
						num++;
						num2 = -1928586241;
						continue;
					case 4:
						hrPXQonAeODgYLqpGRybHDStLgN.Add(new OYSTavsNkFtmKAZpUdLgHuCEopI
						{
							InzpRLWBzesgNjVGacynCIMBDnJ = P_0.rewiredId,
							ODZHadYVuHkMcypYWKMRBQtiqnj = P_0.instanceGuid,
							CgIVyXGyqTDPaUYRIwDzeLsZOit = P_0.CgIVyXGyqTDPaUYRIwDzeLsZOit,
							WfZmTofniSsPbHKlehKQdLSahSv = P_0.inputManagerId,
							jHaYXdTXWAJNlfIRTMsRGaqNBpK = P_0.jHaYXdTXWAJNlfIRTMsRGaqNBpK,
							qOBHYZBCAkYYTJoRDdsZoTyTELA = P_0.qOBHYZBCAkYYTJoRDdsZoTyTELA,
							ByBfmUYbKOERmAjkpxrmtOAORFt = P_0.ByBfmUYbKOERmAjkpxrmtOAORFt,
							pIAPquXHYXQpPJRbLVGwvBFcXgk = P_0.pIAPquXHYXQpPJRbLVGwvBFcXgk,
							wqHuqGsJmegTaHkGmUKGpvcrfRfB = P_0.wqHuqGsJmegTaHkGmUKGpvcrfRfB,
							YPoHnLSGqzBRZHuYjIENcYxHqTgh = P_0.hasDriver
						});
						num2 = -1928586244;
						continue;
					case 2:
						num2 = -1928586241;
						continue;
					default:
						HyJvDRidjTBxfFeRuBIqVHqhepWi(P_0.rewiredId, P_0.instanceGuid, hrPXQonAeODgYLqpGRybHDStLgN.Count - 1);
						return;
					}
					break;
				}
			}
		}

		public bool WQGtezfxeyeFNomyFPdWcsNQBHr(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, SPJwSVFuFCjLQrdyDxCVxDwwJlu P_1)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (hrPXQonAeODgYLqpGRybHDStLgN[num].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, P_1))
					{
						num2 = -501788584;
					}
					else
					{
						num++;
						num2 = -501788583;
					}
					while (true)
					{
						switch (num2 ^ -501788583)
						{
						case 3:
							num2 = -501788581;
							continue;
						case 2:
							break;
						case 1:
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

		public OYSTavsNkFtmKAZpUdLgHuCEopI SNyQPMtxIqmpckDGNaILQiYNCbXF(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, SPJwSVFuFCjLQrdyDxCVxDwwJlu P_1)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1203099876;
				while (true)
				{
					switch (num ^ 0x47B5D8E5)
					{
					case 2:
						break;
					case 1:
						num2 = 0;
						num = 1203099872;
						continue;
					case 5:
					{
						int num3;
						if (num2 >= count)
						{
							num = 1203099877;
							num3 = num;
						}
						else
						{
							num = 1203099878;
							num3 = num;
						}
						continue;
					}
					case 4:
						return hrPXQonAeODgYLqpGRybHDStLgN[num2];
					case 3:
						if (!hrPXQonAeODgYLqpGRybHDStLgN[num2].CjIOgfYLwvzSovgYNuiXTTvJjBe(P_0, P_1))
						{
							num2++;
							num = 1203099872;
						}
						else
						{
							num = 1203099873;
						}
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}

		private void HyJvDRidjTBxfFeRuBIqVHqhepWi(int P_0, Guid P_1, int P_2)
		{
			int num = hrPXQonAeODgYLqpGRybHDStLgN.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					int num2;
					if (num != P_2)
					{
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].InzpRLWBzesgNjVGacynCIMBDnJ != P_0)
						{
							int num3;
							if (!(hrPXQonAeODgYLqpGRybHDStLgN[num].ODZHadYVuHkMcypYWKMRBQtiqnj == P_1))
							{
								num2 = -1610432209;
								num3 = num2;
							}
							else
							{
								num2 = -1610432211;
								num3 = num2;
							}
							goto IL_0018;
						}
						goto IL_007b;
					}
					goto IL_008e;
					IL_007b:
					hrPXQonAeODgYLqpGRybHDStLgN.RemoveAt(num);
					num2 = -1610432209;
					goto IL_0018;
					IL_008e:
					num--;
					num2 = -1610432215;
					goto IL_0018;
					IL_0018:
					while (true)
					{
						switch (num2 ^ -1610432211)
						{
						case 3:
							num2 = -1610432212;
							continue;
						case 1:
							break;
						case 0:
							goto IL_007b;
						case 2:
							goto IL_008e;
						default:
							goto end_IL_0039;
						}
						break;
					}
					continue;
					end_IL_0039:
					break;
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			object[] array = default(object[]);
			int num2 = default(int);
			while (true)
			{
				int num = -2121294209;
				while (true)
				{
					switch (num ^ -2121294214)
					{
					case 3:
						break;
					case 2:
						num = -2121294210;
						continue;
					case 0:
						text = string.Concat(array);
						num = -2121294212;
						continue;
					case 5:
					{
						object obj2 = text;
						array = new object[4] { obj2, "Joystick records: ", hrPXQonAeODgYLqpGRybHDStLgN.Count, "\n" };
						num = -2121294214;
						continue;
					}
					case 1:
					{
						object obj = text;
						text = string.Concat(obj, "Record ", num2, ":\n");
						text = text + hrPXQonAeODgYLqpGRybHDStLgN[num2].ToString() + "\n\n";
						num2++;
						num = -2121294210;
						continue;
					}
					case 6:
						num2 = 0;
						num = -2121294216;
						continue;
					default:
						if (num2 >= hrPXQonAeODgYLqpGRybHDStLgN.Count)
						{
							return text;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}

	private DyxPIAguqliRStlMaxHqlaZTglf enVoekoLyoporHuwAJgfgZkigNl;

	private List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> AvwfdLjWSYyRUfRbGOqVqadERNGK;

	private int hShdCGGbdfKCwKvzqAgdyZHXxRH;

	private UwwjQFGBBMEmsVSwhFMwmrVrhtF VkhgikRmZCRpwCsFCAHFtklICJTg;

	private bool capIsYRGcjdINxLFChhLiBZbnVUt;

	private TimerRealTime lDrCawWWQwDbNHbrPJXgBBstingI;

	private global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool> ckgHevKWKxxvylqJEuOINRCXDZV;

	private int rzeDVbCNKMajPsSZXPQVQjoxsCZ;

	private global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool> hPZMucJayMaNawJjXSMUyHDwzhD;

	private ConfigVars UKtATHlOcpbLyohLTFgOWGklugI;

	private bool ilRrVwkMgOLwkAAfYNNcVNLgBSS;

	private Action<int, ControllerDataUpdater> YALIvlsEVxFcouIKiMIOBoKrdos;

	private PlatformInputManager YLxisMThRDTgIbPaYfJsjfpWQRp;

	private readonly RPMEArDcusoTOTamCEbKzwFcLDSI EsqysMvalMeuTAeZFflQpCwdcnfD;

	private readonly hKTkpUPnMJRQrUCFJINGfAbSxtx LuXZhDIoVYWJDVRjsBUBdAbUFbk;

	private readonly bool jknBiNnVvBEJUrrzYJXBYRgRbau;

	private readonly bool RixhOtXDbSIOhYkJycehgIXDBbxD;

	private readonly bool iyGFwvImCbxxsRCfTTBNAxyjqRK;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

	private readonly Func<int> sbyIXavKIUtCermoZwGVxaaQFdB;

	public bool useXInput
	{
		set
		{
			ilRrVwkMgOLwkAAfYNNcVNLgBSS = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return hShdCGGbdfKCwKvzqAgdyZHXxRH;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return YLxisMThRDTgIbPaYfJsjfpWQRp;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return enVoekoLyoporHuwAJgfgZkigNl;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.RawInput;
		}
	}

	public ZJlurOepsAQxsfgddlEPRgblxKu(ConfigVars configVars, bool useXInput, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard, bool useCustomDrivers)
	{
		try
		{
			UKtATHlOcpbLyohLTFgOWGklugI = configVars;
			ilRrVwkMgOLwkAAfYNNcVNLgBSS = useXInput;
			lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
			sbyIXavKIUtCermoZwGVxaaQFdB = getNewJoystickId;
			jknBiNnVvBEJUrrzYJXBYRgRbau = handleJoysticks;
			RixhOtXDbSIOhYkJycehgIXDBbxD = handleUnifiedMouse;
			iyGFwvImCbxxsRCfTTBNAxyjqRK = handleUnifiedKeyboard;
			YLxisMThRDTgIbPaYfJsjfpWQRp = this;
			if (handleUnifiedKeyboard)
			{
				LuXZhDIoVYWJDVRjsBUBdAbUFbk = new hKTkpUPnMJRQrUCFJINGfAbSxtx(configVars.updateLoop);
			}
			if (handleUnifiedMouse)
			{
				EsqysMvalMeuTAeZFflQpCwdcnfD = new RPMEArDcusoTOTamCEbKzwFcLDSI(configVars.updateLoop);
			}
			enVoekoLyoporHuwAJgfgZkigNl = new DyxPIAguqliRStlMaxHqlaZTglf(configVars, handleJoysticks, useCustomDrivers, EsqysMvalMeuTAeZFflQpCwdcnfD, LuXZhDIoVYWJDVRjsBUBdAbUFbk);
			YALIvlsEVxFcouIKiMIOBoKrdos = UpdateControllerData;
			ckgHevKWKxxvylqJEuOINRCXDZV = new global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool>(true, enVoekoLyoporHuwAJgfgZkigNl.kmodMVsDsXcZsNFRxGrEkPPKsBl);
			hPZMucJayMaNawJjXSMUyHDwzhD = new global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool>(true, enVoekoLyoporHuwAJgfgZkigNl.IpIBfdAJGcUvYyxWHBACBnDwGIP);
		}
		catch (Exception ex)
		{
			OnDestroy();
			throw ex;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return;
		}
		VkhgikRmZCRpwCsFCAHFtklICJTg = new UwwjQFGBBMEmsVSwhFMwmrVrhtF();
		lDrCawWWQwDbNHbrPJXgBBstingI = new TimerRealTime(1f);
		while (true)
		{
			int num = -407596547;
			while (true)
			{
				switch (num ^ -407596548)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0041;
				case 2:
					return;
				}
				break;
				IL_0041:
				lDrCawWWQwDbNHbrPJXgBBstingI.Start();
				ExvTLcrmxZuVwMPPwmgKNOkIvzX();
				num = -407596546;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			goto IL_0008;
		}
		goto IL_0058;
		IL_0008:
		int num = 844213514;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x3251AD08)
			{
			case 8:
				break;
			default:
				return;
			case 3:
				LuXZhDIoVYWJDVRjsBUBdAbUFbk.EhlPnfprjfkehAbDLrDcQKRlXmc(updateLoop);
				num = 844213518;
				continue;
			case 1:
				goto IL_0058;
			case 9:
				goto IL_0072;
			case 0:
				goto IL_009c;
			case 7:
				enVoekoLyoporHuwAJgfgZkigNl.UpdateDevices(updateLoop);
				num = 844213516;
				continue;
			case 2:
				adAlfJRbbOefNAIYcrKKpmNUunTK();
				num = 844213513;
				continue;
			case 4:
				nXErRbwAigpeSUKNnHDMPkYiLlQ();
				if (enVoekoLyoporHuwAJgfgZkigNl != null)
				{
					enVoekoLyoporHuwAJgfgZkigNl.UpdateFinished();
					num = 844213512;
					continue;
				}
				goto IL_009c;
			case 5:
				goto IL_0103;
			case 6:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0058:
		if (enVoekoLyoporHuwAJgfgZkigNl != null)
		{
			enVoekoLyoporHuwAJgfgZkigNl.Update();
			num = 844213505;
			goto IL_000d;
		}
		goto IL_0072;
		IL_009c:
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			EsqysMvalMeuTAeZFflQpCwdcnfD.EhlPnfprjfkehAbDLrDcQKRlXmc(updateLoop);
			num = 844213517;
			goto IL_000d;
		}
		goto IL_0103;
		IL_0072:
		fFpBnJdLcRoXgERDdsEABKLajcgp();
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			int num2;
			if (enVoekoLyoporHuwAJgfgZkigNl == null)
			{
				num = 844213516;
				num2 = num;
			}
			else
			{
				num = 844213519;
				num2 = num;
			}
			goto IL_000d;
		}
		goto IL_009c;
		IL_0103:
		int num3;
		if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
		{
			num = 844213515;
			num3 = num;
		}
		else
		{
			num = 844213518;
			num3 = num;
		}
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (hPZMucJayMaNawJjXSMUyHDwzhD != null)
		{
			hPZMucJayMaNawJjXSMUyHDwzhD.HtJdxRxaGggkmaMTSWUpHqjZLDV();
			goto IL_0016;
		}
		goto IL_00eb;
		IL_0071:
		int count = default(int);
		int num;
		if (AvwfdLjWSYyRUfRbGOqVqadERNGK != null)
		{
			count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
			num = 590319584;
			goto IL_001b;
		}
		goto IL_010b;
		IL_0016:
		num = 590319598;
		goto IL_001b;
		IL_001b:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x232F8FEC)
			{
			case 6:
				break;
			default:
				return;
			case 7:
				EsqysMvalMeuTAeZFflQpCwdcnfD.Dispose();
				num = 590319588;
				continue;
			case 10:
				goto IL_0071;
			case 4:
				goto IL_008f;
			case 8:
				goto IL_00a7;
			case 12:
				num2 = 0;
				num = 590319592;
				continue;
			case 1:
				goto IL_00cf;
			case 2:
				goto IL_00eb;
			case 11:
				goto IL_010b;
			case 9:
				num2++;
				num = 590319592;
				continue;
			case 0:
				enVoekoLyoporHuwAJgfgZkigNl.Dispose();
				num = 590319599;
				continue;
			case 5:
				if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num2] != null)
				{
					AvwfdLjWSYyRUfRbGOqVqadERNGK[num2].HtJdxRxaGggkmaMTSWUpHqjZLDV();
					num = 590319589;
					continue;
				}
				goto case 9;
			case 3:
				return;
			}
			break;
			IL_00a7:
			int num3;
			if (enVoekoLyoporHuwAJgfgZkigNl == null)
			{
				num = 590319599;
				num3 = num;
			}
			else
			{
				num = 590319596;
				num3 = num;
			}
			continue;
			IL_008f:
			int num4;
			if (num2 < count)
			{
				num = 590319593;
				num4 = num;
			}
			else
			{
				num = 590319591;
				num4 = num;
			}
		}
		goto IL_0016;
		IL_00cf:
		int num5;
		if (EsqysMvalMeuTAeZFflQpCwdcnfD != null)
		{
			num = 590319595;
			num5 = num;
		}
		else
		{
			num = 590319588;
			num5 = num;
		}
		goto IL_001b;
		IL_00eb:
		if (ckgHevKWKxxvylqJEuOINRCXDZV != null)
		{
			ckgHevKWKxxvylqJEuOINRCXDZV.HtJdxRxaGggkmaMTSWUpHqjZLDV();
			num = 590319590;
			goto IL_001b;
		}
		goto IL_0071;
		IL_010b:
		if (LuXZhDIoVYWJDVRjsBUBdAbUFbk != null)
		{
			LuXZhDIoVYWJDVRjsBUBdAbUFbk.Dispose();
			num = 590319597;
			goto IL_001b;
		}
		goto IL_00cf;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return YALIvlsEVxFcouIKiMIOBoKrdos;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 2077072274;
			while (true)
			{
				switch (num2 ^ 0x7BCD9B92)
				{
				case 5:
					num2 = 2077072275;
					continue;
				default:
					return;
				case 1:
					break;
				case 0:
					if (num >= hShdCGGbdfKCwKvzqAgdyZHXxRH)
					{
						Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
						num2 = 2077072273;
						continue;
					}
					goto case 2;
				case 2:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num].inputManagerId == inputManagerId)
					{
						AvwfdLjWSYyRUfRbGOqVqadERNGK[num].FillData(data);
						return;
					}
					goto case 4;
				case 4:
					num++;
					num2 = 2077072274;
					continue;
				case 3:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		enVoekoLyoporHuwAJgfgZkigNl.SystemDeviceConnected();
		capIsYRGcjdINxLFChhLiBZbnVUt = true;
		while (true)
		{
			int num = 1063542686;
			while (true)
			{
				switch (num ^ 0x3F645F9C)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (jknBiNnVvBEJUrrzYJXBYRgRbau)
					{
						lDrCawWWQwDbNHbrPJXgBBstingI.Start();
						num = 1063542685;
						continue;
					}
					goto case 1;
				case 3:
					_SystemDeviceConnectedEvent();
					num = 1063542680;
					continue;
				case 1:
				{
					int num2;
					if (_SystemDeviceConnectedEvent == null)
					{
						num = 1063542680;
						num2 = num;
					}
					else
					{
						num = 1063542687;
						num2 = num;
					}
					continue;
				}
				case 4:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		enVoekoLyoporHuwAJgfgZkigNl.SystemDeviceDisconnected();
		capIsYRGcjdINxLFChhLiBZbnVUt = true;
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			goto IL_001a;
		}
		goto IL_004e;
		IL_001a:
		int num = -2068507824;
		goto IL_001f;
		IL_001f:
		while (true)
		{
			switch (num ^ -2068507821)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				lDrCawWWQwDbNHbrPJXgBBstingI.Start();
				num = -2068507822;
				continue;
			case 1:
				goto IL_004e;
			case 2:
				return;
			}
			break;
		}
		goto IL_001a;
		IL_004e:
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
			num = -2068507823;
			goto IL_001f;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool jknBiNnVvBEJUrrzYJXBYRgRbau2 = jknBiNnVvBEJUrrzYJXBYRgRbau;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return EsqysMvalMeuTAeZFflQpCwdcnfD;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return LuXZhDIoVYWJDVRjsBUBdAbUFbk;
	}

	public void RIFGoRkBALlYhSSoKGqJvomxrIu(WsSYQoLcjDhJJICQctaOSeWVJfl P_0, ZsxRzJGagMdpbHQHKZpXdCpvBdnC P_1)
	{
	}

	private void adAlfJRbbOefNAIYcrKKpmNUunTK()
	{
		if (rzeDVbCNKMajPsSZXPQVQjoxsCZ == 0)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (!ckgHevKWKxxvylqJEuOINRCXDZV.isRunning)
			{
				num = -346018394;
				num2 = num;
			}
			else
			{
				num = -346018400;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -346018397)
				{
				case 8:
					num = -346018399;
					continue;
				default:
					return;
				case 0:
					if (ckgHevKWKxxvylqJEuOINRCXDZV.result)
					{
						capIsYRGcjdINxLFChhLiBZbnVUt = true;
						num = -346018398;
						continue;
					}
					goto case 1;
				case 3:
					if (!ckgHevKWKxxvylqJEuOINRCXDZV.xHkLCHGKEGSLVNAFPpLRGAkaRJs())
					{
						return;
					}
					goto case 6;
				case 1:
					lDrCawWWQwDbNHbrPJXgBBstingI.Start();
					return;
				case 4:
					return;
				case 5:
				{
					int num3;
					if (!lDrCawWWQwDbNHbrPJXgBBstingI.running)
					{
						num = -346018391;
						num3 = num;
					}
					else
					{
						num = -346018390;
						num3 = num;
					}
					continue;
				}
				case 9:
					if (lDrCawWWQwDbNHbrPJXgBBstingI.Update())
					{
						ckgHevKWKxxvylqJEuOINRCXDZV.CNNCNIEIEPKDJVWLdcWrLrRIbyb();
						num = -346018396;
						continue;
					}
					return;
				case 10:
					lDrCawWWQwDbNHbrPJXgBBstingI.Start();
					return;
				case 6:
				{
					if (lDrCawWWQwDbNHbrPJXgBBstingI.running)
					{
						return;
					}
					int num4;
					if (!hPZMucJayMaNawJjXSMUyHDwzhD.isRunning)
					{
						num = -346018397;
						num4 = num;
					}
					else
					{
						num = -346018393;
						num4 = num;
					}
					continue;
				}
				case 2:
					break;
				case 7:
					return;
				}
				break;
			}
		}
	}

	private void ExvTLcrmxZuVwMPPwmgKNOkIvzX()
	{
		ExvTLcrmxZuVwMPPwmgKNOkIvzX(PAjVQxsWCeNqngWswmuPEmMVfTd());
	}

	private void ExvTLcrmxZuVwMPPwmgKNOkIvzX(IList<KchbyaIpiOUwIuFRWQOhqCekrdI> P_0)
	{
		int num = 0;
		KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = default(KchbyaIpiOUwIuFRWQOhqCekrdI);
		int num6 = default(int);
		int num4 = default(int);
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		int num3 = default(int);
		List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> avwfdLjWSYyRUfRbGOqVqadERNGK = default(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo>);
		int count = default(int);
		int num5 = default(int);
		List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> list = default(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo>);
		while (true)
		{
			int num2 = -1110105710;
			while (true)
			{
				switch (num2 ^ -1110105705)
				{
				case 19:
					break;
				case 21:
					kchbyaIpiOUwIuFRWQOhqCekrdI = P_0[num6];
					num2 = -1110105702;
					continue;
				case 18:
					num6++;
					num2 = -1110105708;
					continue;
				case 22:
					num4--;
					num2 = -1110105701;
					continue;
				case 2:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.bELhEeAWQmtfFIrLTgNSpwrpFSQN = kchbyaIpiOUwIuFRWQOhqCekrdI.VibrationMotorCount;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.extension = kchbyaIpiOUwIuFRWQOhqCekrdI.ControllerExtension;
					num2 = -1110105712;
					continue;
				case 12:
					if (num4 < 0)
					{
						num3 = ((avwfdLjWSYyRUfRbGOqVqadERNGK != null) ? avwfdLjWSYyRUfRbGOqVqadERNGK.Count : 0);
						count = P_0.Count;
						num6 = 0;
						num2 = -1110105708;
						continue;
					}
					goto case 4;
				case 7:
					kchbyaIpiOUwIuFRWQOhqCekrdI.Acquire();
					num2 = -1110105704;
					continue;
				case 25:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.ZODLrlcqYgYcHKPIQwZOreOIaYF = kchbyaIpiOUwIuFRWQOhqCekrdI.BluetoothDeviceName;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.mqRCOGhpUhuJIDFwlHJQROPEFMrC = kchbyaIpiOUwIuFRWQOhqCekrdI.SupportsVibration;
					num2 = -1110105707;
					continue;
				case 0:
					if (num5 >= num)
					{
						list.ForEach(delegate(zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo3)
						{
							rVPjnRIbMLDOGrkwREudCiotksA(zYKlnVPIidhlEGjgyEmNKwdfoPXo3, false);
						});
						HZnuerKKqNbEDMtPsGxcuVmEOVA(avwfdLjWSYyRUfRbGOqVqadERNGK, AvwfdLjWSYyRUfRbGOqVqadERNGK, false);
						num2 = -1110105728;
						continue;
					}
					goto case 11;
				case 17:
				{
					num++;
					int num8;
					if (!zYKlnVPIidhlEGjgyEmNKwdfoPXo2.NxfPDLDjjkkAByWVYHnViSDRJzU)
					{
						num2 = -1110105723;
						num8 = num2;
					}
					else
					{
						num2 = -1110105725;
						num8 = num2;
					}
					continue;
				}
				case 4:
					if (avwfdLjWSYyRUfRbGOqVqadERNGK[num4] != null)
					{
						int num9;
						if (!avwfdLjWSYyRUfRbGOqVqadERNGK[num4].IsValid)
						{
							num2 = -1110105697;
							num9 = num2;
						}
						else
						{
							num2 = -1110105727;
							num9 = num2;
						}
						continue;
					}
					goto case 22;
				case 10:
					WioVicfbmtCEzmWlIpbInYpIgSp(num3, num, avwfdLjWSYyRUfRbGOqVqadERNGK, AvwfdLjWSYyRUfRbGOqVqadERNGK);
					num2 = -1110105721;
					continue;
				case 8:
					list.Add(avwfdLjWSYyRUfRbGOqVqadERNGK[num4]);
					avwfdLjWSYyRUfRbGOqVqadERNGK.RemoveAt(num4);
					num2 = -1110105727;
					continue;
				case 16:
					num5 = 0;
					num2 = -1110105705;
					continue;
				case 3:
					if (num6 < count)
					{
						goto case 6;
					}
					if (rzeDVbCNKMajPsSZXPQVQjoxsCZ == 0)
					{
						ckgHevKWKxxvylqJEuOINRCXDZV.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
						num2 = -1110105698;
						continue;
					}
					goto case 9;
				case 13:
					if (kchbyaIpiOUwIuFRWQOhqCekrdI != null)
					{
						zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = new zYKlnVPIidhlEGjgyEmNKwdfoPXo(kchbyaIpiOUwIuFRWQOhqCekrdI, kchbyaIpiOUwIuFRWQOhqCekrdI.DeviceType, lzXAqTcTNwGXhyoMQqetZTTNJGjM);
						zYKlnVPIidhlEGjgyEmNKwdfoPXo2.cBDIfdqFvdWzxrFEMJqjLvTvIpG = kchbyaIpiOUwIuFRWQOhqCekrdI.InstanceGuid;
						zYKlnVPIidhlEGjgyEmNKwdfoPXo2.mHIfxFeuzrrprIjNQQttDcAWoJX = kchbyaIpiOUwIuFRWQOhqCekrdI.ProductName;
						zYKlnVPIidhlEGjgyEmNKwdfoPXo2.AOVTbdgjQpuvVXuOzJgmsvYOWec = kchbyaIpiOUwIuFRWQOhqCekrdI.ProductName;
						num2 = -1110105713;
						continue;
					}
					goto case 18;
				case 20:
					rzeDVbCNKMajPsSZXPQVQjoxsCZ++;
					num2 = -1110105723;
					continue;
				case 11:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(AvwfdLjWSYyRUfRbGOqVqadERNGK[num5]));
						num2 = -1110105706;
						continue;
					}
					goto case 1;
				case 14:
					num2 = -1110105701;
					continue;
				case 24:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.qSJYeLiyjfTRCcMnvDOwuKWJouA = kchbyaIpiOUwIuFRWQOhqCekrdI.ProductGuid;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.fSuJoZmgBMnbZWJgvPaTNrIBkjq = kchbyaIpiOUwIuFRWQOhqCekrdI.ProductId;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.DqYErgUjFMUHxVkmrXzgfOxtEsC = kchbyaIpiOUwIuFRWQOhqCekrdI.VendorId;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.ySxHACCmrqwNquIhkRqoFdufNKj = kchbyaIpiOUwIuFRWQOhqCekrdI.JoystickId;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.jHaYXdTXWAJNlfIRTMsRGaqNBpK = kchbyaIpiOUwIuFRWQOhqCekrdI.AxisCount;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.qOBHYZBCAkYYTJoRDdsZoTyTELA = kchbyaIpiOUwIuFRWQOhqCekrdI.ButtonCount;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.ByBfmUYbKOERmAjkpxrmtOAORFt = kchbyaIpiOUwIuFRWQOhqCekrdI.HatCount;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.KqmajqZRajQeRJHxvHBZhqVPgsd = false;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.NxfPDLDjjkkAByWVYHnViSDRJzU = kchbyaIpiOUwIuFRWQOhqCekrdI.IsBluetoothDevice;
					num2 = -1110105714;
					continue;
				case 6:
				{
					int num7;
					if (P_0[num6] != null)
					{
						num2 = -1110105726;
						num7 = num2;
					}
					else
					{
						num2 = -1110105723;
						num7 = num2;
					}
					continue;
				}
				case 9:
					hShdCGGbdfKCwKvzqAgdyZHXxRH = num;
					num2 = -1110105699;
					continue;
				case 15:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.qlRdJvJiKhLJLbmzJBHkcnXAtwPX();
					AvwfdLjWSYyRUfRbGOqVqadERNGK.Add(zYKlnVPIidhlEGjgyEmNKwdfoPXo2);
					num2 = -1110105722;
					continue;
				case 5:
					avwfdLjWSYyRUfRbGOqVqadERNGK = AvwfdLjWSYyRUfRbGOqVqadERNGK;
					num3 = hShdCGGbdfKCwKvzqAgdyZHXxRH;
					AvwfdLjWSYyRUfRbGOqVqadERNGK = new List<zYKlnVPIidhlEGjgyEmNKwdfoPXo>();
					rzeDVbCNKMajPsSZXPQVQjoxsCZ = 0;
					list = new List<zYKlnVPIidhlEGjgyEmNKwdfoPXo>();
					num4 = num3 - 1;
					num2 = -1110105703;
					continue;
				case 1:
					num5++;
					num2 = -1110105705;
					continue;
				default:
					HZnuerKKqNbEDMtPsGxcuVmEOVA(AvwfdLjWSYyRUfRbGOqVqadERNGK, avwfdLjWSYyRUfRbGOqVqadERNGK, true);
					return;
				}
				break;
			}
		}
	}

	private void nXErRbwAigpeSUKNnHDMPkYiLlQ()
	{
		int num = 0;
		while (num < hShdCGGbdfKCwKvzqAgdyZHXxRH)
		{
			while (true)
			{
				zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = AvwfdLjWSYyRUfRbGOqVqadERNGK[num];
				int num2 = -1192407193;
				while (true)
				{
					switch (num2 ^ -1192407197)
					{
					case 5:
						num2 = -1192407198;
						continue;
					case 1:
						break;
					case 4:
						if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2 != null)
						{
							if (ilRrVwkMgOLwkAAfYNNcVNLgBSS)
							{
								goto IL_004d;
							}
							goto case 0;
						}
						goto case 3;
					case 0:
						zYKlnVPIidhlEGjgyEmNKwdfoPXo2.Update();
						num2 = -1192407200;
						continue;
					case 3:
						num++;
						num2 = -1192407199;
						continue;
					default:
						goto end_IL_002e;
					}
					break;
					IL_004d:
					int num3;
					if (!zYKlnVPIidhlEGjgyEmNKwdfoPXo2.KqmajqZRajQeRJHxvHBZhqVPgsd)
					{
						num2 = -1192407197;
						num3 = num2;
					}
					else
					{
						num2 = -1192407200;
						num3 = num2;
					}
				}
				continue;
				end_IL_002e:
				break;
			}
		}
	}

	private bool GnNaUkaHprcsTpLskywvfZOHPBmp(ghVJoxJlbsXgoFcmZESJqvsJGsV P_0)
	{
		try
		{
			return P_0.IsAttached();
		}
		catch
		{
			return false;
		}
	}

	private IList<KchbyaIpiOUwIuFRWQOhqCekrdI> PAjVQxsWCeNqngWswmuPEmMVfTd()
	{
		return enVoekoLyoporHuwAJgfgZkigNl.GetJoysticks<KchbyaIpiOUwIuFRWQOhqCekrdI>();
	}

	private void WioVicfbmtCEzmWlIpbInYpIgSp(int P_0, int P_1, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_2, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(zYKlnVPIidhlEGjgyEmNKwdfoPXo.YGXDKFCxtZualSpgecrIGagUJoxD);
			goto IL_0017;
		}
		goto IL_007c;
		IL_00ad:
		MIoEQIuCiGhoUrcScRIygYMXpyI(P_1, P_3, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu.hsqFwVabxTxZDbitiWOUsqWRrjW);
		MIoEQIuCiGhoUrcScRIygYMXpyI(P_1, P_3, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu.XSasYkIfXXTIuNYDajUSHAZXtRK);
		int num = 1182524714;
		goto IL_001c;
		IL_0017:
		num = 1182524709;
		goto IL_001c;
		IL_001c:
		int num2 = default(int);
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		while (true)
		{
			switch (num ^ 0x467BE52D)
			{
			case 4:
				break;
			case 7:
				num2 = 0;
				num = 1182524715;
				continue;
			case 0:
				zYKlnVPIidhlEGjgyEmNKwdfoPXo2.rewiredId = sbyIXavKIUtCermoZwGVxaaQFdB();
				num = 1182524716;
				continue;
			case 5:
				num2++;
				num = 1182524715;
				continue;
			case 8:
				goto IL_007c;
			case 3:
				goto IL_00ad;
			case 2:
				zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = P_3[num2];
				if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2 != null && zYKlnVPIidhlEGjgyEmNKwdfoPXo2.inputManagerId < 0)
				{
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.inputManagerId = hJEtLubjiEObEqlHGFhLgmjnBHlp(P_3);
					num = 1182524717;
					continue;
				}
				goto case 5;
			case 1:
				VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(zYKlnVPIidhlEGjgyEmNKwdfoPXo2);
				num = 1182524712;
				continue;
			default:
				if (num2 >= P_1)
				{
					P_3.Sort(zYKlnVPIidhlEGjgyEmNKwdfoPXo.KIbRqtvxhdlGNZbGlQYeWDzVgXY);
					return;
				}
				goto case 2;
			}
			break;
		}
		goto IL_0017;
		IL_007c:
		if (P_0 > 0 && P_1 > 0)
		{
			AGedmzbCJhMeJCJgHTXgNMEGvrXn(P_1, P_3, P_0, P_2, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu.hsqFwVabxTxZDbitiWOUsqWRrjW);
			AGedmzbCJhMeJCJgHTXgNMEGvrXn(P_1, P_3, P_0, P_2, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu.XSasYkIfXXTIuNYDajUSHAZXtRK);
			num = 1182524718;
			goto IL_001c;
		}
		goto IL_00ad;
	}

	private void vpLhaJQfWoJCrEfgeBIeKQWnfTfi(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 119759652;
			while (true)
			{
				switch (num ^ 0x7236321)
				{
				case 4:
					break;
				case 5:
					num2 = 0;
					num = 119759648;
					continue;
				case 2:
					if (num2 != P_1)
					{
						int num3;
						if (P_0[num2] != null)
						{
							num = 119759650;
							num3 = num;
						}
						else
						{
							num = 119759649;
							num3 = num;
						}
						continue;
					}
					goto case 0;
				case 0:
					num2++;
					num = 119759648;
					continue;
				case 3:
					if (P_0[num2].inputManagerId == P_2)
					{
						P_0[num2].inputManagerId = -1;
						num = 119759649;
						continue;
					}
					goto case 0;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private bool vwcgKzwXKcPdZstsZhoZReCiCHfD(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				if (P_0[num] != null && P_0[num].inputManagerId == P_1)
				{
					return false;
				}
				num++;
				int num2 = 482498125;
				while (true)
				{
					switch (num2 ^ 0x1CC2564C)
					{
					case 0:
						num2 = 482498126;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0029;
					}
					break;
				}
				continue;
				end_IL_0029:
				break;
			}
		}
		return true;
	}

	private int hJEtLubjiEObEqlHGFhLgmjnBHlp(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int num3 = default(int);
		int count = default(int);
		while (true)
		{
			int num2 = 766681053;
			while (true)
			{
				switch (num2 ^ 0x2DB29FD8)
				{
				case 0:
					break;
				case 5:
					flag = false;
					num2 = 766681054;
					continue;
				case 2:
					num3++;
					num2 = 766681052;
					continue;
				case 4:
				{
					int num5;
					if (num3 < count)
					{
						num2 = 766681051;
						num5 = num2;
					}
					else
					{
						num2 = 766681049;
						num5 = num2;
					}
					continue;
				}
				case 7:
					if (P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = 766681049;
						continue;
					}
					goto case 2;
				case 8:
					num3 = 0;
					num2 = 766681052;
					continue;
				case 6:
					count = P_0.Count;
					num2 = 766681040;
					continue;
				case 3:
				{
					int num4;
					if (P_0[num3] == null)
					{
						num2 = 766681050;
						num4 = num2;
					}
					else
					{
						num2 = 766681055;
						num4 = num2;
					}
					continue;
				}
				default:
					if (!flag)
					{
						return num;
					}
					num++;
					goto case 5;
				}
				break;
			}
		}
	}

	private bool hlnxeRdKsPZbQWDLOeVNBuFoOaU(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < P_0.Count)
			{
				num2 = 674158121;
				num3 = num2;
			}
			else
			{
				num2 = 674158120;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x282ED62A)
				{
				case 4:
					num2 = 674158121;
					continue;
				case 1:
					break;
				case 0:
					return true;
				case 3:
					if (P_0[num].rewiredId != P_1)
					{
						num++;
						num2 = 674158123;
					}
					else
					{
						num2 = 674158122;
					}
					continue;
				default:
					return false;
				}
				break;
			}
		}
	}

	private void AGedmzbCJhMeJCJgHTXgNMEGvrXn(int P_0, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_1, int P_2, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_3, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu P_4)
	{
		int num = ((P_4 != UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu.hsqFwVabxTxZDbitiWOUsqWRrjW) ? 1 : 2);
		int num2 = 0;
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo3 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		int num4 = default(int);
		while (num2 < P_0)
		{
			while (true)
			{
				zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = P_1[num2];
				int num3 = 507312511;
				while (true)
				{
					switch (num3 ^ 0x1E3CF978)
					{
					case 6:
						num3 = 507312505;
						continue;
					case 4:
						if (zYKlnVPIidhlEGjgyEmNKwdfoPXo3 != null && !hlnxeRdKsPZbQWDLOeVNBuFoOaU(P_1, zYKlnVPIidhlEGjgyEmNKwdfoPXo3.rewiredId) && zYKlnVPIidhlEGjgyEmNKwdfoPXo2.CjIOgfYLwvzSovgYNuiXTTvJjBe(zYKlnVPIidhlEGjgyEmNKwdfoPXo3) >= num)
						{
							zYKlnVPIidhlEGjgyEmNKwdfoPXo2.qmxqFhOXPynIFVlddeYJeiHLrJIQ(zYKlnVPIidhlEGjgyEmNKwdfoPXo3);
							num3 = 507312509;
							continue;
						}
						goto case 0;
					case 7:
						break;
					case 9:
						num2++;
						num3 = 507312498;
						continue;
					case 2:
						goto IL_00a1;
					case 5:
						VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(zYKlnVPIidhlEGjgyEmNKwdfoPXo2);
						num3 = 507312504;
						continue;
					case 0:
						num4++;
						num3 = 507312506;
						continue;
					case 1:
						goto end_IL_0015;
					case 8:
						if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2.inputManagerId < 0)
						{
							num4 = 0;
							num3 = 507312506;
							continue;
						}
						goto case 9;
					case 3:
						zYKlnVPIidhlEGjgyEmNKwdfoPXo3 = P_3[num4];
						num3 = 507312508;
						continue;
					default:
						goto end_IL_00dd;
					}
					int num5;
					if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2 != null)
					{
						num3 = 507312496;
						num5 = num3;
					}
					else
					{
						num3 = 507312497;
						num5 = num3;
					}
					continue;
					IL_00a1:
					int num6;
					if (num4 < P_2)
					{
						num3 = 507312507;
						num6 = num3;
					}
					else
					{
						num3 = 507312497;
						num6 = num3;
					}
					continue;
					end_IL_0015:
					break;
				}
				continue;
				end_IL_00dd:
				break;
			}
		}
	}

	private void MIoEQIuCiGhoUrcScRIygYMXpyI(int P_0, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_1, UwwjQFGBBMEmsVSwhFMwmrVrhtF.SPJwSVFuFCjLQrdyDxCVxDwwJlu P_2)
	{
		int num = 0;
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		UwwjQFGBBMEmsVSwhFMwmrVrhtF.OYSTavsNkFtmKAZpUdLgHuCEopI oYSTavsNkFtmKAZpUdLgHuCEopI = default(UwwjQFGBBMEmsVSwhFMwmrVrhtF.OYSTavsNkFtmKAZpUdLgHuCEopI);
		int num3 = default(int);
		while (true)
		{
			int num2 = -1570174610;
			while (true)
			{
				switch (num2 ^ -1570174611)
				{
				case 2:
					break;
				case 0:
					VkhgikRmZCRpwCsFCAHFtklICJTg.twVDKshQikIuavgehoSXWHaPlJad(zYKlnVPIidhlEGjgyEmNKwdfoPXo2);
					num2 = -1570174619;
					continue;
				case 8:
					num++;
					num2 = -1570174620;
					continue;
				case 3:
					num2 = -1570174620;
					continue;
				case 6:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = P_1[num];
					if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2 != null && zYKlnVPIidhlEGjgyEmNKwdfoPXo2.inputManagerId < 0)
					{
						oYSTavsNkFtmKAZpUdLgHuCEopI = VkhgikRmZCRpwCsFCAHFtklICJTg.SNyQPMtxIqmpckDGNaILQiYNCbXF(zYKlnVPIidhlEGjgyEmNKwdfoPXo2, P_2);
						num2 = -1570174612;
						continue;
					}
					goto case 8;
				case 5:
					oYSTavsNkFtmKAZpUdLgHuCEopI.WfZmTofniSsPbHKlehKQdLSahSv = num3;
					num2 = -1570174615;
					continue;
				case 7:
					if (num3 < 0)
					{
						goto case 8;
					}
					if (!vwcgKzwXKcPdZstsZhoZReCiCHfD(P_1, num3))
					{
						num3 = hJEtLubjiEObEqlHGFhLgmjnBHlp(P_1);
						num2 = -1570174616;
						continue;
					}
					goto case 4;
				case 1:
					if (oYSTavsNkFtmKAZpUdLgHuCEopI != null && !hlnxeRdKsPZbQWDLOeVNBuFoOaU(P_1, oYSTavsNkFtmKAZpUdLgHuCEopI.InzpRLWBzesgNjVGacynCIMBDnJ))
					{
						num3 = oYSTavsNkFtmKAZpUdLgHuCEopI.WfZmTofniSsPbHKlehKQdLSahSv;
						num2 = -1570174614;
						continue;
					}
					goto case 8;
				case 4:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.inputManagerId = num3;
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2.rewiredId = oYSTavsNkFtmKAZpUdLgHuCEopI.InzpRLWBzesgNjVGacynCIMBDnJ;
					num2 = -1570174611;
					continue;
				default:
					if (num >= P_0)
					{
						return;
					}
					goto case 6;
				}
				break;
			}
		}
	}

	private void fFpBnJdLcRoXgERDdsEABKLajcgp()
	{
		if (capIsYRGcjdINxLFChhLiBZbnVUt)
		{
			vCuRdmmqHqFMlQrXdksTFtinicw();
			goto IL_000e;
		}
		goto IL_0030;
		IL_0030:
		int num;
		int num2;
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			num = 962894679;
			num2 = num;
		}
		else
		{
			num = 962894676;
			num2 = num;
		}
		goto IL_0013;
		IL_000e:
		num = 962894678;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ 0x39649B55)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0030;
			case 2:
				if (hPZMucJayMaNawJjXSMUyHDwzhD.isRunning && hPZMucJayMaNawJjXSMUyHDwzhD.xHkLCHGKEGSLVNAFPpLRGAkaRJs())
				{
					SzxmDjxbrUAggcZJTsvgnNMpYtvn();
					num = 962894676;
					continue;
				}
				return;
			case 1:
				return;
			}
			break;
		}
		goto IL_000e;
	}

	private void vCuRdmmqHqFMlQrXdksTFtinicw()
	{
		capIsYRGcjdINxLFChhLiBZbnVUt = false;
		if (hPZMucJayMaNawJjXSMUyHDwzhD.isRunning)
		{
			return;
		}
		while (true)
		{
			enVoekoLyoporHuwAJgfgZkigNl.DAHcyYLtplbGvPFjhfRFGgOFCmK();
			hPZMucJayMaNawJjXSMUyHDwzhD.CNNCNIEIEPKDJVWLdcWrLrRIbyb();
			int num = 966884932;
			while (true)
			{
				switch (num ^ 0x39A17E46)
				{
				case 0:
					goto IL_0015;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0015:
				num = 966884935;
			}
		}
	}

	private void SzxmDjxbrUAggcZJTsvgnNMpYtvn()
	{
		enVoekoLyoporHuwAJgfgZkigNl.gHTVzIhcnCDJODvwfVhwJwpSAkRd();
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return;
		}
		IList<KchbyaIpiOUwIuFRWQOhqCekrdI> list = default(IList<KchbyaIpiOUwIuFRWQOhqCekrdI>);
		while (true)
		{
			int num = -624822358;
			while (true)
			{
				switch (num ^ -624822360)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					list = PAjVQxsWCeNqngWswmuPEmMVfTd();
					num = -624822359;
					continue;
				case 4:
					ExvTLcrmxZuVwMPPwmgKNOkIvzX(list);
					num = -624822360;
					continue;
				case 1:
				{
					int num2;
					if (rBuqPQDHkShnzbSQZPtjpzuipiG(list))
					{
						num = -624822356;
						num2 = num;
					}
					else
					{
						num = -624822360;
						num2 = num;
					}
					continue;
				}
				case 0:
					return;
				}
				break;
			}
		}
	}

	private bool rBuqPQDHkShnzbSQZPtjpzuipiG(IList<KchbyaIpiOUwIuFRWQOhqCekrdI> P_0)
	{
		int num = 0;
		int num3 = default(int);
		int count = default(int);
		int num4 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num2 = -26201587;
			while (true)
			{
				switch (num2 ^ -26201593)
				{
				case 0:
					break;
				case 8:
					num2 = -26201595;
					continue;
				case 1:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num3] != null && !NHFlLujTFOmTrBJwxohTnqZbdaWH(P_0, AvwfdLjWSYyRUfRbGOqVqadERNGK[num3].instanceGuid))
					{
						return true;
					}
					num3++;
					num2 = -26201599;
					continue;
				case 10:
					num2 = -26201600;
					continue;
				case 4:
					count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
					num3 = 0;
					num2 = -26201599;
					continue;
				case 11:
					if (!AvwfdLjWSYyRUfRbGOqVqadERNGK[num].IsValid)
					{
						return true;
					}
					goto IL_00bf;
				case 2:
				{
					int num5;
					if (num4 >= count2)
					{
						num2 = -26201597;
						num5 = num2;
					}
					else
					{
						num2 = -26201586;
						num5 = num2;
					}
					continue;
				}
				case 9:
					if (P_0[num4] != null && !eNPklNfgpqYVTvVTCPrrltwNiDp(P_0[num4].InstanceGuid))
					{
						return true;
					}
					num4++;
					num2 = -26201595;
					continue;
				case 7:
				{
					int num6;
					if (num < AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
					{
						num2 = -26201596;
						num6 = num2;
					}
					else
					{
						num2 = -26201598;
						num6 = num2;
					}
					continue;
				}
				case 5:
					count2 = P_0.Count;
					num4 = 0;
					num2 = -26201585;
					continue;
				case 3:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num] != null)
					{
						num2 = -26201588;
						continue;
					}
					goto IL_00bf;
				default:
					{
						if (num3 >= count)
						{
							return false;
						}
						goto case 1;
					}
					IL_00bf:
					num++;
					num2 = -26201600;
					continue;
				}
				break;
			}
		}
	}

	private bool eNPklNfgpqYVTvVTCPrrltwNiDp(Guid P_0)
	{
		int count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -999944174;
				num3 = num2;
			}
			else
			{
				num2 = -999944176;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -999944175)
				{
				case 0:
					num2 = -999944174;
					continue;
				case 3:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num] != null)
					{
						num2 = -999944172;
						continue;
					}
					goto IL_0086;
				case 5:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num].instanceGuid == P_0)
					{
						num2 = -999944171;
						continue;
					}
					goto IL_0086;
				case 2:
					break;
				case 4:
					return true;
				default:
					{
						return false;
					}
					IL_0086:
					num++;
					num2 = -999944173;
					continue;
				}
				break;
			}
		}
	}

	private bool NHFlLujTFOmTrBJwxohTnqZbdaWH(IList<KchbyaIpiOUwIuFRWQOhqCekrdI> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = 86861192;
			while (true)
			{
				switch (num2 ^ 0x52D658B)
				{
				case 4:
					break;
				case 2:
					if (P_0[num].InstanceGuid == P_1)
					{
						return true;
					}
					goto IL_0045;
				case 1:
					if (P_0[num] != null)
					{
						num2 = 86861193;
						continue;
					}
					goto IL_0045;
				case 3:
					num2 = 86861195;
					continue;
				default:
					{
						if (num >= count)
						{
							return false;
						}
						goto case 1;
					}
					IL_0045:
					num++;
					num2 = 86861195;
					continue;
				}
				break;
			}
		}
	}

	private void HZnuerKKqNbEDMtPsGxcuVmEOVA(List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_0, List<zYKlnVPIidhlEGjgyEmNKwdfoPXo> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		bool flag = default(bool);
		int num6 = default(int);
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		zYKlnVPIidhlEGjgyEmNKwdfoPXo zYKlnVPIidhlEGjgyEmNKwdfoPXo3 = default(zYKlnVPIidhlEGjgyEmNKwdfoPXo);
		while (true)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			int num2 = ((P_1 != null) ? P_1.Count : 0);
			int num3 = 0;
			int num4 = -1691419497;
			while (true)
			{
				switch (num4 ^ -1691419498)
				{
				case 9:
					num4 = -1691419503;
					continue;
				case 12:
					flag = false;
					if (P_1 != null)
					{
						num6 = 0;
						num4 = -1691419491;
						continue;
					}
					goto case 2;
				case 0:
					zYKlnVPIidhlEGjgyEmNKwdfoPXo2 = P_0[num3];
					num4 = -1691419490;
					continue;
				case 6:
				{
					zYKlnVPIidhlEGjgyEmNKwdfoPXo3 = P_1[num6];
					int num7;
					if (zYKlnVPIidhlEGjgyEmNKwdfoPXo3 == null)
					{
						num4 = -1691419502;
						num7 = num4;
					}
					else
					{
						num4 = -1691419493;
						num7 = num4;
					}
					continue;
				}
				case 10:
				{
					int num9;
					if (num6 < num2)
					{
						num4 = -1691419504;
						num9 = num4;
					}
					else
					{
						num4 = -1691419500;
						num9 = num4;
					}
					continue;
				}
				case 13:
				{
					int num8;
					if (!(zYKlnVPIidhlEGjgyEmNKwdfoPXo2.instanceGuid == zYKlnVPIidhlEGjgyEmNKwdfoPXo3.instanceGuid))
					{
						num4 = -1691419502;
						num8 = num4;
					}
					else
					{
						num4 = -1691419501;
						num8 = num4;
					}
					continue;
				}
				case 4:
					num6++;
					num4 = -1691419492;
					continue;
				case 8:
				{
					int num5;
					if (zYKlnVPIidhlEGjgyEmNKwdfoPXo2 != null)
					{
						num4 = -1691419494;
						num5 = num4;
					}
					else
					{
						num4 = -1691419499;
						num5 = num4;
					}
					continue;
				}
				case 11:
					num4 = -1691419492;
					continue;
				case 5:
					flag = true;
					num4 = -1691419500;
					continue;
				case 3:
					num3++;
					num4 = -1691419497;
					continue;
				case 2:
					if (!flag)
					{
						rVPjnRIbMLDOGrkwREudCiotksA(P_0[num3], P_2);
						num4 = -1691419499;
						continue;
					}
					goto case 3;
				case 7:
					break;
				default:
					if (num3 >= num)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void rVPjnRIbMLDOGrkwREudCiotksA(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent == null)
			{
				return;
			}
			goto IL_000b;
		}
		goto IL_0062;
		IL_0062:
		int num;
		int num2;
		if (_DeviceDisconnectedEvent == null)
		{
			num = 240401213;
			num2 = num;
		}
		else
		{
			num = 240401209;
			num2 = num;
		}
		goto IL_0010;
		IL_000b:
		num = 240401215;
		goto IL_0010;
		IL_0010:
		while (true)
		{
			switch (num ^ 0xE543B3D)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				_DeviceConnectedEvent(P_0.ToBridgedController());
				return;
			case 4:
				_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
				num = 240401213;
				continue;
			case 1:
				goto IL_0062;
			case 0:
				return;
			}
			break;
		}
		goto IL_000b;
	}

	[Conditional("DEBUGTHIS")]
	private void PGWlUvALtNEAAVDIUVwKDUpOIns(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void qzILqGpdyQQfIjtPQUgeyKnZlBd(zYKlnVPIidhlEGjgyEmNKwdfoPXo P_0)
	{
		rVPjnRIbMLDOGrkwREudCiotksA(P_0, false);
	}
}
