using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct cQgVBZlYElNaPNVdQLmdvIVQeESs
{
	[FieldOffset(0)]
	private uint NlXuhCzSrESNTpbvQLiStOcokNHV;

	[FieldOffset(0)]
	private ulong WrvIZJezEFJlCehaAERBCuRnzOjd;

	[FieldOffset(0)]
	private IntPtr CcpjjzVGEAKmDUJafjyIEhQJFgtJ;

	private static readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	public static readonly int FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	static cQgVBZlYElNaPNVdQLmdvIVQeESs()
	{
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = IntPtr.Size;
		vEcTZgibGOhMRTarrIojYoSggTYM = FfDDSSPkoVyXSlRGlShrtpjBTkxH == 8;
	}

	public static cQgVBZlYElNaPNVdQLmdvIVQeESs pgVkRSYnyhTBzyKtKQklgjDSiBYd(byte[] P_0, int P_1)
	{
		cQgVBZlYElNaPNVdQLmdvIVQeESs result = default(cQgVBZlYElNaPNVdQLmdvIVQeESs);
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = BitConverter.ToUInt64(P_0, P_1);
			result.CcpjjzVGEAKmDUJafjyIEhQJFgtJ = new IntPtr((long)result.WrvIZJezEFJlCehaAERBCuRnzOjd);
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = BitConverter.ToUInt32(P_0, P_1);
			result.CcpjjzVGEAKmDUJafjyIEhQJFgtJ = new IntPtr((int)result.NlXuhCzSrESNTpbvQLiStOcokNHV);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr hWHeOZGaMchoUxcjVNFKgCLOCcPd(cQgVBZlYElNaPNVdQLmdvIVQeESs P_0)
	{
		return P_0.CcpjjzVGEAKmDUJafjyIEhQJFgtJ;
	}

	[SpecialName]
	public static cQgVBZlYElNaPNVdQLmdvIVQeESs hWHeOZGaMchoUxcjVNFKgCLOCcPd(IntPtr P_0)
	{
		cQgVBZlYElNaPNVdQLmdvIVQeESs result = new cQgVBZlYElNaPNVdQLmdvIVQeESs
		{
			CcpjjzVGEAKmDUJafjyIEhQJFgtJ = P_0
		};
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = (ulong)P_0.ToInt64();
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return WrvIZJezEFJlCehaAERBCuRnzOjd.ToString();
		}
		return NlXuhCzSrESNTpbvQLiStOcokNHV.ToString();
	}

	public int ulGBzXQILAgqdeKqqhcBlKMsJSyVA()
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return (int)WrvIZJezEFJlCehaAERBCuRnzOjd;
		}
		return (int)NlXuhCzSrESNTpbvQLiStOcokNHV;
	}
}
