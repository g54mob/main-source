using System;
using System.Runtime.CompilerServices;

internal struct rNzCKyZfSdDOlkShVaXspDpFcCid
{
	private uint hlLaXulYjSDlYtXgSpXAKCKGdDxU;

	private ulong XTaYZjUZcQaggBmRIDAYFESnPEutA;

	private static readonly bool UXVhkWtipEmPLYlUYAOMhVSeLPMHA;

	public static readonly int yGAuqBdcHMcjeIRjcZqtdxbAtcCG;

	static rNzCKyZfSdDOlkShVaXspDpFcCid()
	{
		UXVhkWtipEmPLYlUYAOMhVSeLPMHA = IntPtr.Size == 8;
		yGAuqBdcHMcjeIRjcZqtdxbAtcCG = (UXVhkWtipEmPLYlUYAOMhVSeLPMHA ? 8 : 4);
	}

	public static rNzCKyZfSdDOlkShVaXspDpFcCid SWFPnfmALGXqypscqbKoTtLRakB(byte[] P_0, int P_1)
	{
		rNzCKyZfSdDOlkShVaXspDpFcCid result = default(rNzCKyZfSdDOlkShVaXspDpFcCid);
		if (UXVhkWtipEmPLYlUYAOMhVSeLPMHA)
		{
			result.XTaYZjUZcQaggBmRIDAYFESnPEutA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.hlLaXulYjSDlYtXgSpXAKCKGdDxU = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint gGPSOQMRunDRKqooxaWDDDSkTQZb(rNzCKyZfSdDOlkShVaXspDpFcCid P_0)
	{
		if (UXVhkWtipEmPLYlUYAOMhVSeLPMHA)
		{
			return (uint)P_0.XTaYZjUZcQaggBmRIDAYFESnPEutA;
		}
		return P_0.hlLaXulYjSDlYtXgSpXAKCKGdDxU;
	}

	[SpecialName]
	public static ulong gGPSOQMRunDRKqooxaWDDDSkTQZb(rNzCKyZfSdDOlkShVaXspDpFcCid P_0)
	{
		if (UXVhkWtipEmPLYlUYAOMhVSeLPMHA)
		{
			return P_0.XTaYZjUZcQaggBmRIDAYFESnPEutA;
		}
		return P_0.hlLaXulYjSDlYtXgSpXAKCKGdDxU;
	}

	public string ZnJRussRlAsOhzSOFPeGULLGztzo()
	{
		if (UXVhkWtipEmPLYlUYAOMhVSeLPMHA)
		{
			return XTaYZjUZcQaggBmRIDAYFESnPEutA.ToString();
		}
		return hlLaXulYjSDlYtXgSpXAKCKGdDxU.ToString();
	}
}
