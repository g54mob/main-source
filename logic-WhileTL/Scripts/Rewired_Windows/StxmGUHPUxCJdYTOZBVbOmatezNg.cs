using System;
using System.Runtime.CompilerServices;

internal struct StxmGUHPUxCJdYTOZBVbOmatezNg
{
	private uint NlXuhCzSrESNTpbvQLiStOcokNHV;

	private ulong WrvIZJezEFJlCehaAERBCuRnzOjd;

	private static readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	public static readonly int FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	static StxmGUHPUxCJdYTOZBVbOmatezNg()
	{
		vEcTZgibGOhMRTarrIojYoSggTYM = IntPtr.Size == 8;
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = (vEcTZgibGOhMRTarrIojYoSggTYM ? 8 : 4);
	}

	public static StxmGUHPUxCJdYTOZBVbOmatezNg pgVkRSYnyhTBzyKtKQklgjDSiBYd(byte[] P_0, int P_1)
	{
		StxmGUHPUxCJdYTOZBVbOmatezNg result = default(StxmGUHPUxCJdYTOZBVbOmatezNg);
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint hWHeOZGaMchoUxcjVNFKgCLOCcPd(StxmGUHPUxCJdYTOZBVbOmatezNg P_0)
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return (uint)P_0.WrvIZJezEFJlCehaAERBCuRnzOjd;
		}
		return P_0.NlXuhCzSrESNTpbvQLiStOcokNHV;
	}

	[SpecialName]
	public static ulong hWHeOZGaMchoUxcjVNFKgCLOCcPd(StxmGUHPUxCJdYTOZBVbOmatezNg P_0)
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return P_0.WrvIZJezEFJlCehaAERBCuRnzOjd;
		}
		return P_0.NlXuhCzSrESNTpbvQLiStOcokNHV;
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
