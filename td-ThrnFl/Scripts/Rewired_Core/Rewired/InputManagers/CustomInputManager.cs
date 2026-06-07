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
		private class SDUJIneDmUtGBcIuxagRJCnUDALIA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource yEXcjFYHWfRZAKCIwdRBzHkOicFo;

			private readonly CustomInputSource cIsCLgXSDWhNBWuzQbkJeTmPizHfb;

			private readonly Controller.Extension DDiHeEAinEklwIzDmayejMDaJaPaA;

			private int nKWewTcjbusXKMsczketJNWSmUwRA;

			private int VzRgvjftNWBaFSNBvPWTpiopDuwQA;

			private long? JzEVRLKuDkVlxNaYZGkPJtdCvlsaA;

			private int vUanYrXhuiJltmeKHFLSgtZrCtUV;

			public Guid RHiTgTleCATtdTgIFKmKXspEsQrJ;

			public string epYKoVQtcRakoQgnlbOVLqoxIoQj;

			public string fFqGTyCZUNihcOqDEnLSaIBdgpOmB;

			private int YAUCBSBKLqYAjhhiwfsEHaRSDKSm;

			private int aZUZEmpYxJeMduWnFaVCbjugeajhA;

			private float[] CJictgfEiBZoTDXKxlOmrPIWFCAT;

			private bool[] ZcGFtDBGdUuxvAlSCfGGhSOTESQk;

			private float[] XyphYviikzHvvrzfYISwAiSAeIZr;

			private bool[] JARahXBOnmQnteSwrwuSALeSZNzW;

			private HardwareJoystickMap_InputManager MSgbnrdXqwYnArpfpndudgEzHCUl;

			public CustomInputSource.Joystick aKMbhPxZYoqTKzVuTMJCYvazJofs;

			private bool puAdZDdaPLTFPQTZRxZWqAxSvzSH;

			private readonly bool rDwAvrGNtTyDUgBWYtSQrdxxExAtA;

			private readonly LocalizedString TDSoTGOPpyzbaGWVIFKElzYToORI;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HAFcYYJMpxxEBRdZtFtOWGxNbcso;

			public int tsPMmRndnTFHHJeeWYdZAgVPUFSdA
			{
				get
				{
					if (aKMbhPxZYoqTKzVuTMJCYvazJofs == null)
					{
						return 0;
					}
					return aKMbhPxZYoqTKzVuTMJCYvazJofs.buttonCount;
				}
			}

			public int dvjiRdXbQeJzcGSBTQsHQwadOnkV
			{
				get
				{
					if (aKMbhPxZYoqTKzVuTMJCYvazJofs == null)
					{
						return 0;
					}
					return aKMbhPxZYoqTKzVuTMJCYvazJofs.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return nKWewTcjbusXKMsczketJNWSmUwRA;
				}
				set
				{
					nKWewTcjbusXKMsczketJNWSmUwRA = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return VzRgvjftNWBaFSNBvPWTpiopDuwQA;
				}
				set
				{
					VzRgvjftNWBaFSNBvPWTpiopDuwQA = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(aKMbhPxZYoqTKzVuTMJCYvazJofs.customName)) ? aKMbhPxZYoqTKzVuTMJCYvazJofs.customName : epYKoVQtcRakoQgnlbOVLqoxIoQj);
					if (text == "Unknown Controller")
					{
						text = fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => JzEVRLKuDkVlxNaYZGkPJtdCvlsaA;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => vUanYrXhuiJltmeKHFLSgtZrCtUV;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!JzEVRLKuDkVlxNaYZGkPJtdCvlsaA.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + JzEVRLKuDkVlxNaYZGkPJtdCvlsaA);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid
			{
				get
				{
					if (!(aKMbhPxZYoqTKzVuTMJCYvazJofs.deviceInstanceGuid != Guid.Empty))
					{
						return Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					}
					return aKMbhPxZYoqTKzVuTMJCYvazJofs.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => DDiHeEAinEklwIzDmayejMDaJaPaA;

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

			public SDUJIneDmUtGBcIuxagRJCnUDALIA(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				rDwAvrGNtTyDUgBWYtSQrdxxExAtA = P_0.UBbrNuHNAOPoYVpJFeDjfSwRqCj == InputSource.PS4 || P_0.UBbrNuHNAOPoYVpJFeDjfSwRqCj == InputSource.PS5;
				TDSoTGOPpyzbaGWVIFKElzYToORI = new LocalizedString();
				cIsCLgXSDWhNBWuzQbkJeTmPizHfb = P_0;
				yEXcjFYHWfRZAKCIwdRBzHkOicFo = P_4;
				JzEVRLKuDkVlxNaYZGkPJtdCvlsaA = P_1;
				aKMbhPxZYoqTKzVuTMJCYvazJofs = P_3;
				vUanYrXhuiJltmeKHFLSgtZrCtUV = P_2;
				DDiHeEAinEklwIzDmayejMDaJaPaA = P_5;
				HAFcYYJMpxxEBRdZtFtOWGxNbcso = P_6;
				VzRgvjftNWBaFSNBvPWTpiopDuwQA = -1;
				nKWewTcjbusXKMsczketJNWSmUwRA = -1;
				UlFzCXbwSuwVGKylmtBptPHHFMaA();
				dVDtmxJbSEVOxCdCbGhtkgpgDprt();
				RHiTgTleCATtdTgIFKmKXspEsQrJ = MSgbnrdXqwYnArpfpndudgEzHCUl.hardwareMapIdentifier.guid;
				epYKoVQtcRakoQgnlbOVLqoxIoQj = MSgbnrdXqwYnArpfpndudgEzHCUl.controllerName;
				CJictgfEiBZoTDXKxlOmrPIWFCAT = new float[YAUCBSBKLqYAjhhiwfsEHaRSDKSm];
				ZcGFtDBGdUuxvAlSCfGGhSOTESQk = new bool[aZUZEmpYxJeMduWnFaVCbjugeajhA];
				XyphYviikzHvvrzfYISwAiSAeIZr = new float[aZUZEmpYxJeMduWnFaVCbjugeajhA];
				JARahXBOnmQnteSwrwuSALeSZNzW = new bool[aZUZEmpYxJeMduWnFaVCbjugeajhA];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)MSgbnrdXqwYnArpfpndudgEzHCUl.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, aZUZEmpYxJeMduWnFaVCbjugeajhA);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							JARahXBOnmQnteSwrwuSALeSZNzW[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				Update();
			}

			public void UlFzCXbwSuwVGKylmtBptPHHFMaA()
			{
				fFqGTyCZUNihcOqDEnLSaIBdgpOmB = aKMbhPxZYoqTKzVuTMJCYvazJofs.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (aKMbhPxZYoqTKzVuTMJCYvazJofs.isConnected)
				{
					LlPKGEXeJLhWrdVQkTOUuvtYEpgDb();
					KRVEwRHrTmurchyoKERKiqpJWNVO();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int BIRRJZmmVxKDwWJGvUeJNGBbYMtv(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0)
			{
				if (P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB == fFqGTyCZUNihcOqDEnLSaIBdgpOmB && P_0.JzEVRLKuDkVlxNaYZGkPJtdCvlsaA == JzEVRLKuDkVlxNaYZGkPJtdCvlsaA)
				{
					return 2;
				}
				if (P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB == fFqGTyCZUNihcOqDEnLSaIBdgpOmB)
				{
					return 1;
				}
				return 0;
			}

			private void wRQiUCvmoLOJCaqqQKESdQwqtpbC(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = yEXcjFYHWfRZAKCIwdRBzHkOicFo;
				P_0.inputSource = yEXcjFYHWfRZAKCIwdRBzHkOicFo;
				P_0.hardwareIdentifier = EEhblXwucPGJuIHUCdneAwQtbbXHA();
				P_0.hardwareAxisCount = YAUCBSBKLqYAjhhiwfsEHaRSDKSm;
				P_0.hardwareButtonCount = aZUZEmpYxJeMduWnFaVCbjugeajhA;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
				P_0.hw_supportsVibration = aKMbhPxZYoqTKzVuTMJCYvazJofs.supportsVibration;
				P_0.userCustomIdentifier = aKMbhPxZYoqTKzVuTMJCYvazJofs.customIdentifier;
			}

			private void zgDTXIxREXnhOZEnefOkSCLohHek(BridgedController P_0)
			{
				wRQiUCvmoLOJCaqqQKESdQwqtpbC(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = MSgbnrdXqwYnArpfpndudgEzHCUl.ToGameHardwareControllerMap();
				P_0.instanceName = fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
				P_0.productName = fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
				P_0.isXInputDevice = false;
				P_0.axisCount = YAUCBSBKLqYAjhhiwfsEHaRSDKSm;
				P_0.buttonCount = aZUZEmpYxJeMduWnFaVCbjugeajhA;
				P_0.controllerTypeGuid = RHiTgTleCATtdTgIFKmKXspEsQrJ;
				P_0.customInputSource = cIsCLgXSDWhNBWuzQbkJeTmPizHfb;
				P_0.controllerExtension = DDiHeEAinEklwIzDmayejMDaJaPaA;
				P_0.isButtonPressureSensitive = new bool[JARahXBOnmQnteSwrwuSALeSZNzW.Length];
				for (int i = 0; i < JARahXBOnmQnteSwrwuSALeSZNzW.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = JARahXBOnmQnteSwrwuSALeSZNzW[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (YAUCBSBKLqYAjhhiwfsEHaRSDKSm != dataUpdater.axisCount || aZUZEmpYxJeMduWnFaVCbjugeajhA != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < YAUCBSBKLqYAjhhiwfsEHaRSDKSm; i++)
				{
					dataUpdater.axisValues[i] = CJictgfEiBZoTDXKxlOmrPIWFCAT[i];
				}
				for (int j = 0; j < aZUZEmpYxJeMduWnFaVCbjugeajhA; j++)
				{
					if (JARahXBOnmQnteSwrwuSALeSZNzW[j])
					{
						dataUpdater.buttonPressureValues[j] = XyphYviikzHvvrzfYISwAiSAeIZr[j];
					}
					dataUpdater.buttonValues[j] = ZcGFtDBGdUuxvAlSCfGGhSOTESQk[j];
				}
				if (puAdZDdaPLTFPQTZRxZWqAxSvzSH && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo fDTuKfJVYiBBEjLVfYtYizeGSImH()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				wRQiUCvmoLOJCaqqQKESdQwqtpbC(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				zgDTXIxREXnhOZEnefOkSCLohHek(bridgedController);
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
				return new ControllerDisconnectedEventArgs(nKWewTcjbusXKMsczketJNWSmUwRA);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void LlPKGEXeJLhWrdVQkTOUuvtYEpgDb()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)MSgbnrdXqwYnArpfpndudgEzHCUl.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= YAUCBSBKLqYAjhhiwfsEHaRSDKSm)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						CJictgfEiBZoTDXKxlOmrPIWFCAT[i] = ZYDGUKOXvXAfypJTOPdWwDODQEeK(axes[i]);
						if (!puAdZDdaPLTFPQTZRxZWqAxSvzSH && CJictgfEiBZoTDXKxlOmrPIWFCAT[i] != 0f)
						{
							puAdZDdaPLTFPQTZRxZWqAxSvzSH = true;
						}
					}
				}
			}

			private void KRVEwRHrTmurchyoKERKiqpJWNVO()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)MSgbnrdXqwYnArpfpndudgEzHCUl.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= aZUZEmpYxJeMduWnFaVCbjugeajhA)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					ZcGFtDBGdUuxvAlSCfGGhSOTESQk[i] = yIOECferYoCHflNhwnJRifcLkpam(buttons[i], out XyphYviikzHvvrzfYISwAiSAeIZr[i]);
					if (!puAdZDdaPLTFPQTZRxZWqAxSvzSH && (ZcGFtDBGdUuxvAlSCfGGhSOTESQk[i] || (JARahXBOnmQnteSwrwuSALeSZNzW[i] && XyphYviikzHvvrzfYISwAiSAeIZr[i] != 0f)))
					{
						puAdZDdaPLTFPQTZRxZWqAxSvzSH = true;
					}
				}
			}

			private bool yIOECferYoCHflNhwnJRifcLkpam(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = LxEaAvECrpScRocdtCMedkKvMhRib(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = nAYiHfIMjMyiQCItlnWMuhbFkxmsA(P_0.sourceAxis);
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

			private bool iKNrczAmQgzvCtRdtafDdoZIMpCi(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float ZYDGUKOXvXAfypJTOPdWwDODQEeK(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return nAYiHfIMjMyiQCItlnWMuhbFkxmsA(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!LxEaAvECrpScRocdtCMedkKvMhRib(P_0.sourceButton, out var _))
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

			private float nAYiHfIMjMyiQCItlnWMuhbFkxmsA(int P_0)
			{
				return aKMbhPxZYoqTKzVuTMJCYvazJofs.GetAxisValue(P_0);
			}

			private bool LxEaAvECrpScRocdtCMedkKvMhRib(int P_0, out float P_1)
			{
				aKMbhPxZYoqTKzVuTMJCYvazJofs.JafKEWccZWCEqaqrhtFtsEYjJfLW(P_0, out var result, out P_1);
				return result;
			}

			private void dVDtmxJbSEVOxCdCbGhtkgpgDprt()
			{
				MSgbnrdXqwYnArpfpndudgEzHCUl = HAFcYYJMpxxEBRdZtFtOWGxNbcso(fDTuKfJVYiBBEjLVfYtYizeGSImH());
				if (MSgbnrdXqwYnArpfpndudgEzHCUl == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (aKMbhPxZYoqTKzVuTMJCYvazJofs is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)aKMbhPxZYoqTKzVuTMJCYvazJofs).InitializeHardwareJoystickMap(MSgbnrdXqwYnArpfpndudgEzHCUl);
					}
					catch
					{
					}
				}
				YAUCBSBKLqYAjhhiwfsEHaRSDKSm = MSgbnrdXqwYnArpfpndudgEzHCUl.axisCount;
				aZUZEmpYxJeMduWnFaVCbjugeajhA = MSgbnrdXqwYnArpfpndudgEzHCUl.buttonCount;
			}

			private void PBVYhSLxtigEQfaHSdJCipbWLeVP()
			{
				Array.Clear(ZcGFtDBGdUuxvAlSCfGGhSOTESQk, 0, ZcGFtDBGdUuxvAlSCfGGhSOTESQk.Length);
				Array.Clear(XyphYviikzHvvrzfYISwAiSAeIZr, 0, XyphYviikzHvvrzfYISwAiSAeIZr.Length);
				Array.Clear(CJictgfEiBZoTDXKxlOmrPIWFCAT, 0, CJictgfEiBZoTDXKxlOmrPIWFCAT.Length);
			}

			private string EEhblXwucPGJuIHUCdneAwQtbbXHA()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{yEXcjFYHWfRZAKCIwdRBzHkOicFo.ToString()}{fFqGTyCZUNihcOqDEnLSaIBdgpOmB}");
				}
				if (NaCVyIMwuDhgdNZldvvjhuHYfOGS.gWMFbUBERbzpcApqKNWTmCSqQImmA)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{NaCVyIMwuDhgdNZldvvjhuHYfOGS.bfUYAJLLcdCnQKqrtJljgsAhkoOuB()}{fFqGTyCZUNihcOqDEnLSaIBdgpOmB}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{yEXcjFYHWfRZAKCIwdRBzHkOicFo.ToString()}{fFqGTyCZUNihcOqDEnLSaIBdgpOmB}");
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (!(aKMbhPxZYoqTKzVuTMJCYvazJofs is ITryGetLocalizedName))
				{
					if (rDwAvrGNtTyDUgBWYtSQrdxxExAtA)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(TDSoTGOPpyzbaGWVIFKElzYToORI, MSgbnrdXqwYnArpfpndudgEzHCUl.deviceLocalizationInfo.parentKeys, "controller", Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
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
							TDSoTGOPpyzbaGWVIFKElzYToORI.cachedValue = value;
						}
						return true;
					}
					value = null;
					return false;
				}
				return ((ITryGetLocalizedName)aKMbhPxZYoqTKzVuTMJCYvazJofs).TryGetLocalizedName(out value);
			}

			public static int pexXXEvFaKiNSkgLqoeRllzMzeri(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, SDUJIneDmUtGBcIuxagRJCnUDALIA P_1)
			{
				if (P_0.VzRgvjftNWBaFSNBvPWTpiopDuwQA < P_1.VzRgvjftNWBaFSNBvPWTpiopDuwQA)
				{
					return -1;
				}
				if (P_0.VzRgvjftNWBaFSNBvPWTpiopDuwQA > P_1.VzRgvjftNWBaFSNBvPWTpiopDuwQA)
				{
					return 1;
				}
				return 0;
			}

			public static int RzPqQkvrwWPFCeXeIDZxSafMrjQm(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, SDUJIneDmUtGBcIuxagRJCnUDALIA P_1)
			{
				if (P_0.JzEVRLKuDkVlxNaYZGkPJtdCvlsaA < P_1.JzEVRLKuDkVlxNaYZGkPJtdCvlsaA)
				{
					return -1;
				}
				if (P_0.JzEVRLKuDkVlxNaYZGkPJtdCvlsaA > P_1.JzEVRLKuDkVlxNaYZGkPJtdCvlsaA)
				{
					return 1;
				}
				return 0;
			}
		}

		private class kTViNRyPqOEdwHLqGSaZDuqfIuNC
		{
			public enum ZhmFDrxuGTFVyhBATMzaggkdSqDrB
			{
				Exact = 0,
				Approximate = 1
			}

			public class SpXgqgJYlBmyQBYVrDotvBmKhKWOA
			{
				public int wHvLVjoBAfrbNJuJaPvPdBxFMhjx;

				public long? sAcyiZMIeWaPfhCrFgZXrJxTgAoD;

				public string yPexyQEYcfhECAxsQGiwfCfxSjMF;

				public int RswnNdRTwFNAGDOpNUAipSDYiDHl;

				public int GaOafvbjhbuLucUlUXLIbbqlygmS;

				public int ZdNjvWcdKPPytUfAIiPPbJEfbVsxA;

				public SpXgqgJYlBmyQBYVrDotvBmKhKWOA(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					wHvLVjoBAfrbNJuJaPvPdBxFMhjx = P_0;
					sAcyiZMIeWaPfhCrFgZXrJxTgAoD = P_1;
					yPexyQEYcfhECAxsQGiwfCfxSjMF = P_2;
					RswnNdRTwFNAGDOpNUAipSDYiDHl = P_3;
					GaOafvbjhbuLucUlUXLIbbqlygmS = P_4;
					ZdNjvWcdKPPytUfAIiPPbJEfbVsxA = P_5;
				}

				public bool omOPWfIKRjGJINgXdCWWmTtVGwWbA(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, ZhmFDrxuGTFVyhBATMzaggkdSqDrB P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == wHvLVjoBAfrbNJuJaPvPdBxFMhjx)
					{
						return true;
					}
					if (P_0.tsPMmRndnTFHHJeeWYdZAgVPUFSdA != GaOafvbjhbuLucUlUXLIbbqlygmS)
					{
						return false;
					}
					if (P_0.dvjiRdXbQeJzcGSBTQsHQwadOnkV != ZdNjvWcdKPPytUfAIiPPbJEfbVsxA)
					{
						return false;
					}
					switch (P_1)
					{
					case ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Exact:
						if (sAcyiZMIeWaPfhCrFgZXrJxTgAoD == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return yPexyQEYcfhECAxsQGiwfCfxSjMF == P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
						}
						return false;
					case ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Approximate:
						return yPexyQEYcfhECAxsQGiwfCfxSjMF == P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class PZQaSXaJuGcObThKxpqqsLVjXpgbA : IEnumerable<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>, IEnumerable, IEnumerator<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>, IEnumerator, IDisposable
			{
				private int aBZumdfxZikrHJDDYKwcmXQLDTtq;

				private SpXgqgJYlBmyQBYVrDotvBmKhKWOA uDQbnnqDIchqiFFIpjQvoAEIWSKk;

				private int NRNAfXybMjQxQBiZblnoXcDWDutL;

				public kTViNRyPqOEdwHLqGSaZDuqfIuNC bizBkvBfBTtYSFdTZUIycvwVVoQQA;

				private SDUJIneDmUtGBcIuxagRJCnUDALIA gVTfDACoAhSbtctPaJbZIirbqUvXB;

				public SDUJIneDmUtGBcIuxagRJCnUDALIA MjaPUIFbkmTGRtbPxCVNNqLezCoT;

				private ZhmFDrxuGTFVyhBATMzaggkdSqDrB wMBYEvBYOKJBDtjRTAtDdVsLMwNDA;

				public ZhmFDrxuGTFVyhBATMzaggkdSqDrB aAqdcwFXgZkiFDBjaRBVqKASGkIyA;

				private int jeqGPfhYSvmsEWmKjFHTdjcuBCWV;

				private int EimrGjkdhYNvzuuXntntZGHQuloR;

				SpXgqgJYlBmyQBYVrDotvBmKhKWOA IEnumerator<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>.Current
				{
					[DebuggerHidden]
					get
					{
						return uDQbnnqDIchqiFFIpjQvoAEIWSKk;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return uDQbnnqDIchqiFFIpjQvoAEIWSKk;
					}
				}

				[DebuggerHidden]
				public PZQaSXaJuGcObThKxpqqsLVjXpgbA(int P_0)
				{
					aBZumdfxZikrHJDDYKwcmXQLDTtq = P_0;
					NRNAfXybMjQxQBiZblnoXcDWDutL = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = aBZumdfxZikrHJDDYKwcmXQLDTtq;
					kTViNRyPqOEdwHLqGSaZDuqfIuNC kTViNRyPqOEdwHLqGSaZDuqfIuNC2 = bizBkvBfBTtYSFdTZUIycvwVVoQQA;
					if (num != 0)
					{
						if (num != 1)
						{
							return false;
						}
						aBZumdfxZikrHJDDYKwcmXQLDTtq = -1;
						goto IL_0083;
					}
					aBZumdfxZikrHJDDYKwcmXQLDTtq = -1;
					jeqGPfhYSvmsEWmKjFHTdjcuBCWV = kTViNRyPqOEdwHLqGSaZDuqfIuNC2.mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count;
					EimrGjkdhYNvzuuXntntZGHQuloR = 0;
					goto IL_0093;
					IL_0083:
					EimrGjkdhYNvzuuXntntZGHQuloR++;
					goto IL_0093;
					IL_0093:
					if (EimrGjkdhYNvzuuXntntZGHQuloR < jeqGPfhYSvmsEWmKjFHTdjcuBCWV)
					{
						if (kTViNRyPqOEdwHLqGSaZDuqfIuNC2.mmlqEtaorvTeUnjFmOYDfYJEMfLK[EimrGjkdhYNvzuuXntntZGHQuloR].omOPWfIKRjGJINgXdCWWmTtVGwWbA(gVTfDACoAhSbtctPaJbZIirbqUvXB, wMBYEvBYOKJBDtjRTAtDdVsLMwNDA))
						{
							uDQbnnqDIchqiFFIpjQvoAEIWSKk = kTViNRyPqOEdwHLqGSaZDuqfIuNC2.mmlqEtaorvTeUnjFmOYDfYJEMfLK[EimrGjkdhYNvzuuXntntZGHQuloR];
							aBZumdfxZikrHJDDYKwcmXQLDTtq = 1;
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
				IEnumerator<SpXgqgJYlBmyQBYVrDotvBmKhKWOA> IEnumerable<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>.GetEnumerator()
				{
					PZQaSXaJuGcObThKxpqqsLVjXpgbA pZQaSXaJuGcObThKxpqqsLVjXpgbA;
					if (aBZumdfxZikrHJDDYKwcmXQLDTtq == -2 && NRNAfXybMjQxQBiZblnoXcDWDutL == Environment.CurrentManagedThreadId)
					{
						aBZumdfxZikrHJDDYKwcmXQLDTtq = 0;
						pZQaSXaJuGcObThKxpqqsLVjXpgbA = this;
					}
					else
					{
						pZQaSXaJuGcObThKxpqqsLVjXpgbA = new PZQaSXaJuGcObThKxpqqsLVjXpgbA(0);
						pZQaSXaJuGcObThKxpqqsLVjXpgbA.bizBkvBfBTtYSFdTZUIycvwVVoQQA = bizBkvBfBTtYSFdTZUIycvwVVoQQA;
					}
					pZQaSXaJuGcObThKxpqqsLVjXpgbA.gVTfDACoAhSbtctPaJbZIirbqUvXB = MjaPUIFbkmTGRtbPxCVNNqLezCoT;
					pZQaSXaJuGcObThKxpqqsLVjXpgbA.wMBYEvBYOKJBDtjRTAtDdVsLMwNDA = aAqdcwFXgZkiFDBjaRBVqKASGkIyA;
					return pZQaSXaJuGcObThKxpqqsLVjXpgbA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>)this).GetEnumerator();
				}
			}

			private List<SpXgqgJYlBmyQBYVrDotvBmKhKWOA> mmlqEtaorvTeUnjFmOYDfYJEMfLK;

			public int lSWHXClxYSRHbPeTAfTdyJeMPlIs => mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count;

			public kTViNRyPqOEdwHLqGSaZDuqfIuNC()
			{
				mmlqEtaorvTeUnjFmOYDfYJEMfLK = new List<SpXgqgJYlBmyQBYVrDotvBmKhKWOA>();
			}

			public void pkUsWggBKEJzykJCEdsUpXFTYMIh(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count;
				for (int i = 0; i < count; i++)
				{
					if (mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].omOPWfIKRjGJINgXdCWWmTtVGwWbA(P_0, ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Exact))
					{
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].wHvLVjoBAfrbNJuJaPvPdBxFMhjx = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].sAcyiZMIeWaPfhCrFgZXrJxTgAoD = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].yPexyQEYcfhECAxsQGiwfCfxSjMF = P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB;
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].RswnNdRTwFNAGDOpNUAipSDYiDHl = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].GaOafvbjhbuLucUlUXLIbbqlygmS = P_0.tsPMmRndnTFHHJeeWYdZAgVPUFSdA;
						mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].ZdNjvWcdKPPytUfAIiPPbJEfbVsxA = P_0.dvjiRdXbQeJzcGSBTQsHQwadOnkV;
						lNIasQneHAcfODRWfYTvbTIHyRII(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				mmlqEtaorvTeUnjFmOYDfYJEMfLK.Add(new SpXgqgJYlBmyQBYVrDotvBmKhKWOA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.fFqGTyCZUNihcOqDEnLSaIBdgpOmB, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.tsPMmRndnTFHHJeeWYdZAgVPUFSdA, P_0.dvjiRdXbQeJzcGSBTQsHQwadOnkV));
				lNIasQneHAcfODRWfYTvbTIHyRII(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count - 1);
			}

			public bool CWzyskpHaSCHJSZHxAsxuyHlkPCq(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, ZhmFDrxuGTFVyhBATMzaggkdSqDrB P_1)
			{
				int count = mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count;
				for (int i = 0; i < count; i++)
				{
					if (mmlqEtaorvTeUnjFmOYDfYJEMfLK[i].omOPWfIKRjGJINgXdCWWmTtVGwWbA(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(PZQaSXaJuGcObThKxpqqsLVjXpgbA))]
			public IEnumerable<SpXgqgJYlBmyQBYVrDotvBmKhKWOA> XDMZmpWrAXiwEHNYticDIgskCbJu(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, ZhmFDrxuGTFVyhBATMzaggkdSqDrB P_1)
			{
				return new PZQaSXaJuGcObThKxpqqsLVjXpgbA(-2)
				{
					bizBkvBfBTtYSFdTZUIycvwVVoQQA = this,
					MjaPUIFbkmTGRtbPxCVNNqLezCoT = P_0,
					aAqdcwFXgZkiFDBjaRBVqKASGkIyA = P_1
				};
			}

			public int qwRQTMjlyDkTgDLxQPgFAPeJdklb(SpXgqgJYlBmyQBYVrDotvBmKhKWOA P_0)
			{
				int count = mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count;
				for (int i = 0; i < count; i++)
				{
					if (mmlqEtaorvTeUnjFmOYDfYJEMfLK[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void lNIasQneHAcfODRWfYTvbTIHyRII(int P_0, int P_1)
			{
				for (int num = mmlqEtaorvTeUnjFmOYDfYJEMfLK.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && mmlqEtaorvTeUnjFmOYDfYJEMfLK[num].wHvLVjoBAfrbNJuJaPvPdBxFMhjx == P_0)
					{
						mmlqEtaorvTeUnjFmOYDfYJEMfLK.RemoveAt(num);
					}
				}
			}
		}

		private List<SDUJIneDmUtGBcIuxagRJCnUDALIA> MEKCRHbjnzabbFJvCqKDDrqDLUcte;

		private int BvmaLaaQPCFSgWVLtKiIURwVibGI;

		private kTViNRyPqOEdwHLqGSaZDuqfIuNC ybdXCigquSaALHiuKMElwRelgEAbb;

		private UpdateLoopType AwrJcKGCneEYjiXWfBljeeiqScLB;

		private Action<int, ControllerDataUpdater> mkdNubbQulhAQbhQNRLJGCbZimrD;

		private PlatformInputManager EutEqeIyujRIjGKGgQiPiYEgEGiM;

		private CustomInputSource UutnOVBjkIPvDtmmxfmHzdCqzDQI;

		private bool SDogwMafSjegfVmkUxxjtEBSRcYE;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> eVgXxgrYCeRQbSiUdbyeyCKHIquC;

		private Func<int> ykLsDKuOOLIJiqTLvLHhOAPFOizX;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => BvmaLaaQPCFSgWVLtKiIURwVibGI;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => EutEqeIyujRIjGKGgQiPiYEgEGiM;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => UutnOVBjkIPvDtmmxfmHzdCqzDQI.UBbrNuHNAOPoYVpJFeDjfSwRqCj;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			UutnOVBjkIPvDtmmxfmHzdCqzDQI = P_0;
			eVgXxgrYCeRQbSiUdbyeyCKHIquC = P_2;
			ykLsDKuOOLIJiqTLvLHhOAPFOizX = P_3;
			EutEqeIyujRIjGKGgQiPiYEgEGiM = this;
			try
			{
				mkdNubbQulhAQbhQNRLJGCbZimrD = UpdateControllerData;
				P_0.oNvoGGbDJblCgrLPUWfBTbwANtUU += SystemDeviceConnected;
				P_0.GiREvAnIBmXviKvGhMDyHyTjlBae += SystemDeviceDisconnected;
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
			ybdXCigquSaALHiuKMElwRelgEAbb = new kTViNRyPqOEdwHLqGSaZDuqfIuNC();
			MEKCRHbjnzabbFJvCqKDDrqDLUcte = new List<SDUJIneDmUtGBcIuxagRJCnUDALIA>();
			SDogwMafSjegfVmkUxxjtEBSRcYE = true;
			UutnOVBjkIPvDtmmxfmHzdCqzDQI.dipzRrboOzPXSHQrvmpVGGDsZefo();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			AwrJcKGCneEYjiXWfBljeeiqScLB = updateLoop;
			if (UutnOVBjkIPvDtmmxfmHzdCqzDQI.isReady)
			{
				UutnOVBjkIPvDtmmxfmHzdCqzDQI.Update();
				UutnOVBjkIPvDtmmxfmHzdCqzDQI.BEfVFJbaEZHDUohPIZLChbFkiDBZ();
				if (SDogwMafSjegfVmkUxxjtEBSRcYE)
				{
					TNLaJcCxICVnliphAcIHAeXuMLmAb();
				}
				wAChcPgBxELvVkNqBzVcKwuSLCeO();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (UutnOVBjkIPvDtmmxfmHzdCqzDQI != null)
			{
				UutnOVBjkIPvDtmmxfmHzdCqzDQI.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return mkdNubbQulhAQbhQNRLJGCbZimrD;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < BvmaLaaQPCFSgWVLtKiIURwVibGI; i++)
			{
				if (MEKCRHbjnzabbFJvCqKDDrqDLUcte[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					MEKCRHbjnzabbFJvCqKDDrqDLUcte[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			SDogwMafSjegfVmkUxxjtEBSRcYE = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			SDogwMafSjegfVmkUxxjtEBSRcYE = true;
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
			return UutnOVBjkIPvDtmmxfmHzdCqzDQI.pZdBVaUjniuFnvHCmEeeCzCqaLzbb();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return UutnOVBjkIPvDtmmxfmHzdCqzDQI.sMlcFzxGJhzRyPBLoqhjYWrIacIA();
		}

		private void pJtByIKhxfgRempKgjIjGbJgmrPRA(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<SDUJIneDmUtGBcIuxagRJCnUDALIA> mEKCRHbjnzabbFJvCqKDDrqDLUcte = MEKCRHbjnzabbFJvCqKDDrqDLUcte;
			int bvmaLaaQPCFSgWVLtKiIURwVibGI = BvmaLaaQPCFSgWVLtKiIURwVibGI;
			MEKCRHbjnzabbFJvCqKDDrqDLUcte = new List<SDUJIneDmUtGBcIuxagRJCnUDALIA>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					SDUJIneDmUtGBcIuxagRJCnUDALIA item = new SDUJIneDmUtGBcIuxagRJCnUDALIA(UutnOVBjkIPvDtmmxfmHzdCqzDQI, P_0[i].systemId, P_0[i].unityId, P_0[i], UutnOVBjkIPvDtmmxfmHzdCqzDQI.UBbrNuHNAOPoYVpJFeDjfSwRqCj, P_0[i].extension, eVgXxgrYCeRQbSiUdbyeyCKHIquC);
					MEKCRHbjnzabbFJvCqKDDrqDLUcte.Add(item);
					num++;
				}
			}
			BvmaLaaQPCFSgWVLtKiIURwVibGI = num;
			BRijpRnrpnDRLWObRAjEKRzXOgsCA(bvmaLaaQPCFSgWVLtKiIURwVibGI, num, mEKCRHbjnzabbFJvCqKDDrqDLUcte, MEKCRHbjnzabbFJvCqKDDrqDLUcte);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(MEKCRHbjnzabbFJvCqKDDrqDLUcte[j]));
				}
			}
			mUXQbSukDGaUdZPhBpbfAECnotwc(mEKCRHbjnzabbFJvCqKDDrqDLUcte, MEKCRHbjnzabbFJvCqKDDrqDLUcte, false);
			mUXQbSukDGaUdZPhBpbfAECnotwc(MEKCRHbjnzabbFJvCqKDDrqDLUcte, mEKCRHbjnzabbFJvCqKDDrqDLUcte, true);
		}

		private void wAChcPgBxELvVkNqBzVcKwuSLCeO()
		{
			for (int i = 0; i < BvmaLaaQPCFSgWVLtKiIURwVibGI; i++)
			{
				MEKCRHbjnzabbFJvCqKDDrqDLUcte[i].Update();
			}
		}

		private void BRijpRnrpnDRLWObRAjEKRzXOgsCA(int P_0, int P_1, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_2, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(SDUJIneDmUtGBcIuxagRJCnUDALIA.RzPqQkvrwWPFCeXeIDZxSafMrjQm);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				hRzILIYYoHNgNqIPlBUNXAUBVUcd(P_1, P_3, P_0, P_2, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Exact);
				if (UutnOVBjkIPvDtmmxfmHzdCqzDQI.useApproximateMatching)
				{
					hRzILIYYoHNgNqIPlBUNXAUBVUcd(P_1, P_3, P_0, P_2, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Approximate);
				}
			}
			IwcMwZBOnKMRxvAcobpVJlZgDbdTA(P_1, P_3, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Exact);
			if (UutnOVBjkIPvDtmmxfmHzdCqzDQI.useApproximateMatching)
			{
				IwcMwZBOnKMRxvAcobpVJlZgDbdTA(P_1, P_3, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA = P_3[i];
				if (sDUJIneDmUtGBcIuxagRJCnUDALIA != null && sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = FJbZtSPOoRLkXYMzBLAMVdGMKJrD(P_3);
					sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					ybdXCigquSaALHiuKMElwRelgEAbb.pkUsWggBKEJzykJCEdsUpXFTYMIh(sDUJIneDmUtGBcIuxagRJCnUDALIA);
				}
			}
			P_3.Sort(SDUJIneDmUtGBcIuxagRJCnUDALIA.pexXXEvFaKiNSkgLqoeRllzMzeri);
		}

		private void UulxdEPJHVAuWyttwAwbgLCAqIEZA(List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_0, int P_1, int P_2)
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

		private bool CzlyUxBbaOGDsdZUxvulQiYUBhLdb(List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_0, int P_1)
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

		private int FJbZtSPOoRLkXYMzBLAMVdGMKJrD(List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_0)
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

		private bool SRHmLWjSpArMrnfWeKZHmchzJgoM(List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_0, int P_1)
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

		private void hRzILIYYoHNgNqIPlBUNXAUBVUcd(int P_0, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_1, int P_2, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_3, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB P_4)
		{
			int num = ((P_4 != kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA = P_1[i];
				if (sDUJIneDmUtGBcIuxagRJCnUDALIA == null || sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA2 = P_3[j];
					if (sDUJIneDmUtGBcIuxagRJCnUDALIA2 != null && !SRHmLWjSpArMrnfWeKZHmchzJgoM(P_1, sDUJIneDmUtGBcIuxagRJCnUDALIA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && sDUJIneDmUtGBcIuxagRJCnUDALIA.BIRRJZmmVxKDwWJGvUeJNGBbYMtv(sDUJIneDmUtGBcIuxagRJCnUDALIA2) >= num)
					{
						sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = sDUJIneDmUtGBcIuxagRJCnUDALIA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = sDUJIneDmUtGBcIuxagRJCnUDALIA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						ybdXCigquSaALHiuKMElwRelgEAbb.pkUsWggBKEJzykJCEdsUpXFTYMIh(sDUJIneDmUtGBcIuxagRJCnUDALIA);
					}
				}
			}
		}

		private void IwcMwZBOnKMRxvAcobpVJlZgDbdTA(int P_0, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_1, kTViNRyPqOEdwHLqGSaZDuqfIuNC.ZhmFDrxuGTFVyhBATMzaggkdSqDrB P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA = P_1[i];
				if (sDUJIneDmUtGBcIuxagRJCnUDALIA == null || sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				kTViNRyPqOEdwHLqGSaZDuqfIuNC.SpXgqgJYlBmyQBYVrDotvBmKhKWOA spXgqgJYlBmyQBYVrDotvBmKhKWOA = null;
				foreach (kTViNRyPqOEdwHLqGSaZDuqfIuNC.SpXgqgJYlBmyQBYVrDotvBmKhKWOA item in ybdXCigquSaALHiuKMElwRelgEAbb.XDMZmpWrAXiwEHNYticDIgskCbJu(sDUJIneDmUtGBcIuxagRJCnUDALIA, P_2))
				{
					if (!SRHmLWjSpArMrnfWeKZHmchzJgoM(P_1, item.wHvLVjoBAfrbNJuJaPvPdBxFMhjx) && item.RswnNdRTwFNAGDOpNUAipSDYiDHl >= 0)
					{
						spXgqgJYlBmyQBYVrDotvBmKhKWOA = item;
						break;
					}
				}
				if (spXgqgJYlBmyQBYVrDotvBmKhKWOA != null)
				{
					int num = spXgqgJYlBmyQBYVrDotvBmKhKWOA.RswnNdRTwFNAGDOpNUAipSDYiDHl;
					if (!CzlyUxBbaOGDsdZUxvulQiYUBhLdb(P_1, num))
					{
						num = (spXgqgJYlBmyQBYVrDotvBmKhKWOA.RswnNdRTwFNAGDOpNUAipSDYiDHl = FJbZtSPOoRLkXYMzBLAMVdGMKJrD(P_1));
					}
					sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = spXgqgJYlBmyQBYVrDotvBmKhKWOA.wHvLVjoBAfrbNJuJaPvPdBxFMhjx;
					ybdXCigquSaALHiuKMElwRelgEAbb.pkUsWggBKEJzykJCEdsUpXFTYMIh(sDUJIneDmUtGBcIuxagRJCnUDALIA);
				}
			}
		}

		private void TNLaJcCxICVnliphAcIHAeXuMLmAb()
		{
			CustomInputSource.Joystick[] array = UutnOVBjkIPvDtmmxfmHzdCqzDQI.cRxAkxCSAWSjOHLBrFyedupAtzpIB();
			if (yVYpSjFBamcOlgfKRUqXHolzdJBlA(array))
			{
				pJtByIKhxfgRempKgjIjGbJgmrPRA(array);
			}
			SDogwMafSjegfVmkUxxjtEBSRcYE = false;
		}

		private bool yVYpSjFBamcOlgfKRUqXHolzdJBlA(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = MEKCRHbjnzabbFJvCqKDDrqDLUcte.Count;
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
					if (MEKCRHbjnzabbFJvCqKDDrqDLUcte[j] != null && systemId == MEKCRHbjnzabbFJvCqKDDrqDLUcte[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
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
				if (MEKCRHbjnzabbFJvCqKDDrqDLUcte[k] == null)
				{
					continue;
				}
				long? num2 = MEKCRHbjnzabbFJvCqKDDrqDLUcte[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
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

		private void mUXQbSukDGaUdZPhBpbfAECnotwc(List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_0, List<SDUJIneDmUtGBcIuxagRJCnUDALIA> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA = P_0[i];
				if (sDUJIneDmUtGBcIuxagRJCnUDALIA == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						SDUJIneDmUtGBcIuxagRJCnUDALIA sDUJIneDmUtGBcIuxagRJCnUDALIA2 = P_1[j];
						if (sDUJIneDmUtGBcIuxagRJCnUDALIA2 != null && sDUJIneDmUtGBcIuxagRJCnUDALIA.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == sDUJIneDmUtGBcIuxagRJCnUDALIA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					ZsmfykmoKxBIqVRDyaaECczVadny(P_0[i], P_2);
				}
			}
		}

		private void ZsmfykmoKxBIqVRDyaaECczVadny(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.UlFzCXbwSuwVGKylmtBptPHHFMaA();
			}
			boizaeYpGsGEYAKOKPLDKDyRVOKy(P_0, P_1);
		}

		private void boizaeYpGsGEYAKOKPLDKDyRVOKy(SDUJIneDmUtGBcIuxagRJCnUDALIA P_0, bool P_1)
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
