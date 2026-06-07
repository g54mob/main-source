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

internal class QFMIdjQvuHEqbdqAsbQLKYQulzoJ : PlatformInputManager, MOkVWevpNUQwQWbUTpfVSRcmsAig
{
	private class AnUBMWBIhmyOkbRLhMnOFIfauXTkc : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private bool CdFEaObdmPMKINljbrtejeXeOHsBb;

		private int tMlFMbbnSDaAYEdgwltrYDupMlKyA;

		private readonly int pYZVtWfafWKWbEgDnJIbLPbxXSZh;

		public Guid dfkNjaPwXkaeRLYwmoTrUJWHbEfc;

		public string yIhEuCdnGwhBLCYrZTmZYuCcYZlcA;

		public string dOwZfeJoWhhATUmPdsXZbdgVvtHW;

		public Guid QrLkiuceluZEPMOcjJiYcdnvZQtl;

		public Rewired.Libraries.SharpDX.XInput.DeviceType mgfmGZeLtXcIMfABdmrEeVZBiEBOB;

		public XInputDeviceSubType YscLtiimpnKASXMwYqmhEzpcaiRK;

		public bool SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;

		public bool HyVaDaHEVMzHEmSpvJOZJuKvEuFM;

		public bool UOaCMGcskFlqUFiInGNxuUyKmYVs;

		public bool qcODuIRkFCERlUpWWjyXkIXUkDfY;

		private int hPGYvOJyGRFAXlayNclRbQbgBrho;

		private int alpbKwLALkCahrtZbQONzDYKzPjn;

		private int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

		private int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

		private readonly float[] dydcbiMQDPlMCvQZIVaFxWCilYKQ;

		private readonly bool[] JkLuaNrBfUjBFJFAynrFZsuAKJMTA;

		private HardwareJoystickMap_InputManager hJeYXuujpZcIHhUzFngZZNyaunJy;

		public readonly InJVokOseTgqLZHyEMIbgxKoqhby UztXDfeobYvTILthUwbphNPSdKam;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

		private Action VEzFEfovaBkPFczUefGeqHKwZVSB;

		private readonly LocalizedString IKruLRLUkxvhbHMkcXxsKAdWeahN;

		private bool TMhWxnShuMufpLHxxppPFLwtRKYC;

		private bool zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		public string QPMKBEqKVaycLpEwnGlOkcMWLImdb
		{
			get
			{
				string text = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + pYZVtWfafWKWbEgDnJIbLPbxXSZh;
			}
		}

		public string kdNvziqmWoxIlwtlUVdLVjQQNpFi
		{
			get
			{
				if (!XalKpipCyadVkiFpgWLzAEbGRXUI)
				{
					return string.Empty;
				}
				return YscLtiimpnKASXMwYqmhEzpcaiRK.ToString();
			}
		}

		public bool XalKpipCyadVkiFpgWLzAEbGRXUI
		{
			get
			{
				if (UztXDfeobYvTILthUwbphNPSdKam == null || !qcODuIRkFCERlUpWWjyXkIXUkDfY)
				{
					return false;
				}
				if (TMhWxnShuMufpLHxxppPFLwtRKYC && !cynszkfxOgOAWNGbxIMcUdNuTpjn(YvWSBTRPbtKhNLIKjagZhGQTZJeb.Asynchronous))
				{
					GMsYFzLpWZanparONuNrrYbOYekFA();
				}
				return TMhWxnShuMufpLHxxppPFLwtRKYC;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return tMlFMbbnSDaAYEdgwltrYDupMlKyA;
			}
			set
			{
				tMlFMbbnSDaAYEdgwltrYDupMlKyA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId => pYZVtWfafWKWbEgDnJIbLPbxXSZh;

		[CustomObfuscation(rename = false)]
		public string name => dOwZfeJoWhhATUmPdsXZbdgVvtHW;

		[CustomObfuscation(rename = false)]
		public long? systemId => pYZVtWfafWKWbEgDnJIbLPbxXSZh;

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				if (UztXDfeobYvTILthUwbphNPSdKam == null)
				{
					return null;
				}
				return UztXDfeobYvTILthUwbphNPSdKam.ieKoXnrhaxRLDVjBWLtFweEYtetl;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => QrLkiuceluZEPMOcjJiYcdnvZQtl;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			UztXDfeobYvTILthUwbphNPSdKam.SSYDhArzaqosllxWhbucIiAwdyFZ(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			UztXDfeobYvTILthUwbphNPSdKam.TtqTMYGbIwcFrQNfdmWJpZTiqfPI();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(IKruLRLUkxvhbHMkcXxsKAdWeahN, hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys, "controller", yIhEuCdnGwhBLCYrZTmZYuCcYZlcA, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(pYZVtWfafWKWbEgDnJIbLPbxXSZh + 1).ToString()}";
				IKruLRLUkxvhbHMkcXxsKAdWeahN.cachedValue = value;
			}
			return true;
		}

		public AnUBMWBIhmyOkbRLhMnOFIfauXTkc(int P_0, bool P_1, InJVokOseTgqLZHyEMIbgxKoqhby P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			UztXDfeobYvTILthUwbphNPSdKam = P_2;
			CdFEaObdmPMKINljbrtejeXeOHsBb = P_1;
			pYZVtWfafWKWbEgDnJIbLPbxXSZh = P_0;
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_3;
			VEzFEfovaBkPFczUefGeqHKwZVSB = P_4;
			tMlFMbbnSDaAYEdgwltrYDupMlKyA = -1;
			hPGYvOJyGRFAXlayNclRbQbgBrho = 6;
			alpbKwLALkCahrtZbQONzDYKzPjn = 15;
			HhqbiwBXcDTULYOwmAYexUsXBMtCA = hPGYvOJyGRFAXlayNclRbQbgBrho;
			MCDKyUJlmhQXfeayeJmoXfaHcWfiA = alpbKwLALkCahrtZbQONzDYKzPjn;
			dydcbiMQDPlMCvQZIVaFxWCilYKQ = new float[hPGYvOJyGRFAXlayNclRbQbgBrho];
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA = new bool[alpbKwLALkCahrtZbQONzDYKzPjn];
			IKruLRLUkxvhbHMkcXxsKAdWeahN = new LocalizedString();
			puxBgBLFBpiSVvmvRSNEOXplxmCt();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			UztXDfeobYvTILthUwbphNPSdKam.qfnucLqflxALQiRYVXsitLqJNSuab();
			bool[] array = UztXDfeobYvTILthUwbphNPSdKam.xJOAbibiwiGxgsdpcdMYjGrEAZZwb;
			yznGbdDyUyOPfduhykPAGCjaQExNc(array, ref UztXDfeobYvTILthUwbphNPSdKam.XAQnrDoqLuipBSAbnQeFxIkukeVv);
			RdPFzuLpsssVUfJbWIHhRQPBGScT(array, ref UztXDfeobYvTILthUwbphNPSdKam.XAQnrDoqLuipBSAbnQeFxIkukeVv);
			UztXDfeobYvTILthUwbphNPSdKam.MqQjLCryqEPDlgJVxyKAVvUubRHs();
		}

		public void xTlsYZTTzhQhrmgwSRhOmHEqXUOO(bool P_0)
		{
			if (UztXDfeobYvTILthUwbphNPSdKam != null)
			{
				UOaCMGcskFlqUFiInGNxuUyKmYVs = P_0;
			}
		}

		public bool cynszkfxOgOAWNGbxIMcUdNuTpjn(YvWSBTRPbtKhNLIKjagZhGQTZJeb P_0)
		{
			ecXkKEkxuXPSLXtqqeTYwxtAthMs(hssdLpDBuVKAucWbJRKLBaTkBWQkB(P_0));
			return TMhWxnShuMufpLHxxppPFLwtRKYC;
		}

		public bool hssdLpDBuVKAucWbJRKLBaTkBWQkB(YvWSBTRPbtKhNLIKjagZhGQTZJeb P_0)
		{
			if (UztXDfeobYvTILthUwbphNPSdKam == null)
			{
				return false;
			}
			return UztXDfeobYvTILthUwbphNPSdKam.hssdLpDBuVKAucWbJRKLBaTkBWQkB(P_0);
		}

		public void ecXkKEkxuXPSLXtqqeTYwxtAthMs(bool P_0)
		{
			TMhWxnShuMufpLHxxppPFLwtRKYC = P_0;
		}

		public void MBdWtKwcDkFoOMBqXOwvBKcvvGgR()
		{
			if (!qcODuIRkFCERlUpWWjyXkIXUkDfY || LUDHNCUECAdvpztrGyAJsjgtOEMb())
			{
				puxBgBLFBpiSVvmvRSNEOXplxmCt();
			}
			if (qcODuIRkFCERlUpWWjyXkIXUkDfY && TMhWxnShuMufpLHxxppPFLwtRKYC)
			{
				UztXDfeobYvTILthUwbphNPSdKam.unNSIaykSfpkHNEmGhtmxbrGklvQ();
			}
		}

		public void vJGFFDaLbDWBZxdXIDywEvBunkjNA()
		{
			tMlFMbbnSDaAYEdgwltrYDupMlKyA = -1;
			qcODuIRkFCERlUpWWjyXkIXUkDfY = false;
			UztXDfeobYvTILthUwbphNPSdKam.VPIjVdphVhWzoYvDXKaLpKYEwKDW();
			Array.Clear(dydcbiMQDPlMCvQZIVaFxWCilYKQ, 0, dydcbiMQDPlMCvQZIVaFxWCilYKQ.Length);
			Array.Clear(JkLuaNrBfUjBFJFAynrFZsuAKJMTA, 0, JkLuaNrBfUjBFJFAynrFZsuAKJMTA.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (hPGYvOJyGRFAXlayNclRbQbgBrho != dataUpdater.axisCount || alpbKwLALkCahrtZbQONzDYKzPjn != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < hPGYvOJyGRFAXlayNclRbQbgBrho; i++)
			{
				dataUpdater.axisValues[i] = dydcbiMQDPlMCvQZIVaFxWCilYKQ[i];
			}
			for (int j = 0; j < alpbKwLALkCahrtZbQONzDYKzPjn; j++)
			{
				dataUpdater.buttonValues[j] = JkLuaNrBfUjBFJFAynrFZsuAKJMTA[j];
			}
			if (zGsfYreSUFOtjBTyHnkmVUNXLXYnA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public BridgedControllerHWInfo ridDROClRSAZyaDKOnfYTSobXEmrA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			QEJmtREKifDoriOcevlcZbMJbDfL(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			QEJmtREKifDoriOcevlcZbMJbDfL(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(tMlFMbbnSDaAYEdgwltrYDupMlKyA);
		}

		private void puxBgBLFBpiSVvmvRSNEOXplxmCt()
		{
			if (UztXDfeobYvTILthUwbphNPSdKam == null || !cynszkfxOgOAWNGbxIMcUdNuTpjn(YvWSBTRPbtKhNLIKjagZhGQTZJeb.Synchronous))
			{
				return;
			}
			try
			{
				zLSksqpQsGTmTNetcHtpcssomlWd();
				jUbxDShELFCTFDJtkkSnWnyRGvoLA jUbxDShELFCTFDJtkkSnWnyRGvoLA2 = UztXDfeobYvTILthUwbphNPSdKam.CJeYTfPxPoWWWqokfOiFFdVgtDvr.gRAAWjVSHXhMhFHqQLSDIlsxPtMR(UQWGHLeQbjehaNbCUbKmUdkhLDyEA.Any);
				mgfmGZeLtXcIMfABdmrEeVZBiEBOB = jUbxDShELFCTFDJtkkSnWnyRGvoLA2.dTqvRoWTYLcyxOCegaoAeiVZAPTAb;
				YscLtiimpnKASXMwYqmhEzpcaiRK = (XInputDeviceSubType)jUbxDShELFCTFDJtkkSnWnyRGvoLA2.vmVcBnLgqUqtRjkJPXEUbgjHbkEhA;
				if (UztXDfeobYvTILthUwbphNPSdKam.CJeYTfPxPoWWWqokfOiFFdVgtDvr.SSYDhArzaqosllxWhbucIiAwdyFZ(default(ramHFCfkFFXmCnknQWnLiygydkgKA)).WQjpsdmbpxmvqTAFrYvxgMNLdWSBA)
				{
					SFHEoLFtkmPWaGuXCKXjAhXIeZUVA = true;
				}
				HyVaDaHEVMzHEmSpvJOZJuKvEuFM = (jUbxDShELFCTFDJtkkSnWnyRGvoLA2.PRRpOkhGRpmYTaxqZbRqgXTDKOHx & PDsJghyikBHfWNBqMSsEeONAGjxQ.VoiceSupported) == PDsJghyikBHfWNBqMSsEeONAGjxQ.VoiceSupported;
				bfkxPXlKJejmTALFktyasdIIxRKhA();
				dfkNjaPwXkaeRLYwmoTrUJWHbEfc = hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid;
				if (CdFEaObdmPMKINljbrtejeXeOHsBb)
				{
					yIhEuCdnGwhBLCYrZTmZYuCcYZlcA = StringTools.AddSpacesToCamelCase(YscLtiimpnKASXMwYqmhEzpcaiRK.ToString());
				}
				else
				{
					yIhEuCdnGwhBLCYrZTmZYuCcYZlcA = "XInput " + YscLtiimpnKASXMwYqmhEzpcaiRK;
				}
				dOwZfeJoWhhATUmPdsXZbdgVvtHW = $"{yIhEuCdnGwhBLCYrZTmZYuCcYZlcA} {(pYZVtWfafWKWbEgDnJIbLPbxXSZh + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(YscLtiimpnKASXMwYqmhEzpcaiRK.ToString());
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				IKruLRLUkxvhbHMkcXxsKAdWeahN.Clear();
				UztXDfeobYvTILthUwbphNPSdKam.unNSIaykSfpkHNEmGhtmxbrGklvQ();
				QrLkiuceluZEPMOcjJiYcdnvZQtl = MiscTools.CreateGuidHashSHA1(string.Concat(mgfmGZeLtXcIMfABdmrEeVZBiEBOB, YscLtiimpnKASXMwYqmhEzpcaiRK, pYZVtWfafWKWbEgDnJIbLPbxXSZh));
				qcODuIRkFCERlUpWWjyXkIXUkDfY = true;
			}
			catch (Exception)
			{
				qcODuIRkFCERlUpWWjyXkIXUkDfY = false;
				TMhWxnShuMufpLHxxppPFLwtRKYC = false;
				QrLkiuceluZEPMOcjJiYcdnvZQtl = Guid.Empty;
			}
		}

		private bool LUDHNCUECAdvpztrGyAJsjgtOEMb()
		{
			try
			{
				if (YscLtiimpnKASXMwYqmhEzpcaiRK != (XInputDeviceSubType)UztXDfeobYvTILthUwbphNPSdKam.CJeYTfPxPoWWWqokfOiFFdVgtDvr.gRAAWjVSHXhMhFHqQLSDIlsxPtMR(UQWGHLeQbjehaNbCUbKmUdkhLDyEA.Any).vmVcBnLgqUqtRjkJPXEUbgjHbkEhA)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void zLSksqpQsGTmTNetcHtpcssomlWd()
		{
			HyVaDaHEVMzHEmSpvJOZJuKvEuFM = false;
			SFHEoLFtkmPWaGuXCKXjAhXIeZUVA = false;
			UOaCMGcskFlqUFiInGNxuUyKmYVs = false;
			qcODuIRkFCERlUpWWjyXkIXUkDfY = false;
		}

		private void GMsYFzLpWZanparONuNrrYbOYekFA()
		{
			if (VEzFEfovaBkPFczUefGeqHKwZVSB != null)
			{
				VEzFEfovaBkPFczUefGeqHKwZVSB();
			}
			UztXDfeobYvTILthUwbphNPSdKam.VPIjVdphVhWzoYvDXKaLpKYEwKDW();
		}

		private void yznGbdDyUyOPfduhykPAGCjaQExNc(bool[] P_0, ref AbxnNQawiCMgQGIWRnVNVURPnesM P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= hPGYvOJyGRFAXlayNclRbQbgBrho)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				dydcbiMQDPlMCvQZIVaFxWCilYKQ[i] = mkqEwjEWKTccoblNpohIPzhMuvaL(axes_orig[i], P_0, ref P_1);
				if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && dydcbiMQDPlMCvQZIVaFxWCilYKQ[i] != 0f)
				{
					zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
				}
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT(bool[] P_0, ref AbxnNQawiCMgQGIWRnVNVURPnesM P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= alpbKwLALkCahrtZbQONzDYKzPjn)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i] = MSdCYQsaMwqrghCGBIFNcNtyaXdm(buttons_orig[i], P_0, ref P_1);
				if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i])
				{
					zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
				}
			}
		}

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref AbxnNQawiCMgQGIWRnVNVURPnesM P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return mkqEwjEWKTccoblNpohIPzhMuvaL(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.sourceButton, P_1))
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

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(XInputAxis P_0, ref AbxnNQawiCMgQGIWRnVNVURPnesM P_1)
		{
			switch (P_0)
			{
			case XInputAxis.LeftThumbX:
				return InJVokOseTgqLZHyEMIbgxKoqhby.XkqINHLcERmXREsNUNSKIBnJXSoW(P_1.GOEveahvDdruUIUqpKBRGGeKgeTL);
			case XInputAxis.LeftThumbY:
				return InJVokOseTgqLZHyEMIbgxKoqhby.XkqINHLcERmXREsNUNSKIBnJXSoW(P_1.mlqtvtjuRKKrvujpMRYsQMQyAqFC);
			case XInputAxis.RightThumbX:
				return InJVokOseTgqLZHyEMIbgxKoqhby.XkqINHLcERmXREsNUNSKIBnJXSoW(P_1.sNgdBAdVhUhtlxzgIDQxbSkKuiYJB);
			case XInputAxis.RightThumbY:
				return InJVokOseTgqLZHyEMIbgxKoqhby.XkqINHLcERmXREsNUNSKIBnJXSoW(P_1.YaZBOsBTRdbLTaiHJLJQSRvnszxLc);
			case XInputAxis.LeftTrigger:
				return InJVokOseTgqLZHyEMIbgxKoqhby.CmWMNdCnrAaeFDkLDhKORPilMyYK(P_1.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA);
			case XInputAxis.RightTrigger:
				return InJVokOseTgqLZHyEMIbgxKoqhby.CmWMNdCnrAaeFDkLDhKORPilMyYK(P_1.GzMrQBOyzotNMNIFqVCkpghEVknH);
			default:
				return 0f;
			}
		}

		private bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref AbxnNQawiCMgQGIWRnVNVURPnesM P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = mkqEwjEWKTccoblNpohIPzhMuvaL(P_0.sourceAxis, ref P_2);
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

		private bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(XInputButton P_0, bool[] P_1)
		{
			switch (P_0)
			{
			case XInputButton.DPadUp:
				return P_1[0];
			case XInputButton.DPadDown:
				return P_1[1];
			case XInputButton.DPadLeft:
				return P_1[2];
			case XInputButton.DPadRight:
				return P_1[3];
			case XInputButton.Start:
				return P_1[4];
			case XInputButton.Back:
				return P_1[5];
			case XInputButton.LeftThumb:
				return P_1[6];
			case XInputButton.RightThumb:
				return P_1[7];
			case XInputButton.LeftShoulder:
				return P_1[8];
			case XInputButton.RightShoulder:
				return P_1[9];
			case XInputButton.Guide:
				return P_1[10];
			case XInputButton.A:
				return P_1[11];
			case XInputButton.B:
				return P_1[12];
			case XInputButton.X:
				return P_1[13];
			case XInputButton.Y:
				return P_1[14];
			default:
				return false;
			}
		}

		private void bfkxPXlKJejmTALFktyasdIIxRKhA()
		{
			hJeYXuujpZcIHhUzFngZZNyaunJy = NBBGEOVRvneYDcFdnaoIhuFHZZKyB(ridDROClRSAZyaDKOnfYTSobXEmrA());
			if (hJeYXuujpZcIHhUzFngZZNyaunJy == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			hPGYvOJyGRFAXlayNclRbQbgBrho = hJeYXuujpZcIHhUzFngZZNyaunJy.axisCount;
			alpbKwLALkCahrtZbQONzDYKzPjn = hJeYXuujpZcIHhUzFngZZNyaunJy.buttonCount;
		}

		private bool djNpjqajwQeghNvszAhAYnfOuxrf(ref ramHFCfkFFXmCnknQWnLiygydkgKA P_0)
		{
			if (P_0.rfcGrJKvwCMdyizFcimsxPcuFzvxB > 0 || P_0.gkwtnBuCzbWyyVPgXQxmpBbzlDKy > 0)
			{
				return true;
			}
			return false;
		}

		private void KOvyjmcDrWkwysJDVuiHnigdXmNG(ref ramHFCfkFFXmCnknQWnLiygydkgKA P_0)
		{
			P_0.rfcGrJKvwCMdyizFcimsxPcuFzvxB = 0;
			P_0.gkwtnBuCzbWyyVPgXQxmpBbzlDKy = 0;
		}

		private void AUYXDtKsdoTkjOgOfCafDtVTAjFz(ref ramHFCfkFFXmCnknQWnLiygydkgKA P_0, ref ramHFCfkFFXmCnknQWnLiygydkgKA P_1)
		{
			P_1.rfcGrJKvwCMdyizFcimsxPcuFzvxB = P_0.rfcGrJKvwCMdyizFcimsxPcuFzvxB;
			P_1.gkwtnBuCzbWyyVPgXQxmpBbzlDKy = P_0.gkwtnBuCzbWyyVPgXQxmpBbzlDKy;
		}

		private string fTrtkGAhKrGyGVauahHKFFPlEsVqA()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{mgfmGZeLtXcIMfABdmrEeVZBiEBOB.ToString()}{YscLtiimpnKASXMwYqmhEzpcaiRK.ToString()}");
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = fTrtkGAhKrGyGVauahHKFFPlEsVqA();
			P_0.hardwareAxisCount = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			P_0.hardwareButtonCount = MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.hw_supportsVoice = HyVaDaHEVMzHEmSpvJOZJuKvEuFM;
			P_0.hw_supportsVibration = SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;
			P_0.hw_localVibrationMotorCount = (SFHEoLFtkmPWaGuXCKXjAhXIeZUVA ? 2 : 0);
			P_0.hw_xInputSubType = YscLtiimpnKASXMwYqmhEzpcaiRK;
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedController P_0)
		{
			QEJmtREKifDoriOcevlcZbMJbDfL((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hJeYXuujpZcIHhUzFngZZNyaunJy.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + QPMKBEqKVaycLpEwnGlOkcMWLImdb;
			P_0.productName = "XInput " + kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.isXInputDevice = true;
			P_0.axisCount = hPGYvOJyGRFAXlayNclRbQbgBrho;
			P_0.buttonCount = alpbKwLALkCahrtZbQONzDYKzPjn;
			P_0.controllerTypeGuid = dfkNjaPwXkaeRLYwmoTrUJWHbEfc;
			P_0.controllerExtension = extension;
		}

		public void Dispose()
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
		{
			try
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
		{
			if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				return;
			}
			if (P_0)
			{
				if (XalKpipCyadVkiFpgWLzAEbGRXUI)
				{
					UztXDfeobYvTILthUwbphNPSdKam.yzgwcpWZhrzgJECUZVzpOTCnEbag();
				}
				if (UztXDfeobYvTILthUwbphNPSdKam != null)
				{
					UztXDfeobYvTILthUwbphNPSdKam.Dispose();
				}
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	private class XDxDxQfHWLsrmndAvRyvQxEoLglGA
	{
		private class XIDEpAnpaWGjhkkOaiUaNZdbAjLDb
		{
			public bool FwclQTJIqvWDxnYsGIiEpdFgJeBH;

			public int yezDqSCRWxhlxMjsXiQKzSGNMhog;

			public XInputDeviceSubType YscLtiimpnKASXMwYqmhEzpcaiRK;

			public void mefhGqvTkcrETnFSidhNngFjAYNV(AnUBMWBIhmyOkbRLhMnOFIfauXTkc P_0, bool P_1)
			{
				FwclQTJIqvWDxnYsGIiEpdFgJeBH = P_1;
				yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId;
				YscLtiimpnKASXMwYqmhEzpcaiRK = P_0.YscLtiimpnKASXMwYqmhEzpcaiRK;
			}

			public XIDEpAnpaWGjhkkOaiUaNZdbAjLDb(int P_0, XInputDeviceSubType P_1)
			{
				yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0;
				YscLtiimpnKASXMwYqmhEzpcaiRK = P_1;
			}
		}

		private List<XIDEpAnpaWGjhkkOaiUaNZdbAjLDb> ZDXhulnhGZktqkrQbgcQqMUrEhoFA;

		public XDxDxQfHWLsrmndAvRyvQxEoLglGA()
		{
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA = new List<XIDEpAnpaWGjhkkOaiUaNZdbAjLDb>();
		}

		public void NrwEKrbdqMwzKpQgWialPPTmYfXmA(AnUBMWBIhmyOkbRLhMnOFIfauXTkc P_0, bool P_1)
		{
			if (oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0.rewiredId, P_0.YscLtiimpnKASXMwYqmhEzpcaiRK, true) < 0)
			{
				XIDEpAnpaWGjhkkOaiUaNZdbAjLDb xIDEpAnpaWGjhkkOaiUaNZdbAjLDb = new XIDEpAnpaWGjhkkOaiUaNZdbAjLDb(P_0.rewiredId, P_0.YscLtiimpnKASXMwYqmhEzpcaiRK);
				xIDEpAnpaWGjhkkOaiUaNZdbAjLDb.FwclQTJIqvWDxnYsGIiEpdFgJeBH = P_1;
				ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Add(xIDEpAnpaWGjhkkOaiUaNZdbAjLDb);
			}
		}

		public void mefhGqvTkcrETnFSidhNngFjAYNV(int P_0, AnUBMWBIhmyOkbRLhMnOFIfauXTkc P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count)
			{
				ZDXhulnhGZktqkrQbgcQqMUrEhoFA[P_0].mefhGqvTkcrETnFSidhNngFjAYNV(P_1, P_2);
			}
		}

		public int HYeEWStVHkZPUhCLdBEURGMMUWhm(XInputDeviceSubType P_0, bool P_1)
		{
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].FwclQTJIqvWDxnYsGIiEpdFgJeBH) && ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].YscLtiimpnKASXMwYqmhEzpcaiRK == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int oIZRqqhhcNLckNTOGNWcXEsLzPfQ(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].FwclQTJIqvWDxnYsGIiEpdFgJeBH) && ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].yezDqSCRWxhlxMjsXiQKzSGNMhog == P_0 && ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].YscLtiimpnKASXMwYqmhEzpcaiRK == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int qdnckOqWyRHvCmCdeeHfylrSHxwb(int P_0)
		{
			if (P_0 < 0 || P_0 >= ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return ZDXhulnhGZktqkrQbgcQqMUrEhoFA[P_0].yezDqSCRWxhlxMjsXiQKzSGNMhog;
		}

		public void FErPLqIVZgIUpAjxHnZCZHwMnYNU(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count)
			{
				ZDXhulnhGZktqkrQbgcQqMUrEhoFA[P_0].FwclQTJIqvWDxnYsGIiEpdFgJeBH = P_1;
			}
		}
	}

	private class FRroguUSvkCqbbGRGmpNvrCyeDRW
	{
		public bool yuKwQMZyCWRdarWVAEHzxBGbNrAv;

		private double ufJmuPeAMWquHHcXwdZdQnejYBdc;

		public float OsTWxRwhRxJpeyxmILLwKEftpqsu;

		public FRroguUSvkCqbbGRGmpNvrCyeDRW()
		{
		}

		public FRroguUSvkCqbbGRGmpNvrCyeDRW(float P_0)
		{
			OsTWxRwhRxJpeyxmILLwKEftpqsu = P_0;
		}

		public void tkNcQVBWUEcZyWOdviJvJZIxFBjq()
		{
			yuKwQMZyCWRdarWVAEHzxBGbNrAv = true;
			ufJmuPeAMWquHHcXwdZdQnejYBdc = (double)OsTWxRwhRxJpeyxmILLwKEftpqsu + ReInput.unscaledTime;
		}

		public void tkNcQVBWUEcZyWOdviJvJZIxFBjq(float P_0)
		{
			yuKwQMZyCWRdarWVAEHzxBGbNrAv = true;
			OsTWxRwhRxJpeyxmILLwKEftpqsu = P_0;
			ufJmuPeAMWquHHcXwdZdQnejYBdc = (double)OsTWxRwhRxJpeyxmILLwKEftpqsu + ReInput.unscaledTime;
		}

		public bool mefhGqvTkcrETnFSidhNngFjAYNV()
		{
			if (!yuKwQMZyCWRdarWVAEHzxBGbNrAv)
			{
				return false;
			}
			if (ReInput.unscaledTime >= ufJmuPeAMWquHHcXwdZdQnejYBdc)
			{
				yuKwQMZyCWRdarWVAEHzxBGbNrAv = false;
				return true;
			}
			return false;
		}

		public void DwNKXiEShimVDUzntAObjUXyaFmo()
		{
			yuKwQMZyCWRdarWVAEHzxBGbNrAv = false;
			ufJmuPeAMWquHHcXwdZdQnejYBdc = 0.0;
		}

		public void oNdKHQCWigBrGMqVOoMweuUfdJyv(float P_0)
		{
			OsTWxRwhRxJpeyxmILLwKEftpqsu = P_0;
		}

		public FRroguUSvkCqbbGRGmpNvrCyeDRW mBKfUuhCMfnlekIpakRXobRzPyad()
		{
			return (FRroguUSvkCqbbGRGmpNvrCyeDRW)MemberwiseClone();
		}
	}

	public class InJVokOseTgqLZHyEMIbgxKoqhby : IDisposable
	{
		public readonly KnfjlSnWYubQVoQLDVVhXrtvKlOF CJeYTfPxPoWWWqokfOiFFdVgtDvr;

		private readonly Controller.Extension wViVLSadDnEGnqutnjEyjJuLOUiq;

		public AbxnNQawiCMgQGIWRnVNVURPnesM XAQnrDoqLuipBSAbnQeFxIkukeVv;

		private bool TMhWxnShuMufpLHxxppPFLwtRKYC;

		private readonly ButtonLoopSet NAMTrcvXYLWpIwbVCKZHcEYqDTzA;

		private AbxnNQawiCMgQGIWRnVNVURPnesM zsGzyWZcJahKbGotFMHRtmHEFUVX;

		private bool nYLXBxZeqVPuLIOpQwlyJmXUMZad;

		private DualThreadLowLevelInputEventQueue DXVcjbZjUAQdtqWkXPrhBFajPqfl;

		private readonly object eTRoskBdTVJraCzYFXNyrUomeHqE;

		private RingBuffer<ramHFCfkFFXmCnknQWnLiygydkgKA> cnrNJdmVopuKowPbSnzJCqPueJAQ = new RingBuffer<ramHFCfkFFXmCnknQWnLiygydkgKA>(5);

		private RingBuffer<ramHFCfkFFXmCnknQWnLiygydkgKA> cNgCAzXlFnEcpdosjjKHQAbhxGoKA = new RingBuffer<ramHFCfkFFXmCnknQWnLiygydkgKA>(5);

		private readonly object YcoqYzIrkiFzkCndypZZTutqDPbk = new object();

		private readonly object DtRYpGBBXdOShHWjbNEfTnJfCXMBA = new object();

		private ramHFCfkFFXmCnknQWnLiygydkgKA hrYhgotwxpHLvShAkuYGhStbxiNk;

		private double BawrpZHMfNKaGLzbPJsreDIuIcSdA;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		public Controller.Extension ieKoXnrhaxRLDVjBWLtFweEYtetl => wViVLSadDnEGnqutnjEyjJuLOUiq;

		public bool[] xJOAbibiwiGxgsdpcdMYjGrEAZZwb => NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Current.effectiveValue;

		public InJVokOseTgqLZHyEMIbgxKoqhby(int P_0, UpdateLoopSetting P_1)
		{
			CJeYTfPxPoWWWqokfOiFFdVgtDvr = new KnfjlSnWYubQVoQLDVVhXrtvKlOF((yFvLSEQDnAqKvcTuqPcjMQMzKSMS)P_0);
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA = new ButtonLoopSet(P_1, 15);
			eTRoskBdTVJraCzYFXNyrUomeHqE = new object();
			DXVcjbZjUAQdtqWkXPrhBFajPqfl = new DualThreadLowLevelInputEventQueue((int)((float)YMIsqNPkWjrdLcJvEeLWjHNzddLY.BKENsSJCwPFOTXkHKUNFIlpBJfYC * 0.25f), 15, 6, 0);
			wViVLSadDnEGnqutnjEyjJuLOUiq = new XInputControllerExtension(this);
		}

		public void qfnucLqflxALQiRYVXsitLqJNSuab()
		{
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetUpdateLoop(ReInput.currentUpdateLoop);
			oHzCfDftIRkOYmdtmqumAZbghosvA(ref XAQnrDoqLuipBSAbnQeFxIkukeVv);
		}

		public void MqQjLCryqEPDlgJVxyKAVvUubRHs()
		{
			PoUaIzcHzxHsIJLePvaBgCgcYKhrA();
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Current.ClearWasTrueThisFrame();
		}

		public void unNSIaykSfpkHNEmGhtmxbrGklvQ()
		{
			wSuERjejnukorMpeyvWlfiOlJujf();
			TMhWxnShuMufpLHxxppPFLwtRKYC = true;
			nYLXBxZeqVPuLIOpQwlyJmXUMZad = CJeYTfPxPoWWWqokfOiFFdVgtDvr.JaUeIycumyWlPCjeNyhEexyqywGbA;
		}

		public void VPIjVdphVhWzoYvDXKaLpKYEwKDW()
		{
			TMhWxnShuMufpLHxxppPFLwtRKYC = false;
			nYLXBxZeqVPuLIOpQwlyJmXUMZad = false;
			wSuERjejnukorMpeyvWlfiOlJujf();
		}

		public bool hssdLpDBuVKAucWbJRKLBaTkBWQkB(YvWSBTRPbtKhNLIKjagZhGQTZJeb P_0)
		{
			switch (P_0)
			{
			case YvWSBTRPbtKhNLIKjagZhGQTZJeb.Synchronous:
				return nYLXBxZeqVPuLIOpQwlyJmXUMZad = CJeYTfPxPoWWWqokfOiFFdVgtDvr.JaUeIycumyWlPCjeNyhEexyqywGbA;
			case YvWSBTRPbtKhNLIKjagZhGQTZJeb.Asynchronous:
				return nYLXBxZeqVPuLIOpQwlyJmXUMZad;
			default:
				throw new NotImplementedException();
			}
		}

		public void SSYDhArzaqosllxWhbucIiAwdyFZ(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				hrYhgotwxpHLvShAkuYGhStbxiNk.rfcGrJKvwCMdyizFcimsxPcuFzvxB = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				hrYhgotwxpHLvShAkuYGhStbxiNk.gkwtnBuCzbWyyVPgXQxmpBbzlDKy = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			YvfcFXiGvIlVYpUUciNdgUycVuWwb();
		}

		public void TtqTMYGbIwcFrQNfdmWJpZTiqfPI()
		{
			hrYhgotwxpHLvShAkuYGhStbxiNk.rfcGrJKvwCMdyizFcimsxPcuFzvxB = 0;
			hrYhgotwxpHLvShAkuYGhStbxiNk.gkwtnBuCzbWyyVPgXQxmpBbzlDKy = 0;
			YvfcFXiGvIlVYpUUciNdgUycVuWwb();
		}

		public void yzgwcpWZhrzgJECUZVzpOTCnEbag()
		{
			hrYhgotwxpHLvShAkuYGhStbxiNk.rfcGrJKvwCMdyizFcimsxPcuFzvxB = 0;
			hrYhgotwxpHLvShAkuYGhStbxiNk.gkwtnBuCzbWyyVPgXQxmpBbzlDKy = 0;
			lock (DtRYpGBBXdOShHWjbNEfTnJfCXMBA)
			{
				lock (YcoqYzIrkiFzkCndypZZTutqDPbk)
				{
					cnrNJdmVopuKowPbSnzJCqPueJAQ.Clear();
					cNgCAzXlFnEcpdosjjKHQAbhxGoKA.Clear();
					nwLgiDxCWUFQVPzcOkXFAwZhMOTT(CJeYTfPxPoWWWqokfOiFFdVgtDvr, hrYhgotwxpHLvShAkuYGhStbxiNk, ref BawrpZHMfNKaGLzbPJsreDIuIcSdA);
				}
			}
		}

		public void fxLwxYXNDeWmgTDmiAmUsGsoIgsu()
		{
			if (!TMhWxnShuMufpLHxxppPFLwtRKYC || !nYLXBxZeqVPuLIOpQwlyJmXUMZad)
			{
				return;
			}
			szUSrYdGEqLOFeUPKPIdPPtaOdyV szUSrYdGEqLOFeUPKPIdPPtaOdyV2;
			double realTime;
			try
			{
				if (!CJeYTfPxPoWWWqokfOiFFdVgtDvr.GXQGnXhksfAFRXvBdDLhdQPbMGBLc(out szUSrYdGEqLOFeUPKPIdPPtaOdyV2))
				{
					nYLXBxZeqVPuLIOpQwlyJmXUMZad = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				nYLXBxZeqVPuLIOpQwlyJmXUMZad = false;
				return;
			}
			lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
			{
				if (!vHYozwRQDJjOmEEOhjJkrrjpLBrx(szUSrYdGEqLOFeUPKPIdPPtaOdyV2.PfiLCKmbBsoNWfmwNSMmvnYzSSIW, zsGzyWZcJahKbGotFMHRtmHEFUVX))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = DXVcjbZjUAQdtqWkXPrhBFajPqfl.T_CreateEvent())
					{
						fboxjjefLLFMiyzOHribrQITuxLD(ref szUSrYdGEqLOFeUPKPIdPPtaOdyV2.PfiLCKmbBsoNWfmwNSMmvnYzSSIW, realTime, newEventWrapper.Event);
					}
					zsGzyWZcJahKbGotFMHRtmHEFUVX = szUSrYdGEqLOFeUPKPIdPPtaOdyV2.PfiLCKmbBsoNWfmwNSMmvnYzSSIW;
				}
			}
		}

		public void OhCauHdFBDaPcQNeCIrGOfJDmDOy()
		{
			if (!TMhWxnShuMufpLHxxppPFLwtRKYC || !nYLXBxZeqVPuLIOpQwlyJmXUMZad || ReInput.realTime < BawrpZHMfNKaGLzbPJsreDIuIcSdA + 0.009999999776482582)
			{
				return;
			}
			lock (DtRYpGBBXdOShHWjbNEfTnJfCXMBA)
			{
				lock (YcoqYzIrkiFzkCndypZZTutqDPbk)
				{
					MiscTools.Swap(ref cnrNJdmVopuKowPbSnzJCqPueJAQ, ref cNgCAzXlFnEcpdosjjKHQAbhxGoKA);
				}
				LzibwXvwyLdofdzRGOZEcrHwkNubb(cNgCAzXlFnEcpdosjjKHQAbhxGoKA, CJeYTfPxPoWWWqokfOiFFdVgtDvr, ref BawrpZHMfNKaGLzbPJsreDIuIcSdA);
			}
		}

		private void PoUaIzcHzxHsIJLePvaBgCgcYKhrA()
		{
			eGkpYzKeQCBRwHGZgrYgAyUzptsm();
		}

		private void eGkpYzKeQCBRwHGZgrYgAyUzptsm()
		{
			if (!(ReInput.realTime < BawrpZHMfNKaGLzbPJsreDIuIcSdA + 1.5) && (!Mathf.Approximately((int)hrYhgotwxpHLvShAkuYGhStbxiNk.rfcGrJKvwCMdyizFcimsxPcuFzvxB, 0f) || !Mathf.Approximately((int)hrYhgotwxpHLvShAkuYGhStbxiNk.gkwtnBuCzbWyyVPgXQxmpBbzlDKy, 0f)))
			{
				YvfcFXiGvIlVYpUUciNdgUycVuWwb();
			}
		}

		private void YvfcFXiGvIlVYpUUciNdgUycVuWwb()
		{
			lock (YcoqYzIrkiFzkCndypZZTutqDPbk)
			{
				cnrNJdmVopuKowPbSnzJCqPueJAQ.Enqueue(hrYhgotwxpHLvShAkuYGhStbxiNk);
			}
		}

		private static void LzibwXvwyLdofdzRGOZEcrHwkNubb(RingBuffer<ramHFCfkFFXmCnknQWnLiygydkgKA> P_0, KnfjlSnWYubQVoQLDVVhXrtvKlOF P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				nwLgiDxCWUFQVPzcOkXFAwZhMOTT(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void nwLgiDxCWUFQVPzcOkXFAwZhMOTT(KnfjlSnWYubQVoQLDVVhXrtvKlOF P_0, ramHFCfkFFXmCnknQWnLiygydkgKA P_1, ref double P_2)
		{
			try
			{
				P_0.SSYDhArzaqosllxWhbucIiAwdyFZ(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void oHzCfDftIRkOYmdtmqumAZbghosvA(ref AbxnNQawiCMgQGIWRnVNVURPnesM P_0)
		{
			while (DXVcjbZjUAQdtqWkXPrhBFajPqfl.ProcessNewEvents())
			{
				UtUIOVozKVEIhfKJLWHrZhXaNUdp(ref P_0, ref DXVcjbZjUAQdtqWkXPrhBFajPqfl.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(i, MSdCYQsaMwqrghCGBIFNcNtyaXdm((int)P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA, i), DXVcjbZjUAQdtqWkXPrhBFajPqfl.currentEvent.GetTimestamp());
				}
			}
		}

		private void fboxjjefLLFMiyzOHribrQITuxLD(ref AbxnNQawiCMgQGIWRnVNVURPnesM P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int syxPbhBJItzVAVLveDKeKXtdjmVVA = (int)P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA;
			P_2.SetButtonsBitMask((syxPbhBJItzVAVLveDKeKXtdjmVVA & 0x7FF) | ((syxPbhBJItzVAVLveDKeKXtdjmVVA & (syxPbhBJItzVAVLveDKeKXtdjmVVA & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.GOEveahvDdruUIUqpKBRGGeKgeTL));
			P_2.SetAxisValue(1, XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.mlqtvtjuRKKrvujpMRYsQMQyAqFC));
			P_2.SetAxisValue(2, XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.sNgdBAdVhUhtlxzgIDQxbSkKuiYJB));
			P_2.SetAxisValue(3, XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.YaZBOsBTRdbLTaiHJLJQSRvnszxLc));
			P_2.SetAxisValue(4, CmWMNdCnrAaeFDkLDhKORPilMyYK(P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA));
			P_2.SetAxisValue(5, CmWMNdCnrAaeFDkLDhKORPilMyYK(P_0.GzMrQBOyzotNMNIFqVCkpghEVknH));
		}

		private void UtUIOVozKVEIhfKJLWHrZhXaNUdp(ref AbxnNQawiCMgQGIWRnVNVURPnesM P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA = (ZMpEFtIGeONFstwqpTufHhwRkNfBA)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.GOEveahvDdruUIUqpKBRGGeKgeTL = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.mlqtvtjuRKKrvujpMRYsQMQyAqFC = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.sNgdBAdVhUhtlxzgIDQxbSkKuiYJB = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.YaZBOsBTRdbLTaiHJLJQSRvnszxLc = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.GzMrQBOyzotNMNIFqVCkpghEVknH = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void wSuERjejnukorMpeyvWlfiOlJujf()
		{
			lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
			{
				XAQnrDoqLuipBSAbnQeFxIkukeVv = default(AbxnNQawiCMgQGIWRnVNVURPnesM);
				zsGzyWZcJahKbGotFMHRtmHEFUVX = default(AbxnNQawiCMgQGIWRnVNVURPnesM);
				NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Clear();
				DXVcjbZjUAQdtqWkXPrhBFajPqfl.Clear();
			}
		}

		public void Dispose()
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
		{
			try
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
		{
			if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				if (P_0)
				{
					DXVcjbZjUAQdtqWkXPrhBFajPqfl.Dispose();
				}
				JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			}
		}

		public static float XkqINHLcERmXREsNUNSKIBnJXSoW(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float CmWMNdCnrAaeFDkLDhKORPilMyYK(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool vHYozwRQDJjOmEEOhjJkrrjpLBrx(AbxnNQawiCMgQGIWRnVNVURPnesM P_0, AbxnNQawiCMgQGIWRnVNVURPnesM P_1)
		{
			if (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA == P_1.syxPbhBJItzVAVLveDKeKXtdjmVVA && P_0.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA == P_1.yWSFKFEZfcuyGsIrNIHGcVoNdiKpA && P_0.GzMrQBOyzotNMNIFqVCkpghEVknH == P_1.GzMrQBOyzotNMNIFqVCkpghEVknH && P_0.GOEveahvDdruUIUqpKBRGGeKgeTL == P_1.GOEveahvDdruUIUqpKBRGGeKgeTL && P_0.mlqtvtjuRKKrvujpMRYsQMQyAqFC == P_1.mlqtvtjuRKKrvujpMRYsQMQyAqFC && P_0.sNgdBAdVhUhtlxzgIDQxbSkKuiYJB == P_1.sNgdBAdVhUhtlxzgIDQxbSkKuiYJB)
			{
				return P_0.YaZBOsBTRdbLTaiHJLJQSRvnszxLc == P_1.YaZBOsBTRdbLTaiHJLJQSRvnszxLc;
			}
			return false;
		}
	}

	public enum YvWSBTRPbtKhNLIKjagZhGQTZJeb
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int smDLQhEaENCAxOilgXUrJbxlEhix = 4;

	public const int ExMGcRsTiQWiFTofrfCxjyuQSNUg = 32768;

	public const int RpcGCCoXuDpELeajslYgtemoQlI = -32768;

	public const int LUpqiravEFuMslgkPTeMOipYeNjw = 255;

	public const int wIvhVhERNRxAwFJujZaQojPqzooh = 0;

	public const int xhfbpoJXNeoIgijoGRotDSvkQWfBA = 18;

	public const int WIgtMvudrInuQxazYXJDhjopkICe = 14;

	public const int jSwweBkGHqeRUjYyUvdGqygzbUfAb = 6;

	public const int OsCECBAHAlfYioVibLpCfinGfKdaA = 15;

	private AnUBMWBIhmyOkbRLhMnOFIfauXTkc[] XOgmzUHBSycaojpInYretZmNaLPvA;

	private bool ylSuPikRrZQBcpqyuDBLuNgvGVMS;

	private FRroguUSvkCqbbGRGmpNvrCyeDRW IOqhWLheixAxPWLNdWQkdnKbeKVJA;

	private XDxDxQfHWLsrmndAvRyvQxEoLglGA UhEuxLLQPUqgQWfuXZmBysyjezoE;

	private hDKoCVALQkrmLGSpmGgwMOwPbsxB<bool> CIGbdCwzRSAhHGwgZNwOtaEqgfZw;

	private bool[] UHahqHgquAenFpQOucDQVYqhVscH;

	private bool[] xjQMPXtdRlakWBSMUXzHMdqMHzfq;

	private bool CdFEaObdmPMKINljbrtejeXeOHsBb;

	private readonly bool keLLeHuDEbrypOqdbLSwpkAcHFZM;

	private readonly UpdateLoopSetting qKkPeIypOpjQUxydesBnlQpJkQSb;

	private UpdateLoopType VXhDOsSkbELPmdnhMhoDrrMsrrvI;

	private UpdateLoopType xhRzRISzIdhLqJFQBNdtagvCFWCT;

	private Action<int, ControllerDataUpdater> qTPyWiiAzgfhSZUfTOhfkrKlxaVL;

	private bool rzVCXmSSqefWtZahugWFSxFAcYJJ;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

	private Func<int> OlamnlbqCRkOUMBSkakeUghSoraE;

	private Func<PidVid, bool> VHozMkYTsppjwzplNnvqVlPyVAqq;

	private static Guid[] GIkAAmBPUoLQJKnEitgUJnQeWzUV;

	private static string[] sporgdpUnerCErJHNdJbKdqqupeSA;

	private static string[] aqqbGImYirwDTvsEhowTLXHCIaEL;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (XOgmzUHBSycaojpInYretZmNaLPvA[i].XalKpipCyadVkiFpgWLzAEbGRXUI)
				{
					num++;
				}
			}
			return num;
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.XInput;

	ivZaYCCtEtNTtFRjdTwDlGuFTodBC MOkVWevpNUQwQWbUTpfVSRcmsAig.yspUgnVhRcCpHhsZMukwSUynqPlfb => ivZaYCCtEtNTtFRjdTwDlGuFTodBC.XInput;

	public QFMIdjQvuHEqbdqAsbQLKYQulzoJ(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		keLLeHuDEbrypOqdbLSwpkAcHFZM = P_0;
		qKkPeIypOpjQUxydesBnlQpJkQSb = P_1;
		VHozMkYTsppjwzplNnvqVlPyVAqq = P_4;
		rzVCXmSSqefWtZahugWFSxFAcYJJ = true;
		try
		{
			if (!jQXZxnZotZMoKXvWXxLTaBmrxJae.puxBgBLFBpiSVvmvRSNEOXplxmCt(out var haHwBVoGVlDboBrdUwqeJRPGOhlgA2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (haHwBVoGVlDboBrdUwqeJRPGOhlgA2 < haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_2;
			OlamnlbqCRkOUMBSkakeUghSoraE = P_3;
			CdFEaObdmPMKINljbrtejeXeOHsBb = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(qKkPeIypOpjQUxydesBnlQpJkQSb, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					xhRzRISzIdhLqJFQBNdtagvCFWCT = list[num2];
				}
			}
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw = new hDKoCVALQkrmLGSpmGgwMOwPbsxB<bool>(true, UXURgftBiVutVcWOLsnyVhmsDMgW);
			UHahqHgquAenFpQOucDQVYqhVscH = new bool[4];
			xjQMPXtdRlakWBSMUXzHMdqMHzfq = new bool[4];
			qTPyWiiAzgfhSZUfTOhfkrKlxaVL = UpdateControllerData;
			if (CdFEaObdmPMKINljbrtejeXeOHsBb)
			{
				TZzFLUwbDHyIHNkwrBcFIdPpLANSA();
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
		if (rzVCXmSSqefWtZahugWFSxFAcYJJ)
		{
			IOqhWLheixAxPWLNdWQkdnKbeKVJA = new FRroguUSvkCqbbGRGmpNvrCyeDRW(1f);
		}
		UhEuxLLQPUqgQWfuXZmBysyjezoE = new XDxDxQfHWLsrmndAvRyvQxEoLglGA();
		if (XOgmzUHBSycaojpInYretZmNaLPvA == null)
		{
			XOgmzUHBSycaojpInYretZmNaLPvA = new AnUBMWBIhmyOkbRLhMnOFIfauXTkc[4];
			for (int i = 0; i < 4; i++)
			{
				InJVokOseTgqLZHyEMIbgxKoqhby inJVokOseTgqLZHyEMIbgxKoqhby = new InJVokOseTgqLZHyEMIbgxKoqhby(i, qKkPeIypOpjQUxydesBnlQpJkQSb);
				YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent += inJVokOseTgqLZHyEMIbgxKoqhby.fxLwxYXNDeWmgTDmiAmUsGsoIgsu;
				YMIsqNPkWjrdLcJvEeLWjHNzddLY.unrfEQlddjGfPMFnGuoLscUgiQqR.ThreadUpdateEvent += inJVokOseTgqLZHyEMIbgxKoqhby.OhCauHdFBDaPcQNeCIrGOfJDmDOy;
				XOgmzUHBSycaojpInYretZmNaLPvA[i] = new AnUBMWBIhmyOkbRLhMnOFIfauXTkc(i, CdFEaObdmPMKINljbrtejeXeOHsBb, inJVokOseTgqLZHyEMIbgxKoqhby, NBBGEOVRvneYDcFdnaoIhuFHZZKyB, SystemDeviceDisconnected);
			}
		}
		KReMQlbvWuKaZSyzXhUKpWMxSDRR(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		VXhDOsSkbELPmdnhMhoDrrMsrrvI = currentUpdateLoop;
		FUnOAYKrPGQnYrEjeUvOZtyzGhVe();
		for (int i = 0; i < 4; i++)
		{
			if (XOgmzUHBSycaojpInYretZmNaLPvA[i] != null && XOgmzUHBSycaojpInYretZmNaLPvA[i].XalKpipCyadVkiFpgWLzAEbGRXUI)
			{
				XOgmzUHBSycaojpInYretZmNaLPvA[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (CIGbdCwzRSAhHGwgZNwOtaEqgfZw != null)
		{
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw.vCBFvIdHsbAnKBZkroQOsRrLIAyV();
		}
		if (XOgmzUHBSycaojpInYretZmNaLPvA != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (XOgmzUHBSycaojpInYretZmNaLPvA[i] != null)
				{
					if (YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi != null)
					{
						YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent -= XOgmzUHBSycaojpInYretZmNaLPvA[i].UztXDfeobYvTILthUwbphNPSdKam.fxLwxYXNDeWmgTDmiAmUsGsoIgsu;
					}
					if (YMIsqNPkWjrdLcJvEeLWjHNzddLY.unrfEQlddjGfPMFnGuoLscUgiQqR != null)
					{
						YMIsqNPkWjrdLcJvEeLWjHNzddLY.unrfEQlddjGfPMFnGuoLscUgiQqR.ThreadUpdateEvent -= XOgmzUHBSycaojpInYretZmNaLPvA[i].UztXDfeobYvTILthUwbphNPSdKam.OhCauHdFBDaPcQNeCIrGOfJDmDOy;
					}
					XOgmzUHBSycaojpInYretZmNaLPvA[i].Dispose();
				}
			}
		}
		jQXZxnZotZMoKXvWXxLTaBmrxJae.TqHRYsMwbqlgKxhHpHMoGGGLjQUqA();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return qTPyWiiAzgfhSZUfTOhfkrKlxaVL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		XOgmzUHBSycaojpInYretZmNaLPvA[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		KReMQlbvWuKaZSyzXhUKpWMxSDRR(true);
		SBUrTAVxxvRMQoiqPNJKzeLIONqo();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		KReMQlbvWuKaZSyzXhUKpWMxSDRR(true);
		SBUrTAVxxvRMQoiqPNJKzeLIONqo();
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

	private bool mbeRWTxaaIJiLNVbZKEaAjExEXPFA(string P_0, string P_1, string P_2, PidVid P_3)
	{
		if (VHozMkYTsppjwzplNnvqVlPyVAqq(P_3))
		{
			return false;
		}
		return hzvmEqUeDIUEjNJAHqijmhAFrvjN(P_0, P_1, P_2, MiscTools.CreateHIDProductGuid(P_3.vendorId, P_3.productId));
	}

	bool MOkVWevpNUQwQWbUTpfVSRcmsAig.sGpbxaQopaOdreijKwIPSJCLFXaDA(string P_0, string P_1, string P_2, PidVid P_3)
	{
		//ILSpy generated this explicit interface implementation from .override directive in mbeRWTxaaIJiLNVbZKEaAjExEXPFA
		return this.mbeRWTxaaIJiLNVbZKEaAjExEXPFA(P_0, P_1, P_2, P_3);
	}

	private bool qPlHgNuliKbfvGvPrlbrwQHMftxs()
	{
		if (VXhDOsSkbELPmdnhMhoDrrMsrrvI != xhRzRISzIdhLqJFQBNdtagvCFWCT)
		{
			return false;
		}
		bool num = IOqhWLheixAxPWLNdWQkdnKbeKVJA.mefhGqvTkcrETnFSidhNngFjAYNV();
		if (num)
		{
			KReMQlbvWuKaZSyzXhUKpWMxSDRR(true);
		}
		return num;
	}

	private void KReMQlbvWuKaZSyzXhUKpWMxSDRR(bool P_0)
	{
		ylSuPikRrZQBcpqyuDBLuNgvGVMS = P_0;
		if (rzVCXmSSqefWtZahugWFSxFAcYJJ)
		{
			IOqhWLheixAxPWLNdWQkdnKbeKVJA.tkNcQVBWUEcZyWOdviJvJZIxFBjq();
		}
	}

	private void SBUrTAVxxvRMQoiqPNJKzeLIONqo()
	{
		if (CIGbdCwzRSAhHGwgZNwOtaEqgfZw != null)
		{
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw.DwNKXiEShimVDUzntAObjUXyaFmo();
		}
	}

	private void TZzFLUwbDHyIHNkwrBcFIdPpLANSA()
	{
		_ = new KnfjlSnWYubQVoQLDVVhXrtvKlOF().JaUeIycumyWlPCjeNyhEexyqywGbA;
	}

	private void FUnOAYKrPGQnYrEjeUvOZtyzGhVe()
	{
		bool flag = false;
		if (rzVCXmSSqefWtZahugWFSxFAcYJJ)
		{
			flag = qPlHgNuliKbfvGvPrlbrwQHMftxs();
		}
		if (!flag && ylSuPikRrZQBcpqyuDBLuNgvGVMS)
		{
			gYWuOhHGTbOzJJhgYEzFVCYtEyuu(KaHCBVwQnDPcHmyqVUlUUIkTJMTU());
			KReMQlbvWuKaZSyzXhUKpWMxSDRR(false);
			SBUrTAVxxvRMQoiqPNJKzeLIONqo();
			return;
		}
		if (ylSuPikRrZQBcpqyuDBLuNgvGVMS)
		{
			tPJeYtIjeCijeGcijckJYYtMscvw();
		}
		if (CIGbdCwzRSAhHGwgZNwOtaEqgfZw.RTnbdebLTdTeohXHDoBoLyQGImfWA && CIGbdCwzRSAhHGwgZNwOtaEqgfZw.TPcqcKWeqJnMdeNkqZXytbyidUBn())
		{
			qYzploxFNRIjWyUyiDlZFiYzKmCHb();
		}
	}

	private void tPJeYtIjeCijeGcijckJYYtMscvw()
	{
		ylSuPikRrZQBcpqyuDBLuNgvGVMS = false;
		if (!CIGbdCwzRSAhHGwgZNwOtaEqgfZw.RTnbdebLTdTeohXHDoBoLyQGImfWA)
		{
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw.miPFrJiYaYbOloaoCfGOcsRcMhAoc();
		}
	}

	private void qYzploxFNRIjWyUyiDlZFiYzKmCHb()
	{
		lock (UHahqHgquAenFpQOucDQVYqhVscH)
		{
			Array.Copy(UHahqHgquAenFpQOucDQVYqhVscH, xjQMPXtdRlakWBSMUXzHMdqMHzfq, 4);
		}
		gYWuOhHGTbOzJJhgYEzFVCYtEyuu(xjQMPXtdRlakWBSMUXzHMdqMHzfq);
	}

	private bool UXURgftBiVutVcWOLsnyVhmsDMgW()
	{
		lock (UHahqHgquAenFpQOucDQVYqhVscH)
		{
			for (int i = 0; i < 4; i++)
			{
				if (XOgmzUHBSycaojpInYretZmNaLPvA[i] != null)
				{
					UHahqHgquAenFpQOucDQVYqhVscH[i] = XOgmzUHBSycaojpInYretZmNaLPvA[i].hssdLpDBuVKAucWbJRKLBaTkBWQkB(YvWSBTRPbtKhNLIKjagZhGQTZJeb.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] KaHCBVwQnDPcHmyqVUlUUIkTJMTU()
	{
		for (int i = 0; i < 4; i++)
		{
			xjQMPXtdRlakWBSMUXzHMdqMHzfq[i] = XOgmzUHBSycaojpInYretZmNaLPvA[i].hssdLpDBuVKAucWbJRKLBaTkBWQkB(YvWSBTRPbtKhNLIKjagZhGQTZJeb.Synchronous);
		}
		return xjQMPXtdRlakWBSMUXzHMdqMHzfq;
	}

	private void gYWuOhHGTbOzJJhgYEzFVCYtEyuu(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (XOgmzUHBSycaojpInYretZmNaLPvA[i] != null && XOgmzUHBSycaojpInYretZmNaLPvA[i].UOaCMGcskFlqUFiInGNxuUyKmYVs)
			{
				bool flag = P_0[i];
				XOgmzUHBSycaojpInYretZmNaLPvA[i].ecXkKEkxuXPSLXtqqeTYwxtAthMs(flag);
				if (!flag)
				{
					VTTdBYSqcQzDyOFRkPCEjraxYldu(XOgmzUHBSycaojpInYretZmNaLPvA[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (XOgmzUHBSycaojpInYretZmNaLPvA[j] != null && !XOgmzUHBSycaojpInYretZmNaLPvA[j].UOaCMGcskFlqUFiInGNxuUyKmYVs)
			{
				bool flag2 = P_0[j];
				XOgmzUHBSycaojpInYretZmNaLPvA[j].ecXkKEkxuXPSLXtqqeTYwxtAthMs(flag2);
				if (flag2 && !VTTdBYSqcQzDyOFRkPCEjraxYldu(XOgmzUHBSycaojpInYretZmNaLPvA[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (XOgmzUHBSycaojpInYretZmNaLPvA[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					XOgmzUHBSycaojpInYretZmNaLPvA[k].xTlsYZTTzhQhrmgwSRhOmHEqXUOO(P_0[k]);
				}
			}
		}
	}

	private bool VTTdBYSqcQzDyOFRkPCEjraxYldu(AnUBMWBIhmyOkbRLhMnOFIfauXTkc P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.MBdWtKwcDkFoOMBqXOwvBKcvvGgR();
			if (!P_0.qcODuIRkFCERlUpWWjyXkIXUkDfY)
			{
				return false;
			}
			int num = UhEuxLLQPUqgQWfuXZmBysyjezoE.HYeEWStVHkZPUhCLdBEURGMMUWhm(P_0.YscLtiimpnKASXMwYqmhEzpcaiRK, false);
			if (num >= 0)
			{
				P_0.rewiredId = UhEuxLLQPUqgQWfuXZmBysyjezoE.qdnckOqWyRHvCmCdeeHfylrSHxwb(num);
				UhEuxLLQPUqgQWfuXZmBysyjezoE.mefhGqvTkcrETnFSidhNngFjAYNV(num, P_0, true);
			}
			else
			{
				P_0.rewiredId = OlamnlbqCRkOUMBSkakeUghSoraE();
				UhEuxLLQPUqgQWfuXZmBysyjezoE.NrwEKrbdqMwzKpQgWialPPTmYfXmA(P_0, true);
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
			int num2 = UhEuxLLQPUqgQWfuXZmBysyjezoE.oIZRqqhhcNLckNTOGNWcXEsLzPfQ(P_0.rewiredId, P_0.YscLtiimpnKASXMwYqmhEzpcaiRK, true);
			if (num2 >= 0)
			{
				UhEuxLLQPUqgQWfuXZmBysyjezoE.FErPLqIVZgIUpAjxHnZCZHwMnYNU(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.vJGFFDaLbDWBZxdXIDywEvBunkjNA();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static QFMIdjQvuHEqbdqAsbQLKYQulzoJ()
	{
		GIkAAmBPUoLQJKnEitgUJnQeWzUV = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		sporgdpUnerCErJHNdJbKdqqupeSA = new string[1] { "Xbox Bluetooth Gamepad" };
		aqqbGImYirwDTvsEhowTLXHCIaEL = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool hzvmEqUeDIUEjNJAHqijmhAFrvjN(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(GIkAAmBPUoLQJKnEitgUJnQeWzUV, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < sporgdpUnerCErJHNdJbKdqqupeSA.Length; i++)
			{
				if (P_1.Equals(sporgdpUnerCErJHNdJbKdqqupeSA[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < aqqbGImYirwDTvsEhowTLXHCIaEL.Length; j++)
			{
				if (Regex.IsMatch(P_2, aqqbGImYirwDTvsEhowTLXHCIaEL[j], RegexOptions.IgnoreCase))
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
