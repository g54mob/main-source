using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct LoOOFopNymweGkhICBgeiHdUEeUL : IEquatable<LoOOFopNymweGkhICBgeiHdUEeUL>
{
	public ModifierKey OMRhQCEiYlNzaSriRcREAoaCzxXd;

	public ModifierKey rKeyPvoMRxPgPuZsprieAWrKjSHd;

	public ModifierKey KodeWlfDCBFOFRAqGTjUYDBmAlyR;

	private ModifierKey NIyczwPmNHNBirmgeBvuEuQiCCMi
	{
		get
		{
			if (P_0 <= 0)
			{
				return OMRhQCEiYlNzaSriRcREAoaCzxXd;
			}
			if (P_0 == 1)
			{
				return rKeyPvoMRxPgPuZsprieAWrKjSHd;
			}
			if (P_0 >= 2)
			{
				return KodeWlfDCBFOFRAqGTjUYDBmAlyR;
			}
			return OMRhQCEiYlNzaSriRcREAoaCzxXd;
		}
		set
		{
			if (num <= 0)
			{
				OMRhQCEiYlNzaSriRcREAoaCzxXd = modifierKey;
			}
			if (num == 1)
			{
				rKeyPvoMRxPgPuZsprieAWrKjSHd = modifierKey;
			}
			if (num >= 2)
			{
				KodeWlfDCBFOFRAqGTjUYDBmAlyR = modifierKey;
			}
		}
	}

	public LoOOFopNymweGkhICBgeiHdUEeUL(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		OMRhQCEiYlNzaSriRcREAoaCzxXd = P_0;
		rKeyPvoMRxPgPuZsprieAWrKjSHd = P_1;
		KodeWlfDCBFOFRAqGTjUYDBmAlyR = P_2;
	}

	public void xgmIVJoYwEUHRDpuZZhuoseisAlp()
	{
		if (OMRhQCEiYlNzaSriRcREAoaCzxXd != ModifierKey.None)
		{
			OMRhQCEiYlNzaSriRcREAoaCzxXd = ModifierKey.None;
		}
		if (rKeyPvoMRxPgPuZsprieAWrKjSHd != ModifierKey.None)
		{
			rKeyPvoMRxPgPuZsprieAWrKjSHd = ModifierKey.None;
		}
		if (KodeWlfDCBFOFRAqGTjUYDBmAlyR != ModifierKey.None)
		{
			KodeWlfDCBFOFRAqGTjUYDBmAlyR = ModifierKey.None;
		}
	}

	public static LoOOFopNymweGkhICBgeiHdUEeUL UaVVPtvWihBrKzlASqiBWrxEWjrT(ModifierKeyFlags P_0)
	{
		LoOOFopNymweGkhICBgeiHdUEeUL result = default(LoOOFopNymweGkhICBgeiHdUEeUL);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.BwivdFuHxmzsHazlVwnPCasmqYsm(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.BwivdFuHxmzsHazlVwnPCasmqYsm(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.BwivdFuHxmzsHazlVwnPCasmqYsm(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.BwivdFuHxmzsHazlVwnPCasmqYsm(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(LoOOFopNymweGkhICBgeiHdUEeUL other)
	{
		if (OMRhQCEiYlNzaSriRcREAoaCzxXd == other.OMRhQCEiYlNzaSriRcREAoaCzxXd && rKeyPvoMRxPgPuZsprieAWrKjSHd == other.rKeyPvoMRxPgPuZsprieAWrKjSHd)
		{
			return KodeWlfDCBFOFRAqGTjUYDBmAlyR == other.KodeWlfDCBFOFRAqGTjUYDBmAlyR;
		}
		return false;
	}

	bool IEquatable<LoOOFopNymweGkhICBgeiHdUEeUL>.Equals(LoOOFopNymweGkhICBgeiHdUEeUL other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool TxLoqeVHuhCFqjqAyFSSzgLRPTZR(object P_0)
	{
		if (P_0 == null || !(P_0 is LoOOFopNymweGkhICBgeiHdUEeUL))
		{
			return false;
		}
		return Equals((LoOOFopNymweGkhICBgeiHdUEeUL)P_0);
	}

	public int fCmiYHhFtDkaYWvrUXbxarTODoYg()
	{
		return ((17 * 29 + OMRhQCEiYlNzaSriRcREAoaCzxXd.GetHashCode()) * 29 + rKeyPvoMRxPgPuZsprieAWrKjSHd.GetHashCode()) * 29 + KodeWlfDCBFOFRAqGTjUYDBmAlyR.GetHashCode();
	}

	[SpecialName]
	public static bool TqtaYzveIFsCoLeDtkLecSMjLEK(LoOOFopNymweGkhICBgeiHdUEeUL P_0, LoOOFopNymweGkhICBgeiHdUEeUL P_1)
	{
		if (P_0.OMRhQCEiYlNzaSriRcREAoaCzxXd == P_1.OMRhQCEiYlNzaSriRcREAoaCzxXd && P_0.rKeyPvoMRxPgPuZsprieAWrKjSHd == P_1.rKeyPvoMRxPgPuZsprieAWrKjSHd)
		{
			return P_0.KodeWlfDCBFOFRAqGTjUYDBmAlyR == P_1.KodeWlfDCBFOFRAqGTjUYDBmAlyR;
		}
		return false;
	}

	[SpecialName]
	public static bool seAYghtNJwnSnFmZSrjtaREKrORt(LoOOFopNymweGkhICBgeiHdUEeUL P_0, LoOOFopNymweGkhICBgeiHdUEeUL P_1)
	{
		return !TqtaYzveIFsCoLeDtkLecSMjLEK(P_0, P_1);
	}
}
