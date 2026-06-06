using System;
using System.Runtime.CompilerServices;

internal struct MWFgCxEqLvgswhieoIlPmFabBXuoA
{
	private int rHrbhYwDzasbeQlpGcwNwLvVAQqe;

	private long koAoYXgUsduETmbbEbFwbkRHaQZnA;

	private static readonly bool FhNOTSoUxjKNfkscCjpyGRWeGnKR;

	public static readonly int XnuCvMwhcceDvHPneXUXTHBUyVNjA;

	static MWFgCxEqLvgswhieoIlPmFabBXuoA()
	{
		FhNOTSoUxjKNfkscCjpyGRWeGnKR = IntPtr.Size == 8;
		XnuCvMwhcceDvHPneXUXTHBUyVNjA = (FhNOTSoUxjKNfkscCjpyGRWeGnKR ? 8 : 4);
	}

	public static MWFgCxEqLvgswhieoIlPmFabBXuoA ptLbpKaqmTxyZizxUGwXFWrOfUmB(byte[] P_0, int P_1)
	{
		MWFgCxEqLvgswhieoIlPmFabBXuoA result = default(MWFgCxEqLvgswhieoIlPmFabBXuoA);
		if (FhNOTSoUxjKNfkscCjpyGRWeGnKR)
		{
			result.koAoYXgUsduETmbbEbFwbkRHaQZnA = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.rHrbhYwDzasbeQlpGcwNwLvVAQqe = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int icKfxbhHJCiBzChOUzDDWucTaRS(MWFgCxEqLvgswhieoIlPmFabBXuoA P_0)
	{
		if (FhNOTSoUxjKNfkscCjpyGRWeGnKR)
		{
			return (int)P_0.koAoYXgUsduETmbbEbFwbkRHaQZnA;
		}
		return P_0.rHrbhYwDzasbeQlpGcwNwLvVAQqe;
	}

	[SpecialName]
	public static long icKfxbhHJCiBzChOUzDDWucTaRS(MWFgCxEqLvgswhieoIlPmFabBXuoA P_0)
	{
		if (FhNOTSoUxjKNfkscCjpyGRWeGnKR)
		{
			return P_0.koAoYXgUsduETmbbEbFwbkRHaQZnA;
		}
		return P_0.rHrbhYwDzasbeQlpGcwNwLvVAQqe;
	}

	public string gBfOFYVqlXnHkmzjpNdNioTThHJF()
	{
		if (FhNOTSoUxjKNfkscCjpyGRWeGnKR)
		{
			return koAoYXgUsduETmbbEbFwbkRHaQZnA.ToString();
		}
		return rHrbhYwDzasbeQlpGcwNwLvVAQqe.ToString();
	}
}
