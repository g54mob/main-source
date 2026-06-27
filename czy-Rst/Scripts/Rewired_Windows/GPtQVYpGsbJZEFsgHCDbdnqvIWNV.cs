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

internal class GPtQVYpGsbJZEFsgHCDbdnqvIWNV : PlatformInputManager, QdLLDjUvbeJHvwTMuBtdvfsbPLHe
{
	private class ZGCDdmzeSTxEgTUkALmuobQyEeWu : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		private bool EacXgdBoNObborvsKUCrTjAUVpvj;

		private int nXBJpWqvJWdvvfeQOhhgJUjYbVht;

		private readonly int KPEZMbjdEYRiPEEHosuCJYPPhdbk;

		public Guid TmqsYezqJCIjGugKKFNWDRVljCwj;

		public string WdQIMECTsBauzeZUZssjIWUYJDMW;

		public string YZrNKoHcOTmLxdkKYNhOIKxqLIsb;

		public Guid OxfzKAHevrESlkqcPEHVoSxAJaFm;

		public Rewired.Libraries.SharpDX.XInput.DeviceType PlgAJEkwbEDamvYTogNfpTlwwjJVA;

		public XInputDeviceSubType kqPTlDnIDrEiuDgyEKlprGqBXQcIA;

		public bool HqHpaWOkaUpkkhNGZGIvBTDgJeHD;

		public bool UbngbzXLEleuTaHPaODEIIGqGIoL;

		public bool VgiwfhOaqMATlHJBtDbRFPIabQByb;

		public bool LQoDNWYFCfeWazOqRODbEOxbYMvM;

		private int wXOHOBqWoXvBYPXsTqxggLOjviSl;

		private int nFfZMSOzmrNcawonSppvrIlHNyUK;

		private int MYdSrJkrYwnYwoLcOkCMytEEFWCs;

		private int ZvtrAwNCmZWuOMUiBLhUslElISajA;

		private readonly float[] RbryxyEoepjsbLDakgMQSfPISXuQ;

		private readonly bool[] JnVfzVcCmuFRrDywIKYnOhghHQgYA;

		private HardwareJoystickMap_InputManager xtUTToQMZSNIWuBpnSfUAIOLqdyW;

		public readonly BuZsqkobnKmKKBwfCtzQJcPDbpshA TGyHjUooLEUfLdUCPSKavtsdnSXC;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> kUSLNpRuApkRcfuqUJPnBJQEjUqo;

		private Action FchbZDNUcWCnxFYJbAcQvGpWUAMO;

		private readonly LocalizedString ERMhFgBmbwDjPKZnEMfyrbHWGMaeA;

		private bool tPIhsEuguldRVGLVfpZbdzCGISDUb;

		private bool tZXziRrzWNRsBZgoSHFvfyMSMYht;

		private bool TyfdDMhMGCaqmrDwfkRWCRcTzeJf;

		public string RdiHQOvIpXVbedCoEbjXarEBRENNA
		{
			get
			{
				string text = dGbPgwsjbqyXzTZEgidQhEoRczXEA;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				int kPEZMbjdEYRiPEEHosuCJYPPhdbk = KPEZMbjdEYRiPEEHosuCJYPPhdbk;
				return text + " " + kPEZMbjdEYRiPEEHosuCJYPPhdbk;
			}
		}

		public string dGbPgwsjbqyXzTZEgidQhEoRczXEA
		{
			get
			{
				if (!eWtAEPJIDFXZdSSlsBsZXWwinIkmA)
				{
					return string.Empty;
				}
				return kqPTlDnIDrEiuDgyEKlprGqBXQcIA.ToString();
			}
		}

		public bool eWtAEPJIDFXZdSSlsBsZXWwinIkmA
		{
			get
			{
				if (TGyHjUooLEUfLdUCPSKavtsdnSXC == null || !LQoDNWYFCfeWazOqRODbEOxbYMvM)
				{
					return false;
				}
				if (tPIhsEuguldRVGLVfpZbdzCGISDUb && !JfyqQWvdEsXNJvlOECZNDvYjHlMfA(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Asynchronous))
				{
					yQSQDHijAcBHnHzNmulipRUldpjo();
				}
				return tPIhsEuguldRVGLVfpZbdzCGISDUb;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return nXBJpWqvJWdvvfeQOhhgJUjYbVht;
			}
			set
			{
				nXBJpWqvJWdvvfeQOhhgJUjYbVht = value;
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId => KPEZMbjdEYRiPEEHosuCJYPPhdbk;

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => YZrNKoHcOTmLxdkKYNhOIKxqLIsb;

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => KPEZMbjdEYRiPEEHosuCJYPPhdbk;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => 0;

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				if (TGyHjUooLEUfLdUCPSKavtsdnSXC == null)
				{
					return null;
				}
				return TGyHjUooLEUfLdUCPSKavtsdnSXC.YCeuOriQBaxQfETNELNTXMWpEJre;
			}
		}

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => OxfzKAHevrESlkqcPEHVoSxAJaFm;

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			TGyHjUooLEUfLdUCPSKavtsdnSXC.akBAbWgQQrQLLfyzShkrdNnMwSXoA(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			TGyHjUooLEUfLdUCPSKavtsdnSXC.gYrJYnfgOMkLYCjAUHJynNSqdgsCA();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(ERMhFgBmbwDjPKZnEMfyrbHWGMaeA, xtUTToQMZSNIWuBpnSfUAIOLqdyW.deviceLocalizationInfo.parentKeys, "controller", WdQIMECTsBauzeZUZssjIWUYJDMW, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {(KPEZMbjdEYRiPEEHosuCJYPPhdbk + 1).ToString()}";
				ERMhFgBmbwDjPKZnEMfyrbHWGMaeA.cachedValue = value;
			}
			return true;
		}

		public ZGCDdmzeSTxEgTUkALmuobQyEeWu(int P_0, bool P_1, BuZsqkobnKmKKBwfCtzQJcPDbpshA P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Action P_4)
		{
			TGyHjUooLEUfLdUCPSKavtsdnSXC = P_2;
			EacXgdBoNObborvsKUCrTjAUVpvj = P_1;
			KPEZMbjdEYRiPEEHosuCJYPPhdbk = P_0;
			kUSLNpRuApkRcfuqUJPnBJQEjUqo = P_3;
			FchbZDNUcWCnxFYJbAcQvGpWUAMO = P_4;
			nXBJpWqvJWdvvfeQOhhgJUjYbVht = -1;
			wXOHOBqWoXvBYPXsTqxggLOjviSl = 6;
			nFfZMSOzmrNcawonSppvrIlHNyUK = 15;
			MYdSrJkrYwnYwoLcOkCMytEEFWCs = wXOHOBqWoXvBYPXsTqxggLOjviSl;
			ZvtrAwNCmZWuOMUiBLhUslElISajA = nFfZMSOzmrNcawonSppvrIlHNyUK;
			RbryxyEoepjsbLDakgMQSfPISXuQ = new float[wXOHOBqWoXvBYPXsTqxggLOjviSl];
			JnVfzVcCmuFRrDywIKYnOhghHQgYA = new bool[nFfZMSOzmrNcawonSppvrIlHNyUK];
			ERMhFgBmbwDjPKZnEMfyrbHWGMaeA = new LocalizedString();
			EQQRrqdvLQeNekBsERanBhcssmuf();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			TGyHjUooLEUfLdUCPSKavtsdnSXC.dgpHEGizrOBspkoOFaNoiaIAzJRgb();
			bool[] array = TGyHjUooLEUfLdUCPSKavtsdnSXC.HxMyWfBkmolOvrQpcInpvFleBwTc;
			CwFduxTtyBZoBaLYAgcbDvxIXXGm(array, ref TGyHjUooLEUfLdUCPSKavtsdnSXC.VywVGSfkiXAbtuvPqLfNZGOdVWqb);
			gkocrCLBhiBwQGZlecVPBoqWlmVhA(array, ref TGyHjUooLEUfLdUCPSKavtsdnSXC.VywVGSfkiXAbtuvPqLfNZGOdVWqb);
			TGyHjUooLEUfLdUCPSKavtsdnSXC.ArcYfDYiEdWOdJpkhDLEoLPMHOke();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public void DoQPeimNWJCYtAUhOyVgWqRNCbkL(bool P_0)
		{
			if (TGyHjUooLEUfLdUCPSKavtsdnSXC != null)
			{
				VgiwfhOaqMATlHJBtDbRFPIabQByb = P_0;
			}
		}

		public bool JfyqQWvdEsXNJvlOECZNDvYjHlMfA(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA P_0)
		{
			RvVMGgBeCdrmseFHuxrSbznfMYqu(DYUhPBssOesDKkQgIdSNQyPoPyE(P_0));
			return tPIhsEuguldRVGLVfpZbdzCGISDUb;
		}

		public bool DYUhPBssOesDKkQgIdSNQyPoPyE(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA P_0)
		{
			if (TGyHjUooLEUfLdUCPSKavtsdnSXC == null)
			{
				return false;
			}
			return TGyHjUooLEUfLdUCPSKavtsdnSXC.UCIGxPMoqPjqPqEpHtZgXxfwihWD(P_0);
		}

		public void RvVMGgBeCdrmseFHuxrSbznfMYqu(bool P_0)
		{
			tPIhsEuguldRVGLVfpZbdzCGISDUb = P_0;
		}

		public void UyNGpSHkMYpBWdQlHHXsWxmZehFeb()
		{
			if (!LQoDNWYFCfeWazOqRODbEOxbYMvM || pPfgtfJtCpylngHyoDLsdVLhDgkjb())
			{
				EQQRrqdvLQeNekBsERanBhcssmuf();
			}
			if (LQoDNWYFCfeWazOqRODbEOxbYMvM && tPIhsEuguldRVGLVfpZbdzCGISDUb)
			{
				TGyHjUooLEUfLdUCPSKavtsdnSXC.vvHggHxOshKjbnospEfpTMziaErf();
			}
		}

		public void DIhELPAlOLKqgoZvHJKTUrkwlBVlA()
		{
			nXBJpWqvJWdvvfeQOhhgJUjYbVht = -1;
			LQoDNWYFCfeWazOqRODbEOxbYMvM = false;
			TGyHjUooLEUfLdUCPSKavtsdnSXC.TRsmrtRblZEJKFdckAKTEIlJMLiic();
			Array.Clear(RbryxyEoepjsbLDakgMQSfPISXuQ, 0, RbryxyEoepjsbLDakgMQSfPISXuQ.Length);
			Array.Clear(JnVfzVcCmuFRrDywIKYnOhghHQgYA, 0, JnVfzVcCmuFRrDywIKYnOhghHQgYA.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (wXOHOBqWoXvBYPXsTqxggLOjviSl != dataUpdater.axisCount || nFfZMSOzmrNcawonSppvrIlHNyUK != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < wXOHOBqWoXvBYPXsTqxggLOjviSl; i++)
			{
				dataUpdater.axisValues[i] = RbryxyEoepjsbLDakgMQSfPISXuQ[i];
			}
			for (int j = 0; j < nFfZMSOzmrNcawonSppvrIlHNyUK; j++)
			{
				dataUpdater.buttonValues[j] = JnVfzVcCmuFRrDywIKYnOhghHQgYA[j];
			}
			if (tZXziRrzWNRsBZgoSHFvfyMSMYht && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo LQZvwOcdIGhtQNcceAsCHNjzvETT()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			NodUQjDVBFkrrjqHZgGyQLjUJsAR(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			aWZZxNnXKlhSkwuwcnRuntpALlHN(bridgedController);
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
			return new ControllerDisconnectedEventArgs(nXBJpWqvJWdvvfeQOhhgJUjYbVht);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void EQQRrqdvLQeNekBsERanBhcssmuf()
		{
			if (TGyHjUooLEUfLdUCPSKavtsdnSXC == null || !JfyqQWvdEsXNJvlOECZNDvYjHlMfA(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Synchronous))
			{
				return;
			}
			try
			{
				CzdMaAtdZkozSDFKQLxPXXcAQNVw();
				zeUjBxbSTxpQeenLFPmXUASDQAJKb zeUjBxbSTxpQeenLFPmXUASDQAJKb2 = TGyHjUooLEUfLdUCPSKavtsdnSXC.lKwCSEEkROkYChTOUcjWBVqnXfnR.feSHQBERrAbBlPbpChJekxFrJcuV(CKzzXstLbLWeHDegzKeIKdCmmoDQ.Any);
				PlgAJEkwbEDamvYTogNfpTlwwjJVA = zeUjBxbSTxpQeenLFPmXUASDQAJKb2.CGXrPmkAHbdknThwMCeUCRvBXobO;
				kqPTlDnIDrEiuDgyEKlprGqBXQcIA = (XInputDeviceSubType)zeUjBxbSTxpQeenLFPmXUASDQAJKb2.ltyEzAUDGIGljcxlLnKQTBtdwwyY;
				if (TGyHjUooLEUfLdUCPSKavtsdnSXC.lKwCSEEkROkYChTOUcjWBVqnXfnR.bWipPVSlXBtJpGoZEjwabKNMVnIl(default(fBHyZvHoVlntzUhFrgFfHdKvuXJV)).RBPgLqcqcljdgfXUcHzmjouDClGXd)
				{
					HqHpaWOkaUpkkhNGZGIvBTDgJeHD = true;
				}
				UbngbzXLEleuTaHPaODEIIGqGIoL = (zeUjBxbSTxpQeenLFPmXUASDQAJKb2.gzzJbStZZaNQPqRvwpkmefllGboi & HmTDgAZvylkvrznOpSagJxnLGLSj.VoiceSupported) == HmTDgAZvylkvrznOpSagJxnLGLSj.VoiceSupported;
				eouUNpleChdqWNZWqAMhpcJCXyqi();
				TmqsYezqJCIjGugKKFNWDRVljCwj = xtUTToQMZSNIWuBpnSfUAIOLqdyW.hardwareMapIdentifier.guid;
				if (EacXgdBoNObborvsKUCrTjAUVpvj)
				{
					WdQIMECTsBauzeZUZssjIWUYJDMW = StringTools.AddSpacesToCamelCase(kqPTlDnIDrEiuDgyEKlprGqBXQcIA.ToString());
				}
				else
				{
					WdQIMECTsBauzeZUZssjIWUYJDMW = "XInput " + kqPTlDnIDrEiuDgyEKlprGqBXQcIA;
				}
				YZrNKoHcOTmLxdkKYNhOIKxqLIsb = $"{WdQIMECTsBauzeZUZssjIWUYJDMW} {(KPEZMbjdEYRiPEEHosuCJYPPhdbk + 1).ToString()}";
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(kqPTlDnIDrEiuDgyEKlprGqBXQcIA.ToString());
				xtUTToQMZSNIWuBpnSfUAIOLqdyW.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				ERMhFgBmbwDjPKZnEMfyrbHWGMaeA.Clear();
				TGyHjUooLEUfLdUCPSKavtsdnSXC.vvHggHxOshKjbnospEfpTMziaErf();
				OxfzKAHevrESlkqcPEHVoSxAJaFm = MiscTools.CreateGuidHashSHA1(string.Concat(PlgAJEkwbEDamvYTogNfpTlwwjJVA, kqPTlDnIDrEiuDgyEKlprGqBXQcIA, KPEZMbjdEYRiPEEHosuCJYPPhdbk));
				LQoDNWYFCfeWazOqRODbEOxbYMvM = true;
			}
			catch (Exception)
			{
				LQoDNWYFCfeWazOqRODbEOxbYMvM = false;
				tPIhsEuguldRVGLVfpZbdzCGISDUb = false;
				OxfzKAHevrESlkqcPEHVoSxAJaFm = Guid.Empty;
			}
		}

		private bool pPfgtfJtCpylngHyoDLsdVLhDgkjb()
		{
			try
			{
				if (kqPTlDnIDrEiuDgyEKlprGqBXQcIA != (XInputDeviceSubType)TGyHjUooLEUfLdUCPSKavtsdnSXC.lKwCSEEkROkYChTOUcjWBVqnXfnR.feSHQBERrAbBlPbpChJekxFrJcuV(CKzzXstLbLWeHDegzKeIKdCmmoDQ.Any).ltyEzAUDGIGljcxlLnKQTBtdwwyY)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void CzdMaAtdZkozSDFKQLxPXXcAQNVw()
		{
			UbngbzXLEleuTaHPaODEIIGqGIoL = false;
			HqHpaWOkaUpkkhNGZGIvBTDgJeHD = false;
			VgiwfhOaqMATlHJBtDbRFPIabQByb = false;
			LQoDNWYFCfeWazOqRODbEOxbYMvM = false;
		}

		private void yQSQDHijAcBHnHzNmulipRUldpjo()
		{
			if (FchbZDNUcWCnxFYJbAcQvGpWUAMO != null)
			{
				FchbZDNUcWCnxFYJbAcQvGpWUAMO();
			}
			TGyHjUooLEUfLdUCPSKavtsdnSXC.TRsmrtRblZEJKFdckAKTEIlJMLiic();
		}

		private void CwFduxTtyBZoBaLYAgcbDvxIXXGm(bool[] P_0, ref MUQDTtZzccDfduSyiRzheohKaVBM P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)xtUTToQMZSNIWuBpnSfUAIOLqdyW.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= wXOHOBqWoXvBYPXsTqxggLOjviSl)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				RbryxyEoepjsbLDakgMQSfPISXuQ[i] = atWbhzvmmaCIPETjyRSjUcCVnwIAA(axes_orig[i], P_0, ref P_1);
				if (!tZXziRrzWNRsBZgoSHFvfyMSMYht && RbryxyEoepjsbLDakgMQSfPISXuQ[i] != 0f)
				{
					tZXziRrzWNRsBZgoSHFvfyMSMYht = true;
				}
			}
		}

		private void gkocrCLBhiBwQGZlecVPBoqWlmVhA(bool[] P_0, ref MUQDTtZzccDfduSyiRzheohKaVBM P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)xtUTToQMZSNIWuBpnSfUAIOLqdyW.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= nFfZMSOzmrNcawonSppvrIlHNyUK)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				JnVfzVcCmuFRrDywIKYnOhghHQgYA[i] = QAQeEhTlHzaZrNLJIFgGAgZtIkJn(buttons_orig[i], P_0, ref P_1);
				if (!tZXziRrzWNRsBZgoSHFvfyMSMYht && JnVfzVcCmuFRrDywIKYnOhghHQgYA[i])
				{
					tZXziRrzWNRsBZgoSHFvfyMSMYht = true;
				}
			}
		}

		private float atWbhzvmmaCIPETjyRSjUcCVnwIAA(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref MUQDTtZzccDfduSyiRzheohKaVBM P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return GEUZYDVWBqRERKohqUgqxbAcmrHM(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!kncmzJHztoLCzUbDXpIzhArIDJdP(P_0.sourceButton, P_1))
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

		private float GEUZYDVWBqRERKohqUgqxbAcmrHM(XInputAxis P_0, ref MUQDTtZzccDfduSyiRzheohKaVBM P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => BuZsqkobnKmKKBwfCtzQJcPDbpshA.SMUwiuAXmygICHxhgZjXwdELBwri(P_1.xXVFUlKLPNHgRYFDoPLmYHeKLTJv), 
				XInputAxis.LeftThumbY => BuZsqkobnKmKKBwfCtzQJcPDbpshA.SMUwiuAXmygICHxhgZjXwdELBwri(P_1.CgMXetUPlNSUAzubEJvjdImdTTgd), 
				XInputAxis.RightThumbX => BuZsqkobnKmKKBwfCtzQJcPDbpshA.SMUwiuAXmygICHxhgZjXwdELBwri(P_1.rjCFVZWdewKNqvZVerHdNSWFqiFq), 
				XInputAxis.RightThumbY => BuZsqkobnKmKKBwfCtzQJcPDbpshA.SMUwiuAXmygICHxhgZjXwdELBwri(P_1.TJRCNrpYMknEsrUrOwrrPIBmvyAn), 
				XInputAxis.LeftTrigger => BuZsqkobnKmKKBwfCtzQJcPDbpshA.vIKhSpPlypYVJuRWyumXJpZNFKxu(P_1.bDnsplYkEKChrcQdRwbtufGbkcgoA), 
				XInputAxis.RightTrigger => BuZsqkobnKmKKBwfCtzQJcPDbpshA.vIKhSpPlypYVJuRWyumXJpZNFKxu(P_1.gNMDviSbrVuFrmRxWKvVEgcACOdp), 
				_ => 0f, 
			};
		}

		private bool QAQeEhTlHzaZrNLJIFgGAgZtIkJn(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref MUQDTtZzccDfduSyiRzheohKaVBM P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return kncmzJHztoLCzUbDXpIzhArIDJdP(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = GEUZYDVWBqRERKohqUgqxbAcmrHM(P_0.sourceAxis, ref P_2);
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

		private bool kncmzJHztoLCzUbDXpIzhArIDJdP(XInputButton P_0, bool[] P_1)
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

		private void eouUNpleChdqWNZWqAMhpcJCXyqi()
		{
			xtUTToQMZSNIWuBpnSfUAIOLqdyW = kUSLNpRuApkRcfuqUJPnBJQEjUqo(LQZvwOcdIGhtQNcceAsCHNjzvETT());
			if (xtUTToQMZSNIWuBpnSfUAIOLqdyW == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			wXOHOBqWoXvBYPXsTqxggLOjviSl = xtUTToQMZSNIWuBpnSfUAIOLqdyW.axisCount;
			nFfZMSOzmrNcawonSppvrIlHNyUK = xtUTToQMZSNIWuBpnSfUAIOLqdyW.buttonCount;
		}

		private bool KoJiMWJllSAbTXnKgSumZuKimSKc(ref fBHyZvHoVlntzUhFrgFfHdKvuXJV P_0)
		{
			if (P_0.nTPeMNcIbJrMyDNoACJdjjdJYzYrB > 0 || P_0.qjjfTHUGdREZaCjreXDobAZiCDVpA > 0)
			{
				return true;
			}
			return false;
		}

		private void ocvhBegbjNDvGDvvdNqAqmuaLWxUb(ref fBHyZvHoVlntzUhFrgFfHdKvuXJV P_0)
		{
			P_0.nTPeMNcIbJrMyDNoACJdjjdJYzYrB = 0;
			P_0.qjjfTHUGdREZaCjreXDobAZiCDVpA = 0;
		}

		private void VedVHqoKolEPvtZZbcQuCQqFUuBJ(ref fBHyZvHoVlntzUhFrgFfHdKvuXJV P_0, ref fBHyZvHoVlntzUhFrgFfHdKvuXJV P_1)
		{
			P_1.nTPeMNcIbJrMyDNoACJdjjdJYzYrB = P_0.nTPeMNcIbJrMyDNoACJdjjdJYzYrB;
			P_1.qjjfTHUGdREZaCjreXDobAZiCDVpA = P_0.qjjfTHUGdREZaCjreXDobAZiCDVpA;
		}

		private string tnFswvKoxkmTZUzuxCjBicEklbf()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{PlgAJEkwbEDamvYTogNfpTlwwjJVA.ToString()}{kqPTlDnIDrEiuDgyEKlprGqBXQcIA.ToString()}");
		}

		private void NodUQjDVBFkrrjqHZgGyQLjUJsAR(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.Unknown;
			P_0.hardwareIdentifier = tnFswvKoxkmTZUzuxCjBicEklbf();
			P_0.hardwareAxisCount = MYdSrJkrYwnYwoLcOkCMytEEFWCs;
			P_0.hardwareButtonCount = ZvtrAwNCmZWuOMUiBLhUslElISajA;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = dGbPgwsjbqyXzTZEgidQhEoRczXEA;
			P_0.hw_supportsVoice = UbngbzXLEleuTaHPaODEIIGqGIoL;
			P_0.hw_supportsVibration = HqHpaWOkaUpkkhNGZGIvBTDgJeHD;
			P_0.hw_localVibrationMotorCount = (HqHpaWOkaUpkkhNGZGIvBTDgJeHD ? 2 : 0);
			P_0.hw_xInputSubType = kqPTlDnIDrEiuDgyEKlprGqBXQcIA;
		}

		private void aWZZxNnXKlhSkwuwcnRuntpALlHN(BridgedController P_0)
		{
			NodUQjDVBFkrrjqHZgGyQLjUJsAR(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = xtUTToQMZSNIWuBpnSfUAIOLqdyW.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + RdiHQOvIpXVbedCoEbjXarEBRENNA;
			P_0.productName = "XInput " + dGbPgwsjbqyXzTZEgidQhEoRczXEA;
			P_0.isXInputDevice = true;
			P_0.axisCount = wXOHOBqWoXvBYPXsTqxggLOjviSl;
			P_0.buttonCount = nFfZMSOzmrNcawonSppvrIlHNyUK;
			P_0.controllerTypeGuid = TmqsYezqJCIjGugKKFNWDRVljCwj;
			P_0.controllerExtension = Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002Eextension;
		}

		public void Dispose()
		{
			OTMfxUCfvNdUEjjCTGHCVZMneOfmA(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void TDtBhhNtVMIDFNjvyTvJUZOBoBRV()
		{
			try
			{
				OTMfxUCfvNdUEjjCTGHCVZMneOfmA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void OTMfxUCfvNdUEjjCTGHCVZMneOfmA(bool P_0)
		{
			if (TyfdDMhMGCaqmrDwfkRWCRcTzeJf)
			{
				return;
			}
			if (P_0)
			{
				if (eWtAEPJIDFXZdSSlsBsZXWwinIkmA)
				{
					TGyHjUooLEUfLdUCPSKavtsdnSXC.zMmvzOGTZaByFLRukDTuTGVwCGUL();
				}
				if (TGyHjUooLEUfLdUCPSKavtsdnSXC != null)
				{
					TGyHjUooLEUfLdUCPSKavtsdnSXC.Dispose();
				}
			}
			TyfdDMhMGCaqmrDwfkRWCRcTzeJf = true;
		}
	}

	private class JdTpqDVkworaeuNFRtgbaPXhzpZl
	{
		private class jBolfUmjtJNhucLBFoiYlCulVRpg
		{
			public bool pQJONWvkvfxtFZVeIfZOiwzQlIFF;

			public int OQAtoIqeErwTGgBMKufoUhhWewtD;

			public XInputDeviceSubType LnXmZHRdVRaNuesvVYnlOApVCnumA;

			public void ecqvfbsPAGaasFslCUwFLOBybUogA(ZGCDdmzeSTxEgTUkALmuobQyEeWu P_0, bool P_1)
			{
				pQJONWvkvfxtFZVeIfZOiwzQlIFF = P_1;
				OQAtoIqeErwTGgBMKufoUhhWewtD = P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId;
				LnXmZHRdVRaNuesvVYnlOApVCnumA = P_0.kqPTlDnIDrEiuDgyEKlprGqBXQcIA;
			}

			public jBolfUmjtJNhucLBFoiYlCulVRpg(int P_0, XInputDeviceSubType P_1)
			{
				OQAtoIqeErwTGgBMKufoUhhWewtD = P_0;
				LnXmZHRdVRaNuesvVYnlOApVCnumA = P_1;
			}
		}

		private List<jBolfUmjtJNhucLBFoiYlCulVRpg> RGpwAYsbDwLGLcchNUwtKLGFKpgT;

		public JdTpqDVkworaeuNFRtgbaPXhzpZl()
		{
			RGpwAYsbDwLGLcchNUwtKLGFKpgT = new List<jBolfUmjtJNhucLBFoiYlCulVRpg>();
		}

		public void cvWazhCeTOIqTJOHQubsqzsbPpNO(ZGCDdmzeSTxEgTUkALmuobQyEeWu P_0, bool P_1)
		{
			if (IYDGDMudjHJahpcNbnUHWaBtsCPP(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.kqPTlDnIDrEiuDgyEKlprGqBXQcIA, true) < 0)
			{
				jBolfUmjtJNhucLBFoiYlCulVRpg jBolfUmjtJNhucLBFoiYlCulVRpg2 = new jBolfUmjtJNhucLBFoiYlCulVRpg(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.kqPTlDnIDrEiuDgyEKlprGqBXQcIA);
				jBolfUmjtJNhucLBFoiYlCulVRpg2.pQJONWvkvfxtFZVeIfZOiwzQlIFF = P_1;
				RGpwAYsbDwLGLcchNUwtKLGFKpgT.Add(jBolfUmjtJNhucLBFoiYlCulVRpg2);
			}
		}

		public void ldrmNiSqWnPlYKiIbLEGAFehiFuD(int P_0, ZGCDdmzeSTxEgTUkALmuobQyEeWu P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < RGpwAYsbDwLGLcchNUwtKLGFKpgT.Count)
			{
				RGpwAYsbDwLGLcchNUwtKLGFKpgT[P_0].ecqvfbsPAGaasFslCUwFLOBybUogA(P_1, P_2);
			}
		}

		public int PkcfnBzHZvoFByblmJBOTlScpSMX(XInputDeviceSubType P_0, bool P_1)
		{
			int count = RGpwAYsbDwLGLcchNUwtKLGFKpgT.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !RGpwAYsbDwLGLcchNUwtKLGFKpgT[i].pQJONWvkvfxtFZVeIfZOiwzQlIFF) && RGpwAYsbDwLGLcchNUwtKLGFKpgT[i].LnXmZHRdVRaNuesvVYnlOApVCnumA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int IYDGDMudjHJahpcNbnUHWaBtsCPP(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = RGpwAYsbDwLGLcchNUwtKLGFKpgT.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !RGpwAYsbDwLGLcchNUwtKLGFKpgT[i].pQJONWvkvfxtFZVeIfZOiwzQlIFF) && RGpwAYsbDwLGLcchNUwtKLGFKpgT[i].OQAtoIqeErwTGgBMKufoUhhWewtD == P_0 && RGpwAYsbDwLGLcchNUwtKLGFKpgT[i].LnXmZHRdVRaNuesvVYnlOApVCnumA == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int XSDwqamaxlbKVfKDhOcwZOGCImauA(int P_0)
		{
			if (P_0 < 0 || P_0 >= RGpwAYsbDwLGLcchNUwtKLGFKpgT.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return RGpwAYsbDwLGLcchNUwtKLGFKpgT[P_0].OQAtoIqeErwTGgBMKufoUhhWewtD;
		}

		public void EygqWaFMomatEUvfTIsjuYiXayvM(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < RGpwAYsbDwLGLcchNUwtKLGFKpgT.Count)
			{
				RGpwAYsbDwLGLcchNUwtKLGFKpgT[P_0].pQJONWvkvfxtFZVeIfZOiwzQlIFF = P_1;
			}
		}
	}

	private class jMDuweOqMavWMsQBKtbOTSzdLBXj
	{
		public bool RpffTLzprasAZcXhMUtaQrUaXYje;

		private double HexGtzvPaOFFWgMYyseqmqCFtKJG;

		public float csmFnnGXNdVgRIqQlqxiUcOkhfbZA;

		public jMDuweOqMavWMsQBKtbOTSzdLBXj()
		{
		}

		public jMDuweOqMavWMsQBKtbOTSzdLBXj(float P_0)
		{
			csmFnnGXNdVgRIqQlqxiUcOkhfbZA = P_0;
		}

		public void eJncDrznKeGPGIxLozhFaVTVDDCeb()
		{
			RpffTLzprasAZcXhMUtaQrUaXYje = true;
			HexGtzvPaOFFWgMYyseqmqCFtKJG = (double)csmFnnGXNdVgRIqQlqxiUcOkhfbZA + ReInput.unscaledTime;
		}

		public void hnqijzRifsSCCyBvisbJOapveNEJ(float P_0)
		{
			RpffTLzprasAZcXhMUtaQrUaXYje = true;
			csmFnnGXNdVgRIqQlqxiUcOkhfbZA = P_0;
			HexGtzvPaOFFWgMYyseqmqCFtKJG = (double)csmFnnGXNdVgRIqQlqxiUcOkhfbZA + ReInput.unscaledTime;
		}

		public bool JYBKOCTjkJSRcLKpyZgYHykdQYiE()
		{
			if (!RpffTLzprasAZcXhMUtaQrUaXYje)
			{
				return false;
			}
			if (ReInput.unscaledTime >= HexGtzvPaOFFWgMYyseqmqCFtKJG)
			{
				RpffTLzprasAZcXhMUtaQrUaXYje = false;
				return true;
			}
			return false;
		}

		public void OZuEjOLFZOAcmAJgtDvqXxOSOtImA()
		{
			RpffTLzprasAZcXhMUtaQrUaXYje = false;
			HexGtzvPaOFFWgMYyseqmqCFtKJG = 0.0;
		}

		public void wyzWcKcUxJPHtbUVmDSBWkOYHRVu(float P_0)
		{
			csmFnnGXNdVgRIqQlqxiUcOkhfbZA = P_0;
		}

		public jMDuweOqMavWMsQBKtbOTSzdLBXj dlCDVlMCpnEVHAueCgaBFOkrfiHRA()
		{
			return (jMDuweOqMavWMsQBKtbOTSzdLBXj)MemberwiseClone();
		}
	}

	public class BuZsqkobnKmKKBwfCtzQJcPDbpshA : IDisposable
	{
		public readonly CAUdltGlQSoHgQZtmbnLmjHstndg lKwCSEEkROkYChTOUcjWBVqnXfnR;

		private readonly Controller.Extension zbAaDlSflytgWUxOQVJLZbHzGSFk;

		public MUQDTtZzccDfduSyiRzheohKaVBM VywVGSfkiXAbtuvPqLfNZGOdVWqb;

		private bool jzoAhpwsTrhnrCkWTYMmRVNFTnwA;

		private readonly ButtonLoopSet QUFXgGHyoBPeNYrDmdioDwTPjcuR;

		private MUQDTtZzccDfduSyiRzheohKaVBM OgriPDhhbHdgZTZNPfSuSYZquYoE;

		private bool IygIJkffoAZhVrIWouFLdyAnQdke;

		private DualThreadLowLevelInputEventQueue pPOkdbZdPLFBpFqtcDEbOkxqUUdM;

		private readonly object NiTVHrWHPzhNIUgwrIygildXwxON;

		private RingBuffer<fBHyZvHoVlntzUhFrgFfHdKvuXJV> UpSxRngNkcaIqbOpgNzUjNZuGmXWA = new RingBuffer<fBHyZvHoVlntzUhFrgFfHdKvuXJV>(5);

		private RingBuffer<fBHyZvHoVlntzUhFrgFfHdKvuXJV> sPLBeaMAEAaTSvWxWUzgYqFNKqvw = new RingBuffer<fBHyZvHoVlntzUhFrgFfHdKvuXJV>(5);

		private readonly object gYOBVfnrsneaNmqhdbpForhhgROL = new object();

		private readonly object BHzClIkPjGwxVjFNTgBhhrNjqiodA = new object();

		private fBHyZvHoVlntzUhFrgFfHdKvuXJV pcPoLJmGutNlUSwIGVsSamMgwWCJ;

		private double vfRZchTMhJqsDBECJflKMCAeXUdi;

		private bool OTyDYLfQnnJHxiilgjDXhOKksBAjb;

		public Controller.Extension YCeuOriQBaxQfETNELNTXMWpEJre => zbAaDlSflytgWUxOQVJLZbHzGSFk;

		public bool[] HxMyWfBkmolOvrQpcInpvFleBwTc => QUFXgGHyoBPeNYrDmdioDwTPjcuR.Current.effectiveValue;

		public BuZsqkobnKmKKBwfCtzQJcPDbpshA(int P_0, UpdateLoopSetting P_1)
		{
			lKwCSEEkROkYChTOUcjWBVqnXfnR = new CAUdltGlQSoHgQZtmbnLmjHstndg((anKhMdfBdsILEiWCFgKNDnqDozzcB)P_0);
			QUFXgGHyoBPeNYrDmdioDwTPjcuR = new ButtonLoopSet(P_1, 15);
			NiTVHrWHPzhNIUgwrIygildXwxON = new object();
			pPOkdbZdPLFBpFqtcDEbOkxqUUdM = new DualThreadLowLevelInputEventQueue((int)((float)GGlKyqwtSRgaaWuZtxjwSYfoOckk.IxvjPdsczxfVuHMZdgPbDANUNliEb * 0.25f), 15, 6, 0);
			zbAaDlSflytgWUxOQVJLZbHzGSFk = new XInputControllerExtension(this);
		}

		public void dgpHEGizrOBspkoOFaNoiaIAzJRgb()
		{
			QUFXgGHyoBPeNYrDmdioDwTPjcuR.SetUpdateLoop(ReInput.currentUpdateLoop);
			MQOmzMxpxxtQvJUHLDAcALQXOXYv(ref VywVGSfkiXAbtuvPqLfNZGOdVWqb);
		}

		public void ArcYfDYiEdWOdJpkhDLEoLPMHOke()
		{
			zrvGMkWukFMpmzTVWNUumEdFIRWY();
			QUFXgGHyoBPeNYrDmdioDwTPjcuR.Current.ClearWasTrueThisFrame();
		}

		public void vvHggHxOshKjbnospEfpTMziaErf()
		{
			vZoToRdHAzeKRSEzwekCboiKQwOmA();
			jzoAhpwsTrhnrCkWTYMmRVNFTnwA = true;
			IygIJkffoAZhVrIWouFLdyAnQdke = lKwCSEEkROkYChTOUcjWBVqnXfnR.oHclAshgIlValbIZfNHVaIVOElDAA;
		}

		public void TRsmrtRblZEJKFdckAKTEIlJMLiic()
		{
			jzoAhpwsTrhnrCkWTYMmRVNFTnwA = false;
			IygIJkffoAZhVrIWouFLdyAnQdke = false;
			vZoToRdHAzeKRSEzwekCboiKQwOmA();
		}

		public bool UCIGxPMoqPjqPqEpHtZgXxfwihWD(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA P_0)
		{
			return P_0 switch
			{
				SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Synchronous => IygIJkffoAZhVrIWouFLdyAnQdke = lKwCSEEkROkYChTOUcjWBVqnXfnR.oHclAshgIlValbIZfNHVaIVOElDAA, 
				SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Asynchronous => IygIJkffoAZhVrIWouFLdyAnQdke, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void akBAbWgQQrQLLfyzShkrdNnMwSXoA(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				pcPoLJmGutNlUSwIGVsSamMgwWCJ.nTPeMNcIbJrMyDNoACJdjjdJYzYrB = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				pcPoLJmGutNlUSwIGVsSamMgwWCJ.qjjfTHUGdREZaCjreXDobAZiCDVpA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			PWsdUtFgCrxnisfHIxTxpAwzFLrIb();
		}

		public void gYrJYnfgOMkLYCjAUHJynNSqdgsCA()
		{
			pcPoLJmGutNlUSwIGVsSamMgwWCJ.nTPeMNcIbJrMyDNoACJdjjdJYzYrB = 0;
			pcPoLJmGutNlUSwIGVsSamMgwWCJ.qjjfTHUGdREZaCjreXDobAZiCDVpA = 0;
			PWsdUtFgCrxnisfHIxTxpAwzFLrIb();
		}

		public void zMmvzOGTZaByFLRukDTuTGVwCGUL()
		{
			pcPoLJmGutNlUSwIGVsSamMgwWCJ.nTPeMNcIbJrMyDNoACJdjjdJYzYrB = 0;
			pcPoLJmGutNlUSwIGVsSamMgwWCJ.qjjfTHUGdREZaCjreXDobAZiCDVpA = 0;
			lock (BHzClIkPjGwxVjFNTgBhhrNjqiodA)
			{
				lock (gYOBVfnrsneaNmqhdbpForhhgROL)
				{
					UpSxRngNkcaIqbOpgNzUjNZuGmXWA.Clear();
					sPLBeaMAEAaTSvWxWUzgYqFNKqvw.Clear();
					AzZtBPRbASRrEEDmIGnAdcGgABrjA(lKwCSEEkROkYChTOUcjWBVqnXfnR, pcPoLJmGutNlUSwIGVsSamMgwWCJ, ref vfRZchTMhJqsDBECJflKMCAeXUdi);
				}
			}
		}

		public void mIxHSZFwvGuaIXPABzYEfdUBXFlO()
		{
			if (!jzoAhpwsTrhnrCkWTYMmRVNFTnwA || !IygIJkffoAZhVrIWouFLdyAnQdke)
			{
				return;
			}
			cUdaxzbKWYMFaUUhzEgTRmDfJGBeb cUdaxzbKWYMFaUUhzEgTRmDfJGBeb2;
			double realTime;
			try
			{
				if (!lKwCSEEkROkYChTOUcjWBVqnXfnR.klDGycrslcfBsduEvjzKcZfBlqvGA(out cUdaxzbKWYMFaUUhzEgTRmDfJGBeb2))
				{
					IygIJkffoAZhVrIWouFLdyAnQdke = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				IygIJkffoAZhVrIWouFLdyAnQdke = false;
				return;
			}
			lock (NiTVHrWHPzhNIUgwrIygildXwxON)
			{
				if (!EZfKPWdDevsYmJAGBcqncRwDVPeN(cUdaxzbKWYMFaUUhzEgTRmDfJGBeb2.CHVjGEyjWTtwMNJLLcwkSxwkLJBE, OgriPDhhbHdgZTZNPfSuSYZquYoE))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = pPOkdbZdPLFBpFqtcDEbOkxqUUdM.T_CreateEvent())
					{
						gCuAvGaLGOwFjoZyMCWvsiJtayKf(ref cUdaxzbKWYMFaUUhzEgTRmDfJGBeb2.CHVjGEyjWTtwMNJLLcwkSxwkLJBE, realTime, newEventWrapper.Event);
					}
					OgriPDhhbHdgZTZNPfSuSYZquYoE = cUdaxzbKWYMFaUUhzEgTRmDfJGBeb2.CHVjGEyjWTtwMNJLLcwkSxwkLJBE;
				}
			}
		}

		public void gQnbYKCGtdJkXEeIqznwiUMRWhDB()
		{
			if (!jzoAhpwsTrhnrCkWTYMmRVNFTnwA || !IygIJkffoAZhVrIWouFLdyAnQdke || ReInput.realTime < vfRZchTMhJqsDBECJflKMCAeXUdi + 0.009999999776482582)
			{
				return;
			}
			lock (BHzClIkPjGwxVjFNTgBhhrNjqiodA)
			{
				lock (gYOBVfnrsneaNmqhdbpForhhgROL)
				{
					MiscTools.Swap(ref UpSxRngNkcaIqbOpgNzUjNZuGmXWA, ref sPLBeaMAEAaTSvWxWUzgYqFNKqvw);
				}
				ytfHAsoaMJAsSkpBWBKBTsbhnotQA(sPLBeaMAEAaTSvWxWUzgYqFNKqvw, lKwCSEEkROkYChTOUcjWBVqnXfnR, ref vfRZchTMhJqsDBECJflKMCAeXUdi);
			}
		}

		private void zrvGMkWukFMpmzTVWNUumEdFIRWY()
		{
			mfuXKnJcZPKlTdYKsmmhbSXrRAzL();
		}

		private void mfuXKnJcZPKlTdYKsmmhbSXrRAzL()
		{
			if (!(ReInput.realTime < vfRZchTMhJqsDBECJflKMCAeXUdi + 1.5) && (!Mathf.Approximately((int)pcPoLJmGutNlUSwIGVsSamMgwWCJ.nTPeMNcIbJrMyDNoACJdjjdJYzYrB, 0f) || !Mathf.Approximately((int)pcPoLJmGutNlUSwIGVsSamMgwWCJ.qjjfTHUGdREZaCjreXDobAZiCDVpA, 0f)))
			{
				PWsdUtFgCrxnisfHIxTxpAwzFLrIb();
			}
		}

		private void PWsdUtFgCrxnisfHIxTxpAwzFLrIb()
		{
			lock (gYOBVfnrsneaNmqhdbpForhhgROL)
			{
				UpSxRngNkcaIqbOpgNzUjNZuGmXWA.Enqueue(pcPoLJmGutNlUSwIGVsSamMgwWCJ);
			}
		}

		private static void ytfHAsoaMJAsSkpBWBKBTsbhnotQA(RingBuffer<fBHyZvHoVlntzUhFrgFfHdKvuXJV> P_0, CAUdltGlQSoHgQZtmbnLmjHstndg P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				AzZtBPRbASRrEEDmIGnAdcGgABrjA(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void AzZtBPRbASRrEEDmIGnAdcGgABrjA(CAUdltGlQSoHgQZtmbnLmjHstndg P_0, fBHyZvHoVlntzUhFrgFfHdKvuXJV P_1, ref double P_2)
		{
			try
			{
				P_0.bWipPVSlXBtJpGoZEjwabKNMVnIl(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void MQOmzMxpxxtQvJUHLDAcALQXOXYv(ref MUQDTtZzccDfduSyiRzheohKaVBM P_0)
		{
			while (pPOkdbZdPLFBpFqtcDEbOkxqUUdM.ProcessNewEvents())
			{
				srJzpYFOLhFkNfQAksUVSHwLnXYEA(ref P_0, ref pPOkdbZdPLFBpFqtcDEbOkxqUUdM.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					QUFXgGHyoBPeNYrDmdioDwTPjcuR.SetValue(i, mlnxYNKLtRHEFPfbkLmqNCfUUVat((int)P_0.XQJIuOcEITRTBUOlmDtcukdENzGJ, i), pPOkdbZdPLFBpFqtcDEbOkxqUUdM.currentEvent.GetTimestamp());
				}
			}
		}

		private void gCuAvGaLGOwFjoZyMCWvsiJtayKf(ref MUQDTtZzccDfduSyiRzheohKaVBM P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int xQJIuOcEITRTBUOlmDtcukdENzGJ = (int)P_0.XQJIuOcEITRTBUOlmDtcukdENzGJ;
			P_2.SetButtonsBitMask((xQJIuOcEITRTBUOlmDtcukdENzGJ & 0x7FF) | ((xQJIuOcEITRTBUOlmDtcukdENzGJ & (xQJIuOcEITRTBUOlmDtcukdENzGJ & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, SMUwiuAXmygICHxhgZjXwdELBwri(P_0.xXVFUlKLPNHgRYFDoPLmYHeKLTJv));
			P_2.SetAxisValue(1, SMUwiuAXmygICHxhgZjXwdELBwri(P_0.CgMXetUPlNSUAzubEJvjdImdTTgd));
			P_2.SetAxisValue(2, SMUwiuAXmygICHxhgZjXwdELBwri(P_0.rjCFVZWdewKNqvZVerHdNSWFqiFq));
			P_2.SetAxisValue(3, SMUwiuAXmygICHxhgZjXwdELBwri(P_0.TJRCNrpYMknEsrUrOwrrPIBmvyAn));
			P_2.SetAxisValue(4, vIKhSpPlypYVJuRWyumXJpZNFKxu(P_0.bDnsplYkEKChrcQdRwbtufGbkcgoA));
			P_2.SetAxisValue(5, vIKhSpPlypYVJuRWyumXJpZNFKxu(P_0.gNMDviSbrVuFrmRxWKvVEgcACOdp));
		}

		private void srJzpYFOLhFkNfQAksUVSHwLnXYEA(ref MUQDTtZzccDfduSyiRzheohKaVBM P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.XQJIuOcEITRTBUOlmDtcukdENzGJ = (THQxBCflggKONYzSUQWNGtECDeYr)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.xXVFUlKLPNHgRYFDoPLmYHeKLTJv = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.CgMXetUPlNSUAzubEJvjdImdTTgd = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.rjCFVZWdewKNqvZVerHdNSWFqiFq = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.TJRCNrpYMknEsrUrOwrrPIBmvyAn = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.bDnsplYkEKChrcQdRwbtufGbkcgoA = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.gNMDviSbrVuFrmRxWKvVEgcACOdp = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool mlnxYNKLtRHEFPfbkLmqNCfUUVat(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void vZoToRdHAzeKRSEzwekCboiKQwOmA()
		{
			lock (NiTVHrWHPzhNIUgwrIygildXwxON)
			{
				VywVGSfkiXAbtuvPqLfNZGOdVWqb = default(MUQDTtZzccDfduSyiRzheohKaVBM);
				OgriPDhhbHdgZTZNPfSuSYZquYoE = default(MUQDTtZzccDfduSyiRzheohKaVBM);
				QUFXgGHyoBPeNYrDmdioDwTPjcuR.Clear();
				pPOkdbZdPLFBpFqtcDEbOkxqUUdM.Clear();
			}
		}

		public void Dispose()
		{
			AnkiZoJymnSIqjaEvfTEdHluMeak(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void fHuxsgQPtqgnqfmhOnmralvWVwvMA()
		{
			try
			{
				AnkiZoJymnSIqjaEvfTEdHluMeak(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void AnkiZoJymnSIqjaEvfTEdHluMeak(bool P_0)
		{
			if (!OTyDYLfQnnJHxiilgjDXhOKksBAjb)
			{
				if (P_0)
				{
					pPOkdbZdPLFBpFqtcDEbOkxqUUdM.Dispose();
				}
				OTyDYLfQnnJHxiilgjDXhOKksBAjb = true;
			}
		}

		public static float SMUwiuAXmygICHxhgZjXwdELBwri(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float vIKhSpPlypYVJuRWyumXJpZNFKxu(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool EZfKPWdDevsYmJAGBcqncRwDVPeN(MUQDTtZzccDfduSyiRzheohKaVBM P_0, MUQDTtZzccDfduSyiRzheohKaVBM P_1)
		{
			if (P_0.XQJIuOcEITRTBUOlmDtcukdENzGJ == P_1.XQJIuOcEITRTBUOlmDtcukdENzGJ && P_0.bDnsplYkEKChrcQdRwbtufGbkcgoA == P_1.bDnsplYkEKChrcQdRwbtufGbkcgoA && P_0.gNMDviSbrVuFrmRxWKvVEgcACOdp == P_1.gNMDviSbrVuFrmRxWKvVEgcACOdp && P_0.xXVFUlKLPNHgRYFDoPLmYHeKLTJv == P_1.xXVFUlKLPNHgRYFDoPLmYHeKLTJv && P_0.CgMXetUPlNSUAzubEJvjdImdTTgd == P_1.CgMXetUPlNSUAzubEJvjdImdTTgd && P_0.rjCFVZWdewKNqvZVerHdNSWFqiFq == P_1.rjCFVZWdewKNqvZVerHdNSWFqiFq)
			{
				return P_0.TJRCNrpYMknEsrUrOwrrPIBmvyAn == P_1.TJRCNrpYMknEsrUrOwrrPIBmvyAn;
			}
			return false;
		}
	}

	public enum SQCCnpHZEAbzlFSPdYnuwQJtfJNMA
	{
		Synchronous = 0,
		Asynchronous = 1
	}

	public const int NVmrNsnIeWhdZTgtFTkoClPmwOLn = 4;

	public const int tiacxflbQLEuWVBAvHGzIqCIhPkm = 32768;

	public const int pOOEEHyznwopSYqrbItAztAQGfsP = -32768;

	public const int yeYTdldtPyJkIPUThiYiRSFltFOb = 255;

	public const int PDTwgZyLNMjdvhXrgOHBKfxnUMxe = 0;

	public const int odJpSOIBaJlyLUHgmsnVJVlvSRRU = 18;

	public const int zsojpiiuRftnGxuWiMQHsDcwJhjy = 14;

	public const int oKfgkniAjeojYBtufjueojedYCDwe = 6;

	public const int DVAtHZoqGotLhHjnWyjQAWtjxcZG = 15;

	private ZGCDdmzeSTxEgTUkALmuobQyEeWu[] yYBTiXHJrfNEYiYmBnobaXKwECQL;

	private bool hwyeRIehYdRJLWLTOUjFBifRCDwj;

	private jMDuweOqMavWMsQBKtbOTSzdLBXj NFPazyoglKnpWFQppczKtKkpChibA;

	private JdTpqDVkworaeuNFRtgbaPXhzpZl nSCIcOhdPGfQAbkzKKgzHccCyzUbA;

	private global::xgduufxNbOgmNamvRoWQleTIUVZc<bool> hTxQjePknkdtjCWJLelUxxpCXGktA;

	private bool[] PKZuDttNYKhLzBjFZnBIgPtNpEey;

	private bool[] VtFlfJGhesxiZHIYvDIjLudWFMmH;

	private bool zQntoFpholeiPlrfkoWoQXLwrYHi;

	private readonly bool qRaHZkbHQUGTeXrpjBjqQrkFRGEl;

	private readonly UpdateLoopSetting LdaRmxKbOrOHjdcfrfVFtQEucjsE;

	private UpdateLoopType zCOaSEAZuDXqJfNXUsEWxslzdanR;

	private UpdateLoopType gNYQghVFVKWQITohhwmFoGGJFpjgA;

	private Action<int, ControllerDataUpdater> xJVBiZxyBbGNqYbLWiDyVbLovMjy;

	private bool OuWDgdvUgQQxpXdxWvQLxNPMyLWc;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> upGGKKfmHlzYqjgSpJQsqMezATnm;

	private Func<int> VdikOopqRrTaoJuuwBeDQFnWCaXeA;

	private Func<PidVid, bool> MqnKKgzwMirEpOGkSnvioHsURQnw;

	private static Guid[] YHdKDWsdUbZRSEhIYMMSbqrmkdut;

	private static string[] MCXhJxAhLUfsmaNWNvKIJEYvhUpt;

	private static string[] VuqwiWsvopnotpCdwoSGLpOjugqv;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (yYBTiXHJrfNEYiYmBnobaXKwECQL[i].eWtAEPJIDFXZdSSlsBsZXWwinIkmA)
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

	mYatOtUnQZvEUnhBaBEdFlEKDPkSA QdLLDjUvbeJHvwTMuBtdvfsbPLHe.uIdEzDErjuQvJFjMpkIVjVoDVMrH => mYatOtUnQZvEUnhBaBEdFlEKDPkSA.XInput;

	public GPtQVYpGsbJZEFsgHCDbdnqvIWNV(bool P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, Func<PidVid, bool> P_4)
	{
		qRaHZkbHQUGTeXrpjBjqQrkFRGEl = P_0;
		LdaRmxKbOrOHjdcfrfVFtQEucjsE = P_1;
		MqnKKgzwMirEpOGkSnvioHsURQnw = P_4;
		OuWDgdvUgQQxpXdxWvQLxNPMyLWc = true;
		try
		{
			if (!xYoDbOgqRzHthdFjePrhFpDaEuRD.ctLfJnurzyyVmnaSbVloKotNRjIw(out var dWgbVqHXPLEuVDwFtdYUqgvPCQEeA2, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (dWgbVqHXPLEuVDwFtdYUqgvPCQEeA2 < dWgbVqHXPLEuVDwFtdYUqgvPCQEeA.XINPUT_1_3)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			upGGKKfmHlzYqjgSpJQsqMezATnm = P_2;
			VdikOopqRrTaoJuuwBeDQFnWCaXeA = P_3;
			zQntoFpholeiPlrfkoWoQXLwrYHi = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(LdaRmxKbOrOHjdcfrfVFtQEucjsE, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					gNYQghVFVKWQITohhwmFoGGJFpjgA = list[num2];
				}
			}
			hTxQjePknkdtjCWJLelUxxpCXGktA = new global::xgduufxNbOgmNamvRoWQleTIUVZc<bool>(true, iktssASLkAXKnjxoXqlAuxhXZYAH);
			PKZuDttNYKhLzBjFZnBIgPtNpEey = new bool[4];
			VtFlfJGhesxiZHIYvDIjLudWFMmH = new bool[4];
			xJVBiZxyBbGNqYbLWiDyVbLovMjy = UpdateControllerData;
			if (zQntoFpholeiPlrfkoWoQXLwrYHi)
			{
				GWSzQeKAhWenmBhaaBxemOOWjWAkA();
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
		if (OuWDgdvUgQQxpXdxWvQLxNPMyLWc)
		{
			NFPazyoglKnpWFQppczKtKkpChibA = new jMDuweOqMavWMsQBKtbOTSzdLBXj(1f);
		}
		nSCIcOhdPGfQAbkzKKgzHccCyzUbA = new JdTpqDVkworaeuNFRtgbaPXhzpZl();
		if (yYBTiXHJrfNEYiYmBnobaXKwECQL == null)
		{
			yYBTiXHJrfNEYiYmBnobaXKwECQL = new ZGCDdmzeSTxEgTUkALmuobQyEeWu[4];
			for (int i = 0; i < 4; i++)
			{
				BuZsqkobnKmKKBwfCtzQJcPDbpshA buZsqkobnKmKKBwfCtzQJcPDbpshA = new BuZsqkobnKmKKBwfCtzQJcPDbpshA(i, LdaRmxKbOrOHjdcfrfVFtQEucjsE);
				GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent += buZsqkobnKmKKBwfCtzQJcPDbpshA.mIxHSZFwvGuaIXPABzYEfdUBXFlO;
				GGlKyqwtSRgaaWuZtxjwSYfoOckk.tRiPHogfXqTNFrlrzXWBLUlWuMgA.ThreadUpdateEvent += buZsqkobnKmKKBwfCtzQJcPDbpshA.gQnbYKCGtdJkXEeIqznwiUMRWhDB;
				yYBTiXHJrfNEYiYmBnobaXKwECQL[i] = new ZGCDdmzeSTxEgTUkALmuobQyEeWu(i, zQntoFpholeiPlrfkoWoQXLwrYHi, buZsqkobnKmKKBwfCtzQJcPDbpshA, upGGKKfmHlzYqjgSpJQsqMezATnm, SystemDeviceDisconnected);
			}
		}
		MSScUAcgaJkIteQrSutQBfjYVZCg(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		zCOaSEAZuDXqJfNXUsEWxslzdanR = currentUpdateLoop;
		JLqwTSkfbfExrlsBONReOmOTZjuE();
		for (int i = 0; i < 4; i++)
		{
			if (yYBTiXHJrfNEYiYmBnobaXKwECQL[i] != null && yYBTiXHJrfNEYiYmBnobaXKwECQL[i].eWtAEPJIDFXZdSSlsBsZXWwinIkmA)
			{
				yYBTiXHJrfNEYiYmBnobaXKwECQL[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (hTxQjePknkdtjCWJLelUxxpCXGktA != null)
		{
			hTxQjePknkdtjCWJLelUxxpCXGktA.FOYyubOeaZiQjSwliSBfnAKTjoxy();
		}
		if (yYBTiXHJrfNEYiYmBnobaXKwECQL != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (yYBTiXHJrfNEYiYmBnobaXKwECQL[i] != null)
				{
					if (GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb != null)
					{
						GGlKyqwtSRgaaWuZtxjwSYfoOckk.aAXwUWdIwRCtrGoXoWkdjmgtCORGb.ThreadUpdateEvent -= yYBTiXHJrfNEYiYmBnobaXKwECQL[i].TGyHjUooLEUfLdUCPSKavtsdnSXC.mIxHSZFwvGuaIXPABzYEfdUBXFlO;
					}
					if (GGlKyqwtSRgaaWuZtxjwSYfoOckk.tRiPHogfXqTNFrlrzXWBLUlWuMgA != null)
					{
						GGlKyqwtSRgaaWuZtxjwSYfoOckk.tRiPHogfXqTNFrlrzXWBLUlWuMgA.ThreadUpdateEvent -= yYBTiXHJrfNEYiYmBnobaXKwECQL[i].TGyHjUooLEUfLdUCPSKavtsdnSXC.gQnbYKCGtdJkXEeIqznwiUMRWhDB;
					}
					yYBTiXHJrfNEYiYmBnobaXKwECQL[i].Dispose();
				}
			}
		}
		xYoDbOgqRzHthdFjePrhFpDaEuRD.zbXOefZXTEMjKlCCTUnHpiNidacq();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return xJVBiZxyBbGNqYbLWiDyVbLovMjy;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		yYBTiXHJrfNEYiYmBnobaXKwECQL[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		MSScUAcgaJkIteQrSutQBfjYVZCg(true);
		IfiTJPgYRkAHwixlObcPQXMYEaqc();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		MSScUAcgaJkIteQrSutQBfjYVZCg(true);
		IfiTJPgYRkAHwixlObcPQXMYEaqc();
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

	bool QdLLDjUvbeJHvwTMuBtdvfsbPLHe.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		if (MqnKKgzwMirEpOGkSnvioHsURQnw(pidVid))
		{
			return false;
		}
		return UEyBmViuLiPuhzHQfktdcKNhuvpIB(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid(pidVid.vendorId, pidVid.productId));
	}

	private bool eVOSSmhddFGkRtKIPTyskzdHnKGR()
	{
		if (zCOaSEAZuDXqJfNXUsEWxslzdanR != gNYQghVFVKWQITohhwmFoGGJFpjgA)
		{
			return false;
		}
		bool num = NFPazyoglKnpWFQppczKtKkpChibA.JYBKOCTjkJSRcLKpyZgYHykdQYiE();
		if (num)
		{
			MSScUAcgaJkIteQrSutQBfjYVZCg(true);
		}
		return num;
	}

	private void MSScUAcgaJkIteQrSutQBfjYVZCg(bool P_0)
	{
		hwyeRIehYdRJLWLTOUjFBifRCDwj = P_0;
		if (OuWDgdvUgQQxpXdxWvQLxNPMyLWc)
		{
			NFPazyoglKnpWFQppczKtKkpChibA.eJncDrznKeGPGIxLozhFaVTVDDCeb();
		}
	}

	private void IfiTJPgYRkAHwixlObcPQXMYEaqc()
	{
		if (hTxQjePknkdtjCWJLelUxxpCXGktA != null)
		{
			hTxQjePknkdtjCWJLelUxxpCXGktA.MbxlxWAPjhnJbxoHACPkdinfnmabb();
		}
	}

	private void GWSzQeKAhWenmBhaaBxemOOWjWAkA()
	{
		_ = new CAUdltGlQSoHgQZtmbnLmjHstndg().oHclAshgIlValbIZfNHVaIVOElDAA;
	}

	private void JLqwTSkfbfExrlsBONReOmOTZjuE()
	{
		bool flag = false;
		if (OuWDgdvUgQQxpXdxWvQLxNPMyLWc)
		{
			flag = eVOSSmhddFGkRtKIPTyskzdHnKGR();
		}
		if (!flag && hwyeRIehYdRJLWLTOUjFBifRCDwj)
		{
			ZyyDvSpJmRiHPKZUPhrGLFrwIYVeA(JhJWIJfWHpDseENXZcvOBCRUstjOA());
			MSScUAcgaJkIteQrSutQBfjYVZCg(false);
			IfiTJPgYRkAHwixlObcPQXMYEaqc();
			return;
		}
		if (hwyeRIehYdRJLWLTOUjFBifRCDwj)
		{
			ylFwJIwUbGTzbWtVhErEJNHwjqCaA();
		}
		if (hTxQjePknkdtjCWJLelUxxpCXGktA.YibZslQejybegMCwglLcbMXjXREh && hTxQjePknkdtjCWJLelUxxpCXGktA.QPPcnXHfsXuMerWBTRMGFYgQdvAf())
		{
			iRrFisJNBersUKhwgJsorEZPMlSUA();
		}
	}

	private void ylFwJIwUbGTzbWtVhErEJNHwjqCaA()
	{
		hwyeRIehYdRJLWLTOUjFBifRCDwj = false;
		if (!hTxQjePknkdtjCWJLelUxxpCXGktA.YibZslQejybegMCwglLcbMXjXREh)
		{
			hTxQjePknkdtjCWJLelUxxpCXGktA.gVRMdQUdMoWjfTCoTwRPEnVbhauCA();
		}
	}

	private void iRrFisJNBersUKhwgJsorEZPMlSUA()
	{
		lock (PKZuDttNYKhLzBjFZnBIgPtNpEey)
		{
			Array.Copy(PKZuDttNYKhLzBjFZnBIgPtNpEey, VtFlfJGhesxiZHIYvDIjLudWFMmH, 4);
		}
		ZyyDvSpJmRiHPKZUPhrGLFrwIYVeA(VtFlfJGhesxiZHIYvDIjLudWFMmH);
	}

	private bool iktssASLkAXKnjxoXqlAuxhXZYAH()
	{
		lock (PKZuDttNYKhLzBjFZnBIgPtNpEey)
		{
			for (int i = 0; i < 4; i++)
			{
				if (yYBTiXHJrfNEYiYmBnobaXKwECQL[i] != null)
				{
					PKZuDttNYKhLzBjFZnBIgPtNpEey[i] = yYBTiXHJrfNEYiYmBnobaXKwECQL[i].DYUhPBssOesDKkQgIdSNQyPoPyE(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Synchronous);
				}
			}
		}
		return true;
	}

	private bool[] JhJWIJfWHpDseENXZcvOBCRUstjOA()
	{
		for (int i = 0; i < 4; i++)
		{
			VtFlfJGhesxiZHIYvDIjLudWFMmH[i] = yYBTiXHJrfNEYiYmBnobaXKwECQL[i].DYUhPBssOesDKkQgIdSNQyPoPyE(SQCCnpHZEAbzlFSPdYnuwQJtfJNMA.Synchronous);
		}
		return VtFlfJGhesxiZHIYvDIjLudWFMmH;
	}

	private void ZyyDvSpJmRiHPKZUPhrGLFrwIYVeA(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (yYBTiXHJrfNEYiYmBnobaXKwECQL[i] != null && yYBTiXHJrfNEYiYmBnobaXKwECQL[i].VgiwfhOaqMATlHJBtDbRFPIabQByb)
			{
				bool flag = P_0[i];
				yYBTiXHJrfNEYiYmBnobaXKwECQL[i].RvVMGgBeCdrmseFHuxrSbznfMYqu(flag);
				if (!flag)
				{
					xpCmvGciNUmNiAuPldbMTDnTmbxP(yYBTiXHJrfNEYiYmBnobaXKwECQL[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (yYBTiXHJrfNEYiYmBnobaXKwECQL[j] != null && !yYBTiXHJrfNEYiYmBnobaXKwECQL[j].VgiwfhOaqMATlHJBtDbRFPIabQByb)
			{
				bool flag2 = P_0[j];
				yYBTiXHJrfNEYiYmBnobaXKwECQL[j].RvVMGgBeCdrmseFHuxrSbznfMYqu(flag2);
				if (flag2 && !xpCmvGciNUmNiAuPldbMTDnTmbxP(yYBTiXHJrfNEYiYmBnobaXKwECQL[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (yYBTiXHJrfNEYiYmBnobaXKwECQL[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					yYBTiXHJrfNEYiYmBnobaXKwECQL[k].DoQPeimNWJCYtAUhOyVgWqRNCbkL(P_0[k]);
				}
			}
		}
	}

	private bool xpCmvGciNUmNiAuPldbMTDnTmbxP(ZGCDdmzeSTxEgTUkALmuobQyEeWu P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.UyNGpSHkMYpBWdQlHHXsWxmZehFeb();
			if (!P_0.LQoDNWYFCfeWazOqRODbEOxbYMvM)
			{
				return false;
			}
			int num = nSCIcOhdPGfQAbkzKKgzHccCyzUbA.PkcfnBzHZvoFByblmJBOTlScpSMX(P_0.kqPTlDnIDrEiuDgyEKlprGqBXQcIA, false);
			if (num >= 0)
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = nSCIcOhdPGfQAbkzKKgzHccCyzUbA.XSDwqamaxlbKVfKDhOcwZOGCImauA(num);
				nSCIcOhdPGfQAbkzKKgzHccCyzUbA.ldrmNiSqWnPlYKiIbLEGAFehiFuD(num, P_0, true);
			}
			else
			{
				P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId = VdikOopqRrTaoJuuwBeDQFnWCaXeA();
				nSCIcOhdPGfQAbkzKKgzHccCyzUbA.cvWazhCeTOIqTJOHQubsqzsbPpNO(P_0, true);
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
			int num2 = nSCIcOhdPGfQAbkzKKgzHccCyzUbA.IYDGDMudjHJahpcNbnUHWaBtsCPP(P_0.Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002ErewiredId, P_0.kqPTlDnIDrEiuDgyEKlprGqBXQcIA, true);
			if (num2 >= 0)
			{
				nSCIcOhdPGfQAbkzKKgzHccCyzUbA.EygqWaFMomatEUvfTIsjuYiXayvM(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.DIhELPAlOLKqgoZvHJKTUrkwlBVlA();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static GPtQVYpGsbJZEFsgHCDbdnqvIWNV()
	{
		YHdKDWsdUbZRSEhIYMMSbqrmkdut = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		MCXhJxAhLUfsmaNWNvKIJEYvhUpt = new string[1] { "Xbox Bluetooth Gamepad" };
		VuqwiWsvopnotpCdwoSGLpOjugqv = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool UEyBmViuLiPuhzHQfktdcKNhuvpIB(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(YHdKDWsdUbZRSEhIYMMSbqrmkdut, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < MCXhJxAhLUfsmaNWNvKIJEYvhUpt.Length; i++)
			{
				if (P_1.Equals(MCXhJxAhLUfsmaNWNvKIJEYvhUpt[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < VuqwiWsvopnotpCdwoSGLpOjugqv.Length; j++)
			{
				if (Regex.IsMatch(P_2, VuqwiWsvopnotpCdwoSGLpOjugqv[j], RegexOptions.IgnoreCase))
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
