using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Utils;
using Rewired.Windows.RawInput;

internal abstract class RvZISYIDPdXRXmkDKoxbOaBOekr : IDisposable, MdvOMMNxWfcPHdPxtxTUTmquguI
{
	protected bUiVDUOAHpFECnWVzgHAGOUkHLxZ nrCaOgcYlgmLhdXZQBObPMACAeRA;

	protected readonly string YHtEuhFNXMbKXkXCmocUmoanfRXI;

	protected readonly string MOmYYKsovJJgBVPLtOSwtmMRAfgH;

	protected readonly int IsTHWbzBGcfzINmBcVjVFHKiALR;

	protected readonly int JRhfPemcldoYcpjKNjaKZBrYsJ;

	protected readonly Guid zZrGsvpcmUZZGGexHHzXZAxTZpG;

	protected readonly Guid cBDIfdqFvdWzxrFEMJqjLvTvIpG;

	protected readonly DeviceType IWwxdNtQGcQDQmreWOmpTRhfHCs;

	protected readonly string pLbLMWidWLWezqfULDGEQQFcDtb;

	protected HIDDeviceDriver gBGkpOgtWdAkRVNCGcbgdqBFpkZx;

	protected Controller.Extension QURffhTVTmAKnOacQXBuiiPLVku;

	protected readonly string SfssPDkTMTodZCmfFEFLzrncfJfB;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public bUiVDUOAHpFECnWVzgHAGOUkHLxZ HidDevice
	{
		get
		{
			return nrCaOgcYlgmLhdXZQBObPMACAeRA;
		}
	}

	public string ProductName
	{
		get
		{
			return YHtEuhFNXMbKXkXCmocUmoanfRXI;
		}
	}

	public string Manufacturer
	{
		get
		{
			return MOmYYKsovJJgBVPLtOSwtmMRAfgH;
		}
	}

	public int VendorId
	{
		get
		{
			return IsTHWbzBGcfzINmBcVjVFHKiALR;
		}
	}

	public int ProductId
	{
		get
		{
			return JRhfPemcldoYcpjKNjaKZBrYsJ;
		}
	}

	public Guid ProductGuid
	{
		get
		{
			return zZrGsvpcmUZZGGexHHzXZAxTZpG;
		}
	}

	public Guid InstanceGuid
	{
		get
		{
			return cBDIfdqFvdWzxrFEMJqjLvTvIpG;
		}
	}

	public DeviceType DeviceType
	{
		get
		{
			return IWwxdNtQGcQDQmreWOmpTRhfHCs;
		}
	}

	public bool IsBluetoothDevice
	{
		get
		{
			return nrCaOgcYlgmLhdXZQBObPMACAeRA.IsBluetoothDevice;
		}
	}

	public string BluetoothDeviceName
	{
		get
		{
			return nrCaOgcYlgmLhdXZQBObPMACAeRA.BluetoothDeviceName;
		}
	}

	public string HWDefinitionMatchTag
	{
		get
		{
			return SfssPDkTMTodZCmfFEFLzrncfJfB;
		}
	}

	public HIDDeviceDriver Driver
	{
		get
		{
			return gBGkpOgtWdAkRVNCGcbgdqBFpkZx;
		}
	}

	public Controller.Extension ControllerExtension
	{
		get
		{
			return QURffhTVTmAKnOacQXBuiiPLVku;
		}
	}

	public virtual bool IsValid
	{
		get
		{
			return !nNxUslIcGUpqKgpPZYhuimcvWyC;
		}
	}

	public RvZISYIDPdXRXmkDKoxbOaBOekr(bUiVDUOAHpFECnWVzgHAGOUkHLxZ hidDevice)
	{
		nrCaOgcYlgmLhdXZQBObPMACAeRA = hidDevice;
		IWwxdNtQGcQDQmreWOmpTRhfHCs = uvpDhRbKObAnpFcwxEKXRGrxscz((ushort)hidDevice.Capabilities.UsagePage, (ushort)hidDevice.Capabilities.Usage);
		YHtEuhFNXMbKXkXCmocUmoanfRXI = hidDevice.ReadProductName();
		if (string.IsNullOrEmpty(YHtEuhFNXMbKXkXCmocUmoanfRXI))
		{
			YHtEuhFNXMbKXkXCmocUmoanfRXI = "Unknown";
		}
		MOmYYKsovJJgBVPLtOSwtmMRAfgH = hidDevice.Manufacturer;
		IsTHWbzBGcfzINmBcVjVFHKiALR = hidDevice.Attributes.VendorId;
		JRhfPemcldoYcpjKNjaKZBrYsJ = hidDevice.Attributes.ProductId;
		pLbLMWidWLWezqfULDGEQQFcDtb = hidDevice.ReadSerialNumber();
		zZrGsvpcmUZZGGexHHzXZAxTZpG = MiscTools.CreateHIDProductGuid(IsTHWbzBGcfzINmBcVjVFHKiALR, JRhfPemcldoYcpjKNjaKZBrYsJ);
		cBDIfdqFvdWzxrFEMJqjLvTvIpG = MiscTools.CreateGuidHashSHA1(nrCaOgcYlgmLhdXZQBObPMACAeRA.InstanceId);
		SfssPDkTMTodZCmfFEFLzrncfJfB = XwFnLxypphHNgefilLFbGvPLvxl.WVhPWHLBAhlIDMgWMaWIAyWlQMY(hidDevice, zZrGsvpcmUZZGGexHHzXZAxTZpG, YHtEuhFNXMbKXkXCmocUmoanfRXI, BluetoothDeviceName);
	}

	public virtual void Update(UpdateLoopType P_0)
	{
		if (gBGkpOgtWdAkRVNCGcbgdqBFpkZx == null)
		{
			return;
		}
		while (true)
		{
			int num = -2044826961;
			while (true)
			{
				switch (num ^ -2044826963)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0026;
				case 1:
					return;
				}
				break;
				IL_0026:
				gBGkpOgtWdAkRVNCGcbgdqBFpkZx.Update(P_0);
				num = -2044826964;
			}
		}
	}

	public abstract void UpdateFinished();

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~RvZISYIDPdXRXmkDKoxbOaBOekr()
	{
		Dispose(false);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		while (true)
		{
			IL_0057:
			if (!P_0)
			{
				goto IL_002f;
			}
			int num;
			if (gBGkpOgtWdAkRVNCGcbgdqBFpkZx != null)
			{
				gBGkpOgtWdAkRVNCGcbgdqBFpkZx.Dispose();
				num = 1311995809;
				goto IL_000e;
			}
			goto IL_003d;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x4E3377A1)
				{
				case 4:
					num = 1311995808;
					continue;
				default:
					return;
				case 3:
					break;
				case 0:
					goto IL_003d;
				case 1:
					goto IL_0057;
				case 2:
					return;
				}
				break;
			}
			goto IL_002f;
			IL_003d:
			if (nrCaOgcYlgmLhdXZQBObPMACAeRA != null)
			{
				nrCaOgcYlgmLhdXZQBObPMACAeRA.Dispose();
				num = 1311995810;
				goto IL_000e;
			}
			goto IL_002f;
			IL_002f:
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			num = 1311995811;
			goto IL_000e;
		}
	}

	private static DeviceType uvpDhRbKObAnpFcwxEKXRGrxscz(ushort P_0, ushort P_1)
	{
		if (P_0 != 1)
		{
			return DeviceType.Unknown;
		}
		ushort num = P_1;
		while (true)
		{
			switch (-1032883242 ^ -1032883244)
			{
			case 0:
				continue;
			case 2:
				switch (num)
				{
				case 4:
					break;
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
				break;
			}
			break;
		}
		return DeviceType.Joystick;
	}

	public abstract void Acquire();

	public abstract void Unacquire();

	public abstract bool IsAttached();
}
