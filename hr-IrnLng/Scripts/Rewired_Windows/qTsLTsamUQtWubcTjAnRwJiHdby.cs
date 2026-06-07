using System;
using Rewired;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Utils;

internal class qTsLTsamUQtWubcTjAnRwJiHdby : KvieFbPrtkddHgCaOLaakDbrzdVk, IDisposable, JCYGPjEQcKOOTdZvoMxBaMbkRbzp, XISatJdVArtMUkOXRoGcIhpgBatq
{
	private int eeJEgNdbOeNjlaYWqJBgGBnThHi;

	private biZfRftwELiGKLYOEPcPoCAhFEM rQvyfwuyHYJxmwHdxnGkAYHiCEt;

	private IntPtr QlgcOwbEYhnXnBwDhaOYZOCPCQz;

	private ButtonLoopSet KVuvyhSNRPONDOAYhgLMkebqLbF;

	private xeDXAkGcMzNhIAYbhjotXWERSKg[] MZJVdlKarxDQpTBCVESaHqIzDHs;

	private RsqggZFhRByEelmowNLCCsnWtKZD[] JqcYNdZBLMiMnIReregnHWWiSPbQ;

	private int[] rnFMvfxBLbTUThhFqyHVxkffhcZ;

	private HIDAccelerometer[] ntrXszulHoCYSdGnEStZEMegcSiW;

	private HIDGyroscope[] pXGnluJcaQFLFrqQQIBDvcCCTVd;

	private HIDTouchpad[] WzHZRJQpkVvTAHcQtCPnPbKPPKZ;

	private int aORFycYuiaRmVGcJmTzHLSOPUlP;

	private int UVyastEWXnpXcGdBaPvEGhpEVnsp;

	private int FNTmOAZHUKmnxMXJrfTeCMPQiru;

	private int tvaizqPUvvZWprGvMViCfKjcrxU;

	private int cGSyjumLTQpUVIfMWcedauewnOze;

	private int mPBdkrkcgxdVNPRQLxulvdLtvpm;

	private HidOutputReportHandler DMZqxDjamIAdsbwxYxaGIxfuPrN;

	private vqgaTeSNhmAyVtJlBJtiEGOLEPoO cbERsQKkzJKLhJmGbbfBHqfTaNif;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public int JoystickId => eeJEgNdbOeNjlaYWqJBgGBnThHi;

	public biZfRftwELiGKLYOEPcPoCAhFEM JoystickSourceType => rQvyfwuyHYJxmwHdxnGkAYHiCEt;

	public IntPtr JoystickSourceHandle => QlgcOwbEYhnXnBwDhaOYZOCPCQz;

	public bool[] Buttons => KVuvyhSNRPONDOAYhgLMkebqLbF.Current.effectiveValue;

	public int[] HatValues => rnFMvfxBLbTUThhFqyHVxkffhcZ;

	public int ButtonCount => aORFycYuiaRmVGcJmTzHLSOPUlP;

	public int AxisCount => UVyastEWXnpXcGdBaPvEGhpEVnsp;

	public int HatCount => FNTmOAZHUKmnxMXJrfTeCMPQiru;

	public bool HasElements
	{
		get
		{
			if (aORFycYuiaRmVGcJmTzHLSOPUlP <= 0 && UVyastEWXnpXcGdBaPvEGhpEVnsp <= 0)
			{
				return FNTmOAZHUKmnxMXJrfTeCMPQiru > 0;
			}
			return true;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			if (phkjrlDyMCxXdDWRnPpvhAwzxe == null)
			{
				return false;
			}
			return phkjrlDyMCxXdDWRnPpvhAwzxe.VibrationMotorCount > 0;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			if (phkjrlDyMCxXdDWRnPpvhAwzxe == null)
			{
				return 0;
			}
			return phkjrlDyMCxXdDWRnPpvhAwzxe.VibrationMotorCount;
		}
	}

	public InputSource InputSource => InputSource.InternalDriver;

	public HidOutputReportHandler HidOutputReportHandler => DMZqxDjamIAdsbwxYxaGIxfuPrN;

	public opovrWrkmvbvBEFbrSmBIkHOqTyF AxesState => cbERsQKkzJKLhJmGbbfBHqfTaNif;

	public qTsLTsamUQtWubcTjAnRwJiHdby(int joystickId, biZfRftwELiGKLYOEPcPoCAhFEM joystickSourceType, IntPtr joystickSourceHandle, MFFbigtCSAERTKmOTUlnAJmgNhe hidDevice, HIDDeviceDriver driver, HidOutputReportHandler hidOutputReportHandler)
		: base(hidDevice)
	{
		phkjrlDyMCxXdDWRnPpvhAwzxe = driver;
		DMZqxDjamIAdsbwxYxaGIxfuPrN = hidOutputReportHandler;
		if (phkjrlDyMCxXdDWRnPpvhAwzxe != null)
		{
			DVsySMKjiPwbsgiFRHdnnOZifDB = phkjrlDyMCxXdDWRnPpvhAwzxe.CreateControllerExtension();
		}
		eeJEgNdbOeNjlaYWqJBgGBnThHi = joystickId;
		rQvyfwuyHYJxmwHdxnGkAYHiCEt = joystickSourceType;
		QlgcOwbEYhnXnBwDhaOYZOCPCQz = joystickSourceHandle;
		cbERsQKkzJKLhJmGbbfBHqfTaNif = new vqgaTeSNhmAyVtJlBJtiEGOLEPoO();
		CEhvBeiAZrernkviylmhdyzuHTF();
		cbERsQKkzJKLhJmGbbfBHqfTaNif.OgIYPHrzCuzrIWGschTmFAMXkfm();
	}

	public override void RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		base.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
		KVuvyhSNRPONDOAYhgLMkebqLbF.SetUpdateLoop(P_0);
		for (int i = 0; i < cGSyjumLTQpUVIfMWcedauewnOze; i++)
		{
			pXGnluJcaQFLFrqQQIBDvcCCTVd[i].Update(P_0);
		}
	}

	void JCYGPjEQcKOOTdZvoMxBaMbkRbzp.RMEkOMsGFSFWbHqrAFftMTIKNIHO(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RMEkOMsGFSFWbHqrAFftMTIKNIHO
		this.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
	}

	public override void xbrgbsymhweSXlyAZAqkvRqFNEB()
	{
		KVuvyhSNRPONDOAYhgLMkebqLbF.Current.ClearWasTrueThisFrame();
	}

	void JCYGPjEQcKOOTdZvoMxBaMbkRbzp.xbrgbsymhweSXlyAZAqkvRqFNEB()
	{
		//ILSpy generated this explicit interface implementation from .override directive in xbrgbsymhweSXlyAZAqkvRqFNEB
		this.xbrgbsymhweSXlyAZAqkvRqFNEB();
	}

	public void EbVOACURTuIOJEQxAtEgRrFmQSQ(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		if (P_1 > 0)
		{
			phkjrlDyMCxXdDWRnPpvhAwzxe.ParseInputReport(P_0, P_1, P_4);
			yMmEMHIqZYcuTkSikVFFrOfyKDc();
			VVKAQHjDQMZyRjqEMoRgsckjyIh();
			RnrDpKmoLadDanXnKzyfdWchwqP();
		}
	}

	void XISatJdVArtMUkOXRoGcIhpgBatq.EbVOACURTuIOJEQxAtEgRrFmQSQ(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in EbVOACURTuIOJEQxAtEgRrFmQSQ
		this.EbVOACURTuIOJEQxAtEgRrFmQSQ(P_0, P_1, P_2, P_3, P_4);
	}

	public override void DfoHKTaxZzJSYcaLwTWUBUINGoo()
	{
	}

	void JCYGPjEQcKOOTdZvoMxBaMbkRbzp.DfoHKTaxZzJSYcaLwTWUBUINGoo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DfoHKTaxZzJSYcaLwTWUBUINGoo
		this.DfoHKTaxZzJSYcaLwTWUBUINGoo();
	}

	public override void SdCpHXCeCCZSBrMShYjjsXEWWgu()
	{
	}

	void JCYGPjEQcKOOTdZvoMxBaMbkRbzp.SdCpHXCeCCZSBrMShYjjsXEWWgu()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SdCpHXCeCCZSBrMShYjjsXEWWgu
		this.SdCpHXCeCCZSBrMShYjjsXEWWgu();
	}

	public override bool ezYQOBjVNKObFDufNqksjDEFGPV()
	{
		return grnBDJBtZFZbjIPZRTGcCIJrlds.IsConnected;
	}

	bool JCYGPjEQcKOOTdZvoMxBaMbkRbzp.ezYQOBjVNKObFDufNqksjDEFGPV()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ezYQOBjVNKObFDufNqksjDEFGPV
		return this.ezYQOBjVNKObFDufNqksjDEFGPV();
	}

	public void zMRhGjCghfxrQxKqmZOzHufbmgp(int P_0)
	{
		eeJEgNdbOeNjlaYWqJBgGBnThHi = P_0;
	}

	void XISatJdVArtMUkOXRoGcIhpgBatq.zMRhGjCghfxrQxKqmZOzHufbmgp(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in zMRhGjCghfxrQxKqmZOzHufbmgp
		this.zMRhGjCghfxrQxKqmZOzHufbmgp(P_0);
	}

	public void GOOgnFFAqwQNgKxSPRwAOTnCrYV(IntPtr P_0)
	{
		QlgcOwbEYhnXnBwDhaOYZOCPCQz = P_0;
	}

	void XISatJdVArtMUkOXRoGcIhpgBatq.GOOgnFFAqwQNgKxSPRwAOTnCrYV(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GOOgnFFAqwQNgKxSPRwAOTnCrYV
		this.GOOgnFFAqwQNgKxSPRwAOTnCrYV(P_0);
	}

	private void CEhvBeiAZrernkviylmhdyzuHTF()
	{
		aORFycYuiaRmVGcJmTzHLSOPUlP = phkjrlDyMCxXdDWRnPpvhAwzxe.ButtonCount;
		UVyastEWXnpXcGdBaPvEGhpEVnsp = phkjrlDyMCxXdDWRnPpvhAwzxe.AxisCount;
		FNTmOAZHUKmnxMXJrfTeCMPQiru = phkjrlDyMCxXdDWRnPpvhAwzxe.HatCount;
		tvaizqPUvvZWprGvMViCfKjcrxU = phkjrlDyMCxXdDWRnPpvhAwzxe.AccelerometerCount;
		cGSyjumLTQpUVIfMWcedauewnOze = phkjrlDyMCxXdDWRnPpvhAwzxe.GyroscopeCount;
		mPBdkrkcgxdVNPRQLxulvdLtvpm = phkjrlDyMCxXdDWRnPpvhAwzxe.TouchpadCount;
		KVuvyhSNRPONDOAYhgLMkebqLbF = new ButtonLoopSet(ReInput.configVars.updateLoop, aORFycYuiaRmVGcJmTzHLSOPUlP);
		MZJVdlKarxDQpTBCVESaHqIzDHs = new xeDXAkGcMzNhIAYbhjotXWERSKg[UVyastEWXnpXcGdBaPvEGhpEVnsp];
		JqcYNdZBLMiMnIReregnHWWiSPbQ = new RsqggZFhRByEelmowNLCCsnWtKZD[FNTmOAZHUKmnxMXJrfTeCMPQiru];
		rnFMvfxBLbTUThhFqyHVxkffhcZ = new int[FNTmOAZHUKmnxMXJrfTeCMPQiru];
		ArrayTools.Fill(rnFMvfxBLbTUThhFqyHVxkffhcZ, -1);
		ntrXszulHoCYSdGnEStZEMegcSiW = phkjrlDyMCxXdDWRnPpvhAwzxe.accelerometers;
		pXGnluJcaQFLFrqQQIBDvcCCTVd = phkjrlDyMCxXdDWRnPpvhAwzxe.gyroscopes;
		WzHZRJQpkVvTAHcQtCPnPbKPPKZ = phkjrlDyMCxXdDWRnPpvhAwzxe.touchpads;
		for (int i = 0; i < UVyastEWXnpXcGdBaPvEGhpEVnsp; i++)
		{
			MZJVdlKarxDQpTBCVESaHqIzDHs[i] = sDKQiRpFiIxEyMnCwEmsBmdUrgwN(phkjrlDyMCxXdDWRnPpvhAwzxe.axes[i]);
			cbERsQKkzJKLhJmGbbfBHqfTaNif.qzPBsOcOtJOBUdAbauhtohXZIuQL(MZJVdlKarxDQpTBCVESaHqIzDHs[i]);
		}
		for (int j = 0; j < FNTmOAZHUKmnxMXJrfTeCMPQiru; j++)
		{
			JqcYNdZBLMiMnIReregnHWWiSPbQ[j] = CwOMkISLjasYpIVUGGntXgiVEiP(phkjrlDyMCxXdDWRnPpvhAwzxe.hats[j]);
		}
		for (int k = 0; k < tvaizqPUvvZWprGvMViCfKjcrxU; k++)
		{
		}
		for (int l = 0; l < cGSyjumLTQpUVIfMWcedauewnOze; l++)
		{
		}
	}

	private void yMmEMHIqZYcuTkSikVFFrOfyKDc()
	{
		if (aORFycYuiaRmVGcJmTzHLSOPUlP != 0)
		{
			HIDButton[] buttons = phkjrlDyMCxXdDWRnPpvhAwzxe.buttons;
			for (int i = 0; i < aORFycYuiaRmVGcJmTzHLSOPUlP; i++)
			{
				KVuvyhSNRPONDOAYhgLMkebqLbF.SetValue(i, buttons[i].rawValue, buttons[i].timestamp);
			}
		}
	}

	private void RnrDpKmoLadDanXnKzyfdWchwqP()
	{
		if (FNTmOAZHUKmnxMXJrfTeCMPQiru != 0)
		{
			for (int i = 0; i < FNTmOAZHUKmnxMXJrfTeCMPQiru; i++)
			{
				JqcYNdZBLMiMnIReregnHWWiSPbQ[i].tMdVaanieZgMNBPWABQFUSWqJtyN = (uint)phkjrlDyMCxXdDWRnPpvhAwzxe.hats[i].rawValue;
				rnFMvfxBLbTUThhFqyHVxkffhcZ[i] = JqcYNdZBLMiMnIReregnHWWiSPbQ[i].value;
			}
		}
	}

	private void VVKAQHjDQMZyRjqEMoRgsckjyIh()
	{
		if (UVyastEWXnpXcGdBaPvEGhpEVnsp != 0)
		{
			for (int i = 0; i < UVyastEWXnpXcGdBaPvEGhpEVnsp; i++)
			{
				MZJVdlKarxDQpTBCVESaHqIzDHs[i].tMdVaanieZgMNBPWABQFUSWqJtyN = (uint)phkjrlDyMCxXdDWRnPpvhAwzxe.axes[i].rawValue;
			}
		}
	}

	private xeDXAkGcMzNhIAYbhjotXWERSKg sDKQiRpFiIxEyMnCwEmsBmdUrgwN(HIDAxis P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new xeDXAkGcMzNhIAYbhjotXWERSKg(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0, TtkWfAxSfFGpHWxqDTvJlooeIGU.XDThFkfgVacanEJPWpRtmsozsnY(P_0.hidInfo.usagePage, P_0.hidInfo.usage));
	}

	private RsqggZFhRByEelmowNLCCsnWtKZD CwOMkISLjasYpIVUGGntXgiVEiP(HIDHat P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new RsqggZFhRByEelmowNLCCsnWtKZD(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0);
	}

	protected override void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			euujVPFzGztViWDbYvUutBvFQFP = true;
			base.KRgasgBmyLeCeDGJhNGqwMeOqCwJ(P_0);
		}
	}
}
