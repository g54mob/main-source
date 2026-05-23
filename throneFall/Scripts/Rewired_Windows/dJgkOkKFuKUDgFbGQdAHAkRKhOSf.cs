using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class dJgkOkKFuKUDgFbGQdAHAkRKhOSf : PlatformInputManager, WcLOVIVVtbKfXzBpbdfQnbxdxBNU
{
	private class nqFAqQygbeqywhAOyhuthDgdnaAoA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int pFOhteDcdUKSpXYYqGuTudRDFfudA;

		private int FcpuYSwXEfDYJFuHSEgkmwBcxhGy;

		public Guid MzJjwtozYOtnjebmZjmKPgFgeVAJ;

		public string CrvwsgSmjQtANGTIpPMawimGUBwe;

		private readonly OzySGGBmBYhYxgwfTlyHImbOUOXkA SLshAjSrxOGPqqMetDBGMfOrSFoM;

		private readonly DeviceType gwrvAJsWZOPyyeFXehmODJFDfJVr;

		public string SNFNRGZEsiuOwlPKEHwrDGMqmyToA;

		public string qjrSCvKbsQClTNlntTnqJjADMlKj;

		public string PWNaLDZImUzuWpehueQkofTNyFfX;

		public int XkcbTPUYyfsysBFMFTjdoipwaPjc;

		public int CrZGrYpIBEhtKBkeHoZGcLYvXTXdb;

		public Guid zNKRQcqwTerrbYGHqczUnSOLRhWs;

		public Guid BUlOJQImYTAbJlJepatPFBRcMLmh;

		public Guid JrdeLnnqbZyuOohWchZBvhjofLdm;

		public int xSuHQANYINRgYnplhhObFnfWzpufA;

		public int UhvkXWIUyDbMnBggXGawaGPoJCkEb;

		public int MLKYPeozmRWMCHMpFBzuNslwXByh;

		public int rjhQAVSaVJqRuSbbtfkxRkURhjnW;

		public int CbpfBnityVVJYxsssSDnjxpmPJVq;

		public int CpplwqMPNHkNSjXWuGkrCagaeghP;

		public bool CvrcQOtdMZkKfvNnrtCDddABVOin;

		public bool SVYTluhYGFBfbrvSeckcwhtqNzIE;

		public bool dbekTUUJjmVfnAIZCAbIAHYbJiQT;

		public int DeraddMmJOhMYtmtAWWKgIlTUKaN;

		private float[] itZMHnvPvFdUGeamKPxUdVdEBKtk;

		private float[] yyCpEEsjZkVFRWlprHllEemxuCSOA;

		private bool[] rjTVNLNjnPTtJSccGHRTjJNCMMqb;

		private HardwareJoystickMap_InputManager YFOGPkgNpvmKKLrIfxOTePpLXYsoA;

		private QHiAClADbJnDqzrVZKYXIrwOCrSLA wpuNkfcgtLcMDbMrmhTynocvQQzwA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> YUwaxqSdxshVjnwjEbUkEFnsmrmM;

		private bool gdoACvPLtxhtozbvosBGTwUmmNTV;

		private bool VoCsUPKBdnqPsnMQDaWeydEWCChO;

		[CompilerGenerated]
		private Controller.Extension GsTWdZidFjOoIhtKhjBzzwzLcqBu;

		private bool BgcbbTqDrSbHsvwrWeNERSXpdneb;

		public bool sYpEazATeYXsMSaHdpjefXKGiHihb
		{
			get
			{
				if (SLshAjSrxOGPqqMetDBGMfOrSFoM == null)
				{
					return false;
				}
				return SLshAjSrxOGPqqMetDBGMfOrSFoM.KalRSGqHTzKnJkTISFnZkGzaHthW != null;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return pFOhteDcdUKSpXYYqGuTudRDFfudA;
			}
			set
			{
				pFOhteDcdUKSpXYYqGuTudRDFfudA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return FcpuYSwXEfDYJFuHSEgkmwBcxhGy;
			}
			set
			{
				FcpuYSwXEfDYJFuHSEgkmwBcxhGy = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (CrvwsgSmjQtANGTIpPMawimGUBwe != "Unknown Controller")
				{
					return CrvwsgSmjQtANGTIpPMawimGUBwe;
				}
				if (SVYTluhYGFBfbrvSeckcwhtqNzIE && !string.IsNullOrEmpty(PWNaLDZImUzuWpehueQkofTNyFfX))
				{
					return PWNaLDZImUzuWpehueQkofTNyFfX;
				}
				return qjrSCvKbsQClTNlntTnqJjADMlKj;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (FcpuYSwXEfDYJFuHSEgkmwBcxhGy < 0)
				{
					return null;
				}
				return FcpuYSwXEfDYJFuHSEgkmwBcxhGy;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return GsTWdZidFjOoIhtKhjBzzwzLcqBu;
			}
			[CompilerGenerated]
			set
			{
				GsTWdZidFjOoIhtKhjBzzwzLcqBu = value;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => zNKRQcqwTerrbYGHqczUnSOLRhWs;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		public bool AUFStxkYdraklHuRbcjLxpGcSdoJ
		{
			get
			{
				if (!BgcbbTqDrSbHsvwrWeNERSXpdneb && SLshAjSrxOGPqqMetDBGMfOrSFoM != null)
				{
					return SLshAjSrxOGPqqMetDBGMfOrSFoM.WYPgwlxfWSquIdmwfSuIWqJEKgqL;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = AUFStxkYdraklHuRbcjLxpGcSdoJ;
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = AUFStxkYdraklHuRbcjLxpGcSdoJ;
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public nqFAqQygbeqywhAOyhuthDgdnaAoA(OzySGGBmBYhYxgwfTlyHImbOUOXkA P_0, DeviceType P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			SLshAjSrxOGPqqMetDBGMfOrSFoM = P_0;
			gwrvAJsWZOPyyeFXehmODJFDfJVr = P_1;
			YUwaxqSdxshVjnwjEbUkEFnsmrmM = P_2;
			FcpuYSwXEfDYJFuHSEgkmwBcxhGy = -1;
			pFOhteDcdUKSpXYYqGuTudRDFfudA = -1;
		}

		public void maMcVQcOWYriWjoCdlBWLhmYRZMA()
		{
			if (!AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				return;
			}
			string obj = ((!string.IsNullOrEmpty(PWNaLDZImUzuWpehueQkofTNyFfX)) ? PWNaLDZImUzuWpehueQkofTNyFfX : qjrSCvKbsQClTNlntTnqJjADMlKj);
			Guid bUlOJQImYTAbJlJepatPFBRcMLmh = BUlOJQImYTAbJlJepatPFBRcMLmh;
			JrdeLnnqbZyuOohWchZBvhjofLdm = MiscTools.CreateGuidHashSHA1(obj + bUlOJQImYTAbJlJepatPFBRcMLmh.ToString());
			UhvkXWIUyDbMnBggXGawaGPoJCkEb = rjhQAVSaVJqRuSbbtfkxRkURhjnW;
			MLKYPeozmRWMCHMpFBzuNslwXByh = CbpfBnityVVJYxsssSDnjxpmPJVq + CpplwqMPNHkNSjXWuGkrCagaeghP * 8;
			QKyAaKjXJOkSSuYOFNKEtXvZzKUCA();
			MzJjwtozYOtnjebmZjmKPgFgeVAJ = YFOGPkgNpvmKKLrIfxOTePpLXYsoA.hardwareMapIdentifier.guid;
			CrvwsgSmjQtANGTIpPMawimGUBwe = YFOGPkgNpvmKKLrIfxOTePpLXYsoA.controllerName;
			gdoACvPLtxhtozbvosBGTwUmmNTV = ((MzJjwtozYOtnjebmZjmKPgFgeVAJ == Guid.Empty) ? true : false);
			itZMHnvPvFdUGeamKPxUdVdEBKtk = new float[UhvkXWIUyDbMnBggXGawaGPoJCkEb];
			yyCpEEsjZkVFRWlprHllEemxuCSOA = new float[MLKYPeozmRWMCHMpFBzuNslwXByh];
			rjTVNLNjnPTtJSccGHRTjJNCMMqb = new bool[MLKYPeozmRWMCHMpFBzuNslwXByh];
			if (YFOGPkgNpvmKKLrIfxOTePpLXYsoA != null && MLKYPeozmRWMCHMpFBzuNslwXByh > 0)
			{
				switch (YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map.platform)
				{
				case InputPlatform.WindowsRawInput:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							rjTVNLNjnPTtJSccGHRTjJNCMMqb[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				case InputPlatform.WindowsDirectInput:
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							rjTVNLNjnPTtJSccGHRTjJNCMMqb[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			wpuNkfcgtLcMDbMrmhTynocvQQzwA = SLshAjSrxOGPqqMetDBGMfOrSFoM.zRFtBzLHJIBsKaNUKFxRdrZsuZXq;
			Update();
		}

		public void dqCYkvpqpkfLjcYJRaSwhNRlxTrd(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0)
		{
			if (AUFStxkYdraklHuRbcjLxpGcSdoJ && P_0 != null)
			{
				FcpuYSwXEfDYJFuHSEgkmwBcxhGy = P_0.FcpuYSwXEfDYJFuHSEgkmwBcxhGy;
				pFOhteDcdUKSpXYYqGuTudRDFfudA = P_0.pFOhteDcdUKSpXYYqGuTudRDFfudA;
				for (int i = 0; i < MathTools.Min(yyCpEEsjZkVFRWlprHllEemxuCSOA.Length, P_0.yyCpEEsjZkVFRWlprHllEemxuCSOA.Length); i++)
				{
					yyCpEEsjZkVFRWlprHllEemxuCSOA[i] = P_0.yyCpEEsjZkVFRWlprHllEemxuCSOA[i];
				}
				for (int j = 0; j < MathTools.Min(rjTVNLNjnPTtJSccGHRTjJNCMMqb.Length, P_0.rjTVNLNjnPTtJSccGHRTjJNCMMqb.Length); j++)
				{
					rjTVNLNjnPTtJSccGHRTjJNCMMqb[j] = P_0.rjTVNLNjnPTtJSccGHRTjJNCMMqb[j];
				}
				for (int k = 0; k < MathTools.Min(itZMHnvPvFdUGeamKPxUdVdEBKtk.Length, P_0.itZMHnvPvFdUGeamKPxUdVdEBKtk.Length); k++)
				{
					itZMHnvPvFdUGeamKPxUdVdEBKtk[k] = P_0.itZMHnvPvFdUGeamKPxUdVdEBKtk[k];
				}
				VoCsUPKBdnqPsnMQDaWeydEWCChO = P_0.VoCsUPKBdnqPsnMQDaWeydEWCChO;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				bool[] array = SLshAjSrxOGPqqMetDBGMfOrSFoM.nfulUzEzTLPuprbLuElbHvwsLQVkA;
				int[] array2 = SLshAjSrxOGPqqMetDBGMfOrSFoM.agMgBsulKeFEUKxbyMYzjAYaJqljA;
				SEYClaGmyPYuXiVHZkPJgIlxZWSi(array, array2);
				TBUlbmufKuEFRskNbwlfmfjcFHUAA(array, array2);
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				return;
			}
			if (UhvkXWIUyDbMnBggXGawaGPoJCkEb != dataUpdater.axisCount || MLKYPeozmRWMCHMpFBzuNslwXByh != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < UhvkXWIUyDbMnBggXGawaGPoJCkEb; i++)
			{
				dataUpdater.axisValues[i] = itZMHnvPvFdUGeamKPxUdVdEBKtk[i];
			}
			for (int j = 0; j < MLKYPeozmRWMCHMpFBzuNslwXByh; j++)
			{
				if (rjTVNLNjnPTtJSccGHRTjJNCMMqb[j])
				{
					dataUpdater.buttonPressureValues[j] = yyCpEEsjZkVFRWlprHllEemxuCSOA[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = yyCpEEsjZkVFRWlprHllEemxuCSOA[j] > 0f;
				}
			}
			if (VoCsUPKBdnqPsnMQDaWeydEWCChO && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int oJZXzVOfmJWDAMPLCqzBEQTdpGHX(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0)
		{
			if (!AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				return 0;
			}
			if (P_0.pFOhteDcdUKSpXYYqGuTudRDFfudA == pFOhteDcdUKSpXYYqGuTudRDFfudA)
			{
				return 2;
			}
			if (rjhQAVSaVJqRuSbbtfkxRkURhjnW != P_0.rjhQAVSaVJqRuSbbtfkxRkURhjnW)
			{
				return 0;
			}
			if (CbpfBnityVVJYxsssSDnjxpmPJVq != P_0.CbpfBnityVVJYxsssSDnjxpmPJVq)
			{
				return 0;
			}
			if (CpplwqMPNHkNSjXWuGkrCagaeghP != P_0.CpplwqMPNHkNSjXWuGkrCagaeghP)
			{
				return 0;
			}
			if (sYpEazATeYXsMSaHdpjefXKGiHihb != P_0.sYpEazATeYXsMSaHdpjefXKGiHihb)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.JrdeLnnqbZyuOohWchZBvhjofLdm == JrdeLnnqbZyuOohWchZBvhjofLdm)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo DenGNEdNbAsTbemZjydPUgLvCEEIc()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			xSnjOGEXqRpKadkciaqBWAJQWccn(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			qzHTkqsHSTRKjASEXbDoaMznJGXu(bridgedController);
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
			return new ControllerDisconnectedEventArgs(pFOhteDcdUKSpXYYqGuTudRDFfudA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void SEYClaGmyPYuXiVHZkPJgIlxZWSi(bool[] P_0, int[] P_1)
		{
			if (UhvkXWIUyDbMnBggXGawaGPoJCkEb <= 0)
			{
				return;
			}
			switch (YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						WEstCycdSYcFmMTBdAZpmkIGkEaG(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						WEstCycdSYcFmMTBdAZpmkIGkEaG(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						wKilpIAPTeIEFXYODLcmBglGXgyR(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void TBUlbmufKuEFRskNbwlfmfjcFHUAA(bool[] P_0, int[] P_1)
		{
			if (MLKYPeozmRWMCHMpFBzuNslwXByh <= 0)
			{
				return;
			}
			switch (YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						tYuPFlhlvOFOdEhYLneATjPBSicUA(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						tYuPFlhlvOFOdEhYLneATjPBSicUA(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)YFOGPkgNpvmKKLrIfxOTePpLXYsoA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						PSqgAYoDfkXIVDnyBCaTgztLCXeZ(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void WEstCycdSYcFmMTBdAZpmkIGkEaG(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= UhvkXWIUyDbMnBggXGawaGPoJCkEb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			itZMHnvPvFdUGeamKPxUdVdEBKtk[P_1] = PMMNtjFoEiPFVzFpjDUBPeruawKb(P_0, P_2, P_3);
			if (!VoCsUPKBdnqPsnMQDaWeydEWCChO && itZMHnvPvFdUGeamKPxUdVdEBKtk[P_1] != 0f)
			{
				VoCsUPKBdnqPsnMQDaWeydEWCChO = true;
			}
		}

		private void tYuPFlhlvOFOdEhYLneATjPBSicUA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= MLKYPeozmRWMCHMpFBzuNslwXByh)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			yyCpEEsjZkVFRWlprHllEemxuCSOA[P_1] = FKcZXzeKushVHnINYAidDwvAUYkkA(P_0, P_2, P_3);
			if (!VoCsUPKBdnqPsnMQDaWeydEWCChO && yyCpEEsjZkVFRWlprHllEemxuCSOA[P_1] != 0f)
			{
				VoCsUPKBdnqPsnMQDaWeydEWCChO = true;
			}
		}

		private float PMMNtjFoEiPFVzFpjDUBPeruawKb(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
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
				return fALXlRRcZCEOMfDrEKhNkSbgKiJs((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= CbpfBnityVVJYxsssSDnjxpmPJVq || sourceButton >= 256)
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
				if (sourceHat < 0 || sourceHat >= CpplwqMPNHkNSjXWuGkrCagaeghP || sourceHat >= 4)
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
					num3 = caaCHXgSCwyUjRxTZpyqAtLLTYrDA(num2, AxisDirection.Horizontal);
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
					num3 = caaCHXgSCwyUjRxTZpyqAtLLTYrDA(num2, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && BYFWsTnxgBHAerglrcLoHnNxotbqA(customCalculationSourceData[i], out var item))
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

		private float fALXlRRcZCEOMfDrEKhNkSbgKiJs(RawInputAxis P_0, int P_1)
		{
			return RnCdOJjQBlCFlenyunxufCvNtCdiA((wpuNkfcgtLcMDbMrmhTynocvQQzwA as nYpnZgtHaQPSwPsapFlTmgDlfAMU).hRhinkLYTiROeOdHlyUupdGxydfl(P_0, P_1));
		}

		private float FKcZXzeKushVHnINYAidDwvAUYkkA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= CbpfBnityVVJYxsssSDnjxpmPJVq || sourceButton >= 256)
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
				float num2 = fALXlRRcZCEOMfDrEKhNkSbgKiJs((RawInputAxis)sourceAxis, num);
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
				if (sourceHat < 0 || sourceHat >= CpplwqMPNHkNSjXWuGkrCagaeghP || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (ZxREsVITuMBkTqkMXLkjmOTtOPoR(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (BYFWsTnxgBHAerglrcLoHnNxotbqA(customCalculationSourceData[k], out var num4))
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

		private float RnCdOJjQBlCFlenyunxufCvNtCdiA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float XpxZagJjUjBBiDuzZgXNLsUpvjZGA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (YFOGPkgNpvmKKLrIfxOTePpLXYsoA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
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
				return 1f;
			}
			return 0f;
		}

		private float caaCHXgSCwyUjRxTZpyqAtLLTYrDA(int P_0, AxisDirection P_1)
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

		private bool ZxREsVITuMBkTqkMXLkjmOTtOPoR(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= CbpfBnityVVJYxsssSDnjxpmPJVq || sourceButton >= 256)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool BYFWsTnxgBHAerglrcLoHnNxotbqA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = fALXlRRcZCEOMfDrEKhNkSbgKiJs((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
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

		private ControlDeviceType QgALtMjQCUPGOShkQNwNrCJVEOEX(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.Keyboard, 
				DeviceType.Joystick => ControlDeviceType.Joystick, 
				DeviceType.Gamepad => ControlDeviceType.Gamepad, 
				DeviceType.Mouse => ControlDeviceType.Mouse, 
				DeviceType.MultiAxisController => ControlDeviceType.Joystick, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void wKilpIAPTeIEFXYODLcmBglGXgyR(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= UhvkXWIUyDbMnBggXGawaGPoJCkEb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			itZMHnvPvFdUGeamKPxUdVdEBKtk[P_1] = rySdbGYgMwhfUIjCpKbEAsIAAVacc(P_0, P_2, P_3);
			if (!VoCsUPKBdnqPsnMQDaWeydEWCChO && itZMHnvPvFdUGeamKPxUdVdEBKtk[P_1] != 0f)
			{
				VoCsUPKBdnqPsnMQDaWeydEWCChO = true;
			}
		}

		private void PSqgAYoDfkXIVDnyBCaTgztLCXeZ(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= MLKYPeozmRWMCHMpFBzuNslwXByh)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			yyCpEEsjZkVFRWlprHllEemxuCSOA[P_1] = AuuFtzwhyvPKReBwtQsloVBboFoP(P_0, P_2, P_3);
			if (!VoCsUPKBdnqPsnMQDaWeydEWCChO && yyCpEEsjZkVFRWlprHllEemxuCSOA[P_1] != 0f)
			{
				VoCsUPKBdnqPsnMQDaWeydEWCChO = true;
			}
		}

		private float rySdbGYgMwhfUIjCpKbEAsIAAVacc(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= rjhQAVSaVJqRuSbbtfkxRkURhjnW || sourceAxis >= 56)
				{
					return 0f;
				}
				return SCitIWMzUMxyWQVPBkneJRtGeqVc(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= CbpfBnityVVJYxsssSDnjxpmPJVq || sourceButton >= 256)
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
				if (sourceHat < 0 || sourceHat >= CpplwqMPNHkNSjXWuGkrCagaeghP || sourceHat >= 4)
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
					num2 = caaCHXgSCwyUjRxTZpyqAtLLTYrDA(num, AxisDirection.Horizontal);
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
					num2 = caaCHXgSCwyUjRxTZpyqAtLLTYrDA(num, AxisDirection.Vertical);
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

		private float SCitIWMzUMxyWQVPBkneJRtGeqVc(int P_0)
		{
			return (wpuNkfcgtLcMDbMrmhTynocvQQzwA as gHDldKZwkuMzyeVpZkScEkEvRLzo).JsdLJuvJFWtMNMRkkyWGxZdvTLbL(P_0);
		}

		private float AuuFtzwhyvPKReBwtQsloVBboFoP(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= CbpfBnityVVJYxsssSDnjxpmPJVq || sourceButton >= 256)
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
				if (sourceAxis < 0 || sourceAxis >= rjhQAVSaVJqRuSbbtfkxRkURhjnW || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = SCitIWMzUMxyWQVPBkneJRtGeqVc(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= CpplwqMPNHkNSjXWuGkrCagaeghP || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return XpxZagJjUjBBiDuzZgXNLsUpvjZGA(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private bool QeCnoJTqEBHCRCcHExCdDRliDHVz(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
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

		private float olOKjRYWYSsIwdevJDJmgSKZMapGA(int P_0, AxisDirection P_1)
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

		private void QKyAaKjXJOkSSuYOFNKEtXvZzKUCA()
		{
			YFOGPkgNpvmKKLrIfxOTePpLXYsoA = YUwaxqSdxshVjnwjEbUkEFnsmrmM(DenGNEdNbAsTbemZjydPUgLvCEEIc());
			if (YFOGPkgNpvmKKLrIfxOTePpLXYsoA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			UhvkXWIUyDbMnBggXGawaGPoJCkEb = YFOGPkgNpvmKKLrIfxOTePpLXYsoA.axisCount;
			MLKYPeozmRWMCHMpFBzuNslwXByh = YFOGPkgNpvmKKLrIfxOTePpLXYsoA.buttonCount;
		}

		private string EeTIRIgbvJGFvZsWsAznFZiKhGZVA()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), SLshAjSrxOGPqqMetDBGMfOrSFoM.lNDAbWrWwWQRQeotEGgOCJOvUimC, (SVYTluhYGFBfbrvSeckcwhtqNzIE && !string.IsNullOrEmpty(PWNaLDZImUzuWpehueQkofTNyFfX)) ? PWNaLDZImUzuWpehueQkofTNyFfX : qjrSCvKbsQClTNlntTnqJjADMlKj, XkcbTPUYyfsysBFMFTjdoipwaPjc.ToString("X4"), CrZGrYpIBEhtKBkeHoZGcLYvXTXdb.ToString("X4")));
		}

		private void xSnjOGEXqRpKadkciaqBWAJQWccn(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = SLshAjSrxOGPqqMetDBGMfOrSFoM.lNDAbWrWwWQRQeotEGgOCJOvUimC;
			P_0.deviceType = QgALtMjQCUPGOShkQNwNrCJVEOEX(gwrvAJsWZOPyyeFXehmODJFDfJVr);
			P_0.hardwareIdentifier = EeTIRIgbvJGFvZsWsAznFZiKhGZVA();
			P_0.hardwareAxisCount = rjhQAVSaVJqRuSbbtfkxRkURhjnW;
			P_0.hardwareButtonCount = CbpfBnityVVJYxsssSDnjxpmPJVq;
			P_0.hardwareHatCount = CpplwqMPNHkNSjXWuGkrCagaeghP;
			P_0.hw_productName = qjrSCvKbsQClTNlntTnqJjADMlKj;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_vendorId = CrZGrYpIBEhtKBkeHoZGcLYvXTXdb;
			P_0.hw_productId = XkcbTPUYyfsysBFMFTjdoipwaPjc;
			P_0.hw_pidVid = new PidVid(BUlOJQImYTAbJlJepatPFBRcMLmh);
			P_0.hw_isBluetoothDevice = SVYTluhYGFBfbrvSeckcwhtqNzIE;
			P_0.hw_bluetoothDeviceName = PWNaLDZImUzuWpehueQkofTNyFfX;
			P_0.hw_supportsVibration = dbekTUUJjmVfnAIZCAbIAHYbJiQT;
			P_0.hw_localVibrationMotorCount = DeraddMmJOhMYtmtAWWKgIlTUKaN;
			P_0.definitionMatchTag = SLshAjSrxOGPqqMetDBGMfOrSFoM.CnQQmnZKDYCDDZhJigwiEXljPCbd;
		}

		private void qzHTkqsHSTRKjASEXbDoaMznJGXu(BridgedController P_0)
		{
			xSnjOGEXqRpKadkciaqBWAJQWccn(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = YFOGPkgNpvmKKLrIfxOTePpLXYsoA.ToGameHardwareControllerMap();
			P_0.instanceName = SNFNRGZEsiuOwlPKEHwrDGMqmyToA;
			P_0.productName = qjrSCvKbsQClTNlntTnqJjADMlKj;
			P_0.isXInputDevice = CvrcQOtdMZkKfvNnrtCDddABVOin;
			P_0.axisCount = UhvkXWIUyDbMnBggXGawaGPoJCkEb;
			P_0.buttonCount = MLKYPeozmRWMCHMpFBzuNslwXByh;
			P_0.isButtonPressureSensitive = new bool[MLKYPeozmRWMCHMpFBzuNslwXByh];
			Array.Copy(rjTVNLNjnPTtJSccGHRTjJNCMMqb, P_0.isButtonPressureSensitive, MLKYPeozmRWMCHMpFBzuNslwXByh);
			P_0.unknownControllerHats = TqZuZOxxCjvttRpOomosotInpuGC();
			P_0.controllerTypeGuid = MzJjwtozYOtnjebmZjmKPgFgeVAJ;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void qSWShVFzOwWPJjHZmFxiLKZivkPd()
		{
			for (int i = 0; i < MLKYPeozmRWMCHMpFBzuNslwXByh; i++)
			{
				yyCpEEsjZkVFRWlprHllEemxuCSOA[i] = 0f;
			}
			for (int j = 0; j < UhvkXWIUyDbMnBggXGawaGPoJCkEb; j++)
			{
				itZMHnvPvFdUGeamKPxUdVdEBKtk[j] = 0f;
			}
		}

		private UnknownControllerHat[] TqZuZOxxCjvttRpOomosotInpuGC()
		{
			if (!gdoACvPLtxhtozbvosBGTwUmmNTV)
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

		public void qFndkxoSdEDzpOKvYxDWbNTEFbwB()
		{
			dkdpUQmkNxrRyYkODDzootiyERHb(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void YLSnyPRSAKLLTtlRAjaaMCrociIgA()
		{
			try
			{
				dkdpUQmkNxrRyYkODDzootiyERHb(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void dkdpUQmkNxrRyYkODDzootiyERHb(bool P_0)
		{
			if (!BgcbbTqDrSbHsvwrWeNERSXpdneb)
			{
				BgcbbTqDrSbHsvwrWeNERSXpdneb = true;
			}
		}

		public static int FVQdlgjkDKPczoWxfrGcMASwKbrP(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, nqFAqQygbeqywhAOyhuthDgdnaAoA P_1)
		{
			if (P_0.FcpuYSwXEfDYJFuHSEgkmwBcxhGy < P_1.FcpuYSwXEfDYJFuHSEgkmwBcxhGy)
			{
				return -1;
			}
			if (P_0.FcpuYSwXEfDYJFuHSEgkmwBcxhGy > P_1.FcpuYSwXEfDYJFuHSEgkmwBcxhGy)
			{
				return 1;
			}
			return 0;
		}

		public static int ISJMvfPqrVbhNbziVvoNSucpTDDdA(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, nqFAqQygbeqywhAOyhuthDgdnaAoA P_1)
		{
			if (P_0.xSuHQANYINRgYnplhhObFnfWzpufA < P_1.xSuHQANYINRgYnplhhObFnfWzpufA)
			{
				return -1;
			}
			if (P_0.xSuHQANYINRgYnplhhObFnfWzpufA > P_1.xSuHQANYINRgYnplhhObFnfWzpufA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class ReBnoCzovtmizBMHRusURLLeIIei
	{
		public enum xpKlwIVYZsQvNLBSRbHQGiGaXRPq
		{
			Exact = 0,
			Approximate = 1
		}

		public class lvDDaMfGMPyJoDiwEmgusrAboZfgb
		{
			public int UPVXZMljvZXxcEScRdLTdbokAcyA;

			public Guid SOmQIbbALpHUjrfKmIJGmkbbQDIn;

			public Guid nCwciuifWLEVdkIjpcicUqLpmgSqA;

			public int axiCXzTwNgnZJYAjWjyOhSgxTAHpA;

			public int FBcNljUdbqoWqjqAzuKEUTyztORc;

			public int bIlNjLiHEvRKtaMOTKQUxnXoaFRdA;

			public int gSyyfmuHqcOhLPAosmfwuBHgZdJx;

			public int GpKIxGRxFUqGbPAEzAzFjINAjKPdA;

			public int fvpThVKPRNvRIlQSYoVVVkkAjgUR;

			public bool HVltPgwzhmolcSsPTXODxBOsqqyh;

			public bool PldXTLsEdnDHUDVmvURAKAcsTJBc(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, xpKlwIVYZsQvNLBSRbHQGiGaXRPq P_1)
			{
				if (FBcNljUdbqoWqjqAzuKEUTyztORc != P_0.rjhQAVSaVJqRuSbbtfkxRkURhjnW)
				{
					return false;
				}
				if (bIlNjLiHEvRKtaMOTKQUxnXoaFRdA != P_0.CbpfBnityVVJYxsssSDnjxpmPJVq)
				{
					return false;
				}
				if (gSyyfmuHqcOhLPAosmfwuBHgZdJx != P_0.CpplwqMPNHkNSjXWuGkrCagaeghP)
				{
					return false;
				}
				if (GpKIxGRxFUqGbPAEzAzFjINAjKPdA != P_0.MLKYPeozmRWMCHMpFBzuNslwXByh)
				{
					return false;
				}
				if (fvpThVKPRNvRIlQSYoVVVkkAjgUR != P_0.UhvkXWIUyDbMnBggXGawaGPoJCkEb)
				{
					return false;
				}
				if (HVltPgwzhmolcSsPTXODxBOsqqyh != P_0.sYpEazATeYXsMSaHdpjefXKGiHihb)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == UPVXZMljvZXxcEScRdLTdbokAcyA)
				{
					return true;
				}
				return P_1 switch
				{
					xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Exact => SOmQIbbALpHUjrfKmIJGmkbbQDIn == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Approximate => nCwciuifWLEVdkIjpcicUqLpmgSqA == P_0.JrdeLnnqbZyuOohWchZBvhjofLdm, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string mEaCjjqnJVKSVotRnBVZDMViZBcN()
			{
				string text = "" + "rewiredId = " + UPVXZMljvZXxcEScRdLTdbokAcyA + "\n";
				Guid sOmQIbbALpHUjrfKmIJGmkbbQDIn = SOmQIbbALpHUjrfKmIJGmkbbQDIn;
				string text2 = text + "instanceGuid = " + sOmQIbbALpHUjrfKmIJGmkbbQDIn.ToString() + "\n";
				sOmQIbbALpHUjrfKmIJGmkbbQDIn = nCwciuifWLEVdkIjpcicUqLpmgSqA;
				return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + sOmQIbbALpHUjrfKmIJGmkbbQDIn.ToString() + "\n", "lastInputManagerId = ", axiCXzTwNgnZJYAjWjyOhSgxTAHpA.ToString(), "\n"), "hardwareAxisCount = ", FBcNljUdbqoWqjqAzuKEUTyztORc.ToString(), "\n"), "hardwareButtonCount = ", bIlNjLiHEvRKtaMOTKQUxnXoaFRdA.ToString(), "\n"), "hardwareHatCount = ", gSyyfmuHqcOhLPAosmfwuBHgZdJx.ToString(), "\n"), "gameButtonCount = ", GpKIxGRxFUqGbPAEzAzFjINAjKPdA.ToString(), "\n"), "gameAxisCount = ", fvpThVKPRNvRIlQSYoVVVkkAjgUR.ToString(), "\n"), "hasDriver = ", HVltPgwzhmolcSsPTXODxBOsqqyh.ToString(), "\n");
			}
		}

		private sealed class juTTeHTKhUYMvNDMGFQkGUsSStXu : IEnumerable<lvDDaMfGMPyJoDiwEmgusrAboZfgb>, IEnumerable, IEnumerator<lvDDaMfGMPyJoDiwEmgusrAboZfgb>, IEnumerator, IDisposable
		{
			private int JjrEBZiSBToXezUdiHMlyawlKGRk;

			private lvDDaMfGMPyJoDiwEmgusrAboZfgb memlRDNuhNGlzZJRepVuhpFaCJQCA;

			private int IaaquGtzZXcPRXbsEDQgzpmbXtft;

			public ReBnoCzovtmizBMHRusURLLeIIei jZiFtxJKNpQNIUUSqHNNSiqoLbrib;

			private nqFAqQygbeqywhAOyhuthDgdnaAoA PCSCRenMTyBfdhGsdBsUNXanosqW;

			public nqFAqQygbeqywhAOyhuthDgdnaAoA vEHvaxFkgJJHiuDGxuSKOwdJutcr;

			private xpKlwIVYZsQvNLBSRbHQGiGaXRPq SvcZfDqsDxYRhtMkJGAILGDvecsf;

			public xpKlwIVYZsQvNLBSRbHQGiGaXRPq fwPdJAjGFebzNYUpUeJEMiPsrjTVA;

			private int wcDismBWNcXNmObzKecYiaeobCzSA;

			private int CafxrQGoJDdYAGmMtEgmPAeKjTUd;

			lvDDaMfGMPyJoDiwEmgusrAboZfgb IEnumerator<lvDDaMfGMPyJoDiwEmgusrAboZfgb>.Current
			{
				[DebuggerHidden]
				get
				{
					return memlRDNuhNGlzZJRepVuhpFaCJQCA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return memlRDNuhNGlzZJRepVuhpFaCJQCA;
				}
			}

			[DebuggerHidden]
			public juTTeHTKhUYMvNDMGFQkGUsSStXu(int P_0)
			{
				JjrEBZiSBToXezUdiHMlyawlKGRk = P_0;
				IaaquGtzZXcPRXbsEDQgzpmbXtft = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int jjrEBZiSBToXezUdiHMlyawlKGRk = JjrEBZiSBToXezUdiHMlyawlKGRk;
				ReBnoCzovtmizBMHRusURLLeIIei reBnoCzovtmizBMHRusURLLeIIei = jZiFtxJKNpQNIUUSqHNNSiqoLbrib;
				if (jjrEBZiSBToXezUdiHMlyawlKGRk != 0)
				{
					if (jjrEBZiSBToXezUdiHMlyawlKGRk != 1)
					{
						return false;
					}
					JjrEBZiSBToXezUdiHMlyawlKGRk = -1;
					goto IL_0083;
				}
				JjrEBZiSBToXezUdiHMlyawlKGRk = -1;
				wcDismBWNcXNmObzKecYiaeobCzSA = reBnoCzovtmizBMHRusURLLeIIei.QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count;
				CafxrQGoJDdYAGmMtEgmPAeKjTUd = 0;
				goto IL_0093;
				IL_0083:
				CafxrQGoJDdYAGmMtEgmPAeKjTUd++;
				goto IL_0093;
				IL_0093:
				if (CafxrQGoJDdYAGmMtEgmPAeKjTUd < wcDismBWNcXNmObzKecYiaeobCzSA)
				{
					if (reBnoCzovtmizBMHRusURLLeIIei.QLmUmrcGLNeRoAzYheAhmcdeoxpF[CafxrQGoJDdYAGmMtEgmPAeKjTUd].PldXTLsEdnDHUDVmvURAKAcsTJBc(PCSCRenMTyBfdhGsdBsUNXanosqW, SvcZfDqsDxYRhtMkJGAILGDvecsf))
					{
						memlRDNuhNGlzZJRepVuhpFaCJQCA = reBnoCzovtmizBMHRusURLLeIIei.QLmUmrcGLNeRoAzYheAhmcdeoxpF[CafxrQGoJDdYAGmMtEgmPAeKjTUd];
						JjrEBZiSBToXezUdiHMlyawlKGRk = 1;
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
			IEnumerator<lvDDaMfGMPyJoDiwEmgusrAboZfgb> IEnumerable<lvDDaMfGMPyJoDiwEmgusrAboZfgb>.GetEnumerator()
			{
				juTTeHTKhUYMvNDMGFQkGUsSStXu juTTeHTKhUYMvNDMGFQkGUsSStXu2;
				if (JjrEBZiSBToXezUdiHMlyawlKGRk == -2 && IaaquGtzZXcPRXbsEDQgzpmbXtft == Environment.CurrentManagedThreadId)
				{
					JjrEBZiSBToXezUdiHMlyawlKGRk = 0;
					juTTeHTKhUYMvNDMGFQkGUsSStXu2 = this;
				}
				else
				{
					juTTeHTKhUYMvNDMGFQkGUsSStXu2 = new juTTeHTKhUYMvNDMGFQkGUsSStXu(0);
					juTTeHTKhUYMvNDMGFQkGUsSStXu2.jZiFtxJKNpQNIUUSqHNNSiqoLbrib = jZiFtxJKNpQNIUUSqHNNSiqoLbrib;
				}
				juTTeHTKhUYMvNDMGFQkGUsSStXu2.PCSCRenMTyBfdhGsdBsUNXanosqW = vEHvaxFkgJJHiuDGxuSKOwdJutcr;
				juTTeHTKhUYMvNDMGFQkGUsSStXu2.SvcZfDqsDxYRhtMkJGAILGDvecsf = fwPdJAjGFebzNYUpUeJEMiPsrjTVA;
				return juTTeHTKhUYMvNDMGFQkGUsSStXu2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<lvDDaMfGMPyJoDiwEmgusrAboZfgb>)this).GetEnumerator();
			}
		}

		private List<lvDDaMfGMPyJoDiwEmgusrAboZfgb> QLmUmrcGLNeRoAzYheAhmcdeoxpF;

		public ReBnoCzovtmizBMHRusURLLeIIei()
		{
			QLmUmrcGLNeRoAzYheAhmcdeoxpF = new List<lvDDaMfGMPyJoDiwEmgusrAboZfgb>();
		}

		public void fkWNZelUHQtxiZTkFZcVDjQjBGqL(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count;
			for (int i = 0; i < count; i++)
			{
				if (QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].PldXTLsEdnDHUDVmvURAKAcsTJBc(P_0, xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Exact))
				{
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].UPVXZMljvZXxcEScRdLTdbokAcyA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].SOmQIbbALpHUjrfKmIJGmkbbQDIn = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].nCwciuifWLEVdkIjpcicUqLpmgSqA = P_0.JrdeLnnqbZyuOohWchZBvhjofLdm;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].axiCXzTwNgnZJYAjWjyOhSgxTAHpA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].FBcNljUdbqoWqjqAzuKEUTyztORc = P_0.rjhQAVSaVJqRuSbbtfkxRkURhjnW;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].bIlNjLiHEvRKtaMOTKQUxnXoaFRdA = P_0.CbpfBnityVVJYxsssSDnjxpmPJVq;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].gSyyfmuHqcOhLPAosmfwuBHgZdJx = P_0.CpplwqMPNHkNSjXWuGkrCagaeghP;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].GpKIxGRxFUqGbPAEzAzFjINAjKPdA = P_0.MLKYPeozmRWMCHMpFBzuNslwXByh;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].fvpThVKPRNvRIlQSYoVVVkkAjgUR = P_0.UhvkXWIUyDbMnBggXGawaGPoJCkEb;
					QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].HVltPgwzhmolcSsPTXODxBOsqqyh = P_0.sYpEazATeYXsMSaHdpjefXKGiHihb;
					QuBKdGNdrimFcgVzTlNTBKXBPXxv(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			QLmUmrcGLNeRoAzYheAhmcdeoxpF.Add(new lvDDaMfGMPyJoDiwEmgusrAboZfgb
			{
				UPVXZMljvZXxcEScRdLTdbokAcyA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				SOmQIbbALpHUjrfKmIJGmkbbQDIn = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				nCwciuifWLEVdkIjpcicUqLpmgSqA = P_0.JrdeLnnqbZyuOohWchZBvhjofLdm,
				axiCXzTwNgnZJYAjWjyOhSgxTAHpA = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				FBcNljUdbqoWqjqAzuKEUTyztORc = P_0.rjhQAVSaVJqRuSbbtfkxRkURhjnW,
				bIlNjLiHEvRKtaMOTKQUxnXoaFRdA = P_0.CbpfBnityVVJYxsssSDnjxpmPJVq,
				gSyyfmuHqcOhLPAosmfwuBHgZdJx = P_0.CpplwqMPNHkNSjXWuGkrCagaeghP,
				GpKIxGRxFUqGbPAEzAzFjINAjKPdA = P_0.MLKYPeozmRWMCHMpFBzuNslwXByh,
				fvpThVKPRNvRIlQSYoVVVkkAjgUR = P_0.UhvkXWIUyDbMnBggXGawaGPoJCkEb,
				HVltPgwzhmolcSsPTXODxBOsqqyh = P_0.sYpEazATeYXsMSaHdpjefXKGiHihb
			});
			QuBKdGNdrimFcgVzTlNTBKXBPXxv(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count - 1);
		}

		public bool QIjTxsscFqlkEeGYlJfbSLkrbtAAA(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, xpKlwIVYZsQvNLBSRbHQGiGaXRPq P_1)
		{
			int count = QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count;
			for (int i = 0; i < count; i++)
			{
				if (QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].PldXTLsEdnDHUDVmvURAKAcsTJBc(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(juTTeHTKhUYMvNDMGFQkGUsSStXu))]
		public IEnumerable<lvDDaMfGMPyJoDiwEmgusrAboZfgb> oObZoBYyIWhmVrKYKJPPXZclxHlg(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, xpKlwIVYZsQvNLBSRbHQGiGaXRPq P_1)
		{
			return new juTTeHTKhUYMvNDMGFQkGUsSStXu(-2)
			{
				jZiFtxJKNpQNIUUSqHNNSiqoLbrib = this,
				vEHvaxFkgJJHiuDGxuSKOwdJutcr = P_0,
				fwPdJAjGFebzNYUpUeJEMiPsrjTVA = P_1
			};
		}

		private void QuBKdGNdrimFcgVzTlNTBKXBPXxv(int P_0, Guid P_1, int P_2)
		{
			for (int num = QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (QLmUmrcGLNeRoAzYheAhmcdeoxpF[num].UPVXZMljvZXxcEScRdLTdbokAcyA == P_0 || QLmUmrcGLNeRoAzYheAhmcdeoxpF[num].SOmQIbbALpHUjrfKmIJGmkbbQDIn == P_1))
				{
					QLmUmrcGLNeRoAzYheAhmcdeoxpF.RemoveAt(num);
				}
			}
		}

		public virtual string FOQivTainYLRjWkMedhxIwnHnksMA()
		{
			string text = "";
			text = text + "Joystick records: " + QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count + "\n";
			for (int i = 0; i < QLmUmrcGLNeRoAzYheAhmcdeoxpF.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + QLmUmrcGLNeRoAzYheAhmcdeoxpF[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private TLpaAyfjQfVEHNKGQCySwHFUzfaqA GKvljIXlReLSmmuckEhPgqjpQQdJ;

	private List<nqFAqQygbeqywhAOyhuthDgdnaAoA> CAdSloyrQnTvPCsLtgtRCVcktisP;

	private int lJbURHJGhQGeEyXklhhPBEAQUklkA;

	private ReBnoCzovtmizBMHRusURLLeIIei uEsyZcDUaFYRCxFoyBwMdLbEpRLk;

	private bool RPTJcJSBcVCQhGqNnLvZPXkNeaKh;

	private TimerRealTime eCJARhmSJFqDOMhqtXEWgwSyhREY;

	private global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool> gdSbOYitUSWfozNysTbjANeCJlQx;

	private global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool> qgAzkqWjhjxoUmlUkuyVDEhfIBsk;

	private int eTNCusPGhCGJEIltKgykAIiDMomhB;

	private int krbLBkShCkRqXRBFbYTIPELjbnf;

	private ConfigVars DrhGEOAMhvgDEwIWvVqOMEbBvkCxA;

	private MpfSAJjorzYIlCIHNIPpIhZKdISt xFpBBHsfNFCaPjpXGwPKgyDLcRRiA;

	private Action<int, ControllerDataUpdater> KXaNrVaVsuUybbwmKkJPyLvKbNWg;

	private PlatformInputManager MAjBRfChEFdSaCwMDBRlzfrInncw;

	private readonly mlvCsDdsydRaeUudGGZWhwEDLnMp HYOsVtPegKGuCWPnuaasLNlKvbRl;

	private readonly cGPocQCmpifoVjikWsVbIMPLJBydb PshUJWvkjdIZhvuRalDVakfPUuLJ;

	private readonly bool XsKgUhznzXAnlOGrBwcbwmrXNmYE;

	private readonly bool eRpDZoiECOlgHDRVPPpsBccIOTZfc;

	private readonly bool dGKlGfPtcRaoTMDgArprnlRIXIJB;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> AXfSPlcrWRzrliXaVDBnZFQOBjsr;

	private readonly Func<int> ufKpGqeOpOgwFOiomIgyYdFoYuhu;

	MpfSAJjorzYIlCIHNIPpIhZKdISt WcLOVIVVtbKfXzBpbdfQnbxdxBNU.DWTeVmUMIVxWjJIJYcGdVrdyhSFu
	{
		get
		{
			return xFpBBHsfNFCaPjpXGwPKgyDLcRRiA;
		}
		set
		{
			DWTeVmUMIVxWjJIJYcGdVrdyhSFu = mpfSAJjorzYIlCIHNIPpIhZKdISt;
			GKvljIXlReLSmmuckEhPgqjpQQdJ.BkQSIBOhkfVYlUtGLHOVxOArNuWq = mpfSAJjorzYIlCIHNIPpIhZKdISt;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => lJbURHJGhQGeEyXklhhPBEAQUklkA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => MAjBRfChEFdSaCwMDBRlzfrInncw;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => GKvljIXlReLSmmuckEhPgqjpQQdJ;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.RawInput;

	public dJgkOkKFuKUDgFbGQdAHAkRKhOSf(ConfigVars P_0, MpfSAJjorzYIlCIHNIPpIhZKdISt P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, bool P_4, bool P_5, bool P_6, bool P_7)
	{
		try
		{
			DrhGEOAMhvgDEwIWvVqOMEbBvkCxA = P_0;
			xFpBBHsfNFCaPjpXGwPKgyDLcRRiA = P_1;
			AXfSPlcrWRzrliXaVDBnZFQOBjsr = P_2;
			ufKpGqeOpOgwFOiomIgyYdFoYuhu = P_3;
			XsKgUhznzXAnlOGrBwcbwmrXNmYE = P_4;
			eRpDZoiECOlgHDRVPPpsBccIOTZfc = P_5;
			dGKlGfPtcRaoTMDgArprnlRIXIJB = P_6;
			MAjBRfChEFdSaCwMDBRlzfrInncw = this;
			UpdateLoopSetting updateLoop = P_0.updateLoop;
			if (P_6)
			{
				PshUJWvkjdIZhvuRalDVakfPUuLJ = new cGPocQCmpifoVjikWsVbIMPLJBydb(updateLoop);
			}
			if (P_5)
			{
				HYOsVtPegKGuCWPnuaasLNlKvbRl = new mlvCsDdsydRaeUudGGZWhwEDLnMp(updateLoop);
			}
			GKvljIXlReLSmmuckEhPgqjpQQdJ = new TLpaAyfjQfVEHNKGQCySwHFUzfaqA(P_0, P_1, P_4, P_7, HYOsVtPegKGuCWPnuaasLNlKvbRl, PshUJWvkjdIZhvuRalDVakfPUuLJ);
			KXaNrVaVsuUybbwmKkJPyLvKbNWg = UpdateControllerData;
			gdSbOYitUSWfozNysTbjANeCJlQx = new global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool>(true, sVMrofZIvRESKtGpTvvmFxqPrBpP);
			qgAzkqWjhjxoUmlUkuyVDEhfIBsk = new global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool>(true, GKvljIXlReLSmmuckEhPgqjpQQdJ.ORSfsFUMDmOfghtmQQOOaeQbcXcL);
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
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			uEsyZcDUaFYRCxFoyBwMdLbEpRLk = new ReBnoCzovtmizBMHRusURLLeIIei();
			eCJARhmSJFqDOMhqtXEWgwSyhREY = new TimerRealTime(1.0);
			eCJARhmSJFqDOMhqtXEWgwSyhREY.Start();
			iewdJyRnkYzmoAqlJqaxYiUJqKpi();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			TPuFXxHfMfcvHCnyYmItzWbkeHCaA();
		}
		if (GKvljIXlReLSmmuckEhPgqjpQQdJ != null)
		{
			GKvljIXlReLSmmuckEhPgqjpQQdJ.Update();
		}
		suyZbPJEMASsdsxSjfEKGaNCRtbG();
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			if (GKvljIXlReLSmmuckEhPgqjpQQdJ != null)
			{
				GKvljIXlReLSmmuckEhPgqjpQQdJ.UpdateDevices(updateLoop);
			}
			GAgdNWiiqbbmnTcHSdGCFnDrEruZA();
			if (GKvljIXlReLSmmuckEhPgqjpQQdJ != null)
			{
				GKvljIXlReLSmmuckEhPgqjpQQdJ.UpdateFinished();
			}
		}
		if (eRpDZoiECOlgHDRVPPpsBccIOTZfc)
		{
			HYOsVtPegKGuCWPnuaasLNlKvbRl.kEpvxCuYaJEVVhZJGfDXhDNFikcs(updateLoop);
		}
		if (dGKlGfPtcRaoTMDgArprnlRIXIJB)
		{
			PshUJWvkjdIZhvuRalDVakfPUuLJ.KLlgDTtlmwmaJGHpXjFvGSQCeoKy(updateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (qgAzkqWjhjxoUmlUkuyVDEhfIBsk != null)
		{
			qgAzkqWjhjxoUmlUkuyVDEhfIBsk.FBethkzoPOdpxwrHTNdcWabofFyD();
		}
		if (gdSbOYitUSWfozNysTbjANeCJlQx != null)
		{
			gdSbOYitUSWfozNysTbjANeCJlQx.FBethkzoPOdpxwrHTNdcWabofFyD();
		}
		if (CAdSloyrQnTvPCsLtgtRCVcktisP != null)
		{
			int count = CAdSloyrQnTvPCsLtgtRCVcktisP.Count;
			for (int i = 0; i < count; i++)
			{
				if (CAdSloyrQnTvPCsLtgtRCVcktisP[i] != null)
				{
					CAdSloyrQnTvPCsLtgtRCVcktisP[i].qFndkxoSdEDzpOKvYxDWbNTEFbwB();
				}
			}
		}
		if (PshUJWvkjdIZhvuRalDVakfPUuLJ != null)
		{
			PshUJWvkjdIZhvuRalDVakfPUuLJ.Dispose();
		}
		if (HYOsVtPegKGuCWPnuaasLNlKvbRl != null)
		{
			HYOsVtPegKGuCWPnuaasLNlKvbRl.Dispose();
		}
		if (GKvljIXlReLSmmuckEhPgqjpQQdJ != null)
		{
			GKvljIXlReLSmmuckEhPgqjpQQdJ.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return KXaNrVaVsuUybbwmKkJPyLvKbNWg;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			return;
		}
		for (int i = 0; i < lJbURHJGhQGeEyXklhhPBEAQUklkA; i++)
		{
			if (CAdSloyrQnTvPCsLtgtRCVcktisP[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				CAdSloyrQnTvPCsLtgtRCVcktisP[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		GKvljIXlReLSmmuckEhPgqjpQQdJ.SystemDeviceConnected();
		RPTJcJSBcVCQhGqNnLvZPXkNeaKh = true;
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			eCJARhmSJFqDOMhqtXEWgwSyhREY.Start();
		}
		if (dGKlGfPtcRaoTMDgArprnlRIXIJB)
		{
			PshUJWvkjdIZhvuRalDVakfPUuLJ.lFnHrDAvzMADozJLZlrnlHFimKubb(true);
		}
		if (eRpDZoiECOlgHDRVPPpsBccIOTZfc)
		{
			HYOsVtPegKGuCWPnuaasLNlKvbRl.sNYRcMxyjxUfMpUCybRYsaYXbUOQ(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		GKvljIXlReLSmmuckEhPgqjpQQdJ.SystemDeviceDisconnected();
		RPTJcJSBcVCQhGqNnLvZPXkNeaKh = true;
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			eCJARhmSJFqDOMhqtXEWgwSyhREY.Start();
		}
		if (dGKlGfPtcRaoTMDgArprnlRIXIJB)
		{
			PshUJWvkjdIZhvuRalDVakfPUuLJ.lFnHrDAvzMADozJLZlrnlHFimKubb(false);
		}
		if (eRpDZoiECOlgHDRVPPpsBccIOTZfc)
		{
			HYOsVtPegKGuCWPnuaasLNlKvbRl.sNYRcMxyjxUfMpUCybRYsaYXbUOQ(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = XsKgUhznzXAnlOGrBwcbwmrXNmYE;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return HYOsVtPegKGuCWPnuaasLNlKvbRl;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return PshUJWvkjdIZhvuRalDVakfPUuLJ;
	}

	public void WAjlddwrRunmDtDsyKjaifSgJaQp(UXQgNkKlFfsqcUANDOwHwGUYTczaA P_0, aOtkKhGbkEdIeqbhfwkPvpQtfykp P_1)
	{
	}

	private void TPuFXxHfMfcvHCnyYmItzWbkeHCaA()
	{
		if (gdSbOYitUSWfozNysTbjANeCJlQx.IjDAOhjnupbeicWoJQcuMwlCNKJq)
		{
			if (gdSbOYitUSWfozNysTbjANeCJlQx.IChbtFqxyAxpsLDDmkASsVKzMoVs() && !eCJARhmSJFqDOMhqtXEWgwSyhREY.running && !qgAzkqWjhjxoUmlUkuyVDEhfIBsk.IjDAOhjnupbeicWoJQcuMwlCNKJq)
			{
				if (gdSbOYitUSWfozNysTbjANeCJlQx.UYndadRIHdtACtFVjQfssImkfgZcA)
				{
					RPTJcJSBcVCQhGqNnLvZPXkNeaKh = true;
				}
				eCJARhmSJFqDOMhqtXEWgwSyhREY.Start();
			}
		}
		else if (!eCJARhmSJFqDOMhqtXEWgwSyhREY.running)
		{
			eCJARhmSJFqDOMhqtXEWgwSyhREY.Start();
		}
		else if (eCJARhmSJFqDOMhqtXEWgwSyhREY.Update())
		{
			gdSbOYitUSWfozNysTbjANeCJlQx.icnDcGzVOnAmxAhayFIDZrxYnhvMA();
		}
	}

	private void iewdJyRnkYzmoAqlJqaxYiUJqKpi()
	{
		kTshzjmuMJpxvxWDPOAODOvMfXTEA(LhgGFLRSIxIPYdbYWvagVZDhiekNA());
	}

	private void kTshzjmuMJpxvxWDPOAODOvMfXTEA(IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> P_0)
	{
		int num = 0;
		List<nqFAqQygbeqywhAOyhuthDgdnaAoA> cAdSloyrQnTvPCsLtgtRCVcktisP = CAdSloyrQnTvPCsLtgtRCVcktisP;
		int num2 = lJbURHJGhQGeEyXklhhPBEAQUklkA;
		CAdSloyrQnTvPCsLtgtRCVcktisP = new List<nqFAqQygbeqywhAOyhuthDgdnaAoA>();
		eTNCusPGhCGJEIltKgykAIiDMomhB = 0;
		List<nqFAqQygbeqywhAOyhuthDgdnaAoA> list = new List<nqFAqQygbeqywhAOyhuthDgdnaAoA>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (cAdSloyrQnTvPCsLtgtRCVcktisP[num3] != null && !cAdSloyrQnTvPCsLtgtRCVcktisP[num3].AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				list.Add(cAdSloyrQnTvPCsLtgtRCVcktisP[num3]);
				cAdSloyrQnTvPCsLtgtRCVcktisP.RemoveAt(num3);
			}
		}
		num2 = cAdSloyrQnTvPCsLtgtRCVcktisP?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			OzySGGBmBYhYxgwfTlyHImbOUOXkA ozySGGBmBYhYxgwfTlyHImbOUOXkA = P_0[i];
			if (ozySGGBmBYhYxgwfTlyHImbOUOXkA != null)
			{
				nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = new nqFAqQygbeqywhAOyhuthDgdnaAoA(ozySGGBmBYhYxgwfTlyHImbOUOXkA, ozySGGBmBYhYxgwfTlyHImbOUOXkA.qpTuqoVyPHjOpAAoABLJbutlJrPG, AXfSPlcrWRzrliXaVDBnZFQOBjsr);
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.zNKRQcqwTerrbYGHqczUnSOLRhWs = ozySGGBmBYhYxgwfTlyHImbOUOXkA.nsyavkgcgbuRFXdlgcChhxcpfICc;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.SNFNRGZEsiuOwlPKEHwrDGMqmyToA = ozySGGBmBYhYxgwfTlyHImbOUOXkA.XxyuMkMmhKoIInyRDWsCmtKGdgHA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.qjrSCvKbsQClTNlntTnqJjADMlKj = ozySGGBmBYhYxgwfTlyHImbOUOXkA.XxyuMkMmhKoIInyRDWsCmtKGdgHA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.BUlOJQImYTAbJlJepatPFBRcMLmh = ozySGGBmBYhYxgwfTlyHImbOUOXkA.reWXjJyHHSNMukjgXBpwrUuUBMeJA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.XkcbTPUYyfsysBFMFTjdoipwaPjc = ozySGGBmBYhYxgwfTlyHImbOUOXkA.HUvbaPYWVHzaxnHiJXMScbcOrkSC;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.CrZGrYpIBEhtKBkeHoZGcLYvXTXdb = ozySGGBmBYhYxgwfTlyHImbOUOXkA.FPpDVFqxOBHVOBsaIxIwdAOjqEkzA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.xSuHQANYINRgYnplhhObFnfWzpufA = ozySGGBmBYhYxgwfTlyHImbOUOXkA.RnZPCfjgzLCeiurmkDVAlkChniu;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.rjhQAVSaVJqRuSbbtfkxRkURhjnW = ozySGGBmBYhYxgwfTlyHImbOUOXkA.sLBGBBvNdfCmXzXTXupKenKTeLpEA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.CbpfBnityVVJYxsssSDnjxpmPJVq = ozySGGBmBYhYxgwfTlyHImbOUOXkA.UWMmOITifkPGgSIqTnqobHtqhqIC;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.CpplwqMPNHkNSjXWuGkrCagaeghP = ozySGGBmBYhYxgwfTlyHImbOUOXkA.gkfgipYbCVtOctmsVuhoVRGUdEpp;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.CvrcQOtdMZkKfvNnrtCDddABVOin = false;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.SVYTluhYGFBfbrvSeckcwhtqNzIE = ozySGGBmBYhYxgwfTlyHImbOUOXkA.NifCQRRuHIWBzkmqZsWwxbpaExFX;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.PWNaLDZImUzuWpehueQkofTNyFfX = ozySGGBmBYhYxgwfTlyHImbOUOXkA.GnJPWfnpLSjeStgIxhadEXfgmXOY;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.dbekTUUJjmVfnAIZCAbIAHYbJiQT = ozySGGBmBYhYxgwfTlyHImbOUOXkA.xqsCPkCwAtTzNQDIlcBmxRJPeGHPA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.DeraddMmJOhMYtmtAWWKgIlTUKaN = ozySGGBmBYhYxgwfTlyHImbOUOXkA.MmgaNUokBZAcGcuufaJQcNGKLWJpA;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = ozySGGBmBYhYxgwfTlyHImbOUOXkA.lFhahZCrEFVLaPiaESzPxJOzUvYn;
				ozySGGBmBYhYxgwfTlyHImbOUOXkA.bHXoMueoAGhhLFPCEawLezHslAnxA();
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.maMcVQcOWYriWjoCdlBWLhmYRZMA();
				CAdSloyrQnTvPCsLtgtRCVcktisP.Add(nqFAqQygbeqywhAOyhuthDgdnaAoA2);
				num++;
				if (nqFAqQygbeqywhAOyhuthDgdnaAoA2.SVYTluhYGFBfbrvSeckcwhtqNzIE)
				{
					eTNCusPGhCGJEIltKgykAIiDMomhB++;
				}
			}
		}
		lJbURHJGhQGeEyXklhhPBEAQUklkA = num;
		QdDrosyMPCjTBGQjCzNouWuCkgJo(num2, num, cAdSloyrQnTvPCsLtgtRCVcktisP, CAdSloyrQnTvPCsLtgtRCVcktisP);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(CAdSloyrQnTvPCsLtgtRCVcktisP[j]));
			}
		}
		list.ForEach(delegate(nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA3)
		{
			vcfiHlUamPovdkPIJjTUJhpVerVKA(nqFAqQygbeqywhAOyhuthDgdnaAoA3, false);
		});
		DdCIIGpcweQUgnNrAjgualfLiKBS(cAdSloyrQnTvPCsLtgtRCVcktisP, CAdSloyrQnTvPCsLtgtRCVcktisP, false);
		DdCIIGpcweQUgnNrAjgualfLiKBS(CAdSloyrQnTvPCsLtgtRCVcktisP, cAdSloyrQnTvPCsLtgtRCVcktisP, true);
	}

	private void GAgdNWiiqbbmnTcHSdGCFnDrEruZA()
	{
		for (int i = 0; i < lJbURHJGhQGeEyXklhhPBEAQUklkA; i++)
		{
			nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = CAdSloyrQnTvPCsLtgtRCVcktisP[i];
			if (nqFAqQygbeqywhAOyhuthDgdnaAoA2 != null && (xFpBBHsfNFCaPjpXGwPKgyDLcRRiA == null || !nqFAqQygbeqywhAOyhuthDgdnaAoA2.CvrcQOtdMZkKfvNnrtCDddABVOin))
			{
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Update();
			}
		}
	}

	private bool EhuteOQDbJixiIgwWjUvESXmkoID(rPWbtqpFqHvHspyNofWArNMflbSQ P_0)
	{
		try
		{
			return P_0.GOgsZmTvAHhRsdOUsEmMiVFhhnKgA();
		}
		catch
		{
			return false;
		}
	}

	private IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> LhgGFLRSIxIPYdbYWvagVZDhiekNA()
	{
		return GKvljIXlReLSmmuckEhPgqjpQQdJ.GetJoysticks<OzySGGBmBYhYxgwfTlyHImbOUOXkA>();
	}

	private void QdDrosyMPCjTBGQjCzNouWuCkgJo(int P_0, int P_1, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_2, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(nqFAqQygbeqywhAOyhuthDgdnaAoA.ISJMvfPqrVbhNbziVvoNSucpTDDdA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			QlHbQVGzQiRLveSldoacaCHaetsSB(P_1, P_3, P_0, P_2, ReBnoCzovtmizBMHRusURLLeIIei.xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Exact);
		}
		USRVxcijhwzARtvYWibkGqguFWvb(P_1, P_3, ReBnoCzovtmizBMHRusURLLeIIei.xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Exact);
		for (int i = 0; i < P_1; i++)
		{
			nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = P_3[i];
			if (nqFAqQygbeqywhAOyhuthDgdnaAoA2 != null && nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = IpdxqPuUtromBkjnfFukwiedxGCR(P_3);
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ufKpGqeOpOgwFOiomIgyYdFoYuhu();
				uEsyZcDUaFYRCxFoyBwMdLbEpRLk.fkWNZelUHQtxiZTkFZcVDjQjBGqL(nqFAqQygbeqywhAOyhuthDgdnaAoA2);
			}
		}
		P_3.Sort(nqFAqQygbeqywhAOyhuthDgdnaAoA.FVQdlgjkDKPczoWxfrGcMASwKbrP);
	}

	private void WDaIdFEKOXYWEfUNlmezUPamnbtW(List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_0, int P_1, int P_2)
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

	private bool HJOpUMNOHHMLyZQumPYOGVyLrzGl(List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_0, int P_1)
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

	private int IpdxqPuUtromBkjnfFukwiedxGCR(List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_0)
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

	private bool wrUZqaptgjXivshMPzEAogdNQFZb(List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_0, int P_1)
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

	private void QlHbQVGzQiRLveSldoacaCHaetsSB(int P_0, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_1, int P_2, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_3, ReBnoCzovtmizBMHRusURLLeIIei.xpKlwIVYZsQvNLBSRbHQGiGaXRPq P_4)
	{
		int num = ((P_4 != ReBnoCzovtmizBMHRusURLLeIIei.xpKlwIVYZsQvNLBSRbHQGiGaXRPq.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = P_1[i];
			if (nqFAqQygbeqywhAOyhuthDgdnaAoA2 == null || nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA3 = P_3[j];
				if (nqFAqQygbeqywhAOyhuthDgdnaAoA3 != null && !wrUZqaptgjXivshMPzEAogdNQFZb(P_1, nqFAqQygbeqywhAOyhuthDgdnaAoA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && nqFAqQygbeqywhAOyhuthDgdnaAoA2.oJZXzVOfmJWDAMPLCqzBEQTdpGHX(nqFAqQygbeqywhAOyhuthDgdnaAoA3) >= num)
				{
					nqFAqQygbeqywhAOyhuthDgdnaAoA2.dqCYkvpqpkfLjcYJRaSwhNRlxTrd(nqFAqQygbeqywhAOyhuthDgdnaAoA3);
					uEsyZcDUaFYRCxFoyBwMdLbEpRLk.fkWNZelUHQtxiZTkFZcVDjQjBGqL(nqFAqQygbeqywhAOyhuthDgdnaAoA2);
				}
			}
		}
	}

	private void USRVxcijhwzARtvYWibkGqguFWvb(int P_0, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_1, ReBnoCzovtmizBMHRusURLLeIIei.xpKlwIVYZsQvNLBSRbHQGiGaXRPq P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = P_1[i];
			if (nqFAqQygbeqywhAOyhuthDgdnaAoA2 == null || nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			ReBnoCzovtmizBMHRusURLLeIIei.lvDDaMfGMPyJoDiwEmgusrAboZfgb lvDDaMfGMPyJoDiwEmgusrAboZfgb = null;
			foreach (ReBnoCzovtmizBMHRusURLLeIIei.lvDDaMfGMPyJoDiwEmgusrAboZfgb item in uEsyZcDUaFYRCxFoyBwMdLbEpRLk.oObZoBYyIWhmVrKYKJPPXZclxHlg(nqFAqQygbeqywhAOyhuthDgdnaAoA2, P_2))
			{
				if (!wrUZqaptgjXivshMPzEAogdNQFZb(P_1, item.UPVXZMljvZXxcEScRdLTdbokAcyA) && item.axiCXzTwNgnZJYAjWjyOhSgxTAHpA >= 0)
				{
					lvDDaMfGMPyJoDiwEmgusrAboZfgb = item;
					break;
				}
			}
			if (lvDDaMfGMPyJoDiwEmgusrAboZfgb != null)
			{
				int num = lvDDaMfGMPyJoDiwEmgusrAboZfgb.axiCXzTwNgnZJYAjWjyOhSgxTAHpA;
				if (!HJOpUMNOHHMLyZQumPYOGVyLrzGl(P_1, num))
				{
					num = (lvDDaMfGMPyJoDiwEmgusrAboZfgb.axiCXzTwNgnZJYAjWjyOhSgxTAHpA = IpdxqPuUtromBkjnfFukwiedxGCR(P_1));
				}
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = lvDDaMfGMPyJoDiwEmgusrAboZfgb.UPVXZMljvZXxcEScRdLTdbokAcyA;
				uEsyZcDUaFYRCxFoyBwMdLbEpRLk.fkWNZelUHQtxiZTkFZcVDjQjBGqL(nqFAqQygbeqywhAOyhuthDgdnaAoA2);
			}
		}
	}

	private void suyZbPJEMASsdsxSjfEKGaNCRtbG()
	{
		if (GKvljIXlReLSmmuckEhPgqjpQQdJ.BrZbcADFRIcGtPqSMmktcYymKfsrA(true))
		{
			RPTJcJSBcVCQhGqNnLvZPXkNeaKh = true;
		}
		if (RPTJcJSBcVCQhGqNnLvZPXkNeaKh)
		{
			BfqkMGgoOcQLIVxLwjILJuoKzGIK();
		}
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE && qgAzkqWjhjxoUmlUkuyVDEhfIBsk.IjDAOhjnupbeicWoJQcuMwlCNKJq && qgAzkqWjhjxoUmlUkuyVDEhfIBsk.IChbtFqxyAxpsLDDmkASsVKzMoVs())
		{
			qwuSrFEehTobTzDIuvLzLbIKDSOU();
		}
	}

	private void BfqkMGgoOcQLIVxLwjILJuoKzGIK()
	{
		RPTJcJSBcVCQhGqNnLvZPXkNeaKh = false;
		if (!qgAzkqWjhjxoUmlUkuyVDEhfIBsk.IjDAOhjnupbeicWoJQcuMwlCNKJq)
		{
			GKvljIXlReLSmmuckEhPgqjpQQdJ.NXzaFcvLmEjqeYMUdsycUTEkgQJA();
			qgAzkqWjhjxoUmlUkuyVDEhfIBsk.icnDcGzVOnAmxAhayFIDZrxYnhvMA();
		}
	}

	private void qwuSrFEehTobTzDIuvLzLbIKDSOU()
	{
		GKvljIXlReLSmmuckEhPgqjpQQdJ.owIFMimRDfcQACdfFdbSgdmDqrshb();
		if (XsKgUhznzXAnlOGrBwcbwmrXNmYE)
		{
			IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> list = LhgGFLRSIxIPYdbYWvagVZDhiekNA();
			if (WbIFhIrbXiBIWDZUddViYyHxTdCN(list))
			{
				kTshzjmuMJpxvxWDPOAODOvMfXTEA(list);
			}
		}
	}

	private bool WbIFhIrbXiBIWDZUddViYyHxTdCN(IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> P_0)
	{
		for (int i = 0; i < CAdSloyrQnTvPCsLtgtRCVcktisP.Count; i++)
		{
			if (CAdSloyrQnTvPCsLtgtRCVcktisP[i] != null && !CAdSloyrQnTvPCsLtgtRCVcktisP[i].AUFStxkYdraklHuRbcjLxpGcSdoJ)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !EWTIVttyQqsQfOfUADqYTQMiKCPx(P_0[j].nsyavkgcgbuRFXdlgcChhxcpfICc))
			{
				return true;
			}
		}
		int count2 = CAdSloyrQnTvPCsLtgtRCVcktisP.Count;
		for (int k = 0; k < count2; k++)
		{
			if (CAdSloyrQnTvPCsLtgtRCVcktisP[k] != null && !MdddHwHSOqSTAkTwHicwjdmCtGihB(P_0, CAdSloyrQnTvPCsLtgtRCVcktisP[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	private bool EWTIVttyQqsQfOfUADqYTQMiKCPx(Guid P_0)
	{
		int count = CAdSloyrQnTvPCsLtgtRCVcktisP.Count;
		for (int i = 0; i < count; i++)
		{
			if (CAdSloyrQnTvPCsLtgtRCVcktisP[i] != null && CAdSloyrQnTvPCsLtgtRCVcktisP[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool MdddHwHSOqSTAkTwHicwjdmCtGihB(IList<OzySGGBmBYhYxgwfTlyHImbOUOXkA> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].nsyavkgcgbuRFXdlgcChhxcpfICc == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void DdCIIGpcweQUgnNrAjgualfLiKBS(List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_0, List<nqFAqQygbeqywhAOyhuthDgdnaAoA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA2 = P_0[i];
			if (nqFAqQygbeqywhAOyhuthDgdnaAoA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					nqFAqQygbeqywhAOyhuthDgdnaAoA nqFAqQygbeqywhAOyhuthDgdnaAoA3 = P_1[j];
					if (nqFAqQygbeqywhAOyhuthDgdnaAoA3 != null && nqFAqQygbeqywhAOyhuthDgdnaAoA2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == nqFAqQygbeqywhAOyhuthDgdnaAoA3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				vcfiHlUamPovdkPIJjTUJhpVerVKA(P_0[i], P_2);
			}
		}
	}

	private void vcfiHlUamPovdkPIJjTUJhpVerVKA(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0, bool P_1)
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

	private bool sVMrofZIvRESKtGpTvvmFxqPrBpP()
	{
		try
		{
			int num = 0;
			GIpFgoBUMndhxdBpEKDYQlhhhMuVA.WgsQFYjWinUUzHufsPRtzSRJCtBo(null, ref num, qEhGRKCBLVdeTteVGclkbvGuEbqQ.hvDyZKiqAhdaUxlKMfmseYlxZmKl<ttGTJvCLWyopGRqwuMdUrXnsniOo>());
			if (krbLBkShCkRqXRBFbYTIPELjbnf != num)
			{
				krbLBkShCkRqXRBFbYTIPELjbnf = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (eTNCusPGhCGJEIltKgykAIiDMomhB > 0 && GKvljIXlReLSmmuckEhPgqjpQQdJ.eCbDfwNkfTjmVdCgdQDLGBmltwXs())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void tbwjtIRJbpysegFisFiPrxALzbkE(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void XtqBnvylaKhZViIJreufaPqJUvwDb(nqFAqQygbeqywhAOyhuthDgdnaAoA P_0)
	{
		vcfiHlUamPovdkPIJjTUJhpVerVKA(P_0, false);
	}
}
