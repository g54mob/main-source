using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class hwJtYWPMGvWQzlewoWRSkOkcSeW : IInputManagerJoystickPublic, IInputManagerJoystick
		{
			private readonly InputSource CpNbHtCijSICCnUFhUdnSnuZaCd;

			private readonly CustomInputSource LIUEXihIfwBszLMEBQZCkixZlBNJ;

			private readonly Controller.Extension RlhCPmWdFbcKPPhKmYBnLApskyE;

			private int TcKoYfigmhWFfimOKaOKeTOPnAQ;

			private int QovxBPKLdqHelKEcdGLoDhrEJtsP;

			private long? JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;

			private int YAsnSUHUHZSXPqVPdYXTHFQokii;

			public Guid ReLSneGtMGimyQaICDlebjstllEH;

			public string HWvaGjNRcIhWnCcVIEFLqoJYRNaT;

			public string pccpuiYVhbzFZAkrQDaoogDJfQI;

			private int TwhUkSEboxGPsJgqbpmupSCMcvva;

			private int SgYwVaEgtCZiUkgVDcTwJWbyDTtb;

			private float[] TEOYPaJNdnEWbgWRoihqYehIhMK;

			private bool[] pcgUSJiXRsTNqMrGSyukNhNuJeO;

			private HardwareJoystickMap_InputManager RCNejcvnZtMAmgendVbiwgNYmdD;

			public CustomInputSource.Joystick qLQcDJQUVrdpzmenxwkmEnDiEkr;

			private bool BvBiBtBhorGlOOqcvDhVgnidONSn;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> brkuSOIQTXGziCshBbHdBPqhLfY;

			public int hardwareButtonCount
			{
				get
				{
					if (qLQcDJQUVrdpzmenxwkmEnDiEkr == null)
					{
						return 0;
					}
					return qLQcDJQUVrdpzmenxwkmEnDiEkr.buttonCount;
				}
			}

			public int hardwareAxisCount
			{
				get
				{
					if (qLQcDJQUVrdpzmenxwkmEnDiEkr == null)
					{
						return 0;
					}
					return qLQcDJQUVrdpzmenxwkmEnDiEkr.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return TcKoYfigmhWFfimOKaOKeTOPnAQ;
				}
				set
				{
					TcKoYfigmhWFfimOKaOKeTOPnAQ = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return QovxBPKLdqHelKEcdGLoDhrEJtsP;
				}
				set
				{
					QovxBPKLdqHelKEcdGLoDhrEJtsP = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(qLQcDJQUVrdpzmenxwkmEnDiEkr.customName)) ? qLQcDJQUVrdpzmenxwkmEnDiEkr.customName : HWvaGjNRcIhWnCcVIEFLqoJYRNaT);
					if (text == "Unknown Controller")
					{
						text = pccpuiYVhbzFZAkrQDaoogDJfQI;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId
			{
				get
				{
					return JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;
				}
			}

			[CustomObfuscation(rename = false)]
			public int unityId
			{
				get
				{
					return YAsnSUHUHZSXPqVPdYXTHFQokii;
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!JJkBjQCiHgwWIGHDBEAYPgCRjNJZ.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + JJkBjQCiHgwWIGHDBEAYPgCRjNJZ);
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
					return RlhCPmWdFbcKPPhKmYBnLApskyE;
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

			public hwJtYWPMGvWQzlewoWRSkOkcSeW(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, Controller.Extension controllerExtension, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
			{
				while (true)
				{
					int num = -270492544;
					while (true)
					{
						switch (num ^ -270492543)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							TcKoYfigmhWFfimOKaOKeTOPnAQ = -1;
							HrCUbqPxwDZdLCwtaDJbCdJebrq();
							TiLfIVyvvCkOyWkDMxfDMSbgDnI();
							ReLSneGtMGimyQaICDlebjstllEH = RCNejcvnZtMAmgendVbiwgNYmdD.hardwareMapIdentifier.guid;
							HWvaGjNRcIhWnCcVIEFLqoJYRNaT = RCNejcvnZtMAmgendVbiwgNYmdD.controllerName;
							TEOYPaJNdnEWbgWRoihqYehIhMK = new float[TwhUkSEboxGPsJgqbpmupSCMcvva];
							pcgUSJiXRsTNqMrGSyukNhNuJeO = new bool[SgYwVaEgtCZiUkgVDcTwJWbyDTtb];
							Update();
							num = -270492542;
							continue;
						case 4:
							QovxBPKLdqHelKEcdGLoDhrEJtsP = -1;
							num = -270492541;
							continue;
						case 1:
							LIUEXihIfwBszLMEBQZCkixZlBNJ = customInputSource;
							CpNbHtCijSICCnUFhUdnSnuZaCd = inputSource;
							JJkBjQCiHgwWIGHDBEAYPgCRjNJZ = systemJoystickId;
							qLQcDJQUVrdpzmenxwkmEnDiEkr = joystick;
							YAsnSUHUHZSXPqVPdYXTHFQokii = unityJoystickId;
							RlhCPmWdFbcKPPhKmYBnLApskyE = controllerExtension;
							brkuSOIQTXGziCshBbHdBPqhLfY = getHardwareJoystickMap_InputManager;
							num = -270492539;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public void HrCUbqPxwDZdLCwtaDJbCdJebrq()
			{
				pccpuiYVhbzFZAkrQDaoogDJfQI = qLQcDJQUVrdpzmenxwkmEnDiEkr.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (!qLQcDJQUVrdpzmenxwkmEnDiEkr.isConnected)
				{
					while (true)
					{
						switch (0x36D11B50 ^ 0x36D11B51)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				ACWFShdsqMXYShMhIOVlhqSySfj();
				bWqXMuWKIQJCfsxGeWCQkichWXy();
			}

			public int CGvNMgTtJKByfBoLCudPLkyvgkV(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0)
			{
				if (P_0.pccpuiYVhbzFZAkrQDaoogDJfQI == pccpuiYVhbzFZAkrQDaoogDJfQI)
				{
					long? jJkBjQCiHgwWIGHDBEAYPgCRjNJZ = P_0.JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;
					long? jJkBjQCiHgwWIGHDBEAYPgCRjNJZ2 = JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;
					while (true)
					{
						int num = -1111099168;
						while (true)
						{
							switch (num ^ -1111099167)
							{
							case 0:
								break;
							case 1:
								goto IL_003f;
							default:
								goto IL_0056;
							}
							break;
							IL_0056:
							if (jJkBjQCiHgwWIGHDBEAYPgCRjNJZ.HasValue != jJkBjQCiHgwWIGHDBEAYPgCRjNJZ2.HasValue)
							{
								goto end_IL_0021;
							}
							return 2;
							IL_003f:
							if (jJkBjQCiHgwWIGHDBEAYPgCRjNJZ.GetValueOrDefault() != jJkBjQCiHgwWIGHDBEAYPgCRjNJZ2.GetValueOrDefault())
							{
								goto end_IL_0021;
							}
							num = -1111099165;
						}
						continue;
						end_IL_0021:
						break;
					}
				}
				if (P_0.pccpuiYVhbzFZAkrQDaoogDJfQI == pccpuiYVhbzFZAkrQDaoogDJfQI)
				{
					return 1;
				}
				return 0;
			}

			private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = CpNbHtCijSICCnUFhUdnSnuZaCd;
				P_0.inputSource = CpNbHtCijSICCnUFhUdnSnuZaCd;
				P_0.hardwareIdentifier = ZrEWBQNwcFIqvIYkQITbufsXcXR();
				P_0.hardwareAxisCount = TwhUkSEboxGPsJgqbpmupSCMcvva;
				P_0.hardwareButtonCount = SgYwVaEgtCZiUkgVDcTwJWbyDTtb;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = pccpuiYVhbzFZAkrQDaoogDJfQI;
				P_0.hw_supportsVibration = qLQcDJQUVrdpzmenxwkmEnDiEkr.supportsVibration;
			}

			private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedController P_0)
			{
				azaIOTDxGZMNUjlkOgiJDaxzXhfj((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				while (true)
				{
					int num = -467271393;
					while (true)
					{
						switch (num ^ -467271396)
						{
						case 4:
							break;
						case 3:
							P_0.gameHardwareMap = RCNejcvnZtMAmgendVbiwgNYmdD.ToGameHardwareControllerMap();
							P_0.instanceName = pccpuiYVhbzFZAkrQDaoogDJfQI;
							P_0.productName = pccpuiYVhbzFZAkrQDaoogDJfQI;
							P_0.isXInputDevice = false;
							P_0.axisCount = TwhUkSEboxGPsJgqbpmupSCMcvva;
							num = -467271395;
							continue;
						case 2:
							P_0.customInputSource = LIUEXihIfwBszLMEBQZCkixZlBNJ;
							num = -467271396;
							continue;
						case 1:
							P_0.buttonCount = SgYwVaEgtCZiUkgVDcTwJWbyDTtb;
							P_0.controllerTypeGuid = ReLSneGtMGimyQaICDlebjstllEH;
							num = -467271394;
							continue;
						default:
							P_0.controllerExtension = RlhCPmWdFbcKPPhKmYBnLApskyE;
							return;
						}
						break;
					}
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (TwhUkSEboxGPsJgqbpmupSCMcvva != dataUpdater.axisCount)
				{
					goto IL_009a;
				}
				if (SgYwVaEgtCZiUkgVDcTwJWbyDTtb != dataUpdater.buttonCount)
				{
					goto IL_0022;
				}
				goto IL_00af;
				IL_009a:
				throw new Exception("This controller signature does not match the data object!");
				IL_0022:
				int num = 2069068888;
				goto IL_0027;
				IL_0027:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x7B537C5D)
					{
					case 4:
						break;
					default:
						return;
					case 9:
						dataUpdater.axisValues[num2] = TEOYPaJNdnEWbgWRoihqYehIhMK[num2];
						num = 2069068895;
						continue;
					case 1:
						if (BvBiBtBhorGlOOqcvDhVgnidONSn && !dataUpdater.hasReceivedInput)
						{
							dataUpdater.hasReceivedInput = true;
							num = 2069068894;
							continue;
						}
						return;
					case 5:
						goto IL_009a;
					case 0:
						goto IL_00af;
					case 6:
						if (num2 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
						{
							num3 = 0;
							num = 2069068885;
							continue;
						}
						goto case 9;
					case 8:
						goto IL_00d0;
					case 7:
						dataUpdater.buttonValues[num3] = pcgUSJiXRsTNqMrGSyukNhNuJeO[num3];
						num3++;
						num = 2069068885;
						continue;
					case 2:
						num2++;
						num = 2069068891;
						continue;
					case 3:
						return;
					}
					break;
					IL_00d0:
					int num4;
					if (num3 >= SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
					{
						num = 2069068892;
						num4 = num;
					}
					else
					{
						num = 2069068890;
						num4 = num;
					}
				}
				goto IL_0022;
				IL_00af:
				num2 = 0;
				num = 2069068891;
				goto IL_0027;
			}

			public BridgedControllerHWInfo JBMvgOBJziXYPUQkaqihlBPPMXw()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				while (true)
				{
					int num = -1516788535;
					while (true)
					{
						switch (num ^ -1516788536)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							return bridgedControllerHWInfo;
						}
						break;
						IL_0024:
						azaIOTDxGZMNUjlkOgiJDaxzXhfj(bridgedControllerHWInfo);
						num = -1516788534;
					}
				}
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				azaIOTDxGZMNUjlkOgiJDaxzXhfj(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(TcKoYfigmhWFfimOKaOKeTOPnAQ);
			}

			private void ACWFShdsqMXYShMhIOVlhqSySfj()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)RCNejcvnZtMAmgendVbiwgNYmdD.map).Axes;
				if (axes == null)
				{
					goto IL_001c;
				}
				goto IL_00c0;
				IL_001c:
				int num = 437512319;
				goto IL_0021;
				IL_0021:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x1A13E87B)
					{
					case 5:
						break;
					case 4:
						return;
					case 6:
						TEOYPaJNdnEWbgWRoihqYehIhMK[num2] = MZBONfLuZbixRkBmJqUhwMoksCq(axes[num2]);
						if (!BvBiBtBhorGlOOqcvDhVgnidONSn && TEOYPaJNdnEWbgWRoihqYehIhMK[num2] != 0f)
						{
							BvBiBtBhorGlOOqcvDhVgnidONSn = true;
							num = 437512316;
							continue;
						}
						goto case 7;
					case 3:
						if (axes[num2] != null)
						{
							if (num2 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
							{
								throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
							}
							goto case 6;
						}
						goto case 7;
					case 7:
						num2++;
						num = 437512313;
						continue;
					case 0:
						goto IL_00c0;
					case 1:
						num = 437512313;
						continue;
					default:
						if (num2 >= axes.Length)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
				goto IL_001c;
				IL_00c0:
				num2 = 0;
				num = 437512314;
				goto IL_0021;
			}

			private void bWqXMuWKIQJCfsxGeWCQkichWXy()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)RCNejcvnZtMAmgendVbiwgNYmdD.map).Buttons;
				int num2 = default(int);
				while (true)
				{
					int num = 1443001729;
					while (true)
					{
						switch (num ^ 0x56027586)
						{
						case 6:
							break;
						case 1:
							num2++;
							num = 1443001732;
							continue;
						case 8:
							num2 = 0;
							num = 1443001732;
							continue;
						case 5:
							if (num2 >= SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
							{
								throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
							}
							goto case 0;
						case 3:
							BvBiBtBhorGlOOqcvDhVgnidONSn = true;
							num = 1443001735;
							continue;
						case 7:
							if (buttons == null)
							{
								return;
							}
							goto case 8;
						case 4:
						{
							int num3;
							if (!pcgUSJiXRsTNqMrGSyukNhNuJeO[num2])
							{
								num = 1443001735;
								num3 = num;
							}
							else
							{
								num = 1443001733;
								num3 = num;
							}
							continue;
						}
						case 0:
						{
							pcgUSJiXRsTNqMrGSyukNhNuJeO[num2] = uzIVkYjEcCOqJgyQjMKkDXWAHmv(buttons[num2]);
							int num4;
							if (BvBiBtBhorGlOOqcvDhVgnidONSn)
							{
								num = 1443001735;
								num4 = num;
							}
							else
							{
								num = 1443001730;
								num4 = num;
							}
							continue;
						}
						default:
							if (num2 >= buttons.Length)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
				}
			}

			private bool uzIVkYjEcCOqJgyQjMKkDXWAHmv(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = MZBONfLuZbixRkBmJqUhwMoksCq(P_0.sourceAxis);
					while (true)
					{
						int num2 = -827363440;
						while (true)
						{
							switch (num2 ^ -827363438)
							{
							case 0:
								break;
							case 2:
								if (MathTools.Abs(num) <= P_0.axisDeadZone)
								{
									goto IL_0057;
								}
								if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
								{
									return false;
								}
								if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
								{
									return false;
								}
								return true;
							default:
								return false;
							}
							break;
							IL_0057:
							num2 = -827363437;
						}
					}
				}
				return false;
			}

			private bool PnGKCgddUhiShSiKoDLSOjCdKDO(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float MZBONfLuZbixRkBmJqUhwMoksCq(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					goto IL_0009;
				}
				float result = default(float);
				int num;
				if (P_0.sourceType == 0)
				{
					if (!uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.sourceButton))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result = 1f;
						num = -560010159;
						goto IL_000e;
					}
					goto IL_006d;
				}
				throw new NotImplementedException();
				IL_000e:
				switch (num ^ -560010158)
				{
				case 0:
					break;
				case 1:
					return MZBONfLuZbixRkBmJqUhwMoksCq(P_0.sourceAxis);
				case 2:
					goto IL_006d;
				default:
					return result;
				}
				goto IL_0009;
				IL_0009:
				num = -560010157;
				goto IL_000e;
				IL_006d:
				result = -1f;
				num = -560010159;
				goto IL_000e;
			}

			private float MZBONfLuZbixRkBmJqUhwMoksCq(int P_0)
			{
				return qLQcDJQUVrdpzmenxwkmEnDiEkr.GetAxisValue(P_0);
			}

			private bool uzIVkYjEcCOqJgyQjMKkDXWAHmv(int P_0)
			{
				return qLQcDJQUVrdpzmenxwkmEnDiEkr.GetButtonValue(P_0);
			}

			private void TiLfIVyvvCkOyWkDMxfDMSbgDnI()
			{
				RCNejcvnZtMAmgendVbiwgNYmdD = brkuSOIQTXGziCshBbHdBPqhLfY(JBMvgOBJziXYPUQkaqihlBPPMXw());
				if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				TwhUkSEboxGPsJgqbpmupSCMcvva = RCNejcvnZtMAmgendVbiwgNYmdD.axisCount;
				SgYwVaEgtCZiUkgVDcTwJWbyDTtb = RCNejcvnZtMAmgendVbiwgNYmdD.buttonCount;
			}

			private void tqYfRtthDdSgVRZMoVLzrZSSLul()
			{
				Array.Clear(pcgUSJiXRsTNqMrGSyukNhNuJeO, 0, pcgUSJiXRsTNqMrGSyukNhNuJeO.Length);
				Array.Clear(TEOYPaJNdnEWbgWRoihqYehIhMK, 0, TEOYPaJNdnEWbgWRoihqYehIhMK.Length);
			}

			private string ZrEWBQNwcFIqvIYkQITbufsXcXR()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), ReInput.webplayerPlatform.ToString(), CpNbHtCijSICCnUFhUdnSnuZaCd.ToString(), pccpuiYVhbzFZAkrQDaoogDJfQI));
				}
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), CpNbHtCijSICCnUFhUdnSnuZaCd.ToString(), pccpuiYVhbzFZAkrQDaoogDJfQI));
			}

			public static int cDhwtjWQhSyIsxMLQDmPyGiSilw(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, hwJtYWPMGvWQzlewoWRSkOkcSeW P_1)
			{
				if (P_0.QovxBPKLdqHelKEcdGLoDhrEJtsP < P_1.QovxBPKLdqHelKEcdGLoDhrEJtsP)
				{
					return -1;
				}
				if (P_0.QovxBPKLdqHelKEcdGLoDhrEJtsP > P_1.QovxBPKLdqHelKEcdGLoDhrEJtsP)
				{
					return 1;
				}
				return 0;
			}

			public static int HfjbDlQkUgfXzKVWUYDQEmjeIIYF(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, hwJtYWPMGvWQzlewoWRSkOkcSeW P_1)
			{
				if (P_0.JJkBjQCiHgwWIGHDBEAYPgCRjNJZ < P_1.JJkBjQCiHgwWIGHDBEAYPgCRjNJZ)
				{
					return -1;
				}
				if (P_0.JJkBjQCiHgwWIGHDBEAYPgCRjNJZ > P_1.JJkBjQCiHgwWIGHDBEAYPgCRjNJZ)
				{
					return 1;
				}
				return 0;
			}
		}

		private class NIOXrqHRlxHlUMLPLEvYiqbHqqY
		{
			public enum igFlsUZdiaAWHzaPiGtekcNHjYY
			{
				fyLkgCmTpqIuMAMCxJOMkArnGwx = 0,
				DVvUbKVHsTUhKpitpaArZixJgbT = 1
			}

			public class iGzxVnYmiJOurfvDweKkwKhmTCJ
			{
				public int YZYerWLyrZezITIzzsjvGpplKQw;

				public long? epEMcgGdkeNUGkKEiGsNlqGuKTx;

				public string KrSAaeDrfQehorfbrYOtierIUgu;

				public int GWoLlqegGvGyTtMNhZYqvtRENGv;

				public int SgYwVaEgtCZiUkgVDcTwJWbyDTtb;

				public int TwhUkSEboxGPsJgqbpmupSCMcvva;

				public iGzxVnYmiJOurfvDweKkwKhmTCJ(int rewiredId, long? systemId, string systemControllerName, int lastInputManagerId, int buttonCount, int axisCount)
				{
					while (true)
					{
						int num = 1027086190;
						while (true)
						{
							switch (num ^ 0x3D38176C)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								epEMcgGdkeNUGkKEiGsNlqGuKTx = systemId;
								KrSAaeDrfQehorfbrYOtierIUgu = systemControllerName;
								GWoLlqegGvGyTtMNhZYqvtRENGv = lastInputManagerId;
								SgYwVaEgtCZiUkgVDcTwJWbyDTtb = buttonCount;
								TwhUkSEboxGPsJgqbpmupSCMcvva = axisCount;
								return;
							}
							break;
							IL_0024:
							YZYerWLyrZezITIzzsjvGpplKQw = rewiredId;
							num = 1027086189;
						}
					}
				}

				public bool CGvNMgTtJKByfBoLCudPLkyvgkV(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, igFlsUZdiaAWHzaPiGtekcNHjYY P_1)
				{
					if (P_0.rewiredId == YZYerWLyrZezITIzzsjvGpplKQw)
					{
						return true;
					}
					if (P_0.hardwareButtonCount != SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
					{
						return false;
					}
					if (P_0.hardwareAxisCount != TwhUkSEboxGPsJgqbpmupSCMcvva)
					{
						return false;
					}
					switch (P_1)
					{
					case igFlsUZdiaAWHzaPiGtekcNHjYY.fyLkgCmTpqIuMAMCxJOMkArnGwx:
						if (epEMcgGdkeNUGkKEiGsNlqGuKTx == P_0.systemId)
						{
							return KrSAaeDrfQehorfbrYOtierIUgu == P_0.pccpuiYVhbzFZAkrQDaoogDJfQI;
						}
						return false;
					case igFlsUZdiaAWHzaPiGtekcNHjYY.DVvUbKVHsTUhKpitpaArZixJgbT:
						return KrSAaeDrfQehorfbrYOtierIUgu == P_0.pccpuiYVhbzFZAkrQDaoogDJfQI;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private List<iGzxVnYmiJOurfvDweKkwKhmTCJ> rokTPxsNitEbJnvAHMxvBQpZKze;

			public int Count
			{
				get
				{
					return rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				}
			}

			public NIOXrqHRlxHlUMLPLEvYiqbHqqY()
			{
				rokTPxsNitEbJnvAHMxvBQpZKze = new List<iGzxVnYmiJOurfvDweKkwKhmTCJ>();
			}

			public void hGoGXvVewDdznIUDiLVJVGFrUsD(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0)
			{
				if (P_0 == null)
				{
					goto IL_0006;
				}
				goto IL_0140;
				IL_0006:
				int num = -1041408226;
				goto IL_000b;
				IL_000b:
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					switch (num ^ -1041408232)
					{
					case 4:
						break;
					default:
						return;
					case 0:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num2].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, igFlsUZdiaAWHzaPiGtekcNHjYY.fyLkgCmTpqIuMAMCxJOMkArnGwx))
						{
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].YZYerWLyrZezITIzzsjvGpplKQw = P_0.rewiredId;
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].epEMcgGdkeNUGkKEiGsNlqGuKTx = P_0.systemId;
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].KrSAaeDrfQehorfbrYOtierIUgu = P_0.pccpuiYVhbzFZAkrQDaoogDJfQI;
							num = -1041408239;
							continue;
						}
						goto case 8;
					case 7:
						if (num2 >= count)
						{
							rokTPxsNitEbJnvAHMxvBQpZKze.Add(new iGzxVnYmiJOurfvDweKkwKhmTCJ(P_0.rewiredId, P_0.systemId, P_0.pccpuiYVhbzFZAkrQDaoogDJfQI, P_0.inputManagerId, P_0.hardwareButtonCount, P_0.hardwareAxisCount));
							num = -1041408230;
							continue;
						}
						goto case 0;
					case 8:
						num2++;
						num = -1041408225;
						continue;
					case 3:
						rokTPxsNitEbJnvAHMxvBQpZKze[num2].SgYwVaEgtCZiUkgVDcTwJWbyDTtb = P_0.hardwareButtonCount;
						rokTPxsNitEbJnvAHMxvBQpZKze[num2].TwhUkSEboxGPsJgqbpmupSCMcvva = P_0.hardwareAxisCount;
						BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, num2);
						return;
					case 1:
						goto IL_0140;
					case 6:
						return;
					case 2:
						BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1);
						num = -1041408227;
						continue;
					case 9:
						rokTPxsNitEbJnvAHMxvBQpZKze[num2].GWoLlqegGvGyTtMNhZYqvtRENGv = P_0.inputManagerId;
						num = -1041408229;
						continue;
					case 5:
						return;
					}
					break;
				}
				goto IL_0006;
				IL_0140:
				count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				num2 = 0;
				num = -1041408225;
				goto IL_000b;
			}

			public bool WfhdeimYiTFGUIbHSjqOJaakYWS(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, igFlsUZdiaAWHzaPiGtekcNHjYY P_1)
			{
				int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				int num = 0;
				while (num < count)
				{
					while (true)
					{
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
						{
							return true;
						}
						num++;
						int num2 = 813295404;
						while (true)
						{
							switch (num2 ^ 0x3079E72C)
							{
							case 2:
								num2 = 813295405;
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
				return false;
			}

			public iGzxVnYmiJOurfvDweKkwKhmTCJ OlRyGPawIBmfpGbjKDHJQXdzfaeG(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, igFlsUZdiaAWHzaPiGtekcNHjYY P_1)
			{
				int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				int num2 = default(int);
				while (true)
				{
					int num = -1536651987;
					while (true)
					{
						switch (num ^ -1536651988)
						{
						case 0:
							break;
						case 1:
							num2 = 0;
							num = -1536651986;
							continue;
						case 3:
							if (rokTPxsNitEbJnvAHMxvBQpZKze[num2].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
							{
								return rokTPxsNitEbJnvAHMxvBQpZKze[num2];
							}
							num2++;
							num = -1536651986;
							continue;
						default:
							if (num2 >= count)
							{
								return null;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			public int EAgOMouOjbslHCCsyBDLoGVrHcd(iGzxVnYmiJOurfvDweKkwKhmTCJ P_0)
			{
				int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				int num = 0;
				while (num < count)
				{
					while (true)
					{
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num] == P_0)
						{
							return num;
						}
						num++;
						int num2 = 1830145428;
						while (true)
						{
							switch (num2 ^ 0x6D15CD96)
							{
							case 0:
								num2 = 1830145431;
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

			private void BfoPnOzEfehguKuapcNsLLRRhsb(int P_0, int P_1)
			{
				int num = rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1;
				while (true)
				{
					int num2 = -1409325156;
					while (true)
					{
						switch (num2 ^ -1409325159)
						{
						case 4:
							break;
						default:
							return;
						case 0:
							if (rokTPxsNitEbJnvAHMxvBQpZKze[num].YZYerWLyrZezITIzzsjvGpplKQw == P_0)
							{
								rokTPxsNitEbJnvAHMxvBQpZKze.RemoveAt(num);
								num2 = -1409325158;
								continue;
							}
							goto case 3;
						case 6:
						{
							int num4;
							if (num != P_1)
							{
								num2 = -1409325159;
								num4 = num2;
							}
							else
							{
								num2 = -1409325158;
								num4 = num2;
							}
							continue;
						}
						case 3:
							num--;
							num2 = -1409325160;
							continue;
						case 1:
						{
							int num3;
							if (num < 0)
							{
								num2 = -1409325157;
								num3 = num2;
							}
							else
							{
								num2 = -1409325153;
								num3 = num2;
							}
							continue;
						}
						case 5:
							num2 = -1409325160;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		private List<hwJtYWPMGvWQzlewoWRSkOkcSeW> AVRtfMRpOzQlHvmKXxpZoBGaQUn;

		private int xrSChNBBhEWHvkeIhZBjNmkdZsmA;

		private NIOXrqHRlxHlUMLPLEvYiqbHqqY VYIiPbQDTfmyzeeKLOEXjAUgGAe;

		private UpdateLoopType xFKjhyBYBeaXHwQfmSuqSKfAFpj;

		private Action<int, ControllerDataUpdater> EpczCkvPPKAdjiQfdfFMvZxBJnNl;

		private PlatformInputManager SUAsPHGFrajzPXFANEuqbUoeMlU;

		private CustomInputSource LIUEXihIfwBszLMEBQZCkixZlBNJ;

		private bool LDAcgYOFyYXGHPLDHfJvYGEiUNl;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> brkuSOIQTXGziCshBbHdBPqhLfY;

		private Func<int> wHXHOjgCCjfwhXpVEAfBjzTabcoI;

		[CustomObfuscation(rename = false)]
		public override int deviceCount
		{
			get
			{
				return xrSChNBBhEWHvkeIhZBjNmkdZsmA;
			}
		}

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager
		{
			get
			{
				return SUAsPHGFrajzPXFANEuqbUoeMlU;
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
				return LIUEXihIfwBszLMEBQZCkixZlBNJ.inputSource;
			}
		}

		public CustomInputManager(CustomInputSource customInputSource, UpdateLoopSetting updateLoopSetting, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			while (true)
			{
				int num = 1850620431;
				while (true)
				{
					switch (num ^ 0x6E4E3A0D)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						wHXHOjgCCjfwhXpVEAfBjzTabcoI = getNewJoystickId;
						SUAsPHGFrajzPXFANEuqbUoeMlU = this;
						try
						{
							EpczCkvPPKAdjiQfdfFMvZxBJnNl = UpdateControllerData;
							customInputSource.JoystickConnectedEvent += SystemDeviceConnected;
							customInputSource.JoystickDisconnectedEvent += SystemDeviceDisconnected;
							return;
						}
						catch (Exception)
						{
							OnDestroy();
							throw;
						}
					}
					break;
					IL_0024:
					LIUEXihIfwBszLMEBQZCkixZlBNJ = customInputSource;
					brkuSOIQTXGziCshBbHdBPqhLfY = getHardwareJoystickMap_InputManager;
					num = 1850620428;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void Initialize()
		{
			VYIiPbQDTfmyzeeKLOEXjAUgGAe = new NIOXrqHRlxHlUMLPLEvYiqbHqqY();
			while (true)
			{
				int num = 947247230;
				while (true)
				{
					switch (num ^ 0x3875D87F)
					{
					case 0:
						break;
					case 1:
						goto IL_0029;
					default:
						LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
						return;
					}
					break;
					IL_0029:
					AVRtfMRpOzQlHvmKXxpZoBGaQUn = new List<hwJtYWPMGvWQzlewoWRSkOkcSeW>();
					num = 947247229;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			xFKjhyBYBeaXHwQfmSuqSKfAFpj = updateLoop;
			if (!LIUEXihIfwBszLMEBQZCkixZlBNJ.isReady)
			{
				return;
			}
			while (true)
			{
				LIUEXihIfwBszLMEBQZCkixZlBNJ.Update();
				int num = -1736416931;
				while (true)
				{
					switch (num ^ -1736416929)
					{
					case 4:
						num = -1736416932;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
						if (LDAcgYOFyYXGHPLDHfJvYGEiUNl)
						{
							YUdSTENKKNoVxApSKeakGqiLoBfc();
							num = -1736416930;
							continue;
						}
						goto case 1;
					case 1:
						njzLgbngHRtFtusDoWSXPlqSohr();
						num = -1736416929;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (LIUEXihIfwBszLMEBQZCkixZlBNJ != null)
			{
				LIUEXihIfwBszLMEBQZCkixZlBNJ.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return EpczCkvPPKAdjiQfdfFMvZxBJnNl;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < xrSChNBBhEWHvkeIhZBjNmkdZsmA)
				{
					num2 = 1956547926;
					num3 = num2;
				}
				else
				{
					num2 = 1956547925;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x749E8D57)
					{
					case 0:
						num2 = 1956547926;
						continue;
					case 1:
						if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].inputManagerId == inputManagerId)
						{
							AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].FillData(data);
							return;
						}
						goto case 4;
					case 4:
						num++;
						num2 = 1956547924;
						continue;
					case 3:
						break;
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
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
			while (true)
			{
				int num = -2056501235;
				while (true)
				{
					switch (num ^ -2056501236)
					{
					case 3:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (_SystemDeviceDisconnectedEvent != null)
						{
							num = -2056501234;
							num2 = num;
						}
						else
						{
							num = -2056501236;
							num2 = num;
						}
						continue;
					}
					case 2:
						_SystemDeviceDisconnectedEvent();
						num = -2056501236;
						continue;
					case 0:
						return;
					}
					break;
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

		private void MBWbLtwiramKtsVixhpKLRHaVam(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<hwJtYWPMGvWQzlewoWRSkOkcSeW> aVRtfMRpOzQlHvmKXxpZoBGaQUn = AVRtfMRpOzQlHvmKXxpZoBGaQUn;
			int num2 = xrSChNBBhEWHvkeIhZBjNmkdZsmA;
			AVRtfMRpOzQlHvmKXxpZoBGaQUn = new List<hwJtYWPMGvWQzlewoWRSkOkcSeW>();
			int num3 = 0;
			int num4 = default(int);
			while (true)
			{
				int num5;
				if (num3 >= P_0.Length)
				{
					xrSChNBBhEWHvkeIhZBjNmkdZsmA = num;
					SAHmPdomeKmRmWDMHYyWboYkaxQ(num2, num, aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn);
					num4 = 0;
					num5 = -1108834879;
					goto IL_0024;
				}
				goto IL_00d3;
				IL_0024:
				while (true)
				{
					switch (num5 ^ -1108834873)
					{
					case 3:
						num5 = -1108834878;
						continue;
					case 7:
						break;
					case 9:
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(AVRtfMRpOzQlHvmKXxpZoBGaQUn[num4]));
						num5 = -1108834865;
						continue;
					case 1:
						goto IL_00a9;
					case 2:
						num3++;
						num5 = -1108834880;
						continue;
					case 5:
						goto IL_00d3;
					case 4:
					{
						hwJtYWPMGvWQzlewoWRSkOkcSeW item = new hwJtYWPMGvWQzlewoWRSkOkcSeW(LIUEXihIfwBszLMEBQZCkixZlBNJ, P_0[num3].systemId, P_0[num3].unityId, P_0[num3], LIUEXihIfwBszLMEBQZCkixZlBNJ.inputSource, P_0[num3].extension, brkuSOIQTXGziCshBbHdBPqhLfY);
						AVRtfMRpOzQlHvmKXxpZoBGaQUn.Add(item);
						num++;
						num5 = -1108834875;
						continue;
					}
					case 6:
						goto IL_0140;
					case 8:
						num4++;
						num5 = -1108834879;
						continue;
					default:
						DtOBegFLamhBKwlmzaaiccPahGxz(aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn, false);
						DtOBegFLamhBKwlmzaaiccPahGxz(AVRtfMRpOzQlHvmKXxpZoBGaQUn, aVRtfMRpOzQlHvmKXxpZoBGaQUn, true);
						return;
					}
					break;
					IL_0140:
					int num6;
					if (num4 < num)
					{
						num5 = -1108834874;
						num6 = num5;
					}
					else
					{
						num5 = -1108834873;
						num6 = num5;
					}
					continue;
					IL_00a9:
					int num7;
					if (_UpdateControllerInfoEvent != null)
					{
						num5 = -1108834866;
						num7 = num5;
					}
					else
					{
						num5 = -1108834865;
						num7 = num5;
					}
				}
				continue;
				IL_00d3:
				int num8;
				if (P_0[num3] != null)
				{
					num5 = -1108834877;
					num8 = num5;
				}
				else
				{
					num5 = -1108834875;
					num8 = num5;
				}
				goto IL_0024;
			}
		}

		private void njzLgbngHRtFtusDoWSXPlqSohr()
		{
			int num = 0;
			while (num < xrSChNBBhEWHvkeIhZBjNmkdZsmA)
			{
				while (true)
				{
					AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].Update();
					num++;
					int num2 = -976820360;
					while (true)
					{
						switch (num2 ^ -976820359)
						{
						case 0:
							num2 = -976820357;
							continue;
						case 2:
							break;
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
		}

		private void SAHmPdomeKmRmWDMHYyWboYkaxQ(int P_0, int P_1, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_2, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(hwJtYWPMGvWQzlewoWRSkOkcSeW.HfjbDlQkUgfXzKVWUYDQEmjeIIYF);
				goto IL_001a;
			}
			goto IL_00fb;
			IL_00fb:
			int num;
			if (P_0 > 0 && P_1 > 0)
			{
				CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY.fyLkgCmTpqIuMAMCxJOMkArnGwx);
				if (LIUEXihIfwBszLMEBQZCkixZlBNJ.useApproximateMatching)
				{
					CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY.DVvUbKVHsTUhKpitpaArZixJgbT);
					num = -1379285815;
					goto IL_001f;
				}
			}
			goto IL_00e7;
			IL_001a:
			num = -1379285817;
			goto IL_001f;
			IL_001f:
			int num2 = default(int);
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW2 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			while (true)
			{
				switch (num ^ -1379285811)
				{
				case 3:
					break;
				case 0:
					num = -1379285819;
					continue;
				case 6:
					goto IL_0066;
				case 11:
					goto IL_0083;
				case 1:
					num2++;
					num = -1379285819;
					continue;
				case 5:
					SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY.DVvUbKVHsTUhKpitpaArZixJgbT);
					num = -1379285809;
					continue;
				case 9:
					if (hwJtYWPMGvWQzlewoWRSkOkcSeW2.inputManagerId < 0)
					{
						hwJtYWPMGvWQzlewoWRSkOkcSeW2.inputManagerId = lthALbyMafUeFUSoDiwZaXONIhC(P_3);
						num = -1379285814;
						continue;
					}
					goto case 1;
				case 4:
					goto IL_00e7;
				case 10:
					goto IL_00fb;
				case 7:
					hwJtYWPMGvWQzlewoWRSkOkcSeW2.rewiredId = ReInput.GetNewJoystickId();
					VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(hwJtYWPMGvWQzlewoWRSkOkcSeW2);
					num = -1379285812;
					continue;
				case 2:
					num2 = 0;
					num = -1379285811;
					continue;
				default:
					if (num2 >= P_1)
					{
						P_3.Sort(hwJtYWPMGvWQzlewoWRSkOkcSeW.cDhwtjWQhSyIsxMLQDmPyGiSilw);
						return;
					}
					goto IL_0066;
				}
				break;
				IL_0083:
				int num3;
				if (LIUEXihIfwBszLMEBQZCkixZlBNJ.useApproximateMatching)
				{
					num = -1379285816;
					num3 = num;
				}
				else
				{
					num = -1379285809;
					num3 = num;
				}
				continue;
				IL_0066:
				hwJtYWPMGvWQzlewoWRSkOkcSeW2 = P_3[num2];
				int num4;
				if (hwJtYWPMGvWQzlewoWRSkOkcSeW2 == null)
				{
					num = -1379285812;
					num4 = num;
				}
				else
				{
					num = -1379285820;
					num4 = num;
				}
			}
			goto IL_001a;
			IL_00e7:
			SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY.fyLkgCmTpqIuMAMCxJOMkArnGwx);
			num = -1379285818;
			goto IL_001f;
		}

		private void jMgFvMJOWRWuceXBnZGyQCpTgME(List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (num != P_1 && P_0[num] != null && P_0[num].inputManagerId == P_2)
					{
						P_0[num].inputManagerId = -1;
						num2 = 1066327995;
						goto IL_0010;
					}
					goto IL_005d;
					IL_0010:
					while (true)
					{
						switch (num2 ^ 0x3F8EDFBA)
						{
						case 3:
							num2 = 1066327992;
							continue;
						case 2:
							break;
						case 1:
							goto IL_005d;
						default:
							goto end_IL_002d;
						}
						break;
					}
					continue;
					IL_005d:
					num++;
					num2 = 1066327994;
					goto IL_0010;
					continue;
					end_IL_002d:
					break;
				}
			}
		}

		private bool tdJERshKrZupAABGOtPFZhjIApQ(List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_0, int P_1)
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
					int num2 = -1981427626;
					while (true)
					{
						switch (num2 ^ -1981427625)
						{
						case 0:
							num2 = -1981427627;
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

		private int lthALbyMafUeFUSoDiwZaXONIhC(List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_0)
		{
			int num = 0;
			int num3 = default(int);
			int count = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num2 = -1875702198;
				while (true)
				{
					switch (num2 ^ -1875702196)
					{
					case 3:
						break;
					case 8:
					{
						int num4;
						if (num3 >= count)
						{
							num2 = -1875702195;
							num4 = num2;
						}
						else
						{
							num2 = -1875702199;
							num4 = num2;
						}
						continue;
					}
					case 5:
						if (P_0[num3] != null && P_0[num3].inputManagerId == num)
						{
							flag = true;
							num2 = -1875702196;
							continue;
						}
						goto case 7;
					default:
						flag = false;
						count = P_0.Count;
						num3 = 0;
						num2 = -1875702204;
						continue;
					case 0:
						num2 = -1875702195;
						continue;
					case 7:
						num3++;
						num2 = -1875702204;
						continue;
					case 2:
						return num;
					case 1:
						if (flag)
						{
							num++;
							num2 = -1875702200;
						}
						else
						{
							num2 = -1875702194;
						}
						continue;
					}
					break;
				}
			}
		}

		private bool reYntWceOkPUZwwqHtuPFEoKbLb(List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_0, int P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num = 0;
			int num2 = 871423547;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x33F0DE39)
				{
				case 0:
					break;
				case 3:
					return false;
				case 1:
					if (P_0[num].rewiredId != P_1)
					{
						goto IL_0041;
					}
					return true;
				default:
					if (num >= P_0.Count)
					{
						return false;
					}
					goto case 1;
				}
				break;
				IL_0041:
				num++;
				num2 = 871423547;
			}
			goto IL_0003;
			IL_0003:
			num2 = 871423546;
			goto IL_0008;
		}

		private void CJTiCwRYBKtdCjdVGCYyAKtmlkc(int P_0, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_1, int P_2, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_3, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY P_4)
		{
			int num = ((P_4 != NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY.fyLkgCmTpqIuMAMCxJOMkArnGwx) ? 1 : 2);
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW3 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW2 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			int num3 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = 1131303188;
				while (true)
				{
					switch (num2 ^ 0x436E5111)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						hwJtYWPMGvWQzlewoWRSkOkcSeW3.inputManagerId = hwJtYWPMGvWQzlewoWRSkOkcSeW2.inputManagerId;
						hwJtYWPMGvWQzlewoWRSkOkcSeW3.rewiredId = hwJtYWPMGvWQzlewoWRSkOkcSeW2.rewiredId;
						VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(hwJtYWPMGvWQzlewoWRSkOkcSeW3);
						num2 = 1131303186;
						continue;
					case 7:
					{
						int num7;
						if (num3 < P_0)
						{
							num2 = 1131303189;
							num7 = num2;
						}
						else
						{
							num2 = 1131303193;
							num7 = num2;
						}
						continue;
					}
					case 10:
					{
						int num8;
						if (num5 >= P_2)
						{
							num2 = 1131303187;
							num8 = num2;
						}
						else
						{
							num2 = 1131303191;
							num8 = num2;
						}
						continue;
					}
					case 2:
						num3++;
						num2 = 1131303190;
						continue;
					case 6:
					{
						hwJtYWPMGvWQzlewoWRSkOkcSeW2 = P_3[num5];
						int num6;
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW2 != null)
						{
							num2 = 1131303192;
							num6 = num2;
						}
						else
						{
							num2 = 1131303186;
							num6 = num2;
						}
						continue;
					}
					case 4:
						hwJtYWPMGvWQzlewoWRSkOkcSeW3 = P_1[num3];
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW3 != null && hwJtYWPMGvWQzlewoWRSkOkcSeW3.inputManagerId < 0)
						{
							num5 = 0;
							num2 = 1131303195;
							continue;
						}
						goto case 2;
					case 9:
						if (!reYntWceOkPUZwwqHtuPFEoKbLb(P_1, hwJtYWPMGvWQzlewoWRSkOkcSeW2.rewiredId))
						{
							int num4;
							if (hwJtYWPMGvWQzlewoWRSkOkcSeW3.CGvNMgTtJKByfBoLCudPLkyvgkV(hwJtYWPMGvWQzlewoWRSkOkcSeW2) < num)
							{
								num2 = 1131303186;
								num4 = num2;
							}
							else
							{
								num2 = 1131303184;
								num4 = num2;
							}
							continue;
						}
						goto case 3;
					case 5:
						num3 = 0;
						num2 = 1131303190;
						continue;
					case 3:
						num5++;
						num2 = 1131303195;
						continue;
					case 8:
						return;
					}
					break;
				}
			}
		}

		private void SWJVUJtNevBpHELnpTBupupzivbg(int P_0, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_1, NIOXrqHRlxHlUMLPLEvYiqbHqqY.igFlsUZdiaAWHzaPiGtekcNHjYY P_2)
		{
			int num = 0;
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW2 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			int num4 = default(int);
			NIOXrqHRlxHlUMLPLEvYiqbHqqY.iGzxVnYmiJOurfvDweKkwKhmTCJ iGzxVnYmiJOurfvDweKkwKhmTCJ = default(NIOXrqHRlxHlUMLPLEvYiqbHqqY.iGzxVnYmiJOurfvDweKkwKhmTCJ);
			while (true)
			{
				int num2;
				int num3;
				if (num >= P_0)
				{
					num2 = 789622965;
					num3 = num2;
				}
				else
				{
					num2 = 789622967;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2F10B0B1)
					{
					case 8:
						num2 = 789622967;
						continue;
					default:
						return;
					case 7:
						VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(hwJtYWPMGvWQzlewoWRSkOkcSeW2);
						num2 = 789622964;
						continue;
					case 2:
						num4 = iGzxVnYmiJOurfvDweKkwKhmTCJ.GWoLlqegGvGyTtMNhZYqvtRENGv;
						num2 = 789622961;
						continue;
					case 6:
						hwJtYWPMGvWQzlewoWRSkOkcSeW2 = P_1[num];
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW2 != null && hwJtYWPMGvWQzlewoWRSkOkcSeW2.inputManagerId < 0)
						{
							iGzxVnYmiJOurfvDweKkwKhmTCJ = VYIiPbQDTfmyzeeKLOEXjAUgGAe.OlRyGPawIBmfpGbjKDHJQXdzfaeG(hwJtYWPMGvWQzlewoWRSkOkcSeW2, P_2);
							if (iGzxVnYmiJOurfvDweKkwKhmTCJ != null)
							{
								int num5;
								if (!reYntWceOkPUZwwqHtuPFEoKbLb(P_1, iGzxVnYmiJOurfvDweKkwKhmTCJ.YZYerWLyrZezITIzzsjvGpplKQw))
								{
									num2 = 789622963;
									num5 = num2;
								}
								else
								{
									num2 = 789622964;
									num5 = num2;
								}
								continue;
							}
						}
						goto case 5;
					case 3:
						break;
					case 5:
						num++;
						num2 = 789622962;
						continue;
					case 0:
						if (num4 < 0)
						{
							goto case 5;
						}
						if (!tdJERshKrZupAABGOtPFZhjIApQ(P_1, num4))
						{
							num4 = (iGzxVnYmiJOurfvDweKkwKhmTCJ.GWoLlqegGvGyTtMNhZYqvtRENGv = lthALbyMafUeFUSoDiwZaXONIhC(P_1));
							num2 = 789622968;
							continue;
						}
						goto case 9;
					case 1:
						hwJtYWPMGvWQzlewoWRSkOkcSeW2.rewiredId = iGzxVnYmiJOurfvDweKkwKhmTCJ.YZYerWLyrZezITIzzsjvGpplKQw;
						num2 = 789622966;
						continue;
					case 9:
						hwJtYWPMGvWQzlewoWRSkOkcSeW2.inputManagerId = num4;
						num2 = 789622960;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void YUdSTENKKNoVxApSKeakGqiLoBfc()
		{
			CustomInputSource.Joystick[] array = LIUEXihIfwBszLMEBQZCkixZlBNJ.wcCVtOLMXtslsqKKaATjxgsaWWV();
			if (hXJLHlYsxiqopPvGhwftUXQBvzA(array))
			{
				MBWbLtwiramKtsVixhpKLRHaVam(array);
				goto IL_001c;
			}
			goto IL_003a;
			IL_003a:
			LDAcgYOFyYXGHPLDHfJvYGEiUNl = false;
			int num = 887258058;
			goto IL_0021;
			IL_001c:
			num = 887258057;
			goto IL_0021;
			IL_0021:
			switch (num ^ 0x34E27BCB)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_003a;
			case 1:
				return;
			}
			goto IL_001c;
		}

		private bool hXJLHlYsxiqopPvGhwftUXQBvzA(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
			if (num != count)
			{
				return true;
			}
			int num2 = 0;
			int num3 = default(int);
			long? num8 = default(long?);
			long? systemId4 = default(long?);
			bool flag = default(bool);
			long? num6 = default(long?);
			long? systemId2 = default(long?);
			bool flag2 = default(bool);
			int num5 = default(int);
			long? systemId3 = default(long?);
			int num7 = default(int);
			long? systemId = default(long?);
			while (true)
			{
				IL_01af:
				int num4;
				if (num2 >= num)
				{
					num3 = 0;
					num4 = -270146497;
					goto IL_0022;
				}
				goto IL_012d;
				IL_022e:
				num2++;
				num4 = -270146503;
				goto IL_0022;
				IL_012d:
				if (P_0[num2] != null)
				{
					num4 = -270146507;
					goto IL_0022;
				}
				goto IL_022e;
				IL_0022:
				while (true)
				{
					switch (num4 ^ -270146507)
					{
					case 18:
						num4 = -270146499;
						continue;
					case 16:
						if (num8.HasValue == systemId4.HasValue)
						{
							flag = true;
							num4 = -270146504;
							continue;
						}
						goto case 14;
					case 20:
						if (num6.HasValue == systemId2.HasValue)
						{
							flag2 = true;
							num4 = -270146511;
							continue;
						}
						goto case 2;
					case 3:
						if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num5] != null)
						{
							num8 = systemId3;
							systemId4 = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num5].systemId;
							if (num8.GetValueOrDefault() == systemId4.GetValueOrDefault())
							{
								num4 = -270146523;
								continue;
							}
						}
						goto case 14;
					case 4:
						break;
					case 8:
						goto end_IL_0022;
					case 7:
						goto IL_013f;
					case 1:
						num4 = -270146528;
						continue;
					case 9:
						num7 = 0;
						num4 = -270146524;
						continue;
					case 14:
						num5++;
						num4 = -270146528;
						continue;
					case 5:
						goto IL_017f;
					case 12:
						goto IL_01af;
					case 0:
						systemId3 = P_0[num2].systemId;
						flag = false;
						num5 = 0;
						num4 = -270146508;
						continue;
					case 17:
						num4 = -270146510;
						continue;
					case 13:
						goto IL_01e6;
					case 19:
						systemId2 = P_0[num7].systemId;
						if (num6.GetValueOrDefault() == systemId2.GetValueOrDefault())
						{
							num4 = -270146527;
							continue;
						}
						goto case 2;
					case 2:
						num7++;
						num4 = -270146510;
						continue;
					case 15:
						return true;
					case 6:
						num6 = systemId;
						num4 = -270146522;
						continue;
					case 11:
						goto IL_024a;
					case 21:
						goto IL_0264;
					default:
						if (num3 >= count)
						{
							return false;
						}
						goto IL_017f;
					}
					if (!flag2)
					{
						return true;
					}
					goto IL_011d;
					IL_0264:
					int num9;
					if (num5 >= count)
					{
						num4 = -270146504;
						num9 = num4;
					}
					else
					{
						num4 = -270146506;
						num9 = num4;
					}
					continue;
					IL_017f:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3] != null)
					{
						systemId = AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3].systemId;
						flag2 = false;
						num4 = -270146500;
						continue;
					}
					goto IL_011d;
					IL_01e6:
					if (!flag)
					{
						num4 = -270146502;
						continue;
					}
					goto IL_022e;
					IL_024a:
					int num10;
					if (P_0[num7] == null)
					{
						num4 = -270146505;
						num10 = num4;
					}
					else
					{
						num4 = -270146509;
						num10 = num4;
					}
					continue;
					IL_013f:
					int num11;
					if (num7 >= num)
					{
						num4 = -270146511;
						num11 = num4;
					}
					else
					{
						num4 = -270146498;
						num11 = num4;
					}
					continue;
					IL_011d:
					num3++;
					num4 = -270146497;
					continue;
					end_IL_0022:
					break;
				}
				goto IL_012d;
			}
		}

		private void DtOBegFLamhBKwlmzaaiccPahGxz(List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_0, List<hwJtYWPMGvWQzlewoWRSkOkcSeW> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW2 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			bool flag = default(bool);
			int num5 = default(int);
			hwJtYWPMGvWQzlewoWRSkOkcSeW hwJtYWPMGvWQzlewoWRSkOkcSeW3 = default(hwJtYWPMGvWQzlewoWRSkOkcSeW);
			while (true)
			{
				int num = ((P_0 != null) ? P_0.Count : 0);
				int num2 = ((P_1 != null) ? P_1.Count : 0);
				int num3 = 0;
				int num4 = -109278011;
				while (true)
				{
					switch (num4 ^ -109278011)
					{
					case 10:
						num4 = -109278009;
						continue;
					case 5:
						jdgXxQHlYgOTDPrZOCVnfSFXUtzk(P_0[num3], P_2);
						num4 = -109278013;
						continue;
					case 4:
						hwJtYWPMGvWQzlewoWRSkOkcSeW2 = P_0[num3];
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW2 != null)
						{
							flag = false;
							if (P_1 != null)
							{
								num5 = 0;
								num4 = -109278004;
								continue;
							}
							goto case 7;
						}
						goto case 6;
					case 9:
						num4 = -109278010;
						continue;
					case 3:
					{
						int num7;
						if (num5 < num2)
						{
							num4 = -109278003;
							num7 = num4;
						}
						else
						{
							num4 = -109278014;
							num7 = num4;
						}
						continue;
					}
					case 11:
						num5++;
						num4 = -109278010;
						continue;
					case 7:
					{
						int num8;
						if (!flag)
						{
							num4 = -109278016;
							num8 = num4;
						}
						else
						{
							num4 = -109278013;
							num8 = num4;
						}
						continue;
					}
					case 2:
						break;
					case 6:
						num3++;
						num4 = -109278011;
						continue;
					case 8:
					{
						hwJtYWPMGvWQzlewoWRSkOkcSeW3 = P_1[num5];
						int num6;
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW3 != null)
						{
							num4 = -109278012;
							num6 = num4;
						}
						else
						{
							num4 = -109278002;
							num6 = num4;
						}
						continue;
					}
					case 1:
						if (hwJtYWPMGvWQzlewoWRSkOkcSeW2.rewiredId == hwJtYWPMGvWQzlewoWRSkOkcSeW3.rewiredId)
						{
							flag = true;
							num4 = -109278014;
							continue;
						}
						goto case 11;
					default:
						if (num3 >= num)
						{
							return;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		private void jdgXxQHlYgOTDPrZOCVnfSFXUtzk(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.HrCUbqPxwDZdLCwtaDJbCdJebrq();
				goto IL_0009;
			}
			goto IL_0027;
			IL_0027:
			SfHMDdlcsbsFEPyvTjkIDMcxypA(P_0, P_1);
			int num = 480578867;
			goto IL_000e;
			IL_0009:
			num = 480578864;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x1CA50D31)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0027;
			case 2:
				return;
			}
			goto IL_0009;
		}

		private void SfHMDdlcsbsFEPyvTjkIDMcxypA(hwJtYWPMGvWQzlewoWRSkOkcSeW P_0, bool P_1)
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
				int num = -1733292576;
				while (true)
				{
					switch (num ^ -1733292576)
					{
					case 2:
						goto IL_001d;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_001d:
					num = -1733292575;
				}
			}
		}
	}
}
