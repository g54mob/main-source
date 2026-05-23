using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class QybEXzfcnDxYBdLOCnYSjOfYiCNyA : ZMwBJcBaNMCqBhgMrqHnKJSDNmRtA, XAZzsMQMImLcZRwmVzOOEmMtHEOJ, rEXGaKhLHwvFBakzfgVQFrCIIsrYb, IDisposable
{
	public readonly int PgtZPSzCBlmeBSkDAbiOWKtdOsDC;

	public readonly int lrIacjSDqmcmJTCIBwcHOlKMaAyL;

	public readonly int iLXdJzfmGSQIvKxXcbVIMqMABXCg;

	public readonly int yJACPFjCslBNETlPzNfhgtjHdKsF;

	public readonly short[] KJtrfacpPOWoCdOZIzdrTxQfOtAh;

	private readonly ButtonLoopSet ybodhvuFUmiKRRMKBmVrZlCaxcMW;

	public readonly short[] kHfQhIpiKAmnIGKlocBcFidUkgwHb;

	public readonly short[] UEcWGDJGQfwtfNmNeqbGNEJPYOEl;

	private bool onXdfHAvflgpkKMypxjZvkMAElev;

	public bool[] NbWKGSEmrattyFyfgfOIiMHGzsny
	{
		get
		{
			if (ybodhvuFUmiKRRMKBmVrZlCaxcMW.Current == null)
			{
				return null;
			}
			return ybodhvuFUmiKRRMKBmVrZlCaxcMW.Current.effectiveValue;
		}
	}

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.FuazTfBEgBksQnjVWQekdSorKnmi => FmKkFlHCEqVqZKXItXClrCWGikTD;

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.BJetBysKtJNcJXJCjbAEKPMjBXcvA => PgtZPSzCBlmeBSkDAbiOWKtdOsDC;

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.xHNfwioLhxUhgxfwkpRRqwjAQCUd => lrIacjSDqmcmJTCIBwcHOlKMaAyL;

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.yOGmorjMedujUoVLuHGDRIOGisKEA => iLXdJzfmGSQIvKxXcbVIMqMABXCg;

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.UlHXucVhhPbRVUkyLPuWsxatqSwo => yJACPFjCslBNETlPzNfhgtjHdKsF;

	bool XAZzsMQMImLcZRwmVzOOEmMtHEOJ.uftiANPPCQmCpHHOyNsygOPCxgLd
	{
		get
		{
			if (PgtZPSzCBlmeBSkDAbiOWKtdOsDC <= 0 && lrIacjSDqmcmJTCIBwcHOlKMaAyL <= 0 && iLXdJzfmGSQIvKxXcbVIMqMABXCg <= 0)
			{
				return yJACPFjCslBNETlPzNfhgtjHdKsF > 0;
			}
			return true;
		}
	}

	InputSource XAZzsMQMImLcZRwmVzOOEmMtHEOJ.BWecDgkvBWLCkxXkKOnXEMAgfdAhb => InputSource.SDL2;

	bool XAZzsMQMImLcZRwmVzOOEmMtHEOJ.guZdRDHtevbfroueBYrNAqDFlMEc => onXdfHAvflgpkKMypxjZvkMAElev;

	public QybEXzfcnDxYBdLOCnYSjOfYiCNyA(HxuTdcCdfitpMWSaqHOcYRpUyViO P_0, lEXUOZyrtptSFduQgbxDtqJIFtc P_1)
		: this(P_0, P_1, zIchEEylnWZQwkRvsjjyYsYLFsUQ.Joystick)
	{
	}

	protected QybEXzfcnDxYBdLOCnYSjOfYiCNyA(HxuTdcCdfitpMWSaqHOcYRpUyViO P_0, lEXUOZyrtptSFduQgbxDtqJIFtc P_1, zIchEEylnWZQwkRvsjjyYsYLFsUQ P_2)
		: this(P_0, P_1, P_2, P_1.xaFCqVfuYPPZYAWPQgdNpgdYGngE, P_1.HelnMFnZCbVTCBEOyjdnjFdMoTAtA, P_1.vpyKIZrHOUkyVjQPhuddtTzxnrnN, P_1.JHyGyDWWPkLfNdXYLnZhbtmFjqyE)
	{
	}

	protected QybEXzfcnDxYBdLOCnYSjOfYiCNyA(BJWNVqtUIwgCMaURYKTUPMOKOoCl P_0, lEXUOZyrtptSFduQgbxDtqJIFtc P_1, zIchEEylnWZQwkRvsjjyYsYLFsUQ P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		PgtZPSzCBlmeBSkDAbiOWKtdOsDC = P_3;
		lrIacjSDqmcmJTCIBwcHOlKMaAyL = P_4;
		iLXdJzfmGSQIvKxXcbVIMqMABXCg = P_5;
		yJACPFjCslBNETlPzNfhgtjHdKsF = P_6;
		if (P_4 > 0)
		{
			KJtrfacpPOWoCdOZIzdrTxQfOtAh = new short[P_4];
		}
		ybodhvuFUmiKRRMKBmVrZlCaxcMW = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			kHfQhIpiKAmnIGKlocBcFidUkgwHb = new short[P_5];
		}
		if (P_6 > 0)
		{
			UEcWGDJGQfwtfNmNeqbGNEJPYOEl = new short[P_6 * 2];
		}
	}

	public void mOPJTZrCloNifgRBRLJuBvjQfaBD(LGtssOHZcSDfhUlYEjzhcVhlTpEE P_0, byte P_1, short P_2, double P_3)
	{
		onXdfHAvflgpkKMypxjZvkMAElev = true;
		switch (P_0)
		{
		case LGtssOHZcSDfhUlYEjzhcVhlTpEE.Button:
			if (P_1 < PgtZPSzCBlmeBSkDAbiOWKtdOsDC)
			{
				ybodhvuFUmiKRRMKBmVrZlCaxcMW.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case LGtssOHZcSDfhUlYEjzhcVhlTpEE.Axis:
			if (P_1 < lrIacjSDqmcmJTCIBwcHOlKMaAyL)
			{
				KJtrfacpPOWoCdOZIzdrTxQfOtAh[P_1] = P_2;
			}
			break;
		case LGtssOHZcSDfhUlYEjzhcVhlTpEE.Hat:
			if (P_1 < iLXdJzfmGSQIvKxXcbVIMqMABXCg)
			{
				kHfQhIpiKAmnIGKlocBcFidUkgwHb[P_1] = P_2;
			}
			break;
		case LGtssOHZcSDfhUlYEjzhcVhlTpEE.Ball:
			if (P_1 < yJACPFjCslBNETlPzNfhgtjHdKsF)
			{
				UEcWGDJGQfwtfNmNeqbGNEJPYOEl[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public override void SQEvZnxFJxmfctNuqxfbhSKrNDFg(UpdateLoopType P_0)
	{
		ybodhvuFUmiKRRMKBmVrZlCaxcMW.SetUpdateLoop(P_0);
	}

	public override void uUvaTpQKkJckAsqXqfLgjHVtDLYL()
	{
		ybodhvuFUmiKRRMKBmVrZlCaxcMW.Current.ClearWasTrueThisFrame();
	}

	public float wrHBytMpIembXkGKitkRsUTAKnOs(int P_0)
	{
		if (P_0 < 0 || P_0 >= lrIacjSDqmcmJTCIBwcHOlKMaAyL)
		{
			return 0f;
		}
		return UOCQKeFGvyEyJcOfRPRHbkWiYHMe(KJtrfacpPOWoCdOZIzdrTxQfOtAh[P_0]);
	}

	float XAZzsMQMImLcZRwmVzOOEmMtHEOJ.wrHBytMpIembXkGKitkRsUTAKnOs(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in wrHBytMpIembXkGKitkRsUTAKnOs
		return this.wrHBytMpIembXkGKitkRsUTAKnOs(P_0);
	}

	public int zmaSyrjankrICSyQRfFhTbkYsvgP(int P_0)
	{
		if (P_0 < 0 || P_0 >= lrIacjSDqmcmJTCIBwcHOlKMaAyL)
		{
			return 0;
		}
		return KJtrfacpPOWoCdOZIzdrTxQfOtAh[P_0];
	}

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.zmaSyrjankrICSyQRfFhTbkYsvgP(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in zmaSyrjankrICSyQRfFhTbkYsvgP
		return this.zmaSyrjankrICSyQRfFhTbkYsvgP(P_0);
	}

	public bool uOSBAMcEGUxqqIQujeRrJrxKvBpY(int P_0)
	{
		if (P_0 < 0 || P_0 >= PgtZPSzCBlmeBSkDAbiOWKtdOsDC)
		{
			return false;
		}
		return ybodhvuFUmiKRRMKBmVrZlCaxcMW.Current.effectiveValue[P_0];
	}

	bool XAZzsMQMImLcZRwmVzOOEmMtHEOJ.uOSBAMcEGUxqqIQujeRrJrxKvBpY(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in uOSBAMcEGUxqqIQujeRrJrxKvBpY
		return this.uOSBAMcEGUxqqIQujeRrJrxKvBpY(P_0);
	}

	public int IEBufnfPlyqdpjWvDhhVgnufCwcCA(int P_0)
	{
		if (P_0 < 0 || P_0 >= iLXdJzfmGSQIvKxXcbVIMqMABXCg)
		{
			return -1;
		}
		return BgwWDRHypUNRyjSrUrIqXjRiNZPh(kHfQhIpiKAmnIGKlocBcFidUkgwHb[P_0]);
	}

	int XAZzsMQMImLcZRwmVzOOEmMtHEOJ.IEBufnfPlyqdpjWvDhhVgnufCwcCA(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IEBufnfPlyqdpjWvDhhVgnufCwcCA
		return this.IEBufnfPlyqdpjWvDhhVgnufCwcCA(P_0);
	}

	public Vector2 hloNfsbCRgbfUorQZmpePcjHdaes(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 XAZzsMQMImLcZRwmVzOOEmMtHEOJ.hloNfsbCRgbfUorQZmpePcjHdaes(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in hloNfsbCRgbfUorQZmpePcjHdaes
		return this.hloNfsbCRgbfUorQZmpePcjHdaes(P_0);
	}

	protected void oGppeGgskeZIbghvjBsRdmzouCcu(HxuTdcCdfitpMWSaqHOcYRpUyViO P_0)
	{
		if (!base.tZtAUglChTRFLNRVljFbecXdJLYc || tOngruuekVuFUFicELTBAbvqjfEu.bSffBjEtefxpvBAoNZXCPwbZqWupA(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = tOngruuekVuFUFicELTBAbvqjfEu.UDgbqFJAgbshbrPyKCVJpsgOXbxnA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (tOngruuekVuFUFicELTBAbvqjfEu.MsaLQuREiwWOgeHXQpDLvdgTwYXl(intPtr) != 0)
		{
			tOngruuekVuFUFicELTBAbvqjfEu.wUibLWGVSYArktudjwgHCvZwtUCoA(intPtr);
			return;
		}
		XGbfPCtFnZluZmuVgQTzzcMNQtox = new MnxHDjqnTrDMQzeuBHOvvnESbJCcA(intPtr);
		IhDyJRyGOkdBmbifttSARmzRAsjZ = true;
		ITPMyqGuzSNUlaAyNtphAnOwrajx = tOngruuekVuFUFicELTBAbvqjfEu.RwTpPnjbmanqTeaFLxcjqrNsSkOf(XGbfPCtFnZluZmuVgQTzzcMNQtox) > 0;
		if (ITPMyqGuzSNUlaAyNtphAnOwrajx)
		{
			taiDSYdUODNdYTpEKCeJGfchCMirB = 2;
		}
		sGSxfjkMyQuwgOSgjpupomxTSwUL = new float[taiDSYdUODNdYTpEKCeJGfchCMirB];
	}

	protected virtual void SbffXxcQCjuaSPKOOcLwxElzntWs()
	{
		oGppeGgskeZIbghvjBsRdmzouCcu(QtQydYzXTGaLurqEgifSVJweHpCu as HxuTdcCdfitpMWSaqHOcYRpUyViO);
	}

	protected virtual void SDuANuHzqJFrdAMBUcafNhHswyuE()
	{
		if (QtQydYzXTGaLurqEgifSVJweHpCu != null && QtQydYzXTGaLurqEgifSVJweHpCu.IsValid)
		{
			if (!IyYoJlFrXGoLEiXuVnxzxMEfcOFp())
			{
				QtQydYzXTGaLurqEgifSVJweHpCu.Clear();
				return;
			}
			tOngruuekVuFUFicELTBAbvqjfEu.IRCiqZRLFjkcgHHVmbwpeqManJqXA(QtQydYzXTGaLurqEgifSVJweHpCu);
			QtQydYzXTGaLurqEgifSVJweHpCu.Clear();
		}
	}

	private float UOCQKeFGvyEyJcOfRPRHbkWiYHMe(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int BgwWDRHypUNRyjSrUrIqXjRiNZPh(short P_0)
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
