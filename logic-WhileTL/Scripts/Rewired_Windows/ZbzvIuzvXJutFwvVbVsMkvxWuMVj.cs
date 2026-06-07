using System;
using System.Runtime.CompilerServices;

internal struct ZbzvIuzvXJutFwvVbVsMkvxWuMVj
{
	private uint NlXuhCzSrESNTpbvQLiStOcokNHV;

	private ulong WrvIZJezEFJlCehaAERBCuRnzOjd;

	private static readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	public static readonly int FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	static ZbzvIuzvXJutFwvVbVsMkvxWuMVj()
	{
		vEcTZgibGOhMRTarrIojYoSggTYM = IntPtr.Size == 8;
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = (vEcTZgibGOhMRTarrIojYoSggTYM ? 8 : 4);
	}

	public static ZbzvIuzvXJutFwvVbVsMkvxWuMVj pgVkRSYnyhTBzyKtKQklgjDSiBYd(byte[] P_0, int P_1)
	{
		ZbzvIuzvXJutFwvVbVsMkvxWuMVj result = default(ZbzvIuzvXJutFwvVbVsMkvxWuMVj);
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
	public static uint hWHeOZGaMchoUxcjVNFKgCLOCcPd(ZbzvIuzvXJutFwvVbVsMkvxWuMVj P_0)
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return (uint)P_0.WrvIZJezEFJlCehaAERBCuRnzOjd;
		}
		return P_0.NlXuhCzSrESNTpbvQLiStOcokNHV;
	}

	[SpecialName]
	public static ulong hWHeOZGaMchoUxcjVNFKgCLOCcPd(ZbzvIuzvXJutFwvVbVsMkvxWuMVj P_0)
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
