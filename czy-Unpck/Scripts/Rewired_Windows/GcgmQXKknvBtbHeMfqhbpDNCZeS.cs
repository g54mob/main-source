using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Utils;
using Rewired.Windows.RawInput;

internal abstract class GcgmQXKknvBtbHeMfqhbpDNCZeS : IDisposable, HjEeADgBkBgKtjfHEBuMcIVikmys
{
	protected OzVqfYeaMNEXzwFiuZOmGiQFiUf sytGWrBiDIPjFTtrstDtJIxSHoxH;

	protected readonly int FSZDNLfnbWTDRJISMAIVcCycwKdI;

	protected readonly int UnsidEuQENIGinwFoUsgQCktbcfb;

	protected readonly Guid azCpEufwSssraCFIfMKJQqzPyDg;

	protected readonly Guid duuMMyqFfJAeBAlnwwCpaWGlBUgO;

	protected readonly DeviceType LVLhbadscUPkcwrRwFZrFUurnFKj;

	protected readonly string yRYeNRhokbAmPiwsgbJAeXgBuzFD;

	protected HIDDeviceDriver bJxtiHguiHUEdRuXesZufkATccx;

	protected Controller.Extension LBshyzXbuGqZuOWTqSajtepZkED;

	private string HfwsftNlwTiXNUhbAIvhfxPuSXJ;

	private string lJOFUcCiViKMuIDwfcDKdvoFtTfD;

	private string EBMuSFcpguMGkMsIcAyPpxDLURQ;

	private bool mJrdlUkLynjELqIFaMgaOWoKjrO;

	private bool xnEgkJJgWvsscuMuckuNZgtXzNe;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public OzVqfYeaMNEXzwFiuZOmGiQFiUf HidDevice => sytGWrBiDIPjFTtrstDtJIxSHoxH;

	public string ProductName
	{
		get
		{
			if (!string.IsNullOrEmpty(HfwsftNlwTiXNUhbAIvhfxPuSXJ))
			{
				return HfwsftNlwTiXNUhbAIvhfxPuSXJ;
			}
			HfwsftNlwTiXNUhbAIvhfxPuSXJ = sytGWrBiDIPjFTtrstDtJIxSHoxH.yFxOGXcaegbEFjxkNZdqsTwHOBxe();
			if (string.IsNullOrEmpty(HfwsftNlwTiXNUhbAIvhfxPuSXJ))
			{
				HfwsftNlwTiXNUhbAIvhfxPuSXJ = "Unknown";
			}
			return HfwsftNlwTiXNUhbAIvhfxPuSXJ;
		}
	}

	public string Manufacturer
	{
		get
		{
			if (mJrdlUkLynjELqIFaMgaOWoKjrO)
			{
				goto IL_0008;
			}
			lJOFUcCiViKMuIDwfcDKdvoFtTfD = sytGWrBiDIPjFTtrstDtJIxSHoxH.qndLldKpjRqINyWyQhSIXAPjRbm();
			int num = 1876644371;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x6FDB5212)
			{
			case 0:
				break;
			case 2:
				return lJOFUcCiViKMuIDwfcDKdvoFtTfD;
			default:
				mJrdlUkLynjELqIFaMgaOWoKjrO = true;
				return lJOFUcCiViKMuIDwfcDKdvoFtTfD;
			}
			goto IL_0008;
			IL_0008:
			num = 1876644368;
			goto IL_000d;
		}
	}

	public int VendorId => FSZDNLfnbWTDRJISMAIVcCycwKdI;

	public int ProductId => UnsidEuQENIGinwFoUsgQCktbcfb;

	public Guid ProductGuid => azCpEufwSssraCFIfMKJQqzPyDg;

	public Guid InstanceGuid => duuMMyqFfJAeBAlnwwCpaWGlBUgO;

	public DeviceType DeviceType => LVLhbadscUPkcwrRwFZrFUurnFKj;

	public bool IsBluetoothDevice => sytGWrBiDIPjFTtrstDtJIxSHoxH.IsBluetoothDevice;

	public string BluetoothDeviceName => sytGWrBiDIPjFTtrstDtJIxSHoxH.BluetoothDeviceName;

	public string HWDefinitionMatchTag
	{
		get
		{
			if (xnEgkJJgWvsscuMuckuNZgtXzNe)
			{
				return EBMuSFcpguMGkMsIcAyPpxDLURQ;
			}
			EBMuSFcpguMGkMsIcAyPpxDLURQ = YdyMnIcwNBPdrenZBGWhZdOBHpZh.BBWmVDZLrNTNlSFMsavKfXDvmGqa(sytGWrBiDIPjFTtrstDtJIxSHoxH, azCpEufwSssraCFIfMKJQqzPyDg, ProductName, BluetoothDeviceName);
			xnEgkJJgWvsscuMuckuNZgtXzNe = true;
			return EBMuSFcpguMGkMsIcAyPpxDLURQ;
		}
	}

	public HIDDeviceDriver Driver => bJxtiHguiHUEdRuXesZufkATccx;

	public Controller.Extension ControllerExtension => LBshyzXbuGqZuOWTqSajtepZkED;

	public virtual bool IsValid => !inweGjIgYacXYohFlYRlpMFkgKMi;

	public GcgmQXKknvBtbHeMfqhbpDNCZeS(OzVqfYeaMNEXzwFiuZOmGiQFiUf hidDevice)
	{
		sytGWrBiDIPjFTtrstDtJIxSHoxH = hidDevice;
		LVLhbadscUPkcwrRwFZrFUurnFKj = zACuTSxQmDGyHRuMJsFNKDCbMeF((ushort)hidDevice.Capabilities.UsagePage, (ushort)hidDevice.Capabilities.Usage);
		FSZDNLfnbWTDRJISMAIVcCycwKdI = hidDevice.Attributes.VendorId;
		UnsidEuQENIGinwFoUsgQCktbcfb = hidDevice.Attributes.ProductId;
		yRYeNRhokbAmPiwsgbJAeXgBuzFD = hidDevice.NYcwJindAhRkFWwnCqKYYgxzixr();
		azCpEufwSssraCFIfMKJQqzPyDg = MiscTools.CreateHIDProductGuid(FSZDNLfnbWTDRJISMAIVcCycwKdI, UnsidEuQENIGinwFoUsgQCktbcfb);
		duuMMyqFfJAeBAlnwwCpaWGlBUgO = MiscTools.CreateGuidHashSHA1(sytGWrBiDIPjFTtrstDtJIxSHoxH.InstanceId);
	}

	public virtual void FFYEDujhZPZIRSsDbLkeXQkxTZI(UpdateLoopType P_0)
	{
		if (bJxtiHguiHUEdRuXesZufkATccx != null)
		{
			bJxtiHguiHUEdRuXesZufkATccx.Update(P_0);
		}
	}

	void HjEeADgBkBgKtjfHEBuMcIVikmys.FFYEDujhZPZIRSsDbLkeXQkxTZI(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFYEDujhZPZIRSsDbLkeXQkxTZI
		this.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
	}

	public abstract void fHvlAyzcxwcbEJYkeBnphlWsGSD();

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~GcgmQXKknvBtbHeMfqhbpDNCZeS()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		while (P_0)
		{
			int num;
			int num2;
			if (bJxtiHguiHUEdRuXesZufkATccx == null)
			{
				num = 424456870;
				num2 = num;
			}
			else
			{
				num = 424456868;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x194CB2A5)
				{
				case 0:
					num = 424456865;
					continue;
				case 4:
					break;
				case 3:
					if (sytGWrBiDIPjFTtrstDtJIxSHoxH != null)
					{
						sytGWrBiDIPjFTtrstDtJIxSHoxH.Dispose();
						num = 424456871;
						continue;
					}
					goto end_IL_002f;
				case 1:
					bJxtiHguiHUEdRuXesZufkATccx.Dispose();
					num = 424456870;
					continue;
				default:
					goto end_IL_002f;
				}
				break;
			}
			continue;
			end_IL_002f:
			break;
		}
		inweGjIgYacXYohFlYRlpMFkgKMi = true;
	}

	private static DeviceType zACuTSxQmDGyHRuMJsFNKDCbMeF(ushort P_0, ushort P_1)
	{
		if (P_0 != 1)
		{
			return DeviceType.Unknown;
		}
		switch (P_1)
		{
		case 4:
			return DeviceType.Joystick;
		case 5:
			return DeviceType.Gamepad;
		case 6:
			return DeviceType.Keyboard;
		case 2:
			return DeviceType.Mouse;
		case 8:
			return DeviceType.MultiAxisController;
		default:
			return DeviceType.Unknown;
		}
	}

	public abstract void HyqAXbAgFcqWiYfxZzBDTyqsqlp();

	public abstract void UWOOMlZOWZtWbNikUvqswMufgfx();

	public abstract bool cFCFOdaTTBYIltMLsjQtdfmoKqE();
}
