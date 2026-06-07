internal static class mnqxbYGwQINVXmoGTDtfkBLLYwkeA
{
	public static string nmVOPxzAiHzjSpdAwWgIrCdpKjDu(string P_0)
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

	public static HYPfPEIKeGhwXFMlYWmGenybEyxHA zcXplpeoBeEwKdGiBeYoYEXDYMus(uint P_0)
	{
		return P_0 switch
		{
			8u => HYPfPEIKeGhwXFMlYWmGenybEyxHA.LostFocus, 
			7u => HYPfPEIKeGhwXFMlYWmGenybEyxHA.GainedFocus, 
			_ => HYPfPEIKeGhwXFMlYWmGenybEyxHA.None, 
		};
	}
}
