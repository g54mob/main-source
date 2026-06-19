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
		private class pdAljfPQMTWIfBGcuVQWlQehJAn : IInputManagerJoystickPublic, IInputManagerJoystick
		{
			private readonly InputSource MHWfeAIIxgGWGdDJknvdMLOmOzQM;

			private readonly CustomInputSource HOXBoZWNhEfwnkkOJgHSzhRAwuq;

			private readonly Controller.Extension DLgfvsKWtDDcFdLxaaSpMucpiDtb;

			private int HwTLNUyvqDkSjEHaWEyOnHlYhGtB;

			private int WBaoxaCThMgQdahqjHosoWBIEZL;

			private long? BKdaOxqbTAGWCgnBTRWCklwSDaaL;

			private int GilOEfRsEhDCPCODtRARcQnrnPTg;

			public Guid RxUYBLYGIqivqakOWtPaeuMeATt;

			public string NemrSUHxgqWRlUKFQPoLbCdPfiZ;

			public string jUduMFQVhZgnBwMpGiZmbmtIijn;

			private int JDyNNdOScJLywOHcbmcaJdgZeIE;

			private int CtHmgLQvreiWMWnBZZLsTLZpuCY;

			private float[] BmVsDDHajHfWhKZRyhtaTrJBobn;

			private bool[] lwtalwosBMdLgdmWCxwqMEvxwal;

			private HardwareJoystickMap_InputManager ZBMEOTEbHBcUeYYftsfiohhXNEse;

			public CustomInputSource.Joystick keBGqqKILXOnjCEdvgqocBlblRIX;

			private bool NvMWNQFswZpXSwcgvfrXqxOwMyx;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lJvXHfWbRfyIcaObLbvpiCWsQgzw;

			public int hardwareButtonCount
			{
				get
				{
					if (keBGqqKILXOnjCEdvgqocBlblRIX == null)
					{
						return 0;
					}
					return keBGqqKILXOnjCEdvgqocBlblRIX.buttonCount;
				}
			}

			public int hardwareAxisCount
			{
				get
				{
					if (keBGqqKILXOnjCEdvgqocBlblRIX == null)
					{
						return 0;
					}
					return keBGqqKILXOnjCEdvgqocBlblRIX.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return HwTLNUyvqDkSjEHaWEyOnHlYhGtB;
				}
				set
				{
					HwTLNUyvqDkSjEHaWEyOnHlYhGtB = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return WBaoxaCThMgQdahqjHosoWBIEZL;
				}
				set
				{
					WBaoxaCThMgQdahqjHosoWBIEZL = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(keBGqqKILXOnjCEdvgqocBlblRIX.customName)) ? keBGqqKILXOnjCEdvgqocBlblRIX.customName : NemrSUHxgqWRlUKFQPoLbCdPfiZ);
					if (text == "Unknown Controller")
					{
						text = jUduMFQVhZgnBwMpGiZmbmtIijn;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId => BKdaOxqbTAGWCgnBTRWCklwSDaaL;

			[CustomObfuscation(rename = false)]
			public int unityId => GilOEfRsEhDCPCODtRARcQnrnPTg;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!BKdaOxqbTAGWCgnBTRWCklwSDaaL.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + BKdaOxqbTAGWCgnBTRWCklwSDaaL);
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid => instanceGuid;

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => DLgfvsKWtDDcFdLxaaSpMucpiDtb;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public pdAljfPQMTWIfBGcuVQWlQehJAn(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, Controller.Extension controllerExtension, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
			{
				HOXBoZWNhEfwnkkOJgHSzhRAwuq = customInputSource;
				MHWfeAIIxgGWGdDJknvdMLOmOzQM = inputSource;
				BKdaOxqbTAGWCgnBTRWCklwSDaaL = systemJoystickId;
				keBGqqKILXOnjCEdvgqocBlblRIX = joystick;
				GilOEfRsEhDCPCODtRARcQnrnPTg = unityJoystickId;
				DLgfvsKWtDDcFdLxaaSpMucpiDtb = controllerExtension;
				lJvXHfWbRfyIcaObLbvpiCWsQgzw = getHardwareJoystickMap_InputManager;
				WBaoxaCThMgQdahqjHosoWBIEZL = -1;
				HwTLNUyvqDkSjEHaWEyOnHlYhGtB = -1;
				JJJzpPRKqzeLBeRrcHWpFdprhON();
				PoSdIgbuhkXaateVQltFDLNhMabt();
				RxUYBLYGIqivqakOWtPaeuMeATt = ZBMEOTEbHBcUeYYftsfiohhXNEse.hardwareMapIdentifier.guid;
				NemrSUHxgqWRlUKFQPoLbCdPfiZ = ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName;
				BmVsDDHajHfWhKZRyhtaTrJBobn = new float[JDyNNdOScJLywOHcbmcaJdgZeIE];
				lwtalwosBMdLgdmWCxwqMEvxwal = new bool[CtHmgLQvreiWMWnBZZLsTLZpuCY];
				Update();
			}

			public void JJJzpPRKqzeLBeRrcHWpFdprhON()
			{
				jUduMFQVhZgnBwMpGiZmbmtIijn = keBGqqKILXOnjCEdvgqocBlblRIX.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (keBGqqKILXOnjCEdvgqocBlblRIX.isConnected)
				{
					OqHywWvXuiMZOBydYSSzaganIrEK();
					dpxLoNUKQscDlKAbeZOSlMIeEvD();
				}
			}

			public int QuyjPPVLYssrxnLbKpFVOFYkPay(pdAljfPQMTWIfBGcuVQWlQehJAn P_0)
			{
				if (P_0.jUduMFQVhZgnBwMpGiZmbmtIijn == jUduMFQVhZgnBwMpGiZmbmtIijn && P_0.BKdaOxqbTAGWCgnBTRWCklwSDaaL == BKdaOxqbTAGWCgnBTRWCklwSDaaL)
				{
					return 2;
				}
				if (P_0.jUduMFQVhZgnBwMpGiZmbmtIijn == jUduMFQVhZgnBwMpGiZmbmtIijn)
				{
					return 1;
				}
				return 0;
			}

			private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = MHWfeAIIxgGWGdDJknvdMLOmOzQM;
				P_0.inputSource = MHWfeAIIxgGWGdDJknvdMLOmOzQM;
				P_0.hardwareIdentifier = RkJgHxDMstoRxqAmUOkzfAsKZGc();
				P_0.hardwareAxisCount = JDyNNdOScJLywOHcbmcaJdgZeIE;
				P_0.hardwareButtonCount = CtHmgLQvreiWMWnBZZLsTLZpuCY;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = jUduMFQVhZgnBwMpGiZmbmtIijn;
				P_0.hw_supportsVibration = keBGqqKILXOnjCEdvgqocBlblRIX.supportsVibration;
			}

			private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedController P_0)
			{
				etfbyzPQFfFMvByaCyNPpDEsUfK((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = ZBMEOTEbHBcUeYYftsfiohhXNEse.ToGameHardwareControllerMap();
				P_0.instanceName = jUduMFQVhZgnBwMpGiZmbmtIijn;
				P_0.productName = jUduMFQVhZgnBwMpGiZmbmtIijn;
				P_0.isXInputDevice = false;
				P_0.axisCount = JDyNNdOScJLywOHcbmcaJdgZeIE;
				P_0.buttonCount = CtHmgLQvreiWMWnBZZLsTLZpuCY;
				P_0.controllerTypeGuid = RxUYBLYGIqivqakOWtPaeuMeATt;
				P_0.customInputSource = HOXBoZWNhEfwnkkOJgHSzhRAwuq;
				P_0.controllerExtension = DLgfvsKWtDDcFdLxaaSpMucpiDtb;
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (JDyNNdOScJLywOHcbmcaJdgZeIE != dataUpdater.axisCount || CtHmgLQvreiWMWnBZZLsTLZpuCY != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < JDyNNdOScJLywOHcbmcaJdgZeIE; i++)
				{
					dataUpdater.axisValues[i] = BmVsDDHajHfWhKZRyhtaTrJBobn[i];
				}
				for (int j = 0; j < CtHmgLQvreiWMWnBZZLsTLZpuCY; j++)
				{
					dataUpdater.buttonValues[j] = lwtalwosBMdLgdmWCxwqMEvxwal[j];
				}
				if (NvMWNQFswZpXSwcgvfrXqxOwMyx && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			public BridgedControllerHWInfo TuJmIhZHnIxJHszIupkxqjtULhV()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				etfbyzPQFfFMvByaCyNPpDEsUfK(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				etfbyzPQFfFMvByaCyNPpDEsUfK(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(HwTLNUyvqDkSjEHaWEyOnHlYhGtB);
			}

			private void OqHywWvXuiMZOBydYSSzaganIrEK()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)ZBMEOTEbHBcUeYYftsfiohhXNEse.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= JDyNNdOScJLywOHcbmcaJdgZeIE)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						BmVsDDHajHfWhKZRyhtaTrJBobn[i] = QTYKdOZLkJEqXkCFTAyzbbojlRXP(axes[i]);
						if (!NvMWNQFswZpXSwcgvfrXqxOwMyx && BmVsDDHajHfWhKZRyhtaTrJBobn[i] != 0f)
						{
							NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
						}
					}
				}
			}

			private void dpxLoNUKQscDlKAbeZOSlMIeEvD()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)ZBMEOTEbHBcUeYYftsfiohhXNEse.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= CtHmgLQvreiWMWnBZZLsTLZpuCY)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					lwtalwosBMdLgdmWCxwqMEvxwal[i] = kAVHgdphgcHqDOwQpMCcCbwXpBK(buttons[i]);
					if (!NvMWNQFswZpXSwcgvfrXqxOwMyx && lwtalwosBMdLgdmWCxwqMEvxwal[i])
					{
						NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
					}
				}
			}

			private bool kAVHgdphgcHqDOwQpMCcCbwXpBK(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = QTYKdOZLkJEqXkCFTAyzbbojlRXP(P_0.sourceAxis);
					if (MathTools.Abs(num) <= P_0.axisDeadZone)
					{
						return false;
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
				}
				return false;
			}

			private bool HgFYfZdzOVuarsmGkdXMCJkkZsz(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float QTYKdOZLkJEqXkCFTAyzbbojlRXP(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return QTYKdOZLkJEqXkCFTAyzbbojlRXP(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.sourceButton))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						return 1f;
					}
					return -1f;
				}
				throw new NotImplementedException();
			}

			private float QTYKdOZLkJEqXkCFTAyzbbojlRXP(int P_0)
			{
				return keBGqqKILXOnjCEdvgqocBlblRIX.GetAxisValue(P_0);
			}

			private bool kAVHgdphgcHqDOwQpMCcCbwXpBK(int P_0)
			{
				return keBGqqKILXOnjCEdvgqocBlblRIX.GetButtonValue(P_0);
			}

			private void PoSdIgbuhkXaateVQltFDLNhMabt()
			{
				ZBMEOTEbHBcUeYYftsfiohhXNEse = lJvXHfWbRfyIcaObLbvpiCWsQgzw(TuJmIhZHnIxJHszIupkxqjtULhV());
				if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				JDyNNdOScJLywOHcbmcaJdgZeIE = ZBMEOTEbHBcUeYYftsfiohhXNEse.axisCount;
				CtHmgLQvreiWMWnBZZLsTLZpuCY = ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonCount;
			}

			private void nHicOctZXUaXGlQKmLfriuETVQS()
			{
				Array.Clear(lwtalwosBMdLgdmWCxwqMEvxwal, 0, lwtalwosBMdLgdmWCxwqMEvxwal.Length);
				Array.Clear(BmVsDDHajHfWhKZRyhtaTrJBobn, 0, BmVsDDHajHfWhKZRyhtaTrJBobn.Length);
			}

			private string RkJgHxDMstoRxqAmUOkzfAsKZGc()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{MHWfeAIIxgGWGdDJknvdMLOmOzQM.ToString()}{jUduMFQVhZgnBwMpGiZmbmtIijn}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{MHWfeAIIxgGWGdDJknvdMLOmOzQM.ToString()}{jUduMFQVhZgnBwMpGiZmbmtIijn}");
			}

			public static int uwguXCEdnqrosZyJUNRThBOFGNZ(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, pdAljfPQMTWIfBGcuVQWlQehJAn P_1)
			{
				if (P_0.WBaoxaCThMgQdahqjHosoWBIEZL < P_1.WBaoxaCThMgQdahqjHosoWBIEZL)
				{
					return -1;
				}
				if (P_0.WBaoxaCThMgQdahqjHosoWBIEZL > P_1.WBaoxaCThMgQdahqjHosoWBIEZL)
				{
					return 1;
				}
				return 0;
			}

			public static int JRsfqISXIAZZpwSAIdFMPtHxpdp(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, pdAljfPQMTWIfBGcuVQWlQehJAn P_1)
			{
				if (P_0.BKdaOxqbTAGWCgnBTRWCklwSDaaL < P_1.BKdaOxqbTAGWCgnBTRWCklwSDaaL)
				{
					return -1;
				}
				if (P_0.BKdaOxqbTAGWCgnBTRWCklwSDaaL > P_1.BKdaOxqbTAGWCgnBTRWCklwSDaaL)
				{
					return 1;
				}
				return 0;
			}
		}

		private class ZOVYYVNulXhTGuDRTvHAjPVAHyn
		{
			public enum LiRtQDRaebfyQmWVJYgzrgiSxcR
			{
				bsEuTteZfWpGGkkWfgFWdtTyWHGw = 0,
				HoUDpKToZAvYvTCsbfaQUrQsFTC = 1
			}

			public class zEFnGplYWTdJDpZIoTfKsKOkPPE
			{
				public int AVJCjGFlvmvUQprbQtbNLTqidXD;

				public long? uwHNWRSimSMSUCUEsoLDakWjmHO;

				public string OdPvfZNApsWyqPFzvQOxbZJZpyR;

				public int SCvLuAiDgDtSaPnKtxXIaqXDocp;

				public int CtHmgLQvreiWMWnBZZLsTLZpuCY;

				public int JDyNNdOScJLywOHcbmcaJdgZeIE;

				public zEFnGplYWTdJDpZIoTfKsKOkPPE(int rewiredId, long? systemId, string systemControllerName, int lastInputManagerId, int buttonCount, int axisCount)
				{
					AVJCjGFlvmvUQprbQtbNLTqidXD = rewiredId;
					uwHNWRSimSMSUCUEsoLDakWjmHO = systemId;
					OdPvfZNApsWyqPFzvQOxbZJZpyR = systemControllerName;
					SCvLuAiDgDtSaPnKtxXIaqXDocp = lastInputManagerId;
					CtHmgLQvreiWMWnBZZLsTLZpuCY = buttonCount;
					JDyNNdOScJLywOHcbmcaJdgZeIE = axisCount;
				}

				public bool QuyjPPVLYssrxnLbKpFVOFYkPay(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, LiRtQDRaebfyQmWVJYgzrgiSxcR P_1)
				{
					if (P_0.rewiredId == AVJCjGFlvmvUQprbQtbNLTqidXD)
					{
						return true;
					}
					if (P_0.hardwareButtonCount != CtHmgLQvreiWMWnBZZLsTLZpuCY)
					{
						return false;
					}
					if (P_0.hardwareAxisCount != JDyNNdOScJLywOHcbmcaJdgZeIE)
					{
						return false;
					}
					switch (P_1)
					{
					case LiRtQDRaebfyQmWVJYgzrgiSxcR.bsEuTteZfWpGGkkWfgFWdtTyWHGw:
						if (uwHNWRSimSMSUCUEsoLDakWjmHO == P_0.systemId)
						{
							return OdPvfZNApsWyqPFzvQOxbZJZpyR == P_0.jUduMFQVhZgnBwMpGiZmbmtIijn;
						}
						return false;
					case LiRtQDRaebfyQmWVJYgzrgiSxcR.HoUDpKToZAvYvTCsbfaQUrQsFTC:
						return OdPvfZNApsWyqPFzvQOxbZJZpyR == P_0.jUduMFQVhZgnBwMpGiZmbmtIijn;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class zJwGjONaPOdazFnCAqEcTtycIkS : IDisposable, IEnumerator, IEnumerable, IEnumerable<zEFnGplYWTdJDpZIoTfKsKOkPPE>, IEnumerator<zEFnGplYWTdJDpZIoTfKsKOkPPE>
			{
				private zEFnGplYWTdJDpZIoTfKsKOkPPE ajbaQItphrIyqhowgmMTfPkCBvcN;

				private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

				private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

				public ZOVYYVNulXhTGuDRTvHAjPVAHyn kdBZqupjvsCsVkwJiOeEQzkEDVO;

				public pdAljfPQMTWIfBGcuVQWlQehJAn UrVHqfdkMVOZnqPAIiNXclLMHTZj;

				public pdAljfPQMTWIfBGcuVQWlQehJAn ipVhBkVCCSfvawTftgxfuhaEZKG;

				public LiRtQDRaebfyQmWVJYgzrgiSxcR paUXJyBjwVEMwHcXAcJgCsKrCvZ;

				public LiRtQDRaebfyQmWVJYgzrgiSxcR FXZuxBvuEcsvWVdlSVqtSMIHOMp;

				public int yQidoppRzNCEGIouqRwsuyQaWvN;

				public int WEaqIZlkOXafrZCTcGmyQTyddIOi;

				zEFnGplYWTdJDpZIoTfKsKOkPPE IEnumerator<zEFnGplYWTdJDpZIoTfKsKOkPPE>.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ajbaQItphrIyqhowgmMTfPkCBvcN;
					}
				}

				[DebuggerHidden]
				IEnumerator<zEFnGplYWTdJDpZIoTfKsKOkPPE> IEnumerable<zEFnGplYWTdJDpZIoTfKsKOkPPE>.GetEnumerator()
				{
					zJwGjONaPOdazFnCAqEcTtycIkS zJwGjONaPOdazFnCAqEcTtycIkS2;
					if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
						zJwGjONaPOdazFnCAqEcTtycIkS2 = this;
					}
					else
					{
						zJwGjONaPOdazFnCAqEcTtycIkS2 = new zJwGjONaPOdazFnCAqEcTtycIkS(0);
						zJwGjONaPOdazFnCAqEcTtycIkS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
					}
					zJwGjONaPOdazFnCAqEcTtycIkS2.UrVHqfdkMVOZnqPAIiNXclLMHTZj = ipVhBkVCCSfvawTftgxfuhaEZKG;
					zJwGjONaPOdazFnCAqEcTtycIkS2.paUXJyBjwVEMwHcXAcJgCsKrCvZ = FXZuxBvuEcsvWVdlSVqtSMIHOMp;
					return zJwGjONaPOdazFnCAqEcTtycIkS2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<zEFnGplYWTdJDpZIoTfKsKOkPPE>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
					{
					case 0:
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						yQidoppRzNCEGIouqRwsuyQaWvN = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB.Count;
						WEaqIZlkOXafrZCTcGmyQTyddIOi = 0;
						goto IL_00a3;
					case 1:
						{
							uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
							goto IL_0095;
						}
						IL_00a3:
						if (WEaqIZlkOXafrZCTcGmyQTyddIOi >= yQidoppRzNCEGIouqRwsuyQaWvN)
						{
							break;
						}
						if (kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[WEaqIZlkOXafrZCTcGmyQTyddIOi].QuyjPPVLYssrxnLbKpFVOFYkPay(UrVHqfdkMVOZnqPAIiNXclLMHTZj, paUXJyBjwVEMwHcXAcJgCsKrCvZ))
						{
							ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[WEaqIZlkOXafrZCTcGmyQTyddIOi];
							uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
							return true;
						}
						goto IL_0095;
						IL_0095:
						WEaqIZlkOXafrZCTcGmyQTyddIOi++;
						goto IL_00a3;
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
				public zJwGjONaPOdazFnCAqEcTtycIkS(int _003C_003E1__state)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
					LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private List<zEFnGplYWTdJDpZIoTfKsKOkPPE> fopcRAyqeBjmZPOELjthAdVYQiB;

			public int Count => fopcRAyqeBjmZPOELjthAdVYQiB.Count;

			public ZOVYYVNulXhTGuDRTvHAjPVAHyn()
			{
				fopcRAyqeBjmZPOELjthAdVYQiB = new List<zEFnGplYWTdJDpZIoTfKsKOkPPE>();
			}

			public void pNtVjMTCwjmfvmJXawLBYkfoTpi(pdAljfPQMTWIfBGcuVQWlQehJAn P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
				for (int i = 0; i < count; i++)
				{
					if (fopcRAyqeBjmZPOELjthAdVYQiB[i].QuyjPPVLYssrxnLbKpFVOFYkPay(P_0, LiRtQDRaebfyQmWVJYgzrgiSxcR.bsEuTteZfWpGGkkWfgFWdtTyWHGw))
					{
						fopcRAyqeBjmZPOELjthAdVYQiB[i].AVJCjGFlvmvUQprbQtbNLTqidXD = P_0.rewiredId;
						fopcRAyqeBjmZPOELjthAdVYQiB[i].uwHNWRSimSMSUCUEsoLDakWjmHO = P_0.systemId;
						fopcRAyqeBjmZPOELjthAdVYQiB[i].OdPvfZNApsWyqPFzvQOxbZJZpyR = P_0.jUduMFQVhZgnBwMpGiZmbmtIijn;
						fopcRAyqeBjmZPOELjthAdVYQiB[i].SCvLuAiDgDtSaPnKtxXIaqXDocp = P_0.inputManagerId;
						fopcRAyqeBjmZPOELjthAdVYQiB[i].CtHmgLQvreiWMWnBZZLsTLZpuCY = P_0.hardwareButtonCount;
						fopcRAyqeBjmZPOELjthAdVYQiB[i].JDyNNdOScJLywOHcbmcaJdgZeIE = P_0.hardwareAxisCount;
						BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, i);
						return;
					}
				}
				fopcRAyqeBjmZPOELjthAdVYQiB.Add(new zEFnGplYWTdJDpZIoTfKsKOkPPE(P_0.rewiredId, P_0.systemId, P_0.jUduMFQVhZgnBwMpGiZmbmtIijn, P_0.inputManagerId, P_0.hardwareButtonCount, P_0.hardwareAxisCount));
				BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, fopcRAyqeBjmZPOELjthAdVYQiB.Count - 1);
			}

			public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, LiRtQDRaebfyQmWVJYgzrgiSxcR P_1)
			{
				int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
				for (int i = 0; i < count; i++)
				{
					if (fopcRAyqeBjmZPOELjthAdVYQiB[i].QuyjPPVLYssrxnLbKpFVOFYkPay(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			public IEnumerable<zEFnGplYWTdJDpZIoTfKsKOkPPE> afvWoBaYQAGDQJhLdAqXpRXzPls(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, LiRtQDRaebfyQmWVJYgzrgiSxcR P_1)
			{
				zJwGjONaPOdazFnCAqEcTtycIkS zJwGjONaPOdazFnCAqEcTtycIkS2 = new zJwGjONaPOdazFnCAqEcTtycIkS(-2);
				zJwGjONaPOdazFnCAqEcTtycIkS2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
				zJwGjONaPOdazFnCAqEcTtycIkS2.ipVhBkVCCSfvawTftgxfuhaEZKG = P_0;
				zJwGjONaPOdazFnCAqEcTtycIkS2.FXZuxBvuEcsvWVdlSVqtSMIHOMp = P_1;
				return zJwGjONaPOdazFnCAqEcTtycIkS2;
			}

			public int EZvGxHsqIFFuTapSiFVRnGzgbyW(zEFnGplYWTdJDpZIoTfKsKOkPPE P_0)
			{
				int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
				for (int i = 0; i < count; i++)
				{
					if (fopcRAyqeBjmZPOELjthAdVYQiB[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void BmxembdddCYcgouqniXoOKxIaBMm(int P_0, int P_1)
			{
				for (int num = fopcRAyqeBjmZPOELjthAdVYQiB.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && fopcRAyqeBjmZPOELjthAdVYQiB[num].AVJCjGFlvmvUQprbQtbNLTqidXD == P_0)
					{
						fopcRAyqeBjmZPOELjthAdVYQiB.RemoveAt(num);
					}
				}
			}
		}

		private List<pdAljfPQMTWIfBGcuVQWlQehJAn> GpKTUjLMGVeIHJzINAjLhtehdVC;

		private int hkPEgaZbxwhJzMkQldVtavOeqXDv;

		private ZOVYYVNulXhTGuDRTvHAjPVAHyn VXRpRQGmBLUsrQikVDSFCugvidLN;

		private UpdateLoopType jmBSaJJBPATONArmmooyFDkJURE;

		private Action<int, ControllerDataUpdater> OBflEVhfTmffnsAjdGTAfWJOvWq;

		private PlatformInputManager STXNVyGURWHvVpTJBWUcsUurLbv;

		private CustomInputSource HOXBoZWNhEfwnkkOJgHSzhRAwuq;

		private bool DWJnXrOBumpLFfmZPjflDMezshO;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lJvXHfWbRfyIcaObLbvpiCWsQgzw;

		private Func<int> aKvCUaiGXmdnbQBGdJPaRbbDQB;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => hkPEgaZbxwhJzMkQldVtavOeqXDv;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => STXNVyGURWHvVpTJBWUcsUurLbv;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => HOXBoZWNhEfwnkkOJgHSzhRAwuq.inputSource;

		public CustomInputManager(CustomInputSource customInputSource, UpdateLoopSetting updateLoopSetting, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			HOXBoZWNhEfwnkkOJgHSzhRAwuq = customInputSource;
			lJvXHfWbRfyIcaObLbvpiCWsQgzw = getHardwareJoystickMap_InputManager;
			aKvCUaiGXmdnbQBGdJPaRbbDQB = getNewJoystickId;
			STXNVyGURWHvVpTJBWUcsUurLbv = this;
			try
			{
				OBflEVhfTmffnsAjdGTAfWJOvWq = UpdateControllerData;
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
			VXRpRQGmBLUsrQikVDSFCugvidLN = new ZOVYYVNulXhTGuDRTvHAjPVAHyn();
			GpKTUjLMGVeIHJzINAjLhtehdVC = new List<pdAljfPQMTWIfBGcuVQWlQehJAn>();
			DWJnXrOBumpLFfmZPjflDMezshO = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			jmBSaJJBPATONArmmooyFDkJURE = updateLoop;
			if (HOXBoZWNhEfwnkkOJgHSzhRAwuq.isReady)
			{
				HOXBoZWNhEfwnkkOJgHSzhRAwuq.Update();
				if (DWJnXrOBumpLFfmZPjflDMezshO)
				{
					ECgcLnNOAxTzdoTYOgpcfwIQwLY();
				}
				fikeeHzZorPbLCMiizOEMORFdJAK();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (HOXBoZWNhEfwnkkOJgHSzhRAwuq != null)
			{
				HOXBoZWNhEfwnkkOJgHSzhRAwuq.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return OBflEVhfTmffnsAjdGTAfWJOvWq;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
			{
				if (GpKTUjLMGVeIHJzINAjLhtehdVC[i].inputManagerId == inputManagerId)
				{
					GpKTUjLMGVeIHJzINAjLhtehdVC[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
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

		private void OoDFaIeyrIrGfOQwdBnCiIvBbHRL(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<pdAljfPQMTWIfBGcuVQWlQehJAn> gpKTUjLMGVeIHJzINAjLhtehdVC = GpKTUjLMGVeIHJzINAjLhtehdVC;
			int num2 = hkPEgaZbxwhJzMkQldVtavOeqXDv;
			GpKTUjLMGVeIHJzINAjLhtehdVC = new List<pdAljfPQMTWIfBGcuVQWlQehJAn>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					pdAljfPQMTWIfBGcuVQWlQehJAn item = new pdAljfPQMTWIfBGcuVQWlQehJAn(HOXBoZWNhEfwnkkOJgHSzhRAwuq, P_0[i].systemId, P_0[i].unityId, P_0[i], HOXBoZWNhEfwnkkOJgHSzhRAwuq.inputSource, P_0[i].extension, lJvXHfWbRfyIcaObLbvpiCWsQgzw);
					GpKTUjLMGVeIHJzINAjLhtehdVC.Add(item);
					num++;
				}
			}
			hkPEgaZbxwhJzMkQldVtavOeqXDv = num;
			KTAwGzsoAsHiEgQlJqUIcwdlEjt(num2, num, gpKTUjLMGVeIHJzINAjLhtehdVC, GpKTUjLMGVeIHJzINAjLhtehdVC);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(GpKTUjLMGVeIHJzINAjLhtehdVC[j]));
				}
			}
			NLNETPIPcIzZWgQktmiidfjpSxOl(gpKTUjLMGVeIHJzINAjLhtehdVC, GpKTUjLMGVeIHJzINAjLhtehdVC, false);
			NLNETPIPcIzZWgQktmiidfjpSxOl(GpKTUjLMGVeIHJzINAjLhtehdVC, gpKTUjLMGVeIHJzINAjLhtehdVC, true);
		}

		private void fikeeHzZorPbLCMiizOEMORFdJAK()
		{
			for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].Update();
			}
		}

		private void KTAwGzsoAsHiEgQlJqUIcwdlEjt(int P_0, int P_1, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_2, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(pdAljfPQMTWIfBGcuVQWlQehJAn.JRsfqISXIAZZpwSAIdFMPtHxpdp);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
				if (HOXBoZWNhEfwnkkOJgHSzhRAwuq.useApproximateMatching)
				{
					UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR.HoUDpKToZAvYvTCsbfaQUrQsFTC);
				}
			}
			YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
			if (HOXBoZWNhEfwnkkOJgHSzhRAwuq.useApproximateMatching)
			{
				YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR.HoUDpKToZAvYvTCsbfaQUrQsFTC);
			}
			for (int i = 0; i < P_1; i++)
			{
				pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn2 = P_3[i];
				if (pdAljfPQMTWIfBGcuVQWlQehJAn2 != null && pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId < 0)
				{
					pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_3);
					pdAljfPQMTWIfBGcuVQWlQehJAn2.rewiredId = ReInput.GetNewJoystickId();
					VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pdAljfPQMTWIfBGcuVQWlQehJAn2);
				}
			}
			P_3.Sort(pdAljfPQMTWIfBGcuVQWlQehJAn.uwguXCEdnqrosZyJUNRThBOFGNZ);
		}

		private void nMzSzQRKRtEuNERWjNqyJJJAppk(List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != P_1 && P_0[i] != null && P_0[i].inputManagerId == P_2)
				{
					P_0[i].inputManagerId = -1;
				}
			}
		}

		private bool jKMphJxbMbpySqxLEPdTKRZDSrn(List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].inputManagerId == P_1)
				{
					return false;
				}
			}
			return true;
		}

		private int pzcgaQeegHlaRneiNJuTAjkIvlfu(List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_0)
		{
			int num = 0;
			while (true)
			{
				bool flag = false;
				int count = P_0.Count;
				for (int i = 0; i < count; i++)
				{
					if (P_0[i] != null && P_0[i].inputManagerId == num)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num++;
			}
			return num;
		}

		private bool brHCphkOPMIyDMoTDxdDCAADyNA(List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].rewiredId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		private void UcQYDPRULynzQPJTWpMsBpLjdRDD(int P_0, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_1, int P_2, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_3, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR P_4)
		{
			int num = ((P_4 != ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR.bsEuTteZfWpGGkkWfgFWdtTyWHGw) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn2 = P_1[i];
				if (pdAljfPQMTWIfBGcuVQWlQehJAn2 == null || pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn3 = P_3[j];
					if (pdAljfPQMTWIfBGcuVQWlQehJAn3 != null && !brHCphkOPMIyDMoTDxdDCAADyNA(P_1, pdAljfPQMTWIfBGcuVQWlQehJAn3.rewiredId) && pdAljfPQMTWIfBGcuVQWlQehJAn2.QuyjPPVLYssrxnLbKpFVOFYkPay(pdAljfPQMTWIfBGcuVQWlQehJAn3) >= num)
					{
						pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId = pdAljfPQMTWIfBGcuVQWlQehJAn3.inputManagerId;
						pdAljfPQMTWIfBGcuVQWlQehJAn2.rewiredId = pdAljfPQMTWIfBGcuVQWlQehJAn3.rewiredId;
						VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pdAljfPQMTWIfBGcuVQWlQehJAn2);
					}
				}
			}
		}

		private void YwWhsupQmPrVTdmbpVrereVcWSG(int P_0, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_1, ZOVYYVNulXhTGuDRTvHAjPVAHyn.LiRtQDRaebfyQmWVJYgzrgiSxcR P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn2 = P_1[i];
				if (pdAljfPQMTWIfBGcuVQWlQehJAn2 == null || pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId >= 0)
				{
					continue;
				}
				ZOVYYVNulXhTGuDRTvHAjPVAHyn.zEFnGplYWTdJDpZIoTfKsKOkPPE zEFnGplYWTdJDpZIoTfKsKOkPPE = null;
				foreach (ZOVYYVNulXhTGuDRTvHAjPVAHyn.zEFnGplYWTdJDpZIoTfKsKOkPPE item in VXRpRQGmBLUsrQikVDSFCugvidLN.afvWoBaYQAGDQJhLdAqXpRXzPls(pdAljfPQMTWIfBGcuVQWlQehJAn2, P_2))
				{
					if (!brHCphkOPMIyDMoTDxdDCAADyNA(P_1, item.AVJCjGFlvmvUQprbQtbNLTqidXD) && item.SCvLuAiDgDtSaPnKtxXIaqXDocp >= 0)
					{
						zEFnGplYWTdJDpZIoTfKsKOkPPE = item;
						break;
					}
				}
				if (zEFnGplYWTdJDpZIoTfKsKOkPPE != null)
				{
					int num = zEFnGplYWTdJDpZIoTfKsKOkPPE.SCvLuAiDgDtSaPnKtxXIaqXDocp;
					if (!jKMphJxbMbpySqxLEPdTKRZDSrn(P_1, num))
					{
						num = (zEFnGplYWTdJDpZIoTfKsKOkPPE.SCvLuAiDgDtSaPnKtxXIaqXDocp = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_1));
					}
					pdAljfPQMTWIfBGcuVQWlQehJAn2.inputManagerId = num;
					pdAljfPQMTWIfBGcuVQWlQehJAn2.rewiredId = zEFnGplYWTdJDpZIoTfKsKOkPPE.AVJCjGFlvmvUQprbQtbNLTqidXD;
					VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pdAljfPQMTWIfBGcuVQWlQehJAn2);
				}
			}
		}

		private void ECgcLnNOAxTzdoTYOgpcfwIQwLY()
		{
			CustomInputSource.Joystick[] array = HOXBoZWNhEfwnkkOJgHSzhRAwuq.kqZQuzXBPXjreKeMaNsdehOhbEo();
			if (nfWiyuOsgLuucxCzCJgnyAtNTIQ(array))
			{
				OoDFaIeyrIrGfOQwdBnCiIvBbHRL(array);
			}
			DWJnXrOBumpLFfmZPjflDMezshO = false;
		}

		private bool nfWiyuOsgLuucxCzCJgnyAtNTIQ(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = GpKTUjLMGVeIHJzINAjLhtehdVC.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (P_0[i] == null)
				{
					continue;
				}
				long? systemId = P_0[i].systemId;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					if (GpKTUjLMGVeIHJzINAjLhtehdVC[j] != null && systemId == GpKTUjLMGVeIHJzINAjLhtehdVC[j].systemId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (GpKTUjLMGVeIHJzINAjLhtehdVC[k] == null)
				{
					continue;
				}
				long? systemId2 = GpKTUjLMGVeIHJzINAjLhtehdVC[k].systemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && systemId2 == P_0[l].systemId)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private void NLNETPIPcIzZWgQktmiidfjpSxOl(List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_0, List<pdAljfPQMTWIfBGcuVQWlQehJAn> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn2 = P_0[i];
				if (pdAljfPQMTWIfBGcuVQWlQehJAn2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						pdAljfPQMTWIfBGcuVQWlQehJAn pdAljfPQMTWIfBGcuVQWlQehJAn3 = P_1[j];
						if (pdAljfPQMTWIfBGcuVQWlQehJAn3 != null && pdAljfPQMTWIfBGcuVQWlQehJAn2.rewiredId == pdAljfPQMTWIfBGcuVQWlQehJAn3.rewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					hKnWXzHpMEBnJfTFKLWhLmnAOHC(P_0[i], P_2);
				}
			}
		}

		private void hKnWXzHpMEBnJfTFKLWhLmnAOHC(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.JJJzpPRKqzeLBeRrcHWpFdprhON();
			}
			SeOMpUlyuBgUKtbtDebWWzGyuLl(P_0, P_1);
		}

		private void SeOMpUlyuBgUKtbtDebWWzGyuLl(pdAljfPQMTWIfBGcuVQWlQehJAn P_0, bool P_1)
		{
			if (P_1)
			{
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(P_0.ToBridgedController());
				}
			}
			else if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
			}
		}
	}
}
