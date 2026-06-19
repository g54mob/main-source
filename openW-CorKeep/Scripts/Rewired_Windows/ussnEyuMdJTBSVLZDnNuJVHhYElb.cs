using System;
using System.Runtime.CompilerServices;

internal struct ussnEyuMdJTBSVLZDnNuJVHhYElb
{
	private int IVcBNAQhESkQSAFNBRMLLnKCcNjT;

	private long LEchweVfvukeYhpPhOlXGsFKFQUV;

	private static readonly bool uUqlIUdYXpbyOrACecdiHZzPbSnyA;

	public static readonly int XWSsuTLEGMCxJRIkWHPyFpQrDzkvA;

	static ussnEyuMdJTBSVLZDnNuJVHhYElb()
	{
		uUqlIUdYXpbyOrACecdiHZzPbSnyA = IntPtr.Size == 8;
		XWSsuTLEGMCxJRIkWHPyFpQrDzkvA = (uUqlIUdYXpbyOrACecdiHZzPbSnyA ? 8 : 4);
	}

	public static ussnEyuMdJTBSVLZDnNuJVHhYElb DSbnRbFTOIrvKHdHSGGULSlJyBIR(byte[] P_0, int P_1)
	{
		ussnEyuMdJTBSVLZDnNuJVHhYElb result = default(ussnEyuMdJTBSVLZDnNuJVHhYElb);
		if (uUqlIUdYXpbyOrACecdiHZzPbSnyA)
		{
			result.LEchweVfvukeYhpPhOlXGsFKFQUV = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.IVcBNAQhESkQSAFNBRMLLnKCcNjT = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int UyumwwJFKNpgoOkkQAjmRBPJjepKA(ussnEyuMdJTBSVLZDnNuJVHhYElb P_0)
	{
		if (uUqlIUdYXpbyOrACecdiHZzPbSnyA)
		{
			return (int)P_0.LEchweVfvukeYhpPhOlXGsFKFQUV;
		}
		return P_0.IVcBNAQhESkQSAFNBRMLLnKCcNjT;
	}

	[SpecialName]
	public static long UyumwwJFKNpgoOkkQAjmRBPJjepKA(ussnEyuMdJTBSVLZDnNuJVHhYElb P_0)
	{
		if (uUqlIUdYXpbyOrACecdiHZzPbSnyA)
		{
			return P_0.LEchweVfvukeYhpPhOlXGsFKFQUV;
		}
		return P_0.IVcBNAQhESkQSAFNBRMLLnKCcNjT;
	}

	public string NhHIpTdMuBEfHVWNZGaWDpZyalVMA()
	{
		if (uUqlIUdYXpbyOrACecdiHZzPbSnyA)
		{
			return LEchweVfvukeYhpPhOlXGsFKFQUV.ToString();
		}
		return IVcBNAQhESkQSAFNBRMLLnKCcNjT.ToString();
	}
}
