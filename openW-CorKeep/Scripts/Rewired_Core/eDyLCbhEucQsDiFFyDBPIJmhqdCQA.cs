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

internal class eDyLCbhEucQsDiFFyDBPIJmhqdCQA : PlatformInputManager
{
	private class rBQryuJBtiXqGHrBUQOVsqHTpbqb : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int jzgeNXgvEMqrBpVwNgnjLaMAhopz;

		private int cmvySrpCsCCHafFUZZfUiGAlTakT;

		private int gAWOrqohpGKARpugeAMJjBEgKHNN;

		public Guid WgNprobRqReFqnUGDxNgranfbrKc;

		public string AqKaiDAnZYjpTNQfJMJbqZyWIHHeA;

		public int cHVXMmvNsXuvITnglaaCOaIVwgrx;

		public string AaJthuEdKExpSVpSDumbxMmAAwADA;

		public string ENIGQGptgVfVTIEzJdTuDymtLtvq;

		private int uLWkeHHCReYRTgsMhKdiSOTTfhfQ = 29;

		private int tfAolxGEGePeZyBtLstrECPgTPuW = 20;

		private float[] mEIRlibfOekvnFUvdFDnkVyJKnXr;

		private bool[] dXbcZuYPIAmWoGKyVQsRrdpnbLAIA;

		private bool[] xJygPBBDeHyXZqdRxNIQnTaCuRhs;

		private float[] oDkUpBAOhDkASBvohajAhXXdfWiQ;

		private bool[] hHqjsxJsARhvKWSgcXOHMHPBrUvD;

		private HardwareJoystickMap_InputManager hbPXaFSVhrGlIUUmMmMJbWQqlVMq;

		private bool dpCLHxtmJCFmZYBjfpLUbjlAfBby;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return jzgeNXgvEMqrBpVwNgnjLaMAhopz;
			}
			set
			{
				jzgeNXgvEMqrBpVwNgnjLaMAhopz = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return cmvySrpCsCCHafFUZZfUiGAlTakT;
			}
			set
			{
				cmvySrpCsCCHafFUZZfUiGAlTakT = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (!(AqKaiDAnZYjpTNQfJMJbqZyWIHHeA != "Unknown Controller"))
				{
					return AaJthuEdKExpSVpSDumbxMmAAwADA;
				}
				return AqKaiDAnZYjpTNQfJMJbqZyWIHHeA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (gAWOrqohpGKARpugeAMJjBEgKHNN < 1)
				{
					return null;
				}
				return gAWOrqohpGKARpugeAMJjBEgKHNN;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId
		{
			get
			{
				return gAWOrqohpGKARpugeAMJjBEgKHNN;
			}
			set
			{
				gAWOrqohpGKARpugeAMJjBEgKHNN = value;
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
					return MiscTools.CreateGuidHashSHA1(AaJthuEdKExpSVpSDumbxMmAAwADA);
				}
				return MiscTools.CreateGuidHashSHA1(Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Ename + "_" + gAWOrqohpGKARpugeAMJjBEgKHNN);
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

		public rBQryuJBtiXqGHrBUQOVsqHTpbqb()
		{
			cmvySrpCsCCHafFUZZfUiGAlTakT = -1;
			jzgeNXgvEMqrBpVwNgnjLaMAhopz = -1;
			gAWOrqohpGKARpugeAMJjBEgKHNN = 0;
		}

		public void LlOYqVqStUfkrLCNokMtPBWupPTk()
		{
			fsFuikMKIdXVAizQacKmUQrGnZVH();
			WgNprobRqReFqnUGDxNgranfbrKc = hbPXaFSVhrGlIUUmMmMJbWQqlVMq.hardwareMapIdentifier.guid;
			AqKaiDAnZYjpTNQfJMJbqZyWIHHeA = hbPXaFSVhrGlIUUmMmMJbWQqlVMq.controllerName;
			mEIRlibfOekvnFUvdFDnkVyJKnXr = new float[uLWkeHHCReYRTgsMhKdiSOTTfhfQ];
			dXbcZuYPIAmWoGKyVQsRrdpnbLAIA = new bool[tfAolxGEGePeZyBtLstrECPgTPuW];
			xJygPBBDeHyXZqdRxNIQnTaCuRhs = new bool[uLWkeHHCReYRTgsMhKdiSOTTfhfQ];
			hHqjsxJsARhvKWSgcXOHMHPBrUvD = new bool[29];
			oDkUpBAOhDkASBvohajAhXXdfWiQ = new float[29];
			Update();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (gAWOrqohpGKARpugeAMJjBEgKHNN > 0)
			{
				DJABGqCdcfSkLiLPjGUNVPdEtsLpc();
				ZbNXFttKxLKxyALZmIUMFEebHKAF();
				DgKNPETNiFNOznjvfeJyzAfalTY();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int AqUEhjZrwoBFirjRylMUDHlSbnxgA(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0)
		{
			if ((!string.IsNullOrEmpty(ENIGQGptgVfVTIEzJdTuDymtLtvq) || !string.IsNullOrEmpty(P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq)) && !string.Equals(ENIGQGptgVfVTIEzJdTuDymtLtvq, P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq, StringComparison.Ordinal))
			{
				return 0;
			}
			if (P_0.AaJthuEdKExpSVpSDumbxMmAAwADA == AaJthuEdKExpSVpSDumbxMmAAwADA && P_0.cHVXMmvNsXuvITnglaaCOaIVwgrx == cHVXMmvNsXuvITnglaaCOaIVwgrx)
			{
				return 2;
			}
			if (P_0.AaJthuEdKExpSVpSDumbxMmAAwADA == AaJthuEdKExpSVpSDumbxMmAAwADA)
			{
				return 1;
			}
			return 0;
		}

		private void vONJhMYUFGBXGfpocgvieOKcetfFA(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.Fallback;
			P_0.inputSource = WyozxmaDTdmfabPfuiCGzNGnsNLw();
			P_0.hardwareIdentifier = AkCQdtiqhCgGkeFkqfkFMAcUQzio();
			P_0.hardwareAxisCount = 0;
			P_0.hardwareButtonCount = 0;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = AaJthuEdKExpSVpSDumbxMmAAwADA;
		}

		private void DcCVEhpXJlqxnxVmZwDFWZzqDwEj(BridgedController P_0)
		{
			vONJhMYUFGBXGfpocgvieOKcetfFA(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hbPXaFSVhrGlIUUmMmMJbWQqlVMq.ToGameHardwareControllerMap();
			P_0.instanceName = AaJthuEdKExpSVpSDumbxMmAAwADA;
			P_0.productName = AaJthuEdKExpSVpSDumbxMmAAwADA;
			P_0.isXInputDevice = false;
			P_0.axisCount = uLWkeHHCReYRTgsMhKdiSOTTfhfQ;
			P_0.buttonCount = tfAolxGEGePeZyBtLstrECPgTPuW;
			P_0.controllerTypeGuid = WgNprobRqReFqnUGDxNgranfbrKc;
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (uLWkeHHCReYRTgsMhKdiSOTTfhfQ != dataUpdater.axisCount || tfAolxGEGePeZyBtLstrECPgTPuW != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < uLWkeHHCReYRTgsMhKdiSOTTfhfQ; i++)
			{
				if (axisValues[i] != mEIRlibfOekvnFUvdFDnkVyJKnXr[i])
				{
					axisValues[i] = mEIRlibfOekvnFUvdFDnkVyJKnXr[i];
					if (axisHasBeenPressedOSXLinux[i] != xJygPBBDeHyXZqdRxNIQnTaCuRhs[i])
					{
						axisHasBeenPressedOSXLinux[i] = xJygPBBDeHyXZqdRxNIQnTaCuRhs[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < tfAolxGEGePeZyBtLstrECPgTPuW; j++)
			{
				if (buttonValues[j] != dXbcZuYPIAmWoGKyVQsRrdpnbLAIA[j])
				{
					buttonValues[j] = dXbcZuYPIAmWoGKyVQsRrdpnbLAIA[j];
				}
			}
			if (dpCLHxtmJCFmZYBjfpLUbjlAfBby && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public void SoPanIfhtKUEINUJowWtBUrEefnP(int P_0)
		{
			if (P_0 >= 1 && P_0 <= 16)
			{
				Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = P_0;
			}
		}

		public void OLKVfNUvkktEMHzOrSBqoFnuPBrN()
		{
			gAWOrqohpGKARpugeAMJjBEgKHNN = 0;
			aSjfZGFqDjulswdhfspWjXfpXoDt();
		}

		public BridgedControllerHWInfo OylHahgnyFkqbhSMUiCODSGpJbIDA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			vONJhMYUFGBXGfpocgvieOKcetfFA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			DcCVEhpXJlqxnxVmZwDFWZzqDwEj(bridgedController);
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
			return new ControllerDisconnectedEventArgs(jzgeNXgvEMqrBpVwNgnjLaMAhopz);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void DJABGqCdcfSkLiLPjGUNVPdEtsLpc()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(gAWOrqohpGKARpugeAMJjBEgKHNN, i);
				if (oDkUpBAOhDkASBvohajAhXXdfWiQ[i] != joystickAxisValueByJoystickId)
				{
					oDkUpBAOhDkASBvohajAhXXdfWiQ[i] = joystickAxisValueByJoystickId;
					if (!hHqjsxJsARhvKWSgcXOHMHPBrUvD[i] && joystickAxisValueByJoystickId != 0f)
					{
						hHqjsxJsARhvKWSgcXOHMHPBrUvD[i] = true;
					}
				}
			}
		}

		private void ZbNXFttKxLKxyALZmIUMFEebHKAF()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)hbPXaFSVhrGlIUUmMmMJbWQqlVMq.map).Axes_orig;
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
				if (i >= uLWkeHHCReYRTgsMhKdiSOTTfhfQ)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				float num = ITHSRpgaOqHuvCUjEmaSGNsJNwWRb(axes_orig[i]);
				if (mEIRlibfOekvnFUvdFDnkVyJKnXr[i] == num)
				{
					continue;
				}
				mEIRlibfOekvnFUvdFDnkVyJKnXr[i] = num;
				if (!xJygPBBDeHyXZqdRxNIQnTaCuRhs[i])
				{
					if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
					{
						float num2 = eUYAsDBgsziQqNqzSIamTaXBiLNP(axes_orig[i].sourceAxis);
						xJygPBBDeHyXZqdRxNIQnTaCuRhs[i] = num2 != 0f;
					}
					else
					{
						xJygPBBDeHyXZqdRxNIQnTaCuRhs[i] = true;
					}
				}
				if (!dpCLHxtmJCFmZYBjfpLUbjlAfBby && mEIRlibfOekvnFUvdFDnkVyJKnXr[i] != 0f)
				{
					dpCLHxtmJCFmZYBjfpLUbjlAfBby = true;
				}
			}
		}

		private void DgKNPETNiFNOznjvfeJyzAfalTY()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)hbPXaFSVhrGlIUUmMmMJbWQqlVMq.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= tfAolxGEGePeZyBtLstrECPgTPuW)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = mcfydPjnwwmhUURpYdsTROKUOExV(buttons_orig[i]);
				if (dXbcZuYPIAmWoGKyVQsRrdpnbLAIA[i] != flag)
				{
					dXbcZuYPIAmWoGKyVQsRrdpnbLAIA[i] = flag;
					if (!dpCLHxtmJCFmZYBjfpLUbjlAfBby && dXbcZuYPIAmWoGKyVQsRrdpnbLAIA[i])
					{
						dpCLHxtmJCFmZYBjfpLUbjlAfBby = true;
					}
				}
			}
		}

		private bool mcfydPjnwwmhUURpYdsTROKUOExV(HardwareJoystickMap.Platform_Fallback_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(P_0.requiredButtons[j]))
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
				return zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(P_0.sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num = eUYAsDBgsziQqNqzSIamTaXBiLNP(P_0.sourceAxis);
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
				float num2 = eUYAsDBgsziQqNqzSIamTaXBiLNP(unityHat_sourceAxis);
				float num3 = eUYAsDBgsziQqNqzSIamTaXBiLNP(unityHat_sourceAxis2);
				float x;
				float y;
				if (P_0.unityHat_checkNeverPressed)
				{
					if (TmSufUshCrFxiSZjshHewmbqkMLl(unityHat_sourceAxis) || TmSufUshCrFxiSZjshHewmbqkMLl(unityHat_sourceAxis2))
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
				if (kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues1.x, num2) && kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues1.y, num3))
				{
					return true;
				}
				if (kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues2.x, num2) && kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues2.y, num3))
				{
					return true;
				}
				if (kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues3.x, num2) && kyIXguTYECUjFKokYmuEHbAKfmXgA(P_0.unityHat_isActiveAxisValues3.y, num3))
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
							if (RHkjtNYUonIhlgkvynKmXTfORekx(customCalculationSourceData[k], out var flag3))
							{
								customCalculation.AddData(flag3 ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Axis:
						{
							if (RvwoqJkqbVLJFqKaToNgvoZrrNrm(customCalculationSourceData[k], out var num4))
							{
								customCalculation.AddData((num4 != 0f) ? 1f : 0f);
							}
							break;
						}
						case HardwareElementSourceTypeWithHat.Key:
						{
							if (KwjUKokupmzIfIVabbQVGvCOejbf(customCalculationSourceData[k], out var flag2))
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

		private bool kyIXguTYECUjFKokYmuEHbAKfmXgA(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float ITHSRpgaOqHuvCUjEmaSGNsJNwWRb(HardwareJoystickMap.Platform_Fallback_Base.Axis P_0)
		{
			switch (P_0.sourceType)
			{
			case HardwareElementSourceTypeWithHat.Axis:
				if (P_0.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!TmSufUshCrFxiSZjshHewmbqkMLl(P_0.sourceAxis))
				{
					return 0f;
				}
				return eUYAsDBgsziQqNqzSIamTaXBiLNP(P_0.sourceAxis);
			case HardwareElementSourceTypeWithHat.Button:
				if (P_0.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(P_0.sourceButton))
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && RvwoqJkqbVLJFqKaToNgvoZrrNrm(customCalculationSourceData[i], out var item))
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

		private float eUYAsDBgsziQqNqzSIamTaXBiLNP(UnityAxis P_0)
		{
			if (P_0 == UnityAxis.None)
			{
				return 0f;
			}
			int num = (int)(P_0 - 1);
			return oDkUpBAOhDkASBvohajAhXXdfWiQ[num];
		}

		private bool zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(UnityButton P_0)
		{
			int buttonIndex = (int)(P_0 - 1);
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(gAWOrqohpGKARpugeAMJjBEgKHNN, buttonIndex);
		}

		private bool RHkjtNYUonIhlgkvynKmXTfORekx(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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
			P_1 = zNFtaYAHAiGEhfLnzdEFQCVHYBwbA(sourceElement);
			return true;
		}

		private bool KwjUKokupmzIfIVabbQVGvCOejbf(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out bool P_1)
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

		private bool RvwoqJkqbVLJFqKaToNgvoZrrNrm(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = eUYAsDBgsziQqNqzSIamTaXBiLNP(sourceElement);
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

		private bool TmSufUshCrFxiSZjshHewmbqkMLl(UnityAxis P_0)
		{
			int num = (int)(P_0 - 1);
			return hHqjsxJsARhvKWSgcXOHMHPBrUvD[num];
		}

		private void fsFuikMKIdXVAizQacKmUQrGnZVH()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = OylHahgnyFkqbhSMUiCODSGpJbIDA();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(AaJthuEdKExpSVpSDumbxMmAAwADA, "Xbox Wireless Controller.*"))
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
				else if (UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(AaJthuEdKExpSVpSDumbxMmAAwADA))
					{
						if (ds4Helper.IsDS4KeyMapped(cHVXMmvNsXuvITnglaaCOaIVwgrx))
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
			hbPXaFSVhrGlIUUmMmMJbWQqlVMq = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (hbPXaFSVhrGlIUUmMmMJbWQqlVMq == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && hbPXaFSVhrGlIUUmMmMJbWQqlVMq.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = uxbUPpcDYTySPYyvmevHVankQghq(AaJthuEdKExpSVpSDumbxMmAAwADA);
				if (!string.IsNullOrEmpty(text))
				{
					hbPXaFSVhrGlIUUmMmMJbWQqlVMq.controllerName = text;
					if (hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys[0]))
					{
						hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys[0], text));
					}
					hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (hbPXaFSVhrGlIUUmMmMJbWQqlVMq.useSystemName && !string.IsNullOrEmpty(AaJthuEdKExpSVpSDumbxMmAAwADA))
			{
				string text2 = Regex.Replace(AaJthuEdKExpSVpSDumbxMmAAwADA, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					hbPXaFSVhrGlIUUmMmMJbWQqlVMq.controllerName = text2;
					if (hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys[0]))
					{
						hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.parentKeys[0], text2));
					}
					hbPXaFSVhrGlIUUmMmMJbWQqlVMq.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			uLWkeHHCReYRTgsMhKdiSOTTfhfQ = hbPXaFSVhrGlIUUmMmMJbWQqlVMq.axisCount;
			tfAolxGEGePeZyBtLstrECPgTPuW = hbPXaFSVhrGlIUUmMmMJbWQqlVMq.buttonCount;
		}

		private void aSjfZGFqDjulswdhfspWjXfpXoDt()
		{
			Array.Clear(dXbcZuYPIAmWoGKyVQsRrdpnbLAIA, 0, dXbcZuYPIAmWoGKyVQsRrdpnbLAIA.Length);
			Array.Clear(mEIRlibfOekvnFUvdFDnkVyJKnXr, 0, mEIRlibfOekvnFUvdFDnkVyJKnXr.Length);
		}

		private string AkCQdtiqhCgGkeFkqfkFMAcUQzio()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{WyozxmaDTdmfabPfuiCGzNGnsNLw().ToString()}{AaJthuEdKExpSVpSDumbxMmAAwADA}");
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(AaJthuEdKExpSVpSDumbxMmAAwADA, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{WyozxmaDTdmfabPfuiCGzNGnsNLw().ToString()}{arg}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{WyozxmaDTdmfabPfuiCGzNGnsNLw().ToString()}{AaJthuEdKExpSVpSDumbxMmAAwADA}");
		}

		private InputSource WyozxmaDTdmfabPfuiCGzNGnsNLw()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(AaJthuEdKExpSVpSDumbxMmAAwADA))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		public static int JgJrxhAcXqRkKNEOtxRNnTKgxzxu(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, rBQryuJBtiXqGHrBUQOVsqHTpbqb P_1)
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

		public static int optMJkRNNObEuYhbZdRxmcJXEUuM(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, rBQryuJBtiXqGHrBUQOVsqHTpbqb P_1)
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

		private static string uxbUPpcDYTySPYyvmevHVankQghq(string P_0)
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

	private class kOGoVwTPsIMVSjWArSCqMtGSAcGb
	{
		public enum TwlcoiYQtTQgCYWuctUjTrWRshUj
		{
			Exact = 0,
			Approximate = 1
		}

		public class BAFOgeJJTnfJGIvMfUTdpejHMUaW
		{
			public int GeydmJCEJZXEAkYQQZGLIWgNGbNgb;

			public int qScagqSijuKcejFyqarfIxybVtIM;

			public string kteaiiAyaepkEFGZpkDyHtaNNbNKA;

			public int fmAzvjwYwHPFxyeYhPPNPaTLeHifA;

			public string KUzfPwhWlXOCSCFtVewpcNKESqhKb;

			public bool agDVXuaMfjkxRmloYfCywjYgZwcO(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, TwlcoiYQtTQgCYWuctUjTrWRshUj P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == GeydmJCEJZXEAkYQQZGLIWgNGbNgb)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(KUzfPwhWlXOCSCFtVewpcNKESqhKb) || !string.IsNullOrEmpty(P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq)) && !string.Equals(KUzfPwhWlXOCSCFtVewpcNKESqhKb, P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq, StringComparison.Ordinal))
				{
					return false;
				}
				switch (P_1)
				{
				case TwlcoiYQtTQgCYWuctUjTrWRshUj.Exact:
					if (qScagqSijuKcejFyqarfIxybVtIM == P_0.cHVXMmvNsXuvITnglaaCOaIVwgrx)
					{
						return kteaiiAyaepkEFGZpkDyHtaNNbNKA == P_0.AaJthuEdKExpSVpSDumbxMmAAwADA;
					}
					return false;
				case TwlcoiYQtTQgCYWuctUjTrWRshUj.Approximate:
					return kteaiiAyaepkEFGZpkDyHtaNNbNKA == P_0.AaJthuEdKExpSVpSDumbxMmAAwADA;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class OhLzaNlIMRaPihWsVpenPRqKbFvzA : IEnumerable<BAFOgeJJTnfJGIvMfUTdpejHMUaW>, IEnumerable, IEnumerator<BAFOgeJJTnfJGIvMfUTdpejHMUaW>, IEnumerator, IDisposable
		{
			private int aLonkxrkSwgDAOiMgssfnELliZniA;

			private BAFOgeJJTnfJGIvMfUTdpejHMUaW DPGqxCgkXIclIqoUYjPPIzZiwFsf;

			private int oQRNhoJjcxEDTWASLQeiCNwRXtFn;

			public kOGoVwTPsIMVSjWArSCqMtGSAcGb vEdfrlgGwjLdSwHALFFVmncqIknDb;

			private rBQryuJBtiXqGHrBUQOVsqHTpbqb xXngcAtBrixFCyPXxuaYWKnxvxkA;

			public rBQryuJBtiXqGHrBUQOVsqHTpbqb QryJWBwHGJbjWsZlCyqQUKhrLPol;

			private TwlcoiYQtTQgCYWuctUjTrWRshUj ImhXtQPeqWugMblvLnqQUYGyeCNm;

			public TwlcoiYQtTQgCYWuctUjTrWRshUj JMUYQfrvmOWMkZqjTCjTenBgJiAB;

			private int etQlWCVRSwUmKWXVBZnblRATLPPK;

			private int owxGBMDNSRvSAmXsaAIzJXquKeQAA;

			BAFOgeJJTnfJGIvMfUTdpejHMUaW IEnumerator<BAFOgeJJTnfJGIvMfUTdpejHMUaW>.Current
			{
				[DebuggerHidden]
				get
				{
					return DPGqxCgkXIclIqoUYjPPIzZiwFsf;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DPGqxCgkXIclIqoUYjPPIzZiwFsf;
				}
			}

			[DebuggerHidden]
			public OhLzaNlIMRaPihWsVpenPRqKbFvzA(int P_0)
			{
				aLonkxrkSwgDAOiMgssfnELliZniA = P_0;
				oQRNhoJjcxEDTWASLQeiCNwRXtFn = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				aLonkxrkSwgDAOiMgssfnELliZniA = -2;
			}

			private bool MoveNext()
			{
				int num = aLonkxrkSwgDAOiMgssfnELliZniA;
				kOGoVwTPsIMVSjWArSCqMtGSAcGb kOGoVwTPsIMVSjWArSCqMtGSAcGb2 = vEdfrlgGwjLdSwHALFFVmncqIknDb;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					aLonkxrkSwgDAOiMgssfnELliZniA = -1;
					goto IL_0083;
				}
				aLonkxrkSwgDAOiMgssfnELliZniA = -1;
				etQlWCVRSwUmKWXVBZnblRATLPPK = kOGoVwTPsIMVSjWArSCqMtGSAcGb2.mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count;
				owxGBMDNSRvSAmXsaAIzJXquKeQAA = 0;
				goto IL_0093;
				IL_0083:
				owxGBMDNSRvSAmXsaAIzJXquKeQAA++;
				goto IL_0093;
				IL_0093:
				if (owxGBMDNSRvSAmXsaAIzJXquKeQAA < etQlWCVRSwUmKWXVBZnblRATLPPK)
				{
					if (kOGoVwTPsIMVSjWArSCqMtGSAcGb2.mSjPvPcqCLGTqCGRNjYYkxmfMadH[owxGBMDNSRvSAmXsaAIzJXquKeQAA].agDVXuaMfjkxRmloYfCywjYgZwcO(xXngcAtBrixFCyPXxuaYWKnxvxkA, ImhXtQPeqWugMblvLnqQUYGyeCNm))
					{
						DPGqxCgkXIclIqoUYjPPIzZiwFsf = kOGoVwTPsIMVSjWArSCqMtGSAcGb2.mSjPvPcqCLGTqCGRNjYYkxmfMadH[owxGBMDNSRvSAmXsaAIzJXquKeQAA];
						aLonkxrkSwgDAOiMgssfnELliZniA = 1;
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
			IEnumerator<BAFOgeJJTnfJGIvMfUTdpejHMUaW> IEnumerable<BAFOgeJJTnfJGIvMfUTdpejHMUaW>.GetEnumerator()
			{
				OhLzaNlIMRaPihWsVpenPRqKbFvzA ohLzaNlIMRaPihWsVpenPRqKbFvzA;
				if (aLonkxrkSwgDAOiMgssfnELliZniA == -2 && oQRNhoJjcxEDTWASLQeiCNwRXtFn == Environment.CurrentManagedThreadId)
				{
					aLonkxrkSwgDAOiMgssfnELliZniA = 0;
					ohLzaNlIMRaPihWsVpenPRqKbFvzA = this;
				}
				else
				{
					ohLzaNlIMRaPihWsVpenPRqKbFvzA = new OhLzaNlIMRaPihWsVpenPRqKbFvzA(0);
					ohLzaNlIMRaPihWsVpenPRqKbFvzA.vEdfrlgGwjLdSwHALFFVmncqIknDb = vEdfrlgGwjLdSwHALFFVmncqIknDb;
				}
				ohLzaNlIMRaPihWsVpenPRqKbFvzA.xXngcAtBrixFCyPXxuaYWKnxvxkA = QryJWBwHGJbjWsZlCyqQUKhrLPol;
				ohLzaNlIMRaPihWsVpenPRqKbFvzA.ImhXtQPeqWugMblvLnqQUYGyeCNm = JMUYQfrvmOWMkZqjTCjTenBgJiAB;
				return ohLzaNlIMRaPihWsVpenPRqKbFvzA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<BAFOgeJJTnfJGIvMfUTdpejHMUaW>)this).GetEnumerator();
			}
		}

		private List<BAFOgeJJTnfJGIvMfUTdpejHMUaW> mSjPvPcqCLGTqCGRNjYYkxmfMadH;

		public int PIYyaRwmPzhWucORIWlRkalOOuHtA => mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count;

		public kOGoVwTPsIMVSjWArSCqMtGSAcGb()
		{
			mSjPvPcqCLGTqCGRNjYYkxmfMadH = new List<BAFOgeJJTnfJGIvMfUTdpejHMUaW>();
		}

		public void WaLBaAkcmSDcCYYABFhREBKNWLoFb(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count;
			for (int i = 0; i < count; i++)
			{
				if (mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].agDVXuaMfjkxRmloYfCywjYgZwcO(P_0, TwlcoiYQtTQgCYWuctUjTrWRshUj.Exact))
				{
					mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].GeydmJCEJZXEAkYQQZGLIWgNGbNgb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].kteaiiAyaepkEFGZpkDyHtaNNbNKA = P_0.AaJthuEdKExpSVpSDumbxMmAAwADA;
					mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].qScagqSijuKcejFyqarfIxybVtIM = P_0.cHVXMmvNsXuvITnglaaCOaIVwgrx;
					mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].fmAzvjwYwHPFxyeYhPPNPaTLeHifA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].KUzfPwhWlXOCSCFtVewpcNKESqhKb = P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq;
					QEssxTzITZjOCWLvIDHyRkxDAFNJA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, i);
					return;
				}
			}
			mSjPvPcqCLGTqCGRNjYYkxmfMadH.Add(new BAFOgeJJTnfJGIvMfUTdpejHMUaW
			{
				GeydmJCEJZXEAkYQQZGLIWgNGbNgb = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				kteaiiAyaepkEFGZpkDyHtaNNbNKA = P_0.AaJthuEdKExpSVpSDumbxMmAAwADA,
				qScagqSijuKcejFyqarfIxybVtIM = P_0.cHVXMmvNsXuvITnglaaCOaIVwgrx,
				fmAzvjwYwHPFxyeYhPPNPaTLeHifA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				KUzfPwhWlXOCSCFtVewpcNKESqhKb = P_0.ENIGQGptgVfVTIEzJdTuDymtLtvq
			});
			QEssxTzITZjOCWLvIDHyRkxDAFNJA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count - 1);
		}

		public bool ClGTTeZHGfKmMZaSonrghwxENRwf(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, TwlcoiYQtTQgCYWuctUjTrWRshUj P_1)
		{
			int count = mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count;
			for (int i = 0; i < count; i++)
			{
				if (mSjPvPcqCLGTqCGRNjYYkxmfMadH[i].agDVXuaMfjkxRmloYfCywjYgZwcO(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(OhLzaNlIMRaPihWsVpenPRqKbFvzA))]
		public IEnumerable<BAFOgeJJTnfJGIvMfUTdpejHMUaW> qDjtDqFFFSmlvABzsnrkSBzkdGSN(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, TwlcoiYQtTQgCYWuctUjTrWRshUj P_1)
		{
			return new OhLzaNlIMRaPihWsVpenPRqKbFvzA(-2)
			{
				vEdfrlgGwjLdSwHALFFVmncqIknDb = this,
				QryJWBwHGJbjWsZlCyqQUKhrLPol = P_0,
				JMUYQfrvmOWMkZqjTCjTenBgJiAB = P_1
			};
		}

		public int OHnUETEJMVvltkBTxzZBqwZsixAT(BAFOgeJJTnfJGIvMfUTdpejHMUaW P_0)
		{
			int count = mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count;
			for (int i = 0; i < count; i++)
			{
				if (mSjPvPcqCLGTqCGRNjYYkxmfMadH[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void QEssxTzITZjOCWLvIDHyRkxDAFNJA(int P_0, int P_1)
		{
			for (int num = mSjPvPcqCLGTqCGRNjYYkxmfMadH.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && mSjPvPcqCLGTqCGRNjYYkxmfMadH[num].GeydmJCEJZXEAkYQQZGLIWgNGbNgb == P_0)
				{
					mSjPvPcqCLGTqCGRNjYYkxmfMadH.RemoveAt(num);
				}
			}
		}
	}

	private List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> djgDwAxqFXePqhrOKRPwoQMqDzgpA;

	private int LQMARFjqJCVrdEGlIGFtsniBWDYlA;

	private kOGoVwTPsIMVSjWArSCqMtGSAcGb SiGtAwflDjzWBOhOTnqgLmBrgoMb;

	private bool tjnWqmiXAFFehchKPDfqaCqIPweW;

	private bool kSZxlTVBXAfocyCLnCKGFEmEZIDr;

	private UpdateLoopType DRkTIPBGIxAJWvyQevIlJxKUqmSd;

	private UpdateLoopType XIIvyKvirBGsUXxkHgxMrrPZmfHT;

	private TimerAbs ZisbquTDwtduBEzXMSwcHfmSuzqp;

	private Action<int, ControllerDataUpdater> NgQKLAPmmhyEIzxGlGFPIDJuTeWh;

	private PlatformInputManager QVtftBDkatcvQukedzWUeumQPHVQ;

	private readonly IUnifiedKeyboardSource ELvBGHCgBaQblBAQAIBjncipLvDV;

	private readonly IUnifiedMouseSource qNinJANgDPvdKMajWaxbvIYBykbF;

	private bool ZobnkdDmImQPFGckGytiiOhoSKPw;

	private string[] ARUgMDRBmgmayZGddkJSdGhDrfli;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => LQMARFjqJCVrdEGlIGFtsniBWDYlA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => QVtftBDkatcvQukedzWUeumQPHVQ;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.Fallback;

	public eDyLCbhEucQsDiFFyDBPIJmhqdCQA(UpdateLoopSetting P_0)
	{
		QVtftBDkatcvQukedzWUeumQPHVQ = this;
		ELvBGHCgBaQblBAQAIBjncipLvDV = new UnityUnifiedKeyboardSource();
		qNinJANgDPvdKMajWaxbvIYBykbF = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			int num = 0;
			if (num < list.Count)
			{
				XIIvyKvirBGsUXxkHgxMrrPZmfHT = list[num];
			}
		}
		ARUgMDRBmgmayZGddkJSdGhDrfli = new string[0];
		NgQKLAPmmhyEIzxGlGFPIDJuTeWh = UpdateControllerData;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc != null)
		{
			UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc.DeviceChangedEvent += zaKaSbtFQPxRqcbJQNQACdPurhvM;
		}
		ZisbquTDwtduBEzXMSwcHfmSuzqp = new TimerAbs(1.0);
		SiGtAwflDjzWBOhOTnqgLmBrgoMb = new kOGoVwTPsIMVSjWArSCqMtGSAcGb();
		uMBbQxbbSmfzUqmuQEuSKwlIdojvA();
		tjnWqmiXAFFehchKPDfqaCqIPweW = true;
		ZisbquTDwtduBEzXMSwcHfmSuzqp.Start();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		DRkTIPBGIxAJWvyQevIlJxKUqmSd = updateLoop;
		ftQodZFqvjGOoWalEPEwgWTsoYLv();
		if (tjnWqmiXAFFehchKPDfqaCqIPweW)
		{
			eJwnetMwhlsKqQnKFEjTWqPXcrODA();
		}
		MZUMxazZjmOraCssevleWsxlzAqs(updateLoop);
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc != null)
		{
			UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc.DeviceChangedEvent -= zaKaSbtFQPxRqcbJQNQACdPurhvM;
		}
		(ELvBGHCgBaQblBAQAIBjncipLvDV as IDisposable).Dispose();
		(qNinJANgDPvdKMajWaxbvIYBykbF as IDisposable).Dispose();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NgQKLAPmmhyEIzxGlGFPIDJuTeWh;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < LQMARFjqJCVrdEGlIGFtsniBWDYlA; i++)
		{
			if (djgDwAxqFXePqhrOKRPwoQMqDzgpA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == assignedControllerId)
			{
				djgDwAxqFXePqhrOKRPwoQMqDzgpA[i].FillData(data);
				return;
			}
		}
		Rewired.Logger.LogError("Invalid joystick Id " + assignedControllerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		tjnWqmiXAFFehchKPDfqaCqIPweW = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		tjnWqmiXAFFehchKPDfqaCqIPweW = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	private void zaKaSbtFQPxRqcbJQNQACdPurhvM()
	{
		tjnWqmiXAFFehchKPDfqaCqIPweW = true;
		kSZxlTVBXAfocyCLnCKGFEmEZIDr = true;
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < djgDwAxqFXePqhrOKRPwoQMqDzgpA.Count; i++)
		{
			if (djgDwAxqFXePqhrOKRPwoQMqDzgpA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId == unityJoystickId)
			{
				djgDwAxqFXePqhrOKRPwoQMqDzgpA[i].OLKVfNUvkktEMHzOrSBqoFnuPBrN();
			}
		}
		for (int j = 0; j < djgDwAxqFXePqhrOKRPwoQMqDzgpA.Count; j++)
		{
			if (djgDwAxqFXePqhrOKRPwoQMqDzgpA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == joystickId)
			{
				djgDwAxqFXePqhrOKRPwoQMqDzgpA[j].SoPanIfhtKUEINUJowWtBUrEefnP(unityJoystickId);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return qNinJANgDPvdKMajWaxbvIYBykbF;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return ELvBGHCgBaQblBAQAIBjncipLvDV;
	}

	private void uMBbQxbbSmfzUqmuQEuSKwlIdojvA()
	{
		bjaDLgjxdKwJzIfkQiFlYxIjiNzlA(Input.GetJoystickNames());
	}

	private void bjaDLgjxdKwJzIfkQiFlYxIjiNzlA(string[] P_0)
	{
		int num = 0;
		List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> list = djgDwAxqFXePqhrOKRPwoQMqDzgpA;
		int lQMARFjqJCVrdEGlIGFtsniBWDYlA = LQMARFjqJCVrdEGlIGFtsniBWDYlA;
		djgDwAxqFXePqhrOKRPwoQMqDzgpA = new List<rBQryuJBtiXqGHrBUQOVsqHTpbqb>();
		for (int i = 0; i < P_0.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(P_0[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb2 = new rBQryuJBtiXqGHrBUQOVsqHTpbqb();
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.AaJthuEdKExpSVpSDumbxMmAAwADA = text;
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.AqKaiDAnZYjpTNQfJMJbqZyWIHHeA = text;
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.cHVXMmvNsXuvITnglaaCOaIVwgrx = i;
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc != null)
				{
					rBQryuJBtiXqGHrBUQOVsqHTpbqb2.ENIGQGptgVfVTIEzJdTuDymtLtvq = UnityTools.wORQWYSBYMpFwaXLaNVINsCZUzgc.GetUniqueDeviceIdentifier(text, i);
				}
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.LlOYqVqStUfkrLCNokMtPBWupPTk();
				djgDwAxqFXePqhrOKRPwoQMqDzgpA.Add(rBQryuJBtiXqGHrBUQOVsqHTpbqb2);
				num++;
			}
		}
		LQMARFjqJCVrdEGlIGFtsniBWDYlA = num;
		FaNMPFlVPwVEfmdTxJbYRmfznyuG(lQMARFjqJCVrdEGlIGFtsniBWDYlA, num, list, djgDwAxqFXePqhrOKRPwoQMqDzgpA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(djgDwAxqFXePqhrOKRPwoQMqDzgpA[j]));
			}
		}
		GIUCQHkuUXoKLVcLPETdfCMkaxOrB(list, djgDwAxqFXePqhrOKRPwoQMqDzgpA, false);
		GIUCQHkuUXoKLVcLPETdfCMkaxOrB(djgDwAxqFXePqhrOKRPwoQMqDzgpA, list, true);
		ARUgMDRBmgmayZGddkJSdGhDrfli = P_0;
	}

	private void MZUMxazZjmOraCssevleWsxlzAqs(UpdateLoopType P_0)
	{
		int count = djgDwAxqFXePqhrOKRPwoQMqDzgpA.Count;
		for (int i = 0; i < count; i++)
		{
			if (djgDwAxqFXePqhrOKRPwoQMqDzgpA[i] != null)
			{
				djgDwAxqFXePqhrOKRPwoQMqDzgpA[i].Update();
			}
		}
	}

	private void FaNMPFlVPwVEfmdTxJbYRmfznyuG(int P_0, int P_1, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_2, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(rBQryuJBtiXqGHrBUQOVsqHTpbqb.optMJkRNNObEuYhbZdRxmcJXEUuM);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			OvycPCJCfCHHVYqWVdpDbrafrGLYA(P_1, P_3, P_0, P_2, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj.Exact);
			OvycPCJCfCHHVYqWVdpDbrafrGLYA(P_1, P_3, P_0, P_2, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj.Approximate);
		}
		siGMCfpBVgKyVODuSwhDSAagaBLE(P_1, P_3, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj.Exact);
		siGMCfpBVgKyVODuSwhDSAagaBLE(P_1, P_3, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb2 = P_3[i];
			if (rBQryuJBtiXqGHrBUQOVsqHTpbqb2 != null && rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = qLeNJGIevWfkQkCZfEZWNcCQJkVZ(P_3);
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ReInput.GetNewJoystickId();
				SiGtAwflDjzWBOhOTnqgLmBrgoMb.WaLBaAkcmSDcCYYABFhREBKNWLoFb(rBQryuJBtiXqGHrBUQOVsqHTpbqb2);
			}
		}
		P_3.Sort(rBQryuJBtiXqGHrBUQOVsqHTpbqb.JgJrxhAcXqRkKNEOtxRNnTKgxzxu);
	}

	private void eNkafOMOeyQEwzWUbWaxzGtspjMD(List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_0, int P_1, int P_2)
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

	private bool kJXnhAbtWlbrKBeRhrdPWNSShnFS(List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_0, int P_1)
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

	private int qLeNJGIevWfkQkCZfEZWNcCQJkVZ(List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_0)
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

	private bool DejEHhtheVDEPFQnZLBioHUOYnTFA(List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_0, int P_1)
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

	private void OvycPCJCfCHHVYqWVdpDbrafrGLYA(int P_0, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_1, int P_2, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_3, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj P_4)
	{
		int num = ((P_4 != kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb2 = P_1[i];
			if (rBQryuJBtiXqGHrBUQOVsqHTpbqb2 == null || rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb3 = P_3[j];
				if (rBQryuJBtiXqGHrBUQOVsqHTpbqb3 != null && !DejEHhtheVDEPFQnZLBioHUOYnTFA(P_1, rBQryuJBtiXqGHrBUQOVsqHTpbqb3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && rBQryuJBtiXqGHrBUQOVsqHTpbqb2.AqUEhjZrwoBFirjRylMUDHlSbnxgA(rBQryuJBtiXqGHrBUQOVsqHTpbqb3) >= num)
				{
					rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = rBQryuJBtiXqGHrBUQOVsqHTpbqb3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = rBQryuJBtiXqGHrBUQOVsqHTpbqb3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
					{
						rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId = rBQryuJBtiXqGHrBUQOVsqHTpbqb3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EunityId;
					}
					SiGtAwflDjzWBOhOTnqgLmBrgoMb.WaLBaAkcmSDcCYYABFhREBKNWLoFb(rBQryuJBtiXqGHrBUQOVsqHTpbqb2);
				}
			}
		}
	}

	private void siGMCfpBVgKyVODuSwhDSAagaBLE(int P_0, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_1, kOGoVwTPsIMVSjWArSCqMtGSAcGb.TwlcoiYQtTQgCYWuctUjTrWRshUj P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb2 = P_1[i];
			if (rBQryuJBtiXqGHrBUQOVsqHTpbqb2 == null || rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			kOGoVwTPsIMVSjWArSCqMtGSAcGb.BAFOgeJJTnfJGIvMfUTdpejHMUaW bAFOgeJJTnfJGIvMfUTdpejHMUaW = null;
			foreach (kOGoVwTPsIMVSjWArSCqMtGSAcGb.BAFOgeJJTnfJGIvMfUTdpejHMUaW item in SiGtAwflDjzWBOhOTnqgLmBrgoMb.qDjtDqFFFSmlvABzsnrkSBzkdGSN(rBQryuJBtiXqGHrBUQOVsqHTpbqb2, P_2))
			{
				if (!DejEHhtheVDEPFQnZLBioHUOYnTFA(P_1, item.GeydmJCEJZXEAkYQQZGLIWgNGbNgb) && item.fmAzvjwYwHPFxyeYhPPNPaTLeHifA >= 0)
				{
					bAFOgeJJTnfJGIvMfUTdpejHMUaW = item;
					break;
				}
			}
			if (bAFOgeJJTnfJGIvMfUTdpejHMUaW != null)
			{
				int num = bAFOgeJJTnfJGIvMfUTdpejHMUaW.fmAzvjwYwHPFxyeYhPPNPaTLeHifA;
				if (!kJXnhAbtWlbrKBeRhrdPWNSShnFS(P_1, num))
				{
					num = (bAFOgeJJTnfJGIvMfUTdpejHMUaW.fmAzvjwYwHPFxyeYhPPNPaTLeHifA = qLeNJGIevWfkQkCZfEZWNcCQJkVZ(P_1));
				}
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = bAFOgeJJTnfJGIvMfUTdpejHMUaW.GeydmJCEJZXEAkYQQZGLIWgNGbNgb;
				SiGtAwflDjzWBOhOTnqgLmBrgoMb.WaLBaAkcmSDcCYYABFhREBKNWLoFb(rBQryuJBtiXqGHrBUQOVsqHTpbqb2);
			}
		}
	}

	private void eJwnetMwhlsKqQnKFEjTWqPXcrODA()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (kSZxlTVBXAfocyCLnCKGFEmEZIDr || GsoigljsReEjkVbkJEwHVOrQJKMj(joystickNames))
		{
			bjaDLgjxdKwJzIfkQiFlYxIjiNzlA(joystickNames);
		}
		tjnWqmiXAFFehchKPDfqaCqIPweW = false;
		if (kSZxlTVBXAfocyCLnCKGFEmEZIDr)
		{
			kSZxlTVBXAfocyCLnCKGFEmEZIDr = false;
		}
	}

	private bool GsoigljsReEjkVbkJEwHVOrQJKMj(string[] P_0)
	{
		if (P_0.Length != ARUgMDRBmgmayZGddkJSdGhDrfli.Length)
		{
			return true;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (!string.Equals(P_0[i], ARUgMDRBmgmayZGddkJSdGhDrfli[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	private void GIUCQHkuUXoKLVcLPETdfCMkaxOrB(List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_0, List<rBQryuJBtiXqGHrBUQOVsqHTpbqb> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb2 = P_0[i];
			if (rBQryuJBtiXqGHrBUQOVsqHTpbqb2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					rBQryuJBtiXqGHrBUQOVsqHTpbqb rBQryuJBtiXqGHrBUQOVsqHTpbqb3 = P_1[j];
					if (rBQryuJBtiXqGHrBUQOVsqHTpbqb3 != null && rBQryuJBtiXqGHrBUQOVsqHTpbqb2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == rBQryuJBtiXqGHrBUQOVsqHTpbqb3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				dGSeeDhfRutzEBjEGZdANWwvDjoh(P_0[i], P_2);
			}
		}
	}

	private void dGSeeDhfRutzEBjEGZdANWwvDjoh(rBQryuJBtiXqGHrBUQOVsqHTpbqb P_0, bool P_1)
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

	private void ftQodZFqvjGOoWalEPEwgWTsoYLv()
	{
		if (DRkTIPBGIxAJWvyQevIlJxKUqmSd == XIIvyKvirBGsUXxkHgxMrrPZmfHT && ZisbquTDwtduBEzXMSwcHfmSuzqp.Update())
		{
			tjnWqmiXAFFehchKPDfqaCqIPweW = true;
			ZisbquTDwtduBEzXMSwcHfmSuzqp.Start();
		}
	}
}
