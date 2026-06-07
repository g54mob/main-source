using System;
using System.Runtime.CompilerServices;

internal struct HcOpPzJdhlwSTVCwMDMdTrpcyuiN : IEquatable<HcOpPzJdhlwSTVCwMDMdTrpcyuiN>
{
	public static readonly HcOpPzJdhlwSTVCwMDMdTrpcyuiN vVuicWjNTfBRgCVOmkGzCWWiKvHGA = new HcOpPzJdhlwSTVCwMDMdTrpcyuiN(0, 0);

	public int RMFbQNlnJUYmReRZmkOjqNguGOMV;

	public int AZmoaqiMmEgvmVQchDXfdNwdScdeA;

	public HcOpPzJdhlwSTVCwMDMdTrpcyuiN(int P_0, int P_1)
	{
		RMFbQNlnJUYmReRZmkOjqNguGOMV = P_0;
		AZmoaqiMmEgvmVQchDXfdNwdScdeA = P_1;
	}

	public bool Equals(HcOpPzJdhlwSTVCwMDMdTrpcyuiN other)
	{
		if (other.RMFbQNlnJUYmReRZmkOjqNguGOMV == RMFbQNlnJUYmReRZmkOjqNguGOMV)
		{
			return other.AZmoaqiMmEgvmVQchDXfdNwdScdeA == AZmoaqiMmEgvmVQchDXfdNwdScdeA;
		}
		return false;
	}

	bool IEquatable<HcOpPzJdhlwSTVCwMDMdTrpcyuiN>.Equals(HcOpPzJdhlwSTVCwMDMdTrpcyuiN other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool bREeAVUDNWJqmWhxbPNOSJHTuXnh(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(HcOpPzJdhlwSTVCwMDMdTrpcyuiN))
		{
			return false;
		}
		return Equals((HcOpPzJdhlwSTVCwMDMdTrpcyuiN)P_0);
	}

	public int KNFfLwBLLdnJBnAHEJuGUUEdxTJrA()
	{
		return (RMFbQNlnJUYmReRZmkOjqNguGOMV * 397) ^ AZmoaqiMmEgvmVQchDXfdNwdScdeA;
	}

	[SpecialName]
	public static bool AeeTavMobSbvAClLFWZOFUsriAkk(HcOpPzJdhlwSTVCwMDMdTrpcyuiN P_0, HcOpPzJdhlwSTVCwMDMdTrpcyuiN P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool wlqGwVzKDxEyjSfAOBfgOdfPmJtf(HcOpPzJdhlwSTVCwMDMdTrpcyuiN P_0, HcOpPzJdhlwSTVCwMDMdTrpcyuiN P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string NhwUGrwLSCJLXjnwOUdoLaJXXtcr()
	{
		return $"({RMFbQNlnJUYmReRZmkOjqNguGOMV},{AZmoaqiMmEgvmVQchDXfdNwdScdeA})";
	}
}
