using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.DirectInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class fXpZHAKkyykjjdntipjmCAIqJMD : PlatformInputManager, kxzXTdiJorHKVUHhoBvSNMIscik
{
	private class dIYfxShIDrIIjihOcmVToKsXwFAE : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int LHBzfOUukEAojNhzqhOUdcqBelx;

		private int QSgOYisLlLVufpwxLNKaoIEBiyFd;

		public Guid FHAzoTozCrisunLDoLyimqNbdex;

		public string DHGYnLayswGyOaWIxJecDoLngmm;

		public readonly JEiBJdqVetCaYhzGImdkvLHTeQyH kYVEkOHTXBhxnrAeWMuOTcRgNeH;

		public rrkiWNHnEkzBYEXAvbDAWsEtjKd eMSAOLjJyVqyGYNCqvthQlWRDYcs;

		public ofeqpRsjofXSwYwacxFrGdeWwcg ocqEYLgpYeVchwgaiKyLlHKhmSeI;

		public string aQyubnFZjhaxoHtWxfehAEYaFOR;

		public string SgtdGZiZKfxrYfEaONXeCdMIqIsz;

		public int rFChCpBSHUoiIZbKWfsTCHUdRna;

		public Guid mtlDBDFXTzxHqeXjvCJbhGtTMUCC;

		public Guid eTlTTlBmuxCORrngMaNsxFSpDyMi;

		public Guid AIefUprvkNeEvLSsrampirFfHMzU;

		public int iERVPkhRheIKptTuTmWgWiTZGxm;

		public bool HUFFKhqkxcIVKhtrxspNbGBrTdG;

		public string ZYtBoPNuCmSlSLPglVVYiiIepKT;

		public string ofHFJIxpUZEkaCUKTOBHGzIRSqW;

		public int gwfrHmNqxmYlnzynBGWAgujDDrf;

		public int rqeFUUCoNDfDgMOxuCDGnyLQlXi;

		public int dhEQLHuCYYGQwdehmJKXAJgttVWs;

		public int aCdTArmyUaJIYSBpkbuJpDufgNGc;

		public int JwvOuylcUYNAjPLMAAlyukWmToj;

		public bool IEIpySejupFvUUEVIERJEkDtdcvv;

		private float[] HwRqYBlbrIoKtVDOMNmmVOGCrNt;

		private bool[] xrmDwADRXdFsenTurfwlUsqsAvb;

		private HardwareJoystickMap_InputManager XCAyIFRJbEWUeBcnVweevmqWqtw;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

		private bool cbEqXqyoXBYbIYeDgNacVLXtacu;

		private bool RZErYKzcoEvfMnhtHeFDeTWjAxp;

		private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

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
			get
			{
				return null;
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

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public dIYfxShIDrIIjihOcmVToKsXwFAE(JEiBJdqVetCaYhzGImdkvLHTeQyH sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH = sourceJoystick;
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			QSgOYisLlLVufpwxLNKaoIEBiyFd = -1;
			LHBzfOUukEAojNhzqhOUdcqBelx = -1;
		}

		public void qdrCNHHBSjMYElMPgHUagWNZcjH()
		{
			AIefUprvkNeEvLSsrampirFfHMzU = MiscTools.CreateGuidHashSHA1(SgtdGZiZKfxrYfEaONXeCdMIqIsz + eTlTTlBmuxCORrngMaNsxFSpDyMi);
			gwfrHmNqxmYlnzynBGWAgujDDrf = dhEQLHuCYYGQwdehmJKXAJgttVWs;
			while (true)
			{
				int num = -1906080474;
				while (true)
				{
					int num2;
					switch (num ^ -1906080473)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						rqeFUUCoNDfDgMOxuCDGnyLQlXi = aCdTArmyUaJIYSBpkbuJpDufgNGc + JwvOuylcUYNAjPLMAAlyukWmToj * 8;
						XCEcogOtFbmhupWduawPDMqkEjv();
						FHAzoTozCrisunLDoLyimqNbdex = XCAyIFRJbEWUeBcnVweevmqWqtw.hardwareMapIdentifier.guid;
						DHGYnLayswGyOaWIxJecDoLngmm = XCAyIFRJbEWUeBcnVweevmqWqtw.controllerName;
						num2 = ((FHAzoTozCrisunLDoLyimqNbdex == Guid.Empty) ? 1 : 0);
						goto IL_00a7;
					case 2:
						return;
					}
					break;
					IL_00a7:
					cbEqXqyoXBYbIYeDgNacVLXtacu = (byte)num2 != 0;
					HwRqYBlbrIoKtVDOMNmmVOGCrNt = new float[gwfrHmNqxmYlnzynBGWAgujDDrf];
					xrmDwADRXdFsenTurfwlUsqsAvb = new bool[rqeFUUCoNDfDgMOxuCDGnyLQlXi];
					kYVEkOHTXBhxnrAeWMuOTcRgNeH.OPrDnVhLcontoTptCznHaDrwNsAh();
					Update();
					num = -1906080475;
				}
			}
		}

		public void sHFWIJnFHmHJYIoFEDYPzPHrHZM(dIYfxShIDrIIjihOcmVToKsXwFAE P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				QSgOYisLlLVufpwxLNKaoIEBiyFd = P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd;
				LHBzfOUukEAojNhzqhOUdcqBelx = P_0.LHBzfOUukEAojNhzqhOUdcqBelx;
				int num = 0;
				int num2 = 2116408288;
				while (true)
				{
					switch (num2 ^ 0x7E25D3E3)
					{
					case 2:
						num2 = 2116408290;
						continue;
					case 7:
						num3++;
						num2 = 2116408299;
						continue;
					case 4:
						num++;
						num2 = 2116408288;
						continue;
					case 5:
						xrmDwADRXdFsenTurfwlUsqsAvb[num] = P_0.xrmDwADRXdFsenTurfwlUsqsAvb[num];
						num2 = 2116408295;
						continue;
					case 0:
						HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3] = P_0.HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3];
						num2 = 2116408292;
						continue;
					case 1:
						break;
					case 3:
						if (num >= MathTools.Min(xrmDwADRXdFsenTurfwlUsqsAvb.Length, P_0.xrmDwADRXdFsenTurfwlUsqsAvb.Length))
						{
							num3 = 0;
							num2 = 2116408299;
							continue;
						}
						goto case 5;
					case 8:
					{
						int num4;
						if (num3 < MathTools.Min(HwRqYBlbrIoKtVDOMNmmVOGCrNt.Length, P_0.HwRqYBlbrIoKtVDOMNmmVOGCrNt.Length))
						{
							num2 = 2116408291;
							num4 = num2;
						}
						else
						{
							num2 = 2116408293;
							num4 = num2;
						}
						continue;
					}
					default:
						RZErYKzcoEvfMnhtHeFDeTWjAxp = P_0.RZErYKzcoEvfMnhtHeFDeTWjAxp;
						kYVEkOHTXBhxnrAeWMuOTcRgNeH.sHFWIJnFHmHJYIoFEDYPzPHrHZM(P_0.kYVEkOHTXBhxnrAeWMuOTcRgNeH);
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.WRFQiHBTiHTxzhBXcGRzCalCNF();
			bool[] currentButtonValues = kYVEkOHTXBhxnrAeWMuOTcRgNeH.CurrentButtonValues;
			int[] pointOfViewControllers = kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.PointOfViewControllers;
			IsHEPGDcapJjIIIwabNlagrgYHK(currentButtonValues, pointOfViewControllers);
			xEfKEFgwOpPyjRLoWJIEfoNdBYF(currentButtonValues, pointOfViewControllers);
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.aqqkTdOMGLHPIIcYrYTpjUXAOZk();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (gwfrHmNqxmYlnzynBGWAgujDDrf == dataUpdater.axisCount)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -1349407912;
					while (true)
					{
						switch (num ^ -1349407911)
						{
						case 5:
							break;
						default:
							return;
						case 1:
							goto IL_0052;
						case 8:
							if (!dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = -1349407920;
								continue;
							}
							return;
						case 2:
							if (num3 >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
							{
								goto IL_0093;
							}
							goto case 10;
						case 6:
							num = -1349407909;
							continue;
						case 10:
							dataUpdater.buttonValues[num3] = xrmDwADRXdFsenTurfwlUsqsAvb[num3];
							num3++;
							num = -1349407909;
							continue;
						case 7:
							dataUpdater.axisValues[num2] = HwRqYBlbrIoKtVDOMNmmVOGCrNt[num2];
							num2++;
							num = -1349407911;
							continue;
						case 4:
							goto end_IL_0011;
						case 3:
							num2 = 0;
							num = -1349407911;
							continue;
						case 0:
							if (num2 >= gwfrHmNqxmYlnzynBGWAgujDDrf)
							{
								num3 = 0;
								num = -1349407905;
								continue;
							}
							goto case 7;
						case 9:
							return;
						}
						break;
						IL_0093:
						int num4;
						if (RZErYKzcoEvfMnhtHeFDeTWjAxp)
						{
							num = -1349407919;
							num4 = num;
						}
						else
						{
							num = -1349407920;
							num4 = num;
						}
						continue;
						IL_0052:
						int num5;
						if (rqeFUUCoNDfDgMOxuCDGnyLQlXi != dataUpdater.buttonCount)
						{
							num = -1349407907;
							num5 = num;
						}
						else
						{
							num = -1349407910;
							num5 = num;
						}
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public int QJuTPVbZPhckxeVMgmaDORJltri(dIYfxShIDrIIjihOcmVToKsXwFAE P_0)
		{
			if (P_0.LHBzfOUukEAojNhzqhOUdcqBelx == LHBzfOUukEAojNhzqhOUdcqBelx)
			{
				return 2;
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
				goto IL_003e;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			int num;
			if (P_0.AIefUprvkNeEvLSsrampirFfHMzU == AIefUprvkNeEvLSsrampirFfHMzU)
			{
				num = 1002057701;
				goto IL_0043;
			}
			return 0;
			IL_003e:
			num = 1002057700;
			goto IL_0043;
			IL_0043:
			switch (num ^ 0x3BBA2FE5)
			{
			case 2:
				break;
			case 1:
				return 0;
			default:
				return 1;
			}
			goto IL_003e;
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
			BridgedController bridgedController = new BridgedController();
			qLdgPikrSeiPWSEbkkdRitWDfeYu(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(LHBzfOUukEAojNhzqhOUdcqBelx);
		}

		public bool IMlLKEcEdbfJWCtAPwVjQExfFyg()
		{
			try
			{
				kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA.bJiEXbaJdBIXYlrsFTDrNZQMlrdm();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void MuhNEKLWnOVbFFtlAfKRHODWgpV()
		{
			try
			{
				if (kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA != null)
				{
					kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA.MuhNEKLWnOVbFFtlAfKRHODWgpV();
				}
			}
			catch
			{
			}
		}

		public void ZrHcJGgwwvDxGfSwHIvyriZRodVX()
		{
			try
			{
				if (kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA == null)
				{
					return;
				}
				while (true)
				{
					int num = 99588138;
					while (true)
					{
						switch (num ^ 0x5EF982B)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_002b;
						case 2:
							return;
						}
						break;
						IL_002b:
						kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA.ZrHcJGgwwvDxGfSwHIvyriZRodVX();
						num = 99588137;
					}
				}
			}
			catch
			{
			}
		}

		private void IsHEPGDcapJjIIIwabNlagrgYHK(bool[] P_0, int[] P_1)
		{
			if (gwfrHmNqxmYlnzynBGWAgujDDrf <= 0)
			{
				return;
			}
			int num3 = default(int);
			HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = default(HardwareJoystickMap.Platform_RawInput_Base.Axis[]);
			int num5 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = default(HardwareJoystickMap.Platform_DirectInput_Base.Axis[]);
			while (true)
			{
				InputPlatform platform = XCAyIFRJbEWUeBcnVweevmqWqtw.map.platform;
				int num;
				int num2;
				if (platform == InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg)
				{
					num = 1452921439;
					num2 = num;
				}
				else
				{
					num = 1452921429;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5699D259)
					{
					case 5:
						num = 1452921435;
						continue;
					default:
						return;
					case 4:
						num3++;
						num = 1452921427;
						continue;
					case 1:
						BnNUDmgtuAMaGYlEmQtjNSKwmsB(axes_orig2[num5], num5, P_0, P_1);
						num5++;
						num = 1452921433;
						continue;
					case 2:
						break;
					case 0:
						if (num5 >= axes_orig2.Length)
						{
							return;
						}
						goto case 1;
					case 10:
					{
						int num6;
						if (num3 >= axes_orig.Length)
						{
							num = 1452921425;
							num6 = num;
						}
						else
						{
							num = 1452921434;
							num6 = num;
						}
						continue;
					}
					case 11:
						num3 = 0;
						num = 1452921427;
						continue;
					case 7:
						num5 = 0;
						num = 1452921433;
						continue;
					case 9:
					{
						HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						axes_orig = platform_DirectInput_Base.Axes_orig;
						if (axes_orig == null)
						{
							return;
						}
						goto case 11;
					}
					case 6:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						axes_orig2 = platform_RawInput_Base.Axes_orig;
						if (axes_orig2 == null)
						{
							return;
						}
						goto case 7;
					}
					case 12:
					{
						int num4;
						if (platform != InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw)
						{
							num = 1452921425;
							num4 = num;
						}
						else
						{
							num = 1452921424;
							num4 = num;
						}
						continue;
					}
					case 3:
						BnNUDmgtuAMaGYlEmQtjNSKwmsB(axes_orig[num3], num3, P_0, P_1);
						num = 1452921437;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		private void xEfKEFgwOpPyjRLoWJIEfoNdBYF(bool[] P_0, int[] P_1)
		{
			if (rqeFUUCoNDfDgMOxuCDGnyLQlXi <= 0)
			{
				return;
			}
			int num3 = default(int);
			int num4 = default(int);
			HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = default(HardwareJoystickMap.Platform_DirectInput_Base.Button[]);
			HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = default(HardwareJoystickMap.Platform_RawInput_Base.Button[]);
			while (true)
			{
				InputPlatform platform = XCAyIFRJbEWUeBcnVweevmqWqtw.map.platform;
				int num;
				int num2;
				if (platform != InputPlatform.PmnSHpCUoGadlRLWMAbfdlxfwVg)
				{
					num = 202755986;
					num2 = num;
				}
				else
				{
					num = 202755997;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xC15CF9B)
					{
					case 10:
						num = 202755998;
						continue;
					default:
						return;
					case 0:
						num3 = 0;
						num = 202755994;
						continue;
					case 8:
						num4 = 0;
						num = 202755984;
						continue;
					case 11:
					{
						int num6;
						if (num4 < buttons_orig.Length)
						{
							num = 202755991;
							num6 = num;
						}
						else
						{
							num = 202755996;
							num6 = num;
						}
						continue;
					}
					case 1:
					{
						int num7;
						if (num3 >= buttons_orig2.Length)
						{
							num = 202755999;
							num7 = num;
						}
						else
						{
							num = 202755992;
							num7 = num;
						}
						continue;
					}
					case 6:
					{
						HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						buttons_orig2 = platform_RawInput_Base.Buttons_orig;
						if (buttons_orig2 == null)
						{
							return;
						}
						goto case 0;
					}
					case 4:
						return;
					case 9:
					{
						int num5;
						if (platform == InputPlatform.hQxvcadrrPaLqOjHlvDNLCWZlDw)
						{
							num = 202755993;
							num5 = num;
						}
						else
						{
							num = 202755996;
							num5 = num;
						}
						continue;
					}
					case 5:
						break;
					case 12:
						JQUOJFbbxdoZvdDiXaJFJTBTwATd(buttons_orig[num4], num4, P_0, P_1);
						num4++;
						num = 202755984;
						continue;
					case 3:
						JQUOJFbbxdoZvdDiXaJFJTBTwATd(buttons_orig2[num3], num3, P_0, P_1);
						num3++;
						num = 202755994;
						continue;
					case 2:
					{
						HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map;
						buttons_orig = platform_DirectInput_Base.Buttons_orig;
						if (buttons_orig == null)
						{
							return;
						}
						goto case 8;
					}
					case 7:
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
				int num = 1823581903;
				while (true)
				{
					switch (num ^ 0x6CB1A6CE)
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
					num = 1823581900;
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
				int num;
				int num2;
				if (!RZErYKzcoEvfMnhtHeFDeTWjAxp)
				{
					num = 892734916;
					num2 = num;
				}
				else
				{
					num = 892734917;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x35360DC7)
					{
					case 0:
						num = 892734918;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						if (xrmDwADRXdFsenTurfwlUsqsAvb[P_1])
						{
							RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
							num = 892734917;
							continue;
						}
						return;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis > 0)
				{
					if (P_0.sourceAxis < 32)
					{
						return QkOJeQjNoGuvJJcCjzkxhFnepjH((DirectInputAxis)P_0.sourceAxis);
					}
					goto IL_0025;
				}
				goto IL_026e;
			}
			int sourceHat = default(int);
			int num;
			int sourceButton = default(int);
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					sourceHat = P_0.sourceHat;
					num = -1342367372;
				}
				else
				{
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						return 0f;
					}
					num = -1342367370;
				}
			}
			else
			{
				sourceButton = P_0.sourceButton;
				if (sourceButton < 0)
				{
					goto IL_00d5;
				}
				int num2;
				if (sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					num = -1342367363;
					num2 = num;
				}
				else
				{
					num = -1342367368;
					num2 = num;
				}
			}
			goto IL_002a;
			IL_0025:
			num = -1342367381;
			goto IL_002a;
			IL_026e:
			return 0f;
			IL_002a:
			int num3 = default(int);
			float result = default(float);
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = default(HardwareElementSourceTypeWithHat);
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			CustomCalculation customCalculation = default(CustomCalculation);
			int num4 = default(int);
			float num5 = default(float);
			while (true)
			{
				switch (num ^ -1342367364)
				{
				case 13:
					break;
				case 2:
					return 0f;
				case 12:
					num3++;
					num = -1342367369;
					continue;
				case 1:
					goto IL_00d5;
				case 19:
					goto IL_0103;
				case 22:
					return 0f;
				case 7:
					return 0f;
				case 9:
					return result;
				case 25:
					return 0f;
				case 16:
					return 0f;
				case 0:
					hardwareElementSourceTypeWithHat = sourceType;
					num = -1342367374;
					continue;
				case 20:
					num = -1342367369;
					continue;
				case 3:
					goto IL_01e1;
				case 21:
					goto IL_01f1;
				case 5:
					if (customCalculationSourceData[num3] != null)
					{
						sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType;
						num = -1342367364;
						continue;
					}
					goto case 12;
				case 8:
					if (sourceHat < 0 || sourceHat >= JwvOuylcUYNAjPLMAAlyukWmToj)
					{
						goto case 22;
					}
					goto IL_0240;
				case 11:
					goto IL_0252;
				case 23:
					goto IL_026e;
				case 17:
					goto IL_02b9;
				case 18:
					goto IL_02cb;
				case 6:
					goto IL_02e5;
				case 4:
					goto IL_0341;
				case 10:
					goto IL_0356;
				case 15:
					return 0f;
				case 14:
				{
					float item;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && GcXMSpyoZSbgVbAoeISEDqCbryIv(customCalculationSourceData[num3], out item))
					{
						customCalculation.AddData(item);
						num = -1342367376;
						continue;
					}
					goto case 12;
				}
				default:
					return 0f;
				}
				break;
				IL_0356:
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					num = -1342367373;
					continue;
				}
				customCalculationSourceData = P_0.customCalculationSourceData;
				num = -1342367377;
				continue;
				IL_02b9:
				if (num4 >= 0)
				{
					if (P_0.sourceHatDirection == AxisDirection.Horizontal)
					{
						num5 = lsSCStiAfbFyneyGtxVQJHRkdst(num4, AxisDirection.Horizontal);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							if (P_0.sourceHatRange == AxisRange.Positive)
							{
								num = -1342367366;
								continue;
							}
							if (num5 > 0f)
							{
								return 0f;
							}
						}
					}
					else
					{
						num5 = lsSCStiAfbFyneyGtxVQJHRkdst(num4, AxisDirection.Vertical);
						if (P_0.sourceHatRange != AxisRange.Full)
						{
							if (P_0.sourceHatRange != AxisRange.Positive)
							{
								if (num5 > 0f)
								{
									num = -1342367387;
									continue;
								}
							}
							else if (num5 < 0f)
							{
								num = -1342367365;
								continue;
							}
						}
					}
					goto IL_016f;
				}
				num = -1342367380;
				continue;
				IL_0103:
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				num3 = 0;
				num = -1342367384;
				continue;
				IL_02e5:
				if (num5 < 0f)
				{
					return 0f;
				}
				goto IL_016f;
				IL_0240:
				if (sourceHat < 4)
				{
					num4 = P_2[sourceHat];
					num = -1342367379;
				}
				else
				{
					num = -1342367382;
				}
				continue;
				IL_0341:
				if (sourceButton < 128)
				{
					if (!P_1[sourceButton])
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = -1342367371;
						continue;
					}
					goto IL_01e1;
				}
				num = -1342367363;
				continue;
				IL_016f:
				if (P_0.invert)
				{
					num5 *= -1f;
					num = -1342367378;
					continue;
				}
				goto IL_02cb;
				IL_01f1:
				if (customCalculation.Process())
				{
					if (customCalculation.Result.type == TypeWrapper.DataType.Single)
					{
						return customCalculation.Result;
					}
					num = -1342367388;
				}
				else
				{
					num = -1342367362;
				}
				continue;
				IL_02cb:
				return num5;
				IL_0252:
				int num6;
				if (num3 >= customCalculationSourceData.Length)
				{
					num = -1342367383;
					num6 = num;
				}
				else
				{
					num = -1342367367;
					num6 = num;
				}
				continue;
				IL_01e1:
				result = -1f;
				num = -1342367371;
			}
			goto IL_0025;
			IL_00d5:
			return 0f;
		}

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(DirectInputAxis P_0)
		{
			float result;
			int num;
			switch (P_0)
			{
			case DirectInputAxis.AccelerationY:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AccelerationY);
				num = 1992436648;
				goto IL_0094;
			case DirectInputAxis.AngularAccelerationZ:
				goto IL_016d;
			case DirectInputAxis.RotationZ:
				goto IL_01b1;
			case DirectInputAxis.AccelerationX:
				goto IL_01d7;
			case DirectInputAxis.VelocityY:
				goto IL_01fd;
			case DirectInputAxis.Slider1:
				goto IL_0223;
			case DirectInputAxis.AngularAccelerationX:
				goto IL_024b;
			case DirectInputAxis.VelocityX:
				goto IL_0271;
			case DirectInputAxis.AngularVelocityZ:
				goto IL_0292;
			case DirectInputAxis.AngularVelocityY:
				goto IL_02b3;
			case DirectInputAxis.AccelerationZ:
				goto IL_02d9;
			case DirectInputAxis.AccelerationSlider1:
				goto IL_030e;
			case DirectInputAxis.TorqueX:
				goto IL_0354;
			case DirectInputAxis.VelocitySlider0:
				goto IL_037a;
			case DirectInputAxis.AngularAccelerationY:
				goto IL_03a2;
			case DirectInputAxis.ForceSlider1:
				goto IL_03c8;
			case DirectInputAxis.VelocityZ:
				goto IL_03eb;
			case DirectInputAxis.VelocitySlider1:
				goto IL_0411;
			case DirectInputAxis.ForceY:
				goto IL_0448;
			case DirectInputAxis.TorqueY:
				goto IL_046e;
			case DirectInputAxis.ForceZ:
				goto IL_0494;
			case DirectInputAxis.ForceX:
				goto IL_04b5;
			case DirectInputAxis.Z:
				goto IL_04d6;
			case DirectInputAxis.Y:
				goto IL_04fc;
			case DirectInputAxis.ForceSlider0:
				goto IL_0522;
			case DirectInputAxis.Slider0:
				goto IL_054a;
			case DirectInputAxis.RotationY:
				goto IL_0572;
			case DirectInputAxis.AngularVelocityX:
				goto IL_05a7;
			case DirectInputAxis.AccelerationSlider0:
				goto IL_05d7;
			case DirectInputAxis.RotationX:
				goto IL_05fc;
			case DirectInputAxis.TorqueZ:
				goto IL_061f;
			case DirectInputAxis.X:
				goto IL_0640;
			default:
				goto IL_0663;
				IL_0094:
				while (true)
				{
					switch (num ^ 0x76C22BA6)
					{
					case 11:
						num = 1992436662;
						continue;
					case 17:
						break;
					case 19:
						goto IL_016d;
					case 41:
						goto IL_01b1;
					case 18:
						goto IL_01d7;
					case 25:
						goto IL_01fd;
					case 38:
						goto IL_0223;
					case 13:
						goto IL_024b;
					case 39:
						goto IL_0271;
					case 1:
						goto IL_0292;
					case 34:
						goto IL_02b3;
					case 20:
						goto IL_02d9;
					case 26:
						goto IL_030e;
					case 10:
						goto IL_0354;
					case 6:
						goto IL_037a;
					case 24:
						goto IL_03a2;
					case 9:
						goto IL_03c8;
					case 29:
						goto IL_03eb;
					case 4:
						goto IL_0411;
					case 31:
						goto IL_0448;
					case 22:
						goto IL_046e;
					case 21:
						goto IL_0494;
					case 35:
						goto IL_04b5;
					case 33:
						goto IL_04d6;
					case 2:
						goto IL_04fc;
					case 27:
						goto IL_0522;
					case 3:
						goto IL_054a;
					case 8:
						goto IL_0572;
					case 40:
						goto IL_05a7;
					case 32:
						goto IL_05d7;
					case 5:
						goto IL_05fc;
					case 23:
						goto IL_061f;
					case 16:
						goto IL_0640;
					default:
						goto IL_0663;
					case 0:
					case 7:
					case 12:
					case 14:
					case 15:
					case 28:
					case 36:
					case 37:
						goto end_IL_0005;
					}
					break;
				}
				goto case DirectInputAxis.AccelerationY;
				IL_0663:
				return 0f;
				IL_0640:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.X);
				break;
				IL_061f:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.TorqueZ);
				num = 1992436611;
				goto IL_0094;
				IL_05fc:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.RotationX);
				break;
				IL_05d7:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AccelerationSliders[0]);
				break;
				IL_05a7:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularVelocityX);
				num = 1992436649;
				goto IL_0094;
				IL_0572:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.RotationY);
				break;
				IL_054a:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.Sliders[0]);
				break;
				IL_0522:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.ForceSliders[0]);
				break;
				IL_04fc:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.Y);
				break;
				IL_04d6:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.Z);
				break;
				IL_04b5:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.ForceX);
				num = 1992436641;
				goto IL_0094;
				IL_0494:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.ForceZ);
				num = 1992436610;
				goto IL_0094;
				IL_046e:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.TorqueY);
				break;
				IL_0448:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.ForceY);
				break;
				IL_0411:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.VelocitySliders[1]);
				break;
				IL_03eb:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.VelocityZ);
				break;
				IL_03c8:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.ForceSliders[1]);
				num = 1992436646;
				goto IL_0094;
				IL_03a2:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularAccelerationY);
				break;
				IL_037a:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.VelocitySliders[0]);
				break;
				IL_0354:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.TorqueX);
				break;
				IL_030e:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AccelerationSliders[1]);
				break;
				IL_02d9:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AccelerationZ);
				break;
				IL_02b3:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularVelocityY);
				break;
				IL_0292:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularVelocityZ);
				num = 1992436666;
				goto IL_0094;
				IL_0271:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.VelocityX);
				num = 1992436650;
				goto IL_0094;
				IL_024b:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularAccelerationX);
				break;
				IL_0223:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.Sliders[1]);
				break;
				IL_01fd:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.VelocityY);
				break;
				IL_01d7:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AccelerationX);
				break;
				IL_01b1:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.RotationZ);
				break;
				IL_016d:
				result = dmOmXokuwYPeqkLCCIorsBnvJVN(kYVEkOHTXBhxnrAeWMuOTcRgNeH.joystickState.AngularAccelerationZ);
				break;
				end_IL_0005:
				break;
			}
			return result;
		}

		private bool eRRRbnNJkvBkNLMFRFRiaMhIthSB(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (!P_0.ignoreIfButtonsActive)
				{
					goto IL_00f6;
				}
				num = 0;
				goto IL_03f8;
			}
			int num2;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[]);
			int sourceHat = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int num3;
				if (P_0.sourceAxis > 0)
				{
					num2 = 45607996;
					num3 = num2;
				}
				else
				{
					num2 = 45607991;
					num3 = num2;
				}
			}
			else if (P_0.sourceType != HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					goto IL_04be;
				}
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return false;
				}
				customCalculationSourceData = P_0.customCalculationSourceData;
				num2 = 45607977;
			}
			else
			{
				sourceHat = P_0.sourceHat;
				num2 = 45607989;
			}
			goto IL_0022;
			IL_03f8:
			int num4;
			if (num < P_0.ignoreIfButtonsActiveButtons.Length)
			{
				num2 = 45607968;
				num4 = num2;
			}
			else
			{
				num2 = 45607970;
				num4 = num2;
			}
			goto IL_0022;
			IL_0022:
			int num7 = default(int);
			int sourceButton = default(int);
			int num5 = default(int);
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = default(HardwareElementSourceTypeWithHat);
			float num8 = default(float);
			bool flag2 = default(bool);
			while (true)
			{
				float num6;
				bool flag;
				switch (num2 ^ 0x2B7EC2C)
				{
				case 15:
					num2 = 45607968;
					continue;
				case 3:
					return false;
				case 11:
					return false;
				case 23:
					return false;
				case 14:
					break;
				case 25:
					if (sourceHat >= 0 && sourceHat < JwvOuylcUYNAjPLMAAlyukWmToj)
					{
						goto IL_0121;
					}
					goto case 13;
				case 2:
					return true;
				case 0:
					return false;
				case 16:
					goto IL_0166;
				case 4:
					num2 = 45607981;
					continue;
				case 27:
					return false;
				case 10:
					num7++;
					num2 = 45607988;
					continue;
				case 12:
					goto IL_01c8;
				case 19:
					num2 = 45607981;
					continue;
				case 28:
					goto IL_01e8;
				case 13:
					return false;
				case 6:
					if (sourceButton >= aCdTArmyUaJIYSBpkbuJpDufgNGc)
					{
						goto case 23;
					}
					goto IL_02ff;
				case 1:
					num5++;
					num2 = 45607993;
					continue;
				case 24:
					goto IL_0324;
				case 7:
					switch (hardwareElementSourceTypeWithHat)
					{
					case HardwareElementSourceTypeWithHat.Button:
						goto IL_0358;
					case HardwareElementSourceTypeWithHat.Axis:
						goto IL_046c;
					}
					num2 = 45607999;
					continue;
				case 22:
					goto IL_0358;
				case 29:
					goto IL_0389;
				case 5:
					goto IL_03a2;
				case 18:
					goto IL_03b3;
				case 17:
					goto IL_03f8;
				case 21:
					if (num5 >= customCalculationSourceData.Length)
					{
						goto IL_041f;
					}
					goto case 8;
				case 8:
					if (customCalculationSourceData[num5] != null)
					{
						HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num5].sourceType;
						hardwareElementSourceTypeWithHat = sourceType;
						num2 = 45607979;
						continue;
					}
					goto case 1;
				case 9:
					goto IL_046c;
				default:
					return false;
				case 20:
					goto IL_04be;
					IL_046c:
					if (GcXMSpyoZSbgVbAoeISEDqCbryIv(customCalculationSourceData[num5], out num6))
					{
						customCalculation.AddData((num6 != 0f) ? 1f : 0f);
						num2 = 45607981;
						continue;
					}
					goto case 1;
					IL_0358:
					if (dIGEjeJuOmivVcCLDIiTEFopnzx(customCalculationSourceData[num5], P_1, out flag))
					{
						customCalculation.AddData(flag ? 1f : 0f);
						num2 = 45607976;
						continue;
					}
					goto case 1;
				}
				break;
				IL_041f:
				if (!customCalculation.Process())
				{
					return false;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					num2 = 45607990;
					continue;
				}
				return (float)customCalculation.Result != 0f;
				IL_01e8:
				return uKCWXtJstxLBivpUoCOlAaKlIhZ(P_2[sourceHat], 0, P_0.sourceHatType);
				IL_0121:
				if (sourceHat >= 4)
				{
					num2 = 45607969;
					continue;
				}
				switch (P_0.sourceHatDirection)
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
					num2 = 45607992;
					continue;
				}
				goto IL_01e8;
				IL_02ff:
				if (sourceButton < 128)
				{
					return P_1[sourceButton];
				}
				num2 = 45607995;
				continue;
				IL_0166:
				if (P_0.sourceAxis > 32)
				{
					num2 = 45607991;
					continue;
				}
				num8 = QkOJeQjNoGuvJJcCjzkxhFnepjH((DirectInputAxis)P_0.sourceAxis);
				if (MathTools.Abs(num8) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					num2 = 45607998;
					continue;
				}
				goto IL_03be;
				IL_03a2:
				if (customCalculationSourceData != null)
				{
					num5 = 0;
					num2 = 45607993;
				}
				else
				{
					num2 = 45607983;
				}
				continue;
				IL_0389:
				if (P_1[P_0.requiredButtons[num7]])
				{
					flag2 = true;
					num2 = 45607974;
				}
				else
				{
					num2 = 45607975;
				}
				continue;
				IL_01c8:
				if (!P_1[P_0.ignoreIfButtonsActiveButtons[num]])
				{
					num++;
					num2 = 45607997;
				}
				else
				{
					num2 = 45607980;
				}
				continue;
				IL_0324:
				if (num7 >= P_0.requiredButtons.Length)
				{
					if (!flag2)
					{
						return false;
					}
					num2 = 45607982;
					continue;
				}
				goto IL_0389;
			}
			goto IL_00f6;
			IL_03be:
			if (num8 > 0f)
			{
				return false;
			}
			goto IL_03c9;
			IL_00f6:
			if (P_0.requireMultipleButtons)
			{
				flag2 = false;
				num7 = 0;
				num2 = 45607988;
			}
			else
			{
				sourceButton = P_0.sourceButton;
				int num9;
				if (sourceButton < 0)
				{
					num2 = 45607995;
					num9 = num2;
				}
				else
				{
					num2 = 45607978;
					num9 = num2;
				}
			}
			goto IL_0022;
			IL_03b3:
			if (num8 < 0f)
			{
				return false;
			}
			goto IL_03c9;
			IL_03c9:
			return true;
			IL_04be:
			return false;
		}

		private float dmOmXokuwYPeqkLCCIorsBnvJVN(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private bool uKCWXtJstxLBivpUoCOlAaKlIhZ(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (XCAyIFRJbEWUeBcnVweevmqWqtw.isUnknownController)
			{
				goto IL_0016;
			}
			goto IL_00b4;
			IL_00a8:
			if (!InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			goto IL_00b4;
			IL_0016:
			int num = 483071787;
			goto IL_001b;
			IL_001b:
			int num2 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			int num5 = default(int);
			while (true)
			{
				switch (num ^ 0x1CCB172F)
				{
				case 0:
					break;
				case 2:
					goto IL_004b;
				case 6:
					goto IL_0068;
				case 7:
					if (P_1 == 0 && P_0 > num2)
					{
						P_0 -= 36000;
						num = 483071785;
						continue;
					}
					goto IL_0068;
				case 5:
					goto IL_0092;
				case 4:
					goto IL_00a8;
				case 1:
					goto IL_00c4;
				default:
					return true;
				}
				break;
				IL_00c4:
				num3 = num4 * P_1;
				if (P_2 == HatType.EightWay)
				{
					num = 483071789;
					continue;
				}
				goto IL_0051;
				IL_004b:
				if (P_0 != num3)
				{
					return false;
				}
				goto IL_0051;
				IL_0068:
				if (P_0 < num3 + num5 && P_0 > num3 - num5)
				{
					num = 483071788;
					continue;
				}
				return false;
				IL_0092:
				num2 = 27000;
				num5 = 9000;
				num = 483071784;
				continue;
				IL_0051:
				if (P_2 == HatType.EightWay)
				{
					num2 = 31500;
					num5 = 4500;
					num = 483071784;
					continue;
				}
				goto IL_0092;
			}
			goto IL_0016;
			IL_00b4:
			num4 = 4500;
			num = 483071790;
			goto IL_001b;
		}

		private float lsSCStiAfbFyneyGtxVQJHRkdst(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				goto IL_0004;
			}
			int num;
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000)
				{
					goto IL_0046;
				}
				if (P_0 >= 9000)
				{
					if (P_0 < 27000 && P_0 > 9000)
					{
						return -1f;
					}
					return 0f;
				}
				num = -2012061356;
			}
			else
			{
				if (P_0 <= 0 || P_0 >= 18000)
				{
					if (P_0 > 18000)
					{
						return -1f;
					}
					return 0f;
				}
				num = -2012061353;
			}
			goto IL_0009;
			IL_0004:
			num = -2012061355;
			goto IL_0009;
			IL_0009:
			switch (num ^ -2012061354)
			{
			case 0:
				break;
			case 3:
				return 0f;
			case 2:
				goto IL_0046;
			default:
				return 1f;
			}
			goto IL_0004;
			IL_0046:
			return 1f;
		}

		private bool dIGEjeJuOmivVcCLDIiTEFopnzx(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton >= 0)
			{
				while (true)
				{
					int num = -1531764090;
					while (true)
					{
						switch (num ^ -1531764092)
						{
						case 3:
							break;
						case 2:
							goto IL_003e;
						case 4:
							goto end_IL_0018;
						case 1:
							goto IL_0066;
						default:
							return true;
						}
						break;
						IL_0066:
						if (sourceButton < 128)
						{
							P_2 = P_1[sourceButton];
							num = -1531764092;
						}
						else
						{
							num = -1531764096;
						}
						continue;
						IL_003e:
						int num2;
						if (sourceButton < aCdTArmyUaJIYSBpkbuJpDufgNGc)
						{
							num = -1531764091;
							num2 = num;
						}
						else
						{
							num = -1531764096;
							num2 = num;
						}
					}
					continue;
					end_IL_0018:
					break;
				}
			}
			return false;
		}

		private bool GcXMSpyoZSbgVbAoeISEDqCbryIv(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			while (true)
			{
				int num = -1745977092;
				while (true)
				{
					switch (num ^ -1745977100)
					{
					case 5:
						break;
					case 10:
						if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
						{
							P_1 = 0f;
							num = -1745977089;
							continue;
						}
						goto default;
					case 7:
						if (P_0.sourceAxis >= 32)
						{
							num = -1745977100;
							continue;
						}
						P_1 = QkOJeQjNoGuvJJcCjzkxhFnepjH((DirectInputAxis)P_0.sourceAxis);
						switch (P_0.sourceAxisRange)
						{
						case AxisRange.Negative:
							break;
						default:
							goto IL_0102;
						case AxisRange.Positive:
							goto IL_010c;
						}
						goto case 6;
					case 8:
					{
						if (P_0.sourceType != 1)
						{
							return false;
						}
						int num4;
						if (P_0.sourceAxis <= 0)
						{
							num = -1745977100;
							num4 = num;
						}
						else
						{
							num = -1745977101;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num3;
						if (P_0.axisCalibrationType != AxisCalibrationType.Default)
						{
							num = -1745977099;
							num3 = num;
						}
						else
						{
							num = -1745977098;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (P_1 > 0f)
						{
							P_1 = 0f;
							num = -1745977097;
							continue;
						}
						goto case 3;
					case 0:
						return false;
					case 4:
						goto IL_010c;
					case 9:
						if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated)
						{
							int num2;
							if (P_0.axisDeadZone > 0f)
							{
								num = -1745977090;
								num2 = num;
							}
							else
							{
								num = -1745977089;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 1:
						if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
						{
							P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
							num = -1745977089;
							continue;
						}
						goto case 9;
					case 2:
						P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, false, AxisSensitivityType.Multiplier, 1f, null);
						num = -1745977089;
						continue;
					default:
						{
							return true;
						}
						IL_010c:
						if (P_1 < 0f)
						{
							P_1 = 0f;
							num = -1745977097;
							continue;
						}
						goto case 3;
						IL_0102:
						num = -1745977097;
						continue;
					}
					break;
				}
			}
		}

		private ControlDeviceType rJpjxFYmbdvFMSEGrDkWGiROwzK(ofeqpRsjofXSwYwacxFrGdeWwcg P_0)
		{
			if (P_0 == ofeqpRsjofXSwYwacxFrGdeWwcg.xASCPheTPZjjySaqzxbejdrWIOZ)
			{
				return ControlDeviceType.tkHFoIOLgynnsbjfJgGsghWKZpu;
			}
			if (P_0 == ofeqpRsjofXSwYwacxFrGdeWwcg.kwXecDUdPYUlNuDiMAoCcCImDZIb)
			{
				return ControlDeviceType.sPSdDimdHdkUZBwhcqdUzIdejYne;
			}
			if (P_0 == ofeqpRsjofXSwYwacxFrGdeWwcg.dhUtEzDFvpZQnDBlTeAFXyELNJz)
			{
				goto IL_0013;
			}
			if (P_0 == ofeqpRsjofXSwYwacxFrGdeWwcg.UQBduDQfcpFVodDJGKokyQOHOEHN)
			{
				return ControlDeviceType.EuQbsbgswOBiYuQiqzeyNfABXek;
			}
			int num;
			if (P_0 == ofeqpRsjofXSwYwacxFrGdeWwcg.RSYxVUzovUaewdHaxOMnFaSnBhsn)
			{
				num = -1798634872;
			}
			else
			{
				if (P_0 != ofeqpRsjofXSwYwacxFrGdeWwcg.zYVdxJRhImBRPsxZlpigKIKyrqQ)
				{
					return ControlDeviceType.srbgNzJMznryeuABhpjzUCNZxjJP;
				}
				num = -1798634870;
			}
			goto IL_0018;
			IL_0013:
			num = -1798634871;
			goto IL_0018;
			IL_0018:
			switch (num ^ -1798634869)
			{
			case 0:
				break;
			case 2:
				return ControlDeviceType.dNyyENhbShZpwawrFNHGUzXrCYg;
			case 3:
				return ControlDeviceType.VzLOKbBwdrQamkifJxNjjKppEyRH;
			default:
				return ControlDeviceType.VvQeCWOlDZkBlRrYLudWaZwDzKp;
			}
			goto IL_0013;
		}

		private void XCEcogOtFbmhupWduawPDMqkEjv()
		{
			XCAyIFRJbEWUeBcnVweevmqWqtw = lvntcpgdZsSbabccpIcfMpTzYYr(PJFgAzlnjXDIFtIVMtyxcOgBHLL());
			if (XCAyIFRJbEWUeBcnVweevmqWqtw == null)
			{
				Logger.LogError("Default hardware map not found!");
				while (true)
				{
					switch (0x12862674 ^ 0x12862675)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			gwfrHmNqxmYlnzynBGWAgujDDrf = XCAyIFRJbEWUeBcnVweevmqWqtw.axisCount;
			rqeFUUCoNDfDgMOxuCDGnyLQlXi = XCAyIFRJbEWUeBcnVweevmqWqtw.buttonCount;
		}

		private void wjVtrApEbQVLJidkrOqnpoRQlvb()
		{
		}

		private string PZXxsZWHUlpVhHySZrybyKpWWCD()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (HUFFKhqkxcIVKhtrxspNbGBrTdG && !string.IsNullOrEmpty(ZYtBoPNuCmSlSLPglVVYiiIepKT)) ? ZYtBoPNuCmSlSLPglVVYiiIepKT : SgtdGZiZKfxrYfEaONXeCdMIqIsz, rFChCpBSHUoiIZbKWfsTCHUdRna, eTlTTlBmuxCORrngMaNsxFSpDyMi));
		}

		private void qLdgPikrSeiPWSEbkkdRitWDfeYu(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = rJpjxFYmbdvFMSEGrDkWGiROwzK(ocqEYLgpYeVchwgaiKyLlHKhmSeI);
			P_0.hardwareIdentifier = PZXxsZWHUlpVhHySZrybyKpWWCD();
			P_0.hardwareAxisCount = dhEQLHuCYYGQwdehmJKXAJgttVWs;
			P_0.hardwareButtonCount = aCdTArmyUaJIYSBpkbuJpDufgNGc;
			while (true)
			{
				int num = 1154412236;
				while (true)
				{
					switch (num ^ 0x44CEEECF)
					{
					case 2:
						break;
					case 3:
						P_0.hardwareHatCount = JwvOuylcUYNAjPLMAAlyukWmToj;
						num = 1154412239;
						continue;
					case 0:
						P_0.hw_productName = SgtdGZiZKfxrYfEaONXeCdMIqIsz;
						P_0.hw_deviceGuid = instanceGuid;
						P_0.hw_productId = rFChCpBSHUoiIZbKWfsTCHUdRna;
						P_0.hw_pidVid = new PidVid(eTlTTlBmuxCORrngMaNsxFSpDyMi);
						P_0.hw_isBluetoothDevice = HUFFKhqkxcIVKhtrxspNbGBrTdG;
						P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(ZYtBoPNuCmSlSLPglVVYiiIepKT)) ? ZYtBoPNuCmSlSLPglVVYiiIepKT : string.Empty);
						num = 1154412238;
						continue;
					default:
						P_0.definitionMatchTag = ofHFJIxpUZEkaCUKTOBHGzIRSqW;
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
			P_0.gameHardwareMap = XCAyIFRJbEWUeBcnVweevmqWqtw.ToGameHardwareControllerMap();
			while (true)
			{
				int num = -145145288;
				while (true)
				{
					switch (num ^ -145145285)
					{
					case 2:
						break;
					case 3:
						P_0.instanceName = aQyubnFZjhaxoHtWxfehAEYaFOR;
						P_0.productName = SgtdGZiZKfxrYfEaONXeCdMIqIsz;
						P_0.isXInputDevice = IEIpySejupFvUUEVIERJEkDtdcvv;
						num = -145145285;
						continue;
					case 0:
						P_0.axisCount = gwfrHmNqxmYlnzynBGWAgujDDrf;
						P_0.buttonCount = rqeFUUCoNDfDgMOxuCDGnyLQlXi;
						P_0.unknownControllerHats = FsPEePPVDusMDfXPvWAmjGinMkk();
						num = -145145286;
						continue;
					default:
						P_0.controllerTypeGuid = FHAzoTozCrisunLDoLyimqNbdex;
						P_0.controllerExtension = extension;
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
				IL_0056:
				int num3;
				if (num >= rqeFUUCoNDfDgMOxuCDGnyLQlXi)
				{
					num2 = 0;
					num3 = 575785758;
					goto IL_0009;
				}
				goto IL_002e;
				IL_0009:
				while (true)
				{
					switch (num3 ^ 0x2251CB1B)
					{
					case 0:
						num3 = 575785752;
						continue;
					case 3:
						break;
					case 2:
						HwRqYBlbrIoKtVDOMNmmVOGCrNt[num2] = 0f;
						num3 = 575785754;
						continue;
					case 4:
						goto IL_0056;
					case 1:
						num2++;
						num3 = 575785758;
						continue;
					default:
						if (num2 >= gwfrHmNqxmYlnzynBGWAgujDDrf)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
				goto IL_002e;
				IL_002e:
				xrmDwADRXdFsenTurfwlUsqsAvb[num] = false;
				num++;
				num3 = 575785759;
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
			int num3 = default(int);
			int[] array2 = default(int[]);
			while (true)
			{
				int num2 = 1125592627;
				while (true)
				{
					switch (num2 ^ 0x43172E36)
					{
					case 4:
						break;
					case 6:
					{
						int num4;
						if (num >= 2)
						{
							num2 = 1125592631;
							num4 = num2;
						}
						else
						{
							num2 = 1125592628;
							num4 = num2;
						}
						continue;
					}
					case 2:
						num3 = 128 + num * 8;
						array2 = new int[8] { num3, 0, 0, 0, 0, 0, 0, 0 };
						num2 = 1125592630;
						continue;
					case 5:
						num2 = 1125592624;
						continue;
					case 3:
						num++;
						num2 = 1125592624;
						continue;
					case 0:
					{
						array2[1] = num3 + 1;
						array2[2] = num3 + 2;
						array2[3] = num3 + 3;
						array2[4] = num3 + 4;
						array2[5] = num3 + 5;
						array2[6] = num3 + 6;
						array2[7] = num3 + 7;
						UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(array2);
						array[num] = new UnknownControllerHat(buttons);
						num2 = 1125592629;
						continue;
					}
					default:
						return array;
					}
					break;
				}
			}
		}

		public void JGfOaxGMMubjxaprhTWpWgtvAPZ()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
			GC.SuppressFinalize(this);
		}

		~dIYfxShIDrIIjihOcmVToKsXwFAE()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
		}

		protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
		{
			if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -245307704;
			goto IL_000d;
			IL_000d:
			switch (num ^ -245307703)
			{
			case 0:
				break;
			case 1:
				return;
			case 3:
				goto IL_0032;
			default:
				goto IL_004f;
			}
			goto IL_0008;
			IL_0032:
			if (P_0 && kYVEkOHTXBhxnrAeWMuOTcRgNeH != null)
			{
				kYVEkOHTXBhxnrAeWMuOTcRgNeH.Dispose();
				num = -245307701;
				goto IL_000d;
			}
			goto IL_004f;
			IL_004f:
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		}

		public static int mHubPKenGxeOoCUpuEdJbdHQxjT(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, dIYfxShIDrIIjihOcmVToKsXwFAE P_1)
		{
			if (P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd < P_1.QSgOYisLlLVufpwxLNKaoIEBiyFd)
			{
				goto IL_000e;
			}
			int num;
			if (P_0.QSgOYisLlLVufpwxLNKaoIEBiyFd > P_1.QSgOYisLlLVufpwxLNKaoIEBiyFd)
			{
				num = -2127944452;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -2127944449;
			goto IL_0013;
			IL_0013:
			switch (num ^ -2127944450)
			{
			case 0:
				break;
			case 1:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}

		public static int BpwtCqMMoIuSANtUfTmfAKeytHL(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, dIYfxShIDrIIjihOcmVToKsXwFAE P_1)
		{
			if (P_0.iERVPkhRheIKptTuTmWgWiTZGxm < P_1.iERVPkhRheIKptTuTmWgWiTZGxm)
			{
				goto IL_000e;
			}
			int num;
			if (P_0.iERVPkhRheIKptTuTmWgWiTZGxm > P_1.iERVPkhRheIKptTuTmWgWiTZGxm)
			{
				num = -1483763474;
				goto IL_0013;
			}
			return 0;
			IL_000e:
			num = -1483763475;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1483763476)
			{
			case 0:
				break;
			case 1:
				return -1;
			default:
				return 1;
			}
			goto IL_000e;
		}
	}

	private class JEiBJdqVetCaYhzGImdkvLHTeQyH : IDisposable
	{
		private const int QjGTAyzcwqaBTkMvbhKNUXSDKwD = 2;

		private const int yubvonqLSilmaIyXmNqgdfheRsF = 2;

		private const int TXKUmuipzKfpUntOCmZVYLoalmZ = 128;

		private const int OMtLtuUMaeDAIcVyokyGOlqQbMc = 0;

		private const int kKWaUGiJZRDttBBpJCDyrHtVTnnn = 264;

		private const int AdfjXKZlDhoZlNIIkJYzKkODgNV = 268;

		private readonly int nzQPtryKaFyOknbFWLAdBHgWTek;

		private readonly ButtonLoopSet lOmtwKWetNmUEsKoXlYsIGMqOSm;

		private readonly DualRingReportBuffer cEYnsvdZEgpKUOcsxEpoXmVeOaF;

		public readonly hCkwWPjbZHHQuLPwssAiovZoKVX GopNkYanAGUkOmQwUJuTJxkowKA;

		private readonly POJetljaOyAGVgWkwdAAfDSJZTf uusEcgeppnkfxZzSaLjQJXqkcop;

		private eYQAacJaiYXVekhMtyuASsXijDU drjuHMWcKdKlbemNoyjAmboUjNJK;

		private readonly POJetljaOyAGVgWkwdAAfDSJZTf CdNBOUzjNQHkoHsKxSFkQpBNaIxm;

		private readonly object jkLokmyNuOlUdpUyyeSnDVevISp;

		private byte[] rXYbyQgsCXdWzmrqPlgwHHWWNvN;

		private byte[] siQVDcvmheIRNToTkUevWkMUmhZ;

		private bool tNTCfSzrXJZuOnbCfNhelnFFgApE;

		private POJetljaOyAGVgWkwdAAfDSJZTf klbCRyuWDYuOnexJoneNOUyWWSB;

		private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

		public bool[] CurrentButtonValues
		{
			get
			{
				return lOmtwKWetNmUEsKoXlYsIGMqOSm.Current.effectiveValue;
			}
		}

		public POJetljaOyAGVgWkwdAAfDSJZTf joystickState
		{
			get
			{
				return klbCRyuWDYuOnexJoneNOUyWWSB;
			}
		}

		public JEiBJdqVetCaYhzGImdkvLHTeQyH(hCkwWPjbZHHQuLPwssAiovZoKVX source, UpdateLoopSetting updateLoops)
		{
			GopNkYanAGUkOmQwUJuTJxkowKA = source;
			nzQPtryKaFyOknbFWLAdBHgWTek = source.Capabilities.rQrTdoWPDpDHrLHNnouynDuUHKW;
			cEYnsvdZEgpKUOcsxEpoXmVeOaF = new DualRingReportBuffer(268, 25);
			lOmtwKWetNmUEsKoXlYsIGMqOSm = new ButtonLoopSet(updateLoops, nzQPtryKaFyOknbFWLAdBHgWTek);
			rXYbyQgsCXdWzmrqPlgwHHWWNvN = cEYnsvdZEgpKUOcsxEpoXmVeOaF.ReadBuffer;
			siQVDcvmheIRNToTkUevWkMUmhZ = new byte[268];
			uusEcgeppnkfxZzSaLjQJXqkcop = new POJetljaOyAGVgWkwdAAfDSJZTf();
			klbCRyuWDYuOnexJoneNOUyWWSB = uusEcgeppnkfxZzSaLjQJXqkcop;
			fWzuAFjFXxdRoqxypOAIFkBEHOX(uusEcgeppnkfxZzSaLjQJXqkcop);
			CdNBOUzjNQHkoHsKxSFkQpBNaIxm = new POJetljaOyAGVgWkwdAAfDSJZTf();
			fWzuAFjFXxdRoqxypOAIFkBEHOX(CdNBOUzjNQHkoHsKxSFkQpBNaIxm);
			jkLokmyNuOlUdpUyyeSnDVevISp = new object();
			if (pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread != null)
			{
				pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread.ThreadUpdateEvent += JSZvpcfgZVssNtfXMVqTmNXDSqR;
			}
		}

		public void WRFQiHBTiHTxzhBXcGRzCalCNF()
		{
			lOmtwKWetNmUEsKoXlYsIGMqOSm.SetUpdateLoop(ReInput.currentUpdateLoop);
			VjUBIeINpBMTOJuGDDvIKPqADtPr(uusEcgeppnkfxZzSaLjQJXqkcop);
			if (drjuHMWcKdKlbemNoyjAmboUjNJK == null)
			{
				return;
			}
			while (true)
			{
				int num = -760137670;
				while (true)
				{
					switch (num ^ -760137672)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0042;
					case 1:
						return;
					}
					break;
					IL_0042:
					drjuHMWcKdKlbemNoyjAmboUjNJK.OKHZGFMfxtklwLbZuCziRQFTDNac(ReInput.realTime);
					num = -760137671;
				}
			}
		}

		public void aqqkTdOMGLHPIIcYrYTpjUXAOZk()
		{
			lOmtwKWetNmUEsKoXlYsIGMqOSm.Current.ClearWasTrueThisFrame();
		}

		public void OPrDnVhLcontoTptCznHaDrwNsAh()
		{
			tNTCfSzrXJZuOnbCfNhelnFFgApE = true;
		}

		public void xqyuuQSofyjoJulEXgAcFSYaDtu()
		{
			tNTCfSzrXJZuOnbCfNhelnFFgApE = false;
			IbWidGCHJzvyGGwvigfCOXYPcWYT();
		}

		public void sHFWIJnFHmHJYIoFEDYPzPHrHZM(JEiBJdqVetCaYhzGImdkvLHTeQyH P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_003d;
			IL_0003:
			int num = 1042898256;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x3E295D52)
			{
			case 3:
				break;
			case 2:
				return;
			case 5:
				return;
			case 1:
				goto IL_003d;
			case 4:
				goto IL_0049;
			default:
			{
				float realTime = ReInput.realTime;
				lock (jkLokmyNuOlUdpUyyeSnDVevISp)
				{
					lock (P_0.jkLokmyNuOlUdpUyyeSnDVevISp)
					{
						lOmtwKWetNmUEsKoXlYsIGMqOSm.Import(P_0.lOmtwKWetNmUEsKoXlYsIGMqOSm);
						while (true)
						{
							int num2 = 1042898257;
							while (true)
							{
								switch (num2 ^ 0x3E295D52)
								{
								case 4:
									break;
								case 3:
									hmAIFTqyJhtHhQObXTFjgSWZcpk(P_0.uusEcgeppnkfxZzSaLjQJXqkcop, realTime, siQVDcvmheIRNToTkUevWkMUmhZ);
									rqoXbSKhYdYHKMCJaGaXwTaoFLI(siQVDcvmheIRNToTkUevWkMUmhZ, uusEcgeppnkfxZzSaLjQJXqkcop);
									num2 = 1042898256;
									continue;
								case 1:
									klbCRyuWDYuOnexJoneNOUyWWSB = drjuHMWcKdKlbemNoyjAmboUjNJK.state;
									num2 = 1042898258;
									continue;
								case 2:
								{
									hmAIFTqyJhtHhQObXTFjgSWZcpk(P_0.CdNBOUzjNQHkoHsKxSFkQpBNaIxm, realTime, siQVDcvmheIRNToTkUevWkMUmhZ);
									rqoXbSKhYdYHKMCJaGaXwTaoFLI(siQVDcvmheIRNToTkUevWkMUmhZ, CdNBOUzjNQHkoHsKxSFkQpBNaIxm);
									drjuHMWcKdKlbemNoyjAmboUjNJK = eYQAacJaiYXVekhMtyuASsXijDU.FpyjssVeaQmrgiExuuKkNEPyEXF(P_0.drjuHMWcKdKlbemNoyjAmboUjNJK, uusEcgeppnkfxZzSaLjQJXqkcop);
									int num3;
									if (drjuHMWcKdKlbemNoyjAmboUjNJK == null)
									{
										num2 = 1042898258;
										num3 = num2;
									}
									else
									{
										num2 = 1042898259;
										num3 = num2;
									}
									continue;
								}
								default:
									tNTCfSzrXJZuOnbCfNhelnFFgApE = P_0.tNTCfSzrXJZuOnbCfNhelnFFgApE;
									return;
								}
								break;
							}
						}
					}
				}
			}
			}
			goto IL_0003;
			IL_003d:
			if (P_0 == this)
			{
				return;
			}
			goto IL_0049;
			IL_0049:
			int num4;
			if (P_0.nzQPtryKaFyOknbFWLAdBHgWTek != nzQPtryKaFyOknbFWLAdBHgWTek)
			{
				num = 1042898263;
				num4 = num;
			}
			else
			{
				num = 1042898258;
				num4 = num;
			}
			goto IL_0008;
		}

		public void FADRItgConDiBPwOnuWeUubpqrE(int P_0, int P_1, int P_2, float P_3)
		{
			drjuHMWcKdKlbemNoyjAmboUjNJK = new eYQAacJaiYXVekhMtyuASsXijDU(uusEcgeppnkfxZzSaLjQJXqkcop, P_0, P_1, P_2, P_3);
			klbCRyuWDYuOnexJoneNOUyWWSB = drjuHMWcKdKlbemNoyjAmboUjNJK.state;
		}

		private void JSZvpcfgZVssNtfXMVqTmNXDSqR()
		{
			if (!tNTCfSzrXJZuOnbCfNhelnFFgApE)
			{
				return;
			}
			lock (jkLokmyNuOlUdpUyyeSnDVevISp)
			{
				float realTime;
				try
				{
					GopNkYanAGUkOmQwUJuTJxkowKA.ehCWKYDEXcWiwffbkCGneErfjPbB(CdNBOUzjNQHkoHsKxSFkQpBNaIxm);
					realTime = ReInput.realTime;
				}
				catch
				{
					return;
				}
				hmAIFTqyJhtHhQObXTFjgSWZcpk(CdNBOUzjNQHkoHsKxSFkQpBNaIxm, realTime, siQVDcvmheIRNToTkUevWkMUmhZ);
				cEYnsvdZEgpKUOcsxEpoXmVeOaF.Write(siQVDcvmheIRNToTkUevWkMUmhZ, 268);
			}
		}

		private unsafe void VjUBIeINpBMTOJuGDDvIKPqADtPr(POJetljaOyAGVgWkwdAAfDSJZTf P_0)
		{
			int num = cEYnsvdZEgpKUOcsxEpoXmVeOaF.StartRead() / 268;
			if (num == 0)
			{
				return;
			}
			bool[] buttons = P_0.Buttons;
			while (cEYnsvdZEgpKUOcsxEpoXmVeOaF.Read() > 0)
			{
				if (num > 1)
				{
					for (int i = 0; i < nzQPtryKaFyOknbFWLAdBHgWTek; i++)
					{
						buttons[i] = rXYbyQgsCXdWzmrqPlgwHHWWNvN[i] != 0;
					}
				}
				else
				{
					rqoXbSKhYdYHKMCJaGaXwTaoFLI(rXYbyQgsCXdWzmrqPlgwHHWWNvN, P_0);
				}
				float timestamp;
				fixed (byte* ptr = rXYbyQgsCXdWzmrqPlgwHHWWNvN)
				{
					timestamp = ((float*)ptr)[66];
				}
				for (int j = 0; j < nzQPtryKaFyOknbFWLAdBHgWTek; j++)
				{
					lOmtwKWetNmUEsKoXlYsIGMqOSm.SetValue(j, buttons[j], timestamp);
				}
				num--;
			}
		}

		private unsafe void rqoXbSKhYdYHKMCJaGaXwTaoFLI(byte[] P_0, POJetljaOyAGVgWkwdAAfDSJZTf P_1)
		{
			fixed (byte* ptr = P_0)
			{
				int* ptr2 = (int*)ptr;
				int[] pointOfViewControllers = P_1.PointOfViewControllers;
				int[] accelerationSliders = P_1.AccelerationSliders;
				int[] forceSliders = P_1.ForceSliders;
				int[] sliders = P_1.Sliders;
				int[] velocitySliders = P_1.VelocitySliders;
				fixed (bool* buttons = P_1.Buttons)
				{
					Marshal.Copy(P_0, 0, (IntPtr)buttons, 128);
				}
				ptr2 += 32;
				for (int i = 0; i < 2; i++)
				{
					accelerationSliders[i] = *ptr2;
					ptr2++;
				}
				P_1.AccelerationX = *ptr2;
				ptr2++;
				P_1.AccelerationY = *ptr2;
				ptr2++;
				P_1.AccelerationZ = *ptr2;
				ptr2++;
				P_1.AngularAccelerationX = *ptr2;
				ptr2++;
				P_1.AngularAccelerationY = *ptr2;
				ptr2++;
				P_1.AngularAccelerationZ = *ptr2;
				ptr2++;
				P_1.AngularVelocityX = *ptr2;
				ptr2++;
				P_1.AngularVelocityY = *ptr2;
				ptr2++;
				P_1.AngularVelocityZ = *ptr2;
				ptr2++;
				for (int j = 0; j < 2; j++)
				{
					forceSliders[j] = *ptr2;
					ptr2++;
				}
				P_1.ForceX = *ptr2;
				ptr2++;
				P_1.ForceY = *ptr2;
				ptr2++;
				P_1.ForceZ = *ptr2;
				ptr2++;
				for (int k = 0; k < 2; k++)
				{
					pointOfViewControllers[k] = *ptr2;
					ptr2++;
				}
				P_1.RotationX = *ptr2;
				ptr2++;
				P_1.RotationY = *ptr2;
				ptr2++;
				P_1.RotationZ = *ptr2;
				ptr2++;
				for (int l = 0; l < 2; l++)
				{
					sliders[l] = *ptr2;
					ptr2++;
				}
				P_1.TorqueX = *ptr2;
				ptr2++;
				P_1.TorqueY = *ptr2;
				ptr2++;
				P_1.TorqueZ = *ptr2;
				ptr2++;
				for (int m = 0; m < 2; m++)
				{
					velocitySliders[m] = *ptr2;
					ptr2++;
				}
				P_1.VelocityX = *ptr2;
				ptr2++;
				P_1.VelocityY = *ptr2;
				ptr2++;
				P_1.VelocityZ = *ptr2;
				ptr2++;
				P_1.X = *ptr2;
				ptr2++;
				P_1.Y = *ptr2;
				ptr2++;
				P_1.Z = *ptr2;
				ptr2++;
			}
		}

		private unsafe void hmAIFTqyJhtHhQObXTFjgSWZcpk(POJetljaOyAGVgWkwdAAfDSJZTf P_0, float P_1, byte[] P_2)
		{
			fixed (byte* ptr = P_2)
			{
				int* ptr2 = (int*)ptr;
				int[] pointOfViewControllers = P_0.PointOfViewControllers;
				int[] accelerationSliders = P_0.AccelerationSliders;
				int[] forceSliders = P_0.ForceSliders;
				int[] sliders = P_0.Sliders;
				int[] velocitySliders = P_0.VelocitySliders;
				fixed (bool* buttons = P_0.Buttons)
				{
					Marshal.Copy((IntPtr)buttons, P_2, 0, 128);
				}
				ptr2 += 32;
				for (int i = 0; i < 2; i++)
				{
					*ptr2 = accelerationSliders[i];
					ptr2++;
				}
				*ptr2 = P_0.AccelerationX;
				ptr2++;
				*ptr2 = P_0.AccelerationY;
				ptr2++;
				*ptr2 = P_0.AccelerationZ;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationX;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationY;
				ptr2++;
				*ptr2 = P_0.AngularAccelerationZ;
				ptr2++;
				*ptr2 = P_0.AngularVelocityX;
				ptr2++;
				*ptr2 = P_0.AngularVelocityY;
				ptr2++;
				*ptr2 = P_0.AngularVelocityZ;
				ptr2++;
				for (int j = 0; j < 2; j++)
				{
					*ptr2 = forceSliders[j];
					ptr2++;
				}
				*ptr2 = P_0.ForceX;
				ptr2++;
				*ptr2 = P_0.ForceY;
				ptr2++;
				*ptr2 = P_0.ForceZ;
				ptr2++;
				for (int k = 0; k < 2; k++)
				{
					*ptr2 = pointOfViewControllers[k];
					ptr2++;
				}
				*ptr2 = P_0.RotationX;
				ptr2++;
				*ptr2 = P_0.RotationY;
				ptr2++;
				*ptr2 = P_0.RotationZ;
				ptr2++;
				for (int l = 0; l < 2; l++)
				{
					*ptr2 = sliders[l];
					ptr2++;
				}
				*ptr2 = P_0.TorqueX;
				ptr2++;
				*ptr2 = P_0.TorqueY;
				ptr2++;
				*ptr2 = P_0.TorqueZ;
				ptr2++;
				for (int m = 0; m < 2; m++)
				{
					*ptr2 = velocitySliders[m];
					ptr2++;
				}
				*ptr2 = P_0.VelocityX;
				ptr2++;
				*ptr2 = P_0.VelocityY;
				ptr2++;
				*ptr2 = P_0.VelocityZ;
				ptr2++;
				*ptr2 = P_0.X;
				ptr2++;
				*ptr2 = P_0.Y;
				ptr2++;
				*ptr2 = P_0.Z;
				ptr2++;
				*(float*)ptr2 = P_1;
				ptr2++;
			}
		}

		private void IbWidGCHJzvyGGwvigfCOXYPcWYT()
		{
			lock (jkLokmyNuOlUdpUyyeSnDVevISp)
			{
				cEYnsvdZEgpKUOcsxEpoXmVeOaF.Clear();
				fWzuAFjFXxdRoqxypOAIFkBEHOX(CdNBOUzjNQHkoHsKxSFkQpBNaIxm);
				while (true)
				{
					int num = 1672691814;
					while (true)
					{
						switch (num ^ 0x63B34067)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0042;
						case 2:
							return;
						}
						break;
						IL_0042:
						fWzuAFjFXxdRoqxypOAIFkBEHOX(uusEcgeppnkfxZzSaLjQJXqkcop);
						num = 1672691813;
					}
				}
			}
		}

		private void fWzuAFjFXxdRoqxypOAIFkBEHOX(POJetljaOyAGVgWkwdAAfDSJZTf P_0)
		{
			if (P_0 != null)
			{
				Array.Clear(P_0.Buttons, 0, 128);
				Array.Clear(P_0.AccelerationSliders, 0, 2);
				P_0.AccelerationX = 0;
				P_0.AccelerationY = 0;
				P_0.AccelerationZ = 0;
				P_0.AngularAccelerationX = 0;
				P_0.AngularAccelerationY = 0;
				P_0.AngularAccelerationZ = 0;
				P_0.AngularVelocityX = 0;
				P_0.AngularVelocityY = 0;
				P_0.AngularVelocityZ = 0;
				Array.Clear(P_0.ForceSliders, 0, 2);
				P_0.ForceX = 0;
				P_0.ForceY = 0;
				P_0.ForceZ = 0;
				for (int i = 0; i < 2; i++)
				{
					P_0.PointOfViewControllers[i] = -1;
				}
				P_0.RotationX = 0;
				P_0.RotationY = 0;
				P_0.RotationZ = 0;
				Array.Clear(P_0.Sliders, 0, 2);
				P_0.TorqueX = 0;
				P_0.TorqueY = 0;
				P_0.TorqueZ = 0;
				Array.Clear(P_0.VelocitySliders, 0, 2);
				P_0.VelocityX = 0;
				P_0.VelocityY = 0;
				P_0.VelocityZ = 0;
				P_0.X = 0;
				P_0.Y = 0;
				P_0.Z = 0;
			}
		}

		public void Dispose()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
			GC.SuppressFinalize(this);
		}

		~JEiBJdqVetCaYhzGImdkvLHTeQyH()
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
				int num;
				int num2;
				if (!P_0)
				{
					num = 508633325;
					num2 = num;
				}
				else
				{
					num = 508633327;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x1E5120EC)
					{
					case 4:
						num = 508633326;
						continue;
					case 2:
						break;
					case 3:
						xqyuuQSofyjoJulEXgAcFSYaDtu();
						num = 508633325;
						continue;
					case 1:
						if (pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread != null)
						{
							pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread.ThreadUpdateEvent -= JSZvpcfgZVssNtfXMVqTmNXDSqR;
							num = 508633324;
							continue;
						}
						goto default;
					default:
						nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
						return;
					}
					break;
				}
			}
		}
	}

	private class eYQAacJaiYXVekhMtyuASsXijDU
	{
		private POJetljaOyAGVgWkwdAAfDSJZTf AQQBuhPBkvEbnDpgCTiKqhsmVHn;

		private plIFIZcuOyAqDofRywyemFIDYuz aNxuOwNkMnMrcfIRbzZqikbRpVP;

		private int UFMyvZuOvGRLlrHRlTyYGrnFbXG;

		private int XXRwDByKoXBzHsHZofTwQeEjpsq;

		private int FHKvoADmYLeloiYqNWlLablZoCLb;

		private float NBxnxSmHhZCLsrJycOsQspCTAJU;

		public POJetljaOyAGVgWkwdAAfDSJZTf state
		{
			get
			{
				return AQQBuhPBkvEbnDpgCTiKqhsmVHn;
			}
		}

		public static eYQAacJaiYXVekhMtyuASsXijDU FpyjssVeaQmrgiExuuKkNEPyEXF(eYQAacJaiYXVekhMtyuASsXijDU P_0, POJetljaOyAGVgWkwdAAfDSJZTf P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new eYQAacJaiYXVekhMtyuASsXijDU(P_0, P_1);
		}

		public eYQAacJaiYXVekhMtyuASsXijDU(POJetljaOyAGVgWkwdAAfDSJZTf state, int axisMin, int axisMax, int axisZero, float eventTimeout)
			: this(axisMin, axisMax, axisZero, eventTimeout)
		{
			aNxuOwNkMnMrcfIRbzZqikbRpVP = new plIFIZcuOyAqDofRywyemFIDYuz(state);
			AQQBuhPBkvEbnDpgCTiKqhsmVHn = new POJetljaOyAGVgWkwdAAfDSJZTf();
		}

		private eYQAacJaiYXVekhMtyuASsXijDU(eYQAacJaiYXVekhMtyuASsXijDU source, POJetljaOyAGVgWkwdAAfDSJZTf state)
			: this(state, source.UFMyvZuOvGRLlrHRlTyYGrnFbXG, source.XXRwDByKoXBzHsHZofTwQeEjpsq, source.FHKvoADmYLeloiYqNWlLablZoCLb, source.NBxnxSmHhZCLsrJycOsQspCTAJU)
		{
			RtgGaDkSVkhbZAgNmFrINPvRAMMC(source);
		}

		private eYQAacJaiYXVekhMtyuASsXijDU(int axisMin, int axisMax, int axisZero, float axisTimeout)
		{
			UFMyvZuOvGRLlrHRlTyYGrnFbXG = axisMin;
			XXRwDByKoXBzHsHZofTwQeEjpsq = axisMax;
			FHKvoADmYLeloiYqNWlLablZoCLb = axisZero;
			NBxnxSmHhZCLsrJycOsQspCTAJU = axisTimeout;
		}

		public void OKHZGFMfxtklwLbZuCziRQFTDNac(float P_0)
		{
			aNxuOwNkMnMrcfIRbzZqikbRpVP.OKHZGFMfxtklwLbZuCziRQFTDNac(P_0);
			if (!aNxuOwNkMnMrcfIRbzZqikbRpVP.valueChanged)
			{
				if (P_0 >= aNxuOwNkMnMrcfIRbzZqikbRpVP.lastChangedTimestamp + NBxnxSmHhZCLsrJycOsQspCTAJU)
				{
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.fWzuAFjFXxdRoqxypOAIFkBEHOX();
					goto IL_003f;
				}
				return;
			}
			goto IL_049b;
			IL_0044:
			int num;
			int num7 = default(int);
			POJetljaOyAGVgWkwdAAfDSJZTf changedState = default(POJetljaOyAGVgWkwdAAfDSJZTf);
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			POJetljaOyAGVgWkwdAAfDSJZTf sourceState = default(POJetljaOyAGVgWkwdAAfDSJZTf);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x74CC740C)
				{
				case 6:
					break;
				default:
					return;
				case 16:
					if (num7 >= AQQBuhPBkvEbnDpgCTiKqhsmVHn.AccelerationSliders.Length)
					{
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.ForceX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.ForceX);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.ForceY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.ForceY);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.ForceZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.ForceZ);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.TorqueX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.TorqueX);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.TorqueY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.TorqueY);
						num = 1959556125;
						continue;
					}
					goto case 18;
				case 17:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.TorqueZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.TorqueZ);
					num3 = 0;
					num = 1959556100;
					continue;
				case 8:
					goto IL_016d;
				case 7:
					num5++;
					num = 1959556109;
					continue;
				case 22:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.PointOfViewControllers[num4] = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.PointOfViewControllers[num4]);
					num = 1959556097;
					continue;
				case 3:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.Buttons[num6] = sourceState.Buttons[num6];
					num = 1959556096;
					continue;
				case 9:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.Sliders[num5] = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.Sliders[num5]);
					num = 1959556107;
					continue;
				case 14:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.VelocitySliders[num2] = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.VelocitySliders[num2]);
					num2++;
					num = 1959556099;
					continue;
				case 19:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.ForceSliders[num3] = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.ForceSliders[num3]);
					num3++;
					num = 1959556100;
					continue;
				case 12:
					num6++;
					num = 1959556120;
					continue;
				case 21:
					goto IL_0275;
				case 5:
					num = 1959556109;
					continue;
				case 23:
					return;
				case 20:
					if (num6 >= AQQBuhPBkvEbnDpgCTiKqhsmVHn.Buttons.Length)
					{
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.VelocityX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.VelocityX);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.VelocityY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.VelocityY);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.VelocityZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.VelocityZ);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularVelocityX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularVelocityX);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularVelocityY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularVelocityY);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularVelocityZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularVelocityZ);
						num2 = 0;
						num = 1959556099;
						continue;
					}
					goto case 3;
				case 18:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.AccelerationSliders[num7] = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AccelerationSliders[num7]);
					num7++;
					num = 1959556124;
					continue;
				case 2:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.X = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.X);
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.Y = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.Y);
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.Z = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.Z);
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.RotationX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.RotationX);
					num = 1959556108;
					continue;
				case 11:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularAccelerationY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularAccelerationY);
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularAccelerationZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularAccelerationZ);
					num7 = 0;
					num = 1959556124;
					continue;
				case 1:
					if (num5 >= AQQBuhPBkvEbnDpgCTiKqhsmVHn.Sliders.Length)
					{
						num4 = 0;
						num = 1959556121;
						continue;
					}
					goto case 9;
				case 4:
					num6 = 0;
					num = 1959556120;
					continue;
				case 0:
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.RotationY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.RotationY);
					AQQBuhPBkvEbnDpgCTiKqhsmVHn.RotationZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.RotationZ);
					num5 = 0;
					num = 1959556105;
					continue;
				case 13:
					num4++;
					num = 1959556121;
					continue;
				case 24:
					goto IL_049b;
				case 15:
					if (num2 >= AQQBuhPBkvEbnDpgCTiKqhsmVHn.VelocitySliders.Length)
					{
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AccelerationX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AccelerationX);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AccelerationY = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AccelerationY);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AccelerationZ = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AccelerationZ);
						AQQBuhPBkvEbnDpgCTiKqhsmVHn.AngularAccelerationX = TUCCQSywVkXQVAClWcyYbUoTjhxJ(changedState.AngularAccelerationX);
						num = 1959556103;
						continue;
					}
					goto case 14;
				case 10:
					return;
				}
				break;
				IL_0275:
				int num8;
				if (num4 < AQQBuhPBkvEbnDpgCTiKqhsmVHn.PointOfViewControllers.Length)
				{
					num = 1959556122;
					num8 = num;
				}
				else
				{
					num = 1959556104;
					num8 = num;
				}
				continue;
				IL_016d:
				int num9;
				if (num3 < AQQBuhPBkvEbnDpgCTiKqhsmVHn.ForceSliders.Length)
				{
					num = 1959556127;
					num9 = num;
				}
				else
				{
					num = 1959556102;
					num9 = num;
				}
			}
			goto IL_003f;
			IL_049b:
			changedState = aNxuOwNkMnMrcfIRbzZqikbRpVP.changedState;
			sourceState = aNxuOwNkMnMrcfIRbzZqikbRpVP.sourceState;
			num = 1959556110;
			goto IL_0044;
			IL_003f:
			num = 1959556123;
			goto IL_0044;
		}

		public void RtgGaDkSVkhbZAgNmFrINPvRAMMC(eYQAacJaiYXVekhMtyuASsXijDU P_0)
		{
			AQQBuhPBkvEbnDpgCTiKqhsmVHn.RtgGaDkSVkhbZAgNmFrINPvRAMMC(P_0.AQQBuhPBkvEbnDpgCTiKqhsmVHn);
			aNxuOwNkMnMrcfIRbzZqikbRpVP.RtgGaDkSVkhbZAgNmFrINPvRAMMC(P_0.aNxuOwNkMnMrcfIRbzZqikbRpVP);
			UFMyvZuOvGRLlrHRlTyYGrnFbXG = P_0.UFMyvZuOvGRLlrHRlTyYGrnFbXG;
			XXRwDByKoXBzHsHZofTwQeEjpsq = P_0.XXRwDByKoXBzHsHZofTwQeEjpsq;
			FHKvoADmYLeloiYqNWlLablZoCLb = P_0.FHKvoADmYLeloiYqNWlLablZoCLb;
			NBxnxSmHhZCLsrJycOsQspCTAJU = P_0.NBxnxSmHhZCLsrJycOsQspCTAJU;
		}

		private int TUCCQSywVkXQVAClWcyYbUoTjhxJ(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, UFMyvZuOvGRLlrHRlTyYGrnFbXG, XXRwDByKoXBzHsHZofTwQeEjpsq, -65535, 65535);
		}
	}

	private class plIFIZcuOyAqDofRywyemFIDYuz
	{
		private float urtBfQOEFguSLmTeSeGezKZCroD;

		private POJetljaOyAGVgWkwdAAfDSJZTf DBtESFXFPndrqQDwpUqahmiVcmV;

		private POJetljaOyAGVgWkwdAAfDSJZTf CmtOqmLgqCbTNcgkiXHsCdWMWFxq;

		private POJetljaOyAGVgWkwdAAfDSJZTf ACTvGfPFinWFLpjsDMUKrJQNEtJK;

		private bool ntMqOTmXAUudDwvbMpLZPfaqGmx;

		private float rCNSTRKkChqiiwcZhJJYzbaaPhD;

		public POJetljaOyAGVgWkwdAAfDSJZTf sourceState
		{
			get
			{
				return DBtESFXFPndrqQDwpUqahmiVcmV;
			}
		}

		public POJetljaOyAGVgWkwdAAfDSJZTf changedState
		{
			get
			{
				return ACTvGfPFinWFLpjsDMUKrJQNEtJK;
			}
		}

		public bool valueChanged
		{
			get
			{
				return ntMqOTmXAUudDwvbMpLZPfaqGmx;
			}
		}

		public float lastChangedTimestamp
		{
			get
			{
				return rCNSTRKkChqiiwcZhJJYzbaaPhD;
			}
		}

		public plIFIZcuOyAqDofRywyemFIDYuz(POJetljaOyAGVgWkwdAAfDSJZTf sourceState)
		{
			DBtESFXFPndrqQDwpUqahmiVcmV = sourceState;
			CmtOqmLgqCbTNcgkiXHsCdWMWFxq = new POJetljaOyAGVgWkwdAAfDSJZTf();
			ACTvGfPFinWFLpjsDMUKrJQNEtJK = new POJetljaOyAGVgWkwdAAfDSJZTf();
		}

		public void OKHZGFMfxtklwLbZuCziRQFTDNac(float P_0)
		{
			urtBfQOEFguSLmTeSeGezKZCroD = P_0;
			ACTvGfPFinWFLpjsDMUKrJQNEtJK.X = DBtESFXFPndrqQDwpUqahmiVcmV.X - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.X;
			ACTvGfPFinWFLpjsDMUKrJQNEtJK.Y = DBtESFXFPndrqQDwpUqahmiVcmV.Y - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.Y;
			ACTvGfPFinWFLpjsDMUKrJQNEtJK.Z = DBtESFXFPndrqQDwpUqahmiVcmV.Z - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.Z;
			ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationX = DBtESFXFPndrqQDwpUqahmiVcmV.RotationX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.RotationX;
			ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationY = DBtESFXFPndrqQDwpUqahmiVcmV.RotationY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.RotationY;
			int num2 = default(int);
			int num3 = default(int);
			int num8 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num = -1983510148;
				while (true)
				{
					switch (num ^ -1983510161)
					{
					case 22:
						break;
					default:
						return;
					case 14:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationSliders[num2] = DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationSliders[num2] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AccelerationSliders[num2];
						num = -1983510176;
						continue;
					case 4:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityZ = DBtESFXFPndrqQDwpUqahmiVcmV.AngularVelocityZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularVelocityZ;
						num = -1983510166;
						continue;
					case 8:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.Sliders[num3] = DBtESFXFPndrqQDwpUqahmiVcmV.Sliders[num3] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.Sliders[num3];
						num3++;
						num = -1983510162;
						continue;
					case 18:
					{
						int num9;
						if (ntMqOTmXAUudDwvbMpLZPfaqGmx)
						{
							num = -1983510174;
							num9 = num;
						}
						else
						{
							num = -1983510170;
							num9 = num;
						}
						continue;
					}
					case 2:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueZ = DBtESFXFPndrqQDwpUqahmiVcmV.TorqueZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.TorqueZ;
						num8 = 0;
						num = -1983510150;
						continue;
					case 1:
						if (num3 >= DBtESFXFPndrqQDwpUqahmiVcmV.Sliders.Length)
						{
							num4 = 0;
							num = -1983510167;
							continue;
						}
						goto case 8;
					case 19:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationZ = DBtESFXFPndrqQDwpUqahmiVcmV.RotationZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.RotationZ;
						num3 = 0;
						num = -1983510162;
						continue;
					case 20:
						num = -1983510172;
						continue;
					case 16:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.PointOfViewControllers[num4] = DBtESFXFPndrqQDwpUqahmiVcmV.PointOfViewControllers[num4] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.PointOfViewControllers[num4];
						num4++;
						num = -1983510154;
						continue;
					case 15:
						num2++;
						num = -1983510172;
						continue;
					case 12:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.Buttons[num6] = DBtESFXFPndrqQDwpUqahmiVcmV.Buttons[num6] != CmtOqmLgqCbTNcgkiXHsCdWMWFxq.Buttons[num6];
						num = -1983510146;
						continue;
					case 25:
						if (num4 >= DBtESFXFPndrqQDwpUqahmiVcmV.PointOfViewControllers.Length)
						{
							num6 = 0;
							num = -1983510161;
							continue;
						}
						goto case 16;
					case 0:
						if (num6 >= DBtESFXFPndrqQDwpUqahmiVcmV.Buttons.Length)
						{
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityX = DBtESFXFPndrqQDwpUqahmiVcmV.VelocityX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.VelocityX;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityY = DBtESFXFPndrqQDwpUqahmiVcmV.VelocityY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.VelocityY;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityZ = DBtESFXFPndrqQDwpUqahmiVcmV.VelocityZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.VelocityZ;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityX = DBtESFXFPndrqQDwpUqahmiVcmV.AngularVelocityX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularVelocityX;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityY = DBtESFXFPndrqQDwpUqahmiVcmV.AngularVelocityY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularVelocityY;
							num = -1983510165;
							continue;
						}
						goto case 12;
					case 23:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationY = DBtESFXFPndrqQDwpUqahmiVcmV.AngularAccelerationY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularAccelerationY;
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationZ = DBtESFXFPndrqQDwpUqahmiVcmV.AngularAccelerationZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularAccelerationZ;
						num2 = 0;
						num = -1983510149;
						continue;
					case 21:
						if (num8 >= DBtESFXFPndrqQDwpUqahmiVcmV.ForceSliders.Length)
						{
							ntMqOTmXAUudDwvbMpLZPfaqGmx = LMgFGQGbhkQGddPcTcZCmevcMnre();
							num = -1983510147;
							continue;
						}
						goto case 10;
					case 3:
					{
						int num7;
						if (num5 < DBtESFXFPndrqQDwpUqahmiVcmV.VelocitySliders.Length)
						{
							num = -1983510168;
							num7 = num;
						}
						else
						{
							num = -1983510153;
							num7 = num;
						}
						continue;
					}
					case 13:
						rCNSTRKkChqiiwcZhJJYzbaaPhD = P_0;
						CmtOqmLgqCbTNcgkiXHsCdWMWFxq.RtgGaDkSVkhbZAgNmFrINPvRAMMC(DBtESFXFPndrqQDwpUqahmiVcmV);
						num = -1983510170;
						continue;
					case 7:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocitySliders[num5] = DBtESFXFPndrqQDwpUqahmiVcmV.VelocitySliders[num5] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.VelocitySliders[num5];
						num5++;
						num = -1983510164;
						continue;
					case 17:
						num6++;
						num = -1983510161;
						continue;
					case 5:
						num5 = 0;
						num = -1983510164;
						continue;
					case 10:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceSliders[num8] = DBtESFXFPndrqQDwpUqahmiVcmV.ForceSliders[num8] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.ForceSliders[num8];
						num8++;
						num = -1983510150;
						continue;
					case 11:
						if (num2 >= DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationSliders.Length)
						{
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceX = DBtESFXFPndrqQDwpUqahmiVcmV.ForceX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.ForceX;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceY = DBtESFXFPndrqQDwpUqahmiVcmV.ForceY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.ForceY;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceZ = DBtESFXFPndrqQDwpUqahmiVcmV.ForceZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.ForceZ;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueX = DBtESFXFPndrqQDwpUqahmiVcmV.TorqueX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.TorqueX;
							ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueY = DBtESFXFPndrqQDwpUqahmiVcmV.TorqueY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.TorqueY;
							num = -1983510163;
							continue;
						}
						goto case 14;
					case 24:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationX = DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AccelerationX;
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationY = DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationY - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AccelerationY;
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationZ = DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationZ - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AccelerationZ;
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationX = DBtESFXFPndrqQDwpUqahmiVcmV.AngularAccelerationX - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AngularAccelerationX;
						num = -1983510152;
						continue;
					case 6:
						num = -1983510154;
						continue;
					case 9:
						return;
					}
					break;
				}
			}
		}

		public void RtgGaDkSVkhbZAgNmFrINPvRAMMC(plIFIZcuOyAqDofRywyemFIDYuz P_0)
		{
			urtBfQOEFguSLmTeSeGezKZCroD = P_0.urtBfQOEFguSLmTeSeGezKZCroD;
			while (true)
			{
				int num = 566408583;
				while (true)
				{
					switch (num ^ 0x21C2B586)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						CmtOqmLgqCbTNcgkiXHsCdWMWFxq.RtgGaDkSVkhbZAgNmFrINPvRAMMC(P_0.CmtOqmLgqCbTNcgkiXHsCdWMWFxq);
						num = 566408580;
						continue;
					case 2:
						ACTvGfPFinWFLpjsDMUKrJQNEtJK.RtgGaDkSVkhbZAgNmFrINPvRAMMC(P_0.ACTvGfPFinWFLpjsDMUKrJQNEtJK);
						num = 566408582;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private bool LMgFGQGbhkQGddPcTcZCmevcMnre()
		{
			if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.Y != 0)
			{
				return true;
			}
			if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.Z != 0)
			{
				return true;
			}
			if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationX != 0)
			{
				goto IL_002e;
			}
			if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationY != 0)
			{
				return true;
			}
			if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.RotationZ != 0)
			{
				return true;
			}
			int num = 0;
			int num2 = 1555622874;
			goto IL_0033;
			IL_0033:
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			int num8 = default(int);
			int num6 = default(int);
			while (true)
			{
				switch (num2 ^ 0x5CB8EBDD)
				{
				case 3:
					break;
				case 4:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.Buttons[num4])
					{
						return true;
					}
					num4++;
					num2 = 1555622868;
					continue;
				case 12:
				{
					int num7;
					if (num5 < DBtESFXFPndrqQDwpUqahmiVcmV.VelocitySliders.Length)
					{
						num2 = 1555622863;
						num7 = num2;
					}
					else
					{
						num2 = 1555622856;
						num7 = num2;
					}
					continue;
				}
				case 19:
					ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationSliders[num3] = DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationSliders[num3] - CmtOqmLgqCbTNcgkiXHsCdWMWFxq.AccelerationSliders[num3];
					num2 = 1555622861;
					continue;
				case 25:
				{
					int num9;
					if (num8 < DBtESFXFPndrqQDwpUqahmiVcmV.ForceSliders.Length)
					{
						num2 = 1555622858;
						num9 = num2;
					}
					else
					{
						num2 = 1555622877;
						num9 = num2;
					}
					continue;
				}
				case 22:
					return true;
				case 26:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.Sliders[num] != 0)
					{
						return true;
					}
					num++;
					num2 = 1555622874;
					continue;
				case 21:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationX != 0)
					{
						return true;
					}
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationY != 0)
					{
						num2 = 1555622876;
						continue;
					}
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AccelerationZ != 0)
					{
						return true;
					}
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationX == 0)
					{
						if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationY != 0)
						{
							return true;
						}
						if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularAccelerationZ != 0)
						{
							num2 = 1555622872;
							continue;
						}
						num3 = 0;
						num2 = 1555622875;
					}
					else
					{
						num2 = 1555622879;
					}
					continue;
				case 11:
					num2 = 1555622852;
					continue;
				case 7:
					if (num >= DBtESFXFPndrqQDwpUqahmiVcmV.Sliders.Length)
					{
						num6 = 0;
						num2 = 1555622864;
						continue;
					}
					goto case 26;
				case 2:
					return true;
				case 20:
					return true;
				case 14:
					num2 = 1555622868;
					continue;
				case 13:
					num2 = 1555622869;
					continue;
				case 24:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.PointOfViewControllers[num6] != 0)
					{
						return true;
					}
					num6++;
					num2 = 1555622869;
					continue;
				case 5:
					return true;
				case 15:
					return true;
				case 10:
					return true;
				case 17:
					return true;
				case 23:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceSliders[num8] == 0)
					{
						num8++;
						num2 = 1555622852;
					}
					else
					{
						num2 = 1555622860;
					}
					continue;
				case 8:
					if (num6 >= DBtESFXFPndrqQDwpUqahmiVcmV.PointOfViewControllers.Length)
					{
						num4 = 0;
						num2 = 1555622867;
						continue;
					}
					goto case 24;
				case 6:
					if (num3 >= DBtESFXFPndrqQDwpUqahmiVcmV.AccelerationSliders.Length)
					{
						if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceX == 0)
						{
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceY != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.ForceZ != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueX != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueY != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.TorqueZ != 0)
							{
								return true;
							}
							num8 = 0;
							num2 = 1555622870;
						}
						else
						{
							num2 = 1555622857;
						}
						continue;
					}
					goto case 19;
				case 18:
					if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocitySliders[num5] != 0)
					{
						return true;
					}
					num5++;
					num2 = 1555622865;
					continue;
				case 9:
					if (num4 >= DBtESFXFPndrqQDwpUqahmiVcmV.Buttons.Length)
					{
						if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityX != 0)
						{
							return true;
						}
						if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityY == 0)
						{
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.VelocityZ != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityX != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityY != 0)
							{
								return true;
							}
							if (ACTvGfPFinWFLpjsDMUKrJQNEtJK.AngularVelocityZ != 0)
							{
								num2 = 1555622871;
								continue;
							}
							num5 = 0;
							num2 = 1555622865;
						}
						else
						{
							num2 = 1555622866;
						}
						continue;
					}
					goto case 4;
				case 1:
					return true;
				case 16:
					num3++;
					num2 = 1555622875;
					continue;
				default:
					return false;
				}
				break;
			}
			goto IL_002e;
			IL_002e:
			num2 = 1555622859;
			goto IL_0033;
		}
	}

	private class SNRBnIgKAMRWqTrKMMmcCoNDyKKd
	{
		public enum DIWJVETWaPFFkudLyHFYfVbJqns
		{
			pcWfOxYbvNCAItRmLAyYfYdvnxE = 0,
			JgYTOGxxNXCOjMYfJlJOWIFnveY = 1
		}

		public class AnjAepQmDzjzNYGnHJNnxdhxpUp
		{
			public int OHBcezjWhuCjOisuXXaxDLGlnPLC;

			public Guid AptpRPzwmRXfndEyzaGRSilWIbv;

			public Guid AIefUprvkNeEvLSsrampirFfHMzU;

			public int WppCCSIJiYbWggCDNrMGswGEsUzA;

			public int dhEQLHuCYYGQwdehmJKXAJgttVWs;

			public int aCdTArmyUaJIYSBpkbuJpDufgNGc;

			public int JwvOuylcUYNAjPLMAAlyukWmToj;

			public bool QJuTPVbZPhckxeVMgmaDORJltri(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, DIWJVETWaPFFkudLyHFYfVbJqns P_1)
			{
				if (P_0.rewiredId == OHBcezjWhuCjOisuXXaxDLGlnPLC)
				{
					goto IL_000e;
				}
				int num;
				if (dhEQLHuCYYGQwdehmJKXAJgttVWs != P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs)
				{
					num = -39861016;
					goto IL_0013;
				}
				if (aCdTArmyUaJIYSBpkbuJpDufgNGc != P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc)
				{
					return false;
				}
				if (JwvOuylcUYNAjPLMAAlyukWmToj != P_0.JwvOuylcUYNAjPLMAAlyukWmToj)
				{
					return false;
				}
				switch (P_1)
				{
				case DIWJVETWaPFFkudLyHFYfVbJqns.pcWfOxYbvNCAItRmLAyYfYdvnxE:
					return AptpRPzwmRXfndEyzaGRSilWIbv == P_0.instanceGuid;
				case DIWJVETWaPFFkudLyHFYfVbJqns.JgYTOGxxNXCOjMYfJlJOWIFnveY:
					return AIefUprvkNeEvLSsrampirFfHMzU == P_0.AIefUprvkNeEvLSsrampirFfHMzU;
				default:
					throw new NotImplementedException();
				}
				IL_000e:
				num = -39861013;
				goto IL_0013;
				IL_0013:
				switch (num ^ -39861014)
				{
				case 0:
					break;
				case 1:
					return true;
				default:
					return false;
				}
				goto IL_000e;
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				object[] array2 = default(object[]);
				object[] array6 = default(object[]);
				object[] array5 = default(object[]);
				object obj5 = default(object);
				object[] array4 = default(object[]);
				object obj4 = default(object);
				object[] array3 = default(object[]);
				object[] array = default(object[]);
				while (true)
				{
					int num = -1211826547;
					while (true)
					{
						switch (num ^ -1211826559)
						{
						case 0:
							break;
						case 11:
						{
							array2[3] = "\n";
							text = string.Concat(array2);
							object obj6 = text;
							text = string.Concat(obj6, "hardwareAxisCount = ", dhEQLHuCYYGQwdehmJKXAJgttVWs, "\n");
							object obj7 = text;
							array6 = new object[4] { obj7, null, null, null };
							num = -1211826555;
							continue;
						}
						case 3:
							text = string.Concat(array5);
							num = -1211826557;
							continue;
						case 9:
							array2[2] = WppCCSIJiYbWggCDNrMGswGEsUzA;
							num = -1211826550;
							continue;
						case 6:
							array5[0] = obj5;
							num = -1211826556;
							continue;
						case 4:
							array6[1] = "hardwareButtonCount = ";
							num = -1211826560;
							continue;
						case 10:
							text = string.Concat(array4);
							obj4 = text;
							num = -1211826554;
							continue;
						case 8:
							array5[2] = JwvOuylcUYNAjPLMAAlyukWmToj;
							array5[3] = "\n";
							num = -1211826558;
							continue;
						case 1:
							array6[2] = aCdTArmyUaJIYSBpkbuJpDufgNGc;
							array6[3] = "\n";
							text = string.Concat(array6);
							obj5 = text;
							array5 = new object[4];
							num = -1211826553;
							continue;
						case 5:
							array5[1] = "hardwareHatCount = ";
							num = -1211826551;
							continue;
						case 12:
							array4 = new object[4] { obj, "rewiredId = ", OHBcezjWhuCjOisuXXaxDLGlnPLC, "\n" };
							num = -1211826549;
							continue;
						case 13:
							array3[0] = obj4;
							num = -1211826546;
							continue;
						case 15:
						{
							array3[1] = "instanceGuid = ";
							array3[2] = AptpRPzwmRXfndEyzaGRSilWIbv;
							array3[3] = "\n";
							text = string.Concat(array3);
							object obj3 = text;
							array = new object[4] { obj3, "typeIdentifierGuid = ", AIefUprvkNeEvLSsrampirFfHMzU, null };
							num = -1211826545;
							continue;
						}
						case 7:
							array3 = new object[4];
							num = -1211826548;
							continue;
						case 14:
						{
							array[3] = "\n";
							text = string.Concat(array);
							object obj2 = text;
							array2 = new object[4] { obj2, "lastInputManagerId = ", null, null };
							num = -1211826552;
							continue;
						}
						default:
							return text;
						}
						break;
					}
				}
			}
		}

		private List<AnjAepQmDzjzNYGnHJNnxdhxpUp> hdvnYESDqWrpDISRbrulIlAPAqTj;

		public SNRBnIgKAMRWqTrKMMmcCoNDyKKd()
		{
			while (true)
			{
				int num = -452637405;
				while (true)
				{
					switch (num ^ -452637407)
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
					hdvnYESDqWrpDISRbrulIlAPAqTj = new List<AnjAepQmDzjzNYGnHJNnxdhxpUp>();
					num = -452637408;
				}
			}
		}

		public void xdxZeKjdcofLtxWSQEJXMnutFBg(dIYfxShIDrIIjihOcmVToKsXwFAE P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
				int num = 1883116863;
				while (true)
				{
					switch (num ^ 0x703E1538)
					{
					case 5:
						num = 1883116858;
						continue;
					case 2:
						break;
					case 4:
						num2++;
						num = 1883116862;
						continue;
					case 6:
					{
						int num4;
						if (num2 >= count)
						{
							num = 1883116859;
							num4 = num;
						}
						else
						{
							num = 1883116857;
							num4 = num;
						}
						continue;
					}
					case 0:
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].AptpRPzwmRXfndEyzaGRSilWIbv = P_0.instanceGuid;
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].AIefUprvkNeEvLSsrampirFfHMzU = P_0.AIefUprvkNeEvLSsrampirFfHMzU;
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].WppCCSIJiYbWggCDNrMGswGEsUzA = P_0.inputManagerId;
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].dhEQLHuCYYGQwdehmJKXAJgttVWs = P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs;
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].aCdTArmyUaJIYSBpkbuJpDufgNGc = P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc;
						num = 1883116848;
						continue;
					case 1:
					{
						int num3;
						if (!hdvnYESDqWrpDISRbrulIlAPAqTj[num2].QJuTPVbZPhckxeVMgmaDORJltri(P_0, DIWJVETWaPFFkudLyHFYfVbJqns.pcWfOxYbvNCAItRmLAyYfYdvnxE))
						{
							num = 1883116860;
							num3 = num;
						}
						else
						{
							num = 1883116849;
							num3 = num;
						}
						continue;
					}
					case 9:
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].OHBcezjWhuCjOisuXXaxDLGlnPLC = P_0.rewiredId;
						num = 1883116856;
						continue;
					case 7:
						num2 = 0;
						num = 1883116862;
						continue;
					case 8:
						hdvnYESDqWrpDISRbrulIlAPAqTj[num2].JwvOuylcUYNAjPLMAAlyukWmToj = P_0.JwvOuylcUYNAjPLMAAlyukWmToj;
						TxZIpUDzPauiBdjCLSiYGapVtMo(P_0.rewiredId, P_0.instanceGuid, num2);
						return;
					default:
						hdvnYESDqWrpDISRbrulIlAPAqTj.Add(new AnjAepQmDzjzNYGnHJNnxdhxpUp
						{
							OHBcezjWhuCjOisuXXaxDLGlnPLC = P_0.rewiredId,
							AptpRPzwmRXfndEyzaGRSilWIbv = P_0.instanceGuid,
							AIefUprvkNeEvLSsrampirFfHMzU = P_0.AIefUprvkNeEvLSsrampirFfHMzU,
							WppCCSIJiYbWggCDNrMGswGEsUzA = P_0.inputManagerId,
							dhEQLHuCYYGQwdehmJKXAJgttVWs = P_0.dhEQLHuCYYGQwdehmJKXAJgttVWs,
							aCdTArmyUaJIYSBpkbuJpDufgNGc = P_0.aCdTArmyUaJIYSBpkbuJpDufgNGc,
							JwvOuylcUYNAjPLMAAlyukWmToj = P_0.JwvOuylcUYNAjPLMAAlyukWmToj
						});
						TxZIpUDzPauiBdjCLSiYGapVtMo(P_0.rewiredId, P_0.instanceGuid, hdvnYESDqWrpDISRbrulIlAPAqTj.Count - 1);
						return;
					}
					break;
				}
			}
		}

		public bool QacznVUaOaCwCvKomxmAnPOqZdr(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, DIWJVETWaPFFkudLyHFYfVbJqns P_1)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= count)
				{
					num2 = 1915642038;
					num3 = num2;
				}
				else
				{
					num2 = 1915642039;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x722E60B6)
					{
					case 2:
						num2 = 1915642039;
						continue;
					case 1:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num].QJuTPVbZPhckxeVMgmaDORJltri(P_0, P_1))
						{
							return true;
						}
						num++;
						num2 = 1915642037;
						continue;
					case 3:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public AnjAepQmDzjzNYGnHJNnxdhxpUp GAYuJaWQWiVlljmcwLCVJqAlvzZ(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, DIWJVETWaPFFkudLyHFYfVbJqns P_1)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (hdvnYESDqWrpDISRbrulIlAPAqTj[num].QJuTPVbZPhckxeVMgmaDORJltri(P_0, P_1))
					{
						num2 = 2055705295;
					}
					else
					{
						num++;
						num2 = 2055705292;
					}
					while (true)
					{
						switch (num2 ^ 0x7A8792CE)
						{
						case 0:
							num2 = 2055705293;
							continue;
						case 3:
							break;
						case 1:
							return hdvnYESDqWrpDISRbrulIlAPAqTj[num];
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
								num2 = 2000482038;
								num3 = num2;
							}
							else
							{
								num2 = 2000482032;
								num3 = num2;
							}
							goto IL_0018;
						}
						goto IL_007b;
					}
					goto IL_008e;
					IL_007b:
					hdvnYESDqWrpDISRbrulIlAPAqTj.RemoveAt(num);
					num2 = 2000482038;
					goto IL_0018;
					IL_008e:
					num--;
					num2 = 2000482033;
					goto IL_0018;
					IL_0018:
					while (true)
					{
						switch (num2 ^ 0x773CEEF2)
						{
						case 0:
							num2 = 2000482035;
							continue;
						case 1:
							break;
						case 2:
							goto IL_007b;
						case 4:
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
			object[] array2 = default(object[]);
			int num2 = default(int);
			object obj2 = default(object);
			while (true)
			{
				int num = -1876476678;
				while (true)
				{
					switch (num ^ -1876476680)
					{
					case 3:
						break;
					case 5:
						array2[1] = "Record ";
						array2[2] = num2;
						num = -1876476674;
						continue;
					case 6:
						array2[3] = ":\n";
						text = string.Concat(array2);
						text = text + hdvnYESDqWrpDISRbrulIlAPAqTj[num2].ToString() + "\n\n";
						num2++;
						num = -1876476676;
						continue;
					case 1:
						obj2 = text;
						array2 = new object[4];
						num = -1876476680;
						continue;
					case 2:
						array[2] = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
						array[3] = "\n";
						text = string.Concat(array);
						num2 = 0;
						num = -1876476676;
						continue;
					case 0:
						array2[0] = obj2;
						num = -1876476675;
						continue;
					default:
						if (num2 >= hdvnYESDqWrpDISRbrulIlAPAqTj.Count)
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

	private class yEHdWYdkyWyGSJOAPHTXOhczDmY
	{
		public dIYfxShIDrIIjihOcmVToKsXwFAE PSZKcVVfVmWuwyrmRaPnqSTTRBB;

		public rrkiWNHnEkzBYEXAvbDAWsEtjKd eMSAOLjJyVqyGYNCqvthQlWRDYcs;

		public bool IsValid
		{
			get
			{
				if (PSZKcVVfVmWuwyrmRaPnqSTTRBB != null)
				{
					return eMSAOLjJyVqyGYNCqvthQlWRDYcs != null;
				}
				return false;
			}
		}

		public yEHdWYdkyWyGSJOAPHTXOhczDmY(dIYfxShIDrIIjihOcmVToKsXwFAE joystick, rrkiWNHnEkzBYEXAvbDAWsEtjKd deviceInstance)
		{
			PSZKcVVfVmWuwyrmRaPnqSTTRBB = joystick;
			eMSAOLjJyVqyGYNCqvthQlWRDYcs = deviceInstance;
		}

		public static List<rrkiWNHnEkzBYEXAvbDAWsEtjKd> UieSsnNFHvINJjksbsFwJrDIsvpy(List<yEHdWYdkyWyGSJOAPHTXOhczDmY> P_0)
		{
			if (P_0 == null)
			{
				return new List<rrkiWNHnEkzBYEXAvbDAWsEtjKd>();
			}
			List<rrkiWNHnEkzBYEXAvbDAWsEtjKd> list = new List<rrkiWNHnEkzBYEXAvbDAWsEtjKd>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IsValid)
				{
					list.Add(P_0[i].eMSAOLjJyVqyGYNCqvthQlWRDYcs);
				}
			}
			return list;
		}
	}

	private class ZvhXMLkaLrVnLXNRCrnYxAIOcLD
	{
		public hCkwWPjbZHHQuLPwssAiovZoKVX kjwOerymjUFSmJVvcAkbjKjiVnth;

		public ZvhXMLkaLrVnLXNRCrnYxAIOcLD(hCkwWPjbZHHQuLPwssAiovZoKVX sdxJoystick)
		{
			kjwOerymjUFSmJVvcAkbjKjiVnth = sdxJoystick;
		}
	}

	private class AfFMTnVPQxUPOqejxvzYqfCgiwU
	{
		private SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP cPErUQMyQQeOcFpoAaqqgcGDnYp;

		private SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg gPxtLMVNCvmeZGPesEFNaOrOfDgS;

		private NativeBuffer KrkhvmMqkwmcpCzJkDiQzmIldHfC;

		private int ZxdeZYTjmFLtKTfBipmShpqvEFO;

		public AfFMTnVPQxUPOqejxvzYqfCgiwU()
		{
			cPErUQMyQQeOcFpoAaqqgcGDnYp = new SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP
			{
				SbvjKtRMAnhJrOoaSiNhtdqQEdlB = (uint)Marshal.SizeOf(typeof(SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP)),
				MVhcMlblbUmneTVbxkiaQoRZAMWk = true,
				ZoqJQJdXDyPOhbaEzzCXFpAmLJP = true,
				pSyGmyrRIjyeqJdRkiTbKpzlJgE = false,
				ITogQjdhtEXaYFpYMBbmOJpSDYS = true,
				oFEyQdclJsciZibUoJTArgJtqmj = IntPtr.Zero
			};
			gPxtLMVNCvmeZGPesEFNaOrOfDgS = SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg.QGMHznQHkHQnTPTBloqkWdrurHv();
			KrkhvmMqkwmcpCzJkDiQzmIldHfC = new NativeBuffer((int)gPxtLMVNCvmeZGPesEFNaOrOfDgS.SbvjKtRMAnhJrOoaSiNhtdqQEdlB);
			KrkhvmMqkwmcpCzJkDiQzmIldHfC.Write(gPxtLMVNCvmeZGPesEFNaOrOfDgS.SbvjKtRMAnhJrOoaSiNhtdqQEdlB, 0);
		}

		public bool GdUSUoYPOUWZsVmDJtYnJAXVmkD()
		{
			int num = EgEjAUhxDiCIDqLRLKYENeXGoQHA();
			if (num == ZxdeZYTjmFLtKTfBipmShpqvEFO)
			{
				return false;
			}
			ZxdeZYTjmFLtKTfBipmShpqvEFO = num;
			return true;
		}

		public void iAQSIxHcqRRCHTNIEjSyHMLdVpTN(int P_0)
		{
			ZxdeZYTjmFLtKTfBipmShpqvEFO = P_0;
		}

		private int EgEjAUhxDiCIDqLRLKYENeXGoQHA()
		{
			try
			{
				return qRcrmPWSlvohNRTlmCdEtNVJlYH.POIApcAGjfOoBdAvKfLhVcSifKmd(ref cPErUQMyQQeOcFpoAaqqgcGDnYp, KrkhvmMqkwmcpCzJkDiQzmIldHfC);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum ofeqpRsjofXSwYwacxFrGdeWwcg
	{
		JAPGXbnGLEVcKvOepfYKLDmQrgU = 17,
		UQBduDQfcpFVodDJGKokyQOHOEHN = 18,
		xASCPheTPZjjySaqzxbejdrWIOZ = 19,
		kwXecDUdPYUlNuDiMAoCcCImDZIb = 20,
		dhUtEzDFvpZQnDBlTeAFXyELNJz = 21,
		zYVdxJRhImBRPsxZlpigKIKyrqQ = 22,
		RSYxVUzovUaewdHaxOMnFaSnBhsn = 23,
		hRBNKMrZXnQBptDVtzuNwekIOCP = 24,
		SlnIqwRSRMUekRDlrBdtRtqdwSe = 25,
		aEssYEUSwmmnnJRGohZDlUogiil = 26,
		RRuAazCBOBmPmDtLyBqsTtgxRGXK = 27,
		ewucqLuFeGJENdbcYnPoncBlEqq = 28
	}

	private const FTxufsFYYZLjZuOhPwjajrbMvoj vIQjSgyEOkqgBUaNSsgiNRTOWOD = FTxufsFYYZLjZuOhPwjajrbMvoj.MRqcqejOtASJsQJRNVwXMlVPvNWT;

	private const jQHcAazllAfioxyWFvAxWLMcwIf oHYucWKyfmbaWAdmgUVoqdyyBmpj = jQHcAazllAfioxyWFvAxWLMcwIf.ixnfIgjplOyvFHABieLYYzTzQUKU;

	private IntPtr kBhJxALdxxcEFwejpLfeqaTmQiT;

	private DirectInput fTUmdlBklWTlvmAQYJjrEkdriSN;

	private List<dIYfxShIDrIIjihOcmVToKsXwFAE> SECqOtxIJCMtDAXMpkZHtbqiXBU;

	private int lTHFykxDvdBXxFWZTYErzFFjdVX;

	private SNRBnIgKAMRWqTrKMMmcCoNDyKKd BhZbSIqTJUuvrHhjvLiLwhtaXiV;

	private bool FHTzXxeconPJZctSzyqbRpvkXVQ;

	private bool ydtjoUaZMACQbAJqHjVabQJcAHgE;

	private UpdateLoopSetting ZIxZgRHVxCjXhlcarovUBuZCOqL;

	private Action<int, ControllerDataUpdater> OtrNTBJIBbQldvImDmKCAqMRnke;

	private PlatformInputManager KbZxDysFPLnvPkdChDFikEdaiLpJ;

	private TimerRealTime BAQCuUxBdKKwqZqjVZdkRBTPwCh;

	private global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool> VoIiwUWpoGaVvQsOVAciVQBmthy;

	private int OwMjmoZZHJWflbLcoFaXqkXbfGXF;

	private int YTrkqMmqoBacvniXMdDSHcGseeHl;

	private global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<List<yEHdWYdkyWyGSJOAPHTXOhczDmY>> aigQAbLwpFCjkyEbDcZhCTMWhkgb;

	private AfFMTnVPQxUPOqejxvzYqfCgiwU mAbSqZKATNFUhWPMtuukNHRYGVi;

	private readonly object OwdBRVkoLEeNZyygHCLZABIQljTX = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

	private Func<int> osCAPAIYOEZodlsEwtiFRgmwudTL;

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
			return new InputSourceWrapper<DirectInput>(fTUmdlBklWTlvmAQYJjrEkdriSN);
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.DirectInput;
		}
	}

	public fXpZHAKkyykjjdntipjmCAIqJMD(UpdateLoopSetting updateLoopSetting, bool useXInput, IntPtr windowHandle, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		try
		{
			ZIxZgRHVxCjXhlcarovUBuZCOqL = updateLoopSetting;
			ydtjoUaZMACQbAJqHjVabQJcAHgE = useXInput;
			kBhJxALdxxcEFwejpLfeqaTmQiT = windowHandle;
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			osCAPAIYOEZodlsEwtiFRgmwudTL = getNewJoystickId;
			KbZxDysFPLnvPkdChDFikEdaiLpJ = this;
			fTUmdlBklWTlvmAQYJjrEkdriSN = new DirectInput();
			OtrNTBJIBbQldvImDmKCAqMRnke = UpdateControllerData;
			mAbSqZKATNFUhWPMtuukNHRYGVi = new AfFMTnVPQxUPOqejxvzYqfCgiwU();
			VoIiwUWpoGaVvQsOVAciVQBmthy = new global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool>(true, DlwKaKQxnSCpqwNoIFLrdIXSUNzJ);
			aigQAbLwpFCjkyEbDcZhCTMWhkgb = new global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<List<yEHdWYdkyWyGSJOAPHTXOhczDmY>>(true, () => eVRylQBEybhXtQcVaaakESJbHKit());
			pVVycpDwxIAWedBpvsQuZHVXNEq();
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
		BhZbSIqTJUuvrHhjvLiLwhtaXiV = new SNRBnIgKAMRWqTrKMMmcCoNDyKKd();
		BAQCuUxBdKKwqZqjVZdkRBTPwCh = new TimerRealTime(1f);
		BAQCuUxBdKKwqZqjVZdkRBTPwCh.Start();
		yBcyHxAYdtaJQoCdFYuoptIcyZW();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		MbgVcSUpAefjsjvjwChdFUxHumx();
		fVTyjljPVNAOvCXNsxUbCrhFbJoi();
		nVcSLNPamegvZJFhMFHMKCYMWxY();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (aigQAbLwpFCjkyEbDcZhCTMWhkgb != null)
		{
			goto IL_0008;
		}
		goto IL_003c;
		IL_0008:
		int num = -927741744;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -927741742)
			{
			case 3:
				break;
			case 2:
				aigQAbLwpFCjkyEbDcZhCTMWhkgb.JGfOaxGMMubjxaprhTWpWgtvAPZ();
				num = -927741741;
				continue;
			case 1:
				goto IL_003c;
			default:
				goto IL_0056;
			}
			break;
		}
		goto IL_0008;
		IL_003c:
		if (VoIiwUWpoGaVvQsOVAciVQBmthy != null)
		{
			VoIiwUWpoGaVvQsOVAciVQBmthy.JGfOaxGMMubjxaprhTWpWgtvAPZ();
			num = -927741742;
			goto IL_000d;
		}
		goto IL_0056;
		IL_0056:
		if (SECqOtxIJCMtDAXMpkZHtbqiXBU == null)
		{
			return;
		}
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int num2 = 0;
			while (true)
			{
				int num3 = -927741741;
				while (true)
				{
					switch (num3 ^ -927741742)
					{
					case 0:
						break;
					case 1:
						num3 = -927741744;
						continue;
					case 4:
						num2++;
						num3 = -927741744;
						continue;
					case 3:
						if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num2] != null)
						{
							SECqOtxIJCMtDAXMpkZHtbqiXBU[num2].ZrHcJGgwwvDxGfSwHIvyriZRodVX();
							SECqOtxIJCMtDAXMpkZHtbqiXBU[num2].JGfOaxGMMubjxaprhTWpWgtvAPZ();
							num3 = -927741738;
							continue;
						}
						goto case 4;
					default:
						if (num2 >= SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OtrNTBJIBbQldvImDmKCAqMRnke;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int num = 0;
			while (true)
			{
				IL_000f:
				int num2 = 708666392;
				while (true)
				{
					switch (num2 ^ 0x2A3D641C)
					{
					case 0:
						break;
					case 2:
						SECqOtxIJCMtDAXMpkZHtbqiXBU[num].FillData(data);
						return;
					case 5:
					{
						int num3;
						if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num].inputManagerId != inputManagerId)
						{
							num2 = 708666397;
							num3 = num2;
						}
						else
						{
							num2 = 708666398;
							num3 = num2;
						}
						continue;
					}
					case 1:
						num++;
						num2 = 708666399;
						continue;
					case 4:
						num2 = 708666399;
						continue;
					default:
						if (num >= lTHFykxDvdBXxFWZTYErzFFjdVX)
						{
							goto end_IL_0014;
						}
						goto case 5;
					}
					goto IL_000f;
					continue;
					end_IL_0014:
					break;
				}
				break;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		FHTzXxeconPJZctSzyqbRpvkXVQ = true;
		BAQCuUxBdKKwqZqjVZdkRBTPwCh.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		FHTzXxeconPJZctSzyqbRpvkXVQ = true;
		BAQCuUxBdKKwqZqjVZdkRBTPwCh.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void MbgVcSUpAefjsjvjwChdFUxHumx()
	{
		if (VoIiwUWpoGaVvQsOVAciVQBmthy.isRunning)
		{
			goto IL_0010;
		}
		goto IL_00b5;
		IL_0010:
		int num = -644047277;
		goto IL_0015;
		IL_0015:
		while (true)
		{
			switch (num ^ -644047271)
			{
			case 9:
				break;
			default:
				return;
			case 4:
				if (VoIiwUWpoGaVvQsOVAciVQBmthy.result)
				{
					FHTzXxeconPJZctSzyqbRpvkXVQ = true;
					num = -644047266;
					continue;
				}
				goto case 7;
			case 7:
				BAQCuUxBdKKwqZqjVZdkRBTPwCh.Start();
				return;
			case 10:
				if (!VoIiwUWpoGaVvQsOVAciVQBmthy.xRKBBblbOUOOMSzhwnDVTLoUIDwi())
				{
					return;
				}
				goto case 6;
			case 5:
				goto IL_0094;
			case 1:
				goto IL_00b5;
			case 6:
				if (BAQCuUxBdKKwqZqjVZdkRBTPwCh.running)
				{
					return;
				}
				goto IL_00e4;
			case 0:
				VoIiwUWpoGaVvQsOVAciVQBmthy.SFnUlcdGONKjYCbrEBAjYDBcYmz();
				num = -644047270;
				continue;
			case 8:
				return;
			case 2:
				return;
			case 3:
				return;
			}
			break;
			IL_00e4:
			int num2;
			if (aigQAbLwpFCjkyEbDcZhCTMWhkgb.isRunning)
			{
				num = -644047269;
				num2 = num;
			}
			else
			{
				num = -644047267;
				num2 = num;
			}
		}
		goto IL_0010;
		IL_0094:
		int num3;
		if (!BAQCuUxBdKKwqZqjVZdkRBTPwCh.Update())
		{
			num = -644047270;
			num3 = num;
		}
		else
		{
			num = -644047271;
			num3 = num;
		}
		goto IL_0015;
		IL_00b5:
		if (!BAQCuUxBdKKwqZqjVZdkRBTPwCh.running)
		{
			BAQCuUxBdKKwqZqjVZdkRBTPwCh.Start();
			num = -644047279;
			goto IL_0015;
		}
		goto IL_0094;
	}

	private List<yEHdWYdkyWyGSJOAPHTXOhczDmY> eVRylQBEybhXtQcVaaakESJbHKit()
	{
		List<yEHdWYdkyWyGSJOAPHTXOhczDmY> list = new List<yEHdWYdkyWyGSJOAPHTXOhczDmY>();
		IList<rrkiWNHnEkzBYEXAvbDAWsEtjKd> list2 = jjmBbKffkMRTPIHqYsiZAxmRfyJ();
		int num2 = default(int);
		YmFSmFunbrgipweqkyRyrjKlaog properties = default(YmFSmFunbrgipweqkyRyrjKlaog);
		bool flag2 = default(bool);
		Guid guid = default(Guid);
		pAFUovwQtCmbJTgYWEQSoPZdhKD capabilities = default(pAFUovwQtCmbJTgYWEQSoPZdhKD);
		IList<CwPulMNvQcCYLBIDFFYYMQMiYz> list3 = default(IList<CwPulMNvQcCYLBIDFFYYMQMiYz>);
		int num9 = default(int);
		int count = default(int);
		while (true)
		{
			int num = -1020957490;
			while (true)
			{
				switch (num ^ -1020957489)
				{
				case 2:
					break;
				case 1:
					goto IL_002f;
				default:
					if (list2[num2] != null)
					{
						try
						{
							rrkiWNHnEkzBYEXAvbDAWsEtjKd rrkiWNHnEkzBYEXAvbDAWsEtjKd2 = list2[num2];
							Guid ubuqShzBecTPwZVAjKSSKhWTpPt = rrkiWNHnEkzBYEXAvbDAWsEtjKd2.ubuqShzBecTPwZVAjKSSKhWTpPt;
							hCkwWPjbZHHQuLPwssAiovZoKVX hCkwWPjbZHHQuLPwssAiovZoKVX2 = new hCkwWPjbZHHQuLPwssAiovZoKVX(fTUmdlBklWTlvmAQYJjrEkdriSN, ubuqShzBecTPwZVAjKSSKhWTpPt);
							while (true)
							{
								IL_0078:
								int num3 = -1020957491;
								while (true)
								{
									Guid obj2;
									switch (num3 ^ -1020957489)
									{
									case 0:
										break;
									case 2:
										properties = hCkwWPjbZHHQuLPwssAiovZoKVX2.Properties;
										flag2 = false;
										if (ydtjoUaZMACQbAJqHjVabQJcAHgE)
										{
											flag2 = khPCPJgtQFokObAEkJKNQbaUfSZG.FAFAhPjbbBwAOnGLLyaOWiEzWeM(properties.InterfacePath, StringTools.SanitizeDeviceString(rrkiWNHnEkzBYEXAvbDAWsEtjKd2.QuJoTfbshHjBObeWWlxFfdNiDKOz), string.Empty, rrkiWNHnEkzBYEXAvbDAWsEtjKd2.vkIvCPKRwSgZgrfacRXklZVOEQA);
											if (flag2)
											{
												goto end_IL_007d;
											}
										}
										goto case 1;
									case 1:
										obj2 = ((!string.IsNullOrEmpty(properties.InterfacePath)) ? MiscTools.CreateGuidHashSHA256(properties.InterfacePath) : rrkiWNHnEkzBYEXAvbDAWsEtjKd2.ubuqShzBecTPwZVAjKSSKhWTpPt);
										goto IL_0107;
									default:
									{
										bool flag = false;
										lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
										{
											if (SECqOtxIJCMtDAXMpkZHtbqiXBU != null)
											{
												int num4 = 0;
												while (true)
												{
													IL_01b7:
													int num5;
													int num6;
													if (num4 < SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
													{
														num5 = -1020957492;
														num6 = num5;
													}
													else
													{
														num5 = -1020957490;
														num6 = num5;
													}
													while (true)
													{
														switch (num5 ^ -1020957489)
														{
														case 0:
															num5 = -1020957492;
															continue;
														default:
															goto end_IL_013c;
														case 3:
															if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num4] != null && SECqOtxIJCMtDAXMpkZHtbqiXBU[num4].mtlDBDFXTzxHqeXjvCJbhGtTMUCC == guid)
															{
																hCkwWPjbZHHQuLPwssAiovZoKVX2 = SECqOtxIJCMtDAXMpkZHtbqiXBU[num4].kYVEkOHTXBhxnrAeWMuOTcRgNeH.GopNkYanAGUkOmQwUJuTJxkowKA;
																flag = true;
																num5 = -1020957490;
																continue;
															}
															goto case 4;
														case 4:
															num4++;
															num5 = -1020957491;
															continue;
														case 2:
															break;
														case 1:
															goto end_IL_013c;
														}
														goto IL_01b7;
														continue;
														end_IL_013c:
														break;
													}
													break;
												}
											}
										}
										dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = new dIYfxShIDrIIjihOcmVToKsXwFAE(new JEiBJdqVetCaYhzGImdkvLHTeQyH(hCkwWPjbZHHQuLPwssAiovZoKVX2, ZIxZgRHVxCjXhlcarovUBuZCOqL), lvntcpgdZsSbabccpIcfMpTzYYr);
										dIYfxShIDrIIjihOcmVToKsXwFAE2.eMSAOLjJyVqyGYNCqvthQlWRDYcs = rrkiWNHnEkzBYEXAvbDAWsEtjKd2;
										while (true)
										{
											IL_0207:
											int num7 = -1020957490;
											while (true)
											{
												int num10;
												int num11;
												switch (num7 ^ -1020957489)
												{
												case 0:
													break;
												case 1:
													dIYfxShIDrIIjihOcmVToKsXwFAE2.aQyubnFZjhaxoHtWxfehAEYaFOR = rrkiWNHnEkzBYEXAvbDAWsEtjKd2.UCIJJsaJdKjEMiDWDDmwnCVFXSI;
													dIYfxShIDrIIjihOcmVToKsXwFAE2.mtlDBDFXTzxHqeXjvCJbhGtTMUCC = guid;
													num7 = -1020957491;
													continue;
												case 2:
													dIYfxShIDrIIjihOcmVToKsXwFAE2.SgtdGZiZKfxrYfEaONXeCdMIqIsz = StringTools.SanitizeDeviceString(rrkiWNHnEkzBYEXAvbDAWsEtjKd2.QuJoTfbshHjBObeWWlxFfdNiDKOz);
													dIYfxShIDrIIjihOcmVToKsXwFAE2.eTlTTlBmuxCORrngMaNsxFSpDyMi = rrkiWNHnEkzBYEXAvbDAWsEtjKd2.vkIvCPKRwSgZgrfacRXklZVOEQA;
													dIYfxShIDrIIjihOcmVToKsXwFAE2.ocqEYLgpYeVchwgaiKyLlHKhmSeI = (ofeqpRsjofXSwYwacxFrGdeWwcg)rrkiWNHnEkzBYEXAvbDAWsEtjKd2.Type;
													capabilities = hCkwWPjbZHHQuLPwssAiovZoKVX2.Capabilities;
													dIYfxShIDrIIjihOcmVToKsXwFAE2.rFChCpBSHUoiIZbKWfsTCHUdRna = properties.ProductId;
													num7 = -1020957492;
													continue;
												default:
													{
														dIYfxShIDrIIjihOcmVToKsXwFAE2.IEIpySejupFvUUEVIERJEkDtdcvv = flag2;
														try
														{
															dIYfxShIDrIIjihOcmVToKsXwFAE2.iERVPkhRheIKptTuTmWgWiTZGxm = properties.JoystickId;
														}
														catch (Exception)
														{
															dIYfxShIDrIIjihOcmVToKsXwFAE2.iERVPkhRheIKptTuTmWgWiTZGxm = 0;
														}
														dIYfxShIDrIIjihOcmVToKsXwFAE2.dhEQLHuCYYGQwdehmJKXAJgttVWs = capabilities.bqtKAqSxAowWoUniiCjhuhBfRVu;
														dIYfxShIDrIIjihOcmVToKsXwFAE2.aCdTArmyUaJIYSBpkbuJpDufgNGc = capabilities.rQrTdoWPDpDHrLHNnouynDuUHKW;
														dIYfxShIDrIIjihOcmVToKsXwFAE2.JwvOuylcUYNAjPLMAAlyukWmToj = capabilities.CjrQIVLjQiXDtUXifPPiqmKRmmG;
														mqaZvKDcjQCLobGwMsCVHdhbuqt(dIYfxShIDrIIjihOcmVToKsXwFAE2, properties, out dIYfxShIDrIIjihOcmVToKsXwFAE2.ofHFJIxpUZEkaCUKTOBHGzIRSqW);
														try
														{
															string productName;
															try
															{
																productName = properties.ProductName;
															}
															catch
															{
																productName = dIYfxShIDrIIjihOcmVToKsXwFAE2.SgtdGZiZKfxrYfEaONXeCdMIqIsz;
															}
															if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)properties.VendorId, (ushort)properties.ProductId, productName))
															{
																while (true)
																{
																	IL_0326:
																	int num8 = -1020957490;
																	while (true)
																	{
																		int min;
																		int max;
																		int zero;
																		switch (num8 ^ -1020957489)
																		{
																		case 2:
																			break;
																		default:
																			goto end_IL_032b;
																		case 1:
																			if (SpecialDevices.GetRelativeAxisRanges((ushort)properties.VendorId, (ushort)properties.ProductId, productName, out min, out max, out zero))
																			{
																				goto IL_0363;
																			}
																			goto end_IL_032b;
																		case 0:
																			goto end_IL_032b;
																		}
																		goto IL_0326;
																		IL_0363:
																		dIYfxShIDrIIjihOcmVToKsXwFAE2.kYVEkOHTXBhxnrAeWMuOTcRgNeH.FADRItgConDiBPwOnuWeUubpqrE(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)properties.VendorId, (ushort)properties.ProductId, productName));
																		num8 = -1020957489;
																		continue;
																		end_IL_032b:
																		break;
																	}
																	break;
																}
															}
														}
														catch (Exception)
														{
														}
														if (!flag)
														{
															list3 = hCkwWPjbZHHQuLPwssAiovZoKVX2.PJEcNGtbdKAvVzrSRMQRmtkgwNI();
															if (list3 != null)
															{
																num9 = 0;
																goto IL_03ee;
															}
															goto IL_040a;
														}
														goto IL_0449;
													}
													IL_040a:
													hCkwWPjbZHHQuLPwssAiovZoKVX2.Properties.AxisMode = HYcFbaPdcyXnblzlVQfgJJzNyzk.CeMiPSSNKbNgyqlVlGzxaRKteySo;
													num10 = -1020957498;
													goto IL_03b6;
													IL_03ee:
													if (num9 < list3.Count)
													{
														num10 = -1020957496;
														num11 = num10;
													}
													else
													{
														num10 = -1020957492;
														num11 = num10;
													}
													goto IL_03b6;
													IL_0449:
													list.Add(new yEHdWYdkyWyGSJOAPHTXOhczDmY(dIYfxShIDrIIjihOcmVToKsXwFAE2, rrkiWNHnEkzBYEXAvbDAWsEtjKd2));
													num10 = -1020957490;
													goto IL_03b6;
													IL_03b6:
													while (true)
													{
														switch (num10 ^ -1020957489)
														{
														case 5:
															num10 = -1020957496;
															continue;
														case 8:
															goto IL_03ee;
														case 3:
															goto IL_040a;
														case 7:
															goto IL_041e;
														case 4:
															goto IL_0449;
														case 9:
															hCkwWPjbZHHQuLPwssAiovZoKVX2.pVjCRcnFadXjpSBARcaEJMpHANW(kBhJxALdxxcEFwejpLfeqaTmQiT, aMiFchjDjfNqUBAOopnRVuhunMWj.NGZxmrsXyYuqFHUMXLbTyxUaOmX | aMiFchjDjfNqUBAOopnRVuhunMWj.AXWiAusKiVZHIMEWsxCGzLreiiD);
															num10 = -1020957491;
															continue;
														case 6:
															hCkwWPjbZHHQuLPwssAiovZoKVX2.Properties.Range = new TJtsekndLtkarLCycggFrDgcNKP(-65535, 65535);
															num10 = -1020957489;
															continue;
														case 2:
															hCkwWPjbZHHQuLPwssAiovZoKVX2.MuhNEKLWnOVbFFtlAfKRHODWgpV();
															num10 = -1020957493;
															continue;
														case 0:
															num9++;
															num10 = -1020957497;
															continue;
														case 1:
															break;
														}
														break;
														IL_041e:
														int num12;
														if ((list3[num9].PWmmnMBfsgZpBwBOPUTmjzcqGva.Flags & kwDQWJxJqLfGHqZNmyNdWGtdcVI.RnvlqNwbJnzAfbpYrjOARqAZFyM) == 0)
														{
															num10 = -1020957489;
															num12 = num10;
														}
														else
														{
															num10 = -1020957495;
															num12 = num10;
														}
													}
													goto end_IL_020c;
												}
												goto IL_0207;
												continue;
												end_IL_020c:
												break;
											}
											break;
										}
										goto end_IL_007d;
									}
									}
									goto IL_0078;
									IL_0107:
									guid = obj2;
									num3 = -1020957492;
									continue;
									end_IL_007d:
									break;
								}
								break;
							}
						}
						catch (Exception)
						{
						}
					}
					num2++;
					goto case 0;
				case 0:
					if (num2 >= count)
					{
						return list;
					}
					goto default;
				}
				break;
				IL_002f:
				count = list2.Count;
				num2 = 0;
				num = -1020957489;
			}
		}
	}

	private void yBcyHxAYdtaJQoCdFYuoptIcyZW()
	{
		BSVqdeFFmRGquKzRRwdJkQkTOaWA(eVRylQBEybhXtQcVaaakESJbHKit());
	}

	private void BSVqdeFFmRGquKzRRwdJkQkTOaWA(List<yEHdWYdkyWyGSJOAPHTXOhczDmY> P_0)
	{
		List<dIYfxShIDrIIjihOcmVToKsXwFAE> list = new List<dIYfxShIDrIIjihOcmVToKsXwFAE>();
		OwMjmoZZHJWflbLcoFaXqkXbfGXF = 0;
		if (P_0 == null)
		{
			goto IL_0010;
		}
		int num = P_0.Count;
		goto IL_003b;
		IL_004a:
		int num2 = default(int);
		int num3;
		if (P_0[num2] != null)
		{
			num3 = -1725098934;
			goto IL_0015;
		}
		goto IL_00c2;
		IL_0010:
		num3 = -1725098933;
		goto IL_0015;
		IL_0015:
		switch (num3 ^ -1725098935)
		{
		case 0:
			break;
		case 2:
			goto IL_0032;
		case 1:
			goto IL_004a;
		default:
			goto IL_005a;
		}
		goto IL_0010;
		IL_0032:
		num = 0;
		goto IL_003b;
		IL_003b:
		int num4 = num;
		num2 = 0;
		goto IL_00e4;
		IL_005a:
		if (P_0[num2].IsValid)
		{
			try
			{
				dIYfxShIDrIIjihOcmVToKsXwFAE pSZKcVVfVmWuwyrmRaPnqSTTRBB = P_0[num2].PSZKcVVfVmWuwyrmRaPnqSTTRBB;
				pSZKcVVfVmWuwyrmRaPnqSTTRBB.qdrCNHHBSjMYElMPgHUagWNZcjH();
				while (true)
				{
					IL_007b:
					int num5 = -1725098933;
					while (true)
					{
						switch (num5 ^ -1725098935)
						{
						case 0:
							break;
						case 2:
							if (pSZKcVVfVmWuwyrmRaPnqSTTRBB.HUFFKhqkxcIVKhtrxspNbGBrTdG)
							{
								goto IL_00a1;
							}
							goto default;
						default:
							list.Add(pSZKcVVfVmWuwyrmRaPnqSTTRBB);
							goto end_IL_0080;
						}
						goto IL_007b;
						IL_00a1:
						OwMjmoZZHJWflbLcoFaXqkXbfGXF++;
						num5 = -1725098936;
						continue;
						end_IL_0080:
						break;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
		}
		goto IL_00c2;
		IL_0105:
		mAbSqZKATNFUhWPMtuukNHRYGVi.iAQSIxHcqRRCHTNIEjSyHMLdVpTN(OwMjmoZZHJWflbLcoFaXqkXbfGXF);
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			List<dIYfxShIDrIIjihOcmVToKsXwFAE> sECqOtxIJCMtDAXMpkZHtbqiXBU = SECqOtxIJCMtDAXMpkZHtbqiXBU;
			int count = default(int);
			int num7 = default(int);
			while (true)
			{
				int num6 = -1725098933;
				while (true)
				{
					switch (num6 ^ -1725098935)
					{
					case 0:
						break;
					default:
						return;
					case 2:
					{
						int num8 = lTHFykxDvdBXxFWZTYErzFFjdVX;
						count = list.Count;
						KlUGOAHUqlIJiIxVnahEcgteyqda(num8, count, sECqOtxIJCMtDAXMpkZHtbqiXBU, list);
						num7 = 0;
						num6 = -1725098936;
						continue;
					}
					case 5:
						num7++;
						num6 = -1725098936;
						continue;
					case 1:
						if (num7 >= count)
						{
							JtDrBjjubFXiGBlgRbdsfJusBoA(sECqOtxIJCMtDAXMpkZHtbqiXBU, list, false);
							JtDrBjjubFXiGBlgRbdsfJusBoA(list, sECqOtxIJCMtDAXMpkZHtbqiXBU, true);
							XLSyFvAyvgtnnwkEJGaHASCppOBm(list, sECqOtxIJCMtDAXMpkZHtbqiXBU);
							SECqOtxIJCMtDAXMpkZHtbqiXBU = list;
							lTHFykxDvdBXxFWZTYErzFFjdVX = list.Count;
							num6 = -1725098934;
							continue;
						}
						goto case 4;
					case 4:
						if (_UpdateControllerInfoEvent != null)
						{
							_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[num7]));
							num6 = -1725098932;
							continue;
						}
						goto case 5;
					case 3:
						return;
					}
					break;
				}
			}
		}
		IL_00c2:
		num2++;
		goto IL_00c6;
		IL_00c6:
		int num9 = -1725098936;
		goto IL_00cb;
		IL_00cb:
		switch (num9 ^ -1725098935)
		{
		case 2:
			break;
		case 1:
			goto IL_00e4;
		default:
			goto IL_0105;
		}
		goto IL_00c6;
		IL_00e4:
		if (num2 < num4)
		{
			goto IL_004a;
		}
		if (OwMjmoZZHJWflbLcoFaXqkXbfGXF == 0)
		{
			VoIiwUWpoGaVvQsOVAciVQBmthy.fWzuAFjFXxdRoqxypOAIFkBEHOX();
			num9 = -1725098935;
			goto IL_00cb;
		}
		goto IL_0105;
	}

	private void mqaZvKDcjQCLobGwMsCVHdhbuqt(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, YmFSmFunbrgipweqkyRyrjKlaog P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(P_1.InterfacePath);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			hdKCmGlHttTBdcjeWBCjBOXCTjJ hdKCmGlHttTBdcjeWBCjBOXCTjJ2 = qRcrmPWSlvohNRTlmCdEtNVJlYH.YGWZvKZyyVQnQnhlmktMLZiJaXg(text.ToLower(CultureInfo.InvariantCulture));
			if (hdKCmGlHttTBdcjeWBCjBOXCTjJ2 != null)
			{
				P_0.HUFFKhqkxcIVKhtrxspNbGBrTdG = hdKCmGlHttTBdcjeWBCjBOXCTjJ2.IsBluetoothDevice;
				P_0.ZYtBoPNuCmSlSLPglVVYiiIepKT = hdKCmGlHttTBdcjeWBCjBOXCTjJ2.BluetoothDeviceName;
				P_2 = ZBdWqjRRrpMQStGZMBFtHgnrSdp.UcFxCuePLtGkYNmCfHmGPxwJaCKI(hdKCmGlHttTBdcjeWBCjBOXCTjJ2, P_0.eTlTTlBmuxCORrngMaNsxFSpDyMi, P_0.SgtdGZiZKfxrYfEaONXeCdMIqIsz, P_0.ZYtBoPNuCmSlSLPglVVYiiIepKT);
				hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void nVcSLNPamegvZJFhMFHMKCYMWxY()
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			for (int i = 0; i < lTHFykxDvdBXxFWZTYErzFFjdVX; i++)
			{
				try
				{
					dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = SECqOtxIJCMtDAXMpkZHtbqiXBU[i];
					while (true)
					{
						IL_0021:
						int num = -1592738077;
						while (true)
						{
							switch (num ^ -1592738074)
							{
							case 6:
								break;
							default:
								goto end_IL_0026;
							case 4:
								if (dIYfxShIDrIIjihOcmVToKsXwFAE2.IEIpySejupFvUUEVIERJEkDtdcvv)
								{
									goto end_IL_0026;
								}
								goto case 0;
							case 2:
							{
								int num3;
								if (!dIYfxShIDrIIjihOcmVToKsXwFAE2.IMlLKEcEdbfJWCtAPwVjQExfFyg())
								{
									num = -1592738075;
									num3 = num;
								}
								else
								{
									num = -1592738073;
									num3 = num;
								}
								continue;
							}
							case 5:
								if (dIYfxShIDrIIjihOcmVToKsXwFAE2 == null)
								{
									goto end_IL_0026;
								}
								goto case 2;
							case 1:
							{
								int num2;
								if (!ydtjoUaZMACQbAJqHjVabQJcAHgE)
								{
									num = -1592738074;
									num2 = num;
								}
								else
								{
									num = -1592738078;
									num2 = num;
								}
								continue;
							}
							case 3:
								goto end_IL_0026;
							case 0:
								dIYfxShIDrIIjihOcmVToKsXwFAE2.Update();
								num = -1592738079;
								continue;
							case 7:
								goto end_IL_0026;
							}
							goto IL_0021;
							continue;
							end_IL_0026:
							break;
						}
						break;
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<rrkiWNHnEkzBYEXAvbDAWsEtjKd> jjmBbKffkMRTPIHqYsiZAxmRfyJ()
	{
		try
		{
			IList<rrkiWNHnEkzBYEXAvbDAWsEtjKd> devices = fTUmdlBklWTlvmAQYJjrEkdriSN.GetDevices(FTxufsFYYZLjZuOhPwjajrbMvoj.MRqcqejOtASJsQJRNVwXMlVPvNWT, jQHcAazllAfioxyWFvAxWLMcwIf.ixnfIgjplOyvFHABieLYYzTzQUKU);
			YTrkqMmqoBacvniXMdDSHcGseeHl = ((devices != null) ? devices.Count : 0);
			return devices;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			YTrkqMmqoBacvniXMdDSHcGseeHl = 0;
			return EmptyObjects<rrkiWNHnEkzBYEXAvbDAWsEtjKd>.EmptyReadOnlyIListT;
		}
	}

	private void pVVycpDwxIAWedBpvsQuZHVXNEq()
	{
		fTUmdlBklWTlvmAQYJjrEkdriSN.GetDevices();
	}

	private void KlUGOAHUqlIJiIxVnahEcgteyqda(int P_0, int P_1, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_2, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_3)
	{
		if (P_1 > 0)
		{
			goto IL_0007;
		}
		goto IL_0103;
		IL_0007:
		int num = 1871712310;
		goto IL_000c;
		IL_000c:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x6F901034)
			{
			case 8:
				break;
			case 2:
				P_3.Sort(dIYfxShIDrIIjihOcmVToKsXwFAE.BpwtCqMMoIuSANtUfTmfAKeytHL);
				num = 1871712306;
				continue;
			case 1:
				if (P_1 > 0)
				{
					ISWzZRbBIprIMKhUiHLkZfQuBhZ(P_1, P_3, P_0, P_2, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns.pcWfOxYbvNCAItRmLAyYfYdvnxE);
					num = 1871712308;
					continue;
				}
				goto IL_0083;
			case 4:
				num2++;
				num = 1871712305;
				continue;
			case 7:
				goto IL_0083;
			case 0:
				ISWzZRbBIprIMKhUiHLkZfQuBhZ(P_1, P_3, P_0, P_2, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns.JgYTOGxxNXCOjMYfJlJOWIFnveY);
				num = 1871712307;
				continue;
			case 3:
			{
				dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = P_3[num2];
				if (dIYfxShIDrIIjihOcmVToKsXwFAE2 != null && dIYfxShIDrIIjihOcmVToKsXwFAE2.inputManagerId < 0)
				{
					dIYfxShIDrIIjihOcmVToKsXwFAE2.inputManagerId = jjcAdWSwmMiSHrtrbjSXvfBZBAz(P_3);
					dIYfxShIDrIIjihOcmVToKsXwFAE2.rewiredId = osCAPAIYOEZodlsEwtiFRgmwudTL();
					BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(dIYfxShIDrIIjihOcmVToKsXwFAE2);
					num = 1871712304;
					continue;
				}
				goto case 4;
			}
			case 6:
				goto IL_0103;
			default:
				if (num2 >= P_1)
				{
					P_3.Sort(dIYfxShIDrIIjihOcmVToKsXwFAE.mHubPKenGxeOoCUpuEdJbdHQxjT);
					return;
				}
				goto case 3;
			}
			break;
		}
		goto IL_0007;
		IL_0103:
		if (P_0 > 0)
		{
			num = 1871712309;
			goto IL_000c;
		}
		goto IL_0083;
		IL_0083:
		ILQRLaTXmQpdVwAsNdOarwOhzkQ(P_1, P_3, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns.pcWfOxYbvNCAItRmLAyYfYdvnxE);
		ILQRLaTXmQpdVwAsNdOarwOhzkQ(P_1, P_3, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns.JgYTOGxxNXCOjMYfJlJOWIFnveY);
		num2 = 0;
		num = 1871712305;
		goto IL_000c;
	}

	private void pEtCuzBvCgjYuRXCToAuDLQZmTbF(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = -207633320;
				num3 = num2;
			}
			else
			{
				num2 = -207633316;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -207633319)
				{
				case 4:
					num2 = -207633320;
					continue;
				default:
					return;
				case 3:
					break;
				case 0:
					if (P_0[num] != null && P_0[num].inputManagerId == P_2)
					{
						P_0[num].inputManagerId = -1;
						num2 = -207633317;
						continue;
					}
					goto case 2;
				case 2:
					num++;
					num2 = -207633318;
					continue;
				case 1:
				{
					int num4;
					if (num == P_1)
					{
						num2 = -207633317;
						num4 = num2;
					}
					else
					{
						num2 = -207633319;
						num4 = num2;
					}
					continue;
				}
				case 5:
					return;
				}
				break;
			}
		}
	}

	private bool bxYRVPNBMeqzOlxWcuXPWWCIBKj(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0, int P_1)
	{
		int count = P_0.Count;
		int num2 = default(int);
		while (true)
		{
			int num = 257362948;
			while (true)
			{
				switch (num ^ 0xF570C06)
				{
				case 0:
					break;
				case 2:
					num2 = 0;
					num = 257362949;
					continue;
				case 1:
					if (P_0[num2] != null && P_0[num2].inputManagerId == P_1)
					{
						return false;
					}
					num2++;
					num = 257362949;
					continue;
				default:
					if (num2 >= count)
					{
						return true;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private int jjcAdWSwmMiSHrtrbjSXvfBZBAz(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int num3 = default(int);
		int count = default(int);
		while (true)
		{
			int num2 = -1135666320;
			while (true)
			{
				switch (num2 ^ -1135666315)
				{
				case 3:
					break;
				case 0:
					if (!flag)
					{
						return num;
					}
					num++;
					num2 = -1135666307;
					continue;
				case 1:
				{
					int num4;
					if (num3 < count)
					{
						num2 = -1135666313;
						num4 = num2;
					}
					else
					{
						num2 = -1135666315;
						num4 = num2;
					}
					continue;
				}
				case 4:
					num3++;
					num2 = -1135666316;
					continue;
				case 7:
					num3 = 0;
					num2 = -1135666316;
					continue;
				default:
					flag = false;
					count = P_0.Count;
					num2 = -1135666318;
					continue;
				case 6:
					num2 = -1135666315;
					continue;
				case 2:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = -1135666317;
						continue;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private bool hnPTilELGLdIFJbfnUgVEfTUyAY(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0, int P_1)
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
				int num2;
				if (P_0[num].rewiredId == P_1)
				{
					num2 = 1549782552;
				}
				else
				{
					num++;
					num2 = 1549782554;
				}
				while (true)
				{
					switch (num2 ^ 0x5C5FCE1A)
					{
					case 3:
						num2 = 1549782555;
						continue;
					case 1:
						break;
					case 2:
						return true;
					default:
						goto end_IL_002b;
					}
					break;
				}
				continue;
				end_IL_002b:
				break;
			}
		}
		return false;
	}

	private void ISWzZRbBIprIMKhUiHLkZfQuBhZ(int P_0, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_1, int P_2, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_3, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns P_4)
	{
		if (P_4 != SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns.pcWfOxYbvNCAItRmLAyYfYdvnxE)
		{
			goto IL_0007;
		}
		int num = 2;
		goto IL_00eb;
		IL_00e7:
		num = 1;
		goto IL_00eb;
		IL_0007:
		int num2 = -1276749095;
		goto IL_000c;
		IL_000c:
		dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE3 = default(dIYfxShIDrIIjihOcmVToKsXwFAE);
		int num3 = default(int);
		int num4 = default(int);
		dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = default(dIYfxShIDrIIjihOcmVToKsXwFAE);
		int num5 = default(int);
		while (true)
		{
			switch (num2 ^ -1276749101)
			{
			case 6:
				break;
			case 0:
				dIYfxShIDrIIjihOcmVToKsXwFAE3 = P_1[num3];
				if (dIYfxShIDrIIjihOcmVToKsXwFAE3 != null && dIYfxShIDrIIjihOcmVToKsXwFAE3.inputManagerId < 0)
				{
					num4 = 0;
					num2 = -1276749104;
					continue;
				}
				goto case 5;
			case 7:
				goto IL_0065;
			case 5:
				num3++;
				num2 = -1276749094;
				continue;
			case 3:
				num2 = -1276749100;
				continue;
			case 4:
				dIYfxShIDrIIjihOcmVToKsXwFAE3.sHFWIJnFHmHJYIoFEDYPzPHrHZM(dIYfxShIDrIIjihOcmVToKsXwFAE2);
				BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(dIYfxShIDrIIjihOcmVToKsXwFAE3);
				num2 = -1276749102;
				continue;
			case 8:
				dIYfxShIDrIIjihOcmVToKsXwFAE2 = P_3[num4];
				if (dIYfxShIDrIIjihOcmVToKsXwFAE2 != null && !hnPTilELGLdIFJbfnUgVEfTUyAY(P_1, dIYfxShIDrIIjihOcmVToKsXwFAE2.rewiredId))
				{
					goto IL_00c8;
				}
				goto case 1;
			case 10:
				goto IL_00e7;
			case 2:
				num2 = -1276749094;
				continue;
			case 1:
				num4++;
				num2 = -1276749100;
				continue;
			default:
				if (num3 >= P_0)
				{
					return;
				}
				goto case 0;
			}
			break;
			IL_00c8:
			int num6;
			if (dIYfxShIDrIIjihOcmVToKsXwFAE3.QJuTPVbZPhckxeVMgmaDORJltri(dIYfxShIDrIIjihOcmVToKsXwFAE2) < num5)
			{
				num2 = -1276749102;
				num6 = num2;
			}
			else
			{
				num2 = -1276749097;
				num6 = num2;
			}
			continue;
			IL_0065:
			int num7;
			if (num4 < P_2)
			{
				num2 = -1276749093;
				num7 = num2;
			}
			else
			{
				num2 = -1276749098;
				num7 = num2;
			}
		}
		goto IL_0007;
		IL_00eb:
		num5 = num;
		num3 = 0;
		num2 = -1276749103;
		goto IL_000c;
	}

	private void ILQRLaTXmQpdVwAsNdOarwOhzkQ(int P_0, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_1, SNRBnIgKAMRWqTrKMMmcCoNDyKKd.DIWJVETWaPFFkudLyHFYfVbJqns P_2)
	{
		int num = 0;
		int num4 = default(int);
		SNRBnIgKAMRWqTrKMMmcCoNDyKKd.AnjAepQmDzjzNYGnHJNnxdhxpUp anjAepQmDzjzNYGnHJNnxdhxpUp = default(SNRBnIgKAMRWqTrKMMmcCoNDyKKd.AnjAepQmDzjzNYGnHJNnxdhxpUp);
		while (num < P_0)
		{
			while (true)
			{
				IL_00c8:
				dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = P_1[num];
				int num2;
				if (dIYfxShIDrIIjihOcmVToKsXwFAE2 != null)
				{
					int num3;
					if (dIYfxShIDrIIjihOcmVToKsXwFAE2.inputManagerId < 0)
					{
						num2 = 238923171;
						num3 = num2;
					}
					else
					{
						num2 = 238923169;
						num3 = num2;
					}
					goto IL_000c;
				}
				goto IL_007e;
				IL_000c:
				while (true)
				{
					switch (num2 ^ 0xE3DADA5)
					{
					case 2:
						num2 = 238923172;
						continue;
					case 5:
						if (!bxYRVPNBMeqzOlxWcuXPWWCIBKj(P_1, num4))
						{
							num4 = (anjAepQmDzjzNYGnHJNnxdhxpUp.WppCCSIJiYbWggCDNrMGswGEsUzA = jjcAdWSwmMiSHrtrbjSXvfBZBAz(P_1));
							num2 = 238923173;
							continue;
						}
						goto case 0;
					case 0:
						dIYfxShIDrIIjihOcmVToKsXwFAE2.inputManagerId = num4;
						dIYfxShIDrIIjihOcmVToKsXwFAE2.rewiredId = anjAepQmDzjzNYGnHJNnxdhxpUp.OHBcezjWhuCjOisuXXaxDLGlnPLC;
						BhZbSIqTJUuvrHhjvLiLwhtaXiV.xdxZeKjdcofLtxWSQEJXMnutFBg(dIYfxShIDrIIjihOcmVToKsXwFAE2);
						num2 = 238923169;
						continue;
					case 4:
						break;
					case 6:
						goto IL_0089;
					case 1:
						goto IL_00c8;
					default:
						goto end_IL_00c8;
					}
					break;
					IL_0089:
					anjAepQmDzjzNYGnHJNnxdhxpUp = BhZbSIqTJUuvrHhjvLiLwhtaXiV.GAYuJaWQWiVlljmcwLCVJqAlvzZ(dIYfxShIDrIIjihOcmVToKsXwFAE2, P_2);
					if (anjAepQmDzjzNYGnHJNnxdhxpUp == null || hnPTilELGLdIFJbfnUgVEfTUyAY(P_1, anjAepQmDzjzNYGnHJNnxdhxpUp.OHBcezjWhuCjOisuXXaxDLGlnPLC))
					{
						break;
					}
					num4 = anjAepQmDzjzNYGnHJNnxdhxpUp.WppCCSIJiYbWggCDNrMGswGEsUzA;
					int num5;
					if (num4 < 0)
					{
						num2 = 238923169;
						num5 = num2;
					}
					else
					{
						num2 = 238923168;
						num5 = num2;
					}
				}
				goto IL_007e;
				IL_007e:
				num++;
				num2 = 238923174;
				goto IL_000c;
				continue;
				end_IL_00c8:
				break;
			}
		}
	}

	private void fVTyjljPVNAOvCXNsxUbCrhFbJoi()
	{
		if (FHTzXxeconPJZctSzyqbRpvkXVQ)
		{
			DOhDLCjrEVGqRuZllaswidbgatW();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		int num;
		if (aigQAbLwpFCjkyEbDcZhCTMWhkgb.isRunning && aigQAbLwpFCjkyEbDcZhCTMWhkgb.xRKBBblbOUOOMSzhwnDVTLoUIDwi())
		{
			IVZQXBEcnUfnrWypyWboQvGXMjb(aigQAbLwpFCjkyEbDcZhCTMWhkgb.result);
			num = -1108891078;
			goto IL_0013;
		}
		return;
		IL_000e:
		num = -1108891077;
		goto IL_0013;
		IL_0013:
		switch (num ^ -1108891078)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			goto IL_002c;
		case 0:
			return;
		}
		goto IL_000e;
	}

	private void DOhDLCjrEVGqRuZllaswidbgatW()
	{
		FHTzXxeconPJZctSzyqbRpvkXVQ = false;
		if (!aigQAbLwpFCjkyEbDcZhCTMWhkgb.isRunning)
		{
			aigQAbLwpFCjkyEbDcZhCTMWhkgb.SFnUlcdGONKjYCbrEBAjYDBcYmz();
		}
	}

	private void IVZQXBEcnUfnrWypyWboQvGXMjb(List<yEHdWYdkyWyGSJOAPHTXOhczDmY> P_0)
	{
		if (pmAEuyuEmCBiquTqaFnfwdiCMuU(yEHdWYdkyWyGSJOAPHTXOhczDmY.UieSsnNFHvINJjksbsFwJrDIsvpy(P_0)))
		{
			BSVqdeFFmRGquKzRRwdJkQkTOaWA(P_0);
		}
	}

	private bool pmAEuyuEmCBiquTqaFnfwdiCMuU(IList<rrkiWNHnEkzBYEXAvbDAWsEtjKd> P_0)
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !saptnzWhriuFUwfptyJbkFjzymv(P_0[i].ubuqShzBecTPwZVAjKSSKhWTpPt))
				{
					return true;
				}
			}
			int count2 = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
			for (int j = 0; j < count2; j++)
			{
				if (SECqOtxIJCMtDAXMpkZHtbqiXBU[j] != null && !XrfbUEUpNCHSwbQMOmbXqaVXDkCt(P_0, SECqOtxIJCMtDAXMpkZHtbqiXBU[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool saptnzWhriuFUwfptyJbkFjzymv(Guid P_0)
	{
		lock (OwdBRVkoLEeNZyygHCLZABIQljTX)
		{
			int count = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
			int num = 0;
			bool result = default(bool);
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num] != null && SECqOtxIJCMtDAXMpkZHtbqiXBU[num].instanceGuid == P_0)
					{
						result = true;
						num2 = -292088879;
						goto IL_0022;
					}
					goto IL_0073;
					IL_0073:
					num++;
					num2 = -292088878;
					goto IL_0022;
					IL_0022:
					while (true)
					{
						switch (num2 ^ -292088878)
						{
						case 4:
							num2 = -292088877;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0073;
						default:
							goto end_IL_0043;
						case 3:
							return result;
						}
						break;
					}
					continue;
					end_IL_0043:
					break;
				}
			}
		}
		return false;
	}

	private bool XrfbUEUpNCHSwbQMOmbXqaVXDkCt(IList<rrkiWNHnEkzBYEXAvbDAWsEtjKd> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].ubuqShzBecTPwZVAjKSSKhWTpPt == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void JtDrBjjubFXiGBlgRbdsfJusBoA(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			goto IL_0006;
		}
		goto IL_00da;
		IL_0006:
		int num = -423948714;
		goto IL_000b;
		IL_000b:
		int num4 = default(int);
		dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE2 = default(dIYfxShIDrIIjihOcmVToKsXwFAE);
		bool flag = default(bool);
		int num2 = default(int);
		int num3 = default(int);
		int num5 = default(int);
		while (true)
		{
			switch (num ^ -423948705)
			{
			case 0:
				break;
			case 4:
				goto IL_004b;
			case 2:
			{
				dIYfxShIDrIIjihOcmVToKsXwFAE dIYfxShIDrIIjihOcmVToKsXwFAE3 = P_1[num4];
				if (dIYfxShIDrIIjihOcmVToKsXwFAE3 != null && dIYfxShIDrIIjihOcmVToKsXwFAE2.instanceGuid == dIYfxShIDrIIjihOcmVToKsXwFAE3.instanceGuid)
				{
					flag = true;
					num = -423948711;
					continue;
				}
				goto case 8;
			}
			case 3:
				if (!flag)
				{
					rXhRyzhbQTbXDGmMixSdjNyJMsQm(P_0[num2], P_2);
					num = -423948706;
					continue;
				}
				goto case 1;
			case 9:
				return;
			case 8:
				num4++;
				num = -423948715;
				continue;
			case 10:
				goto IL_00c1;
			case 11:
				goto IL_00da;
			case 6:
				num = -423948708;
				continue;
			case 1:
				num2++;
				num = -423948712;
				continue;
			case 5:
				dIYfxShIDrIIjihOcmVToKsXwFAE2 = P_0[num2];
				if (dIYfxShIDrIIjihOcmVToKsXwFAE2 != null)
				{
					flag = false;
					if (P_1 != null)
					{
						num4 = 0;
						num = -423948715;
						continue;
					}
					goto case 3;
				}
				goto case 1;
			default:
				if (num2 >= num3)
				{
					return;
				}
				goto case 5;
			}
			break;
			IL_00c1:
			int num6;
			if (num4 >= num5)
			{
				num = -423948708;
				num6 = num;
			}
			else
			{
				num = -423948707;
				num6 = num;
			}
		}
		goto IL_0006;
		IL_0054:
		int num7;
		num5 = num7;
		num2 = 0;
		num = -423948712;
		goto IL_000b;
		IL_00da:
		num3 = ((P_0 != null) ? P_0.Count : 0);
		if (P_1 != null)
		{
			num7 = P_1.Count;
			goto IL_0054;
		}
		num = -423948709;
		goto IL_000b;
		IL_004b:
		num7 = 0;
		goto IL_0054;
	}

	private void rXhRyzhbQTbXDGmMixSdjNyJMsQm(dIYfxShIDrIIjihOcmVToKsXwFAE P_0, bool P_1)
	{
		if (P_1)
		{
			goto IL_0003;
		}
		goto IL_002d;
		IL_0003:
		int num = -271971312;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ -271971308)
			{
			case 2:
				break;
			default:
				return;
			case 0:
				goto IL_002d;
			case 5:
				return;
			case 1:
				_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
				num = -271971305;
				continue;
			case 4:
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(P_0.ToBridgedController());
					num = -271971311;
					continue;
				}
				return;
			case 3:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_002d:
		int num2;
		if (_DeviceDisconnectedEvent == null)
		{
			num = -271971305;
			num2 = num;
		}
		else
		{
			num = -271971307;
			num2 = num;
		}
		goto IL_0008;
	}

	private bool DlwKaKQxnSCpqwNoIFLrdIXSUNzJ()
	{
		int num = fTUmdlBklWTlvmAQYJjrEkdriSN.GetDeviceCount(FTxufsFYYZLjZuOhPwjajrbMvoj.MRqcqejOtASJsQJRNVwXMlVPvNWT, jQHcAazllAfioxyWFvAxWLMcwIf.ixnfIgjplOyvFHABieLYYzTzQUKU);
		while (true)
		{
			int num2 = 806511198;
			while (true)
			{
				switch (num2 ^ 0x3012625F)
				{
				case 2:
					break;
				case 1:
					if (YTrkqMmqoBacvniXMdDSHcGseeHl != num)
					{
						goto IL_0035;
					}
					if (OwMjmoZZHJWflbLcoFaXqkXbfGXF > 0 && mAbSqZKATNFUhWPMtuukNHRYGVi.GdUSUoYPOUWZsVmDJtYnJAXVmkD())
					{
						return true;
					}
					return false;
				default:
					return true;
				}
				break;
				IL_0035:
				YTrkqMmqoBacvniXMdDSHcGseeHl = num;
				num2 = 806511199;
			}
		}
	}

	private void XLSyFvAyvgtnnwkEJGaHASCppOBm(List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_0, List<dIYfxShIDrIIjihOcmVToKsXwFAE> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -2129092906;
			while (true)
			{
				switch (num2 ^ -2129092912)
				{
				case 7:
					num2 = -2129092908;
					continue;
				case 1:
				{
					int num4;
					if (P_0.Contains(P_1[num]))
					{
						num2 = -2129092907;
						num4 = num2;
					}
					else
					{
						num2 = -2129092912;
						num4 = num2;
					}
					continue;
				}
				case 5:
					num++;
					num2 = -2129092909;
					continue;
				case 6:
					num2 = -2129092909;
					continue;
				case 0:
					P_1[num].JGfOaxGMMubjxaprhTWpWgtvAPZ();
					num2 = -2129092907;
					continue;
				case 4:
					break;
				case 2:
					if (P_1[num] != null)
					{
						int num3;
						if (P_0 != null)
						{
							num2 = -2129092911;
							num3 = num2;
						}
						else
						{
							num2 = -2129092912;
							num3 = num2;
						}
						continue;
					}
					goto case 5;
				default:
					if (num >= P_1.Count)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void LzexmkpZFbTHPEqjpzBoMdWJgWnE(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<yEHdWYdkyWyGSJOAPHTXOhczDmY> tudMwhBpiSMgeCsoafYGFtlScmm()
	{
		return eVRylQBEybhXtQcVaaakESJbHKit();
	}
}
