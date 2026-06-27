using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct ERzpAcEPwaeYZpgZgfnRECmQBftab : IEquatable<ERzpAcEPwaeYZpgZgfnRECmQBftab>
{
	public ModifierKey RswHfKxHnnAnlfLRjsAdTkfMKKiUA;

	public ModifierKey eNVgwhZRbfahWjDlZSLDwKLKgIeFA;

	public ModifierKey BSSCanDCbXxlUpGCcVhxoxYiWQXo;

	private ModifierKey IZJeeekuwZIbldwYWclRniFmyjtMA
	{
		get
		{
			if (P_0 <= 0)
			{
				return RswHfKxHnnAnlfLRjsAdTkfMKKiUA;
			}
			if (P_0 == 1)
			{
				return eNVgwhZRbfahWjDlZSLDwKLKgIeFA;
			}
			if (P_0 >= 2)
			{
				return BSSCanDCbXxlUpGCcVhxoxYiWQXo;
			}
			return RswHfKxHnnAnlfLRjsAdTkfMKKiUA;
		}
		set
		{
			if (num <= 0)
			{
				RswHfKxHnnAnlfLRjsAdTkfMKKiUA = modifierKey;
			}
			if (num == 1)
			{
				eNVgwhZRbfahWjDlZSLDwKLKgIeFA = modifierKey;
			}
			if (num >= 2)
			{
				BSSCanDCbXxlUpGCcVhxoxYiWQXo = modifierKey;
			}
		}
	}

	public ERzpAcEPwaeYZpgZgfnRECmQBftab(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		RswHfKxHnnAnlfLRjsAdTkfMKKiUA = P_0;
		eNVgwhZRbfahWjDlZSLDwKLKgIeFA = P_1;
		BSSCanDCbXxlUpGCcVhxoxYiWQXo = P_2;
	}

	public void aTBToPVjPQtOKCMClROZGlhydrKj()
	{
		if (RswHfKxHnnAnlfLRjsAdTkfMKKiUA != ModifierKey.None)
		{
			RswHfKxHnnAnlfLRjsAdTkfMKKiUA = ModifierKey.None;
		}
		if (eNVgwhZRbfahWjDlZSLDwKLKgIeFA != ModifierKey.None)
		{
			eNVgwhZRbfahWjDlZSLDwKLKgIeFA = ModifierKey.None;
		}
		if (BSSCanDCbXxlUpGCcVhxoxYiWQXo != ModifierKey.None)
		{
			BSSCanDCbXxlUpGCcVhxoxYiWQXo = ModifierKey.None;
		}
	}

	public static ERzpAcEPwaeYZpgZgfnRECmQBftab ZhyRfbEGFlFXXqDwoCUocpySwIQN(ModifierKeyFlags P_0)
	{
		ERzpAcEPwaeYZpgZgfnRECmQBftab result = default(ERzpAcEPwaeYZpgZgfnRECmQBftab);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.KRPcjZNNOibWEfvFrTHkBolsZpPrA(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.KRPcjZNNOibWEfvFrTHkBolsZpPrA(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.KRPcjZNNOibWEfvFrTHkBolsZpPrA(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.KRPcjZNNOibWEfvFrTHkBolsZpPrA(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(ERzpAcEPwaeYZpgZgfnRECmQBftab other)
	{
		if (RswHfKxHnnAnlfLRjsAdTkfMKKiUA == other.RswHfKxHnnAnlfLRjsAdTkfMKKiUA && eNVgwhZRbfahWjDlZSLDwKLKgIeFA == other.eNVgwhZRbfahWjDlZSLDwKLKgIeFA)
		{
			return BSSCanDCbXxlUpGCcVhxoxYiWQXo == other.BSSCanDCbXxlUpGCcVhxoxYiWQXo;
		}
		return false;
	}

	bool IEquatable<ERzpAcEPwaeYZpgZgfnRECmQBftab>.Equals(ERzpAcEPwaeYZpgZgfnRECmQBftab other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool OkcTgqeLVzzpjyYyMcofBjIFPywo(object P_0)
	{
		if (P_0 == null || !(P_0 is ERzpAcEPwaeYZpgZgfnRECmQBftab))
		{
			return false;
		}
		return Equals((ERzpAcEPwaeYZpgZgfnRECmQBftab)P_0);
	}

	public int iFHCiVAGKZOAVMJTuUpKOCISjytNA()
	{
		return ((17 * 29 + RswHfKxHnnAnlfLRjsAdTkfMKKiUA.GetHashCode()) * 29 + eNVgwhZRbfahWjDlZSLDwKLKgIeFA.GetHashCode()) * 29 + BSSCanDCbXxlUpGCcVhxoxYiWQXo.GetHashCode();
	}

	[SpecialName]
	public static bool YERPrOAdPIMnPvECxmLwMzTYjQvQ(ERzpAcEPwaeYZpgZgfnRECmQBftab P_0, ERzpAcEPwaeYZpgZgfnRECmQBftab P_1)
	{
		if (P_0.RswHfKxHnnAnlfLRjsAdTkfMKKiUA == P_1.RswHfKxHnnAnlfLRjsAdTkfMKKiUA && P_0.eNVgwhZRbfahWjDlZSLDwKLKgIeFA == P_1.eNVgwhZRbfahWjDlZSLDwKLKgIeFA)
		{
			return P_0.BSSCanDCbXxlUpGCcVhxoxYiWQXo == P_1.BSSCanDCbXxlUpGCcVhxoxYiWQXo;
		}
		return false;
	}

	[SpecialName]
	public static bool bCdFgpKVcsavyKdlmgXGEHDOrvan(ERzpAcEPwaeYZpgZgfnRECmQBftab P_0, ERzpAcEPwaeYZpgZgfnRECmQBftab P_1)
	{
		return !YERPrOAdPIMnPvECxmLwMzTYjQvQ(P_0, P_1);
	}
}
