using Rewired.Utils;

internal class xeDXAkGcMzNhIAYbhjotXWERSKg : bARERokRPrroENPUWZfiYoNYxPs
{
	public readonly bool LdzEktejQXERojpcXjQanXlLsgR;

	private int pKShwIVWoIXrthESRiULcOvvIFO;

	private int CpFthOHijqCtNMaOoosLcPHlcCz;

	private bool IFSkNBCruewARIqGMjxdMVsTfnv;

	public readonly int wclPZcDBDlViZwCyCgMeHFYKuUu;

	public readonly int FVTieGbwcOPWTizhRLaruKQUAir;

	public readonly int zeZHXfFKWkTyEFYLlqQNWgtglKvA;

	public readonly int ZFXvtLkFBsytjdWMoVaMmWArVvq;

	public readonly int AnSutSUXElVFsxmsyFNtfhdFlDWF;

	public readonly int DvyrfCsGrpScKMhZGYIayLKVIPn;

	public readonly uint ycjFPPDijlTFxCYLvSjKxgtfIYHf;

	public readonly uint fGXBLzIrbioNuBVRNesOhHUFwIh;

	public readonly int PMPyyMNylNnLtKkHvQgLkSmTiQf;

	public uint tMdVaanieZgMNBPWABQFUSWqJtyN;

	public virtual int value
	{
		get
		{
			int num = (int)tMdVaanieZgMNBPWABQFUSWqJtyN;
			if (LdzEktejQXERojpcXjQanXlLsgR && IFSkNBCruewARIqGMjxdMVsTfnv && num > pKShwIVWoIXrthESRiULcOvvIFO)
			{
				num += CpFthOHijqCtNMaOoosLcPHlcCz;
			}
			if (num == zeZHXfFKWkTyEFYLlqQNWgtglKvA)
			{
				return DvyrfCsGrpScKMhZGYIayLKVIPn;
			}
			return (int)bjptqAdMNNzlFrsxmOvARqLzaqj((float)num, (float)wclPZcDBDlViZwCyCgMeHFYKuUu, (float)FVTieGbwcOPWTizhRLaruKQUAir, (float)ZFXvtLkFBsytjdWMoVaMmWArVvq, (float)AnSutSUXElVFsxmsyFNtfhdFlDWF);
		}
	}

	public xeDXAkGcMzNhIAYbhjotXWERSKg(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex, bool isAxisButton)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		wclPZcDBDlViZwCyCgMeHFYKuUu = logicalMin;
		FVTieGbwcOPWTizhRLaruKQUAir = logicalMax;
		ycjFPPDijlTFxCYLvSjKxgtfIYHf = units;
		fGXBLzIrbioNuBVRNesOhHUFwIh = unitsExp;
		PMPyyMNylNnLtKkHvQgLkSmTiQf = reportIndex;
		LdzEktejQXERojpcXjQanXlLsgR = logicalMin < 0 || logicalMax < 0;
		if (logicalMin > logicalMax || logicalMax - logicalMin < 2)
		{
			if (logicalMin == 0 && logicalMax < 0 && physicalMin == 0 && physicalMax < 0)
			{
				LdzEktejQXERojpcXjQanXlLsgR = false;
			}
			if (bitSize > 1 && bitSize < 32)
			{
				int num = 1 << bitSize;
				if (LdzEktejQXERojpcXjQanXlLsgR)
				{
					zeZHXfFKWkTyEFYLlqQNWgtglKvA = 0;
					wclPZcDBDlViZwCyCgMeHFYKuUu = num * -1;
					FVTieGbwcOPWTizhRLaruKQUAir = num - 1;
				}
				else
				{
					zeZHXfFKWkTyEFYLlqQNWgtglKvA = num >> 1;
					wclPZcDBDlViZwCyCgMeHFYKuUu = 0;
					FVTieGbwcOPWTizhRLaruKQUAir = num - 1;
				}
			}
			else if (LdzEktejQXERojpcXjQanXlLsgR)
			{
				zeZHXfFKWkTyEFYLlqQNWgtglKvA = 0;
				wclPZcDBDlViZwCyCgMeHFYKuUu = -32768;
				FVTieGbwcOPWTizhRLaruKQUAir = 32767;
			}
			else
			{
				zeZHXfFKWkTyEFYLlqQNWgtglKvA = 32768;
				wclPZcDBDlViZwCyCgMeHFYKuUu = 0;
				FVTieGbwcOPWTizhRLaruKQUAir = 65535;
			}
		}
		else
		{
			zeZHXfFKWkTyEFYLlqQNWgtglKvA = (FVTieGbwcOPWTizhRLaruKQUAir - wclPZcDBDlViZwCyCgMeHFYKuUu) / 2;
		}
		DvyrfCsGrpScKMhZGYIayLKVIPn = 0;
		ZFXvtLkFBsytjdWMoVaMmWArVvq = -65535;
		AnSutSUXElVFsxmsyFNtfhdFlDWF = 65535;
		if (LdzEktejQXERojpcXjQanXlLsgR)
		{
			VqfCygcDMiZUMhKxMwFFWimLMYP();
			zeZHXfFKWkTyEFYLlqQNWgtglKvA = logicalMax + 1 + logicalMin;
		}
		if (isAxisButton)
		{
			wclPZcDBDlViZwCyCgMeHFYKuUu = 0;
			zeZHXfFKWkTyEFYLlqQNWgtglKvA = 0;
			ZFXvtLkFBsytjdWMoVaMmWArVvq = 0;
		}
		avkcOhFlGGeHrNSdTQlLZUnJDbw();
	}

	public override void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		tMdVaanieZgMNBPWABQFUSWqJtyN = (uint)zeZHXfFKWkTyEFYLlqQNWgtglKvA;
	}

	private static float bjptqAdMNNzlFrsxmOvARqLzaqj(float P_0, float P_1, float P_2, float P_3, float P_4)
	{
		float num = P_2 - P_1;
		if (MathTools.Approximately(num, 0f))
		{
			return P_3;
		}
		float num2 = P_4 - P_3;
		return (P_0 - P_1) * num2 / num + P_3;
	}

	private static int bjptqAdMNNzlFrsxmOvARqLzaqj(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		int num = P_2 - P_1;
		long num2;
		if (num == 0)
		{
			num2 = P_3;
		}
		else
		{
			int num3 = P_4 - P_3;
			num2 = (long)(P_0 - P_1) * (long)num3 / num + P_3;
		}
		return (int)num2;
	}

	private void VqfCygcDMiZUMhKxMwFFWimLMYP()
	{
		if (QWNmcfJXcOUrbVPAeryQMDClSqi > 0 && QWNmcfJXcOUrbVPAeryQMDClSqi < 32)
		{
			int num = 1 << QWNmcfJXcOUrbVPAeryQMDClSqi;
			int num2 = num >> 1;
			pKShwIVWoIXrthESRiULcOvvIFO = num2 - 1;
			CpFthOHijqCtNMaOoosLcPHlcCz = num * -1;
			IFSkNBCruewARIqGMjxdMVsTfnv = true;
		}
	}
}
