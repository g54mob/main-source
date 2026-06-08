using System;
using Rewired;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Utils;

internal class mAktYGdXOBtSOXijAIoQcISyNuj : GcgmQXKknvBtbHeMfqhbpDNCZeS, IDisposable, HjEeADgBkBgKtjfHEBuMcIVikmys, TPOFglCEUenQueqhakDnrjLmVbgq
{
	private int cKPDljwnRzNZXUoCRSrnKbooovo;

	private dBNoePwdKYyWerGenDMKaakIaLZh dyxbnAjzLVfLEAIHKzylGxtNiBg;

	private IntPtr UewZHMmDSaJBTbPtMGXJBGkapJk;

	private ButtonLoopSet IcemUwJTsYEnRkkBQdYcgEaHCgc;

	private pyZQbMTATyVfguiHEyKaPAqwFRx[] IYJQDJJaOwLqqfhYvVTxBAFxUOn;

	private VlcbnxcqZYpAErUQBbOLTsTltHCc[] XIcuSXANVNnEPwACSNrgUSuPaSu;

	private int[] nuNriJcGFksYrVqbRwMMdjJQrpI;

	private HIDAccelerometer[] bmrszFjgBhBCqeWZzVySWDKRKXd;

	private HIDGyroscope[] rrKqxGAePBTgzVAqnZrYxSPbWam;

	private HIDTouchpad[] KsLuEnDUcCKzsjsuCEQeVZeaqBO;

	private int eHZGWCRkabPOlmhdTfYEHDwgrZW;

	private int QCginViHReoHGHDnVSaPpjTyOmfN;

	private int BUZrJkCpMVUxTkSfEcOdYxbtnrv;

	private int pWhhkXQOPiHIgHkZOSFhrowCqqq;

	private int anYvoSluBHGYdwnktpnmaNCDrFi;

	private int iWDciZvPkcrRpliuiXraroxIGevb;

	private HidOutputReportHandler HFHmifkRsXezMbLJhHvXLKHPoyI;

	private tWkKNCXIrnFwxZTVcetdQCqcJSr khKOnwRWrStHHfQuKSiKLfTcpGx;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public int JoystickId => cKPDljwnRzNZXUoCRSrnKbooovo;

	public dBNoePwdKYyWerGenDMKaakIaLZh JoystickSourceType => dyxbnAjzLVfLEAIHKzylGxtNiBg;

	public IntPtr JoystickSourceHandle => UewZHMmDSaJBTbPtMGXJBGkapJk;

	public bool[] Buttons => IcemUwJTsYEnRkkBQdYcgEaHCgc.Current.effectiveValue;

	public int[] HatValues => nuNriJcGFksYrVqbRwMMdjJQrpI;

	public int ButtonCount => eHZGWCRkabPOlmhdTfYEHDwgrZW;

	public int AxisCount => QCginViHReoHGHDnVSaPpjTyOmfN;

	public int HatCount => BUZrJkCpMVUxTkSfEcOdYxbtnrv;

	public bool HasElements
	{
		get
		{
			if (eHZGWCRkabPOlmhdTfYEHDwgrZW <= 0 && QCginViHReoHGHDnVSaPpjTyOmfN <= 0)
			{
				return BUZrJkCpMVUxTkSfEcOdYxbtnrv > 0;
			}
			return true;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			if (bJxtiHguiHUEdRuXesZufkATccx == null)
			{
				return false;
			}
			return bJxtiHguiHUEdRuXesZufkATccx.VibrationMotorCount > 0;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			if (bJxtiHguiHUEdRuXesZufkATccx == null)
			{
				return 0;
			}
			return bJxtiHguiHUEdRuXesZufkATccx.VibrationMotorCount;
		}
	}

	public InputSource InputSource => InputSource.InternalDriver;

	public HidOutputReportHandler HidOutputReportHandler => HFHmifkRsXezMbLJhHvXLKHPoyI;

	public gjqxeaurskCrrKdTQKtANktjOGhz AxesState => khKOnwRWrStHHfQuKSiKLfTcpGx;

	public mAktYGdXOBtSOXijAIoQcISyNuj(int joystickId, dBNoePwdKYyWerGenDMKaakIaLZh joystickSourceType, IntPtr joystickSourceHandle, OzVqfYeaMNEXzwFiuZOmGiQFiUf hidDevice, HIDDeviceDriver driver, HidOutputReportHandler hidOutputReportHandler)
		: base(hidDevice)
	{
		bJxtiHguiHUEdRuXesZufkATccx = driver;
		HFHmifkRsXezMbLJhHvXLKHPoyI = hidOutputReportHandler;
		if (bJxtiHguiHUEdRuXesZufkATccx != null)
		{
			LBshyzXbuGqZuOWTqSajtepZkED = bJxtiHguiHUEdRuXesZufkATccx.CreateControllerExtension();
		}
		cKPDljwnRzNZXUoCRSrnKbooovo = joystickId;
		dyxbnAjzLVfLEAIHKzylGxtNiBg = joystickSourceType;
		UewZHMmDSaJBTbPtMGXJBGkapJk = joystickSourceHandle;
		khKOnwRWrStHHfQuKSiKLfTcpGx = new tWkKNCXIrnFwxZTVcetdQCqcJSr();
		KKfwsYfLVspEBOSCVdqoxzVFSGC();
		khKOnwRWrStHHfQuKSiKLfTcpGx.MMUwIhsISnTbkkxIVKgbRXyiSqf();
	}

	public override void FFYEDujhZPZIRSsDbLkeXQkxTZI(UpdateLoopType P_0)
	{
		base.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
		int num2 = default(int);
		while (true)
		{
			int num = -1194656514;
			while (true)
			{
				switch (num ^ -1194656517)
				{
				case 0:
					break;
				case 2:
					num2++;
					num = -1194656520;
					continue;
				case 1:
					rrKqxGAePBTgzVAqnZrYxSPbWam[num2].Update(P_0);
					num = -1194656519;
					continue;
				case 4:
					num2 = 0;
					num = -1194656520;
					continue;
				case 5:
					IcemUwJTsYEnRkkBQdYcgEaHCgc.SetUpdateLoop(P_0);
					num = -1194656513;
					continue;
				default:
					if (num2 >= anYvoSluBHGYdwnktpnmaNCDrFi)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	void HjEeADgBkBgKtjfHEBuMcIVikmys.FFYEDujhZPZIRSsDbLkeXQkxTZI(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFYEDujhZPZIRSsDbLkeXQkxTZI
		this.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
	}

	public override void fHvlAyzcxwcbEJYkeBnphlWsGSD()
	{
		IcemUwJTsYEnRkkBQdYcgEaHCgc.Current.ClearWasTrueThisFrame();
	}

	void HjEeADgBkBgKtjfHEBuMcIVikmys.fHvlAyzcxwcbEJYkeBnphlWsGSD()
	{
		//ILSpy generated this explicit interface implementation from .override directive in fHvlAyzcxwcbEJYkeBnphlWsGSD
		this.fHvlAyzcxwcbEJYkeBnphlWsGSD();
	}

	public void GUXOVkFRBjCKbujBlYXzZnxHnTZ(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		if (P_1 <= 0)
		{
			goto IL_0004;
		}
		goto IL_0032;
		IL_0004:
		int num = -1824701740;
		goto IL_0009;
		IL_0009:
		while (true)
		{
			switch (num ^ -1824701744)
			{
			case 2:
				break;
			default:
				return;
			case 4:
				return;
			case 3:
				goto IL_0032;
			case 0:
				aGwDgiXyNNqhCEqcVEYQleQFBPn();
				TcQALxknWBDsjjDgfcKnpyWUiBqK();
				DUpIcmfmFlBZCdXBpsdkNdEGpzYz();
				num = -1824701743;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_0004;
		IL_0032:
		bJxtiHguiHUEdRuXesZufkATccx.ParseInputReport(P_0, P_1, P_4);
		num = -1824701744;
		goto IL_0009;
	}

	void TPOFglCEUenQueqhakDnrjLmVbgq.GUXOVkFRBjCKbujBlYXzZnxHnTZ(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GUXOVkFRBjCKbujBlYXzZnxHnTZ
		this.GUXOVkFRBjCKbujBlYXzZnxHnTZ(P_0, P_1, P_2, P_3, P_4);
	}

	public override void HyqAXbAgFcqWiYfxZzBDTyqsqlp()
	{
	}

	void HjEeADgBkBgKtjfHEBuMcIVikmys.HyqAXbAgFcqWiYfxZzBDTyqsqlp()
	{
		//ILSpy generated this explicit interface implementation from .override directive in HyqAXbAgFcqWiYfxZzBDTyqsqlp
		this.HyqAXbAgFcqWiYfxZzBDTyqsqlp();
	}

	public override void UWOOMlZOWZtWbNikUvqswMufgfx()
	{
	}

	void HjEeADgBkBgKtjfHEBuMcIVikmys.UWOOMlZOWZtWbNikUvqswMufgfx()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UWOOMlZOWZtWbNikUvqswMufgfx
		this.UWOOMlZOWZtWbNikUvqswMufgfx();
	}

	public override bool cFCFOdaTTBYIltMLsjQtdfmoKqE()
	{
		return sytGWrBiDIPjFTtrstDtJIxSHoxH.IsConnected;
	}

	bool HjEeADgBkBgKtjfHEBuMcIVikmys.cFCFOdaTTBYIltMLsjQtdfmoKqE()
	{
		//ILSpy generated this explicit interface implementation from .override directive in cFCFOdaTTBYIltMLsjQtdfmoKqE
		return this.cFCFOdaTTBYIltMLsjQtdfmoKqE();
	}

	public void bGLkBDHnpemvyBRWVRTaJLBCCpw(int P_0)
	{
		cKPDljwnRzNZXUoCRSrnKbooovo = P_0;
	}

	void TPOFglCEUenQueqhakDnrjLmVbgq.bGLkBDHnpemvyBRWVRTaJLBCCpw(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in bGLkBDHnpemvyBRWVRTaJLBCCpw
		this.bGLkBDHnpemvyBRWVRTaJLBCCpw(P_0);
	}

	public void YiOIgfGkkpPDYepmwZfBIvBxhXC(IntPtr P_0)
	{
		UewZHMmDSaJBTbPtMGXJBGkapJk = P_0;
	}

	void TPOFglCEUenQueqhakDnrjLmVbgq.YiOIgfGkkpPDYepmwZfBIvBxhXC(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YiOIgfGkkpPDYepmwZfBIvBxhXC
		this.YiOIgfGkkpPDYepmwZfBIvBxhXC(P_0);
	}

	private void KKfwsYfLVspEBOSCVdqoxzVFSGC()
	{
		eHZGWCRkabPOlmhdTfYEHDwgrZW = bJxtiHguiHUEdRuXesZufkATccx.ButtonCount;
		int num5 = default(int);
		int num2 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			int num = 138784890;
			while (true)
			{
				switch (num ^ 0x845B070)
				{
				case 11:
					break;
				case 9:
					if (num5 >= pWhhkXQOPiHIgHkZOSFhrowCqqq)
					{
						num2 = 0;
						num = 138784881;
						continue;
					}
					goto case 14;
				case 6:
					num = 138784887;
					continue;
				case 8:
					IYJQDJJaOwLqqfhYvVTxBAFxUOn[num3] = qkSopxkYsLSxOszeDtTniOVhvjz(bJxtiHguiHUEdRuXesZufkATccx.axes[num3]);
					khKOnwRWrStHHfQuKSiKLfTcpGx.sSTehkbZdOwHeleDDlmiNnnpynDk(IYJQDJJaOwLqqfhYvVTxBAFxUOn[num3]);
					num3++;
					num = 138784887;
					continue;
				case 14:
					num5++;
					num = 138784889;
					continue;
				case 3:
					anYvoSluBHGYdwnktpnmaNCDrFi = bJxtiHguiHUEdRuXesZufkATccx.GyroscopeCount;
					iWDciZvPkcrRpliuiXraroxIGevb = bJxtiHguiHUEdRuXesZufkATccx.TouchpadCount;
					IcemUwJTsYEnRkkBQdYcgEaHCgc = new ButtonLoopSet(ReInput.configVars.updateLoop, eHZGWCRkabPOlmhdTfYEHDwgrZW);
					IYJQDJJaOwLqqfhYvVTxBAFxUOn = new pyZQbMTATyVfguiHEyKaPAqwFRx[QCginViHReoHGHDnVSaPpjTyOmfN];
					XIcuSXANVNnEPwACSNrgUSuPaSu = new VlcbnxcqZYpAErUQBbOLTsTltHCc[BUZrJkCpMVUxTkSfEcOdYxbtnrv];
					nuNriJcGFksYrVqbRwMMdjJQrpI = new int[BUZrJkCpMVUxTkSfEcOdYxbtnrv];
					num = 138784893;
					continue;
				case 0:
					XIcuSXANVNnEPwACSNrgUSuPaSu[num4] = ACOBiwBodtirVkNkxVlkDfAmdDE(bJxtiHguiHUEdRuXesZufkATccx.hats[num4]);
					num4++;
					num = 138784885;
					continue;
				case 4:
					num2++;
					num = 138784892;
					continue;
				case 5:
					if (num4 >= BUZrJkCpMVUxTkSfEcOdYxbtnrv)
					{
						num5 = 0;
						num = 138784882;
						continue;
					}
					goto case 0;
				case 7:
					if (num3 >= QCginViHReoHGHDnVSaPpjTyOmfN)
					{
						num4 = 0;
						num = 138784885;
						continue;
					}
					goto case 8;
				case 1:
					num = 138784892;
					continue;
				case 10:
					QCginViHReoHGHDnVSaPpjTyOmfN = bJxtiHguiHUEdRuXesZufkATccx.AxisCount;
					BUZrJkCpMVUxTkSfEcOdYxbtnrv = bJxtiHguiHUEdRuXesZufkATccx.HatCount;
					pWhhkXQOPiHIgHkZOSFhrowCqqq = bJxtiHguiHUEdRuXesZufkATccx.AccelerometerCount;
					num = 138784883;
					continue;
				case 13:
					ArrayTools.Fill(nuNriJcGFksYrVqbRwMMdjJQrpI, -1);
					bmrszFjgBhBCqeWZzVySWDKRKXd = bJxtiHguiHUEdRuXesZufkATccx.accelerometers;
					rrKqxGAePBTgzVAqnZrYxSPbWam = bJxtiHguiHUEdRuXesZufkATccx.gyroscopes;
					KsLuEnDUcCKzsjsuCEQeVZeaqBO = bJxtiHguiHUEdRuXesZufkATccx.touchpads;
					num3 = 0;
					num = 138784886;
					continue;
				case 2:
					num = 138784889;
					continue;
				default:
					if (num2 >= anYvoSluBHGYdwnktpnmaNCDrFi)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private void aGwDgiXyNNqhCEqcVEYQleQFBPn()
	{
		if (eHZGWCRkabPOlmhdTfYEHDwgrZW == 0)
		{
			goto IL_0008;
		}
		goto IL_003d;
		IL_0008:
		int num = 2035268579;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		HIDButton[] buttons = default(HIDButton[]);
		while (true)
		{
			switch (num ^ 0x794FBBE0)
			{
			case 2:
				break;
			case 5:
				num2++;
				num = 2035268576;
				continue;
			case 4:
				goto IL_003d;
			case 1:
				IcemUwJTsYEnRkkBQdYcgEaHCgc.SetValue(num2, buttons[num2].rawValue, buttons[num2].timestamp);
				num = 2035268581;
				continue;
			case 3:
				return;
			default:
				if (num2 >= eHZGWCRkabPOlmhdTfYEHDwgrZW)
				{
					return;
				}
				goto case 1;
			}
			break;
		}
		goto IL_0008;
		IL_003d:
		buttons = bJxtiHguiHUEdRuXesZufkATccx.buttons;
		num2 = 0;
		num = 2035268576;
		goto IL_000d;
	}

	private void DUpIcmfmFlBZCdXBpsdkNdEGpzYz()
	{
		if (BUZrJkCpMVUxTkSfEcOdYxbtnrv == 0)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = -773919297;
			while (true)
			{
				switch (num2 ^ -773919300)
				{
				case 0:
					num2 = -773919299;
					continue;
				case 2:
					XIcuSXANVNnEPwACSNrgUSuPaSu[num].lGpyvYcIyUaWjAtqbNROdSiPlaxt = (uint)bJxtiHguiHUEdRuXesZufkATccx.hats[num].rawValue;
					num2 = -773919304;
					continue;
				case 3:
					num2 = -773919303;
					continue;
				case 4:
					nuNriJcGFksYrVqbRwMMdjJQrpI[num] = XIcuSXANVNnEPwACSNrgUSuPaSu[num].value;
					num++;
					num2 = -773919303;
					continue;
				case 1:
					break;
				default:
					if (num >= BUZrJkCpMVUxTkSfEcOdYxbtnrv)
					{
						return;
					}
					goto case 2;
				}
				break;
			}
		}
	}

	private void TcQALxknWBDsjjDgfcKnpyWUiBqK()
	{
		if (QCginViHReoHGHDnVSaPpjTyOmfN == 0)
		{
			return;
		}
		while (true)
		{
			int num = 0;
			int num2 = 542138610;
			while (true)
			{
				switch (num2 ^ 0x205060F2)
				{
				case 3:
					num2 = 542138608;
					continue;
				case 2:
					break;
				case 1:
					IYJQDJJaOwLqqfhYvVTxBAFxUOn[num].lGpyvYcIyUaWjAtqbNROdSiPlaxt = (uint)bJxtiHguiHUEdRuXesZufkATccx.axes[num].rawValue;
					num++;
					num2 = 542138610;
					continue;
				default:
					if (num >= QCginViHReoHGHDnVSaPpjTyOmfN)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private pyZQbMTATyVfguiHEyKaPAqwFRx qkSopxkYsLSxOszeDtTniOVhvjz(HIDAxis P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new pyZQbMTATyVfguiHEyKaPAqwFRx(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0, RZiUqimtzQCfzsOYcVmYjWAZWPR.JlZbaUibXvecLakhnLIwZkEOVgBD(P_0.hidInfo.usagePage, P_0.hidInfo.usage));
	}

	private VlcbnxcqZYpAErUQBbOLTsTltHCc ACOBiwBodtirVkNkxVlkDfAmdDE(HIDHat P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new VlcbnxcqZYpAErUQBbOLTsTltHCc(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0);
	}

	protected override void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		while (true)
		{
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
			base.WYoEhOBxiSjIYKwbsCHdGOUBXDbi(P_0);
			int num = -243325885;
			while (true)
			{
				switch (num ^ -243325887)
				{
				case 0:
					goto IL_0009;
				default:
					return;
				case 1:
					break;
				case 2:
					return;
				}
				break;
				IL_0009:
				num = -243325888;
			}
		}
	}
}
