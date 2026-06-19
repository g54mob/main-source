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

internal class qhEHTWwzpdfUANmcCHXUDkkVGxvn : PlatformInputManager
{
	private class edLZoCAQTvBUycEdsWkOrFiGFHGi : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int HwTLNUyvqDkSjEHaWEyOnHlYhGtB;

		private int WBaoxaCThMgQdahqjHosoWBIEZL;

		private int GilOEfRsEhDCPCODtRARcQnrnPTg;

		public Guid RxUYBLYGIqivqakOWtPaeuMeATt;

		public string erNOLtjANRoyoilQPFCHYVFaxsT;

		public int ZJmbbswvmBuFoQrYSHogylcogaUf;

		public string RvyhpvFdkyCDYCcLhvSphEEMVxw;

		public string kMFIITCLAlHCWfQrUHskdNUnLjQe;

		private int JDyNNdOScJLywOHcbmcaJdgZeIE = 29;

		private int CtHmgLQvreiWMWnBZZLsTLZpuCY = 20;

		private float[] BmVsDDHajHfWhKZRyhtaTrJBobn;

		private bool[] lwtalwosBMdLgdmWCxwqMEvxwal;

		private bool[] RzIfTFbhkwCyEJxQplvAJoDKfCE;

		private float[] OhEfhuIiLAfLogUXRKZbROwkAPYn;

		private bool[] dFfhuCeFJrRPHWuOcdTRBsJXKlN;

		private HardwareJoystickMap_InputManager ZBMEOTEbHBcUeYYftsfiohhXNEse;

		private bool NvMWNQFswZpXSwcgvfrXqxOwMyx;

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
				if (!(erNOLtjANRoyoilQPFCHYVFaxsT != "Unknown Controller"))
				{
					return RvyhpvFdkyCDYCcLhvSphEEMVxw;
				}
				return erNOLtjANRoyoilQPFCHYVFaxsT;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (GilOEfRsEhDCPCODtRARcQnrnPTg < 1)
				{
					return null;
				}
				return GilOEfRsEhDCPCODtRARcQnrnPTg;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return GilOEfRsEhDCPCODtRARcQnrnPTg;
			}
			set
			{
				GilOEfRsEhDCPCODtRARcQnrnPTg = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
				{
					return MiscTools.CreateGuidHashSHA1(name);
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(RvyhpvFdkyCDYCcLhvSphEEMVxw);
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + GilOEfRsEhDCPCODtRARcQnrnPTg);
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

		public edLZoCAQTvBUycEdsWkOrFiGFHGi()
		{
			WBaoxaCThMgQdahqjHosoWBIEZL = -1;
			HwTLNUyvqDkSjEHaWEyOnHlYhGtB = -1;
			GilOEfRsEhDCPCODtRARcQnrnPTg = 0;
		}

		public void obdzkDbpOaaUIgoMQmAkmvMIcKJ()
		{
			PoSdIgbuhkXaateVQltFDLNhMabt();
			RxUYBLYGIqivqakOWtPaeuMeATt = ZBMEOTEbHBcUeYYftsfiohhXNEse.hardwareMapIdentifier.guid;
			erNOLtjANRoyoilQPFCHYVFaxsT = ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName;
			BmVsDDHajHfWhKZRyhtaTrJBobn = new float[JDyNNdOScJLywOHcbmcaJdgZeIE];
			lwtalwosBMdLgdmWCxwqMEvxwal = new bool[CtHmgLQvreiWMWnBZZLsTLZpuCY];
			RzIfTFbhkwCyEJxQplvAJoDKfCE = new bool[JDyNNdOScJLywOHcbmcaJdgZeIE];
			dFfhuCeFJrRPHWuOcdTRBsJXKlN = new bool[29];
			OhEfhuIiLAfLogUXRKZbROwkAPYn = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (GilOEfRsEhDCPCODtRARcQnrnPTg > 0)
			{
				yyoSZuWuabvEWrojOdapJzUqkGKg();
				OqHywWvXuiMZOBydYSSzaganIrEK();
				dpxLoNUKQscDlKAbeZOSlMIeEvD();
			}
		}

		public int QuyjPPVLYssrxnLbKpFVOFYkPay(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0)
		{
			if ((!string.IsNullOrEmpty(kMFIITCLAlHCWfQrUHskdNUnLjQe) || !string.IsNullOrEmpty(P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe)) && !string.Equals(kMFIITCLAlHCWfQrUHskdNUnLjQe, P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw == RvyhpvFdkyCDYCcLhvSphEEMVxw && P_0.ZJmbbswvmBuFoQrYSHogylcogaUf == ZJmbbswvmBuFoQrYSHogylcogaUf)
			{
				return 2;
			}
			if (P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw == RvyhpvFdkyCDYCcLhvSphEEMVxw)
			{
				return 1;
			}
			return 0;
		}

		private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = BPbADakEEWhyIYtlhZcXUTlVzYP();
			P_0.hardwareIdentifier = RkJgHxDMstoRxqAmUOkzfAsKZGc();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = RvyhpvFdkyCDYCcLhvSphEEMVxw;
		}

		private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedController P_0)
		{
			etfbyzPQFfFMvByaCyNPpDEsUfK((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = ZBMEOTEbHBcUeYYftsfiohhXNEse.ToGameHardwareControllerMap();
			P_0.instanceName = RvyhpvFdkyCDYCcLhvSphEEMVxw;
			P_0.productName = RvyhpvFdkyCDYCcLhvSphEEMVxw;
			P_0.isXInputDevice = false;
			P_0.axisCount = JDyNNdOScJLywOHcbmcaJdgZeIE;
			P_0.buttonCount = CtHmgLQvreiWMWnBZZLsTLZpuCY;
			P_0.controllerTypeGuid = RxUYBLYGIqivqakOWtPaeuMeATt;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (JDyNNdOScJLywOHcbmcaJdgZeIE != dataUpdater.axisCount || CtHmgLQvreiWMWnBZZLsTLZpuCY != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < JDyNNdOScJLywOHcbmcaJdgZeIE; i++)
			{
				if (axisValues[i] != BmVsDDHajHfWhKZRyhtaTrJBobn[i])
				{
					axisValues[i] = BmVsDDHajHfWhKZRyhtaTrJBobn[i];
					if (axisHasBeenPressedOSXLinux[i] != RzIfTFbhkwCyEJxQplvAJoDKfCE[i])
					{
						axisHasBeenPressedOSXLinux[i] = RzIfTFbhkwCyEJxQplvAJoDKfCE[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < CtHmgLQvreiWMWnBZZLsTLZpuCY; j++)
			{
				if (buttonValues[j] != lwtalwosBMdLgdmWCxwqMEvxwal[j])
				{
					buttonValues[j] = lwtalwosBMdLgdmWCxwqMEvxwal[j];
				}
			}
			if (NvMWNQFswZpXSwcgvfrXqxOwMyx && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public void fvmwXXXMZREMrAdzDhpgGnYeJRoi(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				unityId = P_0;
			}
		}

		public void WVjZnMRWWRAGgKJTkRutuYYjcXX()
		{
			GilOEfRsEhDCPCODtRARcQnrnPTg = 0;
			nHicOctZXUaXGlQKmLfriuETVQS();
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

		private void yyoSZuWuabvEWrojOdapJzUqkGKg()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(GilOEfRsEhDCPCODtRARcQnrnPTg, i);
				if (OhEfhuIiLAfLogUXRKZbROwkAPYn[i] != joystickAxisValueByJoystickId)
				{
					OhEfhuIiLAfLogUXRKZbROwkAPYn[i] = joystickAxisValueByJoystickId;
					if (!dFfhuCeFJrRPHWuOcdTRBsJXKlN[i] && joystickAxisValueByJoystickId != 0f)
					{
						dFfhuCeFJrRPHWuOcdTRBsJXKlN[i] = true;
					}
				}
			}
		}

		private void OqHywWvXuiMZOBydYSSzaganIrEK()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)ZBMEOTEbHBcUeYYftsfiohhXNEse.map).Axes_orig;
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
				if (i >= JDyNNdOScJLywOHcbmcaJdgZeIE)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = QTYKdOZLkJEqXkCFTAyzbbojlRXP(axes_orig[i]);
				if (BmVsDDHajHfWhKZRyhtaTrJBobn[i] == num)
				{
					continue;
				}
				BmVsDDHajHfWhKZRyhtaTrJBobn[i] = num;
				if (!RzIfTFbhkwCyEJxQplvAJoDKfCE[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = QTYKdOZLkJEqXkCFTAyzbbojlRXP(axes_orig[i].sourceAxis);
						RzIfTFbhkwCyEJxQplvAJoDKfCE[i] = num2 != 0f;
					}
					else
					{
						RzIfTFbhkwCyEJxQplvAJoDKfCE[i] = true;
					}
				}
				if (!NvMWNQFswZpXSwcgvfrXqxOwMyx && BmVsDDHajHfWhKZRyhtaTrJBobn[i] != 0f)
				{
					NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
				}
			}
		}

		private void dpxLoNUKQscDlKAbeZOSlMIeEvD()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)ZBMEOTEbHBcUeYYftsfiohhXNEse.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= CtHmgLQvreiWMWnBZZLsTLZpuCY)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = kAVHgdphgcHqDOwQpMCcCbwXpBK(buttons_orig[i]);
				if (lwtalwosBMdLgdmWCxwqMEvxwal[i] != flag)
				{
					lwtalwosBMdLgdmWCxwqMEvxwal[i] = flag;
					if (!NvMWNQFswZpXSwcgvfrXqxOwMyx && lwtalwosBMdLgdmWCxwqMEvxwal[i])
					{
						NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
					}
				}
			}
		}

		private bool kAVHgdphgcHqDOwQpMCcCbwXpBK(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.requiredButtons[j]))
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
				return kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
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
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				if (P_0.unityHat_sourceAxis1 == UnityAxis.None || P_0.unityHat_sourceAxis2 == UnityAxis.None)
				{
					return false;
				}
				UnityAxis unityHat_sourceAxis = P_0.unityHat_sourceAxis1;
				UnityAxis unityHat_sourceAxis2 = P_0.unityHat_sourceAxis2;
				float num2 = QTYKdOZLkJEqXkCFTAyzbbojlRXP(unityHat_sourceAxis);
				float num3 = QTYKdOZLkJEqXkCFTAyzbbojlRXP(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (rEfSTOkmfahRTRBKVJfJsvetlPY(unityHat_sourceAxis) || rEfSTOkmfahRTRBKVJfJsvetlPY(unityHat_sourceAxis2))
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
				if (HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues1.x, num2) && HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues2.x, num2) && HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues3.x, num2) && HgFYfZdzOVuarsmGkdXMCJkkZsz(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (vZEfqokvghKuJJpNzlTFpAxckJve(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (SPHbezKTTVeuRPAzQsPWynRuLUK(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (xAYTOHShFmbUnXbRgORxZpGJAa(customCalculationSourceData[k], out var flag2))
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

		private bool HgFYfZdzOVuarsmGkdXMCJkkZsz(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float QTYKdOZLkJEqXkCFTAyzbbojlRXP(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!rEfSTOkmfahRTRBKVJfJsvetlPY(P_0.sourceAxis))
				{
					return 0f;
				}
				return QTYKdOZLkJEqXkCFTAyzbbojlRXP(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null)
					{
						HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[i].sourceType;
						HardwareElementSourceTypeWithHat hardwareElementSourceTypeWithHat = sourceType;
						if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && SPHbezKTTVeuRPAzQsPWynRuLUK(customCalculationSourceData[i], out var item))
						{
							customCalculation.AddData(item);
						}
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

		private float QTYKdOZLkJEqXkCFTAyzbbojlRXP(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return OhEfhuIiLAfLogUXRKZbROwkAPYn[num];
		}

		private bool kAVHgdphgcHqDOwQpMCcCbwXpBK(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(GilOEfRsEhDCPCODtRARcQnrnPTg, buttonIndex);
		}

		private bool vZEfqokvghKuJJpNzlTFpAxckJve(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = kAVHgdphgcHqDOwQpMCcCbwXpBK(sourceElement);
			return true;
		}

		private bool xAYTOHShFmbUnXbRgORxZpGJAa(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool SPHbezKTTVeuRPAzQsPWynRuLUK(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = QTYKdOZLkJEqXkCFTAyzbbojlRXP(sourceElement);
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

		private bool rEfSTOkmfahRTRBKVJfJsvetlPY(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return dFfhuCeFJrRPHWuOcdTRBsJXKlN[num];
		}

		private void PoSdIgbuhkXaateVQltFDLNhMabt()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = TuJmIhZHnIxJHszIupkxqjtULhV();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(RvyhpvFdkyCDYCcLhvSphEEMVxw, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.androidFallbackPlatformHelper != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.androidFallbackPlatformHelper.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(RvyhpvFdkyCDYCcLhvSphEEMVxw))
					{
						if (ds4Helper.IsDS4KeyMapped(ZJmbbswvmBuFoQrYSHogylcogaUf))
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
			ZBMEOTEbHBcUeYYftsfiohhXNEse = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse.useSystemName && !string.IsNullOrEmpty(RvyhpvFdkyCDYCcLhvSphEEMVxw))
			{
				string text = Regex.Replace(RvyhpvFdkyCDYCcLhvSphEEMVxw, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName = text;
				}
			}
			if (UnityTools.isIOSPlatform && ZBMEOTEbHBcUeYYftsfiohhXNEse.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text2 = SmPeSttiaCifcByDIMWrovNMxXV(RvyhpvFdkyCDYCcLhvSphEEMVxw);
				if (!string.IsNullOrEmpty(text2))
				{
					ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName = text2;
				}
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
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{BPbADakEEWhyIYtlhZcXUTlVzYP().ToString()}{RvyhpvFdkyCDYCcLhvSphEEMVxw}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(RvyhpvFdkyCDYCcLhvSphEEMVxw, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{BPbADakEEWhyIYtlhZcXUTlVzYP().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{BPbADakEEWhyIYtlhZcXUTlVzYP().ToString()}{RvyhpvFdkyCDYCcLhvSphEEMVxw}");
		}

		private InputSource BPbADakEEWhyIYtlhZcXUTlVzYP()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(RvyhpvFdkyCDYCcLhvSphEEMVxw))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int uwguXCEdnqrosZyJUNRThBOFGNZ(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, edLZoCAQTvBUycEdsWkOrFiGFHGi P_1)
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

		public static int exiaNTlJZpXVUPCyJqInLNaExdO(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, edLZoCAQTvBUycEdsWkOrFiGFHGi P_1)
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

		private static string SmPeSttiaCifcByDIMWrovNMxXV(string P_0)
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

	private class QcbttPpdDzTcxFptQgGOgmwejVw
	{
		public enum JhCBeRNqkmQQEhSSElNSlbTZpH
		{
			bsEuTteZfWpGGkkWfgFWdtTyWHGw = 0,
			HoUDpKToZAvYvTCsbfaQUrQsFTC = 1
		}

		public class YZtTQKHffGQtqrNqBhBYvFwbcbh
		{
			public int AVJCjGFlvmvUQprbQtbNLTqidXD;

			public int ZJmbbswvmBuFoQrYSHogylcogaUf;

			public string OdPvfZNApsWyqPFzvQOxbZJZpyR;

			public int SCvLuAiDgDtSaPnKtxXIaqXDocp;

			public string kMFIITCLAlHCWfQrUHskdNUnLjQe;

			public bool QuyjPPVLYssrxnLbKpFVOFYkPay(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, JhCBeRNqkmQQEhSSElNSlbTZpH P_1)
			{
				if (P_0.rewiredId == AVJCjGFlvmvUQprbQtbNLTqidXD)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(kMFIITCLAlHCWfQrUHskdNUnLjQe) || !string.IsNullOrEmpty(P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe)) && !string.Equals(kMFIITCLAlHCWfQrUHskdNUnLjQe, P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case JhCBeRNqkmQQEhSSElNSlbTZpH.bsEuTteZfWpGGkkWfgFWdtTyWHGw:
					if (ZJmbbswvmBuFoQrYSHogylcogaUf == P_0.ZJmbbswvmBuFoQrYSHogylcogaUf)
					{
						return OdPvfZNApsWyqPFzvQOxbZJZpyR == P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw;
					}
					return false;
				case JhCBeRNqkmQQEhSSElNSlbTZpH.HoUDpKToZAvYvTCsbfaQUrQsFTC:
					return OdPvfZNApsWyqPFzvQOxbZJZpyR == P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class sGcDNrbzSLdsQjnenjwabQFWFRV : IDisposable, IEnumerator, IEnumerable, IEnumerable<YZtTQKHffGQtqrNqBhBYvFwbcbh>, IEnumerator<YZtTQKHffGQtqrNqBhBYvFwbcbh>
		{
			private YZtTQKHffGQtqrNqBhBYvFwbcbh ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public QcbttPpdDzTcxFptQgGOgmwejVw kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public edLZoCAQTvBUycEdsWkOrFiGFHGi UrVHqfdkMVOZnqPAIiNXclLMHTZj;

			public edLZoCAQTvBUycEdsWkOrFiGFHGi ipVhBkVCCSfvawTftgxfuhaEZKG;

			public JhCBeRNqkmQQEhSSElNSlbTZpH paUXJyBjwVEMwHcXAcJgCsKrCvZ;

			public JhCBeRNqkmQQEhSSElNSlbTZpH FXZuxBvuEcsvWVdlSVqtSMIHOMp;

			public int jzXYVuNmyUOzZqJbVDRwwOzdDGD;

			public int MKtfUfOrPwqaxcTZkMuwxjFLVMS;

			YZtTQKHffGQtqrNqBhBYvFwbcbh IEnumerator<YZtTQKHffGQtqrNqBhBYvFwbcbh>.Current
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
			IEnumerator<YZtTQKHffGQtqrNqBhBYvFwbcbh> IEnumerable<YZtTQKHffGQtqrNqBhBYvFwbcbh>.GetEnumerator()
			{
				sGcDNrbzSLdsQjnenjwabQFWFRV sGcDNrbzSLdsQjnenjwabQFWFRV2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					sGcDNrbzSLdsQjnenjwabQFWFRV2 = this;
				}
				else
				{
					sGcDNrbzSLdsQjnenjwabQFWFRV2 = new sGcDNrbzSLdsQjnenjwabQFWFRV(0);
					sGcDNrbzSLdsQjnenjwabQFWFRV2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				sGcDNrbzSLdsQjnenjwabQFWFRV2.UrVHqfdkMVOZnqPAIiNXclLMHTZj = ipVhBkVCCSfvawTftgxfuhaEZKG;
				sGcDNrbzSLdsQjnenjwabQFWFRV2.paUXJyBjwVEMwHcXAcJgCsKrCvZ = FXZuxBvuEcsvWVdlSVqtSMIHOMp;
				return sGcDNrbzSLdsQjnenjwabQFWFRV2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<YZtTQKHffGQtqrNqBhBYvFwbcbh>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					jzXYVuNmyUOzZqJbVDRwwOzdDGD = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB.Count;
					MKtfUfOrPwqaxcTZkMuwxjFLVMS = 0;
					goto IL_00a3;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (MKtfUfOrPwqaxcTZkMuwxjFLVMS >= jzXYVuNmyUOzZqJbVDRwwOzdDGD)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[MKtfUfOrPwqaxcTZkMuwxjFLVMS].QuyjPPVLYssrxnLbKpFVOFYkPay(UrVHqfdkMVOZnqPAIiNXclLMHTZj, paUXJyBjwVEMwHcXAcJgCsKrCvZ))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[MKtfUfOrPwqaxcTZkMuwxjFLVMS];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					MKtfUfOrPwqaxcTZkMuwxjFLVMS++;
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
			public sGcDNrbzSLdsQjnenjwabQFWFRV(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<YZtTQKHffGQtqrNqBhBYvFwbcbh> fopcRAyqeBjmZPOELjthAdVYQiB;

		public int Count => fopcRAyqeBjmZPOELjthAdVYQiB.Count;

		public QcbttPpdDzTcxFptQgGOgmwejVw()
		{
			fopcRAyqeBjmZPOELjthAdVYQiB = new List<YZtTQKHffGQtqrNqBhBYvFwbcbh>();
		}

		public void pNtVjMTCwjmfvmJXawLBYkfoTpi(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
			for (int i = 0; i < count; i++)
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[i].QuyjPPVLYssrxnLbKpFVOFYkPay(P_0, JhCBeRNqkmQQEhSSElNSlbTZpH.bsEuTteZfWpGGkkWfgFWdtTyWHGw))
				{
					fopcRAyqeBjmZPOELjthAdVYQiB[i].AVJCjGFlvmvUQprbQtbNLTqidXD = P_0.rewiredId;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].OdPvfZNApsWyqPFzvQOxbZJZpyR = P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].ZJmbbswvmBuFoQrYSHogylcogaUf = P_0.ZJmbbswvmBuFoQrYSHogylcogaUf;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].SCvLuAiDgDtSaPnKtxXIaqXDocp = P_0.inputManagerId;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].kMFIITCLAlHCWfQrUHskdNUnLjQe = P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe;
					BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, i);
					return;
				}
			}
			fopcRAyqeBjmZPOELjthAdVYQiB.Add(new YZtTQKHffGQtqrNqBhBYvFwbcbh
			{
				AVJCjGFlvmvUQprbQtbNLTqidXD = P_0.rewiredId,
				OdPvfZNApsWyqPFzvQOxbZJZpyR = P_0.RvyhpvFdkyCDYCcLhvSphEEMVxw,
				ZJmbbswvmBuFoQrYSHogylcogaUf = P_0.ZJmbbswvmBuFoQrYSHogylcogaUf,
				SCvLuAiDgDtSaPnKtxXIaqXDocp = P_0.inputManagerId,
				kMFIITCLAlHCWfQrUHskdNUnLjQe = P_0.kMFIITCLAlHCWfQrUHskdNUnLjQe
			});
			BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, fopcRAyqeBjmZPOELjthAdVYQiB.Count - 1);
		}

		public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, JhCBeRNqkmQQEhSSElNSlbTZpH P_1)
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

		public IEnumerable<YZtTQKHffGQtqrNqBhBYvFwbcbh> afvWoBaYQAGDQJhLdAqXpRXzPls(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, JhCBeRNqkmQQEhSSElNSlbTZpH P_1)
		{
			sGcDNrbzSLdsQjnenjwabQFWFRV sGcDNrbzSLdsQjnenjwabQFWFRV2 = new sGcDNrbzSLdsQjnenjwabQFWFRV(-2);
			sGcDNrbzSLdsQjnenjwabQFWFRV2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			sGcDNrbzSLdsQjnenjwabQFWFRV2.ipVhBkVCCSfvawTftgxfuhaEZKG = P_0;
			sGcDNrbzSLdsQjnenjwabQFWFRV2.FXZuxBvuEcsvWVdlSVqtSMIHOMp = P_1;
			return sGcDNrbzSLdsQjnenjwabQFWFRV2;
		}

		public int EZvGxHsqIFFuTapSiFVRnGzgbyW(YZtTQKHffGQtqrNqBhBYvFwbcbh P_0)
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

	private List<edLZoCAQTvBUycEdsWkOrFiGFHGi> GpKTUjLMGVeIHJzINAjLhtehdVC;

	private int hkPEgaZbxwhJzMkQldVtavOeqXDv;

	private QcbttPpdDzTcxFptQgGOgmwejVw VXRpRQGmBLUsrQikVDSFCugvidLN;

	private bool DWJnXrOBumpLFfmZPjflDMezshO;

	private bool BJaGxZArMLzqpovhchMMTVFnijlD;

	private UpdateLoopType jmBSaJJBPATONArmmooyFDkJURE;

	private UpdateLoopType LVlmbxLrmltNTkLCzCNWCivjbEr;

	private TimerAbs zzHYAyyHBMGoeEQslFjdvbwWdUI;

	private Action<int, ControllerDataUpdater> OBflEVhfTmffnsAjdGTAfWJOvWq;

	private PlatformInputManager STXNVyGURWHvVpTJBWUcsUurLbv;

	private readonly IUnifiedKeyboardSource OaSCoZwSKGEeJDrSpKqTpMPkSHOE;

	private readonly IUnifiedMouseSource eSUFZOVUDCMzuBtTXCLctbJfBTO;

	private bool eUGIKMvoEaVMRVEUlDZloQyeWoF;

	private string[] YlkoRfPYStiJWRCrpBUjSKBYQKX;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => hkPEgaZbxwhJzMkQldVtavOeqXDv;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => STXNVyGURWHvVpTJBWUcsUurLbv;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.Fallback;

	public qhEHTWwzpdfUANmcCHXUDkkVGxvn(UpdateLoopSetting updateLoopSetting)
	{
		STXNVyGURWHvVpTJBWUcsUurLbv = this;
		OaSCoZwSKGEeJDrSpKqTpMPkSHOE = new UnityUnifiedKeyboardSource();
		eSUFZOVUDCMzuBtTXCLctbJfBTO = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			int num = 0;
			if (num < list.Count)
			{
				LVlmbxLrmltNTkLCzCNWCivjbEr = list[num];
			}
		}
		YlkoRfPYStiJWRCrpBUjSKBYQKX = new string[0];
		OBflEVhfTmffnsAjdGTAfWJOvWq = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
		{
			UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent += IDibNgPUXBmEPBiiKshylGMlgKf;
		}
		zzHYAyyHBMGoeEQslFjdvbwWdUI = new TimerAbs(1.0);
		VXRpRQGmBLUsrQikVDSFCugvidLN = new QcbttPpdDzTcxFptQgGOgmwejVw();
		OoDFaIeyrIrGfOQwdBnCiIvBbHRL();
		DWJnXrOBumpLFfmZPjflDMezshO = true;
		zzHYAyyHBMGoeEQslFjdvbwWdUI.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		jmBSaJJBPATONArmmooyFDkJURE = updateLoop;
		QfTNhspAYYFnSAvTHesMXOOlWQYv();
		if (DWJnXrOBumpLFfmZPjflDMezshO)
		{
			ECgcLnNOAxTzdoTYOgpcfwIQwLY();
		}
		fikeeHzZorPbLCMiizOEMORFdJAK(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
		{
			UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent -= IDibNgPUXBmEPBiiKshylGMlgKf;
		}
		(OaSCoZwSKGEeJDrSpKqTpMPkSHOE as IDisposable).Dispose();
		(eSUFZOVUDCMzuBtTXCLctbJfBTO as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OBflEVhfTmffnsAjdGTAfWJOvWq;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[i].inputManagerId == assignedControllerId)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
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

	private void IDibNgPUXBmEPBiiKshylGMlgKf()
	{
		DWJnXrOBumpLFfmZPjflDMezshO = true;
		BJaGxZArMLzqpovhchMMTVFnijlD = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Count; i++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[i].unityId == unityJoystickId)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].WVjZnMRWWRAGgKJTkRutuYYjcXX();
			}
		}
		for (int j = 0; j < GpKTUjLMGVeIHJzINAjLhtehdVC.Count; j++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[j].rewiredId == joystickId)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[j].fvmwXXXMZREMrAdzDhpgGnYeJRoi(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return eSUFZOVUDCMzuBtTXCLctbJfBTO;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return OaSCoZwSKGEeJDrSpKqTpMPkSHOE;
	}

	private void OoDFaIeyrIrGfOQwdBnCiIvBbHRL()
	{
		OoDFaIeyrIrGfOQwdBnCiIvBbHRL(Input.GetJoystickNames());
	}

	private void OoDFaIeyrIrGfOQwdBnCiIvBbHRL(string[] P_0)
	{
		int num = 0;
		List<edLZoCAQTvBUycEdsWkOrFiGFHGi> gpKTUjLMGVeIHJzINAjLhtehdVC = GpKTUjLMGVeIHJzINAjLhtehdVC;
		int num2 = hkPEgaZbxwhJzMkQldVtavOeqXDv;
		GpKTUjLMGVeIHJzINAjLhtehdVC = new List<edLZoCAQTvBUycEdsWkOrFiGFHGi>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi2 = new edLZoCAQTvBUycEdsWkOrFiGFHGi();
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.RvyhpvFdkyCDYCcLhvSphEEMVxw = text;
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.erNOLtjANRoyoilQPFCHYVFaxsT = text;
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.ZJmbbswvmBuFoQrYSHogylcogaUf = i;
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.unityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
				{
					edLZoCAQTvBUycEdsWkOrFiGFHGi2.kMFIITCLAlHCWfQrUHskdNUnLjQe = UnityTools.androidFallbackPlatformHelper.GetUniqueDeviceIdentifier(text, i);
				}
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.obdzkDbpOaaUIgoMQmAkmvMIcKJ();
				GpKTUjLMGVeIHJzINAjLhtehdVC.Add(edLZoCAQTvBUycEdsWkOrFiGFHGi2);
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
		YlkoRfPYStiJWRCrpBUjSKBYQKX = P_0;
	}

	private void fikeeHzZorPbLCMiizOEMORFdJAK(UpdateLoopType P_0)
	{
		int count = GpKTUjLMGVeIHJzINAjLhtehdVC.Count;
		for (int i = 0; i < count; i++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[i] != null)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].Update();
			}
		}
	}

	private void KTAwGzsoAsHiEgQlJqUIcwdlEjt(int P_0, int P_1, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_2, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(edLZoCAQTvBUycEdsWkOrFiGFHGi.exiaNTlJZpXVUPCyJqInLNaExdO);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
			UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH.HoUDpKToZAvYvTCsbfaQUrQsFTC);
		}
		YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
		YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH.HoUDpKToZAvYvTCsbfaQUrQsFTC);
		for (int i = 0; i < P_1; i++)
		{
			edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi2 = P_3[i];
			if (edLZoCAQTvBUycEdsWkOrFiGFHGi2 != null && edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId < 0)
			{
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_3);
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.rewiredId = ReInput.GetNewJoystickId();
				VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(edLZoCAQTvBUycEdsWkOrFiGFHGi2);
			}
		}
		P_3.Sort(edLZoCAQTvBUycEdsWkOrFiGFHGi.uwguXCEdnqrosZyJUNRThBOFGNZ);
	}

	private void nMzSzQRKRtEuNERWjNqyJJJAppk(List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_0, int P_1, int P_2)
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

	private bool jKMphJxbMbpySqxLEPdTKRZDSrn(List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_0, int P_1)
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

	private int pzcgaQeegHlaRneiNJuTAjkIvlfu(List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_0)
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

	private bool brHCphkOPMIyDMoTDxdDCAADyNA(List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_0, int P_1)
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

	private void UcQYDPRULynzQPJTWpMsBpLjdRDD(int P_0, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_1, int P_2, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_3, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH P_4)
	{
		int num = ((P_4 != QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH.bsEuTteZfWpGGkkWfgFWdtTyWHGw) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi2 = P_1[i];
			if (edLZoCAQTvBUycEdsWkOrFiGFHGi2 == null || edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi3 = P_3[j];
				if (edLZoCAQTvBUycEdsWkOrFiGFHGi3 != null && !brHCphkOPMIyDMoTDxdDCAADyNA(P_1, edLZoCAQTvBUycEdsWkOrFiGFHGi3.rewiredId) && edLZoCAQTvBUycEdsWkOrFiGFHGi2.QuyjPPVLYssrxnLbKpFVOFYkPay(edLZoCAQTvBUycEdsWkOrFiGFHGi3) >= num)
				{
					edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId = edLZoCAQTvBUycEdsWkOrFiGFHGi3.inputManagerId;
					edLZoCAQTvBUycEdsWkOrFiGFHGi2.rewiredId = edLZoCAQTvBUycEdsWkOrFiGFHGi3.rewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						edLZoCAQTvBUycEdsWkOrFiGFHGi2.unityId = edLZoCAQTvBUycEdsWkOrFiGFHGi3.unityId;
					}
					VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(edLZoCAQTvBUycEdsWkOrFiGFHGi2);
				}
			}
		}
	}

	private void YwWhsupQmPrVTdmbpVrereVcWSG(int P_0, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_1, QcbttPpdDzTcxFptQgGOgmwejVw.JhCBeRNqkmQQEhSSElNSlbTZpH P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi2 = P_1[i];
			if (edLZoCAQTvBUycEdsWkOrFiGFHGi2 == null || edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId >= 0)
			{
				continue;
			}
			QcbttPpdDzTcxFptQgGOgmwejVw.YZtTQKHffGQtqrNqBhBYvFwbcbh yZtTQKHffGQtqrNqBhBYvFwbcbh = null;
			foreach (QcbttPpdDzTcxFptQgGOgmwejVw.YZtTQKHffGQtqrNqBhBYvFwbcbh item in VXRpRQGmBLUsrQikVDSFCugvidLN.afvWoBaYQAGDQJhLdAqXpRXzPls(edLZoCAQTvBUycEdsWkOrFiGFHGi2, P_2))
			{
				if (!brHCphkOPMIyDMoTDxdDCAADyNA(P_1, item.AVJCjGFlvmvUQprbQtbNLTqidXD) && item.SCvLuAiDgDtSaPnKtxXIaqXDocp >= 0)
				{
					yZtTQKHffGQtqrNqBhBYvFwbcbh = item;
					break;
				}
			}
			if (yZtTQKHffGQtqrNqBhBYvFwbcbh != null)
			{
				int num = yZtTQKHffGQtqrNqBhBYvFwbcbh.SCvLuAiDgDtSaPnKtxXIaqXDocp;
				if (!jKMphJxbMbpySqxLEPdTKRZDSrn(P_1, num))
				{
					num = (yZtTQKHffGQtqrNqBhBYvFwbcbh.SCvLuAiDgDtSaPnKtxXIaqXDocp = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_1));
				}
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.inputManagerId = num;
				edLZoCAQTvBUycEdsWkOrFiGFHGi2.rewiredId = yZtTQKHffGQtqrNqBhBYvFwbcbh.AVJCjGFlvmvUQprbQtbNLTqidXD;
				VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(edLZoCAQTvBUycEdsWkOrFiGFHGi2);
			}
		}
	}

	private void ECgcLnNOAxTzdoTYOgpcfwIQwLY()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (BJaGxZArMLzqpovhchMMTVFnijlD || nfWiyuOsgLuucxCzCJgnyAtNTIQ(joystickNames))
		{
			OoDFaIeyrIrGfOQwdBnCiIvBbHRL(joystickNames);
		}
		DWJnXrOBumpLFfmZPjflDMezshO = false;
		if (BJaGxZArMLzqpovhchMMTVFnijlD)
		{
			BJaGxZArMLzqpovhchMMTVFnijlD = false;
		}
	}

	private bool nfWiyuOsgLuucxCzCJgnyAtNTIQ(string[] P_0)
	{
		if (P_0.Length != YlkoRfPYStiJWRCrpBUjSKBYQKX.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], YlkoRfPYStiJWRCrpBUjSKBYQKX[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void NLNETPIPcIzZWgQktmiidfjpSxOl(List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_0, List<edLZoCAQTvBUycEdsWkOrFiGFHGi> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi2 = P_0[i];
			if (edLZoCAQTvBUycEdsWkOrFiGFHGi2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					edLZoCAQTvBUycEdsWkOrFiGFHGi edLZoCAQTvBUycEdsWkOrFiGFHGi3 = P_1[j];
					if (edLZoCAQTvBUycEdsWkOrFiGFHGi3 != null && edLZoCAQTvBUycEdsWkOrFiGFHGi2.rewiredId == edLZoCAQTvBUycEdsWkOrFiGFHGi3.rewiredId)
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

	private void hKnWXzHpMEBnJfTFKLWhLmnAOHC(edLZoCAQTvBUycEdsWkOrFiGFHGi P_0, bool P_1)
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

	private void QfTNhspAYYFnSAvTHesMXOOlWQYv()
	{
		if (jmBSaJJBPATONArmmooyFDkJURE == LVlmbxLrmltNTkLCzCNWCivjbEr && zzHYAyyHBMGoeEQslFjdvbwWdUI.Update())
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
			zzHYAyyHBMGoeEQslFjdvbwWdUI.Start();
		}
	}
}
