using System;
using Rewired;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Utils;

internal class xGZvbflmaFvIVZqDAVLwVcNGzWa : TJDxnkAePbGbioTsrlWNuUKgifD, IDisposable, EorbaTBAfVCiZjvhJJeAhAACxCn, UzKBIaEyudSpXeLmfwTkGCYvktG
{
	private int zYgdsCcaJpNTSfEYZVxDtriUMzyD;

	private kbwNPkkZgMQwtrrUfDtgBehkdCIF ihYfGzzLjPTrFSAtEKJZtmgtaKx;

	private IntPtr PvPkcnoAqkpBCvdNGykzqQnUFSl;

	private ButtonLoopSet XkPfFvfNpIQKgeUUIeMkgPBvSPpG;

	private wYoTldBjcmEPzkyhATJSjejWGKaQ[] XNmArkcXUiiJfexFtPobxeDTpFLF;

	private OwTObMgdIOWMHQqmXdWtBYzFETP[] IVJbokQhfBIWQuWcAQvGrVnzDPd;

	private int[] kuyVymuKhaQhgDgBPCteILKeBaNB;

	private HIDAccelerometer[] yZEOUmxjdvWFhoYnlXkotEVnaYo;

	private HIDGyroscope[] qKlWJbWXIFJLiXsurTaeQjFBABjf;

	private HIDTouchpad[] VmkpkOFKESpUjnGGUxmOmTbWKUJ;

	private int fauThtVRGnbJeqNPRDhsAoxKMINP;

	private int RLJUyVPlihHDAZZZDZrmEOKKpwC;

	private int CUwwwRCEyVjEGwtDSpYBvmyNwZy;

	private int uKOZMkQhcoXLdVVYUOrHIurmNvx;

	private int lsxTcxzlONKCikKKrMeOZFBrgQp;

	private int fgsEDwzeEeMNelWAcjOIOOwoJpk;

	private HidOutputReportHandler IUeZAKgjWNlIXXAjlAIthXMnfrT;

	private saLjtbZSBxlqoNzvuSJHtknSlTo tHjQzDJoPETfYvrWSDkweEMAHFw;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public int JoystickId => zYgdsCcaJpNTSfEYZVxDtriUMzyD;

	public kbwNPkkZgMQwtrrUfDtgBehkdCIF JoystickSourceType => ihYfGzzLjPTrFSAtEKJZtmgtaKx;

	public IntPtr JoystickSourceHandle => PvPkcnoAqkpBCvdNGykzqQnUFSl;

	public bool[] Buttons => XkPfFvfNpIQKgeUUIeMkgPBvSPpG.Current.effectiveValue;

	public int[] HatValues => kuyVymuKhaQhgDgBPCteILKeBaNB;

	public int ButtonCount => fauThtVRGnbJeqNPRDhsAoxKMINP;

	public int AxisCount => RLJUyVPlihHDAZZZDZrmEOKKpwC;

	public int HatCount => CUwwwRCEyVjEGwtDSpYBvmyNwZy;

	public bool HasElements
	{
		get
		{
			if (fauThtVRGnbJeqNPRDhsAoxKMINP <= 0 && RLJUyVPlihHDAZZZDZrmEOKKpwC <= 0)
			{
				return CUwwwRCEyVjEGwtDSpYBvmyNwZy > 0;
			}
			return true;
		}
	}

	public bool SupportsVibration
	{
		get
		{
			if (oQOaImiuMJjIstJUuSXUOWhbMzk == null)
			{
				return false;
			}
			return oQOaImiuMJjIstJUuSXUOWhbMzk.VibrationMotorCount > 0;
		}
	}

	public int VibrationMotorCount
	{
		get
		{
			if (oQOaImiuMJjIstJUuSXUOWhbMzk == null)
			{
				return 0;
			}
			return oQOaImiuMJjIstJUuSXUOWhbMzk.VibrationMotorCount;
		}
	}

	public InputSource InputSource => InputSource.InternalDriver;

	public HidOutputReportHandler HidOutputReportHandler => IUeZAKgjWNlIXXAjlAIthXMnfrT;

	public bbDFITqKYezHstfvOWFmFoaPRag AxesState => tHjQzDJoPETfYvrWSDkweEMAHFw;

	public xGZvbflmaFvIVZqDAVLwVcNGzWa(int joystickId, kbwNPkkZgMQwtrrUfDtgBehkdCIF joystickSourceType, IntPtr joystickSourceHandle, VaqvDpgkuJiGiwrYcarAfGJvBwg hidDevice, HIDDeviceDriver driver, HidOutputReportHandler hidOutputReportHandler)
		: base(hidDevice)
	{
		oQOaImiuMJjIstJUuSXUOWhbMzk = driver;
		IUeZAKgjWNlIXXAjlAIthXMnfrT = hidOutputReportHandler;
		if (oQOaImiuMJjIstJUuSXUOWhbMzk != null)
		{
			OkBfYBgDJSjeKVCaaNbKbSnxxxVj = oQOaImiuMJjIstJUuSXUOWhbMzk.CreateControllerExtension();
		}
		zYgdsCcaJpNTSfEYZVxDtriUMzyD = joystickId;
		ihYfGzzLjPTrFSAtEKJZtmgtaKx = joystickSourceType;
		PvPkcnoAqkpBCvdNGykzqQnUFSl = joystickSourceHandle;
		tHjQzDJoPETfYvrWSDkweEMAHFw = new saLjtbZSBxlqoNzvuSJHtknSlTo();
		TwGNBnrkrsUbMStyBbMSEXKbmTZ();
		tHjQzDJoPETfYvrWSDkweEMAHFw.TRbpaMuAmxtxjkBcFVvXejQApcy();
	}

	public override void CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		base.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
		XkPfFvfNpIQKgeUUIeMkgPBvSPpG.SetUpdateLoop(P_0);
		for (int i = 0; i < lsxTcxzlONKCikKKrMeOZFBrgQp; i++)
		{
			qKlWJbWXIFJLiXsurTaeQjFBABjf[i].Update(P_0);
		}
	}

	void EorbaTBAfVCiZjvhJJeAhAACxCn.CWncwVbJhTWISMonvIVEimpDcKXc(UpdateLoopType P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CWncwVbJhTWISMonvIVEimpDcKXc
		this.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
	}

	public override void gXADYrdzIttymTRoaKqLkIyUtDJ()
	{
		XkPfFvfNpIQKgeUUIeMkgPBvSPpG.Current.ClearWasTrueThisFrame();
	}

	void EorbaTBAfVCiZjvhJJeAhAACxCn.gXADYrdzIttymTRoaKqLkIyUtDJ()
	{
		//ILSpy generated this explicit interface implementation from .override directive in gXADYrdzIttymTRoaKqLkIyUtDJ
		this.gXADYrdzIttymTRoaKqLkIyUtDJ();
	}

	public void HiykjTZubrIXwcnpzwlBuignkIM(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		if (P_1 > 0)
		{
			oQOaImiuMJjIstJUuSXUOWhbMzk.ParseInputReport(P_0, P_1, P_4);
			xHNCeTbZYBVqRMCQRrncKAxpnCcM();
			IhdIeUwZwRLqiJyYdCtNVPXciIb();
			OdGHPBzFxbgVTLazvUAUYzHiwuB();
		}
	}

	void UzKBIaEyudSpXeLmfwTkGCYvktG.HiykjTZubrIXwcnpzwlBuignkIM(IntPtr P_0, int P_1, int P_2, int P_3, double P_4)
	{
		//ILSpy generated this explicit interface implementation from .override directive in HiykjTZubrIXwcnpzwlBuignkIM
		this.HiykjTZubrIXwcnpzwlBuignkIM(P_0, P_1, P_2, P_3, P_4);
	}

	public override void QqViEWwhZaWrvATfPuWfqnkWwbi()
	{
	}

	void EorbaTBAfVCiZjvhJJeAhAACxCn.QqViEWwhZaWrvATfPuWfqnkWwbi()
	{
		//ILSpy generated this explicit interface implementation from .override directive in QqViEWwhZaWrvATfPuWfqnkWwbi
		this.QqViEWwhZaWrvATfPuWfqnkWwbi();
	}

	public override void JkxbMOPQiVSbeNRGETMYZahHimc()
	{
	}

	void EorbaTBAfVCiZjvhJJeAhAACxCn.JkxbMOPQiVSbeNRGETMYZahHimc()
	{
		//ILSpy generated this explicit interface implementation from .override directive in JkxbMOPQiVSbeNRGETMYZahHimc
		this.JkxbMOPQiVSbeNRGETMYZahHimc();
	}

	public override bool pstoeMoNzNWOorGnoIUVfChGZNFf()
	{
		return rYdWhwxECnIItHOggIRnHyqhsm.IsConnected;
	}

	bool EorbaTBAfVCiZjvhJJeAhAACxCn.pstoeMoNzNWOorGnoIUVfChGZNFf()
	{
		//ILSpy generated this explicit interface implementation from .override directive in pstoeMoNzNWOorGnoIUVfChGZNFf
		return this.pstoeMoNzNWOorGnoIUVfChGZNFf();
	}

	public void adyaTeLDJgHxhZocZCoUcxEskgr(int P_0)
	{
		zYgdsCcaJpNTSfEYZVxDtriUMzyD = P_0;
	}

	void UzKBIaEyudSpXeLmfwTkGCYvktG.adyaTeLDJgHxhZocZCoUcxEskgr(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in adyaTeLDJgHxhZocZCoUcxEskgr
		this.adyaTeLDJgHxhZocZCoUcxEskgr(P_0);
	}

	public void BDfABKSWSvgJHmOKusCxrnCPRYP(IntPtr P_0)
	{
		PvPkcnoAqkpBCvdNGykzqQnUFSl = P_0;
	}

	void UzKBIaEyudSpXeLmfwTkGCYvktG.BDfABKSWSvgJHmOKusCxrnCPRYP(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in BDfABKSWSvgJHmOKusCxrnCPRYP
		this.BDfABKSWSvgJHmOKusCxrnCPRYP(P_0);
	}

	private void TwGNBnrkrsUbMStyBbMSEXKbmTZ()
	{
		fauThtVRGnbJeqNPRDhsAoxKMINP = oQOaImiuMJjIstJUuSXUOWhbMzk.ButtonCount;
		RLJUyVPlihHDAZZZDZrmEOKKpwC = oQOaImiuMJjIstJUuSXUOWhbMzk.AxisCount;
		CUwwwRCEyVjEGwtDSpYBvmyNwZy = oQOaImiuMJjIstJUuSXUOWhbMzk.HatCount;
		uKOZMkQhcoXLdVVYUOrHIurmNvx = oQOaImiuMJjIstJUuSXUOWhbMzk.AccelerometerCount;
		lsxTcxzlONKCikKKrMeOZFBrgQp = oQOaImiuMJjIstJUuSXUOWhbMzk.GyroscopeCount;
		fgsEDwzeEeMNelWAcjOIOOwoJpk = oQOaImiuMJjIstJUuSXUOWhbMzk.TouchpadCount;
		XkPfFvfNpIQKgeUUIeMkgPBvSPpG = new ButtonLoopSet(ReInput.configVars.updateLoop, fauThtVRGnbJeqNPRDhsAoxKMINP);
		XNmArkcXUiiJfexFtPobxeDTpFLF = new wYoTldBjcmEPzkyhATJSjejWGKaQ[RLJUyVPlihHDAZZZDZrmEOKKpwC];
		IVJbokQhfBIWQuWcAQvGrVnzDPd = new OwTObMgdIOWMHQqmXdWtBYzFETP[CUwwwRCEyVjEGwtDSpYBvmyNwZy];
		kuyVymuKhaQhgDgBPCteILKeBaNB = new int[CUwwwRCEyVjEGwtDSpYBvmyNwZy];
		ArrayTools.Fill(kuyVymuKhaQhgDgBPCteILKeBaNB, -1);
		yZEOUmxjdvWFhoYnlXkotEVnaYo = oQOaImiuMJjIstJUuSXUOWhbMzk.accelerometers;
		qKlWJbWXIFJLiXsurTaeQjFBABjf = oQOaImiuMJjIstJUuSXUOWhbMzk.gyroscopes;
		VmkpkOFKESpUjnGGUxmOmTbWKUJ = oQOaImiuMJjIstJUuSXUOWhbMzk.touchpads;
		for (int i = 0; i < RLJUyVPlihHDAZZZDZrmEOKKpwC; i++)
		{
			XNmArkcXUiiJfexFtPobxeDTpFLF[i] = xsdOnYmOINGZHcNUVSrBPlIVczw(oQOaImiuMJjIstJUuSXUOWhbMzk.axes[i]);
			tHjQzDJoPETfYvrWSDkweEMAHFw.tecUHhDRfADhQiduDHCWMmKBoGW(XNmArkcXUiiJfexFtPobxeDTpFLF[i]);
		}
		for (int j = 0; j < CUwwwRCEyVjEGwtDSpYBvmyNwZy; j++)
		{
			IVJbokQhfBIWQuWcAQvGrVnzDPd[j] = HHfsiJHzJvUeUsjAdayIwoDEWYB(oQOaImiuMJjIstJUuSXUOWhbMzk.hats[j]);
		}
		for (int k = 0; k < uKOZMkQhcoXLdVVYUOrHIurmNvx; k++)
		{
		}
		for (int l = 0; l < lsxTcxzlONKCikKKrMeOZFBrgQp; l++)
		{
		}
	}

	private void xHNCeTbZYBVqRMCQRrncKAxpnCcM()
	{
		if (fauThtVRGnbJeqNPRDhsAoxKMINP != 0)
		{
			HIDButton[] buttons = oQOaImiuMJjIstJUuSXUOWhbMzk.buttons;
			for (int i = 0; i < fauThtVRGnbJeqNPRDhsAoxKMINP; i++)
			{
				XkPfFvfNpIQKgeUUIeMkgPBvSPpG.SetValue(i, buttons[i].rawValue, buttons[i].timestamp);
			}
		}
	}

	private void OdGHPBzFxbgVTLazvUAUYzHiwuB()
	{
		if (CUwwwRCEyVjEGwtDSpYBvmyNwZy != 0)
		{
			for (int i = 0; i < CUwwwRCEyVjEGwtDSpYBvmyNwZy; i++)
			{
				IVJbokQhfBIWQuWcAQvGrVnzDPd[i].aYGIRtcEyUWEkvIdlycgzgpxzSs = (uint)oQOaImiuMJjIstJUuSXUOWhbMzk.hats[i].rawValue;
				kuyVymuKhaQhgDgBPCteILKeBaNB[i] = IVJbokQhfBIWQuWcAQvGrVnzDPd[i].value;
			}
		}
	}

	private void IhdIeUwZwRLqiJyYdCtNVPXciIb()
	{
		if (RLJUyVPlihHDAZZZDZrmEOKKpwC != 0)
		{
			for (int i = 0; i < RLJUyVPlihHDAZZZDZrmEOKKpwC; i++)
			{
				XNmArkcXUiiJfexFtPobxeDTpFLF[i].aYGIRtcEyUWEkvIdlycgzgpxzSs = (uint)oQOaImiuMJjIstJUuSXUOWhbMzk.axes[i].rawValue;
			}
		}
	}

	private wYoTldBjcmEPzkyhATJSjejWGKaQ xsdOnYmOINGZHcNUVSrBPlIVczw(HIDAxis P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new wYoTldBjcmEPzkyhATJSjejWGKaQ(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0, SZFLyVaNzSdOsaspaPpaYDJlIGK.GpwfHxyLvpXeEkcBtcrSTURqYnA(P_0.hidInfo.usagePage, P_0.hidInfo.usage));
	}

	private OwTObMgdIOWMHQqmXdWtBYzFETP HHfsiJHzJvUeUsjAdayIwoDEWYB(HIDHat P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return new OwTObMgdIOWMHQqmXdWtBYzFETP(P_0.reportId, P_0.hidInfo.usagePage, P_0.hidInfo.usage, P_0.hidInfo.dataIndex, P_0.hidInfo.bitSize, P_0.hidInfo.logicalMin, P_0.hidInfo.logicalMax, P_0.hidInfo.physicalMin, P_0.hidInfo.physicalMax, P_0.hidInfo.units, P_0.hidInfo.unitsExp, 0);
	}

	protected override void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
			base.LLOFbzNISIbRkZTwkaVnsPpYig(P_0);
		}
	}
}
