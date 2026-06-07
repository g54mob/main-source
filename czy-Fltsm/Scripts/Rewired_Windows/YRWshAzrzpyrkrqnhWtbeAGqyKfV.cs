using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Platforms.Windows.XInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class YRWshAzrzpyrkrqnhWtbeAGqyKfV : PlatformInputManager, AHuLsFUDywwjZMRMOCnliKJcVPho
{
	private class DVtFamzbBJjBGaphoorgklqtYuktA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool YDJSybRErGAVUJTucxkpUIkJsPFt;

		private int dFyCSYkGxIRAZJiHwJRsSmFRLzXj;

		private readonly int AUhiwxhGRKolzySCSgIQAEnIOvJw;

		public Guid VrTfPgjghCsuiMdZqntEOKheenUHA;

		public string EbvxCOWTtHIoTUSBrKKlHxiBLPok;

		public string YdQsuIJApLtOhTulqPnlNAgfmPev;

		public Guid QcSJYGFZcjDmJGstptcZvhRJATlO;

		public Rewired.Libraries.SharpDX.XInput.DeviceType DXDuFGyRcIAKEqCIEtyzWpZfrAfK;

		public XInputDeviceSubType elqQQTvVEbEkKSBpiTmjBACOKKYr;

		public bool HToRUmWyhSnXSVtQnosUQfjbaZhZ;

		public bool ACUuTpHHKdzYlUeOSeRIPxadQlAh;

		public bool VGXGfjQGbAJdHbrUJkVFMDcsoEfr;

		public bool PqHvcEKgRtSoGJVdrKjrJHBcKWLp;

		private int aPdfqXdanXHLqShznmGcKryuuxshA;

		private int hAKEhCCzhvIUAUFcmIFtcoZWbccrA;

		private int AjEOMBohVcgqMAkraPsOlUuJrGqW;

		private int PeEbAmTrlFSViovxrBBEnsdmCwSC;

		private readonly float[] NMADWyUvdzsLXvijMcxCLzpZPmUG;

		private readonly bool[] FKeGaVqihaznVGprimYhkPAkAfEl;

		private HardwareJoystickMap_InputManager nhbguaEAUYgomCpaVCLOhZwInzKeA;

		public readonly VHgaDakdqWdcmvuykvNEAklCFnKv DxRLypsVfUWaBFBLlwymcmPqipfp;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> wozEmpiZPpfMYpTxyjjxNMwFEICBb;

		private Action XeAbsTHZnMvJFIzUDqMWHaBVIEgsA;

		private readonly LocalizedString WOxujgRfweDUvuswkBQcwRtXEdKH;

		private bool vNnRvYglxxfOtjMRXhlKmmGHKdWc;

		private bool nHecLTzwLZPdvjthefxfmemNTILy;

		private bool XEKsUQzJTOFCYHZAHwCMHSvYgnhDA;

		public string TbLbmGjcuFPDIHdzkRWJmwnOQqzC
		{
			get
			{
				string text = dCFYemHgodzZpJHGHrWygCYnkhI;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int aUhiwxhGRKolzySCSgIQAEnIOvJw = AUhiwxhGRKolzySCSgIQAEnIOvJw;
				return text + " " + aUhiwxhGRKolzySCSgIQAEnIOvJw;
			}
		}

		public string dCFYemHgodzZpJHGHrWygCYnkhI
		{
			get
			{
				if (!egEpsXWPIRlHVyByAcSBBnIbAUACA)
				{
					return string.Empty;
				}
				return elqQQTvVEbEkKSBpiTmjBACOKKYr.ToString();
			}
		}

		public bool egEpsXWPIRlHVyByAcSBBnIbAUACA
		{
			get
			{
				if (DxRLypsVfUWaBFBLlwymcmPqipfp == null || !PqHvcEKgRtSoGJVdrKjrJHBcKWLp)
				{
					return false;
				}
				if (vNnRvYglxxfOtjMRXhlKmmGHKdWc && !VYVfGQxFTalonNRrihcBmgjohcyg(APtUbpHRPYZjPweUXHBoBznsBWbL.Asynchronous))
				{
					cXldvBAuBmbfJlxUCYXqsiaacnVpA();
				}
				return vNnRvYglxxfOtjMRXhlKmmGHKdWc;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return dFyCSYkGxIRAZJiHwJRsSmFRLzXj;
			}
			set
			{
				dFyCSYkGxIRAZJiHwJRsSmFRLzXj = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => AUhiwxhGRKolzySCSgIQAEnIOvJw;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => YdQsuIJApLtOhTulqPnlNAgfmPev;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => AUhiwxhGRKolzySCSgIQAEnIOvJw;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (DxRLypsVfUWaBFBLlwymcmPqipfp == null)
				{
					return null;
				}
				return DxRLypsVfUWaBFBLlwymcmPqipfp.OCVHVtkYXghVLeTIivnJAMgmgCHAA;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => QcSJYGFZcjDmJGstptcZvhRJATlO;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			DxRLypsVfUWaBFBLlwymcmPqipfp.mDqUqWYJPjzTbMIguWypCMFTWodl(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			DxRLypsVfUWaBFBLlwymcmPqipfp.aGQbJlpIJCpEsePLutOgwfgfgIAj();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(WOxujgRfweDUvuswkBQcwRtXEdKH, nhbguaEAUYgomCpaVCLOhZwInzKeA.deviceLocalizationInfo.parentKeys, "controller", EbvxCOWTtHIoTUSBrKKlHxiBLPok, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(AUhiwxhGRKolzySCSgIQAEnIOvJw + 1).ToString()}";
				WOxujgRfweDUvuswkBQcwRtXEdKH.cachedValue = value;
			}
			return true;
		}

		public DVtFamzbBJjBGaphoorgklqtYuktA(int P_0, bool P_1, VHgaDakdqWdcmvuykvNEAklCFnKv P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			DxRLypsVfUWaBFBLlwymcmPqipfp = P_2;
			YDJSybRErGAVUJTucxkpUIkJsPFt = P_1;
			AUhiwxhGRKolzySCSgIQAEnIOvJw = P_0;
			wozEmpiZPpfMYpTxyjjxNMwFEICBb = P_3;
			XeAbsTHZnMvJFIzUDqMWHaBVIEgsA = P_4;
			dFyCSYkGxIRAZJiHwJRsSmFRLzXj = -1;
			aPdfqXdanXHLqShznmGcKryuuxshA = 6;
			hAKEhCCzhvIUAUFcmIFtcoZWbccrA = 15;
			AjEOMBohVcgqMAkraPsOlUuJrGqW = aPdfqXdanXHLqShznmGcKryuuxshA;
			PeEbAmTrlFSViovxrBBEnsdmCwSC = hAKEhCCzhvIUAUFcmIFtcoZWbccrA;
			NMADWyUvdzsLXvijMcxCLzpZPmUG = new float[aPdfqXdanXHLqShznmGcKryuuxshA];
			FKeGaVqihaznVGprimYhkPAkAfEl = new bool[hAKEhCCzhvIUAUFcmIFtcoZWbccrA];
			WOxujgRfweDUvuswkBQcwRtXEdKH = new LocalizedString();
			WRxfegddOUaGKyOMyJpnEGAzsoKNA();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			DxRLypsVfUWaBFBLlwymcmPqipfp.jcEhCKtIaCKGLIEHrlzgjruaXxvl();
			bool[] array = DxRLypsVfUWaBFBLlwymcmPqipfp.LLlELlNojaBwBXiNIcqzsrfrBNYp;
			SRyRDdNDtNKWjQMVqoSdOwVPSLiT(array, ref DxRLypsVfUWaBFBLlwymcmPqipfp.ZBHuqOjOpDCoDEXkOiphGGskoFoy);
			azFxCSZbimWYenwgWJfBtZUPTsxU(array, ref DxRLypsVfUWaBFBLlwymcmPqipfp.ZBHuqOjOpDCoDEXkOiphGGskoFoy);
			DxRLypsVfUWaBFBLlwymcmPqipfp.AHNszBWkrpqtVrUuXjZIvHrLLGWl();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void DRbdqkEyRFLcLMwsuSIaoVjYLYAiA(bool P_0)
		{
			if (DxRLypsVfUWaBFBLlwymcmPqipfp != null)
			{
				VGXGfjQGbAJdHbrUJkVFMDcsoEfr = P_0;
			}
		}

		public bool VYVfGQxFTalonNRrihcBmgjohcyg(APtUbpHRPYZjPweUXHBoBznsBWbL P_0)
		{
			ThedyfHJWjCCLCSTCTYhqJuoOYmc(HhrOlDFerQRQruADSjwYQTSAGmIIA(P_0));
			return vNnRvYglxxfOtjMRXhlKmmGHKdWc;
		}

		public bool HhrOlDFerQRQruADSjwYQTSAGmIIA(APtUbpHRPYZjPweUXHBoBznsBWbL P_0)
		{
			if (DxRLypsVfUWaBFBLlwymcmPqipfp == null)
			{
				return false;
			}
			return DxRLypsVfUWaBFBLlwymcmPqipfp.KGnnbpUTrTEDMQlBjmDZMgDzFwyx(P_0);
		}

		public void ThedyfHJWjCCLCSTCTYhqJuoOYmc(bool P_0)
		{
			vNnRvYglxxfOtjMRXhlKmmGHKdWc = P_0;
		}

		public void WeyCvGcVXEhCkcxejtKcigMUljxL()
		{
			if (!PqHvcEKgRtSoGJVdrKjrJHBcKWLp || pyWKHhHMFnLXFYojMxssKAzaqUUG())
			{
				WRxfegddOUaGKyOMyJpnEGAzsoKNA();
			}
			if (PqHvcEKgRtSoGJVdrKjrJHBcKWLp && vNnRvYglxxfOtjMRXhlKmmGHKdWc)
			{
				DxRLypsVfUWaBFBLlwymcmPqipfp.fLsAXZGlnxJyBGDvNrajnCTlqkLCb();
			}
		}

		public void VUCcBPjfXFgCKbImzjaBdyYlKBjqA()
		{
			dFyCSYkGxIRAZJiHwJRsSmFRLzXj = -1;
			PqHvcEKgRtSoGJVdrKjrJHBcKWLp = false;
			DxRLypsVfUWaBFBLlwymcmPqipfp.PlLUrKBmERtyKPbeKoVgNDiHHGKD();
			Array.Clear(NMADWyUvdzsLXvijMcxCLzpZPmUG, 0, NMADWyUvdzsLXvijMcxCLzpZPmUG.Length);
			Array.Clear(FKeGaVqihaznVGprimYhkPAkAfEl, 0, FKeGaVqihaznVGprimYhkPAkAfEl.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (aPdfqXdanXHLqShznmGcKryuuxshA != dataUpdater.axisCount || hAKEhCCzhvIUAUFcmIFtcoZWbccrA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < aPdfqXdanXHLqShznmGcKryuuxshA; i++)
			{
				dataUpdater.axisValues[i] = NMADWyUvdzsLXvijMcxCLzpZPmUG[i];
			}
			for (int j = 0; j < hAKEhCCzhvIUAUFcmIFtcoZWbccrA; j++)
			{
				dataUpdater.buttonValues[j] = FKeGaVqihaznVGprimYhkPAkAfEl[j];
			}
			if (nHecLTzwLZPdvjthefxfmemNTILy && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo DtmxCAceXICNoipbESQOBSVohWbgA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			JZGrlzZfULCZZBrAlLewJLZLWkow(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			aggCOHhmBbiPCEFnCjPwkTXHtXtI(bridgedController);
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
			return new ControllerDisconnectedEventArgs(dFyCSYkGxIRAZJiHwJRsSmFRLzXj);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void WRxfegddOUaGKyOMyJpnEGAzsoKNA()
		{
			if (DxRLypsVfUWaBFBLlwymcmPqipfp == null || !VYVfGQxFTalonNRrihcBmgjohcyg(APtUbpHRPYZjPweUXHBoBznsBWbL.Synchronous))
			{
				return;
			}
			try
			{
				AYBSSvDUqGZszbTmCXTSMSVcThDA();
				hdvoYbCLQdebKTTSvQwTBcsTYXti hdvoYbCLQdebKTTSvQwTBcsTYXti2 = DxRLypsVfUWaBFBLlwymcmPqipfp.nQVneCwOOYujmDNTyDoSQFAitjLk.zHzaoXeEaOPVBBrwmKjaszpkHaGxA(YVCcwitYsBdSvvMxHdOQeNajSotYA.Any);
				DXDuFGyRcIAKEqCIEtyzWpZfrAfK = hdvoYbCLQdebKTTSvQwTBcsTYXti2.GgkVMuqaMlWMZdwjaIXYLFDEjqHr;
				elqQQTvVEbEkKSBpiTmjBACOKKYr = (XInputDeviceSubType)hdvoYbCLQdebKTTSvQwTBcsTYXti2.dEFIXUOJKWDUBBorzicSIXXgqBYC;
				if (DxRLypsVfUWaBFBLlwymcmPqipfp.nQVneCwOOYujmDNTyDoSQFAitjLk.jqPfGNIUEXiZTIwQsDJavspVuRoTA(default(xMedudRCKhsTLkKCDLrxSkmiOLrV)).HLagwactvjFsAboZdHpophMHjgbI)
				{
					HToRUmWyhSnXSVtQnosUQfjbaZhZ = true;
				}
				ACUuTpHHKdzYlUeOSeRIPxadQlAh = (hdvoYbCLQdebKTTSvQwTBcsTYXti2.wCGfeKBfAmwpbUIcAmFsChHHuEIXB & XPwAaQKPlnJKPhNTADcwJIVjAWaVb.VoiceSupported) == XPwAaQKPlnJKPhNTADcwJIVjAWaVb.VoiceSupported;
				mQXibtldTtpJohgNWPszokjNZJMx();
				VrTfPgjghCsuiMdZqntEOKheenUHA = nhbguaEAUYgomCpaVCLOhZwInzKeA.hardwareMapIdentifier.guid;
				if (YDJSybRErGAVUJTucxkpUIkJsPFt)
				{
					EbvxCOWTtHIoTUSBrKKlHxiBLPok = StringTools.AddSpacesToCamelCase(elqQQTvVEbEkKSBpiTmjBACOKKYr.ToString());
				}
				else
				{
					EbvxCOWTtHIoTUSBrKKlHxiBLPok = "XInput " + elqQQTvVEbEkKSBpiTmjBACOKKYr;
				}
				YdQsuIJApLtOhTulqPnlNAgfmPev = $"{EbvxCOWTtHIoTUSBrKKlHxiBLPok} {(AUhiwxhGRKolzySCSgIQAEnIOvJw + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(elqQQTvVEbEkKSBpiTmjBACOKKYr.ToString());
				nhbguaEAUYgomCpaVCLOhZwInzKeA.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				WOxujgRfweDUvuswkBQcwRtXEdKH.Clear();
				DxRLypsVfUWaBFBLlwymcmPqipfp.fLsAXZGlnxJyBGDvNrajnCTlqkLCb();
				QcSJYGFZcjDmJGstptcZvhRJATlO = MiscTools.CreateGuidHashSHA1(string.Concat(DXDuFGyRcIAKEqCIEtyzWpZfrAfK, elqQQTvVEbEkKSBpiTmjBACOKKYr, AUhiwxhGRKolzySCSgIQAEnIOvJw));
				PqHvcEKgRtSoGJVdrKjrJHBcKWLp = true;
			}
			catch (Exception)
			{
				PqHvcEKgRtSoGJVdrKjrJHBcKWLp = false;
				vNnRvYglxxfOtjMRXhlKmmGHKdWc = false;
				QcSJYGFZcjDmJGstptcZvhRJATlO = Guid.Empty;
			}
		}

		private bool pyWKHhHMFnLXFYojMxssKAzaqUUG()
		{
			try
			{
				if (elqQQTvVEbEkKSBpiTmjBACOKKYr != (XInputDeviceSubType)DxRLypsVfUWaBFBLlwymcmPqipfp.nQVneCwOOYujmDNTyDoSQFAitjLk.zHzaoXeEaOPVBBrwmKjaszpkHaGxA(YVCcwitYsBdSvvMxHdOQeNajSotYA.Any).dEFIXUOJKWDUBBorzicSIXXgqBYC)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void AYBSSvDUqGZszbTmCXTSMSVcThDA()
		{
			ACUuTpHHKdzYlUeOSeRIPxadQlAh = false;
			HToRUmWyhSnXSVtQnosUQfjbaZhZ = false;
			VGXGfjQGbAJdHbrUJkVFMDcsoEfr = false;
			PqHvcEKgRtSoGJVdrKjrJHBcKWLp = false;
		}

		private void cXldvBAuBmbfJlxUCYXqsiaacnVpA()
		{
			if (XeAbsTHZnMvJFIzUDqMWHaBVIEgsA != null)
			{
				XeAbsTHZnMvJFIzUDqMWHaBVIEgsA();
			}
			DxRLypsVfUWaBFBLlwymcmPqipfp.PlLUrKBmERtyKPbeKoVgNDiHHGKD();
		}

		private void SRyRDdNDtNKWjQMVqoSdOwVPSLiT(bool[] P_0, ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)nhbguaEAUYgomCpaVCLOhZwInzKeA.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= aPdfqXdanXHLqShznmGcKryuuxshA)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				NMADWyUvdzsLXvijMcxCLzpZPmUG[i] = iVvwMnpQtyirltIcCfytzxeIeCmL(axes_orig[i], P_0, ref P_1);
				if (!nHecLTzwLZPdvjthefxfmemNTILy && NMADWyUvdzsLXvijMcxCLzpZPmUG[i] != 0f)
				{
					nHecLTzwLZPdvjthefxfmemNTILy = true;
				}
			}
		}

		private void azFxCSZbimWYenwgWJfBtZUPTsxU(bool[] P_0, ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)nhbguaEAUYgomCpaVCLOhZwInzKeA.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= hAKEhCCzhvIUAUFcmIFtcoZWbccrA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				FKeGaVqihaznVGprimYhkPAkAfEl[i] = CFtzpnTeYbepJexOowKSqXfaUspBA(buttons_orig[i], P_0, ref P_1);
				if (!nHecLTzwLZPdvjthefxfmemNTILy && FKeGaVqihaznVGprimYhkPAkAfEl[i])
				{
					nHecLTzwLZPdvjthefxfmemNTILy = true;
				}
			}
		}

		private float iVvwMnpQtyirltIcCfytzxeIeCmL(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return ScdCvXNHSyHwlmCiIAMyeoafgptNA(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!moPeXBeRiaOhFqcOzmLtacTVlTDLA(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float ScdCvXNHSyHwlmCiIAMyeoafgptNA(XInputAxis P_0, ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => VHgaDakdqWdcmvuykvNEAklCFnKv.KtboZiSGWmWFatEqQJzXjQiEcDNx(P_1.zHctRzKUAJSHjmCKSfQqHGGZFWpD), 
				XInputAxis.LeftThumbY => VHgaDakdqWdcmvuykvNEAklCFnKv.KtboZiSGWmWFatEqQJzXjQiEcDNx(P_1.MxvPazMbMXjgmGXjotffWgwiyBOjA), 
				XInputAxis.RightThumbX => VHgaDakdqWdcmvuykvNEAklCFnKv.KtboZiSGWmWFatEqQJzXjQiEcDNx(P_1.nUpuOXSbbspUEXGEArIvAkwAiavg), 
				XInputAxis.RightThumbY => VHgaDakdqWdcmvuykvNEAklCFnKv.KtboZiSGWmWFatEqQJzXjQiEcDNx(P_1.BYqvgjzzVqFgOJJcaDFlYgxzLkgP), 
				XInputAxis.LeftTrigger => VHgaDakdqWdcmvuykvNEAklCFnKv.lQlrUtRnAxpqpQTCEIeXWBhCKfPi(P_1.tWCIDhQXwYXARugPvHdheaXsmCQF), 
				XInputAxis.RightTrigger => VHgaDakdqWdcmvuykvNEAklCFnKv.lQlrUtRnAxpqpQTCEIeXWBhCKfPi(P_1.slrIDkOheRprZCromqiFNmCHOcZJ), 
				_ => 0f, 
			};
		}

		private bool CFtzpnTeYbepJexOowKSqXfaUspBA(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return moPeXBeRiaOhFqcOzmLtacTVlTDLA(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = ScdCvXNHSyHwlmCiIAMyeoafgptNA(P_0.sourceAxis, ref P_2);
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
			return false;
		}

		private bool moPeXBeRiaOhFqcOzmLtacTVlTDLA(XInputButton P_0, bool[] P_1)
		{
			return P_0 switch
			{
				XInputButton.DPadUp => P_1[0], 
				XInputButton.DPadDown => P_1[1], 
				XInputButton.DPadLeft => P_1[2], 
				XInputButton.DPadRight => P_1[3], 
				XInputButton.Start => P_1[4], 
				XInputButton.Back => P_1[5], 
				XInputButton.LeftThumb => P_1[6], 
				XInputButton.RightThumb => P_1[7], 
				XInputButton.LeftShoulder => P_1[8], 
				XInputButton.RightShoulder => P_1[9], 
				XInputButton.Guide => P_1[10], 
				XInputButton.A => P_1[11], 
				XInputButton.B => P_1[12], 
				XInputButton.X => P_1[13], 
				XInputButton.Y => P_1[14], 
				_ => false, 
			};
		}

		private void mQXibtldTtpJohgNWPszokjNZJMx()
		{
			nhbguaEAUYgomCpaVCLOhZwInzKeA = wozEmpiZPpfMYpTxyjjxNMwFEICBb(DtmxCAceXICNoipbESQOBSVohWbgA());
			if (nhbguaEAUYgomCpaVCLOhZwInzKeA == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			aPdfqXdanXHLqShznmGcKryuuxshA = nhbguaEAUYgomCpaVCLOhZwInzKeA.axisCount;
			hAKEhCCzhvIUAUFcmIFtcoZWbccrA = nhbguaEAUYgomCpaVCLOhZwInzKeA.buttonCount;
		}

		private bool KRwqXEXduCDmRdveMmkihKCrlauaA(ref xMedudRCKhsTLkKCDLrxSkmiOLrV P_0)
		{
			if (P_0.tPyfwJCpeDakOzcxgxwdabVFxQyj > 0 || P_0.mUMyKLCcrHjAGFaKUzFyVgpnTbnj > 0)
			{
				return true;
			}
			return false;
		}

		private void ibSmaizxcHPPiBVkzEzSdBSWUuHG(ref xMedudRCKhsTLkKCDLrxSkmiOLrV P_0)
		{
			P_0.tPyfwJCpeDakOzcxgxwdabVFxQyj = 0;
			P_0.mUMyKLCcrHjAGFaKUzFyVgpnTbnj = 0;
		}

		private void TtCEekcCfnBsTJrIRzCePXUApKlt(ref xMedudRCKhsTLkKCDLrxSkmiOLrV P_0, ref xMedudRCKhsTLkKCDLrxSkmiOLrV P_1)
		{
			P_1.tPyfwJCpeDakOzcxgxwdabVFxQyj = P_0.tPyfwJCpeDakOzcxgxwdabVFxQyj;
			P_1.mUMyKLCcrHjAGFaKUzFyVgpnTbnj = P_0.mUMyKLCcrHjAGFaKUzFyVgpnTbnj;
		}

		private string lFKOqexhfzbOjEdeEfVzQQYZcuTEb()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{DXDuFGyRcIAKEqCIEtyzWpZfrAfK.ToString()}{elqQQTvVEbEkKSBpiTmjBACOKKYr.ToString()}");
		}

		private void JZGrlzZfULCZZBrAlLewJLZLWkow(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = lFKOqexhfzbOjEdeEfVzQQYZcuTEb();
			P_0.hardwareAxisCount = AjEOMBohVcgqMAkraPsOlUuJrGqW;
			P_0.hardwareButtonCount = PeEbAmTrlFSViovxrBBEnsdmCwSC;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = dCFYemHgodzZpJHGHrWygCYnkhI;
			P_0.hw_supportsVoice = ACUuTpHHKdzYlUeOSeRIPxadQlAh;
			P_0.hw_supportsVibration = HToRUmWyhSnXSVtQnosUQfjbaZhZ;
			P_0.hw_localVibrationMotorCount = (HToRUmWyhSnXSVtQnosUQfjbaZhZ ? 2 : 0);
			P_0.hw_xInputSubType = elqQQTvVEbEkKSBpiTmjBACOKKYr;
		}

		private void aggCOHhmBbiPCEFnCjPwkTXHtXtI(BridgedController P_0)
		{
			JZGrlzZfULCZZBrAlLewJLZLWkow(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = nhbguaEAUYgomCpaVCLOhZwInzKeA.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + TbLbmGjcuFPDIHdzkRWJmwnOQqzC;
			P_0.productName = "XInput " + dCFYemHgodzZpJHGHrWygCYnkhI;
			P_0.isXInputDevice = true;
			P_0.axisCount = aPdfqXdanXHLqShznmGcKryuuxshA;
			P_0.buttonCount = hAKEhCCzhvIUAUFcmIFtcoZWbccrA;
			P_0.controllerTypeGuid = VrTfPgjghCsuiMdZqntEOKheenUHA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			YPlYQQnsuPivwDRwffXSUaluKLZd(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void NDQBKdFBEADrftrqOaXRjReKrBxkA()
		{
			try
			{
				YPlYQQnsuPivwDRwffXSUaluKLZd(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void YPlYQQnsuPivwDRwffXSUaluKLZd(bool P_0)
		{
			if (XEKsUQzJTOFCYHZAHwCMHSvYgnhDA)
			{
				return;
			}
			if (P_0)
			{
				if (egEpsXWPIRlHVyByAcSBBnIbAUACA)
				{
					DxRLypsVfUWaBFBLlwymcmPqipfp.xADfSMKWSqMtfgldInzmEGrbfIiCB();
				}
				if (DxRLypsVfUWaBFBLlwymcmPqipfp != null)
				{
					DxRLypsVfUWaBFBLlwymcmPqipfp.Dispose();
				}
			}
			XEKsUQzJTOFCYHZAHwCMHSvYgnhDA = true;
		}
	}

	private class HyRyDFpmsEFSSSjxUWpvhzojsne
	{
		private class bdRsMQyumRCbEQEGlOISibOegLHaA
		{
			public bool lssEjWgdgbKRrmpzoVBAjlNXqvhtA;

			public int QGzHWIiLttMGoKnMmFEoXkPRGoVx;

			public XInputDeviceSubType BujoVzPQDRvCSvkpgTneTZMnrUcA;

			public void yJVAmfihRUIUYWWcgNWPUsxdsKQT(DVtFamzbBJjBGaphoorgklqtYuktA P_0, bool P_1)
			{
				lssEjWgdgbKRrmpzoVBAjlNXqvhtA = P_1;
				QGzHWIiLttMGoKnMmFEoXkPRGoVx = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				BujoVzPQDRvCSvkpgTneTZMnrUcA = P_0.elqQQTvVEbEkKSBpiTmjBACOKKYr;
			}

			public bdRsMQyumRCbEQEGlOISibOegLHaA(int P_0, XInputDeviceSubType P_1)
			{
				QGzHWIiLttMGoKnMmFEoXkPRGoVx = P_0;
				BujoVzPQDRvCSvkpgTneTZMnrUcA = P_1;
			}
		}

		private List<bdRsMQyumRCbEQEGlOISibOegLHaA> XGQlgQwdEahurQPwpwUdXSsAwpUy;

		public HyRyDFpmsEFSSSjxUWpvhzojsne()
		{
			XGQlgQwdEahurQPwpwUdXSsAwpUy = new List<bdRsMQyumRCbEQEGlOISibOegLHaA>();
		}

		public void ynlXUrUMYCXYxpsAqaBapRGerrdr(DVtFamzbBJjBGaphoorgklqtYuktA P_0, bool P_1)
		{
			if (OCsffSCaeZzIXFLIJbaFgVnGqWbxb(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.elqQQTvVEbEkKSBpiTmjBACOKKYr, true) < 0)
			{
				bdRsMQyumRCbEQEGlOISibOegLHaA bdRsMQyumRCbEQEGlOISibOegLHaA2 = new bdRsMQyumRCbEQEGlOISibOegLHaA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.elqQQTvVEbEkKSBpiTmjBACOKKYr);
				bdRsMQyumRCbEQEGlOISibOegLHaA2.lssEjWgdgbKRrmpzoVBAjlNXqvhtA = P_1;
				XGQlgQwdEahurQPwpwUdXSsAwpUy.Add(bdRsMQyumRCbEQEGlOISibOegLHaA2);
			}
		}

		public void bhEmRVIbtzaxVGsrHbpCfXbBouMPb(int P_0, DVtFamzbBJjBGaphoorgklqtYuktA P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < XGQlgQwdEahurQPwpwUdXSsAwpUy.Count)
			{
				XGQlgQwdEahurQPwpwUdXSsAwpUy[P_0].yJVAmfihRUIUYWWcgNWPUsxdsKQT(P_1, P_2);
			}
		}

		public int VcDvAJnRIdSOpWKkOdbSOaezeIofA(XInputDeviceSubType P_0, bool P_1)
		{
			int count = XGQlgQwdEahurQPwpwUdXSsAwpUy.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !XGQlgQwdEahurQPwpwUdXSsAwpUy[i].lssEjWgdgbKRrmpzoVBAjlNXqvhtA) && XGQlgQwdEahurQPwpwUdXSsAwpUy[i].BujoVzPQDRvCSvkpgTneTZMnrUcA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int OCsffSCaeZzIXFLIJbaFgVnGqWbxb(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = XGQlgQwdEahurQPwpwUdXSsAwpUy.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !XGQlgQwdEahurQPwpwUdXSsAwpUy[i].lssEjWgdgbKRrmpzoVBAjlNXqvhtA) && XGQlgQwdEahurQPwpwUdXSsAwpUy[i].QGzHWIiLttMGoKnMmFEoXkPRGoVx == P_0 && XGQlgQwdEahurQPwpwUdXSsAwpUy[i].BujoVzPQDRvCSvkpgTneTZMnrUcA == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int JQibDqwCsrTcbefCHQMqBrsXtmMv(int P_0)
		{
			if (P_0 < 0 || P_0 >= XGQlgQwdEahurQPwpwUdXSsAwpUy.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return XGQlgQwdEahurQPwpwUdXSsAwpUy[P_0].QGzHWIiLttMGoKnMmFEoXkPRGoVx;
		}

		public void EGRbFuDncaLTwguSfOOzjEKCaVVC(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < XGQlgQwdEahurQPwpwUdXSsAwpUy.Count)
			{
				XGQlgQwdEahurQPwpwUdXSsAwpUy[P_0].lssEjWgdgbKRrmpzoVBAjlNXqvhtA = P_1;
			}
		}
	}

	private class hAmgXwAUVevHiQgIksPKKELmeJbAA
	{
		public bool LtOFOPcvygZMhItagguwHRDdzTDHA;

		private double FyCgnvEpzWYhgoWPQQIgtbcQgltwA;

		public float wQHGStLOExGejYOXHFwwdAcptXRJ;

		public hAmgXwAUVevHiQgIksPKKELmeJbAA()
		{
		}

		public hAmgXwAUVevHiQgIksPKKELmeJbAA(float P_0)
		{
			wQHGStLOExGejYOXHFwwdAcptXRJ = P_0;
		}

		public void iyGxqfzoHaFlmDzCAIDBQlvEwBso()
		{
			LtOFOPcvygZMhItagguwHRDdzTDHA = true;
			FyCgnvEpzWYhgoWPQQIgtbcQgltwA = (double)wQHGStLOExGejYOXHFwwdAcptXRJ + ReInput.unscaledTime;
		}

		public void jsThRnJlhyJoqQkYKaSJdPNmzgmPA(float P_0)
		{
			LtOFOPcvygZMhItagguwHRDdzTDHA = true;
			wQHGStLOExGejYOXHFwwdAcptXRJ = P_0;
			FyCgnvEpzWYhgoWPQQIgtbcQgltwA = (double)wQHGStLOExGejYOXHFwwdAcptXRJ + ReInput.unscaledTime;
		}

		public bool PKaFfEBnwJOyWldVGufKCsUoBEAY()
		{
			if (!LtOFOPcvygZMhItagguwHRDdzTDHA)
			{
				return false;
			}
			if (ReInput.unscaledTime >= FyCgnvEpzWYhgoWPQQIgtbcQgltwA)
			{
				LtOFOPcvygZMhItagguwHRDdzTDHA = false;
				return true;
			}
			return false;
		}

		public void QJVKIQLYlAOfEjbADZGsoJgZxDoI()
		{
			LtOFOPcvygZMhItagguwHRDdzTDHA = false;
			FyCgnvEpzWYhgoWPQQIgtbcQgltwA = 0.0;
		}

		public void yjEcRCcXwPivTHkKSyiLVOkHYNdU(float P_0)
		{
			wQHGStLOExGejYOXHFwwdAcptXRJ = P_0;
		}

		public hAmgXwAUVevHiQgIksPKKELmeJbAA dYnsqtSopzfwfyxVoOkFZYJkyFfe()
		{
			return (hAmgXwAUVevHiQgIksPKKELmeJbAA)MemberwiseClone();
		}
	}

	public class VHgaDakdqWdcmvuykvNEAklCFnKv : IDisposable
	{
		public readonly KhdcWngGVIvUISqmYoBXgfhjgnNVA nQVneCwOOYujmDNTyDoSQFAitjLk;

		private readonly Controller.Extension rDvFDvGnkkNBwkIHgNpLKOlwVEpT;

		public CInkDpXCvkZTJYQlWRttzfPDXrvJ ZBHuqOjOpDCoDEXkOiphGGskoFoy;

		private bool tJINplkZrLpBZeElwToSYIpAjFTEA;

		private readonly ButtonLoopSet YsmaNYNXfFKKbacOQiKuFAdGJaWz;

		private CInkDpXCvkZTJYQlWRttzfPDXrvJ OFQVVNdfgVRUnhFSndXcVsdhiyIiA;

		private bool CcJUzFhGkGIjFIBRGKELaoAccKCqb;

		private DualThreadLowLevelInputEventQueue zTzCBreXOLLnPilgEjcvmJBtSKZnA;

		private readonly object FSeuSnUzIlrpmoQnTMvunqBGfumg;

		private RingBuffer<xMedudRCKhsTLkKCDLrxSkmiOLrV> OxtgVlmdhqIqKoKgEyTMQApvhotFA = new RingBuffer<xMedudRCKhsTLkKCDLrxSkmiOLrV>(5);

		private RingBuffer<xMedudRCKhsTLkKCDLrxSkmiOLrV> aSmWPqObLEvveFTgutTsHIvYwqRr = new RingBuffer<xMedudRCKhsTLkKCDLrxSkmiOLrV>(5);

		private readonly object wdhzyftAnxXOtMdyJDLHJzHouekAA = new object();

		private readonly object VgSUdSHsuAXJxZOGpdQhqSdaaSMJ = new object();

		private xMedudRCKhsTLkKCDLrxSkmiOLrV pBmMJRqQdpczsiZPyhjYfpmpaesFA;

		private double bGeCidBDuXOOxKlBvDXOOPsfVFLoA;

		private bool YPJtvJSrsxpFLQRmIznFPvmdFswL;

		public Controller.Extension OCVHVtkYXghVLeTIivnJAMgmgCHAA => rDvFDvGnkkNBwkIHgNpLKOlwVEpT;

		public bool[] LLlELlNojaBwBXiNIcqzsrfrBNYp => YsmaNYNXfFKKbacOQiKuFAdGJaWz.Current.effectiveValue;

		public VHgaDakdqWdcmvuykvNEAklCFnKv(int P_0, UpdateLoopSetting P_1)
		{
			nQVneCwOOYujmDNTyDoSQFAitjLk = new KhdcWngGVIvUISqmYoBXgfhjgnNVA((mKlxvdfoXirsguDCxmfVcCSnngVl)P_0);
			YsmaNYNXfFKKbacOQiKuFAdGJaWz = new ButtonLoopSet(P_1, 15);
			FSeuSnUzIlrpmoQnTMvunqBGfumg = new object();
			zTzCBreXOLLnPilgEjcvmJBtSKZnA = new DualThreadLowLevelInputEventQueue((int)((float)MROXnswaFDYJOaQMZFuqDWLdEBUH.QLOtUfyZkbAhGxDQNPvrDkbJpnUT * 0.25f), 15, 6, 0);
			rDvFDvGnkkNBwkIHgNpLKOlwVEpT = new XInputControllerExtension(this);
		}

		public void jcEhCKtIaCKGLIEHrlzgjruaXxvl()
		{
			YsmaNYNXfFKKbacOQiKuFAdGJaWz.SetUpdateLoop(ReInput.currentUpdateLoop);
			CMzOWbjecfuLQdIudoaOHiOUVqnc(ref ZBHuqOjOpDCoDEXkOiphGGskoFoy);
		}

		public void AHNszBWkrpqtVrUuXjZIvHrLLGWl()
		{
			lpQfRqOfUBJEANFAakJwlfXAXOqk();
			YsmaNYNXfFKKbacOQiKuFAdGJaWz.Current.ClearWasTrueThisFrame();
		}

		public void fLsAXZGlnxJyBGDvNrajnCTlqkLCb()
		{
			lHTXgNdYXhkXtcNiIYqAdCUJikwg();
			tJINplkZrLpBZeElwToSYIpAjFTEA = true;
			CcJUzFhGkGIjFIBRGKELaoAccKCqb = nQVneCwOOYujmDNTyDoSQFAitjLk.kbLhwnrHQvQVDBUMFjBJzrqLnvaB;
		}

		public void PlLUrKBmERtyKPbeKoVgNDiHHGKD()
		{
			tJINplkZrLpBZeElwToSYIpAjFTEA = false;
			CcJUzFhGkGIjFIBRGKELaoAccKCqb = false;
			lHTXgNdYXhkXtcNiIYqAdCUJikwg();
		}

		public bool KGnnbpUTrTEDMQlBjmDZMgDzFwyx(APtUbpHRPYZjPweUXHBoBznsBWbL P_0)
		{
			return P_0 switch
			{
				APtUbpHRPYZjPweUXHBoBznsBWbL.Synchronous => CcJUzFhGkGIjFIBRGKELaoAccKCqb = nQVneCwOOYujmDNTyDoSQFAitjLk.kbLhwnrHQvQVDBUMFjBJzrqLnvaB, 
				APtUbpHRPYZjPweUXHBoBznsBWbL.Asynchronous => CcJUzFhGkGIjFIBRGKELaoAccKCqb, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void mDqUqWYJPjzTbMIguWypCMFTWodl(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				pBmMJRqQdpczsiZPyhjYfpmpaesFA.tPyfwJCpeDakOzcxgxwdabVFxQyj = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				pBmMJRqQdpczsiZPyhjYfpmpaesFA.mUMyKLCcrHjAGFaKUzFyVgpnTbnj = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			BQBpfxqEHtIZELPCgJfvVTOexRRS();
		}

		public void aGQbJlpIJCpEsePLutOgwfgfgIAj()
		{
			pBmMJRqQdpczsiZPyhjYfpmpaesFA.tPyfwJCpeDakOzcxgxwdabVFxQyj = 0;
			pBmMJRqQdpczsiZPyhjYfpmpaesFA.mUMyKLCcrHjAGFaKUzFyVgpnTbnj = 0;
			BQBpfxqEHtIZELPCgJfvVTOexRRS();
		}

		public void xADfSMKWSqMtfgldInzmEGrbfIiCB()
		{
			pBmMJRqQdpczsiZPyhjYfpmpaesFA.tPyfwJCpeDakOzcxgxwdabVFxQyj = 0;
			pBmMJRqQdpczsiZPyhjYfpmpaesFA.mUMyKLCcrHjAGFaKUzFyVgpnTbnj = 0;
			lock (VgSUdSHsuAXJxZOGpdQhqSdaaSMJ)
			{
				lock (wdhzyftAnxXOtMdyJDLHJzHouekAA)
				{
					OxtgVlmdhqIqKoKgEyTMQApvhotFA.Clear();
					aSmWPqObLEvveFTgutTsHIvYwqRr.Clear();
					KdcFSJjHDIrnqKolssBCracbRZNeA(nQVneCwOOYujmDNTyDoSQFAitjLk, pBmMJRqQdpczsiZPyhjYfpmpaesFA, ref bGeCidBDuXOOxKlBvDXOOPsfVFLoA);
				}
			}
		}

		public void mqCxNHVmGKStcfDbxuEYcqNYTyLE()
		{
			if (!tJINplkZrLpBZeElwToSYIpAjFTEA || !CcJUzFhGkGIjFIBRGKELaoAccKCqb)
			{
				return;
			}
			uGSAOvAjRCveMsCgFFKXrVlihUjy uGSAOvAjRCveMsCgFFKXrVlihUjy2;
			double realTime;
			try
			{
				if (!nQVneCwOOYujmDNTyDoSQFAitjLk.ixsTWuvsiitJWJLPJRcGISTCyPFK(out uGSAOvAjRCveMsCgFFKXrVlihUjy2))
				{
					CcJUzFhGkGIjFIBRGKELaoAccKCqb = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				CcJUzFhGkGIjFIBRGKELaoAccKCqb = false;
				return;
			}
			lock (FSeuSnUzIlrpmoQnTMvunqBGfumg)
			{
				if (!AaEgNSzhfveiYjHNdUNrlFKEIRKq(uGSAOvAjRCveMsCgFFKXrVlihUjy2.KwueSScksBgNgbuWvhIgLbZbuTdy, OFQVVNdfgVRUnhFSndXcVsdhiyIiA))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = zTzCBreXOLLnPilgEjcvmJBtSKZnA.T_CreateEvent())
					{
						mDZIrYgmHMKCNlOtkRkjDjrgMqocb(ref uGSAOvAjRCveMsCgFFKXrVlihUjy2.KwueSScksBgNgbuWvhIgLbZbuTdy, realTime, newEventWrapper.Event);
					}
					OFQVVNdfgVRUnhFSndXcVsdhiyIiA = uGSAOvAjRCveMsCgFFKXrVlihUjy2.KwueSScksBgNgbuWvhIgLbZbuTdy;
				}
			}
		}

		public void kuWPGQKsHtvtYapfSTZvnKoYKWPR()
		{
			if (!tJINplkZrLpBZeElwToSYIpAjFTEA || !CcJUzFhGkGIjFIBRGKELaoAccKCqb || ReInput.realTime < bGeCidBDuXOOxKlBvDXOOPsfVFLoA + 0.009999999776482582)
			{
				return;
			}
			lock (VgSUdSHsuAXJxZOGpdQhqSdaaSMJ)
			{
				lock (wdhzyftAnxXOtMdyJDLHJzHouekAA)
				{
					MiscTools.Swap(ref OxtgVlmdhqIqKoKgEyTMQApvhotFA, ref aSmWPqObLEvveFTgutTsHIvYwqRr);
				}
				uQKxkkmFHHUJcRFAqbcDpQRmokRx(aSmWPqObLEvveFTgutTsHIvYwqRr, nQVneCwOOYujmDNTyDoSQFAitjLk, ref bGeCidBDuXOOxKlBvDXOOPsfVFLoA);
			}
		}

		private void lpQfRqOfUBJEANFAakJwlfXAXOqk()
		{
			ohVUkdBfIXtetLJZGlWvsyryANHy();
		}

		private void ohVUkdBfIXtetLJZGlWvsyryANHy()
		{
			if (!(ReInput.realTime < bGeCidBDuXOOxKlBvDXOOPsfVFLoA + 1.5) && (!Mathf.Approximately((int)pBmMJRqQdpczsiZPyhjYfpmpaesFA.tPyfwJCpeDakOzcxgxwdabVFxQyj, 0f) || !Mathf.Approximately((int)pBmMJRqQdpczsiZPyhjYfpmpaesFA.mUMyKLCcrHjAGFaKUzFyVgpnTbnj, 0f)))
			{
				BQBpfxqEHtIZELPCgJfvVTOexRRS();
			}
		}

		private void BQBpfxqEHtIZELPCgJfvVTOexRRS()
		{
			lock (wdhzyftAnxXOtMdyJDLHJzHouekAA)
			{
				OxtgVlmdhqIqKoKgEyTMQApvhotFA.Enqueue(pBmMJRqQdpczsiZPyhjYfpmpaesFA);
			}
		}

		private static void uQKxkkmFHHUJcRFAqbcDpQRmokRx(RingBuffer<xMedudRCKhsTLkKCDLrxSkmiOLrV> P_0, KhdcWngGVIvUISqmYoBXgfhjgnNVA P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				KdcFSJjHDIrnqKolssBCracbRZNeA(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void KdcFSJjHDIrnqKolssBCracbRZNeA(KhdcWngGVIvUISqmYoBXgfhjgnNVA P_0, xMedudRCKhsTLkKCDLrxSkmiOLrV P_1, ref double P_2)
		{
			try
			{
				P_0.jqPfGNIUEXiZTIwQsDJavspVuRoTA(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void CMzOWbjecfuLQdIudoaOHiOUVqnc(ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_0)
		{
			while (zTzCBreXOLLnPilgEjcvmJBtSKZnA.ProcessNewEvents())
			{
				oRoKtWDgGdECjqEJAOmNUtQSDJwx(ref P_0, ref zTzCBreXOLLnPilgEjcvmJBtSKZnA.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					YsmaNYNXfFKKbacOQiKuFAdGJaWz.SetValue(i, swWcvNSSaJRsffQcEfWyeEJFfHKIb((int)P_0.PtihhOubZXUbrolaGHhehLDFbPgT, i), zTzCBreXOLLnPilgEjcvmJBtSKZnA.currentEvent.GetTimestamp());
				}
			}
		}

		private void mDZIrYgmHMKCNlOtkRkjDjrgMqocb(ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int ptihhOubZXUbrolaGHhehLDFbPgT = (int)P_0.PtihhOubZXUbrolaGHhehLDFbPgT;
			P_2.SetButtonsBitMask((ptihhOubZXUbrolaGHhehLDFbPgT & 0x7FF) | ((ptihhOubZXUbrolaGHhehLDFbPgT & (ptihhOubZXUbrolaGHhehLDFbPgT & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, KtboZiSGWmWFatEqQJzXjQiEcDNx(P_0.zHctRzKUAJSHjmCKSfQqHGGZFWpD));
			P_2.SetAxisValue(1, KtboZiSGWmWFatEqQJzXjQiEcDNx(P_0.MxvPazMbMXjgmGXjotffWgwiyBOjA));
			P_2.SetAxisValue(2, KtboZiSGWmWFatEqQJzXjQiEcDNx(P_0.nUpuOXSbbspUEXGEArIvAkwAiavg));
			P_2.SetAxisValue(3, KtboZiSGWmWFatEqQJzXjQiEcDNx(P_0.BYqvgjzzVqFgOJJcaDFlYgxzLkgP));
			P_2.SetAxisValue(4, lQlrUtRnAxpqpQTCEIeXWBhCKfPi(P_0.tWCIDhQXwYXARugPvHdheaXsmCQF));
			P_2.SetAxisValue(5, lQlrUtRnAxpqpQTCEIeXWBhCKfPi(P_0.slrIDkOheRprZCromqiFNmCHOcZJ));
		}

		private void oRoKtWDgGdECjqEJAOmNUtQSDJwx(ref CInkDpXCvkZTJYQlWRttzfPDXrvJ P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.PtihhOubZXUbrolaGHhehLDFbPgT = (XvtcsGbhlsBylyoLsxuNJGsDdckY)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.zHctRzKUAJSHjmCKSfQqHGGZFWpD = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.MxvPazMbMXjgmGXjotffWgwiyBOjA = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.nUpuOXSbbspUEXGEArIvAkwAiavg = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.BYqvgjzzVqFgOJJcaDFlYgxzLkgP = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.tWCIDhQXwYXARugPvHdheaXsmCQF = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.slrIDkOheRprZCromqiFNmCHOcZJ = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool swWcvNSSaJRsffQcEfWyeEJFfHKIb(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void lHTXgNdYXhkXtcNiIYqAdCUJikwg()
		{
			lock (FSeuSnUzIlrpmoQnTMvunqBGfumg)
			{
				ZBHuqOjOpDCoDEXkOiphGGskoFoy = default(CInkDpXCvkZTJYQlWRttzfPDXrvJ);
				OFQVVNdfgVRUnhFSndXcVsdhiyIiA = default(CInkDpXCvkZTJYQlWRttzfPDXrvJ);
				YsmaNYNXfFKKbacOQiKuFAdGJaWz.Clear();
				zTzCBreXOLLnPilgEjcvmJBtSKZnA.Clear();
			}
		}

		public void Dispose()
		{
			IPJfZwZEltKyMBbTBJDKwKHzbICDA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void fvFCBaETyoCXOWriiKMnqKBBGcLdA()
		{
			try
			{
				IPJfZwZEltKyMBbTBJDKwKHzbICDA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void IPJfZwZEltKyMBbTBJDKwKHzbICDA(bool P_0)
		{
			if (!YPJtvJSrsxpFLQRmIznFPvmdFswL)
			{
				if (P_0)
				{
					zTzCBreXOLLnPilgEjcvmJBtSKZnA.Dispose();
				}
				YPJtvJSrsxpFLQRmIznFPvmdFswL = true;
			}
		}

		public static float KtboZiSGWmWFatEqQJzXjQiEcDNx(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float lQlrUtRnAxpqpQTCEIeXWBhCKfPi(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool AaEgNSzhfveiYjHNdUNrlFKEIRKq(CInkDpXCvkZTJYQlWRttzfPDXrvJ P_0, CInkDpXCvkZTJYQlWRttzfPDXrvJ P_1)
		{
			if (P_0.PtihhOubZXUbrolaGHhehLDFbPgT == P_1.PtihhOubZXUbrolaGHhehLDFbPgT && P_0.tWCIDhQXwYXARugPvHdheaXsmCQF == P_1.tWCIDhQXwYXARugPvHdheaXsmCQF && P_0.slrIDkOheRprZCromqiFNmCHOcZJ == P_1.slrIDkOheRprZCromqiFNmCHOcZJ && P_0.zHctRzKUAJSHjmCKSfQqHGGZFWpD == P_1.zHctRzKUAJSHjmCKSfQqHGGZFWpD && P_0.MxvPazMbMXjgmGXjotffWgwiyBOjA == P_1.MxvPazMbMXjgmGXjotffWgwiyBOjA && P_0.nUpuOXSbbspUEXGEArIvAkwAiavg == P_1.nUpuOXSbbspUEXGEArIvAkwAiavg)
			{
				return P_0.BYqvgjzzVqFgOJJcaDFlYgxzLkgP == P_1.BYqvgjzzVqFgOJJcaDFlYgxzLkgP;
			}
			return false;
		}
	}

	public enum APtUbpHRPYZjPweUXHBoBznsBWbL
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int ZeLoAublJSZfbpkLfAVgPnUpItld = 4;

	public const int tZHbJfElJPBishhDFDvdoTaLRvMRB = 32768;

	public const int dkzfVPueBuJbyuigNBAMileTxTSF = -32768;

	public const int wINlwdnVgPsnQvaLjVCCCZgojvhk = 255;

	public const int TvaQZZsTAMLVHNZMCFeJPLNwVKRV = 0;

	public const int suzmKUdDFMzpkhqSZQPOZlqJpxd = 18;

	public const int zSXMFysGEbLmiBQPKymDxOAjlENj = 14;

	public const int qWUJSnStokJVuTfjBMowumMJItAJ = 6;

	public const int DmjAKZyWBefHZcbogoUInBgoftppA = 15;

	private DVtFamzbBJjBGaphoorgklqtYuktA[] ycyiiVIRurzrsqOzbwPrufenNWmAA;

	private bool dIBJNKqbJvcbbhiIaTyZLQPKAKEBb;

	private hAmgXwAUVevHiQgIksPKKELmeJbAA BigSUmgxwQFJmrCoZLVSibSyZxCM;

	private HyRyDFpmsEFSSSjxUWpvhzojsne tShBdMdjEMcJmQqsuAFzlvSXvLqk;

	private global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool> hqUUafVcfyJdZuWCpVeWgiVBGkGi;

	private bool[] LwkeLbtAXOcbRxWOzjbOnsHSrCOV;

	private bool[] VLajQLSbpmfBlhbFLwhhJAFBmFGfb;

	private bool zqEVKBrPrvXGzVZcYsKcHgjbPpfU;

	private readonly bool ajBecwErBIOeKzRsZXvcXLAAmJgS;

	private readonly UpdateLoopSetting LCNhazEgiluyXHYzTHDJyfejyYIh;

	private UpdateLoopType vdpCzUHDhZcWpANQanoOgqZiOePlA;

	private UpdateLoopType gwtXrIHAzUkgWdgtNYFGbgyWfXQb;

	private Action<int, ControllerDataUpdater> hcgWiNbMUnOcUehWyJpmAkdnyUFt;

	private bool UknQszlPRIagXHfumbVNekxGJebtB;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> gntbSOhGOteuMBBaFqjejGQkGfFm;

	private Func<int> HbTzWsrKEnQoAbrdKMHTFYFToFhi;

	private Func<PidVid, bool> WqOvayjLJigeBuezmNOwtMIDWoHH;

	private static Guid[] YvGsMOsgNbbScgRBwubOubLrAdGO;

	private static string[] AfsUAzOOUEzSWWhLzsVYAYueAMDy;

	private static string[] TpBBLMaArlsMJDQmKhqSBWayVwEuA;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (ycyiiVIRurzrsqOzbwPrufenNWmAA[i].egEpsXWPIRlHVyByAcSBBnIbAUACA)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => null;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.XInput;

	ajDppfGDDPBwqFwQEKktuSmXoPMu AHuLsFUDywwjZMRMOCnliKJcVPho.azKelVGTkkhadfzDHYYDuOUOZVRR => ajDppfGDDPBwqFwQEKktuSmXoPMu.XInput;

	public YRWshAzrzpyrkrqnhWtbeAGqyKfV(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		ajBecwErBIOeKzRsZXvcXLAAmJgS = P_0;
		LCNhazEgiluyXHYzTHDJyfejyYIh = P_1;
		WqOvayjLJigeBuezmNOwtMIDWoHH = P_4;
		UknQszlPRIagXHfumbVNekxGJebtB = true;
		try
		{
			if (!fFZryUsdljdnPVeYUEptcGRleKhgb.ypwopninuurkULFNXgLkPzHAfzur(out var hgZiHkRoERAhldvCDoXArkHCEyqf2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (hgZiHkRoERAhldvCDoXArkHCEyqf2 < hgZiHkRoERAhldvCDoXArkHCEyqf.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			gntbSOhGOteuMBBaFqjejGQkGfFm = P_2;
			HbTzWsrKEnQoAbrdKMHTFYFToFhi = P_3;
			zqEVKBrPrvXGzVZcYsKcHgjbPpfU = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(LCNhazEgiluyXHYzTHDJyfejyYIh, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					gwtXrIHAzUkgWdgtNYFGbgyWfXQb = list[num2];
				}
			}
			hqUUafVcfyJdZuWCpVeWgiVBGkGi = new global::tYSDRrlmOWDSjWBhfIKGoQYXYEzm<bool>(true, kyIDBQICnCHrVdXnGjSQgtZvERyLc);
			LwkeLbtAXOcbRxWOzjbOnsHSrCOV = new bool[4];
			VLajQLSbpmfBlhbFLwhhJAFBmFGfb = new bool[4];
			hcgWiNbMUnOcUehWyJpmAkdnyUFt = UpdateControllerData;
			if (zqEVKBrPrvXGzVZcYsKcHgjbPpfU)
			{
				IGtBdcKDwKnNGRHxIXRwJnyLGGmfA();
			}
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
		if (UknQszlPRIagXHfumbVNekxGJebtB)
		{
			BigSUmgxwQFJmrCoZLVSibSyZxCM = new hAmgXwAUVevHiQgIksPKKELmeJbAA(1f);
		}
		tShBdMdjEMcJmQqsuAFzlvSXvLqk = new HyRyDFpmsEFSSSjxUWpvhzojsne();
		if (ycyiiVIRurzrsqOzbwPrufenNWmAA == null)
		{
			ycyiiVIRurzrsqOzbwPrufenNWmAA = new DVtFamzbBJjBGaphoorgklqtYuktA[4];
			for (int i = 0; i < 4; i++)
			{
				VHgaDakdqWdcmvuykvNEAklCFnKv vHgaDakdqWdcmvuykvNEAklCFnKv = new VHgaDakdqWdcmvuykvNEAklCFnKv(i, LCNhazEgiluyXHYzTHDJyfejyYIh);
				MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent += vHgaDakdqWdcmvuykvNEAklCFnKv.mqCxNHVmGKStcfDbxuEYcqNYTyLE;
				MROXnswaFDYJOaQMZFuqDWLdEBUH.vLuOaJcYwVMvlDPcDIdIOawkciegA.ThreadUpdateEvent += vHgaDakdqWdcmvuykvNEAklCFnKv.kuWPGQKsHtvtYapfSTZvnKoYKWPR;
				ycyiiVIRurzrsqOzbwPrufenNWmAA[i] = new DVtFamzbBJjBGaphoorgklqtYuktA(i, zqEVKBrPrvXGzVZcYsKcHgjbPpfU, vHgaDakdqWdcmvuykvNEAklCFnKv, gntbSOhGOteuMBBaFqjejGQkGfFm, SystemDeviceDisconnected);
			}
		}
		WJxdLUEolPcEXeUodyMAeKBRPXuRb(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		vdpCzUHDhZcWpANQanoOgqZiOePlA = currentUpdateLoop;
		XNJGPUmYwnFiLJXvqidoNsQAkHEO();
		for (int i = 0; i < 4; i++)
		{
			if (ycyiiVIRurzrsqOzbwPrufenNWmAA[i] != null && ycyiiVIRurzrsqOzbwPrufenNWmAA[i].egEpsXWPIRlHVyByAcSBBnIbAUACA)
			{
				ycyiiVIRurzrsqOzbwPrufenNWmAA[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (hqUUafVcfyJdZuWCpVeWgiVBGkGi != null)
		{
			hqUUafVcfyJdZuWCpVeWgiVBGkGi.VshDPveQjVqQFgogDGildcmcWyJLc();
		}
		if (ycyiiVIRurzrsqOzbwPrufenNWmAA != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (ycyiiVIRurzrsqOzbwPrufenNWmAA[i] != null)
				{
					if (MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm != null)
					{
						MROXnswaFDYJOaQMZFuqDWLdEBUH.qiyreAjcjPJuJWySIGEplISgOUlm.ThreadUpdateEvent -= ycyiiVIRurzrsqOzbwPrufenNWmAA[i].DxRLypsVfUWaBFBLlwymcmPqipfp.mqCxNHVmGKStcfDbxuEYcqNYTyLE;
					}
					if (MROXnswaFDYJOaQMZFuqDWLdEBUH.vLuOaJcYwVMvlDPcDIdIOawkciegA != null)
					{
						MROXnswaFDYJOaQMZFuqDWLdEBUH.vLuOaJcYwVMvlDPcDIdIOawkciegA.ThreadUpdateEvent -= ycyiiVIRurzrsqOzbwPrufenNWmAA[i].DxRLypsVfUWaBFBLlwymcmPqipfp.kuWPGQKsHtvtYapfSTZvnKoYKWPR;
					}
					ycyiiVIRurzrsqOzbwPrufenNWmAA[i].Dispose();
				}
			}
		}
		fFZryUsdljdnPVeYUEptcGRleKhgb.rDwDptLLGKKqgFxVfdiJkjffTeKq();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return hcgWiNbMUnOcUehWyJpmAkdnyUFt;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		ycyiiVIRurzrsqOzbwPrufenNWmAA[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		WJxdLUEolPcEXeUodyMAeKBRPXuRb(true);
		UYRQaRmFVeuqYIJeeeHTBdhBdGAiA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		WJxdLUEolPcEXeUodyMAeKBRPXuRb(true);
		UYRQaRmFVeuqYIJeeeHTBdhBdGAiA();
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

	bool AHuLsFUDywwjZMRMOCnliKJcVPho.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (WqOvayjLJigeBuezmNOwtMIDWoHH(pidVid))
		{
			return false;
		}
		return SCBcFPuDUuOKXbpPTSDlFwtrpdDP(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool aonYjedtgLGTvNvBlITkxiRWEouk()
	{
		if (vdpCzUHDhZcWpANQanoOgqZiOePlA != gwtXrIHAzUkgWdgtNYFGbgyWfXQb)
		{
			return false;
		}
		bool num = BigSUmgxwQFJmrCoZLVSibSyZxCM.PKaFfEBnwJOyWldVGufKCsUoBEAY();
		if (num)
		{
			WJxdLUEolPcEXeUodyMAeKBRPXuRb(true);
		}
		return num;
	}

	private void WJxdLUEolPcEXeUodyMAeKBRPXuRb(bool P_0)
	{
		dIBJNKqbJvcbbhiIaTyZLQPKAKEBb = P_0;
		if (UknQszlPRIagXHfumbVNekxGJebtB)
		{
			BigSUmgxwQFJmrCoZLVSibSyZxCM.iyGxqfzoHaFlmDzCAIDBQlvEwBso();
		}
	}

	private void UYRQaRmFVeuqYIJeeeHTBdhBdGAiA()
	{
		if (hqUUafVcfyJdZuWCpVeWgiVBGkGi != null)
		{
			hqUUafVcfyJdZuWCpVeWgiVBGkGi.YYGEFUKeavnCFHfYobUgfZFmeDSI();
		}
	}

	private void IGtBdcKDwKnNGRHxIXRwJnyLGGmfA()
	{
		_ = new KhdcWngGVIvUISqmYoBXgfhjgnNVA().kbLhwnrHQvQVDBUMFjBJzrqLnvaB;
	}

	private void XNJGPUmYwnFiLJXvqidoNsQAkHEO()
	{
		bool flag = false;
		if (UknQszlPRIagXHfumbVNekxGJebtB)
		{
			flag = aonYjedtgLGTvNvBlITkxiRWEouk();
		}
		if (!flag && dIBJNKqbJvcbbhiIaTyZLQPKAKEBb)
		{
			DgXSPObxbHnQnzNOpZuOATkvWRjd(VEsbIThxQxGSCcxKxJlMPflPbJPl());
			WJxdLUEolPcEXeUodyMAeKBRPXuRb(false);
			UYRQaRmFVeuqYIJeeeHTBdhBdGAiA();
			return;
		}
		if (dIBJNKqbJvcbbhiIaTyZLQPKAKEBb)
		{
			aVkcfEcYiGRPRyDQZHHMKddxmpkg();
		}
		if (hqUUafVcfyJdZuWCpVeWgiVBGkGi.YASgmbEQfqbFGemfMILquknsdBcZA && hqUUafVcfyJdZuWCpVeWgiVBGkGi.CUmiTZTnrHmOILdUvpnQSdUBdzmgA())
		{
			mqCLsiVTEyMHmRerCWriJAvUCpyr();
		}
	}

	private void aVkcfEcYiGRPRyDQZHHMKddxmpkg()
	{
		dIBJNKqbJvcbbhiIaTyZLQPKAKEBb = false;
		if (!hqUUafVcfyJdZuWCpVeWgiVBGkGi.YASgmbEQfqbFGemfMILquknsdBcZA)
		{
			hqUUafVcfyJdZuWCpVeWgiVBGkGi.iHiGIFABtyBNGjnHrdGZBnbyaQGe();
		}
	}

	private void mqCLsiVTEyMHmRerCWriJAvUCpyr()
	{
		lock (LwkeLbtAXOcbRxWOzjbOnsHSrCOV)
		{
			Array.Copy(LwkeLbtAXOcbRxWOzjbOnsHSrCOV, VLajQLSbpmfBlhbFLwhhJAFBmFGfb, 4);
		}
		DgXSPObxbHnQnzNOpZuOATkvWRjd(VLajQLSbpmfBlhbFLwhhJAFBmFGfb);
	}

	private bool kyIDBQICnCHrVdXnGjSQgtZvERyLc()
	{
		lock (LwkeLbtAXOcbRxWOzjbOnsHSrCOV)
		{
			for (int i = 0; i < 4; i++)
			{
				if (ycyiiVIRurzrsqOzbwPrufenNWmAA[i] != null)
				{
					LwkeLbtAXOcbRxWOzjbOnsHSrCOV[i] = ycyiiVIRurzrsqOzbwPrufenNWmAA[i].HhrOlDFerQRQruADSjwYQTSAGmIIA(APtUbpHRPYZjPweUXHBoBznsBWbL.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] VEsbIThxQxGSCcxKxJlMPflPbJPl()
	{
		for (int i = 0; i < 4; i++)
		{
			VLajQLSbpmfBlhbFLwhhJAFBmFGfb[i] = ycyiiVIRurzrsqOzbwPrufenNWmAA[i].HhrOlDFerQRQruADSjwYQTSAGmIIA(APtUbpHRPYZjPweUXHBoBznsBWbL.Synchronous);
		}
		return VLajQLSbpmfBlhbFLwhhJAFBmFGfb;
	}

	private void DgXSPObxbHnQnzNOpZuOATkvWRjd(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (ycyiiVIRurzrsqOzbwPrufenNWmAA[i] != null && ycyiiVIRurzrsqOzbwPrufenNWmAA[i].VGXGfjQGbAJdHbrUJkVFMDcsoEfr)
			{
				bool flag = P_0[i];
				ycyiiVIRurzrsqOzbwPrufenNWmAA[i].ThedyfHJWjCCLCSTCTYhqJuoOYmc(flag);
				if (!flag)
				{
					pItIQNeIbUhfKmQMLJUEETNShGZd(ycyiiVIRurzrsqOzbwPrufenNWmAA[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (ycyiiVIRurzrsqOzbwPrufenNWmAA[j] != null && !ycyiiVIRurzrsqOzbwPrufenNWmAA[j].VGXGfjQGbAJdHbrUJkVFMDcsoEfr)
			{
				bool flag2 = P_0[j];
				ycyiiVIRurzrsqOzbwPrufenNWmAA[j].ThedyfHJWjCCLCSTCTYhqJuoOYmc(flag2);
				if (flag2 && !pItIQNeIbUhfKmQMLJUEETNShGZd(ycyiiVIRurzrsqOzbwPrufenNWmAA[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (ycyiiVIRurzrsqOzbwPrufenNWmAA[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					ycyiiVIRurzrsqOzbwPrufenNWmAA[k].DRbdqkEyRFLcLMwsuSIaoVjYLYAiA(P_0[k]);
				}
			}
		}
	}

	private bool pItIQNeIbUhfKmQMLJUEETNShGZd(DVtFamzbBJjBGaphoorgklqtYuktA P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.WeyCvGcVXEhCkcxejtKcigMUljxL();
			if (!P_0.PqHvcEKgRtSoGJVdrKjrJHBcKWLp)
			{
				return false;
			}
			int num = tShBdMdjEMcJmQqsuAFzlvSXvLqk.VcDvAJnRIdSOpWKkOdbSOaezeIofA(P_0.elqQQTvVEbEkKSBpiTmjBACOKKYr, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = tShBdMdjEMcJmQqsuAFzlvSXvLqk.JQibDqwCsrTcbefCHQMqBrsXtmMv(num);
				tShBdMdjEMcJmQqsuAFzlvSXvLqk.bhEmRVIbtzaxVGsrHbpCfXbBouMPb(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = HbTzWsrKEnQoAbrdKMHTFYFToFhi();
				tShBdMdjEMcJmQqsuAFzlvSXvLqk.ynlXUrUMYCXYxpsAqaBapRGerrdr(P_0, true);
			}
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
			}
			BridgedController obj = P_0.ToBridgedController();
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = tShBdMdjEMcJmQqsuAFzlvSXvLqk.OCsffSCaeZzIXFLIJbaFgVnGqWbxb(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.elqQQTvVEbEkKSBpiTmjBACOKKYr, true);
			if (num2 >= 0)
			{
				tShBdMdjEMcJmQqsuAFzlvSXvLqk.EGRbFuDncaLTwguSfOOzjEKCaVVC(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.VUCcBPjfXFgCKbImzjaBdyYlKBjqA();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static YRWshAzrzpyrkrqnhWtbeAGqyKfV()
	{
		YvGsMOsgNbbScgRBwubOubLrAdGO = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		AfsUAzOOUEzSWWhLzsVYAYueAMDy = new string[1] { "Xbox Bluetooth Gamepad" };
		TpBBLMaArlsMJDQmKhqSBWayVwEuA = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool SCBcFPuDUuOKXbpPTSDlFwtrpdDP(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(YvGsMOsgNbbScgRBwubOubLrAdGO, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < AfsUAzOOUEzSWWhLzsVYAYueAMDy.Length; i++)
			{
				if (P_1.Equals(AfsUAzOOUEzSWWhLzsVYAYueAMDy[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < TpBBLMaArlsMJDQmKhqSBWayVwEuA.Length; j++)
			{
				if (Regex.IsMatch(P_2, TpBBLMaArlsMJDQmKhqSBWayVwEuA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		P_0 = P_0.ToLower();
		int num = P_0.IndexOf("vid_");
		if (num < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num)
		{
			return false;
		}
		return true;
	}
}
