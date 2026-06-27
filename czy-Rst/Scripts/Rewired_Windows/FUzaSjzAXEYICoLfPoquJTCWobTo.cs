using System;
using System.Runtime.CompilerServices;

internal struct FUzaSjzAXEYICoLfPoquJTCWobTo : IEquatable<FUzaSjzAXEYICoLfPoquJTCWobTo>
{
	public static readonly FUzaSjzAXEYICoLfPoquJTCWobTo xsAeTaOUFqdxLHSBhYdamgsECLUqA = new FUzaSjzAXEYICoLfPoquJTCWobTo(0f, 0f);

	public static readonly FUzaSjzAXEYICoLfPoquJTCWobTo UuFbugpVLRCTaxbwODOTOsxLALeQ = xsAeTaOUFqdxLHSBhYdamgsECLUqA;

	public float qXXYkyWPqIPqzSQKeBZDvApEcEVj;

	public float CcSEiDHNJxsXqprDKVjCJIVppkigA;

	public FUzaSjzAXEYICoLfPoquJTCWobTo(float P_0, float P_1)
	{
		qXXYkyWPqIPqzSQKeBZDvApEcEVj = P_0;
		CcSEiDHNJxsXqprDKVjCJIVppkigA = P_1;
	}

	public bool Equals(FUzaSjzAXEYICoLfPoquJTCWobTo other)
	{
		if (other.qXXYkyWPqIPqzSQKeBZDvApEcEVj == qXXYkyWPqIPqzSQKeBZDvApEcEVj)
		{
			return other.CcSEiDHNJxsXqprDKVjCJIVppkigA == CcSEiDHNJxsXqprDKVjCJIVppkigA;
		}
		return false;
	}

	bool IEquatable<FUzaSjzAXEYICoLfPoquJTCWobTo>.Equals(FUzaSjzAXEYICoLfPoquJTCWobTo other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool sAohQEaDndDIbVakUeNDsfIugVUTA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(FUzaSjzAXEYICoLfPoquJTCWobTo))
		{
			return false;
		}
		return Equals((FUzaSjzAXEYICoLfPoquJTCWobTo)P_0);
	}

	public int dtxvQfusjONfiCqXxGIvHqDQEsWgA()
	{
		return (qXXYkyWPqIPqzSQKeBZDvApEcEVj.GetHashCode() * 397) ^ CcSEiDHNJxsXqprDKVjCJIVppkigA.GetHashCode();
	}

	[SpecialName]
	public static bool QCwhJlkjsjzfBQJiqCxptePXpZgZ(FUzaSjzAXEYICoLfPoquJTCWobTo P_0, FUzaSjzAXEYICoLfPoquJTCWobTo P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool EIAqkibLNqcAstehSkHxdMnlcjgo(FUzaSjzAXEYICoLfPoquJTCWobTo P_0, FUzaSjzAXEYICoLfPoquJTCWobTo P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string gIEkdVvpvzQWraUboVfvQozYBXZT()
	{
		return $"({qXXYkyWPqIPqzSQKeBZDvApEcEVj},{CcSEiDHNJxsXqprDKVjCJIVppkigA})";
	}
}
