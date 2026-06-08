using System.Linq;
using UnityEngine;

public static class StringUtility
{
	public static string Reverse(string input)
	{
		string text = string.Empty;
		for (int num = input.Length - 1; num >= 0; num--)
		{
			text += input[num];
		}
		return text;
	}

	public static string FirstCharToUpper(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return input;
		}
		return Enumerable.First(input).ToString().ToUpper() + input.Substring(1);
	}

	public static string Colored(string input, Color color)
	{
		return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + input + "</color>";
	}
}
