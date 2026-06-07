using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class kKcUrlWIsWzJKGjtCfpCJSdZBisp : xwhNMwlpOZCJYxhvnbudgAISfUwqA, lCQLyMgHDpqaOULHBFMANOWmXxtv, XaYtAMfNAlqwErHCneQOyDUJCUMn, IDisposable
{
	public readonly int bUqtKZJePaVLrZrNOpSYJHAiYaeU;

	public readonly int LsRErjCuftUPKQXdPGLTFVSZDONmA;

	public readonly int OrGDcbZWRRarkVisuXGQTzAXdpzw;

	public readonly int UBLfDVjFdsXaRlGutoojVhzYNXHz;

	public readonly short[] qxafekImANohTsxoEMKrMqEkoedv;

	private readonly ButtonLoopSet IcziibGFVxUbWIwzZsojIZMvPMns;

	public readonly short[] OXkbaMReFViURGTQyXmwNbjVVEXsA;

	public readonly short[] iWzzXBrYJatPwCFRslLIGNLQqcto;

	private bool EYGpaNwdqyBWbHDDleYFMmALUJTkA;

	public bool[] lCRBWIqOydQFdSfKghRAjqDHMJMI
	{
		get
		{
			if (IcziibGFVxUbWIwzZsojIZMvPMns.Current == null)
			{
				return null;
			}
			return IcziibGFVxUbWIwzZsojIZMvPMns.Current.effectiveValue;
		}
	}

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.vllgqxeztWDZNRaoKPpuBsywDiBNA => vvJWlppaBxokUFlyhsSxsdOLUSmL;

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.dahIaSGoaIDWrGxYtzIOMCjwzZhc => bUqtKZJePaVLrZrNOpSYJHAiYaeU;

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.XUYTkcUpOkSjfgZIgPGHrOqJeizIA => LsRErjCuftUPKQXdPGLTFVSZDONmA;

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.APLxtjPBfoeYNbXciCvDMdMVdSxgA => OrGDcbZWRRarkVisuXGQTzAXdpzw;

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.cQCmOitriQFgSNYLNrHInkeqzeDS => UBLfDVjFdsXaRlGutoojVhzYNXHz;

	bool lCQLyMgHDpqaOULHBFMANOWmXxtv.YxeuxOxPMHfRyYOmopyqrDCNHBoDA
	{
		get
		{
			if (bUqtKZJePaVLrZrNOpSYJHAiYaeU <= 0 && LsRErjCuftUPKQXdPGLTFVSZDONmA <= 0 && OrGDcbZWRRarkVisuXGQTzAXdpzw <= 0)
			{
				return UBLfDVjFdsXaRlGutoojVhzYNXHz > 0;
			}
			return true;
		}
	}

	InputSource lCQLyMgHDpqaOULHBFMANOWmXxtv.pihKFmBfWRzmnOtZWSZFZFYbRRdj => InputSource.SDL2;

	bool lCQLyMgHDpqaOULHBFMANOWmXxtv.KqSXyBzaskeQyDdLJMhbAXkAwLtAb => EYGpaNwdqyBWbHDDleYFMmALUJTkA;

	public kKcUrlWIsWzJKGjtCfpCJSdZBisp(rFjcmnamizCDRXHkylGeDAfLtBXI P_0, PHTwOSfBtovGZIvMEGVvQSdSiweP P_1)
		: this(P_0, P_1, PulXWEOduVlrzduSmShwZWWQAslI.Joystick)
	{
	}

	protected kKcUrlWIsWzJKGjtCfpCJSdZBisp(rFjcmnamizCDRXHkylGeDAfLtBXI P_0, PHTwOSfBtovGZIvMEGVvQSdSiweP P_1, PulXWEOduVlrzduSmShwZWWQAslI P_2)
		: this(P_0, P_1, P_2, P_1.JGOEXFNTROTsVZhtIBVXoNqJekNHA, P_1.bEoaJDRrRsaiFOOvmwQxImdBIrrDA, P_1.RppTUTTXDNJXCoIcvEehkmncDUOG, P_1.twtkZFgeUjZiWqGpTnElgmaCENXW)
	{
	}

	protected kKcUrlWIsWzJKGjtCfpCJSdZBisp(tyHgSuZQJteHFrsuWyxSQQUVqmjp P_0, PHTwOSfBtovGZIvMEGVvQSdSiweP P_1, PulXWEOduVlrzduSmShwZWWQAslI P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		bUqtKZJePaVLrZrNOpSYJHAiYaeU = P_3;
		LsRErjCuftUPKQXdPGLTFVSZDONmA = P_4;
		OrGDcbZWRRarkVisuXGQTzAXdpzw = P_5;
		UBLfDVjFdsXaRlGutoojVhzYNXHz = P_6;
		if (P_4 > 0)
		{
			qxafekImANohTsxoEMKrMqEkoedv = new short[P_4];
		}
		IcziibGFVxUbWIwzZsojIZMvPMns = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			OXkbaMReFViURGTQyXmwNbjVVEXsA = new short[P_5];
		}
		if (P_6 > 0)
		{
			iWzzXBrYJatPwCFRslLIGNLQqcto = new short[P_6 * 2];
		}
	}

	public void OvIZYBTJRfgspdmoRotRMDxXfTmu(dVoLlUxjpPIyeHjpWVGrrnZugrtEA P_0, byte P_1, short P_2, double P_3)
	{
		EYGpaNwdqyBWbHDDleYFMmALUJTkA = true;
		switch (P_0)
		{
		case dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Button:
			if (P_1 < bUqtKZJePaVLrZrNOpSYJHAiYaeU)
			{
				IcziibGFVxUbWIwzZsojIZMvPMns.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Axis:
			if (P_1 < LsRErjCuftUPKQXdPGLTFVSZDONmA)
			{
				qxafekImANohTsxoEMKrMqEkoedv[P_1] = P_2;
			}
			break;
		case dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Hat:
			if (P_1 < OrGDcbZWRRarkVisuXGQTzAXdpzw)
			{
				OXkbaMReFViURGTQyXmwNbjVVEXsA[P_1] = P_2;
			}
			break;
		case dVoLlUxjpPIyeHjpWVGrrnZugrtEA.Ball:
			if (P_1 < UBLfDVjFdsXaRlGutoojVhzYNXHz)
			{
				iWzzXBrYJatPwCFRslLIGNLQqcto[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void ysNEkdGLMkePtPsqedItvoKcsruIA(UpdateLoopType P_0)
	{
		IcziibGFVxUbWIwzZsojIZMvPMns.SetUpdateLoop(P_0);
	}

	public override void SimGblmedMBHJjvkceQgVkDenbxFb()
	{
		IcziibGFVxUbWIwzZsojIZMvPMns.Current.ClearWasTrueThisFrame();
	}

	public float IRCOxjmQZnhKIxwfgBXDrHPVqDlW(int P_0)
	{
		if (P_0 < 0 || P_0 >= LsRErjCuftUPKQXdPGLTFVSZDONmA)
		{
			return 0f;
		}
		return yWBdRgjTHbzhSvMrPngReMsfysbT(qxafekImANohTsxoEMKrMqEkoedv[P_0]);
	}

	float lCQLyMgHDpqaOULHBFMANOWmXxtv.IRCOxjmQZnhKIxwfgBXDrHPVqDlW(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IRCOxjmQZnhKIxwfgBXDrHPVqDlW
		return this.IRCOxjmQZnhKIxwfgBXDrHPVqDlW(P_0);
	}

	public int DnXpbtXsfVvXoNpVautoGmZRZDlA(int P_0)
	{
		if (P_0 < 0 || P_0 >= LsRErjCuftUPKQXdPGLTFVSZDONmA)
		{
			return 0;
		}
		return qxafekImANohTsxoEMKrMqEkoedv[P_0];
	}

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.DnXpbtXsfVvXoNpVautoGmZRZDlA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in DnXpbtXsfVvXoNpVautoGmZRZDlA
		return this.DnXpbtXsfVvXoNpVautoGmZRZDlA(P_0);
	}

	public bool KwXNrSaFANZntFTMhaixcdxLvBGd(int P_0)
	{
		if (P_0 < 0 || P_0 >= bUqtKZJePaVLrZrNOpSYJHAiYaeU)
		{
			return false;
		}
		return IcziibGFVxUbWIwzZsojIZMvPMns.Current.effectiveValue[P_0];
	}

	bool lCQLyMgHDpqaOULHBFMANOWmXxtv.KwXNrSaFANZntFTMhaixcdxLvBGd(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in KwXNrSaFANZntFTMhaixcdxLvBGd
		return this.KwXNrSaFANZntFTMhaixcdxLvBGd(P_0);
	}

	public int gcOmbQXuvnYesuYIFMRRxyHqKXwB(int P_0)
	{
		if (P_0 < 0 || P_0 >= OrGDcbZWRRarkVisuXGQTzAXdpzw)
		{
			return -1;
		}
		return xXfkFXzgaHNsvwCYGFWkDORnltcHA(OXkbaMReFViURGTQyXmwNbjVVEXsA[P_0]);
	}

	int lCQLyMgHDpqaOULHBFMANOWmXxtv.gcOmbQXuvnYesuYIFMRRxyHqKXwB(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in gcOmbQXuvnYesuYIFMRRxyHqKXwB
		return this.gcOmbQXuvnYesuYIFMRRxyHqKXwB(P_0);
	}

	public Vector2 TtbbKgjXGhNSVrrrVtNuoIfUwUNY(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 lCQLyMgHDpqaOULHBFMANOWmXxtv.TtbbKgjXGhNSVrrrVtNuoIfUwUNY(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TtbbKgjXGhNSVrrrVtNuoIfUwUNY
		return this.TtbbKgjXGhNSVrrrVtNuoIfUwUNY(P_0);
	}

	protected void WZwEqOCBjpzsqhCSddLZhyxlZoTVA(rFjcmnamizCDRXHkylGeDAfLtBXI P_0)
	{
		if (!base.HByARADXLAVsISEmluMzvlmyLfxz || TLgiAoUVfCyIREMLAuHTFAzrCRtx.VQwQBlTBlqUksDcRNBgSbVzShwFN(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = TLgiAoUVfCyIREMLAuHTFAzrCRtx.sxbzDHojaqAkgOFuCgGNbuAHFSMd(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (TLgiAoUVfCyIREMLAuHTFAzrCRtx.ymrVXmlIptnRpbgsIfiHskkMeser(intPtr) != 0)
		{
			TLgiAoUVfCyIREMLAuHTFAzrCRtx.QhxQEEhcBBMurvNIpLHDcbBlEyzm(intPtr);
			return;
		}
		dCqWRQFSmAVqIdzwmyWpwdGSPnJk = new gPcHMpAKSmLgRiOVTnddeLITXhpM(intPtr);
		sDINhVCQNbCijBcUfUvOtAdAlAEeA = true;
		siSnWmmzmHzcmvbNHIsfXgSjjOQR = TLgiAoUVfCyIREMLAuHTFAzrCRtx.tIOGolFVvvFUKDxyNBGlddDJbmvfc(dCqWRQFSmAVqIdzwmyWpwdGSPnJk) > 0;
		if (siSnWmmzmHzcmvbNHIsfXgSjjOQR)
		{
			XkbNWEgLMOYFRoFdQTxBqdyTaDTh = 2;
		}
		QuJidhQvdPLMtNNTzTsrfzlWynlD = new float[XkbNWEgLMOYFRoFdQTxBqdyTaDTh];
	}

	protected virtual void wbasYjURVgBRTGjzQDwsmVzqAXfu()
	{
		WZwEqOCBjpzsqhCSddLZhyxlZoTVA(yoXkAPXKiXqrxsteoCYwQkpjXreB as rFjcmnamizCDRXHkylGeDAfLtBXI);
	}

	protected virtual void cWtuFNfEkCQimTLpAyPlGVvbnOXN()
	{
		if (yoXkAPXKiXqrxsteoCYwQkpjXreB != null && yoXkAPXKiXqrxsteoCYwQkpjXreB.IsValid)
		{
			if (!gNDBYxbDWVDsZelLVpIbaqKqKamZ())
			{
				yoXkAPXKiXqrxsteoCYwQkpjXreB.Clear();
				return;
			}
			TLgiAoUVfCyIREMLAuHTFAzrCRtx.kqHlAPtBQqZvzUUuePrzdRUjhyVi(yoXkAPXKiXqrxsteoCYwQkpjXreB);
			yoXkAPXKiXqrxsteoCYwQkpjXreB.Clear();
		}
	}

	private float yWBdRgjTHbzhSvMrPngReMsfysbT(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int xXfkFXzgaHNsvwCYGFWkDORnltcHA(short P_0)
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
