using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class qePDAvGeOBieqfeOibcNbUsuVSqM : PlatformInputManager
{
	private class nwXgurhtCFvedRYXAPczDqoZXlg : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int HhStEfcVVlMiBjgWdCLXZvzOFhgb;

		private int SVlrBPWDEySKVHcSUJitCfBSxnO;

		private int EDcwRUJrjTccxnNnAhrMmqhjdqO;

		public Guid NdHHxuQRnYAiYXlkbCSlISGovAq;

		public string mcAwKArXqdrIEFSsaspMyuTeuTS;

		public int JWlyBuqNEfjGChcttNidSemqTVV;

		public string ZhqFGFeXGFfspKpKvhiTdSQSWt;

		public string gEEhLyWTpHycofvBbLWplFWteOZ;

		private int RGhWgMAfPjfICjXGWTZxnPoNdWD = 29;

		private int SeOhWaCQLSUYyhdokorrnPTrNGB = 20;

		private float[] JzCpTyTcKdiDVvPxFKAbxEFLDAw;

		private bool[] vEmeiLseeiFjOBSerAJjqspjZBa;

		private bool[] JmFeGibeFCfceuWsAGOFpaFQMOV;

		private float[] MYTbiHEwyovpMjozyZoyqbgqbqZB;

		private bool[] pNsdvdfsyTXxfBtwJIySExDeNAKC;

		private HardwareJoystickMap_InputManager REZiFujnwfIcWniRKvMxDxhPHlx;

		private bool BjLRIbHSNziZuePSCMYMTKKmtVyj;

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
				if (!(mcAwKArXqdrIEFSsaspMyuTeuTS != "Unknown Controller"))
				{
					return ZhqFGFeXGFfspKpKvhiTdSQSWt;
				}
				return mcAwKArXqdrIEFSsaspMyuTeuTS;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (EDcwRUJrjTccxnNnAhrMmqhjdqO < 1)
				{
					return null;
				}
				return EDcwRUJrjTccxnNnAhrMmqhjdqO;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return EDcwRUJrjTccxnNnAhrMmqhjdqO;
			}
			set
			{
				EDcwRUJrjTccxnNnAhrMmqhjdqO = value;
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
				int num = 1050034496;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x3E964141)
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
					num = 1050034499;
					goto IL_0013;
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(ZhqFGFeXGFfspKpKvhiTdSQSWt);
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + EDcwRUJrjTccxnNnAhrMmqhjdqO);
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public nwXgurhtCFvedRYXAPczDqoZXlg()
		{
			SVlrBPWDEySKVHcSUJitCfBSxnO = -1;
			HhStEfcVVlMiBjgWdCLXZvzOFhgb = -1;
			EDcwRUJrjTccxnNnAhrMmqhjdqO = 0;
		}

		public void kfcRhmfnfWicmjTenihbZSYGYjYh()
		{
			XxHELBuvCCtGAJntxYQUzFBhOFy();
			NdHHxuQRnYAiYXlkbCSlISGovAq = REZiFujnwfIcWniRKvMxDxhPHlx.hardwareMapIdentifier.guid;
			mcAwKArXqdrIEFSsaspMyuTeuTS = REZiFujnwfIcWniRKvMxDxhPHlx.controllerName;
			JzCpTyTcKdiDVvPxFKAbxEFLDAw = new float[RGhWgMAfPjfICjXGWTZxnPoNdWD];
			vEmeiLseeiFjOBSerAJjqspjZBa = new bool[SeOhWaCQLSUYyhdokorrnPTrNGB];
			JmFeGibeFCfceuWsAGOFpaFQMOV = new bool[RGhWgMAfPjfICjXGWTZxnPoNdWD];
			pNsdvdfsyTXxfBtwJIySExDeNAKC = new bool[29];
			MYTbiHEwyovpMjozyZoyqbgqbqZB = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (EDcwRUJrjTccxnNnAhrMmqhjdqO <= 0)
			{
				return;
			}
			while (true)
			{
				ynzNSPSkFJcsmAYLxZmuZrIqpID();
				UDEtzvxqREkxyopZfQhiKhodhQPJ();
				nLotdmIEnGDlRjnDZLzPFXYmCSSJ();
				int num = -1831183278;
				while (true)
				{
					switch (num ^ -1831183277)
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
					num = -1831183279;
				}
			}
		}

		public int YfzaYuFFeAGpZYIlhOCKodCcBwd(nwXgurhtCFvedRYXAPczDqoZXlg P_0)
		{
			if (string.IsNullOrEmpty(gEEhLyWTpHycofvBbLWplFWteOZ))
			{
				goto IL_000d;
			}
			goto IL_0047;
			IL_000d:
			int num = -132207296;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -132207293)
				{
				case 2:
					break;
				case 3:
					goto IL_0033;
				case 0:
					goto IL_0047;
				case 1:
					goto IL_0077;
				default:
					return 2;
				}
				break;
				IL_0077:
				if (P_0.JWlyBuqNEfjGChcttNidSemqTVV == JWlyBuqNEfjGChcttNidSemqTVV)
				{
					num = -132207289;
					continue;
				}
				goto IL_008e;
				IL_0033:
				if (!string.IsNullOrEmpty(P_0.gEEhLyWTpHycofvBbLWplFWteOZ))
				{
					num = -132207293;
					continue;
				}
				goto IL_005d;
			}
			goto IL_000d;
			IL_0047:
			if (!string.Equals(gEEhLyWTpHycofvBbLWplFWteOZ, P_0.gEEhLyWTpHycofvBbLWplFWteOZ, StringComparison.Ordinal))
			{
				return 0;
			}
			goto IL_005d;
			IL_005d:
			if (P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt == ZhqFGFeXGFfspKpKvhiTdSQSWt)
			{
				num = -132207294;
				goto IL_0012;
			}
			goto IL_008e;
			IL_008e:
			if (P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt == ZhqFGFeXGFfspKpKvhiTdSQSWt)
			{
				return 1;
			}
			return 0;
		}

		private void eaqBkFPxlFldmaTQruLSPLTaGpDi(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			while (true)
			{
				int num = -1308503692;
				while (true)
				{
					switch (num ^ -1308503690)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						P_0.inputSource = XMCAPkwsxgrVIvcNAMydmmXHkOV();
						P_0.hardwareIdentifier = ZpMnvMRPjTIgPNWjtdygNONQuFr();
						num = -1308503689;
						continue;
					case 1:
						P_0.hardwareAxisCount = 0;
						P_0.hardwareButtonCount = 0;
						P_0.hardwareHatCount = 0;
						P_0.hw_productName = ZhqFGFeXGFfspKpKvhiTdSQSWt;
						num = -1308503691;
						continue;
					case 3:
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
				int num = 1647044534;
				while (true)
				{
					switch (num ^ 0x622BE7B7)
					{
					case 0:
						break;
					case 1:
						goto IL_002c;
					default:
						P_0.isXInputDevice = false;
						P_0.axisCount = RGhWgMAfPjfICjXGWTZxnPoNdWD;
						P_0.buttonCount = SeOhWaCQLSUYyhdokorrnPTrNGB;
						P_0.controllerTypeGuid = NdHHxuQRnYAiYXlkbCSlISGovAq;
						return;
					}
					break;
					IL_002c:
					P_0.gameHardwareMap = REZiFujnwfIcWniRKvMxDxhPHlx.ToGameHardwareControllerMap();
					P_0.instanceName = ZhqFGFeXGFfspKpKvhiTdSQSWt;
					P_0.productName = ZhqFGFeXGFfspKpKvhiTdSQSWt;
					num = 1647044533;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (RGhWgMAfPjfICjXGWTZxnPoNdWD == dataUpdater.axisCount)
			{
				int num3 = default(int);
				float[] axisValues = default(float[]);
				bool[] axisHasBeenPressedOSXLinux = default(bool[]);
				int num2 = default(int);
				bool[] buttonValues = default(bool[]);
				while (true)
				{
					int num = -395431389;
					while (true)
					{
						switch (num ^ -395431391)
						{
						case 9:
							break;
						default:
							return;
						case 2:
							goto IL_005a;
						case 8:
							num3++;
							num = -395431386;
							continue;
						case 3:
							if (BjLRIbHSNziZuePSCMYMTKKmtVyj && !dataUpdater.hasReceivedInput)
							{
								dataUpdater.hasReceivedInput = true;
								num = -395431382;
								continue;
							}
							return;
						case 1:
							goto end_IL_0011;
						case 7:
							goto IL_00c2;
						case 4:
							goto IL_00e0;
						case 5:
							axisValues = dataUpdater.axisValues;
							axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
							num2 = 0;
							num = -395431387;
							continue;
						case 0:
							num2++;
							num = -395431387;
							continue;
						case 12:
							if (buttonValues[num3] != vEmeiLseeiFjOBSerAJjqspjZBa[num3])
							{
								buttonValues[num3] = vEmeiLseeiFjOBSerAJjqspjZBa[num3];
								num = -395431383;
								continue;
							}
							goto case 8;
						case 6:
							buttonValues = dataUpdater.buttonValues;
							num3 = 0;
							num = -395431386;
							continue;
						case 10:
							if (axisValues[num2] != JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2])
							{
								axisValues[num2] = JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2];
								if (axisHasBeenPressedOSXLinux[num2] != JmFeGibeFCfceuWsAGOFpaFQMOV[num2])
								{
									axisHasBeenPressedOSXLinux[num2] = JmFeGibeFCfceuWsAGOFpaFQMOV[num2];
									num = -395431391;
									continue;
								}
							}
							goto case 0;
						case 11:
							return;
						}
						break;
						IL_00e0:
						int num4;
						if (num2 < RGhWgMAfPjfICjXGWTZxnPoNdWD)
						{
							num = -395431381;
							num4 = num;
						}
						else
						{
							num = -395431385;
							num4 = num;
						}
						continue;
						IL_00c2:
						int num5;
						if (num3 >= SeOhWaCQLSUYyhdokorrnPTrNGB)
						{
							num = -395431390;
							num5 = num;
						}
						else
						{
							num = -395431379;
							num5 = num;
						}
						continue;
						IL_005a:
						int num6;
						if (SeOhWaCQLSUYyhdokorrnPTrNGB != dataUpdater.buttonCount)
						{
							num = -395431392;
							num6 = num;
						}
						else
						{
							num = -395431388;
							num6 = num;
						}
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public void tIprUyVwwtOoVfGVyGApjLOwlofu(int P_0)
		{
			if (P_0 < 1)
			{
				return;
			}
			if (P_0 > 16)
			{
				while (true)
				{
					switch (0x2E10DBAF ^ 0x2E10DBAE)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			unityId = P_0;
		}

		public void YqisevZTpjxqYbEnXlwcGIObmPO()
		{
			EDcwRUJrjTccxnNnAhrMmqhjdqO = 0;
			doSrWnbYutMRvEmuTwguCvcTazP();
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

		private void ynzNSPSkFJcsmAYLxZmuZrIqpID()
		{
			int num = 0;
			while (num < 29)
			{
				while (true)
				{
					float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(EDcwRUJrjTccxnNnAhrMmqhjdqO, num);
					int num2 = -1171296223;
					while (true)
					{
						switch (num2 ^ -1171296224)
						{
						case 3:
							num2 = -1171296222;
							continue;
						case 2:
							break;
						case 1:
							if (MYTbiHEwyovpMjozyZoyqbgqbqZB[num] != joystickAxisValueByJoystickId)
							{
								goto IL_0050;
							}
							goto case 0;
						case 0:
							num++;
							num2 = -1171296220;
							continue;
						case 5:
							if (joystickAxisValueByJoystickId != 0f)
							{
								pNsdvdfsyTXxfBtwJIySExDeNAKC[num] = true;
								num2 = -1171296224;
								continue;
							}
							goto case 0;
						default:
							goto end_IL_0031;
						}
						break;
						IL_0050:
						MYTbiHEwyovpMjozyZoyqbgqbqZB[num] = joystickAxisValueByJoystickId;
						int num3;
						if (!pNsdvdfsyTXxfBtwJIySExDeNAKC[num])
						{
							num2 = -1171296219;
							num3 = num2;
						}
						else
						{
							num2 = -1171296224;
							num3 = num2;
						}
					}
					continue;
					end_IL_0031:
					break;
				}
			}
		}

		private void UDEtzvxqREkxyopZfQhiKhodhQPJ()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)REZiFujnwfIcWniRKvMxDxhPHlx.map).Axes_orig;
			int num2 = default(int);
			while (true)
			{
				int num = -1835762070;
				while (true)
				{
					switch (num ^ -1835762071)
					{
					case 12:
						break;
					case 6:
						if (axes_orig[num2] != null)
						{
							int num6;
							if (num2 >= RGhWgMAfPjfICjXGWTZxnPoNdWD)
							{
								num = -1835762077;
								num6 = num;
							}
							else
							{
								num = -1835762079;
								num6 = num;
							}
							continue;
						}
						goto case 0;
					case 0:
						num2++;
						num = -1835762072;
						continue;
					case 5:
					{
						int num5;
						if (JmFeGibeFCfceuWsAGOFpaFQMOV[num2])
						{
							num = -1835762078;
							num5 = num;
						}
						else
						{
							num = -1835762067;
							num5 = num;
						}
						continue;
					}
					case 9:
					{
						float num3 = QEVsojLqDtQsxnvxgHocZSixiJS(axes_orig[num2].sourceAxis);
						JmFeGibeFCfceuWsAGOFpaFQMOV[num2] = num3 != 0f;
						num = -1835762078;
						continue;
					}
					case 7:
						num = -1835762072;
						continue;
					case 8:
					{
						float num7 = QEVsojLqDtQsxnvxgHocZSixiJS(axes_orig[num2]);
						if (JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] != num7)
						{
							JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] = num7;
							num = -1835762068;
							continue;
						}
						goto case 0;
					}
					case 2:
						num2 = 0;
						num = -1835762066;
						continue;
					case 4:
					{
						int num4;
						if (axes_orig[num2].sourceType == HardwareElementSourceTypeWithHat.Axis)
						{
							num = -1835762080;
							num4 = num;
						}
						else
						{
							num = -1835762076;
							num4 = num;
						}
						continue;
					}
					case 11:
						if (!BjLRIbHSNziZuePSCMYMTKKmtVyj && JzCpTyTcKdiDVvPxFKAbxEFLDAw[num2] != 0f)
						{
							BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
							num = -1835762071;
							continue;
						}
						goto case 0;
					case 10:
						throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
					case 3:
						if (axes_orig == null)
						{
							return;
						}
						goto case 2;
					case 13:
						JmFeGibeFCfceuWsAGOFpaFQMOV[num2] = true;
						num = -1835762078;
						continue;
					default:
						if (num2 >= axes_orig.Length)
						{
							return;
						}
						goto case 6;
					}
					break;
				}
			}
		}

		private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)REZiFujnwfIcWniRKvMxDxhPHlx.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = -883843273;
				while (true)
				{
					switch (num2 ^ -883843276)
					{
					case 6:
						num2 = -883843279;
						continue;
					case 7:
						num++;
						num2 = -883843273;
						continue;
					case 0:
						if (num >= SeOhWaCQLSUYyhdokorrnPTrNGB)
						{
							throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
						}
						goto case 2;
					case 5:
						break;
					case 1:
						if (vEmeiLseeiFjOBSerAJjqspjZBa[num])
						{
							BjLRIbHSNziZuePSCMYMTKKmtVyj = true;
							num2 = -883843277;
							continue;
						}
						goto case 7;
					case 4:
					{
						int num3;
						if (!BjLRIbHSNziZuePSCMYMTKKmtVyj)
						{
							num2 = -883843275;
							num3 = num2;
						}
						else
						{
							num2 = -883843277;
							num3 = num2;
						}
						continue;
					}
					case 2:
					{
						bool flag = oKAKkOrHJCSQdjvqMprroEgDqcJ(buttons_orig[num]);
						if (vEmeiLseeiFjOBSerAJjqspjZBa[num] != flag)
						{
							vEmeiLseeiFjOBSerAJjqspjZBa[num] = flag;
							num2 = -883843280;
							continue;
						}
						goto case 7;
					}
					default:
						if (num >= buttons_orig.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private bool oKAKkOrHJCSQdjvqMprroEgDqcJ(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			int num = default(int);
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					num = 0;
					goto IL_0018;
				}
				goto IL_0419;
			}
			int num2;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			int num3 = default(int);
			float num4 = default(float);
			if (P_0.sourceType != HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					num2 = 1634120064;
				}
				else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Key)
				{
					if (P_0.sourceKeyCode != KeyCode.None)
					{
						return Input.GetKey(P_0.sourceKeyCode);
					}
					num2 = 1634120086;
				}
				else
				{
					if (P_0.sourceType != HardwareElementSourceTypeWithHat.Custom)
					{
						goto IL_05a7;
					}
					customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return false;
					}
					if (customCalculation.ResultType == TypeWrapper.DataType.Single)
					{
						customCalculationSourceData = P_0.customCalculationSourceData;
						if (customCalculationSourceData == null)
						{
							return false;
						}
						num3 = 0;
						num2 = 1634120082;
					}
					else
					{
						num2 = 1634120094;
					}
				}
			}
			else
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				num4 = QEVsojLqDtQsxnvxgHocZSixiJS(P_0.sourceAxis);
				num2 = 1634120092;
			}
			goto IL_001d;
			IL_0104:
			if (P_0.sourceAxisPole == Pole.Negative && num4 > 0f)
			{
				return false;
			}
			return true;
			IL_0018:
			num2 = 1634120065;
			goto IL_001d;
			IL_0419:
			bool flag = default(bool);
			int num5 = default(int);
			if (!P_0.requireMultipleButtons)
			{
				if (P_0.sourceButton != UnityButton.None)
				{
					return oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.sourceButton);
				}
				num2 = 1634120078;
			}
			else
			{
				flag = false;
				num5 = 0;
				num2 = 1634120097;
			}
			goto IL_001d;
			IL_0256:
			if (flag)
			{
				return true;
			}
			return false;
			IL_001d:
			HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = default(HardwareElementSourceTypeWithHat);
			HardwareElementSourceTypeWithHat sourceType = default(HardwareElementSourceTypeWithHat);
			bool flag2 = default(bool);
			float x = default(float);
			float y = default(float);
			UnityAxis unityHat_sourceAxis = default(UnityAxis);
			float num7 = default(float);
			float num8 = default(float);
			while (true)
			{
				bool flag3;
				float num6;
				switch (num2 ^ 0x6166B180)
				{
				case 27:
					break;
				case 28:
					goto IL_00b5;
				case 5:
					hardwareElementSourceTypeWithHat = sourceType;
					num2 = 1634120087;
					continue;
				case 31:
					goto IL_00e5;
				case 4:
					return false;
				case 17:
					goto IL_012f;
				case 26:
					goto IL_014e;
				case 6:
					num2 = 1634120089;
					continue;
				case 16:
					goto IL_0170;
				case 30:
					return false;
				case 2:
					goto IL_01ad;
				case 21:
					return false;
				case 23:
					switch (hardwareElementSourceTypeWithHat)
					{
					case HardwareElementSourceTypeWithHat.Button:
						goto IL_0272;
					case HardwareElementSourceTypeWithHat.Key:
						goto IL_04dc;
					case HardwareElementSourceTypeWithHat.Axis:
						goto IL_051e;
					case HardwareElementSourceTypeWithHat.Hat:
						goto IL_0553;
					}
					num2 = 1634120089;
					continue;
				case 12:
					customCalculation.AddData(flag2 ? 1f : 0f);
					num2 = 1634120089;
					continue;
				case 29:
					goto IL_0256;
				case 19:
					goto IL_0272;
				case 9:
					goto IL_0295;
				case 8:
					if (customCalculationSourceData[num3] != null)
					{
						sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num3].sourceType;
						num2 = 1634120069;
						continue;
					}
					goto IL_0553;
				case 14:
					return false;
				case 10:
					goto IL_035b;
				case 0:
					if (P_0.unityHat_sourceAxis1 == UnityAxis.None)
					{
						goto case 21;
					}
					goto IL_03c1;
				case 1:
					num2 = 1634120066;
					continue;
				case 20:
					goto IL_03e0;
				case 11:
					x = P_0.unityHat_neverPressedZeroValues.x;
					y = P_0.unityHat_neverPressedZeroValues.y;
					num2 = 1634120090;
					continue;
				case 24:
					goto IL_0419;
				case 33:
					num2 = 1634120081;
					continue;
				case 7:
					if (!nUeFezqoNQRolakbgoOOConpIyT(unityHat_sourceAxis))
					{
						goto case 11;
					}
					goto IL_044d;
				case 13:
					goto IL_0471;
				case 22:
					return false;
				case 32:
					goto IL_04dc;
				case 15:
					return false;
				case 3:
					goto IL_051e;
				case 25:
					goto IL_0553;
				default:
					{
						if (num3 < customCalculationSourceData.Length)
						{
							goto case 8;
						}
						goto IL_056e;
					}
					IL_0553:
					num3++;
					num2 = 1634120082;
					continue;
					IL_04dc:
					if (jrNNouTaxtGQsUAhuoXKJIBCoal(customCalculationSourceData[num3], out flag3))
					{
						customCalculation.AddData(flag3 ? 1f : 0f);
						num2 = 1634120089;
						continue;
					}
					goto IL_0553;
					IL_051e:
					if (SSAvaWGqpfYbxkPCzsJDWXzutnB(customCalculationSourceData[num3], out num6))
					{
						customCalculation.AddData((num6 != 0f) ? 1f : 0f);
						num2 = 1634120070;
						continue;
					}
					goto IL_0553;
				}
				break;
				IL_03e0:
				if (num4 < 0f)
				{
					num2 = 1634120068;
					continue;
				}
				goto IL_0104;
				IL_0368:
				if (JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues1.x, num7) && JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues1.y, num8))
				{
					return true;
				}
				if (JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues2.x, num7))
				{
					num2 = 1634120073;
					continue;
				}
				goto IL_02ac;
				IL_03c1:
				if (P_0.unityHat_sourceAxis2 != UnityAxis.None)
				{
					UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis1;
					unityHat_sourceAxis = P_0.unityHat_sourceAxis2;
					num7 = QEVsojLqDtQsxnvxgHocZSixiJS(unityHat_sourceAxis2);
					num8 = QEVsojLqDtQsxnvxgHocZSixiJS(unityHat_sourceAxis);
					if (P_0.unityHat_checkNeverPressed)
					{
						if (!nUeFezqoNQRolakbgoOOConpIyT(unityHat_sourceAxis2))
						{
							num2 = 1634120071;
							continue;
						}
						goto IL_044d;
					}
					goto IL_0471;
				}
				num2 = 1634120085;
				continue;
				IL_00e5:
				if (!oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.requiredButtons[num5]))
				{
					num2 = 1634120079;
					continue;
				}
				flag = true;
				num5++;
				num2 = 1634120081;
				continue;
				IL_014e:
				if (MathTools.Approximately(num7, x))
				{
					num2 = 1634120074;
					continue;
				}
				goto IL_0368;
				IL_01ad:
				int num9;
				if (num < P_0.ignoreIfButtonsActiveButtons.Length)
				{
					num2 = 1634120080;
					num9 = num2;
				}
				else
				{
					num2 = 1634120088;
					num9 = num2;
				}
				continue;
				IL_00b5:
				if (MathTools.Abs(num4) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					num2 = 1634120084;
					continue;
				}
				goto IL_0104;
				IL_044d:
				x = P_0.unityHat_zeroValues.x;
				y = P_0.unityHat_zeroValues.y;
				num2 = 1634120090;
				continue;
				IL_0471:
				x = P_0.unityHat_zeroValues.x;
				y = P_0.unityHat_zeroValues.y;
				num2 = 1634120090;
				continue;
				IL_035b:
				if (MathTools.Approximately(num8, y))
				{
					return false;
				}
				goto IL_0368;
				IL_0170:
				if (oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.ignoreIfButtonsActiveButtons[num]))
				{
					return false;
				}
				num++;
				num2 = 1634120066;
				continue;
				IL_0295:
				if (JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues2.y, num8))
				{
					return true;
				}
				goto IL_02ac;
				IL_012f:
				int num10;
				if (num5 < P_0.requiredButtons.Length)
				{
					num2 = 1634120095;
					num10 = num2;
				}
				else
				{
					num2 = 1634120093;
					num10 = num2;
				}
				continue;
				IL_0272:
				int num11;
				if (rRDjzRnCRRDIdADrIoiQoNdssoc(customCalculationSourceData[num3], out flag2))
				{
					num2 = 1634120076;
					num11 = num2;
				}
				else
				{
					num2 = 1634120089;
					num11 = num2;
				}
			}
			goto IL_0018;
			IL_056e:
			if (!customCalculation.Process())
			{
				return false;
			}
			if (customCalculation.Result.type != TypeWrapper.DataType.Single)
			{
				return false;
			}
			return (float)customCalculation.Result != 0f;
			IL_05a7:
			return false;
			IL_02ac:
			if (JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues3.x, num7) && JAErmqvBztkYNHMmRQcBfRempVw(P_0.unityHat_isActiveAxisValues3.y, num8))
			{
				return true;
			}
			goto IL_05a7;
		}

		private bool JAErmqvBztkYNHMmRQcBfRempVw(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float QEVsojLqDtQsxnvxgHocZSixiJS(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			int num;
			CustomCalculation customCalculation = default(CustomCalculation);
			HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = default(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[]);
			int num2 = default(int);
			bool key = default(bool);
			float result = default(float);
			float result3 = default(float);
			float result2 = default(float);
			switch (P_0.sourceType)
			{
			default:
				num = 854528729;
				goto IL_002f;
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					num = 854528720;
				}
				else
				{
					if (!oKAKkOrHJCSQdjvqMprroEgDqcJ(P_0.sourceButton))
					{
						return 0f;
					}
					int num5;
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						num = 854528725;
						num5 = num;
					}
					else
					{
						num = 854528731;
						num5 = num;
					}
				}
				goto IL_002f;
			case HardwareElementSourceTypeWithHat.Axis:
				goto IL_00a0;
			case HardwareElementSourceTypeWithHat.Custom:
				customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					num = 854528723;
				}
				else
				{
					num2 = 0;
					num = 854528705;
				}
				goto IL_002f;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				key = Input.GetKey(P_0.sourceKeyCode);
				num = 854528728;
				goto IL_002f;
			case HardwareElementSourceTypeWithHat.Hat:
				break;
				IL_00a0:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!nUeFezqoNQRolakbgoOOConpIyT(P_0.sourceAxis))
				{
					num = 854528735;
				}
				else
				{
					result = QEVsojLqDtQsxnvxgHocZSixiJS(P_0.sourceAxis);
					num = 854528724;
				}
				goto IL_002f;
				IL_002f:
				while (true)
				{
					switch (num ^ 0x32EF12D3)
					{
					case 2:
						break;
					case 7:
						return result;
					case 4:
						goto IL_00a0;
					case 16:
						num2++;
						num = 854528705;
						continue;
					case 3:
						return 0f;
					case 13:
						result3 = 1f;
						num = 854528704;
						continue;
					case 19:
						return result3;
					case 0:
						return 0f;
					case 17:
						num = 854528730;
						continue;
					case 8:
						result2 = -1f;
						num = 854528730;
						continue;
					case 9:
						return result2;
					case 12:
						return 0f;
					case 5:
					{
						if (SSAvaWGqpfYbxkPCzsJDWXzutnB(customCalculationSourceData[num2], out var item))
						{
							customCalculation.AddData(item);
							num = 854528707;
							continue;
						}
						goto case 16;
					}
					case 11:
						goto IL_01fa;
					case 18:
						if (num2 >= customCalculationSourceData.Length)
						{
							goto IL_0237;
						}
						goto case 1;
					case 14:
						result3 = -1f;
						num = 854528704;
						continue;
					case 6:
						result2 = 1f;
						num = 854528706;
						continue;
					case 1:
						if (customCalculationSourceData[num2] == null)
						{
							goto case 16;
						}
						goto IL_0279;
					default:
						return 0f;
					case 10:
						goto end_IL_000c;
					}
					break;
					IL_0237:
					if (!customCalculation.Process())
					{
						num = 854528732;
						continue;
					}
					goto IL_02a8;
					IL_01fa:
					if (!key)
					{
						return 0f;
					}
					int num3;
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						num = 854528734;
						num3 = num;
					}
					else
					{
						num = 854528733;
						num3 = num;
					}
					continue;
					IL_0279:
					HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[num2].sourceType;
					HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
					int num4;
					if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis)
					{
						num = 854528726;
						num4 = num;
					}
					else
					{
						num = 854528707;
						num4 = num;
					}
				}
				goto default;
				IL_02a8:
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
				end_IL_000c:
				break;
			}
			return 0f;
		}

		private float QEVsojLqDtQsxnvxgHocZSixiJS(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return MYTbiHEwyovpMjozyZoyqbgqbqZB[num];
		}

		private bool oKAKkOrHJCSQdjvqMprroEgDqcJ(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(EDcwRUJrjTccxnNnAhrMmqhjdqO, buttonIndex);
		}

		private bool rRDjzRnCRRDIdADrIoiQoNdssoc(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = oKAKkOrHJCSQdjvqMprroEgDqcJ(sourceElement);
			return true;
		}

		private bool jrNNouTaxtGQsUAhuoXKJIBCoal(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
		{
			P_1 = false;
			if (P_0.sourceType != 3)
			{
				return false;
			}
			KeyCode sourceElement = (KeyCode)P_0.sourceElement;
			if (sourceElement == KeyCode.None)
			{
				return false;
			}
			P_1 = Input.GetKey(sourceElement);
			return true;
		}

		private bool SSAvaWGqpfYbxkPCzsJDWXzutnB(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				goto IL_0010;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			int num = -321828215;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -321828223)
				{
				case 9:
					break;
				case 2:
					return false;
				case 1:
					if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
					{
						P_1 = 0f;
						num = -321828220;
						continue;
					}
					goto case 5;
				case 5:
					if (P_0.invert)
					{
						P_1 *= -1f;
						num = -321828222;
						continue;
					}
					goto default;
				case 4:
					if (P_1 < 0f)
					{
						P_1 = 0f;
						num = -321828224;
						continue;
					}
					goto case 1;
				case 6:
					goto IL_00c0;
				case 0:
					switch (P_0.sourceAxisRange)
					{
					case AxisRange.Positive:
						break;
					case AxisRange.Negative:
						goto IL_00c0;
					default:
						goto IL_00f1;
					}
					goto case 4;
				case 7:
					num = -321828224;
					continue;
				case 8:
					if (sourceElement == UnityAxis.None)
					{
						return false;
					}
					P_1 = QEVsojLqDtQsxnvxgHocZSixiJS(sourceElement);
					num = -321828223;
					continue;
				default:
					{
						return true;
					}
					IL_00f1:
					num = -321828218;
					continue;
					IL_00c0:
					if (P_1 > 0f)
					{
						P_1 = 0f;
						num = -321828224;
						continue;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -321828221;
			goto IL_0015;
		}

		private bool nUeFezqoNQRolakbgoOOConpIyT(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return pNsdvdfsyTXxfBtwJIySExDeNAKC[num];
		}

		private void XxHELBuvCCtGAJntxYQUzFBhOFy()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = NGITJKBCUwztnLMkPBVweIvQEACZ();
			if (UnityTools.isAndroidPlatform)
			{
				goto IL_0011;
			}
			goto IL_021b;
			IL_0011:
			int num = -512422914;
			goto IL_0016;
			IL_0016:
			List<int> vids = default(List<int>);
			int num2 = default(int);
			List<int> pids = default(List<int>);
			string text2 = default(string);
			IAndroidFallbackDS4Helper ds4Helper = default(IAndroidFallbackDS4Helper);
			while (true)
			{
				switch (num ^ -512422918)
				{
				case 13:
					break;
				case 20:
					bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
					num = -512422923;
					continue;
				case 12:
					goto IL_0094;
				case 8:
					goto IL_00b1;
				case 7:
					if (vids[num2] == 1118 && pids[num2] == 736)
					{
						bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
						num = -512422923;
						continue;
					}
					goto case 19;
				case 0:
					goto IL_0103;
				case 6:
					REZiFujnwfIcWniRKvMxDxhPHlx.controllerName = text2;
					num = -512422926;
					continue;
				case 16:
					goto IL_0148;
				case 22:
					num = -512422922;
					continue;
				case 10:
					goto IL_0187;
				case 4:
					goto IL_01da;
				case 3:
					goto IL_0200;
				case 15:
					goto IL_021b;
				case 18:
					ds4Helper = UnityTools.androidFallbackPlatformHelper.ds4Helper;
					num = -512422920;
					continue;
				case 9:
					UnityTools.externalTools.GetDeviceVIDPIDs(out vids, out pids);
					num = -512422913;
					continue;
				case 2:
					goto IL_0274;
				case 17:
				{
					string text = Regex.Replace(ZhqFGFeXGFfspKpKvhiTdSQSWt, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						REZiFujnwfIcWniRKvMxDxhPHlx.controllerName = text;
						num = -512422928;
						continue;
					}
					goto IL_0187;
				}
				case 1:
					bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
					num = -512422923;
					continue;
				case 14:
					return;
				case 21:
					num = -512422923;
					continue;
				case 5:
					num2 = 0;
					num = -512422932;
					continue;
				case 19:
					num2++;
					num = -512422922;
					continue;
				default:
					SeOhWaCQLSUYyhdokorrnPTrNGB = REZiFujnwfIcWniRKvMxDxhPHlx.buttonCount;
					return;
				}
				break;
				IL_0274:
				int num3;
				if (ds4Helper == null)
				{
					num = -512422923;
					num3 = num;
				}
				else
				{
					num = -512422934;
					num3 = num;
				}
				continue;
				IL_0094:
				int num4;
				if (num2 >= vids.Count)
				{
					num = -512422929;
					num4 = num;
				}
				else
				{
					num = -512422915;
					num4 = num;
				}
				continue;
				IL_01da:
				int num5;
				if (Regex.IsMatch(ZhqFGFeXGFfspKpKvhiTdSQSWt, "Xbox Wireless Controller.*"))
				{
					num = -512422925;
					num5 = num;
				}
				else
				{
					num = -512422919;
					num5 = num;
				}
				continue;
				IL_0200:
				int num6;
				if (UnityTools.androidFallbackPlatformHelper == null)
				{
					num = -512422923;
					num6 = num;
				}
				else
				{
					num = -512422936;
					num6 = num;
				}
				continue;
				IL_0148:
				if (ds4Helper.IsDS4(ZhqFGFeXGFfspKpKvhiTdSQSWt))
				{
					int num7;
					if (!ds4Helper.IsDS4KeyMapped(JWlyBuqNEfjGChcttNidSemqTVV))
					{
						num = -512422917;
						num7 = num;
					}
					else
					{
						num = -512422930;
						num7 = num;
					}
					continue;
				}
				goto IL_021b;
			}
			goto IL_0011;
			IL_0187:
			if (UnityTools.isIOSPlatform && REZiFujnwfIcWniRKvMxDxhPHlx.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				text2 = StQaXKtjPuyFIZtrldfsDnHOMyU(ZhqFGFeXGFfspKpKvhiTdSQSWt);
				int num8;
				if (string.IsNullOrEmpty(text2))
				{
					num = -512422926;
					num8 = num;
				}
				else
				{
					num = -512422916;
					num8 = num;
				}
				goto IL_0016;
			}
			goto IL_00b1;
			IL_021b:
			REZiFujnwfIcWniRKvMxDxhPHlx = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				num = -512422924;
				goto IL_0016;
			}
			goto IL_0103;
			IL_0103:
			if (REZiFujnwfIcWniRKvMxDxhPHlx.useSystemName)
			{
				int num9;
				if (!string.IsNullOrEmpty(ZhqFGFeXGFfspKpKvhiTdSQSWt))
				{
					num = -512422933;
					num9 = num;
				}
				else
				{
					num = -512422928;
					num9 = num;
				}
				goto IL_0016;
			}
			goto IL_0187;
			IL_00b1:
			RGhWgMAfPjfICjXGWTZxnPoNdWD = REZiFujnwfIcWniRKvMxDxhPHlx.axisCount;
			num = -512422927;
			goto IL_0016;
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
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{XMCAPkwsxgrVIvcNAMydmmXHkOV().ToString()}{ZhqFGFeXGFfspKpKvhiTdSQSWt}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(ZhqFGFeXGFfspKpKvhiTdSQSWt, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{XMCAPkwsxgrVIvcNAMydmmXHkOV().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{XMCAPkwsxgrVIvcNAMydmmXHkOV().ToString()}{ZhqFGFeXGFfspKpKvhiTdSQSWt}");
		}

		private InputSource XMCAPkwsxgrVIvcNAMydmmXHkOV()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(ZhqFGFeXGFfspKpKvhiTdSQSWt))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int ehhMYpWNAIOMCksfriRCZCIBJmK(nwXgurhtCFvedRYXAPczDqoZXlg P_0, nwXgurhtCFvedRYXAPczDqoZXlg P_1)
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

		public static int kAfKgqngcNrlauQJovLotuRWWQL(nwXgurhtCFvedRYXAPczDqoZXlg P_0, nwXgurhtCFvedRYXAPczDqoZXlg P_1)
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

		private static string StQaXKtjPuyFIZtrldfsDnHOMyU(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				while (true)
				{
					int num = -1807668232;
					while (true)
					{
						switch (num ^ -1807668231)
						{
						case 2:
							break;
						case 1:
							input = input.Trim();
							num = -1807668231;
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

	private class PryDqtABWuaaxijSFPWDtMXUdrmw
	{
		public enum oXGDdreWaOoyHzCElfiPInJTGxy
		{
			zlJMCEeCIoRemLBsAgqNdRDgziDK = 0,
			BKFaaxAPcuBcJAcYJSBDkcEuaeHB = 1
		}

		public class duNiNiXBHexUIvnXhFUCeboEDDe
		{
			public int UKCDHORBCFHBoYLTIFGoDfJwMEGs;

			public int JWlyBuqNEfjGChcttNidSemqTVV;

			public string WiWNmcNXUQMISiVDOAtiXWTRbUC;

			public int MrgFvxEmVvleAtwmEJiJFGTJUZgS;

			public string gEEhLyWTpHycofvBbLWplFWteOZ;

			public bool YfzaYuFFeAGpZYIlhOCKodCcBwd(nwXgurhtCFvedRYXAPczDqoZXlg P_0, oXGDdreWaOoyHzCElfiPInJTGxy P_1)
			{
				if (P_0.rewiredId == UKCDHORBCFHBoYLTIFGoDfJwMEGs)
				{
					return true;
				}
				if (!string.IsNullOrEmpty(gEEhLyWTpHycofvBbLWplFWteOZ))
				{
					goto IL_0050;
				}
				if (!string.IsNullOrEmpty(P_0.gEEhLyWTpHycofvBbLWplFWteOZ))
				{
					goto IL_002a;
				}
				goto IL_008c;
				IL_008c:
				int num;
				if (P_1 != oXGDdreWaOoyHzCElfiPInJTGxy.zlJMCEeCIoRemLBsAgqNdRDgziDK)
				{
					if (P_1 != oXGDdreWaOoyHzCElfiPInJTGxy.BKFaaxAPcuBcJAcYJSBDkcEuaeHB)
					{
						throw new NotImplementedException();
					}
					num = -1526357666;
				}
				else
				{
					if (JWlyBuqNEfjGChcttNidSemqTVV != P_0.JWlyBuqNEfjGChcttNidSemqTVV)
					{
						return false;
					}
					num = -1526357667;
				}
				goto IL_002f;
				IL_0050:
				if (!string.Equals(gEEhLyWTpHycofvBbLWplFWteOZ, P_0.gEEhLyWTpHycofvBbLWplFWteOZ, StringComparison.Ordinal))
				{
					num = -1526357665;
					goto IL_002f;
				}
				goto IL_008c;
				IL_002a:
				num = -1526357672;
				goto IL_002f;
				IL_002f:
				switch (num ^ -1526357668)
				{
				case 0:
					break;
				case 4:
					goto IL_0050;
				case 1:
					return WiWNmcNXUQMISiVDOAtiXWTRbUC == P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt;
				case 3:
					return false;
				default:
					return WiWNmcNXUQMISiVDOAtiXWTRbUC == P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt;
				}
				goto IL_002a;
			}
		}

		private sealed class tIVdHeefhmMHndVEbDOCgKQDfPKG : IDisposable, IEnumerator, IEnumerable, IEnumerable<duNiNiXBHexUIvnXhFUCeboEDDe>, IEnumerator<duNiNiXBHexUIvnXhFUCeboEDDe>
		{
			private duNiNiXBHexUIvnXhFUCeboEDDe ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public PryDqtABWuaaxijSFPWDtMXUdrmw syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public nwXgurhtCFvedRYXAPczDqoZXlg GHCGdCDbjrofHQLylQoSJOXGrsCj;

			public nwXgurhtCFvedRYXAPczDqoZXlg kBIDOXdTvkXDGsXBIDEoXEkSifNc;

			public oXGDdreWaOoyHzCElfiPInJTGxy deDQMJLHHfbmUIovbnujIcUjOUK;

			public oXGDdreWaOoyHzCElfiPInJTGxy DjGvqohErCEFaeFNfFegiWUXHde;

			public int tJWBKFXVQoaBvNgXagHdWqffeeO;

			public int WhgwdOUlEIMyBTjrFhGbNEbNklB;

			duNiNiXBHexUIvnXhFUCeboEDDe IEnumerator<duNiNiXBHexUIvnXhFUCeboEDDe>.Current
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
			IEnumerator<duNiNiXBHexUIvnXhFUCeboEDDe> IEnumerable<duNiNiXBHexUIvnXhFUCeboEDDe>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId != TFdbdCIUKXTQPHFlNuiMVnWNXiVT || isaqVUvqwfWYqOUtovbpbCbxgPc != -2)
				{
					goto IL_0049;
				}
				isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
				tIVdHeefhmMHndVEbDOCgKQDfPKG tIVdHeefhmMHndVEbDOCgKQDfPKG2 = this;
				goto IL_0063;
				IL_002c:
				int num;
				while (true)
				{
					switch (num ^ 0x4D15B49E)
					{
					case 3:
						num = 1293268127;
						continue;
					case 1:
						break;
					case 2:
						goto IL_0063;
					default:
						return tIVdHeefhmMHndVEbDOCgKQDfPKG2;
					}
					break;
				}
				goto IL_0049;
				IL_0049:
				tIVdHeefhmMHndVEbDOCgKQDfPKG2 = new tIVdHeefhmMHndVEbDOCgKQDfPKG(0);
				tIVdHeefhmMHndVEbDOCgKQDfPKG2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1293268124;
				goto IL_002c;
				IL_0063:
				tIVdHeefhmMHndVEbDOCgKQDfPKG2.GHCGdCDbjrofHQLylQoSJOXGrsCj = kBIDOXdTvkXDGsXBIDEoXEkSifNc;
				tIVdHeefhmMHndVEbDOCgKQDfPKG2.deDQMJLHHfbmUIovbnujIcUjOUK = DjGvqohErCEFaeFNfFegiWUXHde;
				num = 1293268126;
				goto IL_002c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<duNiNiXBHexUIvnXhFUCeboEDDe>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = -805668035;
					goto IL_001f;
				case 0:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						tJWBKFXVQoaBvNgXagHdWqffeeO = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO.Count;
						num = -805668036;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -805668039)
						{
						case 7:
							num = -805668040;
							continue;
						case 4:
							WhgwdOUlEIMyBTjrFhGbNEbNklB++;
							num = -805668038;
							continue;
						case 0:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[WhgwdOUlEIMyBTjrFhGbNEbNklB];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 1:
							break;
						case 3:
							goto IL_00be;
						case 2:
							goto IL_00e0;
						case 5:
							WhgwdOUlEIMyBTjrFhGbNEbNklB = 0;
							num = -805668038;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00e0:
						int num2;
						if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv.pYylSnaZhhHPlmcssGUseHaIflO[WhgwdOUlEIMyBTjrFhGbNEbNklB].YfzaYuFFeAGpZYIlhOCKodCcBwd(GHCGdCDbjrofHQLylQoSJOXGrsCj, deDQMJLHHfbmUIovbnujIcUjOUK))
						{
							num = -805668035;
							num2 = num;
						}
						else
						{
							num = -805668039;
							num2 = num;
						}
						continue;
						IL_00be:
						int num3;
						if (WhgwdOUlEIMyBTjrFhGbNEbNklB >= tJWBKFXVQoaBvNgXagHdWqffeeO)
						{
							num = -805668033;
							num3 = num;
						}
						else
						{
							num = -805668037;
							num3 = num;
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
			public tIVdHeefhmMHndVEbDOCgKQDfPKG(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<duNiNiXBHexUIvnXhFUCeboEDDe> pYylSnaZhhHPlmcssGUseHaIflO;

		public int Count => pYylSnaZhhHPlmcssGUseHaIflO.Count;

		public PryDqtABWuaaxijSFPWDtMXUdrmw()
		{
			pYylSnaZhhHPlmcssGUseHaIflO = new List<duNiNiXBHexUIvnXhFUCeboEDDe>();
		}

		public void tXgmibXCLFITLeBlRtsWPalapKpT(nwXgurhtCFvedRYXAPczDqoZXlg P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
				int num = 0;
				int num2 = 1240632392;
				while (true)
				{
					switch (num2 ^ 0x49F28C48)
					{
					case 4:
						num2 = 1240632393;
						continue;
					default:
						return;
					case 1:
						break;
					case 6:
						pYylSnaZhhHPlmcssGUseHaIflO.Add(new duNiNiXBHexUIvnXhFUCeboEDDe
						{
							UKCDHORBCFHBoYLTIFGoDfJwMEGs = P_0.rewiredId,
							WiWNmcNXUQMISiVDOAtiXWTRbUC = P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt,
							JWlyBuqNEfjGChcttNidSemqTVV = P_0.JWlyBuqNEfjGChcttNidSemqTVV,
							MrgFvxEmVvleAtwmEJiJFGTJUZgS = P_0.inputManagerId,
							gEEhLyWTpHycofvBbLWplFWteOZ = P_0.gEEhLyWTpHycofvBbLWplFWteOZ
						});
						DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, pYylSnaZhhHPlmcssGUseHaIflO.Count - 1);
						num2 = 1240632395;
						continue;
					case 0:
					{
						int num3;
						if (num < count)
						{
							num2 = 1240632397;
							num3 = num2;
						}
						else
						{
							num2 = 1240632398;
							num3 = num2;
						}
						continue;
					}
					case 5:
						if (pYylSnaZhhHPlmcssGUseHaIflO[num].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, oXGDdreWaOoyHzCElfiPInJTGxy.zlJMCEeCIoRemLBsAgqNdRDgziDK))
						{
							pYylSnaZhhHPlmcssGUseHaIflO[num].UKCDHORBCFHBoYLTIFGoDfJwMEGs = P_0.rewiredId;
							pYylSnaZhhHPlmcssGUseHaIflO[num].WiWNmcNXUQMISiVDOAtiXWTRbUC = P_0.ZhqFGFeXGFfspKpKvhiTdSQSWt;
							pYylSnaZhhHPlmcssGUseHaIflO[num].JWlyBuqNEfjGChcttNidSemqTVV = P_0.JWlyBuqNEfjGChcttNidSemqTVV;
							pYylSnaZhhHPlmcssGUseHaIflO[num].MrgFvxEmVvleAtwmEJiJFGTJUZgS = P_0.inputManagerId;
							pYylSnaZhhHPlmcssGUseHaIflO[num].gEEhLyWTpHycofvBbLWplFWteOZ = P_0.gEEhLyWTpHycofvBbLWplFWteOZ;
							DEiihYzBOuDCWDVSMxebepjOOeX(P_0.rewiredId, num);
							return;
						}
						goto case 2;
					case 2:
						num++;
						num2 = 1240632392;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public bool QUzJIwsyLBGiiDjdziRDeDUvrEq(nwXgurhtCFvedRYXAPczDqoZXlg P_0, oXGDdreWaOoyHzCElfiPInJTGxy P_1)
		{
			int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
			int num = 0;
			while (num < count)
			{
				while (true)
				{
					int num2;
					if (pYylSnaZhhHPlmcssGUseHaIflO[num].YfzaYuFFeAGpZYIlhOCKodCcBwd(P_0, P_1))
					{
						num2 = -423738232;
					}
					else
					{
						num++;
						num2 = -423738231;
					}
					while (true)
					{
						switch (num2 ^ -423738231)
						{
						case 3:
							num2 = -423738229;
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

		public IEnumerable<duNiNiXBHexUIvnXhFUCeboEDDe> ujuphkmYzsIfimEfOMVCHtLnQKt(nwXgurhtCFvedRYXAPczDqoZXlg P_0, oXGDdreWaOoyHzCElfiPInJTGxy P_1)
		{
			tIVdHeefhmMHndVEbDOCgKQDfPKG tIVdHeefhmMHndVEbDOCgKQDfPKG2 = new tIVdHeefhmMHndVEbDOCgKQDfPKG(-2);
			tIVdHeefhmMHndVEbDOCgKQDfPKG2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			tIVdHeefhmMHndVEbDOCgKQDfPKG2.kBIDOXdTvkXDGsXBIDEoXEkSifNc = P_0;
			tIVdHeefhmMHndVEbDOCgKQDfPKG2.DjGvqohErCEFaeFNfFegiWUXHde = P_1;
			return tIVdHeefhmMHndVEbDOCgKQDfPKG2;
		}

		public int KhufsiHazfkStoHkXbcGhTzBsNFW(duNiNiXBHexUIvnXhFUCeboEDDe P_0)
		{
			int count = pYylSnaZhhHPlmcssGUseHaIflO.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -1945920531;
				while (true)
				{
					switch (num ^ -1945920529)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = -1945920530;
						continue;
					case 4:
						if (pYylSnaZhhHPlmcssGUseHaIflO[num2] == P_0)
						{
							return num2;
						}
						num2++;
						num = -1945920530;
						continue;
					case 1:
					{
						int num3;
						if (num2 >= count)
						{
							num = -1945920532;
							num3 = num;
						}
						else
						{
							num = -1945920533;
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

		private void DEiihYzBOuDCWDVSMxebepjOOeX(int P_0, int P_1)
		{
			int num = pYylSnaZhhHPlmcssGUseHaIflO.Count - 1;
			while (true)
			{
				int num2 = 1010065129;
				while (true)
				{
					switch (num2 ^ 0x3C345EEC)
					{
					case 4:
						break;
					case 3:
						num--;
						num2 = 1010065133;
						continue;
					case 2:
						pYylSnaZhhHPlmcssGUseHaIflO.RemoveAt(num);
						num2 = 1010065135;
						continue;
					case 0:
						if (num != P_1)
						{
							int num3;
							if (pYylSnaZhhHPlmcssGUseHaIflO[num].UKCDHORBCFHBoYLTIFGoDfJwMEGs == P_0)
							{
								num2 = 1010065134;
								num3 = num2;
							}
							else
							{
								num2 = 1010065135;
								num3 = num2;
							}
							continue;
						}
						goto case 3;
					case 5:
						num2 = 1010065133;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}
	}

	private List<nwXgurhtCFvedRYXAPczDqoZXlg> KjXmBSVldpfwjiNaozEQFsyjEtD;

	private int zCJDBcHESKfNGvcIMmoYVGihyIj;

	private PryDqtABWuaaxijSFPWDtMXUdrmw ZDGzEdGlsfPIXxxIiRhCInujjGU;

	private bool VjAUYAWOZYRvlAZvsjAqxlszqGZ;

	private bool DsxHwkjezpCSRcDXXpxTLpDncEqC;

	private UpdateLoopType vuGbLgVYuadXzhzNZHvlhRNLlqP;

	private UpdateLoopType FkqfeKVDJDBbnJWyWzbNqaonAQm;

	private TimerAbs jwGRLLmVawoxIvuOGajmHacICvN;

	private Action<int, ControllerDataUpdater> QwkejmzJqWXCTBNLCkdLqDDUJzf;

	private PlatformInputManager UkMXWLCIyaKLnYPfeWzjKwidlAk;

	private readonly IUnifiedKeyboardSource MLJGfiifzcvWnIrgODHQoQFaxiP;

	private readonly IUnifiedMouseSource mFFcQtVRysgHQDkpmacpTNZnZsP;

	private bool ksVEFrfplQkadieqAbiaXQewkLYK;

	private string[] AbUhWqDrZkUacyBCXnyQmHYKhCx;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => zCJDBcHESKfNGvcIMmoYVGihyIj;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => UkMXWLCIyaKLnYPfeWzjKwidlAk;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.Fallback;

	public qePDAvGeOBieqfeOibcNbUsuVSqM(UpdateLoopSetting updateLoopSetting)
	{
		UkMXWLCIyaKLnYPfeWzjKwidlAk = this;
		MLJGfiifzcvWnIrgODHQoQFaxiP = new UnityUnifiedKeyboardSource();
		mFFcQtVRysgHQDkpmacpTNZnZsP = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			int num = 0;
			if (num < list.Count)
			{
				FkqfeKVDJDBbnJWyWzbNqaonAQm = list[num];
			}
		}
		AbUhWqDrZkUacyBCXnyQmHYKhCx = new string[0];
		QwkejmzJqWXCTBNLCkdLqDDUJzf = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform)
		{
			while (true)
			{
				int num = 1114744634;
				while (true)
				{
					switch (num ^ 0x4271A73B)
					{
					case 0:
						break;
					case 1:
						if (UnityTools.androidFallbackPlatformHelper != null)
						{
							UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent += IWbWHJNuFbqbksMOvChrRYBpnIw;
							num = 1114744633;
							continue;
						}
						goto end_IL_0007;
					default:
						goto end_IL_0007;
					}
					break;
				}
				continue;
				end_IL_0007:
				break;
			}
		}
		jwGRLLmVawoxIvuOGajmHacICvN = new TimerAbs(1.0);
		ZDGzEdGlsfPIXxxIiRhCInujjGU = new PryDqtABWuaaxijSFPWDtMXUdrmw();
		YAYLplglEiMaFnRMMiGNmldzCmUa();
		VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
		jwGRLLmVawoxIvuOGajmHacICvN.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		vuGbLgVYuadXzhzNZHvlhRNLlqP = updateLoop;
		MlSvoFrbdqmZkMWjiKVHsJGvavX();
		while (true)
		{
			int num = -2019061239;
			while (true)
			{
				switch (num ^ -2019061237)
				{
				case 0:
					break;
				case 2:
					if (VjAUYAWOZYRvlAZvsjAqxlszqGZ)
					{
						goto IL_0033;
					}
					goto default;
				default:
					jqvaloCvHNpVrQxERwhVWaVTZgBw(updateLoop);
					return;
				}
				break;
				IL_0033:
				MFhjbGVDbNrOVBNutDpnZUWGDEP();
				num = -2019061238;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
		{
			UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent -= IWbWHJNuFbqbksMOvChrRYBpnIw;
		}
		(MLJGfiifzcvWnIrgODHQoQFaxiP as IDisposable).Dispose();
		(mFFcQtVRysgHQDkpmacpTNZnZsP as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return QwkejmzJqWXCTBNLCkdLqDDUJzf;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		int num = 0;
		while (true)
		{
			int num2 = -988039879;
			while (true)
			{
				switch (num2 ^ -988039877)
				{
				case 3:
					break;
				case 2:
					num2 = -988039873;
					continue;
				case 5:
				{
					int num3;
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num].inputManagerId != assignedControllerId)
					{
						num2 = -988039878;
						num3 = num2;
					}
					else
					{
						num2 = -988039877;
						num3 = num2;
					}
					continue;
				}
				case 0:
					KjXmBSVldpfwjiNaozEQFsyjEtD[num].FillData(data);
					return;
				case 1:
					num++;
					num2 = -988039873;
					continue;
				default:
					if (num >= zCJDBcHESKfNGvcIMmoYVGihyIj)
					{
						Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
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
		VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
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
			int num = 686925787;
			while (true)
			{
				switch (num ^ 0x28F1A7DA)
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
				num = 686925786;
			}
		}
	}

	private void IWbWHJNuFbqbksMOvChrRYBpnIw()
	{
		VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
		DsxHwkjezpCSRcDXXpxTLpDncEqC = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		int num = 0;
		int num4 = default(int);
		while (true)
		{
			int num2;
			int num3;
			if (num >= KjXmBSVldpfwjiNaozEQFsyjEtD.Count)
			{
				num2 = -1461775340;
				num3 = num2;
			}
			else
			{
				num2 = -1461775336;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ -1461775332)
				{
				case 7:
					num2 = -1461775336;
					continue;
				case 4:
				{
					int num5;
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num].unityId != unityJoystickId)
					{
						num2 = -1461775334;
						num5 = num2;
					}
					else
					{
						num2 = -1461775339;
						num5 = num2;
					}
					continue;
				}
				case 0:
					return;
				case 8:
					num4 = 0;
					num2 = -1461775330;
					continue;
				case 3:
					break;
				case 1:
					num4++;
					num2 = -1461775330;
					continue;
				case 9:
					KjXmBSVldpfwjiNaozEQFsyjEtD[num].YqisevZTpjxqYbEnXlwcGIObmPO();
					num2 = -1461775334;
					continue;
				case 5:
					if (KjXmBSVldpfwjiNaozEQFsyjEtD[num4].rewiredId == joystickId)
					{
						KjXmBSVldpfwjiNaozEQFsyjEtD[num4].tIprUyVwwtOoVfGVyGApjLOwlofu(unityJoystickId);
						num2 = -1461775332;
						continue;
					}
					goto case 1;
				case 6:
					num++;
					num2 = -1461775329;
					continue;
				default:
					if (num4 >= KjXmBSVldpfwjiNaozEQFsyjEtD.Count)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return mFFcQtVRysgHQDkpmacpTNZnZsP;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return MLJGfiifzcvWnIrgODHQoQFaxiP;
	}

	private void YAYLplglEiMaFnRMMiGNmldzCmUa()
	{
		YAYLplglEiMaFnRMMiGNmldzCmUa(Input.GetJoystickNames());
	}

	private void YAYLplglEiMaFnRMMiGNmldzCmUa(string[] P_0)
	{
		int num = 0;
		int num5 = default(int);
		int num3 = default(int);
		nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg2 = default(nwXgurhtCFvedRYXAPczDqoZXlg);
		string text = default(string);
		int num4 = default(int);
		List<nwXgurhtCFvedRYXAPczDqoZXlg> kjXmBSVldpfwjiNaozEQFsyjEtD = default(List<nwXgurhtCFvedRYXAPczDqoZXlg>);
		while (true)
		{
			int num2 = -246665320;
			while (true)
			{
				switch (num2 ^ -246665324)
				{
				case 10:
					break;
				case 0:
					if (num5 >= P_0.Length)
					{
						zCJDBcHESKfNGvcIMmoYVGihyIj = num;
						num2 = -246665313;
						continue;
					}
					goto case 5;
				case 13:
					num2 = -246665324;
					continue;
				case 3:
					if (_UpdateControllerInfoEvent != null)
					{
						_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(KjXmBSVldpfwjiNaozEQFsyjEtD[num3]));
						num2 = -246665316;
						continue;
					}
					goto case 8;
				case 6:
					num5++;
					num2 = -246665324;
					continue;
				case 9:
					nwXgurhtCFvedRYXAPczDqoZXlg2.ZhqFGFeXGFfspKpKvhiTdSQSWt = text;
					nwXgurhtCFvedRYXAPczDqoZXlg2.mcAwKArXqdrIEFSsaspMyuTeuTS = text;
					num2 = -246665328;
					continue;
				case 4:
					nwXgurhtCFvedRYXAPczDqoZXlg2.JWlyBuqNEfjGChcttNidSemqTVV = num5;
					nwXgurhtCFvedRYXAPczDqoZXlg2.unityId = num5 + 1;
					if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
					{
						nwXgurhtCFvedRYXAPczDqoZXlg2.gEEhLyWTpHycofvBbLWplFWteOZ = UnityTools.androidFallbackPlatformHelper.GetUniqueDeviceIdentifier(text, num5);
						num2 = -246665322;
						continue;
					}
					goto case 2;
				case 8:
					num3++;
					num2 = -246665325;
					continue;
				case 11:
					WBFBlruLRCLpAZLkknTLUfchufi(num4, num, kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD);
					num3 = 0;
					num2 = -246665325;
					continue;
				case 12:
					kjXmBSVldpfwjiNaozEQFsyjEtD = KjXmBSVldpfwjiNaozEQFsyjEtD;
					num4 = zCJDBcHESKfNGvcIMmoYVGihyIj;
					KjXmBSVldpfwjiNaozEQFsyjEtD = new List<nwXgurhtCFvedRYXAPczDqoZXlg>();
					num5 = 0;
					num2 = -246665319;
					continue;
				case 5:
					text = StringTools.SanitizeDeviceString(P_0[num5]);
					if (UnityTools.IsValidUnityJoystickName(text))
					{
						nwXgurhtCFvedRYXAPczDqoZXlg2 = new nwXgurhtCFvedRYXAPczDqoZXlg();
						num2 = -246665315;
						continue;
					}
					goto case 6;
				case 2:
					nwXgurhtCFvedRYXAPczDqoZXlg2.kfcRhmfnfWicmjTenihbZSYGYjYh();
					num2 = -246665323;
					continue;
				case 1:
					KjXmBSVldpfwjiNaozEQFsyjEtD.Add(nwXgurhtCFvedRYXAPczDqoZXlg2);
					num++;
					num2 = -246665326;
					continue;
				default:
					if (num3 >= num)
					{
						DvAgAsBJXkezynrKQNPnZfxrsAT(kjXmBSVldpfwjiNaozEQFsyjEtD, KjXmBSVldpfwjiNaozEQFsyjEtD, false);
						DvAgAsBJXkezynrKQNPnZfxrsAT(KjXmBSVldpfwjiNaozEQFsyjEtD, kjXmBSVldpfwjiNaozEQFsyjEtD, true);
						AbUhWqDrZkUacyBCXnyQmHYKhCx = P_0;
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private void jqvaloCvHNpVrQxERwhVWaVTZgBw(UpdateLoopType P_0)
	{
		int count = KjXmBSVldpfwjiNaozEQFsyjEtD.Count;
		int num = 0;
		while (num < count)
		{
			while (true)
			{
				int num2;
				int num3;
				if (KjXmBSVldpfwjiNaozEQFsyjEtD[num] == null)
				{
					num2 = -1363471397;
					num3 = num2;
				}
				else
				{
					num2 = -1363471395;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1363471399)
					{
					case 3:
						num2 = -1363471400;
						continue;
					case 1:
						break;
					case 2:
						num++;
						num2 = -1363471399;
						continue;
					case 4:
						KjXmBSVldpfwjiNaozEQFsyjEtD[num].Update();
						num2 = -1363471397;
						continue;
					default:
						goto end_IL_0036;
					}
					break;
				}
				continue;
				end_IL_0036:
				break;
			}
		}
	}

	private void WBFBlruLRCLpAZLkknTLUfchufi(int P_0, int P_1, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_2, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(nwXgurhtCFvedRYXAPczDqoZXlg.kAfKgqngcNrlauQJovLotuRWWQL);
			goto IL_001a;
		}
		goto IL_0087;
		IL_0087:
		int num;
		if (P_0 > 0)
		{
			num = 792970875;
			goto IL_001f;
		}
		int num2 = 0;
		goto IL_00e3;
		IL_001a:
		num = 792970877;
		goto IL_001f;
		IL_001f:
		bool flag = default(bool);
		int num3 = default(int);
		nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg2 = default(nwXgurhtCFvedRYXAPczDqoZXlg);
		while (true)
		{
			switch (num ^ 0x2F43C67B)
			{
			case 4:
				break;
			case 2:
				if (flag)
				{
					WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy.zlJMCEeCIoRemLBsAgqNdRDgziDK);
					WWBpSaLxuMDBckrvrBppKtPxZoIQ(P_1, P_3, P_0, P_2, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
					num = 792970872;
					continue;
				}
				goto case 3;
			case 9:
				num3++;
				num = 792970867;
				continue;
			case 6:
				goto IL_0087;
			case 1:
				nwXgurhtCFvedRYXAPczDqoZXlg2 = P_3[num3];
				if (nwXgurhtCFvedRYXAPczDqoZXlg2 == null)
				{
					goto case 9;
				}
				goto IL_009e;
			case 5:
				nwXgurhtCFvedRYXAPczDqoZXlg2.rewiredId = ReInput.GetNewJoystickId();
				ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(nwXgurhtCFvedRYXAPczDqoZXlg2);
				num = 792970866;
				continue;
			case 0:
				goto IL_00dc;
			case 3:
				IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy.zlJMCEeCIoRemLBsAgqNdRDgziDK);
				IrBuLLxHFdDknWWFKqrzDdBoboV(P_1, P_3, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy.BKFaaxAPcuBcJAcYJSBDkcEuaeHB);
				num3 = 0;
				num = 792970867;
				continue;
			case 7:
				nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_3);
				num = 792970878;
				continue;
			default:
				if (num3 >= P_1)
				{
					P_3.Sort(nwXgurhtCFvedRYXAPczDqoZXlg.ehhMYpWNAIOMCksfriRCZCIBJmK);
					return;
				}
				goto case 1;
			}
			break;
			IL_009e:
			int num4;
			if (nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId < 0)
			{
				num = 792970876;
				num4 = num;
			}
			else
			{
				num = 792970866;
				num4 = num;
			}
		}
		goto IL_001a;
		IL_00dc:
		num2 = ((P_1 > 0) ? 1 : 0);
		goto IL_00e3;
		IL_00e3:
		flag = (byte)num2 != 0;
		num = 792970873;
		goto IL_001f;
	}

	private void bAaaRABRdZwxMnddEjixrGLYNAe(List<nwXgurhtCFvedRYXAPczDqoZXlg> P_0, int P_1, int P_2)
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
					num2 = 1415173184;
					num3 = num2;
				}
				else
				{
					num2 = 1415173188;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5459D445)
					{
					case 0:
						num2 = 1415173191;
						continue;
					case 3:
						P_0[num].inputManagerId = -1;
						num2 = 1415173184;
						continue;
					case 1:
						if (P_0[num] != null)
						{
							goto IL_0055;
						}
						goto case 5;
					case 2:
						break;
					case 5:
						num++;
						num2 = 1415173185;
						continue;
					default:
						goto end_IL_0075;
					}
					break;
					IL_0055:
					int num4;
					if (P_0[num].inputManagerId == P_2)
					{
						num2 = 1415173190;
						num4 = num2;
					}
					else
					{
						num2 = 1415173184;
						num4 = num2;
					}
				}
				continue;
				end_IL_0075:
				break;
			}
		}
	}

	private bool pgNWowjBpVDUsfPflzUQpiDLSMiQ(List<nwXgurhtCFvedRYXAPczDqoZXlg> P_0, int P_1)
	{
		int count = P_0.Count;
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < count)
			{
				num2 = 2091130514;
				num3 = num2;
			}
			else
			{
				num2 = 2091130515;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x7CA41E93)
				{
				case 3:
					num2 = 2091130514;
					continue;
				case 1:
					if (P_0[num] != null && P_0[num].inputManagerId == P_1)
					{
						return false;
					}
					num++;
					num2 = 2091130513;
					continue;
				case 2:
					break;
				default:
					return true;
				}
				break;
			}
		}
	}

	private int xsxJptmMPnqGtRxSuBrOBHkSWsg(List<nwXgurhtCFvedRYXAPczDqoZXlg> P_0)
	{
		int num = 0;
		int num3 = default(int);
		int count = default(int);
		bool flag = default(bool);
		while (true)
		{
			int num2 = 2015866798;
			while (true)
			{
				switch (num2 ^ 0x7827AFAF)
				{
				case 3:
					break;
				case 4:
					num3++;
					num2 = 2015866799;
					continue;
				case 0:
				{
					int num4;
					if (num3 >= count)
					{
						num2 = 2015866797;
						num4 = num2;
					}
					else
					{
						num2 = 2015866794;
						num4 = num2;
					}
					continue;
				}
				case 1:
					flag = false;
					count = P_0.Count;
					num3 = 0;
					num2 = 2015866799;
					continue;
				case 5:
					if (P_0[num3] != null && P_0[num3].inputManagerId == num)
					{
						flag = true;
						num2 = 2015866797;
						continue;
					}
					goto case 4;
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

	private bool tDUJWQkhxomwvbhOaOoQeAWVFSH(List<nwXgurhtCFvedRYXAPczDqoZXlg> P_0, int P_1)
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
				int num2 = 488970160;
				while (true)
				{
					switch (num2 ^ 0x1D2517B0)
					{
					case 2:
						num2 = 488970161;
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

	private void WWBpSaLxuMDBckrvrBppKtPxZoIQ(int P_0, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_1, int P_2, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_3, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy P_4)
	{
		int num = ((P_4 != PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy.zlJMCEeCIoRemLBsAgqNdRDgziDK) ? 1 : 2);
		int num2 = 0;
		nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg3 = default(nwXgurhtCFvedRYXAPczDqoZXlg);
		int num5 = default(int);
		while (num2 < P_0)
		{
			while (true)
			{
				IL_013a:
				nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg2 = P_1[num2];
				int num3;
				if (nwXgurhtCFvedRYXAPczDqoZXlg2 != null)
				{
					int num4;
					if (nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId < 0)
					{
						num3 = -705700962;
						num4 = num3;
					}
					else
					{
						num3 = -705700973;
						num4 = num3;
					}
					goto IL_0015;
				}
				goto IL_010a;
				IL_0015:
				while (true)
				{
					switch (num3 ^ -705700966)
					{
					case 5:
						num3 = -705700967;
						continue;
					case 10:
						nwXgurhtCFvedRYXAPczDqoZXlg2.unityId = nwXgurhtCFvedRYXAPczDqoZXlg3.unityId;
						num3 = -705700964;
						continue;
					case 8:
						if (nwXgurhtCFvedRYXAPczDqoZXlg2.YfzaYuFFeAGpZYIlhOCKodCcBwd(nwXgurhtCFvedRYXAPczDqoZXlg3) < num)
						{
							goto case 1;
						}
						nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId = nwXgurhtCFvedRYXAPczDqoZXlg3.inputManagerId;
						nwXgurhtCFvedRYXAPczDqoZXlg2.rewiredId = nwXgurhtCFvedRYXAPczDqoZXlg3.rewiredId;
						if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform)
						{
							goto IL_0097;
						}
						goto case 6;
					case 7:
						nwXgurhtCFvedRYXAPczDqoZXlg3 = P_3[num5];
						if (nwXgurhtCFvedRYXAPczDqoZXlg3 != null)
						{
							goto IL_00c0;
						}
						goto case 1;
					case 0:
						break;
					case 1:
						num5++;
						num3 = -705700966;
						continue;
					case 9:
						goto end_IL_0015;
					case 6:
						ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(nwXgurhtCFvedRYXAPczDqoZXlg2);
						num3 = -705700965;
						continue;
					case 4:
						num5 = 0;
						num3 = -705700966;
						continue;
					case 3:
						goto IL_013a;
					default:
						goto end_IL_013a;
					}
					int num6;
					if (num5 >= P_2)
					{
						num3 = -705700973;
						num6 = num3;
					}
					else
					{
						num3 = -705700963;
						num6 = num3;
					}
					continue;
					IL_0097:
					int num7;
					if (!UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						num3 = -705700976;
						num7 = num3;
					}
					else
					{
						num3 = -705700964;
						num7 = num3;
					}
					continue;
					IL_00c0:
					int num8;
					if (tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, nwXgurhtCFvedRYXAPczDqoZXlg3.rewiredId))
					{
						num3 = -705700965;
						num8 = num3;
					}
					else
					{
						num3 = -705700974;
						num8 = num3;
					}
					continue;
					end_IL_0015:
					break;
				}
				goto IL_010a;
				IL_010a:
				num2++;
				num3 = -705700968;
				goto IL_0015;
				continue;
				end_IL_013a:
				break;
			}
		}
	}

	private void IrBuLLxHFdDknWWFKqrzDdBoboV(int P_0, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_1, PryDqtABWuaaxijSFPWDtMXUdrmw.oXGDdreWaOoyHzCElfiPInJTGxy P_2)
	{
		int num = 0;
		int num4 = default(int);
		PryDqtABWuaaxijSFPWDtMXUdrmw.duNiNiXBHexUIvnXhFUCeboEDDe duNiNiXBHexUIvnXhFUCeboEDDe = default(PryDqtABWuaaxijSFPWDtMXUdrmw.duNiNiXBHexUIvnXhFUCeboEDDe);
		PryDqtABWuaaxijSFPWDtMXUdrmw.duNiNiXBHexUIvnXhFUCeboEDDe current = default(PryDqtABWuaaxijSFPWDtMXUdrmw.duNiNiXBHexUIvnXhFUCeboEDDe);
		while (num < P_0)
		{
			while (true)
			{
				nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg2 = P_1[num];
				if (nwXgurhtCFvedRYXAPczDqoZXlg2 != null)
				{
					int num2 = 556109041;
					while (true)
					{
						switch (num2 ^ 0x21258CF3)
						{
						case 0:
							num2 = 556109042;
							continue;
						case 1:
							break;
						default:
							goto IL_003a;
						}
						break;
					}
					continue;
				}
				goto IL_017a;
				IL_0104:
				int num3;
				while (true)
				{
					switch (num3 ^ 0x21258CF3)
					{
					case 4:
						break;
					case 1:
						if (!pgNWowjBpVDUsfPflzUQpiDLSMiQ(P_1, num4))
						{
							num4 = (duNiNiXBHexUIvnXhFUCeboEDDe.MrgFvxEmVvleAtwmEJiJFGTJUZgS = xsxJptmMPnqGtRxSuBrOBHkSWsg(P_1));
							num3 = 556109041;
							continue;
						}
						goto case 2;
					case 2:
						nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId = num4;
						num3 = 556109043;
						continue;
					case 0:
						nwXgurhtCFvedRYXAPczDqoZXlg2.rewiredId = duNiNiXBHexUIvnXhFUCeboEDDe.UKCDHORBCFHBoYLTIFGoDfJwMEGs;
						ZDGzEdGlsfPIXxxIiRhCInujjGU.tXgmibXCLFITLeBlRtsWPalapKpT(nwXgurhtCFvedRYXAPczDqoZXlg2);
						num3 = 556109046;
						continue;
					case 5:
						goto IL_017a;
					default:
						goto end_IL_0025;
					}
					break;
				}
				goto IL_00ff;
				IL_00ff:
				num3 = 556109042;
				goto IL_0104;
				IL_003a:
				if (nwXgurhtCFvedRYXAPczDqoZXlg2.inputManagerId < 0)
				{
					duNiNiXBHexUIvnXhFUCeboEDDe = null;
					using (IEnumerator<PryDqtABWuaaxijSFPWDtMXUdrmw.duNiNiXBHexUIvnXhFUCeboEDDe> enumerator = ZDGzEdGlsfPIXxxIiRhCInujjGU.ujuphkmYzsIfimEfOMVCHtLnQKt(nwXgurhtCFvedRYXAPczDqoZXlg2, P_2).GetEnumerator())
					{
						while (true)
						{
							IL_00c9:
							int num5;
							int num6;
							if (enumerator.MoveNext())
							{
								num5 = 556109042;
								num6 = num5;
							}
							else
							{
								num5 = 556109040;
								num6 = num5;
							}
							while (true)
							{
								switch (num5 ^ 0x21258CF3)
								{
								case 0:
									num5 = 556109042;
									continue;
								default:
									goto end_IL_0063;
								case 1:
									current = enumerator.Current;
									num5 = 556109046;
									continue;
								case 5:
								{
									int num7;
									if (tDUJWQkhxomwvbhOaOoQeAWVFSH(P_1, current.UKCDHORBCFHBoYLTIFGoDfJwMEGs))
									{
										num5 = 556109041;
										num7 = num5;
									}
									else
									{
										num5 = 556109047;
										num7 = num5;
									}
									continue;
								}
								case 4:
									if (current.MrgFvxEmVvleAtwmEJiJFGTJUZgS >= 0)
									{
										duNiNiXBHexUIvnXhFUCeboEDDe = current;
										num5 = 556109040;
										continue;
									}
									break;
								case 2:
									break;
								case 3:
									goto end_IL_0063;
								}
								goto IL_00c9;
								continue;
								end_IL_0063:
								break;
							}
							break;
						}
					}
					if (duNiNiXBHexUIvnXhFUCeboEDDe != null)
					{
						num4 = duNiNiXBHexUIvnXhFUCeboEDDe.MrgFvxEmVvleAtwmEJiJFGTJUZgS;
						goto IL_00ff;
					}
				}
				goto IL_017a;
				IL_017a:
				num++;
				num3 = 556109040;
				goto IL_0104;
				continue;
				end_IL_0025:
				break;
			}
		}
	}

	private void MFhjbGVDbNrOVBNutDpnZUWGDEP()
	{
		string[] joystickNames = Input.GetJoystickNames();
		while (true)
		{
			int num = -1318476266;
			while (true)
			{
				switch (num ^ -1318476265)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (!DsxHwkjezpCSRcDXXpxTLpDncEqC)
					{
						int num3;
						if (hLZerFQUBneQMKuTxVTgEcfJWjN(joystickNames))
						{
							num = -1318476269;
							num3 = num;
						}
						else
						{
							num = -1318476268;
							num3 = num;
						}
						continue;
					}
					goto case 4;
				case 4:
					YAYLplglEiMaFnRMMiGNmldzCmUa(joystickNames);
					num = -1318476268;
					continue;
				case 0:
					DsxHwkjezpCSRcDXXpxTLpDncEqC = false;
					num = -1318476270;
					continue;
				case 3:
				{
					VjAUYAWOZYRvlAZvsjAqxlszqGZ = false;
					int num2;
					if (DsxHwkjezpCSRcDXXpxTLpDncEqC)
					{
						num = -1318476265;
						num2 = num;
					}
					else
					{
						num = -1318476270;
						num2 = num;
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

	private bool hLZerFQUBneQMKuTxVTgEcfJWjN(string[] P_0)
	{
		if (P_0.Length != AbUhWqDrZkUacyBCXnyQmHYKhCx.Length)
		{
			return true;
		}
		int num = 0;
		while (num < P_0.Length)
		{
			while (true)
			{
				if (!string.Equals(P_0[num], AbUhWqDrZkUacyBCXnyQmHYKhCx[num], StringComparison.Ordinal))
				{
					return true;
				}
				num++;
				int num2 = -418507563;
				while (true)
				{
					switch (num2 ^ -418507561)
					{
					case 0:
						num2 = -418507562;
						continue;
					case 1:
						break;
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
		return false;
	}

	private void DvAgAsBJXkezynrKQNPnZfxrsAT(List<nwXgurhtCFvedRYXAPczDqoZXlg> P_0, List<nwXgurhtCFvedRYXAPczDqoZXlg> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num4 = default(int);
		int num5 = default(int);
		nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg2 = default(nwXgurhtCFvedRYXAPczDqoZXlg);
		bool flag = default(bool);
		int num6 = default(int);
		while (true)
		{
			int num = P_0?.Count ?? 0;
			int num2;
			if (P_1 == null)
			{
				num2 = 1871671157;
				goto IL_000c;
			}
			int num3 = P_1.Count;
			goto IL_013e;
			IL_0135:
			num3 = 0;
			goto IL_013e;
			IL_013e:
			num4 = num3;
			num5 = 0;
			num2 = 1871671155;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				nwXgurhtCFvedRYXAPczDqoZXlg nwXgurhtCFvedRYXAPczDqoZXlg3;
				switch (num2 ^ 0x6F8F6F75)
				{
				case 4:
					num2 = 1871671154;
					continue;
				default:
					return;
				case 11:
					if (nwXgurhtCFvedRYXAPczDqoZXlg2 != null)
					{
						goto IL_005b;
					}
					goto case 5;
				case 10:
					if (!flag)
					{
						vymVnMTbjwdXhKDbpoWajlhAhRD(P_0[num5], P_2);
						num2 = 1871671152;
						continue;
					}
					goto case 5;
				case 14:
					nwXgurhtCFvedRYXAPczDqoZXlg3 = P_1[num6];
					if (nwXgurhtCFvedRYXAPczDqoZXlg3 != null)
					{
						goto IL_009c;
					}
					goto case 1;
				case 13:
					num6 = 0;
					num2 = 1871671161;
					continue;
				case 5:
					num5++;
					num2 = 1871671159;
					continue;
				case 3:
					flag = true;
					num2 = 1871671167;
					continue;
				case 2:
					break;
				case 6:
					num2 = 1871671159;
					continue;
				case 8:
					nwXgurhtCFvedRYXAPczDqoZXlg2 = P_0[num5];
					num2 = 1871671166;
					continue;
				case 7:
					goto end_IL_000c;
				case 0:
					goto IL_0135;
				case 1:
					num6++;
					num2 = 1871671161;
					continue;
				case 12:
					goto IL_015b;
				case 9:
					return;
				}
				int num7;
				if (num5 < num)
				{
					num2 = 1871671165;
					num7 = num2;
				}
				else
				{
					num2 = 1871671164;
					num7 = num2;
				}
				continue;
				IL_015b:
				int num8;
				if (num6 >= num4)
				{
					num2 = 1871671167;
					num8 = num2;
				}
				else
				{
					num2 = 1871671163;
					num8 = num2;
				}
				continue;
				IL_009c:
				int num9;
				if (nwXgurhtCFvedRYXAPczDqoZXlg2.rewiredId == nwXgurhtCFvedRYXAPczDqoZXlg3.rewiredId)
				{
					num2 = 1871671158;
					num9 = num2;
				}
				else
				{
					num2 = 1871671156;
					num9 = num2;
				}
				continue;
				IL_005b:
				flag = false;
				int num10;
				if (P_1 != null)
				{
					num2 = 1871671160;
					num10 = num2;
				}
				else
				{
					num2 = 1871671167;
					num10 = num2;
				}
				continue;
				end_IL_000c:
				break;
			}
		}
	}

	private void vymVnMTbjwdXhKDbpoWajlhAhRD(nwXgurhtCFvedRYXAPczDqoZXlg P_0, bool P_1)
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
			int num = -647848717;
			while (true)
			{
				switch (num ^ -647848719)
				{
				case 0:
					goto IL_001d;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_001d:
				num = -647848720;
			}
		}
	}

	private void MlSvoFrbdqmZkMWjiKVHsJGvavX()
	{
		if (vuGbLgVYuadXzhzNZHvlhRNLlqP != FkqfeKVDJDBbnJWyWzbNqaonAQm)
		{
			return;
		}
		while (true)
		{
			int num;
			int num2;
			if (jwGRLLmVawoxIvuOGajmHacICvN.Update())
			{
				num = 1433831140;
				num2 = num;
			}
			else
			{
				num = 1433831143;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x557686E6)
				{
				case 0:
					num = 1433831141;
					continue;
				default:
					return;
				case 3:
					break;
				case 2:
					VjAUYAWOZYRvlAZvsjAqxlszqGZ = true;
					jwGRLLmVawoxIvuOGajmHacICvN.Start();
					num = 1433831143;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}
}
