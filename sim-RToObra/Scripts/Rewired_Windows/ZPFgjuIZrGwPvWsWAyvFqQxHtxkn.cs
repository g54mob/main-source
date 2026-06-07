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

internal class ZPFgjuIZrGwPvWsWAyvFqQxHtxkn : PlatformInputManager, kxzXTdiJorHKVUHhoBvSNMIscik
{
	private class CQqdgMSBwubrhVugChMjQReeGmRd : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int LHBzfOUukEAojNhzqhOUdcqBelx;

		private int QSgOYisLlLVufpwxLNKaoIEBiyFd;

		public Guid FHAzoTozCrisunLDoLyimqNbdex;

		public string DHGYnLayswGyOaWIxJecDoLngmm;

		private readonly IQFNbAfLsEWvVnPpdRQbxxyYJpW PSZKcVVfVmWuwyrmRaPnqSTTRBB;

		private readonly DeviceType PMEjyOyDoHeJObaqgZAFOKNMJAOj;

		public string aQyubnFZjhaxoHtWxfehAEYaFOR;

		public string SgtdGZiZKfxrYfEaONXeCdMIqIsz;

		public string ZYtBoPNuCmSlSLPglVVYiiIepKT;

		public int rFChCpBSHUoiIZbKWfsTCHUdRna;

		public int PbwglKnIRKBGqGPSCbbymWhNwoO;

		public Guid mtlDBDFXTzxHqeXjvCJbhGtTMUCC;

		public Guid eTlTTlBmuxCORrngMaNsxFSpDyMi;

		public Guid AIefUprvkNeEvLSsrampirFfHMzU;

		public int iERVPkhRheIKptTuTmWgWiTZGxm;

		public int gwfrHmNqxmYlnzynBGWAgujDDrf;

		public int rqeFUUCoNDfDgMOxuCDGnyLQlXi;

		public int dhEQLHuCYYGQwdehmJKXAJgttVWs;

		public int aCdTArmyUaJIYSBpkbuJpDufgNGc;

		public int JwvOuylcUYNAjPLMAAlyukWmToj;

		public bool IEIpySejupFvUUEVIERJEkDtdcvv;

		public bool HUFFKhqkxcIVKhtrxspNbGBrTdG;

		public bool uyjBbcIhGzMpDSyGYNhGPPRoYdp;

		public int tojPLGfGkimbIivokBFIzlnJQIx;

		private float[] HwRqYBlbrIoKtVDOMNmmVOGCrNt;

		private float[] xrmDwADRXdFsenTurfwlUsqsAvb;

		private bool[] sTmhwWLXxOaMsilVHjWGwCeGIBV;

		private HardwareJoystickMap_InputManager XCAyIFRJbEWUeBcnVweevmqWqtw;

		private tDbEfRBvKQKUUajRFFcUkaQZPWTt LLXxHTKTMzsnYyWPNUyGYIBrbuz;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

		private bool cbEqXqyoXBYbIYeDgNacVLXtacu;

		private bool RZErYKzcoEvfMnhtHeFDeTWjAxp;

		private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

		[CompilerGenerated]
		private Controller.Extension MLkmGgyFZEHmvENFeschXmLJlec;

		public bool hasDriver
		{
			get
			{
				if (PSZKcVVfVmWuwyrmRaPnqSTTRBB == null)
				{
					return false;
				}
				return PSZKcVVfVmWuwyrmRaPnqSTTRBB.Driver != null;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return LHBzfOUukEAojNhzqhOUdcqBelx;
			}
			set
			{
				LHBzfOUukEAojNhzqhOUdcqBelx = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return QSgOYisLlLVufpwxLNKaoIEBiyFd;
			}
			set
			{
				QSgOYisLlLVufpwxLNKaoIEBiyFd = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (DHGYnLayswGyOaWIxJecDoLngmm != "Unknown Controller")
				{
					return DHGYnLayswGyOaWIxJecDoLngmm;
				}
				if (HUFFKhqkxcIVKhtrxspNbGBrTdG && !string.IsNullOrEmpty(ZYtBoPNuCmSlSLPglVVYiiIepKT))
				{
					return ZYtBoPNuCmSlSLPglVVYiiIepKT;
				}
				return SgtdGZiZKfxrYfEaONXeCdMIqIsz;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (QSgOYisLlLVufpwxLNKaoIEBiyFd < 0)
				{
					return null;
				}
				return QSgOYisLlLVufpwxLNKaoIEBiyFd;
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
				return MLkmGgyFZEHmvENFeschXmLJlec;
			}
			[CompilerGenerated]
			set
			{
				MLkmGgyFZEHmvENFeschXmLJlec = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return mtlDBDFXTzxHqeXjvCJbhGtTMUCC;
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
				if (!nYnvJCdSwCjafdvZoFKnjAkIRCs && PSZKcVVfVmWuwyrmRaPnqSTTRBB != null)
				{
					return PSZKcVVfVmWuwyrmRaPnqSTTRBB.IsValid;
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

		public CQqdgMSBwubrhVugChMjQReeGmRd(IQFNbAfLsEWvVnPpdRQbxxyYJpW joystick, DeviceType riDeviceType, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			PSZKcVVfVmWuwyrmRaPnqSTTRBB = joystick;
			PMEjyOyDoHeJObaqgZAFOKNMJAOj = riDeviceType;
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			QSgOYisLlLVufpwxLNKaoIEBiyFd = -1;
			LHBzfOUukEAojNhzqhOUdcqBelx = -1;
		}

		public void qdrCNHHBSjMYElMPgHUagWNZcjH()
		{
			if (!IsValid)
			{
				return;
			}
			int num4 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			int num2 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = default(HardwareJoystickMap.Platform_RawInput_Base);
			InputPlatform platform = default(InputPlatform);
			while (true)
			{
				AIefUprvkNeEvLSsrampirFfHMzU = MiscTools.CreateGuidHashSHA1(((!string.IsNullOrEmpty(ZYtBoPNuCmSlSLPglVVYiiIepKT)) ? ZYtBoPNuCmSlSLPglVVYiiIepKT : SgtdGZiZKfxrYfEaONXeCdMIqIsz) + eTlTTlBmuxCORrngMaNsxFSpDyMi);
				gwfrHmNqxmYlnzynBGWAgujDDrf = dhEQLHuCYYGQwdehmJKXAJgttVWs;
				rqeFUUCoNDfDgMOxuCDGnyLQlXi = aCdTArmyUaJIYSBpkbuJpDufgNGc + JwvOuylcUYNAjPLMAAlyukWmToj * 8;
				XCEcogOtFbmhupWduawPDMqkEjv();
				FHAzoTozCrisunLDoLyimqNbdex = XCAyIFRJbEWUeBcnVweevmqWqtw.hardwareMapIdentifier.guid;
				int num = 1134445049;
				while (true)
				{
					switch (num ^ 0x439E41FA)
					{
					case 8:
						num = 1134445051;
						continue;
					default:
						return;
					case 18:
					{
						int num5;
						if (num4 < buttons_orig2.Length)
						{
							num = 1134445054;
							num5 = num;
						}
						else
						{
							num = 1134445045;
							num5 = num;
						}
						continue;
					}
					case 19:
						num2++;
						num = 1134445035;
						continue;
					case 11:
						sTmhwWLXxOaMsilVHjWGwCeGIBV[num2] = buttons_orig[num2].buttonInfo.isPressureSensitive;
						num = 1134445033;
						continue;
					case 9:
						if (buttons_orig2 != null)
						{
							num4 = 0;
							num = 1134445052;
							continue;
						}
						goto case 7;
					case 7:
						LLXxHTKTMzsnYyWPNUyGYIBrbuz = PSZKcVVfVmWuwyrmRaPnqSTTRBB.AxesState;
						Update();
						num = 1134445048;
						continue;
					case 6:
						num = 1134445032;
						continue;
					case 17:
					{
						int num3;
						if (num2 < buttons_orig.Length)
						{
							num = 1134445041;
							num3 = num;
						}
						else
						{
							num = 1134445053;
							num3 = num;
						}
						continue;
					}
					case 13:
						if (XCAyIFRJbEWUeBcnVweevmqWqtw != null)
						{
							int num7;
							if (rqeFUUCoNDfDgMOxuCDGnyLQlXi <= 0)
							{
								num = 1134445053;
								num7 = num;
							}
							else
							{
								num = 1134445055;
								num7 = num;
							}
							continue;
						}
						goto case 7;
					case 15:
						num = 1134445053;
						continue;
					case 10:
					{
						HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						buttons_orig = platform_DirectInput_Base.Buttons_orig;
						num = 1134445034;
						continue;
					}
					case 14:
						buttons_orig2 = platform_RawInput_Base.Buttons_orig;
						num = 1134445043;
						continue;
					case 0:
						sTmhwWLXxOaMsilVHjWGwCeGIBV = new bool[rqeFUUCoNDfDgMOxuCDGnyLQlXi];
						num = 1134445047;
						continue;
					case 12:
					{
						int num6;
						if (platform == InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw)
						{
							num = 1134445040;
							num6 = num;
						}
						else
						{
							num = 1134445053;
							num6 = num;
						}
						continue;
					}
					case 16:
						if (buttons_orig != null)
						{
							num2 = 0;
							num = 1134445035;
							continue;
						}
						goto case 7;
					case 4:
						sTmhwWLXxOaMsilVHjWGwCeGIBV[num4] = buttons_orig2[num4].buttonInfo.isPressureSensitive;
						num4++;
						num = 1134445032;
						continue;
					case 5:
						platform = XCAyIFRJbEWUeBcnVweevmqWqtw.map.platform;
						if (platform == InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg)
						{
							platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
							num = 1134445044;
							continue;
						}
						goto case 12;
					case 1:
						break;
					case 3:
						DHGYnLayswGyOaWIxJecDoLngmm = XCAyIFRJbEWUeBcnVweevmqWqtw.controllerName;
						cbEqXqyoXBYbIYeDgNacVLXtacu = ((FHAzoTozCrisunLDoLyimqNbdex == Guid.Empty) ? true : false);
						HwRqYBlbrIoKtVDOMNmmVOGCrNt = new float[gwfrHmNqxmYlnzynBGWAgujDDrf];
						xrmDwADRXdFsenTurfwlUsqsAvb = new float[rqeFUUCoNDfDgMOxuCDGnyLQlXi];
						num = 1134445050;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public void sHFWIJnFHmHJYIoFEDYPzPHrHZM(CQqdgMSBwubrhVugChMjQReeGmRd P_0)
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
					IL_009c:
					QSgOYisLlLVufpwxLNKaoIEBiyFd = P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd;
					LHBzfOUukEAojNhzqhOUdcqBelx = P_0.LHBzfOUukEAojNhzqhOUdcqBelx;
					int num = 0;
					int num2 = -540384528;
					while (true)
					{
						switch (num2 ^ -540384520)
						{
						case 6:
							num2 = -540384526;
							continue;
						case 10:
							break;
						case 4:
							goto IL_0055;
						case 2:
							sTmhwWLXxOaMsilVHjWGwCeGIBV[num4] = P_0.sTmhwWLXxOaMsilVHjWGwCeGIBV[num4];
							num4++;
							num2 = -540384516;
							continue;
						case 9:
							goto IL_009c;
						case 5:
							num++;
							num2 = -540384528;
							continue;
						case 8:
							if (num >= MathTools.Min(xrmDwADRXdFsenTurfwlUsqsAvb.Length, P_0.xrmDwADRXdFsenTurfwlUsqsAvb.Length))
							{
								num4 = 0;
								num2 = -540384516;
								continue;
							}
							goto case 7;
						case 0:
							HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3] = P_0.HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3];
							num3++;
							num2 = -540384519;
							continue;
						case 3:
							num3 = 0;
							num2 = -540384519;
							continue;
						case 7:
							xrmDwADRXdFsenTurfwlUsqsAvb[num] = P_0.xrmDwADRXdFsenTurfwlUsqsAvb[num];
							num2 = -540384515;
							continue;
						default:
							if (num3 >= MathTools.Min(HwRqYBlbrIoKtVDOMNmmVOGCrNt.Length, P_0.HwRqYBlbrIoKtVDOMNmmVOGCrNt.Length))
							{
								RZErYKzcoEvfMnhtHeFDeTWjAxp = P_0.RZErYKzcoEvfMnhtHeFDeTWjAxp;
								return;
							}
							goto case 0;
						}
						break;
						IL_0055:
						int num5;
						if (num4 >= MathTools.Min(sTmhwWLXxOaMsilVHjWGwCeGIBV.Length, P_0.sTmhwWLXxOaMsilVHjWGwCeGIBV.Length))
						{
							num2 = -540384517;
							num5 = num2;
						}
						else
						{
							num2 = -540384518;
							num5 = num2;
						}
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
				bool[] buttons = PSZKcVVfVmWuwyrmRaPnqSTTRBB.Buttons;
				int[] hatValues = PSZKcVVfVmWuwyrmRaPnqSTTRBB.HatValues;
				IsHEPGDcapJjIIIwabNlagrgYHK(buttons, hatValues);
				int num = 1758613391;
				while (true)
				{
					switch (num ^ 0x68D24F8D)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						xEfKEFgwOpPyjRLoWJIEfoNdBYF(buttons, hatValues);
						return;
					}
					break;
					IL_0009:
					num = 1758613388;
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
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				IL_0118:
				if (gwfrHmNqxmYlnzynBGWAgujDDrf == dataUpdater.axisCount)
				{
					int num;
					int num2;
					if (rqeFUUCoNDfDgMOxuCDGnyLQlXi != dataUpdater.buttonCount)
					{
						num = 1020975371;
						num2 = num;
					}
					else
					{
						num = 1020975365;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x3CDAD90B)
						{
						case 5:
							num = 1020975361;
							continue;
						default:
							return;
						case 1:
							break;
						case 9:
							dataUpdater.buttonValues[num4] = ((xrmDwADRXdFsenTurfwlUsqsAvb[num4] > 0f) ? true : false);
							num = 1020975368;
							continue;
						case 6:
							dataUpdater.axisValues[num3] = HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3];
							num3++;
							num = 1020975366;
							continue;
						case 0:
							goto end_IL_0011;
						case 12:
							num = 1020975366;
							continue;
						case 3:
							num4++;
							num = 1020975369;
							continue;
						case 7:
							num = 1020975368;
							continue;
						case 4:
							dataUpdater.buttonPressureValues[num4] = xrmDwADRXdFsenTurfwlUsqsAvb[num4];
							num = 1020975372;
							continue;
						case 11:
							num4 = 0;
							num = 1020975369;
							continue;
						case 10:
							goto IL_0118;
						case 13:
							goto IL_0148;
						case 2:
							if (num4 >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
							{
								if (RZErYKzcoEvfMnhtHeFDeTWjAxp && !dataUpdater.hasReceivedInput)
								{
									dataUpdater.hasReceivedInput = true;
									num = 1020975363;
									continue;
								}
								return;
							}
							break;
						case 14:
							num3 = 0;
							num = 1020975367;
							continue;
						case 8:
							return;
						}
						int num5;
						if (sTmhwWLXxOaMsilVHjWGwCeGIBV[num4])
						{
							num = 1020975375;
							num5 = num;
						}
						else
						{
							num = 1020975362;
							num5 = num;
						}
						continue;
						IL_0148:
						int num6;
						if (num3 < gwfrHmNqxmYlnzynBGWAgujDDrf)
						{
							num = 1020975373;
							num6 = num;
						}
						else
						{
							num = 1020975360;
							num6 = num;
						}
						continue;
						end_IL_0011:
						break;
					}
				}
				throw new Exception("This controller signature does not match the data object!");
			}
		}

		public int QJuTPVbZPhckxeVMgmaDORJltri(CQqdgMSBwubrhVugChMjQReeGmRd P_0)
		{
			if (!IsValid)
			{
				return 0;
			}
			if (P_0.LHBzfOUukEAojNhzqhOUdcqBelx == LHBzfOUukEAojNhzqhOUdcqBelx)
			{
				goto IL_0018;
			}
			if (dhEQLHuCYYGQwdehmJKXAJgttVWs != P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs)
			{
				return 0;
			}
			if (aCdTArmyUaJIYSBpkbuJpDufgNGc != P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc)
			{
				return 0;
			}
			if (JwvOuylcUYNAjPLMAAlyukWmToj != P_0.JwvOuylcUYNAjPLMAAlyukWmToj)
			{
				return 0;
			}
			int num;
			if (hasDriver != P_0.hasDriver)
			{
				num = 1266283345;
				goto IL_001d;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.AIefUprvkNeEvLSsrampirFfHMzU == AIefUprvkNeEvLSsrampirFfHMzU)
			{
				return 1;
			}
			return 0;
			IL_001d:
			switch (num ^ 0x4B79F350)
			{
			case 0:
				break;
			case 2:
				return 2;
			default:
				return 0;
			}
			goto IL_0018;
			IL_0018:
			num = 1266283346;
			goto IL_001d;
		}

		private BridgedControllerHWInfo PJFgAzlnjXDIFtIVMtyxcOgBHLL()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			qLdgPikrSeiPWSEbkkdRitWDfeYu(bridgedControllerHWInfo);
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
			qLdgPikrSeiPWSEbkkdRitWDfeYu(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(LHBzfOUukEAojNhzqhOUdcqBelx);
		}

		private void IsHEPGDcapJjIIIwabNlagrgYHK(bool[] P_0, int[] P_1)
		{
			if (gwfrHmNqxmYlnzynBGWAgujDDrf <= 0)
			{
				goto IL_000c;
			}
			goto IL_0107;
			IL_000c:
			int num = 664826769;
			goto IL_0011;
			IL_0011:
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			int num2 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig3 = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			InputPlatform platform = default(InputPlatform);
			HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_InternalDriver_Base.Axis[]);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x27A0739A)
				{
				case 19:
					break;
				default:
					return;
				case 16:
					if (axes_orig == null)
					{
						return;
					}
					goto case 4;
				case 8:
					if (num2 >= axes_orig3.Length)
					{
						return;
					}
					goto case 5;
				case 10:
					if (platform == InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw)
					{
						HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						axes_orig3 = platform_DirectInput_Base.Axes_orig;
						num = 664826779;
						continue;
					}
					goto IL_01e9;
				case 17:
					XVsHhTTMurwFevgMeVpBaAgdBnH(axes_orig2[num4], num4, P_0, P_1);
					num4++;
					num = 664826773;
					continue;
				case 14:
					return;
				case 1:
					goto IL_00ef;
				case 18:
					goto IL_0107;
				case 6:
					BnNUDmgtuAMaGYlEmQtjNSKwmsB(axes_orig[num3], num3, P_0, P_1);
					num3++;
					num = 664826771;
					continue;
				case 5:
					BnNUDmgtuAMaGYlEmQtjNSKwmsB(axes_orig3[num2], num2, P_0, P_1);
					num = 664826778;
					continue;
				case 20:
					num4 = 0;
					num = 664826773;
					continue;
				case 0:
					num2++;
					num = 664826770;
					continue;
				case 13:
				{
					HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
					axes_orig = platform_RawInput_Base.Axes_orig;
					num = 664826762;
					continue;
				}
				case 11:
					return;
				case 9:
					if (num3 >= axes_orig.Length)
					{
						return;
					}
					goto case 6;
				case 15:
					goto IL_01c1;
				case 4:
					num3 = 0;
					num = 664826771;
					continue;
				case 3:
					goto IL_01e9;
				case 12:
					return;
				case 2:
					num2 = 0;
					num = 664826770;
					continue;
				case 7:
					return;
				}
				break;
				IL_01c1:
				int num5;
				if (num4 >= axes_orig2.Length)
				{
					num = 664826781;
					num5 = num;
				}
				else
				{
					num = 664826763;
					num5 = num;
				}
				continue;
				IL_01e9:
				if (platform == InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG)
				{
					HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
					axes_orig2 = platform_InternalDriver_Base.Axes_orig;
					int num6;
					if (axes_orig2 != null)
					{
						num = 664826766;
						num6 = num;
					}
					else
					{
						num = 664826772;
						num6 = num;
					}
					continue;
				}
				return;
				IL_00ef:
				int num7;
				if (axes_orig3 != null)
				{
					num = 664826776;
					num7 = num;
				}
				else
				{
					num = 664826774;
					num7 = num;
				}
			}
			goto IL_000c;
			IL_0107:
			platform = XCAyIFRJbEWUeBcnVweevmqWqtw.map.platform;
			int num8;
			if (platform == InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg)
			{
				num = 664826775;
				num8 = num;
			}
			else
			{
				num = 664826768;
				num8 = num;
			}
			goto IL_0011;
		}

		private void xEfKEFgwOpPyjRLoWJIEfoNdBYF(bool[] P_0, int[] P_1)
		{
			if (rqeFUUCoNDfDgMOxuCDGnyLQlXi <= 0)
			{
				return;
			}
			int num4 = default(int);
			HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_InternalDriver_Base.Button[]);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			int num5 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = default(HardwareJoystickMap.Platform_DirectInput_Base);
			int num2 = default(int);
			while (true)
			{
				InputPlatform platform = XCAyIFRJbEWUeBcnVweevmqWqtw.map.platform;
				int num = -1311176774;
				while (true)
				{
					switch (num ^ -1311176791)
					{
					case 0:
						num = -1311176769;
						continue;
					default:
						return;
					case 6:
						num4 = 0;
						num = -1311176771;
						continue;
					case 13:
						return;
					case 12:
						num = -1311176776;
						continue;
					case 2:
						if (platform == InputPlatform.DUbQuJCDfrUzNLyHOFGFbNvqDqG)
						{
							HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
							buttons_orig = platform_InternalDriver_Base.Buttons_orig;
							int num8;
							if (buttons_orig != null)
							{
								num = -1311176793;
								num8 = num;
							}
							else
							{
								num = -1311176796;
								num8 = num;
							}
							continue;
						}
						return;
					case 9:
						num = -1311176773;
						continue;
					case 20:
						if (num4 >= buttons_orig2.Length)
						{
							return;
						}
						goto case 4;
					case 17:
					{
						int num9;
						if (num5 < buttons_orig3.Length)
						{
							num = -1311176792;
							num9 = num;
						}
						else
						{
							num = -1311176786;
							num9 = num;
						}
						continue;
					}
					case 11:
						buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
						if (buttons_orig2 == null)
						{
							return;
						}
						goto case 6;
					case 19:
					{
						int num7;
						if (platform != InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg)
						{
							num = -1311176775;
							num7 = num;
						}
						else
						{
							num = -1311176794;
							num7 = num;
						}
						continue;
					}
					case 5:
						return;
					case 15:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						buttons_orig3 = platform_RawInput_Base.Buttons_orig;
						int num6;
						if (buttons_orig3 == null)
						{
							num = -1311176788;
							num6 = num;
						}
						else
						{
							num = -1311176799;
							num6 = num;
						}
						continue;
					}
					case 21:
						num4++;
						num = -1311176771;
						continue;
					case 1:
						JQUOJFbbxdoZvdDiXaJFJTBTwATd(buttons_orig3[num5], num5, P_0, P_1);
						num5++;
						num = -1311176776;
						continue;
					case 16:
						if (platform == InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw)
						{
							platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
							num = -1311176798;
							continue;
						}
						goto case 2;
					case 14:
						num2 = 0;
						num = -1311176800;
						continue;
					case 22:
						break;
					case 8:
						num5 = 0;
						num = -1311176795;
						continue;
					case 18:
					{
						int num3;
						if (num2 < buttons_orig.Length)
						{
							num = -1311176790;
							num3 = num;
						}
						else
						{
							num = -1311176797;
							num3 = num;
						}
						continue;
					}
					case 4:
						JQUOJFbbxdoZvdDiXaJFJTBTwATd(buttons_orig2[num4], num4, P_0, P_1);
						num = -1311176772;
						continue;
					case 7:
						return;
					case 3:
						ksKCYjFmSnAxYNZmTQlAbOeeMin(buttons_orig[num2], num2, P_0, P_1);
						num2++;
						num = -1311176773;
						continue;
					case 10:
						return;
					}
					break;
				}
			}
		}

		private void BnNUDmgtuAMaGYlEmQtjNSKwmsB(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= gwfrHmNqxmYlnzynBGWAgujDDrf)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			while (true)
			{
				HwRqYBlbrIoKtVDOMNmmVOGCrNt[P_1] = QkOJeQjNoGuvJJcCjzkxhFnepjH(P_0, P_2, P_3);
				if (RZErYKzcoEvfMnhtHeFDeTWjAxp || HwRqYBlbrIoKtVDOMNmmVOGCrNt[P_1] == 0f)
				{
					break;
				}
				RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
				int num = 1472423670;
				while (true)
				{
					switch (num ^ 0x57C366F6)
					{
					case 2:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0014:
					num = 1472423671;
				}
			}
		}

		private void JQUOJFbbxdoZvdDiXaJFJTBTwATd(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				xrmDwADRXdFsenTurfwlUsqsAvb[P_1] = eRRRbnNJkvBkNLMFRFRiaMhIthSB(P_0, P_2, P_3);
				if (RZErYKzcoEvfMnhtHeFDeTWjAxp || xrmDwADRXdFsenTurfwlUsqsAvb[P_1] == 0f)
				{
					break;
				}
				RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
				int num = 1211404949;
				while (true)
				{
					switch (num ^ 0x48349295)
					{
					case 2:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0014:
					num = 1211404948;
				}
			}
		}

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			int sourceAxis = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				goto IL_0013;
			}
			int num;
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						return 0f;
					}
					num = -1133759487;
				}
				else
				{
					num = -1133759476;
				}
			}
			else
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					goto IL_025d;
				}
				if (sourceButton < 256)
				{
					if (!P_1[sourceButton])
					{
						return 0f;
					}
					int num2;
					if (P_0.buttonAxisContribution != Pole.Positive)
					{
						num = -1133759471;
						num2 = num;
					}
					else
					{
						num = -1133759465;
						num2 = num;
					}
				}
				else
				{
					num = -1133759473;
				}
			}
			goto IL_0018;
			IL_0013:
			num = -1133759474;
			goto IL_0018;
			IL_03dd:
			CustomCalculation customCalculation = default(CustomCalculation);
			if (!customCalculation.Process())
			{
				return 0f;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			return customCalculation.Result;
			IL_0018:
			int num3 = default(int);
			int sourceHat = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Axis axis = default(HardwareJoystickMap.Platform_RawInput_Base.Axis);
			int num4 = default(int);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			float result = default(float);
			float num6 = default(float);
			while (true)
			{
				switch (num ^ -1133759486)
				{
				case 16:
					break;
				case 15:
					num3++;
					num = -1133759472;
					continue;
				case 10:
					return 0f;
				case 23:
					goto IL_00d1;
				case 20:
					return 0f;
				case 24:
					goto IL_010c;
				case 5:
					if (sourceHat < JwvOuylcUYNAjPLMAAlyukWmToj)
					{
						goto IL_0133;
					}
					goto case 2;
				case 4:
					if (axis == null)
					{
						return 0f;
					}
					num4 = axis.sourceOtherAxis;
					goto case 22;
				case 25:
				{
					HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType;
					HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
					float item;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && GcXMSpyoZSbgVbAoeISEDqCbryIv(customCalculationSourceData[num3], out item))
					{
						customCalculation.AddData(item);
						num = -1133759475;
						continue;
					}
					goto case 15;
				}
				case 0:
					return 0f;
				case 8:
					return result;
				case 3:
					customCalculation = P_0.customCalculation;
					num = -1133759479;
					continue;
				case 7:
					return 0f;
				case 2:
					return 0f;
				case 13:
					goto IL_025d;
				case 17:
					goto IL_028f;
				case 11:
					goto IL_02b1;
				case 19:
					result = -1f;
					num = -1133759478;
					continue;
				case 9:
					goto IL_02ea;
				case 12:
					goto IL_0311;
				case 21:
					result = 1f;
					num = -1133759478;
					continue;
				case 1:
					goto IL_0346;
				case 22:
					return QkOJeQjNoGuvJJcCjzkxhFnepjH((RawInputAxis)sourceAxis, num4);
				case 14:
					goto IL_0395;
				case 6:
					return 0f;
				default:
					goto IL_03d2;
				}
				break;
				IL_03d2:
				if (num3 < customCalculationSourceData.Length)
				{
					goto IL_02ea;
				}
				goto IL_03dd;
				IL_0395:
				sourceHat = P_0.sourceHat;
				int num5;
				if (sourceHat >= 0)
				{
					num = -1133759481;
					num5 = num;
				}
				else
				{
					num = -1133759488;
					num5 = num;
				}
				continue;
				IL_00b5:
				if (P_0.invert)
				{
					num6 *= -1f;
					num = -1133759462;
					continue;
				}
				goto IL_010c;
				IL_00d1:
				if (sourceAxis == 1000)
				{
					axis = P_0 as HardwareJoystickMap.Platform_RawInput_Base.Axis;
					num = -1133759482;
					continue;
				}
				goto IL_0346;
				IL_0311:
				switch (sourceAxis)
				{
				case 0:
					return 0f;
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
					num = -1133759468;
					continue;
				}
				goto IL_00d1;
				IL_02ea:
				int num7;
				if (customCalculationSourceData[num3] != null)
				{
					num = -1133759461;
					num7 = num;
				}
				else
				{
					num = -1133759475;
					num7 = num;
				}
				continue;
				IL_028f:
				if (P_0.sourceHatRange != AxisRange.Positive)
				{
					if (num6 > 0f)
					{
						return 0f;
					}
				}
				else if (num6 < 0f)
				{
					num = -1133759480;
					continue;
				}
				goto IL_00b5;
				IL_010c:
				return num6;
				IL_02b1:
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType == TypeWrapper.DataType.Single)
				{
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						num = -1133759486;
						continue;
					}
					num3 = 0;
					num = -1133759472;
				}
				else
				{
					num = -1133759466;
				}
				continue;
				IL_0346:
				return 0f;
				IL_0133:
				if (sourceHat >= 4)
				{
					num = -1133759488;
					continue;
				}
				int num8 = P_2[sourceHat];
				if (num8 < 0)
				{
					return 0f;
				}
				if (P_0.sourceHatDirection != AxisDirection.Horizontal)
				{
					num6 = lsSCStiAfbFyneyGtxVQJHRkdst(num8, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						num = -1133759469;
						continue;
					}
				}
				else
				{
					num6 = lsSCStiAfbFyneyGtxVQJHRkdst(num8, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num6 < 0f)
							{
								num = -1133759484;
								continue;
							}
						}
						else if (num6 > 0f)
						{
							num = -1133759483;
							continue;
						}
					}
				}
				goto IL_00b5;
			}
			goto IL_0013;
			IL_025d:
			return 0f;
		}

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(RawInputAxis P_0, int P_1)
		{
			return dmOmXokuwYPeqkLCCIorsBnvJVN((LLXxHTKTMzsnYyWPNUyGYIBrbuz as aXvsRAkEsCpkQyhsfGemHvAYTiJM).QkOJeQjNoGuvJJcCjzkxhFnepjH(P_0, P_1));
		}

		private float eRRRbnNJkvBkNLMFRFRiaMhIthSB(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					num = 0;
					goto IL_0018;
				}
				goto IL_0295;
			}
			int sourceAxis = default(int);
			int num2;
			int sourceHat = default(int);
			HatDirection sourceHatDirection = default(HatDirection);
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int num3 = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				sourceAxis = P_0.sourceAxis;
				num2 = 1463274806;
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= JwvOuylcUYNAjPLMAAlyukWmToj)
				{
					goto IL_0390;
				}
				if (sourceHat >= 4)
				{
					num2 = 1463274803;
				}
				else
				{
					sourceHatDirection = P_0.sourceHatDirection;
					num2 = 1463274792;
				}
			}
			else
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_0510;
				}
				customCalculation = P_0.customCalculation;
				if (!(customCalculation == null))
				{
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
					num2 = 1463274784;
				}
				else
				{
					num2 = 1463274793;
				}
			}
			goto IL_001d;
			IL_0018:
			num2 = 1463274815;
			goto IL_001d;
			IL_001d:
			int sourceButton = default(int);
			int num4 = default(int);
			int num8 = default(int);
			bool flag2 = default(bool);
			while (true)
			{
				float num5;
				switch (num2 ^ 0x5737CD31)
				{
				case 23:
					break;
				case 17:
					num2 = 1463274785;
					continue;
				case 3:
					goto IL_009c;
				case 19:
					goto IL_00a2;
				case 11:
					return 0f;
				case 1:
				{
					bool flag;
					if (dIGEjeJuOmivVcCLDIiTEFopnzx(customCalculationSourceData[num3], P_1, out flag))
					{
						customCalculation.AddData(flag ? 1f : 0f);
						num2 = 1463274809;
						continue;
					}
					goto case 8;
				}
				case 7:
					goto IL_014e;
				case 8:
					num3++;
					num2 = 1463274785;
					continue;
				case 12:
					goto IL_0187;
				case 18:
					goto IL_01bd;
				case 5:
					if (customCalculationSourceData[num3] != null)
					{
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
							break;
						case HardwareElementSourceTypeWithHat.Axis:
							goto IL_01bd;
						default:
							goto IL_021b;
						}
						goto case 1;
					}
					goto case 8;
				case 24:
					return 0f;
				case 9:
					return 0f;
				case 15:
					if (sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
					{
						goto case 11;
					}
					goto IL_0280;
				case 10:
					goto IL_0295;
				case 20:
					return 0f;
				case 0:
					goto IL_02f2;
				case 13:
					goto IL_0314;
				case 25:
					goto IL_034d;
				case 6:
					num4 = 0;
					num2 = 1463274786;
					continue;
				case 2:
					goto IL_0390;
				case 21:
					goto IL_03a8;
				case 14:
					num2 = 1463274788;
					continue;
				case 4:
					goto IL_03d1;
				case 22:
					goto IL_049c;
				default:
					{
						if (num3 < customCalculationSourceData.Length)
						{
							goto case 5;
						}
						goto IL_04c7;
					}
					IL_021b:
					num2 = 1463274809;
					continue;
					IL_01bd:
					if (GcXMSpyoZSbgVbAoeISEDqCbryIv(customCalculationSourceData[num3], out num5))
					{
						customCalculation.AddData((num5 != 0f) ? 1f : 0f);
						num2 = 1463274809;
						continue;
					}
					goto case 8;
				}
				break;
				IL_049c:
				if (P_1[P_0.ignoreIfButtonsActiveButtons[num]])
				{
					return 0f;
				}
				num++;
				num2 = 1463274788;
				continue;
				IL_0280:
				if (sourceButton >= 256)
				{
					num2 = 1463274810;
					continue;
				}
				goto IL_00ee;
				IL_0187:
				if (sourceAxis != 1000)
				{
					goto IL_009c;
				}
				HardwareJoystickMap.Platform_RawInput_Base.Button button = P_0 as HardwareJoystickMap.Platform_RawInput_Base.Button;
				if (button == null)
				{
					return 0f;
				}
				num4 = button.sourceOtherAxis;
				goto IL_00a2;
				IL_03a8:
				int num6;
				if (num >= P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num2 = 1463274811;
					num6 = num2;
				}
				else
				{
					num2 = 1463274791;
					num6 = num2;
				}
				continue;
				IL_014e:
				if (sourceAxis == 0)
				{
					return 0f;
				}
				if (sourceAxis >= 1)
				{
					int num7;
					if (sourceAxis > 11)
					{
						num2 = 1463274813;
						num7 = num2;
					}
					else
					{
						num2 = 1463274807;
						num7 = num2;
					}
					continue;
				}
				goto IL_0187;
				IL_009c:
				return 0f;
				IL_0314:
				if (num8 < P_0.requiredButtons.Length)
				{
					goto IL_02f2;
				}
				goto IL_031f;
				IL_02f2:
				if (!P_1[P_0.requiredButtons[num8]])
				{
					return 0f;
				}
				flag2 = true;
				num8++;
				num2 = 1463274812;
				continue;
				IL_00a2:
				float num9 = QkOJeQjNoGuvJJcCjzkxhFnepjH((RawInputAxis)sourceAxis, num4);
				float num10 = MathTools.Abs(num9);
				if (num10 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num9 < 0f)
					{
						num2 = 1463274808;
						continue;
					}
				}
				else if (num9 > 0f)
				{
					num2 = 1463274789;
					continue;
				}
				return num10;
			}
			goto IL_0018;
			IL_0390:
			return 0f;
			IL_034d:
			switch (sourceHatDirection)
			{
			case HatDirection.Up:
				break;
			case HatDirection.UpRight:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 1, P_0.sourceHatType);
			case HatDirection.Right:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 2, P_0.sourceHatType);
			case HatDirection.DownRight:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 3, P_0.sourceHatType);
			case HatDirection.Down:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 4, P_0.sourceHatType);
			case HatDirection.DownLeft:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 5, P_0.sourceHatType);
			case HatDirection.Left:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 6, P_0.sourceHatType);
			case HatDirection.UpLeft:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 7, P_0.sourceHatType);
			default:
				goto IL_0510;
			}
			goto IL_03d1;
			IL_0295:
			if (P_0.requireMultipleButtons)
			{
				flag2 = false;
				num8 = 0;
				num2 = 1463274812;
			}
			else
			{
				sourceButton = P_0.sourceButton;
				int num11;
				if (sourceButton >= 0)
				{
					num2 = 1463274814;
					num11 = num2;
				}
				else
				{
					num2 = 1463274810;
					num11 = num2;
				}
			}
			goto IL_001d;
			IL_00ee:
			if (!P_1[sourceButton])
			{
				return 0f;
			}
			return 1f;
			IL_0510:
			return 0f;
			IL_04c7:
			if (!customCalculation.Process())
			{
				return 0f;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			if ((float)customCalculation.Result == 0f)
			{
				return 0f;
			}
			return 1f;
			IL_03d1:
			return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 0, P_0.sourceHatType);
			IL_031f:
			if (flag2)
			{
				return 1f;
			}
			return 0f;
		}

		private float dmOmXokuwYPeqkLCCIorsBnvJVN(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float uKCWXtJstxLBivpUoCOlAaKlIhZ(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (XCAyIFRJbEWUeBcnVweevmqWqtw.isUnknownController)
			{
				goto IL_001a;
			}
			goto IL_00bb;
			IL_00d3:
			int num = default(int);
			int num2 = default(int);
			if (P_0 < num + num2 && P_0 > num - num2)
			{
				return 1f;
			}
			return 0f;
			IL_001a:
			int num3 = 1413418762;
			goto IL_001f;
			IL_001f:
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ 0x543F0F0F)
				{
				case 0:
					break;
				case 5:
					goto IL_004f;
				case 4:
					return 0f;
				case 2:
					goto IL_007d;
				case 3:
					goto IL_0088;
				case 1:
					if (P_1 == 0 && P_0 > num4)
					{
						P_0 -= 36000;
						num3 = 1413418761;
						continue;
					}
					goto IL_00d3;
				case 7:
					return 0f;
				default:
					goto IL_00d3;
				}
				break;
				IL_007d:
				if (P_0 != num)
				{
					num3 = 1413418763;
					continue;
				}
				goto IL_0066;
				IL_004f:
				if (!InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
				{
					num3 = 1413418760;
					continue;
				}
				goto IL_00bb;
			}
			goto IL_001a;
			IL_0088:
			num4 = 27000;
			num2 = 9000;
			num3 = 1413418766;
			goto IL_001f;
			IL_00bb:
			int num5 = 4500;
			num = num5 * P_1;
			if (P_2 == HatType.EightWay)
			{
				num3 = 1413418765;
				goto IL_001f;
			}
			goto IL_0066;
			IL_0066:
			if (P_2 == HatType.EightWay)
			{
				num4 = 31500;
				num2 = 4500;
				num3 = 1413418766;
				goto IL_001f;
			}
			goto IL_0088;
		}

		private float lsSCStiAfbFyneyGtxVQJHRkdst(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			int num;
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000)
				{
					goto IL_003f;
				}
				if (P_0 < 9000)
				{
					goto IL_001d;
				}
				if (P_0 >= 27000 || P_0 <= 9000)
				{
					return 0f;
				}
				num = -1939155837;
			}
			else
			{
				if (P_0 <= 0)
				{
					goto IL_0081;
				}
				num = -1939155839;
			}
			goto IL_0022;
			IL_003f:
			return 1f;
			IL_0073:
			if (P_0 < 18000)
			{
				return 1f;
			}
			goto IL_0081;
			IL_0081:
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
			IL_0022:
			switch (num ^ -1939155837)
			{
			case 3:
				break;
			case 1:
				goto IL_003f;
			case 0:
				return -1f;
			default:
				goto IL_0073;
			}
			goto IL_001d;
			IL_001d:
			num = -1939155838;
			goto IL_0022;
		}

		private bool dIGEjeJuOmivVcCLDIiTEFopnzx(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			int sourceButton = default(int);
			while (true)
			{
				int num = 1185049442;
				while (true)
				{
					switch (num ^ 0x46A26B61)
					{
					case 0:
						break;
					case 1:
						if (sourceButton >= 256)
						{
							num = 1185049445;
							continue;
						}
						P_2 = P_1[sourceButton];
						return true;
					case 2:
					{
						int num3;
						if (sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
						{
							num = 1185049445;
							num3 = num;
						}
						else
						{
							num = 1185049440;
							num3 = num;
						}
						continue;
					}
					case 3:
					{
						if (P_0.sourceType != 0)
						{
							return false;
						}
						sourceButton = P_0.sourceButton;
						int num2;
						if (sourceButton < 0)
						{
							num = 1185049445;
							num2 = num;
						}
						else
						{
							num = 1185049443;
							num2 = num;
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

		private bool GcXMSpyoZSbgVbAoeISEDqCbryIv(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			while (true)
			{
				int num = 1094598504;
				while (true)
				{
					switch (num ^ 0x413E3F69)
					{
					case 5:
						break;
					case 2:
						P_1 = 0f;
						num = 1094598506;
						continue;
					case 7:
					{
						int num3;
						if (P_1 <= 0f)
						{
							num = 1094598509;
							num3 = num;
						}
						else
						{
							num = 1094598505;
							num3 = num;
						}
						continue;
					}
					case 6:
						num = 1094598506;
						continue;
					case 13:
						switch (P_0.sourceAxisRange)
						{
						case AxisRange.Negative:
							break;
						default:
							goto IL_009a;
						case AxisRange.Positive:
							goto IL_013b;
						}
						goto case 7;
					case 9:
						if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f)
						{
							int num2;
							if (MathTools.Abs(P_1) > P_0.axisDeadZone)
							{
								num = 1094598506;
								num2 = num;
							}
							else
							{
								num = 1094598507;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 1:
						if (P_0.sourceType != 1)
						{
							num = 1094598501;
							continue;
						}
						if (P_0.sourceAxis == 0)
						{
							return false;
						}
						P_1 = QkOJeQjNoGuvJJcCjzkxhFnepjH((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
						num = 1094598500;
						continue;
					case 0:
						P_1 = 0f;
						num = 1094598497;
						continue;
					case 8:
						num = 1094598509;
						continue;
					case 12:
						return false;
					case 10:
						goto IL_013b;
					case 4:
						if (P_0.axisCalibrationType == AxisCalibrationType.Default)
						{
							P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
							num = 1094598511;
							continue;
						}
						goto case 11;
					case 11:
						if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
						{
							P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
							num = 1094598506;
							continue;
						}
						goto case 9;
					default:
						{
							return true;
						}
						IL_009a:
						num = 1094598509;
						continue;
						IL_013b:
						if (P_1 < 0f)
						{
							P_1 = 0f;
							num = 1094598509;
							continue;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		private ControlDeviceType cczrjJXetwzEVNqofNtPnRQPiKY(DeviceType P_0)
		{
			if (P_0 == DeviceType.Keyboard)
			{
				return ControlDeviceType.tkHFoIOLgynnsbjfJgGsghWKZpu;
			}
			if (P_0 == DeviceType.Joystick)
			{
				goto IL_0009;
			}
			if (P_0 == DeviceType.Gamepad)
			{
				return ControlDeviceType.dNyyENhbShZpwawrFNHGUzXrCYg;
			}
			if (P_0 == DeviceType.Mouse)
			{
				return ControlDeviceType.EuQbsbgswOBiYuQiqzeyNfABXek;
			}
			int num;
			if (P_0 == DeviceType.MultiAxisController)
			{
				num = -1512574805;
				goto IL_000e;
			}
			return ControlDeviceType.srbgNzJMznryeuABhpjzUCNZxjJP;
			IL_0009:
			num = -1512574808;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1512574807)
			{
			case 0:
				break;
			case 1:
				return ControlDeviceType.sPSdDimdHdkUZBwhcqdUzIdejYne;
			default:
				return ControlDeviceType.sPSdDimdHdkUZBwhcqdUzIdejYne;
			}
			goto IL_0009;
		}

		private void XVsHhTTMurwFevgMeVpBaAgdBnH(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= gwfrHmNqxmYlnzynBGWAgujDDrf)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			while (true)
			{
				HwRqYBlbrIoKtVDOMNmmVOGCrNt[P_1] = kUwEAUClXTlqKMuncORLmafuoEy(P_0, P_2, P_3);
				if (RZErYKzcoEvfMnhtHeFDeTWjAxp)
				{
					break;
				}
				int num;
				int num2;
				if (HwRqYBlbrIoKtVDOMNmmVOGCrNt[P_1] != 0f)
				{
					num = 1382883728;
					num2 = num;
				}
				else
				{
					num = 1382883730;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x526D2193)
					{
					case 0:
						num = 1382883729;
						continue;
					default:
						return;
					case 2:
						break;
					case 3:
						RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
						num = 1382883730;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void ksKCYjFmSnAxYNZmTQlAbOeeMin(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			while (true)
			{
				xrmDwADRXdFsenTurfwlUsqsAvb[P_1] = KAVQLiNrtVlIUJXSsHsMLMbSyWc(P_0, P_2, P_3);
				if (RZErYKzcoEvfMnhtHeFDeTWjAxp || xrmDwADRXdFsenTurfwlUsqsAvb[P_1] == 0f)
				{
					break;
				}
				RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
				int num = -2133041745;
				while (true)
				{
					switch (num ^ -2133041746)
					{
					case 0:
						goto IL_0014;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0014:
					num = -2133041748;
				}
			}
		}

		private float kUwEAUClXTlqKMuncORLmafuoEy(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis >= 0 && sourceAxis < dhEQLHuCYYGQwdehmJKXAJgttVWs)
				{
					if (sourceAxis < 56)
					{
						return kUwEAUClXTlqKMuncORLmafuoEy(sourceAxis);
					}
					goto IL_0022;
				}
				goto IL_005f;
			}
			int num;
			float result = default(float);
			float num3 = default(float);
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					goto IL_009b;
				}
				if (sourceButton >= 256)
				{
					num = 100523307;
				}
				else
				{
					if (!P_1[sourceButton])
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution != Pole.Positive)
					{
						goto IL_011d;
					}
					result = 1f;
					num = 100523311;
				}
			}
			else
			{
				if (P_0.sourceType != 2)
				{
					return 0f;
				}
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= JwvOuylcUYNAjPLMAAlyukWmToj)
				{
					goto IL_0161;
				}
				if (sourceHat < 4)
				{
					int num2 = P_2[sourceHat];
					if (num2 < 0)
					{
						return 0f;
					}
					if (P_0.sourceHatDirection == AxisDirection.Horizontal)
					{
						num3 = lsSCStiAfbFyneyGtxVQJHRkdst(num2, AxisDirection.Horizontal);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
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
						}
					}
					else
					{
						num3 = lsSCStiAfbFyneyGtxVQJHRkdst(num2, AxisDirection.Vertical);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							num = 100523304;
							goto IL_0027;
						}
					}
					goto IL_0101;
				}
				num = 100523297;
			}
			goto IL_0027;
			IL_011d:
			result = -1f;
			num = 100523308;
			goto IL_0027;
			IL_009b:
			return 0f;
			IL_0101:
			int num4;
			if (P_0.invert)
			{
				num = 100523310;
				num4 = num;
			}
			else
			{
				num = 100523309;
				num4 = num;
			}
			goto IL_0027;
			IL_00da:
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
			goto IL_0101;
			IL_005f:
			return 0f;
			IL_0027:
			while (true)
			{
				switch (num ^ 0x5FDDD28)
				{
				case 2:
					break;
				case 1:
					goto IL_005f;
				case 3:
					goto IL_009b;
				case 6:
					num3 *= -1f;
					num = 100523309;
					continue;
				case 0:
					goto IL_00da;
				case 8:
					goto IL_011d;
				case 4:
					return result;
				case 9:
					goto IL_0161;
				case 7:
					num = 100523308;
					continue;
				default:
					return num3;
				}
				break;
			}
			goto IL_0022;
			IL_0022:
			num = 100523305;
			goto IL_0027;
			IL_0161:
			return 0f;
		}

		private float kUwEAUClXTlqKMuncORLmafuoEy(int P_0)
		{
			return (LLXxHTKTMzsnYyWPNUyGYIBrbuz as czpJRhiNvNJyEOLAnzblSHTKOXZ).QkOJeQjNoGuvJJcCjzkxhFnepjH(P_0);
		}

		private float KAVQLiNrtVlIUJXSsHsMLMbSyWc(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton >= 0 && sourceButton < aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					if (sourceButton < 256)
					{
						if (!P_1[sourceButton])
						{
							return 0f;
						}
						return 1f;
					}
					goto IL_0024;
				}
				goto IL_0061;
			}
			int num;
			int sourceHat = default(int);
			if (P_0.sourceType == 1)
			{
				num = 991663393;
			}
			else
			{
				if (P_0.sourceType != 2)
				{
					goto IL_0226;
				}
				sourceHat = P_0.sourceHat;
				if (sourceHat < 0)
				{
					goto IL_00a8;
				}
				int num2;
				if (sourceHat >= JwvOuylcUYNAjPLMAAlyukWmToj)
				{
					num = 991663395;
					num2 = num;
				}
				else
				{
					num = 991663397;
					num2 = num;
				}
			}
			goto IL_0029;
			IL_00a8:
			return 0f;
			IL_0024:
			num = 991663392;
			goto IL_0029;
			IL_0029:
			float num3 = default(float);
			while (true)
			{
				int sourceAxis;
				switch (num ^ 0x3B1B9524)
				{
				case 2:
					break;
				case 4:
					goto IL_0061;
				case 9:
					goto IL_008b;
				case 1:
					goto IL_009d;
				case 7:
					goto IL_00a8;
				case 3:
					return 0f;
				case 5:
					sourceAxis = P_0.sourceAxis;
					if (sourceAxis < 0 || sourceAxis >= dhEQLHuCYYGQwdehmJKXAJgttVWs)
					{
						goto case 3;
					}
					goto IL_013e;
				case 0:
					return 0f;
				default:
					goto IL_019e;
				case 8:
					goto IL_0226;
				}
				break;
				IL_013e:
				if (sourceAxis < 56)
				{
					num3 = kUwEAUClXTlqKMuncORLmafuoEy(sourceAxis);
					if (MathTools.Abs(num3) <= P_0.axisDeadZone)
					{
						return 0f;
					}
					if (P_0.sourceAxisPole == Pole.Positive)
					{
						num = 991663405;
						continue;
					}
					if (num3 > 0f)
					{
						return 0f;
					}
					goto IL_0161;
				}
				num = 991663399;
				continue;
				IL_008b:
				if (num3 < 0f)
				{
					num = 991663396;
					continue;
				}
				goto IL_0161;
				IL_0161:
				return 1f;
				IL_019e:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 0, P_0.sourceHatType);
				IL_009d:
				if (sourceHat >= 4)
				{
					num = 991663395;
					continue;
				}
				switch (P_0.sourceHatDirection)
				{
				default:
					num = 991663404;
					continue;
				case HatDirection.Up:
					break;
				case HatDirection.UpRight:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 7, P_0.sourceHatType);
				}
				goto IL_019e;
			}
			goto IL_0024;
			IL_0061:
			return 0f;
			IL_0226:
			return 0f;
		}

		private bool YnFtZMceglxNSFwZkMbAaVXciIE(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			int num = 4500;
			int num6 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 497848201;
				while (true)
				{
					switch (num2 ^ 0x1DAC8F88)
					{
					case 2:
						break;
					case 0:
					{
						int num7;
						if (P_1 != 0)
						{
							num2 = 497848206;
							num7 = num2;
						}
						else
						{
							num2 = 497848205;
							num7 = num2;
						}
						continue;
					}
					case 8:
						num6 = 31500;
						num4 = 4500;
						num2 = 497848200;
						continue;
					case 4:
					{
						if (P_2 == HatType.EightWay && P_0 != num3)
						{
							return false;
						}
						int num5;
						if (P_2 != HatType.EightWay)
						{
							num2 = 497848203;
							num5 = num2;
						}
						else
						{
							num2 = 497848192;
							num5 = num2;
						}
						continue;
					}
					case 1:
						num3 = num * P_1;
						num2 = 497848204;
						continue;
					case 3:
						num6 = 27000;
						num4 = 9000;
						num2 = 497848200;
						continue;
					case 5:
						if (P_0 > num6)
						{
							P_0 -= 36000;
							num2 = 497848206;
							continue;
						}
						goto case 6;
					case 6:
						if (P_0 < num3 + num4)
						{
							num2 = 497848207;
							continue;
						}
						goto IL_00de;
					default:
						{
							if (P_0 > num3 - num4)
							{
								return true;
							}
							goto IL_00de;
						}
						IL_00de:
						return false;
					}
					break;
				}
			}
		}

		private float LbzeigGfBGuurJQRcaXLoGuyhGKJ(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 <= 27000)
				{
					if (P_0 >= 9000)
					{
						if (P_0 < 27000 && P_0 > 9000)
						{
							return -1f;
						}
						return 0f;
					}
					goto IL_001d;
				}
				goto IL_003f;
			}
			int num;
			if (P_0 > 0)
			{
				num = -1453752008;
				goto IL_0022;
			}
			goto IL_007a;
			IL_007a:
			if (P_0 > 18000)
			{
				num = -1453752005;
				goto IL_0022;
			}
			return 0f;
			IL_003f:
			return 1f;
			IL_0022:
			switch (num ^ -1453752007)
			{
			case 0:
				break;
			case 3:
				goto IL_003f;
			case 1:
				goto IL_006c;
			default:
				return -1f;
			}
			goto IL_001d;
			IL_006c:
			if (P_0 < 18000)
			{
				return 1f;
			}
			goto IL_007a;
			IL_001d:
			num = -1453752006;
			goto IL_0022;
		}

		private void XCEcogOtFbmhupWduawPDMqkEjv()
		{
			XCAyIFRJbEWUeBcnVweevmqWqtw = lvntcpgdZsSbabccpIcfMpTzYYr(PJFgAzlnjXDIFtIVMtyxcOgBHLL());
			while (true)
			{
				int num = 1657942580;
				while (true)
				{
					switch (num ^ 0x62D23235)
					{
					case 3:
						break;
					case 1:
						if (XCAyIFRJbEWUeBcnVweevmqWqtw == null)
						{
							goto IL_0041;
						}
						goto default;
					case 2:
						return;
					default:
						gwfrHmNqxmYlnzynBGWAgujDDrf = XCAyIFRJbEWUeBcnVweevmqWqtw.axisCount;
						rqeFUUCoNDfDgMOxuCDGnyLQlXi = XCAyIFRJbEWUeBcnVweevmqWqtw.buttonCount;
						return;
					}
					break;
					IL_0041:
					Logger.LogError("Default hardware map not found!");
					num = 1657942583;
				}
			}
		}

		private string RTTlCdhTqgSczdNjerRfpyDBDni()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.RawInput, (HUFFKhqkxcIVKhtrxspNbGBrTdG && !string.IsNullOrEmpty(ZYtBoPNuCmSlSLPglVVYiiIepKT)) ? ZYtBoPNuCmSlSLPglVVYiiIepKT : SgtdGZiZKfxrYfEaONXeCdMIqIsz, rFChCpBSHUoiIZbKWfsTCHUdRna, eTlTTlBmuxCORrngMaNsxFSpDyMi));
		}

		private void qLdgPikrSeiPWSEbkkdRitWDfeYu(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = PSZKcVVfVmWuwyrmRaPnqSTTRBB.InputSource;
			while (true)
			{
				int num = -290816915;
				while (true)
				{
					switch (num ^ -290816916)
					{
					case 6:
						break;
					case 7:
						P_0.hw_productName = SgtdGZiZKfxrYfEaONXeCdMIqIsz;
						num = -290816920;
						continue;
					case 2:
						P_0.hardwareButtonCount = aCdTArmyUaJIYSBpkbuJpDufgNGc;
						num = -290816916;
						continue;
					case 5:
						P_0.hw_isBluetoothDevice = HUFFKhqkxcIVKhtrxspNbGBrTdG;
						P_0.hw_bluetoothDeviceName = ZYtBoPNuCmSlSLPglVVYiiIepKT;
						P_0.hw_supportsVibration = uyjBbcIhGzMpDSyGYNhGPPRoYdp;
						P_0.hw_localVibrationMotorCount = tojPLGfGkimbIivokBFIzlnJQIx;
						num = -290816913;
						continue;
					case 1:
						P_0.deviceType = cczrjJXetwzEVNqofNtPnRQPiKY(PMEjyOyDoHeJObaqgZAFOKNMJAOj);
						num = -290816924;
						continue;
					case 0:
						P_0.hardwareHatCount = JwvOuylcUYNAjPLMAAlyukWmToj;
						num = -290816917;
						continue;
					case 8:
						P_0.hardwareIdentifier = RTTlCdhTqgSczdNjerRfpyDBDni();
						P_0.hardwareAxisCount = dhEQLHuCYYGQwdehmJKXAJgttVWs;
						num = -290816914;
						continue;
					case 4:
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_vendorId = PbwglKnIRKBGqGPSCbbymWhNwoO;
						P_0.hw_productId = rFChCpBSHUoiIZbKWfsTCHUdRna;
						P_0.hw_pidVid = new PidVid(eTlTTlBmuxCORrngMaNsxFSpDyMi);
						num = -290816919;
						continue;
					default:
						P_0.definitionMatchTag = PSZKcVVfVmWuwyrmRaPnqSTTRBB.HWDefinitionMatchTag;
						return;
					}
					break;
				}
			}
		}

		private void qLdgPikrSeiPWSEbkkdRitWDfeYu(BridgedController P_0)
		{
			qLdgPikrSeiPWSEbkkdRitWDfeYu((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			while (true)
			{
				int num = -689290610;
				while (true)
				{
					switch (num ^ -689290614)
					{
					case 5:
						break;
					default:
						return;
					case 3:
						P_0.axisCount = gwfrHmNqxmYlnzynBGWAgujDDrf;
						P_0.buttonCount = rqeFUUCoNDfDgMOxuCDGnyLQlXi;
						P_0.isButtonPressureSensitive = new bool[rqeFUUCoNDfDgMOxuCDGnyLQlXi];
						num = -689290612;
						continue;
					case 7:
						P_0.productName = SgtdGZiZKfxrYfEaONXeCdMIqIsz;
						P_0.isXInputDevice = IEIpySejupFvUUEVIERJEkDtdcvv;
						num = -689290615;
						continue;
					case 6:
						Array.Copy(sTmhwWLXxOaMsilVHjWGwCeGIBV, P_0.isButtonPressureSensitive, rqeFUUCoNDfDgMOxuCDGnyLQlXi);
						num = -689290616;
						continue;
					case 2:
						P_0.unknownControllerHats = FsPEePPVDusMDfXPvWAmjGinMkk();
						P_0.controllerTypeGuid = FHAzoTozCrisunLDoLyimqNbdex;
						num = -689290613;
						continue;
					case 1:
						P_0.controllerExtension = extension;
						num = -689290614;
						continue;
					case 4:
						P_0.gameHardwareMap = XCAyIFRJbEWUeBcnVweevmqWqtw.ToGameHardwareControllerMap();
						P_0.instanceName = aQyubnFZjhaxoHtWxfehAEYaFOR;
						num = -689290611;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void SLzNkHKfnjNVYXrvEkoGmEPNQFJ()
		{
			int num = 0;
			int num2 = default(int);
			while (true)
			{
				IL_0042:
				int num3;
				if (num >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
				{
					num2 = 0;
					num3 = -814529706;
					goto IL_0009;
				}
				goto IL_002a;
				IL_0009:
				while (true)
				{
					switch (num3 ^ -814529710)
					{
					case 2:
						num3 = -814529709;
						continue;
					case 1:
						break;
					case 0:
						goto IL_0042;
					case 3:
						HwRqYBlbrIoKtVDOMNmmVOGCrNt[num2] = 0f;
						num2++;
						num3 = -814529706;
						continue;
					default:
						if (num2 >= gwfrHmNqxmYlnzynBGWAgujDDrf)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
				goto IL_002a;
				IL_002a:
				xrmDwADRXdFsenTurfwlUsqsAvb[num] = 0f;
				num++;
				num3 = -814529710;
				goto IL_0009;
			}
		}

		private UnknownControllerHat[] FsPEePPVDusMDfXPvWAmjGinMkk()
		{
			if (!cbEqXqyoXBYbIYeDgNacVLXtacu)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			int num = 0;
			while (num < 2)
			{
				while (true)
				{
					int num2 = 128 + num * 8;
					int[] array2 = new int[8] { num2, 0, 0, 0, 0, 0, 0, 0 };
					int num3 = -183880014;
					while (true)
					{
						switch (num3 ^ -183880016)
						{
						case 4:
							num3 = -183880015;
							continue;
						case 1:
							break;
						case 3:
						{
							UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
							array[num] = new UnknownControllerHat(buttons);
							num++;
							num3 = -183880016;
							continue;
						}
						case 2:
							array2[1] = num2 + 1;
							num3 = -183880011;
							continue;
						case 5:
							array2[2] = num2 + 2;
							array2[3] = num2 + 3;
							num3 = -183880010;
							continue;
						case 6:
							array2[4] = num2 + 4;
							array2[5] = num2 + 5;
							array2[6] = num2 + 6;
							array2[7] = num2 + 7;
							num3 = -183880013;
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
			return array;
		}

		public void JGfOaxGMMubjxaprhTWpWgtvAPZ()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
			GC.SuppressFinalize(this);
		}

		~CQqdgMSBwubrhVugChMjQReeGmRd()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
		}

		protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
		{
			if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
			{
				return;
			}
			while (true)
			{
				nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
				int num = -1725723181;
				while (true)
				{
					switch (num ^ -1725723182)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = -1725723184;
				}
			}
		}

		public static int MkXapRSnnzwLWGXiQrUeZlhrOqE(CQqdgMSBwubrhVugChMjQReeGmRd P_0, CQqdgMSBwubrhVugChMjQReeGmRd P_1)
		{
			if (P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd < P_1.QSgOYisLlLVufpwxLNKaoIEBiyFd)
			{
				return -1;
			}
			if (P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd > P_1.QSgOYisLlLVufpwxLNKaoIEBiyFd)
			{
				return 1;
			}
			return 0;
		}

		public static int IQnVWhjqpLtmuLhORhWWdeggsnb(CQqdgMSBwubrhVugChMjQReeGmRd P_0, CQqdgMSBwubrhVugChMjQReeGmRd P_1)
		{
			if (P_0.iERVPkhRheIKptTuTmWgWiTZGxm < P_1.iERVPkhRheIKptTuTmWgWiTZGxm)
			{
				return -1;
			}
			if (P_0.iERVPkhRheIKptTuTmWgWiTZGxm > P_1.iERVPkhRheIKptTuTmWgWiTZGxm)
			{
				return 1;
			}
			return 0;
		}
	}

	private class nhnmSGeBkAttkmfxmxGlDeglhSGe
	{
		public enum CxzhajiaPSyLynbAMiUXPxiPCHW
		{
			pcWfOxYbvNCAItRmLAyYfYdvnxE = 0,
			JgYTOGxxNXCOjMYfJlJOWIFnveY = 1
		}

		public class jTQpvKbMiIWhEITSYjSfdPlUyzL
		{
			public int OHBcezjWhuCjOisuXXaxDLGlnPLC;

			public Guid AptpRPzwmRXfndEyzaGRSilWIbv;

			public Guid AIefUprvkNeEvLSsrampirFfHMzU;

			public int WppCCSIJiYbWggCDNrMGswGEsUzA;

			public int dhEQLHuCYYGQwdehmJKXAJgttVWs;

			public int aCdTArmyUaJIYSBpkbuJpDufgNGc;

			public int JwvOuylcUYNAjPLMAAlyukWmToj;

			public int rqeFUUCoNDfDgMOxuCDGnyLQlXi;

			public int gwfrHmNqxmYlnzynBGWAgujDDrf;

			public bool ABQyAdxhmreYSttkGbIRXrnKiNq;

			public bool QJuTPVbZPhckxeVMgmaDORJltri(CQqdgMSBwubrhVugChMjQReeGmRd P_0, CxzhajiaPSyLynbAMiUXPxiPCHW P_1)
			{
				if (dhEQLHuCYYGQwdehmJKXAJgttVWs != P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs)
				{
					return false;
				}
				if (aCdTArmyUaJIYSBpkbuJpDufgNGc != P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					goto IL_001e;
				}
				int num;
				if (JwvOuylcUYNAjPLMAAlyukWmToj != P_0.JwvOuylcUYNAjPLMAAlyukWmToj)
				{
					num = -1130505936;
				}
				else
				{
					if (rqeFUUCoNDfDgMOxuCDGnyLQlXi != P_0.rqeFUUCoNDfDgMOxuCDGnyLQlXi)
					{
						return false;
					}
					if (gwfrHmNqxmYlnzynBGWAgujDDrf != P_0.gwfrHmNqxmYlnzynBGWAgujDDrf)
					{
						return false;
					}
					if (ABQyAdxhmreYSttkGbIRXrnKiNq != P_0.hasDriver)
					{
						return false;
					}
					if (P_0.rewiredId == OHBcezjWhuCjOisuXXaxDLGlnPLC)
					{
						return true;
					}
					if (P_1 == CxzhajiaPSyLynbAMiUXPxiPCHW.pcWfOxYbvNCAItRmLAyYfYdvnxE)
					{
						return AptpRPzwmRXfndEyzaGRSilWIbv == P_0.instanceGuid;
					}
					if (P_1 != CxzhajiaPSyLynbAMiUXPxiPCHW.JgYTOGxxNXCOjMYfJlJOWIFnveY)
					{
						throw new NotImplementedException();
					}
					num = -1130505933;
				}
				goto IL_0023;
				IL_001e:
				num = -1130505935;
				goto IL_0023;
				IL_0023:
				switch (num ^ -1130505934)
				{
				case 0:
					break;
				case 3:
					return false;
				case 2:
					return false;
				default:
					return AIefUprvkNeEvLSsrampirFfHMzU == P_0.AIefUprvkNeEvLSsrampirFfHMzU;
				}
				goto IL_001e;
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				object[] array = new object[4];
				object[] array8 = default(object[]);
				object obj10 = default(object);
				object[] array4 = default(object[]);
				object obj2 = default(object);
				object[] array2 = default(object[]);
				object obj3 = default(object);
				object[] array3 = default(object[]);
				object[] array7 = default(object[]);
				object obj7 = default(object);
				object[] array5 = default(object[]);
				object[] array6 = default(object[]);
				object obj5 = default(object);
				while (true)
				{
					int num = -1406017555;
					while (true)
					{
						switch (num ^ -1406017560)
						{
						case 2:
							break;
						case 13:
							array8[0] = obj10;
							array8[1] = "gameAxisCount = ";
							array8[2] = gwfrHmNqxmYlnzynBGWAgujDDrf;
							num = -1406017544;
							continue;
						case 10:
							text = string.Concat(array4);
							num = -1406017561;
							continue;
						case 16:
							array8[3] = "\n";
							text = string.Concat(array8);
							obj2 = text;
							array2 = new object[4];
							num = -1406017557;
							continue;
						case 18:
							obj3 = text;
							array3 = new object[4];
							num = -1406017567;
							continue;
						case 17:
							array7[3] = "\n";
							text = string.Concat(array7);
							obj10 = text;
							array8 = new object[4];
							num = -1406017563;
							continue;
						case 15:
							obj7 = text;
							num = -1406017564;
							continue;
						case 14:
						{
							array3[1] = "typeIdentifierGuid = ";
							array3[2] = AIefUprvkNeEvLSsrampirFfHMzU;
							array3[3] = "\n";
							text = string.Concat(array3);
							object obj8 = text;
							text = string.Concat(obj8, "lastInputManagerId = ", WppCCSIJiYbWggCDNrMGswGEsUzA, "\n");
							object obj9 = text;
							text = string.Concat(obj9, "hardwareAxisCount = ", dhEQLHuCYYGQwdehmJKXAJgttVWs, "\n");
							num = -1406017553;
							continue;
						}
						case 5:
							array[0] = obj;
							array[1] = "rewiredId = ";
							array[2] = OHBcezjWhuCjOisuXXaxDLGlnPLC;
							array[3] = "\n";
							num = -1406017560;
							continue;
						case 4:
							array5 = new object[4];
							num = -1406017559;
							continue;
						case 11:
							array6[0] = obj7;
							array6[1] = "hardwareHatCount = ";
							array6[2] = JwvOuylcUYNAjPLMAAlyukWmToj;
							num = -1406017554;
							continue;
						case 8:
						{
							object obj6 = text;
							array7 = new object[4] { obj6, "gameButtonCount = ", rqeFUUCoNDfDgMOxuCDGnyLQlXi, null };
							num = -1406017543;
							continue;
						}
						case 12:
							array6 = new object[4];
							num = -1406017565;
							continue;
						case 6:
							array6[3] = "\n";
							text = string.Concat(array6);
							num = -1406017568;
							continue;
						case 1:
							array5[0] = obj5;
							array5[1] = "instanceGuid = ";
							array5[2] = AptpRPzwmRXfndEyzaGRSilWIbv;
							array5[3] = "\n";
							num = -1406017541;
							continue;
						case 19:
							text = string.Concat(array5);
							num = -1406017542;
							continue;
						case 0:
							text = string.Concat(array);
							obj5 = text;
							num = -1406017556;
							continue;
						case 7:
						{
							object obj4 = text;
							array4 = new object[4] { obj4, "hardwareButtonCount = ", aCdTArmyUaJIYSBpkbuJpDufgNGc, "\n" };
							num = -1406017566;
							continue;
						}
						case 9:
							array3[0] = obj3;
							num = -1406017562;
							continue;
						default:
							array2[0] = obj2;
							array2[1] = "hasDriver = ";
							array2[2] = ABQyAdxhmreYSttkGbIRXrnKiNq;
							array2[3] = "\n";
							return string.Concat(array2);
						}
						break;
					}
				}
			}
		}

		private List<jTQpvKbMiIWhEITSYjSfdPlUyzL> hdvnYESDqWrpDISRbrulIlAPAqTj;

		public nhnmSGeBkAttkmfxmxGlDeglhSGe()
		{
			hdvnYESDqWrpDISRbrulIlAPAqTj = new List<jTQpvKbMiIWhEITSYjSfdPlUyzL>();
		}

		public void xdxZeKjdcofLtxWSQEJXMnutFBg(CQqdgMSBwubrhVugChMjQReeGmRd P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
				int num = -1653355491;
				while (true)
				{
					switch (num ^ -1653355496)
					{
					case 3:
						num = -1653355494;
						continue;
					default:
						return;
					case 6:
						if (num2 >= count)
						{
							hdvnYESDqWrpDISRbrulIlAPAqTj.Add(new jTQpvKbMiIWhEITSYjSfdPlUyzL
							{
								OHBcezjWhuCjOisuXXaxDLGlnPLC = P_0.rewiredId,
								AptpRPzwmRXfndEyzaGRSilWIbv = P_0.instanceGuid,
								AIefUprvkNeEvLSsrampirFfHMzU = P_0.AIefUprvkNeEvLSsrampirFfHMzU,
								WppCCSIJiYbWggCDNrMGswGEsUzA = P_0.inputManagerId,
								dhEQLHuCYYGQwdehmJKXAJgttVWs = P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs,
								aCdTArmyUaJIYSBpkbuJpDufgNGc = P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc,
								JwvOuylcUYNAjPLMAAlyukWmToj = P_0.JwvOuylcUYNAjPLMAAlyukWmToj,
								rqeFUUCoNDfDgMOxuCDGnyLQlXi = P_0.rqeFUUCoNDfDgMOxuCDGnyLQlXi,
								gwfrHmNqxmYlnzynBGWAgujDDrf = P_0.gwfrHmNqxmYlnzynBGWAgujDDrf,
								ABQyAdxhmreYSttkGbIRXrnKiNq = P_0.hasDriver
							});
							TxZIpUDzPauiBdjCLSiYGapVtMo(P_0.rewiredId, P_0.instanceGuid, hdvnYESDqWrpDISRbrulIlAPAqTj.Count - 1);
							num = -1653355495;
							continue;
						}
						goto case 0;
					case 5:
						num2 = 0;
						num = -1653355492;
						continue;
					case 0:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num2].QJuTPVbZPhckxeVMgmaDORJltri(P_0, CxzhajiaPSyLynbAMiUXPxiPCHW.pcWfOxYbvNCAItRmLAyYfYdvnxE))
						{
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].OHBcezjWhuCjOisuXXaxDLGlnPLC = P_0.rewiredId;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].AptpRPzwmRXfndEyzaGRSilWIbv = P_0.instanceGuid;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].AIefUprvkNeEvLSsrampirFfHMzU = P_0.AIefUprvkNeEvLSsrampirFfHMzU;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].WppCCSIJiYbWggCDNrMGswGEsUzA = P_0.inputManagerId;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].dhEQLHuCYYGQwdehmJKXAJgttVWs = P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].aCdTArmyUaJIYSBpkbuJpDufgNGc = P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].JwvOuylcUYNAjPLMAAlyukWmToj = P_0.JwvOuylcUYNAjPLMAAlyukWmToj;
							hdvnYESDqWrpDISRbrulIlAPAqTj[num2].rqeFUUCoNDfDgMOxuCDGnyLQlXi = P_0.rqeFUUCoNDfDgMOxuCDGnyLQlXi;
							num = -1653355489;
							continue;
						}
						goto case 8;
					case 4:
						num = -1653355490;
						continue;
					case 7:
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].gwfrHmNqxmYlnzynBGWAgujDDrf = P_0.gwfrHmNqxmYlnzynBGWAgujDDrf;
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].ABQyAdxhmreYSttkGbIRXrnKiNq = P_0.hasDriver;
						TxZIpUDzPauiBdjCLSiYGapVtMo(P_0.rewiredId, P_0.instanceGuid, num2);
						return;
					case 2:
						break;
					case 8:
						num2++;
						num = -1653355490;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public bool QacznVUaOaCwCvKomxmAnPOqZdr(CQqdgMSBwubrhVugChMjQReeGmRd P_0, CxzhajiaPSyLynbAMiUXPxiPCHW P_1)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = -43669877;
					num3 = num2;
				}
				else
				{
					num2 = -43669875;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -43669873)
					{
					case 3:
						num2 = -43669875;
						continue;
					case 2:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num].QJuTPVbZPhckxeVMgmaDORJltri(P_0, P_1))
						{
							num2 = -43669874;
							continue;
						}
						num++;
						num2 = -43669873;
						continue;
					case 0:
						break;
					case 1:
						return true;
					default:
						return false;
					}
					break;
				}
			}
		}

		public jTQpvKbMiIWhEITSYjSfdPlUyzL GAYuJaWQWiVlljmcwLCVJqAlvzZ(CQqdgMSBwubrhVugChMjQReeGmRd P_0, CxzhajiaPSyLynbAMiUXPxiPCHW P_1)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 965375661;
					num3 = num2;
				}
				else
				{
					num2 = 965375662;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x398A76AF)
					{
					case 0:
						num2 = 965375661;
						continue;
					case 2:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num].QJuTPVbZPhckxeVMgmaDORJltri(P_0, P_1))
						{
							return hdvnYESDqWrpDISRbrulIlAPAqTj[num];
						}
						num++;
						num2 = 965375660;
						continue;
					case 3:
						break;
					default:
						return null;
					}
					break;
				}
			}
		}

		private void TxZIpUDzPauiBdjCLSiYGapVtMo(int P_0, Guid P_1, int P_2)
		{
			int num = hdvnYESDqWrpDISRbrulIlAPAqTj.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					int num2;
					if (num != P_2)
					{
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num].OHBcezjWhuCjOisuXXaxDLGlnPLC != P_0)
						{
							int num3;
							if (!(hdvnYESDqWrpDISRbrulIlAPAqTj[num].AptpRPzwmRXfndEyzaGRSilWIbv == P_1))
							{
								num2 = 1671278631;
								num3 = num2;
							}
							else
							{
								num2 = 1671278628;
								num3 = num2;
							}
							goto IL_0018;
						}
						goto IL_007b;
					}
					goto IL_008e;
					IL_007b:
					hdvnYESDqWrpDISRbrulIlAPAqTj.RemoveAt(num);
					num2 = 1671278631;
					goto IL_0018;
					IL_008e:
					num--;
					num2 = 1671278630;
					goto IL_0018;
					IL_0018:
					while (true)
					{
						switch (num2 ^ 0x639DB027)
						{
						case 2:
							num2 = 1671278627;
							continue;
						case 4:
							break;
						case 3:
							goto IL_007b;
						case 0:
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
			object obj = text;
			object[] array = new object[4] { obj, "Joystick records: ", null, null };
			int num2 = default(int);
			object[] array2 = default(object[]);
			while (true)
			{
				int num = -1280558775;
				while (true)
				{
					switch (num ^ -1280558771)
					{
					case 3:
						break;
					case 4:
						array[2] = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
						array[3] = "\n";
						text = string.Concat(array);
						num2 = 0;
						num = -1280558772;
						continue;
					case 2:
						array2[3] = ":\n";
						text = string.Concat(array2);
						text = text + hdvnYESDqWrpDISRbrulIlAPAqTj[num2].ToString() + "\n\n";
						num2++;
						num = -1280558772;
						continue;
					case 0:
					{
						object obj2 = text;
						array2 = new object[4] { obj2, "Record ", num2, null };
						num = -1280558769;
						continue;
					}
					default:
						if (num2 >= hdvnYESDqWrpDISRbrulIlAPAqTj.Count)
						{
							return text;
						}
						goto case 0;
					}
					break;
				}
			}
		}
	}

	private ToVVOkLlyfGfCymNVHdVmAohoaz oAncdCDeuarlyAVWrkNljduAgRv;

	private List<CQqdgMSBwubrhVugChMjQReeGmRd> SECqOtxIJCMtDAXMpkZHtbqiXBU;

	private int lTHFykxDvdBXxFWZTYErzFFjdVX;

	private nhnmSGeBkAttkmfxmxGlDeglhSGe BhZbSIqTJUuvrHhjvLiLwhtaXiV;

	private bool mZVnLimgafFHWakbbRpLWuLRjTSi;

	private TimerRealTime bwJraMvCEoaGCssXuTteIKcJrpq;

	private global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool> iIGFCPdeKbcstfqznMqAUVSlgBRa;

	private int vyWIGRlrOSwEAfybgEcTHDgPgON;

	private global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool> xDdQXMmOyKgEpzhLcTGIfORMPtT;

	private ConfigVars KdNsUfQYehHKnbEfgCkEKVkPfoEV;

	private bool ydtjoUaZMACQbAJqHjVabQJcAHgE;

	private Action<int, ControllerDataUpdater> OtrNTBJIBbQldvImDmKCAqMRnke;

	private PlatformInputManager KbZxDysFPLnvPkdChDFikEdaiLpJ;

	private readonly BJiZlRFcXwALLpIPzfTIrXROVHG SCWnpyELlKxxAXOzoQpSqiyTdPf;

	private readonly hIrefywNUPTTqDhngBJCNezwczv NTvkIjdRvKUBEYGNJZoXqfbatvi;

	private readonly bool bkNLtfWXdHFQHoTBrLDLPyyblom;

	private readonly bool ZmPsgTeJvSmZcVdpLFarBeNhUvt;

	private readonly bool iogeGVrPSlgmncKTwvFLvDcZvoCk;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

	private readonly Func<int> osCAPAIYOEZodlsEwtiFRgmwudTL;

	public bool useXInput
	{
		set
		{
			ydtjoUaZMACQbAJqHjVabQJcAHgE = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return lTHFykxDvdBXxFWZTYErzFFjdVX;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return KbZxDysFPLnvPkdChDFikEdaiLpJ;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return oAncdCDeuarlyAVWrkNljduAgRv;
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

	public ZPFgjuIZrGwPvWsWAyvFqQxHtxkn(ConfigVars configVars, bool useXInput, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard, bool useCustomDrivers)
	{
		try
		{
			KdNsUfQYehHKnbEfgCkEKVkPfoEV = configVars;
			ydtjoUaZMACQbAJqHjVabQJcAHgE = useXInput;
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			osCAPAIYOEZodlsEwtiFRgmwudTL = getNewJoystickId;
			bkNLtfWXdHFQHoTBrLDLPyyblom = handleJoysticks;
			ZmPsgTeJvSmZcVdpLFarBeNhUvt = handleUnifiedMouse;
			iogeGVrPSlgmncKTwvFLvDcZvoCk = handleUnifiedKeyboard;
			KbZxDysFPLnvPkdChDFikEdaiLpJ = this;
			if (handleUnifiedKeyboard)
			{
				NTvkIjdRvKUBEYGNJZoXqfbatvi = new hIrefywNUPTTqDhngBJCNezwczv(configVars.updateLoop);
			}
			if (handleUnifiedMouse)
			{
				SCWnpyELlKxxAXOzoQpSqiyTdPf = new BJiZlRFcXwALLpIPzfTIrXROVHG(configVars.updateLoop);
			}
			oAncdCDeuarlyAVWrkNljduAgRv = new ToVVOkLlyfGfCymNVHdVmAohoaz(configVars, handleJoysticks, useCustomDrivers, SCWnpyELlKxxAXOzoQpSqiyTdPf, NTvkIjdRvKUBEYGNJZoXqfbatvi);
			OtrNTBJIBbQldvImDmKCAqMRnke = UpdateControllerData;
			iIGFCPdeKbcstfqznMqAUVSlgBRa = new global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool>(true, oAncdCDeuarlyAVWrkNljduAgRv.eNOnPlLjwNbOfIUjAqxYoQZqABfY);
			xDdQXMmOyKgEpzhLcTGIfORMPtT = new global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool>(true, oAncdCDeuarlyAVWrkNljduAgRv.IfslcLnhMkosBnmwoPSIUoBSVMZ);
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
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return;
		}
		while (true)
		{
			int num = -1628576280;
			while (true)
			{
				switch (num ^ -1628576279)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					BhZbSIqTJUuvrHhjvLiLwhtaXiV = new nhnmSGeBkAttkmfxmxGlDeglhSGe();
					bwJraMvCEoaGCssXuTteIKcJrpq = new TimerRealTime(1f);
					num = -1628576278;
					continue;
				case 3:
					bwJraMvCEoaGCssXuTteIKcJrpq.Start();
					IuJWHOMhNPSovTnENyBCQBmofkX();
					num = -1628576277;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			goto IL_000b;
		}
		goto IL_0150;
		IL_000b:
		int num = 798978408;
		goto IL_0010;
		IL_0010:
		while (true)
		{
			switch (num ^ 0x2F9F7162)
			{
			case 8:
				break;
			default:
				return;
			case 13:
				oAncdCDeuarlyAVWrkNljduAgRv.UpdateFinished();
				num = 798978404;
				continue;
			case 11:
				NTvkIjdRvKUBEYGNJZoXqfbatvi.OKHZGFMfxtklwLbZuCziRQFTDNac(updateLoop);
				num = 798978402;
				continue;
			case 2:
				goto IL_007d;
			case 6:
				goto IL_0099;
			case 9:
				oAncdCDeuarlyAVWrkNljduAgRv.Update();
				num = 798978406;
				continue;
			case 7:
				goto IL_00ca;
			case 1:
				oAncdCDeuarlyAVWrkNljduAgRv.UpdateDevices(updateLoop);
				num = 798978405;
				continue;
			case 4:
				goto IL_0102;
			case 10:
				apaayfodvIoMOBTmDElQhcNkElT();
				num = 798978414;
				continue;
			case 3:
				goto IL_0134;
			case 12:
				goto IL_0150;
			case 5:
				SCWnpyELlKxxAXOzoQpSqiyTdPf.OKHZGFMfxtklwLbZuCziRQFTDNac(updateLoop);
				num = 798978401;
				continue;
			case 0:
				return;
			}
			break;
			IL_0134:
			int num2;
			if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
			{
				num = 798978409;
				num2 = num;
			}
			else
			{
				num = 798978402;
				num2 = num;
			}
			continue;
			IL_007d:
			int num3;
			if (oAncdCDeuarlyAVWrkNljduAgRv != null)
			{
				num = 798978403;
				num3 = num;
			}
			else
			{
				num = 798978405;
				num3 = num;
			}
			continue;
			IL_00ca:
			nVcSLNPamegvZJFhMFHMKCYMWxY();
			int num4;
			if (oAncdCDeuarlyAVWrkNljduAgRv != null)
			{
				num = 798978415;
				num4 = num;
			}
			else
			{
				num = 798978404;
				num4 = num;
			}
			continue;
			IL_0102:
			jONkrzccOBAfjAzxVQUAFDRBogb();
			int num5;
			if (bkNLtfWXdHFQHoTBrLDLPyyblom)
			{
				num = 798978400;
				num5 = num;
			}
			else
			{
				num = 798978404;
				num5 = num;
			}
			continue;
			IL_0099:
			int num6;
			if (!ZmPsgTeJvSmZcVdpLFarBeNhUvt)
			{
				num = 798978401;
				num6 = num;
			}
			else
			{
				num = 798978407;
				num6 = num;
			}
		}
		goto IL_000b;
		IL_0150:
		int num7;
		if (oAncdCDeuarlyAVWrkNljduAgRv == null)
		{
			num = 798978406;
			num7 = num;
		}
		else
		{
			num = 798978411;
			num7 = num;
		}
		goto IL_0010;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (xDdQXMmOyKgEpzhLcTGIfORMPtT != null)
		{
			goto IL_000b;
		}
		goto IL_0097;
		IL_000b:
		int num = 899807951;
		goto IL_0010;
		IL_0010:
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num ^ 0x35A1FAC7)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0054;
			case 12:
				goto IL_006d;
			case 7:
				NTvkIjdRvKUBEYGNJZoXqfbatvi.Dispose();
				num = 899807949;
				continue;
			case 4:
				goto IL_0097;
			case 5:
				if (oAncdCDeuarlyAVWrkNljduAgRv != null)
				{
					oAncdCDeuarlyAVWrkNljduAgRv.Dispose();
					num = 899807948;
					continue;
				}
				return;
			case 8:
				xDdQXMmOyKgEpzhLcTGIfORMPtT.JGfOaxGMMubjxaprhTWpWgtvAPZ();
				num = 899807939;
				continue;
			case 6:
				if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num2] != null)
				{
					SECqOtxIJCMtDAXMpkZHtbqiXBU[num2].JGfOaxGMMubjxaprhTWpWgtvAPZ();
					num = 899807941;
					continue;
				}
				goto case 2;
			case 2:
				num2++;
				num = 899807947;
				continue;
			case 0:
				num2 = 0;
				num = 899807947;
				continue;
			case 10:
				if (SCWnpyELlKxxAXOzoQpSqiyTdPf != null)
				{
					SCWnpyELlKxxAXOzoQpSqiyTdPf.Dispose();
					num = 899807938;
					continue;
				}
				goto case 5;
			case 9:
				goto IL_014c;
			case 11:
				return;
			}
			break;
			IL_006d:
			int num3;
			if (num2 < count)
			{
				num = 899807937;
				num3 = num;
			}
			else
			{
				num = 899807942;
				num3 = num;
			}
		}
		goto IL_000b;
		IL_0054:
		int num4;
		if (NTvkIjdRvKUBEYGNJZoXqfbatvi == null)
		{
			num = 899807949;
			num4 = num;
		}
		else
		{
			num = 899807936;
			num4 = num;
		}
		goto IL_0010;
		IL_0097:
		if (iIGFCPdeKbcstfqznMqAUVSlgBRa != null)
		{
			iIGFCPdeKbcstfqznMqAUVSlgBRa.JGfOaxGMMubjxaprhTWpWgtvAPZ();
			num = 899807950;
			goto IL_0010;
		}
		goto IL_014c;
		IL_014c:
		if (SECqOtxIJCMtDAXMpkZHtbqiXBU != null)
		{
			count = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
			num = 899807943;
			goto IL_0010;
		}
		goto IL_0054;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OtrNTBJIBbQldvImDmKCAqMRnke;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 991948743;
			while (true)
			{
				switch (num2 ^ 0x3B1FEFC5)
				{
				case 0:
					num2 = 991948742;
					continue;
				case 3:
					break;
				case 2:
				{
					int num3;
					if (num < lTHFykxDvdBXxFWZTYErzFFjdVX)
					{
						num2 = 991948737;
						num3 = num2;
					}
					else
					{
						num2 = 991948740;
						num3 = num2;
					}
					continue;
				}
				case 4:
					if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num].inputManagerId == inputManagerId)
					{
						SECqOtxIJCMtDAXMpkZHtbqiXBU[num].FillData(data);
						return;
					}
					goto case 5;
				case 5:
					num++;
					num2 = 991948743;
					continue;
				default:
					Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		oAncdCDeuarlyAVWrkNljduAgRv.SystemDeviceConnected();
		mZVnLimgafFHWakbbRpLWuLRjTSi = true;
		while (true)
		{
			int num = -1451971588;
			while (true)
			{
				switch (num ^ -1451971587)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (bkNLtfWXdHFQHoTBrLDLPyyblom)
					{
						bwJraMvCEoaGCssXuTteIKcJrpq.Start();
						num = -1451971587;
						continue;
					}
					goto case 0;
				case 0:
				{
					int num2;
					if (_SystemDeviceConnectedEvent == null)
					{
						num = -1451971591;
						num2 = num;
					}
					else
					{
						num = -1451971586;
						num2 = num;
					}
					continue;
				}
				case 3:
					_SystemDeviceConnectedEvent();
					num = -1451971591;
					continue;
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
		oAncdCDeuarlyAVWrkNljduAgRv.SystemDeviceDisconnected();
		mZVnLimgafFHWakbbRpLWuLRjTSi = true;
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			bwJraMvCEoaGCssXuTteIKcJrpq.Start();
			goto IL_0025;
		}
		goto IL_0043;
		IL_0043:
		int num;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
			num = -124883433;
			goto IL_002a;
		}
		return;
		IL_0025:
		num = -124883436;
		goto IL_002a;
		IL_002a:
		switch (num ^ -124883435)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_0043;
		case 2:
			return;
		}
		goto IL_0025;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool bkNLtfWXdHFQHoTBrLDLPyyblom2 = bkNLtfWXdHFQHoTBrLDLPyyblom;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return SCWnpyELlKxxAXOzoQpSqiyTdPf;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return NTvkIjdRvKUBEYGNJZoXqfbatvi;
	}

	public void FVaZVUBSPSViBJbyDLCcalwWIzS(WaaxNiwDiJyoSDhaNWpIFQyxNxt P_0, HGFgPbhAwCdweRprtBxHHvdBSxd P_1)
	{
	}

	private void apaayfodvIoMOBTmDElQhcNkElT()
	{
		if (vyWIGRlrOSwEAfybgEcTHDgPgON == 0)
		{
			return;
		}
		while (true)
		{
			int num;
			if (iIGFCPdeKbcstfqznMqAUVSlgBRa.isRunning)
			{
				int num2;
				if (!iIGFCPdeKbcstfqznMqAUVSlgBRa.xRKBBblbOUOOMSzhwnDVTLoUIDwi())
				{
					num = -1723537205;
					num2 = num;
				}
				else
				{
					num = -1723537207;
					num2 = num;
				}
				goto IL_000e;
			}
			goto IL_00b4;
			IL_00b4:
			if (!bwJraMvCEoaGCssXuTteIKcJrpq.running)
			{
				bwJraMvCEoaGCssXuTteIKcJrpq.Start();
				break;
			}
			goto IL_0124;
			IL_000e:
			while (true)
			{
				switch (num ^ -1723537202)
				{
				case 0:
					num = -1723537206;
					continue;
				default:
					return;
				case 9:
					return;
				case 6:
					bwJraMvCEoaGCssXuTteIKcJrpq.Start();
					return;
				case 4:
					break;
				case 1:
					goto IL_0093;
				case 2:
					goto IL_00b4;
				case 10:
					if (iIGFCPdeKbcstfqznMqAUVSlgBRa.result)
					{
						mZVnLimgafFHWakbbRpLWuLRjTSi = true;
						num = -1723537208;
						continue;
					}
					goto case 6;
				case 5:
					return;
				case 7:
					goto IL_0103;
				case 3:
					goto IL_0124;
				case 8:
					return;
				}
				break;
				IL_0103:
				int num3;
				if (!bwJraMvCEoaGCssXuTteIKcJrpq.running)
				{
					num = -1723537201;
					num3 = num;
				}
				else
				{
					num = -1723537209;
					num3 = num;
				}
				continue;
				IL_0093:
				int num4;
				if (!xDdQXMmOyKgEpzhLcTGIfORMPtT.isRunning)
				{
					num = -1723537212;
					num4 = num;
				}
				else
				{
					num = -1723537209;
					num4 = num;
				}
			}
			continue;
			IL_0124:
			if (bwJraMvCEoaGCssXuTteIKcJrpq.Update())
			{
				iIGFCPdeKbcstfqznMqAUVSlgBRa.SFnUlcdGONKjYCbrEBAjYDBcYmz();
				num = -1723537210;
				goto IL_000e;
			}
			break;
		}
	}

	private void IuJWHOMhNPSovTnENyBCQBmofkX()
	{
		IuJWHOMhNPSovTnENyBCQBmofkX(PWLFJcXWTejoUdOvTcDfHEVflpW());
	}

	private void IuJWHOMhNPSovTnENyBCQBmofkX(IList<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_0)
	{
		int num = 0;
		List<CQqdgMSBwubrhVugChMjQReeGmRd> sECqOtxIJCMtDAXMpkZHtbqiXBU = SECqOtxIJCMtDAXMpkZHtbqiXBU;
		int num2 = lTHFykxDvdBXxFWZTYErzFFjdVX;
		SECqOtxIJCMtDAXMpkZHtbqiXBU = new List<CQqdgMSBwubrhVugChMjQReeGmRd>();
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		int num4 = default(int);
		int num6 = default(int);
		IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = default(IQFNbAfLsEWvVnPpdRQbxxyYJpW);
		List<CQqdgMSBwubrhVugChMjQReeGmRd> list = default(List<CQqdgMSBwubrhVugChMjQReeGmRd>);
		int count = default(int);
		int num9 = default(int);
		while (true)
		{
			int num3 = 1062771967;
			while (true)
			{
				switch (num3 ^ 0x3F589CF6)
				{
				case 6:
					break;
				case 12:
					SECqOtxIJCMtDAXMpkZHtbqiXBU.Add(cQqdgMSBwubrhVugChMjQReeGmRd);
					num++;
					num3 = 1062771963;
					continue;
				case 17:
					num4++;
					num3 = 1062771950;
					continue;
				case 15:
					num4 = 0;
					num3 = 1062771950;
					continue;
				case 14:
					num6--;
					num3 = 1062771955;
					continue;
				case 16:
					num6 = num2 - 1;
					num3 = 1062771955;
					continue;
				case 23:
					if (vyWIGRlrOSwEAfybgEcTHDgPgON == 0)
					{
						iIGFCPdeKbcstfqznMqAUVSlgBRa.fWzuAFjFXxdRoqxypOAIFkBEHOX();
						num3 = 1062771957;
						continue;
					}
					goto case 3;
				case 8:
					cQqdgMSBwubrhVugChMjQReeGmRd = new CQqdgMSBwubrhVugChMjQReeGmRd(iQFNbAfLsEWvVnPpdRQbxxyYJpW, iQFNbAfLsEWvVnPpdRQbxxyYJpW.DeviceType, lvntcpgdZsSbabccpIcfMpTzYYr);
					num3 = 1062771959;
					continue;
				case 18:
					if (!sECqOtxIJCMtDAXMpkZHtbqiXBU[num6].IsValid)
					{
						list.Add(sECqOtxIJCMtDAXMpkZHtbqiXBU[num6]);
						sECqOtxIJCMtDAXMpkZHtbqiXBU.RemoveAt(num6);
						num3 = 1062771960;
						continue;
					}
					goto case 14;
				case 9:
					vyWIGRlrOSwEAfybgEcTHDgPgON = 0;
					list = new List<CQqdgMSBwubrhVugChMjQReeGmRd>();
					num3 = 1062771942;
					continue;
				case 3:
					lTHFykxDvdBXxFWZTYErzFFjdVX = num;
					KlUGOAHUqlIJiIxVnahEcgteyqda(num2, num, sECqOtxIJCMtDAXMpkZHtbqiXBU, SECqOtxIJCMtDAXMpkZHtbqiXBU);
					num3 = 1062771961;
					continue;
				case 7:
				{
					int num8;
					if (sECqOtxIJCMtDAXMpkZHtbqiXBU[num6] != null)
					{
						num3 = 1062771940;
						num8 = num3;
					}
					else
					{
						num3 = 1062771960;
						num8 = num3;
					}
					continue;
				}
				case 5:
					if (num6 < 0)
					{
						num2 = ((sECqOtxIJCMtDAXMpkZHtbqiXBU != null) ? sECqOtxIJCMtDAXMpkZHtbqiXBU.Count : 0);
						count = P_0.Count;
						num9 = 0;
						num3 = 1062771936;
						continue;
					}
					goto case 7;
				case 1:
					cQqdgMSBwubrhVugChMjQReeGmRd.mtlDBDFXTzxHqeXjvCJbhGtTMUCC = iQFNbAfLsEWvVnPpdRQbxxyYJpW.InstanceGuid;
					cQqdgMSBwubrhVugChMjQReeGmRd.aQyubnFZjhaxoHtWxfehAEYaFOR = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ProductName;
					cQqdgMSBwubrhVugChMjQReeGmRd.SgtdGZiZKfxrYfEaONXeCdMIqIsz = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ProductName;
					cQqdgMSBwubrhVugChMjQReeGmRd.eTlTTlBmuxCORrngMaNsxFSpDyMi = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ProductGuid;
					cQqdgMSBwubrhVugChMjQReeGmRd.rFChCpBSHUoiIZbKWfsTCHUdRna = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ProductId;
					cQqdgMSBwubrhVugChMjQReeGmRd.PbwglKnIRKBGqGPSCbbymWhNwoO = iQFNbAfLsEWvVnPpdRQbxxyYJpW.VendorId;
					cQqdgMSBwubrhVugChMjQReeGmRd.iERVPkhRheIKptTuTmWgWiTZGxm = iQFNbAfLsEWvVnPpdRQbxxyYJpW.JoystickId;
					num3 = 1062771939;
					continue;
				case 22:
					num3 = 1062771964;
					continue;
				case 2:
				{
					int num11;
					if (_UpdateControllerInfoEvent == null)
					{
						num3 = 1062771943;
						num11 = num3;
					}
					else
					{
						num3 = 1062771938;
						num11 = num3;
					}
					continue;
				}
				case 19:
					if (P_0[num9] != null)
					{
						iQFNbAfLsEWvVnPpdRQbxxyYJpW = P_0[num9];
						num3 = 1062771965;
						continue;
					}
					goto case 0;
				case 10:
				{
					int num10;
					if (num9 < count)
					{
						num3 = 1062771941;
						num10 = num3;
					}
					else
					{
						num3 = 1062771937;
						num10 = num3;
					}
					continue;
				}
				case 4:
					vyWIGRlrOSwEAfybgEcTHDgPgON++;
					num3 = 1062771958;
					continue;
				case 13:
				{
					int num7;
					if (cQqdgMSBwubrhVugChMjQReeGmRd.HUFFKhqkxcIVKhtrxspNbGBrTdG)
					{
						num3 = 1062771954;
						num7 = num3;
					}
					else
					{
						num3 = 1062771958;
						num7 = num3;
					}
					continue;
				}
				case 20:
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(SECqOtxIJCMtDAXMpkZHtbqiXBU[num4]));
					num3 = 1062771943;
					continue;
				case 0:
					num9++;
					num3 = 1062771964;
					continue;
				case 11:
				{
					int num5;
					if (iQFNbAfLsEWvVnPpdRQbxxyYJpW != null)
					{
						num3 = 1062771966;
						num5 = num3;
					}
					else
					{
						num3 = 1062771958;
						num5 = num3;
					}
					continue;
				}
				case 21:
					cQqdgMSBwubrhVugChMjQReeGmRd.dhEQLHuCYYGQwdehmJKXAJgttVWs = iQFNbAfLsEWvVnPpdRQbxxyYJpW.AxisCount;
					cQqdgMSBwubrhVugChMjQReeGmRd.aCdTArmyUaJIYSBpkbuJpDufgNGc = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ButtonCount;
					cQqdgMSBwubrhVugChMjQReeGmRd.JwvOuylcUYNAjPLMAAlyukWmToj = iQFNbAfLsEWvVnPpdRQbxxyYJpW.HatCount;
					cQqdgMSBwubrhVugChMjQReeGmRd.IEIpySejupFvUUEVIERJEkDtdcvv = false;
					cQqdgMSBwubrhVugChMjQReeGmRd.HUFFKhqkxcIVKhtrxspNbGBrTdG = iQFNbAfLsEWvVnPpdRQbxxyYJpW.IsBluetoothDevice;
					cQqdgMSBwubrhVugChMjQReeGmRd.ZYtBoPNuCmSlSLPglVVYiiIepKT = iQFNbAfLsEWvVnPpdRQbxxyYJpW.BluetoothDeviceName;
					cQqdgMSBwubrhVugChMjQReeGmRd.uyjBbcIhGzMpDSyGYNhGPPRoYdp = iQFNbAfLsEWvVnPpdRQbxxyYJpW.SupportsVibration;
					cQqdgMSBwubrhVugChMjQReeGmRd.tojPLGfGkimbIivokBFIzlnJQIx = iQFNbAfLsEWvVnPpdRQbxxyYJpW.VibrationMotorCount;
					cQqdgMSBwubrhVugChMjQReeGmRd.extension = iQFNbAfLsEWvVnPpdRQbxxyYJpW.ControllerExtension;
					iQFNbAfLsEWvVnPpdRQbxxyYJpW.Acquire();
					cQqdgMSBwubrhVugChMjQReeGmRd.qdrCNHHBSjMYElMPgHUagWNZcjH();
					num3 = 1062771962;
					continue;
				default:
					if (num4 >= num)
					{
						list.ForEach(delegate(CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd2)
						{
							rXhRyzhbQTbXDGmMixSdjNyJMsQm(cQqdgMSBwubrhVugChMjQReeGmRd2, false);
						});
						JtDrBjjubFXiGBlgRbdsfJusBoA(sECqOtxIJCMtDAXMpkZHtbqiXBU, SECqOtxIJCMtDAXMpkZHtbqiXBU, false);
						JtDrBjjubFXiGBlgRbdsfJusBoA(SECqOtxIJCMtDAXMpkZHtbqiXBU, sECqOtxIJCMtDAXMpkZHtbqiXBU, true);
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void nVcSLNPamegvZJFhMFHMKCYMWxY()
	{
		int num = 0;
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		while (true)
		{
			int num2 = 1317646163;
			while (true)
			{
				switch (num2 ^ 0x4E89AF56)
				{
				case 4:
					break;
				case 3:
					num++;
					num2 = 1317646167;
					continue;
				case 2:
					cQqdgMSBwubrhVugChMjQReeGmRd = SECqOtxIJCMtDAXMpkZHtbqiXBU[num];
					if (cQqdgMSBwubrhVugChMjQReeGmRd == null)
					{
						goto case 3;
					}
					if (ydtjoUaZMACQbAJqHjVabQJcAHgE)
					{
						int num3;
						if (cQqdgMSBwubrhVugChMjQReeGmRd.IEIpySejupFvUUEVIERJEkDtdcvv)
						{
							num2 = 1317646165;
							num3 = num2;
						}
						else
						{
							num2 = 1317646166;
							num3 = num2;
						}
						continue;
					}
					goto case 0;
				case 5:
					num2 = 1317646167;
					continue;
				case 0:
					cQqdgMSBwubrhVugChMjQReeGmRd.Update();
					num2 = 1317646165;
					continue;
				default:
					if (num >= lTHFykxDvdBXxFWZTYErzFFjdVX)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private bool IMlLKEcEdbfJWCtAPwVjQExfFyg(eLhSQQinbiEEdCMMucMDEndjKKNi P_0)
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

	private IList<IQFNbAfLsEWvVnPpdRQbxxyYJpW> PWLFJcXWTejoUdOvTcDfHEVflpW()
	{
		return oAncdCDeuarlyAVWrkNljduAgRv.GetJoysticks<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
	}

	private void KlUGOAHUqlIJiIxVnahEcgteyqda(int P_0, int P_1, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_2, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(CQqdgMSBwubrhVugChMjQReeGmRd.IQnVWhjqpLtmuLhORhWWdeggsnb);
			goto IL_001a;
		}
		goto IL_00ca;
		IL_007b:
		int num;
		bool flag = (byte)num != 0;
		int num2 = 603509225;
		goto IL_001f;
		IL_001a:
		num2 = 603509228;
		goto IL_001f;
		IL_001f:
		int num3 = default(int);
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		while (true)
		{
			switch (num2 ^ 0x23F8D1EE)
			{
			case 0:
				break;
			case 9:
				ILQRLaTXmQpdVwAsNdOarwOhzkQ(P_1, P_3, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW.pcWfOxYbvNCAItRmLAyYfYdvnxE);
				ILQRLaTXmQpdVwAsNdOarwOhzkQ(P_1, P_3, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW.JgYTOGxxNXCOjMYfJlJOWIFnveY);
				num3 = 0;
				num2 = 603509231;
				continue;
			case 4:
				goto IL_0074;
			case 8:
				num3++;
				num2 = 603509231;
				continue;
			case 3:
				goto IL_008e;
			case 7:
				if (flag)
				{
					ISWzZRbBIprIMKhUiHLkZfQuBhZ(P_1, P_3, P_0, P_2, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW.pcWfOxYbvNCAItRmLAyYfYdvnxE);
					ISWzZRbBIprIMKhUiHLkZfQuBhZ(P_1, P_3, P_0, P_2, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW.JgYTOGxxNXCOjMYfJlJOWIFnveY);
					num2 = 603509223;
					continue;
				}
				goto case 9;
			case 2:
				goto IL_00ca;
			case 6:
				cQqdgMSBwubrhVugChMjQReeGmRd = P_3[num3];
				num2 = 603509229;
				continue;
			case 5:
				if (cQqdgMSBwubrhVugChMjQReeGmRd.inputManagerId < 0)
				{
					cQqdgMSBwubrhVugChMjQReeGmRd.inputManagerId = jjcAdWSwmMiSHrtrbjSXvfBZBAz(P_3);
					cQqdgMSBwubrhVugChMjQReeGmRd.rewiredId = osCAPAIYOEZodlsEwtiFRgmwudTL();
					BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(cQqdgMSBwubrhVugChMjQReeGmRd);
					num2 = 603509222;
					continue;
				}
				goto case 8;
			default:
				if (num3 >= P_1)
				{
					P_3.Sort(CQqdgMSBwubrhVugChMjQReeGmRd.MkXapRSnnzwLWGXiQrUeZlhrOqE);
					return;
				}
				goto case 6;
			}
			break;
			IL_008e:
			int num4;
			if (cQqdgMSBwubrhVugChMjQReeGmRd != null)
			{
				num2 = 603509227;
				num4 = num2;
			}
			else
			{
				num2 = 603509222;
				num4 = num2;
			}
		}
		goto IL_001a;
		IL_00ca:
		if (P_0 <= 0)
		{
			num = 0;
			goto IL_007b;
		}
		num2 = 603509226;
		goto IL_001f;
		IL_0074:
		num = ((P_1 > 0) ? 1 : 0);
		goto IL_007b;
	}

	private void pEtCuzBvCgjYuRXCToAuDLQZmTbF(List<CQqdgMSBwubrhVugChMjQReeGmRd> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				int num3;
				if (num == P_1)
				{
					num2 = 1398526145;
					num3 = num2;
				}
				else
				{
					num2 = 1398526148;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x535BD0C5)
					{
					case 3:
						num2 = 1398526144;
						continue;
					case 5:
						break;
					case 0:
						P_0[num].inputManagerId = -1;
						num2 = 1398526145;
						continue;
					case 4:
						num++;
						num2 = 1398526151;
						continue;
					case 1:
						if (P_0[num] == null)
						{
							goto case 4;
						}
						goto IL_0075;
					default:
						goto end_IL_0038;
					}
					break;
					IL_0075:
					int num4;
					if (P_0[num].inputManagerId != P_2)
					{
						num2 = 1398526145;
						num4 = num2;
					}
					else
					{
						num2 = 1398526149;
						num4 = num2;
					}
				}
				continue;
				end_IL_0038:
				break;
			}
		}
	}

	private bool bxYRVPNBMeqzOlxWcuXPWWCIBKj(List<CQqdgMSBwubrhVugChMjQReeGmRd> P_0, int P_1)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -1558884371;
			while (true)
			{
				switch (num ^ -1558884375)
				{
				case 3:
					break;
				case 4:
					num2 = 0;
					num = -1558884376;
					continue;
				case 0:
					if (P_0[num2] != null && P_0[num2].inputManagerId == P_1)
					{
						return false;
					}
					num2++;
					num = -1558884373;
					continue;
				case 1:
					num = -1558884373;
					continue;
				default:
					if (num2 >= count)
					{
						return true;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private int jjcAdWSwmMiSHrtrbjSXvfBZBAz(List<CQqdgMSBwubrhVugChMjQReeGmRd> P_0)
	{
		int num = 0;
		int num3 = default(int);
		int count = default(int);
		bool flag = default(bool);
		while (true)
		{
			int num2 = -65241032;
			while (true)
			{
				switch (num2 ^ -65241031)
				{
				case 6:
					break;
				case 7:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = -65241029;
						num4 = num2;
					}
					else
					{
						num2 = -65241030;
						num4 = num2;
					}
					continue;
				}
				case 4:
					count = P_0.Count;
					num2 = -65241031;
					continue;
				case 5:
					num3++;
					num2 = -65241026;
					continue;
				case 0:
					num3 = 0;
					num2 = -65241026;
					continue;
				case 1:
					flag = false;
					num2 = -65241027;
					continue;
				case 3:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -65241029;
						continue;
					}
					goto case 5;
				default:
					if (!flag)
					{
						return num;
					}
					num++;
					goto case 1;
				}
				break;
			}
		}
	}

	private bool hnPTilELGLdIFJbfnUgVEfTUyAY(List<CQqdgMSBwubrhVugChMjQReeGmRd> P_0, int P_1)
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
				int num2 = 679191259;
				while (true)
				{
					switch (num2 ^ 0x287BA2D9)
					{
					case 0:
						num2 = 679191256;
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

	private void ISWzZRbBIprIMKhUiHLkZfQuBhZ(int P_0, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_1, int P_2, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_3, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW P_4)
	{
		int num = ((P_4 != nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW.pcWfOxYbvNCAItRmLAyYfYdvnxE) ? 1 : 2);
		int num2 = 0;
		int num5 = default(int);
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd2 = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		while (num2 < P_0)
		{
			while (true)
			{
				CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = P_1[num2];
				int num3;
				int num4;
				if (cQqdgMSBwubrhVugChMjQReeGmRd != null)
				{
					num3 = -746720324;
					num4 = num3;
				}
				else
				{
					num3 = -746720322;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -746720321)
					{
					case 0:
						num3 = -746720328;
						continue;
					case 2:
						num5++;
						num3 = -746720325;
						continue;
					case 5:
						if (!hnPTilELGLdIFJbfnUgVEfTUyAY(P_1, cQqdgMSBwubrhVugChMjQReeGmRd2.rewiredId) && cQqdgMSBwubrhVugChMjQReeGmRd.QJuTPVbZPhckxeVMgmaDORJltri(cQqdgMSBwubrhVugChMjQReeGmRd2) >= num)
						{
							cQqdgMSBwubrhVugChMjQReeGmRd.sHFWIJnFHmHJYIoFEDYPzPHrHZM(cQqdgMSBwubrhVugChMjQReeGmRd2);
							BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(cQqdgMSBwubrhVugChMjQReeGmRd);
							num3 = -746720323;
							continue;
						}
						goto case 2;
					case 1:
						num2++;
						num3 = -746720330;
						continue;
					case 7:
						break;
					case 4:
						goto IL_00bb;
					case 8:
						goto IL_00d3;
					case 6:
						num3 = -746720325;
						continue;
					case 3:
						if (cQqdgMSBwubrhVugChMjQReeGmRd.inputManagerId < 0)
						{
							num5 = 0;
							num3 = -746720327;
							continue;
						}
						goto case 1;
					default:
						goto end_IL_009c;
					}
					break;
					IL_00d3:
					cQqdgMSBwubrhVugChMjQReeGmRd2 = P_3[num5];
					int num6;
					if (cQqdgMSBwubrhVugChMjQReeGmRd2 != null)
					{
						num3 = -746720326;
						num6 = num3;
					}
					else
					{
						num3 = -746720323;
						num6 = num3;
					}
					continue;
					IL_00bb:
					int num7;
					if (num5 < P_2)
					{
						num3 = -746720329;
						num7 = num3;
					}
					else
					{
						num3 = -746720322;
						num7 = num3;
					}
				}
				continue;
				end_IL_009c:
				break;
			}
		}
	}

	private void ILQRLaTXmQpdVwAsNdOarwOhzkQ(int P_0, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_1, nhnmSGeBkAttkmfxmxGlDeglhSGe.CxzhajiaPSyLynbAMiUXPxiPCHW P_2)
	{
		int num = 0;
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		int num3 = default(int);
		nhnmSGeBkAttkmfxmxGlDeglhSGe.jTQpvKbMiIWhEITSYjSfdPlUyzL jTQpvKbMiIWhEITSYjSfdPlUyzL = default(nhnmSGeBkAttkmfxmxGlDeglhSGe.jTQpvKbMiIWhEITSYjSfdPlUyzL);
		while (true)
		{
			int num2 = 512569852;
			while (true)
			{
				switch (num2 ^ 0x1E8D31F8)
				{
				case 6:
					break;
				default:
					return;
				case 9:
				{
					int num5;
					if (cQqdgMSBwubrhVugChMjQReeGmRd.inputManagerId >= 0)
					{
						num2 = 512569853;
						num5 = num2;
					}
					else
					{
						num2 = 512569850;
						num5 = num2;
					}
					continue;
				}
				case 1:
				{
					cQqdgMSBwubrhVugChMjQReeGmRd = P_1[num];
					int num4;
					if (cQqdgMSBwubrhVugChMjQReeGmRd != null)
					{
						num2 = 512569841;
						num4 = num2;
					}
					else
					{
						num2 = 512569853;
						num4 = num2;
					}
					continue;
				}
				case 3:
					cQqdgMSBwubrhVugChMjQReeGmRd.inputManagerId = num3;
					num2 = 512569855;
					continue;
				case 4:
					num2 = 512569840;
					continue;
				case 8:
				{
					int num6;
					if (num < P_0)
					{
						num2 = 512569849;
						num6 = num2;
					}
					else
					{
						num2 = 512569848;
						num6 = num2;
					}
					continue;
				}
				case 2:
					jTQpvKbMiIWhEITSYjSfdPlUyzL = BhZbSIqTJUuvrHhjvLiLwhtaXiV.GAYuJaWQWiVlljmcwLCVJqAlvzZ(cQqdgMSBwubrhVugChMjQReeGmRd, P_2);
					if (jTQpvKbMiIWhEITSYjSfdPlUyzL != null && !hnPTilELGLdIFJbfnUgVEfTUyAY(P_1, jTQpvKbMiIWhEITSYjSfdPlUyzL.OHBcezjWhuCjOisuXXaxDLGlnPLC))
					{
						num3 = jTQpvKbMiIWhEITSYjSfdPlUyzL.WppCCSIJiYbWggCDNrMGswGEsUzA;
						if (num3 >= 0)
						{
							if (!bxYRVPNBMeqzOlxWcuXPWWCIBKj(P_1, num3))
							{
								num3 = (jTQpvKbMiIWhEITSYjSfdPlUyzL.WppCCSIJiYbWggCDNrMGswGEsUzA = jjcAdWSwmMiSHrtrbjSXvfBZBAz(P_1));
								num2 = 512569851;
								continue;
							}
							goto case 3;
						}
					}
					goto case 5;
				case 7:
					cQqdgMSBwubrhVugChMjQReeGmRd.rewiredId = jTQpvKbMiIWhEITSYjSfdPlUyzL.OHBcezjWhuCjOisuXXaxDLGlnPLC;
					BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(cQqdgMSBwubrhVugChMjQReeGmRd);
					num2 = 512569853;
					continue;
				case 5:
					num++;
					num2 = 512569840;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private void jONkrzccOBAfjAzxVQUAFDRBogb()
	{
		if (mZVnLimgafFHWakbbRpLWuLRjTSi)
		{
			zPWkECTyTaFCiNcvQqkXUhoLuag();
			goto IL_000e;
		}
		goto IL_0030;
		IL_0030:
		int num;
		if (bkNLtfWXdHFQHoTBrLDLPyyblom && xDdQXMmOyKgEpzhLcTGIfORMPtT.isRunning)
		{
			int num2;
			if (xDdQXMmOyKgEpzhLcTGIfORMPtT.xRKBBblbOUOOMSzhwnDVTLoUIDwi())
			{
				num = 1210773123;
				num2 = num;
			}
			else
			{
				num = 1210773121;
				num2 = num;
			}
			goto IL_0013;
		}
		return;
		IL_000e:
		num = 1210773122;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ 0x482AEE83)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0030;
			case 0:
				IVZQXBEcnUfnrWypyWboQvGXMjb();
				num = 1210773121;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_000e;
	}

	private void zPWkECTyTaFCiNcvQqkXUhoLuag()
	{
		mZVnLimgafFHWakbbRpLWuLRjTSi = false;
		if (xDdQXMmOyKgEpzhLcTGIfORMPtT.isRunning)
		{
			return;
		}
		while (true)
		{
			oAncdCDeuarlyAVWrkNljduAgRv.DMfhdqyulvaioEsLYapLXkOfYyU();
			xDdQXMmOyKgEpzhLcTGIfORMPtT.SFnUlcdGONKjYCbrEBAjYDBcYmz();
			int num = 799428170;
			while (true)
			{
				switch (num ^ 0x2FA64E4B)
				{
				case 0:
					goto IL_0015;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_0015:
				num = 799428169;
			}
		}
	}

	private void IVZQXBEcnUfnrWypyWboQvGXMjb()
	{
		oAncdCDeuarlyAVWrkNljduAgRv.eqvmwAShmUUBmsObQvgMthAoiBP();
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return;
		}
		IList<IQFNbAfLsEWvVnPpdRQbxxyYJpW> list = PWLFJcXWTejoUdOvTcDfHEVflpW();
		while (true)
		{
			int num = -1852034020;
			while (true)
			{
				switch (num ^ -1852034019)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (pmAEuyuEmCBiquTqaFnfwdiCMuU(list))
					{
						goto IL_0041;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_0041:
				IuJWHOMhNPSovTnENyBCQBmofkX(list);
				num = -1852034019;
			}
		}
	}

	private bool pmAEuyuEmCBiquTqaFnfwdiCMuU(IList<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_0)
	{
		int num = 0;
		int count = default(int);
		int num2 = default(int);
		int count2 = default(int);
		int num4 = default(int);
		while (true)
		{
			IL_00f3:
			int num3;
			if (num >= SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
			{
				count = P_0.Count;
				num2 = 0;
				num3 = 722696811;
				goto IL_000c;
			}
			goto IL_0040;
			IL_000c:
			while (true)
			{
				switch (num3 ^ 0x2B137A6B)
				{
				case 7:
					num3 = 722696813;
					continue;
				case 6:
					break;
				case 0:
					num3 = 722696803;
					continue;
				case 5:
					goto IL_0075;
				case 8:
					if (num2 >= count)
					{
						count2 = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
						num4 = 0;
						num3 = 722696809;
						continue;
					}
					goto IL_0075;
				case 1:
					goto IL_00bf;
				case 3:
					goto IL_00f3;
				case 4:
					return true;
				default:
					if (num4 >= count2)
					{
						return false;
					}
					goto IL_00bf;
				}
				break;
				IL_00bf:
				if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num4] != null && !XrfbUEUpNCHSwbQMOmbXqaVXDkCt(P_0, SECqOtxIJCMtDAXMpkZHtbqiXBU[num4].instanceGuid))
				{
					num3 = 722696815;
					continue;
				}
				num4++;
				num3 = 722696809;
				continue;
				IL_0075:
				if (P_0[num2] != null && !saptnzWhriuFUwfptyJbkFjzymv(P_0[num2].InstanceGuid))
				{
					return true;
				}
				num2++;
				num3 = 722696803;
			}
			goto IL_0040;
			IL_0040:
			if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num] != null && !SECqOtxIJCMtDAXMpkZHtbqiXBU[num].IsValid)
			{
				break;
			}
			num++;
			num3 = 722696808;
			goto IL_000c;
		}
		return true;
	}

	private bool saptnzWhriuFUwfptyJbkFjzymv(Guid P_0)
	{
		int count = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num] != null && SECqOtxIJCMtDAXMpkZHtbqiXBU[num].instanceGuid == P_0)
				{
					num2 = 242013208;
				}
				else
				{
					num++;
					num2 = 242013210;
				}
				while (true)
				{
					switch (num2 ^ 0xE6CD418)
					{
					case 3:
						num2 = 242013209;
						continue;
					case 1:
						break;
					case 0:
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

	private bool XrfbUEUpNCHSwbQMOmbXqaVXDkCt(IList<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_0, Guid P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2 = 641269342;
			while (true)
			{
				switch (num2 ^ 0x2638FE5F)
				{
				case 3:
					break;
				case 2:
					return true;
				case 0:
					if (P_0[num] == null || !(P_0[num].InstanceGuid == P_1))
					{
						num++;
						num2 = 641269339;
					}
					else
					{
						num2 = 641269341;
					}
					continue;
				case 1:
					num2 = 641269339;
					continue;
				default:
					if (num >= count)
					{
						return false;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	private void JtDrBjjubFXiGBlgRbdsfJusBoA(List<CQqdgMSBwubrhVugChMjQReeGmRd> P_0, List<CQqdgMSBwubrhVugChMjQReeGmRd> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num5 = default(int);
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd2 = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		CQqdgMSBwubrhVugChMjQReeGmRd cQqdgMSBwubrhVugChMjQReeGmRd = default(CQqdgMSBwubrhVugChMjQReeGmRd);
		bool flag = default(bool);
		while (true)
		{
			int num = ((P_0 != null) ? P_0.Count : 0);
			int num2 = ((P_1 != null) ? P_1.Count : 0);
			int num3 = 0;
			int num4 = 349862178;
			while (true)
			{
				switch (num4 ^ 0x14DA7929)
				{
				case 15:
					num4 = 349862184;
					continue;
				default:
					return;
				case 2:
				{
					int num10;
					if (num5 >= num2)
					{
						num4 = 349862188;
						num10 = num4;
					}
					else
					{
						num4 = 349862189;
						num10 = num4;
					}
					continue;
				}
				case 14:
				{
					int num7;
					if (cQqdgMSBwubrhVugChMjQReeGmRd2.instanceGuid == cQqdgMSBwubrhVugChMjQReeGmRd.instanceGuid)
					{
						num4 = 349862177;
						num7 = num4;
					}
					else
					{
						num4 = 349862191;
						num7 = num4;
					}
					continue;
				}
				case 7:
					rXhRyzhbQTbXDGmMixSdjNyJMsQm(P_0[num3], P_2);
					num4 = 349862176;
					continue;
				case 9:
					num3++;
					num4 = 349862186;
					continue;
				case 8:
					flag = true;
					num4 = 349862188;
					continue;
				case 13:
				{
					flag = false;
					int num8;
					if (P_1 != null)
					{
						num4 = 349862179;
						num8 = num4;
					}
					else
					{
						num4 = 349862188;
						num8 = num4;
					}
					continue;
				}
				case 3:
				{
					int num12;
					if (num3 >= num)
					{
						num4 = 349862181;
						num12 = num4;
					}
					else
					{
						num4 = 349862185;
						num12 = num4;
					}
					continue;
				}
				case 5:
				{
					int num11;
					if (flag)
					{
						num4 = 349862176;
						num11 = num4;
					}
					else
					{
						num4 = 349862190;
						num11 = num4;
					}
					continue;
				}
				case 6:
					num5++;
					num4 = 349862187;
					continue;
				case 1:
					break;
				case 0:
				{
					cQqdgMSBwubrhVugChMjQReeGmRd2 = P_0[num3];
					int num9;
					if (cQqdgMSBwubrhVugChMjQReeGmRd2 != null)
					{
						num4 = 349862180;
						num9 = num4;
					}
					else
					{
						num4 = 349862176;
						num9 = num4;
					}
					continue;
				}
				case 10:
					num5 = 0;
					num4 = 349862187;
					continue;
				case 4:
				{
					cQqdgMSBwubrhVugChMjQReeGmRd = P_1[num5];
					int num6;
					if (cQqdgMSBwubrhVugChMjQReeGmRd == null)
					{
						num4 = 349862191;
						num6 = num4;
					}
					else
					{
						num4 = 349862183;
						num6 = num4;
					}
					continue;
				}
				case 11:
					num4 = 349862186;
					continue;
				case 12:
					return;
				}
				break;
			}
		}
	}

	private void rXhRyzhbQTbXDGmMixSdjNyJMsQm(CQqdgMSBwubrhVugChMjQReeGmRd P_0, bool P_1)
	{
		if (P_1)
		{
			goto IL_0003;
		}
		goto IL_0046;
		IL_0003:
		int num = 232201283;
		goto IL_0008;
		IL_0008:
		switch (num ^ 0xDD71C42)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
			return;
		case 0:
			goto IL_0046;
		case 2:
			return;
		}
		goto IL_0003;
		IL_0046:
		if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			num = 232201280;
			goto IL_0008;
		}
	}

	[Conditional("DEBUGTHIS")]
	private void LzexmkpZFbTHPEqjpzBoMdWJgWnE(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void gValVgGXiSaEFwVvdwqedelzbPv(CQqdgMSBwubrhVugChMjQReeGmRd P_0)
	{
		rXhRyzhbQTbXDGmMixSdjNyJMsQm(P_0, false);
	}
}
