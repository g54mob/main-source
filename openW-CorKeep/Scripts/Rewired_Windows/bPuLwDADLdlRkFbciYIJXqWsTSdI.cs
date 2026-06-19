using System;
using System.Runtime.CompilerServices;

internal struct bPuLwDADLdlRkFbciYIJXqWsTSdI
{
	private int EQGwugoqRqqnwjplGrPTimtGWCnt;

	private long DojbVzorgvaXRRNfCbwmaknOAOAp;

	private static readonly bool evyCAauFbbxMxBnkGQOaKgupQjBu;

	public static readonly int eNNPymmdawHWrwIzajUVJejBAZWM;

	static bPuLwDADLdlRkFbciYIJXqWsTSdI()
	{
		evyCAauFbbxMxBnkGQOaKgupQjBu = IntPtr.Size == 8;
		eNNPymmdawHWrwIzajUVJejBAZWM = (evyCAauFbbxMxBnkGQOaKgupQjBu ? 8 : 4);
	}

	public static bPuLwDADLdlRkFbciYIJXqWsTSdI SuwcmmBmiXZeJWTbUZhcDVeHjzLCA(byte[] P_0, int P_1)
	{
		bPuLwDADLdlRkFbciYIJXqWsTSdI result = default(bPuLwDADLdlRkFbciYIJXqWsTSdI);
		if (evyCAauFbbxMxBnkGQOaKgupQjBu)
		{
			result.DojbVzorgvaXRRNfCbwmaknOAOAp = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.EQGwugoqRqqnwjplGrPTimtGWCnt = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int JiDzBRvYPZrzTWVlStCHDwUzRqAQ(bPuLwDADLdlRkFbciYIJXqWsTSdI P_0)
	{
		if (evyCAauFbbxMxBnkGQOaKgupQjBu)
		{
			return (int)P_0.DojbVzorgvaXRRNfCbwmaknOAOAp;
		}
		return P_0.EQGwugoqRqqnwjplGrPTimtGWCnt;
	}

	[SpecialName]
	public static long JiDzBRvYPZrzTWVlStCHDwUzRqAQ(bPuLwDADLdlRkFbciYIJXqWsTSdI P_0)
	{
		if (evyCAauFbbxMxBnkGQOaKgupQjBu)
		{
			return P_0.DojbVzorgvaXRRNfCbwmaknOAOAp;
		}
		return P_0.EQGwugoqRqqnwjplGrPTimtGWCnt;
	}

	public string FiMkRmXerHyuqRPhdzeBcltMofKn()
	{
		if (evyCAauFbbxMxBnkGQOaKgupQjBu)
		{
			return DojbVzorgvaXRRNfCbwmaknOAOAp.ToString();
		}
		return EQGwugoqRqqnwjplGrPTimtGWCnt.ToString();
	}
}
