using System;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;

namespace Assets.Scripts.UI.Mouse;

public static class Tooltip
{
	private const string tooltipColor = "#ffe88a";

	private const string tooltipColorOther = "#42b9f5";

	public unsafe static string GetTooltipString(EStat stat, string color = "#ffe88a")
	{
		//IL_01a7: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string[] array = new string[7];
		if (array.Length > 0)
		{
			array[0] = "<link=\"";
			if (array.Length > 1)
			{
				array[1] = text;
				if (array.Length > 2)
				{
					array[2] = "\"><color=";
					if (array.Length > 3)
					{
						array[3] = color;
						if (array.Length > 4)
						{
							array[4] = ">";
							string text2 = EnumUtility.EnumToReadable(stat);
							if (array.Length > 5)
							{
								array[5] = text2;
								if (array.Length > 6)
								{
									array[6] = "</color></link>";
									return string.Concat(array);
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string GetTooltipString(string s, string forceColor = "")
	{
		bool flag = forceColor == "";
		bool flag2 = !flag;
		string text = forceColor;
		if (!flag2)
		{
			text = "#42b9f5";
		}
		string[] array = new string[7];
		if (array.Length > 0)
		{
			array[0] = "<link=\"";
			if (array.Length > 1)
			{
				array[1] = s;
				if (array.Length > 2)
				{
					array[2] = "\"><color=";
					if (array.Length > 3)
					{
						array[3] = text;
						if (array.Length > 4)
						{
							array[4] = ">";
							if (array.Length > 5)
							{
								array[5] = s;
								if (array.Length > 6)
								{
									array[6] = "</color></link>";
									return string.Concat(array);
								}
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string GetIdInfo(string keyword)
	{
		//IL_0065: Expected I, but got O
		//IL_006d: Expected I, but got O
		//IL_00af: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EStat));
		if (!Enum.TryParse(typeFromHandle, keyword, out var result))
		{
			return "???: " + keyword;
		}
		nint num = (nint)typeof(EStat);
		nint num2 = (nint)result;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v3 (Il2CppClass<Assets.Scripts.Menu.Shop.EStat>)+40]");
		if (num3 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj = default(object);
			return LocalizationUtility.GetStatDesc((EStat)obj);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		string result2 = default(string);
		return result2;
	}
}
