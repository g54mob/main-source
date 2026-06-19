using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class dnJJlCvkyWsJFkQFpOPAltwceYg : PlatformInputManager, ofDdrrXOoPYnlTBBhXLegRaygjXC
{
	private class xttSOAxySzBEQLtvGhlaStamuIY : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int NajCXKtukqHbFEALjLVyGCYCNtSb;

		private int UMWomiZvEhDEPuJOYiXKDueLnyc;

		public Guid VUgBODHNCJPXSoOhhBOWRFfzFbGD;

		public string RxaFaRXqeYZbErOsosnUgQSpQhN;

		public readonly HXwClQTVyfqvGtLpLpnviaiWecIC igbQmSqThzEBDsBKZScaimlglKi;

		public rwUDYNAmSWwCoTDiwmZsStufkqWe wviegHeumjDVgSdipDjNQtyBLDB;

		public xqYBxITugRxezsSPWmytYtNDnmT wlGyzJWWOKDXLrNCpUopceovTWD;

		public string kxKCChAepXZZMUCPgfBLnfqoDYsI;

		public string IBLmgPovQLSZcNmAXhMIAhsmJVX;

		public int hhkcLloTZcVDgCdaTwOpzCelsoR;

		public Guid ypBhwPylZXgbWvdXwgdHvTJZNDf;

		public Guid giPzSxcdmJFlxkpGRptEQPgrFzn;

		public Guid YTUiBjSgszCjFKdQcXGXQLdjmPC;

		public int oidArcJIfGQvDhinAUSWvxCbFPQc;

		public bool TIjeAxRHlSqfwwEReELjSBfzpeh;

		public string BDNzUFwhASNOsMHGagnuFDeiUNc;

		public string iZnrpEOOjlDqSDsjMdinrkqThZr;

		public int odPqVuqwqCGxHoMYKpamBTSJBGU;

		public int rxWqrCZnPtiqWFbRznNyTZvGOEF;

		public int tsubhXPAkivKUjJndgFvgCYtCih;

		public int uELhfbdZYGHumCLLdtArLMIvIGxA;

		public int ZjLWaiKAEkbMVYsMXPeYLhgiSLG;

		public bool wTIUKRsZMOmpZhNBlfPZhbzhGk;

		private float[] PdhmHHQzLgjPZAoxHUYVuyeAAEh;

		private bool[] tBDNhubiBrrcAkNhlDXEHdQeLZEA;

		private HardwareJoystickMap_InputManager VwkQKXgoNahhCiMQWLUMFSQOAvBb;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

		private bool odakGqXSybzjkLavhBfCeptlajT;

		private bool FZwJHUUPwuLUimELESGrJJjnaNW;

		private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return NajCXKtukqHbFEALjLVyGCYCNtSb;
			}
			set
			{
				NajCXKtukqHbFEALjLVyGCYCNtSb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return UMWomiZvEhDEPuJOYiXKDueLnyc;
			}
			set
			{
				UMWomiZvEhDEPuJOYiXKDueLnyc = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (RxaFaRXqeYZbErOsosnUgQSpQhN != "Unknown Controller")
				{
					return RxaFaRXqeYZbErOsosnUgQSpQhN;
				}
				if (TIjeAxRHlSqfwwEReELjSBfzpeh && !string.IsNullOrEmpty(BDNzUFwhASNOsMHGagnuFDeiUNc))
				{
					return BDNzUFwhASNOsMHGagnuFDeiUNc;
				}
				return IBLmgPovQLSZcNmAXhMIAhsmJVX;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (UMWomiZvEhDEPuJOYiXKDueLnyc < 0)
				{
					return null;
				}
				return UMWomiZvEhDEPuJOYiXKDueLnyc;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => ypBhwPylZXgbWvdXwgdHvTJZNDf;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public xttSOAxySzBEQLtvGhlaStamuIY(HXwClQTVyfqvGtLpLpnviaiWecIC sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			igbQmSqThzEBDsBKZScaimlglKi = sourceJoystick;
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			UMWomiZvEhDEPuJOYiXKDueLnyc = -1;
			NajCXKtukqHbFEALjLVyGCYCNtSb = -1;
		}

		public void awLKiXcoOFmnokthljbUZIrPZrq()
		{
			YTUiBjSgszCjFKdQcXGXQLdjmPC = MiscTools.CreateGuidHashSHA1(IBLmgPovQLSZcNmAXhMIAhsmJVX + giPzSxcdmJFlxkpGRptEQPgrFzn);
			odPqVuqwqCGxHoMYKpamBTSJBGU = tsubhXPAkivKUjJndgFvgCYtCih;
			rxWqrCZnPtiqWFbRznNyTZvGOEF = uELhfbdZYGHumCLLdtArLMIvIGxA + ZjLWaiKAEkbMVYsMXPeYLhgiSLG * 8;
			TGqlSqzKzTCPYwisxjGzscmapHG();
			VUgBODHNCJPXSoOhhBOWRFfzFbGD = VwkQKXgoNahhCiMQWLUMFSQOAvBb.hardwareMapIdentifier.guid;
			RxaFaRXqeYZbErOsosnUgQSpQhN = VwkQKXgoNahhCiMQWLUMFSQOAvBb.controllerName;
			odakGqXSybzjkLavhBfCeptlajT = ((VUgBODHNCJPXSoOhhBOWRFfzFbGD == Guid.Empty) ? true : false);
			PdhmHHQzLgjPZAoxHUYVuyeAAEh = new float[odPqVuqwqCGxHoMYKpamBTSJBGU];
			tBDNhubiBrrcAkNhlDXEHdQeLZEA = new bool[rxWqrCZnPtiqWFbRznNyTZvGOEF];
			igbQmSqThzEBDsBKZScaimlglKi.SLLPWXkdwSWuCebTNNLdcVukhel();
			Update();
		}

		public void eaxwcXMwRKCkmHbjLyonEghfcUhe(xttSOAxySzBEQLtvGhlaStamuIY P_0)
		{
			if (P_0 != null)
			{
				UMWomiZvEhDEPuJOYiXKDueLnyc = P_0.UMWomiZvEhDEPuJOYiXKDueLnyc;
				NajCXKtukqHbFEALjLVyGCYCNtSb = P_0.NajCXKtukqHbFEALjLVyGCYCNtSb;
				for (int i = 0; i < MathTools.Min(tBDNhubiBrrcAkNhlDXEHdQeLZEA.Length, P_0.tBDNhubiBrrcAkNhlDXEHdQeLZEA.Length); i++)
				{
					tBDNhubiBrrcAkNhlDXEHdQeLZEA[i] = P_0.tBDNhubiBrrcAkNhlDXEHdQeLZEA[i];
				}
				for (int j = 0; j < MathTools.Min(PdhmHHQzLgjPZAoxHUYVuyeAAEh.Length, P_0.PdhmHHQzLgjPZAoxHUYVuyeAAEh.Length); j++)
				{
					PdhmHHQzLgjPZAoxHUYVuyeAAEh[j] = P_0.PdhmHHQzLgjPZAoxHUYVuyeAAEh[j];
				}
				FZwJHUUPwuLUimELESGrJJjnaNW = P_0.FZwJHUUPwuLUimELESGrJJjnaNW;
				igbQmSqThzEBDsBKZScaimlglKi.eaxwcXMwRKCkmHbjLyonEghfcUhe(P_0.igbQmSqThzEBDsBKZScaimlglKi);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			igbQmSqThzEBDsBKZScaimlglKi.SGjNzeeFRMimPyTnCrUvIiCnKKq();
			bool[] currentButtonValues = igbQmSqThzEBDsBKZScaimlglKi.CurrentButtonValues;
			int[] mjGaOhCCwwikLNutAItaFHduVBV = igbQmSqThzEBDsBKZScaimlglKi.joystickState.mjGaOhCCwwikLNutAItaFHduVBV;
			IhdIeUwZwRLqiJyYdCtNVPXciIb(currentButtonValues, mjGaOhCCwwikLNutAItaFHduVBV);
			xHNCeTbZYBVqRMCQRrncKAxpnCcM(currentButtonValues, mjGaOhCCwwikLNutAItaFHduVBV);
			igbQmSqThzEBDsBKZScaimlglKi.gXADYrdzIttymTRoaKqLkIyUtDJ();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (odPqVuqwqCGxHoMYKpamBTSJBGU != dataUpdater.axisCount || rxWqrCZnPtiqWFbRznNyTZvGOEF != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < odPqVuqwqCGxHoMYKpamBTSJBGU; i++)
			{
				dataUpdater.axisValues[i] = PdhmHHQzLgjPZAoxHUYVuyeAAEh[i];
			}
			for (int j = 0; j < rxWqrCZnPtiqWFbRznNyTZvGOEF; j++)
			{
				dataUpdater.buttonValues[j] = tBDNhubiBrrcAkNhlDXEHdQeLZEA[j];
			}
			if (FZwJHUUPwuLUimELESGrJJjnaNW && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int KyAfiLYcJFhJNpOgrDEhxwnhNoD(xttSOAxySzBEQLtvGhlaStamuIY P_0)
		{
			if (P_0.NajCXKtukqHbFEALjLVyGCYCNtSb == NajCXKtukqHbFEALjLVyGCYCNtSb)
			{
				return 2;
			}
			if (tsubhXPAkivKUjJndgFvgCYtCih != P_0.tsubhXPAkivKUjJndgFvgCYtCih)
			{
				return 0;
			}
			if (uELhfbdZYGHumCLLdtArLMIvIGxA != P_0.uELhfbdZYGHumCLLdtArLMIvIGxA)
			{
				return 0;
			}
			if (ZjLWaiKAEkbMVYsMXPeYLhgiSLG != P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC == YTUiBjSgszCjFKdQcXGXQLdjmPC)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo FdleSbAIfzeupXihLnJRPTOJTSuk()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			eVVvseUpGSgpqZdXlHEbWYuzpch(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			eVVvseUpGSgpqZdXlHEbWYuzpch(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(NajCXKtukqHbFEALjLVyGCYCNtSb);
		}

		public bool YXHHdWXxvTPYwRhsUBWBnayhySV()
		{
			try
			{
				igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf.zSYjzvkNxnwVckwIIzeLeusOegS();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void QqViEWwhZaWrvATfPuWfqnkWwbi()
		{
			try
			{
				if (igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf != null)
				{
					igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf.QqViEWwhZaWrvATfPuWfqnkWwbi();
				}
			}
			catch
			{
			}
		}

		public void JkxbMOPQiVSbeNRGETMYZahHimc()
		{
			try
			{
				if (igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf != null)
				{
					igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf.JkxbMOPQiVSbeNRGETMYZahHimc();
				}
			}
			catch
			{
			}
		}

		private void IhdIeUwZwRLqiJyYdCtNVPXciIb(bool[] P_0, int[] P_1)
		{
			if (odPqVuqwqCGxHoMYKpamBTSJBGU <= 0)
			{
				return;
			}
			switch (VwkQKXgoNahhCiMQWLUMFSQOAvBb.map.platform)
			{
			case InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX:
			{
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = platform_RawInput_Base.Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						TZtvkoZhamkXyDxmbLPRqzoeirq(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = platform_DirectInput_Base.Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						TZtvkoZhamkXyDxmbLPRqzoeirq(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void xHNCeTbZYBVqRMCQRrncKAxpnCcM(bool[] P_0, int[] P_1)
		{
			if (rxWqrCZnPtiqWFbRznNyTZvGOEF <= 0)
			{
				return;
			}
			switch (VwkQKXgoNahhCiMQWLUMFSQOAvBb.map.platform)
			{
			case InputPlatform.HnmsmUSKysdUvrNYWdqtigLcwDX:
			{
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = platform_RawInput_Base.Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						VqJtHEGbHByZNiOMEpxzghFtXwK(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = platform_DirectInput_Base.Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						VqJtHEGbHByZNiOMEpxzghFtXwK(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void TZtvkoZhamkXyDxmbLPRqzoeirq(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= odPqVuqwqCGxHoMYKpamBTSJBGU)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			PdhmHHQzLgjPZAoxHUYVuyeAAEh[P_1] = CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0, P_2, P_3);
			if (!FZwJHUUPwuLUimELESGrJJjnaNW && PdhmHHQzLgjPZAoxHUYVuyeAAEh[P_1] != 0f)
			{
				FZwJHUUPwuLUimELESGrJJjnaNW = true;
			}
		}

		private void VqJtHEGbHByZNiOMEpxzghFtXwK(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= rxWqrCZnPtiqWFbRznNyTZvGOEF)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			tBDNhubiBrrcAkNhlDXEHdQeLZEA[P_1] = golTpfekpJZdxAtdMfSTzBKxebB(P_0, P_2, P_3);
			if (!FZwJHUUPwuLUimELESGrJJjnaNW && tBDNhubiBrrcAkNhlDXEHdQeLZEA[P_1])
			{
				FZwJHUUPwuLUimELESGrJJjnaNW = true;
			}
		}

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return CCwCnYhEmaFZrOQeiMBHgUHikwcc((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 128)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ZjLWaiKAEkbMVYsMXPeYLhgiSLG || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = bVkYilBptDFBBxeggyXamyleLyY(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = bVkYilBptDFBBxeggyXamyleLyY(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
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
						if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && KcfsmpRBxcTGrLJKxoRyPeEhvxp(customCalculationSourceData[i], out var item))
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
			return 0f;
		}

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => igbQmSqThzEBDsBKZScaimlglKi.joystickState.lSOdwKYaTJSJyAWJnADwkSPKwkp, 
				DirectInputAxis.Y => igbQmSqThzEBDsBKZScaimlglKi.joystickState.ZqYMkLdonrbLPbHprxydzkIAizSD, 
				DirectInputAxis.Z => igbQmSqThzEBDsBKZScaimlglKi.joystickState.ZCWmLKzOWxAhKMWTYgDsRddDcsH, 
				DirectInputAxis.RotationX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.QJRrLLtvpVSruBRVLArwGYQMcpu, 
				DirectInputAxis.RotationY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.BOKlOKYVZEOuFAUbQpaozXxlJLT, 
				DirectInputAxis.RotationZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.KcNguPRBcVFahKHEeFjVfyEUICq, 
				DirectInputAxis.Slider0 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.kOTbATLrHUAzqUGYbrGymJRChLf[0], 
				DirectInputAxis.Slider1 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.kOTbATLrHUAzqUGYbrGymJRChLf[1], 
				DirectInputAxis.VelocityX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.aLYcVdnngwQTGScFELFOZJkACal, 
				DirectInputAxis.VelocityY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.jmgmlfbNnrGKbhYjqDCCUpHoyNP, 
				DirectInputAxis.VelocityZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.KOjGaOmQavMiInvlvLUCiAcXxgq, 
				DirectInputAxis.AngularVelocityX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.cxleXfUgzAndpnBlKJqCEdajwSZ, 
				DirectInputAxis.AngularVelocityY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.OXJKxPiCBcVNFClDsYrOoltyGaq, 
				DirectInputAxis.AngularVelocityZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.rPlabENtGjTbZOLpKtFIzAQtJrn, 
				DirectInputAxis.VelocitySlider0 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.PHyppMeuhEjzvzFJsZXBvTQRUZ[0], 
				DirectInputAxis.VelocitySlider1 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.PHyppMeuhEjzvzFJsZXBvTQRUZ[1], 
				DirectInputAxis.AccelerationX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.YUkBHnfHmowIOjoqWFbjElYAKue, 
				DirectInputAxis.AccelerationY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.glnFLQjzqvYRHGlkpvoGopNjdxPe, 
				DirectInputAxis.AccelerationZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.JZlTzRQIAqLJWfgFixAwfHUHbLs, 
				DirectInputAxis.AngularAccelerationX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.WMhDjMgPtLMQXvpjnKiwrpSljcMh, 
				DirectInputAxis.AngularAccelerationY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.qrIdbXguNMaKOPCEUDSvXHhMMRb, 
				DirectInputAxis.AngularAccelerationZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.FLNnsqCjMYooxIshTWFrrUQYMnA, 
				DirectInputAxis.AccelerationSlider0 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.FyymDKayGxwaLQWiNfDcbIMVYAa[0], 
				DirectInputAxis.AccelerationSlider1 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.FyymDKayGxwaLQWiNfDcbIMVYAa[1], 
				DirectInputAxis.ForceX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.JMmAqTFPPRmWmARmkiHPkejHKrJb, 
				DirectInputAxis.ForceY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.VHJeVXSsaEUfvCuLuCsmRTJBgTE, 
				DirectInputAxis.ForceZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.AdeHmHjbARmAjReDYwlcLOMZCdsS, 
				DirectInputAxis.TorqueX => igbQmSqThzEBDsBKZScaimlglKi.joystickState.NURxWdlMGfdVbIzwhEayywMtvdm, 
				DirectInputAxis.TorqueY => igbQmSqThzEBDsBKZScaimlglKi.joystickState.PumexRLcmgGcDITGyGUiVrtgSWsL, 
				DirectInputAxis.TorqueZ => igbQmSqThzEBDsBKZScaimlglKi.joystickState.aeWJElqjemricEIgFebzBxlLot, 
				DirectInputAxis.ForceSlider0 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.HFvILfAusGkfxxAHiuFLAfpWlfoh[0], 
				DirectInputAxis.ForceSlider1 => igbQmSqThzEBDsBKZScaimlglKi.joystickState.HFvILfAusGkfxxAHiuFLAfpWlfoh[1], 
				_ => 0f, 
			};
		}

		private bool golTpfekpJZdxAtdMfSTzBKxebB(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
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
						if (!P_1[P_0.requiredButtons[j]])
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
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 128)
				{
					return false;
				}
				return P_1[sourceButton];
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis > 32)
				{
					return false;
				}
				float num = CCwCnYhEmaFZrOQeiMBHgUHikwcc((DirectInputAxis)P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ZjLWaiKAEkbMVYsMXPeYLhgiSLG || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return mVkxGfqHdFJcAwxyxMgTjGelngm(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
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
						if (fxsoyeapiGPPfniaETknruGnSwC(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (KcfsmpRBxcTGrLJKxoRyPeEhvxp(customCalculationSourceData[k], out var num2))
						{
							customCalculation.AddData((num2 != 0f) ? 1f : 0f);
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
			return false;
		}

		private bool mVkxGfqHdFJcAwxyxMgTjGelngm(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (VwkQKXgoNahhCiMQWLUMFSQOAvBb.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return false;
			}
			int num3;
			int num4;
			if (P_2 == HatType.EightWay)
			{
				num3 = 31500;
				num4 = 4500;
			}
			else
			{
				num3 = 27000;
				num4 = 9000;
			}
			if (P_1 == 0 && P_0 > num3)
			{
				P_0 -= 36000;
			}
			if (P_0 < num2 + num4 && P_0 > num2 - num4)
			{
				return true;
			}
			return false;
		}

		private float bVkYilBptDFBBxeggyXamyleLyY(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private bool fxsoyeapiGPPfniaETknruGnSwC(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool KcfsmpRBxcTGrLJKxoRyPeEhvxp(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
			{
				return false;
			}
			P_1 = CCwCnYhEmaFZrOQeiMBHgUHikwcc((DirectInputAxis)P_0.sourceAxis);
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
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType bUTFRZdfxRoiwDhegSpiHibYjyf(xqYBxITugRxezsSPWmytYtNDnmT P_0)
		{
			return P_0 switch
			{
				xqYBxITugRxezsSPWmytYtNDnmT.bheAcljDHpoAOeHYhiVCoSJIEJwV => ControlDeviceType.fQYnmvKyNAUpwLJlHByyedaPIyZG, 
				xqYBxITugRxezsSPWmytYtNDnmT.wopKQFfSLcafzbyCVCGaJLucPYz => ControlDeviceType.uiRYEFedDHmUTxShoQfUcCLjblSE, 
				xqYBxITugRxezsSPWmytYtNDnmT.vFmwJbshzNEkREUTCqstpmqTaAKd => ControlDeviceType.xMAFLxhGvaUFxGrktALTXyTGqvn, 
				xqYBxITugRxezsSPWmytYtNDnmT.QWzvIXfHqDcsOQVtNnKAnsyXzLg => ControlDeviceType.EbLlCRijimOLmWyMuIbuKxBCfaJ, 
				xqYBxITugRxezsSPWmytYtNDnmT.ZPeapYOijseJEWhKaykVFYevbmZ => ControlDeviceType.JzOfRMXzRJiFcWfjBLnlifDuePs, 
				xqYBxITugRxezsSPWmytYtNDnmT.nOpxFTcuYUeuvxBpcnMYjZuiPtr => ControlDeviceType.JpBULrWxTbhulfeUVTyGbaKAXYS, 
				_ => ControlDeviceType.eDgdySKclHgXmmILffzdHPvUtEi, 
			};
		}

		private void TGqlSqzKzTCPYwisxjGzscmapHG()
		{
			VwkQKXgoNahhCiMQWLUMFSQOAvBb = bKHIVnLAXWYbMiOIyqMJrMzriBW(FdleSbAIfzeupXihLnJRPTOJTSuk());
			if (VwkQKXgoNahhCiMQWLUMFSQOAvBb == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			odPqVuqwqCGxHoMYKpamBTSJBGU = VwkQKXgoNahhCiMQWLUMFSQOAvBb.axisCount;
			rxWqrCZnPtiqWFbRznNyTZvGOEF = VwkQKXgoNahhCiMQWLUMFSQOAvBb.buttonCount;
		}

		private void aDxANYEKtammtxiYgxIVMuvChwQ()
		{
		}

		private string DHbCKXzEIVryDGDmMuQHNdHAMFk()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.DirectInput}{((TIjeAxRHlSqfwwEReELjSBfzpeh && !string.IsNullOrEmpty(BDNzUFwhASNOsMHGagnuFDeiUNc)) ? BDNzUFwhASNOsMHGagnuFDeiUNc : IBLmgPovQLSZcNmAXhMIAhsmJVX)}{hhkcLloTZcVDgCdaTwOpzCelsoR}{giPzSxcdmJFlxkpGRptEQPgrFzn}");
		}

		private void eVVvseUpGSgpqZdXlHEbWYuzpch(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = bUTFRZdfxRoiwDhegSpiHibYjyf(wlGyzJWWOKDXLrNCpUopceovTWD);
			P_0.hardwareIdentifier = DHbCKXzEIVryDGDmMuQHNdHAMFk();
			P_0.hardwareAxisCount = tsubhXPAkivKUjJndgFvgCYtCih;
			P_0.hardwareButtonCount = uELhfbdZYGHumCLLdtArLMIvIGxA;
			P_0.hardwareHatCount = ZjLWaiKAEkbMVYsMXPeYLhgiSLG;
			P_0.hw_productName = IBLmgPovQLSZcNmAXhMIAhsmJVX;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_productId = hhkcLloTZcVDgCdaTwOpzCelsoR;
			P_0.hw_pidVid = new PidVid(giPzSxcdmJFlxkpGRptEQPgrFzn);
			P_0.hw_isBluetoothDevice = TIjeAxRHlSqfwwEReELjSBfzpeh;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(BDNzUFwhASNOsMHGagnuFDeiUNc)) ? BDNzUFwhASNOsMHGagnuFDeiUNc : string.Empty);
			P_0.definitionMatchTag = iZnrpEOOjlDqSDsjMdinrkqThZr;
		}

		private void eVVvseUpGSgpqZdXlHEbWYuzpch(BridgedController P_0)
		{
			eVVvseUpGSgpqZdXlHEbWYuzpch((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = VwkQKXgoNahhCiMQWLUMFSQOAvBb.ToGameHardwareControllerMap();
			P_0.instanceName = kxKCChAepXZZMUCPgfBLnfqoDYsI;
			P_0.productName = IBLmgPovQLSZcNmAXhMIAhsmJVX;
			P_0.isXInputDevice = wTIUKRsZMOmpZhNBlfPZhbzhGk;
			P_0.axisCount = odPqVuqwqCGxHoMYKpamBTSJBGU;
			P_0.buttonCount = rxWqrCZnPtiqWFbRznNyTZvGOEF;
			P_0.unknownControllerHats = NhzPiRcnZCCXfbyviPcQNUGlGHLo();
			P_0.controllerTypeGuid = VUgBODHNCJPXSoOhhBOWRFfzFbGD;
			P_0.controllerExtension = extension;
		}

		private void GZJOVqtzFnuulSFDMOgQNpJxYuk()
		{
			for (int i = 0; i < rxWqrCZnPtiqWFbRznNyTZvGOEF; i++)
			{
				tBDNhubiBrrcAkNhlDXEHdQeLZEA[i] = false;
			}
			for (int j = 0; j < odPqVuqwqCGxHoMYKpamBTSJBGU; j++)
			{
				PdhmHHQzLgjPZAoxHUYVuyeAAEh[j] = 0f;
			}
		}

		private UnknownControllerHat[] NhzPiRcnZCCXfbyviPcQNUGlGHLo()
		{
			if (!odakGqXSybzjkLavhBfCeptlajT)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons buttons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(buttons);
			}
			return array;
		}

		public void LLOFbzNISIbRkZTwkaVnsPpYig()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(true);
			GC.SuppressFinalize(this);
		}

		~xttSOAxySzBEQLtvGhlaStamuIY()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(false);
		}

		protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
		{
			if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				if (P_0 && igbQmSqThzEBDsBKZScaimlglKi != null)
				{
					igbQmSqThzEBDsBKZScaimlglKi.Dispose();
				}
				dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			}
		}

		public static int kxOFZEPgjHEFCJiwzgahiMzQOiwI(xttSOAxySzBEQLtvGhlaStamuIY P_0, xttSOAxySzBEQLtvGhlaStamuIY P_1)
		{
			if (P_0.UMWomiZvEhDEPuJOYiXKDueLnyc < P_1.UMWomiZvEhDEPuJOYiXKDueLnyc)
			{
				return -1;
			}
			if (P_0.UMWomiZvEhDEPuJOYiXKDueLnyc > P_1.UMWomiZvEhDEPuJOYiXKDueLnyc)
			{
				return 1;
			}
			return 0;
		}

		public static int HQEqZQjEIqGDqYsLuCzAlfsgYsm(xttSOAxySzBEQLtvGhlaStamuIY P_0, xttSOAxySzBEQLtvGhlaStamuIY P_1)
		{
			if (P_0.oidArcJIfGQvDhinAUSWvxCbFPQc < P_1.oidArcJIfGQvDhinAUSWvxCbFPQc)
			{
				return -1;
			}
			if (P_0.oidArcJIfGQvDhinAUSWvxCbFPQc > P_1.oidArcJIfGQvDhinAUSWvxCbFPQc)
			{
				return 1;
			}
			return 0;
		}
	}

	private class HXwClQTVyfqvGtLpLpnviaiWecIC : IDisposable
	{
		public class rWewiDeItCkkJIPmulocnIePCBPh
		{
			public float lSOdwKYaTJSJyAWJnADwkSPKwkp;

			public float ZqYMkLdonrbLPbHprxydzkIAizSD;

			public float ZCWmLKzOWxAhKMWTYgDsRddDcsH;

			public float QJRrLLtvpVSruBRVLArwGYQMcpu;

			public float BOKlOKYVZEOuFAUbQpaozXxlJLT;

			public float KcNguPRBcVFahKHEeFjVfyEUICq;

			public float[] kOTbATLrHUAzqUGYbrGymJRChLf;

			public readonly int[] mjGaOhCCwwikLNutAItaFHduVBV;

			public readonly bool[] GjtzeSFrmMHuPyjYbDczCVRXyeJ;

			public float aLYcVdnngwQTGScFELFOZJkACal;

			public float jmgmlfbNnrGKbhYjqDCCUpHoyNP;

			public float KOjGaOmQavMiInvlvLUCiAcXxgq;

			public float cxleXfUgzAndpnBlKJqCEdajwSZ;

			public float OXJKxPiCBcVNFClDsYrOoltyGaq;

			public float rPlabENtGjTbZOLpKtFIzAQtJrn;

			public readonly float[] PHyppMeuhEjzvzFJsZXBvTQRUZ;

			public float YUkBHnfHmowIOjoqWFbjElYAKue;

			public float glnFLQjzqvYRHGlkpvoGopNjdxPe;

			public float JZlTzRQIAqLJWfgFixAwfHUHbLs;

			public float WMhDjMgPtLMQXvpjnKiwrpSljcMh;

			public float qrIdbXguNMaKOPCEUDSvXHhMMRb;

			public float FLNnsqCjMYooxIshTWFrrUQYMnA;

			public readonly float[] FyymDKayGxwaLQWiNfDcbIMVYAa;

			public float JMmAqTFPPRmWmARmkiHPkejHKrJb;

			public float VHJeVXSsaEUfvCuLuCsmRTJBgTE;

			public float AdeHmHjbARmAjReDYwlcLOMZCdsS;

			public float NURxWdlMGfdVbIzwhEayywMtvdm;

			public float PumexRLcmgGcDITGyGUiVrtgSWsL;

			public float aeWJElqjemricEIgFebzBxlLot;

			public readonly float[] HFvILfAusGkfxxAHiuFLAfpWlfoh;

			public rWewiDeItCkkJIPmulocnIePCBPh()
			{
				kOTbATLrHUAzqUGYbrGymJRChLf = new float[2];
				mjGaOhCCwwikLNutAItaFHduVBV = new int[4];
				GjtzeSFrmMHuPyjYbDczCVRXyeJ = new bool[128];
				PHyppMeuhEjzvzFJsZXBvTQRUZ = new float[2];
				FyymDKayGxwaLQWiNfDcbIMVYAa = new float[2];
				HFvILfAusGkfxxAHiuFLAfpWlfoh = new float[2];
			}

			public void rKJfCRBWFLQsKCjGykmcumzKLPwE()
			{
				lSOdwKYaTJSJyAWJnADwkSPKwkp = 0f;
				ZqYMkLdonrbLPbHprxydzkIAizSD = 0f;
				ZCWmLKzOWxAhKMWTYgDsRddDcsH = 0f;
				QJRrLLtvpVSruBRVLArwGYQMcpu = 0f;
				BOKlOKYVZEOuFAUbQpaozXxlJLT = 0f;
				KcNguPRBcVFahKHEeFjVfyEUICq = 0f;
				for (int i = 0; i < kOTbATLrHUAzqUGYbrGymJRChLf.Length; i++)
				{
					kOTbATLrHUAzqUGYbrGymJRChLf[i] = 0f;
				}
				for (int j = 0; j < mjGaOhCCwwikLNutAItaFHduVBV.Length; j++)
				{
					mjGaOhCCwwikLNutAItaFHduVBV[j] = 0;
				}
				for (int k = 0; k < GjtzeSFrmMHuPyjYbDczCVRXyeJ.Length; k++)
				{
					GjtzeSFrmMHuPyjYbDczCVRXyeJ[k] = false;
				}
				aLYcVdnngwQTGScFELFOZJkACal = 0f;
				jmgmlfbNnrGKbhYjqDCCUpHoyNP = 0f;
				KOjGaOmQavMiInvlvLUCiAcXxgq = 0f;
				cxleXfUgzAndpnBlKJqCEdajwSZ = 0f;
				OXJKxPiCBcVNFClDsYrOoltyGaq = 0f;
				rPlabENtGjTbZOLpKtFIzAQtJrn = 0f;
				for (int l = 0; l < PHyppMeuhEjzvzFJsZXBvTQRUZ.Length; l++)
				{
					PHyppMeuhEjzvzFJsZXBvTQRUZ[l] = 0f;
				}
				YUkBHnfHmowIOjoqWFbjElYAKue = 0f;
				glnFLQjzqvYRHGlkpvoGopNjdxPe = 0f;
				JZlTzRQIAqLJWfgFixAwfHUHbLs = 0f;
				WMhDjMgPtLMQXvpjnKiwrpSljcMh = 0f;
				qrIdbXguNMaKOPCEUDSvXHhMMRb = 0f;
				FLNnsqCjMYooxIshTWFrrUQYMnA = 0f;
				for (int m = 0; m < FyymDKayGxwaLQWiNfDcbIMVYAa.Length; m++)
				{
					FyymDKayGxwaLQWiNfDcbIMVYAa[m] = 0f;
				}
				JMmAqTFPPRmWmARmkiHPkejHKrJb = 0f;
				VHJeVXSsaEUfvCuLuCsmRTJBgTE = 0f;
				AdeHmHjbARmAjReDYwlcLOMZCdsS = 0f;
				NURxWdlMGfdVbIzwhEayywMtvdm = 0f;
				PumexRLcmgGcDITGyGUiVrtgSWsL = 0f;
				aeWJElqjemricEIgFebzBxlLot = 0f;
				for (int n = 0; n < HFvILfAusGkfxxAHiuFLAfpWlfoh.Length; n++)
				{
					HFvILfAusGkfxxAHiuFLAfpWlfoh[n] = 0f;
				}
			}

			public void VpAIKPbOJQWFpjXrnVZoafNPJEv(rWewiDeItCkkJIPmulocnIePCBPh P_0)
			{
				lSOdwKYaTJSJyAWJnADwkSPKwkp = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp;
				ZqYMkLdonrbLPbHprxydzkIAizSD = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD;
				ZCWmLKzOWxAhKMWTYgDsRddDcsH = P_0.ZCWmLKzOWxAhKMWTYgDsRddDcsH;
				QJRrLLtvpVSruBRVLArwGYQMcpu = P_0.QJRrLLtvpVSruBRVLArwGYQMcpu;
				BOKlOKYVZEOuFAUbQpaozXxlJLT = P_0.BOKlOKYVZEOuFAUbQpaozXxlJLT;
				KcNguPRBcVFahKHEeFjVfyEUICq = P_0.KcNguPRBcVFahKHEeFjVfyEUICq;
				for (int i = 0; i < kOTbATLrHUAzqUGYbrGymJRChLf.Length; i++)
				{
					kOTbATLrHUAzqUGYbrGymJRChLf[i] = P_0.kOTbATLrHUAzqUGYbrGymJRChLf[i];
				}
				for (int j = 0; j < mjGaOhCCwwikLNutAItaFHduVBV.Length; j++)
				{
					mjGaOhCCwwikLNutAItaFHduVBV[j] = P_0.mjGaOhCCwwikLNutAItaFHduVBV[j];
				}
				for (int k = 0; k < GjtzeSFrmMHuPyjYbDczCVRXyeJ.Length; k++)
				{
					GjtzeSFrmMHuPyjYbDczCVRXyeJ[k] = P_0.GjtzeSFrmMHuPyjYbDczCVRXyeJ[k];
				}
				aLYcVdnngwQTGScFELFOZJkACal = P_0.aLYcVdnngwQTGScFELFOZJkACal;
				jmgmlfbNnrGKbhYjqDCCUpHoyNP = P_0.jmgmlfbNnrGKbhYjqDCCUpHoyNP;
				KOjGaOmQavMiInvlvLUCiAcXxgq = P_0.KOjGaOmQavMiInvlvLUCiAcXxgq;
				cxleXfUgzAndpnBlKJqCEdajwSZ = P_0.cxleXfUgzAndpnBlKJqCEdajwSZ;
				OXJKxPiCBcVNFClDsYrOoltyGaq = P_0.OXJKxPiCBcVNFClDsYrOoltyGaq;
				rPlabENtGjTbZOLpKtFIzAQtJrn = P_0.rPlabENtGjTbZOLpKtFIzAQtJrn;
				for (int l = 0; l < PHyppMeuhEjzvzFJsZXBvTQRUZ.Length; l++)
				{
					PHyppMeuhEjzvzFJsZXBvTQRUZ[l] = P_0.PHyppMeuhEjzvzFJsZXBvTQRUZ[l];
				}
				YUkBHnfHmowIOjoqWFbjElYAKue = P_0.YUkBHnfHmowIOjoqWFbjElYAKue;
				glnFLQjzqvYRHGlkpvoGopNjdxPe = P_0.glnFLQjzqvYRHGlkpvoGopNjdxPe;
				JZlTzRQIAqLJWfgFixAwfHUHbLs = P_0.JZlTzRQIAqLJWfgFixAwfHUHbLs;
				WMhDjMgPtLMQXvpjnKiwrpSljcMh = P_0.WMhDjMgPtLMQXvpjnKiwrpSljcMh;
				qrIdbXguNMaKOPCEUDSvXHhMMRb = P_0.qrIdbXguNMaKOPCEUDSvXHhMMRb;
				FLNnsqCjMYooxIshTWFrrUQYMnA = P_0.FLNnsqCjMYooxIshTWFrrUQYMnA;
				for (int m = 0; m < FyymDKayGxwaLQWiNfDcbIMVYAa.Length; m++)
				{
					FyymDKayGxwaLQWiNfDcbIMVYAa[m] = P_0.FyymDKayGxwaLQWiNfDcbIMVYAa[m];
				}
				JMmAqTFPPRmWmARmkiHPkejHKrJb = P_0.JMmAqTFPPRmWmARmkiHPkejHKrJb;
				VHJeVXSsaEUfvCuLuCsmRTJBgTE = P_0.VHJeVXSsaEUfvCuLuCsmRTJBgTE;
				AdeHmHjbARmAjReDYwlcLOMZCdsS = P_0.AdeHmHjbARmAjReDYwlcLOMZCdsS;
				NURxWdlMGfdVbIzwhEayywMtvdm = P_0.NURxWdlMGfdVbIzwhEayywMtvdm;
				PumexRLcmgGcDITGyGUiVrtgSWsL = P_0.PumexRLcmgGcDITGyGUiVrtgSWsL;
				aeWJElqjemricEIgFebzBxlLot = P_0.aeWJElqjemricEIgFebzBxlLot;
				for (int n = 0; n < HFvILfAusGkfxxAHiuFLAfpWlfoh.Length; n++)
				{
					HFvILfAusGkfxxAHiuFLAfpWlfoh[n] = P_0.HFvILfAusGkfxxAHiuFLAfpWlfoh[n];
				}
			}

			public unsafe void VpAIKPbOJQWFpjXrnVZoafNPJEv(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = ((int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart))[i];
					for (int j = 0; j < 32; j++)
					{
						GjtzeSFrmMHuPyjYbDczCVRXyeJ[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					FyymDKayGxwaLQWiNfDcbIMVYAa[k] = *ptr;
					ptr++;
				}
				YUkBHnfHmowIOjoqWFbjElYAKue = *ptr;
				ptr++;
				glnFLQjzqvYRHGlkpvoGopNjdxPe = *ptr;
				ptr++;
				JZlTzRQIAqLJWfgFixAwfHUHbLs = *ptr;
				ptr++;
				WMhDjMgPtLMQXvpjnKiwrpSljcMh = *ptr;
				ptr++;
				qrIdbXguNMaKOPCEUDSvXHhMMRb = *ptr;
				ptr++;
				FLNnsqCjMYooxIshTWFrrUQYMnA = *ptr;
				ptr++;
				cxleXfUgzAndpnBlKJqCEdajwSZ = *ptr;
				ptr++;
				OXJKxPiCBcVNFClDsYrOoltyGaq = *ptr;
				ptr++;
				rPlabENtGjTbZOLpKtFIzAQtJrn = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					HFvILfAusGkfxxAHiuFLAfpWlfoh[l] = *ptr;
					ptr++;
				}
				JMmAqTFPPRmWmARmkiHPkejHKrJb = *ptr;
				ptr++;
				VHJeVXSsaEUfvCuLuCsmRTJBgTE = *ptr;
				ptr++;
				AdeHmHjbARmAjReDYwlcLOMZCdsS = *ptr;
				ptr++;
				QJRrLLtvpVSruBRVLArwGYQMcpu = *ptr;
				ptr++;
				BOKlOKYVZEOuFAUbQpaozXxlJLT = *ptr;
				ptr++;
				KcNguPRBcVFahKHEeFjVfyEUICq = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					kOTbATLrHUAzqUGYbrGymJRChLf[m] = *ptr;
					ptr++;
				}
				NURxWdlMGfdVbIzwhEayywMtvdm = *ptr;
				ptr++;
				PumexRLcmgGcDITGyGUiVrtgSWsL = *ptr;
				ptr++;
				aeWJElqjemricEIgFebzBxlLot = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					PHyppMeuhEjzvzFJsZXBvTQRUZ[n] = *ptr;
					ptr++;
				}
				aLYcVdnngwQTGScFELFOZJkACal = *ptr;
				ptr++;
				jmgmlfbNnrGKbhYjqDCCUpHoyNP = *ptr;
				ptr++;
				KOjGaOmQavMiInvlvLUCiAcXxgq = *ptr;
				ptr++;
				lSOdwKYaTJSJyAWJnADwkSPKwkp = *ptr;
				ptr++;
				ZqYMkLdonrbLPbHprxydzkIAizSD = *ptr;
				ptr++;
				ZCWmLKzOWxAhKMWTYgDsRddDcsH = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					mjGaOhCCwwikLNutAItaFHduVBV[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void uPCmRSALwGFxkvcCGAyDZvqtBBm(PRfuElMMOSGhxJbUbIuaBSoRrQWL P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] pointOfViewControllers = P_0.PointOfViewControllers;
				int[] accelerationSliders = P_0.AccelerationSliders;
				int[] forceSliders = P_0.ForceSliders;
				int[] sliders = P_0.Sliders;
				int[] velocitySliders = P_0.VelocitySliders;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.Buttons[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						((int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart))[num2] = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(accelerationSliders[j]);
					ptr++;
				}
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AccelerationX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AccelerationY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AccelerationZ);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularAccelerationX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularAccelerationY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularAccelerationZ);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularVelocityX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularVelocityY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.AngularVelocityZ);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(forceSliders[k]);
					ptr++;
				}
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.ForceX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.ForceY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.ForceZ);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.RotationX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.RotationY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.RotationZ);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(sliders[l]);
					ptr++;
				}
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.TorqueX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.TorqueY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.TorqueZ);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(velocitySliders[m]);
					ptr++;
				}
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.VelocityX);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.VelocityY);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.VelocityZ);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.X);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.Y);
				ptr++;
				*ptr = jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.Z);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = pointOfViewControllers[n];
					ptr2++;
				}
			}
		}

		private const int CDkqRcAXyGoLjXMJasGxeNcFrGc = 2;

		private const int moJENldZCYyUIDqvnPjAOTLkxUs = 2;

		private const int PPqGuycJnaKWoZyaJVEdkjOaYycF = 128;

		private const int mtISLpzTlozeOgfdtjPTfEqQFUeG = 32;

		private const int SABgzaFtoMqeuNbInMYoFpNKMuJD = 0;

		private const int mxmudMknZtCGZYDXBvyQmHEXoTU = 264;

		private const int MbHvDUuPFZawRQnitieVdFmNUUm = 272;

		private readonly int fauThtVRGnbJeqNPRDhsAoxKMINP;

		private readonly ButtonLoopSet xMOAMIpUblwzclpASeqOvbiquVB;

		private readonly DualThreadLowLevelInputEventQueue vdRdcSJAmhdxgFuDQMtgOvYJsTt;

		private ycUnGIYlnwzxqvUOCLYDcpQUvKO fPBWEKdXUTkIFbZbjDFyVHIIMQm;

		private readonly PRfuElMMOSGhxJbUbIuaBSoRrQWL SefBsOKwDayLMvnoebnGWCbZFJK;

		private readonly PRfuElMMOSGhxJbUbIuaBSoRrQWL ViulEdmBtnERkQDvPfVeGLWdwbxr;

		private readonly object zrvbWkHMkcXMNovKdrSHskCzaDOb;

		private bool pNlLfCQUZtLDaiAkmVVUCWpVTeW;

		public readonly rfGUKNICXjMvSKkObEqIFzzuSJa ARbQMcDSmWJwSnMVxhlTeMoEfnf;

		private readonly rWewiDeItCkkJIPmulocnIePCBPh VBAJSEpHIGkcRoIrDWjrxDyzGRSE;

		private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

		public bool[] CurrentButtonValues => xMOAMIpUblwzclpASeqOvbiquVB.Current.effectiveValue;

		public rWewiDeItCkkJIPmulocnIePCBPh joystickState => VBAJSEpHIGkcRoIrDWjrxDyzGRSE;

		public HXwClQTVyfqvGtLpLpnviaiWecIC(rfGUKNICXjMvSKkObEqIFzzuSJa source, UpdateLoopSetting updateLoops)
		{
			ARbQMcDSmWJwSnMVxhlTeMoEfnf = source;
			fauThtVRGnbJeqNPRDhsAoxKMINP = source.Capabilities.vKVJSofBVFDiPCcbycKCGKIUjJfL;
			xMOAMIpUblwzclpASeqOvbiquVB = new ButtonLoopSet(updateLoops, fauThtVRGnbJeqNPRDhsAoxKMINP);
			vdRdcSJAmhdxgFuDQMtgOvYJsTt = new DualThreadLowLevelInputEventQueue((int)((float)tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickRefreshRate * 0.25f), 128, 32, 2);
			VBAJSEpHIGkcRoIrDWjrxDyzGRSE = new rWewiDeItCkkJIPmulocnIePCBPh();
			SefBsOKwDayLMvnoebnGWCbZFJK = new PRfuElMMOSGhxJbUbIuaBSoRrQWL();
			ViulEdmBtnERkQDvPfVeGLWdwbxr = new PRfuElMMOSGhxJbUbIuaBSoRrQWL();
			zrvbWkHMkcXMNovKdrSHskCzaDOb = new object();
			if (tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread != null)
			{
				tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread.ThreadUpdateEvent += NGvIPyOvZluZfmopLHzfBsvLuRu;
			}
		}

		public void SGjNzeeFRMimPyTnCrUvIiCnKKq()
		{
			xMOAMIpUblwzclpASeqOvbiquVB.SetUpdateLoop(ReInput.currentUpdateLoop);
			ZdkglmuvphcjivNwSDkawQYIaNe();
		}

		public void gXADYrdzIttymTRoaKqLkIyUtDJ()
		{
			xMOAMIpUblwzclpASeqOvbiquVB.Current.ClearWasTrueThisFrame();
		}

		public void SLLPWXkdwSWuCebTNNLdcVukhel()
		{
			IgqBTMgoLLDsubFJdJZiejmTNfb();
			pNlLfCQUZtLDaiAkmVVUCWpVTeW = true;
		}

		public void pxIDOEabnUcUluxaEwWKgTcoDWJc()
		{
			pNlLfCQUZtLDaiAkmVVUCWpVTeW = false;
			IgqBTMgoLLDsubFJdJZiejmTNfb();
		}

		public void eaxwcXMwRKCkmHbjLyonEghfcUhe(HXwClQTVyfqvGtLpLpnviaiWecIC P_0)
		{
			if (P_0 == null || P_0 == this || P_0.fauThtVRGnbJeqNPRDhsAoxKMINP != fauThtVRGnbJeqNPRDhsAoxKMINP)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
			{
				lock (P_0.zrvbWkHMkcXMNovKdrSHskCzaDOb)
				{
					xMOAMIpUblwzclpASeqOvbiquVB.Import(P_0.xMOAMIpUblwzclpASeqOvbiquVB);
					VBAJSEpHIGkcRoIrDWjrxDyzGRSE.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.VBAJSEpHIGkcRoIrDWjrxDyzGRSE);
					SefBsOKwDayLMvnoebnGWCbZFJK.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.SefBsOKwDayLMvnoebnGWCbZFJK);
					ViulEdmBtnERkQDvPfVeGLWdwbxr.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.ViulEdmBtnERkQDvPfVeGLWdwbxr);
					vdRdcSJAmhdxgFuDQMtgOvYJsTt.ImportAll(P_0.vdRdcSJAmhdxgFuDQMtgOvYJsTt);
					fPBWEKdXUTkIFbZbjDFyVHIIMQm = ycUnGIYlnwzxqvUOCLYDcpQUvKO.DQEQimyoSkCEIzaRbyPQwPtmYmc(P_0.fPBWEKdXUTkIFbZbjDFyVHIIMQm, SefBsOKwDayLMvnoebnGWCbZFJK);
					pNlLfCQUZtLDaiAkmVVUCWpVTeW = P_0.pNlLfCQUZtLDaiAkmVVUCWpVTeW;
				}
			}
		}

		public void RGngbfFWoPZHlGVwifsMxaRtQoz(int P_0, int P_1, int P_2, float P_3)
		{
			lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
			{
				fPBWEKdXUTkIFbZbjDFyVHIIMQm = new ycUnGIYlnwzxqvUOCLYDcpQUvKO(SefBsOKwDayLMvnoebnGWCbZFJK, P_0, P_1, P_2, P_3);
			}
		}

		private void NGvIPyOvZluZfmopLHzfBsvLuRu()
		{
			if (!pNlLfCQUZtLDaiAkmVVUCWpVTeW)
			{
				return;
			}
			double realTime;
			try
			{
				ARbQMcDSmWJwSnMVxhlTeMoEfnf.oFkohWofHCkHIodLpLmPneXvDUSB(SefBsOKwDayLMvnoebnGWCbZFJK);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
			{
				if (fPBWEKdXUTkIFbZbjDFyVHIIMQm != null)
				{
					fPBWEKdXUTkIFbZbjDFyVHIIMQm.CWncwVbJhTWISMonvIVEimpDcKXc(realTime);
				}
				if (!SefBsOKwDayLMvnoebnGWCbZFJK.yKxuRWRnWFnBURlXGqTwNNLhkrx(ViulEdmBtnERkQDvPfVeGLWdwbxr))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = vdRdcSJAmhdxgFuDQMtgOvYJsTt.T_CreateEvent())
					{
						rWewiDeItCkkJIPmulocnIePCBPh.uPCmRSALwGFxkvcCGAyDZvqtBBm(SefBsOKwDayLMvnoebnGWCbZFJK, realTime, newEventWrapper.Event);
					}
					ViulEdmBtnERkQDvPfVeGLWdwbxr.VpAIKPbOJQWFpjXrnVZoafNPJEv(SefBsOKwDayLMvnoebnGWCbZFJK);
				}
			}
		}

		private void ZdkglmuvphcjivNwSDkawQYIaNe()
		{
			while (vdRdcSJAmhdxgFuDQMtgOvYJsTt.ProcessNewEvents())
			{
				VBAJSEpHIGkcRoIrDWjrxDyzGRSE.VpAIKPbOJQWFpjXrnVZoafNPJEv(ref vdRdcSJAmhdxgFuDQMtgOvYJsTt.currentEvent);
				for (int i = 0; i < fauThtVRGnbJeqNPRDhsAoxKMINP; i++)
				{
					xMOAMIpUblwzclpASeqOvbiquVB.SetValue(i, VBAJSEpHIGkcRoIrDWjrxDyzGRSE.GjtzeSFrmMHuPyjYbDczCVRXyeJ[i], vdRdcSJAmhdxgFuDQMtgOvYJsTt.currentEvent.GetTimestamp());
				}
			}
		}

		private void IgqBTMgoLLDsubFJdJZiejmTNfb()
		{
			VBAJSEpHIGkcRoIrDWjrxDyzGRSE.rKJfCRBWFLQsKCjGykmcumzKLPwE();
			lock (zrvbWkHMkcXMNovKdrSHskCzaDOb)
			{
				SefBsOKwDayLMvnoebnGWCbZFJK.rKJfCRBWFLQsKCjGykmcumzKLPwE();
				ViulEdmBtnERkQDvPfVeGLWdwbxr.rKJfCRBWFLQsKCjGykmcumzKLPwE();
				vdRdcSJAmhdxgFuDQMtgOvYJsTt.Clear();
			}
			xMOAMIpUblwzclpASeqOvbiquVB.Clear();
		}

		public void Dispose()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(true);
			GC.SuppressFinalize(this);
		}

		~HXwClQTVyfqvGtLpLpnviaiWecIC()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(false);
		}

		protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
		{
			if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				if (P_0)
				{
					pxIDOEabnUcUluxaEwWKgTcoDWJc();
					vdRdcSJAmhdxgFuDQMtgOvYJsTt.Dispose();
				}
				if (tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread != null)
				{
					tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread.ThreadUpdateEvent -= NGvIPyOvZluZfmopLHzfBsvLuRu;
				}
				dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			}
		}

		private static float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class ycUnGIYlnwzxqvUOCLYDcpQUvKO
	{
		private PRfuElMMOSGhxJbUbIuaBSoRrQWL OsizpriAsFbUJGWAJuKcMNYmrGYk;

		private HdZZUOxIuyOhqnfxkSywkpbuTap gtJaSaDiYLqfKcofbuRAnTJeBiiq;

		private int ABoFJBZazyOmBeinyeMcJxDFRSjh;

		private int PKvbbXFqepfYdeblxvvGEpuldnPS;

		private int TfqGmYsAEbdKQHkSIBDjEjTLyLs;

		private float HJONETQxnemEasCbhGkhFqFHSdx;

		public PRfuElMMOSGhxJbUbIuaBSoRrQWL state => OsizpriAsFbUJGWAJuKcMNYmrGYk;

		public static ycUnGIYlnwzxqvUOCLYDcpQUvKO DQEQimyoSkCEIzaRbyPQwPtmYmc(ycUnGIYlnwzxqvUOCLYDcpQUvKO P_0, PRfuElMMOSGhxJbUbIuaBSoRrQWL P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new ycUnGIYlnwzxqvUOCLYDcpQUvKO(P_0, P_1);
		}

		public ycUnGIYlnwzxqvUOCLYDcpQUvKO(PRfuElMMOSGhxJbUbIuaBSoRrQWL state, int axisMin, int axisMax, int axisZero, float eventTimeout)
			: this(axisMin, axisMax, axisZero, eventTimeout)
		{
			gtJaSaDiYLqfKcofbuRAnTJeBiiq = new HdZZUOxIuyOhqnfxkSywkpbuTap(state);
			OsizpriAsFbUJGWAJuKcMNYmrGYk = new PRfuElMMOSGhxJbUbIuaBSoRrQWL();
		}

		private ycUnGIYlnwzxqvUOCLYDcpQUvKO(ycUnGIYlnwzxqvUOCLYDcpQUvKO source, PRfuElMMOSGhxJbUbIuaBSoRrQWL state)
			: this(state, source.ABoFJBZazyOmBeinyeMcJxDFRSjh, source.PKvbbXFqepfYdeblxvvGEpuldnPS, source.TfqGmYsAEbdKQHkSIBDjEjTLyLs, source.HJONETQxnemEasCbhGkhFqFHSdx)
		{
			VpAIKPbOJQWFpjXrnVZoafNPJEv(source);
		}

		private ycUnGIYlnwzxqvUOCLYDcpQUvKO(int axisMin, int axisMax, int axisZero, float axisTimeout)
		{
			ABoFJBZazyOmBeinyeMcJxDFRSjh = axisMin;
			PKvbbXFqepfYdeblxvvGEpuldnPS = axisMax;
			TfqGmYsAEbdKQHkSIBDjEjTLyLs = axisZero;
			HJONETQxnemEasCbhGkhFqFHSdx = axisTimeout;
		}

		public void CWncwVbJhTWISMonvIVEimpDcKXc(double P_0)
		{
			gtJaSaDiYLqfKcofbuRAnTJeBiiq.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
			if (!gtJaSaDiYLqfKcofbuRAnTJeBiiq.valueChanged)
			{
				if (P_0 >= gtJaSaDiYLqfKcofbuRAnTJeBiiq.lastChangedTimestamp + (double)HJONETQxnemEasCbhGkhFqFHSdx)
				{
					OsizpriAsFbUJGWAJuKcMNYmrGYk.rKJfCRBWFLQsKCjGykmcumzKLPwE();
				}
				return;
			}
			PRfuElMMOSGhxJbUbIuaBSoRrQWL changedState = gtJaSaDiYLqfKcofbuRAnTJeBiiq.changedState;
			PRfuElMMOSGhxJbUbIuaBSoRrQWL sourceState = gtJaSaDiYLqfKcofbuRAnTJeBiiq.sourceState;
			OsizpriAsFbUJGWAJuKcMNYmrGYk.X = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.X);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.Y = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.Y);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.Z = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.Z);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.RotationX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.RotationX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.RotationY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.RotationY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.RotationZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.RotationZ);
			for (int i = 0; i < OsizpriAsFbUJGWAJuKcMNYmrGYk.Sliders.Length; i++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.Sliders[i] = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.Sliders[i]);
			}
			for (int j = 0; j < OsizpriAsFbUJGWAJuKcMNYmrGYk.PointOfViewControllers.Length; j++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.PointOfViewControllers[j] = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.PointOfViewControllers[j]);
			}
			for (int k = 0; k < OsizpriAsFbUJGWAJuKcMNYmrGYk.Buttons.Length; k++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.Buttons[k] = sourceState.Buttons[k];
			}
			OsizpriAsFbUJGWAJuKcMNYmrGYk.VelocityX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.VelocityX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.VelocityY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.VelocityY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.VelocityZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.VelocityZ);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularVelocityX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularVelocityX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularVelocityY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularVelocityY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularVelocityZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularVelocityZ);
			for (int l = 0; l < OsizpriAsFbUJGWAJuKcMNYmrGYk.VelocitySliders.Length; l++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.VelocitySliders[l] = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.VelocitySliders[l]);
			}
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AccelerationX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AccelerationX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AccelerationY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AccelerationY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AccelerationZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AccelerationZ);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularAccelerationX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularAccelerationX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularAccelerationY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularAccelerationY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.AngularAccelerationZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AngularAccelerationZ);
			for (int m = 0; m < OsizpriAsFbUJGWAJuKcMNYmrGYk.AccelerationSliders.Length; m++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.AccelerationSliders[m] = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.AccelerationSliders[m]);
			}
			OsizpriAsFbUJGWAJuKcMNYmrGYk.ForceX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.ForceX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.ForceY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.ForceY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.ForceZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.ForceZ);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.TorqueX = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.TorqueX);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.TorqueY = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.TorqueY);
			OsizpriAsFbUJGWAJuKcMNYmrGYk.TorqueZ = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.TorqueZ);
			for (int n = 0; n < OsizpriAsFbUJGWAJuKcMNYmrGYk.ForceSliders.Length; n++)
			{
				OsizpriAsFbUJGWAJuKcMNYmrGYk.ForceSliders[n] = TNqmBANCZWgvtBwZLhUeSPGTYgO(changedState.ForceSliders[n]);
			}
		}

		public void VpAIKPbOJQWFpjXrnVZoafNPJEv(ycUnGIYlnwzxqvUOCLYDcpQUvKO P_0)
		{
			OsizpriAsFbUJGWAJuKcMNYmrGYk.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.OsizpriAsFbUJGWAJuKcMNYmrGYk);
			gtJaSaDiYLqfKcofbuRAnTJeBiiq.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.gtJaSaDiYLqfKcofbuRAnTJeBiiq);
			ABoFJBZazyOmBeinyeMcJxDFRSjh = P_0.ABoFJBZazyOmBeinyeMcJxDFRSjh;
			PKvbbXFqepfYdeblxvvGEpuldnPS = P_0.PKvbbXFqepfYdeblxvvGEpuldnPS;
			TfqGmYsAEbdKQHkSIBDjEjTLyLs = P_0.TfqGmYsAEbdKQHkSIBDjEjTLyLs;
			HJONETQxnemEasCbhGkhFqFHSdx = P_0.HJONETQxnemEasCbhGkhFqFHSdx;
		}

		private int TNqmBANCZWgvtBwZLhUeSPGTYgO(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, ABoFJBZazyOmBeinyeMcJxDFRSjh, PKvbbXFqepfYdeblxvvGEpuldnPS, -65535, 65535);
		}
	}

	private class HdZZUOxIuyOhqnfxkSywkpbuTap
	{
		private double mwPWZIfKPWOpdnjKXloGSBbMapi;

		private PRfuElMMOSGhxJbUbIuaBSoRrQWL VgPTgDcoJXiUQTUKacGMCOAFGjqj;

		private PRfuElMMOSGhxJbUbIuaBSoRrQWL AViOmnwcyomtThWhopWDKuKOCSR;

		private PRfuElMMOSGhxJbUbIuaBSoRrQWL WkzinxeVyTiGjoIYKoDqAvuBuoa;

		private bool vigVWLDQWiuJnhUNNRXxuvCcNpK;

		private double bBfnGTbQATBxIjzggpmoSCNumFs;

		public PRfuElMMOSGhxJbUbIuaBSoRrQWL sourceState => VgPTgDcoJXiUQTUKacGMCOAFGjqj;

		public PRfuElMMOSGhxJbUbIuaBSoRrQWL changedState => WkzinxeVyTiGjoIYKoDqAvuBuoa;

		public bool valueChanged => vigVWLDQWiuJnhUNNRXxuvCcNpK;

		public double lastChangedTimestamp => bBfnGTbQATBxIjzggpmoSCNumFs;

		public HdZZUOxIuyOhqnfxkSywkpbuTap(PRfuElMMOSGhxJbUbIuaBSoRrQWL sourceState)
		{
			VgPTgDcoJXiUQTUKacGMCOAFGjqj = sourceState;
			AViOmnwcyomtThWhopWDKuKOCSR = new PRfuElMMOSGhxJbUbIuaBSoRrQWL();
			WkzinxeVyTiGjoIYKoDqAvuBuoa = new PRfuElMMOSGhxJbUbIuaBSoRrQWL();
		}

		public void CWncwVbJhTWISMonvIVEimpDcKXc(double P_0)
		{
			mwPWZIfKPWOpdnjKXloGSBbMapi = P_0;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.X = VgPTgDcoJXiUQTUKacGMCOAFGjqj.X - AViOmnwcyomtThWhopWDKuKOCSR.X;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.Y = VgPTgDcoJXiUQTUKacGMCOAFGjqj.Y - AViOmnwcyomtThWhopWDKuKOCSR.Y;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.Z = VgPTgDcoJXiUQTUKacGMCOAFGjqj.Z - AViOmnwcyomtThWhopWDKuKOCSR.Z;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.RotationX - AViOmnwcyomtThWhopWDKuKOCSR.RotationX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.RotationY - AViOmnwcyomtThWhopWDKuKOCSR.RotationY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.RotationZ - AViOmnwcyomtThWhopWDKuKOCSR.RotationZ;
			for (int i = 0; i < VgPTgDcoJXiUQTUKacGMCOAFGjqj.Sliders.Length; i++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.Sliders[i] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.Sliders[i] - AViOmnwcyomtThWhopWDKuKOCSR.Sliders[i];
			}
			for (int j = 0; j < VgPTgDcoJXiUQTUKacGMCOAFGjqj.PointOfViewControllers.Length; j++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.PointOfViewControllers[j] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.PointOfViewControllers[j] - AViOmnwcyomtThWhopWDKuKOCSR.PointOfViewControllers[j];
			}
			for (int k = 0; k < VgPTgDcoJXiUQTUKacGMCOAFGjqj.Buttons.Length; k++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.Buttons[k] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.Buttons[k] != AViOmnwcyomtThWhopWDKuKOCSR.Buttons[k];
			}
			WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocityX - AViOmnwcyomtThWhopWDKuKOCSR.VelocityX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocityY - AViOmnwcyomtThWhopWDKuKOCSR.VelocityY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocityZ - AViOmnwcyomtThWhopWDKuKOCSR.VelocityZ;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularVelocityX - AViOmnwcyomtThWhopWDKuKOCSR.AngularVelocityX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularVelocityY - AViOmnwcyomtThWhopWDKuKOCSR.AngularVelocityY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularVelocityZ - AViOmnwcyomtThWhopWDKuKOCSR.AngularVelocityZ;
			for (int l = 0; l < VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocitySliders.Length; l++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocitySliders[l] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocitySliders[l] - AViOmnwcyomtThWhopWDKuKOCSR.VelocitySliders[l];
			}
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationX - AViOmnwcyomtThWhopWDKuKOCSR.AccelerationX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationY - AViOmnwcyomtThWhopWDKuKOCSR.AccelerationY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationZ - AViOmnwcyomtThWhopWDKuKOCSR.AccelerationZ;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularAccelerationX - AViOmnwcyomtThWhopWDKuKOCSR.AngularAccelerationX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularAccelerationY - AViOmnwcyomtThWhopWDKuKOCSR.AngularAccelerationY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AngularAccelerationZ - AViOmnwcyomtThWhopWDKuKOCSR.AngularAccelerationZ;
			for (int m = 0; m < VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationSliders.Length; m++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationSliders[m] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationSliders[m] - AViOmnwcyomtThWhopWDKuKOCSR.AccelerationSliders[m];
			}
			WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceX - AViOmnwcyomtThWhopWDKuKOCSR.ForceX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceY - AViOmnwcyomtThWhopWDKuKOCSR.ForceY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceZ - AViOmnwcyomtThWhopWDKuKOCSR.ForceZ;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueX = VgPTgDcoJXiUQTUKacGMCOAFGjqj.TorqueX - AViOmnwcyomtThWhopWDKuKOCSR.TorqueX;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueY = VgPTgDcoJXiUQTUKacGMCOAFGjqj.TorqueY - AViOmnwcyomtThWhopWDKuKOCSR.TorqueY;
			WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueZ = VgPTgDcoJXiUQTUKacGMCOAFGjqj.TorqueZ - AViOmnwcyomtThWhopWDKuKOCSR.TorqueZ;
			for (int n = 0; n < VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceSliders.Length; n++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceSliders[n] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceSliders[n] - AViOmnwcyomtThWhopWDKuKOCSR.ForceSliders[n];
			}
			vigVWLDQWiuJnhUNNRXxuvCcNpK = BwYeQCItxGxHFWKECdQcZjNsbuS();
			if (vigVWLDQWiuJnhUNNRXxuvCcNpK)
			{
				bBfnGTbQATBxIjzggpmoSCNumFs = P_0;
				AViOmnwcyomtThWhopWDKuKOCSR.VpAIKPbOJQWFpjXrnVZoafNPJEv(VgPTgDcoJXiUQTUKacGMCOAFGjqj);
			}
		}

		public void VpAIKPbOJQWFpjXrnVZoafNPJEv(HdZZUOxIuyOhqnfxkSywkpbuTap P_0)
		{
			mwPWZIfKPWOpdnjKXloGSBbMapi = P_0.mwPWZIfKPWOpdnjKXloGSBbMapi;
			AViOmnwcyomtThWhopWDKuKOCSR.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.AViOmnwcyomtThWhopWDKuKOCSR);
			WkzinxeVyTiGjoIYKoDqAvuBuoa.VpAIKPbOJQWFpjXrnVZoafNPJEv(P_0.WkzinxeVyTiGjoIYKoDqAvuBuoa);
		}

		private bool BwYeQCItxGxHFWKECdQcZjNsbuS()
		{
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.Y != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.Z != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.RotationZ != 0)
			{
				return true;
			}
			for (int i = 0; i < VgPTgDcoJXiUQTUKacGMCOAFGjqj.Sliders.Length; i++)
			{
				if (WkzinxeVyTiGjoIYKoDqAvuBuoa.Sliders[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < VgPTgDcoJXiUQTUKacGMCOAFGjqj.PointOfViewControllers.Length; j++)
			{
				if (WkzinxeVyTiGjoIYKoDqAvuBuoa.PointOfViewControllers[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < VgPTgDcoJXiUQTUKacGMCOAFGjqj.Buttons.Length; k++)
			{
				if (WkzinxeVyTiGjoIYKoDqAvuBuoa.Buttons[k])
				{
					return true;
				}
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocityZ != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularVelocityZ != 0)
			{
				return true;
			}
			for (int l = 0; l < VgPTgDcoJXiUQTUKacGMCOAFGjqj.VelocitySliders.Length; l++)
			{
				if (WkzinxeVyTiGjoIYKoDqAvuBuoa.VelocitySliders[l] != 0)
				{
					return true;
				}
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationZ != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.AngularAccelerationZ != 0)
			{
				return true;
			}
			for (int m = 0; m < VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationSliders.Length; m++)
			{
				WkzinxeVyTiGjoIYKoDqAvuBuoa.AccelerationSliders[m] = VgPTgDcoJXiUQTUKacGMCOAFGjqj.AccelerationSliders[m] - AViOmnwcyomtThWhopWDKuKOCSR.AccelerationSliders[m];
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceZ != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueX != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueY != 0)
			{
				return true;
			}
			if (WkzinxeVyTiGjoIYKoDqAvuBuoa.TorqueZ != 0)
			{
				return true;
			}
			for (int n = 0; n < VgPTgDcoJXiUQTUKacGMCOAFGjqj.ForceSliders.Length; n++)
			{
				if (WkzinxeVyTiGjoIYKoDqAvuBuoa.ForceSliders[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class ZAVoVVxYwqpvvZMZjjXNFpuIkPz
	{
		public enum sHchDYgcApQTDepBtPahxbQcocQ
		{
			jCoiBlfabpaxiBivYEooCEijjotH = 0,
			LGsVvWMqVpKpHXTLCoBgxjvzdgdF = 1
		}

		public class EWfdGMzAeRtNdwPsyaGujllDSCsI
		{
			public int IarEMbMqzCAYwlSQGSgLyHgrWQw;

			public Guid KTBFXHUSsvUaTwiOmbyvhbRGtyWr;

			public Guid YTUiBjSgszCjFKdQcXGXQLdjmPC;

			public int StNvaEdPkeHdOVPfOWiyBYqIBZC;

			public int tsubhXPAkivKUjJndgFvgCYtCih;

			public int uELhfbdZYGHumCLLdtArLMIvIGxA;

			public int ZjLWaiKAEkbMVYsMXPeYLhgiSLG;

			public bool KyAfiLYcJFhJNpOgrDEhxwnhNoD(xttSOAxySzBEQLtvGhlaStamuIY P_0, sHchDYgcApQTDepBtPahxbQcocQ P_1)
			{
				if (P_0.rewiredId == IarEMbMqzCAYwlSQGSgLyHgrWQw)
				{
					return true;
				}
				if (tsubhXPAkivKUjJndgFvgCYtCih != P_0.tsubhXPAkivKUjJndgFvgCYtCih)
				{
					return false;
				}
				if (uELhfbdZYGHumCLLdtArLMIvIGxA != P_0.uELhfbdZYGHumCLLdtArLMIvIGxA)
				{
					return false;
				}
				if (ZjLWaiKAEkbMVYsMXPeYLhgiSLG != P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG)
				{
					return false;
				}
				return P_1 switch
				{
					sHchDYgcApQTDepBtPahxbQcocQ.jCoiBlfabpaxiBivYEooCEijjotH => KTBFXHUSsvUaTwiOmbyvhbRGtyWr == P_0.instanceGuid, 
					sHchDYgcApQTDepBtPahxbQcocQ.LGsVvWMqVpKpHXTLCoBgxjvzdgdF => YTUiBjSgszCjFKdQcXGXQLdjmPC == P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC, 
					_ => throw new NotImplementedException(), 
				};
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				text = string.Concat(obj, "rewiredId = ", IarEMbMqzCAYwlSQGSgLyHgrWQw, "\n");
				object obj2 = text;
				text = string.Concat(obj2, "instanceGuid = ", KTBFXHUSsvUaTwiOmbyvhbRGtyWr, "\n");
				object obj3 = text;
				text = string.Concat(obj3, "typeIdentifierGuid = ", YTUiBjSgszCjFKdQcXGXQLdjmPC, "\n");
				object obj4 = text;
				text = string.Concat(obj4, "lastInputManagerId = ", StNvaEdPkeHdOVPfOWiyBYqIBZC, "\n");
				object obj5 = text;
				text = string.Concat(obj5, "hardwareAxisCount = ", tsubhXPAkivKUjJndgFvgCYtCih, "\n");
				object obj6 = text;
				text = string.Concat(obj6, "hardwareButtonCount = ", uELhfbdZYGHumCLLdtArLMIvIGxA, "\n");
				object obj7 = text;
				return string.Concat(obj7, "hardwareHatCount = ", ZjLWaiKAEkbMVYsMXPeYLhgiSLG, "\n");
			}
		}

		private sealed class dRZDawjhqOgUvgMPAiRGhJdmHiEC : IEnumerable<EWfdGMzAeRtNdwPsyaGujllDSCsI>, IEnumerator<EWfdGMzAeRtNdwPsyaGujllDSCsI>, IDisposable, IEnumerable, IEnumerator
		{
			private EWfdGMzAeRtNdwPsyaGujllDSCsI eGPKTGyzgMFAWcHLLlCxsVDFMVF;

			private int waNxGruVnkDJsvXTmfsQkrGamZW;

			private int BBQWedXXzEABJslsFGqlwQvMEop;

			public ZAVoVVxYwqpvvZMZjjXNFpuIkPz atnkeqgXxTBLxuTqVeTupqRLlmp;

			public xttSOAxySzBEQLtvGhlaStamuIY CefbijIwCmLkPuepfMadBXgHqcyK;

			public xttSOAxySzBEQLtvGhlaStamuIY iFluTsQcIlgKEhcOMkSFgVVbRpfl;

			public sHchDYgcApQTDepBtPahxbQcocQ lUgIDcEJoqQxAXsgxguWfbjkfCij;

			public sHchDYgcApQTDepBtPahxbQcocQ TPzaVyiSPZBiaBIeziXdlbKGjEo;

			public int gKQanMdQICYBnZXVpxkKjpKyYjV;

			public int PeasbSZQhmJqZwtcRmpeSzpukMZ;

			EWfdGMzAeRtNdwPsyaGujllDSCsI IEnumerator<EWfdGMzAeRtNdwPsyaGujllDSCsI>.Current
			{
				[DebuggerHidden]
				get
				{
					return eGPKTGyzgMFAWcHLLlCxsVDFMVF;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eGPKTGyzgMFAWcHLLlCxsVDFMVF;
				}
			}

			[DebuggerHidden]
			IEnumerator<EWfdGMzAeRtNdwPsyaGujllDSCsI> IEnumerable<EWfdGMzAeRtNdwPsyaGujllDSCsI>.GetEnumerator()
			{
				dRZDawjhqOgUvgMPAiRGhJdmHiEC dRZDawjhqOgUvgMPAiRGhJdmHiEC2;
				if (Thread.CurrentThread.ManagedThreadId == BBQWedXXzEABJslsFGqlwQvMEop && waNxGruVnkDJsvXTmfsQkrGamZW == -2)
				{
					waNxGruVnkDJsvXTmfsQkrGamZW = 0;
					dRZDawjhqOgUvgMPAiRGhJdmHiEC2 = this;
				}
				else
				{
					dRZDawjhqOgUvgMPAiRGhJdmHiEC2 = new dRZDawjhqOgUvgMPAiRGhJdmHiEC(0);
					dRZDawjhqOgUvgMPAiRGhJdmHiEC2.atnkeqgXxTBLxuTqVeTupqRLlmp = atnkeqgXxTBLxuTqVeTupqRLlmp;
				}
				dRZDawjhqOgUvgMPAiRGhJdmHiEC2.CefbijIwCmLkPuepfMadBXgHqcyK = iFluTsQcIlgKEhcOMkSFgVVbRpfl;
				dRZDawjhqOgUvgMPAiRGhJdmHiEC2.lUgIDcEJoqQxAXsgxguWfbjkfCij = TPzaVyiSPZBiaBIeziXdlbKGjEo;
				return dRZDawjhqOgUvgMPAiRGhJdmHiEC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<EWfdGMzAeRtNdwPsyaGujllDSCsI>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (waNxGruVnkDJsvXTmfsQkrGamZW)
				{
				case 0:
					waNxGruVnkDJsvXTmfsQkrGamZW = -1;
					gKQanMdQICYBnZXVpxkKjpKyYjV = atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
					PeasbSZQhmJqZwtcRmpeSzpukMZ = 0;
					goto IL_00a3;
				case 1:
					{
						waNxGruVnkDJsvXTmfsQkrGamZW = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (PeasbSZQhmJqZwtcRmpeSzpukMZ >= gKQanMdQICYBnZXVpxkKjpKyYjV)
					{
						break;
					}
					if (atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi[PeasbSZQhmJqZwtcRmpeSzpukMZ].KyAfiLYcJFhJNpOgrDEhxwnhNoD(CefbijIwCmLkPuepfMadBXgHqcyK, lUgIDcEJoqQxAXsgxguWfbjkfCij))
					{
						eGPKTGyzgMFAWcHLLlCxsVDFMVF = atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi[PeasbSZQhmJqZwtcRmpeSzpukMZ];
						waNxGruVnkDJsvXTmfsQkrGamZW = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					PeasbSZQhmJqZwtcRmpeSzpukMZ++;
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
			public dRZDawjhqOgUvgMPAiRGhJdmHiEC(int _003C_003E1__state)
			{
				waNxGruVnkDJsvXTmfsQkrGamZW = _003C_003E1__state;
				BBQWedXXzEABJslsFGqlwQvMEop = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<EWfdGMzAeRtNdwPsyaGujllDSCsI> rHeRGdaxkUgtZdjiIBVhiIXdbi;

		public ZAVoVVxYwqpvvZMZjjXNFpuIkPz()
		{
			rHeRGdaxkUgtZdjiIBVhiIXdbi = new List<EWfdGMzAeRtNdwPsyaGujllDSCsI>();
		}

		public void xgVDvWMPwGSwXsgsVGmvrCGbsMR(xttSOAxySzBEQLtvGhlaStamuIY P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
			for (int i = 0; i < count; i++)
			{
				if (rHeRGdaxkUgtZdjiIBVhiIXdbi[i].KyAfiLYcJFhJNpOgrDEhxwnhNoD(P_0, sHchDYgcApQTDepBtPahxbQcocQ.jCoiBlfabpaxiBivYEooCEijjotH))
				{
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].IarEMbMqzCAYwlSQGSgLyHgrWQw = P_0.rewiredId;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].KTBFXHUSsvUaTwiOmbyvhbRGtyWr = P_0.instanceGuid;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].YTUiBjSgszCjFKdQcXGXQLdjmPC = P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].StNvaEdPkeHdOVPfOWiyBYqIBZC = P_0.inputManagerId;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].tsubhXPAkivKUjJndgFvgCYtCih = P_0.tsubhXPAkivKUjJndgFvgCYtCih;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].uELhfbdZYGHumCLLdtArLMIvIGxA = P_0.uELhfbdZYGHumCLLdtArLMIvIGxA;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].ZjLWaiKAEkbMVYsMXPeYLhgiSLG = P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG;
					FJLMwloVnlBXUksRQWoCzvEJpgt(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			rHeRGdaxkUgtZdjiIBVhiIXdbi.Add(new EWfdGMzAeRtNdwPsyaGujllDSCsI
			{
				IarEMbMqzCAYwlSQGSgLyHgrWQw = P_0.rewiredId,
				KTBFXHUSsvUaTwiOmbyvhbRGtyWr = P_0.instanceGuid,
				YTUiBjSgszCjFKdQcXGXQLdjmPC = P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC,
				StNvaEdPkeHdOVPfOWiyBYqIBZC = P_0.inputManagerId,
				tsubhXPAkivKUjJndgFvgCYtCih = P_0.tsubhXPAkivKUjJndgFvgCYtCih,
				uELhfbdZYGHumCLLdtArLMIvIGxA = P_0.uELhfbdZYGHumCLLdtArLMIvIGxA,
				ZjLWaiKAEkbMVYsMXPeYLhgiSLG = P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG
			});
			FJLMwloVnlBXUksRQWoCzvEJpgt(P_0.rewiredId, P_0.instanceGuid, rHeRGdaxkUgtZdjiIBVhiIXdbi.Count - 1);
		}

		public bool WDMRBLdLaAepmasexhLgbGtHkMQT(xttSOAxySzBEQLtvGhlaStamuIY P_0, sHchDYgcApQTDepBtPahxbQcocQ P_1)
		{
			int count = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
			for (int i = 0; i < count; i++)
			{
				if (rHeRGdaxkUgtZdjiIBVhiIXdbi[i].KyAfiLYcJFhJNpOgrDEhxwnhNoD(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<EWfdGMzAeRtNdwPsyaGujllDSCsI> crTEwBjpShikeXLaYUTdOaoyQQJ(xttSOAxySzBEQLtvGhlaStamuIY P_0, sHchDYgcApQTDepBtPahxbQcocQ P_1)
		{
			dRZDawjhqOgUvgMPAiRGhJdmHiEC dRZDawjhqOgUvgMPAiRGhJdmHiEC2 = new dRZDawjhqOgUvgMPAiRGhJdmHiEC(-2);
			dRZDawjhqOgUvgMPAiRGhJdmHiEC2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
			dRZDawjhqOgUvgMPAiRGhJdmHiEC2.iFluTsQcIlgKEhcOMkSFgVVbRpfl = P_0;
			dRZDawjhqOgUvgMPAiRGhJdmHiEC2.TPzaVyiSPZBiaBIeziXdlbKGjEo = P_1;
			return dRZDawjhqOgUvgMPAiRGhJdmHiEC2;
		}

		private void FJLMwloVnlBXUksRQWoCzvEJpgt(int P_0, Guid P_1, int P_2)
		{
			for (int num = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (rHeRGdaxkUgtZdjiIBVhiIXdbi[num].IarEMbMqzCAYwlSQGSgLyHgrWQw == P_0 || rHeRGdaxkUgtZdjiIBVhiIXdbi[num].KTBFXHUSsvUaTwiOmbyvhbRGtyWr == P_1))
				{
					rHeRGdaxkUgtZdjiIBVhiIXdbi.RemoveAt(num);
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			object obj = text;
			text = string.Concat(obj, "Joystick records: ", rHeRGdaxkUgtZdjiIBVhiIXdbi.Count, "\n");
			for (int i = 0; i < rHeRGdaxkUgtZdjiIBVhiIXdbi.Count; i++)
			{
				object obj2 = text;
				text = string.Concat(obj2, "Record ", i, ":\n");
				text = text + rHeRGdaxkUgtZdjiIBVhiIXdbi[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class wKZwaBmLlpGrsbkHVuUVwhDFwgn
	{
		public xttSOAxySzBEQLtvGhlaStamuIY PFnOTHqJnYDWzxCOYtTyZdOVMyq;

		public rwUDYNAmSWwCoTDiwmZsStufkqWe wviegHeumjDVgSdipDjNQtyBLDB;

		public bool IsValid
		{
			get
			{
				if (PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
				{
					return wviegHeumjDVgSdipDjNQtyBLDB != null;
				}
				return false;
			}
		}

		public wKZwaBmLlpGrsbkHVuUVwhDFwgn(xttSOAxySzBEQLtvGhlaStamuIY joystick, rwUDYNAmSWwCoTDiwmZsStufkqWe deviceInstance)
		{
			PFnOTHqJnYDWzxCOYtTyZdOVMyq = joystick;
			wviegHeumjDVgSdipDjNQtyBLDB = deviceInstance;
		}

		public static List<rwUDYNAmSWwCoTDiwmZsStufkqWe> YeGaQhqvXLymnvCOkDrUEjjQAcA(List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> P_0)
		{
			if (P_0 == null)
			{
				return new List<rwUDYNAmSWwCoTDiwmZsStufkqWe>();
			}
			List<rwUDYNAmSWwCoTDiwmZsStufkqWe> list = new List<rwUDYNAmSWwCoTDiwmZsStufkqWe>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IsValid)
				{
					list.Add(P_0[i].wviegHeumjDVgSdipDjNQtyBLDB);
				}
			}
			return list;
		}
	}

	private class ZdoGgWCCzIKgJhiHgQBEDOiesWFj
	{
		public rfGUKNICXjMvSKkObEqIFzzuSJa wIwWzVGhibrYBYZpPSPLzNLHwEj;

		public ZdoGgWCCzIKgJhiHgQBEDOiesWFj(rfGUKNICXjMvSKkObEqIFzzuSJa sdxJoystick)
		{
			wIwWzVGhibrYBYZpPSPLzNLHwEj = sdxJoystick;
		}
	}

	private class EfnDmWtRebDTsjDfEQjIfVsEcaSy
	{
		private SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf avyiYgbKhkbGBEGmPIImZcEVFFY;

		private SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC amZAtMuySNJJhHkIxVbltHTGYEJ;

		private NativeBuffer AOMFuqreSEJDHNgdnCJwSyyjEWA;

		private int VhHxSKauwnQPgGlObCKwMEntIGn;

		public EfnDmWtRebDTsjDfEQjIfVsEcaSy()
		{
			avyiYgbKhkbGBEGmPIImZcEVFFY = new SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf
			{
				CyZqStgDIPaCFFuUFvMLYbSUmTA = (uint)Marshal.SizeOf(typeof(SmtbXLEQrGnIZlmUjbTNRZuCpJS.yDVmQStWdMIYWOVYCVgGchdnCXf)),
				ILBZqpUBdcwOCWrFqDMUfThBePpI = true,
				FwYcvZAFJCllLyaumofpiiVeOwR = true,
				dGSKygCEVJYNCGctpQYPlEDdwCh = false,
				YQQsOvGGdkTiyUZyJVlMfGBKJLv = true,
				ezyFEbZEpGjDhDxJvZhaDKYhntGf = IntPtr.Zero
			};
			amZAtMuySNJJhHkIxVbltHTGYEJ = SmtbXLEQrGnIZlmUjbTNRZuCpJS.drSDytqeZpNRDgsxRnHgDVNKoGC.KbsenlehkfKhrEUvGoQEltREagOX();
			AOMFuqreSEJDHNgdnCJwSyyjEWA = new NativeBuffer((int)amZAtMuySNJJhHkIxVbltHTGYEJ.CyZqStgDIPaCFFuUFvMLYbSUmTA);
			AOMFuqreSEJDHNgdnCJwSyyjEWA.Write(amZAtMuySNJJhHkIxVbltHTGYEJ.CyZqStgDIPaCFFuUFvMLYbSUmTA, 0);
		}

		public bool MGgleQdlFqqjvEMGIOFgkiqHvvR()
		{
			int num = MbygVUWNZSfDtSutQmNkXFrCJem();
			if (num == VhHxSKauwnQPgGlObCKwMEntIGn)
			{
				return false;
			}
			VhHxSKauwnQPgGlObCKwMEntIGn = num;
			return true;
		}

		public void mYkglasoFxjhfAsEFwsSprCvoLe(int P_0)
		{
			VhHxSKauwnQPgGlObCKwMEntIGn = P_0;
		}

		private int MbygVUWNZSfDtSutQmNkXFrCJem()
		{
			try
			{
				return uNUGDLxbzFWxnCXPxXiZAvRTReD.FyyHFsnMdNTwjVEDmbXDLritDjL(ref avyiYgbKhkbGBEGmPIImZcEVFFY, AOMFuqreSEJDHNgdnCJwSyyjEWA);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum xqYBxITugRxezsSPWmytYtNDnmT
	{
		LjvfuhORJgLCiwGYyiHqyWuCfjx = 17,
		QWzvIXfHqDcsOQVtNnKAnsyXzLg = 18,
		bheAcljDHpoAOeHYhiVCoSJIEJwV = 19,
		wopKQFfSLcafzbyCVCGaJLucPYz = 20,
		vFmwJbshzNEkREUTCqstpmqTaAKd = 21,
		nOpxFTcuYUeuvxBpcnMYjZuiPtr = 22,
		ZPeapYOijseJEWhKaykVFYevbmZ = 23,
		xSxhbOIcBTXjDmLxwLLxJtCSuBc = 24,
		OzLgakmqWmOjIAzHyavLmMGxarL = 25,
		guOfEArKOYlNPOWrrBDnWBgonjK = 26,
		ROIIuzoLObeISusxzGsSIMQhLrk = 27,
		oIQDUXNwXckcfwFGJBDAdShfcZPm = 28
	}

	private const HiBJWeyeWfhElzlDChLUgQROjnAq zAkGTuZFKMGFhANpLpEScedJIDoo = HiBJWeyeWfhElzlDChLUgQROjnAq.UOIGbizuvcghCQGjQAUpIizRcQjG;

	private const zTnRQWEjlkWYSgeKMuNijZncOjb efcKXIngdGgXsXmSnrfARNSifrW = zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt;

	private IntPtr idBhrIasrPEVndsAwTtUPkQwgLkE;

	private qlIBtAfuFtdSnDfdAlXLqIlaFZjt hmoIGvwuxwJiZhNwPsZPjZFhpVy;

	private List<xttSOAxySzBEQLtvGhlaStamuIY> WEuHIpAYAmfrlFuzqsSpOYLelMz;

	private int tElQBcMFfTokTSGpOCgJUghpIgcJ;

	private ZAVoVVxYwqpvvZMZjjXNFpuIkPz RafIJEjRPcZZJNODanhvgJXwSAct;

	private bool XazDXdLmqFaahtQowFABimVmkYzw;

	private bool wYPAnAmOAglaNAsIippUdzhQMob;

	private UpdateLoopSetting ZDLIoJiSlykgJcBIgNQgaErGetg;

	private Action<int, ControllerDataUpdater> WmFnGJiLKLAaRkIIWsgqhlsBheL;

	private PlatformInputManager ObhiZaVIPxECrBbksWjAaFTwhIWj;

	private TimerRealTime RDcQyMEdXmKzMILKWClGmenXmfM;

	private global::TUExllOFrNiCflNptTwhTfgfIzgh<bool> FpqIPSroXiuEZNqFOOfQuzbmgmB;

	private EfnDmWtRebDTsjDfEQjIfVsEcaSy iGNfyZdwBdEpReXssxGSouhIwUHh;

	private int GdqURqacBvESNwJUhGOhXhTvTAg;

	private int IQZGZAXyrnBrVkzRDzLmBiwupat;

	private global::TUExllOFrNiCflNptTwhTfgfIzgh<List<wKZwaBmLlpGrsbkHVuUVwhDFwgn>> qrWkihqzKfQCChINMfqVmAeIlfB;

	private readonly object WfTbITFnDgahnloEWtIracmCfqy = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

	private Func<int> soqxPQhwIsLUZvHgdWElDYIwuLk;

	public bool useXInput
	{
		set
		{
			wYPAnAmOAglaNAsIippUdzhQMob = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => tElQBcMFfTokTSGpOCgJUghpIgcJ;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ObhiZaVIPxECrBbksWjAaFTwhIWj;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => new InputSourceWrapper<qlIBtAfuFtdSnDfdAlXLqIlaFZjt>(hmoIGvwuxwJiZhNwPsZPjZFhpVy);

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.DirectInput;

	public dnJJlCvkyWsJFkQFpOPAltwceYg(UpdateLoopSetting updateLoopSetting, bool useXInput, IntPtr windowHandle, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		try
		{
			ZDLIoJiSlykgJcBIgNQgaErGetg = updateLoopSetting;
			wYPAnAmOAglaNAsIippUdzhQMob = useXInput;
			idBhrIasrPEVndsAwTtUPkQwgLkE = windowHandle;
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			soqxPQhwIsLUZvHgdWElDYIwuLk = getNewJoystickId;
			ObhiZaVIPxECrBbksWjAaFTwhIWj = this;
			hmoIGvwuxwJiZhNwPsZPjZFhpVy = new qlIBtAfuFtdSnDfdAlXLqIlaFZjt();
			WmFnGJiLKLAaRkIIWsgqhlsBheL = UpdateControllerData;
			iGNfyZdwBdEpReXssxGSouhIwUHh = new EfnDmWtRebDTsjDfEQjIfVsEcaSy();
			FpqIPSroXiuEZNqFOOfQuzbmgmB = new global::TUExllOFrNiCflNptTwhTfgfIzgh<bool>(useSharedThread: true, VMtEQWtzyAGQAnUhFnHPzvdEAKR);
			qrWkihqzKfQCChINMfqVmAeIlfB = new global::TUExllOFrNiCflNptTwhTfgfIzgh<List<wKZwaBmLlpGrsbkHVuUVwhDFwgn>>(useSharedThread: true, () => cljxYMgNyNeWVLyzxOlIhJllJvJ());
			jmfaYfbczmJdEIuNcsOSvgdvRIZW();
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
		RafIJEjRPcZZJNODanhvgJXwSAct = new ZAVoVVxYwqpvvZMZjjXNFpuIkPz();
		RDcQyMEdXmKzMILKWClGmenXmfM = new TimerRealTime(1.0);
		RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		wfMgYxfdtVoNyAhVKIiCeAapixnP();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		CIQmbedndYaSXuZDlHeLgVuLtzC();
		vGxdBlKXJhEtHKJthcyFDIPFLKZi();
		vKWUwPqagUZSjOHDZUpalOcMgaf();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (qrWkihqzKfQCChINMfqVmAeIlfB != null)
		{
			qrWkihqzKfQCChINMfqVmAeIlfB.LLOFbzNISIbRkZTwkaVnsPpYig();
		}
		if (FpqIPSroXiuEZNqFOOfQuzbmgmB != null)
		{
			FpqIPSroXiuEZNqFOOfQuzbmgmB.LLOFbzNISIbRkZTwkaVnsPpYig();
		}
		if (WEuHIpAYAmfrlFuzqsSpOYLelMz == null)
		{
			return;
		}
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			for (int i = 0; i < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; i++)
			{
				if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null)
				{
					WEuHIpAYAmfrlFuzqsSpOYLelMz[i].JkxbMOPQiVSbeNRGETMYZahHimc();
					WEuHIpAYAmfrlFuzqsSpOYLelMz[i].LLOFbzNISIbRkZTwkaVnsPpYig();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return WmFnGJiLKLAaRkIIWsgqhlsBheL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			for (int i = 0; i < tElQBcMFfTokTSGpOCgJUghpIgcJ; i++)
			{
				if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i].inputManagerId == inputManagerId)
				{
					WEuHIpAYAmfrlFuzqsSpOYLelMz[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		XazDXdLmqFaahtQowFABimVmkYzw = true;
		RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		XazDXdLmqFaahtQowFABimVmkYzw = true;
		RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private void CIQmbedndYaSXuZDlHeLgVuLtzC()
	{
		if (FpqIPSroXiuEZNqFOOfQuzbmgmB.isRunning)
		{
			if (FpqIPSroXiuEZNqFOOfQuzbmgmB.lVgWjrQkCsFlsaFVzSjplyEWLEJg() && !RDcQyMEdXmKzMILKWClGmenXmfM.running && !qrWkihqzKfQCChINMfqVmAeIlfB.isRunning)
			{
				if (FpqIPSroXiuEZNqFOOfQuzbmgmB.result)
				{
					XazDXdLmqFaahtQowFABimVmkYzw = true;
				}
				RDcQyMEdXmKzMILKWClGmenXmfM.Start();
			}
		}
		else if (!RDcQyMEdXmKzMILKWClGmenXmfM.running)
		{
			RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		}
		else if (RDcQyMEdXmKzMILKWClGmenXmfM.Update())
		{
			FpqIPSroXiuEZNqFOOfQuzbmgmB.UyHkmeYMKxbRaLGZZmHNfcnwklW();
		}
	}

	private List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> cljxYMgNyNeWVLyzxOlIhJllJvJ()
	{
		List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> list = new List<wKZwaBmLlpGrsbkHVuUVwhDFwgn>();
		IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> list2 = jyGzJGOiqoBunAXGJoMxRtONAtsl();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				rwUDYNAmSWwCoTDiwmZsStufkqWe rwUDYNAmSWwCoTDiwmZsStufkqWe2 = list2[i];
				Guid wXKmhfCcjUksYEsLiiQybuQLGQI = rwUDYNAmSWwCoTDiwmZsStufkqWe2.wXKmhfCcjUksYEsLiiQybuQLGQI;
				rfGUKNICXjMvSKkObEqIFzzuSJa rfGUKNICXjMvSKkObEqIFzzuSJa2 = new rfGUKNICXjMvSKkObEqIFzzuSJa(hmoIGvwuxwJiZhNwPsZPjZFhpVy, wXKmhfCcjUksYEsLiiQybuQLGQI);
				UahaQRTbdPaFHdrOtyfKJWgzghXZ properties = rfGUKNICXjMvSKkObEqIFzzuSJa2.Properties;
				bool flag = false;
				if (!wYPAnAmOAglaNAsIippUdzhQMob)
				{
					goto IL_008b;
				}
				flag = mFhbDHUVMhTRsTSifoqtETGQFLi.TmdtXLMLtxmfoirfUPEqxZwbkhn(properties.InterfacePath, StringTools.SanitizeDeviceString(rwUDYNAmSWwCoTDiwmZsStufkqWe2.MqxtgbOxQtaHwdixZLQxCzOqPIb), string.Empty, rwUDYNAmSWwCoTDiwmZsStufkqWe2.jogDTTzPLkSRUmADdmtAWGdKeHhB);
				if (!flag)
				{
					goto IL_008b;
				}
				goto end_IL_0027;
				IL_008b:
				Guid guid = ((!string.IsNullOrEmpty(properties.InterfacePath)) ? MiscTools.CreateGuidHashSHA256(properties.InterfacePath) : rwUDYNAmSWwCoTDiwmZsStufkqWe2.wXKmhfCcjUksYEsLiiQybuQLGQI);
				bool flag2 = false;
				lock (WfTbITFnDgahnloEWtIracmCfqy)
				{
					if (WEuHIpAYAmfrlFuzqsSpOYLelMz != null)
					{
						for (int j = 0; j < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; j++)
						{
							if (WEuHIpAYAmfrlFuzqsSpOYLelMz[j] != null && WEuHIpAYAmfrlFuzqsSpOYLelMz[j].ypBhwPylZXgbWvdXwgdHvTJZNDf == guid)
							{
								rfGUKNICXjMvSKkObEqIFzzuSJa2 = WEuHIpAYAmfrlFuzqsSpOYLelMz[j].igbQmSqThzEBDsBKZScaimlglKi.ARbQMcDSmWJwSnMVxhlTeMoEfnf;
								flag2 = true;
								break;
							}
						}
					}
				}
				xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = new xttSOAxySzBEQLtvGhlaStamuIY(new HXwClQTVyfqvGtLpLpnviaiWecIC(rfGUKNICXjMvSKkObEqIFzzuSJa2, ZDLIoJiSlykgJcBIgNQgaErGetg), bKHIVnLAXWYbMiOIyqMJrMzriBW);
				xttSOAxySzBEQLtvGhlaStamuIY2.wviegHeumjDVgSdipDjNQtyBLDB = rwUDYNAmSWwCoTDiwmZsStufkqWe2;
				xttSOAxySzBEQLtvGhlaStamuIY2.kxKCChAepXZZMUCPgfBLnfqoDYsI = rwUDYNAmSWwCoTDiwmZsStufkqWe2.WbaMzmZsvilMwfkoMtIUOLzNtVn;
				xttSOAxySzBEQLtvGhlaStamuIY2.ypBhwPylZXgbWvdXwgdHvTJZNDf = guid;
				xttSOAxySzBEQLtvGhlaStamuIY2.IBLmgPovQLSZcNmAXhMIAhsmJVX = StringTools.SanitizeDeviceString(rwUDYNAmSWwCoTDiwmZsStufkqWe2.MqxtgbOxQtaHwdixZLQxCzOqPIb);
				xttSOAxySzBEQLtvGhlaStamuIY2.giPzSxcdmJFlxkpGRptEQPgrFzn = rwUDYNAmSWwCoTDiwmZsStufkqWe2.jogDTTzPLkSRUmADdmtAWGdKeHhB;
				xttSOAxySzBEQLtvGhlaStamuIY2.wlGyzJWWOKDXLrNCpUopceovTWD = (xqYBxITugRxezsSPWmytYtNDnmT)rwUDYNAmSWwCoTDiwmZsStufkqWe2.Type;
				jhrZonNYraaVnYaoFxggXithXJo capabilities = rfGUKNICXjMvSKkObEqIFzzuSJa2.Capabilities;
				xttSOAxySzBEQLtvGhlaStamuIY2.hhkcLloTZcVDgCdaTwOpzCelsoR = properties.ProductId;
				xttSOAxySzBEQLtvGhlaStamuIY2.wTIUKRsZMOmpZhNBlfPZhbzhGk = flag;
				try
				{
					xttSOAxySzBEQLtvGhlaStamuIY2.oidArcJIfGQvDhinAUSWvxCbFPQc = properties.JoystickId;
				}
				catch (Exception)
				{
					xttSOAxySzBEQLtvGhlaStamuIY2.oidArcJIfGQvDhinAUSWvxCbFPQc = 0;
				}
				xttSOAxySzBEQLtvGhlaStamuIY2.tsubhXPAkivKUjJndgFvgCYtCih = capabilities.hXFCmadnASzZQEPEdeoHmBdlTIJA;
				xttSOAxySzBEQLtvGhlaStamuIY2.uELhfbdZYGHumCLLdtArLMIvIGxA = capabilities.vKVJSofBVFDiPCcbycKCGKIUjJfL;
				xttSOAxySzBEQLtvGhlaStamuIY2.ZjLWaiKAEkbMVYsMXPeYLhgiSLG = capabilities.OvHajLmABQoxBJCUifQOFcNVxft;
				qiUGvUqLeoShAwmaLaGtFyNvxzQM(xttSOAxySzBEQLtvGhlaStamuIY2, properties, out xttSOAxySzBEQLtvGhlaStamuIY2.iZnrpEOOjlDqSDsjMdinrkqThZr);
				try
				{
					string productName;
					try
					{
						productName = properties.ProductName;
					}
					catch
					{
						productName = xttSOAxySzBEQLtvGhlaStamuIY2.IBLmgPovQLSZcNmAXhMIAhsmJVX;
					}
					if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)properties.VendorId, (ushort)properties.ProductId, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)properties.VendorId, (ushort)properties.ProductId, productName, out var min, out var max, out var zero))
					{
						xttSOAxySzBEQLtvGhlaStamuIY2.igbQmSqThzEBDsBKZScaimlglKi.RGngbfFWoPZHlGVwifsMxaRtQoz(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)properties.VendorId, (ushort)properties.ProductId, productName));
					}
				}
				catch (Exception)
				{
				}
				if (!flag2)
				{
					IList<QFSOxzhPpyaLqYMwQgtmifgAXZG> list3 = rfGUKNICXjMvSKkObEqIFzzuSJa2.TVaiIWKNfoNxveKqEumdFXOwUxn();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].PNUPKdsUxQjgBzrtMqUfGFBqDTO.Flags & qLlbkJgSwnsGlOrbhfONlbVdJMjX.RsTgZXXBZHrKFqBmaGTodiwVlGzD) != qLlbkJgSwnsGlOrbhfONlbVdJMjX.lKcDIMfHrbBBgTzhXBojeBKdnPsp)
							{
								rfGUKNICXjMvSKkObEqIFzzuSJa2.Properties.Range = new LORDAuECNFpRPQHKhdIzDKYopLmA(-65535, 65535);
							}
						}
					}
					rfGUKNICXjMvSKkObEqIFzzuSJa2.Properties.AxisMode = HFKRfaaqtMAaHgaZACmYQqFFbfTQ.UAuloMvIvFNSTlbDkXiVasOvntW;
					rfGUKNICXjMvSKkObEqIFzzuSJa2.ziFjyeSOwDLkZHbqSBEimrFBCOf(idBhrIasrPEVndsAwTtUPkQwgLkE, owAAslgtlZRBkLCqnJXnZtJciRz.LgtvTjRPymPTjQKaGjfhfDuaYDmG | owAAslgtlZRBkLCqnJXnZtJciRz.AKecQabDebEowINgbVPwdWpqPzsb);
					rfGUKNICXjMvSKkObEqIFzzuSJa2.QqViEWwhZaWrvATfPuWfqnkWwbi();
				}
				list.Add(new wKZwaBmLlpGrsbkHVuUVwhDFwgn(xttSOAxySzBEQLtvGhlaStamuIY2, rwUDYNAmSWwCoTDiwmZsStufkqWe2));
				end_IL_0027:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void wfMgYxfdtVoNyAhVKIiCeAapixnP()
	{
		HsnTwWykStBEJwjyMBjwxAGFxfK(cljxYMgNyNeWVLyzxOlIhJllJvJ());
	}

	private void HsnTwWykStBEJwjyMBjwxAGFxfK(List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> P_0)
	{
		List<xttSOAxySzBEQLtvGhlaStamuIY> list = new List<xttSOAxySzBEQLtvGhlaStamuIY>();
		GdqURqacBvESNwJUhGOhXhTvTAg = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].IsValid)
			{
				continue;
			}
			try
			{
				xttSOAxySzBEQLtvGhlaStamuIY pFnOTHqJnYDWzxCOYtTyZdOVMyq = P_0[i].PFnOTHqJnYDWzxCOYtTyZdOVMyq;
				pFnOTHqJnYDWzxCOYtTyZdOVMyq.awLKiXcoOFmnokthljbUZIrPZrq();
				if (pFnOTHqJnYDWzxCOYtTyZdOVMyq.TIjeAxRHlSqfwwEReELjSBfzpeh)
				{
					GdqURqacBvESNwJUhGOhXhTvTAg++;
				}
				list.Add(pFnOTHqJnYDWzxCOYtTyZdOVMyq);
			}
			catch (Exception)
			{
			}
		}
		iGNfyZdwBdEpReXssxGSouhIwUHh.mYkglasoFxjhfAsEFwsSprCvoLe(GdqURqacBvESNwJUhGOhXhTvTAg);
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			List<xttSOAxySzBEQLtvGhlaStamuIY> wEuHIpAYAmfrlFuzqsSpOYLelMz = WEuHIpAYAmfrlFuzqsSpOYLelMz;
			int num2 = tElQBcMFfTokTSGpOCgJUghpIgcJ;
			int count = list.Count;
			KwmkxSzomVumQegjajVmZlHmThQ(num2, count, wEuHIpAYAmfrlFuzqsSpOYLelMz, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			ZmlQXVOFofpsuUZXWFZOUlSkSAt(wEuHIpAYAmfrlFuzqsSpOYLelMz, list, false);
			ZmlQXVOFofpsuUZXWFZOUlSkSAt(list, wEuHIpAYAmfrlFuzqsSpOYLelMz, true);
			PWyAfbbNzGLKVjbiAWWrlwuxOVq(list, wEuHIpAYAmfrlFuzqsSpOYLelMz);
			WEuHIpAYAmfrlFuzqsSpOYLelMz = list;
			tElQBcMFfTokTSGpOCgJUghpIgcJ = list.Count;
		}
	}

	private void qiUGvUqLeoShAwmaLaGtFyNvxzQM(xttSOAxySzBEQLtvGhlaStamuIY P_0, UahaQRTbdPaFHdrOtyfKJWgzghXZ P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = usQKsbAGCyboWkvovXGOmVypyoBn.eeRbsFgjcGEcYbwbzwbvhdcMPuCo(P_1.InterfacePath);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			nGuMwmGQLFierjbLPQhsmJwGfEIc nGuMwmGQLFierjbLPQhsmJwGfEIc2 = uNUGDLxbzFWxnCXPxXiZAvRTReD.CbkPnOositGayySLpRdkqIQTIvL(text.ToLower(CultureInfo.InvariantCulture));
			if (nGuMwmGQLFierjbLPQhsmJwGfEIc2 != null)
			{
				P_0.TIjeAxRHlSqfwwEReELjSBfzpeh = nGuMwmGQLFierjbLPQhsmJwGfEIc2.IsBluetoothDevice;
				P_0.BDNzUFwhASNOsMHGagnuFDeiUNc = nGuMwmGQLFierjbLPQhsmJwGfEIc2.BluetoothDeviceName;
				P_2 = ZKLIjvmxtRjTyokzJnlXgDPvgmC.YknolmFaNNBJmSzmqGIcasMPdBrK(nGuMwmGQLFierjbLPQhsmJwGfEIc2, P_0.giPzSxcdmJFlxkpGRptEQPgrFzn, P_0.IBLmgPovQLSZcNmAXhMIAhsmJVX, P_0.BDNzUFwhASNOsMHGagnuFDeiUNc);
				nGuMwmGQLFierjbLPQhsmJwGfEIc2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void vKWUwPqagUZSjOHDZUpalOcMgaf()
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			for (int i = 0; i < tElQBcMFfTokTSGpOCgJUghpIgcJ; i++)
			{
				try
				{
					xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = WEuHIpAYAmfrlFuzqsSpOYLelMz[i];
					if (xttSOAxySzBEQLtvGhlaStamuIY2 != null && xttSOAxySzBEQLtvGhlaStamuIY2.YXHHdWXxvTPYwRhsUBWBnayhySV() && (!wYPAnAmOAglaNAsIippUdzhQMob || !xttSOAxySzBEQLtvGhlaStamuIY2.wTIUKRsZMOmpZhNBlfPZhbzhGk))
					{
						xttSOAxySzBEQLtvGhlaStamuIY2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> jyGzJGOiqoBunAXGJoMxRtONAtsl()
	{
		try
		{
			IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> list = hmoIGvwuxwJiZhNwPsZPjZFhpVy.npLwcPNqCJKIqEewEfYdgbDGPcD(HiBJWeyeWfhElzlDChLUgQROjnAq.UOIGbizuvcghCQGjQAUpIizRcQjG, zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt);
			IQZGZAXyrnBrVkzRDzLmBiwupat = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			IQZGZAXyrnBrVkzRDzLmBiwupat = 0;
			return EmptyObjects<rwUDYNAmSWwCoTDiwmZsStufkqWe>.EmptyReadOnlyIListT;
		}
	}

	private void jmfaYfbczmJdEIuNcsOSvgdvRIZW()
	{
		hmoIGvwuxwJiZhNwPsZPjZFhpVy.npLwcPNqCJKIqEewEfYdgbDGPcD();
	}

	private void KwmkxSzomVumQegjajVmZlHmThQ(int P_0, int P_1, List<xttSOAxySzBEQLtvGhlaStamuIY> P_2, List<xttSOAxySzBEQLtvGhlaStamuIY> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(xttSOAxySzBEQLtvGhlaStamuIY.HQEqZQjEIqGDqYsLuCzAlfsgYsm);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			YRoKRRItNDPIoVmafgdCaZmigio(P_1, P_3, P_0, P_2, ZAVoVVxYwqpvvZMZjjXNFpuIkPz.sHchDYgcApQTDepBtPahxbQcocQ.jCoiBlfabpaxiBivYEooCEijjotH);
		}
		CukpyZaqCaKrflYIEoAWQuYhhqd(P_1, P_3, ZAVoVVxYwqpvvZMZjjXNFpuIkPz.sHchDYgcApQTDepBtPahxbQcocQ.jCoiBlfabpaxiBivYEooCEijjotH);
		for (int i = 0; i < P_1; i++)
		{
			xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = P_3[i];
			if (xttSOAxySzBEQLtvGhlaStamuIY2 != null && xttSOAxySzBEQLtvGhlaStamuIY2.inputManagerId < 0)
			{
				xttSOAxySzBEQLtvGhlaStamuIY2.inputManagerId = zwMpiMvmkkdNpwoFkWHdIKVNvMQ(P_3);
				xttSOAxySzBEQLtvGhlaStamuIY2.rewiredId = soqxPQhwIsLUZvHgdWElDYIwuLk();
				RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(xttSOAxySzBEQLtvGhlaStamuIY2);
			}
		}
		P_3.Sort(xttSOAxySzBEQLtvGhlaStamuIY.kxOFZEPgjHEFCJiwzgahiMzQOiwI);
	}

	private void jdLAfzORWSzWAULiMkqIyHkZWvG(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0, int P_1, int P_2)
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

	private bool xKgbnJakGGMPubegxZWtQtwOCOMA(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0, int P_1)
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

	private int zwMpiMvmkkdNpwoFkWHdIKVNvMQ(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0)
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

	private bool rZvMgtxFAtHlxYHFeIOxjWvKfXpH(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0, int P_1)
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

	private void YRoKRRItNDPIoVmafgdCaZmigio(int P_0, List<xttSOAxySzBEQLtvGhlaStamuIY> P_1, int P_2, List<xttSOAxySzBEQLtvGhlaStamuIY> P_3, ZAVoVVxYwqpvvZMZjjXNFpuIkPz.sHchDYgcApQTDepBtPahxbQcocQ P_4)
	{
		int num = ((P_4 != ZAVoVVxYwqpvvZMZjjXNFpuIkPz.sHchDYgcApQTDepBtPahxbQcocQ.jCoiBlfabpaxiBivYEooCEijjotH) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = P_1[i];
			if (xttSOAxySzBEQLtvGhlaStamuIY2 == null || xttSOAxySzBEQLtvGhlaStamuIY2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY3 = P_3[j];
				if (xttSOAxySzBEQLtvGhlaStamuIY3 != null && !rZvMgtxFAtHlxYHFeIOxjWvKfXpH(P_1, xttSOAxySzBEQLtvGhlaStamuIY3.rewiredId) && xttSOAxySzBEQLtvGhlaStamuIY2.KyAfiLYcJFhJNpOgrDEhxwnhNoD(xttSOAxySzBEQLtvGhlaStamuIY3) >= num)
				{
					xttSOAxySzBEQLtvGhlaStamuIY2.eaxwcXMwRKCkmHbjLyonEghfcUhe(xttSOAxySzBEQLtvGhlaStamuIY3);
					RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(xttSOAxySzBEQLtvGhlaStamuIY2);
				}
			}
		}
	}

	private void CukpyZaqCaKrflYIEoAWQuYhhqd(int P_0, List<xttSOAxySzBEQLtvGhlaStamuIY> P_1, ZAVoVVxYwqpvvZMZjjXNFpuIkPz.sHchDYgcApQTDepBtPahxbQcocQ P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = P_1[i];
			if (xttSOAxySzBEQLtvGhlaStamuIY2 == null || xttSOAxySzBEQLtvGhlaStamuIY2.inputManagerId >= 0)
			{
				continue;
			}
			ZAVoVVxYwqpvvZMZjjXNFpuIkPz.EWfdGMzAeRtNdwPsyaGujllDSCsI eWfdGMzAeRtNdwPsyaGujllDSCsI = null;
			foreach (ZAVoVVxYwqpvvZMZjjXNFpuIkPz.EWfdGMzAeRtNdwPsyaGujllDSCsI item in RafIJEjRPcZZJNODanhvgJXwSAct.crTEwBjpShikeXLaYUTdOaoyQQJ(xttSOAxySzBEQLtvGhlaStamuIY2, P_2))
			{
				if (!rZvMgtxFAtHlxYHFeIOxjWvKfXpH(P_1, item.IarEMbMqzCAYwlSQGSgLyHgrWQw) && item.StNvaEdPkeHdOVPfOWiyBYqIBZC >= 0)
				{
					eWfdGMzAeRtNdwPsyaGujllDSCsI = item;
					break;
				}
			}
			if (eWfdGMzAeRtNdwPsyaGujllDSCsI != null)
			{
				int num = eWfdGMzAeRtNdwPsyaGujllDSCsI.StNvaEdPkeHdOVPfOWiyBYqIBZC;
				if (!xKgbnJakGGMPubegxZWtQtwOCOMA(P_1, num))
				{
					num = (eWfdGMzAeRtNdwPsyaGujllDSCsI.StNvaEdPkeHdOVPfOWiyBYqIBZC = zwMpiMvmkkdNpwoFkWHdIKVNvMQ(P_1));
				}
				xttSOAxySzBEQLtvGhlaStamuIY2.inputManagerId = num;
				xttSOAxySzBEQLtvGhlaStamuIY2.rewiredId = eWfdGMzAeRtNdwPsyaGujllDSCsI.IarEMbMqzCAYwlSQGSgLyHgrWQw;
				RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(xttSOAxySzBEQLtvGhlaStamuIY2);
			}
		}
	}

	private void vGxdBlKXJhEtHKJthcyFDIPFLKZi()
	{
		if (XazDXdLmqFaahtQowFABimVmkYzw)
		{
			BkJdeIMBEvNyjriHoGzWTRvwyfd();
		}
		if (qrWkihqzKfQCChINMfqVmAeIlfB.isRunning && qrWkihqzKfQCChINMfqVmAeIlfB.lVgWjrQkCsFlsaFVzSjplyEWLEJg())
		{
			GntxwHbSvkdKZVqZrEXWzBoLwgM(qrWkihqzKfQCChINMfqVmAeIlfB.result);
		}
	}

	private void BkJdeIMBEvNyjriHoGzWTRvwyfd()
	{
		XazDXdLmqFaahtQowFABimVmkYzw = false;
		if (!qrWkihqzKfQCChINMfqVmAeIlfB.isRunning)
		{
			qrWkihqzKfQCChINMfqVmAeIlfB.UyHkmeYMKxbRaLGZZmHNfcnwklW();
		}
	}

	private void GntxwHbSvkdKZVqZrEXWzBoLwgM(List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> P_0)
	{
		if (xpwTkcFvimSLOfpOpgTZDXMIVrrj(wKZwaBmLlpGrsbkHVuUVwhDFwgn.YeGaQhqvXLymnvCOkDrUEjjQAcA(P_0)))
		{
			HsnTwWykStBEJwjyMBjwxAGFxfK(P_0);
		}
	}

	private bool xpwTkcFvimSLOfpOpgTZDXMIVrrj(IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> P_0)
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !czJBvlfxhCiJqbFVedmVBFfpdTE(P_0[i].wXKmhfCcjUksYEsLiiQybuQLGQI))
				{
					return true;
				}
			}
			int count2 = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
			for (int j = 0; j < count2; j++)
			{
				if (WEuHIpAYAmfrlFuzqsSpOYLelMz[j] != null && !PwBwoOjLHcxUOJjuFAJtJZzDlnn(P_0, WEuHIpAYAmfrlFuzqsSpOYLelMz[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool czJBvlfxhCiJqbFVedmVBFfpdTE(Guid P_0)
	{
		lock (WfTbITFnDgahnloEWtIracmCfqy)
		{
			int count = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
			for (int i = 0; i < count; i++)
			{
				if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null && WEuHIpAYAmfrlFuzqsSpOYLelMz[i].instanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool PwBwoOjLHcxUOJjuFAJtJZzDlnn(IList<rwUDYNAmSWwCoTDiwmZsStufkqWe> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].wXKmhfCcjUksYEsLiiQybuQLGQI == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ZmlQXVOFofpsuUZXWFZOUlSkSAt(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0, List<xttSOAxySzBEQLtvGhlaStamuIY> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY2 = P_0[i];
			if (xttSOAxySzBEQLtvGhlaStamuIY2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					xttSOAxySzBEQLtvGhlaStamuIY xttSOAxySzBEQLtvGhlaStamuIY3 = P_1[j];
					if (xttSOAxySzBEQLtvGhlaStamuIY3 != null && xttSOAxySzBEQLtvGhlaStamuIY2.instanceGuid == xttSOAxySzBEQLtvGhlaStamuIY3.instanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				bGZMnrEUihehhlqffgHFcHUJpbf(P_0[i], P_2);
			}
		}
	}

	private void bGZMnrEUihehhlqffgHFcHUJpbf(xttSOAxySzBEQLtvGhlaStamuIY P_0, bool P_1)
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

	private bool VMtEQWtzyAGQAnUhFnHPzvdEAKR()
	{
		int num = hmoIGvwuxwJiZhNwPsZPjZFhpVy.uYEAGtqGpXGOqyYytMRHARWYrtv(HiBJWeyeWfhElzlDChLUgQROjnAq.UOIGbizuvcghCQGjQAUpIizRcQjG, zTnRQWEjlkWYSgeKMuNijZncOjb.mfDsciKEpiiAxZMfjwhaCIxnzBt);
		if (IQZGZAXyrnBrVkzRDzLmBiwupat != num)
		{
			IQZGZAXyrnBrVkzRDzLmBiwupat = num;
			return true;
		}
		if (GdqURqacBvESNwJUhGOhXhTvTAg > 0 && iGNfyZdwBdEpReXssxGSouhIwUHh.MGgleQdlFqqjvEMGIOFgkiqHvvR())
		{
			return true;
		}
		return false;
	}

	private void PWyAfbbNzGLKVjbiAWWrlwuxOVq(List<xttSOAxySzBEQLtvGhlaStamuIY> P_0, List<xttSOAxySzBEQLtvGhlaStamuIY> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].LLOFbzNISIbRkZTwkaVnsPpYig();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void FJIcWmWzRBcerVUFofxYfXyRAXG(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<wKZwaBmLlpGrsbkHVuUVwhDFwgn> bjMlqwqtxorHGRcAxBZaakVCinX()
	{
		return cljxYMgNyNeWVLyzxOlIhJllJvJ();
	}
}
