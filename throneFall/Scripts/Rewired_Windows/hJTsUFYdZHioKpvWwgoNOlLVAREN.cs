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
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class hJTsUFYdZHioKpvWwgoNOlLVAREN : PlatformInputManager, WcLOVIVVtbKfXzBpbdfQnbxdxBNU
{
	private class pLnbctCxXNbPwKWEvlJdVbqyluUL : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int oDAJEeZPvydjRrSosJpGwBXuntxq;

		private int RKGqgNvXBIkJIcZBYKsSagSUkbOH;

		public Guid rGxeChdavfSqYnhVMUmzRthVfTu;

		public string ERhGKhLIewkTskTInRtxzrFDoKBD;

		public readonly PdkBAyTFrWhMFIqWfCGVITkFuelB MxCcUOblCXaUTDGDrzCoqAOblHUY;

		public TtTEWPAmgCXtCiwlxHCRLqWtUGyz XRuxPqEJOGIcLKYqdIofWJmkmaZz;

		public YHBoSiEgJmbVHxbppfOYBehIaUzQ HpABQSeePylSvbsmaUfrIdshjQaWe;

		public string CjkFdbaFShEShblMDLuHhMDXslzdc;

		public string bOwaLviFEKBESDUdEuzTJMUrJdIXb;

		public int OYyqLUOIOkFGHArDoFAOarJgGzleA;

		public Guid oQQLlcDSVlTHNJsDttELdoBcmraR;

		public Guid WrlINHcqUTtIXGQVlZBcDpkTjfaj;

		public Guid uYjRZjjknrZkGauDtFUmeWdyFCAe;

		public int MYwVqSxuBDMygOGOtdjPVwofxAzL;

		public bool jfxuEwonXGPOchcdXZmfkibPTjGn;

		public string IHpTjBufJDxDGoTmHeBoZGYbKHwk;

		public string IKYUhwJfbcPBqHhyshGNRIYbXfom;

		public int KIAToFVIeZcvqxeZHldXjWdiLvrC;

		public int dvHTKKwdDkADrgrKWawmuvylBaHU;

		public int cAGbpadCFHslPrHhQaEfhyuuoGMW;

		public int cXcNrMRVGoanCIZRAKAkaUYXayoq;

		public int dWHlAGlBJFCjZJQsYMmilVVxiwMfb;

		public bool WnrlaCVIBHYDSOhmpxjbRkOUaPAG;

		public Controller.Extension cbBvzotOVpOmsMtOKbVjTEHacFJE;

		private float[] JaVyUBALPWRxTvwGvadjJLQWxpkC;

		private bool[] uniaDRuFNXCisznmZBSTCsEvCUGnA;

		private HardwareJoystickMap_InputManager CzkkOuFPcIWHqWzrLTPDFMqVyEqw;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TgHxgCqMJuDkPKgYyYdbSrGcoXzbb;

		private bool pIbGAlduaRXWLNFytEIfAiFwRakHA;

		private bool BvvQDeGJnKXMIDTDyhAFZMchRAXX;

		private bool VDDxZqtGOGUDQohNzMqiubzTPdIQ;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return oDAJEeZPvydjRrSosJpGwBXuntxq;
			}
			set
			{
				oDAJEeZPvydjRrSosJpGwBXuntxq = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return RKGqgNvXBIkJIcZBYKsSagSUkbOH;
			}
			set
			{
				RKGqgNvXBIkJIcZBYKsSagSUkbOH = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (ERhGKhLIewkTskTInRtxzrFDoKBD != "Unknown Controller")
				{
					return ERhGKhLIewkTskTInRtxzrFDoKBD;
				}
				if (jfxuEwonXGPOchcdXZmfkibPTjGn && !string.IsNullOrEmpty(IHpTjBufJDxDGoTmHeBoZGYbKHwk))
				{
					return IHpTjBufJDxDGoTmHeBoZGYbKHwk;
				}
				return bOwaLviFEKBESDUdEuzTJMUrJdIXb;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (RKGqgNvXBIkJIcZBYKsSagSUkbOH < 0)
				{
					return null;
				}
				return RKGqgNvXBIkJIcZBYKsSagSUkbOH;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => cbBvzotOVpOmsMtOKbVjTEHacFJE;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => oQQLlcDSVlTHNJsDttELdoBcmraR;

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

		public pLnbctCxXNbPwKWEvlJdVbqyluUL(PdkBAyTFrWhMFIqWfCGVITkFuelB P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			MxCcUOblCXaUTDGDrzCoqAOblHUY = P_0;
			TgHxgCqMJuDkPKgYyYdbSrGcoXzbb = P_1;
			RKGqgNvXBIkJIcZBYKsSagSUkbOH = -1;
			oDAJEeZPvydjRrSosJpGwBXuntxq = -1;
		}

		public void WCihnNkByaBCZAORaLyLETwurXfYB()
		{
			string text = bOwaLviFEKBESDUdEuzTJMUrJdIXb;
			Guid wrlINHcqUTtIXGQVlZBcDpkTjfaj = WrlINHcqUTtIXGQVlZBcDpkTjfaj;
			uYjRZjjknrZkGauDtFUmeWdyFCAe = MiscTools.CreateGuidHashSHA1(text + wrlINHcqUTtIXGQVlZBcDpkTjfaj.ToString());
			KIAToFVIeZcvqxeZHldXjWdiLvrC = cAGbpadCFHslPrHhQaEfhyuuoGMW;
			dvHTKKwdDkADrgrKWawmuvylBaHU = cXcNrMRVGoanCIZRAKAkaUYXayoq + dWHlAGlBJFCjZJQsYMmilVVxiwMfb * 8;
			lvbCRvaXPPdteuLERzoTGjUdPmyKA();
			rGxeChdavfSqYnhVMUmzRthVfTu = CzkkOuFPcIWHqWzrLTPDFMqVyEqw.hardwareMapIdentifier.guid;
			ERhGKhLIewkTskTInRtxzrFDoKBD = CzkkOuFPcIWHqWzrLTPDFMqVyEqw.controllerName;
			pIbGAlduaRXWLNFytEIfAiFwRakHA = ((rGxeChdavfSqYnhVMUmzRthVfTu == Guid.Empty) ? true : false);
			JaVyUBALPWRxTvwGvadjJLQWxpkC = new float[KIAToFVIeZcvqxeZHldXjWdiLvrC];
			uniaDRuFNXCisznmZBSTCsEvCUGnA = new bool[dvHTKKwdDkADrgrKWawmuvylBaHU];
			MxCcUOblCXaUTDGDrzCoqAOblHUY.rpdqdWCxGtldQxpqqcVeyfgoKOCy();
			Update();
		}

		public void jZJkHBMsQfDsrbKGsjSaYBOfJtwjA(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0)
		{
			if (P_0 != null)
			{
				RKGqgNvXBIkJIcZBYKsSagSUkbOH = P_0.RKGqgNvXBIkJIcZBYKsSagSUkbOH;
				oDAJEeZPvydjRrSosJpGwBXuntxq = P_0.oDAJEeZPvydjRrSosJpGwBXuntxq;
				for (int i = 0; i < MathTools.Min(uniaDRuFNXCisznmZBSTCsEvCUGnA.Length, P_0.uniaDRuFNXCisznmZBSTCsEvCUGnA.Length); i++)
				{
					uniaDRuFNXCisznmZBSTCsEvCUGnA[i] = P_0.uniaDRuFNXCisznmZBSTCsEvCUGnA[i];
				}
				for (int j = 0; j < MathTools.Min(JaVyUBALPWRxTvwGvadjJLQWxpkC.Length, P_0.JaVyUBALPWRxTvwGvadjJLQWxpkC.Length); j++)
				{
					JaVyUBALPWRxTvwGvadjJLQWxpkC[j] = P_0.JaVyUBALPWRxTvwGvadjJLQWxpkC[j];
				}
				BvvQDeGJnKXMIDTDyhAFZMchRAXX = P_0.BvvQDeGJnKXMIDTDyhAFZMchRAXX;
				MxCcUOblCXaUTDGDrzCoqAOblHUY.rnrCdvFawplkpLBqQugbPUOrjTbd(P_0.MxCcUOblCXaUTDGDrzCoqAOblHUY);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			MxCcUOblCXaUTDGDrzCoqAOblHUY.EqcVCpKQLNmtuBpfsyjJHXDyqZDk();
			bool[] array = MxCcUOblCXaUTDGDrzCoqAOblHUY.avetRUKpKeBLyEcLMIaUNaVxBAsQA;
			int[] rleuQYTECvpakOIqwbWdwFkakLcu = MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.rleuQYTECvpakOIqwbWdwFkakLcu;
			guakItwuFazjVixwDyZnSVEhuyPj(array, rleuQYTECvpakOIqwbWdwFkakLcu);
			fVxIYjRUIbuEiRDSeOjxMdtjULJU(array, rleuQYTECvpakOIqwbWdwFkakLcu);
			MxCcUOblCXaUTDGDrzCoqAOblHUY.wTIZSiHquOnWFuVcoiADTOJlbcfh();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (KIAToFVIeZcvqxeZHldXjWdiLvrC != dataUpdater.axisCount || dvHTKKwdDkADrgrKWawmuvylBaHU != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < KIAToFVIeZcvqxeZHldXjWdiLvrC; i++)
			{
				dataUpdater.axisValues[i] = JaVyUBALPWRxTvwGvadjJLQWxpkC[i];
			}
			for (int j = 0; j < dvHTKKwdDkADrgrKWawmuvylBaHU; j++)
			{
				dataUpdater.buttonValues[j] = uniaDRuFNXCisznmZBSTCsEvCUGnA[j];
			}
			if (BvvQDeGJnKXMIDTDyhAFZMchRAXX && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int VVsXEVZnxycNezvVrcmidPKgaSCUA(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0)
		{
			if (P_0.oDAJEeZPvydjRrSosJpGwBXuntxq == oDAJEeZPvydjRrSosJpGwBXuntxq)
			{
				return 2;
			}
			if (cAGbpadCFHslPrHhQaEfhyuuoGMW != P_0.cAGbpadCFHslPrHhQaEfhyuuoGMW)
			{
				return 0;
			}
			if (cXcNrMRVGoanCIZRAKAkaUYXayoq != P_0.cXcNrMRVGoanCIZRAKAkaUYXayoq)
			{
				return 0;
			}
			if (dWHlAGlBJFCjZJQsYMmilVVxiwMfb != P_0.dWHlAGlBJFCjZJQsYMmilVVxiwMfb)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.uYjRZjjknrZkGauDtFUmeWdyFCAe == uYjRZjjknrZkGauDtFUmeWdyFCAe)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo qgNGgRDsxXeTlyWbZHlxpqRmPZuSA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			fppDqDPJGOdGxdfrJckyrHWEInmm(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			wuscPbahPVgXFwhANECzgWFbmRNZ(bridgedController);
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
			return new ControllerDisconnectedEventArgs(oDAJEeZPvydjRrSosJpGwBXuntxq);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool KaGDlXtneaLpOvBnKxnWzuaCCQZs()
		{
			try
			{
				MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU.MrHFJYhFaGgLvjcXTAPjuKuVwgduA();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void fXOtFMuKIztiRjtVZTHWFalrQZWj()
		{
			try
			{
				if (MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU != null)
				{
					MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU.sJEXKhTDzjFmWWXehgEkbpPDPJQA();
				}
			}
			catch
			{
			}
		}

		public void YEIZVlKRWiUMxAQCQEvpgZtFIfcEA()
		{
			try
			{
				if (MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU != null)
				{
					MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU.VmaqNrYBgZEfmTiwaupLiygsIZLf();
				}
			}
			catch
			{
			}
		}

		private void guakItwuFazjVixwDyZnSVEhuyPj(bool[] P_0, int[] P_1)
		{
			if (KIAToFVIeZcvqxeZHldXjWdiLvrC <= 0)
			{
				return;
			}
			switch (CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						SpURibeqIgrpEAqPJIZvFpRghmobA(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						SpURibeqIgrpEAqPJIZvFpRghmobA(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void fVxIYjRUIbuEiRDSeOjxMdtjULJU(bool[] P_0, int[] P_1)
		{
			if (dvHTKKwdDkADrgrKWawmuvylBaHU <= 0)
			{
				return;
			}
			switch (CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						rPEqepzpJpeqMhwSGFcUVbhcNEHIb(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)CzkkOuFPcIWHqWzrLTPDFMqVyEqw.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						rPEqepzpJpeqMhwSGFcUVbhcNEHIb(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void SpURibeqIgrpEAqPJIZvFpRghmobA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= KIAToFVIeZcvqxeZHldXjWdiLvrC)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			JaVyUBALPWRxTvwGvadjJLQWxpkC[P_1] = ngqclNAXtrLttkXeYnrwoppHpJjcA(P_0, P_2, P_3);
			if (!BvvQDeGJnKXMIDTDyhAFZMchRAXX && JaVyUBALPWRxTvwGvadjJLQWxpkC[P_1] != 0f)
			{
				BvvQDeGJnKXMIDTDyhAFZMchRAXX = true;
			}
		}

		private void rPEqepzpJpeqMhwSGFcUVbhcNEHIb(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= dvHTKKwdDkADrgrKWawmuvylBaHU)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			uniaDRuFNXCisznmZBSTCsEvCUGnA[P_1] = uXzpTwesgTdustsgaxDnauKCRFsh(P_0, P_2, P_3);
			if (!BvvQDeGJnKXMIDTDyhAFZMchRAXX && uniaDRuFNXCisznmZBSTCsEvCUGnA[P_1])
			{
				BvvQDeGJnKXMIDTDyhAFZMchRAXX = true;
			}
		}

		private float ngqclNAXtrLttkXeYnrwoppHpJjcA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return VhllvIwhqJBdwMJQURzowHjObmko((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= cXcNrMRVGoanCIZRAKAkaUYXayoq || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= dWHlAGlBJFCjZJQsYMmilVVxiwMfb || sourceHat >= 4)
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
					num2 = exOgTPLMUyzWEyJmIoImpWginqHm(num, AxisDirection.Horizontal);
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
					num2 = exOgTPLMUyzWEyJmIoImpWginqHm(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && beqiDABLoOikxXCzFKnLDhXUMzRr(customCalculationSourceData[i], out var item))
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

		private float VhllvIwhqJBdwMJQURzowHjObmko(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.VTeJCcnXWRlQpJezQadVGenrPrqt, 
				DirectInputAxis.Y => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.qwiWXUsdCmSVMjZroheSUYXDCLPP, 
				DirectInputAxis.Z => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.nVtSjoWHWiIfZGPlaNiXFVQRwpnX, 
				DirectInputAxis.RotationX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.RssErqFAEsmZynBONEXKcZVsMeLGA, 
				DirectInputAxis.RotationY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.wDpwXYRWXdlTCXgxkQeXBcsVySNf, 
				DirectInputAxis.RotationZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.JIqFJJONRmwwtsHVsxPIcfONAVXF, 
				DirectInputAxis.Slider0 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.oIbKqrauIyiZBdagQirnhDVqjxUAb[0], 
				DirectInputAxis.Slider1 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.oIbKqrauIyiZBdagQirnhDVqjxUAb[1], 
				DirectInputAxis.VelocityX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.eLKlwwAhTGPfskzBGtcbPtFGlkQK, 
				DirectInputAxis.VelocityY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.LTsmKbsmemPuUkhDpAEnIJLxzQaw, 
				DirectInputAxis.VelocityZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.LMiPnapSjYMlammtfRVRVavajflX, 
				DirectInputAxis.AngularVelocityX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.foFADUanALLDhhPyMzdNbUsijPGo, 
				DirectInputAxis.AngularVelocityY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.PRRNqlfEfchqeStmNnHIrRLqchWB, 
				DirectInputAxis.AngularVelocityZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.iDQullBwxsMMYinlSozonbTpvMqW, 
				DirectInputAxis.VelocitySlider0 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.bekOUGJHObCpwOEfFBMOYWDLGgTBA[0], 
				DirectInputAxis.VelocitySlider1 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.bekOUGJHObCpwOEfFBMOYWDLGgTBA[1], 
				DirectInputAxis.AccelerationX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.EEwFYGJrBgxYDSDJTtJsxdsraDzS, 
				DirectInputAxis.AccelerationY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.CiizGHdpRJiLfKxcuUdLhchjIolc, 
				DirectInputAxis.AccelerationZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.tQSOsVFHUxGpvJWWWKXHscjTgkjBb, 
				DirectInputAxis.AngularAccelerationX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.RKBiQxaGEIvMCZfylugPqKUqHEZt, 
				DirectInputAxis.AngularAccelerationY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.jaBWVhrLfNTiCIlggdRloEWyHArs, 
				DirectInputAxis.AngularAccelerationZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.LDycEGNwipMJLsMPHmqOsiWJiCLA, 
				DirectInputAxis.AccelerationSlider0 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.qGeQZIXbXHahNaoyCJBsTcQlntyQA[0], 
				DirectInputAxis.AccelerationSlider1 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.qGeQZIXbXHahNaoyCJBsTcQlntyQA[1], 
				DirectInputAxis.ForceX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.uObDgVlfqXvCtmFMVMfGClAPQvjX, 
				DirectInputAxis.ForceY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.wfGBDLbWZdjFkidPJmTegewYxqnzA, 
				DirectInputAxis.ForceZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.LZopEswotxjYThOGoTvFtSXmMmpv, 
				DirectInputAxis.TorqueX => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.pOMQxdppHdtoFhwvkaDUjBNVDXTh, 
				DirectInputAxis.TorqueY => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.dYRdmodjtkYsNjqPeZqlWXkWZbQiA, 
				DirectInputAxis.TorqueZ => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.FSWBvvlitnfokvsbECPtKtcYSufrA, 
				DirectInputAxis.ForceSlider0 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.KVLEDYGMyedLBaYasXuxFVETSiKcb[0], 
				DirectInputAxis.ForceSlider1 => MxCcUOblCXaUTDGDrzCoqAOblHUY.JRbdEDFqxZLwwbeIIBKsiOgSpoSx.KVLEDYGMyedLBaYasXuxFVETSiKcb[1], 
				_ => 0f, 
			};
		}

		private bool uXzpTwesgTdustsgaxDnauKCRFsh(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= cXcNrMRVGoanCIZRAKAkaUYXayoq || sourceButton >= 128)
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
				float num = VhllvIwhqJBdwMJQURzowHjObmko((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= dWHlAGlBJFCjZJQsYMmilVVxiwMfb || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return gQaRlbSwnKkGjvNmSmJewrpbyZzN(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (TLImMjjJFGXyjmvagbklqVEyCgDu(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (beqiDABLoOikxXCzFKnLDhXUMzRr(customCalculationSourceData[k], out var num2))
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

		private bool gQaRlbSwnKkGjvNmSmJewrpbyZzN(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (CzkkOuFPcIWHqWzrLTPDFMqVyEqw.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float exOgTPLMUyzWEyJmIoImpWginqHm(int P_0, AxisDirection P_1)
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

		private bool TLImMjjJFGXyjmvagbklqVEyCgDu(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= cXcNrMRVGoanCIZRAKAkaUYXayoq || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool beqiDABLoOikxXCzFKnLDhXUMzRr(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = VhllvIwhqJBdwMJQURzowHjObmko((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType YNTvDfoGEzaomAcJfueWmfGiFDTTA(YHBoSiEgJmbVHxbppfOYBehIaUzQ P_0)
		{
			return P_0 switch
			{
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Keyboard => ControlDeviceType.Keyboard, 
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Joystick => ControlDeviceType.Joystick, 
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Gamepad => ControlDeviceType.Gamepad, 
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Mouse => ControlDeviceType.Mouse, 
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Flight => ControlDeviceType.Flight, 
				YHBoSiEgJmbVHxbppfOYBehIaUzQ.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void lvbCRvaXPPdteuLERzoTGjUdPmyKA()
		{
			CzkkOuFPcIWHqWzrLTPDFMqVyEqw = TgHxgCqMJuDkPKgYyYdbSrGcoXzbb(qgNGgRDsxXeTlyWbZHlxpqRmPZuSA());
			if (CzkkOuFPcIWHqWzrLTPDFMqVyEqw == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			KIAToFVIeZcvqxeZHldXjWdiLvrC = CzkkOuFPcIWHqWzrLTPDFMqVyEqw.axisCount;
			dvHTKKwdDkADrgrKWawmuvylBaHU = CzkkOuFPcIWHqWzrLTPDFMqVyEqw.buttonCount;
		}

		private void XrxfOFQcaQhBXecaFsyNarfrYwYO()
		{
		}

		private string MetxbjjXWdNBUlXeoQPhVgiRyJpk()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (jfxuEwonXGPOchcdXZmfkibPTjGn && !string.IsNullOrEmpty(IHpTjBufJDxDGoTmHeBoZGYbKHwk)) ? IHpTjBufJDxDGoTmHeBoZGYbKHwk : bOwaLviFEKBESDUdEuzTJMUrJdIXb, OYyqLUOIOkFGHArDoFAOarJgGzleA.ToString("X4"), new PidVid(WrlINHcqUTtIXGQVlZBcDpkTjfaj).vendorId.ToString("X4")));
		}

		private void fppDqDPJGOdGxdfrJckyrHWEInmm(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = YNTvDfoGEzaomAcJfueWmfGiFDTTA(HpABQSeePylSvbsmaUfrIdshjQaWe);
			P_0.hardwareIdentifier = MetxbjjXWdNBUlXeoQPhVgiRyJpk();
			P_0.hardwareAxisCount = cAGbpadCFHslPrHhQaEfhyuuoGMW;
			P_0.hardwareButtonCount = cXcNrMRVGoanCIZRAKAkaUYXayoq;
			P_0.hardwareHatCount = dWHlAGlBJFCjZJQsYMmilVVxiwMfb;
			P_0.hw_productName = bOwaLviFEKBESDUdEuzTJMUrJdIXb;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = OYyqLUOIOkFGHArDoFAOarJgGzleA;
			P_0.hw_pidVid = new PidVid(WrlINHcqUTtIXGQVlZBcDpkTjfaj);
			P_0.hw_isBluetoothDevice = jfxuEwonXGPOchcdXZmfkibPTjGn;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(IHpTjBufJDxDGoTmHeBoZGYbKHwk)) ? IHpTjBufJDxDGoTmHeBoZGYbKHwk : string.Empty);
			P_0.definitionMatchTag = IKYUhwJfbcPBqHhyshGNRIYbXfom;
		}

		private void wuscPbahPVgXFwhANECzgWFbmRNZ(BridgedController P_0)
		{
			fppDqDPJGOdGxdfrJckyrHWEInmm(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = CzkkOuFPcIWHqWzrLTPDFMqVyEqw.ToGameHardwareControllerMap();
			P_0.instanceName = CjkFdbaFShEShblMDLuHhMDXslzdc;
			P_0.productName = bOwaLviFEKBESDUdEuzTJMUrJdIXb;
			P_0.isXInputDevice = WnrlaCVIBHYDSOhmpxjbRkOUaPAG;
			P_0.axisCount = KIAToFVIeZcvqxeZHldXjWdiLvrC;
			P_0.buttonCount = dvHTKKwdDkADrgrKWawmuvylBaHU;
			P_0.unknownControllerHats = DAoJfGUkVvcokJzrKMoBPOmJICPEA();
			P_0.controllerTypeGuid = rGxeChdavfSqYnhVMUmzRthVfTu;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void iZmeuWujYjchrqQWXfojHSACDIxe()
		{
			for (int i = 0; i < dvHTKKwdDkADrgrKWawmuvylBaHU; i++)
			{
				uniaDRuFNXCisznmZBSTCsEvCUGnA[i] = false;
			}
			for (int j = 0; j < KIAToFVIeZcvqxeZHldXjWdiLvrC; j++)
			{
				JaVyUBALPWRxTvwGvadjJLQWxpkC[j] = 0f;
			}
		}

		private UnknownControllerHat[] DAoJfGUkVvcokJzrKMoBPOmJICPEA()
		{
			if (!pIbGAlduaRXWLNFytEIfAiFwRakHA)
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

		public void OlrMQIWFFuOAeogJdvRmhVIMvNxC()
		{
			sfPNUFpSFQshNLCQNZumkMEnqkEG(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void xmExbAwTSFDXvSNnDNoxpDVaFpQC()
		{
			try
			{
				sfPNUFpSFQshNLCQNZumkMEnqkEG(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void sfPNUFpSFQshNLCQNZumkMEnqkEG(bool P_0)
		{
			if (!VDDxZqtGOGUDQohNzMqiubzTPdIQ)
			{
				if (P_0 && MxCcUOblCXaUTDGDrzCoqAOblHUY != null)
				{
					MxCcUOblCXaUTDGDrzCoqAOblHUY.Dispose();
				}
				VDDxZqtGOGUDQohNzMqiubzTPdIQ = true;
			}
		}

		public static int UkidBRzdGcBQEmORLHelGsIAVwEi(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, pLnbctCxXNbPwKWEvlJdVbqyluUL P_1)
		{
			if (P_0.RKGqgNvXBIkJIcZBYKsSagSUkbOH < P_1.RKGqgNvXBIkJIcZBYKsSagSUkbOH)
			{
				return -1;
			}
			if (P_0.RKGqgNvXBIkJIcZBYKsSagSUkbOH > P_1.RKGqgNvXBIkJIcZBYKsSagSUkbOH)
			{
				return 1;
			}
			return 0;
		}

		public static int JmcBDKINuXYBNIimRNCbpqlIpxcgb(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, pLnbctCxXNbPwKWEvlJdVbqyluUL P_1)
		{
			if (P_0.MYwVqSxuBDMygOGOtdjPVwofxAzL < P_1.MYwVqSxuBDMygOGOtdjPVwofxAzL)
			{
				return -1;
			}
			if (P_0.MYwVqSxuBDMygOGOtdjPVwofxAzL > P_1.MYwVqSxuBDMygOGOtdjPVwofxAzL)
			{
				return 1;
			}
			return 0;
		}
	}

	private class PdkBAyTFrWhMFIqWfCGVITkFuelB : IDisposable
	{
		public class FdsBMobHBeYfZmCIoUqkRhixTWbdA
		{
			public float VTeJCcnXWRlQpJezQadVGenrPrqt;

			public float qwiWXUsdCmSVMjZroheSUYXDCLPP;

			public float nVtSjoWHWiIfZGPlaNiXFVQRwpnX;

			public float RssErqFAEsmZynBONEXKcZVsMeLGA;

			public float wDpwXYRWXdlTCXgxkQeXBcsVySNf;

			public float JIqFJJONRmwwtsHVsxPIcfONAVXF;

			public float[] oIbKqrauIyiZBdagQirnhDVqjxUAb;

			public readonly int[] rleuQYTECvpakOIqwbWdwFkakLcu;

			public readonly bool[] LfIuIsZgzVFSGXFmmqGRKpWJvWQI;

			public float eLKlwwAhTGPfskzBGtcbPtFGlkQK;

			public float LTsmKbsmemPuUkhDpAEnIJLxzQaw;

			public float LMiPnapSjYMlammtfRVRVavajflX;

			public float foFADUanALLDhhPyMzdNbUsijPGo;

			public float PRRNqlfEfchqeStmNnHIrRLqchWB;

			public float iDQullBwxsMMYinlSozonbTpvMqW;

			public readonly float[] bekOUGJHObCpwOEfFBMOYWDLGgTBA;

			public float EEwFYGJrBgxYDSDJTtJsxdsraDzS;

			public float CiizGHdpRJiLfKxcuUdLhchjIolc;

			public float tQSOsVFHUxGpvJWWWKXHscjTgkjBb;

			public float RKBiQxaGEIvMCZfylugPqKUqHEZt;

			public float jaBWVhrLfNTiCIlggdRloEWyHArs;

			public float LDycEGNwipMJLsMPHmqOsiWJiCLA;

			public readonly float[] qGeQZIXbXHahNaoyCJBsTcQlntyQA;

			public float uObDgVlfqXvCtmFMVMfGClAPQvjX;

			public float wfGBDLbWZdjFkidPJmTegewYxqnzA;

			public float LZopEswotxjYThOGoTvFtSXmMmpv;

			public float pOMQxdppHdtoFhwvkaDUjBNVDXTh;

			public float dYRdmodjtkYsNjqPeZqlWXkWZbQiA;

			public float FSWBvvlitnfokvsbECPtKtcYSufrA;

			public readonly float[] KVLEDYGMyedLBaYasXuxFVETSiKcb;

			public FdsBMobHBeYfZmCIoUqkRhixTWbdA()
			{
				oIbKqrauIyiZBdagQirnhDVqjxUAb = new float[2];
				rleuQYTECvpakOIqwbWdwFkakLcu = new int[4];
				LfIuIsZgzVFSGXFmmqGRKpWJvWQI = new bool[128];
				bekOUGJHObCpwOEfFBMOYWDLGgTBA = new float[2];
				qGeQZIXbXHahNaoyCJBsTcQlntyQA = new float[2];
				KVLEDYGMyedLBaYasXuxFVETSiKcb = new float[2];
			}

			public void LajSWctSVXSTUIPXXMXHaddNYQZk()
			{
				VTeJCcnXWRlQpJezQadVGenrPrqt = 0f;
				qwiWXUsdCmSVMjZroheSUYXDCLPP = 0f;
				nVtSjoWHWiIfZGPlaNiXFVQRwpnX = 0f;
				RssErqFAEsmZynBONEXKcZVsMeLGA = 0f;
				wDpwXYRWXdlTCXgxkQeXBcsVySNf = 0f;
				JIqFJJONRmwwtsHVsxPIcfONAVXF = 0f;
				for (int i = 0; i < oIbKqrauIyiZBdagQirnhDVqjxUAb.Length; i++)
				{
					oIbKqrauIyiZBdagQirnhDVqjxUAb[i] = 0f;
				}
				for (int j = 0; j < rleuQYTECvpakOIqwbWdwFkakLcu.Length; j++)
				{
					rleuQYTECvpakOIqwbWdwFkakLcu[j] = 0;
				}
				for (int k = 0; k < LfIuIsZgzVFSGXFmmqGRKpWJvWQI.Length; k++)
				{
					LfIuIsZgzVFSGXFmmqGRKpWJvWQI[k] = false;
				}
				eLKlwwAhTGPfskzBGtcbPtFGlkQK = 0f;
				LTsmKbsmemPuUkhDpAEnIJLxzQaw = 0f;
				LMiPnapSjYMlammtfRVRVavajflX = 0f;
				foFADUanALLDhhPyMzdNbUsijPGo = 0f;
				PRRNqlfEfchqeStmNnHIrRLqchWB = 0f;
				iDQullBwxsMMYinlSozonbTpvMqW = 0f;
				for (int l = 0; l < bekOUGJHObCpwOEfFBMOYWDLGgTBA.Length; l++)
				{
					bekOUGJHObCpwOEfFBMOYWDLGgTBA[l] = 0f;
				}
				EEwFYGJrBgxYDSDJTtJsxdsraDzS = 0f;
				CiizGHdpRJiLfKxcuUdLhchjIolc = 0f;
				tQSOsVFHUxGpvJWWWKXHscjTgkjBb = 0f;
				RKBiQxaGEIvMCZfylugPqKUqHEZt = 0f;
				jaBWVhrLfNTiCIlggdRloEWyHArs = 0f;
				LDycEGNwipMJLsMPHmqOsiWJiCLA = 0f;
				for (int m = 0; m < qGeQZIXbXHahNaoyCJBsTcQlntyQA.Length; m++)
				{
					qGeQZIXbXHahNaoyCJBsTcQlntyQA[m] = 0f;
				}
				uObDgVlfqXvCtmFMVMfGClAPQvjX = 0f;
				wfGBDLbWZdjFkidPJmTegewYxqnzA = 0f;
				LZopEswotxjYThOGoTvFtSXmMmpv = 0f;
				pOMQxdppHdtoFhwvkaDUjBNVDXTh = 0f;
				dYRdmodjtkYsNjqPeZqlWXkWZbQiA = 0f;
				FSWBvvlitnfokvsbECPtKtcYSufrA = 0f;
				for (int n = 0; n < KVLEDYGMyedLBaYasXuxFVETSiKcb.Length; n++)
				{
					KVLEDYGMyedLBaYasXuxFVETSiKcb[n] = 0f;
				}
			}

			public void tTUykRsshtTCMYNuEScPtvRVJIpr(FdsBMobHBeYfZmCIoUqkRhixTWbdA P_0)
			{
				VTeJCcnXWRlQpJezQadVGenrPrqt = P_0.VTeJCcnXWRlQpJezQadVGenrPrqt;
				qwiWXUsdCmSVMjZroheSUYXDCLPP = P_0.qwiWXUsdCmSVMjZroheSUYXDCLPP;
				nVtSjoWHWiIfZGPlaNiXFVQRwpnX = P_0.nVtSjoWHWiIfZGPlaNiXFVQRwpnX;
				RssErqFAEsmZynBONEXKcZVsMeLGA = P_0.RssErqFAEsmZynBONEXKcZVsMeLGA;
				wDpwXYRWXdlTCXgxkQeXBcsVySNf = P_0.wDpwXYRWXdlTCXgxkQeXBcsVySNf;
				JIqFJJONRmwwtsHVsxPIcfONAVXF = P_0.JIqFJJONRmwwtsHVsxPIcfONAVXF;
				for (int i = 0; i < oIbKqrauIyiZBdagQirnhDVqjxUAb.Length; i++)
				{
					oIbKqrauIyiZBdagQirnhDVqjxUAb[i] = P_0.oIbKqrauIyiZBdagQirnhDVqjxUAb[i];
				}
				for (int j = 0; j < rleuQYTECvpakOIqwbWdwFkakLcu.Length; j++)
				{
					rleuQYTECvpakOIqwbWdwFkakLcu[j] = P_0.rleuQYTECvpakOIqwbWdwFkakLcu[j];
				}
				for (int k = 0; k < LfIuIsZgzVFSGXFmmqGRKpWJvWQI.Length; k++)
				{
					LfIuIsZgzVFSGXFmmqGRKpWJvWQI[k] = P_0.LfIuIsZgzVFSGXFmmqGRKpWJvWQI[k];
				}
				eLKlwwAhTGPfskzBGtcbPtFGlkQK = P_0.eLKlwwAhTGPfskzBGtcbPtFGlkQK;
				LTsmKbsmemPuUkhDpAEnIJLxzQaw = P_0.LTsmKbsmemPuUkhDpAEnIJLxzQaw;
				LMiPnapSjYMlammtfRVRVavajflX = P_0.LMiPnapSjYMlammtfRVRVavajflX;
				foFADUanALLDhhPyMzdNbUsijPGo = P_0.foFADUanALLDhhPyMzdNbUsijPGo;
				PRRNqlfEfchqeStmNnHIrRLqchWB = P_0.PRRNqlfEfchqeStmNnHIrRLqchWB;
				iDQullBwxsMMYinlSozonbTpvMqW = P_0.iDQullBwxsMMYinlSozonbTpvMqW;
				for (int l = 0; l < bekOUGJHObCpwOEfFBMOYWDLGgTBA.Length; l++)
				{
					bekOUGJHObCpwOEfFBMOYWDLGgTBA[l] = P_0.bekOUGJHObCpwOEfFBMOYWDLGgTBA[l];
				}
				EEwFYGJrBgxYDSDJTtJsxdsraDzS = P_0.EEwFYGJrBgxYDSDJTtJsxdsraDzS;
				CiizGHdpRJiLfKxcuUdLhchjIolc = P_0.CiizGHdpRJiLfKxcuUdLhchjIolc;
				tQSOsVFHUxGpvJWWWKXHscjTgkjBb = P_0.tQSOsVFHUxGpvJWWWKXHscjTgkjBb;
				RKBiQxaGEIvMCZfylugPqKUqHEZt = P_0.RKBiQxaGEIvMCZfylugPqKUqHEZt;
				jaBWVhrLfNTiCIlggdRloEWyHArs = P_0.jaBWVhrLfNTiCIlggdRloEWyHArs;
				LDycEGNwipMJLsMPHmqOsiWJiCLA = P_0.LDycEGNwipMJLsMPHmqOsiWJiCLA;
				for (int m = 0; m < qGeQZIXbXHahNaoyCJBsTcQlntyQA.Length; m++)
				{
					qGeQZIXbXHahNaoyCJBsTcQlntyQA[m] = P_0.qGeQZIXbXHahNaoyCJBsTcQlntyQA[m];
				}
				uObDgVlfqXvCtmFMVMfGClAPQvjX = P_0.uObDgVlfqXvCtmFMVMfGClAPQvjX;
				wfGBDLbWZdjFkidPJmTegewYxqnzA = P_0.wfGBDLbWZdjFkidPJmTegewYxqnzA;
				LZopEswotxjYThOGoTvFtSXmMmpv = P_0.LZopEswotxjYThOGoTvFtSXmMmpv;
				pOMQxdppHdtoFhwvkaDUjBNVDXTh = P_0.pOMQxdppHdtoFhwvkaDUjBNVDXTh;
				dYRdmodjtkYsNjqPeZqlWXkWZbQiA = P_0.dYRdmodjtkYsNjqPeZqlWXkWZbQiA;
				FSWBvvlitnfokvsbECPtKtcYSufrA = P_0.FSWBvvlitnfokvsbECPtKtcYSufrA;
				for (int n = 0; n < KVLEDYGMyedLBaYasXuxFVETSiKcb.Length; n++)
				{
					KVLEDYGMyedLBaYasXuxFVETSiKcb[n] = P_0.KVLEDYGMyedLBaYasXuxFVETSiKcb[n];
				}
			}

			public unsafe void zMZIqBZRCJJSgJyCuCgQqswJqYwo(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						LfIuIsZgzVFSGXFmmqGRKpWJvWQI[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					qGeQZIXbXHahNaoyCJBsTcQlntyQA[k] = *ptr;
					ptr++;
				}
				EEwFYGJrBgxYDSDJTtJsxdsraDzS = *ptr;
				ptr++;
				CiizGHdpRJiLfKxcuUdLhchjIolc = *ptr;
				ptr++;
				tQSOsVFHUxGpvJWWWKXHscjTgkjBb = *ptr;
				ptr++;
				RKBiQxaGEIvMCZfylugPqKUqHEZt = *ptr;
				ptr++;
				jaBWVhrLfNTiCIlggdRloEWyHArs = *ptr;
				ptr++;
				LDycEGNwipMJLsMPHmqOsiWJiCLA = *ptr;
				ptr++;
				foFADUanALLDhhPyMzdNbUsijPGo = *ptr;
				ptr++;
				PRRNqlfEfchqeStmNnHIrRLqchWB = *ptr;
				ptr++;
				iDQullBwxsMMYinlSozonbTpvMqW = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					KVLEDYGMyedLBaYasXuxFVETSiKcb[l] = *ptr;
					ptr++;
				}
				uObDgVlfqXvCtmFMVMfGClAPQvjX = *ptr;
				ptr++;
				wfGBDLbWZdjFkidPJmTegewYxqnzA = *ptr;
				ptr++;
				LZopEswotxjYThOGoTvFtSXmMmpv = *ptr;
				ptr++;
				RssErqFAEsmZynBONEXKcZVsMeLGA = *ptr;
				ptr++;
				wDpwXYRWXdlTCXgxkQeXBcsVySNf = *ptr;
				ptr++;
				JIqFJJONRmwwtsHVsxPIcfONAVXF = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					oIbKqrauIyiZBdagQirnhDVqjxUAb[m] = *ptr;
					ptr++;
				}
				pOMQxdppHdtoFhwvkaDUjBNVDXTh = *ptr;
				ptr++;
				dYRdmodjtkYsNjqPeZqlWXkWZbQiA = *ptr;
				ptr++;
				FSWBvvlitnfokvsbECPtKtcYSufrA = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					bekOUGJHObCpwOEfFBMOYWDLGgTBA[n] = *ptr;
					ptr++;
				}
				eLKlwwAhTGPfskzBGtcbPtFGlkQK = *ptr;
				ptr++;
				LTsmKbsmemPuUkhDpAEnIJLxzQaw = *ptr;
				ptr++;
				LMiPnapSjYMlammtfRVRVavajflX = *ptr;
				ptr++;
				VTeJCcnXWRlQpJezQadVGenrPrqt = *ptr;
				ptr++;
				qwiWXUsdCmSVMjZroheSUYXDCLPP = *ptr;
				ptr++;
				nVtSjoWHWiIfZGPlaNiXFVQRwpnX = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					rleuQYTECvpakOIqwbWdwFkakLcu[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void vixblyyUYQWfWQBmMlUWlpDrscIS(ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.zwwYiEDefXbIjMelwAAjSwmyIsxF;
				int[] array2 = P_0.WcXRbpMJwwdWoHunYoCOSjzBFdrcb;
				int[] array3 = P_0.BBrXCczdJNTGAnmqOJdqPOcjIYBX;
				int[] array4 = P_0.xhGRoDOrzInljAMDeuDNTcmdrbPp;
				int[] array5 = P_0.sukgxNMGEtSDFMtxkRfANBooWpjr;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.XbQZoaMPpaDKKEtGcyekRldbtHpV[i])
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
					*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(array2[j]);
					ptr++;
				}
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.kOmObIdJdSnMIqyRiDjPNljJWXGR);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.dfbWWpHBxdSqDLEwywRnoHWhwhFR);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.nLegDadVzYooxORbUifrckVhZgqFB);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.mkUVInqZAIkZVetBpHcINFuFbaOL);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.jlrsXxSiyalTuuwoCkbTBdWPAEon);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.bQFoAiSsgktHmcWWNdepXkhIKqgt);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.aRGLlfdbSzisEjBDFdwplMqvrfoj);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.tVLbQpHggEGgBDBXvecwpAbuQTjO);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.ctOnaunvrcqmwuTOLyJEoaYAYqzj);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(array3[k]);
					ptr++;
				}
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.GaixrBoNhNKdHQrryOkmbPyjwaws);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.mEzautgCFQVUtkvPkTEcImvrtGffA);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.WjTyPuBJQGheHPdHNmBrKNzKagUZ);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.FZPurDPxWjTJzDEnBUkGUkiiGSzo);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.XEIsOXPlOCUSXoGHByInlDjNfXMZ);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.CEcCyLXzQxfpKAAyIfINnhuleVNH);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(array4[l]);
					ptr++;
				}
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.jvKYSwqbxuDHYekbFwzGNQliclHXA);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.YNkwuyhSVXHQFQoPsmRkxLBiXUqe);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.WrsrVcMOnZdoViEDrmmXlnNwJBqdA);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(array5[m]);
					ptr++;
				}
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.IirdBwKSGHhNjnnGGCnZFWewEqLo);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.cxXgqcBmcfknsEIcDQlLgaLqUCNKb);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.tXXcsgMqIWhWKawKFOqCmyjZumzh);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.djmmitcMmZoJbPYrYVFybvKddNnR);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.UnlvwUIYvgwemCBLyHITrxWZGDaN);
				ptr++;
				*ptr = IQWqjJsbHOItRVnhubtkagIjtFUm(P_0.XQfZcygjntbsSSRQJjLcoGttavMb);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int mzMagcxWSmboXEYIuYdYaWCHcdVIA = 2;

		private const int TcUoXUJqZvoezwhUVpsbTltBKJjb = 2;

		private const int NIfvdcVqZiXZteEzFacMGcnUjWrS = 128;

		private const int jHgUcWcShZdGDNkroFwJeSycaRDeb = 32;

		private const int QGFHnmvdRJHaiIVhObuPfkqXqnRX = 0;

		private const int BpQFoYFUDxdiiQWZjOuEtAgUtgXH = 264;

		private const int bYbGUobUtsyxMxwCnbiUbLnjYjVJA = 272;

		private readonly int sdQBurdjegiivEIWQVWkYCkgILkeb;

		private readonly ButtonLoopSet cemQJbaIctVdsQpYIFYSYuYEHbpA;

		private readonly DualThreadLowLevelInputEventQueue AIKGUoKFqHheOqPvfpTUCRqmFTfJ;

		private qGrmDdozyQQQbIioMwKZpclCDyxH lLaOJePOJTNBgnKAgQHmhJrTeENz;

		private readonly ppyUYlIAyEDIFFGNqqfLGHCTQykdb eVTHTzuKXJffiHGOwhVlNLqmpnFp;

		private readonly ppyUYlIAyEDIFFGNqqfLGHCTQykdb UdHnGxMRccTMYboaKusbWLDXbDwC;

		private readonly object fwpbUhjJhGdgMSshPhLqUlWMBpXcA;

		private bool TrZAsJCzMkwUGMGhdPhGQOBSdThtA;

		public readonly DiJVETKbnrpIufzFejttIwRifnEK tmqeSEpbejKDbGtoJqGKrgHWIdWU;

		private readonly FdsBMobHBeYfZmCIoUqkRhixTWbdA RbbdTsiUAobYYeSSbNeKqvYhHdtwb;

		private bool uWMzRYOPHNWdTvjQAGEOjMXqBOLrA;

		public bool[] avetRUKpKeBLyEcLMIaUNaVxBAsQA => cemQJbaIctVdsQpYIFYSYuYEHbpA.Current.effectiveValue;

		public FdsBMobHBeYfZmCIoUqkRhixTWbdA JRbdEDFqxZLwwbeIIBKsiOgSpoSx => RbbdTsiUAobYYeSSbNeKqvYhHdtwb;

		public PdkBAyTFrWhMFIqWfCGVITkFuelB(DiJVETKbnrpIufzFejttIwRifnEK P_0, UpdateLoopSetting P_1)
		{
			tmqeSEpbejKDbGtoJqGKrgHWIdWU = P_0;
			sdQBurdjegiivEIWQVWkYCkgILkeb = P_0.ayiHuvHMyVEmPiMCbctPWGfezqmE.rBMrmVqLlmcCwyghsLRupBaRlCgP;
			cemQJbaIctVdsQpYIFYSYuYEHbpA = new ButtonLoopSet(P_1, sdQBurdjegiivEIWQVWkYCkgILkeb);
			AIKGUoKFqHheOqPvfpTUCRqmFTfJ = new DualThreadLowLevelInputEventQueue((int)((float)WNDYrcPDOUObmqnBCmqijYTVsDhn.CPLaRrFzUcOrwvDuUKrdhlDtwzfD * 0.25f), 128, 32, 2);
			RbbdTsiUAobYYeSSbNeKqvYhHdtwb = new FdsBMobHBeYfZmCIoUqkRhixTWbdA();
			eVTHTzuKXJffiHGOwhVlNLqmpnFp = new ppyUYlIAyEDIFFGNqqfLGHCTQykdb();
			UdHnGxMRccTMYboaKusbWLDXbDwC = new ppyUYlIAyEDIFFGNqqfLGHCTQykdb();
			fwpbUhjJhGdgMSshPhLqUlWMBpXcA = new object();
			if (WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX != null)
			{
				WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent += jiWBjWkTFDMBcYwQXDCoXdtwkQwK;
			}
		}

		public void EqcVCpKQLNmtuBpfsyjJHXDyqZDk()
		{
			cemQJbaIctVdsQpYIFYSYuYEHbpA.SetUpdateLoop(ReInput.currentUpdateLoop);
			AZPgqeHerBDNmKEJJWcONmkljAifA();
		}

		public void wTIZSiHquOnWFuVcoiADTOJlbcfh()
		{
			cemQJbaIctVdsQpYIFYSYuYEHbpA.Current.ClearWasTrueThisFrame();
		}

		public void rpdqdWCxGtldQxpqqcVeyfgoKOCy()
		{
			dSKfFdCvvNrBWjsqIiXGxpgibgif();
			TrZAsJCzMkwUGMGhdPhGQOBSdThtA = true;
		}

		public void MYlBoWjODObjzJxIdLZvjrZuWqixA()
		{
			TrZAsJCzMkwUGMGhdPhGQOBSdThtA = false;
			dSKfFdCvvNrBWjsqIiXGxpgibgif();
		}

		public void rnrCdvFawplkpLBqQugbPUOrjTbd(PdkBAyTFrWhMFIqWfCGVITkFuelB P_0)
		{
			if (P_0 == null || P_0 == this || P_0.sdQBurdjegiivEIWQVWkYCkgILkeb != sdQBurdjegiivEIWQVWkYCkgILkeb)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (fwpbUhjJhGdgMSshPhLqUlWMBpXcA)
			{
				lock (P_0.fwpbUhjJhGdgMSshPhLqUlWMBpXcA)
				{
					cemQJbaIctVdsQpYIFYSYuYEHbpA.Import(P_0.cemQJbaIctVdsQpYIFYSYuYEHbpA);
					RbbdTsiUAobYYeSSbNeKqvYhHdtwb.tTUykRsshtTCMYNuEScPtvRVJIpr(P_0.RbbdTsiUAobYYeSSbNeKqvYhHdtwb);
					eVTHTzuKXJffiHGOwhVlNLqmpnFp.HKuPtcnsJakmwNvZmwWaQcITFfBk(P_0.eVTHTzuKXJffiHGOwhVlNLqmpnFp);
					UdHnGxMRccTMYboaKusbWLDXbDwC.HKuPtcnsJakmwNvZmwWaQcITFfBk(P_0.UdHnGxMRccTMYboaKusbWLDXbDwC);
					AIKGUoKFqHheOqPvfpTUCRqmFTfJ.ImportAll(P_0.AIKGUoKFqHheOqPvfpTUCRqmFTfJ);
					lLaOJePOJTNBgnKAgQHmhJrTeENz = qGrmDdozyQQQbIioMwKZpclCDyxH.kBmdCRsveellJSWdDUnoNZJRmcwW(P_0.lLaOJePOJTNBgnKAgQHmhJrTeENz, eVTHTzuKXJffiHGOwhVlNLqmpnFp);
					TrZAsJCzMkwUGMGhdPhGQOBSdThtA = P_0.TrZAsJCzMkwUGMGhdPhGQOBSdThtA;
				}
			}
		}

		public void IUzWjcxpyGTyLcnIKCqejSTutHiq(int P_0, int P_1, int P_2, float P_3)
		{
			lock (fwpbUhjJhGdgMSshPhLqUlWMBpXcA)
			{
				lLaOJePOJTNBgnKAgQHmhJrTeENz = new qGrmDdozyQQQbIioMwKZpclCDyxH(eVTHTzuKXJffiHGOwhVlNLqmpnFp, P_0, P_1, P_2, P_3);
			}
		}

		private void jiWBjWkTFDMBcYwQXDCoXdtwkQwK()
		{
			if (!TrZAsJCzMkwUGMGhdPhGQOBSdThtA)
			{
				return;
			}
			double realTime;
			try
			{
				tmqeSEpbejKDbGtoJqGKrgHWIdWU.BcCeHBlEyXUkWXPwXPKPBZPgJDpi(eVTHTzuKXJffiHGOwhVlNLqmpnFp);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (fwpbUhjJhGdgMSshPhLqUlWMBpXcA)
			{
				if (lLaOJePOJTNBgnKAgQHmhJrTeENz != null)
				{
					lLaOJePOJTNBgnKAgQHmhJrTeENz.zfQtWvwvFIUehXidqYjzzRxpKxHP(realTime);
				}
				if (!eVTHTzuKXJffiHGOwhVlNLqmpnFp.dlChimRnyepUwJNwgxzTCZnmdHpD(UdHnGxMRccTMYboaKusbWLDXbDwC))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = AIKGUoKFqHheOqPvfpTUCRqmFTfJ.T_CreateEvent())
					{
						FdsBMobHBeYfZmCIoUqkRhixTWbdA.vixblyyUYQWfWQBmMlUWlpDrscIS(eVTHTzuKXJffiHGOwhVlNLqmpnFp, realTime, newEventWrapper.Event);
					}
					UdHnGxMRccTMYboaKusbWLDXbDwC.HKuPtcnsJakmwNvZmwWaQcITFfBk(eVTHTzuKXJffiHGOwhVlNLqmpnFp);
				}
			}
		}

		private void AZPgqeHerBDNmKEJJWcONmkljAifA()
		{
			while (AIKGUoKFqHheOqPvfpTUCRqmFTfJ.ProcessNewEvents())
			{
				RbbdTsiUAobYYeSSbNeKqvYhHdtwb.zMZIqBZRCJJSgJyCuCgQqswJqYwo(ref AIKGUoKFqHheOqPvfpTUCRqmFTfJ.currentEvent);
				for (int i = 0; i < sdQBurdjegiivEIWQVWkYCkgILkeb; i++)
				{
					cemQJbaIctVdsQpYIFYSYuYEHbpA.SetValue(i, RbbdTsiUAobYYeSSbNeKqvYhHdtwb.LfIuIsZgzVFSGXFmmqGRKpWJvWQI[i], AIKGUoKFqHheOqPvfpTUCRqmFTfJ.currentEvent.GetTimestamp());
				}
			}
		}

		private void dSKfFdCvvNrBWjsqIiXGxpgibgif()
		{
			RbbdTsiUAobYYeSSbNeKqvYhHdtwb.LajSWctSVXSTUIPXXMXHaddNYQZk();
			lock (fwpbUhjJhGdgMSshPhLqUlWMBpXcA)
			{
				eVTHTzuKXJffiHGOwhVlNLqmpnFp.GxGcHFSqDsbgPSSPOdMGtQXFcKam();
				UdHnGxMRccTMYboaKusbWLDXbDwC.GxGcHFSqDsbgPSSPOdMGtQXFcKam();
				AIKGUoKFqHheOqPvfpTUCRqmFTfJ.Clear();
			}
			cemQJbaIctVdsQpYIFYSYuYEHbpA.Clear();
		}

		public void Dispose()
		{
			mRHcdLhLDjISrnOSXMknmygAisUrA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void hmMxDLLuONTIHitURiagsLtusuTE()
		{
			try
			{
				mRHcdLhLDjISrnOSXMknmygAisUrA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void mRHcdLhLDjISrnOSXMknmygAisUrA(bool P_0)
		{
			if (!uWMzRYOPHNWdTvjQAGEOjMXqBOLrA)
			{
				if (P_0)
				{
					MYlBoWjODObjzJxIdLZvjrZuWqixA();
					AIKGUoKFqHheOqPvfpTUCRqmFTfJ.Dispose();
				}
				if (WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX != null)
				{
					WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent -= jiWBjWkTFDMBcYwQXDCoXdtwkQwK;
				}
				uWMzRYOPHNWdTvjQAGEOjMXqBOLrA = true;
			}
		}

		private static float IQWqjJsbHOItRVnhubtkagIjtFUm(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class qGrmDdozyQQQbIioMwKZpclCDyxH
	{
		private ppyUYlIAyEDIFFGNqqfLGHCTQykdb ewHtzjZMMXnxpskCRApXulHbdWYeA;

		private ZQKAimLPLExQtotdIUUSOnjeQOaM qldDFXJvLXAsraJBTyAFxErbaNJrA;

		private int zVkymwVaVtnqlPgsZGSzgtmDBwOdb;

		private int zorfatArUSNQRZpnBEiqOeccVvVx;

		private int uxhKpwToANNzMsEUKRrXMcccjfJcA;

		private float WfKSIgsgJiRYjXGCftGvtEYuaqlX;

		public ppyUYlIAyEDIFFGNqqfLGHCTQykdb GBLQavWFpikXMYtibVAUPqexKCAX => ewHtzjZMMXnxpskCRApXulHbdWYeA;

		public static qGrmDdozyQQQbIioMwKZpclCDyxH kBmdCRsveellJSWdDUnoNZJRmcwW(qGrmDdozyQQQbIioMwKZpclCDyxH P_0, ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new qGrmDdozyQQQbIioMwKZpclCDyxH(P_0, P_1);
		}

		public qGrmDdozyQQQbIioMwKZpclCDyxH(ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			qldDFXJvLXAsraJBTyAFxErbaNJrA = new ZQKAimLPLExQtotdIUUSOnjeQOaM(P_0);
			ewHtzjZMMXnxpskCRApXulHbdWYeA = new ppyUYlIAyEDIFFGNqqfLGHCTQykdb();
		}

		private qGrmDdozyQQQbIioMwKZpclCDyxH(qGrmDdozyQQQbIioMwKZpclCDyxH P_0, ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_1)
			: this(P_1, P_0.zVkymwVaVtnqlPgsZGSzgtmDBwOdb, P_0.zorfatArUSNQRZpnBEiqOeccVvVx, P_0.uxhKpwToANNzMsEUKRrXMcccjfJcA, P_0.WfKSIgsgJiRYjXGCftGvtEYuaqlX)
		{
			tDSAQVCgctYziawnSskNCexsHicMA(P_0);
		}

		private qGrmDdozyQQQbIioMwKZpclCDyxH(int P_0, int P_1, int P_2, float P_3)
		{
			zVkymwVaVtnqlPgsZGSzgtmDBwOdb = P_0;
			zorfatArUSNQRZpnBEiqOeccVvVx = P_1;
			uxhKpwToANNzMsEUKRrXMcccjfJcA = P_2;
			WfKSIgsgJiRYjXGCftGvtEYuaqlX = P_3;
		}

		public void zfQtWvwvFIUehXidqYjzzRxpKxHP(double P_0)
		{
			qldDFXJvLXAsraJBTyAFxErbaNJrA.jIPaUeaUpdFpMDDjGrjZcVFGaLEDC(P_0);
			if (!qldDFXJvLXAsraJBTyAFxErbaNJrA.jJtBeBybfAXPBGAKFlBqsGOzDPoq)
			{
				if (P_0 >= qldDFXJvLXAsraJBTyAFxErbaNJrA.wAyzxgmGiIoVMxCldGrrcrmiHAms + (double)WfKSIgsgJiRYjXGCftGvtEYuaqlX)
				{
					ewHtzjZMMXnxpskCRApXulHbdWYeA.GxGcHFSqDsbgPSSPOdMGtQXFcKam();
				}
				return;
			}
			ppyUYlIAyEDIFFGNqqfLGHCTQykdb ppyUYlIAyEDIFFGNqqfLGHCTQykdb2 = qldDFXJvLXAsraJBTyAFxErbaNJrA.jOZcjSNXdOISVFCRYPxuLwZQCfxEA;
			ppyUYlIAyEDIFFGNqqfLGHCTQykdb ppyUYlIAyEDIFFGNqqfLGHCTQykdb3 = qldDFXJvLXAsraJBTyAFxErbaNJrA.ALTDsaHTmMPfgSMuBTfSnsVJlqWxA;
			ewHtzjZMMXnxpskCRApXulHbdWYeA.djmmitcMmZoJbPYrYVFybvKddNnR = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.djmmitcMmZoJbPYrYVFybvKddNnR);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.UnlvwUIYvgwemCBLyHITrxWZGDaN = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.UnlvwUIYvgwemCBLyHITrxWZGDaN);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.XQfZcygjntbsSSRQJjLcoGttavMb = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.XQfZcygjntbsSSRQJjLcoGttavMb);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.FZPurDPxWjTJzDEnBUkGUkiiGSzo = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.FZPurDPxWjTJzDEnBUkGUkiiGSzo);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.XEIsOXPlOCUSXoGHByInlDjNfXMZ = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.XEIsOXPlOCUSXoGHByInlDjNfXMZ);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.CEcCyLXzQxfpKAAyIfINnhuleVNH = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.CEcCyLXzQxfpKAAyIfINnhuleVNH);
			for (int i = 0; i < ewHtzjZMMXnxpskCRApXulHbdWYeA.xhGRoDOrzInljAMDeuDNTcmdrbPp.Length; i++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.xhGRoDOrzInljAMDeuDNTcmdrbPp[i] = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.xhGRoDOrzInljAMDeuDNTcmdrbPp[i]);
			}
			for (int j = 0; j < ewHtzjZMMXnxpskCRApXulHbdWYeA.zwwYiEDefXbIjMelwAAjSwmyIsxF.Length; j++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.zwwYiEDefXbIjMelwAAjSwmyIsxF[j] = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.zwwYiEDefXbIjMelwAAjSwmyIsxF[j]);
			}
			for (int k = 0; k < ewHtzjZMMXnxpskCRApXulHbdWYeA.XbQZoaMPpaDKKEtGcyekRldbtHpV.Length; k++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.XbQZoaMPpaDKKEtGcyekRldbtHpV[k] = ppyUYlIAyEDIFFGNqqfLGHCTQykdb3.XbQZoaMPpaDKKEtGcyekRldbtHpV[k];
			}
			ewHtzjZMMXnxpskCRApXulHbdWYeA.IirdBwKSGHhNjnnGGCnZFWewEqLo = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.IirdBwKSGHhNjnnGGCnZFWewEqLo);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.cxXgqcBmcfknsEIcDQlLgaLqUCNKb = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.cxXgqcBmcfknsEIcDQlLgaLqUCNKb);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.tXXcsgMqIWhWKawKFOqCmyjZumzh = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.tXXcsgMqIWhWKawKFOqCmyjZumzh);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.aRGLlfdbSzisEjBDFdwplMqvrfoj = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.aRGLlfdbSzisEjBDFdwplMqvrfoj);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.tVLbQpHggEGgBDBXvecwpAbuQTjO = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.tVLbQpHggEGgBDBXvecwpAbuQTjO);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.ctOnaunvrcqmwuTOLyJEoaYAYqzj = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.ctOnaunvrcqmwuTOLyJEoaYAYqzj);
			for (int l = 0; l < ewHtzjZMMXnxpskCRApXulHbdWYeA.sukgxNMGEtSDFMtxkRfANBooWpjr.Length; l++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.sukgxNMGEtSDFMtxkRfANBooWpjr[l] = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.sukgxNMGEtSDFMtxkRfANBooWpjr[l]);
			}
			ewHtzjZMMXnxpskCRApXulHbdWYeA.kOmObIdJdSnMIqyRiDjPNljJWXGR = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.kOmObIdJdSnMIqyRiDjPNljJWXGR);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.dfbWWpHBxdSqDLEwywRnoHWhwhFR = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.dfbWWpHBxdSqDLEwywRnoHWhwhFR);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.nLegDadVzYooxORbUifrckVhZgqFB = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.nLegDadVzYooxORbUifrckVhZgqFB);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.mkUVInqZAIkZVetBpHcINFuFbaOL = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.mkUVInqZAIkZVetBpHcINFuFbaOL);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.jlrsXxSiyalTuuwoCkbTBdWPAEon = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.jlrsXxSiyalTuuwoCkbTBdWPAEon);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.bQFoAiSsgktHmcWWNdepXkhIKqgt = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.bQFoAiSsgktHmcWWNdepXkhIKqgt);
			for (int m = 0; m < ewHtzjZMMXnxpskCRApXulHbdWYeA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb.Length; m++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m] = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m]);
			}
			ewHtzjZMMXnxpskCRApXulHbdWYeA.GaixrBoNhNKdHQrryOkmbPyjwaws = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.GaixrBoNhNKdHQrryOkmbPyjwaws);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.mEzautgCFQVUtkvPkTEcImvrtGffA = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.mEzautgCFQVUtkvPkTEcImvrtGffA);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.WjTyPuBJQGheHPdHNmBrKNzKagUZ = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.WjTyPuBJQGheHPdHNmBrKNzKagUZ);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.jvKYSwqbxuDHYekbFwzGNQliclHXA = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.jvKYSwqbxuDHYekbFwzGNQliclHXA);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.YNkwuyhSVXHQFQoPsmRkxLBiXUqe = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.YNkwuyhSVXHQFQoPsmRkxLBiXUqe);
			ewHtzjZMMXnxpskCRApXulHbdWYeA.WrsrVcMOnZdoViEDrmmXlnNwJBqdA = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.WrsrVcMOnZdoViEDrmmXlnNwJBqdA);
			for (int n = 0; n < ewHtzjZMMXnxpskCRApXulHbdWYeA.BBrXCczdJNTGAnmqOJdqPOcjIYBX.Length; n++)
			{
				ewHtzjZMMXnxpskCRApXulHbdWYeA.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n] = sRGCduBSVtthSkFCpmfzLlTHeHDYA(ppyUYlIAyEDIFFGNqqfLGHCTQykdb2.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n]);
			}
		}

		public void tDSAQVCgctYziawnSskNCexsHicMA(qGrmDdozyQQQbIioMwKZpclCDyxH P_0)
		{
			ewHtzjZMMXnxpskCRApXulHbdWYeA.HKuPtcnsJakmwNvZmwWaQcITFfBk(P_0.ewHtzjZMMXnxpskCRApXulHbdWYeA);
			qldDFXJvLXAsraJBTyAFxErbaNJrA.OniogPLcNlbnukCzQxHqmaYGUyIQA(P_0.qldDFXJvLXAsraJBTyAFxErbaNJrA);
			zVkymwVaVtnqlPgsZGSzgtmDBwOdb = P_0.zVkymwVaVtnqlPgsZGSzgtmDBwOdb;
			zorfatArUSNQRZpnBEiqOeccVvVx = P_0.zorfatArUSNQRZpnBEiqOeccVvVx;
			uxhKpwToANNzMsEUKRrXMcccjfJcA = P_0.uxhKpwToANNzMsEUKRrXMcccjfJcA;
			WfKSIgsgJiRYjXGCftGvtEYuaqlX = P_0.WfKSIgsgJiRYjXGCftGvtEYuaqlX;
		}

		private int sRGCduBSVtthSkFCpmfzLlTHeHDYA(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, zVkymwVaVtnqlPgsZGSzgtmDBwOdb, zorfatArUSNQRZpnBEiqOeccVvVx, -65535, 65535);
		}
	}

	private class ZQKAimLPLExQtotdIUUSOnjeQOaM
	{
		private double eGsgzgBXnTLBqkOCNuEtQSaJlfjZA;

		private ppyUYlIAyEDIFFGNqqfLGHCTQykdb etoDTLEBdjqbQdavZKQEOmATtskaA;

		private ppyUYlIAyEDIFFGNqqfLGHCTQykdb bWHfAbFOeMrQKtilQrqZHgotltTnA;

		private ppyUYlIAyEDIFFGNqqfLGHCTQykdb HxisEMVCDZbaKzYPGCVWxpSjWkQB;

		private bool CRoUgXGifskSguuOIBaHMTMIsKoG;

		private double WFxMpwKoipoKQzUBiliSAcLCZmkr;

		public ppyUYlIAyEDIFFGNqqfLGHCTQykdb ALTDsaHTmMPfgSMuBTfSnsVJlqWxA => etoDTLEBdjqbQdavZKQEOmATtskaA;

		public ppyUYlIAyEDIFFGNqqfLGHCTQykdb jOZcjSNXdOISVFCRYPxuLwZQCfxEA => HxisEMVCDZbaKzYPGCVWxpSjWkQB;

		public bool jJtBeBybfAXPBGAKFlBqsGOzDPoq => CRoUgXGifskSguuOIBaHMTMIsKoG;

		public double wAyzxgmGiIoVMxCldGrrcrmiHAms => WFxMpwKoipoKQzUBiliSAcLCZmkr;

		public ZQKAimLPLExQtotdIUUSOnjeQOaM(ppyUYlIAyEDIFFGNqqfLGHCTQykdb P_0)
		{
			etoDTLEBdjqbQdavZKQEOmATtskaA = P_0;
			bWHfAbFOeMrQKtilQrqZHgotltTnA = new ppyUYlIAyEDIFFGNqqfLGHCTQykdb();
			HxisEMVCDZbaKzYPGCVWxpSjWkQB = new ppyUYlIAyEDIFFGNqqfLGHCTQykdb();
		}

		public void jIPaUeaUpdFpMDDjGrjZcVFGaLEDC(double P_0)
		{
			eGsgzgBXnTLBqkOCNuEtQSaJlfjZA = P_0;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.djmmitcMmZoJbPYrYVFybvKddNnR = etoDTLEBdjqbQdavZKQEOmATtskaA.djmmitcMmZoJbPYrYVFybvKddNnR - bWHfAbFOeMrQKtilQrqZHgotltTnA.djmmitcMmZoJbPYrYVFybvKddNnR;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.UnlvwUIYvgwemCBLyHITrxWZGDaN = etoDTLEBdjqbQdavZKQEOmATtskaA.UnlvwUIYvgwemCBLyHITrxWZGDaN - bWHfAbFOeMrQKtilQrqZHgotltTnA.UnlvwUIYvgwemCBLyHITrxWZGDaN;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.XQfZcygjntbsSSRQJjLcoGttavMb = etoDTLEBdjqbQdavZKQEOmATtskaA.XQfZcygjntbsSSRQJjLcoGttavMb - bWHfAbFOeMrQKtilQrqZHgotltTnA.XQfZcygjntbsSSRQJjLcoGttavMb;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.FZPurDPxWjTJzDEnBUkGUkiiGSzo = etoDTLEBdjqbQdavZKQEOmATtskaA.FZPurDPxWjTJzDEnBUkGUkiiGSzo - bWHfAbFOeMrQKtilQrqZHgotltTnA.FZPurDPxWjTJzDEnBUkGUkiiGSzo;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.XEIsOXPlOCUSXoGHByInlDjNfXMZ = etoDTLEBdjqbQdavZKQEOmATtskaA.XEIsOXPlOCUSXoGHByInlDjNfXMZ - bWHfAbFOeMrQKtilQrqZHgotltTnA.XEIsOXPlOCUSXoGHByInlDjNfXMZ;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.CEcCyLXzQxfpKAAyIfINnhuleVNH = etoDTLEBdjqbQdavZKQEOmATtskaA.CEcCyLXzQxfpKAAyIfINnhuleVNH - bWHfAbFOeMrQKtilQrqZHgotltTnA.CEcCyLXzQxfpKAAyIfINnhuleVNH;
			for (int i = 0; i < etoDTLEBdjqbQdavZKQEOmATtskaA.xhGRoDOrzInljAMDeuDNTcmdrbPp.Length; i++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.xhGRoDOrzInljAMDeuDNTcmdrbPp[i] = etoDTLEBdjqbQdavZKQEOmATtskaA.xhGRoDOrzInljAMDeuDNTcmdrbPp[i] - bWHfAbFOeMrQKtilQrqZHgotltTnA.xhGRoDOrzInljAMDeuDNTcmdrbPp[i];
			}
			for (int j = 0; j < etoDTLEBdjqbQdavZKQEOmATtskaA.zwwYiEDefXbIjMelwAAjSwmyIsxF.Length; j++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.zwwYiEDefXbIjMelwAAjSwmyIsxF[j] = etoDTLEBdjqbQdavZKQEOmATtskaA.zwwYiEDefXbIjMelwAAjSwmyIsxF[j] - bWHfAbFOeMrQKtilQrqZHgotltTnA.zwwYiEDefXbIjMelwAAjSwmyIsxF[j];
			}
			for (int k = 0; k < etoDTLEBdjqbQdavZKQEOmATtskaA.XbQZoaMPpaDKKEtGcyekRldbtHpV.Length; k++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.XbQZoaMPpaDKKEtGcyekRldbtHpV[k] = etoDTLEBdjqbQdavZKQEOmATtskaA.XbQZoaMPpaDKKEtGcyekRldbtHpV[k] != bWHfAbFOeMrQKtilQrqZHgotltTnA.XbQZoaMPpaDKKEtGcyekRldbtHpV[k];
			}
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.IirdBwKSGHhNjnnGGCnZFWewEqLo = etoDTLEBdjqbQdavZKQEOmATtskaA.IirdBwKSGHhNjnnGGCnZFWewEqLo - bWHfAbFOeMrQKtilQrqZHgotltTnA.IirdBwKSGHhNjnnGGCnZFWewEqLo;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.cxXgqcBmcfknsEIcDQlLgaLqUCNKb = etoDTLEBdjqbQdavZKQEOmATtskaA.cxXgqcBmcfknsEIcDQlLgaLqUCNKb - bWHfAbFOeMrQKtilQrqZHgotltTnA.cxXgqcBmcfknsEIcDQlLgaLqUCNKb;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.tXXcsgMqIWhWKawKFOqCmyjZumzh = etoDTLEBdjqbQdavZKQEOmATtskaA.tXXcsgMqIWhWKawKFOqCmyjZumzh - bWHfAbFOeMrQKtilQrqZHgotltTnA.tXXcsgMqIWhWKawKFOqCmyjZumzh;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.aRGLlfdbSzisEjBDFdwplMqvrfoj = etoDTLEBdjqbQdavZKQEOmATtskaA.aRGLlfdbSzisEjBDFdwplMqvrfoj - bWHfAbFOeMrQKtilQrqZHgotltTnA.aRGLlfdbSzisEjBDFdwplMqvrfoj;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.tVLbQpHggEGgBDBXvecwpAbuQTjO = etoDTLEBdjqbQdavZKQEOmATtskaA.tVLbQpHggEGgBDBXvecwpAbuQTjO - bWHfAbFOeMrQKtilQrqZHgotltTnA.tVLbQpHggEGgBDBXvecwpAbuQTjO;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.ctOnaunvrcqmwuTOLyJEoaYAYqzj = etoDTLEBdjqbQdavZKQEOmATtskaA.ctOnaunvrcqmwuTOLyJEoaYAYqzj - bWHfAbFOeMrQKtilQrqZHgotltTnA.ctOnaunvrcqmwuTOLyJEoaYAYqzj;
			for (int l = 0; l < etoDTLEBdjqbQdavZKQEOmATtskaA.sukgxNMGEtSDFMtxkRfANBooWpjr.Length; l++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.sukgxNMGEtSDFMtxkRfANBooWpjr[l] = etoDTLEBdjqbQdavZKQEOmATtskaA.sukgxNMGEtSDFMtxkRfANBooWpjr[l] - bWHfAbFOeMrQKtilQrqZHgotltTnA.sukgxNMGEtSDFMtxkRfANBooWpjr[l];
			}
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.kOmObIdJdSnMIqyRiDjPNljJWXGR = etoDTLEBdjqbQdavZKQEOmATtskaA.kOmObIdJdSnMIqyRiDjPNljJWXGR - bWHfAbFOeMrQKtilQrqZHgotltTnA.kOmObIdJdSnMIqyRiDjPNljJWXGR;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.dfbWWpHBxdSqDLEwywRnoHWhwhFR = etoDTLEBdjqbQdavZKQEOmATtskaA.dfbWWpHBxdSqDLEwywRnoHWhwhFR - bWHfAbFOeMrQKtilQrqZHgotltTnA.dfbWWpHBxdSqDLEwywRnoHWhwhFR;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.nLegDadVzYooxORbUifrckVhZgqFB = etoDTLEBdjqbQdavZKQEOmATtskaA.nLegDadVzYooxORbUifrckVhZgqFB - bWHfAbFOeMrQKtilQrqZHgotltTnA.nLegDadVzYooxORbUifrckVhZgqFB;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.mkUVInqZAIkZVetBpHcINFuFbaOL = etoDTLEBdjqbQdavZKQEOmATtskaA.mkUVInqZAIkZVetBpHcINFuFbaOL - bWHfAbFOeMrQKtilQrqZHgotltTnA.mkUVInqZAIkZVetBpHcINFuFbaOL;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.jlrsXxSiyalTuuwoCkbTBdWPAEon = etoDTLEBdjqbQdavZKQEOmATtskaA.jlrsXxSiyalTuuwoCkbTBdWPAEon - bWHfAbFOeMrQKtilQrqZHgotltTnA.jlrsXxSiyalTuuwoCkbTBdWPAEon;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.bQFoAiSsgktHmcWWNdepXkhIKqgt = etoDTLEBdjqbQdavZKQEOmATtskaA.bQFoAiSsgktHmcWWNdepXkhIKqgt - bWHfAbFOeMrQKtilQrqZHgotltTnA.bQFoAiSsgktHmcWWNdepXkhIKqgt;
			for (int m = 0; m < etoDTLEBdjqbQdavZKQEOmATtskaA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb.Length; m++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m] = etoDTLEBdjqbQdavZKQEOmATtskaA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m] - bWHfAbFOeMrQKtilQrqZHgotltTnA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m];
			}
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.GaixrBoNhNKdHQrryOkmbPyjwaws = etoDTLEBdjqbQdavZKQEOmATtskaA.GaixrBoNhNKdHQrryOkmbPyjwaws - bWHfAbFOeMrQKtilQrqZHgotltTnA.GaixrBoNhNKdHQrryOkmbPyjwaws;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.mEzautgCFQVUtkvPkTEcImvrtGffA = etoDTLEBdjqbQdavZKQEOmATtskaA.mEzautgCFQVUtkvPkTEcImvrtGffA - bWHfAbFOeMrQKtilQrqZHgotltTnA.mEzautgCFQVUtkvPkTEcImvrtGffA;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.WjTyPuBJQGheHPdHNmBrKNzKagUZ = etoDTLEBdjqbQdavZKQEOmATtskaA.WjTyPuBJQGheHPdHNmBrKNzKagUZ - bWHfAbFOeMrQKtilQrqZHgotltTnA.WjTyPuBJQGheHPdHNmBrKNzKagUZ;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.jvKYSwqbxuDHYekbFwzGNQliclHXA = etoDTLEBdjqbQdavZKQEOmATtskaA.jvKYSwqbxuDHYekbFwzGNQliclHXA - bWHfAbFOeMrQKtilQrqZHgotltTnA.jvKYSwqbxuDHYekbFwzGNQliclHXA;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.YNkwuyhSVXHQFQoPsmRkxLBiXUqe = etoDTLEBdjqbQdavZKQEOmATtskaA.YNkwuyhSVXHQFQoPsmRkxLBiXUqe - bWHfAbFOeMrQKtilQrqZHgotltTnA.YNkwuyhSVXHQFQoPsmRkxLBiXUqe;
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.WrsrVcMOnZdoViEDrmmXlnNwJBqdA = etoDTLEBdjqbQdavZKQEOmATtskaA.WrsrVcMOnZdoViEDrmmXlnNwJBqdA - bWHfAbFOeMrQKtilQrqZHgotltTnA.WrsrVcMOnZdoViEDrmmXlnNwJBqdA;
			for (int n = 0; n < etoDTLEBdjqbQdavZKQEOmATtskaA.BBrXCczdJNTGAnmqOJdqPOcjIYBX.Length; n++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n] = etoDTLEBdjqbQdavZKQEOmATtskaA.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n] - bWHfAbFOeMrQKtilQrqZHgotltTnA.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n];
			}
			CRoUgXGifskSguuOIBaHMTMIsKoG = WydDqHvFlxxhboaaFyVJMyPsJFIH();
			if (CRoUgXGifskSguuOIBaHMTMIsKoG)
			{
				WFxMpwKoipoKQzUBiliSAcLCZmkr = P_0;
				bWHfAbFOeMrQKtilQrqZHgotltTnA.HKuPtcnsJakmwNvZmwWaQcITFfBk(etoDTLEBdjqbQdavZKQEOmATtskaA);
			}
		}

		public void OniogPLcNlbnukCzQxHqmaYGUyIQA(ZQKAimLPLExQtotdIUUSOnjeQOaM P_0)
		{
			eGsgzgBXnTLBqkOCNuEtQSaJlfjZA = P_0.eGsgzgBXnTLBqkOCNuEtQSaJlfjZA;
			bWHfAbFOeMrQKtilQrqZHgotltTnA.HKuPtcnsJakmwNvZmwWaQcITFfBk(P_0.bWHfAbFOeMrQKtilQrqZHgotltTnA);
			HxisEMVCDZbaKzYPGCVWxpSjWkQB.HKuPtcnsJakmwNvZmwWaQcITFfBk(P_0.HxisEMVCDZbaKzYPGCVWxpSjWkQB);
		}

		private bool WydDqHvFlxxhboaaFyVJMyPsJFIH()
		{
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.UnlvwUIYvgwemCBLyHITrxWZGDaN != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.XQfZcygjntbsSSRQJjLcoGttavMb != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.FZPurDPxWjTJzDEnBUkGUkiiGSzo != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.XEIsOXPlOCUSXoGHByInlDjNfXMZ != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.CEcCyLXzQxfpKAAyIfINnhuleVNH != 0)
			{
				return true;
			}
			for (int i = 0; i < etoDTLEBdjqbQdavZKQEOmATtskaA.xhGRoDOrzInljAMDeuDNTcmdrbPp.Length; i++)
			{
				if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.xhGRoDOrzInljAMDeuDNTcmdrbPp[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < etoDTLEBdjqbQdavZKQEOmATtskaA.zwwYiEDefXbIjMelwAAjSwmyIsxF.Length; j++)
			{
				if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.zwwYiEDefXbIjMelwAAjSwmyIsxF[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < etoDTLEBdjqbQdavZKQEOmATtskaA.XbQZoaMPpaDKKEtGcyekRldbtHpV.Length; k++)
			{
				if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.XbQZoaMPpaDKKEtGcyekRldbtHpV[k])
				{
					return true;
				}
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.IirdBwKSGHhNjnnGGCnZFWewEqLo != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.cxXgqcBmcfknsEIcDQlLgaLqUCNKb != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.tXXcsgMqIWhWKawKFOqCmyjZumzh != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.aRGLlfdbSzisEjBDFdwplMqvrfoj != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.tVLbQpHggEGgBDBXvecwpAbuQTjO != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.ctOnaunvrcqmwuTOLyJEoaYAYqzj != 0)
			{
				return true;
			}
			for (int l = 0; l < etoDTLEBdjqbQdavZKQEOmATtskaA.sukgxNMGEtSDFMtxkRfANBooWpjr.Length; l++)
			{
				if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.sukgxNMGEtSDFMtxkRfANBooWpjr[l] != 0)
				{
					return true;
				}
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.kOmObIdJdSnMIqyRiDjPNljJWXGR != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.dfbWWpHBxdSqDLEwywRnoHWhwhFR != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.nLegDadVzYooxORbUifrckVhZgqFB != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.mkUVInqZAIkZVetBpHcINFuFbaOL != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.jlrsXxSiyalTuuwoCkbTBdWPAEon != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.bQFoAiSsgktHmcWWNdepXkhIKqgt != 0)
			{
				return true;
			}
			for (int m = 0; m < etoDTLEBdjqbQdavZKQEOmATtskaA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb.Length; m++)
			{
				HxisEMVCDZbaKzYPGCVWxpSjWkQB.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m] = etoDTLEBdjqbQdavZKQEOmATtskaA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m] - bWHfAbFOeMrQKtilQrqZHgotltTnA.WcXRbpMJwwdWoHunYoCOSjzBFdrcb[m];
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.GaixrBoNhNKdHQrryOkmbPyjwaws != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.mEzautgCFQVUtkvPkTEcImvrtGffA != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.WjTyPuBJQGheHPdHNmBrKNzKagUZ != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.jvKYSwqbxuDHYekbFwzGNQliclHXA != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.YNkwuyhSVXHQFQoPsmRkxLBiXUqe != 0)
			{
				return true;
			}
			if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.WrsrVcMOnZdoViEDrmmXlnNwJBqdA != 0)
			{
				return true;
			}
			for (int n = 0; n < etoDTLEBdjqbQdavZKQEOmATtskaA.BBrXCczdJNTGAnmqOJdqPOcjIYBX.Length; n++)
			{
				if (HxisEMVCDZbaKzYPGCVWxpSjWkQB.BBrXCczdJNTGAnmqOJdqPOcjIYBX[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class NfnLYwCTDDFjMJRqVPeCzSmDESRN
	{
		public enum vacFSerwpXvYzyroHnPQbxgMCFK
		{
			Exact = 0,
			Approximate = 1
		}

		public class BvPauDHSVlHzDOhOkgvacwrdoMfEb
		{
			public int tUlDwLYPHdzxXkVueEFqSgDgrAlr;

			public Guid djnQOixQMeXpiGEbXQwCivKIsCLm;

			public Guid haLqvxvICZJkomcYWGHQggMHEoGAb;

			public int ofwyytQLMRdgphLzdXDlgzsedoHf;

			public int bQycEuaJWwlmSRuSUnaIbMfEKbcoB;

			public int UcAgJfDWEuHeusmvfoiTEtTEHZCeb;

			public int jbVulkyvkurndFbRaFMoSLqSdUtE;

			public bool cEyoxRpszDmbozzQzAgkkFgbsBRX(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, vacFSerwpXvYzyroHnPQbxgMCFK P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == tUlDwLYPHdzxXkVueEFqSgDgrAlr)
				{
					return true;
				}
				if (bQycEuaJWwlmSRuSUnaIbMfEKbcoB != P_0.cAGbpadCFHslPrHhQaEfhyuuoGMW)
				{
					return false;
				}
				if (UcAgJfDWEuHeusmvfoiTEtTEHZCeb != P_0.cXcNrMRVGoanCIZRAKAkaUYXayoq)
				{
					return false;
				}
				if (jbVulkyvkurndFbRaFMoSLqSdUtE != P_0.dWHlAGlBJFCjZJQsYMmilVVxiwMfb)
				{
					return false;
				}
				return P_1 switch
				{
					vacFSerwpXvYzyroHnPQbxgMCFK.Exact => djnQOixQMeXpiGEbXQwCivKIsCLm == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					vacFSerwpXvYzyroHnPQbxgMCFK.Approximate => haLqvxvICZJkomcYWGHQggMHEoGAb == P_0.uYjRZjjknrZkGauDtFUmeWdyFCAe, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string pgomMcDyvlUUtnOkOUMdTBHTAFAC()
			{
				string text = "" + "rewiredId = " + tUlDwLYPHdzxXkVueEFqSgDgrAlr + "\n";
				Guid guid = djnQOixQMeXpiGEbXQwCivKIsCLm;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = haLqvxvICZJkomcYWGHQggMHEoGAb;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", ofwyytQLMRdgphLzdXDlgzsedoHf.ToString(), "\n"), "hardwareAxisCount = ", bQycEuaJWwlmSRuSUnaIbMfEKbcoB.ToString(), "\n"), "hardwareButtonCount = ", UcAgJfDWEuHeusmvfoiTEtTEHZCeb.ToString(), "\n"), "hardwareHatCount = ", jbVulkyvkurndFbRaFMoSLqSdUtE.ToString(), "\n");
			}
		}

		private sealed class fuWuuVDQvZHyTUkhNwIwTiDtArVT : IEnumerable<BvPauDHSVlHzDOhOkgvacwrdoMfEb>, IEnumerable, IEnumerator<BvPauDHSVlHzDOhOkgvacwrdoMfEb>, IEnumerator, IDisposable
		{
			private int vmGccbifDmSaaNCgtSPJcStimWCcA;

			private BvPauDHSVlHzDOhOkgvacwrdoMfEb bMNutvNLVCgAelAPIidqOAMVElom;

			private int wUWMVKMPLXRrwHjVqCTVcyXXYjqqA;

			public NfnLYwCTDDFjMJRqVPeCzSmDESRN AFyhseJXdhIZUcXjpsmICfCRAfHR;

			private pLnbctCxXNbPwKWEvlJdVbqyluUL kekQvasleNBbJdipRzhcgXmbgvJe;

			public pLnbctCxXNbPwKWEvlJdVbqyluUL RvrFIgPHfFWanNwaLICWnFrrDxxG;

			private vacFSerwpXvYzyroHnPQbxgMCFK rFIEzCgaXlvMbfBGpsnIzEZBjyDg;

			public vacFSerwpXvYzyroHnPQbxgMCFK kInTKnXjryahxyRCbvYMqEUhGjLt;

			private int kgSJUvrUSZQfJhBCRNPepUVinqKf;

			private int BTCBYfCSlGbmdwyrZVXuSeTwRxlQA;

			BvPauDHSVlHzDOhOkgvacwrdoMfEb IEnumerator<BvPauDHSVlHzDOhOkgvacwrdoMfEb>.Current
			{
				[DebuggerHidden]
				get
				{
					return bMNutvNLVCgAelAPIidqOAMVElom;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bMNutvNLVCgAelAPIidqOAMVElom;
				}
			}

			[DebuggerHidden]
			public fuWuuVDQvZHyTUkhNwIwTiDtArVT(int P_0)
			{
				vmGccbifDmSaaNCgtSPJcStimWCcA = P_0;
				wUWMVKMPLXRrwHjVqCTVcyXXYjqqA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = vmGccbifDmSaaNCgtSPJcStimWCcA;
				NfnLYwCTDDFjMJRqVPeCzSmDESRN aFyhseJXdhIZUcXjpsmICfCRAfHR = AFyhseJXdhIZUcXjpsmICfCRAfHR;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					vmGccbifDmSaaNCgtSPJcStimWCcA = -1;
					goto IL_0083;
				}
				vmGccbifDmSaaNCgtSPJcStimWCcA = -1;
				kgSJUvrUSZQfJhBCRNPepUVinqKf = aFyhseJXdhIZUcXjpsmICfCRAfHR.yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count;
				BTCBYfCSlGbmdwyrZVXuSeTwRxlQA = 0;
				goto IL_0093;
				IL_0083:
				BTCBYfCSlGbmdwyrZVXuSeTwRxlQA++;
				goto IL_0093;
				IL_0093:
				if (BTCBYfCSlGbmdwyrZVXuSeTwRxlQA < kgSJUvrUSZQfJhBCRNPepUVinqKf)
				{
					if (aFyhseJXdhIZUcXjpsmICfCRAfHR.yeCVKCuSlEVvPDBnKqzazyAOdGpO[BTCBYfCSlGbmdwyrZVXuSeTwRxlQA].cEyoxRpszDmbozzQzAgkkFgbsBRX(kekQvasleNBbJdipRzhcgXmbgvJe, rFIEzCgaXlvMbfBGpsnIzEZBjyDg))
					{
						bMNutvNLVCgAelAPIidqOAMVElom = aFyhseJXdhIZUcXjpsmICfCRAfHR.yeCVKCuSlEVvPDBnKqzazyAOdGpO[BTCBYfCSlGbmdwyrZVXuSeTwRxlQA];
						vmGccbifDmSaaNCgtSPJcStimWCcA = 1;
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
			IEnumerator<BvPauDHSVlHzDOhOkgvacwrdoMfEb> IEnumerable<BvPauDHSVlHzDOhOkgvacwrdoMfEb>.GetEnumerator()
			{
				fuWuuVDQvZHyTUkhNwIwTiDtArVT fuWuuVDQvZHyTUkhNwIwTiDtArVT2;
				if (vmGccbifDmSaaNCgtSPJcStimWCcA == -2 && wUWMVKMPLXRrwHjVqCTVcyXXYjqqA == Environment.CurrentManagedThreadId)
				{
					vmGccbifDmSaaNCgtSPJcStimWCcA = 0;
					fuWuuVDQvZHyTUkhNwIwTiDtArVT2 = this;
				}
				else
				{
					fuWuuVDQvZHyTUkhNwIwTiDtArVT2 = new fuWuuVDQvZHyTUkhNwIwTiDtArVT(0);
					fuWuuVDQvZHyTUkhNwIwTiDtArVT2.AFyhseJXdhIZUcXjpsmICfCRAfHR = AFyhseJXdhIZUcXjpsmICfCRAfHR;
				}
				fuWuuVDQvZHyTUkhNwIwTiDtArVT2.kekQvasleNBbJdipRzhcgXmbgvJe = RvrFIgPHfFWanNwaLICWnFrrDxxG;
				fuWuuVDQvZHyTUkhNwIwTiDtArVT2.rFIEzCgaXlvMbfBGpsnIzEZBjyDg = kInTKnXjryahxyRCbvYMqEUhGjLt;
				return fuWuuVDQvZHyTUkhNwIwTiDtArVT2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<BvPauDHSVlHzDOhOkgvacwrdoMfEb>)this).GetEnumerator();
			}
		}

		private List<BvPauDHSVlHzDOhOkgvacwrdoMfEb> yeCVKCuSlEVvPDBnKqzazyAOdGpO;

		public NfnLYwCTDDFjMJRqVPeCzSmDESRN()
		{
			yeCVKCuSlEVvPDBnKqzazyAOdGpO = new List<BvPauDHSVlHzDOhOkgvacwrdoMfEb>();
		}

		public void bTAtRGHLvakPdVclWlWiyzPIFrIq(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count;
			for (int i = 0; i < count; i++)
			{
				if (yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].cEyoxRpszDmbozzQzAgkkFgbsBRX(P_0, vacFSerwpXvYzyroHnPQbxgMCFK.Exact))
				{
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].tUlDwLYPHdzxXkVueEFqSgDgrAlr = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].djnQOixQMeXpiGEbXQwCivKIsCLm = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].haLqvxvICZJkomcYWGHQggMHEoGAb = P_0.uYjRZjjknrZkGauDtFUmeWdyFCAe;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].ofwyytQLMRdgphLzdXDlgzsedoHf = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].bQycEuaJWwlmSRuSUnaIbMfEKbcoB = P_0.cAGbpadCFHslPrHhQaEfhyuuoGMW;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].UcAgJfDWEuHeusmvfoiTEtTEHZCeb = P_0.cXcNrMRVGoanCIZRAKAkaUYXayoq;
					yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].jbVulkyvkurndFbRaFMoSLqSdUtE = P_0.dWHlAGlBJFCjZJQsYMmilVVxiwMfb;
					nFqSYyUWRPqcqIqZQKbBLDeXcuBHA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			yeCVKCuSlEVvPDBnKqzazyAOdGpO.Add(new BvPauDHSVlHzDOhOkgvacwrdoMfEb
			{
				tUlDwLYPHdzxXkVueEFqSgDgrAlr = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				djnQOixQMeXpiGEbXQwCivKIsCLm = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				haLqvxvICZJkomcYWGHQggMHEoGAb = P_0.uYjRZjjknrZkGauDtFUmeWdyFCAe,
				ofwyytQLMRdgphLzdXDlgzsedoHf = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				bQycEuaJWwlmSRuSUnaIbMfEKbcoB = P_0.cAGbpadCFHslPrHhQaEfhyuuoGMW,
				UcAgJfDWEuHeusmvfoiTEtTEHZCeb = P_0.cXcNrMRVGoanCIZRAKAkaUYXayoq,
				jbVulkyvkurndFbRaFMoSLqSdUtE = P_0.dWHlAGlBJFCjZJQsYMmilVVxiwMfb
			});
			nFqSYyUWRPqcqIqZQKbBLDeXcuBHA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count - 1);
		}

		public bool oFwHaBcWMWUUfzabQOvFgERygsjl(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, vacFSerwpXvYzyroHnPQbxgMCFK P_1)
		{
			int count = yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count;
			for (int i = 0; i < count; i++)
			{
				if (yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].cEyoxRpszDmbozzQzAgkkFgbsBRX(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(fuWuuVDQvZHyTUkhNwIwTiDtArVT))]
		public IEnumerable<BvPauDHSVlHzDOhOkgvacwrdoMfEb> VrgOGXYlchFTDjJJzlLKptrkkDyAb(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, vacFSerwpXvYzyroHnPQbxgMCFK P_1)
		{
			return new fuWuuVDQvZHyTUkhNwIwTiDtArVT(-2)
			{
				AFyhseJXdhIZUcXjpsmICfCRAfHR = this,
				RvrFIgPHfFWanNwaLICWnFrrDxxG = P_0,
				kInTKnXjryahxyRCbvYMqEUhGjLt = P_1
			};
		}

		private void nFqSYyUWRPqcqIqZQKbBLDeXcuBHA(int P_0, Guid P_1, int P_2)
		{
			for (int num = yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (yeCVKCuSlEVvPDBnKqzazyAOdGpO[num].tUlDwLYPHdzxXkVueEFqSgDgrAlr == P_0 || yeCVKCuSlEVvPDBnKqzazyAOdGpO[num].djnQOixQMeXpiGEbXQwCivKIsCLm == P_1))
				{
					yeCVKCuSlEVvPDBnKqzazyAOdGpO.RemoveAt(num);
				}
			}
		}

		public virtual string RQMMdYmFvhfHSwmqAGwukFBUUdmH()
		{
			string text = "";
			text = text + "Joystick records: " + yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count + "\n";
			for (int i = 0; i < yeCVKCuSlEVvPDBnKqzazyAOdGpO.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + yeCVKCuSlEVvPDBnKqzazyAOdGpO[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class JxutsCzrIuJRPPGngJHyfEaKrbeb
	{
		public pLnbctCxXNbPwKWEvlJdVbqyluUL HMTTPczstAhhUOzmpFOVZQFkgxjS;

		public TtTEWPAmgCXtCiwlxHCRLqWtUGyz TRNlaBzkFpzZEPdOnCWrcpXwztziA;

		public bool CBSibPeJhjseFkbmESzoveeePlwT
		{
			get
			{
				if (HMTTPczstAhhUOzmpFOVZQFkgxjS != null)
				{
					return TRNlaBzkFpzZEPdOnCWrcpXwztziA != null;
				}
				return false;
			}
		}

		public JxutsCzrIuJRPPGngJHyfEaKrbeb(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, TtTEWPAmgCXtCiwlxHCRLqWtUGyz P_1)
		{
			HMTTPczstAhhUOzmpFOVZQFkgxjS = P_0;
			TRNlaBzkFpzZEPdOnCWrcpXwztziA = P_1;
		}

		public static List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> NhiBcyBVJfGXOHNXaEpkfeNwgogq(List<JxutsCzrIuJRPPGngJHyfEaKrbeb> P_0)
		{
			if (P_0 == null)
			{
				return new List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz>();
			}
			List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> list = new List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].CBSibPeJhjseFkbmESzoveeePlwT)
				{
					list.Add(P_0[i].TRNlaBzkFpzZEPdOnCWrcpXwztziA);
				}
			}
			return list;
		}
	}

	private class MaGjOQVLnjXjXRijOFJhTgXOrOej
	{
		public DiJVETKbnrpIufzFejttIwRifnEK jvwIoAllPnAJwGYarsosCIBzsuMOA;

		public MaGjOQVLnjXjXRijOFJhTgXOrOej(DiJVETKbnrpIufzFejttIwRifnEK P_0)
		{
			jvwIoAllPnAJwGYarsosCIBzsuMOA = P_0;
		}
	}

	private class mQBxLRqzfEhSViUcsqdrVbPNSCbw
	{
		private FMYuCeSKHXgEATgpxokEweMRESyu.vybKZVsZANnLoraXvYYNMzlKEnpO QIRuMoJucsbiCWSfffpuCVUqHuFz;

		private FMYuCeSKHXgEATgpxokEweMRESyu.UKUXoHiSxKfhbEnWapmPwcQLanPI ADreCnyXsSsShlgIsTlQPtrGkUnR;

		private NativeBuffer qIxFqbKqRAUIOvZsKhcvkDPyBNIl;

		private int FpbfMWZpsIkRIRZQquwzYgxbhKLC;

		public mQBxLRqzfEhSViUcsqdrVbPNSCbw()
		{
			QIRuMoJucsbiCWSfffpuCVUqHuFz = new FMYuCeSKHXgEATgpxokEweMRESyu.vybKZVsZANnLoraXvYYNMzlKEnpO
			{
				nBiizthhobcMiIKzDVRGscWdPCIhA = (uint)Marshal.SizeOf(typeof(FMYuCeSKHXgEATgpxokEweMRESyu.vybKZVsZANnLoraXvYYNMzlKEnpO)),
				zeslROaAfJeUJAAoGOovCoogHKzEB = true,
				zhtNEWaWdKCmcyOYSxSsRlummnDO = true,
				tNbJlQvlNYozoLBTzcFnjCYehPhgb = false,
				bxMoTsJOXlScQrbsYPgLJTzEobtg = true,
				ckZfwIvQBJFSBNojqtSwHQGetmAK = IntPtr.Zero
			};
			ADreCnyXsSsShlgIsTlQPtrGkUnR = FMYuCeSKHXgEATgpxokEweMRESyu.UKUXoHiSxKfhbEnWapmPwcQLanPI.NNUpwZpGRswDKSCOhVnUSFwrVVyV();
			qIxFqbKqRAUIOvZsKhcvkDPyBNIl = new NativeBuffer((int)ADreCnyXsSsShlgIsTlQPtrGkUnR.qkFTAxWfLYmHVVTczLWwWGjCGorA);
			qIxFqbKqRAUIOvZsKhcvkDPyBNIl.Write(ADreCnyXsSsShlgIsTlQPtrGkUnR.qkFTAxWfLYmHVVTczLWwWGjCGorA, 0);
		}

		public bool oYSFqbVSTTcmpzhJLKnybkuzdVzE()
		{
			int num = BIueyznkEwonOTaUQSkkLGCZtGZl();
			if (num == FpbfMWZpsIkRIRZQquwzYgxbhKLC)
			{
				return false;
			}
			FpbfMWZpsIkRIRZQquwzYgxbhKLC = num;
			return true;
		}

		public void oMBhGEAizqFbfKGErKQicwpCuEtgB(int P_0)
		{
			FpbfMWZpsIkRIRZQquwzYgxbhKLC = P_0;
		}

		private int BIueyznkEwonOTaUQSkkLGCZtGZl()
		{
			try
			{
				return OPLEcXnXDXrWZrMZuMEHPFiRdVOC.FpkkWnRXbYYAQbxsOKgbEDUmESVF(ref QIRuMoJucsbiCWSfffpuCVUqHuFz, qIxFqbKqRAUIOvZsKhcvkDPyBNIl);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum YHBoSiEgJmbVHxbppfOYBehIaUzQ
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

	private const ruYRpisEghgnBUWQDMCzFKdYMDaM dIdQxSzUpJODHztwtkHdDPuTjpbg = ruYRpisEghgnBUWQDMCzFKdYMDaM.GameControl;

	private const VruoKSWLPeRfmJpNHaCJctBwRVFp TlNgqTeyDCigqQIgBNONrblOxTAPA = VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly;

	private IntPtr FPGWRTvVcRRNbOOWivOKtWZXgiNp;

	private EDFdvGfovhQrLKAgmMSedZFXctJPA jXNHNCbJNSGRLRfeYIAoCJnAeKjJ;

	private List<pLnbctCxXNbPwKWEvlJdVbqyluUL> KeQsTjCNvtuonfgoubXFFIbFGxHSA;

	private int itrDpOPfJYxIabtCjiCTbUNtDLZFb;

	private NfnLYwCTDDFjMJRqVPeCzSmDESRN MMUYVKFJtQPFTscAVXwcKfSZjcgq;

	private bool eECJlmbEmETMrJpFnAANjVnXXBZy;

	private MpfSAJjorzYIlCIHNIPpIhZKdISt PycNQrXPAYhSoRBSGNeRAPOdgqXi;

	private UpdateLoopSetting aVkQzzicRdZbLXhRxpNqVrnXePLi;

	private Action<int, ControllerDataUpdater> wTMMNJTqClXPpgJlGftAbhbUsShHA;

	private PlatformInputManager scyiiKbeWRVUBlMtyiKrJgXLxtmV;

	private TimerRealTime IIJWTHeNXmBvWbPFfpzmSUICHicbA;

	private global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool> GLGflZQcsfhBjTEPDyijWFdLWVO;

	private mQBxLRqzfEhSViUcsqdrVbPNSCbw CedgzMoixrUnVXMSRsTTxuNIntrA;

	private int owUVsrvoBNxrcseucsAiTlesdaTq;

	private int vCWOuoAesRwOxBwRTwwYQgcRiSic;

	private global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<List<JxutsCzrIuJRPPGngJHyfEaKrbeb>> TdmUbiXaTCsINWNkkbrYcEAqhlUrA;

	private readonly object FipcYDtXkkDHjRmbLBoSBCxSamoz = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> baolmZPKeDfSIJcjWJgaMTjCiSUu;

	private Func<int> SQVGMPGyWxjESnDUsAZIigAgeVhzA;

	MpfSAJjorzYIlCIHNIPpIhZKdISt WcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu
	{
		get
		{
			return PycNQrXPAYhSoRBSGNeRAPOdgqXi;
		}
		set
		{
			PycNQrXPAYhSoRBSGNeRAPOdgqXi = pycNQrXPAYhSoRBSGNeRAPOdgqXi;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => itrDpOPfJYxIabtCjiCTbUNtDLZFb;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => scyiiKbeWRVUBlMtyiKrJgXLxtmV;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<EDFdvGfovhQrLKAgmMSedZFXctJPA>(jXNHNCbJNSGRLRfeYIAoCJnAeKjJ);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public hJTsUFYdZHioKpvWwgoNOlLVAREN(UpdateLoopSetting P_0, MpfSAJjorzYIlCIHNIPpIhZKdISt P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			aVkQzzicRdZbLXhRxpNqVrnXePLi = P_0;
			PycNQrXPAYhSoRBSGNeRAPOdgqXi = P_1;
			FPGWRTvVcRRNbOOWivOKtWZXgiNp = P_2;
			baolmZPKeDfSIJcjWJgaMTjCiSUu = P_3;
			SQVGMPGyWxjESnDUsAZIigAgeVhzA = P_4;
			scyiiKbeWRVUBlMtyiKrJgXLxtmV = this;
			jXNHNCbJNSGRLRfeYIAoCJnAeKjJ = new EDFdvGfovhQrLKAgmMSedZFXctJPA();
			wTMMNJTqClXPpgJlGftAbhbUsShHA = UpdateControllerData;
			CedgzMoixrUnVXMSRsTTxuNIntrA = new mQBxLRqzfEhSViUcsqdrVbPNSCbw();
			GLGflZQcsfhBjTEPDyijWFdLWVO = new global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool>(true, FzYdcbzVPzafvJxIsrHTASSXRLhH);
			TdmUbiXaTCsINWNkkbrYcEAqhlUrA = new global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<List<JxutsCzrIuJRPPGngJHyfEaKrbeb>>(true, () => ADefLIIAhQmwavOPlwaJOUZnqJTMA());
			UaOQntoEOeHgwhglsDktEOAdsVufc();
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
		MMUYVKFJtQPFTscAVXwcKfSZjcgq = new NfnLYwCTDDFjMJRqVPeCzSmDESRN();
		IIJWTHeNXmBvWbPFfpzmSUICHicbA = new TimerRealTime(1.0);
		IIJWTHeNXmBvWbPFfpzmSUICHicbA.Start();
		cEvCVVzvlTHrcbqsfUhurMPVAgyv();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		dGJPNCNRTXbREhezySPILbASKGYEA();
		MuzqimEEIVrYEZnUPqnehDTBZUqH();
		LQSISRpSJytRHHGFWwKKKmhatJoE();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (TdmUbiXaTCsINWNkkbrYcEAqhlUrA != null)
		{
			TdmUbiXaTCsINWNkkbrYcEAqhlUrA.FBethkzoPOdpxwrHTNdcWabofFyD();
		}
		if (GLGflZQcsfhBjTEPDyijWFdLWVO != null)
		{
			GLGflZQcsfhBjTEPDyijWFdLWVO.FBethkzoPOdpxwrHTNdcWabofFyD();
		}
		if (KeQsTjCNvtuonfgoubXFFIbFGxHSA == null)
		{
			return;
		}
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			for (int i = 0; i < KeQsTjCNvtuonfgoubXFFIbFGxHSA.Count; i++)
			{
				if (KeQsTjCNvtuonfgoubXFFIbFGxHSA[i] != null)
				{
					KeQsTjCNvtuonfgoubXFFIbFGxHSA[i].YEIZVlKRWiUMxAQCQEvpgZtFIfcEA();
					KeQsTjCNvtuonfgoubXFFIbFGxHSA[i].OlrMQIWFFuOAeogJdvRmhVIMvNxC();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return wTMMNJTqClXPpgJlGftAbhbUsShHA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			for (int i = 0; i < itrDpOPfJYxIabtCjiCTbUNtDLZFb; i++)
			{
				if (KeQsTjCNvtuonfgoubXFFIbFGxHSA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					KeQsTjCNvtuonfgoubXFFIbFGxHSA[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		eECJlmbEmETMrJpFnAANjVnXXBZy = true;
		IIJWTHeNXmBvWbPFfpzmSUICHicbA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		eECJlmbEmETMrJpFnAANjVnXXBZy = true;
		IIJWTHeNXmBvWbPFfpzmSUICHicbA.Start();
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

	private void dGJPNCNRTXbREhezySPILbASKGYEA()
	{
		if (GLGflZQcsfhBjTEPDyijWFdLWVO.IjDAOhjnupbeicWoJQcuMwlCNKJq)
		{
			if (GLGflZQcsfhBjTEPDyijWFdLWVO.IChbtFqxyAxpsLDDmkASsVKzMoVs() && !IIJWTHeNXmBvWbPFfpzmSUICHicbA.running && !TdmUbiXaTCsINWNkkbrYcEAqhlUrA.IjDAOhjnupbeicWoJQcuMwlCNKJq)
			{
				if (GLGflZQcsfhBjTEPDyijWFdLWVO.UYndadRIHdtACtFVjQfssImkfgZcA)
				{
					eECJlmbEmETMrJpFnAANjVnXXBZy = true;
				}
				IIJWTHeNXmBvWbPFfpzmSUICHicbA.Start();
			}
		}
		else if (!IIJWTHeNXmBvWbPFfpzmSUICHicbA.running)
		{
			IIJWTHeNXmBvWbPFfpzmSUICHicbA.Start();
		}
		else if (IIJWTHeNXmBvWbPFfpzmSUICHicbA.Update())
		{
			GLGflZQcsfhBjTEPDyijWFdLWVO.icnDcGzVOnAmxAhayFIDZrxYnhvMA();
		}
	}

	private List<JxutsCzrIuJRPPGngJHyfEaKrbeb> ADefLIIAhQmwavOPlwaJOUZnqJTMA()
	{
		List<JxutsCzrIuJRPPGngJHyfEaKrbeb> list = new List<JxutsCzrIuJRPPGngJHyfEaKrbeb>();
		IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> list2 = nXndvSJbEMRztszzPFghTNwcbkycA();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				TtTEWPAmgCXtCiwlxHCRLqWtUGyz ttTEWPAmgCXtCiwlxHCRLqWtUGyz = list2[i];
				Guid tLUoFBXwbtDPnYjcetOHmmDLIghT = ttTEWPAmgCXtCiwlxHCRLqWtUGyz.tLUoFBXwbtDPnYjcetOHmmDLIghT;
				DiJVETKbnrpIufzFejttIwRifnEK diJVETKbnrpIufzFejttIwRifnEK = new DiJVETKbnrpIufzFejttIwRifnEK(jXNHNCbJNSGRLRfeYIAoCJnAeKjJ, tLUoFBXwbtDPnYjcetOHmmDLIghT);
				sigMIPBCRNutrUCPmjsbLvWhGBxw sigMIPBCRNutrUCPmjsbLvWhGBxw2 = diJVETKbnrpIufzFejttIwRifnEK.WpkGQjixRyPHkhsmQcvmwSYOeJHr;
				if (PycNQrXPAYhSoRBSGNeRAPOdgqXi == null)
				{
					goto IL_00bd;
				}
				string text = ttTEWPAmgCXtCiwlxHCRLqWtUGyz.ZRPrStnqNFGUgSDUzouORCQogvNA.ToString();
				if (!PycNQrXPAYhSoRBSGNeRAPOdgqXi.emscKeIFCBuPTEbKhcjpOwpoHmAX(sigMIPBCRNutrUCPmjsbLvWhGBxw2.MWqdaUhgUFqkCCxPtdUKbzFSyMJT, StringTools.SanitizeDeviceString(ttTEWPAmgCXtCiwlxHCRLqWtUGyz.QidLEIgLoaLuSNjoxjFLWLcoNNFF), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (AxZHxbJVUZerMtgvYFHiGyXYrJKaA.yxbiPyBCfaTRLBROrAkPLxJMyGKJ(InputSource.DirectInput, (ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.dvblTkkExKwsGeFMARkeKPqPJoLQ, (ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.qiORUvXtBOJJIANnzdWeEoyAlZsd, (AxZHxbJVUZerMtgvYFHiGyXYrJKaA.culpeKqqpLYmRhkwltWEHngnmyvF)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(sigMIPBCRNutrUCPmjsbLvWhGBxw2.MWqdaUhgUFqkCCxPtdUKbzFSyMJT)) ? MiscTools.CreateGuidHashSHA256(sigMIPBCRNutrUCPmjsbLvWhGBxw2.MWqdaUhgUFqkCCxPtdUKbzFSyMJT) : ttTEWPAmgCXtCiwlxHCRLqWtUGyz.tLUoFBXwbtDPnYjcetOHmmDLIghT);
				bool flag = false;
				lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
				{
					if (KeQsTjCNvtuonfgoubXFFIbFGxHSA != null)
					{
						for (int j = 0; j < KeQsTjCNvtuonfgoubXFFIbFGxHSA.Count; j++)
						{
							if (KeQsTjCNvtuonfgoubXFFIbFGxHSA[j] != null && KeQsTjCNvtuonfgoubXFFIbFGxHSA[j].oQQLlcDSVlTHNJsDttELdoBcmraR == guid)
							{
								diJVETKbnrpIufzFejttIwRifnEK = KeQsTjCNvtuonfgoubXFFIbFGxHSA[j].MxCcUOblCXaUTDGDrzCoqAOblHUY.tmqeSEpbejKDbGtoJqGKrgHWIdWU;
								flag = true;
								break;
							}
						}
					}
				}
				pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = new pLnbctCxXNbPwKWEvlJdVbqyluUL(new PdkBAyTFrWhMFIqWfCGVITkFuelB(diJVETKbnrpIufzFejttIwRifnEK, aVkQzzicRdZbLXhRxpNqVrnXePLi), baolmZPKeDfSIJcjWJgaMTjCiSUu);
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.XRuxPqEJOGIcLKYqdIofWJmkmaZz = ttTEWPAmgCXtCiwlxHCRLqWtUGyz;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.CjkFdbaFShEShblMDLuHhMDXslzdc = ttTEWPAmgCXtCiwlxHCRLqWtUGyz.IJSFxeePxfWfQVTYzLSUVIxKaegc;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.oQQLlcDSVlTHNJsDttELdoBcmraR = guid;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.bOwaLviFEKBESDUdEuzTJMUrJdIXb = StringTools.SanitizeDeviceString(ttTEWPAmgCXtCiwlxHCRLqWtUGyz.QidLEIgLoaLuSNjoxjFLWLcoNNFF);
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.WrlINHcqUTtIXGQVlZBcDpkTjfaj = ttTEWPAmgCXtCiwlxHCRLqWtUGyz.ZRPrStnqNFGUgSDUzouORCQogvNA;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.HpABQSeePylSvbsmaUfrIdshjQaWe = (YHBoSiEgJmbVHxbppfOYBehIaUzQ)ttTEWPAmgCXtCiwlxHCRLqWtUGyz.lHQWSBfUCkkMyFLPPlIAkmZRDgPw;
				BGkDoxBTVmWwTIrhQKnDyEVhFrIEb bGkDoxBTVmWwTIrhQKnDyEVhFrIEb = diJVETKbnrpIufzFejttIwRifnEK.ayiHuvHMyVEmPiMCbctPWGfezqmE;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.OYyqLUOIOkFGHArDoFAOarJgGzleA = sigMIPBCRNutrUCPmjsbLvWhGBxw2.qiORUvXtBOJJIANnzdWeEoyAlZsd;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.WnrlaCVIBHYDSOhmpxjbRkOUaPAG = false;
				try
				{
					pLnbctCxXNbPwKWEvlJdVbqyluUL2.MYwVqSxuBDMygOGOtdjPVwofxAzL = sigMIPBCRNutrUCPmjsbLvWhGBxw2.ZlKAvERyBpGHhOmBaAFqHXhmuGqe;
				}
				catch (Exception)
				{
					pLnbctCxXNbPwKWEvlJdVbqyluUL2.MYwVqSxuBDMygOGOtdjPVwofxAzL = 0;
				}
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.cAGbpadCFHslPrHhQaEfhyuuoGMW = bGkDoxBTVmWwTIrhQKnDyEVhFrIEb.fpMgJMdSfAnvhgmdsAtVcYshLYWKc;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.cXcNrMRVGoanCIZRAKAkaUYXayoq = bGkDoxBTVmWwTIrhQKnDyEVhFrIEb.rBMrmVqLlmcCwyghsLRupBaRlCgP;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.dWHlAGlBJFCjZJQsYMmilVVxiwMfb = bGkDoxBTVmWwTIrhQKnDyEVhFrIEb.WjLAuaXmjSjgxfsuAKElCtaGUCkD;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.cbBvzotOVpOmsMtOKbVjTEHacFJE = new DirectInputControllerExtension(ttTEWPAmgCXtCiwlxHCRLqWtUGyz, diJVETKbnrpIufzFejttIwRifnEK);
				XLGBGHTkjrNesKiDZONDYQqUHQbf(pLnbctCxXNbPwKWEvlJdVbqyluUL2, sigMIPBCRNutrUCPmjsbLvWhGBxw2, out pLnbctCxXNbPwKWEvlJdVbqyluUL2.IKYUhwJfbcPBqHhyshGNRIYbXfom);
				try
				{
					string text2;
					try
					{
						text2 = sigMIPBCRNutrUCPmjsbLvWhGBxw2.sJSaAgkeqAfpJvVDDfKKEMckqJNEb;
					}
					catch
					{
						text2 = pLnbctCxXNbPwKWEvlJdVbqyluUL2.bOwaLviFEKBESDUdEuzTJMUrJdIXb;
					}
					if (gXcWZPmcMasVpNyHVanIaMnQphDy.ahONxUsHQhJADDqcIvOvLlWAwImh((ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.dvblTkkExKwsGeFMARkeKPqPJoLQ, (ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.qiORUvXtBOJJIANnzdWeEoyAlZsd, text2) && gXcWZPmcMasVpNyHVanIaMnQphDy.meAcTtZJMqXvdWtysrkvXGcTAKtiA((ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.dvblTkkExKwsGeFMARkeKPqPJoLQ, (ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.qiORUvXtBOJJIANnzdWeEoyAlZsd, text2, out var num, out var num2, out var num3))
					{
						pLnbctCxXNbPwKWEvlJdVbqyluUL2.MxCcUOblCXaUTDGDrzCoqAOblHUY.IUzWjcxpyGTyLcnIKCqejSTutHiq(num, num2, num3, gXcWZPmcMasVpNyHVanIaMnQphDy.POVforFVXCkTxjTkPsosuiIuZEFFA((ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.dvblTkkExKwsGeFMARkeKPqPJoLQ, (ushort)sigMIPBCRNutrUCPmjsbLvWhGBxw2.qiORUvXtBOJJIANnzdWeEoyAlZsd, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<agXldjjcDkpqUxQdFPyLgCAMtRsl> list3 = diJVETKbnrpIufzFejttIwRifnEK.XKQlsWmfuDhJyeSampHQJsgQANK();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].KSbjVyCcpaougzdqlecPRwfRNJhS.UWpOyWLwHKPlYFYBrpyIxICBRkrM & SBgCiXgUYzMrBAKimxFgjcthAaBfb.Axis) != SBgCiXgUYzMrBAKimxFgjcthAaBfb.All)
							{
								diJVETKbnrpIufzFejttIwRifnEK.WpkGQjixRyPHkhsmQcvmwSYOeJHr.FbdBqJuPwzsMSjzjHUfGFgKPIUSY = new doKHYmOpzFAsttGDulJYTWiuFxQt(-65535, 65535);
							}
						}
					}
					diJVETKbnrpIufzFejttIwRifnEK.WpkGQjixRyPHkhsmQcvmwSYOeJHr.bLVVeifAXcDiycqafbbEHCENIigo = jATtzgkEXWURrVUQFnhxpTbNhTlx.Absolute;
					diJVETKbnrpIufzFejttIwRifnEK.mJpXXoiWLUiwlCeUxDtlKxPgaJOtA(FPGWRTvVcRRNbOOWivOKtWZXgiNp, KLREUhiRBDgPKcfvedSGSMrodbVEA.NonExclusive | KLREUhiRBDgPKcfvedSGSMrodbVEA.Background);
					diJVETKbnrpIufzFejttIwRifnEK.sJEXKhTDzjFmWWXehgEkbpPDPJQA();
				}
				list.Add(new JxutsCzrIuJRPPGngJHyfEaKrbeb(pLnbctCxXNbPwKWEvlJdVbqyluUL2, ttTEWPAmgCXtCiwlxHCRLqWtUGyz));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void cEvCVVzvlTHrcbqsfUhurMPVAgyv()
	{
		MISufJUhleVZZmSeNLhaKcnjmdmG(ADefLIIAhQmwavOPlwaJOUZnqJTMA());
	}

	private void MISufJUhleVZZmSeNLhaKcnjmdmG(List<JxutsCzrIuJRPPGngJHyfEaKrbeb> P_0)
	{
		List<pLnbctCxXNbPwKWEvlJdVbqyluUL> list = new List<pLnbctCxXNbPwKWEvlJdVbqyluUL>();
		owUVsrvoBNxrcseucsAiTlesdaTq = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].CBSibPeJhjseFkbmESzoveeePlwT)
			{
				continue;
			}
			try
			{
				pLnbctCxXNbPwKWEvlJdVbqyluUL hMTTPczstAhhUOzmpFOVZQFkgxjS = P_0[i].HMTTPczstAhhUOzmpFOVZQFkgxjS;
				hMTTPczstAhhUOzmpFOVZQFkgxjS.WCihnNkByaBCZAORaLyLETwurXfYB();
				if (hMTTPczstAhhUOzmpFOVZQFkgxjS.jfxuEwonXGPOchcdXZmfkibPTjGn)
				{
					owUVsrvoBNxrcseucsAiTlesdaTq++;
				}
				list.Add(hMTTPczstAhhUOzmpFOVZQFkgxjS);
			}
			catch (Exception)
			{
			}
		}
		CedgzMoixrUnVXMSRsTTxuNIntrA.oMBhGEAizqFbfKGErKQicwpCuEtgB(owUVsrvoBNxrcseucsAiTlesdaTq);
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			List<pLnbctCxXNbPwKWEvlJdVbqyluUL> keQsTjCNvtuonfgoubXFFIbFGxHSA = KeQsTjCNvtuonfgoubXFFIbFGxHSA;
			int num2 = itrDpOPfJYxIabtCjiCTbUNtDLZFb;
			int count = list.Count;
			kPJobrZKtwAOFAxdUkBaPiNncQSnA(num2, count, keQsTjCNvtuonfgoubXFFIbFGxHSA, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			khmDQzjTixOIDqYGqyUJhvoIJmqEb(keQsTjCNvtuonfgoubXFFIbFGxHSA, list, false);
			khmDQzjTixOIDqYGqyUJhvoIJmqEb(list, keQsTjCNvtuonfgoubXFFIbFGxHSA, true);
			zkYYOzAFitotbbTloNDAhIcTHriX(list, keQsTjCNvtuonfgoubXFFIbFGxHSA);
			KeQsTjCNvtuonfgoubXFFIbFGxHSA = list;
			itrDpOPfJYxIabtCjiCTbUNtDLZFb = list.Count;
		}
	}

	private void XLGBGHTkjrNesKiDZONDYQqUHQbf(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, sigMIPBCRNutrUCPmjsbLvWhGBxw P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = bvtgEnKgLvpUlVJWIuBTWZeTqPnl.QUCmAxfNxfsMLarRgjorxDVSwgsr(P_1.MWqdaUhgUFqkCCxPtdUKbzFSyMJT);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			TDrocuSAzVTRFYTGGytFvXQEcNyK tDrocuSAzVTRFYTGGytFvXQEcNyK = OPLEcXnXDXrWZrMZuMEHPFiRdVOC.KzSLBEHPXwJHpwHVgbHdiLLJdBkTA(text.ToLower(CultureInfo.InvariantCulture));
			if (tDrocuSAzVTRFYTGGytFvXQEcNyK != null)
			{
				P_0.jfxuEwonXGPOchcdXZmfkibPTjGn = tDrocuSAzVTRFYTGGytFvXQEcNyK.NTDSlxoSqbwbyPoXQJyTDkRbyTCf;
				P_0.IHpTjBufJDxDGoTmHeBoZGYbKHwk = tDrocuSAzVTRFYTGGytFvXQEcNyK.RFVGrcbQUPKDKDiNDNRqdTbUxxmWA;
				P_2 = AxZHxbJVUZerMtgvYFHiGyXYrJKaA.bbdvctbPDfmGBUBAvijpEmyhgfDtA(tDrocuSAzVTRFYTGGytFvXQEcNyK, P_0.WrlINHcqUTtIXGQVlZBcDpkTjfaj, P_0.bOwaLviFEKBESDUdEuzTJMUrJdIXb, P_0.IHpTjBufJDxDGoTmHeBoZGYbKHwk);
				tDrocuSAzVTRFYTGGytFvXQEcNyK.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void LQSISRpSJytRHHGFWwKKKmhatJoE()
	{
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			for (int i = 0; i < itrDpOPfJYxIabtCjiCTbUNtDLZFb; i++)
			{
				try
				{
					pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = KeQsTjCNvtuonfgoubXFFIbFGxHSA[i];
					if (pLnbctCxXNbPwKWEvlJdVbqyluUL2 != null && pLnbctCxXNbPwKWEvlJdVbqyluUL2.KaGDlXtneaLpOvBnKxnWzuaCCQZs() && (DWTeVmUMIVxWjJIJYcGdVrdyhSFu == null || !pLnbctCxXNbPwKWEvlJdVbqyluUL2.WnrlaCVIBHYDSOhmpxjbRkOUaPAG))
					{
						pLnbctCxXNbPwKWEvlJdVbqyluUL2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> nXndvSJbEMRztszzPFghTNwcbkycA()
	{
		try
		{
			IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> list = jXNHNCbJNSGRLRfeYIAoCJnAeKjJ.vidXVffTImmFJHJCUkFTqKzQCfkL(ruYRpisEghgnBUWQDMCzFKdYMDaM.GameControl, VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly);
			vCWOuoAesRwOxBwRTwwYQgcRiSic = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			vCWOuoAesRwOxBwRTwwYQgcRiSic = 0;
			return EmptyObjects<TtTEWPAmgCXtCiwlxHCRLqWtUGyz>.EmptyReadOnlyIListT;
		}
	}

	private void UaOQntoEOeHgwhglsDktEOAdsVufc()
	{
		jXNHNCbJNSGRLRfeYIAoCJnAeKjJ.XekHOtworGBXuHohTogyksLtLpqwA();
	}

	private void kPJobrZKtwAOFAxdUkBaPiNncQSnA(int P_0, int P_1, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_2, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(pLnbctCxXNbPwKWEvlJdVbqyluUL.JmcBDKINuXYBNIimRNCbpqlIpxcgb);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			PHAUIMvZAvldzfZddBUvoorQpcpM(P_1, P_3, P_0, P_2, NfnLYwCTDDFjMJRqVPeCzSmDESRN.vacFSerwpXvYzyroHnPQbxgMCFK.Exact);
		}
		vcScgDGzXHLzzuhFWQCttLlsejTM(P_1, P_3, NfnLYwCTDDFjMJRqVPeCzSmDESRN.vacFSerwpXvYzyroHnPQbxgMCFK.Exact);
		for (int i = 0; i < P_1; i++)
		{
			pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = P_3[i];
			if (pLnbctCxXNbPwKWEvlJdVbqyluUL2 != null && pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = MDRBVUNaTVLyeuDacnvYVAyjpLki(P_3);
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = SQVGMPGyWxjESnDUsAZIigAgeVhzA();
				MMUYVKFJtQPFTscAVXwcKfSZjcgq.bTAtRGHLvakPdVclWlWiyzPIFrIq(pLnbctCxXNbPwKWEvlJdVbqyluUL2);
			}
		}
		P_3.Sort(pLnbctCxXNbPwKWEvlJdVbqyluUL.UkidBRzdGcBQEmORLHelGsIAVwEi);
	}

	private void kcGWVJYEOyXWyNYByKQBwKIOaqDJ(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0, int P_1, int P_2)
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

	private bool RfSRWpboGMekBezSRoxifacHlCyr(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0, int P_1)
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

	private int MDRBVUNaTVLyeuDacnvYVAyjpLki(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0)
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

	private bool zYVFAWEelmPDfVzMMlENFKrXhKakA(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0, int P_1)
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

	private void PHAUIMvZAvldzfZddBUvoorQpcpM(int P_0, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_1, int P_2, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_3, NfnLYwCTDDFjMJRqVPeCzSmDESRN.vacFSerwpXvYzyroHnPQbxgMCFK P_4)
	{
		int num = ((P_4 != NfnLYwCTDDFjMJRqVPeCzSmDESRN.vacFSerwpXvYzyroHnPQbxgMCFK.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = P_1[i];
			if (pLnbctCxXNbPwKWEvlJdVbqyluUL2 == null || pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL3 = P_3[j];
				if (pLnbctCxXNbPwKWEvlJdVbqyluUL3 != null && !zYVFAWEelmPDfVzMMlENFKrXhKakA(P_1, pLnbctCxXNbPwKWEvlJdVbqyluUL3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && pLnbctCxXNbPwKWEvlJdVbqyluUL2.VVsXEVZnxycNezvVrcmidPKgaSCUA(pLnbctCxXNbPwKWEvlJdVbqyluUL3) >= num)
				{
					pLnbctCxXNbPwKWEvlJdVbqyluUL2.jZJkHBMsQfDsrbKGsjSaYBOfJtwjA(pLnbctCxXNbPwKWEvlJdVbqyluUL3);
					MMUYVKFJtQPFTscAVXwcKfSZjcgq.bTAtRGHLvakPdVclWlWiyzPIFrIq(pLnbctCxXNbPwKWEvlJdVbqyluUL2);
				}
			}
		}
	}

	private void vcScgDGzXHLzzuhFWQCttLlsejTM(int P_0, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_1, NfnLYwCTDDFjMJRqVPeCzSmDESRN.vacFSerwpXvYzyroHnPQbxgMCFK P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = P_1[i];
			if (pLnbctCxXNbPwKWEvlJdVbqyluUL2 == null || pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			NfnLYwCTDDFjMJRqVPeCzSmDESRN.BvPauDHSVlHzDOhOkgvacwrdoMfEb bvPauDHSVlHzDOhOkgvacwrdoMfEb = null;
			foreach (NfnLYwCTDDFjMJRqVPeCzSmDESRN.BvPauDHSVlHzDOhOkgvacwrdoMfEb item in MMUYVKFJtQPFTscAVXwcKfSZjcgq.VrgOGXYlchFTDjJJzlLKptrkkDyAb(pLnbctCxXNbPwKWEvlJdVbqyluUL2, P_2))
			{
				if (!zYVFAWEelmPDfVzMMlENFKrXhKakA(P_1, item.tUlDwLYPHdzxXkVueEFqSgDgrAlr) && item.ofwyytQLMRdgphLzdXDlgzsedoHf >= 0)
				{
					bvPauDHSVlHzDOhOkgvacwrdoMfEb = item;
					break;
				}
			}
			if (bvPauDHSVlHzDOhOkgvacwrdoMfEb != null)
			{
				int num = bvPauDHSVlHzDOhOkgvacwrdoMfEb.ofwyytQLMRdgphLzdXDlgzsedoHf;
				if (!RfSRWpboGMekBezSRoxifacHlCyr(P_1, num))
				{
					num = (bvPauDHSVlHzDOhOkgvacwrdoMfEb.ofwyytQLMRdgphLzdXDlgzsedoHf = MDRBVUNaTVLyeuDacnvYVAyjpLki(P_1));
				}
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = bvPauDHSVlHzDOhOkgvacwrdoMfEb.tUlDwLYPHdzxXkVueEFqSgDgrAlr;
				MMUYVKFJtQPFTscAVXwcKfSZjcgq.bTAtRGHLvakPdVclWlWiyzPIFrIq(pLnbctCxXNbPwKWEvlJdVbqyluUL2);
			}
		}
	}

	private void MuzqimEEIVrYEZnUPqnehDTBZUqH()
	{
		if (eECJlmbEmETMrJpFnAANjVnXXBZy)
		{
			UngmyknukTSMvyDnCVjuhJWsVAzn();
		}
		if (TdmUbiXaTCsINWNkkbrYcEAqhlUrA.IjDAOhjnupbeicWoJQcuMwlCNKJq && TdmUbiXaTCsINWNkkbrYcEAqhlUrA.IChbtFqxyAxpsLDDmkASsVKzMoVs())
		{
			lUTGwnCCCBqCkPkMhNhFeUjiWLcyB(TdmUbiXaTCsINWNkkbrYcEAqhlUrA.UYndadRIHdtACtFVjQfssImkfgZcA);
		}
	}

	private void UngmyknukTSMvyDnCVjuhJWsVAzn()
	{
		eECJlmbEmETMrJpFnAANjVnXXBZy = false;
		if (!TdmUbiXaTCsINWNkkbrYcEAqhlUrA.IjDAOhjnupbeicWoJQcuMwlCNKJq)
		{
			TdmUbiXaTCsINWNkkbrYcEAqhlUrA.icnDcGzVOnAmxAhayFIDZrxYnhvMA();
		}
	}

	private void lUTGwnCCCBqCkPkMhNhFeUjiWLcyB(List<JxutsCzrIuJRPPGngJHyfEaKrbeb> P_0)
	{
		if (aCrXfITKfKxCZEXfwvjgofEPdQyFA(JxutsCzrIuJRPPGngJHyfEaKrbeb.NhiBcyBVJfGXOHNXaEpkfeNwgogq(P_0)))
		{
			MISufJUhleVZZmSeNLhaKcnjmdmG(P_0);
		}
	}

	private bool aCrXfITKfKxCZEXfwvjgofEPdQyFA(IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> P_0)
	{
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !wuoMWGsLiOCPYwoQwdDOcWNpxGGgA(P_0[i].tLUoFBXwbtDPnYjcetOHmmDLIghT))
				{
					return true;
				}
			}
			int count2 = KeQsTjCNvtuonfgoubXFFIbFGxHSA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (KeQsTjCNvtuonfgoubXFFIbFGxHSA[j] != null && !nlSGAQmhwQxOfoffkdSzinLJLOlEA(P_0, KeQsTjCNvtuonfgoubXFFIbFGxHSA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool wuoMWGsLiOCPYwoQwdDOcWNpxGGgA(Guid P_0)
	{
		lock (FipcYDtXkkDHjRmbLBoSBCxSamoz)
		{
			int count = KeQsTjCNvtuonfgoubXFFIbFGxHSA.Count;
			for (int i = 0; i < count; i++)
			{
				if (KeQsTjCNvtuonfgoubXFFIbFGxHSA[i] != null && KeQsTjCNvtuonfgoubXFFIbFGxHSA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool nlSGAQmhwQxOfoffkdSzinLJLOlEA(IList<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].tLUoFBXwbtDPnYjcetOHmmDLIghT == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void khmDQzjTixOIDqYGqyUJhvoIJmqEb(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL2 = P_0[i];
			if (pLnbctCxXNbPwKWEvlJdVbqyluUL2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					pLnbctCxXNbPwKWEvlJdVbqyluUL pLnbctCxXNbPwKWEvlJdVbqyluUL3 = P_1[j];
					if (pLnbctCxXNbPwKWEvlJdVbqyluUL3 != null && pLnbctCxXNbPwKWEvlJdVbqyluUL2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == pLnbctCxXNbPwKWEvlJdVbqyluUL3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				edpHERaatibQHykUupeLErhbgdNyB(P_0[i], P_2);
			}
		}
	}

	private void edpHERaatibQHykUupeLErhbgdNyB(pLnbctCxXNbPwKWEvlJdVbqyluUL P_0, bool P_1)
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

	private bool FzYdcbzVPzafvJxIsrHTASSXRLhH()
	{
		int num = jXNHNCbJNSGRLRfeYIAoCJnAeKjJ.pLNNpvznVdGOlAGOcGGpDudxdVeHA(ruYRpisEghgnBUWQDMCzFKdYMDaM.GameControl, VruoKSWLPeRfmJpNHaCJctBwRVFp.AttachedOnly);
		if (vCWOuoAesRwOxBwRTwwYQgcRiSic != num)
		{
			vCWOuoAesRwOxBwRTwwYQgcRiSic = num;
			return true;
		}
		if (owUVsrvoBNxrcseucsAiTlesdaTq > 0 && CedgzMoixrUnVXMSRsTTxuNIntrA.oYSFqbVSTTcmpzhJLKnybkuzdVzE())
		{
			return true;
		}
		return false;
	}

	private void zkYYOzAFitotbbTloNDAhIcTHriX(List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_0, List<pLnbctCxXNbPwKWEvlJdVbqyluUL> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].OlrMQIWFFuOAeogJdvRmhVIMvNxC();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void SIUypnKvjnWKPugTrlAobgruZXQF(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<JxutsCzrIuJRPPGngJHyfEaKrbeb> lKnjAXCkiRZDIsnuMtEgwpTdNcKo()
	{
		return ADefLIIAhQmwavOPlwaJOUZnqJTMA();
	}
}
