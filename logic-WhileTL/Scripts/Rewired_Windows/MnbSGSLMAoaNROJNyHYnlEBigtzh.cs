using System;
using System.Runtime.CompilerServices;

internal struct MnbSGSLMAoaNROJNyHYnlEBigtzh
{
	private int NlXuhCzSrESNTpbvQLiStOcokNHV;

	private long WrvIZJezEFJlCehaAERBCuRnzOjd;

	private static readonly bool vEcTZgibGOhMRTarrIojYoSggTYM;

	public static readonly int FfDDSSPkoVyXSlRGlShrtpjBTkxH;

	static MnbSGSLMAoaNROJNyHYnlEBigtzh()
	{
		vEcTZgibGOhMRTarrIojYoSggTYM = IntPtr.Size == 8;
		FfDDSSPkoVyXSlRGlShrtpjBTkxH = (vEcTZgibGOhMRTarrIojYoSggTYM ? 8 : 4);
	}

	public static MnbSGSLMAoaNROJNyHYnlEBigtzh pgVkRSYnyhTBzyKtKQklgjDSiBYd(byte[] P_0, int P_1)
	{
		MnbSGSLMAoaNROJNyHYnlEBigtzh result = default(MnbSGSLMAoaNROJNyHYnlEBigtzh);
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			result.WrvIZJezEFJlCehaAERBCuRnzOjd = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.NlXuhCzSrESNTpbvQLiStOcokNHV = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int hWHeOZGaMchoUxcjVNFKgCLOCcPd(MnbSGSLMAoaNROJNyHYnlEBigtzh P_0)
	{
		if (vEcTZgibGOhMRTarrIojYoSggTYM)
		{
			return (int)P_0.WrvIZJezEFJlCehaAERBCuRnzOjd;
		}
		return P_0.NlXuhCzSrESNTpbvQLiStOcokNHV;
	}

	[SpecialName]
	public static long hWHeOZGaMchoUxcjVNFKgCLOCcPd(MnbSGSLMAoaNROJNyHYnlEBigtzh P_0)
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
