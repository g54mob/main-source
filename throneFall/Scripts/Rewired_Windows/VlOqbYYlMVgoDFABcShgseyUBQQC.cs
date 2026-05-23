using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct VlOqbYYlMVgoDFABcShgseyUBQQC
{
	[FieldOffset(0)]
	private int PHKAXLLVImrXpGCCniJsfrBpvUcy;

	[FieldOffset(0)]
	private long GXjxCDLatunKjyNTHkdttLolAhTj;

	[FieldOffset(0)]
	private IntPtr rgmQvbuhnudsNRaGSfnSLaqUsszA;

	private static readonly bool aPuAYampxOAQCPFChiXyZLlNtJBN;

	public static readonly int FFblJLGQUflXbDfeuFvdblQiUKtN;

	static VlOqbYYlMVgoDFABcShgseyUBQQC()
	{
		FFblJLGQUflXbDfeuFvdblQiUKtN = IntPtr.Size;
		aPuAYampxOAQCPFChiXyZLlNtJBN = FFblJLGQUflXbDfeuFvdblQiUKtN == 8;
	}

	public static VlOqbYYlMVgoDFABcShgseyUBQQC uawQiqxErXaNEUEwUkuCCGHMgrsC(byte[] P_0, int P_1)
	{
		VlOqbYYlMVgoDFABcShgseyUBQQC result = default(VlOqbYYlMVgoDFABcShgseyUBQQC);
		if (aPuAYampxOAQCPFChiXyZLlNtJBN)
		{
			result.GXjxCDLatunKjyNTHkdttLolAhTj = BitConverter.ToInt64(P_0, P_1);
			result.rgmQvbuhnudsNRaGSfnSLaqUsszA = new IntPtr(result.GXjxCDLatunKjyNTHkdttLolAhTj);
		}
		else
		{
			result.PHKAXLLVImrXpGCCniJsfrBpvUcy = BitConverter.ToInt32(P_0, P_1);
			result.rgmQvbuhnudsNRaGSfnSLaqUsszA = new IntPtr(result.PHKAXLLVImrXpGCCniJsfrBpvUcy);
		}
		return result;
	}

	[SpecialName]
	public static VlOqbYYlMVgoDFABcShgseyUBQQC jLPbiFivmKbvXOxvwPAqEFEvGgWZ(IntPtr P_0)
	{
		VlOqbYYlMVgoDFABcShgseyUBQQC result = new VlOqbYYlMVgoDFABcShgseyUBQQC
		{
			rgmQvbuhnudsNRaGSfnSLaqUsszA = P_0
		};
		if (aPuAYampxOAQCPFChiXyZLlNtJBN)
		{
			result.GXjxCDLatunKjyNTHkdttLolAhTj = P_0.ToInt64();
		}
		else
		{
			result.PHKAXLLVImrXpGCCniJsfrBpvUcy = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr bketUuzRqFUGrUwyPHTMBUWsXHHl(VlOqbYYlMVgoDFABcShgseyUBQQC P_0)
	{
		return P_0.rgmQvbuhnudsNRaGSfnSLaqUsszA;
	}

	public string FONGvnxKWcfDezfRJPuKpZkRnHQF()
	{
		if (aPuAYampxOAQCPFChiXyZLlNtJBN)
		{
			return GXjxCDLatunKjyNTHkdttLolAhTj.ToString();
		}
		return PHKAXLLVImrXpGCCniJsfrBpvUcy.ToString();
	}
}
