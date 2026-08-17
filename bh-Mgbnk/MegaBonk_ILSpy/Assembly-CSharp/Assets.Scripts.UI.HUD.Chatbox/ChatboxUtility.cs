using System;
using System.Text.RegularExpressions;
using Cpp2ILInjected;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI.HUD.Chatbox;

public class ChatboxUtility
{
	private static Regex rich;

	private static int maxNameLength;

	private static string[] censoredWords;

	public static string ColorPlayerName(ulong steamId)
	{
		ulong num = default(ulong);
		return num.ToString();
	}

	public static string SanitizePlayerName(string name)
	{
		//IL_0070: Expected O, but got I
		//IL_0080: Expected O, but got I
		if (rich != null)
		{
			bool flag = rich.IsMatch(name);
			bool flag2 = !flag;
			string text = name;
			if (!flag2)
			{
				if (rich == null)
				{
					goto IL_010f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v29+B8]");
				object replacement = 0;
				string text2 = rich.Replace(name, (string)replacement);
				text = text2;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				int num = UnityEngine.Random.Range(0, 9999);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text3 = $"Gamer#{arg}";
				text = text3;
			}
			if (text != null)
			{
				if (text._stringLength > maxNameLength)
				{
					string text4 = StringUtility.Truncate(text, maxNameLength, "");
				}
				return text;
			}
		}
		goto IL_010f;
		IL_010f:
		return (string)(object)new NullReferenceException();
	}

	public static string SanitizeString(string input)
	{
		return input;
	}

	public static string RemoveRichEmbedding(string text)
	{
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		if (rich != null)
		{
			if (!rich.IsMatch(text))
			{
				return text;
			}
			if (rich != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v11+B8]");
				object replacement = 0;
				return rich.Replace(text, (string)replacement);
			}
		}
		return (string)(object)new NullReferenceException();
	}

	static ChatboxUtility()
	{
		Regex regex = new Regex("<[^>]*>");
		rich = regex;
		maxNameLength = 20;
		censoredWords = new string[17]
		{
			"cock", "cunt", "dick", "dyke", "fag", "faggot", "fagg", "fuck", "homo", "jizz",
			"nigger", "n1gger", "nlgger", "nigg3r", "nigga", "n1gga", "queer"
		};
	}
}
