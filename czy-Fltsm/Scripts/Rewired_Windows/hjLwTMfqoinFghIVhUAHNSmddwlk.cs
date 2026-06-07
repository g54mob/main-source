using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class hjLwTMfqoinFghIVhUAHNSmddwlk : PlatformInputManager
{
	private class TKfHGTtEUQNcnNSOKlmDEDECjdpe : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int scqUVVHrvlbvXbcVkhYEAMnIcrPE;

		private int BbbYavcjOkZGtRMyEwTVMvijqdyq;

		public Guid HCPUYJezdjhWJurPOUXqZJQHwprP;

		public string zpgJsamrphhcUgxnXELQVGnngXhO;

		public TrKPVSrmRjdoziVhIIYQgcCFPMlEB iPkUeRtJUlalUclmExYdAMXCpvWdb;

		public nteZwwonWclXlbKGnLfBqdoXbiQr wJmypQBeugKffUDrEUkOfPuVpHWB;

		public string jFioqxDeRaApjvRmpVDzHSqPiwuv;

		public string EvfqJIBcxhGnaVAGzSXKkKCDRjJO;

		public int mCJsoBBKuXXGSXKeSRxlbsbUDVjR;

		public int rvUQoTJcAPuryBjjaGwBFWVeYeLwA;

		public Guid QnYYlliVZFddzWoxJUtEXRizdCWN;

		public PidVid zFxSCwYEDdSPlZHudxioYDFCuqtS;

		public Guid yrhJYtxysWlcSuezCfpXLEWabaoFA;

		public int BoAILnnTUHAqRleLluQugFIdDAyh;

		public int cRYdRQXYLMmDzzfLmaCAdquMCPGZ;

		public int FuIAKhLRQnmTMepPJbFmBjjrnoZGb;

		public int CXQzQMQGCfpToCUQlqFradSpdIpA;

		public int EaDnIVazCYTEIoDHQiLraAAVoHrGA;

		public int EiDmBhLBHQYVGOGFnbhAChyVBHpCA;

		public bool nMIiXfImvvheBZzLIxBaapNjuNQq;

		public bool WhbemcMbzsegEwqLhrnntDFBNXVs;

		public int RrkXoAryJDghogpOspIqQrsfPjYy;

		private float[] BcGgSbkUzqPxXUQNbdDbbcTOKjcFA;

		private bool[] PpnAMgacAICxiQhvWbcPzHWwtbKUA;

		private HardwareJoystickMap_InputManager oFnFfhHEwiNwngPwclhsjCkuEtdTA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZnEtyFEAXezZPKRcMiKnBnPSdKco;

		private bool uTowxzBerIHNHpbBQGCARFcbJHoeA;

		private bool ftCwYpEYJccvKSYyIIunGJodlTnR;

		[CompilerGenerated]
		private Controller.Extension yhpOUWwEIcbUiNUiYZvbAcuwDuoL;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return scqUVVHrvlbvXbcVkhYEAMnIcrPE;
			}
			set
			{
				scqUVVHrvlbvXbcVkhYEAMnIcrPE = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return BbbYavcjOkZGtRMyEwTVMvijqdyq;
			}
			set
			{
				BbbYavcjOkZGtRMyEwTVMvijqdyq = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => zpgJsamrphhcUgxnXELQVGnngXhO;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (BbbYavcjOkZGtRMyEwTVMvijqdyq < 0)
				{
					return null;
				}
				return BbbYavcjOkZGtRMyEwTVMvijqdyq;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => QnYYlliVZFddzWoxJUtEXRizdCWN;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			[CompilerGenerated]
			get
			{
				return yhpOUWwEIcbUiNUiYZvbAcuwDuoL;
			}
			[CompilerGenerated]
			set
			{
				yhpOUWwEIcbUiNUiYZvbAcuwDuoL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			iPkUeRtJUlalUclmExYdAMXCpvWdb.IiopYRABEpuiympOgsZftwqWctLT(motorIndex, amount, false);
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

		public TKfHGTtEUQNcnNSOKlmDEDECjdpe(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			ZnEtyFEAXezZPKRcMiKnBnPSdKco = P_0;
			BbbYavcjOkZGtRMyEwTVMvijqdyq = -1;
			scqUVVHrvlbvXbcVkhYEAMnIcrPE = -1;
		}

		public void pWvmvYCmTlKTvVqvvlWsqSsKDYjv()
		{
			yrhJYtxysWlcSuezCfpXLEWabaoFA = MiscTools.CreateGuidHashSHA1(jFioqxDeRaApjvRmpVDzHSqPiwuv + zFxSCwYEDdSPlZHudxioYDFCuqtS.ToProductGuid().ToString());
			cRYdRQXYLMmDzzfLmaCAdquMCPGZ = CXQzQMQGCfpToCUQlqFradSpdIpA;
			FuIAKhLRQnmTMepPJbFmBjjrnoZGb = EaDnIVazCYTEIoDHQiLraAAVoHrGA + EiDmBhLBHQYVGOGFnbhAChyVBHpCA * 8;
			VPqqvzmrTnjqFgTpwjnlWVzPNeal();
			HCPUYJezdjhWJurPOUXqZJQHwprP = oFnFfhHEwiNwngPwclhsjCkuEtdTA.hardwareMapIdentifier.guid;
			zpgJsamrphhcUgxnXELQVGnngXhO = oFnFfhHEwiNwngPwclhsjCkuEtdTA.controllerName;
			uTowxzBerIHNHpbBQGCARFcbJHoeA = HCPUYJezdjhWJurPOUXqZJQHwprP == Guid.Empty;
			BcGgSbkUzqPxXUQNbdDbbcTOKjcFA = new float[cRYdRQXYLMmDzzfLmaCAdquMCPGZ];
			PpnAMgacAICxiQhvWbcPzHWwtbKUA = new bool[FuIAKhLRQnmTMepPJbFmBjjrnoZGb];
			Update();
		}

		public void XYbASjDxVdHqsWsJnWEaiYbFMwhV(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0)
		{
			if (P_0 != null)
			{
				BbbYavcjOkZGtRMyEwTVMvijqdyq = P_0.BbbYavcjOkZGtRMyEwTVMvijqdyq;
				scqUVVHrvlbvXbcVkhYEAMnIcrPE = P_0.scqUVVHrvlbvXbcVkhYEAMnIcrPE;
				for (int i = 0; i < MathTools.Min(PpnAMgacAICxiQhvWbcPzHWwtbKUA.Length, P_0.PpnAMgacAICxiQhvWbcPzHWwtbKUA.Length); i++)
				{
					PpnAMgacAICxiQhvWbcPzHWwtbKUA[i] = P_0.PpnAMgacAICxiQhvWbcPzHWwtbKUA[i];
				}
				for (int j = 0; j < MathTools.Min(BcGgSbkUzqPxXUQNbdDbbcTOKjcFA.Length, P_0.BcGgSbkUzqPxXUQNbdDbbcTOKjcFA.Length); j++)
				{
					BcGgSbkUzqPxXUQNbdDbbcTOKjcFA[j] = P_0.BcGgSbkUzqPxXUQNbdDbbcTOKjcFA[j];
				}
				ftCwYpEYJccvKSYyIIunGJodlTnR = P_0.ftCwYpEYJccvKSYyIIunGJodlTnR;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			PpJhcuovWczpAIRYOFuSNDiOkmUg();
			WSeoOPueQvfMBQdmPOPTpcMirTJM();
			if (!ftCwYpEYJccvKSYyIIunGJodlTnR && iPkUeRtJUlalUclmExYdAMXCpvWdb.qiUGHDGssgKOZZyzUCpdagcfngdzb)
			{
				ftCwYpEYJccvKSYyIIunGJodlTnR = true;
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
			if (cRYdRQXYLMmDzzfLmaCAdquMCPGZ != dataUpdater.axisCount || FuIAKhLRQnmTMepPJbFmBjjrnoZGb != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < cRYdRQXYLMmDzzfLmaCAdquMCPGZ; i++)
			{
				dataUpdater.axisValues[i] = BcGgSbkUzqPxXUQNbdDbbcTOKjcFA[i];
			}
			for (int j = 0; j < FuIAKhLRQnmTMepPJbFmBjjrnoZGb; j++)
			{
				dataUpdater.buttonValues[j] = PpnAMgacAICxiQhvWbcPzHWwtbKUA[j];
			}
			if (ftCwYpEYJccvKSYyIIunGJodlTnR && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int dtyZwHYhQWnKqzXeVSHuJFzLDwDo(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0)
		{
			if (P_0.scqUVVHrvlbvXbcVkhYEAMnIcrPE == scqUVVHrvlbvXbcVkhYEAMnIcrPE)
			{
				return 2;
			}
			if (CXQzQMQGCfpToCUQlqFradSpdIpA != P_0.CXQzQMQGCfpToCUQlqFradSpdIpA)
			{
				return 0;
			}
			if (EaDnIVazCYTEIoDHQiLraAAVoHrGA != P_0.EaDnIVazCYTEIoDHQiLraAAVoHrGA)
			{
				return 0;
			}
			if (EiDmBhLBHQYVGOGFnbhAChyVBHpCA != P_0.EiDmBhLBHQYVGOGFnbhAChyVBHpCA)
			{
				return 0;
			}
			if (P_0.QnYYlliVZFddzWoxJUtEXRizdCWN == QnYYlliVZFddzWoxJUtEXRizdCWN)
			{
				return 2;
			}
			if (P_0.yrhJYtxysWlcSuezCfpXLEWabaoFA == yrhJYtxysWlcSuezCfpXLEWabaoFA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo RVldlvlkqwVyKZfpVealtnrYjJJr()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			uQvmzQnedpEeNDbYlnqiBNNyRihEb(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			OcDUqQcnNIaoDLbJbiTtwCtsFaod(bridgedController);
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
			return new ControllerDisconnectedEventArgs(scqUVVHrvlbvXbcVkhYEAMnIcrPE);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void PpJhcuovWczpAIRYOFuSNDiOkmUg()
		{
			if (cRYdRQXYLMmDzzfLmaCAdquMCPGZ <= 0 || oFnFfhHEwiNwngPwclhsjCkuEtdTA.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)oFnFfhHEwiNwngPwclhsjCkuEtdTA.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					XqAdWTfUvqkhgDlFITexrtNomXNaB(axes_orig[i], i);
				}
			}
		}

		private void WSeoOPueQvfMBQdmPOPTpcMirTJM()
		{
			if (FuIAKhLRQnmTMepPJbFmBjjrnoZGb <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)oFnFfhHEwiNwngPwclhsjCkuEtdTA.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					oZeFbOlthzGyFuGSiyBFRsajyacr(buttons_orig[i], i);
				}
			}
		}

		private void XqAdWTfUvqkhgDlFITexrtNomXNaB(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= cRYdRQXYLMmDzzfLmaCAdquMCPGZ)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			BcGgSbkUzqPxXUQNbdDbbcTOKjcFA[P_1] = PKKgrXrjzvwQxzKlpWZqpXUlsrGC(P_0);
		}

		private void oZeFbOlthzGyFuGSiyBFRsajyacr(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= FuIAKhLRQnmTMepPJbFmBjjrnoZGb)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			PpnAMgacAICxiQhvWbcPzHWwtbKUA[P_1] = GhpKwSGmrdJSwopbPEKktosQKgdA(P_0);
		}

		private float PKKgrXrjzvwQxzKlpWZqpXUlsrGC(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= CXQzQMQGCfpToCUQlqFradSpdIpA || sourceAxis >= 56)
				{
					return 0f;
				}
				return iPkUeRtJUlalUclmExYdAMXCpvWdb.adYMMtrWXbAOxaSZxIPPKcFkQcpw(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= EaDnIVazCYTEIoDHQiLraAAVoHrGA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!iPkUeRtJUlalUclmExYdAMXCpvWdb.kPikCxtRPsPAvQzivejIPjmbKYoA(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= EiDmBhLBHQYVGOGFnbhAChyVBHpCA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = jROCvUbQwrQcEpGkNVkJeKmrJtBB(num, AxisDirection.Horizontal);
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
					num2 = jROCvUbQwrQcEpGkNVkJeKmrJtBB(num, AxisDirection.Vertical);
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

		private bool GhpKwSGmrdJSwopbPEKktosQKgdA(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (iPkUeRtJUlalUclmExYdAMXCpvWdb.kPikCxtRPsPAvQzivejIPjmbKYoA(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!iPkUeRtJUlalUclmExYdAMXCpvWdb.kPikCxtRPsPAvQzivejIPjmbKYoA(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= EaDnIVazCYTEIoDHQiLraAAVoHrGA || sourceButton >= 256)
				{
					return false;
				}
				return iPkUeRtJUlalUclmExYdAMXCpvWdb.kPikCxtRPsPAvQzivejIPjmbKYoA(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= CXQzQMQGCfpToCUQlqFradSpdIpA || sourceAxis >= 56)
				{
					return false;
				}
				float num = iPkUeRtJUlalUclmExYdAMXCpvWdb.adYMMtrWXbAOxaSZxIPPKcFkQcpw(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= EiDmBhLBHQYVGOGFnbhAChyVBHpCA || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return FUUisVyEzENClXfKqWDhaADfczb(iPkUeRtJUlalUclmExYdAMXCpvWdb.SMOJphAqcrCxBtcUYCDrQycZdeTE(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool FUUisVyEzENClXfKqWDhaADfczb(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (oFnFfhHEwiNwngPwclhsjCkuEtdTA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float jROCvUbQwrQcEpGkNVkJeKmrJtBB(int P_0, AxisDirection P_1)
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

		private ControlDeviceType PHkEabPkAVxtXzKNbQZJEHjyuPhA(nteZwwonWclXlbKGnLfBqdoXbiQr P_0)
		{
			return P_0 switch
			{
				nteZwwonWclXlbKGnLfBqdoXbiQr.Joystick => ControlDeviceType.Joystick, 
				nteZwwonWclXlbKGnLfBqdoXbiQr.Gamepad => ControlDeviceType.Gamepad, 
				nteZwwonWclXlbKGnLfBqdoXbiQr.Keyboard => ControlDeviceType.Keyboard, 
				nteZwwonWclXlbKGnLfBqdoXbiQr.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void VPqqvzmrTnjqFgTpwjnlWVzPNeal()
		{
			oFnFfhHEwiNwngPwclhsjCkuEtdTA = ZnEtyFEAXezZPKRcMiKnBnPSdKco(RVldlvlkqwVyKZfpVealtnrYjJJr());
			if (oFnFfhHEwiNwngPwclhsjCkuEtdTA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (oFnFfhHEwiNwngPwclhsjCkuEtdTA.useSystemName)
			{
				if (!string.IsNullOrEmpty(EvfqJIBcxhGnaVAGzSXKkKCDRjJO))
				{
					string text = Regex.Replace(EvfqJIBcxhGnaVAGzSXKkKCDRjJO, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						oFnFfhHEwiNwngPwclhsjCkuEtdTA.controllerName = text;
					}
				}
				if (oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", iPkUeRtJUlalUclmExYdAMXCpvWdb.EOoAFsIqXBDxENMUTOCJoXIKlcrn.vendorId.ToString("x4"), iPkUeRtJUlalUclmExYdAMXCpvWdb.EOoAFsIqXBDxENMUTOCJoXIKlcrn.productId.ToString("x4"));
					oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(iPkUeRtJUlalUclmExYdAMXCpvWdb.VSljtfpqwMcLQszZUApCPLLNeeKn))
					{
						oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, iPkUeRtJUlalUclmExYdAMXCpvWdb.VSljtfpqwMcLQszZUApCPLLNeeKn));
					}
					if (!string.IsNullOrEmpty(iPkUeRtJUlalUclmExYdAMXCpvWdb.VSljtfpqwMcLQszZUApCPLLNeeKn))
					{
						oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.additionalIdentifyingInformation = $"{iPkUeRtJUlalUclmExYdAMXCpvWdb.VSljtfpqwMcLQszZUApCPLLNeeKn} [{text2}]";
					}
					else
					{
						oFnFfhHEwiNwngPwclhsjCkuEtdTA.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			cRYdRQXYLMmDzzfLmaCAdquMCPGZ = oFnFfhHEwiNwngPwclhsjCkuEtdTA.axisCount;
			FuIAKhLRQnmTMepPJbFmBjjrnoZGb = oFnFfhHEwiNwngPwclhsjCkuEtdTA.buttonCount;
		}

		private string LMkLNtEJCCPKfBHMGXgKfHIEZAxo()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{iPkUeRtJUlalUclmExYdAMXCpvWdb.JrpQuUxGNhIKRVrVUnBsaCQqRtI}{jFioqxDeRaApjvRmpVDzHSqPiwuv}{mCJsoBBKuXXGSXKeSRxlbsbUDVjR}{zFxSCwYEDdSPlZHudxioYDFCuqtS.ToProductGuid()}");
		}

		private void uQvmzQnedpEeNDbYlnqiBNNyRihEb(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = iPkUeRtJUlalUclmExYdAMXCpvWdb.JrpQuUxGNhIKRVrVUnBsaCQqRtI;
			P_0.deviceType = PHkEabPkAVxtXzKNbQZJEHjyuPhA(wJmypQBeugKffUDrEUkOfPuVpHWB);
			P_0.hardwareIdentifier = LMkLNtEJCCPKfBHMGXgKfHIEZAxo();
			P_0.hardwareAxisCount = CXQzQMQGCfpToCUQlqFradSpdIpA;
			P_0.hardwareButtonCount = EaDnIVazCYTEIoDHQiLraAAVoHrGA;
			P_0.hardwareHatCount = EiDmBhLBHQYVGOGFnbhAChyVBHpCA;
			P_0.hw_productName = jFioqxDeRaApjvRmpVDzHSqPiwuv;
			P_0.hw_deviceGuid = QnYYlliVZFddzWoxJUtEXRizdCWN;
			P_0.hw_productId = mCJsoBBKuXXGSXKeSRxlbsbUDVjR;
			P_0.hw_pidVid = zFxSCwYEDdSPlZHudxioYDFCuqtS;
			P_0.hw_isBluetoothDevice = nMIiXfImvvheBZzLIxBaapNjuNQq;
			P_0.hw_bluetoothDeviceName = jFioqxDeRaApjvRmpVDzHSqPiwuv;
			P_0.hw_systemDeviceName = jFioqxDeRaApjvRmpVDzHSqPiwuv;
			P_0.hw_supportsVibration = WhbemcMbzsegEwqLhrnntDFBNXVs;
			P_0.hw_isSDL2Gamepad = iPkUeRtJUlalUclmExYdAMXCpvWdb.JHddNFJxkKejzGyAVdnYzQZTxxxu == nteZwwonWclXlbKGnLfBqdoXbiQr.Gamepad;
			P_0.hw_localVibrationMotorCount = RrkXoAryJDghogpOspIqQrsfPjYy;
		}

		private void OcDUqQcnNIaoDLbJbiTtwCtsFaod(BridgedController P_0)
		{
			uQvmzQnedpEeNDbYlnqiBNNyRihEb(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = oFnFfhHEwiNwngPwclhsjCkuEtdTA.ToGameHardwareControllerMap();
			P_0.instanceName = jFioqxDeRaApjvRmpVDzHSqPiwuv;
			P_0.productName = jFioqxDeRaApjvRmpVDzHSqPiwuv;
			P_0.axisCount = cRYdRQXYLMmDzzfLmaCAdquMCPGZ;
			P_0.buttonCount = FuIAKhLRQnmTMepPJbFmBjjrnoZGb;
			P_0.unknownControllerHats = XtBfOEgsxKZEOVdGhgTDmUTjceJG();
			P_0.controllerTypeGuid = HCPUYJezdjhWJurPOUXqZJQHwprP;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void yhTSVvbVkewrqXXkNwSmeYCMioWs()
		{
			for (int i = 0; i < FuIAKhLRQnmTMepPJbFmBjjrnoZGb; i++)
			{
				PpnAMgacAICxiQhvWbcPzHWwtbKUA[i] = false;
			}
			for (int j = 0; j < cRYdRQXYLMmDzzfLmaCAdquMCPGZ; j++)
			{
				BcGgSbkUzqPxXUQNbdDbbcTOKjcFA[j] = 0f;
			}
		}

		private UnknownControllerHat[] XtBfOEgsxKZEOVdGhgTDmUTjceJG()
		{
			if (!uTowxzBerIHNHpbBQGCARFcbJHoeA)
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

		public static int yKeGEUPesrSSECBaUEMRHFqIxZzx(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, TKfHGTtEUQNcnNSOKlmDEDECjdpe P_1)
		{
			if (P_0.BbbYavcjOkZGtRMyEwTVMvijqdyq < P_1.BbbYavcjOkZGtRMyEwTVMvijqdyq)
			{
				return -1;
			}
			if (P_0.BbbYavcjOkZGtRMyEwTVMvijqdyq > P_1.BbbYavcjOkZGtRMyEwTVMvijqdyq)
			{
				return 1;
			}
			return 0;
		}

		public static int BaCRiMxZqZJQfZzUikcRrfTFecJq(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, TKfHGTtEUQNcnNSOKlmDEDECjdpe P_1)
		{
			if (P_0.BoAILnnTUHAqRleLluQugFIdDAyh < P_1.BoAILnnTUHAqRleLluQugFIdDAyh)
			{
				return -1;
			}
			if (P_0.BoAILnnTUHAqRleLluQugFIdDAyh > P_1.BoAILnnTUHAqRleLluQugFIdDAyh)
			{
				return 1;
			}
			return 0;
		}
	}

	private class XUJpoJNUkjceIPpFIobwgWXEMDRi
	{
		public enum lqDHQniyFmiRBUPfZjuzGHcPeEAhA
		{
			Exact = 0,
			Approximate = 1
		}

		public class uYcHkkwIsabhfaynBbOEbARDuHIY
		{
			public int IERGuEcSdxTyRYsseFcZuDoMEayL;

			public Guid HfYYpWDdlbrPaLkRlIjwDMGfXOoQ;

			public Guid mxVRjPKuJjPspfGIPYKmdinDUHpI;

			public int nrueisZrPAQWMOsFSZYXasOigWnC;

			public int fnEPMxDQuTLqUJkKjdASCFYqNrrUA;

			public int gHYHUUMJGgZIuSHzVucCAgRAjOcT;

			public int nntkPsIhpcDgVcQnFsQwwyhHWGNTA;

			public bool cnTDvjKdOwAVehLNmYhdiwuFbQeD(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, lqDHQniyFmiRBUPfZjuzGHcPeEAhA P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == IERGuEcSdxTyRYsseFcZuDoMEayL)
				{
					return true;
				}
				if (fnEPMxDQuTLqUJkKjdASCFYqNrrUA != P_0.CXQzQMQGCfpToCUQlqFradSpdIpA)
				{
					return false;
				}
				if (gHYHUUMJGgZIuSHzVucCAgRAjOcT != P_0.EaDnIVazCYTEIoDHQiLraAAVoHrGA)
				{
					return false;
				}
				if (nntkPsIhpcDgVcQnFsQwwyhHWGNTA != P_0.EiDmBhLBHQYVGOGFnbhAChyVBHpCA)
				{
					return false;
				}
				return P_1 switch
				{
					lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Exact => HfYYpWDdlbrPaLkRlIjwDMGfXOoQ == P_0.QnYYlliVZFddzWoxJUtEXRizdCWN, 
					lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Approximate => mxVRjPKuJjPspfGIPYKmdinDUHpI == P_0.yrhJYtxysWlcSuezCfpXLEWabaoFA, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class LkfOCqHlOYZaYEfPQSZxAwwXNBnF : IEnumerable<uYcHkkwIsabhfaynBbOEbARDuHIY>, IEnumerable, IEnumerator<uYcHkkwIsabhfaynBbOEbARDuHIY>, IEnumerator, IDisposable
		{
			private int WJQUCqpoTioWezUkndMNsADrNexQ;

			private uYcHkkwIsabhfaynBbOEbARDuHIY uIpXaOrLFmPvZLTWSbkETfdBbWsN;

			private int eDoEVooQJJKZbmlKEKuApqsvPxoG;

			public XUJpoJNUkjceIPpFIobwgWXEMDRi VjcOLHBmkQgXFSTKQSCSAnlTTZFH;

			private TKfHGTtEUQNcnNSOKlmDEDECjdpe qgGFlNAeujXPXuGDaJBgxZiBIsro;

			public TKfHGTtEUQNcnNSOKlmDEDECjdpe gUPtosmHDOehAIFvSmNieINXpDuy;

			private lqDHQniyFmiRBUPfZjuzGHcPeEAhA talecBkGUTrSSoTuEpJFNTIpXoUSA;

			public lqDHQniyFmiRBUPfZjuzGHcPeEAhA QQOVzKDvNPmcjrMgpnJrFLKraKAgA;

			private int jGfGjQjjBzSbgqSmYXwBZdrDqWIc;

			private int knHkDeBHCdbANLFQExTnkQcYDkaS;

			uYcHkkwIsabhfaynBbOEbARDuHIY IEnumerator<uYcHkkwIsabhfaynBbOEbARDuHIY>.Current
			{
				[DebuggerHidden]
				get
				{
					return uIpXaOrLFmPvZLTWSbkETfdBbWsN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return uIpXaOrLFmPvZLTWSbkETfdBbWsN;
				}
			}

			[DebuggerHidden]
			public LkfOCqHlOYZaYEfPQSZxAwwXNBnF(int P_0)
			{
				WJQUCqpoTioWezUkndMNsADrNexQ = P_0;
				eDoEVooQJJKZbmlKEKuApqsvPxoG = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				WJQUCqpoTioWezUkndMNsADrNexQ = -2;
			}

			private bool MoveNext()
			{
				int wJQUCqpoTioWezUkndMNsADrNexQ = WJQUCqpoTioWezUkndMNsADrNexQ;
				XUJpoJNUkjceIPpFIobwgWXEMDRi vjcOLHBmkQgXFSTKQSCSAnlTTZFH = VjcOLHBmkQgXFSTKQSCSAnlTTZFH;
				if (wJQUCqpoTioWezUkndMNsADrNexQ != 0)
				{
					if (wJQUCqpoTioWezUkndMNsADrNexQ != 1)
					{
						return false;
					}
					WJQUCqpoTioWezUkndMNsADrNexQ = -1;
					goto IL_0083;
				}
				WJQUCqpoTioWezUkndMNsADrNexQ = -1;
				jGfGjQjjBzSbgqSmYXwBZdrDqWIc = vjcOLHBmkQgXFSTKQSCSAnlTTZFH.xPnGYofQTvHaqGflCpvjasPDajNFc.Count;
				knHkDeBHCdbANLFQExTnkQcYDkaS = 0;
				goto IL_0093;
				IL_0083:
				knHkDeBHCdbANLFQExTnkQcYDkaS++;
				goto IL_0093;
				IL_0093:
				if (knHkDeBHCdbANLFQExTnkQcYDkaS < jGfGjQjjBzSbgqSmYXwBZdrDqWIc)
				{
					if (vjcOLHBmkQgXFSTKQSCSAnlTTZFH.xPnGYofQTvHaqGflCpvjasPDajNFc[knHkDeBHCdbANLFQExTnkQcYDkaS].cnTDvjKdOwAVehLNmYhdiwuFbQeD(qgGFlNAeujXPXuGDaJBgxZiBIsro, talecBkGUTrSSoTuEpJFNTIpXoUSA))
					{
						uIpXaOrLFmPvZLTWSbkETfdBbWsN = vjcOLHBmkQgXFSTKQSCSAnlTTZFH.xPnGYofQTvHaqGflCpvjasPDajNFc[knHkDeBHCdbANLFQExTnkQcYDkaS];
						WJQUCqpoTioWezUkndMNsADrNexQ = 1;
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
			IEnumerator<uYcHkkwIsabhfaynBbOEbARDuHIY> IEnumerable<uYcHkkwIsabhfaynBbOEbARDuHIY>.GetEnumerator()
			{
				LkfOCqHlOYZaYEfPQSZxAwwXNBnF lkfOCqHlOYZaYEfPQSZxAwwXNBnF;
				if (WJQUCqpoTioWezUkndMNsADrNexQ == -2 && eDoEVooQJJKZbmlKEKuApqsvPxoG == Environment.CurrentManagedThreadId)
				{
					WJQUCqpoTioWezUkndMNsADrNexQ = 0;
					lkfOCqHlOYZaYEfPQSZxAwwXNBnF = this;
				}
				else
				{
					lkfOCqHlOYZaYEfPQSZxAwwXNBnF = new LkfOCqHlOYZaYEfPQSZxAwwXNBnF(0);
					lkfOCqHlOYZaYEfPQSZxAwwXNBnF.VjcOLHBmkQgXFSTKQSCSAnlTTZFH = VjcOLHBmkQgXFSTKQSCSAnlTTZFH;
				}
				lkfOCqHlOYZaYEfPQSZxAwwXNBnF.qgGFlNAeujXPXuGDaJBgxZiBIsro = gUPtosmHDOehAIFvSmNieINXpDuy;
				lkfOCqHlOYZaYEfPQSZxAwwXNBnF.talecBkGUTrSSoTuEpJFNTIpXoUSA = QQOVzKDvNPmcjrMgpnJrFLKraKAgA;
				return lkfOCqHlOYZaYEfPQSZxAwwXNBnF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<uYcHkkwIsabhfaynBbOEbARDuHIY>)this).GetEnumerator();
			}
		}

		private List<uYcHkkwIsabhfaynBbOEbARDuHIY> xPnGYofQTvHaqGflCpvjasPDajNFc;

		public XUJpoJNUkjceIPpFIobwgWXEMDRi()
		{
			xPnGYofQTvHaqGflCpvjasPDajNFc = new List<uYcHkkwIsabhfaynBbOEbARDuHIY>();
		}

		public void JtGFYduCmIBEaUUccHnSDrOXhZVP(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = xPnGYofQTvHaqGflCpvjasPDajNFc.Count;
			for (int i = 0; i < count; i++)
			{
				if (xPnGYofQTvHaqGflCpvjasPDajNFc[i].cnTDvjKdOwAVehLNmYhdiwuFbQeD(P_0, lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Exact))
				{
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].IERGuEcSdxTyRYsseFcZuDoMEayL = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].HfYYpWDdlbrPaLkRlIjwDMGfXOoQ = P_0.QnYYlliVZFddzWoxJUtEXRizdCWN;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].mxVRjPKuJjPspfGIPYKmdinDUHpI = P_0.yrhJYtxysWlcSuezCfpXLEWabaoFA;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].nrueisZrPAQWMOsFSZYXasOigWnC = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].fnEPMxDQuTLqUJkKjdASCFYqNrrUA = P_0.CXQzQMQGCfpToCUQlqFradSpdIpA;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].gHYHUUMJGgZIuSHzVucCAgRAjOcT = P_0.EaDnIVazCYTEIoDHQiLraAAVoHrGA;
					xPnGYofQTvHaqGflCpvjasPDajNFc[i].nntkPsIhpcDgVcQnFsQwwyhHWGNTA = P_0.EiDmBhLBHQYVGOGFnbhAChyVBHpCA;
					xOJGIefDNWSnNlLTvWggnnCCfyvYA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.QnYYlliVZFddzWoxJUtEXRizdCWN, i);
					return;
				}
			}
			xPnGYofQTvHaqGflCpvjasPDajNFc.Add(new uYcHkkwIsabhfaynBbOEbARDuHIY
			{
				IERGuEcSdxTyRYsseFcZuDoMEayL = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				HfYYpWDdlbrPaLkRlIjwDMGfXOoQ = P_0.QnYYlliVZFddzWoxJUtEXRizdCWN,
				mxVRjPKuJjPspfGIPYKmdinDUHpI = P_0.yrhJYtxysWlcSuezCfpXLEWabaoFA,
				nrueisZrPAQWMOsFSZYXasOigWnC = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				fnEPMxDQuTLqUJkKjdASCFYqNrrUA = P_0.CXQzQMQGCfpToCUQlqFradSpdIpA,
				gHYHUUMJGgZIuSHzVucCAgRAjOcT = P_0.EaDnIVazCYTEIoDHQiLraAAVoHrGA,
				nntkPsIhpcDgVcQnFsQwwyhHWGNTA = P_0.EiDmBhLBHQYVGOGFnbhAChyVBHpCA
			});
			xOJGIefDNWSnNlLTvWggnnCCfyvYA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.QnYYlliVZFddzWoxJUtEXRizdCWN, xPnGYofQTvHaqGflCpvjasPDajNFc.Count - 1);
		}

		public bool JnVFBbdZpseNykCplMDIsoETCqMWA(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, lqDHQniyFmiRBUPfZjuzGHcPeEAhA P_1)
		{
			int count = xPnGYofQTvHaqGflCpvjasPDajNFc.Count;
			for (int i = 0; i < count; i++)
			{
				if (xPnGYofQTvHaqGflCpvjasPDajNFc[i].cnTDvjKdOwAVehLNmYhdiwuFbQeD(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(LkfOCqHlOYZaYEfPQSZxAwwXNBnF))]
		public IEnumerable<uYcHkkwIsabhfaynBbOEbARDuHIY> fGgCrqExIoNgabHgCGcjFaIAdItYb(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, lqDHQniyFmiRBUPfZjuzGHcPeEAhA P_1)
		{
			return new LkfOCqHlOYZaYEfPQSZxAwwXNBnF(-2)
			{
				VjcOLHBmkQgXFSTKQSCSAnlTTZFH = this,
				gUPtosmHDOehAIFvSmNieINXpDuy = P_0,
				QQOVzKDvNPmcjrMgpnJrFLKraKAgA = P_1
			};
		}

		private void xOJGIefDNWSnNlLTvWggnnCCfyvYA(int P_0, Guid P_1, int P_2)
		{
			for (int num = xPnGYofQTvHaqGflCpvjasPDajNFc.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (xPnGYofQTvHaqGflCpvjasPDajNFc[num].IERGuEcSdxTyRYsseFcZuDoMEayL == P_0 || xPnGYofQTvHaqGflCpvjasPDajNFc[num].HfYYpWDdlbrPaLkRlIjwDMGfXOoQ == P_1))
				{
					xPnGYofQTvHaqGflCpvjasPDajNFc.RemoveAt(num);
				}
			}
		}
	}

	internal const bool mGugteCSSXLAjJWpWavvahmfgMsWB = true;

	private IInputSource JYIZrxEMaAGkbCXULpPFStiVOATEb;

	private List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> IfbGzOEgkYIJwYORArNjJOhXTDVdA;

	private int MLfIlQBGvfaPiozjZFWERSeBcFQC;

	private XUJpoJNUkjceIPpFIobwgWXEMDRi gOIpZOYYsYHbCsOiTHxkAwWzIYUqA;

	private bool ZknptpOJKRaaBTPCbHreMQAAjefj;

	private Action<int, ControllerDataUpdater> VcMoZPRsYerOGQsWvfavGHISGMBCA;

	private PlatformInputManager XkSxBCrHlNUKSaySnLmVBujMhuor;

	private readonly bool iFJJcxAXsRHWKwyzrulThyGrwmQs;

	private readonly bool ccCLeJfagNqOkGXVhmVMMQrROhdo;

	private readonly bool sMNgYwDgXksJkFQSKXMwODEMDffDb;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NpxTdxanBOtVxBLqJWaVhdIAvIdn;

	private readonly Func<int> LaVtOdIFUqXQAQliTAxIkMTWgjGq;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => MLfIlQBGvfaPiozjZFWERSeBcFQC;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => XkSxBCrHlNUKSaySnLmVBujMhuor;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => JYIZrxEMaAGkbCXULpPFStiVOATEb;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.SDL2;

	public hjLwTMfqoinFghIVhUAHNSmddwlk(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			NpxTdxanBOtVxBLqJWaVhdIAvIdn = P_1;
			LaVtOdIFUqXQAQliTAxIkMTWgjGq = P_2;
			iFJJcxAXsRHWKwyzrulThyGrwmQs = P_3;
			ccCLeJfagNqOkGXVhmVMMQrROhdo = P_4;
			sMNgYwDgXksJkFQSKXMwODEMDffDb = P_5;
			XkSxBCrHlNUKSaySnLmVBujMhuor = this;
			JYIZrxEMaAGkbCXULpPFStiVOATEb = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			VcMoZPRsYerOGQsWvfavGHISGMBCA = UpdateControllerData;
			JYIZrxEMaAGkbCXULpPFStiVOATEb.DeviceChangedEvent += hMBBRWCfMluoBPicswtcabtNsXIMA;
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
		if (iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			gOIpZOYYsYHbCsOiTHxkAwWzIYUqA = new XUJpoJNUkjceIPpFIobwgWXEMDRi();
			jxXnkVHpJgIfzODKsfwYuzRWYGWK();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (JYIZrxEMaAGkbCXULpPFStiVOATEb != null)
		{
			JYIZrxEMaAGkbCXULpPFStiVOATEb.Update();
		}
		if (iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			if (ZknptpOJKRaaBTPCbHreMQAAjefj)
			{
				AdZhRSjROblzuaYjpZgdKpzOMFDXA();
			}
			if (JYIZrxEMaAGkbCXULpPFStiVOATEb != null)
			{
				for (int i = 0; i < MLfIlQBGvfaPiozjZFWERSeBcFQC; i++)
				{
					IfbGzOEgkYIJwYORArNjJOhXTDVdA[i]?.iPkUeRtJUlalUclmExYdAMXCpvWdb.IGPYDzGlOcXVMjWKtKEvPHMXxSuw(updateLoop);
				}
				JYIZrxEMaAGkbCXULpPFStiVOATEb.UpdateDevices(updateLoop);
			}
			cXgyehwGwXeOLJsjvLEtvkrNTiIH();
			if (JYIZrxEMaAGkbCXULpPFStiVOATEb != null)
			{
				JYIZrxEMaAGkbCXULpPFStiVOATEb.UpdateFinished();
				for (int j = 0; j < MLfIlQBGvfaPiozjZFWERSeBcFQC; j++)
				{
					IfbGzOEgkYIJwYORArNjJOhXTDVdA[j]?.iPkUeRtJUlalUclmExYdAMXCpvWdb.kLenQhbybKTJyanKxeWeBwFJsGbV();
				}
			}
		}
		_ = ccCLeJfagNqOkGXVhmVMMQrROhdo;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (IfbGzOEgkYIJwYORArNjJOhXTDVdA != null)
		{
			int count = IfbGzOEgkYIJwYORArNjJOhXTDVdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (IfbGzOEgkYIJwYORArNjJOhXTDVdA[i] != null)
				{
					IfbGzOEgkYIJwYORArNjJOhXTDVdA[i].iPkUeRtJUlalUclmExYdAMXCpvWdb?.THAczxlNGeRpJTMGauBMvnteIDXq();
				}
			}
		}
		if (JYIZrxEMaAGkbCXULpPFStiVOATEb != null)
		{
			JYIZrxEMaAGkbCXULpPFStiVOATEb.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return VcMoZPRsYerOGQsWvfavGHISGMBCA;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			return;
		}
		for (int i = 0; i < MLfIlQBGvfaPiozjZFWERSeBcFQC; i++)
		{
			if (IfbGzOEgkYIJwYORArNjJOhXTDVdA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
			{
				IfbGzOEgkYIJwYORArNjJOhXTDVdA[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			ZknptpOJKRaaBTPCbHreMQAAjefj = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			ZknptpOJKRaaBTPCbHreMQAAjefj = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = iFJJcxAXsRHWKwyzrulThyGrwmQs;
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

	private void jxXnkVHpJgIfzODKsfwYuzRWYGWK()
	{
		HNUJMdfQkmSkkxbeDKeHsGMQFtPO(yKGekadJWtqZtsyFWkVMFHHzVlsCA());
	}

	private void HNUJMdfQkmSkkxbeDKeHsGMQFtPO(IList<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> P_0)
	{
		int num = 0;
		List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> ifbGzOEgkYIJwYORArNjJOhXTDVdA = IfbGzOEgkYIJwYORArNjJOhXTDVdA;
		int mLfIlQBGvfaPiozjZFWERSeBcFQC = MLfIlQBGvfaPiozjZFWERSeBcFQC;
		IfbGzOEgkYIJwYORArNjJOhXTDVdA = new List<TKfHGTtEUQNcnNSOKlmDEDECjdpe>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				TrKPVSrmRjdoziVhIIYQgcCFPMlEB trKPVSrmRjdoziVhIIYQgcCFPMlEB = P_0[i];
				TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe = new TKfHGTtEUQNcnNSOKlmDEDECjdpe(NpxTdxanBOtVxBLqJWaVhdIAvIdn);
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.iPkUeRtJUlalUclmExYdAMXCpvWdb = trKPVSrmRjdoziVhIIYQgcCFPMlEB;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.QnYYlliVZFddzWoxJUtEXRizdCWN = trKPVSrmRjdoziVhIIYQgcCFPMlEB.ibMvknppBrFxthUlcRzGMjahygXf;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.jFioqxDeRaApjvRmpVDzHSqPiwuv = trKPVSrmRjdoziVhIIYQgcCFPMlEB.VSljtfpqwMcLQszZUApCPLLNeeKn;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.EvfqJIBcxhGnaVAGzSXKkKCDRjJO = trKPVSrmRjdoziVhIIYQgcCFPMlEB.EdeTiNeZrpVARenUfGbVdmjvoXmXA;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.zFxSCwYEDdSPlZHudxioYDFCuqtS = trKPVSrmRjdoziVhIIYQgcCFPMlEB.EOoAFsIqXBDxENMUTOCJoXIKlcrn;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.mCJsoBBKuXXGSXKeSRxlbsbUDVjR = trKPVSrmRjdoziVhIIYQgcCFPMlEB.armLiiWmzxcEwQrAbbkPjtJlsElM;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.rvUQoTJcAPuryBjjaGwBFWVeYeLwA = trKPVSrmRjdoziVhIIYQgcCFPMlEB.XyhnfzLYeGToCLaLVpPwCLATcjJkA;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.wJmypQBeugKffUDrEUkOfPuVpHWB = trKPVSrmRjdoziVhIIYQgcCFPMlEB.JHddNFJxkKejzGyAVdnYzQZTxxxu;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.BoAILnnTUHAqRleLluQugFIdDAyh = trKPVSrmRjdoziVhIIYQgcCFPMlEB.VLrxPxqqvSxPgrFWHTzgDwaBTTVk;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.CXQzQMQGCfpToCUQlqFradSpdIpA = trKPVSrmRjdoziVhIIYQgcCFPMlEB.vBIcFajHEkjbWOhelLWRHEwkNJziA;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.EaDnIVazCYTEIoDHQiLraAAVoHrGA = trKPVSrmRjdoziVhIIYQgcCFPMlEB.NnltTiRkpYHDxZRVmrkGzEbRKoJD;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.EiDmBhLBHQYVGOGFnbhAChyVBHpCA = trKPVSrmRjdoziVhIIYQgcCFPMlEB.cCJWbfCVxqIhuckEztQHfiIuzrhH;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.nMIiXfImvvheBZzLIxBaapNjuNQq = trKPVSrmRjdoziVhIIYQgcCFPMlEB.DxOyuushYFOGNcfPaaESOcwVDGRL;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.WhbemcMbzsegEwqLhrnntDFBNXVs = trKPVSrmRjdoziVhIIYQgcCFPMlEB.tEqjjDXzrkUihiHefLNbSEYVoArG;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.RrkXoAryJDghogpOspIqQrsfPjYy = trKPVSrmRjdoziVhIIYQgcCFPMlEB.eBrBQdgVzGcCPIEqUMAqwAHpbXmzA;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension = trKPVSrmRjdoziVhIIYQgcCFPMlEB.ZpXotqKABUxbQQIpaxeHtMiKUgWj;
				trKPVSrmRjdoziVhIIYQgcCFPMlEB.XCCpKvVKRpipHJCBjEVmVDqiZkFi();
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.pWvmvYCmTlKTvVqvvlWsqSsKDYjv();
				IfbGzOEgkYIJwYORArNjJOhXTDVdA.Add(tKfHGTtEUQNcnNSOKlmDEDECjdpe);
				num++;
			}
		}
		MLfIlQBGvfaPiozjZFWERSeBcFQC = num;
		AHLBlahQaGRUiJlJHjcynlCYamlDA(mLfIlQBGvfaPiozjZFWERSeBcFQC, num, ifbGzOEgkYIJwYORArNjJOhXTDVdA, IfbGzOEgkYIJwYORArNjJOhXTDVdA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(IfbGzOEgkYIJwYORArNjJOhXTDVdA[j]));
			}
		}
		iaTKEOHpXqvaWHgirrnZpiGlwlPo(ifbGzOEgkYIJwYORArNjJOhXTDVdA, IfbGzOEgkYIJwYORArNjJOhXTDVdA, false);
		iaTKEOHpXqvaWHgirrnZpiGlwlPo(IfbGzOEgkYIJwYORArNjJOhXTDVdA, ifbGzOEgkYIJwYORArNjJOhXTDVdA, true);
	}

	private void cXgyehwGwXeOLJsjvLEtvkrNTiIH()
	{
		for (int i = 0; i < MLfIlQBGvfaPiozjZFWERSeBcFQC; i++)
		{
			IfbGzOEgkYIJwYORArNjJOhXTDVdA[i]?.Update();
		}
	}

	private bool GzOjbbxMVWanJcIOhbieYcOrIxuW(znMQMowGFzgnEgmTyiCeLUiqxgOd P_0)
	{
		try
		{
			return P_0.OeLfblcaEVdwcyydYjSzZRQLiDwM();
		}
		catch
		{
			return false;
		}
	}

	private IList<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> yKGekadJWtqZtsyFWkVMFHHzVlsCA()
	{
		return JYIZrxEMaAGkbCXULpPFStiVOATEb.GetJoysticks<TrKPVSrmRjdoziVhIIYQgcCFPMlEB>();
	}

	private void AHLBlahQaGRUiJlJHjcynlCYamlDA(int P_0, int P_1, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_2, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(TKfHGTtEUQNcnNSOKlmDEDECjdpe.BaCRiMxZqZJQfZzUikcRrfTFecJq);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			YeVWsSbSMRQZfkRFeSuYxNGFuMZN(P_1, P_3, P_0, P_2, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Exact);
			YeVWsSbSMRQZfkRFeSuYxNGFuMZN(P_1, P_3, P_0, P_2, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Approximate);
		}
		nKiepYmiDPZOUjvdWhOrHfjBiMCp(P_1, P_3, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Exact);
		nKiepYmiDPZOUjvdWhOrHfjBiMCp(P_1, P_3, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe = P_3[i];
			if (tKfHGTtEUQNcnNSOKlmDEDECjdpe != null && tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = lwsjVKTaywaJwcuAgTPmkNLKQqNDA(P_3);
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = LaVtOdIFUqXQAQliTAxIkMTWgjGq();
				gOIpZOYYsYHbCsOiTHxkAwWzIYUqA.JtGFYduCmIBEaUUccHnSDrOXhZVP(tKfHGTtEUQNcnNSOKlmDEDECjdpe);
			}
		}
		P_3.Sort(TKfHGTtEUQNcnNSOKlmDEDECjdpe.yKeGEUPesrSSECBaUEMRHFqIxZzx);
	}

	private void kqwBMocwyEJRhbkusmwxDKWdhchUA(List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_0, int P_1, int P_2)
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

	private bool BfEFfIjsckhKIuENvroaBQHaROGPA(List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_0, int P_1)
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

	private int lwsjVKTaywaJwcuAgTPmkNLKQqNDA(List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_0)
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

	private bool oGsdbnMmBVUDDdFgmfqJsvdqFhAJA(List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_0, int P_1)
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

	private void YeVWsSbSMRQZfkRFeSuYxNGFuMZN(int P_0, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_1, int P_2, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_3, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA P_4)
	{
		int num = ((P_4 != XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe = P_1[i];
			if (tKfHGTtEUQNcnNSOKlmDEDECjdpe == null || tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe2 = P_3[j];
				if (tKfHGTtEUQNcnNSOKlmDEDECjdpe2 != null && !oGsdbnMmBVUDDdFgmfqJsvdqFhAJA(P_1, tKfHGTtEUQNcnNSOKlmDEDECjdpe2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && tKfHGTtEUQNcnNSOKlmDEDECjdpe.dtyZwHYhQWnKqzXeVSHuJFzLDwDo(tKfHGTtEUQNcnNSOKlmDEDECjdpe2) >= num)
				{
					tKfHGTtEUQNcnNSOKlmDEDECjdpe.XYbASjDxVdHqsWsJnWEaiYbFMwhV(tKfHGTtEUQNcnNSOKlmDEDECjdpe2);
					gOIpZOYYsYHbCsOiTHxkAwWzIYUqA.JtGFYduCmIBEaUUccHnSDrOXhZVP(tKfHGTtEUQNcnNSOKlmDEDECjdpe);
				}
			}
		}
	}

	private void nKiepYmiDPZOUjvdWhOrHfjBiMCp(int P_0, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_1, XUJpoJNUkjceIPpFIobwgWXEMDRi.lqDHQniyFmiRBUPfZjuzGHcPeEAhA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe = P_1[i];
			if (tKfHGTtEUQNcnNSOKlmDEDECjdpe == null || tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			XUJpoJNUkjceIPpFIobwgWXEMDRi.uYcHkkwIsabhfaynBbOEbARDuHIY uYcHkkwIsabhfaynBbOEbARDuHIY = null;
			foreach (XUJpoJNUkjceIPpFIobwgWXEMDRi.uYcHkkwIsabhfaynBbOEbARDuHIY item in gOIpZOYYsYHbCsOiTHxkAwWzIYUqA.fGgCrqExIoNgabHgCGcjFaIAdItYb(tKfHGTtEUQNcnNSOKlmDEDECjdpe, P_2))
			{
				if (!oGsdbnMmBVUDDdFgmfqJsvdqFhAJA(P_1, item.IERGuEcSdxTyRYsseFcZuDoMEayL) && item.nrueisZrPAQWMOsFSZYXasOigWnC >= 0)
				{
					uYcHkkwIsabhfaynBbOEbARDuHIY = item;
					break;
				}
			}
			if (uYcHkkwIsabhfaynBbOEbARDuHIY != null)
			{
				int num = uYcHkkwIsabhfaynBbOEbARDuHIY.nrueisZrPAQWMOsFSZYXasOigWnC;
				if (!BfEFfIjsckhKIuENvroaBQHaROGPA(P_1, num))
				{
					num = (uYcHkkwIsabhfaynBbOEbARDuHIY.nrueisZrPAQWMOsFSZYXasOigWnC = lwsjVKTaywaJwcuAgTPmkNLKQqNDA(P_1));
				}
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				tKfHGTtEUQNcnNSOKlmDEDECjdpe.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = uYcHkkwIsabhfaynBbOEbARDuHIY.IERGuEcSdxTyRYsseFcZuDoMEayL;
				gOIpZOYYsYHbCsOiTHxkAwWzIYUqA.JtGFYduCmIBEaUUccHnSDrOXhZVP(tKfHGTtEUQNcnNSOKlmDEDECjdpe);
			}
		}
	}

	private void AdZhRSjROblzuaYjpZgdKpzOMFDXA()
	{
		IList<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> list = yKGekadJWtqZtsyFWkVMFHHzVlsCA();
		HNUJMdfQkmSkkxbeDKeHsGMQFtPO(list);
		ZknptpOJKRaaBTPCbHreMQAAjefj = false;
	}

	private bool jCAZhOjjxFlZbCNGcnRmwcAFQeFd(IList<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !TimQkiuAaeDaagEUMIwNDqbOjvFdb(P_0[i].ibMvknppBrFxthUlcRzGMjahygXf))
			{
				return true;
			}
		}
		int count2 = IfbGzOEgkYIJwYORArNjJOhXTDVdA.Count;
		for (int j = 0; j < count2; j++)
		{
			if (IfbGzOEgkYIJwYORArNjJOhXTDVdA[j] != null && !kXPlYgClwqbVEeWefVCCgNagUngS(P_0, IfbGzOEgkYIJwYORArNjJOhXTDVdA[j].QnYYlliVZFddzWoxJUtEXRizdCWN))
			{
				return true;
			}
		}
		return false;
	}

	private bool TimQkiuAaeDaagEUMIwNDqbOjvFdb(Guid P_0)
	{
		int count = IfbGzOEgkYIJwYORArNjJOhXTDVdA.Count;
		for (int i = 0; i < count; i++)
		{
			if (IfbGzOEgkYIJwYORArNjJOhXTDVdA[i] != null && IfbGzOEgkYIJwYORArNjJOhXTDVdA[i].QnYYlliVZFddzWoxJUtEXRizdCWN == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool kXPlYgClwqbVEeWefVCCgNagUngS(IList<TrKPVSrmRjdoziVhIIYQgcCFPMlEB> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].ibMvknppBrFxthUlcRzGMjahygXf == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void iaTKEOHpXqvaWHgirrnZpiGlwlPo(List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_0, List<TKfHGTtEUQNcnNSOKlmDEDECjdpe> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe = P_0[i];
			if (tKfHGTtEUQNcnNSOKlmDEDECjdpe == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					TKfHGTtEUQNcnNSOKlmDEDECjdpe tKfHGTtEUQNcnNSOKlmDEDECjdpe2 = P_1[j];
					if (tKfHGTtEUQNcnNSOKlmDEDECjdpe2 != null && tKfHGTtEUQNcnNSOKlmDEDECjdpe.QnYYlliVZFddzWoxJUtEXRizdCWN == tKfHGTtEUQNcnNSOKlmDEDECjdpe2.QnYYlliVZFddzWoxJUtEXRizdCWN)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				HlEIDPzUYHijfHWXECcbQFlnOvAi(P_0[i], P_2);
			}
		}
	}

	private void HlEIDPzUYHijfHWXECcbQFlnOvAi(TKfHGTtEUQNcnNSOKlmDEDECjdpe P_0, bool P_1)
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

	private void hMBBRWCfMluoBPicswtcabtNsXIMA()
	{
		if (iFJJcxAXsRHWKwyzrulThyGrwmQs)
		{
			ZknptpOJKRaaBTPCbHreMQAAjefj = true;
		}
		SystemDeviceConnected();
	}
}
