using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct ZmQAsnFateHowPIRZHWVpzpnRNMx : IEquatable<ZmQAsnFateHowPIRZHWVpzpnRNMx>
{
	public ModifierKey QKPjhXmRwvNIIzfJCjVfDFypgwPG;

	public ModifierKey dPwiQmWMwlHGtFtdaaDXReMzJoZo;

	public ModifierKey KRhiCoPDaDVztaJOVEfxVBBBDmyt;

	private ModifierKey JfgqYxlvpZPDOUWFjIAXRKpDXgSh
	{
		get
		{
			if (P_0 <= 0)
			{
				return QKPjhXmRwvNIIzfJCjVfDFypgwPG;
			}
			if (P_0 == 1)
			{
				return dPwiQmWMwlHGtFtdaaDXReMzJoZo;
			}
			if (P_0 >= 2)
			{
				return KRhiCoPDaDVztaJOVEfxVBBBDmyt;
			}
			return QKPjhXmRwvNIIzfJCjVfDFypgwPG;
		}
		set
		{
			if (num <= 0)
			{
				QKPjhXmRwvNIIzfJCjVfDFypgwPG = modifierKey;
			}
			if (num == 1)
			{
				dPwiQmWMwlHGtFtdaaDXReMzJoZo = modifierKey;
			}
			if (num >= 2)
			{
				KRhiCoPDaDVztaJOVEfxVBBBDmyt = modifierKey;
			}
		}
	}

	public ZmQAsnFateHowPIRZHWVpzpnRNMx(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		QKPjhXmRwvNIIzfJCjVfDFypgwPG = P_0;
		dPwiQmWMwlHGtFtdaaDXReMzJoZo = P_1;
		KRhiCoPDaDVztaJOVEfxVBBBDmyt = P_2;
	}

	public void lKyAHChESAqTpcyAhUeFHdeoZPpVB()
	{
		if (QKPjhXmRwvNIIzfJCjVfDFypgwPG != ModifierKey.None)
		{
			QKPjhXmRwvNIIzfJCjVfDFypgwPG = ModifierKey.None;
		}
		if (dPwiQmWMwlHGtFtdaaDXReMzJoZo != ModifierKey.None)
		{
			dPwiQmWMwlHGtFtdaaDXReMzJoZo = ModifierKey.None;
		}
		if (KRhiCoPDaDVztaJOVEfxVBBBDmyt != ModifierKey.None)
		{
			KRhiCoPDaDVztaJOVEfxVBBBDmyt = ModifierKey.None;
		}
	}

	public static ZmQAsnFateHowPIRZHWVpzpnRNMx GwHsVqHKGnDpyMlwValsgFvdlihHA(ModifierKeyFlags P_0)
	{
		ZmQAsnFateHowPIRZHWVpzpnRNMx result = default(ZmQAsnFateHowPIRZHWVpzpnRNMx);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.BSgMbCYvBsnmdJaLGjcuaNqPLRoYA(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.BSgMbCYvBsnmdJaLGjcuaNqPLRoYA(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.BSgMbCYvBsnmdJaLGjcuaNqPLRoYA(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.BSgMbCYvBsnmdJaLGjcuaNqPLRoYA(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(ZmQAsnFateHowPIRZHWVpzpnRNMx other)
	{
		if (QKPjhXmRwvNIIzfJCjVfDFypgwPG == other.QKPjhXmRwvNIIzfJCjVfDFypgwPG && dPwiQmWMwlHGtFtdaaDXReMzJoZo == other.dPwiQmWMwlHGtFtdaaDXReMzJoZo)
		{
			return KRhiCoPDaDVztaJOVEfxVBBBDmyt == other.KRhiCoPDaDVztaJOVEfxVBBBDmyt;
		}
		return false;
	}

	bool IEquatable<ZmQAsnFateHowPIRZHWVpzpnRNMx>.Equals(ZmQAsnFateHowPIRZHWVpzpnRNMx other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool BtJiChtEHlNdAEeezFMbsUVuIEHJ(object P_0)
	{
		if (P_0 == null || !(P_0 is ZmQAsnFateHowPIRZHWVpzpnRNMx))
		{
			return false;
		}
		return Equals((ZmQAsnFateHowPIRZHWVpzpnRNMx)P_0);
	}

	public int dYoyHCXfRLemadjRHdKUrmLpEvUJ()
	{
		return ((17 * 29 + QKPjhXmRwvNIIzfJCjVfDFypgwPG.GetHashCode()) * 29 + dPwiQmWMwlHGtFtdaaDXReMzJoZo.GetHashCode()) * 29 + KRhiCoPDaDVztaJOVEfxVBBBDmyt.GetHashCode();
	}

	[SpecialName]
	public static bool VdcBnTVHEEdFiBuYWjccxOUpGsUy(ZmQAsnFateHowPIRZHWVpzpnRNMx P_0, ZmQAsnFateHowPIRZHWVpzpnRNMx P_1)
	{
		if (P_0.QKPjhXmRwvNIIzfJCjVfDFypgwPG == P_1.QKPjhXmRwvNIIzfJCjVfDFypgwPG && P_0.dPwiQmWMwlHGtFtdaaDXReMzJoZo == P_1.dPwiQmWMwlHGtFtdaaDXReMzJoZo)
		{
			return P_0.KRhiCoPDaDVztaJOVEfxVBBBDmyt == P_1.KRhiCoPDaDVztaJOVEfxVBBBDmyt;
		}
		return false;
	}

	[SpecialName]
	public static bool ehKlyqVCtybMXujvRemMdsCtbPNEA(ZmQAsnFateHowPIRZHWVpzpnRNMx P_0, ZmQAsnFateHowPIRZHWVpzpnRNMx P_1)
	{
		return !VdcBnTVHEEdFiBuYWjccxOUpGsUy(P_0, P_1);
	}
}
