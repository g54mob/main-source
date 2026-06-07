using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct WQqLGQywLMLNSSEEpkLCmvqBKOXC : IEquatable<WQqLGQywLMLNSSEEpkLCmvqBKOXC>
{
	public ModifierKey MIxLMWwQJMcJovsdIIGRAmxyypaL;

	public ModifierKey fxNCAHtdCsJDvWYpfiXMfLfrfXVH;

	public ModifierKey VNplPFQNgQXLmKziduylcvkLUOiO;

	private ModifierKey TOeQjtXAmEJKcihHdegXiMOIfTTY
	{
		get
		{
			if (P_0 <= 0)
			{
				return MIxLMWwQJMcJovsdIIGRAmxyypaL;
			}
			if (P_0 == 1)
			{
				return fxNCAHtdCsJDvWYpfiXMfLfrfXVH;
			}
			if (P_0 >= 2)
			{
				return VNplPFQNgQXLmKziduylcvkLUOiO;
			}
			return MIxLMWwQJMcJovsdIIGRAmxyypaL;
		}
		set
		{
			if (num <= 0)
			{
				MIxLMWwQJMcJovsdIIGRAmxyypaL = modifierKey;
			}
			if (num == 1)
			{
				fxNCAHtdCsJDvWYpfiXMfLfrfXVH = modifierKey;
			}
			if (num >= 2)
			{
				VNplPFQNgQXLmKziduylcvkLUOiO = modifierKey;
			}
		}
	}

	public WQqLGQywLMLNSSEEpkLCmvqBKOXC(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		MIxLMWwQJMcJovsdIIGRAmxyypaL = P_0;
		fxNCAHtdCsJDvWYpfiXMfLfrfXVH = P_1;
		VNplPFQNgQXLmKziduylcvkLUOiO = P_2;
	}

	public void wJjPIIRJfHhEbGedUconecGfiwzgB()
	{
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

	public static WQqLGQywLMLNSSEEpkLCmvqBKOXC uknhQfjeaUxvodiETKkZmIhKpMdp(ModifierKeyFlags P_0)
	{
		WQqLGQywLMLNSSEEpkLCmvqBKOXC result = default(WQqLGQywLMLNSSEEpkLCmvqBKOXC);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.pbqeexEwvGckXSgUKgfrquOrpXfxA(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.pbqeexEwvGckXSgUKgfrquOrpXfxA(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.pbqeexEwvGckXSgUKgfrquOrpXfxA(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.pbqeexEwvGckXSgUKgfrquOrpXfxA(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(WQqLGQywLMLNSSEEpkLCmvqBKOXC other)
	{
		if (MIxLMWwQJMcJovsdIIGRAmxyypaL == other.MIxLMWwQJMcJovsdIIGRAmxyypaL && fxNCAHtdCsJDvWYpfiXMfLfrfXVH == other.fxNCAHtdCsJDvWYpfiXMfLfrfXVH)
		{
			return VNplPFQNgQXLmKziduylcvkLUOiO == other.VNplPFQNgQXLmKziduylcvkLUOiO;
		}
		return false;
	}

	public bool gEZzHVTSbDWAkBDNwKSzaMrNdeacA(object P_0)
	{
		if (P_0 == null || !(P_0 is WQqLGQywLMLNSSEEpkLCmvqBKOXC))
		{
			return false;
		}
		return Equals((WQqLGQywLMLNSSEEpkLCmvqBKOXC)P_0);
	}

	public int OUGUbLMNttjKmzEBoSdMtBkhdBDR()
	{
		return ((17 * 29 + MIxLMWwQJMcJovsdIIGRAmxyypaL.GetHashCode()) * 29 + fxNCAHtdCsJDvWYpfiXMfLfrfXVH.GetHashCode()) * 29 + VNplPFQNgQXLmKziduylcvkLUOiO.GetHashCode();
	}

	[SpecialName]
	public static bool vdnDEStJwzgDPNDdxCDXqtnrouxE(WQqLGQywLMLNSSEEpkLCmvqBKOXC P_0, WQqLGQywLMLNSSEEpkLCmvqBKOXC P_1)
	{
		if (P_0.MIxLMWwQJMcJovsdIIGRAmxyypaL == P_1.MIxLMWwQJMcJovsdIIGRAmxyypaL && P_0.fxNCAHtdCsJDvWYpfiXMfLfrfXVH == P_1.fxNCAHtdCsJDvWYpfiXMfLfrfXVH)
		{
			return P_0.VNplPFQNgQXLmKziduylcvkLUOiO == P_1.VNplPFQNgQXLmKziduylcvkLUOiO;
		}
		return false;
	}

	[SpecialName]
	public static bool ZgZSZRyMUzENffqUWKcCdKJsPzMs(WQqLGQywLMLNSSEEpkLCmvqBKOXC P_0, WQqLGQywLMLNSSEEpkLCmvqBKOXC P_1)
	{
		return !vdnDEStJwzgDPNDdxCDXqtnrouxE(P_0, P_1);
	}
}
