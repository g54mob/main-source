using System;
using System.Runtime.CompilerServices;

internal struct MKUQejbXGhtisssiOQGPGRPAAYng
{
	private uint BCupFquLKMReuquSXzucFSTPcAFk;

	private ulong ikeSTnLCifnACfjvUYzcTUdWKxuG;

	private static readonly bool aGyaJcVXebuWzVRweTqCsMcdkXyL;

	public static readonly int SVslHBCPEiqJvrkLnPlcdvGQkXGt;

	static MKUQejbXGhtisssiOQGPGRPAAYng()
	{
		aGyaJcVXebuWzVRweTqCsMcdkXyL = IntPtr.Size == 8;
		SVslHBCPEiqJvrkLnPlcdvGQkXGt = (aGyaJcVXebuWzVRweTqCsMcdkXyL ? 8 : 4);
	}

	public static MKUQejbXGhtisssiOQGPGRPAAYng LojMxsQiKtlKRoPLTpgXSpYTTeIy(byte[] P_0, int P_1)
	{
		MKUQejbXGhtisssiOQGPGRPAAYng result = default(MKUQejbXGhtisssiOQGPGRPAAYng);
		if (aGyaJcVXebuWzVRweTqCsMcdkXyL)
		{
			result.ikeSTnLCifnACfjvUYzcTUdWKxuG = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.BCupFquLKMReuquSXzucFSTPcAFk = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint nXdEGxkvQawUPdGFxxsVKRHLniBdA(MKUQejbXGhtisssiOQGPGRPAAYng P_0)
	{
		if (aGyaJcVXebuWzVRweTqCsMcdkXyL)
		{
			return (uint)P_0.ikeSTnLCifnACfjvUYzcTUdWKxuG;
		}
		return P_0.BCupFquLKMReuquSXzucFSTPcAFk;
	}

	[SpecialName]
	public static ulong nXdEGxkvQawUPdGFxxsVKRHLniBdA(MKUQejbXGhtisssiOQGPGRPAAYng P_0)
	{
		if (aGyaJcVXebuWzVRweTqCsMcdkXyL)
		{
			return P_0.ikeSTnLCifnACfjvUYzcTUdWKxuG;
		}
		return P_0.BCupFquLKMReuquSXzucFSTPcAFk;
	}

	public string dgMmxzBBPUtRILLfTCOGTvmgveSK()
	{
		if (aGyaJcVXebuWzVRweTqCsMcdkXyL)
		{
			return ikeSTnLCifnACfjvUYzcTUdWKxuG.ToString();
		}
		return BCupFquLKMReuquSXzucFSTPcAFk.ToString();
	}
}
