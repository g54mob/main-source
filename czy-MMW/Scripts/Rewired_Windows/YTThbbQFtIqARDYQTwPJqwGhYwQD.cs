using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class YTThbbQFtIqARDYQTwPJqwGhYwQD : PlatformInputManager
{
	private class SUfugzNurCJGwFIawnIMGHPGrqkj : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private bool vlyXiYhbJxqcPbvJMRYotudfrgJG;

		private int XQqMdqANZjMEqXCUUKOvucfAIxrhA;

		private readonly int QFFaXmdIEjDFEyXlEBiCIyAAnYDm;

		public Guid tBwkeepoKzKmGeuXYQFXEDuOdBPg;

		public string cmxFcqOoPZXtmjCjeakwJIpEkENK;

		public Guid VzCfzbfsUzrHvPbLmYBnoTKGlrVC;

		public Rewired.Libraries.SharpDX.XInput.DeviceType UdHAmujMdTDyvDHagPCbawylBsnJB;

		public XInputDeviceSubType upsnEmgENFIztzGGHSiBlLGFfJHAA;

		public bool LPbgmrNuyEZpbQalFeeLOpQxYZfG;

		public bool sykRDVbqAwTKuaHCqliKZYXsAMTL;

		public bool uEYJHHGoZcqtjCStTHlWKpexejqJA;

		public bool EJCOBjOOXpfHRDsFkumILcsyEApTA;

		private int VlgTWBadatSdYRxpCfvXQMsZTGGl;

		private int aPoAvrmNWaxCVOJccqAlLKWgaWON;

		private int yqodHOSkacPAPVPcoiGnQEmElBcH;

		private int SKWGEKtLKngnMoEsdqsPYrYJERTr;

		private readonly float[] WhUmyCHmXIdbvfLcUGXpvTNKUIZD;

		private readonly bool[] BgQfzOgGzKSlObeoHfAuGSmFCXDp;

		private HardwareJoystickMap_InputManager pIytVsvXAAVsuXWWiNSkxCbhzkkC;

		public readonly ljysGOtBMrboAifkyROqwAovfmXW tGOZePUkTvuGCzzJKHiEVQiiRBFe;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> xOvLkVrySkSzNVDVTtOCEIuBctDE;

		private Action hvKTGHXEpQjtqqtzrVULZXZqiduR;

		private bool RdqscweXwVKLZxZMXKqexpkBGBfP;

		private bool wpySWxmZupOrABQihQnvmhWvCTLKA;

		private bool cgFicafHeRwaQgNtykjnXXXCqhQqA;

		public string KsGejgQkzDaKRaDjkiyCfGzXStiy
		{
			get
			{
				string text = NbyZamPFLwzavAQcLzaNejFOKdEN;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int qFFaXmdIEjDFEyXlEBiCIyAAnYDm = QFFaXmdIEjDFEyXlEBiCIyAAnYDm;
				return text + " " + qFFaXmdIEjDFEyXlEBiCIyAAnYDm;
			}
		}

		public string NbyZamPFLwzavAQcLzaNejFOKdEN
		{
			get
			{
				if (!hTaPqtDilahkNzBKuidObLFujoiDA)
				{
					return string.Empty;
				}
				return upsnEmgENFIztzGGHSiBlLGFfJHAA.ToString();
			}
		}

		public bool hTaPqtDilahkNzBKuidObLFujoiDA
		{
			get
			{
				if (tGOZePUkTvuGCzzJKHiEVQiiRBFe == null || !EJCOBjOOXpfHRDsFkumILcsyEApTA)
				{
					return false;
				}
				if (RdqscweXwVKLZxZMXKqexpkBGBfP && !ESMMefEMjgrAfhEMcjmJCqYvIxiZ(metHzXivGZQUcympqClxsBxxXEMy.Asynchronous))
				{
					GJWJCxJdghKlwTmwZtNWxGuNhyWv();
				}
				return RdqscweXwVKLZxZMXKqexpkBGBfP;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return XQqMdqANZjMEqXCUUKOvucfAIxrhA;
			}
			set
			{
				XQqMdqANZjMEqXCUUKOvucfAIxrhA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => QFFaXmdIEjDFEyXlEBiCIyAAnYDm;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (vlyXiYhbJxqcPbvJMRYotudfrgJG)
				{
					return upsnEmgENFIztzGGHSiBlLGFfJHAA.ToString() + " " + (QFFaXmdIEjDFEyXlEBiCIyAAnYDm + 1);
				}
				return "XInput " + upsnEmgENFIztzGGHSiBlLGFfJHAA.ToString() + " " + (QFFaXmdIEjDFEyXlEBiCIyAAnYDm + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => QFFaXmdIEjDFEyXlEBiCIyAAnYDm;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => null;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => VzCfzbfsUzrHvPbLmYBnoTKGlrVC;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.whAuSdKGexiyedoQYGOmKiufuQpkA(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.etJZIWgxIMariYkbkqysJuqpaNAG();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public SUfugzNurCJGwFIawnIMGHPGrqkj(int P_0, bool P_1, ljysGOtBMrboAifkyROqwAovfmXW P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			tGOZePUkTvuGCzzJKHiEVQiiRBFe = P_2;
			vlyXiYhbJxqcPbvJMRYotudfrgJG = P_1;
			QFFaXmdIEjDFEyXlEBiCIyAAnYDm = P_0;
			xOvLkVrySkSzNVDVTtOCEIuBctDE = P_3;
			hvKTGHXEpQjtqqtzrVULZXZqiduR = P_4;
			XQqMdqANZjMEqXCUUKOvucfAIxrhA = -1;
			VlgTWBadatSdYRxpCfvXQMsZTGGl = 6;
			aPoAvrmNWaxCVOJccqAlLKWgaWON = 15;
			yqodHOSkacPAPVPcoiGnQEmElBcH = VlgTWBadatSdYRxpCfvXQMsZTGGl;
			SKWGEKtLKngnMoEsdqsPYrYJERTr = aPoAvrmNWaxCVOJccqAlLKWgaWON;
			WhUmyCHmXIdbvfLcUGXpvTNKUIZD = new float[VlgTWBadatSdYRxpCfvXQMsZTGGl];
			BgQfzOgGzKSlObeoHfAuGSmFCXDp = new bool[aPoAvrmNWaxCVOJccqAlLKWgaWON];
			zDQioysGrfiTZcjUpyCenclYZoXC();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.qydoVHgrTkfzJmNsMXNHOBhCViYD();
			bool[] array = tGOZePUkTvuGCzzJKHiEVQiiRBFe.etfWIuBPqlNKYxeSOAOhzivnnXiq;
			GQJRkVWPBMNwZYiuGmcaDIEMBvYP(array, ref tGOZePUkTvuGCzzJKHiEVQiiRBFe.JVlAGKqDsXdmirnaVwKIdYEewgvC);
			LSyrARRbINMgUJoZYDLHoQzwtogi(array, ref tGOZePUkTvuGCzzJKHiEVQiiRBFe.JVlAGKqDsXdmirnaVwKIdYEewgvC);
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.yOXenaoAzrBZFhwxcVWRmapepRLR();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void WmTiMdqjfCSPJgezxaDnsRnlPXbi(bool P_0)
		{
			if (tGOZePUkTvuGCzzJKHiEVQiiRBFe != null)
			{
				uEYJHHGoZcqtjCStTHlWKpexejqJA = P_0;
			}
		}

		public bool ESMMefEMjgrAfhEMcjmJCqYvIxiZ(metHzXivGZQUcympqClxsBxxXEMy P_0)
		{
			ngDNPPWAeohBDfHEZTeGWGVQGpceA(rvEfsDAfQJrTRGeVPHWLpxEKNWVQ(P_0));
			return RdqscweXwVKLZxZMXKqexpkBGBfP;
		}

		public bool rvEfsDAfQJrTRGeVPHWLpxEKNWVQ(metHzXivGZQUcympqClxsBxxXEMy P_0)
		{
			if (tGOZePUkTvuGCzzJKHiEVQiiRBFe == null)
			{
				return false;
			}
			return tGOZePUkTvuGCzzJKHiEVQiiRBFe.YSaGqHULQPaBbvKkQNLwptpkUQhd(P_0);
		}

		public void ngDNPPWAeohBDfHEZTeGWGVQGpceA(bool P_0)
		{
			RdqscweXwVKLZxZMXKqexpkBGBfP = P_0;
		}

		public void cpCLLPnIiCqsKeunbQCjVIHIfplh()
		{
			if (!EJCOBjOOXpfHRDsFkumILcsyEApTA || NYNoecuDogUHUVbFMqdwPpwLrDmn())
			{
				zDQioysGrfiTZcjUpyCenclYZoXC();
			}
			if (EJCOBjOOXpfHRDsFkumILcsyEApTA && RdqscweXwVKLZxZMXKqexpkBGBfP)
			{
				tGOZePUkTvuGCzzJKHiEVQiiRBFe.SkmdObKroIVEcNJLMvQcLWknCAYsA();
			}
		}

		public void OtqgQnxaIDfOILDrKDaLFrtGxwHv()
		{
			XQqMdqANZjMEqXCUUKOvucfAIxrhA = -1;
			EJCOBjOOXpfHRDsFkumILcsyEApTA = false;
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.mwigTNVVlMMOtxRNJmIJngzxdTPe();
			Array.Clear(WhUmyCHmXIdbvfLcUGXpvTNKUIZD, 0, WhUmyCHmXIdbvfLcUGXpvTNKUIZD.Length);
			Array.Clear(BgQfzOgGzKSlObeoHfAuGSmFCXDp, 0, BgQfzOgGzKSlObeoHfAuGSmFCXDp.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (VlgTWBadatSdYRxpCfvXQMsZTGGl != dataUpdater.axisCount || aPoAvrmNWaxCVOJccqAlLKWgaWON != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < VlgTWBadatSdYRxpCfvXQMsZTGGl; i++)
			{
				dataUpdater.axisValues[i] = WhUmyCHmXIdbvfLcUGXpvTNKUIZD[i];
			}
			for (int j = 0; j < aPoAvrmNWaxCVOJccqAlLKWgaWON; j++)
			{
				dataUpdater.buttonValues[j] = BgQfzOgGzKSlObeoHfAuGSmFCXDp[j];
			}
			if (wpySWxmZupOrABQihQnvmhWvCTLKA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo MKapDGDaVMmnAnnZNLvHbLPRKlpj()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			ilHfKYydEGmARFCbRzIJvAYbNFLF(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			eFFIQasaCmHldkRuvQLBmetQjeKy(bridgedController);
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
			return new ControllerDisconnectedEventArgs(XQqMdqANZjMEqXCUUKOvucfAIxrhA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void zDQioysGrfiTZcjUpyCenclYZoXC()
		{
			if (tGOZePUkTvuGCzzJKHiEVQiiRBFe == null || !ESMMefEMjgrAfhEMcjmJCqYvIxiZ(metHzXivGZQUcympqClxsBxxXEMy.Synchronous))
			{
				return;
			}
			try
			{
				AHRNazvVvNHHKeBhsiPYOSFHjRcD();
				xuLbIRvuyJbJtfamXnyOqSgQtuMTA xuLbIRvuyJbJtfamXnyOqSgQtuMTA2 = tGOZePUkTvuGCzzJKHiEVQiiRBFe.AXCkosrgntAZxxWxNxxMZkMGEFtr.vVXUNhrMMkiCqCLOKFxdstbfOWzE(YOcwOWQuGxprAWETvnkFQJssgSEs.Any);
				UdHAmujMdTDyvDHagPCbawylBsnJB = xuLbIRvuyJbJtfamXnyOqSgQtuMTA2.MLQcoKViyTupsSIXIfgZcKVNrEqUA;
				upsnEmgENFIztzGGHSiBlLGFfJHAA = (XInputDeviceSubType)xuLbIRvuyJbJtfamXnyOqSgQtuMTA2.ndrnqinPniziqeUGDIIRVgDtIMtkA;
				if (tGOZePUkTvuGCzzJKHiEVQiiRBFe.AXCkosrgntAZxxWxNxxMZkMGEFtr.bbriNnpocrkIqNaiIlKnfBzUliXF(default(tEMvMDgcwZeueXxszEJiRQqrAbCz)).JgAeCQFNBLRaxSQfLuvjTeOIKNGrA)
				{
					LPbgmrNuyEZpbQalFeeLOpQxYZfG = true;
				}
				sykRDVbqAwTKuaHCqliKZYXsAMTL = (xuLbIRvuyJbJtfamXnyOqSgQtuMTA2.ivqMEwUjeUWpGtIMwdwzoLivuzpe & DHGWWesSFJjWguAttSnvRbTLuERH.VoiceSupported) == DHGWWesSFJjWguAttSnvRbTLuERH.VoiceSupported;
				lDstfkxyxSiPUDVsVaQhjaVbgTun();
				tBwkeepoKzKmGeuXYQFXEDuOdBPg = pIytVsvXAAVsuXWWiNSkxCbhzkkC.hardwareMapIdentifier.guid;
				cmxFcqOoPZXtmjCjeakwJIpEkENK = pIytVsvXAAVsuXWWiNSkxCbhzkkC.controllerName;
				tGOZePUkTvuGCzzJKHiEVQiiRBFe.SkmdObKroIVEcNJLMvQcLWknCAYsA();
				VzCfzbfsUzrHvPbLmYBnoTKGlrVC = MiscTools.CreateGuidHashSHA1(string.Concat(UdHAmujMdTDyvDHagPCbawylBsnJB, upsnEmgENFIztzGGHSiBlLGFfJHAA, QFFaXmdIEjDFEyXlEBiCIyAAnYDm));
				EJCOBjOOXpfHRDsFkumILcsyEApTA = true;
			}
			catch (Exception)
			{
				EJCOBjOOXpfHRDsFkumILcsyEApTA = false;
				RdqscweXwVKLZxZMXKqexpkBGBfP = false;
				VzCfzbfsUzrHvPbLmYBnoTKGlrVC = Guid.Empty;
			}
		}

		private bool NYNoecuDogUHUVbFMqdwPpwLrDmn()
		{
			try
			{
				if (upsnEmgENFIztzGGHSiBlLGFfJHAA != (XInputDeviceSubType)tGOZePUkTvuGCzzJKHiEVQiiRBFe.AXCkosrgntAZxxWxNxxMZkMGEFtr.vVXUNhrMMkiCqCLOKFxdstbfOWzE(YOcwOWQuGxprAWETvnkFQJssgSEs.Any).ndrnqinPniziqeUGDIIRVgDtIMtkA)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void AHRNazvVvNHHKeBhsiPYOSFHjRcD()
		{
			sykRDVbqAwTKuaHCqliKZYXsAMTL = false;
			LPbgmrNuyEZpbQalFeeLOpQxYZfG = false;
			uEYJHHGoZcqtjCStTHlWKpexejqJA = false;
			EJCOBjOOXpfHRDsFkumILcsyEApTA = false;
		}

		private void GJWJCxJdghKlwTmwZtNWxGuNhyWv()
		{
			if (hvKTGHXEpQjtqqtzrVULZXZqiduR != null)
			{
				hvKTGHXEpQjtqqtzrVULZXZqiduR();
			}
			tGOZePUkTvuGCzzJKHiEVQiiRBFe.mwigTNVVlMMOtxRNJmIJngzxdTPe();
		}

		private void GQJRkVWPBMNwZYiuGmcaDIEMBvYP(bool[] P_0, ref SZDJGBmiFCvaatOZeubqeqTUslAY P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)pIytVsvXAAVsuXWWiNSkxCbhzkkC.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= VlgTWBadatSdYRxpCfvXQMsZTGGl)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				WhUmyCHmXIdbvfLcUGXpvTNKUIZD[i] = ASQBtcgFdVCCQNQOyMLSkzzEWFHaA(axes_orig[i], P_0, ref P_1);
				if (!wpySWxmZupOrABQihQnvmhWvCTLKA && WhUmyCHmXIdbvfLcUGXpvTNKUIZD[i] != 0f)
				{
					wpySWxmZupOrABQihQnvmhWvCTLKA = true;
				}
			}
		}

		private void LSyrARRbINMgUJoZYDLHoQzwtogi(bool[] P_0, ref SZDJGBmiFCvaatOZeubqeqTUslAY P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)pIytVsvXAAVsuXWWiNSkxCbhzkkC.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= aPoAvrmNWaxCVOJccqAlLKWgaWON)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				BgQfzOgGzKSlObeoHfAuGSmFCXDp[i] = xmJmRGKUEXXuMznSqVVFUQSBDGyH(buttons_orig[i], P_0, ref P_1);
				if (!wpySWxmZupOrABQihQnvmhWvCTLKA && BgQfzOgGzKSlObeoHfAuGSmFCXDp[i])
				{
					wpySWxmZupOrABQihQnvmhWvCTLKA = true;
				}
			}
		}

		private float ASQBtcgFdVCCQNQOyMLSkzzEWFHaA(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref SZDJGBmiFCvaatOZeubqeqTUslAY P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return qlRaIQFBSIdlPvawGLeYgBIRwMFS(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!fZvjAdegXEmiiWPteLrJooMaCFcAA(P_0.sourceButton, P_1))
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

		private float qlRaIQFBSIdlPvawGLeYgBIRwMFS(XInputAxis P_0, ref SZDJGBmiFCvaatOZeubqeqTUslAY P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => ljysGOtBMrboAifkyROqwAovfmXW.lmelkiuILiwbZXXVgApYVyyjjZJB(P_1.xtYhDZxKklCvYLAwsnDbQLQChxQx), 
				XInputAxis.LeftThumbY => ljysGOtBMrboAifkyROqwAovfmXW.lmelkiuILiwbZXXVgApYVyyjjZJB(P_1.CKJQJLxqWlRDfiPaEDJovsMtnVde), 
				XInputAxis.RightThumbX => ljysGOtBMrboAifkyROqwAovfmXW.lmelkiuILiwbZXXVgApYVyyjjZJB(P_1.xtPkGfnBJGqArsDasiNqLxaVDOCEA), 
				XInputAxis.RightThumbY => ljysGOtBMrboAifkyROqwAovfmXW.lmelkiuILiwbZXXVgApYVyyjjZJB(P_1.ZFMIPFWYlABgrezKKhpeTTbqOQDG), 
				XInputAxis.LeftTrigger => ljysGOtBMrboAifkyROqwAovfmXW.FMEgxlUZLjGHUagZRWYRdfTPWHdf(P_1.dLqOaJhGbeXmgDgMPppajKihiIlfA), 
				XInputAxis.RightTrigger => ljysGOtBMrboAifkyROqwAovfmXW.FMEgxlUZLjGHUagZRWYRdfTPWHdf(P_1.aWHJgKxgMppIujqGSBMEOLSUqsiT), 
				_ => 0f, 
			};
		}

		private bool xmJmRGKUEXXuMznSqVVFUQSBDGyH(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref SZDJGBmiFCvaatOZeubqeqTUslAY P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return fZvjAdegXEmiiWPteLrJooMaCFcAA(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = qlRaIQFBSIdlPvawGLeYgBIRwMFS(P_0.sourceAxis, ref P_2);
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

		private bool fZvjAdegXEmiiWPteLrJooMaCFcAA(XInputButton P_0, bool[] P_1)
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

		private void lDstfkxyxSiPUDVsVaQhjaVbgTun()
		{
			pIytVsvXAAVsuXWWiNSkxCbhzkkC = xOvLkVrySkSzNVDVTtOCEIuBctDE(MKapDGDaVMmnAnnZNLvHbLPRKlpj());
			if (pIytVsvXAAVsuXWWiNSkxCbhzkkC == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			VlgTWBadatSdYRxpCfvXQMsZTGGl = pIytVsvXAAVsuXWWiNSkxCbhzkkC.axisCount;
			aPoAvrmNWaxCVOJccqAlLKWgaWON = pIytVsvXAAVsuXWWiNSkxCbhzkkC.buttonCount;
		}

		private string HvsqbjvbnvxMSBlhtgCvKWYeYhmt()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{UdHAmujMdTDyvDHagPCbawylBsnJB.ToString()}{upsnEmgENFIztzGGHSiBlLGFfJHAA.ToString()}");
		}

		private void ilHfKYydEGmARFCbRzIJvAYbNFLF(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = HvsqbjvbnvxMSBlhtgCvKWYeYhmt();
			P_0.hardwareAxisCount = yqodHOSkacPAPVPcoiGnQEmElBcH;
			P_0.hardwareButtonCount = SKWGEKtLKngnMoEsdqsPYrYJERTr;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = NbyZamPFLwzavAQcLzaNejFOKdEN;
			P_0.hw_supportsVoice = sykRDVbqAwTKuaHCqliKZYXsAMTL;
			P_0.hw_supportsVibration = LPbgmrNuyEZpbQalFeeLOpQxYZfG;
			P_0.hw_localVibrationMotorCount = (LPbgmrNuyEZpbQalFeeLOpQxYZfG ? 2 : 0);
			P_0.hw_xInputSubType = upsnEmgENFIztzGGHSiBlLGFfJHAA;
		}

		private void eFFIQasaCmHldkRuvQLBmetQjeKy(BridgedController P_0)
		{
			ilHfKYydEGmARFCbRzIJvAYbNFLF(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = pIytVsvXAAVsuXWWiNSkxCbhzkkC.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + KsGejgQkzDaKRaDjkiyCfGzXStiy;
			P_0.productName = "XInput " + NbyZamPFLwzavAQcLzaNejFOKdEN;
			P_0.isXInputDevice = true;
			P_0.axisCount = VlgTWBadatSdYRxpCfvXQMsZTGGl;
			P_0.buttonCount = aPoAvrmNWaxCVOJccqAlLKWgaWON;
			P_0.controllerTypeGuid = tBwkeepoKzKmGeuXYQFXEDuOdBPg;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			qeDLIkiHMeWXTsyeMeCavnASniyC(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void kRdDoyxmFPCLBWfRGPMkAPYUbdIDA()
		{
			try
			{
				qeDLIkiHMeWXTsyeMeCavnASniyC(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void qeDLIkiHMeWXTsyeMeCavnASniyC(bool P_0)
		{
			if (cgFicafHeRwaQgNtykjnXXXCqhQqA)
			{
				return;
			}
			if (P_0)
			{
				if (hTaPqtDilahkNzBKuidObLFujoiDA)
				{
					tGOZePUkTvuGCzzJKHiEVQiiRBFe.NeWtCaoWyqFJYhmaDfwTQhDdtzKt();
				}
				if (tGOZePUkTvuGCzzJKHiEVQiiRBFe != null)
				{
					tGOZePUkTvuGCzzJKHiEVQiiRBFe.Dispose();
				}
			}
			cgFicafHeRwaQgNtykjnXXXCqhQqA = true;
		}
	}

	private class FlOcMxHGsMqCnWovTZLALTLfnZhk
	{
		private class BsFsCXLQQTOiTpfYdAaKxTGjlAYx
		{
			public bool gxsGkvIwXSlidetRArpPQQntdwuI;

			public int TpycXkWAzLxNwpNjAYbyoLhvYig;

			public XInputDeviceSubType tfTkbvAghYOGuFJDWiKSCmeeuHES;

			public void DXAbZWrQhoGLHBgwfNPbqNkLgLNc(SUfugzNurCJGwFIawnIMGHPGrqkj P_0, bool P_1)
			{
				gxsGkvIwXSlidetRArpPQQntdwuI = P_1;
				TpycXkWAzLxNwpNjAYbyoLhvYig = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				tfTkbvAghYOGuFJDWiKSCmeeuHES = P_0.upsnEmgENFIztzGGHSiBlLGFfJHAA;
			}

			public BsFsCXLQQTOiTpfYdAaKxTGjlAYx(int P_0, XInputDeviceSubType P_1)
			{
				TpycXkWAzLxNwpNjAYbyoLhvYig = P_0;
				tfTkbvAghYOGuFJDWiKSCmeeuHES = P_1;
			}
		}

		private List<BsFsCXLQQTOiTpfYdAaKxTGjlAYx> PlUiYQveqGHUXwFTwbJLCRDHwnqEA;

		public FlOcMxHGsMqCnWovTZLALTLfnZhk()
		{
			PlUiYQveqGHUXwFTwbJLCRDHwnqEA = new List<BsFsCXLQQTOiTpfYdAaKxTGjlAYx>();
		}

		public void GogBxyUDdnalIWNWhAwecbSEtwCx(SUfugzNurCJGwFIawnIMGHPGrqkj P_0, bool P_1)
		{
			if (TbesXJDnCtkGntWKYMaOXjMQEMkb(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.upsnEmgENFIztzGGHSiBlLGFfJHAA, true) < 0)
			{
				BsFsCXLQQTOiTpfYdAaKxTGjlAYx bsFsCXLQQTOiTpfYdAaKxTGjlAYx = new BsFsCXLQQTOiTpfYdAaKxTGjlAYx(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.upsnEmgENFIztzGGHSiBlLGFfJHAA);
				bsFsCXLQQTOiTpfYdAaKxTGjlAYx.gxsGkvIwXSlidetRArpPQQntdwuI = P_1;
				PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Add(bsFsCXLQQTOiTpfYdAaKxTGjlAYx);
			}
		}

		public void KpnYFdANUroQlvZmnFkkfDqWNDew(int P_0, SUfugzNurCJGwFIawnIMGHPGrqkj P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Count)
			{
				PlUiYQveqGHUXwFTwbJLCRDHwnqEA[P_0].DXAbZWrQhoGLHBgwfNPbqNkLgLNc(P_1, P_2);
			}
		}

		public int oKXwKnSrtkRlSeiRdLerGNTRajWIA(XInputDeviceSubType P_0, bool P_1)
		{
			int count = PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !PlUiYQveqGHUXwFTwbJLCRDHwnqEA[i].gxsGkvIwXSlidetRArpPQQntdwuI) && PlUiYQveqGHUXwFTwbJLCRDHwnqEA[i].tfTkbvAghYOGuFJDWiKSCmeeuHES == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int TbesXJDnCtkGntWKYMaOXjMQEMkb(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !PlUiYQveqGHUXwFTwbJLCRDHwnqEA[i].gxsGkvIwXSlidetRArpPQQntdwuI) && PlUiYQveqGHUXwFTwbJLCRDHwnqEA[i].TpycXkWAzLxNwpNjAYbyoLhvYig == P_0 && PlUiYQveqGHUXwFTwbJLCRDHwnqEA[i].tfTkbvAghYOGuFJDWiKSCmeeuHES == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int rlRSwisJxoQwBLOVATwgOPDFYDzL(int P_0)
		{
			if (P_0 < 0 || P_0 >= PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return PlUiYQveqGHUXwFTwbJLCRDHwnqEA[P_0].TpycXkWAzLxNwpNjAYbyoLhvYig;
		}

		public void jzlAREBMbFUREuESwEimFLJHzvZF(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < PlUiYQveqGHUXwFTwbJLCRDHwnqEA.Count)
			{
				PlUiYQveqGHUXwFTwbJLCRDHwnqEA[P_0].gxsGkvIwXSlidetRArpPQQntdwuI = P_1;
			}
		}
	}

	private class KFPuNkpPFDaTOPTZpuAAGrgDczdn
	{
		public bool DzsFcziXLGoAGfDngDqiYedTudwT;

		private double rhZuEvhjUExfzgqsJBswzAhMFxtQ;

		public float wqKpfPWwuZfJkUmjwtnZAuPDoHGw;

		public KFPuNkpPFDaTOPTZpuAAGrgDczdn(float P_0)
		{
			wqKpfPWwuZfJkUmjwtnZAuPDoHGw = P_0;
		}

		public void RxfKVicQdcuPuVgGLPSNQKGFXinx()
		{
			DzsFcziXLGoAGfDngDqiYedTudwT = true;
			rhZuEvhjUExfzgqsJBswzAhMFxtQ = (double)wqKpfPWwuZfJkUmjwtnZAuPDoHGw + ReInput.unscaledTime;
		}

		public bool kztybYEhMCRsgHtygNAgEFWKQGum()
		{
			if (!DzsFcziXLGoAGfDngDqiYedTudwT)
			{
				return false;
			}
			if (ReInput.unscaledTime >= rhZuEvhjUExfzgqsJBswzAhMFxtQ)
			{
				DzsFcziXLGoAGfDngDqiYedTudwT = false;
				return true;
			}
			return false;
		}
	}

	public class ljysGOtBMrboAifkyROqwAovfmXW : IDisposable
	{
		public readonly OxXoFPtoxevzpTAOmpYSoCvcDCol AXCkosrgntAZxxWxNxxMZkMGEFtr;

		public SZDJGBmiFCvaatOZeubqeqTUslAY JVlAGKqDsXdmirnaVwKIdYEewgvC;

		private bool CfJuDNslCgzOYWFuhYJRgIhkMGTF;

		private readonly ButtonLoopSet QfyxTqwDvyrdIfttMpytieXHkwpv;

		private SZDJGBmiFCvaatOZeubqeqTUslAY mOPZQhPOIvnoQkWHeBmKVHItJptq;

		private bool HmWSPiQFadORMqPAkYlEwpApnEUR;

		private DualThreadLowLevelInputEventQueue BawACOtNeDcuzfykABRIbiYrcuGzA;

		private readonly object xlBOWHzeQOFworFvvpXCKFmmXnLg;

		private RingBuffer<tEMvMDgcwZeueXxszEJiRQqrAbCz> LxGBSFJIQLRPzfzfgJYiqulYOoRf = new RingBuffer<tEMvMDgcwZeueXxszEJiRQqrAbCz>(5);

		private RingBuffer<tEMvMDgcwZeueXxszEJiRQqrAbCz> txEHvlAbXALzYlqheRqwzUHGRJXX = new RingBuffer<tEMvMDgcwZeueXxszEJiRQqrAbCz>(5);

		private readonly object JUKdxTEQxnHNvsEgoltzlPgvbkhTA = new object();

		private readonly object hBSzsxmDVkxqoIpbHzgYPdEwFyEy = new object();

		private tEMvMDgcwZeueXxszEJiRQqrAbCz npwcVIDlkpFAihpuDLajFFEIcqvtB;

		private double BrddaNDwXkhClijYNnQnvgnVJVGDA;

		private bool wCiBqPakvbrHpsfBIbJoEUdAtpOMb;

		public bool[] etfWIuBPqlNKYxeSOAOhzivnnXiq => QfyxTqwDvyrdIfttMpytieXHkwpv.Current.effectiveValue;

		public ljysGOtBMrboAifkyROqwAovfmXW(int P_0, UpdateLoopSetting P_1)
		{
			AXCkosrgntAZxxWxNxxMZkMGEFtr = new OxXoFPtoxevzpTAOmpYSoCvcDCol((mJHIZVYQAWrATPZlJRACpHMahDqeA)P_0);
			QfyxTqwDvyrdIfttMpytieXHkwpv = new ButtonLoopSet(P_1, 15);
			xlBOWHzeQOFworFvvpXCKFmmXnLg = new object();
			BawACOtNeDcuzfykABRIbiYrcuGzA = new DualThreadLowLevelInputEventQueue((int)((float)TOahviIJXSwhIkcLgNJHhAnDExwT.msYvraZKixRWczNsdUKcrerceHvr * 0.25f), 15, 6, 0);
		}

		public void qydoVHgrTkfzJmNsMXNHOBhCViYD()
		{
			QfyxTqwDvyrdIfttMpytieXHkwpv.SetUpdateLoop(ReInput.currentUpdateLoop);
			mSJHRHMEsfAWtSZXRkrLUnGIeMNfA(ref JVlAGKqDsXdmirnaVwKIdYEewgvC);
		}

		public void yOXenaoAzrBZFhwxcVWRmapepRLR()
		{
			mVgppcntmbPGInMIsUagqboWpADG();
			QfyxTqwDvyrdIfttMpytieXHkwpv.Current.ClearWasTrueThisFrame();
		}

		public void SkmdObKroIVEcNJLMvQcLWknCAYsA()
		{
			JiFUMZWKFbbKrKmuYvppSNkZuhrk();
			CfJuDNslCgzOYWFuhYJRgIhkMGTF = true;
			HmWSPiQFadORMqPAkYlEwpApnEUR = AXCkosrgntAZxxWxNxxMZkMGEFtr.yMpQJKKzhNEfuakaflNCiCzEWDCW;
		}

		public void mwigTNVVlMMOtxRNJmIJngzxdTPe()
		{
			CfJuDNslCgzOYWFuhYJRgIhkMGTF = false;
			HmWSPiQFadORMqPAkYlEwpApnEUR = false;
			JiFUMZWKFbbKrKmuYvppSNkZuhrk();
		}

		public bool YSaGqHULQPaBbvKkQNLwptpkUQhd(metHzXivGZQUcympqClxsBxxXEMy P_0)
		{
			return P_0 switch
			{
				metHzXivGZQUcympqClxsBxxXEMy.Synchronous => HmWSPiQFadORMqPAkYlEwpApnEUR = AXCkosrgntAZxxWxNxxMZkMGEFtr.yMpQJKKzhNEfuakaflNCiCzEWDCW, 
				metHzXivGZQUcympqClxsBxxXEMy.Asynchronous => HmWSPiQFadORMqPAkYlEwpApnEUR, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void whAuSdKGexiyedoQYGOmKiufuQpkA(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				npwcVIDlkpFAihpuDLajFFEIcqvtB.xBSDBnDxEvVRveSTUbBwSdXWOTBz = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				npwcVIDlkpFAihpuDLajFFEIcqvtB.wtskEdxkIrxEvkrCepLpCQxeclKR = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			ZsQAAzgbrEPNvEraAJCvfRlDZHNJA();
		}

		public void etJZIWgxIMariYkbkqysJuqpaNAG()
		{
			npwcVIDlkpFAihpuDLajFFEIcqvtB.xBSDBnDxEvVRveSTUbBwSdXWOTBz = 0;
			npwcVIDlkpFAihpuDLajFFEIcqvtB.wtskEdxkIrxEvkrCepLpCQxeclKR = 0;
			ZsQAAzgbrEPNvEraAJCvfRlDZHNJA();
		}

		public void NeWtCaoWyqFJYhmaDfwTQhDdtzKt()
		{
			npwcVIDlkpFAihpuDLajFFEIcqvtB.xBSDBnDxEvVRveSTUbBwSdXWOTBz = 0;
			npwcVIDlkpFAihpuDLajFFEIcqvtB.wtskEdxkIrxEvkrCepLpCQxeclKR = 0;
			lock (hBSzsxmDVkxqoIpbHzgYPdEwFyEy)
			{
				lock (JUKdxTEQxnHNvsEgoltzlPgvbkhTA)
				{
					LxGBSFJIQLRPzfzfgJYiqulYOoRf.Clear();
					txEHvlAbXALzYlqheRqwzUHGRJXX.Clear();
					joYUuAKgbBwbxwjeFnsbZIEwmram(AXCkosrgntAZxxWxNxxMZkMGEFtr, npwcVIDlkpFAihpuDLajFFEIcqvtB, ref BrddaNDwXkhClijYNnQnvgnVJVGDA);
				}
			}
		}

		public void OiAIAothjAGQjHLnemgtpklDFrBCA()
		{
			if (!CfJuDNslCgzOYWFuhYJRgIhkMGTF || !HmWSPiQFadORMqPAkYlEwpApnEUR)
			{
				return;
			}
			iEoHiNBpxuqYdDLSfjoMCydwpsYiB iEoHiNBpxuqYdDLSfjoMCydwpsYiB2;
			double realTime;
			try
			{
				if (!AXCkosrgntAZxxWxNxxMZkMGEFtr.qoMDnCaQYWUCzlkjxpvRnBDJOSeWA(out iEoHiNBpxuqYdDLSfjoMCydwpsYiB2))
				{
					HmWSPiQFadORMqPAkYlEwpApnEUR = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				HmWSPiQFadORMqPAkYlEwpApnEUR = false;
				return;
			}
			lock (xlBOWHzeQOFworFvvpXCKFmmXnLg)
			{
				if (!RAlbvXFdIiikDMbTYtFgsKAKSCbpA(iEoHiNBpxuqYdDLSfjoMCydwpsYiB2.OyGwGgZFIxggJWieZAebOqDkHfEBA, mOPZQhPOIvnoQkWHeBmKVHItJptq))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = BawACOtNeDcuzfykABRIbiYrcuGzA.T_CreateEvent())
					{
						xuzCDIyOlEpRhhyNqENTxbQcyqjP(ref iEoHiNBpxuqYdDLSfjoMCydwpsYiB2.OyGwGgZFIxggJWieZAebOqDkHfEBA, realTime, newEventWrapper.Event);
					}
					mOPZQhPOIvnoQkWHeBmKVHItJptq = iEoHiNBpxuqYdDLSfjoMCydwpsYiB2.OyGwGgZFIxggJWieZAebOqDkHfEBA;
				}
			}
		}

		public void CppLJwTwjhMNFnWCKYzhJupsHlII()
		{
			if (!CfJuDNslCgzOYWFuhYJRgIhkMGTF || !HmWSPiQFadORMqPAkYlEwpApnEUR || ReInput.realTime < BrddaNDwXkhClijYNnQnvgnVJVGDA + 0.009999999776482582)
			{
				return;
			}
			lock (hBSzsxmDVkxqoIpbHzgYPdEwFyEy)
			{
				lock (JUKdxTEQxnHNvsEgoltzlPgvbkhTA)
				{
					MiscTools.Swap(ref LxGBSFJIQLRPzfzfgJYiqulYOoRf, ref txEHvlAbXALzYlqheRqwzUHGRJXX);
				}
				YRqHDgXkhyjCsIqjmEIDDwYdCqQD(txEHvlAbXALzYlqheRqwzUHGRJXX, AXCkosrgntAZxxWxNxxMZkMGEFtr, ref BrddaNDwXkhClijYNnQnvgnVJVGDA);
			}
		}

		private void mVgppcntmbPGInMIsUagqboWpADG()
		{
			mffZlaHIiowzEBmeXktRSNcKOgal();
		}

		private void mffZlaHIiowzEBmeXktRSNcKOgal()
		{
			if (!(ReInput.realTime < BrddaNDwXkhClijYNnQnvgnVJVGDA + 1.5) && (!Mathf.Approximately((int)npwcVIDlkpFAihpuDLajFFEIcqvtB.xBSDBnDxEvVRveSTUbBwSdXWOTBz, 0f) || !Mathf.Approximately((int)npwcVIDlkpFAihpuDLajFFEIcqvtB.wtskEdxkIrxEvkrCepLpCQxeclKR, 0f)))
			{
				ZsQAAzgbrEPNvEraAJCvfRlDZHNJA();
			}
		}

		private void ZsQAAzgbrEPNvEraAJCvfRlDZHNJA()
		{
			lock (JUKdxTEQxnHNvsEgoltzlPgvbkhTA)
			{
				LxGBSFJIQLRPzfzfgJYiqulYOoRf.Enqueue(npwcVIDlkpFAihpuDLajFFEIcqvtB);
			}
		}

		private static void YRqHDgXkhyjCsIqjmEIDDwYdCqQD(RingBuffer<tEMvMDgcwZeueXxszEJiRQqrAbCz> P_0, OxXoFPtoxevzpTAOmpYSoCvcDCol P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				joYUuAKgbBwbxwjeFnsbZIEwmram(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void joYUuAKgbBwbxwjeFnsbZIEwmram(OxXoFPtoxevzpTAOmpYSoCvcDCol P_0, tEMvMDgcwZeueXxszEJiRQqrAbCz P_1, ref double P_2)
		{
			try
			{
				P_0.bbriNnpocrkIqNaiIlKnfBzUliXF(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void mSJHRHMEsfAWtSZXRkrLUnGIeMNfA(ref SZDJGBmiFCvaatOZeubqeqTUslAY P_0)
		{
			while (BawACOtNeDcuzfykABRIbiYrcuGzA.ProcessNewEvents())
			{
				bREJgsQVsUuobFDIZAxXNGpuqFZd(ref P_0, ref BawACOtNeDcuzfykABRIbiYrcuGzA.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					QfyxTqwDvyrdIfttMpytieXHkwpv.SetValue(i, ICZGlzaiBervsBNsIatWaUrTGTum((int)P_0.HiSZQgVhEzSwYZYMuPhniDxMzIDC, i), BawACOtNeDcuzfykABRIbiYrcuGzA.currentEvent.GetTimestamp());
				}
			}
		}

		private void xuzCDIyOlEpRhhyNqENTxbQcyqjP(ref SZDJGBmiFCvaatOZeubqeqTUslAY P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int hiSZQgVhEzSwYZYMuPhniDxMzIDC = (int)P_0.HiSZQgVhEzSwYZYMuPhniDxMzIDC;
			P_2.SetButtonsBitMask((hiSZQgVhEzSwYZYMuPhniDxMzIDC & 0x7FF) | ((hiSZQgVhEzSwYZYMuPhniDxMzIDC & (hiSZQgVhEzSwYZYMuPhniDxMzIDC & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, lmelkiuILiwbZXXVgApYVyyjjZJB(P_0.xtYhDZxKklCvYLAwsnDbQLQChxQx));
			P_2.SetAxisValue(1, lmelkiuILiwbZXXVgApYVyyjjZJB(P_0.CKJQJLxqWlRDfiPaEDJovsMtnVde));
			P_2.SetAxisValue(2, lmelkiuILiwbZXXVgApYVyyjjZJB(P_0.xtPkGfnBJGqArsDasiNqLxaVDOCEA));
			P_2.SetAxisValue(3, lmelkiuILiwbZXXVgApYVyyjjZJB(P_0.ZFMIPFWYlABgrezKKhpeTTbqOQDG));
			P_2.SetAxisValue(4, FMEgxlUZLjGHUagZRWYRdfTPWHdf(P_0.dLqOaJhGbeXmgDgMPppajKihiIlfA));
			P_2.SetAxisValue(5, FMEgxlUZLjGHUagZRWYRdfTPWHdf(P_0.aWHJgKxgMppIujqGSBMEOLSUqsiT));
		}

		private void bREJgsQVsUuobFDIZAxXNGpuqFZd(ref SZDJGBmiFCvaatOZeubqeqTUslAY P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.HiSZQgVhEzSwYZYMuPhniDxMzIDC = (HqNVOwAoDYFDMHedEiWMBAsGqGViA)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.xtYhDZxKklCvYLAwsnDbQLQChxQx = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.CKJQJLxqWlRDfiPaEDJovsMtnVde = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.xtPkGfnBJGqArsDasiNqLxaVDOCEA = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.ZFMIPFWYlABgrezKKhpeTTbqOQDG = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.dLqOaJhGbeXmgDgMPppajKihiIlfA = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.aWHJgKxgMppIujqGSBMEOLSUqsiT = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool ICZGlzaiBervsBNsIatWaUrTGTum(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void JiFUMZWKFbbKrKmuYvppSNkZuhrk()
		{
			lock (xlBOWHzeQOFworFvvpXCKFmmXnLg)
			{
				JVlAGKqDsXdmirnaVwKIdYEewgvC = default(SZDJGBmiFCvaatOZeubqeqTUslAY);
				mOPZQhPOIvnoQkWHeBmKVHItJptq = default(SZDJGBmiFCvaatOZeubqeqTUslAY);
				QfyxTqwDvyrdIfttMpytieXHkwpv.Clear();
				BawACOtNeDcuzfykABRIbiYrcuGzA.Clear();
			}
		}

		public void Dispose()
		{
			YbBxRArTtmQHaGTFBDWdZPiVFQJO(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void VesgfbpFszycWeTtzfQcuXGOCXtn()
		{
			try
			{
				YbBxRArTtmQHaGTFBDWdZPiVFQJO(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void YbBxRArTtmQHaGTFBDWdZPiVFQJO(bool P_0)
		{
			if (!wCiBqPakvbrHpsfBIbJoEUdAtpOMb)
			{
				if (P_0)
				{
					BawACOtNeDcuzfykABRIbiYrcuGzA.Dispose();
				}
				wCiBqPakvbrHpsfBIbJoEUdAtpOMb = true;
			}
		}

		public static float lmelkiuILiwbZXXVgApYVyyjjZJB(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float FMEgxlUZLjGHUagZRWYRdfTPWHdf(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool RAlbvXFdIiikDMbTYtFgsKAKSCbpA(SZDJGBmiFCvaatOZeubqeqTUslAY P_0, SZDJGBmiFCvaatOZeubqeqTUslAY P_1)
		{
			if (P_0.HiSZQgVhEzSwYZYMuPhniDxMzIDC == P_1.HiSZQgVhEzSwYZYMuPhniDxMzIDC && P_0.dLqOaJhGbeXmgDgMPppajKihiIlfA == P_1.dLqOaJhGbeXmgDgMPppajKihiIlfA && P_0.aWHJgKxgMppIujqGSBMEOLSUqsiT == P_1.aWHJgKxgMppIujqGSBMEOLSUqsiT && P_0.xtYhDZxKklCvYLAwsnDbQLQChxQx == P_1.xtYhDZxKklCvYLAwsnDbQLQChxQx && P_0.CKJQJLxqWlRDfiPaEDJovsMtnVde == P_1.CKJQJLxqWlRDfiPaEDJovsMtnVde && P_0.xtPkGfnBJGqArsDasiNqLxaVDOCEA == P_1.xtPkGfnBJGqArsDasiNqLxaVDOCEA)
			{
				return P_0.ZFMIPFWYlABgrezKKhpeTTbqOQDG == P_1.ZFMIPFWYlABgrezKKhpeTTbqOQDG;
			}
			return false;
		}
	}

	public enum metHzXivGZQUcympqClxsBxxXEMy
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	private SUfugzNurCJGwFIawnIMGHPGrqkj[] RUNguoFXhdUkZGfFFFDRSzixeSlT;

	private bool OTDOGVfgPvfIkZUZgIVxRbUdxjGL;

	private KFPuNkpPFDaTOPTZpuAAGrgDczdn MzPYImELRrCWCQFegxenyfCDAhtj;

	private FlOcMxHGsMqCnWovTZLALTLfnZhk GhBIinCoYgJrwYijYjsrRdVVnAsu;

	private global::npittTMAakxvSluVLkUJndISsJCJ<bool> rWKCakjaIEfIjQNOzbqRuzYuzLsqA;

	private bool[] HPzlRqsOcMCBKhbeJQjcHAZzFctpA;

	private bool[] ZaMOgPuLaognCbjxDEMMYSCATxYlA;

	private bool DLpOGfHlszbunAQNsUQuHAwjWEIpA;

	private readonly bool MByPODGKJYQHtRSHnKElNLjOFRDg;

	private readonly UpdateLoopSetting dkyCKrsLLIiUZzHgkziarfTBaSJf;

	private UpdateLoopType QTMJszXtejvyCoBmdWqtvjWdQdwv;

	private UpdateLoopType paFcpBDgSMtBigDTBktKGsPoqTFxA;

	private Action<int, ControllerDataUpdater> CPCHxnYrJNlEWfBzJuaVZRHKiqZA;

	private bool QropumOfbqWlYhDMVLLWICnHwhDM;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> wKZCuBXdRQefgBGYoEaSWgIYoomTA;

	private Func<int> EcyhydUaCOAjufRUMaRoegvBbFDR;

	private static Guid[] yvUmYkIdcAnCCjmtPMLyHzViFCDo;

	private static string[] QPtFzofcLHQABmsuLzXtLQBMmtlI;

	private static string[] OSKsDuVbuHwilDDzcyKGhVQLEhcS;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (RUNguoFXhdUkZGfFFFDRSzixeSlT[i].hTaPqtDilahkNzBKuidObLFujoiDA)
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

	public YTThbbQFtIqARDYQTwPJqwGhYwQD(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
	{
		MByPODGKJYQHtRSHnKElNLjOFRDg = P_0;
		dkyCKrsLLIiUZzHgkziarfTBaSJf = P_1;
		QropumOfbqWlYhDMVLLWICnHwhDM = true;
		try
		{
			if (!vfuAiKLVRYGaNsyitTmuTXodeUQA.wOYaABcPQWsWdiovhXznSUTJjLFnA(out var xfzjGOmskvZtGUvshJSLmbDHsoTQ2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (xfzjGOmskvZtGUvshJSLmbDHsoTQ2 < xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			wKZCuBXdRQefgBGYoEaSWgIYoomTA = P_2;
			EcyhydUaCOAjufRUMaRoegvBbFDR = P_3;
			DLpOGfHlszbunAQNsUQuHAwjWEIpA = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(dkyCKrsLLIiUZzHgkziarfTBaSJf, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					paFcpBDgSMtBigDTBktKGsPoqTFxA = list[num2];
				}
			}
			rWKCakjaIEfIjQNOzbqRuzYuzLsqA = new global::npittTMAakxvSluVLkUJndISsJCJ<bool>(true, aUDlydnNSqdjjRDwHZCINCBrxWyi);
			HPzlRqsOcMCBKhbeJQjcHAZzFctpA = new bool[4];
			ZaMOgPuLaognCbjxDEMMYSCATxYlA = new bool[4];
			CPCHxnYrJNlEWfBzJuaVZRHKiqZA = UpdateControllerData;
			if (DLpOGfHlszbunAQNsUQuHAwjWEIpA)
			{
				sLRWVpIJoadcvoLLFwRZqViEqwMV();
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
		if (QropumOfbqWlYhDMVLLWICnHwhDM)
		{
			MzPYImELRrCWCQFegxenyfCDAhtj = new KFPuNkpPFDaTOPTZpuAAGrgDczdn(1f);
		}
		GhBIinCoYgJrwYijYjsrRdVVnAsu = new FlOcMxHGsMqCnWovTZLALTLfnZhk();
		if (RUNguoFXhdUkZGfFFFDRSzixeSlT == null)
		{
			RUNguoFXhdUkZGfFFFDRSzixeSlT = new SUfugzNurCJGwFIawnIMGHPGrqkj[4];
			for (int i = 0; i < 4; i++)
			{
				ljysGOtBMrboAifkyROqwAovfmXW ljysGOtBMrboAifkyROqwAovfmXW2 = new ljysGOtBMrboAifkyROqwAovfmXW(i, dkyCKrsLLIiUZzHgkziarfTBaSJf);
				TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH.ThreadUpdateEvent += ljysGOtBMrboAifkyROqwAovfmXW2.OiAIAothjAGQjHLnemgtpklDFrBCA;
				TOahviIJXSwhIkcLgNJHhAnDExwT.jzwtqIeVJjMJesGFTWJHnefCesGEA.ThreadUpdateEvent += ljysGOtBMrboAifkyROqwAovfmXW2.CppLJwTwjhMNFnWCKYzhJupsHlII;
				RUNguoFXhdUkZGfFFFDRSzixeSlT[i] = new SUfugzNurCJGwFIawnIMGHPGrqkj(i, DLpOGfHlszbunAQNsUQuHAwjWEIpA, ljysGOtBMrboAifkyROqwAovfmXW2, wKZCuBXdRQefgBGYoEaSWgIYoomTA, SystemDeviceDisconnected);
			}
		}
		NyEMuPhwcjnnrjBFiWzDofqOMqfA(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		QTMJszXtejvyCoBmdWqtvjWdQdwv = currentUpdateLoop;
		ahehPVibaUySbYDBkjwzptSYeFrCA();
		for (int i = 0; i < 4; i++)
		{
			if (RUNguoFXhdUkZGfFFFDRSzixeSlT[i] != null && RUNguoFXhdUkZGfFFFDRSzixeSlT[i].hTaPqtDilahkNzBKuidObLFujoiDA)
			{
				RUNguoFXhdUkZGfFFFDRSzixeSlT[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (rWKCakjaIEfIjQNOzbqRuzYuzLsqA != null)
		{
			rWKCakjaIEfIjQNOzbqRuzYuzLsqA.ZsTnXJbLVbjRqPCSwHQgfEuNnYwm();
		}
		if (RUNguoFXhdUkZGfFFFDRSzixeSlT != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (RUNguoFXhdUkZGfFFFDRSzixeSlT[i] != null)
				{
					if (TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH != null)
					{
						TOahviIJXSwhIkcLgNJHhAnDExwT.gqqZYRewLjqhcutjWUAaQkwNKKCH.ThreadUpdateEvent -= RUNguoFXhdUkZGfFFFDRSzixeSlT[i].tGOZePUkTvuGCzzJKHiEVQiiRBFe.OiAIAothjAGQjHLnemgtpklDFrBCA;
					}
					if (TOahviIJXSwhIkcLgNJHhAnDExwT.jzwtqIeVJjMJesGFTWJHnefCesGEA != null)
					{
						TOahviIJXSwhIkcLgNJHhAnDExwT.jzwtqIeVJjMJesGFTWJHnefCesGEA.ThreadUpdateEvent -= RUNguoFXhdUkZGfFFFDRSzixeSlT[i].tGOZePUkTvuGCzzJKHiEVQiiRBFe.CppLJwTwjhMNFnWCKYzhJupsHlII;
					}
					RUNguoFXhdUkZGfFFFDRSzixeSlT[i].Dispose();
				}
			}
		}
		vfuAiKLVRYGaNsyitTmuTXodeUQA.zWOBhHwDucLGLyXdXGBOlbpiEUhx();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return CPCHxnYrJNlEWfBzJuaVZRHKiqZA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		RUNguoFXhdUkZGfFFFDRSzixeSlT[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		NyEMuPhwcjnnrjBFiWzDofqOMqfA(true);
		adyCITaTzUTktfjfYBLecpORWfjkA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		NyEMuPhwcjnnrjBFiWzDofqOMqfA(true);
		adyCITaTzUTktfjfYBLecpORWfjkA();
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

	private bool OobdisengHsxRgDIDGKRdMoGAfVI()
	{
		if (QTMJszXtejvyCoBmdWqtvjWdQdwv != paFcpBDgSMtBigDTBktKGsPoqTFxA)
		{
			return false;
		}
		bool num = MzPYImELRrCWCQFegxenyfCDAhtj.kztybYEhMCRsgHtygNAgEFWKQGum();
		if (num)
		{
			NyEMuPhwcjnnrjBFiWzDofqOMqfA(true);
		}
		return num;
	}

	private void NyEMuPhwcjnnrjBFiWzDofqOMqfA(bool P_0)
	{
		OTDOGVfgPvfIkZUZgIVxRbUdxjGL = P_0;
		if (QropumOfbqWlYhDMVLLWICnHwhDM)
		{
			MzPYImELRrCWCQFegxenyfCDAhtj.RxfKVicQdcuPuVgGLPSNQKGFXinx();
		}
	}

	private void adyCITaTzUTktfjfYBLecpORWfjkA()
	{
		if (rWKCakjaIEfIjQNOzbqRuzYuzLsqA != null)
		{
			rWKCakjaIEfIjQNOzbqRuzYuzLsqA.GwueoqldKDESkkscWQTdVaBdpUdEA();
		}
	}

	private void sLRWVpIJoadcvoLLFwRZqViEqwMV()
	{
		_ = new OxXoFPtoxevzpTAOmpYSoCvcDCol().yMpQJKKzhNEfuakaflNCiCzEWDCW;
	}

	private void ahehPVibaUySbYDBkjwzptSYeFrCA()
	{
		bool flag = false;
		if (QropumOfbqWlYhDMVLLWICnHwhDM)
		{
			flag = OobdisengHsxRgDIDGKRdMoGAfVI();
		}
		if (!flag && OTDOGVfgPvfIkZUZgIVxRbUdxjGL)
		{
			URCBgUHTkyWYviphqmHkfInJKSVmc(PVucYhyvMIvpYmfxhvdVkHRZchjdA());
			NyEMuPhwcjnnrjBFiWzDofqOMqfA(false);
			adyCITaTzUTktfjfYBLecpORWfjkA();
			return;
		}
		if (OTDOGVfgPvfIkZUZgIVxRbUdxjGL)
		{
			eSqClhFFNITkaxnuKlwLVfKzCFPB();
		}
		if (rWKCakjaIEfIjQNOzbqRuzYuzLsqA.QNkWrLdeVAqfzHLJahJtrCjbJhLT && rWKCakjaIEfIjQNOzbqRuzYuzLsqA.OGYjjpkJopdcraeeXRZPVQYSFoHJ())
		{
			bIwiwSoJAurJrvKrPjZYjYbCwvuI();
		}
	}

	private void eSqClhFFNITkaxnuKlwLVfKzCFPB()
	{
		OTDOGVfgPvfIkZUZgIVxRbUdxjGL = false;
		if (!rWKCakjaIEfIjQNOzbqRuzYuzLsqA.QNkWrLdeVAqfzHLJahJtrCjbJhLT)
		{
			rWKCakjaIEfIjQNOzbqRuzYuzLsqA.qAWTketRvCdmkOgJVrHCCVbnLSdx();
		}
	}

	private void bIwiwSoJAurJrvKrPjZYjYbCwvuI()
	{
		lock (HPzlRqsOcMCBKhbeJQjcHAZzFctpA)
		{
			Array.Copy(HPzlRqsOcMCBKhbeJQjcHAZzFctpA, ZaMOgPuLaognCbjxDEMMYSCATxYlA, 4);
		}
		URCBgUHTkyWYviphqmHkfInJKSVmc(ZaMOgPuLaognCbjxDEMMYSCATxYlA);
	}

	private bool aUDlydnNSqdjjRDwHZCINCBrxWyi()
	{
		lock (HPzlRqsOcMCBKhbeJQjcHAZzFctpA)
		{
			for (int i = 0; i < 4; i++)
			{
				if (RUNguoFXhdUkZGfFFFDRSzixeSlT[i] != null)
				{
					HPzlRqsOcMCBKhbeJQjcHAZzFctpA[i] = RUNguoFXhdUkZGfFFFDRSzixeSlT[i].rvEfsDAfQJrTRGeVPHWLpxEKNWVQ(metHzXivGZQUcympqClxsBxxXEMy.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] PVucYhyvMIvpYmfxhvdVkHRZchjdA()
	{
		for (int i = 0; i < 4; i++)
		{
			ZaMOgPuLaognCbjxDEMMYSCATxYlA[i] = RUNguoFXhdUkZGfFFFDRSzixeSlT[i].rvEfsDAfQJrTRGeVPHWLpxEKNWVQ(metHzXivGZQUcympqClxsBxxXEMy.Synchronous);
		}
		return ZaMOgPuLaognCbjxDEMMYSCATxYlA;
	}

	private void URCBgUHTkyWYviphqmHkfInJKSVmc(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (RUNguoFXhdUkZGfFFFDRSzixeSlT[i] != null && RUNguoFXhdUkZGfFFFDRSzixeSlT[i].uEYJHHGoZcqtjCStTHlWKpexejqJA)
			{
				bool flag = P_0[i];
				RUNguoFXhdUkZGfFFFDRSzixeSlT[i].ngDNPPWAeohBDfHEZTeGWGVQGpceA(flag);
				if (!flag)
				{
					HhiDleBEMMarbmNxFXDIzPPJZxzL(RUNguoFXhdUkZGfFFFDRSzixeSlT[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (RUNguoFXhdUkZGfFFFDRSzixeSlT[j] != null && !RUNguoFXhdUkZGfFFFDRSzixeSlT[j].uEYJHHGoZcqtjCStTHlWKpexejqJA)
			{
				bool flag2 = P_0[j];
				RUNguoFXhdUkZGfFFFDRSzixeSlT[j].ngDNPPWAeohBDfHEZTeGWGVQGpceA(flag2);
				if (flag2 && !HhiDleBEMMarbmNxFXDIzPPJZxzL(RUNguoFXhdUkZGfFFFDRSzixeSlT[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (RUNguoFXhdUkZGfFFFDRSzixeSlT[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					RUNguoFXhdUkZGfFFFDRSzixeSlT[k].WmTiMdqjfCSPJgezxaDnsRnlPXbi(P_0[k]);
				}
			}
		}
	}

	private bool HhiDleBEMMarbmNxFXDIzPPJZxzL(SUfugzNurCJGwFIawnIMGHPGrqkj P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.cpCLLPnIiCqsKeunbQCjVIHIfplh();
			if (!P_0.EJCOBjOOXpfHRDsFkumILcsyEApTA)
			{
				return false;
			}
			int num = GhBIinCoYgJrwYijYjsrRdVVnAsu.oKXwKnSrtkRlSeiRdLerGNTRajWIA(P_0.upsnEmgENFIztzGGHSiBlLGFfJHAA, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = GhBIinCoYgJrwYijYjsrRdVVnAsu.rlRSwisJxoQwBLOVATwgOPDFYDzL(num);
				GhBIinCoYgJrwYijYjsrRdVVnAsu.KpnYFdANUroQlvZmnFkkfDqWNDew(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = EcyhydUaCOAjufRUMaRoegvBbFDR();
				GhBIinCoYgJrwYijYjsrRdVVnAsu.GogBxyUDdnalIWNWhAwecbSEtwCx(P_0, true);
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
			int num2 = GhBIinCoYgJrwYijYjsrRdVVnAsu.TbesXJDnCtkGntWKYMaOXjMQEMkb(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.upsnEmgENFIztzGGHSiBlLGFfJHAA, true);
			if (num2 >= 0)
			{
				GhBIinCoYgJrwYijYjsrRdVVnAsu.jzlAREBMbFUREuESwEimFLJHzvZF(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.OtqgQnxaIDfOILDrKDaLFrtGxwHv();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static YTThbbQFtIqARDYQTwPJqwGhYwQD()
	{
		yvUmYkIdcAnCCjmtPMLyHzViFCDo = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		QPtFzofcLHQABmsuLzXtLQBMmtlI = new string[1] { "Xbox Bluetooth Gamepad" };
		OSKsDuVbuHwilDDzcyKGhVQLEhcS = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool DQTUQCKZbdhwjzgrqKGKRchSTojx(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(yvUmYkIdcAnCCjmtPMLyHzViFCDo, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < QPtFzofcLHQABmsuLzXtLQBMmtlI.Length; i++)
			{
				if (P_1.Equals(QPtFzofcLHQABmsuLzXtLQBMmtlI[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < OSKsDuVbuHwilDDzcyKGhVQLEhcS.Length; j++)
			{
				if (Regex.IsMatch(P_2, OSKsDuVbuHwilDDzcyKGhVQLEhcS[j], RegexOptions.IgnoreCase))
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
