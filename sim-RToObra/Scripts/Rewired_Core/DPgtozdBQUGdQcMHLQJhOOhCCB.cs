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

internal class DPgtozdBQUGdQcMHLQJhOOhCCB : PlatformInputManager
{
	private class rvEtmlHRdCcipcmARRdpCrWqxsM : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int TcKoYfigmhWFfimOKaOKeTOPnAQ;

		private int QovxBPKLdqHelKEcdGLoDhrEJtsP;

		private int YAsnSUHUHZSXPqVPdYXTHFQokii;

		public Guid ReLSneGtMGimyQaICDlebjstllEH;

		public string oJQguCtPmjqScMAmVURNLbjxBsy;

		public int FDxfKNBiipHZgwkKUPegefKbjZpG;

		public string HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;

		private int TwhUkSEboxGPsJgqbpmupSCMcvva = 29;

		private int SgYwVaEgtCZiUkgVDcTwJWbyDTtb = 20;

		private float[] TEOYPaJNdnEWbgWRoihqYehIhMK;

		private bool[] pcgUSJiXRsTNqMrGSyukNhNuJeO;

		private bool[] NzFpIqxNyEyEQhNMbtdAGihZRWr;

		private float[] OiJQDfANXoXeMiVATHdbLOvhihv;

		private bool[] jcqPhReRRKLHMgCkYHVTGnEaWcd;

		private HardwareJoystickMap_InputManager RCNejcvnZtMAmgendVbiwgNYmdD;

		private bool BvBiBtBhorGlOOqcvDhVgnidONSn;

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
				if (!(oJQguCtPmjqScMAmVURNLbjxBsy != "Unknown Controller"))
				{
					return HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
				}
				return oJQguCtPmjqScMAmVURNLbjxBsy;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (YAsnSUHUHZSXPqVPdYXTHFQokii < 1)
				{
					return null;
				}
				return YAsnSUHUHZSXPqVPdYXTHFQokii;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return YAsnSUHUHZSXPqVPdYXTHFQokii;
			}
			set
			{
				YAsnSUHUHZSXPqVPdYXTHFQokii = value;
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
				int num = -1980859538;
				goto IL_0013;
				IL_0013:
				switch (num ^ -1980859537)
				{
				case 0:
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
					num = -1980859539;
					goto IL_0013;
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + YAsnSUHUHZSXPqVPdYXTHFQokii);
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

		public rvEtmlHRdCcipcmARRdpCrWqxsM()
		{
			QovxBPKLdqHelKEcdGLoDhrEJtsP = -1;
			TcKoYfigmhWFfimOKaOKeTOPnAQ = -1;
			YAsnSUHUHZSXPqVPdYXTHFQokii = 0;
		}

		public void sbcTSexDWKGUOKrMGnEajLgRvts()
		{
			TiLfIVyvvCkOyWkDMxfDMSbgDnI();
			while (true)
			{
				int num = -750424602;
				while (true)
				{
					switch (num ^ -750424604)
					{
					case 3:
						break;
					case 2:
						ReLSneGtMGimyQaICDlebjstllEH = RCNejcvnZtMAmgendVbiwgNYmdD.hardwareMapIdentifier.guid;
						oJQguCtPmjqScMAmVURNLbjxBsy = RCNejcvnZtMAmgendVbiwgNYmdD.controllerName;
						num = -750424603;
						continue;
					case 1:
						TEOYPaJNdnEWbgWRoihqYehIhMK = new float[TwhUkSEboxGPsJgqbpmupSCMcvva];
						num = -750424604;
						continue;
					default:
						pcgUSJiXRsTNqMrGSyukNhNuJeO = new bool[SgYwVaEgtCZiUkgVDcTwJWbyDTtb];
						NzFpIqxNyEyEQhNMbtdAGihZRWr = new bool[TwhUkSEboxGPsJgqbpmupSCMcvva];
						jcqPhReRRKLHMgCkYHVTGnEaWcd = new bool[29];
						OiJQDfANXoXeMiVATHdbLOvhihv = new float[29];
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
			if (YAsnSUHUHZSXPqVPdYXTHFQokii <= 0)
			{
				return;
			}
			while (true)
			{
				emvgYHQwVLMGEBipMqhlumkzhhx();
				ACWFShdsqMXYShMhIOVlhqSySfj();
				bWqXMuWKIQJCfsxGeWCQkichWXy();
				int num = 1056985232;
				while (true)
				{
					switch (num ^ 0x3F005091)
					{
					case 0:
						goto IL_000a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000a:
					num = 1056985235;
				}
			}
		}

		public int CGvNMgTtJKByfBoLCudPLkyvgkV(rvEtmlHRdCcipcmARRdpCrWqxsM P_0)
		{
			if (P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ == HIvDSEfHmYLXCZgFzgQfmcgNYIFJ && P_0.FDxfKNBiipHZgwkKUPegefKbjZpG == FDxfKNBiipHZgwkKUPegefKbjZpG)
			{
				return 2;
			}
			if (P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ == HIvDSEfHmYLXCZgFzgQfmcgNYIFJ)
			{
				return 1;
			}
			return 0;
		}

		private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = XOOElcaUSyqtayLtlARuHPnUDYlh();
			P_0.hardwareIdentifier = ZrEWBQNwcFIqvIYkQITbufsXcXR();
			while (true)
			{
				int num = -1416174712;
				while (true)
				{
					switch (num ^ -1416174711)
					{
					case 0:
						break;
					case 1:
						P_0.hardwareAxisCount = 0;
						num = -1416174710;
						continue;
					case 3:
						P_0.hardwareButtonCount = 0;
						num = -1416174709;
						continue;
					default:
						P_0.hardwareHatCount = 0;
						P_0.hw_productName = HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
						return;
					}
					break;
				}
			}
		}

		private void azaIOTDxGZMNUjlkOgiJDaxzXhfj(BridgedController P_0)
		{
			azaIOTDxGZMNUjlkOgiJDaxzXhfj((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			while (true)
			{
				int num = 1838804062;
				while (true)
				{
					switch (num ^ 0x6D99EC5F)
					{
					case 4:
						break;
					case 1:
						P_0.gameHardwareMap = RCNejcvnZtMAmgendVbiwgNYmdD.ToGameHardwareControllerMap();
						P_0.instanceName = HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
						num = 1838804058;
						continue;
					case 5:
						P_0.productName = HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
						num = 1838804063;
						continue;
					case 3:
						P_0.buttonCount = SgYwVaEgtCZiUkgVDcTwJWbyDTtb;
						num = 1838804061;
						continue;
					case 0:
						P_0.isXInputDevice = false;
						P_0.axisCount = TwhUkSEboxGPsJgqbpmupSCMcvva;
						num = 1838804060;
						continue;
					default:
						P_0.controllerTypeGuid = ReLSneGtMGimyQaICDlebjstllEH;
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (TwhUkSEboxGPsJgqbpmupSCMcvva == dataUpdater.axisCount)
			{
				int num3 = default(int);
				int num2 = default(int);
				float[] axisValues = default(float[]);
				bool[] axisHasBeenPressedOSXLinux = default(bool[]);
				bool[] buttonValues = default(bool[]);
				while (true)
				{
					int num = 1071656617;
					while (true)
					{
						switch (num ^ 0x3FE02EA1)
						{
						case 0:
							break;
						default:
							return;
						case 12:
							if (BvBiBtBhorGlOOqcvDhVgnidONSn && !dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = 1071656608;
								continue;
							}
							return;
						case 2:
							num3 = 0;
							num = 1071656614;
							continue;
						case 5:
							goto IL_0087;
						case 11:
							num3++;
							num = 1071656614;
							continue;
						case 3:
							num2++;
							num = 1071656612;
							continue;
						case 4:
							if (axisValues[num3] != TEOYPaJNdnEWbgWRoihqYehIhMK[num3])
							{
								axisValues[num3] = TEOYPaJNdnEWbgWRoihqYehIhMK[num3];
								if (axisHasBeenPressedOSXLinux[num3] != NzFpIqxNyEyEQhNMbtdAGihZRWr[num3])
								{
									axisHasBeenPressedOSXLinux[num3] = NzFpIqxNyEyEQhNMbtdAGihZRWr[num3];
									num = 1071656618;
									continue;
								}
							}
							goto case 11;
						case 8:
							goto IL_00fd;
						case 10:
							axisValues = dataUpdater.axisValues;
							axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
							num = 1071656611;
							continue;
						case 9:
							goto end_IL_0011;
						case 7:
							if (num3 >= TwhUkSEboxGPsJgqbpmupSCMcvva)
							{
								buttonValues = dataUpdater.buttonValues;
								num2 = 0;
								num = 1071656612;
								continue;
							}
							goto case 4;
						case 6:
							if (buttonValues[num2] != pcgUSJiXRsTNqMrGSyukNhNuJeO[num2])
							{
								buttonValues[num2] = pcgUSJiXRsTNqMrGSyukNhNuJeO[num2];
								num = 1071656610;
								continue;
							}
							goto case 3;
						case 1:
							return;
						}
						break;
						IL_00fd:
						int num4;
						if (SgYwVaEgtCZiUkgVDcTwJWbyDTtb == dataUpdater.buttonCount)
						{
							num = 1071656619;
							num4 = num;
						}
						else
						{
							num = 1071656616;
							num4 = num;
						}
						continue;
						IL_0087:
						int num5;
						if (num2 >= SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
						{
							num = 1071656621;
							num5 = num;
						}
						else
						{
							num = 1071656615;
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

		public void jvrkDyTBNzBMlibzXFhmiiedfaBH(int P_0)
		{
			if (P_0 >= 1)
			{
				if (P_0 > 11)
				{
					goto IL_0009;
				}
				goto IL_0033;
			}
			return;
			IL_0033:
			unityId = P_0;
			int num = -856132833;
			goto IL_000e;
			IL_0009:
			num = -856132835;
			goto IL_000e;
			IL_000e:
			switch (num ^ -856132836)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0033;
			case 3:
				return;
			}
			goto IL_0009;
		}

		public void AqaErtHnQpGUqupVaRoxdDokZWa()
		{
			YAsnSUHUHZSXPqVPdYXTHFQokii = 0;
			while (true)
			{
				int num = -1923898836;
				while (true)
				{
					switch (num ^ -1923898835)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 0:
						return;
					}
					break;
					IL_0025:
					tqYfRtthDdSgVRZMoVLzrZSSLul();
					num = -1923898835;
				}
			}
		}

		public BridgedControllerHWInfo JBMvgOBJziXYPUQkaqihlBPPMXw()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			azaIOTDxGZMNUjlkOgiJDaxzXhfj(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
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

		private void emvgYHQwVLMGEBipMqhlumkzhhx()
		{
			int num = 0;
			float joystickAxisValueByJoystickId = default(float);
			while (true)
			{
				int num2 = -324602620;
				while (true)
				{
					switch (num2 ^ -324602618)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						num2 = -324602617;
						continue;
					case 6:
					{
						joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(YAsnSUHUHZSXPqVPdYXTHFQokii, num);
						int num4;
						if (OiJQDfANXoXeMiVATHdbLOvhihv[num] != joystickAxisValueByJoystickId)
						{
							num2 = -324602619;
							num4 = num2;
						}
						else
						{
							num2 = -324602621;
							num4 = num2;
						}
						continue;
					}
					case 3:
						OiJQDfANXoXeMiVATHdbLOvhihv[num] = joystickAxisValueByJoystickId;
						if (!jcqPhReRRKLHMgCkYHVTGnEaWcd[num] && joystickAxisValueByJoystickId != 0f)
						{
							jcqPhReRRKLHMgCkYHVTGnEaWcd[num] = true;
							num2 = -324602621;
							continue;
						}
						goto case 5;
					case 5:
						num++;
						num2 = -324602617;
						continue;
					case 1:
					{
						int num3;
						if (num < 29)
						{
							num2 = -324602624;
							num3 = num2;
						}
						else
						{
							num2 = -324602622;
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

		private void ACWFShdsqMXYShMhIOVlhqSySfj()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)RCNejcvnZtMAmgendVbiwgNYmdD.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			float num3 = default(float);
			while (true)
			{
				int num = 0;
				int num2 = 1491543923;
				while (true)
				{
					switch (num2 ^ 0x58E72778)
					{
					case 8:
						num2 = 1491543930;
						continue;
					case 5:
						throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
					case 3:
						num++;
						num2 = 1491543923;
						continue;
					case 4:
						NzFpIqxNyEyEQhNMbtdAGihZRWr[num] = true;
						num2 = 1491543935;
						continue;
					case 7:
						if (!BvBiBtBhorGlOOqcvDhVgnidONSn)
						{
							int num6;
							if (TEOYPaJNdnEWbgWRoihqYehIhMK[num] != 0f)
							{
								num2 = 1491543934;
								num6 = num2;
							}
							else
							{
								num2 = 1491543931;
								num6 = num2;
							}
							continue;
						}
						goto case 3;
					case 9:
						if (axes_orig[num] != null)
						{
							int num7;
							if (num >= TwhUkSEboxGPsJgqbpmupSCMcvva)
							{
								num2 = 1491543933;
								num7 = num2;
							}
							else
							{
								num2 = 1491543928;
								num7 = num2;
							}
							continue;
						}
						goto case 3;
					case 6:
						BvBiBtBhorGlOOqcvDhVgnidONSn = true;
						num2 = 1491543931;
						continue;
					case 10:
						NzFpIqxNyEyEQhNMbtdAGihZRWr[num] = num3 != 0f;
						num2 = 1491543935;
						continue;
					case 0:
					{
						float num4 = MZBONfLuZbixRkBmJqUhwMoksCq(axes_orig[num]);
						if (TEOYPaJNdnEWbgWRoihqYehIhMK[num] != num4)
						{
							TEOYPaJNdnEWbgWRoihqYehIhMK[num] = num4;
							int num5;
							if (!NzFpIqxNyEyEQhNMbtdAGihZRWr[num])
							{
								num2 = 1491543929;
								num5 = num2;
							}
							else
							{
								num2 = 1491543935;
								num5 = num2;
							}
							continue;
						}
						goto case 3;
					}
					case 2:
						break;
					case 1:
						if (axes_orig[num].sourceType == HardwareElementSourceTypeWithHat.Axis)
						{
							num3 = MZBONfLuZbixRkBmJqUhwMoksCq(axes_orig[num].sourceAxis);
							num2 = 1491543922;
							continue;
						}
						goto case 4;
					default:
						if (num >= axes_orig.Length)
						{
							return;
						}
						goto case 9;
					}
					break;
				}
			}
		}

		private void bWqXMuWKIQJCfsxGeWCQkichWXy()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)RCNejcvnZtMAmgendVbiwgNYmdD.map).Buttons_orig;
			int num2 = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num = -264787155;
				while (true)
				{
					switch (num ^ -264787164)
					{
					case 6:
						break;
					default:
						return;
					case 9:
					{
						int num6;
						if (buttons_orig == null)
						{
							num = -264787168;
							num6 = num;
						}
						else
						{
							num = -264787154;
							num6 = num;
						}
						continue;
					}
					case 10:
						num2 = 0;
						num = -264787153;
						continue;
					case 2:
						if (pcgUSJiXRsTNqMrGSyukNhNuJeO[num2])
						{
							BvBiBtBhorGlOOqcvDhVgnidONSn = true;
							num = -264787163;
							continue;
						}
						goto case 1;
					case 4:
						return;
					case 11:
					{
						int num4;
						if (num2 >= buttons_orig.Length)
						{
							num = -264787161;
							num4 = num;
						}
						else
						{
							num = -264787156;
							num4 = num;
						}
						continue;
					}
					case 5:
						flag = uzIVkYjEcCOqJgyQjMKkDXWAHmv(buttons_orig[num2]);
						num = -264787164;
						continue;
					case 7:
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					case 1:
						num2++;
						num = -264787153;
						continue;
					case 0:
						if (pcgUSJiXRsTNqMrGSyukNhNuJeO[num2] != flag)
						{
							pcgUSJiXRsTNqMrGSyukNhNuJeO[num2] = flag;
							int num5;
							if (BvBiBtBhorGlOOqcvDhVgnidONSn)
							{
								num = -264787163;
								num5 = num;
							}
							else
							{
								num = -264787162;
								num5 = num;
							}
							continue;
						}
						goto case 1;
					case 8:
					{
						int num3;
						if (num2 < SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
						{
							num = -264787167;
							num3 = num;
						}
						else
						{
							num = -264787165;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		private bool uzIVkYjEcCOqJgyQjMKkDXWAHmv(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (!P_0.ignoreIfButtonsActive)
				{
					goto IL_00ba;
				}
				num = 0;
				goto IL_0108;
			}
			int num2;
			float num3 = default(float);
			float num4 = default(float);
			bool flag = default(bool);
			float num5 = default(float);
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					if (P_0.unityHat_sourceAxis1 == UnityAxis.None)
					{
						goto IL_03c7;
					}
					if (P_0.unityHat_sourceAxis2 == UnityAxis.None)
					{
						num2 = -1927009824;
					}
					else
					{
						UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
						UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
						num3 = MZBONfLuZbixRkBmJqUhwMoksCq(unityHat_sourceAxis);
						num4 = MZBONfLuZbixRkBmJqUhwMoksCq(unityHat_sourceAxis2);
						if (!P_0.unityHat_checkNeverPressed)
						{
							goto IL_0219;
						}
						flag = pmmPnfazoOanLpzTJPDRppNcfYvG(unityHat_sourceAxis) || pmmPnfazoOanLpzTJPDRppNcfYvG(unityHat_sourceAxis2);
						num2 = -1927009854;
					}
				}
				else
				{
					if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
					{
						if (P_0.sourceKeyCode == KeyCode.None)
						{
							return false;
						}
						return Input.GetKey(P_0.sourceKeyCode);
					}
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						goto IL_05ad;
					}
					num2 = -1927009855;
				}
			}
			else
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				num5 = MZBONfLuZbixRkBmJqUhwMoksCq(P_0.sourceAxis);
				num2 = -1927009835;
			}
			goto IL_0022;
			IL_0219:
			float x = P_0.unityHat_zeroValues.x;
			float y = P_0.unityHat_zeroValues.y;
			num2 = -1927009830;
			goto IL_0022;
			IL_00ba:
			if (P_0.requireMultipleButtons)
			{
				num2 = -1927009850;
				goto IL_0022;
			}
			if (P_0.sourceButton == UnityButton.None)
			{
				return false;
			}
			return uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.sourceButton);
			IL_0108:
			int num6;
			if (num >= P_0.ignoreIfButtonsActiveButtons.Length)
			{
				num2 = -1927009831;
				num6 = num2;
			}
			else
			{
				num2 = -1927009842;
				num6 = num2;
			}
			goto IL_0022;
			IL_0022:
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			int num7 = default(int);
			CustomCalculation customCalculation = default(CustomCalculation);
			int num8 = default(int);
			bool flag4 = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				float num9;
				switch (num2 ^ -1927009855)
				{
				case 12:
					num2 = -1927009842;
					continue;
				case 24:
					break;
				case 20:
					goto IL_00cf;
				case 9:
					return false;
				case 5:
					num2 = -1927009834;
					continue;
				case 10:
					goto IL_0108;
				case 15:
					goto IL_0127;
				case 13:
					return false;
				case 17:
					goto IL_0155;
				case 27:
					goto IL_016f;
				case 32:
					goto IL_0219;
				case 6:
				{
					bool flag3;
					if (jhVhzcNAIzJgGVkFPboBmLvBFmTK(customCalculationSourceData[num7], out flag3))
					{
						customCalculation.AddData(flag3 ? 1f : 0f);
						num2 = -1927009834;
						continue;
					}
					goto IL_0473;
				}
				case 1:
					x = P_0.unityHat_zeroValues.x;
					y = P_0.unityHat_zeroValues.y;
					num2 = -1927009830;
					continue;
				case 21:
					num8++;
					num2 = -1927009851;
					continue;
				case 4:
					goto IL_02a2;
				case 29:
					goto IL_02c1;
				case 18:
					x = P_0.unityHat_neverPressedZeroValues.x;
					y = P_0.unityHat_neverPressedZeroValues.y;
					num2 = -1927009830;
					continue;
				case 7:
					flag4 = false;
					num8 = 0;
					num2 = -1927009851;
					continue;
				case 22:
					goto IL_0306;
				case 25:
					goto IL_033e;
				case 31:
					return false;
				case 16:
					goto IL_038b;
				case 0:
					goto IL_039b;
				case 33:
					goto IL_03c7;
				case 8:
					return true;
				case 3:
					goto IL_0451;
				case 28:
					num2 = -1927009834;
					continue;
				case 23:
					goto IL_0473;
				case 2:
					customCalculation.AddData(flag2 ? 1f : 0f);
					num2 = -1927009852;
					continue;
				case 26:
					return false;
				case 11:
					goto IL_04c6;
				case 14:
					return true;
				case 19:
					if (customCalculationSourceData[num7] != null)
					{
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[num7].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Key:
							break;
						case HardwareElementSourceTypeWithHat.Axis:
							goto IL_033e;
						case HardwareElementSourceTypeWithHat.Hat:
							goto IL_0473;
						case HardwareElementSourceTypeWithHat.Button:
							goto IL_04c6;
						default:
							goto IL_0562;
						}
						goto case 6;
					}
					goto IL_0473;
				default:
					{
						if (num7 < customCalculationSourceData.Length)
						{
							goto case 19;
						}
						goto IL_0574;
					}
					IL_0562:
					num2 = -1927009827;
					continue;
					IL_033e:
					if (WJMfHKgAHjyqDPrpYCNQhlxEvvrt(customCalculationSourceData[num7], out num9))
					{
						customCalculation.AddData((num9 != 0f) ? 1f : 0f);
						num2 = -1927009834;
						continue;
					}
					goto IL_0473;
					IL_0473:
					num7++;
					num2 = -1927009825;
					continue;
				}
				break;
				IL_04c6:
				int num10;
				if (!fSNHVJrEcFiyXXXZlDwJPFwhuYS(customCalculationSourceData[num7], out flag2))
				{
					num2 = -1927009834;
					num10 = num2;
				}
				else
				{
					num2 = -1927009853;
					num10 = num2;
				}
				continue;
				IL_0310:
				return true;
				IL_0127:
				if (uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.ignoreIfButtonsActiveButtons[num]))
				{
					return false;
				}
				num++;
				num2 = -1927009845;
				continue;
				IL_0451:
				int num11;
				if (!flag)
				{
					num2 = -1927009837;
					num11 = num2;
				}
				else
				{
					num2 = -1927009856;
					num11 = num2;
				}
				continue;
				IL_0306:
				if (num5 > 0f)
				{
					return false;
				}
				goto IL_0310;
				IL_016f:
				if (MathTools.Approximately(num3, x) && MathTools.Approximately(num4, y))
				{
					return false;
				}
				if (PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues1.x, num3) && PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues1.y, num4))
				{
					return true;
				}
				if (PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues2.x, num3) && PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues2.y, num4))
				{
					return true;
				}
				if (PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues3.x, num3) && PnGKCgddUhiShSiKoDLSOjCdKDO(P_0.unityHat_isActiveAxisValues3.y, num4))
				{
					num2 = -1927009847;
					continue;
				}
				goto IL_05ad;
				IL_039b:
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType == TypeWrapper.DataType.Single)
				{
					customCalculationSourceData = P_0.customCalculationSourceData;
					num2 = -1927009828;
				}
				else
				{
					num2 = -1927009848;
				}
				continue;
				IL_02c1:
				if (customCalculationSourceData == null)
				{
					return false;
				}
				num7 = 0;
				num2 = -1927009825;
				continue;
				IL_00cf:
				if (MathTools.Abs(num5) <= P_0.axisDeadZone)
				{
					num2 = -1927009829;
					continue;
				}
				if (P_0.sourceAxisPole != Pole.Positive || !(num5 < 0f))
				{
					if (P_0.sourceAxisPole == Pole.Negative)
					{
						num2 = -1927009833;
						continue;
					}
					goto IL_0310;
				}
				num2 = -1927009826;
				continue;
				IL_0155:
				if (uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.requiredButtons[num8]))
				{
					flag4 = true;
					num2 = -1927009836;
				}
				else
				{
					num2 = -1927009844;
				}
				continue;
				IL_02a2:
				int num12;
				if (num8 < P_0.requiredButtons.Length)
				{
					num2 = -1927009840;
					num12 = num2;
				}
				else
				{
					num2 = -1927009839;
					num12 = num2;
				}
				continue;
				IL_038b:
				if (flag4)
				{
					num2 = -1927009841;
					continue;
				}
				return false;
			}
			goto IL_00ba;
			IL_03c7:
			return false;
			IL_0574:
			if (!customCalculation.Process())
			{
				return false;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return false;
			}
			return (float)customCalculation.Result != 0f;
			IL_05ad:
			return false;
		}

		private bool PnGKCgddUhiShSiKoDLSOjCdKDO(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float MZBONfLuZbixRkBmJqUhwMoksCq(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			HardwareElementSourceTypeWithHat sourceType = P_0.sourceType;
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
			int num;
			float result3 = default(float);
			bool flag = default(bool);
			int num2 = default(int);
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat2 = default(HardwareElementSourceTypeWithHat);
			float result2 = default(float);
			CustomCalculation customCalculation = default(CustomCalculation);
			float result = default(float);
			switch (hardwareElementSourceTypeWithHat)
			{
			default:
				num = 662917679;
				goto IL_0026;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode != KeyCode.None)
				{
					if (!Input.GetKey(P_0.sourceKeyCode))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution != Pole.Positive)
					{
						goto IL_00b8;
					}
					result3 = 1f;
					num = 662917678;
				}
				else
				{
					num = 662917690;
				}
				goto IL_0026;
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				flag = uzIVkYjEcCOqJgyQjMKkDXWAHmv(P_0.sourceButton);
				num = 662917693;
				goto IL_0026;
			case HardwareElementSourceTypeWithHat.Axis:
				goto IL_0231;
			case HardwareElementSourceTypeWithHat.Hat:
				break;
				IL_0026:
				while (true)
				{
					switch (num ^ 0x2783523F)
					{
					case 15:
						break;
					case 5:
						return 0f;
					case 13:
						goto IL_00b8;
					case 8:
						if (num2 >= customCalculationSourceData.Length)
						{
							goto IL_00d1;
						}
						goto case 10;
					case 16:
						goto IL_00eb;
					case 10:
						if (customCalculationSourceData[num2] != null)
						{
							HardwareElementSourceTypeWithHat sourceType2 = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num2].sourceType;
							hardwareElementSourceTypeWithHat2 = sourceType2;
							num = 662917684;
							continue;
						}
						goto case 4;
					case 1:
						return result3;
					case 12:
						return result2;
					case 4:
						num2++;
						num = 662917687;
						continue;
					case 2:
						goto IL_0176;
					case 11:
					{
						float item;
						if (hardwareElementSourceTypeWithHat2 == HardwareElementSourceTypeWithHat.Axis && WJMfHKgAHjyqDPrpYCNQhlxEvvrt(customCalculationSourceData[num2], out item))
						{
							customCalculation.AddData(item);
							num = 662917691;
							continue;
						}
						goto case 4;
					}
					case 0:
						return 0f;
					case 17:
						num = 662917694;
						continue;
					case 3:
						goto IL_01fa;
					case 6:
						return result;
					case 9:
						goto IL_0231;
					case 7:
						return 0f;
					default:
						return 0f;
					case 14:
						goto end_IL_000c;
					}
					break;
					IL_0176:
					if (!flag)
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						result2 = 1f;
						num = 662917683;
						continue;
					}
					goto IL_01fa;
					IL_00eb:
					if (hardwareElementSourceTypeWithHat != HardwareElementSourceTypeWithHat.Custom)
					{
						num = 662917681;
						continue;
					}
					customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return 0f;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						num = 662917688;
						continue;
					}
					customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					num2 = 0;
					num = 662917687;
					continue;
					IL_00d1:
					if (!customCalculation.Process())
					{
						num = 662917695;
						continue;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						num = 662917677;
						continue;
					}
					return customCalculation.Result;
					IL_01fa:
					result2 = -1f;
					num = 662917683;
				}
				goto default;
				IL_0231:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!pmmPnfazoOanLpzTJPDRppNcfYvG(P_0.sourceAxis))
				{
					return 0f;
				}
				result = MZBONfLuZbixRkBmJqUhwMoksCq(P_0.sourceAxis);
				num = 662917689;
				goto IL_0026;
				IL_00b8:
				result3 = -1f;
				num = 662917694;
				goto IL_0026;
				end_IL_000c:
				break;
			}
			return 0f;
		}

		private float MZBONfLuZbixRkBmJqUhwMoksCq(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return OiJQDfANXoXeMiVATHdbLOvhihv[num];
		}

		private bool uzIVkYjEcCOqJgyQjMKkDXWAHmv(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(YAsnSUHUHZSXPqVPdYXTHFQokii, buttonIndex);
		}

		private bool fSNHVJrEcFiyXXXZlDwJPFwhuYS(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 0)
			{
				goto IL_000b;
			}
			UnityButton sourceElement = (UnityButton)P_0.sourceElement;
			int num = -1874997816;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1874997816)
				{
				case 2:
					break;
				case 4:
					return false;
				case 0:
					if (sourceElement == UnityButton.None)
					{
						num = -1874997813;
						continue;
					}
					P_1 = uzIVkYjEcCOqJgyQjMKkDXWAHmv(sourceElement);
					num = -1874997815;
					continue;
				case 3:
					return false;
				default:
					return true;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num = -1874997812;
			goto IL_0010;
		}

		private bool jhVhzcNAIzJgGVkFPboBmLvBFmTK(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			while (true)
			{
				int num = -445976024;
				while (true)
				{
					switch (num ^ -445976023)
					{
					case 2:
						break;
					case 1:
					{
						if (P_0.sourceType != 3)
						{
							goto IL_002a;
						}
						KeyCode sourceElement = (KeyCode)P_0.sourceElement;
						if (sourceElement == KeyCode.None)
						{
							return false;
						}
						P_1 = Input.GetKey(sourceElement);
						return true;
					}
					default:
						return false;
					}
					break;
					IL_002a:
					num = -445976023;
				}
			}
		}

		private bool WJMfHKgAHjyqDPrpYCNQhlxEvvrt(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				goto IL_0013;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			int num;
			if (sourceElement == UnityAxis.None)
			{
				num = -317801931;
			}
			else
			{
				P_1 = MZBONfLuZbixRkBmJqUhwMoksCq(sourceElement);
				num = -317801933;
			}
			goto IL_0018;
			IL_0013:
			num = -317801935;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -317801936)
				{
				case 0:
					break;
				case 7:
					if (P_1 > 0f)
					{
						P_1 = 0f;
						num = -317801932;
						continue;
					}
					goto case 4;
				case 6:
					if (P_0.invert)
					{
						P_1 *= -1f;
						num = -317801934;
						continue;
					}
					goto default;
				case 4:
					if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
					{
						P_1 = 0f;
						num = -317801930;
						continue;
					}
					goto case 6;
				case 3:
					switch (P_0.sourceAxisRange)
					{
					case AxisRange.Negative:
						break;
					default:
						goto IL_00c3;
					case AxisRange.Positive:
						goto IL_00e3;
					}
					goto case 7;
				case 1:
					return false;
				case 8:
					goto IL_00e3;
				case 5:
					return false;
				default:
					{
						return true;
					}
					IL_00e3:
					if (P_1 < 0f)
					{
						P_1 = 0f;
						num = -317801932;
						continue;
					}
					goto case 4;
					IL_00c3:
					num = -317801932;
					continue;
				}
				break;
			}
			goto IL_0013;
		}

		private bool pmmPnfazoOanLpzTJPDRppNcfYvG(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return jcqPhReRRKLHMgCkYHVTGnEaWcd[num];
		}

		private void TiLfIVyvvCkOyWkDMxfDMSbgDnI()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = JBMvgOBJziXYPUQkaqihlBPPMXw();
			if (!UnityTools.isAndroidPlatform || !Regex.IsMatch(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ, "Xbox Wireless Controller.*"))
			{
				goto IL_007a;
			}
			List<int> vids = default(List<int>);
			List<int> pids = default(List<int>);
			UnityTools.externalTools.GetDeviceVIDPIDs(out vids, out pids);
			int num = 0;
			goto IL_0137;
			IL_003a:
			int num2;
			while (true)
			{
				switch (num2 ^ -1219821981)
				{
				case 9:
					num2 = -1219821982;
					continue;
				default:
					return;
				case 10:
					break;
				case 3:
					num2 = -1219821975;
					continue;
				case 5:
					goto IL_00a7;
				case 2:
					goto IL_00c2;
				case 7:
					TwhUkSEboxGPsJgqbpmupSCMcvva = RCNejcvnZtMAmgendVbiwgNYmdD.axisCount;
					num2 = -1219821973;
					continue;
				case 11:
					goto IL_0137;
				case 0:
					if (RCNejcvnZtMAmgendVbiwgNYmdD.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
					{
						string text = WmCvOHpqwsboAQVBAYxTsjTDauh(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ);
						if (!string.IsNullOrEmpty(text))
						{
							RCNejcvnZtMAmgendVbiwgNYmdD.controllerName = text;
							num2 = -1219821980;
							continue;
						}
					}
					goto case 7;
				case 8:
					SgYwVaEgtCZiUkgVDcTwJWbyDTtb = RCNejcvnZtMAmgendVbiwgNYmdD.buttonCount;
					num2 = -1219821979;
					continue;
				case 4:
					num++;
					num2 = -1219821976;
					continue;
				case 1:
					if (vids[num] == 1118 && pids[num] == 736)
					{
						bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
						num2 = -1219821984;
						continue;
					}
					goto case 4;
				case 6:
					return;
				}
				break;
			}
			goto IL_007a;
			IL_00c2:
			if (RCNejcvnZtMAmgendVbiwgNYmdD.useSystemName && !string.IsNullOrEmpty(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ))
			{
				string text2 = Regex.Replace(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					RCNejcvnZtMAmgendVbiwgNYmdD.controllerName = text2;
					num2 = -1219821978;
					goto IL_003a;
				}
			}
			goto IL_00a7;
			IL_0137:
			int num3;
			if (num < vids.Count)
			{
				num2 = -1219821982;
				num3 = num2;
			}
			else
			{
				num2 = -1219821975;
				num3 = num2;
			}
			goto IL_003a;
			IL_007a:
			RCNejcvnZtMAmgendVbiwgNYmdD = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (RCNejcvnZtMAmgendVbiwgNYmdD == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			goto IL_00c2;
			IL_00a7:
			int num4;
			if (!UnityTools.isIOSPlatform)
			{
				num2 = -1219821980;
				num4 = num2;
			}
			else
			{
				num2 = -1219821981;
				num4 = num2;
			}
			goto IL_003a;
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
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), ReInput.webplayerPlatform.ToString(), XOOElcaUSyqtayLtlARuHPnUDYlh().ToString(), HIvDSEfHmYLXCZgFzgQfmcgNYIFJ));
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), XOOElcaUSyqtayLtlARuHPnUDYlh().ToString(), arg));
			}
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), XOOElcaUSyqtayLtlARuHPnUDYlh().ToString(), HIvDSEfHmYLXCZgFzgQfmcgNYIFJ));
		}

		private InputSource XOOElcaUSyqtayLtlARuHPnUDYlh()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(HIvDSEfHmYLXCZgFzgQfmcgNYIFJ))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int cDhwtjWQhSyIsxMLQDmPyGiSilw(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, rvEtmlHRdCcipcmARRdpCrWqxsM P_1)
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

		public static int cEpjkqnxFPGTQdhuPpChSvOZbMpb(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, rvEtmlHRdCcipcmARRdpCrWqxsM P_1)
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

		private static string WmCvOHpqwsboAQVBAYxTsjTDauh(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				while (true)
				{
					int num = -95946434;
					while (true)
					{
						switch (num ^ -95946436)
						{
						case 0:
							break;
						case 2:
							input = input.Trim();
							num = -95946435;
							continue;
						default:
							goto end_IL_002a;
						}
						break;
					}
					continue;
					end_IL_002a:
					break;
				}
			}
			return input;
		}
	}

	private class xIhmKboaCjBJRNQhMaCyrnJkVBq
	{
		public enum JlfFIFxnsIMhEOGkCIfNuUYzjVy
		{
			fyLkgCmTpqIuMAMCxJOMkArnGwx = 0,
			DVvUbKVHsTUhKpitpaArZixJgbT = 1
		}

		public class joAFcDtfnAKSLOFXVsIgotMZQQN
		{
			public int YZYerWLyrZezITIzzsjvGpplKQw;

			public int FDxfKNBiipHZgwkKUPegefKbjZpG;

			public string KrSAaeDrfQehorfbrYOtierIUgu;

			public int GWoLlqegGvGyTtMNhZYqvtRENGv;

			public bool CGvNMgTtJKByfBoLCudPLkyvgkV(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, JlfFIFxnsIMhEOGkCIfNuUYzjVy P_1)
			{
				if (P_0.rewiredId == YZYerWLyrZezITIzzsjvGpplKQw)
				{
					return true;
				}
				switch (P_1)
				{
				case JlfFIFxnsIMhEOGkCIfNuUYzjVy.fyLkgCmTpqIuMAMCxJOMkArnGwx:
					if (FDxfKNBiipHZgwkKUPegefKbjZpG == P_0.FDxfKNBiipHZgwkKUPegefKbjZpG)
					{
						return KrSAaeDrfQehorfbrYOtierIUgu == P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
					}
					return false;
				case JlfFIFxnsIMhEOGkCIfNuUYzjVy.DVvUbKVHsTUhKpitpaArZixJgbT:
					return KrSAaeDrfQehorfbrYOtierIUgu == P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private List<joAFcDtfnAKSLOFXVsIgotMZQQN> rokTPxsNitEbJnvAHMxvBQpZKze;

		public int Count
		{
			get
			{
				return rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			}
		}

		public xIhmKboaCjBJRNQhMaCyrnJkVBq()
		{
			rokTPxsNitEbJnvAHMxvBQpZKze = new List<joAFcDtfnAKSLOFXVsIgotMZQQN>();
		}

		public void hGoGXvVewDdznIUDiLVJVGFrUsD(rvEtmlHRdCcipcmARRdpCrWqxsM P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
				int num = -1357985130;
				while (true)
				{
					switch (num ^ -1357985133)
					{
					case 4:
						num = -1357985132;
						continue;
					case 0:
						return;
					case 5:
						num2 = 0;
						num = -1357985136;
						continue;
					case 2:
						num2++;
						num = -1357985136;
						continue;
					case 6:
						BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, num2);
						num = -1357985133;
						continue;
					case 7:
						break;
					case 1:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num2].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, JlfFIFxnsIMhEOGkCIfNuUYzjVy.fyLkgCmTpqIuMAMCxJOMkArnGwx))
						{
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].YZYerWLyrZezITIzzsjvGpplKQw = P_0.rewiredId;
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].KrSAaeDrfQehorfbrYOtierIUgu = P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ;
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].FDxfKNBiipHZgwkKUPegefKbjZpG = P_0.FDxfKNBiipHZgwkKUPegefKbjZpG;
							rokTPxsNitEbJnvAHMxvBQpZKze[num2].GWoLlqegGvGyTtMNhZYqvtRENGv = P_0.inputManagerId;
							num = -1357985131;
							continue;
						}
						goto case 2;
					default:
						if (num2 >= count)
						{
							rokTPxsNitEbJnvAHMxvBQpZKze.Add(new joAFcDtfnAKSLOFXVsIgotMZQQN
							{
								YZYerWLyrZezITIzzsjvGpplKQw = P_0.rewiredId,
								KrSAaeDrfQehorfbrYOtierIUgu = P_0.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ,
								FDxfKNBiipHZgwkKUPegefKbjZpG = P_0.FDxfKNBiipHZgwkKUPegefKbjZpG,
								GWoLlqegGvGyTtMNhZYqvtRENGv = P_0.inputManagerId
							});
							BfoPnOzEfehguKuapcNsLLRRhsb(P_0.rewiredId, rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1);
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public bool WfhdeimYiTFGUIbHSjqOJaakYWS(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, JlfFIFxnsIMhEOGkCIfNuUYzjVy P_1)
		{
			int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -452014979;
				while (true)
				{
					switch (num ^ -452014978)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = -452014980;
						continue;
					case 1:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num2].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
						{
							return true;
						}
						num2++;
						num = -452014980;
						continue;
					default:
						if (num2 >= count)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public joAFcDtfnAKSLOFXVsIgotMZQQN OlRyGPawIBmfpGbjKDHJQXdzfaeG(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, JlfFIFxnsIMhEOGkCIfNuUYzjVy P_1)
		{
			int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = -213273979;
					num3 = num2;
				}
				else
				{
					num2 = -213273978;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -213273980)
					{
					case 0:
						num2 = -213273979;
						continue;
					case 1:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].CGvNMgTtJKByfBoLCudPLkyvgkV(P_0, P_1))
						{
							return rokTPxsNitEbJnvAHMxvBQpZKze[num];
						}
						num++;
						num2 = -213273977;
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

		public int EAgOMouOjbslHCCsyBDLoGVrHcd(joAFcDtfnAKSLOFXVsIgotMZQQN P_0)
		{
			int count = rokTPxsNitEbJnvAHMxvBQpZKze.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 544817403;
				while (true)
				{
					switch (num ^ 0x207940FF)
					{
					case 2:
						break;
					case 4:
						num2 = 0;
						num = 544817404;
						continue;
					case 0:
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num2] == P_0)
						{
							return num2;
						}
						num2++;
						num = 544817404;
						continue;
					case 3:
					{
						int num3;
						if (num2 < count)
						{
							num = 544817407;
							num3 = num;
						}
						else
						{
							num = 544817406;
							num3 = num;
						}
						continue;
					}
					default:
						return -1;
					}
					break;
				}
			}
		}

		private void BfoPnOzEfehguKuapcNsLLRRhsb(int P_0, int P_1)
		{
			int num = rokTPxsNitEbJnvAHMxvBQpZKze.Count - 1;
			while (num >= 0)
			{
				while (true)
				{
					int num2;
					if (num != P_1)
					{
						int num3;
						if (rokTPxsNitEbJnvAHMxvBQpZKze[num].YZYerWLyrZezITIzzsjvGpplKQw == P_0)
						{
							num2 = 2003876251;
							num3 = num2;
						}
						else
						{
							num2 = 2003876250;
							num3 = num2;
						}
						goto IL_0015;
					}
					goto IL_005f;
					IL_0015:
					while (true)
					{
						switch (num2 ^ 0x7770B99B)
						{
						case 2:
							num2 = 2003876248;
							continue;
						case 3:
							break;
						case 1:
							goto IL_005f;
						case 0:
							rokTPxsNitEbJnvAHMxvBQpZKze.RemoveAt(num);
							num2 = 2003876250;
							continue;
						default:
							goto end_IL_0036;
						}
						break;
					}
					continue;
					IL_005f:
					num--;
					num2 = 2003876255;
					goto IL_0015;
					continue;
					end_IL_0036:
					break;
				}
			}
		}
	}

	private List<rvEtmlHRdCcipcmARRdpCrWqxsM> AVRtfMRpOzQlHvmKXxpZoBGaQUn;

	private int xrSChNBBhEWHvkeIhZBjNmkdZsmA;

	private xIhmKboaCjBJRNQhMaCyrnJkVBq VYIiPbQDTfmyzeeKLOEXjAUgGAe;

	private bool LDAcgYOFyYXGHPLDHfJvYGEiUNl;

	private UpdateLoopType xFKjhyBYBeaXHwQfmSuqSKfAFpj;

	private UpdateLoopType ZpquRMBZyBonTKZAnGSSVdUwCYM;

	private TimerAbs pMCqfPoqTaQAqaJobVLvqPWHujn;

	private Action<int, ControllerDataUpdater> EpczCkvPPKAdjiQfdfFMvZxBJnNl;

	private PlatformInputManager SUAsPHGFrajzPXFANEuqbUoeMlU;

	private readonly IUnifiedKeyboardSource AMPTgkqyYuesJRBEloKTFpddsSb;

	private readonly IUnifiedMouseSource qRsirXHVwCtkYlNNNRsgubchynJ;

	private bool soPtrZbOCsGTHtAkbTrijQgpBIs;

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
			return InputSource.Fallback;
		}
	}

	public DPgtozdBQUGdQcMHLQJhOOhCCB(UpdateLoopSetting updateLoopSetting)
	{
		SUAsPHGFrajzPXFANEuqbUoeMlU = this;
		AMPTgkqyYuesJRBEloKTFpddsSb = new UnityUnifiedKeyboardSource();
		qRsirXHVwCtkYlNNNRsgubchynJ = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			int num = 0;
			if (num < list.Count)
			{
				ZpquRMBZyBonTKZAnGSSVdUwCYM = list[num];
			}
		}
		EpczCkvPPKAdjiQfdfFMvZxBJnNl = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		pMCqfPoqTaQAqaJobVLvqPWHujn = new TimerAbs(1f);
		VYIiPbQDTfmyzeeKLOEXjAUgGAe = new xIhmKboaCjBJRNQhMaCyrnJkVBq();
		MBWbLtwiramKtsVixhpKLRHaVam();
		while (true)
		{
			int num = -679386084;
			while (true)
			{
				switch (num ^ -679386082)
				{
				case 0:
					break;
				case 2:
					goto IL_003f;
				default:
					pMCqfPoqTaQAqaJobVLvqPWHujn.Start();
					return;
				}
				break;
				IL_003f:
				LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
				num = -679386081;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		xFKjhyBYBeaXHwQfmSuqSKfAFpj = updateLoop;
		while (true)
		{
			int num = -1001361592;
			while (true)
			{
				switch (num ^ -1001361591)
				{
				case 2:
					break;
				case 1:
					EtAMQHtUsklNEPJuTaQYVwGwxRp();
					if (LDAcgYOFyYXGHPLDHfJvYGEiUNl)
					{
						goto IL_0033;
					}
					goto default;
				default:
					njzLgbngHRtFtusDoWSXPlqSohr(updateLoop);
					return;
				}
				break;
				IL_0033:
				YUdSTENKKNoVxApSKeakGqiLoBfc();
				num = -1001361591;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		(AMPTgkqyYuesJRBEloKTFpddsSb as IDisposable).Dispose();
		(qRsirXHVwCtkYlNNNRsgubchynJ as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return EpczCkvPPKAdjiQfdfFMvZxBJnNl;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= xrSChNBBhEWHvkeIhZBjNmkdZsmA)
			{
				num2 = -1191509265;
				num3 = num2;
			}
			else
			{
				num2 = -1191509271;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1191509269)
				{
				case 0:
					num2 = -1191509271;
					continue;
				case 1:
					break;
				case 3:
					num++;
					num2 = -1191509270;
					continue;
				case 2:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].inputManagerId == assignedControllerId)
					{
						AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].FillData(data);
						return;
					}
					goto case 3;
				default:
					Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
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
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
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
			if (num >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count)
			{
				num2 = 0;
				num3 = 1547864725;
				goto IL_0009;
			}
			goto IL_0094;
			IL_0054:
			num++;
			num3 = 1547864720;
			goto IL_0009;
			IL_0094:
			if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].unityId == unityJoystickId)
			{
				AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].AqaErtHnQpGUqupVaRoxdDokZWa();
				num3 = 1547864727;
				goto IL_0009;
			}
			goto IL_0054;
			IL_0009:
			while (true)
			{
				switch (num3 ^ 0x5C428A93)
				{
				case 7:
					num3 = 1547864721;
					continue;
				default:
					return;
				case 3:
					break;
				case 4:
					goto IL_0054;
				case 6:
					goto IL_005f;
				case 8:
					return;
				case 0:
					num2++;
					num3 = 1547864725;
					continue;
				case 2:
					goto IL_0094;
				case 5:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2].rewiredId == joystickId)
					{
						AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2].jvrkDyTBNzBMlibzXFhmiiedfaBH(unityJoystickId);
						num3 = 1547864731;
						continue;
					}
					goto case 0;
				case 1:
					return;
				}
				break;
				IL_005f:
				int num4;
				if (num2 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count)
				{
					num3 = 1547864722;
					num4 = num3;
				}
				else
				{
					num3 = 1547864726;
					num4 = num3;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return qRsirXHVwCtkYlNNNRsgubchynJ;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return AMPTgkqyYuesJRBEloKTFpddsSb;
	}

	private void MBWbLtwiramKtsVixhpKLRHaVam()
	{
		MBWbLtwiramKtsVixhpKLRHaVam(nWzehzZmYlXFNxvfavITNDeRbhi());
	}

	private void MBWbLtwiramKtsVixhpKLRHaVam(string[] P_0)
	{
		int num = 0;
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM2 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		int num5 = default(int);
		int num4 = default(int);
		List<rvEtmlHRdCcipcmARRdpCrWqxsM> aVRtfMRpOzQlHvmKXxpZoBGaQUn = default(List<rvEtmlHRdCcipcmARRdpCrWqxsM>);
		int num6 = default(int);
		string text = default(string);
		while (true)
		{
			int num2 = 1144268012;
			while (true)
			{
				switch (num2 ^ 0x443424E0)
				{
				case 6:
					break;
				case 13:
					rvEtmlHRdCcipcmARRdpCrWqxsM2.FDxfKNBiipHZgwkKUPegefKbjZpG = num5;
					rvEtmlHRdCcipcmARRdpCrWqxsM2.unityId = num5 + 1;
					rvEtmlHRdCcipcmARRdpCrWqxsM2.sbcTSexDWKGUOKrMGnEajLgRvts();
					AVRtfMRpOzQlHvmKXxpZoBGaQUn.Add(rvEtmlHRdCcipcmARRdpCrWqxsM2);
					num++;
					num2 = 1144268002;
					continue;
				case 0:
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(AVRtfMRpOzQlHvmKXxpZoBGaQUn[num4]));
					num2 = 1144268009;
					continue;
				case 3:
					if (num4 >= num)
					{
						DtOBegFLamhBKwlmzaaiccPahGxz(aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn, false);
						num2 = 1144268004;
						continue;
					}
					goto case 10;
				case 8:
					xrSChNBBhEWHvkeIhZBjNmkdZsmA = num;
					SAHmPdomeKmRmWDMHYyWboYkaxQ(num6, num, aVRtfMRpOzQlHvmKXxpZoBGaQUn, AVRtfMRpOzQlHvmKXxpZoBGaQUn);
					num4 = 0;
					num2 = 1144268003;
					continue;
				case 7:
					rvEtmlHRdCcipcmARRdpCrWqxsM2 = new rvEtmlHRdCcipcmARRdpCrWqxsM();
					rvEtmlHRdCcipcmARRdpCrWqxsM2.HIvDSEfHmYLXCZgFzgQfmcgNYIFJ = text;
					rvEtmlHRdCcipcmARRdpCrWqxsM2.oJQguCtPmjqScMAmVURNLbjxBsy = text;
					num2 = 1144268013;
					continue;
				case 2:
					num5++;
					num2 = 1144268001;
					continue;
				case 10:
				{
					int num8;
					if (_UpdateControllerInfoEvent != null)
					{
						num2 = 1144268000;
						num8 = num2;
					}
					else
					{
						num2 = 1144268009;
						num8 = num2;
					}
					continue;
				}
				case 1:
				{
					int num7;
					if (num5 >= P_0.Length)
					{
						num2 = 1144268008;
						num7 = num2;
					}
					else
					{
						num2 = 1144268011;
						num7 = num2;
					}
					continue;
				}
				case 9:
					num4++;
					num2 = 1144268003;
					continue;
				case 11:
					text = StringTools.SanitizeDeviceString(P_0[num5]);
					num2 = 1144268005;
					continue;
				case 12:
					aVRtfMRpOzQlHvmKXxpZoBGaQUn = AVRtfMRpOzQlHvmKXxpZoBGaQUn;
					num6 = xrSChNBBhEWHvkeIhZBjNmkdZsmA;
					AVRtfMRpOzQlHvmKXxpZoBGaQUn = new List<rvEtmlHRdCcipcmARRdpCrWqxsM>();
					num5 = 0;
					num2 = 1144268001;
					continue;
				case 5:
				{
					int num3;
					if (UnityTools.IsValidUnityJoystickName(text))
					{
						num2 = 1144268007;
						num3 = num2;
					}
					else
					{
						num2 = 1144268002;
						num3 = num2;
					}
					continue;
				}
				default:
					DtOBegFLamhBKwlmzaaiccPahGxz(AVRtfMRpOzQlHvmKXxpZoBGaQUn, aVRtfMRpOzQlHvmKXxpZoBGaQUn, true);
					return;
				}
				break;
			}
		}
	}

	private void njzLgbngHRtFtusDoWSXPlqSohr(UpdateLoopType P_0)
	{
		int count = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
		int num2 = default(int);
		while (true)
		{
			int num = -2145470457;
			while (true)
			{
				switch (num ^ -2145470458)
				{
				case 0:
					break;
				case 1:
					num2 = 0;
					num = -2145470461;
					continue;
				case 4:
					AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2].Update();
					num = -2145470460;
					continue;
				case 3:
				{
					int num3;
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2] != null)
					{
						num = -2145470462;
						num3 = num;
					}
					else
					{
						num = -2145470460;
						num3 = num;
					}
					continue;
				}
				case 2:
					num2++;
					num = -2145470461;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private string[] nWzehzZmYlXFNxvfavITNDeRbhi()
	{
		return Input.GetJoystickNames();
	}

	private void SAHmPdomeKmRmWDMHYyWboYkaxQ(int P_0, int P_1, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_2, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(rvEtmlHRdCcipcmARRdpCrWqxsM.cEpjkqnxFPGTQdhuPpChSvOZbMpb);
			goto IL_001a;
		}
		goto IL_00ba;
		IL_0103:
		SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy.fyLkgCmTpqIuMAMCxJOMkArnGwx);
		SWJVUJtNevBpHELnpTBupupzivbg(P_1, P_3, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy.DVvUbKVHsTUhKpitpaArZixJgbT);
		int num = 0;
		int num2 = -587695955;
		goto IL_001f;
		IL_001a:
		num2 = -587695958;
		goto IL_001f;
		IL_001f:
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM2 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		while (true)
		{
			switch (num2 ^ -587695960)
			{
			case 6:
				break;
			case 5:
				num2 = -587695957;
				continue;
			case 0:
				num++;
				num2 = -587695957;
				continue;
			case 1:
				if (rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId < 0)
				{
					rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId = lthALbyMafUeFUSoDiwZaXONIhC(P_3);
					rvEtmlHRdCcipcmARRdpCrWqxsM2.rewiredId = ReInput.GetNewJoystickId();
					VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(rvEtmlHRdCcipcmARRdpCrWqxsM2);
					num2 = -587695960;
					continue;
				}
				goto case 0;
			case 7:
				goto IL_009a;
			case 2:
				goto IL_00ba;
			case 3:
				goto IL_00eb;
			case 8:
				goto IL_0103;
			default:
				P_3.Sort(rvEtmlHRdCcipcmARRdpCrWqxsM.cDhwtjWQhSyIsxMLQDmPyGiSilw);
				return;
			}
			break;
			IL_00eb:
			int num3;
			if (num >= P_1)
			{
				num2 = -587695956;
				num3 = num2;
			}
			else
			{
				num2 = -587695953;
				num3 = num2;
			}
			continue;
			IL_009a:
			rvEtmlHRdCcipcmARRdpCrWqxsM2 = P_3[num];
			int num4;
			if (rvEtmlHRdCcipcmARRdpCrWqxsM2 != null)
			{
				num2 = -587695959;
				num4 = num2;
			}
			else
			{
				num2 = -587695960;
				num4 = num2;
			}
		}
		goto IL_001a;
		IL_00ba:
		if (P_0 > 0 && P_1 > 0)
		{
			CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy.fyLkgCmTpqIuMAMCxJOMkArnGwx);
			CJTiCwRYBKtdCjdVGCYyAKtmlkc(P_1, P_3, P_0, P_2, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy.DVvUbKVHsTUhKpitpaArZixJgbT);
			num2 = -587695968;
			goto IL_001f;
		}
		goto IL_0103;
	}

	private void jMgFvMJOWRWuceXBnZGyQCpTgME(List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				if (num != P_1 && P_0[num] != null)
				{
					int num3;
					if (P_0[num].inputManagerId != P_2)
					{
						num2 = 1979697212;
						num3 = num2;
					}
					else
					{
						num2 = 1979697214;
						num3 = num2;
					}
					goto IL_0010;
				}
				goto IL_005e;
				IL_005e:
				num++;
				num2 = 1979697215;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num2 ^ 0x75FFC83C)
					{
					case 4:
						num2 = 1979697213;
						continue;
					case 1:
						break;
					case 0:
						goto IL_005e;
					case 2:
						P_0[num].inputManagerId = -1;
						num2 = 1979697212;
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

	private bool tdJERshKrZupAABGOtPFZhjIApQ(List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_0, int P_1)
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
				int num2 = 918253206;
				while (true)
				{
					switch (num2 ^ 0x36BB6E96)
					{
					case 2:
						num2 = 918253207;
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

	private int lthALbyMafUeFUSoDiwZaXONIhC(List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_0)
	{
		int num = 0;
		bool flag = default(bool);
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num2 = 1645198990;
			while (true)
			{
				switch (num2 ^ 0x620FBE89)
				{
				case 2:
					break;
				case 1:
					num2 = 1645198991;
					continue;
				case 4:
					flag = true;
					num2 = 1645198984;
					continue;
				case 7:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = 1645198985;
					continue;
				case 3:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = 1645198991;
						num4 = num2;
					}
					else
					{
						num2 = 1645198988;
						num4 = num2;
					}
					continue;
				}
				case 5:
					if (P_0[num3] != null)
					{
						int num5;
						if (P_0[num3].inputManagerId != num)
						{
							num2 = 1645198977;
							num5 = num2;
						}
						else
						{
							num2 = 1645198989;
							num5 = num2;
						}
						continue;
					}
					goto case 8;
				case 8:
					num3++;
					num2 = 1645198986;
					continue;
				case 0:
					num2 = 1645198986;
					continue;
				default:
					if (!flag)
					{
						return num;
					}
					num++;
					goto case 7;
				}
				break;
			}
		}
	}

	private bool reYntWceOkPUZwwqHtuPFEoKbLb(List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_0, int P_1)
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
				int num2 = 47181208;
				while (true)
				{
					switch (num2 ^ 0x2CFED98)
					{
					case 2:
						num2 = 47181209;
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

	private void CJTiCwRYBKtdCjdVGCYyAKtmlkc(int P_0, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_1, int P_2, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_3, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy P_4)
	{
		int num = ((P_4 != xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy.fyLkgCmTpqIuMAMCxJOMkArnGwx) ? 1 : 2);
		int num4 = default(int);
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM2 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		int num3 = default(int);
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM3 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		while (true)
		{
			int num2 = 953593610;
			while (true)
			{
				switch (num2 ^ 0x38D6AF02)
				{
				case 7:
					break;
				case 6:
					num4++;
					num2 = 953593609;
					continue;
				case 3:
					rvEtmlHRdCcipcmARRdpCrWqxsM2 = P_1[num3];
					num2 = 953593614;
					continue;
				case 0:
					rvEtmlHRdCcipcmARRdpCrWqxsM3 = P_3[num4];
					num2 = 953593607;
					continue;
				case 8:
					num3 = 0;
					num2 = 953593603;
					continue;
				case 12:
				{
					int num6;
					if (rvEtmlHRdCcipcmARRdpCrWqxsM2 != null)
					{
						num2 = 953593600;
						num6 = num2;
					}
					else
					{
						num2 = 953593606;
						num6 = num2;
					}
					continue;
				}
				case 11:
				{
					int num5;
					if (num4 >= P_2)
					{
						num2 = 953593606;
						num5 = num2;
					}
					else
					{
						num2 = 953593602;
						num5 = num2;
					}
					continue;
				}
				case 4:
					num3++;
					num2 = 953593603;
					continue;
				case 2:
					if (rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId < 0)
					{
						num4 = 0;
						num2 = 953593609;
						continue;
					}
					goto case 4;
				case 5:
					if (rvEtmlHRdCcipcmARRdpCrWqxsM3 != null && !reYntWceOkPUZwwqHtuPFEoKbLb(P_1, rvEtmlHRdCcipcmARRdpCrWqxsM3.rewiredId) && rvEtmlHRdCcipcmARRdpCrWqxsM2.CGvNMgTtJKByfBoLCudPLkyvgkV(rvEtmlHRdCcipcmARRdpCrWqxsM3) >= num)
					{
						rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId = rvEtmlHRdCcipcmARRdpCrWqxsM3.inputManagerId;
						num2 = 953593611;
						continue;
					}
					goto case 6;
				case 9:
					rvEtmlHRdCcipcmARRdpCrWqxsM2.rewiredId = rvEtmlHRdCcipcmARRdpCrWqxsM3.rewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						rvEtmlHRdCcipcmARRdpCrWqxsM2.unityId = rvEtmlHRdCcipcmARRdpCrWqxsM3.unityId;
						num2 = 953593608;
						continue;
					}
					goto case 10;
				case 10:
					VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(rvEtmlHRdCcipcmARRdpCrWqxsM2);
					num2 = 953593604;
					continue;
				default:
					if (num3 >= P_0)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private void SWJVUJtNevBpHELnpTBupupzivbg(int P_0, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_1, xIhmKboaCjBJRNQhMaCyrnJkVBq.JlfFIFxnsIMhEOGkCIfNuUYzjVy P_2)
	{
		int num = 0;
		int num4 = default(int);
		xIhmKboaCjBJRNQhMaCyrnJkVBq.joAFcDtfnAKSLOFXVsIgotMZQQN joAFcDtfnAKSLOFXVsIgotMZQQN = default(xIhmKboaCjBJRNQhMaCyrnJkVBq.joAFcDtfnAKSLOFXVsIgotMZQQN);
		while (num < P_0)
		{
			while (true)
			{
				rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM2 = P_1[num];
				int num2;
				int num3;
				if (rvEtmlHRdCcipcmARRdpCrWqxsM2 != null)
				{
					num2 = 777152558;
					num3 = num2;
				}
				else
				{
					num2 = 777152557;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2E52682B)
					{
					case 4:
						num2 = 777152553;
						continue;
					case 3:
						num4 = joAFcDtfnAKSLOFXVsIgotMZQQN.GWoLlqegGvGyTtMNhZYqvtRENGv;
						if (num4 < 0)
						{
							goto case 6;
						}
						if (!tdJERshKrZupAABGOtPFZhjIApQ(P_1, num4))
						{
							num4 = lthALbyMafUeFUSoDiwZaXONIhC(P_1);
							num2 = 777152556;
							continue;
						}
						goto case 1;
					case 6:
						num++;
						num2 = 777152555;
						continue;
					case 8:
						VYIiPbQDTfmyzeeKLOEXjAUgGAe.hGoGXvVewDdznIUDiLVJVGFrUsD(rvEtmlHRdCcipcmARRdpCrWqxsM2);
						num2 = 777152557;
						continue;
					case 5:
						if (rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId < 0)
						{
							joAFcDtfnAKSLOFXVsIgotMZQQN = VYIiPbQDTfmyzeeKLOEXjAUgGAe.OlRyGPawIBmfpGbjKDHJQXdzfaeG(rvEtmlHRdCcipcmARRdpCrWqxsM2, P_2);
							if (joAFcDtfnAKSLOFXVsIgotMZQQN != null)
							{
								goto IL_009c;
							}
						}
						goto case 6;
					case 1:
						rvEtmlHRdCcipcmARRdpCrWqxsM2.inputManagerId = num4;
						rvEtmlHRdCcipcmARRdpCrWqxsM2.rewiredId = joAFcDtfnAKSLOFXVsIgotMZQQN.YZYerWLyrZezITIzzsjvGpplKQw;
						num2 = 777152547;
						continue;
					case 2:
						break;
					case 7:
						joAFcDtfnAKSLOFXVsIgotMZQQN.GWoLlqegGvGyTtMNhZYqvtRENGv = num4;
						num2 = 777152554;
						continue;
					default:
						goto end_IL_00dc;
					}
					break;
					IL_009c:
					int num5;
					if (!reYntWceOkPUZwwqHtuPFEoKbLb(P_1, joAFcDtfnAKSLOFXVsIgotMZQQN.YZYerWLyrZezITIzzsjvGpplKQw))
					{
						num2 = 777152552;
						num5 = num2;
					}
					else
					{
						num2 = 777152557;
						num5 = num2;
					}
				}
				continue;
				end_IL_00dc:
				break;
			}
		}
	}

	private void YUdSTENKKNoVxApSKeakGqiLoBfc()
	{
		string[] array = nWzehzZmYlXFNxvfavITNDeRbhi();
		while (true)
		{
			int num = 163187967;
			while (true)
			{
				switch (num ^ 0x9BA0CFE)
				{
				case 3:
					break;
				case 1:
				{
					int num2;
					if (hXJLHlYsxiqopPvGhwftUXQBvzA(array))
					{
						num = 163187964;
						num2 = num;
					}
					else
					{
						num = 163187966;
						num2 = num;
					}
					continue;
				}
				case 2:
					MBWbLtwiramKtsVixhpKLRHaVam(array);
					num = 163187966;
					continue;
				default:
					LDAcgYOFyYXGHPLDHfJvYGEiUNl = false;
					return;
				}
				break;
			}
		}
	}

	private bool hXJLHlYsxiqopPvGhwftUXQBvzA(string[] P_0)
	{
		int num = P_0.Length;
		int num7 = default(int);
		int num5 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		int num6 = default(int);
		int count = default(int);
		string text = default(string);
		while (true)
		{
			int num2 = 1313491715;
			while (true)
			{
				switch (num2 ^ 0x4E4A4B06)
				{
				case 6:
					break;
				case 4:
					if (num7 >= num)
					{
						num5 = 0;
						num3 = 0;
						num2 = 1313491720;
						continue;
					}
					goto case 13;
				case 1:
					num7++;
					num2 = 1313491714;
					continue;
				case 10:
					num4++;
					num2 = 1313491719;
					continue;
				case 7:
				{
					int num8;
					if (num6 < num)
					{
						num2 = 1313491716;
						num8 = num2;
					}
					else
					{
						num2 = 1313491725;
						num8 = num2;
					}
					continue;
				}
				case 5:
					count = AVRtfMRpOzQlHvmKXxpZoBGaQUn.Count;
					if (num != count)
					{
						return true;
					}
					num6 = 0;
					num2 = 1313491713;
					continue;
				case 13:
				{
					int num9;
					if (!(P_0[num7] == text))
					{
						num2 = 1313491719;
						num9 = num2;
					}
					else
					{
						num2 = 1313491724;
						num9 = num2;
					}
					continue;
				}
				case 0:
					return true;
				case 9:
					text = P_0[num6];
					num4 = 0;
					num7 = 0;
					num2 = 1313491717;
					continue;
				case 2:
					if (P_0[num6] == null)
					{
						P_0[num6] = string.Empty;
						num2 = 1313491727;
						continue;
					}
					goto case 9;
				case 3:
					num2 = 1313491714;
					continue;
				case 12:
					if (AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3] != null && AVRtfMRpOzQlHvmKXxpZoBGaQUn[num3].HIvDSEfHmYLXCZgFzgQfmcgNYIFJ == text)
					{
						num5++;
						num2 = 1313491726;
						continue;
					}
					goto case 8;
				case 8:
					num3++;
					num2 = 1313491720;
					continue;
				case 14:
					if (num3 >= count)
					{
						if (num4 == num5)
						{
							num6++;
							num2 = 1313491713;
						}
						else
						{
							num2 = 1313491718;
						}
						continue;
					}
					goto case 12;
				default:
					return false;
				}
				break;
			}
		}
	}

	private void DtOBegFLamhBKwlmzaaiccPahGxz(List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_0, List<rvEtmlHRdCcipcmARRdpCrWqxsM> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num4 = default(int);
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM2 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		int num5 = default(int);
		bool flag = default(bool);
		int num6 = default(int);
		rvEtmlHRdCcipcmARRdpCrWqxsM rvEtmlHRdCcipcmARRdpCrWqxsM3 = default(rvEtmlHRdCcipcmARRdpCrWqxsM);
		while (true)
		{
			IL_013a:
			int num = ((P_0 != null) ? P_0.Count : 0);
			int num2;
			if (P_1 != null)
			{
				num2 = P_1.Count;
				goto IL_0081;
			}
			int num3 = -1468171776;
			goto IL_000c;
			IL_0081:
			num4 = num2;
			num3 = -1468171770;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num3 ^ -1468171764)
				{
				case 14:
					num3 = -1468171763;
					continue;
				case 0:
					rvEtmlHRdCcipcmARRdpCrWqxsM2 = P_0[num5];
					if (rvEtmlHRdCcipcmARRdpCrWqxsM2 != null)
					{
						flag = false;
						num3 = -1468171771;
						continue;
					}
					goto case 7;
				case 7:
					num5++;
					num3 = -1468171769;
					continue;
				case 12:
					break;
				case 4:
					goto IL_0089;
				case 9:
					if (P_1 != null)
					{
						num6 = 0;
						num3 = -1468171762;
						continue;
					}
					goto IL_0100;
				case 5:
					num6++;
					num3 = -1468171768;
					continue;
				case 6:
					goto IL_00c2;
				case 8:
					if (rvEtmlHRdCcipcmARRdpCrWqxsM2.rewiredId == rvEtmlHRdCcipcmARRdpCrWqxsM3.rewiredId)
					{
						flag = true;
						num3 = -1468171761;
						continue;
					}
					goto case 5;
				case 3:
					goto IL_0100;
				case 2:
					num3 = -1468171768;
					continue;
				case 13:
					jdgXxQHlYgOTDPrZOCVnfSFXUtzk(P_0[num5], P_2);
					num3 = -1468171765;
					continue;
				case 1:
					goto IL_013a;
				case 10:
					num5 = 0;
					num3 = -1468171769;
					continue;
				default:
					if (num5 >= num)
					{
						return;
					}
					goto case 0;
				}
				break;
				IL_00c2:
				rvEtmlHRdCcipcmARRdpCrWqxsM3 = P_1[num6];
				int num7;
				if (rvEtmlHRdCcipcmARRdpCrWqxsM3 != null)
				{
					num3 = -1468171772;
					num7 = num3;
				}
				else
				{
					num3 = -1468171767;
					num7 = num3;
				}
				continue;
				IL_0100:
				int num8;
				if (!flag)
				{
					num3 = -1468171775;
					num8 = num3;
				}
				else
				{
					num3 = -1468171765;
					num8 = num3;
				}
				continue;
				IL_0089:
				int num9;
				if (num6 >= num4)
				{
					num3 = -1468171761;
					num9 = num3;
				}
				else
				{
					num3 = -1468171766;
					num9 = num3;
				}
			}
			num2 = 0;
			goto IL_0081;
		}
	}

	private void jdgXxQHlYgOTDPrZOCVnfSFXUtzk(rvEtmlHRdCcipcmARRdpCrWqxsM P_0, bool P_1)
	{
		if (P_1)
		{
			goto IL_0003;
		}
		goto IL_0029;
		IL_0003:
		int num = 1822737590;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ 0x6CA4C4B7)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0029;
			case 4:
				_DeviceConnectedEvent(P_0.ToBridgedController());
				return;
			case 1:
				goto IL_0062;
			case 2:
				return;
			}
			break;
			IL_0062:
			int num2;
			if (_DeviceConnectedEvent != null)
			{
				num = 1822737587;
				num2 = num;
			}
			else
			{
				num = 1822737589;
				num2 = num;
			}
		}
		goto IL_0003;
		IL_0029:
		if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			num = 1822737589;
			goto IL_0008;
		}
	}

	private void EtAMQHtUsklNEPJuTaQYVwGwxRp()
	{
		if (xFKjhyBYBeaXHwQfmSuqSKfAFpj != ZpquRMBZyBonTKZAnGSSVdUwCYM)
		{
			goto IL_000e;
		}
		goto IL_0055;
		IL_000e:
		int num = -1572471873;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ -1572471876)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				LDAcgYOFyYXGHPLDHfJvYGEiUNl = true;
				pMCqfPoqTaQAqaJobVLvqPWHujn.Start();
				num = -1572471874;
				continue;
			case 4:
				goto IL_0055;
			case 2:
				return;
			}
			break;
		}
		goto IL_000e;
		IL_0055:
		int num2;
		if (pMCqfPoqTaQAqaJobVLvqPWHujn.Update())
		{
			num = -1572471875;
			num2 = num;
		}
		else
		{
			num = -1572471874;
			num2 = num;
		}
		goto IL_0013;
	}
}
