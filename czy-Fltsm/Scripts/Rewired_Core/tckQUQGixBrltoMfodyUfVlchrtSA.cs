using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct tckQUQGixBrltoMfodyUfVlchrtSA : IEquatable<tckQUQGixBrltoMfodyUfVlchrtSA>
{
	public KeyboardKeyCode BCxIMdkgHknVtQQvpIhHqxHmEhVT;

	public ModifierKey MitOHSHKBIBuSCQbNvsXfjvGhZdf;

	public ModifierKey OHwkunTOAQBnvMydXcGLhzgfCBwR;

	public ModifierKey GFHJxQnhmUWrZRdGDNEwtvBWEQFv;

	public tckQUQGixBrltoMfodyUfVlchrtSA(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		BCxIMdkgHknVtQQvpIhHqxHmEhVT = P_0;
		MitOHSHKBIBuSCQbNvsXfjvGhZdf = P_1;
		OHwkunTOAQBnvMydXcGLhzgfCBwR = P_2;
		GFHJxQnhmUWrZRdGDNEwtvBWEQFv = P_3;
	}

	public void hZkHuvlwpIRJMASbmUGCyvfxTSUV()
	{
		if (BCxIMdkgHknVtQQvpIhHqxHmEhVT != KeyboardKeyCode.None)
		{
			BCxIMdkgHknVtQQvpIhHqxHmEhVT = KeyboardKeyCode.None;
		}
		if (MitOHSHKBIBuSCQbNvsXfjvGhZdf != ModifierKey.None)
		{
			MitOHSHKBIBuSCQbNvsXfjvGhZdf = ModifierKey.None;
		}
		if (OHwkunTOAQBnvMydXcGLhzgfCBwR != ModifierKey.None)
		{
			OHwkunTOAQBnvMydXcGLhzgfCBwR = ModifierKey.None;
		}
		if (GFHJxQnhmUWrZRdGDNEwtvBWEQFv != ModifierKey.None)
		{
			GFHJxQnhmUWrZRdGDNEwtvBWEQFv = ModifierKey.None;
		}
	}

	public bool Equals(tckQUQGixBrltoMfodyUfVlchrtSA other)
	{
		if (BCxIMdkgHknVtQQvpIhHqxHmEhVT == other.BCxIMdkgHknVtQQvpIhHqxHmEhVT && MitOHSHKBIBuSCQbNvsXfjvGhZdf == other.MitOHSHKBIBuSCQbNvsXfjvGhZdf && OHwkunTOAQBnvMydXcGLhzgfCBwR == other.OHwkunTOAQBnvMydXcGLhzgfCBwR)
		{
			return GFHJxQnhmUWrZRdGDNEwtvBWEQFv == other.GFHJxQnhmUWrZRdGDNEwtvBWEQFv;
		}
		return false;
	}

	bool IEquatable<tckQUQGixBrltoMfodyUfVlchrtSA>.Equals(tckQUQGixBrltoMfodyUfVlchrtSA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool qtejXxqWJEfFRshSIoxexAEOfNFhA(object P_0)
	{
		if (P_0 == null || !(P_0 is tckQUQGixBrltoMfodyUfVlchrtSA))
		{
			return false;
		}
		return Equals((tckQUQGixBrltoMfodyUfVlchrtSA)P_0);
	}

	public int hUWApsCyrbXOFaCYxMQHGVAwtTEu()
	{
		return (((17 * 29 + BCxIMdkgHknVtQQvpIhHqxHmEhVT.GetHashCode()) * 29 + MitOHSHKBIBuSCQbNvsXfjvGhZdf.GetHashCode()) * 29 + OHwkunTOAQBnvMydXcGLhzgfCBwR.GetHashCode()) * 29 + GFHJxQnhmUWrZRdGDNEwtvBWEQFv.GetHashCode();
	}

	[SpecialName]
	public static bool lviRPKIjSYXwkUiGtyJhkKTIDWgI(tckQUQGixBrltoMfodyUfVlchrtSA P_0, tckQUQGixBrltoMfodyUfVlchrtSA P_1)
	{
		if (P_0.BCxIMdkgHknVtQQvpIhHqxHmEhVT == P_1.BCxIMdkgHknVtQQvpIhHqxHmEhVT && P_0.MitOHSHKBIBuSCQbNvsXfjvGhZdf == P_1.MitOHSHKBIBuSCQbNvsXfjvGhZdf && P_0.OHwkunTOAQBnvMydXcGLhzgfCBwR == P_1.OHwkunTOAQBnvMydXcGLhzgfCBwR)
		{
			return P_0.GFHJxQnhmUWrZRdGDNEwtvBWEQFv == P_1.GFHJxQnhmUWrZRdGDNEwtvBWEQFv;
		}
		return false;
	}

	[SpecialName]
	public static bool bbEYGwjAObIOYaPxKJyQackWQjGEb(tckQUQGixBrltoMfodyUfVlchrtSA P_0, tckQUQGixBrltoMfodyUfVlchrtSA P_1)
	{
		return !lviRPKIjSYXwkUiGtyJhkKTIDWgI(P_0, P_1);
	}
}
