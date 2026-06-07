using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.HID;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class jSzyivpKikIcKFnbBCmdglPWWQPZA : PlatformInputManager, gcpwKCRbatOImQkjFmQXegHCctcx
{
	private class PsAnRFoXZVCPLNyfCHpsvaxBALYi : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int RBzddwdezIOCGLcVOVXLLBCXdLWYA;

		private int SyLNldTFLIuFBqlMriAhEwaMjOiIA;

		public Guid EbeNsMHsLcwFxVopnjRKgmXIlXoNA;

		public string XfzSVKGYnoTncrJwgRZnvrUsciYG;

		public readonly LULJRRBiGsDrlsRcrtYctFCnDxsN VYaelqDNEmXCfBgvJjdzbdadDIuRA;

		public zxeoTygAWuodzEbOIdaTbdNJPkfzA aTEvJQQIXHoKGgRYSQwnGWuPFGdI;

		public VAaoGYMiyFsYsJBkYQMoTZOXkiKl PEPBYDGdMlEwryRdTGvJmyPGKyUQA;

		public string dQQTAPdrLnlKYtSrjLzKSAQsJSZL;

		public string rcXDaYwMeEKknjayUvhpiJxBCkZfA;

		public int gaidNLKjVNzSYwWLCQLULHEOfeOBA;

		public Guid ftGGzFdLlvwNxVfadmUwEEKGDIofB;

		public Guid BYexPClfKRemOAfJoRPKlNvaqNAn;

		public Guid ZJCbKwIgkEiHAvPpRLVvZRvobdViA;

		public int MVbWGHQqbzXxpRXAUQjpHdBpxZFl;

		public bool IXjcVnIzVMMzTvZRvUGeXRorqgTL;

		public string ucgaIHHkOUiZHiAciGsosMzLxKYE;

		public string zSfgsHFwqDLSOUcFoBPkIZzvkNYq;

		public int gAFFBuafFJZuitBmqUkycmUzpRyzA;

		public int QRWGWCljFeAgojwRdAlxXRkInxqDb;

		public int qKjzDhbAFLatokrBnyHFMHppIdWvA;

		public int AqNmTzfrngcvaftwUChjtBJNSNBn;

		public int mGMdnbwkuHlLZnTozAwGpzOZilLg;

		public bool ybJaHfSbxtHAQOPHOmHRBFYhFnzT;

		private float[] dOKDzidbfTAhUHUjgtuEWpKJjVtGc;

		private bool[] HmlSVfuvVueypAPYyzEoVXThwuBg;

		private HardwareJoystickMap_InputManager UWgIAIwCDQOBecLowdbqTUqjdWhr;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> pNGFytlpCVHIetJHkhANdMbvFKBJb;

		private bool WSWllHNHfhjDjFwUVJOpMBigJQxp;

		private bool AZWOhpaoMhOeHnbGIHPKiEdhVNyDA;

		private bool YAIRCKXaEEaJndAJrMAyjZswIVRBb;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return RBzddwdezIOCGLcVOVXLLBCXdLWYA;
			}
			set
			{
				RBzddwdezIOCGLcVOVXLLBCXdLWYA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return SyLNldTFLIuFBqlMriAhEwaMjOiIA;
			}
			set
			{
				SyLNldTFLIuFBqlMriAhEwaMjOiIA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (XfzSVKGYnoTncrJwgRZnvrUsciYG != "Unknown Controller")
				{
					return XfzSVKGYnoTncrJwgRZnvrUsciYG;
				}
				if (IXjcVnIzVMMzTvZRvUGeXRorqgTL && !string.IsNullOrEmpty(ucgaIHHkOUiZHiAciGsosMzLxKYE))
				{
					return ucgaIHHkOUiZHiAciGsosMzLxKYE;
				}
				return rcXDaYwMeEKknjayUvhpiJxBCkZfA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (SyLNldTFLIuFBqlMriAhEwaMjOiIA < 0)
				{
					return null;
				}
				return SyLNldTFLIuFBqlMriAhEwaMjOiIA;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => ftGGzFdLlvwNxVfadmUwEEKGDIofB;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

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

		public PsAnRFoXZVCPLNyfCHpsvaxBALYi(LULJRRBiGsDrlsRcrtYctFCnDxsN P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			VYaelqDNEmXCfBgvJjdzbdadDIuRA = P_0;
			pNGFytlpCVHIetJHkhANdMbvFKBJb = P_1;
			SyLNldTFLIuFBqlMriAhEwaMjOiIA = -1;
			RBzddwdezIOCGLcVOVXLLBCXdLWYA = -1;
		}

		public void HhrivJUWWCRRugasimAoQeqKwSMR()
		{
			string text = rcXDaYwMeEKknjayUvhpiJxBCkZfA;
			Guid bYexPClfKRemOAfJoRPKlNvaqNAn = BYexPClfKRemOAfJoRPKlNvaqNAn;
			ZJCbKwIgkEiHAvPpRLVvZRvobdViA = MiscTools.CreateGuidHashSHA1(text + bYexPClfKRemOAfJoRPKlNvaqNAn.ToString());
			gAFFBuafFJZuitBmqUkycmUzpRyzA = qKjzDhbAFLatokrBnyHFMHppIdWvA;
			QRWGWCljFeAgojwRdAlxXRkInxqDb = AqNmTzfrngcvaftwUChjtBJNSNBn + mGMdnbwkuHlLZnTozAwGpzOZilLg * 8;
			UsebakTwoRWNVDckGAwaYDrbhagcA();
			EbeNsMHsLcwFxVopnjRKgmXIlXoNA = UWgIAIwCDQOBecLowdbqTUqjdWhr.hardwareMapIdentifier.guid;
			XfzSVKGYnoTncrJwgRZnvrUsciYG = UWgIAIwCDQOBecLowdbqTUqjdWhr.controllerName;
			WSWllHNHfhjDjFwUVJOpMBigJQxp = ((EbeNsMHsLcwFxVopnjRKgmXIlXoNA == Guid.Empty) ? true : false);
			dOKDzidbfTAhUHUjgtuEWpKJjVtGc = new float[gAFFBuafFJZuitBmqUkycmUzpRyzA];
			HmlSVfuvVueypAPYyzEoVXThwuBg = new bool[QRWGWCljFeAgojwRdAlxXRkInxqDb];
			VYaelqDNEmXCfBgvJjdzbdadDIuRA.YCeXTnKtMOGqGXGLRghdcBuFuBiQ();
			Update();
		}

		public void ZwsMLhHdBEuPStOfGgjZwDhTWuJr(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0)
		{
			if (P_0 != null)
			{
				SyLNldTFLIuFBqlMriAhEwaMjOiIA = P_0.SyLNldTFLIuFBqlMriAhEwaMjOiIA;
				RBzddwdezIOCGLcVOVXLLBCXdLWYA = P_0.RBzddwdezIOCGLcVOVXLLBCXdLWYA;
				for (int i = 0; i < MathTools.Min(HmlSVfuvVueypAPYyzEoVXThwuBg.Length, P_0.HmlSVfuvVueypAPYyzEoVXThwuBg.Length); i++)
				{
					HmlSVfuvVueypAPYyzEoVXThwuBg[i] = P_0.HmlSVfuvVueypAPYyzEoVXThwuBg[i];
				}
				for (int j = 0; j < MathTools.Min(dOKDzidbfTAhUHUjgtuEWpKJjVtGc.Length, P_0.dOKDzidbfTAhUHUjgtuEWpKJjVtGc.Length); j++)
				{
					dOKDzidbfTAhUHUjgtuEWpKJjVtGc[j] = P_0.dOKDzidbfTAhUHUjgtuEWpKJjVtGc[j];
				}
				AZWOhpaoMhOeHnbGIHPKiEdhVNyDA = P_0.AZWOhpaoMhOeHnbGIHPKiEdhVNyDA;
				VYaelqDNEmXCfBgvJjdzbdadDIuRA.pgjfsoazaOhLHEEefZTqRAHQcYmB(P_0.VYaelqDNEmXCfBgvJjdzbdadDIuRA);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			VYaelqDNEmXCfBgvJjdzbdadDIuRA.GSFFceEPpyssQbUhFNpXsePshCuo();
			bool[] array = VYaelqDNEmXCfBgvJjdzbdadDIuRA.tFPTRtOuoLrCjLFGkqZPKpHCTppt;
			int[] uiCCBtBDSGDfxBkqXAFzqPXGKUft = VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.uiCCBtBDSGDfxBkqXAFzqPXGKUft;
			hWtOHkRWRaFFTPMuMUpSPFcugMLJA(array, uiCCBtBDSGDfxBkqXAFzqPXGKUft);
			txCibbfavlKMXWWpeXbXttLFeBMc(array, uiCCBtBDSGDfxBkqXAFzqPXGKUft);
			VYaelqDNEmXCfBgvJjdzbdadDIuRA.WktFJgafJxFFMLMVybYYsJqjoxkLA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (gAFFBuafFJZuitBmqUkycmUzpRyzA != dataUpdater.axisCount || QRWGWCljFeAgojwRdAlxXRkInxqDb != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < gAFFBuafFJZuitBmqUkycmUzpRyzA; i++)
			{
				dataUpdater.axisValues[i] = dOKDzidbfTAhUHUjgtuEWpKJjVtGc[i];
			}
			for (int j = 0; j < QRWGWCljFeAgojwRdAlxXRkInxqDb; j++)
			{
				dataUpdater.buttonValues[j] = HmlSVfuvVueypAPYyzEoVXThwuBg[j];
			}
			if (AZWOhpaoMhOeHnbGIHPKiEdhVNyDA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int kQZmGfRNTYvvoqmpMebThLQvBxDT(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0)
		{
			if (P_0.RBzddwdezIOCGLcVOVXLLBCXdLWYA == RBzddwdezIOCGLcVOVXLLBCXdLWYA)
			{
				return 2;
			}
			if (qKjzDhbAFLatokrBnyHFMHppIdWvA != P_0.qKjzDhbAFLatokrBnyHFMHppIdWvA)
			{
				return 0;
			}
			if (AqNmTzfrngcvaftwUChjtBJNSNBn != P_0.AqNmTzfrngcvaftwUChjtBJNSNBn)
			{
				return 0;
			}
			if (mGMdnbwkuHlLZnTozAwGpzOZilLg != P_0.mGMdnbwkuHlLZnTozAwGpzOZilLg)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.ZJCbKwIgkEiHAvPpRLVvZRvobdViA == ZJCbKwIgkEiHAvPpRLVvZRvobdViA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo PMIFVsAbyqOLOqasTitvtuEFTOZFA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			NVYjIwSGZLZpWXUnznFTGoVesxDI(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			TviFXvHzlrDGhftrGArkAbQKSSHhA(bridgedController);
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
			return new ControllerDisconnectedEventArgs(RBzddwdezIOCGLcVOVXLLBCXdLWYA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool cvuPgZujhYknfDShJxpakTNrocXg()
		{
			try
			{
				VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV.uLewQdxPEwvLSWHogTlvNJfheKyDA();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void IvXrFnuSGPqEKwPNKStDruFGLBml()
		{
			try
			{
				if (VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV != null)
				{
					VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV.AGcUmdNvzDHZZmFwBKCGcWkvflUG();
				}
			}
			catch
			{
			}
		}

		public void kRARaCujCWgsRFwgmdwjleyRtRCEA()
		{
			try
			{
				if (VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV != null)
				{
					VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV.jTTjSKChCviCLdBVBoGJfznYQoYU();
				}
			}
			catch
			{
			}
		}

		private void hWtOHkRWRaFFTPMuMUpSPFcugMLJA(bool[] P_0, int[] P_1)
		{
			if (gAFFBuafFJZuitBmqUkycmUzpRyzA <= 0)
			{
				return;
			}
			switch (UWgIAIwCDQOBecLowdbqTUqjdWhr.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)UWgIAIwCDQOBecLowdbqTUqjdWhr.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						dWCHTHifUZfNQJnqXuDvBNcJNgwiA(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)UWgIAIwCDQOBecLowdbqTUqjdWhr.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						dWCHTHifUZfNQJnqXuDvBNcJNgwiA(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void txCibbfavlKMXWWpeXbXttLFeBMc(bool[] P_0, int[] P_1)
		{
			if (QRWGWCljFeAgojwRdAlxXRkInxqDb <= 0)
			{
				return;
			}
			switch (UWgIAIwCDQOBecLowdbqTUqjdWhr.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)UWgIAIwCDQOBecLowdbqTUqjdWhr.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						InMxsVmLQRDEdWWLKAutQtoJsKtP(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)UWgIAIwCDQOBecLowdbqTUqjdWhr.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						InMxsVmLQRDEdWWLKAutQtoJsKtP(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void dWCHTHifUZfNQJnqXuDvBNcJNgwiA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= gAFFBuafFJZuitBmqUkycmUzpRyzA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			dOKDzidbfTAhUHUjgtuEWpKJjVtGc[P_1] = hcdGIOdWKCnEBEZOkniPWkTeRbaSA(P_0, P_2, P_3);
			if (!AZWOhpaoMhOeHnbGIHPKiEdhVNyDA && dOKDzidbfTAhUHUjgtuEWpKJjVtGc[P_1] != 0f)
			{
				AZWOhpaoMhOeHnbGIHPKiEdhVNyDA = true;
			}
		}

		private void InMxsVmLQRDEdWWLKAutQtoJsKtP(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= QRWGWCljFeAgojwRdAlxXRkInxqDb)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			HmlSVfuvVueypAPYyzEoVXThwuBg[P_1] = XNvEMHApNQiSkMEUAywVADpWbJtOA(P_0, P_2, P_3);
			if (!AZWOhpaoMhOeHnbGIHPKiEdhVNyDA && HmlSVfuvVueypAPYyzEoVXThwuBg[P_1])
			{
				AZWOhpaoMhOeHnbGIHPKiEdhVNyDA = true;
			}
		}

		private float hcdGIOdWKCnEBEZOkniPWkTeRbaSA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return BIBBjwAzHzBGRfmEIlBJAIUvtUoEA((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= AqNmTzfrngcvaftwUChjtBJNSNBn || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= mGMdnbwkuHlLZnTozAwGpzOZilLg || sourceHat >= 4)
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
					num2 = lCcvREnRSfPUfOSrgRMKwXJjgGQm(num, AxisDirection.Horizontal);
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
					num2 = lCcvREnRSfPUfOSrgRMKwXJjgGQm(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && cZUfZoBWIFOUHdiMaNodjtnPGxFiA(customCalculationSourceData[i], out var item))
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
			return 0f;
		}

		private float BIBBjwAzHzBGRfmEIlBJAIUvtUoEA(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.HtTeZAARtZuwYTCBwAYEHVkwKgie, 
				DirectInputAxis.Y => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.MmfKCRGhNKoOIWVCGDzRhOCKvdcG, 
				DirectInputAxis.Z => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.AkDPSKOAsFmCZsGDvhYGinvlxZFeA, 
				DirectInputAxis.RotationX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.KyJWPPIbnofirnrAlRNFRJSKdzFV, 
				DirectInputAxis.RotationY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.wHYyTbGFSDQlTcrEadQbRiVCyKUi, 
				DirectInputAxis.RotationZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.CttZbqASDHIGXhdHcErKePWazzgx, 
				DirectInputAxis.Slider0 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.sMeqEqXWmbRCXXCJbxJBSwWZigEt[0], 
				DirectInputAxis.Slider1 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.sMeqEqXWmbRCXXCJbxJBSwWZigEt[1], 
				DirectInputAxis.VelocityX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.trPpoXUEDlqqIsixhUZVoXqdsASC, 
				DirectInputAxis.VelocityY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.HiLEnxuQDtjxJGEbXGBuCLLbHIETB, 
				DirectInputAxis.VelocityZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.jSfTesuCyeRuJucBASTSrzeDtxIn, 
				DirectInputAxis.AngularVelocityX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.ygxtyaBLWIRmpKjSrLHcUUcGfwQp, 
				DirectInputAxis.AngularVelocityY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.jzlgCdSLxKGRodkGGGWdsEYnbEcA, 
				DirectInputAxis.AngularVelocityZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.lndAYprTSArMFkSFdKbPIAsZoFwm, 
				DirectInputAxis.VelocitySlider0 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.yrRBVIEGctEiDzfmEBQggujpULnk[0], 
				DirectInputAxis.VelocitySlider1 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.yrRBVIEGctEiDzfmEBQggujpULnk[1], 
				DirectInputAxis.AccelerationX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.rGCnwFlKkncqxhkmYHAvhWeQBMLUA, 
				DirectInputAxis.AccelerationY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.LRjCppihIMOekaTAIhJLtYNWarjG, 
				DirectInputAxis.AccelerationZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.UBPJGLZPYubeWJpzhfsTmbpZUBlsA, 
				DirectInputAxis.AngularAccelerationX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.zeuMUYmqzqVpyKHKRNftzWLnzzjj, 
				DirectInputAxis.AngularAccelerationY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.fPDgQnaEcKZawEqgUoqcwuBFlDsS, 
				DirectInputAxis.AngularAccelerationZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.ClQQjuiHUEYJGPhOzUHNUnIIUoXn, 
				DirectInputAxis.AccelerationSlider0 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.WIGKilZjmjnVpcDHGFFbSetbvuEi[0], 
				DirectInputAxis.AccelerationSlider1 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.WIGKilZjmjnVpcDHGFFbSetbvuEi[1], 
				DirectInputAxis.ForceX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.LltdiWiwscLSwBPmBZefBYFUchZz, 
				DirectInputAxis.ForceY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.foYZLWQOsAnMiBIUFgESfNTnbcyHb, 
				DirectInputAxis.ForceZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.slOwyULWXLSxGHqSAGoXIijQUNzM, 
				DirectInputAxis.TorqueX => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.cxxGVueFdHJlVaQIJPVfwlualqqkb, 
				DirectInputAxis.TorqueY => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.rkAFDlBlFbBkwphcKNDmFuASBfbsA, 
				DirectInputAxis.TorqueZ => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.rwEdfgJcKrJwBSdTfPAbSkMMkLgcA, 
				DirectInputAxis.ForceSlider0 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.rsAkTxCRuHRBJcaKgtZuIbRGQRUu[0], 
				DirectInputAxis.ForceSlider1 => VYaelqDNEmXCfBgvJjdzbdadDIuRA.yTmdkbbKWfKgdvADmcCyjnfPUECfb.rsAkTxCRuHRBJcaKgtZuIbRGQRUu[1], 
				_ => 0f, 
			};
		}

		private bool XNvEMHApNQiSkMEUAywVADpWbJtOA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= AqNmTzfrngcvaftwUChjtBJNSNBn || sourceButton >= 128)
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
				float num = BIBBjwAzHzBGRfmEIlBJAIUvtUoEA((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= mGMdnbwkuHlLZnTozAwGpzOZilLg || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return MZIJykWXSBiWmtjFIiVgoTAGVtUn(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (MUTJsRjpGpMsKQcJRBHShuSehwEl(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (cZUfZoBWIFOUHdiMaNodjtnPGxFiA(customCalculationSourceData[k], out var num2))
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

		private bool MZIJykWXSBiWmtjFIiVgoTAGVtUn(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (UWgIAIwCDQOBecLowdbqTUqjdWhr.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float lCcvREnRSfPUfOSrgRMKwXJjgGQm(int P_0, AxisDirection P_1)
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

		private bool MUTJsRjpGpMsKQcJRBHShuSehwEl(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= AqNmTzfrngcvaftwUChjtBJNSNBn || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool cZUfZoBWIFOUHdiMaNodjtnPGxFiA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = BIBBjwAzHzBGRfmEIlBJAIUvtUoEA((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType HoRYfvqnpWcZJCCdqBUaKkWFqZlbb(VAaoGYMiyFsYsJBkYQMoTZOXkiKl P_0)
		{
			return P_0 switch
			{
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Keyboard => ControlDeviceType.Keyboard, 
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Joystick => ControlDeviceType.Joystick, 
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Gamepad => ControlDeviceType.Gamepad, 
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Mouse => ControlDeviceType.Mouse, 
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Flight => ControlDeviceType.Flight, 
				VAaoGYMiyFsYsJBkYQMoTZOXkiKl.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void UsebakTwoRWNVDckGAwaYDrbhagcA()
		{
			UWgIAIwCDQOBecLowdbqTUqjdWhr = pNGFytlpCVHIetJHkhANdMbvFKBJb(PMIFVsAbyqOLOqasTitvtuEFTOZFA());
			if (UWgIAIwCDQOBecLowdbqTUqjdWhr == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			gAFFBuafFJZuitBmqUkycmUzpRyzA = UWgIAIwCDQOBecLowdbqTUqjdWhr.axisCount;
			QRWGWCljFeAgojwRdAlxXRkInxqDb = UWgIAIwCDQOBecLowdbqTUqjdWhr.buttonCount;
		}

		private void IXuXFSTIzbGoZBweKXiWdixlzqnvA()
		{
		}

		private string CGpqfSnNzgHZpPLtwpzmUzZImcHR()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.DirectInput}{((IXjcVnIzVMMzTvZRvUGeXRorqgTL && !string.IsNullOrEmpty(ucgaIHHkOUiZHiAciGsosMzLxKYE)) ? ucgaIHHkOUiZHiAciGsosMzLxKYE : rcXDaYwMeEKknjayUvhpiJxBCkZfA)}{gaidNLKjVNzSYwWLCQLULHEOfeOBA}{BYexPClfKRemOAfJoRPKlNvaqNAn}");
		}

		private void NVYjIwSGZLZpWXUnznFTGoVesxDI(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = HoRYfvqnpWcZJCCdqBUaKkWFqZlbb(PEPBYDGdMlEwryRdTGvJmyPGKyUQA);
			P_0.hardwareIdentifier = CGpqfSnNzgHZpPLtwpzmUzZImcHR();
			P_0.hardwareAxisCount = qKjzDhbAFLatokrBnyHFMHppIdWvA;
			P_0.hardwareButtonCount = AqNmTzfrngcvaftwUChjtBJNSNBn;
			P_0.hardwareHatCount = mGMdnbwkuHlLZnTozAwGpzOZilLg;
			P_0.hw_productName = rcXDaYwMeEKknjayUvhpiJxBCkZfA;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = gaidNLKjVNzSYwWLCQLULHEOfeOBA;
			P_0.hw_pidVid = new PidVid(BYexPClfKRemOAfJoRPKlNvaqNAn);
			P_0.hw_isBluetoothDevice = IXjcVnIzVMMzTvZRvUGeXRorqgTL;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(ucgaIHHkOUiZHiAciGsosMzLxKYE)) ? ucgaIHHkOUiZHiAciGsosMzLxKYE : string.Empty);
			P_0.definitionMatchTag = zSfgsHFwqDLSOUcFoBPkIZzvkNYq;
		}

		private void TviFXvHzlrDGhftrGArkAbQKSSHhA(BridgedController P_0)
		{
			NVYjIwSGZLZpWXUnznFTGoVesxDI(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = UWgIAIwCDQOBecLowdbqTUqjdWhr.ToGameHardwareControllerMap();
			P_0.instanceName = dQQTAPdrLnlKYtSrjLzKSAQsJSZL;
			P_0.productName = rcXDaYwMeEKknjayUvhpiJxBCkZfA;
			P_0.isXInputDevice = ybJaHfSbxtHAQOPHOmHRBFYhFnzT;
			P_0.axisCount = gAFFBuafFJZuitBmqUkycmUzpRyzA;
			P_0.buttonCount = QRWGWCljFeAgojwRdAlxXRkInxqDb;
			P_0.unknownControllerHats = rAWFHAEKBoBaqmMtlmqNvtGZxAUTA();
			P_0.controllerTypeGuid = EbeNsMHsLcwFxVopnjRKgmXIlXoNA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void FkGhQkUyKILMBjofzCFufaZopaju()
		{
			for (int i = 0; i < QRWGWCljFeAgojwRdAlxXRkInxqDb; i++)
			{
				HmlSVfuvVueypAPYyzEoVXThwuBg[i] = false;
			}
			for (int j = 0; j < gAFFBuafFJZuitBmqUkycmUzpRyzA; j++)
			{
				dOKDzidbfTAhUHUjgtuEWpKJjVtGc[j] = 0f;
			}
		}

		private UnknownControllerHat[] rAWFHAEKBoBaqmMtlmqNvtGZxAUTA()
		{
			if (!WSWllHNHfhjDjFwUVJOpMBigJQxp)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
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
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void QrdMzxiisMRKRsQnktTJMYEFCtxA()
		{
			LblYbHaowhYeCWoyOMatfNxFPDmw(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void CCACHGzkQqbmDcnJYBDDyqFcmajcb()
		{
			try
			{
				LblYbHaowhYeCWoyOMatfNxFPDmw(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void LblYbHaowhYeCWoyOMatfNxFPDmw(bool P_0)
		{
			if (!YAIRCKXaEEaJndAJrMAyjZswIVRBb)
			{
				if (P_0 && VYaelqDNEmXCfBgvJjdzbdadDIuRA != null)
				{
					VYaelqDNEmXCfBgvJjdzbdadDIuRA.Dispose();
				}
				YAIRCKXaEEaJndAJrMAyjZswIVRBb = true;
			}
		}

		public static int cNgCHDAUgptKWybBieteaIwoyxFP(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, PsAnRFoXZVCPLNyfCHpsvaxBALYi P_1)
		{
			if (P_0.SyLNldTFLIuFBqlMriAhEwaMjOiIA < P_1.SyLNldTFLIuFBqlMriAhEwaMjOiIA)
			{
				return -1;
			}
			if (P_0.SyLNldTFLIuFBqlMriAhEwaMjOiIA > P_1.SyLNldTFLIuFBqlMriAhEwaMjOiIA)
			{
				return 1;
			}
			return 0;
		}

		public static int UoCETYGdHhPiZBVSbqPDVgjBllku(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, PsAnRFoXZVCPLNyfCHpsvaxBALYi P_1)
		{
			if (P_0.MVbWGHQqbzXxpRXAUQjpHdBpxZFl < P_1.MVbWGHQqbzXxpRXAUQjpHdBpxZFl)
			{
				return -1;
			}
			if (P_0.MVbWGHQqbzXxpRXAUQjpHdBpxZFl > P_1.MVbWGHQqbzXxpRXAUQjpHdBpxZFl)
			{
				return 1;
			}
			return 0;
		}
	}

	private class LULJRRBiGsDrlsRcrtYctFCnDxsN : IDisposable
	{
		public class phwdNJHNSNtXuAFLbKHkaeJcFgPCB
		{
			public float HtTeZAARtZuwYTCBwAYEHVkwKgie;

			public float MmfKCRGhNKoOIWVCGDzRhOCKvdcG;

			public float AkDPSKOAsFmCZsGDvhYGinvlxZFeA;

			public float KyJWPPIbnofirnrAlRNFRJSKdzFV;

			public float wHYyTbGFSDQlTcrEadQbRiVCyKUi;

			public float CttZbqASDHIGXhdHcErKePWazzgx;

			public float[] sMeqEqXWmbRCXXCJbxJBSwWZigEt;

			public readonly int[] uiCCBtBDSGDfxBkqXAFzqPXGKUft;

			public readonly bool[] TKEUeczYbUwkjpymRRIIeVVKpLlh;

			public float trPpoXUEDlqqIsixhUZVoXqdsASC;

			public float HiLEnxuQDtjxJGEbXGBuCLLbHIETB;

			public float jSfTesuCyeRuJucBASTSrzeDtxIn;

			public float ygxtyaBLWIRmpKjSrLHcUUcGfwQp;

			public float jzlgCdSLxKGRodkGGGWdsEYnbEcA;

			public float lndAYprTSArMFkSFdKbPIAsZoFwm;

			public readonly float[] yrRBVIEGctEiDzfmEBQggujpULnk;

			public float rGCnwFlKkncqxhkmYHAvhWeQBMLUA;

			public float LRjCppihIMOekaTAIhJLtYNWarjG;

			public float UBPJGLZPYubeWJpzhfsTmbpZUBlsA;

			public float zeuMUYmqzqVpyKHKRNftzWLnzzjj;

			public float fPDgQnaEcKZawEqgUoqcwuBFlDsS;

			public float ClQQjuiHUEYJGPhOzUHNUnIIUoXn;

			public readonly float[] WIGKilZjmjnVpcDHGFFbSetbvuEi;

			public float LltdiWiwscLSwBPmBZefBYFUchZz;

			public float foYZLWQOsAnMiBIUFgESfNTnbcyHb;

			public float slOwyULWXLSxGHqSAGoXIijQUNzM;

			public float cxxGVueFdHJlVaQIJPVfwlualqqkb;

			public float rkAFDlBlFbBkwphcKNDmFuASBfbsA;

			public float rwEdfgJcKrJwBSdTfPAbSkMMkLgcA;

			public readonly float[] rsAkTxCRuHRBJcaKgtZuIbRGQRUu;

			public phwdNJHNSNtXuAFLbKHkaeJcFgPCB()
			{
				sMeqEqXWmbRCXXCJbxJBSwWZigEt = new float[2];
				uiCCBtBDSGDfxBkqXAFzqPXGKUft = new int[4];
				TKEUeczYbUwkjpymRRIIeVVKpLlh = new bool[128];
				yrRBVIEGctEiDzfmEBQggujpULnk = new float[2];
				WIGKilZjmjnVpcDHGFFbSetbvuEi = new float[2];
				rsAkTxCRuHRBJcaKgtZuIbRGQRUu = new float[2];
			}

			public void NJfsHsZXVjMwATbBxEYJBhvVJOJjA()
			{
				HtTeZAARtZuwYTCBwAYEHVkwKgie = 0f;
				MmfKCRGhNKoOIWVCGDzRhOCKvdcG = 0f;
				AkDPSKOAsFmCZsGDvhYGinvlxZFeA = 0f;
				KyJWPPIbnofirnrAlRNFRJSKdzFV = 0f;
				wHYyTbGFSDQlTcrEadQbRiVCyKUi = 0f;
				CttZbqASDHIGXhdHcErKePWazzgx = 0f;
				for (int i = 0; i < sMeqEqXWmbRCXXCJbxJBSwWZigEt.Length; i++)
				{
					sMeqEqXWmbRCXXCJbxJBSwWZigEt[i] = 0f;
				}
				for (int j = 0; j < uiCCBtBDSGDfxBkqXAFzqPXGKUft.Length; j++)
				{
					uiCCBtBDSGDfxBkqXAFzqPXGKUft[j] = 0;
				}
				for (int k = 0; k < TKEUeczYbUwkjpymRRIIeVVKpLlh.Length; k++)
				{
					TKEUeczYbUwkjpymRRIIeVVKpLlh[k] = false;
				}
				trPpoXUEDlqqIsixhUZVoXqdsASC = 0f;
				HiLEnxuQDtjxJGEbXGBuCLLbHIETB = 0f;
				jSfTesuCyeRuJucBASTSrzeDtxIn = 0f;
				ygxtyaBLWIRmpKjSrLHcUUcGfwQp = 0f;
				jzlgCdSLxKGRodkGGGWdsEYnbEcA = 0f;
				lndAYprTSArMFkSFdKbPIAsZoFwm = 0f;
				for (int l = 0; l < yrRBVIEGctEiDzfmEBQggujpULnk.Length; l++)
				{
					yrRBVIEGctEiDzfmEBQggujpULnk[l] = 0f;
				}
				rGCnwFlKkncqxhkmYHAvhWeQBMLUA = 0f;
				LRjCppihIMOekaTAIhJLtYNWarjG = 0f;
				UBPJGLZPYubeWJpzhfsTmbpZUBlsA = 0f;
				zeuMUYmqzqVpyKHKRNftzWLnzzjj = 0f;
				fPDgQnaEcKZawEqgUoqcwuBFlDsS = 0f;
				ClQQjuiHUEYJGPhOzUHNUnIIUoXn = 0f;
				for (int m = 0; m < WIGKilZjmjnVpcDHGFFbSetbvuEi.Length; m++)
				{
					WIGKilZjmjnVpcDHGFFbSetbvuEi[m] = 0f;
				}
				LltdiWiwscLSwBPmBZefBYFUchZz = 0f;
				foYZLWQOsAnMiBIUFgESfNTnbcyHb = 0f;
				slOwyULWXLSxGHqSAGoXIijQUNzM = 0f;
				cxxGVueFdHJlVaQIJPVfwlualqqkb = 0f;
				rkAFDlBlFbBkwphcKNDmFuASBfbsA = 0f;
				rwEdfgJcKrJwBSdTfPAbSkMMkLgcA = 0f;
				for (int n = 0; n < rsAkTxCRuHRBJcaKgtZuIbRGQRUu.Length; n++)
				{
					rsAkTxCRuHRBJcaKgtZuIbRGQRUu[n] = 0f;
				}
			}

			public void zwvtzSYStmKKjMmdgabdQHMkpKZH(phwdNJHNSNtXuAFLbKHkaeJcFgPCB P_0)
			{
				HtTeZAARtZuwYTCBwAYEHVkwKgie = P_0.HtTeZAARtZuwYTCBwAYEHVkwKgie;
				MmfKCRGhNKoOIWVCGDzRhOCKvdcG = P_0.MmfKCRGhNKoOIWVCGDzRhOCKvdcG;
				AkDPSKOAsFmCZsGDvhYGinvlxZFeA = P_0.AkDPSKOAsFmCZsGDvhYGinvlxZFeA;
				KyJWPPIbnofirnrAlRNFRJSKdzFV = P_0.KyJWPPIbnofirnrAlRNFRJSKdzFV;
				wHYyTbGFSDQlTcrEadQbRiVCyKUi = P_0.wHYyTbGFSDQlTcrEadQbRiVCyKUi;
				CttZbqASDHIGXhdHcErKePWazzgx = P_0.CttZbqASDHIGXhdHcErKePWazzgx;
				for (int i = 0; i < sMeqEqXWmbRCXXCJbxJBSwWZigEt.Length; i++)
				{
					sMeqEqXWmbRCXXCJbxJBSwWZigEt[i] = P_0.sMeqEqXWmbRCXXCJbxJBSwWZigEt[i];
				}
				for (int j = 0; j < uiCCBtBDSGDfxBkqXAFzqPXGKUft.Length; j++)
				{
					uiCCBtBDSGDfxBkqXAFzqPXGKUft[j] = P_0.uiCCBtBDSGDfxBkqXAFzqPXGKUft[j];
				}
				for (int k = 0; k < TKEUeczYbUwkjpymRRIIeVVKpLlh.Length; k++)
				{
					TKEUeczYbUwkjpymRRIIeVVKpLlh[k] = P_0.TKEUeczYbUwkjpymRRIIeVVKpLlh[k];
				}
				trPpoXUEDlqqIsixhUZVoXqdsASC = P_0.trPpoXUEDlqqIsixhUZVoXqdsASC;
				HiLEnxuQDtjxJGEbXGBuCLLbHIETB = P_0.HiLEnxuQDtjxJGEbXGBuCLLbHIETB;
				jSfTesuCyeRuJucBASTSrzeDtxIn = P_0.jSfTesuCyeRuJucBASTSrzeDtxIn;
				ygxtyaBLWIRmpKjSrLHcUUcGfwQp = P_0.ygxtyaBLWIRmpKjSrLHcUUcGfwQp;
				jzlgCdSLxKGRodkGGGWdsEYnbEcA = P_0.jzlgCdSLxKGRodkGGGWdsEYnbEcA;
				lndAYprTSArMFkSFdKbPIAsZoFwm = P_0.lndAYprTSArMFkSFdKbPIAsZoFwm;
				for (int l = 0; l < yrRBVIEGctEiDzfmEBQggujpULnk.Length; l++)
				{
					yrRBVIEGctEiDzfmEBQggujpULnk[l] = P_0.yrRBVIEGctEiDzfmEBQggujpULnk[l];
				}
				rGCnwFlKkncqxhkmYHAvhWeQBMLUA = P_0.rGCnwFlKkncqxhkmYHAvhWeQBMLUA;
				LRjCppihIMOekaTAIhJLtYNWarjG = P_0.LRjCppihIMOekaTAIhJLtYNWarjG;
				UBPJGLZPYubeWJpzhfsTmbpZUBlsA = P_0.UBPJGLZPYubeWJpzhfsTmbpZUBlsA;
				zeuMUYmqzqVpyKHKRNftzWLnzzjj = P_0.zeuMUYmqzqVpyKHKRNftzWLnzzjj;
				fPDgQnaEcKZawEqgUoqcwuBFlDsS = P_0.fPDgQnaEcKZawEqgUoqcwuBFlDsS;
				ClQQjuiHUEYJGPhOzUHNUnIIUoXn = P_0.ClQQjuiHUEYJGPhOzUHNUnIIUoXn;
				for (int m = 0; m < WIGKilZjmjnVpcDHGFFbSetbvuEi.Length; m++)
				{
					WIGKilZjmjnVpcDHGFFbSetbvuEi[m] = P_0.WIGKilZjmjnVpcDHGFFbSetbvuEi[m];
				}
				LltdiWiwscLSwBPmBZefBYFUchZz = P_0.LltdiWiwscLSwBPmBZefBYFUchZz;
				foYZLWQOsAnMiBIUFgESfNTnbcyHb = P_0.foYZLWQOsAnMiBIUFgESfNTnbcyHb;
				slOwyULWXLSxGHqSAGoXIijQUNzM = P_0.slOwyULWXLSxGHqSAGoXIijQUNzM;
				cxxGVueFdHJlVaQIJPVfwlualqqkb = P_0.cxxGVueFdHJlVaQIJPVfwlualqqkb;
				rkAFDlBlFbBkwphcKNDmFuASBfbsA = P_0.rkAFDlBlFbBkwphcKNDmFuASBfbsA;
				rwEdfgJcKrJwBSdTfPAbSkMMkLgcA = P_0.rwEdfgJcKrJwBSdTfPAbSkMMkLgcA;
				for (int n = 0; n < rsAkTxCRuHRBJcaKgtZuIbRGQRUu.Length; n++)
				{
					rsAkTxCRuHRBJcaKgtZuIbRGQRUu[n] = P_0.rsAkTxCRuHRBJcaKgtZuIbRGQRUu[n];
				}
			}

			public unsafe void gYolaDZFUAZAknxZoJvmVlyJjqxR(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						TKEUeczYbUwkjpymRRIIeVVKpLlh[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					WIGKilZjmjnVpcDHGFFbSetbvuEi[k] = *ptr;
					ptr++;
				}
				rGCnwFlKkncqxhkmYHAvhWeQBMLUA = *ptr;
				ptr++;
				LRjCppihIMOekaTAIhJLtYNWarjG = *ptr;
				ptr++;
				UBPJGLZPYubeWJpzhfsTmbpZUBlsA = *ptr;
				ptr++;
				zeuMUYmqzqVpyKHKRNftzWLnzzjj = *ptr;
				ptr++;
				fPDgQnaEcKZawEqgUoqcwuBFlDsS = *ptr;
				ptr++;
				ClQQjuiHUEYJGPhOzUHNUnIIUoXn = *ptr;
				ptr++;
				ygxtyaBLWIRmpKjSrLHcUUcGfwQp = *ptr;
				ptr++;
				jzlgCdSLxKGRodkGGGWdsEYnbEcA = *ptr;
				ptr++;
				lndAYprTSArMFkSFdKbPIAsZoFwm = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					rsAkTxCRuHRBJcaKgtZuIbRGQRUu[l] = *ptr;
					ptr++;
				}
				LltdiWiwscLSwBPmBZefBYFUchZz = *ptr;
				ptr++;
				foYZLWQOsAnMiBIUFgESfNTnbcyHb = *ptr;
				ptr++;
				slOwyULWXLSxGHqSAGoXIijQUNzM = *ptr;
				ptr++;
				KyJWPPIbnofirnrAlRNFRJSKdzFV = *ptr;
				ptr++;
				wHYyTbGFSDQlTcrEadQbRiVCyKUi = *ptr;
				ptr++;
				CttZbqASDHIGXhdHcErKePWazzgx = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					sMeqEqXWmbRCXXCJbxJBSwWZigEt[m] = *ptr;
					ptr++;
				}
				cxxGVueFdHJlVaQIJPVfwlualqqkb = *ptr;
				ptr++;
				rkAFDlBlFbBkwphcKNDmFuASBfbsA = *ptr;
				ptr++;
				rwEdfgJcKrJwBSdTfPAbSkMMkLgcA = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					yrRBVIEGctEiDzfmEBQggujpULnk[n] = *ptr;
					ptr++;
				}
				trPpoXUEDlqqIsixhUZVoXqdsASC = *ptr;
				ptr++;
				HiLEnxuQDtjxJGEbXGBuCLLbHIETB = *ptr;
				ptr++;
				jSfTesuCyeRuJucBASTSrzeDtxIn = *ptr;
				ptr++;
				HtTeZAARtZuwYTCBwAYEHVkwKgie = *ptr;
				ptr++;
				MmfKCRGhNKoOIWVCGDzRhOCKvdcG = *ptr;
				ptr++;
				AkDPSKOAsFmCZsGDvhYGinvlxZFeA = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					uiCCBtBDSGDfxBkqXAFzqPXGKUft[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void PEHqHipXgEXIouJxVsKGCyUrfMye(VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA;
				int[] array2 = P_0.mywFmMiUAUSKTuEGtFgWQwatGHkOA;
				int[] array3 = P_0.btAJPHhXnljIfHkPxPRkCNpPYyAM;
				int[] array4 = P_0.NdrjfoIIXymlEIgkZrfLAQzLKBOaA;
				int[] array5 = P_0.IqVXoiINmNjLeaoKTDXMpIhQIRgAb;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(array2[j]);
					ptr++;
				}
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.YVRBytjmLcaAdBAcZRHHaOsgrrFbc);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.VkMFFQZjXVfgirBPJabjJlBZpDABb);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.ZeNuSHBMTijwOnrIzbHzbvMxoShv);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.UEvMTKqxnamMwQcWMdzCQCtlwDBs);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.ZDOGQIGbYKPvRKnZhgSTGRRzWclr);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.XYwZBNOnSMJTLANxeCJxQBsoAOfU);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.KYlWxKddsHBmdBjqmgNdEajTCHjVA);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.TewCoEFYEevYejUmSWGegUmAhlsn);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.UyrgNinDeOiFNOhXaQsMlJWmoGed);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(array3[k]);
					ptr++;
				}
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.yfJfkqydDrSnwaPAZASqocrXhSzQ);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.EkYidYWzrkoASROuXOwuzVcTnkqp);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.icolILJBmaRuyzqagDtxXOiefOVY);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.xEcfeeHdsZCPWxwYgdWCHXdOCioZ);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.rAhIFgKJaimOmCYghykrAysyhrJVb);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.sxNxRkJGaRdlzcNZtBaRoUzRUXOe);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(array4[l]);
					ptr++;
				}
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.TzxHHFyvJQVHxAiGybTGXYiYRQCL);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.cIVAlXrVyztDayVBPDKomEYUenzz);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(array5[m]);
					ptr++;
				}
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.yACOeBGNsrPMSDyphNKBEAjGEZOi);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.IbgszZkpGTjxZaAXjdZRpzIivsAO);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.PdghcNGsQsvEzCtLekPObwhjIrsD);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.TENehSAyWbvDAjjMvQzuBsPVqjiHA);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.qSKuldKLVMsLXacLJccJyXFrxNjE);
				ptr++;
				*ptr = YSQBLEuSWWnDdaruFmjQxCvFACXW(P_0.fLEEGFsIZNelNuIasMPNbCTFCEwfA);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int jDrSuEGtPOXskxGEEWKahaOsJIKH = 2;

		private const int UGXnfDbKldHiYFqTEKUcHBYSslrjA = 2;

		private const int GdwfVvtYSFtixCBKdDpZHTrwvlDU = 128;

		private const int YjoGhQOlwaHrkYYgZRIzWfMZlqUb = 32;

		private const int WBzvhuWhTlTohUtsqCCWfmCPRczw = 0;

		private const int fcIXAberddiFRhrEvLiRjTrhLVaqc = 264;

		private const int zntsbnvXxltiDPEiwigXXDxGrADo = 272;

		private readonly int eZFjZfQnzISWiUiFtHtoahqnxnql;

		private readonly ButtonLoopSet BaisqioeIHbighAbRSvSkmCJdZDWA;

		private readonly DualThreadLowLevelInputEventQueue xdttUasSZTrXeGaPfUMtkDzzHQCQ;

		private fTvJBkIPfwffYDYPKTbOnrUmnKlpA hwwEsPIDnGkbYPzuOIAYvBEVOhFPA;

		private readonly VtLeNKSsCaVMweNoLHJHDUNhwUvFA QjDFaXwloDENFCsNOUfVUsZOjuMr;

		private readonly VtLeNKSsCaVMweNoLHJHDUNhwUvFA brNWSmINuHNIqahmcryqGTBdedUn;

		private readonly object GewDLBrADtHZVBHDbJSyacHfrhqaB;

		private bool ezRAAFZDvCZronRKdbeWzmnOPlGA;

		public readonly jmiDTsUKFPYQFBYgXXnbDNCMRcXj VlPtUFgOsOtaZwSydthtHZgOPEJV;

		private readonly phwdNJHNSNtXuAFLbKHkaeJcFgPCB wEnVWpuKKfoKqtHrleGnAXaAAFbH;

		private bool TvxRZsZCvbMxmTJyEZzcuOnvuiZl;

		public bool[] tFPTRtOuoLrCjLFGkqZPKpHCTppt => BaisqioeIHbighAbRSvSkmCJdZDWA.Current.effectiveValue;

		public phwdNJHNSNtXuAFLbKHkaeJcFgPCB yTmdkbbKWfKgdvADmcCyjnfPUECfb => wEnVWpuKKfoKqtHrleGnAXaAAFbH;

		public LULJRRBiGsDrlsRcrtYctFCnDxsN(jmiDTsUKFPYQFBYgXXnbDNCMRcXj P_0, UpdateLoopSetting P_1)
		{
			VlPtUFgOsOtaZwSydthtHZgOPEJV = P_0;
			eZFjZfQnzISWiUiFtHtoahqnxnql = P_0.OfVKqIDBopiIsKkbUgUZRuDOHWzK.VwzgdefkBUxKPQWWTBdoFkdfOyhWA;
			BaisqioeIHbighAbRSvSkmCJdZDWA = new ButtonLoopSet(P_1, eZFjZfQnzISWiUiFtHtoahqnxnql);
			xdttUasSZTrXeGaPfUMtkDzzHQCQ = new DualThreadLowLevelInputEventQueue((int)((float)lOimudEEADkCsfXveaIQPguQeEbk.UkYuObHPviBjKuyijpofFIgljEwT * 0.25f), 128, 32, 2);
			wEnVWpuKKfoKqtHrleGnAXaAAFbH = new phwdNJHNSNtXuAFLbKHkaeJcFgPCB();
			QjDFaXwloDENFCsNOUfVUsZOjuMr = new VtLeNKSsCaVMweNoLHJHDUNhwUvFA();
			brNWSmINuHNIqahmcryqGTBdedUn = new VtLeNKSsCaVMweNoLHJHDUNhwUvFA();
			GewDLBrADtHZVBHDbJSyacHfrhqaB = new object();
			if (lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA != null)
			{
				lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA.ThreadUpdateEvent += dPmMsEajpAWrMHhqklJrZfrDykTK;
			}
		}

		public void GSFFceEPpyssQbUhFNpXsePshCuo()
		{
			BaisqioeIHbighAbRSvSkmCJdZDWA.SetUpdateLoop(ReInput.currentUpdateLoop);
			OECSEaPraLcrFdVDkAKOnMGwamYRA();
		}

		public void WktFJgafJxFFMLMVybYYsJqjoxkLA()
		{
			BaisqioeIHbighAbRSvSkmCJdZDWA.Current.ClearWasTrueThisFrame();
		}

		public void YCeXTnKtMOGqGXGLRghdcBuFuBiQ()
		{
			ukSsbKWWmNqFDtRByfcXubiDRpSC();
			ezRAAFZDvCZronRKdbeWzmnOPlGA = true;
		}

		public void ArHicXUOYSGsuQUmypYDvdsfLTrM()
		{
			ezRAAFZDvCZronRKdbeWzmnOPlGA = false;
			ukSsbKWWmNqFDtRByfcXubiDRpSC();
		}

		public void pgjfsoazaOhLHEEefZTqRAHQcYmB(LULJRRBiGsDrlsRcrtYctFCnDxsN P_0)
		{
			if (P_0 == null || P_0 == this || P_0.eZFjZfQnzISWiUiFtHtoahqnxnql != eZFjZfQnzISWiUiFtHtoahqnxnql)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (GewDLBrADtHZVBHDbJSyacHfrhqaB)
			{
				lock (P_0.GewDLBrADtHZVBHDbJSyacHfrhqaB)
				{
					BaisqioeIHbighAbRSvSkmCJdZDWA.Import(P_0.BaisqioeIHbighAbRSvSkmCJdZDWA);
					wEnVWpuKKfoKqtHrleGnAXaAAFbH.zwvtzSYStmKKjMmdgabdQHMkpKZH(P_0.wEnVWpuKKfoKqtHrleGnAXaAAFbH);
					QjDFaXwloDENFCsNOUfVUsZOjuMr.rOHCVHndpOgPzhyiJEgyVVIhnQnb(P_0.QjDFaXwloDENFCsNOUfVUsZOjuMr);
					brNWSmINuHNIqahmcryqGTBdedUn.rOHCVHndpOgPzhyiJEgyVVIhnQnb(P_0.brNWSmINuHNIqahmcryqGTBdedUn);
					xdttUasSZTrXeGaPfUMtkDzzHQCQ.ImportAll(P_0.xdttUasSZTrXeGaPfUMtkDzzHQCQ);
					hwwEsPIDnGkbYPzuOIAYvBEVOhFPA = fTvJBkIPfwffYDYPKTbOnrUmnKlpA.LlJWTSpkiOixEhCgthFADafEsbQub(P_0.hwwEsPIDnGkbYPzuOIAYvBEVOhFPA, QjDFaXwloDENFCsNOUfVUsZOjuMr);
					ezRAAFZDvCZronRKdbeWzmnOPlGA = P_0.ezRAAFZDvCZronRKdbeWzmnOPlGA;
				}
			}
		}

		public void CKjEiQaIyTCwvUnxcQpskDdgLIZH(int P_0, int P_1, int P_2, float P_3)
		{
			lock (GewDLBrADtHZVBHDbJSyacHfrhqaB)
			{
				hwwEsPIDnGkbYPzuOIAYvBEVOhFPA = new fTvJBkIPfwffYDYPKTbOnrUmnKlpA(QjDFaXwloDENFCsNOUfVUsZOjuMr, P_0, P_1, P_2, P_3);
			}
		}

		private void dPmMsEajpAWrMHhqklJrZfrDykTK()
		{
			if (!ezRAAFZDvCZronRKdbeWzmnOPlGA)
			{
				return;
			}
			double realTime;
			try
			{
				VlPtUFgOsOtaZwSydthtHZgOPEJV.xhpUNyvcGlsepdtZqnUZGcYGrPoj(QjDFaXwloDENFCsNOUfVUsZOjuMr);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (GewDLBrADtHZVBHDbJSyacHfrhqaB)
			{
				if (hwwEsPIDnGkbYPzuOIAYvBEVOhFPA != null)
				{
					hwwEsPIDnGkbYPzuOIAYvBEVOhFPA.yrPxTnMGSWaSiKsUOUicbUaZNuKsA(realTime);
				}
				if (!QjDFaXwloDENFCsNOUfVUsZOjuMr.DCpgJbLUAWdbRdcDVPRZNAeILTgC(brNWSmINuHNIqahmcryqGTBdedUn))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = xdttUasSZTrXeGaPfUMtkDzzHQCQ.T_CreateEvent())
					{
						phwdNJHNSNtXuAFLbKHkaeJcFgPCB.PEHqHipXgEXIouJxVsKGCyUrfMye(QjDFaXwloDENFCsNOUfVUsZOjuMr, realTime, newEventWrapper.Event);
					}
					brNWSmINuHNIqahmcryqGTBdedUn.rOHCVHndpOgPzhyiJEgyVVIhnQnb(QjDFaXwloDENFCsNOUfVUsZOjuMr);
				}
			}
		}

		private void OECSEaPraLcrFdVDkAKOnMGwamYRA()
		{
			while (xdttUasSZTrXeGaPfUMtkDzzHQCQ.ProcessNewEvents())
			{
				wEnVWpuKKfoKqtHrleGnAXaAAFbH.gYolaDZFUAZAknxZoJvmVlyJjqxR(ref xdttUasSZTrXeGaPfUMtkDzzHQCQ.currentEvent);
				for (int i = 0; i < eZFjZfQnzISWiUiFtHtoahqnxnql; i++)
				{
					BaisqioeIHbighAbRSvSkmCJdZDWA.SetValue(i, wEnVWpuKKfoKqtHrleGnAXaAAFbH.TKEUeczYbUwkjpymRRIIeVVKpLlh[i], xdttUasSZTrXeGaPfUMtkDzzHQCQ.currentEvent.GetTimestamp());
				}
			}
		}

		private void ukSsbKWWmNqFDtRByfcXubiDRpSC()
		{
			wEnVWpuKKfoKqtHrleGnAXaAAFbH.NJfsHsZXVjMwATbBxEYJBhvVJOJjA();
			lock (GewDLBrADtHZVBHDbJSyacHfrhqaB)
			{
				QjDFaXwloDENFCsNOUfVUsZOjuMr.ycvKKiEhVMqFyqDwpymSihUjKYdI();
				brNWSmINuHNIqahmcryqGTBdedUn.ycvKKiEhVMqFyqDwpymSihUjKYdI();
				xdttUasSZTrXeGaPfUMtkDzzHQCQ.Clear();
			}
			BaisqioeIHbighAbRSvSkmCJdZDWA.Clear();
		}

		public void Dispose()
		{
			JUQyKIXQyoQnUQiCTpdvjezdLJmQ(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void VyMBuJKTcvLjLHwFyGTSPvVRLDqq()
		{
			try
			{
				JUQyKIXQyoQnUQiCTpdvjezdLJmQ(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void JUQyKIXQyoQnUQiCTpdvjezdLJmQ(bool P_0)
		{
			if (!TvxRZsZCvbMxmTJyEZzcuOnvuiZl)
			{
				if (P_0)
				{
					ArHicXUOYSGsuQUmypYDvdsfLTrM();
					xdttUasSZTrXeGaPfUMtkDzzHQCQ.Dispose();
				}
				if (lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA != null)
				{
					lOimudEEADkCsfXveaIQPguQeEbk.ANuGBWudliodGbGfCbfveIhMhBLIA.ThreadUpdateEvent -= dPmMsEajpAWrMHhqklJrZfrDykTK;
				}
				TvxRZsZCvbMxmTJyEZzcuOnvuiZl = true;
			}
		}

		private static float YSQBLEuSWWnDdaruFmjQxCvFACXW(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class fTvJBkIPfwffYDYPKTbOnrUmnKlpA
	{
		private VtLeNKSsCaVMweNoLHJHDUNhwUvFA NQtWwBWNUBnJoqXzcEHABymJXWZH;

		private NqxjGYcBrptFNJMnrCLiKWREmDlu bPJQFDTuwSxkQqRUWOAmaIALbqrb;

		private int DCkVIcrGtRDMgPOBqHtsjHXpssEG;

		private int rpNVdqRHWmbBMemkalmrblTpexkc;

		private int oUYCRGqtTXxUPGQtyztAmKsbkJfl;

		private float taMqhGvhrfJMDDNiGcZgMcbRXTlj;

		public VtLeNKSsCaVMweNoLHJHDUNhwUvFA kLefehKRMsgJVtVsWkuqSemeHcOYA => NQtWwBWNUBnJoqXzcEHABymJXWZH;

		public static fTvJBkIPfwffYDYPKTbOnrUmnKlpA LlJWTSpkiOixEhCgthFADafEsbQub(fTvJBkIPfwffYDYPKTbOnrUmnKlpA P_0, VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new fTvJBkIPfwffYDYPKTbOnrUmnKlpA(P_0, P_1);
		}

		public fTvJBkIPfwffYDYPKTbOnrUmnKlpA(VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			bPJQFDTuwSxkQqRUWOAmaIALbqrb = new NqxjGYcBrptFNJMnrCLiKWREmDlu(P_0);
			NQtWwBWNUBnJoqXzcEHABymJXWZH = new VtLeNKSsCaVMweNoLHJHDUNhwUvFA();
		}

		private fTvJBkIPfwffYDYPKTbOnrUmnKlpA(fTvJBkIPfwffYDYPKTbOnrUmnKlpA P_0, VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_1)
			: this(P_1, P_0.DCkVIcrGtRDMgPOBqHtsjHXpssEG, P_0.rpNVdqRHWmbBMemkalmrblTpexkc, P_0.oUYCRGqtTXxUPGQtyztAmKsbkJfl, P_0.taMqhGvhrfJMDDNiGcZgMcbRXTlj)
		{
			nyKUZPdQVCHhhJbigsPUFKCkjjZJ(P_0);
		}

		private fTvJBkIPfwffYDYPKTbOnrUmnKlpA(int P_0, int P_1, int P_2, float P_3)
		{
			DCkVIcrGtRDMgPOBqHtsjHXpssEG = P_0;
			rpNVdqRHWmbBMemkalmrblTpexkc = P_1;
			oUYCRGqtTXxUPGQtyztAmKsbkJfl = P_2;
			taMqhGvhrfJMDDNiGcZgMcbRXTlj = P_3;
		}

		public void yrPxTnMGSWaSiKsUOUicbUaZNuKsA(double P_0)
		{
			bPJQFDTuwSxkQqRUWOAmaIALbqrb.dBqhRNITfDmSRkVShcWOJvAYKsDf(P_0);
			if (!bPJQFDTuwSxkQqRUWOAmaIALbqrb.xWyWvodmFVRQjijPLWpZOfkmoNqn)
			{
				if (P_0 >= bPJQFDTuwSxkQqRUWOAmaIALbqrb.ijsdJIdyTewLuiLfoKDMfnZAoeLO + (double)taMqhGvhrfJMDDNiGcZgMcbRXTlj)
				{
					NQtWwBWNUBnJoqXzcEHABymJXWZH.ycvKKiEhVMqFyqDwpymSihUjKYdI();
				}
				return;
			}
			VtLeNKSsCaVMweNoLHJHDUNhwUvFA vtLeNKSsCaVMweNoLHJHDUNhwUvFA = bPJQFDTuwSxkQqRUWOAmaIALbqrb.GXFaSrcrCdNFbLeKfsHmuVadDiVPA;
			VtLeNKSsCaVMweNoLHJHDUNhwUvFA vtLeNKSsCaVMweNoLHJHDUNhwUvFA2 = bPJQFDTuwSxkQqRUWOAmaIALbqrb.mbsYgTgWJIpnokUTMOMIlDVDQgYw;
			NQtWwBWNUBnJoqXzcEHABymJXWZH.TENehSAyWbvDAjjMvQzuBsPVqjiHA = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.TENehSAyWbvDAjjMvQzuBsPVqjiHA);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.qSKuldKLVMsLXacLJccJyXFrxNjE = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.qSKuldKLVMsLXacLJccJyXFrxNjE);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.fLEEGFsIZNelNuIasMPNbCTFCEwfA = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.fLEEGFsIZNelNuIasMPNbCTFCEwfA);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.xEcfeeHdsZCPWxwYgdWCHXdOCioZ = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.xEcfeeHdsZCPWxwYgdWCHXdOCioZ);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.rAhIFgKJaimOmCYghykrAysyhrJVb = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.rAhIFgKJaimOmCYghykrAysyhrJVb);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.sxNxRkJGaRdlzcNZtBaRoUzRUXOe = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.sxNxRkJGaRdlzcNZtBaRoUzRUXOe);
			for (int i = 0; i < NQtWwBWNUBnJoqXzcEHABymJXWZH.NdrjfoIIXymlEIgkZrfLAQzLKBOaA.Length; i++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i] = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i]);
			}
			for (int j = 0; j < NQtWwBWNUBnJoqXzcEHABymJXWZH.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA.Length; j++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j] = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j]);
			}
			for (int k = 0; k < NQtWwBWNUBnJoqXzcEHABymJXWZH.dFtjxHIKBEVCbiMbVRQgOXuRBzsR.Length; k++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k] = vtLeNKSsCaVMweNoLHJHDUNhwUvFA2.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k];
			}
			NQtWwBWNUBnJoqXzcEHABymJXWZH.yACOeBGNsrPMSDyphNKBEAjGEZOi = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.yACOeBGNsrPMSDyphNKBEAjGEZOi);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.IbgszZkpGTjxZaAXjdZRpzIivsAO = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.IbgszZkpGTjxZaAXjdZRpzIivsAO);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.PdghcNGsQsvEzCtLekPObwhjIrsD = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.PdghcNGsQsvEzCtLekPObwhjIrsD);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.KYlWxKddsHBmdBjqmgNdEajTCHjVA = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.KYlWxKddsHBmdBjqmgNdEajTCHjVA);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.TewCoEFYEevYejUmSWGegUmAhlsn = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.TewCoEFYEevYejUmSWGegUmAhlsn);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.UyrgNinDeOiFNOhXaQsMlJWmoGed = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.UyrgNinDeOiFNOhXaQsMlJWmoGed);
			for (int l = 0; l < NQtWwBWNUBnJoqXzcEHABymJXWZH.IqVXoiINmNjLeaoKTDXMpIhQIRgAb.Length; l++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l] = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l]);
			}
			NQtWwBWNUBnJoqXzcEHABymJXWZH.YVRBytjmLcaAdBAcZRHHaOsgrrFbc = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.YVRBytjmLcaAdBAcZRHHaOsgrrFbc);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.VkMFFQZjXVfgirBPJabjJlBZpDABb = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.VkMFFQZjXVfgirBPJabjJlBZpDABb);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.ZeNuSHBMTijwOnrIzbHzbvMxoShv = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.ZeNuSHBMTijwOnrIzbHzbvMxoShv);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.UEvMTKqxnamMwQcWMdzCQCtlwDBs = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.UEvMTKqxnamMwQcWMdzCQCtlwDBs);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.ZDOGQIGbYKPvRKnZhgSTGRRzWclr = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.ZDOGQIGbYKPvRKnZhgSTGRRzWclr);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.XYwZBNOnSMJTLANxeCJxQBsoAOfU = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.XYwZBNOnSMJTLANxeCJxQBsoAOfU);
			for (int m = 0; m < NQtWwBWNUBnJoqXzcEHABymJXWZH.mywFmMiUAUSKTuEGtFgWQwatGHkOA.Length; m++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m] = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m]);
			}
			NQtWwBWNUBnJoqXzcEHABymJXWZH.yfJfkqydDrSnwaPAZASqocrXhSzQ = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.yfJfkqydDrSnwaPAZASqocrXhSzQ);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.EkYidYWzrkoASROuXOwuzVcTnkqp = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.EkYidYWzrkoASROuXOwuzVcTnkqp);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.icolILJBmaRuyzqagDtxXOiefOVY = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.icolILJBmaRuyzqagDtxXOiefOVY);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.TzxHHFyvJQVHxAiGybTGXYiYRQCL = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.TzxHHFyvJQVHxAiGybTGXYiYRQCL);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.cIVAlXrVyztDayVBPDKomEYUenzz = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.cIVAlXrVyztDayVBPDKomEYUenzz);
			NQtWwBWNUBnJoqXzcEHABymJXWZH.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA);
			for (int n = 0; n < NQtWwBWNUBnJoqXzcEHABymJXWZH.btAJPHhXnljIfHkPxPRkCNpPYyAM.Length; n++)
			{
				NQtWwBWNUBnJoqXzcEHABymJXWZH.btAJPHhXnljIfHkPxPRkCNpPYyAM[n] = mVyWdtqOoicmmJbGfClJmsllefrFA(vtLeNKSsCaVMweNoLHJHDUNhwUvFA.btAJPHhXnljIfHkPxPRkCNpPYyAM[n]);
			}
		}

		public void nyKUZPdQVCHhhJbigsPUFKCkjjZJ(fTvJBkIPfwffYDYPKTbOnrUmnKlpA P_0)
		{
			NQtWwBWNUBnJoqXzcEHABymJXWZH.rOHCVHndpOgPzhyiJEgyVVIhnQnb(P_0.NQtWwBWNUBnJoqXzcEHABymJXWZH);
			bPJQFDTuwSxkQqRUWOAmaIALbqrb.EGaKqUyBQqIEbssChzuNfFoLyMbs(P_0.bPJQFDTuwSxkQqRUWOAmaIALbqrb);
			DCkVIcrGtRDMgPOBqHtsjHXpssEG = P_0.DCkVIcrGtRDMgPOBqHtsjHXpssEG;
			rpNVdqRHWmbBMemkalmrblTpexkc = P_0.rpNVdqRHWmbBMemkalmrblTpexkc;
			oUYCRGqtTXxUPGQtyztAmKsbkJfl = P_0.oUYCRGqtTXxUPGQtyztAmKsbkJfl;
			taMqhGvhrfJMDDNiGcZgMcbRXTlj = P_0.taMqhGvhrfJMDDNiGcZgMcbRXTlj;
		}

		private int mVyWdtqOoicmmJbGfClJmsllefrFA(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, DCkVIcrGtRDMgPOBqHtsjHXpssEG, rpNVdqRHWmbBMemkalmrblTpexkc, -65535, 65535);
		}
	}

	private class NqxjGYcBrptFNJMnrCLiKWREmDlu
	{
		private double HaGDuBntgqYvZKYidFCXWhsmzsyp;

		private VtLeNKSsCaVMweNoLHJHDUNhwUvFA lSYGYLwleXwokouoKuwLuhxOvjfm;

		private VtLeNKSsCaVMweNoLHJHDUNhwUvFA UZJUmctMGkMJNmPinZTeKjMifAnCA;

		private VtLeNKSsCaVMweNoLHJHDUNhwUvFA MWNWAXLBdTnLactSleXoQVVFHlFp;

		private bool XdzihNSWMzINhgPHtwVNDjjopVPQ;

		private double fadKnBptObAVefhcmJqHAcomqMgE;

		public VtLeNKSsCaVMweNoLHJHDUNhwUvFA mbsYgTgWJIpnokUTMOMIlDVDQgYw => lSYGYLwleXwokouoKuwLuhxOvjfm;

		public VtLeNKSsCaVMweNoLHJHDUNhwUvFA GXFaSrcrCdNFbLeKfsHmuVadDiVPA => MWNWAXLBdTnLactSleXoQVVFHlFp;

		public bool xWyWvodmFVRQjijPLWpZOfkmoNqn => XdzihNSWMzINhgPHtwVNDjjopVPQ;

		public double ijsdJIdyTewLuiLfoKDMfnZAoeLO => fadKnBptObAVefhcmJqHAcomqMgE;

		public NqxjGYcBrptFNJMnrCLiKWREmDlu(VtLeNKSsCaVMweNoLHJHDUNhwUvFA P_0)
		{
			lSYGYLwleXwokouoKuwLuhxOvjfm = P_0;
			UZJUmctMGkMJNmPinZTeKjMifAnCA = new VtLeNKSsCaVMweNoLHJHDUNhwUvFA();
			MWNWAXLBdTnLactSleXoQVVFHlFp = new VtLeNKSsCaVMweNoLHJHDUNhwUvFA();
		}

		public void dBqhRNITfDmSRkVShcWOJvAYKsDf(double P_0)
		{
			HaGDuBntgqYvZKYidFCXWhsmzsyp = P_0;
			MWNWAXLBdTnLactSleXoQVVFHlFp.TENehSAyWbvDAjjMvQzuBsPVqjiHA = lSYGYLwleXwokouoKuwLuhxOvjfm.TENehSAyWbvDAjjMvQzuBsPVqjiHA - UZJUmctMGkMJNmPinZTeKjMifAnCA.TENehSAyWbvDAjjMvQzuBsPVqjiHA;
			MWNWAXLBdTnLactSleXoQVVFHlFp.qSKuldKLVMsLXacLJccJyXFrxNjE = lSYGYLwleXwokouoKuwLuhxOvjfm.qSKuldKLVMsLXacLJccJyXFrxNjE - UZJUmctMGkMJNmPinZTeKjMifAnCA.qSKuldKLVMsLXacLJccJyXFrxNjE;
			MWNWAXLBdTnLactSleXoQVVFHlFp.fLEEGFsIZNelNuIasMPNbCTFCEwfA = lSYGYLwleXwokouoKuwLuhxOvjfm.fLEEGFsIZNelNuIasMPNbCTFCEwfA - UZJUmctMGkMJNmPinZTeKjMifAnCA.fLEEGFsIZNelNuIasMPNbCTFCEwfA;
			MWNWAXLBdTnLactSleXoQVVFHlFp.xEcfeeHdsZCPWxwYgdWCHXdOCioZ = lSYGYLwleXwokouoKuwLuhxOvjfm.xEcfeeHdsZCPWxwYgdWCHXdOCioZ - UZJUmctMGkMJNmPinZTeKjMifAnCA.xEcfeeHdsZCPWxwYgdWCHXdOCioZ;
			MWNWAXLBdTnLactSleXoQVVFHlFp.rAhIFgKJaimOmCYghykrAysyhrJVb = lSYGYLwleXwokouoKuwLuhxOvjfm.rAhIFgKJaimOmCYghykrAysyhrJVb - UZJUmctMGkMJNmPinZTeKjMifAnCA.rAhIFgKJaimOmCYghykrAysyhrJVb;
			MWNWAXLBdTnLactSleXoQVVFHlFp.sxNxRkJGaRdlzcNZtBaRoUzRUXOe = lSYGYLwleXwokouoKuwLuhxOvjfm.sxNxRkJGaRdlzcNZtBaRoUzRUXOe - UZJUmctMGkMJNmPinZTeKjMifAnCA.sxNxRkJGaRdlzcNZtBaRoUzRUXOe;
			for (int i = 0; i < lSYGYLwleXwokouoKuwLuhxOvjfm.NdrjfoIIXymlEIgkZrfLAQzLKBOaA.Length; i++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i] = lSYGYLwleXwokouoKuwLuhxOvjfm.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i] - UZJUmctMGkMJNmPinZTeKjMifAnCA.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i];
			}
			for (int j = 0; j < lSYGYLwleXwokouoKuwLuhxOvjfm.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA.Length; j++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j] = lSYGYLwleXwokouoKuwLuhxOvjfm.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j] - UZJUmctMGkMJNmPinZTeKjMifAnCA.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j];
			}
			for (int k = 0; k < lSYGYLwleXwokouoKuwLuhxOvjfm.dFtjxHIKBEVCbiMbVRQgOXuRBzsR.Length; k++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k] = lSYGYLwleXwokouoKuwLuhxOvjfm.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k] != UZJUmctMGkMJNmPinZTeKjMifAnCA.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k];
			}
			MWNWAXLBdTnLactSleXoQVVFHlFp.yACOeBGNsrPMSDyphNKBEAjGEZOi = lSYGYLwleXwokouoKuwLuhxOvjfm.yACOeBGNsrPMSDyphNKBEAjGEZOi - UZJUmctMGkMJNmPinZTeKjMifAnCA.yACOeBGNsrPMSDyphNKBEAjGEZOi;
			MWNWAXLBdTnLactSleXoQVVFHlFp.IbgszZkpGTjxZaAXjdZRpzIivsAO = lSYGYLwleXwokouoKuwLuhxOvjfm.IbgszZkpGTjxZaAXjdZRpzIivsAO - UZJUmctMGkMJNmPinZTeKjMifAnCA.IbgszZkpGTjxZaAXjdZRpzIivsAO;
			MWNWAXLBdTnLactSleXoQVVFHlFp.PdghcNGsQsvEzCtLekPObwhjIrsD = lSYGYLwleXwokouoKuwLuhxOvjfm.PdghcNGsQsvEzCtLekPObwhjIrsD - UZJUmctMGkMJNmPinZTeKjMifAnCA.PdghcNGsQsvEzCtLekPObwhjIrsD;
			MWNWAXLBdTnLactSleXoQVVFHlFp.KYlWxKddsHBmdBjqmgNdEajTCHjVA = lSYGYLwleXwokouoKuwLuhxOvjfm.KYlWxKddsHBmdBjqmgNdEajTCHjVA - UZJUmctMGkMJNmPinZTeKjMifAnCA.KYlWxKddsHBmdBjqmgNdEajTCHjVA;
			MWNWAXLBdTnLactSleXoQVVFHlFp.TewCoEFYEevYejUmSWGegUmAhlsn = lSYGYLwleXwokouoKuwLuhxOvjfm.TewCoEFYEevYejUmSWGegUmAhlsn - UZJUmctMGkMJNmPinZTeKjMifAnCA.TewCoEFYEevYejUmSWGegUmAhlsn;
			MWNWAXLBdTnLactSleXoQVVFHlFp.UyrgNinDeOiFNOhXaQsMlJWmoGed = lSYGYLwleXwokouoKuwLuhxOvjfm.UyrgNinDeOiFNOhXaQsMlJWmoGed - UZJUmctMGkMJNmPinZTeKjMifAnCA.UyrgNinDeOiFNOhXaQsMlJWmoGed;
			for (int l = 0; l < lSYGYLwleXwokouoKuwLuhxOvjfm.IqVXoiINmNjLeaoKTDXMpIhQIRgAb.Length; l++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l] = lSYGYLwleXwokouoKuwLuhxOvjfm.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l] - UZJUmctMGkMJNmPinZTeKjMifAnCA.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l];
			}
			MWNWAXLBdTnLactSleXoQVVFHlFp.YVRBytjmLcaAdBAcZRHHaOsgrrFbc = lSYGYLwleXwokouoKuwLuhxOvjfm.YVRBytjmLcaAdBAcZRHHaOsgrrFbc - UZJUmctMGkMJNmPinZTeKjMifAnCA.YVRBytjmLcaAdBAcZRHHaOsgrrFbc;
			MWNWAXLBdTnLactSleXoQVVFHlFp.VkMFFQZjXVfgirBPJabjJlBZpDABb = lSYGYLwleXwokouoKuwLuhxOvjfm.VkMFFQZjXVfgirBPJabjJlBZpDABb - UZJUmctMGkMJNmPinZTeKjMifAnCA.VkMFFQZjXVfgirBPJabjJlBZpDABb;
			MWNWAXLBdTnLactSleXoQVVFHlFp.ZeNuSHBMTijwOnrIzbHzbvMxoShv = lSYGYLwleXwokouoKuwLuhxOvjfm.ZeNuSHBMTijwOnrIzbHzbvMxoShv - UZJUmctMGkMJNmPinZTeKjMifAnCA.ZeNuSHBMTijwOnrIzbHzbvMxoShv;
			MWNWAXLBdTnLactSleXoQVVFHlFp.UEvMTKqxnamMwQcWMdzCQCtlwDBs = lSYGYLwleXwokouoKuwLuhxOvjfm.UEvMTKqxnamMwQcWMdzCQCtlwDBs - UZJUmctMGkMJNmPinZTeKjMifAnCA.UEvMTKqxnamMwQcWMdzCQCtlwDBs;
			MWNWAXLBdTnLactSleXoQVVFHlFp.ZDOGQIGbYKPvRKnZhgSTGRRzWclr = lSYGYLwleXwokouoKuwLuhxOvjfm.ZDOGQIGbYKPvRKnZhgSTGRRzWclr - UZJUmctMGkMJNmPinZTeKjMifAnCA.ZDOGQIGbYKPvRKnZhgSTGRRzWclr;
			MWNWAXLBdTnLactSleXoQVVFHlFp.XYwZBNOnSMJTLANxeCJxQBsoAOfU = lSYGYLwleXwokouoKuwLuhxOvjfm.XYwZBNOnSMJTLANxeCJxQBsoAOfU - UZJUmctMGkMJNmPinZTeKjMifAnCA.XYwZBNOnSMJTLANxeCJxQBsoAOfU;
			for (int m = 0; m < lSYGYLwleXwokouoKuwLuhxOvjfm.mywFmMiUAUSKTuEGtFgWQwatGHkOA.Length; m++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m] = lSYGYLwleXwokouoKuwLuhxOvjfm.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m] - UZJUmctMGkMJNmPinZTeKjMifAnCA.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m];
			}
			MWNWAXLBdTnLactSleXoQVVFHlFp.yfJfkqydDrSnwaPAZASqocrXhSzQ = lSYGYLwleXwokouoKuwLuhxOvjfm.yfJfkqydDrSnwaPAZASqocrXhSzQ - UZJUmctMGkMJNmPinZTeKjMifAnCA.yfJfkqydDrSnwaPAZASqocrXhSzQ;
			MWNWAXLBdTnLactSleXoQVVFHlFp.EkYidYWzrkoASROuXOwuzVcTnkqp = lSYGYLwleXwokouoKuwLuhxOvjfm.EkYidYWzrkoASROuXOwuzVcTnkqp - UZJUmctMGkMJNmPinZTeKjMifAnCA.EkYidYWzrkoASROuXOwuzVcTnkqp;
			MWNWAXLBdTnLactSleXoQVVFHlFp.icolILJBmaRuyzqagDtxXOiefOVY = lSYGYLwleXwokouoKuwLuhxOvjfm.icolILJBmaRuyzqagDtxXOiefOVY - UZJUmctMGkMJNmPinZTeKjMifAnCA.icolILJBmaRuyzqagDtxXOiefOVY;
			MWNWAXLBdTnLactSleXoQVVFHlFp.TzxHHFyvJQVHxAiGybTGXYiYRQCL = lSYGYLwleXwokouoKuwLuhxOvjfm.TzxHHFyvJQVHxAiGybTGXYiYRQCL - UZJUmctMGkMJNmPinZTeKjMifAnCA.TzxHHFyvJQVHxAiGybTGXYiYRQCL;
			MWNWAXLBdTnLactSleXoQVVFHlFp.cIVAlXrVyztDayVBPDKomEYUenzz = lSYGYLwleXwokouoKuwLuhxOvjfm.cIVAlXrVyztDayVBPDKomEYUenzz - UZJUmctMGkMJNmPinZTeKjMifAnCA.cIVAlXrVyztDayVBPDKomEYUenzz;
			MWNWAXLBdTnLactSleXoQVVFHlFp.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA = lSYGYLwleXwokouoKuwLuhxOvjfm.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA - UZJUmctMGkMJNmPinZTeKjMifAnCA.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA;
			for (int n = 0; n < lSYGYLwleXwokouoKuwLuhxOvjfm.btAJPHhXnljIfHkPxPRkCNpPYyAM.Length; n++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.btAJPHhXnljIfHkPxPRkCNpPYyAM[n] = lSYGYLwleXwokouoKuwLuhxOvjfm.btAJPHhXnljIfHkPxPRkCNpPYyAM[n] - UZJUmctMGkMJNmPinZTeKjMifAnCA.btAJPHhXnljIfHkPxPRkCNpPYyAM[n];
			}
			XdzihNSWMzINhgPHtwVNDjjopVPQ = pPONENLjEqGJeTOwnlIXuyKosTLG();
			if (XdzihNSWMzINhgPHtwVNDjjopVPQ)
			{
				fadKnBptObAVefhcmJqHAcomqMgE = P_0;
				UZJUmctMGkMJNmPinZTeKjMifAnCA.rOHCVHndpOgPzhyiJEgyVVIhnQnb(lSYGYLwleXwokouoKuwLuhxOvjfm);
			}
		}

		public void EGaKqUyBQqIEbssChzuNfFoLyMbs(NqxjGYcBrptFNJMnrCLiKWREmDlu P_0)
		{
			HaGDuBntgqYvZKYidFCXWhsmzsyp = P_0.HaGDuBntgqYvZKYidFCXWhsmzsyp;
			UZJUmctMGkMJNmPinZTeKjMifAnCA.rOHCVHndpOgPzhyiJEgyVVIhnQnb(P_0.UZJUmctMGkMJNmPinZTeKjMifAnCA);
			MWNWAXLBdTnLactSleXoQVVFHlFp.rOHCVHndpOgPzhyiJEgyVVIhnQnb(P_0.MWNWAXLBdTnLactSleXoQVVFHlFp);
		}

		private bool pPONENLjEqGJeTOwnlIXuyKosTLG()
		{
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.qSKuldKLVMsLXacLJccJyXFrxNjE != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.fLEEGFsIZNelNuIasMPNbCTFCEwfA != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.xEcfeeHdsZCPWxwYgdWCHXdOCioZ != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.rAhIFgKJaimOmCYghykrAysyhrJVb != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.sxNxRkJGaRdlzcNZtBaRoUzRUXOe != 0)
			{
				return true;
			}
			for (int i = 0; i < lSYGYLwleXwokouoKuwLuhxOvjfm.NdrjfoIIXymlEIgkZrfLAQzLKBOaA.Length; i++)
			{
				if (MWNWAXLBdTnLactSleXoQVVFHlFp.NdrjfoIIXymlEIgkZrfLAQzLKBOaA[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < lSYGYLwleXwokouoKuwLuhxOvjfm.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA.Length; j++)
			{
				if (MWNWAXLBdTnLactSleXoQVVFHlFp.NDZBTtFPBnBrMKyEDKqzTRtGtgqiA[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < lSYGYLwleXwokouoKuwLuhxOvjfm.dFtjxHIKBEVCbiMbVRQgOXuRBzsR.Length; k++)
			{
				if (MWNWAXLBdTnLactSleXoQVVFHlFp.dFtjxHIKBEVCbiMbVRQgOXuRBzsR[k])
				{
					return true;
				}
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.yACOeBGNsrPMSDyphNKBEAjGEZOi != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.IbgszZkpGTjxZaAXjdZRpzIivsAO != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.PdghcNGsQsvEzCtLekPObwhjIrsD != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.KYlWxKddsHBmdBjqmgNdEajTCHjVA != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.TewCoEFYEevYejUmSWGegUmAhlsn != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.UyrgNinDeOiFNOhXaQsMlJWmoGed != 0)
			{
				return true;
			}
			for (int l = 0; l < lSYGYLwleXwokouoKuwLuhxOvjfm.IqVXoiINmNjLeaoKTDXMpIhQIRgAb.Length; l++)
			{
				if (MWNWAXLBdTnLactSleXoQVVFHlFp.IqVXoiINmNjLeaoKTDXMpIhQIRgAb[l] != 0)
				{
					return true;
				}
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.YVRBytjmLcaAdBAcZRHHaOsgrrFbc != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.VkMFFQZjXVfgirBPJabjJlBZpDABb != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.ZeNuSHBMTijwOnrIzbHzbvMxoShv != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.UEvMTKqxnamMwQcWMdzCQCtlwDBs != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.ZDOGQIGbYKPvRKnZhgSTGRRzWclr != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.XYwZBNOnSMJTLANxeCJxQBsoAOfU != 0)
			{
				return true;
			}
			for (int m = 0; m < lSYGYLwleXwokouoKuwLuhxOvjfm.mywFmMiUAUSKTuEGtFgWQwatGHkOA.Length; m++)
			{
				MWNWAXLBdTnLactSleXoQVVFHlFp.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m] = lSYGYLwleXwokouoKuwLuhxOvjfm.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m] - UZJUmctMGkMJNmPinZTeKjMifAnCA.mywFmMiUAUSKTuEGtFgWQwatGHkOA[m];
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.yfJfkqydDrSnwaPAZASqocrXhSzQ != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.EkYidYWzrkoASROuXOwuzVcTnkqp != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.icolILJBmaRuyzqagDtxXOiefOVY != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.TzxHHFyvJQVHxAiGybTGXYiYRQCL != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.cIVAlXrVyztDayVBPDKomEYUenzz != 0)
			{
				return true;
			}
			if (MWNWAXLBdTnLactSleXoQVVFHlFp.sZHeSVeYRrqcmTaoWUYFJyWYPbbmA != 0)
			{
				return true;
			}
			for (int n = 0; n < lSYGYLwleXwokouoKuwLuhxOvjfm.btAJPHhXnljIfHkPxPRkCNpPYyAM.Length; n++)
			{
				if (MWNWAXLBdTnLactSleXoQVVFHlFp.btAJPHhXnljIfHkPxPRkCNpPYyAM[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class KxbYasQTjZJkSyCaICMaSTQpwfYr
	{
		public enum UsGNQBNBgNZUhlYjbPkaBwgidHLU
		{
			Exact = 0,
			Approximate = 1
		}

		public class DTYuUedmDfITSBrmYZQCMQrVXAot
		{
			public int theChBjZCqKuzdHpFUITiqougwpu;

			public Guid yvCmJWCPOtZEITzwWHicRCoSLsqF;

			public Guid hIlOcnFfoLPhjloDafWHuDNkQazI;

			public int PRbrxnrCMQOpzdyBQfOiSZETUQNy;

			public int ojVsCuWDaxFDwJFBDjNKXeRSCjFiA;

			public int RVgcknhKGGQOvtUZzSCxfIedTwTX;

			public int yplaNTdOjiVhwPnBskSOvNzZEgBO;

			public bool tryBhsckAaIzgiAJRQTzOXfiBBPbb(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, UsGNQBNBgNZUhlYjbPkaBwgidHLU P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == theChBjZCqKuzdHpFUITiqougwpu)
				{
					return true;
				}
				if (ojVsCuWDaxFDwJFBDjNKXeRSCjFiA != P_0.qKjzDhbAFLatokrBnyHFMHppIdWvA)
				{
					return false;
				}
				if (RVgcknhKGGQOvtUZzSCxfIedTwTX != P_0.AqNmTzfrngcvaftwUChjtBJNSNBn)
				{
					return false;
				}
				if (yplaNTdOjiVhwPnBskSOvNzZEgBO != P_0.mGMdnbwkuHlLZnTozAwGpzOZilLg)
				{
					return false;
				}
				return P_1 switch
				{
					UsGNQBNBgNZUhlYjbPkaBwgidHLU.Exact => yvCmJWCPOtZEITzwWHicRCoSLsqF == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					UsGNQBNBgNZUhlYjbPkaBwgidHLU.Approximate => hIlOcnFfoLPhjloDafWHuDNkQazI == P_0.ZJCbKwIgkEiHAvPpRLVvZRvobdViA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string OHZBOtervbLpGLFcubDtjSzfNCti()
			{
				string text = "" + "rewiredId = " + theChBjZCqKuzdHpFUITiqougwpu + "\n";
				Guid guid = yvCmJWCPOtZEITzwWHicRCoSLsqF;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = hIlOcnFfoLPhjloDafWHuDNkQazI;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", PRbrxnrCMQOpzdyBQfOiSZETUQNy.ToString(), "\n"), "hardwareAxisCount = ", ojVsCuWDaxFDwJFBDjNKXeRSCjFiA.ToString(), "\n"), "hardwareButtonCount = ", RVgcknhKGGQOvtUZzSCxfIedTwTX.ToString(), "\n"), "hardwareHatCount = ", yplaNTdOjiVhwPnBskSOvNzZEgBO.ToString(), "\n");
			}
		}

		private sealed class WNZzCsGylevnMloHrXnqglmmLBzE : IEnumerable<DTYuUedmDfITSBrmYZQCMQrVXAot>, IEnumerable, IEnumerator<DTYuUedmDfITSBrmYZQCMQrVXAot>, IEnumerator, IDisposable
		{
			private int QZPlYDhulxfVgyFftEexhvUeoiRfb;

			private DTYuUedmDfITSBrmYZQCMQrVXAot toZqhZJcORGyYuIqIDogbAoiOnwB;

			private int GfYSQphCTYIvFfqtWeZQTlBjSFoV;

			public KxbYasQTjZJkSyCaICMaSTQpwfYr pDYHHkJQEbAKNjNyvKAslrajkCZIb;

			private PsAnRFoXZVCPLNyfCHpsvaxBALYi XPocpAvDMFoZMlCVraFrgSyTqYVT;

			public PsAnRFoXZVCPLNyfCHpsvaxBALYi IofKlZTxPeSLiKWeNaitEaxpvsFt;

			private UsGNQBNBgNZUhlYjbPkaBwgidHLU fXylyqonQvFaRxghWtWTxgAbrMvW;

			public UsGNQBNBgNZUhlYjbPkaBwgidHLU NlueDwkhPGGHAgZdBxuhhgSGdjdsb;

			private int mVzaWRbvPVJGmelFyLUgJgoaWenE;

			private int qntiJEaJDuIjxSVtqrtVLDfvjDqt;

			DTYuUedmDfITSBrmYZQCMQrVXAot IEnumerator<DTYuUedmDfITSBrmYZQCMQrVXAot>.Current
			{
				[DebuggerHidden]
				get
				{
					return toZqhZJcORGyYuIqIDogbAoiOnwB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return toZqhZJcORGyYuIqIDogbAoiOnwB;
				}
			}

			[DebuggerHidden]
			public WNZzCsGylevnMloHrXnqglmmLBzE(int P_0)
			{
				QZPlYDhulxfVgyFftEexhvUeoiRfb = P_0;
				GfYSQphCTYIvFfqtWeZQTlBjSFoV = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int qZPlYDhulxfVgyFftEexhvUeoiRfb = QZPlYDhulxfVgyFftEexhvUeoiRfb;
				KxbYasQTjZJkSyCaICMaSTQpwfYr kxbYasQTjZJkSyCaICMaSTQpwfYr = pDYHHkJQEbAKNjNyvKAslrajkCZIb;
				if (qZPlYDhulxfVgyFftEexhvUeoiRfb != 0)
				{
					if (qZPlYDhulxfVgyFftEexhvUeoiRfb != 1)
					{
						return false;
					}
					QZPlYDhulxfVgyFftEexhvUeoiRfb = -1;
					goto IL_0083;
				}
				QZPlYDhulxfVgyFftEexhvUeoiRfb = -1;
				mVzaWRbvPVJGmelFyLUgJgoaWenE = kxbYasQTjZJkSyCaICMaSTQpwfYr.IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count;
				qntiJEaJDuIjxSVtqrtVLDfvjDqt = 0;
				goto IL_0093;
				IL_0083:
				qntiJEaJDuIjxSVtqrtVLDfvjDqt++;
				goto IL_0093;
				IL_0093:
				if (qntiJEaJDuIjxSVtqrtVLDfvjDqt < mVzaWRbvPVJGmelFyLUgJgoaWenE)
				{
					if (kxbYasQTjZJkSyCaICMaSTQpwfYr.IyHdVkALnDoDvHXZHnboHcUlMdGfc[qntiJEaJDuIjxSVtqrtVLDfvjDqt].tryBhsckAaIzgiAJRQTzOXfiBBPbb(XPocpAvDMFoZMlCVraFrgSyTqYVT, fXylyqonQvFaRxghWtWTxgAbrMvW))
					{
						toZqhZJcORGyYuIqIDogbAoiOnwB = kxbYasQTjZJkSyCaICMaSTQpwfYr.IyHdVkALnDoDvHXZHnboHcUlMdGfc[qntiJEaJDuIjxSVtqrtVLDfvjDqt];
						QZPlYDhulxfVgyFftEexhvUeoiRfb = 1;
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
			IEnumerator<DTYuUedmDfITSBrmYZQCMQrVXAot> IEnumerable<DTYuUedmDfITSBrmYZQCMQrVXAot>.GetEnumerator()
			{
				WNZzCsGylevnMloHrXnqglmmLBzE wNZzCsGylevnMloHrXnqglmmLBzE;
				if (QZPlYDhulxfVgyFftEexhvUeoiRfb == -2 && GfYSQphCTYIvFfqtWeZQTlBjSFoV == Environment.CurrentManagedThreadId)
				{
					QZPlYDhulxfVgyFftEexhvUeoiRfb = 0;
					wNZzCsGylevnMloHrXnqglmmLBzE = this;
				}
				else
				{
					wNZzCsGylevnMloHrXnqglmmLBzE = new WNZzCsGylevnMloHrXnqglmmLBzE(0);
					wNZzCsGylevnMloHrXnqglmmLBzE.pDYHHkJQEbAKNjNyvKAslrajkCZIb = pDYHHkJQEbAKNjNyvKAslrajkCZIb;
				}
				wNZzCsGylevnMloHrXnqglmmLBzE.XPocpAvDMFoZMlCVraFrgSyTqYVT = IofKlZTxPeSLiKWeNaitEaxpvsFt;
				wNZzCsGylevnMloHrXnqglmmLBzE.fXylyqonQvFaRxghWtWTxgAbrMvW = NlueDwkhPGGHAgZdBxuhhgSGdjdsb;
				return wNZzCsGylevnMloHrXnqglmmLBzE;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<DTYuUedmDfITSBrmYZQCMQrVXAot>)this).GetEnumerator();
			}
		}

		private List<DTYuUedmDfITSBrmYZQCMQrVXAot> IyHdVkALnDoDvHXZHnboHcUlMdGfc;

		public KxbYasQTjZJkSyCaICMaSTQpwfYr()
		{
			IyHdVkALnDoDvHXZHnboHcUlMdGfc = new List<DTYuUedmDfITSBrmYZQCMQrVXAot>();
		}

		public void hJPwthDecAFRMVQHivkuGLTIAyjEA(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count;
			for (int i = 0; i < count; i++)
			{
				if (IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].tryBhsckAaIzgiAJRQTzOXfiBBPbb(P_0, UsGNQBNBgNZUhlYjbPkaBwgidHLU.Exact))
				{
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].theChBjZCqKuzdHpFUITiqougwpu = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].yvCmJWCPOtZEITzwWHicRCoSLsqF = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].hIlOcnFfoLPhjloDafWHuDNkQazI = P_0.ZJCbKwIgkEiHAvPpRLVvZRvobdViA;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].PRbrxnrCMQOpzdyBQfOiSZETUQNy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].ojVsCuWDaxFDwJFBDjNKXeRSCjFiA = P_0.qKjzDhbAFLatokrBnyHFMHppIdWvA;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].RVgcknhKGGQOvtUZzSCxfIedTwTX = P_0.AqNmTzfrngcvaftwUChjtBJNSNBn;
					IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].yplaNTdOjiVhwPnBskSOvNzZEgBO = P_0.mGMdnbwkuHlLZnTozAwGpzOZilLg;
					tApBpSvJDaXiSWyBvVvrSqayhNAjA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			IyHdVkALnDoDvHXZHnboHcUlMdGfc.Add(new DTYuUedmDfITSBrmYZQCMQrVXAot
			{
				theChBjZCqKuzdHpFUITiqougwpu = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				yvCmJWCPOtZEITzwWHicRCoSLsqF = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				hIlOcnFfoLPhjloDafWHuDNkQazI = P_0.ZJCbKwIgkEiHAvPpRLVvZRvobdViA,
				PRbrxnrCMQOpzdyBQfOiSZETUQNy = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				ojVsCuWDaxFDwJFBDjNKXeRSCjFiA = P_0.qKjzDhbAFLatokrBnyHFMHppIdWvA,
				RVgcknhKGGQOvtUZzSCxfIedTwTX = P_0.AqNmTzfrngcvaftwUChjtBJNSNBn,
				yplaNTdOjiVhwPnBskSOvNzZEgBO = P_0.mGMdnbwkuHlLZnTozAwGpzOZilLg
			});
			tApBpSvJDaXiSWyBvVvrSqayhNAjA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count - 1);
		}

		public bool bYxvlpbOtZzmMpjGCGpvGQmCsgsAA(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, UsGNQBNBgNZUhlYjbPkaBwgidHLU P_1)
		{
			int count = IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count;
			for (int i = 0; i < count; i++)
			{
				if (IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].tryBhsckAaIzgiAJRQTzOXfiBBPbb(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(WNZzCsGylevnMloHrXnqglmmLBzE))]
		public IEnumerable<DTYuUedmDfITSBrmYZQCMQrVXAot> vPPSYtxrpLoHuUGpopFdAkySbLmr(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, UsGNQBNBgNZUhlYjbPkaBwgidHLU P_1)
		{
			return new WNZzCsGylevnMloHrXnqglmmLBzE(-2)
			{
				pDYHHkJQEbAKNjNyvKAslrajkCZIb = this,
				IofKlZTxPeSLiKWeNaitEaxpvsFt = P_0,
				NlueDwkhPGGHAgZdBxuhhgSGdjdsb = P_1
			};
		}

		private void tApBpSvJDaXiSWyBvVvrSqayhNAjA(int P_0, Guid P_1, int P_2)
		{
			for (int num = IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (IyHdVkALnDoDvHXZHnboHcUlMdGfc[num].theChBjZCqKuzdHpFUITiqougwpu == P_0 || IyHdVkALnDoDvHXZHnboHcUlMdGfc[num].yvCmJWCPOtZEITzwWHicRCoSLsqF == P_1))
				{
					IyHdVkALnDoDvHXZHnboHcUlMdGfc.RemoveAt(num);
				}
			}
		}

		public virtual string tWcFCgrcCRszLBdrsnjRynyhfiVIA()
		{
			string text = "";
			text = text + "Joystick records: " + IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count + "\n";
			for (int i = 0; i < IyHdVkALnDoDvHXZHnboHcUlMdGfc.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + IyHdVkALnDoDvHXZHnboHcUlMdGfc[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class fQVErFwZfYAeNldNqFlmAqpkgPCe
	{
		public PsAnRFoXZVCPLNyfCHpsvaxBALYi QdqqdWyUFrDmgHmJnBbLfDaFGGiIA;

		public zxeoTygAWuodzEbOIdaTbdNJPkfzA kBsRGkvYxAMgIwHeeRYbzvuScWhM;

		public bool RwWARFToMxCORmClXnUySyINjroi
		{
			get
			{
				if (QdqqdWyUFrDmgHmJnBbLfDaFGGiIA != null)
				{
					return kBsRGkvYxAMgIwHeeRYbzvuScWhM != null;
				}
				return false;
			}
		}

		public fQVErFwZfYAeNldNqFlmAqpkgPCe(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, zxeoTygAWuodzEbOIdaTbdNJPkfzA P_1)
		{
			QdqqdWyUFrDmgHmJnBbLfDaFGGiIA = P_0;
			kBsRGkvYxAMgIwHeeRYbzvuScWhM = P_1;
		}

		public static List<zxeoTygAWuodzEbOIdaTbdNJPkfzA> RqoIAuCuFYeDLqMUpVmXnpJxVaRC(List<fQVErFwZfYAeNldNqFlmAqpkgPCe> P_0)
		{
			if (P_0 == null)
			{
				return new List<zxeoTygAWuodzEbOIdaTbdNJPkfzA>();
			}
			List<zxeoTygAWuodzEbOIdaTbdNJPkfzA> list = new List<zxeoTygAWuodzEbOIdaTbdNJPkfzA>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].RwWARFToMxCORmClXnUySyINjroi)
				{
					list.Add(P_0[i].kBsRGkvYxAMgIwHeeRYbzvuScWhM);
				}
			}
			return list;
		}
	}

	private class NwNWrvfBsHstDUqcWxmIVjbUVGnB
	{
		public jmiDTsUKFPYQFBYgXXnbDNCMRcXj EZRUgDPlhjkHSMppVakCGXTHpYvL;

		public NwNWrvfBsHstDUqcWxmIVjbUVGnB(jmiDTsUKFPYQFBYgXXnbDNCMRcXj P_0)
		{
			EZRUgDPlhjkHSMppVakCGXTHpYvL = P_0;
		}
	}

	private class yssfKrivWakmhpFtIorVLvpvPFgeA
	{
		private MOZStyWbbwrJOgdsTsPiZRRqNFzj.pYcGQNqvOVpkMunGNuOZXbVUAKaU zCnyFyVHCxDHabjLUJuzknWLYmDs;

		private MOZStyWbbwrJOgdsTsPiZRRqNFzj.qKEcdHQQuroQXggVIJjwigTVCLsl RruvZNRYYtfwBwhTcxjcLjnbXFcD;

		private NativeBuffer UaWjulDJIqNdkJQnhjmNzvYmCAuI;

		private int TQaiUWXSSZrLaiXSgDAKzxxajCtM;

		public yssfKrivWakmhpFtIorVLvpvPFgeA()
		{
			zCnyFyVHCxDHabjLUJuzknWLYmDs = new MOZStyWbbwrJOgdsTsPiZRRqNFzj.pYcGQNqvOVpkMunGNuOZXbVUAKaU
			{
				mBzTPinacwFxafpBtmbXPLFTfrChb = (uint)Marshal.SizeOf(typeof(MOZStyWbbwrJOgdsTsPiZRRqNFzj.pYcGQNqvOVpkMunGNuOZXbVUAKaU)),
				yjTOvoeekZFwoGSIaLWxdhgjpOsX = true,
				AFlznGaWmyWCzTmGIpSuVEmIvXom = true,
				hFBeOsHiNqlZLTRFKNnLnpsqoLbNA = false,
				BqWEvIhYoHtstwzlgkhjLEwqGaHS = true,
				thFWetJqjOqYlZtugkueATyKvEDl = IntPtr.Zero
			};
			RruvZNRYYtfwBwhTcxjcLjnbXFcD = MOZStyWbbwrJOgdsTsPiZRRqNFzj.qKEcdHQQuroQXggVIJjwigTVCLsl.UvsZvAocmtOgtneRXxluMarvuZdE();
			UaWjulDJIqNdkJQnhjmNzvYmCAuI = new NativeBuffer((int)RruvZNRYYtfwBwhTcxjcLjnbXFcD.QHpVhlxJWwFfsDbpRdRaatldoXwwA);
			UaWjulDJIqNdkJQnhjmNzvYmCAuI.Write(RruvZNRYYtfwBwhTcxjcLjnbXFcD.QHpVhlxJWwFfsDbpRdRaatldoXwwA, 0);
		}

		public bool zzWWnMudubaTTnXVFdUZGrpNVxof()
		{
			int num = gubqjIEHyDRxTbxabcIIYuTGPFBu();
			if (num == TQaiUWXSSZrLaiXSgDAKzxxajCtM)
			{
				return false;
			}
			TQaiUWXSSZrLaiXSgDAKzxxajCtM = num;
			return true;
		}

		public void wDfWBAEsdpKUWMAAbgSpAmVwwcqg(int P_0)
		{
			TQaiUWXSSZrLaiXSgDAKzxxajCtM = P_0;
		}

		private int gubqjIEHyDRxTbxabcIIYuTGPFBu()
		{
			try
			{
				return oymLFibOtnrrwNkvVefVAYWlRuLG.HUXDfeyUiNnlPftfMtzHxRryumMD(ref zCnyFyVHCxDHabjLUJuzknWLYmDs, UaWjulDJIqNdkJQnhjmNzvYmCAuI);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum VAaoGYMiyFsYsJBkYQMoTZOXkiKl
	{
		Device = 17,
		Mouse = 18,
		Keyboard = 19,
		Joystick = 20,
		Gamepad = 21,
		Driving = 22,
		Flight = 23,
		FirstPerson = 24,
		ControlDevice = 25,
		ScreenPointer = 26,
		Remote = 27,
		Supplemental = 28
	}

	private const VLvQcNuaSLlqeeafybsvEUaykbhq wnDBSjwjcOnbqwJoBExfaOQRwqmV = VLvQcNuaSLlqeeafybsvEUaykbhq.GameControl;

	private const pnJfJlKSvYRtZdzwwioLpnYQNhYbb AhcvGJkeJcsJMxEqvXpdXCzDyDKD = pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly;

	private IntPtr eAnnhJWEsNLulZamEvpmyHuxDxghA;

	private kHulolaiHHHtqEyPXwgoOKOviJQAb pEziqwcbImzBDdiCVhGCuMrzKDle;

	private List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> IdfaftUBXaTsuZflIRIlUZaKWGLq;

	private int QqzjecwddDFPGmnxBVAOpqrSeNtf;

	private KxbYasQTjZJkSyCaICMaSTQpwfYr MpVzuWTDGKCWmnvMFjMKjhXNfleD;

	private bool ffhdOXmbepoojfUhUTQleaCbNgtl;

	private bool JGsbAfCIofKovwQJrWvjuzDGBYGuA;

	private UpdateLoopSetting uVqGJsRbzBApfBgoAxcnXNTcgYoe;

	private Action<int, ControllerDataUpdater> btaZfxlwJQcmItmDgGEtYqYscznf;

	private PlatformInputManager xiTMFeCGVoUygfiFNFqCIKowGwAaA;

	private TimerRealTime xYdiQjyKIsISvJfZKNfNoHGIgYkAA;

	private global::LLuerUMhyjncgwVxBNqCJPLVjyLE<bool> lsVvGNylmkdPjqlVtaiKwgZKEvMw;

	private yssfKrivWakmhpFtIorVLvpvPFgeA SFfvmOrdCyVzlaRyfedaGhitzVU;

	private int WSdOsPpFraceEJZACAnzSzCdoiPdA;

	private int pbxBoSbSFWZEPUYAqbDNBQZsmJKvA;

	private global::LLuerUMhyjncgwVxBNqCJPLVjyLE<List<fQVErFwZfYAeNldNqFlmAqpkgPCe>> zTftfUxYsFFEBYjWVAHzWWQqZMEv;

	private readonly object qbjnCVjqUAeIjdgLzlzAFfPEfCnYb = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> rzCdCMEngRIXLYFudQqMUvQfjioh;

	private Func<int> qtfbYDSASXCbwzBgdpYHuKeVfqKc;

	bool gcpwKCRbatOImQkjFmQXegHCctcx.pWHVLXJvtZaNjMbaMDeQcrLhbtlAA
	{
		set
		{
			JGsbAfCIofKovwQJrWvjuzDGBYGuA = jGsbAfCIofKovwQJrWvjuzDGBYGuA;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => QqzjecwddDFPGmnxBVAOpqrSeNtf;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => xiTMFeCGVoUygfiFNFqCIKowGwAaA;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<kHulolaiHHHtqEyPXwgoOKOviJQAb>(pEziqwcbImzBDdiCVhGCuMrzKDle);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public jSzyivpKikIcKFnbBCmdglPWWQPZA(UpdateLoopSetting P_0, bool P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			uVqGJsRbzBApfBgoAxcnXNTcgYoe = P_0;
			JGsbAfCIofKovwQJrWvjuzDGBYGuA = P_1;
			eAnnhJWEsNLulZamEvpmyHuxDxghA = P_2;
			rzCdCMEngRIXLYFudQqMUvQfjioh = P_3;
			qtfbYDSASXCbwzBgdpYHuKeVfqKc = P_4;
			xiTMFeCGVoUygfiFNFqCIKowGwAaA = this;
			pEziqwcbImzBDdiCVhGCuMrzKDle = new kHulolaiHHHtqEyPXwgoOKOviJQAb();
			btaZfxlwJQcmItmDgGEtYqYscznf = UpdateControllerData;
			SFfvmOrdCyVzlaRyfedaGhitzVU = new yssfKrivWakmhpFtIorVLvpvPFgeA();
			lsVvGNylmkdPjqlVtaiKwgZKEvMw = new global::LLuerUMhyjncgwVxBNqCJPLVjyLE<bool>(true, mTFZGvxrBYmSadXmnOWLgeCtaVHFA);
			zTftfUxYsFFEBYjWVAHzWWQqZMEv = new global::LLuerUMhyjncgwVxBNqCJPLVjyLE<List<fQVErFwZfYAeNldNqFlmAqpkgPCe>>(true, () => xQmoZahdLkZslcgIcfdUhVMLNRhu());
			RRuEiTkbLJVGeoTKjdSWYkcmmwJfA();
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
		MpVzuWTDGKCWmnvMFjMKjhXNfleD = new KxbYasQTjZJkSyCaICMaSTQpwfYr();
		xYdiQjyKIsISvJfZKNfNoHGIgYkAA = new TimerRealTime(1.0);
		xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Start();
		ppChCUCYgvflxzBgReVBUOsOFRTJA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		MeErJZJhXjgyjDHPwlGpZUzCefgh();
		cMzIiHaqIHhFZLQuZZCduroNDCMg();
		rmfgFgHbJFgigdppvEDMnqOuPsjcb();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (zTftfUxYsFFEBYjWVAHzWWQqZMEv != null)
		{
			zTftfUxYsFFEBYjWVAHzWWQqZMEv.bkHmwKfdIczaMGhYiGtzFjzCYJlw();
		}
		if (lsVvGNylmkdPjqlVtaiKwgZKEvMw != null)
		{
			lsVvGNylmkdPjqlVtaiKwgZKEvMw.bkHmwKfdIczaMGhYiGtzFjzCYJlw();
		}
		if (IdfaftUBXaTsuZflIRIlUZaKWGLq == null)
		{
			return;
		}
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			for (int i = 0; i < IdfaftUBXaTsuZflIRIlUZaKWGLq.Count; i++)
			{
				if (IdfaftUBXaTsuZflIRIlUZaKWGLq[i] != null)
				{
					IdfaftUBXaTsuZflIRIlUZaKWGLq[i].kRARaCujCWgsRFwgmdwjleyRtRCEA();
					IdfaftUBXaTsuZflIRIlUZaKWGLq[i].QrdMzxiisMRKRsQnktTJMYEFCtxA();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return btaZfxlwJQcmItmDgGEtYqYscznf;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			for (int i = 0; i < QqzjecwddDFPGmnxBVAOpqrSeNtf; i++)
			{
				if (IdfaftUBXaTsuZflIRIlUZaKWGLq[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					IdfaftUBXaTsuZflIRIlUZaKWGLq[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		ffhdOXmbepoojfUhUTQleaCbNgtl = true;
		xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		ffhdOXmbepoojfUhUTQleaCbNgtl = true;
		xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Start();
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

	private void MeErJZJhXjgyjDHPwlGpZUzCefgh()
	{
		if (lsVvGNylmkdPjqlVtaiKwgZKEvMw.snsDQUpOcRaGRKbTkYpwRvywuGYh)
		{
			if (lsVvGNylmkdPjqlVtaiKwgZKEvMw.iuGaMmcGKafyNfJkNqVWhILJWPAm() && !xYdiQjyKIsISvJfZKNfNoHGIgYkAA.running && !zTftfUxYsFFEBYjWVAHzWWQqZMEv.snsDQUpOcRaGRKbTkYpwRvywuGYh)
			{
				if (lsVvGNylmkdPjqlVtaiKwgZKEvMw.adAzQMLivFAMfDeoAKPmjfzQvGQr)
				{
					ffhdOXmbepoojfUhUTQleaCbNgtl = true;
				}
				xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Start();
			}
		}
		else if (!xYdiQjyKIsISvJfZKNfNoHGIgYkAA.running)
		{
			xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Start();
		}
		else if (xYdiQjyKIsISvJfZKNfNoHGIgYkAA.Update())
		{
			lsVvGNylmkdPjqlVtaiKwgZKEvMw.SgOnxhdhoJMkOXBTPqeBcreyDTgn();
		}
	}

	private List<fQVErFwZfYAeNldNqFlmAqpkgPCe> xQmoZahdLkZslcgIcfdUhVMLNRhu()
	{
		List<fQVErFwZfYAeNldNqFlmAqpkgPCe> list = new List<fQVErFwZfYAeNldNqFlmAqpkgPCe>();
		IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> list2 = oiTArfHEeYzLlqWwwbbYwugfNnrmA();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				zxeoTygAWuodzEbOIdaTbdNJPkfzA zxeoTygAWuodzEbOIdaTbdNJPkfzA2 = list2[i];
				Guid htnaQuDxVHZJAgkNHGcRfsCbXIkP = zxeoTygAWuodzEbOIdaTbdNJPkfzA2.HtnaQuDxVHZJAgkNHGcRfsCbXIkP;
				jmiDTsUKFPYQFBYgXXnbDNCMRcXj jmiDTsUKFPYQFBYgXXnbDNCMRcXj2 = new jmiDTsUKFPYQFBYgXXnbDNCMRcXj(pEziqwcbImzBDdiCVhGCuMrzKDle, htnaQuDxVHZJAgkNHGcRfsCbXIkP);
				SZRZOcFvpvoeQgknTIEbEGLZnLkg sZRZOcFvpvoeQgknTIEbEGLZnLkg = jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.sXDSFEegzIGHJfFPzuVoJnPazfEEA;
				bool flag = false;
				if (!JGsbAfCIofKovwQJrWvjuzDGBYGuA)
				{
					goto IL_008c;
				}
				flag = iJBgwMICNtsxCQITcDMiEfutRJOA.nsFVRFMKeqbpXkshgJjJxgkLGncZ(sZRZOcFvpvoeQgknTIEbEGLZnLkg.ypNqxrkTitVctugqKxiAcZWehkIU, StringTools.SanitizeDeviceString(zxeoTygAWuodzEbOIdaTbdNJPkfzA2.uOXIriiYjCRnxlHeUPJeHhWUdUCB), string.Empty, zxeoTygAWuodzEbOIdaTbdNJPkfzA2.hdueOrdlMvKpdcNivQkyMEDscIuS);
				if (!flag)
				{
					goto IL_008c;
				}
				goto end_IL_0028;
				IL_008c:
				Guid guid = ((!string.IsNullOrEmpty(sZRZOcFvpvoeQgknTIEbEGLZnLkg.ypNqxrkTitVctugqKxiAcZWehkIU)) ? MiscTools.CreateGuidHashSHA256(sZRZOcFvpvoeQgknTIEbEGLZnLkg.ypNqxrkTitVctugqKxiAcZWehkIU) : zxeoTygAWuodzEbOIdaTbdNJPkfzA2.HtnaQuDxVHZJAgkNHGcRfsCbXIkP);
				bool flag2 = false;
				lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
				{
					if (IdfaftUBXaTsuZflIRIlUZaKWGLq != null)
					{
						for (int j = 0; j < IdfaftUBXaTsuZflIRIlUZaKWGLq.Count; j++)
						{
							if (IdfaftUBXaTsuZflIRIlUZaKWGLq[j] != null && IdfaftUBXaTsuZflIRIlUZaKWGLq[j].ftGGzFdLlvwNxVfadmUwEEKGDIofB == guid)
							{
								jmiDTsUKFPYQFBYgXXnbDNCMRcXj2 = IdfaftUBXaTsuZflIRIlUZaKWGLq[j].VYaelqDNEmXCfBgvJjdzbdadDIuRA.VlPtUFgOsOtaZwSydthtHZgOPEJV;
								flag2 = true;
								break;
							}
						}
					}
				}
				PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = new PsAnRFoXZVCPLNyfCHpsvaxBALYi(new LULJRRBiGsDrlsRcrtYctFCnDxsN(jmiDTsUKFPYQFBYgXXnbDNCMRcXj2, uVqGJsRbzBApfBgoAxcnXNTcgYoe), rzCdCMEngRIXLYFudQqMUvQfjioh);
				psAnRFoXZVCPLNyfCHpsvaxBALYi.aTEvJQQIXHoKGgRYSQwnGWuPFGdI = zxeoTygAWuodzEbOIdaTbdNJPkfzA2;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.dQQTAPdrLnlKYtSrjLzKSAQsJSZL = zxeoTygAWuodzEbOIdaTbdNJPkfzA2.esxMiZsFdBkElbwiIphKIUVqaQbu;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.ftGGzFdLlvwNxVfadmUwEEKGDIofB = guid;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.rcXDaYwMeEKknjayUvhpiJxBCkZfA = StringTools.SanitizeDeviceString(zxeoTygAWuodzEbOIdaTbdNJPkfzA2.uOXIriiYjCRnxlHeUPJeHhWUdUCB);
				psAnRFoXZVCPLNyfCHpsvaxBALYi.BYexPClfKRemOAfJoRPKlNvaqNAn = zxeoTygAWuodzEbOIdaTbdNJPkfzA2.hdueOrdlMvKpdcNivQkyMEDscIuS;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.PEPBYDGdMlEwryRdTGvJmyPGKyUQA = (VAaoGYMiyFsYsJBkYQMoTZOXkiKl)zxeoTygAWuodzEbOIdaTbdNJPkfzA2.VLrEFwxaqUQKXtPyqYaSrUWrbYGv;
				tLNnxKVRxIoHaBaCzJQDHyYDRBTl tLNnxKVRxIoHaBaCzJQDHyYDRBTl2 = jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.OfVKqIDBopiIsKkbUgUZRuDOHWzK;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.gaidNLKjVNzSYwWLCQLULHEOfeOBA = sZRZOcFvpvoeQgknTIEbEGLZnLkg.UZzQBKRfDcFxdsMfUJUcNtScDBte;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.ybJaHfSbxtHAQOPHOmHRBFYhFnzT = flag;
				try
				{
					psAnRFoXZVCPLNyfCHpsvaxBALYi.MVbWGHQqbzXxpRXAUQjpHdBpxZFl = sZRZOcFvpvoeQgknTIEbEGLZnLkg.dHGViCNLMxIyumOVHooNEEMWMMlK;
				}
				catch (Exception)
				{
					psAnRFoXZVCPLNyfCHpsvaxBALYi.MVbWGHQqbzXxpRXAUQjpHdBpxZFl = 0;
				}
				psAnRFoXZVCPLNyfCHpsvaxBALYi.qKjzDhbAFLatokrBnyHFMHppIdWvA = tLNnxKVRxIoHaBaCzJQDHyYDRBTl2.BUpPQbOPJqabGYXEBvJDNXdjPmFu;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.AqNmTzfrngcvaftwUChjtBJNSNBn = tLNnxKVRxIoHaBaCzJQDHyYDRBTl2.VwzgdefkBUxKPQWWTBdoFkdfOyhWA;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.mGMdnbwkuHlLZnTozAwGpzOZilLg = tLNnxKVRxIoHaBaCzJQDHyYDRBTl2.gQcLwFJCKehJFBEPbcXGPRqyaJhH;
				pucYkkroLSaCiuTZezfCtIoQcDMb(psAnRFoXZVCPLNyfCHpsvaxBALYi, sZRZOcFvpvoeQgknTIEbEGLZnLkg, out psAnRFoXZVCPLNyfCHpsvaxBALYi.zSfgsHFwqDLSOUcFoBPkIZzvkNYq);
				try
				{
					string productName;
					try
					{
						productName = sZRZOcFvpvoeQgknTIEbEGLZnLkg.OpfLWPeEZmjjyJijegHARxyWthUD;
					}
					catch
					{
						productName = psAnRFoXZVCPLNyfCHpsvaxBALYi.rcXDaYwMeEKknjayUvhpiJxBCkZfA;
					}
					if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.HPAdQBfoTuIsfMObrTWaAZrfYWCP, (ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.UZzQBKRfDcFxdsMfUJUcNtScDBte, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.HPAdQBfoTuIsfMObrTWaAZrfYWCP, (ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.UZzQBKRfDcFxdsMfUJUcNtScDBte, productName, out var min, out var max, out var zero))
					{
						psAnRFoXZVCPLNyfCHpsvaxBALYi.VYaelqDNEmXCfBgvJjdzbdadDIuRA.CKjEiQaIyTCwvUnxcQpskDdgLIZH(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.HPAdQBfoTuIsfMObrTWaAZrfYWCP, (ushort)sZRZOcFvpvoeQgknTIEbEGLZnLkg.UZzQBKRfDcFxdsMfUJUcNtScDBte, productName));
					}
				}
				catch (Exception)
				{
				}
				if (!flag2)
				{
					IList<IAgdmKbxxCierJHKqWSFAjDwBDjEb> list3 = jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.fWtXYVUCSWZikKkfLUGZZPfKcqQG();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].aLWciJOjBCisHJVTCYpDOCixDlsO.yrYglbiJtyhblKhgSIEStyVbbMuYA & ohTLfsCnqDzhumcBDNxmtssJOYWS.Axis) != ohTLfsCnqDzhumcBDNxmtssJOYWS.All)
							{
								jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.sXDSFEegzIGHJfFPzuVoJnPazfEEA.vTMlomscYJERfBLYoLyKSSDbmdHI = new ZwzuTTMVBnDuEVKaTDvIbKtEjZPCb(-65535, 65535);
							}
						}
					}
					jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.sXDSFEegzIGHJfFPzuVoJnPazfEEA.LSyUpHldtGDUPYgTIgNEMrPjlQjM = THkfkXGotekDMStrkHTzacchnjuRB.Absolute;
					jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.YcWLEXqQnoIaAqcpIfXhHiKYnjFEb(eAnnhJWEsNLulZamEvpmyHuxDxghA, uPgPOmkhanidvQEINqQfPcVCTSiB.NonExclusive | uPgPOmkhanidvQEINqQfPcVCTSiB.Background);
					jmiDTsUKFPYQFBYgXXnbDNCMRcXj2.AGcUmdNvzDHZZmFwBKCGcWkvflUG();
				}
				list.Add(new fQVErFwZfYAeNldNqFlmAqpkgPCe(psAnRFoXZVCPLNyfCHpsvaxBALYi, zxeoTygAWuodzEbOIdaTbdNJPkfzA2));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void ppChCUCYgvflxzBgReVBUOsOFRTJA()
	{
		XqyBbDCTtUXcxAJLCNcQkXwKjMVEA(xQmoZahdLkZslcgIcfdUhVMLNRhu());
	}

	private void XqyBbDCTtUXcxAJLCNcQkXwKjMVEA(List<fQVErFwZfYAeNldNqFlmAqpkgPCe> P_0)
	{
		List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> list = new List<PsAnRFoXZVCPLNyfCHpsvaxBALYi>();
		WSdOsPpFraceEJZACAnzSzCdoiPdA = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].RwWARFToMxCORmClXnUySyINjroi)
			{
				continue;
			}
			try
			{
				PsAnRFoXZVCPLNyfCHpsvaxBALYi qdqqdWyUFrDmgHmJnBbLfDaFGGiIA = P_0[i].QdqqdWyUFrDmgHmJnBbLfDaFGGiIA;
				qdqqdWyUFrDmgHmJnBbLfDaFGGiIA.HhrivJUWWCRRugasimAoQeqKwSMR();
				if (qdqqdWyUFrDmgHmJnBbLfDaFGGiIA.IXjcVnIzVMMzTvZRvUGeXRorqgTL)
				{
					WSdOsPpFraceEJZACAnzSzCdoiPdA++;
				}
				list.Add(qdqqdWyUFrDmgHmJnBbLfDaFGGiIA);
			}
			catch (Exception)
			{
			}
		}
		SFfvmOrdCyVzlaRyfedaGhitzVU.wDfWBAEsdpKUWMAAbgSpAmVwwcqg(WSdOsPpFraceEJZACAnzSzCdoiPdA);
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> idfaftUBXaTsuZflIRIlUZaKWGLq = IdfaftUBXaTsuZflIRIlUZaKWGLq;
			int qqzjecwddDFPGmnxBVAOpqrSeNtf = QqzjecwddDFPGmnxBVAOpqrSeNtf;
			int count = list.Count;
			invlbTuqYUBLyhoglGpmLsHobFQJA(qqzjecwddDFPGmnxBVAOpqrSeNtf, count, idfaftUBXaTsuZflIRIlUZaKWGLq, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			GNZcExXyYIaRUpcVECANkIvTdIFX(idfaftUBXaTsuZflIRIlUZaKWGLq, list, false);
			GNZcExXyYIaRUpcVECANkIvTdIFX(list, idfaftUBXaTsuZflIRIlUZaKWGLq, true);
			stIGRXEzdEMIyuvsIWihjbcYmukW(list, idfaftUBXaTsuZflIRIlUZaKWGLq);
			IdfaftUBXaTsuZflIRIlUZaKWGLq = list;
			QqzjecwddDFPGmnxBVAOpqrSeNtf = list.Count;
		}
	}

	private void pucYkkroLSaCiuTZezfCtIoQcDMb(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, SZRZOcFvpvoeQgknTIEbEGLZnLkg P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = mnqxbYGwQINVXmoGTDtfkBLLYwkeA.nmVOPxzAiHzjSpdAwWgIrCdpKjDu(P_1.ypNqxrkTitVctugqKxiAcZWehkIU);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			tmIanFBEFfADwAijJlMTSoVSsCpuB tmIanFBEFfADwAijJlMTSoVSsCpuB2 = oymLFibOtnrrwNkvVefVAYWlRuLG.gHjaYdTKfQaPYDGmLsvprWEtztxPA(text.ToLower(CultureInfo.InvariantCulture));
			if (tmIanFBEFfADwAijJlMTSoVSsCpuB2 != null)
			{
				P_0.IXjcVnIzVMMzTvZRvUGeXRorqgTL = tmIanFBEFfADwAijJlMTSoVSsCpuB2.nlyBYhmQcPybNheOlhiPCMWDUUVD;
				P_0.ucgaIHHkOUiZHiAciGsosMzLxKYE = tmIanFBEFfADwAijJlMTSoVSsCpuB2.rxiReLEZcveLbWOugGlmGwqmRBfP;
				P_2 = ZBpRTWwxkbUTtbRqnOjmekgVugdF.ggHbEQncEAcHjjTFfGHnFynECNGU(tmIanFBEFfADwAijJlMTSoVSsCpuB2, P_0.BYexPClfKRemOAfJoRPKlNvaqNAn, P_0.rcXDaYwMeEKknjayUvhpiJxBCkZfA, P_0.ucgaIHHkOUiZHiAciGsosMzLxKYE);
				tmIanFBEFfADwAijJlMTSoVSsCpuB2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void rmfgFgHbJFgigdppvEDMnqOuPsjcb()
	{
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			for (int i = 0; i < QqzjecwddDFPGmnxBVAOpqrSeNtf; i++)
			{
				try
				{
					PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = IdfaftUBXaTsuZflIRIlUZaKWGLq[i];
					if (psAnRFoXZVCPLNyfCHpsvaxBALYi != null && psAnRFoXZVCPLNyfCHpsvaxBALYi.cvuPgZujhYknfDShJxpakTNrocXg() && (!JGsbAfCIofKovwQJrWvjuzDGBYGuA || !psAnRFoXZVCPLNyfCHpsvaxBALYi.ybJaHfSbxtHAQOPHOmHRBFYhFnzT))
					{
						psAnRFoXZVCPLNyfCHpsvaxBALYi.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> oiTArfHEeYzLlqWwwbbYwugfNnrmA()
	{
		try
		{
			IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> list = pEziqwcbImzBDdiCVhGCuMrzKDle.LbAmUIpjiYaToBfvvmjVybogrgveA(VLvQcNuaSLlqeeafybsvEUaykbhq.GameControl, pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly);
			pbxBoSbSFWZEPUYAqbDNBQZsmJKvA = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			pbxBoSbSFWZEPUYAqbDNBQZsmJKvA = 0;
			return EmptyObjects<zxeoTygAWuodzEbOIdaTbdNJPkfzA>.EmptyReadOnlyIListT;
		}
	}

	private void RRuEiTkbLJVGeoTKjdSWYkcmmwJfA()
	{
		pEziqwcbImzBDdiCVhGCuMrzKDle.tMZuXUwmRelPRMBWsyUedZCFTVnu();
	}

	private void invlbTuqYUBLyhoglGpmLsHobFQJA(int P_0, int P_1, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_2, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(PsAnRFoXZVCPLNyfCHpsvaxBALYi.UoCETYGdHhPiZBVSbqPDVgjBllku);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			PcDnVKASEUBktuCSSKXPyzeONHbb(P_1, P_3, P_0, P_2, KxbYasQTjZJkSyCaICMaSTQpwfYr.UsGNQBNBgNZUhlYjbPkaBwgidHLU.Exact);
		}
		nXzmCrugLpbbjUCMKGVLALzgKBrFb(P_1, P_3, KxbYasQTjZJkSyCaICMaSTQpwfYr.UsGNQBNBgNZUhlYjbPkaBwgidHLU.Exact);
		for (int i = 0; i < P_1; i++)
		{
			PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = P_3[i];
			if (psAnRFoXZVCPLNyfCHpsvaxBALYi != null && psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = cEkknBteNNFpmbdzgEuzhAbfEygDb(P_3);
				psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = qtfbYDSASXCbwzBgdpYHuKeVfqKc();
				MpVzuWTDGKCWmnvMFjMKjhXNfleD.hJPwthDecAFRMVQHivkuGLTIAyjEA(psAnRFoXZVCPLNyfCHpsvaxBALYi);
			}
		}
		P_3.Sort(PsAnRFoXZVCPLNyfCHpsvaxBALYi.cNgCHDAUgptKWybBieteaIwoyxFP);
	}

	private void OfKlVMcWGtqZiLWaSAZXAFRaCVot(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0, int P_1, int P_2)
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

	private bool fVElmGFAWRbnMVRdtBGYPHdqbLSIA(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0, int P_1)
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

	private int cEkknBteNNFpmbdzgEuzhAbfEygDb(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0)
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

	private bool MbleJIJvNwABCRCmkUHMBypPEsde(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0, int P_1)
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

	private void PcDnVKASEUBktuCSSKXPyzeONHbb(int P_0, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_1, int P_2, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_3, KxbYasQTjZJkSyCaICMaSTQpwfYr.UsGNQBNBgNZUhlYjbPkaBwgidHLU P_4)
	{
		int num = ((P_4 != KxbYasQTjZJkSyCaICMaSTQpwfYr.UsGNQBNBgNZUhlYjbPkaBwgidHLU.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = P_1[i];
			if (psAnRFoXZVCPLNyfCHpsvaxBALYi == null || psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi2 = P_3[j];
				if (psAnRFoXZVCPLNyfCHpsvaxBALYi2 != null && !MbleJIJvNwABCRCmkUHMBypPEsde(P_1, psAnRFoXZVCPLNyfCHpsvaxBALYi2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && psAnRFoXZVCPLNyfCHpsvaxBALYi.kQZmGfRNTYvvoqmpMebThLQvBxDT(psAnRFoXZVCPLNyfCHpsvaxBALYi2) >= num)
				{
					psAnRFoXZVCPLNyfCHpsvaxBALYi.ZwsMLhHdBEuPStOfGgjZwDhTWuJr(psAnRFoXZVCPLNyfCHpsvaxBALYi2);
					MpVzuWTDGKCWmnvMFjMKjhXNfleD.hJPwthDecAFRMVQHivkuGLTIAyjEA(psAnRFoXZVCPLNyfCHpsvaxBALYi);
				}
			}
		}
	}

	private void nXzmCrugLpbbjUCMKGVLALzgKBrFb(int P_0, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_1, KxbYasQTjZJkSyCaICMaSTQpwfYr.UsGNQBNBgNZUhlYjbPkaBwgidHLU P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = P_1[i];
			if (psAnRFoXZVCPLNyfCHpsvaxBALYi == null || psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			KxbYasQTjZJkSyCaICMaSTQpwfYr.DTYuUedmDfITSBrmYZQCMQrVXAot dTYuUedmDfITSBrmYZQCMQrVXAot = null;
			foreach (KxbYasQTjZJkSyCaICMaSTQpwfYr.DTYuUedmDfITSBrmYZQCMQrVXAot item in MpVzuWTDGKCWmnvMFjMKjhXNfleD.vPPSYtxrpLoHuUGpopFdAkySbLmr(psAnRFoXZVCPLNyfCHpsvaxBALYi, P_2))
			{
				if (!MbleJIJvNwABCRCmkUHMBypPEsde(P_1, item.theChBjZCqKuzdHpFUITiqougwpu) && item.PRbrxnrCMQOpzdyBQfOiSZETUQNy >= 0)
				{
					dTYuUedmDfITSBrmYZQCMQrVXAot = item;
					break;
				}
			}
			if (dTYuUedmDfITSBrmYZQCMQrVXAot != null)
			{
				int num = dTYuUedmDfITSBrmYZQCMQrVXAot.PRbrxnrCMQOpzdyBQfOiSZETUQNy;
				if (!fVElmGFAWRbnMVRdtBGYPHdqbLSIA(P_1, num))
				{
					num = (dTYuUedmDfITSBrmYZQCMQrVXAot.PRbrxnrCMQOpzdyBQfOiSZETUQNy = cEkknBteNNFpmbdzgEuzhAbfEygDb(P_1));
				}
				psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = dTYuUedmDfITSBrmYZQCMQrVXAot.theChBjZCqKuzdHpFUITiqougwpu;
				MpVzuWTDGKCWmnvMFjMKjhXNfleD.hJPwthDecAFRMVQHivkuGLTIAyjEA(psAnRFoXZVCPLNyfCHpsvaxBALYi);
			}
		}
	}

	private void cMzIiHaqIHhFZLQuZZCduroNDCMg()
	{
		if (ffhdOXmbepoojfUhUTQleaCbNgtl)
		{
			NpQNhQrrQJrQoqiOCGwpyREaHRHl();
		}
		if (zTftfUxYsFFEBYjWVAHzWWQqZMEv.snsDQUpOcRaGRKbTkYpwRvywuGYh && zTftfUxYsFFEBYjWVAHzWWQqZMEv.iuGaMmcGKafyNfJkNqVWhILJWPAm())
		{
			TLiedVJhXlGFOxtDgncaVtYvQCwl(zTftfUxYsFFEBYjWVAHzWWQqZMEv.adAzQMLivFAMfDeoAKPmjfzQvGQr);
		}
	}

	private void NpQNhQrrQJrQoqiOCGwpyREaHRHl()
	{
		ffhdOXmbepoojfUhUTQleaCbNgtl = false;
		if (!zTftfUxYsFFEBYjWVAHzWWQqZMEv.snsDQUpOcRaGRKbTkYpwRvywuGYh)
		{
			zTftfUxYsFFEBYjWVAHzWWQqZMEv.SgOnxhdhoJMkOXBTPqeBcreyDTgn();
		}
	}

	private void TLiedVJhXlGFOxtDgncaVtYvQCwl(List<fQVErFwZfYAeNldNqFlmAqpkgPCe> P_0)
	{
		if (iLrdrFoAhxvlaXqxjcwPfHsjrjCRA(fQVErFwZfYAeNldNqFlmAqpkgPCe.RqoIAuCuFYeDLqMUpVmXnpJxVaRC(P_0)))
		{
			XqyBbDCTtUXcxAJLCNcQkXwKjMVEA(P_0);
		}
	}

	private bool iLrdrFoAhxvlaXqxjcwPfHsjrjCRA(IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> P_0)
	{
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !yKzUFwJcHMLSsjHFWJljbCAfEMjG(P_0[i].HtnaQuDxVHZJAgkNHGcRfsCbXIkP))
				{
					return true;
				}
			}
			int count2 = IdfaftUBXaTsuZflIRIlUZaKWGLq.Count;
			for (int j = 0; j < count2; j++)
			{
				if (IdfaftUBXaTsuZflIRIlUZaKWGLq[j] != null && !oEQjtEAGNYtSrXHscYkGoalLFjPt(P_0, IdfaftUBXaTsuZflIRIlUZaKWGLq[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool yKzUFwJcHMLSsjHFWJljbCAfEMjG(Guid P_0)
	{
		lock (qbjnCVjqUAeIjdgLzlzAFfPEfCnYb)
		{
			int count = IdfaftUBXaTsuZflIRIlUZaKWGLq.Count;
			for (int i = 0; i < count; i++)
			{
				if (IdfaftUBXaTsuZflIRIlUZaKWGLq[i] != null && IdfaftUBXaTsuZflIRIlUZaKWGLq[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool oEQjtEAGNYtSrXHscYkGoalLFjPt(IList<zxeoTygAWuodzEbOIdaTbdNJPkfzA> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].HtnaQuDxVHZJAgkNHGcRfsCbXIkP == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void GNZcExXyYIaRUpcVECANkIvTdIFX(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi = P_0[i];
			if (psAnRFoXZVCPLNyfCHpsvaxBALYi == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					PsAnRFoXZVCPLNyfCHpsvaxBALYi psAnRFoXZVCPLNyfCHpsvaxBALYi2 = P_1[j];
					if (psAnRFoXZVCPLNyfCHpsvaxBALYi2 != null && psAnRFoXZVCPLNyfCHpsvaxBALYi.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == psAnRFoXZVCPLNyfCHpsvaxBALYi2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				NAWjdRfufFSnMdwMAiLQUPNvxaJBA(P_0[i], P_2);
			}
		}
	}

	private void NAWjdRfufFSnMdwMAiLQUPNvxaJBA(PsAnRFoXZVCPLNyfCHpsvaxBALYi P_0, bool P_1)
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

	private bool mTFZGvxrBYmSadXmnOWLgeCtaVHFA()
	{
		int num = pEziqwcbImzBDdiCVhGCuMrzKDle.DtqAgSdbdXCUSQwtJpyjQSeTFtdjA(VLvQcNuaSLlqeeafybsvEUaykbhq.GameControl, pnJfJlKSvYRtZdzwwioLpnYQNhYbb.AttachedOnly);
		if (pbxBoSbSFWZEPUYAqbDNBQZsmJKvA != num)
		{
			pbxBoSbSFWZEPUYAqbDNBQZsmJKvA = num;
			return true;
		}
		if (WSdOsPpFraceEJZACAnzSzCdoiPdA > 0 && SFfvmOrdCyVzlaRyfedaGhitzVU.zzWWnMudubaTTnXVFdUZGrpNVxof())
		{
			return true;
		}
		return false;
	}

	private void stIGRXEzdEMIyuvsIWihjbcYmukW(List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_0, List<PsAnRFoXZVCPLNyfCHpsvaxBALYi> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].QrdMzxiisMRKRsQnktTJMYEFCtxA();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void WAjSOIPTnGMmywGRhFqzEZgiDuGrA(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<fQVErFwZfYAeNldNqFlmAqpkgPCe> PCAaCgdKRapKOMEcQrHFMJHVEYoeb()
	{
		return xQmoZahdLkZslcgIcfdUhVMLNRhu();
	}
}
