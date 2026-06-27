using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class eyVduWzQgIbYnDfromxoqcJXVyviA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource SxWnEaLlGjyecXbLjaymbYQTHYbx;

			private readonly CustomInputSource EnlwFDAiREahbLVyFnsguhMCJkxj;

			private readonly Controller.Extension dOdLsvfBtAISOeUClhJVKbtvUVjF;

			private int RWTRPukpMssJkjfeyjPUceHZsJAd;

			private int vkSIJWsFJAHEjYjSiLHwDXYcIcOI;

			private long? lDDojeFNCeUEDQCZWlRcYqNXDTMF;

			private int VLxfMMIYakpuPrYRWHIjVKzegVmT;

			public Guid vBjCmkcuEEFmZBUPIvBdtwNDxKRDA;

			public string IbDjhqXJePGVCeXeidqkdiCBeasOb;

			public string RRvccZUCSPSqKvcWNhObfDzppVaP;

			private int gqTenvBQNaFzRUkblJozDezbZwuHB;

			private int OfTleVigpNtQJlJuEEdzCTKvGNVg;

			private float[] gVnsMFuYwFeJjGqTwbVPKoyPouyJ;

			private bool[] hTHQUsEVdClWJJQXJTNdEowGfqkV;

			private float[] phqdTWhQadYlJqEaDRURtUuJcPrh;

			private bool[] vMSGioJlEuCYNzbfcxGprEQRtNFL;

			private HardwareJoystickMap_InputManager qMfbIWbyVqrxiquacicNCYmbmjwYb;

			public CustomInputSource.Joystick SvRrAugTIabaegQbWRKdnlSubMBt;

			private bool BMXfIukqJTImjDVOGmcfLdZTZFqo;

			private readonly bool JObYAVWjBXageUHHJFDxUBRuZvcG;

			private readonly LocalizedString nwZhVbZvjwjGCLhIPFIpFCcIUKxtA;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> pRCiDlKchrpKbGnAcdCjdUTOgYIW;

			public int XgSLhyubfTekhxcfLLyuLvlGjvaH
			{
				get
				{
					if (SvRrAugTIabaegQbWRKdnlSubMBt == null)
					{
						return 0;
					}
					return SvRrAugTIabaegQbWRKdnlSubMBt.buttonCount;
				}
			}

			public int ZGkrTQEPAmbWIPsSUyvqzdMyIJYgA
			{
				get
				{
					if (SvRrAugTIabaegQbWRKdnlSubMBt == null)
					{
						return 0;
					}
					return SvRrAugTIabaegQbWRKdnlSubMBt.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return RWTRPukpMssJkjfeyjPUceHZsJAd;
				}
				set
				{
					RWTRPukpMssJkjfeyjPUceHZsJAd = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return vkSIJWsFJAHEjYjSiLHwDXYcIcOI;
				}
				set
				{
					vkSIJWsFJAHEjYjSiLHwDXYcIcOI = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(SvRrAugTIabaegQbWRKdnlSubMBt.customName)) ? SvRrAugTIabaegQbWRKdnlSubMBt.customName : IbDjhqXJePGVCeXeidqkdiCBeasOb);
					if (text == "Unknown Controller")
					{
						text = RRvccZUCSPSqKvcWNhObfDzppVaP;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => lDDojeFNCeUEDQCZWlRcYqNXDTMF;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => VLxfMMIYakpuPrYRWHIjVKzegVmT;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!lDDojeFNCeUEDQCZWlRcYqNXDTMF.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + lDDojeFNCeUEDQCZWlRcYqNXDTMF);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid
			{
				get
				{
					if (!(SvRrAugTIabaegQbWRKdnlSubMBt.deviceInstanceGuid != Guid.Empty))
					{
						return Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					}
					return SvRrAugTIabaegQbWRKdnlSubMBt.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => dOdLsvfBtAISOeUClhJVKbtvUVjF;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetVibration
				this.SetVibration(amount, motorIndex);
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			void IInputManagerJoystickPublic.StopVibration()
			{
				//ILSpy generated this explicit interface implementation from .override directive in StopVibration
				this.StopVibration();
			}

			public eyVduWzQgIbYnDfromxoqcJXVyviA(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				JObYAVWjBXageUHHJFDxUBRuZvcG = P_0.qPMUMehiHEDlGbNIUsQohQervpgoA == InputSource.PS4 || P_0.qPMUMehiHEDlGbNIUsQohQervpgoA == InputSource.PS5;
				nwZhVbZvjwjGCLhIPFIpFCcIUKxtA = new LocalizedString();
				EnlwFDAiREahbLVyFnsguhMCJkxj = P_0;
				SxWnEaLlGjyecXbLjaymbYQTHYbx = P_4;
				lDDojeFNCeUEDQCZWlRcYqNXDTMF = P_1;
				SvRrAugTIabaegQbWRKdnlSubMBt = P_3;
				VLxfMMIYakpuPrYRWHIjVKzegVmT = P_2;
				dOdLsvfBtAISOeUClhJVKbtvUVjF = P_5;
				pRCiDlKchrpKbGnAcdCjdUTOgYIW = P_6;
				vkSIJWsFJAHEjYjSiLHwDXYcIcOI = -1;
				RWTRPukpMssJkjfeyjPUceHZsJAd = -1;
				ulavAzyjaQgFjfRlqGiqzIvWjjgLA();
				BrAGGSHSMMpkDfPPyORWFSTzYNPR();
				vBjCmkcuEEFmZBUPIvBdtwNDxKRDA = qMfbIWbyVqrxiquacicNCYmbmjwYb.hardwareMapIdentifier.guid;
				IbDjhqXJePGVCeXeidqkdiCBeasOb = qMfbIWbyVqrxiquacicNCYmbmjwYb.controllerName;
				gVnsMFuYwFeJjGqTwbVPKoyPouyJ = new float[gqTenvBQNaFzRUkblJozDezbZwuHB];
				hTHQUsEVdClWJJQXJTNdEowGfqkV = new bool[OfTleVigpNtQJlJuEEdzCTKvGNVg];
				phqdTWhQadYlJqEaDRURtUuJcPrh = new float[OfTleVigpNtQJlJuEEdzCTKvGNVg];
				vMSGioJlEuCYNzbfcxGprEQRtNFL = new bool[OfTleVigpNtQJlJuEEdzCTKvGNVg];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)qMfbIWbyVqrxiquacicNCYmbmjwYb.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, OfTleVigpNtQJlJuEEdzCTKvGNVg);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							vMSGioJlEuCYNzbfcxGprEQRtNFL[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				Update();
			}

			public void ulavAzyjaQgFjfRlqGiqzIvWjjgLA()
			{
				RRvccZUCSPSqKvcWNhObfDzppVaP = SvRrAugTIabaegQbWRKdnlSubMBt.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (SvRrAugTIabaegQbWRKdnlSubMBt.isConnected)
				{
					rSSzxjQNLTffJOlLrLCpSmHFPFAl();
					oFQBTaQEDaYkGoUxLIyzRlFWlzlh();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int rXOqvmdYPpgRKHtFybukkwfmkwHi(eyVduWzQgIbYnDfromxoqcJXVyviA P_0)
			{
				if (P_0.RRvccZUCSPSqKvcWNhObfDzppVaP == RRvccZUCSPSqKvcWNhObfDzppVaP && P_0.lDDojeFNCeUEDQCZWlRcYqNXDTMF == lDDojeFNCeUEDQCZWlRcYqNXDTMF)
				{
					return 2;
				}
				if (P_0.RRvccZUCSPSqKvcWNhObfDzppVaP == RRvccZUCSPSqKvcWNhObfDzppVaP)
				{
					return 1;
				}
				return 0;
			}

			private void AmRaThCmeTYncbtzTLBtqKwxaNBUA(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = SxWnEaLlGjyecXbLjaymbYQTHYbx;
				P_0.inputSource = SxWnEaLlGjyecXbLjaymbYQTHYbx;
				P_0.hardwareIdentifier = qWmOCwxmcBYkCXEDBVuNrpcgIFfu();
				P_0.hardwareAxisCount = gqTenvBQNaFzRUkblJozDezbZwuHB;
				P_0.hardwareButtonCount = OfTleVigpNtQJlJuEEdzCTKvGNVg;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = RRvccZUCSPSqKvcWNhObfDzppVaP;
				P_0.hw_supportsVibration = SvRrAugTIabaegQbWRKdnlSubMBt.supportsVibration;
				P_0.userCustomIdentifier = SvRrAugTIabaegQbWRKdnlSubMBt.customIdentifier;
			}

			private void TYAiqfijCLGKihGgdmuBkzzvWLOPA(BridgedController P_0)
			{
				AmRaThCmeTYncbtzTLBtqKwxaNBUA(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = qMfbIWbyVqrxiquacicNCYmbmjwYb.ToGameHardwareControllerMap();
				P_0.instanceName = RRvccZUCSPSqKvcWNhObfDzppVaP;
				P_0.productName = RRvccZUCSPSqKvcWNhObfDzppVaP;
				P_0.isXInputDevice = false;
				P_0.axisCount = gqTenvBQNaFzRUkblJozDezbZwuHB;
				P_0.buttonCount = OfTleVigpNtQJlJuEEdzCTKvGNVg;
				P_0.controllerTypeGuid = vBjCmkcuEEFmZBUPIvBdtwNDxKRDA;
				P_0.customInputSource = EnlwFDAiREahbLVyFnsguhMCJkxj;
				P_0.controllerExtension = dOdLsvfBtAISOeUClhJVKbtvUVjF;
				P_0.isButtonPressureSensitive = new bool[vMSGioJlEuCYNzbfcxGprEQRtNFL.Length];
				for (int i = 0; i < vMSGioJlEuCYNzbfcxGprEQRtNFL.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = vMSGioJlEuCYNzbfcxGprEQRtNFL[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (gqTenvBQNaFzRUkblJozDezbZwuHB != dataUpdater.axisCount || OfTleVigpNtQJlJuEEdzCTKvGNVg != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < gqTenvBQNaFzRUkblJozDezbZwuHB; i++)
				{
					dataUpdater.axisValues[i] = gVnsMFuYwFeJjGqTwbVPKoyPouyJ[i];
				}
				for (int j = 0; j < OfTleVigpNtQJlJuEEdzCTKvGNVg; j++)
				{
					if (vMSGioJlEuCYNzbfcxGprEQRtNFL[j])
					{
						dataUpdater.buttonPressureValues[j] = phqdTWhQadYlJqEaDRURtUuJcPrh[j];
					}
					dataUpdater.buttonValues[j] = hTHQUsEVdClWJJQXJTNdEowGfqkV[j];
				}
				if (BMXfIukqJTImjDVOGmcfLdZTZFqo && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo VSYBrUGkUcUgwqcWaaPraBIPdaEBb()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				AmRaThCmeTYncbtzTLBtqKwxaNBUA(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				TYAiqfijCLGKihGgdmuBkzzvWLOPA(bridgedController);
				return bridgedController;
			}

			BridgedController IInputManagerJoystick.ToBridgedController()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
				return this.ToBridgedController();
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(RWTRPukpMssJkjfeyjPUceHZsJAd);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void rSSzxjQNLTffJOlLrLCpSmHFPFAl()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)qMfbIWbyVqrxiquacicNCYmbmjwYb.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= gqTenvBQNaFzRUkblJozDezbZwuHB)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						gVnsMFuYwFeJjGqTwbVPKoyPouyJ[i] = ltCFhtaXZZVjAFeULyCvQFqEuyOaA(axes[i]);
						if (!BMXfIukqJTImjDVOGmcfLdZTZFqo && gVnsMFuYwFeJjGqTwbVPKoyPouyJ[i] != 0f)
						{
							BMXfIukqJTImjDVOGmcfLdZTZFqo = true;
						}
					}
				}
			}

			private void oFQBTaQEDaYkGoUxLIyzRlFWlzlh()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)qMfbIWbyVqrxiquacicNCYmbmjwYb.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= OfTleVigpNtQJlJuEEdzCTKvGNVg)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					hTHQUsEVdClWJJQXJTNdEowGfqkV[i] = CvNDtSzsMgAzFkfijokmTNSEcUOO(buttons[i], out phqdTWhQadYlJqEaDRURtUuJcPrh[i]);
					if (!BMXfIukqJTImjDVOGmcfLdZTZFqo && (hTHQUsEVdClWJJQXJTNdEowGfqkV[i] || (vMSGioJlEuCYNzbfcxGprEQRtNFL[i] && phqdTWhQadYlJqEaDRURtUuJcPrh[i] != 0f)))
					{
						BMXfIukqJTImjDVOGmcfLdZTZFqo = true;
					}
				}
			}

			private bool CvNDtSzsMgAzFkfijokmTNSEcUOO(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = hjBqhKBTbdsFlvlawBRFFxiyaHfx(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = FLDgKAFhvITkaPOkwVgvUxDQFYGH(P_0.sourceAxis);
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
					if (num < 0f)
					{
						num *= -1f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					P_1 = num;
					return true;
				}
				P_1 = 0f;
				return false;
			}

			private bool MWKDYMNpGwFQcyZeoRlwQZnRlmmX(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float ltCFhtaXZZVjAFeULyCvQFqEuyOaA(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return FLDgKAFhvITkaPOkwVgvUxDQFYGH(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!hjBqhKBTbdsFlvlawBRFFxiyaHfx(P_0.sourceButton, out var _))
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

			private float FLDgKAFhvITkaPOkwVgvUxDQFYGH(int P_0)
			{
				return SvRrAugTIabaegQbWRKdnlSubMBt.GetAxisValue(P_0);
			}

			private bool hjBqhKBTbdsFlvlawBRFFxiyaHfx(int P_0, out float P_1)
			{
				SvRrAugTIabaegQbWRKdnlSubMBt.dSehppvDTQEdUIfyuJEEaPkHqLxDc(P_0, out var result, out P_1);
				return result;
			}

			private void BrAGGSHSMMpkDfPPyORWFSTzYNPR()
			{
				qMfbIWbyVqrxiquacicNCYmbmjwYb = pRCiDlKchrpKbGnAcdCjdUTOgYIW(VSYBrUGkUcUgwqcWaaPraBIPdaEBb());
				if (qMfbIWbyVqrxiquacicNCYmbmjwYb == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (SvRrAugTIabaegQbWRKdnlSubMBt is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)SvRrAugTIabaegQbWRKdnlSubMBt).InitializeHardwareJoystickMap(qMfbIWbyVqrxiquacicNCYmbmjwYb);
					}
					catch
					{
					}
				}
				gqTenvBQNaFzRUkblJozDezbZwuHB = qMfbIWbyVqrxiquacicNCYmbmjwYb.axisCount;
				OfTleVigpNtQJlJuEEdzCTKvGNVg = qMfbIWbyVqrxiquacicNCYmbmjwYb.buttonCount;
			}

			private void pSSkfpQNbmBNwEsOXuYdOJXXbEhbb()
			{
				Array.Clear(hTHQUsEVdClWJJQXJTNdEowGfqkV, 0, hTHQUsEVdClWJJQXJTNdEowGfqkV.Length);
				Array.Clear(phqdTWhQadYlJqEaDRURtUuJcPrh, 0, phqdTWhQadYlJqEaDRURtUuJcPrh.Length);
				Array.Clear(gVnsMFuYwFeJjGqTwbVPKoyPouyJ, 0, gVnsMFuYwFeJjGqTwbVPKoyPouyJ.Length);
			}

			private string qWmOCwxmcBYkCXEDBVuNrpcgIFfu()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{SxWnEaLlGjyecXbLjaymbYQTHYbx.ToString()}{RRvccZUCSPSqKvcWNhObfDzppVaP}");
				}
				if (pEDFtRXsVNNJtQauegEJObAFaioB.SINAvtVjZlMAWkyjXPhqxZwrawWF)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{pEDFtRXsVNNJtQauegEJObAFaioB.TPRxckMyavAmjfoXmmAeXsRdSkhb()}{RRvccZUCSPSqKvcWNhObfDzppVaP}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{SxWnEaLlGjyecXbLjaymbYQTHYbx.ToString()}{RRvccZUCSPSqKvcWNhObfDzppVaP}");
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (!(SvRrAugTIabaegQbWRKdnlSubMBt is ITryGetLocalizedName))
				{
					if (JObYAVWjBXageUHHJFDxUBRuZvcG)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(nwZhVbZvjwjGCLhIPFIpFCcIUKxtA, qMfbIWbyVqrxiquacicNCYmbmjwYb.deviceLocalizationInfo.parentKeys, "controller", Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
						{
							string text = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename;
							string text2 = null;
							MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
							if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
							{
								text = matchCollection[0].Groups[1].Value;
								text2 = matchCollection[0].Groups[2].Value;
							}
							if (!string.IsNullOrEmpty(text2))
							{
								value = $"{text} {text2}";
							}
							nwZhVbZvjwjGCLhIPFIpFCcIUKxtA.cachedValue = value;
						}
						return true;
					}
					value = null;
					return false;
				}
				return ((ITryGetLocalizedName)SvRrAugTIabaegQbWRKdnlSubMBt).TryGetLocalizedName(out value);
			}

			public static int LqaFkpofiGTBuxLCbAvuSeVVtRZs(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, eyVduWzQgIbYnDfromxoqcJXVyviA P_1)
			{
				if (P_0.vkSIJWsFJAHEjYjSiLHwDXYcIcOI < P_1.vkSIJWsFJAHEjYjSiLHwDXYcIcOI)
				{
					return -1;
				}
				if (P_0.vkSIJWsFJAHEjYjSiLHwDXYcIcOI > P_1.vkSIJWsFJAHEjYjSiLHwDXYcIcOI)
				{
					return 1;
				}
				return 0;
			}

			public static int nnIClPiokMAkubpvBXWEfCPNSLyo(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, eyVduWzQgIbYnDfromxoqcJXVyviA P_1)
			{
				if (P_0.lDDojeFNCeUEDQCZWlRcYqNXDTMF < P_1.lDDojeFNCeUEDQCZWlRcYqNXDTMF)
				{
					return -1;
				}
				if (P_0.lDDojeFNCeUEDQCZWlRcYqNXDTMF > P_1.lDDojeFNCeUEDQCZWlRcYqNXDTMF)
				{
					return 1;
				}
				return 0;
			}
		}

		private class IpSBNuErNChdMRWGNFJstaQooqdhb
		{
			public enum rspcIEgkAHyMYGBXKwYRLNWLUXhg
			{
				Exact = 0,
				Approximate = 1
			}

			public class gvQFKXLghLDqgVFWyDrGkoGXEokBA
			{
				public int OQwaQUxXUbAxlUUGpyRyGBLUZHLI;

				public long? CLhHLmZZeATTVgeVOZreYmrGYEIx;

				public string CchJdODcTzQcwZjVjPJbOLkiseDc;

				public int jdbjYMQTyDTocIEeMmZDCAlVOUrK;

				public int yKJAiOmvIreRCruXLIpzGCEyWtID;

				public int roQQopaATNTbFZJBHMXesWswfHKh;

				public gvQFKXLghLDqgVFWyDrGkoGXEokBA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					OQwaQUxXUbAxlUUGpyRyGBLUZHLI = P_0;
					CLhHLmZZeATTVgeVOZreYmrGYEIx = P_1;
					CchJdODcTzQcwZjVjPJbOLkiseDc = P_2;
					jdbjYMQTyDTocIEeMmZDCAlVOUrK = P_3;
					yKJAiOmvIreRCruXLIpzGCEyWtID = P_4;
					roQQopaATNTbFZJBHMXesWswfHKh = P_5;
				}

				public bool KaLhxEXfFxEkgCgEqvBtLbVIoWiQ(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, rspcIEgkAHyMYGBXKwYRLNWLUXhg P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == OQwaQUxXUbAxlUUGpyRyGBLUZHLI)
					{
						return true;
					}
					if (P_0.XgSLhyubfTekhxcfLLyuLvlGjvaH != yKJAiOmvIreRCruXLIpzGCEyWtID)
					{
						return false;
					}
					if (P_0.ZGkrTQEPAmbWIPsSUyvqzdMyIJYgA != roQQopaATNTbFZJBHMXesWswfHKh)
					{
						return false;
					}
					switch (P_1)
					{
					case rspcIEgkAHyMYGBXKwYRLNWLUXhg.Exact:
						if (CLhHLmZZeATTVgeVOZreYmrGYEIx == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return CchJdODcTzQcwZjVjPJbOLkiseDc == P_0.RRvccZUCSPSqKvcWNhObfDzppVaP;
						}
						return false;
					case rspcIEgkAHyMYGBXKwYRLNWLUXhg.Approximate:
						return CchJdODcTzQcwZjVjPJbOLkiseDc == P_0.RRvccZUCSPSqKvcWNhObfDzppVaP;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class rePvggGmVKnANyEDsdqJwhryiPYQ : IEnumerable<gvQFKXLghLDqgVFWyDrGkoGXEokBA>, IEnumerable, IEnumerator<gvQFKXLghLDqgVFWyDrGkoGXEokBA>, IEnumerator, IDisposable
			{
				private int IQEcVGsTJyGOjGIGVZzDThoEMnXp;

				private gvQFKXLghLDqgVFWyDrGkoGXEokBA GyReSOIdGyyUOBOFgKyYJLwNqsskA;

				private int fCIQAkrfQzyWeStCuOsLmLhDUzNp;

				public IpSBNuErNChdMRWGNFJstaQooqdhb XNsPpUeVGNrxaqGRIHGVQGdOWmmD;

				private eyVduWzQgIbYnDfromxoqcJXVyviA UbIofzxKEpWnBmDYxsjwZJsdmdLg;

				public eyVduWzQgIbYnDfromxoqcJXVyviA uyjFytYoiwByxEeAsXMsIilfAyUeb;

				private rspcIEgkAHyMYGBXKwYRLNWLUXhg SSCjAEIYhIuAdiiQQcnamBAAAslm;

				public rspcIEgkAHyMYGBXKwYRLNWLUXhg WgjNjLMbyZZnlAwotKQqdTyZYngI;

				private int JntwPMiwQzVjyLRTiGckIIQlKeoT;

				private int awthSUtzpUEpFphSgEoIoubZLRQt;

				gvQFKXLghLDqgVFWyDrGkoGXEokBA IEnumerator<gvQFKXLghLDqgVFWyDrGkoGXEokBA>.Current
				{
					[DebuggerHidden]
					get
					{
						return GyReSOIdGyyUOBOFgKyYJLwNqsskA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return GyReSOIdGyyUOBOFgKyYJLwNqsskA;
					}
				}

				[DebuggerHidden]
				public rePvggGmVKnANyEDsdqJwhryiPYQ(int P_0)
				{
					IQEcVGsTJyGOjGIGVZzDThoEMnXp = P_0;
					fCIQAkrfQzyWeStCuOsLmLhDUzNp = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int iQEcVGsTJyGOjGIGVZzDThoEMnXp = IQEcVGsTJyGOjGIGVZzDThoEMnXp;
					IpSBNuErNChdMRWGNFJstaQooqdhb xNsPpUeVGNrxaqGRIHGVQGdOWmmD = XNsPpUeVGNrxaqGRIHGVQGdOWmmD;
					if (iQEcVGsTJyGOjGIGVZzDThoEMnXp != 0)
					{
						if (iQEcVGsTJyGOjGIGVZzDThoEMnXp != 1)
						{
							return false;
						}
						IQEcVGsTJyGOjGIGVZzDThoEMnXp = -1;
						goto IL_0083;
					}
					IQEcVGsTJyGOjGIGVZzDThoEMnXp = -1;
					JntwPMiwQzVjyLRTiGckIIQlKeoT = xNsPpUeVGNrxaqGRIHGVQGdOWmmD.EvmChIxEzpADikyQlhBgnInZEuzbb.Count;
					awthSUtzpUEpFphSgEoIoubZLRQt = 0;
					goto IL_0093;
					IL_0083:
					awthSUtzpUEpFphSgEoIoubZLRQt++;
					goto IL_0093;
					IL_0093:
					if (awthSUtzpUEpFphSgEoIoubZLRQt < JntwPMiwQzVjyLRTiGckIIQlKeoT)
					{
						if (xNsPpUeVGNrxaqGRIHGVQGdOWmmD.EvmChIxEzpADikyQlhBgnInZEuzbb[awthSUtzpUEpFphSgEoIoubZLRQt].KaLhxEXfFxEkgCgEqvBtLbVIoWiQ(UbIofzxKEpWnBmDYxsjwZJsdmdLg, SSCjAEIYhIuAdiiQQcnamBAAAslm))
						{
							GyReSOIdGyyUOBOFgKyYJLwNqsskA = xNsPpUeVGNrxaqGRIHGVQGdOWmmD.EvmChIxEzpADikyQlhBgnInZEuzbb[awthSUtzpUEpFphSgEoIoubZLRQt];
							IQEcVGsTJyGOjGIGVZzDThoEMnXp = 1;
							return true;
						}
						goto IL_0083;
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

				[DebuggerHidden]
				IEnumerator<gvQFKXLghLDqgVFWyDrGkoGXEokBA> IEnumerable<gvQFKXLghLDqgVFWyDrGkoGXEokBA>.GetEnumerator()
				{
					rePvggGmVKnANyEDsdqJwhryiPYQ rePvggGmVKnANyEDsdqJwhryiPYQ2;
					if (IQEcVGsTJyGOjGIGVZzDThoEMnXp == -2 && fCIQAkrfQzyWeStCuOsLmLhDUzNp == Environment.CurrentManagedThreadId)
					{
						IQEcVGsTJyGOjGIGVZzDThoEMnXp = 0;
						rePvggGmVKnANyEDsdqJwhryiPYQ2 = this;
					}
					else
					{
						rePvggGmVKnANyEDsdqJwhryiPYQ2 = new rePvggGmVKnANyEDsdqJwhryiPYQ(0);
						rePvggGmVKnANyEDsdqJwhryiPYQ2.XNsPpUeVGNrxaqGRIHGVQGdOWmmD = XNsPpUeVGNrxaqGRIHGVQGdOWmmD;
					}
					rePvggGmVKnANyEDsdqJwhryiPYQ2.UbIofzxKEpWnBmDYxsjwZJsdmdLg = uyjFytYoiwByxEeAsXMsIilfAyUeb;
					rePvggGmVKnANyEDsdqJwhryiPYQ2.SSCjAEIYhIuAdiiQQcnamBAAAslm = WgjNjLMbyZZnlAwotKQqdTyZYngI;
					return rePvggGmVKnANyEDsdqJwhryiPYQ2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<gvQFKXLghLDqgVFWyDrGkoGXEokBA>)this).GetEnumerator();
				}
			}

			private List<gvQFKXLghLDqgVFWyDrGkoGXEokBA> EvmChIxEzpADikyQlhBgnInZEuzbb;

			public int RaRoWhyTMKobLGCYRhYMFRKZvRys => EvmChIxEzpADikyQlhBgnInZEuzbb.Count;

			public IpSBNuErNChdMRWGNFJstaQooqdhb()
			{
				EvmChIxEzpADikyQlhBgnInZEuzbb = new List<gvQFKXLghLDqgVFWyDrGkoGXEokBA>();
			}

			public void LwZfVRvoWEweKnGTHswjQqhQuysO(eyVduWzQgIbYnDfromxoqcJXVyviA P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = EvmChIxEzpADikyQlhBgnInZEuzbb.Count;
				for (int i = 0; i < count; i++)
				{
					if (EvmChIxEzpADikyQlhBgnInZEuzbb[i].KaLhxEXfFxEkgCgEqvBtLbVIoWiQ(P_0, rspcIEgkAHyMYGBXKwYRLNWLUXhg.Exact))
					{
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].OQwaQUxXUbAxlUUGpyRyGBLUZHLI = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].CLhHLmZZeATTVgeVOZreYmrGYEIx = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].CchJdODcTzQcwZjVjPJbOLkiseDc = P_0.RRvccZUCSPSqKvcWNhObfDzppVaP;
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].jdbjYMQTyDTocIEeMmZDCAlVOUrK = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].yKJAiOmvIreRCruXLIpzGCEyWtID = P_0.XgSLhyubfTekhxcfLLyuLvlGjvaH;
						EvmChIxEzpADikyQlhBgnInZEuzbb[i].roQQopaATNTbFZJBHMXesWswfHKh = P_0.ZGkrTQEPAmbWIPsSUyvqzdMyIJYgA;
						HBPHHbjyJGGFuLSTwfNGSIkEsMwjA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				EvmChIxEzpADikyQlhBgnInZEuzbb.Add(new gvQFKXLghLDqgVFWyDrGkoGXEokBA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.RRvccZUCSPSqKvcWNhObfDzppVaP, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.XgSLhyubfTekhxcfLLyuLvlGjvaH, P_0.ZGkrTQEPAmbWIPsSUyvqzdMyIJYgA));
				HBPHHbjyJGGFuLSTwfNGSIkEsMwjA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, EvmChIxEzpADikyQlhBgnInZEuzbb.Count - 1);
			}

			public bool mhaRPJqziEEmpXmIsBlUcVjuypccA(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, rspcIEgkAHyMYGBXKwYRLNWLUXhg P_1)
			{
				int count = EvmChIxEzpADikyQlhBgnInZEuzbb.Count;
				for (int i = 0; i < count; i++)
				{
					if (EvmChIxEzpADikyQlhBgnInZEuzbb[i].KaLhxEXfFxEkgCgEqvBtLbVIoWiQ(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(rePvggGmVKnANyEDsdqJwhryiPYQ))]
			public IEnumerable<gvQFKXLghLDqgVFWyDrGkoGXEokBA> tPJioQHxKFaLgOtRsFvwzlAjIHlV(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, rspcIEgkAHyMYGBXKwYRLNWLUXhg P_1)
			{
				return new rePvggGmVKnANyEDsdqJwhryiPYQ(-2)
				{
					XNsPpUeVGNrxaqGRIHGVQGdOWmmD = this,
					uyjFytYoiwByxEeAsXMsIilfAyUeb = P_0,
					WgjNjLMbyZZnlAwotKQqdTyZYngI = P_1
				};
			}

			public int UnvtngqyxynZvAyGcBSJhZnUwJCn(gvQFKXLghLDqgVFWyDrGkoGXEokBA P_0)
			{
				int count = EvmChIxEzpADikyQlhBgnInZEuzbb.Count;
				for (int i = 0; i < count; i++)
				{
					if (EvmChIxEzpADikyQlhBgnInZEuzbb[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void HBPHHbjyJGGFuLSTwfNGSIkEsMwjA(int P_0, int P_1)
			{
				for (int num = EvmChIxEzpADikyQlhBgnInZEuzbb.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && EvmChIxEzpADikyQlhBgnInZEuzbb[num].OQwaQUxXUbAxlUUGpyRyGBLUZHLI == P_0)
					{
						EvmChIxEzpADikyQlhBgnInZEuzbb.RemoveAt(num);
					}
				}
			}
		}

		private List<eyVduWzQgIbYnDfromxoqcJXVyviA> ojDcGeuhnvAODCHujPqyCZIEiUPf;

		private int lFhKVRrCTEXuAFJMetDxrNCIIQmn;

		private IpSBNuErNChdMRWGNFJstaQooqdhb AgcnGHbauOzPhjrbRDUWuUbcyqyd;

		private UpdateLoopType wwnSqLFoOhgjotAOToMEJIOjaeOEA;

		private Action<int, ControllerDataUpdater> AycaqMCsQpDAqdmcBYEoNhckKEHoB;

		private PlatformInputManager aioLuPBkordoTRFRrhvsFQqjgcML;

		private CustomInputSource qgoIAuAbyIKutqpniAywEngjdDkcA;

		private bool oRpAJtatvhGXNqAhDIgCLSeNxjgnA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> WgbsmBaEGetsLNhfqUsDHbaYNuOo;

		private Func<int> CYQcxvtxINofYnjUuAzGdEjAUqNK;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => lFhKVRrCTEXuAFJMetDxrNCIIQmn;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => aioLuPBkordoTRFRrhvsFQqjgcML;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => qgoIAuAbyIKutqpniAywEngjdDkcA.qPMUMehiHEDlGbNIUsQohQervpgoA;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			qgoIAuAbyIKutqpniAywEngjdDkcA = P_0;
			WgbsmBaEGetsLNhfqUsDHbaYNuOo = P_2;
			CYQcxvtxINofYnjUuAzGdEjAUqNK = P_3;
			aioLuPBkordoTRFRrhvsFQqjgcML = this;
			try
			{
				AycaqMCsQpDAqdmcBYEoNhckKEHoB = UpdateControllerData;
				P_0.WCoAzlaXXzRdOenGFGiicoQXERqTA += SystemDeviceConnected;
				P_0.oNzWdKopEkCqTjVyaPJBAwAupHAoA += SystemDeviceDisconnected;
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
			AgcnGHbauOzPhjrbRDUWuUbcyqyd = new IpSBNuErNChdMRWGNFJstaQooqdhb();
			ojDcGeuhnvAODCHujPqyCZIEiUPf = new List<eyVduWzQgIbYnDfromxoqcJXVyviA>();
			oRpAJtatvhGXNqAhDIgCLSeNxjgnA = true;
			qgoIAuAbyIKutqpniAywEngjdDkcA.PusaYVcABdgihSkdmyFkhbobGEPF();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			wwnSqLFoOhgjotAOToMEJIOjaeOEA = updateLoop;
			if (qgoIAuAbyIKutqpniAywEngjdDkcA.isReady)
			{
				qgoIAuAbyIKutqpniAywEngjdDkcA.Update();
				qgoIAuAbyIKutqpniAywEngjdDkcA.jVehwmutETkRglGYTdMvCzjrpzjL();
				if (oRpAJtatvhGXNqAhDIgCLSeNxjgnA)
				{
					bfQNqHRTKScGFhxePAJgPlxbzOKl();
				}
				WJXJrufmnGUNbzNdSYOXxuQTePAH();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (qgoIAuAbyIKutqpniAywEngjdDkcA != null)
			{
				qgoIAuAbyIKutqpniAywEngjdDkcA.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return AycaqMCsQpDAqdmcBYEoNhckKEHoB;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < lFhKVRrCTEXuAFJMetDxrNCIIQmn; i++)
			{
				if (ojDcGeuhnvAODCHujPqyCZIEiUPf[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					ojDcGeuhnvAODCHujPqyCZIEiUPf[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			oRpAJtatvhGXNqAhDIgCLSeNxjgnA = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			oRpAJtatvhGXNqAhDIgCLSeNxjgnA = true;
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
			return qgoIAuAbyIKutqpniAywEngjdDkcA.BsgRyFJghmDeJarLdvjREaudnpHP();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return qgoIAuAbyIKutqpniAywEngjdDkcA.WGiWTegEKFEInJWOSunAWtaqdWCUA();
		}

		private void LVwRVfDlxbPsStxJvHNWWzzhSXhR(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<eyVduWzQgIbYnDfromxoqcJXVyviA> list = ojDcGeuhnvAODCHujPqyCZIEiUPf;
			int num2 = lFhKVRrCTEXuAFJMetDxrNCIIQmn;
			ojDcGeuhnvAODCHujPqyCZIEiUPf = new List<eyVduWzQgIbYnDfromxoqcJXVyviA>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					eyVduWzQgIbYnDfromxoqcJXVyviA item = new eyVduWzQgIbYnDfromxoqcJXVyviA(qgoIAuAbyIKutqpniAywEngjdDkcA, P_0[i].systemId, P_0[i].unityId, P_0[i], qgoIAuAbyIKutqpniAywEngjdDkcA.qPMUMehiHEDlGbNIUsQohQervpgoA, P_0[i].extension, WgbsmBaEGetsLNhfqUsDHbaYNuOo);
					ojDcGeuhnvAODCHujPqyCZIEiUPf.Add(item);
					num++;
				}
			}
			lFhKVRrCTEXuAFJMetDxrNCIIQmn = num;
			hzdEDaicvzasfJXyGwlpyXJIGpOF(num2, num, list, ojDcGeuhnvAODCHujPqyCZIEiUPf);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(ojDcGeuhnvAODCHujPqyCZIEiUPf[j]));
				}
			}
			AIDxtEtfiVSZqYxOKuyGpEscfEZS(list, ojDcGeuhnvAODCHujPqyCZIEiUPf, false);
			AIDxtEtfiVSZqYxOKuyGpEscfEZS(ojDcGeuhnvAODCHujPqyCZIEiUPf, list, true);
		}

		private void WJXJrufmnGUNbzNdSYOXxuQTePAH()
		{
			for (int i = 0; i < lFhKVRrCTEXuAFJMetDxrNCIIQmn; i++)
			{
				ojDcGeuhnvAODCHujPqyCZIEiUPf[i].Update();
			}
		}

		private void hzdEDaicvzasfJXyGwlpyXJIGpOF(int P_0, int P_1, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_2, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(eyVduWzQgIbYnDfromxoqcJXVyviA.nnIClPiokMAkubpvBXWEfCPNSLyo);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				LLwbbpkRCBQevtzDiNIijqgSRxOy(P_1, P_3, P_0, P_2, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg.Exact);
				if (qgoIAuAbyIKutqpniAywEngjdDkcA.useApproximateMatching)
				{
					LLwbbpkRCBQevtzDiNIijqgSRxOy(P_1, P_3, P_0, P_2, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg.Approximate);
				}
			}
			mkzXegYYxOgLByoddqtuWbtlTcRi(P_1, P_3, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg.Exact);
			if (qgoIAuAbyIKutqpniAywEngjdDkcA.useApproximateMatching)
			{
				mkzXegYYxOgLByoddqtuWbtlTcRi(P_1, P_3, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA2 = P_3[i];
				if (eyVduWzQgIbYnDfromxoqcJXVyviA2 != null && eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = nYaaklJGCNAyASHFObAlgmFhLgRBB(P_3);
					eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					AgcnGHbauOzPhjrbRDUWuUbcyqyd.LwZfVRvoWEweKnGTHswjQqhQuysO(eyVduWzQgIbYnDfromxoqcJXVyviA2);
				}
			}
			P_3.Sort(eyVduWzQgIbYnDfromxoqcJXVyviA.LqaFkpofiGTBuxLCbAvuSeVVtRZs);
		}

		private void wYeYfkGLnFJwAnafrjFOuwkDeCgf(List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_0, int P_1, int P_2)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != P_1 && P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_2)
				{
					P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = -1;
				}
			}
		}

		private bool uJktjMGgOWsAKUHJcxEEPiCHXFpg(List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == P_1)
				{
					return false;
				}
			}
			return true;
		}

		private int nYaaklJGCNAyASHFObAlgmFhLgRBB(List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_0)
		{
			int num = 0;
			while (true)
			{
				bool flag = false;
				int count = P_0.Count;
				for (int i = 0; i < count; i++)
				{
					if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == num)
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

		private bool ihAwQdeFtOatZuEBjBCmZwNaaKGAA(List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return false;
			}
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		private void LLwbbpkRCBQevtzDiNIijqgSRxOy(int P_0, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_1, int P_2, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_3, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg P_4)
		{
			int num = ((P_4 != IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA2 = P_1[i];
				if (eyVduWzQgIbYnDfromxoqcJXVyviA2 == null || eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA3 = P_3[j];
					if (eyVduWzQgIbYnDfromxoqcJXVyviA3 != null && !ihAwQdeFtOatZuEBjBCmZwNaaKGAA(P_1, eyVduWzQgIbYnDfromxoqcJXVyviA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && eyVduWzQgIbYnDfromxoqcJXVyviA2.rXOqvmdYPpgRKHtFybukkwfmkwHi(eyVduWzQgIbYnDfromxoqcJXVyviA3) >= num)
					{
						eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = eyVduWzQgIbYnDfromxoqcJXVyviA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = eyVduWzQgIbYnDfromxoqcJXVyviA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						AgcnGHbauOzPhjrbRDUWuUbcyqyd.LwZfVRvoWEweKnGTHswjQqhQuysO(eyVduWzQgIbYnDfromxoqcJXVyviA2);
					}
				}
			}
		}

		private void mkzXegYYxOgLByoddqtuWbtlTcRi(int P_0, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_1, IpSBNuErNChdMRWGNFJstaQooqdhb.rspcIEgkAHyMYGBXKwYRLNWLUXhg P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA2 = P_1[i];
				if (eyVduWzQgIbYnDfromxoqcJXVyviA2 == null || eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				IpSBNuErNChdMRWGNFJstaQooqdhb.gvQFKXLghLDqgVFWyDrGkoGXEokBA gvQFKXLghLDqgVFWyDrGkoGXEokBA = null;
				foreach (IpSBNuErNChdMRWGNFJstaQooqdhb.gvQFKXLghLDqgVFWyDrGkoGXEokBA item in AgcnGHbauOzPhjrbRDUWuUbcyqyd.tPJioQHxKFaLgOtRsFvwzlAjIHlV(eyVduWzQgIbYnDfromxoqcJXVyviA2, P_2))
				{
					if (!ihAwQdeFtOatZuEBjBCmZwNaaKGAA(P_1, item.OQwaQUxXUbAxlUUGpyRyGBLUZHLI) && item.jdbjYMQTyDTocIEeMmZDCAlVOUrK >= 0)
					{
						gvQFKXLghLDqgVFWyDrGkoGXEokBA = item;
						break;
					}
				}
				if (gvQFKXLghLDqgVFWyDrGkoGXEokBA != null)
				{
					int num = gvQFKXLghLDqgVFWyDrGkoGXEokBA.jdbjYMQTyDTocIEeMmZDCAlVOUrK;
					if (!uJktjMGgOWsAKUHJcxEEPiCHXFpg(P_1, num))
					{
						num = (gvQFKXLghLDqgVFWyDrGkoGXEokBA.jdbjYMQTyDTocIEeMmZDCAlVOUrK = nYaaklJGCNAyASHFObAlgmFhLgRBB(P_1));
					}
					eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = gvQFKXLghLDqgVFWyDrGkoGXEokBA.OQwaQUxXUbAxlUUGpyRyGBLUZHLI;
					AgcnGHbauOzPhjrbRDUWuUbcyqyd.LwZfVRvoWEweKnGTHswjQqhQuysO(eyVduWzQgIbYnDfromxoqcJXVyviA2);
				}
			}
		}

		private void bfQNqHRTKScGFhxePAJgPlxbzOKl()
		{
			CustomInputSource.Joystick[] array = qgoIAuAbyIKutqpniAywEngjdDkcA.CCyTkYTATYWcfKUbohfTFZlqDLBe();
			if (EDTBnMMXqgizXufJETvmDvZyOhdO(array))
			{
				LVwRVfDlxbPsStxJvHNWWzzhSXhR(array);
			}
			oRpAJtatvhGXNqAhDIgCLSeNxjgnA = false;
		}

		private bool EDTBnMMXqgizXufJETvmDvZyOhdO(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = ojDcGeuhnvAODCHujPqyCZIEiUPf.Count;
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
					if (ojDcGeuhnvAODCHujPqyCZIEiUPf[j] != null && systemId == ojDcGeuhnvAODCHujPqyCZIEiUPf[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
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
				if (ojDcGeuhnvAODCHujPqyCZIEiUPf[k] == null)
				{
					continue;
				}
				long? num2 = ojDcGeuhnvAODCHujPqyCZIEiUPf[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && num2 == P_0[l].systemId)
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

		private void AIDxtEtfiVSZqYxOKuyGpEscfEZS(List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_0, List<eyVduWzQgIbYnDfromxoqcJXVyviA> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA2 = P_0[i];
				if (eyVduWzQgIbYnDfromxoqcJXVyviA2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						eyVduWzQgIbYnDfromxoqcJXVyviA eyVduWzQgIbYnDfromxoqcJXVyviA3 = P_1[j];
						if (eyVduWzQgIbYnDfromxoqcJXVyviA3 != null && eyVduWzQgIbYnDfromxoqcJXVyviA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == eyVduWzQgIbYnDfromxoqcJXVyviA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					tKjKMFpRWnYqIIlEvwlfnEHUPBLW(P_0[i], P_2);
				}
			}
		}

		private void tKjKMFpRWnYqIIlEvwlfnEHUPBLW(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.ulavAzyjaQgFjfRlqGiqzIvWjjgLA();
			}
			LSdZcVBGmojFmXPsDCWwxKqWwiyC(P_0, P_1);
		}

		private void LSdZcVBGmojFmXPsDCWwxKqWwiyC(eyVduWzQgIbYnDfromxoqcJXVyviA P_0, bool P_1)
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
