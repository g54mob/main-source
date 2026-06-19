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

internal class mFhbDHUVMhTRsTSifoqtETGQFLi : PlatformInputManager
{
	private class FuThHjtdSobqdDGGClJiotTkzYXh : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private bool oiXDjnvMKuinPdIMerLpprtOcXoH;

		private int NajCXKtukqHbFEALjLVyGCYCNtSb;

		private readonly int BiNUunjLprpLsrcUsjAgQBoZPAN;

		public Guid VUgBODHNCJPXSoOhhBOWRFfzFbGD;

		public string RxaFaRXqeYZbErOsosnUgQSpQhN;

		public Guid ypBhwPylZXgbWvdXwgdHvTJZNDf;

		public Rewired.Libraries.SharpDX.XInput.DeviceType SGxwBqmyXozkDpBkgeHLAPrQLEP;

		public XInputDeviceSubType iokwoVwoTYAzFmMXTwAwRvHWPyX;

		public bool wAZMpcjYCVAzjJccPAzohypyqPYD;

		public bool tjZOcFLxxligFZKdmeRGKeFDyTH;

		public bool iReJbzaWagFZkslpoheYjMGcYRs;

		public bool KXWdnFNvBxagMplhHMEKtfPiRjd;

		private int BQeNhaBkakeIrANMzRWkkBCYbli;

		private int OdToNpXnFfXunMuyNoIOgmgyZdD;

		private int tsubhXPAkivKUjJndgFvgCYtCih;

		private int uELhfbdZYGHumCLLdtArLMIvIGxA;

		private readonly float[] PdhmHHQzLgjPZAoxHUYVuyeAAEh;

		private readonly bool[] tBDNhubiBrrcAkNhlDXEHdQeLZEA;

		private HardwareJoystickMap_InputManager VwkQKXgoNahhCiMQWLUMFSQOAvBb;

		public readonly UtcHKTqHdmEeiosPnCXKUYyTuZh igbQmSqThzEBDsBKZScaimlglKi;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

		private Action bpQIQlfZPLXpAPzSZBiXzetABTX;

		private bool pNlLfCQUZtLDaiAkmVVUCWpVTeW;

		private bool FZwJHUUPwuLUimELESGrJJjnaNW;

		private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

		public string instanceName
		{
			get
			{
				string text = productName;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + BiNUunjLprpLsrcUsjAgQBoZPAN;
			}
		}

		public string productName
		{
			get
			{
				if (!isConnected)
				{
					return string.Empty;
				}
				return iokwoVwoTYAzFmMXTwAwRvHWPyX.ToString();
			}
		}

		public bool isConnected
		{
			get
			{
				if (igbQmSqThzEBDsBKZScaimlglKi == null || !KXWdnFNvBxagMplhHMEKtfPiRjd)
				{
					return false;
				}
				if (pNlLfCQUZtLDaiAkmVVUCWpVTeW && !ScfprDbDoNpUNgAYeiwhFwjYzyv(EnOvHNnFLIukKSkiGofdEyVTBYu.DusqhzmXUyMegHfyjcHSiVtflVfj))
				{
					oAcrAWZkkajOgYNxYlpoXGBmbsw();
				}
				return pNlLfCQUZtLDaiAkmVVUCWpVTeW;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return NajCXKtukqHbFEALjLVyGCYCNtSb;
			}
			set
			{
				NajCXKtukqHbFEALjLVyGCYCNtSb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId => BiNUunjLprpLsrcUsjAgQBoZPAN;

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (oiXDjnvMKuinPdIMerLpprtOcXoH)
				{
					return iokwoVwoTYAzFmMXTwAwRvHWPyX.ToString() + " " + (BiNUunjLprpLsrcUsjAgQBoZPAN + 1);
				}
				return "XInput " + iokwoVwoTYAzFmMXTwAwRvHWPyX.ToString() + " " + (BiNUunjLprpLsrcUsjAgQBoZPAN + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId => BiNUunjLprpLsrcUsjAgQBoZPAN;

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => ypBhwPylZXgbWvdXwgdHvTJZNDf;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			igbQmSqThzEBDsBKZScaimlglKi.gNCEcnFrONoNmBIzemElKBkKsgLf(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			igbQmSqThzEBDsBKZScaimlglKi.dhgOzOSsRJokFdSEeCfAkvOGqjV();
		}

		public FuThHjtdSobqdDGGClJiotTkzYXh(int systemId, bool isWin8AppStore, UtcHKTqHdmEeiosPnCXKUYyTuZh sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Action deviceDisconnectedDelegate)
		{
			igbQmSqThzEBDsBKZScaimlglKi = sourceJoystick;
			oiXDjnvMKuinPdIMerLpprtOcXoH = isWin8AppStore;
			BiNUunjLprpLsrcUsjAgQBoZPAN = systemId;
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			bpQIQlfZPLXpAPzSZBiXzetABTX = deviceDisconnectedDelegate;
			NajCXKtukqHbFEALjLVyGCYCNtSb = -1;
			BQeNhaBkakeIrANMzRWkkBCYbli = 6;
			OdToNpXnFfXunMuyNoIOgmgyZdD = 15;
			tsubhXPAkivKUjJndgFvgCYtCih = BQeNhaBkakeIrANMzRWkkBCYbli;
			uELhfbdZYGHumCLLdtArLMIvIGxA = OdToNpXnFfXunMuyNoIOgmgyZdD;
			PdhmHHQzLgjPZAoxHUYVuyeAAEh = new float[BQeNhaBkakeIrANMzRWkkBCYbli];
			tBDNhubiBrrcAkNhlDXEHdQeLZEA = new bool[OdToNpXnFfXunMuyNoIOgmgyZdD];
			BFvKkxFvqMhQoGUuUjHmPRhFkAG();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			igbQmSqThzEBDsBKZScaimlglKi.SGjNzeeFRMimPyTnCrUvIiCnKKq();
			bool[] currentButtonValues = igbQmSqThzEBDsBKZScaimlglKi.CurrentButtonValues;
			IhdIeUwZwRLqiJyYdCtNVPXciIb(currentButtonValues, ref igbQmSqThzEBDsBKZScaimlglKi.nfAwLuanVTBtOtOqauzMcWyGivL);
			xHNCeTbZYBVqRMCQRrncKAxpnCcM(currentButtonValues, ref igbQmSqThzEBDsBKZScaimlglKi.nfAwLuanVTBtOtOqauzMcWyGivL);
			igbQmSqThzEBDsBKZScaimlglKi.gXADYrdzIttymTRoaKqLkIyUtDJ();
		}

		public void VsfvDyXqZIMuiFHDXHZBjZyCAyO(bool P_0)
		{
			if (igbQmSqThzEBDsBKZScaimlglKi != null)
			{
				iReJbzaWagFZkslpoheYjMGcYRs = P_0;
			}
		}

		public bool ScfprDbDoNpUNgAYeiwhFwjYzyv(EnOvHNnFLIukKSkiGofdEyVTBYu P_0)
		{
			MeRhZtdgQairGkQRtCpJAhBsCnCH(BNifSUTCIqMhvjPQUVmWdXhdtUY(P_0));
			return pNlLfCQUZtLDaiAkmVVUCWpVTeW;
		}

		public bool BNifSUTCIqMhvjPQUVmWdXhdtUY(EnOvHNnFLIukKSkiGofdEyVTBYu P_0)
		{
			if (igbQmSqThzEBDsBKZScaimlglKi == null)
			{
				return false;
			}
			return igbQmSqThzEBDsBKZScaimlglKi.BNifSUTCIqMhvjPQUVmWdXhdtUY(P_0);
		}

		public void MeRhZtdgQairGkQRtCpJAhBsCnCH(bool P_0)
		{
			pNlLfCQUZtLDaiAkmVVUCWpVTeW = P_0;
		}

		public void adDtxuxlZDkRlAXSCGwMGOPQSm()
		{
			if (!KXWdnFNvBxagMplhHMEKtfPiRjd || zkIKfkIdwlGFwUwURAiDftVTEVU())
			{
				BFvKkxFvqMhQoGUuUjHmPRhFkAG();
			}
			if (KXWdnFNvBxagMplhHMEKtfPiRjd && pNlLfCQUZtLDaiAkmVVUCWpVTeW)
			{
				igbQmSqThzEBDsBKZScaimlglKi.SLLPWXkdwSWuCebTNNLdcVukhel();
			}
		}

		public void LcOcEkimVsXyMDEsJAYfzejUtyjG()
		{
			NajCXKtukqHbFEALjLVyGCYCNtSb = -1;
			KXWdnFNvBxagMplhHMEKtfPiRjd = false;
			igbQmSqThzEBDsBKZScaimlglKi.pxIDOEabnUcUluxaEwWKgTcoDWJc();
			Array.Clear(PdhmHHQzLgjPZAoxHUYVuyeAAEh, 0, PdhmHHQzLgjPZAoxHUYVuyeAAEh.Length);
			Array.Clear(tBDNhubiBrrcAkNhlDXEHdQeLZEA, 0, tBDNhubiBrrcAkNhlDXEHdQeLZEA.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (BQeNhaBkakeIrANMzRWkkBCYbli != dataUpdater.axisCount || OdToNpXnFfXunMuyNoIOgmgyZdD != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < BQeNhaBkakeIrANMzRWkkBCYbli; i++)
			{
				dataUpdater.axisValues[i] = PdhmHHQzLgjPZAoxHUYVuyeAAEh[i];
			}
			for (int j = 0; j < OdToNpXnFfXunMuyNoIOgmgyZdD; j++)
			{
				dataUpdater.buttonValues[j] = tBDNhubiBrrcAkNhlDXEHdQeLZEA[j];
			}
			if (FZwJHUUPwuLUimELESGrJJjnaNW && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public BridgedControllerHWInfo FdleSbAIfzeupXihLnJRPTOJTSuk()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			eVVvseUpGSgpqZdXlHEbWYuzpch(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			eVVvseUpGSgpqZdXlHEbWYuzpch(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(NajCXKtukqHbFEALjLVyGCYCNtSb);
		}

		private void BFvKkxFvqMhQoGUuUjHmPRhFkAG()
		{
			if (igbQmSqThzEBDsBKZScaimlglKi == null || !ScfprDbDoNpUNgAYeiwhFwjYzyv(EnOvHNnFLIukKSkiGofdEyVTBYu.tvUdvKgVeyZLZVRGSZUJrIXWmuy))
			{
				return;
			}
			try
			{
				FMYfIZxnopsyYalHzrOyrtOSwUA();
				PrxqYxfCfoaUOqjCnEgiyLSbAjag prxqYxfCfoaUOqjCnEgiyLSbAjag = igbQmSqThzEBDsBKZScaimlglKi.qwkQMEPTvTCxXBJPsoEOSCvOdNjj.IpETACFzPqdVemPrFicATKQRpIR(gwSgCcGfNQxKhKgnLQsxicMPPRg.sdyRaIQoaKHZNkCvPvOoJJCMpUn);
				SGxwBqmyXozkDpBkgeHLAPrQLEP = prxqYxfCfoaUOqjCnEgiyLSbAjag.HSgsKXENkcvZsdtDvNAJblnfTHZ;
				iokwoVwoTYAzFmMXTwAwRvHWPyX = (XInputDeviceSubType)prxqYxfCfoaUOqjCnEgiyLSbAjag.FuTAWEXAlnIWGWoNOuNkqZtsuGX;
				if (igbQmSqThzEBDsBKZScaimlglKi.qwkQMEPTvTCxXBJPsoEOSCvOdNjj.gNCEcnFrONoNmBIzemElKBkKsgLf(default(DFsJAhmwnmSRJJkYRXwEfgOEkaa)).Success)
				{
					wAZMpcjYCVAzjJccPAzohypyqPYD = true;
				}
				tjZOcFLxxligFZKdmeRGKeFDyTH = (prxqYxfCfoaUOqjCnEgiyLSbAjag.tUBXRZljfAUzITeLSNnlnxnnsCR & rbqWUSuKqqOFHsDBXCABfjNcjzn.VonHGFsDsmcbVkblWuwkeprKwDG) == rbqWUSuKqqOFHsDBXCABfjNcjzn.VonHGFsDsmcbVkblWuwkeprKwDG;
				TGqlSqzKzTCPYwisxjGzscmapHG();
				VUgBODHNCJPXSoOhhBOWRFfzFbGD = VwkQKXgoNahhCiMQWLUMFSQOAvBb.hardwareMapIdentifier.guid;
				RxaFaRXqeYZbErOsosnUgQSpQhN = VwkQKXgoNahhCiMQWLUMFSQOAvBb.controllerName;
				igbQmSqThzEBDsBKZScaimlglKi.SLLPWXkdwSWuCebTNNLdcVukhel();
				ypBhwPylZXgbWvdXwgdHvTJZNDf = MiscTools.CreateGuidHashSHA1(string.Concat(SGxwBqmyXozkDpBkgeHLAPrQLEP, iokwoVwoTYAzFmMXTwAwRvHWPyX, BiNUunjLprpLsrcUsjAgQBoZPAN));
				KXWdnFNvBxagMplhHMEKtfPiRjd = true;
			}
			catch (Exception)
			{
				KXWdnFNvBxagMplhHMEKtfPiRjd = false;
				pNlLfCQUZtLDaiAkmVVUCWpVTeW = false;
				ypBhwPylZXgbWvdXwgdHvTJZNDf = Guid.Empty;
			}
		}

		private bool zkIKfkIdwlGFwUwURAiDftVTEVU()
		{
			try
			{
				if (iokwoVwoTYAzFmMXTwAwRvHWPyX != (XInputDeviceSubType)igbQmSqThzEBDsBKZScaimlglKi.qwkQMEPTvTCxXBJPsoEOSCvOdNjj.IpETACFzPqdVemPrFicATKQRpIR(gwSgCcGfNQxKhKgnLQsxicMPPRg.sdyRaIQoaKHZNkCvPvOoJJCMpUn).FuTAWEXAlnIWGWoNOuNkqZtsuGX)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void FMYfIZxnopsyYalHzrOyrtOSwUA()
		{
			tjZOcFLxxligFZKdmeRGKeFDyTH = false;
			wAZMpcjYCVAzjJccPAzohypyqPYD = false;
			iReJbzaWagFZkslpoheYjMGcYRs = false;
			KXWdnFNvBxagMplhHMEKtfPiRjd = false;
		}

		private void oAcrAWZkkajOgYNxYlpoXGBmbsw()
		{
			if (bpQIQlfZPLXpAPzSZBiXzetABTX != null)
			{
				bpQIQlfZPLXpAPzSZBiXzetABTX();
			}
			igbQmSqThzEBDsBKZScaimlglKi.pxIDOEabnUcUluxaEwWKgTcoDWJc();
		}

		private void IhdIeUwZwRLqiJyYdCtNVPXciIb(bool[] P_0, ref oLruUfshGlRHHhqtEntQMNrhdqi P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= BQeNhaBkakeIrANMzRWkkBCYbli)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				PdhmHHQzLgjPZAoxHUYVuyeAAEh[i] = CCwCnYhEmaFZrOQeiMBHgUHikwcc(axes_orig[i], P_0, ref P_1);
				if (!FZwJHUUPwuLUimELESGrJJjnaNW && PdhmHHQzLgjPZAoxHUYVuyeAAEh[i] != 0f)
				{
					FZwJHUUPwuLUimELESGrJJjnaNW = true;
				}
			}
		}

		private void xHNCeTbZYBVqRMCQRrncKAxpnCcM(bool[] P_0, ref oLruUfshGlRHHhqtEntQMNrhdqi P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)VwkQKXgoNahhCiMQWLUMFSQOAvBb.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= OdToNpXnFfXunMuyNoIOgmgyZdD)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				tBDNhubiBrrcAkNhlDXEHdQeLZEA[i] = golTpfekpJZdxAtdMfSTzBKxebB(buttons_orig[i], P_0, ref P_1);
				if (!FZwJHUUPwuLUimELESGrJJjnaNW && tBDNhubiBrrcAkNhlDXEHdQeLZEA[i])
				{
					FZwJHUUPwuLUimELESGrJJjnaNW = true;
				}
			}
		}

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref oLruUfshGlRHHhqtEntQMNrhdqi P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!golTpfekpJZdxAtdMfSTzBKxebB(P_0.sourceButton, P_1))
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

		private float CCwCnYhEmaFZrOQeiMBHgUHikwcc(XInputAxis P_0, ref oLruUfshGlRHHhqtEntQMNrhdqi P_1)
		{
			return P_0 switch
			{
				XInputAxis.LeftThumbX => UtcHKTqHdmEeiosPnCXKUYyTuZh.jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_1.erOakDdpZKuYNhudwVwMDQAoKaD), 
				XInputAxis.LeftThumbY => UtcHKTqHdmEeiosPnCXKUYyTuZh.jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_1.QogskKrMYxfEwJKUNbWpHGeESPN), 
				XInputAxis.RightThumbX => UtcHKTqHdmEeiosPnCXKUYyTuZh.jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_1.GQmfIrDLBbfWkWgLLgkmFXMACcAU), 
				XInputAxis.RightThumbY => UtcHKTqHdmEeiosPnCXKUYyTuZh.jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_1.oEVqLVZrvQMqEXfySOnTYjBGFdv), 
				XInputAxis.LeftTrigger => UtcHKTqHdmEeiosPnCXKUYyTuZh.saQUSGMfFbhDQAayUBqJOMOFmgOq(P_1.EJOjTuHEVLpDVnsYKkfPSWWjqyU), 
				XInputAxis.RightTrigger => UtcHKTqHdmEeiosPnCXKUYyTuZh.saQUSGMfFbhDQAayUBqJOMOFmgOq(P_1.whGgacCMUNGIFyKnzpmhcwDsFih), 
				_ => 0f, 
			};
		}

		private bool golTpfekpJZdxAtdMfSTzBKxebB(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref oLruUfshGlRHHhqtEntQMNrhdqi P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return golTpfekpJZdxAtdMfSTzBKxebB(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = CCwCnYhEmaFZrOQeiMBHgUHikwcc(P_0.sourceAxis, ref P_2);
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

		private bool golTpfekpJZdxAtdMfSTzBKxebB(XInputButton P_0, bool[] P_1)
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

		private void TGqlSqzKzTCPYwisxjGzscmapHG()
		{
			VwkQKXgoNahhCiMQWLUMFSQOAvBb = bKHIVnLAXWYbMiOIyqMJrMzriBW(FdleSbAIfzeupXihLnJRPTOJTSuk());
			if (VwkQKXgoNahhCiMQWLUMFSQOAvBb == null)
			{
				Rewired.Logger.LogError("Default hardware map not found!");
				return;
			}
			BQeNhaBkakeIrANMzRWkkBCYbli = VwkQKXgoNahhCiMQWLUMFSQOAvBb.axisCount;
			OdToNpXnFfXunMuyNoIOgmgyZdD = VwkQKXgoNahhCiMQWLUMFSQOAvBb.buttonCount;
		}

		private bool TrLwwHeBAnVmekDUsoVHLXOgwlR(ref DFsJAhmwnmSRJJkYRXwEfgOEkaa P_0)
		{
			if (P_0.VaklogroOfOvtGAslCQxALOhTbr > 0 || P_0.QBwOuuquRIFZvegLSQNjsRFFqRG > 0)
			{
				return true;
			}
			return false;
		}

		private void esttPXclThFXnZJyAMyGmIkVTbH(ref DFsJAhmwnmSRJJkYRXwEfgOEkaa P_0)
		{
			P_0.VaklogroOfOvtGAslCQxALOhTbr = 0;
			P_0.QBwOuuquRIFZvegLSQNjsRFFqRG = 0;
		}

		private void qEQGYSKDuLmkwvxCkCegIlxntOZ(ref DFsJAhmwnmSRJJkYRXwEfgOEkaa P_0, ref DFsJAhmwnmSRJJkYRXwEfgOEkaa P_1)
		{
			P_1.VaklogroOfOvtGAslCQxALOhTbr = P_0.VaklogroOfOvtGAslCQxALOhTbr;
			P_1.QBwOuuquRIFZvegLSQNjsRFFqRG = P_0.QBwOuuquRIFZvegLSQNjsRFFqRG;
		}

		private string REhszzMgvCPPesBPhjVnWjgLmgV()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{SGxwBqmyXozkDpBkgeHLAPrQLEP.ToString()}{iokwoVwoTYAzFmMXTwAwRvHWPyX.ToString()}");
		}

		private void eVVvseUpGSgpqZdXlHEbWYuzpch(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = ControlDeviceType.eDgdySKclHgXmmILffzdHPvUtEi;
			P_0.hardwareIdentifier = REhszzMgvCPPesBPhjVnWjgLmgV();
			P_0.hardwareAxisCount = tsubhXPAkivKUjJndgFvgCYtCih;
			P_0.hardwareButtonCount = uELhfbdZYGHumCLLdtArLMIvIGxA;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = productName;
			P_0.hw_supportsVoice = tjZOcFLxxligFZKdmeRGKeFDyTH;
			P_0.hw_supportsVibration = wAZMpcjYCVAzjJccPAzohypyqPYD;
			P_0.hw_localVibrationMotorCount = (wAZMpcjYCVAzjJccPAzohypyqPYD ? 2 : 0);
			P_0.hw_xInputSubType = iokwoVwoTYAzFmMXTwAwRvHWPyX;
		}

		private void eVVvseUpGSgpqZdXlHEbWYuzpch(BridgedController P_0)
		{
			eVVvseUpGSgpqZdXlHEbWYuzpch((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = VwkQKXgoNahhCiMQWLUMFSQOAvBb.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + instanceName;
			P_0.productName = "XInput " + productName;
			P_0.isXInputDevice = true;
			P_0.axisCount = BQeNhaBkakeIrANMzRWkkBCYbli;
			P_0.buttonCount = OdToNpXnFfXunMuyNoIOgmgyZdD;
			P_0.controllerTypeGuid = VUgBODHNCJPXSoOhhBOWRFfzFbGD;
			P_0.controllerExtension = extension;
		}

		public void Dispose()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(true);
			GC.SuppressFinalize(this);
		}

		~FuThHjtdSobqdDGGClJiotTkzYXh()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(false);
		}

		protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
		{
			if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				return;
			}
			if (P_0)
			{
				if (isConnected)
				{
					igbQmSqThzEBDsBKZScaimlglKi.WBeCpUMWzEHQSxcnAdxwPOfXyGk();
				}
				if (igbQmSqThzEBDsBKZScaimlglKi != null)
				{
					igbQmSqThzEBDsBKZScaimlglKi.Dispose();
				}
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}

	private class MyOYzuUGOiBGxhtyptZcclOeOQr
	{
		private class bklOhMEdQEogCYnHMrPhffdValq
		{
			public bool rjwaceBPkKbfsQsvDkFDwyxYFtN;

			public int IarEMbMqzCAYwlSQGSgLyHgrWQw;

			public XInputDeviceSubType iokwoVwoTYAzFmMXTwAwRvHWPyX;

			public void CWncwVbJhTWISMonvIVEimpDcKXc(FuThHjtdSobqdDGGClJiotTkzYXh P_0, bool P_1)
			{
				rjwaceBPkKbfsQsvDkFDwyxYFtN = P_1;
				IarEMbMqzCAYwlSQGSgLyHgrWQw = P_0.rewiredId;
				iokwoVwoTYAzFmMXTwAwRvHWPyX = P_0.iokwoVwoTYAzFmMXTwAwRvHWPyX;
			}

			public bklOhMEdQEogCYnHMrPhffdValq(int rewiredId, XInputDeviceSubType deviceSubType)
			{
				IarEMbMqzCAYwlSQGSgLyHgrWQw = rewiredId;
				iokwoVwoTYAzFmMXTwAwRvHWPyX = deviceSubType;
			}
		}

		private List<bklOhMEdQEogCYnHMrPhffdValq> rHeRGdaxkUgtZdjiIBVhiIXdbi;

		public MyOYzuUGOiBGxhtyptZcclOeOQr()
		{
			rHeRGdaxkUgtZdjiIBVhiIXdbi = new List<bklOhMEdQEogCYnHMrPhffdValq>();
		}

		public void zwsiPSlOApWCVvjLZKAmMZzYJvH(FuThHjtdSobqdDGGClJiotTkzYXh P_0, bool P_1)
		{
			int num = ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0.rewiredId, P_0.iokwoVwoTYAzFmMXTwAwRvHWPyX, true);
			if (num < 0)
			{
				bklOhMEdQEogCYnHMrPhffdValq bklOhMEdQEogCYnHMrPhffdValq2 = new bklOhMEdQEogCYnHMrPhffdValq(P_0.rewiredId, P_0.iokwoVwoTYAzFmMXTwAwRvHWPyX);
				bklOhMEdQEogCYnHMrPhffdValq2.rjwaceBPkKbfsQsvDkFDwyxYFtN = P_1;
				rHeRGdaxkUgtZdjiIBVhiIXdbi.Add(bklOhMEdQEogCYnHMrPhffdValq2);
			}
		}

		public void CWncwVbJhTWISMonvIVEimpDcKXc(int P_0, FuThHjtdSobqdDGGClJiotTkzYXh P_1, bool P_2)
		{
			if (P_0 >= 0 && P_0 < rHeRGdaxkUgtZdjiIBVhiIXdbi.Count)
			{
				rHeRGdaxkUgtZdjiIBVhiIXdbi[P_0].CWncwVbJhTWISMonvIVEimpDcKXc(P_1, P_2);
			}
		}

		public int vhgNHjvpyPowZUuOihxNWulkANl(XInputDeviceSubType P_0, bool P_1)
		{
			int count = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_1 || !rHeRGdaxkUgtZdjiIBVhiIXdbi[i].rjwaceBPkKbfsQsvDkFDwyxYFtN) && rHeRGdaxkUgtZdjiIBVhiIXdbi[i].iokwoVwoTYAzFmMXTwAwRvHWPyX == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		public int ExRxpDlEMwqDfegjLZuvCQEtdBt(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = rHeRGdaxkUgtZdjiIBVhiIXdbi.Count;
			for (int i = 0; i < count; i++)
			{
				if ((P_2 || !rHeRGdaxkUgtZdjiIBVhiIXdbi[i].rjwaceBPkKbfsQsvDkFDwyxYFtN) && rHeRGdaxkUgtZdjiIBVhiIXdbi[i].IarEMbMqzCAYwlSQGSgLyHgrWQw == P_0 && rHeRGdaxkUgtZdjiIBVhiIXdbi[i].iokwoVwoTYAzFmMXTwAwRvHWPyX == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		public int QdfbpZaCmLimyXNpjtSKtbRyVDj(int P_0)
		{
			if (P_0 < 0 || P_0 >= rHeRGdaxkUgtZdjiIBVhiIXdbi.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return rHeRGdaxkUgtZdjiIBVhiIXdbi[P_0].IarEMbMqzCAYwlSQGSgLyHgrWQw;
		}

		public void zHlSADEtrBrvetqSSnpDIQEupMP(int P_0, bool P_1)
		{
			if (P_0 >= 0 && P_0 < rHeRGdaxkUgtZdjiIBVhiIXdbi.Count)
			{
				rHeRGdaxkUgtZdjiIBVhiIXdbi[P_0].rjwaceBPkKbfsQsvDkFDwyxYFtN = P_1;
			}
		}
	}

	private class XUxYttEtJowxIDybUHZPFhKlMLt
	{
		public bool ErYqLxFSgjkCxMeoDrdsaewJXfO;

		private double IuPpLPucyzFtbsEXMBZQHPXRmAD;

		public float qTZPksemrAcMfHZNTkflHZVBZec;

		public XUxYttEtJowxIDybUHZPFhKlMLt()
		{
		}

		public XUxYttEtJowxIDybUHZPFhKlMLt(float inLength)
		{
			qTZPksemrAcMfHZNTkflHZVBZec = inLength;
		}

		public void ZWHXmzFoPzsdydQwCbiSIgZvLxH()
		{
			ErYqLxFSgjkCxMeoDrdsaewJXfO = true;
			IuPpLPucyzFtbsEXMBZQHPXRmAD = (double)qTZPksemrAcMfHZNTkflHZVBZec + ReInput.unscaledTime;
		}

		public void ZWHXmzFoPzsdydQwCbiSIgZvLxH(float P_0)
		{
			ErYqLxFSgjkCxMeoDrdsaewJXfO = true;
			qTZPksemrAcMfHZNTkflHZVBZec = P_0;
			IuPpLPucyzFtbsEXMBZQHPXRmAD = (double)qTZPksemrAcMfHZNTkflHZVBZec + ReInput.unscaledTime;
		}

		public bool CWncwVbJhTWISMonvIVEimpDcKXc()
		{
			if (!ErYqLxFSgjkCxMeoDrdsaewJXfO)
			{
				return false;
			}
			if (ReInput.unscaledTime >= IuPpLPucyzFtbsEXMBZQHPXRmAD)
			{
				ErYqLxFSgjkCxMeoDrdsaewJXfO = false;
				return true;
			}
			return false;
		}

		public void rKJfCRBWFLQsKCjGykmcumzKLPwE()
		{
			ErYqLxFSgjkCxMeoDrdsaewJXfO = false;
			IuPpLPucyzFtbsEXMBZQHPXRmAD = 0.0;
		}

		public void EanEWtEGOBeMXqhkZYghGzuRuTen(float P_0)
		{
			qTZPksemrAcMfHZNTkflHZVBZec = P_0;
		}

		public XUxYttEtJowxIDybUHZPFhKlMLt WxGcwXzTkSQmhHlSxIqUvcVNPos()
		{
			return (XUxYttEtJowxIDybUHZPFhKlMLt)MemberwiseClone();
		}
	}

	public class UtcHKTqHdmEeiosPnCXKUYyTuZh : IDisposable
	{
		public readonly knlslTnqsPKELXkpCvqaYPLNMCJ qwkQMEPTvTCxXBJPsoEOSCvOdNjj;

		public oLruUfshGlRHHhqtEntQMNrhdqi nfAwLuanVTBtOtOqauzMcWyGivL;

		private bool pNlLfCQUZtLDaiAkmVVUCWpVTeW;

		private readonly ButtonLoopSet xMOAMIpUblwzclpASeqOvbiquVB;

		private oLruUfshGlRHHhqtEntQMNrhdqi RuCNdtNEnNxlwdLWIMpKeIzgxIB;

		private bool RBBImOPySyeAChTSNUJxWdUyWjq;

		private DualThreadLowLevelInputEventQueue vdRdcSJAmhdxgFuDQMtgOvYJsTt;

		private readonly object WfTbITFnDgahnloEWtIracmCfqy;

		private RingBuffer<DFsJAhmwnmSRJJkYRXwEfgOEkaa> USlUYKecMYOljBIWJKBONOpMiTOi = new RingBuffer<DFsJAhmwnmSRJJkYRXwEfgOEkaa>(5);

		private RingBuffer<DFsJAhmwnmSRJJkYRXwEfgOEkaa> OSeTMgHjvWVgwLNecmGKXTQDIcY = new RingBuffer<DFsJAhmwnmSRJJkYRXwEfgOEkaa>(5);

		private readonly object gWunOGUWVZwWdjQPvFeMOePELPf = new object();

		private readonly object vUZoqrPIlWUtmgeKuZciMDpVULW = new object();

		private DFsJAhmwnmSRJJkYRXwEfgOEkaa LqOotHlCHCazujmfpSxFcWPPhgZ;

		private double tLqyseVODwdZJamOGEMomvcYPoMH;

		private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

		public bool[] CurrentButtonValues => xMOAMIpUblwzclpASeqOvbiquVB.Current.effectiveValue;

		public UtcHKTqHdmEeiosPnCXKUYyTuZh(int controllerIndex, UpdateLoopSetting updateLoops)
		{
			qwkQMEPTvTCxXBJPsoEOSCvOdNjj = new knlslTnqsPKELXkpCvqaYPLNMCJ((EGzwNtIgDfmlyBDPvBQafJyHhAGz)controllerIndex);
			xMOAMIpUblwzclpASeqOvbiquVB = new ButtonLoopSet(updateLoops, 15);
			WfTbITFnDgahnloEWtIracmCfqy = new object();
			vdRdcSJAmhdxgFuDQMtgOvYJsTt = new DualThreadLowLevelInputEventQueue((int)((float)tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickRefreshRate * 0.25f), 15, 6, 0);
		}

		public void SGjNzeeFRMimPyTnCrUvIiCnKKq()
		{
			xMOAMIpUblwzclpASeqOvbiquVB.SetUpdateLoop(ReInput.currentUpdateLoop);
			IdpEagzVegTtJCmCdHYdKBRUDeaE(ref nfAwLuanVTBtOtOqauzMcWyGivL);
		}

		public void gXADYrdzIttymTRoaKqLkIyUtDJ()
		{
			dxCfVCXiNQqVXwjDKjESBDWKUAnA();
			xMOAMIpUblwzclpASeqOvbiquVB.Current.ClearWasTrueThisFrame();
		}

		public void SLLPWXkdwSWuCebTNNLdcVukhel()
		{
			IgqBTMgoLLDsubFJdJZiejmTNfb();
			pNlLfCQUZtLDaiAkmVVUCWpVTeW = true;
			RBBImOPySyeAChTSNUJxWdUyWjq = qwkQMEPTvTCxXBJPsoEOSCvOdNjj.IsConnected;
		}

		public void pxIDOEabnUcUluxaEwWKgTcoDWJc()
		{
			pNlLfCQUZtLDaiAkmVVUCWpVTeW = false;
			RBBImOPySyeAChTSNUJxWdUyWjq = false;
			IgqBTMgoLLDsubFJdJZiejmTNfb();
		}

		public bool BNifSUTCIqMhvjPQUVmWdXhdtUY(EnOvHNnFLIukKSkiGofdEyVTBYu P_0)
		{
			return P_0 switch
			{
				EnOvHNnFLIukKSkiGofdEyVTBYu.tvUdvKgVeyZLZVRGSZUJrIXWmuy => RBBImOPySyeAChTSNUJxWdUyWjq = qwkQMEPTvTCxXBJPsoEOSCvOdNjj.IsConnected, 
				EnOvHNnFLIukKSkiGofdEyVTBYu.DusqhzmXUyMegHfyjcHSiVtflVfj => RBBImOPySyeAChTSNUJxWdUyWjq, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void gNCEcnFrONoNmBIzemElKBkKsgLf(float P_0, int P_1)
		{
			switch (P_1)
			{
			case 0:
				LqOotHlCHCazujmfpSxFcWPPhgZ.VaklogroOfOvtGAslCQxALOhTbr = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			case 1:
				LqOotHlCHCazujmfpSxFcWPPhgZ.QBwOuuquRIFZvegLSQNjsRFFqRG = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				break;
			}
			ijxgEyOjFdVyFjyffCrkTtEfjqI();
		}

		public void dhgOzOSsRJokFdSEeCfAkvOGqjV()
		{
			LqOotHlCHCazujmfpSxFcWPPhgZ.VaklogroOfOvtGAslCQxALOhTbr = 0;
			LqOotHlCHCazujmfpSxFcWPPhgZ.QBwOuuquRIFZvegLSQNjsRFFqRG = 0;
			ijxgEyOjFdVyFjyffCrkTtEfjqI();
		}

		public void WBeCpUMWzEHQSxcnAdxwPOfXyGk()
		{
			LqOotHlCHCazujmfpSxFcWPPhgZ.VaklogroOfOvtGAslCQxALOhTbr = 0;
			LqOotHlCHCazujmfpSxFcWPPhgZ.QBwOuuquRIFZvegLSQNjsRFFqRG = 0;
			lock (vUZoqrPIlWUtmgeKuZciMDpVULW)
			{
				lock (gWunOGUWVZwWdjQPvFeMOePELPf)
				{
					USlUYKecMYOljBIWJKBONOpMiTOi.Clear();
					OSeTMgHjvWVgwLNecmGKXTQDIcY.Clear();
					THspmheuzJrGoBXVTvYDMjZcCZ(qwkQMEPTvTCxXBJPsoEOSCvOdNjj, LqOotHlCHCazujmfpSxFcWPPhgZ, ref tLqyseVODwdZJamOGEMomvcYPoMH);
				}
			}
		}

		public void TDHltpBGvPfIjoqJxelHndOCDue()
		{
			if (!pNlLfCQUZtLDaiAkmVVUCWpVTeW || !RBBImOPySyeAChTSNUJxWdUyWjq)
			{
				return;
			}
			ANInovfBkTqpKTBiXBwqFKXAGniM aNInovfBkTqpKTBiXBwqFKXAGniM;
			double realTime;
			try
			{
				if (!qwkQMEPTvTCxXBJPsoEOSCvOdNjj.oHWIwggXUQsQMAGigHbmDktspIV(out aNInovfBkTqpKTBiXBwqFKXAGniM))
				{
					RBBImOPySyeAChTSNUJxWdUyWjq = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				RBBImOPySyeAChTSNUJxWdUyWjq = false;
				return;
			}
			lock (WfTbITFnDgahnloEWtIracmCfqy)
			{
				if (!LsExmFHlwgGfxvdvcnKtycZNcPf(aNInovfBkTqpKTBiXBwqFKXAGniM.vFmwJbshzNEkREUTCqstpmqTaAKd, RuCNdtNEnNxlwdLWIMpKeIzgxIB))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = vdRdcSJAmhdxgFuDQMtgOvYJsTt.T_CreateEvent())
					{
						RyuboIiCNoHepiBOEwDkmemvLmNe(ref aNInovfBkTqpKTBiXBwqFKXAGniM.vFmwJbshzNEkREUTCqstpmqTaAKd, realTime, newEventWrapper.Event);
					}
					RuCNdtNEnNxlwdLWIMpKeIzgxIB = aNInovfBkTqpKTBiXBwqFKXAGniM.vFmwJbshzNEkREUTCqstpmqTaAKd;
				}
			}
		}

		public void wEijusbjaPkjMjXBcHBgJhcpHEZ()
		{
			if (!pNlLfCQUZtLDaiAkmVVUCWpVTeW || !RBBImOPySyeAChTSNUJxWdUyWjq || ReInput.realTime < tLqyseVODwdZJamOGEMomvcYPoMH + 0.009999999776482582)
			{
				return;
			}
			lock (vUZoqrPIlWUtmgeKuZciMDpVULW)
			{
				lock (gWunOGUWVZwWdjQPvFeMOePELPf)
				{
					MiscTools.Swap(ref USlUYKecMYOljBIWJKBONOpMiTOi, ref OSeTMgHjvWVgwLNecmGKXTQDIcY);
				}
				rLoenkfHSoxRiUwsHDrPkjfQLFu(OSeTMgHjvWVgwLNecmGKXTQDIcY, qwkQMEPTvTCxXBJPsoEOSCvOdNjj, ref tLqyseVODwdZJamOGEMomvcYPoMH);
			}
		}

		private void dxCfVCXiNQqVXwjDKjESBDWKUAnA()
		{
			CfqtDUUgkzforFaufOsvlLuLGzcd();
		}

		private void CfqtDUUgkzforFaufOsvlLuLGzcd()
		{
			if (!(ReInput.realTime < tLqyseVODwdZJamOGEMomvcYPoMH + 1.5) && (!Mathf.Approximately((int)LqOotHlCHCazujmfpSxFcWPPhgZ.VaklogroOfOvtGAslCQxALOhTbr, 0f) || !Mathf.Approximately((int)LqOotHlCHCazujmfpSxFcWPPhgZ.QBwOuuquRIFZvegLSQNjsRFFqRG, 0f)))
			{
				ijxgEyOjFdVyFjyffCrkTtEfjqI();
			}
		}

		private void ijxgEyOjFdVyFjyffCrkTtEfjqI()
		{
			lock (gWunOGUWVZwWdjQPvFeMOePELPf)
			{
				USlUYKecMYOljBIWJKBONOpMiTOi.Enqueue(LqOotHlCHCazujmfpSxFcWPPhgZ);
			}
		}

		private static void rLoenkfHSoxRiUwsHDrPkjfQLFu(RingBuffer<DFsJAhmwnmSRJJkYRXwEfgOEkaa> P_0, knlslTnqsPKELXkpCvqaYPLNMCJ P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				THspmheuzJrGoBXVTvYDMjZcCZ(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void THspmheuzJrGoBXVTvYDMjZcCZ(knlslTnqsPKELXkpCvqaYPLNMCJ P_0, DFsJAhmwnmSRJJkYRXwEfgOEkaa P_1, ref double P_2)
		{
			try
			{
				P_0.gNCEcnFrONoNmBIzemElKBkKsgLf(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void IdpEagzVegTtJCmCdHYdKBRUDeaE(ref oLruUfshGlRHHhqtEntQMNrhdqi P_0)
		{
			while (vdRdcSJAmhdxgFuDQMtgOvYJsTt.ProcessNewEvents())
			{
				utCEPwfyacyhcFOsIqradMvCrAnH(ref P_0, ref vdRdcSJAmhdxgFuDQMtgOvYJsTt.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					xMOAMIpUblwzclpASeqOvbiquVB.SetValue(i, golTpfekpJZdxAtdMfSTzBKxebB((int)P_0.GjtzeSFrmMHuPyjYbDczCVRXyeJ, i), vdRdcSJAmhdxgFuDQMtgOvYJsTt.currentEvent.GetTimestamp());
				}
			}
		}

		private void RyuboIiCNoHepiBOEwDkmemvLmNe(ref oLruUfshGlRHHhqtEntQMNrhdqi P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int gjtzeSFrmMHuPyjYbDczCVRXyeJ = (int)P_0.GjtzeSFrmMHuPyjYbDczCVRXyeJ;
			P_2.SetButtonsBitMask((gjtzeSFrmMHuPyjYbDczCVRXyeJ & 0x7FF) | ((gjtzeSFrmMHuPyjYbDczCVRXyeJ & (gjtzeSFrmMHuPyjYbDczCVRXyeJ & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.erOakDdpZKuYNhudwVwMDQAoKaD));
			P_2.SetAxisValue(1, jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.QogskKrMYxfEwJKUNbWpHGeESPN));
			P_2.SetAxisValue(2, jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.GQmfIrDLBbfWkWgLLgkmFXMACcAU));
			P_2.SetAxisValue(3, jBwGMgeXcypsIUbeXmoFAFFnKCeq(P_0.oEVqLVZrvQMqEXfySOnTYjBGFdv));
			P_2.SetAxisValue(4, saQUSGMfFbhDQAayUBqJOMOFmgOq(P_0.EJOjTuHEVLpDVnsYKkfPSWWjqyU));
			P_2.SetAxisValue(5, saQUSGMfFbhDQAayUBqJOMOFmgOq(P_0.whGgacCMUNGIFyKnzpmhcwDsFih));
		}

		private void utCEPwfyacyhcFOsIqradMvCrAnH(ref oLruUfshGlRHHhqtEntQMNrhdqi P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.GjtzeSFrmMHuPyjYbDczCVRXyeJ = (fZvHAMUBCnlihVaZmvUikUUlFXv)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.erOakDdpZKuYNhudwVwMDQAoKaD = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.QogskKrMYxfEwJKUNbWpHGeESPN = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.GQmfIrDLBbfWkWgLLgkmFXMACcAU = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.oEVqLVZrvQMqEXfySOnTYjBGFdv = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.EJOjTuHEVLpDVnsYKkfPSWWjqyU = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.whGgacCMUNGIFyKnzpmhcwDsFih = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool golTpfekpJZdxAtdMfSTzBKxebB(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void IgqBTMgoLLDsubFJdJZiejmTNfb()
		{
			lock (WfTbITFnDgahnloEWtIracmCfqy)
			{
				nfAwLuanVTBtOtOqauzMcWyGivL = default(oLruUfshGlRHHhqtEntQMNrhdqi);
				RuCNdtNEnNxlwdLWIMpKeIzgxIB = default(oLruUfshGlRHHhqtEntQMNrhdqi);
				xMOAMIpUblwzclpASeqOvbiquVB.Clear();
				vdRdcSJAmhdxgFuDQMtgOvYJsTt.Clear();
			}
		}

		public void Dispose()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(true);
			GC.SuppressFinalize(this);
		}

		~UtcHKTqHdmEeiosPnCXKUYyTuZh()
		{
			LLOFbzNISIbRkZTwkaVnsPpYig(false);
		}

		protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
		{
			if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
			{
				if (P_0)
				{
					vdRdcSJAmhdxgFuDQMtgOvYJsTt.Dispose();
				}
				dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			}
		}

		public static float jBwGMgeXcypsIUbeXmoFAFFnKCeq(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float saQUSGMfFbhDQAayUBqJOMOFmgOq(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool LsExmFHlwgGfxvdvcnKtycZNcPf(oLruUfshGlRHHhqtEntQMNrhdqi P_0, oLruUfshGlRHHhqtEntQMNrhdqi P_1)
		{
			if (P_0.GjtzeSFrmMHuPyjYbDczCVRXyeJ == P_1.GjtzeSFrmMHuPyjYbDczCVRXyeJ && P_0.EJOjTuHEVLpDVnsYKkfPSWWjqyU == P_1.EJOjTuHEVLpDVnsYKkfPSWWjqyU && P_0.whGgacCMUNGIFyKnzpmhcwDsFih == P_1.whGgacCMUNGIFyKnzpmhcwDsFih && P_0.erOakDdpZKuYNhudwVwMDQAoKaD == P_1.erOakDdpZKuYNhudwVwMDQAoKaD && P_0.QogskKrMYxfEwJKUNbWpHGeESPN == P_1.QogskKrMYxfEwJKUNbWpHGeESPN && P_0.GQmfIrDLBbfWkWgLLgkmFXMACcAU == P_1.GQmfIrDLBbfWkWgLLgkmFXMACcAU)
			{
				return P_0.oEVqLVZrvQMqEXfySOnTYjBGFdv == P_1.oEVqLVZrvQMqEXfySOnTYjBGFdv;
			}
			return false;
		}
	}

	public enum EnOvHNnFLIukKSkiGofdEyVTBYu
	{
		tvUdvKgVeyZLZVRGSZUJrIXWmuy = 0,
		DusqhzmXUyMegHfyjcHSiVtflVfj = 1
	}

	public const int SmVQEtOkAsnsuzENvhckWXBppia = 4;

	public const int oIGLoguMpljNIkYyoZTagUSeAoQ = 32768;

	public const int dbhAlfKSdPucBybTcOGBtbUExyt = -32768;

	public const int vmfrvIobsoDjtIlHSbGZTeTejBf = 255;

	public const int MrpyeISOfuGUveGgytJBpunEzec = 0;

	public const int ZEjGuTHktJkldKUPFtAqRmXMuKl = 18;

	public const int mxmudMknZtCGZYDXBvyQmHEXoTU = 14;

	public const int LuardsaKhNmsHrNLTAVPejYHFIrU = 6;

	public const int kpCJYmEgyQbivZHxmFlHuXheWmx = 15;

	private FuThHjtdSobqdDGGClJiotTkzYXh[] dPuwcrPjwTTIbQgziCTrUjGtADP;

	private bool KAUnMXeAZmIazKNDfGjOlfKRFHAA;

	private XUxYttEtJowxIDybUHZPFhKlMLt csYeorwIQrWItoqqwiheTsHKAL;

	private MyOYzuUGOiBGxhtyptZcclOeOQr isMjfmZpwhHSXbdZKxKOfwCNqga;

	private global::TUExllOFrNiCflNptTwhTfgfIzgh<bool> qrWkihqzKfQCChINMfqVmAeIlfB;

	private bool[] grwePwyIhlZiMOtmrCVVOOyBFki;

	private bool[] JCWUWglZrSjNVsSnBLXUTGIwhlj;

	private bool oiXDjnvMKuinPdIMerLpprtOcXoH;

	private readonly bool OhDwxqqlcWUZipIGolutcuwCTRB;

	private readonly UpdateLoopSetting MPyWITsdDQWvVIANbJUScpirSgO;

	private UpdateLoopType pbfWYHQpPpsLzGGARERGiimKxbj;

	private UpdateLoopType FBkkpOYaYaWhFwxHCpiyzLKoUWF;

	private Action<int, ControllerDataUpdater> WmFnGJiLKLAaRkIIWsgqhlsBheL;

	private bool FcXQdHGOrBYLsgUKvMrILtCamqL;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bKHIVnLAXWYbMiOIyqMJrMzriBW;

	private Func<int> soqxPQhwIsLUZvHgdWElDYIwuLk;

	private static Guid[] quAHNSPoJmlKdxxrmQFEQuEYbWm;

	private static string[] IXuvfIbNDJndHImkIdbugwCIefmB;

	private static string[] QqwRzYeUtUoWsQfqcUCoAxugKGe;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (dPuwcrPjwTTIbQgziCTrUjGtADP[i].isConnected)
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

	public mFhbDHUVMhTRsTSifoqtETGQFLi(bool isWin10AUHack, UpdateLoopSetting updateLoop, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		OhDwxqqlcWUZipIGolutcuwCTRB = isWin10AUHack;
		MPyWITsdDQWvVIANbJUScpirSgO = updateLoop;
		FcXQdHGOrBYLsgUKvMrILtCamqL = true;
		try
		{
			if (!ROXKDWXUKcvkJkBQYHFAjebHFlk.BFvKkxFvqMhQoGUuUjHmPRhFkAG(out var rLPLEmaTbAdCzEBENlKjSljwIxd, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (rLPLEmaTbAdCzEBENlKjSljwIxd < RLPLEmaTbAdCzEBENlKjSljwIxd.MdrPqthdYeOoDTFlDHSFKmxtmRH)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			bKHIVnLAXWYbMiOIyqMJrMzriBW = getHardwareJoystickMap_InputManager;
			soqxPQhwIsLUZvHgdWElDYIwuLk = getNewJoystickId;
			oiXDjnvMKuinPdIMerLpprtOcXoH = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(MPyWITsdDQWvVIANbJUScpirSgO, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					FBkkpOYaYaWhFwxHCpiyzLKoUWF = list[num2];
				}
			}
			qrWkihqzKfQCChINMfqVmAeIlfB = new global::TUExllOFrNiCflNptTwhTfgfIzgh<bool>(useSharedThread: true, iIMxzOtjMgMSUXbrWeTfjMEQeUkA);
			grwePwyIhlZiMOtmrCVVOOyBFki = new bool[4];
			JCWUWglZrSjNVsSnBLXUTGIwhlj = new bool[4];
			WmFnGJiLKLAaRkIIWsgqhlsBheL = UpdateControllerData;
			if (oiXDjnvMKuinPdIMerLpprtOcXoH)
			{
				jmfaYfbczmJdEIuNcsOSvgdvRIZW();
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
		if (FcXQdHGOrBYLsgUKvMrILtCamqL)
		{
			csYeorwIQrWItoqqwiheTsHKAL = new XUxYttEtJowxIDybUHZPFhKlMLt(1f);
		}
		isMjfmZpwhHSXbdZKxKOfwCNqga = new MyOYzuUGOiBGxhtyptZcclOeOQr();
		if (dPuwcrPjwTTIbQgziCTrUjGtADP == null)
		{
			dPuwcrPjwTTIbQgziCTrUjGtADP = new FuThHjtdSobqdDGGClJiotTkzYXh[4];
			for (int i = 0; i < 4; i++)
			{
				UtcHKTqHdmEeiosPnCXKUYyTuZh utcHKTqHdmEeiosPnCXKUYyTuZh = new UtcHKTqHdmEeiosPnCXKUYyTuZh(i, MPyWITsdDQWvVIANbJUScpirSgO);
				tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread.ThreadUpdateEvent += utcHKTqHdmEeiosPnCXKUYyTuZh.TDHltpBGvPfIjoqJxelHndOCDue;
				tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickOutputThread.ThreadUpdateEvent += utcHKTqHdmEeiosPnCXKUYyTuZh.wEijusbjaPkjMjXBcHBgJhcpHEZ;
				dPuwcrPjwTTIbQgziCTrUjGtADP[i] = new FuThHjtdSobqdDGGClJiotTkzYXh(i, oiXDjnvMKuinPdIMerLpprtOcXoH, utcHKTqHdmEeiosPnCXKUYyTuZh, bKHIVnLAXWYbMiOIyqMJrMzriBW, SystemDeviceDisconnected);
			}
		}
		unwVLEzOuZEBCtAAGwsPangXGPH(true);
		Update(UpdateLoopType.Update);
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		pbfWYHQpPpsLzGGARERGiimKxbj = currentUpdateLoop;
		vGxdBlKXJhEtHKJthcyFDIPFLKZi();
		for (int i = 0; i < 4; i++)
		{
			if (dPuwcrPjwTTIbQgziCTrUjGtADP[i] != null && dPuwcrPjwTTIbQgziCTrUjGtADP[i].isConnected)
			{
				dPuwcrPjwTTIbQgziCTrUjGtADP[i].Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (qrWkihqzKfQCChINMfqVmAeIlfB != null)
		{
			qrWkihqzKfQCChINMfqVmAeIlfB.LLOFbzNISIbRkZTwkaVnsPpYig();
		}
		if (dPuwcrPjwTTIbQgziCTrUjGtADP != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (dPuwcrPjwTTIbQgziCTrUjGtADP[i] != null)
				{
					if (tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread != null)
					{
						tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickInputThread.ThreadUpdateEvent -= dPuwcrPjwTTIbQgziCTrUjGtADP[i].igbQmSqThzEBDsBKZScaimlglKi.TDHltpBGvPfIjoqJxelHndOCDue;
					}
					if (tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickOutputThread != null)
					{
						tRQxiUSWOtLDbmnzWRyhXVoemgO.joystickOutputThread.ThreadUpdateEvent -= dPuwcrPjwTTIbQgziCTrUjGtADP[i].igbQmSqThzEBDsBKZScaimlglKi.wEijusbjaPkjMjXBcHBgJhcpHEZ;
					}
					dPuwcrPjwTTIbQgziCTrUjGtADP[i].Dispose();
				}
			}
		}
		ROXKDWXUKcvkJkBQYHFAjebHFlk.lwRVDJGvRJeHBSOcsHqfbHazJCIy();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return WmFnGJiLKLAaRkIIWsgqhlsBheL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		dPuwcrPjwTTIbQgziCTrUjGtADP[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		unwVLEzOuZEBCtAAGwsPangXGPH(true);
		wEQAKrADTIXlXfZTIadZhkjglXsE();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		unwVLEzOuZEBCtAAGwsPangXGPH(true);
		wEQAKrADTIXlXfZTIadZhkjglXsE();
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

	private bool QPjAtaHwKrCYsDhubwBgUvjDsvdg()
	{
		if (pbfWYHQpPpsLzGGARERGiimKxbj != FBkkpOYaYaWhFwxHCpiyzLKoUWF)
		{
			return false;
		}
		bool flag = csYeorwIQrWItoqqwiheTsHKAL.CWncwVbJhTWISMonvIVEimpDcKXc();
		if (flag)
		{
			unwVLEzOuZEBCtAAGwsPangXGPH(true);
		}
		return flag;
	}

	private void unwVLEzOuZEBCtAAGwsPangXGPH(bool P_0)
	{
		KAUnMXeAZmIazKNDfGjOlfKRFHAA = P_0;
		if (FcXQdHGOrBYLsgUKvMrILtCamqL)
		{
			csYeorwIQrWItoqqwiheTsHKAL.ZWHXmzFoPzsdydQwCbiSIgZvLxH();
		}
	}

	private void wEQAKrADTIXlXfZTIadZhkjglXsE()
	{
		if (qrWkihqzKfQCChINMfqVmAeIlfB != null)
		{
			qrWkihqzKfQCChINMfqVmAeIlfB.rKJfCRBWFLQsKCjGykmcumzKLPwE();
		}
	}

	private void jmfaYfbczmJdEIuNcsOSvgdvRIZW()
	{
		knlslTnqsPKELXkpCvqaYPLNMCJ knlslTnqsPKELXkpCvqaYPLNMCJ2 = new knlslTnqsPKELXkpCvqaYPLNMCJ();
		_ = knlslTnqsPKELXkpCvqaYPLNMCJ2.IsConnected;
	}

	private void vGxdBlKXJhEtHKJthcyFDIPFLKZi()
	{
		bool flag = false;
		if (FcXQdHGOrBYLsgUKvMrILtCamqL)
		{
			flag = QPjAtaHwKrCYsDhubwBgUvjDsvdg();
		}
		if (!flag && KAUnMXeAZmIazKNDfGjOlfKRFHAA)
		{
			OMAlRULjpCvYWqUFFNpUSuyRiaa(kaBERmoJCkXrWBXpERnRHSxhCGP());
			unwVLEzOuZEBCtAAGwsPangXGPH(false);
			wEQAKrADTIXlXfZTIadZhkjglXsE();
			return;
		}
		if (KAUnMXeAZmIazKNDfGjOlfKRFHAA)
		{
			BkJdeIMBEvNyjriHoGzWTRvwyfd();
		}
		if (qrWkihqzKfQCChINMfqVmAeIlfB.isRunning && qrWkihqzKfQCChINMfqVmAeIlfB.lVgWjrQkCsFlsaFVzSjplyEWLEJg())
		{
			GntxwHbSvkdKZVqZrEXWzBoLwgM();
		}
	}

	private void BkJdeIMBEvNyjriHoGzWTRvwyfd()
	{
		KAUnMXeAZmIazKNDfGjOlfKRFHAA = false;
		if (!qrWkihqzKfQCChINMfqVmAeIlfB.isRunning)
		{
			qrWkihqzKfQCChINMfqVmAeIlfB.UyHkmeYMKxbRaLGZZmHNfcnwklW();
		}
	}

	private void GntxwHbSvkdKZVqZrEXWzBoLwgM()
	{
		lock (grwePwyIhlZiMOtmrCVVOOyBFki)
		{
			Array.Copy(grwePwyIhlZiMOtmrCVVOOyBFki, JCWUWglZrSjNVsSnBLXUTGIwhlj, 4);
		}
		OMAlRULjpCvYWqUFFNpUSuyRiaa(JCWUWglZrSjNVsSnBLXUTGIwhlj);
	}

	private bool iIMxzOtjMgMSUXbrWeTfjMEQeUkA()
	{
		lock (grwePwyIhlZiMOtmrCVVOOyBFki)
		{
			for (int i = 0; i < 4; i++)
			{
				if (dPuwcrPjwTTIbQgziCTrUjGtADP[i] != null)
				{
					grwePwyIhlZiMOtmrCVVOOyBFki[i] = dPuwcrPjwTTIbQgziCTrUjGtADP[i].BNifSUTCIqMhvjPQUVmWdXhdtUY(EnOvHNnFLIukKSkiGofdEyVTBYu.tvUdvKgVeyZLZVRGSZUJrIXWmuy);
				}
			}
		}
		return true;
	}

	private bool[] kaBERmoJCkXrWBXpERnRHSxhCGP()
	{
		for (int i = 0; i < 4; i++)
		{
			JCWUWglZrSjNVsSnBLXUTGIwhlj[i] = dPuwcrPjwTTIbQgziCTrUjGtADP[i].BNifSUTCIqMhvjPQUVmWdXhdtUY(EnOvHNnFLIukKSkiGofdEyVTBYu.tvUdvKgVeyZLZVRGSZUJrIXWmuy);
		}
		return JCWUWglZrSjNVsSnBLXUTGIwhlj;
	}

	private void OMAlRULjpCvYWqUFFNpUSuyRiaa(bool[] P_0)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (dPuwcrPjwTTIbQgziCTrUjGtADP[i] != null && dPuwcrPjwTTIbQgziCTrUjGtADP[i].iReJbzaWagFZkslpoheYjMGcYRs)
			{
				bool flag = P_0[i];
				dPuwcrPjwTTIbQgziCTrUjGtADP[i].MeRhZtdgQairGkQRtCpJAhBsCnCH(flag);
				if (!flag)
				{
					bGZMnrEUihehhlqffgHFcHUJpbf(dPuwcrPjwTTIbQgziCTrUjGtADP[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (dPuwcrPjwTTIbQgziCTrUjGtADP[j] != null && !dPuwcrPjwTTIbQgziCTrUjGtADP[j].iReJbzaWagFZkslpoheYjMGcYRs)
			{
				bool flag2 = P_0[j];
				dPuwcrPjwTTIbQgziCTrUjGtADP[j].MeRhZtdgQairGkQRtCpJAhBsCnCH(flag2);
				if (flag2 && !bGZMnrEUihehhlqffgHFcHUJpbf(dPuwcrPjwTTIbQgziCTrUjGtADP[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (dPuwcrPjwTTIbQgziCTrUjGtADP[k] != null)
			{
				int num2 = ((k == 0) ? 1 : (1 << k));
				if ((num & num2) != 1 << k)
				{
					dPuwcrPjwTTIbQgziCTrUjGtADP[k].VsfvDyXqZIMuiFHDXHZBjZyCAyO(P_0[k]);
				}
			}
		}
	}

	private bool bGZMnrEUihehhlqffgHFcHUJpbf(FuThHjtdSobqdDGGClJiotTkzYXh P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.adDtxuxlZDkRlAXSCGwMGOPQSm();
			if (!P_0.KXWdnFNvBxagMplhHMEKtfPiRjd)
			{
				return false;
			}
			int num = isMjfmZpwhHSXbdZKxKOfwCNqga.vhgNHjvpyPowZUuOihxNWulkANl(P_0.iokwoVwoTYAzFmMXTwAwRvHWPyX, false);
			if (num >= 0)
			{
				P_0.rewiredId = isMjfmZpwhHSXbdZKxKOfwCNqga.QdfbpZaCmLimyXNpjtSKtbRyVDj(num);
				isMjfmZpwhHSXbdZKxKOfwCNqga.CWncwVbJhTWISMonvIVEimpDcKXc(num, P_0, true);
			}
			else
			{
				P_0.rewiredId = soqxPQhwIsLUZvHgdWElDYIwuLk();
				isMjfmZpwhHSXbdZKxKOfwCNqga.zwsiPSlOApWCVvjLZKAmMZzYJvH(P_0, true);
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
			int num2 = isMjfmZpwhHSXbdZKxKOfwCNqga.ExRxpDlEMwqDfegjLZuvCQEtdBt(P_0.rewiredId, P_0.iokwoVwoTYAzFmMXTwAwRvHWPyX, true);
			if (num2 >= 0)
			{
				isMjfmZpwhHSXbdZKxKOfwCNqga.zHlSADEtrBrvetqSSnpDIQEupMP(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = P_0.ToControllerDisconnectedEventArgs();
			P_0.LcOcEkimVsXyMDEsJAYfzejUtyjG();
			if (_DeviceDisconnectedEvent != null)
			{
				_DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	static mFhbDHUVMhTRsTSifoqtETGQFLi()
	{
		quAHNSPoJmlKdxxrmQFEQuEYbWm = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		IXuvfIbNDJndHImkIdbugwCIefmB = new string[1] { "Xbox Bluetooth Gamepad" };
		QqwRzYeUtUoWsQfqcUCoAxugKGe = new string[1] { "Xbox Wireless Controller.*" };
	}

	public static bool TmdtXLMLtxmfoirfUPEqxZwbkhn(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(quAHNSPoJmlKdxxrmQFEQuEYbWm, P_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(P_1))
		{
			for (int i = 0; i < IXuvfIbNDJndHImkIdbugwCIefmB.Length; i++)
			{
				if (P_1.Equals(IXuvfIbNDJndHImkIdbugwCIefmB[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(P_2))
		{
			for (int j = 0; j < QqwRzYeUtUoWsQfqcUCoAxugKGe.Length; j++)
			{
				if (Regex.IsMatch(P_2, QqwRzYeUtUoWsQfqcUCoAxugKGe[j], RegexOptions.IgnoreCase))
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
