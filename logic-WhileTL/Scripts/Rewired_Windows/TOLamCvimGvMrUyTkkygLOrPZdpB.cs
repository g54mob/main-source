using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct TOLamCvimGvMrUyTkkygLOrPZdpB
{
	[FieldOffset(0)]
	private int NlXuhCzSrESNTpbvQLiStOcokNHV;

	[FieldOffset(0)]
	private long WrvIZJezEFJlCehaAERBCuRnzOjd;

	[FieldOffset(0)]
	private IntPtr CcpjjzVGEAKmDUJafjyIEhQJFgtJ;

	private static readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	public static readonly int FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	static TOLamCvimGvMrUyTkkygLOrPZdpB()
	{
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = IntPtr.Size;
		vEcTZgibGOhMRTarrIojYoSggTYM = FfDDSSPkoVyXSlRGlShrtpjBTkxH == 8;
	}

	public static TOLamCvimGvMrUyTkkygLOrPZdpB pgVkRSYnyhTBzyKtKQklgjDSiBYd(byte[] P_0, int P_1)
	{
		TOLamCvimGvMrUyTkkygLOrPZdpB result = default(TOLamCvimGvMrUyTkkygLOrPZdpB);
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = BitConverter.ToInt64(P_0, P_1);
			result.CcpjjzVGEAKmDUJafjyIEhQJFgtJ = new IntPtr(result.WrvIZJezEFJlCehaAERBCuRnzOjd);
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = BitConverter.ToInt32(P_0, P_1);
			result.CcpjjzVGEAKmDUJafjyIEhQJFgtJ = new IntPtr(result.NlXuhCzSrESNTpbvQLiStOcokNHV);
		}
		return result;
	}

	[SpecialName]
	public static TOLamCvimGvMrUyTkkygLOrPZdpB hWHeOZGaMchoUxcjVNFKgCLOCcPd(IntPtr P_0)
	{
		TOLamCvimGvMrUyTkkygLOrPZdpB result = new TOLamCvimGvMrUyTkkygLOrPZdpB
		{
			CcpjjzVGEAKmDUJafjyIEhQJFgtJ = P_0
		};
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = P_0.ToInt64();
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr hWHeOZGaMchoUxcjVNFKgCLOCcPd(TOLamCvimGvMrUyTkkygLOrPZdpB P_0)
	{
		return P_0.CcpjjzVGEAKmDUJafjyIEhQJFgtJ;
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return WrvIZJezEFJlCehaAERBCuRnzOjd.ToString();
		}
		return NlXuhCzSrESNTpbvQLiStOcokNHV.ToString();
	}
}
