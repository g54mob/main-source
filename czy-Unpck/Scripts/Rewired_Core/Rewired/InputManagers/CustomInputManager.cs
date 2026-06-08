using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class lhBiYQLnfhmmZqOADaUJPSOxgsk : IInputManagerJoystickPublic, IInputManagerJoystick
		{
			private readonly InputSource IRTGlhOkWOimkumhYFSkdpOYbETD;

			private readonly CustomInputSource HRMjdsKAakYtLJeqeiyLJFLWXih;

			private readonly Controller.Extension XRrbuPDOAbJMnDUNcTrqkgwkvwmk;

			private int HhStEfcVVlMiBjgWdCLXZvzOFhgb;

			private int SVlrBPWDEySKVHcSUJitCfBSxnO;

			private long? XcwVCJqiNcgcNAxYsxBgTcGENhR;

			private int EDcwRUJrjTccxnNnAhrMmqhjdqO;

			public Guid NdHHxuQRnYAiYXlkbCSlISGovAq;

			public string ZgzgdXTVKfkRlzrzfeUmNfHzFAx;

			public string hgkMJeYOCfCNxcRFlqotyZvMrEoR;

			private int RGhWgMAfPjfICjXGWTZxnPoNdWD;

			private int SeOhWaCQLSUYyhdokorrnPTrNGB;

			private float[] JzCpTyTcKdiDVvPxFKAbxEFLDAw;

			private bool[] vEmeiLseeiFjOBSerAJjqspjZBa;

			private HardwareJoystickMap_InputManager REZiFujnwfIcWniRKvMxDxhPHlx;

			public CustomInputSource.Joystick sxWHzTWgqbBNNfMTYkLznhnllaB;

			private bool BjLRIbHSNziZuePSCMYMTKKmtVyj;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dUeoOAWeqXvgKLTHqOAcuSQkGJiK;

			public int hardwareButtonCount
			{
				get
				{
					if (sxWHzTWgqbBNNfMTYkLznhnllaB == null)
					{
						return 0;
					}
					return sxWHzTWgqbBNNfMTYkLznhnllaB.buttonCount;
				}
			}

			public int hardwareAxisCount
			{
				get
				{
					if (sxWHzTWgqbBNNfMTYkLznhnllaB == null)
					{
						return 0;
					}
					return sxWHzTWgqbBNNfMTYkLznhnllaB.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return HhStEfcVVlMiBjgWdCLXZvzOFhgb;
				}
				set
				{
					HhStEfcVVlMiBjgWdCLXZvzOFhgb = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return SVlrBPWDEySKVHcSUJitCfBSxnO;
				}
				set
				{
					SVlrBPWDEySKVHcSUJitCfBSxnO = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(sxWHzTWgqbBNNfMTYkLznhnllaB.customName)) ? sxWHzTWgqbBNNfMTYkLznhnllaB.customName : ZgzgdXTVKfkRlzrzfeUmNfHzFAx);
					if (text == "Unknown Controller")
					{
						text = hgkMJeYOCfCNxcRFlqotyZvMrEoR;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId => XcwVCJqiNcgcNAxYsxBgTcGENhR;

			[CustomObfuscation(rename = false)]
			public int unityId => EDcwRUJrjTccxnNnAhrMmqhjdqO;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!XcwVCJqiNcgcNAxYsxBgTcGENhR.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + XcwVCJqiNcgcNAxYsxBgTcGENhR);
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid => instanceGuid;

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => XRrbuPDOAbJMnDUNcTrqkgwkvwmk;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public lhBiYQLnfhmmZqOADaUJPSOxgsk(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, Controller.Extension controllerExtension, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
			{
				HRMjdsKAakYtLJeqeiyLJFLWXih = customInputSource;
				IRTGlhOkWOimkumhYFSkdpOYbETD = inputSource;
				XcwVCJqiNcgcNAxYsxBgTcGENhR = systemJoystickId;
				sxWHzTWgqbBNNfMTYkLznhnllaB = joystick;
				EDcwRUJrjTccxnNnAhrMmqhjdqO = unityJoystickId;
				XRrbuPDOAbJMnDUNcTrqkgwkvwmk = controllerExtension;
				dUeoOAWeqXvgKLTHqOAcuSQkGJiK = getHardwareJoystickMap_InputManager;
				SVlrBPWDEySKVHcSUJitCfBSxnO = -1;
				HhStEfcVVlMiBjgWdCLXZvzOFhgb = -1;
				TuOpcsNENVAllcZBZvugOvvnqjYG();
				XxHELBuvCCtGAJntxYQUzFBhOFy();
				NdHHxuQRnYAiYXlkbCSlISGovAq = REZiFujnwfIcWniRKvMxDxhPHlx.hardwareMapIdentifier.guid;
				ZgzgdXTVKfkRlzrzfeUmNfHzFAx = REZiFujnwfIcWniRKvMxDxhPHlx.controllerName;
				JzCpTyTcKdiDVvPxFKAbxEFLDAw = new float[RGhWgMAfPjfICjXGWTZxnPoNdWD];
				vEmeiLseeiFjOBSerAJjqspjZBa = new bool[SeOhWaCQLSUYyhdokorrnPTrNGB];
				Update();
			}

			public void TuOpcsNENVAllcZBZvugOvvnqjYG()
			{
				hgkMJeYOCfCNxcRFlqotyZvMrEoR = sxWHzTWgqbBNNfMTYkLznhnllaB.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (!sxWHzTWgqbBNNfMTYkLznhnllaB.isConnected)
				{
					goto IL_000d;
				}
				goto IL_0037;
				IL_000d:
				int num = 1812152829;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x6C0341FE)
				{
				case 0:
					break;
				case 3:
					return;
				case 2:
					goto IL_0037;
				default:
					nLotdmIEnGDlRjnDZLzPFXYmCSSJ();
					return;
				}
				goto IL_000d;
				IL_0037:
				UDEtzvxqREkxyopZfQhiKhodhQPJ();
				num = 1812152831;
				goto IL_0012;
			}

			public int YfzaYuFFeAGpZYIlhOCKodCcBwd(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0)
			{
				if (P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR == hgkMJeYOCfCNxcRFlqotyZvMrEoR && P_0.XcwVCJqiNcgcNAxYsxBgTcGENhR == XcwVCJqiNcgcNAxYsxBgTcGENhR)
				{
					return 2;
				}
				if (P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR == hgkMJeYOCfCNxcRFlqotyZvMrEoR)
				{
					return 1;
				}
				return 0;
			}

			private void eaqBkFPxlFldmaTQruLSPLTaGpDi(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = IRTGlhOkWOimkumhYFSkdpOYbETD;
				P_0.inputSource = IRTGlhOkWOimkumhYFSkdpOYbETD;
				while (true)
				{
					int num = -435516179;
					while (true)
					{
						switch (num ^ -435516177)
						{
						case 0:
							break;
						case 2:
							P_0.hardwareIdentifier = ZpMnvMRPjTIgPNWjtdygNONQuFr();
							P_0.hardwareAxisCount = RGhWgMAfPjfICjXGWTZxnPoNdWD;
							num = -435516178;
							continue;
						case 1:
							P_0.hardwareButtonCount = SeOhWaCQLSUYyhdokorrnPTrNGB;
							num = -435516180;
							continue;
						default:
							P_0.hardwareHatCount = 0;
							P_0.hw_productName = hgkMJeYOCfCNxcRFlqotyZvMrEoR;
							P_0.hw_supportsVibration = sxWHzTWgqbBNNfMTYkLznhnllaB.supportsVibration;
							return;
						}
						break;
					}
				}
			}

			private void eaqBkFPxlFldmaTQruLSPLTaGpDi(BridgedController P_0)
			{
				eaqBkFPxlFldmaTQruLSPLTaGpDi((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				while (true)
				{
					int num = 2021256118;
					while (true)
					{
						switch (num ^ 0x7879EBB0)
						{
						case 2:
							break;
						default:
							return;
						case 3:
							P_0.axisCount = RGhWgMAfPjfICjXGWTZxnPoNdWD;
							num = 2021256113;
							continue;
						case 0:
							P_0.productName = hgkMJeYOCfCNxcRFlqotyZvMrEoR;
							num = 2021256119;
							continue;
						case 7:
							P_0.isXInputDevice = false;
							num = 2021256115;
							continue;
						case 5:
							P_0.controllerTypeGuid = NdHHxuQRnYAiYXlkbCSlISGovAq;
							P_0.customInputSource = HRMjdsKAakYtLJeqeiyLJFLWXih;
							P_0.controllerExtension = XRrbuPDOAbJMnDUNcTrqkgwkvwmk;
							num = 2021256116;
							continue;
						case 6:
							P_0.gameHardwareMap = REZiFujnwfIcWniRKvMxDxhPHlx.ToGameHardwareControllerMap();
							P_0.instanceName = hgkMJeYOCfCNxcRFlqotyZvMrEoR;
							num = 2021256112;
							continue;
						case 1:
							P_0.buttonCount = SeOhWaCQLSUYyhdokorrnPTrNGB;
							num = 2021256117;
							continue;
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
				if (RGhWgMAfPjfICjXGWTZxnPoNdWD != dataUpdater.axisCount)
				{
					goto IL_00b6;
				}
				if (SeOhWaCQLSUYyhdokorrnPTrNGB != dataUpdater.buttonCount)
				{
					goto IL_0022;
				}
				goto IL_00cb;
				IL_00cb:
				int num = 0;
				int num2 = -1481869655;
				goto IL_0027;
				IL_0022:
				num2 = -1481869652;
				goto IL_0027;
				IL_0027:
				int num3 = default(int);
				while (true)
				{
					switch (num2 ^ -1481869654)
					{
					case 2:
						break;
					default:
						return;
					case 10:
						if (num3 >= SeOhWaCQLSUYyhdokorrnPTrNGB)
						{
							goto IL_0073;
						}
						goto case 11;
					case 3:
						if (num >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
						{
							num3 = 0;
							num2 = -1481869662;
							continue;
						}
						goto case 0;
					case 8:
						num2 = -1481869664;
						continue;
					case 6:
						goto IL_00b6;
					case 5:
						goto IL_00cb;
					case 0:
						dataUpdater.axisValues[num] = JzCpTyTcKdiDVvPxFKAbxEFLDAw[num];
						num2 = -1481869653;
						continue;
					case 4:
						dataUpdater.hasReceivedInput = true;
						num2 = -1481869661;
						continue;
					case 7:
						num3++;
						num2 = -1481869664;
						continue;
					case 11:
						dataUpdater.buttonValues[num3] = vEmeiLseeiFjOBSerAJjqspjZBa[num3];
						num2 = -1481869651;
						continue;
					case 1:
						num++;
						num2 = -1481869655;
						continue;
					case 9:
						return;
					}
					break;
					IL_0073:
					if (BjLRIbHSNziZuePSCMYMTKKmtVyj)
					{
						int num4;
						if (!dataUpdater.hasReceivedInput)
						{
							num2 = -1481869650;
							num4 = num2;
						}
						else
						{
							num2 = -1481869661;
							num4 = num2;
						}
						continue;
					}
					return;
				}
				goto IL_0022;
				IL_00b6:
				throw new Exception("This controller signature does not match the data object!");
			}

			public BridgedControllerHWInfo NGITJKBCUwztnLMkPBVweIvQEACZ()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				eaqBkFPxlFldmaTQruLSPLTaGpDi(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				eaqBkFPxlFldmaTQruLSPLTaGpDi(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(HhStEfcVVlMiBjgWdCLXZvzOFhgb);
			}

			private void UDEtzvxqREkxyopZfQhiKhodhQPJ()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)REZiFujnwfIcWniRKvMxDxhPHlx.map).Axes;
				int num2 = default(int);
				while (true)
				{
					int num = 990946420;
					while (true)
					{
						switch (num ^ 0x3B10A47C)
						{
						case 6:
							break;
						case 8:
						{
							int num3;
							if (axes != null)
							{
								num = 990946424;
								num3 = num;
							}
							else
							{
								num = 990946429;
								num3 = num;
							}
							continue;
						}
						case 7:
							num2++;
							num = 990946425;
							continue;
						case 4:
							num2 = 0;
							num = 990946425;
							continue;
						case 0:
							if (JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] != 0f)
							{
								BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
								num = 990946427;
								continue;
							}
							goto case 7;
						case 2:
							if (axes[num2] == null)
							{
								goto case 7;
							}
							if (num2 >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
							{
								throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
							}
							goto case 3;
						case 1:
							return;
						case 3:
						{
							JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] = QEVsojLqDtQsxnvxgHocZSixiJS(axes[num2]);
							int num4;
							if (!BjLRIbHSNziZuePSCMYMTKKmtVyj)
							{
								num = 990946428;
								num4 = num;
							}
							else
							{
								num = 990946427;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= axes.Length)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}

			private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)REZiFujnwfIcWniRKvMxDxhPHlx.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = -70731593;
					while (true)
					{
						switch (num2 ^ -70731599)
						{
						case 4:
							num2 = -70731600;
							continue;
						case 0:
						{
							int num3;
							if (BjLRIbHSNziZuePSCMYMTKKmtVyj)
							{
								num2 = -70731597;
								num3 = num2;
							}
							else
							{
								num2 = -70731594;
								num3 = num2;
							}
							continue;
						}
						case 7:
							if (vEmeiLseeiFjOBSerAJjqspjZBa[num])
							{
								BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
								num2 = -70731597;
								continue;
							}
							goto case 2;
						case 5:
							if (num >= SeOhWaCQLSUYyhdokorrnPTrNGB)
							{
								throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
							}
							goto case 3;
						case 1:
							break;
						case 3:
							vEmeiLseeiFjOBSerAJjqspjZBa[num] = oKAKkOrHJCSQdjvqMprroEgDqcJ(buttons[num]);
							num2 = -70731599;
							continue;
						case 2:
							num++;
							num2 = -70731593;
							continue;
						default:
							if (num >= buttons.Length)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			private bool oKAKkOrHJCSQdjvqMprroEgDqcJ(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.sourceButton);
				}
				float num2 = default(float);
				if (P_0.sourceType == 1)
				{
					while (true)
					{
						int num = 1663559506;
						while (true)
						{
							switch (num ^ 0x6327E753)
							{
							case 0:
								break;
							case 1:
								num2 = QEVsojLqDtQsxnvxgHocZSixiJS(P_0.sourceAxis);
								if (MathTools.Abs(num2) <= P_0.axisDeadZone)
								{
									return false;
								}
								if (P_0.sourceAxisPole == Pole.Positive && num2 < 0f)
								{
									return false;
								}
								if (P_0.sourceAxisPole == Pole.Negative)
								{
									goto IL_0074;
								}
								goto IL_0085;
							default:
								{
									if (num2 > 0f)
									{
										return false;
									}
									goto IL_0085;
								}
								IL_0085:
								return true;
							}
							break;
							IL_0074:
							num = 1663559505;
						}
					}
				}
				return false;
			}

			private bool JAErmqvBztkYNHMmRQcBfRempVw(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float QEVsojLqDtQsxnvxgHocZSixiJS(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return QEVsojLqDtQsxnvxgHocZSixiJS(P_0.sourceAxis);
				}
				float result = default(float);
				int num;
				if (P_0.sourceType == 0)
				{
					if (!oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.sourceButton))
					{
						goto IL_0030;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = -468427959;
						goto IL_0035;
					}
					goto IL_006d;
				}
				throw new NotImplementedException();
				IL_006d:
				result = -1f;
				num = -468427959;
				goto IL_0035;
				IL_0035:
				switch (num ^ -468427959)
				{
				case 3:
					break;
				case 1:
					return 0f;
				case 2:
					goto IL_006d;
				default:
					return result;
				}
				goto IL_0030;
				IL_0030:
				num = -468427960;
				goto IL_0035;
			}

			private float QEVsojLqDtQsxnvxgHocZSixiJS(int P_0)
			{
				return sxWHzTWgqbBNNfMTYkLznhnllaB.GetAxisValue(P_0);
			}

			private bool oKAKkOrHJCSQdjvqMprroEgDqcJ(int P_0)
			{
				return sxWHzTWgqbBNNfMTYkLznhnllaB.GetButtonValue(P_0);
			}

			private void XxHELBuvCCtGAJntxYQUzFBhOFy()
			{
				REZiFujnwfIcWniRKvMxDxhPHlx = dUeoOAWeqXvgKLTHqOAcuSQkGJiK(NGITJKBCUwztnLMkPBVweIvQEACZ());
				if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
				{
					while (true)
					{
						switch (0x44A21207 ^ 0x44A21205)
						{
						case 0:
							continue;
						case 2:
							Logger.LogError("Default hardware map not found!");
							return;
						}
						break;
					}
				}
				RGhWgMAfPjfICjXGWTZxnPoNdWD = REZiFujnwfIcWniRKvMxDxhPHlx.axisCount;
				SeOhWaCQLSUYyhdokorrnPTrNGB = REZiFujnwfIcWniRKvMxDxhPHlx.buttonCount;
			}

			private void doSrWnbYutMRvEmuTwguCvcTazP()
			{
				Array.Clear(vEmeiLseeiFjOBSerAJjqspjZBa, 0, vEmeiLseeiFjOBSerAJjqspjZBa.Length);
				Array.Clear(JzCpTyTcKdiDVvPxFKAbxEFLDAw, 0, JzCpTyTcKdiDVvPxFKAbxEFLDAw.Length);
			}

			private string ZpMnvMRPjTIgPNWjtdygNONQuFr()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{IRTGlhOkWOimkumhYFSkdpOYbETD.ToString()}{hgkMJeYOCfCNxcRFlqotyZvMrEoR}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{IRTGlhOkWOimkumhYFSkdpOYbETD.ToString()}{hgkMJeYOCfCNxcRFlqotyZvMrEoR}");
			}

			public static int ehhMYpWNAIOMCksfriRCZCIBJmK(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, lhBiYQLnfhmmZqOADaUJPSOxgsk P_1)
			{
				if (P_0.SVlrBPWDEySKVHcSUJitCfBSxnO < P_1.SVlrBPWDEySKVHcSUJitCfBSxnO)
				{
					return -1;
				}
				if (P_0.SVlrBPWDEySKVHcSUJitCfBSxnO > P_1.SVlrBPWDEySKVHcSUJitCfBSxnO)
				{
					return 1;
				}
				return 0;
			}

			public static int HvfjzvQvjexjRTguxMiTnsTjOCk(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, lhBiYQLnfhmmZqOADaUJPSOxgsk P_1)
			{
				if (P_0.XcwVCJqiNcgcNAxYsxBgTcGENhR < P_1.XcwVCJqiNcgcNAxYsxBgTcGENhR)
				{
					return -1;
				}
				if (P_0.XcwVCJqiNcgcNAxYsxBgTcGENhR > P_1.XcwVCJqiNcgcNAxYsxBgTcGENhR)
				{
					return 1;
				}
				return 0;
			}
		}

		private class HuUXmoVjKtZgiBunoGiLZoHKaFw
		{
			public enum cXMUTOCaLscKmEFwfrwvgHJxQBt
			{
				zlJMCEeCIoRemLBsAgqNdRDgziDK = 0,
				BKFaaxAPcuBcJAcYJSBDkcEuaeHB = 1
			}

			public class YVyGawaeUarGhxDRtRZLlSdHRrwQ
			{
				public int UKCDHORBCFHBoYLTIFGoDfJwMEGs;

				public long? cLWCqaWuBmaQypqcNFvOKmcxPrH;

				public string WiWNmcNXUQMISiVDOAtiXWTRbUC;

				public int MrgFvxEmVvleAtwmEJiJFGTJUZgS;

				public int SeOhWaCQLSUYyhdokorrnPTrNGB;

				public int RGhWgMAfPjfICjXGWTZxnPoNdWD;

				public YVyGawaeUarGhxDRtRZLlSdHRrwQ(int rewiredId, long? systemId, string systemControllerName, int lastInputManagerId, int buttonCount, int axisCount)
				{
					UKCDHORBCFHBoYLTIFGoDfJwMEGs = rewiredId;
					cLWCqaWuBmaQypqcNFvOKmcxPrH = systemId;
					WiWNmcNXUQMISiVDOAtiXWTRbUC = systemControllerName;
					MrgFvxEmVvleAtwmEJiJFGTJUZgS = lastInputManagerId;
					SeOhWaCQLSUYyhdokorrnPTrNGB = buttonCount;
					RGhWgMAfPjfICjXGWTZxnPoNdWD = axisCount;
				}

				public bool YfzaYuFFeAGpZYIlhOCKodCcBwd(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, cXMUTOCaLscKmEFwfrwvgHJxQBt P_1)
				{
					if (P_0.rewiredId == UKCDHORBCFHBoYLTIFGoDfJwMEGs)
					{
						return true;
					}
					if (P_0.hardwareButtonCount != SeOhWaCQLSUYyhdokorrnPTrNGB)
					{
						return false;
					}
					if (P_0.hardwareAxisCount != RGhWgMAfPjfICjXGWTZxnPoNdWD)
					{
						return false;
					}
					switch (P_1)
					{
					case cXMUTOCaLscKmEFwfrwvgHJxQBt.zlJMCEeCIoRemLBsAgqNdRDgziDK:
					{
						long? num = cLWCqaWuBmaQypqcNFvOKmcxPrH;
						long? systemId = default(long?);
						while (true)
						{
							int num2 = -1848767293;
							while (true)
							{
								switch (num2 ^ -1848767295)
								{
								case 0:
									break;
								case 2:
									systemId = P_0.systemId;
									if (num.GetValueOrDefault() == systemId.GetValueOrDefault())
									{
										goto IL_006f;
									}
									goto IL_009d;
								default:
									{
										if (num.HasValue == systemId.HasValue)
										{
											return WiWNmcNXUQMISiVDOAtiXWTRbUC == P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR;
										}
										goto IL_009d;
									}
									IL_009d:
									return false;
								}
								break;
								IL_006f:
								num2 = -1848767296;
							}
						}
					}
					case cXMUTOCaLscKmEFwfrwvgHJxQBt.BKFaaxAPcuBcJAcYJSBDkcEuaeHB:
						return WiWNmcNXUQMISiVDOAtiXWTRbUC == P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class nMVaWXGUKEcGuSOlzWUbnnOHxQdP : IDisposable, IEnumerator, IEnumerable, IEnumerable<YVyGawaeUarGhxDRtRZLlSdHRrwQ>, IEnumerator<YVyGawaeUarGhxDRtRZLlSdHRrwQ>
			{
				private YVyGawaeUarGhxDRtRZLlSdHRrwQ ubyTdixGSFKGaFQFZdQnpwgWIvJ;

				private int isaqVUvqwfWYqOUtovbpbCbxgPc;

				private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

				public HuUXmoVjKtZgiBunoGiLZoHKaFw syCPfFbHYMDOvEPjTnPLBqiOhsPv;

				public lhBiYQLnfhmmZqOADaUJPSOxgsk GHCGdCDbjrofHQLylQoSJOXGrsCj;

				public lhBiYQLnfhmmZqOADaUJPSOxgsk kBIDOXdTvkXDGsXBIDEoXEkSifNc;

				public cXMUTOCaLscKmEFwfrwvgHJxQBt deDQMJLHHfbmUIovbnujIcUjOUK;

				public cXMUTOCaLscKmEFwfrwvgHJxQBt DjGvqohErCEFaeFNfFegiWUXHde;

				public int eUzfiKzKPdkfmpdUHNQtQOYabEQ;

				public int OBbXNebLfhIFLIgnBqVzXywdxhFu;

				YVyGawaeUarGhxDRtRZLlSdHRrwQ IEnumerator<YVyGawaeUarGhxDRtRZLlSdHRrwQ>.Current
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
				IEnumerator<YVyGawaeUarGhxDRtRZLlSdHRrwQ> IEnumerable<YVyGawaeUarGhxDRtRZLlSdHRrwQ>.GetEnumerator()
				{
					if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						goto IL_0023;
					}
					goto IL_0065;
					IL_0028:
					int num;
					nMVaWXGUKEcGuSOlzWUbnnOHxQdP nMVaWXGUKEcGuSOlzWUbnnOHxQdP2 = default(nMVaWXGUKEcGuSOlzWUbnnOHxQdP);
					while (true)
					{
						switch (num ^ -2124941120)
						{
						case 0:
							break;
						case 4:
							nMVaWXGUKEcGuSOlzWUbnnOHxQdP2 = this;
							num = -2124941118;
							continue;
						case 2:
							nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.GHCGdCDbjrofHQLylQoSJOXGrsCj = kBIDOXdTvkXDGsXBIDEoXEkSifNc;
							num = -2124941119;
							continue;
						case 3:
							goto IL_0065;
						default:
							nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.deDQMJLHHfbmUIovbnujIcUjOUK = DjGvqohErCEFaeFNfFegiWUXHde;
							return nMVaWXGUKEcGuSOlzWUbnnOHxQdP2;
						}
						break;
					}
					goto IL_0023;
					IL_0065:
					nMVaWXGUKEcGuSOlzWUbnnOHxQdP2 = new nMVaWXGUKEcGuSOlzWUbnnOHxQdP(0);
					nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
					num = -2124941118;
					goto IL_0028;
					IL_0023:
					num = -2124941116;
					goto IL_0028;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<YVyGawaeUarGhxDRtRZLlSdHRrwQ>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					while (true)
					{
						int num2 = 251054544;
						while (true)
						{
							switch (num2 ^ 0xEF6C9D6)
							{
							case 9:
								break;
							case 6:
								switch (num)
								{
								default:
									num2 = 251054551;
									continue;
								case 1:
									isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
									num2 = 251054547;
									continue;
								case 0:
									break;
								}
								goto case 3;
							case 5:
								OBbXNebLfhIFLIgnBqVzXywdxhFu++;
								num2 = 251054550;
								continue;
							case 8:
								num2 = 251054550;
								continue;
							case 2:
								return true;
							case 0:
							{
								int num4;
								if (OBbXNebLfhIFLIgnBqVzXywdxhFu < eUzfiKzKPdkfmpdUHNQtQOYabEQ)
								{
									num2 = 251054556;
									num4 = num2;
								}
								else
								{
									num2 = 251054551;
									num4 = num2;
								}
								continue;
							}
							case 7:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num2 = 251054548;
								continue;
							case 3:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								eUzfiKzKPdkfmpdUHNQtQOYabEQ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO.Count;
								OBbXNebLfhIFLIgnBqVzXywdxhFu = 0;
								num2 = 251054558;
								continue;
							case 10:
							{
								int num3;
								if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[OBbXNebLfhIFLIgnBqVzXywdxhFu].YfzaYuFFeAGpZYIlhOCKodCcBwd(GHCGdCDbjrofHQLylQoSJOXGrsCj, deDQMJLHHfbmUIovbnujIcUjOUK))
								{
									num2 = 251054547;
									num3 = num2;
								}
								else
								{
									num2 = 251054546;
									num3 = num2;
								}
								continue;
							}
							case 4:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[OBbXNebLfhIFLIgnBqVzXywdxhFu];
								num2 = 251054545;
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
				public nMVaWXGUKEcGuSOlzWUbnnOHxQdP(int _003C_003E1__state)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
					TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private List<YVyGawaeUarGhxDRtRZLlSdHRrwQ> pYylSnaZhhHPlmcssGUseHaIflO;

			public int Count => pYylSnaZhhHPlmcssGUseHaIflO.Count;

			public HuUXmoVjKtZgiBunoGiLZoHKaFw()
			{
				pYylSnaZhhHPlmcssGUseHaIflO = new List<YVyGawaeUarGhxDRtRZLlSdHRrwQ>();
			}

			public void tXgmibXCLFITLeBlRtsWPalapKpT(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				while (true)
				{
					int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
					int num = 0;
					int num2 = 920541079;
					while (true)
					{
						switch (num2 ^ 0x36DE5790)
						{
						case 2:
							num2 = 920541075;
							continue;
						default:
							return;
						case 3:
							break;
						case 8:
							pYylSnaZhhHPlmcssGUseHaIflO[num].SeOhWaCQLSUYyhdokorrnPTrNGB = P_0.hardwareButtonCount;
							pYylSnaZhhHPlmcssGUseHaIflO[num].RGhWgMAfPjfICjXGWTZxnPoNdWD = P_0.hardwareAxisCount;
							DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, num);
							num2 = 920541073;
							continue;
						case 1:
							return;
						case 7:
							if (num >= count)
							{
								pYylSnaZhhHPlmcssGUseHaIflO.Add(new YVyGawaeUarGhxDRtRZLlSdHRrwQ(P_0.rewiredId, P_0.systemId, P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR, P_0.inputManagerId, P_0.hardwareButtonCount, P_0.hardwareAxisCount));
								DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, pYylSnaZhhHPlmcssGUseHaIflO.Count - 1);
								num2 = 920541076;
								continue;
							}
							goto case 0;
						case 6:
							num++;
							num2 = 920541079;
							continue;
						case 0:
						{
							int num3;
							if (pYylSnaZhhHPlmcssGUseHaIflO[num].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, cXMUTOCaLscKmEFwfrwvgHJxQBt.zlJMCEeCIoRemLBsAgqNdRDgziDK))
							{
								num2 = 920541077;
								num3 = num2;
							}
							else
							{
								num2 = 920541078;
								num3 = num2;
							}
							continue;
						}
						case 5:
							pYylSnaZhhHPlmcssGUseHaIflO[num].UKCDHORBCFHBoYLTIFGoDfJwMEGs = P_0.rewiredId;
							pYylSnaZhhHPlmcssGUseHaIflO[num].cLWCqaWuBmaQypqcNFvOKmcxPrH = P_0.systemId;
							pYylSnaZhhHPlmcssGUseHaIflO[num].WiWNmcNXUQMISiVDOAtiXWTRbUC = P_0.hgkMJeYOCfCNxcRFlqotyZvMrEoR;
							pYylSnaZhhHPlmcssGUseHaIflO[num].MrgFvxEmVvleAtwmEJiJFGTJUZgS = P_0.inputManagerId;
							num2 = 920541080;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}

			public bool QUzJIwsyLBGiiDjdziRDeDUvrEq(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, cXMUTOCaLscKmEFwfrwvgHJxQBt P_1)
			{
				int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
				int num = 0;
				while (true)
				{
					int num2 = 1488517651;
					while (true)
					{
						switch (num2 ^ 0x58B8FA12)
						{
						case 2:
							break;
						case 3:
						{
							int num3;
							if (num >= count)
							{
								num2 = 1488517650;
								num3 = num2;
							}
							else
							{
								num2 = 1488517654;
								num3 = num2;
							}
							continue;
						}
						case 4:
							if (pYylSnaZhhHPlmcssGUseHaIflO[num].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, P_1))
							{
								return true;
							}
							num++;
							num2 = 1488517649;
							continue;
						case 1:
							num2 = 1488517649;
							continue;
						default:
							return false;
						}
						break;
					}
				}
			}

			public IEnumerable<YVyGawaeUarGhxDRtRZLlSdHRrwQ> ujuphkmYzsIfimEfOMVCHtLnQKt(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, cXMUTOCaLscKmEFwfrwvgHJxQBt P_1)
			{
				nMVaWXGUKEcGuSOlzWUbnnOHxQdP nMVaWXGUKEcGuSOlzWUbnnOHxQdP2 = new nMVaWXGUKEcGuSOlzWUbnnOHxQdP(-2);
				nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.kBIDOXdTvkXDGsXBIDEoXEkSifNc = P_0;
				nMVaWXGUKEcGuSOlzWUbnnOHxQdP2.DjGvqohErCEFaeFNfFegiWUXHde = P_1;
				return nMVaWXGUKEcGuSOlzWUbnnOHxQdP2;
			}

			public int KhufsiHazfkStoHkXbcGhTzBsNFW(YVyGawaeUarGhxDRtRZLlSdHRrwQ P_0)
			{
				int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
				int num = 0;
				while (true)
				{
					int num2 = 107207866;
					while (true)
					{
						switch (num2 ^ 0x663DCB9)
						{
						case 2:
							break;
						case 3:
							num2 = 107207864;
							continue;
						case 0:
							if (pYylSnaZhhHPlmcssGUseHaIflO[num] == P_0)
							{
								return num;
							}
							num++;
							num2 = 107207864;
							continue;
						default:
							if (num >= count)
							{
								return -1;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			private void DEiihYzBOuDCWDVSMxebepjOOeX(int P_0, int P_1)
			{
				int num = pYylSnaZhhHPlmcssGUseHaIflO.Count - 1;
				while (true)
				{
					int num2 = -2084354332;
					while (true)
					{
						switch (num2 ^ -2084354336)
						{
						case 3:
							break;
						case 4:
							num2 = -2084354334;
							continue;
						case 0:
							num--;
							num2 = -2084354334;
							continue;
						case 1:
							if (num != P_1 && pYylSnaZhhHPlmcssGUseHaIflO[num].UKCDHORBCFHBoYLTIFGoDfJwMEGs == P_0)
							{
								pYylSnaZhhHPlmcssGUseHaIflO.RemoveAt(num);
								num2 = -2084354336;
								continue;
							}
							goto case 0;
						default:
							if (num < 0)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		private List<lhBiYQLnfhmmZqOADaUJPSOxgsk> KjXmBSVldpfwjiNaozEQFsyjEtD;

		private int zCJDBcHESKfNGvcIMmoYVGihyIj;

		private HuUXmoVjKtZgiBunoGiLZoHKaFw ZDGzEdGlsfPIXxxIiRhCInujjGU;

		private UpdateLoopType vuGbLgVYuadXzhzNZHvlhRNLlqP;

		private Action<int, ControllerDataUpdater> QwkejmzJqWXCTBNLCkdLqDDUJzf;

		private PlatformInputManager UkMXWLCIyaKLnYPfeWzjKwidlAk;

		private CustomInputSource HRMjdsKAakYtLJeqeiyLJFLWXih;

		private bool VjAUYAWOZYRvlAZvsjAqxlszqGZ;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dUeoOAWeqXvgKLTHqOAcuSQkGJiK;

		private Func<int> sSVyKfminzFIZSXvvbOACNrjwsU;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => zCJDBcHESKfNGvcIMmoYVGihyIj;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => UkMXWLCIyaKLnYPfeWzjKwidlAk;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => HRMjdsKAakYtLJeqeiyLJFLWXih.inputSource;

		public CustomInputManager(CustomInputSource customInputSource, UpdateLoopSetting updateLoopSetting, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			HRMjdsKAakYtLJeqeiyLJFLWXih = customInputSource;
			dUeoOAWeqXvgKLTHqOAcuSQkGJiK = getHardwareJoystickMap_InputManager;
			sSVyKfminzFIZSXvvbOACNrjwsU = getNewJoystickId;
			UkMXWLCIyaKLnYPfeWzjKwidlAk = this;
			try
			{
				QwkejmzJqWXCTBNLCkdLqDDUJzf = UpdateControllerData;
				customInputSource.JoystickConnectedEvent += SystemDeviceConnected;
				customInputSource.JoystickDisconnectedEvent += SystemDeviceDisconnected;
			}
			catch (Exception)
			{
				OnDestroy();
				throw;
			}
		}

		[CustomObfuscation(rename = false)]
		public override void Initialize()
		{
			ZDGzEdGlsfPIXxxIiRhCInujjGU = new HuUXmoVjKtZgiBunoGiLZoHKaFw();
			KjXmBSVldpfwjiNaozEQFsyjEtD = new List<lhBiYQLnfhmmZqOADaUJPSOxgsk>();
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			vuGbLgVYuadXzhzNZHvlhRNLlqP = updateLoop;
			if (!HRMjdsKAakYtLJeqeiyLJFLWXih.isReady)
			{
				goto IL_0014;
			}
			goto IL_0057;
			IL_0014:
			int num = -1172076920;
			goto IL_0019;
			IL_0019:
			while (true)
			{
				switch (num ^ -1172076917)
				{
				case 0:
					break;
				case 3:
					return;
				case 4:
					if (VjAUYAWOZYRvlAZvsjAqxlszqGZ)
					{
						MFhjbGVDbNrOVBNutDpnZUWGDEP();
						num = -1172076919;
						continue;
					}
					goto default;
				case 1:
					goto IL_0057;
				default:
					jqvaloCvHNpVrQxERwhVWaVTZgBw();
					return;
				}
				break;
			}
			goto IL_0014;
			IL_0057:
			HRMjdsKAakYtLJeqeiyLJFLWXih.Update();
			num = -1172076913;
			goto IL_0019;
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (HRMjdsKAakYtLJeqeiyLJFLWXih != null)
			{
				HRMjdsKAakYtLJeqeiyLJFLWXih.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return QwkejmzJqWXCTBNLCkdLqDDUJzf;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < zCJDBcHESKfNGvcIMmoYVGihyIj)
				{
					num2 = 578072985;
					num3 = num2;
				}
				else
				{
					num2 = 578072986;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2274B19B)
					{
					case 3:
						num2 = 578072985;
						continue;
					case 2:
						if (KjXmBSVldpfwjiNaozEQFsyjEtD[num].inputManagerId == inputManagerId)
						{
							KjXmBSVldpfwjiNaozEQFsyjEtD[num].FillData(data);
							return;
						}
						goto case 4;
					case 0:
						break;
					case 4:
						num++;
						num2 = 578072987;
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
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
			while (true)
			{
				int num = 784307105;
				while (true)
				{
					switch (num ^ 0x2EBF93A0)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (_SystemDeviceConnectedEvent != null)
						{
							goto IL_002d;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_002d:
					_SystemDeviceConnectedEvent();
					num = 784307104;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
			if (_SystemDeviceDisconnectedEvent == null)
			{
				return;
			}
			while (true)
			{
				int num = -1700752255;
				while (true)
				{
					switch (num ^ -1700752256)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002d;
					case 0:
						return;
					}
					break;
					IL_002d:
					_SystemDeviceDisconnectedEvent();
					num = -1700752256;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
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

		private void YAYLplglEiMaFnRMMiGNmldzCmUa(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<lhBiYQLnfhmmZqOADaUJPSOxgsk> kjXmBSVldpfwjiNaozEQFsyjEtD = KjXmBSVldpfwjiNaozEQFsyjEtD;
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = -104457874;
				while (true)
				{
					switch (num2 ^ -104457877)
					{
					case 7:
						break;
					case 4:
						if (P_0[num4] != null)
						{
							lhBiYQLnfhmmZqOADaUJPSOxgsk item = new lhBiYQLnfhmmZqOADaUJPSOxgsk(HRMjdsKAakYtLJeqeiyLJFLWXih, P_0[num4].systemId, P_0[num4].unityId, P_0[num4], HRMjdsKAakYtLJeqeiyLJFLWXih.inputSource, P_0[num4].extension, dUeoOAWeqXvgKLTHqOAcuSQkGJiK);
							KjXmBSVldpfwjiNaozEQFsyjEtD.Add(item);
							num++;
							num2 = -104457875;
							continue;
						}
						goto case 6;
					case 3:
						if (num4 >= P_0.Length)
						{
							zCJDBcHESKfNGvcIMmoYVGihyIj = num;
							WBFBlruLRCLpAZLkknTLUfchufi(num5, num, kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD);
							num3 = 0;
							num2 = -104457879;
							continue;
						}
						goto case 4;
					case 0:
						num3++;
						num2 = -104457879;
						continue;
					case 6:
						num4++;
						num2 = -104457880;
						continue;
					case 8:
						num4 = 0;
						num2 = -104457880;
						continue;
					case 1:
						if (_UpdateControllerInfoEvent != null)
						{
							_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(KjXmBSVldpfwjiNaozEQFsyjEtD[num3]));
							num2 = -104457877;
							continue;
						}
						goto case 0;
					case 5:
						num5 = zCJDBcHESKfNGvcIMmoYVGihyIj;
						KjXmBSVldpfwjiNaozEQFsyjEtD = new List<lhBiYQLnfhmmZqOADaUJPSOxgsk>();
						num2 = -104457885;
						continue;
					default:
						if (num3 >= num)
						{
							DvAgAsBJXkezynrKQNPnZfxrsAT(kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD, false);
							DvAgAsBJXkezynrKQNPnZfxrsAT(KjXmBSVldpfwjiNaozEQFsyjEtD, kjXmBSVldpfwjiNaozEQFsyjEtD, true);
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private void jqvaloCvHNpVrQxERwhVWaVTZgBw()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < zCJDBcHESKfNGvcIMmoYVGihyIj)
				{
					num2 = 898743395;
					num3 = num2;
				}
				else
				{
					num2 = 898743392;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x3591BC62)
					{
					case 0:
						num2 = 898743395;
						continue;
					default:
						return;
					case 1:
						KjXmBSVldpfwjiNaozEQFsyjEtD[num].Update();
						num++;
						num2 = 898743393;
						continue;
					case 3:
						break;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void WBFBlruLRCLpAZLkknTLUfchufi(int P_0, int P_1, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_2, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(lhBiYQLnfhmmZqOADaUJPSOxgsk.HvfjzvQvjexjRTguxMiTnsTjOCk);
				goto IL_001a;
			}
			goto IL_00b5;
			IL_014b:
			IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt.zlJMCEeCIoRemLBsAgqNdRDgziDK);
			int num;
			if (HRMjdsKAakYtLJeqeiyLJFLWXih.useApproximateMatching)
			{
				IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
				num = -336706104;
				goto IL_001f;
			}
			goto IL_00a9;
			IL_001a:
			num = -336706103;
			goto IL_001f;
			IL_001f:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -336706110)
				{
				case 9:
					break;
				case 7:
				{
					lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk2 = P_3[num2];
					if (lhBiYQLnfhmmZqOADaUJPSOxgsk2 != null && lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId < 0)
					{
						lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_3);
						lhBiYQLnfhmmZqOADaUJPSOxgsk2.rewiredId = ReInput.GetNewJoystickId();
						ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(lhBiYQLnfhmmZqOADaUJPSOxgsk2);
						num = -336706102;
						continue;
					}
					goto case 8;
				}
				case 10:
					goto IL_00a9;
				case 11:
					goto IL_00b5;
				case 1:
					if (P_1 > 0)
					{
						WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt.zlJMCEeCIoRemLBsAgqNdRDgziDK);
						num = -336706112;
						continue;
					}
					goto IL_014b;
				case 0:
					num = -336706105;
					continue;
				case 3:
					WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
					num = -336706108;
					continue;
				case 8:
					num2++;
					num = -336706105;
					continue;
				case 5:
					goto IL_0112;
				case 2:
					goto IL_012a;
				case 6:
					goto IL_014b;
				default:
					P_3.Sort(lhBiYQLnfhmmZqOADaUJPSOxgsk.ehhMYpWNAIOMCksfriRCZCIBJmK);
					return;
				}
				break;
				IL_012a:
				int num3;
				if (HRMjdsKAakYtLJeqeiyLJFLWXih.useApproximateMatching)
				{
					num = -336706111;
					num3 = num;
				}
				else
				{
					num = -336706108;
					num3 = num;
				}
				continue;
				IL_0112:
				int num4;
				if (num2 < P_1)
				{
					num = -336706107;
					num4 = num;
				}
				else
				{
					num = -336706106;
					num4 = num;
				}
			}
			goto IL_001a;
			IL_00b5:
			if (P_0 > 0)
			{
				num = -336706109;
				goto IL_001f;
			}
			goto IL_014b;
			IL_00a9:
			num2 = 0;
			num = -336706110;
			goto IL_001f;
		}

		private void bAaaRABRdZwxMnddEjixrGLYNAe(List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			int num = 0;
			while (true)
			{
				int num2 = -1603110575;
				while (true)
				{
					switch (num2 ^ -1603110574)
					{
					case 4:
						break;
					case 3:
						num2 = -1603110573;
						continue;
					case 2:
						num++;
						num2 = -1603110573;
						continue;
					case 5:
						P_0[num].inputManagerId = -1;
						num2 = -1603110576;
						continue;
					case 0:
						if (num != P_1 && P_0[num] != null)
						{
							int num3;
							if (P_0[num].inputManagerId == P_2)
							{
								num2 = -1603110569;
								num3 = num2;
							}
							else
							{
								num2 = -1603110576;
								num3 = num2;
							}
							continue;
						}
						goto case 2;
					default:
						if (num >= count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private bool pgNWowjBpVDUsfPflzUQpiDLSMiQ(List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_0, int P_1)
		{
			int count = P_0.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 1956242532;
					num3 = num2;
				}
				else
				{
					num2 = 1956242533;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x7499E466)
					{
					case 0:
						num2 = 1956242532;
						continue;
					case 2:
						if (P_0[num] != null && P_0[num].inputManagerId == P_1)
						{
							return false;
						}
						num++;
						num2 = 1956242535;
						continue;
					case 1:
						break;
					default:
						return true;
					}
					break;
				}
			}
		}

		private int xsxJptmMPnqGtRxSuBrOBHkSWsg(List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_0)
		{
			int num = 0;
			int num3 = default(int);
			int count = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num2 = -262254951;
				while (true)
				{
					switch (num2 ^ -262254952)
					{
					case 0:
						break;
					case 2:
					{
						int num4;
						if (num3 >= count)
						{
							num2 = -262254948;
							num4 = num2;
						}
						else
						{
							num2 = -262254947;
							num4 = num2;
						}
						continue;
					}
					case 4:
						if (!flag)
						{
							num2 = -262254946;
							continue;
						}
						num++;
						goto case 1;
					case 5:
						if (P_0[num3] != null && P_0[num3].inputManagerId == num)
						{
							flag = true;
							num2 = -262254948;
							continue;
						}
						goto case 3;
					case 1:
						flag = false;
						count = P_0.Count;
						num3 = 0;
						num2 = -262254950;
						continue;
					case 3:
						num3++;
						num2 = -262254950;
						continue;
					default:
						return num;
					}
					break;
				}
			}
		}

		private bool tDUJWQkhxomwvbhOaOoQeAWVFSH(List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				int num2 = 595108273;
				while (true)
				{
					switch (num2 ^ 0x2378A1B0)
					{
					case 4:
						break;
					case 1:
						num2 = 595108275;
						continue;
					case 2:
						return true;
					case 0:
						if (P_0[num].rewiredId != P_1)
						{
							num++;
							num2 = 595108275;
						}
						else
						{
							num2 = 595108274;
						}
						continue;
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

		private void WWBpSaLxuMDBckrvrBppKtPxZoIQ(int P_0, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_1, int P_2, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_3, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt P_4)
		{
			int num = ((P_4 != HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt.zlJMCEeCIoRemLBsAgqNdRDgziDK) ? 1 : 2);
			int num2 = 0;
			lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk3 = default(lhBiYQLnfhmmZqOADaUJPSOxgsk);
			int num6 = default(int);
			lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk2 = default(lhBiYQLnfhmmZqOADaUJPSOxgsk);
			while (true)
			{
				int num3;
				int num4;
				if (num2 < P_0)
				{
					num3 = 412297293;
					num4 = num3;
				}
				else
				{
					num3 = 412297280;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x18932844)
					{
					case 7:
						num3 = 412297293;
						continue;
					default:
						return;
					case 8:
						lhBiYQLnfhmmZqOADaUJPSOxgsk3 = P_3[num6];
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk3 != null && !tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, lhBiYQLnfhmmZqOADaUJPSOxgsk3.rewiredId))
						{
							int num8;
							if (lhBiYQLnfhmmZqOADaUJPSOxgsk2.YfzaYuFFeAGpZYIlhOCKodCcBwd(lhBiYQLnfhmmZqOADaUJPSOxgsk3) >= num)
							{
								num3 = 412297285;
								num8 = num3;
							}
							else
							{
								num3 = 412297295;
								num8 = num3;
							}
							continue;
						}
						goto case 11;
					case 6:
						num2++;
						num3 = 412297286;
						continue;
					case 5:
					{
						int num9;
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk2 != null)
						{
							num3 = 412297284;
							num9 = num3;
						}
						else
						{
							num3 = 412297282;
							num9 = num3;
						}
						continue;
					}
					case 10:
						num6 = 0;
						num3 = 412297287;
						continue;
					case 9:
						lhBiYQLnfhmmZqOADaUJPSOxgsk2 = P_1[num2];
						num3 = 412297281;
						continue;
					case 2:
						break;
					case 11:
						num6++;
						num3 = 412297287;
						continue;
					case 1:
						lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId = lhBiYQLnfhmmZqOADaUJPSOxgsk3.inputManagerId;
						lhBiYQLnfhmmZqOADaUJPSOxgsk2.rewiredId = lhBiYQLnfhmmZqOADaUJPSOxgsk3.rewiredId;
						ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(lhBiYQLnfhmmZqOADaUJPSOxgsk2);
						num3 = 412297295;
						continue;
					case 3:
					{
						int num7;
						if (num6 >= P_2)
						{
							num3 = 412297282;
							num7 = num3;
						}
						else
						{
							num3 = 412297292;
							num7 = num3;
						}
						continue;
					}
					case 0:
					{
						int num5;
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId >= 0)
						{
							num3 = 412297282;
							num5 = num3;
						}
						else
						{
							num3 = 412297294;
							num5 = num3;
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

		private void IrBuLLxHFdDknWWFKqrzDdBoboV(int P_0, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_1, HuUXmoVjKtZgiBunoGiLZoHKaFw.cXMUTOCaLscKmEFwfrwvgHJxQBt P_2)
		{
			int num = 0;
			lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk2 = default(lhBiYQLnfhmmZqOADaUJPSOxgsk);
			HuUXmoVjKtZgiBunoGiLZoHKaFw.YVyGawaeUarGhxDRtRZLlSdHRrwQ yVyGawaeUarGhxDRtRZLlSdHRrwQ = default(HuUXmoVjKtZgiBunoGiLZoHKaFw.YVyGawaeUarGhxDRtRZLlSdHRrwQ);
			int num4 = default(int);
			while (true)
			{
				IL_0167:
				if (num < P_0)
				{
					while (true)
					{
						lhBiYQLnfhmmZqOADaUJPSOxgsk2 = P_1[num];
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk2 == null)
						{
							break;
						}
						int num2 = -1481064395;
						while (true)
						{
							switch (num2 ^ -1481064395)
							{
							case 3:
								num2 = -1481064396;
								continue;
							case 1:
								break;
							case 0:
								goto IL_003e;
							default:
								goto IL_0053;
							}
							break;
							IL_003e:
							if (lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId >= 0)
							{
								goto end_IL_0029;
							}
							yVyGawaeUarGhxDRtRZLlSdHRrwQ = null;
							num2 = -1481064393;
						}
						continue;
						end_IL_0029:
						break;
					}
					goto IL_019c;
				}
				int num3 = -1481064396;
				goto IL_011f;
				IL_019c:
				num++;
				num3 = -1481064400;
				goto IL_011f;
				IL_011f:
				while (true)
				{
					switch (num3 ^ -1481064395)
					{
					case 0:
						break;
					default:
						return;
					case 6:
						lhBiYQLnfhmmZqOADaUJPSOxgsk2.rewiredId = yVyGawaeUarGhxDRtRZLlSdHRrwQ.UKCDHORBCFHBoYLTIFGoDfJwMEGs;
						ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(lhBiYQLnfhmmZqOADaUJPSOxgsk2);
						num3 = -1481064399;
						continue;
					case 5:
						goto IL_0167;
					case 3:
						num4 = (yVyGawaeUarGhxDRtRZLlSdHRrwQ.MrgFvxEmVvleAtwmEJiJFGTJUZgS = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_1));
						num3 = -1481064393;
						continue;
					case 2:
						goto IL_018d;
					case 4:
						goto IL_019c;
					case 1:
						return;
					}
					break;
				}
				goto IL_011a;
				IL_0053:
				IEnumerator<HuUXmoVjKtZgiBunoGiLZoHKaFw.YVyGawaeUarGhxDRtRZLlSdHRrwQ> enumerator = ZDGzEdGlsfPIXxxIiRhCInujjGU.ujuphkmYzsIfimEfOMVCHtLnQKt(lhBiYQLnfhmmZqOADaUJPSOxgsk2, P_2).GetEnumerator();
				try
				{
					while (true)
					{
						IL_00b4:
						int num5;
						int num6;
						if (enumerator.MoveNext())
						{
							num5 = -1481064396;
							num6 = num5;
						}
						else
						{
							num5 = -1481064395;
							num6 = num5;
						}
						while (true)
						{
							switch (num5 ^ -1481064395)
							{
							case 3:
								num5 = -1481064396;
								continue;
							default:
								goto end_IL_006e;
							case 1:
							{
								HuUXmoVjKtZgiBunoGiLZoHKaFw.YVyGawaeUarGhxDRtRZLlSdHRrwQ current = enumerator.Current;
								if (!tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, current.UKCDHORBCFHBoYLTIFGoDfJwMEGs) && current.MrgFvxEmVvleAtwmEJiJFGTJUZgS >= 0)
								{
									yVyGawaeUarGhxDRtRZLlSdHRrwQ = current;
									num5 = -1481064395;
									continue;
								}
								break;
							}
							case 2:
								break;
							case 0:
								goto end_IL_006e;
							}
							goto IL_00b4;
							continue;
							end_IL_006e:
							break;
						}
						break;
					}
				}
				finally
				{
					if (enumerator != null)
					{
						while (true)
						{
							IL_00d4:
							int num7 = -1481064396;
							while (true)
							{
								switch (num7 ^ -1481064395)
								{
								case 2:
									break;
								default:
									goto end_IL_00d9;
								case 1:
									goto IL_00f2;
								case 0:
									goto end_IL_00d9;
								}
								goto IL_00d4;
								IL_00f2:
								enumerator.Dispose();
								num7 = -1481064395;
								continue;
								end_IL_00d9:
								break;
							}
							break;
						}
					}
				}
				if (yVyGawaeUarGhxDRtRZLlSdHRrwQ != null)
				{
					num4 = yVyGawaeUarGhxDRtRZLlSdHRrwQ.MrgFvxEmVvleAtwmEJiJFGTJUZgS;
					if (!pgNWowjBpVDUsfPflzUQpiDLSMiQ(P_1, num4))
					{
						goto IL_011a;
					}
					goto IL_018d;
				}
				goto IL_019c;
				IL_018d:
				lhBiYQLnfhmmZqOADaUJPSOxgsk2.inputManagerId = num4;
				num3 = -1481064397;
				goto IL_011f;
				IL_011a:
				num3 = -1481064394;
				goto IL_011f;
			}
		}

		private void MFhjbGVDbNrOVBNutDpnZUWGDEP()
		{
			CustomInputSource.Joystick[] array = HRMjdsKAakYtLJeqeiyLJFLWXih.iJGVmIFyHnFtOlccHagmOiUvOnb();
			if (hLZerFQUBneQMKuTxVTgEcfJWjN(array))
			{
				while (true)
				{
					int num = -1850073896;
					while (true)
					{
						switch (num ^ -1850073895)
						{
						case 2:
							break;
						case 1:
							YAYLplglEiMaFnRMMiGNmldzCmUa(array);
							num = -1850073895;
							continue;
						default:
							goto end_IL_0015;
						}
						break;
					}
					continue;
					end_IL_0015:
					break;
				}
			}
			VjAUYAWOZYRvlAZvsjAqxlszqGZ = false;
		}

		private bool hLZerFQUBneQMKuTxVTgEcfJWjN(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = KjXmBSVldpfwjiNaozEQFsyjEtD.Count;
			if (num != count)
			{
				goto IL_0017;
			}
			int num2 = 0;
			int num3 = 1748596796;
			goto IL_001c;
			IL_001c:
			int num7 = default(int);
			bool flag2 = default(bool);
			int num5 = default(int);
			long? systemId2 = default(long?);
			bool flag = default(bool);
			int num4 = default(int);
			long? systemId = default(long?);
			while (true)
			{
				switch (num3 ^ 0x68397830)
				{
				case 21:
					break;
				case 7:
				{
					int num8;
					if (num7 < count)
					{
						num3 = 1748596772;
						num8 = num3;
					}
					else
					{
						num3 = 1748596784;
						num8 = num3;
					}
					continue;
				}
				case 20:
				{
					int num10;
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num7] == null)
					{
						num3 = 1748596794;
						num10 = num3;
					}
					else
					{
						num3 = 1748596787;
						num10 = num3;
					}
					continue;
				}
				case 17:
					if (!flag2)
					{
						return true;
					}
					goto IL_00c3;
				case 9:
					if (P_0[num5] != null && systemId2 == P_0[num5].systemId)
					{
						flag2 = true;
						num3 = 1748596769;
						continue;
					}
					goto case 8;
				case 14:
					num5 = 0;
					num3 = 1748596789;
					continue;
				case 18:
				{
					int num6;
					if (num5 >= num)
					{
						num3 = 1748596769;
						num6 = num3;
					}
					else
					{
						num3 = 1748596793;
						num6 = num3;
					}
					continue;
				}
				case 8:
					num5++;
					num3 = 1748596770;
					continue;
				case 2:
				{
					int num9;
					if (num2 >= num)
					{
						num3 = 1748596771;
						num9 = num3;
					}
					else
					{
						num3 = 1748596788;
						num9 = num3;
					}
					continue;
				}
				case 0:
					if (!flag)
					{
						num3 = 1748596785;
						continue;
					}
					goto IL_01c5;
				case 10:
					num7++;
					num3 = 1748596791;
					continue;
				case 11:
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num4] != null)
					{
						systemId2 = KjXmBSVldpfwjiNaozEQFsyjEtD[num4].systemId;
						flag2 = false;
						num3 = 1748596798;
						continue;
					}
					goto IL_00c3;
				case 5:
					num3 = 1748596770;
					continue;
				case 1:
					return true;
				case 19:
					num4 = 0;
					num3 = 1748596768;
					continue;
				case 15:
					systemId = P_0[num2].systemId;
					flag = false;
					num7 = 0;
					num3 = 1748596791;
					continue;
				case 4:
					if (P_0[num2] != null)
					{
						num3 = 1748596799;
						continue;
					}
					goto IL_01c5;
				case 12:
					num3 = 1748596786;
					continue;
				case 3:
					if (systemId == KjXmBSVldpfwjiNaozEQFsyjEtD[num7].systemId)
					{
						flag = true;
						num3 = 1748596784;
						continue;
					}
					goto case 10;
				case 16:
					num3 = 1748596797;
					continue;
				case 6:
					return true;
				default:
					{
						if (num4 >= count)
						{
							return false;
						}
						goto case 11;
					}
					IL_01c5:
					num2++;
					num3 = 1748596786;
					continue;
					IL_00c3:
					num4++;
					num3 = 1748596797;
					continue;
				}
				break;
			}
			goto IL_0017;
			IL_0017:
			num3 = 1748596790;
			goto IL_001c;
		}

		private void DvAgAsBJXkezynrKQNPnZfxrsAT(List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_0, List<lhBiYQLnfhmmZqOADaUJPSOxgsk> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk3 = default(lhBiYQLnfhmmZqOADaUJPSOxgsk);
			int num3 = default(int);
			bool flag = default(bool);
			int num6 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num = P_0?.Count ?? 0;
				int num2 = -1773863900;
				while (true)
				{
					switch (num2 ^ -1773863902)
					{
					case 3:
						num2 = -1773863893;
						continue;
					case 9:
						break;
					case 0:
						lhBiYQLnfhmmZqOADaUJPSOxgsk3 = P_0[num3];
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk3 != null)
						{
							flag = false;
							num2 = -1773863894;
							continue;
						}
						goto case 13;
					case 6:
						num6 = P_1?.Count ?? 0;
						num2 = -1773863896;
						continue;
					case 11:
						num4++;
						num2 = -1773863898;
						continue;
					case 4:
					{
						int num7;
						if (num4 < num6)
						{
							num2 = -1773863904;
							num7 = num2;
						}
						else
						{
							num2 = -1773863897;
							num7 = num2;
						}
						continue;
					}
					case 12:
						num2 = -1773863901;
						continue;
					case 7:
						vymVnMTbjwdXhKDbpoWajlhAhRD(P_0[num3], P_2);
						num2 = -1773863889;
						continue;
					case 5:
					{
						int num5;
						if (flag)
						{
							num2 = -1773863889;
							num5 = num2;
						}
						else
						{
							num2 = -1773863899;
							num5 = num2;
						}
						continue;
					}
					case 2:
					{
						lhBiYQLnfhmmZqOADaUJPSOxgsk lhBiYQLnfhmmZqOADaUJPSOxgsk2 = P_1[num4];
						if (lhBiYQLnfhmmZqOADaUJPSOxgsk2 != null && lhBiYQLnfhmmZqOADaUJPSOxgsk3.rewiredId == lhBiYQLnfhmmZqOADaUJPSOxgsk2.rewiredId)
						{
							flag = true;
							num2 = -1773863897;
							continue;
						}
						goto case 11;
					}
					case 13:
						num3++;
						num2 = -1773863901;
						continue;
					case 10:
						num3 = 0;
						num2 = -1773863890;
						continue;
					case 8:
						if (P_1 != null)
						{
							num4 = 0;
							num2 = -1773863898;
							continue;
						}
						goto case 5;
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

		private void vymVnMTbjwdXhKDbpoWajlhAhRD(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.TuOpcsNENVAllcZBZvugOvvnqjYG();
				goto IL_0009;
			}
			goto IL_0027;
			IL_0027:
			OuPugjrXRpvKiMmTmCKDHwMoOgap(P_0, P_1);
			int num = 318402201;
			goto IL_000e;
			IL_0009:
			num = 318402202;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x12FA6E98)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0027;
			case 1:
				return;
			}
			goto IL_0009;
		}

		private void OuPugjrXRpvKiMmTmCKDHwMoOgap(lhBiYQLnfhmmZqOADaUJPSOxgsk P_0, bool P_1)
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
				num = 720852424;
				num2 = num;
			}
			else
			{
				num = 720852427;
				num2 = num;
			}
			goto IL_0010;
			IL_000b:
			num = 720852426;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ 0x2AF755C8)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					_DeviceConnectedEvent(P_0.ToBridgedController());
					return;
				case 3:
					_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
					num = 720852424;
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
	}
}
