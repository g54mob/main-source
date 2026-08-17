using System;
using System.Text.RegularExpressions;
using Cpp2ILInjected;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Utility;

public static class ChatUtility
{
	private static Regex richRegex;

	private static int maxNameLength;

	public static string SanitizePlayerName(string name)
	{
		//IL_0071: Expected O, but got I
		//IL_0081: Expected O, but got I
		if (richRegex != null)
		{
			bool flag = richRegex.IsMatch(name);
			bool flag2 = !flag;
			string text = name;
			if (!flag2)
			{
				if (richRegex == null)
				{
					goto IL_0167;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v36+B8]");
				object replacement = 0;
				string text2 = richRegex.Replace(name, (string)replacement);
				text = text2;
			}
			char[] separator = new char[4] { '\t', '\r', '\n', '<' };
			if (text != null)
			{
				string[] array = text.Split(separator, StringSplitOptions.None);
				string text3 = string.Concat(array);
				bool flag3 = string.IsNullOrWhiteSpace(text3);
				bool flag4 = !flag3;
				string text4 = text3;
				if (!flag4)
				{
					int num = UnityEngine.Random.Range(0, 9999);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string text5 = $"Player#{arg}";
					text4 = text5;
				}
				if (text4 != null)
				{
					if (text4._stringLength > maxNameLength)
					{
						string text6 = StringUtility.Truncate(text4, maxNameLength, "");
					}
					return text4;
				}
			}
		}
		goto IL_0167;
		IL_0167:
		return (string)(object)new NullReferenceException();
	}

	public static string SanitizeString(string input)
	{
		char[] separator = new char[4] { '\t', '\r', '\n', '<' };
		if (input != null)
		{
			string[] array = input.Split(separator, StringSplitOptions.None);
			return string.Concat(array);
		}
		return (string)(object)new NullReferenceException();
	}

	public static string RemoveRichEmbedding(string text)
	{
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		if (richRegex != null)
		{
			if (!richRegex.IsMatch(text))
			{
				return text;
			}
			if (richRegex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v11+B8]");
				object replacement = 0;
				return richRegex.Replace(text, (string)replacement);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	static ChatUtility()
	{
		Regex regex = new Regex("<[^>]*>");
		richRegex = regex;
		maxNameLength = 12;
	}
}
