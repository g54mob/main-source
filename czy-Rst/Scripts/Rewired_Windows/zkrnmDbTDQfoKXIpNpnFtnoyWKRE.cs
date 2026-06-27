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

internal class zkrnmDbTDQfoKXIpNpnFtnoyWKRE : PlatformInputManager, AOnTCMyhWiFBDPnpOkhOOLpWAYMC
{
	private class jeVhmjjeVKqMykpAYwlbuYKFcBZI : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int mtsxDquxnhjiTPOqNwkOBQzZkgst;

		private int JDwlFVUNlXjtQCVAhDVSBkIdxPRd;

		public Guid tVynEUOTwmHeaPVteBAkOOXEgcUH;

		public string QBVNjMsDEvcvNYeFKSEvKDFsxbWw;

		public readonly TpQKeSuTJVwsGafeKVECzGzgftvp GXuNWUYCzKFxRsBeKXwezaGESNBD;

		public RCbrBLDngHgaSCZnWWTNJSaCQXlM HCCJQefcSZZlFgBsCXvbytYDfOMk;

		public EFfdpmrEFpCiZgNjMHoExeNrkBgbb LlaPBWBeBvHXfApubEqrJSQIlPZDb;

		public string GnAqclayIcfZhVjKoAxXhldFNqmy;

		public string rLQNOveJWLjLEwqpLbuPFtgarwVMA;

		public int McWEAOKnCllDRdqTCDTMqVbnZgiCb;

		public Guid ahmCgmGaZyJQLhxTMBXLRGnLmattA;

		public Guid AZRFIDJSVSoIDaPHSODkqaSusjbh;

		public Guid ePRUxDMNyiMTwUPuGAuEHagZYnTL;

		public int IUKCECULrWNrucKVEkOBwYbYaYge;

		public bool jmRHHuPTRPjBwLMzuxnzDYVkGwJM;

		public string CkJQNRDhDAIoOKtgaHxkkQsWdHbP;

		public string OgwXAwobpzAIatBwTWaXapiQgMhq;

		public int WIwWrDqzWYvBkDlqsmiZAncRMiki;

		public int hzxWJWFVsvAcfGGxhbUcJWBMxdEf;

		public int sRqdccCqHIdlZZxjlMJpGGALMTXu;

		public int cYKFgMwUErcyAyvJljXcHZiszjtdA;

		public int lDpdRWDWZUtgDsssjLjkHetIIjZsB;

		public bool EYNcBmsHOWCHAuCnOnodeQelcjRQ;

		public Controller.Extension konmlsWVMmJQikKjfoFfwZmRhdQI;

		private float[] DMhfJHnfHXSVjPYsKbJloznhmtxF;

		private bool[] wFEbHDBVrElruJiCcRIFFjmOZePl;

		private HardwareJoystickMap_InputManager GtQWNeyxaBrSkwClegODAeEwZRvjA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZPzEzGJvJblnDIpMZRgzUkqHvOkQ;

		private bool rnXrFnVMoGEZZzawYsXhZzbDWlft;

		private bool HYPcIeKjhPsDUExRJcJRskWQfJAjb;

		private bool BNvEGwCaGXaIKCXPSzriXqNqukDo;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return mtsxDquxnhjiTPOqNwkOBQzZkgst;
			}
			set
			{
				mtsxDquxnhjiTPOqNwkOBQzZkgst = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return JDwlFVUNlXjtQCVAhDVSBkIdxPRd;
			}
			set
			{
				JDwlFVUNlXjtQCVAhDVSBkIdxPRd = value;
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name
		{
			get
			{
				if (QBVNjMsDEvcvNYeFKSEvKDFsxbWw != "Unknown Controller")
				{
					return QBVNjMsDEvcvNYeFKSEvKDFsxbWw;
				}
				if (jmRHHuPTRPjBwLMzuxnzDYVkGwJM && !string.IsNullOrEmpty(CkJQNRDhDAIoOKtgaHxkkQsWdHbP))
				{
					return CkJQNRDhDAIoOKtgaHxkkQsWdHbP;
				}
				return rLQNOveJWLjLEwqpLbuPFtgarwVMA;
			}
		}

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId
		{
			get
			{
				if (JDwlFVUNlXjtQCVAhDVSBkIdxPRd < 0)
				{
					return null;
				}
				return JDwlFVUNlXjtQCVAhDVSBkIdxPRd;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension => konmlsWVMmJQikKjfoFfwZmRhdQI;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => ahmCgmGaZyJQLhxTMBXLRGnLmattA;

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

		public jeVhmjjeVKqMykpAYwlbuYKFcBZI(TpQKeSuTJVwsGafeKVECzGzgftvp P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			GXuNWUYCzKFxRsBeKXwezaGESNBD = P_0;
			ZPzEzGJvJblnDIpMZRgzUkqHvOkQ = P_1;
			JDwlFVUNlXjtQCVAhDVSBkIdxPRd = -1;
			mtsxDquxnhjiTPOqNwkOBQzZkgst = -1;
		}

		public void ItUoqNaTqtLPNiuLiGxJwSKIgCqV()
		{
			string text = rLQNOveJWLjLEwqpLbuPFtgarwVMA;
			Guid aZRFIDJSVSoIDaPHSODkqaSusjbh = AZRFIDJSVSoIDaPHSODkqaSusjbh;
			ePRUxDMNyiMTwUPuGAuEHagZYnTL = MiscTools.CreateGuidHashSHA1(text + aZRFIDJSVSoIDaPHSODkqaSusjbh.ToString());
			WIwWrDqzWYvBkDlqsmiZAncRMiki = sRqdccCqHIdlZZxjlMJpGGALMTXu;
			hzxWJWFVsvAcfGGxhbUcJWBMxdEf = cYKFgMwUErcyAyvJljXcHZiszjtdA + lDpdRWDWZUtgDsssjLjkHetIIjZsB * 8;
			zAZSKtwHFSCccvcMgAhHCRgIexpx();
			tVynEUOTwmHeaPVteBAkOOXEgcUH = GtQWNeyxaBrSkwClegODAeEwZRvjA.hardwareMapIdentifier.guid;
			QBVNjMsDEvcvNYeFKSEvKDFsxbWw = GtQWNeyxaBrSkwClegODAeEwZRvjA.controllerName;
			rnXrFnVMoGEZZzawYsXhZzbDWlft = ((tVynEUOTwmHeaPVteBAkOOXEgcUH == Guid.Empty) ? true : false);
			DMhfJHnfHXSVjPYsKbJloznhmtxF = new float[WIwWrDqzWYvBkDlqsmiZAncRMiki];
			wFEbHDBVrElruJiCcRIFFjmOZePl = new bool[hzxWJWFVsvAcfGGxhbUcJWBMxdEf];
			GXuNWUYCzKFxRsBeKXwezaGESNBD.lLNFsGexIsPsOdHgJKzoiHAFbXDuA();
			Update();
		}

		public void bSpWYVvVAqldnaNYHbHouoiMBajIA(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0)
		{
			if (P_0 != null)
			{
				JDwlFVUNlXjtQCVAhDVSBkIdxPRd = P_0.JDwlFVUNlXjtQCVAhDVSBkIdxPRd;
				mtsxDquxnhjiTPOqNwkOBQzZkgst = P_0.mtsxDquxnhjiTPOqNwkOBQzZkgst;
				for (int i = 0; i < MathTools.Min(wFEbHDBVrElruJiCcRIFFjmOZePl.Length, P_0.wFEbHDBVrElruJiCcRIFFjmOZePl.Length); i++)
				{
					wFEbHDBVrElruJiCcRIFFjmOZePl[i] = P_0.wFEbHDBVrElruJiCcRIFFjmOZePl[i];
				}
				for (int j = 0; j < MathTools.Min(DMhfJHnfHXSVjPYsKbJloznhmtxF.Length, P_0.DMhfJHnfHXSVjPYsKbJloznhmtxF.Length); j++)
				{
					DMhfJHnfHXSVjPYsKbJloznhmtxF[j] = P_0.DMhfJHnfHXSVjPYsKbJloznhmtxF[j];
				}
				HYPcIeKjhPsDUExRJcJRskWQfJAjb = P_0.HYPcIeKjhPsDUExRJcJRskWQfJAjb;
				GXuNWUYCzKFxRsBeKXwezaGESNBD.fbPVWbcvmwoknfPFjpetczcUwFcK(P_0.GXuNWUYCzKFxRsBeKXwezaGESNBD);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			GXuNWUYCzKFxRsBeKXwezaGESNBD.IgAeFpzYJAGsgbNdHmwTiWlBaQOn();
			bool[] array = GXuNWUYCzKFxRsBeKXwezaGESNBD.oYAeSAlXSztMwKoVnXvOZKtWTNbp;
			int[] fhOdxYmTSclyisqmTmxfBIMHESds = GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.fhOdxYmTSclyisqmTmxfBIMHESds;
			uRGhDdVNqfsVJEyOifshnuYEhuKe(array, fhOdxYmTSclyisqmTmxfBIMHESds);
			dzDVHbwLOsxTghRYLcybrPBISSWr(array, fhOdxYmTSclyisqmTmxfBIMHESds);
			GXuNWUYCzKFxRsBeKXwezaGESNBD.yuyKtAgTgBmzWCiHNdJJyesEqCoI();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (WIwWrDqzWYvBkDlqsmiZAncRMiki != dataUpdater.axisCount || hzxWJWFVsvAcfGGxhbUcJWBMxdEf != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < WIwWrDqzWYvBkDlqsmiZAncRMiki; i++)
			{
				dataUpdater.axisValues[i] = DMhfJHnfHXSVjPYsKbJloznhmtxF[i];
			}
			for (int j = 0; j < hzxWJWFVsvAcfGGxhbUcJWBMxdEf; j++)
			{
				dataUpdater.buttonValues[j] = wFEbHDBVrElruJiCcRIFFjmOZePl[j];
			}
			if (HYPcIeKjhPsDUExRJcJRskWQfJAjb && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int PwQgNNeFrnYIyLxDMglyqlwBJLHX(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0)
		{
			if (P_0.mtsxDquxnhjiTPOqNwkOBQzZkgst == mtsxDquxnhjiTPOqNwkOBQzZkgst)
			{
				return 2;
			}
			if (sRqdccCqHIdlZZxjlMJpGGALMTXu != P_0.sRqdccCqHIdlZZxjlMJpGGALMTXu)
			{
				return 0;
			}
			if (cYKFgMwUErcyAyvJljXcHZiszjtdA != P_0.cYKFgMwUErcyAyvJljXcHZiszjtdA)
			{
				return 0;
			}
			if (lDpdRWDWZUtgDsssjLjkHetIIjZsB != P_0.lDpdRWDWZUtgDsssjLjkHetIIjZsB)
			{
				return 0;
			}
			if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
			{
				return 2;
			}
			if (P_0.ePRUxDMNyiMTwUPuGAuEHagZYnTL == ePRUxDMNyiMTwUPuGAuEHagZYnTL)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo kUjRlRJClCRSdawfiKkfZolLuUvW()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			tAZdUJsmADRkpXNlcOxuMvsdoPbv(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			gtCWIvVDTQUuNCBCmLtvrNzQCrYE(bridgedController);
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
			return new ControllerDisconnectedEventArgs(mtsxDquxnhjiTPOqNwkOBQzZkgst);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		public bool QPsubDWsRfmCGZivbuRCMAOpBFAw()
		{
			try
			{
				GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA.YhdWAIWnuDXMzUgZsPGpfqSsbsmL();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void txkCiWRwGexiXBNNilMOuLVYtDVN()
		{
			try
			{
				if (GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA != null)
				{
					GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA.oBlOMMyTLkQVgySBVdHMQILwEDKk();
				}
			}
			catch
			{
			}
		}

		public void GsyJCpdzAfoNjqoIfSkzwJTqBsbp()
		{
			try
			{
				if (GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA != null)
				{
					GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA.ZiYbrvzqaSrBafdyVkpZBZMJaFMU();
				}
			}
			catch
			{
			}
		}

		private void uRGhDdVNqfsVJEyOifshnuYEhuKe(bool[] P_0, int[] P_1)
		{
			if (WIwWrDqzWYvBkDlqsmiZAncRMiki <= 0)
			{
				return;
			}
			switch (GtQWNeyxaBrSkwClegODAeEwZRvjA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)GtQWNeyxaBrSkwClegODAeEwZRvjA.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						MLsgjhbBYhHuMfkDyFYtbAdcBnlkc(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)GtQWNeyxaBrSkwClegODAeEwZRvjA.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						MLsgjhbBYhHuMfkDyFYtbAdcBnlkc(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void dzDVHbwLOsxTghRYLcybrPBISSWr(bool[] P_0, int[] P_1)
		{
			if (hzxWJWFVsvAcfGGxhbUcJWBMxdEf <= 0)
			{
				return;
			}
			switch (GtQWNeyxaBrSkwClegODAeEwZRvjA.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)GtQWNeyxaBrSkwClegODAeEwZRvjA.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						ploFlvjKZwSdKUGQntxCAvPNhVAiA(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)GtQWNeyxaBrSkwClegODAeEwZRvjA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						ploFlvjKZwSdKUGQntxCAvPNhVAiA(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void MLsgjhbBYhHuMfkDyFYtbAdcBnlkc(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= WIwWrDqzWYvBkDlqsmiZAncRMiki)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			DMhfJHnfHXSVjPYsKbJloznhmtxF[P_1] = fpAmuNgmfoGudrRijqkkCvRkwYoO(P_0, P_2, P_3);
			if (!HYPcIeKjhPsDUExRJcJRskWQfJAjb && DMhfJHnfHXSVjPYsKbJloznhmtxF[P_1] != 0f)
			{
				HYPcIeKjhPsDUExRJcJRskWQfJAjb = true;
			}
		}

		private void ploFlvjKZwSdKUGQntxCAvPNhVAiA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= hzxWJWFVsvAcfGGxhbUcJWBMxdEf)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			wFEbHDBVrElruJiCcRIFFjmOZePl[P_1] = goPcsLNriSsVmVToTszhZSUhOXnI(P_0, P_2, P_3);
			if (!HYPcIeKjhPsDUExRJcJRskWQfJAjb && wFEbHDBVrElruJiCcRIFFjmOZePl[P_1])
			{
				HYPcIeKjhPsDUExRJcJRskWQfJAjb = true;
			}
		}

		private float fpAmuNgmfoGudrRijqkkCvRkwYoO(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return PHPiPKBoXIoDwqWsdaKcTTUptSle((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= cYKFgMwUErcyAyvJljXcHZiszjtdA || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= lDpdRWDWZUtgDsssjLjkHetIIjZsB || sourceHat >= 4)
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
					num2 = mwynLciKsrwOFEwipdagIGdTkxYD(num, AxisDirection.Horizontal);
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
					num2 = mwynLciKsrwOFEwipdagIGdTkxYD(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && pPKTAUedkJorttsxkwpXcDrtbmSU(customCalculationSourceData[i], out var item))
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

		private float PHPiPKBoXIoDwqWsdaKcTTUptSle(DirectInputAxis P_0)
		{
			return P_0 switch
			{
				DirectInputAxis.X => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.JFWxFsSQYIfudphtlMkXtJXIXerv, 
				DirectInputAxis.Y => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.idAMOKPYYbaCEXLvThvGzibgLYAp, 
				DirectInputAxis.Z => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.hyVekcpfOzrmLiPrHbxZuuugEaky, 
				DirectInputAxis.RotationX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.BzCUyomfGnqMcFdKiEMWgsbTKnEeA, 
				DirectInputAxis.RotationY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.kNHtMIwXdiuaCzFgZXxTgmKslVKF, 
				DirectInputAxis.RotationZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.BQLCZdcRzFnpCKDFwgYpLueIPAvA, 
				DirectInputAxis.Slider0 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.moZYzdXeEjRMBPEcvielAsvXDiRZA[0], 
				DirectInputAxis.Slider1 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.moZYzdXeEjRMBPEcvielAsvXDiRZA[1], 
				DirectInputAxis.VelocityX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.iowcoypDXYCsSURbYcditjdueZO, 
				DirectInputAxis.VelocityY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.JzCcHpiPsnqdYoGPWHZtIxxCkHlJA, 
				DirectInputAxis.VelocityZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.JgCbioGAdFogivEdANEHfqZGLcgSc, 
				DirectInputAxis.AngularVelocityX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.dDdWSSFQdGOIjPiitsfZSQWLGnTj, 
				DirectInputAxis.AngularVelocityY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.DBrChuWvYdeqaofUkqeXCBbXvtqg, 
				DirectInputAxis.AngularVelocityZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.wxsDktEyvloJMWIhjLwuKEhWlPhfb, 
				DirectInputAxis.VelocitySlider0 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.hNOHOMoSvqeawwbWuTiOhbQajSVc[0], 
				DirectInputAxis.VelocitySlider1 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.hNOHOMoSvqeawwbWuTiOhbQajSVc[1], 
				DirectInputAxis.AccelerationX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.WhEYJCaVEfivFgPocyEsIEaOAAqG, 
				DirectInputAxis.AccelerationY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.IBUuHEGnhUplBcalVDLzUKWOvLtq, 
				DirectInputAxis.AccelerationZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.vjectRiyUeWwrFmOhJYXbRZGaboqb, 
				DirectInputAxis.AngularAccelerationX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.ZNbuPrVaWHbZYazmARpRtXsHoJSOA, 
				DirectInputAxis.AngularAccelerationY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.hTfFCtYclGXjImMiBlkjBZgFSJoO, 
				DirectInputAxis.AngularAccelerationZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.DwdncGgRqpNMXQACqpsuThIptYVf, 
				DirectInputAxis.AccelerationSlider0 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.uMCfEQIkTCPcJeSgjxWanXmpEynLc[0], 
				DirectInputAxis.AccelerationSlider1 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.uMCfEQIkTCPcJeSgjxWanXmpEynLc[1], 
				DirectInputAxis.ForceX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.iYTpdTUdyIXFbWQUkysYhwGckGkh, 
				DirectInputAxis.ForceY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.aNapCXlnJwQSkDbVkCYaPoGrhhiaA, 
				DirectInputAxis.ForceZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.TYKgBedRlazNPWBYFnyVYGjTzxeFA, 
				DirectInputAxis.TorqueX => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.hZeDxLQNJoiLMZiZNfKlKxlsIWoB, 
				DirectInputAxis.TorqueY => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.fvfqxgWzhvJvHUJDFStlgPYrykFl, 
				DirectInputAxis.TorqueZ => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.TcsaLnEkhkxgyTpdfYixKrUztOkJ, 
				DirectInputAxis.ForceSlider0 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.AdbvKIlfwtzEZqPcBnlrwCsuqhRU[0], 
				DirectInputAxis.ForceSlider1 => GXuNWUYCzKFxRsBeKXwezaGESNBD.RAXDpBaCbIUUaBWGpJWmNkSffLDf.AdbvKIlfwtzEZqPcBnlrwCsuqhRU[1], 
				_ => 0f, 
			};
		}

		private bool goPcsLNriSsVmVToTszhZSUhOXnI(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
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
				if (sourceButton < 0 || sourceButton >= cYKFgMwUErcyAyvJljXcHZiszjtdA || sourceButton >= 128)
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
				float num = PHPiPKBoXIoDwqWsdaKcTTUptSle((DirectInputAxis)P_0.sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= lDpdRWDWZUtgDsssjLjkHetIIjZsB || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return adEGghfdpFmFvAPmdlUkaJZExEmAA(P_2[sourceHat], 7, P_0.sourceHatType);
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
						if (XLqeDbKGJVPrxcKkFUttTHyBEjYCb(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (pPKTAUedkJorttsxkwpXcDrtbmSU(customCalculationSourceData[k], out var num2))
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

		private bool adEGghfdpFmFvAPmdlUkaJZExEmAA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (GtQWNeyxaBrSkwClegODAeEwZRvjA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float mwynLciKsrwOFEwipdagIGdTkxYD(int P_0, AxisDirection P_1)
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

		private bool XLqeDbKGJVPrxcKkFUttTHyBEjYCb(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= cYKFgMwUErcyAyvJljXcHZiszjtdA || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool pPKTAUedkJorttsxkwpXcDrtbmSU(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
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
			P_1 = PHPiPKBoXIoDwqWsdaKcTTUptSle((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType WdxeKdPmWuGjiCAJUvpUHSsLbKSRA(EFfdpmrEFpCiZgNjMHoExeNrkBgbb P_0)
		{
			return P_0 switch
			{
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Keyboard => ControlDeviceType.Keyboard, 
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Joystick => ControlDeviceType.Joystick, 
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Gamepad => ControlDeviceType.Gamepad, 
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Mouse => ControlDeviceType.Mouse, 
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Flight => ControlDeviceType.Flight, 
				EFfdpmrEFpCiZgNjMHoExeNrkBgbb.Driving => ControlDeviceType.Wheel, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void zAZSKtwHFSCccvcMgAhHCRgIexpx()
		{
			GtQWNeyxaBrSkwClegODAeEwZRvjA = ZPzEzGJvJblnDIpMZRgzUkqHvOkQ(kUjRlRJClCRSdawfiKkfZolLuUvW());
			if (GtQWNeyxaBrSkwClegODAeEwZRvjA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			WIwWrDqzWYvBkDlqsmiZAncRMiki = GtQWNeyxaBrSkwClegODAeEwZRvjA.axisCount;
			hzxWJWFVsvAcfGGxhbUcJWBMxdEf = GtQWNeyxaBrSkwClegODAeEwZRvjA.buttonCount;
		}

		private void ThTwRVnKaXrKJMKkehnZPhDOddDcA()
		{
		}

		private string KHVkizUCGsWmEXuVRVeliAiyjdqF()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (jmRHHuPTRPjBwLMzuxnzDYVkGwJM && !string.IsNullOrEmpty(CkJQNRDhDAIoOKtgaHxkkQsWdHbP)) ? CkJQNRDhDAIoOKtgaHxkkQsWdHbP : rLQNOveJWLjLEwqpLbuPFtgarwVMA, McWEAOKnCllDRdqTCDTMqVbnZgiCb.ToString("X4"), new PidVid(AZRFIDJSVSoIDaPHSODkqaSusjbh).vendorId.ToString("X4")));
		}

		private void tAZdUJsmADRkpXNlcOxuMvsdoPbv(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = WdxeKdPmWuGjiCAJUvpUHSsLbKSRA(LlaPBWBeBvHXfApubEqrJSQIlPZDb);
			P_0.hardwareIdentifier = KHVkizUCGsWmEXuVRVeliAiyjdqF();
			P_0.hardwareAxisCount = sRqdccCqHIdlZZxjlMJpGGALMTXu;
			P_0.hardwareButtonCount = cYKFgMwUErcyAyvJljXcHZiszjtdA;
			P_0.hardwareHatCount = lDpdRWDWZUtgDsssjLjkHetIIjZsB;
			P_0.hw_productName = rLQNOveJWLjLEwqpLbuPFtgarwVMA;
			P_0.hw_deviceGuid = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
			P_0.hw_productId = McWEAOKnCllDRdqTCDTMqVbnZgiCb;
			P_0.hw_pidVid = new PidVid(AZRFIDJSVSoIDaPHSODkqaSusjbh);
			P_0.hw_isBluetoothDevice = jmRHHuPTRPjBwLMzuxnzDYVkGwJM;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(CkJQNRDhDAIoOKtgaHxkkQsWdHbP)) ? CkJQNRDhDAIoOKtgaHxkkQsWdHbP : string.Empty);
			P_0.definitionMatchTag = OgwXAwobpzAIatBwTWaXapiQgMhq;
		}

		private void gtCWIvVDTQUuNCBCmLtvrNzQCrYE(BridgedController P_0)
		{
			tAZdUJsmADRkpXNlcOxuMvsdoPbv(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = GtQWNeyxaBrSkwClegODAeEwZRvjA.ToGameHardwareControllerMap();
			P_0.instanceName = GnAqclayIcfZhVjKoAxXhldFNqmy;
			P_0.productName = rLQNOveJWLjLEwqpLbuPFtgarwVMA;
			P_0.isXInputDevice = EYNcBmsHOWCHAuCnOnodeQelcjRQ;
			P_0.axisCount = WIwWrDqzWYvBkDlqsmiZAncRMiki;
			P_0.buttonCount = hzxWJWFVsvAcfGGxhbUcJWBMxdEf;
			P_0.unknownControllerHats = DRYzcOnBLovbqrFlxYrPspWiENEr();
			P_0.controllerTypeGuid = tVynEUOTwmHeaPVteBAkOOXEgcUH;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		private void gnKbnWRfhegbhOkYibkeiXidlUgo()
		{
			for (int i = 0; i < hzxWJWFVsvAcfGGxhbUcJWBMxdEf; i++)
			{
				wFEbHDBVrElruJiCcRIFFjmOZePl[i] = false;
			}
			for (int j = 0; j < WIwWrDqzWYvBkDlqsmiZAncRMiki; j++)
			{
				DMhfJHnfHXSVjPYsKbJloznhmtxF[j] = 0f;
			}
		}

		private UnknownControllerHat[] DRYzcOnBLovbqrFlxYrPspWiENEr()
		{
			if (!rnXrFnVMoGEZZzawYsXhZzbDWlft)
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

		public void UELVAUfPPbBnyAVsQgKaOvthgOcF()
		{
			gjrABFWDINhhVxSSuIAiReoQvVFE(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void pfeciEVEHGfIdqHHiLQjUnfRmUDs()
		{
			try
			{
				gjrABFWDINhhVxSSuIAiReoQvVFE(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void gjrABFWDINhhVxSSuIAiReoQvVFE(bool P_0)
		{
			if (!BNvEGwCaGXaIKCXPSzriXqNqukDo)
			{
				if (P_0 && GXuNWUYCzKFxRsBeKXwezaGESNBD != null)
				{
					GXuNWUYCzKFxRsBeKXwezaGESNBD.Dispose();
				}
				BNvEGwCaGXaIKCXPSzriXqNqukDo = true;
			}
		}

		public static int QcIejBYIKziEOWLLwCOntRwhUMLW(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, jeVhmjjeVKqMykpAYwlbuYKFcBZI P_1)
		{
			if (P_0.JDwlFVUNlXjtQCVAhDVSBkIdxPRd < P_1.JDwlFVUNlXjtQCVAhDVSBkIdxPRd)
			{
				return -1;
			}
			if (P_0.JDwlFVUNlXjtQCVAhDVSBkIdxPRd > P_1.JDwlFVUNlXjtQCVAhDVSBkIdxPRd)
			{
				return 1;
			}
			return 0;
		}

		public static int JjWOMMmMaAJGZGCmgpRtFLTznopjb(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, jeVhmjjeVKqMykpAYwlbuYKFcBZI P_1)
		{
			if (P_0.IUKCECULrWNrucKVEkOBwYbYaYge < P_1.IUKCECULrWNrucKVEkOBwYbYaYge)
			{
				return -1;
			}
			if (P_0.IUKCECULrWNrucKVEkOBwYbYaYge > P_1.IUKCECULrWNrucKVEkOBwYbYaYge)
			{
				return 1;
			}
			return 0;
		}
	}

	private class TpQKeSuTJVwsGafeKVECzGzgftvp : IDisposable
	{
		public class XTMhXuicNzsiRcRWRlfmUAOEsLcQ
		{
			public float JFWxFsSQYIfudphtlMkXtJXIXerv;

			public float idAMOKPYYbaCEXLvThvGzibgLYAp;

			public float hyVekcpfOzrmLiPrHbxZuuugEaky;

			public float BzCUyomfGnqMcFdKiEMWgsbTKnEeA;

			public float kNHtMIwXdiuaCzFgZXxTgmKslVKF;

			public float BQLCZdcRzFnpCKDFwgYpLueIPAvA;

			public float[] moZYzdXeEjRMBPEcvielAsvXDiRZA;

			public readonly int[] fhOdxYmTSclyisqmTmxfBIMHESds;

			public readonly bool[] FHcdnyqZbIQYWrJqRnhXzmeswDDm;

			public float iowcoypDXYCsSURbYcditjdueZO;

			public float JzCcHpiPsnqdYoGPWHZtIxxCkHlJA;

			public float JgCbioGAdFogivEdANEHfqZGLcgSc;

			public float dDdWSSFQdGOIjPiitsfZSQWLGnTj;

			public float DBrChuWvYdeqaofUkqeXCBbXvtqg;

			public float wxsDktEyvloJMWIhjLwuKEhWlPhfb;

			public readonly float[] hNOHOMoSvqeawwbWuTiOhbQajSVc;

			public float WhEYJCaVEfivFgPocyEsIEaOAAqG;

			public float IBUuHEGnhUplBcalVDLzUKWOvLtq;

			public float vjectRiyUeWwrFmOhJYXbRZGaboqb;

			public float ZNbuPrVaWHbZYazmARpRtXsHoJSOA;

			public float hTfFCtYclGXjImMiBlkjBZgFSJoO;

			public float DwdncGgRqpNMXQACqpsuThIptYVf;

			public readonly float[] uMCfEQIkTCPcJeSgjxWanXmpEynLc;

			public float iYTpdTUdyIXFbWQUkysYhwGckGkh;

			public float aNapCXlnJwQSkDbVkCYaPoGrhhiaA;

			public float TYKgBedRlazNPWBYFnyVYGjTzxeFA;

			public float hZeDxLQNJoiLMZiZNfKlKxlsIWoB;

			public float fvfqxgWzhvJvHUJDFStlgPYrykFl;

			public float TcsaLnEkhkxgyTpdfYixKrUztOkJ;

			public readonly float[] AdbvKIlfwtzEZqPcBnlrwCsuqhRU;

			public XTMhXuicNzsiRcRWRlfmUAOEsLcQ()
			{
				moZYzdXeEjRMBPEcvielAsvXDiRZA = new float[2];
				fhOdxYmTSclyisqmTmxfBIMHESds = new int[4];
				FHcdnyqZbIQYWrJqRnhXzmeswDDm = new bool[128];
				hNOHOMoSvqeawwbWuTiOhbQajSVc = new float[2];
				uMCfEQIkTCPcJeSgjxWanXmpEynLc = new float[2];
				AdbvKIlfwtzEZqPcBnlrwCsuqhRU = new float[2];
			}

			public void BTRCDmGWXOyCKdcVoKVNAHPwaVWIA()
			{
				JFWxFsSQYIfudphtlMkXtJXIXerv = 0f;
				idAMOKPYYbaCEXLvThvGzibgLYAp = 0f;
				hyVekcpfOzrmLiPrHbxZuuugEaky = 0f;
				BzCUyomfGnqMcFdKiEMWgsbTKnEeA = 0f;
				kNHtMIwXdiuaCzFgZXxTgmKslVKF = 0f;
				BQLCZdcRzFnpCKDFwgYpLueIPAvA = 0f;
				for (int i = 0; i < moZYzdXeEjRMBPEcvielAsvXDiRZA.Length; i++)
				{
					moZYzdXeEjRMBPEcvielAsvXDiRZA[i] = 0f;
				}
				for (int j = 0; j < fhOdxYmTSclyisqmTmxfBIMHESds.Length; j++)
				{
					fhOdxYmTSclyisqmTmxfBIMHESds[j] = 0;
				}
				for (int k = 0; k < FHcdnyqZbIQYWrJqRnhXzmeswDDm.Length; k++)
				{
					FHcdnyqZbIQYWrJqRnhXzmeswDDm[k] = false;
				}
				iowcoypDXYCsSURbYcditjdueZO = 0f;
				JzCcHpiPsnqdYoGPWHZtIxxCkHlJA = 0f;
				JgCbioGAdFogivEdANEHfqZGLcgSc = 0f;
				dDdWSSFQdGOIjPiitsfZSQWLGnTj = 0f;
				DBrChuWvYdeqaofUkqeXCBbXvtqg = 0f;
				wxsDktEyvloJMWIhjLwuKEhWlPhfb = 0f;
				for (int l = 0; l < hNOHOMoSvqeawwbWuTiOhbQajSVc.Length; l++)
				{
					hNOHOMoSvqeawwbWuTiOhbQajSVc[l] = 0f;
				}
				WhEYJCaVEfivFgPocyEsIEaOAAqG = 0f;
				IBUuHEGnhUplBcalVDLzUKWOvLtq = 0f;
				vjectRiyUeWwrFmOhJYXbRZGaboqb = 0f;
				ZNbuPrVaWHbZYazmARpRtXsHoJSOA = 0f;
				hTfFCtYclGXjImMiBlkjBZgFSJoO = 0f;
				DwdncGgRqpNMXQACqpsuThIptYVf = 0f;
				for (int m = 0; m < uMCfEQIkTCPcJeSgjxWanXmpEynLc.Length; m++)
				{
					uMCfEQIkTCPcJeSgjxWanXmpEynLc[m] = 0f;
				}
				iYTpdTUdyIXFbWQUkysYhwGckGkh = 0f;
				aNapCXlnJwQSkDbVkCYaPoGrhhiaA = 0f;
				TYKgBedRlazNPWBYFnyVYGjTzxeFA = 0f;
				hZeDxLQNJoiLMZiZNfKlKxlsIWoB = 0f;
				fvfqxgWzhvJvHUJDFStlgPYrykFl = 0f;
				TcsaLnEkhkxgyTpdfYixKrUztOkJ = 0f;
				for (int n = 0; n < AdbvKIlfwtzEZqPcBnlrwCsuqhRU.Length; n++)
				{
					AdbvKIlfwtzEZqPcBnlrwCsuqhRU[n] = 0f;
				}
			}

			public void jdkInXRnlklLAoTajIlBMltqCPkcA(XTMhXuicNzsiRcRWRlfmUAOEsLcQ P_0)
			{
				JFWxFsSQYIfudphtlMkXtJXIXerv = P_0.JFWxFsSQYIfudphtlMkXtJXIXerv;
				idAMOKPYYbaCEXLvThvGzibgLYAp = P_0.idAMOKPYYbaCEXLvThvGzibgLYAp;
				hyVekcpfOzrmLiPrHbxZuuugEaky = P_0.hyVekcpfOzrmLiPrHbxZuuugEaky;
				BzCUyomfGnqMcFdKiEMWgsbTKnEeA = P_0.BzCUyomfGnqMcFdKiEMWgsbTKnEeA;
				kNHtMIwXdiuaCzFgZXxTgmKslVKF = P_0.kNHtMIwXdiuaCzFgZXxTgmKslVKF;
				BQLCZdcRzFnpCKDFwgYpLueIPAvA = P_0.BQLCZdcRzFnpCKDFwgYpLueIPAvA;
				for (int i = 0; i < moZYzdXeEjRMBPEcvielAsvXDiRZA.Length; i++)
				{
					moZYzdXeEjRMBPEcvielAsvXDiRZA[i] = P_0.moZYzdXeEjRMBPEcvielAsvXDiRZA[i];
				}
				for (int j = 0; j < fhOdxYmTSclyisqmTmxfBIMHESds.Length; j++)
				{
					fhOdxYmTSclyisqmTmxfBIMHESds[j] = P_0.fhOdxYmTSclyisqmTmxfBIMHESds[j];
				}
				for (int k = 0; k < FHcdnyqZbIQYWrJqRnhXzmeswDDm.Length; k++)
				{
					FHcdnyqZbIQYWrJqRnhXzmeswDDm[k] = P_0.FHcdnyqZbIQYWrJqRnhXzmeswDDm[k];
				}
				iowcoypDXYCsSURbYcditjdueZO = P_0.iowcoypDXYCsSURbYcditjdueZO;
				JzCcHpiPsnqdYoGPWHZtIxxCkHlJA = P_0.JzCcHpiPsnqdYoGPWHZtIxxCkHlJA;
				JgCbioGAdFogivEdANEHfqZGLcgSc = P_0.JgCbioGAdFogivEdANEHfqZGLcgSc;
				dDdWSSFQdGOIjPiitsfZSQWLGnTj = P_0.dDdWSSFQdGOIjPiitsfZSQWLGnTj;
				DBrChuWvYdeqaofUkqeXCBbXvtqg = P_0.DBrChuWvYdeqaofUkqeXCBbXvtqg;
				wxsDktEyvloJMWIhjLwuKEhWlPhfb = P_0.wxsDktEyvloJMWIhjLwuKEhWlPhfb;
				for (int l = 0; l < hNOHOMoSvqeawwbWuTiOhbQajSVc.Length; l++)
				{
					hNOHOMoSvqeawwbWuTiOhbQajSVc[l] = P_0.hNOHOMoSvqeawwbWuTiOhbQajSVc[l];
				}
				WhEYJCaVEfivFgPocyEsIEaOAAqG = P_0.WhEYJCaVEfivFgPocyEsIEaOAAqG;
				IBUuHEGnhUplBcalVDLzUKWOvLtq = P_0.IBUuHEGnhUplBcalVDLzUKWOvLtq;
				vjectRiyUeWwrFmOhJYXbRZGaboqb = P_0.vjectRiyUeWwrFmOhJYXbRZGaboqb;
				ZNbuPrVaWHbZYazmARpRtXsHoJSOA = P_0.ZNbuPrVaWHbZYazmARpRtXsHoJSOA;
				hTfFCtYclGXjImMiBlkjBZgFSJoO = P_0.hTfFCtYclGXjImMiBlkjBZgFSJoO;
				DwdncGgRqpNMXQACqpsuThIptYVf = P_0.DwdncGgRqpNMXQACqpsuThIptYVf;
				for (int m = 0; m < uMCfEQIkTCPcJeSgjxWanXmpEynLc.Length; m++)
				{
					uMCfEQIkTCPcJeSgjxWanXmpEynLc[m] = P_0.uMCfEQIkTCPcJeSgjxWanXmpEynLc[m];
				}
				iYTpdTUdyIXFbWQUkysYhwGckGkh = P_0.iYTpdTUdyIXFbWQUkysYhwGckGkh;
				aNapCXlnJwQSkDbVkCYaPoGrhhiaA = P_0.aNapCXlnJwQSkDbVkCYaPoGrhhiaA;
				TYKgBedRlazNPWBYFnyVYGjTzxeFA = P_0.TYKgBedRlazNPWBYFnyVYGjTzxeFA;
				hZeDxLQNJoiLMZiZNfKlKxlsIWoB = P_0.hZeDxLQNJoiLMZiZNfKlKxlsIWoB;
				fvfqxgWzhvJvHUJDFStlgPYrykFl = P_0.fvfqxgWzhvJvHUJDFStlgPYrykFl;
				TcsaLnEkhkxgyTpdfYixKrUztOkJ = P_0.TcsaLnEkhkxgyTpdfYixKrUztOkJ;
				for (int n = 0; n < AdbvKIlfwtzEZqPcBnlrwCsuqhRU.Length; n++)
				{
					AdbvKIlfwtzEZqPcBnlrwCsuqhRU[n] = P_0.AdbvKIlfwtzEZqPcBnlrwCsuqhRU[n];
				}
			}

			public unsafe void hkdyjXsHGWCZkpnGRChCLlOgUHzN(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						FHcdnyqZbIQYWrJqRnhXzmeswDDm[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					uMCfEQIkTCPcJeSgjxWanXmpEynLc[k] = *ptr;
					ptr++;
				}
				WhEYJCaVEfivFgPocyEsIEaOAAqG = *ptr;
				ptr++;
				IBUuHEGnhUplBcalVDLzUKWOvLtq = *ptr;
				ptr++;
				vjectRiyUeWwrFmOhJYXbRZGaboqb = *ptr;
				ptr++;
				ZNbuPrVaWHbZYazmARpRtXsHoJSOA = *ptr;
				ptr++;
				hTfFCtYclGXjImMiBlkjBZgFSJoO = *ptr;
				ptr++;
				DwdncGgRqpNMXQACqpsuThIptYVf = *ptr;
				ptr++;
				dDdWSSFQdGOIjPiitsfZSQWLGnTj = *ptr;
				ptr++;
				DBrChuWvYdeqaofUkqeXCBbXvtqg = *ptr;
				ptr++;
				wxsDktEyvloJMWIhjLwuKEhWlPhfb = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					AdbvKIlfwtzEZqPcBnlrwCsuqhRU[l] = *ptr;
					ptr++;
				}
				iYTpdTUdyIXFbWQUkysYhwGckGkh = *ptr;
				ptr++;
				aNapCXlnJwQSkDbVkCYaPoGrhhiaA = *ptr;
				ptr++;
				TYKgBedRlazNPWBYFnyVYGjTzxeFA = *ptr;
				ptr++;
				BzCUyomfGnqMcFdKiEMWgsbTKnEeA = *ptr;
				ptr++;
				kNHtMIwXdiuaCzFgZXxTgmKslVKF = *ptr;
				ptr++;
				BQLCZdcRzFnpCKDFwgYpLueIPAvA = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					moZYzdXeEjRMBPEcvielAsvXDiRZA[m] = *ptr;
					ptr++;
				}
				hZeDxLQNJoiLMZiZNfKlKxlsIWoB = *ptr;
				ptr++;
				fvfqxgWzhvJvHUJDFStlgPYrykFl = *ptr;
				ptr++;
				TcsaLnEkhkxgyTpdfYixKrUztOkJ = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					hNOHOMoSvqeawwbWuTiOhbQajSVc[n] = *ptr;
					ptr++;
				}
				iowcoypDXYCsSURbYcditjdueZO = *ptr;
				ptr++;
				JzCcHpiPsnqdYoGPWHZtIxxCkHlJA = *ptr;
				ptr++;
				JgCbioGAdFogivEdANEHfqZGLcgSc = *ptr;
				ptr++;
				JFWxFsSQYIfudphtlMkXtJXIXerv = *ptr;
				ptr++;
				idAMOKPYYbaCEXLvThvGzibgLYAp = *ptr;
				ptr++;
				hyVekcpfOzrmLiPrHbxZuuugEaky = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					fhOdxYmTSclyisqmTmxfBIMHESds[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void vpXpuaPVUDEsSirsbLTEWItAipZQ(fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.vyIFxMkEvMfudkrbPAVtanSVxZeqA;
				int[] array2 = P_0.MTvggvkdofkLsHGfjnBIdQHjgcsXB;
				int[] array3 = P_0.DyTjFsWhTANuQPyovsjgaFIIEPMO;
				int[] array4 = P_0.nOkGlBgptVNgbviPFbEXIkMiGyISB;
				int[] array5 = P_0.kfQAcRHnGgxIZuXzFesGFgMFnykOA;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.NQchruvyvxIFUojERLboovROTOsS[i])
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
					*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(array2[j]);
					ptr++;
				}
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.gGYBqYcGzDXXOlELHnaRSsFyAKJtA);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.rOFFPfqWdiCfDpasDWOpHnyYBsEP);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.tpMsCsmmlTlzvjstjaozXxpmkzvU);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.sJcQVvLwXDvuHKHdQUmAsKGqwvJj);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.hIXGYdvgexhsaEQiphzJuDisNTbM);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.rJfaRkBlglLSqITOwBbzjeBpbbduA);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.wdkBYvWOKktlMZhBwEahECOEUqbWA);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.bzxAitkJuVXBNbIPWCjqKMZVICuZ);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.ySskkYAjllnqPSAfmbbIZidvDoee);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(array3[k]);
					ptr++;
				}
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.MTAfiJJUbQekHuSxNCdaIcUAojvO);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.qUZgvhjnJFfXvCJVZhXuFtJAfPedA);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.INjIGcoSKBdtFbsFsCVldjFrAxJO);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.PulfoTuoYkXOrvQtoixSfXUNTFkN);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.FwagLTHgAXlPNqEXcGTnOENcPAPxA);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.WIKtTVgFIuusSepcleuHYJGUhCIK);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(array4[l]);
					ptr++;
				}
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.resKRmJGrrxICUlriacQfWHHUyKK);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.MDMAnkUjUCvAVcveBahaMlzNOhdL);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.MEChUihzvOvfXwWPIppLMjdFcIfaA);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(array5[m]);
					ptr++;
				}
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.KMHYOstcQMCsnZAEvccDkLMXdJIG);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.iWbPbeFpqaUggozynjsTBndbDDUO);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.fohnmIfOlPyCKKMjoFgKVDYkfCgD);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.vJUejbdRgGqWdfjtifIqNGqSMSgpb);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.MeDwLMtzNbtoqcHSRBHXCaCgMSfC);
				ptr++;
				*ptr = ADchHJTJDNkNDhnfJixaFGeYGJBl(P_0.XZHEDoZEhyDmcwkXaogNRfsQnbiR);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int gToLrwESSnIjVwoILaaAKHieIoIVA = 2;

		private const int PqotTLymSAtakIgvxwieidLKTDYl = 2;

		private const int ZEFykguLxhAxqErzwfUBbBIhRHaE = 128;

		private const int jOUhbKNZdGjPFxipVtjBxXCVJOWv = 32;

		private const int SnlIIsWaNWxuoaffdzwTGdOweqYL = 0;

		private const int XWqSGWoXfaqTuoJNQFwIGYFnmtId = 264;

		private const int jXZOPujBfdWsUPTCKCxUulVQKwUV = 272;

		private readonly int mTqHpfUaipSbhokEtcJqktEFxAvTA;

		private readonly ButtonLoopSet gdMJLHFtYpEFvmsxlYMKnQxrKAah;

		private readonly DualThreadLowLevelInputEventQueue CfcCJifWsATyISKxYFaGlrYVRKiS;

		private gkNtifXudJNYfeemlvXZMBonQeid dOUZKmkxRShAiLKGVeYkCkTyIZOM;

		private readonly fEIEHzfgwHXLRiMTFeeLDuigNlxcb eWpYKlFvTSfairEQRTEtsWYRwfGK;

		private readonly fEIEHzfgwHXLRiMTFeeLDuigNlxcb IphsVYhNVfUcMPccbrCoxDroHcpW;

		private readonly object rwZZZzKpkVdOIshDkMCmdbitoiSh;

		private bool DefPnBGyEfgTKsdtUsoSfuxhiKaW;

		public readonly NQheDZtFtwtPwXhJJkvldbrPekPu fIOCzGUswytRpcDosvzICbfreiTFA;

		private readonly XTMhXuicNzsiRcRWRlfmUAOEsLcQ BuZlSshjGvyRAeZEglnCKHqkwawp;

		private bool mXkHOApxFWQiNZSOpuZWrHtRHLGw;

		public bool[] oYAeSAlXSztMwKoVnXvOZKtWTNbp => gdMJLHFtYpEFvmsxlYMKnQxrKAah.Current.effectiveValue;

		public XTMhXuicNzsiRcRWRlfmUAOEsLcQ RAXDpBaCbIUUaBWGpJWmNkSffLDf => BuZlSshjGvyRAeZEglnCKHqkwawp;

		public TpQKeSuTJVwsGafeKVECzGzgftvp(NQheDZtFtwtPwXhJJkvldbrPekPu P_0, UpdateLoopSetting P_1)
		{
			fIOCzGUswytRpcDosvzICbfreiTFA = P_0;
			mTqHpfUaipSbhokEtcJqktEFxAvTA = P_0.gTMAPzeAKWLVPWzSMtAZlxaTsatl.vRwGtTDXnbGJiUVbNyQcGtUoPLlM;
			gdMJLHFtYpEFvmsxlYMKnQxrKAah = new ButtonLoopSet(P_1, mTqHpfUaipSbhokEtcJqktEFxAvTA);
			CfcCJifWsATyISKxYFaGlrYVRKiS = new DualThreadLowLevelInputEventQueue((int)((float)GGlKyqwtSRgaaWuZtxjwSYfoOckk.IxvjPdsczxfVuHMZdgPbDANUNliEb * 0.25f), 128, 32, 2);
			BuZlSshjGvyRAeZEglnCKHqkwawp = new XTMhXuicNzsiRcRWRlfmUAOEsLcQ();
			eWpYKlFvTSfairEQRTEtsWYRwfGK = new fEIEHzfgwHXLRiMTFeeLDuigNlxcb();
			IphsVYhNVfUcMPccbrCoxDroHcpW = new fEIEHzfgwHXLRiMTFeeLDuigNlxcb();
			rwZZZzKpkVdOIshDkMCmdbitoiSh = new object();
			if (GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb != null)
			{
				GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent += xqlYOZZZCGFosqSiiYkarFLPvrm;
			}
		}

		public void IgAeFpzYJAGsgbNdHmwTiWlBaQOn()
		{
			gdMJLHFtYpEFvmsxlYMKnQxrKAah.SetUpdateLoop(ReInput.currentUpdateLoop);
			KslnUcehHAWNkyDeqnEMqISSBGzj();
		}

		public void yuyKtAgTgBmzWCiHNdJJyesEqCoI()
		{
			gdMJLHFtYpEFvmsxlYMKnQxrKAah.Current.ClearWasTrueThisFrame();
		}

		public void lLNFsGexIsPsOdHgJKzoiHAFbXDuA()
		{
			rcefozxAtCPkSBYijvtWKLZLdibhA();
			DefPnBGyEfgTKsdtUsoSfuxhiKaW = true;
		}

		public void QOJfzMSBVJsnXHEiWKdbUnDRbnpD()
		{
			DefPnBGyEfgTKsdtUsoSfuxhiKaW = false;
			rcefozxAtCPkSBYijvtWKLZLdibhA();
		}

		public void fbPVWbcvmwoknfPFjpetczcUwFcK(TpQKeSuTJVwsGafeKVECzGzgftvp P_0)
		{
			if (P_0 == null || P_0 == this || P_0.mTqHpfUaipSbhokEtcJqktEFxAvTA != mTqHpfUaipSbhokEtcJqktEFxAvTA)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (rwZZZzKpkVdOIshDkMCmdbitoiSh)
			{
				lock (P_0.rwZZZzKpkVdOIshDkMCmdbitoiSh)
				{
					gdMJLHFtYpEFvmsxlYMKnQxrKAah.Import(P_0.gdMJLHFtYpEFvmsxlYMKnQxrKAah);
					BuZlSshjGvyRAeZEglnCKHqkwawp.jdkInXRnlklLAoTajIlBMltqCPkcA(P_0.BuZlSshjGvyRAeZEglnCKHqkwawp);
					eWpYKlFvTSfairEQRTEtsWYRwfGK.PDCOfsEXCrhycvFjXbMwpacoWtUd(P_0.eWpYKlFvTSfairEQRTEtsWYRwfGK);
					IphsVYhNVfUcMPccbrCoxDroHcpW.PDCOfsEXCrhycvFjXbMwpacoWtUd(P_0.IphsVYhNVfUcMPccbrCoxDroHcpW);
					CfcCJifWsATyISKxYFaGlrYVRKiS.ImportAll(P_0.CfcCJifWsATyISKxYFaGlrYVRKiS);
					dOUZKmkxRShAiLKGVeYkCkTyIZOM = gkNtifXudJNYfeemlvXZMBonQeid.moCVPTVjkvkpFmOdsuCogHfievzw(P_0.dOUZKmkxRShAiLKGVeYkCkTyIZOM, eWpYKlFvTSfairEQRTEtsWYRwfGK);
					DefPnBGyEfgTKsdtUsoSfuxhiKaW = P_0.DefPnBGyEfgTKsdtUsoSfuxhiKaW;
				}
			}
		}

		public void WcLmkoOXiFBtHEwEhCrwGBbTTUxQ(int P_0, int P_1, int P_2, float P_3)
		{
			lock (rwZZZzKpkVdOIshDkMCmdbitoiSh)
			{
				dOUZKmkxRShAiLKGVeYkCkTyIZOM = new gkNtifXudJNYfeemlvXZMBonQeid(eWpYKlFvTSfairEQRTEtsWYRwfGK, P_0, P_1, P_2, P_3);
			}
		}

		private void xqlYOZZZCGFosqSiiYkarFLPvrm()
		{
			if (!DefPnBGyEfgTKsdtUsoSfuxhiKaW)
			{
				return;
			}
			double realTime;
			try
			{
				fIOCzGUswytRpcDosvzICbfreiTFA.TSiKbJObwUjoUfUciEPDsFxZIhsf(eWpYKlFvTSfairEQRTEtsWYRwfGK);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (rwZZZzKpkVdOIshDkMCmdbitoiSh)
			{
				if (dOUZKmkxRShAiLKGVeYkCkTyIZOM != null)
				{
					dOUZKmkxRShAiLKGVeYkCkTyIZOM.tLegVbZrLXXlvdWjFMevCBPAacYbA(realTime);
				}
				if (!eWpYKlFvTSfairEQRTEtsWYRwfGK.fHqkarosTniwghDLJoHKlbDBaypB(IphsVYhNVfUcMPccbrCoxDroHcpW))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = CfcCJifWsATyISKxYFaGlrYVRKiS.T_CreateEvent())
					{
						XTMhXuicNzsiRcRWRlfmUAOEsLcQ.vpXpuaPVUDEsSirsbLTEWItAipZQ(eWpYKlFvTSfairEQRTEtsWYRwfGK, realTime, newEventWrapper.Event);
					}
					IphsVYhNVfUcMPccbrCoxDroHcpW.PDCOfsEXCrhycvFjXbMwpacoWtUd(eWpYKlFvTSfairEQRTEtsWYRwfGK);
				}
			}
		}

		private void KslnUcehHAWNkyDeqnEMqISSBGzj()
		{
			while (CfcCJifWsATyISKxYFaGlrYVRKiS.ProcessNewEvents())
			{
				BuZlSshjGvyRAeZEglnCKHqkwawp.hkdyjXsHGWCZkpnGRChCLlOgUHzN(ref CfcCJifWsATyISKxYFaGlrYVRKiS.currentEvent);
				for (int i = 0; i < mTqHpfUaipSbhokEtcJqktEFxAvTA; i++)
				{
					gdMJLHFtYpEFvmsxlYMKnQxrKAah.SetValue(i, BuZlSshjGvyRAeZEglnCKHqkwawp.FHcdnyqZbIQYWrJqRnhXzmeswDDm[i], CfcCJifWsATyISKxYFaGlrYVRKiS.currentEvent.GetTimestamp());
				}
			}
		}

		private void rcefozxAtCPkSBYijvtWKLZLdibhA()
		{
			BuZlSshjGvyRAeZEglnCKHqkwawp.BTRCDmGWXOyCKdcVoKVNAHPwaVWIA();
			lock (rwZZZzKpkVdOIshDkMCmdbitoiSh)
			{
				eWpYKlFvTSfairEQRTEtsWYRwfGK.QXyEvBjNHxbrLaHChBjWKixyxcpI();
				IphsVYhNVfUcMPccbrCoxDroHcpW.QXyEvBjNHxbrLaHChBjWKixyxcpI();
				CfcCJifWsATyISKxYFaGlrYVRKiS.Clear();
			}
			gdMJLHFtYpEFvmsxlYMKnQxrKAah.Clear();
		}

		public void Dispose()
		{
			ggvOwFsrHgTRbkdEmsrjPpMzcnBiA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void vZyoPZaRmWEvVGOtcpjmVUlRvjMg()
		{
			try
			{
				ggvOwFsrHgTRbkdEmsrjPpMzcnBiA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void ggvOwFsrHgTRbkdEmsrjPpMzcnBiA(bool P_0)
		{
			if (!mXkHOApxFWQiNZSOpuZWrHtRHLGw)
			{
				if (P_0)
				{
					QOJfzMSBVJsnXHEiWKdbUnDRbnpD();
					CfcCJifWsATyISKxYFaGlrYVRKiS.Dispose();
				}
				if (GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb != null)
				{
					GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent -= xqlYOZZZCGFosqSiiYkarFLPvrm;
				}
				mXkHOApxFWQiNZSOpuZWrHtRHLGw = true;
			}
		}

		private static float ADchHJTJDNkNDhnfJixaFGeYGJBl(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class gkNtifXudJNYfeemlvXZMBonQeid
	{
		private fEIEHzfgwHXLRiMTFeeLDuigNlxcb iabGgroDQUgopBOSsjoNAVrYpHPEb;

		private DzejRyaBXBXZxUddhXEIjhFZJBpn akNnODeVVEGhlhfPuODXtpBCIxMm;

		private int lwCgviwfXyqzxvmymUNrEoQyglPr;

		private int rfTWtlvZSRJLZbDhuQzejoIFrcYy;

		private int gZBwmqoTWOTyEMGSzfiBxrIRDuOO;

		private float SheBnyBvFrCprrEWSgebMLmLAxaiA;

		public fEIEHzfgwHXLRiMTFeeLDuigNlxcb MptNjzbjebAMIakuCJpMyCVUNUVE => iabGgroDQUgopBOSsjoNAVrYpHPEb;

		public static gkNtifXudJNYfeemlvXZMBonQeid moCVPTVjkvkpFmOdsuCogHfievzw(gkNtifXudJNYfeemlvXZMBonQeid P_0, fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new gkNtifXudJNYfeemlvXZMBonQeid(P_0, P_1);
		}

		public gkNtifXudJNYfeemlvXZMBonQeid(fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			akNnODeVVEGhlhfPuODXtpBCIxMm = new DzejRyaBXBXZxUddhXEIjhFZJBpn(P_0);
			iabGgroDQUgopBOSsjoNAVrYpHPEb = new fEIEHzfgwHXLRiMTFeeLDuigNlxcb();
		}

		private gkNtifXudJNYfeemlvXZMBonQeid(gkNtifXudJNYfeemlvXZMBonQeid P_0, fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_1)
			: this(P_1, P_0.lwCgviwfXyqzxvmymUNrEoQyglPr, P_0.rfTWtlvZSRJLZbDhuQzejoIFrcYy, P_0.gZBwmqoTWOTyEMGSzfiBxrIRDuOO, P_0.SheBnyBvFrCprrEWSgebMLmLAxaiA)
		{
			jtmgBNTGoeTmsUDnrTnFBtZTNbtQ(P_0);
		}

		private gkNtifXudJNYfeemlvXZMBonQeid(int P_0, int P_1, int P_2, float P_3)
		{
			lwCgviwfXyqzxvmymUNrEoQyglPr = P_0;
			rfTWtlvZSRJLZbDhuQzejoIFrcYy = P_1;
			gZBwmqoTWOTyEMGSzfiBxrIRDuOO = P_2;
			SheBnyBvFrCprrEWSgebMLmLAxaiA = P_3;
		}

		public void tLegVbZrLXXlvdWjFMevCBPAacYbA(double P_0)
		{
			akNnODeVVEGhlhfPuODXtpBCIxMm.lppoZkfzxqeKAvWlKydHsMfNOaAl(P_0);
			if (!akNnODeVVEGhlhfPuODXtpBCIxMm.hdFWSFTcvVfONqKIegocaRuEQWzBb)
			{
				if (P_0 >= akNnODeVVEGhlhfPuODXtpBCIxMm.oLIixaZosXfhKBziQcZpVOHFDQlC + (double)SheBnyBvFrCprrEWSgebMLmLAxaiA)
				{
					iabGgroDQUgopBOSsjoNAVrYpHPEb.QXyEvBjNHxbrLaHChBjWKixyxcpI();
				}
				return;
			}
			fEIEHzfgwHXLRiMTFeeLDuigNlxcb fEIEHzfgwHXLRiMTFeeLDuigNlxcb2 = akNnODeVVEGhlhfPuODXtpBCIxMm.pedLsUgLbJDVBuMPfDeeKqnjEocPA;
			fEIEHzfgwHXLRiMTFeeLDuigNlxcb fEIEHzfgwHXLRiMTFeeLDuigNlxcb3 = akNnODeVVEGhlhfPuODXtpBCIxMm.SmxMtyyFaRbaqjwywtmUTJtuodLyA;
			iabGgroDQUgopBOSsjoNAVrYpHPEb.vJUejbdRgGqWdfjtifIqNGqSMSgpb = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.vJUejbdRgGqWdfjtifIqNGqSMSgpb);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.MeDwLMtzNbtoqcHSRBHXCaCgMSfC = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.MeDwLMtzNbtoqcHSRBHXCaCgMSfC);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.XZHEDoZEhyDmcwkXaogNRfsQnbiR = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.XZHEDoZEhyDmcwkXaogNRfsQnbiR);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.PulfoTuoYkXOrvQtoixSfXUNTFkN = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.PulfoTuoYkXOrvQtoixSfXUNTFkN);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.FwagLTHgAXlPNqEXcGTnOENcPAPxA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.FwagLTHgAXlPNqEXcGTnOENcPAPxA);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.WIKtTVgFIuusSepcleuHYJGUhCIK = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.WIKtTVgFIuusSepcleuHYJGUhCIK);
			for (int i = 0; i < iabGgroDQUgopBOSsjoNAVrYpHPEb.nOkGlBgptVNgbviPFbEXIkMiGyISB.Length; i++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.nOkGlBgptVNgbviPFbEXIkMiGyISB[i] = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.nOkGlBgptVNgbviPFbEXIkMiGyISB[i]);
			}
			for (int j = 0; j < iabGgroDQUgopBOSsjoNAVrYpHPEb.vyIFxMkEvMfudkrbPAVtanSVxZeqA.Length; j++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j] = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j]);
			}
			for (int k = 0; k < iabGgroDQUgopBOSsjoNAVrYpHPEb.NQchruvyvxIFUojERLboovROTOsS.Length; k++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.NQchruvyvxIFUojERLboovROTOsS[k] = fEIEHzfgwHXLRiMTFeeLDuigNlxcb3.NQchruvyvxIFUojERLboovROTOsS[k];
			}
			iabGgroDQUgopBOSsjoNAVrYpHPEb.KMHYOstcQMCsnZAEvccDkLMXdJIG = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.KMHYOstcQMCsnZAEvccDkLMXdJIG);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.iWbPbeFpqaUggozynjsTBndbDDUO = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.iWbPbeFpqaUggozynjsTBndbDDUO);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.fohnmIfOlPyCKKMjoFgKVDYkfCgD = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.fohnmIfOlPyCKKMjoFgKVDYkfCgD);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.wdkBYvWOKktlMZhBwEahECOEUqbWA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.wdkBYvWOKktlMZhBwEahECOEUqbWA);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.bzxAitkJuVXBNbIPWCjqKMZVICuZ = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.bzxAitkJuVXBNbIPWCjqKMZVICuZ);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.ySskkYAjllnqPSAfmbbIZidvDoee = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.ySskkYAjllnqPSAfmbbIZidvDoee);
			for (int l = 0; l < iabGgroDQUgopBOSsjoNAVrYpHPEb.kfQAcRHnGgxIZuXzFesGFgMFnykOA.Length; l++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l] = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l]);
			}
			iabGgroDQUgopBOSsjoNAVrYpHPEb.gGYBqYcGzDXXOlELHnaRSsFyAKJtA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.gGYBqYcGzDXXOlELHnaRSsFyAKJtA);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.rOFFPfqWdiCfDpasDWOpHnyYBsEP = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.rOFFPfqWdiCfDpasDWOpHnyYBsEP);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.tpMsCsmmlTlzvjstjaozXxpmkzvU = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.tpMsCsmmlTlzvjstjaozXxpmkzvU);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.sJcQVvLwXDvuHKHdQUmAsKGqwvJj = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.sJcQVvLwXDvuHKHdQUmAsKGqwvJj);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.hIXGYdvgexhsaEQiphzJuDisNTbM = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.hIXGYdvgexhsaEQiphzJuDisNTbM);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.rJfaRkBlglLSqITOwBbzjeBpbbduA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.rJfaRkBlglLSqITOwBbzjeBpbbduA);
			for (int m = 0; m < iabGgroDQUgopBOSsjoNAVrYpHPEb.MTvggvkdofkLsHGfjnBIdQHjgcsXB.Length; m++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m] = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m]);
			}
			iabGgroDQUgopBOSsjoNAVrYpHPEb.MTAfiJJUbQekHuSxNCdaIcUAojvO = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.MTAfiJJUbQekHuSxNCdaIcUAojvO);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.qUZgvhjnJFfXvCJVZhXuFtJAfPedA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.qUZgvhjnJFfXvCJVZhXuFtJAfPedA);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.INjIGcoSKBdtFbsFsCVldjFrAxJO = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.INjIGcoSKBdtFbsFsCVldjFrAxJO);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.resKRmJGrrxICUlriacQfWHHUyKK = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.resKRmJGrrxICUlriacQfWHHUyKK);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.MDMAnkUjUCvAVcveBahaMlzNOhdL = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.MDMAnkUjUCvAVcveBahaMlzNOhdL);
			iabGgroDQUgopBOSsjoNAVrYpHPEb.MEChUihzvOvfXwWPIppLMjdFcIfaA = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.MEChUihzvOvfXwWPIppLMjdFcIfaA);
			for (int n = 0; n < iabGgroDQUgopBOSsjoNAVrYpHPEb.DyTjFsWhTANuQPyovsjgaFIIEPMO.Length; n++)
			{
				iabGgroDQUgopBOSsjoNAVrYpHPEb.DyTjFsWhTANuQPyovsjgaFIIEPMO[n] = uikLcynPHaoqCdPOYOqlEwjwqAIr(fEIEHzfgwHXLRiMTFeeLDuigNlxcb2.DyTjFsWhTANuQPyovsjgaFIIEPMO[n]);
			}
		}

		public void jtmgBNTGoeTmsUDnrTnFBtZTNbtQ(gkNtifXudJNYfeemlvXZMBonQeid P_0)
		{
			iabGgroDQUgopBOSsjoNAVrYpHPEb.PDCOfsEXCrhycvFjXbMwpacoWtUd(P_0.iabGgroDQUgopBOSsjoNAVrYpHPEb);
			akNnODeVVEGhlhfPuODXtpBCIxMm.IFIaxBEkNmrumfydlZSmuPkrwhLqA(P_0.akNnODeVVEGhlhfPuODXtpBCIxMm);
			lwCgviwfXyqzxvmymUNrEoQyglPr = P_0.lwCgviwfXyqzxvmymUNrEoQyglPr;
			rfTWtlvZSRJLZbDhuQzejoIFrcYy = P_0.rfTWtlvZSRJLZbDhuQzejoIFrcYy;
			gZBwmqoTWOTyEMGSzfiBxrIRDuOO = P_0.gZBwmqoTWOTyEMGSzfiBxrIRDuOO;
			SheBnyBvFrCprrEWSgebMLmLAxaiA = P_0.SheBnyBvFrCprrEWSgebMLmLAxaiA;
		}

		private int uikLcynPHaoqCdPOYOqlEwjwqAIr(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, lwCgviwfXyqzxvmymUNrEoQyglPr, rfTWtlvZSRJLZbDhuQzejoIFrcYy, -65535, 65535);
		}
	}

	private class DzejRyaBXBXZxUddhXEIjhFZJBpn
	{
		private double aUURscuAjCtIyqBMmjDzgjMahweYA;

		private fEIEHzfgwHXLRiMTFeeLDuigNlxcb cAMuCFucdsxoIAbzqNLCZuwmSdto;

		private fEIEHzfgwHXLRiMTFeeLDuigNlxcb lxloFtdakBNBCUvthShNXpAGaiIN;

		private fEIEHzfgwHXLRiMTFeeLDuigNlxcb PwQrXGwrUCojmTRAvPQBWHPWHCzh;

		private bool SAIfPPpMzfMpoESQvBWDbhclshvv;

		private double UpTDkggjiufBQvFRDTvSCfxtJdvEA;

		public fEIEHzfgwHXLRiMTFeeLDuigNlxcb SmxMtyyFaRbaqjwywtmUTJtuodLyA => cAMuCFucdsxoIAbzqNLCZuwmSdto;

		public fEIEHzfgwHXLRiMTFeeLDuigNlxcb pedLsUgLbJDVBuMPfDeeKqnjEocPA => PwQrXGwrUCojmTRAvPQBWHPWHCzh;

		public bool hdFWSFTcvVfONqKIegocaRuEQWzBb => SAIfPPpMzfMpoESQvBWDbhclshvv;

		public double oLIixaZosXfhKBziQcZpVOHFDQlC => UpTDkggjiufBQvFRDTvSCfxtJdvEA;

		public DzejRyaBXBXZxUddhXEIjhFZJBpn(fEIEHzfgwHXLRiMTFeeLDuigNlxcb P_0)
		{
			cAMuCFucdsxoIAbzqNLCZuwmSdto = P_0;
			lxloFtdakBNBCUvthShNXpAGaiIN = new fEIEHzfgwHXLRiMTFeeLDuigNlxcb();
			PwQrXGwrUCojmTRAvPQBWHPWHCzh = new fEIEHzfgwHXLRiMTFeeLDuigNlxcb();
		}

		public void lppoZkfzxqeKAvWlKydHsMfNOaAl(double P_0)
		{
			aUURscuAjCtIyqBMmjDzgjMahweYA = P_0;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.vJUejbdRgGqWdfjtifIqNGqSMSgpb = cAMuCFucdsxoIAbzqNLCZuwmSdto.vJUejbdRgGqWdfjtifIqNGqSMSgpb - lxloFtdakBNBCUvthShNXpAGaiIN.vJUejbdRgGqWdfjtifIqNGqSMSgpb;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.MeDwLMtzNbtoqcHSRBHXCaCgMSfC = cAMuCFucdsxoIAbzqNLCZuwmSdto.MeDwLMtzNbtoqcHSRBHXCaCgMSfC - lxloFtdakBNBCUvthShNXpAGaiIN.MeDwLMtzNbtoqcHSRBHXCaCgMSfC;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.XZHEDoZEhyDmcwkXaogNRfsQnbiR = cAMuCFucdsxoIAbzqNLCZuwmSdto.XZHEDoZEhyDmcwkXaogNRfsQnbiR - lxloFtdakBNBCUvthShNXpAGaiIN.XZHEDoZEhyDmcwkXaogNRfsQnbiR;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.PulfoTuoYkXOrvQtoixSfXUNTFkN = cAMuCFucdsxoIAbzqNLCZuwmSdto.PulfoTuoYkXOrvQtoixSfXUNTFkN - lxloFtdakBNBCUvthShNXpAGaiIN.PulfoTuoYkXOrvQtoixSfXUNTFkN;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.FwagLTHgAXlPNqEXcGTnOENcPAPxA = cAMuCFucdsxoIAbzqNLCZuwmSdto.FwagLTHgAXlPNqEXcGTnOENcPAPxA - lxloFtdakBNBCUvthShNXpAGaiIN.FwagLTHgAXlPNqEXcGTnOENcPAPxA;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.WIKtTVgFIuusSepcleuHYJGUhCIK = cAMuCFucdsxoIAbzqNLCZuwmSdto.WIKtTVgFIuusSepcleuHYJGUhCIK - lxloFtdakBNBCUvthShNXpAGaiIN.WIKtTVgFIuusSepcleuHYJGUhCIK;
			for (int i = 0; i < cAMuCFucdsxoIAbzqNLCZuwmSdto.nOkGlBgptVNgbviPFbEXIkMiGyISB.Length; i++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.nOkGlBgptVNgbviPFbEXIkMiGyISB[i] = cAMuCFucdsxoIAbzqNLCZuwmSdto.nOkGlBgptVNgbviPFbEXIkMiGyISB[i] - lxloFtdakBNBCUvthShNXpAGaiIN.nOkGlBgptVNgbviPFbEXIkMiGyISB[i];
			}
			for (int j = 0; j < cAMuCFucdsxoIAbzqNLCZuwmSdto.vyIFxMkEvMfudkrbPAVtanSVxZeqA.Length; j++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j] = cAMuCFucdsxoIAbzqNLCZuwmSdto.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j] - lxloFtdakBNBCUvthShNXpAGaiIN.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j];
			}
			for (int k = 0; k < cAMuCFucdsxoIAbzqNLCZuwmSdto.NQchruvyvxIFUojERLboovROTOsS.Length; k++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.NQchruvyvxIFUojERLboovROTOsS[k] = cAMuCFucdsxoIAbzqNLCZuwmSdto.NQchruvyvxIFUojERLboovROTOsS[k] != lxloFtdakBNBCUvthShNXpAGaiIN.NQchruvyvxIFUojERLboovROTOsS[k];
			}
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.KMHYOstcQMCsnZAEvccDkLMXdJIG = cAMuCFucdsxoIAbzqNLCZuwmSdto.KMHYOstcQMCsnZAEvccDkLMXdJIG - lxloFtdakBNBCUvthShNXpAGaiIN.KMHYOstcQMCsnZAEvccDkLMXdJIG;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.iWbPbeFpqaUggozynjsTBndbDDUO = cAMuCFucdsxoIAbzqNLCZuwmSdto.iWbPbeFpqaUggozynjsTBndbDDUO - lxloFtdakBNBCUvthShNXpAGaiIN.iWbPbeFpqaUggozynjsTBndbDDUO;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.fohnmIfOlPyCKKMjoFgKVDYkfCgD = cAMuCFucdsxoIAbzqNLCZuwmSdto.fohnmIfOlPyCKKMjoFgKVDYkfCgD - lxloFtdakBNBCUvthShNXpAGaiIN.fohnmIfOlPyCKKMjoFgKVDYkfCgD;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.wdkBYvWOKktlMZhBwEahECOEUqbWA = cAMuCFucdsxoIAbzqNLCZuwmSdto.wdkBYvWOKktlMZhBwEahECOEUqbWA - lxloFtdakBNBCUvthShNXpAGaiIN.wdkBYvWOKktlMZhBwEahECOEUqbWA;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.bzxAitkJuVXBNbIPWCjqKMZVICuZ = cAMuCFucdsxoIAbzqNLCZuwmSdto.bzxAitkJuVXBNbIPWCjqKMZVICuZ - lxloFtdakBNBCUvthShNXpAGaiIN.bzxAitkJuVXBNbIPWCjqKMZVICuZ;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.ySskkYAjllnqPSAfmbbIZidvDoee = cAMuCFucdsxoIAbzqNLCZuwmSdto.ySskkYAjllnqPSAfmbbIZidvDoee - lxloFtdakBNBCUvthShNXpAGaiIN.ySskkYAjllnqPSAfmbbIZidvDoee;
			for (int l = 0; l < cAMuCFucdsxoIAbzqNLCZuwmSdto.kfQAcRHnGgxIZuXzFesGFgMFnykOA.Length; l++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l] = cAMuCFucdsxoIAbzqNLCZuwmSdto.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l] - lxloFtdakBNBCUvthShNXpAGaiIN.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l];
			}
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.gGYBqYcGzDXXOlELHnaRSsFyAKJtA = cAMuCFucdsxoIAbzqNLCZuwmSdto.gGYBqYcGzDXXOlELHnaRSsFyAKJtA - lxloFtdakBNBCUvthShNXpAGaiIN.gGYBqYcGzDXXOlELHnaRSsFyAKJtA;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.rOFFPfqWdiCfDpasDWOpHnyYBsEP = cAMuCFucdsxoIAbzqNLCZuwmSdto.rOFFPfqWdiCfDpasDWOpHnyYBsEP - lxloFtdakBNBCUvthShNXpAGaiIN.rOFFPfqWdiCfDpasDWOpHnyYBsEP;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.tpMsCsmmlTlzvjstjaozXxpmkzvU = cAMuCFucdsxoIAbzqNLCZuwmSdto.tpMsCsmmlTlzvjstjaozXxpmkzvU - lxloFtdakBNBCUvthShNXpAGaiIN.tpMsCsmmlTlzvjstjaozXxpmkzvU;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.sJcQVvLwXDvuHKHdQUmAsKGqwvJj = cAMuCFucdsxoIAbzqNLCZuwmSdto.sJcQVvLwXDvuHKHdQUmAsKGqwvJj - lxloFtdakBNBCUvthShNXpAGaiIN.sJcQVvLwXDvuHKHdQUmAsKGqwvJj;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.hIXGYdvgexhsaEQiphzJuDisNTbM = cAMuCFucdsxoIAbzqNLCZuwmSdto.hIXGYdvgexhsaEQiphzJuDisNTbM - lxloFtdakBNBCUvthShNXpAGaiIN.hIXGYdvgexhsaEQiphzJuDisNTbM;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.rJfaRkBlglLSqITOwBbzjeBpbbduA = cAMuCFucdsxoIAbzqNLCZuwmSdto.rJfaRkBlglLSqITOwBbzjeBpbbduA - lxloFtdakBNBCUvthShNXpAGaiIN.rJfaRkBlglLSqITOwBbzjeBpbbduA;
			for (int m = 0; m < cAMuCFucdsxoIAbzqNLCZuwmSdto.MTvggvkdofkLsHGfjnBIdQHjgcsXB.Length; m++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m] = cAMuCFucdsxoIAbzqNLCZuwmSdto.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m] - lxloFtdakBNBCUvthShNXpAGaiIN.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m];
			}
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.MTAfiJJUbQekHuSxNCdaIcUAojvO = cAMuCFucdsxoIAbzqNLCZuwmSdto.MTAfiJJUbQekHuSxNCdaIcUAojvO - lxloFtdakBNBCUvthShNXpAGaiIN.MTAfiJJUbQekHuSxNCdaIcUAojvO;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.qUZgvhjnJFfXvCJVZhXuFtJAfPedA = cAMuCFucdsxoIAbzqNLCZuwmSdto.qUZgvhjnJFfXvCJVZhXuFtJAfPedA - lxloFtdakBNBCUvthShNXpAGaiIN.qUZgvhjnJFfXvCJVZhXuFtJAfPedA;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.INjIGcoSKBdtFbsFsCVldjFrAxJO = cAMuCFucdsxoIAbzqNLCZuwmSdto.INjIGcoSKBdtFbsFsCVldjFrAxJO - lxloFtdakBNBCUvthShNXpAGaiIN.INjIGcoSKBdtFbsFsCVldjFrAxJO;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.resKRmJGrrxICUlriacQfWHHUyKK = cAMuCFucdsxoIAbzqNLCZuwmSdto.resKRmJGrrxICUlriacQfWHHUyKK - lxloFtdakBNBCUvthShNXpAGaiIN.resKRmJGrrxICUlriacQfWHHUyKK;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.MDMAnkUjUCvAVcveBahaMlzNOhdL = cAMuCFucdsxoIAbzqNLCZuwmSdto.MDMAnkUjUCvAVcveBahaMlzNOhdL - lxloFtdakBNBCUvthShNXpAGaiIN.MDMAnkUjUCvAVcveBahaMlzNOhdL;
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.MEChUihzvOvfXwWPIppLMjdFcIfaA = cAMuCFucdsxoIAbzqNLCZuwmSdto.MEChUihzvOvfXwWPIppLMjdFcIfaA - lxloFtdakBNBCUvthShNXpAGaiIN.MEChUihzvOvfXwWPIppLMjdFcIfaA;
			for (int n = 0; n < cAMuCFucdsxoIAbzqNLCZuwmSdto.DyTjFsWhTANuQPyovsjgaFIIEPMO.Length; n++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.DyTjFsWhTANuQPyovsjgaFIIEPMO[n] = cAMuCFucdsxoIAbzqNLCZuwmSdto.DyTjFsWhTANuQPyovsjgaFIIEPMO[n] - lxloFtdakBNBCUvthShNXpAGaiIN.DyTjFsWhTANuQPyovsjgaFIIEPMO[n];
			}
			SAIfPPpMzfMpoESQvBWDbhclshvv = ERPAUFYrfgsuvMkwkhLBpdvLKSVK();
			if (SAIfPPpMzfMpoESQvBWDbhclshvv)
			{
				UpTDkggjiufBQvFRDTvSCfxtJdvEA = P_0;
				lxloFtdakBNBCUvthShNXpAGaiIN.PDCOfsEXCrhycvFjXbMwpacoWtUd(cAMuCFucdsxoIAbzqNLCZuwmSdto);
			}
		}

		public void IFIaxBEkNmrumfydlZSmuPkrwhLqA(DzejRyaBXBXZxUddhXEIjhFZJBpn P_0)
		{
			aUURscuAjCtIyqBMmjDzgjMahweYA = P_0.aUURscuAjCtIyqBMmjDzgjMahweYA;
			lxloFtdakBNBCUvthShNXpAGaiIN.PDCOfsEXCrhycvFjXbMwpacoWtUd(P_0.lxloFtdakBNBCUvthShNXpAGaiIN);
			PwQrXGwrUCojmTRAvPQBWHPWHCzh.PDCOfsEXCrhycvFjXbMwpacoWtUd(P_0.PwQrXGwrUCojmTRAvPQBWHPWHCzh);
		}

		private bool ERPAUFYrfgsuvMkwkhLBpdvLKSVK()
		{
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.MeDwLMtzNbtoqcHSRBHXCaCgMSfC != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.XZHEDoZEhyDmcwkXaogNRfsQnbiR != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.PulfoTuoYkXOrvQtoixSfXUNTFkN != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.FwagLTHgAXlPNqEXcGTnOENcPAPxA != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.WIKtTVgFIuusSepcleuHYJGUhCIK != 0)
			{
				return true;
			}
			for (int i = 0; i < cAMuCFucdsxoIAbzqNLCZuwmSdto.nOkGlBgptVNgbviPFbEXIkMiGyISB.Length; i++)
			{
				if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.nOkGlBgptVNgbviPFbEXIkMiGyISB[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < cAMuCFucdsxoIAbzqNLCZuwmSdto.vyIFxMkEvMfudkrbPAVtanSVxZeqA.Length; j++)
			{
				if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.vyIFxMkEvMfudkrbPAVtanSVxZeqA[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < cAMuCFucdsxoIAbzqNLCZuwmSdto.NQchruvyvxIFUojERLboovROTOsS.Length; k++)
			{
				if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.NQchruvyvxIFUojERLboovROTOsS[k])
				{
					return true;
				}
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.KMHYOstcQMCsnZAEvccDkLMXdJIG != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.iWbPbeFpqaUggozynjsTBndbDDUO != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.fohnmIfOlPyCKKMjoFgKVDYkfCgD != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.wdkBYvWOKktlMZhBwEahECOEUqbWA != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.bzxAitkJuVXBNbIPWCjqKMZVICuZ != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.ySskkYAjllnqPSAfmbbIZidvDoee != 0)
			{
				return true;
			}
			for (int l = 0; l < cAMuCFucdsxoIAbzqNLCZuwmSdto.kfQAcRHnGgxIZuXzFesGFgMFnykOA.Length; l++)
			{
				if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.kfQAcRHnGgxIZuXzFesGFgMFnykOA[l] != 0)
				{
					return true;
				}
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.gGYBqYcGzDXXOlELHnaRSsFyAKJtA != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.rOFFPfqWdiCfDpasDWOpHnyYBsEP != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.tpMsCsmmlTlzvjstjaozXxpmkzvU != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.sJcQVvLwXDvuHKHdQUmAsKGqwvJj != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.hIXGYdvgexhsaEQiphzJuDisNTbM != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.rJfaRkBlglLSqITOwBbzjeBpbbduA != 0)
			{
				return true;
			}
			for (int m = 0; m < cAMuCFucdsxoIAbzqNLCZuwmSdto.MTvggvkdofkLsHGfjnBIdQHjgcsXB.Length; m++)
			{
				PwQrXGwrUCojmTRAvPQBWHPWHCzh.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m] = cAMuCFucdsxoIAbzqNLCZuwmSdto.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m] - lxloFtdakBNBCUvthShNXpAGaiIN.MTvggvkdofkLsHGfjnBIdQHjgcsXB[m];
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.MTAfiJJUbQekHuSxNCdaIcUAojvO != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.qUZgvhjnJFfXvCJVZhXuFtJAfPedA != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.INjIGcoSKBdtFbsFsCVldjFrAxJO != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.resKRmJGrrxICUlriacQfWHHUyKK != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.MDMAnkUjUCvAVcveBahaMlzNOhdL != 0)
			{
				return true;
			}
			if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.MEChUihzvOvfXwWPIppLMjdFcIfaA != 0)
			{
				return true;
			}
			for (int n = 0; n < cAMuCFucdsxoIAbzqNLCZuwmSdto.DyTjFsWhTANuQPyovsjgaFIIEPMO.Length; n++)
			{
				if (PwQrXGwrUCojmTRAvPQBWHPWHCzh.DyTjFsWhTANuQPyovsjgaFIIEPMO[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class FqJCPmCvZYRgMafkaZzEUUYgDZCxA
	{
		public enum tfMOgURNaeQFUFZvTCNXlXFFVyCd
		{
			Exact = 0,
			Approximate = 1
		}

		public class TXrLvXzFHkdiHDsUNWmqJZRISLcv
		{
			public int nbJuxRnnNcDeROnqBEAyrvjNLNiN;

			public Guid fLxNoUIKvqEkwtdiGJEXrwpglCq;

			public Guid zAnHkraKWYibqwSQhFSCOVkcLbTZA;

			public int kjEtJrjOKGctnTxXSGgjROqHisWd;

			public int thCLPskHIlKjOAnGvgrUfvRzgwdqA;

			public int GYisIznaQdAbcJYxQalVpIfdiKVDb;

			public int dLxftwRyjdyozlktNItujupfaLmg;

			public bool oQSZuTAmzEekmbFGYLrgfNASTMEKA(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, tfMOgURNaeQFUFZvTCNXlXFFVyCd P_1)
			{
				if (P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId == nbJuxRnnNcDeROnqBEAyrvjNLNiN)
				{
					return true;
				}
				if (thCLPskHIlKjOAnGvgrUfvRzgwdqA != P_0.sRqdccCqHIdlZZxjlMJpGGALMTXu)
				{
					return false;
				}
				if (GYisIznaQdAbcJYxQalVpIfdiKVDb != P_0.cYKFgMwUErcyAyvJljXcHZiszjtdA)
				{
					return false;
				}
				if (dLxftwRyjdyozlktNItujupfaLmg != P_0.lDpdRWDWZUtgDsssjLjkHetIIjZsB)
				{
					return false;
				}
				return P_1 switch
				{
					tfMOgURNaeQFUFZvTCNXlXFFVyCd.Exact => fLxNoUIKvqEkwtdiGJEXrwpglCq == P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, 
					tfMOgURNaeQFUFZvTCNXlXFFVyCd.Approximate => zAnHkraKWYibqwSQhFSCOVkcLbTZA == P_0.ePRUxDMNyiMTwUPuGAuEHagZYnTL, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string bGQxueyxuuNHfLHYrgLfmmhmBLPx()
			{
				string text = "" + "rewiredId = " + nbJuxRnnNcDeROnqBEAyrvjNLNiN + "\n";
				Guid guid = fLxNoUIKvqEkwtdiGJEXrwpglCq;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = zAnHkraKWYibqwSQhFSCOVkcLbTZA;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", kjEtJrjOKGctnTxXSGgjROqHisWd.ToString(), "\n"), "hardwareAxisCount = ", thCLPskHIlKjOAnGvgrUfvRzgwdqA.ToString(), "\n"), "hardwareButtonCount = ", GYisIznaQdAbcJYxQalVpIfdiKVDb.ToString(), "\n"), "hardwareHatCount = ", dLxftwRyjdyozlktNItujupfaLmg.ToString(), "\n");
			}
		}

		private sealed class nxsfnDmLpIcrLoibyiPqGwnIleMVA : IEnumerable<TXrLvXzFHkdiHDsUNWmqJZRISLcv>, IEnumerable, IEnumerator<TXrLvXzFHkdiHDsUNWmqJZRISLcv>, IEnumerator, IDisposable
		{
			private int xIuOxpQlTlPtwkniSHQHjIZRkLZO;

			private TXrLvXzFHkdiHDsUNWmqJZRISLcv nCjafjgCTFpnoXAGvdnehvyakDxib;

			private int uasDAEhtFAKwwDlTRNGRuXvsBupCb;

			public FqJCPmCvZYRgMafkaZzEUUYgDZCxA OtKUbmqofcpYUIWlAktWbquuNmGP;

			private jeVhmjjeVKqMykpAYwlbuYKFcBZI chQLExTTfOIcXNPemyDoDLdOreKL;

			public jeVhmjjeVKqMykpAYwlbuYKFcBZI DVNQbCaEZKfBblqqyAFSkSNAjKmbb;

			private tfMOgURNaeQFUFZvTCNXlXFFVyCd rMcLAaXXrgixhZYxAfKMKzPumUBc;

			public tfMOgURNaeQFUFZvTCNXlXFFVyCd ygBKYhkdffaqzCQpCZMYRqhOkQOe;

			private int wmyAfEOEmUFTwJMcyCiDGxXToRBB;

			private int RGwOTfpWxHlnpIIhaCYqLAlVgmgR;

			TXrLvXzFHkdiHDsUNWmqJZRISLcv IEnumerator<TXrLvXzFHkdiHDsUNWmqJZRISLcv>.Current
			{
				[DebuggerHidden]
				get
				{
					return nCjafjgCTFpnoXAGvdnehvyakDxib;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nCjafjgCTFpnoXAGvdnehvyakDxib;
				}
			}

			[DebuggerHidden]
			public nxsfnDmLpIcrLoibyiPqGwnIleMVA(int P_0)
			{
				xIuOxpQlTlPtwkniSHQHjIZRkLZO = P_0;
				uasDAEhtFAKwwDlTRNGRuXvsBupCb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = xIuOxpQlTlPtwkniSHQHjIZRkLZO;
				FqJCPmCvZYRgMafkaZzEUUYgDZCxA otKUbmqofcpYUIWlAktWbquuNmGP = OtKUbmqofcpYUIWlAktWbquuNmGP;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					xIuOxpQlTlPtwkniSHQHjIZRkLZO = -1;
					goto IL_0083;
				}
				xIuOxpQlTlPtwkniSHQHjIZRkLZO = -1;
				wmyAfEOEmUFTwJMcyCiDGxXToRBB = otKUbmqofcpYUIWlAktWbquuNmGP.qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count;
				RGwOTfpWxHlnpIIhaCYqLAlVgmgR = 0;
				goto IL_0093;
				IL_0083:
				RGwOTfpWxHlnpIIhaCYqLAlVgmgR++;
				goto IL_0093;
				IL_0093:
				if (RGwOTfpWxHlnpIIhaCYqLAlVgmgR < wmyAfEOEmUFTwJMcyCiDGxXToRBB)
				{
					if (otKUbmqofcpYUIWlAktWbquuNmGP.qpaeJWVvtHPcBnTlzDouGsmvNVsP[RGwOTfpWxHlnpIIhaCYqLAlVgmgR].oQSZuTAmzEekmbFGYLrgfNASTMEKA(chQLExTTfOIcXNPemyDoDLdOreKL, rMcLAaXXrgixhZYxAfKMKzPumUBc))
					{
						nCjafjgCTFpnoXAGvdnehvyakDxib = otKUbmqofcpYUIWlAktWbquuNmGP.qpaeJWVvtHPcBnTlzDouGsmvNVsP[RGwOTfpWxHlnpIIhaCYqLAlVgmgR];
						xIuOxpQlTlPtwkniSHQHjIZRkLZO = 1;
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
			IEnumerator<TXrLvXzFHkdiHDsUNWmqJZRISLcv> IEnumerable<TXrLvXzFHkdiHDsUNWmqJZRISLcv>.GetEnumerator()
			{
				nxsfnDmLpIcrLoibyiPqGwnIleMVA nxsfnDmLpIcrLoibyiPqGwnIleMVA2;
				if (xIuOxpQlTlPtwkniSHQHjIZRkLZO == -2 && uasDAEhtFAKwwDlTRNGRuXvsBupCb == Environment.CurrentManagedThreadId)
				{
					xIuOxpQlTlPtwkniSHQHjIZRkLZO = 0;
					nxsfnDmLpIcrLoibyiPqGwnIleMVA2 = this;
				}
				else
				{
					nxsfnDmLpIcrLoibyiPqGwnIleMVA2 = new nxsfnDmLpIcrLoibyiPqGwnIleMVA(0);
					nxsfnDmLpIcrLoibyiPqGwnIleMVA2.OtKUbmqofcpYUIWlAktWbquuNmGP = OtKUbmqofcpYUIWlAktWbquuNmGP;
				}
				nxsfnDmLpIcrLoibyiPqGwnIleMVA2.chQLExTTfOIcXNPemyDoDLdOreKL = DVNQbCaEZKfBblqqyAFSkSNAjKmbb;
				nxsfnDmLpIcrLoibyiPqGwnIleMVA2.rMcLAaXXrgixhZYxAfKMKzPumUBc = ygBKYhkdffaqzCQpCZMYRqhOkQOe;
				return nxsfnDmLpIcrLoibyiPqGwnIleMVA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<TXrLvXzFHkdiHDsUNWmqJZRISLcv>)this).GetEnumerator();
			}
		}

		private List<TXrLvXzFHkdiHDsUNWmqJZRISLcv> qpaeJWVvtHPcBnTlzDouGsmvNVsP;

		public FqJCPmCvZYRgMafkaZzEUUYgDZCxA()
		{
			qpaeJWVvtHPcBnTlzDouGsmvNVsP = new List<TXrLvXzFHkdiHDsUNWmqJZRISLcv>();
		}

		public void vXwDOSiCpxcAbDfdthDiEVrdfaHQb(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count;
			for (int i = 0; i < count; i++)
			{
				if (qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].oQSZuTAmzEekmbFGYLrgfNASTMEKA(P_0, tfMOgURNaeQFUFZvTCNXlXFFVyCd.Exact))
				{
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].nbJuxRnnNcDeROnqBEAyrvjNLNiN = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].fLxNoUIKvqEkwtdiGJEXrwpglCq = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].zAnHkraKWYibqwSQhFSCOVkcLbTZA = P_0.ePRUxDMNyiMTwUPuGAuEHagZYnTL;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].kjEtJrjOKGctnTxXSGgjROqHisWd = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].thCLPskHIlKjOAnGvgrUfvRzgwdqA = P_0.sRqdccCqHIdlZZxjlMJpGGALMTXu;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].GYisIznaQdAbcJYxQalVpIfdiKVDb = P_0.cYKFgMwUErcyAyvJljXcHZiszjtdA;
					qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].dLxftwRyjdyozlktNItujupfaLmg = P_0.lDpdRWDWZUtgDsssjLjkHetIIjZsB;
					jLQGHwbqTIwlsyOXfmRDkjGwklWy(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, i);
					return;
				}
			}
			qpaeJWVvtHPcBnTlzDouGsmvNVsP.Add(new TXrLvXzFHkdiHDsUNWmqJZRISLcv
			{
				nbJuxRnnNcDeROnqBEAyrvjNLNiN = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId,
				fLxNoUIKvqEkwtdiGJEXrwpglCq = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid,
				zAnHkraKWYibqwSQhFSCOVkcLbTZA = P_0.ePRUxDMNyiMTwUPuGAuEHagZYnTL,
				kjEtJrjOKGctnTxXSGgjROqHisWd = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId,
				thCLPskHIlKjOAnGvgrUfvRzgwdqA = P_0.sRqdccCqHIdlZZxjlMJpGGALMTXu,
				GYisIznaQdAbcJYxQalVpIfdiKVDb = P_0.cYKFgMwUErcyAyvJljXcHZiszjtdA,
				dLxftwRyjdyozlktNItujupfaLmg = P_0.lDpdRWDWZUtgDsssjLjkHetIIjZsB
			});
			jLQGHwbqTIwlsyOXfmRDkjGwklWy(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid, qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count - 1);
		}

		public bool wSWTdVFPINiBjHhtvvXFJTjXdnew(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, tfMOgURNaeQFUFZvTCNXlXFFVyCd P_1)
		{
			int count = qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count;
			for (int i = 0; i < count; i++)
			{
				if (qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].oQSZuTAmzEekmbFGYLrgfNASTMEKA(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(nxsfnDmLpIcrLoibyiPqGwnIleMVA))]
		public IEnumerable<TXrLvXzFHkdiHDsUNWmqJZRISLcv> NcMjXDGbaqIORCbHQwESeGNILMpzB(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, tfMOgURNaeQFUFZvTCNXlXFFVyCd P_1)
		{
			return new nxsfnDmLpIcrLoibyiPqGwnIleMVA(-2)
			{
				OtKUbmqofcpYUIWlAktWbquuNmGP = this,
				DVNQbCaEZKfBblqqyAFSkSNAjKmbb = P_0,
				ygBKYhkdffaqzCQpCZMYRqhOkQOe = P_1
			};
		}

		private void jLQGHwbqTIwlsyOXfmRDkjGwklWy(int P_0, Guid P_1, int P_2)
		{
			for (int num = qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (qpaeJWVvtHPcBnTlzDouGsmvNVsP[num].nbJuxRnnNcDeROnqBEAyrvjNLNiN == P_0 || qpaeJWVvtHPcBnTlzDouGsmvNVsP[num].fLxNoUIKvqEkwtdiGJEXrwpglCq == P_1))
				{
					qpaeJWVvtHPcBnTlzDouGsmvNVsP.RemoveAt(num);
				}
			}
		}

		public virtual string JBsFFCXXpijgUKWidNVcPenrZZhn()
		{
			string text = "";
			text = text + "Joystick records: " + qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count + "\n";
			for (int i = 0; i < qpaeJWVvtHPcBnTlzDouGsmvNVsP.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + qpaeJWVvtHPcBnTlzDouGsmvNVsP[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class ZDTygwMKxHIlJpRQAAQVGWaHqNgG
	{
		public jeVhmjjeVKqMykpAYwlbuYKFcBZI HJtHGuEIrHduWmhiKFRVyjpBGmkiA;

		public RCbrBLDngHgaSCZnWWTNJSaCQXlM VipChJKODuaGWgfYJYHbtGtbDowCc;

		public bool IxmTsDVcfiLtHMuslgoaSaONXsns
		{
			get
			{
				if (HJtHGuEIrHduWmhiKFRVyjpBGmkiA != null)
				{
					return VipChJKODuaGWgfYJYHbtGtbDowCc != null;
				}
				return false;
			}
		}

		public ZDTygwMKxHIlJpRQAAQVGWaHqNgG(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, RCbrBLDngHgaSCZnWWTNJSaCQXlM P_1)
		{
			HJtHGuEIrHduWmhiKFRVyjpBGmkiA = P_0;
			VipChJKODuaGWgfYJYHbtGtbDowCc = P_1;
		}

		public static List<RCbrBLDngHgaSCZnWWTNJSaCQXlM> JlKhmciiPcQpKnADNJSyCidFlRpm(List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> P_0)
		{
			if (P_0 == null)
			{
				return new List<RCbrBLDngHgaSCZnWWTNJSaCQXlM>();
			}
			List<RCbrBLDngHgaSCZnWWTNJSaCQXlM> list = new List<RCbrBLDngHgaSCZnWWTNJSaCQXlM>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].IxmTsDVcfiLtHMuslgoaSaONXsns)
				{
					list.Add(P_0[i].VipChJKODuaGWgfYJYHbtGtbDowCc);
				}
			}
			return list;
		}
	}

	private class EtiuJEkODcANDphntCLjajvngKlL
	{
		public NQheDZtFtwtPwXhJJkvldbrPekPu xWCVrUIeLejCkIecKEnasvfWChRPA;

		public EtiuJEkODcANDphntCLjajvngKlL(NQheDZtFtwtPwXhJJkvldbrPekPu P_0)
		{
			xWCVrUIeLejCkIecKEnasvfWChRPA = P_0;
		}
	}

	private class eFtEINTqxVMHJUvyZNkdaRveEJoEA
	{
		private XzsdhqbOQGnkYvfrQJnOJeguHFpIA.fbZYGPXeQUCCeKJRGlNFGjVjrawQA YPlHVeoewtTrYuLlSSqwaqwVOjWM;

		private XzsdhqbOQGnkYvfrQJnOJeguHFpIA.cpKVsLhBuqfJuOPIqRsTyorbWWA UNNvVnRqmJpZjFpGHHwAgBTtdHiGA;

		private NativeBuffer mEBdWzfNgJVBCNkPvfqzaFnBPUXFA;

		private int BfJcxWaanFefMjTVLsjlzICSUsKU;

		public eFtEINTqxVMHJUvyZNkdaRveEJoEA()
		{
			YPlHVeoewtTrYuLlSSqwaqwVOjWM = new XzsdhqbOQGnkYvfrQJnOJeguHFpIA.fbZYGPXeQUCCeKJRGlNFGjVjrawQA
			{
				zRCNyjGTokjXoymncOEAXdsSTRRr = (uint)Marshal.SizeOf(typeof(XzsdhqbOQGnkYvfrQJnOJeguHFpIA.fbZYGPXeQUCCeKJRGlNFGjVjrawQA)),
				voUCMKIJzWuPNCamvczxxFQiKHyIb = true,
				vlZaBWFHpNPjiROAdmFaBoCJzyEaA = true,
				hLTxiIUCRFGkginJYnUbltiPWIcxA = false,
				zqgalkmpGaeJELjsbqKTcPRlbjmFA = true,
				weveaACLAAKoBlhXZaeoeyAFacZC = IntPtr.Zero
			};
			UNNvVnRqmJpZjFpGHHwAgBTtdHiGA = XzsdhqbOQGnkYvfrQJnOJeguHFpIA.cpKVsLhBuqfJuOPIqRsTyorbWWA.JHubdFHKPdYMSdgAEfuSXpMMYIpwA();
			mEBdWzfNgJVBCNkPvfqzaFnBPUXFA = new NativeBuffer((int)UNNvVnRqmJpZjFpGHHwAgBTtdHiGA.oTEIgKlPvMbTLnMDPUPMxVkSVFdm);
			mEBdWzfNgJVBCNkPvfqzaFnBPUXFA.Write(UNNvVnRqmJpZjFpGHHwAgBTtdHiGA.oTEIgKlPvMbTLnMDPUPMxVkSVFdm, 0);
		}

		public bool inmEgjqVIWdhnZZCmNekUCAKqScg()
		{
			int num = VKKrrUGGDtpiShEDzJmgyeIgeCAh();
			if (num == BfJcxWaanFefMjTVLsjlzICSUsKU)
			{
				return false;
			}
			BfJcxWaanFefMjTVLsjlzICSUsKU = num;
			return true;
		}

		public void ahvsZElbddBgfHuMOmHmoFPNrXqSA(int P_0)
		{
			BfJcxWaanFefMjTVLsjlzICSUsKU = P_0;
		}

		private int VKKrrUGGDtpiShEDzJmgyeIgeCAh()
		{
			try
			{
				return CDjRvZGPLAcfDJlYHLOLilziojJi.RzApAWgVPFZPOPEldXCnzxiBJxGf(ref YPlHVeoewtTrYuLlSSqwaqwVOjWM, mEBdWzfNgJVBCNkPvfqzaFnBPUXFA);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum EFfdpmrEFpCiZgNjMHoExeNrkBgbb
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

	private const rxoCQyLeXikLCiACyHfjyDszEnHc fjVPJOErwCHQXRutWbInmEuaeEyc = rxoCQyLeXikLCiACyHfjyDszEnHc.GameControl;

	private const NcIhHWHlNfssiPdJoxBFHDvPFCIoA NPpRbXJCBTCjmIcoqOFBdORtuADpA = NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly;

	private IntPtr NGefODMsgIiKrfyQVhJIEExaPxAoA;

	private MWxKeWPstqLsHiooDoLaaAhoicECA dulIhQUgDTgZJzdbpiHiHbVbRzqTA;

	private List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> UWedYxDfzcKvhEXkLYENOpHgckCVA;

	private int gAZVqUmaFLgPuERAItRBQbtKLCAJb;

	private FqJCPmCvZYRgMafkaZzEUUYgDZCxA YAoVQkghcHABGOKZqCqplummxxuB;

	private bool yUuxiqUmkXNNltnDSoFFWGFibMKJA;

	private QdLLDjUvbeJHvwTMuBtdvfsbPLHe HvCKjtqWKRidotSktQHBhaFWhNMC;

	private UpdateLoopSetting mQyPtcBgciUJuhXAlsgemJiyhUJb;

	private Action<int, ControllerDataUpdater> uboeCBJcUeKQpcQbddiMhAZMjDoHB;

	private PlatformInputManager osIylOMMUSRHNXwpDIDzyXzaBgnX;

	private TimerRealTime MIhfUDTWFpVeKrMPMemuvForebxcA;

	private global::xgduufxNbOgmNamvRoWQleTIUVZc<bool> AhhmIduqgjyfTJdAkDbqUobWEFYP;

	private eFtEINTqxVMHJUvyZNkdaRveEJoEA KhPpzbLIsyFQjlnCdtQNSiMuAeyV;

	private int odglvfOxJIRwiWQsRFZuyyKBLnSo;

	private int nPiFhuhLiWtMOvnyafYgdLCilJZG;

	private global::xgduufxNbOgmNamvRoWQleTIUVZc<List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG>> PvIDaoAgPJfLPewqeVcAppmOHuFpB;

	private readonly object RkFVkZQFgzGPnxfTclAKsGJnbOxf = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> dKnqFRwuGvyIsfvxQpgubPpdDRvA;

	private Func<int> MbpaNBFfIsCNOTJIByUMkJoXcGyYA;

	QdLLDjUvbeJHvwTMuBtdvfsbPLHe AOnTCMyhWiFBDPnpOkhOOLpWAYMC.JcpvMwtROEesznlBjbRpiuPHRFQjA
	{
		get
		{
			return HvCKjtqWKRidotSktQHBhaFWhNMC;
		}
		set
		{
			HvCKjtqWKRidotSktQHBhaFWhNMC = hvCKjtqWKRidotSktQHBhaFWhNMC;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => gAZVqUmaFLgPuERAItRBQbtKLCAJb;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => osIylOMMUSRHNXwpDIDzyXzaBgnX;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => new InputSourceWrapper<MWxKeWPstqLsHiooDoLaaAhoicECA>(dulIhQUgDTgZJzdbpiHiHbVbRzqTA);

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => InputSource.DirectInput;

	public zkrnmDbTDQfoKXIpNpnFtnoyWKRE(UpdateLoopSetting P_0, QdLLDjUvbeJHvwTMuBtdvfsbPLHe P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			mQyPtcBgciUJuhXAlsgemJiyhUJb = P_0;
			HvCKjtqWKRidotSktQHBhaFWhNMC = P_1;
			NGefODMsgIiKrfyQVhJIEExaPxAoA = P_2;
			dKnqFRwuGvyIsfvxQpgubPpdDRvA = P_3;
			MbpaNBFfIsCNOTJIByUMkJoXcGyYA = P_4;
			osIylOMMUSRHNXwpDIDzyXzaBgnX = this;
			dulIhQUgDTgZJzdbpiHiHbVbRzqTA = new MWxKeWPstqLsHiooDoLaaAhoicECA();
			uboeCBJcUeKQpcQbddiMhAZMjDoHB = UpdateControllerData;
			KhPpzbLIsyFQjlnCdtQNSiMuAeyV = new eFtEINTqxVMHJUvyZNkdaRveEJoEA();
			AhhmIduqgjyfTJdAkDbqUobWEFYP = new global::xgduufxNbOgmNamvRoWQleTIUVZc<bool>(true, ZcRgntENqZnrvWYNZcNdOogkQoP);
			PvIDaoAgPJfLPewqeVcAppmOHuFpB = new global::xgduufxNbOgmNamvRoWQleTIUVZc<List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG>>(true, () => KqGQEOxNzLxvkmaVMMvTtQnQrACQ());
			GAehcfkFQrnbmKCnNqdtXhwJbYxKA();
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
		YAoVQkghcHABGOKZqCqplummxxuB = new FqJCPmCvZYRgMafkaZzEUUYgDZCxA();
		MIhfUDTWFpVeKrMPMemuvForebxcA = new TimerRealTime(1.0);
		MIhfUDTWFpVeKrMPMemuvForebxcA.Start();
		wIXKRHKivAiQqJGsUmDmWXfsjxtG();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		lTdbCGjiLOFCUsEtTfOOhIkvwLVBb();
		IyLnxsbyQIeSUrUVufAmQjsiMhrF();
		BwqVLROcIpHoBbLSjbnGzfAXPkxU();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (PvIDaoAgPJfLPewqeVcAppmOHuFpB != null)
		{
			PvIDaoAgPJfLPewqeVcAppmOHuFpB.FOYyubOeaZiQjSwliSBfnAKTjoxy();
		}
		if (AhhmIduqgjyfTJdAkDbqUobWEFYP != null)
		{
			AhhmIduqgjyfTJdAkDbqUobWEFYP.FOYyubOeaZiQjSwliSBfnAKTjoxy();
		}
		if (UWedYxDfzcKvhEXkLYENOpHgckCVA == null)
		{
			return;
		}
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			for (int i = 0; i < UWedYxDfzcKvhEXkLYENOpHgckCVA.Count; i++)
			{
				if (UWedYxDfzcKvhEXkLYENOpHgckCVA[i] != null)
				{
					UWedYxDfzcKvhEXkLYENOpHgckCVA[i].GsyJCpdzAfoNjqoIfSkzwJTqBsbp();
					UWedYxDfzcKvhEXkLYENOpHgckCVA[i].UELVAUfPPbBnyAVsQgKaOvthgOcF();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return uboeCBJcUeKQpcQbddiMhAZMjDoHB;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			for (int i = 0; i < gAZVqUmaFLgPuERAItRBQbtKLCAJb; i++)
			{
				if (UWedYxDfzcKvhEXkLYENOpHgckCVA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId == inputManagerId)
				{
					UWedYxDfzcKvhEXkLYENOpHgckCVA[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		yUuxiqUmkXNNltnDSoFFWGFibMKJA = true;
		MIhfUDTWFpVeKrMPMemuvForebxcA.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		yUuxiqUmkXNNltnDSoFFWGFibMKJA = true;
		MIhfUDTWFpVeKrMPMemuvForebxcA.Start();
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

	private void lTdbCGjiLOFCUsEtTfOOhIkvwLVBb()
	{
		if (AhhmIduqgjyfTJdAkDbqUobWEFYP.YibZslQejybegMCwglLcbMXjXREh)
		{
			if (AhhmIduqgjyfTJdAkDbqUobWEFYP.QPPcnXHfsXuMerWBTRMGFYgQdvAf() && !MIhfUDTWFpVeKrMPMemuvForebxcA.running && !PvIDaoAgPJfLPewqeVcAppmOHuFpB.YibZslQejybegMCwglLcbMXjXREh)
			{
				if (AhhmIduqgjyfTJdAkDbqUobWEFYP.IOFddxkEPgJuSBEVGkKcRMAZvCAm)
				{
					yUuxiqUmkXNNltnDSoFFWGFibMKJA = true;
				}
				MIhfUDTWFpVeKrMPMemuvForebxcA.Start();
			}
		}
		else if (!MIhfUDTWFpVeKrMPMemuvForebxcA.running)
		{
			MIhfUDTWFpVeKrMPMemuvForebxcA.Start();
		}
		else if (MIhfUDTWFpVeKrMPMemuvForebxcA.Update())
		{
			AhhmIduqgjyfTJdAkDbqUobWEFYP.gVRMdQUdMoWjfTCoTwRPEnVbhauCA();
		}
	}

	private List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> KqGQEOxNzLxvkmaVMMvTtQnQrACQ()
	{
		List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> list = new List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG>();
		IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> list2 = lxFwCIqSSBicbSnsafHpwiILhnfh();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				RCbrBLDngHgaSCZnWWTNJSaCQXlM rCbrBLDngHgaSCZnWWTNJSaCQXlM = list2[i];
				Guid vooZCRenfowGvkjwBdPFIBfsSrucA = rCbrBLDngHgaSCZnWWTNJSaCQXlM.vooZCRenfowGvkjwBdPFIBfsSrucA;
				NQheDZtFtwtPwXhJJkvldbrPekPu nQheDZtFtwtPwXhJJkvldbrPekPu = new NQheDZtFtwtPwXhJJkvldbrPekPu(dulIhQUgDTgZJzdbpiHiHbVbRzqTA, vooZCRenfowGvkjwBdPFIBfsSrucA);
				weGHcRsXsOpHfajVBjLjigiUhOkx weGHcRsXsOpHfajVBjLjigiUhOkx2 = nQheDZtFtwtPwXhJJkvldbrPekPu.SjKSPnBOTzwGcHPolOscJNmhgYScA;
				if (HvCKjtqWKRidotSktQHBhaFWhNMC == null)
				{
					goto IL_00bd;
				}
				string text = rCbrBLDngHgaSCZnWWTNJSaCQXlM.HHnyOAQmqKRfIepNrbhokTmxpHaK.ToString();
				if (!HvCKjtqWKRidotSktQHBhaFWhNMC.oIWBrivfGEOfRaGKIAwfExVZptXiA(weGHcRsXsOpHfajVBjLjigiUhOkx2.SeCSvIFISGlfYwHVYQJAKxfxrBCv, StringTools.SanitizeDeviceString(rCbrBLDngHgaSCZnWWTNJSaCQXlM.QfDOMnZwbpIBMfcjGivHtILHKTYC), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (CXvYylkBCMAyQJmbdwWcNwlniCRQ.aqVtrsmgfbIWDfuGSqJTgQjhAbXU(InputSource.DirectInput, (ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.taJdSoHJrTOxUaKAjOtwuzMwNzIpA, (ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.alqObbwDKJKsSylNOkbghYMtuDvC, (CXvYylkBCMAyQJmbdwWcNwlniCRQ.eNsmKaDtaGBZkXaGAaBKiAgCvWiC)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(weGHcRsXsOpHfajVBjLjigiUhOkx2.SeCSvIFISGlfYwHVYQJAKxfxrBCv)) ? MiscTools.CreateGuidHashSHA256(weGHcRsXsOpHfajVBjLjigiUhOkx2.SeCSvIFISGlfYwHVYQJAKxfxrBCv) : rCbrBLDngHgaSCZnWWTNJSaCQXlM.vooZCRenfowGvkjwBdPFIBfsSrucA);
				bool flag = false;
				lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
				{
					if (UWedYxDfzcKvhEXkLYENOpHgckCVA != null)
					{
						for (int j = 0; j < UWedYxDfzcKvhEXkLYENOpHgckCVA.Count; j++)
						{
							if (UWedYxDfzcKvhEXkLYENOpHgckCVA[j] != null && UWedYxDfzcKvhEXkLYENOpHgckCVA[j].ahmCgmGaZyJQLhxTMBXLRGnLmattA == guid)
							{
								nQheDZtFtwtPwXhJJkvldbrPekPu = UWedYxDfzcKvhEXkLYENOpHgckCVA[j].GXuNWUYCzKFxRsBeKXwezaGESNBD.fIOCzGUswytRpcDosvzICbfreiTFA;
								flag = true;
								break;
							}
						}
					}
				}
				jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = new jeVhmjjeVKqMykpAYwlbuYKFcBZI(new TpQKeSuTJVwsGafeKVECzGzgftvp(nQheDZtFtwtPwXhJJkvldbrPekPu, mQyPtcBgciUJuhXAlsgemJiyhUJb), dKnqFRwuGvyIsfvxQpgubPpdDRvA);
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.HCCJQefcSZZlFgBsCXvbytYDfOMk = rCbrBLDngHgaSCZnWWTNJSaCQXlM;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.GnAqclayIcfZhVjKoAxXhldFNqmy = rCbrBLDngHgaSCZnWWTNJSaCQXlM.GdeEloThXcRPInxXOOLEkIyljMrj;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.ahmCgmGaZyJQLhxTMBXLRGnLmattA = guid;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.rLQNOveJWLjLEwqpLbuPFtgarwVMA = StringTools.SanitizeDeviceString(rCbrBLDngHgaSCZnWWTNJSaCQXlM.QfDOMnZwbpIBMfcjGivHtILHKTYC);
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.AZRFIDJSVSoIDaPHSODkqaSusjbh = rCbrBLDngHgaSCZnWWTNJSaCQXlM.HHnyOAQmqKRfIepNrbhokTmxpHaK;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.LlaPBWBeBvHXfApubEqrJSQIlPZDb = (EFfdpmrEFpCiZgNjMHoExeNrkBgbb)rCbrBLDngHgaSCZnWWTNJSaCQXlM.brofLJGMGjbNcpQJiXRSFspoutUU;
				TrOMzzgFBdVbBTLxdpuPjgdAdiFJA trOMzzgFBdVbBTLxdpuPjgdAdiFJA = nQheDZtFtwtPwXhJJkvldbrPekPu.gTMAPzeAKWLVPWzSMtAZlxaTsatl;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.McWEAOKnCllDRdqTCDTMqVbnZgiCb = weGHcRsXsOpHfajVBjLjigiUhOkx2.alqObbwDKJKsSylNOkbghYMtuDvC;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.EYNcBmsHOWCHAuCnOnodeQelcjRQ = false;
				try
				{
					jeVhmjjeVKqMykpAYwlbuYKFcBZI2.IUKCECULrWNrucKVEkOBwYbYaYge = weGHcRsXsOpHfajVBjLjigiUhOkx2.LdZRgtsMwYBEFoqkVXdPisfRzzhG;
				}
				catch (Exception)
				{
					jeVhmjjeVKqMykpAYwlbuYKFcBZI2.IUKCECULrWNrucKVEkOBwYbYaYge = 0;
				}
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.sRqdccCqHIdlZZxjlMJpGGALMTXu = trOMzzgFBdVbBTLxdpuPjgdAdiFJA.zjoRIGrKpTucrUYjNriVpXIajHDV;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.cYKFgMwUErcyAyvJljXcHZiszjtdA = trOMzzgFBdVbBTLxdpuPjgdAdiFJA.vRwGtTDXnbGJiUVbNyQcGtUoPLlM;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.lDpdRWDWZUtgDsssjLjkHetIIjZsB = trOMzzgFBdVbBTLxdpuPjgdAdiFJA.QBlDxugBsTcxwPpepXPQzCNfaXdT;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.konmlsWVMmJQikKjfoFfwZmRhdQI = new DirectInputControllerExtension(rCbrBLDngHgaSCZnWWTNJSaCQXlM, nQheDZtFtwtPwXhJJkvldbrPekPu);
				VhkUBNqAwwbIuoAByDXTDzUzWQihA(jeVhmjjeVKqMykpAYwlbuYKFcBZI2, weGHcRsXsOpHfajVBjLjigiUhOkx2, out jeVhmjjeVKqMykpAYwlbuYKFcBZI2.OgwXAwobpzAIatBwTWaXapiQgMhq);
				try
				{
					string text2;
					try
					{
						text2 = weGHcRsXsOpHfajVBjLjigiUhOkx2.mkwLTeJuqReQJFPNoVUtjGIZGUMc;
					}
					catch
					{
						text2 = jeVhmjjeVKqMykpAYwlbuYKFcBZI2.rLQNOveJWLjLEwqpLbuPFtgarwVMA;
					}
					if (yuCKQFXxIbGVfdbLqamQXXBrbsWv.ieoQSBRMWiILLpkZngbtwJNxbhUb((ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.taJdSoHJrTOxUaKAjOtwuzMwNzIpA, (ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.alqObbwDKJKsSylNOkbghYMtuDvC, text2) && yuCKQFXxIbGVfdbLqamQXXBrbsWv.gQqAjpehOxszlasgHzZfclUwZPkg((ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.taJdSoHJrTOxUaKAjOtwuzMwNzIpA, (ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.alqObbwDKJKsSylNOkbghYMtuDvC, text2, out var num, out var num2, out var num3))
					{
						jeVhmjjeVKqMykpAYwlbuYKFcBZI2.GXuNWUYCzKFxRsBeKXwezaGESNBD.WcLmkoOXiFBtHEwEhCrwGBbTTUxQ(num, num2, num3, yuCKQFXxIbGVfdbLqamQXXBrbsWv.RhrqpzgUXHTUbtJyiIhiPpyNXwWl((ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.taJdSoHJrTOxUaKAjOtwuzMwNzIpA, (ushort)weGHcRsXsOpHfajVBjLjigiUhOkx2.alqObbwDKJKsSylNOkbghYMtuDvC, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<qpzCcdMUThEhWJJvcjvJGTijXwxeb> list3 = nQheDZtFtwtPwXhJJkvldbrPekPu.LLsViclNqjIKNOhMNrWJbgYLeJGu();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].KZVgksxHjhfZqLxwYnjTaPVmMueh.QWXGfOKoRPqaKxdTGIdQAIsbirqIB & WVKLnHnnIsWeFoDkVmYeRlTOGpEs.Axis) != WVKLnHnnIsWeFoDkVmYeRlTOGpEs.All)
							{
								nQheDZtFtwtPwXhJJkvldbrPekPu.SjKSPnBOTzwGcHPolOscJNmhgYScA.TOFrNDPDewPCUZJjeaFWmDqyeJRn = new piquBkdKfEhtpTjFPXYUqGEHvoRv(-65535, 65535);
							}
						}
					}
					nQheDZtFtwtPwXhJJkvldbrPekPu.SjKSPnBOTzwGcHPolOscJNmhgYScA.nDbMqwYeNnjYsYqaOTiQyPiqRxpo = dtpceejJRHqCdGrGeyqneYJkRCmIA.Absolute;
					nQheDZtFtwtPwXhJJkvldbrPekPu.snRjOePBRFLdroAYSDqraGtNGUDqA(NGefODMsgIiKrfyQVhJIEExaPxAoA, IfnLjTFPCEtFMCzXZNSQjTzZiQUE.NonExclusive | IfnLjTFPCEtFMCzXZNSQjTzZiQUE.Background);
					nQheDZtFtwtPwXhJJkvldbrPekPu.oBlOMMyTLkQVgySBVdHMQILwEDKk();
				}
				list.Add(new ZDTygwMKxHIlJpRQAAQVGWaHqNgG(jeVhmjjeVKqMykpAYwlbuYKFcBZI2, rCbrBLDngHgaSCZnWWTNJSaCQXlM));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void wIXKRHKivAiQqJGsUmDmWXfsjxtG()
	{
		MFchGLbBlvdIVQMIaWEclbEWHnddA(KqGQEOxNzLxvkmaVMMvTtQnQrACQ());
	}

	private void MFchGLbBlvdIVQMIaWEclbEWHnddA(List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> P_0)
	{
		List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> list = new List<jeVhmjjeVKqMykpAYwlbuYKFcBZI>();
		odglvfOxJIRwiWQsRFZuyyKBLnSo = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].IxmTsDVcfiLtHMuslgoaSaONXsns)
			{
				continue;
			}
			try
			{
				jeVhmjjeVKqMykpAYwlbuYKFcBZI hJtHGuEIrHduWmhiKFRVyjpBGmkiA = P_0[i].HJtHGuEIrHduWmhiKFRVyjpBGmkiA;
				hJtHGuEIrHduWmhiKFRVyjpBGmkiA.ItUoqNaTqtLPNiuLiGxJwSKIgCqV();
				if (hJtHGuEIrHduWmhiKFRVyjpBGmkiA.jmRHHuPTRPjBwLMzuxnzDYVkGwJM)
				{
					odglvfOxJIRwiWQsRFZuyyKBLnSo++;
				}
				list.Add(hJtHGuEIrHduWmhiKFRVyjpBGmkiA);
			}
			catch (Exception)
			{
			}
		}
		KhPpzbLIsyFQjlnCdtQNSiMuAeyV.ahvsZElbddBgfHuMOmHmoFPNrXqSA(odglvfOxJIRwiWQsRFZuyyKBLnSo);
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> uWedYxDfzcKvhEXkLYENOpHgckCVA = UWedYxDfzcKvhEXkLYENOpHgckCVA;
			int num2 = gAZVqUmaFLgPuERAItRBQbtKLCAJb;
			int count = list.Count;
			eijagtkojfSHHpNdxIOwdNbDITNUb(num2, count, uWedYxDfzcKvhEXkLYENOpHgckCVA, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			iQQMVnaDsyVNLaJGPZLHKLEdbhhx(uWedYxDfzcKvhEXkLYENOpHgckCVA, list, false);
			iQQMVnaDsyVNLaJGPZLHKLEdbhhx(list, uWedYxDfzcKvhEXkLYENOpHgckCVA, true);
			xHcdBftLooanjNojHGEUaOIacsvGb(list, uWedYxDfzcKvhEXkLYENOpHgckCVA);
			UWedYxDfzcKvhEXkLYENOpHgckCVA = list;
			gAZVqUmaFLgPuERAItRBQbtKLCAJb = list.Count;
		}
	}

	private void VhkUBNqAwwbIuoAByDXTDzUzWQihA(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, weGHcRsXsOpHfajVBjLjigiUhOkx P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = xUPCxrzhBiksftNMbGxZgbEwrnkFA.EAscRlbCrskDTfIDNSvjOShdypfOA(P_1.SeCSvIFISGlfYwHVYQJAKxfxrBCv);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			ZrLZfadkjQbKLybIbLvPGHmrChbIA zrLZfadkjQbKLybIbLvPGHmrChbIA = CDjRvZGPLAcfDJlYHLOLilziojJi.KwkZSYqYRvDOpOiTVOWhcBlivQvt(text.ToLower(CultureInfo.InvariantCulture));
			if (zrLZfadkjQbKLybIbLvPGHmrChbIA != null)
			{
				P_0.jmRHHuPTRPjBwLMzuxnzDYVkGwJM = zrLZfadkjQbKLybIbLvPGHmrChbIA.JZxRdWZmWclwVrJbwKRYmrYUhHmA;
				P_0.CkJQNRDhDAIoOKtgaHxkkQsWdHbP = zrLZfadkjQbKLybIbLvPGHmrChbIA.RSlrkwpJCEGMQUnFwHKeqwZpcrjL;
				P_2 = CXvYylkBCMAyQJmbdwWcNwlniCRQ.nvNEfzMvLwfTFwCEQimjdXWCnqWqA(zrLZfadkjQbKLybIbLvPGHmrChbIA, P_0.AZRFIDJSVSoIDaPHSODkqaSusjbh, P_0.rLQNOveJWLjLEwqpLbuPFtgarwVMA, P_0.CkJQNRDhDAIoOKtgaHxkkQsWdHbP);
				zrLZfadkjQbKLybIbLvPGHmrChbIA.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void BwqVLROcIpHoBbLSjbnGzfAXPkxU()
	{
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			for (int i = 0; i < gAZVqUmaFLgPuERAItRBQbtKLCAJb; i++)
			{
				try
				{
					jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = UWedYxDfzcKvhEXkLYENOpHgckCVA[i];
					if (jeVhmjjeVKqMykpAYwlbuYKFcBZI2 != null && jeVhmjjeVKqMykpAYwlbuYKFcBZI2.QPsubDWsRfmCGZivbuRCMAOpBFAw() && (JcpvMwtROEesznlBjbRpiuPHRFQjA == null || !jeVhmjjeVKqMykpAYwlbuYKFcBZI2.EYNcBmsHOWCHAuCnOnodeQelcjRQ))
					{
						jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> lxFwCIqSSBicbSnsafHpwiILhnfh()
	{
		try
		{
			IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> list = dulIhQUgDTgZJzdbpiHiHbVbRzqTA.jmFjCvWVKtqWJbZYtHCFLKPdBXpCA(rxoCQyLeXikLCiACyHfjyDszEnHc.GameControl, NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly);
			nPiFhuhLiWtMOvnyafYgdLCilJZG = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			nPiFhuhLiWtMOvnyafYgdLCilJZG = 0;
			return EmptyObjects<RCbrBLDngHgaSCZnWWTNJSaCQXlM>.EmptyReadOnlyIListT;
		}
	}

	private void GAehcfkFQrnbmKCnNqdtXhwJbYxKA()
	{
		dulIhQUgDTgZJzdbpiHiHbVbRzqTA.VRQuRdNxlVVMaICngcvwVWtCVejy();
	}

	private void eijagtkojfSHHpNdxIOwdNbDITNUb(int P_0, int P_1, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_2, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(jeVhmjjeVKqMykpAYwlbuYKFcBZI.JjWOMMmMaAJGZGCmgpRtFLTznopjb);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			ZoohLAMiSkrorLVhGBFhHGXlIvwM(P_1, P_3, P_0, P_2, FqJCPmCvZYRgMafkaZzEUUYgDZCxA.tfMOgURNaeQFUFZvTCNXlXFFVyCd.Exact);
		}
		bqavUHdKHCiGpEBDlEFfALBTiuQz(P_1, P_3, FqJCPmCvZYRgMafkaZzEUUYgDZCxA.tfMOgURNaeQFUFZvTCNXlXFFVyCd.Exact);
		for (int i = 0; i < P_1; i++)
		{
			jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = P_3[i];
			if (jeVhmjjeVKqMykpAYwlbuYKFcBZI2 != null && jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId < 0)
			{
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = YJxCChqPRUIkLGqZHsMfiYjGuGrC(P_3);
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = MbpaNBFfIsCNOTJIByUMkJoXcGyYA();
				YAoVQkghcHABGOKZqCqplummxxuB.vXwDOSiCpxcAbDfdthDiEVrdfaHQb(jeVhmjjeVKqMykpAYwlbuYKFcBZI2);
			}
		}
		P_3.Sort(jeVhmjjeVKqMykpAYwlbuYKFcBZI.QcIejBYIKziEOWLLwCOntRwhUMLW);
	}

	private void cnyLIZfWYxKwTjXjHRBMHyxbbWKb(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0, int P_1, int P_2)
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

	private bool LVqgXnWqEXjdVIUOgLessCQqYLvoA(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0, int P_1)
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

	private int YJxCChqPRUIkLGqZHsMfiYjGuGrC(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0)
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

	private bool jZfPFKDWplCOjPIMlMHBvBRccTbiA(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0, int P_1)
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

	private void ZoohLAMiSkrorLVhGBFhHGXlIvwM(int P_0, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_1, int P_2, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_3, FqJCPmCvZYRgMafkaZzEUUYgDZCxA.tfMOgURNaeQFUFZvTCNXlXFFVyCd P_4)
	{
		int num = ((P_4 != FqJCPmCvZYRgMafkaZzEUUYgDZCxA.tfMOgURNaeQFUFZvTCNXlXFFVyCd.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = P_1[i];
			if (jeVhmjjeVKqMykpAYwlbuYKFcBZI2 == null || jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI3 = P_3[j];
				if (jeVhmjjeVKqMykpAYwlbuYKFcBZI3 != null && !jZfPFKDWplCOjPIMlMHBvBRccTbiA(P_1, jeVhmjjeVKqMykpAYwlbuYKFcBZI3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId) && jeVhmjjeVKqMykpAYwlbuYKFcBZI2.PwQgNNeFrnYIyLxDMglyqlwBJLHX(jeVhmjjeVKqMykpAYwlbuYKFcBZI3) >= num)
				{
					jeVhmjjeVKqMykpAYwlbuYKFcBZI2.bSpWYVvVAqldnaNYHbHouoiMBajIA(jeVhmjjeVKqMykpAYwlbuYKFcBZI3);
					YAoVQkghcHABGOKZqCqplummxxuB.vXwDOSiCpxcAbDfdthDiEVrdfaHQb(jeVhmjjeVKqMykpAYwlbuYKFcBZI2);
				}
			}
		}
	}

	private void bqavUHdKHCiGpEBDlEFfALBTiuQz(int P_0, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_1, FqJCPmCvZYRgMafkaZzEUUYgDZCxA.tfMOgURNaeQFUFZvTCNXlXFFVyCd P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = P_1[i];
			if (jeVhmjjeVKqMykpAYwlbuYKFcBZI2 == null || jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId >= 0)
			{
				continue;
			}
			FqJCPmCvZYRgMafkaZzEUUYgDZCxA.TXrLvXzFHkdiHDsUNWmqJZRISLcv tXrLvXzFHkdiHDsUNWmqJZRISLcv = null;
			foreach (FqJCPmCvZYRgMafkaZzEUUYgDZCxA.TXrLvXzFHkdiHDsUNWmqJZRISLcv item in YAoVQkghcHABGOKZqCqplummxxuB.NcMjXDGbaqIORCbHQwESeGNILMpzB(jeVhmjjeVKqMykpAYwlbuYKFcBZI2, P_2))
			{
				if (!jZfPFKDWplCOjPIMlMHBvBRccTbiA(P_1, item.nbJuxRnnNcDeROnqBEAyrvjNLNiN) && item.kjEtJrjOKGctnTxXSGgjROqHisWd >= 0)
				{
					tXrLvXzFHkdiHDsUNWmqJZRISLcv = item;
					break;
				}
			}
			if (tXrLvXzFHkdiHDsUNWmqJZRISLcv != null)
			{
				int num = tXrLvXzFHkdiHDsUNWmqJZRISLcv.kjEtJrjOKGctnTxXSGgjROqHisWd;
				if (!LVqgXnWqEXjdVIUOgLessCQqYLvoA(P_1, num))
				{
					num = (tXrLvXzFHkdiHDsUNWmqJZRISLcv.kjEtJrjOKGctnTxXSGgjROqHisWd = YJxCChqPRUIkLGqZHsMfiYjGuGrC(P_1));
				}
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinputManagerId = num;
				jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = tXrLvXzFHkdiHDsUNWmqJZRISLcv.nbJuxRnnNcDeROnqBEAyrvjNLNiN;
				YAoVQkghcHABGOKZqCqplummxxuB.vXwDOSiCpxcAbDfdthDiEVrdfaHQb(jeVhmjjeVKqMykpAYwlbuYKFcBZI2);
			}
		}
	}

	private void IyLnxsbyQIeSUrUVufAmQjsiMhrF()
	{
		if (yUuxiqUmkXNNltnDSoFFWGFibMKJA)
		{
			SMWcfokAcCiVrYAldGsanYsDNNkY();
		}
		if (PvIDaoAgPJfLPewqeVcAppmOHuFpB.YibZslQejybegMCwglLcbMXjXREh && PvIDaoAgPJfLPewqeVcAppmOHuFpB.QPPcnXHfsXuMerWBTRMGFYgQdvAf())
		{
			tDjrrxhuQYZViIDESHmJpCJhqKrO(PvIDaoAgPJfLPewqeVcAppmOHuFpB.IOFddxkEPgJuSBEVGkKcRMAZvCAm);
		}
	}

	private void SMWcfokAcCiVrYAldGsanYsDNNkY()
	{
		yUuxiqUmkXNNltnDSoFFWGFibMKJA = false;
		if (!PvIDaoAgPJfLPewqeVcAppmOHuFpB.YibZslQejybegMCwglLcbMXjXREh)
		{
			PvIDaoAgPJfLPewqeVcAppmOHuFpB.gVRMdQUdMoWjfTCoTwRPEnVbhauCA();
		}
	}

	private void tDjrrxhuQYZViIDESHmJpCJhqKrO(List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> P_0)
	{
		if (iPTjgUeDzBoXHoEhRHuiCHwgrHjTA(ZDTygwMKxHIlJpRQAAQVGWaHqNgG.JlKhmciiPcQpKnADNJSyCidFlRpm(P_0)))
		{
			MFchGLbBlvdIVQMIaWEclbEWHnddA(P_0);
		}
	}

	private bool iPTjgUeDzBoXHoEhRHuiCHwgrHjTA(IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> P_0)
	{
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !yAKDXIJNwNEUSEYIHcQKqhdOlRDrA(P_0[i].vooZCRenfowGvkjwBdPFIBfsSrucA))
				{
					return true;
				}
			}
			int count2 = UWedYxDfzcKvhEXkLYENOpHgckCVA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (UWedYxDfzcKvhEXkLYENOpHgckCVA[j] != null && !znsSJCNQyVDZnhGhXpRzEtfqZFoT(P_0, UWedYxDfzcKvhEXkLYENOpHgckCVA[j].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool yAKDXIJNwNEUSEYIHcQKqhdOlRDrA(Guid P_0)
	{
		lock (RkFVkZQFgzGPnxfTclAKsGJnbOxf)
		{
			int count = UWedYxDfzcKvhEXkLYENOpHgckCVA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UWedYxDfzcKvhEXkLYENOpHgckCVA[i] != null && UWedYxDfzcKvhEXkLYENOpHgckCVA[i].Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool znsSJCNQyVDZnhGhXpRzEtfqZFoT(IList<RCbrBLDngHgaSCZnWWTNJSaCQXlM> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].vooZCRenfowGvkjwBdPFIBfsSrucA == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void iQQMVnaDsyVNLaJGPZLHKLEdbhhx(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI2 = P_0[i];
			if (jeVhmjjeVKqMykpAYwlbuYKFcBZI2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					jeVhmjjeVKqMykpAYwlbuYKFcBZI jeVhmjjeVKqMykpAYwlbuYKFcBZI3 = P_1[j];
					if (jeVhmjjeVKqMykpAYwlbuYKFcBZI3 != null && jeVhmjjeVKqMykpAYwlbuYKFcBZI2.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid == jeVhmjjeVKqMykpAYwlbuYKFcBZI3.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				atPNPXFIzjZrLMYGZjkHQaTPciGT(P_0[i], P_2);
			}
		}
	}

	private void atPNPXFIzjZrLMYGZjkHQaTPciGT(jeVhmjjeVKqMykpAYwlbuYKFcBZI P_0, bool P_1)
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

	private bool ZcRgntENqZnrvWYNZcNdOogkQoP()
	{
		int num = dulIhQUgDTgZJzdbpiHiHbVbRzqTA.zotaefACDkyTdrsEVrNfSgZAGGrWA(rxoCQyLeXikLCiACyHfjyDszEnHc.GameControl, NcIhHWHlNfssiPdJoxBFHDvPFCIoA.AttachedOnly);
		if (nPiFhuhLiWtMOvnyafYgdLCilJZG != num)
		{
			nPiFhuhLiWtMOvnyafYgdLCilJZG = num;
			return true;
		}
		if (odglvfOxJIRwiWQsRFZuyyKBLnSo > 0 && KhPpzbLIsyFQjlnCdtQNSiMuAeyV.inmEgjqVIWdhnZZCmNekUCAKqScg())
		{
			return true;
		}
		return false;
	}

	private void xHcdBftLooanjNojHGEUaOIacsvGb(List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_0, List<jeVhmjjeVKqMykpAYwlbuYKFcBZI> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].UELVAUfPPbBnyAVsQgKaOvthgOcF();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void KmWvvhUhmrTDEJqOyoiIZZRmSFW(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<ZDTygwMKxHIlJpRQAAQVGWaHqNgG> vhLXJLpHkQgIUAYsneXoRLjIgpZYA()
	{
		return KqGQEOxNzLxvkmaVMMvTtQnQrACQ();
	}
}
