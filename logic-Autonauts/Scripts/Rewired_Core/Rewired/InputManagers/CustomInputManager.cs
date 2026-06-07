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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class UjRCRJDfGfDpWwHlQMLAERgcbfBS : IInputManagerJoystickPublic, IInputManagerJoystick
		{
			private readonly InputSource rsTYFamRrKtdrFcGFJzbrFwDZOs;

			private readonly CustomInputSource qYMxEncGvudBCauPreXIXlxJBQK;

			private readonly Controller.Extension iKrPwKwbznPAureDUGtpiCKudaT;

			private int GHfkhSadilGfAxFyuOxXFmXoNB;

			private int pypcACKajeDXMgihCBBcoMfRHezM;

			private long? gEmWeJYfBgnlltFGfhGUfHSHmACI;

			private int hByaRVpMQNtgYWGKTUTkcHssvjs;

			public Guid ocZIgneRSUDLHotByUrmWfynkiD;

			public string eIfVLwdouQinCOHKaqFZLQPIxWh;

			public string EhwqqtoeznbQaiMsyDLqPuFNCFR;

			private int ijxelHigybruBiYdNSiiNzGQTwsf;

			private int vgSbQnhkfGJDrjOShKPojdhsCSkQ;

			private float[] wbUISjltnzArWBKEUafkjffKERTS;

			private bool[] CFcByKWcDyyvXwtHigPcgEPuCPR;

			private HardwareJoystickMap_InputManager kABaypBwJpdJPQfaNrcsDzJUopW;

			public CustomInputSource.Joystick RyMGnIsqLxWuAShaFgWuroLmzHk;

			private bool qEBChkdMenIWbHajRwlLiEqfOWVs;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> SquvrBwjLHJfDioapylbqZuppCD;

			public int hardwareButtonCount
			{
				get
				{
					if (RyMGnIsqLxWuAShaFgWuroLmzHk == null)
					{
						return 0;
					}
					return RyMGnIsqLxWuAShaFgWuroLmzHk.buttonCount;
				}
			}

			public int hardwareAxisCount
			{
				get
				{
					if (RyMGnIsqLxWuAShaFgWuroLmzHk == null)
					{
						return 0;
					}
					return RyMGnIsqLxWuAShaFgWuroLmzHk.axisCount;
				}
			}

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
					string text = ((!string.IsNullOrEmpty(RyMGnIsqLxWuAShaFgWuroLmzHk.customName)) ? RyMGnIsqLxWuAShaFgWuroLmzHk.customName : eIfVLwdouQinCOHKaqFZLQPIxWh);
					while (true)
					{
						int num = -8677343;
						while (true)
						{
							switch (num ^ -8677344)
							{
							case 2:
								break;
							case 1:
								if (text == "Unknown Controller")
								{
									goto IL_0051;
								}
								goto default;
							default:
								return text;
							}
							break;
							IL_0051:
							text = EhwqqtoeznbQaiMsyDLqPuFNCFR;
							num = -8677344;
						}
					}
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId
			{
				get
				{
					return gEmWeJYfBgnlltFGfhGUfHSHmACI;
				}
			}

			[CustomObfuscation(rename = false)]
			public int unityId
			{
				get
				{
					return hByaRVpMQNtgYWGKTUTkcHssvjs;
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!gEmWeJYfBgnlltFGfhGUfHSHmACI.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + gEmWeJYfBgnlltFGfhGUfHSHmACI);
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
					return iKrPwKwbznPAureDUGtpiCKudaT;
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

			public UjRCRJDfGfDpWwHlQMLAERgcbfBS(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, Controller.Extension controllerExtension, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
			{
				qYMxEncGvudBCauPreXIXlxJBQK = customInputSource;
				rsTYFamRrKtdrFcGFJzbrFwDZOs = inputSource;
				gEmWeJYfBgnlltFGfhGUfHSHmACI = systemJoystickId;
				RyMGnIsqLxWuAShaFgWuroLmzHk = joystick;
				hByaRVpMQNtgYWGKTUTkcHssvjs = unityJoystickId;
				iKrPwKwbznPAureDUGtpiCKudaT = controllerExtension;
				SquvrBwjLHJfDioapylbqZuppCD = getHardwareJoystickMap_InputManager;
				pypcACKajeDXMgihCBBcoMfRHezM = -1;
				GHfkhSadilGfAxFyuOxXFmXoNB = -1;
				cQAaFptieRamqauyKZBxAdBkaurO();
				cYHcXCOFpORyFoNYyhyTldjiUMD();
				ocZIgneRSUDLHotByUrmWfynkiD = kABaypBwJpdJPQfaNrcsDzJUopW.hardwareMapIdentifier.guid;
				eIfVLwdouQinCOHKaqFZLQPIxWh = kABaypBwJpdJPQfaNrcsDzJUopW.controllerName;
				wbUISjltnzArWBKEUafkjffKERTS = new float[ijxelHigybruBiYdNSiiNzGQTwsf];
				CFcByKWcDyyvXwtHigPcgEPuCPR = new bool[vgSbQnhkfGJDrjOShKPojdhsCSkQ];
				Update();
			}

			public void cQAaFptieRamqauyKZBxAdBkaurO()
			{
				EhwqqtoeznbQaiMsyDLqPuFNCFR = RyMGnIsqLxWuAShaFgWuroLmzHk.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (!RyMGnIsqLxWuAShaFgWuroLmzHk.isConnected)
				{
					return;
				}
				while (true)
				{
					pZGbWgDuiUJknDkmqIIleMKulPyz();
					OmvEduKEMDwCfGsAUMYnJwvhRxA();
					int num = -416074530;
					while (true)
					{
						switch (num ^ -416074529)
						{
						case 0:
							goto IL_000e;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000e:
						num = -416074531;
					}
				}
			}

			public int texDHprRVSCDIhdEcHxFsscbHjUA(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0)
			{
				long? num = default(long?);
				if (P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR == EhwqqtoeznbQaiMsyDLqPuFNCFR)
				{
					num = P_0.gEmWeJYfBgnlltFGfhGUfHSHmACI;
					goto IL_001a;
				}
				goto IL_0066;
				IL_0066:
				int num2;
				if (P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR == EhwqqtoeznbQaiMsyDLqPuFNCFR)
				{
					num2 = -864323575;
					goto IL_001f;
				}
				return 0;
				IL_001a:
				num2 = -864323576;
				goto IL_001f;
				IL_001f:
				switch (num2 ^ -864323575)
				{
				case 2:
					break;
				case 1:
					goto IL_0038;
				default:
					return 1;
				}
				goto IL_001a;
				IL_0038:
				if (num == gEmWeJYfBgnlltFGfhGUfHSHmACI)
				{
					return 2;
				}
				goto IL_0066;
			}

			private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = rsTYFamRrKtdrFcGFJzbrFwDZOs;
				while (true)
				{
					int num = -1795760186;
					while (true)
					{
						switch (num ^ -1795760185)
						{
						case 3:
							break;
						case 1:
							P_0.inputSource = rsTYFamRrKtdrFcGFJzbrFwDZOs;
							P_0.hardwareIdentifier = wrMbWRvukXjTEBqvwwUtLByTtlYl();
							P_0.hardwareAxisCount = ijxelHigybruBiYdNSiiNzGQTwsf;
							num = -1795760185;
							continue;
						case 0:
							P_0.hardwareButtonCount = vgSbQnhkfGJDrjOShKPojdhsCSkQ;
							num = -1795760187;
							continue;
						default:
							P_0.hardwareHatCount = 0;
							P_0.hw_productName = EhwqqtoeznbQaiMsyDLqPuFNCFR;
							P_0.hw_supportsVibration = RyMGnIsqLxWuAShaFgWuroLmzHk.supportsVibration;
							return;
						}
						break;
					}
				}
			}

			private void VDeqJOjTSTlabFOpcCmVfVrbzeiM(BridgedController P_0)
			{
				VDeqJOjTSTlabFOpcCmVfVrbzeiM((BridgedControllerHWInfo)P_0);
				while (true)
				{
					int num = -459282026;
					while (true)
					{
						switch (num ^ -459282028)
						{
						case 3:
							break;
						case 1:
							P_0.axisCount = ijxelHigybruBiYdNSiiNzGQTwsf;
							num = -459282030;
							continue;
						case 6:
							P_0.buttonCount = vgSbQnhkfGJDrjOShKPojdhsCSkQ;
							P_0.controllerTypeGuid = ocZIgneRSUDLHotByUrmWfynkiD;
							P_0.customInputSource = qYMxEncGvudBCauPreXIXlxJBQK;
							num = -459282032;
							continue;
						case 5:
							P_0.instanceName = EhwqqtoeznbQaiMsyDLqPuFNCFR;
							num = -459282028;
							continue;
						case 2:
							P_0.sourceJoystick = this;
							P_0.gameHardwareMap = kABaypBwJpdJPQfaNrcsDzJUopW.ToGameHardwareControllerMap();
							num = -459282031;
							continue;
						case 0:
							P_0.productName = EhwqqtoeznbQaiMsyDLqPuFNCFR;
							P_0.isXInputDevice = false;
							num = -459282027;
							continue;
						default:
							P_0.controllerExtension = iKrPwKwbznPAureDUGtpiCKudaT;
							return;
						}
						break;
					}
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (ijxelHigybruBiYdNSiiNzGQTwsf != dataUpdater.axisCount)
				{
					goto IL_00b7;
				}
				if (vgSbQnhkfGJDrjOShKPojdhsCSkQ != dataUpdater.buttonCount)
				{
					goto IL_0022;
				}
				goto IL_0103;
				IL_00b7:
				throw new Exception("This controller signature does not match the data object!");
				IL_0022:
				int num = -301880510;
				goto IL_0027;
				IL_0027:
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ -301880501)
					{
					case 4:
						break;
					default:
						return;
					case 6:
						num2++;
						num = -301880502;
						continue;
					case 3:
						dataUpdater.buttonValues[num3] = CFcByKWcDyyvXwtHigPcgEPuCPR[num3];
						num3++;
						num = -301880503;
						continue;
					case 7:
						if (!dataUpdater.hasReceivedInput)
						{
							dataUpdater.hasReceivedInput = true;
							num = -301880498;
							continue;
						}
						return;
					case 1:
						if (num2 >= ijxelHigybruBiYdNSiiNzGQTwsf)
						{
							num3 = 0;
							num = -301880503;
							continue;
						}
						goto case 8;
					case 9:
						goto IL_00b7;
					case 2:
						goto IL_00cc;
					case 8:
						dataUpdater.axisValues[num2] = wbUISjltnzArWBKEUafkjffKERTS[num2];
						num = -301880499;
						continue;
					case 10:
						goto IL_0103;
					case 0:
						goto IL_010f;
					case 5:
						return;
					}
					break;
					IL_010f:
					int num4;
					if (qEBChkdMenIWbHajRwlLiEqfOWVs)
					{
						num = -301880500;
						num4 = num;
					}
					else
					{
						num = -301880498;
						num4 = num;
					}
					continue;
					IL_00cc:
					int num5;
					if (num3 < vgSbQnhkfGJDrjOShKPojdhsCSkQ)
					{
						num = -301880504;
						num5 = num;
					}
					else
					{
						num = -301880501;
						num5 = num;
					}
				}
				goto IL_0022;
				IL_0103:
				num2 = 0;
				num = -301880502;
				goto IL_0027;
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

			private void pZGbWgDuiUJknDkmqIIleMKulPyz()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)kABaypBwJpdJPQfaNrcsDzJUopW.map).Axes;
				if (axes == null)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = 64248477;
					while (true)
					{
						switch (num2 ^ 0x3D45A9C)
						{
						case 5:
							num2 = 64248474;
							continue;
						default:
							return;
						case 6:
							break;
						case 4:
							if (axes[num] == null)
							{
								goto case 2;
							}
							if (num >= ijxelHigybruBiYdNSiiNzGQTwsf)
							{
								throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
							}
							goto case 0;
						case 8:
							if (wbUISjltnzArWBKEUafkjffKERTS[num] != 0f)
							{
								qEBChkdMenIWbHajRwlLiEqfOWVs = true;
								num2 = 64248478;
								continue;
							}
							goto case 2;
						case 2:
							num++;
							num2 = 64248479;
							continue;
						case 3:
						{
							int num3;
							if (num < axes.Length)
							{
								num2 = 64248472;
								num3 = num2;
							}
							else
							{
								num2 = 64248475;
								num3 = num2;
							}
							continue;
						}
						case 1:
							num2 = 64248479;
							continue;
						case 0:
						{
							wbUISjltnzArWBKEUafkjffKERTS[num] = dLTmadjmjVluMhSlcxbDwCyzhb(axes[num]);
							int num4;
							if (!qEBChkdMenIWbHajRwlLiEqfOWVs)
							{
								num2 = 64248468;
								num4 = num2;
							}
							else
							{
								num2 = 64248478;
								num4 = num2;
							}
							continue;
						}
						case 7:
							return;
						}
						break;
					}
				}
			}

			private void OmvEduKEMDwCfGsAUMYnJwvhRxA()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)kABaypBwJpdJPQfaNrcsDzJUopW.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				while (true)
				{
					int num = 0;
					int num2 = 277872600;
					while (true)
					{
						switch (num2 ^ 0x108FFFDA)
						{
						case 4:
							num2 = 277872603;
							continue;
						case 1:
							break;
						case 0:
							if (num >= vgSbQnhkfGJDrjOShKPojdhsCSkQ)
							{
								throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
							}
							goto case 6;
						case 5:
							if (!qEBChkdMenIWbHajRwlLiEqfOWVs && CFcByKWcDyyvXwtHigPcgEPuCPR[num])
							{
								qEBChkdMenIWbHajRwlLiEqfOWVs = true;
								num2 = 277872601;
								continue;
							}
							goto case 3;
						case 6:
							CFcByKWcDyyvXwtHigPcgEPuCPR[num] = VMMfdBCZsMnRqIWVFlCcPeWKEbcs(buttons[num]);
							num2 = 277872607;
							continue;
						case 3:
							num++;
							num2 = 277872600;
							continue;
						default:
							if (num >= buttons.Length)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			private bool VMMfdBCZsMnRqIWVFlCcPeWKEbcs(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					goto IL_000b;
				}
				int num;
				if (P_0.sourceType == 1)
				{
					num = -140500327;
					goto IL_0010;
				}
				return false;
				IL_000b:
				num = -140500324;
				goto IL_0010;
				IL_0010:
				float num2 = default(float);
				while (true)
				{
					switch (num ^ -140500328)
					{
					case 3:
						break;
					case 0:
						if (MathTools.Abs(num2) <= P_0.axisDeadZone)
						{
							return false;
						}
						if (P_0.sourceAxisPole == Pole.Positive && num2 < 0f)
						{
							return false;
						}
						if (P_0.sourceAxisPole == Pole.Negative && num2 > 0f)
						{
							num = -140500326;
							continue;
						}
						return true;
					case 1:
						num2 = dLTmadjmjVluMhSlcxbDwCyzhb(P_0.sourceAxis);
						num = -140500328;
						continue;
					case 4:
						return VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.sourceButton);
					default:
						return false;
					}
					break;
				}
				goto IL_000b;
			}

			private bool cWIAPhHiGrnNQgMTGgFCAjEbVQBJ(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float dLTmadjmjVluMhSlcxbDwCyzhb(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return dLTmadjmjVluMhSlcxbDwCyzhb(P_0.sourceAxis);
				}
				float result = default(float);
				if (P_0.sourceType == 0)
				{
					while (true)
					{
						int num = 594306498;
						while (true)
						{
							switch (num ^ 0x236C65C1)
							{
							case 4:
								break;
							case 3:
							{
								if (!VMMfdBCZsMnRqIWVFlCcPeWKEbcs(P_0.sourceButton))
								{
									return 0f;
								}
								int num2;
								if (P_0.buttonAxisContribution != Pole.Positive)
								{
									num = 594306496;
									num2 = num;
								}
								else
								{
									num = 594306497;
									num2 = num;
								}
								continue;
							}
							case 0:
								result = 1f;
								num = 594306499;
								continue;
							case 1:
								result = -1f;
								num = 594306499;
								continue;
							default:
								return result;
							}
							break;
						}
					}
				}
				throw new NotImplementedException();
			}

			private float dLTmadjmjVluMhSlcxbDwCyzhb(int P_0)
			{
				return RyMGnIsqLxWuAShaFgWuroLmzHk.GetAxisValue(P_0);
			}

			private bool VMMfdBCZsMnRqIWVFlCcPeWKEbcs(int P_0)
			{
				return RyMGnIsqLxWuAShaFgWuroLmzHk.GetButtonValue(P_0);
			}

			private void cYHcXCOFpORyFoNYyhyTldjiUMD()
			{
				kABaypBwJpdJPQfaNrcsDzJUopW = SquvrBwjLHJfDioapylbqZuppCD(qOeDHherkAoikMXOIsfGhJBfRvh());
				while (true)
				{
					switch (0x43B0773 ^ 0x43B0771)
					{
					case 0:
						continue;
					case 2:
						if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
						{
							Logger.LogError("Default hardware map not found!");
							return;
						}
						break;
					}
					break;
				}
				ijxelHigybruBiYdNSiiNzGQTwsf = kABaypBwJpdJPQfaNrcsDzJUopW.axisCount;
				vgSbQnhkfGJDrjOShKPojdhsCSkQ = kABaypBwJpdJPQfaNrcsDzJUopW.buttonCount;
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
					return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), ReInput.webplayerPlatform.ToString(), rsTYFamRrKtdrFcGFJzbrFwDZOs.ToString(), EhwqqtoeznbQaiMsyDLqPuFNCFR));
				}
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), rsTYFamRrKtdrFcGFJzbrFwDZOs.ToString(), EhwqqtoeznbQaiMsyDLqPuFNCFR));
			}

			public static int DdthPkejlSCBRHlGiPFXBIiIcvj(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, UjRCRJDfGfDpWwHlQMLAERgcbfBS P_1)
			{
				if (P_0.pypcACKajeDXMgihCBBcoMfRHezM < P_1.pypcACKajeDXMgihCBBcoMfRHezM)
				{
					return -1;
				}
				if (P_0.pypcACKajeDXMgihCBBcoMfRHezM > P_1.pypcACKajeDXMgihCBBcoMfRHezM)
				{
					return 1;
				}
				return 0;
			}

			public static int wVvCuiwMUgooQyGXybZGbznoTDR(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, UjRCRJDfGfDpWwHlQMLAERgcbfBS P_1)
			{
				long? num = P_0.gEmWeJYfBgnlltFGfhGUfHSHmACI;
				long? num2 = P_1.gEmWeJYfBgnlltFGfhGUfHSHmACI;
				long? num4 = default(long?);
				while (true)
				{
					int num3 = -2062479278;
					while (true)
					{
						switch (num3 ^ -2062479277)
						{
						case 0:
							break;
						case 1:
							if (!(num < num2))
							{
								goto IL_0052;
							}
							return -1;
						default:
							if (num4 > P_1.gEmWeJYfBgnlltFGfhGUfHSHmACI)
							{
								return 1;
							}
							return 0;
						}
						break;
						IL_0052:
						num4 = P_0.gEmWeJYfBgnlltFGfhGUfHSHmACI;
						num3 = -2062479279;
					}
				}
			}
		}

		private class wAWhqjaldjmIxyyWdhxUDJtLUbZs
		{
			public enum YQdckKlKiygeWjVwgVlBlgICONlz
			{
				OhRlOZGftuFdhsJLJdBYcXflSzkM = 0,
				miFZPclZwwzlANpYVeOKmkxlzSo = 1
			}

			public class igTmcrTqIovDncueXqUJhCyVKmB
			{
				public int lJGmoPjWlZhCnfYmPrnrnNrpiFd;

				public long? RPKHxnkugqFjnANRQkoJIMYuiUe;

				public string vjITxzvWrKXTVVGmBWwpPCtMVsl;

				public int hkuClqGgyrjaNFrDJJuCSthMWeZ;

				public int vgSbQnhkfGJDrjOShKPojdhsCSkQ;

				public int ijxelHigybruBiYdNSiiNzGQTwsf;

				public igTmcrTqIovDncueXqUJhCyVKmB(int rewiredId, long? systemId, string systemControllerName, int lastInputManagerId, int buttonCount, int axisCount)
				{
					lJGmoPjWlZhCnfYmPrnrnNrpiFd = rewiredId;
					RPKHxnkugqFjnANRQkoJIMYuiUe = systemId;
					vjITxzvWrKXTVVGmBWwpPCtMVsl = systemControllerName;
					hkuClqGgyrjaNFrDJJuCSthMWeZ = lastInputManagerId;
					vgSbQnhkfGJDrjOShKPojdhsCSkQ = buttonCount;
					ijxelHigybruBiYdNSiiNzGQTwsf = axisCount;
				}

				public bool texDHprRVSCDIhdEcHxFsscbHjUA(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, YQdckKlKiygeWjVwgVlBlgICONlz P_1)
				{
					if (P_0.rewiredId == lJGmoPjWlZhCnfYmPrnrnNrpiFd)
					{
						return true;
					}
					if (P_0.hardwareButtonCount != vgSbQnhkfGJDrjOShKPojdhsCSkQ)
					{
						return false;
					}
					if (P_0.hardwareAxisCount != ijxelHigybruBiYdNSiiNzGQTwsf)
					{
						goto IL_002e;
					}
					long? rPKHxnkugqFjnANRQkoJIMYuiUe = default(long?);
					long? systemId = default(long?);
					int num;
					if (P_1 == YQdckKlKiygeWjVwgVlBlgICONlz.OhRlOZGftuFdhsJLJdBYcXflSzkM)
					{
						rPKHxnkugqFjnANRQkoJIMYuiUe = RPKHxnkugqFjnANRQkoJIMYuiUe;
						systemId = P_0.systemId;
						num = 1282595560;
					}
					else
					{
						if (P_1 != YQdckKlKiygeWjVwgVlBlgICONlz.miFZPclZwwzlANpYVeOKmkxlzSo)
						{
							throw new NotImplementedException();
						}
						num = 1282595561;
					}
					goto IL_0033;
					IL_0033:
					switch (num ^ 0x4C72DAE9)
					{
					case 3:
						break;
					case 2:
						return false;
					case 1:
						if (rPKHxnkugqFjnANRQkoJIMYuiUe == systemId)
						{
							return vjITxzvWrKXTVVGmBWwpPCtMVsl == P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR;
						}
						return false;
					default:
						return vjITxzvWrKXTVVGmBWwpPCtMVsl == P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR;
					}
					goto IL_002e;
					IL_002e:
					num = 1282595563;
					goto IL_0033;
				}
			}

			private List<igTmcrTqIovDncueXqUJhCyVKmB> KbaDSiCRyndUgELDxxppquzLFodU;

			public int Count
			{
				get
				{
					return KbaDSiCRyndUgELDxxppquzLFodU.Count;
				}
			}

			public wAWhqjaldjmIxyyWdhxUDJtLUbZs()
			{
				KbaDSiCRyndUgELDxxppquzLFodU = new List<igTmcrTqIovDncueXqUJhCyVKmB>();
			}

			public void CzcBIezjgBkIUujMOARHJgPbWVOP(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0)
			{
				if (P_0 == null)
				{
					goto IL_0003;
				}
				goto IL_007f;
				IL_0003:
				int num = 1579211925;
				goto IL_0008;
				IL_0008:
				int num2 = default(int);
				int count = default(int);
				while (true)
				{
					switch (num ^ 0x5E20DC93)
					{
					case 3:
						break;
					case 7:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].vgSbQnhkfGJDrjOShKPojdhsCSkQ = P_0.hardwareButtonCount;
						KbaDSiCRyndUgELDxxppquzLFodU[num2].ijxelHigybruBiYdNSiiNzGQTwsf = P_0.hardwareAxisCount;
						iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, num2);
						return;
					case 4:
						goto IL_007f;
					case 0:
						if (KbaDSiCRyndUgELDxxppquzLFodU[num2].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, YQdckKlKiygeWjVwgVlBlgICONlz.OhRlOZGftuFdhsJLJdBYcXflSzkM))
						{
							KbaDSiCRyndUgELDxxppquzLFodU[num2].lJGmoPjWlZhCnfYmPrnrnNrpiFd = P_0.rewiredId;
							num = 1579211931;
							continue;
						}
						goto case 1;
					case 6:
						return;
					case 8:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].RPKHxnkugqFjnANRQkoJIMYuiUe = P_0.systemId;
						KbaDSiCRyndUgELDxxppquzLFodU[num2].vjITxzvWrKXTVVGmBWwpPCtMVsl = P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR;
						num = 1579211926;
						continue;
					case 5:
						KbaDSiCRyndUgELDxxppquzLFodU[num2].hkuClqGgyrjaNFrDJJuCSthMWeZ = P_0.inputManagerId;
						num = 1579211924;
						continue;
					case 1:
						num2++;
						num = 1579211921;
						continue;
					default:
						if (num2 >= count)
						{
							KbaDSiCRyndUgELDxxppquzLFodU.Add(new igTmcrTqIovDncueXqUJhCyVKmB(P_0.rewiredId, P_0.systemId, P_0.EhwqqtoeznbQaiMsyDLqPuFNCFR, P_0.inputManagerId, P_0.hardwareButtonCount, P_0.hardwareAxisCount));
							iAyKOJFTncPoHepzJVFmwURBpNi(P_0.rewiredId, KbaDSiCRyndUgELDxxppquzLFodU.Count - 1);
							return;
						}
						goto case 0;
					}
					break;
				}
				goto IL_0003;
				IL_007f:
				count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				num2 = 0;
				num = 1579211921;
				goto IL_0008;
			}

			public bool hVhfCpEYePxtliVMkmzCRpiiDkB(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, YQdckKlKiygeWjVwgVlBlgICONlz P_1)
			{
				int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				int num = 0;
				while (num < count)
				{
					while (true)
					{
						if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
						{
							return true;
						}
						num++;
						int num2 = -2091044470;
						while (true)
						{
							switch (num2 ^ -2091044472)
							{
							case 0:
								num2 = -2091044471;
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

			public igTmcrTqIovDncueXqUJhCyVKmB lYJFZOeYSDYSWqqagvNTnOjxepl(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, YQdckKlKiygeWjVwgVlBlgICONlz P_1)
			{
				int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= count)
					{
						num2 = 1323138668;
						num3 = num2;
					}
					else
					{
						num2 = 1323138671;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x4EDD7E6D)
						{
						case 0:
							num2 = 1323138671;
							continue;
						case 2:
							if (KbaDSiCRyndUgELDxxppquzLFodU[num].texDHprRVSCDIhdEcHxFsscbHjUA(P_0, P_1))
							{
								return KbaDSiCRyndUgELDxxppquzLFodU[num];
							}
							num++;
							num2 = 1323138670;
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

			public int tZuNWtSCplPhyqDRGNVBVrTnWqi(igTmcrTqIovDncueXqUJhCyVKmB P_0)
			{
				int count = KbaDSiCRyndUgELDxxppquzLFodU.Count;
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < count)
					{
						num2 = 2130732449;
						num3 = num2;
					}
					else
					{
						num2 = 2130732451;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x7F0065A0)
						{
						case 2:
							num2 = 2130732449;
							continue;
						case 1:
							if (KbaDSiCRyndUgELDxxppquzLFodU[num] == P_0)
							{
								return num;
							}
							num++;
							num2 = 2130732448;
							continue;
						case 0:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			private void iAyKOJFTncPoHepzJVFmwURBpNi(int P_0, int P_1)
			{
				int num = KbaDSiCRyndUgELDxxppquzLFodU.Count - 1;
				while (num >= 0)
				{
					while (true)
					{
						int num2;
						if (num != P_1 && KbaDSiCRyndUgELDxxppquzLFodU[num].lJGmoPjWlZhCnfYmPrnrnNrpiFd == P_0)
						{
							KbaDSiCRyndUgELDxxppquzLFodU.RemoveAt(num);
							num2 = -209399710;
							goto IL_0015;
						}
						goto IL_005d;
						IL_005d:
						num--;
						num2 = -209399709;
						goto IL_0015;
						IL_0015:
						while (true)
						{
							switch (num2 ^ -209399709)
							{
							case 3:
								num2 = -209399711;
								continue;
							case 2:
								break;
							case 1:
								goto IL_005d;
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
			}
		}

		private List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> jkFiqNnyAtbymFOLlvWZRfYeLku;

		private int QpGtgOrxdSaeYYJRHgHfdBynVbjv;

		private wAWhqjaldjmIxyyWdhxUDJtLUbZs cBQhEyiNFbRkGCtCdGNTEMPiFbh;

		private UpdateLoopType KyGQivhvNcexgOdgEkqkdUhAdys;

		private Action<int, ControllerDataUpdater> xykDZfHJBUnQEfowVcHAJyncPoER;

		private PlatformInputManager hdSfCWqBbgExirMqfOCeUEacXMD;

		private CustomInputSource qYMxEncGvudBCauPreXIXlxJBQK;

		private bool oCfgXkGkSgDkbBQjCfrbIAyBZc;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> SquvrBwjLHJfDioapylbqZuppCD;

		private Func<int> JWZMJaIeQbeZYzwUqzlBWSLcbtjA;

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
				return qYMxEncGvudBCauPreXIXlxJBQK.inputSource;
			}
		}

		public CustomInputManager(CustomInputSource customInputSource, UpdateLoopSetting updateLoopSetting, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			qYMxEncGvudBCauPreXIXlxJBQK = customInputSource;
			SquvrBwjLHJfDioapylbqZuppCD = getHardwareJoystickMap_InputManager;
			JWZMJaIeQbeZYzwUqzlBWSLcbtjA = getNewJoystickId;
			hdSfCWqBbgExirMqfOCeUEacXMD = this;
			try
			{
				xykDZfHJBUnQEfowVcHAJyncPoER = UpdateControllerData;
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
			cBQhEyiNFbRkGCtCdGNTEMPiFbh = new wAWhqjaldjmIxyyWdhxUDJtLUbZs();
			jkFiqNnyAtbymFOLlvWZRfYeLku = new List<UjRCRJDfGfDpWwHlQMLAERgcbfBS>();
			oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			KyGQivhvNcexgOdgEkqkdUhAdys = updateLoop;
			while (true)
			{
				int num = -737627541;
				while (true)
				{
					switch (num ^ -737627543)
					{
					case 4:
						break;
					case 2:
					{
						int num2;
						if (qYMxEncGvudBCauPreXIXlxJBQK.isReady)
						{
							num = -737627542;
							num2 = num;
						}
						else
						{
							num = -737627540;
							num2 = num;
						}
						continue;
					}
					case 3:
						qYMxEncGvudBCauPreXIXlxJBQK.Update();
						num = -737627543;
						continue;
					case 5:
						return;
					case 0:
						if (oCfgXkGkSgDkbBQjCfrbIAyBZc)
						{
							lMlcWXDhUZyoYToHgCauFZahHGiP();
							num = -737627544;
							continue;
						}
						goto default;
					default:
						OojMLjXcFZUGyMEfOYjCmtjMhke();
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (qYMxEncGvudBCauPreXIXlxJBQK != null)
			{
				qYMxEncGvudBCauPreXIXlxJBQK.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return xykDZfHJBUnQEfowVcHAJyncPoER;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			int num = 0;
			while (num < QpGtgOrxdSaeYYJRHgHfdBynVbjv)
			{
				while (true)
				{
					int num2;
					int num3;
					if (jkFiqNnyAtbymFOLlvWZRfYeLku[num].inputManagerId == inputManagerId)
					{
						num2 = 185259690;
						num3 = num2;
					}
					else
					{
						num2 = 185259695;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0xB0AD6AB)
						{
						case 5:
							num2 = 185259688;
							continue;
						case 3:
							break;
						case 4:
							num++;
							num2 = 185259691;
							continue;
						case 2:
							return;
						case 1:
							jkFiqNnyAtbymFOLlvWZRfYeLku[num].FillData(data);
							num2 = 185259689;
							continue;
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
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			oCfgXkGkSgDkbBQjCfrbIAyBZc = true;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				_SystemDeviceDisconnectedEvent();
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

		private void pBKGiqCzbgfPGMFhRdFSwUDshjx(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> list = jkFiqNnyAtbymFOLlvWZRfYeLku;
			int num4 = default(int);
			int qpGtgOrxdSaeYYJRHgHfdBynVbjv = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = -197730949;
				while (true)
				{
					switch (num2 ^ -197730952)
					{
					case 9:
						break;
					default:
						return;
					case 0:
						num++;
						num2 = -197730951;
						continue;
					case 10:
					{
						int num6;
						if (P_0[num4] != null)
						{
							num2 = -197730960;
							num6 = num2;
						}
						else
						{
							num2 = -197730951;
							num6 = num2;
						}
						continue;
					}
					case 3:
						qpGtgOrxdSaeYYJRHgHfdBynVbjv = QpGtgOrxdSaeYYJRHgHfdBynVbjv;
						jkFiqNnyAtbymFOLlvWZRfYeLku = new List<UjRCRJDfGfDpWwHlQMLAERgcbfBS>();
						num4 = 0;
						num2 = -197730950;
						continue;
					case 7:
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(jkFiqNnyAtbymFOLlvWZRfYeLku[num3]));
						num2 = -197730946;
						continue;
					case 1:
						num4++;
						num2 = -197730950;
						continue;
					case 12:
						if (num3 >= num)
						{
							oQChKjbOquuMrWKdTwrmVgDaXkc(list, jkFiqNnyAtbymFOLlvWZRfYeLku, false);
							oQChKjbOquuMrWKdTwrmVgDaXkc(jkFiqNnyAtbymFOLlvWZRfYeLku, list, true);
							num2 = -197730948;
							continue;
						}
						goto case 5;
					case 8:
					{
						UjRCRJDfGfDpWwHlQMLAERgcbfBS item = new UjRCRJDfGfDpWwHlQMLAERgcbfBS(qYMxEncGvudBCauPreXIXlxJBQK, P_0[num4].systemId, P_0[num4].unityId, P_0[num4], qYMxEncGvudBCauPreXIXlxJBQK.inputSource, P_0[num4].extension, SquvrBwjLHJfDioapylbqZuppCD);
						jkFiqNnyAtbymFOLlvWZRfYeLku.Add(item);
						num2 = -197730952;
						continue;
					}
					case 6:
						num3++;
						num2 = -197730956;
						continue;
					case 2:
						if (num4 >= P_0.Length)
						{
							QpGtgOrxdSaeYYJRHgHfdBynVbjv = num;
							num2 = -197730957;
							continue;
						}
						goto case 10;
					case 5:
					{
						int num5;
						if (_UpdateControllerInfoEvent != null)
						{
							num2 = -197730945;
							num5 = num2;
						}
						else
						{
							num2 = -197730946;
							num5 = num2;
						}
						continue;
					}
					case 11:
						nFPQMeOiyGmsFomDtcaSCOUgIsTF(qpGtgOrxdSaeYYJRHgHfdBynVbjv, num, list, jkFiqNnyAtbymFOLlvWZRfYeLku);
						num3 = 0;
						num2 = -197730956;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void OojMLjXcFZUGyMEfOYjCmtjMhke()
		{
			int num = 0;
			while (num < QpGtgOrxdSaeYYJRHgHfdBynVbjv)
			{
				while (true)
				{
					jkFiqNnyAtbymFOLlvWZRfYeLku[num].Update();
					int num2 = -396095756;
					while (true)
					{
						switch (num2 ^ -396095756)
						{
						case 2:
							num2 = -396095755;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = -396095753;
							continue;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
		}

		private void nFPQMeOiyGmsFomDtcaSCOUgIsTF(int P_0, int P_1, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_2, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_3)
		{
			if (P_1 > 0)
			{
				goto IL_0007;
			}
			goto IL_00bf;
			IL_0007:
			int num = -1826183861;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS = default(UjRCRJDfGfDpWwHlQMLAERgcbfBS);
			int num4;
			while (true)
			{
				switch (num ^ -1826183857)
				{
				case 8:
					break;
				default:
					return;
				case 2:
					goto IL_0054;
				case 7:
					rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz.miFZPclZwwzlANpYVeOKmkxlzSo);
					num = -1826183860;
					continue;
				case 5:
					num2 = 0;
					num = -1826183866;
					continue;
				case 12:
					goto IL_00a0;
				case 10:
					goto IL_00bf;
				case 0:
					goto IL_00cd;
				case 13:
					if (ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId < 0)
					{
						ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId = IojKdiCykxLgoivdxmqNHsMNBtN(P_3);
						ujRCRJDfGfDpWwHlQMLAERgcbfBS.rewiredId = ReInput.GetNewJoystickId();
						num = -1826183863;
						continue;
					}
					goto case 1;
				case 6:
					cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(ujRCRJDfGfDpWwHlQMLAERgcbfBS);
					num = -1826183858;
					continue;
				case 4:
					P_3.Sort(UjRCRJDfGfDpWwHlQMLAERgcbfBS.wVvCuiwMUgooQyGXybZGbznoTDR);
					num = -1826183867;
					continue;
				case 9:
					if (num2 >= P_1)
					{
						P_3.Sort(UjRCRJDfGfDpWwHlQMLAERgcbfBS.DdthPkejlSCBRHlGiPFXBIiIcvj);
						num = -1826183868;
						continue;
					}
					goto IL_00cd;
				case 1:
					num2++;
					num = -1826183866;
					continue;
				case 3:
					xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz.OhRlOZGftuFdhsJLJdBYcXflSzkM);
					if (qYMxEncGvudBCauPreXIXlxJBQK.useApproximateMatching)
					{
						xtNfNMKFmfYIygncVYHsbFvnNoe(P_1, P_3, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz.miFZPclZwwzlANpYVeOKmkxlzSo);
						num = -1826183862;
						continue;
					}
					goto case 5;
				case 11:
					return;
				}
				break;
				IL_00cd:
				ujRCRJDfGfDpWwHlQMLAERgcbfBS = P_3[num2];
				int num3;
				if (ujRCRJDfGfDpWwHlQMLAERgcbfBS != null)
				{
					num = -1826183870;
					num3 = num;
				}
				else
				{
					num = -1826183858;
					num3 = num;
				}
				continue;
				IL_00a0:
				if (P_1 > 0)
				{
					num = -1826183859;
					num4 = num;
					continue;
				}
				goto IL_00ab;
				IL_0054:
				rXDbrbtyNWDCpRVSolUyjKvqIhp(P_1, P_3, P_0, P_2, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz.OhRlOZGftuFdhsJLJdBYcXflSzkM);
				int num5;
				if (qYMxEncGvudBCauPreXIXlxJBQK.useApproximateMatching)
				{
					num = -1826183864;
					num5 = num;
				}
				else
				{
					num = -1826183860;
					num5 = num;
				}
			}
			goto IL_0007;
			IL_00bf:
			if (P_0 > 0)
			{
				num = -1826183869;
				goto IL_000c;
			}
			goto IL_00ab;
			IL_00ab:
			num = -1826183860;
			num4 = num;
			goto IL_000c;
		}

		private void YzqMoBhvKRalBOYGHRNonNnPINV(List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1192420191;
				while (true)
				{
					switch (num ^ -1192420192)
					{
					case 6:
						break;
					case 2:
						num2++;
						num = -1192420188;
						continue;
					case 3:
						if (P_0[num2].inputManagerId == P_2)
						{
							P_0[num2].inputManagerId = -1;
							num = -1192420190;
							continue;
						}
						goto case 2;
					case 5:
					{
						int num4;
						if (P_0[num2] != null)
						{
							num = -1192420189;
							num4 = num;
						}
						else
						{
							num = -1192420190;
							num4 = num;
						}
						continue;
					}
					case 0:
					{
						int num3;
						if (num2 != P_1)
						{
							num = -1192420187;
							num3 = num;
						}
						else
						{
							num = -1192420190;
							num3 = num;
						}
						continue;
					}
					case 1:
						num2 = 0;
						num = -1192420188;
						continue;
					default:
						if (num2 >= count)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private bool WFsHpGVScPZlQaWKivTImrGOHRY(List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_0, int P_1)
		{
			int count = P_0.Count;
			int num = 0;
			while (true)
			{
				int num2 = 1715052848;
				while (true)
				{
					switch (num2 ^ 0x6639A133)
					{
					case 0:
						break;
					case 3:
						num2 = 1715052850;
						continue;
					case 2:
						if (P_0[num] != null && P_0[num].inputManagerId == P_1)
						{
							return false;
						}
						num++;
						num2 = 1715052850;
						continue;
					default:
						if (num >= count)
						{
							return true;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		private int IojKdiCykxLgoivdxmqNHsMNBtN(List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_0)
		{
			int num = 0;
			int num3 = default(int);
			bool flag = default(bool);
			int count = default(int);
			while (true)
			{
				int num2 = 1752306043;
				while (true)
				{
					switch (num2 ^ 0x6872117E)
					{
					case 2:
						break;
					case 3:
						if (P_0[num3] != null && P_0[num3].inputManagerId == num)
						{
							flag = true;
							num2 = 1752306046;
							continue;
						}
						goto case 6;
					case 0:
						if (!flag)
						{
							return num;
						}
						num++;
						num2 = 1752306042;
						continue;
					default:
						flag = false;
						count = P_0.Count;
						num3 = 0;
						num2 = 1752306041;
						continue;
					case 1:
					{
						int num4;
						if (num3 < count)
						{
							num2 = 1752306045;
							num4 = num2;
						}
						else
						{
							num2 = 1752306046;
							num4 = num2;
						}
						continue;
					}
					case 6:
						num3++;
						num2 = 1752306047;
						continue;
					case 7:
						num2 = 1752306047;
						continue;
					}
					break;
				}
			}
		}

		private bool QHMDmJGdAwPrsYvhnfrFmKuYnKq(List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_0, int P_1)
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
				if (num >= P_0.Count)
				{
					num2 = 1453926123;
					num3 = num2;
				}
				else
				{
					num2 = 1453926122;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x56A926EB)
					{
					case 2:
						num2 = 1453926122;
						continue;
					case 1:
						if (P_0[num].rewiredId == P_1)
						{
							return true;
						}
						num++;
						num2 = 1453926120;
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

		private void rXDbrbtyNWDCpRVSolUyjKvqIhp(int P_0, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_1, int P_2, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_3, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz P_4)
		{
			int num = ((P_4 != wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz.OhRlOZGftuFdhsJLJdBYcXflSzkM) ? 1 : 2);
			int num2 = 0;
			UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS2 = default(UjRCRJDfGfDpWwHlQMLAERgcbfBS);
			int num4 = default(int);
			while (num2 < P_0)
			{
				while (true)
				{
					UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS = P_1[num2];
					int num3 = -49780894;
					while (true)
					{
						switch (num3 ^ -49780895)
						{
						case 5:
							num3 = -49780896;
							continue;
						case 1:
							break;
						case 0:
							if (!QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, ujRCRJDfGfDpWwHlQMLAERgcbfBS2.rewiredId) && ujRCRJDfGfDpWwHlQMLAERgcbfBS.texDHprRVSCDIhdEcHxFsscbHjUA(ujRCRJDfGfDpWwHlQMLAERgcbfBS2) >= num)
							{
								ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId = ujRCRJDfGfDpWwHlQMLAERgcbfBS2.inputManagerId;
								ujRCRJDfGfDpWwHlQMLAERgcbfBS.rewiredId = ujRCRJDfGfDpWwHlQMLAERgcbfBS2.rewiredId;
								cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(ujRCRJDfGfDpWwHlQMLAERgcbfBS);
								num3 = -49780893;
								continue;
							}
							goto case 2;
						case 7:
							goto IL_00a3;
						case 4:
							num2++;
							num3 = -49780889;
							continue;
						case 3:
							if (ujRCRJDfGfDpWwHlQMLAERgcbfBS != null && ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId < 0)
							{
								num4 = 0;
								num3 = -49780890;
								continue;
							}
							goto case 4;
						case 2:
							num4++;
							num3 = -49780890;
							continue;
						case 8:
							goto IL_00ef;
						default:
							goto end_IL_0049;
						}
						break;
						IL_00ef:
						ujRCRJDfGfDpWwHlQMLAERgcbfBS2 = P_3[num4];
						int num5;
						if (ujRCRJDfGfDpWwHlQMLAERgcbfBS2 != null)
						{
							num3 = -49780895;
							num5 = num3;
						}
						else
						{
							num3 = -49780893;
							num5 = num3;
						}
						continue;
						IL_00a3:
						int num6;
						if (num4 < P_2)
						{
							num3 = -49780887;
							num6 = num3;
						}
						else
						{
							num3 = -49780891;
							num6 = num3;
						}
					}
					continue;
					end_IL_0049:
					break;
				}
			}
		}

		private void xtNfNMKFmfYIygncVYHsbFvnNoe(int P_0, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_1, wAWhqjaldjmIxyyWdhxUDJtLUbZs.YQdckKlKiygeWjVwgVlBlgICONlz P_2)
		{
			int num = 0;
			int num4 = default(int);
			wAWhqjaldjmIxyyWdhxUDJtLUbZs.igTmcrTqIovDncueXqUJhCyVKmB igTmcrTqIovDncueXqUJhCyVKmB = default(wAWhqjaldjmIxyyWdhxUDJtLUbZs.igTmcrTqIovDncueXqUJhCyVKmB);
			while (num < P_0)
			{
				while (true)
				{
					UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS = P_1[num];
					int num2;
					if (ujRCRJDfGfDpWwHlQMLAERgcbfBS != null)
					{
						int num3;
						if (ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId >= 0)
						{
							num2 = -1296665391;
							num3 = num2;
						}
						else
						{
							num2 = -1296665389;
							num3 = num2;
						}
						goto IL_000c;
					}
					goto IL_00e9;
					IL_000c:
					while (true)
					{
						switch (num2 ^ -1296665388)
						{
						case 0:
							num2 = -1296665386;
							continue;
						case 8:
							if (!WFsHpGVScPZlQaWKivTImrGOHRY(P_1, num4))
							{
								num4 = IojKdiCykxLgoivdxmqNHsMNBtN(P_1);
								num2 = -1296665392;
								continue;
							}
							goto case 1;
						case 7:
							igTmcrTqIovDncueXqUJhCyVKmB = cBQhEyiNFbRkGCtCdGNTEMPiFbh.lYJFZOeYSDYSWqqagvNTnOjxepl(ujRCRJDfGfDpWwHlQMLAERgcbfBS, P_2);
							if (igTmcrTqIovDncueXqUJhCyVKmB != null && !QHMDmJGdAwPrsYvhnfrFmKuYnKq(P_1, igTmcrTqIovDncueXqUJhCyVKmB.lJGmoPjWlZhCnfYmPrnrnNrpiFd))
							{
								num4 = igTmcrTqIovDncueXqUJhCyVKmB.hkuClqGgyrjaNFrDJJuCSthMWeZ;
								num2 = -1296665385;
								continue;
							}
							goto IL_00e9;
						case 1:
							ujRCRJDfGfDpWwHlQMLAERgcbfBS.inputManagerId = num4;
							ujRCRJDfGfDpWwHlQMLAERgcbfBS.rewiredId = igTmcrTqIovDncueXqUJhCyVKmB.lJGmoPjWlZhCnfYmPrnrnNrpiFd;
							cBQhEyiNFbRkGCtCdGNTEMPiFbh.CzcBIezjgBkIUujMOARHJgPbWVOP(ujRCRJDfGfDpWwHlQMLAERgcbfBS);
							num2 = -1296665391;
							continue;
						case 4:
							igTmcrTqIovDncueXqUJhCyVKmB.hkuClqGgyrjaNFrDJJuCSthMWeZ = num4;
							num2 = -1296665387;
							continue;
						case 2:
							break;
						case 5:
							goto IL_00e9;
						case 3:
							goto IL_00f7;
						default:
							goto end_IL_00c1;
						}
						break;
						IL_00f7:
						int num5;
						if (num4 >= 0)
						{
							num2 = -1296665380;
							num5 = num2;
						}
						else
						{
							num2 = -1296665391;
							num5 = num2;
						}
					}
					continue;
					IL_00e9:
					num++;
					num2 = -1296665390;
					goto IL_000c;
					continue;
					end_IL_00c1:
					break;
				}
			}
		}

		private void lMlcWXDhUZyoYToHgCauFZahHGiP()
		{
			CustomInputSource.Joystick[] array = qYMxEncGvudBCauPreXIXlxJBQK.DLWawRDhJxuKFmUZYwNxkUomlPWH();
			while (true)
			{
				int num = 1184800650;
				while (true)
				{
					switch (num ^ 0x469E9F88)
					{
					case 3:
						break;
					case 2:
					{
						int num2;
						if (!SeXECUiByzFeJnRsasbrYvFSefu(array))
						{
							num = 1184800648;
							num2 = num;
						}
						else
						{
							num = 1184800649;
							num2 = num;
						}
						continue;
					}
					case 1:
						pBKGiqCzbgfPGMFhRdFSwUDshjx(array);
						num = 1184800648;
						continue;
					default:
						oCfgXkGkSgDkbBQjCfrbIAyBZc = false;
						return;
					}
					break;
				}
			}
		}

		private bool SeXECUiByzFeJnRsasbrYvFSefu(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = jkFiqNnyAtbymFOLlvWZRfYeLku.Count;
			int num3 = default(int);
			int num5 = default(int);
			long? systemId2 = default(long?);
			bool flag2 = default(bool);
			long? systemId = default(long?);
			bool flag = default(bool);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num2 = 1642057780;
				while (true)
				{
					switch (num2 ^ 0x61DFD03D)
					{
					case 2:
						break;
					case 1:
						num3 = 0;
						num2 = 1642057782;
						continue;
					case 17:
						num2 = 1642057787;
						continue;
					case 4:
						num5 = 0;
						num2 = 1642057772;
						continue;
					case 13:
						if (jkFiqNnyAtbymFOLlvWZRfYeLku[num5] != null && systemId2 == jkFiqNnyAtbymFOLlvWZRfYeLku[num5].systemId)
						{
							flag2 = true;
							num2 = 1642057781;
							continue;
						}
						goto case 15;
					case 16:
						if (jkFiqNnyAtbymFOLlvWZRfYeLku[num3] != null)
						{
							systemId = jkFiqNnyAtbymFOLlvWZRfYeLku[num3].systemId;
							flag = false;
							num2 = 1642057779;
							continue;
						}
						goto IL_0227;
					case 12:
					{
						int num7;
						if (num4 >= num)
						{
							num2 = 1642057790;
							num7 = num2;
						}
						else
						{
							num2 = 1642057783;
							num7 = num2;
						}
						continue;
					}
					case 8:
						if (!flag2)
						{
							return true;
						}
						goto IL_0138;
					case 14:
						num4 = 0;
						num2 = 1642057777;
						continue;
					case 0:
						num4++;
						num2 = 1642057777;
						continue;
					case 9:
						if (num != count)
						{
							return true;
						}
						num6 = 0;
						num2 = 1642057784;
						continue;
					case 5:
					{
						int num9;
						if (num6 < num)
						{
							num2 = 1642057786;
							num9 = num2;
						}
						else
						{
							num2 = 1642057788;
							num9 = num2;
						}
						continue;
					}
					case 15:
						num5++;
						num2 = 1642057787;
						continue;
					case 6:
					{
						int num8;
						if (num5 < count)
						{
							num2 = 1642057776;
							num8 = num2;
						}
						else
						{
							num2 = 1642057781;
							num8 = num2;
						}
						continue;
					}
					case 7:
						if (P_0[num6] != null)
						{
							systemId2 = P_0[num6].systemId;
							flag2 = false;
							num2 = 1642057785;
							continue;
						}
						goto IL_0138;
					case 10:
						if (P_0[num4] != null && systemId == P_0[num4].systemId)
						{
							flag = true;
							num2 = 1642057790;
							continue;
						}
						goto case 0;
					case 3:
						if (!flag)
						{
							return true;
						}
						goto IL_0227;
					default:
						{
							if (num3 >= count)
							{
								return false;
							}
							goto case 16;
						}
						IL_0138:
						num6++;
						num2 = 1642057784;
						continue;
						IL_0227:
						num3++;
						num2 = 1642057782;
						continue;
					}
					break;
				}
			}
		}

		private void oQChKjbOquuMrWKdTwrmVgDaXkc(List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_0, List<UjRCRJDfGfDpWwHlQMLAERgcbfBS> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num4 = default(int);
			bool flag = default(bool);
			int num3 = default(int);
			int num5 = default(int);
			UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS2 = default(UjRCRJDfGfDpWwHlQMLAERgcbfBS);
			UjRCRJDfGfDpWwHlQMLAERgcbfBS ujRCRJDfGfDpWwHlQMLAERgcbfBS = default(UjRCRJDfGfDpWwHlQMLAERgcbfBS);
			while (true)
			{
				int num = ((P_0 != null) ? P_0.Count : 0);
				int num2 = -890470988;
				while (true)
				{
					switch (num2 ^ -890470980)
					{
					case 4:
						num2 = -890470986;
						continue;
					case 10:
						break;
					case 5:
					{
						int num7;
						if (P_1 == null)
						{
							num2 = -890470977;
							num7 = num2;
						}
						else
						{
							num2 = -890470990;
							num7 = num2;
						}
						continue;
					}
					case 14:
						num4 = 0;
						num2 = -890470980;
						continue;
					case 3:
						if (!flag)
						{
							OfeHsDDvEoLmeubGkgNtdbFKDqss(P_0[num3], P_2);
							num2 = -890470992;
							continue;
						}
						goto case 12;
					case 0:
					{
						int num6;
						if (num4 < num5)
						{
							num2 = -890470985;
							num6 = num2;
						}
						else
						{
							num2 = -890470977;
							num6 = num2;
						}
						continue;
					}
					case 13:
						flag = false;
						num2 = -890470983;
						continue;
					case 9:
						ujRCRJDfGfDpWwHlQMLAERgcbfBS2 = P_0[num3];
						num2 = -890470981;
						continue;
					case 7:
					{
						int num8;
						if (ujRCRJDfGfDpWwHlQMLAERgcbfBS2 != null)
						{
							num2 = -890470991;
							num8 = num2;
						}
						else
						{
							num2 = -890470992;
							num8 = num2;
						}
						continue;
					}
					case 6:
						if (ujRCRJDfGfDpWwHlQMLAERgcbfBS != null && ujRCRJDfGfDpWwHlQMLAERgcbfBS2.rewiredId == ujRCRJDfGfDpWwHlQMLAERgcbfBS.rewiredId)
						{
							flag = true;
							num2 = -890470977;
							continue;
						}
						goto case 1;
					case 12:
						num3++;
						num2 = -890470978;
						continue;
					case 8:
						num5 = ((P_1 != null) ? P_1.Count : 0);
						num3 = 0;
						num2 = -890470978;
						continue;
					case 11:
						ujRCRJDfGfDpWwHlQMLAERgcbfBS = P_1[num4];
						num2 = -890470982;
						continue;
					case 1:
						num4++;
						num2 = -890470980;
						continue;
					default:
						if (num3 >= num)
						{
							return;
						}
						goto case 9;
					}
					break;
				}
			}
		}

		private void OfeHsDDvEoLmeubGkgNtdbFKDqss(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.cQAaFptieRamqauyKZBxAdBkaurO();
			}
			tHJBoSBwnoRbdnuftpSDkmafzhV(P_0, P_1);
		}

		private void tHJBoSBwnoRbdnuftpSDkmafzhV(UjRCRJDfGfDpWwHlQMLAERgcbfBS P_0, bool P_1)
		{
			if (P_1)
			{
				goto IL_0003;
			}
			goto IL_0042;
			IL_0003:
			int num = -30010727;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -30010725)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					goto IL_0029;
				case 3:
					goto IL_0042;
				case 1:
					_DeviceConnectedEvent(P_0.ToBridgedController());
					return;
				case 0:
					return;
				}
				break;
				IL_0029:
				int num2;
				if (_DeviceConnectedEvent == null)
				{
					num = -30010725;
					num2 = num;
				}
				else
				{
					num = -30010726;
					num2 = num;
				}
			}
			goto IL_0003;
			IL_0042:
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
				num = -30010725;
				goto IL_0008;
			}
		}
	}
}
