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

internal class CKORtxtALbxyeRsqoWjMACyCwcV : PlatformInputManager, hVogZkGpYOPjCtJVInzVFePlclN
{
	private class bPLgxNnBUaabocrbwwumoDYtmwe : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int CeIdVJsUwjdwsuPBCtZxfxIInIm;

		private int VbfjQpAQVkwFagQXhUQnioLEhvsN;

		public Guid QmLKgYYPeYYRxIivEciniTYoXdO;

		public string YGVWsQIdEPlUdLcmFGBdDRxwphL;

		private readonly XISatJdVArtMUkOXRoGcIhpgBatq IAYCyCCfxLADdcDSjhLuqwShOQyR;

		private readonly DeviceType QKVxwHSyOwwVXVXAWMMCGgYRAFv;

		public string xAjwjehTWQJNfiRQZtsPAVhpGDq;

		public string RoslMAzcuMRQRlOImiNlFrTtTTTb;

		public string QqssUOlwiVEPRaCsLVgJqEHvHwg;

		public int alBpuJrvfbBbJganskpQSPVakoV;

		public int IqbmTkZzBzpzKtwCqxczmcnUnOd;

		public Guid zAgUTYpwnGscdFlNDxXqCoyIrDh;

		public Guid ryufZshRWEThUUWWibRppcJadxfg;

		public Guid XMpQMgBqYwmfmmIEFnscpkEovPA;

		public int nQnRhDVRHBdclEftFaviShDQJSn;

		public int dQifsxjMWJbLcEtOzEAXaRvCMoW;

		public int qItqYPQVfmselpOVATDJcXAPBWB;

		public int cOVEXSAIuvbznALDYKQQXTxspUvG;

		public int xOcVIiUgaPmbRhbRYiQWvhIsYap;

		public int CyeGyzgLsveraNekyMxxiXDhXGK;

		public bool BqXBiRECKKlUBedponJUgsIHutKP;

		public bool KcCwYwApJNGgFSVHZTdItDIiFcvD;

		public bool rPgbDjuxkQCjUxKyoCDTJEWtoRC;

		public int sDsTvNDeoHDFRZJJKqHNfQsWBFne;

		private float[] MyEdCYiRJtoncZaamVaftBLHcGOw;

		private float[] uIeLPvaOtikrhYebGzxpUwrhZxM;

		private bool[] zElBwVHlFlQflDLbnanFoabPSSqv;

		private HardwareJoystickMap_InputManager QKBgAKpFvffffqJCzlcbbQpNNbB;

		private opovrWrkmvbvBEFbrSmBIkHOqTyF YGGjLKypaSeERTNhbFsXMrGazwQ;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

		private bool rtLkWzYCOebfPzMzGZJpRqWoEhH;

		private bool UoPBhPBqUjBCLUUTzRsIuKGshLSj;

		private bool euujVPFzGztViWDbYvUutBvFQFP;

		[CompilerGenerated]
		private Controller.Extension LHjuazWdubNjkdFzCeAqFeYCztR;

		public bool hasDriver
		{
			get
			{
				if (IAYCyCCfxLADdcDSjhLuqwShOQyR == null)
				{
					return false;
				}
				return IAYCyCCfxLADdcDSjhLuqwShOQyR.Driver != null;
			}
		}

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
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return LHjuazWdubNjkdFzCeAqFeYCztR;
			}
			[CompilerGenerated]
			set
			{
				LHjuazWdubNjkdFzCeAqFeYCztR = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => zAgUTYpwnGscdFlNDxXqCoyIrDh;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		public bool IsValid
		{
			get
			{
				if (!euujVPFzGztViWDbYvUutBvFQFP && IAYCyCCfxLADdcDSjhLuqwShOQyR != null)
				{
					return IAYCyCCfxLADdcDSjhLuqwShOQyR.IsValid;
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

		public bPLgxNnBUaabocrbwwumoDYtmwe(XISatJdVArtMUkOXRoGcIhpgBatq joystick, DeviceType riDeviceType, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			IAYCyCCfxLADdcDSjhLuqwShOQyR = joystick;
			QKVxwHSyOwwVXVXAWMMCGgYRAFv = riDeviceType;
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			VbfjQpAQVkwFagQXhUQnioLEhvsN = -1;
			CeIdVJsUwjdwsuPBCtZxfxIInIm = -1;
		}

		public void vKgBIMftcSDdNIHlYFBnbgIECncp()
		{
			if (!IsValid)
			{
				return;
			}
			XMpQMgBqYwmfmmIEFnscpkEovPA = MiscTools.CreateGuidHashSHA1(((!string.IsNullOrEmpty(QqssUOlwiVEPRaCsLVgJqEHvHwg)) ? QqssUOlwiVEPRaCsLVgJqEHvHwg : RoslMAzcuMRQRlOImiNlFrTtTTTb) + ryufZshRWEThUUWWibRppcJadxfg);
			dQifsxjMWJbLcEtOzEAXaRvCMoW = cOVEXSAIuvbznALDYKQQXTxspUvG;
			qItqYPQVfmselpOVATDJcXAPBWB = xOcVIiUgaPmbRhbRYiQWvhIsYap + CyeGyzgLsveraNekyMxxiXDhXGK * 8;
			YOJqghcNXYHtfCjcMsnGHhFpgHI();
			QmLKgYYPeYYRxIivEciniTYoXdO = QKBgAKpFvffffqJCzlcbbQpNNbB.hardwareMapIdentifier.guid;
			YGVWsQIdEPlUdLcmFGBdDRxwphL = QKBgAKpFvffffqJCzlcbbQpNNbB.controllerName;
			rtLkWzYCOebfPzMzGZJpRqWoEhH = ((QmLKgYYPeYYRxIivEciniTYoXdO == Guid.Empty) ? true : false);
			MyEdCYiRJtoncZaamVaftBLHcGOw = new float[dQifsxjMWJbLcEtOzEAXaRvCMoW];
			uIeLPvaOtikrhYebGzxpUwrhZxM = new float[qItqYPQVfmselpOVATDJcXAPBWB];
			zElBwVHlFlQflDLbnanFoabPSSqv = new bool[qItqYPQVfmselpOVATDJcXAPBWB];
			if (QKBgAKpFvffffqJCzlcbbQpNNbB != null && qItqYPQVfmselpOVATDJcXAPBWB > 0)
			{
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
							zElBwVHlFlQflDLbnanFoabPSSqv[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
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
							zElBwVHlFlQflDLbnanFoabPSSqv[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			YGGjLKypaSeERTNhbFsXMrGazwQ = IAYCyCCfxLADdcDSjhLuqwShOQyR.AxesState;
			Update();
		}

		public void jGCYCANCzJiiLhbbuKOMrbCwWVt(bPLgxNnBUaabocrbwwumoDYtmwe P_0)
		{
			if (IsValid && P_0 != null)
			{
				VbfjQpAQVkwFagQXhUQnioLEhvsN = P_0.VbfjQpAQVkwFagQXhUQnioLEhvsN;
				CeIdVJsUwjdwsuPBCtZxfxIInIm = P_0.CeIdVJsUwjdwsuPBCtZxfxIInIm;
				for (int i = 0; i < MathTools.Min(uIeLPvaOtikrhYebGzxpUwrhZxM.Length, P_0.uIeLPvaOtikrhYebGzxpUwrhZxM.Length); i++)
				{
					uIeLPvaOtikrhYebGzxpUwrhZxM[i] = P_0.uIeLPvaOtikrhYebGzxpUwrhZxM[i];
				}
				for (int j = 0; j < MathTools.Min(zElBwVHlFlQflDLbnanFoabPSSqv.Length, P_0.zElBwVHlFlQflDLbnanFoabPSSqv.Length); j++)
				{
					zElBwVHlFlQflDLbnanFoabPSSqv[j] = P_0.zElBwVHlFlQflDLbnanFoabPSSqv[j];
				}
				for (int k = 0; k < MathTools.Min(MyEdCYiRJtoncZaamVaftBLHcGOw.Length, P_0.MyEdCYiRJtoncZaamVaftBLHcGOw.Length); k++)
				{
					MyEdCYiRJtoncZaamVaftBLHcGOw[k] = P_0.MyEdCYiRJtoncZaamVaftBLHcGOw[k];
				}
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = P_0.UoPBhPBqUjBCLUUTzRsIuKGshLSj;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (IsValid)
			{
				bool[] buttons = IAYCyCCfxLADdcDSjhLuqwShOQyR.Buttons;
				int[] hatValues = IAYCyCCfxLADdcDSjhLuqwShOQyR.HatValues;
				VVKAQHjDQMZyRjqEMoRgsckjyIh(buttons, hatValues);
				yMmEMHIqZYcuTkSikVFFrOfyKDc(buttons, hatValues);
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!IsValid)
			{
				return;
			}
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
				if (zElBwVHlFlQflDLbnanFoabPSSqv[j])
				{
					dataUpdater.buttonPressureValues[j] = uIeLPvaOtikrhYebGzxpUwrhZxM[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = ((uIeLPvaOtikrhYebGzxpUwrhZxM[j] > 0f) ? true : false);
				}
			}
			if (UoPBhPBqUjBCLUUTzRsIuKGshLSj && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int NitiHALsfYhXyGTeMMaYoAUmOkLM(bPLgxNnBUaabocrbwwumoDYtmwe P_0)
		{
			if (!IsValid)
			{
				return 0;
			}
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
			if (hasDriver != P_0.hasDriver)
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
			if (!IsValid)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			znmRFnJWmRHaLzxNQMvWhUZoLvz(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(CeIdVJsUwjdwsuPBCtZxfxIInIm);
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
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = platform_RawInput_Base.Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						KlIHHfGqKlFDXrNwExsqJzZttMs(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.LVWvrxQsAqeVkjNRwnuKIXNmUpb:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = platform_DirectInput_Base.Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						KlIHHfGqKlFDXrNwExsqJzZttMs(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.ztGaXYrZUAGOJsEfXRsYwkwVeDN:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = platform_InternalDriver_Base.Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						KxxPUAdgsQhNxKloCaJYCehgGMkQ(axes_orig[i], i, P_0, P_1);
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
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = platform_RawInput_Base.Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						WIJBTCIRRSBeeGMYbnDWPXMEQDGe(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.LVWvrxQsAqeVkjNRwnuKIXNmUpb:
			{
				HardwareJoystickMap.Platform_DirectInput_Base platform_DirectInput_Base = (HardwareJoystickMap.Platform_DirectInput_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = platform_DirectInput_Base.Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						WIJBTCIRRSBeeGMYbnDWPXMEQDGe(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.ztGaXYrZUAGOJsEfXRsYwkwVeDN:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base platform_InternalDriver_Base = (HardwareJoystickMap.Platform_InternalDriver_Base)QKBgAKpFvffffqJCzlcbbQpNNbB.map;
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = platform_InternalDriver_Base.Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						pALGUazkyKKOPkROfrPDtZzntBY(buttons_orig[i], i, P_0, P_1);
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
			if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && uIeLPvaOtikrhYebGzxpUwrhZxM[P_1] != 0f)
			{
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
			}
		}

		private float TgLPLRPKTlXSaoodLpemjkZzehs(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
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
				return TgLPLRPKTlXSaoodLpemjkZzehs((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 256)
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
				int num2 = P_2[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = oAZCxiOkVATasFWaPhbZTIAzioS(num2, AxisDirection.Horizontal);
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
					num3 = oAZCxiOkVATasFWaPhbZTIAzioS(num2, AxisDirection.Vertical);
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

		private float TgLPLRPKTlXSaoodLpemjkZzehs(RawInputAxis P_0, int P_1)
		{
			return gGNoAhCUXzgDbDcskWksokriYti((YGGjLKypaSeERTNhbFsXMrGazwQ as zzueNJUhUtGPFEHSXaerdfBbDbiW).TgLPLRPKTlXSaoodLpemjkZzehs(P_0, P_1));
		}

		private float hCGghiHxSAcLADozffLtfQoDJspU(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 256)
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
				float num2 = TgLPLRPKTlXSaoodLpemjkZzehs((RawInputAxis)sourceAxis, num);
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
				if (sourceHat < 0 || sourceHat >= CyeGyzgLsveraNekyMxxiXDhXGK || sourceHat >= 4)
				{
					return 0f;
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
						if (geXMBlrHCRaLQBfmbQSGEzdcCwE(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (TWAwKiKApdUVUdHASbIDeYHuwhj(customCalculationSourceData[k], out var num4))
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

		private float gGNoAhCUXzgDbDcskWksokriYti(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float fmPFHgbpHOqutCcgElSaAMDgVgs(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (QKBgAKpFvffffqJCzlcbbQpNNbB.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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
			if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 256)
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
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = TgLPLRPKTlXSaoodLpemjkZzehs((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
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

		private ControlDeviceType vtahlQcbXPKbIzgALwxYizLGcHrD(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.RCedHXktmDuEaJMNAKkvapTxIktB, 
				DeviceType.Joystick => ControlDeviceType.SRzHntXksMAdDsrLdjhLausTYzs, 
				DeviceType.Gamepad => ControlDeviceType.FkuTeNINGnHkhHTSsaBIaLcmEbXx, 
				DeviceType.Mouse => ControlDeviceType.oNtyvjTqZbBsgFbifrnlIOieMqj, 
				DeviceType.MultiAxisController => ControlDeviceType.SRzHntXksMAdDsrLdjhLausTYzs, 
				_ => ControlDeviceType.CxIBFsnaOMTSettXyfvwFIXcUdA, 
			};
		}

		private void KxxPUAdgsQhNxKloCaJYCehgGMkQ(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= dQifsxjMWJbLcEtOzEAXaRvCMoW)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			MyEdCYiRJtoncZaamVaftBLHcGOw[P_1] = pchWCDySjidBVgfJGLDKfkipZBLa(P_0, P_2, P_3);
			if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && MyEdCYiRJtoncZaamVaftBLHcGOw[P_1] != 0f)
			{
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
			}
		}

		private void pALGUazkyKKOPkROfrPDtZzntBY(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= qItqYPQVfmselpOVATDJcXAPBWB)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			uIeLPvaOtikrhYebGzxpUwrhZxM[P_1] = RZKfXrfuFodtHuweCFyBhNkFFTVY(P_0, P_2, P_3);
			if (!UoPBhPBqUjBCLUUTzRsIuKGshLSj && uIeLPvaOtikrhYebGzxpUwrhZxM[P_1] != 0f)
			{
				UoPBhPBqUjBCLUUTzRsIuKGshLSj = true;
			}
		}

		private float pchWCDySjidBVgfJGLDKfkipZBLa(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= cOVEXSAIuvbznALDYKQQXTxspUvG || sourceAxis >= 56)
				{
					return 0f;
				}
				return pchWCDySjidBVgfJGLDKfkipZBLa(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 256)
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
			return 0f;
		}

		private float pchWCDySjidBVgfJGLDKfkipZBLa(int P_0)
		{
			return (YGGjLKypaSeERTNhbFsXMrGazwQ as vqgaTeSNhmAyVtJlBJtiEGOLEPoO).TgLPLRPKTlXSaoodLpemjkZzehs(P_0);
		}

		private float RZKfXrfuFodtHuweCFyBhNkFFTVY(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= xOcVIiUgaPmbRhbRYiQWvhIsYap || sourceButton >= 256)
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
				if (sourceAxis < 0 || sourceAxis >= cOVEXSAIuvbznALDYKQQXTxspUvG || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = pchWCDySjidBVgfJGLDKfkipZBLa(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= CyeGyzgLsveraNekyMxxiXDhXGK || sourceHat >= 4)
				{
					return 0f;
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
			return 0f;
		}

		private bool BJAgFVGiKYbcBJkvEwrBwTMzEFf(int P_0, int P_1, HatType P_2)
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

		private float GTymylPgrdCXsfCdGlFMKcjbnHf(int P_0, AxisDirection P_1)
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

		private string AbSdQehDUFLFwmADWQZyBfSeEcFK()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.RawInput}{((KcCwYwApJNGgFSVHZTdItDIiFcvD && !string.IsNullOrEmpty(QqssUOlwiVEPRaCsLVgJqEHvHwg)) ? QqssUOlwiVEPRaCsLVgJqEHvHwg : RoslMAzcuMRQRlOImiNlFrTtTTTb)}{alBpuJrvfbBbJganskpQSPVakoV}{ryufZshRWEThUUWWibRppcJadxfg}");
		}

		private void znmRFnJWmRHaLzxNQMvWhUZoLvz(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = IAYCyCCfxLADdcDSjhLuqwShOQyR.InputSource;
			P_0.deviceType = vtahlQcbXPKbIzgALwxYizLGcHrD(QKVxwHSyOwwVXVXAWMMCGgYRAFv);
			P_0.hardwareIdentifier = AbSdQehDUFLFwmADWQZyBfSeEcFK();
			P_0.hardwareAxisCount = cOVEXSAIuvbznALDYKQQXTxspUvG;
			P_0.hardwareButtonCount = xOcVIiUgaPmbRhbRYiQWvhIsYap;
			P_0.hardwareHatCount = CyeGyzgLsveraNekyMxxiXDhXGK;
			P_0.hw_productName = RoslMAzcuMRQRlOImiNlFrTtTTTb;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_vendorId = IqbmTkZzBzpzKtwCqxczmcnUnOd;
			P_0.hw_productId = alBpuJrvfbBbJganskpQSPVakoV;
			P_0.hw_pidVid = new PidVid(ryufZshRWEThUUWWibRppcJadxfg);
			P_0.hw_isBluetoothDevice = KcCwYwApJNGgFSVHZTdItDIiFcvD;
			P_0.hw_bluetoothDeviceName = QqssUOlwiVEPRaCsLVgJqEHvHwg;
			P_0.hw_supportsVibration = rPgbDjuxkQCjUxKyoCDTJEWtoRC;
			P_0.hw_localVibrationMotorCount = sDsTvNDeoHDFRZJJKqHNfQsWBFne;
			P_0.definitionMatchTag = IAYCyCCfxLADdcDSjhLuqwShOQyR.HWDefinitionMatchTag;
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
			P_0.isButtonPressureSensitive = new bool[qItqYPQVfmselpOVATDJcXAPBWB];
			Array.Copy(zElBwVHlFlQflDLbnanFoabPSSqv, P_0.isButtonPressureSensitive, qItqYPQVfmselpOVATDJcXAPBWB);
			P_0.unknownControllerHats = QVSUQWvsrNVKIAHrZHGppYveKLH();
			P_0.controllerTypeGuid = QmLKgYYPeYYRxIivEciniTYoXdO;
			P_0.controllerExtension = extension;
		}

		private void NNmAqEjiDMumRkoBcOeJDkEGqAaA()
		{
			for (int i = 0; i < qItqYPQVfmselpOVATDJcXAPBWB; i++)
			{
				uIeLPvaOtikrhYebGzxpUwrhZxM[i] = 0f;
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

		~bPLgxNnBUaabocrbwwumoDYtmwe()
		{
			KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
		}

		protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
		{
			if (!euujVPFzGztViWDbYvUutBvFQFP)
			{
				euujVPFzGztViWDbYvUutBvFQFP = true;
			}
		}

		public static int TjItvQkFROykFtOBuAzvTuqsppr(bPLgxNnBUaabocrbwwumoDYtmwe P_0, bPLgxNnBUaabocrbwwumoDYtmwe P_1)
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

		public static int BcwPByNZiiMpvqcCvnENzrAzjrE(bPLgxNnBUaabocrbwwumoDYtmwe P_0, bPLgxNnBUaabocrbwwumoDYtmwe P_1)
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

	private class sIdPWULimrJXWRHJkdrjvTNjUas
	{
		public enum lLEyrNmXVkUxAoRySKCIpIqGYoM
		{
			ilLbvccjJelxRWfbtcIBpILmuaf = 0,
			CmVFEXBFtubByhJDbjNXIMOscxd = 1
		}

		public class UfZoglaPnwrigQZSKGbLrJaNIzi
		{
			public int DnWOcqJTVBlYFHDWvysyPeNuQSq;

			public Guid JXoxeGNALkcNmYISRYNWKuuNuTE;

			public Guid XMpQMgBqYwmfmmIEFnscpkEovPA;

			public int TZaGiTqKIftsljYrtCTLiMFBVZE;

			public int cOVEXSAIuvbznALDYKQQXTxspUvG;

			public int xOcVIiUgaPmbRhbRYiQWvhIsYap;

			public int CyeGyzgLsveraNekyMxxiXDhXGK;

			public int qItqYPQVfmselpOVATDJcXAPBWB;

			public int dQifsxjMWJbLcEtOzEAXaRvCMoW;

			public bool FqRgIwLMgElLVUMEwKCKRaeVQSB;

			public bool NitiHALsfYhXyGTeMMaYoAUmOkLM(bPLgxNnBUaabocrbwwumoDYtmwe P_0, lLEyrNmXVkUxAoRySKCIpIqGYoM P_1)
			{
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
				if (qItqYPQVfmselpOVATDJcXAPBWB != P_0.qItqYPQVfmselpOVATDJcXAPBWB)
				{
					return false;
				}
				if (dQifsxjMWJbLcEtOzEAXaRvCMoW != P_0.dQifsxjMWJbLcEtOzEAXaRvCMoW)
				{
					return false;
				}
				if (FqRgIwLMgElLVUMEwKCKRaeVQSB != P_0.hasDriver)
				{
					return false;
				}
				if (P_0.rewiredId == DnWOcqJTVBlYFHDWvysyPeNuQSq)
				{
					return true;
				}
				return P_1 switch
				{
					lLEyrNmXVkUxAoRySKCIpIqGYoM.ilLbvccjJelxRWfbtcIBpILmuaf => JXoxeGNALkcNmYISRYNWKuuNuTE == P_0.instanceGuid, 
					lLEyrNmXVkUxAoRySKCIpIqGYoM.CmVFEXBFtubByhJDbjNXIMOscxd => XMpQMgBqYwmfmmIEFnscpkEovPA == P_0.XMpQMgBqYwmfmmIEFnscpkEovPA, 
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
				text = string.Concat(obj7, "hardwareHatCount = ", CyeGyzgLsveraNekyMxxiXDhXGK, "\n");
				object obj8 = text;
				text = string.Concat(obj8, "gameButtonCount = ", qItqYPQVfmselpOVATDJcXAPBWB, "\n");
				object obj9 = text;
				text = string.Concat(obj9, "gameAxisCount = ", dQifsxjMWJbLcEtOzEAXaRvCMoW, "\n");
				object obj10 = text;
				return string.Concat(obj10, "hasDriver = ", FqRgIwLMgElLVUMEwKCKRaeVQSB, "\n");
			}
		}

		private sealed class XYvEAAdGpradzFfOiGmUljeCbDqv : IEnumerable<UfZoglaPnwrigQZSKGbLrJaNIzi>, IEnumerator<UfZoglaPnwrigQZSKGbLrJaNIzi>, IDisposable, IEnumerable, IEnumerator
		{
			private UfZoglaPnwrigQZSKGbLrJaNIzi dTaSsHpnJJEVtDGLgOHQGZyYVIXQ;

			private int nvkdBavXrtgJBGDZFCTvwXCruwCj;

			private int OGvIvwIPzTVfaOeGoCjUFfAJsqp;

			public sIdPWULimrJXWRHJkdrjvTNjUas jCCESxhkXKXRASiiyhhDQRyWTmj;

			public bPLgxNnBUaabocrbwwumoDYtmwe PPWOKytbcnkKaUCfKMHWwNXGgOa;

			public bPLgxNnBUaabocrbwwumoDYtmwe xKEfMxZmpqYVlMUlbsSseuDUpyd;

			public lLEyrNmXVkUxAoRySKCIpIqGYoM wjXCljJmUfGrplhoWeMtAGArnCgj;

			public lLEyrNmXVkUxAoRySKCIpIqGYoM QFGEAMdzmCAJVfrIOYQypKEJWxUF;

			public int kSdrIvzRVbIXKkyYsulhHHkedozb;

			public int hLgUCSWxQkGcEGwKIgTXxurHFrM;

			UfZoglaPnwrigQZSKGbLrJaNIzi IEnumerator<UfZoglaPnwrigQZSKGbLrJaNIzi>.Current
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
			IEnumerator<UfZoglaPnwrigQZSKGbLrJaNIzi> IEnumerable<UfZoglaPnwrigQZSKGbLrJaNIzi>.GetEnumerator()
			{
				XYvEAAdGpradzFfOiGmUljeCbDqv xYvEAAdGpradzFfOiGmUljeCbDqv;
				if (Thread.CurrentThread.ManagedThreadId == OGvIvwIPzTVfaOeGoCjUFfAJsqp && nvkdBavXrtgJBGDZFCTvwXCruwCj == -2)
				{
					nvkdBavXrtgJBGDZFCTvwXCruwCj = 0;
					xYvEAAdGpradzFfOiGmUljeCbDqv = this;
				}
				else
				{
					xYvEAAdGpradzFfOiGmUljeCbDqv = new XYvEAAdGpradzFfOiGmUljeCbDqv(0);
					xYvEAAdGpradzFfOiGmUljeCbDqv.jCCESxhkXKXRASiiyhhDQRyWTmj = jCCESxhkXKXRASiiyhhDQRyWTmj;
				}
				xYvEAAdGpradzFfOiGmUljeCbDqv.PPWOKytbcnkKaUCfKMHWwNXGgOa = xKEfMxZmpqYVlMUlbsSseuDUpyd;
				xYvEAAdGpradzFfOiGmUljeCbDqv.wjXCljJmUfGrplhoWeMtAGArnCgj = QFGEAMdzmCAJVfrIOYQypKEJWxUF;
				return xYvEAAdGpradzFfOiGmUljeCbDqv;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<UfZoglaPnwrigQZSKGbLrJaNIzi>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (nvkdBavXrtgJBGDZFCTvwXCruwCj)
				{
				case 0:
					nvkdBavXrtgJBGDZFCTvwXCruwCj = -1;
					kSdrIvzRVbIXKkyYsulhHHkedozb = jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT.Count;
					hLgUCSWxQkGcEGwKIgTXxurHFrM = 0;
					goto IL_00a3;
				case 1:
					{
						nvkdBavXrtgJBGDZFCTvwXCruwCj = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (hLgUCSWxQkGcEGwKIgTXxurHFrM >= kSdrIvzRVbIXKkyYsulhHHkedozb)
					{
						break;
					}
					if (jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT[hLgUCSWxQkGcEGwKIgTXxurHFrM].NitiHALsfYhXyGTeMMaYoAUmOkLM(PPWOKytbcnkKaUCfKMHWwNXGgOa, wjXCljJmUfGrplhoWeMtAGArnCgj))
					{
						dTaSsHpnJJEVtDGLgOHQGZyYVIXQ = jCCESxhkXKXRASiiyhhDQRyWTmj.cRyaCDjwErkISWbxXDsigITBKjqT[hLgUCSWxQkGcEGwKIgTXxurHFrM];
						nvkdBavXrtgJBGDZFCTvwXCruwCj = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					hLgUCSWxQkGcEGwKIgTXxurHFrM++;
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
			public XYvEAAdGpradzFfOiGmUljeCbDqv(int _003C_003E1__state)
			{
				nvkdBavXrtgJBGDZFCTvwXCruwCj = _003C_003E1__state;
				OGvIvwIPzTVfaOeGoCjUFfAJsqp = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<UfZoglaPnwrigQZSKGbLrJaNIzi> cRyaCDjwErkISWbxXDsigITBKjqT;

		public sIdPWULimrJXWRHJkdrjvTNjUas()
		{
			cRyaCDjwErkISWbxXDsigITBKjqT = new List<UfZoglaPnwrigQZSKGbLrJaNIzi>();
		}

		public void oOaPrTHEWDBSgKiiowMCWfzaAKNC(bPLgxNnBUaabocrbwwumoDYtmwe P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = cRyaCDjwErkISWbxXDsigITBKjqT.Count;
			for (int i = 0; i < count; i++)
			{
				if (cRyaCDjwErkISWbxXDsigITBKjqT[i].NitiHALsfYhXyGTeMMaYoAUmOkLM(P_0, lLEyrNmXVkUxAoRySKCIpIqGYoM.ilLbvccjJelxRWfbtcIBpILmuaf))
				{
					cRyaCDjwErkISWbxXDsigITBKjqT[i].DnWOcqJTVBlYFHDWvysyPeNuQSq = P_0.rewiredId;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].JXoxeGNALkcNmYISRYNWKuuNuTE = P_0.instanceGuid;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].XMpQMgBqYwmfmmIEFnscpkEovPA = P_0.XMpQMgBqYwmfmmIEFnscpkEovPA;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].TZaGiTqKIftsljYrtCTLiMFBVZE = P_0.inputManagerId;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].cOVEXSAIuvbznALDYKQQXTxspUvG = P_0.cOVEXSAIuvbznALDYKQQXTxspUvG;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].xOcVIiUgaPmbRhbRYiQWvhIsYap = P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].CyeGyzgLsveraNekyMxxiXDhXGK = P_0.CyeGyzgLsveraNekyMxxiXDhXGK;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].qItqYPQVfmselpOVATDJcXAPBWB = P_0.qItqYPQVfmselpOVATDJcXAPBWB;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].dQifsxjMWJbLcEtOzEAXaRvCMoW = P_0.dQifsxjMWJbLcEtOzEAXaRvCMoW;
					cRyaCDjwErkISWbxXDsigITBKjqT[i].FqRgIwLMgElLVUMEwKCKRaeVQSB = P_0.hasDriver;
					CQoIzinEDcHJhCkDtGfbEenGggv(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			cRyaCDjwErkISWbxXDsigITBKjqT.Add(new UfZoglaPnwrigQZSKGbLrJaNIzi
			{
				DnWOcqJTVBlYFHDWvysyPeNuQSq = P_0.rewiredId,
				JXoxeGNALkcNmYISRYNWKuuNuTE = P_0.instanceGuid,
				XMpQMgBqYwmfmmIEFnscpkEovPA = P_0.XMpQMgBqYwmfmmIEFnscpkEovPA,
				TZaGiTqKIftsljYrtCTLiMFBVZE = P_0.inputManagerId,
				cOVEXSAIuvbznALDYKQQXTxspUvG = P_0.cOVEXSAIuvbznALDYKQQXTxspUvG,
				xOcVIiUgaPmbRhbRYiQWvhIsYap = P_0.xOcVIiUgaPmbRhbRYiQWvhIsYap,
				CyeGyzgLsveraNekyMxxiXDhXGK = P_0.CyeGyzgLsveraNekyMxxiXDhXGK,
				qItqYPQVfmselpOVATDJcXAPBWB = P_0.qItqYPQVfmselpOVATDJcXAPBWB,
				dQifsxjMWJbLcEtOzEAXaRvCMoW = P_0.dQifsxjMWJbLcEtOzEAXaRvCMoW,
				FqRgIwLMgElLVUMEwKCKRaeVQSB = P_0.hasDriver
			});
			CQoIzinEDcHJhCkDtGfbEenGggv(P_0.rewiredId, P_0.instanceGuid, cRyaCDjwErkISWbxXDsigITBKjqT.Count - 1);
		}

		public bool TsxbHEcmQPhQPOBcEjqTjgYzUQM(bPLgxNnBUaabocrbwwumoDYtmwe P_0, lLEyrNmXVkUxAoRySKCIpIqGYoM P_1)
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

		public IEnumerable<UfZoglaPnwrigQZSKGbLrJaNIzi> xGaEkUmWuamNBtSslvPYrVXhEeN(bPLgxNnBUaabocrbwwumoDYtmwe P_0, lLEyrNmXVkUxAoRySKCIpIqGYoM P_1)
		{
			XYvEAAdGpradzFfOiGmUljeCbDqv xYvEAAdGpradzFfOiGmUljeCbDqv = new XYvEAAdGpradzFfOiGmUljeCbDqv(-2);
			xYvEAAdGpradzFfOiGmUljeCbDqv.jCCESxhkXKXRASiiyhhDQRyWTmj = this;
			xYvEAAdGpradzFfOiGmUljeCbDqv.xKEfMxZmpqYVlMUlbsSseuDUpyd = P_0;
			xYvEAAdGpradzFfOiGmUljeCbDqv.QFGEAMdzmCAJVfrIOYQypKEJWxUF = P_1;
			return xYvEAAdGpradzFfOiGmUljeCbDqv;
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

	private CDUDUtloSCOYNTanpthEeshuCdC pnktKZzYVXGXdrcxDcbedpHLExC;

	private List<bPLgxNnBUaabocrbwwumoDYtmwe> BNRwQaHYudxtMzjvBeOOjyanYNh;

	private int wzGTkrXSHKqeaqvfxQCkjnIiqSc;

	private sIdPWULimrJXWRHJkdrjvTNjUas QLIrcBWnyhRCmcLMZBdCkDmlOPy;

	private bool hASHRrcGESJaZEVHJPxExCYIrUlg;

	private TimerRealTime IsLEnDVVrbdFbqVEnPhvPRYEfVA;

	private global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool> EIBumFyJQxRierGmhosrZtMvhiJ;

	private global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool> xnhEOafvVmqEfCZFepVuWHXDLfDy;

	private int wuFEdIHgMlXbBETfUUNMDxxKNky;

	private int DJUcNdRINfCvlEzvzPtKlOrrgQuk;

	private ConfigVars VsMgYcimWEGlycMVKSeLPFvWQnhv;

	private bool hskpsPnisvnzcwCOJgZlUKENLCt;

	private Action<int, ControllerDataUpdater> JcoiPGandIoCihCSGbQPMEFfAvAL;

	private PlatformInputManager LMMdhtGnZeQEOByzBHUxskBnUeW;

	private readonly SItXuYbYOTfkYGCaLEfPjCCHCOnG NQBAbfboRnwQXwqVOSdDAazOhsYe;

	private readonly semsxMCoWgefAkNrSJJwPcOjkQI CVystqBEptblBrorrNVEeMercSP;

	private readonly bool wjKcjakyNggjYkTtNALWrDlwLpFA;

	private readonly bool MHOguSHKDpCslowFrgeilBKioqQB;

	private readonly bool nDrVOOXzsMdXepMzAAVSLdpYhnhj;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> muwCboYBpXBddhISLPoaIQYyEVOW;

	private readonly Func<int> ngZnFDsAelLLgZWmCeeSqxddlic;

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
	public override IInputSource inputSource => pnktKZzYVXGXdrcxDcbedpHLExC;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.RawInput;

	public CKORtxtALbxyeRsqoWjMACyCwcV(ConfigVars configVars, bool useXInput, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard, bool useCustomDrivers)
	{
		try
		{
			VsMgYcimWEGlycMVKSeLPFvWQnhv = configVars;
			hskpsPnisvnzcwCOJgZlUKENLCt = useXInput;
			muwCboYBpXBddhISLPoaIQYyEVOW = getHardwareJoystickMap_InputManager;
			ngZnFDsAelLLgZWmCeeSqxddlic = getNewJoystickId;
			wjKcjakyNggjYkTtNALWrDlwLpFA = handleJoysticks;
			MHOguSHKDpCslowFrgeilBKioqQB = handleUnifiedMouse;
			nDrVOOXzsMdXepMzAAVSLdpYhnhj = handleUnifiedKeyboard;
			LMMdhtGnZeQEOByzBHUxskBnUeW = this;
			UpdateLoopSetting updateLoop = configVars.updateLoop;
			if (handleUnifiedKeyboard)
			{
				CVystqBEptblBrorrNVEeMercSP = new semsxMCoWgefAkNrSJJwPcOjkQI(updateLoop);
			}
			if (handleUnifiedMouse)
			{
				NQBAbfboRnwQXwqVOSdDAazOhsYe = new SItXuYbYOTfkYGCaLEfPjCCHCOnG(updateLoop);
			}
			pnktKZzYVXGXdrcxDcbedpHLExC = new CDUDUtloSCOYNTanpthEeshuCdC(configVars, handleJoysticks, useCustomDrivers, NQBAbfboRnwQXwqVOSdDAazOhsYe, CVystqBEptblBrorrNVEeMercSP);
			JcoiPGandIoCihCSGbQPMEFfAvAL = UpdateControllerData;
			EIBumFyJQxRierGmhosrZtMvhiJ = new global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool>(useSharedThread: true, OJxCoLfeZjFQhrFCuSHuDWMBtMYV);
			xnhEOafvVmqEfCZFepVuWHXDLfDy = new global::SmnfRaZRTCRKUNzdKVQSwqJahva<bool>(useSharedThread: true, pnktKZzYVXGXdrcxDcbedpHLExC.XotdmMEHyLPNWVKWMuMTGEMJsNsB);
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
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			QLIrcBWnyhRCmcLMZBdCkDmlOPy = new sIdPWULimrJXWRHJkdrjvTNjUas();
			IsLEnDVVrbdFbqVEnPhvPRYEfVA = new TimerRealTime(1.0);
			IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
			BYWMQZgjPylFwgUNlcHNORtjaRm();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			XpvVWrsANNMckCqRQMluZpRCvUK();
		}
		if (pnktKZzYVXGXdrcxDcbedpHLExC != null)
		{
			pnktKZzYVXGXdrcxDcbedpHLExC.Update();
		}
		gACCeyKxSeslmhXJfHSNBRMUBlU();
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			if (pnktKZzYVXGXdrcxDcbedpHLExC != null)
			{
				pnktKZzYVXGXdrcxDcbedpHLExC.UpdateDevices(updateLoop);
			}
			kXnUTEtOoFIbAgXxuDGNUaTXqAh();
			if (pnktKZzYVXGXdrcxDcbedpHLExC != null)
			{
				pnktKZzYVXGXdrcxDcbedpHLExC.UpdateFinished();
			}
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			NQBAbfboRnwQXwqVOSdDAazOhsYe.RMEkOMsGFSFWbHqrAFftMTIKNIHO(updateLoop);
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			CVystqBEptblBrorrNVEeMercSP.RMEkOMsGFSFWbHqrAFftMTIKNIHO(updateLoop);
		}
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
		if (BNRwQaHYudxtMzjvBeOOjyanYNh != null)
		{
			int count = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
			for (int i = 0; i < count; i++)
			{
				if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null)
				{
					BNRwQaHYudxtMzjvBeOOjyanYNh[i].KRgasgBmyLeCeDGJhNGqwMeOqCwJ();
				}
			}
		}
		if (CVystqBEptblBrorrNVEeMercSP != null)
		{
			CVystqBEptblBrorrNVEeMercSP.Dispose();
		}
		if (NQBAbfboRnwQXwqVOSdDAazOhsYe != null)
		{
			NQBAbfboRnwQXwqVOSdDAazOhsYe.Dispose();
		}
		if (pnktKZzYVXGXdrcxDcbedpHLExC != null)
		{
			pnktKZzYVXGXdrcxDcbedpHLExC.Dispose();
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
		if (!wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			return;
		}
		for (int i = 0; i < wzGTkrXSHKqeaqvfxQCkjnIiqSc; i++)
		{
			if (BNRwQaHYudxtMzjvBeOOjyanYNh[i].inputManagerId == inputManagerId)
			{
				BNRwQaHYudxtMzjvBeOOjyanYNh[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		pnktKZzYVXGXdrcxDcbedpHLExC.SystemDeviceConnected();
		hASHRrcGESJaZEVHJPxExCYIrUlg = true;
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			CVystqBEptblBrorrNVEeMercSP.BaKUrWtSdbbeIHinStpYOpNkyeF(true);
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			NQBAbfboRnwQXwqVOSdDAazOhsYe.BaKUrWtSdbbeIHinStpYOpNkyeF(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		pnktKZzYVXGXdrcxDcbedpHLExC.SystemDeviceDisconnected();
		hASHRrcGESJaZEVHJPxExCYIrUlg = true;
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			IsLEnDVVrbdFbqVEnPhvPRYEfVA.Start();
		}
		if (nDrVOOXzsMdXepMzAAVSLdpYhnhj)
		{
			CVystqBEptblBrorrNVEeMercSP.BaKUrWtSdbbeIHinStpYOpNkyeF(false);
		}
		if (MHOguSHKDpCslowFrgeilBKioqQB)
		{
			NQBAbfboRnwQXwqVOSdDAazOhsYe.BaKUrWtSdbbeIHinStpYOpNkyeF(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = wjKcjakyNggjYkTtNALWrDlwLpFA;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return NQBAbfboRnwQXwqVOSdDAazOhsYe;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return CVystqBEptblBrorrNVEeMercSP;
	}

	public void ExrHJJtpfvNVWwqCndSnwcdPMan(TSrfFdAmQuDNBoHUlddNXTpuyKU P_0, QMQeCqPHCzDkbwgNXAhQBqgQGsWB P_1)
	{
	}

	private void XpvVWrsANNMckCqRQMluZpRCvUK()
	{
		if (EIBumFyJQxRierGmhosrZtMvhiJ.isRunning)
		{
			if (EIBumFyJQxRierGmhosrZtMvhiJ.wcZXiwBuSxlGFrbXURQEZElVWiH() && !IsLEnDVVrbdFbqVEnPhvPRYEfVA.running && !xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning)
			{
				if (EIBumFyJQxRierGmhosrZtMvhiJ.result)
				{
					hASHRrcGESJaZEVHJPxExCYIrUlg = true;
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

	private void BYWMQZgjPylFwgUNlcHNORtjaRm()
	{
		BYWMQZgjPylFwgUNlcHNORtjaRm(UVYFSCdlkFKubIqrpaIAFEFyibG());
	}

	private void BYWMQZgjPylFwgUNlcHNORtjaRm(IList<XISatJdVArtMUkOXRoGcIhpgBatq> P_0)
	{
		int num = 0;
		List<bPLgxNnBUaabocrbwwumoDYtmwe> bNRwQaHYudxtMzjvBeOOjyanYNh = BNRwQaHYudxtMzjvBeOOjyanYNh;
		int num2 = wzGTkrXSHKqeaqvfxQCkjnIiqSc;
		BNRwQaHYudxtMzjvBeOOjyanYNh = new List<bPLgxNnBUaabocrbwwumoDYtmwe>();
		wuFEdIHgMlXbBETfUUNMDxxKNky = 0;
		List<bPLgxNnBUaabocrbwwumoDYtmwe> list = new List<bPLgxNnBUaabocrbwwumoDYtmwe>();
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (bNRwQaHYudxtMzjvBeOOjyanYNh[num3] != null && !bNRwQaHYudxtMzjvBeOOjyanYNh[num3].IsValid)
			{
				list.Add(bNRwQaHYudxtMzjvBeOOjyanYNh[num3]);
				bNRwQaHYudxtMzjvBeOOjyanYNh.RemoveAt(num3);
			}
		}
		num2 = bNRwQaHYudxtMzjvBeOOjyanYNh?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			XISatJdVArtMUkOXRoGcIhpgBatq xISatJdVArtMUkOXRoGcIhpgBatq = P_0[i];
			if (xISatJdVArtMUkOXRoGcIhpgBatq != null)
			{
				bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = new bPLgxNnBUaabocrbwwumoDYtmwe(xISatJdVArtMUkOXRoGcIhpgBatq, xISatJdVArtMUkOXRoGcIhpgBatq.DeviceType, muwCboYBpXBddhISLPoaIQYyEVOW);
				bPLgxNnBUaabocrbwwumoDYtmwe2.zAgUTYpwnGscdFlNDxXqCoyIrDh = xISatJdVArtMUkOXRoGcIhpgBatq.InstanceGuid;
				bPLgxNnBUaabocrbwwumoDYtmwe2.xAjwjehTWQJNfiRQZtsPAVhpGDq = xISatJdVArtMUkOXRoGcIhpgBatq.ProductName;
				bPLgxNnBUaabocrbwwumoDYtmwe2.RoslMAzcuMRQRlOImiNlFrTtTTTb = xISatJdVArtMUkOXRoGcIhpgBatq.ProductName;
				bPLgxNnBUaabocrbwwumoDYtmwe2.ryufZshRWEThUUWWibRppcJadxfg = xISatJdVArtMUkOXRoGcIhpgBatq.ProductGuid;
				bPLgxNnBUaabocrbwwumoDYtmwe2.alBpuJrvfbBbJganskpQSPVakoV = xISatJdVArtMUkOXRoGcIhpgBatq.ProductId;
				bPLgxNnBUaabocrbwwumoDYtmwe2.IqbmTkZzBzpzKtwCqxczmcnUnOd = xISatJdVArtMUkOXRoGcIhpgBatq.VendorId;
				bPLgxNnBUaabocrbwwumoDYtmwe2.nQnRhDVRHBdclEftFaviShDQJSn = xISatJdVArtMUkOXRoGcIhpgBatq.JoystickId;
				bPLgxNnBUaabocrbwwumoDYtmwe2.cOVEXSAIuvbznALDYKQQXTxspUvG = xISatJdVArtMUkOXRoGcIhpgBatq.AxisCount;
				bPLgxNnBUaabocrbwwumoDYtmwe2.xOcVIiUgaPmbRhbRYiQWvhIsYap = xISatJdVArtMUkOXRoGcIhpgBatq.ButtonCount;
				bPLgxNnBUaabocrbwwumoDYtmwe2.CyeGyzgLsveraNekyMxxiXDhXGK = xISatJdVArtMUkOXRoGcIhpgBatq.HatCount;
				bPLgxNnBUaabocrbwwumoDYtmwe2.BqXBiRECKKlUBedponJUgsIHutKP = false;
				bPLgxNnBUaabocrbwwumoDYtmwe2.KcCwYwApJNGgFSVHZTdItDIiFcvD = xISatJdVArtMUkOXRoGcIhpgBatq.IsBluetoothDevice;
				bPLgxNnBUaabocrbwwumoDYtmwe2.QqssUOlwiVEPRaCsLVgJqEHvHwg = xISatJdVArtMUkOXRoGcIhpgBatq.BluetoothDeviceName;
				bPLgxNnBUaabocrbwwumoDYtmwe2.rPgbDjuxkQCjUxKyoCDTJEWtoRC = xISatJdVArtMUkOXRoGcIhpgBatq.SupportsVibration;
				bPLgxNnBUaabocrbwwumoDYtmwe2.sDsTvNDeoHDFRZJJKqHNfQsWBFne = xISatJdVArtMUkOXRoGcIhpgBatq.VibrationMotorCount;
				bPLgxNnBUaabocrbwwumoDYtmwe2.extension = xISatJdVArtMUkOXRoGcIhpgBatq.ControllerExtension;
				xISatJdVArtMUkOXRoGcIhpgBatq.DfoHKTaxZzJSYcaLwTWUBUINGoo();
				bPLgxNnBUaabocrbwwumoDYtmwe2.vKgBIMftcSDdNIHlYFBnbgIECncp();
				BNRwQaHYudxtMzjvBeOOjyanYNh.Add(bPLgxNnBUaabocrbwwumoDYtmwe2);
				num++;
				if (bPLgxNnBUaabocrbwwumoDYtmwe2.KcCwYwApJNGgFSVHZTdItDIiFcvD)
				{
					wuFEdIHgMlXbBETfUUNMDxxKNky++;
				}
			}
		}
		wzGTkrXSHKqeaqvfxQCkjnIiqSc = num;
		RpJREBaKEEUqrCItLUjNcKalNhO(num2, num, bNRwQaHYudxtMzjvBeOOjyanYNh, BNRwQaHYudxtMzjvBeOOjyanYNh);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(BNRwQaHYudxtMzjvBeOOjyanYNh[j]));
			}
		}
		list.ForEach(delegate(bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe3)
		{
			ybsGugBBooRgYsLwSUUgUZpACxl(bPLgxNnBUaabocrbwwumoDYtmwe3, false);
		});
		MUAlBSDbWugPHscLdGflzkxxmAr(bNRwQaHYudxtMzjvBeOOjyanYNh, BNRwQaHYudxtMzjvBeOOjyanYNh, false);
		MUAlBSDbWugPHscLdGflzkxxmAr(BNRwQaHYudxtMzjvBeOOjyanYNh, bNRwQaHYudxtMzjvBeOOjyanYNh, true);
	}

	private void kXnUTEtOoFIbAgXxuDGNUaTXqAh()
	{
		for (int i = 0; i < wzGTkrXSHKqeaqvfxQCkjnIiqSc; i++)
		{
			bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = BNRwQaHYudxtMzjvBeOOjyanYNh[i];
			if (bPLgxNnBUaabocrbwwumoDYtmwe2 != null && (!hskpsPnisvnzcwCOJgZlUKENLCt || !bPLgxNnBUaabocrbwwumoDYtmwe2.BqXBiRECKKlUBedponJUgsIHutKP))
			{
				bPLgxNnBUaabocrbwwumoDYtmwe2.Update();
			}
		}
	}

	private bool DHmcXFAgLYfMVKfsvVmyMSVwNMPb(dHehSZErNPSnylbgSIAEHzyqWNwJ P_0)
	{
		try
		{
			return P_0.ezYQOBjVNKObFDufNqksjDEFGPV();
		}
		catch
		{
			return false;
		}
	}

	private IList<XISatJdVArtMUkOXRoGcIhpgBatq> UVYFSCdlkFKubIqrpaIAFEFyibG()
	{
		return pnktKZzYVXGXdrcxDcbedpHLExC.GetJoysticks<XISatJdVArtMUkOXRoGcIhpgBatq>();
	}

	private void RpJREBaKEEUqrCItLUjNcKalNhO(int P_0, int P_1, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_2, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(bPLgxNnBUaabocrbwwumoDYtmwe.BcwPByNZiiMpvqcCvnENzrAzjrE);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			DBTDfQTzxMkYHtAeEeZhgFTticed(P_1, P_3, P_0, P_2, sIdPWULimrJXWRHJkdrjvTNjUas.lLEyrNmXVkUxAoRySKCIpIqGYoM.ilLbvccjJelxRWfbtcIBpILmuaf);
		}
		XJHgXlxPExiOYhHWnfYtJbLohhlX(P_1, P_3, sIdPWULimrJXWRHJkdrjvTNjUas.lLEyrNmXVkUxAoRySKCIpIqGYoM.ilLbvccjJelxRWfbtcIBpILmuaf);
		for (int i = 0; i < P_1; i++)
		{
			bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = P_3[i];
			if (bPLgxNnBUaabocrbwwumoDYtmwe2 != null && bPLgxNnBUaabocrbwwumoDYtmwe2.inputManagerId < 0)
			{
				bPLgxNnBUaabocrbwwumoDYtmwe2.inputManagerId = mEtKtHeMEfFpKIBRPfsUzIoWAkW(P_3);
				bPLgxNnBUaabocrbwwumoDYtmwe2.rewiredId = ngZnFDsAelLLgZWmCeeSqxddlic();
				QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(bPLgxNnBUaabocrbwwumoDYtmwe2);
			}
		}
		P_3.Sort(bPLgxNnBUaabocrbwwumoDYtmwe.TjItvQkFROykFtOBuAzvTuqsppr);
	}

	private void uPilyqFCmZcpxiagfHMxBZTCAMID(List<bPLgxNnBUaabocrbwwumoDYtmwe> P_0, int P_1, int P_2)
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

	private bool uDuHIdzqXFVTRKaQtgEBWDVXSAc(List<bPLgxNnBUaabocrbwwumoDYtmwe> P_0, int P_1)
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

	private int mEtKtHeMEfFpKIBRPfsUzIoWAkW(List<bPLgxNnBUaabocrbwwumoDYtmwe> P_0)
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

	private bool wKWHaqaZomwvSwqVVGwMUDIDYZx(List<bPLgxNnBUaabocrbwwumoDYtmwe> P_0, int P_1)
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

	private void DBTDfQTzxMkYHtAeEeZhgFTticed(int P_0, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_1, int P_2, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_3, sIdPWULimrJXWRHJkdrjvTNjUas.lLEyrNmXVkUxAoRySKCIpIqGYoM P_4)
	{
		int num = ((P_4 != sIdPWULimrJXWRHJkdrjvTNjUas.lLEyrNmXVkUxAoRySKCIpIqGYoM.ilLbvccjJelxRWfbtcIBpILmuaf) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = P_1[i];
			if (bPLgxNnBUaabocrbwwumoDYtmwe2 == null || bPLgxNnBUaabocrbwwumoDYtmwe2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe3 = P_3[j];
				if (bPLgxNnBUaabocrbwwumoDYtmwe3 != null && !wKWHaqaZomwvSwqVVGwMUDIDYZx(P_1, bPLgxNnBUaabocrbwwumoDYtmwe3.rewiredId) && bPLgxNnBUaabocrbwwumoDYtmwe2.NitiHALsfYhXyGTeMMaYoAUmOkLM(bPLgxNnBUaabocrbwwumoDYtmwe3) >= num)
				{
					bPLgxNnBUaabocrbwwumoDYtmwe2.jGCYCANCzJiiLhbbuKOMrbCwWVt(bPLgxNnBUaabocrbwwumoDYtmwe3);
					QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(bPLgxNnBUaabocrbwwumoDYtmwe2);
				}
			}
		}
	}

	private void XJHgXlxPExiOYhHWnfYtJbLohhlX(int P_0, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_1, sIdPWULimrJXWRHJkdrjvTNjUas.lLEyrNmXVkUxAoRySKCIpIqGYoM P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = P_1[i];
			if (bPLgxNnBUaabocrbwwumoDYtmwe2 == null || bPLgxNnBUaabocrbwwumoDYtmwe2.inputManagerId >= 0)
			{
				continue;
			}
			sIdPWULimrJXWRHJkdrjvTNjUas.UfZoglaPnwrigQZSKGbLrJaNIzi ufZoglaPnwrigQZSKGbLrJaNIzi = null;
			foreach (sIdPWULimrJXWRHJkdrjvTNjUas.UfZoglaPnwrigQZSKGbLrJaNIzi item in QLIrcBWnyhRCmcLMZBdCkDmlOPy.xGaEkUmWuamNBtSslvPYrVXhEeN(bPLgxNnBUaabocrbwwumoDYtmwe2, P_2))
			{
				if (!wKWHaqaZomwvSwqVVGwMUDIDYZx(P_1, item.DnWOcqJTVBlYFHDWvysyPeNuQSq) && item.TZaGiTqKIftsljYrtCTLiMFBVZE >= 0)
				{
					ufZoglaPnwrigQZSKGbLrJaNIzi = item;
					break;
				}
			}
			if (ufZoglaPnwrigQZSKGbLrJaNIzi != null)
			{
				int num = ufZoglaPnwrigQZSKGbLrJaNIzi.TZaGiTqKIftsljYrtCTLiMFBVZE;
				if (!uDuHIdzqXFVTRKaQtgEBWDVXSAc(P_1, num))
				{
					num = (ufZoglaPnwrigQZSKGbLrJaNIzi.TZaGiTqKIftsljYrtCTLiMFBVZE = mEtKtHeMEfFpKIBRPfsUzIoWAkW(P_1));
				}
				bPLgxNnBUaabocrbwwumoDYtmwe2.inputManagerId = num;
				bPLgxNnBUaabocrbwwumoDYtmwe2.rewiredId = ufZoglaPnwrigQZSKGbLrJaNIzi.DnWOcqJTVBlYFHDWvysyPeNuQSq;
				QLIrcBWnyhRCmcLMZBdCkDmlOPy.oOaPrTHEWDBSgKiiowMCWfzaAKNC(bPLgxNnBUaabocrbwwumoDYtmwe2);
			}
		}
	}

	private void gACCeyKxSeslmhXJfHSNBRMUBlU()
	{
		if (pnktKZzYVXGXdrcxDcbedpHLExC.JxwgIWemLgZLViQDegvbxYgcrKE(true))
		{
			hASHRrcGESJaZEVHJPxExCYIrUlg = true;
		}
		if (hASHRrcGESJaZEVHJPxExCYIrUlg)
		{
			eeNYQJpqlDYrdweDiwgOSctGfbHc();
		}
		if (wjKcjakyNggjYkTtNALWrDlwLpFA && xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning && xnhEOafvVmqEfCZFepVuWHXDLfDy.wcZXiwBuSxlGFrbXURQEZElVWiH())
		{
			PTWORQqgBdUCodONUbJlUWFGkKU();
		}
	}

	private void eeNYQJpqlDYrdweDiwgOSctGfbHc()
	{
		hASHRrcGESJaZEVHJPxExCYIrUlg = false;
		if (!xnhEOafvVmqEfCZFepVuWHXDLfDy.isRunning)
		{
			pnktKZzYVXGXdrcxDcbedpHLExC.MGgSpbKODMUDxdrrqofKFoVwyxn();
			xnhEOafvVmqEfCZFepVuWHXDLfDy.HnocEhRkacOxHhLLsmQmCGWhJlU();
		}
	}

	private void PTWORQqgBdUCodONUbJlUWFGkKU()
	{
		pnktKZzYVXGXdrcxDcbedpHLExC.bBgkhnueVbhjKRKwscthvcoztta();
		if (wjKcjakyNggjYkTtNALWrDlwLpFA)
		{
			IList<XISatJdVArtMUkOXRoGcIhpgBatq> list = UVYFSCdlkFKubIqrpaIAFEFyibG();
			if (ibDYRtIWfbPqvRKtYpccgjnNpPp(list))
			{
				BYWMQZgjPylFwgUNlcHNORtjaRm(list);
			}
		}
	}

	private bool ibDYRtIWfbPqvRKtYpccgjnNpPp(IList<XISatJdVArtMUkOXRoGcIhpgBatq> P_0)
	{
		for (int i = 0; i < BNRwQaHYudxtMzjvBeOOjyanYNh.Count; i++)
		{
			if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null && !BNRwQaHYudxtMzjvBeOOjyanYNh[i].IsValid)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !fviCveaaVVLiPSTBJMVwqiqgKjGf(P_0[j].InstanceGuid))
			{
				return true;
			}
		}
		int count2 = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
		for (int k = 0; k < count2; k++)
		{
			if (BNRwQaHYudxtMzjvBeOOjyanYNh[k] != null && !OCeKMHwBjvtydhmVyhVOyGNGvgf(P_0, BNRwQaHYudxtMzjvBeOOjyanYNh[k].instanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	private bool fviCveaaVVLiPSTBJMVwqiqgKjGf(Guid P_0)
	{
		int count = BNRwQaHYudxtMzjvBeOOjyanYNh.Count;
		for (int i = 0; i < count; i++)
		{
			if (BNRwQaHYudxtMzjvBeOOjyanYNh[i] != null && BNRwQaHYudxtMzjvBeOOjyanYNh[i].instanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool OCeKMHwBjvtydhmVyhVOyGNGvgf(IList<XISatJdVArtMUkOXRoGcIhpgBatq> P_0, Guid P_1)
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

	private void MUAlBSDbWugPHscLdGflzkxxmAr(List<bPLgxNnBUaabocrbwwumoDYtmwe> P_0, List<bPLgxNnBUaabocrbwwumoDYtmwe> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe2 = P_0[i];
			if (bPLgxNnBUaabocrbwwumoDYtmwe2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					bPLgxNnBUaabocrbwwumoDYtmwe bPLgxNnBUaabocrbwwumoDYtmwe3 = P_1[j];
					if (bPLgxNnBUaabocrbwwumoDYtmwe3 != null && bPLgxNnBUaabocrbwwumoDYtmwe2.instanceGuid == bPLgxNnBUaabocrbwwumoDYtmwe3.instanceGuid)
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

	private void ybsGugBBooRgYsLwSUUgUZpACxl(bPLgxNnBUaabocrbwwumoDYtmwe P_0, bool P_1)
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
		try
		{
			int num = 0;
			pKZMnjMMImQdiKyeumoKPkbgwQI.WPimmLUNirHddOMGogIEehnEPAPc(null, ref num, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<AZmbvcVIunYbHEntMIOGHkdhIws>());
			if (DJUcNdRINfCvlEzvzPtKlOrrgQuk != num)
			{
				DJUcNdRINfCvlEzvzPtKlOrrgQuk = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (wuFEdIHgMlXbBETfUUNMDxxKNky > 0 && pnktKZzYVXGXdrcxDcbedpHLExC.bmNDFsCrIgtruDdZyobLpGWnBEYL())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void SUbkefTLxKciKbHRLcRxUFTEtXM(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void rTxjIxsFSjTNQHgJBEqxfvcypQW(bPLgxNnBUaabocrbwwumoDYtmwe P_0)
	{
		ybsGugBBooRgYsLwSUUgUZpACxl(P_0, false);
	}
}
