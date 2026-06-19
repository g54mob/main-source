using System;
using Rewired;

internal struct TwhJHDwMitMPZPGfcRtEVjrcGrF : IEquatable<TwhJHDwMitMPZPGfcRtEVjrcGrF>
{
	public ModifierKey RCfsEFwOpxyMtsvpZivwrNvBSuI;

	public ModifierKey oRBMwSfgfFIxuTfPcHBtCIhGdNt;

	public ModifierKey EUzOXCQPGfeOpZnmkDNSdDouKKMo;

	private ModifierKey this[int index]
	{
		get
		{
			if (index <= 0)
			{
				return RCfsEFwOpxyMtsvpZivwrNvBSuI;
			}
			if (index == 1)
			{
				return oRBMwSfgfFIxuTfPcHBtCIhGdNt;
			}
			if (index >= 2)
			{
				return EUzOXCQPGfeOpZnmkDNSdDouKKMo;
			}
			return RCfsEFwOpxyMtsvpZivwrNvBSuI;
		}
		set
		{
			if (index <= 0)
			{
				RCfsEFwOpxyMtsvpZivwrNvBSuI = value;
			}
			if (index == 1)
			{
				oRBMwSfgfFIxuTfPcHBtCIhGdNt = value;
			}
			if (index >= 2)
			{
				EUzOXCQPGfeOpZnmkDNSdDouKKMo = value;
			}
		}
	}

	public TwhJHDwMitMPZPGfcRtEVjrcGrF(ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		RCfsEFwOpxyMtsvpZivwrNvBSuI = modifierKey1;
		oRBMwSfgfFIxuTfPcHBtCIhGdNt = modifierKey2;
		EUzOXCQPGfeOpZnmkDNSdDouKKMo = modifierKey3;
	}

	public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
	{
		if (RCfsEFwOpxyMtsvpZivwrNvBSuI != ModifierKey.None)
		{
			RCfsEFwOpxyMtsvpZivwrNvBSuI = ModifierKey.None;
		}
		if (oRBMwSfgfFIxuTfPcHBtCIhGdNt != ModifierKey.None)
		{
			oRBMwSfgfFIxuTfPcHBtCIhGdNt = ModifierKey.None;
		}
		if (EUzOXCQPGfeOpZnmkDNSdDouKKMo != ModifierKey.None)
		{
			EUzOXCQPGfeOpZnmkDNSdDouKKMo = ModifierKey.None;
		}
	}

	public static TwhJHDwMitMPZPGfcRtEVjrcGrF pKxcrghASbAgdGwMKtZePMtbdORa(ModifierKeyFlags P_0)
	{
		TwhJHDwMitMPZPGfcRtEVjrcGrF result = default(TwhJHDwMitMPZPGfcRtEVjrcGrF);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result[num++] = ModifierKey.Control;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result[num++] = ModifierKey.Command;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result[num++] = ModifierKey.Alt;
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result[num++] = ModifierKey.Shift;
		}
		return result;
	}

	public bool Equals(TwhJHDwMitMPZPGfcRtEVjrcGrF other)
	{
		if (RCfsEFwOpxyMtsvpZivwrNvBSuI == other.RCfsEFwOpxyMtsvpZivwrNvBSuI && oRBMwSfgfFIxuTfPcHBtCIhGdNt == other.oRBMwSfgfFIxuTfPcHBtCIhGdNt)
		{
			return EUzOXCQPGfeOpZnmkDNSdDouKKMo == other.EUzOXCQPGfeOpZnmkDNSdDouKKMo;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is TwhJHDwMitMPZPGfcRtEVjrcGrF))
		{
			return false;
		}
		return Equals((TwhJHDwMitMPZPGfcRtEVjrcGrF)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + RCfsEFwOpxyMtsvpZivwrNvBSuI.GetHashCode();
		num = num * 29 + oRBMwSfgfFIxuTfPcHBtCIhGdNt.GetHashCode();
		return num * 29 + EUzOXCQPGfeOpZnmkDNSdDouKKMo.GetHashCode();
	}

	public static bool operator ==(TwhJHDwMitMPZPGfcRtEVjrcGrF a, TwhJHDwMitMPZPGfcRtEVjrcGrF b)
	{
		if (a.RCfsEFwOpxyMtsvpZivwrNvBSuI == b.RCfsEFwOpxyMtsvpZivwrNvBSuI && a.oRBMwSfgfFIxuTfPcHBtCIhGdNt == b.oRBMwSfgfFIxuTfPcHBtCIhGdNt)
		{
			return a.EUzOXCQPGfeOpZnmkDNSdDouKKMo == b.EUzOXCQPGfeOpZnmkDNSdDouKKMo;
		}
		return false;
	}

	public static bool operator !=(TwhJHDwMitMPZPGfcRtEVjrcGrF a, TwhJHDwMitMPZPGfcRtEVjrcGrF b)
	{
		return !(a == b);
	}
}
