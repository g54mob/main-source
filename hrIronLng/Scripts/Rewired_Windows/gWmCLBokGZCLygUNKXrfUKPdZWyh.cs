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

internal class gWmCLBokGZCLygUNKXrfUKPdZWyh : PlatformInputManager, hVogZkGpYOPjCtJVInzVFePlclN
{
	private class HzoWThWhXPgLoJWCdUXwIvXSOGyG : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int CeIdVJsUwjdwsuPBCtZxfxIInIm;

		private int VbfjQpAQVkwFagQXhUQnioLEhvsN;

		public Guid QmLKgYYPeYYRxIivEciniTYoXdO;

		public string YGVWsQIdEPlUdLcmFGBdDRxwphL;

		public readonly yRlQRJWFBLpLKarYvNwwzBTmLPM fUWusVflpgaWsSNSoAiTBPWnobsa;

		public oavsBCpkURSQZhuDFrqXELCmmrM niPNEMrDAcpRFqRoYdlkrbLCjZFD;

		public MmRJUmGmuYaWGBxLajcHAEiJST nybQUKNBcNvNqFOQAMgQTsHaDTX;

		public string xAjwjehTWQJNfiRQZtsPAVhpGDq;

		public string RoslMAzcuMRQRlOImiNlFrTtTTTb;

		public int alBpuJrvfbBbJganskpQSPVakoV;

		public Guid zAgUTYpwnGscdFlNDxXqCoyIrDh;

		public Guid ryufZshRWEThUUWWibRppcJadxfg;

		public Guid XMpQMgBqYwmfmmIEFnscpkEovPA;

		public int nQnRhDVRHBdclEftFaviShDQJSn;

		public bool KcCwYwApJNGgFSVHZTdItDIiFcvD;

		public string QqssUOlwiVEPRaCsLVgJqEHvHwg;

		public string tNEwBRRTowMZppuozlRUAoDKupf;

		public int dQifsxjMWJbLcEtOzEAXaRvCMoW;

		public int qItqYPQVfmselpOVATDJcXAPBWB;

		public int cOVEXSAIuvbznALDYKQQXTxspUvG;

		public int xOcVIiUgaPmbRhbRYiQWvhIsYap;

		public int CyeGyzgLsveraNekyMxxiXDhXGK;

		public bool BqXBiRECKKlUBedponJUgsIHutKP;

		private float[] MyEdCYiRJtoncZaamVaftBLHcGOw;

		private bool[] uIeLPvaOtikrhYebGzxpUwrhZxM;

		private HardwareJoystickMap_InputManager QKBgAKpFvffffqJCzlcbbQpNNbB;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

		private bool rtLkWzYCOebfPzMzGZJpRqWoEhH;

		private bool UoPBhPBqUjBCLUUTzRsIuKGshLSj;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return CeIdVJsUwjdwsuPBCtZxfxIInIm;
			}
			set
			{
				CeIdVJsUwjdwsuPBCtZxfxIInIm = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return VbfjQpAQVkwFagQXhUQnioLEhvsN;
			}
			set
			{
				VbfjQpAQVkwFagQXhUQnioLEhvsN = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (YGVWsQIdEPlUdLcmFGBdDRxwphL != "Unknown Controller")
				{
					return YGVWsQIdEPlUdLcmFGBdDRxwphL;
				}
				if (KcCwYwApJNGgFSVHZTdItDIiFcvD && !string.IsNullOrEmpty(QqssUOlwiVEPRaCsLVgJqEHvHwg))
				{
					return QqssUOlwiVEPRaCsLVgJqEHvHwg;
				}
				return RoslMAzcuMRQRlOImiNlFrTtTTTb;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (VbfjQpAQVkwFagQXhUQnioLEhvsN < 0)
				{
					return null;
				}
				return VbfjQpAQVkwFagQXhUQnioLEhvsN;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => zAgUTYpwnGscdFlNDxXqCoyIrDh;

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

		public HzoWThWhXPgLoJWCdUXwIvXSOGyG(yRlQRJWFBLpLKarYvNwwzBTmLPM sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa = sourceJoystick;
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			VbfjQpAQVkwFagQXhUQnioLEhvsN = -1;
			CeIdVJsUwjdwsuPBCtZxfxIInIm = -1;
		}

		public void vKgBIMftcSDdNIHlYFBnbgIECncp()
		{
			XMpQMgBqYwmfmmIEFnscpkEovPA = MiscTools.CreateGuidHashSHA1(RoslMAzcuMRQRlOImiNlFrTtTTTb + ryufZshRWEThUUWWibRppcJadxfg);
			dQifsxjMWJbLcEtOzEAXaRvCMoW = cOVEXSAIuvbznALDYKQQXTxspUvG;
			qItqYPQVfmselpOVATDJcXAPBWB = xOcVIiUgaPmbRhbRYiQWvhIsYap + CyeGyzgLsveraNekyMxxiXDhXGK * 8;
			YOJqghcNXYHtfCjcMsnGHhFpgHI();
			QmLKgYYPeYYRxIivEciniTYoXdO = QKBgAKpFvffffqJCzlcbbQpNNbB.hardwareMapIdentifier.guid;
			YGVWsQIdEPlUdLcmFGBdDRxwphL = QKBgAKpFvffffqJCzlcbbQpNNbB.controllerName;
			rtLkWzYCOebfPzMzGZJpRqWoEhH = ((QmLKgYYPeYYRxIivEciniTYoXdO == Guid.Empty) ? true : false);
			MyEdCYiRJtoncZaamVaftBLHcGOw = new float[dQifsxjMWJbLcEtOzEAXaRvCMoW];
			uIeLPvaOtikrhYebGzxpUwrhZxM = new bool[qItqYPQVfmselpOVATDJcXAPBWB];
			fUWusVflpgaWsSNSoAiTBPWnobsa.DfsndYxHYVKUdQgDuAfETngfexb();
			Update();
		}

		public void jGCYCANCzJiiLhbbuKOMrbCwWVt(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0)
		{
			if (P_0 != null)
			{
				VbfjQpAQVkwFagQXhUQnioLEhvsN = P_0.VbfjQpAQVkwFagQXhUQnioLEhvsN;
				CeIdVJsUwjdwsuPBCtZxfxIInIm = P_0.CeIdVJsUwjdwsuPBCtZxfxIInIm;
				for (int i = 0; i < MathTools.Min(uIeLPvaOtikrhYebGzxpUwrhZxM.Length, P_0.uIeLPvaOtikrhYebGzxpUwrhZxM.Length); i++)
				{
					uIeLPvaOtikrhYebGzxpUwrhZxM[i] = P_0.uIeLPvaOtikrhYebGzxpUwrhZxM[i];
				}
				for (int j = 0; j < MathTools.Min(MyEdCYiRJtoncZaamVaftBLHcGOw.Length, P_0.MyEdCYiRJtoncZaamVaftBLHcGOw.Length); j++)
				{
					MyEdCYiRJtoncZaamVaftBLHcGOw[j] = P_0.MyEdCYiRJtoncZaamVaftBLHcGOw[j];
				}
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = P_0.UoPBhPBqUjBCLUUTzRsIuKGshLSj;
				fUWusVflpgaWsSNSoAiTBPWnobsa.jGCYCANCzJiiLhbbuKOMrbCwWVt(P_0.fUWusVflpgaWsSNSoAiTBPWnobsa);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			fUWusVflpgaWsSNSoAiTBPWnobsa.NNKDQtzuxXoooYVfbmDIlBryQvg();
			bool[] currentButtonValues = fUWusVflpgaWsSNSoAiTBPWnobsa.CurrentButtonValues;
			int[] jXfyAkXiOzsicjndlcVNghKtBBV = fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.jXfyAkXiOzsicjndlcVNghKtBBV;
			VVKAQHjDQMZyRjqEMoRgsckjyIh(currentButtonValues, jXfyAkXiOzsicjndlcVNghKtBBV);
			yMmEMHIqZYcuTkSikVFFrOfyKDc(currentButtonValues, jXfyAkXiOzsicjndlcVNghKtBBV);
			fUWusVflpgaWsSNSoAiTBPWnobsa.xbrgbsymhweSXlyAZAqkvRqFNEB();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (dQifsxjMWJbLcEtOzEAXaRvCMoW != dataUpdater.axisCount || qItqYPQVfmselpOVATDJcXAPBWB != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < dQifsxjMWJbLcEtOzEAXaRvCMoW; i++)
			{
				dataUpdater.axisValues[i] = MyEdCYiRJtoncZaamVaftBLHcGOw[i];
			}
			for (int j = 0; j < qItqYPQVfmselpOVATDJcXAPBWB; j++)
			{
				dataUpdater.buttonValues[j] = uIeLPvaOtikrhYebGzxpUwrhZxM[j];
			}
			if (UoPBhPBqUjBCLUUTzRsIuKGshLSj && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int NitiHALsfYhXyGTeMMaYoAUmOkLM(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0)
		{
			if (P_0.CeIdVJsUwjdwsuPBCtZxfxIInIm == CeIdVJsUwjdwsuPBCtZxfxIInIm)
			{
				return 2;
			}
			if (cOVEXSAIuvbznALDYKQQXTxspUvG != P_0.cOVEXSAIuvbznALDYKQQXTxspUvG)
			{
				return 0;
			}
			if (xOcVIiUgaPmbRhbRYiQWvhIsYap != P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap)
			{
				return 0;
			}
			if (CyeGyzgLsveraNekyMxxiXDhXGK != P_0.CyeGyzgLsveraNekyMxxiXDhXGK)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.XMpQMgBqYwmfmmIEFnscpkEovPA == XMpQMgBqYwmfmmIEFnscpkEovPA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo OiAyslXLaikGHSduwzwAoxjCWis()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			znmRFnJWmRHaLzxNQMvWhUZoLvz(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			znmRFnJWmRHaLzxNQMvWhUZoLvz(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(CeIdVJsUwjdwsuPBCtZxfxIInIm);
		}

		public bool DHmcXFAgLYfMVKfsvVmyMSVwNMPb()
		{
			try
			{
				fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx.emjQLuphPoQsXMTYhbZwZdTFpsM();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void DfoHKTaxZzJSYcaLwTWUBUINGoo()
		{
			try
			{
				if (fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx != null)
				{
					fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx.DfoHKTaxZzJSYcaLwTWUBUINGoo();
				}
			}
			catch
			{
			}
		}

		public void SdCpHXCeCCZSBrMShYjjsXEWWgu()
		{
			try
			{
				if (fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx != null)
				{
					fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx.SdCpHXCeCCZSBrMShYjjsXEWWgu();
				}
			}
			catch
			{
			}
		}

		private void VVKAQHjDQMZyRjqEMoRgsckjyIh(bool[] P_0, int[] P_1)
		{
			if (dQifsxjMWJbLcEtOzEAXaRvCMoW <= 0)
			{
				return;
			}
			switch (QKBgAKpFvffffqJCzlcbbQpNNbB.map.platform)
			{
			case InputPlatform.tMjFoInTdjUdFsuvBdkJykAOcxK:
			{
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = platform_RawInput_Base.Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						KlIHHfGqKlFDXrNwExsqJzZttMs(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.LVWvrxQsAqeVkjNRwnuKIXNmUpb:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = platform_DirectInput_Base.Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						KlIHHfGqKlFDXrNwExsqJzZttMs(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void yMmEMHIqZYcuTkSikVFFrOfyKDc(bool[] P_0, int[] P_1)
		{
			if (qItqYPQVfmselpOVATDJcXAPBWB <= 0)
			{
				return;
			}
			switch (QKBgAKpFvffffqJCzlcbbQpNNbB.map.platform)
			{
			case InputPlatform.tMjFoInTdjUdFsuvBdkJykAOcxK:
			{
				HardwareJoystickMap.Platform_RawInput_Base platform_RawInput_Base = (HardwareJoystickMap.Platform_RawInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = platform_RawInput_Base.Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						WIJBTCIRRSBeeGMYbnDWPXMEQDGe(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.LVWvrxQsAqeVkjNRwnuKIXNmUpb:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = platform_DirectInput_Base.Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						WIJBTCIRRSBeeGMYbnDWPXMEQDGe(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void KlIHHfGqKlFDXrNwExsqJzZttMs(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= dQifsxjMWJbLcEtOzEAXaRvCMoW)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			MyEdCYiRJtoncZaamVaftBLHcGOw[P_1] = TgLPLRPKTlXSaoodLpemjkZzehs(P_0, P_2, P_3);
			if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && MyEdCYiRJtoncZaamVaftBLHcGOw[P_1] != 0f)
			{
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
			}
		}

		private void WIJBTCIRRSBeeGMYbnDWPXMEQDGe(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= qItqYPQVfmselpOVATDJcXAPBWB)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			uIeLPvaOtikrhYebGzxpUwrhZxM[P_1] = hCGghiHxSAcLADozffLtfQoDJspU(P_0, P_2, P_3);
			if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && uIeLPvaOtikrhYebGzxpUwrhZxM[P_1])
			{
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
			}
		}

		private float TgLPLRPKTlXSaoodLpemjkZzehs(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return TgLPLRPKTlXSaoodLpemjkZzehs((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= CyeGyzgLsveraNekyMxxiXDhXGK || sourceHat >= 4)
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
					num2 = oAZCxiOkVATasFWaPhbZTIAzioS(num, AxisDirection.Horizontal);
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
					num2 = oAZCxiOkVATasFWaPhbZTIAzioS(num, AxisDirection.Vertical);
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
						if (hardwareElementSourceTypeWithHat == HardwareElementSourceTypeWithHat.Axis && TWAwKiKApdUVUdHASbIDeYHuwhj(customCalculationSourceData[i], out var item))
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

		private float TgLPLRPKTlXSaoodLpemjkZzehs(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.aKhnJLPlzQqMJcsXANqZDKcXdkvk, 
				DirectInputAxis.Y => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.CfrGUAcJZiBIgrKhIOoWYteVjgS, 
				DirectInputAxis.Z => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.WXjeIOAoewOQIscExpKoNuKQHmwy, 
				DirectInputAxis.RotationX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.JywpkGypXKpMPpmJmoSTdBhHgka, 
				DirectInputAxis.RotationY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.OBnofHHNvJiJakkxtUvXOcQmFQN, 
				DirectInputAxis.RotationZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.TWkvQGYlQKKRAykOFNByKSfVmCk, 
				DirectInputAxis.Slider0 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.vZwkaUCOfHprJiHGGRsVDgqRzLl[0], 
				DirectInputAxis.Slider1 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.vZwkaUCOfHprJiHGGRsVDgqRzLl[1], 
				DirectInputAxis.VelocityX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.vvfjvyePYbfVnEiPrKhbJqRVnwzT, 
				DirectInputAxis.VelocityY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.geNOSosKHqgOWDDxRonbxWgzkwF, 
				DirectInputAxis.VelocityZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.XdCaAZtQKaCefLRxCkorPrFAkgk, 
				DirectInputAxis.AngularVelocityX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.lJQPEkRPLTenYcXltDEvunJkwQNF, 
				DirectInputAxis.AngularVelocityY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.NNeBFAbujhDTkeOVHBXvVZCpoda, 
				DirectInputAxis.AngularVelocityZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.cHELCJMRgsMTguqvbGHjbQxwhpjD, 
				DirectInputAxis.VelocitySlider0 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.ATyZGwDpMafdMeJDuxheQcuTtJBg[0], 
				DirectInputAxis.VelocitySlider1 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.ATyZGwDpMafdMeJDuxheQcuTtJBg[1], 
				DirectInputAxis.AccelerationX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.FiFXhicDYntuvNpevQvQjwnFtOc, 
				DirectInputAxis.AccelerationY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.rvCzNxiUQqTwigkeOKItPaQapwF, 
				DirectInputAxis.AccelerationZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.KVEGbuFHkriBpaHmCVNZLWvjKdmk, 
				DirectInputAxis.AngularAccelerationX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.XSOZDFCBQuUyYBxQXYZdMfwDeCv, 
				DirectInputAxis.AngularAccelerationY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.xbnJICdhHRWEdaKLhmAKaYsRTIr, 
				DirectInputAxis.AngularAccelerationZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.WZyxHvBlwVGkOGejoakQwClFsWCQ, 
				DirectInputAxis.AccelerationSlider0 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.CKDBUEfrUJRsXkuAJLDsSClHSWWm[0], 
				DirectInputAxis.AccelerationSlider1 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.CKDBUEfrUJRsXkuAJLDsSClHSWWm[1], 
				DirectInputAxis.ForceX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.CDfOEwEfMsGRTjoRCrysFIBmdNH, 
				DirectInputAxis.ForceY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.AbasMYLPUPdQGeJRFFmJomiAdcMi, 
				DirectInputAxis.ForceZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.ToHWJCaqFGYwKATVfDANjxuKnCy, 
				DirectInputAxis.TorqueX => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.MbseeuuMigDqMmimUEaZTVzinDs, 
				DirectInputAxis.TorqueY => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.WIHPnWKDUtEkkfuGJAmJMfCxjYi, 
				DirectInputAxis.TorqueZ => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.bsDcwDgaZzAgRdGICLWEQCWkiyvk, 
				DirectInputAxis.ForceSlider0 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.MPYlcktMxXfKIuNNNdEkMEKBtMg[0], 
				DirectInputAxis.ForceSlider1 => fUWusVflpgaWsSNSoAiTBPWnobsa.joystickState.MPYlcktMxXfKIuNNNdEkMEKBtMg[1], 
				_ => 0f, 
			};
		}

		private bool hCGghiHxSAcLADozffLtfQoDJspU(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 128)
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
				float num = TgLPLRPKTlXSaoodLpemjkZzehs((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= CyeGyzgLsveraNekyMxxiXDhXGK || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return fmPFHgbpHOqutCcgElSaAMDgVgs(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (geXMBlrHCRaLQBfmbQSGEzdcCwE(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (TWAwKiKApdUVUdHASbIDeYHuwhj(customCalculationSourceData[k], out var num2))
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

		private bool fmPFHgbpHOqutCcgElSaAMDgVgs(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (QKBgAKpFvffffqJCzlcbbQpNNbB.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float oAZCxiOkVATasFWaPhbZTIAzioS(int P_0, AxisDirection P_1)
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

		private bool geXMBlrHCRaLQBfmbQSGEzdcCwE(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool TWAwKiKApdUVUdHASbIDeYHuwhj(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = TgLPLRPKTlXSaoodLpemjkZzehs((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType ipoxvUirZWBmBfWoVUuVcpQDnyd(MmRJUmGmuYaWGBxLajcHAEiJST P_0)
		{
			return P_0 switch
			{
				MmRJUmGmuYaWGBxLajcHAEiJST.cXiIaGSjeBKnSzIJGvtEtwBDTsm => ControlDeviceType.RCedHXktmDuEaJMNAKkvapTxIktB, 
				MmRJUmGmuYaWGBxLajcHAEiJST.byUbkGgDbtpnARqSeOsTiHVjQYb => ControlDeviceType.SRzHntXksMAdDsrLdjhLausTYzs, 
				MmRJUmGmuYaWGBxLajcHAEiJST.cMDdbqtCLCmlakqTbYRMVcREdGI => ControlDeviceType.FkuTeNINGnHkhHTSsaBIaLcmEbXx, 
				MmRJUmGmuYaWGBxLajcHAEiJST.NcOiPCmfYWmxxojUswKfONTIHos => ControlDeviceType.oNtyvjTqZbBsgFbifrnlIOieMqj, 
				MmRJUmGmuYaWGBxLajcHAEiJST.EbJjJPLABvUPxotWDOnmczJgiZJ => ControlDeviceType.rmiCKkqPGOgJmRpPIqPckJiGJWS, 
				MmRJUmGmuYaWGBxLajcHAEiJST.mvSrrAvfuJuFKHBdVurdUIXvett => ControlDeviceType.fjvEgHdOoukDdojyWPaZjjfqNMc, 
				_ => ControlDeviceType.CxIBFsnaOMTSettXyfvwFIXcUdA, 
			};
		}

		private void YOJqghcNXYHtfCjcMsnGHhFpgHI()
		{
			QKBgAKpFvffffqJCzlcbbQpNNbB = muwCboYBpXBddhISLPoaIQYyEVOW(OiAyslXLaikGHSduwzwAoxjCWis());
			if (QKBgAKpFvffffqJCzlcbbQpNNbB == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			dQifsxjMWJbLcEtOzEAXaRvCMoW = QKBgAKpFvffffqJCzlcbbQpNNbB.axisCount;
			qItqYPQVfmselpOVATDJcXAPBWB = QKBgAKpFvffffqJCzlcbbQpNNbB.buttonCount;
		}

		private void hOQgnJXHVfaqUaNKDkyqetKTIqGA()
		{
		}

		private string YXIGqOwOaSKguwVetUikwAgNhDcE()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.DirectInput}{((KcCwYwApJNGgFSVHZTdItDIiFcvD && !string.IsNullOrEmpty(QqssUOlwiVEPRaCsLVgJqEHvHwg)) ? QqssUOlwiVEPRaCsLVgJqEHvHwg : RoslMAzcuMRQRlOImiNlFrTtTTTb)}{alBpuJrvfbBbJganskpQSPVakoV}{ryufZshRWEThUUWWibRppcJadxfg}");
		}

		private void znmRFnJWmRHaLzxNQMvWhUZoLvz(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ipoxvUirZWBmBfWoVUuVcpQDnyd(nybQUKNBcNvNqFOQAMgQTsHaDTX);
			P_0.hardwareIdentifier = YXIGqOwOaSKguwVetUikwAgNhDcE();
			P_0.hardwareAxisCount = cOVEXSAIuvbznALDYKQQXTxspUvG;
			P_0.hardwareButtonCount = xOcVIiUgaPmbRhbRYiQWvhIsYap;
			P_0.hardwareHatCount = CyeGyzgLsveraNekyMxxiXDhXGK;
			P_0.hw_productName = RoslMAzcuMRQRlOImiNlFrTtTTTb;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_productId = alBpuJrvfbBbJganskpQSPVakoV;
			P_0.hw_pidVid = new PidVid(ryufZshRWEThUUWWibRppcJadxfg);
			P_0.hw_isBluetoothDevice = KcCwYwApJNGgFSVHZTdItDIiFcvD;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(QqssUOlwiVEPRaCsLVgJqEHvHwg)) ? QqssUOlwiVEPRaCsLVgJqEHvHwg : string.Empty);
			P_0.definitionMatchTag = tNEwBRRTowMZppuozlRUAoDKupf;
		}

		private void znmRFnJWmRHaLzxNQMvWhUZoLvz(BridgedController P_0)
		{
			znmRFnJWmRHaLzxNQMvWhUZoLvz((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = QKBgAKpFvffffqJCzlcbbQpNNbB.ToGameHardwareControllerMap();
			P_0.instanceName = xAjwjehTWQJNfiRQZtsPAVhpGDq;
			P_0.productName = RoslMAzcuMRQRlOImiNlFrTtTTTb;
			P_0.isXInputDevice = BqXBiRECKKlUBedponJUgsIHutKP;
			P_0.axisCount = dQifsxjMWJbLcEtOzEAXaRvCMoW;
			P_0.buttonCount = qItqYPQVfmselpOVATDJcXAPBWB;
			P_0.unknownControllerHats = QVSUQWvsrNVKIAHrZHGppYveKLH();
			P_0.controllerTypeGuid = QmLKgYYPeYYRxIivEciniTYoXdO;
			P_0.controllerExtension = extension;
		}

		private void NNmAqEjiDMumRkoBcOeJDkEGqAaA()
		{
			for (int i = 0; i < qItqYPQVfmselpOVATDJcXAPBWB; i++)
			{
				uIeLPvaOtikrhYebGzxpUwrhZxM[i] = false;
			}
			for (int j = 0; j < dQifsxjMWJbLcEtOzEAXaRvCMoW; j++)
			{
				MyEdCYiRJtoncZaamVaftBLHcGOw[j] = 0f;
			}
		}

		private UnknownControllerHat[] QVSUQWvsrNVKIAHrZHGppYveKLH()
		{
			if (!rtLkWzYCOebfPzMzGZJpRqWoEhH)
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

		public void KRgasgBmyLeCeDGJhNGqwMeOqCwJ()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
			GC.SuppressFinalize(this);
		}

		~HzoWThWhXPgLoJWCdUXwIvXSOGyG()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (!euujVPFzGztViWDbYvUutBvFQFP)
			{
				if (P_0 && fUWusVflpgaWsSNSoAiTBPWnobsa != null)
				{
					fUWusVflpgaWsSNSoAiTBPWnobsa.Dispose();
				}
				euujVPFzGztViWDbYvUutBvFQFP = true;
			}
		}

		public static int pGjfuRAfDSILvnrsYiKAbBWPKog(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, HzoWThWhXPgLoJWCdUXwIvXSOGyG P_1)
		{
			if (P_0.VbfjQpAQVkwFagQXhUQnioLEhvsN < P_1.VbfjQpAQVkwFagQXhUQnioLEhvsN)
			{
				return -1;
			}
			if (P_0.VbfjQpAQVkwFagQXhUQnioLEhvsN > P_1.VbfjQpAQVkwFagQXhUQnioLEhvsN)
			{
				return 1;
			}
			return 0;
		}

		public static int IXhtCFsFifIXBgUBDrBxKdNjSso(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, HzoWThWhXPgLoJWCdUXwIvXSOGyG P_1)
		{
			if (P_0.nQnRhDVRHBdclEftFaviShDQJSn < P_1.nQnRhDVRHBdclEftFaviShDQJSn)
			{
				return -1;
			}
			if (P_0.nQnRhDVRHBdclEftFaviShDQJSn > P_1.nQnRhDVRHBdclEftFaviShDQJSn)
			{
				return 1;
			}
			return 0;
		}
	}

	private class yRlQRJWFBLpLKarYvNwwzBTmLPM : IDisposable
	{
		public class cmIOoFiNpNIWemfyAoRFQFJGgFz
		{
			public float aKhnJLPlzQqMJcsXANqZDKcXdkvk;

			public float CfrGUAcJZiBIgrKhIOoWYteVjgS;

			public float WXjeIOAoewOQIscExpKoNuKQHmwy;

			public float JywpkGypXKpMPpmJmoSTdBhHgka;

			public float OBnofHHNvJiJakkxtUvXOcQmFQN;

			public float TWkvQGYlQKKRAykOFNByKSfVmCk;

			public float[] vZwkaUCOfHprJiHGGRsVDgqRzLl;

			public readonly int[] jXfyAkXiOzsicjndlcVNghKtBBV;

			public readonly bool[] TUYMVHGCBHgHkIfQYSkUtTsGyCJ;

			public float vvfjvyePYbfVnEiPrKhbJqRVnwzT;

			public float geNOSosKHqgOWDDxRonbxWgzkwF;

			public float XdCaAZtQKaCefLRxCkorPrFAkgk;

			public float lJQPEkRPLTenYcXltDEvunJkwQNF;

			public float NNeBFAbujhDTkeOVHBXvVZCpoda;

			public float cHELCJMRgsMTguqvbGHjbQxwhpjD;

			public readonly float[] ATyZGwDpMafdMeJDuxheQcuTtJBg;

			public float FiFXhicDYntuvNpevQvQjwnFtOc;

			public float rvCzNxiUQqTwigkeOKItPaQapwF;

			public float KVEGbuFHkriBpaHmCVNZLWvjKdmk;

			public float XSOZDFCBQuUyYBxQXYZdMfwDeCv;

			public float xbnJICdhHRWEdaKLhmAKaYsRTIr;

			public float WZyxHvBlwVGkOGejoakQwClFsWCQ;

			public readonly float[] CKDBUEfrUJRsXkuAJLDsSClHSWWm;

			public float CDfOEwEfMsGRTjoRCrysFIBmdNH;

			public float AbasMYLPUPdQGeJRFFmJomiAdcMi;

			public float ToHWJCaqFGYwKATVfDANjxuKnCy;

			public float MbseeuuMigDqMmimUEaZTVzinDs;

			public float WIHPnWKDUtEkkfuGJAmJMfCxjYi;

			public float bsDcwDgaZzAgRdGICLWEQCWkiyvk;

			public readonly float[] MPYlcktMxXfKIuNNNdEkMEKBtMg;

			public cmIOoFiNpNIWemfyAoRFQFJGgFz()
			{
				vZwkaUCOfHprJiHGGRsVDgqRzLl = new float[2];
				jXfyAkXiOzsicjndlcVNghKtBBV = new int[4];
				TUYMVHGCBHgHkIfQYSkUtTsGyCJ = new bool[128];
				ATyZGwDpMafdMeJDuxheQcuTtJBg = new float[2];
				CKDBUEfrUJRsXkuAJLDsSClHSWWm = new float[2];
				MPYlcktMxXfKIuNNNdEkMEKBtMg = new float[2];
			}

			public void avkcOhFlGGeHrNSdTQlLZUnJDbw()
			{
				aKhnJLPlzQqMJcsXANqZDKcXdkvk = 0f;
				CfrGUAcJZiBIgrKhIOoWYteVjgS = 0f;
				WXjeIOAoewOQIscExpKoNuKQHmwy = 0f;
				JywpkGypXKpMPpmJmoSTdBhHgka = 0f;
				OBnofHHNvJiJakkxtUvXOcQmFQN = 0f;
				TWkvQGYlQKKRAykOFNByKSfVmCk = 0f;
				for (int i = 0; i < vZwkaUCOfHprJiHGGRsVDgqRzLl.Length; i++)
				{
					vZwkaUCOfHprJiHGGRsVDgqRzLl[i] = 0f;
				}
				for (int j = 0; j < jXfyAkXiOzsicjndlcVNghKtBBV.Length; j++)
				{
					jXfyAkXiOzsicjndlcVNghKtBBV[j] = 0;
				}
				for (int k = 0; k < TUYMVHGCBHgHkIfQYSkUtTsGyCJ.Length; k++)
				{
					TUYMVHGCBHgHkIfQYSkUtTsGyCJ[k] = false;
				}
				vvfjvyePYbfVnEiPrKhbJqRVnwzT = 0f;
				geNOSosKHqgOWDDxRonbxWgzkwF = 0f;
				XdCaAZtQKaCefLRxCkorPrFAkgk = 0f;
				lJQPEkRPLTenYcXltDEvunJkwQNF = 0f;
				NNeBFAbujhDTkeOVHBXvVZCpoda = 0f;
				cHELCJMRgsMTguqvbGHjbQxwhpjD = 0f;
				for (int l = 0; l < ATyZGwDpMafdMeJDuxheQcuTtJBg.Length; l++)
				{
					ATyZGwDpMafdMeJDuxheQcuTtJBg[l] = 0f;
				}
				FiFXhicDYntuvNpevQvQjwnFtOc = 0f;
				rvCzNxiUQqTwigkeOKItPaQapwF = 0f;
				KVEGbuFHkriBpaHmCVNZLWvjKdmk = 0f;
				XSOZDFCBQuUyYBxQXYZdMfwDeCv = 0f;
				xbnJICdhHRWEdaKLhmAKaYsRTIr = 0f;
				WZyxHvBlwVGkOGejoakQwClFsWCQ = 0f;
				for (int m = 0; m < CKDBUEfrUJRsXkuAJLDsSClHSWWm.Length; m++)
				{
					CKDBUEfrUJRsXkuAJLDsSClHSWWm[m] = 0f;
				}
				CDfOEwEfMsGRTjoRCrysFIBmdNH = 0f;
				AbasMYLPUPdQGeJRFFmJomiAdcMi = 0f;
				ToHWJCaqFGYwKATVfDANjxuKnCy = 0f;
				MbseeuuMigDqMmimUEaZTVzinDs = 0f;
				WIHPnWKDUtEkkfuGJAmJMfCxjYi = 0f;
				bsDcwDgaZzAgRdGICLWEQCWkiyvk = 0f;
				for (int n = 0; n < MPYlcktMxXfKIuNNNdEkMEKBtMg.Length; n++)
				{
					MPYlcktMxXfKIuNNNdEkMEKBtMg[n] = 0f;
				}
			}

			public void OcfraEykjBtASDrfWrlPPDyQQVt(cmIOoFiNpNIWemfyAoRFQFJGgFz P_0)
			{
				aKhnJLPlzQqMJcsXANqZDKcXdkvk = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
				CfrGUAcJZiBIgrKhIOoWYteVjgS = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS;
				WXjeIOAoewOQIscExpKoNuKQHmwy = P_0.WXjeIOAoewOQIscExpKoNuKQHmwy;
				JywpkGypXKpMPpmJmoSTdBhHgka = P_0.JywpkGypXKpMPpmJmoSTdBhHgka;
				OBnofHHNvJiJakkxtUvXOcQmFQN = P_0.OBnofHHNvJiJakkxtUvXOcQmFQN;
				TWkvQGYlQKKRAykOFNByKSfVmCk = P_0.TWkvQGYlQKKRAykOFNByKSfVmCk;
				for (int i = 0; i < vZwkaUCOfHprJiHGGRsVDgqRzLl.Length; i++)
				{
					vZwkaUCOfHprJiHGGRsVDgqRzLl[i] = P_0.vZwkaUCOfHprJiHGGRsVDgqRzLl[i];
				}
				for (int j = 0; j < jXfyAkXiOzsicjndlcVNghKtBBV.Length; j++)
				{
					jXfyAkXiOzsicjndlcVNghKtBBV[j] = P_0.jXfyAkXiOzsicjndlcVNghKtBBV[j];
				}
				for (int k = 0; k < TUYMVHGCBHgHkIfQYSkUtTsGyCJ.Length; k++)
				{
					TUYMVHGCBHgHkIfQYSkUtTsGyCJ[k] = P_0.TUYMVHGCBHgHkIfQYSkUtTsGyCJ[k];
				}
				vvfjvyePYbfVnEiPrKhbJqRVnwzT = P_0.vvfjvyePYbfVnEiPrKhbJqRVnwzT;
				geNOSosKHqgOWDDxRonbxWgzkwF = P_0.geNOSosKHqgOWDDxRonbxWgzkwF;
				XdCaAZtQKaCefLRxCkorPrFAkgk = P_0.XdCaAZtQKaCefLRxCkorPrFAkgk;
				lJQPEkRPLTenYcXltDEvunJkwQNF = P_0.lJQPEkRPLTenYcXltDEvunJkwQNF;
				NNeBFAbujhDTkeOVHBXvVZCpoda = P_0.NNeBFAbujhDTkeOVHBXvVZCpoda;
				cHELCJMRgsMTguqvbGHjbQxwhpjD = P_0.cHELCJMRgsMTguqvbGHjbQxwhpjD;
				for (int l = 0; l < ATyZGwDpMafdMeJDuxheQcuTtJBg.Length; l++)
				{
					ATyZGwDpMafdMeJDuxheQcuTtJBg[l] = P_0.ATyZGwDpMafdMeJDuxheQcuTtJBg[l];
				}
				FiFXhicDYntuvNpevQvQjwnFtOc = P_0.FiFXhicDYntuvNpevQvQjwnFtOc;
				rvCzNxiUQqTwigkeOKItPaQapwF = P_0.rvCzNxiUQqTwigkeOKItPaQapwF;
				KVEGbuFHkriBpaHmCVNZLWvjKdmk = P_0.KVEGbuFHkriBpaHmCVNZLWvjKdmk;
				XSOZDFCBQuUyYBxQXYZdMfwDeCv = P_0.XSOZDFCBQuUyYBxQXYZdMfwDeCv;
				xbnJICdhHRWEdaKLhmAKaYsRTIr = P_0.xbnJICdhHRWEdaKLhmAKaYsRTIr;
				WZyxHvBlwVGkOGejoakQwClFsWCQ = P_0.WZyxHvBlwVGkOGejoakQwClFsWCQ;
				for (int m = 0; m < CKDBUEfrUJRsXkuAJLDsSClHSWWm.Length; m++)
				{
					CKDBUEfrUJRsXkuAJLDsSClHSWWm[m] = P_0.CKDBUEfrUJRsXkuAJLDsSClHSWWm[m];
				}
				CDfOEwEfMsGRTjoRCrysFIBmdNH = P_0.CDfOEwEfMsGRTjoRCrysFIBmdNH;
				AbasMYLPUPdQGeJRFFmJomiAdcMi = P_0.AbasMYLPUPdQGeJRFFmJomiAdcMi;
				ToHWJCaqFGYwKATVfDANjxuKnCy = P_0.ToHWJCaqFGYwKATVfDANjxuKnCy;
				MbseeuuMigDqMmimUEaZTVzinDs = P_0.MbseeuuMigDqMmimUEaZTVzinDs;
				WIHPnWKDUtEkkfuGJAmJMfCxjYi = P_0.WIHPnWKDUtEkkfuGJAmJMfCxjYi;
				bsDcwDgaZzAgRdGICLWEQCWkiyvk = P_0.bsDcwDgaZzAgRdGICLWEQCWkiyvk;
				for (int n = 0; n < MPYlcktMxXfKIuNNNdEkMEKBtMg.Length; n++)
				{
					MPYlcktMxXfKIuNNNdEkMEKBtMg[n] = P_0.MPYlcktMxXfKIuNNNdEkMEKBtMg[n];
				}
			}

			public unsafe void OcfraEykjBtASDrfWrlPPDyQQVt(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = ((int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart))[i];
					for (int j = 0; j < 32; j++)
					{
						TUYMVHGCBHgHkIfQYSkUtTsGyCJ[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					CKDBUEfrUJRsXkuAJLDsSClHSWWm[k] = *ptr;
					ptr++;
				}
				FiFXhicDYntuvNpevQvQjwnFtOc = *ptr;
				ptr++;
				rvCzNxiUQqTwigkeOKItPaQapwF = *ptr;
				ptr++;
				KVEGbuFHkriBpaHmCVNZLWvjKdmk = *ptr;
				ptr++;
				XSOZDFCBQuUyYBxQXYZdMfwDeCv = *ptr;
				ptr++;
				xbnJICdhHRWEdaKLhmAKaYsRTIr = *ptr;
				ptr++;
				WZyxHvBlwVGkOGejoakQwClFsWCQ = *ptr;
				ptr++;
				lJQPEkRPLTenYcXltDEvunJkwQNF = *ptr;
				ptr++;
				NNeBFAbujhDTkeOVHBXvVZCpoda = *ptr;
				ptr++;
				cHELCJMRgsMTguqvbGHjbQxwhpjD = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					MPYlcktMxXfKIuNNNdEkMEKBtMg[l] = *ptr;
					ptr++;
				}
				CDfOEwEfMsGRTjoRCrysFIBmdNH = *ptr;
				ptr++;
				AbasMYLPUPdQGeJRFFmJomiAdcMi = *ptr;
				ptr++;
				ToHWJCaqFGYwKATVfDANjxuKnCy = *ptr;
				ptr++;
				JywpkGypXKpMPpmJmoSTdBhHgka = *ptr;
				ptr++;
				OBnofHHNvJiJakkxtUvXOcQmFQN = *ptr;
				ptr++;
				TWkvQGYlQKKRAykOFNByKSfVmCk = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					vZwkaUCOfHprJiHGGRsVDgqRzLl[m] = *ptr;
					ptr++;
				}
				MbseeuuMigDqMmimUEaZTVzinDs = *ptr;
				ptr++;
				WIHPnWKDUtEkkfuGJAmJMfCxjYi = *ptr;
				ptr++;
				bsDcwDgaZzAgRdGICLWEQCWkiyvk = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					ATyZGwDpMafdMeJDuxheQcuTtJBg[n] = *ptr;
					ptr++;
				}
				vvfjvyePYbfVnEiPrKhbJqRVnwzT = *ptr;
				ptr++;
				geNOSosKHqgOWDDxRonbxWgzkwF = *ptr;
				ptr++;
				XdCaAZtQKaCefLRxCkorPrFAkgk = *ptr;
				ptr++;
				aKhnJLPlzQqMJcsXANqZDKcXdkvk = *ptr;
				ptr++;
				CfrGUAcJZiBIgrKhIOoWYteVjgS = *ptr;
				ptr++;
				WXjeIOAoewOQIscExpKoNuKQHmwy = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					jXfyAkXiOzsicjndlcVNghKtBBV[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void dKxTGBXdfPIXPVTurBkqGeUeLTw(WdUgpcVePDxEWRCUGSnBbePWAHU P_0, double P_1, LowLevelInputEvent P_2)
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
					*ptr = gGNoAhCUXzgDbDcskWksokriYti(accelerationSliders[j]);
					ptr++;
				}
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AccelerationX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AccelerationY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AccelerationZ);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularAccelerationX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularAccelerationY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularAccelerationZ);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularVelocityX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularVelocityY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.AngularVelocityZ);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = gGNoAhCUXzgDbDcskWksokriYti(forceSliders[k]);
					ptr++;
				}
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.ForceX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.ForceY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.ForceZ);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.RotationX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.RotationY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.RotationZ);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = gGNoAhCUXzgDbDcskWksokriYti(sliders[l]);
					ptr++;
				}
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.TorqueX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.TorqueY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.TorqueZ);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = gGNoAhCUXzgDbDcskWksokriYti(velocitySliders[m]);
					ptr++;
				}
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.VelocityX);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.VelocityY);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.VelocityZ);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.X);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.Y);
				ptr++;
				*ptr = gGNoAhCUXzgDbDcskWksokriYti(P_0.Z);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = pointOfViewControllers[n];
					ptr2++;
				}
			}
		}

		private const int VOFiItZnODgoYpCVFaQAeLHWVxok = 2;

		private const int ptyfGcYgXZEtbdbBUTmjxcsfQOy = 2;

		private const int ETXMtSOHadKkTWeloqxSUjPvkDc = 128;

		private const int vEdRkyemFxfzdGMhAThgLONVwSoS = 32;

		private const int JEcBdluQtDomTXEAKsCJOGmVoEP = 0;

		private const int vIJNGHhLpkOEmaRPykTpNGsQowC = 264;

		private const int NUuxVBhUpCIwuwDqIqKgQqZSiOc = 272;

		private readonly int aORFycYuiaRmVGcJmTzHLSOPUlP;

		private readonly ButtonLoopSet sdzgyVcwHqRpNJLIhbGtHGVnHPZd;

		private readonly DualThreadLowLevelInputEventQueue svaNJVSHYqJtTvuXjDrXdclMBTr;

		private OTttRthNhavrHrLUUrYOhHUluQa cCqcBFaAsOGcyRRpMnEDcolJIGu;

		private readonly WdUgpcVePDxEWRCUGSnBbePWAHU RrAKkXBtOxVWtDsjNFtvnUqWJlI;

		private readonly WdUgpcVePDxEWRCUGSnBbePWAHU SsZfFmhWTsgBHmKnmJrNkmligft;

		private readonly object eQuodSQpbSdsKiGAacuPzpuZcE;

		private bool eFIldJHAlwDZVMNuZYxdjxWSQFI;

		public readonly iKlolGPnHgrjtsiEOOZxcLUhJOe ZfsAwHWQezYJXJnEkPTMXerdwlx;

		private readonly cmIOoFiNpNIWemfyAoRFQFJGgFz OTlqpFsbeZGiyHOnqpLWAEXDeJCc;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		public bool[] CurrentButtonValues => sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Current.effectiveValue;

		public cmIOoFiNpNIWemfyAoRFQFJGgFz joystickState => OTlqpFsbeZGiyHOnqpLWAEXDeJCc;

		public yRlQRJWFBLpLKarYvNwwzBTmLPM(iKlolGPnHgrjtsiEOOZxcLUhJOe source, UpdateLoopSetting updateLoops)
		{
			ZfsAwHWQezYJXJnEkPTMXerdwlx = source;
			aORFycYuiaRmVGcJmTzHLSOPUlP = source.Capabilities.qcyHpxgSpKtegmJpDPmnhYbZINb;
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd = new ButtonLoopSet(updateLoops, aORFycYuiaRmVGcJmTzHLSOPUlP);
			svaNJVSHYqJtTvuXjDrXdclMBTr = new DualThreadLowLevelInputEventQueue((int)((float)oizETVRXykJREMrljZxCoqipUeW.joystickRefreshRate * 0.25f), 128, 32, 2);
			OTlqpFsbeZGiyHOnqpLWAEXDeJCc = new cmIOoFiNpNIWemfyAoRFQFJGgFz();
			RrAKkXBtOxVWtDsjNFtvnUqWJlI = new WdUgpcVePDxEWRCUGSnBbePWAHU();
			SsZfFmhWTsgBHmKnmJrNkmligft = new WdUgpcVePDxEWRCUGSnBbePWAHU();
			eQuodSQpbSdsKiGAacuPzpuZcE = new object();
			if (oizETVRXykJREMrljZxCoqipUeW.joystickInputThread != null)
			{
				oizETVRXykJREMrljZxCoqipUeW.joystickInputThread.ThreadUpdateEvent += GWCbbdPIhiDNAkQzqeBYraCCVNcS;
			}
		}

		public void NNKDQtzuxXoooYVfbmDIlBryQvg()
		{
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd.SetUpdateLoop(ReInput.currentUpdateLoop);
			YOHpShjCXutwPTokdTvLDLpPiys();
		}

		public void xbrgbsymhweSXlyAZAqkvRqFNEB()
		{
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Current.ClearWasTrueThisFrame();
		}

		public void DfsndYxHYVKUdQgDuAfETngfexb()
		{
			TzBPrZngbKbHBhJPAmtHpHNMMTtf();
			eFIldJHAlwDZVMNuZYxdjxWSQFI = true;
		}

		public void ibjqBHyFNJOhWJActsfrTOPbIjF()
		{
			eFIldJHAlwDZVMNuZYxdjxWSQFI = false;
			TzBPrZngbKbHBhJPAmtHpHNMMTtf();
		}

		public void jGCYCANCzJiiLhbbuKOMrbCwWVt(yRlQRJWFBLpLKarYvNwwzBTmLPM P_0)
		{
			if (P_0 == null || P_0 == this || P_0.aORFycYuiaRmVGcJmTzHLSOPUlP != aORFycYuiaRmVGcJmTzHLSOPUlP)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (eQuodSQpbSdsKiGAacuPzpuZcE)
			{
				lock (P_0.eQuodSQpbSdsKiGAacuPzpuZcE)
				{
					sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Import(P_0.sdzgyVcwHqRpNJLIhbGtHGVnHPZd);
					OTlqpFsbeZGiyHOnqpLWAEXDeJCc.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.OTlqpFsbeZGiyHOnqpLWAEXDeJCc);
					RrAKkXBtOxVWtDsjNFtvnUqWJlI.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.RrAKkXBtOxVWtDsjNFtvnUqWJlI);
					SsZfFmhWTsgBHmKnmJrNkmligft.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.SsZfFmhWTsgBHmKnmJrNkmligft);
					svaNJVSHYqJtTvuXjDrXdclMBTr.ImportAll(P_0.svaNJVSHYqJtTvuXjDrXdclMBTr);
					cCqcBFaAsOGcyRRpMnEDcolJIGu = OTttRthNhavrHrLUUrYOhHUluQa.EDpXkbpKIjGArdDTMoOnuFQvDQmz(P_0.cCqcBFaAsOGcyRRpMnEDcolJIGu, RrAKkXBtOxVWtDsjNFtvnUqWJlI);
					eFIldJHAlwDZVMNuZYxdjxWSQFI = P_0.eFIldJHAlwDZVMNuZYxdjxWSQFI;
				}
			}
		}

		public void MsGJuKGSvMRQdmipZApDEoQeybl(int P_0, int P_1, int P_2, float P_3)
		{
			lock (eQuodSQpbSdsKiGAacuPzpuZcE)
			{
				cCqcBFaAsOGcyRRpMnEDcolJIGu = new OTttRthNhavrHrLUUrYOhHUluQa(RrAKkXBtOxVWtDsjNFtvnUqWJlI, P_0, P_1, P_2, P_3);
			}
		}

		private void GWCbbdPIhiDNAkQzqeBYraCCVNcS()
		{
			if (!eFIldJHAlwDZVMNuZYxdjxWSQFI)
			{
				return;
			}
			double realTime;
			try
			{
				ZfsAwHWQezYJXJnEkPTMXerdwlx.nPPFSRhCjNULnUJXWJMcGBiunWI(RrAKkXBtOxVWtDsjNFtvnUqWJlI);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (eQuodSQpbSdsKiGAacuPzpuZcE)
			{
				if (cCqcBFaAsOGcyRRpMnEDcolJIGu != null)
				{
					cCqcBFaAsOGcyRRpMnEDcolJIGu.RMEkOMsGFSFWbHqrAFftMTIKNIHO(realTime);
				}
				if (!RrAKkXBtOxVWtDsjNFtvnUqWJlI.hRAhnVKsaGNgnxFNtvrPglkcvJj(SsZfFmhWTsgBHmKnmJrNkmligft))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = svaNJVSHYqJtTvuXjDrXdclMBTr.T_CreateEvent())
					{
						cmIOoFiNpNIWemfyAoRFQFJGgFz.dKxTGBXdfPIXPVTurBkqGeUeLTw(RrAKkXBtOxVWtDsjNFtvnUqWJlI, realTime, newEventWrapper.Event);
					}
					SsZfFmhWTsgBHmKnmJrNkmligft.OcfraEykjBtASDrfWrlPPDyQQVt(RrAKkXBtOxVWtDsjNFtvnUqWJlI);
				}
			}
		}

		private void YOHpShjCXutwPTokdTvLDLpPiys()
		{
			while (svaNJVSHYqJtTvuXjDrXdclMBTr.ProcessNewEvents())
			{
				OTlqpFsbeZGiyHOnqpLWAEXDeJCc.OcfraEykjBtASDrfWrlPPDyQQVt(ref svaNJVSHYqJtTvuXjDrXdclMBTr.currentEvent);
				for (int i = 0; i < aORFycYuiaRmVGcJmTzHLSOPUlP; i++)
				{
					sdzgyVcwHqRpNJLIhbGtHGVnHPZd.SetValue(i, OTlqpFsbeZGiyHOnqpLWAEXDeJCc.TUYMVHGCBHgHkIfQYSkUtTsGyCJ[i], svaNJVSHYqJtTvuXjDrXdclMBTr.currentEvent.GetTimestamp());
				}
			}
		}

		private void TzBPrZngbKbHBhJPAmtHpHNMMTtf()
		{
			OTlqpFsbeZGiyHOnqpLWAEXDeJCc.avkcOhFlGGeHrNSdTQlLZUnJDbw();
			lock (eQuodSQpbSdsKiGAacuPzpuZcE)
			{
				RrAKkXBtOxVWtDsjNFtvnUqWJlI.avkcOhFlGGeHrNSdTQlLZUnJDbw();
				SsZfFmhWTsgBHmKnmJrNkmligft.avkcOhFlGGeHrNSdTQlLZUnJDbw();
				svaNJVSHYqJtTvuXjDrXdclMBTr.Clear();
			}
			sdzgyVcwHqRpNJLIhbGtHGVnHPZd.Clear();
		}

		public void Dispose()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
			GC.SuppressFinalize(this);
		}

		~yRlQRJWFBLpLKarYvNwwzBTmLPM()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (!euujVPFzGztViWDbYvUutBvFQFP)
			{
				if (P_0)
				{
					ibjqBHyFNJOhWJActsfrTOPbIjF();
					svaNJVSHYqJtTvuXjDrXdclMBTr.Dispose();
				}
				if (oizETVRXykJREMrljZxCoqipUeW.joystickInputThread != null)
				{
					oizETVRXykJREMrljZxCoqipUeW.joystickInputThread.ThreadUpdateEvent -= GWCbbdPIhiDNAkQzqeBYraCCVNcS;
				}
				euujVPFzGztViWDbYvUutBvFQFP = true;
			}
		}

		private static float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class OTttRthNhavrHrLUUrYOhHUluQa
	{
		private WdUgpcVePDxEWRCUGSnBbePWAHU PYDFLwbgYMAriugUauwNeWjnIQC;

		private ztRwfFqFoRtiDuJJXFsQQBQijgJ dqmohfdeShhhWHnLnlniIgAuqc;

		private int LRBjpQAKTdbssYrjZgkNWKcUdUr;

		private int GwOKPGGaEshUYCLrCcXhaOTjihRD;

		private int YqNEgVrViaaEdbPAhcvGrwkGGJoc;

		private float GWaAlREYHmtepVIUYvyXsIFYxGn;

		public WdUgpcVePDxEWRCUGSnBbePWAHU state => PYDFLwbgYMAriugUauwNeWjnIQC;

		public static OTttRthNhavrHrLUUrYOhHUluQa EDpXkbpKIjGArdDTMoOnuFQvDQmz(OTttRthNhavrHrLUUrYOhHUluQa P_0, WdUgpcVePDxEWRCUGSnBbePWAHU P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new OTttRthNhavrHrLUUrYOhHUluQa(P_0, P_1);
		}

		public OTttRthNhavrHrLUUrYOhHUluQa(WdUgpcVePDxEWRCUGSnBbePWAHU state, int axisMin, int axisMax, int axisZero, float eventTimeout)
			: this(axisMin, axisMax, axisZero, eventTimeout)
		{
			dqmohfdeShhhWHnLnlniIgAuqc = new ztRwfFqFoRtiDuJJXFsQQBQijgJ(state);
			PYDFLwbgYMAriugUauwNeWjnIQC = new WdUgpcVePDxEWRCUGSnBbePWAHU();
		}

		private OTttRthNhavrHrLUUrYOhHUluQa(OTttRthNhavrHrLUUrYOhHUluQa source, WdUgpcVePDxEWRCUGSnBbePWAHU state)
			: this(state, source.LRBjpQAKTdbssYrjZgkNWKcUdUr, source.GwOKPGGaEshUYCLrCcXhaOTjihRD, source.YqNEgVrViaaEdbPAhcvGrwkGGJoc, source.GWaAlREYHmtepVIUYvyXsIFYxGn)
		{
			OcfraEykjBtASDrfWrlPPDyQQVt(source);
		}

		private OTttRthNhavrHrLUUrYOhHUluQa(int axisMin, int axisMax, int axisZero, float axisTimeout)
		{
			LRBjpQAKTdbssYrjZgkNWKcUdUr = axisMin;
			GwOKPGGaEshUYCLrCcXhaOTjihRD = axisMax;
			YqNEgVrViaaEdbPAhcvGrwkGGJoc = axisZero;
			GWaAlREYHmtepVIUYvyXsIFYxGn = axisTimeout;
		}

		public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(double P_0)
		{
			dqmohfdeShhhWHnLnlniIgAuqc.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
			if (!dqmohfdeShhhWHnLnlniIgAuqc.valueChanged)
			{
				if (P_0 >= dqmohfdeShhhWHnLnlniIgAuqc.lastChangedTimestamp + (double)GWaAlREYHmtepVIUYvyXsIFYxGn)
				{
					PYDFLwbgYMAriugUauwNeWjnIQC.avkcOhFlGGeHrNSdTQlLZUnJDbw();
				}
				return;
			}
			WdUgpcVePDxEWRCUGSnBbePWAHU changedState = dqmohfdeShhhWHnLnlniIgAuqc.changedState;
			WdUgpcVePDxEWRCUGSnBbePWAHU sourceState = dqmohfdeShhhWHnLnlniIgAuqc.sourceState;
			PYDFLwbgYMAriugUauwNeWjnIQC.X = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.X);
			PYDFLwbgYMAriugUauwNeWjnIQC.Y = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.Y);
			PYDFLwbgYMAriugUauwNeWjnIQC.Z = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.Z);
			PYDFLwbgYMAriugUauwNeWjnIQC.RotationX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.RotationX);
			PYDFLwbgYMAriugUauwNeWjnIQC.RotationY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.RotationY);
			PYDFLwbgYMAriugUauwNeWjnIQC.RotationZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.RotationZ);
			for (int i = 0; i < PYDFLwbgYMAriugUauwNeWjnIQC.Sliders.Length; i++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.Sliders[i] = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.Sliders[i]);
			}
			for (int j = 0; j < PYDFLwbgYMAriugUauwNeWjnIQC.PointOfViewControllers.Length; j++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.PointOfViewControllers[j] = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.PointOfViewControllers[j]);
			}
			for (int k = 0; k < PYDFLwbgYMAriugUauwNeWjnIQC.Buttons.Length; k++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.Buttons[k] = sourceState.Buttons[k];
			}
			PYDFLwbgYMAriugUauwNeWjnIQC.VelocityX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.VelocityX);
			PYDFLwbgYMAriugUauwNeWjnIQC.VelocityY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.VelocityY);
			PYDFLwbgYMAriugUauwNeWjnIQC.VelocityZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.VelocityZ);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularVelocityX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularVelocityX);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularVelocityY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularVelocityY);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularVelocityZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularVelocityZ);
			for (int l = 0; l < PYDFLwbgYMAriugUauwNeWjnIQC.VelocitySliders.Length; l++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.VelocitySliders[l] = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.VelocitySliders[l]);
			}
			PYDFLwbgYMAriugUauwNeWjnIQC.AccelerationX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AccelerationX);
			PYDFLwbgYMAriugUauwNeWjnIQC.AccelerationY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AccelerationY);
			PYDFLwbgYMAriugUauwNeWjnIQC.AccelerationZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AccelerationZ);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularAccelerationX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularAccelerationX);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularAccelerationY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularAccelerationY);
			PYDFLwbgYMAriugUauwNeWjnIQC.AngularAccelerationZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AngularAccelerationZ);
			for (int m = 0; m < PYDFLwbgYMAriugUauwNeWjnIQC.AccelerationSliders.Length; m++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.AccelerationSliders[m] = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.AccelerationSliders[m]);
			}
			PYDFLwbgYMAriugUauwNeWjnIQC.ForceX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.ForceX);
			PYDFLwbgYMAriugUauwNeWjnIQC.ForceY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.ForceY);
			PYDFLwbgYMAriugUauwNeWjnIQC.ForceZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.ForceZ);
			PYDFLwbgYMAriugUauwNeWjnIQC.TorqueX = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.TorqueX);
			PYDFLwbgYMAriugUauwNeWjnIQC.TorqueY = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.TorqueY);
			PYDFLwbgYMAriugUauwNeWjnIQC.TorqueZ = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.TorqueZ);
			for (int n = 0; n < PYDFLwbgYMAriugUauwNeWjnIQC.ForceSliders.Length; n++)
			{
				PYDFLwbgYMAriugUauwNeWjnIQC.ForceSliders[n] = MAZtYNYhlZQdIvdJuIgDahdITeGJ(changedState.ForceSliders[n]);
			}
		}

		public void OcfraEykjBtASDrfWrlPPDyQQVt(OTttRthNhavrHrLUUrYOhHUluQa P_0)
		{
			PYDFLwbgYMAriugUauwNeWjnIQC.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.PYDFLwbgYMAriugUauwNeWjnIQC);
			dqmohfdeShhhWHnLnlniIgAuqc.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.dqmohfdeShhhWHnLnlniIgAuqc);
			LRBjpQAKTdbssYrjZgkNWKcUdUr = P_0.LRBjpQAKTdbssYrjZgkNWKcUdUr;
			GwOKPGGaEshUYCLrCcXhaOTjihRD = P_0.GwOKPGGaEshUYCLrCcXhaOTjihRD;
			YqNEgVrViaaEdbPAhcvGrwkGGJoc = P_0.YqNEgVrViaaEdbPAhcvGrwkGGJoc;
			GWaAlREYHmtepVIUYvyXsIFYxGn = P_0.GWaAlREYHmtepVIUYvyXsIFYxGn;
		}

		private int MAZtYNYhlZQdIvdJuIgDahdITeGJ(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, LRBjpQAKTdbssYrjZgkNWKcUdUr, GwOKPGGaEshUYCLrCcXhaOTjihRD, -65535, 65535);
		}
	}

	private class ztRwfFqFoRtiDuJJXFsQQBQijgJ
	{
		private double rCqxjNmczNrHWTHAiKutffIDnZq;

		private WdUgpcVePDxEWRCUGSnBbePWAHU YMeCOYfnoAEHrdUHVmcltErWdAk;

		private WdUgpcVePDxEWRCUGSnBbePWAHU DNgBcvcnStSyWRiGYZXvhYPTbGS;

		private WdUgpcVePDxEWRCUGSnBbePWAHU RuEEOmnlMAbeSAsEpZYNjbXChqaI;

		private bool ovLisKYidrPdSDHFmtsCPMjplaQ;

		private double cXSdPWaemORTvaJvVaTFOxbtxekW;

		public WdUgpcVePDxEWRCUGSnBbePWAHU sourceState => YMeCOYfnoAEHrdUHVmcltErWdAk;

		public WdUgpcVePDxEWRCUGSnBbePWAHU changedState => RuEEOmnlMAbeSAsEpZYNjbXChqaI;

		public bool valueChanged => ovLisKYidrPdSDHFmtsCPMjplaQ;

		public double lastChangedTimestamp => cXSdPWaemORTvaJvVaTFOxbtxekW;

		public ztRwfFqFoRtiDuJJXFsQQBQijgJ(WdUgpcVePDxEWRCUGSnBbePWAHU sourceState)
		{
			YMeCOYfnoAEHrdUHVmcltErWdAk = sourceState;
			DNgBcvcnStSyWRiGYZXvhYPTbGS = new WdUgpcVePDxEWRCUGSnBbePWAHU();
			RuEEOmnlMAbeSAsEpZYNjbXChqaI = new WdUgpcVePDxEWRCUGSnBbePWAHU();
		}

		public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(double P_0)
		{
			rCqxjNmczNrHWTHAiKutffIDnZq = P_0;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.X = YMeCOYfnoAEHrdUHVmcltErWdAk.X - DNgBcvcnStSyWRiGYZXvhYPTbGS.X;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.Y = YMeCOYfnoAEHrdUHVmcltErWdAk.Y - DNgBcvcnStSyWRiGYZXvhYPTbGS.Y;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.Z = YMeCOYfnoAEHrdUHVmcltErWdAk.Z - DNgBcvcnStSyWRiGYZXvhYPTbGS.Z;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationX = YMeCOYfnoAEHrdUHVmcltErWdAk.RotationX - DNgBcvcnStSyWRiGYZXvhYPTbGS.RotationX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationY = YMeCOYfnoAEHrdUHVmcltErWdAk.RotationY - DNgBcvcnStSyWRiGYZXvhYPTbGS.RotationY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationZ = YMeCOYfnoAEHrdUHVmcltErWdAk.RotationZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.RotationZ;
			for (int i = 0; i < YMeCOYfnoAEHrdUHVmcltErWdAk.Sliders.Length; i++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.Sliders[i] = YMeCOYfnoAEHrdUHVmcltErWdAk.Sliders[i] - DNgBcvcnStSyWRiGYZXvhYPTbGS.Sliders[i];
			}
			for (int j = 0; j < YMeCOYfnoAEHrdUHVmcltErWdAk.PointOfViewControllers.Length; j++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.PointOfViewControllers[j] = YMeCOYfnoAEHrdUHVmcltErWdAk.PointOfViewControllers[j] - DNgBcvcnStSyWRiGYZXvhYPTbGS.PointOfViewControllers[j];
			}
			for (int k = 0; k < YMeCOYfnoAEHrdUHVmcltErWdAk.Buttons.Length; k++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.Buttons[k] = YMeCOYfnoAEHrdUHVmcltErWdAk.Buttons[k] != DNgBcvcnStSyWRiGYZXvhYPTbGS.Buttons[k];
			}
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityX = YMeCOYfnoAEHrdUHVmcltErWdAk.VelocityX - DNgBcvcnStSyWRiGYZXvhYPTbGS.VelocityX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityY = YMeCOYfnoAEHrdUHVmcltErWdAk.VelocityY - DNgBcvcnStSyWRiGYZXvhYPTbGS.VelocityY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityZ = YMeCOYfnoAEHrdUHVmcltErWdAk.VelocityZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.VelocityZ;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityX = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularVelocityX - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularVelocityX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityY = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularVelocityY - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularVelocityY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityZ = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularVelocityZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularVelocityZ;
			for (int l = 0; l < YMeCOYfnoAEHrdUHVmcltErWdAk.VelocitySliders.Length; l++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocitySliders[l] = YMeCOYfnoAEHrdUHVmcltErWdAk.VelocitySliders[l] - DNgBcvcnStSyWRiGYZXvhYPTbGS.VelocitySliders[l];
			}
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationX = YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationX - DNgBcvcnStSyWRiGYZXvhYPTbGS.AccelerationX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationY = YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationY - DNgBcvcnStSyWRiGYZXvhYPTbGS.AccelerationY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationZ = YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.AccelerationZ;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationX = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularAccelerationX - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularAccelerationX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationY = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularAccelerationY - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularAccelerationY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationZ = YMeCOYfnoAEHrdUHVmcltErWdAk.AngularAccelerationZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.AngularAccelerationZ;
			for (int m = 0; m < YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationSliders.Length; m++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationSliders[m] = YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationSliders[m] - DNgBcvcnStSyWRiGYZXvhYPTbGS.AccelerationSliders[m];
			}
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceX = YMeCOYfnoAEHrdUHVmcltErWdAk.ForceX - DNgBcvcnStSyWRiGYZXvhYPTbGS.ForceX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceY = YMeCOYfnoAEHrdUHVmcltErWdAk.ForceY - DNgBcvcnStSyWRiGYZXvhYPTbGS.ForceY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceZ = YMeCOYfnoAEHrdUHVmcltErWdAk.ForceZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.ForceZ;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueX = YMeCOYfnoAEHrdUHVmcltErWdAk.TorqueX - DNgBcvcnStSyWRiGYZXvhYPTbGS.TorqueX;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueY = YMeCOYfnoAEHrdUHVmcltErWdAk.TorqueY - DNgBcvcnStSyWRiGYZXvhYPTbGS.TorqueY;
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueZ = YMeCOYfnoAEHrdUHVmcltErWdAk.TorqueZ - DNgBcvcnStSyWRiGYZXvhYPTbGS.TorqueZ;
			for (int n = 0; n < YMeCOYfnoAEHrdUHVmcltErWdAk.ForceSliders.Length; n++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceSliders[n] = YMeCOYfnoAEHrdUHVmcltErWdAk.ForceSliders[n] - DNgBcvcnStSyWRiGYZXvhYPTbGS.ForceSliders[n];
			}
			ovLisKYidrPdSDHFmtsCPMjplaQ = IHvqATDtZPavaevQbIHFoRyjfuM();
			if (ovLisKYidrPdSDHFmtsCPMjplaQ)
			{
				cXSdPWaemORTvaJvVaTFOxbtxekW = P_0;
				DNgBcvcnStSyWRiGYZXvhYPTbGS.OcfraEykjBtASDrfWrlPPDyQQVt(YMeCOYfnoAEHrdUHVmcltErWdAk);
			}
		}

		public void OcfraEykjBtASDrfWrlPPDyQQVt(ztRwfFqFoRtiDuJJXFsQQBQijgJ P_0)
		{
			rCqxjNmczNrHWTHAiKutffIDnZq = P_0.rCqxjNmczNrHWTHAiKutffIDnZq;
			DNgBcvcnStSyWRiGYZXvhYPTbGS.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.DNgBcvcnStSyWRiGYZXvhYPTbGS);
			RuEEOmnlMAbeSAsEpZYNjbXChqaI.OcfraEykjBtASDrfWrlPPDyQQVt(P_0.RuEEOmnlMAbeSAsEpZYNjbXChqaI);
		}

		private bool IHvqATDtZPavaevQbIHFoRyjfuM()
		{
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.Y != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.Z != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.RotationZ != 0)
			{
				return true;
			}
			for (int i = 0; i < YMeCOYfnoAEHrdUHVmcltErWdAk.Sliders.Length; i++)
			{
				if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.Sliders[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < YMeCOYfnoAEHrdUHVmcltErWdAk.PointOfViewControllers.Length; j++)
			{
				if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.PointOfViewControllers[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < YMeCOYfnoAEHrdUHVmcltErWdAk.Buttons.Length; k++)
			{
				if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.Buttons[k])
				{
					return true;
				}
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocityZ != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularVelocityZ != 0)
			{
				return true;
			}
			for (int l = 0; l < YMeCOYfnoAEHrdUHVmcltErWdAk.VelocitySliders.Length; l++)
			{
				if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.VelocitySliders[l] != 0)
				{
					return true;
				}
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationZ != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.AngularAccelerationZ != 0)
			{
				return true;
			}
			for (int m = 0; m < YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationSliders.Length; m++)
			{
				RuEEOmnlMAbeSAsEpZYNjbXChqaI.AccelerationSliders[m] = YMeCOYfnoAEHrdUHVmcltErWdAk.AccelerationSliders[m] - DNgBcvcnStSyWRiGYZXvhYPTbGS.AccelerationSliders[m];
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceZ != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueX != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueY != 0)
			{
				return true;
			}
			if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.TorqueZ != 0)
			{
				return true;
			}
			for (int n = 0; n < YMeCOYfnoAEHrdUHVmcltErWdAk.ForceSliders.Length; n++)
			{
				if (RuEEOmnlMAbeSAsEpZYNjbXChqaI.ForceSliders[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class JlsrxnFNvjhwJVuMUNteXOTPAxQ
	{
		public enum XnVbDpdWQZTgcfAbSpSeSDTBjwLk
		{
			ilLbvccjJelxRWfbtcIBpILmuaf = 0,
			CmVFEXBFtubByhJDbjNXIMOscxd = 1
		}

		public class TpysUuaoXiPszlaZbSgvafwubzvH
		{
			public int DnWOcqJTVBlYFHDWvysyPeNuQSq;

			public Guid JXoxeGNALkcNmYISRYNWKuuNuTE;

			public Guid XMpQMgBqYwmfmmIEFnscpkEovPA;

			public int TZaGiTqKIftsljYrtCTLiMFBVZE;

			public int cOVEXSAIuvbznALDYKQQXTxspUvG;

			public int xOcVIiUgaPmbRhbRYiQWvhIsYap;

			public int CyeGyzgLsveraNekyMxxiXDhXGK;

			public bool NitiHALsfYhXyGTeMMaYoAUmOkLM(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, XnVbDpdWQZTgcfAbSpSeSDTBjwLk P_1)
			{
				if (P_0.rewiredId == DnWOcqJTVBlYFHDWvysyPeNuQSq)
				{
					return true;
				}
				if (cOVEXSAIuvbznALDYKQQXTxspUvG != P_0.cOVEXSAIuvbznALDYKQQXTxspUvG)
				{
					return false;
				}
				if (xOcVIiUgaPmbRhbRYiQWvhIsYap != P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap)
				{
					return false;
				}
				if (CyeGyzgLsveraNekyMxxiXDhXGK != P_0.CyeGyzgLsveraNekyMxxiXDhXGK)
				{
					return false;
				}
				return P_1 switch
				{
					XnVbDpdWQZTgcfAbSpSeSDTBjwLk.ilLbvccjJelxRWfbtcIBpILmuaf => JXoxeGNALkcNmYISRYNWKuuNuTE == P_0.instanceGuid, 
					XnVbDpdWQZTgcfAbSpSeSDTBjwLk.CmVFEXBFtubByhJDbjNXIMOscxd => XMpQMgBqYwmfmmIEFnscpkEovPA == P_0.XMpQMgBqYwmfmmIEFnscpkEovPA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public override string ToString()
			{
				string text = "";
				object obj = text;
				text = string.Concat(obj, "rewiredId = ", DnWOcqJTVBlYFHDWvysyPeNuQSq, "\n");
				object obj2 = text;
				text = string.Concat(obj2, "instanceGuid = ", JXoxeGNALkcNmYISRYNWKuuNuTE, "\n");
				object obj3 = text;
				text = string.Concat(obj3, "typeIdentifierGuid = ", XMpQMgBqYwmfmmIEFnscpkEovPA, "\n");
				object obj4 = text;
				text = string.Concat(obj4, "lastInputManagerId = ", TZaGiTqKIftsljYrtCTLiMFBVZE, "\n");
				object obj5 = text;
				text = string.Concat(obj5, "hardwareAxisCount = ", cOVEXSAIuvbznALDYKQQXTxspUvG, "\n");
				object obj6 = text;
				text = string.Concat(obj6, "hardwareButtonCount = ", xOcVIiUgaPmbRhbRYiQWvhIsYap, "\n");
				object obj7 = text;
				return string.Concat(obj7, "hardwareHatCount = ", CyeGyzgLsveraNekyMxxiXDhXGK, "\n");
			}
		}

		private sealed class iITgfrPVxgbDBGLGjelGBxpaHNNV : IEnumerable<TpysUuaoXiPszlaZbSgvafwubzvH>, IEnumerator<TpysUuaoXiPszlaZbSgvafwubzvH>, IDisposable, IEnumerable, IEnumerator
		{
			private TpysUuaoXiPszlaZbSgvafwubzvH dTaSsHpnJJEVtDGLgOHQGZyYVIXQ;

			private int nvkdBavXrtgJBGDZFCTvwXCruwCj;

			private int OGvIvwIPzTVfaOeGoCjUFfAJsqp;

			public JlsrxnFNvjhwJVuMUNteXOTPAxQ jCCESxhkXKXRASiiyhhDQRyWTmj;

			public HzoWThWhXPgLoJWCdUXwIvXSOGyG PPWOKytbcnkKaUCfKMHWwNXGgOa;

			public HzoWThWhXPgLoJWCdUXwIvXSOGyG xKEfMxZmpqYVlMUlbsSseuDUpyd;

			public XnVbDpdWQZTgcfAbSpSeSDTBjwLk wjXCljJmUfGrplhoWeMtAGArnCgj;

			public XnVbDpdWQZTgcfAbSpSeSDTBjwLk QFGEAMdzmCAJVfrIOYQypKEJWxUF;

			public int rlZBDCFiXERUFjTbSKrtQruzdXi;

			public int UrLLjDCTNruBgWhwuVUXnWYdWCJ;

			TpysUuaoXiPszlaZbSgvafwubzvH IEnumerator<TpysUuaoXiPszlaZbSgvafwubzvH>.Current
			{
				[DebuggerHidden]
				get
				{
					return dTaSsHpnJJEVtDGLgOHQGZyYVIXQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return dTaSsHpnJJEVtDGLgOHQGZyYVIXQ;
				}
			}

			[DebuggerHidden]
			IEnumerator<TpysUuaoXiPszlaZbSgvafwubzvH> IEnumerable<TpysUuaoXiPszlaZbSgvafwubzvH>.GetEnumerator()
			{
				iITgfrPVxgbDBGLGjelGBxpaHNNV iITgfrPVxgbDBGLGjelGBxpaHNNV2;
				if (Thread.CurrentThread.ManagedThreadId == OGvIvwIPzTVfaOeGoCjUFfAJsqp && nvkdBavXrtgJBGDZFCTvwXCruwCj == -2)
				{
					nvkdBavXrtgJBGDZFCTvwXCruwCj = 0;
					iITgfrPVxgbDBGLGjelGBxpaHNNV2 = this;
				}
				else
				{
					iITgfrPVxgbDBGLGjelGBxpaHNNV2 = new iITgfrPVxgbDBGLGjelGBxpaHNNV(0);
					iITgfrPVxgbDBGLGjelGBxpaHNNV2.jCCESxhkXKXRASiiyhhDQRyWTmj = jCCESxhkXKXRASiiyhhDQRyWTmj;
				}
				iITgfrPVxgbDBGLGjelGBxpaHNNV2.PPWOKytbcnkKaUCfKMHWwNXGgOa = xKEfMxZmpqYVlMUlbsSseuDUpyd;
				iITgfrPVxgbDBGLGjelGBxpaHNNV2.wjXCljJmUfGrplhoWeMtAGArnCgj = QFGEAMdzmCAJVfrIOYQypKEJWxUF;
				return iITgfrPVxgbDBGLGjelGBxpaHNNV2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TpysUuaoXiPszlaZbSgvafwubzvH>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (nvkdBavXrtgJBGDZFCTvwXCruwCj)
				{
				case 0:
					nvkdBavXrtgJBGDZFCTvwXCruwCj = -1;
					rlZBDCFiXERUFjTbSKrtQruzdXi = jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT.Count;
					UrLLjDCTNruBgWhwuVUXnWYdWCJ = 0;
					goto IL_00a3;
				case 1:
					{
						nvkdBavXrtgJBGDZFCTvwXCruwCj = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (UrLLjDCTNruBgWhwuVUXnWYdWCJ >= rlZBDCFiXERUFjTbSKrtQruzdXi)
					{
						break;
					}
					if (jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT[UrLLjDCTNruBgWhwuVUXnWYdWCJ].NitiHALsfYhXyGTeMMaYoAUmOkLM(PPWOKytbcnkKaUCfKMHWwNXGgOa, wjXCljJmUfGrplhoWeMtAGArnCgj))
					{
						dTaSsHpnJJEVtDGLgOHQGZyYVIXQ = jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT[UrLLjDCTNruBgWhwuVUXnWYdWCJ];
						nvkdBavXrtgJBGDZFCTvwXCruwCj = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					UrLLjDCTNruBgWhwuVUXnWYdWCJ++;
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
			public iITgfrPVxgbDBGLGjelGBxpaHNNV(int _003C_003E1__state)
			{
				nvkdBavXrtgJBGDZFCTvwXCruwCj = _003C_003E1__state;
				OGvIvwIPzTVfaOeGoCjUFfAJsqp = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<TpysUuaoXiPszlaZbSgvafwubzvH> cRyaCDjwErkISWbxXDsigITBKjqT;

		public JlsrxnFNvjhwJVuMUNteXOTPAxQ()
		{
			cRyaCDjwErkISWbxXDsigITBKjqT = new List<TpysUuaoXiPszlaZbSgvafwubzvH>();
		}

		public void oOaPrTHEWDBSgKiiowMCWfzaAKNC(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = cRyaCDjwErkISWbxXDsigITBKjqT.Count;
			for (int i = 0; i < count; i++)
			{
				if (cRyaCDjwErkISWbxXDsigITBKjqT[i].NitiHALsfYhXyGTeMMaYoAUmOkLM(P_0, XnVbDpdWQZTgcfAbSpSeSDTBjwLk.ilLbvccjJelxRWfbtcIBpILmuaf))
				{
					cRyaCDjwErkISWbxXDsigITBKjqT[i].DnWOcqJTVBlYFHDWvysyPeNuQSq = P_0.rewiredId;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].JXoxeGNALkcNmYISRYNWKuuNuTE = P_0.instanceGuid;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].XMpQMgBqYwmfmmIEFnscpkEovPA = P_0.XMpQMgBqYwmfmmIEFnscpkEovPA;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].TZaGiTqKIftsljYrtCTLiMFBVZE = P_0.inputManagerId;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].cOVEXSAIuvbznALDYKQQXTxspUvG = P_0.cOVEXSAIuvbznALDYKQQXTxspUvG;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].xOcVIiUgaPmbRhbRYiQWvhIsYap = P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].CyeGyzgLsveraNekyMxxiXDhXGK = P_0.CyeGyzgLsveraNekyMxxiXDhXGK;
					CQoIzinEDcHJhCkDtGfbEenGggv(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			cRyaCDjwErkISWbxXDsigITBKjqT.Add(new TpysUuaoXiPszlaZbSgvafwubzvH
			{
				DnWOcqJTVBlYFHDWvysyPeNuQSq = P_0.rewiredId,
				JXoxeGNALkcNmYISRYNWKuuNuTE = P_0.instanceGuid,
				XMpQMgBqYwmfmmIEFnscpkEovPA = P_0.XMpQMgBqYwmfmmIEFnscpkEovPA,
				TZaGiTqKIftsljYrtCTLiMFBVZE = P_0.inputManagerId,
				cOVEXSAIuvbznALDYKQQXTxspUvG = P_0.cOVEXSAIuvbznALDYKQQXTxspUvG,
				xOcVIiUgaPmbRhbRYiQWvhIsYap = P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap,
				CyeGyzgLsveraNekyMxxiXDhXGK = P_0.CyeGyzgLsveraNekyMxxiXDhXGK
			});
			CQoIzinEDcHJhCkDtGfbEenGggv(P_0.rewiredId, P_0.instanceGuid, cRyaCDjwErkISWbxXDsigITBKjqT.Count - 1);
		}

		public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, XnVbDpdWQZTgcfAbSpSeSDTBjwLk P_1)
		{
			int count = cRyaCDjwErkISWbxXDsigITBKjqT.Count;
			for (int i = 0; i < count; i++)
			{
				if (cRyaCDjwErkISWbxXDsigITBKjqT[i].NitiHALsfYhXyGTeMMaYoAUmOkLM(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<TpysUuaoXiPszlaZbSgvafwubzvH> xGaEkUmWuamNBtSslvPYrVXhEeN(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, XnVbDpdWQZTgcfAbSpSeSDTBjwLk P_1)
		{
			iITgfrPVxgbDBGLGjelGBxpaHNNV iITgfrPVxgbDBGLGjelGBxpaHNNV2 = new iITgfrPVxgbDBGLGjelGBxpaHNNV(-2);
			iITgfrPVxgbDBGLGjelGBxpaHNNV2.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
			iITgfrPVxgbDBGLGjelGBxpaHNNV2.xKEfMxZmpqYVlMUlbsSseuDUpyd = P_0;
			iITgfrPVxgbDBGLGjelGBxpaHNNV2.QFGEAMdzmCAJVfrIOYQypKEJWxUF = P_1;
			return iITgfrPVxgbDBGLGjelGBxpaHNNV2;
		}

		private void CQoIzinEDcHJhCkDtGfbEenGggv(int P_0, Guid P_1, int P_2)
		{
			for (int num = cRyaCDjwErkISWbxXDsigITBKjqT.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (cRyaCDjwErkISWbxXDsigITBKjqT[num].DnWOcqJTVBlYFHDWvysyPeNuQSq == P_0 || cRyaCDjwErkISWbxXDsigITBKjqT[num].JXoxeGNALkcNmYISRYNWKuuNuTE == P_1))
				{
					cRyaCDjwErkISWbxXDsigITBKjqT.RemoveAt(num);
				}
			}
		}

		public override string ToString()
		{
			string text = "";
			object obj = text;
			text = string.Concat(obj, "Joystick records: ", cRyaCDjwErkISWbxXDsigITBKjqT.Count, "\n");
			for (int i = 0; i < cRyaCDjwErkISWbxXDsigITBKjqT.Count; i++)
			{
				object obj2 = text;
				text = string.Concat(obj2, "Record ", i, ":\n");
				text = text + cRyaCDjwErkISWbxXDsigITBKjqT[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class AqwgvrcZNltsgJzfCEjawIDjAveH
	{
		public HzoWThWhXPgLoJWCdUXwIvXSOGyG IAYCyCCfxLADdcDSjhLuqwShOQyR;

		public oavsBCpkURSQZhuDFrqXELCmmrM niPNEMrDAcpRFqRoYdlkrbLCjZFD;

		public bool IsValid
		{
			get
			{
				if (IAYCyCCfxLADdcDSjhLuqwShOQyR != null)
				{
					return niPNEMrDAcpRFqRoYdlkrbLCjZFD != null;
				}
				return false;
			}
		}

		public AqwgvrcZNltsgJzfCEjawIDjAveH(HzoWThWhXPgLoJWCdUXwIvXSOGyG joystick, oavsBCpkURSQZhuDFrqXELCmmrM deviceInstance)
		{
			IAYCyCCfxLADdcDSjhLuqwShOQyR = joystick;
			niPNEMrDAcpRFqRoYdlkrbLCjZFD = deviceInstance;
		}

		public static List<oavsBCpkURSQZhuDFrqXELCmmrM> FOnGkebBpOPuIDnARuXbbyIDVcG(List<AqwgvrcZNltsgJzfCEjawIDjAveH> P_0)
		{
			if (P_0 == null)
			{
				return new List<oavsBCpkURSQZhuDFrqXELCmmrM>();
			}
			List<oavsBCpkURSQZhuDFrqXELCmmrM> list = new List<oavsBCpkURSQZhuDFrqXELCmmrM>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IsValid)
				{
					list.Add(P_0[i].niPNEMrDAcpRFqRoYdlkrbLCjZFD);
				}
			}
			return list;
		}
	}

	private class diobgRaoqlIGiiQxBARWwoHKXeIF
	{
		public iKlolGPnHgrjtsiEOOZxcLUhJOe vkbcwaBOTdHtbRuPAtaaICgIGwKj;

		public diobgRaoqlIGiiQxBARWwoHKXeIF(iKlolGPnHgrjtsiEOOZxcLUhJOe sdxJoystick)
		{
			vkbcwaBOTdHtbRuPAtaaICgIGwKj = sdxJoystick;
		}
	}

	private class aTBBAzXGMVKKPFGpzqspXraYek
	{
		private HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA rKHGYPHognJflCcCuxavQcXAHZCG;

		private HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs jDsgZFvKyIFNOddOUgBCcYcLcYBe;

		private NativeBuffer TChanvyuMNePkBfhAgoDFzBHyYSj;

		private int QVotTPbSScDAXoDzIlwTtNlmEGf;

		public aTBBAzXGMVKKPFGpzqspXraYek()
		{
			rKHGYPHognJflCcCuxavQcXAHZCG = new HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA
			{
				LSkXGyldcGzcsniYgtVoxFzBUgQ = (uint)Marshal.SizeOf(typeof(HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA)),
				NxwKXiZZPzGfbqADNsYbSmCSZMr = true,
				SktzEWBrrBtdyOnqVaQOcPBxxEu = true,
				aWbSUhJDvCdVtkllSTkeGNeulCj = false,
				RfxaCqCTZtXRJOcskupfnYkFpXpO = true,
				jHDwUiAeZVEJETgBGdZFfndmbpOD = IntPtr.Zero
			};
			jDsgZFvKyIFNOddOUgBCcYcLcYBe = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs.XEZZaRuCBatWlcrdVaazQoMlqtI();
			TChanvyuMNePkBfhAgoDFzBHyYSj = new NativeBuffer((int)jDsgZFvKyIFNOddOUgBCcYcLcYBe.LSkXGyldcGzcsniYgtVoxFzBUgQ);
			TChanvyuMNePkBfhAgoDFzBHyYSj.Write(jDsgZFvKyIFNOddOUgBCcYcLcYBe.LSkXGyldcGzcsniYgtVoxFzBUgQ, 0);
		}

		public bool POJADZekprpNMmEYxtxDHfDKvqX()
		{
			int num = XuHOGZVIxTlXWkyfxSpBqjGRXSg();
			if (num == QVotTPbSScDAXoDzIlwTtNlmEGf)
			{
				return false;
			}
			QVotTPbSScDAXoDzIlwTtNlmEGf = num;
			return true;
		}

		public void pUHdSuIpGixnKHaicPGziCEexoed(int P_0)
		{
			QVotTPbSScDAXoDzIlwTtNlmEGf = P_0;
		}

		private int XuHOGZVIxTlXWkyfxSpBqjGRXSg()
		{
			try
			{
				return pDdfcWqxDAHCEFuHEUpBobYCGVaf.QKVNtxkIRUoPMrJFRDZsguZgSVJi(ref rKHGYPHognJflCcCuxavQcXAHZCG, TChanvyuMNePkBfhAgoDFzBHyYSj);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum MmRJUmGmuYaWGBxLajcHAEiJST
	{
		IwQsZkJYbdNBBYrWJIGRHvvDEft = 17,
		NcOiPCmfYWmxxojUswKfONTIHos = 18,
		cXiIaGSjeBKnSzIJGvtEtwBDTsm = 19,
		byUbkGgDbtpnARqSeOsTiHVjQYb = 20,
		cMDdbqtCLCmlakqTbYRMVcREdGI = 21,
		mvSrrAvfuJuFKHBdVurdUIXvett = 22,
		EbJjJPLABvUPxotWDOnmczJgiZJ = 23,
		mCMBVNZAfWZnoObhTYtWwXpBcBa = 24,
		BjyCAdvSujArvypTXKTkPudsUrN = 25,
		pIhaJNgYeJDmoquhEhpOvuNpzIW = 26,
		KGrNoupkwySknCIfKjgbJjrarLoA = 27,
		trhkPSQXrlgGYKIEsrhrpsGqNIH = 28
	}

	private const QyuEnlbUowDKQRpThenvnYsTHrA kKFatjAluHrBYlfnmIwpBFCDBPqs = QyuEnlbUowDKQRpThenvnYsTHrA.HGdLkhkeXxQgpeHxfXiEbkQICSv;

	private const acSaGRXzHfCbnAZWrzgPGuGjden xqLHoHyPNFVTDvAKEtJteEpzZrU = acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng;

	private IntPtr rMuaLDfFTUuFIHvODEHxuSzlVRy;

	private hhwTHKlniCMKoBzWDzyznYMwDzW yuVdsmfyNnpmsPViwqbiAHkqsVe;

	private List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> BNRwQaHYudxtMzjvBeOOjyanYNh;

	private int wzGTkrXSHKqeaqvfxQCkjnIiqSc;

	private JlsrxnFNvjhwJVuMUNteXOTPAxQ QLIrcBWnyhRCmcLMZBdCkDmlOPy;

	private bool UfAnsMESSCkSRBeUJaiZJkcfOhg;

	private bool hskpsPnisvnzcwCOJgZlUKENLCt;

	private UpdateLoopSetting GQeokIzsJjhywMdAXCjNZOQBbryb;

	private Action<int, ControllerDataUpdater> JcoiPGandIoCihCSGbQPMEFfAvAL;

	private PlatformInputManager LMMdhtGnZeQEOByzBHUxskBnUeW;

	private TimerRealTime IsLEnDVVrbdFbqVEnPhvPRYEfVA;

	private global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool> EIBumFyJQxRierGmhosrZtMvhiJ;

	private aTBBAzXGMVKKPFGpzqspXraYek fssAYMejSavawfmQNmnmLGGTAFH;

	private int PXPUejnLpqcYoOTAQyvCccUeiHy;

	private int BfgYsXGGQuRPiGyzquNTyhXfThi;

	private global::SmnfRaZRTCRKUNzdKVQSwqJahva<List<AqwgvrcZNltsgJzfCEjawIDjAveH>> xnhEOafvVmqEfCZFepVuWHXDLfDy;

	private readonly object DYqmLYQWtnCkUZCOjwXSRkHXDqs = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

	private Func<int> ngZnFDsAelLLgZWmCeeSqxddlic;

	public bool useXInput
	{
		set
		{
			hskpsPnisvnzcwCOJgZlUKENLCt = value;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => wzGTkrXSHKqeaqvfxQCkjnIiqSc;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => LMMdhtGnZeQEOByzBHUxskBnUeW;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => new InputSourceWrapper<hhwTHKlniCMKoBzWDzyznYMwDzW>(yuVdsmfyNnpmsPViwqbiAHkqsVe);

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.DirectInput;

	public gWmCLBokGZCLygUNKXrfUKPdZWyh(UpdateLoopSetting updateLoopSetting, bool useXInput, IntPtr windowHandle, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		try
		{
			GQeokIzsJjhywMdAXCjNZOQBbryb = updateLoopSetting;
			hskpsPnisvnzcwCOJgZlUKENLCt = useXInput;
			rMuaLDfFTUuFIHvODEHxuSzlVRy = windowHandle;
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			ngZnFDsAelLLgZWmCeeSqxddlic = getNewJoystickId;
			LMMdhtGnZeQEOByzBHUxskBnUeW = this;
			yuVdsmfyNnpmsPViwqbiAHkqsVe = new hhwTHKlniCMKoBzWDzyznYMwDzW();
			JcoiPGandIoCihCSGbQPMEFfAvAL = UpdateControllerData;
			fssAYMejSavawfmQNmnmLGGTAFH = new aTBBAzXGMVKKPFGpzqspXraYek();
			EIBumFyJQxRierGmhosrZtMvhiJ = new global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool>(useSharedThread: true, OJxCoLfeZjFQhrFCuSHuDWMBtMYV);
			xnhEOafvVmqEfCZFepVuWHXDLfDy = new global::SmnfRaZRTCRKUNzdKVQSwqJahva<List<AqwgvrcZNltsgJzfCEjawIDjAveH>>(useSharedThread: true, () => tXOqLLnAKSmaunbcEcdjEiMuDIH());
			gIdwgJtRpelzLADPjuhEHQdMCXH();
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
		QLIrcBWnyhRCmcLMZBdCkDmlOPy = new JlsrxnFNvjhwJVuMUNteXOTPAxQ();
		IsLEnDVVrbdFbqVEnPhvPRYEfVA = new TimerRealTime(1.0);
		IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		tQhisroJpENVBLZppInidJVbrlA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		XpvVWrsANNMckCqRQMluZpRCvUK();
		exSgneZYdsIdkachYNIgzYiIeQJ();
		kXnUTEtOoFIbAgXxuDGNUaTXqAh();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (xnhEOafvVmqEfCZFepVuWHXDLfDy != null)
		{
			xnhEOafvVmqEfCZFepVuWHXDLfDy.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
		}
		if (EIBumFyJQxRierGmhosrZtMvhiJ != null)
		{
			EIBumFyJQxRierGmhosrZtMvhiJ.KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
		}
		if (BNRwQaHYudxtMzjvBeOOjyanYNh == null)
		{
			return;
		}
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			for (int i = 0; i < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; i++)
			{
				if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null)
				{
					BNRwQaHYudxtMzjvBeOOjyanYNh[i].SdCpHXCeCCZSBrMShYjjsXEWWgu();
					BNRwQaHYudxtMzjvBeOOjyanYNh[i].KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return JcoiPGandIoCihCSGbQPMEFfAvAL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			for (int i = 0; i < wzGTkrXSHKqeaqvfxQCkjnIiqSc; i++)
			{
				if (BNRwQaHYudxtMzjvBeOOjyanYNh[i].inputManagerId == inputManagerId)
				{
					BNRwQaHYudxtMzjvBeOOjyanYNh[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		UfAnsMESSCkSRBeUJaiZJkcfOhg = true;
		IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		UfAnsMESSCkSRBeUJaiZJkcfOhg = true;
		IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
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

	private void XpvVWrsANNMckCqRQMluZpRCvUK()
	{
		if (EIBumFyJQxRierGmhosrZtMvhiJ.isRunning)
		{
			if (EIBumFyJQxRierGmhosrZtMvhiJ.wcZXiwBuSxlGFrbXURQEZElVWiH() && !IsLEnDVVrbdFbqVEnPhvPRYEfVA.running && !xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning)
			{
				if (EIBumFyJQxRierGmhosrZtMvhiJ.result)
				{
					UfAnsMESSCkSRBeUJaiZJkcfOhg = true;
				}
				IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
			}
		}
		else if (!IsLEnDVVrbdFbqVEnPhvPRYEfVA.running)
		{
			IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		}
		else if (IsLEnDVVrbdFbqVEnPhvPRYEfVA.Update())
		{
			EIBumFyJQxRierGmhosrZtMvhiJ.HnocEhRkacOxHhLLsmQmCGWhJlU();
		}
	}

	private List<AqwgvrcZNltsgJzfCEjawIDjAveH> tXOqLLnAKSmaunbcEcdjEiMuDIH()
	{
		List<AqwgvrcZNltsgJzfCEjawIDjAveH> list = new List<AqwgvrcZNltsgJzfCEjawIDjAveH>();
		IList<oavsBCpkURSQZhuDFrqXELCmmrM> list2 = klbvKHRbAbgdQrlKusaGEExMexg();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				oavsBCpkURSQZhuDFrqXELCmmrM oavsBCpkURSQZhuDFrqXELCmmrM2 = list2[i];
				Guid rShFIeIDKVTszLkmTmIZgIPGwGWB = oavsBCpkURSQZhuDFrqXELCmmrM2.rShFIeIDKVTszLkmTmIZgIPGwGWB;
				iKlolGPnHgrjtsiEOOZxcLUhJOe iKlolGPnHgrjtsiEOOZxcLUhJOe2 = new iKlolGPnHgrjtsiEOOZxcLUhJOe(yuVdsmfyNnpmsPViwqbiAHkqsVe, rShFIeIDKVTszLkmTmIZgIPGwGWB);
				TkMGeKCCDKyLeVkGOpDxzRBwtTD properties = iKlolGPnHgrjtsiEOOZxcLUhJOe2.Properties;
				bool flag = false;
				if (!hskpsPnisvnzcwCOJgZlUKENLCt)
				{
					goto IL_008b;
				}
				flag = dSElFGVpyqTZVtKoEbCEnZfBwBs.AtUjsMHXuqlHRCvkrgGRGBocvYd(properties.InterfacePath, StringTools.SanitizeDeviceString(oavsBCpkURSQZhuDFrqXELCmmrM2.DgEhJocJJkZoJBLmmHdIFnYalFtw), string.Empty, oavsBCpkURSQZhuDFrqXELCmmrM2.oeNdQWoDfdJZbQNVIMHzlNMZeJp);
				if (!flag)
				{
					goto IL_008b;
				}
				goto end_IL_0027;
				IL_008b:
				Guid guid = ((!string.IsNullOrEmpty(properties.InterfacePath)) ? MiscTools.CreateGuidHashSHA256(properties.InterfacePath) : oavsBCpkURSQZhuDFrqXELCmmrM2.rShFIeIDKVTszLkmTmIZgIPGwGWB);
				bool flag2 = false;
				lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
				{
					if (BNRwQaHYudxtMzjvBeOOjyanYNh != null)
					{
						for (int j = 0; j < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; j++)
						{
							if (BNRwQaHYudxtMzjvBeOOjyanYNh[j] != null && BNRwQaHYudxtMzjvBeOOjyanYNh[j].zAgUTYpwnGscdFlNDxXqCoyIrDh == guid)
							{
								iKlolGPnHgrjtsiEOOZxcLUhJOe2 = BNRwQaHYudxtMzjvBeOOjyanYNh[j].fUWusVflpgaWsSNSoAiTBPWnobsa.ZfsAwHWQezYJXJnEkPTMXerdwlx;
								flag2 = true;
								break;
							}
						}
					}
				}
				HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = new HzoWThWhXPgLoJWCdUXwIvXSOGyG(new yRlQRJWFBLpLKarYvNwwzBTmLPM(iKlolGPnHgrjtsiEOOZxcLUhJOe2, GQeokIzsJjhywMdAXCjNZOQBbryb), muwCboYBpXBddhISLPoaIQYyEVOW);
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.niPNEMrDAcpRFqRoYdlkrbLCjZFD = oavsBCpkURSQZhuDFrqXELCmmrM2;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.xAjwjehTWQJNfiRQZtsPAVhpGDq = oavsBCpkURSQZhuDFrqXELCmmrM2.ZrLcNvIYVboEDVecrwufnkQYMVh;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.zAgUTYpwnGscdFlNDxXqCoyIrDh = guid;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.RoslMAzcuMRQRlOImiNlFrTtTTTb = StringTools.SanitizeDeviceString(oavsBCpkURSQZhuDFrqXELCmmrM2.DgEhJocJJkZoJBLmmHdIFnYalFtw);
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.ryufZshRWEThUUWWibRppcJadxfg = oavsBCpkURSQZhuDFrqXELCmmrM2.oeNdQWoDfdJZbQNVIMHzlNMZeJp;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.nybQUKNBcNvNqFOQAMgQTsHaDTX = (MmRJUmGmuYaWGBxLajcHAEiJST)oavsBCpkURSQZhuDFrqXELCmmrM2.Type;
				kKjAsbERtYZOrmukDYBJeIwsHkb capabilities = iKlolGPnHgrjtsiEOOZxcLUhJOe2.Capabilities;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.alBpuJrvfbBbJganskpQSPVakoV = properties.ProductId;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.BqXBiRECKKlUBedponJUgsIHutKP = flag;
				try
				{
					hzoWThWhXPgLoJWCdUXwIvXSOGyG.nQnRhDVRHBdclEftFaviShDQJSn = properties.JoystickId;
				}
				catch (Exception)
				{
					hzoWThWhXPgLoJWCdUXwIvXSOGyG.nQnRhDVRHBdclEftFaviShDQJSn = 0;
				}
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.cOVEXSAIuvbznALDYKQQXTxspUvG = capabilities.wbsCjjmacTLyfxArQKRouMOsODD;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.xOcVIiUgaPmbRhbRYiQWvhIsYap = capabilities.qcyHpxgSpKtegmJpDPmnhYbZINb;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.CyeGyzgLsveraNekyMxxiXDhXGK = capabilities.NqgfKCdrcZpooGlIRIZbRyRYknzC;
				xybHoTjxMjfJdEEswduUJosgrdK(hzoWThWhXPgLoJWCdUXwIvXSOGyG, properties, out hzoWThWhXPgLoJWCdUXwIvXSOGyG.tNEwBRRTowMZppuozlRUAoDKupf);
				try
				{
					string productName;
					try
					{
						productName = properties.ProductName;
					}
					catch
					{
						productName = hzoWThWhXPgLoJWCdUXwIvXSOGyG.RoslMAzcuMRQRlOImiNlFrTtTTTb;
					}
					if (SpecialDevices.RequiresRelativeToAbsoluteAxisConversion((ushort)properties.VendorId, (ushort)properties.ProductId, productName) && SpecialDevices.GetRelativeAxisRanges((ushort)properties.VendorId, (ushort)properties.ProductId, productName, out var min, out var max, out var zero))
					{
						hzoWThWhXPgLoJWCdUXwIvXSOGyG.fUWusVflpgaWsSNSoAiTBPWnobsa.MsGJuKGSvMRQdmipZApDEoQeybl(min, max, zero, SpecialDevices.GetRelativeToAbsoluteAxisEventTimeout((ushort)properties.VendorId, (ushort)properties.ProductId, productName));
					}
				}
				catch (Exception)
				{
				}
				if (!flag2)
				{
					IList<HMxBjwmUHlBNPuNunDJFOGXNgBM> list3 = iKlolGPnHgrjtsiEOOZxcLUhJOe2.IFFbiNRSHlxwESfkhJMQeVdlaxt();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].UVnyDmtbPFbaoFixbwSAhHizrTQ.Flags & pYDUQtFWywMKELdMLkqFCiEuGzi.UAwdzUChrEKCiSlcRUpBPrHWtId) != pYDUQtFWywMKELdMLkqFCiEuGzi.cXEeBjOXiiTJnTtduUOyunqeJia)
							{
								iKlolGPnHgrjtsiEOOZxcLUhJOe2.Properties.Range = new IEgwOtJfzUHOcmGCEHySfandPNq(-65535, 65535);
							}
						}
					}
					iKlolGPnHgrjtsiEOOZxcLUhJOe2.Properties.AxisMode = QSvXhjzSZRyksOJVtELpRniIpoT.FpFuDJixgIjNpJNbZtjuHoDmJfb;
					iKlolGPnHgrjtsiEOOZxcLUhJOe2.sxaaQbLrQWZcwlialNsBVlyEbOh(rMuaLDfFTUuFIHvODEHxuSzlVRy, lHxqyinfHWWBZhZcGjdKqnyjyRx.SMGzjgYhUzDpUmDsvVtOowLpLOa | lHxqyinfHWWBZhZcGjdKqnyjyRx.HLYcrcOUkpyFzuaQXjRfrOjlfo);
					iKlolGPnHgrjtsiEOOZxcLUhJOe2.DfoHKTaxZzJSYcaLwTWUBUINGoo();
				}
				list.Add(new AqwgvrcZNltsgJzfCEjawIDjAveH(hzoWThWhXPgLoJWCdUXwIvXSOGyG, oavsBCpkURSQZhuDFrqXELCmmrM2));
				end_IL_0027:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void tQhisroJpENVBLZppInidJVbrlA()
	{
		GGGFfpxwYmbXfFQvdJlYVCfQrbro(tXOqLLnAKSmaunbcEcdjEiMuDIH());
	}

	private void GGGFfpxwYmbXfFQvdJlYVCfQrbro(List<AqwgvrcZNltsgJzfCEjawIDjAveH> P_0)
	{
		List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> list = new List<HzoWThWhXPgLoJWCdUXwIvXSOGyG>();
		PXPUejnLpqcYoOTAQyvCccUeiHy = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].IsValid)
			{
				continue;
			}
			try
			{
				HzoWThWhXPgLoJWCdUXwIvXSOGyG iAYCyCCfxLADdcDSjhLuqwShOQyR = P_0[i].IAYCyCCfxLADdcDSjhLuqwShOQyR;
				iAYCyCCfxLADdcDSjhLuqwShOQyR.vKgBIMftcSDdNIHlYFBnbgIECncp();
				if (iAYCyCCfxLADdcDSjhLuqwShOQyR.KcCwYwApJNGgFSVHZTdItDIiFcvD)
				{
					PXPUejnLpqcYoOTAQyvCccUeiHy++;
				}
				list.Add(iAYCyCCfxLADdcDSjhLuqwShOQyR);
			}
			catch (Exception)
			{
			}
		}
		fssAYMejSavawfmQNmnmLGGTAFH.pUHdSuIpGixnKHaicPGziCEexoed(PXPUejnLpqcYoOTAQyvCccUeiHy);
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> bNRwQaHYudxtMzjvBeOOjyanYNh = BNRwQaHYudxtMzjvBeOOjyanYNh;
			int num2 = wzGTkrXSHKqeaqvfxQCkjnIiqSc;
			int count = list.Count;
			RpJREBaKEEUqrCItLUjNcKalNhO(num2, count, bNRwQaHYudxtMzjvBeOOjyanYNh, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			MUAlBSDbWugPHscLdGflzkxxmAr(bNRwQaHYudxtMzjvBeOOjyanYNh, list, false);
			MUAlBSDbWugPHscLdGflzkxxmAr(list, bNRwQaHYudxtMzjvBeOOjyanYNh, true);
			UGRINmavTNbOeFmqxtqEMJXmDVk(list, bNRwQaHYudxtMzjvBeOOjyanYNh);
			BNRwQaHYudxtMzjvBeOOjyanYNh = list;
			wzGTkrXSHKqeaqvfxQCkjnIiqSc = list.Count;
		}
	}

	private void xybHoTjxMjfJdEEswduUJosgrdK(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, TkMGeKCCDKyLeVkGOpDxzRBwtTD P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(P_1.InterfacePath);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			oODKWlXjjUaKGJbFcHDHZKTTKwC oODKWlXjjUaKGJbFcHDHZKTTKwC2 = pDdfcWqxDAHCEFuHEUpBobYCGVaf.ZmFojZlQEqlGHAKPEqdTPnbWmvR(text.ToLower(CultureInfo.InvariantCulture));
			if (oODKWlXjjUaKGJbFcHDHZKTTKwC2 != null)
			{
				P_0.KcCwYwApJNGgFSVHZTdItDIiFcvD = oODKWlXjjUaKGJbFcHDHZKTTKwC2.IsBluetoothDevice;
				P_0.QqssUOlwiVEPRaCsLVgJqEHvHwg = oODKWlXjjUaKGJbFcHDHZKTTKwC2.BluetoothDeviceName;
				P_2 = MwoFssxjTIQzJQFdgnRgTEwkueQ.FUEfOdGwzMIRJkpsPreVXOvWCDd(oODKWlXjjUaKGJbFcHDHZKTTKwC2, P_0.ryufZshRWEThUUWWibRppcJadxfg, P_0.RoslMAzcuMRQRlOImiNlFrTtTTTb, P_0.QqssUOlwiVEPRaCsLVgJqEHvHwg);
				oODKWlXjjUaKGJbFcHDHZKTTKwC2.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void kXnUTEtOoFIbAgXxuDGNUaTXqAh()
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			for (int i = 0; i < wzGTkrXSHKqeaqvfxQCkjnIiqSc; i++)
			{
				try
				{
					HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = BNRwQaHYudxtMzjvBeOOjyanYNh[i];
					if (hzoWThWhXPgLoJWCdUXwIvXSOGyG != null && hzoWThWhXPgLoJWCdUXwIvXSOGyG.DHmcXFAgLYfMVKfsvVmyMSVwNMPb() && (!hskpsPnisvnzcwCOJgZlUKENLCt || !hzoWThWhXPgLoJWCdUXwIvXSOGyG.BqXBiRECKKlUBedponJUgsIHutKP))
					{
						hzoWThWhXPgLoJWCdUXwIvXSOGyG.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<oavsBCpkURSQZhuDFrqXELCmmrM> klbvKHRbAbgdQrlKusaGEExMexg()
	{
		try
		{
			IList<oavsBCpkURSQZhuDFrqXELCmmrM> list = yuVdsmfyNnpmsPViwqbiAHkqsVe.yDqiGSkMQYxYBcosfJNCvDgVcTXc(QyuEnlbUowDKQRpThenvnYsTHrA.HGdLkhkeXxQgpeHxfXiEbkQICSv, acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng);
			BfgYsXGGQuRPiGyzquNTyhXfThi = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			BfgYsXGGQuRPiGyzquNTyhXfThi = 0;
			return EmptyObjects<oavsBCpkURSQZhuDFrqXELCmmrM>.EmptyReadOnlyIListT;
		}
	}

	private void gIdwgJtRpelzLADPjuhEHQdMCXH()
	{
		yuVdsmfyNnpmsPViwqbiAHkqsVe.yDqiGSkMQYxYBcosfJNCvDgVcTXc();
	}

	private void RpJREBaKEEUqrCItLUjNcKalNhO(int P_0, int P_1, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_2, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(HzoWThWhXPgLoJWCdUXwIvXSOGyG.IXhtCFsFifIXBgUBDrBxKdNjSso);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			DBTDfQTzxMkYHtAeEeZhgFTticed(P_1, P_3, P_0, P_2, JlsrxnFNvjhwJVuMUNteXOTPAxQ.XnVbDpdWQZTgcfAbSpSeSDTBjwLk.ilLbvccjJelxRWfbtcIBpILmuaf);
		}
		XJHgXlxPExiOYhHWnfYtJbLohhlX(P_1, P_3, JlsrxnFNvjhwJVuMUNteXOTPAxQ.XnVbDpdWQZTgcfAbSpSeSDTBjwLk.ilLbvccjJelxRWfbtcIBpILmuaf);
		for (int i = 0; i < P_1; i++)
		{
			HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = P_3[i];
			if (hzoWThWhXPgLoJWCdUXwIvXSOGyG != null && hzoWThWhXPgLoJWCdUXwIvXSOGyG.inputManagerId < 0)
			{
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.inputManagerId = mEtKtHeMEfFpKIBRPfsUzIoWAkW(P_3);
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.rewiredId = ngZnFDsAelLLgZWmCeeSqxddlic();
				QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(hzoWThWhXPgLoJWCdUXwIvXSOGyG);
			}
		}
		P_3.Sort(HzoWThWhXPgLoJWCdUXwIvXSOGyG.pGjfuRAfDSILvnrsYiKAbBWPKog);
	}

	private void uPilyqFCmZcpxiagfHMxBZTCAMID(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0, int P_1, int P_2)
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

	private bool uDuHIdzqXFVTRKaQtgEBWDVXSAc(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0, int P_1)
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

	private int mEtKtHeMEfFpKIBRPfsUzIoWAkW(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0)
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

	private bool wKWHaqaZomwvSwqVVGwMUDIDYZx(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0, int P_1)
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

	private void DBTDfQTzxMkYHtAeEeZhgFTticed(int P_0, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_1, int P_2, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_3, JlsrxnFNvjhwJVuMUNteXOTPAxQ.XnVbDpdWQZTgcfAbSpSeSDTBjwLk P_4)
	{
		int num = ((P_4 != JlsrxnFNvjhwJVuMUNteXOTPAxQ.XnVbDpdWQZTgcfAbSpSeSDTBjwLk.ilLbvccjJelxRWfbtcIBpILmuaf) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = P_1[i];
			if (hzoWThWhXPgLoJWCdUXwIvXSOGyG == null || hzoWThWhXPgLoJWCdUXwIvXSOGyG.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG2 = P_3[j];
				if (hzoWThWhXPgLoJWCdUXwIvXSOGyG2 != null && !wKWHaqaZomwvSwqVVGwMUDIDYZx(P_1, hzoWThWhXPgLoJWCdUXwIvXSOGyG2.rewiredId) && hzoWThWhXPgLoJWCdUXwIvXSOGyG.NitiHALsfYhXyGTeMMaYoAUmOkLM(hzoWThWhXPgLoJWCdUXwIvXSOGyG2) >= num)
				{
					hzoWThWhXPgLoJWCdUXwIvXSOGyG.jGCYCANCzJiiLhbbuKOMrbCwWVt(hzoWThWhXPgLoJWCdUXwIvXSOGyG2);
					QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(hzoWThWhXPgLoJWCdUXwIvXSOGyG);
				}
			}
		}
	}

	private void XJHgXlxPExiOYhHWnfYtJbLohhlX(int P_0, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_1, JlsrxnFNvjhwJVuMUNteXOTPAxQ.XnVbDpdWQZTgcfAbSpSeSDTBjwLk P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = P_1[i];
			if (hzoWThWhXPgLoJWCdUXwIvXSOGyG == null || hzoWThWhXPgLoJWCdUXwIvXSOGyG.inputManagerId >= 0)
			{
				continue;
			}
			JlsrxnFNvjhwJVuMUNteXOTPAxQ.TpysUuaoXiPszlaZbSgvafwubzvH tpysUuaoXiPszlaZbSgvafwubzvH = null;
			foreach (JlsrxnFNvjhwJVuMUNteXOTPAxQ.TpysUuaoXiPszlaZbSgvafwubzvH item in QLIrcBWnyhRCmcLMZBdCkDmlOPy.xGaEkUmWuamNBtSslvPYrVXhEeN(hzoWThWhXPgLoJWCdUXwIvXSOGyG, P_2))
			{
				if (!wKWHaqaZomwvSwqVVGwMUDIDYZx(P_1, item.DnWOcqJTVBlYFHDWvysyPeNuQSq) && item.TZaGiTqKIftsljYrtCTLiMFBVZE >= 0)
				{
					tpysUuaoXiPszlaZbSgvafwubzvH = item;
					break;
				}
			}
			if (tpysUuaoXiPszlaZbSgvafwubzvH != null)
			{
				int num = tpysUuaoXiPszlaZbSgvafwubzvH.TZaGiTqKIftsljYrtCTLiMFBVZE;
				if (!uDuHIdzqXFVTRKaQtgEBWDVXSAc(P_1, num))
				{
					num = (tpysUuaoXiPszlaZbSgvafwubzvH.TZaGiTqKIftsljYrtCTLiMFBVZE = mEtKtHeMEfFpKIBRPfsUzIoWAkW(P_1));
				}
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.inputManagerId = num;
				hzoWThWhXPgLoJWCdUXwIvXSOGyG.rewiredId = tpysUuaoXiPszlaZbSgvafwubzvH.DnWOcqJTVBlYFHDWvysyPeNuQSq;
				QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(hzoWThWhXPgLoJWCdUXwIvXSOGyG);
			}
		}
	}

	private void exSgneZYdsIdkachYNIgzYiIeQJ()
	{
		if (UfAnsMESSCkSRBeUJaiZJkcfOhg)
		{
			ADgVHLRwiilDWZwTLColkzizLqb();
		}
		if (xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning && xnhEOafvVmqEfCZFepVuWHXDLfDy.wcZXiwBuSxlGFrbXURQEZElVWiH())
		{
			PTWORQqgBdUCodONUbJlUWFGkKU(xnhEOafvVmqEfCZFepVuWHXDLfDy.result);
		}
	}

	private void ADgVHLRwiilDWZwTLColkzizLqb()
	{
		UfAnsMESSCkSRBeUJaiZJkcfOhg = false;
		if (!xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning)
		{
			xnhEOafvVmqEfCZFepVuWHXDLfDy.HnocEhRkacOxHhLLsmQmCGWhJlU();
		}
	}

	private void PTWORQqgBdUCodONUbJlUWFGkKU(List<AqwgvrcZNltsgJzfCEjawIDjAveH> P_0)
	{
		if (ibDYRtIWfbPqvRKtYpccgjnNpPp(AqwgvrcZNltsgJzfCEjawIDjAveH.FOnGkebBpOPuIDnARuXbbyIDVcG(P_0)))
		{
			GGGFfpxwYmbXfFQvdJlYVCfQrbro(P_0);
		}
	}

	private bool ibDYRtIWfbPqvRKtYpccgjnNpPp(IList<oavsBCpkURSQZhuDFrqXELCmmrM> P_0)
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !fviCveaaVVLiPSTBJMVwqiqgKjGf(P_0[i].rShFIeIDKVTszLkmTmIZgIPGwGWB))
				{
					return true;
				}
			}
			int count2 = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
			for (int j = 0; j < count2; j++)
			{
				if (BNRwQaHYudxtMzjvBeOOjyanYNh[j] != null && !OCeKMHwBjvtydhmVyhVOyGNGvgf(P_0, BNRwQaHYudxtMzjvBeOOjyanYNh[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool fviCveaaVVLiPSTBJMVwqiqgKjGf(Guid P_0)
	{
		lock (DYqmLYQWtnCkUZCOjwXSRkHXDqs)
		{
			int count = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
			for (int i = 0; i < count; i++)
			{
				if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null && BNRwQaHYudxtMzjvBeOOjyanYNh[i].instanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool OCeKMHwBjvtydhmVyhVOyGNGvgf(IList<oavsBCpkURSQZhuDFrqXELCmmrM> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].rShFIeIDKVTszLkmTmIZgIPGwGWB == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void MUAlBSDbWugPHscLdGflzkxxmAr(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG = P_0[i];
			if (hzoWThWhXPgLoJWCdUXwIvXSOGyG == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					HzoWThWhXPgLoJWCdUXwIvXSOGyG hzoWThWhXPgLoJWCdUXwIvXSOGyG2 = P_1[j];
					if (hzoWThWhXPgLoJWCdUXwIvXSOGyG2 != null && hzoWThWhXPgLoJWCdUXwIvXSOGyG.instanceGuid == hzoWThWhXPgLoJWCdUXwIvXSOGyG2.instanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				ybsGugBBooRgYsLwSUUgUZpACxl(P_0[i], P_2);
			}
		}
	}

	private void ybsGugBBooRgYsLwSUUgUZpACxl(HzoWThWhXPgLoJWCdUXwIvXSOGyG P_0, bool P_1)
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

	private bool OJxCoLfeZjFQhrFCuSHuDWMBtMYV()
	{
		int num = yuVdsmfyNnpmsPViwqbiAHkqsVe.tRnqqsboVUqGBCogAlxstdlVGjpa(QyuEnlbUowDKQRpThenvnYsTHrA.HGdLkhkeXxQgpeHxfXiEbkQICSv, acSaGRXzHfCbnAZWrzgPGuGjden.xycNSjFEVhRECdalUfBPpVOeFZng);
		if (BfgYsXGGQuRPiGyzquNTyhXfThi != num)
		{
			BfgYsXGGQuRPiGyzquNTyhXfThi = num;
			return true;
		}
		if (PXPUejnLpqcYoOTAQyvCccUeiHy > 0 && fssAYMejSavawfmQNmnmLGGTAFH.POJADZekprpNMmEYxtxDHfDKvqX())
		{
			return true;
		}
		return false;
	}

	private void UGRINmavTNbOeFmqxtqEMJXmDVk(List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_0, List<HzoWThWhXPgLoJWCdUXwIvXSOGyG> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void SUbkefTLxKciKbHRLcRxUFTEtXM(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<AqwgvrcZNltsgJzfCEjawIDjAveH> grfWgzdrTbzxdffKOfQHZcaLfzH()
	{
		return tXOqLLnAKSmaunbcEcdjEiMuDIH();
	}
}
