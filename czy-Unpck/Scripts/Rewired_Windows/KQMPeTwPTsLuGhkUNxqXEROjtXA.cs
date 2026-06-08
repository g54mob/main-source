using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Windows.RawInput;

internal class KQMPeTwPTsLuGhkUNxqXEROjtXA : PlatformInputManager, pBqgKWLeCLFlqaXbtEoODTfhYyUL
{
	private class lYLjuNkLxblMGskfekgsFxSEpiX : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int EXConJjMyypIPGpmnoMnbRhdgLW;

		private int JuzBXDTMFrDVUhqtKRLmdorveybr;

		public Guid UfFFvwXyyVSVFqRBlSrwmIuVpoX;

		public string AAVbVyNqUOuvZbdAweQkkZTDvgMS;

		private readonly TPOFglCEUenQueqhakDnrjLmVbgq AUIdfqdotGKPVLbiMbUhWyorbHfX;

		private readonly DeviceType OrLvljLwGziixrbcxLTXKnasxGm;

		public string vhbvSIyRvLTNKIdHyehnSxBQFBz;

		public string DVaqHcutoHoUrPluDMMcnunKAGA;

		public string OWynlsqwgASivUcmwQTMqEbSEpd;

		public int sEJsjYepUiBfnYUEFbfTIGbRtAM;

		public int GbjlnZOlkxhZPSOBDicayQzeaoO;

		public Guid duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		public Guid jswiKSoBCTxrqereFiOojDxDRmw;

		public Guid LFrLHWCZQzUjUEpwygbljLuHiCF;

		public int zuIOHHSFjUvtYoHqYbOkIVnjKLJ;

		public int bxgcDFqOQApgYslsUNoAyTPhJYH;

		public int opznTvXijlFgLFSdvYEAiweymVQ;

		public int qhBaQiBUaifpRBvldoZTqTDFPFqY;

		public int lenAIRsoOFqjBdbpibHDlBXGVmR;

		public int QQactFjAyaivYJCKROwerenGIZRE;

		public bool XWJGdtiTCNTQbkDNDyOHMuyHxoJn;

		public bool MVCWNUJrDWfwziBxuAuBAzgJAhiF;

		public bool fIkYGLxAqHefuTpANtEKPdaCbCFc;

		public int uxkWxbOjiQcJzrqdxdEMzRAvnKk;

		private float[] UeCdPcJARqFdGACIKPtkWZxawHVX;

		private float[] mCgSEFdyltyHHshVpCgaWFFUiOPJ;

		private bool[] nXfUtvmmBgAjTbwJUcuGGaPmoRlF;

		private HardwareJoystickMap_InputManager UDBtEeitridwJAiaUtqcfFDaFaI;

		private gjqxeaurskCrrKdTQKtANktjOGhz GnIhWyhRgHiOpzVFKrnEEvuLLfX;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

		private bool zzVdHXNFUtEpnTWJnqCoLRkJxcS;

		private bool YhPoJfQiAmHSpianQZbJomoJUOB;

		private bool inweGjIgYacXYohFlYRlpMFkgKMi;

		[CompilerGenerated]
		private Controller.Extension DBrxMHLcdkJyEFMTjrbrLCkhaSC;

		public bool hasDriver
		{
			get
			{
				if (AUIdfqdotGKPVLbiMbUhWyorbHfX == null)
				{
					return false;
				}
				return AUIdfqdotGKPVLbiMbUhWyorbHfX.Driver != null;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return EXConJjMyypIPGpmnoMnbRhdgLW;
			}
			set
			{
				EXConJjMyypIPGpmnoMnbRhdgLW = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return JuzBXDTMFrDVUhqtKRLmdorveybr;
			}
			set
			{
				JuzBXDTMFrDVUhqtKRLmdorveybr = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (AAVbVyNqUOuvZbdAweQkkZTDvgMS != "Unknown Controller")
				{
					return AAVbVyNqUOuvZbdAweQkkZTDvgMS;
				}
				if (MVCWNUJrDWfwziBxuAuBAzgJAhiF && !string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd))
				{
					return OWynlsqwgASivUcmwQTMqEbSEpd;
				}
				return DVaqHcutoHoUrPluDMMcnunKAGA;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (JuzBXDTMFrDVUhqtKRLmdorveybr < 0)
				{
					return null;
				}
				return JuzBXDTMFrDVUhqtKRLmdorveybr;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return DBrxMHLcdkJyEFMTjrbrLCkhaSC;
			}
			[CompilerGenerated]
			set
			{
				DBrxMHLcdkJyEFMTjrbrLCkhaSC = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		public bool IsValid
		{
			get
			{
				if (!inweGjIgYacXYohFlYRlpMFkgKMi && AUIdfqdotGKPVLbiMbUhWyorbHfX != null)
				{
					return AUIdfqdotGKPVLbiMbUhWyorbHfX.IsValid;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = IsValid;
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = IsValid;
		}

		public lYLjuNkLxblMGskfekgsFxSEpiX(TPOFglCEUenQueqhakDnrjLmVbgq joystick, DeviceType riDeviceType, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			AUIdfqdotGKPVLbiMbUhWyorbHfX = joystick;
			OrLvljLwGziixrbcxLTXKnasxGm = riDeviceType;
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			JuzBXDTMFrDVUhqtKRLmdorveybr = -1;
			EXConJjMyypIPGpmnoMnbRhdgLW = -1;
		}

		public void jDkVEgygiHHntkZXtjEwiSihtux()
		{
			if (!IsValid)
			{
				goto IL_000b;
			}
			goto IL_0154;
			IL_000b:
			int num = -1513039353;
			goto IL_0010;
			IL_0010:
			InputPlatform platform = default(InputPlatform);
			int num3 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num2 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			while (true)
			{
				switch (num ^ -1513039356)
				{
				case 11:
					break;
				case 8:
					if (platform == InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv)
					{
						goto IL_0067;
					}
					goto default;
				case 7:
					num3 = 0;
					num = -1513039349;
					continue;
				case 9:
					nXfUtvmmBgAjTbwJUcuGGaPmoRlF[num3] = buttons_orig2[num3].buttonInfo.isPressureSensitive;
					num = -1513039354;
					continue;
				case 4:
					nXfUtvmmBgAjTbwJUcuGGaPmoRlF[num2] = buttons_orig[num2].buttonInfo.isPressureSensitive;
					num2++;
					num = -1513039358;
					continue;
				case 6:
					goto IL_00ec;
				case 14:
					if (opznTvXijlFgLFSdvYEAiweymVQ > 0)
					{
						platform = UDBtEeitridwJAiaUtqcfFDaFaI.map.platform;
						if (platform != InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM)
						{
							goto case 8;
						}
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
						buttons_orig = platform_RawInput_Base.Buttons_orig;
						if (buttons_orig != null)
						{
							num2 = 0;
							num = -1513039358;
							continue;
						}
					}
					goto default;
				case 5:
					goto IL_0154;
				case 12:
					mCgSEFdyltyHHshVpCgaWFFUiOPJ = new float[opznTvXijlFgLFSdvYEAiweymVQ];
					nXfUtvmmBgAjTbwJUcuGGaPmoRlF = new bool[opznTvXijlFgLFSdvYEAiweymVQ];
					num = -1513039356;
					continue;
				case 15:
					goto IL_020e;
				case 2:
					num3++;
					num = -1513039349;
					continue;
				case 0:
					goto IL_023a;
				case 3:
					return;
				case 13:
					num = -1513039346;
					continue;
				case 1:
					zzVdHXNFUtEpnTWJnqCoLRkJxcS = ((UfFFvwXyyVSVFqRBlSrwmIuVpoX == Guid.Empty) ? true : false);
					UeCdPcJARqFdGACIKPtkWZxawHVX = new float[bxgcDFqOQApgYslsUNoAyTPhJYH];
					num = -1513039352;
					continue;
				default:
					GnIhWyhRgHiOpzVFKrnEEvuLLfX = AUIdfqdotGKPVLbiMbUhWyorbHfX.AxesState;
					Update();
					return;
				}
				break;
				IL_023a:
				int num4;
				if (UDBtEeitridwJAiaUtqcfFDaFaI != null)
				{
					num = -1513039350;
					num4 = num;
				}
				else
				{
					num = -1513039346;
					num4 = num;
				}
				continue;
				IL_00ec:
				int num5;
				if (num2 < buttons_orig.Length)
				{
					num = -1513039360;
					num5 = num;
				}
				else
				{
					num = -1513039351;
					num5 = num;
				}
				continue;
				IL_0067:
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
				buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
				int num6;
				if (buttons_orig2 == null)
				{
					num = -1513039346;
					num6 = num;
				}
				else
				{
					num = -1513039357;
					num6 = num;
				}
				continue;
				IL_020e:
				int num7;
				if (num3 < buttons_orig2.Length)
				{
					num = -1513039347;
					num7 = num;
				}
				else
				{
					num = -1513039346;
					num7 = num;
				}
			}
			goto IL_000b;
			IL_0154:
			LFrLHWCZQzUjUEpwygbljLuHiCF = MiscTools.CreateGuidHashSHA1(((!string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd)) ? OWynlsqwgASivUcmwQTMqEbSEpd : DVaqHcutoHoUrPluDMMcnunKAGA) + jswiKSoBCTxrqereFiOojDxDRmw);
			bxgcDFqOQApgYslsUNoAyTPhJYH = qhBaQiBUaifpRBvldoZTqTDFPFqY;
			opznTvXijlFgLFSdvYEAiweymVQ = lenAIRsoOFqjBdbpibHDlBXGVmR + QQactFjAyaivYJCKROwerenGIZRE * 8;
			UVFtCXlXPJBKXqaKnfwDHhlUFOJ();
			UfFFvwXyyVSVFqRBlSrwmIuVpoX = UDBtEeitridwJAiaUtqcfFDaFaI.hardwareMapIdentifier.guid;
			AAVbVyNqUOuvZbdAweQkkZTDvgMS = UDBtEeitridwJAiaUtqcfFDaFaI.controllerName;
			num = -1513039355;
			goto IL_0010;
		}

		public void laWNKiWcrSexnZtRRPyPhNqRVNc(lYLjuNkLxblMGskfekgsFxSEpiX P_0)
		{
			if (!IsValid)
			{
				return;
			}
			int num4 = default(int);
			int num6 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (P_0 == null)
				{
					num = -329713811;
					num2 = num;
				}
				else
				{
					num = -329713812;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -329713819)
					{
					case 5:
						num = -329713822;
						continue;
					default:
						return;
					case 4:
					{
						int num5;
						if (num4 >= MathTools.Min(nXfUtvmmBgAjTbwJUcuGGaPmoRlF.Length, P_0.nXfUtvmmBgAjTbwJUcuGGaPmoRlF.Length))
						{
							num = -329713818;
							num5 = num;
						}
						else
						{
							num = -329713809;
							num5 = num;
						}
						continue;
					}
					case 12:
						num6 = 0;
						num = -329713819;
						continue;
					case 9:
						JuzBXDTMFrDVUhqtKRLmdorveybr = P_0.JuzBXDTMFrDVUhqtKRLmdorveybr;
						EXConJjMyypIPGpmnoMnbRhdgLW = P_0.EXConJjMyypIPGpmnoMnbRhdgLW;
						num = -329713815;
						continue;
					case 11:
						mCgSEFdyltyHHshVpCgaWFFUiOPJ[num6] = P_0.mCgSEFdyltyHHshVpCgaWFFUiOPJ[num6];
						num6++;
						num = -329713819;
						continue;
					case 8:
						return;
					case 0:
						if (num6 >= MathTools.Min(mCgSEFdyltyHHshVpCgaWFFUiOPJ.Length, P_0.mCgSEFdyltyHHshVpCgaWFFUiOPJ.Length))
						{
							num4 = 0;
							num = -329713823;
							continue;
						}
						goto case 11;
					case 3:
						num3 = 0;
						num = -329713821;
						continue;
					case 1:
						UeCdPcJARqFdGACIKPtkWZxawHVX[num3] = P_0.UeCdPcJARqFdGACIKPtkWZxawHVX[num3];
						num3++;
						num = -329713821;
						continue;
					case 7:
						break;
					case 10:
						nXfUtvmmBgAjTbwJUcuGGaPmoRlF[num4] = P_0.nXfUtvmmBgAjTbwJUcuGGaPmoRlF[num4];
						num4++;
						num = -329713823;
						continue;
					case 6:
						if (num3 >= MathTools.Min(UeCdPcJARqFdGACIKPtkWZxawHVX.Length, P_0.UeCdPcJARqFdGACIKPtkWZxawHVX.Length))
						{
							YhPoJfQiAmHSpianQZbJomoJUOB = P_0.YhPoJfQiAmHSpianQZbJomoJUOB;
							num = -329713817;
							continue;
						}
						goto case 1;
					case 2:
						return;
					}
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
				bool[] buttons = AUIdfqdotGKPVLbiMbUhWyorbHfX.Buttons;
				int[] hatValues = AUIdfqdotGKPVLbiMbUhWyorbHfX.HatValues;
				int num = 336800473;
				while (true)
				{
					switch (num ^ 0x14132ADB)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						TcQALxknWBDsjjDgfcKnpyWUiBqK(buttons, hatValues);
						aGwDgiXyNNqhCEqcVEYQleQFBPn(buttons, hatValues);
						return;
					}
					break;
					IL_0009:
					num = 336800474;
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
				if (bxgcDFqOQApgYslsUNoAyTPhJYH == dataUpdater.axisCount)
				{
					int num;
					int num2;
					if (opznTvXijlFgLFSdvYEAiweymVQ == dataUpdater.buttonCount)
					{
						num = -1091015270;
						num2 = num;
					}
					else
					{
						num = -1091015274;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1091015277)
						{
						case 0:
							num = -1091015266;
							continue;
						default:
							return;
						case 13:
							break;
						case 10:
							goto IL_008a;
						case 11:
							if (num3 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
							{
								num4 = 0;
								num = -1091015269;
								continue;
							}
							goto case 3;
						case 3:
							dataUpdater.axisValues[num3] = UeCdPcJARqFdGACIKPtkWZxawHVX[num3];
							num3++;
							num = -1091015272;
							continue;
						case 9:
							num3 = 0;
							num = -1091015272;
							continue;
						case 8:
							num = -1091015271;
							continue;
						case 6:
							dataUpdater.buttonPressureValues[num4] = mCgSEFdyltyHHshVpCgaWFFUiOPJ[num4];
							num = -1091015267;
							continue;
						case 2:
							num4++;
							num = -1091015271;
							continue;
						case 5:
							goto IL_0118;
						case 12:
							dataUpdater.buttonValues[num4] = ((mCgSEFdyltyHHshVpCgaWFFUiOPJ[num4] > 0f) ? true : false);
							num = -1091015279;
							continue;
						case 7:
							if (YhPoJfQiAmHSpianQZbJomoJUOB && !dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = -1091015273;
								continue;
							}
							return;
						case 1:
							goto IL_0173;
						case 14:
							num = -1091015279;
							continue;
						case 4:
							return;
						}
						break;
						IL_0173:
						int num5;
						if (nXfUtvmmBgAjTbwJUcuGGaPmoRlF[num4])
						{
							num = -1091015275;
							num5 = num;
						}
						else
						{
							num = -1091015265;
							num5 = num;
						}
						continue;
						IL_008a:
						int num6;
						if (num4 >= opznTvXijlFgLFSdvYEAiweymVQ)
						{
							num = -1091015276;
							num6 = num;
						}
						else
						{
							num = -1091015278;
							num6 = num;
						}
					}
					continue;
				}
				goto IL_0118;
				IL_0118:
				throw new Exception("This controller signature does not match the data object!");
			}
		}

		public int FcvkUyKypZmJCfGSpczJhAaNNjEx(lYLjuNkLxblMGskfekgsFxSEpiX P_0)
		{
			if (!IsValid)
			{
				return 0;
			}
			if (P_0.EXConJjMyypIPGpmnoMnbRhdgLW == EXConJjMyypIPGpmnoMnbRhdgLW)
			{
				return 2;
			}
			if (qhBaQiBUaifpRBvldoZTqTDFPFqY != P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY)
			{
				return 0;
			}
			if (lenAIRsoOFqjBdbpibHDlBXGVmR != P_0.lenAIRsoOFqjBdbpibHDlBXGVmR)
			{
				goto IL_0038;
			}
			if (QQactFjAyaivYJCKROwerenGIZRE != P_0.QQactFjAyaivYJCKROwerenGIZRE)
			{
				return 0;
			}
			int num;
			if (hasDriver != P_0.hasDriver)
			{
				num = 178824554;
			}
			else
			{
				if (P_0.instanceGuid == instanceGuid)
				{
					return 2;
				}
				if (!(P_0.LFrLHWCZQzUjUEpwygbljLuHiCF == LFrLHWCZQzUjUEpwygbljLuHiCF))
				{
					return 0;
				}
				num = 178824552;
			}
			goto IL_003d;
			IL_003d:
			switch (num ^ 0xAA8A56A)
			{
			case 3:
				break;
			case 1:
				return 0;
			case 0:
				return 0;
			default:
				return 1;
			}
			goto IL_0038;
			IL_0038:
			num = 178824555;
			goto IL_003d;
		}

		private BridgedControllerHWInfo GcYjAXCLyrkmacLFLclUoLjdDBr()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedControllerHWInfo);
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
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(EXConJjMyypIPGpmnoMnbRhdgLW);
		}

		private void TcQALxknWBDsjjDgfcKnpyWUiBqK(bool[] P_0, int[] P_1)
		{
			if (bxgcDFqOQApgYslsUNoAyTPhJYH <= 0)
			{
				return;
			}
			int num5 = default(int);
			HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_InternalDriver_Base.Axis[]);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig3 = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			int num3 = default(int);
			int num4 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			while (true)
			{
				InputPlatform platform = UDBtEeitridwJAiaUtqcfFDaFaI.map.platform;
				int num;
				int num2;
				if (platform != InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM)
				{
					num = 2128449874;
					num2 = num;
				}
				else
				{
					num = 2128449883;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7EDD915D)
					{
					case 12:
						num = 2128449877;
						continue;
					default:
						return;
					case 2:
					{
						int num7;
						if (num5 >= axes_orig.Length)
						{
							num = 2128449878;
							num7 = num;
						}
						else
						{
							num = 2128449882;
							num7 = num;
						}
						continue;
					}
					case 15:
					{
						int num6;
						if (platform != InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv)
						{
							num = 2128449879;
							num6 = num;
						}
						else
						{
							num = 2128449886;
							num6 = num;
						}
						continue;
					}
					case 3:
					{
						HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
						axes_orig3 = platform_DirectInput_Base.Axes_orig;
						if (axes_orig3 == null)
						{
							return;
						}
						goto case 16;
					}
					case 4:
						num3 = 0;
						num = 2128449885;
						continue;
					case 8:
						break;
					case 16:
						num4 = 0;
						num = 2128449875;
						continue;
					case 1:
						num5 = 0;
						num = 2128449887;
						continue;
					case 7:
						IDhAxysgaHZRDwYCdUgRmfDPJFx(axes_orig[num5], num5, P_0, P_1);
						num5++;
						num = 2128449887;
						continue;
					case 14:
						if (num4 >= axes_orig3.Length)
						{
							return;
						}
						goto case 5;
					case 6:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
						axes_orig2 = platform_RawInput_Base.Axes_orig;
						if (axes_orig2 == null)
						{
							return;
						}
						goto case 4;
					}
					case 0:
						if (num3 >= axes_orig2.Length)
						{
							return;
						}
						goto case 13;
					case 5:
						MESJAHDhCuoZzFfOnSstZllUyWn(axes_orig3[num4], num4, P_0, P_1);
						num4++;
						num = 2128449875;
						continue;
					case 10:
						if (platform == InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc)
						{
							HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
							axes_orig = platform_InternalDriver_Base.Axes_orig;
							if (axes_orig == null)
							{
								return;
							}
							goto case 1;
						}
						return;
					case 9:
						num3++;
						num = 2128449885;
						continue;
					case 13:
						MESJAHDhCuoZzFfOnSstZllUyWn(axes_orig2[num3], num3, P_0, P_1);
						num = 2128449876;
						continue;
					case 11:
						return;
					}
					break;
				}
			}
		}

		private void aGwDgiXyNNqhCEqcVEYQleQFBPn(bool[] P_0, int[] P_1)
		{
			if (opznTvXijlFgLFSdvYEAiweymVQ <= 0)
			{
				return;
			}
			int num5 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num3 = default(int);
			HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig3 = default(HardwareJoystickMap.Platform_InternalDriver_Base.Button[]);
			HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = default(HardwareJoystickMap.Platform_InternalDriver_Base);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			int num6 = default(int);
			while (true)
			{
				InputPlatform platform = UDBtEeitridwJAiaUtqcfFDaFaI.map.platform;
				int num = -538399455;
				while (true)
				{
					switch (num ^ -538399442)
					{
					case 20:
						num = -538399451;
						continue;
					default:
						return;
					case 11:
						break;
					case 0:
						num5 = 0;
						num = -538399452;
						continue;
					case 18:
						SPXGYihGXHFuAFquACCBaZiSvIdu(buttons_orig[num3], num3, P_0, P_1);
						num3++;
						num = -538399441;
						continue;
					case 10:
					{
						int num9;
						if (num5 >= buttons_orig3.Length)
						{
							num = -538399446;
							num9 = num;
						}
						else
						{
							num = -538399449;
							num9 = num;
						}
						continue;
					}
					case 3:
						if (platform == InputPlatform.ZttKGDSUEbTObEfblEyIYTXbRoc)
						{
							platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
							num = -538399427;
							continue;
						}
						return;
					case 19:
						buttons_orig3 = platform_InternalDriver_Base.Buttons_orig;
						num = -538399450;
						continue;
					case 1:
					{
						int num4;
						if (num3 < buttons_orig.Length)
						{
							num = -538399428;
							num4 = num;
						}
						else
						{
							num = -538399447;
							num4 = num;
						}
						continue;
					}
					case 17:
						return;
					case 7:
						return;
					case 9:
						nhNNgCqisXQvxYkmEoXExPTIwgD(buttons_orig3[num5], num5, P_0, P_1);
						num5++;
						num = -538399452;
						continue;
					case 8:
						if (buttons_orig3 == null)
						{
							return;
						}
						goto case 0;
					case 16:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
						buttons_orig2 = platform_RawInput_Base.Buttons_orig;
						int num8;
						if (buttons_orig2 != null)
						{
							num = -538399453;
							num8 = num;
						}
						else
						{
							num = -538399425;
							num8 = num;
						}
						continue;
					}
					case 5:
						num3 = 0;
						num = -538399441;
						continue;
					case 2:
						if (platform == InputPlatform.nxzcJmevYVMAWQJHQoCKKweYMfMv)
						{
							HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map;
							buttons_orig = platform_DirectInput_Base.Buttons_orig;
							int num7;
							if (buttons_orig == null)
							{
								num = -538399454;
								num7 = num;
							}
							else
							{
								num = -538399445;
								num7 = num;
							}
							continue;
						}
						goto case 3;
					case 12:
						return;
					case 13:
						num6 = 0;
						num = -538399456;
						continue;
					case 6:
						SPXGYihGXHFuAFquACCBaZiSvIdu(buttons_orig2[num6], num6, P_0, P_1);
						num6++;
						num = -538399456;
						continue;
					case 14:
						if (num6 >= buttons_orig2.Length)
						{
							return;
						}
						goto case 6;
					case 15:
					{
						int num2;
						if (platform == InputPlatform.TxthorEPmOLBHYyZxIReALnmNeM)
						{
							num = -538399426;
							num2 = num;
						}
						else
						{
							num = -538399444;
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

		private void MESJAHDhCuoZzFfOnSstZllUyWn(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
			{
				goto IL_0009;
			}
			goto IL_0041;
			IL_0009:
			int num = 747467302;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x2C8D7222)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				case 3:
					goto IL_0041;
				case 0:
					if (!YhPoJfQiAmHSpianQZbJomoJUOB && UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] != 0f)
					{
						YhPoJfQiAmHSpianQZbJomoJUOB = true;
						num = 747467299;
						continue;
					}
					return;
				case 1:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0041:
			UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] = LaNWitWQqyZMqUSPioBpzBMOpwf(P_0, P_2, P_3);
			num = 747467298;
			goto IL_000e;
		}

		private void SPXGYihGXHFuAFquACCBaZiSvIdu(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= opznTvXijlFgLFSdvYEAiweymVQ)
			{
				goto IL_0009;
			}
			goto IL_0066;
			IL_0009:
			int num = 758828006;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x2D3ACBE2)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				case 0:
					if (!YhPoJfQiAmHSpianQZbJomoJUOB && mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1] != 0f)
					{
						YhPoJfQiAmHSpianQZbJomoJUOB = true;
						num = 758828000;
						continue;
					}
					return;
				case 1:
					goto IL_0066;
				case 2:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0066:
			mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1] = fjKDuIFmYPFHshMFIEKwpUOEovgL(P_0, P_2, P_3);
			num = 758828002;
			goto IL_000e;
		}

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				goto IL_000c;
			}
			int num;
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				num = 1672376347;
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					return 0f;
				}
				num = 1672376327;
			}
			else
			{
				sourceHat = P_0.sourceHat;
				int num2;
				if (sourceHat >= 0)
				{
					num = 1672376338;
					num2 = num;
				}
				else
				{
					num = 1672376331;
					num2 = num;
				}
			}
			goto IL_0011;
			IL_0011:
			int sourceButton = default(int);
			float result = default(float);
			int sourceAxis = default(int);
			int num4 = default(int);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num3 = default(int);
			CustomCalculation customCalculation = default(CustomCalculation);
			float num6 = default(float);
			while (true)
			{
				int num9;
				switch (num ^ 0x63AE7009)
				{
				case 21:
					break;
				case 19:
					if (sourceButton >= 256)
					{
						num = 1672376351;
						continue;
					}
					if (!P_1[sourceButton])
					{
						num = 1672376332;
						continue;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = 1672376335;
						continue;
					}
					goto case 1;
				case 20:
					return 0f;
				case 3:
				case 13:
					return LaNWitWQqyZMqUSPioBpzBMOpwf((RawInputAxis)sourceAxis, num4);
				case 28:
					return 0f;
				case 26:
				{
					HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType;
					HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
					int num11;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis)
					{
						num = 1672376350;
						num11 = num;
					}
					else
					{
						num = 1672376325;
						num11 = num;
					}
					continue;
				}
				case 14:
					customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						num = 1672376343;
						continue;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						return 0f;
					}
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num3 = 0;
					num = 1672376326;
					continue;
				case 29:
				{
					int num8;
					if (customCalculationSourceData[num3] == null)
					{
						num = 1672376325;
						num8 = num;
					}
					else
					{
						num = 1672376339;
						num8 = num;
					}
					continue;
				}
				case 15:
					num = 1672376344;
					continue;
				case 10:
					return 0f;
				case 25:
					if (sourceButton >= 0)
					{
						int num10;
						if (sourceButton < lenAIRsoOFqjBdbpibHDlBXGVmR)
						{
							num = 1672376346;
							num10 = num;
						}
						else
						{
							num = 1672376351;
							num10 = num;
						}
						continue;
					}
					goto case 22;
				case 9:
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num6 < 0f)
							{
								num = 1672376321;
								continue;
							}
						}
						else if (num6 > 0f)
						{
							num = 1672376341;
							continue;
						}
					}
					goto IL_00df;
				case 16:
				{
					int num5;
					if (sourceAxis != 1000)
					{
						num = 1672376349;
						num5 = num;
					}
					else
					{
						num = 1672376329;
						num5 = num;
					}
					continue;
				}
				case 2:
					return 0f;
				case 23:
				{
					if (BdEWXKXXzeZJqVCqxkREiNpHGeq(customCalculationSourceData[num3], out var item))
					{
						customCalculation.AddData(item);
						num = 1672376325;
						continue;
					}
					goto case 12;
				}
				case 4:
					sourceAxis = P_0.sourceAxis;
					switch (sourceAxis)
					{
					case 0:
						num = 1672376322;
						continue;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 11:
						num4 = 0;
						num = 1672376324;
						continue;
					}
					goto case 16;
				case 27:
					if (sourceHat < QQactFjAyaivYJCKROwerenGIZRE)
					{
						if (sourceHat < 4)
						{
							int num7 = P_2[sourceHat];
							if (num7 < 0)
							{
								return 0f;
							}
							if (P_0.sourceHatDirection != AxisDirection.Horizontal)
							{
								num6 = cTBJQWNJnVBISfYRgepYNiZKpVs(num7, AxisDirection.Vertical);
								num = 1672376320;
								continue;
							}
							num6 = cTBJQWNJnVBISfYRgepYNiZKpVs(num7, AxisDirection.Horizontal);
							if (P_0.sourceHatRange != AxisRange.Full)
							{
								if (P_0.sourceHatRange != AxisRange.Positive)
								{
									if (num6 > 0f)
									{
										return 0f;
									}
								}
								else if (num6 < 0f)
								{
									num = 1672376323;
									continue;
								}
							}
							goto IL_00df;
						}
						num = 1672376331;
						continue;
					}
					goto case 2;
				case 30:
					return 0f;
				case 7:
					return num6;
				case 24:
					num6 *= -1f;
					num = 1672376334;
					continue;
				case 11:
					return 0f;
				case 8:
					return 0f;
				case 12:
					num3++;
					num = 1672376344;
					continue;
				case 1:
					result = -1f;
					num = 1672376335;
					continue;
				case 0:
					if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Axis axis))
					{
						return 0f;
					}
					num4 = axis.sourceOtherAxis;
					num = 1672376330;
					continue;
				case 22:
					return 0f;
				case 5:
					return 0f;
				case 18:
					sourceButton = P_0.sourceButton;
					num = 1672376336;
					continue;
				case 6:
					return result;
				default:
					{
						if (num3 >= customCalculationSourceData.Length)
						{
							if (!customCalculation.Process())
							{
								return 0f;
							}
							if (customCalculation.Result.type != TypeWrapper.DataType.Single)
							{
								return 0f;
							}
							return customCalculation.Result;
						}
						goto case 29;
					}
					IL_00df:
					if (!P_0.invert)
					{
						num = 1672376334;
						num9 = num;
					}
					else
					{
						num = 1672376337;
						num9 = num;
					}
					continue;
				}
				break;
			}
			goto IL_000c;
			IL_000c:
			num = 1672376333;
			goto IL_0011;
		}

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(RawInputAxis P_0, int P_1)
		{
			return oMNnXrBObsqXntKHDHpZyOhNBhe((GnIhWyhRgHiOpzVFKrnEEvuLLfX as btyGStVvEsLNfhSsaBhklVtiGypg).LaNWitWQqyZMqUSPioBpzBMOpwf(P_0, P_1));
		}

		private float fjKDuIFmYPFHshMFIEKwpUOEovgL(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					num = 0;
					goto IL_0018;
				}
				goto IL_023f;
			}
			int sourceAxis = default(int);
			int num2;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num4 = default(int);
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				int num3;
				if (sourceAxis == 0)
				{
					num2 = 1189980444;
				}
				else if (sourceAxis < 1)
				{
					num2 = 1189980428;
					num3 = num2;
				}
				else
				{
					num2 = 1189980438;
					num3 = num2;
				}
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_05b9;
				}
				customCalculation = P_0.customCalculation;
				if (!(customCalculation == null))
				{
					if (customCalculation.ResultType == TypeWrapper.DataType.Single)
					{
						customCalculationSourceData = P_0.customCalculationSourceData;
						if (customCalculationSourceData == null)
						{
							return 0f;
						}
						num4 = 0;
						num2 = 1189980436;
					}
					else
					{
						num2 = 1189980430;
					}
				}
				else
				{
					num2 = 1189980440;
				}
			}
			else
			{
				sourceHat = P_0.sourceHat;
				num2 = 1189980445;
			}
			goto IL_001d;
			IL_05b9:
			return 0f;
			IL_023f:
			if (!P_0.requireMultipleButtons)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= lenAIRsoOFqjBdbpibHDlBXGVmR)
				{
					goto IL_00b9;
				}
				if (sourceButton < 256)
				{
					if (P_1[sourceButton])
					{
						return 1f;
					}
					num2 = 1189980425;
				}
				else
				{
					num2 = 1189980421;
				}
			}
			else
			{
				num2 = 1189980431;
			}
			goto IL_001d;
			IL_0018:
			num2 = 1189980417;
			goto IL_001d;
			IL_001d:
			bool flag3 = default(bool);
			bool flag2 = default(bool);
			bool flag = default(bool);
			int num5 = default(int);
			while (true)
			{
				float num6;
				switch (num2 ^ 0x46EDA904)
				{
				case 3:
					break;
				case 1:
					goto IL_00b9;
				case 32:
					return 0f;
				case 13:
					return 0f;
				case 10:
					return 0f;
				case 21:
					goto IL_0136;
				case 34:
					goto IL_0148;
				case 16:
					if (num4 >= customCalculationSourceData.Length)
					{
						flag3 = customCalculation.Process();
						num2 = 1189980443;
						continue;
					}
					goto case 33;
				case 12:
					num4++;
					num2 = 1189980436;
					continue;
				case 9:
					goto IL_01b4;
				case 14:
					goto IL_01d3;
				case 26:
					num2 = 1189980424;
					continue;
				case 22:
					goto IL_0207;
				case 17:
					goto IL_0220;
				case 29:
					goto IL_023f;
				case 31:
					goto IL_0254;
				case 28:
					return 0f;
				case 2:
					goto IL_02b3;
				case 19:
					customCalculation.AddData(flag2 ? 1f : 0f);
					num2 = 1189980446;
					continue;
				case 11:
					flag = false;
					num5 = 0;
					num2 = 1189980429;
					continue;
				case 24:
					return 0f;
				case 0:
					return 0f;
				case 33:
					if (customCalculationSourceData[num4] != null)
					{
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num4].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
							goto IL_043f;
						case HardwareElementSourceTypeWithHat.Axis:
							goto IL_0471;
						}
						num2 = 1189980424;
						continue;
					}
					goto case 12;
				case 18:
					goto IL_039e;
				case 15:
					goto IL_03b8;
				case 25:
					if (sourceHat >= 0)
					{
						goto IL_03dd;
					}
					goto case 4;
				case 4:
					return 0f;
				case 23:
					goto IL_043f;
				case 27:
					num5++;
					num2 = 1189980429;
					continue;
				case 30:
					goto IL_0471;
				case 6:
					goto IL_04a9;
				case 20:
					return 0f;
				case 8:
					goto IL_0586;
				case 5:
					num2 = 1189980437;
					continue;
				default:
					{
						return 0f;
					}
					IL_0471:
					if (BdEWXKXXzeZJqVCqxkREiNpHGeq(customCalculationSourceData[num4], out num6))
					{
						customCalculation.AddData((num6 != 0f) ? 1f : 0f);
						num2 = 1189980424;
						continue;
					}
					goto case 12;
				}
				break;
				IL_0586:
				int num7;
				if (sourceAxis != 1000)
				{
					num2 = 1189980420;
					num7 = num2;
				}
				else
				{
					num2 = 1189980426;
					num7 = num2;
				}
				continue;
				IL_01b4:
				int num8;
				if (num5 < P_0.requiredButtons.Length)
				{
					num2 = 1189980434;
					num8 = num2;
				}
				else
				{
					num2 = 1189980454;
					num8 = num2;
				}
				continue;
				IL_043f:
				int num9;
				if (!eKDLpJuQWMVUcppIKLCJIoZTxZP(customCalculationSourceData[num4], P_1, out flag2))
				{
					num2 = 1189980424;
					num9 = num2;
				}
				else
				{
					num2 = 1189980439;
					num9 = num2;
				}
				continue;
				IL_03dd:
				int num10;
				if (sourceHat < QQactFjAyaivYJCKROwerenGIZRE)
				{
					num2 = 1189980433;
					num10 = num2;
				}
				else
				{
					num2 = 1189980416;
					num10 = num2;
				}
				continue;
				IL_0254:
				if (!flag3)
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				if ((float)customCalculation.Result == 0f)
				{
					num2 = 1189980419;
					continue;
				}
				return 1f;
				IL_0207:
				if (P_1[P_0.requiredButtons[num5]])
				{
					flag = true;
					num2 = 1189980447;
				}
				else
				{
					num2 = 1189980452;
				}
				continue;
				IL_03b8:
				if (P_1[P_0.ignoreIfButtonsActiveButtons[num]])
				{
					return 0f;
				}
				num++;
				num2 = 1189980437;
				continue;
				IL_0136:
				if (sourceHat >= 4)
				{
					num2 = 1189980416;
					continue;
				}
				goto IL_0401;
				IL_0220:
				int num11;
				if (num >= P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num2 = 1189980441;
					num11 = num2;
				}
				else
				{
					num2 = 1189980427;
					num11 = num2;
				}
				continue;
				IL_039e:
				int num12;
				if (sourceAxis > 11)
				{
					num2 = 1189980428;
					num12 = num2;
				}
				else
				{
					num2 = 1189980422;
					num12 = num2;
				}
				continue;
				IL_0316:
				int num14;
				float num13 = LaNWitWQqyZMqUSPioBpzBMOpwf((RawInputAxis)sourceAxis, num14);
				float num15 = MathTools.Abs(num13);
				if (num15 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num13 < 0f)
					{
						return 0f;
					}
				}
				else if (num13 > 0f)
				{
					num2 = 1189980432;
					continue;
				}
				return num15;
				IL_01d3:
				if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Button button))
				{
					return 0f;
				}
				num14 = button.sourceOtherAxis;
				goto IL_0316;
				IL_02b3:
				num14 = 0;
				goto IL_0316;
			}
			goto IL_0018;
			IL_04a9:
			return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 0, P_0.sourceHatType);
			IL_0148:
			if (flag)
			{
				return 1f;
			}
			return 0f;
			IL_0401:
			switch (P_0.sourceHatDirection)
			{
			case HatDirection.Up:
				break;
			case HatDirection.UpRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 1, P_0.sourceHatType);
			case HatDirection.Right:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 2, P_0.sourceHatType);
			case HatDirection.DownRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 3, P_0.sourceHatType);
			case HatDirection.Down:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 4, P_0.sourceHatType);
			case HatDirection.DownLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 5, P_0.sourceHatType);
			case HatDirection.Left:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 6, P_0.sourceHatType);
			case HatDirection.UpLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 7, P_0.sourceHatType);
			default:
				goto IL_05b9;
			}
			goto IL_04a9;
			IL_00b9:
			return 0f;
		}

		private float oMNnXrBObsqXntKHDHpZyOhNBhe(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float rtBKMWyfBZOyTgZEbLolEBtLHfb(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (UDBtEeitridwJAiaUtqcfFDaFaI.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return 0f;
			}
			if (P_2 == HatType.EightWay)
			{
				goto IL_0043;
			}
			goto IL_0093;
			IL_0043:
			int num3 = 8306008;
			goto IL_0048;
			IL_00a6:
			int num4 = default(int);
			if (P_0 < num2 + num4 && P_0 > num2 - num4)
			{
				return 1f;
			}
			return 0f;
			IL_0048:
			int num5 = default(int);
			while (true)
			{
				switch (num3 ^ 0x7EBD59)
				{
				case 3:
					break;
				case 1:
					num5 = 31500;
					num4 = 4500;
					num3 = 8306013;
					continue;
				case 4:
					if (P_1 == 0 && P_0 > num5)
					{
						P_0 -= 36000;
						num3 = 8306009;
						continue;
					}
					goto IL_00a6;
				case 2:
					goto IL_0093;
				default:
					goto IL_00a6;
				}
				break;
			}
			goto IL_0043;
			IL_0093:
			num5 = 27000;
			num4 = 9000;
			num3 = 8306013;
			goto IL_0048;
		}

		private float cTBJQWNJnVBISfYRgepYNiZKpVs(int P_0, AxisDirection P_1)
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
			if (P_0 <= 0 || P_0 >= 18000)
			{
				if (P_0 <= 18000)
				{
					return 0f;
				}
				num = 319764573;
			}
			else
			{
				num = 319764570;
			}
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x130F385F)
				{
				case 0:
					break;
				case 5:
					return 1f;
				case 3:
					return -1f;
				case 4:
					return 1f;
				case 1:
					if (P_0 <= 27000)
					{
						if (P_0 >= 9000)
						{
							if (P_0 >= 27000 || P_0 <= 9000)
							{
								return 0f;
							}
							num = 319764572;
						}
						else
						{
							num = 319764571;
						}
						continue;
					}
					goto case 4;
				default:
					return -1f;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 319764574;
			goto IL_0012;
		}

		private bool eKDLpJuQWMVUcppIKLCJIoZTxZP(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			int sourceButton = default(int);
			while (true)
			{
				int num = -1536266037;
				while (true)
				{
					switch (num ^ -1536266039)
					{
					case 0:
						break;
					case 2:
						if (P_0.sourceType != 0)
						{
							return false;
						}
						sourceButton = P_0.sourceButton;
						if (sourceButton >= 0)
						{
							int num2;
							if (sourceButton >= lenAIRsoOFqjBdbpibHDlBXGVmR)
							{
								num = -1536266040;
								num2 = num;
							}
							else
							{
								num = -1536266038;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 3:
						if (sourceButton >= 256)
						{
							num = -1536266040;
							continue;
						}
						P_2 = P_1[sourceButton];
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		private bool BdEWXKXXzeZJqVCqxkREiNpHGeq(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				goto IL_0013;
			}
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = LaNWitWQqyZMqUSPioBpzBMOpwf((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Positive:
				goto IL_012f;
			case AxisRange.Negative:
				goto IL_01ad;
			}
			int num = -1514318178;
			goto IL_0018;
			IL_01ad:
			if (P_1 > 0f)
			{
				P_1 = 0f;
				num = -1514318178;
				goto IL_0018;
			}
			goto IL_00d3;
			IL_00d3:
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
				num = -1514318183;
				goto IL_0018;
			}
			goto IL_0112;
			IL_0112:
			int num2;
			if (P_0.axisCalibrationType != AxisCalibrationType.Custom)
			{
				num = -1514318181;
				num2 = num;
			}
			else
			{
				num = -1514318190;
				num2 = num;
			}
			goto IL_0018;
			IL_012f:
			if (P_1 < 0f)
			{
				P_1 = 0f;
				num = -1514318178;
				goto IL_0018;
			}
			goto IL_00d3;
			IL_0013:
			num = -1514318180;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -1514318181)
				{
				case 10:
					break;
				case 0:
					goto IL_0058;
				case 3:
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
						num = -1514318183;
						continue;
					}
					goto default;
				case 7:
					return false;
				case 5:
					goto IL_00d3;
				case 8:
					goto IL_0112;
				case 6:
					goto IL_012f;
				case 9:
					P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
					num = -1514318182;
					continue;
				case 4:
					goto IL_0182;
				case 1:
					num = -1514318183;
					continue;
				case 11:
					goto IL_01ad;
				default:
					return true;
				}
				break;
				IL_0182:
				int num3;
				if (P_0.axisDeadZone <= 0f)
				{
					num = -1514318183;
					num3 = num;
				}
				else
				{
					num = -1514318184;
					num3 = num;
				}
				continue;
				IL_0058:
				int num4;
				if (P_0.axisCalibrationType != AxisCalibrationType.Uncalibrated)
				{
					num = -1514318183;
					num4 = num;
				}
				else
				{
					num = -1514318177;
					num4 = num;
				}
			}
			goto IL_0013;
		}

		private ControlDeviceType jmeBesFqRIhxcAWkiwiTAvlUrSyI(DeviceType P_0)
		{
			switch (P_0)
			{
			case DeviceType.Keyboard:
				return ControlDeviceType.rCRUfGMYcabNQcwJmpNrFXaJmFK;
			case DeviceType.Joystick:
				return ControlDeviceType.etApNsmaydFifFQZNkCXGYFhvYDz;
			case DeviceType.Gamepad:
				return ControlDeviceType.rlDBEAevYUudHNlWSHcStzDSfSse;
			case DeviceType.Mouse:
				return ControlDeviceType.ONOENoDqLOAvQwxgTsKnLgJYNZAF;
			case DeviceType.MultiAxisController:
				return ControlDeviceType.etApNsmaydFifFQZNkCXGYFhvYDz;
			default:
				return ControlDeviceType.mWddvsAGGdWECRlxCOhehpBItyh;
			}
		}

		private void IDhAxysgaHZRDwYCdUgRmfDPJFx(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= bxgcDFqOQApgYslsUNoAyTPhJYH)
			{
				goto IL_0009;
			}
			goto IL_003d;
			IL_0009:
			int num = 1678130265;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x64063C5A)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			case 1:
				goto IL_003d;
			case 2:
				return;
			}
			goto IL_0009;
			IL_003d:
			UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] = rVlxPzpldtBRpHDvhPCTwkUUzQOi(P_0, P_2, P_3);
			if (!YhPoJfQiAmHSpianQZbJomoJUOB && UeCdPcJARqFdGACIKPtkWZxawHVX[P_1] != 0f)
			{
				YhPoJfQiAmHSpianQZbJomoJUOB = true;
				num = 1678130264;
				goto IL_000e;
			}
		}

		private void nhNNgCqisXQvxYkmEoXExPTIwgD(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= opznTvXijlFgLFSdvYEAiweymVQ)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1] = VSKZMTmkDbDljCgYfpfKFAQyLSS(P_0, P_2, P_3);
				if (YhPoJfQiAmHSpianQZbJomoJUOB || mCgSEFdyltyHHshVpCgaWFFUiOPJ[P_1] == 0f)
				{
					break;
				}
				YhPoJfQiAmHSpianQZbJomoJUOB = true;
				int num = 594022720;
				while (true)
				{
					switch (num ^ 0x23681142)
					{
					case 0:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0014:
					num = 594022723;
				}
			}
		}

		private float rVlxPzpldtBRpHDvhPCTwkUUzQOi(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			int sourceAxis = default(int);
			if (P_0.sourceType == 1)
			{
				sourceAxis = P_0.sourceAxis;
				goto IL_0013;
			}
			int num;
			int sourceButton = default(int);
			if (P_0.sourceType != 0)
			{
				if (P_0.sourceType != 2)
				{
					return 0f;
				}
				num = 947010850;
			}
			else
			{
				sourceButton = P_0.sourceButton;
				int num2;
				if (sourceButton >= 0)
				{
					num = 947010851;
					num2 = num;
				}
				else
				{
					num = 947010852;
					num2 = num;
				}
			}
			goto IL_0018;
			IL_0013:
			num = 947010861;
			goto IL_0018;
			IL_0018:
			float result = default(float);
			int sourceHat = default(int);
			int num5 = default(int);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ 0x38723D2A)
				{
				case 2:
					break;
				case 13:
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						num = 947010849;
						continue;
					}
					goto IL_01cf;
				case 12:
					result = -1f;
					num = 947010874;
					continue;
				case 0:
					return 0f;
				case 5:
					if (sourceHat < 4)
					{
						num5 = P_2[sourceHat];
						if (num5 < 0)
						{
							num = 947010860;
						}
						else if (P_0.sourceHatDirection != AxisDirection.Horizontal)
						{
							num3 = cTBJQWNJnVBISfYRgepYNiZKpVs(num5, AxisDirection.Vertical);
							num = 947010855;
						}
						else
						{
							num = 947010859;
						}
					}
					else
					{
						num = 947010858;
					}
					continue;
				case 10:
					return 0f;
				case 14:
					return 0f;
				case 1:
					num3 = cTBJQWNJnVBISfYRgepYNiZKpVs(num5, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							num = 947010853;
							continue;
						}
						if (num3 > 0f)
						{
							num = 947010848;
							continue;
						}
					}
					goto IL_01cf;
				case 16:
					return result;
				case 8:
					sourceHat = P_0.sourceHat;
					if (sourceHat >= 0)
					{
						int num4;
						if (sourceHat >= QQactFjAyaivYJCKROwerenGIZRE)
						{
							num = 947010858;
							num4 = num;
						}
						else
						{
							num = 947010863;
							num4 = num;
						}
						continue;
					}
					goto case 0;
				case 15:
					if (num3 < 0f)
					{
						return 0f;
					}
					goto IL_01cf;
				case 17:
					if (sourceButton < 256)
					{
						if (!P_1[sourceButton])
						{
							return 0f;
						}
						if (P_0.buttonAxisContribution == Pole.Positive)
						{
							result = 1f;
							num = 947010874;
							continue;
						}
						goto case 12;
					}
					num = 947010852;
					continue;
				case 9:
				{
					int num6;
					if (sourceButton < lenAIRsoOFqjBdbpibHDlBXGVmR)
					{
						num = 947010875;
						num6 = num;
					}
					else
					{
						num = 947010852;
						num6 = num;
					}
					continue;
				}
				case 4:
					return 0f;
				case 6:
					return 0f;
				case 7:
					if (sourceAxis >= 0 && sourceAxis < qhBaQiBUaifpRBvldoZTqTDFPFqY)
					{
						if (sourceAxis >= 56)
						{
							num = 947010857;
							continue;
						}
						return rVlxPzpldtBRpHDvhPCTwkUUzQOi(sourceAxis);
					}
					goto case 3;
				case 3:
					return 0f;
				case 11:
					if (P_0.sourceHatRange == AxisRange.Positive)
					{
						if (num3 < 0f)
						{
							return 0f;
						}
					}
					else if (num3 > 0f)
					{
						num = 947010862;
						continue;
					}
					goto IL_01cf;
				default:
					{
						return num3;
					}
					IL_01cf:
					if (P_0.invert)
					{
						num3 *= -1f;
						num = 947010872;
						continue;
					}
					goto default;
				}
				break;
			}
			goto IL_0013;
		}

		private float rVlxPzpldtBRpHDvhPCTwkUUzQOi(int P_0)
		{
			return (GnIhWyhRgHiOpzVFKrnEEvuLLfX as tWkKNCXIrnFwxZTVcetdQCqcJSr).LaNWitWQqyZMqUSPioBpzBMOpwf(P_0);
		}

		private float VSKZMTmkDbDljCgYfpfKFAQyLSS(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				goto IL_000b;
			}
			int num;
			int sourceAxis = default(int);
			if (P_0.sourceType != 1)
			{
				if (P_0.sourceType != 2)
				{
					goto IL_0265;
				}
				num = -323052699;
			}
			else
			{
				sourceAxis = P_0.sourceAxis;
				num = -323052698;
			}
			goto IL_0010;
			IL_01dd:
			int sourceHat = default(int);
			return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 0, P_0.sourceHatType);
			IL_0265:
			return 0f;
			IL_00c8:
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
			IL_0140:
			HatDirection sourceHatDirection = default(HatDirection);
			switch (sourceHatDirection)
			{
			case HatDirection.Up:
				break;
			case HatDirection.UpRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 1, P_0.sourceHatType);
			case HatDirection.Right:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 2, P_0.sourceHatType);
			case HatDirection.DownRight:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 3, P_0.sourceHatType);
			case HatDirection.Down:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 4, P_0.sourceHatType);
			case HatDirection.DownLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 5, P_0.sourceHatType);
			case HatDirection.Left:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 6, P_0.sourceHatType);
			case HatDirection.UpLeft:
				return rtBKMWyfBZOyTgZEbLolEBtLHfb(P_2[sourceHat], 7, P_0.sourceHatType);
			default:
				goto IL_0265;
			}
			goto IL_01dd;
			IL_000b:
			num = -323052700;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				int sourceButton;
				switch (num ^ -323052703)
				{
				case 0:
					break;
				case 5:
					sourceButton = P_0.sourceButton;
					if (sourceButton >= 0 && sourceButton < lenAIRsoOFqjBdbpibHDlBXGVmR)
					{
						goto IL_006e;
					}
					goto case 9;
				case 8:
					return 0f;
				case 2:
					goto IL_0098;
				case 7:
					if (sourceAxis < 0)
					{
						goto case 8;
					}
					goto IL_00ab;
				case 11:
					goto IL_00c8;
				case 12:
					if (sourceHat >= 0 && sourceHat < QQactFjAyaivYJCKROwerenGIZRE)
					{
						goto IL_012f;
					}
					goto case 1;
				case 6:
					goto IL_0140;
				case 10:
					return 0f;
				case 9:
					return 0f;
				case 4:
					sourceHat = P_0.sourceHat;
					num = -323052691;
					continue;
				case 1:
					return 0f;
				default:
					goto IL_01dd;
				}
				break;
				IL_012f:
				if (sourceHat >= 4)
				{
					num = -323052704;
					continue;
				}
				sourceHatDirection = P_0.sourceHatDirection;
				num = -323052697;
				continue;
				IL_0098:
				if (sourceAxis < 56)
				{
					num2 = rVlxPzpldtBRpHDvhPCTwkUUzQOi(sourceAxis);
					num = -323052694;
				}
				else
				{
					num = -323052695;
				}
				continue;
				IL_006e:
				if (sourceButton >= 256)
				{
					num = -323052696;
					continue;
				}
				if (P_1[sourceButton])
				{
					return 1f;
				}
				num = -323052693;
				continue;
				IL_00ab:
				int num3;
				if (sourceAxis >= qhBaQiBUaifpRBvldoZTqTDFPFqY)
				{
					num = -323052695;
					num3 = num;
				}
				else
				{
					num = -323052701;
					num3 = num;
				}
			}
			goto IL_000b;
		}

		private bool TdCjQnXiQHCmxiWFvqmQgqcIHAkv(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return false;
			}
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num3 = 31500;
				goto IL_0024;
			}
			goto IL_0090;
			IL_0024:
			int num4 = 2144570830;
			goto IL_0029;
			IL_0090:
			num3 = 27000;
			int num5 = 9000;
			num4 = 2144570828;
			goto IL_0029;
			IL_0029:
			while (true)
			{
				switch (num4 ^ 0x7FD38DCC)
				{
				case 4:
					break;
				case 0:
					if (P_1 == 0 && P_0 > num3)
					{
						P_0 -= 36000;
						num4 = 2144570826;
						continue;
					}
					goto IL_0076;
				case 3:
					goto IL_0069;
				case 6:
					goto IL_0076;
				case 2:
					num5 = 4500;
					num4 = 2144570828;
					continue;
				case 1:
					goto IL_0090;
				default:
					return true;
				}
				break;
				IL_0069:
				if (P_0 > num2 - num5)
				{
					num4 = 2144570825;
					continue;
				}
				goto IL_00a5;
				IL_00a5:
				return false;
				IL_0076:
				if (P_0 < num2 + num5)
				{
					num4 = 2144570831;
					continue;
				}
				goto IL_00a5;
			}
			goto IL_0024;
		}

		private float SAqTtBOsxkDBQVlZvHADGnTKXUk(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				goto IL_000d;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			int num;
			if (P_0 > 18000)
			{
				num = 1991849127;
				goto IL_0012;
			}
			return 0f;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x76B934A7)
				{
				case 3:
					break;
				case 1:
					if (P_0 <= 27000)
					{
						if (P_0 < 9000)
						{
							goto IL_003f;
						}
						if (P_0 < 27000 && P_0 > 9000)
						{
							return -1f;
						}
						return 0f;
					}
					goto case 2;
				case 2:
					return 1f;
				default:
					return -1f;
				}
				break;
				IL_003f:
				num = 1991849125;
			}
			goto IL_000d;
			IL_000d:
			num = 1991849126;
			goto IL_0012;
		}

		private void UVFtCXlXPJBKXqaKnfwDHhlUFOJ()
		{
			UDBtEeitridwJAiaUtqcfFDaFaI = qnewRYFCzYevHqfqyatlbQmZFOFg(GcYjAXCLyrkmacLFLclUoLjdDBr());
			if (UDBtEeitridwJAiaUtqcfFDaFaI == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			bxgcDFqOQApgYslsUNoAyTPhJYH = UDBtEeitridwJAiaUtqcfFDaFaI.axisCount;
			opznTvXijlFgLFSdvYEAiweymVQ = UDBtEeitridwJAiaUtqcfFDaFaI.buttonCount;
		}

		private string SUOCLYiMCAFBYPeppWCzWhwrMxIS()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.RawInput}{((MVCWNUJrDWfwziBxuAuBAzgJAhiF && !string.IsNullOrEmpty(OWynlsqwgASivUcmwQTMqEbSEpd)) ? OWynlsqwgASivUcmwQTMqEbSEpd : DVaqHcutoHoUrPluDMMcnunKAGA)}{sEJsjYepUiBfnYUEFbfTIGbRtAM}{jswiKSoBCTxrqereFiOojDxDRmw}");
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = AUIdfqdotGKPVLbiMbUhWyorbHfX.InputSource;
			P_0.deviceType = jmeBesFqRIhxcAWkiwiTAvlUrSyI(OrLvljLwGziixrbcxLTXKnasxGm);
			P_0.hardwareIdentifier = SUOCLYiMCAFBYPeppWCzWhwrMxIS();
			while (true)
			{
				int num = 600353237;
				while (true)
				{
					switch (num ^ 0x23C8A9D6)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						P_0.hardwareAxisCount = qhBaQiBUaifpRBvldoZTqTDFPFqY;
						P_0.hardwareButtonCount = lenAIRsoOFqjBdbpibHDlBXGVmR;
						P_0.hardwareHatCount = QQactFjAyaivYJCKROwerenGIZRE;
						P_0.hw_productName = DVaqHcutoHoUrPluDMMcnunKAGA;
						num = 600353235;
						continue;
					case 1:
						P_0.hw_bluetoothDeviceName = OWynlsqwgASivUcmwQTMqEbSEpd;
						num = 600353234;
						continue;
					case 6:
						P_0.definitionMatchTag = AUIdfqdotGKPVLbiMbUhWyorbHfX.HWDefinitionMatchTag;
						num = 600353236;
						continue;
					case 4:
						P_0.hw_supportsVibration = fIkYGLxAqHefuTpANtEKPdaCbCFc;
						P_0.hw_localVibrationMotorCount = uxkWxbOjiQcJzrqdxdEMzRAvnKk;
						num = 600353232;
						continue;
					case 5:
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_vendorId = GbjlnZOlkxhZPSOBDicayQzeaoO;
						P_0.hw_productId = sEJsjYepUiBfnYUEFbfTIGbRtAM;
						P_0.hw_pidVid = new PidVid(jswiKSoBCTxrqereFiOojDxDRmw);
						P_0.hw_isBluetoothDevice = MVCWNUJrDWfwziBxuAuBAzgJAhiF;
						num = 600353239;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedController P_0)
		{
			dGqnYVYWgCeqfZEbphqNBhbNleek((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			while (true)
			{
				int num = -1205107807;
				while (true)
				{
					switch (num ^ -1205107808)
					{
					case 2:
						break;
					case 1:
						P_0.gameHardwareMap = UDBtEeitridwJAiaUtqcfFDaFaI.ToGameHardwareControllerMap();
						P_0.instanceName = vhbvSIyRvLTNKIdHyehnSxBQFBz;
						num = -1205107808;
						continue;
					case 0:
						P_0.productName = DVaqHcutoHoUrPluDMMcnunKAGA;
						num = -1205107805;
						continue;
					default:
						P_0.isXInputDevice = XWJGdtiTCNTQbkDNDyOHMuyHxoJn;
						P_0.axisCount = bxgcDFqOQApgYslsUNoAyTPhJYH;
						P_0.buttonCount = opznTvXijlFgLFSdvYEAiweymVQ;
						P_0.isButtonPressureSensitive = new bool[opznTvXijlFgLFSdvYEAiweymVQ];
						Array.Copy(nXfUtvmmBgAjTbwJUcuGGaPmoRlF, P_0.isButtonPressureSensitive, opznTvXijlFgLFSdvYEAiweymVQ);
						P_0.unknownControllerHats = OcUHrymqzKTvssBZgPXgfXPVImG();
						P_0.controllerTypeGuid = UfFFvwXyyVSVFqRBlSrwmIuVpoX;
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		private void ZUufxygzLDLqreSdRfjQUkyhpRth()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_0083:
				int num3;
				if (num >= opznTvXijlFgLFSdvYEAiweymVQ)
				{
					num2 = 0;
					num3 = 1467770509;
					goto IL_0009;
				}
				goto IL_0032;
				IL_0009:
				while (true)
				{
					switch (num3 ^ 0x577C668D)
					{
					case 3:
						num3 = 1467770505;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						num2++;
						num3 = 1467770509;
						continue;
					case 5:
						UeCdPcJARqFdGACIKPtkWZxawHVX[num2] = 0f;
						num3 = 1467770511;
						continue;
					case 0:
						goto IL_0069;
					case 1:
						goto IL_0083;
					case 6:
						return;
					}
					break;
					IL_0069:
					int num4;
					if (num2 < bxgcDFqOQApgYslsUNoAyTPhJYH)
					{
						num3 = 1467770504;
						num4 = num3;
					}
					else
					{
						num3 = 1467770507;
						num4 = num3;
					}
				}
				goto IL_0032;
				IL_0032:
				mCgSEFdyltyHHshVpCgaWFFUiOPJ[num] = 0f;
				num++;
				num3 = 1467770508;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] OcUHrymqzKTvssBZgPXgfXPVImG()
		{
			if (!zzVdHXNFUtEpnTWJnqCoLRkJxcS)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			int[] array2 = default(int[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = -2091823797;
				while (true)
				{
					switch (num2 ^ -2091823798)
					{
					case 2:
						break;
					case 4:
					{
						array2[6] = num3 + 6;
						array2[7] = num3 + 7;
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num] = new UnknownControllerHat(buttons);
						num++;
						num2 = -2091823798;
						continue;
					}
					case 3:
						array2[1] = num3 + 1;
						array2[2] = num3 + 2;
						array2[3] = num3 + 3;
						array2[4] = num3 + 4;
						array2[5] = num3 + 5;
						num2 = -2091823794;
						continue;
					case 5:
						num3 = 128 + num * 8;
						array2 = new int[8] { num3, 0, 0, 0, 0, 0, 0, 0 };
						num2 = -2091823799;
						continue;
					case 1:
						num2 = -2091823798;
						continue;
					default:
						if (num >= 2)
						{
							return array;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public void WYoEhOBxiSjIYKwbsCHdGOUBXDbi()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
			GC.SuppressFinalize(this);
		}

		~lYLjuNkLxblMGskfekgsFxSEpiX()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
		}

		protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				while (true)
				{
					switch (-1622987362 ^ -1622987361)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}

		public static int PqQgrmpdNXqmxXMcBHguZRCFinw(lYLjuNkLxblMGskfekgsFxSEpiX P_0, lYLjuNkLxblMGskfekgsFxSEpiX P_1)
		{
			if (P_0.JuzBXDTMFrDVUhqtKRLmdorveybr < P_1.JuzBXDTMFrDVUhqtKRLmdorveybr)
			{
				return -1;
			}
			if (P_0.JuzBXDTMFrDVUhqtKRLmdorveybr > P_1.JuzBXDTMFrDVUhqtKRLmdorveybr)
			{
				return 1;
			}
			return 0;
		}

		public static int JioKUzANjtCPjECxIaCGfNSKwPx(lYLjuNkLxblMGskfekgsFxSEpiX P_0, lYLjuNkLxblMGskfekgsFxSEpiX P_1)
		{
			if (P_0.zuIOHHSFjUvtYoHqYbOkIVnjKLJ < P_1.zuIOHHSFjUvtYoHqYbOkIVnjKLJ)
			{
				return -1;
			}
			if (P_0.zuIOHHSFjUvtYoHqYbOkIVnjKLJ > P_1.zuIOHHSFjUvtYoHqYbOkIVnjKLJ)
			{
				return 1;
			}
			return 0;
		}
	}

	private class dTIPNxKifeGRTLAlxoeMsVuEQGU
	{
		public enum SyuwUSifCFiFLJpUObqglHzCCnc
		{
			afFbgEzNXvGvvGsLKuJIIflFbruT = 0,
			UFRAQlMKzdfISVPlAcYSIMiPnrq = 1
		}

		public class SdygmTDVboJRCwHFatkFJoEvXnC
		{
			public int VGSrrWYLNAwIbrYoUwvzVCxXdRzc;

			public Guid XycawPIOvCyONuaycBLuYSafxNd;

			public Guid LFrLHWCZQzUjUEpwygbljLuHiCF;

			public int RgyPfpfFQwdoJNiBIXrQsaliAnP;

			public int qhBaQiBUaifpRBvldoZTqTDFPFqY;

			public int lenAIRsoOFqjBdbpibHDlBXGVmR;

			public int QQactFjAyaivYJCKROwerenGIZRE;

			public int opznTvXijlFgLFSdvYEAiweymVQ;

			public int bxgcDFqOQApgYslsUNoAyTPhJYH;

			public bool JLubYAVQZJxtyMiFJHVLTGosXQ;

			public bool FcvkUyKypZmJCfGSpczJhAaNNjEx(lYLjuNkLxblMGskfekgsFxSEpiX P_0, SyuwUSifCFiFLJpUObqglHzCCnc P_1)
			{
				if (qhBaQiBUaifpRBvldoZTqTDFPFqY != P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY)
				{
					return false;
				}
				if (lenAIRsoOFqjBdbpibHDlBXGVmR != P_0.lenAIRsoOFqjBdbpibHDlBXGVmR)
				{
					return false;
				}
				if (QQactFjAyaivYJCKROwerenGIZRE != P_0.QQactFjAyaivYJCKROwerenGIZRE)
				{
					return false;
				}
				if (opznTvXijlFgLFSdvYEAiweymVQ != P_0.opznTvXijlFgLFSdvYEAiweymVQ)
				{
					goto IL_003e;
				}
				int num;
				if (bxgcDFqOQApgYslsUNoAyTPhJYH != P_0.bxgcDFqOQApgYslsUNoAyTPhJYH)
				{
					num = -1481198852;
				}
				else
				{
					if (JLubYAVQZJxtyMiFJHVLTGosXQ != P_0.hasDriver)
					{
						return false;
					}
					if (P_0.rewiredId != VGSrrWYLNAwIbrYoUwvzVCxXdRzc)
					{
						if (P_1 == SyuwUSifCFiFLJpUObqglHzCCnc.afFbgEzNXvGvvGsLKuJIIflFbruT)
						{
							return XycawPIOvCyONuaycBLuYSafxNd == P_0.instanceGuid;
						}
						if (P_1 != SyuwUSifCFiFLJpUObqglHzCCnc.UFRAQlMKzdfISVPlAcYSIMiPnrq)
						{
							throw new NotImplementedException();
						}
						num = -1481198851;
					}
					else
					{
						num = -1481198850;
					}
				}
				goto IL_0043;
				IL_003e:
				num = -1481198853;
				goto IL_0043;
				IL_0043:
				switch (num ^ -1481198849)
				{
				case 0:
					break;
				case 4:
					return false;
				case 1:
					return true;
				case 3:
					return false;
				default:
					return LFrLHWCZQzUjUEpwygbljLuHiCF == P_0.LFrLHWCZQzUjUEpwygbljLuHiCF;
				}
				goto IL_003e;
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				object[] array8 = default(object[]);
				object[] array3 = default(object[]);
				object[] array2 = default(object[]);
				object obj3 = default(object);
				object[] array = default(object[]);
				object[] array4 = default(object[]);
				object[] array5 = default(object[]);
				object obj9 = default(object);
				object obj4 = default(object);
				object[] array9 = default(object[]);
				object[] array6 = default(object[]);
				object[] array10 = default(object[]);
				object obj6 = default(object);
				object obj7 = default(object);
				object obj2 = default(object);
				object[] array7 = default(object[]);
				object obj5 = default(object);
				while (true)
				{
					int num = 1367797465;
					while (true)
					{
						switch (num ^ 0x5186EEC1)
						{
						case 2:
							break;
						case 4:
						{
							text = string.Concat(array8);
							object obj10 = text;
							array3 = new object[4] { obj10, null, null, null };
							num = 1367797446;
							continue;
						}
						case 9:
							array2[2] = bxgcDFqOQApgYslsUNoAyTPhJYH;
							array2[3] = "\n";
							text = string.Concat(array2);
							obj3 = text;
							array = new object[4];
							num = 1367797467;
							continue;
						case 31:
							text = string.Concat(array4);
							num = 1367797454;
							continue;
						case 1:
							array5[0] = obj9;
							num = 1367797466;
							continue;
						case 28:
							array8[1] = "hardwareHatCount = ";
							array8[2] = QQactFjAyaivYJCKROwerenGIZRE;
							num = 1367797459;
							continue;
						case 10:
							text = string.Concat(array3);
							obj4 = text;
							num = 1367797462;
							continue;
						case 22:
							array9[0] = obj;
							num = 1367797464;
							continue;
						case 15:
							obj9 = text;
							array5 = new object[4];
							num = 1367797440;
							continue;
						case 21:
						{
							array6[3] = "\n";
							text = string.Concat(array6);
							object obj8 = text;
							array10 = new object[4] { obj8, "lastInputManagerId = ", null, null };
							num = 1367797452;
							continue;
						}
						case 29:
							array8[0] = obj6;
							num = 1367797469;
							continue;
						case 19:
							array4[2] = qhBaQiBUaifpRBvldoZTqTDFPFqY;
							array4[3] = "\n";
							num = 1367797470;
							continue;
						case 7:
							array3[1] = "gameButtonCount = ";
							array3[2] = opznTvXijlFgLFSdvYEAiweymVQ;
							num = 1367797457;
							continue;
						case 12:
							text = string.Concat(array9);
							obj7 = text;
							num = 1367797449;
							continue;
						case 18:
							array8[3] = "\n";
							num = 1367797445;
							continue;
						case 24:
							array9 = new object[4];
							num = 1367797463;
							continue;
						case 13:
							array10[2] = RgyPfpfFQwdoJNiBIXrQsaliAnP;
							array10[3] = "\n";
							text = string.Concat(array10);
							obj2 = text;
							array4 = new object[4];
							num = 1367797456;
							continue;
						case 6:
							array2[1] = "gameAxisCount = ";
							num = 1367797448;
							continue;
						case 8:
							array7 = new object[4];
							num = 1367797471;
							continue;
						case 25:
							array9[1] = "rewiredId = ";
							array9[2] = VGSrrWYLNAwIbrYoUwvzVCxXdRzc;
							array9[3] = "\n";
							num = 1367797453;
							continue;
						case 30:
							array7[0] = obj7;
							array7[1] = "instanceGuid = ";
							array7[2] = XycawPIOvCyONuaycBLuYSafxNd;
							num = 1367797442;
							continue;
						case 32:
							array6[0] = obj5;
							array6[1] = "typeIdentifierGuid = ";
							array6[2] = LFrLHWCZQzUjUEpwygbljLuHiCF;
							num = 1367797460;
							continue;
						case 11:
							array5[2] = lenAIRsoOFqjBdbpibHDlBXGVmR;
							array5[3] = "\n";
							text = string.Concat(array5);
							obj6 = text;
							array8 = new object[4];
							num = 1367797468;
							continue;
						case 3:
							array7[3] = "\n";
							text = string.Concat(array7);
							obj5 = text;
							num = 1367797441;
							continue;
						case 0:
							array6 = new object[4];
							num = 1367797473;
							continue;
						case 5:
							array2[0] = obj4;
							num = 1367797447;
							continue;
						case 26:
							array[0] = obj3;
							array[1] = "hasDriver = ";
							num = 1367797455;
							continue;
						case 14:
							array[2] = JLubYAVQZJxtyMiFJHVLTGosXQ;
							array[3] = "\n";
							num = 1367797461;
							continue;
						case 27:
							array5[1] = "hardwareButtonCount = ";
							num = 1367797450;
							continue;
						case 17:
							array4[0] = obj2;
							array4[1] = "hardwareAxisCount = ";
							num = 1367797458;
							continue;
						case 16:
							array3[3] = "\n";
							num = 1367797451;
							continue;
						case 23:
							array2 = new object[4];
							num = 1367797444;
							continue;
						default:
							return string.Concat(array);
						}
						break;
					}
				}
			}
		}

		private sealed class WPgGJMaxktSEYhhwOMjCguYrHFLK : IEnumerable<SdygmTDVboJRCwHFatkFJoEvXnC>, IEnumerator<SdygmTDVboJRCwHFatkFJoEvXnC>, IDisposable, IEnumerable, IEnumerator
		{
			private SdygmTDVboJRCwHFatkFJoEvXnC zaeaxnimXYLPZwadZmMRLZSdyFWN;

			private int lBwCMCgvzsvBnpNnmYUoDOyCSvR;

			private int GAtDJGRHxGPYGsKYTZZuVqCmfac;

			public dTIPNxKifeGRTLAlxoeMsVuEQGU xvYPGRaXRVZlwecANemUYNIlHnq;

			public lYLjuNkLxblMGskfekgsFxSEpiX DIEZrMuylamgGcHdpTXXqfwtldf;

			public lYLjuNkLxblMGskfekgsFxSEpiX jsKqKJUJoxOmFqcsArDvuHUjkPy;

			public SyuwUSifCFiFLJpUObqglHzCCnc aCFerNKXEctsXPGMtFXeGIuKZyd;

			public SyuwUSifCFiFLJpUObqglHzCCnc OmMCHaaoqZqFnjPmdZNpWKskvkVC;

			public int oLdLPJuCNiTHeKGgPxioBjYJrvi;

			public int dSkzJcPnYbcpccFgvfUWdtJoSaV;

			SdygmTDVboJRCwHFatkFJoEvXnC IEnumerator<SdygmTDVboJRCwHFatkFJoEvXnC>.Current
			{
				[DebuggerHidden]
				get
				{
					return zaeaxnimXYLPZwadZmMRLZSdyFWN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return zaeaxnimXYLPZwadZmMRLZSdyFWN;
				}
			}

			[DebuggerHidden]
			IEnumerator<SdygmTDVboJRCwHFatkFJoEvXnC> IEnumerable<SdygmTDVboJRCwHFatkFJoEvXnC>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == GAtDJGRHxGPYGsKYTZZuVqCmfac && lBwCMCgvzsvBnpNnmYUoDOyCSvR == -2)
				{
					lBwCMCgvzsvBnpNnmYUoDOyCSvR = 0;
					goto IL_0023;
				}
				goto IL_0052;
				IL_0028:
				int num;
				WPgGJMaxktSEYhhwOMjCguYrHFLK wPgGJMaxktSEYhhwOMjCguYrHFLK = default(WPgGJMaxktSEYhhwOMjCguYrHFLK);
				while (true)
				{
					switch (num ^ 0x2916AD2)
					{
					case 4:
						break;
					case 3:
						wPgGJMaxktSEYhhwOMjCguYrHFLK = this;
						num = 43084496;
						continue;
					case 0:
						goto IL_0052;
					case 1:
						wPgGJMaxktSEYhhwOMjCguYrHFLK.xvYPGRaXRVZlwecANemUYNIlHnq = xvYPGRaXRVZlwecANemUYNIlHnq;
						num = 43084496;
						continue;
					default:
						wPgGJMaxktSEYhhwOMjCguYrHFLK.DIEZrMuylamgGcHdpTXXqfwtldf = jsKqKJUJoxOmFqcsArDvuHUjkPy;
						wPgGJMaxktSEYhhwOMjCguYrHFLK.aCFerNKXEctsXPGMtFXeGIuKZyd = OmMCHaaoqZqFnjPmdZNpWKskvkVC;
						return wPgGJMaxktSEYhhwOMjCguYrHFLK;
					}
					break;
				}
				goto IL_0023;
				IL_0052:
				wPgGJMaxktSEYhhwOMjCguYrHFLK = new WPgGJMaxktSEYhhwOMjCguYrHFLK(0);
				num = 43084499;
				goto IL_0028;
				IL_0023:
				num = 43084497;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<SdygmTDVboJRCwHFatkFJoEvXnC>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (lBwCMCgvzsvBnpNnmYUoDOyCSvR)
				{
				case 1:
					lBwCMCgvzsvBnpNnmYUoDOyCSvR = -1;
					num = -1486708645;
					goto IL_001f;
				case 0:
					{
						lBwCMCgvzsvBnpNnmYUoDOyCSvR = -1;
						oLdLPJuCNiTHeKGgPxioBjYJrvi = xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly.Count;
						dSkzJcPnYbcpccFgvfUWdtJoSaV = 0;
						num = -1486708643;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1486708642)
						{
						case 4:
							num = -1486708641;
							continue;
						case 5:
							dSkzJcPnYbcpccFgvfUWdtJoSaV++;
							num = -1486708642;
							continue;
						case 6:
							if (xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly[dSkzJcPnYbcpccFgvfUWdtJoSaV].FcvkUyKypZmJCfGSpczJhAaNNjEx(DIEZrMuylamgGcHdpTXXqfwtldf, aCFerNKXEctsXPGMtFXeGIuKZyd))
							{
								zaeaxnimXYLPZwadZmMRLZSdyFWN = xvYPGRaXRVZlwecANemUYNIlHnq.yyiFPljnUsCKsCDVIczjlInczmly[dSkzJcPnYbcpccFgvfUWdtJoSaV];
								lBwCMCgvzsvBnpNnmYUoDOyCSvR = 1;
								return true;
							}
							goto case 5;
						case 3:
							num = -1486708642;
							continue;
						case 1:
							break;
						case 0:
							goto IL_00f7;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00f7:
						int num2;
						if (dSkzJcPnYbcpccFgvfUWdtJoSaV < oLdLPJuCNiTHeKGgPxioBjYJrvi)
						{
							num = -1486708648;
							num2 = num;
						}
						else
						{
							num = -1486708644;
							num2 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public WPgGJMaxktSEYhhwOMjCguYrHFLK(int _003C_003E1__state)
			{
				lBwCMCgvzsvBnpNnmYUoDOyCSvR = _003C_003E1__state;
				GAtDJGRHxGPYGsKYTZZuVqCmfac = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<SdygmTDVboJRCwHFatkFJoEvXnC> yyiFPljnUsCKsCDVIczjlInczmly;

		public dTIPNxKifeGRTLAlxoeMsVuEQGU()
		{
			yyiFPljnUsCKsCDVIczjlInczmly = new List<SdygmTDVboJRCwHFatkFJoEvXnC>();
		}

		public void kVadApUnAEuOWsMMZXVNAURVCZW(lYLjuNkLxblMGskfekgsFxSEpiX P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
				int num = 0;
				int num2 = 663022808;
				while (true)
				{
					switch (num2 ^ 0x2784ECDA)
					{
					case 3:
						num2 = 663022814;
						continue;
					case 6:
						num++;
						num2 = 663022808;
						continue;
					case 0:
						yyiFPljnUsCKsCDVIczjlInczmly[num].RgyPfpfFQwdoJNiBIXrQsaliAnP = P_0.inputManagerId;
						yyiFPljnUsCKsCDVIczjlInczmly[num].qhBaQiBUaifpRBvldoZTqTDFPFqY = P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY;
						yyiFPljnUsCKsCDVIczjlInczmly[num].lenAIRsoOFqjBdbpibHDlBXGVmR = P_0.lenAIRsoOFqjBdbpibHDlBXGVmR;
						yyiFPljnUsCKsCDVIczjlInczmly[num].QQactFjAyaivYJCKROwerenGIZRE = P_0.QQactFjAyaivYJCKROwerenGIZRE;
						num2 = 663022815;
						continue;
					case 5:
						yyiFPljnUsCKsCDVIczjlInczmly[num].opznTvXijlFgLFSdvYEAiweymVQ = P_0.opznTvXijlFgLFSdvYEAiweymVQ;
						yyiFPljnUsCKsCDVIczjlInczmly[num].bxgcDFqOQApgYslsUNoAyTPhJYH = P_0.bxgcDFqOQApgYslsUNoAyTPhJYH;
						yyiFPljnUsCKsCDVIczjlInczmly[num].JLubYAVQZJxtyMiFJHVLTGosXQ = P_0.hasDriver;
						YxaByKiVVfVaZoBlAARoSYRdsvs(P_0.rewiredId, P_0.instanceGuid, num);
						return;
					case 1:
						if (yyiFPljnUsCKsCDVIczjlInczmly[num].FcvkUyKypZmJCfGSpczJhAaNNjEx(P_0, SyuwUSifCFiFLJpUObqglHzCCnc.afFbgEzNXvGvvGsLKuJIIflFbruT))
						{
							yyiFPljnUsCKsCDVIczjlInczmly[num].VGSrrWYLNAwIbrYoUwvzVCxXdRzc = P_0.rewiredId;
							yyiFPljnUsCKsCDVIczjlInczmly[num].XycawPIOvCyONuaycBLuYSafxNd = P_0.instanceGuid;
							yyiFPljnUsCKsCDVIczjlInczmly[num].LFrLHWCZQzUjUEpwygbljLuHiCF = P_0.LFrLHWCZQzUjUEpwygbljLuHiCF;
							num2 = 663022810;
							continue;
						}
						goto case 6;
					case 4:
						break;
					default:
						if (num >= count)
						{
							yyiFPljnUsCKsCDVIczjlInczmly.Add(new SdygmTDVboJRCwHFatkFJoEvXnC
							{
								VGSrrWYLNAwIbrYoUwvzVCxXdRzc = P_0.rewiredId,
								XycawPIOvCyONuaycBLuYSafxNd = P_0.instanceGuid,
								LFrLHWCZQzUjUEpwygbljLuHiCF = P_0.LFrLHWCZQzUjUEpwygbljLuHiCF,
								RgyPfpfFQwdoJNiBIXrQsaliAnP = P_0.inputManagerId,
								qhBaQiBUaifpRBvldoZTqTDFPFqY = P_0.qhBaQiBUaifpRBvldoZTqTDFPFqY,
								lenAIRsoOFqjBdbpibHDlBXGVmR = P_0.lenAIRsoOFqjBdbpibHDlBXGVmR,
								QQactFjAyaivYJCKROwerenGIZRE = P_0.QQactFjAyaivYJCKROwerenGIZRE,
								opznTvXijlFgLFSdvYEAiweymVQ = P_0.opznTvXijlFgLFSdvYEAiweymVQ,
								bxgcDFqOQApgYslsUNoAyTPhJYH = P_0.bxgcDFqOQApgYslsUNoAyTPhJYH,
								JLubYAVQZJxtyMiFJHVLTGosXQ = P_0.hasDriver
							});
							YxaByKiVVfVaZoBlAARoSYRdsvs(P_0.rewiredId, P_0.instanceGuid, yyiFPljnUsCKsCDVIczjlInczmly.Count - 1);
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool RYjoxuvBIQdFpgfUrGqIfrkODTT(lYLjuNkLxblMGskfekgsFxSEpiX P_0, SyuwUSifCFiFLJpUObqglHzCCnc P_1)
		{
			int count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (yyiFPljnUsCKsCDVIczjlInczmly[num].FcvkUyKypZmJCfGSpczJhAaNNjEx(P_0, P_1))
					{
						num2 = 2098797969;
					}
					else
					{
						num++;
						num2 = 2098797968;
					}
					while (true)
					{
						switch (num2 ^ 0x7D191D92)
						{
						case 0:
							num2 = 2098797971;
							continue;
						case 1:
							break;
						case 3:
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

		public IEnumerable<SdygmTDVboJRCwHFatkFJoEvXnC> joccDsvMkbNqtLkAGboThijYbVO(lYLjuNkLxblMGskfekgsFxSEpiX P_0, SyuwUSifCFiFLJpUObqglHzCCnc P_1)
		{
			WPgGJMaxktSEYhhwOMjCguYrHFLK wPgGJMaxktSEYhhwOMjCguYrHFLK = new WPgGJMaxktSEYhhwOMjCguYrHFLK(-2);
			wPgGJMaxktSEYhhwOMjCguYrHFLK.xvYPGRaXRVZlwecANemUYNIlHnq = this;
			wPgGJMaxktSEYhhwOMjCguYrHFLK.jsKqKJUJoxOmFqcsArDvuHUjkPy = P_0;
			while (true)
			{
				int num = -794421338;
				while (true)
				{
					switch (num ^ -794421340)
					{
					case 0:
						break;
					case 2:
						goto IL_0034;
					default:
						return wPgGJMaxktSEYhhwOMjCguYrHFLK;
					}
					break;
					IL_0034:
					wPgGJMaxktSEYhhwOMjCguYrHFLK.OmMCHaaoqZqFnjPmdZNpWKskvkVC = P_1;
					num = -794421339;
				}
			}
		}

		private void YxaByKiVVfVaZoBlAARoSYRdsvs(int P_0, Guid P_1, int P_2)
		{
			int num = yyiFPljnUsCKsCDVIczjlInczmly.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					IL_005b:
					int num2;
					if (num != P_2)
					{
						int num3;
						if (yyiFPljnUsCKsCDVIczjlInczmly[num].VGSrrWYLNAwIbrYoUwvzVCxXdRzc != P_0)
						{
							num2 = 707311945;
							num3 = num2;
						}
						else
						{
							num2 = 707311947;
							num3 = num2;
						}
						goto IL_0018;
					}
					goto IL_0050;
					IL_0018:
					while (true)
					{
						switch (num2 ^ 0x2A28B949)
						{
						case 5:
							num2 = 707311944;
							continue;
						case 2:
							yyiFPljnUsCKsCDVIczjlInczmly.RemoveAt(num);
							num2 = 707311946;
							continue;
						case 3:
							break;
						case 1:
							goto IL_005b;
						case 0:
							goto IL_0084;
						default:
							goto end_IL_005b;
						}
						break;
						IL_0084:
						int num4;
						if (yyiFPljnUsCKsCDVIczjlInczmly[num].XycawPIOvCyONuaycBLuYSafxNd == P_1)
						{
							num2 = 707311947;
							num4 = num2;
						}
						else
						{
							num2 = 707311946;
							num4 = num2;
						}
					}
					goto IL_0050;
					IL_0050:
					num--;
					num2 = 707311949;
					goto IL_0018;
					continue;
					end_IL_005b:
					break;
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			object[] array = default(object[]);
			object[] array2 = default(object[]);
			int num2 = default(int);
			while (true)
			{
				int num = 1853169708;
				while (true)
				{
					switch (num ^ 0x6E752029)
					{
					case 7:
						break;
					case 2:
					{
						object obj = text;
						array = new object[4] { obj, null, null, null };
						num = 1853169706;
						continue;
					}
					case 4:
						text = string.Concat(array2);
						num2 = 0;
						num = 1853169704;
						continue;
					case 6:
						text = text + yyiFPljnUsCKsCDVIczjlInczmly[num2].ToString() + "\n\n";
						num2++;
						num = 1853169705;
						continue;
					case 1:
						num = 1853169705;
						continue;
					case 3:
						array[1] = "Record ";
						array[2] = num2;
						array[3] = ":\n";
						text = string.Concat(array);
						num = 1853169711;
						continue;
					case 5:
					{
						object obj2 = text;
						array2 = new object[4] { obj2, "Joystick records: ", yyiFPljnUsCKsCDVIczjlInczmly.Count, "\n" };
						num = 1853169709;
						continue;
					}
					default:
						if (num2 >= yyiFPljnUsCKsCDVIczjlInczmly.Count)
						{
							return text;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}

	private YkKIPPiCWZeAzAfNMTiDRgJXluDN dgeymjwCdGAtHTMwapVjdBigBLF;

	private List<lYLjuNkLxblMGskfekgsFxSEpiX> DhZbdMKNkujxkBYZovsLjyUUFhq;

	private int ySAWzXMlBDpuUMZJSTZdpLsLntr;

	private dTIPNxKifeGRTLAlxoeMsVuEQGU UMsKdJAzyaBSALboFULhgKARVjb;

	private bool lTMACTFXWDSejtRxaVyHEsqhUZm;

	private TimerRealTime QyTJbpIQxqdJHCNiKQcoFeqrkmT;

	private global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool> APFYhbxyKiosMFmWCfvqFsqArjE;

	private global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool> bGpaBMieDdHAVIdvKMObQFtPsiSb;

	private int aHPRwjEykMDbpqxpTXLQNJbOCnE;

	private int ZqUclFGnPscdViyFMMwBPbZEeVjm;

	private ConfigVars ZlGbTCkxQRChOIofeffCYHRKxiuW;

	private bool pyimnvsUyirvCGgwqkCsOmauCTw;

	private Action<int, ControllerDataUpdater> NvqaCuAwnRtIQraiMLVUyKxjukSM;

	private PlatformInputManager PQcgLBxnvdIehjQoFUyCgOAdLDX;

	private readonly UcjcCicwSOnbqeWIgHcOdekypFs JXHFgLdxFgCWheQdbwuUfaTzLpZb;

	private readonly uXmfJyNysxkJVMfVjUMqRSBUjHs AcedwEGjvyEhtNGXEEKTGcQOyzC;

	private readonly bool yCIfoAipTphniepDsrKPaDRNhiMJ;

	private readonly bool UNCDhikBVajwTkKrWKjlDBeTSzFD;

	private readonly bool pxdVJyAGwTQNGJDRzUSBDhXjucu;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

	private readonly Func<int> faTqYhfgwuuVCbrIpddTkYZQAdf;

	public bool useXInput
	{
		set
		{
			pyimnvsUyirvCGgwqkCsOmauCTw = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => ySAWzXMlBDpuUMZJSTZdpLsLntr;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => PQcgLBxnvdIehjQoFUyCgOAdLDX;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => dgeymjwCdGAtHTMwapVjdBigBLF;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.RawInput;

	public KQMPeTwPTsLuGhkUNxqXEROjtXA(ConfigVars configVars, bool useXInput, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard, bool useCustomDrivers)
	{
		try
		{
			ZlGbTCkxQRChOIofeffCYHRKxiuW = configVars;
			pyimnvsUyirvCGgwqkCsOmauCTw = useXInput;
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			faTqYhfgwuuVCbrIpddTkYZQAdf = getNewJoystickId;
			yCIfoAipTphniepDsrKPaDRNhiMJ = handleJoysticks;
			UNCDhikBVajwTkKrWKjlDBeTSzFD = handleUnifiedMouse;
			pxdVJyAGwTQNGJDRzUSBDhXjucu = handleUnifiedKeyboard;
			PQcgLBxnvdIehjQoFUyCgOAdLDX = this;
			UpdateLoopSetting updateLoop = configVars.updateLoop;
			if (handleUnifiedKeyboard)
			{
				AcedwEGjvyEhtNGXEEKTGcQOyzC = new uXmfJyNysxkJVMfVjUMqRSBUjHs(updateLoop);
			}
			if (handleUnifiedMouse)
			{
				JXHFgLdxFgCWheQdbwuUfaTzLpZb = new UcjcCicwSOnbqeWIgHcOdekypFs(updateLoop);
			}
			dgeymjwCdGAtHTMwapVjdBigBLF = new YkKIPPiCWZeAzAfNMTiDRgJXluDN(configVars, handleJoysticks, useCustomDrivers, JXHFgLdxFgCWheQdbwuUfaTzLpZb, AcedwEGjvyEhtNGXEEKTGcQOyzC);
			NvqaCuAwnRtIQraiMLVUyKxjukSM = UpdateControllerData;
			APFYhbxyKiosMFmWCfvqFsqArjE = new global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool>(useSharedThread: true, QdjFbhivHyWOJIdqVKGlvWgkVXXl);
			bGpaBMieDdHAVIdvKMObQFtPsiSb = new global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool>(useSharedThread: true, dgeymjwCdGAtHTMwapVjdBigBLF.ZHnfziDQiQxToFwsnsRUKtaeiUpD);
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
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			UMsKdJAzyaBSALboFULhgKARVjb = new dTIPNxKifeGRTLAlxoeMsVuEQGU();
			QyTJbpIQxqdJHCNiKQcoFeqrkmT = new TimerRealTime(1.0);
			QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
			ZEQTqdrQJjlBCMOvIzIIORNAzup();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			goto IL_0008;
		}
		goto IL_0056;
		IL_0008:
		int num = -1211268301;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -1211268293)
			{
			case 6:
				break;
			default:
				return;
			case 8:
				JWvEXNrpTUEiGwLjrRCrZpfrsHV();
				num = -1211268293;
				continue;
			case 0:
				goto IL_0056;
			case 1:
				goto IL_0070;
			case 2:
				goto IL_0089;
			case 10:
				if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
				{
					AcedwEGjvyEhtNGXEEKTGcQOyzC.FFYEDujhZPZIRSsDbLkeXQkxTZI(updateLoop);
					num = -1211268290;
					continue;
				}
				return;
			case 4:
				mrpXieuHWEMeqScxLKfMAzfufkq();
				num = -1211268296;
				continue;
			case 9:
				if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
				{
					goto IL_0070;
				}
				if (dgeymjwCdGAtHTMwapVjdBigBLF != null)
				{
					dgeymjwCdGAtHTMwapVjdBigBLF.UpdateDevices(updateLoop);
					num = -1211268289;
					continue;
				}
				goto case 4;
			case 3:
				if (dgeymjwCdGAtHTMwapVjdBigBLF != null)
				{
					dgeymjwCdGAtHTMwapVjdBigBLF.UpdateFinished();
					num = -1211268294;
					continue;
				}
				goto IL_0070;
			case 7:
				JXHFgLdxFgCWheQdbwuUfaTzLpZb.FFYEDujhZPZIRSsDbLkeXQkxTZI(updateLoop);
				num = -1211268303;
				continue;
			case 5:
				return;
			}
			break;
			IL_0070:
			int num2;
			if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
			{
				num = -1211268303;
				num2 = num;
			}
			else
			{
				num = -1211268292;
				num2 = num;
			}
		}
		goto IL_0008;
		IL_0056:
		if (dgeymjwCdGAtHTMwapVjdBigBLF != null)
		{
			dgeymjwCdGAtHTMwapVjdBigBLF.Update();
			num = -1211268295;
			goto IL_000d;
		}
		goto IL_0089;
		IL_0089:
		oGKalEFSMrovSTqbIEPCXcczDyVh();
		num = -1211268302;
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb != null)
		{
			bGpaBMieDdHAVIdvKMObQFtPsiSb.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
			goto IL_0016;
		}
		goto IL_00c6;
		IL_0057:
		int num;
		if (dgeymjwCdGAtHTMwapVjdBigBLF != null)
		{
			dgeymjwCdGAtHTMwapVjdBigBLF.Dispose();
			num = -913396999;
			goto IL_001b;
		}
		return;
		IL_0016:
		num = -913397007;
		goto IL_001b;
		IL_001b:
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ -913396997)
			{
			case 0:
				break;
			default:
				return;
			case 7:
				goto IL_0057;
			case 8:
				goto IL_0074;
			case 3:
				goto IL_0089;
			case 6:
				goto IL_00a9;
			case 10:
				goto IL_00c6;
			case 4:
				goto IL_00e3;
			case 9:
				DhZbdMKNkujxkBYZovsLjyUUFhq[num2].WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
				num = -913396998;
				continue;
			case 1:
				num2++;
				num = -913397005;
				continue;
			case 5:
				goto IL_012e;
			case 2:
				return;
			}
			break;
			IL_00e3:
			int num3;
			if (DhZbdMKNkujxkBYZovsLjyUUFhq[num2] != null)
			{
				num = -913397006;
				num3 = num;
			}
			else
			{
				num = -913396998;
				num3 = num;
			}
			continue;
			IL_0074:
			int num4;
			if (num2 >= count)
			{
				num = -913396995;
				num4 = num;
			}
			else
			{
				num = -913396993;
				num4 = num;
			}
		}
		goto IL_0016;
		IL_00a9:
		if (AcedwEGjvyEhtNGXEEKTGcQOyzC != null)
		{
			AcedwEGjvyEhtNGXEEKTGcQOyzC.Dispose();
			num = -913396994;
			goto IL_001b;
		}
		goto IL_012e;
		IL_012e:
		if (JXHFgLdxFgCWheQdbwuUfaTzLpZb != null)
		{
			JXHFgLdxFgCWheQdbwuUfaTzLpZb.Dispose();
			num = -913396996;
			goto IL_001b;
		}
		goto IL_0057;
		IL_0089:
		if (DhZbdMKNkujxkBYZovsLjyUUFhq != null)
		{
			count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
			num2 = 0;
			num = -913397005;
			goto IL_001b;
		}
		goto IL_00a9;
		IL_00c6:
		if (APFYhbxyKiosMFmWCfvqFsqArjE != null)
		{
			APFYhbxyKiosMFmWCfvqFsqArjE.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
			num = -913397000;
			goto IL_001b;
		}
		goto IL_0089;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NvqaCuAwnRtIQraiMLVUyKxjukSM;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 736640859;
			while (true)
			{
				switch (num2 ^ 0x2BE83F5F)
				{
				case 3:
					num2 = 736640861;
					continue;
				case 2:
					break;
				case 5:
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num].inputManagerId == inputManagerId)
					{
						DhZbdMKNkujxkBYZovsLjyUUFhq[num].FillData(data);
						num2 = 736640857;
						continue;
					}
					goto case 0;
				case 4:
					num2 = 736640862;
					continue;
				case 6:
					return;
				case 0:
					num++;
					num2 = 736640862;
					continue;
				default:
					if (num >= ySAWzXMlBDpuUMZJSTZdpLsLntr)
					{
						Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
						return;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		dgeymjwCdGAtHTMwapVjdBigBLF.SystemDeviceConnected();
		while (true)
		{
			int num = 641672840;
			while (true)
			{
				switch (num ^ 0x263F268C)
				{
				case 7:
					break;
				default:
					return;
				case 3:
				{
					int num4;
					if (_SystemDeviceConnectedEvent == null)
					{
						num = 641672844;
						num4 = num;
					}
					else
					{
						num = 641672841;
						num4 = num;
					}
					continue;
				}
				case 8:
				{
					int num3;
					if (!pxdVJyAGwTQNGJDRzUSBDhXjucu)
					{
						num = 641672845;
						num3 = num;
					}
					else
					{
						num = 641672842;
						num3 = num;
					}
					continue;
				}
				case 6:
					AcedwEGjvyEhtNGXEEKTGcQOyzC.FtQMeykQvehoqnnZziMNKixBdnK(true);
					num = 641672845;
					continue;
				case 4:
					lTMACTFXWDSejtRxaVyHEsqhUZm = true;
					if (yCIfoAipTphniepDsrKPaDRNhiMJ)
					{
						QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
						num = 641672836;
						continue;
					}
					goto case 8;
				case 5:
					_SystemDeviceConnectedEvent();
					num = 641672844;
					continue;
				case 2:
					JXHFgLdxFgCWheQdbwuUfaTzLpZb.FtQMeykQvehoqnnZziMNKixBdnK(true);
					num = 641672847;
					continue;
				case 1:
				{
					int num2;
					if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
					{
						num = 641672847;
						num2 = num;
					}
					else
					{
						num = 641672846;
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

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		dgeymjwCdGAtHTMwapVjdBigBLF.SystemDeviceDisconnected();
		lTMACTFXWDSejtRxaVyHEsqhUZm = true;
		if (yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
			goto IL_0025;
		}
		goto IL_0098;
		IL_0066:
		int num;
		int num2;
		if (!UNCDhikBVajwTkKrWKjlDBeTSzFD)
		{
			num = 1120699578;
			num2 = num;
		}
		else
		{
			num = 1120699583;
			num2 = num;
		}
		goto IL_002a;
		IL_0025:
		num = 1120699577;
		goto IL_002a;
		IL_002a:
		while (true)
		{
			switch (num ^ 0x42CC84BA)
			{
			case 4:
				break;
			default:
				return;
			case 5:
				JXHFgLdxFgCWheQdbwuUfaTzLpZb.FtQMeykQvehoqnnZziMNKixBdnK(false);
				num = 1120699578;
				continue;
			case 2:
				goto IL_0066;
			case 0:
				goto IL_007f;
			case 3:
				goto IL_0098;
			case 6:
				_SystemDeviceDisconnectedEvent();
				num = 1120699579;
				continue;
			case 1:
				return;
			}
			break;
			IL_007f:
			int num3;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				num = 1120699580;
				num3 = num;
			}
			else
			{
				num = 1120699579;
				num3 = num;
			}
		}
		goto IL_0025;
		IL_0098:
		if (pxdVJyAGwTQNGJDRzUSBDhXjucu)
		{
			AcedwEGjvyEhtNGXEEKTGcQOyzC.FtQMeykQvehoqnnZziMNKixBdnK(false);
			num = 1120699576;
			goto IL_002a;
		}
		goto IL_0066;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = yCIfoAipTphniepDsrKPaDRNhiMJ;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return JXHFgLdxFgCWheQdbwuUfaTzLpZb;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return AcedwEGjvyEhtNGXEEKTGcQOyzC;
	}

	public void MdnhOzkfliRLqCXkAeVecbVgXle(FalmQVTJKnCRzOnsKpwWBjXTJHN P_0, SgUbOIYhKqFHBWCjywfFXIQjDhT P_1)
	{
	}

	private void JWvEXNrpTUEiGwLjrRCrZpfrsHV()
	{
		if (APFYhbxyKiosMFmWCfvqFsqArjE.isRunning)
		{
			goto IL_0010;
		}
		goto IL_010b;
		IL_0010:
		int num = -164238959;
		goto IL_0015;
		IL_0015:
		while (true)
		{
			switch (num ^ -164238952)
			{
			case 4:
				break;
			default:
				return;
			case 8:
				if (APFYhbxyKiosMFmWCfvqFsqArjE.result)
				{
					lTMACTFXWDSejtRxaVyHEsqhUZm = true;
					num = -164238950;
					continue;
				}
				goto case 2;
			case 3:
				if (QyTJbpIQxqdJHCNiKQcoFeqrkmT.Update())
				{
					APFYhbxyKiosMFmWCfvqFsqArjE.LgoJHLCBitFthTodNHJlYroGYaX();
					num = -164238951;
					continue;
				}
				return;
			case 6:
				return;
			case 9:
				if (!APFYhbxyKiosMFmWCfvqFsqArjE.uIPQYCOyPijpbHfLzGABZERoRaI())
				{
					return;
				}
				goto case 5;
			case 5:
				if (QyTJbpIQxqdJHCNiKQcoFeqrkmT.running)
				{
					return;
				}
				goto IL_00be;
			case 2:
				QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
				return;
			case 7:
				QyTJbpIQxqdJHCNiKQcoFeqrkmT.Start();
				return;
			case 0:
				goto IL_010b;
			case 1:
				return;
			}
			break;
			IL_00be:
			int num2;
			if (!bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
			{
				num = -164238960;
				num2 = num;
			}
			else
			{
				num = -164238946;
				num2 = num;
			}
		}
		goto IL_0010;
		IL_010b:
		int num3;
		if (QyTJbpIQxqdJHCNiKQcoFeqrkmT.running)
		{
			num = -164238949;
			num3 = num;
		}
		else
		{
			num = -164238945;
			num3 = num;
		}
		goto IL_0015;
	}

	private void ZEQTqdrQJjlBCMOvIzIIORNAzup()
	{
		ZEQTqdrQJjlBCMOvIzIIORNAzup(YOECwsaBcGMJRqdOYDzBLdxXBjF());
	}

	private void ZEQTqdrQJjlBCMOvIzIIORNAzup(IList<TPOFglCEUenQueqhakDnrjLmVbgq> P_0)
	{
		int num = 0;
		List<lYLjuNkLxblMGskfekgsFxSEpiX> dhZbdMKNkujxkBYZovsLjyUUFhq = DhZbdMKNkujxkBYZovsLjyUUFhq;
		int num2 = ySAWzXMlBDpuUMZJSTZdpLsLntr;
		DhZbdMKNkujxkBYZovsLjyUUFhq = new List<lYLjuNkLxblMGskfekgsFxSEpiX>();
		int num6 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		int count = default(int);
		TPOFglCEUenQueqhakDnrjLmVbgq tPOFglCEUenQueqhakDnrjLmVbgq = default(TPOFglCEUenQueqhakDnrjLmVbgq);
		lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2 = default(lYLjuNkLxblMGskfekgsFxSEpiX);
		List<lYLjuNkLxblMGskfekgsFxSEpiX> list = default(List<lYLjuNkLxblMGskfekgsFxSEpiX>);
		while (true)
		{
			int num3 = -4148482;
			while (true)
			{
				switch (num3 ^ -4148489)
				{
				case 15:
					break;
				case 16:
					num3 = -4148485;
					continue;
				case 2:
					num6++;
					num3 = -4148486;
					continue;
				case 6:
					num4++;
					num3 = -4148485;
					continue;
				case 11:
				{
					int num7;
					if (dhZbdMKNkujxkBYZovsLjyUUFhq[num5] == null)
					{
						num3 = -4148489;
						num7 = num3;
					}
					else
					{
						num3 = -4148493;
						num7 = num3;
					}
					continue;
				}
				case 13:
					if (num6 >= count)
					{
						ySAWzXMlBDpuUMZJSTZdpLsLntr = num;
						ViJmTrtaYTomRaMXivkMijSGBsTd(num2, num, dhZbdMKNkujxkBYZovsLjyUUFhq, DhZbdMKNkujxkBYZovsLjyUUFhq);
						num4 = 0;
						num3 = -4148505;
						continue;
					}
					goto case 18;
				case 3:
					if (tPOFglCEUenQueqhakDnrjLmVbgq != null)
					{
						lYLjuNkLxblMGskfekgsFxSEpiX2 = new lYLjuNkLxblMGskfekgsFxSEpiX(tPOFglCEUenQueqhakDnrjLmVbgq, tPOFglCEUenQueqhakDnrjLmVbgq.DeviceType, qnewRYFCzYevHqfqyatlbQmZFOFg);
						lYLjuNkLxblMGskfekgsFxSEpiX2.duuMMyqFfJAeBAlnwwCpaWGlBUgO = tPOFglCEUenQueqhakDnrjLmVbgq.InstanceGuid;
						lYLjuNkLxblMGskfekgsFxSEpiX2.vhbvSIyRvLTNKIdHyehnSxBQFBz = tPOFglCEUenQueqhakDnrjLmVbgq.ProductName;
						lYLjuNkLxblMGskfekgsFxSEpiX2.DVaqHcutoHoUrPluDMMcnunKAGA = tPOFglCEUenQueqhakDnrjLmVbgq.ProductName;
						lYLjuNkLxblMGskfekgsFxSEpiX2.jswiKSoBCTxrqereFiOojDxDRmw = tPOFglCEUenQueqhakDnrjLmVbgq.ProductGuid;
						num3 = -4148490;
						continue;
					}
					goto case 2;
				case 0:
					num5--;
					num3 = -4148508;
					continue;
				case 22:
					num6 = 0;
					num3 = -4148486;
					continue;
				case 4:
					if (!dhZbdMKNkujxkBYZovsLjyUUFhq[num5].IsValid)
					{
						list.Add(dhZbdMKNkujxkBYZovsLjyUUFhq[num5]);
						dhZbdMKNkujxkBYZovsLjyUUFhq.RemoveAt(num5);
						num3 = -4148489;
						continue;
					}
					goto case 0;
				case 5:
					DhZbdMKNkujxkBYZovsLjyUUFhq.Add(lYLjuNkLxblMGskfekgsFxSEpiX2);
					num++;
					num3 = -4148496;
					continue;
				case 14:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(DhZbdMKNkujxkBYZovsLjyUUFhq[num4]));
						num3 = -4148495;
						continue;
					}
					goto case 6;
				case 9:
					aHPRwjEykMDbpqxpTXLQNJbOCnE = 0;
					num3 = -4148506;
					continue;
				case 18:
				{
					int num8;
					if (P_0[num6] != null)
					{
						num3 = -4148483;
						num8 = num3;
					}
					else
					{
						num3 = -4148491;
						num8 = num3;
					}
					continue;
				}
				case 17:
					list = new List<lYLjuNkLxblMGskfekgsFxSEpiX>();
					num5 = num2 - 1;
					num3 = -4148508;
					continue;
				case 7:
					if (lYLjuNkLxblMGskfekgsFxSEpiX2.MVCWNUJrDWfwziBxuAuBAzgJAhiF)
					{
						aHPRwjEykMDbpqxpTXLQNJbOCnE++;
						num3 = -4148491;
						continue;
					}
					goto case 2;
				case 19:
					if (num5 < 0)
					{
						num2 = dhZbdMKNkujxkBYZovsLjyUUFhq?.Count ?? 0;
						count = P_0.Count;
						num3 = -4148511;
						continue;
					}
					goto case 11;
				case 1:
					lYLjuNkLxblMGskfekgsFxSEpiX2.sEJsjYepUiBfnYUEFbfTIGbRtAM = tPOFglCEUenQueqhakDnrjLmVbgq.ProductId;
					lYLjuNkLxblMGskfekgsFxSEpiX2.GbjlnZOlkxhZPSOBDicayQzeaoO = tPOFglCEUenQueqhakDnrjLmVbgq.VendorId;
					lYLjuNkLxblMGskfekgsFxSEpiX2.zuIOHHSFjUvtYoHqYbOkIVnjKLJ = tPOFglCEUenQueqhakDnrjLmVbgq.JoystickId;
					lYLjuNkLxblMGskfekgsFxSEpiX2.qhBaQiBUaifpRBvldoZTqTDFPFqY = tPOFglCEUenQueqhakDnrjLmVbgq.AxisCount;
					num3 = -4148510;
					continue;
				case 21:
					lYLjuNkLxblMGskfekgsFxSEpiX2.lenAIRsoOFqjBdbpibHDlBXGVmR = tPOFglCEUenQueqhakDnrjLmVbgq.ButtonCount;
					lYLjuNkLxblMGskfekgsFxSEpiX2.QQactFjAyaivYJCKROwerenGIZRE = tPOFglCEUenQueqhakDnrjLmVbgq.HatCount;
					num3 = -4148481;
					continue;
				case 8:
					lYLjuNkLxblMGskfekgsFxSEpiX2.XWJGdtiTCNTQbkDNDyOHMuyHxoJn = false;
					num3 = -4148509;
					continue;
				case 10:
					tPOFglCEUenQueqhakDnrjLmVbgq = P_0[num6];
					num3 = -4148492;
					continue;
				case 20:
					lYLjuNkLxblMGskfekgsFxSEpiX2.MVCWNUJrDWfwziBxuAuBAzgJAhiF = tPOFglCEUenQueqhakDnrjLmVbgq.IsBluetoothDevice;
					lYLjuNkLxblMGskfekgsFxSEpiX2.OWynlsqwgASivUcmwQTMqEbSEpd = tPOFglCEUenQueqhakDnrjLmVbgq.BluetoothDeviceName;
					lYLjuNkLxblMGskfekgsFxSEpiX2.fIkYGLxAqHefuTpANtEKPdaCbCFc = tPOFglCEUenQueqhakDnrjLmVbgq.SupportsVibration;
					lYLjuNkLxblMGskfekgsFxSEpiX2.uxkWxbOjiQcJzrqdxdEMzRAvnKk = tPOFglCEUenQueqhakDnrjLmVbgq.VibrationMotorCount;
					lYLjuNkLxblMGskfekgsFxSEpiX2.extension = tPOFglCEUenQueqhakDnrjLmVbgq.ControllerExtension;
					tPOFglCEUenQueqhakDnrjLmVbgq.HyqAXbAgFcqWiYfxZzBDTyqsqlp();
					lYLjuNkLxblMGskfekgsFxSEpiX2.jDkVEgygiHHntkZXtjEwiSihtux();
					num3 = -4148494;
					continue;
				default:
					if (num4 >= num)
					{
						list.ForEach(delegate(lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX3)
						{
							wHkejOBKyruymhvApBBfcXZjNmgH(lYLjuNkLxblMGskfekgsFxSEpiX3, false);
						});
						QNAqfgEMQhqzfWLjYkRwnnHWNmc(dhZbdMKNkujxkBYZovsLjyUUFhq, DhZbdMKNkujxkBYZovsLjyUUFhq, false);
						QNAqfgEMQhqzfWLjYkRwnnHWNmc(DhZbdMKNkujxkBYZovsLjyUUFhq, dhZbdMKNkujxkBYZovsLjyUUFhq, true);
						return;
					}
					goto case 14;
				}
				break;
			}
		}
	}

	private void mrpXieuHWEMeqScxLKfMAzfufkq()
	{
		int num = 0;
		while (num < ySAWzXMlBDpuUMZJSTZdpLsLntr)
		{
			while (true)
			{
				lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2 = DhZbdMKNkujxkBYZovsLjyUUFhq[num];
				int num2 = -1227072272;
				while (true)
				{
					switch (num2 ^ -1227072267)
					{
					case 4:
						num2 = -1227072268;
						continue;
					case 1:
						break;
					case 5:
						if (lYLjuNkLxblMGskfekgsFxSEpiX2 != null)
						{
							if (pyimnvsUyirvCGgwqkCsOmauCTw)
							{
								goto IL_004d;
							}
							goto case 0;
						}
						goto case 3;
					case 0:
						lYLjuNkLxblMGskfekgsFxSEpiX2.Update();
						num2 = -1227072266;
						continue;
					case 3:
						num++;
						num2 = -1227072265;
						continue;
					default:
						goto end_IL_002e;
					}
					break;
					IL_004d:
					int num3;
					if (lYLjuNkLxblMGskfekgsFxSEpiX2.XWJGdtiTCNTQbkDNDyOHMuyHxoJn)
					{
						num2 = -1227072266;
						num3 = num2;
					}
					else
					{
						num2 = -1227072267;
						num3 = num2;
					}
				}
				continue;
				end_IL_002e:
				break;
			}
		}
	}

	private bool BooOvjDDXJCPvNBIKejrMetJcRQF(vbkjNjHATCWdCHIMnyXZzpSXcCp P_0)
	{
		try
		{
			return P_0.cFCFOdaTTBYIltMLsjQtdfmoKqE();
		}
		catch
		{
			return false;
		}
	}

	private IList<TPOFglCEUenQueqhakDnrjLmVbgq> YOECwsaBcGMJRqdOYDzBLdxXBjF()
	{
		return dgeymjwCdGAtHTMwapVjdBigBLF.GetJoysticks<TPOFglCEUenQueqhakDnrjLmVbgq>();
	}

	private void ViJmTrtaYTomRaMXivkMijSGBsTd(int P_0, int P_1, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_2, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(lYLjuNkLxblMGskfekgsFxSEpiX.JioKUzANjtCPjECxIaCGfNSKwPx);
			goto IL_001a;
		}
		goto IL_00cc;
		IL_00cc:
		bool flag = P_0 > 0 && P_1 > 0;
		int num = 1407995605;
		goto IL_001f;
		IL_001a:
		num = 1407995600;
		goto IL_001f;
		IL_001f:
		int num2 = default(int);
		lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2 = default(lYLjuNkLxblMGskfekgsFxSEpiX);
		while (true)
		{
			switch (num ^ 0x53EC4ED1)
			{
			case 0:
				break;
			case 2:
				goto IL_0057;
			case 6:
				num2++;
				num = 1407995604;
				continue;
			case 3:
				if (lYLjuNkLxblMGskfekgsFxSEpiX2.inputManagerId < 0)
				{
					lYLjuNkLxblMGskfekgsFxSEpiX2.inputManagerId = kljZIvnOWqRsmwSbuwsBhIvvLbR(P_3);
					lYLjuNkLxblMGskfekgsFxSEpiX2.rewiredId = faTqYhfgwuuVCbrIpddTkYZQAdf();
					UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(lYLjuNkLxblMGskfekgsFxSEpiX2);
					num = 1407995607;
					continue;
				}
				goto case 6;
			case 5:
				goto IL_00b4;
			case 1:
				goto IL_00cc;
			case 8:
				lYLjuNkLxblMGskfekgsFxSEpiX2 = P_3[num2];
				num = 1407995603;
				continue;
			case 9:
				FqLDQLawGkiWwPbgSVXafbrXgsoF(P_1, P_3, dTIPNxKifeGRTLAlxoeMsVuEQGU.SyuwUSifCFiFLJpUObqglHzCCnc.afFbgEzNXvGvvGsLKuJIIflFbruT);
				num2 = 0;
				num = 1407995604;
				continue;
			case 4:
				if (flag)
				{
					HUXcFuUWtJIwxJKGbYwyPfpEvbr(P_1, P_3, P_0, P_2, dTIPNxKifeGRTLAlxoeMsVuEQGU.SyuwUSifCFiFLJpUObqglHzCCnc.afFbgEzNXvGvvGsLKuJIIflFbruT);
					num = 1407995608;
					continue;
				}
				goto case 9;
			default:
				P_3.Sort(lYLjuNkLxblMGskfekgsFxSEpiX.PqQgrmpdNXqmxXMcBHguZRCFinw);
				return;
			}
			break;
			IL_00b4:
			int num3;
			if (num2 >= P_1)
			{
				num = 1407995606;
				num3 = num;
			}
			else
			{
				num = 1407995609;
				num3 = num;
			}
			continue;
			IL_0057:
			int num4;
			if (lYLjuNkLxblMGskfekgsFxSEpiX2 == null)
			{
				num = 1407995607;
				num4 = num;
			}
			else
			{
				num = 1407995602;
				num4 = num;
			}
		}
		goto IL_001a;
	}

	private void gxkqtQMMgQbzFEECEFPoGZzcjBLy(List<lYLjuNkLxblMGskfekgsFxSEpiX> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -34878892;
			while (true)
			{
				switch (num ^ -34878890)
				{
				case 4:
					break;
				case 5:
					if (P_0[num2] != null && P_0[num2].inputManagerId == P_2)
					{
						P_0[num2].inputManagerId = -1;
						num = -34878890;
						continue;
					}
					goto case 0;
				case 1:
				{
					int num3;
					if (num2 != P_1)
					{
						num = -34878893;
						num3 = num;
					}
					else
					{
						num = -34878890;
						num3 = num;
					}
					continue;
				}
				case 2:
					num2 = 0;
					num = -34878891;
					continue;
				case 0:
					num2++;
					num = -34878891;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private bool gwFYeeaoDMFEdccEhpkZULzuLlR(List<lYLjuNkLxblMGskfekgsFxSEpiX> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				if (P_0[num] != null && P_0[num].inputManagerId == P_1)
				{
					num2 = 1898166477;
				}
				else
				{
					num++;
					num2 = 1898166478;
				}
				while (true)
				{
					switch (num2 ^ 0x7123B8CD)
					{
					case 2:
						num2 = 1898166476;
						continue;
					case 1:
						break;
					case 0:
						return false;
					default:
						goto end_IL_002d;
					}
					break;
				}
				continue;
				end_IL_002d:
				break;
			}
		}
		return true;
	}

	private int kljZIvnOWqRsmwSbuwsBhIvvLbR(List<lYLjuNkLxblMGskfekgsFxSEpiX> P_0)
	{
		int num = 0;
		int num3 = default(int);
		bool flag = default(bool);
		int count = default(int);
		while (true)
		{
			int num2 = -1718080527;
			while (true)
			{
				switch (num2 ^ -1718080521)
				{
				case 3:
					break;
				case 5:
					num3++;
					num2 = -1718080522;
					continue;
				case 0:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -1718080523;
						continue;
					}
					goto case 5;
				case 4:
					count = P_0.Count;
					num3 = 0;
					num2 = -1718080522;
					continue;
				case 6:
					flag = false;
					num2 = -1718080525;
					continue;
				case 1:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = -1718080523;
						num4 = num2;
					}
					else
					{
						num2 = -1718080521;
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
					goto case 6;
				}
				break;
			}
		}
	}

	private bool oEQKpQzPwfllmCXbyvwZIGacQVo(List<lYLjuNkLxblMGskfekgsFxSEpiX> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (num < P_0.Count)
		{
			while (true)
			{
				if (P_0[num].rewiredId == P_1)
				{
					return true;
				}
				num++;
				int num2 = -887891675;
				while (true)
				{
					switch (num2 ^ -887891673)
					{
					case 0:
						num2 = -887891674;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
		}
		return false;
	}

	private void HUXcFuUWtJIwxJKGbYwyPfpEvbr(int P_0, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_1, int P_2, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_3, dTIPNxKifeGRTLAlxoeMsVuEQGU.SyuwUSifCFiFLJpUObqglHzCCnc P_4)
	{
		int num = ((P_4 != dTIPNxKifeGRTLAlxoeMsVuEQGU.SyuwUSifCFiFLJpUObqglHzCCnc.afFbgEzNXvGvvGsLKuJIIflFbruT) ? 1 : 2);
		int num2 = 0;
		int num4 = default(int);
		lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2 = default(lYLjuNkLxblMGskfekgsFxSEpiX);
		while (true)
		{
			int num3 = 566677398;
			while (true)
			{
				switch (num3 ^ 0x21C6CF90)
				{
				case 5:
					break;
				default:
					return;
				case 6:
					num3 = 566677392;
					continue;
				case 1:
					num4++;
					num3 = 566677396;
					continue;
				case 3:
					UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(lYLjuNkLxblMGskfekgsFxSEpiX2);
					num3 = 566677393;
					continue;
				case 2:
				{
					lYLjuNkLxblMGskfekgsFxSEpiX2 = P_1[num2];
					int num6;
					if (lYLjuNkLxblMGskfekgsFxSEpiX2 != null)
					{
						num3 = 566677401;
						num6 = num3;
					}
					else
					{
						num3 = 566677399;
						num6 = num3;
					}
					continue;
				}
				case 8:
				{
					lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX3 = P_3[num4];
					if (lYLjuNkLxblMGskfekgsFxSEpiX3 != null && !oEQKpQzPwfllmCXbyvwZIGacQVo(P_1, lYLjuNkLxblMGskfekgsFxSEpiX3.rewiredId) && lYLjuNkLxblMGskfekgsFxSEpiX2.FcvkUyKypZmJCfGSpczJhAaNNjEx(lYLjuNkLxblMGskfekgsFxSEpiX3) >= num)
					{
						lYLjuNkLxblMGskfekgsFxSEpiX2.laWNKiWcrSexnZtRRPyPhNqRVNc(lYLjuNkLxblMGskfekgsFxSEpiX3);
						num3 = 566677395;
						continue;
					}
					goto case 1;
				}
				case 0:
				{
					int num8;
					if (num2 < P_0)
					{
						num3 = 566677394;
						num8 = num3;
					}
					else
					{
						num3 = 566677402;
						num8 = num3;
					}
					continue;
				}
				case 4:
				{
					int num7;
					if (num4 < P_2)
					{
						num3 = 566677400;
						num7 = num3;
					}
					else
					{
						num3 = 566677399;
						num7 = num3;
					}
					continue;
				}
				case 9:
				{
					int num5;
					if (lYLjuNkLxblMGskfekgsFxSEpiX2.inputManagerId >= 0)
					{
						num3 = 566677399;
						num5 = num3;
					}
					else
					{
						num3 = 566677403;
						num5 = num3;
					}
					continue;
				}
				case 7:
					num2++;
					num3 = 566677392;
					continue;
				case 11:
					num4 = 0;
					num3 = 566677396;
					continue;
				case 10:
					return;
				}
				break;
			}
		}
	}

	private void FqLDQLawGkiWwPbgSVXafbrXgsoF(int P_0, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_1, dTIPNxKifeGRTLAlxoeMsVuEQGU.SyuwUSifCFiFLJpUObqglHzCCnc P_2)
	{
		int num = 0;
		dTIPNxKifeGRTLAlxoeMsVuEQGU.SdygmTDVboJRCwHFatkFJoEvXnC sdygmTDVboJRCwHFatkFJoEvXnC = default(dTIPNxKifeGRTLAlxoeMsVuEQGU.SdygmTDVboJRCwHFatkFJoEvXnC);
		dTIPNxKifeGRTLAlxoeMsVuEQGU.SdygmTDVboJRCwHFatkFJoEvXnC current = default(dTIPNxKifeGRTLAlxoeMsVuEQGU.SdygmTDVboJRCwHFatkFJoEvXnC);
		int num5 = default(int);
		while (true)
		{
			lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2;
			int num6;
			switch (0x5E38C993 ^ 0x5E38C992)
			{
			case 0:
				break;
			default:
				lYLjuNkLxblMGskfekgsFxSEpiX2 = P_1[num];
				if (lYLjuNkLxblMGskfekgsFxSEpiX2 != null && lYLjuNkLxblMGskfekgsFxSEpiX2.inputManagerId < 0)
				{
					sdygmTDVboJRCwHFatkFJoEvXnC = null;
					using (IEnumerator<dTIPNxKifeGRTLAlxoeMsVuEQGU.SdygmTDVboJRCwHFatkFJoEvXnC> enumerator = UMsKdJAzyaBSALboFULhgKARVjb.joccDsvMkbNqtLkAGboThijYbVO(lYLjuNkLxblMGskfekgsFxSEpiX2, P_2).GetEnumerator())
					{
						while (true)
						{
							IL_0084:
							int num2;
							int num3;
							if (enumerator.MoveNext())
							{
								num2 = 1580779926;
								num3 = num2;
							}
							else
							{
								num2 = 1580779923;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ 0x5E38C992)
								{
								case 2:
									num2 = 1580779926;
									continue;
								default:
									goto end_IL_0063;
								case 0:
									break;
								case 3:
									sdygmTDVboJRCwHFatkFJoEvXnC = current;
									num2 = 1580779923;
									continue;
								case 4:
									current = enumerator.Current;
									if (!oEQKpQzPwfllmCXbyvwZIGacQVo(P_1, current.VGSrrWYLNAwIbrYoUwvzVCxXdRzc))
									{
										int num4;
										if (current.RgyPfpfFQwdoJNiBIXrQsaliAnP < 0)
										{
											num2 = 1580779922;
											num4 = num2;
										}
										else
										{
											num2 = 1580779921;
											num4 = num2;
										}
										continue;
									}
									break;
								case 1:
									goto end_IL_0063;
								}
								goto IL_0084;
								continue;
								end_IL_0063:
								break;
							}
							break;
						}
					}
					if (sdygmTDVboJRCwHFatkFJoEvXnC != null)
					{
						num5 = sdygmTDVboJRCwHFatkFJoEvXnC.RgyPfpfFQwdoJNiBIXrQsaliAnP;
						goto IL_00f4;
					}
				}
				goto IL_016f;
			case 1:
				goto IL_017d;
				IL_016f:
				num++;
				num6 = 1580779920;
				goto IL_00f9;
				IL_00f9:
				while (true)
				{
					switch (num6 ^ 0x5E38C992)
					{
					case 0:
						break;
					case 3:
						lYLjuNkLxblMGskfekgsFxSEpiX2.inputManagerId = num5;
						lYLjuNkLxblMGskfekgsFxSEpiX2.rewiredId = sdygmTDVboJRCwHFatkFJoEvXnC.VGSrrWYLNAwIbrYoUwvzVCxXdRzc;
						UMsKdJAzyaBSALboFULhgKARVjb.kVadApUnAEuOWsMMZXVNAURVCZW(lYLjuNkLxblMGskfekgsFxSEpiX2);
						num6 = 1580779926;
						continue;
					case 1:
						sdygmTDVboJRCwHFatkFJoEvXnC.RgyPfpfFQwdoJNiBIXrQsaliAnP = num5;
						num6 = 1580779921;
						continue;
					case 5:
						if (!gwFYeeaoDMFEdccEhpkZULzuLlR(P_1, num5))
						{
							num5 = kljZIvnOWqRsmwSbuwsBhIvvLbR(P_1);
							num6 = 1580779923;
							continue;
						}
						goto case 3;
					case 4:
						goto IL_016f;
					default:
						goto IL_017d;
					}
					break;
				}
				goto IL_00f4;
				IL_017d:
				if (num >= P_0)
				{
					return;
				}
				goto default;
				IL_00f4:
				num6 = 1580779927;
				goto IL_00f9;
			}
		}
	}

	private void oGKalEFSMrovSTqbIEPCXcczDyVh()
	{
		if (dgeymjwCdGAtHTMwapVjdBigBLF.RdolmFtiYxRtXQsWHnoHzcUZsHk(true))
		{
			lTMACTFXWDSejtRxaVyHEsqhUZm = true;
			goto IL_0015;
		}
		goto IL_0037;
		IL_004c:
		int num;
		if (yCIfoAipTphniepDsrKPaDRNhiMJ && bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning && bGpaBMieDdHAVIdvKMObQFtPsiSb.uIPQYCOyPijpbHfLzGABZERoRaI())
		{
			DMCTVklVuaMMWNhSreqsObOptgT();
			num = 1085748350;
			goto IL_001a;
		}
		return;
		IL_0015:
		num = 1085748349;
		goto IL_001a;
		IL_001a:
		switch (num ^ 0x40B7347F)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_0037;
		case 3:
			goto IL_004c;
		case 1:
			return;
		}
		goto IL_0015;
		IL_0037:
		if (lTMACTFXWDSejtRxaVyHEsqhUZm)
		{
			cKRwFlgodEhzBEtlTXbPMDPvWoA();
			num = 1085748348;
			goto IL_001a;
		}
		goto IL_004c;
	}

	private void cKRwFlgodEhzBEtlTXbPMDPvWoA()
	{
		lTMACTFXWDSejtRxaVyHEsqhUZm = false;
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
		{
			return;
		}
		while (true)
		{
			dgeymjwCdGAtHTMwapVjdBigBLF.INaXaDHFVRAFNLXXTDgLCTrNFiua();
			bGpaBMieDdHAVIdvKMObQFtPsiSb.LgoJHLCBitFthTodNHJlYroGYaX();
			int num = -1303613531;
			while (true)
			{
				switch (num ^ -1303613531)
				{
				case 2:
					goto IL_0015;
				default:
					return;
				case 1:
					break;
				case 0:
					return;
				}
				break;
				IL_0015:
				num = -1303613532;
			}
		}
	}

	private void DMCTVklVuaMMWNhSreqsObOptgT()
	{
		dgeymjwCdGAtHTMwapVjdBigBLF.fUuxtFvkFydskviGBsYizrMCeMj();
		if (!yCIfoAipTphniepDsrKPaDRNhiMJ)
		{
			return;
		}
		while (true)
		{
			int num = -600951684;
			while (true)
			{
				IList<TPOFglCEUenQueqhakDnrjLmVbgq> list;
				switch (num ^ -600951683)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					list = YOECwsaBcGMJRqdOYDzBLdxXBjF();
					if (uiZVLTRAQmHuNjHshitfwEPawrk(list))
					{
						goto IL_0041;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_0041:
				ZEQTqdrQJjlBCMOvIzIIORNAzup(list);
				num = -600951683;
			}
		}
	}

	private bool uiZVLTRAQmHuNjHshitfwEPawrk(IList<TPOFglCEUenQueqhakDnrjLmVbgq> P_0)
	{
		int num = 0;
		int num5 = default(int);
		int count = default(int);
		int num4 = default(int);
		int count2 = default(int);
		while (true)
		{
			int num2;
			int num3;
			if (num < DhZbdMKNkujxkBYZovsLjyUUFhq.Count)
			{
				num2 = -314023447;
				num3 = num2;
			}
			else
			{
				num2 = -314023453;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -314023445)
				{
				case 0:
					num2 = -314023447;
					continue;
				case 7:
				{
					int num6;
					if (num5 < count)
					{
						num2 = -314023443;
						num6 = num2;
					}
					else
					{
						num2 = -314023454;
						num6 = num2;
					}
					continue;
				}
				case 3:
				{
					int num7;
					if (num4 < count2)
					{
						num2 = -314023442;
						num7 = num2;
					}
					else
					{
						num2 = -314023441;
						num7 = num2;
					}
					continue;
				}
				case 2:
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num] != null && !DhZbdMKNkujxkBYZovsLjyUUFhq[num].IsValid)
					{
						return true;
					}
					num++;
					num2 = -314023446;
					continue;
				case 6:
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num5] != null && !WIuHAzptWodiXNDYRqDNuIenjew(P_0, DhZbdMKNkujxkBYZovsLjyUUFhq[num5].instanceGuid))
					{
						return true;
					}
					num5++;
					num2 = -314023444;
					continue;
				case 1:
					break;
				case 4:
					count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
					num5 = 0;
					num2 = -314023444;
					continue;
				case 8:
					count2 = P_0.Count;
					num4 = 0;
					num2 = -314023448;
					continue;
				case 5:
					if (P_0[num4] != null && !nbmciSAlDSdytTnfmLWpviEBliTd(P_0[num4].InstanceGuid))
					{
						return true;
					}
					num4++;
					num2 = -314023448;
					continue;
				default:
					return false;
				}
				break;
			}
		}
	}

	private bool nbmciSAlDSdytTnfmLWpviEBliTd(Guid P_0)
	{
		int count = DhZbdMKNkujxkBYZovsLjyUUFhq.Count;
		int num = 0;
		while (true)
		{
			int num2 = -824767202;
			while (true)
			{
				switch (num2 ^ -824767201)
				{
				case 2:
					break;
				case 1:
					num2 = -824767201;
					continue;
				case 0:
				{
					int num3;
					if (num < count)
					{
						num2 = -824767205;
						num3 = num2;
					}
					else
					{
						num2 = -824767204;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (DhZbdMKNkujxkBYZovsLjyUUFhq[num] != null && DhZbdMKNkujxkBYZovsLjyUUFhq[num].instanceGuid == P_0)
					{
						return true;
					}
					num++;
					num2 = -824767201;
					continue;
				default:
					return false;
				}
				break;
			}
		}
	}

	private bool WIuHAzptWodiXNDYRqDNuIenjew(IList<TPOFglCEUenQueqhakDnrjLmVbgq> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = 1834644114;
			while (true)
			{
				switch (num2 ^ 0x6D5A7297)
				{
				case 4:
					break;
				case 1:
					if (P_0[num].InstanceGuid == P_1)
					{
						return true;
					}
					goto IL_0049;
				case 0:
				{
					int num3;
					if (num < count)
					{
						num2 = 1834644116;
						num3 = num2;
					}
					else
					{
						num2 = 1834644117;
						num3 = num2;
					}
					continue;
				}
				case 5:
					num2 = 1834644119;
					continue;
				case 3:
					if (P_0[num] != null)
					{
						num2 = 1834644118;
						continue;
					}
					goto IL_0049;
				default:
					{
						return false;
					}
					IL_0049:
					num++;
					num2 = 1834644119;
					continue;
				}
				break;
			}
		}
	}

	private void QNAqfgEMQhqzfWLjYkRwnnHWNmc(List<lYLjuNkLxblMGskfekgsFxSEpiX> P_0, List<lYLjuNkLxblMGskfekgsFxSEpiX> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num3 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX3 = default(lYLjuNkLxblMGskfekgsFxSEpiX);
		int num6 = default(int);
		bool flag = default(bool);
		lYLjuNkLxblMGskfekgsFxSEpiX lYLjuNkLxblMGskfekgsFxSEpiX2 = default(lYLjuNkLxblMGskfekgsFxSEpiX);
		while (true)
		{
			IL_0139:
			int num;
			if (P_0 != null)
			{
				num = P_0.Count;
				goto IL_00b9;
			}
			int num2 = -2050568597;
			goto IL_000c;
			IL_00b9:
			num3 = num;
			num4 = P_1?.Count ?? 0;
			num5 = 0;
			num2 = -2050568594;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num2 ^ -2050568605)
				{
				case 9:
					num2 = -2050568604;
					continue;
				case 3:
					wHkejOBKyruymhvApBBfcXZjNmgH(P_0[num5], P_2);
					num2 = -2050568602;
					continue;
				case 10:
					lYLjuNkLxblMGskfekgsFxSEpiX3 = P_1[num6];
					num2 = -2050568593;
					continue;
				case 6:
					break;
				case 5:
					num5++;
					num2 = -2050568594;
					continue;
				case 8:
					goto end_IL_000c;
				case 0:
					goto IL_00d3;
				case 11:
					goto IL_00ec;
				case 4:
					flag = true;
					num2 = -2050568600;
					continue;
				case 12:
					goto IL_0111;
				case 2:
					num6++;
					num2 = -2050568605;
					continue;
				case 7:
					goto IL_0139;
				case 1:
					lYLjuNkLxblMGskfekgsFxSEpiX2 = P_0[num5];
					if (lYLjuNkLxblMGskfekgsFxSEpiX2 == null)
					{
						goto case 5;
					}
					flag = false;
					if (P_1 != null)
					{
						num6 = 0;
						num2 = -2050568605;
						continue;
					}
					goto IL_00ec;
				default:
					if (num5 >= num3)
					{
						return;
					}
					goto case 1;
				}
				int num7;
				if (!(lYLjuNkLxblMGskfekgsFxSEpiX2.instanceGuid == lYLjuNkLxblMGskfekgsFxSEpiX3.instanceGuid))
				{
					num2 = -2050568607;
					num7 = num2;
				}
				else
				{
					num2 = -2050568601;
					num7 = num2;
				}
				continue;
				IL_0111:
				int num8;
				if (lYLjuNkLxblMGskfekgsFxSEpiX3 != null)
				{
					num2 = -2050568603;
					num8 = num2;
				}
				else
				{
					num2 = -2050568607;
					num8 = num2;
				}
				continue;
				IL_00d3:
				int num9;
				if (num6 >= num4)
				{
					num2 = -2050568600;
					num9 = num2;
				}
				else
				{
					num2 = -2050568599;
					num9 = num2;
				}
				continue;
				IL_00ec:
				int num10;
				if (!flag)
				{
					num2 = -2050568608;
					num10 = num2;
				}
				else
				{
					num2 = -2050568602;
					num10 = num2;
				}
				continue;
				end_IL_000c:
				break;
			}
			num = 0;
			goto IL_00b9;
		}
	}

	private void wHkejOBKyruymhvApBBfcXZjNmgH(lYLjuNkLxblMGskfekgsFxSEpiX P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
			return;
		}
		while (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			int num = 328513952;
			while (true)
			{
				switch (num ^ 0x1394B9A1)
				{
				case 0:
					goto IL_001d;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_001d:
				num = 328513955;
			}
		}
	}

	private bool QdjFbhivHyWOJIdqVKGlvWgkVXXl()
	{
		try
		{
			int num = 0;
			tPBjZZpAtSQYcuGDlfDVOARrNX.IxiRznNLccenLgseDrJPlJNbHPI(null, ref num, XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<StoefIABSsMqhewHfXAHNOAILfl>());
			while (true)
			{
				switch (-945837609 ^ -945837610)
				{
				case 0:
					break;
				default:
					goto end_IL_0010;
				case 1:
					if (ZqUclFGnPscdViyFMMwBPbZEeVjm != num)
					{
						ZqUclFGnPscdViyFMMwBPbZEeVjm = num;
						return true;
					}
					goto end_IL_0010;
				case 2:
					goto end_IL_0010;
				}
				continue;
				end_IL_0010:
				break;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (aHPRwjEykMDbpqxpTXLQNJbOCnE > 0 && dgeymjwCdGAtHTMwapVjdBigBLF.tFFgYAdaQhinKkFvHMyMHGcGcZJS())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void GNdfrTAopLHigBkrmDIuQQdtIMHd(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void fMtomNjKOcZysxvDghtgvUWVTAV(lYLjuNkLxblMGskfekgsFxSEpiX P_0)
	{
		wHkejOBKyruymhvApBBfcXZjNmgH(P_0, false);
	}
}
