using System;
using Rewired;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Utils;

internal class rtJOzXjwulRDsZLuifHOdxmwsVQ : RvZISYIDPdXRXmkDKoxbOaBOekr, IDisposable, MdvOMMNxWfcPHdPxtxTUTmquguI, KchbyaIpiOUwIuFRWQOhqCekrdI
{
	private int jJuFRouHLXZtvSzAbLNpJgYsIkN;

	private yOsYsEkRiyFUYfUQFHVYzKDYlZb ywAdlZerzvhjomUtiPfdBHUVlVAW;

	private IntPtr FKFCDRHciUKlpUrPiLCVBUVisTSX;

	private ButtonLoopSet TuFFmTLprqCiXduGufgYHxdRxUWF;

	private wLwPITJheYTdSwSdyTnuOtXwpVJ[] HYwiUYFvYYkzEpgTVdCDHUvfsSkO;

	private QKXAlowNpmmkcCKidMLBxmsteVme[] OjJKqUMsfxiYzmmsuqjuPDFHfQC;

	private int[] kheuUYshhWmkBBeTnbFEavsKTpm;

	private HIDAccelerometer[] eNWjKWbSdXeoYyGhZHvCFQbXiNT;

	private HIDGyroscope[] qXlQeNUiEhjxFGHeJNIMqwptBUCB;

	private HIDTouchpad[] BaaGRuZTEuHCAfqQuLtoQeZcFJk;

	private int fnovMDLsEFplBmyRxsHQABHgwLo;

	private int HWPhRUBGpEkhsZTLpibRoPcmWoP;

	private int OGsDSjMgyzLabiqTmDPbFAExdrN;

	private int eVYhhASIeUmjSBqOqXFtcmLIieEJ;

	private int tfpexPtfwrmyTgItHifkxhIBNrA;

	private int vvuccUHpSWetXWfEYPaeKeGKpqZP;

	private HidOutputReportHandler OgsmvyoUzvRriNbCBucDNEmBgVg;

	private iPRBYFToZLwSXJOnSrvnRmHihEH ztnrVvFJWkzbWlGiubEAOgmwEDV;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public int JoystickId
	{
		get
		{
			return jJuFRouHLXZtvSzAbLNpJgYsIkN;
		}
	}

	public yOsYsEkRiyFUYfUQFHVYzKDYlZb JoystickSourceType
	{
		get
		{
			return ywAdlZerzvhjomUtiPfdBHUVlVAW;
		}
	}

	public IntPtr JoystickSourceHandle
	{
		get
		{
			return FKFCDRHciUKlpUrPiLCVBUVisTSX;
		}
	}

	public bool[] Buttons
	{
		get
		{
			return TuFFmTLprqCiXduGufgYHxdRxUWF.Current.effectiveValue;
		}
	}

	public int[] HatValues
	{
		get
		{
			return kheuUYshhWmkBBeTnbFEavsKTpm;
		}
	}

	public int ButtonCount
	{
		get
		{
			return fnovMDLsEFplBmyRxsHQABHgwLo;
		}
	}

	public int AxisCount
	{
		get
		{
			return HWPhRUBGpEkhsZTLpibRoPcmWoP;
		}
	}

	public int HatCount
	{
		get
		{
			return OGsDSjMgyzLabiqTmDPbFAExdrN;
		}
	}

	public bool HasElements
	{
		get
		{
			if (fnovMDLsEFplBmyRxsHQABHgwLo <= 0)
			{
				while (true)
				{
					int num = 1310889018;
					while (true)
					{
						switch (num ^ 0x4E22943B)
						{
						case 2:
							break;
						case 1:
							goto IL_0027;
						default:
							return OGsDSjMgyzLabiqTmDPbFAExdrN > 0;
						}
						break;
						IL_0027:
						if (HWPhRUBGpEkhsZTLpibRoPcmWoP > 0)
						{
							goto end_IL_0009;
						}
						num = 1310889019;
					}
					continue;
					end_IL_0009:
					break;
				}
			}
			return true;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			if (gBGkpOgtWdAkRVNCGcbgdqBFpkZx == null)
			{
				return false;
			}
			return gBGkpOgtWdAkRVNCGcbgdqBFpkZx.VibrationMotorCount > 0;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			if (gBGkpOgtWdAkRVNCGcbgdqBFpkZx == null)
			{
				return 0;
			}
			return gBGkpOgtWdAkRVNCGcbgdqBFpkZx.VibrationMotorCount;
		}
	}

	public InputSource InputSource
	{
		get
		{
			return InputSource.InternalDriver;
		}
	}

	public HidOutputReportHandler HidOutputReportHandler
	{
		get
		{
			return OgsmvyoUzvRriNbCBucDNEmBgVg;
		}
	}

	public pORaxzeTYCRZPbhHycQGjGqbCdL AxesState
	{
		get
		{
			return ztnrVvFJWkzbWlGiubEAOgmwEDV;
		}
	}

	public rtJOzXjwulRDsZLuifHOdxmwsVQ(int joystickId, yOsYsEkRiyFUYfUQFHVYzKDYlZb joystickSourceType, IntPtr joystickSourceHandle, bUiVDUOAHpFECnWVzgHAGOUkHLxZ hidDevice, HIDDeviceDriver driver, HidOutputReportHandler hidOutputReportHandler)
		: base(hidDevice)
	{
		gBGkpOgtWdAkRVNCGcbgdqBFpkZx = driver;
		OgsmvyoUzvRriNbCBucDNEmBgVg = hidOutputReportHandler;
		if (gBGkpOgtWdAkRVNCGcbgdqBFpkZx != null)
		{
			QURffhTVTmAKnOacQXBuiiPLVku = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.CreateControllerExtension();
		}
		jJuFRouHLXZtvSzAbLNpJgYsIkN = joystickId;
		ywAdlZerzvhjomUtiPfdBHUVlVAW = joystickSourceType;
		FKFCDRHciUKlpUrPiLCVBUVisTSX = joystickSourceHandle;
		ztnrVvFJWkzbWlGiubEAOgmwEDV = new iPRBYFToZLwSXJOnSrvnRmHihEH();
		HkGTsRlFpKINjbEipXgmvkyXnYsS();
		ztnrVvFJWkzbWlGiubEAOgmwEDV.Finish();
	}

	public override void Update(UpdateLoopType P_0)
	{
		base.Update(P_0);
		TuFFmTLprqCiXduGufgYHxdRxUWF.SetUpdateLoop(P_0);
		int num = 0;
		while (true)
		{
			int num2 = -2050759540;
			while (true)
			{
				switch (num2 ^ -2050759538)
				{
				case 0:
					break;
				case 2:
					num2 = -2050759537;
					continue;
				case 3:
					qXlQeNUiEhjxFGHeJNIMqwptBUCB[num].Update(P_0);
					num++;
					num2 = -2050759537;
					continue;
				default:
					if (num >= tfpexPtfwrmyTgItHifkxhIBNrA)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	public override void UpdateFinished()
	{
		TuFFmTLprqCiXduGufgYHxdRxUWF.Current.ClearWasTrueThisFrame();
	}

	public void UpdateValue(IntPtr P_0, int P_1, int P_2, int P_3, float P_4)
	{
		if (P_1 > 0)
		{
			gBGkpOgtWdAkRVNCGcbgdqBFpkZx.ParseInputReport(P_0, P_1, P_4);
			ntHkZnBwItpIoEGMjrBEabLTXFJ();
			QwjbBaCiqpyATADIBvDzRnxExBKA();
			GoSulUtzkBjwaTdVHkaXkdTAhyO();
		}
	}

	public override void Acquire()
	{
	}

	public override void Unacquire()
	{
	}

	public override bool IsAttached()
	{
		return nrCaOgcYlgmLhdXZQBObPMACAeRA.IsConnected;
	}

	public void SetJoystickId(int P_0)
	{
		jJuFRouHLXZtvSzAbLNpJgYsIkN = P_0;
	}

	public void SetJoystickSourceHandle(IntPtr P_0)
	{
		FKFCDRHciUKlpUrPiLCVBUVisTSX = P_0;
	}

	private void HkGTsRlFpKINjbEipXgmvkyXnYsS()
	{
		fnovMDLsEFplBmyRxsHQABHgwLo = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.ButtonCount;
		HWPhRUBGpEkhsZTLpibRoPcmWoP = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.AxisCount;
		OGsDSjMgyzLabiqTmDPbFAExdrN = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.HatCount;
		eVYhhASIeUmjSBqOqXFtcmLIieEJ = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.AccelerometerCount;
		int num5 = default(int);
		int num4 = default(int);
		int num2 = default(int);
		int num3 = default(int);
		while (true)
		{
			int num = -1605422650;
			while (true)
			{
				switch (num ^ -1605422642)
				{
				case 14:
					break;
				default:
					return;
				case 5:
				{
					int num8;
					if (num5 < HWPhRUBGpEkhsZTLpibRoPcmWoP)
					{
						num = -1605422647;
						num8 = num;
					}
					else
					{
						num = -1605422646;
						num8 = num;
					}
					continue;
				}
				case 11:
					TuFFmTLprqCiXduGufgYHxdRxUWF = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, fnovMDLsEFplBmyRxsHQABHgwLo);
					num = -1605422655;
					continue;
				case 3:
					ztnrVvFJWkzbWlGiubEAOgmwEDV.AddAxis(HYwiUYFvYYkzEpgTVdCDHUvfsSkO[num5]);
					num5++;
					num = -1605422645;
					continue;
				case 15:
					HYwiUYFvYYkzEpgTVdCDHUvfsSkO = new wLwPITJheYTdSwSdyTnuOtXwpVJ[HWPhRUBGpEkhsZTLpibRoPcmWoP];
					OjJKqUMsfxiYzmmsuqjuPDFHfQC = new QKXAlowNpmmkcCKidMLBxmsteVme[OGsDSjMgyzLabiqTmDPbFAExdrN];
					kheuUYshhWmkBBeTnbFEavsKTpm = new int[OGsDSjMgyzLabiqTmDPbFAExdrN];
					ArrayTools.Fill(kheuUYshhWmkBBeTnbFEavsKTpm, -1);
					eNWjKWbSdXeoYyGhZHvCFQbXiNT = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.accelerometers;
					qXlQeNUiEhjxFGHeJNIMqwptBUCB = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.gyroscopes;
					BaaGRuZTEuHCAfqQuLtoQeZcFJk = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.touchpads;
					num5 = 0;
					num = -1605422645;
					continue;
				case 1:
					num4++;
					num = -1605422642;
					continue;
				case 10:
					num4 = 0;
					num = -1605422642;
					continue;
				case 9:
				{
					int num7;
					if (num2 >= eVYhhASIeUmjSBqOqXFtcmLIieEJ)
					{
						num = -1605422652;
						num7 = num;
					}
					else
					{
						num = -1605422648;
						num7 = num;
					}
					continue;
				}
				case 0:
				{
					int num6;
					if (num4 < tfpexPtfwrmyTgItHifkxhIBNrA)
					{
						num = -1605422641;
						num6 = num;
					}
					else
					{
						num = -1605422644;
						num6 = num;
					}
					continue;
				}
				case 4:
					num3 = 0;
					num = -1605422653;
					continue;
				case 12:
					OjJKqUMsfxiYzmmsuqjuPDFHfQC[num3] = HUztRxZKLHkSlafKVNWqCCzwBDoF(gBGkpOgtWdAkRVNCGcbgdqBFpkZx.hats[num3]);
					num3++;
					num = -1605422653;
					continue;
				case 7:
					HYwiUYFvYYkzEpgTVdCDHUvfsSkO[num5] = vDhjmokUhvijquEkbiPhxsfllLT(gBGkpOgtWdAkRVNCGcbgdqBFpkZx.axes[num5]);
					num = -1605422643;
					continue;
				case 13:
					if (num3 >= OGsDSjMgyzLabiqTmDPbFAExdrN)
					{
						num2 = 0;
						num = -1605422649;
						continue;
					}
					goto case 12;
				case 8:
					tfpexPtfwrmyTgItHifkxhIBNrA = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.GyroscopeCount;
					vvuccUHpSWetXWfEYPaeKeGKpqZP = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.TouchpadCount;
					num = -1605422651;
					continue;
				case 6:
					num2++;
					num = -1605422649;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void ntHkZnBwItpIoEGMjrBEabLTXFJ()
	{
		if (fnovMDLsEFplBmyRxsHQABHgwLo == 0)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			HIDButton[] buttons = gBGkpOgtWdAkRVNCGcbgdqBFpkZx.buttons;
			int num = -1093566150;
			while (true)
			{
				switch (num ^ -1093566149)
				{
				case 0:
					num = -1093566151;
					continue;
				default:
					return;
				case 3:
					TuFFmTLprqCiXduGufgYHxdRxUWF.SetValue(num2, buttons[num2].rawValue, buttons[num2].timestamp);
					num2++;
					num = -1093566145;
					continue;
				case 1:
					num2 = 0;
					num = -1093566145;
					continue;
				case 2:
					break;
				case 4:
				{
					int num3;
					if (num2 < fnovMDLsEFplBmyRxsHQABHgwLo)
					{
						num = -1093566152;
						num3 = num;
					}
					else
					{
						num = -1093566146;
						num3 = num;
					}
					continue;
				}
				case 5:
					return;
				}
				break;
			}
		}
	}

	private void GoSulUtzkBjwaTdVHkaXkdTAhyO()
	{
		if (OGsDSjMgyzLabiqTmDPbFAExdrN == 0)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -1454762368;
			while (true)
			{
				switch (num2 ^ -1454762368)
				{
				case 4:
					num2 = -1454762367;
					continue;
				case 1:
					break;
				case 3:
					OjJKqUMsfxiYzmmsuqjuPDFHfQC[num].wmSvsDuQKkgIZvbYXgCGTuPJLgF = (uint)gBGkpOgtWdAkRVNCGcbgdqBFpkZx.hats[num].rawValue;
					kheuUYshhWmkBBeTnbFEavsKTpm[num] = OjJKqUMsfxiYzmmsuqjuPDFHfQC[num].value;
					num++;
					num2 = -1454762366;
					continue;
				case 0:
					num2 = -1454762366;
					continue;
				default:
					if (num >= OGsDSjMgyzLabiqTmDPbFAExdrN)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	private void QwjbBaCiqpyATADIBvDzRnxExBKA()
	{
		if (HWPhRUBGpEkhsZTLpibRoPcmWoP == 0)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 1260346020;
			while (true)
			{
				switch (num2 ^ 0x4B1F5AA4)
				{
				case 3:
					num2 = 1260346021;
					continue;
				case 1:
					break;
				case 2:
					HYwiUYFvYYkzEpgTVdCDHUvfsSkO[num].wmSvsDuQKkgIZvbYXgCGTuPJLgF = (uint)gBGkpOgtWdAkRVNCGcbgdqBFpkZx.axes[num].rawValue;
					num++;
					num2 = 1260346020;
					continue;
				default:
					if (num >= HWPhRUBGpEkhsZTLpibRoPcmWoP)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private wLwPITJheYTdSwSdyTnuOtXwpVJ vDhjmokUhvijquEkbiPhxsfllLT(HIDAxis P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new wLwPITJheYTdSwSdyTnuOtXwpVJ(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0, GNFedjgvPcDOHkBgIivYujrHsRh.EEwfcDfapHJOrUcFVJDuPjrUpstR(P_0.hidInfo.usagePage, P_0.hidInfo.usage));
	}

	private QKXAlowNpmmkcCKidMLBxmsteVme HUztRxZKLHkSlafKVNWqCCzwBDoF(HIDHat P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new QKXAlowNpmmkcCKidMLBxmsteVme(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0);
	}

	protected override void Dispose(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			base.Dispose(P_0);
		}
	}
}
