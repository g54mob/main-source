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

internal class YeDLvUUmeuKtQrgSaWuhUANSLKCe : PlatformInputManager, MpfSAJjorzYIlCIHNIPpIhZKdISt
{
	private class NKwSfsGyUIazodrgxUlsBzqRhiXk : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool OQGGcrubiLdgcJkdvFVffesfUYcHA;

		private int rBtxwWHdNFscpJDQzFqgHwHdKEcuA;

		private readonly int KCcBObYCEHPUZidHZXnAgZbcIagU;

		public Guid TfWnioWbcTGJGMCIdDESKgnISctwA;

		public string ITuXVExmkWgbdOCWsEfhxXqxaSLjA;

		public string YQZADOkFkGKrHRhclwIjbisLsGZy;

		public Guid OqRgxQgEroCPfYgcyPHHVODtGEKS;

		public Rewired.Libraries.SharpDX.XInput.DeviceType JHUnCSJfjLYlukWXZIQzgRJJNuGu;

		public XInputDeviceSubType iDvicFAoLsYlcSjadcqddrIaZDhJA;

		public bool RAbqGmrhuNstgLzBgXIEgdzJHWSO;

		public bool WRLzUxwuFqfjJOfTRRLIvsmJPpjj;

		public bool TPSFwhfjkPWAhnDFKGeVDaiYfJQmA;

		public bool VdOWGUpCGwDLoPIweCEpxOPUBBaP;

		private int uvoUhVBegKwoAboayrPeFmZGqJNE;

		private int rTVJPGzrskTlmOVlzCsdKWVcArFM;

		private int ISLEoRRyEdWTqSxynHFMVLgpxPDu;

		private int JyFEBowSoCAzKeyyuTwKARcCAXrfb;

		private readonly float[] JyHIymrGkkfulducFSNExOxlsExq;

		private readonly bool[] JerwgBTkgnaQxjKotjXleSOjOXtHB;

		private HardwareJoystickMap_InputManager zXwfAkxDDXiNIAYrYEyQDbgciqhvA;

		public readonly RxhEziXVhDGFUrIhpfyWqJviVifY NjYCbbBSwHJznXPGkHgoSUFYuyCF;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> mrsEhhaUuulOaHeQbOHzkFyhJnxI;

		private Action RqPCmNoCaToJtpVHObSKAcZfTPNI;

		private readonly LocalizedString EAsBAqdczjEyXuolxxgkFApzoBnfb;

		private bool tIcSrQZIsmzGDzVDOVInGHotOVUm;

		private bool hZphhNSqWCRCLvPodGGvDWufwLmHA;

		private bool FSZigIKWSDrpkHfFGhjMfQnqBaIx;

		public string ZqOuPYAyxOpuaXcsjbuLiSqsnXKoA
		{
			get
			{
				string text = lTBBxcGXfxqCjjSWLecQITIwIkKFA;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int kCcBObYCEHPUZidHZXnAgZbcIagU = KCcBObYCEHPUZidHZXnAgZbcIagU;
				return text + " " + kCcBObYCEHPUZidHZXnAgZbcIagU;
			}
		}

		public string lTBBxcGXfxqCjjSWLecQITIwIkKFA
		{
			get
			{
				if (!qYJlZLrVTKUIhgYzVshTfFULGZzAA)
				{
					return string.Empty;
				}
				return iDvicFAoLsYlcSjadcqddrIaZDhJA.ToString();
			}
		}

		public bool qYJlZLrVTKUIhgYzVshTfFULGZzAA
		{
			get
			{
				if (NjYCbbBSwHJznXPGkHgoSUFYuyCF == null || !VdOWGUpCGwDLoPIweCEpxOPUBBaP)
				{
					return false;
				}
				if (tIcSrQZIsmzGDzVDOVInGHotOVUm && !TVWENOjYEbPIBqVMxnAFQWwOoyVfA(WGgLqpogYRSujebBKDmwAhrUAWUMA.Asynchronous))
				{
					yZkJPSFUwrGnPpPRRiqdAkZEsoIb();
				}
				return tIcSrQZIsmzGDzVDOVInGHotOVUm;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return rBtxwWHdNFscpJDQzFqgHwHdKEcuA;
			}
			set
			{
				rBtxwWHdNFscpJDQzFqgHwHdKEcuA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => KCcBObYCEHPUZidHZXnAgZbcIagU;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => YQZADOkFkGKrHRhclwIjbisLsGZy;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => KCcBObYCEHPUZidHZXnAgZbcIagU;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (NjYCbbBSwHJznXPGkHgoSUFYuyCF == null)
				{
					return null;
				}
				return NjYCbbBSwHJznXPGkHgoSUFYuyCF.OmAnUdNIQvkkxyjPlBQLifuEXNyq;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => OqRgxQgEroCPfYgcyPHHVODtGEKS;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.mqvNuGrnYijMLOOfxxnxiOPvoFCp(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.sABZXzENSHbCMumCpuWaQvqFkbjt();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(EAsBAqdczjEyXuolxxgkFApzoBnfb, zXwfAkxDDXiNIAYrYEyQDbgciqhvA.deviceLocalizationInfo.parentKeys, "controller", ITuXVExmkWgbdOCWsEfhxXqxaSLjA, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(KCcBObYCEHPUZidHZXnAgZbcIagU + 1).ToString()}";
				EAsBAqdczjEyXuolxxgkFApzoBnfb.cachedValue = value;
			}
			return true;
		}

		public NKwSfsGyUIazodrgxUlsBzqRhiXk(int P_0, bool P_1, RxhEziXVhDGFUrIhpfyWqJviVifY P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			NjYCbbBSwHJznXPGkHgoSUFYuyCF = P_2;
			OQGGcrubiLdgcJkdvFVffesfUYcHA = P_1;
			KCcBObYCEHPUZidHZXnAgZbcIagU = P_0;
			mrsEhhaUuulOaHeQbOHzkFyhJnxI = P_3;
			RqPCmNoCaToJtpVHObSKAcZfTPNI = P_4;
			rBtxwWHdNFscpJDQzFqgHwHdKEcuA = -1;
			uvoUhVBegKwoAboayrPeFmZGqJNE = 6;
			rTVJPGzrskTlmOVlzCsdKWVcArFM = 15;
			ISLEoRRyEdWTqSxynHFMVLgpxPDu = uvoUhVBegKwoAboayrPeFmZGqJNE;
			JyFEBowSoCAzKeyyuTwKARcCAXrfb = rTVJPGzrskTlmOVlzCsdKWVcArFM;
			JyHIymrGkkfulducFSNExOxlsExq = new float[uvoUhVBegKwoAboayrPeFmZGqJNE];
			JerwgBTkgnaQxjKotjXleSOjOXtHB = new bool[rTVJPGzrskTlmOVlzCsdKWVcArFM];
			EAsBAqdczjEyXuolxxgkFApzoBnfb = new LocalizedString();
			UXkQheELxZzHyYPZfACjoOkJhEdF();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.dvPNZIKllNVvhYrCwSUiNJgAiWEt();
			bool[] array = NjYCbbBSwHJznXPGkHgoSUFYuyCF.FUenNpiFupAgxJqARhBncOlPSCbz;
			ECrszfuhyOGjREaAtUfzunHbBCZJA(array, ref NjYCbbBSwHJznXPGkHgoSUFYuyCF.DNYKWAQmcEXjdInfFKpzgciMUpJL);
			wdEsLUeAtplYQdmnFUhDBLMztUEh(array, ref NjYCbbBSwHJznXPGkHgoSUFYuyCF.DNYKWAQmcEXjdInfFKpzgciMUpJL);
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.WUWFiHxRymBjbzhvAIYUNdsnGfte();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void HckEkzHOLCBvPmnDxrivjrYcDpOB(bool P_0)
		{
			if (NjYCbbBSwHJznXPGkHgoSUFYuyCF != null)
			{
				TPSFwhfjkPWAhnDFKGeVDaiYfJQmA = P_0;
			}
		}

		public bool TVWENOjYEbPIBqVMxnAFQWwOoyVfA(WGgLqpogYRSujebBKDmwAhrUAWUMA P_0)
		{
			ZcrDDmEaAsTjuQOTDEcCXSRIVNnvA(DMuTLRcnoPfxZkRMDLbMwSMybXdg(P_0));
			return tIcSrQZIsmzGDzVDOVInGHotOVUm;
		}

		public bool DMuTLRcnoPfxZkRMDLbMwSMybXdg(WGgLqpogYRSujebBKDmwAhrUAWUMA P_0)
		{
			if (NjYCbbBSwHJznXPGkHgoSUFYuyCF == null)
			{
				return false;
			}
			return NjYCbbBSwHJznXPGkHgoSUFYuyCF.MPcLytnfmKawsENMwkDHaGVHbRFm(P_0);
		}

		public void ZcrDDmEaAsTjuQOTDEcCXSRIVNnvA(bool P_0)
		{
			tIcSrQZIsmzGDzVDOVInGHotOVUm = P_0;
		}

		public void KXlpoSPlELaECbizgaMgCKIuxuWDb()
		{
			if (!VdOWGUpCGwDLoPIweCEpxOPUBBaP || pINsmjyOIcFkvEIwVrMygphQtvtv())
			{
				UXkQheELxZzHyYPZfACjoOkJhEdF();
			}
			if (VdOWGUpCGwDLoPIweCEpxOPUBBaP && tIcSrQZIsmzGDzVDOVInGHotOVUm)
			{
				NjYCbbBSwHJznXPGkHgoSUFYuyCF.pnZlXAYoghXbjVgEoHleXRDAxsGA();
			}
		}

		public void FlPQULQNQKkdqpLjycRFUnWXGJYk()
		{
			rBtxwWHdNFscpJDQzFqgHwHdKEcuA = -1;
			VdOWGUpCGwDLoPIweCEpxOPUBBaP = false;
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.ViAEmhIqzMiECIXohLXRgnZWdCbyb();
			Array.Clear(JyHIymrGkkfulducFSNExOxlsExq, 0, JyHIymrGkkfulducFSNExOxlsExq.Length);
			Array.Clear(JerwgBTkgnaQxjKotjXleSOjOXtHB, 0, JerwgBTkgnaQxjKotjXleSOjOXtHB.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (uvoUhVBegKwoAboayrPeFmZGqJNE != dataUpdater.axisCount || rTVJPGzrskTlmOVlzCsdKWVcArFM != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < uvoUhVBegKwoAboayrPeFmZGqJNE; i++)
			{
				dataUpdater.axisValues[i] = JyHIymrGkkfulducFSNExOxlsExq[i];
			}
			for (int j = 0; j < rTVJPGzrskTlmOVlzCsdKWVcArFM; j++)
			{
				dataUpdater.buttonValues[j] = JerwgBTkgnaQxjKotjXleSOjOXtHB[j];
			}
			if (hZphhNSqWCRCLvPodGGvDWufwLmHA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo PWfuuQDUWJkdEjJaLfRWsgPKXoQi()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			ZkRhJbgoJObkzHfJsSTyruNbQlNU(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			uYhmoHIdQoMHsMysZMIcANJtdcIr(bridgedController);
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
			return new ControllerDisconnectedEventArgs(rBtxwWHdNFscpJDQzFqgHwHdKEcuA);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void UXkQheELxZzHyYPZfACjoOkJhEdF()
		{
			if (NjYCbbBSwHJznXPGkHgoSUFYuyCF == null || !TVWENOjYEbPIBqVMxnAFQWwOoyVfA(WGgLqpogYRSujebBKDmwAhrUAWUMA.Synchronous))
			{
				return;
			}
			try
			{
				SwHBbKErDrjwKzMMdykLiKKdaUKU();
				fuoOEptqBeePsHoFyhrBbbubKTYKA fuoOEptqBeePsHoFyhrBbbubKTYKA2 = NjYCbbBSwHJznXPGkHgoSUFYuyCF.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.zmSCBdpdHlghSzhrCSqdRrESblcB(WOPJEgIDdQArVapyKhtYfhoFkxGBb.Any);
				JHUnCSJfjLYlukWXZIQzgRJJNuGu = fuoOEptqBeePsHoFyhrBbbubKTYKA2.CNliDePjFozkbvaebGtSjVPspbmN;
				iDvicFAoLsYlcSjadcqddrIaZDhJA = (XInputDeviceSubType)fuoOEptqBeePsHoFyhrBbbubKTYKA2.jAGxgIdGONyatJVreDZIeDNOphhn;
				if (NjYCbbBSwHJznXPGkHgoSUFYuyCF.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.xuCugPvRFWwRrsZkryAkItQbOrTE(default(zXdjGtoSXgQepgzBUgUnoRyUsKYX)).PzrRUsPXmgGcudhEueqwBPMlQwENA)
				{
					RAbqGmrhuNstgLzBgXIEgdzJHWSO = true;
				}
				WRLzUxwuFqfjJOfTRRLIvsmJPpjj = (fuoOEptqBeePsHoFyhrBbbubKTYKA2.spDYOlORxbAPLKtgJmoCLLSGPrTb & FxENUuyYmvDlBSpSFbiuBeeTfNG.VoiceSupported) == FxENUuyYmvDlBSpSFbiuBeeTfNG.VoiceSupported;
				sBMbRhWHEoAeEgdOFjDxUUrdEIzsA();
				TfWnioWbcTGJGMCIdDESKgnISctwA = zXwfAkxDDXiNIAYrYEyQDbgciqhvA.hardwareMapIdentifier.guid;
				if (OQGGcrubiLdgcJkdvFVffesfUYcHA)
				{
					ITuXVExmkWgbdOCWsEfhxXqxaSLjA = StringTools.AddSpacesToCamelCase(iDvicFAoLsYlcSjadcqddrIaZDhJA.ToString());
				}
				else
				{
					ITuXVExmkWgbdOCWsEfhxXqxaSLjA = "XInput " + iDvicFAoLsYlcSjadcqddrIaZDhJA;
				}
				YQZADOkFkGKrHRhclwIjbisLsGZy = $"{ITuXVExmkWgbdOCWsEfhxXqxaSLjA} {(KCcBObYCEHPUZidHZXnAgZbcIagU + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(iDvicFAoLsYlcSjadcqddrIaZDhJA.ToString());
				zXwfAkxDDXiNIAYrYEyQDbgciqhvA.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				EAsBAqdczjEyXuolxxgkFApzoBnfb.Clear();
				NjYCbbBSwHJznXPGkHgoSUFYuyCF.pnZlXAYoghXbjVgEoHleXRDAxsGA();
				OqRgxQgEroCPfYgcyPHHVODtGEKS = MiscTools.CreateGuidHashSHA1(string.Concat(JHUnCSJfjLYlukWXZIQzgRJJNuGu, iDvicFAoLsYlcSjadcqddrIaZDhJA, KCcBObYCEHPUZidHZXnAgZbcIagU));
				VdOWGUpCGwDLoPIweCEpxOPUBBaP = true;
			}
			catch (Exception)
			{
				VdOWGUpCGwDLoPIweCEpxOPUBBaP = false;
				tIcSrQZIsmzGDzVDOVInGHotOVUm = false;
				OqRgxQgEroCPfYgcyPHHVODtGEKS = Guid.Empty;
			}
		}

		private bool pINsmjyOIcFkvEIwVrMygphQtvtv()
		{
			try
			{
				if (iDvicFAoLsYlcSjadcqddrIaZDhJA != (XInputDeviceSubType)NjYCbbBSwHJznXPGkHgoSUFYuyCF.hKUlDKLcVZeLUBLOxAsWsgYYIgsab.zmSCBdpdHlghSzhrCSqdRrESblcB(WOPJEgIDdQArVapyKhtYfhoFkxGBb.Any).jAGxgIdGONyatJVreDZIeDNOphhn)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void SwHBbKErDrjwKzMMdykLiKKdaUKU()
		{
			WRLzUxwuFqfjJOfTRRLIvsmJPpjj = false;
			RAbqGmrhuNstgLzBgXIEgdzJHWSO = false;
			TPSFwhfjkPWAhnDFKGeVDaiYfJQmA = false;
			VdOWGUpCGwDLoPIweCEpxOPUBBaP = false;
		}

		private void yZkJPSFUwrGnPpPRRiqdAkZEsoIb()
		{
			if (RqPCmNoCaToJtpVHObSKAcZfTPNI != null)
			{
				RqPCmNoCaToJtpVHObSKAcZfTPNI();
			}
			NjYCbbBSwHJznXPGkHgoSUFYuyCF.ViAEmhIqzMiECIXohLXRgnZWdCbyb();
		}

		private void ECrszfuhyOGjREaAtUfzunHbBCZJA(bool[] P_0, ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)zXwfAkxDDXiNIAYrYEyQDbgciqhvA.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= uvoUhVBegKwoAboayrPeFmZGqJNE)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				JyHIymrGkkfulducFSNExOxlsExq[i] = sBycLxOojrVeRjKrDDEbREqmntXl(axes_orig[i], P_0, ref P_1);
				if (!hZphhNSqWCRCLvPodGGvDWufwLmHA && JyHIymrGkkfulducFSNExOxlsExq[i] != 0f)
				{
					hZphhNSqWCRCLvPodGGvDWufwLmHA = true;
				}
			}
		}

		private void wdEsLUeAtplYQdmnFUhDBLMztUEh(bool[] P_0, ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)zXwfAkxDDXiNIAYrYEyQDbgciqhvA.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= rTVJPGzrskTlmOVlzCsdKWVcArFM)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				JerwgBTkgnaQxjKotjXleSOjOXtHB[i] = IRqRXzyTLeMQljFcxlTGpbVOtvSC(buttons_orig[i], P_0, ref P_1);
				if (!hZphhNSqWCRCLvPodGGvDWufwLmHA && JerwgBTkgnaQxjKotjXleSOjOXtHB[i])
				{
					hZphhNSqWCRCLvPodGGvDWufwLmHA = true;
				}
			}
		}

		private float sBycLxOojrVeRjKrDDEbREqmntXl(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return SUghHHcNBjiLNAybLhrwFQoVZwWW(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!aAWfFNaxatElmmFdqqrTGVFfKcJc(P_0.sourceButton, P_1))
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

		private float SUghHHcNBjiLNAybLhrwFQoVZwWW(XInputAxis P_0, ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => RxhEziXVhDGFUrIhpfyWqJviVifY.EzudpozLTdfsYlelZIDTJnwuGdak(P_1.vtnTNnfQNIbhVanJVdOghAYhOGUy), 
				XInputAxis.LeftThumbY => RxhEziXVhDGFUrIhpfyWqJviVifY.EzudpozLTdfsYlelZIDTJnwuGdak(P_1.SnwUCpvXZUVvAPpidGinGLsUKyvH), 
				XInputAxis.RightThumbX => RxhEziXVhDGFUrIhpfyWqJviVifY.EzudpozLTdfsYlelZIDTJnwuGdak(P_1.zkywMHlYitfYkZcPZdEhHmiifxOPA), 
				XInputAxis.RightThumbY => RxhEziXVhDGFUrIhpfyWqJviVifY.EzudpozLTdfsYlelZIDTJnwuGdak(P_1.HDtMstWiIzRwyLLrfcMreAlJihTM), 
				XInputAxis.LeftTrigger => RxhEziXVhDGFUrIhpfyWqJviVifY.zKeSVheeuuESJkKSPRrHUojmDPwqA(P_1.jSFgobipUPtkrnkhuwelrYaYytjBA), 
				XInputAxis.RightTrigger => RxhEziXVhDGFUrIhpfyWqJviVifY.zKeSVheeuuESJkKSPRrHUojmDPwqA(P_1.kDuVmktVrCcWvEbzrLDJnPOpJuuK), 
				_ => 0f, 
			};
		}

		private bool IRqRXzyTLeMQljFcxlTGpbVOtvSC(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return aAWfFNaxatElmmFdqqrTGVFfKcJc(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = SUghHHcNBjiLNAybLhrwFQoVZwWW(P_0.sourceAxis, ref P_2);
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

		private bool aAWfFNaxatElmmFdqqrTGVFfKcJc(XInputButton P_0, bool[] P_1)
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

		private void sBMbRhWHEoAeEgdOFjDxUUrdEIzsA()
		{
			zXwfAkxDDXiNIAYrYEyQDbgciqhvA = mrsEhhaUuulOaHeQbOHzkFyhJnxI(PWfuuQDUWJkdEjJaLfRWsgPKXoQi());
			if (zXwfAkxDDXiNIAYrYEyQDbgciqhvA == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			uvoUhVBegKwoAboayrPeFmZGqJNE = zXwfAkxDDXiNIAYrYEyQDbgciqhvA.axisCount;
			rTVJPGzrskTlmOVlzCsdKWVcArFM = zXwfAkxDDXiNIAYrYEyQDbgciqhvA.buttonCount;
		}

		private bool QXltBGaanZDNxhQfTVBsccQJCnJdA(ref zXdjGtoSXgQepgzBUgUnoRyUsKYX P_0)
		{
			if (P_0.zZjRXJhDnAMHynIstfOdaQTdfqVgb > 0 || P_0.ykLWUDtZnCMAeZTvXaUybIxBSUQq > 0)
			{
				return true;
			}
			return false;
		}

		private void wrBoUyEOnCOuSBcnohhYdDUmEVwMA(ref zXdjGtoSXgQepgzBUgUnoRyUsKYX P_0)
		{
			P_0.zZjRXJhDnAMHynIstfOdaQTdfqVgb = 0;
			P_0.ykLWUDtZnCMAeZTvXaUybIxBSUQq = 0;
		}

		private void RiXKkaJBuecVtPfPSDnuHpAcgBWwA(ref zXdjGtoSXgQepgzBUgUnoRyUsKYX P_0, ref zXdjGtoSXgQepgzBUgUnoRyUsKYX P_1)
		{
			P_1.zZjRXJhDnAMHynIstfOdaQTdfqVgb = P_0.zZjRXJhDnAMHynIstfOdaQTdfqVgb;
			P_1.ykLWUDtZnCMAeZTvXaUybIxBSUQq = P_0.ykLWUDtZnCMAeZTvXaUybIxBSUQq;
		}

		private string poLIliIuwqpuFzedXmPlwkAltQcI()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{JHUnCSJfjLYlukWXZIQzgRJJNuGu.ToString()}{iDvicFAoLsYlcSjadcqddrIaZDhJA.ToString()}");
		}

		private void ZkRhJbgoJObkzHfJsSTyruNbQlNU(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = poLIliIuwqpuFzedXmPlwkAltQcI();
			P_0.hardwareAxisCount = ISLEoRRyEdWTqSxynHFMVLgpxPDu;
			P_0.hardwareButtonCount = JyFEBowSoCAzKeyyuTwKARcCAXrfb;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = lTBBxcGXfxqCjjSWLecQITIwIkKFA;
			P_0.hw_supportsVoice = WRLzUxwuFqfjJOfTRRLIvsmJPpjj;
			P_0.hw_supportsVibration = RAbqGmrhuNstgLzBgXIEgdzJHWSO;
			P_0.hw_localVibrationMotorCount = (RAbqGmrhuNstgLzBgXIEgdzJHWSO ? 2 : 0);
			P_0.hw_xInputSubType = iDvicFAoLsYlcSjadcqddrIaZDhJA;
		}

		private void uYhmoHIdQoMHsMysZMIcANJtdcIr(BridgedController P_0)
		{
			ZkRhJbgoJObkzHfJsSTyruNbQlNU(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = zXwfAkxDDXiNIAYrYEyQDbgciqhvA.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + ZqOuPYAyxOpuaXcsjbuLiSqsnXKoA;
			P_0.productName = "XInput " + lTBBxcGXfxqCjjSWLecQITIwIkKFA;
			P_0.isXInputDevice = true;
			P_0.axisCount = uvoUhVBegKwoAboayrPeFmZGqJNE;
			P_0.buttonCount = rTVJPGzrskTlmOVlzCsdKWVcArFM;
			P_0.controllerTypeGuid = TfWnioWbcTGJGMCIdDESKgnISctwA;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			QciqqOEUhUCZQXwGcJCSaUcOHFum(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void BrPmkfuCVPQnPxndNyLLbfyaaMUS()
		{
			try
			{
				QciqqOEUhUCZQXwGcJCSaUcOHFum(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void QciqqOEUhUCZQXwGcJCSaUcOHFum(bool P_0)
		{
			if (FSZigIKWSDrpkHfFGhjMfQnqBaIx)
			{
				return;
			}
			if (P_0)
			{
				if (qYJlZLrVTKUIhgYzVshTfFULGZzAA)
				{
					NjYCbbBSwHJznXPGkHgoSUFYuyCF.xgOygGzNNhAvBdorNSkuuhJTPuDe();
				}
				if (NjYCbbBSwHJznXPGkHgoSUFYuyCF != null)
				{
					NjYCbbBSwHJznXPGkHgoSUFYuyCF.Dispose();
				}
			}
			FSZigIKWSDrpkHfFGhjMfQnqBaIx = true;
		}
	}

	private class LPtbnBHaijhvgxOFsRrtgDlUKcUuA
	{
		private class nRYsdMBEhGDKsEoNmjdAGKUIUAqPA
		{
			public bool hXpHJMCrecgcXhDafmbUBDLfdqMR;

			public int UyygfKRjimvxSAaBxcjwnpDjdhsV;

			public XInputDeviceSubType HnfEEFJcFMGAuhGhhscvblHZeqrjb;

			public void gWUemtFKSBgjwWwjjizVhqhDKJbJA(NKwSfsGyUIazodrgxUlsBzqRhiXk P_0, bool P_1)
			{
				hXpHJMCrecgcXhDafmbUBDLfdqMR = P_1;
				UyygfKRjimvxSAaBxcjwnpDjdhsV = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				HnfEEFJcFMGAuhGhhscvblHZeqrjb = P_0.iDvicFAoLsYlcSjadcqddrIaZDhJA;
			}

			public nRYsdMBEhGDKsEoNmjdAGKUIUAqPA(int P_0, XInputDeviceSubType P_1)
			{
				UyygfKRjimvxSAaBxcjwnpDjdhsV = P_0;
				HnfEEFJcFMGAuhGhhscvblHZeqrjb = P_1;
			}
		}

		private List<nRYsdMBEhGDKsEoNmjdAGKUIUAqPA> BPZFDWFhLfFVFKVnsijfjLeocerhA;

		public LPtbnBHaijhvgxOFsRrtgDlUKcUuA()
		{
			BPZFDWFhLfFVFKVnsijfjLeocerhA = new List<nRYsdMBEhGDKsEoNmjdAGKUIUAqPA>();
		}

		public void aSwurzbbZPzCVruPpyCiXzYYqUQD(NKwSfsGyUIazodrgxUlsBzqRhiXk P_0, bool P_1)
		{
			if (QPbBQZLbTSzrWHLvYXVznpuAVCEc(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.iDvicFAoLsYlcSjadcqddrIaZDhJA, true) < 0)
			{
				nRYsdMBEhGDKsEoNmjdAGKUIUAqPA nRYsdMBEhGDKsEoNmjdAGKUIUAqPA2 = new nRYsdMBEhGDKsEoNmjdAGKUIUAqPA(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.iDvicFAoLsYlcSjadcqddrIaZDhJA);
				nRYsdMBEhGDKsEoNmjdAGKUIUAqPA2.hXpHJMCrecgcXhDafmbUBDLfdqMR = P_1;
				BPZFDWFhLfFVFKVnsijfjLeocerhA.Add(nRYsdMBEhGDKsEoNmjdAGKUIUAqPA2);
			}
		}

		public void xpLvANbLecKFjsOmWWSIzGhSpBdm(int P_0, NKwSfsGyUIazodrgxUlsBzqRhiXk P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < BPZFDWFhLfFVFKVnsijfjLeocerhA.Count)
			{
				BPZFDWFhLfFVFKVnsijfjLeocerhA[P_0].gWUemtFKSBgjwWwjjizVhqhDKJbJA(P_1, P_2);
			}
		}

		public int XhIgIRAcTqvpZUMjBYnSayyDPeZG(XInputDeviceSubType P_0, bool P_1)
		{
			int count = BPZFDWFhLfFVFKVnsijfjLeocerhA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !BPZFDWFhLfFVFKVnsijfjLeocerhA[i].hXpHJMCrecgcXhDafmbUBDLfdqMR) && BPZFDWFhLfFVFKVnsijfjLeocerhA[i].HnfEEFJcFMGAuhGhhscvblHZeqrjb == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int QPbBQZLbTSzrWHLvYXVznpuAVCEc(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = BPZFDWFhLfFVFKVnsijfjLeocerhA.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !BPZFDWFhLfFVFKVnsijfjLeocerhA[i].hXpHJMCrecgcXhDafmbUBDLfdqMR) && BPZFDWFhLfFVFKVnsijfjLeocerhA[i].UyygfKRjimvxSAaBxcjwnpDjdhsV == P_0 && BPZFDWFhLfFVFKVnsijfjLeocerhA[i].HnfEEFJcFMGAuhGhhscvblHZeqrjb == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int JzjKpiNHduhLNkyLEqvyqvydKfhWA(int P_0)
		{
			if (P_0 < 0 || P_0 >= BPZFDWFhLfFVFKVnsijfjLeocerhA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return BPZFDWFhLfFVFKVnsijfjLeocerhA[P_0].UyygfKRjimvxSAaBxcjwnpDjdhsV;
		}

		public void YaQFXagQcrEcACcxicjlcNQeWbyXA(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < BPZFDWFhLfFVFKVnsijfjLeocerhA.Count)
			{
				BPZFDWFhLfFVFKVnsijfjLeocerhA[P_0].hXpHJMCrecgcXhDafmbUBDLfdqMR = P_1;
			}
		}
	}

	private class nGfzdqtWsvorQWPEtueWuDFGIMAG
	{
		public bool HWTyELSzOtdZBEdYpBKmfRaNMTqe;

		private double VHFLelSklZECEIIeJrwwLaVsyTSe;

		public float iBCqqdgsVoorHAnUCtyaBGoDbcoq;

		public nGfzdqtWsvorQWPEtueWuDFGIMAG()
		{
		}

		public nGfzdqtWsvorQWPEtueWuDFGIMAG(float P_0)
		{
			iBCqqdgsVoorHAnUCtyaBGoDbcoq = P_0;
		}

		public void yDDOLfUSwxKbWNbZRiaNsunoCGHj()
		{
			HWTyELSzOtdZBEdYpBKmfRaNMTqe = true;
			VHFLelSklZECEIIeJrwwLaVsyTSe = (double)iBCqqdgsVoorHAnUCtyaBGoDbcoq + ReInput.unscaledTime;
		}

		public void xaAclxgmqxENMYVLBFfJejZCdbJYA(float P_0)
		{
			HWTyELSzOtdZBEdYpBKmfRaNMTqe = true;
			iBCqqdgsVoorHAnUCtyaBGoDbcoq = P_0;
			VHFLelSklZECEIIeJrwwLaVsyTSe = (double)iBCqqdgsVoorHAnUCtyaBGoDbcoq + ReInput.unscaledTime;
		}

		public bool BVzFgQqFfGBNmxAQNBGAkWCYIJzEA()
		{
			if (!HWTyELSzOtdZBEdYpBKmfRaNMTqe)
			{
				return false;
			}
			if (ReInput.unscaledTime >= VHFLelSklZECEIIeJrwwLaVsyTSe)
			{
				HWTyELSzOtdZBEdYpBKmfRaNMTqe = false;
				return true;
			}
			return false;
		}

		public void YwEUaSsnBDjviCtcWDgciKwfzyLVb()
		{
			HWTyELSzOtdZBEdYpBKmfRaNMTqe = false;
			VHFLelSklZECEIIeJrwwLaVsyTSe = 0.0;
		}

		public void kwNJvCFNpCVUvBmRRDVVvhwxcGAjA(float P_0)
		{
			iBCqqdgsVoorHAnUCtyaBGoDbcoq = P_0;
		}

		public nGfzdqtWsvorQWPEtueWuDFGIMAG plkVSljknubORBigxsbXhjWSAxORA()
		{
			return (nGfzdqtWsvorQWPEtueWuDFGIMAG)MemberwiseClone();
		}
	}

	public class RxhEziXVhDGFUrIhpfyWqJviVifY : IDisposable
	{
		public readonly GwZmjtOSXdzmuypRqNJNGfDirwh hKUlDKLcVZeLUBLOxAsWsgYYIgsab;

		private readonly Controller.Extension lNuhgvzyjnuOCsoSnGKTswdETuUi;

		public EByVAlkqcfWmhSOeNHgpLgXrAAEZ DNYKWAQmcEXjdInfFKpzgciMUpJL;

		private bool zZFPGzDkiOgVjykcjJtWmijuAIgJ;

		private readonly ButtonLoopSet MEhjzSiqqMtxZaBFHPzokKtgrppp;

		private EByVAlkqcfWmhSOeNHgpLgXrAAEZ UNFrDPGBfKtxXbKTcoJsrCxXdEhI;

		private bool ONWPsXAOfXSEtFwWFhfBWfEMJXfV;

		private DualThreadLowLevelInputEventQueue hYmbnDeTEQGchpjPXTUzxNAZFgyd;

		private readonly object FjlDOhvRNwbAAsbaSljqNTLmEiDO;

		private RingBuffer<zXdjGtoSXgQepgzBUgUnoRyUsKYX> EkaJSxTuspTRmwodZgeKmidRDxUhA = new RingBuffer<zXdjGtoSXgQepgzBUgUnoRyUsKYX>(5);

		private RingBuffer<zXdjGtoSXgQepgzBUgUnoRyUsKYX> eahblwraCJSmMZjxvygsfGlgezkU = new RingBuffer<zXdjGtoSXgQepgzBUgUnoRyUsKYX>(5);

		private readonly object sOmAXbEcJobJNGxoKwjFBjDMpqJj = new object();

		private readonly object TqXleOqfjJgwBcTHyPWhaYxAUpnZb = new object();

		private zXdjGtoSXgQepgzBUgUnoRyUsKYX jStBdNVfscBKKhyQnzQOVBsNrnRmA;

		private double jnrWbYmdwIhHsdWKuwEmhuHTSqEc;

		private bool SZYRTVxFjwTCxGKrJZWBbpyLcSZv;

		public Controller.Extension OmAnUdNIQvkkxyjPlBQLifuEXNyq => lNuhgvzyjnuOCsoSnGKTswdETuUi;

		public bool[] FUenNpiFupAgxJqARhBncOlPSCbz => MEhjzSiqqMtxZaBFHPzokKtgrppp.Current.effectiveValue;

		public RxhEziXVhDGFUrIhpfyWqJviVifY(int P_0, UpdateLoopSetting P_1)
		{
			hKUlDKLcVZeLUBLOxAsWsgYYIgsab = new GwZmjtOSXdzmuypRqNJNGfDirwh((oGeSPlMkzxnYMibOoIPBDUUVLqkRA)P_0);
			MEhjzSiqqMtxZaBFHPzokKtgrppp = new ButtonLoopSet(P_1, 15);
			FjlDOhvRNwbAAsbaSljqNTLmEiDO = new object();
			hYmbnDeTEQGchpjPXTUzxNAZFgyd = new DualThreadLowLevelInputEventQueue((int)((float)WNDYrcPDOUObmqnBCmqijYTVsDhn.CPLaRrFzUcOrwvDuUKrdhlDtwzfD * 0.25f), 15, 6, 0);
			lNuhgvzyjnuOCsoSnGKTswdETuUi = new XInputControllerExtension(this);
		}

		public void dvPNZIKllNVvhYrCwSUiNJgAiWEt()
		{
			MEhjzSiqqMtxZaBFHPzokKtgrppp.SetUpdateLoop(ReInput.currentUpdateLoop);
			GhweeQgUruwTdmpPyjHmEdgbcYZrB(ref DNYKWAQmcEXjdInfFKpzgciMUpJL);
		}

		public void WUWFiHxRymBjbzhvAIYUNdsnGfte()
		{
			hAPaNsfrwCZwaTNHvxPcLXDkpCVz();
			MEhjzSiqqMtxZaBFHPzokKtgrppp.Current.ClearWasTrueThisFrame();
		}

		public void pnZlXAYoghXbjVgEoHleXRDAxsGA()
		{
			zTWFhHCrGeKLNslxDsvORAAnglDbA();
			zZFPGzDkiOgVjykcjJtWmijuAIgJ = true;
			ONWPsXAOfXSEtFwWFhfBWfEMJXfV = hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ysKdRoCGYgoztDHBWcWRNsdzgyUaA;
		}

		public void ViAEmhIqzMiECIXohLXRgnZWdCbyb()
		{
			zZFPGzDkiOgVjykcjJtWmijuAIgJ = false;
			ONWPsXAOfXSEtFwWFhfBWfEMJXfV = false;
			zTWFhHCrGeKLNslxDsvORAAnglDbA();
		}

		public bool MPcLytnfmKawsENMwkDHaGVHbRFm(WGgLqpogYRSujebBKDmwAhrUAWUMA P_0)
		{
			return P_0 switch
			{
				WGgLqpogYRSujebBKDmwAhrUAWUMA.Synchronous => ONWPsXAOfXSEtFwWFhfBWfEMJXfV = hKUlDKLcVZeLUBLOxAsWsgYYIgsab.ysKdRoCGYgoztDHBWcWRNsdzgyUaA, 
				WGgLqpogYRSujebBKDmwAhrUAWUMA.Asynchronous => ONWPsXAOfXSEtFwWFhfBWfEMJXfV, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void mqvNuGrnYijMLOOfxxnxiOPvoFCp(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				jStBdNVfscBKKhyQnzQOVBsNrnRmA.zZjRXJhDnAMHynIstfOdaQTdfqVgb = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				jStBdNVfscBKKhyQnzQOVBsNrnRmA.ykLWUDtZnCMAeZTvXaUybIxBSUQq = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			NeESFxTVSmTiyTlTtZIdrbASdWuHA();
		}

		public void sABZXzENSHbCMumCpuWaQvqFkbjt()
		{
			jStBdNVfscBKKhyQnzQOVBsNrnRmA.zZjRXJhDnAMHynIstfOdaQTdfqVgb = 0;
			jStBdNVfscBKKhyQnzQOVBsNrnRmA.ykLWUDtZnCMAeZTvXaUybIxBSUQq = 0;
			NeESFxTVSmTiyTlTtZIdrbASdWuHA();
		}

		public void xgOygGzNNhAvBdorNSkuuhJTPuDe()
		{
			jStBdNVfscBKKhyQnzQOVBsNrnRmA.zZjRXJhDnAMHynIstfOdaQTdfqVgb = 0;
			jStBdNVfscBKKhyQnzQOVBsNrnRmA.ykLWUDtZnCMAeZTvXaUybIxBSUQq = 0;
			lock (TqXleOqfjJgwBcTHyPWhaYxAUpnZb)
			{
				lock (sOmAXbEcJobJNGxoKwjFBjDMpqJj)
				{
					EkaJSxTuspTRmwodZgeKmidRDxUhA.Clear();
					eahblwraCJSmMZjxvygsfGlgezkU.Clear();
					UprkPkqSrDASWcaWlqAAYyIJGkEc(hKUlDKLcVZeLUBLOxAsWsgYYIgsab, jStBdNVfscBKKhyQnzQOVBsNrnRmA, ref jnrWbYmdwIhHsdWKuwEmhuHTSqEc);
				}
			}
		}

		public void glXTRXePbLZpQtbEwYBQYPqcdSgN()
		{
			if (!zZFPGzDkiOgVjykcjJtWmijuAIgJ || !ONWPsXAOfXSEtFwWFhfBWfEMJXfV)
			{
				return;
			}
			qyFLqlfCGZvCiuLpWgnVcPlGjVSDb qyFLqlfCGZvCiuLpWgnVcPlGjVSDb2;
			double realTime;
			try
			{
				if (!hKUlDKLcVZeLUBLOxAsWsgYYIgsab.wnzrzyUKnzcUoBwESKmGsUDcQheW(out qyFLqlfCGZvCiuLpWgnVcPlGjVSDb2))
				{
					ONWPsXAOfXSEtFwWFhfBWfEMJXfV = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				ONWPsXAOfXSEtFwWFhfBWfEMJXfV = false;
				return;
			}
			lock (FjlDOhvRNwbAAsbaSljqNTLmEiDO)
			{
				if (!ESFWWIEYosaNojeKectpjJOsLWrKA(qyFLqlfCGZvCiuLpWgnVcPlGjVSDb2.EkvuNARgfOkwGfEReclobpJFMAEHA, UNFrDPGBfKtxXbKTcoJsrCxXdEhI))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = hYmbnDeTEQGchpjPXTUzxNAZFgyd.T_CreateEvent())
					{
						kQQLKsTUVJdpcCedzHavZzPIjWBD(ref qyFLqlfCGZvCiuLpWgnVcPlGjVSDb2.EkvuNARgfOkwGfEReclobpJFMAEHA, realTime, newEventWrapper.Event);
					}
					UNFrDPGBfKtxXbKTcoJsrCxXdEhI = qyFLqlfCGZvCiuLpWgnVcPlGjVSDb2.EkvuNARgfOkwGfEReclobpJFMAEHA;
				}
			}
		}

		public void maTepQdDOmhEciEwVkmvDPagTTcU()
		{
			if (!zZFPGzDkiOgVjykcjJtWmijuAIgJ || !ONWPsXAOfXSEtFwWFhfBWfEMJXfV || ReInput.realTime < jnrWbYmdwIhHsdWKuwEmhuHTSqEc + 0.009999999776482582)
			{
				return;
			}
			lock (TqXleOqfjJgwBcTHyPWhaYxAUpnZb)
			{
				lock (sOmAXbEcJobJNGxoKwjFBjDMpqJj)
				{
					MiscTools.Swap(ref EkaJSxTuspTRmwodZgeKmidRDxUhA, ref eahblwraCJSmMZjxvygsfGlgezkU);
				}
				cDFBRkDVKQfrIRPHdPXXbRVERhcSA(eahblwraCJSmMZjxvygsfGlgezkU, hKUlDKLcVZeLUBLOxAsWsgYYIgsab, ref jnrWbYmdwIhHsdWKuwEmhuHTSqEc);
			}
		}

		private void hAPaNsfrwCZwaTNHvxPcLXDkpCVz()
		{
			umAQitkZuOLgJBDOXrLjSUfSGYcj();
		}

		private void umAQitkZuOLgJBDOXrLjSUfSGYcj()
		{
			if (!(ReInput.realTime < jnrWbYmdwIhHsdWKuwEmhuHTSqEc + 1.5) && (!Mathf.Approximately((int)jStBdNVfscBKKhyQnzQOVBsNrnRmA.zZjRXJhDnAMHynIstfOdaQTdfqVgb, 0f) || !Mathf.Approximately((int)jStBdNVfscBKKhyQnzQOVBsNrnRmA.ykLWUDtZnCMAeZTvXaUybIxBSUQq, 0f)))
			{
				NeESFxTVSmTiyTlTtZIdrbASdWuHA();
			}
		}

		private void NeESFxTVSmTiyTlTtZIdrbASdWuHA()
		{
			lock (sOmAXbEcJobJNGxoKwjFBjDMpqJj)
			{
				EkaJSxTuspTRmwodZgeKmidRDxUhA.Enqueue(jStBdNVfscBKKhyQnzQOVBsNrnRmA);
			}
		}

		private static void cDFBRkDVKQfrIRPHdPXXbRVERhcSA(RingBuffer<zXdjGtoSXgQepgzBUgUnoRyUsKYX> P_0, GwZmjtOSXdzmuypRqNJNGfDirwh P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				UprkPkqSrDASWcaWlqAAYyIJGkEc(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void UprkPkqSrDASWcaWlqAAYyIJGkEc(GwZmjtOSXdzmuypRqNJNGfDirwh P_0, zXdjGtoSXgQepgzBUgUnoRyUsKYX P_1, ref double P_2)
		{
			try
			{
				P_0.xuCugPvRFWwRrsZkryAkItQbOrTE(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void GhweeQgUruwTdmpPyjHmEdgbcYZrB(ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_0)
		{
			while (hYmbnDeTEQGchpjPXTUzxNAZFgyd.ProcessNewEvents())
			{
				qAfkqWgULwpnFcQCThZHsjAuYMVV(ref P_0, ref hYmbnDeTEQGchpjPXTUzxNAZFgyd.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					MEhjzSiqqMtxZaBFHPzokKtgrppp.SetValue(i, moVjBLfQrEbTLzszBbKmejJjFIhV((int)P_0.XDbCVMJWOOaALajbFzCeBQPthAHX, i), hYmbnDeTEQGchpjPXTUzxNAZFgyd.currentEvent.GetTimestamp());
				}
			}
		}

		private void kQQLKsTUVJdpcCedzHavZzPIjWBD(ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int xDbCVMJWOOaALajbFzCeBQPthAHX = (int)P_0.XDbCVMJWOOaALajbFzCeBQPthAHX;
			P_2.SetButtonsBitMask((xDbCVMJWOOaALajbFzCeBQPthAHX & 0x7FF) | ((xDbCVMJWOOaALajbFzCeBQPthAHX & (xDbCVMJWOOaALajbFzCeBQPthAHX & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, EzudpozLTdfsYlelZIDTJnwuGdak(P_0.vtnTNnfQNIbhVanJVdOghAYhOGUy));
			P_2.SetAxisValue(1, EzudpozLTdfsYlelZIDTJnwuGdak(P_0.SnwUCpvXZUVvAPpidGinGLsUKyvH));
			P_2.SetAxisValue(2, EzudpozLTdfsYlelZIDTJnwuGdak(P_0.zkywMHlYitfYkZcPZdEhHmiifxOPA));
			P_2.SetAxisValue(3, EzudpozLTdfsYlelZIDTJnwuGdak(P_0.HDtMstWiIzRwyLLrfcMreAlJihTM));
			P_2.SetAxisValue(4, zKeSVheeuuESJkKSPRrHUojmDPwqA(P_0.jSFgobipUPtkrnkhuwelrYaYytjBA));
			P_2.SetAxisValue(5, zKeSVheeuuESJkKSPRrHUojmDPwqA(P_0.kDuVmktVrCcWvEbzrLDJnPOpJuuK));
		}

		private void qAfkqWgULwpnFcQCThZHsjAuYMVV(ref EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.XDbCVMJWOOaALajbFzCeBQPthAHX = (NkyjYUYPaxeBNspMhdHTJtwrghLAb)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.vtnTNnfQNIbhVanJVdOghAYhOGUy = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.SnwUCpvXZUVvAPpidGinGLsUKyvH = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.zkywMHlYitfYkZcPZdEhHmiifxOPA = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.HDtMstWiIzRwyLLrfcMreAlJihTM = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.jSFgobipUPtkrnkhuwelrYaYytjBA = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.kDuVmktVrCcWvEbzrLDJnPOpJuuK = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool moVjBLfQrEbTLzszBbKmejJjFIhV(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void zTWFhHCrGeKLNslxDsvORAAnglDbA()
		{
			lock (FjlDOhvRNwbAAsbaSljqNTLmEiDO)
			{
				DNYKWAQmcEXjdInfFKpzgciMUpJL = default(EByVAlkqcfWmhSOeNHgpLgXrAAEZ);
				UNFrDPGBfKtxXbKTcoJsrCxXdEhI = default(EByVAlkqcfWmhSOeNHgpLgXrAAEZ);
				MEhjzSiqqMtxZaBFHPzokKtgrppp.Clear();
				hYmbnDeTEQGchpjPXTUzxNAZFgyd.Clear();
			}
		}

		public void Dispose()
		{
			EhQnIembqiGZyBWEWnqCGgTHfDvjA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void fKCJvorydbNgaIpndbplKEHjvjmMA()
		{
			try
			{
				EhQnIembqiGZyBWEWnqCGgTHfDvjA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void EhQnIembqiGZyBWEWnqCGgTHfDvjA(bool P_0)
		{
			if (!SZYRTVxFjwTCxGKrJZWBbpyLcSZv)
			{
				if (P_0)
				{
					hYmbnDeTEQGchpjPXTUzxNAZFgyd.Dispose();
				}
				SZYRTVxFjwTCxGKrJZWBbpyLcSZv = true;
			}
		}

		public static float EzudpozLTdfsYlelZIDTJnwuGdak(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float zKeSVheeuuESJkKSPRrHUojmDPwqA(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool ESFWWIEYosaNojeKectpjJOsLWrKA(EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_0, EByVAlkqcfWmhSOeNHgpLgXrAAEZ P_1)
		{
			if (P_0.XDbCVMJWOOaALajbFzCeBQPthAHX == P_1.XDbCVMJWOOaALajbFzCeBQPthAHX && P_0.jSFgobipUPtkrnkhuwelrYaYytjBA == P_1.jSFgobipUPtkrnkhuwelrYaYytjBA && P_0.kDuVmktVrCcWvEbzrLDJnPOpJuuK == P_1.kDuVmktVrCcWvEbzrLDJnPOpJuuK && P_0.vtnTNnfQNIbhVanJVdOghAYhOGUy == P_1.vtnTNnfQNIbhVanJVdOghAYhOGUy && P_0.SnwUCpvXZUVvAPpidGinGLsUKyvH == P_1.SnwUCpvXZUVvAPpidGinGLsUKyvH && P_0.zkywMHlYitfYkZcPZdEhHmiifxOPA == P_1.zkywMHlYitfYkZcPZdEhHmiifxOPA)
			{
				return P_0.HDtMstWiIzRwyLLrfcMreAlJihTM == P_1.HDtMstWiIzRwyLLrfcMreAlJihTM;
			}
			return false;
		}
	}

	public enum WGgLqpogYRSujebBKDmwAhrUAWUMA
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int ZXYeSuaSoDIgTLxlosneBxrJpZEW = 4;

	public const int tfGzdKSGMGFAwnEOVEdhbuCzivFb = 32768;

	public const int bfwWXHJItruiSqElUUuYULkvFufbA = -32768;

	public const int mSMMdfQsfQKVqjOGolwSshuIqQEI = 255;

	public const int HKrjZLBQRDevnBdDDPePvVFENukj = 0;

	public const int iPpBZUbvmScvNJscVpwDNuTAFEQUA = 18;

	public const int dEMXmqFWPiPeCRnYDlDPRPGRfqcHA = 14;

	public const int oNNspdtMzhjcKXCqEUvqKcWdJRho = 6;

	public const int HgZwNgHErPudfxbfJtKdwyEyaSq = 15;

	private NKwSfsGyUIazodrgxUlsBzqRhiXk[] cnhUDNspvcCoAWwfqwujPuvZHTxc;

	private bool rYSjWWBVAoAARaaHxdRJsvPiJQxl;

	private nGfzdqtWsvorQWPEtueWuDFGIMAG XotyTcLnTJsOUdfOWykYCItQeEhD;

	private LPtbnBHaijhvgxOFsRrtgDlUKcUuA temyvKUmPLOFAQBhzoxlFbCtqiDP;

	private global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool> vhPEygimrvvanAmFoeiOHWLgtHbNB;

	private bool[] BjnhApIFANpKjlhZmxMEFZVgITxX;

	private bool[] FuhdeVpHevKeRfLQEQUrmqDvYKzW;

	private bool ldHyENYbkkfUJBhlZrMctDzZgWYH;

	private readonly bool uOcGiEYSeFDuBttFOYaXhADsOIPE;

	private readonly UpdateLoopSetting DmIExlrDrkEZjXwgIUkZEHmRulhN;

	private UpdateLoopType huuGNUeMeAHjXPOZhEBMJKNCIfcoA;

	private UpdateLoopType wKqExjewHLoFCxprWpvTyNwmSgujA;

	private Action<int, ControllerDataUpdater> lHpWYVOVhqPYmoHSpKKkcjKDBjyg;

	private bool IWwENtMNKHLBpjUbxmqDQChzpPWJ;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qjgSDWAEJmdXqCBASRJeHHKcORahB;

	private Func<int> HTMzNkAyPkNnwjYyTBjVroNbwpKp;

	private Func<PidVid, bool> SBFYNgSpGxlNbaOqzAkmPbOhhXihA;

	private static Guid[] GpBzUCJmCetIOwlCtzVEGgTJdmzcA;

	private static string[] CkdqhvzCHBfpiSACyinGkIiQJwyI;

	private static string[] JaOMlCXSkatdvREhToHKefwAqprt;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (cnhUDNspvcCoAWwfqwujPuvZHTxc[i].qYJlZLrVTKUIhgYzVshTfFULGZzAA)
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

	iSWDNvpsUMPLKHvHHpHbIawpGErjA MpfSAJjorzYIlCIHNIPpIhZKdISt.gdZHATbzDdJgRdeISdhNQaKmJUeU => iSWDNvpsUMPLKHvHHpHbIawpGErjA.XInput;

	public YeDLvUUmeuKtQrgSaWuhUANSLKCe(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		uOcGiEYSeFDuBttFOYaXhADsOIPE = P_0;
		DmIExlrDrkEZjXwgIUkZEHmRulhN = P_1;
		SBFYNgSpGxlNbaOqzAkmPbOhhXihA = P_4;
		IWwENtMNKHLBpjUbxmqDQChzpPWJ = true;
		try
		{
			if (!xRUGkURngkKlvPjZVWYliaTXRZSh.gdnQSbZRzfGAoPcWWvoilGRyUqPU(out var pYOnYkqGRQCrLrgLYQZQXwPkTLVu2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (pYOnYkqGRQCrLrgLYQZQXwPkTLVu2 < pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			qjgSDWAEJmdXqCBASRJeHHKcORahB = P_2;
			HTMzNkAyPkNnwjYyTBjVroNbwpKp = P_3;
			ldHyENYbkkfUJBhlZrMctDzZgWYH = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(DmIExlrDrkEZjXwgIUkZEHmRulhN, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					wKqExjewHLoFCxprWpvTyNwmSgujA = list[num2];
				}
			}
			vhPEygimrvvanAmFoeiOHWLgtHbNB = new global::tgFAlfAsXFDhZaOgiAxWJMIbRLIcA<bool>(true, meBnDIfgxJYvrFypmzPIVRvkUdJD);
			BjnhApIFANpKjlhZmxMEFZVgITxX = new bool[4];
			FuhdeVpHevKeRfLQEQUrmqDvYKzW = new bool[4];
			lHpWYVOVhqPYmoHSpKKkcjKDBjyg = UpdateControllerData;
			if (ldHyENYbkkfUJBhlZrMctDzZgWYH)
			{
				YvqHPebIbBycsRwmLemynFmbANHAA();
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
		if (IWwENtMNKHLBpjUbxmqDQChzpPWJ)
		{
			XotyTcLnTJsOUdfOWykYCItQeEhD = new nGfzdqtWsvorQWPEtueWuDFGIMAG(1f);
		}
		temyvKUmPLOFAQBhzoxlFbCtqiDP = new LPtbnBHaijhvgxOFsRrtgDlUKcUuA();
		if (cnhUDNspvcCoAWwfqwujPuvZHTxc == null)
		{
			cnhUDNspvcCoAWwfqwujPuvZHTxc = new NKwSfsGyUIazodrgxUlsBzqRhiXk[4];
			for (int i = 0; i < 4; i++)
			{
				RxhEziXVhDGFUrIhpfyWqJviVifY rxhEziXVhDGFUrIhpfyWqJviVifY = new RxhEziXVhDGFUrIhpfyWqJviVifY(i, DmIExlrDrkEZjXwgIUkZEHmRulhN);
				WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent += rxhEziXVhDGFUrIhpfyWqJviVifY.glXTRXePbLZpQtbEwYBQYPqcdSgN;
				WNDYrcPDOUObmqnBCmqijYTVsDhn.nytSzNVIhUWoXZDzKGaUmjqGlQXF.ThreadUpdateEvent += rxhEziXVhDGFUrIhpfyWqJviVifY.maTepQdDOmhEciEwVkmvDPagTTcU;
				cnhUDNspvcCoAWwfqwujPuvZHTxc[i] = new NKwSfsGyUIazodrgxUlsBzqRhiXk(i, ldHyENYbkkfUJBhlZrMctDzZgWYH, rxhEziXVhDGFUrIhpfyWqJviVifY, qjgSDWAEJmdXqCBASRJeHHKcORahB, SystemDeviceDisconnected);
			}
		}
		YwXfGNBiEhjdPAdryzWHmJrJGVPA(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		huuGNUeMeAHjXPOZhEBMJKNCIfcoA = currentUpdateLoop;
		HbMaxUJrhitXdRkcrrGgpnEyDKhq();
		for (int i = 0; i < 4; i++)
		{
			if (cnhUDNspvcCoAWwfqwujPuvZHTxc[i] != null && cnhUDNspvcCoAWwfqwujPuvZHTxc[i].qYJlZLrVTKUIhgYzVshTfFULGZzAA)
			{
				cnhUDNspvcCoAWwfqwujPuvZHTxc[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (vhPEygimrvvanAmFoeiOHWLgtHbNB != null)
		{
			vhPEygimrvvanAmFoeiOHWLgtHbNB.FBethkzoPOdpxwrHTNdcWabofFyD();
		}
		if (cnhUDNspvcCoAWwfqwujPuvZHTxc != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (cnhUDNspvcCoAWwfqwujPuvZHTxc[i] != null)
				{
					if (WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX != null)
					{
						WNDYrcPDOUObmqnBCmqijYTVsDhn.stbFXYGdqGZahOUHVobnVZEOHNEX.ThreadUpdateEvent -= cnhUDNspvcCoAWwfqwujPuvZHTxc[i].NjYCbbBSwHJznXPGkHgoSUFYuyCF.glXTRXePbLZpQtbEwYBQYPqcdSgN;
					}
					if (WNDYrcPDOUObmqnBCmqijYTVsDhn.nytSzNVIhUWoXZDzKGaUmjqGlQXF != null)
					{
						WNDYrcPDOUObmqnBCmqijYTVsDhn.nytSzNVIhUWoXZDzKGaUmjqGlQXF.ThreadUpdateEvent -= cnhUDNspvcCoAWwfqwujPuvZHTxc[i].NjYCbbBSwHJznXPGkHgoSUFYuyCF.maTepQdDOmhEciEwVkmvDPagTTcU;
					}
					cnhUDNspvcCoAWwfqwujPuvZHTxc[i].Dispose();
				}
			}
		}
		xRUGkURngkKlvPjZVWYliaTXRZSh.lNdXqbeFVRGPGPkUeuXBIetBlnjO();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return lHpWYVOVhqPYmoHSpKKkcjKDBjyg;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		cnhUDNspvcCoAWwfqwujPuvZHTxc[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		YwXfGNBiEhjdPAdryzWHmJrJGVPA(true);
		KLAWATVdQbIRsCHrvfiJhfpnHJzwA();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		YwXfGNBiEhjdPAdryzWHmJrJGVPA(true);
		KLAWATVdQbIRsCHrvfiJhfpnHJzwA();
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

	bool MpfSAJjorzYIlCIHNIPpIhZKdISt.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (SBFYNgSpGxlNbaOqzAkmPbOhhXihA(pidVid))
		{
			return false;
		}
		return IUShrVBkBlNnfjEYIootzAdNHscBA(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool yRuFosYjTEveBJMxmlcmXAFmNJNi()
	{
		if (huuGNUeMeAHjXPOZhEBMJKNCIfcoA != wKqExjewHLoFCxprWpvTyNwmSgujA)
		{
			return false;
		}
		bool num = XotyTcLnTJsOUdfOWykYCItQeEhD.BVzFgQqFfGBNmxAQNBGAkWCYIJzEA();
		if (num)
		{
			YwXfGNBiEhjdPAdryzWHmJrJGVPA(true);
		}
		return num;
	}

	private void YwXfGNBiEhjdPAdryzWHmJrJGVPA(bool P_0)
	{
		rYSjWWBVAoAARaaHxdRJsvPiJQxl = P_0;
		if (IWwENtMNKHLBpjUbxmqDQChzpPWJ)
		{
			XotyTcLnTJsOUdfOWykYCItQeEhD.yDDOLfUSwxKbWNbZRiaNsunoCGHj();
		}
	}

	private void KLAWATVdQbIRsCHrvfiJhfpnHJzwA()
	{
		if (vhPEygimrvvanAmFoeiOHWLgtHbNB != null)
		{
			vhPEygimrvvanAmFoeiOHWLgtHbNB.QtFVeQtTlkQQbDQNpqQaZpNWShhT();
		}
	}

	private void YvqHPebIbBycsRwmLemynFmbANHAA()
	{
		_ = new GwZmjtOSXdzmuypRqNJNGfDirwh().ysKdRoCGYgoztDHBWcWRNsdzgyUaA;
	}

	private void HbMaxUJrhitXdRkcrrGgpnEyDKhq()
	{
		bool flag = false;
		if (IWwENtMNKHLBpjUbxmqDQChzpPWJ)
		{
			flag = yRuFosYjTEveBJMxmlcmXAFmNJNi();
		}
		if (!flag && rYSjWWBVAoAARaaHxdRJsvPiJQxl)
		{
			RvCtwCUBuOaOTElUyFmMheFLVHCCb(DRhfHJIoHswtakTDkSiSpTvpPegr());
			YwXfGNBiEhjdPAdryzWHmJrJGVPA(false);
			KLAWATVdQbIRsCHrvfiJhfpnHJzwA();
			return;
		}
		if (rYSjWWBVAoAARaaHxdRJsvPiJQxl)
		{
			oKpFKELnzXlspsBPAroOwSnVDfBO();
		}
		if (vhPEygimrvvanAmFoeiOHWLgtHbNB.IjDAOhjnupbeicWoJQcuMwlCNKJq && vhPEygimrvvanAmFoeiOHWLgtHbNB.IChbtFqxyAxpsLDDmkASsVKzMoVs())
		{
			ccHqdeehLvYvALnaPOlmnefmvaRx();
		}
	}

	private void oKpFKELnzXlspsBPAroOwSnVDfBO()
	{
		rYSjWWBVAoAARaaHxdRJsvPiJQxl = false;
		if (!vhPEygimrvvanAmFoeiOHWLgtHbNB.IjDAOhjnupbeicWoJQcuMwlCNKJq)
		{
			vhPEygimrvvanAmFoeiOHWLgtHbNB.icnDcGzVOnAmxAhayFIDZrxYnhvMA();
		}
	}

	private void ccHqdeehLvYvALnaPOlmnefmvaRx()
	{
		lock (BjnhApIFANpKjlhZmxMEFZVgITxX)
		{
			Array.Copy(BjnhApIFANpKjlhZmxMEFZVgITxX, FuhdeVpHevKeRfLQEQUrmqDvYKzW, 4);
		}
		RvCtwCUBuOaOTElUyFmMheFLVHCCb(FuhdeVpHevKeRfLQEQUrmqDvYKzW);
	}

	private bool meBnDIfgxJYvrFypmzPIVRvkUdJD()
	{
		lock (BjnhApIFANpKjlhZmxMEFZVgITxX)
		{
			for (int i = 0; i < 4; i++)
			{
				if (cnhUDNspvcCoAWwfqwujPuvZHTxc[i] != null)
				{
					BjnhApIFANpKjlhZmxMEFZVgITxX[i] = cnhUDNspvcCoAWwfqwujPuvZHTxc[i].DMuTLRcnoPfxZkRMDLbMwSMybXdg(WGgLqpogYRSujebBKDmwAhrUAWUMA.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] DRhfHJIoHswtakTDkSiSpTvpPegr()
	{
		for (int i = 0; i < 4; i++)
		{
			FuhdeVpHevKeRfLQEQUrmqDvYKzW[i] = cnhUDNspvcCoAWwfqwujPuvZHTxc[i].DMuTLRcnoPfxZkRMDLbMwSMybXdg(WGgLqpogYRSujebBKDmwAhrUAWUMA.Synchronous);
		}
		return FuhdeVpHevKeRfLQEQUrmqDvYKzW;
	}

	private void RvCtwCUBuOaOTElUyFmMheFLVHCCb(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (cnhUDNspvcCoAWwfqwujPuvZHTxc[i] != null && cnhUDNspvcCoAWwfqwujPuvZHTxc[i].TPSFwhfjkPWAhnDFKGeVDaiYfJQmA)
			{
				bool flag = P_0[i];
				cnhUDNspvcCoAWwfqwujPuvZHTxc[i].ZcrDDmEaAsTjuQOTDEcCXSRIVNnvA(flag);
				if (!flag)
				{
					zFsckOBVVNZAkryFCokUJsVaWkkY(cnhUDNspvcCoAWwfqwujPuvZHTxc[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (cnhUDNspvcCoAWwfqwujPuvZHTxc[j] != null && !cnhUDNspvcCoAWwfqwujPuvZHTxc[j].TPSFwhfjkPWAhnDFKGeVDaiYfJQmA)
			{
				bool flag2 = P_0[j];
				cnhUDNspvcCoAWwfqwujPuvZHTxc[j].ZcrDDmEaAsTjuQOTDEcCXSRIVNnvA(flag2);
				if (flag2 && !zFsckOBVVNZAkryFCokUJsVaWkkY(cnhUDNspvcCoAWwfqwujPuvZHTxc[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (cnhUDNspvcCoAWwfqwujPuvZHTxc[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					cnhUDNspvcCoAWwfqwujPuvZHTxc[k].HckEkzHOLCBvPmnDxrivjrYcDpOB(P_0[k]);
				}
			}
		}
	}

	private bool zFsckOBVVNZAkryFCokUJsVaWkkY(NKwSfsGyUIazodrgxUlsBzqRhiXk P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.KXlpoSPlELaECbizgaMgCKIuxuWDb();
			if (!P_0.VdOWGUpCGwDLoPIweCEpxOPUBBaP)
			{
				return false;
			}
			int num = temyvKUmPLOFAQBhzoxlFbCtqiDP.XhIgIRAcTqvpZUMjBYnSayyDPeZG(P_0.iDvicFAoLsYlcSjadcqddrIaZDhJA, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = temyvKUmPLOFAQBhzoxlFbCtqiDP.JzjKpiNHduhLNkyLEqvyqvydKfhWA(num);
				temyvKUmPLOFAQBhzoxlFbCtqiDP.xpLvANbLecKFjsOmWWSIzGhSpBdm(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = HTMzNkAyPkNnwjYyTBjVroNbwpKp();
				temyvKUmPLOFAQBhzoxlFbCtqiDP.aSwurzbbZPzCVruPpyCiXzYYqUQD(P_0, true);
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
			int num2 = temyvKUmPLOFAQBhzoxlFbCtqiDP.QPbBQZLbTSzrWHLvYXVznpuAVCEc(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.iDvicFAoLsYlcSjadcqddrIaZDhJA, true);
			if (num2 >= 0)
			{
				temyvKUmPLOFAQBhzoxlFbCtqiDP.YaQFXagQcrEcACcxicjlcNQeWbyXA(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.FlPQULQNQKkdqpLjycRFUnWXGJYk();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static YeDLvUUmeuKtQrgSaWuhUANSLKCe()
	{
		GpBzUCJmCetIOwlCtzVEGgTJdmzcA = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		CkdqhvzCHBfpiSACyinGkIiQJwyI = new string[1] { "Xbox Bluetooth Gamepad" };
		JaOMlCXSkatdvREhToHKefwAqprt = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool IUShrVBkBlNnfjEYIootzAdNHscBA(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(GpBzUCJmCetIOwlCtzVEGgTJdmzcA, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < CkdqhvzCHBfpiSACyinGkIiQJwyI.Length; i++)
			{
				if (P_1.Equals(CkdqhvzCHBfpiSACyinGkIiQJwyI[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < JaOMlCXSkatdvREhToHKefwAqprt.Length; j++)
			{
				if (Regex.IsMatch(P_2, JaOMlCXSkatdvREhToHKefwAqprt[j], RegexOptions.IgnoreCase))
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
