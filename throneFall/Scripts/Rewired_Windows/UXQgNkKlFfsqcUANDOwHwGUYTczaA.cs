using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct UXQgNkKlFfsqcUANDOwHwGUYTczaA
{
	[FieldOffset(0)]
	private uint NEmWEaVQGDrmLrRdqCCoQKnyNVMD;

	[FieldOffset(0)]
	private ulong UAvKaMUVYsTFVePslTRsbklPYqSE;

	[FieldOffset(0)]
	private IntPtr daQtsVXCrvEcvEOWPNhMtBYPpyqGA;

	private static readonly bool BHbSpVvfRXCKbINdFQrZkRifTumN;

	public static readonly int sstadPYhCcjNxwsDhfZnzBBaiuAe;

	static UXQgNkKlFfsqcUANDOwHwGUYTczaA()
	{
		sstadPYhCcjNxwsDhfZnzBBaiuAe = IntPtr.Size;
		BHbSpVvfRXCKbINdFQrZkRifTumN = sstadPYhCcjNxwsDhfZnzBBaiuAe == 8;
	}

	public static UXQgNkKlFfsqcUANDOwHwGUYTczaA RLZwCcahxXJslXtGHATRenBOBeCU(byte[] P_0, int P_1)
	{
		UXQgNkKlFfsqcUANDOwHwGUYTczaA result = default(UXQgNkKlFfsqcUANDOwHwGUYTczaA);
		if (BHbSpVvfRXCKbINdFQrZkRifTumN)
		{
			result.UAvKaMUVYsTFVePslTRsbklPYqSE = BitConverter.ToUInt64(P_0, P_1);
			result.daQtsVXCrvEcvEOWPNhMtBYPpyqGA = new IntPtr((long)result.UAvKaMUVYsTFVePslTRsbklPYqSE);
		}
		else
		{
			result.NEmWEaVQGDrmLrRdqCCoQKnyNVMD = BitConverter.ToUInt32(P_0, P_1);
			result.daQtsVXCrvEcvEOWPNhMtBYPpyqGA = new IntPtr((int)result.NEmWEaVQGDrmLrRdqCCoQKnyNVMD);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr knMDqWEJKzaOjaUpFKlKHWjCCoUpA(UXQgNkKlFfsqcUANDOwHwGUYTczaA P_0)
	{
		return P_0.daQtsVXCrvEcvEOWPNhMtBYPpyqGA;
	}

	[SpecialName]
	public static UXQgNkKlFfsqcUANDOwHwGUYTczaA NDfIYuJQiOOcwVHgPHfSbtkgcyLCA(IntPtr P_0)
	{
		UXQgNkKlFfsqcUANDOwHwGUYTczaA result = new UXQgNkKlFfsqcUANDOwHwGUYTczaA
		{
			daQtsVXCrvEcvEOWPNhMtBYPpyqGA = P_0
		};
		if (BHbSpVvfRXCKbINdFQrZkRifTumN)
		{
			result.UAvKaMUVYsTFVePslTRsbklPYqSE = (ulong)P_0.ToInt64();
		}
		else
		{
			result.NEmWEaVQGDrmLrRdqCCoQKnyNVMD = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string NABvFeErNazvAXGuNymMrsbsVhox()
	{
		if (BHbSpVvfRXCKbINdFQrZkRifTumN)
		{
			return UAvKaMUVYsTFVePslTRsbklPYqSE.ToString();
		}
		return NEmWEaVQGDrmLrRdqCCoQKnyNVMD.ToString();
	}

	public int LKKrPsCRVfSvMlhpEIebFbSZuTeh()
	{
		if (BHbSpVvfRXCKbINdFQrZkRifTumN)
		{
			return (int)UAvKaMUVYsTFVePslTRsbklPYqSE;
		}
		return (int)NEmWEaVQGDrmLrRdqCCoQKnyNVMD;
	}
}
