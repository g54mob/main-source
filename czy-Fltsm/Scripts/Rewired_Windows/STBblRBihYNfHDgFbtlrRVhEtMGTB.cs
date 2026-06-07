using Rewired.Utils;

internal class STBblRBihYNfHDgFbtlrRVhEtMGTB : qftbBPXdpkiKXkGiwkaIgUTSKbnwA
{
	public readonly int KszWdTVikSzQCRQjanPGeoHGzfuX;

	public readonly int lSmPcPGDClzLoSOXsILdinWbwfov;

	public readonly int VSHUMYDpwuBCHkHPDDodQRASkFCIb;

	public readonly int mauJvdWeSliMsrhbnKjOtPoCpuHf;

	public readonly int KXcVmRMhcnQXnwZUKkkOuMscRqhG;

	public readonly int sRtwIZZOrfgGcCxRqulwbGVYRgcrA;

	public readonly uint aIOgpkgjMOAhREAZwsgMRkJrfRcd;

	public readonly uint NEYDWoJHkoEAqqZzBaankhwOxeSA;

	public readonly int zDIeLrHcudXHVwobSuQgitXnpoLsA;

	private readonly int xZuroEYpBrcrUkaEDxDvPQVQfVeu;

	public uint kXLonIRWspHuIVmKGEMzYLzaIdUE;

	public int afItDouQxAiMVbxxpRiboqFUtMdp
	{
		get
		{
			if (kXLonIRWspHuIVmKGEMzYLzaIdUE < KszWdTVikSzQCRQjanPGeoHGzfuX || kXLonIRWspHuIVmKGEMzYLzaIdUE > lSmPcPGDClzLoSOXsILdinWbwfov)
			{
				return -1;
			}
			int num = (int)((kXLonIRWspHuIVmKGEMzYLzaIdUE - KszWdTVikSzQCRQjanPGeoHGzfuX) / xZuroEYpBrcrUkaEDxDvPQVQfVeu * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public STBblRBihYNfHDgFbtlrRVhEtMGTB(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		KszWdTVikSzQCRQjanPGeoHGzfuX = P_5;
		lSmPcPGDClzLoSOXsILdinWbwfov = P_6;
		aIOgpkgjMOAhREAZwsgMRkJrfRcd = P_9;
		NEYDWoJHkoEAqqZzBaankhwOxeSA = P_10;
		zDIeLrHcudXHVwobSuQgitXnpoLsA = P_11;
		VSHUMYDpwuBCHkHPDDodQRASkFCIb = P_5 - 1;
		if (VSHUMYDpwuBCHkHPDDodQRASkFCIb < 0)
		{
			VSHUMYDpwuBCHkHPDDodQRASkFCIb = P_6 + 1;
		}
		sRtwIZZOrfgGcCxRqulwbGVYRgcrA = -1;
		int num = P_6 - P_5 + 1;
		xZuroEYpBrcrUkaEDxDvPQVQfVeu = MathTools.Clamp(num / 8, 1, int.MaxValue);
		lMOPnUXOcGnTsXYzLnTdhUZtYLbg();
	}

	public virtual void hzUGkloNvsuIIONkARGoVJAiHEUDA()
	{
		kXLonIRWspHuIVmKGEMzYLzaIdUE = (uint)VSHUMYDpwuBCHkHPDDodQRASkFCIb;
	}
}
