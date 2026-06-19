using System;
using Rewired;

internal struct fAQxRkfPGErHCkvcDwnufsfdxcK : IEquatable<fAQxRkfPGErHCkvcDwnufsfdxcK>
{
	public KeyboardKeyCode eVxxBexHOjtqqOLiFQGEtbldcFh;

	public ModifierKey RCfsEFwOpxyMtsvpZivwrNvBSuI;

	public ModifierKey oRBMwSfgfFIxuTfPcHBtCIhGdNt;

	public ModifierKey EUzOXCQPGfeOpZnmkDNSdDouKKMo;

	public fAQxRkfPGErHCkvcDwnufsfdxcK(KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		eVxxBexHOjtqqOLiFQGEtbldcFh = keyCode;
		RCfsEFwOpxyMtsvpZivwrNvBSuI = modifierKey1;
		oRBMwSfgfFIxuTfPcHBtCIhGdNt = modifierKey2;
		EUzOXCQPGfeOpZnmkDNSdDouKKMo = modifierKey3;
	}

	public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
	{
		if (eVxxBexHOjtqqOLiFQGEtbldcFh != KeyboardKeyCode.None)
		{
			eVxxBexHOjtqqOLiFQGEtbldcFh = KeyboardKeyCode.None;
		}
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

	public bool Equals(fAQxRkfPGErHCkvcDwnufsfdxcK other)
	{
		if (eVxxBexHOjtqqOLiFQGEtbldcFh == other.eVxxBexHOjtqqOLiFQGEtbldcFh && RCfsEFwOpxyMtsvpZivwrNvBSuI == other.RCfsEFwOpxyMtsvpZivwrNvBSuI && oRBMwSfgfFIxuTfPcHBtCIhGdNt == other.oRBMwSfgfFIxuTfPcHBtCIhGdNt)
		{
			return EUzOXCQPGfeOpZnmkDNSdDouKKMo == other.EUzOXCQPGfeOpZnmkDNSdDouKKMo;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is fAQxRkfPGErHCkvcDwnufsfdxcK))
		{
			return false;
		}
		return Equals((fAQxRkfPGErHCkvcDwnufsfdxcK)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + eVxxBexHOjtqqOLiFQGEtbldcFh.GetHashCode();
		num = num * 29 + RCfsEFwOpxyMtsvpZivwrNvBSuI.GetHashCode();
		num = num * 29 + oRBMwSfgfFIxuTfPcHBtCIhGdNt.GetHashCode();
		return num * 29 + EUzOXCQPGfeOpZnmkDNSdDouKKMo.GetHashCode();
	}

	public static bool operator ==(fAQxRkfPGErHCkvcDwnufsfdxcK a, fAQxRkfPGErHCkvcDwnufsfdxcK b)
	{
		if (a.eVxxBexHOjtqqOLiFQGEtbldcFh == b.eVxxBexHOjtqqOLiFQGEtbldcFh && a.RCfsEFwOpxyMtsvpZivwrNvBSuI == b.RCfsEFwOpxyMtsvpZivwrNvBSuI && a.oRBMwSfgfFIxuTfPcHBtCIhGdNt == b.oRBMwSfgfFIxuTfPcHBtCIhGdNt)
		{
			return a.EUzOXCQPGfeOpZnmkDNSdDouKKMo == b.EUzOXCQPGfeOpZnmkDNSdDouKKMo;
		}
		return false;
	}

	public static bool operator !=(fAQxRkfPGErHCkvcDwnufsfdxcK a, fAQxRkfPGErHCkvcDwnufsfdxcK b)
	{
		return !(a == b);
	}
}
