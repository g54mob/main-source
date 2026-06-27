using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct OyupQaMYRgpbewATwEdBKrofApgMA
{
	[FieldOffset(0)]
	private uint VUyZwSsFQIqYeHsDDTlabusPOOLm;

	[FieldOffset(0)]
	private ulong CqZVVIzvFfWVJAwJCAOsMGQuRWNg;

	[FieldOffset(0)]
	private IntPtr jTmcpRjkhsZlzAuWqmoMaicAmdtsB;

	private static readonly bool PfVVCXGcVUJzryvduajFNUEYtGdm;

	public static readonly int gwNfiHhwpjqGhQTcSgExWwtZloXG;

	static OyupQaMYRgpbewATwEdBKrofApgMA()
	{
		gwNfiHhwpjqGhQTcSgExWwtZloXG = IntPtr.Size;
		PfVVCXGcVUJzryvduajFNUEYtGdm = gwNfiHhwpjqGhQTcSgExWwtZloXG == 8;
	}

	public static OyupQaMYRgpbewATwEdBKrofApgMA BKdFFeNNrUDfbtBIanUHRHljbpXDA(byte[] P_0, int P_1)
	{
		OyupQaMYRgpbewATwEdBKrofApgMA result = default(OyupQaMYRgpbewATwEdBKrofApgMA);
		if (PfVVCXGcVUJzryvduajFNUEYtGdm)
		{
			result.CqZVVIzvFfWVJAwJCAOsMGQuRWNg = BitConverter.ToUInt64(P_0, P_1);
			result.jTmcpRjkhsZlzAuWqmoMaicAmdtsB = new IntPtr((long)result.CqZVVIzvFfWVJAwJCAOsMGQuRWNg);
		}
		else
		{
			result.VUyZwSsFQIqYeHsDDTlabusPOOLm = BitConverter.ToUInt32(P_0, P_1);
			result.jTmcpRjkhsZlzAuWqmoMaicAmdtsB = new IntPtr((int)result.VUyZwSsFQIqYeHsDDTlabusPOOLm);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr keuVtMlUSeULteexuLaYlQNpVhPS(OyupQaMYRgpbewATwEdBKrofApgMA P_0)
	{
		return P_0.jTmcpRjkhsZlzAuWqmoMaicAmdtsB;
	}

	[SpecialName]
	public static OyupQaMYRgpbewATwEdBKrofApgMA TtPyHegXoNSjezueuvsQIWYTljSQ(IntPtr P_0)
	{
		OyupQaMYRgpbewATwEdBKrofApgMA result = new OyupQaMYRgpbewATwEdBKrofApgMA
		{
			jTmcpRjkhsZlzAuWqmoMaicAmdtsB = P_0
		};
		if (PfVVCXGcVUJzryvduajFNUEYtGdm)
		{
			result.CqZVVIzvFfWVJAwJCAOsMGQuRWNg = (ulong)P_0.ToInt64();
		}
		else
		{
			result.VUyZwSsFQIqYeHsDDTlabusPOOLm = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string HtlEMovGJjEsWexmoWzYBCDPEotsA()
	{
		if (PfVVCXGcVUJzryvduajFNUEYtGdm)
		{
			return CqZVVIzvFfWVJAwJCAOsMGQuRWNg.ToString();
		}
		return VUyZwSsFQIqYeHsDDTlabusPOOLm.ToString();
	}

	public int BcgcvavcJyVTOLDzvcBpomyaAhlN()
	{
		if (PfVVCXGcVUJzryvduajFNUEYtGdm)
		{
			return (int)CqZVVIzvFfWVJAwJCAOsMGQuRWNg;
		}
		return (int)VUyZwSsFQIqYeHsDDTlabusPOOLm;
	}
}
