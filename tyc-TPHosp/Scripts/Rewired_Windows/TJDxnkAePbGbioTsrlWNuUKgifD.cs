using System;
using Rewired;
using Rewired.HID.Drivers;
using Rewired.Utils;
using Rewired.Windows.RawInput;

internal abstract class TJDxnkAePbGbioTsrlWNuUKgifD : IDisposable, EorbaTBAfVCiZjvhJJeAhAACxCn
{
	protected VaqvDpgkuJiGiwrYcarAfGJvBwg rYdWhwxECnIItHOggIRnHyqhsm;

	protected readonly int YowCsezATUyJENikCrxxxstMePc;

	protected readonly int HwTQrladgBFCfhnzqFgSdelTFru;

	protected readonly Guid fNtvkBbNmqjFxUSuzhnhpCwbeSt;

	protected readonly Guid ypBhwPylZXgbWvdXwgdHvTJZNDf;

	protected readonly DeviceType YLaaUBxUGAKknmcrumeXdnbJGSL;

	protected readonly string fxnmgUiGlsmYZmKhSgmHyvUTsWl;

	protected HIDDeviceDriver oQOaImiuMJjIstJUuSXUOWhbMzk;

	protected Controller.Extension OkBfYBgDJSjeKVCaaNbKbSnxxxVj;

	private string IvZcLMcNTPVsEkEVMchTeCaKUDQB;

	private string wavfDJajNgIxaJISkawDYpbTEhK;

	private string XHhtXkcEMaUJzAQsmTopKaWrGJV;

	private bool vsEBYGCkhzThFRssmwjSAvTqNkac;

	private bool gThUJcPrippkrgKSkUTdoUotIyt;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public VaqvDpgkuJiGiwrYcarAfGJvBwg HidDevice => rYdWhwxECnIItHOggIRnHyqhsm;

	public string ProductName
	{
		get
		{
			if (!string.IsNullOrEmpty(IvZcLMcNTPVsEkEVMchTeCaKUDQB))
			{
				return IvZcLMcNTPVsEkEVMchTeCaKUDQB;
			}
			IvZcLMcNTPVsEkEVMchTeCaKUDQB = rYdWhwxECnIItHOggIRnHyqhsm.hGWnWkyuYsGvKxKINIkKkOfzYJg();
			if (string.IsNullOrEmpty(IvZcLMcNTPVsEkEVMchTeCaKUDQB))
			{
				IvZcLMcNTPVsEkEVMchTeCaKUDQB = "Unknown";
			}
			return IvZcLMcNTPVsEkEVMchTeCaKUDQB;
		}
	}

	public string Manufacturer
	{
		get
		{
			if (vsEBYGCkhzThFRssmwjSAvTqNkac)
			{
				return wavfDJajNgIxaJISkawDYpbTEhK;
			}
			wavfDJajNgIxaJISkawDYpbTEhK = rYdWhwxECnIItHOggIRnHyqhsm.jYIpiYUiDDxgEemUYgUmGmENCMlV();
			vsEBYGCkhzThFRssmwjSAvTqNkac = true;
			return wavfDJajNgIxaJISkawDYpbTEhK;
		}
	}

	public int VendorId => YowCsezATUyJENikCrxxxstMePc;

	public int ProductId => HwTQrladgBFCfhnzqFgSdelTFru;

	public Guid ProductGuid => fNtvkBbNmqjFxUSuzhnhpCwbeSt;

	public Guid InstanceGuid => ypBhwPylZXgbWvdXwgdHvTJZNDf;

	public DeviceType DeviceType => YLaaUBxUGAKknmcrumeXdnbJGSL;

	public bool IsBluetoothDevice => rYdWhwxECnIItHOggIRnHyqhsm.IsBluetoothDevice;

	public string BluetoothDeviceName => rYdWhwxECnIItHOggIRnHyqhsm.BluetoothDeviceName;

	public string HWDefinitionMatchTag
	{
		get
		{
			if (gThUJcPrippkrgKSkUTdoUotIyt)
			{
				return XHhtXkcEMaUJzAQsmTopKaWrGJV;
			}
			XHhtXkcEMaUJzAQsmTopKaWrGJV = ZKLIjvmxtRjTyokzJnlXgDPvgmC.YknolmFaNNBJmSzmqGIcasMPdBrK(rYdWhwxECnIItHOggIRnHyqhsm, fNtvkBbNmqjFxUSuzhnhpCwbeSt, ProductName, BluetoothDeviceName);
			gThUJcPrippkrgKSkUTdoUotIyt = true;
			return XHhtXkcEMaUJzAQsmTopKaWrGJV;
		}
	}

	public HIDDeviceDriver Driver => oQOaImiuMJjIstJUuSXUOWhbMzk;

	public Controller.Extension ControllerExtension => OkBfYBgDJSjeKVCaaNbKbSnxxxVj;

	public virtual bool IsValid => !dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public TJDxnkAePbGbioTsrlWNuUKgifD(VaqvDpgkuJiGiwrYcarAfGJvBwg hidDevice)
	{
		rYdWhwxECnIItHOggIRnHyqhsm = hidDevice;
		YLaaUBxUGAKknmcrumeXdnbJGSL = cIhqzddkODwTUHeaVgqtnrXFfgC((ushort)hidDevice.Capabilities.UsagePage, (ushort)hidDevice.Capabilities.Usage);
		YowCsezATUyJENikCrxxxstMePc = hidDevice.Attributes.VendorId;
		HwTQrladgBFCfhnzqFgSdelTFru = hidDevice.Attributes.ProductId;
		fxnmgUiGlsmYZmKhSgmHyvUTsWl = hidDevice.OKJUZXbWmtKHCKBBILDyjkeFjvuc();
		fNtvkBbNmqjFxUSuzhnhpCwbeSt = MiscTools.CreateHIDProductGuid(YowCsezATUyJENikCrxxxstMePc, HwTQrladgBFCfhnzqFgSdelTFru);
		ypBhwPylZXgbWvdXwgdHvTJZNDf = MiscTools.CreateGuidHashSHA1(rYdWhwxECnIItHOggIRnHyqhsm.InstanceId);
	}

	public virtual void CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		if (oQOaImiuMJjIstJUuSXUOWhbMzk != null)
		{
			oQOaImiuMJjIstJUuSXUOWhbMzk.Update(P_0);
		}
	}

	void EorbaTBAfVCiZjvhJJeAhAACxCn.CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CWncwVbJhTWISMonvIVEimpDcKXc
		this.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
	}

	public abstract void gXADYrdzIttymTRoaKqLkIyUtDJ();

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~TJDxnkAePbGbioTsrlWNuUKgifD()
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
			if (oQOaImiuMJjIstJUuSXUOWhbMzk != null)
			{
				oQOaImiuMJjIstJUuSXUOWhbMzk.Dispose();
			}
			if (rYdWhwxECnIItHOggIRnHyqhsm != null)
			{
				rYdWhwxECnIItHOggIRnHyqhsm.Dispose();
			}
		}
		dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
	}

	private static DeviceType cIhqzddkODwTUHeaVgqtnrXFfgC(ushort P_0, ushort P_1)
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

	public abstract void QqViEWwhZaWrvATfPuWfqnkWwbi();

	public abstract void JkxbMOPQiVSbeNRGETMYZahHimc();

	public abstract bool pstoeMoNzNWOorGnoIUVfChGZNFf();
}
