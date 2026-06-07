using System;
using System.Runtime.CompilerServices;

internal struct BMQYXAXHUCpGfcIoCbaVfxBKDfwG
{
	private int xYMaJyxTHXimefAASIoTxsyzSpNI;

	private long onORPCcBkxVCyIAKeTfZoihpSFgv;

	private static readonly bool FdQJhyOJSwrWoSmBnUtobwBcqTBp;

	public static readonly int weigVxgwTZLFrPqtLfBgiVigMoUMb;

	static BMQYXAXHUCpGfcIoCbaVfxBKDfwG()
	{
		FdQJhyOJSwrWoSmBnUtobwBcqTBp = IntPtr.Size == 8;
		weigVxgwTZLFrPqtLfBgiVigMoUMb = (FdQJhyOJSwrWoSmBnUtobwBcqTBp ? 8 : 4);
	}

	public static BMQYXAXHUCpGfcIoCbaVfxBKDfwG mFJJoNccPNaJoDcCLzCKrfXcDUiVA(byte[] P_0, int P_1)
	{
		BMQYXAXHUCpGfcIoCbaVfxBKDfwG result = default(BMQYXAXHUCpGfcIoCbaVfxBKDfwG);
		if (FdQJhyOJSwrWoSmBnUtobwBcqTBp)
		{
			result.onORPCcBkxVCyIAKeTfZoihpSFgv = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.xYMaJyxTHXimefAASIoTxsyzSpNI = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int zSCjPSyDZWQQInGrXWfghirqxpZs(BMQYXAXHUCpGfcIoCbaVfxBKDfwG P_0)
	{
		if (FdQJhyOJSwrWoSmBnUtobwBcqTBp)
		{
			return (int)P_0.onORPCcBkxVCyIAKeTfZoihpSFgv;
		}
		return P_0.xYMaJyxTHXimefAASIoTxsyzSpNI;
	}

	[SpecialName]
	public static long zSCjPSyDZWQQInGrXWfghirqxpZs(BMQYXAXHUCpGfcIoCbaVfxBKDfwG P_0)
	{
		if (FdQJhyOJSwrWoSmBnUtobwBcqTBp)
		{
			return P_0.onORPCcBkxVCyIAKeTfZoihpSFgv;
		}
		return P_0.xYMaJyxTHXimefAASIoTxsyzSpNI;
	}

	public string wqjMQbGBhSaPhCgCOWiKMRbVrgvCA()
	{
		if (FdQJhyOJSwrWoSmBnUtobwBcqTBp)
		{
			return onORPCcBkxVCyIAKeTfZoihpSFgv.ToString();
		}
		return xYMaJyxTHXimefAASIoTxsyzSpNI.ToString();
	}
}
