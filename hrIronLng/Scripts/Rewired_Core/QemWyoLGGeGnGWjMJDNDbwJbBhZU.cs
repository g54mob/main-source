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

internal class QemWyoLGGeGnGWjMJDNDbwJbBhZU : PlatformInputManager
{
	private class usaUzIWUmvHGQubVIqmkcOxadgR : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int jIpZegDsRCglpRpWZFkZhlMabSZS;

		private int sVCXCYtCFTJlHfQcwXhLqojaMtg;

		private int gfRejPemhyrlXBFjuSIUeEWTIFdB;

		public Guid ndgbjpxTbxrFsttqZvzramhIWKV;

		public string YdteeZaQmIaNannwKqGOnKaYbypx;

		public int jWYWoOVkVQeEkPxaNiXliuFIcou;

		public string zeSUqHoZRvaBQVdckAscfnsmpBA;

		public string UdjAlzHtvuftQNDXVocbITpTczgx;

		private int rGEuFEtJcMmFaLOCcsmbRHUjSpy = 29;

		private int qrXpdbCUzFLCBfjCDTfPHyJCus = 20;

		private float[] jzpVEtuClUvVjBdDtjXvLsbzhOL;

		private bool[] HgTlEIPAcVpesdxuHAohUBSLbkRC;

		private bool[] jmeCIdMXNtDxUWviuhpHTMgobzka;

		private float[] kxmuOGvEoVicsiNpOTHcmIXGHZeS;

		private bool[] NmBvDsNukchwDJksdLWUBfabebh;

		private HardwareJoystickMap_InputManager rEqQznEUmYwtoLNJsErzjlKjjYY;

		private bool lIckeksaZUISOlJWqVjEgKdCPmH;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return jIpZegDsRCglpRpWZFkZhlMabSZS;
			}
			set
			{
				jIpZegDsRCglpRpWZFkZhlMabSZS = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return sVCXCYtCFTJlHfQcwXhLqojaMtg;
			}
			set
			{
				sVCXCYtCFTJlHfQcwXhLqojaMtg = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (!(YdteeZaQmIaNannwKqGOnKaYbypx != "Unknown Controller"))
				{
					return zeSUqHoZRvaBQVdckAscfnsmpBA;
				}
				return YdteeZaQmIaNannwKqGOnKaYbypx;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (gfRejPemhyrlXBFjuSIUeEWTIFdB < 1)
				{
					return null;
				}
				return gfRejPemhyrlXBFjuSIUeEWTIFdB;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return gfRejPemhyrlXBFjuSIUeEWTIFdB;
			}
			set
			{
				gfRejPemhyrlXBFjuSIUeEWTIFdB = value;
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
					return MiscTools.CreateGuidHashSHA1(zeSUqHoZRvaBQVdckAscfnsmpBA);
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + gfRejPemhyrlXBFjuSIUeEWTIFdB);
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

		public usaUzIWUmvHGQubVIqmkcOxadgR()
		{
			sVCXCYtCFTJlHfQcwXhLqojaMtg = -1;
			jIpZegDsRCglpRpWZFkZhlMabSZS = -1;
			gfRejPemhyrlXBFjuSIUeEWTIFdB = 0;
		}

		public void KfBKHnOxjftuCpCkJBMbkWxcLWv()
		{
			nXglhCVRQvdNmlZfFNtWDSyReON();
			ndgbjpxTbxrFsttqZvzramhIWKV = rEqQznEUmYwtoLNJsErzjlKjjYY.hardwareMapIdentifier.guid;
			YdteeZaQmIaNannwKqGOnKaYbypx = rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName;
			jzpVEtuClUvVjBdDtjXvLsbzhOL = new float[rGEuFEtJcMmFaLOCcsmbRHUjSpy];
			HgTlEIPAcVpesdxuHAohUBSLbkRC = new bool[qrXpdbCUzFLCBfjCDTfPHyJCus];
			jmeCIdMXNtDxUWviuhpHTMgobzka = new bool[rGEuFEtJcMmFaLOCcsmbRHUjSpy];
			NmBvDsNukchwDJksdLWUBfabebh = new bool[29];
			kxmuOGvEoVicsiNpOTHcmIXGHZeS = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (gfRejPemhyrlXBFjuSIUeEWTIFdB > 0)
			{
				WLSGqQtNDcWxMeSRTWwcfYlAcYq();
				eDxlTkEkZjIqIOaXTGEydwFFOfoR();
				DmLZJnvnrnNkrBYTnoYZbojIVhn();
			}
		}

		public int kGUAgzoWmpBJnomvNrYAMpbELMU(usaUzIWUmvHGQubVIqmkcOxadgR P_0)
		{
			if ((!string.IsNullOrEmpty(UdjAlzHtvuftQNDXVocbITpTczgx) || !string.IsNullOrEmpty(P_0.UdjAlzHtvuftQNDXVocbITpTczgx)) && !string.Equals(UdjAlzHtvuftQNDXVocbITpTczgx, P_0.UdjAlzHtvuftQNDXVocbITpTczgx, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.zeSUqHoZRvaBQVdckAscfnsmpBA == zeSUqHoZRvaBQVdckAscfnsmpBA && P_0.jWYWoOVkVQeEkPxaNiXliuFIcou == jWYWoOVkVQeEkPxaNiXliuFIcou)
			{
				return 2;
			}
			if (P_0.zeSUqHoZRvaBQVdckAscfnsmpBA == zeSUqHoZRvaBQVdckAscfnsmpBA)
			{
				return 1;
			}
			return 0;
		}

		private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = lLvrnrNqnRUwmJgRoXTvQDentea();
			P_0.hardwareIdentifier = xtPTTEaBiKHldvKRyKuWbfwSXWZ();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = zeSUqHoZRvaBQVdckAscfnsmpBA;
		}

		private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedController P_0)
		{
			OZHQiQgSzsqBMEXKRiXEjRuQMNq((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = rEqQznEUmYwtoLNJsErzjlKjjYY.ToGameHardwareControllerMap();
			P_0.instanceName = zeSUqHoZRvaBQVdckAscfnsmpBA;
			P_0.productName = zeSUqHoZRvaBQVdckAscfnsmpBA;
			P_0.isXInputDevice = false;
			P_0.axisCount = rGEuFEtJcMmFaLOCcsmbRHUjSpy;
			P_0.buttonCount = qrXpdbCUzFLCBfjCDTfPHyJCus;
			P_0.controllerTypeGuid = ndgbjpxTbxrFsttqZvzramhIWKV;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (rGEuFEtJcMmFaLOCcsmbRHUjSpy != dataUpdater.axisCount || qrXpdbCUzFLCBfjCDTfPHyJCus != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < rGEuFEtJcMmFaLOCcsmbRHUjSpy; i++)
			{
				if (axisValues[i] != jzpVEtuClUvVjBdDtjXvLsbzhOL[i])
				{
					axisValues[i] = jzpVEtuClUvVjBdDtjXvLsbzhOL[i];
					if (axisHasBeenPressedOSXLinux[i] != jmeCIdMXNtDxUWviuhpHTMgobzka[i])
					{
						axisHasBeenPressedOSXLinux[i] = jmeCIdMXNtDxUWviuhpHTMgobzka[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < qrXpdbCUzFLCBfjCDTfPHyJCus; j++)
			{
				if (buttonValues[j] != HgTlEIPAcVpesdxuHAohUBSLbkRC[j])
				{
					buttonValues[j] = HgTlEIPAcVpesdxuHAohUBSLbkRC[j];
				}
			}
			if (lIckeksaZUISOlJWqVjEgKdCPmH && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public void TIOKahaRuKqflPvBEtjlfNpWlFI(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				unityId = P_0;
			}
		}

		public void mpVJEcuqbOftoLfpzcDcyGxDNcp()
		{
			gfRejPemhyrlXBFjuSIUeEWTIFdB = 0;
			BMxTPkCTwKHaHoMkxNoqwTHvLfs();
		}

		public BridgedControllerHWInfo nGxBhPkTOZfyTEzcjVyqmmIgztnf()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(jIpZegDsRCglpRpWZFkZhlMabSZS);
		}

		private void WLSGqQtNDcWxMeSRTWwcfYlAcYq()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(gfRejPemhyrlXBFjuSIUeEWTIFdB, i);
				if (kxmuOGvEoVicsiNpOTHcmIXGHZeS[i] != joystickAxisValueByJoystickId)
				{
					kxmuOGvEoVicsiNpOTHcmIXGHZeS[i] = joystickAxisValueByJoystickId;
					if (!NmBvDsNukchwDJksdLWUBfabebh[i] && joystickAxisValueByJoystickId != 0f)
					{
						NmBvDsNukchwDJksdLWUBfabebh[i] = true;
					}
				}
			}
		}

		private void eDxlTkEkZjIqIOaXTGEydwFFOfoR()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)rEqQznEUmYwtoLNJsErzjlKjjYY.map).Axes_orig;
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
				if (i >= rGEuFEtJcMmFaLOCcsmbRHUjSpy)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(axes_orig[i]);
				if (jzpVEtuClUvVjBdDtjXvLsbzhOL[i] == num)
				{
					continue;
				}
				jzpVEtuClUvVjBdDtjXvLsbzhOL[i] = num;
				if (!jmeCIdMXNtDxUWviuhpHTMgobzka[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(axes_orig[i].sourceAxis);
						jmeCIdMXNtDxUWviuhpHTMgobzka[i] = num2 != 0f;
					}
					else
					{
						jmeCIdMXNtDxUWviuhpHTMgobzka[i] = true;
					}
				}
				if (!lIckeksaZUISOlJWqVjEgKdCPmH && jzpVEtuClUvVjBdDtjXvLsbzhOL[i] != 0f)
				{
					lIckeksaZUISOlJWqVjEgKdCPmH = true;
				}
			}
		}

		private void DmLZJnvnrnNkrBYTnoYZbojIVhn()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)rEqQznEUmYwtoLNJsErzjlKjjYY.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= qrXpdbCUzFLCBfjCDTfPHyJCus)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = YkbkFPCFEvZkXFmauWArEBZdXhq(buttons_orig[i]);
				if (HgTlEIPAcVpesdxuHAohUBSLbkRC[i] != flag)
				{
					HgTlEIPAcVpesdxuHAohUBSLbkRC[i] = flag;
					if (!lIckeksaZUISOlJWqVjEgKdCPmH && HgTlEIPAcVpesdxuHAohUBSLbkRC[i])
					{
						lIckeksaZUISOlJWqVjEgKdCPmH = true;
					}
				}
			}
		}

		private bool YkbkFPCFEvZkXFmauWArEBZdXhq(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.requiredButtons[j]))
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
				return YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0.sourceAxis);
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
				float num2 = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(unityHat_sourceAxis);
				float num3 = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (DvNfQcDiLbKEDEcbMXJKoQGXlui(unityHat_sourceAxis) || DvNfQcDiLbKEDEcbMXJKoQGXlui(unityHat_sourceAxis2))
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
				if (hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues1.x, num2) && hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues2.x, num2) && hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues3.x, num2) && hzliQjSHnMiRjGzedHXXtVVWUcNG(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (DtkQDQCSRwOHNcqlyADIILECiDDb(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (ittPmBtheEVfDGaFJHZRamcUBGi(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (JrevEpuvpAVtMofxOaRSlJaiRkS(customCalculationSourceData[k], out var flag2))
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

		private bool hzliQjSHnMiRjGzedHXXtVVWUcNG(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!DvNfQcDiLbKEDEcbMXJKoQGXlui(P_0.sourceAxis))
				{
					return 0f;
				}
				return cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.sourceButton))
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
						if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && ittPmBtheEVfDGaFJHZRamcUBGi(customCalculationSourceData[i], out var item))
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

		private float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return kxmuOGvEoVicsiNpOTHcmIXGHZeS[num];
		}

		private bool YkbkFPCFEvZkXFmauWArEBZdXhq(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(gfRejPemhyrlXBFjuSIUeEWTIFdB, buttonIndex);
		}

		private bool DtkQDQCSRwOHNcqlyADIILECiDDb(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = YkbkFPCFEvZkXFmauWArEBZdXhq(sourceElement);
			return true;
		}

		private bool JrevEpuvpAVtMofxOaRSlJaiRkS(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool ittPmBtheEVfDGaFJHZRamcUBGi(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(sourceElement);
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

		private bool DvNfQcDiLbKEDEcbMXJKoQGXlui(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return NmBvDsNukchwDJksdLWUBfabebh[num];
		}

		private void nXglhCVRQvdNmlZfFNtWDSyReON()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = nGxBhPkTOZfyTEzcjVyqmmIgztnf();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(zeSUqHoZRvaBQVdckAscfnsmpBA, "Xbox Wireless Controller.*"))
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
					if (ds4Helper != null && ds4Helper.IsDS4(zeSUqHoZRvaBQVdckAscfnsmpBA))
					{
						if (ds4Helper.IsDS4KeyMapped(jWYWoOVkVQeEkPxaNiXliuFIcou))
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
			rEqQznEUmYwtoLNJsErzjlKjjYY = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (rEqQznEUmYwtoLNJsErzjlKjjYY.useSystemName && !string.IsNullOrEmpty(zeSUqHoZRvaBQVdckAscfnsmpBA))
			{
				string text = Regex.Replace(zeSUqHoZRvaBQVdckAscfnsmpBA, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName = text;
				}
			}
			if (UnityTools.isIOSPlatform && rEqQznEUmYwtoLNJsErzjlKjjYY.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text2 = stjSdFUeZBGMidjbHVUeujisZLzE(zeSUqHoZRvaBQVdckAscfnsmpBA);
				if (!string.IsNullOrEmpty(text2))
				{
					rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName = text2;
				}
			}
			rGEuFEtJcMmFaLOCcsmbRHUjSpy = rEqQznEUmYwtoLNJsErzjlKjjYY.axisCount;
			qrXpdbCUzFLCBfjCDTfPHyJCus = rEqQznEUmYwtoLNJsErzjlKjjYY.buttonCount;
		}

		private void BMxTPkCTwKHaHoMkxNoqwTHvLfs()
		{
			Array.Clear(HgTlEIPAcVpesdxuHAohUBSLbkRC, 0, HgTlEIPAcVpesdxuHAohUBSLbkRC.Length);
			Array.Clear(jzpVEtuClUvVjBdDtjXvLsbzhOL, 0, jzpVEtuClUvVjBdDtjXvLsbzhOL.Length);
		}

		private string xtPTTEaBiKHldvKRyKuWbfwSXWZ()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{lLvrnrNqnRUwmJgRoXTvQDentea().ToString()}{zeSUqHoZRvaBQVdckAscfnsmpBA}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(zeSUqHoZRvaBQVdckAscfnsmpBA, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{lLvrnrNqnRUwmJgRoXTvQDentea().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{lLvrnrNqnRUwmJgRoXTvQDentea().ToString()}{zeSUqHoZRvaBQVdckAscfnsmpBA}");
		}

		private InputSource lLvrnrNqnRUwmJgRoXTvQDentea()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(zeSUqHoZRvaBQVdckAscfnsmpBA))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int CFEFaonWGdGHmSbxFpVUdBbnEVrf(usaUzIWUmvHGQubVIqmkcOxadgR P_0, usaUzIWUmvHGQubVIqmkcOxadgR P_1)
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

		public static int AbMgSvAHikioAQPYCMbaLAHsHra(usaUzIWUmvHGQubVIqmkcOxadgR P_0, usaUzIWUmvHGQubVIqmkcOxadgR P_1)
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

		private static string stjSdFUeZBGMidjbHVUeujisZLzE(string P_0)
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

	private class FbCjmhUvrJOrSYCatVKizXQcGbQ
	{
		public enum kIVvFktUxOgfVeOxEgYguFDLBnB
		{
			JlcFwBXJAZQpAvmagfRVInsQEVib = 0,
			lkctGikYsLMhbYMEyImPMsrGWJw = 1
		}

		public class DwBctdfRvzWsClScUGOppwvgTtr
		{
			public int sjbjANsWQaKxKgfHgxDuZgoAatr;

			public int jWYWoOVkVQeEkPxaNiXliuFIcou;

			public string khvGMpkRQjhHiSkBkeSsdqkvyhn;

			public int kPTxDqHUNQFlgCKgmbPPsQsvVsL;

			public string UdjAlzHtvuftQNDXVocbITpTczgx;

			public bool kGUAgzoWmpBJnomvNrYAMpbELMU(usaUzIWUmvHGQubVIqmkcOxadgR P_0, kIVvFktUxOgfVeOxEgYguFDLBnB P_1)
			{
				if (P_0.rewiredId == sjbjANsWQaKxKgfHgxDuZgoAatr)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(UdjAlzHtvuftQNDXVocbITpTczgx) || !string.IsNullOrEmpty(P_0.UdjAlzHtvuftQNDXVocbITpTczgx)) && !string.Equals(UdjAlzHtvuftQNDXVocbITpTczgx, P_0.UdjAlzHtvuftQNDXVocbITpTczgx, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case kIVvFktUxOgfVeOxEgYguFDLBnB.JlcFwBXJAZQpAvmagfRVInsQEVib:
					if (jWYWoOVkVQeEkPxaNiXliuFIcou == P_0.jWYWoOVkVQeEkPxaNiXliuFIcou)
					{
						return khvGMpkRQjhHiSkBkeSsdqkvyhn == P_0.zeSUqHoZRvaBQVdckAscfnsmpBA;
					}
					return false;
				case kIVvFktUxOgfVeOxEgYguFDLBnB.lkctGikYsLMhbYMEyImPMsrGWJw:
					return khvGMpkRQjhHiSkBkeSsdqkvyhn == P_0.zeSUqHoZRvaBQVdckAscfnsmpBA;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class RAUdSLjlApwwnjBSDymohtqJNLSC : IDisposable, IEnumerator, IEnumerable, IEnumerable<DwBctdfRvzWsClScUGOppwvgTtr>, IEnumerator<DwBctdfRvzWsClScUGOppwvgTtr>
		{
			private DwBctdfRvzWsClScUGOppwvgTtr WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public FbCjmhUvrJOrSYCatVKizXQcGbQ GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public usaUzIWUmvHGQubVIqmkcOxadgR gHvYZHUarOaorfxsTfLYBukkoDdr;

			public usaUzIWUmvHGQubVIqmkcOxadgR UbjxuEellXeMyafFoPliUyZkaWij;

			public kIVvFktUxOgfVeOxEgYguFDLBnB NDuIiQmBXOqfkYsxTjDpIDbLijzg;

			public kIVvFktUxOgfVeOxEgYguFDLBnB bHlBJlWzmhLdKSVRZFPkQzpzAEJ;

			public int RipzaMeXkBzWHlXLENAjqhAXDtl;

			public int mHNUnJhfGxhBdbwddNEdzrObqJc;

			DwBctdfRvzWsClScUGOppwvgTtr IEnumerator<DwBctdfRvzWsClScUGOppwvgTtr>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<DwBctdfRvzWsClScUGOppwvgTtr> IEnumerable<DwBctdfRvzWsClScUGOppwvgTtr>.GetEnumerator()
			{
				RAUdSLjlApwwnjBSDymohtqJNLSC rAUdSLjlApwwnjBSDymohtqJNLSC;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					rAUdSLjlApwwnjBSDymohtqJNLSC = this;
				}
				else
				{
					rAUdSLjlApwwnjBSDymohtqJNLSC = new RAUdSLjlApwwnjBSDymohtqJNLSC(0);
					rAUdSLjlApwwnjBSDymohtqJNLSC.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				rAUdSLjlApwwnjBSDymohtqJNLSC.gHvYZHUarOaorfxsTfLYBukkoDdr = UbjxuEellXeMyafFoPliUyZkaWij;
				rAUdSLjlApwwnjBSDymohtqJNLSC.NDuIiQmBXOqfkYsxTjDpIDbLijzg = bHlBJlWzmhLdKSVRZFPkQzpzAEJ;
				return rAUdSLjlApwwnjBSDymohtqJNLSC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<DwBctdfRvzWsClScUGOppwvgTtr>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					RipzaMeXkBzWHlXLENAjqhAXDtl = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
					mHNUnJhfGxhBdbwddNEdzrObqJc = 0;
					goto IL_00a3;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (mHNUnJhfGxhBdbwddNEdzrObqJc >= RipzaMeXkBzWHlXLENAjqhAXDtl)
					{
						break;
					}
					if (GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[mHNUnJhfGxhBdbwddNEdzrObqJc].kGUAgzoWmpBJnomvNrYAMpbELMU(gHvYZHUarOaorfxsTfLYBukkoDdr, NDuIiQmBXOqfkYsxTjDpIDbLijzg))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[mHNUnJhfGxhBdbwddNEdzrObqJc];
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					mHNUnJhfGxhBdbwddNEdzrObqJc++;
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
			public RAUdSLjlApwwnjBSDymohtqJNLSC(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<DwBctdfRvzWsClScUGOppwvgTtr> DBNLceLJjOSJnIoFWvBsUwReOrv;

		public int Count => DBNLceLJjOSJnIoFWvBsUwReOrv.Count;

		public FbCjmhUvrJOrSYCatVKizXQcGbQ()
		{
			DBNLceLJjOSJnIoFWvBsUwReOrv = new List<DwBctdfRvzWsClScUGOppwvgTtr>();
		}

		public void TXPDIkiKZyOgtxZjjNIOUuEOnmW(usaUzIWUmvHGQubVIqmkcOxadgR P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
			for (int i = 0; i < count; i++)
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, kIVvFktUxOgfVeOxEgYguFDLBnB.JlcFwBXJAZQpAvmagfRVInsQEVib))
				{
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].sjbjANsWQaKxKgfHgxDuZgoAatr = P_0.rewiredId;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].khvGMpkRQjhHiSkBkeSsdqkvyhn = P_0.zeSUqHoZRvaBQVdckAscfnsmpBA;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].jWYWoOVkVQeEkPxaNiXliuFIcou = P_0.jWYWoOVkVQeEkPxaNiXliuFIcou;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].kPTxDqHUNQFlgCKgmbPPsQsvVsL = P_0.inputManagerId;
					DBNLceLJjOSJnIoFWvBsUwReOrv[i].UdjAlzHtvuftQNDXVocbITpTczgx = P_0.UdjAlzHtvuftQNDXVocbITpTczgx;
					fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, i);
					return;
				}
			}
			DBNLceLJjOSJnIoFWvBsUwReOrv.Add(new DwBctdfRvzWsClScUGOppwvgTtr
			{
				sjbjANsWQaKxKgfHgxDuZgoAatr = P_0.rewiredId,
				khvGMpkRQjhHiSkBkeSsdqkvyhn = P_0.zeSUqHoZRvaBQVdckAscfnsmpBA,
				jWYWoOVkVQeEkPxaNiXliuFIcou = P_0.jWYWoOVkVQeEkPxaNiXliuFIcou,
				kPTxDqHUNQFlgCKgmbPPsQsvVsL = P_0.inputManagerId,
				UdjAlzHtvuftQNDXVocbITpTczgx = P_0.UdjAlzHtvuftQNDXVocbITpTczgx
			});
			fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1);
		}

		public bool qUMsmxJoDabnMgpnPbuRnplJapZC(usaUzIWUmvHGQubVIqmkcOxadgR P_0, kIVvFktUxOgfVeOxEgYguFDLBnB P_1)
		{
			int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
			for (int i = 0; i < count; i++)
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<DwBctdfRvzWsClScUGOppwvgTtr> SHNHDnJvrVJkCMTxccwUvluFGxE(usaUzIWUmvHGQubVIqmkcOxadgR P_0, kIVvFktUxOgfVeOxEgYguFDLBnB P_1)
		{
			RAUdSLjlApwwnjBSDymohtqJNLSC rAUdSLjlApwwnjBSDymohtqJNLSC = new RAUdSLjlApwwnjBSDymohtqJNLSC(-2);
			rAUdSLjlApwwnjBSDymohtqJNLSC.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			rAUdSLjlApwwnjBSDymohtqJNLSC.UbjxuEellXeMyafFoPliUyZkaWij = P_0;
			rAUdSLjlApwwnjBSDymohtqJNLSC.bHlBJlWzmhLdKSVRZFPkQzpzAEJ = P_1;
			return rAUdSLjlApwwnjBSDymohtqJNLSC;
		}

		public int iFNXApJjlWtDZdwedJFKpfGAMok(DwBctdfRvzWsClScUGOppwvgTtr P_0)
		{
			int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
			for (int i = 0; i < count; i++)
			{
				if (DBNLceLJjOSJnIoFWvBsUwReOrv[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void fgJODZEmUJbPsdCEyOZvWvEmnPm(int P_0, int P_1)
		{
			for (int num = DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && DBNLceLJjOSJnIoFWvBsUwReOrv[num].sjbjANsWQaKxKgfHgxDuZgoAatr == P_0)
				{
					DBNLceLJjOSJnIoFWvBsUwReOrv.RemoveAt(num);
				}
			}
		}
	}

	private List<usaUzIWUmvHGQubVIqmkcOxadgR> kjwFdZmRbOPrZUBwYofYzTFLQnc;

	private int PntfPQsEGteZvXgyoThapnrOHwd;

	private FbCjmhUvrJOrSYCatVKizXQcGbQ zDjgwsHxmQpJhkRGMsAWvoTTUnrS;

	private bool vjxAyPbSJhAqNfkvQzrguHPZorgB;

	private bool fTCpYxKypADBxlCTftYVJniDQbT;

	private UpdateLoopType TShjztsSqTidVVARtigrVGyvDKuC;

	private UpdateLoopType dIVLVjiBzaUXXhmEaWFGUBWNpXY;

	private TimerAbs JwjjvQHAkJBjiBoMorLincXskGw;

	private Action<int, ControllerDataUpdater> oUTSfLSyrhEhRjXHwJZwIeaqWEL;

	private PlatformInputManager ukvfaICvkVuAVKulQnApsyLNAjRD;

	private readonly IUnifiedKeyboardSource yMkNHjZNrRwZZoEuokeSQEuYdRuJ;

	private readonly IUnifiedMouseSource MFqTqeqoqBlQoULhIHVjvByZAFy;

	private bool IQuyfeGhxvGtTKGscrLcFaLIZajG;

	private string[] cVQNNFqvTaTvKOLYgSImIkUcWoh;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => PntfPQsEGteZvXgyoThapnrOHwd;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ukvfaICvkVuAVKulQnApsyLNAjRD;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.Fallback;

	public QemWyoLGGeGnGWjMJDNDbwJbBhZU(UpdateLoopSetting updateLoopSetting)
	{
		ukvfaICvkVuAVKulQnApsyLNAjRD = this;
		yMkNHjZNrRwZZoEuokeSQEuYdRuJ = new UnityUnifiedKeyboardSource();
		MFqTqeqoqBlQoULhIHVjvByZAFy = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			int num = 0;
			if (num < list.Count)
			{
				dIVLVjiBzaUXXhmEaWFGUBWNpXY = list[num];
			}
		}
		cVQNNFqvTaTvKOLYgSImIkUcWoh = new string[0];
		oUTSfLSyrhEhRjXHwJZwIeaqWEL = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
		{
			UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent += yWOuBWuEaQvRLEKOBhknfjdXhWR;
		}
		JwjjvQHAkJBjiBoMorLincXskGw = new TimerAbs(1.0);
		zDjgwsHxmQpJhkRGMsAWvoTTUnrS = new FbCjmhUvrJOrSYCatVKizXQcGbQ();
		yAvsVgTTGDItlDdMcthFKeWXlDf();
		vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		JwjjvQHAkJBjiBoMorLincXskGw.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		TShjztsSqTidVVARtigrVGyvDKuC = updateLoop;
		cLbdMMICxJDSWKifQmiXeSreDQgk();
		if (vjxAyPbSJhAqNfkvQzrguHPZorgB)
		{
			wfYVPLmhaoedujmiFqdMztEymuO();
		}
		XOMSRbIiPeAQLGFCfLGDNIijuZwC(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
		{
			UnityTools.androidFallbackPlatformHelper.DeviceChangedEvent -= yWOuBWuEaQvRLEKOBhknfjdXhWR;
		}
		(yMkNHjZNrRwZZoEuokeSQEuYdRuJ as IDisposable).Dispose();
		(MFqTqeqoqBlQoULhIHVjvByZAFy as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return oUTSfLSyrhEhRjXHwJZwIeaqWEL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i].inputManagerId == assignedControllerId)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void yWOuBWuEaQvRLEKOBhknfjdXhWR()
	{
		vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		fTCpYxKypADBxlCTftYVJniDQbT = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Count; i++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i].unityId == unityJoystickId)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].mpVJEcuqbOftoLfpzcDcyGxDNcp();
			}
		}
		for (int j = 0; j < kjwFdZmRbOPrZUBwYofYzTFLQnc.Count; j++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[j].rewiredId == joystickId)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[j].TIOKahaRuKqflPvBEtjlfNpWlFI(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return MFqTqeqoqBlQoULhIHVjvByZAFy;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return yMkNHjZNrRwZZoEuokeSQEuYdRuJ;
	}

	private void yAvsVgTTGDItlDdMcthFKeWXlDf()
	{
		yAvsVgTTGDItlDdMcthFKeWXlDf(Input.GetJoystickNames());
	}

	private void yAvsVgTTGDItlDdMcthFKeWXlDf(string[] P_0)
	{
		int num = 0;
		List<usaUzIWUmvHGQubVIqmkcOxadgR> list = kjwFdZmRbOPrZUBwYofYzTFLQnc;
		int pntfPQsEGteZvXgyoThapnrOHwd = PntfPQsEGteZvXgyoThapnrOHwd;
		kjwFdZmRbOPrZUBwYofYzTFLQnc = new List<usaUzIWUmvHGQubVIqmkcOxadgR>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR2 = new usaUzIWUmvHGQubVIqmkcOxadgR();
				usaUzIWUmvHGQubVIqmkcOxadgR2.zeSUqHoZRvaBQVdckAscfnsmpBA = text;
				usaUzIWUmvHGQubVIqmkcOxadgR2.YdteeZaQmIaNannwKqGOnKaYbypx = text;
				usaUzIWUmvHGQubVIqmkcOxadgR2.jWYWoOVkVQeEkPxaNiXliuFIcou = i;
				usaUzIWUmvHGQubVIqmkcOxadgR2.unityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.androidFallbackPlatformHelper != null)
				{
					usaUzIWUmvHGQubVIqmkcOxadgR2.UdjAlzHtvuftQNDXVocbITpTczgx = UnityTools.androidFallbackPlatformHelper.GetUniqueDeviceIdentifier(text, i);
				}
				usaUzIWUmvHGQubVIqmkcOxadgR2.KfBKHnOxjftuCpCkJBMbkWxcLWv();
				kjwFdZmRbOPrZUBwYofYzTFLQnc.Add(usaUzIWUmvHGQubVIqmkcOxadgR2);
				num++;
			}
		}
		PntfPQsEGteZvXgyoThapnrOHwd = num;
		uayRUeBwFfgScjCqOBsLgfFLjQBi(pntfPQsEGteZvXgyoThapnrOHwd, num, list, kjwFdZmRbOPrZUBwYofYzTFLQnc);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(kjwFdZmRbOPrZUBwYofYzTFLQnc[j]));
			}
		}
		dvtoafoBVFcqUHDKsKmzitILBloS(list, kjwFdZmRbOPrZUBwYofYzTFLQnc, false);
		dvtoafoBVFcqUHDKsKmzitILBloS(kjwFdZmRbOPrZUBwYofYzTFLQnc, list, true);
		cVQNNFqvTaTvKOLYgSImIkUcWoh = P_0;
	}

	private void XOMSRbIiPeAQLGFCfLGDNIijuZwC(UpdateLoopType P_0)
	{
		int count = kjwFdZmRbOPrZUBwYofYzTFLQnc.Count;
		for (int i = 0; i < count; i++)
		{
			if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i] != null)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].Update();
			}
		}
	}

	private void uayRUeBwFfgScjCqOBsLgfFLjQBi(int P_0, int P_1, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_2, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(usaUzIWUmvHGQubVIqmkcOxadgR.AbMgSvAHikioAQPYCMbaLAHsHra);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB.JlcFwBXJAZQpAvmagfRVInsQEVib);
			uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB.lkctGikYsLMhbYMEyImPMsrGWJw);
		}
		wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB.JlcFwBXJAZQpAvmagfRVInsQEVib);
		wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB.lkctGikYsLMhbYMEyImPMsrGWJw);
		for (int i = 0; i < P_1; i++)
		{
			usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR2 = P_3[i];
			if (usaUzIWUmvHGQubVIqmkcOxadgR2 != null && usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId < 0)
			{
				usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId = XsOsVyBtTACNZvhKSCqKhJNcObX(P_3);
				usaUzIWUmvHGQubVIqmkcOxadgR2.rewiredId = ReInput.GetNewJoystickId();
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(usaUzIWUmvHGQubVIqmkcOxadgR2);
			}
		}
		P_3.Sort(usaUzIWUmvHGQubVIqmkcOxadgR.CFEFaonWGdGHmSbxFpVUdBbnEVrf);
	}

	private void ZYHxGNylvgpiiDGzmFDnBqagypH(List<usaUzIWUmvHGQubVIqmkcOxadgR> P_0, int P_1, int P_2)
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

	private bool BHoDIxSSroZRExzlHLxMWTglSdB(List<usaUzIWUmvHGQubVIqmkcOxadgR> P_0, int P_1)
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

	private int XsOsVyBtTACNZvhKSCqKhJNcObX(List<usaUzIWUmvHGQubVIqmkcOxadgR> P_0)
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

	private bool TDbfjHTAtTEdVDROIPjYUelzQmc(List<usaUzIWUmvHGQubVIqmkcOxadgR> P_0, int P_1)
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

	private void uvyHsbansrbOEFMvTGIzNDuVqFhl(int P_0, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_1, int P_2, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_3, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB P_4)
	{
		int num = ((P_4 != FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB.JlcFwBXJAZQpAvmagfRVInsQEVib) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR2 = P_1[i];
			if (usaUzIWUmvHGQubVIqmkcOxadgR2 == null || usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR3 = P_3[j];
				if (usaUzIWUmvHGQubVIqmkcOxadgR3 != null && !TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, usaUzIWUmvHGQubVIqmkcOxadgR3.rewiredId) && usaUzIWUmvHGQubVIqmkcOxadgR2.kGUAgzoWmpBJnomvNrYAMpbELMU(usaUzIWUmvHGQubVIqmkcOxadgR3) >= num)
				{
					usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId = usaUzIWUmvHGQubVIqmkcOxadgR3.inputManagerId;
					usaUzIWUmvHGQubVIqmkcOxadgR2.rewiredId = usaUzIWUmvHGQubVIqmkcOxadgR3.rewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						usaUzIWUmvHGQubVIqmkcOxadgR2.unityId = usaUzIWUmvHGQubVIqmkcOxadgR3.unityId;
					}
					zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(usaUzIWUmvHGQubVIqmkcOxadgR2);
				}
			}
		}
	}

	private void wPaQeUOLsWCfDaRkoDbzlEsIIQc(int P_0, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_1, FbCjmhUvrJOrSYCatVKizXQcGbQ.kIVvFktUxOgfVeOxEgYguFDLBnB P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR2 = P_1[i];
			if (usaUzIWUmvHGQubVIqmkcOxadgR2 == null || usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId >= 0)
			{
				continue;
			}
			FbCjmhUvrJOrSYCatVKizXQcGbQ.DwBctdfRvzWsClScUGOppwvgTtr dwBctdfRvzWsClScUGOppwvgTtr = null;
			foreach (FbCjmhUvrJOrSYCatVKizXQcGbQ.DwBctdfRvzWsClScUGOppwvgTtr item in zDjgwsHxmQpJhkRGMsAWvoTTUnrS.SHNHDnJvrVJkCMTxccwUvluFGxE(usaUzIWUmvHGQubVIqmkcOxadgR2, P_2))
			{
				if (!TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, item.sjbjANsWQaKxKgfHgxDuZgoAatr) && item.kPTxDqHUNQFlgCKgmbPPsQsvVsL >= 0)
				{
					dwBctdfRvzWsClScUGOppwvgTtr = item;
					break;
				}
			}
			if (dwBctdfRvzWsClScUGOppwvgTtr != null)
			{
				int num = dwBctdfRvzWsClScUGOppwvgTtr.kPTxDqHUNQFlgCKgmbPPsQsvVsL;
				if (!BHoDIxSSroZRExzlHLxMWTglSdB(P_1, num))
				{
					num = (dwBctdfRvzWsClScUGOppwvgTtr.kPTxDqHUNQFlgCKgmbPPsQsvVsL = XsOsVyBtTACNZvhKSCqKhJNcObX(P_1));
				}
				usaUzIWUmvHGQubVIqmkcOxadgR2.inputManagerId = num;
				usaUzIWUmvHGQubVIqmkcOxadgR2.rewiredId = dwBctdfRvzWsClScUGOppwvgTtr.sjbjANsWQaKxKgfHgxDuZgoAatr;
				zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(usaUzIWUmvHGQubVIqmkcOxadgR2);
			}
		}
	}

	private void wfYVPLmhaoedujmiFqdMztEymuO()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (fTCpYxKypADBxlCTftYVJniDQbT || RlkwRQpOLQQDoeMFZRsoshUnDQsD(joystickNames))
		{
			yAvsVgTTGDItlDdMcthFKeWXlDf(joystickNames);
		}
		vjxAyPbSJhAqNfkvQzrguHPZorgB = false;
		if (fTCpYxKypADBxlCTftYVJniDQbT)
		{
			fTCpYxKypADBxlCTftYVJniDQbT = false;
		}
	}

	private bool RlkwRQpOLQQDoeMFZRsoshUnDQsD(string[] P_0)
	{
		if (P_0.Length != cVQNNFqvTaTvKOLYgSImIkUcWoh.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], cVQNNFqvTaTvKOLYgSImIkUcWoh[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void dvtoafoBVFcqUHDKsKmzitILBloS(List<usaUzIWUmvHGQubVIqmkcOxadgR> P_0, List<usaUzIWUmvHGQubVIqmkcOxadgR> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR2 = P_0[i];
			if (usaUzIWUmvHGQubVIqmkcOxadgR2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					usaUzIWUmvHGQubVIqmkcOxadgR usaUzIWUmvHGQubVIqmkcOxadgR3 = P_1[j];
					if (usaUzIWUmvHGQubVIqmkcOxadgR3 != null && usaUzIWUmvHGQubVIqmkcOxadgR2.rewiredId == usaUzIWUmvHGQubVIqmkcOxadgR3.rewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				FyZjHIebzTuXOypeVTeqTYZyKta(P_0[i], P_2);
			}
		}
	}

	private void FyZjHIebzTuXOypeVTeqTYZyKta(usaUzIWUmvHGQubVIqmkcOxadgR P_0, bool P_1)
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

	private void cLbdMMICxJDSWKifQmiXeSreDQgk()
	{
		if (TShjztsSqTidVVARtigrVGyvDKuC == dIVLVjiBzaUXXhmEaWFGUBWNpXY && JwjjvQHAkJBjiBoMorLincXskGw.Update())
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
			JwjjvQHAkJBjiBoMorLincXskGw.Start();
		}
	}
}
