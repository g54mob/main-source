using System;
using System.Runtime.CompilerServices;

internal struct yWdhsGnKaQZClWjQEkiHyNtvHyMl
{
	private int PdBrWhRXqPLBvwsVyijHPYWJItSM;

	private long YaDfuJIDQujOGRVkECiTTMXlfhO;

	private static readonly bool xhIqhoBOMnygFEQgjgizURuDIukA;

	public static readonly int xeMxQpPWLJaiuzOHIHJNcJGUxatS;

	static yWdhsGnKaQZClWjQEkiHyNtvHyMl()
	{
		xhIqhoBOMnygFEQgjgizURuDIukA = IntPtr.Size == 8;
		xeMxQpPWLJaiuzOHIHJNcJGUxatS = (xhIqhoBOMnygFEQgjgizURuDIukA ? 8 : 4);
	}

	public static yWdhsGnKaQZClWjQEkiHyNtvHyMl FEniEzDSNuWUOQbRqgPyedJOUYwM(byte[] P_0, int P_1)
	{
		yWdhsGnKaQZClWjQEkiHyNtvHyMl result = default(yWdhsGnKaQZClWjQEkiHyNtvHyMl);
		if (xhIqhoBOMnygFEQgjgizURuDIukA)
		{
			result.YaDfuJIDQujOGRVkECiTTMXlfhO = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.PdBrWhRXqPLBvwsVyijHPYWJItSM = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int EkEotIOqmezRQLpTyziFwrrmcXdx(yWdhsGnKaQZClWjQEkiHyNtvHyMl P_0)
	{
		if (xhIqhoBOMnygFEQgjgizURuDIukA)
		{
			return (int)P_0.YaDfuJIDQujOGRVkECiTTMXlfhO;
		}
		return P_0.PdBrWhRXqPLBvwsVyijHPYWJItSM;
	}

	[SpecialName]
	public static long EkEotIOqmezRQLpTyziFwrrmcXdx(yWdhsGnKaQZClWjQEkiHyNtvHyMl P_0)
	{
		if (xhIqhoBOMnygFEQgjgizURuDIukA)
		{
			return P_0.YaDfuJIDQujOGRVkECiTTMXlfhO;
		}
		return P_0.PdBrWhRXqPLBvwsVyijHPYWJItSM;
	}

	public string YkVCfjHmGyOAhjQLRbUJmFEFKIxbb()
	{
		if (xhIqhoBOMnygFEQgjgizURuDIukA)
		{
			return YaDfuJIDQujOGRVkECiTTMXlfhO.ToString();
		}
		return PdBrWhRXqPLBvwsVyijHPYWJItSM.ToString();
	}
}
