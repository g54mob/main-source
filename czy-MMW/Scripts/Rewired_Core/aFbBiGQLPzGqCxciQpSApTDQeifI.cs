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

internal class aFbBiGQLPzGqCxciQpSApTDQeifI : PlatformInputManager
{
	private class lPUzaDumuiejzIvEsRqRClJklkMN : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int xEzAAaVipZHLCkADvwXypIvdddOU;

		private int iTsObOKxDJJttmVpdpVHWMxSwpRM;

		private int yhBdJZjJABHoCrwLKcyMGRnHvMkDb;

		public Guid KaMxaIWJmKRMWggvdBXMfVTIzyKTA;

		public string InBzSuOBoLNJGBDWdcfozqHtiUmw;

		public int eQwFTNWRIlDJPQFTiEVusdaNtQBA;

		public string IdOypVtvlZDVLWAvlOfuNVVfzlpL;

		public string EQFPRdYlFGZXSXnSpdzptJNCmMUI;

		private int osZrWueCqntlQfOrZLVxwkygsqMg = 29;

		private int rCZCkYdjlpUSSpiCjGBcgHqBBALEA = 20;

		private float[] yAFUIZOjhrBHyCxCXGvaURDaiagM;

		private bool[] bngnMBzaxPronJoPpeIUBJEYQWtNA;

		private bool[] hWzIocsLDYbZIznmFqbJHQDdEOWF;

		private float[] oGtaLsdGOKBmFSEFTlRFPawSYJZy;

		private bool[] bypEaAdsBYdHVNJxSorWAywkQkEfA;

		private HardwareJoystickMap_InputManager zHOdiFrMEgHiNJTiwulMJrVJEnhe;

		private bool jQZCEMUqwNXAQFUSFbtZDlMfMOGr;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return xEzAAaVipZHLCkADvwXypIvdddOU;
			}
			set
			{
				xEzAAaVipZHLCkADvwXypIvdddOU = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return iTsObOKxDJJttmVpdpVHWMxSwpRM;
			}
			set
			{
				iTsObOKxDJJttmVpdpVHWMxSwpRM = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(InBzSuOBoLNJGBDWdcfozqHtiUmw != "Unknown Controller"))
				{
					return IdOypVtvlZDVLWAvlOfuNVVfzlpL;
				}
				return InBzSuOBoLNJGBDWdcfozqHtiUmw;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (yhBdJZjJABHoCrwLKcyMGRnHvMkDb < 1)
				{
					return null;
				}
				return yhBdJZjJABHoCrwLKcyMGRnHvMkDb;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return yhBdJZjJABHoCrwLKcyMGRnHvMkDb;
			}
			set
			{
				yhBdJZjJABHoCrwLKcyMGRnHvMkDb = value;
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
					return MiscTools.CreateGuidHashSHA1(IdOypVtvlZDVLWAvlOfuNVVfzlpL);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + yhBdJZjJABHoCrwLKcyMGRnHvMkDb);
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

		public lPUzaDumuiejzIvEsRqRClJklkMN()
		{
			iTsObOKxDJJttmVpdpVHWMxSwpRM = -1;
			xEzAAaVipZHLCkADvwXypIvdddOU = -1;
			yhBdJZjJABHoCrwLKcyMGRnHvMkDb = 0;
		}

		public void BQPGHuRzQXRNaQhaAvGqnOvPeqgY()
		{
			zoAjdNxjOizqDhjDAKFzyIkvmDwE();
			KaMxaIWJmKRMWggvdBXMfVTIzyKTA = zHOdiFrMEgHiNJTiwulMJrVJEnhe.hardwareMapIdentifier.guid;
			InBzSuOBoLNJGBDWdcfozqHtiUmw = zHOdiFrMEgHiNJTiwulMJrVJEnhe.controllerName;
			yAFUIZOjhrBHyCxCXGvaURDaiagM = new float[osZrWueCqntlQfOrZLVxwkygsqMg];
			bngnMBzaxPronJoPpeIUBJEYQWtNA = new bool[rCZCkYdjlpUSSpiCjGBcgHqBBALEA];
			hWzIocsLDYbZIznmFqbJHQDdEOWF = new bool[osZrWueCqntlQfOrZLVxwkygsqMg];
			bypEaAdsBYdHVNJxSorWAywkQkEfA = new bool[29];
			oGtaLsdGOKBmFSEFTlRFPawSYJZy = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (yhBdJZjJABHoCrwLKcyMGRnHvMkDb > 0)
			{
				BbRHxJQPrmMYQYqCksiGdEUIrCkK();
				JeMfESBYUSnctEDqGucHxRBWEMdIA();
				BufZGkswibhfLeASPMSYNRfCvyiR();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int CQPguWmPBrzLrqdkWaWNtgQxJcAp(lPUzaDumuiejzIvEsRqRClJklkMN P_0)
		{
			if ((!string.IsNullOrEmpty(EQFPRdYlFGZXSXnSpdzptJNCmMUI) || !string.IsNullOrEmpty(P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI)) && !string.Equals(EQFPRdYlFGZXSXnSpdzptJNCmMUI, P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL == IdOypVtvlZDVLWAvlOfuNVVfzlpL && P_0.eQwFTNWRIlDJPQFTiEVusdaNtQBA == eQwFTNWRIlDJPQFTiEVusdaNtQBA)
			{
				return 2;
			}
			if (P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL == IdOypVtvlZDVLWAvlOfuNVVfzlpL)
			{
				return 1;
			}
			return 0;
		}

		private void luOaVlfcsPbpXsXPURMlGBtXAiYo(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = KjoeHXYmmrXloeUCQsVFgjKzAkR();
			P_0.hardwareIdentifier = CWDjTKNWCFlWtfLHUsSQecXzfiTiA();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = IdOypVtvlZDVLWAvlOfuNVVfzlpL;
		}

		private void FEFhOSCoygwEuaxNxeMIiFYBOQfN(BridgedController P_0)
		{
			luOaVlfcsPbpXsXPURMlGBtXAiYo(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = zHOdiFrMEgHiNJTiwulMJrVJEnhe.ToGameHardwareControllerMap();
			P_0.instanceName = IdOypVtvlZDVLWAvlOfuNVVfzlpL;
			P_0.productName = IdOypVtvlZDVLWAvlOfuNVVfzlpL;
			P_0.isXInputDevice = false;
			P_0.axisCount = osZrWueCqntlQfOrZLVxwkygsqMg;
			P_0.buttonCount = rCZCkYdjlpUSSpiCjGBcgHqBBALEA;
			P_0.controllerTypeGuid = KaMxaIWJmKRMWggvdBXMfVTIzyKTA;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (osZrWueCqntlQfOrZLVxwkygsqMg != dataUpdater.axisCount || rCZCkYdjlpUSSpiCjGBcgHqBBALEA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < osZrWueCqntlQfOrZLVxwkygsqMg; i++)
			{
				if (axisValues[i] != yAFUIZOjhrBHyCxCXGvaURDaiagM[i])
				{
					axisValues[i] = yAFUIZOjhrBHyCxCXGvaURDaiagM[i];
					if (axisHasBeenPressedOSXLinux[i] != hWzIocsLDYbZIznmFqbJHQDdEOWF[i])
					{
						axisHasBeenPressedOSXLinux[i] = hWzIocsLDYbZIznmFqbJHQDdEOWF[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < rCZCkYdjlpUSSpiCjGBcgHqBBALEA; j++)
			{
				if (buttonValues[j] != bngnMBzaxPronJoPpeIUBJEYQWtNA[j])
				{
					buttonValues[j] = bngnMBzaxPronJoPpeIUBJEYQWtNA[j];
				}
			}
			if (jQZCEMUqwNXAQFUSFbtZDlMfMOGr && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void QTONydALYJNqZKxaKvmuhKQtxqYu(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void OUJgiKbHElsHDSbQHtejQFUPQKCG()
		{
			yhBdJZjJABHoCrwLKcyMGRnHvMkDb = 0;
			mKkStfTuIwXJhuWiTJHZVAzEvuib();
		}

		public BridgedControllerHWInfo SimlJYTMLWYVaupvmuWPqRlIykxH()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			luOaVlfcsPbpXsXPURMlGBtXAiYo(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			FEFhOSCoygwEuaxNxeMIiFYBOQfN(bridgedController);
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
			return new ControllerDisconnectedEventArgs(xEzAAaVipZHLCkADvwXypIvdddOU);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void BbRHxJQPrmMYQYqCksiGdEUIrCkK()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(yhBdJZjJABHoCrwLKcyMGRnHvMkDb, i);
				if (oGtaLsdGOKBmFSEFTlRFPawSYJZy[i] != joystickAxisValueByJoystickId)
				{
					oGtaLsdGOKBmFSEFTlRFPawSYJZy[i] = joystickAxisValueByJoystickId;
					if (!bypEaAdsBYdHVNJxSorWAywkQkEfA[i] && joystickAxisValueByJoystickId != 0f)
					{
						bypEaAdsBYdHVNJxSorWAywkQkEfA[i] = true;
					}
				}
			}
		}

		private void JeMfESBYUSnctEDqGucHxRBWEMdIA()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)zHOdiFrMEgHiNJTiwulMJrVJEnhe.map).Axes_orig;
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
				if (i >= osZrWueCqntlQfOrZLVxwkygsqMg)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = CiAGgCDfpdGgcNCvuUDVzTTqbxwc(axes_orig[i]);
				if (yAFUIZOjhrBHyCxCXGvaURDaiagM[i] == num)
				{
					continue;
				}
				yAFUIZOjhrBHyCxCXGvaURDaiagM[i] = num;
				if (!hWzIocsLDYbZIznmFqbJHQDdEOWF[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = eNJANcgwHeUInlSYkrabKbogzSetA(axes_orig[i].sourceAxis);
						hWzIocsLDYbZIznmFqbJHQDdEOWF[i] = num2 != 0f;
					}
					else
					{
						hWzIocsLDYbZIznmFqbJHQDdEOWF[i] = true;
					}
				}
				if (!jQZCEMUqwNXAQFUSFbtZDlMfMOGr && yAFUIZOjhrBHyCxCXGvaURDaiagM[i] != 0f)
				{
					jQZCEMUqwNXAQFUSFbtZDlMfMOGr = true;
				}
			}
		}

		private void BufZGkswibhfLeASPMSYNRfCvyiR()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)zHOdiFrMEgHiNJTiwulMJrVJEnhe.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= rCZCkYdjlpUSSpiCjGBcgHqBBALEA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = ukvimEQPhhVJLTUoiAIwlxdfFEWB(buttons_orig[i]);
				if (bngnMBzaxPronJoPpeIUBJEYQWtNA[i] != flag)
				{
					bngnMBzaxPronJoPpeIUBJEYQWtNA[i] = flag;
					if (!jQZCEMUqwNXAQFUSFbtZDlMfMOGr && bngnMBzaxPronJoPpeIUBJEYQWtNA[i])
					{
						jQZCEMUqwNXAQFUSFbtZDlMfMOGr = true;
					}
				}
			}
		}

		private bool ukvimEQPhhVJLTUoiAIwlxdfFEWB(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (hvYngtvvjruxgCWoDsiSouDcCzHC(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!hvYngtvvjruxgCWoDsiSouDcCzHC(P_0.requiredButtons[j]))
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
				return hvYngtvvjruxgCWoDsiSouDcCzHC(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = eNJANcgwHeUInlSYkrabKbogzSetA(P_0.sourceAxis);
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
				float num2 = eNJANcgwHeUInlSYkrabKbogzSetA(unityHat_sourceAxis);
				float num3 = eNJANcgwHeUInlSYkrabKbogzSetA(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (PuLwCdLdDqfefHIKETDvArELrpij(unityHat_sourceAxis) || PuLwCdLdDqfefHIKETDvArELrpij(unityHat_sourceAxis2))
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
				if (wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues1.x, num2) && wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues2.x, num2) && wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues3.x, num2) && wBpvPodbDlJSJKFoMrFbyfvjHif(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (RYlwfivoJiTFirRQCqDnpqEfbRLK(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (NptAfmHZGMhjEfTBfFfdFKyQKnSk(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (AFstXJTpDjITgFGgJWXQuUSnunSp(customCalculationSourceData[k], out var flag2))
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

		private bool wBpvPodbDlJSJKFoMrFbyfvjHif(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float CiAGgCDfpdGgcNCvuUDVzTTqbxwc(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!PuLwCdLdDqfefHIKETDvArELrpij(P_0.sourceAxis))
				{
					return 0f;
				}
				return eNJANcgwHeUInlSYkrabKbogzSetA(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!hvYngtvvjruxgCWoDsiSouDcCzHC(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && NptAfmHZGMhjEfTBfFfdFKyQKnSk(customCalculationSourceData[i], out var item))
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

		private float eNJANcgwHeUInlSYkrabKbogzSetA(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return oGtaLsdGOKBmFSEFTlRFPawSYJZy[num];
		}

		private bool hvYngtvvjruxgCWoDsiSouDcCzHC(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(yhBdJZjJABHoCrwLKcyMGRnHvMkDb, buttonIndex);
		}

		private bool RYlwfivoJiTFirRQCqDnpqEfbRLK(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = hvYngtvvjruxgCWoDsiSouDcCzHC(sourceElement);
			return true;
		}

		private bool AFstXJTpDjITgFGgJWXQuUSnunSp(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool NptAfmHZGMhjEfTBfFfdFKyQKnSk(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = eNJANcgwHeUInlSYkrabKbogzSetA(sourceElement);
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

		private bool PuLwCdLdDqfefHIKETDvArELrpij(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return bypEaAdsBYdHVNJxSorWAywkQkEfA[num];
		}

		private void zoAjdNxjOizqDhjDAKFzyIkvmDwE()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = SimlJYTMLWYVaupvmuWPqRlIykxH();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(IdOypVtvlZDVLWAvlOfuNVVfzlpL, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(IdOypVtvlZDVLWAvlOfuNVVfzlpL))
					{
						if (ds4Helper.IsDS4KeyMapped(eQwFTNWRIlDJPQFTiEVusdaNtQBA))
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
			zHOdiFrMEgHiNJTiwulMJrVJEnhe = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (zHOdiFrMEgHiNJTiwulMJrVJEnhe == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (zHOdiFrMEgHiNJTiwulMJrVJEnhe.useSystemName && !string.IsNullOrEmpty(IdOypVtvlZDVLWAvlOfuNVVfzlpL))
			{
				string text = Regex.Replace(IdOypVtvlZDVLWAvlOfuNVVfzlpL, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					zHOdiFrMEgHiNJTiwulMJrVJEnhe.controllerName = text;
				}
			}
			if (UnityTools.isIOSPlatform && zHOdiFrMEgHiNJTiwulMJrVJEnhe.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text2 = gLsIcEXdnOsqERWFMRjWfGUTvNKG(IdOypVtvlZDVLWAvlOfuNVVfzlpL);
				if (!string.IsNullOrEmpty(text2))
				{
					zHOdiFrMEgHiNJTiwulMJrVJEnhe.controllerName = text2;
				}
			}
			osZrWueCqntlQfOrZLVxwkygsqMg = zHOdiFrMEgHiNJTiwulMJrVJEnhe.axisCount;
			rCZCkYdjlpUSSpiCjGBcgHqBBALEA = zHOdiFrMEgHiNJTiwulMJrVJEnhe.buttonCount;
		}

		private void mKkStfTuIwXJhuWiTJHZVAzEvuib()
		{
			Array.Clear(bngnMBzaxPronJoPpeIUBJEYQWtNA, 0, bngnMBzaxPronJoPpeIUBJEYQWtNA.Length);
			Array.Clear(yAFUIZOjhrBHyCxCXGvaURDaiagM, 0, yAFUIZOjhrBHyCxCXGvaURDaiagM.Length);
		}

		private string CWDjTKNWCFlWtfLHUsSQecXzfiTiA()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{KjoeHXYmmrXloeUCQsVFgjKzAkR().ToString()}{IdOypVtvlZDVLWAvlOfuNVVfzlpL}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(IdOypVtvlZDVLWAvlOfuNVVfzlpL, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{KjoeHXYmmrXloeUCQsVFgjKzAkR().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{KjoeHXYmmrXloeUCQsVFgjKzAkR().ToString()}{IdOypVtvlZDVLWAvlOfuNVVfzlpL}");
		}

		private InputSource KjoeHXYmmrXloeUCQsVFgjKzAkR()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(IdOypVtvlZDVLWAvlOfuNVVfzlpL))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int BxOwFIzXmlOKHWgnHhRORenHaeCI(lPUzaDumuiejzIvEsRqRClJklkMN P_0, lPUzaDumuiejzIvEsRqRClJklkMN P_1)
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

		public static int wqqBCZmpeVjuvCTSzKJuIMyuFBLEb(lPUzaDumuiejzIvEsRqRClJklkMN P_0, lPUzaDumuiejzIvEsRqRClJklkMN P_1)
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

		private static string gLsIcEXdnOsqERWFMRjWfGUTvNKG(string P_0)
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

	private class upJvpgckyDZaSixnNTsNwlKliVNO
	{
		public enum PkogfFnwQInsHLoRUJBqjtxaLvbO
		{
			Exact = 0,
			Approximate = 1
		}

		public class JHYdfTcNmcydHVmjZHzygPCqQFBqA
		{
			public int GzznwcjuPYwNVTfAsiWWmHyugyVB;

			public int spdNfRvmIxZWxqVDKPByeCBOFcjgA;

			public string wrzbQFXFRpIBPTZeJrsdTpLuekwL;

			public int dVYyEXoTMErwruzFyzKrlamdUJX;

			public string UnaUUBlGgWkSFWOrlWgmplMjjMGd;

			public bool cAYWiFDARiDAInfPskXvOKhHtPZL(lPUzaDumuiejzIvEsRqRClJklkMN P_0, PkogfFnwQInsHLoRUJBqjtxaLvbO P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == GzznwcjuPYwNVTfAsiWWmHyugyVB)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(UnaUUBlGgWkSFWOrlWgmplMjjMGd) || !string.IsNullOrEmpty(P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI)) && !string.Equals(UnaUUBlGgWkSFWOrlWgmplMjjMGd, P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case PkogfFnwQInsHLoRUJBqjtxaLvbO.Exact:
					if (spdNfRvmIxZWxqVDKPByeCBOFcjgA == P_0.eQwFTNWRIlDJPQFTiEVusdaNtQBA)
					{
						return wrzbQFXFRpIBPTZeJrsdTpLuekwL == P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL;
					}
					return false;
				case PkogfFnwQInsHLoRUJBqjtxaLvbO.Approximate:
					return wrzbQFXFRpIBPTZeJrsdTpLuekwL == P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class WIvhqmAzASdzHXLlNMaTrVviUEFA : IEnumerable<JHYdfTcNmcydHVmjZHzygPCqQFBqA>, IEnumerable, IEnumerator<JHYdfTcNmcydHVmjZHzygPCqQFBqA>, IEnumerator, IDisposable
		{
			private int iWjcbWIPzhBjNaFhQRIicVaCXKAPA;

			private JHYdfTcNmcydHVmjZHzygPCqQFBqA ZtBkptNzoVKwDbivgGJUuOyTEdDM;

			private int oTKRUXyGPmFnMbHxlQMpbqRcOcyGA;

			public upJvpgckyDZaSixnNTsNwlKliVNO rAymcKnHRaLABUXdtlnARxPVjPOI;

			private lPUzaDumuiejzIvEsRqRClJklkMN ltUxdHMJqqCVYhbyzWGhgsnGriWFA;

			public lPUzaDumuiejzIvEsRqRClJklkMN QkxkWqNFpUpLHlPOulQTcYCGdOTN;

			private PkogfFnwQInsHLoRUJBqjtxaLvbO UyqASfGkLZkKRmcOvRLTCivZvvyHA;

			public PkogfFnwQInsHLoRUJBqjtxaLvbO XwZWTxIoOJsVVOZZnkBqUrINSlLL;

			private int cIXfqtirfzBoLJpabGbgJEzkBMwz;

			private int soaIRnkhbOuXLtBpCaigjAVBxQvj;

			JHYdfTcNmcydHVmjZHzygPCqQFBqA IEnumerator<JHYdfTcNmcydHVmjZHzygPCqQFBqA>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZtBkptNzoVKwDbivgGJUuOyTEdDM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZtBkptNzoVKwDbivgGJUuOyTEdDM;
				}
			}

			[DebuggerHidden]
			public WIvhqmAzASdzHXLlNMaTrVviUEFA(int P_0)
			{
				iWjcbWIPzhBjNaFhQRIicVaCXKAPA = P_0;
				oTKRUXyGPmFnMbHxlQMpbqRcOcyGA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = iWjcbWIPzhBjNaFhQRIicVaCXKAPA;
				upJvpgckyDZaSixnNTsNwlKliVNO upJvpgckyDZaSixnNTsNwlKliVNO2 = rAymcKnHRaLABUXdtlnARxPVjPOI;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					iWjcbWIPzhBjNaFhQRIicVaCXKAPA = -1;
					goto IL_0083;
				}
				iWjcbWIPzhBjNaFhQRIicVaCXKAPA = -1;
				cIXfqtirfzBoLJpabGbgJEzkBMwz = upJvpgckyDZaSixnNTsNwlKliVNO2.yMgkXsNyjOgCbFesjioBQnLKVJGp.Count;
				soaIRnkhbOuXLtBpCaigjAVBxQvj = 0;
				goto IL_0093;
				IL_0083:
				soaIRnkhbOuXLtBpCaigjAVBxQvj++;
				goto IL_0093;
				IL_0093:
				if (soaIRnkhbOuXLtBpCaigjAVBxQvj < cIXfqtirfzBoLJpabGbgJEzkBMwz)
				{
					if (upJvpgckyDZaSixnNTsNwlKliVNO2.yMgkXsNyjOgCbFesjioBQnLKVJGp[soaIRnkhbOuXLtBpCaigjAVBxQvj].cAYWiFDARiDAInfPskXvOKhHtPZL(ltUxdHMJqqCVYhbyzWGhgsnGriWFA, UyqASfGkLZkKRmcOvRLTCivZvvyHA))
					{
						ZtBkptNzoVKwDbivgGJUuOyTEdDM = upJvpgckyDZaSixnNTsNwlKliVNO2.yMgkXsNyjOgCbFesjioBQnLKVJGp[soaIRnkhbOuXLtBpCaigjAVBxQvj];
						iWjcbWIPzhBjNaFhQRIicVaCXKAPA = 1;
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
			IEnumerator<JHYdfTcNmcydHVmjZHzygPCqQFBqA> IEnumerable<JHYdfTcNmcydHVmjZHzygPCqQFBqA>.GetEnumerator()
			{
				WIvhqmAzASdzHXLlNMaTrVviUEFA wIvhqmAzASdzHXLlNMaTrVviUEFA;
				if (iWjcbWIPzhBjNaFhQRIicVaCXKAPA == -2 && oTKRUXyGPmFnMbHxlQMpbqRcOcyGA == Environment.CurrentManagedThreadId)
				{
					iWjcbWIPzhBjNaFhQRIicVaCXKAPA = 0;
					wIvhqmAzASdzHXLlNMaTrVviUEFA = this;
				}
				else
				{
					wIvhqmAzASdzHXLlNMaTrVviUEFA = new WIvhqmAzASdzHXLlNMaTrVviUEFA(0);
					wIvhqmAzASdzHXLlNMaTrVviUEFA.rAymcKnHRaLABUXdtlnARxPVjPOI = rAymcKnHRaLABUXdtlnARxPVjPOI;
				}
				wIvhqmAzASdzHXLlNMaTrVviUEFA.ltUxdHMJqqCVYhbyzWGhgsnGriWFA = QkxkWqNFpUpLHlPOulQTcYCGdOTN;
				wIvhqmAzASdzHXLlNMaTrVviUEFA.UyqASfGkLZkKRmcOvRLTCivZvvyHA = XwZWTxIoOJsVVOZZnkBqUrINSlLL;
				return wIvhqmAzASdzHXLlNMaTrVviUEFA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<JHYdfTcNmcydHVmjZHzygPCqQFBqA>)this).GetEnumerator();
			}
		}

		private List<JHYdfTcNmcydHVmjZHzygPCqQFBqA> yMgkXsNyjOgCbFesjioBQnLKVJGp;

		public int RXzhwKLsgkudjPseVVOBOOxjjqoA => yMgkXsNyjOgCbFesjioBQnLKVJGp.Count;

		public upJvpgckyDZaSixnNTsNwlKliVNO()
		{
			yMgkXsNyjOgCbFesjioBQnLKVJGp = new List<JHYdfTcNmcydHVmjZHzygPCqQFBqA>();
		}

		public void IIQjxFiXFBIRJknpuXQnQxkGEBP(lPUzaDumuiejzIvEsRqRClJklkMN P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = yMgkXsNyjOgCbFesjioBQnLKVJGp.Count;
			for (int i = 0; i < count; i++)
			{
				if (yMgkXsNyjOgCbFesjioBQnLKVJGp[i].cAYWiFDARiDAInfPskXvOKhHtPZL(P_0, PkogfFnwQInsHLoRUJBqjtxaLvbO.Exact))
				{
					yMgkXsNyjOgCbFesjioBQnLKVJGp[i].GzznwcjuPYwNVTfAsiWWmHyugyVB = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					yMgkXsNyjOgCbFesjioBQnLKVJGp[i].wrzbQFXFRpIBPTZeJrsdTpLuekwL = P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL;
					yMgkXsNyjOgCbFesjioBQnLKVJGp[i].spdNfRvmIxZWxqVDKPByeCBOFcjgA = P_0.eQwFTNWRIlDJPQFTiEVusdaNtQBA;
					yMgkXsNyjOgCbFesjioBQnLKVJGp[i].dVYyEXoTMErwruzFyzKrlamdUJX = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					yMgkXsNyjOgCbFesjioBQnLKVJGp[i].UnaUUBlGgWkSFWOrlWgmplMjjMGd = P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI;
					UWjyFeOgSMcQHFWFihFxfKNuGAgG(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
					return;
				}
			}
			yMgkXsNyjOgCbFesjioBQnLKVJGp.Add(new JHYdfTcNmcydHVmjZHzygPCqQFBqA
			{
				GzznwcjuPYwNVTfAsiWWmHyugyVB = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				wrzbQFXFRpIBPTZeJrsdTpLuekwL = P_0.IdOypVtvlZDVLWAvlOfuNVVfzlpL,
				spdNfRvmIxZWxqVDKPByeCBOFcjgA = P_0.eQwFTNWRIlDJPQFTiEVusdaNtQBA,
				dVYyEXoTMErwruzFyzKrlamdUJX = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				UnaUUBlGgWkSFWOrlWgmplMjjMGd = P_0.EQFPRdYlFGZXSXnSpdzptJNCmMUI
			});
			UWjyFeOgSMcQHFWFihFxfKNuGAgG(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, yMgkXsNyjOgCbFesjioBQnLKVJGp.Count - 1);
		}

		public bool GxRASZiybsggZEQnSaVjyZIhcWRsA(lPUzaDumuiejzIvEsRqRClJklkMN P_0, PkogfFnwQInsHLoRUJBqjtxaLvbO P_1)
		{
			int count = yMgkXsNyjOgCbFesjioBQnLKVJGp.Count;
			for (int i = 0; i < count; i++)
			{
				if (yMgkXsNyjOgCbFesjioBQnLKVJGp[i].cAYWiFDARiDAInfPskXvOKhHtPZL(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(WIvhqmAzASdzHXLlNMaTrVviUEFA))]
		public IEnumerable<JHYdfTcNmcydHVmjZHzygPCqQFBqA> qGmEgHekmZnKeiPOGTRruaOJtRzEA(lPUzaDumuiejzIvEsRqRClJklkMN P_0, PkogfFnwQInsHLoRUJBqjtxaLvbO P_1)
		{
			return new WIvhqmAzASdzHXLlNMaTrVviUEFA(-2)
			{
				rAymcKnHRaLABUXdtlnARxPVjPOI = this,
				QkxkWqNFpUpLHlPOulQTcYCGdOTN = P_0,
				XwZWTxIoOJsVVOZZnkBqUrINSlLL = P_1
			};
		}

		public int OYeRfmbxJWPeixAaHjoQEFeFoPzj(JHYdfTcNmcydHVmjZHzygPCqQFBqA P_0)
		{
			int count = yMgkXsNyjOgCbFesjioBQnLKVJGp.Count;
			for (int i = 0; i < count; i++)
			{
				if (yMgkXsNyjOgCbFesjioBQnLKVJGp[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void UWjyFeOgSMcQHFWFihFxfKNuGAgG(int P_0, int P_1)
		{
			for (int num = yMgkXsNyjOgCbFesjioBQnLKVJGp.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && yMgkXsNyjOgCbFesjioBQnLKVJGp[num].GzznwcjuPYwNVTfAsiWWmHyugyVB == P_0)
				{
					yMgkXsNyjOgCbFesjioBQnLKVJGp.RemoveAt(num);
				}
			}
		}
	}

	private List<lPUzaDumuiejzIvEsRqRClJklkMN> luhlzbCmIYfkdgzCixpjynMXexLD;

	private int XODUTkLKiRPVcHjWmvckDdRkFStr;

	private upJvpgckyDZaSixnNTsNwlKliVNO OkrywhGUIWPNLTmYcTrvzYJQtgRK;

	private bool tsilPcZtpWCkslxalPbpkDjjbBbB;

	private bool wMYPskqrmBhTjtqqJNcVlALlRVoV;

	private UpdateLoopType FkrtIaoIlqeyXqlTAyDoptGtPhrn;

	private UpdateLoopType LSHjlCASAWAGRMBnjPEPZBoiwpsj;

	private TimerAbs JxpQeXoiZegASBeceIKxIpNjoiFIA;

	private Action<int, ControllerDataUpdater> XWNgXjfePsAOTHmUbDuEPgaxLAfrc;

	private PlatformInputManager OnmiWikULiDmTztTXmHXGeTfCqem;

	private readonly IUnifiedKeyboardSource GuwCAudSgpyayICpsghmgJDEQemPA;

	private readonly IUnifiedMouseSource sqttivgTZMZlZPDEuFOwLIpycfCIA;

	private bool LOyBlIcGxlMbMBJDaZLfIkGJHRuk;

	private string[] KoRghiEuobCIroWQZxUJeFSaPkGAb;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => XODUTkLKiRPVcHjWmvckDdRkFStr;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => OnmiWikULiDmTztTXmHXGeTfCqem;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public aFbBiGQLPzGqCxciQpSApTDQeifI(UpdateLoopSetting P_0)
	{
		OnmiWikULiDmTztTXmHXGeTfCqem = this;
		GuwCAudSgpyayICpsghmgJDEQemPA = new UnityUnifiedKeyboardSource();
		sqttivgTZMZlZPDEuFOwLIpycfCIA = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				LSHjlCASAWAGRMBnjPEPZBoiwpsj = list[num];
			}
		}
		KoRghiEuobCIroWQZxUJeFSaPkGAb = new string[0];
		XWNgXjfePsAOTHmUbDuEPgaxLAfrc = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA != null)
		{
			UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA.DeviceChangedEvent += fkJqDKCnpKFxbrJseCyPessTmsQr;
		}
		JxpQeXoiZegASBeceIKxIpNjoiFIA = new TimerAbs(1.0);
		OkrywhGUIWPNLTmYcTrvzYJQtgRK = new upJvpgckyDZaSixnNTsNwlKliVNO();
		ovWZiMUFxpRXPreNsGFXWAWfAhAR();
		tsilPcZtpWCkslxalPbpkDjjbBbB = true;
		JxpQeXoiZegASBeceIKxIpNjoiFIA.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		FkrtIaoIlqeyXqlTAyDoptGtPhrn = updateLoop;
		dMRAskySYwOcvTfSkoolYQqPGNuq();
		if (tsilPcZtpWCkslxalPbpkDjjbBbB)
		{
			gwtbWEliAmbctTQhxuBOkKuqlgnM();
		}
		YFPByLCZMjNKzJYXKVpdueYGPuDi(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA != null)
		{
			UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA.DeviceChangedEvent -= fkJqDKCnpKFxbrJseCyPessTmsQr;
		}
		(GuwCAudSgpyayICpsghmgJDEQemPA as IDisposable).Dispose();
		(sqttivgTZMZlZPDEuFOwLIpycfCIA as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return XWNgXjfePsAOTHmUbDuEPgaxLAfrc;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < XODUTkLKiRPVcHjWmvckDdRkFStr; i++)
		{
			if (luhlzbCmIYfkdgzCixpjynMXexLD[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				luhlzbCmIYfkdgzCixpjynMXexLD[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		tsilPcZtpWCkslxalPbpkDjjbBbB = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		tsilPcZtpWCkslxalPbpkDjjbBbB = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void fkJqDKCnpKFxbrJseCyPessTmsQr()
	{
		tsilPcZtpWCkslxalPbpkDjjbBbB = true;
		wMYPskqrmBhTjtqqJNcVlALlRVoV = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < luhlzbCmIYfkdgzCixpjynMXexLD.Count; i++)
		{
			if (luhlzbCmIYfkdgzCixpjynMXexLD[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				luhlzbCmIYfkdgzCixpjynMXexLD[i].OUJgiKbHElsHDSbQHtejQFUPQKCG();
			}
		}
		for (int j = 0; j < luhlzbCmIYfkdgzCixpjynMXexLD.Count; j++)
		{
			if (luhlzbCmIYfkdgzCixpjynMXexLD[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				luhlzbCmIYfkdgzCixpjynMXexLD[j].QTONydALYJNqZKxaKvmuhKQtxqYu(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return sqttivgTZMZlZPDEuFOwLIpycfCIA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return GuwCAudSgpyayICpsghmgJDEQemPA;
	}

	private void ovWZiMUFxpRXPreNsGFXWAWfAhAR()
	{
		juxEvLOMnLtFiiFDyzieRvWSQYEC(Input.GetJoystickNames());
	}

	private void juxEvLOMnLtFiiFDyzieRvWSQYEC(string[] P_0)
	{
		int num = 0;
		List<lPUzaDumuiejzIvEsRqRClJklkMN> list = luhlzbCmIYfkdgzCixpjynMXexLD;
		int xODUTkLKiRPVcHjWmvckDdRkFStr = XODUTkLKiRPVcHjWmvckDdRkFStr;
		luhlzbCmIYfkdgzCixpjynMXexLD = new List<lPUzaDumuiejzIvEsRqRClJklkMN>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN2 = new lPUzaDumuiejzIvEsRqRClJklkMN();
				lPUzaDumuiejzIvEsRqRClJklkMN2.IdOypVtvlZDVLWAvlOfuNVVfzlpL = text;
				lPUzaDumuiejzIvEsRqRClJklkMN2.InBzSuOBoLNJGBDWdcfozqHtiUmw = text;
				lPUzaDumuiejzIvEsRqRClJklkMN2.eQwFTNWRIlDJPQFTiEVusdaNtQBA = i;
				lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA != null)
				{
					lPUzaDumuiejzIvEsRqRClJklkMN2.EQFPRdYlFGZXSXnSpdzptJNCmMUI = UnityTools.gVOFJpatkJHJYZfiYMjQGfZaqTURA.GetUniqueDeviceIdentifier(text, i);
				}
				lPUzaDumuiejzIvEsRqRClJklkMN2.BQPGHuRzQXRNaQhaAvGqnOvPeqgY();
				luhlzbCmIYfkdgzCixpjynMXexLD.Add(lPUzaDumuiejzIvEsRqRClJklkMN2);
				num++;
			}
		}
		XODUTkLKiRPVcHjWmvckDdRkFStr = num;
		XIWuBsCYalluinjyTbbXbAAOieXFA(xODUTkLKiRPVcHjWmvckDdRkFStr, num, list, luhlzbCmIYfkdgzCixpjynMXexLD);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(luhlzbCmIYfkdgzCixpjynMXexLD[j]));
			}
		}
		WBNXrwBvjSibYfiydrpacGlJyMjg(list, luhlzbCmIYfkdgzCixpjynMXexLD, false);
		WBNXrwBvjSibYfiydrpacGlJyMjg(luhlzbCmIYfkdgzCixpjynMXexLD, list, true);
		KoRghiEuobCIroWQZxUJeFSaPkGAb = P_0;
	}

	private void YFPByLCZMjNKzJYXKVpdueYGPuDi(UpdateLoopType P_0)
	{
		int count = luhlzbCmIYfkdgzCixpjynMXexLD.Count;
		for (int i = 0; i < count; i++)
		{
			if (luhlzbCmIYfkdgzCixpjynMXexLD[i] != null)
			{
				luhlzbCmIYfkdgzCixpjynMXexLD[i].Update();
			}
		}
	}

	private void XIWuBsCYalluinjyTbbXbAAOieXFA(int P_0, int P_1, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_2, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(lPUzaDumuiejzIvEsRqRClJklkMN.wqqBCZmpeVjuvCTSzKJuIMyuFBLEb);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			SpzQtpgFCFLpGXMrrqHQFxLWnZuS(P_1, P_3, P_0, P_2, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO.Exact);
			SpzQtpgFCFLpGXMrrqHQFxLWnZuS(P_1, P_3, P_0, P_2, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO.Approximate);
		}
		mAFzZbMXotiHnHzmsCLsomlXpmaJ(P_1, P_3, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO.Exact);
		mAFzZbMXotiHnHzmsCLsomlXpmaJ(P_1, P_3, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN2 = P_3[i];
			if (lPUzaDumuiejzIvEsRqRClJklkMN2 != null && lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = qYbaIlllUFpMTLlwVStTYNhbfxmfA(P_3);
				lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				OkrywhGUIWPNLTmYcTrvzYJQtgRK.IIQjxFiXFBIRJknpuXQnQxkGEBP(lPUzaDumuiejzIvEsRqRClJklkMN2);
			}
		}
		P_3.Sort(lPUzaDumuiejzIvEsRqRClJklkMN.BxOwFIzXmlOKHWgnHhRORenHaeCI);
	}

	private void gorVfCtptnBmjsonXDwuaBzZlylHA(List<lPUzaDumuiejzIvEsRqRClJklkMN> P_0, int P_1, int P_2)
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

	private bool wVSiXhWxbuHODWCaBGLAwsvjpaeo(List<lPUzaDumuiejzIvEsRqRClJklkMN> P_0, int P_1)
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

	private int qYbaIlllUFpMTLlwVStTYNhbfxmfA(List<lPUzaDumuiejzIvEsRqRClJklkMN> P_0)
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

	private bool JXaMESYeBSBgKTnOjBvpvdvjEaaAA(List<lPUzaDumuiejzIvEsRqRClJklkMN> P_0, int P_1)
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

	private void SpzQtpgFCFLpGXMrrqHQFxLWnZuS(int P_0, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_1, int P_2, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_3, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO P_4)
	{
		int num = ((P_4 != upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN2 = P_1[i];
			if (lPUzaDumuiejzIvEsRqRClJklkMN2 == null || lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN3 = P_3[j];
				if (lPUzaDumuiejzIvEsRqRClJklkMN3 != null && !JXaMESYeBSBgKTnOjBvpvdvjEaaAA(P_1, lPUzaDumuiejzIvEsRqRClJklkMN3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && lPUzaDumuiejzIvEsRqRClJklkMN2.CQPguWmPBrzLrqdkWaWNtgQxJcAp(lPUzaDumuiejzIvEsRqRClJklkMN3) >= num)
				{
					lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = lPUzaDumuiejzIvEsRqRClJklkMN3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = lPUzaDumuiejzIvEsRqRClJklkMN3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = lPUzaDumuiejzIvEsRqRClJklkMN3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					OkrywhGUIWPNLTmYcTrvzYJQtgRK.IIQjxFiXFBIRJknpuXQnQxkGEBP(lPUzaDumuiejzIvEsRqRClJklkMN2);
				}
			}
		}
	}

	private void mAFzZbMXotiHnHzmsCLsomlXpmaJ(int P_0, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_1, upJvpgckyDZaSixnNTsNwlKliVNO.PkogfFnwQInsHLoRUJBqjtxaLvbO P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN2 = P_1[i];
			if (lPUzaDumuiejzIvEsRqRClJklkMN2 == null || lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			upJvpgckyDZaSixnNTsNwlKliVNO.JHYdfTcNmcydHVmjZHzygPCqQFBqA jHYdfTcNmcydHVmjZHzygPCqQFBqA = null;
			foreach (upJvpgckyDZaSixnNTsNwlKliVNO.JHYdfTcNmcydHVmjZHzygPCqQFBqA item in OkrywhGUIWPNLTmYcTrvzYJQtgRK.qGmEgHekmZnKeiPOGTRruaOJtRzEA(lPUzaDumuiejzIvEsRqRClJklkMN2, P_2))
			{
				if (!JXaMESYeBSBgKTnOjBvpvdvjEaaAA(P_1, item.GzznwcjuPYwNVTfAsiWWmHyugyVB) && item.dVYyEXoTMErwruzFyzKrlamdUJX >= 0)
				{
					jHYdfTcNmcydHVmjZHzygPCqQFBqA = item;
					break;
				}
			}
			if (jHYdfTcNmcydHVmjZHzygPCqQFBqA != null)
			{
				int num = jHYdfTcNmcydHVmjZHzygPCqQFBqA.dVYyEXoTMErwruzFyzKrlamdUJX;
				if (!wVSiXhWxbuHODWCaBGLAwsvjpaeo(P_1, num))
				{
					num = (jHYdfTcNmcydHVmjZHzygPCqQFBqA.dVYyEXoTMErwruzFyzKrlamdUJX = qYbaIlllUFpMTLlwVStTYNhbfxmfA(P_1));
				}
				lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = jHYdfTcNmcydHVmjZHzygPCqQFBqA.GzznwcjuPYwNVTfAsiWWmHyugyVB;
				OkrywhGUIWPNLTmYcTrvzYJQtgRK.IIQjxFiXFBIRJknpuXQnQxkGEBP(lPUzaDumuiejzIvEsRqRClJklkMN2);
			}
		}
	}

	private void gwtbWEliAmbctTQhxuBOkKuqlgnM()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (wMYPskqrmBhTjtqqJNcVlALlRVoV || ASvCzOCUPfUibUOFlPmAAhIrIIlsA(joystickNames))
		{
			juxEvLOMnLtFiiFDyzieRvWSQYEC(joystickNames);
		}
		tsilPcZtpWCkslxalPbpkDjjbBbB = false;
		if (wMYPskqrmBhTjtqqJNcVlALlRVoV)
		{
			wMYPskqrmBhTjtqqJNcVlALlRVoV = false;
		}
	}

	private bool ASvCzOCUPfUibUOFlPmAAhIrIIlsA(string[] P_0)
	{
		if (P_0.Length != KoRghiEuobCIroWQZxUJeFSaPkGAb.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], KoRghiEuobCIroWQZxUJeFSaPkGAb[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void WBNXrwBvjSibYfiydrpacGlJyMjg(List<lPUzaDumuiejzIvEsRqRClJklkMN> P_0, List<lPUzaDumuiejzIvEsRqRClJklkMN> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN2 = P_0[i];
			if (lPUzaDumuiejzIvEsRqRClJklkMN2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					lPUzaDumuiejzIvEsRqRClJklkMN lPUzaDumuiejzIvEsRqRClJklkMN3 = P_1[j];
					if (lPUzaDumuiejzIvEsRqRClJklkMN3 != null && lPUzaDumuiejzIvEsRqRClJklkMN2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == lPUzaDumuiejzIvEsRqRClJklkMN3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				fzVczmIpcziZZQhxoArTetLCpIXCA(P_0[i], P_2);
			}
		}
	}

	private void fzVczmIpcziZZQhxoArTetLCpIXCA(lPUzaDumuiejzIvEsRqRClJklkMN P_0, bool P_1)
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

	private void dMRAskySYwOcvTfSkoolYQqPGNuq()
	{
		if (FkrtIaoIlqeyXqlTAyDoptGtPhrn == LSHjlCASAWAGRMBnjPEPZBoiwpsj && JxpQeXoiZegASBeceIKxIpNjoiFIA.Update())
		{
			tsilPcZtpWCkslxalPbpkDjjbBbB = true;
			JxpQeXoiZegASBeceIKxIpNjoiFIA.Start();
		}
	}
}
