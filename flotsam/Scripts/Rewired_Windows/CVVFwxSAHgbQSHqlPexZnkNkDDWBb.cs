using System;
using System.Runtime.CompilerServices;

internal struct CVVFwxSAHgbQSHqlPexZnkNkDDWBb
{
	private uint DMrPTyDBRPAyIFqRYKGwlhZxJpoZ;

	private ulong wwltavwmDgUOkhccNefofVjcGXJHA;

	private static readonly bool uyzDjkkRtyPjZTErjPDQCemHspBV;

	public static readonly int MKhzERlmPpwcFlpGiKLwNbUqBSpv;

	static CVVFwxSAHgbQSHqlPexZnkNkDDWBb()
	{
		uyzDjkkRtyPjZTErjPDQCemHspBV = IntPtr.Size == 8;
		MKhzERlmPpwcFlpGiKLwNbUqBSpv = (uyzDjkkRtyPjZTErjPDQCemHspBV ? 8 : 4);
	}

	public static CVVFwxSAHgbQSHqlPexZnkNkDDWBb HDgHzyxhDknpziGGMHMNuzQlfxhG(byte[] P_0, int P_1)
	{
		CVVFwxSAHgbQSHqlPexZnkNkDDWBb result = default(CVVFwxSAHgbQSHqlPexZnkNkDDWBb);
		if (uyzDjkkRtyPjZTErjPDQCemHspBV)
		{
			result.wwltavwmDgUOkhccNefofVjcGXJHA = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.DMrPTyDBRPAyIFqRYKGwlhZxJpoZ = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint vegaxTCNhfnHlUMFqRGVzbBzroyl(CVVFwxSAHgbQSHqlPexZnkNkDDWBb P_0)
	{
		if (uyzDjkkRtyPjZTErjPDQCemHspBV)
		{
			return (uint)P_0.wwltavwmDgUOkhccNefofVjcGXJHA;
		}
		return P_0.DMrPTyDBRPAyIFqRYKGwlhZxJpoZ;
	}

	[SpecialName]
	public static ulong vegaxTCNhfnHlUMFqRGVzbBzroyl(CVVFwxSAHgbQSHqlPexZnkNkDDWBb P_0)
	{
		if (uyzDjkkRtyPjZTErjPDQCemHspBV)
		{
			return P_0.wwltavwmDgUOkhccNefofVjcGXJHA;
		}
		return P_0.DMrPTyDBRPAyIFqRYKGwlhZxJpoZ;
	}

	public string lQDnSjqhWNQOyLhoSHlQflwAmotO()
	{
		if (uyzDjkkRtyPjZTErjPDQCemHspBV)
		{
			return wwltavwmDgUOkhccNefofVjcGXJHA.ToString();
		}
		return DMrPTyDBRPAyIFqRYKGwlhZxJpoZ.ToString();
	}
}
