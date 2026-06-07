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

internal class iiaEEuCRUcoidSBfrqKsFQaITgQFA : PlatformInputManager
{
	private class xyDbjxneddYDOsTFJNRjnxmgDypr : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int zXkgPIGQaSypjbCOAQeYvEGzvnpAA;

		private int aoluEsHUlGRuMWeiSybrpYVEvTce;

		private int iEWMWvYhXUEZpOOvfJhkyEABSoRk;

		public Guid AnTbdyNktTUsrOhkQZiaqGiKxspO;

		public string AQIHuGLEfWrpxzQRKCCAKpkvzGLS;

		public int qIDnUfVmOVjlqCaYijvrcVQsQfvWA;

		public string SeHWdrcdmWurqwHoCGhUGcitkvCAb;

		public string GSMGQRCLAVibnCpDECIDbOuxEgxyb;

		public string fNOZMAIqpBmKsbCQLCBRCELKNAZb;

		private int YwXevxFPscwTJsMqOCzYMHwGEyS = 29;

		private int MOseuUubfmHqjwVDdceonoXSUfko = 20;

		private float[] sYOLxnTgzmbPKmPwgECGxkfqmhJe;

		private bool[] ffoDrjucYTCQinEfGpeOorGKYErB;

		private bool[] dpmgRMHjEDVHblLlolJvWmihnIdEb;

		private float[] gikVrUcYZRhGycDKeninetDQHVkP;

		private bool[] lfqrtwnOAPfewvOerOycRhDkkFtH;

		private HardwareJoystickMap_InputManager nxZmeIgwJlEvqxdIFZJqaPERxWSp;

		private bool fuSWZyTYhWiultoNcdGtgEffuYjU;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return zXkgPIGQaSypjbCOAQeYvEGzvnpAA;
			}
			set
			{
				zXkgPIGQaSypjbCOAQeYvEGzvnpAA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return aoluEsHUlGRuMWeiSybrpYVEvTce;
			}
			set
			{
				aoluEsHUlGRuMWeiSybrpYVEvTce = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(AQIHuGLEfWrpxzQRKCCAKpkvzGLS != "Unknown Controller"))
				{
					return SeHWdrcdmWurqwHoCGhUGcitkvCAb;
				}
				return AQIHuGLEfWrpxzQRKCCAKpkvzGLS;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (iEWMWvYhXUEZpOOvfJhkyEABSoRk < 1)
				{
					return null;
				}
				return iEWMWvYhXUEZpOOvfJhkyEABSoRk;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return iEWMWvYhXUEZpOOvfJhkyEABSoRk;
			}
			set
			{
				iEWMWvYhXUEZpOOvfJhkyEABSoRk = value;
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
					return MiscTools.CreateGuidHashSHA1(SeHWdrcdmWurqwHoCGhUGcitkvCAb);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + iEWMWvYhXUEZpOOvfJhkyEABSoRk);
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		public int feOBxsAqwcMyrLRJAnsSVJZPPKqjb => MOseuUubfmHqjwVDdceonoXSUfko;

		public int elYCwSHlpwUPhBRagsiFABFfysviB => YwXevxFPscwTJsMqOCzYMHwGEyS;

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

		public xyDbjxneddYDOsTFJNRjnxmgDypr()
		{
			aoluEsHUlGRuMWeiSybrpYVEvTce = -1;
			zXkgPIGQaSypjbCOAQeYvEGzvnpAA = -1;
			iEWMWvYhXUEZpOOvfJhkyEABSoRk = 0;
		}

		public void JnCMmASILYnHHqglljOGSFWDAgFv()
		{
			huLNadejojLPkRgkpQdFXxnbWoLN();
			AnTbdyNktTUsrOhkQZiaqGiKxspO = nxZmeIgwJlEvqxdIFZJqaPERxWSp.hardwareMapIdentifier.guid;
			AQIHuGLEfWrpxzQRKCCAKpkvzGLS = nxZmeIgwJlEvqxdIFZJqaPERxWSp.controllerName;
			sYOLxnTgzmbPKmPwgECGxkfqmhJe = new float[YwXevxFPscwTJsMqOCzYMHwGEyS];
			ffoDrjucYTCQinEfGpeOorGKYErB = new bool[MOseuUubfmHqjwVDdceonoXSUfko];
			dpmgRMHjEDVHblLlolJvWmihnIdEb = new bool[YwXevxFPscwTJsMqOCzYMHwGEyS];
			lfqrtwnOAPfewvOerOycRhDkkFtH = new bool[29];
			gikVrUcYZRhGycDKeninetDQHVkP = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (iEWMWvYhXUEZpOOvfJhkyEABSoRk > 0)
			{
				ZEQIWhRSSjiolcojXNNgUXrIdhFy();
				NYFNzmZWVRKHStgvtHXlKayGKuQl();
				VSsAPYxlvoYPqQWZozEcyfAGDkHo();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int WvScxadrIyMBYaOdxhDhgAjvWgxFb(xyDbjxneddYDOsTFJNRjnxmgDypr P_0)
		{
			if (feOBxsAqwcMyrLRJAnsSVJZPPKqjb != P_0.feOBxsAqwcMyrLRJAnsSVJZPPKqjb || elYCwSHlpwUPhBRagsiFABFfysviB != P_0.elYCwSHlpwUPhBRagsiFABFfysviB)
			{
				return 0;
			}
			if ((!string.IsNullOrEmpty(GSMGQRCLAVibnCpDECIDbOuxEgxyb) || !string.IsNullOrEmpty(P_0.GSMGQRCLAVibnCpDECIDbOuxEgxyb)) && !string.Equals(GSMGQRCLAVibnCpDECIDbOuxEgxyb, P_0.GSMGQRCLAVibnCpDECIDbOuxEgxyb, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.SeHWdrcdmWurqwHoCGhUGcitkvCAb == SeHWdrcdmWurqwHoCGhUGcitkvCAb && P_0.qIDnUfVmOVjlqCaYijvrcVQsQfvWA == qIDnUfVmOVjlqCaYijvrcVQsQfvWA)
			{
				return 2;
			}
			if (P_0.SeHWdrcdmWurqwHoCGhUGcitkvCAb == SeHWdrcdmWurqwHoCGhUGcitkvCAb)
			{
				return 1;
			}
			return 0;
		}

		private void jnXcxXdmrGxHsoUEbduJcdQfJcpMc(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = IbgonlWQxbrkMSeDphVxeJIEiKLX();
			P_0.hardwareIdentifier = MFGGKqGeZQuQQLnKhlPiXrkboYuF();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = SeHWdrcdmWurqwHoCGhUGcitkvCAb;
		}

		private void NdWDoiJpKfuBLGKvQrEyTtkRWOIC(BridgedController P_0)
		{
			jnXcxXdmrGxHsoUEbduJcdQfJcpMc(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = nxZmeIgwJlEvqxdIFZJqaPERxWSp.ToGameHardwareControllerMap();
			P_0.instanceName = SeHWdrcdmWurqwHoCGhUGcitkvCAb;
			P_0.productName = SeHWdrcdmWurqwHoCGhUGcitkvCAb;
			P_0.isXInputDevice = false;
			P_0.axisCount = YwXevxFPscwTJsMqOCzYMHwGEyS;
			P_0.buttonCount = MOseuUubfmHqjwVDdceonoXSUfko;
			P_0.controllerTypeGuid = AnTbdyNktTUsrOhkQZiaqGiKxspO;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (YwXevxFPscwTJsMqOCzYMHwGEyS != dataUpdater.axisCount || MOseuUubfmHqjwVDdceonoXSUfko != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < YwXevxFPscwTJsMqOCzYMHwGEyS; i++)
			{
				if (axisValues[i] != sYOLxnTgzmbPKmPwgECGxkfqmhJe[i])
				{
					axisValues[i] = sYOLxnTgzmbPKmPwgECGxkfqmhJe[i];
					if (axisHasBeenPressedOSXLinux[i] != dpmgRMHjEDVHblLlolJvWmihnIdEb[i])
					{
						axisHasBeenPressedOSXLinux[i] = dpmgRMHjEDVHblLlolJvWmihnIdEb[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < MOseuUubfmHqjwVDdceonoXSUfko; j++)
			{
				if (buttonValues[j] != ffoDrjucYTCQinEfGpeOorGKYErB[j])
				{
					buttonValues[j] = ffoDrjucYTCQinEfGpeOorGKYErB[j];
				}
			}
			if (fuSWZyTYhWiultoNcdGtgEffuYjU && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void OOXbVvLFEYCieexNbHHAUIdxiSnj(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void QNMszIiVMwQAuokkqfULAndFDUbjA()
		{
			iEWMWvYhXUEZpOOvfJhkyEABSoRk = 0;
			sLdHDJCPlfGpMeKBePclQmjUinFqA();
		}

		public BridgedControllerHWInfo OXfageaKSRKmPDQkDiPtMDWMgaYrA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			jnXcxXdmrGxHsoUEbduJcdQfJcpMc(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			NdWDoiJpKfuBLGKvQrEyTtkRWOIC(bridgedController);
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
			return new ControllerDisconnectedEventArgs(zXkgPIGQaSypjbCOAQeYvEGzvnpAA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void ZEQIWhRSSjiolcojXNNgUXrIdhFy()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(iEWMWvYhXUEZpOOvfJhkyEABSoRk, i);
				if (gikVrUcYZRhGycDKeninetDQHVkP[i] != joystickAxisValueByJoystickId)
				{
					gikVrUcYZRhGycDKeninetDQHVkP[i] = joystickAxisValueByJoystickId;
					if (!lfqrtwnOAPfewvOerOycRhDkkFtH[i] && joystickAxisValueByJoystickId != 0f)
					{
						lfqrtwnOAPfewvOerOycRhDkkFtH[i] = true;
					}
				}
			}
		}

		private void NYFNzmZWVRKHStgvtHXlKayGKuQl()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)nxZmeIgwJlEvqxdIFZJqaPERxWSp.map).Axes_orig;
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
				if (i >= YwXevxFPscwTJsMqOCzYMHwGEyS)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = SWJpNsIaqcFiVluRZCnbjEoyZzOuA(axes_orig[i]);
				if (sYOLxnTgzmbPKmPwgECGxkfqmhJe[i] == num)
				{
					continue;
				}
				sYOLxnTgzmbPKmPwgECGxkfqmhJe[i] = num;
				if (!dpmgRMHjEDVHblLlolJvWmihnIdEb[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(axes_orig[i].sourceAxis);
						dpmgRMHjEDVHblLlolJvWmihnIdEb[i] = num2 != 0f;
					}
					else
					{
						dpmgRMHjEDVHblLlolJvWmihnIdEb[i] = true;
					}
				}
				if (!fuSWZyTYhWiultoNcdGtgEffuYjU && sYOLxnTgzmbPKmPwgECGxkfqmhJe[i] != 0f)
				{
					fuSWZyTYhWiultoNcdGtgEffuYjU = true;
				}
			}
		}

		private void VSsAPYxlvoYPqQWZozEcyfAGDkHo()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)nxZmeIgwJlEvqxdIFZJqaPERxWSp.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= MOseuUubfmHqjwVDdceonoXSUfko)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = cfpMdWJOAqabmxkPJOxsKzQlpHxu(buttons_orig[i]);
				if (ffoDrjucYTCQinEfGpeOorGKYErB[i] != flag)
				{
					ffoDrjucYTCQinEfGpeOorGKYErB[i] = flag;
					if (!fuSWZyTYhWiultoNcdGtgEffuYjU && ffoDrjucYTCQinEfGpeOorGKYErB[i])
					{
						fuSWZyTYhWiultoNcdGtgEffuYjU = true;
					}
				}
			}
		}

		private bool cfpMdWJOAqabmxkPJOxsKzQlpHxu(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (xJPRgFkXumsABuNTyGPqXpDebAaq(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!xJPRgFkXumsABuNTyGPqXpDebAaq(P_0.requiredButtons[j]))
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
				return xJPRgFkXumsABuNTyGPqXpDebAaq(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(P_0.sourceAxis);
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
				float num2 = sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(unityHat_sourceAxis);
				float num3 = sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (DJEQfNKFylLFWjnBndsXfttLdvFab(unityHat_sourceAxis) || DJEQfNKFylLFWjnBndsXfttLdvFab(unityHat_sourceAxis2))
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
				if (gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues1.x, num2) && gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues2.x, num2) && gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues3.x, num2) && gAGpappleCexfjLKTzvtWkShqnBv(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (HNmBlWdmErcvVWHRxzJBKSxvkzmuA(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (TtiUqAApXXXZfHgEQbCPoINWDIlaA(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (AclQWnEYMuxDDtufmcEeHYrvpfdj(customCalculationSourceData[k], out var flag2))
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

		private bool gAGpappleCexfjLKTzvtWkShqnBv(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float SWJpNsIaqcFiVluRZCnbjEoyZzOuA(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!DJEQfNKFylLFWjnBndsXfttLdvFab(P_0.sourceAxis))
				{
					return 0f;
				}
				return sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!xJPRgFkXumsABuNTyGPqXpDebAaq(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && TtiUqAApXXXZfHgEQbCPoINWDIlaA(customCalculationSourceData[i], out var item))
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

		private float sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return gikVrUcYZRhGycDKeninetDQHVkP[num];
		}

		private bool xJPRgFkXumsABuNTyGPqXpDebAaq(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(iEWMWvYhXUEZpOOvfJhkyEABSoRk, buttonIndex);
		}

		private bool HNmBlWdmErcvVWHRxzJBKSxvkzmuA(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = xJPRgFkXumsABuNTyGPqXpDebAaq(sourceElement);
			return true;
		}

		private bool AclQWnEYMuxDDtufmcEeHYrvpfdj(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool TtiUqAApXXXZfHgEQbCPoINWDIlaA(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = sYWUyYrDAfwBAkDZBiFJMOHoKIHQ(sourceElement);
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

		private bool DJEQfNKFylLFWjnBndsXfttLdvFab(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return lfqrtwnOAPfewvOerOycRhDkkFtH[num];
		}

		private void huLNadejojLPkRgkpQdFXxnbWoLN()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = OXfageaKSRKmPDQkDiPtMDWMgaYrA();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(SeHWdrcdmWurqwHoCGhUGcitkvCAb, "Xbox Wireless Controller.*"))
				{
					UnityTools.externalTools.GetDeviceVIDPIDs(out var vids, out var pids);
					for (int i = 0; i < vids.Count; i++)
					{
						if (vids[i] == 1118 && pids[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							fNOZMAIqpBmKsbCQLCBRCELKNAZb = bridgedControllerHWInfo.definitionMatchTag;
							break;
						}
					}
				}
				else if (UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(SeHWdrcdmWurqwHoCGhUGcitkvCAb))
					{
						if (ds4Helper.IsDS4KeyMapped(qIDnUfVmOVjlqCaYijvrcVQsQfvWA))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
						fNOZMAIqpBmKsbCQLCBRCELKNAZb = bridgedControllerHWInfo.definitionMatchTag;
					}
				}
			}
			nxZmeIgwJlEvqxdIFZJqaPERxWSp = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (nxZmeIgwJlEvqxdIFZJqaPERxWSp == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && nxZmeIgwJlEvqxdIFZJqaPERxWSp.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = yAdrTkADwDAMvbxTjCaucKbLQbpNA(SeHWdrcdmWurqwHoCGhUGcitkvCAb);
				if (!string.IsNullOrEmpty(text))
				{
					nxZmeIgwJlEvqxdIFZJqaPERxWSp.controllerName = text;
					if (nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys[0]))
					{
						nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys[0], text));
					}
					nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (nxZmeIgwJlEvqxdIFZJqaPERxWSp.useSystemName && !string.IsNullOrEmpty(SeHWdrcdmWurqwHoCGhUGcitkvCAb))
			{
				string text2 = Regex.Replace(SeHWdrcdmWurqwHoCGhUGcitkvCAb, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					nxZmeIgwJlEvqxdIFZJqaPERxWSp.controllerName = text2;
					if (nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys[0]))
					{
						nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.parentKeys[0], text2));
					}
					nxZmeIgwJlEvqxdIFZJqaPERxWSp.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			YwXevxFPscwTJsMqOCzYMHwGEyS = nxZmeIgwJlEvqxdIFZJqaPERxWSp.axisCount;
			MOseuUubfmHqjwVDdceonoXSUfko = nxZmeIgwJlEvqxdIFZJqaPERxWSp.buttonCount;
		}

		private void sLdHDJCPlfGpMeKBePclQmjUinFqA()
		{
			Array.Clear(ffoDrjucYTCQinEfGpeOorGKYErB, 0, ffoDrjucYTCQinEfGpeOorGKYErB.Length);
			Array.Clear(sYOLxnTgzmbPKmPwgECGxkfqmhJe, 0, sYOLxnTgzmbPKmPwgECGxkfqmhJe.Length);
		}

		private string MFGGKqGeZQuQQLnKhlPiXrkboYuF()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{IbgonlWQxbrkMSeDphVxeJIEiKLX().ToString()}{SeHWdrcdmWurqwHoCGhUGcitkvCAb}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(SeHWdrcdmWurqwHoCGhUGcitkvCAb, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{IbgonlWQxbrkMSeDphVxeJIEiKLX().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{IbgonlWQxbrkMSeDphVxeJIEiKLX().ToString()}{SeHWdrcdmWurqwHoCGhUGcitkvCAb}");
		}

		private InputSource IbgonlWQxbrkMSeDphVxeJIEiKLX()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(SeHWdrcdmWurqwHoCGhUGcitkvCAb))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int LkZsneyPrkFuygroamYoqROTuavy(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, xyDbjxneddYDOsTFJNRjnxmgDypr P_1)
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

		public static int qudVBdjmtWNCWfrBOLcUfzJkHToN(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, xyDbjxneddYDOsTFJNRjnxmgDypr P_1)
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

		private static string yAdrTkADwDAMvbxTjCaucKbLQbpNA(string P_0)
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

	private class ooIwhKvFvCGKbSVmgVVpVkpdZFmU
	{
		public class XYXzyzdTbbHXclDmagWImJngYTux
		{
			public int OZgIuYspjXAYyrkuDPNgPdomGcHgA;

			public int ykhwjbwRcRyASAUfMcOfPkQHoYyA;

			public string sUkHuvGDGwosknizkXQXufceDcJjA;

			public int fIKNjmUYOPpDVZtcyEGmOjZaEEiDA;

			public string GotHNlqZXHqCegzFMxXYGGIjbxto;

			public string PIFYusFMNneURGozbnaPcALBMvUwb;

			public int tNUGcWDhacrruUmGSLTUucCHZKdqA;

			public int VvMdVbmWYuGCTFLCEqRtldUkMQyRA;

			public XYXzyzdTbbHXclDmagWImJngYTux(int P_0, int P_1, string P_2, int P_3, string P_4, string P_5, int P_6, int P_7)
			{
				OZgIuYspjXAYyrkuDPNgPdomGcHgA = P_0;
				ykhwjbwRcRyASAUfMcOfPkQHoYyA = P_1;
				sUkHuvGDGwosknizkXQXufceDcJjA = P_2;
				fIKNjmUYOPpDVZtcyEGmOjZaEEiDA = P_3;
				GotHNlqZXHqCegzFMxXYGGIjbxto = P_4;
				PIFYusFMNneURGozbnaPcALBMvUwb = P_5;
				tNUGcWDhacrruUmGSLTUucCHZKdqA = P_6;
				VvMdVbmWYuGCTFLCEqRtldUkMQyRA = P_7;
			}

			public bool odNuJxKYXbHltPDKFRNFtlAXRzcn(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, PSvmIrmJmLALetYNpkcOIUEodMED P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == OZgIuYspjXAYyrkuDPNgPdomGcHgA)
				{
					return true;
				}
				if (tNUGcWDhacrruUmGSLTUucCHZKdqA != P_0.feOBxsAqwcMyrLRJAnsSVJZPPKqjb || VvMdVbmWYuGCTFLCEqRtldUkMQyRA != P_0.elYCwSHlpwUPhBRagsiFABFfysviB)
				{
					return false;
				}
				if ((!string.IsNullOrEmpty(GotHNlqZXHqCegzFMxXYGGIjbxto) || !string.IsNullOrEmpty(P_0.GSMGQRCLAVibnCpDECIDbOuxEgxyb)) && !string.Equals(GotHNlqZXHqCegzFMxXYGGIjbxto, P_0.GSMGQRCLAVibnCpDECIDbOuxEgxyb, StringComparison.Ordinal))
				{
					return false;
				}
				if ((!string.IsNullOrEmpty(PIFYusFMNneURGozbnaPcALBMvUwb) || !string.IsNullOrEmpty(P_0.fNOZMAIqpBmKsbCQLCBRCELKNAZb)) && !string.Equals(PIFYusFMNneURGozbnaPcALBMvUwb, P_0.fNOZMAIqpBmKsbCQLCBRCELKNAZb, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case PSvmIrmJmLALetYNpkcOIUEodMED.Exact:
					if (ykhwjbwRcRyASAUfMcOfPkQHoYyA == P_0.qIDnUfVmOVjlqCaYijvrcVQsQfvWA)
					{
						return sUkHuvGDGwosknizkXQXufceDcJjA == P_0.SeHWdrcdmWurqwHoCGhUGcitkvCAb;
					}
					return false;
				case PSvmIrmJmLALetYNpkcOIUEodMED.Approximate:
					return sUkHuvGDGwosknizkXQXufceDcJjA == P_0.SeHWdrcdmWurqwHoCGhUGcitkvCAb;
				default:
					throw new NotImplementedException();
				}
			}
		}

		public enum PSvmIrmJmLALetYNpkcOIUEodMED
		{
			Exact = 0,
			Approximate = 1
		}

		private sealed class UIqTYVOUEHNgpSvYgcExcUdfpOXg : IEnumerable<XYXzyzdTbbHXclDmagWImJngYTux>, IEnumerable, IEnumerator<XYXzyzdTbbHXclDmagWImJngYTux>, IEnumerator, IDisposable
		{
			private int VDgOAGaavSwDAaVTuQnEGJNddmxw;

			private XYXzyzdTbbHXclDmagWImJngYTux lEEtMjZmjXGFrIJiVIvPvhzqbtWvA;

			private int aWmbcjVGdFTbPioMeLrkuyQKBZiv;

			public ooIwhKvFvCGKbSVmgVVpVkpdZFmU bfpZbyyaevHhDgaTCMcorbJTSySE;

			private xyDbjxneddYDOsTFJNRjnxmgDypr kJarYsUAydDOVWwDAHBRfFyBvOWMA;

			public xyDbjxneddYDOsTFJNRjnxmgDypr ETXeOgBGhjMrNYevMCuyHhryubLc;

			private PSvmIrmJmLALetYNpkcOIUEodMED ZTgiMPEGxioBwhBzCGrWwlDyHRcr;

			public PSvmIrmJmLALetYNpkcOIUEodMED oEEIhbqqOzdYliPQnwtjlFaMgWbM;

			private int ZkGmtadYITDhaBBHFNEiTKPxKVqR;

			private int iIhnylxSldvDfDZbntyhKVfptfxo;

			XYXzyzdTbbHXclDmagWImJngYTux IEnumerator<XYXzyzdTbbHXclDmagWImJngYTux>.Current
			{
				[DebuggerHidden]
				get
				{
					return lEEtMjZmjXGFrIJiVIvPvhzqbtWvA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return lEEtMjZmjXGFrIJiVIvPvhzqbtWvA;
				}
			}

			[DebuggerHidden]
			public UIqTYVOUEHNgpSvYgcExcUdfpOXg(int P_0)
			{
				VDgOAGaavSwDAaVTuQnEGJNddmxw = P_0;
				aWmbcjVGdFTbPioMeLrkuyQKBZiv = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				VDgOAGaavSwDAaVTuQnEGJNddmxw = -2;
			}

			private bool MoveNext()
			{
				int vDgOAGaavSwDAaVTuQnEGJNddmxw = VDgOAGaavSwDAaVTuQnEGJNddmxw;
				ooIwhKvFvCGKbSVmgVVpVkpdZFmU ooIwhKvFvCGKbSVmgVVpVkpdZFmU2 = bfpZbyyaevHhDgaTCMcorbJTSySE;
				if (vDgOAGaavSwDAaVTuQnEGJNddmxw != 0)
				{
					if (vDgOAGaavSwDAaVTuQnEGJNddmxw != 1)
					{
						return false;
					}
					VDgOAGaavSwDAaVTuQnEGJNddmxw = -1;
					goto IL_0083;
				}
				VDgOAGaavSwDAaVTuQnEGJNddmxw = -1;
				ZkGmtadYITDhaBBHFNEiTKPxKVqR = ooIwhKvFvCGKbSVmgVVpVkpdZFmU2.uqxtpICCyFlGEzwtUITvrEsAOXxv.Count;
				iIhnylxSldvDfDZbntyhKVfptfxo = 0;
				goto IL_0093;
				IL_0083:
				iIhnylxSldvDfDZbntyhKVfptfxo++;
				goto IL_0093;
				IL_0093:
				if (iIhnylxSldvDfDZbntyhKVfptfxo < ZkGmtadYITDhaBBHFNEiTKPxKVqR)
				{
					if (ooIwhKvFvCGKbSVmgVVpVkpdZFmU2.uqxtpICCyFlGEzwtUITvrEsAOXxv[iIhnylxSldvDfDZbntyhKVfptfxo].odNuJxKYXbHltPDKFRNFtlAXRzcn(kJarYsUAydDOVWwDAHBRfFyBvOWMA, ZTgiMPEGxioBwhBzCGrWwlDyHRcr))
					{
						lEEtMjZmjXGFrIJiVIvPvhzqbtWvA = ooIwhKvFvCGKbSVmgVVpVkpdZFmU2.uqxtpICCyFlGEzwtUITvrEsAOXxv[iIhnylxSldvDfDZbntyhKVfptfxo];
						VDgOAGaavSwDAaVTuQnEGJNddmxw = 1;
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
			IEnumerator<XYXzyzdTbbHXclDmagWImJngYTux> IEnumerable<XYXzyzdTbbHXclDmagWImJngYTux>.GetEnumerator()
			{
				UIqTYVOUEHNgpSvYgcExcUdfpOXg uIqTYVOUEHNgpSvYgcExcUdfpOXg;
				if (VDgOAGaavSwDAaVTuQnEGJNddmxw == -2 && aWmbcjVGdFTbPioMeLrkuyQKBZiv == Environment.CurrentManagedThreadId)
				{
					VDgOAGaavSwDAaVTuQnEGJNddmxw = 0;
					uIqTYVOUEHNgpSvYgcExcUdfpOXg = this;
				}
				else
				{
					uIqTYVOUEHNgpSvYgcExcUdfpOXg = new UIqTYVOUEHNgpSvYgcExcUdfpOXg(0);
					uIqTYVOUEHNgpSvYgcExcUdfpOXg.bfpZbyyaevHhDgaTCMcorbJTSySE = bfpZbyyaevHhDgaTCMcorbJTSySE;
				}
				uIqTYVOUEHNgpSvYgcExcUdfpOXg.kJarYsUAydDOVWwDAHBRfFyBvOWMA = ETXeOgBGhjMrNYevMCuyHhryubLc;
				uIqTYVOUEHNgpSvYgcExcUdfpOXg.ZTgiMPEGxioBwhBzCGrWwlDyHRcr = oEEIhbqqOzdYliPQnwtjlFaMgWbM;
				return uIqTYVOUEHNgpSvYgcExcUdfpOXg;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<XYXzyzdTbbHXclDmagWImJngYTux>)this).GetEnumerator();
			}
		}

		private List<XYXzyzdTbbHXclDmagWImJngYTux> uqxtpICCyFlGEzwtUITvrEsAOXxv;

		public int DkIlgOIarjEGEjXxHXisbSdlTbZy => uqxtpICCyFlGEzwtUITvrEsAOXxv.Count;

		public ooIwhKvFvCGKbSVmgVVpVkpdZFmU()
		{
			uqxtpICCyFlGEzwtUITvrEsAOXxv = new List<XYXzyzdTbbHXclDmagWImJngYTux>();
		}

		public void GBFoaRIbCAJwccrgKFeiWMWmWQgiA(xyDbjxneddYDOsTFJNRjnxmgDypr P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = uqxtpICCyFlGEzwtUITvrEsAOXxv.Count;
			for (int i = 0; i < count; i++)
			{
				if (uqxtpICCyFlGEzwtUITvrEsAOXxv[i].odNuJxKYXbHltPDKFRNFtlAXRzcn(P_0, PSvmIrmJmLALetYNpkcOIUEodMED.Exact))
				{
					WnishralRBlBNovAsrPpuzUxkmhX(uqxtpICCyFlGEzwtUITvrEsAOXxv[i], P_0);
					return;
				}
			}
			uqxtpICCyFlGEzwtUITvrEsAOXxv.Add(new XYXzyzdTbbHXclDmagWImJngYTux(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.qIDnUfVmOVjlqCaYijvrcVQsQfvWA, P_0.SeHWdrcdmWurqwHoCGhUGcitkvCAb, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId, P_0.GSMGQRCLAVibnCpDECIDbOuxEgxyb, P_0.fNOZMAIqpBmKsbCQLCBRCELKNAZb, P_0.feOBxsAqwcMyrLRJAnsSVJZPPKqjb, P_0.elYCwSHlpwUPhBRagsiFABFfysviB));
			KBsrjUZvvJGSgpGVXQODQxdcOIZw(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, uqxtpICCyFlGEzwtUITvrEsAOXxv.Count - 1);
		}

		public void WnishralRBlBNovAsrPpuzUxkmhX(XYXzyzdTbbHXclDmagWImJngYTux P_0, xyDbjxneddYDOsTFJNRjnxmgDypr P_1)
		{
			int num = uqxtpICCyFlGEzwtUITvrEsAOXxv.IndexOf(P_0);
			if (num >= 0)
			{
				P_0.OZgIuYspjXAYyrkuDPNgPdomGcHgA = P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				P_0.sUkHuvGDGwosknizkXQXufceDcJjA = P_1.SeHWdrcdmWurqwHoCGhUGcitkvCAb;
				P_0.ykhwjbwRcRyASAUfMcOfPkQHoYyA = P_1.qIDnUfVmOVjlqCaYijvrcVQsQfvWA;
				P_0.fIKNjmUYOPpDVZtcyEGmOjZaEEiDA = P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
				P_0.GotHNlqZXHqCegzFMxXYGGIjbxto = P_1.GSMGQRCLAVibnCpDECIDbOuxEgxyb;
				P_0.PIFYusFMNneURGozbnaPcALBMvUwb = P_1.fNOZMAIqpBmKsbCQLCBRCELKNAZb;
				P_0.tNUGcWDhacrruUmGSLTUucCHZKdqA = P_1.feOBxsAqwcMyrLRJAnsSVJZPPKqjb;
				P_0.VvMdVbmWYuGCTFLCEqRtldUkMQyRA = P_1.elYCwSHlpwUPhBRagsiFABFfysviB;
				KBsrjUZvvJGSgpGVXQODQxdcOIZw(P_1.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, num);
			}
		}

		public bool OHMRlztRobYpukGutspXyMbpMpqg(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, PSvmIrmJmLALetYNpkcOIUEodMED P_1)
		{
			int count = uqxtpICCyFlGEzwtUITvrEsAOXxv.Count;
			for (int i = 0; i < count; i++)
			{
				if (uqxtpICCyFlGEzwtUITvrEsAOXxv[i].odNuJxKYXbHltPDKFRNFtlAXRzcn(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(UIqTYVOUEHNgpSvYgcExcUdfpOXg))]
		public IEnumerable<XYXzyzdTbbHXclDmagWImJngYTux> qbrngrfelMjgXxxZvLmHNqpBDJSm(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, PSvmIrmJmLALetYNpkcOIUEodMED P_1)
		{
			return new UIqTYVOUEHNgpSvYgcExcUdfpOXg(-2)
			{
				bfpZbyyaevHhDgaTCMcorbJTSySE = this,
				ETXeOgBGhjMrNYevMCuyHhryubLc = P_0,
				oEEIhbqqOzdYliPQnwtjlFaMgWbM = P_1
			};
		}

		public int QDrQEAqnqDhvRHVtumYmxRFBKyWR(XYXzyzdTbbHXclDmagWImJngYTux P_0)
		{
			int count = uqxtpICCyFlGEzwtUITvrEsAOXxv.Count;
			for (int i = 0; i < count; i++)
			{
				if (uqxtpICCyFlGEzwtUITvrEsAOXxv[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void KBsrjUZvvJGSgpGVXQODQxdcOIZw(int P_0, int P_1)
		{
			for (int num = uqxtpICCyFlGEzwtUITvrEsAOXxv.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && uqxtpICCyFlGEzwtUITvrEsAOXxv[num].OZgIuYspjXAYyrkuDPNgPdomGcHgA == P_0)
				{
					uqxtpICCyFlGEzwtUITvrEsAOXxv.RemoveAt(num);
				}
			}
		}
	}

	private List<xyDbjxneddYDOsTFJNRjnxmgDypr> blyigJTRfJuPIYWuRTYJHEQNIeur;

	private int XsSiLWKIpOunXllNRhKAKgkiGCMYA;

	private ooIwhKvFvCGKbSVmgVVpVkpdZFmU QwgchDXOZRkdsnIVHcUPOZcOzgmJ;

	private bool rljQotElcZdaRPdiKeiBcNujBxoJA;

	private bool mUHrUprxIAzQyBfVyXpcAyZbVZhc;

	private UpdateLoopType LwoBkEjcwdWGyUfWjoMGMahrdsMm;

	private UpdateLoopType ZKCRgJXtNBvoyuOMEhsliuJimcHs;

	private TimerAbs LegrfftMalsglbhzZbvVUOqbiRsl;

	private Action<int, ControllerDataUpdater> NEWOZBfmSfmoaMAJgXrqVBJJEtWI;

	private PlatformInputManager EczElSbtWlIjyEPWigNdejeEfOXHc;

	private readonly IUnifiedKeyboardSource EpxPwIcStqQOHwuuRKkYezsYyNVF;

	private readonly IUnifiedMouseSource ankzXZfeMRfvyzoFNapKmRSovxnq;

	private bool DsvvscdKekFPvgvCZisZSvvVjHLIb;

	private string[] QvUapUbuhagpYuAFonMjchWqoenh;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => XsSiLWKIpOunXllNRhKAKgkiGCMYA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => EczElSbtWlIjyEPWigNdejeEfOXHc;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public iiaEEuCRUcoidSBfrqKsFQaITgQFA(UpdateLoopSetting P_0)
	{
		EczElSbtWlIjyEPWigNdejeEfOXHc = this;
		EpxPwIcStqQOHwuuRKkYezsYyNVF = new UnityUnifiedKeyboardSource();
		ankzXZfeMRfvyzoFNapKmRSovxnq = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				ZKCRgJXtNBvoyuOMEhsliuJimcHs = list[num];
			}
		}
		QvUapUbuhagpYuAFonMjchWqoenh = new string[0];
		NEWOZBfmSfmoaMAJgXrqVBJJEtWI = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM != null)
		{
			UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM.DeviceChangedEvent += jUAUCsZkLNFXKLfBJXnnBREHcqxD;
		}
		LegrfftMalsglbhzZbvVUOqbiRsl = new TimerAbs(1.0);
		QwgchDXOZRkdsnIVHcUPOZcOzgmJ = new ooIwhKvFvCGKbSVmgVVpVkpdZFmU();
		cIHIQmVJiuKdkNqWLGrzbdrtCrhwA();
		rljQotElcZdaRPdiKeiBcNujBxoJA = true;
		LegrfftMalsglbhzZbvVUOqbiRsl.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		LwoBkEjcwdWGyUfWjoMGMahrdsMm = updateLoop;
		vPKUdQrORpVSEppLDCRJznHTaZDGA();
		if (rljQotElcZdaRPdiKeiBcNujBxoJA)
		{
			unmYywcwFvuWCpAgAqmkLwXwquCt();
		}
		MxCylxNxRwOpYzFWtjkHJWzMKZqQ(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM != null)
		{
			UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM.DeviceChangedEvent -= jUAUCsZkLNFXKLfBJXnnBREHcqxD;
		}
		(EpxPwIcStqQOHwuuRKkYezsYyNVF as IDisposable).Dispose();
		(ankzXZfeMRfvyzoFNapKmRSovxnq as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NEWOZBfmSfmoaMAJgXrqVBJJEtWI;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < XsSiLWKIpOunXllNRhKAKgkiGCMYA; i++)
		{
			if (blyigJTRfJuPIYWuRTYJHEQNIeur[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				blyigJTRfJuPIYWuRTYJHEQNIeur[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		rljQotElcZdaRPdiKeiBcNujBxoJA = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		rljQotElcZdaRPdiKeiBcNujBxoJA = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void jUAUCsZkLNFXKLfBJXnnBREHcqxD()
	{
		rljQotElcZdaRPdiKeiBcNujBxoJA = true;
		mUHrUprxIAzQyBfVyXpcAyZbVZhc = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < blyigJTRfJuPIYWuRTYJHEQNIeur.Count; i++)
		{
			if (blyigJTRfJuPIYWuRTYJHEQNIeur[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				blyigJTRfJuPIYWuRTYJHEQNIeur[i].QNMszIiVMwQAuokkqfULAndFDUbjA();
			}
		}
		for (int j = 0; j < blyigJTRfJuPIYWuRTYJHEQNIeur.Count; j++)
		{
			if (blyigJTRfJuPIYWuRTYJHEQNIeur[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				blyigJTRfJuPIYWuRTYJHEQNIeur[j].OOXbVvLFEYCieexNbHHAUIdxiSnj(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return ankzXZfeMRfvyzoFNapKmRSovxnq;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return EpxPwIcStqQOHwuuRKkYezsYyNVF;
	}

	private void cIHIQmVJiuKdkNqWLGrzbdrtCrhwA()
	{
		dliIVzRjRAlVRSqYDnGYkXIWWQtl(Input.GetJoystickNames());
	}

	private void dliIVzRjRAlVRSqYDnGYkXIWWQtl(string[] P_0)
	{
		int num = 0;
		List<xyDbjxneddYDOsTFJNRjnxmgDypr> list = blyigJTRfJuPIYWuRTYJHEQNIeur;
		int xsSiLWKIpOunXllNRhKAKgkiGCMYA = XsSiLWKIpOunXllNRhKAKgkiGCMYA;
		blyigJTRfJuPIYWuRTYJHEQNIeur = new List<xyDbjxneddYDOsTFJNRjnxmgDypr>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr2 = new xyDbjxneddYDOsTFJNRjnxmgDypr();
				xyDbjxneddYDOsTFJNRjnxmgDypr2.SeHWdrcdmWurqwHoCGhUGcitkvCAb = text;
				xyDbjxneddYDOsTFJNRjnxmgDypr2.AQIHuGLEfWrpxzQRKCCAKpkvzGLS = text;
				xyDbjxneddYDOsTFJNRjnxmgDypr2.qIDnUfVmOVjlqCaYijvrcVQsQfvWA = i;
				xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM != null)
				{
					xyDbjxneddYDOsTFJNRjnxmgDypr2.GSMGQRCLAVibnCpDECIDbOuxEgxyb = UnityTools.qSLOmZsIlGbabZAzlCUuQvguDNzM.GetUniqueDeviceIdentifier(text, i);
				}
				xyDbjxneddYDOsTFJNRjnxmgDypr2.JnCMmASILYnHHqglljOGSFWDAgFv();
				blyigJTRfJuPIYWuRTYJHEQNIeur.Add(xyDbjxneddYDOsTFJNRjnxmgDypr2);
				num++;
			}
		}
		XsSiLWKIpOunXllNRhKAKgkiGCMYA = num;
		JFZaQOZrjksVVPBnupEbWTbSQuix(xsSiLWKIpOunXllNRhKAKgkiGCMYA, num, list, blyigJTRfJuPIYWuRTYJHEQNIeur);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(blyigJTRfJuPIYWuRTYJHEQNIeur[j]));
			}
		}
		GdYMKQUouVrQfTNvKjQIPtMFQgQw(list, blyigJTRfJuPIYWuRTYJHEQNIeur, false);
		GdYMKQUouVrQfTNvKjQIPtMFQgQw(blyigJTRfJuPIYWuRTYJHEQNIeur, list, true);
		QvUapUbuhagpYuAFonMjchWqoenh = P_0;
	}

	private void MxCylxNxRwOpYzFWtjkHJWzMKZqQ(UpdateLoopType P_0)
	{
		int count = blyigJTRfJuPIYWuRTYJHEQNIeur.Count;
		for (int i = 0; i < count; i++)
		{
			if (blyigJTRfJuPIYWuRTYJHEQNIeur[i] != null)
			{
				blyigJTRfJuPIYWuRTYJHEQNIeur[i].Update();
			}
		}
	}

	private void JFZaQOZrjksVVPBnupEbWTbSQuix(int P_0, int P_1, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_2, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(xyDbjxneddYDOsTFJNRjnxmgDypr.qudVBdjmtWNCWfrBOLcUfzJkHToN);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			WWyaRGpXmQNhndurUqiJaygETLrc(P_1, P_3, P_0, P_2, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED.Exact);
			WWyaRGpXmQNhndurUqiJaygETLrc(P_1, P_3, P_0, P_2, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED.Approximate);
		}
		unKdKXFBdudGIclzDChQtXADKrTz(P_1, P_3, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED.Exact);
		unKdKXFBdudGIclzDChQtXADKrTz(P_1, P_3, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr2 = P_3[i];
			if (xyDbjxneddYDOsTFJNRjnxmgDypr2 != null && xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = gPeYVDgeDMiqyDltieOzznKxwjXY(P_3);
				xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				QwgchDXOZRkdsnIVHcUPOZcOzgmJ.GBFoaRIbCAJwccrgKFeiWMWmWQgiA(xyDbjxneddYDOsTFJNRjnxmgDypr2);
			}
		}
		P_3.Sort(xyDbjxneddYDOsTFJNRjnxmgDypr.LkZsneyPrkFuygroamYoqROTuavy);
	}

	private void oMmalkeYmaEoIIDaghHQwPSNGkUbA(List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_0, int P_1, int P_2)
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

	private bool onNYzDHfmlNrigLrwFoaHEQxwkHR(List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_0, int P_1)
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

	private int gPeYVDgeDMiqyDltieOzznKxwjXY(List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_0)
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

	private bool FdvGVeePAVsYlteVAcKTQVYvxqDs(List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_0, int P_1)
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

	private void WWyaRGpXmQNhndurUqiJaygETLrc(int P_0, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_1, int P_2, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_3, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED P_4)
	{
		int num = ((P_4 != ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr2 = P_1[i];
			if (xyDbjxneddYDOsTFJNRjnxmgDypr2 == null || xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr3 = P_3[j];
				if (xyDbjxneddYDOsTFJNRjnxmgDypr3 != null && !FdvGVeePAVsYlteVAcKTQVYvxqDs(P_1, xyDbjxneddYDOsTFJNRjnxmgDypr3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && xyDbjxneddYDOsTFJNRjnxmgDypr2.WvScxadrIyMBYaOdxhDhgAjvWgxFb(xyDbjxneddYDOsTFJNRjnxmgDypr3) >= num)
				{
					xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = xyDbjxneddYDOsTFJNRjnxmgDypr3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = xyDbjxneddYDOsTFJNRjnxmgDypr3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = xyDbjxneddYDOsTFJNRjnxmgDypr3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					QwgchDXOZRkdsnIVHcUPOZcOzgmJ.GBFoaRIbCAJwccrgKFeiWMWmWQgiA(xyDbjxneddYDOsTFJNRjnxmgDypr2);
				}
			}
		}
	}

	private void unKdKXFBdudGIclzDChQtXADKrTz(int P_0, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_1, ooIwhKvFvCGKbSVmgVVpVkpdZFmU.PSvmIrmJmLALetYNpkcOIUEodMED P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr2 = P_1[i];
			if (xyDbjxneddYDOsTFJNRjnxmgDypr2 == null || xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			ooIwhKvFvCGKbSVmgVVpVkpdZFmU.XYXzyzdTbbHXclDmagWImJngYTux xYXzyzdTbbHXclDmagWImJngYTux = null;
			foreach (ooIwhKvFvCGKbSVmgVVpVkpdZFmU.XYXzyzdTbbHXclDmagWImJngYTux item in QwgchDXOZRkdsnIVHcUPOZcOzgmJ.qbrngrfelMjgXxxZvLmHNqpBDJSm(xyDbjxneddYDOsTFJNRjnxmgDypr2, P_2))
			{
				if (!FdvGVeePAVsYlteVAcKTQVYvxqDs(P_1, item.OZgIuYspjXAYyrkuDPNgPdomGcHgA) && item.fIKNjmUYOPpDVZtcyEGmOjZaEEiDA >= 0)
				{
					xYXzyzdTbbHXclDmagWImJngYTux = item;
					break;
				}
			}
			if (xYXzyzdTbbHXclDmagWImJngYTux != null)
			{
				int num = xYXzyzdTbbHXclDmagWImJngYTux.fIKNjmUYOPpDVZtcyEGmOjZaEEiDA;
				if (!onNYzDHfmlNrigLrwFoaHEQxwkHR(P_1, num))
				{
					num = (xYXzyzdTbbHXclDmagWImJngYTux.fIKNjmUYOPpDVZtcyEGmOjZaEEiDA = gPeYVDgeDMiqyDltieOzznKxwjXY(P_1));
				}
				xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = xYXzyzdTbbHXclDmagWImJngYTux.OZgIuYspjXAYyrkuDPNgPdomGcHgA;
				QwgchDXOZRkdsnIVHcUPOZcOzgmJ.WnishralRBlBNovAsrPpuzUxkmhX(xYXzyzdTbbHXclDmagWImJngYTux, xyDbjxneddYDOsTFJNRjnxmgDypr2);
			}
		}
	}

	private void unmYywcwFvuWCpAgAqmkLwXwquCt()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (mUHrUprxIAzQyBfVyXpcAyZbVZhc || OPcuaeJlIeADImgGMGRiENhvfWGx(joystickNames))
		{
			dliIVzRjRAlVRSqYDnGYkXIWWQtl(joystickNames);
		}
		rljQotElcZdaRPdiKeiBcNujBxoJA = false;
		if (mUHrUprxIAzQyBfVyXpcAyZbVZhc)
		{
			mUHrUprxIAzQyBfVyXpcAyZbVZhc = false;
		}
	}

	private bool OPcuaeJlIeADImgGMGRiENhvfWGx(string[] P_0)
	{
		if (P_0.Length != QvUapUbuhagpYuAFonMjchWqoenh.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], QvUapUbuhagpYuAFonMjchWqoenh[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void GdYMKQUouVrQfTNvKjQIPtMFQgQw(List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_0, List<xyDbjxneddYDOsTFJNRjnxmgDypr> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr2 = P_0[i];
			if (xyDbjxneddYDOsTFJNRjnxmgDypr2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					xyDbjxneddYDOsTFJNRjnxmgDypr xyDbjxneddYDOsTFJNRjnxmgDypr3 = P_1[j];
					if (xyDbjxneddYDOsTFJNRjnxmgDypr3 != null && xyDbjxneddYDOsTFJNRjnxmgDypr2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == xyDbjxneddYDOsTFJNRjnxmgDypr3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				xkMkTEHRzgzycqagFUDbSmaKYlkF(P_0[i], P_2);
			}
		}
	}

	private void xkMkTEHRzgzycqagFUDbSmaKYlkF(xyDbjxneddYDOsTFJNRjnxmgDypr P_0, bool P_1)
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

	private void vPKUdQrORpVSEppLDCRJznHTaZDGA()
	{
		if (LwoBkEjcwdWGyUfWjoMGMahrdsMm == ZKCRgJXtNBvoyuOMEhsliuJimcHs && LegrfftMalsglbhzZbvVUOqbiRsl.Update())
		{
			rljQotElcZdaRPdiKeiBcNujBxoJA = true;
			LegrfftMalsglbhzZbvVUOqbiRsl.Start();
		}
	}
}
