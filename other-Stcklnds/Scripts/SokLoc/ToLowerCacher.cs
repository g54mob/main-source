using System.Collections.Generic;

public static class ToLowerCacher
{
	public static Dictionary<string, string> cache = new Dictionary<string, string>();

	public static string ToLowerCached(this string s)
	{
		if (!cache.TryGetValue(s, out var value))
		{
			string text = s.ToLower();
			cache[s] = text;
			return text;
		}
		return value;
	}
}
