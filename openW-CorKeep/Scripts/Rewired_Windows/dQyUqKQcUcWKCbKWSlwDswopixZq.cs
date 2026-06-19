using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct dQyUqKQcUcWKCbKWSlwDswopixZq
{
	[FieldOffset(0)]
	private uint oNifpeqHxSVBUOHWfYMqaPmVSdmJ;

	[FieldOffset(0)]
	private ulong nrRpryjKfnlMtRIFmJRyJCZeJixb;

	[FieldOffset(0)]
	private IntPtr QlyHRpaqwuYCXzxLQBdYppoyAnSgA;

	private static readonly bool utLtljWWGOsYHjNwWrkDMrECplEJ;

	public static readonly int DMNBhzfbwjLuZFhOelYrDfdBpDwG;

	static dQyUqKQcUcWKCbKWSlwDswopixZq()
	{
		DMNBhzfbwjLuZFhOelYrDfdBpDwG = IntPtr.Size;
		utLtljWWGOsYHjNwWrkDMrECplEJ = DMNBhzfbwjLuZFhOelYrDfdBpDwG == 8;
	}

	public static dQyUqKQcUcWKCbKWSlwDswopixZq wCphdIABgEgQTNqJWvFZdYjdIpugA(byte[] P_0, int P_1)
	{
		dQyUqKQcUcWKCbKWSlwDswopixZq result = default(dQyUqKQcUcWKCbKWSlwDswopixZq);
		if (utLtljWWGOsYHjNwWrkDMrECplEJ)
		{
			result.nrRpryjKfnlMtRIFmJRyJCZeJixb = BitConverter.ToUInt64(P_0, P_1);
			result.QlyHRpaqwuYCXzxLQBdYppoyAnSgA = new IntPtr((long)result.nrRpryjKfnlMtRIFmJRyJCZeJixb);
		}
		else
		{
			result.oNifpeqHxSVBUOHWfYMqaPmVSdmJ = BitConverter.ToUInt32(P_0, P_1);
			result.QlyHRpaqwuYCXzxLQBdYppoyAnSgA = new IntPtr((int)result.oNifpeqHxSVBUOHWfYMqaPmVSdmJ);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr ZkcRTapdZqeyFcfqWRzQgiLbnxiaA(dQyUqKQcUcWKCbKWSlwDswopixZq P_0)
	{
		return P_0.QlyHRpaqwuYCXzxLQBdYppoyAnSgA;
	}

	[SpecialName]
	public static dQyUqKQcUcWKCbKWSlwDswopixZq muDMhOmDvZcQAfovGuhSEPIBNxdKA(IntPtr P_0)
	{
		dQyUqKQcUcWKCbKWSlwDswopixZq result = new dQyUqKQcUcWKCbKWSlwDswopixZq
		{
			QlyHRpaqwuYCXzxLQBdYppoyAnSgA = P_0
		};
		if (utLtljWWGOsYHjNwWrkDMrECplEJ)
		{
			result.nrRpryjKfnlMtRIFmJRyJCZeJixb = (ulong)P_0.ToInt64();
		}
		else
		{
			result.oNifpeqHxSVBUOHWfYMqaPmVSdmJ = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string quxgkSklQhPHeUwvYRyWhNXXUmEDA()
	{
		if (utLtljWWGOsYHjNwWrkDMrECplEJ)
		{
			return nrRpryjKfnlMtRIFmJRyJCZeJixb.ToString();
		}
		return oNifpeqHxSVBUOHWfYMqaPmVSdmJ.ToString();
	}

	public int aGmWkUfUMiqAoYAmBUOdvtsgxqOI()
	{
		if (utLtljWWGOsYHjNwWrkDMrECplEJ)
		{
			return (int)nrRpryjKfnlMtRIFmJRyJCZeJixb;
		}
		return (int)oNifpeqHxSVBUOHWfYMqaPmVSdmJ;
	}
}
