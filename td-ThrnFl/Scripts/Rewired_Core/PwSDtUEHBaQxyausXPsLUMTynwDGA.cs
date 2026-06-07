using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class PwSDtUEHBaQxyausXPsLUMTynwDGA : PlatformInputManager
{
	private class MzxGMXfFqdGSRLREzAhGjlXAimsL : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int MvSBemWxtUDyaihBcnAnfWpXwliCb;

		private int PMTQHCHUPSJnEtmmUKpdfwldvn;

		private int ZrkttRQUKEXBohjNBgfHwcpdoMUV;

		public Guid plbQjGZGwPHfmjOviKYBqHVmcoky;

		public string pDmiJaTeaQEecgUOqgopROXNBWCtA;

		public int BnrrvVBQTNkvvHbHCBVGHqlKbjsO;

		public string hTdwMDoMbOygnRppiqTzwIBVjpThA;

		public string pgibprEFFNsmyWMOokweHIPsqocKA;

		private int HioEXyjqsoEYiiwxUBImLJiEwkwkA = 29;

		private int ASqTIMqoboFhohwIieEdOFqjJKpab = 20;

		private float[] FJkoLyBbSywSSVYCGyxCdBWEkQWb;

		private bool[] YvPkDWcnUMJFkEHZsJLomKjyQVHc;

		private bool[] OOYBguzVNXIScFguKlbCiaTZeKiXA;

		private float[] PUGvOuwjWBjVpJwDWPSGqfkylXxv;

		private bool[] KFWAjOdNLFolfMEjHAkNFbeOFekiA;

		private HardwareJoystickMap_InputManager QXdsTywGIrpgrUTFrDhXeDnbDSNiA;

		private bool OdowmWDwqGobyUXAOleQcSYLOucL;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return MvSBemWxtUDyaihBcnAnfWpXwliCb;
			}
			set
			{
				MvSBemWxtUDyaihBcnAnfWpXwliCb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return PMTQHCHUPSJnEtmmUKpdfwldvn;
			}
			set
			{
				PMTQHCHUPSJnEtmmUKpdfwldvn = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(pDmiJaTeaQEecgUOqgopROXNBWCtA != "Unknown Controller"))
				{
					return hTdwMDoMbOygnRppiqTzwIBVjpThA;
				}
				return pDmiJaTeaQEecgUOqgopROXNBWCtA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (ZrkttRQUKEXBohjNBgfHwcpdoMUV < 1)
				{
					return null;
				}
				return ZrkttRQUKEXBohjNBgfHwcpdoMUV;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return ZrkttRQUKEXBohjNBgfHwcpdoMUV;
			}
			set
			{
				ZrkttRQUKEXBohjNBgfHwcpdoMUV = value;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid
		{
			get
			{
				if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
				{
					return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename);
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(hTdwMDoMbOygnRppiqTzwIBVjpThA);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + ZrkttRQUKEXBohjNBgfHwcpdoMUV);
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

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

		public MzxGMXfFqdGSRLREzAhGjlXAimsL()
		{
			PMTQHCHUPSJnEtmmUKpdfwldvn = -1;
			MvSBemWxtUDyaihBcnAnfWpXwliCb = -1;
			ZrkttRQUKEXBohjNBgfHwcpdoMUV = 0;
		}

		public void gdyvkkUGNUeeWPCiPJVfEupxyuCi()
		{
			MhtoPTwuplxCboItXFLojFAXOoKeA();
			plbQjGZGwPHfmjOviKYBqHVmcoky = QXdsTywGIrpgrUTFrDhXeDnbDSNiA.hardwareMapIdentifier.guid;
			pDmiJaTeaQEecgUOqgopROXNBWCtA = QXdsTywGIrpgrUTFrDhXeDnbDSNiA.controllerName;
			FJkoLyBbSywSSVYCGyxCdBWEkQWb = new float[HioEXyjqsoEYiiwxUBImLJiEwkwkA];
			YvPkDWcnUMJFkEHZsJLomKjyQVHc = new bool[ASqTIMqoboFhohwIieEdOFqjJKpab];
			OOYBguzVNXIScFguKlbCiaTZeKiXA = new bool[HioEXyjqsoEYiiwxUBImLJiEwkwkA];
			KFWAjOdNLFolfMEjHAkNFbeOFekiA = new bool[29];
			PUGvOuwjWBjVpJwDWPSGqfkylXxv = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (ZrkttRQUKEXBohjNBgfHwcpdoMUV > 0)
			{
				cOwGhBDMFbybwVLahAlNQLYuGlCp();
				imbiwQJhUJJVBYgRTfbKKbJuYbFK();
				oEOaoefsigICrbQMUBDVaujchgQtA();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int viwCKUinBwbGVcticHfMFQWzDawkb(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0)
		{
			if ((!string.IsNullOrEmpty(pgibprEFFNsmyWMOokweHIPsqocKA) || !string.IsNullOrEmpty(P_0.pgibprEFFNsmyWMOokweHIPsqocKA)) && !string.Equals(pgibprEFFNsmyWMOokweHIPsqocKA, P_0.pgibprEFFNsmyWMOokweHIPsqocKA, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA == hTdwMDoMbOygnRppiqTzwIBVjpThA && P_0.BnrrvVBQTNkvvHbHCBVGHqlKbjsO == BnrrvVBQTNkvvHbHCBVGHqlKbjsO)
			{
				return 2;
			}
			if (P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA == hTdwMDoMbOygnRppiqTzwIBVjpThA)
			{
				return 1;
			}
			return 0;
		}

		private void YKzfKvHquCqOrHrPJcGsUlnpWaiCA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = laWPWDQFstGsJjfCDttEoctmWEKcA();
			P_0.hardwareIdentifier = jjqnbYEfKOryPiJDFHHLJDRXHyxS();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = hTdwMDoMbOygnRppiqTzwIBVjpThA;
		}

		private void srkyKOVamhpHMntJqLlPRdYpdEJo(BridgedController P_0)
		{
			YKzfKvHquCqOrHrPJcGsUlnpWaiCA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = QXdsTywGIrpgrUTFrDhXeDnbDSNiA.ToGameHardwareControllerMap();
			P_0.instanceName = hTdwMDoMbOygnRppiqTzwIBVjpThA;
			P_0.productName = hTdwMDoMbOygnRppiqTzwIBVjpThA;
			P_0.isXInputDevice = false;
			P_0.axisCount = HioEXyjqsoEYiiwxUBImLJiEwkwkA;
			P_0.buttonCount = ASqTIMqoboFhohwIieEdOFqjJKpab;
			P_0.controllerTypeGuid = plbQjGZGwPHfmjOviKYBqHVmcoky;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (HioEXyjqsoEYiiwxUBImLJiEwkwkA != dataUpdater.axisCount || ASqTIMqoboFhohwIieEdOFqjJKpab != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < HioEXyjqsoEYiiwxUBImLJiEwkwkA; i++)
			{
				if (axisValues[i] != FJkoLyBbSywSSVYCGyxCdBWEkQWb[i])
				{
					axisValues[i] = FJkoLyBbSywSSVYCGyxCdBWEkQWb[i];
					if (axisHasBeenPressedOSXLinux[i] != OOYBguzVNXIScFguKlbCiaTZeKiXA[i])
					{
						axisHasBeenPressedOSXLinux[i] = OOYBguzVNXIScFguKlbCiaTZeKiXA[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < ASqTIMqoboFhohwIieEdOFqjJKpab; j++)
			{
				if (buttonValues[j] != YvPkDWcnUMJFkEHZsJLomKjyQVHc[j])
				{
					buttonValues[j] = YvPkDWcnUMJFkEHZsJLomKjyQVHc[j];
				}
			}
			if (OdowmWDwqGobyUXAOleQcSYLOucL && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void vnGLlPESEVwvRUiPftvASURkQgf(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void dNmMYswWTgFenRPxOmourtWtGqkh()
		{
			ZrkttRQUKEXBohjNBgfHwcpdoMUV = 0;
			NCJKczCrercVNrcEMKWEqNAaHpOo();
		}

		public BridgedControllerHWInfo taHiRGHMZDqxQkvpjZrMpJpeCyBTA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			YKzfKvHquCqOrHrPJcGsUlnpWaiCA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			srkyKOVamhpHMntJqLlPRdYpdEJo(bridgedController);
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
			return new ControllerDisconnectedEventArgs(MvSBemWxtUDyaihBcnAnfWpXwliCb);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void cOwGhBDMFbybwVLahAlNQLYuGlCp()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(ZrkttRQUKEXBohjNBgfHwcpdoMUV, i);
				if (PUGvOuwjWBjVpJwDWPSGqfkylXxv[i] != joystickAxisValueByJoystickId)
				{
					PUGvOuwjWBjVpJwDWPSGqfkylXxv[i] = joystickAxisValueByJoystickId;
					if (!KFWAjOdNLFolfMEjHAkNFbeOFekiA[i] && joystickAxisValueByJoystickId != 0f)
					{
						KFWAjOdNLFolfMEjHAkNFbeOFekiA[i] = true;
					}
				}
			}
		}

		private void imbiwQJhUJJVBYgRTfbKKbJuYbFK()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)QXdsTywGIrpgrUTFrDhXeDnbDSNiA.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i] == null)
				{
					continue;
				}
				if (i >= HioEXyjqsoEYiiwxUBImLJiEwkwkA)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = zYtnyOMCjwMvCOpMhuNISVRKMfZr(axes_orig[i]);
				if (FJkoLyBbSywSSVYCGyxCdBWEkQWb[i] == num)
				{
					continue;
				}
				FJkoLyBbSywSSVYCGyxCdBWEkQWb[i] = num;
				if (!OOYBguzVNXIScFguKlbCiaTZeKiXA[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = VXqnkofrDtvLXRqQprIiKqaSQMEH(axes_orig[i].sourceAxis);
						OOYBguzVNXIScFguKlbCiaTZeKiXA[i] = num2 != 0f;
					}
					else
					{
						OOYBguzVNXIScFguKlbCiaTZeKiXA[i] = true;
					}
				}
				if (!OdowmWDwqGobyUXAOleQcSYLOucL && FJkoLyBbSywSSVYCGyxCdBWEkQWb[i] != 0f)
				{
					OdowmWDwqGobyUXAOleQcSYLOucL = true;
				}
			}
		}

		private void oEOaoefsigICrbQMUBDVaujchgQtA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)QXdsTywGIrpgrUTFrDhXeDnbDSNiA.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= ASqTIMqoboFhohwIieEdOFqjJKpab)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = VrHrCgBnXgEenKIOnGJXQAvLOTmwA(buttons_orig[i]);
				if (YvPkDWcnUMJFkEHZsJLomKjyQVHc[i] != flag)
				{
					YvPkDWcnUMJFkEHZsJLomKjyQVHc[i] = flag;
					if (!OdowmWDwqGobyUXAOleQcSYLOucL && YvPkDWcnUMJFkEHZsJLomKjyQVHc[i])
					{
						OdowmWDwqGobyUXAOleQcSYLOucL = true;
					}
				}
			}
		}

		private bool VrHrCgBnXgEenKIOnGJXQAvLOTmwA(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (AKnOJpeMheoPGVNOKrzLJBqETUds(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return false;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!AKnOJpeMheoPGVNOKrzLJBqETUds(P_0.requiredButtons[j]))
						{
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				if (P_0.sourceButton == UnityButton.None)
				{
					return false;
				}
				return AKnOJpeMheoPGVNOKrzLJBqETUds(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = VXqnkofrDtvLXRqQprIiKqaSQMEH(P_0.sourceAxis);
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
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None || P_0.unityHat_sourceAxis2 == UnityAxis.None)
				{
					return false;
				}
				UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
				UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
				float num2 = VXqnkofrDtvLXRqQprIiKqaSQMEH(unityHat_sourceAxis);
				float num3 = VXqnkofrDtvLXRqQprIiKqaSQMEH(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (aLynCjYVjxWMLUyMFaEgfQSpZrGw(unityHat_sourceAxis) || aLynCjYVjxWMLUyMFaEgfQSpZrGw(unityHat_sourceAxis2))
					{
						x = P_0.unityHat_zeroValues.x;
						y = P_0.unityHat_zeroValues.y;
					}
					else
					{
						x = P_0.unityHat_neverPressedZeroValues.x;
						y = P_0.unityHat_neverPressedZeroValues.y;
					}
				}
				else
				{
					x = P_0.unityHat_zeroValues.x;
					y = P_0.unityHat_zeroValues.y;
				}
				if (MathTools.Approximately(num2, x) && MathTools.Approximately(num3, y))
				{
					return false;
				}
				if (HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues1.x, num2) && HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues2.x, num2) && HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues3.x, num2) && HaisBZnklKcqaEQFtqFSQIbLYjKn(P_0.unityHat_isActiveAxisValues3.y, num3))
				{
					return true;
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
				if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					CustomCalculation customCalculation = P_0.customCalculation;
					if (customCalculation == null)
					{
						return false;
					}
					if (customCalculation.ResultType != TypeWrapper.DataType.Single)
					{
						return false;
					}
					HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return false;
					}
					for (int k = 0; k < customCalculationSourceData.Length; k++)
					{
						if (customCalculationSourceData[k] == null)
						{
							continue;
						}
						switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
						{
						case HardwareElementSourceTypeWithHat.Button:
						{
							if (kqAgIwfqBpKmEDaIPivoeCSHBtvKB(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (mdUbPwASYNeKkdcVwSmsCikIcAqeB(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (trHvTFUxLoaMAAQmUQqDDMYDfycI(customCalculationSourceData[k], out var flag2))
							{
								customCalculation.AddData(flag2 ? 1f : 0f);
							}
							break;
						}
						}
					}
					if (!customCalculation.Process())
					{
						return false;
					}
					if (customCalculation.Result.type != TypeWrapper.DataType.Single)
					{
						return false;
					}
					return (float)customCalculation.Result != 0f;
				}
			}
			return false;
		}

		private bool HaisBZnklKcqaEQFtqFSQIbLYjKn(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float zYtnyOMCjwMvCOpMhuNISVRKMfZr(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!aLynCjYVjxWMLUyMFaEgfQSpZrGw(P_0.sourceAxis))
				{
					return 0f;
				}
				return VXqnkofrDtvLXRqQprIiKqaSQMEH(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!AKnOJpeMheoPGVNOKrzLJBqETUds(P_0.sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Key:
				if (P_0.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				if (!Input.GetKey(P_0.sourceKeyCode))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			case HardwareElementSourceTypeWithHat.Custom:
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && mdUbPwASYNeKkdcVwSmsCikIcAqeB(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			default:
				return 0f;
			}
		}

		private float VXqnkofrDtvLXRqQprIiKqaSQMEH(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return PUGvOuwjWBjVpJwDWPSGqfkylXxv[num];
		}

		private bool AKnOJpeMheoPGVNOKrzLJBqETUds(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(ZrkttRQUKEXBohjNBgfHwcpdoMUV, buttonIndex);
		}

		private bool kqAgIwfqBpKmEDaIPivoeCSHBtvKB(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = AKnOJpeMheoPGVNOKrzLJBqETUds(sourceElement);
			return true;
		}

		private bool trHvTFUxLoaMAAQmUQqDDMYDfycI(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool mdUbPwASYNeKkdcVwSmsCikIcAqeB(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)P_0.sourceElement;
			if (sourceElement == UnityAxis.None)
			{
				return false;
			}
			P_1 = VXqnkofrDtvLXRqQprIiKqaSQMEH(sourceElement);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.deadzone > 0f && MathTools.Abs(P_1) <= P_0.deadzone)
			{
				P_1 = 0f;
			}
			if (P_0.invert)
			{
				P_1 *= -1f;
			}
			return true;
		}

		private bool aLynCjYVjxWMLUyMFaEgfQSpZrGw(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return KFWAjOdNLFolfMEjHAkNFbeOFekiA[num];
		}

		private void MhtoPTwuplxCboItXFLojFAXOoKeA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = taHiRGHMZDqxQkvpjZrMpJpeCyBTA();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(hTdwMDoMbOygnRppiqTzwIBVjpThA, "Xbox Wireless Controller.*"))
				{
					UnityTools.externalTools.GetDeviceVIDPIDs(out var vids, out var pids);
					for (int i = 0; i < vids.Count; i++)
					{
						if (vids[i] == 1118 && pids[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							break;
						}
					}
				}
				else if (UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(hTdwMDoMbOygnRppiqTzwIBVjpThA))
					{
						if (ds4Helper.IsDS4KeyMapped(BnrrvVBQTNkvvHbHCBVGHqlKbjsO))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
					}
				}
			}
			QXdsTywGIrpgrUTFrDhXeDnbDSNiA = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (QXdsTywGIrpgrUTFrDhXeDnbDSNiA == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && QXdsTywGIrpgrUTFrDhXeDnbDSNiA.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = VaXNiYUrzPFHeAxOXuEZUmStnneY(hTdwMDoMbOygnRppiqTzwIBVjpThA);
				if (!string.IsNullOrEmpty(text))
				{
					QXdsTywGIrpgrUTFrDhXeDnbDSNiA.controllerName = text;
					if (QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys[0]))
					{
						QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys[0], text));
					}
					QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (QXdsTywGIrpgrUTFrDhXeDnbDSNiA.useSystemName && !string.IsNullOrEmpty(hTdwMDoMbOygnRppiqTzwIBVjpThA))
			{
				string text2 = Regex.Replace(hTdwMDoMbOygnRppiqTzwIBVjpThA, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					QXdsTywGIrpgrUTFrDhXeDnbDSNiA.controllerName = text2;
					if (QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys[0]))
					{
						QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.parentKeys[0], text2));
					}
					QXdsTywGIrpgrUTFrDhXeDnbDSNiA.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			HioEXyjqsoEYiiwxUBImLJiEwkwkA = QXdsTywGIrpgrUTFrDhXeDnbDSNiA.axisCount;
			ASqTIMqoboFhohwIieEdOFqjJKpab = QXdsTywGIrpgrUTFrDhXeDnbDSNiA.buttonCount;
		}

		private void NCJKczCrercVNrcEMKWEqNAaHpOo()
		{
			Array.Clear(YvPkDWcnUMJFkEHZsJLomKjyQVHc, 0, YvPkDWcnUMJFkEHZsJLomKjyQVHc.Length);
			Array.Clear(FJkoLyBbSywSSVYCGyxCdBWEkQWb, 0, FJkoLyBbSywSSVYCGyxCdBWEkQWb.Length);
		}

		private string jjqnbYEfKOryPiJDFHHLJDRXHyxS()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{laWPWDQFstGsJjfCDttEoctmWEKcA().ToString()}{hTdwMDoMbOygnRppiqTzwIBVjpThA}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(hTdwMDoMbOygnRppiqTzwIBVjpThA, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{laWPWDQFstGsJjfCDttEoctmWEKcA().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{laWPWDQFstGsJjfCDttEoctmWEKcA().ToString()}{hTdwMDoMbOygnRppiqTzwIBVjpThA}");
		}

		private InputSource laWPWDQFstGsJjfCDttEoctmWEKcA()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(hTdwMDoMbOygnRppiqTzwIBVjpThA))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int indyWWuzaiolpDkbAfaPkqfzaegeA(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, MzxGMXfFqdGSRLREzAhGjlXAimsL P_1)
		{
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId)
			{
				return -1;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId > P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId)
			{
				return 1;
			}
			return 0;
		}

		public static int JDZUoJbXgGTVNMhIubCnEzsSwLpeA(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, MzxGMXfFqdGSRLREzAhGjlXAimsL P_1)
		{
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId < P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId)
			{
				return -1;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId > P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId)
			{
				return 1;
			}
			return 0;
		}

		private static string VaXNiYUrzPFHeAxOXuEZUmStnneY(string P_0)
		{
			string input = Regex.Replace(P_0, "\\[.*\\] joystick [0-9]+ by ", "");
			input = Regex.Replace(input, "\\s+", " ");
			if (!string.IsNullOrEmpty(input))
			{
				input = input.Trim();
			}
			return input;
		}
	}

	private class JyicVcnsiMmBilFdAulUDXYZQBfo
	{
		public enum aVZBLNsiCHPOxMUVXINpQPrYbOZg
		{
			Exact = 0,
			Approximate = 1
		}

		public class iXtTNDrVapqEbGWxKEilwyYMDPfP
		{
			public int loSeVicNoNfFdaClnilHWHRQvwCKA;

			public int PaEJpBqYtsvBXhPZXUSpHDDeqiNF;

			public string TeSiJZEDToedlFCcGLmkgiHSFyUOA;

			public int CHqQUIEzPJEIMqdpWyeTAXkAmAny;

			public string pENJyXycYDpJdPbCkbHdiKdBPticb;

			public bool PRpmwXUJUvIqkgTVltxyfVrjVxlS(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, aVZBLNsiCHPOxMUVXINpQPrYbOZg P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == loSeVicNoNfFdaClnilHWHRQvwCKA)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(pENJyXycYDpJdPbCkbHdiKdBPticb) || !string.IsNullOrEmpty(P_0.pgibprEFFNsmyWMOokweHIPsqocKA)) && !string.Equals(pENJyXycYDpJdPbCkbHdiKdBPticb, P_0.pgibprEFFNsmyWMOokweHIPsqocKA, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case aVZBLNsiCHPOxMUVXINpQPrYbOZg.Exact:
					if (PaEJpBqYtsvBXhPZXUSpHDDeqiNF == P_0.BnrrvVBQTNkvvHbHCBVGHqlKbjsO)
					{
						return TeSiJZEDToedlFCcGLmkgiHSFyUOA == P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA;
					}
					return false;
				case aVZBLNsiCHPOxMUVXINpQPrYbOZg.Approximate:
					return TeSiJZEDToedlFCcGLmkgiHSFyUOA == P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class nMbqJoVglXuWDMnPwjTlUxHTQsml : IEnumerable<iXtTNDrVapqEbGWxKEilwyYMDPfP>, IEnumerable, IEnumerator<iXtTNDrVapqEbGWxKEilwyYMDPfP>, IEnumerator, IDisposable
		{
			private int DmIvJSXYpgMKhSivZtZbkveupIkS;

			private iXtTNDrVapqEbGWxKEilwyYMDPfP ucmDHhUIgIhutcObjMyNVwoxrspi;

			private int FcxkZOnROfOqsAbAwHaCVVdUoEOC;

			public JyicVcnsiMmBilFdAulUDXYZQBfo CqPKAIcKVjsglTpjwhyZeYVrzKwj;

			private MzxGMXfFqdGSRLREzAhGjlXAimsL QFrVUJNiqfGoaiwouBTmTbzoheaV;

			public MzxGMXfFqdGSRLREzAhGjlXAimsL hWQosyWjiBcShsCuhBAORSpeIbjE;

			private aVZBLNsiCHPOxMUVXINpQPrYbOZg tGHgwbpuBCtOdflAqWwGNWhbloMg;

			public aVZBLNsiCHPOxMUVXINpQPrYbOZg sfyxmbNIEMDNzBcVeWvdbOMnjOnJA;

			private int BvsOCdvBliRlfUavaqXhmvaYQxGC;

			private int VDVIcfpIfVHDzjuJHIpnHKVctfTsb;

			iXtTNDrVapqEbGWxKEilwyYMDPfP IEnumerator<iXtTNDrVapqEbGWxKEilwyYMDPfP>.Current
			{
				[DebuggerHidden]
				get
				{
					return ucmDHhUIgIhutcObjMyNVwoxrspi;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ucmDHhUIgIhutcObjMyNVwoxrspi;
				}
			}

			[DebuggerHidden]
			public nMbqJoVglXuWDMnPwjTlUxHTQsml(int P_0)
			{
				DmIvJSXYpgMKhSivZtZbkveupIkS = P_0;
				FcxkZOnROfOqsAbAwHaCVVdUoEOC = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int dmIvJSXYpgMKhSivZtZbkveupIkS = DmIvJSXYpgMKhSivZtZbkveupIkS;
				JyicVcnsiMmBilFdAulUDXYZQBfo cqPKAIcKVjsglTpjwhyZeYVrzKwj = CqPKAIcKVjsglTpjwhyZeYVrzKwj;
				if (dmIvJSXYpgMKhSivZtZbkveupIkS != 0)
				{
					if (dmIvJSXYpgMKhSivZtZbkveupIkS != 1)
					{
						return false;
					}
					DmIvJSXYpgMKhSivZtZbkveupIkS = -1;
					goto IL_0083;
				}
				DmIvJSXYpgMKhSivZtZbkveupIkS = -1;
				BvsOCdvBliRlfUavaqXhmvaYQxGC = cqPKAIcKVjsglTpjwhyZeYVrzKwj.JAJaKefQfXUTViYoobdOzzBquRqoA.Count;
				VDVIcfpIfVHDzjuJHIpnHKVctfTsb = 0;
				goto IL_0093;
				IL_0083:
				VDVIcfpIfVHDzjuJHIpnHKVctfTsb++;
				goto IL_0093;
				IL_0093:
				if (VDVIcfpIfVHDzjuJHIpnHKVctfTsb < BvsOCdvBliRlfUavaqXhmvaYQxGC)
				{
					if (cqPKAIcKVjsglTpjwhyZeYVrzKwj.JAJaKefQfXUTViYoobdOzzBquRqoA[VDVIcfpIfVHDzjuJHIpnHKVctfTsb].PRpmwXUJUvIqkgTVltxyfVrjVxlS(QFrVUJNiqfGoaiwouBTmTbzoheaV, tGHgwbpuBCtOdflAqWwGNWhbloMg))
					{
						ucmDHhUIgIhutcObjMyNVwoxrspi = cqPKAIcKVjsglTpjwhyZeYVrzKwj.JAJaKefQfXUTViYoobdOzzBquRqoA[VDVIcfpIfVHDzjuJHIpnHKVctfTsb];
						DmIvJSXYpgMKhSivZtZbkveupIkS = 1;
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
			IEnumerator<iXtTNDrVapqEbGWxKEilwyYMDPfP> IEnumerable<iXtTNDrVapqEbGWxKEilwyYMDPfP>.GetEnumerator()
			{
				nMbqJoVglXuWDMnPwjTlUxHTQsml nMbqJoVglXuWDMnPwjTlUxHTQsml2;
				if (DmIvJSXYpgMKhSivZtZbkveupIkS == -2 && FcxkZOnROfOqsAbAwHaCVVdUoEOC == Environment.CurrentManagedThreadId)
				{
					DmIvJSXYpgMKhSivZtZbkveupIkS = 0;
					nMbqJoVglXuWDMnPwjTlUxHTQsml2 = this;
				}
				else
				{
					nMbqJoVglXuWDMnPwjTlUxHTQsml2 = new nMbqJoVglXuWDMnPwjTlUxHTQsml(0);
					nMbqJoVglXuWDMnPwjTlUxHTQsml2.CqPKAIcKVjsglTpjwhyZeYVrzKwj = CqPKAIcKVjsglTpjwhyZeYVrzKwj;
				}
				nMbqJoVglXuWDMnPwjTlUxHTQsml2.QFrVUJNiqfGoaiwouBTmTbzoheaV = hWQosyWjiBcShsCuhBAORSpeIbjE;
				nMbqJoVglXuWDMnPwjTlUxHTQsml2.tGHgwbpuBCtOdflAqWwGNWhbloMg = sfyxmbNIEMDNzBcVeWvdbOMnjOnJA;
				return nMbqJoVglXuWDMnPwjTlUxHTQsml2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<iXtTNDrVapqEbGWxKEilwyYMDPfP>)this).GetEnumerator();
			}
		}

		private List<iXtTNDrVapqEbGWxKEilwyYMDPfP> JAJaKefQfXUTViYoobdOzzBquRqoA;

		public int oLmQJiCpijMXDOqsnpSVxeKXxhER => JAJaKefQfXUTViYoobdOzzBquRqoA.Count;

		public JyicVcnsiMmBilFdAulUDXYZQBfo()
		{
			JAJaKefQfXUTViYoobdOzzBquRqoA = new List<iXtTNDrVapqEbGWxKEilwyYMDPfP>();
		}

		public void nZbNDlWnVILjzGNbsGEZHYnQfUznA(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = JAJaKefQfXUTViYoobdOzzBquRqoA.Count;
			for (int i = 0; i < count; i++)
			{
				if (JAJaKefQfXUTViYoobdOzzBquRqoA[i].PRpmwXUJUvIqkgTVltxyfVrjVxlS(P_0, aVZBLNsiCHPOxMUVXINpQPrYbOZg.Exact))
				{
					JAJaKefQfXUTViYoobdOzzBquRqoA[i].loSeVicNoNfFdaClnilHWHRQvwCKA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					JAJaKefQfXUTViYoobdOzzBquRqoA[i].TeSiJZEDToedlFCcGLmkgiHSFyUOA = P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA;
					JAJaKefQfXUTViYoobdOzzBquRqoA[i].PaEJpBqYtsvBXhPZXUSpHDDeqiNF = P_0.BnrrvVBQTNkvvHbHCBVGHqlKbjsO;
					JAJaKefQfXUTViYoobdOzzBquRqoA[i].CHqQUIEzPJEIMqdpWyeTAXkAmAny = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					JAJaKefQfXUTViYoobdOzzBquRqoA[i].pENJyXycYDpJdPbCkbHdiKdBPticb = P_0.pgibprEFFNsmyWMOokweHIPsqocKA;
					rNYpWqRIiPnZhGWOpTqwWGQChGWdA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
					return;
				}
			}
			JAJaKefQfXUTViYoobdOzzBquRqoA.Add(new iXtTNDrVapqEbGWxKEilwyYMDPfP
			{
				loSeVicNoNfFdaClnilHWHRQvwCKA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				TeSiJZEDToedlFCcGLmkgiHSFyUOA = P_0.hTdwMDoMbOygnRppiqTzwIBVjpThA,
				PaEJpBqYtsvBXhPZXUSpHDDeqiNF = P_0.BnrrvVBQTNkvvHbHCBVGHqlKbjsO,
				CHqQUIEzPJEIMqdpWyeTAXkAmAny = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				pENJyXycYDpJdPbCkbHdiKdBPticb = P_0.pgibprEFFNsmyWMOokweHIPsqocKA
			});
			rNYpWqRIiPnZhGWOpTqwWGQChGWdA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, JAJaKefQfXUTViYoobdOzzBquRqoA.Count - 1);
		}

		public bool digwVRfQphTqdRzxRCwsknQBEKdi(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, aVZBLNsiCHPOxMUVXINpQPrYbOZg P_1)
		{
			int count = JAJaKefQfXUTViYoobdOzzBquRqoA.Count;
			for (int i = 0; i < count; i++)
			{
				if (JAJaKefQfXUTViYoobdOzzBquRqoA[i].PRpmwXUJUvIqkgTVltxyfVrjVxlS(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(nMbqJoVglXuWDMnPwjTlUxHTQsml))]
		public IEnumerable<iXtTNDrVapqEbGWxKEilwyYMDPfP> BOFCYDrGcWdDMYOWHEBgFrYtLYVj(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, aVZBLNsiCHPOxMUVXINpQPrYbOZg P_1)
		{
			return new nMbqJoVglXuWDMnPwjTlUxHTQsml(-2)
			{
				CqPKAIcKVjsglTpjwhyZeYVrzKwj = this,
				hWQosyWjiBcShsCuhBAORSpeIbjE = P_0,
				sfyxmbNIEMDNzBcVeWvdbOMnjOnJA = P_1
			};
		}

		public int hQLNfqwjdTzgMaduYoiFrqujowRN(iXtTNDrVapqEbGWxKEilwyYMDPfP P_0)
		{
			int count = JAJaKefQfXUTViYoobdOzzBquRqoA.Count;
			for (int i = 0; i < count; i++)
			{
				if (JAJaKefQfXUTViYoobdOzzBquRqoA[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void rNYpWqRIiPnZhGWOpTqwWGQChGWdA(int P_0, int P_1)
		{
			for (int num = JAJaKefQfXUTViYoobdOzzBquRqoA.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && JAJaKefQfXUTViYoobdOzzBquRqoA[num].loSeVicNoNfFdaClnilHWHRQvwCKA == P_0)
				{
					JAJaKefQfXUTViYoobdOzzBquRqoA.RemoveAt(num);
				}
			}
		}
	}

	private List<MzxGMXfFqdGSRLREzAhGjlXAimsL> OjKeFfTfoPAUXavdloegpBtpZatkA;

	private int sBkHmwUZgQywMEAYtFcrwDLMdKLGA;

	private JyicVcnsiMmBilFdAulUDXYZQBfo dvCUihBFADJmtGqUbPYkUxPawvzw;

	private bool GlFlPNUEnTCtIiQtkfYiNkJRzffU;

	private bool BpvGioxwUdyJjkuWTzUDIJTNDOwA;

	private UpdateLoopType cWEquchgxzhZpdHNBOAhQyWXEbLp;

	private UpdateLoopType sKonFjXBKTYhrNYFmwQQoHqUPeYx;

	private TimerAbs gDAOPZvXhWviySyblXgAALhDenqB;

	private Action<int, ControllerDataUpdater> oGcvuzhnTrhpttfIUBjDJLmxVEPx;

	private PlatformInputManager nBFdIyDlRfcybVuXMwbWknVLCGMIb;

	private readonly IUnifiedKeyboardSource nCTwumqEeyXTYRBdfqZfoPBgmfCL;

	private readonly IUnifiedMouseSource DaEBUpppPJbchSJExMBnwglCRvwu;

	private bool qfRUTSlmvwCKeMFDpRMydkYvJFYP;

	private string[] vVaXFclvqipDBPiMWcBYwHQMIceR;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => sBkHmwUZgQywMEAYtFcrwDLMdKLGA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => nBFdIyDlRfcybVuXMwbWknVLCGMIb;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public PwSDtUEHBaQxyausXPsLUMTynwDGA(UpdateLoopSetting P_0)
	{
		nBFdIyDlRfcybVuXMwbWknVLCGMIb = this;
		nCTwumqEeyXTYRBdfqZfoPBgmfCL = new UnityUnifiedKeyboardSource();
		DaEBUpppPJbchSJExMBnwglCRvwu = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				sKonFjXBKTYhrNYFmwQQoHqUPeYx = list[num];
			}
		}
		vVaXFclvqipDBPiMWcBYwHQMIceR = new string[0];
		oGcvuzhnTrhpttfIUBjDJLmxVEPx = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg != null)
		{
			UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg.DeviceChangedEvent += EoLxQpPrVsCXhawtIjWBRiliictA;
		}
		gDAOPZvXhWviySyblXgAALhDenqB = new TimerAbs(1.0);
		dvCUihBFADJmtGqUbPYkUxPawvzw = new JyicVcnsiMmBilFdAulUDXYZQBfo();
		TkrGrWFgvyXoveuJbeJGfJQBrwkK();
		GlFlPNUEnTCtIiQtkfYiNkJRzffU = true;
		gDAOPZvXhWviySyblXgAALhDenqB.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		cWEquchgxzhZpdHNBOAhQyWXEbLp = updateLoop;
		IbaBYyEtMhLBVGSOftlmTlqvrDGsA();
		if (GlFlPNUEnTCtIiQtkfYiNkJRzffU)
		{
			FKUuZCkCSfcLDGKxahMDjRgWJwXLA();
		}
		xuysWZFCEysaJOsRRCUaVIEidRbgA(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg != null)
		{
			UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg.DeviceChangedEvent -= EoLxQpPrVsCXhawtIjWBRiliictA;
		}
		(nCTwumqEeyXTYRBdfqZfoPBgmfCL as IDisposable).Dispose();
		(DaEBUpppPJbchSJExMBnwglCRvwu as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return oGcvuzhnTrhpttfIUBjDJLmxVEPx;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < sBkHmwUZgQywMEAYtFcrwDLMdKLGA; i++)
		{
			if (OjKeFfTfoPAUXavdloegpBtpZatkA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				OjKeFfTfoPAUXavdloegpBtpZatkA[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		GlFlPNUEnTCtIiQtkfYiNkJRzffU = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		GlFlPNUEnTCtIiQtkfYiNkJRzffU = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void EoLxQpPrVsCXhawtIjWBRiliictA()
	{
		GlFlPNUEnTCtIiQtkfYiNkJRzffU = true;
		BpvGioxwUdyJjkuWTzUDIJTNDOwA = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < OjKeFfTfoPAUXavdloegpBtpZatkA.Count; i++)
		{
			if (OjKeFfTfoPAUXavdloegpBtpZatkA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				OjKeFfTfoPAUXavdloegpBtpZatkA[i].dNmMYswWTgFenRPxOmourtWtGqkh();
			}
		}
		for (int j = 0; j < OjKeFfTfoPAUXavdloegpBtpZatkA.Count; j++)
		{
			if (OjKeFfTfoPAUXavdloegpBtpZatkA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				OjKeFfTfoPAUXavdloegpBtpZatkA[j].vnGLlPESEVwvRUiPftvASURkQgf(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return DaEBUpppPJbchSJExMBnwglCRvwu;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return nCTwumqEeyXTYRBdfqZfoPBgmfCL;
	}

	private void TkrGrWFgvyXoveuJbeJGfJQBrwkK()
	{
		MjQegZBAQCWKQzIVfBexwLrgfQwR(Input.GetJoystickNames());
	}

	private void MjQegZBAQCWKQzIVfBexwLrgfQwR(string[] P_0)
	{
		int num = 0;
		List<MzxGMXfFqdGSRLREzAhGjlXAimsL> ojKeFfTfoPAUXavdloegpBtpZatkA = OjKeFfTfoPAUXavdloegpBtpZatkA;
		int num2 = sBkHmwUZgQywMEAYtFcrwDLMdKLGA;
		OjKeFfTfoPAUXavdloegpBtpZatkA = new List<MzxGMXfFqdGSRLREzAhGjlXAimsL>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL = new MzxGMXfFqdGSRLREzAhGjlXAimsL();
				mzxGMXfFqdGSRLREzAhGjlXAimsL.hTdwMDoMbOygnRppiqTzwIBVjpThA = text;
				mzxGMXfFqdGSRLREzAhGjlXAimsL.pDmiJaTeaQEecgUOqgopROXNBWCtA = text;
				mzxGMXfFqdGSRLREzAhGjlXAimsL.BnrrvVBQTNkvvHbHCBVGHqlKbjsO = i;
				mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg != null)
				{
					mzxGMXfFqdGSRLREzAhGjlXAimsL.pgibprEFFNsmyWMOokweHIPsqocKA = UnityTools.RddtjxiMwGqXwmDyXwJZYBQUTDqg.GetUniqueDeviceIdentifier(text, i);
				}
				mzxGMXfFqdGSRLREzAhGjlXAimsL.gdyvkkUGNUeeWPCiPJVfEupxyuCi();
				OjKeFfTfoPAUXavdloegpBtpZatkA.Add(mzxGMXfFqdGSRLREzAhGjlXAimsL);
				num++;
			}
		}
		sBkHmwUZgQywMEAYtFcrwDLMdKLGA = num;
		gSvxwcVHmmBMMgLsQvcYCFQcxmfQ(num2, num, ojKeFfTfoPAUXavdloegpBtpZatkA, OjKeFfTfoPAUXavdloegpBtpZatkA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(OjKeFfTfoPAUXavdloegpBtpZatkA[j]));
			}
		}
		vqwEnkYAhDNZicBoiCsdHgvlWkJQ(ojKeFfTfoPAUXavdloegpBtpZatkA, OjKeFfTfoPAUXavdloegpBtpZatkA, false);
		vqwEnkYAhDNZicBoiCsdHgvlWkJQ(OjKeFfTfoPAUXavdloegpBtpZatkA, ojKeFfTfoPAUXavdloegpBtpZatkA, true);
		vVaXFclvqipDBPiMWcBYwHQMIceR = P_0;
	}

	private void xuysWZFCEysaJOsRRCUaVIEidRbgA(UpdateLoopType P_0)
	{
		int count = OjKeFfTfoPAUXavdloegpBtpZatkA.Count;
		for (int i = 0; i < count; i++)
		{
			if (OjKeFfTfoPAUXavdloegpBtpZatkA[i] != null)
			{
				OjKeFfTfoPAUXavdloegpBtpZatkA[i].Update();
			}
		}
	}

	private void gSvxwcVHmmBMMgLsQvcYCFQcxmfQ(int P_0, int P_1, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_2, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(MzxGMXfFqdGSRLREzAhGjlXAimsL.JDZUoJbXgGTVNMhIubCnEzsSwLpeA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			nKhVvXlWCvCcnKdqQQFXuXeJHCUA(P_1, P_3, P_0, P_2, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg.Exact);
			nKhVvXlWCvCcnKdqQQFXuXeJHCUA(P_1, P_3, P_0, P_2, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg.Approximate);
		}
		VKgjMhRdeygTRABetHTvjDrnQlAfA(P_1, P_3, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg.Exact);
		VKgjMhRdeygTRABetHTvjDrnQlAfA(P_1, P_3, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL = P_3[i];
			if (mzxGMXfFqdGSRLREzAhGjlXAimsL != null && mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = JMMukhyuWCAnjMTkMgwWnezHRlCw(P_3);
				mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				dvCUihBFADJmtGqUbPYkUxPawvzw.nZbNDlWnVILjzGNbsGEZHYnQfUznA(mzxGMXfFqdGSRLREzAhGjlXAimsL);
			}
		}
		P_3.Sort(MzxGMXfFqdGSRLREzAhGjlXAimsL.indyWWuzaiolpDkbAfaPkqfzaegeA);
	}

	private void JZEBZYcTbiBFBnKrOwfxedldAsRKA(List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_0, int P_1, int P_2)
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

	private bool LKvuMbNajdDcxiJkUdINMFrRxqSnA(List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_0, int P_1)
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

	private int JMMukhyuWCAnjMTkMgwWnezHRlCw(List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_0)
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

	private bool gqPDgIbPHRxLyRUMuikkOQnTsmSZ(List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_0, int P_1)
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

	private void nKhVvXlWCvCcnKdqQQFXuXeJHCUA(int P_0, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_1, int P_2, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_3, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg P_4)
	{
		int num = ((P_4 != JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL = P_1[i];
			if (mzxGMXfFqdGSRLREzAhGjlXAimsL == null || mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL2 = P_3[j];
				if (mzxGMXfFqdGSRLREzAhGjlXAimsL2 != null && !gqPDgIbPHRxLyRUMuikkOQnTsmSZ(P_1, mzxGMXfFqdGSRLREzAhGjlXAimsL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && mzxGMXfFqdGSRLREzAhGjlXAimsL.viwCKUinBwbGVcticHfMFQWzDawkb(mzxGMXfFqdGSRLREzAhGjlXAimsL2) >= num)
				{
					mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = mzxGMXfFqdGSRLREzAhGjlXAimsL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = mzxGMXfFqdGSRLREzAhGjlXAimsL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = mzxGMXfFqdGSRLREzAhGjlXAimsL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					dvCUihBFADJmtGqUbPYkUxPawvzw.nZbNDlWnVILjzGNbsGEZHYnQfUznA(mzxGMXfFqdGSRLREzAhGjlXAimsL);
				}
			}
		}
	}

	private void VKgjMhRdeygTRABetHTvjDrnQlAfA(int P_0, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_1, JyicVcnsiMmBilFdAulUDXYZQBfo.aVZBLNsiCHPOxMUVXINpQPrYbOZg P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL = P_1[i];
			if (mzxGMXfFqdGSRLREzAhGjlXAimsL == null || mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			JyicVcnsiMmBilFdAulUDXYZQBfo.iXtTNDrVapqEbGWxKEilwyYMDPfP iXtTNDrVapqEbGWxKEilwyYMDPfP = null;
			foreach (JyicVcnsiMmBilFdAulUDXYZQBfo.iXtTNDrVapqEbGWxKEilwyYMDPfP item in dvCUihBFADJmtGqUbPYkUxPawvzw.BOFCYDrGcWdDMYOWHEBgFrYtLYVj(mzxGMXfFqdGSRLREzAhGjlXAimsL, P_2))
			{
				if (!gqPDgIbPHRxLyRUMuikkOQnTsmSZ(P_1, item.loSeVicNoNfFdaClnilHWHRQvwCKA) && item.CHqQUIEzPJEIMqdpWyeTAXkAmAny >= 0)
				{
					iXtTNDrVapqEbGWxKEilwyYMDPfP = item;
					break;
				}
			}
			if (iXtTNDrVapqEbGWxKEilwyYMDPfP != null)
			{
				int num = iXtTNDrVapqEbGWxKEilwyYMDPfP.CHqQUIEzPJEIMqdpWyeTAXkAmAny;
				if (!LKvuMbNajdDcxiJkUdINMFrRxqSnA(P_1, num))
				{
					num = (iXtTNDrVapqEbGWxKEilwyYMDPfP.CHqQUIEzPJEIMqdpWyeTAXkAmAny = JMMukhyuWCAnjMTkMgwWnezHRlCw(P_1));
				}
				mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = iXtTNDrVapqEbGWxKEilwyYMDPfP.loSeVicNoNfFdaClnilHWHRQvwCKA;
				dvCUihBFADJmtGqUbPYkUxPawvzw.nZbNDlWnVILjzGNbsGEZHYnQfUznA(mzxGMXfFqdGSRLREzAhGjlXAimsL);
			}
		}
	}

	private void FKUuZCkCSfcLDGKxahMDjRgWJwXLA()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (BpvGioxwUdyJjkuWTzUDIJTNDOwA || daSVeKBYVuHYVHBLmbNPEEUJAGVv(joystickNames))
		{
			MjQegZBAQCWKQzIVfBexwLrgfQwR(joystickNames);
		}
		GlFlPNUEnTCtIiQtkfYiNkJRzffU = false;
		if (BpvGioxwUdyJjkuWTzUDIJTNDOwA)
		{
			BpvGioxwUdyJjkuWTzUDIJTNDOwA = false;
		}
	}

	private bool daSVeKBYVuHYVHBLmbNPEEUJAGVv(string[] P_0)
	{
		if (P_0.Length != vVaXFclvqipDBPiMWcBYwHQMIceR.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], vVaXFclvqipDBPiMWcBYwHQMIceR[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void vqwEnkYAhDNZicBoiCsdHgvlWkJQ(List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_0, List<MzxGMXfFqdGSRLREzAhGjlXAimsL> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL = P_0[i];
			if (mzxGMXfFqdGSRLREzAhGjlXAimsL == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					MzxGMXfFqdGSRLREzAhGjlXAimsL mzxGMXfFqdGSRLREzAhGjlXAimsL2 = P_1[j];
					if (mzxGMXfFqdGSRLREzAhGjlXAimsL2 != null && mzxGMXfFqdGSRLREzAhGjlXAimsL.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == mzxGMXfFqdGSRLREzAhGjlXAimsL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				UhuPWiXbmwsdvXElxktUWwRuCojI(P_0[i], P_2);
			}
		}
	}

	private void UhuPWiXbmwsdvXElxktUWwRuCojI(MzxGMXfFqdGSRLREzAhGjlXAimsL P_0, bool P_1)
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

	private void IbaBYyEtMhLBVGSOftlmTlqvrDGsA()
	{
		if (cWEquchgxzhZpdHNBOAhQyWXEbLp == sKonFjXBKTYhrNYFmwQQoHqUPeYx && gDAOPZvXhWviySyblXgAALhDenqB.Update())
		{
			GlFlPNUEnTCtIiQtkfYiNkJRzffU = true;
			gDAOPZvXhWviySyblXgAALhDenqB.Start();
		}
	}
}
