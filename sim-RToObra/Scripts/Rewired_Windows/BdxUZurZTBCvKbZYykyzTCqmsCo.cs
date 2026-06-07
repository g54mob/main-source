using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Utils;
using Rewired.Windows.RawInput;

internal abstract class BdxUZurZTBCvKbZYykyzTCqmsCo : IDisposable, CRXrBgggAdrpYwIPGGrSdEyGnoQt
{
	protected hdKCmGlHttTBdcjeWBCjBOXCTjJ dDiORYZMrygMeGilpySloSKsIyVj;

	protected readonly string WqJtaJydLKfHMdBaTOkMfyaNjHV;

	protected readonly string IGwBqVihXInEfQfSMYaccExvhmS;

	protected readonly int MuUvKqUoBwjeeARSVEPLjMRCxMZm;

	protected readonly int JMlYutJKotRfBkZPzojsSHTHpoT;

	protected readonly Guid dtDBXVaMeIfOBNZSuCJFNWYxzPWi;

	protected readonly Guid mtlDBDFXTzxHqeXjvCJbhGtTMUCC;

	protected readonly DeviceType MPYsoXMGWkWNPnIZfcIbKUFFbRqA;

	protected readonly string znTrOyJMKNkVctOsieCUDRBSRtrz;

	protected HIDDeviceDriver sKccQcTMCpzjEQGijBfqlsHvtcP;

	protected Controller.Extension GxryzPkvRgFXiLtGnPVwlFRrgKm;

	protected readonly string ANGYavRKqBsICDNVyLmZyfbWDyj;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public hdKCmGlHttTBdcjeWBCjBOXCTjJ HidDevice
	{
		get
		{
			return dDiORYZMrygMeGilpySloSKsIyVj;
		}
	}

	public string ProductName
	{
		get
		{
			return WqJtaJydLKfHMdBaTOkMfyaNjHV;
		}
	}

	public string Manufacturer
	{
		get
		{
			return IGwBqVihXInEfQfSMYaccExvhmS;
		}
	}

	public int VendorId
	{
		get
		{
			return MuUvKqUoBwjeeARSVEPLjMRCxMZm;
		}
	}

	public int ProductId
	{
		get
		{
			return JMlYutJKotRfBkZPzojsSHTHpoT;
		}
	}

	public Guid ProductGuid
	{
		get
		{
			return dtDBXVaMeIfOBNZSuCJFNWYxzPWi;
		}
	}

	public Guid InstanceGuid
	{
		get
		{
			return mtlDBDFXTzxHqeXjvCJbhGtTMUCC;
		}
	}

	public DeviceType DeviceType
	{
		get
		{
			return MPYsoXMGWkWNPnIZfcIbKUFFbRqA;
		}
	}

	public bool IsBluetoothDevice
	{
		get
		{
			return dDiORYZMrygMeGilpySloSKsIyVj.IsBluetoothDevice;
		}
	}

	public string BluetoothDeviceName
	{
		get
		{
			return dDiORYZMrygMeGilpySloSKsIyVj.BluetoothDeviceName;
		}
	}

	public string HWDefinitionMatchTag
	{
		get
		{
			return ANGYavRKqBsICDNVyLmZyfbWDyj;
		}
	}

	public HIDDeviceDriver Driver
	{
		get
		{
			return sKccQcTMCpzjEQGijBfqlsHvtcP;
		}
	}

	public Controller.Extension ControllerExtension
	{
		get
		{
			return GxryzPkvRgFXiLtGnPVwlFRrgKm;
		}
	}

	public virtual bool IsValid
	{
		get
		{
			return !nYnvJCdSwCjafdvZoFKnjAkIRCs;
		}
	}

	public BdxUZurZTBCvKbZYykyzTCqmsCo(hdKCmGlHttTBdcjeWBCjBOXCTjJ hidDevice)
	{
		dDiORYZMrygMeGilpySloSKsIyVj = hidDevice;
		MPYsoXMGWkWNPnIZfcIbKUFFbRqA = uzPBItgSGbQRoCWEBKGFsGnSPanC((ushort)hidDevice.Capabilities.UsagePage, (ushort)hidDevice.Capabilities.Usage);
		WqJtaJydLKfHMdBaTOkMfyaNjHV = hidDevice.ReadProductName();
		if (string.IsNullOrEmpty(WqJtaJydLKfHMdBaTOkMfyaNjHV))
		{
			WqJtaJydLKfHMdBaTOkMfyaNjHV = "Unknown";
		}
		IGwBqVihXInEfQfSMYaccExvhmS = hidDevice.Manufacturer;
		MuUvKqUoBwjeeARSVEPLjMRCxMZm = hidDevice.Attributes.VendorId;
		JMlYutJKotRfBkZPzojsSHTHpoT = hidDevice.Attributes.ProductId;
		znTrOyJMKNkVctOsieCUDRBSRtrz = hidDevice.ReadSerialNumber();
		dtDBXVaMeIfOBNZSuCJFNWYxzPWi = MiscTools.CreateHIDProductGuid(MuUvKqUoBwjeeARSVEPLjMRCxMZm, JMlYutJKotRfBkZPzojsSHTHpoT);
		mtlDBDFXTzxHqeXjvCJbhGtTMUCC = MiscTools.CreateGuidHashSHA1(dDiORYZMrygMeGilpySloSKsIyVj.InstanceId);
		ANGYavRKqBsICDNVyLmZyfbWDyj = ZBdWqjRRrpMQStGZMBFtHgnrSdp.UcFxCuePLtGkYNmCfHmGPxwJaCKI(hidDevice, dtDBXVaMeIfOBNZSuCJFNWYxzPWi, WqJtaJydLKfHMdBaTOkMfyaNjHV, BluetoothDeviceName);
	}

	public virtual void Update(UpdateLoopType P_0)
	{
		if (sKccQcTMCpzjEQGijBfqlsHvtcP != null)
		{
			sKccQcTMCpzjEQGijBfqlsHvtcP.Update(P_0);
		}
	}

	public abstract void UpdateFinished();

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~BdxUZurZTBCvKbZYykyzTCqmsCo()
	{
		Dispose(false);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			goto IL_0008;
		}
		goto IL_0050;
		IL_0008:
		int num = -290944980;
		goto IL_000d;
		IL_000d:
		switch (num ^ -290944977)
		{
		case 2:
			break;
		case 3:
			return;
		case 1:
			goto IL_0036;
		case 4:
			goto IL_0050;
		default:
			goto IL_006d;
		}
		goto IL_0008;
		IL_0050:
		if (P_0)
		{
			if (sKccQcTMCpzjEQGijBfqlsHvtcP != null)
			{
				sKccQcTMCpzjEQGijBfqlsHvtcP.Dispose();
				num = -290944978;
				goto IL_000d;
			}
			goto IL_0036;
		}
		goto IL_006d;
		IL_006d:
		nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
		return;
		IL_0036:
		if (dDiORYZMrygMeGilpySloSKsIyVj != null)
		{
			dDiORYZMrygMeGilpySloSKsIyVj.Dispose();
			num = -290944977;
			goto IL_000d;
		}
		goto IL_006d;
	}

	private static DeviceType uzPBItgSGbQRoCWEBKGFsGnSPanC(ushort P_0, ushort P_1)
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

	public abstract void Acquire();

	public abstract void Unacquire();

	public abstract bool IsAttached();
}
