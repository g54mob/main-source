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

internal class OoKXAmdYbXiAWwiETfBFmpRbcOsd : PlatformInputManager, pSdznuaGwmothEGkyHtMJwPUSUzT
{
	private class OlpHasFnmtCOEUrNnellhAsOhXwC : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int GjsScYsasTotVedXviUXKBxsgmEl;

		private int eJBhrqVuNofirijULrqoQbbRXoct;

		public Guid zBlQeBVLTNNDHZctIJjGljtRPnyN;

		public string zaDHeSdfrVFfltAvsPauOQHtXqOe;

		private readonly zvOGxcHsUJhuDsNyEaqXAYZbfPfCB bZMqzLvUmPAzQVBtkqPCsZaQAWUp;

		private readonly DeviceType NlLbrhDJAZbEENHMzWaEfdzqNEtLA;

		public string bXjkyimFzbmmCKVFVloboLwFdjrY;

		public string PvBncTfjeNottimGsTBwhBayRxsj;

		public string aRnZDzmFxJiDkILsddUyEIlivILiA;

		public int cXAIZfllpoOmAeiCIKXpKQKDFxxn;

		public int dNpMSmSXCHMTgVqdWFLSdncWbQbY;

		public Guid AueckOBcWbVZRnBCphpYBXocNgwm;

		public Guid egFjnclXPMaqjOYneuPPpfjVkRYs;

		public Guid ckZZOFEgsEHAsZULtejJXINRYyJS;

		public int MKSLpksjZQACcGMyutEtjPPdqgIkA;

		public int fQZLoitwtMGcDmdlCcuaBsbPRZYtA;

		public int jpqzLKVLfEqrykTsGDaanmLXOKCI;

		public int IEFjUjdcOMHYUrPqqfentPuqjqZR;

		public int bgZuaXFarIWtkOoprXVhRfNBCMlAA;

		public int riLJZWjCWWdEkEIFnJWjkuGJivLM;

		public bool dZVFkcOuZOgBFKcosOMHHagqJpQf;

		public bool tziwkUOILQruFIlVxsSuKqVTGDol;

		public bool MnSBLobIelMbNfXAXkpOoaoGudsx;

		public int wJVCSBzrGPwxcAEgTCoUOCBidDSr;

		private float[] HfdJoZQOoMhZiZznXtDEBmDxYMRW;

		private float[] HggDnaDlOfjtnftykShbxCEEOPyzA;

		private bool[] EVrmkjaCkKdPJfjnXDmRNlzpPeoL;

		private HardwareJoystickMap_InputManager pUySoEohsmcwcCGJqQCJWxBedFWxA;

		private tZGWdXmeeMqtWCvUSDWRJbQvngwO RvSJNFFPwGpypxxidkDoSQAWeVFt;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ngKZxYbFovxJFCIgNGsmiOLRaHMK;

		private bool ZlSbvXqjagDwMEcihZTKdusBMlnl;

		private bool odgGntpCkqrzSQBROtcyYjmlDVBq;

		[CompilerGenerated]
		private Controller.Extension hOvACxNwGgfWibSRgSLzpXTcqdpGA;

		private bool kbKAlFJBYcJHpMjUouZNxgJiuZFe;

		public bool ZOBWBNsedXuMwVRQoLzmzakzHKKEA
		{
			get
			{
				if (bZMqzLvUmPAzQVBtkqPCsZaQAWUp == null)
				{
					return false;
				}
				return bZMqzLvUmPAzQVBtkqPCsZaQAWUp.hFjmewFMcmejcJNNTRBVEXNSoZqA != null;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return GjsScYsasTotVedXviUXKBxsgmEl;
			}
			set
			{
				GjsScYsasTotVedXviUXKBxsgmEl = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return eJBhrqVuNofirijULrqoQbbRXoct;
			}
			set
			{
				eJBhrqVuNofirijULrqoQbbRXoct = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (zaDHeSdfrVFfltAvsPauOQHtXqOe != "Unknown Controller")
				{
					return zaDHeSdfrVFfltAvsPauOQHtXqOe;
				}
				if (tziwkUOILQruFIlVxsSuKqVTGDol && !string.IsNullOrEmpty(aRnZDzmFxJiDkILsddUyEIlivILiA))
				{
					return aRnZDzmFxJiDkILsddUyEIlivILiA;
				}
				return PvBncTfjeNottimGsTBwhBayRxsj;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (eJBhrqVuNofirijULrqoQbbRXoct < 0)
				{
					return null;
				}
				return eJBhrqVuNofirijULrqoQbbRXoct;
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
				return hOvACxNwGgfWibSRgSLzpXTcqdpGA;
			}
			[CompilerGenerated]
			set
			{
				hOvACxNwGgfWibSRgSLzpXTcqdpGA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => AueckOBcWbVZRnBCphpYBXocNgwm;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		public bool bhllbXTIkeUoBsrAyigPVToNFLKI
		{
			get
			{
				if (!kbKAlFJBYcJHpMjUouZNxgJiuZFe && bZMqzLvUmPAzQVBtkqPCsZaQAWUp != null)
				{
					return bZMqzLvUmPAzQVBtkqPCsZaQAWUp.dpzcVHCsBHCMmICbyeUMDkzlYFQHA;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = bhllbXTIkeUoBsrAyigPVToNFLKI;
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = bhllbXTIkeUoBsrAyigPVToNFLKI;
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public OlpHasFnmtCOEUrNnellhAsOhXwC(zvOGxcHsUJhuDsNyEaqXAYZbfPfCB P_0, DeviceType P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			bZMqzLvUmPAzQVBtkqPCsZaQAWUp = P_0;
			NlLbrhDJAZbEENHMzWaEfdzqNEtLA = P_1;
			ngKZxYbFovxJFCIgNGsmiOLRaHMK = P_2;
			eJBhrqVuNofirijULrqoQbbRXoct = -1;
			GjsScYsasTotVedXviUXKBxsgmEl = -1;
		}

		public void FZOVanPbLJTmAWLjZdrNrMHNEXzI()
		{
			if (!bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				return;
			}
			string obj = ((!string.IsNullOrEmpty(aRnZDzmFxJiDkILsddUyEIlivILiA)) ? aRnZDzmFxJiDkILsddUyEIlivILiA : PvBncTfjeNottimGsTBwhBayRxsj);
			Guid guid = egFjnclXPMaqjOYneuPPpfjVkRYs;
			ckZZOFEgsEHAsZULtejJXINRYyJS = MiscTools.CreateGuidHashSHA1(obj + guid.ToString());
			fQZLoitwtMGcDmdlCcuaBsbPRZYtA = IEFjUjdcOMHYUrPqqfentPuqjqZR;
			jpqzLKVLfEqrykTsGDaanmLXOKCI = bgZuaXFarIWtkOoprXVhRfNBCMlAA + riLJZWjCWWdEkEIFnJWjkuGJivLM * 8;
			tWEvLogJYJFkqDpRWUUIujFcSZeAA();
			zBlQeBVLTNNDHZctIJjGljtRPnyN = pUySoEohsmcwcCGJqQCJWxBedFWxA.hardwareMapIdentifier.guid;
			zaDHeSdfrVFfltAvsPauOQHtXqOe = pUySoEohsmcwcCGJqQCJWxBedFWxA.controllerName;
			ZlSbvXqjagDwMEcihZTKdusBMlnl = zBlQeBVLTNNDHZctIJjGljtRPnyN == Guid.Empty;
			HfdJoZQOoMhZiZznXtDEBmDxYMRW = new float[fQZLoitwtMGcDmdlCcuaBsbPRZYtA];
			HggDnaDlOfjtnftykShbxCEEOPyzA = new float[jpqzLKVLfEqrykTsGDaanmLXOKCI];
			EVrmkjaCkKdPJfjnXDmRNlzpPeoL = new bool[jpqzLKVLfEqrykTsGDaanmLXOKCI];
			if (pUySoEohsmcwcCGJqQCJWxBedFWxA != null && jpqzLKVLfEqrykTsGDaanmLXOKCI > 0)
			{
				switch (pUySoEohsmcwcCGJqQCJWxBedFWxA.map.platform)
				{
				case InputPlatform.WindowsRawInput:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							EVrmkjaCkKdPJfjnXDmRNlzpPeoL[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				case InputPlatform.WindowsDirectInput:
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							EVrmkjaCkKdPJfjnXDmRNlzpPeoL[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			RvSJNFFPwGpypxxidkDoSQAWeVFt = bZMqzLvUmPAzQVBtkqPCsZaQAWUp.EjzGwBuvIZFSaCPTHznZvNtTeSvWA;
			Update();
		}

		public void YvcbsHSnspZPLLVSSytcDrrYwCTC(OlpHasFnmtCOEUrNnellhAsOhXwC P_0)
		{
			if (bhllbXTIkeUoBsrAyigPVToNFLKI && P_0 != null)
			{
				eJBhrqVuNofirijULrqoQbbRXoct = P_0.eJBhrqVuNofirijULrqoQbbRXoct;
				GjsScYsasTotVedXviUXKBxsgmEl = P_0.GjsScYsasTotVedXviUXKBxsgmEl;
				for (int i = 0; i < MathTools.Min(HggDnaDlOfjtnftykShbxCEEOPyzA.Length, P_0.HggDnaDlOfjtnftykShbxCEEOPyzA.Length); i++)
				{
					HggDnaDlOfjtnftykShbxCEEOPyzA[i] = P_0.HggDnaDlOfjtnftykShbxCEEOPyzA[i];
				}
				for (int j = 0; j < MathTools.Min(EVrmkjaCkKdPJfjnXDmRNlzpPeoL.Length, P_0.EVrmkjaCkKdPJfjnXDmRNlzpPeoL.Length); j++)
				{
					EVrmkjaCkKdPJfjnXDmRNlzpPeoL[j] = P_0.EVrmkjaCkKdPJfjnXDmRNlzpPeoL[j];
				}
				for (int k = 0; k < MathTools.Min(HfdJoZQOoMhZiZznXtDEBmDxYMRW.Length, P_0.HfdJoZQOoMhZiZznXtDEBmDxYMRW.Length); k++)
				{
					HfdJoZQOoMhZiZznXtDEBmDxYMRW[k] = P_0.HfdJoZQOoMhZiZznXtDEBmDxYMRW[k];
				}
				odgGntpCkqrzSQBROtcyYjmlDVBq = P_0.odgGntpCkqrzSQBROtcyYjmlDVBq;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				bool[] array = bZMqzLvUmPAzQVBtkqPCsZaQAWUp.MYWhtZzmOOCIFEKYdEvnERWcPLnqb;
				int[] array2 = bZMqzLvUmPAzQVBtkqPCsZaQAWUp.DliRiQDHRpzekMwehUWjqGaLvtRR;
				dqkKYAtfvCuglRFMEkmRIkBWCYobA(array, array2);
				wssIFONjDhedhFHEkmdjUjXVbGcfA(array, array2);
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
			if (!bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				return;
			}
			if (fQZLoitwtMGcDmdlCcuaBsbPRZYtA != dataUpdater.axisCount || jpqzLKVLfEqrykTsGDaanmLXOKCI != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < fQZLoitwtMGcDmdlCcuaBsbPRZYtA; i++)
			{
				dataUpdater.axisValues[i] = HfdJoZQOoMhZiZznXtDEBmDxYMRW[i];
			}
			for (int j = 0; j < jpqzLKVLfEqrykTsGDaanmLXOKCI; j++)
			{
				if (EVrmkjaCkKdPJfjnXDmRNlzpPeoL[j])
				{
					dataUpdater.buttonPressureValues[j] = HggDnaDlOfjtnftykShbxCEEOPyzA[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = HggDnaDlOfjtnftykShbxCEEOPyzA[j] > 0f;
				}
			}
			if (odgGntpCkqrzSQBROtcyYjmlDVBq && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int FRxBOpdxrAUzkdwSTZpDchzSdNpFA(OlpHasFnmtCOEUrNnellhAsOhXwC P_0)
		{
			if (!bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				return 0;
			}
			if (P_0.GjsScYsasTotVedXviUXKBxsgmEl == GjsScYsasTotVedXviUXKBxsgmEl)
			{
				return 2;
			}
			if (IEFjUjdcOMHYUrPqqfentPuqjqZR != P_0.IEFjUjdcOMHYUrPqqfentPuqjqZR)
			{
				return 0;
			}
			if (bgZuaXFarIWtkOoprXVhRfNBCMlAA != P_0.bgZuaXFarIWtkOoprXVhRfNBCMlAA)
			{
				return 0;
			}
			if (riLJZWjCWWdEkEIFnJWjkuGJivLM != P_0.riLJZWjCWWdEkEIFnJWjkuGJivLM)
			{
				return 0;
			}
			if (ZOBWBNsedXuMwVRQoLzmzakzHKKEA != P_0.ZOBWBNsedXuMwVRQoLzmzakzHKKEA)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.ckZZOFEgsEHAsZULtejJXINRYyJS == ckZZOFEgsEHAsZULtejJXINRYyJS)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo kWZtwaeGwPIbNRgIlehPCWvhPDspA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			WyPnrezMpArmUWdjtwyZainjdRWk(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			XvdfHYgNPMzkJbnRUnJsnKFICNlfb(bridgedController);
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
			return new ControllerDisconnectedEventArgs(GjsScYsasTotVedXviUXKBxsgmEl);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void dqkKYAtfvCuglRFMEkmRIkBWCYobA(bool[] P_0, int[] P_1)
		{
			if (fQZLoitwtMGcDmdlCcuaBsbPRZYtA <= 0)
			{
				return;
			}
			switch (pUySoEohsmcwcCGJqQCJWxBedFWxA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						vMOGTETwHFEaCfIucImvASyxbcAE(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						vMOGTETwHFEaCfIucImvASyxbcAE(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						TtQHGcdtCxagfaoPOfiyhrXnebQXA(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void wssIFONjDhedhFHEkmdjUjXVbGcfA(bool[] P_0, int[] P_1)
		{
			if (jpqzLKVLfEqrykTsGDaanmLXOKCI <= 0)
			{
				return;
			}
			switch (pUySoEohsmcwcCGJqQCJWxBedFWxA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						AMCHmZUHkJzsNMaJOZeWBqnqGxYhA(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						AMCHmZUHkJzsNMaJOZeWBqnqGxYhA(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)pUySoEohsmcwcCGJqQCJWxBedFWxA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						qLKmtoLQgbwgveYfKNuXZaHwBQObA(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void vMOGTETwHFEaCfIucImvASyxbcAE(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= fQZLoitwtMGcDmdlCcuaBsbPRZYtA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			HfdJoZQOoMhZiZznXtDEBmDxYMRW[P_1] = mNmsSZwHdnrGlEtMaDAExWKLvGCJ(P_0, P_2, P_3);
			if (!odgGntpCkqrzSQBROtcyYjmlDVBq && HfdJoZQOoMhZiZznXtDEBmDxYMRW[P_1] != 0f)
			{
				odgGntpCkqrzSQBROtcyYjmlDVBq = true;
			}
		}

		private void AMCHmZUHkJzsNMaJOZeWBqnqGxYhA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= jpqzLKVLfEqrykTsGDaanmLXOKCI)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			HggDnaDlOfjtnftykShbxCEEOPyzA[P_1] = sPAAwTTlxrXlfEGITFktJOZzYROpA(P_0, P_2, P_3);
			if (!odgGntpCkqrzSQBROtcyYjmlDVBq && HggDnaDlOfjtnftykShbxCEEOPyzA[P_1] != 0f)
			{
				odgGntpCkqrzSQBROtcyYjmlDVBq = true;
			}
		}

		private float mNmsSZwHdnrGlEtMaDAExWKLvGCJ(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
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
				return EhdAalmnKLiuwBKwFufLQUVZsfflA((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= bgZuaXFarIWtkOoprXVhRfNBCMlAA || sourceButton >= 256)
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
				if (sourceHat < 0 || sourceHat >= riLJZWjCWWdEkEIFnJWjkuGJivLM || sourceHat >= 4)
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
					num3 = LUYykxrGBnSaPUjYOyouJzxwAVNU(num2, AxisDirection.Horizontal);
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
					num3 = LUYykxrGBnSaPUjYOyouJzxwAVNU(num2, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && sIxZBpAgbQNkGEjuuZBcHjhEAmVjA(customCalculationSourceData[i], out var item))
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

		private float EhdAalmnKLiuwBKwFufLQUVZsfflA(RawInputAxis P_0, int P_1)
		{
			return aAechlQUIydvZGwrfDnmjgXagNVTA((RvSJNFFPwGpypxxidkDoSQAWeVFt as SPDdCAYahBBjGiXtqyHRCWjATVyT).EDPFwIqlCnrHKdeMuKucNFoMapRiA(P_0, P_1));
		}

		private float sPAAwTTlxrXlfEGITFktJOZzYROpA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= bgZuaXFarIWtkOoprXVhRfNBCMlAA || sourceButton >= 256)
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
				float num2 = EhdAalmnKLiuwBKwFufLQUVZsfflA((RawInputAxis)sourceAxis, num);
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
				if (sourceHat < 0 || sourceHat >= riLJZWjCWWdEkEIFnJWjkuGJivLM || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (eTjqBnrJrLsUbNbNIFkbIEpUmAOHb(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (sIxZBpAgbQNkGEjuuZBcHjhEAmVjA(customCalculationSourceData[k], out var num4))
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

		private float aAechlQUIydvZGwrfDnmjgXagNVTA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float qlDzJMafTsdzAALeGfJFBSyaIwhrb(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (pUySoEohsmcwcCGJqQCJWxBedFWxA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float LUYykxrGBnSaPUjYOyouJzxwAVNU(int P_0, AxisDirection P_1)
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

		private bool eTjqBnrJrLsUbNbNIFkbIEpUmAOHb(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= bgZuaXFarIWtkOoprXVhRfNBCMlAA || sourceButton >= 256)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool sIxZBpAgbQNkGEjuuZBcHjhEAmVjA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = EhdAalmnKLiuwBKwFufLQUVZsfflA((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
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

		private ControlDeviceType tbmekaWfPTnjoxwtHJRRFHjyBXwt(DeviceType P_0)
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

		private void TtQHGcdtCxagfaoPOfiyhrXnebQXA(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= fQZLoitwtMGcDmdlCcuaBsbPRZYtA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			HfdJoZQOoMhZiZznXtDEBmDxYMRW[P_1] = IJwCJoftDnFqgSkPopZSKtkvSnSF(P_0, P_2, P_3);
			if (!odgGntpCkqrzSQBROtcyYjmlDVBq && HfdJoZQOoMhZiZznXtDEBmDxYMRW[P_1] != 0f)
			{
				odgGntpCkqrzSQBROtcyYjmlDVBq = true;
			}
		}

		private void qLKmtoLQgbwgveYfKNuXZaHwBQObA(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= jpqzLKVLfEqrykTsGDaanmLXOKCI)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			HggDnaDlOfjtnftykShbxCEEOPyzA[P_1] = zDGQABBUlgparHndgcepOBlCDQSY(P_0, P_2, P_3);
			if (!odgGntpCkqrzSQBROtcyYjmlDVBq && HggDnaDlOfjtnftykShbxCEEOPyzA[P_1] != 0f)
			{
				odgGntpCkqrzSQBROtcyYjmlDVBq = true;
			}
		}

		private float IJwCJoftDnFqgSkPopZSKtkvSnSF(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= IEFjUjdcOMHYUrPqqfentPuqjqZR || sourceAxis >= 56)
				{
					return 0f;
				}
				return jIMUcehuTVDemjEHYkJyxfNpxsAD(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= bgZuaXFarIWtkOoprXVhRfNBCMlAA || sourceButton >= 256)
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
				if (sourceHat < 0 || sourceHat >= riLJZWjCWWdEkEIFnJWjkuGJivLM || sourceHat >= 4)
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
					num2 = LUYykxrGBnSaPUjYOyouJzxwAVNU(num, AxisDirection.Horizontal);
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
					num2 = LUYykxrGBnSaPUjYOyouJzxwAVNU(num, AxisDirection.Vertical);
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

		private float jIMUcehuTVDemjEHYkJyxfNpxsAD(int P_0)
		{
			return (RvSJNFFPwGpypxxidkDoSQAWeVFt as DwhHUsgGvbTPWRSgIAUsyncIEAXEA).aFJKkYSyCZCopbUtfJsAJpDKyGTt(P_0);
		}

		private float zDGQABBUlgparHndgcepOBlCDQSY(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= bgZuaXFarIWtkOoprXVhRfNBCMlAA || sourceButton >= 256)
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
				if (sourceAxis < 0 || sourceAxis >= IEFjUjdcOMHYUrPqqfentPuqjqZR || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = jIMUcehuTVDemjEHYkJyxfNpxsAD(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= riLJZWjCWWdEkEIFnJWjkuGJivLM || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return qlDzJMafTsdzAALeGfJFBSyaIwhrb(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private bool pagJHdcsRABenlmYRKKlfxBHoIdR(int P_0, int P_1, HatType P_2)
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

		private float LGkoKzvJPJMsYKgyKYDyekmuDvRgA(int P_0, AxisDirection P_1)
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

		private void tWEvLogJYJFkqDpRWUUIujFcSZeAA()
		{
			pUySoEohsmcwcCGJqQCJWxBedFWxA = ngKZxYbFovxJFCIgNGsmiOLRaHMK(kWZtwaeGwPIbNRgIlehPCWvhPDspA());
			if (pUySoEohsmcwcCGJqQCJWxBedFWxA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			fQZLoitwtMGcDmdlCcuaBsbPRZYtA = pUySoEohsmcwcCGJqQCJWxBedFWxA.axisCount;
			jpqzLKVLfEqrykTsGDaanmLXOKCI = pUySoEohsmcwcCGJqQCJWxBedFWxA.buttonCount;
		}

		private string ptpmokNLkKyrRufPdrxrjxUjLLtr()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), bZMqzLvUmPAzQVBtkqPCsZaQAWUp.GybnuqYNOBaYmHvLZEdGqidWLFUK, (tziwkUOILQruFIlVxsSuKqVTGDol && !string.IsNullOrEmpty(aRnZDzmFxJiDkILsddUyEIlivILiA)) ? aRnZDzmFxJiDkILsddUyEIlivILiA : PvBncTfjeNottimGsTBwhBayRxsj, cXAIZfllpoOmAeiCIKXpKQKDFxxn.ToString("X4"), dNpMSmSXCHMTgVqdWFLSdncWbQbY.ToString("X4")));
		}

		private void WyPnrezMpArmUWdjtwyZainjdRWk(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = bZMqzLvUmPAzQVBtkqPCsZaQAWUp.GybnuqYNOBaYmHvLZEdGqidWLFUK;
			P_0.deviceType = tbmekaWfPTnjoxwtHJRRFHjyBXwt(NlLbrhDJAZbEENHMzWaEfdzqNEtLA);
			P_0.hardwareIdentifier = ptpmokNLkKyrRufPdrxrjxUjLLtr();
			P_0.hardwareAxisCount = IEFjUjdcOMHYUrPqqfentPuqjqZR;
			P_0.hardwareButtonCount = bgZuaXFarIWtkOoprXVhRfNBCMlAA;
			P_0.hardwareHatCount = riLJZWjCWWdEkEIFnJWjkuGJivLM;
			P_0.hw_productName = PvBncTfjeNottimGsTBwhBayRxsj;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_vendorId = dNpMSmSXCHMTgVqdWFLSdncWbQbY;
			P_0.hw_productId = cXAIZfllpoOmAeiCIKXpKQKDFxxn;
			P_0.hw_pidVid = new PidVid(egFjnclXPMaqjOYneuPPpfjVkRYs);
			P_0.hw_isBluetoothDevice = tziwkUOILQruFIlVxsSuKqVTGDol;
			P_0.hw_bluetoothDeviceName = aRnZDzmFxJiDkILsddUyEIlivILiA;
			P_0.hw_supportsVibration = MnSBLobIelMbNfXAXkpOoaoGudsx;
			P_0.hw_localVibrationMotorCount = wJVCSBzrGPwxcAEgTCoUOCBidDSr;
			P_0.definitionMatchTag = bZMqzLvUmPAzQVBtkqPCsZaQAWUp.tRebNUoDNXeulchgzkRiuQdQCQHF;
		}

		private void XvdfHYgNPMzkJbnRUnJsnKFICNlfb(BridgedController P_0)
		{
			WyPnrezMpArmUWdjtwyZainjdRWk(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = pUySoEohsmcwcCGJqQCJWxBedFWxA.ToGameHardwareControllerMap();
			P_0.instanceName = bXjkyimFzbmmCKVFVloboLwFdjrY;
			P_0.productName = PvBncTfjeNottimGsTBwhBayRxsj;
			P_0.isXInputDevice = dZVFkcOuZOgBFKcosOMHHagqJpQf;
			P_0.axisCount = fQZLoitwtMGcDmdlCcuaBsbPRZYtA;
			P_0.buttonCount = jpqzLKVLfEqrykTsGDaanmLXOKCI;
			P_0.isButtonPressureSensitive = new bool[jpqzLKVLfEqrykTsGDaanmLXOKCI];
			Array.Copy(EVrmkjaCkKdPJfjnXDmRNlzpPeoL, P_0.isButtonPressureSensitive, jpqzLKVLfEqrykTsGDaanmLXOKCI);
			P_0.unknownControllerHats = oxMRsOmekJrLyAkxByqOHLKDcgU();
			P_0.controllerTypeGuid = zBlQeBVLTNNDHZctIJjGljtRPnyN;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void PLybBfeGyzkHfQfSzJPwpEqHBadu()
		{
			for (int i = 0; i < jpqzLKVLfEqrykTsGDaanmLXOKCI; i++)
			{
				HggDnaDlOfjtnftykShbxCEEOPyzA[i] = 0f;
			}
			for (int j = 0; j < fQZLoitwtMGcDmdlCcuaBsbPRZYtA; j++)
			{
				HfdJoZQOoMhZiZznXtDEBmDxYMRW[j] = 0f;
			}
		}

		private UnknownControllerHat[] oxMRsOmekJrLyAkxByqOHLKDcgU()
		{
			if (!ZlSbvXqjagDwMEcihZTKdusBMlnl)
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

		public void VzJQTINiNLpSVlAXNjcDPBpncEPQ()
		{
			IvTGtiNizuBXnjozUJVrMfBPZezH(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void lRsGHhyIPNjlvdYYPgsmSuHHodujA()
		{
			try
			{
				IvTGtiNizuBXnjozUJVrMfBPZezH(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void IvTGtiNizuBXnjozUJVrMfBPZezH(bool P_0)
		{
			if (!kbKAlFJBYcJHpMjUouZNxgJiuZFe)
			{
				kbKAlFJBYcJHpMjUouZNxgJiuZFe = true;
			}
		}

		public static int anySJCSLKRMWTTRecIbmiTuJwOHk(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, OlpHasFnmtCOEUrNnellhAsOhXwC P_1)
		{
			if (P_0.eJBhrqVuNofirijULrqoQbbRXoct < P_1.eJBhrqVuNofirijULrqoQbbRXoct)
			{
				return -1;
			}
			if (P_0.eJBhrqVuNofirijULrqoQbbRXoct > P_1.eJBhrqVuNofirijULrqoQbbRXoct)
			{
				return 1;
			}
			return 0;
		}

		public static int lEhIWBsfoIcXnYqtEFcRHSGMyQxaA(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, OlpHasFnmtCOEUrNnellhAsOhXwC P_1)
		{
			if (P_0.MKSLpksjZQACcGMyutEtjPPdqgIkA < P_1.MKSLpksjZQACcGMyutEtjPPdqgIkA)
			{
				return -1;
			}
			if (P_0.MKSLpksjZQACcGMyutEtjPPdqgIkA > P_1.MKSLpksjZQACcGMyutEtjPPdqgIkA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class eKvbIyIaskPEHyGGYngSlbhNPTQp
	{
		public enum SImkPmiZSxiahkBFWcPEFuiHqQbZA
		{
			Exact = 0,
			Approximate = 1
		}

		public class YmrSFehdNCtvKNCtJDawJNsYiGDUA
		{
			public int bQngJlUKgursDloDrffVFkVDLQMH;

			public Guid nFIfBDSeKqKlPMkZbvHECSLWhUip;

			public Guid QsAzNESRDQljRrzaafaqILzSdjgjA;

			public int JKMgiVaOAznihzAeXAmUiuUIlTlo;

			public int mwKsFthknlMIcEbUekYqyfUqwoZA;

			public int IdLmGhNQNqQmTZAFSnWEDklFUUpN;

			public int RBACEGBPjlCBrLonrsrihEnXPedSA;

			public int xBkpUakKKZdgFjiTgAtBBJbGlTzKb;

			public int OgLfGjdbQMtpqsQDVBBDptGpLfgz;

			public bool yYRSLMNLorIPSnNQOPaTBfeLbbWP;

			public bool wTZcPtBiPybqhaBIvSBDuheLgSlv(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, SImkPmiZSxiahkBFWcPEFuiHqQbZA P_1)
			{
				if (mwKsFthknlMIcEbUekYqyfUqwoZA != P_0.IEFjUjdcOMHYUrPqqfentPuqjqZR)
				{
					return false;
				}
				if (IdLmGhNQNqQmTZAFSnWEDklFUUpN != P_0.bgZuaXFarIWtkOoprXVhRfNBCMlAA)
				{
					return false;
				}
				if (RBACEGBPjlCBrLonrsrihEnXPedSA != P_0.riLJZWjCWWdEkEIFnJWjkuGJivLM)
				{
					return false;
				}
				if (xBkpUakKKZdgFjiTgAtBBJbGlTzKb != P_0.jpqzLKVLfEqrykTsGDaanmLXOKCI)
				{
					return false;
				}
				if (OgLfGjdbQMtpqsQDVBBDptGpLfgz != P_0.fQZLoitwtMGcDmdlCcuaBsbPRZYtA)
				{
					return false;
				}
				if (yYRSLMNLorIPSnNQOPaTBfeLbbWP != P_0.ZOBWBNsedXuMwVRQoLzmzakzHKKEA)
				{
					return false;
				}
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == bQngJlUKgursDloDrffVFkVDLQMH)
				{
					return true;
				}
				return P_1 switch
				{
					SImkPmiZSxiahkBFWcPEFuiHqQbZA.Exact => nFIfBDSeKqKlPMkZbvHECSLWhUip == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					SImkPmiZSxiahkBFWcPEFuiHqQbZA.Approximate => QsAzNESRDQljRrzaafaqILzSdjgjA == P_0.ckZZOFEgsEHAsZULtejJXINRYyJS, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string TPMKwTHBKCwMfJAOqTVRrlrFQHIm()
			{
				string text = "" + "rewiredId = " + bQngJlUKgursDloDrffVFkVDLQMH + "\n";
				Guid guid = nFIfBDSeKqKlPMkZbvHECSLWhUip;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = QsAzNESRDQljRrzaafaqILzSdjgjA;
				return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", JKMgiVaOAznihzAeXAmUiuUIlTlo.ToString(), "\n"), "hardwareAxisCount = ", mwKsFthknlMIcEbUekYqyfUqwoZA.ToString(), "\n"), "hardwareButtonCount = ", IdLmGhNQNqQmTZAFSnWEDklFUUpN.ToString(), "\n"), "hardwareHatCount = ", RBACEGBPjlCBrLonrsrihEnXPedSA.ToString(), "\n"), "gameButtonCount = ", xBkpUakKKZdgFjiTgAtBBJbGlTzKb.ToString(), "\n"), "gameAxisCount = ", OgLfGjdbQMtpqsQDVBBDptGpLfgz.ToString(), "\n"), "hasDriver = ", yYRSLMNLorIPSnNQOPaTBfeLbbWP.ToString(), "\n");
			}
		}

		private sealed class OnaWbyvgTcjXscZVUEyoQYfmIbF : IEnumerable<YmrSFehdNCtvKNCtJDawJNsYiGDUA>, IEnumerable, IEnumerator<YmrSFehdNCtvKNCtJDawJNsYiGDUA>, IEnumerator, IDisposable
		{
			private int mRJfRbBIKAdGMCkyfaFnMrUCiTtR;

			private YmrSFehdNCtvKNCtJDawJNsYiGDUA DaMJiritcADVZwyGfRTuRKhNPQko;

			private int heOfNkWaMIVCrgnzLZWgBnEMWsTX;

			public eKvbIyIaskPEHyGGYngSlbhNPTQp YoKWWNtZKulpqvJJtWHBOdOPBmTFA;

			private OlpHasFnmtCOEUrNnellhAsOhXwC aLmchEUGWjwzBYejceeYlcKYdrCeA;

			public OlpHasFnmtCOEUrNnellhAsOhXwC SPtFXPsWdKzfWDiNidEOsbPsZyQN;

			private SImkPmiZSxiahkBFWcPEFuiHqQbZA njSahzHxKaiYDUXFGCzOtePMvhSd;

			public SImkPmiZSxiahkBFWcPEFuiHqQbZA YKrucifEOlZDhhMuRHWWSxlTonxE;

			private int RmhWNCcoAtJpIxlcLBgUhIWDyRBGA;

			private int zfXCgudivONbqnFfyHWgpEuvQiqw;

			YmrSFehdNCtvKNCtJDawJNsYiGDUA IEnumerator<YmrSFehdNCtvKNCtJDawJNsYiGDUA>.Current
			{
				[DebuggerHidden]
				get
				{
					return DaMJiritcADVZwyGfRTuRKhNPQko;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DaMJiritcADVZwyGfRTuRKhNPQko;
				}
			}

			[DebuggerHidden]
			public OnaWbyvgTcjXscZVUEyoQYfmIbF(int P_0)
			{
				mRJfRbBIKAdGMCkyfaFnMrUCiTtR = P_0;
				heOfNkWaMIVCrgnzLZWgBnEMWsTX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				mRJfRbBIKAdGMCkyfaFnMrUCiTtR = -2;
			}

			private bool MoveNext()
			{
				int num = mRJfRbBIKAdGMCkyfaFnMrUCiTtR;
				eKvbIyIaskPEHyGGYngSlbhNPTQp yoKWWNtZKulpqvJJtWHBOdOPBmTFA = YoKWWNtZKulpqvJJtWHBOdOPBmTFA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					mRJfRbBIKAdGMCkyfaFnMrUCiTtR = -1;
					goto IL_0083;
				}
				mRJfRbBIKAdGMCkyfaFnMrUCiTtR = -1;
				RmhWNCcoAtJpIxlcLBgUhIWDyRBGA = yoKWWNtZKulpqvJJtWHBOdOPBmTFA.fpMtGNXVMYGmCdIFojwvArNPKvDW.Count;
				zfXCgudivONbqnFfyHWgpEuvQiqw = 0;
				goto IL_0093;
				IL_0083:
				zfXCgudivONbqnFfyHWgpEuvQiqw++;
				goto IL_0093;
				IL_0093:
				if (zfXCgudivONbqnFfyHWgpEuvQiqw < RmhWNCcoAtJpIxlcLBgUhIWDyRBGA)
				{
					if (yoKWWNtZKulpqvJJtWHBOdOPBmTFA.fpMtGNXVMYGmCdIFojwvArNPKvDW[zfXCgudivONbqnFfyHWgpEuvQiqw].wTZcPtBiPybqhaBIvSBDuheLgSlv(aLmchEUGWjwzBYejceeYlcKYdrCeA, njSahzHxKaiYDUXFGCzOtePMvhSd))
					{
						DaMJiritcADVZwyGfRTuRKhNPQko = yoKWWNtZKulpqvJJtWHBOdOPBmTFA.fpMtGNXVMYGmCdIFojwvArNPKvDW[zfXCgudivONbqnFfyHWgpEuvQiqw];
						mRJfRbBIKAdGMCkyfaFnMrUCiTtR = 1;
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
			IEnumerator<YmrSFehdNCtvKNCtJDawJNsYiGDUA> IEnumerable<YmrSFehdNCtvKNCtJDawJNsYiGDUA>.GetEnumerator()
			{
				OnaWbyvgTcjXscZVUEyoQYfmIbF onaWbyvgTcjXscZVUEyoQYfmIbF;
				if (mRJfRbBIKAdGMCkyfaFnMrUCiTtR == -2 && heOfNkWaMIVCrgnzLZWgBnEMWsTX == Environment.CurrentManagedThreadId)
				{
					mRJfRbBIKAdGMCkyfaFnMrUCiTtR = 0;
					onaWbyvgTcjXscZVUEyoQYfmIbF = this;
				}
				else
				{
					onaWbyvgTcjXscZVUEyoQYfmIbF = new OnaWbyvgTcjXscZVUEyoQYfmIbF(0);
					onaWbyvgTcjXscZVUEyoQYfmIbF.YoKWWNtZKulpqvJJtWHBOdOPBmTFA = YoKWWNtZKulpqvJJtWHBOdOPBmTFA;
				}
				onaWbyvgTcjXscZVUEyoQYfmIbF.aLmchEUGWjwzBYejceeYlcKYdrCeA = SPtFXPsWdKzfWDiNidEOsbPsZyQN;
				onaWbyvgTcjXscZVUEyoQYfmIbF.njSahzHxKaiYDUXFGCzOtePMvhSd = YKrucifEOlZDhhMuRHWWSxlTonxE;
				return onaWbyvgTcjXscZVUEyoQYfmIbF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<YmrSFehdNCtvKNCtJDawJNsYiGDUA>)this).GetEnumerator();
			}
		}

		private List<YmrSFehdNCtvKNCtJDawJNsYiGDUA> fpMtGNXVMYGmCdIFojwvArNPKvDW;

		public eKvbIyIaskPEHyGGYngSlbhNPTQp()
		{
			fpMtGNXVMYGmCdIFojwvArNPKvDW = new List<YmrSFehdNCtvKNCtJDawJNsYiGDUA>();
		}

		public void KeoqQISCQZCXSiZfShFDxmuMzQCt(OlpHasFnmtCOEUrNnellhAsOhXwC P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = fpMtGNXVMYGmCdIFojwvArNPKvDW.Count;
			for (int i = 0; i < count; i++)
			{
				if (fpMtGNXVMYGmCdIFojwvArNPKvDW[i].wTZcPtBiPybqhaBIvSBDuheLgSlv(P_0, SImkPmiZSxiahkBFWcPEFuiHqQbZA.Exact))
				{
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].bQngJlUKgursDloDrffVFkVDLQMH = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].nFIfBDSeKqKlPMkZbvHECSLWhUip = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].QsAzNESRDQljRrzaafaqILzSdjgjA = P_0.ckZZOFEgsEHAsZULtejJXINRYyJS;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].JKMgiVaOAznihzAeXAmUiuUIlTlo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].mwKsFthknlMIcEbUekYqyfUqwoZA = P_0.IEFjUjdcOMHYUrPqqfentPuqjqZR;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].IdLmGhNQNqQmTZAFSnWEDklFUUpN = P_0.bgZuaXFarIWtkOoprXVhRfNBCMlAA;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].RBACEGBPjlCBrLonrsrihEnXPedSA = P_0.riLJZWjCWWdEkEIFnJWjkuGJivLM;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].xBkpUakKKZdgFjiTgAtBBJbGlTzKb = P_0.jpqzLKVLfEqrykTsGDaanmLXOKCI;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].OgLfGjdbQMtpqsQDVBBDptGpLfgz = P_0.fQZLoitwtMGcDmdlCcuaBsbPRZYtA;
					fpMtGNXVMYGmCdIFojwvArNPKvDW[i].yYRSLMNLorIPSnNQOPaTBfeLbbWP = P_0.ZOBWBNsedXuMwVRQoLzmzakzHKKEA;
					drzoEkevcxIhWBpyAfJZknpknYNRA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			fpMtGNXVMYGmCdIFojwvArNPKvDW.Add(new YmrSFehdNCtvKNCtJDawJNsYiGDUA
			{
				bQngJlUKgursDloDrffVFkVDLQMH = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				nFIfBDSeKqKlPMkZbvHECSLWhUip = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				QsAzNESRDQljRrzaafaqILzSdjgjA = P_0.ckZZOFEgsEHAsZULtejJXINRYyJS,
				JKMgiVaOAznihzAeXAmUiuUIlTlo = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				mwKsFthknlMIcEbUekYqyfUqwoZA = P_0.IEFjUjdcOMHYUrPqqfentPuqjqZR,
				IdLmGhNQNqQmTZAFSnWEDklFUUpN = P_0.bgZuaXFarIWtkOoprXVhRfNBCMlAA,
				RBACEGBPjlCBrLonrsrihEnXPedSA = P_0.riLJZWjCWWdEkEIFnJWjkuGJivLM,
				xBkpUakKKZdgFjiTgAtBBJbGlTzKb = P_0.jpqzLKVLfEqrykTsGDaanmLXOKCI,
				OgLfGjdbQMtpqsQDVBBDptGpLfgz = P_0.fQZLoitwtMGcDmdlCcuaBsbPRZYtA,
				yYRSLMNLorIPSnNQOPaTBfeLbbWP = P_0.ZOBWBNsedXuMwVRQoLzmzakzHKKEA
			});
			drzoEkevcxIhWBpyAfJZknpknYNRA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, fpMtGNXVMYGmCdIFojwvArNPKvDW.Count - 1);
		}

		public bool tYDCMECJAtUYkZHFsihpguKWBcgpA(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, SImkPmiZSxiahkBFWcPEFuiHqQbZA P_1)
		{
			int count = fpMtGNXVMYGmCdIFojwvArNPKvDW.Count;
			for (int i = 0; i < count; i++)
			{
				if (fpMtGNXVMYGmCdIFojwvArNPKvDW[i].wTZcPtBiPybqhaBIvSBDuheLgSlv(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(OnaWbyvgTcjXscZVUEyoQYfmIbF))]
		public IEnumerable<YmrSFehdNCtvKNCtJDawJNsYiGDUA> TdHejplphLTqzIDALRcVprPOeXvc(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, SImkPmiZSxiahkBFWcPEFuiHqQbZA P_1)
		{
			return new OnaWbyvgTcjXscZVUEyoQYfmIbF(-2)
			{
				YoKWWNtZKulpqvJJtWHBOdOPBmTFA = this,
				SPtFXPsWdKzfWDiNidEOsbPsZyQN = P_0,
				YKrucifEOlZDhhMuRHWWSxlTonxE = P_1
			};
		}

		private void drzoEkevcxIhWBpyAfJZknpknYNRA(int P_0, Guid P_1, int P_2)
		{
			for (int num = fpMtGNXVMYGmCdIFojwvArNPKvDW.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (fpMtGNXVMYGmCdIFojwvArNPKvDW[num].bQngJlUKgursDloDrffVFkVDLQMH == P_0 || fpMtGNXVMYGmCdIFojwvArNPKvDW[num].nFIfBDSeKqKlPMkZbvHECSLWhUip == P_1))
				{
					fpMtGNXVMYGmCdIFojwvArNPKvDW.RemoveAt(num);
				}
			}
		}

		public virtual string exiQClFvwXupNpaXjAnffKXqIdYbb()
		{
			string text = "";
			text = text + "Joystick records: " + fpMtGNXVMYGmCdIFojwvArNPKvDW.Count + "\n";
			for (int i = 0; i < fpMtGNXVMYGmCdIFojwvArNPKvDW.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + fpMtGNXVMYGmCdIFojwvArNPKvDW[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private aVNwfEKFFkuytdgRDywStztpwdQi dxNdSggxGlezWBxfdCtTQVJMPuPI;

	private List<OlpHasFnmtCOEUrNnellhAsOhXwC> bKRHIYBdVeXXrluOubfLsBODbnGY;

	private int SxPCmtkgyJWOmCFtuelRzigrIjNRA;

	private eKvbIyIaskPEHyGGYngSlbhNPTQp RqMXeOadpCIqgAtrvBXWTZHtlghn;

	private bool qxNwxjojQeoBfMSsKZHxzfiTfoq;

	private TimerRealTime BmpmYNNUESzokbqzsUUWStaBANog;

	private global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool> BlmchcRxLFiBEcIpnJvrpmEriemcb;

	private global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool> BqgKWCbyeJNchXVlkqPZlNGMLKeA;

	private int LOrJHYepiXtZqWHqBuomujOrGbMt;

	private int NWJOcxVJHPWFAcaMEpLXicvycLHK;

	private ConfigVars udVVpuftycnsyhYHeaaGoBLkKxmS;

	private tfBBbpYawsTqFdIUEKOlukvpcHoaA IODehpXuUOIcvYQCXJTIWQjmADfl;

	private Action<int, ControllerDataUpdater> lrYcVzTnzpwSHIaxPqXLOgHbcogm;

	private PlatformInputManager tNNwaLvCJWGiQxrJAGZjZnFbjyYU;

	private readonly NCZNhrCupoGuOroTBBBCFKccmmyk yPycXZuQrPCuwznevteavrBvCkniA;

	private readonly HltKLehnudYOrPAbZhZbCybkRCQnA gIBzMwUyesiWHWFMvpaNIeVidTzs;

	private readonly bool ywcBmZYbqUHoVfnkOhqlIBFiIAiEA;

	private readonly bool NwTxiKzPFHhWzaaMYFzsVGEjcCncb;

	private readonly bool IoqSLcsAeIMOCpwIJzKlJZFzOOkh;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dDVgeDbPFWdBBZFxOlPtevcjncWyA;

	private readonly Func<int> FMkIpUPqyXHEddjfjlquazxVtbFU;

	tfBBbpYawsTqFdIUEKOlukvpcHoaA pSdznuaGwmothEGkyHtMJwPUSUzT.wbjsmIpoJYIDLciADgGvDfNBzFtGA
	{
		get
		{
			return IODehpXuUOIcvYQCXJTIWQjmADfl;
		}
		set
		{
			wbjsmIpoJYIDLciADgGvDfNBzFtGA = tfBBbpYawsTqFdIUEKOlukvpcHoaA2;
			dxNdSggxGlezWBxfdCtTQVJMPuPI.iXcDfdFjrojgBepFMNGDjJcQBxuWA = tfBBbpYawsTqFdIUEKOlukvpcHoaA2;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => SxPCmtkgyJWOmCFtuelRzigrIjNRA;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => tNNwaLvCJWGiQxrJAGZjZnFbjyYU;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => dxNdSggxGlezWBxfdCtTQVJMPuPI;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.RawInput;

	public OoKXAmdYbXiAWwiETfBFmpRbcOsd(ConfigVars P_0, tfBBbpYawsTqFdIUEKOlukvpcHoaA P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, bool P_4, bool P_5, bool P_6, bool P_7)
	{
		try
		{
			udVVpuftycnsyhYHeaaGoBLkKxmS = P_0;
			IODehpXuUOIcvYQCXJTIWQjmADfl = P_1;
			dDVgeDbPFWdBBZFxOlPtevcjncWyA = P_2;
			FMkIpUPqyXHEddjfjlquazxVtbFU = P_3;
			ywcBmZYbqUHoVfnkOhqlIBFiIAiEA = P_4;
			NwTxiKzPFHhWzaaMYFzsVGEjcCncb = P_5;
			IoqSLcsAeIMOCpwIJzKlJZFzOOkh = P_6;
			tNNwaLvCJWGiQxrJAGZjZnFbjyYU = this;
			UpdateLoopSetting updateLoop = P_0.updateLoop;
			if (P_6)
			{
				gIBzMwUyesiWHWFMvpaNIeVidTzs = new HltKLehnudYOrPAbZhZbCybkRCQnA(updateLoop);
			}
			if (P_5)
			{
				yPycXZuQrPCuwznevteavrBvCkniA = new NCZNhrCupoGuOroTBBBCFKccmmyk(updateLoop);
			}
			dxNdSggxGlezWBxfdCtTQVJMPuPI = new aVNwfEKFFkuytdgRDywStztpwdQi(P_0, P_1, P_4, P_7, yPycXZuQrPCuwznevteavrBvCkniA, gIBzMwUyesiWHWFMvpaNIeVidTzs);
			lrYcVzTnzpwSHIaxPqXLOgHbcogm = UpdateControllerData;
			BlmchcRxLFiBEcIpnJvrpmEriemcb = new global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool>(true, TzwWKVwtyOcwwYqtUrYufEkaYaJf);
			BqgKWCbyeJNchXVlkqPZlNGMLKeA = new global::McjQlNxEMWbTtbUlrizSwucUAAoO<bool>(true, dxNdSggxGlezWBxfdCtTQVJMPuPI.hxuMmpxyWvwyEYQfBOTYSuNKxDOG);
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
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA || dxNdSggxGlezWBxfdCtTQVJMPuPI.TdXSyBPCyCbSaNSoknzfnCBNGuzV)
		{
			BmpmYNNUESzokbqzsUUWStaBANog = new TimerRealTime(1.0);
			BmpmYNNUESzokbqzsUUWStaBANog.Start();
		}
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA)
		{
			RqMXeOadpCIqgAtrvBXWTZHtlghn = new eKvbIyIaskPEHyGGYngSlbhNPTQp();
			XkSdAMkSzTNPEflcItohyakubhZDA();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA || dxNdSggxGlezWBxfdCtTQVJMPuPI.TdXSyBPCyCbSaNSoknzfnCBNGuzV)
		{
			uEEvwJmLFkGVrEMvDeEvVHHTsIwt();
		}
		if (dxNdSggxGlezWBxfdCtTQVJMPuPI != null)
		{
			dxNdSggxGlezWBxfdCtTQVJMPuPI.Update();
		}
		JOcEhkuNJwgNJfeyxWKwexzGSPt();
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA)
		{
			if (dxNdSggxGlezWBxfdCtTQVJMPuPI != null)
			{
				dxNdSggxGlezWBxfdCtTQVJMPuPI.UpdateDevices(updateLoop);
			}
			fUSmYwZadsEjHwxWXYyCBdbYsdSi();
			if (dxNdSggxGlezWBxfdCtTQVJMPuPI != null)
			{
				dxNdSggxGlezWBxfdCtTQVJMPuPI.UpdateFinished();
			}
		}
		if (NwTxiKzPFHhWzaaMYFzsVGEjcCncb)
		{
			yPycXZuQrPCuwznevteavrBvCkniA.NPBgMecRhGuglPCWNIxHfJdJcdMTb(updateLoop);
		}
		if (IoqSLcsAeIMOCpwIJzKlJZFzOOkh)
		{
			gIBzMwUyesiWHWFMvpaNIeVidTzs.ljHcLvEIhhbGtpJgCZwdcBqpdxqS(updateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (BqgKWCbyeJNchXVlkqPZlNGMLKeA != null)
		{
			BqgKWCbyeJNchXVlkqPZlNGMLKeA.mkQAsPQkdBLuRVdsGBfjsPGJgaIJ();
		}
		if (BlmchcRxLFiBEcIpnJvrpmEriemcb != null)
		{
			BlmchcRxLFiBEcIpnJvrpmEriemcb.mkQAsPQkdBLuRVdsGBfjsPGJgaIJ();
		}
		if (bKRHIYBdVeXXrluOubfLsBODbnGY != null)
		{
			int count = bKRHIYBdVeXXrluOubfLsBODbnGY.Count;
			for (int i = 0; i < count; i++)
			{
				if (bKRHIYBdVeXXrluOubfLsBODbnGY[i] != null)
				{
					bKRHIYBdVeXXrluOubfLsBODbnGY[i].VzJQTINiNLpSVlAXNjcDPBpncEPQ();
				}
			}
		}
		if (gIBzMwUyesiWHWFMvpaNIeVidTzs != null)
		{
			gIBzMwUyesiWHWFMvpaNIeVidTzs.Dispose();
		}
		if (yPycXZuQrPCuwznevteavrBvCkniA != null)
		{
			yPycXZuQrPCuwznevteavrBvCkniA.Dispose();
		}
		if (dxNdSggxGlezWBxfdCtTQVJMPuPI != null)
		{
			dxNdSggxGlezWBxfdCtTQVJMPuPI.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return lrYcVzTnzpwSHIaxPqXLOgHbcogm;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!ywcBmZYbqUHoVfnkOhqlIBFiIAiEA)
		{
			return;
		}
		for (int i = 0; i < SxPCmtkgyJWOmCFtuelRzigrIjNRA; i++)
		{
			if (bKRHIYBdVeXXrluOubfLsBODbnGY[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				bKRHIYBdVeXXrluOubfLsBODbnGY[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		dxNdSggxGlezWBxfdCtTQVJMPuPI.SystemDeviceConnected();
		qxNwxjojQeoBfMSsKZHxzfiTfoq = true;
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA || dxNdSggxGlezWBxfdCtTQVJMPuPI.TdXSyBPCyCbSaNSoknzfnCBNGuzV)
		{
			BmpmYNNUESzokbqzsUUWStaBANog.Start();
		}
		if (IoqSLcsAeIMOCpwIJzKlJZFzOOkh)
		{
			gIBzMwUyesiWHWFMvpaNIeVidTzs.WiXWKhCUgJBtCmWKWefzjcnDPXIo(true);
		}
		if (NwTxiKzPFHhWzaaMYFzsVGEjcCncb)
		{
			yPycXZuQrPCuwznevteavrBvCkniA.HeihVcCliymHoCXLpIxAUTyuFDsN(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		dxNdSggxGlezWBxfdCtTQVJMPuPI.SystemDeviceDisconnected();
		qxNwxjojQeoBfMSsKZHxzfiTfoq = true;
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA || dxNdSggxGlezWBxfdCtTQVJMPuPI.TdXSyBPCyCbSaNSoknzfnCBNGuzV)
		{
			BmpmYNNUESzokbqzsUUWStaBANog.Start();
		}
		if (IoqSLcsAeIMOCpwIJzKlJZFzOOkh)
		{
			gIBzMwUyesiWHWFMvpaNIeVidTzs.WiXWKhCUgJBtCmWKWefzjcnDPXIo(false);
		}
		if (NwTxiKzPFHhWzaaMYFzsVGEjcCncb)
		{
			yPycXZuQrPCuwznevteavrBvCkniA.HeihVcCliymHoCXLpIxAUTyuFDsN(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = ywcBmZYbqUHoVfnkOhqlIBFiIAiEA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return yPycXZuQrPCuwznevteavrBvCkniA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return gIBzMwUyesiWHWFMvpaNIeVidTzs;
	}

	public void jDZODRHIArZpwUlInIsbEsNFzivB(dQyUqKQcUcWKCbKWSlwDswopixZq P_0, LGPZdTdazZeyYZxciePBPaRUlZSd P_1)
	{
	}

	private void uEEvwJmLFkGVrEMvDeEvVHHTsIwt()
	{
		if (BlmchcRxLFiBEcIpnJvrpmEriemcb.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
		{
			if (BlmchcRxLFiBEcIpnJvrpmEriemcb.hRRQBhRlrNLlIwAAvCWMAegGhfdIA() && !BmpmYNNUESzokbqzsUUWStaBANog.running && !BqgKWCbyeJNchXVlkqPZlNGMLKeA.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
			{
				if (BlmchcRxLFiBEcIpnJvrpmEriemcb.pIVDjHonGkoGmUlIarmyWTCFlTfh)
				{
					qxNwxjojQeoBfMSsKZHxzfiTfoq = true;
				}
				BmpmYNNUESzokbqzsUUWStaBANog.Start();
			}
		}
		else if (!BmpmYNNUESzokbqzsUUWStaBANog.running)
		{
			BmpmYNNUESzokbqzsUUWStaBANog.Start();
		}
		else if (BmpmYNNUESzokbqzsUUWStaBANog.Update())
		{
			BlmchcRxLFiBEcIpnJvrpmEriemcb.ZRNxDcQZRiFYRKxfnaKLNAFnscDt();
		}
	}

	private void XkSdAMkSzTNPEflcItohyakubhZDA()
	{
		PkQlGFLCZMcLPfOUUPKMGrBnxOtKA(cTWtopskXmvjqYyJHgYqdSpMtJKF());
	}

	private void PkQlGFLCZMcLPfOUUPKMGrBnxOtKA(IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> P_0)
	{
		int num = 0;
		List<OlpHasFnmtCOEUrNnellhAsOhXwC> list = bKRHIYBdVeXXrluOubfLsBODbnGY;
		int sxPCmtkgyJWOmCFtuelRzigrIjNRA = SxPCmtkgyJWOmCFtuelRzigrIjNRA;
		bKRHIYBdVeXXrluOubfLsBODbnGY = new List<OlpHasFnmtCOEUrNnellhAsOhXwC>();
		LOrJHYepiXtZqWHqBuomujOrGbMt = 0;
		List<OlpHasFnmtCOEUrNnellhAsOhXwC> list2 = new List<OlpHasFnmtCOEUrNnellhAsOhXwC>();
		for (int num2 = sxPCmtkgyJWOmCFtuelRzigrIjNRA - 1; num2 >= 0; num2--)
		{
			if (list[num2] != null && !list[num2].bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				list2.Add(list[num2]);
				list.RemoveAt(num2);
			}
		}
		sxPCmtkgyJWOmCFtuelRzigrIjNRA = list?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			zvOGxcHsUJhuDsNyEaqXAYZbfPfCB zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2 = P_0[i];
			if (zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2 != null)
			{
				OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = new OlpHasFnmtCOEUrNnellhAsOhXwC(zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2, zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.ZErDWEsMYMTvJzWzFPYRZaJSUfdL, dDVgeDbPFWdBBZFxOlPtevcjncWyA);
				olpHasFnmtCOEUrNnellhAsOhXwC.AueckOBcWbVZRnBCphpYBXocNgwm = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.EHQHtNNrxlMzreeTogiAPPIWcpqC;
				olpHasFnmtCOEUrNnellhAsOhXwC.bXjkyimFzbmmCKVFVloboLwFdjrY = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.kHVLroZdzgYbmtCjUQBkmLNvwIAh;
				olpHasFnmtCOEUrNnellhAsOhXwC.PvBncTfjeNottimGsTBwhBayRxsj = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.kHVLroZdzgYbmtCjUQBkmLNvwIAh;
				olpHasFnmtCOEUrNnellhAsOhXwC.egFjnclXPMaqjOYneuPPpfjVkRYs = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.GwyBEvfTEZeyGrFtYNdeBRCHzPAOb;
				olpHasFnmtCOEUrNnellhAsOhXwC.cXAIZfllpoOmAeiCIKXpKQKDFxxn = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.yJPKDzzdTMFNGOBOQDLASYBxbecU;
				olpHasFnmtCOEUrNnellhAsOhXwC.dNpMSmSXCHMTgVqdWFLSdncWbQbY = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.izTxynPZFQvOiNEtBAmqobeGLRIL;
				olpHasFnmtCOEUrNnellhAsOhXwC.MKSLpksjZQACcGMyutEtjPPdqgIkA = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.ahTmqiGAlooOKRykhVRFmiEdcRAi;
				olpHasFnmtCOEUrNnellhAsOhXwC.IEFjUjdcOMHYUrPqqfentPuqjqZR = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.BZnryvGngwgOtAHOQzzKQkauNMZy;
				olpHasFnmtCOEUrNnellhAsOhXwC.bgZuaXFarIWtkOoprXVhRfNBCMlAA = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.xAeBNkejlxbvIhTFSrCiHanTeVsi;
				olpHasFnmtCOEUrNnellhAsOhXwC.riLJZWjCWWdEkEIFnJWjkuGJivLM = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.NbZTHRzpPMpqKQApSzjgrKijqTZM;
				olpHasFnmtCOEUrNnellhAsOhXwC.dZVFkcOuZOgBFKcosOMHHagqJpQf = false;
				olpHasFnmtCOEUrNnellhAsOhXwC.tziwkUOILQruFIlVxsSuKqVTGDol = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.cmRjyxmQtZdaHTctAEloLaRHsWhh;
				olpHasFnmtCOEUrNnellhAsOhXwC.aRnZDzmFxJiDkILsddUyEIlivILiA = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.xXjjzJOGKVAUsURDmlmlbuXJFSkP;
				olpHasFnmtCOEUrNnellhAsOhXwC.MnSBLobIelMbNfXAXkpOoaoGudsx = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.UxAZyIJbJamNfyMPcXJgznzokRpN;
				olpHasFnmtCOEUrNnellhAsOhXwC.wJVCSBzrGPwxcAEgTCoUOCBidDSr = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.nVMeWiXuKKGvqXvriZiCpnspHnrj;
				olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.KjNIvvnSJArvYwgjBjyDXHyKeRaf;
				zvOGxcHsUJhuDsNyEaqXAYZbfPfCB2.MdtMfAVmBZYZlclZRBuTFVbXsHRs();
				olpHasFnmtCOEUrNnellhAsOhXwC.FZOVanPbLJTmAWLjZdrNrMHNEXzI();
				bKRHIYBdVeXXrluOubfLsBODbnGY.Add(olpHasFnmtCOEUrNnellhAsOhXwC);
				num++;
				if (olpHasFnmtCOEUrNnellhAsOhXwC.tziwkUOILQruFIlVxsSuKqVTGDol)
				{
					LOrJHYepiXtZqWHqBuomujOrGbMt++;
				}
			}
		}
		SxPCmtkgyJWOmCFtuelRzigrIjNRA = num;
		jUhFHGDoYBvnxdXqZXbaYFUhhhxS(sxPCmtkgyJWOmCFtuelRzigrIjNRA, num, list, bKRHIYBdVeXXrluOubfLsBODbnGY);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(bKRHIYBdVeXXrluOubfLsBODbnGY[j]));
			}
		}
		list2.ForEach(delegate(OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC2)
		{
			IODreFhLbEUXZVxBSBUYzfPgBsfS(olpHasFnmtCOEUrNnellhAsOhXwC2, false);
		});
		gUeMhyANjrPwOKcgBLiuQpRuNLbY(list, bKRHIYBdVeXXrluOubfLsBODbnGY, false);
		gUeMhyANjrPwOKcgBLiuQpRuNLbY(bKRHIYBdVeXXrluOubfLsBODbnGY, list, true);
	}

	private void fUSmYwZadsEjHwxWXYyCBdbYsdSi()
	{
		for (int i = 0; i < SxPCmtkgyJWOmCFtuelRzigrIjNRA; i++)
		{
			OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = bKRHIYBdVeXXrluOubfLsBODbnGY[i];
			if (olpHasFnmtCOEUrNnellhAsOhXwC != null && (IODehpXuUOIcvYQCXJTIWQjmADfl == null || !olpHasFnmtCOEUrNnellhAsOhXwC.dZVFkcOuZOgBFKcosOMHHagqJpQf))
			{
				olpHasFnmtCOEUrNnellhAsOhXwC.Update();
			}
		}
	}

	private bool rDWKyavYHOEpGvxgVpTrkaXNheeC(YyaQcSKMfMfOOEKYzGdEBLkAwOyl P_0)
	{
		try
		{
			return P_0.xcKGaKgsNYCpGCUVllkYWenYMagx();
		}
		catch
		{
			return false;
		}
	}

	private IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> cTWtopskXmvjqYyJHgYqdSpMtJKF()
	{
		return dxNdSggxGlezWBxfdCtTQVJMPuPI.GetJoysticks<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB>();
	}

	private void jUhFHGDoYBvnxdXqZXbaYFUhhhxS(int P_0, int P_1, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_2, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(OlpHasFnmtCOEUrNnellhAsOhXwC.lEhIWBsfoIcXnYqtEFcRHSGMyQxaA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			dwnvrhAKJjZxFzbycZscgslNcgGR(P_1, P_3, P_0, P_2, eKvbIyIaskPEHyGGYngSlbhNPTQp.SImkPmiZSxiahkBFWcPEFuiHqQbZA.Exact);
		}
		dFtwpBXwLlFEuWwgVgLbcGePSiaG(P_1, P_3, eKvbIyIaskPEHyGGYngSlbhNPTQp.SImkPmiZSxiahkBFWcPEFuiHqQbZA.Exact);
		for (int i = 0; i < P_1; i++)
		{
			OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = P_3[i];
			if (olpHasFnmtCOEUrNnellhAsOhXwC != null && olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = nLVSflXgauMRnJZyogFwUQSULJkF(P_3);
				olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = FMkIpUPqyXHEddjfjlquazxVtbFU();
				RqMXeOadpCIqgAtrvBXWTZHtlghn.KeoqQISCQZCXSiZfShFDxmuMzQCt(olpHasFnmtCOEUrNnellhAsOhXwC);
			}
		}
		P_3.Sort(OlpHasFnmtCOEUrNnellhAsOhXwC.anySJCSLKRMWTTRecIbmiTuJwOHk);
	}

	private void tuYmKbrJZGEkkFUKisipswKXEmDGA(List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_0, int P_1, int P_2)
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

	private bool mBsLdoiZGOUvAkwljsOSyzUooygr(List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_0, int P_1)
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

	private int nLVSflXgauMRnJZyogFwUQSULJkF(List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_0)
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

	private bool FCPgJMIemtfvCTWuTlOUUgKcBOph(List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_0, int P_1)
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

	private void dwnvrhAKJjZxFzbycZscgslNcgGR(int P_0, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_1, int P_2, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_3, eKvbIyIaskPEHyGGYngSlbhNPTQp.SImkPmiZSxiahkBFWcPEFuiHqQbZA P_4)
	{
		int num = ((P_4 != eKvbIyIaskPEHyGGYngSlbhNPTQp.SImkPmiZSxiahkBFWcPEFuiHqQbZA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = P_1[i];
			if (olpHasFnmtCOEUrNnellhAsOhXwC == null || olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC2 = P_3[j];
				if (olpHasFnmtCOEUrNnellhAsOhXwC2 != null && !FCPgJMIemtfvCTWuTlOUUgKcBOph(P_1, olpHasFnmtCOEUrNnellhAsOhXwC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && olpHasFnmtCOEUrNnellhAsOhXwC.FRxBOpdxrAUzkdwSTZpDchzSdNpFA(olpHasFnmtCOEUrNnellhAsOhXwC2) >= num)
				{
					olpHasFnmtCOEUrNnellhAsOhXwC.YvcbsHSnspZPLLVSSytcDrrYwCTC(olpHasFnmtCOEUrNnellhAsOhXwC2);
					RqMXeOadpCIqgAtrvBXWTZHtlghn.KeoqQISCQZCXSiZfShFDxmuMzQCt(olpHasFnmtCOEUrNnellhAsOhXwC);
				}
			}
		}
	}

	private void dFtwpBXwLlFEuWwgVgLbcGePSiaG(int P_0, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_1, eKvbIyIaskPEHyGGYngSlbhNPTQp.SImkPmiZSxiahkBFWcPEFuiHqQbZA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = P_1[i];
			if (olpHasFnmtCOEUrNnellhAsOhXwC == null || olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			eKvbIyIaskPEHyGGYngSlbhNPTQp.YmrSFehdNCtvKNCtJDawJNsYiGDUA ymrSFehdNCtvKNCtJDawJNsYiGDUA = null;
			foreach (eKvbIyIaskPEHyGGYngSlbhNPTQp.YmrSFehdNCtvKNCtJDawJNsYiGDUA item in RqMXeOadpCIqgAtrvBXWTZHtlghn.TdHejplphLTqzIDALRcVprPOeXvc(olpHasFnmtCOEUrNnellhAsOhXwC, P_2))
			{
				if (!FCPgJMIemtfvCTWuTlOUUgKcBOph(P_1, item.bQngJlUKgursDloDrffVFkVDLQMH) && item.JKMgiVaOAznihzAeXAmUiuUIlTlo >= 0)
				{
					ymrSFehdNCtvKNCtJDawJNsYiGDUA = item;
					break;
				}
			}
			if (ymrSFehdNCtvKNCtJDawJNsYiGDUA != null)
			{
				int num = ymrSFehdNCtvKNCtJDawJNsYiGDUA.JKMgiVaOAznihzAeXAmUiuUIlTlo;
				if (!mBsLdoiZGOUvAkwljsOSyzUooygr(P_1, num))
				{
					num = (ymrSFehdNCtvKNCtJDawJNsYiGDUA.JKMgiVaOAznihzAeXAmUiuUIlTlo = nLVSflXgauMRnJZyogFwUQSULJkF(P_1));
				}
				olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = ymrSFehdNCtvKNCtJDawJNsYiGDUA.bQngJlUKgursDloDrffVFkVDLQMH;
				RqMXeOadpCIqgAtrvBXWTZHtlghn.KeoqQISCQZCXSiZfShFDxmuMzQCt(olpHasFnmtCOEUrNnellhAsOhXwC);
			}
		}
	}

	private void JOcEhkuNJwgNJfeyxWKwexzGSPt()
	{
		if (dxNdSggxGlezWBxfdCtTQVJMPuPI.skbXDgsRILNuHVBLXcapbmUVIcAZA(true))
		{
			qxNwxjojQeoBfMSsKZHxzfiTfoq = true;
		}
		if (qxNwxjojQeoBfMSsKZHxzfiTfoq)
		{
			uJGdLoJLTfvgaigQhorLdXArdieR();
		}
		if ((ywcBmZYbqUHoVfnkOhqlIBFiIAiEA || dxNdSggxGlezWBxfdCtTQVJMPuPI.TdXSyBPCyCbSaNSoknzfnCBNGuzV) && BqgKWCbyeJNchXVlkqPZlNGMLKeA.rYnfxXQpvqMpOJxdAcMymuXfVPdJ && BqgKWCbyeJNchXVlkqPZlNGMLKeA.hRRQBhRlrNLlIwAAvCWMAegGhfdIA())
		{
			FOYpajjlNWUGrKbBbfshnKkhVEuh();
		}
	}

	private void uJGdLoJLTfvgaigQhorLdXArdieR()
	{
		qxNwxjojQeoBfMSsKZHxzfiTfoq = false;
		if (!BqgKWCbyeJNchXVlkqPZlNGMLKeA.rYnfxXQpvqMpOJxdAcMymuXfVPdJ)
		{
			dxNdSggxGlezWBxfdCtTQVJMPuPI.ecrZrbRAwjDGUtDDBknusjrvbPom();
			BqgKWCbyeJNchXVlkqPZlNGMLKeA.ZRNxDcQZRiFYRKxfnaKLNAFnscDt();
		}
	}

	private void FOYpajjlNWUGrKbBbfshnKkhVEuh()
	{
		dxNdSggxGlezWBxfdCtTQVJMPuPI.PYmuhUXlKkGikOnoUvxKPxCBgRUK();
		if (ywcBmZYbqUHoVfnkOhqlIBFiIAiEA)
		{
			IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> list = cTWtopskXmvjqYyJHgYqdSpMtJKF();
			if (tGaagsMmUvEycigLyfDcqgbQdsudA(list))
			{
				PkQlGFLCZMcLPfOUUPKMGrBnxOtKA(list);
			}
		}
	}

	private bool tGaagsMmUvEycigLyfDcqgbQdsudA(IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> P_0)
	{
		for (int i = 0; i < bKRHIYBdVeXXrluOubfLsBODbnGY.Count; i++)
		{
			if (bKRHIYBdVeXXrluOubfLsBODbnGY[i] != null && !bKRHIYBdVeXXrluOubfLsBODbnGY[i].bhllbXTIkeUoBsrAyigPVToNFLKI)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !jonOmZEXBdkMZpzLXFiSjxaFBJnT(P_0[j].EHQHtNNrxlMzreeTogiAPPIWcpqC))
			{
				return true;
			}
		}
		int count2 = bKRHIYBdVeXXrluOubfLsBODbnGY.Count;
		for (int k = 0; k < count2; k++)
		{
			if (bKRHIYBdVeXXrluOubfLsBODbnGY[k] != null && !rRHZkCztZdmlkazfGTokFlQMOZYt(P_0, bKRHIYBdVeXXrluOubfLsBODbnGY[k].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	private bool jonOmZEXBdkMZpzLXFiSjxaFBJnT(Guid P_0)
	{
		int count = bKRHIYBdVeXXrluOubfLsBODbnGY.Count;
		for (int i = 0; i < count; i++)
		{
			if (bKRHIYBdVeXXrluOubfLsBODbnGY[i] != null && bKRHIYBdVeXXrluOubfLsBODbnGY[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool rRHZkCztZdmlkazfGTokFlQMOZYt(IList<zvOGxcHsUJhuDsNyEaqXAYZbfPfCB> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].EHQHtNNrxlMzreeTogiAPPIWcpqC == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void gUeMhyANjrPwOKcgBLiuQpRuNLbY(List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_0, List<OlpHasFnmtCOEUrNnellhAsOhXwC> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC = P_0[i];
			if (olpHasFnmtCOEUrNnellhAsOhXwC == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					OlpHasFnmtCOEUrNnellhAsOhXwC olpHasFnmtCOEUrNnellhAsOhXwC2 = P_1[j];
					if (olpHasFnmtCOEUrNnellhAsOhXwC2 != null && olpHasFnmtCOEUrNnellhAsOhXwC.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == olpHasFnmtCOEUrNnellhAsOhXwC2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				IODreFhLbEUXZVxBSBUYzfPgBsfS(P_0[i], P_2);
			}
		}
	}

	private void IODreFhLbEUXZVxBSBUYzfPgBsfS(OlpHasFnmtCOEUrNnellhAsOhXwC P_0, bool P_1)
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

	private bool TzwWKVwtyOcwwYqtUrYufEkaYaJf()
	{
		try
		{
			int num = 0;
			nSXuRAqOTwCZXyXcDRQCJHZOFUUJ.dRAFwmWlfgokPyRuvPJxXxriEehQ(null, ref num, VRhfcElUYIDhtSYXXbsQDsFMgObb.SMbLtcBgTmiVeQQXRwhsKdNWLAkr<AicfiLBzLnbLmEahFvhGePZzVboqb>());
			if (NWJOcxVJHPWFAcaMEpLXicvycLHK != num)
			{
				NWJOcxVJHPWFAcaMEpLXicvycLHK = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (LOrJHYepiXtZqWHqBuomujOrGbMt > 0 && dxNdSggxGlezWBxfdCtTQVJMPuPI.HSHUYEwFgEGTtCCvaFzZcUGKzedf())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void OCDAtFoUteMjSBaAlPhaHlLaubSI(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void cOYIRJJthHxsvbAGkqehxfKiEuGV(OlpHasFnmtCOEUrNnellhAsOhXwC P_0)
	{
		IODreFhLbEUXZVxBSBUYzfPgBsfS(P_0, false);
	}
}
