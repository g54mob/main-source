using System;
using Rewired;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Utils;

internal class bbhCXrFCupJGnHGvLurGZgdOxuXJ : BdxUZurZTBCvKbZYykyzTCqmsCo, IDisposable, CRXrBgggAdrpYwIPGGrSdEyGnoQt, IQFNbAfLsEWvVnPpdRQbxxyYJpW
{
	private int rJUIDSBdJFHyoXoaCbHxWSGEegZ;

	private iGRvmBZykBTTuGmotZKeBVybDl gCciBnCHrpeGpFCBRHzxSBKvjLE;

	private IntPtr HevKLtZBqOengondROkZXMZYLbO;

	private ButtonLoopSet ZWfxdvsXfgrTIlWsTsMGkehnaWQ;

	private ajUREtsgqMboTruDDhvoVRJAART[] XYCXGmuQIKcJBcjvieCXLYtRbIs;

	private GdbsuUDypqSdpDKGWLJDomgHxLk[] IIdKFwfLfjBhgjxSFjyuQlBjMUQ;

	private int[] wmEEzegBrCStOQQjWYZMndwwMvsY;

	private HIDAccelerometer[] seaJksWTxJlQNzGJggnCAXvfUBJ;

	private HIDGyroscope[] qVTlibtiYjcJKUyOiIsKlvhTGtC;

	private HIDTouchpad[] JyGHTSwGCaSWTmmmTPRiVbDIbNq;

	private int nzQPtryKaFyOknbFWLAdBHgWTek;

	private int DXxKouqjjQssbQXpGtWVtKuSwQL;

	private int AmCeEZjzerqWitVpRhZjANQXzdZ;

	private int gxembmptsAyGPWIqDbJplaHoQsY;

	private int xsRIvfYFvzFvAepyiDweyetxvLEr;

	private int lDWxWkWQtGqiSocFnwayfUNqyFN;

	private HidOutputReportHandler QHOEfIDPArsUbpAPcIkRDWcErycP;

	private czpJRhiNvNJyEOLAnzblSHTKOXZ zzRGoXaeFysgmEqiFkjKhHwBKCFa;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public int JoystickId
	{
		get
		{
			return rJUIDSBdJFHyoXoaCbHxWSGEegZ;
		}
	}

	public iGRvmBZykBTTuGmotZKeBVybDl JoystickSourceType
	{
		get
		{
			return gCciBnCHrpeGpFCBRHzxSBKvjLE;
		}
	}

	public IntPtr JoystickSourceHandle
	{
		get
		{
			return HevKLtZBqOengondROkZXMZYLbO;
		}
	}

	public bool[] Buttons
	{
		get
		{
			return ZWfxdvsXfgrTIlWsTsMGkehnaWQ.Current.effectiveValue;
		}
	}

	public int[] HatValues
	{
		get
		{
			return wmEEzegBrCStOQQjWYZMndwwMvsY;
		}
	}

	public int ButtonCount
	{
		get
		{
			return nzQPtryKaFyOknbFWLAdBHgWTek;
		}
	}

	public int AxisCount
	{
		get
		{
			return DXxKouqjjQssbQXpGtWVtKuSwQL;
		}
	}

	public int HatCount
	{
		get
		{
			return AmCeEZjzerqWitVpRhZjANQXzdZ;
		}
	}

	public bool HasElements
	{
		get
		{
			if (nzQPtryKaFyOknbFWLAdBHgWTek <= 0 && DXxKouqjjQssbQXpGtWVtKuSwQL <= 0)
			{
				return AmCeEZjzerqWitVpRhZjANQXzdZ > 0;
			}
			return true;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			if (sKccQcTMCpzjEQGijBfqlsHvtcP == null)
			{
				return false;
			}
			return sKccQcTMCpzjEQGijBfqlsHvtcP.VibrationMotorCount > 0;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			if (sKccQcTMCpzjEQGijBfqlsHvtcP == null)
			{
				return 0;
			}
			return sKccQcTMCpzjEQGijBfqlsHvtcP.VibrationMotorCount;
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
			return QHOEfIDPArsUbpAPcIkRDWcErycP;
		}
	}

	public tDbEfRBvKQKUUajRFFcUkaQZPWTt AxesState
	{
		get
		{
			return zzRGoXaeFysgmEqiFkjKhHwBKCFa;
		}
	}

	public bbhCXrFCupJGnHGvLurGZgdOxuXJ(int joystickId, iGRvmBZykBTTuGmotZKeBVybDl joystickSourceType, IntPtr joystickSourceHandle, hdKCmGlHttTBdcjeWBCjBOXCTjJ hidDevice, HIDDeviceDriver driver, HidOutputReportHandler hidOutputReportHandler)
		: base(hidDevice)
	{
		sKccQcTMCpzjEQGijBfqlsHvtcP = driver;
		QHOEfIDPArsUbpAPcIkRDWcErycP = hidOutputReportHandler;
		if (sKccQcTMCpzjEQGijBfqlsHvtcP != null)
		{
			GxryzPkvRgFXiLtGnPVwlFRrgKm = sKccQcTMCpzjEQGijBfqlsHvtcP.CreateControllerExtension();
		}
		rJUIDSBdJFHyoXoaCbHxWSGEegZ = joystickId;
		gCciBnCHrpeGpFCBRHzxSBKvjLE = joystickSourceType;
		HevKLtZBqOengondROkZXMZYLbO = joystickSourceHandle;
		zzRGoXaeFysgmEqiFkjKhHwBKCFa = new czpJRhiNvNJyEOLAnzblSHTKOXZ();
		TjunfxAbcCQYgXUpUmEkfeltEzo();
		zzRGoXaeFysgmEqiFkjKhHwBKCFa.Finish();
	}

	public override void Update(UpdateLoopType P_0)
	{
		base.Update(P_0);
		int num2 = default(int);
		while (true)
		{
			int num = -583662029;
			while (true)
			{
				switch (num ^ -583662031)
				{
				case 0:
					break;
				case 2:
					ZWfxdvsXfgrTIlWsTsMGkehnaWQ.SetUpdateLoop(P_0);
					num2 = 0;
					num = -583662030;
					continue;
				case 1:
					qVTlibtiYjcJKUyOiIsKlvhTGtC[num2].Update(P_0);
					num2++;
					num = -583662030;
					continue;
				default:
					if (num2 >= xsRIvfYFvzFvAepyiDweyetxvLEr)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public override void UpdateFinished()
	{
		ZWfxdvsXfgrTIlWsTsMGkehnaWQ.Current.ClearWasTrueThisFrame();
	}

	public void UpdateValue(IntPtr P_0, int P_1, int P_2, int P_3, float P_4)
	{
		if (P_1 <= 0)
		{
			return;
		}
		while (true)
		{
			sKccQcTMCpzjEQGijBfqlsHvtcP.ParseInputReport(P_0, P_1, P_4);
			int num = 1235967347;
			while (true)
			{
				switch (num ^ 0x49AB5D70)
				{
				case 0:
					num = 1235967349;
					continue;
				default:
					return;
				case 4:
					IsHEPGDcapJjIIIwabNlagrgYHK();
					num = 1235967345;
					continue;
				case 3:
					xEfKEFgwOpPyjRLoWJIEfoNdBYF();
					num = 1235967348;
					continue;
				case 1:
					MEaVhFQazLlyvQyNgcusdploinie();
					num = 1235967346;
					continue;
				case 5:
					break;
				case 2:
					return;
				}
				break;
			}
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
		return dDiORYZMrygMeGilpySloSKsIyVj.IsConnected;
	}

	public void SetJoystickId(int P_0)
	{
		rJUIDSBdJFHyoXoaCbHxWSGEegZ = P_0;
	}

	public void SetJoystickSourceHandle(IntPtr P_0)
	{
		HevKLtZBqOengondROkZXMZYLbO = P_0;
	}

	private void TjunfxAbcCQYgXUpUmEkfeltEzo()
	{
		nzQPtryKaFyOknbFWLAdBHgWTek = sKccQcTMCpzjEQGijBfqlsHvtcP.ButtonCount;
		DXxKouqjjQssbQXpGtWVtKuSwQL = sKccQcTMCpzjEQGijBfqlsHvtcP.AxisCount;
		AmCeEZjzerqWitVpRhZjANQXzdZ = sKccQcTMCpzjEQGijBfqlsHvtcP.HatCount;
		gxembmptsAyGPWIqDbJplaHoQsY = sKccQcTMCpzjEQGijBfqlsHvtcP.AccelerometerCount;
		xsRIvfYFvzFvAepyiDweyetxvLEr = sKccQcTMCpzjEQGijBfqlsHvtcP.GyroscopeCount;
		int num3 = default(int);
		int num6 = default(int);
		int num4 = default(int);
		int num2 = default(int);
		while (true)
		{
			int num = -47586780;
			while (true)
			{
				switch (num ^ -47586769)
				{
				case 5:
					break;
				case 3:
					XYCXGmuQIKcJBcjvieCXLYtRbIs[num3] = pvLEsQhZEnYjnThmYectryyHChJd(sKccQcTMCpzjEQGijBfqlsHvtcP.axes[num3]);
					zzRGoXaeFysgmEqiFkjKhHwBKCFa.AddAxis(XYCXGmuQIKcJBcjvieCXLYtRbIs[num3]);
					num = -47586776;
					continue;
				case 1:
					ZWfxdvsXfgrTIlWsTsMGkehnaWQ = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, nzQPtryKaFyOknbFWLAdBHgWTek);
					XYCXGmuQIKcJBcjvieCXLYtRbIs = new ajUREtsgqMboTruDDhvoVRJAART[DXxKouqjjQssbQXpGtWVtKuSwQL];
					num = -47586769;
					continue;
				case 2:
					if (num6 >= AmCeEZjzerqWitVpRhZjANQXzdZ)
					{
						num4 = 0;
						num = -47586781;
						continue;
					}
					goto case 13;
				case 0:
					IIdKFwfLfjBhgjxSFjyuQlBjMUQ = new GdbsuUDypqSdpDKGWLJDomgHxLk[AmCeEZjzerqWitVpRhZjANQXzdZ];
					wmEEzegBrCStOQQjWYZMndwwMvsY = new int[AmCeEZjzerqWitVpRhZjANQXzdZ];
					ArrayTools.Fill(wmEEzegBrCStOQQjWYZMndwwMvsY, -1);
					seaJksWTxJlQNzGJggnCAXvfUBJ = sKccQcTMCpzjEQGijBfqlsHvtcP.accelerometers;
					num = -47586773;
					continue;
				case 9:
					if (num3 >= DXxKouqjjQssbQXpGtWVtKuSwQL)
					{
						num6 = 0;
						num = -47586771;
						continue;
					}
					goto case 3;
				case 10:
					num4++;
					num = -47586781;
					continue;
				case 6:
					num = -47586777;
					continue;
				case 14:
					num2 = 0;
					num = -47586775;
					continue;
				case 13:
					IIdKFwfLfjBhgjxSFjyuQlBjMUQ[num6] = LRXGcZaDPDFMyziakWHyPlLMHiy(sKccQcTMCpzjEQGijBfqlsHvtcP.hats[num6]);
					num6++;
					num = -47586771;
					continue;
				case 11:
					lDWxWkWQtGqiSocFnwayfUNqyFN = sKccQcTMCpzjEQGijBfqlsHvtcP.TouchpadCount;
					num = -47586770;
					continue;
				case 12:
				{
					int num5;
					if (num4 < gxembmptsAyGPWIqDbJplaHoQsY)
					{
						num = -47586779;
						num5 = num;
					}
					else
					{
						num = -47586783;
						num5 = num;
					}
					continue;
				}
				case 15:
					num2++;
					num = -47586777;
					continue;
				case 7:
					num3++;
					num = -47586778;
					continue;
				case 4:
					qVTlibtiYjcJKUyOiIsKlvhTGtC = sKccQcTMCpzjEQGijBfqlsHvtcP.gyroscopes;
					JyGHTSwGCaSWTmmmTPRiVbDIbNq = sKccQcTMCpzjEQGijBfqlsHvtcP.touchpads;
					num3 = 0;
					num = -47586778;
					continue;
				default:
					if (num2 >= xsRIvfYFvzFvAepyiDweyetxvLEr)
					{
						return;
					}
					goto case 15;
				}
				break;
			}
		}
	}

	private void xEfKEFgwOpPyjRLoWJIEfoNdBYF()
	{
		if (nzQPtryKaFyOknbFWLAdBHgWTek == 0)
		{
			return;
		}
		while (true)
		{
			HIDButton[] buttons = sKccQcTMCpzjEQGijBfqlsHvtcP.buttons;
			int num = 0;
			int num2 = 1207545515;
			while (true)
			{
				switch (num2 ^ 0x47F9AEA8)
				{
				case 0:
					num2 = 1207545516;
					continue;
				default:
					return;
				case 4:
					break;
				case 1:
					ZWfxdvsXfgrTIlWsTsMGkehnaWQ.SetValue(num, buttons[num].rawValue, buttons[num].timestamp);
					num++;
					num2 = 1207545515;
					continue;
				case 3:
				{
					int num3;
					if (num >= nzQPtryKaFyOknbFWLAdBHgWTek)
					{
						num2 = 1207545514;
						num3 = num2;
					}
					else
					{
						num2 = 1207545513;
						num3 = num2;
					}
					continue;
				}
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void MEaVhFQazLlyvQyNgcusdploinie()
	{
		if (AmCeEZjzerqWitVpRhZjANQXzdZ == 0)
		{
			goto IL_0008;
		}
		goto IL_0084;
		IL_0008:
		int num = -1059212691;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1059212692)
			{
			case 5:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				IIdKFwfLfjBhgjxSFjyuQlBjMUQ[num2].slcDutVbWmJxSkNwoiIYAENfAsLd = (uint)sKccQcTMCpzjEQGijBfqlsHvtcP.hats[num2].rawValue;
				wmEEzegBrCStOQQjWYZMndwwMvsY[num2] = IIdKFwfLfjBhgjxSFjyuQlBjMUQ[num2].value;
				num2++;
				num = -1059212689;
				continue;
			case 0:
				num = -1059212689;
				continue;
			case 4:
				goto IL_0084;
			case 3:
				goto IL_008d;
			case 6:
				return;
			}
			break;
			IL_008d:
			int num3;
			if (num2 < AmCeEZjzerqWitVpRhZjANQXzdZ)
			{
				num = -1059212690;
				num3 = num;
			}
			else
			{
				num = -1059212694;
				num3 = num;
			}
		}
		goto IL_0008;
		IL_0084:
		num2 = 0;
		num = -1059212692;
		goto IL_000d;
	}

	private void IsHEPGDcapJjIIIwabNlagrgYHK()
	{
		if (DXxKouqjjQssbQXpGtWVtKuSwQL == 0)
		{
			goto IL_0008;
		}
		goto IL_0036;
		IL_0008:
		int num = -501435483;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -501435487)
			{
			case 2:
				break;
			case 4:
				return;
			case 0:
				goto IL_0036;
			case 3:
				XYCXGmuQIKcJBcjvieCXLYtRbIs[num2].slcDutVbWmJxSkNwoiIYAENfAsLd = (uint)sKccQcTMCpzjEQGijBfqlsHvtcP.axes[num2].rawValue;
				num2++;
				num = -501435488;
				continue;
			default:
				if (num2 >= DXxKouqjjQssbQXpGtWVtKuSwQL)
				{
					return;
				}
				goto case 3;
			}
			break;
		}
		goto IL_0008;
		IL_0036:
		num2 = 0;
		num = -501435488;
		goto IL_000d;
	}

	private ajUREtsgqMboTruDDhvoVRJAART pvLEsQhZEnYjnThmYectryyHChJd(HIDAxis P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new ajUREtsgqMboTruDDhvoVRJAART(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0, YzxJnJDUJemCSpIExExEhMbbJDhC.AJApadLBbBTGgrypwPocyJzsedj(P_0.hidInfo.usagePage, P_0.hidInfo.usage));
	}

	private GdbsuUDypqSdpDKGWLJDomgHxLk LRXGcZaDPDFMyziakWHyPlLMHiy(HIDHat P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new GdbsuUDypqSdpDKGWLJDomgHxLk(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0);
	}

	protected override void Dispose(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		while (true)
		{
			int num = -270643517;
			while (true)
			{
				switch (num ^ -270643519)
				{
				case 0:
					goto IL_0009;
				case 1:
					break;
				default:
					nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
					base.Dispose(P_0);
					return;
				}
				break;
				IL_0009:
				num = -270643520;
			}
		}
	}
}
