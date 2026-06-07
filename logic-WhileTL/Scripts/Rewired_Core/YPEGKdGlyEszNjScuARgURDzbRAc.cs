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

internal class YPEGKdGlyEszNjScuARgURDzbRAc : PlatformInputManager
{
	private class LZffdTmeAXWDSIRgGRDMdlZPpzyP : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int jnTUNQIkgqcKCiEAwbMZLHIeGqRG;

		private int wyitjeizprUCYMqORpWhWzygUUjQ;

		private int kQhTCblAYSuvmyinRJJGwAKFBIfj;

		public Guid nOQoHZoiWPrSFIsmqagvEKvWBGDT;

		public string QUFMelDfJaUFXAbyxaVAmqwGjofN;

		public int tSyZyaCrqwhsLmcgyErbUEHKZucs;

		public string rTchmpjdeNRfricdByXcoHrqvrWY;

		public string ELZDDcOYYkixojZiclpBbfXZzkcA;

		private int jhazYdoXweuxJmcAJnlflvXbFGyT = 29;

		private int yrHZhNoSpLMEzcgptuOphbaHHcuiA = 20;

		private float[] rODUhFvDvuNqUagvIByzDzydddPVA;

		private bool[] JspBooWrPbsrHYagyhvvwXCFhuHz;

		private bool[] jJQnkFHKoDNinpNsLAgFFnseqnmNA;

		private float[] mtEghmeLEhbfRqCbpKiuyyXCVmuI;

		private bool[] LehvFKORBOfpiwoWSKsWpyRdptdC;

		private HardwareJoystickMap_InputManager jnGTQDFeNsixRwgRJcghDqCbQWSP;

		private bool pfESQMflewZfzKfYXhoSMGpQFgFkA;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return jnTUNQIkgqcKCiEAwbMZLHIeGqRG;
			}
			set
			{
				jnTUNQIkgqcKCiEAwbMZLHIeGqRG = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return wyitjeizprUCYMqORpWhWzygUUjQ;
			}
			set
			{
				wyitjeizprUCYMqORpWhWzygUUjQ = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (!(QUFMelDfJaUFXAbyxaVAmqwGjofN != "Unknown Controller"))
				{
					return rTchmpjdeNRfricdByXcoHrqvrWY;
				}
				return QUFMelDfJaUFXAbyxaVAmqwGjofN;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (kQhTCblAYSuvmyinRJJGwAKFBIfj < 1)
				{
					return null;
				}
				return kQhTCblAYSuvmyinRJJGwAKFBIfj;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return kQhTCblAYSuvmyinRJJGwAKFBIfj;
			}
			set
			{
				kQhTCblAYSuvmyinRJJGwAKFBIfj = value;
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
					return MiscTools.CreateGuidHashSHA1(rTchmpjdeNRfricdByXcoHrqvrWY);
				}
				return MiscTools.CreateGuidHashSHA1(name + "_" + kQhTCblAYSuvmyinRJJGwAKFBIfj);
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

		public LZffdTmeAXWDSIRgGRDMdlZPpzyP()
		{
			wyitjeizprUCYMqORpWhWzygUUjQ = -1;
			jnTUNQIkgqcKCiEAwbMZLHIeGqRG = -1;
			kQhTCblAYSuvmyinRJJGwAKFBIfj = 0;
		}

		public void MlxxoBHQWLcsxCtqgDqxENlqGClK()
		{
			fyKHXiGInVfATQTtqFcElaiTdiLdA();
			nOQoHZoiWPrSFIsmqagvEKvWBGDT = jnGTQDFeNsixRwgRJcghDqCbQWSP.hardwareMapIdentifier.guid;
			QUFMelDfJaUFXAbyxaVAmqwGjofN = jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName;
			rODUhFvDvuNqUagvIByzDzydddPVA = new float[jhazYdoXweuxJmcAJnlflvXbFGyT];
			JspBooWrPbsrHYagyhvvwXCFhuHz = new bool[yrHZhNoSpLMEzcgptuOphbaHHcuiA];
			jJQnkFHKoDNinpNsLAgFFnseqnmNA = new bool[jhazYdoXweuxJmcAJnlflvXbFGyT];
			LehvFKORBOfpiwoWSKsWpyRdptdC = new bool[29];
			mtEghmeLEhbfRqCbpKiuyyXCVmuI = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (kQhTCblAYSuvmyinRJJGwAKFBIfj > 0)
			{
				CcoGvckwyGkpfZgPgpLkPAfEWrel();
				sMDjzCJDeBvhrbyByBjiYGZTdvid();
				NmpnNBiKKVbSAuwNMDZPPwvGzdji();
			}
		}

		public int eRcrgXtiJZnEILPhcaiUyTnAFTCn(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0)
		{
			if ((!string.IsNullOrEmpty(ELZDDcOYYkixojZiclpBbfXZzkcA) || !string.IsNullOrEmpty(P_0.ELZDDcOYYkixojZiclpBbfXZzkcA)) && !string.Equals(ELZDDcOYYkixojZiclpBbfXZzkcA, P_0.ELZDDcOYYkixojZiclpBbfXZzkcA, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.rTchmpjdeNRfricdByXcoHrqvrWY == rTchmpjdeNRfricdByXcoHrqvrWY && P_0.tSyZyaCrqwhsLmcgyErbUEHKZucs == tSyZyaCrqwhsLmcgyErbUEHKZucs)
			{
				return 2;
			}
			if (P_0.rTchmpjdeNRfricdByXcoHrqvrWY == rTchmpjdeNRfricdByXcoHrqvrWY)
			{
				return 1;
			}
			return 0;
		}

		private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = nEVkZLGeGncLLgmFTQIdiggxOdgXA();
			P_0.hardwareIdentifier = bCDcrddrcACOMFQMHyZkZRleWBKYA();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = rTchmpjdeNRfricdByXcoHrqvrWY;
		}

		private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedController P_0)
		{
			KonGcavNUOwjzblUmOrIFvgYlQaM((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = jnGTQDFeNsixRwgRJcghDqCbQWSP.ToGameHardwareControllerMap();
			P_0.instanceName = rTchmpjdeNRfricdByXcoHrqvrWY;
			P_0.productName = rTchmpjdeNRfricdByXcoHrqvrWY;
			P_0.isXInputDevice = false;
			P_0.axisCount = jhazYdoXweuxJmcAJnlflvXbFGyT;
			P_0.buttonCount = yrHZhNoSpLMEzcgptuOphbaHHcuiA;
			P_0.controllerTypeGuid = nOQoHZoiWPrSFIsmqagvEKvWBGDT;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (jhazYdoXweuxJmcAJnlflvXbFGyT != dataUpdater.axisCount || yrHZhNoSpLMEzcgptuOphbaHHcuiA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < jhazYdoXweuxJmcAJnlflvXbFGyT; i++)
			{
				if (axisValues[i] != rODUhFvDvuNqUagvIByzDzydddPVA[i])
				{
					axisValues[i] = rODUhFvDvuNqUagvIByzDzydddPVA[i];
					if (axisHasBeenPressedOSXLinux[i] != jJQnkFHKoDNinpNsLAgFFnseqnmNA[i])
					{
						axisHasBeenPressedOSXLinux[i] = jJQnkFHKoDNinpNsLAgFFnseqnmNA[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < yrHZhNoSpLMEzcgptuOphbaHHcuiA; j++)
			{
				if (buttonValues[j] != JspBooWrPbsrHYagyhvvwXCFhuHz[j])
				{
					buttonValues[j] = JspBooWrPbsrHYagyhvvwXCFhuHz[j];
				}
			}
			if (pfESQMflewZfzKfYXhoSMGpQFgFkA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public void HfiIOHxPJyoTWueFtupxNudQLZCI(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				unityId = P_0;
			}
		}

		public void cffeHOxsEoykPialCEImCAbXiqtGA()
		{
			kQhTCblAYSuvmyinRJJGwAKFBIfj = 0;
			ZbLJlCPrDufAoCXeGXMcwORfZBsBA();
		}

		public BridgedControllerHWInfo dRJFQxxbJtbamMAsWxKyOgWwHrhW()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			KonGcavNUOwjzblUmOrIFvgYlQaM(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			KonGcavNUOwjzblUmOrIFvgYlQaM(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(jnTUNQIkgqcKCiEAwbMZLHIeGqRG);
		}

		private void CcoGvckwyGkpfZgPgpLkPAfEWrel()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(kQhTCblAYSuvmyinRJJGwAKFBIfj, i);
				if (mtEghmeLEhbfRqCbpKiuyyXCVmuI[i] != joystickAxisValueByJoystickId)
				{
					mtEghmeLEhbfRqCbpKiuyyXCVmuI[i] = joystickAxisValueByJoystickId;
					if (!LehvFKORBOfpiwoWSKsWpyRdptdC[i] && joystickAxisValueByJoystickId != 0f)
					{
						LehvFKORBOfpiwoWSKsWpyRdptdC[i] = true;
					}
				}
			}
		}

		private void sMDjzCJDeBvhrbyByBjiYGZTdvid()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Axes_orig;
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
				if (i >= jhazYdoXweuxJmcAJnlflvXbFGyT)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(axes_orig[i]);
				if (rODUhFvDvuNqUagvIByzDzydddPVA[i] == num)
				{
					continue;
				}
				rODUhFvDvuNqUagvIByzDzydddPVA[i] = num;
				if (!jJQnkFHKoDNinpNsLAgFFnseqnmNA[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(axes_orig[i].sourceAxis);
						jJQnkFHKoDNinpNsLAgFFnseqnmNA[i] = num2 != 0f;
					}
					else
					{
						jJQnkFHKoDNinpNsLAgFFnseqnmNA[i] = true;
					}
				}
				if (!pfESQMflewZfzKfYXhoSMGpQFgFkA && rODUhFvDvuNqUagvIByzDzydddPVA[i] != 0f)
				{
					pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
				}
			}
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= yrHZhNoSpLMEzcgptuOphbaHHcuiA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = QJBSSzPioDBMmqZkZEFzajPlEHwp(buttons_orig[i]);
				if (JspBooWrPbsrHYagyhvvwXCFhuHz[i] != flag)
				{
					JspBooWrPbsrHYagyhvvwXCFhuHz[i] = flag;
					if (!pfESQMflewZfzKfYXhoSMGpQFgFkA && JspBooWrPbsrHYagyhvvwXCFhuHz[i])
					{
						pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
					}
				}
			}
		}

		private bool QJBSSzPioDBMmqZkZEFzajPlEHwp(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.requiredButtons[j]))
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
				return QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0.sourceAxis);
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
				float num2 = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(unityHat_sourceAxis);
				float num3 = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (XWjRZSAqyRATqlmvzHWSIPSPRjum(unityHat_sourceAxis) || XWjRZSAqyRATqlmvzHWSIPSPRjum(unityHat_sourceAxis2))
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
				if (hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues1.x, num2) && hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues2.x, num2) && hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues3.x, num2) && hXBsbZHpUaIMKWjuSUkZhaLQekTj(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (PCMrHcHciUhSqPJnXsOGsVUYdBXs(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (qYPZbrsODeeMgKpVqMKTgUgEqEuYA(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (RWCKXFbEMqWKdXJjpvjUFAiwDVOaA(customCalculationSourceData[k], out var flag2))
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

		private bool hXBsbZHpUaIMKWjuSUkZhaLQekTj(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!XWjRZSAqyRATqlmvzHWSIPSPRjum(P_0.sourceAxis))
				{
					return 0f;
				}
				return oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && qYPZbrsODeeMgKpVqMKTgUgEqEuYA(customCalculationSourceData[i], out var item))
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

		private float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return mtEghmeLEhbfRqCbpKiuyyXCVmuI[num];
		}

		private bool QJBSSzPioDBMmqZkZEFzajPlEHwp(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(kQhTCblAYSuvmyinRJJGwAKFBIfj, buttonIndex);
		}

		private bool PCMrHcHciUhSqPJnXsOGsVUYdBXs(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = QJBSSzPioDBMmqZkZEFzajPlEHwp(sourceElement);
			return true;
		}

		private bool RWCKXFbEMqWKdXJjpvjUFAiwDVOaA(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool qYPZbrsODeeMgKpVqMKTgUgEqEuYA(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(sourceElement);
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

		private bool XWjRZSAqyRATqlmvzHWSIPSPRjum(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return LehvFKORBOfpiwoWSKsWpyRdptdC[num];
		}

		private void fyKHXiGInVfATQTtqFcElaiTdiLdA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = dRJFQxxbJtbamMAsWxKyOgWwHrhW();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(rTchmpjdeNRfricdByXcoHrqvrWY, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(rTchmpjdeNRfricdByXcoHrqvrWY))
					{
						if (ds4Helper.IsDS4KeyMapped(tSyZyaCrqwhsLmcgyErbUEHKZucs))
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
			jnGTQDFeNsixRwgRJcghDqCbQWSP = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP.useSystemName && !string.IsNullOrEmpty(rTchmpjdeNRfricdByXcoHrqvrWY))
			{
				string text = Regex.Replace(rTchmpjdeNRfricdByXcoHrqvrWY, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName = text;
				}
			}
			if (UnityTools.isIOSPlatform && jnGTQDFeNsixRwgRJcghDqCbQWSP.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text2 = exDHcpJwBlHjBSfvuHkkRIweGJtw(rTchmpjdeNRfricdByXcoHrqvrWY);
				if (!string.IsNullOrEmpty(text2))
				{
					jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName = text2;
				}
			}
			jhazYdoXweuxJmcAJnlflvXbFGyT = jnGTQDFeNsixRwgRJcghDqCbQWSP.axisCount;
			yrHZhNoSpLMEzcgptuOphbaHHcuiA = jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonCount;
		}

		private void ZbLJlCPrDufAoCXeGXMcwORfZBsBA()
		{
			Array.Clear(JspBooWrPbsrHYagyhvvwXCFhuHz, 0, JspBooWrPbsrHYagyhvvwXCFhuHz.Length);
			Array.Clear(rODUhFvDvuNqUagvIByzDzydddPVA, 0, rODUhFvDvuNqUagvIByzDzydddPVA.Length);
		}

		private string bCDcrddrcACOMFQMHyZkZRleWBKYA()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{nEVkZLGeGncLLgmFTQIdiggxOdgXA().ToString()}{rTchmpjdeNRfricdByXcoHrqvrWY}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(rTchmpjdeNRfricdByXcoHrqvrWY, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{nEVkZLGeGncLLgmFTQIdiggxOdgXA().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{nEVkZLGeGncLLgmFTQIdiggxOdgXA().ToString()}{rTchmpjdeNRfricdByXcoHrqvrWY}");
		}

		private InputSource nEVkZLGeGncLLgmFTQIdiggxOdgXA()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(rTchmpjdeNRfricdByXcoHrqvrWY))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int MOuKBWibvJbSJxUfatGKZFlrmTlW(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, LZffdTmeAXWDSIRgGRDMdlZPpzyP P_1)
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

		public static int AOqDETERVUclbxpOxfFoZvRcjryqA(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, LZffdTmeAXWDSIRgGRDMdlZPpzyP P_1)
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

		private static string exDHcpJwBlHjBSfvuHkkRIweGJtw(string P_0)
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

	private class SZyjuaaEUcVUhchZtnBIJIUKfQpbA
	{
		public enum czvlRokeiiWZYVdQVNbKudDsjQOR
		{
			Exact = 0,
			Approximate = 1
		}

		public class rXPXhIqjMZmKRIGBJYXZiqPMROri
		{
			public int wKTIDzdbnMqFnJlBBeomtbaWsxjR;

			public int tSyZyaCrqwhsLmcgyErbUEHKZucs;

			public string oGNaWLprhBUnPveHBZCyLCclilfn;

			public int czjrOWhmqBwDdneXNALtIaxNwVzA;

			public string ELZDDcOYYkixojZiclpBbfXZzkcA;

			public bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, czvlRokeiiWZYVdQVNbKudDsjQOR P_1)
			{
				if (P_0.rewiredId == wKTIDzdbnMqFnJlBBeomtbaWsxjR)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(ELZDDcOYYkixojZiclpBbfXZzkcA) || !string.IsNullOrEmpty(P_0.ELZDDcOYYkixojZiclpBbfXZzkcA)) && !string.Equals(ELZDDcOYYkixojZiclpBbfXZzkcA, P_0.ELZDDcOYYkixojZiclpBbfXZzkcA, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case czvlRokeiiWZYVdQVNbKudDsjQOR.Exact:
					if (tSyZyaCrqwhsLmcgyErbUEHKZucs == P_0.tSyZyaCrqwhsLmcgyErbUEHKZucs)
					{
						return oGNaWLprhBUnPveHBZCyLCclilfn == P_0.rTchmpjdeNRfricdByXcoHrqvrWY;
					}
					return false;
				case czvlRokeiiWZYVdQVNbKudDsjQOR.Approximate:
					return oGNaWLprhBUnPveHBZCyLCclilfn == P_0.rTchmpjdeNRfricdByXcoHrqvrWY;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class obdbkiaSCMhsGYFJAecTaEhGLjmoc : IDisposable, IEnumerable<rXPXhIqjMZmKRIGBJYXZiqPMROri>, IEnumerator<rXPXhIqjMZmKRIGBJYXZiqPMROri>, IEnumerable, IEnumerator
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private rXPXhIqjMZmKRIGBJYXZiqPMROri USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public SZyjuaaEUcVUhchZtnBIJIUKfQpbA GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private LZffdTmeAXWDSIRgGRDMdlZPpzyP sgVxbuDAuevAQEggkQAcSuZkVnGc;

			public LZffdTmeAXWDSIRgGRDMdlZPpzyP USZMaIxQjfLLMAXcFwImGLBkIAsG;

			private czvlRokeiiWZYVdQVNbKudDsjQOR NkWUjerweacIBvSdmEmpoCzRdbtX;

			public czvlRokeiiWZYVdQVNbKudDsjQOR pMHTdFHYEXVSjtXRwCWwwczjKiTJ;

			private int XoXSDiftyvAwyAXRnHGdMRIPCNdGA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			rXPXhIqjMZmKRIGBJYXZiqPMROri IEnumerator<rXPXhIqjMZmKRIGBJYXZiqPMROri>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public obdbkiaSCMhsGYFJAecTaEhGLjmoc(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
				nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				SZyjuaaEUcVUhchZtnBIJIUKfQpbA gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_0083;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				XoXSDiftyvAwyAXRnHGdMRIPCNdGA = gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA.Count;
				eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
				goto IL_0093;
				IL_0083:
				eolRghqutZOOIGqvOFTzJOGfYTsn++;
				goto IL_0093;
				IL_0093:
				if (eolRghqutZOOIGqvOFTzJOGfYTsn < XoXSDiftyvAwyAXRnHGdMRIPCNdGA)
				{
					if (gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA[eolRghqutZOOIGqvOFTzJOGfYTsn].eRcrgXtiJZnEILPhcaiUyTnAFTCn(sgVxbuDAuevAQEggkQAcSuZkVnGc, NkWUjerweacIBvSdmEmpoCzRdbtX))
					{
						USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA[eolRghqutZOOIGqvOFTzJOGfYTsn];
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
			IEnumerator<rXPXhIqjMZmKRIGBJYXZiqPMROri> IEnumerable<rXPXhIqjMZmKRIGBJYXZiqPMROri>.GetEnumerator()
			{
				obdbkiaSCMhsGYFJAecTaEhGLjmoc obdbkiaSCMhsGYFJAecTaEhGLjmoc2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					obdbkiaSCMhsGYFJAecTaEhGLjmoc2 = this;
				}
				else
				{
					obdbkiaSCMhsGYFJAecTaEhGLjmoc2 = new obdbkiaSCMhsGYFJAecTaEhGLjmoc(0);
					obdbkiaSCMhsGYFJAecTaEhGLjmoc2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				obdbkiaSCMhsGYFJAecTaEhGLjmoc2.sgVxbuDAuevAQEggkQAcSuZkVnGc = USZMaIxQjfLLMAXcFwImGLBkIAsG;
				obdbkiaSCMhsGYFJAecTaEhGLjmoc2.NkWUjerweacIBvSdmEmpoCzRdbtX = pMHTdFHYEXVSjtXRwCWwwczjKiTJ;
				return obdbkiaSCMhsGYFJAecTaEhGLjmoc2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<rXPXhIqjMZmKRIGBJYXZiqPMROri>)this).GetEnumerator();
			}
		}

		private List<rXPXhIqjMZmKRIGBJYXZiqPMROri> LztWhAIbukRXonlavhcowoysBOjjA;

		public int mueqHgIkLYeeWIkgOmnbTNFVJkWJ => LztWhAIbukRXonlavhcowoysBOjjA.Count;

		public SZyjuaaEUcVUhchZtnBIJIUKfQpbA()
		{
			LztWhAIbukRXonlavhcowoysBOjjA = new List<rXPXhIqjMZmKRIGBJYXZiqPMROri>();
		}

		public void XwxmMWfpySNSMASbMCDIaCKEBrGP(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
			for (int i = 0; i < count; i++)
			{
				if (LztWhAIbukRXonlavhcowoysBOjjA[i].eRcrgXtiJZnEILPhcaiUyTnAFTCn(P_0, czvlRokeiiWZYVdQVNbKudDsjQOR.Exact))
				{
					LztWhAIbukRXonlavhcowoysBOjjA[i].wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0.rewiredId;
					LztWhAIbukRXonlavhcowoysBOjjA[i].oGNaWLprhBUnPveHBZCyLCclilfn = P_0.rTchmpjdeNRfricdByXcoHrqvrWY;
					LztWhAIbukRXonlavhcowoysBOjjA[i].tSyZyaCrqwhsLmcgyErbUEHKZucs = P_0.tSyZyaCrqwhsLmcgyErbUEHKZucs;
					LztWhAIbukRXonlavhcowoysBOjjA[i].czjrOWhmqBwDdneXNALtIaxNwVzA = P_0.inputManagerId;
					LztWhAIbukRXonlavhcowoysBOjjA[i].ELZDDcOYYkixojZiclpBbfXZzkcA = P_0.ELZDDcOYYkixojZiclpBbfXZzkcA;
					nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, i);
					return;
				}
			}
			LztWhAIbukRXonlavhcowoysBOjjA.Add(new rXPXhIqjMZmKRIGBJYXZiqPMROri
			{
				wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0.rewiredId,
				oGNaWLprhBUnPveHBZCyLCclilfn = P_0.rTchmpjdeNRfricdByXcoHrqvrWY,
				tSyZyaCrqwhsLmcgyErbUEHKZucs = P_0.tSyZyaCrqwhsLmcgyErbUEHKZucs,
				czjrOWhmqBwDdneXNALtIaxNwVzA = P_0.inputManagerId,
				ELZDDcOYYkixojZiclpBbfXZzkcA = P_0.ELZDDcOYYkixojZiclpBbfXZzkcA
			});
			nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, LztWhAIbukRXonlavhcowoysBOjjA.Count - 1);
		}

		public bool kUiCmZCewQfczGBdspnXBabLzrLy(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, czvlRokeiiWZYVdQVNbKudDsjQOR P_1)
		{
			int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
			for (int i = 0; i < count; i++)
			{
				if (LztWhAIbukRXonlavhcowoysBOjjA[i].eRcrgXtiJZnEILPhcaiUyTnAFTCn(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<rXPXhIqjMZmKRIGBJYXZiqPMROri> EIllDHQFSlaxtdIhRTpOBXaXOnOQ(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, czvlRokeiiWZYVdQVNbKudDsjQOR P_1)
		{
			return new obdbkiaSCMhsGYFJAecTaEhGLjmoc(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				USZMaIxQjfLLMAXcFwImGLBkIAsG = P_0,
				pMHTdFHYEXVSjtXRwCWwwczjKiTJ = P_1
			};
		}

		public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(rXPXhIqjMZmKRIGBJYXZiqPMROri P_0)
		{
			int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
			for (int i = 0; i < count; i++)
			{
				if (LztWhAIbukRXonlavhcowoysBOjjA[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void nPpArpXwftSAPCgODdQhbwKgoHcvA(int P_0, int P_1)
		{
			for (int num = LztWhAIbukRXonlavhcowoysBOjjA.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && LztWhAIbukRXonlavhcowoysBOjjA[num].wKTIDzdbnMqFnJlBBeomtbaWsxjR == P_0)
				{
					LztWhAIbukRXonlavhcowoysBOjjA.RemoveAt(num);
				}
			}
		}
	}

	private List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> elKJbbxESyfcuzfcxFoUDTJZIhcJA;

	private int NcFhTqaznBUbORimVwWyLExKyNzx;

	private SZyjuaaEUcVUhchZtnBIJIUKfQpbA boNSEKuFFoQzYuEJbTHAMBvFjgjG;

	private bool vOBKVnebkBpKgLMbliSkdvNFpdei;

	private bool lEcAaLZsMqRMMUTDCMHZptaJAxDq;

	private UpdateLoopType HvFDPHvQHhAdkasJMjRxfxqlAkaF;

	private UpdateLoopType xflYdbhzwYnRoAywPqTPypXPlhFn;

	private TimerAbs HcPoHgGlLjDuNqHGNAOgiXFgBYmPA;

	private Action<int, ControllerDataUpdater> aZjUoBTvFJqBWAfFXmCRkuewLIOx;

	private PlatformInputManager gfTEZguFOlDAmDChxHFfMUBZrqTl;

	private readonly IUnifiedKeyboardSource cCMBjLQdMhYKuXiyPflWBugIUTcqA;

	private readonly IUnifiedMouseSource COQGjUtTWxBMXhxTrGrlDolXBdye;

	private bool GATiUDPEXgsktbcJYtwWfNQkgnL;

	private string[] oaiElnKvSOuKbUxHZFZkswgybYlvA;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => NcFhTqaznBUbORimVwWyLExKyNzx;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => gfTEZguFOlDAmDChxHFfMUBZrqTl;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.Fallback;

	public YPEGKdGlyEszNjScuARgURDzbRAc(UpdateLoopSetting P_0)
	{
		gfTEZguFOlDAmDChxHFfMUBZrqTl = this;
		cCMBjLQdMhYKuXiyPflWBugIUTcqA = new UnityUnifiedKeyboardSource();
		COQGjUtTWxBMXhxTrGrlDolXBdye = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				xflYdbhzwYnRoAywPqTPypXPlhFn = list[num];
			}
		}
		oaiElnKvSOuKbUxHZFZkswgybYlvA = new string[0];
		aZjUoBTvFJqBWAfFXmCRkuewLIOx = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH != null)
		{
			UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH.DeviceChangedEvent += qbkcSkAjPufewvzGawuduVjHJQPKA;
		}
		HcPoHgGlLjDuNqHGNAOgiXFgBYmPA = new TimerAbs(1.0);
		boNSEKuFFoQzYuEJbTHAMBvFjgjG = new SZyjuaaEUcVUhchZtnBIJIUKfQpbA();
		arLxlEYGvjkvWuzMDsSNwJKRPbbl();
		vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		HcPoHgGlLjDuNqHGNAOgiXFgBYmPA.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		HvFDPHvQHhAdkasJMjRxfxqlAkaF = updateLoop;
		yDVekoZdYfNldNijdpdXsQfRAhyL();
		if (vOBKVnebkBpKgLMbliSkdvNFpdei)
		{
			alayrrvNCSZbAOTuonjpHkvoUumW();
		}
		DzgjBVFcaWDogqCKSBeRqdglJPai(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH != null)
		{
			UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH.DeviceChangedEvent -= qbkcSkAjPufewvzGawuduVjHJQPKA;
		}
		(cCMBjLQdMhYKuXiyPflWBugIUTcqA as IDisposable).Dispose();
		(COQGjUtTWxBMXhxTrGrlDolXBdye as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return aZjUoBTvFJqBWAfFXmCRkuewLIOx;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].inputManagerId == assignedControllerId)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void qbkcSkAjPufewvzGawuduVjHJQPKA()
	{
		vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		lEcAaLZsMqRMMUTDCMHZptaJAxDq = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count; i++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].unityId == unityJoystickId)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].cffeHOxsEoykPialCEImCAbXiqtGA();
			}
		}
		for (int j = 0; j < elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count; j++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[j].rewiredId == joystickId)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[j].HfiIOHxPJyoTWueFtupxNudQLZCI(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return COQGjUtTWxBMXhxTrGrlDolXBdye;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return cCMBjLQdMhYKuXiyPflWBugIUTcqA;
	}

	private void arLxlEYGvjkvWuzMDsSNwJKRPbbl()
	{
		arLxlEYGvjkvWuzMDsSNwJKRPbbl(Input.GetJoystickNames());
	}

	private void arLxlEYGvjkvWuzMDsSNwJKRPbbl(string[] P_0)
	{
		int num = 0;
		List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> list = elKJbbxESyfcuzfcxFoUDTJZIhcJA;
		int ncFhTqaznBUbORimVwWyLExKyNzx = NcFhTqaznBUbORimVwWyLExKyNzx;
		elKJbbxESyfcuzfcxFoUDTJZIhcJA = new List<LZffdTmeAXWDSIRgGRDMdlZPpzyP>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP = new LZffdTmeAXWDSIRgGRDMdlZPpzyP();
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.rTchmpjdeNRfricdByXcoHrqvrWY = text;
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.QUFMelDfJaUFXAbyxaVAmqwGjofN = text;
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.tSyZyaCrqwhsLmcgyErbUEHKZucs = i;
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.unityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH != null)
				{
					lZffdTmeAXWDSIRgGRDMdlZPpzyP.ELZDDcOYYkixojZiclpBbfXZzkcA = UnityTools.BCHkYYLGsLQnMmusVpqPohjqMrGH.GetUniqueDeviceIdentifier(text, i);
				}
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.MlxxoBHQWLcsxCtqgDqxENlqGClK();
				elKJbbxESyfcuzfcxFoUDTJZIhcJA.Add(lZffdTmeAXWDSIRgGRDMdlZPpzyP);
				num++;
			}
		}
		NcFhTqaznBUbORimVwWyLExKyNzx = num;
		cqAGnKSmwNWnRODgdRfXOJTBoCZu(ncFhTqaznBUbORimVwWyLExKyNzx, num, list, elKJbbxESyfcuzfcxFoUDTJZIhcJA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(elKJbbxESyfcuzfcxFoUDTJZIhcJA[j]));
			}
		}
		ndHGRVlfkxHhrsyODJjzLJITnfsX(list, elKJbbxESyfcuzfcxFoUDTJZIhcJA, false);
		ndHGRVlfkxHhrsyODJjzLJITnfsX(elKJbbxESyfcuzfcxFoUDTJZIhcJA, list, true);
		oaiElnKvSOuKbUxHZFZkswgybYlvA = P_0;
	}

	private void DzgjBVFcaWDogqCKSBeRqdglJPai(UpdateLoopType P_0)
	{
		int count = elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count;
		for (int i = 0; i < count; i++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i] != null)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].Update();
			}
		}
	}

	private void cqAGnKSmwNWnRODgdRfXOJTBoCZu(int P_0, int P_1, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_2, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(LZffdTmeAXWDSIRgGRDMdlZPpzyP.AOqDETERVUclbxpOxfFoZvRcjryqA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR.Exact);
			uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR.Approximate);
		}
		qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR.Exact);
		qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP = P_3[i];
			if (lZffdTmeAXWDSIRgGRDMdlZPpzyP != null && lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId < 0)
			{
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_3);
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.rewiredId = ReInput.GetNewJoystickId();
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(lZffdTmeAXWDSIRgGRDMdlZPpzyP);
			}
		}
		P_3.Sort(LZffdTmeAXWDSIRgGRDMdlZPpzyP.MOuKBWibvJbSJxUfatGKZFlrmTlW);
	}

	private void PXvhJlnAOWKmBwlhRDOltbukRfTW(List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_0, int P_1, int P_2)
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

	private bool RoQgGVBBIMEvxAlvsqmCkaytazLq(List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_0, int P_1)
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

	private int VdgvNWWcieHYaYPMzqzCHdZkirLp(List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_0)
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

	private bool XuZqBzKvCtCosuIEtcqGHmpxHywSA(List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_0, int P_1)
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

	private void uYUMbRdtPJBZfjrxwDzznOaHJQrI(int P_0, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_1, int P_2, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_3, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR P_4)
	{
		int num = ((P_4 != SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP = P_1[i];
			if (lZffdTmeAXWDSIRgGRDMdlZPpzyP == null || lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP2 = P_3[j];
				if (lZffdTmeAXWDSIRgGRDMdlZPpzyP2 != null && !XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, lZffdTmeAXWDSIRgGRDMdlZPpzyP2.rewiredId) && lZffdTmeAXWDSIRgGRDMdlZPpzyP.eRcrgXtiJZnEILPhcaiUyTnAFTCn(lZffdTmeAXWDSIRgGRDMdlZPpzyP2) >= num)
				{
					lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId = lZffdTmeAXWDSIRgGRDMdlZPpzyP2.inputManagerId;
					lZffdTmeAXWDSIRgGRDMdlZPpzyP.rewiredId = lZffdTmeAXWDSIRgGRDMdlZPpzyP2.rewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						lZffdTmeAXWDSIRgGRDMdlZPpzyP.unityId = lZffdTmeAXWDSIRgGRDMdlZPpzyP2.unityId;
					}
					boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(lZffdTmeAXWDSIRgGRDMdlZPpzyP);
				}
			}
		}
	}

	private void qGASwmLKicpNuRMFZhYhTikWOtmL(int P_0, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_1, SZyjuaaEUcVUhchZtnBIJIUKfQpbA.czvlRokeiiWZYVdQVNbKudDsjQOR P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP = P_1[i];
			if (lZffdTmeAXWDSIRgGRDMdlZPpzyP == null || lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId >= 0)
			{
				continue;
			}
			SZyjuaaEUcVUhchZtnBIJIUKfQpbA.rXPXhIqjMZmKRIGBJYXZiqPMROri rXPXhIqjMZmKRIGBJYXZiqPMROri = null;
			foreach (SZyjuaaEUcVUhchZtnBIJIUKfQpbA.rXPXhIqjMZmKRIGBJYXZiqPMROri item in boNSEKuFFoQzYuEJbTHAMBvFjgjG.EIllDHQFSlaxtdIhRTpOBXaXOnOQ(lZffdTmeAXWDSIRgGRDMdlZPpzyP, P_2))
			{
				if (!XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, item.wKTIDzdbnMqFnJlBBeomtbaWsxjR) && item.czjrOWhmqBwDdneXNALtIaxNwVzA >= 0)
				{
					rXPXhIqjMZmKRIGBJYXZiqPMROri = item;
					break;
				}
			}
			if (rXPXhIqjMZmKRIGBJYXZiqPMROri != null)
			{
				int num = rXPXhIqjMZmKRIGBJYXZiqPMROri.czjrOWhmqBwDdneXNALtIaxNwVzA;
				if (!RoQgGVBBIMEvxAlvsqmCkaytazLq(P_1, num))
				{
					num = (rXPXhIqjMZmKRIGBJYXZiqPMROri.czjrOWhmqBwDdneXNALtIaxNwVzA = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_1));
				}
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.inputManagerId = num;
				lZffdTmeAXWDSIRgGRDMdlZPpzyP.rewiredId = rXPXhIqjMZmKRIGBJYXZiqPMROri.wKTIDzdbnMqFnJlBBeomtbaWsxjR;
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(lZffdTmeAXWDSIRgGRDMdlZPpzyP);
			}
		}
	}

	private void alayrrvNCSZbAOTuonjpHkvoUumW()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (lEcAaLZsMqRMMUTDCMHZptaJAxDq || JCMhjgogkiAcRTHBcfVaOMUtSLyg(joystickNames))
		{
			arLxlEYGvjkvWuzMDsSNwJKRPbbl(joystickNames);
		}
		vOBKVnebkBpKgLMbliSkdvNFpdei = false;
		if (lEcAaLZsMqRMMUTDCMHZptaJAxDq)
		{
			lEcAaLZsMqRMMUTDCMHZptaJAxDq = false;
		}
	}

	private bool JCMhjgogkiAcRTHBcfVaOMUtSLyg(string[] P_0)
	{
		if (P_0.Length != oaiElnKvSOuKbUxHZFZkswgybYlvA.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], oaiElnKvSOuKbUxHZFZkswgybYlvA[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void ndHGRVlfkxHhrsyODJjzLJITnfsX(List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_0, List<LZffdTmeAXWDSIRgGRDMdlZPpzyP> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP = P_0[i];
			if (lZffdTmeAXWDSIRgGRDMdlZPpzyP == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					LZffdTmeAXWDSIRgGRDMdlZPpzyP lZffdTmeAXWDSIRgGRDMdlZPpzyP2 = P_1[j];
					if (lZffdTmeAXWDSIRgGRDMdlZPpzyP2 != null && lZffdTmeAXWDSIRgGRDMdlZPpzyP.rewiredId == lZffdTmeAXWDSIRgGRDMdlZPpzyP2.rewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				TsntVxtlUhBxydDlwSYiTnYwbYkmA(P_0[i], P_2);
			}
		}
	}

	private void TsntVxtlUhBxydDlwSYiTnYwbYkmA(LZffdTmeAXWDSIRgGRDMdlZPpzyP P_0, bool P_1)
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

	private void yDVekoZdYfNldNijdpdXsQfRAhyL()
	{
		if (HvFDPHvQHhAdkasJMjRxfxqlAkaF == xflYdbhzwYnRoAywPqTPypXPlhFn && HcPoHgGlLjDuNqHGNAOgiXFgBYmPA.Update())
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
			HcPoHgGlLjDuNqHGNAOgiXFgBYmPA.Start();
		}
	}
}
