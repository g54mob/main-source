using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct uWOqpRQeRUtDCJArQdGhUlVIEJbt : IEquatable<uWOqpRQeRUtDCJArQdGhUlVIEJbt>
{
	private int YdNuMPMZJnwMjbbioGjKFsUghDgx;

	public uWOqpRQeRUtDCJArQdGhUlVIEJbt(bool P_0)
	{
		YdNuMPMZJnwMjbbioGjKFsUghDgx = (P_0 ? 1 : 0);
	}

	public bool Equals(uWOqpRQeRUtDCJArQdGhUlVIEJbt other)
	{
		return YdNuMPMZJnwMjbbioGjKFsUghDgx == other.YdNuMPMZJnwMjbbioGjKFsUghDgx;
	}

	bool IEquatable<uWOqpRQeRUtDCJArQdGhUlVIEJbt>.Equals(uWOqpRQeRUtDCJArQdGhUlVIEJbt other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool MCZOJLaoViTsEDMnhBAtZDqXRzRo(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is uWOqpRQeRUtDCJArQdGhUlVIEJbt)
		{
			return Equals((uWOqpRQeRUtDCJArQdGhUlVIEJbt)P_0);
		}
		return false;
	}

	public int dHmfIfOvPMVDZtrwOKYUGtKlmNAd()
	{
		return YdNuMPMZJnwMjbbioGjKFsUghDgx;
	}

	[SpecialName]
	public static bool QoOniuTeJKIxqcOuKTSMPxFKEedib(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0, uWOqpRQeRUtDCJArQdGhUlVIEJbt P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool qZyHiBGRHsUUXxCyEbsMdZVChmYBA(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0, uWOqpRQeRUtDCJArQdGhUlVIEJbt P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool PMDgsKyazRldbtKMCpVbnSLewPTt(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0)
	{
		return P_0.YdNuMPMZJnwMjbbioGjKFsUghDgx != 0;
	}

	[SpecialName]
	public static uWOqpRQeRUtDCJArQdGhUlVIEJbt MOfaPDImCmDmbaegWGjutVqaOIJX(bool P_0)
	{
		return new uWOqpRQeRUtDCJArQdGhUlVIEJbt(P_0);
	}

	public string XQVSKNZAKnxdBaMLcHfVJEGRMVVP()
	{
		return $"{YdNuMPMZJnwMjbbioGjKFsUghDgx != 0}";
	}
}
