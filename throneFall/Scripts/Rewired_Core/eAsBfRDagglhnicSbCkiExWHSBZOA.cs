using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct eAsBfRDagglhnicSbCkiExWHSBZOA : IEquatable<eAsBfRDagglhnicSbCkiExWHSBZOA>
{
	public ModifierKey farIvpkQhxAmLCAIebDOJzDZwiUT;

	public ModifierKey IBOJOEILlxMWeoMuYYIaLGfPDqMR;

	public ModifierKey bDLRGMPhlREQkJZFbcEAPeijhsvM;

	private ModifierKey keIHnXpagBIYThPQNwgcVhtxPBrc
	{
		get
		{
			if (P_0 <= 0)
			{
				return farIvpkQhxAmLCAIebDOJzDZwiUT;
			}
			if (P_0 == 1)
			{
				return IBOJOEILlxMWeoMuYYIaLGfPDqMR;
			}
			if (P_0 >= 2)
			{
				return bDLRGMPhlREQkJZFbcEAPeijhsvM;
			}
			return farIvpkQhxAmLCAIebDOJzDZwiUT;
		}
		set
		{
			if (num <= 0)
			{
				farIvpkQhxAmLCAIebDOJzDZwiUT = iBOJOEILlxMWeoMuYYIaLGfPDqMR;
			}
			if (num == 1)
			{
				IBOJOEILlxMWeoMuYYIaLGfPDqMR = iBOJOEILlxMWeoMuYYIaLGfPDqMR;
			}
			if (num >= 2)
			{
				bDLRGMPhlREQkJZFbcEAPeijhsvM = iBOJOEILlxMWeoMuYYIaLGfPDqMR;
			}
		}
	}

	public eAsBfRDagglhnicSbCkiExWHSBZOA(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		farIvpkQhxAmLCAIebDOJzDZwiUT = P_0;
		IBOJOEILlxMWeoMuYYIaLGfPDqMR = P_1;
		bDLRGMPhlREQkJZFbcEAPeijhsvM = P_2;
	}

	public void QOYgsyBEPWWEiAHNixKyHjFtqPmQA()
	{
		if (farIvpkQhxAmLCAIebDOJzDZwiUT != ModifierKey.None)
		{
			farIvpkQhxAmLCAIebDOJzDZwiUT = ModifierKey.None;
		}
		if (IBOJOEILlxMWeoMuYYIaLGfPDqMR != ModifierKey.None)
		{
			IBOJOEILlxMWeoMuYYIaLGfPDqMR = ModifierKey.None;
		}
		if (bDLRGMPhlREQkJZFbcEAPeijhsvM != ModifierKey.None)
		{
			bDLRGMPhlREQkJZFbcEAPeijhsvM = ModifierKey.None;
		}
	}

	public static eAsBfRDagglhnicSbCkiExWHSBZOA vtdMuKFGBlggrefjvxNVIZCJriqZ(ModifierKeyFlags P_0)
	{
		eAsBfRDagglhnicSbCkiExWHSBZOA result = default(eAsBfRDagglhnicSbCkiExWHSBZOA);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.cCIUCwCiAaVzgsNEeGGZRCNpmZts(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.cCIUCwCiAaVzgsNEeGGZRCNpmZts(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.cCIUCwCiAaVzgsNEeGGZRCNpmZts(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.cCIUCwCiAaVzgsNEeGGZRCNpmZts(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(eAsBfRDagglhnicSbCkiExWHSBZOA other)
	{
		if (farIvpkQhxAmLCAIebDOJzDZwiUT == other.farIvpkQhxAmLCAIebDOJzDZwiUT && IBOJOEILlxMWeoMuYYIaLGfPDqMR == other.IBOJOEILlxMWeoMuYYIaLGfPDqMR)
		{
			return bDLRGMPhlREQkJZFbcEAPeijhsvM == other.bDLRGMPhlREQkJZFbcEAPeijhsvM;
		}
		return false;
	}

	bool IEquatable<eAsBfRDagglhnicSbCkiExWHSBZOA>.Equals(eAsBfRDagglhnicSbCkiExWHSBZOA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool qztDDFbXrJOLIdxgZdQCsinQQWwb(object P_0)
	{
		if (P_0 == null || !(P_0 is eAsBfRDagglhnicSbCkiExWHSBZOA))
		{
			return false;
		}
		return Equals((eAsBfRDagglhnicSbCkiExWHSBZOA)P_0);
	}

	public int WlGZFeXBQZjIzAEVxayhzghNATZe()
	{
		return ((17 * 29 + farIvpkQhxAmLCAIebDOJzDZwiUT.GetHashCode()) * 29 + IBOJOEILlxMWeoMuYYIaLGfPDqMR.GetHashCode()) * 29 + bDLRGMPhlREQkJZFbcEAPeijhsvM.GetHashCode();
	}

	[SpecialName]
	public static bool yNMAXtJzVIAnncLNgUbLxPhRceZH(eAsBfRDagglhnicSbCkiExWHSBZOA P_0, eAsBfRDagglhnicSbCkiExWHSBZOA P_1)
	{
		if (P_0.farIvpkQhxAmLCAIebDOJzDZwiUT == P_1.farIvpkQhxAmLCAIebDOJzDZwiUT && P_0.IBOJOEILlxMWeoMuYYIaLGfPDqMR == P_1.IBOJOEILlxMWeoMuYYIaLGfPDqMR)
		{
			return P_0.bDLRGMPhlREQkJZFbcEAPeijhsvM == P_1.bDLRGMPhlREQkJZFbcEAPeijhsvM;
		}
		return false;
	}

	[SpecialName]
	public static bool JTkQZQVbcegTYBLgfsUxnhdNcJSYA(eAsBfRDagglhnicSbCkiExWHSBZOA P_0, eAsBfRDagglhnicSbCkiExWHSBZOA P_1)
	{
		return !yNMAXtJzVIAnncLNgUbLxPhRceZH(P_0, P_1);
	}
}
