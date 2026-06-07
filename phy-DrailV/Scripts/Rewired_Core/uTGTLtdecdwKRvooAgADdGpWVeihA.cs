using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct uTGTLtdecdwKRvooAgADdGpWVeihA : IEquatable<uTGTLtdecdwKRvooAgADdGpWVeihA>
{
	public KeyboardKeyCode ddynOjTbMjyvDFFKYvtuExCJyJRA;

	public ModifierKey MIxLMWwQJMcJovsdIIGRAmxyypaL;

	public ModifierKey fxNCAHtdCsJDvWYpfiXMfLfrfXVH;

	public ModifierKey VNplPFQNgQXLmKziduylcvkLUOiO;

	public uTGTLtdecdwKRvooAgADdGpWVeihA(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		ddynOjTbMjyvDFFKYvtuExCJyJRA = P_0;
		MIxLMWwQJMcJovsdIIGRAmxyypaL = P_1;
		fxNCAHtdCsJDvWYpfiXMfLfrfXVH = P_2;
		VNplPFQNgQXLmKziduylcvkLUOiO = P_3;
	}

	public void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
		if (ddynOjTbMjyvDFFKYvtuExCJyJRA != KeyboardKeyCode.None)
		{
			ddynOjTbMjyvDFFKYvtuExCJyJRA = KeyboardKeyCode.None;
		}
		if (MIxLMWwQJMcJovsdIIGRAmxyypaL != ModifierKey.None)
		{
			MIxLMWwQJMcJovsdIIGRAmxyypaL = ModifierKey.None;
		}
		if (fxNCAHtdCsJDvWYpfiXMfLfrfXVH != ModifierKey.None)
		{
			fxNCAHtdCsJDvWYpfiXMfLfrfXVH = ModifierKey.None;
		}
		if (VNplPFQNgQXLmKziduylcvkLUOiO != ModifierKey.None)
		{
			VNplPFQNgQXLmKziduylcvkLUOiO = ModifierKey.None;
		}
	}

	public bool Equals(uTGTLtdecdwKRvooAgADdGpWVeihA other)
	{
		if (ddynOjTbMjyvDFFKYvtuExCJyJRA == other.ddynOjTbMjyvDFFKYvtuExCJyJRA && MIxLMWwQJMcJovsdIIGRAmxyypaL == other.MIxLMWwQJMcJovsdIIGRAmxyypaL && fxNCAHtdCsJDvWYpfiXMfLfrfXVH == other.fxNCAHtdCsJDvWYpfiXMfLfrfXVH)
		{
			return VNplPFQNgQXLmKziduylcvkLUOiO == other.VNplPFQNgQXLmKziduylcvkLUOiO;
		}
		return false;
	}

	public bool gEZzHVTSbDWAkBDNwKSzaMrNdeacA(object P_0)
	{
		if (P_0 == null || !(P_0 is uTGTLtdecdwKRvooAgADdGpWVeihA))
		{
			return false;
		}
		return Equals((uTGTLtdecdwKRvooAgADdGpWVeihA)P_0);
	}

	public int OUGUbLMNttjKmzEBoSdMtBkhdBDR()
	{
		return (((17 * 29 + ddynOjTbMjyvDFFKYvtuExCJyJRA.GetHashCode()) * 29 + MIxLMWwQJMcJovsdIIGRAmxyypaL.GetHashCode()) * 29 + fxNCAHtdCsJDvWYpfiXMfLfrfXVH.GetHashCode()) * 29 + VNplPFQNgQXLmKziduylcvkLUOiO.GetHashCode();
	}

	[SpecialName]
	public static bool vdnDEStJwzgDPNDdxCDXqtnrouxE(uTGTLtdecdwKRvooAgADdGpWVeihA P_0, uTGTLtdecdwKRvooAgADdGpWVeihA P_1)
	{
		if (P_0.ddynOjTbMjyvDFFKYvtuExCJyJRA == P_1.ddynOjTbMjyvDFFKYvtuExCJyJRA && P_0.MIxLMWwQJMcJovsdIIGRAmxyypaL == P_1.MIxLMWwQJMcJovsdIIGRAmxyypaL && P_0.fxNCAHtdCsJDvWYpfiXMfLfrfXVH == P_1.fxNCAHtdCsJDvWYpfiXMfLfrfXVH)
		{
			return P_0.VNplPFQNgQXLmKziduylcvkLUOiO == P_1.VNplPFQNgQXLmKziduylcvkLUOiO;
		}
		return false;
	}

	[SpecialName]
	public static bool ZgZSZRyMUzENffqUWKcCdKJsPzMs(uTGTLtdecdwKRvooAgADdGpWVeihA P_0, uTGTLtdecdwKRvooAgADdGpWVeihA P_1)
	{
		return !vdnDEStJwzgDPNDdxCDXqtnrouxE(P_0, P_1);
	}
}
