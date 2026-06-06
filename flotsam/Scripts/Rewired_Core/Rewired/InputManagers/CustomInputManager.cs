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
		private class hgeqALyhdKyGWBlzFAAwTtKoIKUG : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
		{
			private readonly InputSource FidAWfGQZxnQPlOBQpTctuVggxUK;

			private readonly CustomInputSource PvOcuYgBMEJCGUnmikUkGRXhZzCPA;

			private readonly Controller.Extension iPSAPwioiQtqhPSUKHGVOtqYzaIhA;

			private int YimgLnHhmmiEDFLhGPSCOLjUwOjJb;

			private int gydcGDCrUUwnQMiYVSoaAcFXmsbMA;

			private long? qYysgpKKUgAaqmaJhqCwfxQoNjhU;

			private int WUOWuNTUvuERePBFhdHzmGgXIzNp;

			public Guid ehKsubfiDIUfwwbPramvLmSwvqkM;

			public string HccfTdGxdXdlfxYeNTloXcXJUIHk;

			public string CSKDgSiZPXDodHXKuedjLEsEKnZtA;

			private int rpmvxwVWvgRlsMfpSBihZgTaMHZe;

			private int BaufrSehwPWBiWVqrkfxExVgIscvb;

			private float[] ljIYGQtFnTjxSyqFJFyPbCziJELW;

			private bool[] uOiCnzDGgCEouxBRmForCpvfOQFPA;

			private float[] ubTHjLcjtvAkgkSwqNoNZQdeXWYHA;

			private bool[] uqtsWnWmcoogcNChVaIhhADePZyyA;

			private HardwareJoystickMap_InputManager dVKEmNrgQsRQBImcZTYRfGpRXoDg;

			public CustomInputSource.Joystick TIyYHpnDDcfIDQFxlNtxUfJHNqiN;

			private bool CVoOSzblMZIJIdlWfHQbkdGibXHh;

			private readonly bool IsKuMPZNyPfQHsTDicyfxzUVNhNS;

			private readonly LocalizedString chcHLeQQmmeHxnjCwrYdpnjnqJCF;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> okzTGaRlozwqYoFUTzbnMuGfontJ;

			public int KCfTZdrFeVlYQPCbcMHkuGidqLLW
			{
				get
				{
					if (TIyYHpnDDcfIDQFxlNtxUfJHNqiN == null)
					{
						return 0;
					}
					return TIyYHpnDDcfIDQFxlNtxUfJHNqiN.buttonCount;
				}
			}

			public int QyPFIBDCRaAgldLStUWkGZVHbEvJ
			{
				get
				{
					if (TIyYHpnDDcfIDQFxlNtxUfJHNqiN == null)
					{
						return 0;
					}
					return TIyYHpnDDcfIDQFxlNtxUfJHNqiN.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.rewiredId
			{
				get
				{
					return YimgLnHhmmiEDFLhGPSCOLjUwOjJb;
				}
				set
				{
					YimgLnHhmmiEDFLhGPSCOLjUwOjJb = value;
				}
			}

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.inputManagerId
			{
				get
				{
					return gydcGDCrUUwnQMiYVSoaAcFXmsbMA;
				}
				set
				{
					gydcGDCrUUwnQMiYVSoaAcFXmsbMA = value;
				}
			}

			[CustomObfuscation(rename = false)]
			string IInputManagerJoystickPublic.name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(TIyYHpnDDcfIDQFxlNtxUfJHNqiN.customName)) ? TIyYHpnDDcfIDQFxlNtxUfJHNqiN.customName : HccfTdGxdXdlfxYeNTloXcXJUIHk);
					if (text == "Unknown Controller")
					{
						text = CSKDgSiZPXDodHXKuedjLEsEKnZtA;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			long? IInputManagerJoystickPublic.systemId => qYysgpKKUgAaqmaJhqCwfxQoNjhU;

			[CustomObfuscation(rename = false)]
			int IInputManagerJoystickPublic.unityId => WUOWuNTUvuERePBFhdHzmGgXIzNp;

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.instanceGuid
			{
				get
				{
					if (!qYysgpKKUgAaqmaJhqCwfxQoNjhU.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + qYysgpKKUgAaqmaJhqCwfxQoNjhU);
				}
			}

			[CustomObfuscation(rename = false)]
			Guid IInputManagerJoystickPublic.persistentGuid
			{
				get
				{
					if (!(TIyYHpnDDcfIDQFxlNtxUfJHNqiN.deviceInstanceGuid != Guid.Empty))
					{
						return Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					}
					return TIyYHpnDDcfIDQFxlNtxUfJHNqiN.deviceInstanceGuid;
				}
			}

			[CustomObfuscation(rename = false)]
			Controller.Extension IInputManagerJoystickPublic.extension => iPSAPwioiQtqhPSUKHGVOtqYzaIhA;

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

			public hgeqALyhdKyGWBlzFAAwTtKoIKUG(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				IsKuMPZNyPfQHsTDicyfxzUVNhNS = P_0.nmvMaliKWKVVtnEotrcihrnQRPHD == InputSource.PS4 || P_0.nmvMaliKWKVVtnEotrcihrnQRPHD == InputSource.PS5;
				chcHLeQQmmeHxnjCwrYdpnjnqJCF = new LocalizedString();
				PvOcuYgBMEJCGUnmikUkGRXhZzCPA = P_0;
				FidAWfGQZxnQPlOBQpTctuVggxUK = P_4;
				qYysgpKKUgAaqmaJhqCwfxQoNjhU = P_1;
				TIyYHpnDDcfIDQFxlNtxUfJHNqiN = P_3;
				WUOWuNTUvuERePBFhdHzmGgXIzNp = P_2;
				iPSAPwioiQtqhPSUKHGVOtqYzaIhA = P_5;
				okzTGaRlozwqYoFUTzbnMuGfontJ = P_6;
				gydcGDCrUUwnQMiYVSoaAcFXmsbMA = -1;
				YimgLnHhmmiEDFLhGPSCOLjUwOjJb = -1;
				jWBCsLxbeYvGMdvnRNVoniKnRHJD();
				MSzQKRLJdUYmifJyTstCiMLKbCcf();
				ehKsubfiDIUfwwbPramvLmSwvqkM = dVKEmNrgQsRQBImcZTYRfGpRXoDg.hardwareMapIdentifier.guid;
				HccfTdGxdXdlfxYeNTloXcXJUIHk = dVKEmNrgQsRQBImcZTYRfGpRXoDg.controllerName;
				ljIYGQtFnTjxSyqFJFyPbCziJELW = new float[rpmvxwVWvgRlsMfpSBihZgTaMHZe];
				uOiCnzDGgCEouxBRmForCpvfOQFPA = new bool[BaufrSehwPWBiWVqrkfxExVgIscvb];
				ubTHjLcjtvAkgkSwqNoNZQdeXWYHA = new float[BaufrSehwPWBiWVqrkfxExVgIscvb];
				uqtsWnWmcoogcNChVaIhhADePZyyA = new bool[BaufrSehwPWBiWVqrkfxExVgIscvb];
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)dVKEmNrgQsRQBImcZTYRfGpRXoDg.map).Buttons;
				if (buttons != null)
				{
					int num = MathTools.Min(buttons.Length, BaufrSehwPWBiWVqrkfxExVgIscvb);
					for (int i = 0; i < num; i++)
					{
						if (buttons[i] != null && buttons[i].buttonInfo != null)
						{
							uqtsWnWmcoogcNChVaIhhADePZyyA[i] = buttons[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				Update();
			}

			public void jWBCsLxbeYvGMdvnRNVoniKnRHJD()
			{
				CSKDgSiZPXDodHXKuedjLEsEKnZtA = TIyYHpnDDcfIDQFxlNtxUfJHNqiN.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (TIyYHpnDDcfIDQFxlNtxUfJHNqiN.isConnected)
				{
					kJpfjiXQKNMJggHJCAodFtKmbvzXA();
					rBtMJbNgIemadSpvagrvHgQnlRSWA();
				}
			}

			void IInputManagerJoystick.Update()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Update
				this.Update();
			}

			public int wLlOgvuZEzwUdfmDRGSgDTiVzEemA(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0)
			{
				if (P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA == CSKDgSiZPXDodHXKuedjLEsEKnZtA && P_0.qYysgpKKUgAaqmaJhqCwfxQoNjhU == qYysgpKKUgAaqmaJhqCwfxQoNjhU)
				{
					return 2;
				}
				if (P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA == CSKDgSiZPXDodHXKuedjLEsEKnZtA)
				{
					return 1;
				}
				return 0;
			}

			private void DsiROyvAbJTyXPixueltfSjYjeuj(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = FidAWfGQZxnQPlOBQpTctuVggxUK;
				P_0.inputSource = FidAWfGQZxnQPlOBQpTctuVggxUK;
				P_0.hardwareIdentifier = tHNEUjcZhVCQrrRTuLMVOZnDtGGk();
				P_0.hardwareAxisCount = rpmvxwVWvgRlsMfpSBihZgTaMHZe;
				P_0.hardwareButtonCount = BaufrSehwPWBiWVqrkfxExVgIscvb;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = CSKDgSiZPXDodHXKuedjLEsEKnZtA;
				P_0.hw_supportsVibration = TIyYHpnDDcfIDQFxlNtxUfJHNqiN.supportsVibration;
				P_0.userCustomIdentifier = TIyYHpnDDcfIDQFxlNtxUfJHNqiN.customIdentifier;
			}

			private void YJbsJgzSFZknJmZgQZYPQcuIfFtj(BridgedController P_0)
			{
				DsiROyvAbJTyXPixueltfSjYjeuj(P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = dVKEmNrgQsRQBImcZTYRfGpRXoDg.ToGameHardwareControllerMap();
				P_0.instanceName = CSKDgSiZPXDodHXKuedjLEsEKnZtA;
				P_0.productName = CSKDgSiZPXDodHXKuedjLEsEKnZtA;
				P_0.isXInputDevice = false;
				P_0.axisCount = rpmvxwVWvgRlsMfpSBihZgTaMHZe;
				P_0.buttonCount = BaufrSehwPWBiWVqrkfxExVgIscvb;
				P_0.controllerTypeGuid = ehKsubfiDIUfwwbPramvLmSwvqkM;
				P_0.customInputSource = PvOcuYgBMEJCGUnmikUkGRXhZzCPA;
				P_0.controllerExtension = iPSAPwioiQtqhPSUKHGVOtqYzaIhA;
				P_0.isButtonPressureSensitive = new bool[uqtsWnWmcoogcNChVaIhhADePZyyA.Length];
				for (int i = 0; i < uqtsWnWmcoogcNChVaIhhADePZyyA.Length; i++)
				{
					P_0.isButtonPressureSensitive[i] = uqtsWnWmcoogcNChVaIhhADePZyyA[i];
				}
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (rpmvxwVWvgRlsMfpSBihZgTaMHZe != dataUpdater.axisCount || BaufrSehwPWBiWVqrkfxExVgIscvb != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < rpmvxwVWvgRlsMfpSBihZgTaMHZe; i++)
				{
					dataUpdater.axisValues[i] = ljIYGQtFnTjxSyqFJFyPbCziJELW[i];
				}
				for (int j = 0; j < BaufrSehwPWBiWVqrkfxExVgIscvb; j++)
				{
					if (uqtsWnWmcoogcNChVaIhhADePZyyA[j])
					{
						dataUpdater.buttonPressureValues[j] = ubTHjLcjtvAkgkSwqNoNZQdeXWYHA[j];
					}
					dataUpdater.buttonValues[j] = uOiCnzDGgCEouxBRmForCpvfOQFPA[j];
				}
				if (CVoOSzblMZIJIdlWfHQbkdGibXHh && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
			{
				//ILSpy generated this explicit interface implementation from .override directive in FillData
				this.FillData(dataUpdater);
			}

			public BridgedControllerHWInfo SQrmvRXCJyFMXfKOVaqfooFosCvjb()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				DsiROyvAbJTyXPixueltfSjYjeuj(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				YJbsJgzSFZknJmZgQZYPQcuIfFtj(bridgedController);
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
				return new ControllerDisconnectedEventArgs(YimgLnHhmmiEDFLhGPSCOLjUwOjJb);
			}

			ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
				return this.ToControllerDisconnectedEventArgs();
			}

			private void kJpfjiXQKNMJggHJCAodFtKmbvzXA()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)dVKEmNrgQsRQBImcZTYRfGpRXoDg.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= rpmvxwVWvgRlsMfpSBihZgTaMHZe)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						ljIYGQtFnTjxSyqFJFyPbCziJELW[i] = aldftuUOrXJChKGpcnCtkDzvYnvg(axes[i]);
						if (!CVoOSzblMZIJIdlWfHQbkdGibXHh && ljIYGQtFnTjxSyqFJFyPbCziJELW[i] != 0f)
						{
							CVoOSzblMZIJIdlWfHQbkdGibXHh = true;
						}
					}
				}
			}

			private void rBtMJbNgIemadSpvagrvHgQnlRSWA()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)dVKEmNrgQsRQBImcZTYRfGpRXoDg.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= BaufrSehwPWBiWVqrkfxExVgIscvb)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					uOiCnzDGgCEouxBRmForCpvfOQFPA[i] = JnovCFyZLaZDoCRiUJBsmrNdiavH(buttons[i], out ubTHjLcjtvAkgkSwqNoNZQdeXWYHA[i]);
					if (!CVoOSzblMZIJIdlWfHQbkdGibXHh && (uOiCnzDGgCEouxBRmForCpvfOQFPA[i] || (uqtsWnWmcoogcNChVaIhhADePZyyA[i] && ubTHjLcjtvAkgkSwqNoNZQdeXWYHA[i] != 0f)))
					{
						CVoOSzblMZIJIdlWfHQbkdGibXHh = true;
					}
				}
			}

			private bool JnovCFyZLaZDoCRiUJBsmrNdiavH(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
			{
				if (P_0.sourceType == 0)
				{
					bool result = yamAlHAmezytSVIoJamVwSrBbfEP(P_0.sourceButton, out P_1);
					if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
					{
						P_1 = 0f;
					}
					return result;
				}
				if (P_0.sourceType == 1)
				{
					P_1 = 0f;
					float num = OWmBwLCvmOHpDhnyTqsbedAClvrTb(P_0.sourceAxis);
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

			private bool FmrWCZCxHqiQZIewNIyipciyQHRg(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float aldftuUOrXJChKGpcnCtkDzvYnvg(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return OWmBwLCvmOHpDhnyTqsbedAClvrTb(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!yamAlHAmezytSVIoJamVwSrBbfEP(P_0.sourceButton, out var _))
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

			private float OWmBwLCvmOHpDhnyTqsbedAClvrTb(int P_0)
			{
				return TIyYHpnDDcfIDQFxlNtxUfJHNqiN.GetAxisValue(P_0);
			}

			private bool yamAlHAmezytSVIoJamVwSrBbfEP(int P_0, out float P_1)
			{
				TIyYHpnDDcfIDQFxlNtxUfJHNqiN.mKDxRauoOORzvBksDhPUkTlHftIJ(P_0, out var result, out P_1);
				return result;
			}

			private void MSzQKRLJdUYmifJyTstCiMLKbCcf()
			{
				dVKEmNrgQsRQBImcZTYRfGpRXoDg = okzTGaRlozwqYoFUTzbnMuGfontJ(SQrmvRXCJyFMXfKOVaqfooFosCvjb());
				if (dVKEmNrgQsRQBImcZTYRfGpRXoDg == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				if (TIyYHpnDDcfIDQFxlNtxUfJHNqiN is IInputManagerHardwareJoystickMapHandler)
				{
					try
					{
						((IInputManagerHardwareJoystickMapHandler)TIyYHpnDDcfIDQFxlNtxUfJHNqiN).InitializeHardwareJoystickMap(dVKEmNrgQsRQBImcZTYRfGpRXoDg);
					}
					catch
					{
					}
				}
				rpmvxwVWvgRlsMfpSBihZgTaMHZe = dVKEmNrgQsRQBImcZTYRfGpRXoDg.axisCount;
				BaufrSehwPWBiWVqrkfxExVgIscvb = dVKEmNrgQsRQBImcZTYRfGpRXoDg.buttonCount;
			}

			private void cottUuDwVcpgNOHGsfHjkFMaouWI()
			{
				Array.Clear(uOiCnzDGgCEouxBRmForCpvfOQFPA, 0, uOiCnzDGgCEouxBRmForCpvfOQFPA.Length);
				Array.Clear(ubTHjLcjtvAkgkSwqNoNZQdeXWYHA, 0, ubTHjLcjtvAkgkSwqNoNZQdeXWYHA.Length);
				Array.Clear(ljIYGQtFnTjxSyqFJFyPbCziJELW, 0, ljIYGQtFnTjxSyqFJFyPbCziJELW.Length);
			}

			private string tHNEUjcZhVCQrrRTuLMVOZnDtGGk()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{FidAWfGQZxnQPlOBQpTctuVggxUK.ToString()}{CSKDgSiZPXDodHXKuedjLEsEKnZtA}");
				}
				if (gxyUNwMTjDnpgmNcTiXKrGmaVQZM.FWiaKwjEYfoyrcIdbeowyEloYCbFb)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{gxyUNwMTjDnpgmNcTiXKrGmaVQZM.YQaxbzZPfzhiJHjkDMPSupdMvcNu()}{CSKDgSiZPXDodHXKuedjLEsEKnZtA}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{FidAWfGQZxnQPlOBQpTctuVggxUK.ToString()}{CSKDgSiZPXDodHXKuedjLEsEKnZtA}");
			}

			bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
			{
				if (!(TIyYHpnDDcfIDQFxlNtxUfJHNqiN is ITryGetLocalizedName))
				{
					if (IsKuMPZNyPfQHsTDicyfxzUVNhNS)
					{
						if ((LocalizationManager.GetAndUpdateLocalizedString(chcHLeQQmmeHxnjCwrYdpnjnqJCF, dVKEmNrgQsRQBImcZTYRfGpRXoDg.deviceLocalizationInfo.parentKeys, "controller", Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
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
							chcHLeQQmmeHxnjCwrYdpnjnqJCF.cachedValue = value;
						}
						return true;
					}
					value = null;
					return false;
				}
				return ((ITryGetLocalizedName)TIyYHpnDDcfIDQFxlNtxUfJHNqiN).TryGetLocalizedName(out value);
			}

			public static int SRLesevobWzoBBYIUUJozOSchaiG(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, hgeqALyhdKyGWBlzFAAwTtKoIKUG P_1)
			{
				if (P_0.gydcGDCrUUwnQMiYVSoaAcFXmsbMA < P_1.gydcGDCrUUwnQMiYVSoaAcFXmsbMA)
				{
					return -1;
				}
				if (P_0.gydcGDCrUUwnQMiYVSoaAcFXmsbMA > P_1.gydcGDCrUUwnQMiYVSoaAcFXmsbMA)
				{
					return 1;
				}
				return 0;
			}

			public static int gvxLtKfGzIpWFLcjwzpUOoOiInNV(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, hgeqALyhdKyGWBlzFAAwTtKoIKUG P_1)
			{
				if (P_0.qYysgpKKUgAaqmaJhqCwfxQoNjhU < P_1.qYysgpKKUgAaqmaJhqCwfxQoNjhU)
				{
					return -1;
				}
				if (P_0.qYysgpKKUgAaqmaJhqCwfxQoNjhU > P_1.qYysgpKKUgAaqmaJhqCwfxQoNjhU)
				{
					return 1;
				}
				return 0;
			}
		}

		private class LvnBLheGuEZHjkIMectoXdXBGAIt
		{
			public enum iQGCcHJhRZmClBgRhERRrcDqKaCQA
			{
				Exact = 0,
				Approximate = 1
			}

			public class fpfcRQKUkTDfVJtWPlCGfNVckKBUb
			{
				public int XtJqiNmBXhCsMAcQKgPsmzYjbhkpA;

				public long? TqKXMxImfUzgoAgDtFImxWufkihs;

				public string HGYYZkIsjvUmTlKboFqNfNKTEEBq;

				public int weEWtVTPlVWCPueclkwDlEsgkVGK;

				public int tVytUVbhknnSdJneaRvdfnHPGylGA;

				public int mPpbIqHvTLIlqRhXinbaXPzLgRxRA;

				public fpfcRQKUkTDfVJtWPlCGfNVckKBUb(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					XtJqiNmBXhCsMAcQKgPsmzYjbhkpA = P_0;
					TqKXMxImfUzgoAgDtFImxWufkihs = P_1;
					HGYYZkIsjvUmTlKboFqNfNKTEEBq = P_2;
					weEWtVTPlVWCPueclkwDlEsgkVGK = P_3;
					tVytUVbhknnSdJneaRvdfnHPGylGA = P_4;
					mPpbIqHvTLIlqRhXinbaXPzLgRxRA = P_5;
				}

				public bool PIiRhFAjCfZYTeeQHWihqLMvosBw(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, iQGCcHJhRZmClBgRhERRrcDqKaCQA P_1)
				{
					if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == XtJqiNmBXhCsMAcQKgPsmzYjbhkpA)
					{
						return true;
					}
					if (P_0.KCfTZdrFeVlYQPCbcMHkuGidqLLW != tVytUVbhknnSdJneaRvdfnHPGylGA)
					{
						return false;
					}
					if (P_0.QyPFIBDCRaAgldLStUWkGZVHbEvJ != mPpbIqHvTLIlqRhXinbaXPzLgRxRA)
					{
						return false;
					}
					switch (P_1)
					{
					case iQGCcHJhRZmClBgRhERRrcDqKaCQA.Exact:
						if (TqKXMxImfUzgoAgDtFImxWufkihs == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
						{
							return HGYYZkIsjvUmTlKboFqNfNKTEEBq == P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA;
						}
						return false;
					case iQGCcHJhRZmClBgRhERRrcDqKaCQA.Approximate:
						return HGYYZkIsjvUmTlKboFqNfNKTEEBq == P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class gzkctrJBrQJDobIRkNCDODyfBhlHB : IEnumerable<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>, IEnumerable, IEnumerator<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>, IEnumerator, IDisposable
			{
				private int HObMZPjZAyiaUggCyBSRctfjYPmx;

				private fpfcRQKUkTDfVJtWPlCGfNVckKBUb FgoAzNwXxayqxgRgPBVWyrxiWePE;

				private int abfaSngpPfPoPieMJAZBHReyqTcgA;

				public LvnBLheGuEZHjkIMectoXdXBGAIt QVNgJBEtITlRRlGYlvwXJpDrowXYA;

				private hgeqALyhdKyGWBlzFAAwTtKoIKUG RIpZsquORvnieWXQOnFiyCMQCWkHA;

				public hgeqALyhdKyGWBlzFAAwTtKoIKUG xgWyqiNhNmGrOOYuPjMyTaDAOZfE;

				private iQGCcHJhRZmClBgRhERRrcDqKaCQA XkjutVZjNUlQCOcYrmTkHrHxkwIo;

				public iQGCcHJhRZmClBgRhERRrcDqKaCQA VyMCBWHHbRgzUWucCmxkXYtmAiVDb;

				private int CvIgaPdlDjvdBlbZHfpkbrFIqWTvA;

				private int xhWpvPaouKrgiNeMJrXMRTymLvfO;

				fpfcRQKUkTDfVJtWPlCGfNVckKBUb IEnumerator<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>.Current
				{
					[DebuggerHidden]
					get
					{
						return FgoAzNwXxayqxgRgPBVWyrxiWePE;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return FgoAzNwXxayqxgRgPBVWyrxiWePE;
					}
				}

				[DebuggerHidden]
				public gzkctrJBrQJDobIRkNCDODyfBhlHB(int P_0)
				{
					HObMZPjZAyiaUggCyBSRctfjYPmx = P_0;
					abfaSngpPfPoPieMJAZBHReyqTcgA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
					HObMZPjZAyiaUggCyBSRctfjYPmx = -2;
				}

				private bool MoveNext()
				{
					int hObMZPjZAyiaUggCyBSRctfjYPmx = HObMZPjZAyiaUggCyBSRctfjYPmx;
					LvnBLheGuEZHjkIMectoXdXBGAIt qVNgJBEtITlRRlGYlvwXJpDrowXYA = QVNgJBEtITlRRlGYlvwXJpDrowXYA;
					if (hObMZPjZAyiaUggCyBSRctfjYPmx != 0)
					{
						if (hObMZPjZAyiaUggCyBSRctfjYPmx != 1)
						{
							return false;
						}
						HObMZPjZAyiaUggCyBSRctfjYPmx = -1;
						goto IL_0083;
					}
					HObMZPjZAyiaUggCyBSRctfjYPmx = -1;
					CvIgaPdlDjvdBlbZHfpkbrFIqWTvA = qVNgJBEtITlRRlGYlvwXJpDrowXYA.FJTLdJqBexxtJSNAKyicfXyqAXKl.Count;
					xhWpvPaouKrgiNeMJrXMRTymLvfO = 0;
					goto IL_0093;
					IL_0083:
					xhWpvPaouKrgiNeMJrXMRTymLvfO++;
					goto IL_0093;
					IL_0093:
					if (xhWpvPaouKrgiNeMJrXMRTymLvfO < CvIgaPdlDjvdBlbZHfpkbrFIqWTvA)
					{
						if (qVNgJBEtITlRRlGYlvwXJpDrowXYA.FJTLdJqBexxtJSNAKyicfXyqAXKl[xhWpvPaouKrgiNeMJrXMRTymLvfO].PIiRhFAjCfZYTeeQHWihqLMvosBw(RIpZsquORvnieWXQOnFiyCMQCWkHA, XkjutVZjNUlQCOcYrmTkHrHxkwIo))
						{
							FgoAzNwXxayqxgRgPBVWyrxiWePE = qVNgJBEtITlRRlGYlvwXJpDrowXYA.FJTLdJqBexxtJSNAKyicfXyqAXKl[xhWpvPaouKrgiNeMJrXMRTymLvfO];
							HObMZPjZAyiaUggCyBSRctfjYPmx = 1;
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
				IEnumerator<fpfcRQKUkTDfVJtWPlCGfNVckKBUb> IEnumerable<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>.GetEnumerator()
				{
					gzkctrJBrQJDobIRkNCDODyfBhlHB gzkctrJBrQJDobIRkNCDODyfBhlHB2;
					if (HObMZPjZAyiaUggCyBSRctfjYPmx == -2 && abfaSngpPfPoPieMJAZBHReyqTcgA == Environment.CurrentManagedThreadId)
					{
						HObMZPjZAyiaUggCyBSRctfjYPmx = 0;
						gzkctrJBrQJDobIRkNCDODyfBhlHB2 = this;
					}
					else
					{
						gzkctrJBrQJDobIRkNCDODyfBhlHB2 = new gzkctrJBrQJDobIRkNCDODyfBhlHB(0);
						gzkctrJBrQJDobIRkNCDODyfBhlHB2.QVNgJBEtITlRRlGYlvwXJpDrowXYA = QVNgJBEtITlRRlGYlvwXJpDrowXYA;
					}
					gzkctrJBrQJDobIRkNCDODyfBhlHB2.RIpZsquORvnieWXQOnFiyCMQCWkHA = xgWyqiNhNmGrOOYuPjMyTaDAOZfE;
					gzkctrJBrQJDobIRkNCDODyfBhlHB2.XkjutVZjNUlQCOcYrmTkHrHxkwIo = VyMCBWHHbRgzUWucCmxkXYtmAiVDb;
					return gzkctrJBrQJDobIRkNCDODyfBhlHB2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>)this).GetEnumerator();
				}
			}

			private List<fpfcRQKUkTDfVJtWPlCGfNVckKBUb> FJTLdJqBexxtJSNAKyicfXyqAXKl;

			public int KcshkghUXKUGkwmQkFbSImFgQrJMA => FJTLdJqBexxtJSNAKyicfXyqAXKl.Count;

			public LvnBLheGuEZHjkIMectoXdXBGAIt()
			{
				FJTLdJqBexxtJSNAKyicfXyqAXKl = new List<fpfcRQKUkTDfVJtWPlCGfNVckKBUb>();
			}

			public void SLmPTCwrXCIGvZsLwRHtxKmzYrZH(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = FJTLdJqBexxtJSNAKyicfXyqAXKl.Count;
				for (int i = 0; i < count; i++)
				{
					if (FJTLdJqBexxtJSNAKyicfXyqAXKl[i].PIiRhFAjCfZYTeeQHWihqLMvosBw(P_0, iQGCcHJhRZmClBgRhERRrcDqKaCQA.Exact))
					{
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].XtJqiNmBXhCsMAcQKgPsmzYjbhkpA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].TqKXMxImfUzgoAgDtFImxWufkihs = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].HGYYZkIsjvUmTlKboFqNfNKTEEBq = P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA;
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].weEWtVTPlVWCPueclkwDlEsgkVGK = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].tVytUVbhknnSdJneaRvdfnHPGylGA = P_0.KCfTZdrFeVlYQPCbcMHkuGidqLLW;
						FJTLdJqBexxtJSNAKyicfXyqAXKl[i].mPpbIqHvTLIlqRhXinbaXPzLgRxRA = P_0.QyPFIBDCRaAgldLStUWkGZVHbEvJ;
						ECiVranOdUnvJeLXLuGXbdcdsBNd(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
						return;
					}
				}
				FJTLdJqBexxtJSNAKyicfXyqAXKl.Add(new fpfcRQKUkTDfVJtWPlCGfNVckKBUb(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId, P_0.CSKDgSiZPXDodHXKuedjLEsEKnZtA, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.KCfTZdrFeVlYQPCbcMHkuGidqLLW, P_0.QyPFIBDCRaAgldLStUWkGZVHbEvJ));
				ECiVranOdUnvJeLXLuGXbdcdsBNd(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, FJTLdJqBexxtJSNAKyicfXyqAXKl.Count - 1);
			}

			public bool lwFVjMjGlCIUYvxGHNIUymyDBTXW(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, iQGCcHJhRZmClBgRhERRrcDqKaCQA P_1)
			{
				int count = FJTLdJqBexxtJSNAKyicfXyqAXKl.Count;
				for (int i = 0; i < count; i++)
				{
					if (FJTLdJqBexxtJSNAKyicfXyqAXKl[i].PIiRhFAjCfZYTeeQHWihqLMvosBw(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			[IteratorStateMachine(typeof(gzkctrJBrQJDobIRkNCDODyfBhlHB))]
			public IEnumerable<fpfcRQKUkTDfVJtWPlCGfNVckKBUb> ksiqiXUqDJfSPirPRKGiOTLEvGCm(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, iQGCcHJhRZmClBgRhERRrcDqKaCQA P_1)
			{
				return new gzkctrJBrQJDobIRkNCDODyfBhlHB(-2)
				{
					QVNgJBEtITlRRlGYlvwXJpDrowXYA = this,
					xgWyqiNhNmGrOOYuPjMyTaDAOZfE = P_0,
					VyMCBWHHbRgzUWucCmxkXYtmAiVDb = P_1
				};
			}

			public int XtMxitfoGuxaYeCMLzeREosfhbbl(fpfcRQKUkTDfVJtWPlCGfNVckKBUb P_0)
			{
				int count = FJTLdJqBexxtJSNAKyicfXyqAXKl.Count;
				for (int i = 0; i < count; i++)
				{
					if (FJTLdJqBexxtJSNAKyicfXyqAXKl[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void ECiVranOdUnvJeLXLuGXbdcdsBNd(int P_0, int P_1)
			{
				for (int num = FJTLdJqBexxtJSNAKyicfXyqAXKl.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && FJTLdJqBexxtJSNAKyicfXyqAXKl[num].XtJqiNmBXhCsMAcQKgPsmzYjbhkpA == P_0)
					{
						FJTLdJqBexxtJSNAKyicfXyqAXKl.RemoveAt(num);
					}
				}
			}
		}

		private List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> jusdodevutNmuiXcYhuqfbDbWMelA;

		private int qWKLxEidQUCXvtACPwmlWeLvImDs;

		private LvnBLheGuEZHjkIMectoXdXBGAIt RANVdYkRnSiTQPonemUSDEBJeGDx;

		private UpdateLoopType jlEujSIFYvXoJREXuzrAeZmWSWle;

		private Action<int, ControllerDataUpdater> TkDgTXpNxbaFNYbsphrcQCvbyPmi;

		private PlatformInputManager bUXkHSOmjlbPwfnXUgWeaJjWjMriA;

		private CustomInputSource xxDUGtBMxASCQSshPVbanplYhWBi;

		private bool nQGRRscouvdwaydHwVGMhxaeDzZe;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PXEyGOpXDiWHsnGtVKLBePbfDQhT;

		private Func<int> ZJfpckunLTYObLhABDdUEwubhgecA;

		[CustomObfuscation(rename = false)]
		int PlatformInputManager.deviceCount => qWKLxEidQUCXvtACPwmlWeLvImDs;

		[CustomObfuscation(rename = false)]
		PlatformInputManager PlatformInputManager.primaryInputManager => bUXkHSOmjlbPwfnXUgWeaJjWjMriA;

		[CustomObfuscation(rename = false)]
		IInputSource PlatformInputManager.inputSource => null;

		[CustomObfuscation(rename = false)]
		InputSource PlatformInputManager.inputSourceType => xxDUGtBMxASCQSshPVbanplYhWBi.nmvMaliKWKVVtnEotrcihrnQRPHD;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			xxDUGtBMxASCQSshPVbanplYhWBi = P_0;
			PXEyGOpXDiWHsnGtVKLBePbfDQhT = P_2;
			ZJfpckunLTYObLhABDdUEwubhgecA = P_3;
			bUXkHSOmjlbPwfnXUgWeaJjWjMriA = this;
			try
			{
				TkDgTXpNxbaFNYbsphrcQCvbyPmi = UpdateControllerData;
				P_0.NBPqvcntSfuVxALUiCBwFVDuixLCA += SystemDeviceConnected;
				P_0.bPSrLptPisUqejgpVgLlRDuVzzCc += SystemDeviceDisconnected;
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
			RANVdYkRnSiTQPonemUSDEBJeGDx = new LvnBLheGuEZHjkIMectoXdXBGAIt();
			jusdodevutNmuiXcYhuqfbDbWMelA = new List<hgeqALyhdKyGWBlzFAAwTtKoIKUG>();
			nQGRRscouvdwaydHwVGMhxaeDzZe = true;
			xxDUGtBMxASCQSshPVbanplYhWBi.AjJwsLldBlpITmjcHENsWTmMTamU();
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			jlEujSIFYvXoJREXuzrAeZmWSWle = updateLoop;
			if (xxDUGtBMxASCQSshPVbanplYhWBi.isReady)
			{
				xxDUGtBMxASCQSshPVbanplYhWBi.Update();
				xxDUGtBMxASCQSshPVbanplYhWBi.ugDiQtlpJXWlRXrEwhijlruENhKI();
				if (nQGRRscouvdwaydHwVGMhxaeDzZe)
				{
					aDnduOKZBMduuPVasurwqGuAbRxX();
				}
				VYugNreNeWjaEEFpfzjZDQDmRYvqA();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (xxDUGtBMxASCQSshPVbanplYhWBi != null)
			{
				xxDUGtBMxASCQSshPVbanplYhWBi.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return TkDgTXpNxbaFNYbsphrcQCvbyPmi;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < qWKLxEidQUCXvtACPwmlWeLvImDs; i++)
			{
				if (jusdodevutNmuiXcYhuqfbDbWMelA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					jusdodevutNmuiXcYhuqfbDbWMelA[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			nQGRRscouvdwaydHwVGMhxaeDzZe = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			nQGRRscouvdwaydHwVGMhxaeDzZe = true;
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
			return xxDUGtBMxASCQSshPVbanplYhWBi.OnPuJOAXguOMgIKLSOoPvezSBQuK();
		}

		[CustomObfuscation(rename = false)]
		public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
		{
			return xxDUGtBMxASCQSshPVbanplYhWBi.VZDDvpxLFXkIreYsfAIRCvBwyrBb();
		}

		private void EJTRgkAgwxSMbVzHOuWGlokUtEGk(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> list = jusdodevutNmuiXcYhuqfbDbWMelA;
			int num2 = qWKLxEidQUCXvtACPwmlWeLvImDs;
			jusdodevutNmuiXcYhuqfbDbWMelA = new List<hgeqALyhdKyGWBlzFAAwTtKoIKUG>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					hgeqALyhdKyGWBlzFAAwTtKoIKUG item = new hgeqALyhdKyGWBlzFAAwTtKoIKUG(xxDUGtBMxASCQSshPVbanplYhWBi, P_0[i].systemId, P_0[i].unityId, P_0[i], xxDUGtBMxASCQSshPVbanplYhWBi.nmvMaliKWKVVtnEotrcihrnQRPHD, P_0[i].extension, PXEyGOpXDiWHsnGtVKLBePbfDQhT);
					jusdodevutNmuiXcYhuqfbDbWMelA.Add(item);
					num++;
				}
			}
			qWKLxEidQUCXvtACPwmlWeLvImDs = num;
			udIDOrzPmpbEIDrybTXvRNIplgbJA(num2, num, list, jusdodevutNmuiXcYhuqfbDbWMelA);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(jusdodevutNmuiXcYhuqfbDbWMelA[j]));
				}
			}
			BuodVJshdRhDGcAPdXYwCjCDmedc(list, jusdodevutNmuiXcYhuqfbDbWMelA, false);
			BuodVJshdRhDGcAPdXYwCjCDmedc(jusdodevutNmuiXcYhuqfbDbWMelA, list, true);
		}

		private void VYugNreNeWjaEEFpfzjZDQDmRYvqA()
		{
			for (int i = 0; i < qWKLxEidQUCXvtACPwmlWeLvImDs; i++)
			{
				jusdodevutNmuiXcYhuqfbDbWMelA[i].Update();
			}
		}

		private void udIDOrzPmpbEIDrybTXvRNIplgbJA(int P_0, int P_1, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_2, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(hgeqALyhdKyGWBlzFAAwTtKoIKUG.gvxLtKfGzIpWFLcjwzpUOoOiInNV);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				MRZbNoEFvTKwSZJWNnCiRpynXOlE(P_1, P_3, P_0, P_2, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA.Exact);
				if (xxDUGtBMxASCQSshPVbanplYhWBi.useApproximateMatching)
				{
					MRZbNoEFvTKwSZJWNnCiRpynXOlE(P_1, P_3, P_0, P_2, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA.Approximate);
				}
			}
			vYGsJdTAmSUKqWyfSVUspdyMCbgn(P_1, P_3, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA.Exact);
			if (xxDUGtBMxASCQSshPVbanplYhWBi.useApproximateMatching)
			{
				vYGsJdTAmSUKqWyfSVUspdyMCbgn(P_1, P_3, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG2 = P_3[i];
				if (hgeqALyhdKyGWBlzFAAwTtKoIKUG2 != null && hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
				{
					hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = alFaviBbDNKdxxMPrvkpJPEuMYoF(P_3);
					hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
					RANVdYkRnSiTQPonemUSDEBJeGDx.SLmPTCwrXCIGvZsLwRHtxKmzYrZH(hgeqALyhdKyGWBlzFAAwTtKoIKUG2);
				}
			}
			P_3.Sort(hgeqALyhdKyGWBlzFAAwTtKoIKUG.SRLesevobWzoBBYIUUJozOSchaiG);
		}

		private void fDDWCeFNIBFpDJbqMyWQLHhcoQDR(List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_0, int P_1, int P_2)
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

		private bool dXHSlFZOhQeWlevDPmAWeirwArUaA(List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_0, int P_1)
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

		private int alFaviBbDNKdxxMPrvkpJPEuMYoF(List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_0)
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

		private bool ldtSwixXcAdFoWENKahwcwSNmmliA(List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_0, int P_1)
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

		private void MRZbNoEFvTKwSZJWNnCiRpynXOlE(int P_0, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_1, int P_2, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_3, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA P_4)
		{
			int num = ((P_4 != LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG2 = P_1[i];
				if (hgeqALyhdKyGWBlzFAAwTtKoIKUG2 == null || hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG3 = P_3[j];
					if (hgeqALyhdKyGWBlzFAAwTtKoIKUG3 != null && !ldtSwixXcAdFoWENKahwcwSNmmliA(P_1, hgeqALyhdKyGWBlzFAAwTtKoIKUG3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && hgeqALyhdKyGWBlzFAAwTtKoIKUG2.wLlOgvuZEzwUdfmDRGSgDTiVzEemA(hgeqALyhdKyGWBlzFAAwTtKoIKUG3) >= num)
					{
						hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = hgeqALyhdKyGWBlzFAAwTtKoIKUG3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
						hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = hgeqALyhdKyGWBlzFAAwTtKoIKUG3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
						RANVdYkRnSiTQPonemUSDEBJeGDx.SLmPTCwrXCIGvZsLwRHtxKmzYrZH(hgeqALyhdKyGWBlzFAAwTtKoIKUG2);
					}
				}
			}
		}

		private void vYGsJdTAmSUKqWyfSVUspdyMCbgn(int P_0, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_1, LvnBLheGuEZHjkIMectoXdXBGAIt.iQGCcHJhRZmClBgRhERRrcDqKaCQA P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG2 = P_1[i];
				if (hgeqALyhdKyGWBlzFAAwTtKoIKUG2 == null || hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
				{
					continue;
				}
				LvnBLheGuEZHjkIMectoXdXBGAIt.fpfcRQKUkTDfVJtWPlCGfNVckKBUb fpfcRQKUkTDfVJtWPlCGfNVckKBUb = null;
				foreach (LvnBLheGuEZHjkIMectoXdXBGAIt.fpfcRQKUkTDfVJtWPlCGfNVckKBUb item in RANVdYkRnSiTQPonemUSDEBJeGDx.ksiqiXUqDJfSPirPRKGiOTLEvGCm(hgeqALyhdKyGWBlzFAAwTtKoIKUG2, P_2))
				{
					if (!ldtSwixXcAdFoWENKahwcwSNmmliA(P_1, item.XtJqiNmBXhCsMAcQKgPsmzYjbhkpA) && item.weEWtVTPlVWCPueclkwDlEsgkVGK >= 0)
					{
						fpfcRQKUkTDfVJtWPlCGfNVckKBUb = item;
						break;
					}
				}
				if (fpfcRQKUkTDfVJtWPlCGfNVckKBUb != null)
				{
					int num = fpfcRQKUkTDfVJtWPlCGfNVckKBUb.weEWtVTPlVWCPueclkwDlEsgkVGK;
					if (!dXHSlFZOhQeWlevDPmAWeirwArUaA(P_1, num))
					{
						num = (fpfcRQKUkTDfVJtWPlCGfNVckKBUb.weEWtVTPlVWCPueclkwDlEsgkVGK = alFaviBbDNKdxxMPrvkpJPEuMYoF(P_1));
					}
					hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
					hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = fpfcRQKUkTDfVJtWPlCGfNVckKBUb.XtJqiNmBXhCsMAcQKgPsmzYjbhkpA;
					RANVdYkRnSiTQPonemUSDEBJeGDx.SLmPTCwrXCIGvZsLwRHtxKmzYrZH(hgeqALyhdKyGWBlzFAAwTtKoIKUG2);
				}
			}
		}

		private void aDnduOKZBMduuPVasurwqGuAbRxX()
		{
			CustomInputSource.Joystick[] array = xxDUGtBMxASCQSshPVbanplYhWBi.JBZIJTFKHSXwTLqWFPEZjcQLmfuJA();
			if (VfuOjXHPdoHLmMEXdrQeeQAVOJQV(array))
			{
				EJTRgkAgwxSMbVzHOuWGlokUtEGk(array);
			}
			nQGRRscouvdwaydHwVGMhxaeDzZe = false;
		}

		private bool VfuOjXHPdoHLmMEXdrQeeQAVOJQV(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = jusdodevutNmuiXcYhuqfbDbWMelA.Count;
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
					if (jusdodevutNmuiXcYhuqfbDbWMelA[j] != null && systemId == jusdodevutNmuiXcYhuqfbDbWMelA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId)
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
				if (jusdodevutNmuiXcYhuqfbDbWMelA[k] == null)
				{
					continue;
				}
				long? num2 = jusdodevutNmuiXcYhuqfbDbWMelA[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EsystemId;
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

		private void BuodVJshdRhDGcAPdXYwCjCDmedc(List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_0, List<hgeqALyhdKyGWBlzFAAwTtKoIKUG> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG2 = P_0[i];
				if (hgeqALyhdKyGWBlzFAAwTtKoIKUG2 == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						hgeqALyhdKyGWBlzFAAwTtKoIKUG hgeqALyhdKyGWBlzFAAwTtKoIKUG3 = P_1[j];
						if (hgeqALyhdKyGWBlzFAAwTtKoIKUG3 != null && hgeqALyhdKyGWBlzFAAwTtKoIKUG2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == hgeqALyhdKyGWBlzFAAwTtKoIKUG3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					wsIYxUyCNjQhhcoUWSGbIBGfGfsr(P_0[i], P_2);
				}
			}
		}

		private void wsIYxUyCNjQhhcoUWSGbIBGfGfsr(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.jWBCsLxbeYvGMdvnRNVoniKnRHJD();
			}
			YJITBUCoPwBRVJxRgTtukSXzlMLZA(P_0, P_1);
		}

		private void YJITBUCoPwBRVJxRgTtukSXzlMLZA(hgeqALyhdKyGWBlzFAAwTtKoIKUG P_0, bool P_1)
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
