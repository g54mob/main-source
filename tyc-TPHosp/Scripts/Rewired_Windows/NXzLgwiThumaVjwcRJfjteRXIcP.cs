using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Windows.RawInput;

internal class NXzLgwiThumaVjwcRJfjteRXIcP : PlatformInputManager, ofDdrrXOoPYnlTBBhXLegRaygjXC
{
	private class UarCymSBEKuIcmOWvaMIzilEuIM : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int NajCXKtukqHbFEALjLVyGCYCNtSb;

		private int UMWomiZvEhDEPuJOYiXKDueLnyc;

		public Guid VUgBODHNCJPXSoOhhBOWRFfzFbGD;

		public string RxaFaRXqeYZbErOsosnUgQSpQhN;

		private readonly UzKBIaEyudSpXeLmfwTkGCYvktG PFnOTHqJnYDWzxCOYtTyZdOVMyq;

		private readonly DeviceType PXkMEMTkWtuGutiOraKhjHvOGFx;

		public string kxKCChAepXZZMUCPgfBLnfqoDYsI;

		public string IBLmgPovQLSZcNmAXhMIAhsmJVX;

		public string BDNzUFwhASNOsMHGagnuFDeiUNc;

		public int hhkcLloTZcVDgCdaTwOpzCelsoR;

		public int HgIEIMWSDaFhIGVwBNVWCVPHunvR;

		public Guid ypBhwPylZXgbWvdXwgdHvTJZNDf;

		public Guid giPzSxcdmJFlxkpGRptEQPgrFzn;

		public Guid YTUiBjSgszCjFKdQcXGXQLdjmPC;

		public int oidArcJIfGQvDhinAUSWvxCbFPQc;

		public int odPqVuqwqCGxHoMYKpamBTSJBGU;

		public int rxWqrCZnPtiqWFbRznNyTZvGOEF;

		public int tsubhXPAkivKUjJndgFvgCYtCih;

		public int uELhfbdZYGHumCLLdtArLMIvIGxA;

		public int ZjLWaiKAEkbMVYsMXPeYLhgiSLG;

		public bool wTIUKRsZMOmpZhNBlfPZhbzhGk;

		public bool TIjeAxRHlSqfwwEReELjSBfzpeh;

		public bool wAZMpcjYCVAzjJccPAzohypyqPYD;

		public int lpBHnYIqUEtJizBVtebuWwTDdFle;

		private float[] PdhmHHQzLgjPZAoxHUYVuyeAAEh;

		private float[] tBDNhubiBrrcAkNhlDXEHdQeLZEA;

		private bool[] kQQSIMaHdsbNAbJxIbJuHtUOjYs;

		private HardwareJoystickMap_InputManager VwkQKXgoNahhCiMQWLUMFSQOAvBb;

		private bbDFITqKYezHstfvOWFmFoaPRag BxdadZrRQDlKkpMxCfSufzhvUwW;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

		private bool odakGqXSybzjkLavhBfCeptlajT;

		private bool FZwJHUUPwuLUimELESGrJJjnaNW;

		private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

		[CompilerGenerated]
		private Controller.Extension KbCwOwDLZuaRXXMpxOxRegpVGdJ;

		public bool hasDriver
		{
			get
			{
				if (PFnOTHqJnYDWzxCOYtTyZdOVMyq == null)
				{
					return false;
				}
				return PFnOTHqJnYDWzxCOYtTyZdOVMyq.Driver != null;
			}
		}

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
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return KbCwOwDLZuaRXXMpxOxRegpVGdJ;
			}
			[CompilerGenerated]
			set
			{
				KbCwOwDLZuaRXXMpxOxRegpVGdJ = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => ypBhwPylZXgbWvdXwgdHvTJZNDf;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		public bool IsValid
		{
			get
			{
				if (!dkPCbOYSgevDLsWpfwoFAuUOPFV && PFnOTHqJnYDWzxCOYtTyZdOVMyq != null)
				{
					return PFnOTHqJnYDWzxCOYtTyZdOVMyq.IsValid;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = IsValid;
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = IsValid;
		}

		public UarCymSBEKuIcmOWvaMIzilEuIM(UzKBIaEyudSpXeLmfwTkGCYvktG joystick, DeviceType riDeviceType, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			PFnOTHqJnYDWzxCOYtTyZdOVMyq = joystick;
			PXkMEMTkWtuGutiOraKhjHvOGFx = riDeviceType;
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			UMWomiZvEhDEPuJOYiXKDueLnyc = -1;
			NajCXKtukqHbFEALjLVyGCYCNtSb = -1;
		}

		public void awLKiXcoOFmnokthljbUZIrPZrq()
		{
			if (!IsValid)
			{
				return;
			}
			YTUiBjSgszCjFKdQcXGXQLdjmPC = MiscTools.CreateGuidHashSHA1(((!string.IsNullOrEmpty(BDNzUFwhASNOsMHGagnuFDeiUNc)) ? BDNzUFwhASNOsMHGagnuFDeiUNc : IBLmgPovQLSZcNmAXhMIAhsmJVX) + giPzSxcdmJFlxkpGRptEQPgrFzn);
			odPqVuqwqCGxHoMYKpamBTSJBGU = tsubhXPAkivKUjJndgFvgCYtCih;
			rxWqrCZnPtiqWFbRznNyTZvGOEF = uELhfbdZYGHumCLLdtArLMIvIGxA + ZjLWaiKAEkbMVYsMXPeYLhgiSLG * 8;
			TGqlSqzKzTCPYwisxjGzscmapHG();
			VUgBODHNCJPXSoOhhBOWRFfzFbGD = VwkQKXgoNahhCiMQWLUMFSQOAvBb.hardwareMapIdentifier.guid;
			RxaFaRXqeYZbErOsosnUgQSpQhN = VwkQKXgoNahhCiMQWLUMFSQOAvBb.controllerName;
			odakGqXSybzjkLavhBfCeptlajT = ((VUgBODHNCJPXSoOhhBOWRFfzFbGD == Guid.Empty) ? true : false);
			PdhmHHQzLgjPZAoxHUYVuyeAAEh = new float[odPqVuqwqCGxHoMYKpamBTSJBGU];
			tBDNhubiBrrcAkNhlDXEHdQeLZEA = new float[rxWqrCZnPtiqWFbRznNyTZvGOEF];
			kQQSIMaHdsbNAbJxIbJuHtUOjYs = new bool[rxWqrCZnPtiqWFbRznNyTZvGOEF];
			if (VwkQKXgoNahhCiMQWLUMFSQOAvBb != null && rxWqrCZnPtiqWFbRznNyTZvGOEF > 0)
			{
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
							kQQSIMaHdsbNAbJxIbJuHtUOjYs[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
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
							kQQSIMaHdsbNAbJxIbJuHtUOjYs[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			BxdadZrRQDlKkpMxCfSufzhvUwW = PFnOTHqJnYDWzxCOYtTyZdOVMyq.AxesState;
			Update();
		}

		public void eaxwcXMwRKCkmHbjLyonEghfcUhe(UarCymSBEKuIcmOWvaMIzilEuIM P_0)
		{
			if (IsValid && P_0 != null)
			{
				UMWomiZvEhDEPuJOYiXKDueLnyc = P_0.UMWomiZvEhDEPuJOYiXKDueLnyc;
				NajCXKtukqHbFEALjLVyGCYCNtSb = P_0.NajCXKtukqHbFEALjLVyGCYCNtSb;
				for (int i = 0; i < MathTools.Min(tBDNhubiBrrcAkNhlDXEHdQeLZEA.Length, P_0.tBDNhubiBrrcAkNhlDXEHdQeLZEA.Length); i++)
				{
					tBDNhubiBrrcAkNhlDXEHdQeLZEA[i] = P_0.tBDNhubiBrrcAkNhlDXEHdQeLZEA[i];
				}
				for (int j = 0; j < MathTools.Min(kQQSIMaHdsbNAbJxIbJuHtUOjYs.Length, P_0.kQQSIMaHdsbNAbJxIbJuHtUOjYs.Length); j++)
				{
					kQQSIMaHdsbNAbJxIbJuHtUOjYs[j] = P_0.kQQSIMaHdsbNAbJxIbJuHtUOjYs[j];
				}
				for (int k = 0; k < MathTools.Min(PdhmHHQzLgjPZAoxHUYVuyeAAEh.Length, P_0.PdhmHHQzLgjPZAoxHUYVuyeAAEh.Length); k++)
				{
					PdhmHHQzLgjPZAoxHUYVuyeAAEh[k] = P_0.PdhmHHQzLgjPZAoxHUYVuyeAAEh[k];
				}
				FZwJHUUPwuLUimELESGrJJjnaNW = P_0.FZwJHUUPwuLUimELESGrJJjnaNW;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (IsValid)
			{
				bool[] buttons = PFnOTHqJnYDWzxCOYtTyZdOVMyq.Buttons;
				int[] hatValues = PFnOTHqJnYDWzxCOYtTyZdOVMyq.HatValues;
				IhdIeUwZwRLqiJyYdCtNVPXciIb(buttons, hatValues);
				xHNCeTbZYBVqRMCQRrncKAxpnCcM(buttons, hatValues);
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!IsValid)
			{
				return;
			}
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
				if (kQQSIMaHdsbNAbJxIbJuHtUOjYs[j])
				{
					dataUpdater.buttonPressureValues[j] = tBDNhubiBrrcAkNhlDXEHdQeLZEA[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = ((tBDNhubiBrrcAkNhlDXEHdQeLZEA[j] > 0f) ? true : false);
				}
			}
			if (FZwJHUUPwuLUimELESGrJJjnaNW && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int KyAfiLYcJFhJNpOgrDEhxwnhNoD(UarCymSBEKuIcmOWvaMIzilEuIM P_0)
		{
			if (!IsValid)
			{
				return 0;
			}
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
			if (hasDriver != P_0.hasDriver)
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
			if (!IsValid)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			eVVvseUpGSgpqZdXlHEbWYuzpch(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(NajCXKtukqHbFEALjLVyGCYCNtSb);
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
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = platform_RawInput_Base.Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						TZtvkoZhamkXyDxmbLPRqzoeirq(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = platform_DirectInput_Base.Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						TZtvkoZhamkXyDxmbLPRqzoeirq(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = platform_InternalDriver_Base.Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						RiMJdLqoOJeRMmWavBbzhHItgKyC(axes_orig[i], i, P_0, P_1);
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
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = platform_RawInput_Base.Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						VqJtHEGbHByZNiOMEpxzghFtXwK(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.zjuIGPllhlPcayeppPtHSewObGXj:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						VqJtHEGbHByZNiOMEpxzghFtXwK(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.FhqZiqCHhXxQXjCHQDlDqwTlgOd:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map;
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = platform_InternalDriver_Base.Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						aVivklaMKZgYacCOGPDeNICcGbEH(buttons_orig[i], i, P_0, P_1);
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
			if (!FZwJHUUPwuLUimELESGrJJjnaNW && tBDNhubiBrrcAkNhlDXEHdQeLZEA[P_1] != 0f)
			{
				FZwJHUUPwuLUimELESGrJJjnaNW = true;
			}
		}

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Axis axis))
						{
							return 0f;
						}
						num = axis.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				return CCwCnYhEmaFZrOQeiMBHgUHikwcc((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 256)
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
				int num2 = P_2[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = bVkYilBptDFBBxeggyXamyleLyY(num2, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num3 = bVkYilBptDFBBxeggyXamyleLyY(num2, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num3 *= -1f;
				}
				return num3;
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

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(RawInputAxis P_0, int P_1)
		{
			return jBwGMgeXcypsIUbeXmoFAFFnKCeq((BxdadZrRQDlKkpMxCfSufzhvUwW as gjXrWEFBmmfJodbKaRYGCXcWpVk).CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0, P_1));
		}

		private float golTpfekpJZdxAtdMfSTzBKxebB(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return 0f;
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
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Button button))
						{
							return 0f;
						}
						num = button.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				float num2 = CCwCnYhEmaFZrOQeiMBHgUHikwcc((RawInputAxis)sourceAxis, num);
				float num3 = MathTools.Abs(num2);
				if (num3 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
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
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ZjLWaiKAEkbMVYsMXPeYLhgiSLG || sourceHat >= 4)
				{
					return 0f;
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
						if (KcfsmpRBxcTGrLJKxoRyPeEhvxp(customCalculationSourceData[k], out var num4))
						{
							customCalculation.AddData((num4 != 0f) ? 1f : 0f);
						}
						break;
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
				if ((float)customCalculation.Result == 0f)
				{
					return 0f;
				}
				return 1f;
			}
			return 0f;
		}

		private float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float mVkxGfqHdFJcAwxyxMgTjGelngm(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (VwkQKXgoNahhCiMQWLUMFSQOAvBb.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500;
			int num2 = num * P_1;
			if (P_2 == HatType.EightWay && P_0 != num2)
			{
				return 0f;
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
				return 1f;
			}
			return 0f;
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
			if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 256)
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
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = CCwCnYhEmaFZrOQeiMBHgUHikwcc((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
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

		private ControlDeviceType sxRJZvgpBQbKbCUVcRFtSiYDPhb(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.fQYnmvKyNAUpwLJlHByyedaPIyZG, 
				DeviceType.Joystick => ControlDeviceType.uiRYEFedDHmUTxShoQfUcCLjblSE, 
				DeviceType.Gamepad => ControlDeviceType.xMAFLxhGvaUFxGrktALTXyTGqvn, 
				DeviceType.Mouse => ControlDeviceType.EbLlCRijimOLmWyMuIbuKxBCfaJ, 
				DeviceType.MultiAxisController => ControlDeviceType.uiRYEFedDHmUTxShoQfUcCLjblSE, 
				_ => ControlDeviceType.eDgdySKclHgXmmILffzdHPvUtEi, 
			};
		}

		private void RiMJdLqoOJeRMmWavBbzhHItgKyC(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= odPqVuqwqCGxHoMYKpamBTSJBGU)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			PdhmHHQzLgjPZAoxHUYVuyeAAEh[P_1] = oIAwYKrJMtTLcZLLfnYpXPPoRxF(P_0, P_2, P_3);
			if (!FZwJHUUPwuLUimELESGrJJjnaNW && PdhmHHQzLgjPZAoxHUYVuyeAAEh[P_1] != 0f)
			{
				FZwJHUUPwuLUimELESGrJJjnaNW = true;
			}
		}

		private void aVivklaMKZgYacCOGPDeNICcGbEH(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= rxWqrCZnPtiqWFbRznNyTZvGOEF)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			tBDNhubiBrrcAkNhlDXEHdQeLZEA[P_1] = SJltjwebVttAwYwQxWqycRoUHHU(P_0, P_2, P_3);
			if (!FZwJHUUPwuLUimELESGrJJjnaNW && tBDNhubiBrrcAkNhlDXEHdQeLZEA[P_1] != 0f)
			{
				FZwJHUUPwuLUimELESGrJJjnaNW = true;
			}
		}

		private float oIAwYKrJMtTLcZLLfnYpXPPoRxF(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= tsubhXPAkivKUjJndgFvgCYtCih || sourceAxis >= 56)
				{
					return 0f;
				}
				return oIAwYKrJMtTLcZLLfnYpXPPoRxF(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 256)
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
			if (P_0.sourceType == 2)
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
			return 0f;
		}

		private float oIAwYKrJMtTLcZLLfnYpXPPoRxF(int P_0)
		{
			return (BxdadZrRQDlKkpMxCfSufzhvUwW as saLjtbZSBxlqoNzvuSJHtknSlTo).CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0);
		}

		private float SJltjwebVttAwYwQxWqycRoUHHU(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= uELhfbdZYGHumCLLdtArLMIvIGxA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= tsubhXPAkivKUjJndgFvgCYtCih || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = oIAwYKrJMtTLcZLLfnYpXPPoRxF(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= ZjLWaiKAEkbMVYsMXPeYLhgiSLG || sourceHat >= 4)
				{
					return 0f;
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
			return 0f;
		}

		private bool UzjvPSRxaZirwYFxtFfaNsxkHOx(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
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

		private float RGTQzkUgZkJgNLbztdSrbGKkVlv(int P_0, AxisDirection P_1)
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

		private string REhszzMgvCPPesBPhjVnWjgLmgV()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.RawInput}{((TIjeAxRHlSqfwwEReELjSBfzpeh && !string.IsNullOrEmpty(BDNzUFwhASNOsMHGagnuFDeiUNc)) ? BDNzUFwhASNOsMHGagnuFDeiUNc : IBLmgPovQLSZcNmAXhMIAhsmJVX)}{hhkcLloTZcVDgCdaTwOpzCelsoR}{giPzSxcdmJFlxkpGRptEQPgrFzn}");
		}

		private void eVVvseUpGSgpqZdXlHEbWYuzpch(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = PFnOTHqJnYDWzxCOYtTyZdOVMyq.InputSource;
			P_0.deviceType = sxRJZvgpBQbKbCUVcRFtSiYDPhb(PXkMEMTkWtuGutiOraKhjHvOGFx);
			P_0.hardwareIdentifier = REhszzMgvCPPesBPhjVnWjgLmgV();
			P_0.hardwareAxisCount = tsubhXPAkivKUjJndgFvgCYtCih;
			P_0.hardwareButtonCount = uELhfbdZYGHumCLLdtArLMIvIGxA;
			P_0.hardwareHatCount = ZjLWaiKAEkbMVYsMXPeYLhgiSLG;
			P_0.hw_productName = IBLmgPovQLSZcNmAXhMIAhsmJVX;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_vendorId = HgIEIMWSDaFhIGVwBNVWCVPHunvR;
			P_0.hw_productId = hhkcLloTZcVDgCdaTwOpzCelsoR;
			P_0.hw_pidVid = new PidVid(giPzSxcdmJFlxkpGRptEQPgrFzn);
			P_0.hw_isBluetoothDevice = TIjeAxRHlSqfwwEReELjSBfzpeh;
			P_0.hw_bluetoothDeviceName = BDNzUFwhASNOsMHGagnuFDeiUNc;
			P_0.hw_supportsVibration = wAZMpcjYCVAzjJccPAzohypyqPYD;
			P_0.hw_localVibrationMotorCount = lpBHnYIqUEtJizBVtebuWwTDdFle;
			P_0.definitionMatchTag = PFnOTHqJnYDWzxCOYtTyZdOVMyq.HWDefinitionMatchTag;
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
			P_0.isButtonPressureSensitive = new bool[rxWqrCZnPtiqWFbRznNyTZvGOEF];
			Array.Copy(kQQSIMaHdsbNAbJxIbJuHtUOjYs, P_0.isButtonPressureSensitive, rxWqrCZnPtiqWFbRznNyTZvGOEF);
			P_0.unknownControllerHats = NhzPiRcnZCCXfbyviPcQNUGlGHLo();
			P_0.controllerTypeGuid = VUgBODHNCJPXSoOhhBOWRFfzFbGD;
			P_0.controllerExtension = extension;
		}

		private void GZJOVqtzFnuulSFDMOgQNpJxYuk()
		{
			for (int i = 0; i < rxWqrCZnPtiqWFbRznNyTZvGOEF; i++)
			{
				tBDNhubiBrrcAkNhlDXEHdQeLZEA[i] = 0f;
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

		~UarCymSBEKuIcmOWvaMIzilEuIM()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(false);
		}

		protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
		{
			if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			}
		}

		public static int QwvSPJxYjPaiiPmCTKmKweDrutf(UarCymSBEKuIcmOWvaMIzilEuIM P_0, UarCymSBEKuIcmOWvaMIzilEuIM P_1)
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

		public static int CxXDnpMWrnfKMDSwWHTiDGGcTnCF(UarCymSBEKuIcmOWvaMIzilEuIM P_0, UarCymSBEKuIcmOWvaMIzilEuIM P_1)
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

	private class eZqnHLQqpFsiyxjHfkpdhbbdZRW
	{
		public enum zeTkJrQnaflKrnxBzXiEoUXMbKm
		{
			jCoiBlfabpaxiBivYEooCEijjotH = 0,
			LGsVvWMqVpKpHXTLCoBgxjvzdgdF = 1
		}

		public class muzGKpSLiaiIwPFIvDaPjcxstwN
		{
			public int IarEMbMqzCAYwlSQGSgLyHgrWQw;

			public Guid KTBFXHUSsvUaTwiOmbyvhbRGtyWr;

			public Guid YTUiBjSgszCjFKdQcXGXQLdjmPC;

			public int StNvaEdPkeHdOVPfOWiyBYqIBZC;

			public int tsubhXPAkivKUjJndgFvgCYtCih;

			public int uELhfbdZYGHumCLLdtArLMIvIGxA;

			public int ZjLWaiKAEkbMVYsMXPeYLhgiSLG;

			public int rxWqrCZnPtiqWFbRznNyTZvGOEF;

			public int odPqVuqwqCGxHoMYKpamBTSJBGU;

			public bool UFyhErDGkTlryPeOZSuxSgLCNMRB;

			public bool KyAfiLYcJFhJNpOgrDEhxwnhNoD(UarCymSBEKuIcmOWvaMIzilEuIM P_0, zeTkJrQnaflKrnxBzXiEoUXMbKm P_1)
			{
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
				if (rxWqrCZnPtiqWFbRznNyTZvGOEF != P_0.rxWqrCZnPtiqWFbRznNyTZvGOEF)
				{
					return false;
				}
				if (odPqVuqwqCGxHoMYKpamBTSJBGU != P_0.odPqVuqwqCGxHoMYKpamBTSJBGU)
				{
					return false;
				}
				if (UFyhErDGkTlryPeOZSuxSgLCNMRB != P_0.hasDriver)
				{
					return false;
				}
				if (P_0.rewiredId == IarEMbMqzCAYwlSQGSgLyHgrWQw)
				{
					return true;
				}
				return P_1 switch
				{
					zeTkJrQnaflKrnxBzXiEoUXMbKm.jCoiBlfabpaxiBivYEooCEijjotH => KTBFXHUSsvUaTwiOmbyvhbRGtyWr == P_0.instanceGuid, 
					zeTkJrQnaflKrnxBzXiEoUXMbKm.LGsVvWMqVpKpHXTLCoBgxjvzdgdF => YTUiBjSgszCjFKdQcXGXQLdjmPC == P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC, 
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
				text = string.Concat(obj7, "hardwareHatCount = ", ZjLWaiKAEkbMVYsMXPeYLhgiSLG, "\n");
				object obj8 = text;
				text = string.Concat(obj8, "gameButtonCount = ", rxWqrCZnPtiqWFbRznNyTZvGOEF, "\n");
				object obj9 = text;
				text = string.Concat(obj9, "gameAxisCount = ", odPqVuqwqCGxHoMYKpamBTSJBGU, "\n");
				object obj10 = text;
				return string.Concat(obj10, "hasDriver = ", UFyhErDGkTlryPeOZSuxSgLCNMRB, "\n");
			}
		}

		private sealed class jwsvIzegJVAbHLFLqDmUpHROYgZ : IEnumerable<muzGKpSLiaiIwPFIvDaPjcxstwN>, IEnumerator<muzGKpSLiaiIwPFIvDaPjcxstwN>, IDisposable, IEnumerable, IEnumerator
		{
			private muzGKpSLiaiIwPFIvDaPjcxstwN eGPKTGyzgMFAWcHLLlCxsVDFMVF;

			private int waNxGruVnkDJsvXTmfsQkrGamZW;

			private int BBQWedXXzEABJslsFGqlwQvMEop;

			public eZqnHLQqpFsiyxjHfkpdhbbdZRW atnkeqgXxTBLxuTqVeTupqRLlmp;

			public UarCymSBEKuIcmOWvaMIzilEuIM CefbijIwCmLkPuepfMadBXgHqcyK;

			public UarCymSBEKuIcmOWvaMIzilEuIM iFluTsQcIlgKEhcOMkSFgVVbRpfl;

			public zeTkJrQnaflKrnxBzXiEoUXMbKm lUgIDcEJoqQxAXsgxguWfbjkfCij;

			public zeTkJrQnaflKrnxBzXiEoUXMbKm TPzaVyiSPZBiaBIeziXdlbKGjEo;

			public int rAQuLqqdryBDpYOSJIZUecFfFqh;

			public int yQLmLHFqxfabzsUAttgiCdWQjAS;

			muzGKpSLiaiIwPFIvDaPjcxstwN IEnumerator<muzGKpSLiaiIwPFIvDaPjcxstwN>.Current
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
			IEnumerator<muzGKpSLiaiIwPFIvDaPjcxstwN> IEnumerable<muzGKpSLiaiIwPFIvDaPjcxstwN>.GetEnumerator()
			{
				jwsvIzegJVAbHLFLqDmUpHROYgZ jwsvIzegJVAbHLFLqDmUpHROYgZ2;
				if (Thread.CurrentThread.ManagedThreadId == BBQWedXXzEABJslsFGqlwQvMEop && waNxGruVnkDJsvXTmfsQkrGamZW == -2)
				{
					waNxGruVnkDJsvXTmfsQkrGamZW = 0;
					jwsvIzegJVAbHLFLqDmUpHROYgZ2 = this;
				}
				else
				{
					jwsvIzegJVAbHLFLqDmUpHROYgZ2 = new jwsvIzegJVAbHLFLqDmUpHROYgZ(0);
					jwsvIzegJVAbHLFLqDmUpHROYgZ2.atnkeqgXxTBLxuTqVeTupqRLlmp = atnkeqgXxTBLxuTqVeTupqRLlmp;
				}
				jwsvIzegJVAbHLFLqDmUpHROYgZ2.CefbijIwCmLkPuepfMadBXgHqcyK = iFluTsQcIlgKEhcOMkSFgVVbRpfl;
				jwsvIzegJVAbHLFLqDmUpHROYgZ2.lUgIDcEJoqQxAXsgxguWfbjkfCij = TPzaVyiSPZBiaBIeziXdlbKGjEo;
				return jwsvIzegJVAbHLFLqDmUpHROYgZ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<muzGKpSLiaiIwPFIvDaPjcxstwN>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (waNxGruVnkDJsvXTmfsQkrGamZW)
				{
				case 0:
					waNxGruVnkDJsvXTmfsQkrGamZW = -1;
					rAQuLqqdryBDpYOSJIZUecFfFqh = atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
					yQLmLHFqxfabzsUAttgiCdWQjAS = 0;
					goto IL_00a3;
				case 1:
					{
						waNxGruVnkDJsvXTmfsQkrGamZW = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (yQLmLHFqxfabzsUAttgiCdWQjAS >= rAQuLqqdryBDpYOSJIZUecFfFqh)
					{
						break;
					}
					if (atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi[yQLmLHFqxfabzsUAttgiCdWQjAS].KyAfiLYcJFhJNpOgrDEhxwnhNoD(CefbijIwCmLkPuepfMadBXgHqcyK, lUgIDcEJoqQxAXsgxguWfbjkfCij))
					{
						eGPKTGyzgMFAWcHLLlCxsVDFMVF = atnkeqgXxTBLxuTqVeTupqRLlmp.rHeRGdaxkUgtZdjiIBVhiIXdbi[yQLmLHFqxfabzsUAttgiCdWQjAS];
						waNxGruVnkDJsvXTmfsQkrGamZW = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					yQLmLHFqxfabzsUAttgiCdWQjAS++;
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
			public jwsvIzegJVAbHLFLqDmUpHROYgZ(int _003C_003E1__state)
			{
				waNxGruVnkDJsvXTmfsQkrGamZW = _003C_003E1__state;
				BBQWedXXzEABJslsFGqlwQvMEop = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<muzGKpSLiaiIwPFIvDaPjcxstwN> rHeRGdaxkUgtZdjiIBVhiIXdbi;

		public eZqnHLQqpFsiyxjHfkpdhbbdZRW()
		{
			rHeRGdaxkUgtZdjiIBVhiIXdbi = new List<muzGKpSLiaiIwPFIvDaPjcxstwN>();
		}

		public void xgVDvWMPwGSwXsgsVGmvrCGbsMR(UarCymSBEKuIcmOWvaMIzilEuIM P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
			for (int i = 0; i < count; i++)
			{
				if (rHeRGdaxkUgtZdjiIBVhiIXdbi[i].KyAfiLYcJFhJNpOgrDEhxwnhNoD(P_0, zeTkJrQnaflKrnxBzXiEoUXMbKm.jCoiBlfabpaxiBivYEooCEijjotH))
				{
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].IarEMbMqzCAYwlSQGSgLyHgrWQw = P_0.rewiredId;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].KTBFXHUSsvUaTwiOmbyvhbRGtyWr = P_0.instanceGuid;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].YTUiBjSgszCjFKdQcXGXQLdjmPC = P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].StNvaEdPkeHdOVPfOWiyBYqIBZC = P_0.inputManagerId;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].tsubhXPAkivKUjJndgFvgCYtCih = P_0.tsubhXPAkivKUjJndgFvgCYtCih;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].uELhfbdZYGHumCLLdtArLMIvIGxA = P_0.uELhfbdZYGHumCLLdtArLMIvIGxA;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].ZjLWaiKAEkbMVYsMXPeYLhgiSLG = P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].rxWqrCZnPtiqWFbRznNyTZvGOEF = P_0.rxWqrCZnPtiqWFbRznNyTZvGOEF;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].odPqVuqwqCGxHoMYKpamBTSJBGU = P_0.odPqVuqwqCGxHoMYKpamBTSJBGU;
					rHeRGdaxkUgtZdjiIBVhiIXdbi[i].UFyhErDGkTlryPeOZSuxSgLCNMRB = P_0.hasDriver;
					FJLMwloVnlBXUksRQWoCzvEJpgt(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			rHeRGdaxkUgtZdjiIBVhiIXdbi.Add(new muzGKpSLiaiIwPFIvDaPjcxstwN
			{
				IarEMbMqzCAYwlSQGSgLyHgrWQw = P_0.rewiredId,
				KTBFXHUSsvUaTwiOmbyvhbRGtyWr = P_0.instanceGuid,
				YTUiBjSgszCjFKdQcXGXQLdjmPC = P_0.YTUiBjSgszCjFKdQcXGXQLdjmPC,
				StNvaEdPkeHdOVPfOWiyBYqIBZC = P_0.inputManagerId,
				tsubhXPAkivKUjJndgFvgCYtCih = P_0.tsubhXPAkivKUjJndgFvgCYtCih,
				uELhfbdZYGHumCLLdtArLMIvIGxA = P_0.uELhfbdZYGHumCLLdtArLMIvIGxA,
				ZjLWaiKAEkbMVYsMXPeYLhgiSLG = P_0.ZjLWaiKAEkbMVYsMXPeYLhgiSLG,
				rxWqrCZnPtiqWFbRznNyTZvGOEF = P_0.rxWqrCZnPtiqWFbRznNyTZvGOEF,
				odPqVuqwqCGxHoMYKpamBTSJBGU = P_0.odPqVuqwqCGxHoMYKpamBTSJBGU,
				UFyhErDGkTlryPeOZSuxSgLCNMRB = P_0.hasDriver
			});
			FJLMwloVnlBXUksRQWoCzvEJpgt(P_0.rewiredId, P_0.instanceGuid, rHeRGdaxkUgtZdjiIBVhiIXdbi.Count - 1);
		}

		public bool WDMRBLdLaAepmasexhLgbGtHkMQT(UarCymSBEKuIcmOWvaMIzilEuIM P_0, zeTkJrQnaflKrnxBzXiEoUXMbKm P_1)
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

		public IEnumerable<muzGKpSLiaiIwPFIvDaPjcxstwN> crTEwBjpShikeXLaYUTdOaoyQQJ(UarCymSBEKuIcmOWvaMIzilEuIM P_0, zeTkJrQnaflKrnxBzXiEoUXMbKm P_1)
		{
			jwsvIzegJVAbHLFLqDmUpHROYgZ jwsvIzegJVAbHLFLqDmUpHROYgZ2 = new jwsvIzegJVAbHLFLqDmUpHROYgZ(-2);
			jwsvIzegJVAbHLFLqDmUpHROYgZ2.atnkeqgXxTBLxuTqVeTupqRLlmp = this;
			jwsvIzegJVAbHLFLqDmUpHROYgZ2.iFluTsQcIlgKEhcOMkSFgVVbRpfl = P_0;
			jwsvIzegJVAbHLFLqDmUpHROYgZ2.TPzaVyiSPZBiaBIeziXdlbKGjEo = P_1;
			return jwsvIzegJVAbHLFLqDmUpHROYgZ2;
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

	private TnbctswGyXOsohdhCkTtNqIlEbQG gBFcFEjcuYMKWkPeeMELlKKAWMAI;

	private List<UarCymSBEKuIcmOWvaMIzilEuIM> WEuHIpAYAmfrlFuzqsSpOYLelMz;

	private int tElQBcMFfTokTSGpOCgJUghpIgcJ;

	private eZqnHLQqpFsiyxjHfkpdhbbdZRW RafIJEjRPcZZJNODanhvgJXwSAct;

	private bool uKjdesFqmBuDurBLcVlbnghPaWx;

	private TimerRealTime RDcQyMEdXmKzMILKWClGmenXmfM;

	private global::TUExllOFrNiCflNptTwhTfgfIzgh<bool> FpqIPSroXiuEZNqFOOfQuzbmgmB;

	private global::TUExllOFrNiCflNptTwhTfgfIzgh<bool> qrWkihqzKfQCChINMfqVmAeIlfB;

	private int npcgkDhYYesDkWeLbvcfIoYRvJsS;

	private int ITbEEkSZzskfOmplYHHhWPYiAtm;

	private ConfigVars KwfsfhlcXHbtZqDWjONkwMwRzFn;

	private bool wYPAnAmOAglaNAsIippUdzhQMob;

	private Action<int, ControllerDataUpdater> WmFnGJiLKLAaRkIIWsgqhlsBheL;

	private PlatformInputManager ObhiZaVIPxECrBbksWjAaFTwhIWj;

	private readonly TaAHjLoGaYExvekcumBiOQzAKKnf AgZCefenyYrqACVjBGoNDGBkuO;

	private readonly rzBAKwBWKxcqQDABpdzeUuBgNqWX JFPJEvGQXgjhuPYfSdtrBTFqwuN;

	private readonly bool tzYHxRnlzOrnlnzshpfccGilhLX;

	private readonly bool JtjQTORvuooIOWTuKIJSajqliWY;

	private readonly bool ukIkfFWACDFFXBsntvhnwgCRpQh;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

	private readonly Func<int> soqxPQhwIsLUZvHgdWElDYIwuLk;

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
	public override IInputSource inputSource => gBFcFEjcuYMKWkPeeMELlKKAWMAI;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.RawInput;

	public NXzLgwiThumaVjwcRJfjteRXIcP(ConfigVars configVars, bool useXInput, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard, bool useCustomDrivers)
	{
		try
		{
			KwfsfhlcXHbtZqDWjONkwMwRzFn = configVars;
			wYPAnAmOAglaNAsIippUdzhQMob = useXInput;
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			soqxPQhwIsLUZvHgdWElDYIwuLk = getNewJoystickId;
			tzYHxRnlzOrnlnzshpfccGilhLX = handleJoysticks;
			JtjQTORvuooIOWTuKIJSajqliWY = handleUnifiedMouse;
			ukIkfFWACDFFXBsntvhnwgCRpQh = handleUnifiedKeyboard;
			ObhiZaVIPxECrBbksWjAaFTwhIWj = this;
			UpdateLoopSetting updateLoop = configVars.updateLoop;
			if (handleUnifiedKeyboard)
			{
				JFPJEvGQXgjhuPYfSdtrBTFqwuN = new rzBAKwBWKxcqQDABpdzeUuBgNqWX(updateLoop);
			}
			if (handleUnifiedMouse)
			{
				AgZCefenyYrqACVjBGoNDGBkuO = new TaAHjLoGaYExvekcumBiOQzAKKnf(updateLoop);
			}
			gBFcFEjcuYMKWkPeeMELlKKAWMAI = new TnbctswGyXOsohdhCkTtNqIlEbQG(configVars, handleJoysticks, useCustomDrivers, AgZCefenyYrqACVjBGoNDGBkuO, JFPJEvGQXgjhuPYfSdtrBTFqwuN);
			WmFnGJiLKLAaRkIIWsgqhlsBheL = UpdateControllerData;
			FpqIPSroXiuEZNqFOOfQuzbmgmB = new global::TUExllOFrNiCflNptTwhTfgfIzgh<bool>(useSharedThread: true, VMtEQWtzyAGQAnUhFnHPzvdEAKR);
			qrWkihqzKfQCChINMfqVmAeIlfB = new global::TUExllOFrNiCflNptTwhTfgfIzgh<bool>(useSharedThread: true, gBFcFEjcuYMKWkPeeMELlKKAWMAI.KKxAHhSKkINjxsYIxciKdvSYHuM);
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
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			RafIJEjRPcZZJNODanhvgJXwSAct = new eZqnHLQqpFsiyxjHfkpdhbbdZRW();
			RDcQyMEdXmKzMILKWClGmenXmfM = new TimerRealTime(1.0);
			RDcQyMEdXmKzMILKWClGmenXmfM.Start();
			EktqiUtNzhGtDEvBWqSqxRUocww();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			CIQmbedndYaSXuZDlHeLgVuLtzC();
		}
		if (gBFcFEjcuYMKWkPeeMELlKKAWMAI != null)
		{
			gBFcFEjcuYMKWkPeeMELlKKAWMAI.Update();
		}
		drlGQhPFmrgnVfDLWpowhypNphYM();
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			if (gBFcFEjcuYMKWkPeeMELlKKAWMAI != null)
			{
				gBFcFEjcuYMKWkPeeMELlKKAWMAI.UpdateDevices(updateLoop);
			}
			vKWUwPqagUZSjOHDZUpalOcMgaf();
			if (gBFcFEjcuYMKWkPeeMELlKKAWMAI != null)
			{
				gBFcFEjcuYMKWkPeeMELlKKAWMAI.UpdateFinished();
			}
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			AgZCefenyYrqACVjBGoNDGBkuO.CWncwVbJhTWISMonvIVEimpDcKXc(updateLoop);
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			JFPJEvGQXgjhuPYfSdtrBTFqwuN.CWncwVbJhTWISMonvIVEimpDcKXc(updateLoop);
		}
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
		if (WEuHIpAYAmfrlFuzqsSpOYLelMz != null)
		{
			int count = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
			for (int i = 0; i < count; i++)
			{
				if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null)
				{
					WEuHIpAYAmfrlFuzqsSpOYLelMz[i].LLOFbzNISIbRkZTwkaVnsPpYig();
				}
			}
		}
		if (JFPJEvGQXgjhuPYfSdtrBTFqwuN != null)
		{
			JFPJEvGQXgjhuPYfSdtrBTFqwuN.Dispose();
		}
		if (AgZCefenyYrqACVjBGoNDGBkuO != null)
		{
			AgZCefenyYrqACVjBGoNDGBkuO.Dispose();
		}
		if (gBFcFEjcuYMKWkPeeMELlKKAWMAI != null)
		{
			gBFcFEjcuYMKWkPeeMELlKKAWMAI.Dispose();
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
		if (!tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			return;
		}
		for (int i = 0; i < tElQBcMFfTokTSGpOCgJUghpIgcJ; i++)
		{
			if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i].inputManagerId == inputManagerId)
			{
				WEuHIpAYAmfrlFuzqsSpOYLelMz[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		gBFcFEjcuYMKWkPeeMELlKKAWMAI.SystemDeviceConnected();
		uKjdesFqmBuDurBLcVlbnghPaWx = true;
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			JFPJEvGQXgjhuPYfSdtrBTFqwuN.EOfLvZeQNqcczljjrXLbjGczkeD(true);
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			AgZCefenyYrqACVjBGoNDGBkuO.EOfLvZeQNqcczljjrXLbjGczkeD(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		gBFcFEjcuYMKWkPeeMELlKKAWMAI.SystemDeviceDisconnected();
		uKjdesFqmBuDurBLcVlbnghPaWx = true;
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			RDcQyMEdXmKzMILKWClGmenXmfM.Start();
		}
		if (ukIkfFWACDFFXBsntvhnwgCRpQh)
		{
			JFPJEvGQXgjhuPYfSdtrBTFqwuN.EOfLvZeQNqcczljjrXLbjGczkeD(false);
		}
		if (JtjQTORvuooIOWTuKIJSajqliWY)
		{
			AgZCefenyYrqACVjBGoNDGBkuO.EOfLvZeQNqcczljjrXLbjGczkeD(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = tzYHxRnlzOrnlnzshpfccGilhLX;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return AgZCefenyYrqACVjBGoNDGBkuO;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return JFPJEvGQXgjhuPYfSdtrBTFqwuN;
	}

	public void VGGcjEuuHiPXlUAUUbkEZBCKiyhH(EHIlksBYwvRxwUuMUPpiqnChUPW P_0, NgzvGfQDisRTGMKXwIDhsRJTBuE P_1)
	{
	}

	private void CIQmbedndYaSXuZDlHeLgVuLtzC()
	{
		if (FpqIPSroXiuEZNqFOOfQuzbmgmB.isRunning)
		{
			if (FpqIPSroXiuEZNqFOOfQuzbmgmB.lVgWjrQkCsFlsaFVzSjplyEWLEJg() && !RDcQyMEdXmKzMILKWClGmenXmfM.running && !qrWkihqzKfQCChINMfqVmAeIlfB.isRunning)
			{
				if (FpqIPSroXiuEZNqFOOfQuzbmgmB.result)
				{
					uKjdesFqmBuDurBLcVlbnghPaWx = true;
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

	private void EktqiUtNzhGtDEvBWqSqxRUocww()
	{
		EktqiUtNzhGtDEvBWqSqxRUocww(PNrRpPgZEQCSGmTwYNIjgkgtssI());
	}

	private void EktqiUtNzhGtDEvBWqSqxRUocww(IList<UzKBIaEyudSpXeLmfwTkGCYvktG> P_0)
	{
		int num = 0;
		List<UarCymSBEKuIcmOWvaMIzilEuIM> wEuHIpAYAmfrlFuzqsSpOYLelMz = WEuHIpAYAmfrlFuzqsSpOYLelMz;
		int num2 = tElQBcMFfTokTSGpOCgJUghpIgcJ;
		WEuHIpAYAmfrlFuzqsSpOYLelMz = new List<UarCymSBEKuIcmOWvaMIzilEuIM>();
		npcgkDhYYesDkWeLbvcfIoYRvJsS = 0;
		List<UarCymSBEKuIcmOWvaMIzilEuIM> list = new List<UarCymSBEKuIcmOWvaMIzilEuIM>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (wEuHIpAYAmfrlFuzqsSpOYLelMz[num3] != null && !wEuHIpAYAmfrlFuzqsSpOYLelMz[num3].IsValid)
			{
				list.Add(wEuHIpAYAmfrlFuzqsSpOYLelMz[num3]);
				wEuHIpAYAmfrlFuzqsSpOYLelMz.RemoveAt(num3);
			}
		}
		num2 = wEuHIpAYAmfrlFuzqsSpOYLelMz?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			UzKBIaEyudSpXeLmfwTkGCYvktG uzKBIaEyudSpXeLmfwTkGCYvktG = P_0[i];
			if (uzKBIaEyudSpXeLmfwTkGCYvktG != null)
			{
				UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = new UarCymSBEKuIcmOWvaMIzilEuIM(uzKBIaEyudSpXeLmfwTkGCYvktG, uzKBIaEyudSpXeLmfwTkGCYvktG.DeviceType, bKHIVnLAXWYbMiOIyqMJrMzriBW);
				uarCymSBEKuIcmOWvaMIzilEuIM.ypBhwPylZXgbWvdXwgdHvTJZNDf = uzKBIaEyudSpXeLmfwTkGCYvktG.InstanceGuid;
				uarCymSBEKuIcmOWvaMIzilEuIM.kxKCChAepXZZMUCPgfBLnfqoDYsI = uzKBIaEyudSpXeLmfwTkGCYvktG.ProductName;
				uarCymSBEKuIcmOWvaMIzilEuIM.IBLmgPovQLSZcNmAXhMIAhsmJVX = uzKBIaEyudSpXeLmfwTkGCYvktG.ProductName;
				uarCymSBEKuIcmOWvaMIzilEuIM.giPzSxcdmJFlxkpGRptEQPgrFzn = uzKBIaEyudSpXeLmfwTkGCYvktG.ProductGuid;
				uarCymSBEKuIcmOWvaMIzilEuIM.hhkcLloTZcVDgCdaTwOpzCelsoR = uzKBIaEyudSpXeLmfwTkGCYvktG.ProductId;
				uarCymSBEKuIcmOWvaMIzilEuIM.HgIEIMWSDaFhIGVwBNVWCVPHunvR = uzKBIaEyudSpXeLmfwTkGCYvktG.VendorId;
				uarCymSBEKuIcmOWvaMIzilEuIM.oidArcJIfGQvDhinAUSWvxCbFPQc = uzKBIaEyudSpXeLmfwTkGCYvktG.JoystickId;
				uarCymSBEKuIcmOWvaMIzilEuIM.tsubhXPAkivKUjJndgFvgCYtCih = uzKBIaEyudSpXeLmfwTkGCYvktG.AxisCount;
				uarCymSBEKuIcmOWvaMIzilEuIM.uELhfbdZYGHumCLLdtArLMIvIGxA = uzKBIaEyudSpXeLmfwTkGCYvktG.ButtonCount;
				uarCymSBEKuIcmOWvaMIzilEuIM.ZjLWaiKAEkbMVYsMXPeYLhgiSLG = uzKBIaEyudSpXeLmfwTkGCYvktG.HatCount;
				uarCymSBEKuIcmOWvaMIzilEuIM.wTIUKRsZMOmpZhNBlfPZhbzhGk = false;
				uarCymSBEKuIcmOWvaMIzilEuIM.TIjeAxRHlSqfwwEReELjSBfzpeh = uzKBIaEyudSpXeLmfwTkGCYvktG.IsBluetoothDevice;
				uarCymSBEKuIcmOWvaMIzilEuIM.BDNzUFwhASNOsMHGagnuFDeiUNc = uzKBIaEyudSpXeLmfwTkGCYvktG.BluetoothDeviceName;
				uarCymSBEKuIcmOWvaMIzilEuIM.wAZMpcjYCVAzjJccPAzohypyqPYD = uzKBIaEyudSpXeLmfwTkGCYvktG.SupportsVibration;
				uarCymSBEKuIcmOWvaMIzilEuIM.lpBHnYIqUEtJizBVtebuWwTDdFle = uzKBIaEyudSpXeLmfwTkGCYvktG.VibrationMotorCount;
				uarCymSBEKuIcmOWvaMIzilEuIM.extension = uzKBIaEyudSpXeLmfwTkGCYvktG.ControllerExtension;
				uzKBIaEyudSpXeLmfwTkGCYvktG.QqViEWwhZaWrvATfPuWfqnkWwbi();
				uarCymSBEKuIcmOWvaMIzilEuIM.awLKiXcoOFmnokthljbUZIrPZrq();
				WEuHIpAYAmfrlFuzqsSpOYLelMz.Add(uarCymSBEKuIcmOWvaMIzilEuIM);
				num++;
				if (uarCymSBEKuIcmOWvaMIzilEuIM.TIjeAxRHlSqfwwEReELjSBfzpeh)
				{
					npcgkDhYYesDkWeLbvcfIoYRvJsS++;
				}
			}
		}
		tElQBcMFfTokTSGpOCgJUghpIgcJ = num;
		KwmkxSzomVumQegjajVmZlHmThQ(num2, num, wEuHIpAYAmfrlFuzqsSpOYLelMz, WEuHIpAYAmfrlFuzqsSpOYLelMz);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(WEuHIpAYAmfrlFuzqsSpOYLelMz[j]));
			}
		}
		list.ForEach(delegate(UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM2)
		{
			bGZMnrEUihehhlqffgHFcHUJpbf(uarCymSBEKuIcmOWvaMIzilEuIM2, false);
		});
		ZmlQXVOFofpsuUZXWFZOUlSkSAt(wEuHIpAYAmfrlFuzqsSpOYLelMz, WEuHIpAYAmfrlFuzqsSpOYLelMz, false);
		ZmlQXVOFofpsuUZXWFZOUlSkSAt(WEuHIpAYAmfrlFuzqsSpOYLelMz, wEuHIpAYAmfrlFuzqsSpOYLelMz, true);
	}

	private void vKWUwPqagUZSjOHDZUpalOcMgaf()
	{
		for (int i = 0; i < tElQBcMFfTokTSGpOCgJUghpIgcJ; i++)
		{
			UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = WEuHIpAYAmfrlFuzqsSpOYLelMz[i];
			if (uarCymSBEKuIcmOWvaMIzilEuIM != null && (!wYPAnAmOAglaNAsIippUdzhQMob || !uarCymSBEKuIcmOWvaMIzilEuIM.wTIUKRsZMOmpZhNBlfPZhbzhGk))
			{
				uarCymSBEKuIcmOWvaMIzilEuIM.Update();
			}
		}
	}

	private bool YXHHdWXxvTPYwRhsUBWBnayhySV(wwLeoMBCxCEjXPiqztkjGHLruPe P_0)
	{
		try
		{
			return P_0.pstoeMoNzNWOorGnoIUVfChGZNFf();
		}
		catch
		{
			return false;
		}
	}

	private IList<UzKBIaEyudSpXeLmfwTkGCYvktG> PNrRpPgZEQCSGmTwYNIjgkgtssI()
	{
		return gBFcFEjcuYMKWkPeeMELlKKAWMAI.GetJoysticks<UzKBIaEyudSpXeLmfwTkGCYvktG>();
	}

	private void KwmkxSzomVumQegjajVmZlHmThQ(int P_0, int P_1, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_2, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(UarCymSBEKuIcmOWvaMIzilEuIM.CxXDnpMWrnfKMDSwWHTiDGGcTnCF);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			YRoKRRItNDPIoVmafgdCaZmigio(P_1, P_3, P_0, P_2, eZqnHLQqpFsiyxjHfkpdhbbdZRW.zeTkJrQnaflKrnxBzXiEoUXMbKm.jCoiBlfabpaxiBivYEooCEijjotH);
		}
		CukpyZaqCaKrflYIEoAWQuYhhqd(P_1, P_3, eZqnHLQqpFsiyxjHfkpdhbbdZRW.zeTkJrQnaflKrnxBzXiEoUXMbKm.jCoiBlfabpaxiBivYEooCEijjotH);
		for (int i = 0; i < P_1; i++)
		{
			UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = P_3[i];
			if (uarCymSBEKuIcmOWvaMIzilEuIM != null && uarCymSBEKuIcmOWvaMIzilEuIM.inputManagerId < 0)
			{
				uarCymSBEKuIcmOWvaMIzilEuIM.inputManagerId = zwMpiMvmkkdNpwoFkWHdIKVNvMQ(P_3);
				uarCymSBEKuIcmOWvaMIzilEuIM.rewiredId = soqxPQhwIsLUZvHgdWElDYIwuLk();
				RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(uarCymSBEKuIcmOWvaMIzilEuIM);
			}
		}
		P_3.Sort(UarCymSBEKuIcmOWvaMIzilEuIM.QwvSPJxYjPaiiPmCTKmKweDrutf);
	}

	private void jdLAfzORWSzWAULiMkqIyHkZWvG(List<UarCymSBEKuIcmOWvaMIzilEuIM> P_0, int P_1, int P_2)
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

	private bool xKgbnJakGGMPubegxZWtQtwOCOMA(List<UarCymSBEKuIcmOWvaMIzilEuIM> P_0, int P_1)
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

	private int zwMpiMvmkkdNpwoFkWHdIKVNvMQ(List<UarCymSBEKuIcmOWvaMIzilEuIM> P_0)
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

	private bool rZvMgtxFAtHlxYHFeIOxjWvKfXpH(List<UarCymSBEKuIcmOWvaMIzilEuIM> P_0, int P_1)
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

	private void YRoKRRItNDPIoVmafgdCaZmigio(int P_0, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_1, int P_2, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_3, eZqnHLQqpFsiyxjHfkpdhbbdZRW.zeTkJrQnaflKrnxBzXiEoUXMbKm P_4)
	{
		int num = ((P_4 != eZqnHLQqpFsiyxjHfkpdhbbdZRW.zeTkJrQnaflKrnxBzXiEoUXMbKm.jCoiBlfabpaxiBivYEooCEijjotH) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = P_1[i];
			if (uarCymSBEKuIcmOWvaMIzilEuIM == null || uarCymSBEKuIcmOWvaMIzilEuIM.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM2 = P_3[j];
				if (uarCymSBEKuIcmOWvaMIzilEuIM2 != null && !rZvMgtxFAtHlxYHFeIOxjWvKfXpH(P_1, uarCymSBEKuIcmOWvaMIzilEuIM2.rewiredId) && uarCymSBEKuIcmOWvaMIzilEuIM.KyAfiLYcJFhJNpOgrDEhxwnhNoD(uarCymSBEKuIcmOWvaMIzilEuIM2) >= num)
				{
					uarCymSBEKuIcmOWvaMIzilEuIM.eaxwcXMwRKCkmHbjLyonEghfcUhe(uarCymSBEKuIcmOWvaMIzilEuIM2);
					RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(uarCymSBEKuIcmOWvaMIzilEuIM);
				}
			}
		}
	}

	private void CukpyZaqCaKrflYIEoAWQuYhhqd(int P_0, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_1, eZqnHLQqpFsiyxjHfkpdhbbdZRW.zeTkJrQnaflKrnxBzXiEoUXMbKm P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = P_1[i];
			if (uarCymSBEKuIcmOWvaMIzilEuIM == null || uarCymSBEKuIcmOWvaMIzilEuIM.inputManagerId >= 0)
			{
				continue;
			}
			eZqnHLQqpFsiyxjHfkpdhbbdZRW.muzGKpSLiaiIwPFIvDaPjcxstwN muzGKpSLiaiIwPFIvDaPjcxstwN = null;
			foreach (eZqnHLQqpFsiyxjHfkpdhbbdZRW.muzGKpSLiaiIwPFIvDaPjcxstwN item in RafIJEjRPcZZJNODanhvgJXwSAct.crTEwBjpShikeXLaYUTdOaoyQQJ(uarCymSBEKuIcmOWvaMIzilEuIM, P_2))
			{
				if (!rZvMgtxFAtHlxYHFeIOxjWvKfXpH(P_1, item.IarEMbMqzCAYwlSQGSgLyHgrWQw) && item.StNvaEdPkeHdOVPfOWiyBYqIBZC >= 0)
				{
					muzGKpSLiaiIwPFIvDaPjcxstwN = item;
					break;
				}
			}
			if (muzGKpSLiaiIwPFIvDaPjcxstwN != null)
			{
				int num = muzGKpSLiaiIwPFIvDaPjcxstwN.StNvaEdPkeHdOVPfOWiyBYqIBZC;
				if (!xKgbnJakGGMPubegxZWtQtwOCOMA(P_1, num))
				{
					num = (muzGKpSLiaiIwPFIvDaPjcxstwN.StNvaEdPkeHdOVPfOWiyBYqIBZC = zwMpiMvmkkdNpwoFkWHdIKVNvMQ(P_1));
				}
				uarCymSBEKuIcmOWvaMIzilEuIM.inputManagerId = num;
				uarCymSBEKuIcmOWvaMIzilEuIM.rewiredId = muzGKpSLiaiIwPFIvDaPjcxstwN.IarEMbMqzCAYwlSQGSgLyHgrWQw;
				RafIJEjRPcZZJNODanhvgJXwSAct.xgVDvWMPwGSwXsgsVGmvrCGbsMR(uarCymSBEKuIcmOWvaMIzilEuIM);
			}
		}
	}

	private void drlGQhPFmrgnVfDLWpowhypNphYM()
	{
		if (gBFcFEjcuYMKWkPeeMELlKKAWMAI.MLVEEFCtQzFVqsWSDKGUEGnjjnWV(true))
		{
			uKjdesFqmBuDurBLcVlbnghPaWx = true;
		}
		if (uKjdesFqmBuDurBLcVlbnghPaWx)
		{
			nPekbCsGHMdrESpTZGvjprQDdpT();
		}
		if (tzYHxRnlzOrnlnzshpfccGilhLX && qrWkihqzKfQCChINMfqVmAeIlfB.isRunning && qrWkihqzKfQCChINMfqVmAeIlfB.lVgWjrQkCsFlsaFVzSjplyEWLEJg())
		{
			GntxwHbSvkdKZVqZrEXWzBoLwgM();
		}
	}

	private void nPekbCsGHMdrESpTZGvjprQDdpT()
	{
		uKjdesFqmBuDurBLcVlbnghPaWx = false;
		if (!qrWkihqzKfQCChINMfqVmAeIlfB.isRunning)
		{
			gBFcFEjcuYMKWkPeeMELlKKAWMAI.BmLXWuFfjXVDGDnTVJCtqjwhrdz();
			qrWkihqzKfQCChINMfqVmAeIlfB.UyHkmeYMKxbRaLGZZmHNfcnwklW();
		}
	}

	private void GntxwHbSvkdKZVqZrEXWzBoLwgM()
	{
		gBFcFEjcuYMKWkPeeMELlKKAWMAI.yuBsGanGpqqzptceTaJAiCPaLrkD();
		if (tzYHxRnlzOrnlnzshpfccGilhLX)
		{
			IList<UzKBIaEyudSpXeLmfwTkGCYvktG> list = PNrRpPgZEQCSGmTwYNIjgkgtssI();
			if (xpwTkcFvimSLOfpOpgTZDXMIVrrj(list))
			{
				EktqiUtNzhGtDEvBWqSqxRUocww(list);
			}
		}
	}

	private bool xpwTkcFvimSLOfpOpgTZDXMIVrrj(IList<UzKBIaEyudSpXeLmfwTkGCYvktG> P_0)
	{
		for (int i = 0; i < WEuHIpAYAmfrlFuzqsSpOYLelMz.Count; i++)
		{
			if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null && !WEuHIpAYAmfrlFuzqsSpOYLelMz[i].IsValid)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !czJBvlfxhCiJqbFVedmVBFfpdTE(P_0[j].InstanceGuid))
			{
				return true;
			}
		}
		int count2 = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
		for (int k = 0; k < count2; k++)
		{
			if (WEuHIpAYAmfrlFuzqsSpOYLelMz[k] != null && !PwBwoOjLHcxUOJjuFAJtJZzDlnn(P_0, WEuHIpAYAmfrlFuzqsSpOYLelMz[k].instanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	private bool czJBvlfxhCiJqbFVedmVBFfpdTE(Guid P_0)
	{
		int count = WEuHIpAYAmfrlFuzqsSpOYLelMz.Count;
		for (int i = 0; i < count; i++)
		{
			if (WEuHIpAYAmfrlFuzqsSpOYLelMz[i] != null && WEuHIpAYAmfrlFuzqsSpOYLelMz[i].instanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool PwBwoOjLHcxUOJjuFAJtJZzDlnn(IList<UzKBIaEyudSpXeLmfwTkGCYvktG> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].InstanceGuid == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ZmlQXVOFofpsuUZXWFZOUlSkSAt(List<UarCymSBEKuIcmOWvaMIzilEuIM> P_0, List<UarCymSBEKuIcmOWvaMIzilEuIM> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM = P_0[i];
			if (uarCymSBEKuIcmOWvaMIzilEuIM == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					UarCymSBEKuIcmOWvaMIzilEuIM uarCymSBEKuIcmOWvaMIzilEuIM2 = P_1[j];
					if (uarCymSBEKuIcmOWvaMIzilEuIM2 != null && uarCymSBEKuIcmOWvaMIzilEuIM.instanceGuid == uarCymSBEKuIcmOWvaMIzilEuIM2.instanceGuid)
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

	private void bGZMnrEUihehhlqffgHFcHUJpbf(UarCymSBEKuIcmOWvaMIzilEuIM P_0, bool P_1)
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
		try
		{
			int num = 0;
			mAgjioNWilhSVagqLOEzscTnDyYo.HdDWzONQvcthSwCYPgLtEpUHQDZ(null, ref num, QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<LNHvDvYjaclMyuJxhDyrbuVyHQyf>());
			if (ITbEEkSZzskfOmplYHHhWPYiAtm != num)
			{
				ITbEEkSZzskfOmplYHHhWPYiAtm = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (npcgkDhYYesDkWeLbvcfIoYRvJsS > 0 && gBFcFEjcuYMKWkPeeMELlKKAWMAI.owfpfzaklbjNBPVhNVwCfhVyUWS())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void FJIcWmWzRBcerVUFofxYfXyRAXG(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void enSzXuzCwcePlbTXmDQOOSDjFOGA(UarCymSBEKuIcmOWvaMIzilEuIM P_0)
	{
		bGZMnrEUihehhlqffgHFcHUJpbf(P_0, false);
	}
}
