using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class auNcdVoXGDiflbMrqAIZtkfCQyeKA
{
	public IntPtr sKPeLscCeBCoeCmtbUeiiupsPbmt;

	public auNcdVoXGDiflbMrqAIZtkfCQyeKA(IntPtr P_0)
	{
		sKPeLscCeBCoeCmtbUeiiupsPbmt = P_0;
	}

	public unsafe auNcdVoXGDiflbMrqAIZtkfCQyeKA(void* P_0)
	{
		sKPeLscCeBCoeCmtbUeiiupsPbmt = new IntPtr(P_0);
	}

	[SpecialName]
	public static IntPtr mqnQyqNHmCHuogFBwlNaQnuOPein(auNcdVoXGDiflbMrqAIZtkfCQyeKA P_0)
	{
		return P_0.sKPeLscCeBCoeCmtbUeiiupsPbmt;
	}

	[SpecialName]
	public static auNcdVoXGDiflbMrqAIZtkfCQyeKA fObmMbwAAPLNGrMQFdNgwQDOBEThA(IntPtr P_0)
	{
		return new auNcdVoXGDiflbMrqAIZtkfCQyeKA(P_0);
	}

	[SpecialName]
	public unsafe static void* ZCEITDaBMEPekRoSBXnqdRbUYdjSA(auNcdVoXGDiflbMrqAIZtkfCQyeKA P_0)
	{
		return (void*)P_0.sKPeLscCeBCoeCmtbUeiiupsPbmt;
	}

	[SpecialName]
	public unsafe static auNcdVoXGDiflbMrqAIZtkfCQyeKA YAhOUDuHbWjHPSBUxslQDnqiUeRw(void* P_0)
	{
		return new auNcdVoXGDiflbMrqAIZtkfCQyeKA(P_0);
	}

	public virtual string iYTwAHibwfFMHOWTFEymiLLCGoBs()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", sKPeLscCeBCoeCmtbUeiiupsPbmt);
	}

	public string HgOoaMGKVoJfmFneNkVawFAxjXNl(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", sKPeLscCeBCoeCmtbUeiiupsPbmt.ToString(P_0));
	}

	public virtual int rXUrfkhjhpDcbebYaicOJzFnEsTy()
	{
		return sKPeLscCeBCoeCmtbUeiiupsPbmt.ToInt32();
	}

	public bool BIVrplSHuVcyPbvYsDAxCatNLJjxA(auNcdVoXGDiflbMrqAIZtkfCQyeKA P_0)
	{
		return sKPeLscCeBCoeCmtbUeiiupsPbmt == P_0.sKPeLscCeBCoeCmtbUeiiupsPbmt;
	}

	public virtual bool cuamKPQLNjaSRKKHydQxEJsjLQGSB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(auNcdVoXGDiflbMrqAIZtkfCQyeKA))
		{
			return false;
		}
		return BIVrplSHuVcyPbvYsDAxCatNLJjxA((auNcdVoXGDiflbMrqAIZtkfCQyeKA)P_0);
	}
}
