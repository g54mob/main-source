using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout((LayoutKind)0, Size = 4)]
internal struct NPJJVDbRziHVpFFVsJeqXajCKrBx : IEquatable<NPJJVDbRziHVpFFVsJeqXajCKrBx>
{
	private int fOcPVctrDgGAgzWYrkRiOokcxCic;

	public bool Equals(NPJJVDbRziHVpFFVsJeqXajCKrBx other)
	{
		return fOcPVctrDgGAgzWYrkRiOokcxCic == other.fOcPVctrDgGAgzWYrkRiOokcxCic;
	}

	bool IEquatable<NPJJVDbRziHVpFFVsJeqXajCKrBx>.Equals(NPJJVDbRziHVpFFVsJeqXajCKrBx other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool ppUUqTRZpGaGnPPPZgDiCNCLiNzgA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is NPJJVDbRziHVpFFVsJeqXajCKrBx)
		{
			return Equals((NPJJVDbRziHVpFFVsJeqXajCKrBx)P_0);
		}
		return false;
	}

	public int IvxBSrtJDqcrizsPiSHNDRVpPGoV()
	{
		return fOcPVctrDgGAgzWYrkRiOokcxCic;
	}

	[SpecialName]
	public static bool ifQDFSENNzrHACfiwdYqbonhqrjHb(NPJJVDbRziHVpFFVsJeqXajCKrBx P_0)
	{
		return P_0.fOcPVctrDgGAgzWYrkRiOokcxCic != 0;
	}

	public string kISmtXajuZsXimPtMaaIGZuVolfX()
	{
		return $"{fOcPVctrDgGAgzWYrkRiOokcxCic != 0}";
	}
}
