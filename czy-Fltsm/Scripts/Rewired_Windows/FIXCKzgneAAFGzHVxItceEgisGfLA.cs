using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct FIXCKzgneAAFGzHVxItceEgisGfLA
{
	[FieldOffset(0)]
	private int HxDevLskRjzCNQBJimwwBXRTCBPv;

	[FieldOffset(0)]
	private long MJkyZLuniluEDikEOjHfkBoHQXyTA;

	[FieldOffset(0)]
	private IntPtr bDzDyhdJindSGeVpEFQhbdcMApHaB;

	private static readonly bool iebgsuLqmJyrgPrLsakyxGzlnIcp;

	public static readonly int NmyrfXxjLuUrZHExlMArZEGMcHGQ;

	static FIXCKzgneAAFGzHVxItceEgisGfLA()
	{
		NmyrfXxjLuUrZHExlMArZEGMcHGQ = IntPtr.Size;
		iebgsuLqmJyrgPrLsakyxGzlnIcp = NmyrfXxjLuUrZHExlMArZEGMcHGQ == 8;
	}

	public static FIXCKzgneAAFGzHVxItceEgisGfLA qWnCaqbUFOCBswIFRlDCkgSoGxRfb(byte[] P_0, int P_1)
	{
		FIXCKzgneAAFGzHVxItceEgisGfLA result = default(FIXCKzgneAAFGzHVxItceEgisGfLA);
		if (iebgsuLqmJyrgPrLsakyxGzlnIcp)
		{
			result.MJkyZLuniluEDikEOjHfkBoHQXyTA = BitConverter.ToInt64(P_0, P_1);
			result.bDzDyhdJindSGeVpEFQhbdcMApHaB = new IntPtr(result.MJkyZLuniluEDikEOjHfkBoHQXyTA);
		}
		else
		{
			result.HxDevLskRjzCNQBJimwwBXRTCBPv = BitConverter.ToInt32(P_0, P_1);
			result.bDzDyhdJindSGeVpEFQhbdcMApHaB = new IntPtr(result.HxDevLskRjzCNQBJimwwBXRTCBPv);
		}
		return result;
	}

	[SpecialName]
	public static FIXCKzgneAAFGzHVxItceEgisGfLA buSKCRRJdTDIzKWmjyxakASJyjbr(IntPtr P_0)
	{
		FIXCKzgneAAFGzHVxItceEgisGfLA result = new FIXCKzgneAAFGzHVxItceEgisGfLA
		{
			bDzDyhdJindSGeVpEFQhbdcMApHaB = P_0
		};
		if (iebgsuLqmJyrgPrLsakyxGzlnIcp)
		{
			result.MJkyZLuniluEDikEOjHfkBoHQXyTA = P_0.ToInt64();
		}
		else
		{
			result.HxDevLskRjzCNQBJimwwBXRTCBPv = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr jRliteUpMIrOZOxMWygWxCZQSgiE(FIXCKzgneAAFGzHVxItceEgisGfLA P_0)
	{
		return P_0.bDzDyhdJindSGeVpEFQhbdcMApHaB;
	}

	public string XASuoxSoFzVWCpdUGQwGPdslrkvM()
	{
		if (iebgsuLqmJyrgPrLsakyxGzlnIcp)
		{
			return MJkyZLuniluEDikEOjHfkBoHQXyTA.ToString();
		}
		return HxDevLskRjzCNQBJimwwBXRTCBPv.ToString();
	}
}
