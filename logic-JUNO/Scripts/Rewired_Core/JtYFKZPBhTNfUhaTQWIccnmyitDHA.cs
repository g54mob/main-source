using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct JtYFKZPBhTNfUhaTQWIccnmyitDHA : IEquatable<JtYFKZPBhTNfUhaTQWIccnmyitDHA>
{
	public ModifierKey ITLnhbeZiAHQuDkXRitGAbtkVAWO;

	public ModifierKey fmyPeGMdaEiIDJhhbYicQWLapWWIA;

	public ModifierKey SOpykEFkiaGQFjSMIiCSrYCMmWvqA;

	private ModifierKey VpiUgTdRfovSyskWgoKcIhXIKxJR
	{
		get
		{
			if (P_0 <= 0)
			{
				return ITLnhbeZiAHQuDkXRitGAbtkVAWO;
			}
			if (P_0 == 1)
			{
				return fmyPeGMdaEiIDJhhbYicQWLapWWIA;
			}
			if (P_0 >= 2)
			{
				return SOpykEFkiaGQFjSMIiCSrYCMmWvqA;
			}
			return ITLnhbeZiAHQuDkXRitGAbtkVAWO;
		}
		set
		{
			if (num <= 0)
			{
				ITLnhbeZiAHQuDkXRitGAbtkVAWO = modifierKey;
			}
			if (num == 1)
			{
				fmyPeGMdaEiIDJhhbYicQWLapWWIA = modifierKey;
			}
			if (num >= 2)
			{
				SOpykEFkiaGQFjSMIiCSrYCMmWvqA = modifierKey;
			}
		}
	}

	public JtYFKZPBhTNfUhaTQWIccnmyitDHA(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		ITLnhbeZiAHQuDkXRitGAbtkVAWO = P_0;
		fmyPeGMdaEiIDJhhbYicQWLapWWIA = P_1;
		SOpykEFkiaGQFjSMIiCSrYCMmWvqA = P_2;
	}

	public void piRVwAWYepYFvQOaHqwPynlMzcGB()
	{
		if (ITLnhbeZiAHQuDkXRitGAbtkVAWO != ModifierKey.None)
		{
			ITLnhbeZiAHQuDkXRitGAbtkVAWO = ModifierKey.None;
		}
		if (fmyPeGMdaEiIDJhhbYicQWLapWWIA != ModifierKey.None)
		{
			fmyPeGMdaEiIDJhhbYicQWLapWWIA = ModifierKey.None;
		}
		if (SOpykEFkiaGQFjSMIiCSrYCMmWvqA != ModifierKey.None)
		{
			SOpykEFkiaGQFjSMIiCSrYCMmWvqA = ModifierKey.None;
		}
	}

	public static JtYFKZPBhTNfUhaTQWIccnmyitDHA AANRuYPSSUukSiXkYtVRWtokGEcI(ModifierKeyFlags P_0)
	{
		JtYFKZPBhTNfUhaTQWIccnmyitDHA result = default(JtYFKZPBhTNfUhaTQWIccnmyitDHA);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.BJerLqKSPNflTfMXPorNACtEhxzi(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.BJerLqKSPNflTfMXPorNACtEhxzi(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.BJerLqKSPNflTfMXPorNACtEhxzi(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.BJerLqKSPNflTfMXPorNACtEhxzi(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(JtYFKZPBhTNfUhaTQWIccnmyitDHA other)
	{
		if (ITLnhbeZiAHQuDkXRitGAbtkVAWO == other.ITLnhbeZiAHQuDkXRitGAbtkVAWO && fmyPeGMdaEiIDJhhbYicQWLapWWIA == other.fmyPeGMdaEiIDJhhbYicQWLapWWIA)
		{
			return SOpykEFkiaGQFjSMIiCSrYCMmWvqA == other.SOpykEFkiaGQFjSMIiCSrYCMmWvqA;
		}
		return false;
	}

	bool IEquatable<JtYFKZPBhTNfUhaTQWIccnmyitDHA>.Equals(JtYFKZPBhTNfUhaTQWIccnmyitDHA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool PELgeJDdQIrQwksusADCHbGDpwGNB(object P_0)
	{
		if (P_0 == null || !(P_0 is JtYFKZPBhTNfUhaTQWIccnmyitDHA))
		{
			return false;
		}
		return Equals((JtYFKZPBhTNfUhaTQWIccnmyitDHA)P_0);
	}

	public int dVwxkkToZuNbEVxTQRWrqpCkDqLy()
	{
		return ((17 * 29 + ITLnhbeZiAHQuDkXRitGAbtkVAWO.GetHashCode()) * 29 + fmyPeGMdaEiIDJhhbYicQWLapWWIA.GetHashCode()) * 29 + SOpykEFkiaGQFjSMIiCSrYCMmWvqA.GetHashCode();
	}

	[SpecialName]
	public static bool FycKrxDcKpfSEjvOHsmJmwXkcCBjA(JtYFKZPBhTNfUhaTQWIccnmyitDHA P_0, JtYFKZPBhTNfUhaTQWIccnmyitDHA P_1)
	{
		if (P_0.ITLnhbeZiAHQuDkXRitGAbtkVAWO == P_1.ITLnhbeZiAHQuDkXRitGAbtkVAWO && P_0.fmyPeGMdaEiIDJhhbYicQWLapWWIA == P_1.fmyPeGMdaEiIDJhhbYicQWLapWWIA)
		{
			return P_0.SOpykEFkiaGQFjSMIiCSrYCMmWvqA == P_1.SOpykEFkiaGQFjSMIiCSrYCMmWvqA;
		}
		return false;
	}

	[SpecialName]
	public static bool kYGqHAZPjZJMvAZxIoFdcxPkbvEG(JtYFKZPBhTNfUhaTQWIccnmyitDHA P_0, JtYFKZPBhTNfUhaTQWIccnmyitDHA P_1)
	{
		return !FycKrxDcKpfSEjvOHsmJmwXkcCBjA(P_0, P_1);
	}
}
