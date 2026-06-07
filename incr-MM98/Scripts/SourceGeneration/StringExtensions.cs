using System.Globalization;
using System.Text.RegularExpressions;

public static class StringExtensions
{
	public static string ToPascalCase(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		string str = Regex.Replace(input, "[^a-zA-Z0-9]", " ");
		str = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(str).Replace(" ", string.Empty);
		return str.Trim(' ');
	}

	public static string ToSnakeCase(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		return Regex.Replace(Regex.Replace(input, "[^a-zA-Z0-9]", "_"), "([a-z0-9])([A-Z])", "$1_$2").ToLower().Trim('_');
	}

	public static string ToMacroCase(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return string.Empty;
		}
		return Regex.Replace(Regex.Replace(input, "[^a-zA-Z0-9]", "_"), "([a-z0-9])([A-Z])", "$1_$2").ToUpper().Trim('_');
	}
}
