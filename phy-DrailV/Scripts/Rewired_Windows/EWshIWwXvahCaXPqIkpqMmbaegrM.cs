using System;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal class EWshIWwXvahCaXPqIkpqMmbaegrM : NknEDVXLdriaemqelgeBVJQtENtk, IDisposable, vcOJddXuBPMFeykHjUusxGIgBCDEA, HaOkodQgKHTDiFuGZKtkAaEJxnaG
{
	public readonly int alpbKwLALkCahrtZbQONzDYKzPjn;

	public readonly int hPGYvOJyGRFAXlayNclRbQbgBrho;

	public readonly int GlJwIjJIPZnHArhQuCAwcYBiCWFp;

	public readonly int ScycAvdxNTPWxdRXyYbeGenTtXti;

	public readonly short[] VaqoBlSqHFRmnupsjuqOcfDRcicJ;

	private readonly ButtonLoopSet jVTJAOFxXrJnpRsdXHsxSWlBFJdQ;

	public readonly short[] ubOIojEZmddLMrtoKPCOlkadmdPaA;

	public readonly short[] hwSVFewQpDoFiWIDrOwVZqKZdJe;

	private bool zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

	public bool[] MgRfgnqjhMCTbUOttFrnwOfmcodIA
	{
		get
		{
			if (jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.Current == null)
			{
				return null;
			}
			return jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.Current.effectiveValue;
		}
	}

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.BEwuJlSgrzvnNiHAkXqrckJVpxbD => dyrwQhtCzquFMozPbnrCxDshlZdr;

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.JVqCHAvnctFGSlUdMoFcLkcNXrDA => alpbKwLALkCahrtZbQONzDYKzPjn;

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.OnAwGKsEQkUZSJUZVquvqkbDyaWo => hPGYvOJyGRFAXlayNclRbQbgBrho;

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.nHDbLoGMognNLMuWpWyCEHRJaNibA => GlJwIjJIPZnHArhQuCAwcYBiCWFp;

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.JcdMCwXGnSPkaoYrIrcnBmGOjUZJ => ScycAvdxNTPWxdRXyYbeGenTtXti;

	bool HaOkodQgKHTDiFuGZKtkAaEJxnaG.lirjTskzLLQRcjCiGfspAAltLHNp
	{
		get
		{
			if (alpbKwLALkCahrtZbQONzDYKzPjn <= 0 && hPGYvOJyGRFAXlayNclRbQbgBrho <= 0 && GlJwIjJIPZnHArhQuCAwcYBiCWFp <= 0)
			{
				return ScycAvdxNTPWxdRXyYbeGenTtXti > 0;
			}
			return true;
		}
	}

	InputSource HaOkodQgKHTDiFuGZKtkAaEJxnaG.ETYQlWrHMsDuymSvhSEBrhZjAPnu => InputSource.SDL2;

	bool HaOkodQgKHTDiFuGZKtkAaEJxnaG.LnexytcRMRFtiQTXussUvARXgQwf => zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

	public EWshIWwXvahCaXPqIkpqMmbaegrM(TWdnkNUefXafpcUIoWzOuWtkApCMA P_0, jDJENvVUyUxQxVFZSXsXZjxliNpi P_1)
		: this(P_0, P_1, tKtcBvAetfOINjsFsLWOzIKhGMgOA.Joystick)
	{
	}

	protected EWshIWwXvahCaXPqIkpqMmbaegrM(TWdnkNUefXafpcUIoWzOuWtkApCMA P_0, jDJENvVUyUxQxVFZSXsXZjxliNpi P_1, tKtcBvAetfOINjsFsLWOzIKhGMgOA P_2)
		: this(P_0, P_1, P_2, P_1.alpbKwLALkCahrtZbQONzDYKzPjn, P_1.hPGYvOJyGRFAXlayNclRbQbgBrho, P_1.GlJwIjJIPZnHArhQuCAwcYBiCWFp, P_1.ScycAvdxNTPWxdRXyYbeGenTtXti)
	{
	}

	protected EWshIWwXvahCaXPqIkpqMmbaegrM(PIRQkBrFKZyAzgcnSBxmFgCgtcgM P_0, jDJENvVUyUxQxVFZSXsXZjxliNpi P_1, tKtcBvAetfOINjsFsLWOzIKhGMgOA P_2, int P_3, int P_4, int P_5, int P_6)
		: base(P_0, P_1, P_2)
	{
		alpbKwLALkCahrtZbQONzDYKzPjn = P_3;
		hPGYvOJyGRFAXlayNclRbQbgBrho = P_4;
		GlJwIjJIPZnHArhQuCAwcYBiCWFp = P_5;
		ScycAvdxNTPWxdRXyYbeGenTtXti = P_6;
		if (P_4 > 0)
		{
			VaqoBlSqHFRmnupsjuqOcfDRcicJ = new short[P_4];
		}
		jVTJAOFxXrJnpRsdXHsxSWlBFJdQ = new ButtonLoopSet(ReInput.UserData.ConfigVars.updateLoop, P_3);
		if (P_5 > 0)
		{
			ubOIojEZmddLMrtoKPCOlkadmdPaA = new short[P_5];
		}
		if (P_6 > 0)
		{
			hwSVFewQpDoFiWIDrOwVZqKZdJe = new short[P_6 * 2];
		}
	}

	public void uqcjdwWGLmpPBtHzkpeQnIbXtmIb(BEultZLyaxPADMiYOWRewNKBfupc P_0, byte P_1, short P_2, double P_3)
	{
		zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
		switch (P_0)
		{
		case BEultZLyaxPADMiYOWRewNKBfupc.Button:
			if (P_1 < alpbKwLALkCahrtZbQONzDYKzPjn)
			{
				jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.SetValue(P_1, P_2 > 0, P_3);
			}
			break;
		case BEultZLyaxPADMiYOWRewNKBfupc.Axis:
			if (P_1 < hPGYvOJyGRFAXlayNclRbQbgBrho)
			{
				VaqoBlSqHFRmnupsjuqOcfDRcicJ[P_1] = P_2;
			}
			break;
		case BEultZLyaxPADMiYOWRewNKBfupc.Hat:
			if (P_1 < GlJwIjJIPZnHArhQuCAwcYBiCWFp)
			{
				ubOIojEZmddLMrtoKPCOlkadmdPaA[P_1] = P_2;
			}
			break;
		case BEultZLyaxPADMiYOWRewNKBfupc.Ball:
			if (P_1 < ScycAvdxNTPWxdRXyYbeGenTtXti)
			{
				hwSVFewQpDoFiWIDrOwVZqKZdJe[P_1] = P_2;
			}
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public virtual void mefhGqvTkcrETnFSidhNngFjAYNV(UpdateLoopType P_0)
	{
		jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.SetUpdateLoop(P_0);
	}

	public virtual void MqQjLCryqEPDlgJVxyKAVvUubRHs()
	{
		jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.Current.ClearWasTrueThisFrame();
	}

	public float mkqEwjEWKTccoblNpohIPzhMuvaL(int P_0)
	{
		if (P_0 < 0 || P_0 >= hPGYvOJyGRFAXlayNclRbQbgBrho)
		{
			return 0f;
		}
		return lQhBLBTBBImhLpvHRRScCtbgPtvn(VaqoBlSqHFRmnupsjuqOcfDRcicJ[P_0]);
	}

	float HaOkodQgKHTDiFuGZKtkAaEJxnaG.mkqEwjEWKTccoblNpohIPzhMuvaL(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in mkqEwjEWKTccoblNpohIPzhMuvaL
		return this.mkqEwjEWKTccoblNpohIPzhMuvaL(P_0);
	}

	public int SjSPhYkHEkxjsjZYYzhqNZJnxaSC(int P_0)
	{
		if (P_0 < 0 || P_0 >= hPGYvOJyGRFAXlayNclRbQbgBrho)
		{
			return 0;
		}
		return VaqoBlSqHFRmnupsjuqOcfDRcicJ[P_0];
	}

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.SjSPhYkHEkxjsjZYYzhqNZJnxaSC(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SjSPhYkHEkxjsjZYYzhqNZJnxaSC
		return this.SjSPhYkHEkxjsjZYYzhqNZJnxaSC(P_0);
	}

	public bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(int P_0)
	{
		if (P_0 < 0 || P_0 >= alpbKwLALkCahrtZbQONzDYKzPjn)
		{
			return false;
		}
		return jVTJAOFxXrJnpRsdXHsxSWlBFJdQ.Current.effectiveValue[P_0];
	}

	bool HaOkodQgKHTDiFuGZKtkAaEJxnaG.MSdCYQsaMwqrghCGBIFNcNtyaXdm(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in MSdCYQsaMwqrghCGBIFNcNtyaXdm
		return this.MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0);
	}

	public int bwSacbDVxuNnabflxysnTdPFpaBB(int P_0)
	{
		if (P_0 < 0 || P_0 >= GlJwIjJIPZnHArhQuCAwcYBiCWFp)
		{
			return -1;
		}
		return lMKrBccMDiiDqbzBIVsqqVrKCKGab(ubOIojEZmddLMrtoKPCOlkadmdPaA[P_0]);
	}

	int HaOkodQgKHTDiFuGZKtkAaEJxnaG.bwSacbDVxuNnabflxysnTdPFpaBB(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in bwSacbDVxuNnabflxysnTdPFpaBB
		return this.bwSacbDVxuNnabflxysnTdPFpaBB(P_0);
	}

	public Vector2 MQyhxpOqsaqgIlVqFzoyUdSkjPLT(int P_0)
	{
		return Vector2.zero;
	}

	Vector2 HaOkodQgKHTDiFuGZKtkAaEJxnaG.MQyhxpOqsaqgIlVqFzoyUdSkjPLT(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in MQyhxpOqsaqgIlVqFzoyUdSkjPLT
		return this.MQyhxpOqsaqgIlVqFzoyUdSkjPLT(P_0);
	}

	protected void yllraxQncPWaUZilVxSCBdmsjTjN(TWdnkNUefXafpcUIoWzOuWtkApCMA P_0)
	{
		if (!base.LOAKUriHGZEbByAroDTyQAHhOjqU || predoReysgkDbMHWQjyxbMtjCRqMc.IXrhbVbLpRFlYkVuMXXbedOxARYAb(P_0) <= 0)
		{
			return;
		}
		IntPtr intPtr = predoReysgkDbMHWQjyxbMtjCRqMc.vFGDvrAiMzABHYitPmZzqXnvOLpq(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return;
		}
		if (predoReysgkDbMHWQjyxbMtjCRqMc.QjsjvpwguehPCwOOWBWGhQPflcSMA(intPtr) != 0)
		{
			predoReysgkDbMHWQjyxbMtjCRqMc.OHxgjHNtKJLiuhJYWvpDzOaYdJqFA(intPtr);
			return;
		}
		qyeCrTyMwMbDrFuxtqByujjUFVhu = new CnsOsSaLiIVSvdMuXfiLfOKqhLad(intPtr);
		SEwecSgxxmoTMCdqMioeHDXdsnuqc = true;
		JFygDCWFGeEuEEeqGFRWrDEDlVpEA = predoReysgkDbMHWQjyxbMtjCRqMc.mqyoEBFKwWgsmvMjHsPFgUFOlftF(qyeCrTyMwMbDrFuxtqByujjUFVhu) > 0;
		if (JFygDCWFGeEuEEeqGFRWrDEDlVpEA)
		{
			JRVaqxBKatYgbGYyeEJbKTzddNthb = 2;
		}
		EPvLhUbbfrRNOoyhfkxKwfsxcUyv = new float[JRVaqxBKatYgbGYyeEJbKTzddNthb];
	}

	protected override void wivNpGMJTALcWTBRojzxsntOzmJC()
	{
		yllraxQncPWaUZilVxSCBdmsjTjN(brMCZGztVyGAQhfVvGaprymgKPDFA as TWdnkNUefXafpcUIoWzOuWtkApCMA);
	}

	protected override void zXktUZPPGodJAcfQSusogOzdeqFo()
	{
		if (brMCZGztVyGAQhfVvGaprymgKPDFA != null && brMCZGztVyGAQhfVvGaprymgKPDFA.IsValid)
		{
			if (!TvxYbbeLRgfpxOLIlIeWEDFewZTKA())
			{
				brMCZGztVyGAQhfVvGaprymgKPDFA.Clear();
				return;
			}
			predoReysgkDbMHWQjyxbMtjCRqMc.rhUkthsvUMpRPQpAcDajAUZYxWApA(brMCZGztVyGAQhfVvGaprymgKPDFA);
			brMCZGztVyGAQhfVvGaprymgKPDFA.Clear();
		}
	}

	private float lQhBLBTBBImhLpvHRRScCtbgPtvn(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.ValueInNewRange(P_0, -32767f, 32768f, -1f, 1f);
	}

	private int lMKrBccMDiiDqbzBIVsqqVrKCKGab(short P_0)
	{
		switch (P_0)
		{
		case 0:
			return -1;
		case 1:
			return 0;
		case 3:
			return 4500;
		case 2:
			return 9000;
		case 6:
			return 13500;
		case 4:
			return 18000;
		case 12:
			return 22500;
		case 8:
			return 27000;
		case 9:
			return 31500;
		default:
			return -1;
		}
	}
}
