using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class XcPhIaWtTJbGpRDjcDeYUxCKXJV : PlatformInputManager
{
	private class KAGhbYqdLHHcHxnWsqoxVNPpXVc : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int GHfkhSadilGfAxFyuOxXFmXoNB;

		private int pypcACKajeDXMgihCBBcoMfRHezM;

		private int hByaRVpMQNtgYWGKTUTkcHssvjs;

		public Guid ocZIgneRSUDLHotByUrmWfynkiD;

		public string ZYYfRsBXtJZNvqHpPAZvqlbYCpl;

		public int gDvaREBGcnxwFAEDwOmcDKOhWYks;

		public string eGxTXNjqmCsabYsADiQdVSwZbLC;

		private int ijxelHigybruBiYdNSiiNzGQTwsf = 29;

		private int vgSbQnhkfGJDrjOShKPojdhsCSkQ = 20;

		private float[] wbUISjltnzArWBKEUafkjffKERTS;

		private bool[] CFcByKWcDyyvXwtHigPcgEPuCPR;

		private bool[] klHkLpTOsMbjpdFFJNtEXfbBtXsc;

		private float[] vrPDvCyDbykJNAQrhFKvoSuhhTc;

		private bool[] AGmMYuMLCHqhmIjFUTlXzBtYZIb;

		private HardwareJoystickMap_InputManager kABaypBwJpdJPQfaNrcsDzJUopW;

		private bool qEBChkdMenIWbHajRwlLiEqfOWVs;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return GHfkhSadilGfAxFyuOxXFmXoNB;
			}
			set
			{
				GHfkhSadilGfAxFyuOxXFmXoNB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return pypcACKajeDXMgihCBBcoMfRHezM;
			}
			set
			{
				pypcACKajeDXMgihCBBcoMfRHezM = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (!(ZYYfRsBXtJZNvqHpPAZvqlbYCpl != "Unknown Controller"))
				{
					return eGxTXNjqmCsabYsADiQdVSwZbLC;
				}
				return ZYYfRsBXtJZNvqHpPAZvqlbYCpl;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				long? result = default(long?);
				if (hByaRVpMQNtgYWGKTUTkcHssvjs < 1)
				{
					while (true)
					{
						int num = -1074971204;
						while (true)
						{
							switch (num ^ -1074971203)
							{
							case 2:
								break;
							case 1:
								goto IL_0027;
							default:
								return result;
							}
							break;
							IL_0027:
							result = null;
							num = -1074971203;
						}
					}
				}
				return hByaRVpMQNtgYWGKTUTkcHssvjs;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return hByaRVpMQNtgYWGKTUTkcHssvjs;
			}
			set
			{
				hByaRVpMQNtgYWGKTUTkcHssvjs = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				if (!ReInput.isWindowsStandaloneWebplayerOrEditorPlatform)
				{
					goto IL_002c;
				}
				if (UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
				{
					goto IL_000e;
				}
				goto IL_003b;
				IL_003b:
				return MiscTools.CreateGuidHashSHA1(name);
				IL_000e:
				int num = 1433164777;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x556C5BE8)
				{
				case 2:
					break;
				case 1:
					goto IL_002c;
				default:
					goto IL_003b;
				}
				goto IL_000e;
				IL_002c:
				if (UnityTools.effectivePlatform == Platform.OSX)
				{
					num = 1433164776;
					goto IL_0013;
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + hByaRVpMQNtgYWGKTUTkcHssvjs);
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

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public KAGhbYqdLHHcHxnWsqoxVNPpXVc()
		{
			while (true)
			{
				int num = 128774818;
				while (true)
				{
					switch (num ^ 0x7ACF2A1)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						pypcACKajeDXMgihCBBcoMfRHezM = -1;
						GHfkhSadilGfAxFyuOxXFmXoNB = -1;
						num = 128774817;
						continue;
					case 0:
						hByaRVpMQNtgYWGKTUTkcHssvjs = 0;
						num = 128774816;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public void NbodIzVoMOIfxhiTmzGcfYqHqqpP()
		{
			cYHcXCOFpORyFoNYyhyTldjiUMD();
			ocZIgneRSUDLHotByUrmWfynkiD = kABaypBwJpdJPQfaNrcsDzJUopW.hardwareMapIdentifier.guid;
			while (true)
			{
				int num = 1046850976;
				while (true)
				{
					switch (num ^ 0x3E65ADA2)
					{
					case 4:
						break;
					case 2:
						ZYYfRsBXtJZNvqHpPAZvqlbYCpl = kABaypBwJpdJPQfaNrcsDzJUopW.controllerName;
						wbUISjltnzArWBKEUafkjffKERTS = new float[ijxelHigybruBiYdNSiiNzGQTwsf];
						CFcByKWcDyyvXwtHigPcgEPuCPR = new bool[vgSbQnhkfGJDrjOShKPojdhsCSkQ];
						klHkLpTOsMbjpdFFJNtEXfbBtXsc = new bool[ijxelHigybruBiYdNSiiNzGQTwsf];
						num = 1046850979;
						continue;
					case 3:
						vrPDvCyDbykJNAQrhFKvoSuhhTc = new float[29];
						num = 1046850978;
						continue;
					case 1:
						AGmMYuMLCHqhmIjFUTlXzBtYZIb = new bool[29];
						num = 1046850977;
						continue;
					default:
						Update();
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (hByaRVpMQNtgYWGKTUTkcHssvjs <= 0)
			{
				return;
			}
			while (true)
			{
				LohzVQqBwLzIhfHcmJazTCcvEuub();
				pZGbWgDuiUJknDkmqIIleMKulPyz();
				OmvEduKEMDwCfGsAUMYnJwvhRxA();
				int num = 620341367;
				while (true)
				{
					switch (num ^ 0x24F9A875)
					{
					case 0:
						goto IL_000a;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000a:
					num = 620341364;
				}
			}
		}

		public int texDHprRVSCDIhdEcHxFsscbHjUA(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0)
		{
			if (P_0.eGxTXNjqmCsabYsADiQdVSwZbLC == eGxTXNjqmCsabYsADiQdVSwZbLC && P_0.gDvaREBGcnxwFAEDwOmcDKOhWYks == gDvaREBGcnxwFAEDwOmcDKOhWYks)
			{
				return 2;
			}
			if (P_0.eGxTXNjqmCsabYsADiQdVSwZbLC == eGxTXNjqmCsabYsADiQdVSwZbLC)
			{
				return 1;
			}
			return 0;
		}

		private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = krUOmbAYEeuGHMmeXeVaoHvSDPw();
			while (true)
			{
				int num = 950726055;
				while (true)
				{
					switch (num ^ 0x38AAEDA6)
					{
					case 0:
						break;
					case 1:
						goto IL_0031;
					default:
						P_0.hardwareHatCount = 0;
						P_0.hw_productName = eGxTXNjqmCsabYsADiQdVSwZbLC;
						return;
					}
					break;
					IL_0031:
					P_0.hardwareIdentifier = wrMbWRvukXjTEBqvwwUtLByTtlYl();
					P_0.hardwareAxisCount = 0;
					P_0.hardwareButtonCount = 0;
					num = 950726052;
				}
			}
		}

		private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedController P_0)
		{
			VDeqJOjTSTlabFOpcCmVfVrbzeiM((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = 84860060;
				while (true)
				{
					switch (num ^ 0x50EDC9D)
					{
					case 2:
						break;
					case 1:
						P_0.sourceJoystick = this;
						P_0.gameHardwareMap = kABaypBwJpdJPQfaNrcsDzJUopW.ToGameHardwareControllerMap();
						P_0.instanceName = eGxTXNjqmCsabYsADiQdVSwZbLC;
						P_0.productName = eGxTXNjqmCsabYsADiQdVSwZbLC;
						num = 84860062;
						continue;
					case 3:
						P_0.isXInputDevice = false;
						num = 84860061;
						continue;
					default:
						P_0.axisCount = ijxelHigybruBiYdNSiiNzGQTwsf;
						P_0.buttonCount = vgSbQnhkfGJDrjOShKPojdhsCSkQ;
						P_0.controllerTypeGuid = ocZIgneRSUDLHotByUrmWfynkiD;
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (ijxelHigybruBiYdNSiiNzGQTwsf == dataUpdater.axisCount)
			{
				if (vgSbQnhkfGJDrjOShKPojdhsCSkQ != dataUpdater.buttonCount)
				{
					goto IL_0022;
				}
				goto IL_00f7;
			}
			goto IL_011e;
			IL_011e:
			throw new Exception("This controller signature does not match the data object!");
			IL_0022:
			int num = 1617465867;
			goto IL_0027;
			IL_0027:
			int num2 = default(int);
			bool[] buttonValues = default(bool[]);
			int num3 = default(int);
			float[] axisValues = default(float[]);
			bool[] axisHasBeenPressedOSXLinux = default(bool[]);
			while (true)
			{
				switch (num ^ 0x6068920D)
				{
				case 9:
					break;
				default:
					return;
				case 3:
					if (num2 >= ijxelHigybruBiYdNSiiNzGQTwsf)
					{
						buttonValues = dataUpdater.buttonValues;
						num = 1617465862;
						continue;
					}
					goto case 1;
				case 10:
					if (buttonValues[num3] != CFcByKWcDyyvXwtHigPcgEPuCPR[num3])
					{
						buttonValues[num3] = CFcByKWcDyyvXwtHigPcgEPuCPR[num3];
						num = 1617465871;
						continue;
					}
					goto case 2;
				case 7:
					if (num3 >= vgSbQnhkfGJDrjOShKPojdhsCSkQ)
					{
						if (qEBChkdMenIWbHajRwlLiEqfOWVs && !dataUpdater.hasReceivedInput)
						{
							dataUpdater.hasReceivedInput = true;
							num = 1617465865;
							continue;
						}
						return;
					}
					goto case 10;
				case 1:
					if (axisValues[num2] != wbUISjltnzArWBKEUafkjffKERTS[num2])
					{
						axisValues[num2] = wbUISjltnzArWBKEUafkjffKERTS[num2];
						num = 1617465861;
						continue;
					}
					goto case 5;
				case 0:
					goto IL_00f7;
				case 11:
					num3 = 0;
					num = 1617465866;
					continue;
				case 6:
					goto IL_011e;
				case 5:
					num2++;
					num = 1617465870;
					continue;
				case 2:
					num3++;
					num = 1617465866;
					continue;
				case 8:
					if (axisHasBeenPressedOSXLinux[num2] != klHkLpTOsMbjpdFFJNtEXfbBtXsc[num2])
					{
						axisHasBeenPressedOSXLinux[num2] = klHkLpTOsMbjpdFFJNtEXfbBtXsc[num2];
						num = 1617465864;
						continue;
					}
					goto case 5;
				case 4:
					return;
				}
				break;
			}
			goto IL_0022;
			IL_00f7:
			axisValues = dataUpdater.axisValues;
			axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			num2 = 0;
			num = 1617465870;
			goto IL_0027;
		}

		public void YExCxnhSFxrlSWqkzPncFvqbthU(int P_0)
		{
			if (P_0 < 1)
			{
				return;
			}
			if (P_0 > 16)
			{
				while (true)
				{
					switch (-929171039 ^ -929171037)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			unityId = P_0;
		}

		public void jRiCHqhvGjWtHCkEAFTxEjkkdOtK()
		{
			hByaRVpMQNtgYWGKTUTkcHssvjs = 0;
			AnWpKwNKJbsVcxTXGsPrCzUWjfg();
		}

		public BridgedControllerHWInfo qOeDHherkAoikMXOIsfGhJBfRvh()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			VDeqJOjTSTlabFOpcCmVfVrbzeiM(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			VDeqJOjTSTlabFOpcCmVfVrbzeiM(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(GHfkhSadilGfAxFyuOxXFmXoNB);
		}

		private void LohzVQqBwLzIhfHcmJazTCcvEuub()
		{
			int num = 0;
			while (true)
			{
				int num2 = 130361290;
				while (true)
				{
					switch (num2 ^ 0x7C527CB)
					{
					case 2:
						break;
					case 0:
						num++;
						num2 = 130361295;
						continue;
					case 3:
					{
						float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(hByaRVpMQNtgYWGKTUTkcHssvjs, num);
						if (vrPDvCyDbykJNAQrhFKvoSuhhTc[num] != joystickAxisValueByJoystickId)
						{
							vrPDvCyDbykJNAQrhFKvoSuhhTc[num] = joystickAxisValueByJoystickId;
							if (!AGmMYuMLCHqhmIjFUTlXzBtYZIb[num] && joystickAxisValueByJoystickId != 0f)
							{
								AGmMYuMLCHqhmIjFUTlXzBtYZIb[num] = true;
								num2 = 130361291;
								continue;
							}
						}
						goto case 0;
					}
					case 1:
						num2 = 130361295;
						continue;
					default:
						if (num >= 29)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private void pZGbWgDuiUJknDkmqIIleMKulPyz()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)kABaypBwJpdJPQfaNrcsDzJUopW.map).Axes_orig;
			if (axes_orig == null)
			{
				goto IL_0019;
			}
			goto IL_008d;
			IL_0019:
			int num = 453457018;
			goto IL_001e;
			IL_001e:
			int num2 = default(int);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ 0x1B073471)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (!qEBChkdMenIWbHajRwlLiEqfOWVs && wbUISjltnzArWBKEUafkjffKERTS[num2] != 0f)
					{
						qEBChkdMenIWbHajRwlLiEqfOWVs = true;
						num = 453457016;
						continue;
					}
					goto case 9;
				case 0:
					goto IL_008d;
				case 5:
					num = 453457017;
					continue;
				case 3:
					wbUISjltnzArWBKEUafkjffKERTS[num2] = num3;
					num = 453457021;
					continue;
				case 12:
					if (klHkLpTOsMbjpdFFJNtEXfbBtXsc[num2])
					{
						goto case 1;
					}
					if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num4 = dLTmadjmjVluMhSlcxbDwCyzhb(axes_orig[num2].sourceAxis);
						klHkLpTOsMbjpdFFJNtEXfbBtXsc[num2] = num4 != 0f;
						num = 453457008;
						continue;
					}
					goto case 10;
				case 10:
					klHkLpTOsMbjpdFFJNtEXfbBtXsc[num2] = true;
					num = 453457008;
					continue;
				case 11:
					return;
				case 6:
					goto IL_010f;
				case 7:
					if (axes_orig[num2] != null)
					{
						if (num2 >= ijxelHigybruBiYdNSiiNzGQTwsf)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						goto IL_010f;
					}
					goto case 9;
				case 8:
					goto IL_015b;
				case 9:
					num2++;
					num = 453457017;
					continue;
				case 4:
					return;
				}
				break;
				IL_015b:
				int num5;
				if (num2 < axes_orig.Length)
				{
					num = 453457014;
					num5 = num;
				}
				else
				{
					num = 453457013;
					num5 = num;
				}
				continue;
				IL_010f:
				num3 = dLTmadjmjVluMhSlcxbDwCyzhb(axes_orig[num2]);
				int num6;
				if (wbUISjltnzArWBKEUafkjffKERTS[num2] != num3)
				{
					num = 453457010;
					num6 = num;
				}
				else
				{
					num = 453457016;
					num6 = num;
				}
			}
			goto IL_0019;
			IL_008d:
			num2 = 0;
			num = 453457012;
			goto IL_001e;
		}

		private void OmvEduKEMDwCfGsAUMYnJwvhRxA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)kABaypBwJpdJPQfaNrcsDzJUopW.map).Buttons_orig;
			int num2 = default(int);
			while (true)
			{
				int num = -1354273171;
				while (true)
				{
					switch (num ^ -1354273179)
					{
					case 6:
						break;
					case 0:
						num2 = 0;
						num = -1354273180;
						continue;
					case 4:
						return;
					case 5:
						num2++;
						num = -1354273180;
						continue;
					case 7:
						if (CFcByKWcDyyvXwtHigPcgEPuCPR[num2])
						{
							qEBChkdMenIWbHajRwlLiEqfOWVs = true;
							num = -1354273184;
							continue;
						}
						goto case 5;
					case 2:
					{
						bool flag = VMMfdBCZsMnRqIWVFlCcPeWKEbcs(buttons_orig[num2]);
						if (CFcByKWcDyyvXwtHigPcgEPuCPR[num2] != flag)
						{
							CFcByKWcDyyvXwtHigPcgEPuCPR[num2] = flag;
							int num4;
							if (!qEBChkdMenIWbHajRwlLiEqfOWVs)
							{
								num = -1354273182;
								num4 = num;
							}
							else
							{
								num = -1354273184;
								num4 = num;
							}
							continue;
						}
						goto case 5;
					}
					case 8:
					{
						int num3;
						if (buttons_orig == null)
						{
							num = -1354273183;
							num3 = num;
						}
						else
						{
							num = -1354273179;
							num3 = num;
						}
						continue;
					}
					case 3:
						if (num2 >= vgSbQnhkfGJDrjOShKPojdhsCSkQ)
						{
							throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
						}
						goto case 2;
					default:
						if (num2 >= buttons_orig.Length)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private bool VMMfdBCZsMnRqIWVFlCcPeWKEbcs(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					goto IL_0016;
				}
				goto IL_04c7;
			}
			int num2;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			int num3 = default(int);
			UnityAxis unityHat_sourceAxis = default(UnityAxis);
			UnityAxis unityHat_sourceAxis2 = default(UnityAxis);
			float num4 = default(float);
			float num5 = default(float);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = dLTmadjmjVluMhSlcxbDwCyzhb(P_0.sourceAxis);
				if (!(MathTools.Abs(num) <= P_0.axisDeadZone))
				{
					if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
					{
						return false;
					}
					return true;
				}
				num2 = 630463969;
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
				{
					if (P_0.sourceKeyCode != KeyCode.None)
					{
						return Input.GetKey(P_0.sourceKeyCode);
					}
					num2 = 630463997;
				}
				else
				{
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						goto IL_058f;
					}
					customCalculation = P_0.customCalculation;
					if (!(customCalculation == null))
					{
						if (customCalculation.ResultType != TypeWrapper.DataType.Single)
						{
							return false;
						}
						customCalculationSourceData = P_0.customCalculationSourceData;
						if (customCalculationSourceData == null)
						{
							num2 = 630463999;
						}
						else
						{
							num3 = 0;
							num2 = 630463992;
						}
					}
					else
					{
						num2 = 630463973;
					}
				}
			}
			else
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None)
				{
					goto IL_0332;
				}
				if (P_0.unityHat_sourceAxis2 != UnityAxis.None)
				{
					unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
					unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
					num4 = dLTmadjmjVluMhSlcxbDwCyzhb(unityHat_sourceAxis);
					num5 = dLTmadjmjVluMhSlcxbDwCyzhb(unityHat_sourceAxis2);
					num2 = 630463977;
				}
				else
				{
					num2 = 630463990;
				}
			}
			goto IL_001b;
			IL_01e7:
			if (cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues1.x, num4) && cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues1.y, num5))
			{
				return true;
			}
			if (cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues2.x, num4) && cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues2.y, num5))
			{
				return true;
			}
			if (cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues3.x, num4) && cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(P_0.unityHat_isActiveAxisValues3.y, num5))
			{
				return true;
			}
			goto IL_058f;
			IL_04c7:
			bool flag = default(bool);
			int num6 = default(int);
			if (!P_0.requireMultipleButtons)
			{
				if (P_0.sourceButton != UnityButton.None)
				{
					return VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.sourceButton);
				}
				num2 = 630463971;
			}
			else
			{
				flag = false;
				num6 = 0;
				num2 = 630463979;
			}
			goto IL_001b;
			IL_058f:
			return false;
			IL_0016:
			num2 = 630463968;
			goto IL_001b;
			IL_001b:
			float x = default(float);
			bool flag3 = default(bool);
			float y = default(float);
			int num8 = default(int);
			float num7 = default(float);
			while (true)
			{
				bool flag2;
				switch (num2 ^ 0x25941DEA)
				{
				case 4:
					break;
				case 1:
					goto IL_00ab;
				case 12:
					switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
						goto IL_0148;
					case HardwareElementSourceTypeWithHat.Axis:
						goto IL_02eb;
					case HardwareElementSourceTypeWithHat.Key:
						goto IL_0362;
					case HardwareElementSourceTypeWithHat.Hat:
						goto IL_041d;
					}
					num2 = 630463985;
					continue;
				case 5:
					num2 = 630463985;
					continue;
				case 22:
					x = P_0.unityHat_zeroValues.x;
					num2 = 630463984;
					continue;
				case 7:
					customCalculation.AddData(flag3 ? 1f : 0f);
					num2 = 630463985;
					continue;
				case 19:
					goto IL_0148;
				case 20:
					goto IL_016b;
				case 3:
					if (!P_0.unityHat_checkNeverPressed)
					{
						goto case 22;
					}
					if (SToFsgEycWQumVxWrBoTUVXmFXe(unityHat_sourceAxis) || SToFsgEycWQumVxWrBoTUVXmFXe(unityHat_sourceAxis2))
					{
						x = P_0.unityHat_zeroValues.x;
						y = P_0.unityHat_zeroValues.y;
						num2 = 630463991;
						continue;
					}
					goto case 24;
				case 25:
					goto IL_01da;
				case 16:
					goto IL_0292;
				case 2:
					goto IL_02b2;
				case 30:
					num2 = 630463978;
					continue;
				case 26:
					y = P_0.unityHat_zeroValues.y;
					num2 = 630463976;
					continue;
				case 8:
					goto IL_02eb;
				case 24:
					x = P_0.unityHat_neverPressedZeroValues.x;
					y = P_0.unityHat_neverPressedZeroValues.y;
					num2 = 630463989;
					continue;
				case 28:
					goto IL_0332;
				case 6:
					goto IL_0362;
				case 31:
					num2 = 630463976;
					continue;
				case 15:
					return false;
				case 9:
					return false;
				case 10:
					num8 = 0;
					num2 = 630463988;
					continue;
				case 27:
					goto IL_041d;
				case 13:
					customCalculation.AddData((num7 != 0f) ? 1f : 0f);
					num2 = 630463983;
					continue;
				case 0:
					goto IL_0453;
				case 11:
					return false;
				case 17:
					goto IL_04c7;
				case 23:
					return false;
				case 14:
					goto IL_051a;
				case 29:
					num2 = 630463976;
					continue;
				case 21:
					return false;
				default:
					goto IL_054e;
					IL_0362:
					if (OvPmetbLOzGTnrNEbasPHjdXHxO(customCalculationSourceData[num3], out flag2))
					{
						customCalculation.AddData(flag2 ? 1f : 0f);
						num2 = 630463985;
						continue;
					}
					goto IL_041d;
					IL_041d:
					num3++;
					num2 = 630463992;
					continue;
				}
				break;
				IL_054e:
				if (num3 < customCalculationSourceData.Length)
				{
					goto IL_051a;
				}
				goto IL_0556;
				IL_051a:
				int num9;
				if (customCalculationSourceData[num3] != null)
				{
					num2 = 630463974;
					num9 = num2;
				}
				else
				{
					num2 = 630463985;
					num9 = num2;
				}
				continue;
				IL_0148:
				int num10;
				if (!CNLYWSDukDLIebRCVDbXgTDdxkD(customCalculationSourceData[num3], out flag3))
				{
					num2 = 630463985;
					num10 = num2;
				}
				else
				{
					num2 = 630463981;
					num10 = num2;
				}
				continue;
				IL_00ab:
				if (num6 >= P_0.requiredButtons.Length)
				{
					goto IL_00b9;
				}
				goto IL_016b;
				IL_0453:
				int num11;
				if (num8 >= P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num2 = 630463995;
					num11 = num2;
				}
				else
				{
					num2 = 630463994;
					num11 = num2;
				}
				continue;
				IL_01da:
				if (MathTools.Approximately(num5, y))
				{
					return false;
				}
				goto IL_01e7;
				IL_016b:
				if (!VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.requiredButtons[num6]))
				{
					return false;
				}
				flag = true;
				num6++;
				num2 = 630463979;
				continue;
				IL_02b2:
				if (MathTools.Approximately(num4, x))
				{
					num2 = 630463987;
					continue;
				}
				goto IL_01e7;
				IL_02eb:
				int num12;
				if (daEAMZGyDtAPgCRioQNAKEpznocl(customCalculationSourceData[num3], out num7))
				{
					num2 = 630463975;
					num12 = num2;
				}
				else
				{
					num2 = 630463985;
					num12 = num2;
				}
				continue;
				IL_0292:
				if (VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.ignoreIfButtonsActiveButtons[num8]))
				{
					return false;
				}
				num8++;
				num2 = 630463978;
			}
			goto IL_0016;
			IL_00b9:
			if (flag)
			{
				return true;
			}
			return false;
			IL_0556:
			if (!customCalculation.Process())
			{
				return false;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return false;
			}
			return (float)customCalculation.Result != 0f;
			IL_0332:
			return false;
		}

		private bool cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float dLTmadjmjVluMhSlcxbDwCyzhb(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			CustomCalculation customCalculation = default(CustomCalculation);
			int num;
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			float result2 = default(float);
			float result = default(float);
			float result3 = default(float);
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			int num2 = default(int);
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Custom:
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					num = -1124414578;
				}
				else
				{
					customCalculationSourceData = P_0.customCalculationSourceData;
					num = -1124414592;
				}
				goto IL_0031;
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					result2 = 1f;
					num = -1124414577;
					goto IL_0031;
				}
				goto IL_0145;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				if (!Input.GetKey(P_0.sourceKeyCode))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					result = 1f;
					num = -1124414587;
					goto IL_0031;
				}
				goto IL_0134;
			case HardwareElementSourceTypeWithHat.Axis:
				goto IL_0200;
			default:
				{
					return 0f;
				}
				IL_0031:
				while (true)
				{
					switch (num ^ -1124414588)
					{
					case 0:
						num = -1124414590;
						continue;
					case 7:
						return result;
					case 3:
						return result3;
					case 9:
					{
						HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
						float item;
						if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && daEAMZGyDtAPgCRioQNAKEpznocl(customCalculationSourceData[num2], out item))
						{
							customCalculation.AddData(item);
							num = -1124414591;
							continue;
						}
						goto case 5;
					}
					case 2:
						num = -1124414582;
						continue;
					case 1:
						num = -1124414589;
						continue;
					case 13:
						break;
					case 8:
						goto IL_0145;
					case 14:
						if (num2 >= customCalculationSourceData.Length)
						{
							goto IL_0160;
						}
						goto case 12;
					case 11:
						return result2;
					case 5:
						num2++;
						num = -1124414582;
						continue;
					case 12:
						if (customCalculationSourceData[num2] != null)
						{
							sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num2].sourceType;
							num = -1124414579;
							continue;
						}
						goto case 5;
					case 6:
						goto IL_0200;
					case 10:
						return 0f;
					case 4:
						goto IL_0251;
					default:
						return 0f;
					}
					break;
					IL_0251:
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num2 = 0;
					num = -1124414586;
					continue;
					IL_0160:
					if (!customCalculation.Process())
					{
						return 0f;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						num = -1124414581;
						continue;
					}
					return customCalculation.Result;
				}
				goto IL_0134;
				IL_0200:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!SToFsgEycWQumVxWrBoTUVXmFXe(P_0.sourceAxis))
				{
					return 0f;
				}
				result3 = dLTmadjmjVluMhSlcxbDwCyzhb(P_0.sourceAxis);
				num = -1124414585;
				goto IL_0031;
				IL_0145:
				result2 = -1f;
				num = -1124414577;
				goto IL_0031;
				IL_0134:
				result = -1f;
				num = -1124414589;
				goto IL_0031;
			}
		}

		private float dLTmadjmjVluMhSlcxbDwCyzhb(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return vrPDvCyDbykJNAQrhFKvoSuhhTc[num];
		}

		private bool VMMfdBCZsMnRqIWVFlCcPeWKEbcs(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(hByaRVpMQNtgYWGKTUTkcHssvjs, buttonIndex);
		}

		private bool CNLYWSDukDLIebRCVDbXgTDdxkD(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			UnityButton sourceElement = (UnityButton)P_0.sourceElement;
			if (sourceElement == UnityButton.None)
			{
				return false;
			}
			P_1 = VMMfdBCZsMnRqIWVFlCcPeWKEbcs(sourceElement);
			return true;
		}

		private bool OvPmetbLOzGTnrNEbasPHjdXHxO(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 3)
			{
				goto IL_000c;
			}
			KeyCode sourceElement = (KeyCode)P_0.sourceElement;
			int num;
			if (sourceElement == KeyCode.None)
			{
				num = 1769497465;
				goto IL_0011;
			}
			P_1 = Input.GetKey(sourceElement);
			return true;
			IL_000c:
			num = 1769497466;
			goto IL_0011;
			IL_0011:
			switch (num ^ 0x69786378)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_000c;
		}

		private bool daEAMZGyDtAPgCRioQNAKEpznocl(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			AxisRange sourceAxisRange = default(AxisRange);
			while (true)
			{
				int num = -1970931331;
				while (true)
				{
					switch (num ^ -1970931330)
					{
					case 4:
						break;
					case 1:
						P_1 *= -1f;
						num = -1970931332;
						continue;
					case 8:
						if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
						{
							P_1 = 0f;
							num = -1970931333;
							continue;
						}
						goto case 5;
					case 6:
						switch (sourceAxisRange)
						{
						case AxisRange.Negative:
							goto IL_00b1;
						case AxisRange.Positive:
							goto IL_00cb;
						}
						num = -1970931338;
						continue;
					case 0:
						goto IL_00b1;
					case 9:
						goto IL_00cb;
					case 7:
						sourceAxisRange = P_0.sourceAxisRange;
						num = -1970931336;
						continue;
					case 3:
						if (sourceElement == UnityAxis.None)
						{
							return false;
						}
						P_1 = dLTmadjmjVluMhSlcxbDwCyzhb(sourceElement);
						num = -1970931335;
						continue;
					case 5:
					{
						int num2;
						if (!P_0.invert)
						{
							num = -1970931332;
							num2 = num;
						}
						else
						{
							num = -1970931329;
							num2 = num;
						}
						continue;
					}
					default:
						{
							return true;
						}
						IL_00cb:
						if (P_1 < 0f)
						{
							P_1 = 0f;
							num = -1970931338;
							continue;
						}
						goto case 8;
						IL_00b1:
						if (P_1 > 0f)
						{
							P_1 = 0f;
							num = -1970931338;
							continue;
						}
						goto case 8;
					}
					break;
				}
			}
		}

		private bool SToFsgEycWQumVxWrBoTUVXmFXe(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return AGmMYuMLCHqhmIjFUTlXzBtYZIb[num];
		}

		private void cYHcXCOFpORyFoNYyhyTldjiUMD()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = qOeDHherkAoikMXOIsfGhJBfRvh();
			if (UnityTools.isAndroidPlatform)
			{
				goto IL_0011;
			}
			goto IL_01f1;
			IL_0011:
			int num = -1316755140;
			goto IL_0016;
			IL_0016:
			List<int> vids = default(List<int>);
			List<int> pids = default(List<int>);
			int num2 = default(int);
			string text = default(string);
			while (true)
			{
				switch (num ^ -1316755144)
				{
				case 6:
					break;
				default:
					return;
				case 4:
					if (Regex.IsMatch(eGxTXNjqmCsabYsADiQdVSwZbLC, "Xbox Wireless Controller.*"))
					{
						UnityTools.externalTools.GetDeviceVIDPIDs(out vids, out pids);
						num = -1316755151;
						continue;
					}
					goto IL_01f1;
				case 1:
					ijxelHigybruBiYdNSiiNzGQTwsf = kABaypBwJpdJPQfaNrcsDzJUopW.axisCount;
					vgSbQnhkfGJDrjOShKPojdhsCSkQ = kABaypBwJpdJPQfaNrcsDzJUopW.buttonCount;
					num = -1316755137;
					continue;
				case 11:
					if (vids[num2] == 1118 && pids[num2] == 736)
					{
						bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
						num = -1316755152;
						continue;
					}
					goto case 12;
				case 3:
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						kABaypBwJpdJPQfaNrcsDzJUopW.controllerName = text;
						num = -1316755139;
						continue;
					}
					goto case 5;
				case 12:
					num2++;
					num = -1316755142;
					continue;
				case 10:
					if (kABaypBwJpdJPQfaNrcsDzJUopW.useSystemName && !string.IsNullOrEmpty(eGxTXNjqmCsabYsADiQdVSwZbLC))
					{
						text = Regex.Replace(eGxTXNjqmCsabYsADiQdVSwZbLC, "\\s+", " ");
						num = -1316755141;
						continue;
					}
					goto case 5;
				case 13:
					num = -1316755142;
					continue;
				case 5:
					if (UnityTools.isIOSPlatform && kABaypBwJpdJPQfaNrcsDzJUopW.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
					{
						string text2 = rmEyKBDsbcEOXeWQoQjQXdzFlvP(eGxTXNjqmCsabYsADiQdVSwZbLC);
						if (!string.IsNullOrEmpty(text2))
						{
							kABaypBwJpdJPQfaNrcsDzJUopW.controllerName = text2;
							num = -1316755143;
							continue;
						}
					}
					goto case 1;
				case 2:
					goto IL_01be;
				case 8:
					num = -1316755144;
					continue;
				case 9:
					num2 = 0;
					num = -1316755147;
					continue;
				case 0:
					goto IL_01f1;
				case 14:
					if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
					{
						Rewired.Logger.LogError("Default hardware map not found!");
						return;
					}
					goto case 10;
				case 7:
					return;
				}
				break;
				IL_01be:
				int num3;
				if (num2 >= vids.Count)
				{
					num = -1316755144;
					num3 = num;
				}
				else
				{
					num = -1316755149;
					num3 = num;
				}
			}
			goto IL_0011;
			IL_01f1:
			kABaypBwJpdJPQfaNrcsDzJUopW = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			num = -1316755146;
			goto IL_0016;
		}

		private void AnWpKwNKJbsVcxTXGsPrCzUWjfg()
		{
			Array.Clear(CFcByKWcDyyvXwtHigPcgEPuCPR, 0, CFcByKWcDyyvXwtHigPcgEPuCPR.Length);
			Array.Clear(wbUISjltnzArWBKEUafkjffKERTS, 0, wbUISjltnzArWBKEUafkjffKERTS.Length);
		}

		private string wrMbWRvukXjTEBqvwwUtLByTtlYl()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), ReInput.webplayerPlatform.ToString(), krUOmbAYEeuGHMmeXeVaoHvSDPw().ToString(), eGxTXNjqmCsabYsADiQdVSwZbLC));
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(eGxTXNjqmCsabYsADiQdVSwZbLC, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), krUOmbAYEeuGHMmeXeVaoHvSDPw().ToString(), arg));
			}
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), krUOmbAYEeuGHMmeXeVaoHvSDPw().ToString(), eGxTXNjqmCsabYsADiQdVSwZbLC));
		}

		private InputSource krUOmbAYEeuGHMmeXeVaoHvSDPw()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(eGxTXNjqmCsabYsADiQdVSwZbLC))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int DdthPkejlSCBRHlGiPFXBIiIcvj(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, KAGhbYqdLHHcHxnWsqoxVNPpXVc P_1)
		{
			if (P_0.inputManagerId < P_1.inputManagerId)
			{
				return -1;
			}
			if (P_0.inputManagerId > P_1.inputManagerId)
			{
				return 1;
			}
			return 0;
		}

		public static int ZChZhxNhXPDqvHdlpWAljTKVCDs(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, KAGhbYqdLHHcHxnWsqoxVNPpXVc P_1)
		{
			if (P_0.unityId < P_1.unityId)
			{
				return -1;
			}
			if (P_0.unityId > P_1.unityId)
			{
				return 1;
			}
			return 0;
		}

		private static string rmEyKBDsbcEOXeWQoQjQXdzFlvP(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			while (true)
			{
				int num = -122870624;
				while (true)
				{
					switch (num ^ -122870622)
					{
					case 0:
						break;
					case 2:
						if (!string.IsNullOrEmpty(input))
						{
							goto IL_0048;
						}
						goto default;
					default:
						return input;
					}
					break;
					IL_0048:
					input = input.Trim();
					num = -122870621;
				}
			}
		}
	}

	private class fGqAWhxgerOiYrGSUOvBLqFbYND
	{
		public enum lgUhEPkcjotShCbVkyfQkjieHWkC
		{
			OhRlOZGftuFdhsJLJdBYcXflSzkM = 0,
			miFZPclZwwzlANpYVeOKmkxlzSo = 1
		}

		public class TeALczgNmLhgwhNymmtYXowPgfYG
		{
			public int lJGmoPjWlZhCnfYmPrnrnNrpiFd;

			public int gDvaREBGcnxwFAEDwOmcDKOhWYks;

			public string vjITxzvWrKXTVVGmBWwpPCtMVsl;

			public int hkuClqGgyrjaNFrDJJuCSthMWeZ;

			public bool texDHprRVSCDIhdEcHxFsscbHjUA(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, lgUhEPkcjotShCbVkyfQkjieHWkC P_1)
			{
				if (P_0.rewiredId == lJGmoPjWlZhCnfYmPrnrnNrpiFd)
				{
					return true;
				}
				switch (P_1)
				{
				case lgUhEPkcjotShCbVkyfQkjieHWkC.OhRlOZGftuFdhsJLJdBYcXflSzkM:
					if (gDvaREBGcnxwFAEDwOmcDKOhWYks == P_0.gDvaREBGcnxwFAEDwOmcDKOhWYks)
					{
						return vjITxzvWrKXTVVGmBWwpPCtMVsl == P_0.eGxTXNjqmCsabYsADiQdVSwZbLC;
					}
					return false;
				case lgUhEPkcjotShCbVkyfQkjieHWkC.miFZPclZwwzlANpYVeOKmkxlzSo:
					return vjITxzvWrKXTVVGmBWwpPCtMVsl == P_0.eGxTXNjqmCsabYsADiQdVSwZbLC;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private List<TeALczgNmLhgwhNymmtYXowPgfYG> KbaDSiCRyndUgELDxxppquzLFodU;

		public int Count
		{
			get
			{
				return KbaDSiCRyndUgELDxxppquzLFodU.Count;
			}
		}

		public fGqAWhxgerOiYrGSUOvBLqFbYND()
		{
			KbaDSiCRyndUgELDxxppquzLFodU = new List<TeALczgNmLhgwhNymmtYXowPgfYG>();
		}

		public void CzcBIezjgBkIUujMOARHJgPbWVOP(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				int num = 0;
				int num2 = -842022227;
				while (true)
				{
					switch (num2 ^ -842022227)
					{
					case 3:
						num2 = -842022228;
						continue;
					default:
						return;
					case 6:
						return;
					case 5:
						iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, KbaDSiCRyndUgELDxxppquzLFodU.Count - 1);
						num2 = -842022225;
						continue;
					case 11:
						KbaDSiCRyndUgELDxxppquzLFodU[num].lJGmoPjWlZhCnfYmPrnrnNrpiFd = P_0.rewiredId;
						num2 = -842022231;
						continue;
					case 4:
						KbaDSiCRyndUgELDxxppquzLFodU[num].vjITxzvWrKXTVVGmBWwpPCtMVsl = P_0.eGxTXNjqmCsabYsADiQdVSwZbLC;
						num2 = -842022230;
						continue;
					case 0:
						if (num >= count)
						{
							KbaDSiCRyndUgELDxxppquzLFodU.Add(new TeALczgNmLhgwhNymmtYXowPgfYG
							{
								lJGmoPjWlZhCnfYmPrnrnNrpiFd = P_0.rewiredId,
								vjITxzvWrKXTVVGmBWwpPCtMVsl = P_0.eGxTXNjqmCsabYsADiQdVSwZbLC,
								gDvaREBGcnxwFAEDwOmcDKOhWYks = P_0.gDvaREBGcnxwFAEDwOmcDKOhWYks,
								hkuClqGgyrjaNFrDJJuCSthMWeZ = P_0.inputManagerId
							});
							num2 = -842022232;
							continue;
						}
						goto case 10;
					case 7:
						KbaDSiCRyndUgELDxxppquzLFodU[num].gDvaREBGcnxwFAEDwOmcDKOhWYks = P_0.gDvaREBGcnxwFAEDwOmcDKOhWYks;
						num2 = -842022236;
						continue;
					case 8:
						num++;
						num2 = -842022227;
						continue;
					case 1:
						break;
					case 9:
						KbaDSiCRyndUgELDxxppquzLFodU[num].hkuClqGgyrjaNFrDJJuCSthMWeZ = P_0.inputManagerId;
						iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, num);
						num2 = -842022229;
						continue;
					case 10:
					{
						int num3;
						if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, lgUhEPkcjotShCbVkyfQkjieHWkC.OhRlOZGftuFdhsJLJdBYcXflSzkM))
						{
							num2 = -842022234;
							num3 = num2;
						}
						else
						{
							num2 = -842022235;
							num3 = num2;
						}
						continue;
					}
					case 2:
						return;
					}
					break;
				}
			}
		}

		public bool hVhfCpEYePxtliVMkmzCRpiiDkB(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, lgUhEPkcjotShCbVkyfQkjieHWkC P_1)
		{
			int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 729081611;
					num3 = num2;
				}
				else
				{
					num2 = 729081610;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2B74E70A)
					{
					case 2:
						num2 = 729081611;
						continue;
					case 3:
						break;
					case 4:
						return true;
					case 1:
						if (!KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
						{
							num++;
							num2 = 729081609;
						}
						else
						{
							num2 = 729081614;
						}
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		public TeALczgNmLhgwhNymmtYXowPgfYG lYJFZOeYSDYSWqqagvNTnOjxepl(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, lgUhEPkcjotShCbVkyfQkjieHWkC P_1)
		{
			int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
					{
						return KbaDSiCRyndUgELDxxppquzLFodU[num];
					}
					num++;
					int num2 = 974733857;
					while (true)
					{
						switch (num2 ^ 0x3A194223)
						{
						case 0:
							num2 = 974733858;
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

		public int tZuNWtSCplPhyqDRGNVBVrTnWqi(TeALczgNmLhgwhNymmtYXowPgfYG P_0)
		{
			int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					if (KbaDSiCRyndUgELDxxppquzLFodU[num] == P_0)
					{
						return num;
					}
					num++;
					int num2 = -178440202;
					while (true)
					{
						switch (num2 ^ -178440202)
						{
						case 2:
							num2 = -178440201;
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

		private void iAyKOJFTncPoHepzJVFmwURBpNi(int P_0, int P_1)
		{
			int num = KbaDSiCRyndUgELDxxppquzLFodU.Count - 1;
			while (true)
			{
				int num2 = -1347702461;
				while (true)
				{
					switch (num2 ^ -1347702463)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						num--;
						num2 = -1347702464;
						continue;
					case 5:
						if (num != P_1 && KbaDSiCRyndUgELDxxppquzLFodU[num].lJGmoPjWlZhCnfYmPrnrnNrpiFd == P_0)
						{
							KbaDSiCRyndUgELDxxppquzLFodU.RemoveAt(num);
							num2 = -1347702462;
							continue;
						}
						goto case 3;
					case 2:
						num2 = -1347702464;
						continue;
					case 1:
					{
						int num3;
						if (num < 0)
						{
							num2 = -1347702459;
							num3 = num2;
						}
						else
						{
							num2 = -1347702460;
							num3 = num2;
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
	}

	private List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> jkFiqNnyAtbymFOLlvWZRfYeLku;

	private int QpGtgOrxdSaeYYJRHgHfdBynVbjv;

	private fGqAWhxgerOiYrGSUOvBLqFbYND cBQhEyiNFbRkGCtCdGNTEMPiFbh;

	private bool oCfgXkGkSgDkbBQjCfrbIAyBZc;

	private UpdateLoopType KyGQivhvNcexgOdgEkqkdUhAdys;

	private UpdateLoopType yQgeUBihcLYUsNeHXLYEtcCaMLNn;

	private TimerAbs GaCIgQSpFgupZQzfXHPjXkEDWee;

	private Action<int, ControllerDataUpdater> xykDZfHJBUnQEfowVcHAJyncPoER;

	private PlatformInputManager hdSfCWqBbgExirMqfOCeUEacXMD;

	private readonly IUnifiedKeyboardSource dMVOHlUpMgJkcnaPZirDgGfhrhg;

	private readonly IUnifiedMouseSource PDDnSkvTvmIDDFGrrLzkDpNidEa;

	private bool XPBknkFkAQtacJlRXVhvWaItFQh;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return QpGtgOrxdSaeYYJRHgHfdBynVbjv;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return hdSfCWqBbgExirMqfOCeUEacXMD;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return null;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.Fallback;
		}
	}

	public XcPhIaWtTJbGpRDjcDeYUxCKXJV(UpdateLoopSetting updateLoopSetting)
	{
		hdSfCWqBbgExirMqfOCeUEacXMD = this;
		dMVOHlUpMgJkcnaPZirDgGfhrhg = new UnityUnifiedKeyboardSource();
		PDDnSkvTvmIDDFGrrLzkDpNidEa = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			int num = 0;
			if (num < list.Count)
			{
				yQgeUBihcLYUsNeHXLYEtcCaMLNn = list[num];
			}
		}
		xykDZfHJBUnQEfowVcHAJyncPoER = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		GaCIgQSpFgupZQzfXHPjXkEDWee = new TimerAbs(1f);
		cBQhEyiNFbRkGCtCdGNTEMPiFbh = new fGqAWhxgerOiYrGSUOvBLqFbYND();
		pBKGiqCzbgfPGMFhRdFSwUDshjx();
		oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
		GaCIgQSpFgupZQzfXHPjXkEDWee.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		KyGQivhvNcexgOdgEkqkdUhAdys = updateLoop;
		xeYDWaFQsgWnujAWncOMeikceiV();
		if (oCfgXkGkSgDkbBQjCfrbIAyBZc)
		{
			lMlcWXDhUZyoYToHgCauFZahHGiP();
			goto IL_001b;
		}
		goto IL_0039;
		IL_0039:
		OojMLjXcFZUGyMEfOYjCmtjMhke(updateLoop);
		int num = -1269202944;
		goto IL_0020;
		IL_001b:
		num = -1269202941;
		goto IL_0020;
		IL_0020:
		switch (num ^ -1269202943)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_0039;
		case 1:
			return;
		}
		goto IL_001b;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		(dMVOHlUpMgJkcnaPZirDgGfhrhg as IDisposable).Dispose();
		(PDDnSkvTvmIDDFGrrLzkDpNidEa as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return xykDZfHJBUnQEfowVcHAJyncPoER;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		int num = 0;
		while (true)
		{
			int num2 = 2007439857;
			while (true)
			{
				switch (num2 ^ 0x77A719F3)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					num++;
					num2 = 2007439858;
					continue;
				case 6:
				{
					int num3;
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num].inputManagerId == assignedControllerId)
					{
						num2 = 2007439862;
						num3 = num2;
					}
					else
					{
						num2 = 2007439856;
						num3 = num2;
					}
					continue;
				}
				case 5:
					jkFiqNnyAtbymFOLlvWZRfYeLku[num].FillData(data);
					return;
				case 1:
					if (num >= QpGtgOrxdSaeYYJRHgHfdBynVbjv)
					{
						Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
						num2 = 2007439863;
						continue;
					}
					goto case 6;
				case 2:
					num2 = 2007439858;
					continue;
				case 4:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
		while (true)
		{
			int num = -831986469;
			while (true)
			{
				switch (num ^ -831986470)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (_SystemDeviceConnectedEvent != null)
					{
						goto IL_002d;
					}
					return;
				case 2:
					return;
				}
				break;
				IL_002d:
				_SystemDeviceConnectedEvent();
				num = -831986472;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
		while (true)
		{
			int num = -1593604215;
			while (true)
			{
				switch (num ^ -1593604216)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (_SystemDeviceDisconnectedEvent != null)
					{
						goto IL_002d;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_002d:
				_SystemDeviceDisconnectedEvent();
				num = -1593604216;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		int num = 0;
		int num2 = default(int);
		while (true)
		{
			int num3;
			if (num >= jkFiqNnyAtbymFOLlvWZRfYeLku.Count)
			{
				num2 = 0;
				num3 = 1126042222;
				goto IL_0009;
			}
			goto IL_0099;
			IL_0009:
			while (true)
			{
				switch (num3 ^ 0x431E0A69)
				{
				case 0:
					num3 = 1126042223;
					continue;
				case 1:
					break;
				case 2:
					jkFiqNnyAtbymFOLlvWZRfYeLku[num].jRiCHqhvGjWtHCkEAFTxEjkkdOtK();
					num3 = 1126042218;
					continue;
				case 5:
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num2].rewiredId == joystickId)
					{
						jkFiqNnyAtbymFOLlvWZRfYeLku[num2].YExCxnhSFxrlSWqkzPncFvqbthU(unityJoystickId);
						return;
					}
					goto case 4;
				case 6:
					goto IL_0099;
				case 3:
					num++;
					num3 = 1126042216;
					continue;
				case 4:
					num2++;
					num3 = 1126042222;
					continue;
				default:
					if (num2 >= jkFiqNnyAtbymFOLlvWZRfYeLku.Count)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
			continue;
			IL_0099:
			int num4;
			if (jkFiqNnyAtbymFOLlvWZRfYeLku[num].unityId != unityJoystickId)
			{
				num3 = 1126042218;
				num4 = num3;
			}
			else
			{
				num3 = 1126042219;
				num4 = num3;
			}
			goto IL_0009;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return PDDnSkvTvmIDDFGrrLzkDpNidEa;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return dMVOHlUpMgJkcnaPZirDgGfhrhg;
	}

	private void pBKGiqCzbgfPGMFhRdFSwUDshjx()
	{
		pBKGiqCzbgfPGMFhRdFSwUDshjx(CBnhsalFktmtiXqaKtmByJSPkEd());
	}

	private void pBKGiqCzbgfPGMFhRdFSwUDshjx(string[] P_0)
	{
		int num = 0;
		List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> list = jkFiqNnyAtbymFOLlvWZRfYeLku;
		int qpGtgOrxdSaeYYJRHgHfdBynVbjv = QpGtgOrxdSaeYYJRHgHfdBynVbjv;
		jkFiqNnyAtbymFOLlvWZRfYeLku = new List<KAGhbYqdLHHcHxnWsqoxVNPpXVc>();
		int num3 = default(int);
		int num5 = default(int);
		KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc = default(KAGhbYqdLHHcHxnWsqoxVNPpXVc);
		string text = default(string);
		while (true)
		{
			int num2 = -2081112198;
			while (true)
			{
				switch (num2 ^ -2081112196)
				{
				case 2:
					break;
				case 14:
					num3++;
					num2 = -2081112199;
					continue;
				case 9:
					num3 = 0;
					num2 = -2081112202;
					continue;
				case 7:
					num5++;
					num2 = -2081112193;
					continue;
				case 4:
					num++;
					num2 = -2081112197;
					continue;
				case 1:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.eGxTXNjqmCsabYsADiQdVSwZbLC = text;
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.ZYYfRsBXtJZNvqHpPAZvqlbYCpl = text;
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.gDvaREBGcnxwFAEDwOmcDKOhWYks = num5;
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.unityId = num5 + 1;
					num2 = -2081112196;
					continue;
				case 11:
					text = StringTools.SanitizeDeviceString(P_0[num5]);
					if (UnityTools.IsValidUnityJoystickName(text))
					{
						kAGhbYqdLHHcHxnWsqoxVNPpXVc = new KAGhbYqdLHHcHxnWsqoxVNPpXVc();
						num2 = -2081112195;
						continue;
					}
					goto case 7;
				case 0:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.NbodIzVoMOIfxhiTmzGcfYqHqqpP();
					jkFiqNnyAtbymFOLlvWZRfYeLku.Add(kAGhbYqdLHHcHxnWsqoxVNPpXVc);
					num2 = -2081112200;
					continue;
				case 3:
					if (num5 >= P_0.Length)
					{
						QpGtgOrxdSaeYYJRHgHfdBynVbjv = num;
						nFPQMeOiyGmsFomDtcaSCOUgIsTF(qpGtgOrxdSaeYYJRHgHfdBynVbjv, num, list, jkFiqNnyAtbymFOLlvWZRfYeLku);
						num2 = -2081112203;
						continue;
					}
					goto case 11;
				case 12:
					num2 = -2081112193;
					continue;
				case 10:
					num2 = -2081112199;
					continue;
				case 13:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(jkFiqNnyAtbymFOLlvWZRfYeLku[num3]));
						num2 = -2081112206;
						continue;
					}
					goto case 14;
				case 6:
					num5 = 0;
					num2 = -2081112208;
					continue;
				case 5:
				{
					int num4;
					if (num3 < num)
					{
						num2 = -2081112207;
						num4 = num2;
					}
					else
					{
						num2 = -2081112204;
						num4 = num2;
					}
					continue;
				}
				default:
					oQChKjbOquuMrWKdTwrmVgDaXkc(list, jkFiqNnyAtbymFOLlvWZRfYeLku, false);
					oQChKjbOquuMrWKdTwrmVgDaXkc(jkFiqNnyAtbymFOLlvWZRfYeLku, list, true);
					return;
				}
				break;
			}
		}
	}

	private void OojMLjXcFZUGyMEfOYjCmtjMhke(UpdateLoopType P_0)
	{
		int count = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -55209688;
				num3 = num2;
			}
			else
			{
				num2 = -55209686;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -55209685)
				{
				case 0:
					num2 = -55209688;
					continue;
				default:
					return;
				case 3:
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num] != null)
					{
						jkFiqNnyAtbymFOLlvWZRfYeLku[num].Update();
						num2 = -55209687;
						continue;
					}
					goto case 2;
				case 4:
					break;
				case 2:
					num++;
					num2 = -55209681;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private string[] CBnhsalFktmtiXqaKtmByJSPkEd()
	{
		return Input.GetJoystickNames();
	}

	private void nFPQMeOiyGmsFomDtcaSCOUgIsTF(int P_0, int P_1, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_2, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(KAGhbYqdLHHcHxnWsqoxVNPpXVc.ZChZhxNhXPDqvHdlpWAljTKVCDs);
			goto IL_0017;
		}
		goto IL_0054;
		IL_0054:
		bool flag = P_0 > 0 && P_1 > 0;
		int num = 1043320397;
		goto IL_001c;
		IL_0017:
		num = 1043320385;
		goto IL_001c;
		IL_001c:
		KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc = default(KAGhbYqdLHHcHxnWsqoxVNPpXVc);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x3E2FCE45)
			{
			case 6:
				break;
			case 4:
				goto IL_0054;
			case 7:
				kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId = IojKdiCykxLgoivdxmqNHsMNBtN(P_3);
				num = 1043320389;
				continue;
			case 1:
				rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC.miFZPclZwwzlANpYVeOKmkxlzSo);
				num = 1043320391;
				continue;
			case 8:
				if (flag)
				{
					rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC.OhRlOZGftuFdhsJLJdBYcXflSzkM);
					num = 1043320388;
					continue;
				}
				goto case 2;
			case 5:
				kAGhbYqdLHHcHxnWsqoxVNPpXVc = P_3[num2];
				if (kAGhbYqdLHHcHxnWsqoxVNPpXVc != null)
				{
					goto IL_00b4;
				}
				goto case 3;
			case 0:
				kAGhbYqdLHHcHxnWsqoxVNPpXVc.rewiredId = ReInput.GetNewJoystickId();
				cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(kAGhbYqdLHHcHxnWsqoxVNPpXVc);
				num = 1043320390;
				continue;
			case 3:
				num2++;
				num = 1043320396;
				continue;
			case 2:
				xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC.OhRlOZGftuFdhsJLJdBYcXflSzkM);
				xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC.miFZPclZwwzlANpYVeOKmkxlzSo);
				num2 = 0;
				num = 1043320396;
				continue;
			default:
				if (num2 >= P_1)
				{
					P_3.Sort(KAGhbYqdLHHcHxnWsqoxVNPpXVc.DdthPkejlSCBRHlGiPFXBIiIcvj);
					return;
				}
				goto case 5;
			}
			break;
			IL_00b4:
			int num3;
			if (kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId >= 0)
			{
				num = 1043320390;
				num3 = num;
			}
			else
			{
				num = 1043320386;
				num3 = num;
			}
		}
		goto IL_0017;
	}

	private void YzqMoBhvKRalBOYGHRNonNnPINV(List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 284962572;
			while (true)
			{
				switch (num ^ 0x10FC2F0F)
				{
				case 2:
					break;
				default:
					return;
				case 5:
					num2++;
					num = 284962571;
					continue;
				case 4:
				{
					int num3;
					if (num2 >= count)
					{
						num = 284962574;
						num3 = num;
					}
					else
					{
						num = 284962575;
						num3 = num;
					}
					continue;
				}
				case 3:
					num2 = 0;
					num = 284962571;
					continue;
				case 0:
					if (num2 != P_1 && P_0[num2] != null && P_0[num2].inputManagerId == P_2)
					{
						P_0[num2].inputManagerId = -1;
						num = 284962570;
						continue;
					}
					goto case 5;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private bool WFsHpGVScPZlQaWKivTImrGOHRY(List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_0, int P_1)
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
				int num2 = -871582377;
				while (true)
				{
					switch (num2 ^ -871582377)
					{
					case 2:
						num2 = -871582378;
						continue;
					case 1:
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

	private int IojKdiCykxLgoivdxmqNHsMNBtN(List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = -458013958;
			while (true)
			{
				switch (num2 ^ -458013956)
				{
				case 4:
					break;
				case 6:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = -458013955;
					continue;
				case 3:
					num3++;
					num2 = -458013959;
					continue;
				case 5:
				{
					int num4;
					if (num3 < count)
					{
						num2 = -458013964;
						num4 = num2;
					}
					else
					{
						num2 = -458013954;
						num4 = num2;
					}
					continue;
				}
				case 0:
					num2 = -458013954;
					continue;
				case 8:
				{
					int num5;
					if (P_0[num3] != null)
					{
						num2 = -458013957;
						num5 = num2;
					}
					else
					{
						num2 = -458013953;
						num5 = num2;
					}
					continue;
				}
				case 1:
					num2 = -458013959;
					continue;
				case 7:
					if (P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -458013956;
						continue;
					}
					goto case 3;
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

	private bool QHMDmJGdAwPrsYvhnfrFmKuYnKq(List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2 = -962202433;
			while (true)
			{
				switch (num2 ^ -962202437)
				{
				case 2:
					break;
				case 4:
					num2 = -962202438;
					continue;
				case 0:
					if (P_0[num].rewiredId == P_1)
					{
						num2 = -962202440;
						continue;
					}
					num++;
					num2 = -962202438;
					continue;
				case 3:
					return true;
				default:
					if (num >= P_0.Count)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void rXDbrbtyNWDCpRVSolUyjKvqIhp(int P_0, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_1, int P_2, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_3, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC P_4)
	{
		int num = ((P_4 != fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC.OhRlOZGftuFdhsJLJdBYcXflSzkM) ? 1 : 2);
		int num2 = 0;
		KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc2 = default(KAGhbYqdLHHcHxnWsqoxVNPpXVc);
		int num5 = default(int);
		while (num2 < P_0)
		{
			while (true)
			{
				KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc = P_1[num2];
				int num3;
				if (kAGhbYqdLHHcHxnWsqoxVNPpXVc != null)
				{
					int num4;
					if (kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId >= 0)
					{
						num3 = 1872297427;
						num4 = num3;
					}
					else
					{
						num3 = 1872297428;
						num4 = num3;
					}
					goto IL_0015;
				}
				goto IL_0109;
				IL_0015:
				while (true)
				{
					switch (num3 ^ 0x6F98FDD2)
					{
					case 10:
						num3 = 1872297434;
						continue;
					case 8:
						break;
					case 9:
						kAGhbYqdLHHcHxnWsqoxVNPpXVc2 = P_3[num5];
						if (kAGhbYqdLHHcHxnWsqoxVNPpXVc2 != null && !QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, kAGhbYqdLHHcHxnWsqoxVNPpXVc2.rewiredId) && kAGhbYqdLHHcHxnWsqoxVNPpXVc.texDHprRVSCDIhdEcHxFsscbHjUA(kAGhbYqdLHHcHxnWsqoxVNPpXVc2) >= num)
						{
							goto IL_00a5;
						}
						goto case 4;
					case 0:
						kAGhbYqdLHHcHxnWsqoxVNPpXVc.unityId = kAGhbYqdLHHcHxnWsqoxVNPpXVc2.unityId;
						num3 = 1872297425;
						continue;
					case 2:
						goto IL_00f1;
					case 1:
						goto IL_0109;
					case 4:
						num5++;
						num3 = 1872297424;
						continue;
					case 3:
						cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(kAGhbYqdLHHcHxnWsqoxVNPpXVc);
						num3 = 1872297430;
						continue;
					case 6:
						num5 = 0;
						num3 = 1872297424;
						continue;
					case 7:
						goto IL_0147;
					default:
						goto end_IL_0051;
					}
					break;
					IL_0147:
					int num6;
					if (!UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						num3 = 1872297426;
						num6 = num3;
					}
					else
					{
						num3 = 1872297425;
						num6 = num3;
					}
					continue;
					IL_00f1:
					int num7;
					if (num5 < P_2)
					{
						num3 = 1872297435;
						num7 = num3;
					}
					else
					{
						num3 = 1872297427;
						num7 = num3;
					}
					continue;
					IL_00a5:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId = kAGhbYqdLHHcHxnWsqoxVNPpXVc2.inputManagerId;
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.rewiredId = kAGhbYqdLHHcHxnWsqoxVNPpXVc2.rewiredId;
					int num8;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform)
					{
						num3 = 1872297429;
						num8 = num3;
					}
					else
					{
						num3 = 1872297425;
						num8 = num3;
					}
				}
				continue;
				IL_0109:
				num2++;
				num3 = 1872297431;
				goto IL_0015;
				continue;
				end_IL_0051:
				break;
			}
		}
	}

	private void xtNfNMKFmfYIygncVYHsbFvnNoe(int P_0, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_1, fGqAWhxgerOiYrGSUOvBLqFbYND.lgUhEPkcjotShCbVkyfQkjieHWkC P_2)
	{
		int num = 0;
		KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc = default(KAGhbYqdLHHcHxnWsqoxVNPpXVc);
		int num4 = default(int);
		fGqAWhxgerOiYrGSUOvBLqFbYND.TeALczgNmLhgwhNymmtYXowPgfYG teALczgNmLhgwhNymmtYXowPgfYG = default(fGqAWhxgerOiYrGSUOvBLqFbYND.TeALczgNmLhgwhNymmtYXowPgfYG);
		while (true)
		{
			int num2;
			int num3;
			if (num >= P_0)
			{
				num2 = 607970140;
				num3 = num2;
			}
			else
			{
				num2 = 607970136;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x243CE35F)
				{
				case 0:
					num2 = 607970136;
					continue;
				default:
					return;
				case 4:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId = num4;
					kAGhbYqdLHHcHxnWsqoxVNPpXVc.rewiredId = teALczgNmLhgwhNymmtYXowPgfYG.lJGmoPjWlZhCnfYmPrnrnNrpiFd;
					cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(kAGhbYqdLHHcHxnWsqoxVNPpXVc);
					num2 = 607970141;
					continue;
				case 2:
					num++;
					num2 = 607970137;
					continue;
				case 5:
					if (!QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, teALczgNmLhgwhNymmtYXowPgfYG.lJGmoPjWlZhCnfYmPrnrnNrpiFd))
					{
						num4 = teALczgNmLhgwhNymmtYXowPgfYG.hkuClqGgyrjaNFrDJJuCSthMWeZ;
						int num6;
						if (num4 >= 0)
						{
							num2 = 607970142;
							num6 = num2;
						}
						else
						{
							num2 = 607970141;
							num6 = num2;
						}
						continue;
					}
					goto case 2;
				case 7:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc = P_1[num];
					if (kAGhbYqdLHHcHxnWsqoxVNPpXVc != null && kAGhbYqdLHHcHxnWsqoxVNPpXVc.inputManagerId < 0)
					{
						teALczgNmLhgwhNymmtYXowPgfYG = cBQhEyiNFbRkGCtCdGNTEMPiFbh.lYJFZOeYSDYSWqqagvNTnOjxepl(kAGhbYqdLHHcHxnWsqoxVNPpXVc, P_2);
						int num5;
						if (teALczgNmLhgwhNymmtYXowPgfYG == null)
						{
							num2 = 607970141;
							num5 = num2;
						}
						else
						{
							num2 = 607970138;
							num5 = num2;
						}
						continue;
					}
					goto case 2;
				case 6:
					break;
				case 1:
					if (!WFsHpGVScPZlQaWKivTImrGOHRY(P_1, num4))
					{
						num4 = (teALczgNmLhgwhNymmtYXowPgfYG.hkuClqGgyrjaNFrDJJuCSthMWeZ = IojKdiCykxLgoivdxmqNHsMNBtN(P_1));
						num2 = 607970139;
						continue;
					}
					goto case 4;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private void lMlcWXDhUZyoYToHgCauFZahHGiP()
	{
		string[] array = CBnhsalFktmtiXqaKtmByJSPkEd();
		while (true)
		{
			int num = 1799402738;
			while (true)
			{
				switch (num ^ 0x6B40B4F3)
				{
				case 2:
					break;
				case 1:
				{
					int num2;
					if (SeXECUiByzFeJnRsasbrYvFSefu(array))
					{
						num = 1799402739;
						num2 = num;
					}
					else
					{
						num = 1799402736;
						num2 = num;
					}
					continue;
				}
				case 0:
					pBKGiqCzbgfPGMFhRdFSwUDshjx(array);
					num = 1799402736;
					continue;
				default:
					oCfgXkGkSgDkbBQjCfrbIAyBZc = false;
					return;
				}
				break;
			}
		}
	}

	private bool SeXECUiByzFeJnRsasbrYvFSefu(string[] P_0)
	{
		int num = P_0.Length;
		int count = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
		int num6 = default(int);
		string text = default(string);
		int num9 = default(int);
		int num5 = default(int);
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = 43390371;
			while (true)
			{
				switch (num2 ^ 0x29615A4)
				{
				case 12:
					break;
				case 3:
				{
					int num8;
					if (!(P_0[num6] == text))
					{
						num2 = 43390374;
						num8 = num2;
					}
					else
					{
						num2 = 43390381;
						num8 = num2;
					}
					continue;
				}
				case 13:
				{
					int num7;
					if (num6 >= num)
					{
						num2 = 43390372;
						num7 = num2;
					}
					else
					{
						num2 = 43390375;
						num7 = num2;
					}
					continue;
				}
				case 2:
					num6++;
					num2 = 43390377;
					continue;
				case 9:
					num9++;
					num2 = 43390374;
					continue;
				case 10:
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num5] != null && jkFiqNnyAtbymFOLlvWZRfYeLku[num5].eGxTXNjqmCsabYsADiQdVSwZbLC == text)
					{
						num4++;
						num2 = 43390373;
						continue;
					}
					goto case 1;
				case 0:
					num4 = 0;
					num5 = 0;
					num2 = 43390383;
					continue;
				case 11:
					num2 = 43390370;
					continue;
				case 6:
					if (num5 >= count)
					{
						if (num9 != num4)
						{
							return true;
						}
						num3++;
						num2 = 43390368;
						continue;
					}
					goto case 10;
				case 8:
					if (P_0[num3] == null)
					{
						P_0[num3] = string.Empty;
						num2 = 43390369;
						continue;
					}
					goto case 5;
				case 1:
					num5++;
					num2 = 43390370;
					continue;
				case 7:
					if (num != count)
					{
						return true;
					}
					num3 = 0;
					num2 = 43390368;
					continue;
				case 5:
					text = P_0[num3];
					num9 = 0;
					num6 = 0;
					num2 = 43390377;
					continue;
				default:
					if (num3 >= num)
					{
						return false;
					}
					goto case 8;
				}
				break;
			}
		}
	}

	private void oQChKjbOquuMrWKdTwrmVgDaXkc(List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_0, List<KAGhbYqdLHHcHxnWsqoxVNPpXVc> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num4 = default(int);
		int num5 = default(int);
		int num3 = default(int);
		bool flag = default(bool);
		KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc2 = default(KAGhbYqdLHHcHxnWsqoxVNPpXVc);
		int num6 = default(int);
		while (true)
		{
			int num;
			if (P_0 == null)
			{
				num = -1253816969;
				goto IL_000c;
			}
			int num2 = P_0.Count;
			goto IL_00d4;
			IL_000c:
			while (true)
			{
				switch (num ^ -1253816965)
				{
				case 7:
					num = -1253816961;
					continue;
				default:
					return;
				case 8:
					num4 = ((P_1 != null) ? P_1.Count : 0);
					num5 = 0;
					num = -1253816962;
					continue;
				case 0:
					num3++;
					num = -1253816974;
					continue;
				case 10:
					if (!flag)
					{
						OfeHsDDvEoLmeubGkgNtdbFKDqss(P_0[num5], P_2);
						num = -1253816976;
						continue;
					}
					goto case 11;
				case 4:
					break;
				case 2:
					kAGhbYqdLHHcHxnWsqoxVNPpXVc2 = P_0[num5];
					if (kAGhbYqdLHHcHxnWsqoxVNPpXVc2 != null)
					{
						goto IL_00a4;
					}
					goto case 11;
				case 6:
					num3 = 0;
					num = -1253816974;
					continue;
				case 12:
					goto IL_00cb;
				case 11:
					num5++;
					num = -1253816962;
					continue;
				case 9:
					goto IL_00ed;
				case 5:
					goto IL_0106;
				case 3:
				{
					KAGhbYqdLHHcHxnWsqoxVNPpXVc kAGhbYqdLHHcHxnWsqoxVNPpXVc = P_1[num3];
					if (kAGhbYqdLHHcHxnWsqoxVNPpXVc != null && kAGhbYqdLHHcHxnWsqoxVNPpXVc2.rewiredId == kAGhbYqdLHHcHxnWsqoxVNPpXVc.rewiredId)
					{
						flag = true;
						num = -1253816975;
						continue;
					}
					goto case 0;
				}
				case 1:
					return;
				}
				break;
				IL_0106:
				int num7;
				if (num5 >= num6)
				{
					num = -1253816966;
					num7 = num;
				}
				else
				{
					num = -1253816967;
					num7 = num;
				}
				continue;
				IL_00ed:
				int num8;
				if (num3 < num4)
				{
					num = -1253816968;
					num8 = num;
				}
				else
				{
					num = -1253816975;
					num8 = num;
				}
				continue;
				IL_00a4:
				flag = false;
				int num9;
				if (P_1 == null)
				{
					num = -1253816975;
					num9 = num;
				}
				else
				{
					num = -1253816963;
					num9 = num;
				}
			}
			continue;
			IL_00cb:
			num2 = 0;
			goto IL_00d4;
			IL_00d4:
			num6 = num2;
			num = -1253816973;
			goto IL_000c;
		}
	}

	private void OfeHsDDvEoLmeubGkgNtdbFKDqss(KAGhbYqdLHHcHxnWsqoxVNPpXVc P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent == null)
			{
				return;
			}
			goto IL_000b;
		}
		goto IL_0046;
		IL_0046:
		int num;
		if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			num = -1850133216;
			goto IL_0010;
		}
		return;
		IL_000b:
		num = -1850133214;
		goto IL_0010;
		IL_0010:
		switch (num ^ -1850133216)
		{
		case 3:
			break;
		default:
			return;
		case 2:
			_DeviceConnectedEvent(P_0.ToBridgedController());
			return;
		case 1:
			goto IL_0046;
		case 0:
			return;
		}
		goto IL_000b;
	}

	private void xeYDWaFQsgWnujAWncOMeikceiV()
	{
		if (KyGQivhvNcexgOdgEkqkdUhAdys != yQgeUBihcLYUsNeHXLYEtcCaMLNn)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (GaCIgQSpFgupZQzfXHPjXkEDWee.Update())
			{
				num = -1403285889;
				num2 = num;
			}
			else
			{
				num = -1403285891;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ -1403285891)
				{
				case 3:
					num = -1403285892;
					continue;
				default:
					return;
				case 1:
					break;
				case 2:
					oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
					GaCIgQSpFgupZQzfXHPjXkEDWee.Start();
					num = -1403285891;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}
}
