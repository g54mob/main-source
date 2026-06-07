using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class srlBRtRclsWYTCTseoEJvfJUEIIJA : tSweDkFeXniaTDvgaFLsJqqvZqSjB, bZTYrShHWPAVFFKErndDmtappVZBb, JxNBuWiUVLLxDhBRNHQJUywWuQkH, IDisposable
{
	public readonly int tNdfRZOQMGImuTlCigbZvskbKYGk;

	public readonly int DLAsyflvgTkmHSAynXgUnJmClojt;

	public readonly int SXNUpdAAKlnYvTfpKTnPzdkSgLBcA;

	public readonly int MvQpKFAviYNTKIPpJoBcXvLVEvts;

	public readonly short[] iDrVnmBkHhbWQqpbgJjoyLgbSCPo;

	private readonly ButtonLoopSet QIeZdxXLYBVCVICorMFkwXakeqLM;

	public readonly short[] CbjbHAOOGlxOCRgLQfDdTaRIGetz;

	public readonly short[] sZmICZqSEASunOtAIxiDeKbXQEHv;

	private bool AvPCtBHztKNjmcJYDXpMgCuMgdzAb;

	public bool[] zFIQHKtjhLhKsIHQCOlRVldSmZwe
	{
		get
		{
			if (QIeZdxXLYBVCVICorMFkwXakeqLM.Current == null)
			{
				return null;
			}
			return QIeZdxXLYBVCVICorMFkwXakeqLM.Current.effectiveValue;
		}
	}

	int bZTYrShHWPAVFFKErndDmtappVZBb.rEgQttkGsqEyWkRtaAAjiWYpFKbVA => zYYgqhwkGDBNRFRrTuJySIaIjkCq;

	int bZTYrShHWPAVFFKErndDmtappVZBb.zwyTEiDwdysaDGFcBBEDcpunXvxJ => tNdfRZOQMGImuTlCigbZvskbKYGk;

	int bZTYrShHWPAVFFKErndDmtappVZBb.JOVelaFpRMFSmeWVMClOPWQEbGLcA => DLAsyflvgTkmHSAynXgUnJmClojt;

	int bZTYrShHWPAVFFKErndDmtappVZBb.IjOsflQiuAfZAntPWKaCseaEcQXi => SXNUpdAAKlnYvTfpKTnPzdkSgLBcA;

	int bZTYrShHWPAVFFKErndDmtappVZBb.kxXAHucobebRNYVSfXiDnHUrdUdGb => MvQpKFAviYNTKIPpJoBcXvLVEvts;

	bool bZTYrShHWPAVFFKErndDmtappVZBb.KrpeqOqdHnsgfKNdIgVrFmiIhSKK
	{
		get
		{
			if (tNdfRZOQMGImuTlCigbZvskbKYGk <= 0 && DLAsyflvgTkmHSAynXgUnJmClojt <= 0 && SXNUpdAAKlnYvTfpKTnPzdkSgLBcA <= 0)
			{
				return MvQpKFAviYNTKIPpJoBcXvLVEvts > 0;
			}
			return true;
		}
	}

	InputSource bZTYrShHWPAVFFKErndDmtappVZBb.dOsRtkKERzDSgAwUkftMpDqoPlDr => InputSource.SDL2;

	bool bZTYrShHWPAVFFKErndDmtappVZBb.UtLknDaepYdddAhYjwCyupAPMnHHb => AvPCtBHztKNjmcJYDXpMgCuMgdzAb;

	public srlBRtRclsWYTCTseoEJvfJUEIIJA(vmufigtVdJbTCNnGOSszzPPMTDbm P_0, LbOGBSopwOVdYGqFwBwchyJXbQKgA P_1)
		: this(P_0, P_1, HcQIMNRtzDUkxUXAxrbjcqZXaHV.Joystick)
	{
	}

	protected srlBRtRclsWYTCTseoEJvfJUEIIJA(vmufigtVdJbTCNnGOSszzPPMTDbm P_0, LbOGBSopwOVdYGqFwBwchyJXbQKgA P_1, HcQIMNRtzDUkxUXAxrbjcqZXaHV P_2)
		: this(P_0, P_1, P_2, P_1.XMXtOZCmKaGJOiTiaduEIMOUnIzAA, P_1.tXnEOVWAmENiSGwvEpZeiHTYZgTd, P_1.NIcGGHCFYtqmZwdvXtwgQHWbvukD, P_1.hCiaKThjLLJDFxywbfnkKUCPZhdNA)
	{
	}

	protected srlBRtRclsWYTCTseoEJvfJUEIIJA(pUIxFiKcKXPiYfHrwTWPwYsMcOJx P_0, LbOGBSopwOVdYGqFwBwchyJXbQKgA P_1, HcQIMNRtzDUkxUXAxrbjcqZXaHV P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		tNdfRZOQMGImuTlCigbZvskbKYGk = P_3;
		DLAsyflvgTkmHSAynXgUnJmClojt = P_4;
		SXNUpdAAKlnYvTfpKTnPzdkSgLBcA = P_5;
		MvQpKFAviYNTKIPpJoBcXvLVEvts = P_6;
		if (P_4 > 0)
		{
			iDrVnmBkHhbWQqpbgJjoyLgbSCPo = new short[P_4];
		}
		QIeZdxXLYBVCVICorMFkwXakeqLM = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			CbjbHAOOGlxOCRgLQfDdTaRIGetz = new short[P_5];
		}
		if (P_6 > 0)
		{
			sZmICZqSEASunOtAIxiDeKbXQEHv = new short[P_6 * 2];
		}
	}

	public void WODITJAaSHtLwbyxrTLEkHPYAvMcA(dstbaIewkvGVrkHumIlsJRjhZXNo P_0, byte P_1, short P_2, double P_3)
	{
		AvPCtBHztKNjmcJYDXpMgCuMgdzAb = true;
		switch (P_0)
		{
		case dstbaIewkvGVrkHumIlsJRjhZXNo.Button:
			if (P_1 < tNdfRZOQMGImuTlCigbZvskbKYGk)
			{
				QIeZdxXLYBVCVICorMFkwXakeqLM.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case dstbaIewkvGVrkHumIlsJRjhZXNo.Axis:
			if (P_1 < DLAsyflvgTkmHSAynXgUnJmClojt)
			{
				iDrVnmBkHhbWQqpbgJjoyLgbSCPo[P_1] = P_2;
			}
			break;
		case dstbaIewkvGVrkHumIlsJRjhZXNo.Hat:
			if (P_1 < SXNUpdAAKlnYvTfpKTnPzdkSgLBcA)
			{
				CbjbHAOOGlxOCRgLQfDdTaRIGetz[P_1] = P_2;
			}
			break;
		case dstbaIewkvGVrkHumIlsJRjhZXNo.Ball:
			if (P_1 < MvQpKFAviYNTKIPpJoBcXvLVEvts)
			{
				sZmICZqSEASunOtAIxiDeKbXQEHv[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void uLMszpCzPSSeaoTlWbhgIQyhXTUK(UpdateLoopType P_0)
	{
		QIeZdxXLYBVCVICorMFkwXakeqLM.SetUpdateLoop(P_0);
	}

	public override void GOdWujvaycYgUpnxImzhAHzfdFNo()
	{
		QIeZdxXLYBVCVICorMFkwXakeqLM.Current.ClearWasTrueThisFrame();
	}

	public float MyBDozCjSJRvPujaAFsKQLtInfLEA(int P_0)
	{
		if (P_0 < 0 || P_0 >= DLAsyflvgTkmHSAynXgUnJmClojt)
		{
			return 0f;
		}
		return iaAREyyZGRAIDjnyxELSEsOsEUPaA(iDrVnmBkHhbWQqpbgJjoyLgbSCPo[P_0]);
	}

	float bZTYrShHWPAVFFKErndDmtappVZBb.MyBDozCjSJRvPujaAFsKQLtInfLEA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in MyBDozCjSJRvPujaAFsKQLtInfLEA
		return this.MyBDozCjSJRvPujaAFsKQLtInfLEA(P_0);
	}

	public int VAomOvSjlJKyMVDwtHhuguUGxsjF(int P_0)
	{
		if (P_0 < 0 || P_0 >= DLAsyflvgTkmHSAynXgUnJmClojt)
		{
			return 0;
		}
		return iDrVnmBkHhbWQqpbgJjoyLgbSCPo[P_0];
	}

	int bZTYrShHWPAVFFKErndDmtappVZBb.VAomOvSjlJKyMVDwtHhuguUGxsjF(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in VAomOvSjlJKyMVDwtHhuguUGxsjF
		return this.VAomOvSjlJKyMVDwtHhuguUGxsjF(P_0);
	}

	public bool YcWYvCtzIlmFqZECZGVqAtJKDRkw(int P_0)
	{
		if (P_0 < 0 || P_0 >= tNdfRZOQMGImuTlCigbZvskbKYGk)
		{
			return false;
		}
		return QIeZdxXLYBVCVICorMFkwXakeqLM.Current.effectiveValue[P_0];
	}

	bool bZTYrShHWPAVFFKErndDmtappVZBb.YcWYvCtzIlmFqZECZGVqAtJKDRkw(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YcWYvCtzIlmFqZECZGVqAtJKDRkw
		return this.YcWYvCtzIlmFqZECZGVqAtJKDRkw(P_0);
	}

	public int sYRfvnYhjZzejuVTptcEPhUtyWll(int P_0)
	{
		if (P_0 < 0 || P_0 >= SXNUpdAAKlnYvTfpKTnPzdkSgLBcA)
		{
			return -1;
		}
		return peeAKBuxdtaPebaNsltjCifyqTSBb(CbjbHAOOGlxOCRgLQfDdTaRIGetz[P_0]);
	}

	int bZTYrShHWPAVFFKErndDmtappVZBb.sYRfvnYhjZzejuVTptcEPhUtyWll(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in sYRfvnYhjZzejuVTptcEPhUtyWll
		return this.sYRfvnYhjZzejuVTptcEPhUtyWll(P_0);
	}

	public Vector2 TWgmNsOFTRQbYplshjcrkdZPFqpeA(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 bZTYrShHWPAVFFKErndDmtappVZBb.TWgmNsOFTRQbYplshjcrkdZPFqpeA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TWgmNsOFTRQbYplshjcrkdZPFqpeA
		return this.TWgmNsOFTRQbYplshjcrkdZPFqpeA(P_0);
	}

	protected void EGnVfYXCmDYRrlwZVcgKCwHacQnp(vmufigtVdJbTCNnGOSszzPPMTDbm P_0)
	{
		if (!base.DvdJYCQRAcBNHSfnNvdmBVWrHJVT || HbXxmfJswkPCGAKIoZSlrDDopjDd.JxvPxfEzgAzIlVdEvhNBFcNLzSht(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = HbXxmfJswkPCGAKIoZSlrDDopjDd.wDacvHnnaStbxYQMuNYEXvOAxsak(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (HbXxmfJswkPCGAKIoZSlrDDopjDd.uFiIDgcGuZOLsrAxyDAQMrGRGiEj(intPtr) != 0)
		{
			HbXxmfJswkPCGAKIoZSlrDDopjDd.INcPuYkxWzvBizqJNyPSIjroEJJi(intPtr);
			return;
		}
		zpcNUdOnFysBMrnTIZaLQaXPlnfc = new wmfVNnLkVQxJOoIMbfOsAWwWQHFhA(intPtr);
		saVemFfZMXBVuuyZZbONzqVXDsoFb = true;
		sLZuZuvdXtIFnfSDvbFwrmjwiviD = HbXxmfJswkPCGAKIoZSlrDDopjDd.fCDqlrOxcDKbJjvhvbhqPPnorEJu(zpcNUdOnFysBMrnTIZaLQaXPlnfc) > 0;
		if (sLZuZuvdXtIFnfSDvbFwrmjwiviD)
		{
			JhcSiOncSaChWaNuoiuEKbQUWUho = 2;
		}
		YAWvnzXvkxsmmLKwZixaPTcRCMRe = new float[JhcSiOncSaChWaNuoiuEKbQUWUho];
	}

	protected virtual void airERvcRKKkgOGYqeuJlbQHzdnXXB()
	{
		EGnVfYXCmDYRrlwZVcgKCwHacQnp(qUGxRMCLNlTicqeaAhdHqKYqxfNp as vmufigtVdJbTCNnGOSszzPPMTDbm);
	}

	protected virtual void oqsDSFmOjmDHtHjacweaeCRoTkzt()
	{
		if (qUGxRMCLNlTicqeaAhdHqKYqxfNp != null && qUGxRMCLNlTicqeaAhdHqKYqxfNp.IsValid)
		{
			if (!uQKLSzgeHxXBGldSrCjaWIubGCAGA())
			{
				qUGxRMCLNlTicqeaAhdHqKYqxfNp.Clear();
				return;
			}
			HbXxmfJswkPCGAKIoZSlrDDopjDd.cJSmdTuRmGeoXAhdGqmtZkaoNAtC(qUGxRMCLNlTicqeaAhdHqKYqxfNp);
			qUGxRMCLNlTicqeaAhdHqKYqxfNp.Clear();
		}
	}

	private float iaAREyyZGRAIDjnyxELSEsOsEUPaA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int peeAKBuxdtaPebaNsltjCifyqTSBb(short P_0)
	{
		return P_0 switch
		{
			0 => -1, 
			1 => 0, 
			3 => 4500, 
			2 => 9000, 
			6 => 13500, 
			4 => 18000, 
			12 => 22500, 
			8 => 27000, 
			9 => 31500, 
			_ => -1, 
		};
	}
}
