using System;
using System.Runtime.CompilerServices;

internal struct lTfFJxTDtehdKOZnvEPBcakaGlrz
{
	private int NRvpdHtnufkhJZnFpqLRevNFwuIC;

	private long YuhDArboWNnGTZotZQPLbrwHltzPA;

	private static readonly bool zYtzgRArwKhQJmfkQFJiJoGErzQcA;

	public static readonly int IxJsCUwZznLRKOOGiFxgKvzcSOJQ;

	static lTfFJxTDtehdKOZnvEPBcakaGlrz()
	{
		zYtzgRArwKhQJmfkQFJiJoGErzQcA = IntPtr.Size == 8;
		IxJsCUwZznLRKOOGiFxgKvzcSOJQ = (zYtzgRArwKhQJmfkQFJiJoGErzQcA ? 8 : 4);
	}

	public static lTfFJxTDtehdKOZnvEPBcakaGlrz CBgazkGkfhWJVVClkjkSpsGOlwbAA(byte[] P_0, int P_1)
	{
		lTfFJxTDtehdKOZnvEPBcakaGlrz result = default(lTfFJxTDtehdKOZnvEPBcakaGlrz);
		if (zYtzgRArwKhQJmfkQFJiJoGErzQcA)
		{
			result.YuhDArboWNnGTZotZQPLbrwHltzPA = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.NRvpdHtnufkhJZnFpqLRevNFwuIC = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int VbpyCxgylekYnNqSyePmsjmKhLMgA(lTfFJxTDtehdKOZnvEPBcakaGlrz P_0)
	{
		if (zYtzgRArwKhQJmfkQFJiJoGErzQcA)
		{
			return (int)P_0.YuhDArboWNnGTZotZQPLbrwHltzPA;
		}
		return P_0.NRvpdHtnufkhJZnFpqLRevNFwuIC;
	}

	[SpecialName]
	public static long VbpyCxgylekYnNqSyePmsjmKhLMgA(lTfFJxTDtehdKOZnvEPBcakaGlrz P_0)
	{
		if (zYtzgRArwKhQJmfkQFJiJoGErzQcA)
		{
			return P_0.YuhDArboWNnGTZotZQPLbrwHltzPA;
		}
		return P_0.NRvpdHtnufkhJZnFpqLRevNFwuIC;
	}

	public string MmSeDKgIBsxXEAGznjSQnCsxxCkqA()
	{
		if (zYtzgRArwKhQJmfkQFJiJoGErzQcA)
		{
			return YuhDArboWNnGTZotZQPLbrwHltzPA.ToString();
		}
		return NRvpdHtnufkhJZnFpqLRevNFwuIC.ToString();
	}
}
