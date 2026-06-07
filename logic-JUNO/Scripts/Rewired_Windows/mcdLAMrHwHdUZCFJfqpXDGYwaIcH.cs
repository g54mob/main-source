using System;
using System.Runtime.CompilerServices;

internal struct mcdLAMrHwHdUZCFJfqpXDGYwaIcH
{
	private uint hHGuZiCwiINHYQfyHVeUUCjaIAq;

	private ulong QEPAVOVysNTzdDgYbeqsOPoejobU;

	private static readonly bool GKPWRTFMeTCcKtDPNEsAbntJWYdi;

	public static readonly int aQTdEyIssGZHKDkaKcZwuOTaAfFU;

	static mcdLAMrHwHdUZCFJfqpXDGYwaIcH()
	{
		GKPWRTFMeTCcKtDPNEsAbntJWYdi = IntPtr.Size == 8;
		aQTdEyIssGZHKDkaKcZwuOTaAfFU = (GKPWRTFMeTCcKtDPNEsAbntJWYdi ? 8 : 4);
	}

	public static mcdLAMrHwHdUZCFJfqpXDGYwaIcH bkSemFKIkPzIaWWokvKLPBVphIZvA(byte[] P_0, int P_1)
	{
		mcdLAMrHwHdUZCFJfqpXDGYwaIcH result = default(mcdLAMrHwHdUZCFJfqpXDGYwaIcH);
		if (GKPWRTFMeTCcKtDPNEsAbntJWYdi)
		{
			result.QEPAVOVysNTzdDgYbeqsOPoejobU = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.hHGuZiCwiINHYQfyHVeUUCjaIAq = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint ZqYrRAzmyQpCgsPgWbYBWdSrdGQeA(mcdLAMrHwHdUZCFJfqpXDGYwaIcH P_0)
	{
		if (GKPWRTFMeTCcKtDPNEsAbntJWYdi)
		{
			return (uint)P_0.QEPAVOVysNTzdDgYbeqsOPoejobU;
		}
		return P_0.hHGuZiCwiINHYQfyHVeUUCjaIAq;
	}

	[SpecialName]
	public static ulong ZqYrRAzmyQpCgsPgWbYBWdSrdGQeA(mcdLAMrHwHdUZCFJfqpXDGYwaIcH P_0)
	{
		if (GKPWRTFMeTCcKtDPNEsAbntJWYdi)
		{
			return P_0.QEPAVOVysNTzdDgYbeqsOPoejobU;
		}
		return P_0.hHGuZiCwiINHYQfyHVeUUCjaIAq;
	}

	public string DhMnUjPvfaptBjGqscCSMfhSLFjc()
	{
		if (GKPWRTFMeTCcKtDPNEsAbntJWYdi)
		{
			return QEPAVOVysNTzdDgYbeqsOPoejobU.ToString();
		}
		return hHGuZiCwiINHYQfyHVeUUCjaIAq.ToString();
	}
}
