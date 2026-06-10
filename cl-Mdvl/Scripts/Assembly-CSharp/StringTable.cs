using System.Collections.Generic;

public static class StringTable
{
	private static Dictionary<int, string> strings = new Dictionary<int, string>();

	public static string Get(string text)
	{
		if (strings.TryGetValue(text.GetHashCode(), out var value))
		{
			return value;
		}
		strings.Add(text.GetHashCode(), text);
		return text;
	}
}
