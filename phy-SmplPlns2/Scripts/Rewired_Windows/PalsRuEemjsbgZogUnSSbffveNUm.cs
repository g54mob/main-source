using System;
using System.Runtime.CompilerServices;

internal struct PalsRuEemjsbgZogUnSSbffveNUm
{
	private uint EPVKmpDDiASVkRCCHtEzkdfoIbafA;

	private ulong raBFRgIiqdmfQrGrUcxvrwVzgJFQA;

	private static readonly bool dwPqKnamAlAMlfoyknLPcTQgEzXqB;

	public static readonly int RiXCOYlkmwFBnUHZlnIrYZqtuSvR;

	static PalsRuEemjsbgZogUnSSbffveNUm()
	{
		dwPqKnamAlAMlfoyknLPcTQgEzXqB = IntPtr.Size == 8;
		RiXCOYlkmwFBnUHZlnIrYZqtuSvR = (dwPqKnamAlAMlfoyknLPcTQgEzXqB ? 8 : 4);
	}

	public static PalsRuEemjsbgZogUnSSbffveNUm UBWBqbjCuzGQDfNVFLXQijemTxftA(byte[] P_0, int P_1)
	{
		PalsRuEemjsbgZogUnSSbffveNUm result = default(PalsRuEemjsbgZogUnSSbffveNUm);
		if (dwPqKnamAlAMlfoyknLPcTQgEzXqB)
		{
			result.raBFRgIiqdmfQrGrUcxvrwVzgJFQA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.EPVKmpDDiASVkRCCHtEzkdfoIbafA = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint eHENMwIaLsGhBrJvlHtOwdAstagF(PalsRuEemjsbgZogUnSSbffveNUm P_0)
	{
		if (dwPqKnamAlAMlfoyknLPcTQgEzXqB)
		{
			return (uint)P_0.raBFRgIiqdmfQrGrUcxvrwVzgJFQA;
		}
		return P_0.EPVKmpDDiASVkRCCHtEzkdfoIbafA;
	}

	[SpecialName]
	public static ulong eHENMwIaLsGhBrJvlHtOwdAstagF(PalsRuEemjsbgZogUnSSbffveNUm P_0)
	{
		if (dwPqKnamAlAMlfoyknLPcTQgEzXqB)
		{
			return P_0.raBFRgIiqdmfQrGrUcxvrwVzgJFQA;
		}
		return P_0.EPVKmpDDiASVkRCCHtEzkdfoIbafA;
	}

	public string gthiveuadKCfQjodDXvNagGHBsbxA()
	{
		if (dwPqKnamAlAMlfoyknLPcTQgEzXqB)
		{
			return raBFRgIiqdmfQrGrUcxvrwVzgJFQA.ToString();
		}
		return EPVKmpDDiASVkRCCHtEzkdfoIbafA.ToString();
	}
}
