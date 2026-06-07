using System;
using System.Runtime.CompilerServices;

internal struct ZhVWkUaOABSKNsFLToOBDMleQCXS
{
	private int jTZpEaMYYCARYvtZJuzFRykJPUgm;

	private long kSDxVCZMdcxqWQbBvAAPCPvNMQBY;

	private static readonly bool HuDPxwdfHngjKCAIsmEmTnLCIWqx;

	public static readonly int iolpjvLAAwqZeccHYkmVpuhspnIB;

	static ZhVWkUaOABSKNsFLToOBDMleQCXS()
	{
		HuDPxwdfHngjKCAIsmEmTnLCIWqx = IntPtr.Size == 8;
		iolpjvLAAwqZeccHYkmVpuhspnIB = (HuDPxwdfHngjKCAIsmEmTnLCIWqx ? 8 : 4);
	}

	public static ZhVWkUaOABSKNsFLToOBDMleQCXS kWAaCTDJEIOmYoVLMJvYZUXIBRTp(byte[] P_0, int P_1)
	{
		ZhVWkUaOABSKNsFLToOBDMleQCXS result = default(ZhVWkUaOABSKNsFLToOBDMleQCXS);
		if (HuDPxwdfHngjKCAIsmEmTnLCIWqx)
		{
			result.kSDxVCZMdcxqWQbBvAAPCPvNMQBY = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.jTZpEaMYYCARYvtZJuzFRykJPUgm = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int pBDFxYFkMRRpezseKOSqHAdUFyiiA(ZhVWkUaOABSKNsFLToOBDMleQCXS P_0)
	{
		if (HuDPxwdfHngjKCAIsmEmTnLCIWqx)
		{
			return (int)P_0.kSDxVCZMdcxqWQbBvAAPCPvNMQBY;
		}
		return P_0.jTZpEaMYYCARYvtZJuzFRykJPUgm;
	}

	[SpecialName]
	public static long pBDFxYFkMRRpezseKOSqHAdUFyiiA(ZhVWkUaOABSKNsFLToOBDMleQCXS P_0)
	{
		if (HuDPxwdfHngjKCAIsmEmTnLCIWqx)
		{
			return P_0.kSDxVCZMdcxqWQbBvAAPCPvNMQBY;
		}
		return P_0.jTZpEaMYYCARYvtZJuzFRykJPUgm;
	}

	public string qggwyljkWNuiFqiTLHnKrlxhhrCh()
	{
		if (HuDPxwdfHngjKCAIsmEmTnLCIWqx)
		{
			return kSDxVCZMdcxqWQbBvAAPCPvNMQBY.ToString();
		}
		return jTZpEaMYYCARYvtZJuzFRykJPUgm.ToString();
	}
}
