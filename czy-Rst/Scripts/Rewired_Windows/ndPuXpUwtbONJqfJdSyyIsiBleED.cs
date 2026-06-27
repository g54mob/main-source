using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class ndPuXpUwtbONJqfJdSyyIsiBleED : PlatformInputManager, INativePlatformHelper
{
	private class syHlbqFqXwWfOJkmpRjCwOIxByRs
	{
		private class LwxjRleIdljStUttjvLUMOGrqJce
		{
			public int ONReBYTanUfYIiIrVqvhuEdERkmGb;

			public int uiqaqocvLWtgfZdtztPQHwipEqeh;

			public int XXHbASIpukOmosAowqUgjNsAFEMj;

			public InputSource wMnvCgXmSUPhApSOacaRCQNbYUtR;

			public LwxjRleIdljStUttjvLUMOGrqJce(int P_0, int P_1, int P_2, InputSource P_3)
			{
				ONReBYTanUfYIiIrVqvhuEdERkmGb = P_0;
				uiqaqocvLWtgfZdtztPQHwipEqeh = P_1;
				XXHbASIpukOmosAowqUgjNsAFEMj = P_2;
				wMnvCgXmSUPhApSOacaRCQNbYUtR = P_3;
			}

			public void HmcBsfgUuMeBbpHHpfqmoktBgQGU(int P_0)
			{
				uiqaqocvLWtgfZdtztPQHwipEqeh = P_0;
			}

			public uXeSQiviPFRgQxCaFcrhAMzwJGDfA CISDFxziczXGScpszSxRwYCfJsMC()
			{
				return new uXeSQiviPFRgQxCaFcrhAMzwJGDfA(ONReBYTanUfYIiIrVqvhuEdERkmGb, uiqaqocvLWtgfZdtztPQHwipEqeh, wMnvCgXmSUPhApSOacaRCQNbYUtR);
			}

			public static int bMoJQEumndhnrqDtHczBbTvgoJoB(LwxjRleIdljStUttjvLUMOGrqJce P_0, LwxjRleIdljStUttjvLUMOGrqJce P_1)
			{
				if (P_0.ONReBYTanUfYIiIrVqvhuEdERkmGb < P_1.ONReBYTanUfYIiIrVqvhuEdERkmGb)
				{
					return -1;
				}
				if (P_0.ONReBYTanUfYIiIrVqvhuEdERkmGb > P_1.ONReBYTanUfYIiIrVqvhuEdERkmGb)
				{
					return 1;
				}
				return 0;
			}
		}

		public struct uXeSQiviPFRgQxCaFcrhAMzwJGDfA
		{
			public int VMInDAErVtemvwOVJdkgFdxmPkHcb;

			public int VMlgMtLoTazOHqOcPdZmghYTgDiOA;

			public InputSource YAWRYYSxdSKuvwAdzeyxLhVdlCIm;

			public uXeSQiviPFRgQxCaFcrhAMzwJGDfA(int P_0, int P_1, InputSource P_2)
			{
				VMInDAErVtemvwOVJdkgFdxmPkHcb = P_0;
				VMlgMtLoTazOHqOcPdZmghYTgDiOA = P_1;
				YAWRYYSxdSKuvwAdzeyxLhVdlCIm = P_2;
			}
		}

		public enum tjvzbTwNQacMWkAcalSMLAZJitOz
		{
			Connected = 0,
			Disconnected = 1
		}

		private List<LwxjRleIdljStUttjvLUMOGrqJce> tVTnsAstsBHbmiLCVfmYkKWFjNTeA;

		private List<LwxjRleIdljStUttjvLUMOGrqJce> VGjTMdieQqiEEhgEDvkOfNlhKgLC;

		public int JsVdczffTNfMmiBendTcfnFCjDSNb => VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count;

		public syHlbqFqXwWfOJkmpRjCwOIxByRs()
		{
			VGjTMdieQqiEEhgEDvkOfNlhKgLC = new List<LwxjRleIdljStUttjvLUMOGrqJce>();
			tVTnsAstsBHbmiLCVfmYkKWFjNTeA = new List<LwxjRleIdljStUttjvLUMOGrqJce>();
		}

		public void fewHUhsmsrTqYNFsQKUkKMMRDoWl(BridgedController P_0)
		{
			if (P_0 == null || P_0.sourceJoystick == null)
			{
				return;
			}
			IInputManagerJoystickPublic sourceJoystick = P_0.sourceJoystick;
			int num = DtcjpZIOjtazPgaBJFWqixLPLZtrA(sourceJoystick.rewiredId, tjvzbTwNQacMWkAcalSMLAZJitOz.Connected);
			LwxjRleIdljStUttjvLUMOGrqJce lwxjRleIdljStUttjvLUMOGrqJce;
			if (num >= 0)
			{
				lwxjRleIdljStUttjvLUMOGrqJce = VGjTMdieQqiEEhgEDvkOfNlhKgLC[num];
				lwxjRleIdljStUttjvLUMOGrqJce.HmcBsfgUuMeBbpHHpfqmoktBgQGU(sourceJoystick.inputManagerId);
				P_0.sourceJoystick = new lCmGFmqJxcJwSLPnMMWuSespLHRH(sourceJoystick, lwxjRleIdljStUttjvLUMOGrqJce.ONReBYTanUfYIiIrVqvhuEdERkmGb);
				return;
			}
			num = DtcjpZIOjtazPgaBJFWqixLPLZtrA(sourceJoystick.rewiredId, tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected);
			if (num >= 0)
			{
				lwxjRleIdljStUttjvLUMOGrqJce = tVTnsAstsBHbmiLCVfmYkKWFjNTeA[num];
				tVTnsAstsBHbmiLCVfmYkKWFjNTeA.RemoveAt(num);
				int oNReBYTanUfYIiIrVqvhuEdERkmGb = VJZzHXDvkANIBhLmkhDXekuwAfxF(lwxjRleIdljStUttjvLUMOGrqJce.ONReBYTanUfYIiIrVqvhuEdERkmGb);
				lwxjRleIdljStUttjvLUMOGrqJce.ONReBYTanUfYIiIrVqvhuEdERkmGb = oNReBYTanUfYIiIrVqvhuEdERkmGb;
			}
			else
			{
				lwxjRleIdljStUttjvLUMOGrqJce = new LwxjRleIdljStUttjvLUMOGrqJce(dQVPiXOknuSPvziEctElxcwCdUyBA(), sourceJoystick.inputManagerId, sourceJoystick.rewiredId, P_0.inputManagerSource);
			}
			P_0.sourceJoystick = new lCmGFmqJxcJwSLPnMMWuSespLHRH(sourceJoystick, lwxjRleIdljStUttjvLUMOGrqJce.ONReBYTanUfYIiIrVqvhuEdERkmGb);
			VGjTMdieQqiEEhgEDvkOfNlhKgLC.Add(lwxjRleIdljStUttjvLUMOGrqJce);
			VGjTMdieQqiEEhgEDvkOfNlhKgLC.Sort(LwxjRleIdljStUttjvLUMOGrqJce.bMoJQEumndhnrqDtHczBbTvgoJoB);
		}

		public void MaqHXezjoufRlawZmtOeHEkgPxzbA(ControllerDisconnectedEventArgs P_0)
		{
			if (P_0 != null)
			{
				int num = DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0.rewiredId, tjvzbTwNQacMWkAcalSMLAZJitOz.Connected);
				if (num < 0)
				{
					Logger.LogError("Device was not in connected list! Cannot remove!");
					return;
				}
				LwxjRleIdljStUttjvLUMOGrqJce item = VGjTMdieQqiEEhgEDvkOfNlhKgLC[num];
				VGjTMdieQqiEEhgEDvkOfNlhKgLC.RemoveAt(num);
				tVTnsAstsBHbmiLCVfmYkKWFjNTeA.Add(item);
			}
		}

		public void qoeSkqeiBSwhUxcxbBgEbmRczfLX(int P_0, int P_1)
		{
			int num = DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0, tjvzbTwNQacMWkAcalSMLAZJitOz.Connected);
			if (num >= 0)
			{
				VGjTMdieQqiEEhgEDvkOfNlhKgLC[num].HmcBsfgUuMeBbpHHpfqmoktBgQGU(P_1);
				return;
			}
			num = DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0, tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected);
			if (num >= 0)
			{
				tVTnsAstsBHbmiLCVfmYkKWFjNTeA[num].HmcBsfgUuMeBbpHHpfqmoktBgQGU(P_1);
			}
		}

		public bool YRTmeOdTZJHvJMPkfKDaorJOWvEG(int P_0, tjvzbTwNQacMWkAcalSMLAZJitOz P_1)
		{
			if (DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0, P_1) < 0)
			{
				return false;
			}
			return true;
		}

		public int DtcjpZIOjtazPgaBJFWqixLPLZtrA(int P_0, tjvzbTwNQacMWkAcalSMLAZJitOz P_1)
		{
			switch (P_1)
			{
			case tjvzbTwNQacMWkAcalSMLAZJitOz.Connected:
			{
				int count2 = VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count;
				for (int j = 0; j < count2; j++)
				{
					if (VGjTMdieQqiEEhgEDvkOfNlhKgLC[j].XXHbASIpukOmosAowqUgjNsAFEMj == P_0)
					{
						return j;
					}
				}
				break;
			}
			case tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected:
			{
				int count = tVTnsAstsBHbmiLCVfmYkKWFjNTeA.Count;
				for (int i = 0; i < count; i++)
				{
					if (tVTnsAstsBHbmiLCVfmYkKWFjNTeA[i].XXHbASIpukOmosAowqUgjNsAFEMj == P_0)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public int pdOmrVukJNkUxUobGVAzTOqoGtAB(int P_0, InputSource P_1, tjvzbTwNQacMWkAcalSMLAZJitOz P_2)
		{
			switch (P_2)
			{
			case tjvzbTwNQacMWkAcalSMLAZJitOz.Connected:
			{
				int count2 = VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count;
				for (int j = 0; j < count2; j++)
				{
					if (VGjTMdieQqiEEhgEDvkOfNlhKgLC[j].ONReBYTanUfYIiIrVqvhuEdERkmGb == P_0 && VGjTMdieQqiEEhgEDvkOfNlhKgLC[j].wMnvCgXmSUPhApSOacaRCQNbYUtR == P_1)
					{
						return j;
					}
				}
				break;
			}
			case tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected:
			{
				int count = tVTnsAstsBHbmiLCVfmYkKWFjNTeA.Count;
				for (int i = 0; i < count; i++)
				{
					if (tVTnsAstsBHbmiLCVfmYkKWFjNTeA[i].ONReBYTanUfYIiIrVqvhuEdERkmGb == P_0 && tVTnsAstsBHbmiLCVfmYkKWFjNTeA[i].wMnvCgXmSUPhApSOacaRCQNbYUtR == P_1)
					{
						return i;
					}
				}
				break;
			}
			}
			return -1;
		}

		public uXeSQiviPFRgQxCaFcrhAMzwJGDfA KqvKfYCpLFvjbFAXAlFqUQnMuMWk(int P_0, tjvzbTwNQacMWkAcalSMLAZJitOz P_1)
		{
			if (P_1 == tjvzbTwNQacMWkAcalSMLAZJitOz.Connected)
			{
				if (P_0 < 0 || P_0 >= VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				return VGjTMdieQqiEEhgEDvkOfNlhKgLC[P_0].CISDFxziczXGScpszSxRwYCfJsMC();
			}
			if (P_0 < 0 || P_0 >= tVTnsAstsBHbmiLCVfmYkKWFjNTeA.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return tVTnsAstsBHbmiLCVfmYkKWFjNTeA[P_0].CISDFxziczXGScpszSxRwYCfJsMC();
		}

		public int ZwsHUZhWNPOpkDfdElcugLeTpiCj(int P_0, InputSource P_1, tjvzbTwNQacMWkAcalSMLAZJitOz P_2)
		{
			int num = pdOmrVukJNkUxUobGVAzTOqoGtAB(P_0, P_1, P_2);
			if (num < 0)
			{
				return -1;
			}
			return P_2 switch
			{
				tjvzbTwNQacMWkAcalSMLAZJitOz.Connected => VGjTMdieQqiEEhgEDvkOfNlhKgLC[num].uiqaqocvLWtgfZdtztPQHwipEqeh, 
				tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected => tVTnsAstsBHbmiLCVfmYkKWFjNTeA[num].uiqaqocvLWtgfZdtztPQHwipEqeh, 
				_ => -1, 
			};
		}

		private int VJZzHXDvkANIBhLmkhDXekuwAfxF(int P_0)
		{
			int count = VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count;
			for (int i = 0; i < count; i++)
			{
				if (VGjTMdieQqiEEhgEDvkOfNlhKgLC[i].ONReBYTanUfYIiIrVqvhuEdERkmGb == P_0)
				{
					return dQVPiXOknuSPvziEctElxcwCdUyBA();
				}
			}
			return P_0;
		}

		private int dQVPiXOknuSPvziEctElxcwCdUyBA()
		{
			int count = VGjTMdieQqiEEhgEDvkOfNlhKgLC.Count;
			int num = 0;
			while (true)
			{
				bool flag = false;
				for (int i = 0; i < count; i++)
				{
					if (VGjTMdieQqiEEhgEDvkOfNlhKgLC[i].ONReBYTanUfYIiIrVqvhuEdERkmGb == num)
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
	}

	private class lCmGFmqJxcJwSLPnMMWuSespLHRH : IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private IInputManagerJoystickPublic unOKNcwDFvBtbRRlmIOArflrzKsk;

		private int gVYLfhSUAlUNJfvGydZSrzWlazAq;

		int IInputManagerJoystickPublic.rewiredId => unOKNcwDFvBtbRRlmIOArflrzKsk.rewiredId;

		int IInputManagerJoystickPublic.inputManagerId => gVYLfhSUAlUNJfvGydZSrzWlazAq;

		string IInputManagerJoystickPublic.name => unOKNcwDFvBtbRRlmIOArflrzKsk.name;

		long? IInputManagerJoystickPublic.systemId => unOKNcwDFvBtbRRlmIOArflrzKsk.systemId;

		int IInputManagerJoystickPublic.unityId => unOKNcwDFvBtbRRlmIOArflrzKsk.unityId;

		Guid IInputManagerJoystickPublic.instanceGuid => unOKNcwDFvBtbRRlmIOArflrzKsk.instanceGuid;

		Guid IInputManagerJoystickPublic.persistentGuid => Rewired_002EInterfaces_002EIInputManagerJoystickPublic_002EinstanceGuid;

		Controller.Extension IInputManagerJoystickPublic.extension => unOKNcwDFvBtbRRlmIOArflrzKsk.extension;

		public lCmGFmqJxcJwSLPnMMWuSespLHRH(IInputManagerJoystickPublic P_0, int P_1)
		{
			unOKNcwDFvBtbRRlmIOArflrzKsk = P_0;
			gVYLfhSUAlUNJfvGydZSrzWlazAq = P_1;
		}

		public void SetVibration(float amount, int motorIndex)
		{
			unOKNcwDFvBtbRRlmIOArflrzKsk.SetVibration(amount, motorIndex);
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		public void StopVibration()
		{
			unOKNcwDFvBtbRRlmIOArflrzKsk.StopVibration();
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (unOKNcwDFvBtbRRlmIOArflrzKsk is ITryGetLocalizedName tryGetLocalizedName)
			{
				return tryGetLocalizedName.TryGetLocalizedName(out value);
			}
			value = null;
			return false;
		}
	}

	[Serializable]
	private sealed class SLESUSsoizFnCuzFzYaOSrEaQxzi
	{
		public static readonly SLESUSsoizFnCuzFzYaOSrEaQxzi _003C_003E9 = new SLESUSsoizFnCuzFzYaOSrEaQxzi();

		public static Func<PidVid, bool> _003C_003E9__17_0;

		internal bool gSpYzSiqRATVnxIDphBfrntfyAmN(PidVid P_0)
		{
			return false;
		}
	}

	private sealed class bfGILcARUcIsmCPSWSEFRGZsdksVA
	{
		public int GnXYnPLgqvryyyaWpZhBRJTKVMAW;

		internal int dkqwTsSGOkGskadRZMOUInUjqIOob()
		{
			return GnXYnPLgqvryyyaWpZhBRJTKVMAW++;
		}
	}

	private const bool qXQvrZuGEmihyFDgNTAdDZeMmhtLA = false;

	private const bool mjOhpUZTNgzQqxULqpsskiXsiVSG = false;

	private const bool NZvagDbsgwjSRayteGsuhkGFJXwqc = false;

	private const bool RSYkBfJKSljzxmonkCPrnLFPCamdA = false;

	private const bool rCBmqeQXmcAYdnEuovwKoWCSlLpM = false;

	private const bool rHjGjzkhADnqUEhgKhFvVlebsZulB = false;

	private bool lfbzBvNbsLdVdxjrDRnfDxfJpWt;

	private xAAARHJpGeNEmXXisDcrWtIrxcCb XheryrpOdbzPevIPLafkzQNhLSts;

	private IndexedDictionary<int, PlatformInputManager> mmMBbIahSzXrCLKQPDKAVXtYtCCvA;

	private syHlbqFqXwWfOJkmpRjCwOIxByRs xKkyDumjNpTKqRBaVrUanizKxvHi;

	private Action<int, ControllerDataUpdater> zGITOZYrvNvjCwgaFeWKBEHmCKzS;

	private WindowsStandalonePrimaryInputSource roopVxeIpuSfDHDwPqtdiyBZLlmR;

	private PlatformInputManager CCAsIoHWdgdCtawYdiEIYtyJrGNR;

	private bool hqMBevkKmFvDHZxONvtxuamwBYmP;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZhYjQhBVtANcvzmhyrnlNqLhoXdg;

	private Func<int> gQVfzQUdZyUEbllYFeSQBNQsojWAA;

	private Func<PidVid, bool> wwzepISFYhAXyEzTuKMzuMhYyPCWA;

	[CustomObfuscation(rename = false)]
	private int counter;

	bool INativePlatformHelper.isApplicationFocused
	{
		get
		{
			IntPtr intPtr = NtPSOxELPOOaKLQRVmbwGRgHcLOL.PVuzEAmmgekMahdvMMEpEdClaksR();
			IntPtr intPtr2 = NtPSOxELPOOaKLQRVmbwGRgHcLOL.mfAwakXZewqnIYzQRlaMvZSxMEgj();
			if (intPtr2 != IntPtr.Zero)
			{
				return intPtr == intPtr2;
			}
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => xKkyDumjNpTKqRBaVrUanizKxvHi.JsVdczffTNfMmiBendTcfnFCjDSNb;

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => CCAsIoHWdgdCtawYdiEIYtyJrGNR;

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => CCAsIoHWdgdCtawYdiEIYtyJrGNR.inputSource;

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType
	{
		get
		{
			if (CCAsIoHWdgdCtawYdiEIYtyJrGNR == null)
			{
				return InputSource.None;
			}
			return CCAsIoHWdgdCtawYdiEIYtyJrGNR.inputSourceType;
		}
	}

	public ndPuXpUwtbONJqfJdSyyIsiBleED(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2)
	{
		try
		{
			roopVxeIpuSfDHDwPqtdiyBZLlmR = P_0.windowsStandalonePrimaryInputSource;
			wwzepISFYhAXyEzTuKMzuMhYyPCWA = SLESUSsoizFnCuzFzYaOSrEaQxzi._003C_003E9.gSpYzSiqRATVnxIDphBfrntfyAmN;
			bool flag = UnityTools.platform == Platform.WindowsAppStore || UnityTools.platform == Platform.Windows81Store || UnityTools.platform == Platform.WindowsPhone8;
			bool flag2 = UnityTools.platform == Platform.Windows && (roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.DirectInput || roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.RawInput);
			mYatOtUnQZvEUnhBaBEdFlEKDPkSA mYatOtUnQZvEUnhBaBEdFlEKDPkSA2 = mYatOtUnQZvEUnhBaBEdFlEKDPkSA.None;
			if (flag2)
			{
				mYatOtUnQZvEUnhBaBEdFlEKDPkSA2 = (P_0.GetPlatformVar_useWindowsGamingInput() ? mYatOtUnQZvEUnhBaBEdFlEKDPkSA.WindowsGamingInput : (P_0.useXInput ? mYatOtUnQZvEUnhBaBEdFlEKDPkSA.XInput : mYatOtUnQZvEUnhBaBEdFlEKDPkSA.None));
			}
			bool flag3 = mYatOtUnQZvEUnhBaBEdFlEKDPkSA2 == mYatOtUnQZvEUnhBaBEdFlEKDPkSA.WindowsGamingInput || mYatOtUnQZvEUnhBaBEdFlEKDPkSA2 == mYatOtUnQZvEUnhBaBEdFlEKDPkSA.XInput || roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.XInput || roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.WindowsGamingInput;
			ZhYjQhBVtANcvzmhyrnlNqLhoXdg = P_1;
			gQVfzQUdZyUEbllYFeSQBNQsojWAA = P_2;
			bool flag4 = false;
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA = new IndexedDictionary<int, PlatformInputManager>();
			PlatformInputManager platformInputManager = null;
			if (UnityTools.platform != Platform.WindowsAppStore)
			{
				try
				{
					GGlKyqwtSRgaaWuZtxjwSYfoOckk.HdhRnQdBBsnTOwgZyYRTDUbWtiCj(flag3);
				}
				catch (Exception ex)
				{
					OnDestroy();
					Logger.LogWarning("Unable to initialize input source!\n" + ex.Message);
					throw;
				}
			}
			if (flag2)
			{
				switch (mYatOtUnQZvEUnhBaBEdFlEKDPkSA2)
				{
				case mYatOtUnQZvEUnhBaBEdFlEKDPkSA.XInput:
					if (bWqfSvaWSUBmGPrGmjOolZchNIPo(P_0, false, out platformInputManager))
					{
						flag4 = true;
					}
					else
					{
						P_0.useXInput = false;
					}
					break;
				case mYatOtUnQZvEUnhBaBEdFlEKDPkSA.WindowsGamingInput:
					if (iImuANvXEllnWswRfQusAbMdYfjw(P_0, false, out platformInputManager))
					{
						break;
					}
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					if (P_0.useXInput && !flag4)
					{
						Logger.Log("Attempting to fallback to XInput...");
						if (bWqfSvaWSUBmGPrGmjOolZchNIPo(P_0, false, out platformInputManager))
						{
							flag4 = true;
							Logger.Log("XInput initialized.");
						}
						else
						{
							P_0.useXInput = false;
						}
					}
					break;
				}
			}
			if (flag)
			{
				if (!flag4 && !bWqfSvaWSUBmGPrGmjOolZchNIPo(P_0, true, out CCAsIoHWdgdCtawYdiEIYtyJrGNR))
				{
					throw new Exception();
				}
			}
			else if (UnityTools.platform != Platform.WindowsAppStore)
			{
				XheryrpOdbzPevIPLafkzQNhLSts = new xAAARHJpGeNEmXXisDcrWtIrxcCb();
				bool flag5 = false;
				if (roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.DirectInput)
				{
					flag5 = cctPgCmPnbmDKAHBfMTvOtAuOHdF(P_0, XheryrpOdbzPevIPLafkzQNhLSts, platformInputManager as QdLLDjUvbeJHvwTMuBtdvfsbPLHe);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = PreWnLVshXwvPdrYkiCPIGCkQslI(P_0, XheryrpOdbzPevIPLafkzQNhLSts, platformInputManager as QdLLDjUvbeJHvwTMuBtdvfsbPLHe);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							roopVxeIpuSfDHDwPqtdiyBZLlmR = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.RawInput)
				{
					flag5 = PreWnLVshXwvPdrYkiCPIGCkQslI(P_0, XheryrpOdbzPevIPLafkzQNhLSts, platformInputManager as QdLLDjUvbeJHvwTMuBtdvfsbPLHe);
					if (!flag5)
					{
						Logger.Log("Attempting to fallback to Direct Input...");
						flag5 = cctPgCmPnbmDKAHBfMTvOtAuOHdF(P_0, XheryrpOdbzPevIPLafkzQNhLSts, platformInputManager as QdLLDjUvbeJHvwTMuBtdvfsbPLHe);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.DirectInput;
							roopVxeIpuSfDHDwPqtdiyBZLlmR = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Direct Input initialized.");
						}
					}
				}
				else if (roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.XInput)
				{
					P_0.SetPlatformVar_useWindowsGamingInput(value: false);
					flag5 = bWqfSvaWSUBmGPrGmjOolZchNIPo(P_0, true, out CCAsIoHWdgdCtawYdiEIYtyJrGNR);
					flag4 = flag5;
					if (flag5)
					{
						kUfLPUPcszUpGAyuZJAqtpegtgUD(P_0, XheryrpOdbzPevIPLafkzQNhLSts);
					}
					else
					{
						P_0.useXInput = false;
						Logger.Log("Attempting to fallback to Raw Input...");
						flag5 = PreWnLVshXwvPdrYkiCPIGCkQslI(P_0, XheryrpOdbzPevIPLafkzQNhLSts, null);
						if (flag5)
						{
							P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
							roopVxeIpuSfDHDwPqtdiyBZLlmR = P_0.windowsStandalonePrimaryInputSource;
							Logger.Log("Raw Input initialized.");
						}
					}
				}
				else if (roopVxeIpuSfDHDwPqtdiyBZLlmR == WindowsStandalonePrimaryInputSource.WindowsGamingInput)
				{
					bool flag6 = true;
					flag5 = iImuANvXEllnWswRfQusAbMdYfjw(P_0, true, out CCAsIoHWdgdCtawYdiEIYtyJrGNR);
					if (!flag5)
					{
						P_0.SetPlatformVar_useWindowsGamingInput(value: false);
						if (P_0.useXInput && !flag4)
						{
							Logger.Log("Attempting to fallback to XInput...");
							flag5 = bWqfSvaWSUBmGPrGmjOolZchNIPo(P_0, true, out CCAsIoHWdgdCtawYdiEIYtyJrGNR);
							flag4 = flag5;
							if (flag5)
							{
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.XInput;
								Logger.Log("XInput initialized.");
							}
							else
							{
								P_0.useXInput = false;
							}
						}
						if (!flag5)
						{
							Logger.Log("Attempting to fallback to Raw Input...");
							flag5 = PreWnLVshXwvPdrYkiCPIGCkQslI(P_0, XheryrpOdbzPevIPLafkzQNhLSts, null);
							if (flag5)
							{
								flag6 = false;
								P_0.windowsStandalonePrimaryInputSource = WindowsStandalonePrimaryInputSource.RawInput;
								roopVxeIpuSfDHDwPqtdiyBZLlmR = P_0.windowsStandalonePrimaryInputSource;
								Logger.Log("Raw Input initialized.");
							}
						}
					}
					if (flag5 && flag6)
					{
						kUfLPUPcszUpGAyuZJAqtpegtgUD(P_0, XheryrpOdbzPevIPLafkzQNhLSts);
					}
				}
				if (!flag5)
				{
					throw new Exception();
				}
				XheryrpOdbzPevIPLafkzQNhLSts.gmaCsfinnSNSgcZzFLRAQovMBbNtb += LomUiNMewxYxAMHlFaxNKcNiSOYV;
				XheryrpOdbzPevIPLafkzQNhLSts.iHxpwMdqSdZfYYWFXCRoDBdBxDbk += hLGBWgeJbZOAtMzvvXUZzokWHVAT;
			}
			if (CCAsIoHWdgdCtawYdiEIYtyJrGNR == null)
			{
				throw new Exception("No primary input manager could be initialized.");
			}
			zGITOZYrvNvjCwgaFeWKBEHmCKzS = UpdateControllerData;
		}
		catch (Exception ex2)
		{
			OnDestroy();
			Logger.LogWarning("Unable to initialize input source!\n" + ex2.Message);
			throw;
		}
	}

	private bool cctPgCmPnbmDKAHBfMTvOtAuOHdF(ConfigVars P_0, xAAARHJpGeNEmXXisDcrWtIrxcCb P_1, QdLLDjUvbeJHvwTMuBtdvfsbPLHe P_2)
	{
		dKCtUwdeDBjLqfEjrVqDtrbboyLn dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = null;
		zkrnmDbTDQfoKXIpNpnFtnoyWKRE zkrnmDbTDQfoKXIpNpnFtnoyWKRE2 = null;
		try
		{
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = new dKCtUwdeDBjLqfEjrVqDtrbboyLn(P_0, null, null, null, false, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			zkrnmDbTDQfoKXIpNpnFtnoyWKRE2 = (zkrnmDbTDQfoKXIpNpnFtnoyWKRE)(CCAsIoHWdgdCtawYdiEIYtyJrGNR = new zkrnmDbTDQfoKXIpNpnFtnoyWKRE(P_0.updateLoop, P_2, P_1.ykTgahhfnIxXLAbmqJgupRCMpTchb, ZhYjQhBVtANcvzmhyrnlNqLhoXdg, gQVfzQUdZyUEbllYFeSQBNQsojWAA));
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(5, dKCtUwdeDBjLqfEjrVqDtrbboyLn2);
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(1, CCAsIoHWdgdCtawYdiEIYtyJrGNR);
			P_1.JsuSTXPviYcNryTOjrkSPuoRfrde += dKCtUwdeDBjLqfEjrVqDtrbboyLn2.WTXAwfRdDfGaJDPeFGPonRoFqlRz;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			zkrnmDbTDQfoKXIpNpnFtnoyWKRE2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
			zkrnmDbTDQfoKXIpNpnFtnoyWKRE2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
			zkrnmDbTDQfoKXIpNpnFtnoyWKRE2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			return true;
		}
		catch (Exception)
		{
			zkrnmDbTDQfoKXIpNpnFtnoyWKRE2?.OnDestroy();
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2?.OnDestroy();
			Logger.LogWarning("Unable to initialize Direct Input! ");
		}
		return false;
	}

	private bool PreWnLVshXwvPdrYkiCPIGCkQslI(ConfigVars P_0, xAAARHJpGeNEmXXisDcrWtIrxcCb P_1, QdLLDjUvbeJHvwTMuBtdvfsbPLHe P_2)
	{
		dKCtUwdeDBjLqfEjrVqDtrbboyLn dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = null;
		try
		{
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = new dKCtUwdeDBjLqfEjrVqDtrbboyLn(P_0, P_2, ZhYjQhBVtANcvzmhyrnlNqLhoXdg, gQVfzQUdZyUEbllYFeSQBNQsojWAA, true, P_0.GetPlatformVar_useNativeMouse(), P_0.GetPlatformVar_useNativeKeyboard(), P_0.GetPlatformVar_useEnhancedDeviceSupport());
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(5, dKCtUwdeDBjLqfEjrVqDtrbboyLn2);
			P_1.JsuSTXPviYcNryTOjrkSPuoRfrde += dKCtUwdeDBjLqfEjrVqDtrbboyLn2.WTXAwfRdDfGaJDPeFGPonRoFqlRz;
			CCAsIoHWdgdCtawYdiEIYtyJrGNR = dKCtUwdeDBjLqfEjrVqDtrbboyLn2;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			return true;
		}
		catch (Exception)
		{
			Logger.LogWarning("Unable to initialize Raw Input! This error can be caused by running Unity sandboxed.");
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2?.OnDestroy();
		}
		return false;
	}

	private bool kUfLPUPcszUpGAyuZJAqtpegtgUD(ConfigVars P_0, xAAARHJpGeNEmXXisDcrWtIrxcCb P_1)
	{
		bool platformVar_useNativeMouse = P_0.GetPlatformVar_useNativeMouse();
		bool platformVar_useNativeKeyboard = P_0.GetPlatformVar_useNativeKeyboard();
		if (!platformVar_useNativeMouse && !platformVar_useNativeKeyboard)
		{
			return false;
		}
		dKCtUwdeDBjLqfEjrVqDtrbboyLn dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = null;
		try
		{
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = new dKCtUwdeDBjLqfEjrVqDtrbboyLn(P_0, null, null, null, false, platformVar_useNativeMouse, platformVar_useNativeKeyboard, P_0.GetPlatformVar_useEnhancedDeviceSupport());
			P_1.JsuSTXPviYcNryTOjrkSPuoRfrde += dKCtUwdeDBjLqfEjrVqDtrbboyLn2.WTXAwfRdDfGaJDPeFGPonRoFqlRz;
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(5, dKCtUwdeDBjLqfEjrVqDtrbboyLn2);
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			return true;
		}
		catch
		{
			Logger.LogWarning("Unable to initialize Raw Input for native mouse handling! Unity mouse input will be used instead.");
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2?.OnDestroy();
			dKCtUwdeDBjLqfEjrVqDtrbboyLn2 = null;
			return false;
		}
	}

	private bool bWqfSvaWSUBmGPrGmjOolZchNIPo(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		UpdateLoopSetting updateLoop = P_0.updateLoop;
		bool flag = false;
		try
		{
			if (flag)
			{
				bfGILcARUcIsmCPSWSEFRGZsdksVA bfGILcARUcIsmCPSWSEFRGZsdksVA2 = new bfGILcARUcIsmCPSWSEFRGZsdksVA();
				bfGILcARUcIsmCPSWSEFRGZsdksVA2.GnXYnPLgqvryyyaWpZhBRJTKVMAW = 0;
				P_2 = new GPtQVYpGsbJZEFsgHCDbdnqvIWNV(flag, updateLoop, ZhYjQhBVtANcvzmhyrnlNqLhoXdg, bfGILcARUcIsmCPSWSEFRGZsdksVA2.dkqwTsSGOkGskadRZMOUInUjqIOob, wwzepISFYhAXyEzTuKMzuMhYyPCWA);
				mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(2, P_2);
			}
			else
			{
				P_2 = new GPtQVYpGsbJZEFsgHCDbdnqvIWNV(flag, updateLoop, ZhYjQhBVtANcvzmhyrnlNqLhoXdg, gQVfzQUdZyUEbllYFeSQBNQsojWAA, wwzepISFYhAXyEzTuKMzuMhYyPCWA);
				mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(2, P_2);
				P_2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
				P_2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
				P_2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			}
			return true;
		}
		catch
		{
			P_2 = null;
			if (P_1)
			{
				Logger.LogWarning("Unable to initialize XInput!");
			}
			else if (!flag)
			{
				P_0.useXInput = false;
				for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
				{
					if (mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i] != null && mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i] is AOnTCMyhWiFBDPnpOkhOOLpWAYMC { JcpvMwtROEesznlBjbRpiuPHRFQjA: not null } aOnTCMyhWiFBDPnpOkhOOLpWAYMC && aOnTCMyhWiFBDPnpOkhOOLpWAYMC.JcpvMwtROEesznlBjbRpiuPHRFQjA.eInOFfhsWuoUgeMhuykHHHAsMahJ == mYatOtUnQZvEUnhBaBEdFlEKDPkSA.XInput)
					{
						aOnTCMyhWiFBDPnpOkhOOLpWAYMC.JcpvMwtROEesznlBjbRpiuPHRFQjA = null;
					}
				}
				Logger.LogWarning("Unable to initialize XInput! XInput controllers will be handled by " + roopVxeIpuSfDHDwPqtdiyBZLlmR.ToString() + " instead. Vibration is not supported and the L/R triggers are treated as a single axis and input cannot be detected when both are pressed simultaneously. ");
			}
			return false;
		}
	}

	private bool iImuANvXEllnWswRfQusAbMdYfjw(ConfigVars P_0, bool P_1, out PlatformInputManager P_2)
	{
		_ = P_0.updateLoop;
		if (!(P_0.GetPlatformVar_useWindowsGamingInput() || P_1))
		{
			P_2 = null;
			return false;
		}
		try
		{
			P_2 = new SGleuUHllVEAaRUkeBzbBlEPvQyt(P_0, ZhYjQhBVtANcvzmhyrnlNqLhoXdg, gQVfzQUdZyUEbllYFeSQBNQsojWAA, wwzepISFYhAXyEzTuKMzuMhYyPCWA);
			if (P_1)
			{
				CCAsIoHWdgdCtawYdiEIYtyJrGNR = P_2;
			}
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Add(30, P_2);
			P_2.DeviceConnectedEvent += GTsYSzbbgGoeVOAWYdmwHdmsNitBb;
			P_2.DeviceDisconnectedEvent += UYyEobPvnMJaaAryDfRzDjPrQxSkA;
			P_2.UpdateControllerInfoEvent += foVOTnIDVddChDbAPQIxbFHZJpI;
			return true;
		}
		catch (Exception)
		{
			P_2 = null;
			if (!P_1)
			{
				P_0.SetPlatformVar_useWindowsGamingInput(value: false);
				for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
				{
					if (mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i] != null && mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i] is AOnTCMyhWiFBDPnpOkhOOLpWAYMC { JcpvMwtROEesznlBjbRpiuPHRFQjA: not null } aOnTCMyhWiFBDPnpOkhOOLpWAYMC && aOnTCMyhWiFBDPnpOkhOOLpWAYMC.JcpvMwtROEesznlBjbRpiuPHRFQjA.eInOFfhsWuoUgeMhuykHHHAsMahJ == mYatOtUnQZvEUnhBaBEdFlEKDPkSA.WindowsGamingInput)
					{
						aOnTCMyhWiFBDPnpOkhOOLpWAYMC.JcpvMwtROEesznlBjbRpiuPHRFQjA = null;
					}
				}
			}
			Logger.LogWarning("Unable to initialize Windows Gaming Input! ");
			return false;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		lfbzBvNbsLdVdxjrDRnfDxfJpWt = true;
		xKkyDumjNpTKqRBaVrUanizKxvHi = new syHlbqFqXwWfOJkmpRjCwOIxByRs();
		for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
		{
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].Initialize();
		}
	}

	public virtual void UKbxhIFcmFaxvQxSkUwPdcjaQtnd(UpdateLoopType P_0)
	{
		for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
		{
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].Update(P_0);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		for (int num = mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count - 1; num >= 0; num--)
		{
			mmMBbIahSzXrCLKQPDKAVXtYtCCvA[num].OnDestroy();
		}
		mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Clear();
		if (XheryrpOdbzPevIPLafkzQNhLSts != null)
		{
			XheryrpOdbzPevIPLafkzQNhLSts.yaicBpTCGUcpCeIqquduijbUPYhQA();
			XheryrpOdbzPevIPLafkzQNhLSts = null;
		}
		GGlKyqwtSRgaaWuZtxjwSYfoOckk.vzobnjikpbJGXwXzjSFjvdvtasMu();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return zGITOZYrvNvjCwgaFeWKBEHmCKzS;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int controllerId, ControllerDataUpdater data)
	{
		mmMBbIahSzXrCLKQPDKAVXtYtCCvA.GetValue((int)data.source).UpdateControllerData(xKkyDumjNpTKqRBaVrUanizKxvHi.ZwsHUZhWNPOpkDfdElcugLeTpiCj(controllerId, data.source, syHlbqFqXwWfOJkmpRjCwOIxByRs.tjvzbTwNQacMWkAcalSMLAZJitOz.Connected), data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
		{
			IUnifiedMouseSource unifiedMouseSource = mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].GetUnifiedMouseSource();
			if (unifiedMouseSource != null)
			{
				return unifiedMouseSource;
			}
		}
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
		{
			IUnifiedKeyboardSource unifiedKeyboardSource = mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].GetUnifiedKeyboardSource();
			if (unifiedKeyboardSource != null)
			{
				return unifiedKeyboardSource;
			}
		}
		return null;
	}

	private void GTsYSzbbgGoeVOAWYdmwHdmsNitBb(BridgedController P_0)
	{
		if (P_0 != null)
		{
			xKkyDumjNpTKqRBaVrUanizKxvHi.fewHUhsmsrTqYNFsQKUkKMMRDoWl(P_0);
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0);
			}
		}
	}

	private void UYyEobPvnMJaaAryDfRzDjPrQxSkA(ControllerDisconnectedEventArgs P_0)
	{
		if (P_0 != null)
		{
			xKkyDumjNpTKqRBaVrUanizKxvHi.MaqHXezjoufRlawZmtOeHEkgPxzbA(P_0);
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(P_0);
			}
		}
	}

	private void LomUiNMewxYxAMHlFaxNKcNiSOYV(EventArgs P_0)
	{
		if (lfbzBvNbsLdVdxjrDRnfDxfJpWt)
		{
			for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
			{
				mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].SystemDeviceConnected();
			}
		}
	}

	private void hLGBWgeJbZOAtMzvvXUZzokWHVAT(EventArgs P_0)
	{
		if (lfbzBvNbsLdVdxjrDRnfDxfJpWt)
		{
			for (int i = 0; i < mmMBbIahSzXrCLKQPDKAVXtYtCCvA.Count; i++)
			{
				mmMBbIahSzXrCLKQPDKAVXtYtCCvA[i].SystemDeviceDisconnected();
			}
		}
	}

	private void foVOTnIDVddChDbAPQIxbFHZJpI(UpdateControllerInfoEventArgs P_0)
	{
		if (P_0 == null || P_0.sourceJoystick == null)
		{
			return;
		}
		xKkyDumjNpTKqRBaVrUanizKxvHi.qoeSkqeiBSwhUxcxbBgEbmRczfLX(P_0.sourceJoystick.rewiredId, P_0.sourceJoystick.inputManagerId);
		syHlbqFqXwWfOJkmpRjCwOIxByRs.tjvzbTwNQacMWkAcalSMLAZJitOz tjvzbTwNQacMWkAcalSMLAZJitOz = syHlbqFqXwWfOJkmpRjCwOIxByRs.tjvzbTwNQacMWkAcalSMLAZJitOz.Connected;
		int num = xKkyDumjNpTKqRBaVrUanizKxvHi.DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0.sourceJoystick.rewiredId, tjvzbTwNQacMWkAcalSMLAZJitOz);
		if (num < 0)
		{
			tjvzbTwNQacMWkAcalSMLAZJitOz = syHlbqFqXwWfOJkmpRjCwOIxByRs.tjvzbTwNQacMWkAcalSMLAZJitOz.Disconnected;
			num = xKkyDumjNpTKqRBaVrUanizKxvHi.DtcjpZIOjtazPgaBJFWqixLPLZtrA(P_0.sourceJoystick.rewiredId, tjvzbTwNQacMWkAcalSMLAZJitOz);
		}
		if (num >= 0)
		{
			syHlbqFqXwWfOJkmpRjCwOIxByRs.uXeSQiviPFRgQxCaFcrhAMzwJGDfA uXeSQiviPFRgQxCaFcrhAMzwJGDfA = xKkyDumjNpTKqRBaVrUanizKxvHi.KqvKfYCpLFvjbFAXAlFqUQnMuMWk(num, tjvzbTwNQacMWkAcalSMLAZJitOz);
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(new lCmGFmqJxcJwSLPnMMWuSespLHRH(P_0.sourceJoystick, uXeSQiviPFRgQxCaFcrhAMzwJGDfA.VMInDAErVtemvwOVJdkgFdxmPkHcb)));
			}
		}
	}
}
