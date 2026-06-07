internal static class SXgteXWEPLyHbxmQNCQiBhYIujrBA
{
	public static string RrPHxkdLfQdsyuEeqnENTilmyeUC(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return string.Empty;
		}
		int num = P_0.LastIndexOf('\\');
		if (num < 0 || num >= P_0.Length - 1)
		{
			return P_0;
		}
		return P_0.Substring(num + 1);
	}

	public static vjLKSDOZfFImbYjjOVLVIVdqJbio HEJruwmPUlmmoiNsPedjwZEKPPtP(uint P_0)
	{
		return P_0 switch
		{
			8u => vjLKSDOZfFImbYjjOVLVIVdqJbio.LostFocus, 
			7u => vjLKSDOZfFImbYjjOVLVIVdqJbio.GainedFocus, 
			_ => vjLKSDOZfFImbYjjOVLVIVdqJbio.None, 
		};
	}
}
