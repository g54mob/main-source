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
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class kgqWAFMONnxVtQdidGZVSnDQQTp : PlatformInputManager
{
	private class ptJIbPzhpGqUcARPEDDGoRdjVMmV : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int jYkDyxIcAtmPrmAqJkhrBRrqPigB;

		private int wZldkOcNSnrOgCoqTMsKvgHVHHzQA;

		private int kbCpKDMkDxWFPmqMwAPRpoNWhwYo;

		public Guid CTTibOVmlcfdHwTuDquRbTlJfGmt;

		public string YJMBogDWpnveHRzTDROfZGfwbqOBA;

		public int mANYiDXPGkkMYSKAbvOUYBHhiRqT;

		public string WgPfnLwwbfeOSWsjTfghdHziXXPD;

		public string EuYCrpDCHceXGZDpPUaaJtAHQiXc;

		private int wWgcclthJCWPhdorKgmfCMtSUadA = 29;

		private int bgOpLYgcQNxbFdIRJibvSrWIauxH = 20;

		private float[] kXSEHVeFsRiyzTCJnNWdgabryYOQA;

		private bool[] bJtZBRyucxHBqPjSZnjThDwPzwPU;

		private bool[] tqeBkWnGkiCXndlDrZCWnrQoiHsC;

		private float[] ckkhrweVliVMQUWfpsvQpQqJhjje;

		private bool[] pbaUpAnCKySyKPCgycYJGOYviKuzA;

		private HardwareJoystickMap_InputManager dOXiJoktBEauSXBIWHqZhxDGmlJJ;

		private bool bkOPlQLEzrfNFDITpEQUjncwaQeL;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return jYkDyxIcAtmPrmAqJkhrBRrqPigB;
			}
			set
			{
				jYkDyxIcAtmPrmAqJkhrBRrqPigB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return wZldkOcNSnrOgCoqTMsKvgHVHHzQA;
			}
			set
			{
				wZldkOcNSnrOgCoqTMsKvgHVHHzQA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(YJMBogDWpnveHRzTDROfZGfwbqOBA != "Unknown Controller"))
				{
					return WgPfnLwwbfeOSWsjTfghdHziXXPD;
				}
				return YJMBogDWpnveHRzTDROfZGfwbqOBA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (kbCpKDMkDxWFPmqMwAPRpoNWhwYo < 1)
				{
					return null;
				}
				return kbCpKDMkDxWFPmqMwAPRpoNWhwYo;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return kbCpKDMkDxWFPmqMwAPRpoNWhwYo;
			}
			set
			{
				kbCpKDMkDxWFPmqMwAPRpoNWhwYo = value;
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
					return MiscTools.CreateGuidHashSHA1(WgPfnLwwbfeOSWsjTfghdHziXXPD);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + kbCpKDMkDxWFPmqMwAPRpoNWhwYo);
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

		public ptJIbPzhpGqUcARPEDDGoRdjVMmV()
		{
			wZldkOcNSnrOgCoqTMsKvgHVHHzQA = -1;
			jYkDyxIcAtmPrmAqJkhrBRrqPigB = -1;
			kbCpKDMkDxWFPmqMwAPRpoNWhwYo = 0;
		}

		public void FxSwSkYvVhrwrGuruMnhVoRECOSR()
		{
			plHcDRwEeEiEOfIesApmfKowCWEjA();
			CTTibOVmlcfdHwTuDquRbTlJfGmt = dOXiJoktBEauSXBIWHqZhxDGmlJJ.hardwareMapIdentifier.guid;
			YJMBogDWpnveHRzTDROfZGfwbqOBA = dOXiJoktBEauSXBIWHqZhxDGmlJJ.controllerName;
			kXSEHVeFsRiyzTCJnNWdgabryYOQA = new float[wWgcclthJCWPhdorKgmfCMtSUadA];
			bJtZBRyucxHBqPjSZnjThDwPzwPU = new bool[bgOpLYgcQNxbFdIRJibvSrWIauxH];
			tqeBkWnGkiCXndlDrZCWnrQoiHsC = new bool[wWgcclthJCWPhdorKgmfCMtSUadA];
			pbaUpAnCKySyKPCgycYJGOYviKuzA = new bool[29];
			ckkhrweVliVMQUWfpsvQpQqJhjje = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (kbCpKDMkDxWFPmqMwAPRpoNWhwYo > 0)
			{
				RXCdMXDiEQAxBMipYcFZfHkRVPCSA();
				NHFRVCHlFcFLkXJlcINKkLdNzkPBA();
				NNyiVofNnBGEWkKLrEzZBpDXkAGcA();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int YJSlkQpGoNKJiszHoTOCRiKyQTqd(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0)
		{
			if ((!string.IsNullOrEmpty(EuYCrpDCHceXGZDpPUaaJtAHQiXc) || !string.IsNullOrEmpty(P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc)) && !string.Equals(EuYCrpDCHceXGZDpPUaaJtAHQiXc, P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD == WgPfnLwwbfeOSWsjTfghdHziXXPD && P_0.mANYiDXPGkkMYSKAbvOUYBHhiRqT == mANYiDXPGkkMYSKAbvOUYBHhiRqT)
			{
				return 2;
			}
			if (P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD == WgPfnLwwbfeOSWsjTfghdHziXXPD)
			{
				return 1;
			}
			return 0;
		}

		private void dRQjngszvpMKGwGcRiwecHAIWwAc(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = GEshCPCLnKwRqilBmHnCbTFBiNWK();
			P_0.hardwareIdentifier = KdGBEKhIZxgxsJhYiLzHIXlyxIdo();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = WgPfnLwwbfeOSWsjTfghdHziXXPD;
		}

		private void RbCwXGZSxYkfnqLAZdfFhAgObiNRA(BridgedController P_0)
		{
			dRQjngszvpMKGwGcRiwecHAIWwAc(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = dOXiJoktBEauSXBIWHqZhxDGmlJJ.ToGameHardwareControllerMap();
			P_0.instanceName = WgPfnLwwbfeOSWsjTfghdHziXXPD;
			P_0.productName = WgPfnLwwbfeOSWsjTfghdHziXXPD;
			P_0.isXInputDevice = false;
			P_0.axisCount = wWgcclthJCWPhdorKgmfCMtSUadA;
			P_0.buttonCount = bgOpLYgcQNxbFdIRJibvSrWIauxH;
			P_0.controllerTypeGuid = CTTibOVmlcfdHwTuDquRbTlJfGmt;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (wWgcclthJCWPhdorKgmfCMtSUadA != dataUpdater.axisCount || bgOpLYgcQNxbFdIRJibvSrWIauxH != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < wWgcclthJCWPhdorKgmfCMtSUadA; i++)
			{
				if (axisValues[i] != kXSEHVeFsRiyzTCJnNWdgabryYOQA[i])
				{
					axisValues[i] = kXSEHVeFsRiyzTCJnNWdgabryYOQA[i];
					if (axisHasBeenPressedOSXLinux[i] != tqeBkWnGkiCXndlDrZCWnrQoiHsC[i])
					{
						axisHasBeenPressedOSXLinux[i] = tqeBkWnGkiCXndlDrZCWnrQoiHsC[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < bgOpLYgcQNxbFdIRJibvSrWIauxH; j++)
			{
				if (buttonValues[j] != bJtZBRyucxHBqPjSZnjThDwPzwPU[j])
				{
					buttonValues[j] = bJtZBRyucxHBqPjSZnjThDwPzwPU[j];
				}
			}
			if (bkOPlQLEzrfNFDITpEQUjncwaQeL && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void UaNGpnIXTdXPQoYlmyFhVTqsfSmbA(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void ERUrFasvCBPuAYcafMmwaevWcaih()
		{
			kbCpKDMkDxWFPmqMwAPRpoNWhwYo = 0;
			qrtRGxMzhGsyoiJJbwIGnUgBXZSG();
		}

		public BridgedControllerHWInfo CLrgYCKABehlswkCKZiQUPiZSBHD()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			dRQjngszvpMKGwGcRiwecHAIWwAc(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			RbCwXGZSxYkfnqLAZdfFhAgObiNRA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(jYkDyxIcAtmPrmAqJkhrBRrqPigB);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void RXCdMXDiEQAxBMipYcFZfHkRVPCSA()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(kbCpKDMkDxWFPmqMwAPRpoNWhwYo, i);
				if (ckkhrweVliVMQUWfpsvQpQqJhjje[i] != joystickAxisValueByJoystickId)
				{
					ckkhrweVliVMQUWfpsvQpQqJhjje[i] = joystickAxisValueByJoystickId;
					if (!pbaUpAnCKySyKPCgycYJGOYviKuzA[i] && joystickAxisValueByJoystickId != 0f)
					{
						pbaUpAnCKySyKPCgycYJGOYviKuzA[i] = true;
					}
				}
			}
		}

		private void NHFRVCHlFcFLkXJlcINKkLdNzkPBA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)dOXiJoktBEauSXBIWHqZhxDGmlJJ.map).Axes_orig;
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
				if (i >= wWgcclthJCWPhdorKgmfCMtSUadA)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = GOZXvACNiHfhjFwTAvaWRuxlTzJH(axes_orig[i]);
				if (kXSEHVeFsRiyzTCJnNWdgabryYOQA[i] == num)
				{
					continue;
				}
				kXSEHVeFsRiyzTCJnNWdgabryYOQA[i] = num;
				if (!tqeBkWnGkiCXndlDrZCWnrQoiHsC[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = wGQmAujHKAylgWqDSMRmZMOhfaUr(axes_orig[i].sourceAxis);
						tqeBkWnGkiCXndlDrZCWnrQoiHsC[i] = num2 != 0f;
					}
					else
					{
						tqeBkWnGkiCXndlDrZCWnrQoiHsC[i] = true;
					}
				}
				if (!bkOPlQLEzrfNFDITpEQUjncwaQeL && kXSEHVeFsRiyzTCJnNWdgabryYOQA[i] != 0f)
				{
					bkOPlQLEzrfNFDITpEQUjncwaQeL = true;
				}
			}
		}

		private void NNyiVofNnBGEWkKLrEzZBpDXkAGcA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)dOXiJoktBEauSXBIWHqZhxDGmlJJ.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= bgOpLYgcQNxbFdIRJibvSrWIauxH)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = uVjvXeVBQFskKBqXMppRPrDclUwg(buttons_orig[i]);
				if (bJtZBRyucxHBqPjSZnjThDwPzwPU[i] != flag)
				{
					bJtZBRyucxHBqPjSZnjThDwPzwPU[i] = flag;
					if (!bkOPlQLEzrfNFDITpEQUjncwaQeL && bJtZBRyucxHBqPjSZnjThDwPzwPU[i])
					{
						bkOPlQLEzrfNFDITpEQUjncwaQeL = true;
					}
				}
			}
		}

		private bool uVjvXeVBQFskKBqXMppRPrDclUwg(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (vbZufdoEiJVWlGHDrHVXYZShomlF(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!vbZufdoEiJVWlGHDrHVXYZShomlF(P_0.requiredButtons[j]))
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
				return vbZufdoEiJVWlGHDrHVXYZShomlF(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = wGQmAujHKAylgWqDSMRmZMOhfaUr(P_0.sourceAxis);
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
				float num2 = wGQmAujHKAylgWqDSMRmZMOhfaUr(unityHat_sourceAxis);
				float num3 = wGQmAujHKAylgWqDSMRmZMOhfaUr(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (DAMrnhKHkUHOqTuNahoeowkWRJIr(unityHat_sourceAxis) || DAMrnhKHkUHOqTuNahoeowkWRJIr(unityHat_sourceAxis2))
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
				if (ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues1.x, num2) && ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues2.x, num2) && ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues3.x, num2) && ifIuyVzEafqnDZiGCzPADgNijZEs(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (BcchaboUvCcrahNgyXCaBagkNUlC(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (JIggXuCRlcOJDnMnXYqPzCELcjeD(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (KIbfQJKfWBtqtVshflwJGVuwTXcl(customCalculationSourceData[k], out var flag2))
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

		private bool ifIuyVzEafqnDZiGCzPADgNijZEs(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float GOZXvACNiHfhjFwTAvaWRuxlTzJH(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!DAMrnhKHkUHOqTuNahoeowkWRJIr(P_0.sourceAxis))
				{
					return 0f;
				}
				return wGQmAujHKAylgWqDSMRmZMOhfaUr(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!vbZufdoEiJVWlGHDrHVXYZShomlF(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && JIggXuCRlcOJDnMnXYqPzCELcjeD(customCalculationSourceData[i], out var item))
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

		private float wGQmAujHKAylgWqDSMRmZMOhfaUr(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return ckkhrweVliVMQUWfpsvQpQqJhjje[num];
		}

		private bool vbZufdoEiJVWlGHDrHVXYZShomlF(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(kbCpKDMkDxWFPmqMwAPRpoNWhwYo, buttonIndex);
		}

		private bool BcchaboUvCcrahNgyXCaBagkNUlC(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = vbZufdoEiJVWlGHDrHVXYZShomlF(sourceElement);
			return true;
		}

		private bool KIbfQJKfWBtqtVshflwJGVuwTXcl(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool JIggXuCRlcOJDnMnXYqPzCELcjeD(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = wGQmAujHKAylgWqDSMRmZMOhfaUr(sourceElement);
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

		private bool DAMrnhKHkUHOqTuNahoeowkWRJIr(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return pbaUpAnCKySyKPCgycYJGOYviKuzA[num];
		}

		private void plHcDRwEeEiEOfIesApmfKowCWEjA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = CLrgYCKABehlswkCKZiQUPiZSBHD();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(WgPfnLwwbfeOSWsjTfghdHziXXPD, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(WgPfnLwwbfeOSWsjTfghdHziXXPD))
					{
						if (ds4Helper.IsDS4KeyMapped(mANYiDXPGkkMYSKAbvOUYBHhiRqT))
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
			dOXiJoktBEauSXBIWHqZhxDGmlJJ = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (dOXiJoktBEauSXBIWHqZhxDGmlJJ == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (dOXiJoktBEauSXBIWHqZhxDGmlJJ.useSystemName && !string.IsNullOrEmpty(WgPfnLwwbfeOSWsjTfghdHziXXPD))
			{
				string text = Regex.Replace(WgPfnLwwbfeOSWsjTfghdHziXXPD, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					dOXiJoktBEauSXBIWHqZhxDGmlJJ.controllerName = text;
				}
			}
			if (UnityTools.isIOSPlatform && dOXiJoktBEauSXBIWHqZhxDGmlJJ.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text2 = yRhHZYKnqgPPVLyRkcwVZdyGXvoJ(WgPfnLwwbfeOSWsjTfghdHziXXPD);
				if (!string.IsNullOrEmpty(text2))
				{
					dOXiJoktBEauSXBIWHqZhxDGmlJJ.controllerName = text2;
				}
			}
			wWgcclthJCWPhdorKgmfCMtSUadA = dOXiJoktBEauSXBIWHqZhxDGmlJJ.axisCount;
			bgOpLYgcQNxbFdIRJibvSrWIauxH = dOXiJoktBEauSXBIWHqZhxDGmlJJ.buttonCount;
		}

		private void qrtRGxMzhGsyoiJJbwIGnUgBXZSG()
		{
			Array.Clear(bJtZBRyucxHBqPjSZnjThDwPzwPU, 0, bJtZBRyucxHBqPjSZnjThDwPzwPU.Length);
			Array.Clear(kXSEHVeFsRiyzTCJnNWdgabryYOQA, 0, kXSEHVeFsRiyzTCJnNWdgabryYOQA.Length);
		}

		private string KdGBEKhIZxgxsJhYiLzHIXlyxIdo()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{GEshCPCLnKwRqilBmHnCbTFBiNWK().ToString()}{WgPfnLwwbfeOSWsjTfghdHziXXPD}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(WgPfnLwwbfeOSWsjTfghdHziXXPD, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{GEshCPCLnKwRqilBmHnCbTFBiNWK().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{GEshCPCLnKwRqilBmHnCbTFBiNWK().ToString()}{WgPfnLwwbfeOSWsjTfghdHziXXPD}");
		}

		private InputSource GEshCPCLnKwRqilBmHnCbTFBiNWK()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(WgPfnLwwbfeOSWsjTfghdHziXXPD))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int FANxIWkdjXpmMWBmjYKVjYHWMzwH(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, ptJIbPzhpGqUcARPEDDGoRdjVMmV P_1)
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

		public static int oJfHSLjihrFokFATHGipsOCjKfbn(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, ptJIbPzhpGqUcARPEDDGoRdjVMmV P_1)
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

		private static string yRhHZYKnqgPPVLyRkcwVZdyGXvoJ(string P_0)
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

	private class qIGiwidkfdpDPqBsdLBGKLaobptfA
	{
		public enum DQbxqHqxNiMLUPAWuvsdDfPbTRRS
		{
			Exact = 0,
			Approximate = 1
		}

		public class RbXqIRnjpUMHGHeyjCClpeejtfji
		{
			public int UfydoochtgdHWANySQRVDMlbnKOeb;

			public int oLseiLicDVJhqbqKkqktMMreBSJub;

			public string iowBoJYvQLUdADojnqEynodfzSGX;

			public int dmKpeGKrCwAIdzGgthULFAKjgqldA;

			public string CudNHXmAPwPxEKIZDhzjFwNqLJsm;

			public bool uGBVVRSQPSovVzCKWXcgqSNIHOxg(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, DQbxqHqxNiMLUPAWuvsdDfPbTRRS P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == UfydoochtgdHWANySQRVDMlbnKOeb)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(CudNHXmAPwPxEKIZDhzjFwNqLJsm) || !string.IsNullOrEmpty(P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc)) && !string.Equals(CudNHXmAPwPxEKIZDhzjFwNqLJsm, P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Exact:
					if (oLseiLicDVJhqbqKkqktMMreBSJub == P_0.mANYiDXPGkkMYSKAbvOUYBHhiRqT)
					{
						return iowBoJYvQLUdADojnqEynodfzSGX == P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD;
					}
					return false;
				case DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Approximate:
					return iowBoJYvQLUdADojnqEynodfzSGX == P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class AbDgQyNTkcGrmBZYLtbrZurekOol : IEnumerable<RbXqIRnjpUMHGHeyjCClpeejtfji>, IEnumerable, IEnumerator<RbXqIRnjpUMHGHeyjCClpeejtfji>, IEnumerator, IDisposable
		{
			private int iaceCYZPiJSoGDOkezcpxsELsuuI;

			private RbXqIRnjpUMHGHeyjCClpeejtfji PqCycrIytlAdIbEwIYkRCGMGBDtGA;

			private int oqHfTPDnEWPQJUXgVYdcHGfxJWGvA;

			public qIGiwidkfdpDPqBsdLBGKLaobptfA nxdjkIwhSCiiISTqFYwXhedEfHkV;

			private ptJIbPzhpGqUcARPEDDGoRdjVMmV tMJKiHDwpEqmZdzlDHlcAFVNLOeo;

			public ptJIbPzhpGqUcARPEDDGoRdjVMmV IQoXPoKiicbkWfRXQGbUHEyHnereb;

			private DQbxqHqxNiMLUPAWuvsdDfPbTRRS QRjmBrfxWfMpQgyZHMgQStLMwBES;

			public DQbxqHqxNiMLUPAWuvsdDfPbTRRS XZIgEtXWTfVUISdUPeZdgjgUlizs;

			private int cfOSlpfcgVnPQBXlDPSzbyNxEkWr;

			private int wUvPljlhmehDOlFYgCXffHrUoVBaA;

			RbXqIRnjpUMHGHeyjCClpeejtfji IEnumerator<RbXqIRnjpUMHGHeyjCClpeejtfji>.Current
			{
				[DebuggerHidden]
				get
				{
					return PqCycrIytlAdIbEwIYkRCGMGBDtGA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PqCycrIytlAdIbEwIYkRCGMGBDtGA;
				}
			}

			[DebuggerHidden]
			public AbDgQyNTkcGrmBZYLtbrZurekOol(int P_0)
			{
				iaceCYZPiJSoGDOkezcpxsELsuuI = P_0;
				oqHfTPDnEWPQJUXgVYdcHGfxJWGvA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = iaceCYZPiJSoGDOkezcpxsELsuuI;
				qIGiwidkfdpDPqBsdLBGKLaobptfA qIGiwidkfdpDPqBsdLBGKLaobptfA2 = nxdjkIwhSCiiISTqFYwXhedEfHkV;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					iaceCYZPiJSoGDOkezcpxsELsuuI = -1;
					goto IL_0083;
				}
				iaceCYZPiJSoGDOkezcpxsELsuuI = -1;
				cfOSlpfcgVnPQBXlDPSzbyNxEkWr = qIGiwidkfdpDPqBsdLBGKLaobptfA2.gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count;
				wUvPljlhmehDOlFYgCXffHrUoVBaA = 0;
				goto IL_0093;
				IL_0083:
				wUvPljlhmehDOlFYgCXffHrUoVBaA++;
				goto IL_0093;
				IL_0093:
				if (wUvPljlhmehDOlFYgCXffHrUoVBaA < cfOSlpfcgVnPQBXlDPSzbyNxEkWr)
				{
					if (qIGiwidkfdpDPqBsdLBGKLaobptfA2.gGtzdgWFmyVYuJRbPZWUmAfHpLuF[wUvPljlhmehDOlFYgCXffHrUoVBaA].uGBVVRSQPSovVzCKWXcgqSNIHOxg(tMJKiHDwpEqmZdzlDHlcAFVNLOeo, QRjmBrfxWfMpQgyZHMgQStLMwBES))
					{
						PqCycrIytlAdIbEwIYkRCGMGBDtGA = qIGiwidkfdpDPqBsdLBGKLaobptfA2.gGtzdgWFmyVYuJRbPZWUmAfHpLuF[wUvPljlhmehDOlFYgCXffHrUoVBaA];
						iaceCYZPiJSoGDOkezcpxsELsuuI = 1;
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
			IEnumerator<RbXqIRnjpUMHGHeyjCClpeejtfji> IEnumerable<RbXqIRnjpUMHGHeyjCClpeejtfji>.GetEnumerator()
			{
				AbDgQyNTkcGrmBZYLtbrZurekOol abDgQyNTkcGrmBZYLtbrZurekOol;
				if (iaceCYZPiJSoGDOkezcpxsELsuuI == -2 && oqHfTPDnEWPQJUXgVYdcHGfxJWGvA == Environment.CurrentManagedThreadId)
				{
					iaceCYZPiJSoGDOkezcpxsELsuuI = 0;
					abDgQyNTkcGrmBZYLtbrZurekOol = this;
				}
				else
				{
					abDgQyNTkcGrmBZYLtbrZurekOol = new AbDgQyNTkcGrmBZYLtbrZurekOol(0);
					abDgQyNTkcGrmBZYLtbrZurekOol.nxdjkIwhSCiiISTqFYwXhedEfHkV = nxdjkIwhSCiiISTqFYwXhedEfHkV;
				}
				abDgQyNTkcGrmBZYLtbrZurekOol.tMJKiHDwpEqmZdzlDHlcAFVNLOeo = IQoXPoKiicbkWfRXQGbUHEyHnereb;
				abDgQyNTkcGrmBZYLtbrZurekOol.QRjmBrfxWfMpQgyZHMgQStLMwBES = XZIgEtXWTfVUISdUPeZdgjgUlizs;
				return abDgQyNTkcGrmBZYLtbrZurekOol;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<RbXqIRnjpUMHGHeyjCClpeejtfji>)this).GetEnumerator();
			}
		}

		private List<RbXqIRnjpUMHGHeyjCClpeejtfji> gGtzdgWFmyVYuJRbPZWUmAfHpLuF;

		public int ZBCeteCNjIPcyHStGmiPqHquHPYw => gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count;

		public qIGiwidkfdpDPqBsdLBGKLaobptfA()
		{
			gGtzdgWFmyVYuJRbPZWUmAfHpLuF = new List<RbXqIRnjpUMHGHeyjCClpeejtfji>();
		}

		public void UfRyBdOPUpzaYVTwDaLRBBTxwWfC(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count;
			for (int i = 0; i < count; i++)
			{
				if (gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].uGBVVRSQPSovVzCKWXcgqSNIHOxg(P_0, DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Exact))
				{
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].UfydoochtgdHWANySQRVDMlbnKOeb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].iowBoJYvQLUdADojnqEynodfzSGX = P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD;
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].oLseiLicDVJhqbqKkqktMMreBSJub = P_0.mANYiDXPGkkMYSKAbvOUYBHhiRqT;
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].dmKpeGKrCwAIdzGgthULFAKjgqldA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].CudNHXmAPwPxEKIZDhzjFwNqLJsm = P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc;
					GTqtycNwjoPfENOROMZiPGunulMh(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
					return;
				}
			}
			gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Add(new RbXqIRnjpUMHGHeyjCClpeejtfji
			{
				UfydoochtgdHWANySQRVDMlbnKOeb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				iowBoJYvQLUdADojnqEynodfzSGX = P_0.WgPfnLwwbfeOSWsjTfghdHziXXPD,
				oLseiLicDVJhqbqKkqktMMreBSJub = P_0.mANYiDXPGkkMYSKAbvOUYBHhiRqT,
				dmKpeGKrCwAIdzGgthULFAKjgqldA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				CudNHXmAPwPxEKIZDhzjFwNqLJsm = P_0.EuYCrpDCHceXGZDpPUaaJtAHQiXc
			});
			GTqtycNwjoPfENOROMZiPGunulMh(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count - 1);
		}

		public bool YqImVXdJyEsHMYKgubqcihmuYazqA(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, DQbxqHqxNiMLUPAWuvsdDfPbTRRS P_1)
		{
			int count = gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count;
			for (int i = 0; i < count; i++)
			{
				if (gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i].uGBVVRSQPSovVzCKWXcgqSNIHOxg(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(AbDgQyNTkcGrmBZYLtbrZurekOol))]
		public IEnumerable<RbXqIRnjpUMHGHeyjCClpeejtfji> aknsjXrnxzCrvZlRiJyoSNuMaxTo(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, DQbxqHqxNiMLUPAWuvsdDfPbTRRS P_1)
		{
			return new AbDgQyNTkcGrmBZYLtbrZurekOol(-2)
			{
				nxdjkIwhSCiiISTqFYwXhedEfHkV = this,
				IQoXPoKiicbkWfRXQGbUHEyHnereb = P_0,
				XZIgEtXWTfVUISdUPeZdgjgUlizs = P_1
			};
		}

		public int OvdUbweecydelzGnbwMJkJMOEMJv(RbXqIRnjpUMHGHeyjCClpeejtfji P_0)
		{
			int count = gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count;
			for (int i = 0; i < count; i++)
			{
				if (gGtzdgWFmyVYuJRbPZWUmAfHpLuF[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void GTqtycNwjoPfENOROMZiPGunulMh(int P_0, int P_1)
		{
			for (int num = gGtzdgWFmyVYuJRbPZWUmAfHpLuF.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && gGtzdgWFmyVYuJRbPZWUmAfHpLuF[num].UfydoochtgdHWANySQRVDMlbnKOeb == P_0)
				{
					gGtzdgWFmyVYuJRbPZWUmAfHpLuF.RemoveAt(num);
				}
			}
		}
	}

	private List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> hQsAcdJwvmLYuqtgUWVgSARMeMhQ;

	private int NLSbTsWBbnowrRwBEbSnxVxxOwDn;

	private qIGiwidkfdpDPqBsdLBGKLaobptfA WDmJdjJyNiQkARqNKvicZafByFfR;

	private bool fpdyRXYusmrxrvokNkemMqroRsni;

	private bool otBhdwcnxvZaslplvqPSHDvcZxCCA;

	private UpdateLoopType BDcfRonliIRXIomOeTqfTDeyqJFu;

	private UpdateLoopType BPEkmdZMDelOCWMGNuMInwEpSqMI;

	private TimerAbs BDaIvNBnOYOxPxVxUgdkmJjmnCxab;

	private Action<int, ControllerDataUpdater> BAKtQrlOAAGtQCoRbSLRaUAIlmJcA;

	private PlatformInputManager OQvthojCKWqxSxIjbNkSkxtmaEEe;

	private readonly IUnifiedKeyboardSource GXzOVeizhFJTxEvaKCzfpHfLEyIG;

	private readonly IUnifiedMouseSource sTafpztKCckuERBNSDfbbTXbcFyp;

	private bool XixqOGxHwBEuTDEIKyIywdiGjvSU;

	private string[] UrAQiutLtPFxyExRbTxGxFgvMSyw;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => NLSbTsWBbnowrRwBEbSnxVxxOwDn;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => OQvthojCKWqxSxIjbNkSkxtmaEEe;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public kgqWAFMONnxVtQdidGZVSnDQQTp(UpdateLoopSetting P_0)
	{
		OQvthojCKWqxSxIjbNkSkxtmaEEe = this;
		GXzOVeizhFJTxEvaKCzfpHfLEyIG = new UnityUnifiedKeyboardSource();
		sTafpztKCckuERBNSDfbbTXbcFyp = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				BPEkmdZMDelOCWMGNuMInwEpSqMI = list[num];
			}
		}
		UrAQiutLtPFxyExRbTxGxFgvMSyw = new string[0];
		BAKtQrlOAAGtQCoRbSLRaUAIlmJcA = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA != null)
		{
			UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA.DeviceChangedEvent += vGIGSObVwclAwGxzcILIXUYHAGyhc;
		}
		BDaIvNBnOYOxPxVxUgdkmJjmnCxab = new TimerAbs(1.0);
		WDmJdjJyNiQkARqNKvicZafByFfR = new qIGiwidkfdpDPqBsdLBGKLaobptfA();
		cBXFSAHpuLAkEcrEUldWfgkeEZktA();
		fpdyRXYusmrxrvokNkemMqroRsni = true;
		BDaIvNBnOYOxPxVxUgdkmJjmnCxab.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		BDcfRonliIRXIomOeTqfTDeyqJFu = updateLoop;
		zFAvYihTGQRwaVLcGZRceEqCnnKE();
		if (fpdyRXYusmrxrvokNkemMqroRsni)
		{
			ypyqZAuTcEZByDbgToUBWkUlGYXi();
		}
		QzIhFZBcJJoGwReOiGyeCrqJplrO(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA != null)
		{
			UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA.DeviceChangedEvent -= vGIGSObVwclAwGxzcILIXUYHAGyhc;
		}
		(GXzOVeizhFJTxEvaKCzfpHfLEyIG as IDisposable).Dispose();
		(sTafpztKCckuERBNSDfbbTXbcFyp as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return BAKtQrlOAAGtQCoRbSLRaUAIlmJcA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < NLSbTsWBbnowrRwBEbSnxVxxOwDn; i++)
		{
			if (hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		fpdyRXYusmrxrvokNkemMqroRsni = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		fpdyRXYusmrxrvokNkemMqroRsni = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void vGIGSObVwclAwGxzcILIXUYHAGyhc()
	{
		fpdyRXYusmrxrvokNkemMqroRsni = true;
		otBhdwcnxvZaslplvqPSHDvcZxCCA = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < hQsAcdJwvmLYuqtgUWVgSARMeMhQ.Count; i++)
		{
			if (hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i].ERUrFasvCBPuAYcafMmwaevWcaih();
			}
		}
		for (int j = 0; j < hQsAcdJwvmLYuqtgUWVgSARMeMhQ.Count; j++)
		{
			if (hQsAcdJwvmLYuqtgUWVgSARMeMhQ[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				hQsAcdJwvmLYuqtgUWVgSARMeMhQ[j].UaNGpnIXTdXPQoYlmyFhVTqsfSmbA(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return sTafpztKCckuERBNSDfbbTXbcFyp;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return GXzOVeizhFJTxEvaKCzfpHfLEyIG;
	}

	private void cBXFSAHpuLAkEcrEUldWfgkeEZktA()
	{
		jQcbJRRbBrTMpgNQSkArtOZBOacn(Input.GetJoystickNames());
	}

	private void jQcbJRRbBrTMpgNQSkArtOZBOacn(string[] P_0)
	{
		int num = 0;
		List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> list = hQsAcdJwvmLYuqtgUWVgSARMeMhQ;
		int nLSbTsWBbnowrRwBEbSnxVxxOwDn = NLSbTsWBbnowrRwBEbSnxVxxOwDn;
		hQsAcdJwvmLYuqtgUWVgSARMeMhQ = new List<ptJIbPzhpGqUcARPEDDGoRdjVMmV>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV2 = new ptJIbPzhpGqUcARPEDDGoRdjVMmV();
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.WgPfnLwwbfeOSWsjTfghdHziXXPD = text;
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.YJMBogDWpnveHRzTDROfZGfwbqOBA = text;
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.mANYiDXPGkkMYSKAbvOUYBHhiRqT = i;
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA != null)
				{
					ptJIbPzhpGqUcARPEDDGoRdjVMmV2.EuYCrpDCHceXGZDpPUaaJtAHQiXc = UnityTools.cpLrCxcQtxKuFzfzsDGNdJvftxsmA.GetUniqueDeviceIdentifier(text, i);
				}
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.FxSwSkYvVhrwrGuruMnhVoRECOSR();
				hQsAcdJwvmLYuqtgUWVgSARMeMhQ.Add(ptJIbPzhpGqUcARPEDDGoRdjVMmV2);
				num++;
			}
		}
		NLSbTsWBbnowrRwBEbSnxVxxOwDn = num;
		BMXDMqJxxFYldjYzjWqUJkmVGLlG(nLSbTsWBbnowrRwBEbSnxVxxOwDn, num, list, hQsAcdJwvmLYuqtgUWVgSARMeMhQ);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(hQsAcdJwvmLYuqtgUWVgSARMeMhQ[j]));
			}
		}
		OiIBSyOXigHtRvYtBAYdSnJUKgLL(list, hQsAcdJwvmLYuqtgUWVgSARMeMhQ, false);
		OiIBSyOXigHtRvYtBAYdSnJUKgLL(hQsAcdJwvmLYuqtgUWVgSARMeMhQ, list, true);
		UrAQiutLtPFxyExRbTxGxFgvMSyw = P_0;
	}

	private void QzIhFZBcJJoGwReOiGyeCrqJplrO(UpdateLoopType P_0)
	{
		int count = hQsAcdJwvmLYuqtgUWVgSARMeMhQ.Count;
		for (int i = 0; i < count; i++)
		{
			if (hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i] != null)
			{
				hQsAcdJwvmLYuqtgUWVgSARMeMhQ[i].Update();
			}
		}
	}

	private void BMXDMqJxxFYldjYzjWqUJkmVGLlG(int P_0, int P_1, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_2, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(ptJIbPzhpGqUcARPEDDGoRdjVMmV.oJfHSLjihrFokFATHGipsOCjKfbn);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			WVsFwfazBfwGVaNkRMiNpbpTmxAZA(P_1, P_3, P_0, P_2, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Exact);
			WVsFwfazBfwGVaNkRMiNpbpTmxAZA(P_1, P_3, P_0, P_2, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Approximate);
		}
		uuAGYhVZrJIRiDDzMbxrEIZUYDGaA(P_1, P_3, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Exact);
		uuAGYhVZrJIRiDDzMbxrEIZUYDGaA(P_1, P_3, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV2 = P_3[i];
			if (ptJIbPzhpGqUcARPEDDGoRdjVMmV2 != null && ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = isqVZvyVpllISXbIhQUAkLkwJBOE(P_3);
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				WDmJdjJyNiQkARqNKvicZafByFfR.UfRyBdOPUpzaYVTwDaLRBBTxwWfC(ptJIbPzhpGqUcARPEDDGoRdjVMmV2);
			}
		}
		P_3.Sort(ptJIbPzhpGqUcARPEDDGoRdjVMmV.FANxIWkdjXpmMWBmjYKVjYHWMzwH);
	}

	private void oHyhwKkfuHNDmejqxoVrtTJGTEDT(List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_0, int P_1, int P_2)
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

	private bool iPZxbnTceUsnQACnndiFSMRmsCEw(List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_0, int P_1)
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

	private int isqVZvyVpllISXbIhQUAkLkwJBOE(List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_0)
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

	private bool BrzRQIPKacZRxNLIJYIaLBlcApMD(List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_0, int P_1)
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

	private void WVsFwfazBfwGVaNkRMiNpbpTmxAZA(int P_0, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_1, int P_2, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_3, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS P_4)
	{
		int num = ((P_4 != qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV2 = P_1[i];
			if (ptJIbPzhpGqUcARPEDDGoRdjVMmV2 == null || ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV3 = P_3[j];
				if (ptJIbPzhpGqUcARPEDDGoRdjVMmV3 != null && !BrzRQIPKacZRxNLIJYIaLBlcApMD(P_1, ptJIbPzhpGqUcARPEDDGoRdjVMmV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && ptJIbPzhpGqUcARPEDDGoRdjVMmV2.YJSlkQpGoNKJiszHoTOCRiKyQTqd(ptJIbPzhpGqUcARPEDDGoRdjVMmV3) >= num)
				{
					ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = ptJIbPzhpGqUcARPEDDGoRdjVMmV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ptJIbPzhpGqUcARPEDDGoRdjVMmV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = ptJIbPzhpGqUcARPEDDGoRdjVMmV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					WDmJdjJyNiQkARqNKvicZafByFfR.UfRyBdOPUpzaYVTwDaLRBBTxwWfC(ptJIbPzhpGqUcARPEDDGoRdjVMmV2);
				}
			}
		}
	}

	private void uuAGYhVZrJIRiDDzMbxrEIZUYDGaA(int P_0, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_1, qIGiwidkfdpDPqBsdLBGKLaobptfA.DQbxqHqxNiMLUPAWuvsdDfPbTRRS P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV2 = P_1[i];
			if (ptJIbPzhpGqUcARPEDDGoRdjVMmV2 == null || ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			qIGiwidkfdpDPqBsdLBGKLaobptfA.RbXqIRnjpUMHGHeyjCClpeejtfji rbXqIRnjpUMHGHeyjCClpeejtfji = null;
			foreach (qIGiwidkfdpDPqBsdLBGKLaobptfA.RbXqIRnjpUMHGHeyjCClpeejtfji item in WDmJdjJyNiQkARqNKvicZafByFfR.aknsjXrnxzCrvZlRiJyoSNuMaxTo(ptJIbPzhpGqUcARPEDDGoRdjVMmV2, P_2))
			{
				if (!BrzRQIPKacZRxNLIJYIaLBlcApMD(P_1, item.UfydoochtgdHWANySQRVDMlbnKOeb) && item.dmKpeGKrCwAIdzGgthULFAKjgqldA >= 0)
				{
					rbXqIRnjpUMHGHeyjCClpeejtfji = item;
					break;
				}
			}
			if (rbXqIRnjpUMHGHeyjCClpeejtfji != null)
			{
				int num = rbXqIRnjpUMHGHeyjCClpeejtfji.dmKpeGKrCwAIdzGgthULFAKjgqldA;
				if (!iPZxbnTceUsnQACnndiFSMRmsCEw(P_1, num))
				{
					num = (rbXqIRnjpUMHGHeyjCClpeejtfji.dmKpeGKrCwAIdzGgthULFAKjgqldA = isqVZvyVpllISXbIhQUAkLkwJBOE(P_1));
				}
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = rbXqIRnjpUMHGHeyjCClpeejtfji.UfydoochtgdHWANySQRVDMlbnKOeb;
				WDmJdjJyNiQkARqNKvicZafByFfR.UfRyBdOPUpzaYVTwDaLRBBTxwWfC(ptJIbPzhpGqUcARPEDDGoRdjVMmV2);
			}
		}
	}

	private void ypyqZAuTcEZByDbgToUBWkUlGYXi()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (otBhdwcnxvZaslplvqPSHDvcZxCCA || ImipaKNuWVXtsEVEDNMZLpymssHj(joystickNames))
		{
			jQcbJRRbBrTMpgNQSkArtOZBOacn(joystickNames);
		}
		fpdyRXYusmrxrvokNkemMqroRsni = false;
		if (otBhdwcnxvZaslplvqPSHDvcZxCCA)
		{
			otBhdwcnxvZaslplvqPSHDvcZxCCA = false;
		}
	}

	private bool ImipaKNuWVXtsEVEDNMZLpymssHj(string[] P_0)
	{
		if (P_0.Length != UrAQiutLtPFxyExRbTxGxFgvMSyw.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], UrAQiutLtPFxyExRbTxGxFgvMSyw[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void OiIBSyOXigHtRvYtBAYdSnJUKgLL(List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_0, List<ptJIbPzhpGqUcARPEDDGoRdjVMmV> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV2 = P_0[i];
			if (ptJIbPzhpGqUcARPEDDGoRdjVMmV2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					ptJIbPzhpGqUcARPEDDGoRdjVMmV ptJIbPzhpGqUcARPEDDGoRdjVMmV3 = P_1[j];
					if (ptJIbPzhpGqUcARPEDDGoRdjVMmV3 != null && ptJIbPzhpGqUcARPEDDGoRdjVMmV2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == ptJIbPzhpGqUcARPEDDGoRdjVMmV3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				bSIPagZpjNWwWQNgWrAURRxFOmvx(P_0[i], P_2);
			}
		}
	}

	private void bSIPagZpjNWwWQNgWrAURRxFOmvx(ptJIbPzhpGqUcARPEDDGoRdjVMmV P_0, bool P_1)
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

	private void zFAvYihTGQRwaVLcGZRceEqCnnKE()
	{
		if (BDcfRonliIRXIomOeTqfTDeyqJFu == BPEkmdZMDelOCWMGNuMInwEpSqMI && BDaIvNBnOYOxPxVxUgdkmJjmnCxab.Update())
		{
			fpdyRXYusmrxrvokNkemMqroRsni = true;
			BDaIvNBnOYOxPxVxUgdkmJjmnCxab.Start();
		}
	}
}
