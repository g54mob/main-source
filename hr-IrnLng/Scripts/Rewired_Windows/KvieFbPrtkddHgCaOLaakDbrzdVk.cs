using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Utils;
using Rewired.Windows.RawInput;

internal abstract class KvieFbPrtkddHgCaOLaakDbrzdVk : IDisposable, JCYGPjEQcKOOTdZvoMxBaMbkRbzp
{
	protected MFFbigtCSAERTKmOTUlnAJmgNhe grnBDJBtZFZbjIPZRTGcCIJrlds;

	protected readonly int RZHIGxictBaLdinslbXSFAAcVZwE;

	protected readonly int MhukoibVMCaWMPbjNznhKeYCorw;

	protected readonly Guid yfOOLOyjApmbGkxaIJJQKRViOSz;

	protected readonly Guid zAgUTYpwnGscdFlNDxXqCoyIrDh;

	protected readonly DeviceType JcHGgOgbiJToMAlzRjYaQTOAcUT;

	protected readonly string qLEGSxFzgcnshsGSWCKXBBKFDkKI;

	protected HIDDeviceDriver phkjrlDyMCxXdDWRnPpvhAwzxe;

	protected Controller.Extension DVsySMKjiPwbsgiFRHdnnOZifDB;

	private string ZYolPGUxfYeeraLXjBJmvNxFLrO;

	private string jqQCJQdtRnUSOqdQLiMTcbWYHWQa;

	private string IUOnNhfGwpfASeqoVopIHtvDgTXH;

	private bool abeJBbIDgdaaYBiTAPvEMalAoaD;

	private bool bGKhltIEUuaQKWQpXpMKJZuusPf;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public MFFbigtCSAERTKmOTUlnAJmgNhe HidDevice => grnBDJBtZFZbjIPZRTGcCIJrlds;

	public string ProductName
	{
		get
		{
			if (!string.IsNullOrEmpty(ZYolPGUxfYeeraLXjBJmvNxFLrO))
			{
				return ZYolPGUxfYeeraLXjBJmvNxFLrO;
			}
			ZYolPGUxfYeeraLXjBJmvNxFLrO = grnBDJBtZFZbjIPZRTGcCIJrlds.qZvONhbQmhqKnNrMmPatPTIwFOu();
			if (string.IsNullOrEmpty(ZYolPGUxfYeeraLXjBJmvNxFLrO))
			{
				ZYolPGUxfYeeraLXjBJmvNxFLrO = "Unknown";
			}
			return ZYolPGUxfYeeraLXjBJmvNxFLrO;
		}
	}

	public string Manufacturer
	{
		get
		{
			if (abeJBbIDgdaaYBiTAPvEMalAoaD)
			{
				return jqQCJQdtRnUSOqdQLiMTcbWYHWQa;
			}
			jqQCJQdtRnUSOqdQLiMTcbWYHWQa = grnBDJBtZFZbjIPZRTGcCIJrlds.sGlGxVXmpWmZtSOOjiEBDZjUYMx();
			abeJBbIDgdaaYBiTAPvEMalAoaD = true;
			return jqQCJQdtRnUSOqdQLiMTcbWYHWQa;
		}
	}

	public int VendorId => RZHIGxictBaLdinslbXSFAAcVZwE;

	public int ProductId => MhukoibVMCaWMPbjNznhKeYCorw;

	public Guid ProductGuid => yfOOLOyjApmbGkxaIJJQKRViOSz;

	public Guid InstanceGuid => zAgUTYpwnGscdFlNDxXqCoyIrDh;

	public DeviceType DeviceType => JcHGgOgbiJToMAlzRjYaQTOAcUT;

	public bool IsBluetoothDevice => grnBDJBtZFZbjIPZRTGcCIJrlds.IsBluetoothDevice;

	public string BluetoothDeviceName => grnBDJBtZFZbjIPZRTGcCIJrlds.BluetoothDeviceName;

	public string HWDefinitionMatchTag
	{
		get
		{
			if (bGKhltIEUuaQKWQpXpMKJZuusPf)
			{
				return IUOnNhfGwpfASeqoVopIHtvDgTXH;
			}
			IUOnNhfGwpfASeqoVopIHtvDgTXH = MwoFssxjTIQzJQFdgnRgTEwkueQ.FUEfOdGwzMIRJkpsPreVXOvWCDd(grnBDJBtZFZbjIPZRTGcCIJrlds, yfOOLOyjApmbGkxaIJJQKRViOSz, ProductName, BluetoothDeviceName);
			bGKhltIEUuaQKWQpXpMKJZuusPf = true;
			return IUOnNhfGwpfASeqoVopIHtvDgTXH;
		}
	}

	public HIDDeviceDriver Driver => phkjrlDyMCxXdDWRnPpvhAwzxe;

	public Controller.Extension ControllerExtension => DVsySMKjiPwbsgiFRHdnnOZifDB;

	public virtual bool IsValid => !euujVPFzGztViWDbYvUutBvFQFP;

	public KvieFbPrtkddHgCaOLaakDbrzdVk(MFFbigtCSAERTKmOTUlnAJmgNhe hidDevice)
	{
		grnBDJBtZFZbjIPZRTGcCIJrlds = hidDevice;
		JcHGgOgbiJToMAlzRjYaQTOAcUT = duMmYwycgMfujfKcaaYUHWsOklQH((ushort)hidDevice.Capabilities.UsagePage, (ushort)hidDevice.Capabilities.Usage);
		RZHIGxictBaLdinslbXSFAAcVZwE = hidDevice.Attributes.VendorId;
		MhukoibVMCaWMPbjNznhKeYCorw = hidDevice.Attributes.ProductId;
		qLEGSxFzgcnshsGSWCKXBBKFDkKI = hidDevice.BRmxKCgUEwFrfmXPnrqBAXoQjAk();
		yfOOLOyjApmbGkxaIJJQKRViOSz = MiscTools.CreateHIDProductGuid(RZHIGxictBaLdinslbXSFAAcVZwE, MhukoibVMCaWMPbjNznhKeYCorw);
		zAgUTYpwnGscdFlNDxXqCoyIrDh = MiscTools.CreateGuidHashSHA1(grnBDJBtZFZbjIPZRTGcCIJrlds.InstanceId);
	}

	public virtual void RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		if (phkjrlDyMCxXdDWRnPpvhAwzxe != null)
		{
			phkjrlDyMCxXdDWRnPpvhAwzxe.Update(P_0);
		}
	}

	void JCYGPjEQcKOOTdZvoMxBaMbkRbzp.RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RMEkOMsGFSFWbHqrAFftMTIKNIHO
		this.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
	}

	public abstract void xbrgbsymhweSXlyAZAqkvRqFNEB();

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~KvieFbPrtkddHgCaOLaakDbrzdVk()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		if (P_0)
		{
			if (phkjrlDyMCxXdDWRnPpvhAwzxe != null)
			{
				phkjrlDyMCxXdDWRnPpvhAwzxe.Dispose();
			}
			if (grnBDJBtZFZbjIPZRTGcCIJrlds != null)
			{
				grnBDJBtZFZbjIPZRTGcCIJrlds.Dispose();
			}
		}
		euujVPFzGztViWDbYvUutBvFQFP = true;
	}

	private static DeviceType duMmYwycgMfujfKcaaYUHWsOklQH(ushort P_0, ushort P_1)
	{
		if (P_0 != 1)
		{
			return DeviceType.Unknown;
		}
		return P_1 switch
		{
			4 => DeviceType.Joystick, 
			5 => DeviceType.Gamepad, 
			6 => DeviceType.Keyboard, 
			2 => DeviceType.Mouse, 
			8 => DeviceType.MultiAxisController, 
			_ => DeviceType.Unknown, 
		};
	}

	public abstract void DfoHKTaxZzJSYcaLwTWUBUINGoo();

	public abstract void SdCpHXCeCCZSBrMShYjjsXEWWgu();

	public abstract bool ezYQOBjVNKObFDufNqksjDEFGPV();
}
