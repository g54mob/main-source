using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct HcjebfGWBEygWckvSivzbOnNcDqbb : IEquatable<HcjebfGWBEygWckvSivzbOnNcDqbb>
{
	private int rjgsllAqZdMllQQecjUMPdgnqNpx;

	public HcjebfGWBEygWckvSivzbOnNcDqbb(bool P_0)
	{
		rjgsllAqZdMllQQecjUMPdgnqNpx = (P_0 ? 1 : 0);
	}

	public bool Equals(HcjebfGWBEygWckvSivzbOnNcDqbb other)
	{
		return rjgsllAqZdMllQQecjUMPdgnqNpx == other.rjgsllAqZdMllQQecjUMPdgnqNpx;
	}

	bool IEquatable<HcjebfGWBEygWckvSivzbOnNcDqbb>.Equals(HcjebfGWBEygWckvSivzbOnNcDqbb other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool pwsdKnyIZkJjGcatfVlpLDYETzKL(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is HcjebfGWBEygWckvSivzbOnNcDqbb)
		{
			return Equals((HcjebfGWBEygWckvSivzbOnNcDqbb)P_0);
		}
		return false;
	}

	public int KPDWoNYlvKbSDbUlWEhEIMXitaHXA()
	{
		return rjgsllAqZdMllQQecjUMPdgnqNpx;
	}

	[SpecialName]
	public static bool byxalCVrRKaoqhIySzhMfvjHheox(HcjebfGWBEygWckvSivzbOnNcDqbb P_0, HcjebfGWBEygWckvSivzbOnNcDqbb P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool JNDbcfKnXsTHTMwQOPhIJJxPaoHi(HcjebfGWBEygWckvSivzbOnNcDqbb P_0, HcjebfGWBEygWckvSivzbOnNcDqbb P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool gMwbwssujBajpGdCYagthOjjGNYHA(HcjebfGWBEygWckvSivzbOnNcDqbb P_0)
	{
		return P_0.rjgsllAqZdMllQQecjUMPdgnqNpx != 0;
	}

	[SpecialName]
	public static HcjebfGWBEygWckvSivzbOnNcDqbb hmSkzjSgWoANjXggEISqnWQrlYCv(bool P_0)
	{
		return new HcjebfGWBEygWckvSivzbOnNcDqbb(P_0);
	}

	public string gSeXpiPOsfkRPHTdwKBWHeVWDELB()
	{
		return $"{rjgsllAqZdMllQQecjUMPdgnqNpx != 0}";
	}
}
