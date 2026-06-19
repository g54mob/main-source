public static class TextUtil
{
	public static string GetHiddenString(string inputString)
	{
		string text = "";
		for (int i = 0; i < inputString.Length; i++)
		{
			text = ((inputString[i] != ' ') ? (text + "?") : (text + " "));
		}
		return text;
	}
}
