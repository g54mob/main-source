using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Utils;

internal class JgtdwCPZBEmqSQnaWXtOJKpKzuR : PlatformInputManager
{
	private class pbvCkoktDJLPiAKikqPXHkvMIHZe : IInputManagerJoystickPublic, IInputManagerJoystick
	{
		private int HwTLNUyvqDkSjEHaWEyOnHlYhGtB;

		private int WBaoxaCThMgQdahqjHosoWBIEZL;

		public Guid RxUYBLYGIqivqakOWtPaeuMeATt;

		public string PwOTiLCDyfZIkjOLBaMuBPvabQuP;

		public foibGJXqBDBdLqGLpNATeBHsIxT TlPIeVvtJlqGmzBlhgEbovEIPdV;

		public BWKfdefSbYUQHxMvQjQCBolasgeb YNXFTszUDHaCzxHFNdehdWIPlhk;

		public string PlMadegsJjnIcHPsrebeTOEozhQ;

		public string AvyftLzUyJglwYQfpfUwBlMFDvlF;

		public int zoKLHtvFVNkkMUCHuynHAkHmONk;

		public int BrgQIQRJLDuAcBXJgGkqkzwAMUC;

		public Guid qBdzfLpHoqJBujyeJGIjMduWcWC;

		public PidVid XxPyoTTaBrqavQxCEWuldVgopKn;

		public Guid EwiyfKFgiSIfUYfxVphNlAaqmIv;

		public int sMBNzsXJlbxStmcInMdeUjrIfabF;

		public int iwpFZmpkohGEjcRddFZKGsfIMtvf;

		public int hsggiECDlEXNwDyOSGbQkSWJzRm;

		public int dXKlnVAJCPAUchFmQZzXBTtazrO;

		public int msnoplUuKhANAHrkQgdLKvneTlEU;

		public int XivCWcPrOJYPzWqNscxqmoZvpex;

		public bool LjJsEbMjhvKHUoKgVbwVDpWsZVKe;

		public bool swbwxminWkIfPLDNkfAOLJChHuv;

		public int hFnuhMXoYvgyCariIlYOShuWnqMq;

		private float[] BmVsDDHajHfWhKZRyhtaTrJBobn;

		private bool[] lwtalwosBMdLgdmWCxwqMEvxwal;

		private HardwareJoystickMap_InputManager ZBMEOTEbHBcUeYYftsfiohhXNEse;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lJvXHfWbRfyIcaObLbvpiCWsQgzw;

		private bool wQEZEuUQyIkSMXhYCsEiNHGszSy;

		private bool NvMWNQFswZpXSwcgvfrXqxOwMyx;

		[CompilerGenerated]
		private Controller.Extension UscFGsIZXVmUpVzIYnHbZDMQIIg;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return HwTLNUyvqDkSjEHaWEyOnHlYhGtB;
			}
			set
			{
				HwTLNUyvqDkSjEHaWEyOnHlYhGtB = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return WBaoxaCThMgQdahqjHosoWBIEZL;
			}
			set
			{
				WBaoxaCThMgQdahqjHosoWBIEZL = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name => PwOTiLCDyfZIkjOLBaMuBPvabQuP;

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (WBaoxaCThMgQdahqjHosoWBIEZL < 0)
				{
					return null;
				}
				return WBaoxaCThMgQdahqjHosoWBIEZL;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => qBdzfLpHoqJBujyeJGIjMduWcWC;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return UscFGsIZXVmUpVzIYnHbZDMQIIg;
			}
			[CompilerGenerated]
			set
			{
				UscFGsIZXVmUpVzIYnHbZDMQIIg = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			TlPIeVvtJlqGmzBlhgEbovEIPdV.kleMgtcSWiiaAKLUBevZHuTJLNsB(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public pbvCkoktDJLPiAKikqPXHkvMIHZe(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
		{
			lJvXHfWbRfyIcaObLbvpiCWsQgzw = getHardwareJoystickMap_InputManager;
			WBaoxaCThMgQdahqjHosoWBIEZL = -1;
			HwTLNUyvqDkSjEHaWEyOnHlYhGtB = -1;
		}

		public void obdzkDbpOaaUIgoMQmAkmvMIcKJ()
		{
			EwiyfKFgiSIfUYfxVphNlAaqmIv = MiscTools.CreateGuidHashSHA1(PlMadegsJjnIcHPsrebeTOEozhQ + XxPyoTTaBrqavQxCEWuldVgopKn.ToProductGuid());
			iwpFZmpkohGEjcRddFZKGsfIMtvf = dXKlnVAJCPAUchFmQZzXBTtazrO;
			hsggiECDlEXNwDyOSGbQkSWJzRm = msnoplUuKhANAHrkQgdLKvneTlEU + XivCWcPrOJYPzWqNscxqmoZvpex * 8;
			PoSdIgbuhkXaateVQltFDLNhMabt();
			RxUYBLYGIqivqakOWtPaeuMeATt = ZBMEOTEbHBcUeYYftsfiohhXNEse.hardwareMapIdentifier.guid;
			PwOTiLCDyfZIkjOLBaMuBPvabQuP = ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName;
			wQEZEuUQyIkSMXhYCsEiNHGszSy = ((RxUYBLYGIqivqakOWtPaeuMeATt == Guid.Empty) ? true : false);
			BmVsDDHajHfWhKZRyhtaTrJBobn = new float[iwpFZmpkohGEjcRddFZKGsfIMtvf];
			lwtalwosBMdLgdmWCxwqMEvxwal = new bool[hsggiECDlEXNwDyOSGbQkSWJzRm];
			Update();
		}

		public void yVXFqVXzLlBDILgCcWPHxsSqcfA(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0)
		{
			if (P_0 != null)
			{
				WBaoxaCThMgQdahqjHosoWBIEZL = P_0.WBaoxaCThMgQdahqjHosoWBIEZL;
				HwTLNUyvqDkSjEHaWEyOnHlYhGtB = P_0.HwTLNUyvqDkSjEHaWEyOnHlYhGtB;
				for (int i = 0; i < MathTools.Min(lwtalwosBMdLgdmWCxwqMEvxwal.Length, P_0.lwtalwosBMdLgdmWCxwqMEvxwal.Length); i++)
				{
					lwtalwosBMdLgdmWCxwqMEvxwal[i] = P_0.lwtalwosBMdLgdmWCxwqMEvxwal[i];
				}
				for (int j = 0; j < MathTools.Min(BmVsDDHajHfWhKZRyhtaTrJBobn.Length, P_0.BmVsDDHajHfWhKZRyhtaTrJBobn.Length); j++)
				{
					BmVsDDHajHfWhKZRyhtaTrJBobn[j] = P_0.BmVsDDHajHfWhKZRyhtaTrJBobn[j];
				}
				NvMWNQFswZpXSwcgvfrXqxOwMyx = P_0.NvMWNQFswZpXSwcgvfrXqxOwMyx;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			OqHywWvXuiMZOBydYSSzaganIrEK();
			dpxLoNUKQscDlKAbeZOSlMIeEvD();
			if (!NvMWNQFswZpXSwcgvfrXqxOwMyx && TlPIeVvtJlqGmzBlhgEbovEIPdV.HasEverReceivedInput)
			{
				NvMWNQFswZpXSwcgvfrXqxOwMyx = true;
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (iwpFZmpkohGEjcRddFZKGsfIMtvf != dataUpdater.axisCount || hsggiECDlEXNwDyOSGbQkSWJzRm != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < iwpFZmpkohGEjcRddFZKGsfIMtvf; i++)
			{
				dataUpdater.axisValues[i] = BmVsDDHajHfWhKZRyhtaTrJBobn[i];
			}
			for (int j = 0; j < hsggiECDlEXNwDyOSGbQkSWJzRm; j++)
			{
				dataUpdater.buttonValues[j] = lwtalwosBMdLgdmWCxwqMEvxwal[j];
			}
			if (NvMWNQFswZpXSwcgvfrXqxOwMyx && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int QuyjPPVLYssrxnLbKpFVOFYkPay(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0)
		{
			if (P_0.HwTLNUyvqDkSjEHaWEyOnHlYhGtB == HwTLNUyvqDkSjEHaWEyOnHlYhGtB)
			{
				return 2;
			}
			if (dXKlnVAJCPAUchFmQZzXBTtazrO != P_0.dXKlnVAJCPAUchFmQZzXBTtazrO)
			{
				return 0;
			}
			if (msnoplUuKhANAHrkQgdLKvneTlEU != P_0.msnoplUuKhANAHrkQgdLKvneTlEU)
			{
				return 0;
			}
			if (XivCWcPrOJYPzWqNscxqmoZvpex != P_0.XivCWcPrOJYPzWqNscxqmoZvpex)
			{
				return 0;
			}
			if (P_0.qBdzfLpHoqJBujyeJGIjMduWcWC == qBdzfLpHoqJBujyeJGIjMduWcWC)
			{
				return 2;
			}
			if (P_0.EwiyfKFgiSIfUYfxVphNlAaqmIv == EwiyfKFgiSIfUYfxVphNlAaqmIv)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo TuJmIhZHnIxJHszIupkxqjtULhV()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			etfbyzPQFfFMvByaCyNPpDEsUfK(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			etfbyzPQFfFMvByaCyNPpDEsUfK(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(HwTLNUyvqDkSjEHaWEyOnHlYhGtB);
		}

		private void OqHywWvXuiMZOBydYSSzaganIrEK()
		{
			if (iwpFZmpkohGEjcRddFZKGsfIMtvf <= 0)
			{
				return;
			}
			InputPlatform platform = ZBMEOTEbHBcUeYYftsfiohhXNEse.map.platform;
			if (platform != InputPlatform.fMohdktunNVwcKFhaCaZcTOyeuLa)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)ZBMEOTEbHBcUeYYftsfiohhXNEse.map;
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = platform_SDL2_Base.Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					RQPllwQyYJcoEBVNAsibLjPlWnT(axes_orig[i], i);
				}
			}
		}

		private void dpxLoNUKQscDlKAbeZOSlMIeEvD()
		{
			if (hsggiECDlEXNwDyOSGbQkSWJzRm <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base platform_SDL2_Base = (HardwareJoystickMap.Platform_SDL2_Base)ZBMEOTEbHBcUeYYftsfiohhXNEse.map;
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = platform_SDL2_Base.Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					DAWzkBHNrwZptsoxbMGHFASEgaL(buttons_orig[i], i);
				}
			}
		}

		private void RQPllwQyYJcoEBVNAsibLjPlWnT(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= iwpFZmpkohGEjcRddFZKGsfIMtvf)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			BmVsDDHajHfWhKZRyhtaTrJBobn[P_1] = QTYKdOZLkJEqXkCFTAyzbbojlRXP(P_0);
		}

		private void DAWzkBHNrwZptsoxbMGHFASEgaL(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= hsggiECDlEXNwDyOSGbQkSWJzRm)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			lwtalwosBMdLgdmWCxwqMEvxwal[P_1] = kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0);
		}

		private float QTYKdOZLkJEqXkCFTAyzbbojlRXP(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= dXKlnVAJCPAUchFmQZzXBTtazrO || sourceAxis >= 56)
				{
					return 0f;
				}
				return TlPIeVvtJlqGmzBlhgEbovEIPdV.QTYKdOZLkJEqXkCFTAyzbbojlRXP(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= msnoplUuKhANAHrkQgdLKvneTlEU || sourceButton >= 256)
				{
					return 0f;
				}
				if (!TlPIeVvtJlqGmzBlhgEbovEIPdV.kAVHgdphgcHqDOwQpMCcCbwXpBK(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= XivCWcPrOJYPzWqNscxqmoZvpex || sourceHat >= 4)
				{
					return 0f;
				}
				int num = TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = dCWkcpCotuqsxrPDLJmYFSElTvd(num, AxisDirection.Horizontal);
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
					num2 = dCWkcpCotuqsxrPDLJmYFSElTvd(num, AxisDirection.Vertical);
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

		private bool kAVHgdphgcHqDOwQpMCcCbwXpBK(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (TlPIeVvtJlqGmzBlhgEbovEIPdV.kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!TlPIeVvtJlqGmzBlhgEbovEIPdV.kAVHgdphgcHqDOwQpMCcCbwXpBK(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= msnoplUuKhANAHrkQgdLKvneTlEU || sourceButton >= 256)
				{
					return false;
				}
				return TlPIeVvtJlqGmzBlhgEbovEIPdV.kAVHgdphgcHqDOwQpMCcCbwXpBK(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= dXKlnVAJCPAUchFmQZzXBTtazrO || sourceAxis >= 56)
				{
					return false;
				}
				float num = TlPIeVvtJlqGmzBlhgEbovEIPdV.QTYKdOZLkJEqXkCFTAyzbbojlRXP(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= XivCWcPrOJYPzWqNscxqmoZvpex || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return oWWbOdrrgsFCcsaVOXFhMfPcaVP(TlPIeVvtJlqGmzBlhgEbovEIPdV.FFydkTOruaTjWQcdDbKNjjyoDOR(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool oWWbOdrrgsFCcsaVOXFhMfPcaVP(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float dCWkcpCotuqsxrPDLJmYFSElTvd(int P_0, AxisDirection P_1)
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

		private ControlDeviceType ExHMTeTaxrBiOECbdhQirgXuYmli(BWKfdefSbYUQHxMvQjQCBolasgeb P_0)
		{
			return P_0 switch
			{
				BWKfdefSbYUQHxMvQjQCBolasgeb.uiRYEFedDHmUTxShoQfUcCLjblSE => ControlDeviceType.uiRYEFedDHmUTxShoQfUcCLjblSE, 
				BWKfdefSbYUQHxMvQjQCBolasgeb.xMAFLxhGvaUFxGrktALTXyTGqvn => ControlDeviceType.xMAFLxhGvaUFxGrktALTXyTGqvn, 
				BWKfdefSbYUQHxMvQjQCBolasgeb.fQYnmvKyNAUpwLJlHByyedaPIyZG => ControlDeviceType.fQYnmvKyNAUpwLJlHByyedaPIyZG, 
				BWKfdefSbYUQHxMvQjQCBolasgeb.EbLlCRijimOLmWyMuIbuKxBCfaJ => ControlDeviceType.EbLlCRijimOLmWyMuIbuKxBCfaJ, 
				_ => ControlDeviceType.eDgdySKclHgXmmILffzdHPvUtEi, 
			};
		}

		private void PoSdIgbuhkXaateVQltFDLNhMabt()
		{
			ZBMEOTEbHBcUeYYftsfiohhXNEse = lJvXHfWbRfyIcaObLbvpiCWsQgzw(TuJmIhZHnIxJHszIupkxqjtULhV());
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse.useSystemName && !string.IsNullOrEmpty(AvyftLzUyJglwYQfpfUwBlMFDvlF))
			{
				string text = Regex.Replace(AvyftLzUyJglwYQfpfUwBlMFDvlF, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					ZBMEOTEbHBcUeYYftsfiohhXNEse.controllerName = text;
				}
			}
			iwpFZmpkohGEjcRddFZKGsfIMtvf = ZBMEOTEbHBcUeYYftsfiohhXNEse.axisCount;
			hsggiECDlEXNwDyOSGbQkSWJzRm = ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonCount;
		}

		private string JIJQrXmiOwRkdUwZddYfecIBmwD()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{TlPIeVvtJlqGmzBlhgEbovEIPdV.InputSource}{PlMadegsJjnIcHPsrebeTOEozhQ}{zoKLHtvFVNkkMUCHuynHAkHmONk}{XxPyoTTaBrqavQxCEWuldVgopKn.ToProductGuid()}");
		}

		private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = TlPIeVvtJlqGmzBlhgEbovEIPdV.InputSource;
			P_0.deviceType = ExHMTeTaxrBiOECbdhQirgXuYmli(YNXFTszUDHaCzxHFNdehdWIPlhk);
			P_0.hardwareIdentifier = JIJQrXmiOwRkdUwZddYfecIBmwD();
			P_0.hardwareAxisCount = dXKlnVAJCPAUchFmQZzXBTtazrO;
			P_0.hardwareButtonCount = msnoplUuKhANAHrkQgdLKvneTlEU;
			P_0.hardwareHatCount = XivCWcPrOJYPzWqNscxqmoZvpex;
			P_0.hw_productName = PlMadegsJjnIcHPsrebeTOEozhQ;
			P_0.hw_deviceGuid = qBdzfLpHoqJBujyeJGIjMduWcWC;
			P_0.hw_productId = zoKLHtvFVNkkMUCHuynHAkHmONk;
			P_0.hw_pidVid = XxPyoTTaBrqavQxCEWuldVgopKn;
			P_0.hw_isBluetoothDevice = LjJsEbMjhvKHUoKgVbwVDpWsZVKe;
			P_0.hw_bluetoothDeviceName = PlMadegsJjnIcHPsrebeTOEozhQ;
			P_0.hw_systemDeviceName = PlMadegsJjnIcHPsrebeTOEozhQ;
			P_0.hw_supportsVibration = swbwxminWkIfPLDNkfAOLJChHuv;
			P_0.hw_isSDL2Gamepad = TlPIeVvtJlqGmzBlhgEbovEIPdV.DeviceType == BWKfdefSbYUQHxMvQjQCBolasgeb.xMAFLxhGvaUFxGrktALTXyTGqvn;
			P_0.hw_localVibrationMotorCount = hFnuhMXoYvgyCariIlYOShuWnqMq;
		}

		private void etfbyzPQFfFMvByaCyNPpDEsUfK(BridgedController P_0)
		{
			etfbyzPQFfFMvByaCyNPpDEsUfK((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = ZBMEOTEbHBcUeYYftsfiohhXNEse.ToGameHardwareControllerMap();
			P_0.instanceName = PlMadegsJjnIcHPsrebeTOEozhQ;
			P_0.productName = PlMadegsJjnIcHPsrebeTOEozhQ;
			P_0.axisCount = iwpFZmpkohGEjcRddFZKGsfIMtvf;
			P_0.buttonCount = hsggiECDlEXNwDyOSGbQkSWJzRm;
			P_0.unknownControllerHats = TqZfiDfzPnbaXHkWHSPgDfzCgsap();
			P_0.controllerTypeGuid = RxUYBLYGIqivqakOWtPaeuMeATt;
			P_0.controllerExtension = extension;
		}

		private void QVbCiZwknwJDSSZwwrgEowEKbAZ()
		{
			for (int i = 0; i < hsggiECDlEXNwDyOSGbQkSWJzRm; i++)
			{
				lwtalwosBMdLgdmWCxwqMEvxwal[i] = false;
			}
			for (int j = 0; j < iwpFZmpkohGEjcRddFZKGsfIMtvf; j++)
			{
				BmVsDDHajHfWhKZRyhtaTrJBobn[j] = 0f;
			}
		}

		private UnknownControllerHat[] TqZfiDfzPnbaXHkWHSPgDfzCgsap()
		{
			if (!wQEZEuUQyIkSMXhYCsEiNHGszSy)
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

		public static int GxDEXTomhoFUSPwniPKgVeysYnC(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, pbvCkoktDJLPiAKikqPXHkvMIHZe P_1)
		{
			if (P_0.WBaoxaCThMgQdahqjHosoWBIEZL < P_1.WBaoxaCThMgQdahqjHosoWBIEZL)
			{
				return -1;
			}
			if (P_0.WBaoxaCThMgQdahqjHosoWBIEZL > P_1.WBaoxaCThMgQdahqjHosoWBIEZL)
			{
				return 1;
			}
			return 0;
		}

		public static int QbfUhzJwpGHfcGNVphgCnDnrtWf(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, pbvCkoktDJLPiAKikqPXHkvMIHZe P_1)
		{
			if (P_0.sMBNzsXJlbxStmcInMdeUjrIfabF < P_1.sMBNzsXJlbxStmcInMdeUjrIfabF)
			{
				return -1;
			}
			if (P_0.sMBNzsXJlbxStmcInMdeUjrIfabF > P_1.sMBNzsXJlbxStmcInMdeUjrIfabF)
			{
				return 1;
			}
			return 0;
		}
	}

	private class XCwFydGRILHWLkEArWlpFxfKRKn
	{
		public enum pOpXcwqGsoTkfFNyRCzWHgpVKNSu
		{
			bsEuTteZfWpGGkkWfgFWdtTyWHGw = 0,
			HoUDpKToZAvYvTCsbfaQUrQsFTC = 1
		}

		public class pjKgXsIZnkftWWFTBGpEbXvvTeRW
		{
			public int AVJCjGFlvmvUQprbQtbNLTqidXD;

			public Guid MFxPNNDXcQATxqTzNEBJQKaLbJl;

			public Guid EwiyfKFgiSIfUYfxVphNlAaqmIv;

			public int SCvLuAiDgDtSaPnKtxXIaqXDocp;

			public int dXKlnVAJCPAUchFmQZzXBTtazrO;

			public int msnoplUuKhANAHrkQgdLKvneTlEU;

			public int XivCWcPrOJYPzWqNscxqmoZvpex;

			public bool QuyjPPVLYssrxnLbKpFVOFYkPay(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, pOpXcwqGsoTkfFNyRCzWHgpVKNSu P_1)
			{
				if (P_0.rewiredId == AVJCjGFlvmvUQprbQtbNLTqidXD)
				{
					return true;
				}
				if (dXKlnVAJCPAUchFmQZzXBTtazrO != P_0.dXKlnVAJCPAUchFmQZzXBTtazrO)
				{
					return false;
				}
				if (msnoplUuKhANAHrkQgdLKvneTlEU != P_0.msnoplUuKhANAHrkQgdLKvneTlEU)
				{
					return false;
				}
				if (XivCWcPrOJYPzWqNscxqmoZvpex != P_0.XivCWcPrOJYPzWqNscxqmoZvpex)
				{
					return false;
				}
				return P_1 switch
				{
					pOpXcwqGsoTkfFNyRCzWHgpVKNSu.bsEuTteZfWpGGkkWfgFWdtTyWHGw => MFxPNNDXcQATxqTzNEBJQKaLbJl == P_0.qBdzfLpHoqJBujyeJGIjMduWcWC, 
					pOpXcwqGsoTkfFNyRCzWHgpVKNSu.HoUDpKToZAvYvTCsbfaQUrQsFTC => EwiyfKFgiSIfUYfxVphNlAaqmIv == P_0.EwiyfKFgiSIfUYfxVphNlAaqmIv, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class wVuPDbXGdVuGQNWWRZkyTYyewSN : IDisposable, IEnumerator, IEnumerable, IEnumerable<pjKgXsIZnkftWWFTBGpEbXvvTeRW>, IEnumerator<pjKgXsIZnkftWWFTBGpEbXvvTeRW>
		{
			private pjKgXsIZnkftWWFTBGpEbXvvTeRW ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public XCwFydGRILHWLkEArWlpFxfKRKn kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public pbvCkoktDJLPiAKikqPXHkvMIHZe UrVHqfdkMVOZnqPAIiNXclLMHTZj;

			public pbvCkoktDJLPiAKikqPXHkvMIHZe ipVhBkVCCSfvawTftgxfuhaEZKG;

			public pOpXcwqGsoTkfFNyRCzWHgpVKNSu paUXJyBjwVEMwHcXAcJgCsKrCvZ;

			public pOpXcwqGsoTkfFNyRCzWHgpVKNSu FXZuxBvuEcsvWVdlSVqtSMIHOMp;

			public int jzXYVuNmyUOzZqJbVDRwwOzdDGD;

			public int MKtfUfOrPwqaxcTZkMuwxjFLVMS;

			pjKgXsIZnkftWWFTBGpEbXvvTeRW IEnumerator<pjKgXsIZnkftWWFTBGpEbXvvTeRW>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<pjKgXsIZnkftWWFTBGpEbXvvTeRW> IEnumerable<pjKgXsIZnkftWWFTBGpEbXvvTeRW>.GetEnumerator()
			{
				wVuPDbXGdVuGQNWWRZkyTYyewSN wVuPDbXGdVuGQNWWRZkyTYyewSN2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					wVuPDbXGdVuGQNWWRZkyTYyewSN2 = this;
				}
				else
				{
					wVuPDbXGdVuGQNWWRZkyTYyewSN2 = new wVuPDbXGdVuGQNWWRZkyTYyewSN(0);
					wVuPDbXGdVuGQNWWRZkyTYyewSN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				wVuPDbXGdVuGQNWWRZkyTYyewSN2.UrVHqfdkMVOZnqPAIiNXclLMHTZj = ipVhBkVCCSfvawTftgxfuhaEZKG;
				wVuPDbXGdVuGQNWWRZkyTYyewSN2.paUXJyBjwVEMwHcXAcJgCsKrCvZ = FXZuxBvuEcsvWVdlSVqtSMIHOMp;
				return wVuPDbXGdVuGQNWWRZkyTYyewSN2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<pjKgXsIZnkftWWFTBGpEbXvvTeRW>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					jzXYVuNmyUOzZqJbVDRwwOzdDGD = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB.Count;
					MKtfUfOrPwqaxcTZkMuwxjFLVMS = 0;
					goto IL_00a3;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0095;
					}
					IL_00a3:
					if (MKtfUfOrPwqaxcTZkMuwxjFLVMS >= jzXYVuNmyUOzZqJbVDRwwOzdDGD)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[MKtfUfOrPwqaxcTZkMuwxjFLVMS].QuyjPPVLYssrxnLbKpFVOFYkPay(UrVHqfdkMVOZnqPAIiNXclLMHTZj, paUXJyBjwVEMwHcXAcJgCsKrCvZ))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = kdBZqupjvsCsVkwJiOeEQzkEDVO.fopcRAyqeBjmZPOELjthAdVYQiB[MKtfUfOrPwqaxcTZkMuwxjFLVMS];
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0095;
					IL_0095:
					MKtfUfOrPwqaxcTZkMuwxjFLVMS++;
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
			public wVuPDbXGdVuGQNWWRZkyTYyewSN(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private List<pjKgXsIZnkftWWFTBGpEbXvvTeRW> fopcRAyqeBjmZPOELjthAdVYQiB;

		public XCwFydGRILHWLkEArWlpFxfKRKn()
		{
			fopcRAyqeBjmZPOELjthAdVYQiB = new List<pjKgXsIZnkftWWFTBGpEbXvvTeRW>();
		}

		public void pNtVjMTCwjmfvmJXawLBYkfoTpi(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
			for (int i = 0; i < count; i++)
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[i].QuyjPPVLYssrxnLbKpFVOFYkPay(P_0, pOpXcwqGsoTkfFNyRCzWHgpVKNSu.bsEuTteZfWpGGkkWfgFWdtTyWHGw))
				{
					fopcRAyqeBjmZPOELjthAdVYQiB[i].AVJCjGFlvmvUQprbQtbNLTqidXD = P_0.rewiredId;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].MFxPNNDXcQATxqTzNEBJQKaLbJl = P_0.qBdzfLpHoqJBujyeJGIjMduWcWC;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].EwiyfKFgiSIfUYfxVphNlAaqmIv = P_0.EwiyfKFgiSIfUYfxVphNlAaqmIv;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].SCvLuAiDgDtSaPnKtxXIaqXDocp = P_0.inputManagerId;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].dXKlnVAJCPAUchFmQZzXBTtazrO = P_0.dXKlnVAJCPAUchFmQZzXBTtazrO;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].msnoplUuKhANAHrkQgdLKvneTlEU = P_0.msnoplUuKhANAHrkQgdLKvneTlEU;
					fopcRAyqeBjmZPOELjthAdVYQiB[i].XivCWcPrOJYPzWqNscxqmoZvpex = P_0.XivCWcPrOJYPzWqNscxqmoZvpex;
					BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, P_0.qBdzfLpHoqJBujyeJGIjMduWcWC, i);
					return;
				}
			}
			fopcRAyqeBjmZPOELjthAdVYQiB.Add(new pjKgXsIZnkftWWFTBGpEbXvvTeRW
			{
				AVJCjGFlvmvUQprbQtbNLTqidXD = P_0.rewiredId,
				MFxPNNDXcQATxqTzNEBJQKaLbJl = P_0.qBdzfLpHoqJBujyeJGIjMduWcWC,
				EwiyfKFgiSIfUYfxVphNlAaqmIv = P_0.EwiyfKFgiSIfUYfxVphNlAaqmIv,
				SCvLuAiDgDtSaPnKtxXIaqXDocp = P_0.inputManagerId,
				dXKlnVAJCPAUchFmQZzXBTtazrO = P_0.dXKlnVAJCPAUchFmQZzXBTtazrO,
				msnoplUuKhANAHrkQgdLKvneTlEU = P_0.msnoplUuKhANAHrkQgdLKvneTlEU,
				XivCWcPrOJYPzWqNscxqmoZvpex = P_0.XivCWcPrOJYPzWqNscxqmoZvpex
			});
			BmxembdddCYcgouqniXoOKxIaBMm(P_0.rewiredId, P_0.qBdzfLpHoqJBujyeJGIjMduWcWC, fopcRAyqeBjmZPOELjthAdVYQiB.Count - 1);
		}

		public bool YRagHVGgqrxCGUgBYtkIqvCxSddL(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, pOpXcwqGsoTkfFNyRCzWHgpVKNSu P_1)
		{
			int count = fopcRAyqeBjmZPOELjthAdVYQiB.Count;
			for (int i = 0; i < count; i++)
			{
				if (fopcRAyqeBjmZPOELjthAdVYQiB[i].QuyjPPVLYssrxnLbKpFVOFYkPay(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<pjKgXsIZnkftWWFTBGpEbXvvTeRW> afvWoBaYQAGDQJhLdAqXpRXzPls(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, pOpXcwqGsoTkfFNyRCzWHgpVKNSu P_1)
		{
			wVuPDbXGdVuGQNWWRZkyTYyewSN wVuPDbXGdVuGQNWWRZkyTYyewSN2 = new wVuPDbXGdVuGQNWWRZkyTYyewSN(-2);
			wVuPDbXGdVuGQNWWRZkyTYyewSN2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			wVuPDbXGdVuGQNWWRZkyTYyewSN2.ipVhBkVCCSfvawTftgxfuhaEZKG = P_0;
			wVuPDbXGdVuGQNWWRZkyTYyewSN2.FXZuxBvuEcsvWVdlSVqtSMIHOMp = P_1;
			return wVuPDbXGdVuGQNWWRZkyTYyewSN2;
		}

		private void BmxembdddCYcgouqniXoOKxIaBMm(int P_0, Guid P_1, int P_2)
		{
			for (int num = fopcRAyqeBjmZPOELjthAdVYQiB.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (fopcRAyqeBjmZPOELjthAdVYQiB[num].AVJCjGFlvmvUQprbQtbNLTqidXD == P_0 || fopcRAyqeBjmZPOELjthAdVYQiB[num].MFxPNNDXcQATxqTzNEBJQKaLbJl == P_1))
				{
					fopcRAyqeBjmZPOELjthAdVYQiB.RemoveAt(num);
				}
			}
		}
	}

	internal const bool iODHYbsGKMLPjkeomNdBalSJfGf = true;

	private IInputSource ZDlUxkUjsUcGKeLVqrQXLelAILc;

	private List<pbvCkoktDJLPiAKikqPXHkvMIHZe> GpKTUjLMGVeIHJzINAjLhtehdVC;

	private int hkPEgaZbxwhJzMkQldVtavOeqXDv;

	private XCwFydGRILHWLkEArWlpFxfKRKn VXRpRQGmBLUsrQikVDSFCugvidLN;

	private bool DWJnXrOBumpLFfmZPjflDMezshO;

	private Action<int, ControllerDataUpdater> OBflEVhfTmffnsAjdGTAfWJOvWq;

	private PlatformInputManager STXNVyGURWHvVpTJBWUcsUurLbv;

	private readonly bool rTBZChsWvIMJDvQUVMrHNOniKIa;

	private readonly bool JVFQwLOrbFHJoUHgbzVjTHEeAPd;

	private readonly bool qFuapJVYWeknrVjEMYqXTUbYADM;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lJvXHfWbRfyIcaObLbvpiCWsQgzw;

	private readonly Func<int> aKvCUaiGXmdnbQBGdJPaRbbDQB;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => hkPEgaZbxwhJzMkQldVtavOeqXDv;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => STXNVyGURWHvVpTJBWUcsUurLbv;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => ZDlUxkUjsUcGKeLVqrQXLelAILc;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.SDL2;

	public JgtdwCPZBEmqSQnaWXtOJKpKzuR(ConfigVars configVars, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId, bool handleJoysticks, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
	{
		try
		{
			lJvXHfWbRfyIcaObLbvpiCWsQgzw = getHardwareJoystickMap_InputManager;
			aKvCUaiGXmdnbQBGdJPaRbbDQB = getNewJoystickId;
			rTBZChsWvIMJDvQUVMrHNOniKIa = handleJoysticks;
			JVFQwLOrbFHJoUHgbzVjTHEeAPd = handleUnifiedMouse;
			qFuapJVYWeknrVjEMYqXTUbYADM = handleUnifiedKeyboard;
			STXNVyGURWHvVpTJBWUcsUurLbv = this;
			ZDlUxkUjsUcGKeLVqrQXLelAILc = new SDL2InputSource(configVars.updateLoop, handleJoysticks, handleJoysticks, handleUnifiedMouse, handleUnifiedKeyboard);
			OBflEVhfTmffnsAjdGTAfWJOvWq = UpdateControllerData;
			ZDlUxkUjsUcGKeLVqrQXLelAILc.DeviceChangedEvent += PFsgcBAqudCMKvLgQUMNRnqFSqBm;
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
		if (rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			VXRpRQGmBLUsrQikVDSFCugvidLN = new XCwFydGRILHWLkEArWlpFxfKRKn();
			OoDFaIeyrIrGfOQwdBnCiIvBbHRL();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (ZDlUxkUjsUcGKeLVqrQXLelAILc != null)
		{
			ZDlUxkUjsUcGKeLVqrQXLelAILc.Update();
		}
		if (rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			if (DWJnXrOBumpLFfmZPjflDMezshO)
			{
				ECgcLnNOAxTzdoTYOgpcfwIQwLY();
			}
			if (ZDlUxkUjsUcGKeLVqrQXLelAILc != null)
			{
				for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
				{
					GpKTUjLMGVeIHJzINAjLhtehdVC[i]?.TlPIeVvtJlqGmzBlhgEbovEIPdV.QTPiZFmnRsxmyQYmMuIoBQkOtfg(updateLoop);
				}
				ZDlUxkUjsUcGKeLVqrQXLelAILc.UpdateDevices(updateLoop);
			}
			fikeeHzZorPbLCMiizOEMORFdJAK();
			if (ZDlUxkUjsUcGKeLVqrQXLelAILc != null)
			{
				ZDlUxkUjsUcGKeLVqrQXLelAILc.UpdateFinished();
				for (int j = 0; j < hkPEgaZbxwhJzMkQldVtavOeqXDv; j++)
				{
					GpKTUjLMGVeIHJzINAjLhtehdVC[j]?.TlPIeVvtJlqGmzBlhgEbovEIPdV.yBuuCvoSMWjNMRELDWTrhiPPkXs();
				}
			}
		}
		_ = JVFQwLOrbFHJoUHgbzVjTHEeAPd;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (GpKTUjLMGVeIHJzINAjLhtehdVC != null)
		{
			int count = GpKTUjLMGVeIHJzINAjLhtehdVC.Count;
			for (int i = 0; i < count; i++)
			{
				if (GpKTUjLMGVeIHJzINAjLhtehdVC[i] != null)
				{
					GpKTUjLMGVeIHJzINAjLhtehdVC[i].TlPIeVvtJlqGmzBlhgEbovEIPdV?.BLflYGegufXOPfvlydomFOMZLR();
				}
			}
		}
		if (ZDlUxkUjsUcGKeLVqrQXLelAILc != null)
		{
			ZDlUxkUjsUcGKeLVqrQXLelAILc.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OBflEVhfTmffnsAjdGTAfWJOvWq;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			return;
		}
		for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[i].inputManagerId == inputManagerId)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = rTBZChsWvIMJDvQUVMrHNOniKIa;
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

	private void OoDFaIeyrIrGfOQwdBnCiIvBbHRL()
	{
		OoDFaIeyrIrGfOQwdBnCiIvBbHRL(HiFgvZhvCfAjiayZhQfZhLXwkNpG());
	}

	private void OoDFaIeyrIrGfOQwdBnCiIvBbHRL(IList<foibGJXqBDBdLqGLpNATeBHsIxT> P_0)
	{
		int num = 0;
		List<pbvCkoktDJLPiAKikqPXHkvMIHZe> gpKTUjLMGVeIHJzINAjLhtehdVC = GpKTUjLMGVeIHJzINAjLhtehdVC;
		int num2 = hkPEgaZbxwhJzMkQldVtavOeqXDv;
		GpKTUjLMGVeIHJzINAjLhtehdVC = new List<pbvCkoktDJLPiAKikqPXHkvMIHZe>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				foibGJXqBDBdLqGLpNATeBHsIxT foibGJXqBDBdLqGLpNATeBHsIxT2 = P_0[i];
				pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe2 = new pbvCkoktDJLPiAKikqPXHkvMIHZe(lJvXHfWbRfyIcaObLbvpiCWsQgzw);
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.TlPIeVvtJlqGmzBlhgEbovEIPdV = foibGJXqBDBdLqGLpNATeBHsIxT2;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.qBdzfLpHoqJBujyeJGIjMduWcWC = foibGJXqBDBdLqGLpNATeBHsIxT2.InstanceGuid;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.PlMadegsJjnIcHPsrebeTOEozhQ = foibGJXqBDBdLqGLpNATeBHsIxT2.SystemName;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.AvyftLzUyJglwYQfpfUwBlMFDvlF = foibGJXqBDBdLqGLpNATeBHsIxT2.FriendlyName;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.XxPyoTTaBrqavQxCEWuldVgopKn = foibGJXqBDBdLqGLpNATeBHsIxT2.PidVid;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.zoKLHtvFVNkkMUCHuynHAkHmONk = foibGJXqBDBdLqGLpNATeBHsIxT2.ProductId;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.BrgQIQRJLDuAcBXJgGkqkzwAMUC = foibGJXqBDBdLqGLpNATeBHsIxT2.VendorId;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.YNXFTszUDHaCzxHFNdehdWIPlhk = foibGJXqBDBdLqGLpNATeBHsIxT2.DeviceType;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.sMBNzsXJlbxStmcInMdeUjrIfabF = foibGJXqBDBdLqGLpNATeBHsIxT2.JoystickId;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.dXKlnVAJCPAUchFmQZzXBTtazrO = foibGJXqBDBdLqGLpNATeBHsIxT2.AxisCount;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.msnoplUuKhANAHrkQgdLKvneTlEU = foibGJXqBDBdLqGLpNATeBHsIxT2.ButtonCount;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.XivCWcPrOJYPzWqNscxqmoZvpex = foibGJXqBDBdLqGLpNATeBHsIxT2.HatCount;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.LjJsEbMjhvKHUoKgVbwVDpWsZVKe = foibGJXqBDBdLqGLpNATeBHsIxT2.IsBluetoothDevice;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.swbwxminWkIfPLDNkfAOLJChHuv = foibGJXqBDBdLqGLpNATeBHsIxT2.SupportsVibration;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.hFnuhMXoYvgyCariIlYOShuWnqMq = foibGJXqBDBdLqGLpNATeBHsIxT2.VibrationMotorCount;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.extension = foibGJXqBDBdLqGLpNATeBHsIxT2.ControllerExtension;
				foibGJXqBDBdLqGLpNATeBHsIxT2.QAjacOrjhHavTCkkyNQHPEELDVD();
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.obdzkDbpOaaUIgoMQmAkmvMIcKJ();
				GpKTUjLMGVeIHJzINAjLhtehdVC.Add(pbvCkoktDJLPiAKikqPXHkvMIHZe2);
				num++;
			}
		}
		hkPEgaZbxwhJzMkQldVtavOeqXDv = num;
		KTAwGzsoAsHiEgQlJqUIcwdlEjt(num2, num, gpKTUjLMGVeIHJzINAjLhtehdVC, GpKTUjLMGVeIHJzINAjLhtehdVC);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(GpKTUjLMGVeIHJzINAjLhtehdVC[j]));
			}
		}
		NLNETPIPcIzZWgQktmiidfjpSxOl(gpKTUjLMGVeIHJzINAjLhtehdVC, GpKTUjLMGVeIHJzINAjLhtehdVC, false);
		NLNETPIPcIzZWgQktmiidfjpSxOl(GpKTUjLMGVeIHJzINAjLhtehdVC, gpKTUjLMGVeIHJzINAjLhtehdVC, true);
	}

	private void fikeeHzZorPbLCMiizOEMORFdJAK()
	{
		for (int i = 0; i < hkPEgaZbxwhJzMkQldVtavOeqXDv; i++)
		{
			GpKTUjLMGVeIHJzINAjLhtehdVC[i]?.Update();
		}
	}

	private bool OVjZrUUanuenQGXPvojbLIRyKfku(ZRynwOEYvZqVXXkDHCvJHHVVthqL P_0)
	{
		try
		{
			return P_0.tEDHkWhnncgdEqnOLjfbOlQRoucd();
		}
		catch
		{
			return false;
		}
	}

	private IList<foibGJXqBDBdLqGLpNATeBHsIxT> HiFgvZhvCfAjiayZhQfZhLXwkNpG()
	{
		return ZDlUxkUjsUcGKeLVqrQXLelAILc.GetJoysticks<foibGJXqBDBdLqGLpNATeBHsIxT>();
	}

	private void KTAwGzsoAsHiEgQlJqUIcwdlEjt(int P_0, int P_1, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_2, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(pbvCkoktDJLPiAKikqPXHkvMIHZe.QbfUhzJwpGHfcGNVphgCnDnrtWf);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
			UcQYDPRULynzQPJTWpMsBpLjdRDD(P_1, P_3, P_0, P_2, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu.HoUDpKToZAvYvTCsbfaQUrQsFTC);
		}
		YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu.bsEuTteZfWpGGkkWfgFWdtTyWHGw);
		YwWhsupQmPrVTdmbpVrereVcWSG(P_1, P_3, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu.HoUDpKToZAvYvTCsbfaQUrQsFTC);
		for (int i = 0; i < P_1; i++)
		{
			pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe2 = P_3[i];
			if (pbvCkoktDJLPiAKikqPXHkvMIHZe2 != null && pbvCkoktDJLPiAKikqPXHkvMIHZe2.inputManagerId < 0)
			{
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.inputManagerId = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_3);
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.rewiredId = aKvCUaiGXmdnbQBGdJPaRbbDQB();
				VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pbvCkoktDJLPiAKikqPXHkvMIHZe2);
			}
		}
		P_3.Sort(pbvCkoktDJLPiAKikqPXHkvMIHZe.GxDEXTomhoFUSPwniPKgVeysYnC);
	}

	private void nMzSzQRKRtEuNERWjNqyJJJAppk(List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_0, int P_1, int P_2)
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

	private bool jKMphJxbMbpySqxLEPdTKRZDSrn(List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_0, int P_1)
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

	private int pzcgaQeegHlaRneiNJuTAjkIvlfu(List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_0)
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

	private bool brHCphkOPMIyDMoTDxdDCAADyNA(List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_0, int P_1)
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

	private void UcQYDPRULynzQPJTWpMsBpLjdRDD(int P_0, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_1, int P_2, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_3, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu P_4)
	{
		int num = ((P_4 != XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu.bsEuTteZfWpGGkkWfgFWdtTyWHGw) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe2 = P_1[i];
			if (pbvCkoktDJLPiAKikqPXHkvMIHZe2 == null || pbvCkoktDJLPiAKikqPXHkvMIHZe2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe3 = P_3[j];
				if (pbvCkoktDJLPiAKikqPXHkvMIHZe3 != null && !brHCphkOPMIyDMoTDxdDCAADyNA(P_1, pbvCkoktDJLPiAKikqPXHkvMIHZe3.rewiredId) && pbvCkoktDJLPiAKikqPXHkvMIHZe2.QuyjPPVLYssrxnLbKpFVOFYkPay(pbvCkoktDJLPiAKikqPXHkvMIHZe3) >= num)
				{
					pbvCkoktDJLPiAKikqPXHkvMIHZe2.yVXFqVXzLlBDILgCcWPHxsSqcfA(pbvCkoktDJLPiAKikqPXHkvMIHZe3);
					VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pbvCkoktDJLPiAKikqPXHkvMIHZe2);
				}
			}
		}
	}

	private void YwWhsupQmPrVTdmbpVrereVcWSG(int P_0, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_1, XCwFydGRILHWLkEArWlpFxfKRKn.pOpXcwqGsoTkfFNyRCzWHgpVKNSu P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe2 = P_1[i];
			if (pbvCkoktDJLPiAKikqPXHkvMIHZe2 == null || pbvCkoktDJLPiAKikqPXHkvMIHZe2.inputManagerId >= 0)
			{
				continue;
			}
			XCwFydGRILHWLkEArWlpFxfKRKn.pjKgXsIZnkftWWFTBGpEbXvvTeRW pjKgXsIZnkftWWFTBGpEbXvvTeRW = null;
			foreach (XCwFydGRILHWLkEArWlpFxfKRKn.pjKgXsIZnkftWWFTBGpEbXvvTeRW item in VXRpRQGmBLUsrQikVDSFCugvidLN.afvWoBaYQAGDQJhLdAqXpRXzPls(pbvCkoktDJLPiAKikqPXHkvMIHZe2, P_2))
			{
				if (!brHCphkOPMIyDMoTDxdDCAADyNA(P_1, item.AVJCjGFlvmvUQprbQtbNLTqidXD) && item.SCvLuAiDgDtSaPnKtxXIaqXDocp >= 0)
				{
					pjKgXsIZnkftWWFTBGpEbXvvTeRW = item;
					break;
				}
			}
			if (pjKgXsIZnkftWWFTBGpEbXvvTeRW != null)
			{
				int num = pjKgXsIZnkftWWFTBGpEbXvvTeRW.SCvLuAiDgDtSaPnKtxXIaqXDocp;
				if (!jKMphJxbMbpySqxLEPdTKRZDSrn(P_1, num))
				{
					num = (pjKgXsIZnkftWWFTBGpEbXvvTeRW.SCvLuAiDgDtSaPnKtxXIaqXDocp = pzcgaQeegHlaRneiNJuTAjkIvlfu(P_1));
				}
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.inputManagerId = num;
				pbvCkoktDJLPiAKikqPXHkvMIHZe2.rewiredId = pjKgXsIZnkftWWFTBGpEbXvvTeRW.AVJCjGFlvmvUQprbQtbNLTqidXD;
				VXRpRQGmBLUsrQikVDSFCugvidLN.pNtVjMTCwjmfvmJXawLBYkfoTpi(pbvCkoktDJLPiAKikqPXHkvMIHZe2);
			}
		}
	}

	private void ECgcLnNOAxTzdoTYOgpcfwIQwLY()
	{
		IList<foibGJXqBDBdLqGLpNATeBHsIxT> list = HiFgvZhvCfAjiayZhQfZhLXwkNpG();
		OoDFaIeyrIrGfOQwdBnCiIvBbHRL(list);
		DWJnXrOBumpLFfmZPjflDMezshO = false;
	}

	private bool nfWiyuOsgLuucxCzCJgnyAtNTIQ(IList<foibGJXqBDBdLqGLpNATeBHsIxT> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !gRvZZvcutrVLUffkHWdvagmokAh(P_0[i].InstanceGuid))
			{
				return true;
			}
		}
		int count2 = GpKTUjLMGVeIHJzINAjLhtehdVC.Count;
		for (int j = 0; j < count2; j++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[j] != null && !DAzMgOgUJBAIsHBLwUuBuwCMSwQ(P_0, GpKTUjLMGVeIHJzINAjLhtehdVC[j].qBdzfLpHoqJBujyeJGIjMduWcWC))
			{
				return true;
			}
		}
		return false;
	}

	private bool gRvZZvcutrVLUffkHWdvagmokAh(Guid P_0)
	{
		int count = GpKTUjLMGVeIHJzINAjLhtehdVC.Count;
		for (int i = 0; i < count; i++)
		{
			if (GpKTUjLMGVeIHJzINAjLhtehdVC[i] != null && GpKTUjLMGVeIHJzINAjLhtehdVC[i].qBdzfLpHoqJBujyeJGIjMduWcWC == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool DAzMgOgUJBAIsHBLwUuBuwCMSwQ(IList<foibGJXqBDBdLqGLpNATeBHsIxT> P_0, Guid P_1)
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

	private void NLNETPIPcIzZWgQktmiidfjpSxOl(List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_0, List<pbvCkoktDJLPiAKikqPXHkvMIHZe> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe2 = P_0[i];
			if (pbvCkoktDJLPiAKikqPXHkvMIHZe2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					pbvCkoktDJLPiAKikqPXHkvMIHZe pbvCkoktDJLPiAKikqPXHkvMIHZe3 = P_1[j];
					if (pbvCkoktDJLPiAKikqPXHkvMIHZe3 != null && pbvCkoktDJLPiAKikqPXHkvMIHZe2.qBdzfLpHoqJBujyeJGIjMduWcWC == pbvCkoktDJLPiAKikqPXHkvMIHZe3.qBdzfLpHoqJBujyeJGIjMduWcWC)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				hKnWXzHpMEBnJfTFKLWhLmnAOHC(P_0[i], P_2);
			}
		}
	}

	private void hKnWXzHpMEBnJfTFKLWhLmnAOHC(pbvCkoktDJLPiAKikqPXHkvMIHZe P_0, bool P_1)
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

	private void PFsgcBAqudCMKvLgQUMNRnqFSqBm()
	{
		if (rTBZChsWvIMJDvQUVMrHNOniKIa)
		{
			DWJnXrOBumpLFfmZPjflDMezshO = true;
		}
		SystemDeviceConnected();
	}
}
