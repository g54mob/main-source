using System;
using System.Runtime.CompilerServices;

internal struct pIudYAEqdbxHtmkOZMButTjNkGVM : IEquatable<pIudYAEqdbxHtmkOZMButTjNkGVM>
{
	public static readonly pIudYAEqdbxHtmkOZMButTjNkGVM LDZeDHDvlPmyeHWovwIyjCNRfsIeb = new pIudYAEqdbxHtmkOZMButTjNkGVM(0f, 0f);

	public static readonly pIudYAEqdbxHtmkOZMButTjNkGVM yOCBeNAQnmSZFlmTSJdHqoQOcouBA = LDZeDHDvlPmyeHWovwIyjCNRfsIeb;

	public float OCSCYJprMxYbEMuvwksHLWXTLbZf;

	public float yhBfkkJkhMkWLdncMoCWLoqwGDkUA;

	public pIudYAEqdbxHtmkOZMButTjNkGVM(float P_0, float P_1)
	{
		OCSCYJprMxYbEMuvwksHLWXTLbZf = P_0;
		yhBfkkJkhMkWLdncMoCWLoqwGDkUA = P_1;
	}

	public bool Equals(pIudYAEqdbxHtmkOZMButTjNkGVM other)
	{
		if (other.OCSCYJprMxYbEMuvwksHLWXTLbZf == OCSCYJprMxYbEMuvwksHLWXTLbZf)
		{
			return other.yhBfkkJkhMkWLdncMoCWLoqwGDkUA == yhBfkkJkhMkWLdncMoCWLoqwGDkUA;
		}
		return false;
	}

	bool IEquatable<pIudYAEqdbxHtmkOZMButTjNkGVM>.Equals(pIudYAEqdbxHtmkOZMButTjNkGVM other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool CwzEArfaTISHGVwTUpaPsFzpimSfb(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(pIudYAEqdbxHtmkOZMButTjNkGVM))
		{
			return false;
		}
		return Equals((pIudYAEqdbxHtmkOZMButTjNkGVM)P_0);
	}

	public int DHsyAKVPLvCaFaAajtlxAncLXDSkA()
	{
		return (OCSCYJprMxYbEMuvwksHLWXTLbZf.GetHashCode() * 397) ^ yhBfkkJkhMkWLdncMoCWLoqwGDkUA.GetHashCode();
	}

	[SpecialName]
	public static bool wNrEHWhUUQPeqeLZcpOxySmSJqimA(pIudYAEqdbxHtmkOZMButTjNkGVM P_0, pIudYAEqdbxHtmkOZMButTjNkGVM P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool udJwJZYmxNxeLbQMYukxZOSkKLiK(pIudYAEqdbxHtmkOZMButTjNkGVM P_0, pIudYAEqdbxHtmkOZMButTjNkGVM P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string QTZhtiAPDMbVAaYKyuQjokKXFaRKA()
	{
		return $"({OCSCYJprMxYbEMuvwksHLWXTLbZf},{yhBfkkJkhMkWLdncMoCWLoqwGDkUA})";
	}
}
