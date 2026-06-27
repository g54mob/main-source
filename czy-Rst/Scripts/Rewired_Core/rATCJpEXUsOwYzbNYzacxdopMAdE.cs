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

internal class rATCJpEXUsOwYzbNYzacxdopMAdE : PlatformInputManager
{
	private class eksNrmuJaxejvDOZiWixMQzTZYUlA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int mgVJOFTzoOVAOmEStLDGvGRSFdUL;

		private int hpAtupIuZWMrhsHwjbZhBAVvoXTJA;

		private int vdnmKgTmAOisWqvUQcfcDeHsKkmT;

		public Guid TxwMzvMHwXoEIwJyfZFyXhdtkUIW;

		public string VljyKNMNgIZQMHJHdrZYlptWkGeG;

		public int hUmbMqSuPPrFLMoYPIOzuNJJkHAr;

		public string VzezcMlnCMLTCUoWxIYUNveKNpeB;

		public string RKdIlUGLMVVGGHZurldPzhYfWFAd;

		private int lureDPudagnQEnmmHVjXycQHfGEW = 29;

		private int mtvfxjafoaKUrnLhEHEaCMkToVQ = 20;

		private float[] rDtvJeEizqeDgeOBVNlYsOtHiKkmA;

		private bool[] mjMXBopybWNqtNBGtGCqKTkvmerOA;

		private bool[] ytTHOVwNHHlWtppiNgHrHfSEugWe;

		private float[] lAFpgNnYnHaiTUGABHWvRaWbxOLi;

		private bool[] sWVfxdoEJXbHJeHaElhufaEITMWzB;

		private HardwareJoystickMap_InputManager yMgcaBzsKnINZNqUsxawHuPulspT;

		private bool kjjNnLKiFWQOGLFQZrvhPmhKqUlB;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return mgVJOFTzoOVAOmEStLDGvGRSFdUL;
			}
			set
			{
				mgVJOFTzoOVAOmEStLDGvGRSFdUL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return hpAtupIuZWMrhsHwjbZhBAVvoXTJA;
			}
			set
			{
				hpAtupIuZWMrhsHwjbZhBAVvoXTJA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(VljyKNMNgIZQMHJHdrZYlptWkGeG != "Unknown Controller"))
				{
					return VzezcMlnCMLTCUoWxIYUNveKNpeB;
				}
				return VljyKNMNgIZQMHJHdrZYlptWkGeG;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (vdnmKgTmAOisWqvUQcfcDeHsKkmT < 1)
				{
					return null;
				}
				return vdnmKgTmAOisWqvUQcfcDeHsKkmT;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return vdnmKgTmAOisWqvUQcfcDeHsKkmT;
			}
			set
			{
				vdnmKgTmAOisWqvUQcfcDeHsKkmT = value;
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
					return MiscTools.CreateGuidHashSHA1(VzezcMlnCMLTCUoWxIYUNveKNpeB);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + vdnmKgTmAOisWqvUQcfcDeHsKkmT);
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

		public eksNrmuJaxejvDOZiWixMQzTZYUlA()
		{
			hpAtupIuZWMrhsHwjbZhBAVvoXTJA = -1;
			mgVJOFTzoOVAOmEStLDGvGRSFdUL = -1;
			vdnmKgTmAOisWqvUQcfcDeHsKkmT = 0;
		}

		public void CrxAQLBVSMLRuOSfGgYAozNquAaMA()
		{
			apuAsedtfzbdNhqoQrGNiMmYFIgfA();
			TxwMzvMHwXoEIwJyfZFyXhdtkUIW = yMgcaBzsKnINZNqUsxawHuPulspT.hardwareMapIdentifier.guid;
			VljyKNMNgIZQMHJHdrZYlptWkGeG = yMgcaBzsKnINZNqUsxawHuPulspT.controllerName;
			rDtvJeEizqeDgeOBVNlYsOtHiKkmA = new float[lureDPudagnQEnmmHVjXycQHfGEW];
			mjMXBopybWNqtNBGtGCqKTkvmerOA = new bool[mtvfxjafoaKUrnLhEHEaCMkToVQ];
			ytTHOVwNHHlWtppiNgHrHfSEugWe = new bool[lureDPudagnQEnmmHVjXycQHfGEW];
			sWVfxdoEJXbHJeHaElhufaEITMWzB = new bool[29];
			lAFpgNnYnHaiTUGABHWvRaWbxOLi = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (vdnmKgTmAOisWqvUQcfcDeHsKkmT > 0)
			{
				KDzIQmEmDzEYGCSjgwdadwavJqqJ();
				QdwELnOXOJqglHHpEmypdozfIarX();
				SQNNLTsSkopdXwFJPnYcPZFnGXmg();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int XMxdflcCZqbHlqJxGotvxBsAYdKj(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0)
		{
			if ((!string.IsNullOrEmpty(RKdIlUGLMVVGGHZurldPzhYfWFAd) || !string.IsNullOrEmpty(P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd)) && !string.Equals(RKdIlUGLMVVGGHZurldPzhYfWFAd, P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB == VzezcMlnCMLTCUoWxIYUNveKNpeB && P_0.hUmbMqSuPPrFLMoYPIOzuNJJkHAr == hUmbMqSuPPrFLMoYPIOzuNJJkHAr)
			{
				return 2;
			}
			if (P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB == VzezcMlnCMLTCUoWxIYUNveKNpeB)
			{
				return 1;
			}
			return 0;
		}

		private void yVsdfYhbkUbnHqCEUXlNWhNiFWYM(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = LjRcriHawzNPfkEFATydDeJbsikq();
			P_0.hardwareIdentifier = NdxeWlTRIUICbgtKINKeOqtSkMXCb();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = VzezcMlnCMLTCUoWxIYUNveKNpeB;
		}

		private void GfhIXbIngvhAceqQfoMotgsoRwzw(BridgedController P_0)
		{
			yVsdfYhbkUbnHqCEUXlNWhNiFWYM(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = yMgcaBzsKnINZNqUsxawHuPulspT.ToGameHardwareControllerMap();
			P_0.instanceName = VzezcMlnCMLTCUoWxIYUNveKNpeB;
			P_0.productName = VzezcMlnCMLTCUoWxIYUNveKNpeB;
			P_0.isXInputDevice = false;
			P_0.axisCount = lureDPudagnQEnmmHVjXycQHfGEW;
			P_0.buttonCount = mtvfxjafoaKUrnLhEHEaCMkToVQ;
			P_0.controllerTypeGuid = TxwMzvMHwXoEIwJyfZFyXhdtkUIW;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (lureDPudagnQEnmmHVjXycQHfGEW != dataUpdater.axisCount || mtvfxjafoaKUrnLhEHEaCMkToVQ != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < lureDPudagnQEnmmHVjXycQHfGEW; i++)
			{
				if (axisValues[i] != rDtvJeEizqeDgeOBVNlYsOtHiKkmA[i])
				{
					axisValues[i] = rDtvJeEizqeDgeOBVNlYsOtHiKkmA[i];
					if (axisHasBeenPressedOSXLinux[i] != ytTHOVwNHHlWtppiNgHrHfSEugWe[i])
					{
						axisHasBeenPressedOSXLinux[i] = ytTHOVwNHHlWtppiNgHrHfSEugWe[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < mtvfxjafoaKUrnLhEHEaCMkToVQ; j++)
			{
				if (buttonValues[j] != mjMXBopybWNqtNBGtGCqKTkvmerOA[j])
				{
					buttonValues[j] = mjMXBopybWNqtNBGtGCqKTkvmerOA[j];
				}
			}
			if (kjjNnLKiFWQOGLFQZrvhPmhKqUlB && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void JSkUbMElOCRoZUqjQhgSDjiUnEGxA(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void RvjliZbeFiIoRSLwRgdTDYiwcyIDA()
		{
			vdnmKgTmAOisWqvUQcfcDeHsKkmT = 0;
			jQOHmERNgrBbrgcZZFDrRCinlVmM();
		}

		public BridgedControllerHWInfo FMAiuxNBMBMIwyqSyqVxgVJxKjPc()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			yVsdfYhbkUbnHqCEUXlNWhNiFWYM(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			GfhIXbIngvhAceqQfoMotgsoRwzw(bridgedController);
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
			return new ControllerDisconnectedEventArgs(mgVJOFTzoOVAOmEStLDGvGRSFdUL);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void KDzIQmEmDzEYGCSjgwdadwavJqqJ()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(vdnmKgTmAOisWqvUQcfcDeHsKkmT, i);
				if (lAFpgNnYnHaiTUGABHWvRaWbxOLi[i] != joystickAxisValueByJoystickId)
				{
					lAFpgNnYnHaiTUGABHWvRaWbxOLi[i] = joystickAxisValueByJoystickId;
					if (!sWVfxdoEJXbHJeHaElhufaEITMWzB[i] && joystickAxisValueByJoystickId != 0f)
					{
						sWVfxdoEJXbHJeHaElhufaEITMWzB[i] = true;
					}
				}
			}
		}

		private void QdwELnOXOJqglHHpEmypdozfIarX()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)yMgcaBzsKnINZNqUsxawHuPulspT.map).Axes_orig;
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
				if (i >= lureDPudagnQEnmmHVjXycQHfGEW)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = ZHmZXtBZbmESeXPLuQOnlUvPTGpJ(axes_orig[i]);
				if (rDtvJeEizqeDgeOBVNlYsOtHiKkmA[i] == num)
				{
					continue;
				}
				rDtvJeEizqeDgeOBVNlYsOtHiKkmA[i] = num;
				if (!ytTHOVwNHHlWtppiNgHrHfSEugWe[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = zJlkKRuxVdHUhGoVugiVdzYXHkaY(axes_orig[i].sourceAxis);
						ytTHOVwNHHlWtppiNgHrHfSEugWe[i] = num2 != 0f;
					}
					else
					{
						ytTHOVwNHHlWtppiNgHrHfSEugWe[i] = true;
					}
				}
				if (!kjjNnLKiFWQOGLFQZrvhPmhKqUlB && rDtvJeEizqeDgeOBVNlYsOtHiKkmA[i] != 0f)
				{
					kjjNnLKiFWQOGLFQZrvhPmhKqUlB = true;
				}
			}
		}

		private void SQNNLTsSkopdXwFJPnYcPZFnGXmg()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)yMgcaBzsKnINZNqUsxawHuPulspT.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= mtvfxjafoaKUrnLhEHEaCMkToVQ)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = vaIDlNYxVgdJBNxFocOyxmJIOfYn(buttons_orig[i]);
				if (mjMXBopybWNqtNBGtGCqKTkvmerOA[i] != flag)
				{
					mjMXBopybWNqtNBGtGCqKTkvmerOA[i] = flag;
					if (!kjjNnLKiFWQOGLFQZrvhPmhKqUlB && mjMXBopybWNqtNBGtGCqKTkvmerOA[i])
					{
						kjjNnLKiFWQOGLFQZrvhPmhKqUlB = true;
					}
				}
			}
		}

		private bool vaIDlNYxVgdJBNxFocOyxmJIOfYn(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (eYkcGMvGnyJooONXBHwmqYAFewZS(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!eYkcGMvGnyJooONXBHwmqYAFewZS(P_0.requiredButtons[j]))
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
				return eYkcGMvGnyJooONXBHwmqYAFewZS(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = zJlkKRuxVdHUhGoVugiVdzYXHkaY(P_0.sourceAxis);
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
				float num2 = zJlkKRuxVdHUhGoVugiVdzYXHkaY(unityHat_sourceAxis);
				float num3 = zJlkKRuxVdHUhGoVugiVdzYXHkaY(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (IAtbwQZDlfBtfVNPAbXFGUmorTeSA(unityHat_sourceAxis) || IAtbwQZDlfBtfVNPAbXFGUmorTeSA(unityHat_sourceAxis2))
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
				if (zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues1.x, num2) && zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues2.x, num2) && zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues3.x, num2) && zIncsaatjQwRCNnAwbYzlbZACJwaA(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (GwDnJZhbFbNxkrvFEmORpMgMLQRJ(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (YpZqaRZAeRplWvWqdpwNXYyhgRSD(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (PdIRQuTZZkMByNmpHUTwefuEPFKS(customCalculationSourceData[k], out var flag2))
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

		private bool zIncsaatjQwRCNnAwbYzlbZACJwaA(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float ZHmZXtBZbmESeXPLuQOnlUvPTGpJ(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!IAtbwQZDlfBtfVNPAbXFGUmorTeSA(P_0.sourceAxis))
				{
					return 0f;
				}
				return zJlkKRuxVdHUhGoVugiVdzYXHkaY(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!eYkcGMvGnyJooONXBHwmqYAFewZS(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && YpZqaRZAeRplWvWqdpwNXYyhgRSD(customCalculationSourceData[i], out var item))
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

		private float zJlkKRuxVdHUhGoVugiVdzYXHkaY(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return lAFpgNnYnHaiTUGABHWvRaWbxOLi[num];
		}

		private bool eYkcGMvGnyJooONXBHwmqYAFewZS(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(vdnmKgTmAOisWqvUQcfcDeHsKkmT, buttonIndex);
		}

		private bool GwDnJZhbFbNxkrvFEmORpMgMLQRJ(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = eYkcGMvGnyJooONXBHwmqYAFewZS(sourceElement);
			return true;
		}

		private bool PdIRQuTZZkMByNmpHUTwefuEPFKS(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool YpZqaRZAeRplWvWqdpwNXYyhgRSD(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = zJlkKRuxVdHUhGoVugiVdzYXHkaY(sourceElement);
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

		private bool IAtbwQZDlfBtfVNPAbXFGUmorTeSA(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return sWVfxdoEJXbHJeHaElhufaEITMWzB[num];
		}

		private void apuAsedtfzbdNhqoQrGNiMmYFIgfA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = FMAiuxNBMBMIwyqSyqVxgVJxKjPc();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(VzezcMlnCMLTCUoWxIYUNveKNpeB, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(VzezcMlnCMLTCUoWxIYUNveKNpeB))
					{
						if (ds4Helper.IsDS4KeyMapped(hUmbMqSuPPrFLMoYPIOzuNJJkHAr))
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
			yMgcaBzsKnINZNqUsxawHuPulspT = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (yMgcaBzsKnINZNqUsxawHuPulspT == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && yMgcaBzsKnINZNqUsxawHuPulspT.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = njQaLxRijBLaWJQLAFHqhMkyqHWw(VzezcMlnCMLTCUoWxIYUNveKNpeB);
				if (!string.IsNullOrEmpty(text))
				{
					yMgcaBzsKnINZNqUsxawHuPulspT.controllerName = text;
					if (yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys[0]))
					{
						yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys[0], text));
					}
					yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (yMgcaBzsKnINZNqUsxawHuPulspT.useSystemName && !string.IsNullOrEmpty(VzezcMlnCMLTCUoWxIYUNveKNpeB))
			{
				string text2 = Regex.Replace(VzezcMlnCMLTCUoWxIYUNveKNpeB, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					yMgcaBzsKnINZNqUsxawHuPulspT.controllerName = text2;
					if (yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys[0]))
					{
						yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.parentKeys[0], text2));
					}
					yMgcaBzsKnINZNqUsxawHuPulspT.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			lureDPudagnQEnmmHVjXycQHfGEW = yMgcaBzsKnINZNqUsxawHuPulspT.axisCount;
			mtvfxjafoaKUrnLhEHEaCMkToVQ = yMgcaBzsKnINZNqUsxawHuPulspT.buttonCount;
		}

		private void jQOHmERNgrBbrgcZZFDrRCinlVmM()
		{
			Array.Clear(mjMXBopybWNqtNBGtGCqKTkvmerOA, 0, mjMXBopybWNqtNBGtGCqKTkvmerOA.Length);
			Array.Clear(rDtvJeEizqeDgeOBVNlYsOtHiKkmA, 0, rDtvJeEizqeDgeOBVNlYsOtHiKkmA.Length);
		}

		private string NdxeWlTRIUICbgtKINKeOqtSkMXCb()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{LjRcriHawzNPfkEFATydDeJbsikq().ToString()}{VzezcMlnCMLTCUoWxIYUNveKNpeB}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(VzezcMlnCMLTCUoWxIYUNveKNpeB, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{LjRcriHawzNPfkEFATydDeJbsikq().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{LjRcriHawzNPfkEFATydDeJbsikq().ToString()}{VzezcMlnCMLTCUoWxIYUNveKNpeB}");
		}

		private InputSource LjRcriHawzNPfkEFATydDeJbsikq()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(VzezcMlnCMLTCUoWxIYUNveKNpeB))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int WScrjnhyLkMfTOqcJnesXaRwOpYL(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, eksNrmuJaxejvDOZiWixMQzTZYUlA P_1)
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

		public static int xjYHgkialSenaBZUbTOyUMJPdNOB(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, eksNrmuJaxejvDOZiWixMQzTZYUlA P_1)
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

		private static string njQaLxRijBLaWJQLAFHqhMkyqHWw(string P_0)
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

	private class dQnsyLmayWesSyHiRwmdoZiSMdJn
	{
		public enum QQEGoobbGROeDXHSYsVOavNNnZfjA
		{
			Exact = 0,
			Approximate = 1
		}

		public class MivuigqsvilXZPyHFfYcXaZxpRCA
		{
			public int BDVmeVfneJsORVOcygisqMtTMouk;

			public int tuFzukrOImHUlwHSEBVSgUxfVQzS;

			public string tnXyKcROPuKjHRArLxEFFvlXYBeI;

			public int sWvArbLRRPYlgjKyHcdalaQHeaBjA;

			public string TSSHiwtJWTixDMqDjOqOtNWQHYGE;

			public bool xGkXeaBIMviZGtgOeQqNIZDcPVVs(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, QQEGoobbGROeDXHSYsVOavNNnZfjA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == BDVmeVfneJsORVOcygisqMtTMouk)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(TSSHiwtJWTixDMqDjOqOtNWQHYGE) || !string.IsNullOrEmpty(P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd)) && !string.Equals(TSSHiwtJWTixDMqDjOqOtNWQHYGE, P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case QQEGoobbGROeDXHSYsVOavNNnZfjA.Exact:
					if (tuFzukrOImHUlwHSEBVSgUxfVQzS == P_0.hUmbMqSuPPrFLMoYPIOzuNJJkHAr)
					{
						return tnXyKcROPuKjHRArLxEFFvlXYBeI == P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB;
					}
					return false;
				case QQEGoobbGROeDXHSYsVOavNNnZfjA.Approximate:
					return tnXyKcROPuKjHRArLxEFFvlXYBeI == P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class FVcCkRKMtTUxbFQGxtMUjfdUToOU : IEnumerable<MivuigqsvilXZPyHFfYcXaZxpRCA>, IEnumerable, IEnumerator<MivuigqsvilXZPyHFfYcXaZxpRCA>, IEnumerator, IDisposable
		{
			private int pLPknzOfiMnTzTcKMYGGPWAbqOLB;

			private MivuigqsvilXZPyHFfYcXaZxpRCA UrndaMGFkQrCXEvuiQJuPqMeTRNMA;

			private int tPwUFsinRlAxMBAizRSXqbvFXQet;

			public dQnsyLmayWesSyHiRwmdoZiSMdJn qXSrzjxRPjRlVOCqxtjcRGteATQM;

			private eksNrmuJaxejvDOZiWixMQzTZYUlA aQmpsiSMepFVWhqrraMPasNzxYMQA;

			public eksNrmuJaxejvDOZiWixMQzTZYUlA DKXcXFBZfXeFBujLseOhGoiKtkTec;

			private QQEGoobbGROeDXHSYsVOavNNnZfjA TXEHBOiVXUGGBqVFnjRxeTBiULix;

			public QQEGoobbGROeDXHSYsVOavNNnZfjA OrxlCSGiMYgeTCtAtbmYIKumWqXjA;

			private int pIrEzMierupcHnPbvztQLVLPeuexA;

			private int zRQRNIispBuBVbqEMsRGtSxmLqdg;

			MivuigqsvilXZPyHFfYcXaZxpRCA IEnumerator<MivuigqsvilXZPyHFfYcXaZxpRCA>.Current
			{
				[DebuggerHidden]
				get
				{
					return UrndaMGFkQrCXEvuiQJuPqMeTRNMA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UrndaMGFkQrCXEvuiQJuPqMeTRNMA;
				}
			}

			[DebuggerHidden]
			public FVcCkRKMtTUxbFQGxtMUjfdUToOU(int P_0)
			{
				pLPknzOfiMnTzTcKMYGGPWAbqOLB = P_0;
				tPwUFsinRlAxMBAizRSXqbvFXQet = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = pLPknzOfiMnTzTcKMYGGPWAbqOLB;
				dQnsyLmayWesSyHiRwmdoZiSMdJn dQnsyLmayWesSyHiRwmdoZiSMdJn2 = qXSrzjxRPjRlVOCqxtjcRGteATQM;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					pLPknzOfiMnTzTcKMYGGPWAbqOLB = -1;
					goto IL_0083;
				}
				pLPknzOfiMnTzTcKMYGGPWAbqOLB = -1;
				pIrEzMierupcHnPbvztQLVLPeuexA = dQnsyLmayWesSyHiRwmdoZiSMdJn2.vMKjgDTtHDyefVnLzmgrIlujhcKD.Count;
				zRQRNIispBuBVbqEMsRGtSxmLqdg = 0;
				goto IL_0093;
				IL_0083:
				zRQRNIispBuBVbqEMsRGtSxmLqdg++;
				goto IL_0093;
				IL_0093:
				if (zRQRNIispBuBVbqEMsRGtSxmLqdg < pIrEzMierupcHnPbvztQLVLPeuexA)
				{
					if (dQnsyLmayWesSyHiRwmdoZiSMdJn2.vMKjgDTtHDyefVnLzmgrIlujhcKD[zRQRNIispBuBVbqEMsRGtSxmLqdg].xGkXeaBIMviZGtgOeQqNIZDcPVVs(aQmpsiSMepFVWhqrraMPasNzxYMQA, TXEHBOiVXUGGBqVFnjRxeTBiULix))
					{
						UrndaMGFkQrCXEvuiQJuPqMeTRNMA = dQnsyLmayWesSyHiRwmdoZiSMdJn2.vMKjgDTtHDyefVnLzmgrIlujhcKD[zRQRNIispBuBVbqEMsRGtSxmLqdg];
						pLPknzOfiMnTzTcKMYGGPWAbqOLB = 1;
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
			IEnumerator<MivuigqsvilXZPyHFfYcXaZxpRCA> IEnumerable<MivuigqsvilXZPyHFfYcXaZxpRCA>.GetEnumerator()
			{
				FVcCkRKMtTUxbFQGxtMUjfdUToOU fVcCkRKMtTUxbFQGxtMUjfdUToOU;
				if (pLPknzOfiMnTzTcKMYGGPWAbqOLB == -2 && tPwUFsinRlAxMBAizRSXqbvFXQet == Environment.CurrentManagedThreadId)
				{
					pLPknzOfiMnTzTcKMYGGPWAbqOLB = 0;
					fVcCkRKMtTUxbFQGxtMUjfdUToOU = this;
				}
				else
				{
					fVcCkRKMtTUxbFQGxtMUjfdUToOU = new FVcCkRKMtTUxbFQGxtMUjfdUToOU(0);
					fVcCkRKMtTUxbFQGxtMUjfdUToOU.qXSrzjxRPjRlVOCqxtjcRGteATQM = qXSrzjxRPjRlVOCqxtjcRGteATQM;
				}
				fVcCkRKMtTUxbFQGxtMUjfdUToOU.aQmpsiSMepFVWhqrraMPasNzxYMQA = DKXcXFBZfXeFBujLseOhGoiKtkTec;
				fVcCkRKMtTUxbFQGxtMUjfdUToOU.TXEHBOiVXUGGBqVFnjRxeTBiULix = OrxlCSGiMYgeTCtAtbmYIKumWqXjA;
				return fVcCkRKMtTUxbFQGxtMUjfdUToOU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<MivuigqsvilXZPyHFfYcXaZxpRCA>)this).GetEnumerator();
			}
		}

		private List<MivuigqsvilXZPyHFfYcXaZxpRCA> vMKjgDTtHDyefVnLzmgrIlujhcKD;

		public int UthdkNDjufdurHUlmzRuGpsODDwfA => vMKjgDTtHDyefVnLzmgrIlujhcKD.Count;

		public dQnsyLmayWesSyHiRwmdoZiSMdJn()
		{
			vMKjgDTtHDyefVnLzmgrIlujhcKD = new List<MivuigqsvilXZPyHFfYcXaZxpRCA>();
		}

		public void BHsciGRGJGDIPBRepVZgezZJAuRdA(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = vMKjgDTtHDyefVnLzmgrIlujhcKD.Count;
			for (int i = 0; i < count; i++)
			{
				if (vMKjgDTtHDyefVnLzmgrIlujhcKD[i].xGkXeaBIMviZGtgOeQqNIZDcPVVs(P_0, QQEGoobbGROeDXHSYsVOavNNnZfjA.Exact))
				{
					vMKjgDTtHDyefVnLzmgrIlujhcKD[i].BDVmeVfneJsORVOcygisqMtTMouk = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					vMKjgDTtHDyefVnLzmgrIlujhcKD[i].tnXyKcROPuKjHRArLxEFFvlXYBeI = P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB;
					vMKjgDTtHDyefVnLzmgrIlujhcKD[i].tuFzukrOImHUlwHSEBVSgUxfVQzS = P_0.hUmbMqSuPPrFLMoYPIOzuNJJkHAr;
					vMKjgDTtHDyefVnLzmgrIlujhcKD[i].sWvArbLRRPYlgjKyHcdalaQHeaBjA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					vMKjgDTtHDyefVnLzmgrIlujhcKD[i].TSSHiwtJWTixDMqDjOqOtNWQHYGE = P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd;
					ZCVltPGdyTDgRJPJirtLtMyRaeobA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
					return;
				}
			}
			vMKjgDTtHDyefVnLzmgrIlujhcKD.Add(new MivuigqsvilXZPyHFfYcXaZxpRCA
			{
				BDVmeVfneJsORVOcygisqMtTMouk = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				tnXyKcROPuKjHRArLxEFFvlXYBeI = P_0.VzezcMlnCMLTCUoWxIYUNveKNpeB,
				tuFzukrOImHUlwHSEBVSgUxfVQzS = P_0.hUmbMqSuPPrFLMoYPIOzuNJJkHAr,
				sWvArbLRRPYlgjKyHcdalaQHeaBjA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				TSSHiwtJWTixDMqDjOqOtNWQHYGE = P_0.RKdIlUGLMVVGGHZurldPzhYfWFAd
			});
			ZCVltPGdyTDgRJPJirtLtMyRaeobA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, vMKjgDTtHDyefVnLzmgrIlujhcKD.Count - 1);
		}

		public bool LzfHFueKjrbkXMDmGQFDHdsOYoNX(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, QQEGoobbGROeDXHSYsVOavNNnZfjA P_1)
		{
			int count = vMKjgDTtHDyefVnLzmgrIlujhcKD.Count;
			for (int i = 0; i < count; i++)
			{
				if (vMKjgDTtHDyefVnLzmgrIlujhcKD[i].xGkXeaBIMviZGtgOeQqNIZDcPVVs(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(FVcCkRKMtTUxbFQGxtMUjfdUToOU))]
		public IEnumerable<MivuigqsvilXZPyHFfYcXaZxpRCA> jFIFrmqGgSqOuPNNWmRTcAuoplju(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, QQEGoobbGROeDXHSYsVOavNNnZfjA P_1)
		{
			return new FVcCkRKMtTUxbFQGxtMUjfdUToOU(-2)
			{
				qXSrzjxRPjRlVOCqxtjcRGteATQM = this,
				DKXcXFBZfXeFBujLseOhGoiKtkTec = P_0,
				OrxlCSGiMYgeTCtAtbmYIKumWqXjA = P_1
			};
		}

		public int LEMaIPnDbVsNkpjnJydkKIUeUCzP(MivuigqsvilXZPyHFfYcXaZxpRCA P_0)
		{
			int count = vMKjgDTtHDyefVnLzmgrIlujhcKD.Count;
			for (int i = 0; i < count; i++)
			{
				if (vMKjgDTtHDyefVnLzmgrIlujhcKD[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void ZCVltPGdyTDgRJPJirtLtMyRaeobA(int P_0, int P_1)
		{
			for (int num = vMKjgDTtHDyefVnLzmgrIlujhcKD.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && vMKjgDTtHDyefVnLzmgrIlujhcKD[num].BDVmeVfneJsORVOcygisqMtTMouk == P_0)
				{
					vMKjgDTtHDyefVnLzmgrIlujhcKD.RemoveAt(num);
				}
			}
		}
	}

	private List<eksNrmuJaxejvDOZiWixMQzTZYUlA> osNqDIGoeNjndsAsyGhXgWTsgABW;

	private int SKpDkVFTeQRbyTDFgKfGJwvVMkrv;

	private dQnsyLmayWesSyHiRwmdoZiSMdJn PnZmdWEUUJCVLDLReAFHdMzrXPBy;

	private bool uSGiMuXctHaMcnuopqDPyovAEDBV;

	private bool jjuWdDormEBZtfbxTUctujnQLliJA;

	private UpdateLoopType MhHRJDslzrByHqTIEDwYjdoCFTrL;

	private UpdateLoopType YstqJQEaUNEADMpArhLhLTQLMYkU;

	private TimerAbs WYBuvgwGTrYSIPnrwTIHdppOuWRv;

	private Action<int, ControllerDataUpdater> IzlEAIyODvNWDawBFLcqgnGopyhv;

	private PlatformInputManager JHEphLyEVnREJjTATeLbEdtYufgi;

	private readonly IUnifiedKeyboardSource XnOETZvFowIqafAuedjAzTzrgWioA;

	private readonly IUnifiedMouseSource xsLpnIeVFVWDPDpJcBSUdRPJJRIHA;

	private bool SJQcxrubnibWtJAjcZDlAqgqteUc;

	private string[] NGxGqXoieeqUzOUHHaCzVrcHCIGt;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => SKpDkVFTeQRbyTDFgKfGJwvVMkrv;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => JHEphLyEVnREJjTATeLbEdtYufgi;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public rATCJpEXUsOwYzbNYzacxdopMAdE(UpdateLoopSetting P_0)
	{
		JHEphLyEVnREJjTATeLbEdtYufgi = this;
		XnOETZvFowIqafAuedjAzTzrgWioA = new UnityUnifiedKeyboardSource();
		xsLpnIeVFVWDPDpJcBSUdRPJJRIHA = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				YstqJQEaUNEADMpArhLhLTQLMYkU = list[num];
			}
		}
		NGxGqXoieeqUzOUHHaCzVrcHCIGt = new string[0];
		IzlEAIyODvNWDawBFLcqgnGopyhv = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA != null)
		{
			UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA.DeviceChangedEvent += imhUSfMjvXaxfzlfqbclCiEynEOgb;
		}
		WYBuvgwGTrYSIPnrwTIHdppOuWRv = new TimerAbs(1.0);
		PnZmdWEUUJCVLDLReAFHdMzrXPBy = new dQnsyLmayWesSyHiRwmdoZiSMdJn();
		jZuIehOTnkBPPtwQaKUvStsUXqIj();
		uSGiMuXctHaMcnuopqDPyovAEDBV = true;
		WYBuvgwGTrYSIPnrwTIHdppOuWRv.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		MhHRJDslzrByHqTIEDwYjdoCFTrL = updateLoop;
		amxhJTwIwfwlIRRaucFFIUjitmKB();
		if (uSGiMuXctHaMcnuopqDPyovAEDBV)
		{
			hHWsfFlWnSclCJkrpRmWiCNLSdYA();
		}
		PfapuQFYiWHlVvIAMPLuPupzvTV(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA != null)
		{
			UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA.DeviceChangedEvent -= imhUSfMjvXaxfzlfqbclCiEynEOgb;
		}
		(XnOETZvFowIqafAuedjAzTzrgWioA as IDisposable).Dispose();
		(xsLpnIeVFVWDPDpJcBSUdRPJJRIHA as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return IzlEAIyODvNWDawBFLcqgnGopyhv;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < SKpDkVFTeQRbyTDFgKfGJwvVMkrv; i++)
		{
			if (osNqDIGoeNjndsAsyGhXgWTsgABW[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				osNqDIGoeNjndsAsyGhXgWTsgABW[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		uSGiMuXctHaMcnuopqDPyovAEDBV = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		uSGiMuXctHaMcnuopqDPyovAEDBV = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void imhUSfMjvXaxfzlfqbclCiEynEOgb()
	{
		uSGiMuXctHaMcnuopqDPyovAEDBV = true;
		jjuWdDormEBZtfbxTUctujnQLliJA = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < osNqDIGoeNjndsAsyGhXgWTsgABW.Count; i++)
		{
			if (osNqDIGoeNjndsAsyGhXgWTsgABW[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				osNqDIGoeNjndsAsyGhXgWTsgABW[i].RvjliZbeFiIoRSLwRgdTDYiwcyIDA();
			}
		}
		for (int j = 0; j < osNqDIGoeNjndsAsyGhXgWTsgABW.Count; j++)
		{
			if (osNqDIGoeNjndsAsyGhXgWTsgABW[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				osNqDIGoeNjndsAsyGhXgWTsgABW[j].JSkUbMElOCRoZUqjQhgSDjiUnEGxA(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return xsLpnIeVFVWDPDpJcBSUdRPJJRIHA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return XnOETZvFowIqafAuedjAzTzrgWioA;
	}

	private void jZuIehOTnkBPPtwQaKUvStsUXqIj()
	{
		msTNfwKuEQbamivQidJGVhTdoKCG(Input.GetJoystickNames());
	}

	private void msTNfwKuEQbamivQidJGVhTdoKCG(string[] P_0)
	{
		int num = 0;
		List<eksNrmuJaxejvDOZiWixMQzTZYUlA> list = osNqDIGoeNjndsAsyGhXgWTsgABW;
		int sKpDkVFTeQRbyTDFgKfGJwvVMkrv = SKpDkVFTeQRbyTDFgKfGJwvVMkrv;
		osNqDIGoeNjndsAsyGhXgWTsgABW = new List<eksNrmuJaxejvDOZiWixMQzTZYUlA>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA2 = new eksNrmuJaxejvDOZiWixMQzTZYUlA();
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.VzezcMlnCMLTCUoWxIYUNveKNpeB = text;
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.VljyKNMNgIZQMHJHdrZYlptWkGeG = text;
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.hUmbMqSuPPrFLMoYPIOzuNJJkHAr = i;
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA != null)
				{
					eksNrmuJaxejvDOZiWixMQzTZYUlA2.RKdIlUGLMVVGGHZurldPzhYfWFAd = UnityTools.bogHKChnwWGVEctpAkleZxzXilUtA.GetUniqueDeviceIdentifier(text, i);
				}
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.CrxAQLBVSMLRuOSfGgYAozNquAaMA();
				osNqDIGoeNjndsAsyGhXgWTsgABW.Add(eksNrmuJaxejvDOZiWixMQzTZYUlA2);
				num++;
			}
		}
		SKpDkVFTeQRbyTDFgKfGJwvVMkrv = num;
		KEyPUXEVgiwhczAbPNxbbletBSJP(sKpDkVFTeQRbyTDFgKfGJwvVMkrv, num, list, osNqDIGoeNjndsAsyGhXgWTsgABW);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(osNqDIGoeNjndsAsyGhXgWTsgABW[j]));
			}
		}
		RebMXBFBpDoPUfCjtavMcuLwtEhp(list, osNqDIGoeNjndsAsyGhXgWTsgABW, false);
		RebMXBFBpDoPUfCjtavMcuLwtEhp(osNqDIGoeNjndsAsyGhXgWTsgABW, list, true);
		NGxGqXoieeqUzOUHHaCzVrcHCIGt = P_0;
	}

	private void PfapuQFYiWHlVvIAMPLuPupzvTV(UpdateLoopType P_0)
	{
		int count = osNqDIGoeNjndsAsyGhXgWTsgABW.Count;
		for (int i = 0; i < count; i++)
		{
			if (osNqDIGoeNjndsAsyGhXgWTsgABW[i] != null)
			{
				osNqDIGoeNjndsAsyGhXgWTsgABW[i].Update();
			}
		}
	}

	private void KEyPUXEVgiwhczAbPNxbbletBSJP(int P_0, int P_1, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_2, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(eksNrmuJaxejvDOZiWixMQzTZYUlA.xjYHgkialSenaBZUbTOyUMJPdNOB);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			NLTwgYodIQjlUgBezQBgdVzdOhkEb(P_1, P_3, P_0, P_2, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA.Exact);
			NLTwgYodIQjlUgBezQBgdVzdOhkEb(P_1, P_3, P_0, P_2, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA.Approximate);
		}
		fVflOEGHawzahFlbwSOCgMLayPus(P_1, P_3, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA.Exact);
		fVflOEGHawzahFlbwSOCgMLayPus(P_1, P_3, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA2 = P_3[i];
			if (eksNrmuJaxejvDOZiWixMQzTZYUlA2 != null && eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = tRgNKQnECbGRsVfVettZYHOxNuT(P_3);
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				PnZmdWEUUJCVLDLReAFHdMzrXPBy.BHsciGRGJGDIPBRepVZgezZJAuRdA(eksNrmuJaxejvDOZiWixMQzTZYUlA2);
			}
		}
		P_3.Sort(eksNrmuJaxejvDOZiWixMQzTZYUlA.WScrjnhyLkMfTOqcJnesXaRwOpYL);
	}

	private void vRJRuzjmfuecdkgyDnwUcJHKiYtoc(List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_0, int P_1, int P_2)
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

	private bool ngWtWORtvXZXSwpNTFgmpXGKZiH(List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_0, int P_1)
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

	private int tRgNKQnECbGRsVfVettZYHOxNuT(List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_0)
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

	private bool YAITzbKBBPuhQPJWxhVHzNjOSlud(List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_0, int P_1)
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

	private void NLTwgYodIQjlUgBezQBgdVzdOhkEb(int P_0, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_1, int P_2, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_3, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA P_4)
	{
		int num = ((P_4 != dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA2 = P_1[i];
			if (eksNrmuJaxejvDOZiWixMQzTZYUlA2 == null || eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA3 = P_3[j];
				if (eksNrmuJaxejvDOZiWixMQzTZYUlA3 != null && !YAITzbKBBPuhQPJWxhVHzNjOSlud(P_1, eksNrmuJaxejvDOZiWixMQzTZYUlA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && eksNrmuJaxejvDOZiWixMQzTZYUlA2.XMxdflcCZqbHlqJxGotvxBsAYdKj(eksNrmuJaxejvDOZiWixMQzTZYUlA3) >= num)
				{
					eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = eksNrmuJaxejvDOZiWixMQzTZYUlA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = eksNrmuJaxejvDOZiWixMQzTZYUlA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = eksNrmuJaxejvDOZiWixMQzTZYUlA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					PnZmdWEUUJCVLDLReAFHdMzrXPBy.BHsciGRGJGDIPBRepVZgezZJAuRdA(eksNrmuJaxejvDOZiWixMQzTZYUlA2);
				}
			}
		}
	}

	private void fVflOEGHawzahFlbwSOCgMLayPus(int P_0, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_1, dQnsyLmayWesSyHiRwmdoZiSMdJn.QQEGoobbGROeDXHSYsVOavNNnZfjA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA2 = P_1[i];
			if (eksNrmuJaxejvDOZiWixMQzTZYUlA2 == null || eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			dQnsyLmayWesSyHiRwmdoZiSMdJn.MivuigqsvilXZPyHFfYcXaZxpRCA mivuigqsvilXZPyHFfYcXaZxpRCA = null;
			foreach (dQnsyLmayWesSyHiRwmdoZiSMdJn.MivuigqsvilXZPyHFfYcXaZxpRCA item in PnZmdWEUUJCVLDLReAFHdMzrXPBy.jFIFrmqGgSqOuPNNWmRTcAuoplju(eksNrmuJaxejvDOZiWixMQzTZYUlA2, P_2))
			{
				if (!YAITzbKBBPuhQPJWxhVHzNjOSlud(P_1, item.BDVmeVfneJsORVOcygisqMtTMouk) && item.sWvArbLRRPYlgjKyHcdalaQHeaBjA >= 0)
				{
					mivuigqsvilXZPyHFfYcXaZxpRCA = item;
					break;
				}
			}
			if (mivuigqsvilXZPyHFfYcXaZxpRCA != null)
			{
				int num = mivuigqsvilXZPyHFfYcXaZxpRCA.sWvArbLRRPYlgjKyHcdalaQHeaBjA;
				if (!ngWtWORtvXZXSwpNTFgmpXGKZiH(P_1, num))
				{
					num = (mivuigqsvilXZPyHFfYcXaZxpRCA.sWvArbLRRPYlgjKyHcdalaQHeaBjA = tRgNKQnECbGRsVfVettZYHOxNuT(P_1));
				}
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = mivuigqsvilXZPyHFfYcXaZxpRCA.BDVmeVfneJsORVOcygisqMtTMouk;
				PnZmdWEUUJCVLDLReAFHdMzrXPBy.BHsciGRGJGDIPBRepVZgezZJAuRdA(eksNrmuJaxejvDOZiWixMQzTZYUlA2);
			}
		}
	}

	private void hHWsfFlWnSclCJkrpRmWiCNLSdYA()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (jjuWdDormEBZtfbxTUctujnQLliJA || XsZJyfIOBqwohGpAduiitykSQazu(joystickNames))
		{
			msTNfwKuEQbamivQidJGVhTdoKCG(joystickNames);
		}
		uSGiMuXctHaMcnuopqDPyovAEDBV = false;
		if (jjuWdDormEBZtfbxTUctujnQLliJA)
		{
			jjuWdDormEBZtfbxTUctujnQLliJA = false;
		}
	}

	private bool XsZJyfIOBqwohGpAduiitykSQazu(string[] P_0)
	{
		if (P_0.Length != NGxGqXoieeqUzOUHHaCzVrcHCIGt.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], NGxGqXoieeqUzOUHHaCzVrcHCIGt[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void RebMXBFBpDoPUfCjtavMcuLwtEhp(List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_0, List<eksNrmuJaxejvDOZiWixMQzTZYUlA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA2 = P_0[i];
			if (eksNrmuJaxejvDOZiWixMQzTZYUlA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					eksNrmuJaxejvDOZiWixMQzTZYUlA eksNrmuJaxejvDOZiWixMQzTZYUlA3 = P_1[j];
					if (eksNrmuJaxejvDOZiWixMQzTZYUlA3 != null && eksNrmuJaxejvDOZiWixMQzTZYUlA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == eksNrmuJaxejvDOZiWixMQzTZYUlA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				mszfqTKousvZHALqmBzlzIxpgRRK(P_0[i], P_2);
			}
		}
	}

	private void mszfqTKousvZHALqmBzlzIxpgRRK(eksNrmuJaxejvDOZiWixMQzTZYUlA P_0, bool P_1)
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

	private void amxhJTwIwfwlIRRaucFFIUjitmKB()
	{
		if (MhHRJDslzrByHqTIEDwYjdoCFTrL == YstqJQEaUNEADMpArhLhLTQLMYkU && WYBuvgwGTrYSIPnrwTIHdppOuWRv.Update())
		{
			uSGiMuXctHaMcnuopqDPyovAEDBV = true;
			WYBuvgwGTrYSIPnrwTIHdppOuWRv.Start();
		}
	}
}
