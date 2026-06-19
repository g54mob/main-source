using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils;

internal class HLdBxKWeCCnyYemLsKrebKcAXOS
{
	public int uiOHwBrYNOLBuZUwvPRpKAvvNnQ;

	public int OxaYhfaGlOIumOWmOozrcdXdBYi;

	public bool nwuFkwuKZJNUmRNBHlHkaVmWisU;

	public string smokGOBqcHhadIuTGoOisYEsZev;

	public string AvyftLzUyJglwYQfpfUwBlMFDvlF;

	public Guid oHcUxJjAVizMmWpVgzoSjEmmGSV;

	public Guid oMiTtujRXgajflzsMflJRQlODId;

	public int CtHmgLQvreiWMWnBZZLsTLZpuCY;

	public int JDyNNdOScJLywOHcbmcaJdgZeIE;

	public int ujudIdEbcBxpOOEDEHDZQOoRtUi;

	public int quIzUGyDpRHLEYNLWYPNqooevEE;

	public PidVid XxPyoTTaBrqavQxCEWuldVgopKn;

	public Guid MFxPNNDXcQATxqTzNEBJQKaLbJl;

	public int BrgQIQRJLDuAcBXJgGkqkzwAMUC;

	public int zoKLHtvFVNkkMUCHuynHAkHmONk;

	public void obdzkDbpOaaUIgoMQmAkmvMIcKJ()
	{
		byte[] value = oHcUxJjAVizMmWpVgzoSjEmmGSV.ToByteArray();
		int startIndex;
		int startIndex2;
		switch (UnityTools.effectivePlatform)
		{
		case Platform.Windows:
			startIndex = 0;
			startIndex2 = 2;
			break;
		case Platform.OSX:
			startIndex = 0;
			startIndex2 = 8;
			break;
		case Platform.Linux:
			startIndex = 4;
			startIndex2 = 8;
			break;
		default:
			throw new NotImplementedException();
		}
		BrgQIQRJLDuAcBXJgGkqkzwAMUC = BitConverter.ToUInt16(value, startIndex);
		zoKLHtvFVNkkMUCHuynHAkHmONk = BitConverter.ToUInt16(value, startIndex2);
		XxPyoTTaBrqavQxCEWuldVgopKn = new PidVid((ushort)zoKLHtvFVNkkMUCHuynHAkHmONk, (ushort)BrgQIQRJLDuAcBXJgGkqkzwAMUC);
		MFxPNNDXcQATxqTzNEBJQKaLbJl = MiscTools.CreateGuidHashSHA1(smokGOBqcHhadIuTGoOisYEsZev + XxPyoTTaBrqavQxCEWuldVgopKn.ToString() + OxaYhfaGlOIumOWmOozrcdXdBYi);
		if (string.IsNullOrEmpty(AvyftLzUyJglwYQfpfUwBlMFDvlF))
		{
			AvyftLzUyJglwYQfpfUwBlMFDvlF = smokGOBqcHhadIuTGoOisYEsZev;
		}
	}

	public override string ToString()
	{
		string text = "";
		object obj = text;
		text = string.Concat(obj, "joystickIndex = ", uiOHwBrYNOLBuZUwvPRpKAvvNnQ, "\n");
		object obj2 = text;
		text = string.Concat(obj2, "joystickId = ", OxaYhfaGlOIumOWmOozrcdXdBYi, "\n");
		object obj3 = text;
		text = string.Concat(obj3, "isGameController = ", nwuFkwuKZJNUmRNBHlHkaVmWisU, "\n");
		text = text + "hardwareName = " + smokGOBqcHhadIuTGoOisYEsZev + "\n";
		text = text + "friendlyName = " + AvyftLzUyJglwYQfpfUwBlMFDvlF + "\n";
		object obj4 = text;
		text = string.Concat(obj4, "sdlJoystickGuid = ", oHcUxJjAVizMmWpVgzoSjEmmGSV, "\n");
		object obj5 = text;
		text = string.Concat(obj5, "sdlDeviceGuid = ", oMiTtujRXgajflzsMflJRQlODId, "\n");
		object obj6 = text;
		text = string.Concat(obj6, "buttonCount = ", CtHmgLQvreiWMWnBZZLsTLZpuCY, "\n");
		object obj7 = text;
		text = string.Concat(obj7, "axisCount = ", JDyNNdOScJLywOHcbmcaJdgZeIE, "\n");
		object obj8 = text;
		text = string.Concat(obj8, "hatCount = ", ujudIdEbcBxpOOEDEHDZQOoRtUi, "\n");
		object obj9 = text;
		text = string.Concat(obj9, "ballCount = ", quIzUGyDpRHLEYNLWYPNqooevEE, "\n");
		object obj10 = text;
		text = string.Concat(obj10, "pidVid = ", XxPyoTTaBrqavQxCEWuldVgopKn, "\n");
		object obj11 = text;
		text = string.Concat(obj11, "instanceGuid = ", MFxPNNDXcQATxqTzNEBJQKaLbJl, "\n");
		object obj12 = text;
		text = string.Concat(obj12, "vendorId = ", BrgQIQRJLDuAcBXJgGkqkzwAMUC, "\n");
		object obj13 = text;
		return string.Concat(obj13, "productId = ", zoKLHtvFVNkkMUCHuynHAkHmONk, "\n");
	}
}
