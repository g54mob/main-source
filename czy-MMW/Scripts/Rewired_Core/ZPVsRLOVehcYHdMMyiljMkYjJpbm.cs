using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct ZPVsRLOVehcYHdMMyiljMkYjJpbm : IEquatable<ZPVsRLOVehcYHdMMyiljMkYjJpbm>
{
	public ModifierKey UqWZutphnsHnpZcIfXAFuWTpIwas;

	public ModifierKey xsbhpMhZfeHdYEdcPMBfEqdcpqioB;

	public ModifierKey WswJlGEkhOTxSYCPsunHajaDUyBl;

	private ModifierKey ZSdDhNepkYjfxsPXAfjdqXpTwBrP
	{
		get
		{
			if (P_0 <= 0)
			{
				return UqWZutphnsHnpZcIfXAFuWTpIwas;
			}
			if (P_0 == 1)
			{
				return xsbhpMhZfeHdYEdcPMBfEqdcpqioB;
			}
			if (P_0 >= 2)
			{
				return WswJlGEkhOTxSYCPsunHajaDUyBl;
			}
			return UqWZutphnsHnpZcIfXAFuWTpIwas;
		}
		set
		{
			if (num <= 0)
			{
				UqWZutphnsHnpZcIfXAFuWTpIwas = modifierKey;
			}
			if (num == 1)
			{
				xsbhpMhZfeHdYEdcPMBfEqdcpqioB = modifierKey;
			}
			if (num >= 2)
			{
				WswJlGEkhOTxSYCPsunHajaDUyBl = modifierKey;
			}
		}
	}

	public ZPVsRLOVehcYHdMMyiljMkYjJpbm(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		UqWZutphnsHnpZcIfXAFuWTpIwas = P_0;
		xsbhpMhZfeHdYEdcPMBfEqdcpqioB = P_1;
		WswJlGEkhOTxSYCPsunHajaDUyBl = P_2;
	}

	public void pvnQAqXsZTlUMYBTxHbvMsFDXPEk()
	{
		if (UqWZutphnsHnpZcIfXAFuWTpIwas != ModifierKey.None)
		{
			UqWZutphnsHnpZcIfXAFuWTpIwas = ModifierKey.None;
		}
		if (xsbhpMhZfeHdYEdcPMBfEqdcpqioB != ModifierKey.None)
		{
			xsbhpMhZfeHdYEdcPMBfEqdcpqioB = ModifierKey.None;
		}
		if (WswJlGEkhOTxSYCPsunHajaDUyBl != ModifierKey.None)
		{
			WswJlGEkhOTxSYCPsunHajaDUyBl = ModifierKey.None;
		}
	}

	public static ZPVsRLOVehcYHdMMyiljMkYjJpbm KDMWJSOVpaZWZcfXiUQIwKOlqqAd(ModifierKeyFlags P_0)
	{
		ZPVsRLOVehcYHdMMyiljMkYjJpbm result = default(ZPVsRLOVehcYHdMMyiljMkYjJpbm);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.BnhumtJCTzYAQbQklVEtkHBNDVrb(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.BnhumtJCTzYAQbQklVEtkHBNDVrb(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.BnhumtJCTzYAQbQklVEtkHBNDVrb(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.BnhumtJCTzYAQbQklVEtkHBNDVrb(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(ZPVsRLOVehcYHdMMyiljMkYjJpbm other)
	{
		if (UqWZutphnsHnpZcIfXAFuWTpIwas == other.UqWZutphnsHnpZcIfXAFuWTpIwas && xsbhpMhZfeHdYEdcPMBfEqdcpqioB == other.xsbhpMhZfeHdYEdcPMBfEqdcpqioB)
		{
			return WswJlGEkhOTxSYCPsunHajaDUyBl == other.WswJlGEkhOTxSYCPsunHajaDUyBl;
		}
		return false;
	}

	bool IEquatable<ZPVsRLOVehcYHdMMyiljMkYjJpbm>.Equals(ZPVsRLOVehcYHdMMyiljMkYjJpbm other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool TiGQhZalBgjxjcXdQBkFLqoukGyn(object P_0)
	{
		if (P_0 == null || !(P_0 is ZPVsRLOVehcYHdMMyiljMkYjJpbm))
		{
			return false;
		}
		return Equals((ZPVsRLOVehcYHdMMyiljMkYjJpbm)P_0);
	}

	public int hzhKliSoAIdATCHOcYvugYctNKrOA()
	{
		return ((17 * 29 + UqWZutphnsHnpZcIfXAFuWTpIwas.GetHashCode()) * 29 + xsbhpMhZfeHdYEdcPMBfEqdcpqioB.GetHashCode()) * 29 + WswJlGEkhOTxSYCPsunHajaDUyBl.GetHashCode();
	}

	[SpecialName]
	public static bool NEhacdHMJPPrZOrTzxDCKQfplebrA(ZPVsRLOVehcYHdMMyiljMkYjJpbm P_0, ZPVsRLOVehcYHdMMyiljMkYjJpbm P_1)
	{
		if (P_0.UqWZutphnsHnpZcIfXAFuWTpIwas == P_1.UqWZutphnsHnpZcIfXAFuWTpIwas && P_0.xsbhpMhZfeHdYEdcPMBfEqdcpqioB == P_1.xsbhpMhZfeHdYEdcPMBfEqdcpqioB)
		{
			return P_0.WswJlGEkhOTxSYCPsunHajaDUyBl == P_1.WswJlGEkhOTxSYCPsunHajaDUyBl;
		}
		return false;
	}

	[SpecialName]
	public static bool ocZfKfWqFhcmSQeDsZAoIzXlFgmE(ZPVsRLOVehcYHdMMyiljMkYjJpbm P_0, ZPVsRLOVehcYHdMMyiljMkYjJpbm P_1)
	{
		return !NEhacdHMJPPrZOrTzxDCKQfplebrA(P_0, P_1);
	}
}
