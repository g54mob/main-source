using System;
using System.Runtime.CompilerServices;

internal struct YGaHCxSDMeuMeKFcjDBHxdrnYXkO
{
	private uint LMdyaaRSReGcMCIaCuyGwlqMnKAb;

	private ulong wJGATbiKCmnaUZOppHFwuLLhbDrHA;

	private static readonly bool ogWEriaeJyFxtzmMNjsIZCKGvHhe;

	public static readonly int WBUCGHbdAlhEbLVHCnsauIwfxKDuA;

	static YGaHCxSDMeuMeKFcjDBHxdrnYXkO()
	{
		ogWEriaeJyFxtzmMNjsIZCKGvHhe = IntPtr.Size == 8;
		WBUCGHbdAlhEbLVHCnsauIwfxKDuA = (ogWEriaeJyFxtzmMNjsIZCKGvHhe ? 8 : 4);
	}

	public static YGaHCxSDMeuMeKFcjDBHxdrnYXkO NELecwivCqsJBkAHaMdDUpyoMnHIb(byte[] P_0, int P_1)
	{
		YGaHCxSDMeuMeKFcjDBHxdrnYXkO result = default(YGaHCxSDMeuMeKFcjDBHxdrnYXkO);
		if (ogWEriaeJyFxtzmMNjsIZCKGvHhe)
		{
			result.wJGATbiKCmnaUZOppHFwuLLhbDrHA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.LMdyaaRSReGcMCIaCuyGwlqMnKAb = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint zVRrBnGkApgDHawLKlrLaanaXxSCA(YGaHCxSDMeuMeKFcjDBHxdrnYXkO P_0)
	{
		if (ogWEriaeJyFxtzmMNjsIZCKGvHhe)
		{
			return (uint)P_0.wJGATbiKCmnaUZOppHFwuLLhbDrHA;
		}
		return P_0.LMdyaaRSReGcMCIaCuyGwlqMnKAb;
	}

	[SpecialName]
	public static ulong zVRrBnGkApgDHawLKlrLaanaXxSCA(YGaHCxSDMeuMeKFcjDBHxdrnYXkO P_0)
	{
		if (ogWEriaeJyFxtzmMNjsIZCKGvHhe)
		{
			return P_0.wJGATbiKCmnaUZOppHFwuLLhbDrHA;
		}
		return P_0.LMdyaaRSReGcMCIaCuyGwlqMnKAb;
	}

	public string fMmrpCcLlTmMBnhmaXIwkCnVmPJb()
	{
		if (ogWEriaeJyFxtzmMNjsIZCKGvHhe)
		{
			return wJGATbiKCmnaUZOppHFwuLLhbDrHA.ToString();
		}
		return LMdyaaRSReGcMCIaCuyGwlqMnKAb.ToString();
	}
}
