using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils.ColorModels;
using UnityEngine;

namespace Doozy.Engine.Utils;

[Serializable]
public class DColor
{
	private const string UNNAMED_COLOR = "Unnamed Color";

	public string ColorName;

	public Color Light;

	public Color Normal;

	public Color Dark;

	private unsafe static Color GetLightColor(Color normalColor)
	{
		//IL_0150: Invalid comparison between I4 and F4
		//IL_0170: Invalid comparison between I4 and F4
		//IL_0094: Expected F4, but got I4
		//IL_0190: Invalid comparison between I4 and F4
		//IL_019f: Expected F4, but got I4
		//IL_00b0: Expected F4, but got I4
		//IL_0239: Expected native int or pointer, but got O
		RGB rGB = null;
		rGB.r = normalColor.r;
		rGB.g = normalColor.g;
		rGB.b = normalColor.b;
		HSV hSV = ColorUtils.RGBtoHSV(rGB);
		if (hSV != null)
		{
			hSV.s = 0.3529412f;
			hSV.v = 0.9411765f;
			RGB rGB2 = ColorUtils.HSVtoRGB(hSV);
			if (rGB2 != null)
			{
				float num = rGB2.r;
				if (rGB2.r > 1f)
				{
					num = 1f;
				}
				if (0f > num)
				{
					num = 0f;
				}
				float num2 = rGB2.g;
				rGB2.r = num;
				if (rGB2.g > 1f)
				{
					num2 = 1f;
				}
				if (0f > num2)
				{
					num2 = 0f;
				}
				rGB2.g = num2;
				bool flag = rGB2.b > 1f;
				float num3 = 1f;
				if (!flag)
				{
					num3 = rGB2.b;
				}
				bool flag2 = 0f > num3;
				float b = 0f;
				if (!flag2)
				{
					b = num3;
				}
				rGB2.b = b;
				Color color = default(Color);
				float r = default(float);
				((Color*)(nint)color)->r = r;
				return color;
			}
		}
		return (Color)new NullReferenceException();
	}

	private unsafe static Color GetDarkColor(Color normalColor)
	{
		//IL_0150: Invalid comparison between I4 and F4
		//IL_0170: Invalid comparison between I4 and F4
		//IL_0094: Expected F4, but got I4
		//IL_0190: Invalid comparison between I4 and F4
		//IL_019f: Expected F4, but got I4
		//IL_00b0: Expected F4, but got I4
		//IL_0239: Expected native int or pointer, but got O
		RGB rGB = null;
		rGB.r = normalColor.r;
		rGB.g = normalColor.g;
		rGB.b = normalColor.b;
		HSV hSV = ColorUtils.RGBtoHSV(rGB);
		if (hSV != null)
		{
			hSV.s = 44f / 51f;
			hSV.v = 0.3529412f;
			RGB rGB2 = ColorUtils.HSVtoRGB(hSV);
			if (rGB2 != null)
			{
				float num = rGB2.r;
				if (rGB2.r > 1f)
				{
					num = 1f;
				}
				if (0f > num)
				{
					num = 0f;
				}
				float num2 = rGB2.g;
				rGB2.r = num;
				if (rGB2.g > 1f)
				{
					num2 = 1f;
				}
				if (0f > num2)
				{
					num2 = 0f;
				}
				rGB2.g = num2;
				bool flag = rGB2.b > 1f;
				float num3 = 1f;
				if (!flag)
				{
					num3 = rGB2.b;
				}
				bool flag2 = 0f > num3;
				float b = 0f;
				if (!flag2)
				{
					b = num3;
				}
				rGB2.b = b;
				Color color = default(Color);
				float r = default(float);
				((Color*)(nint)color)->r = r;
				return color;
			}
		}
		return (Color)new NullReferenceException();
	}

	public unsafe DColor(Color normal)
	{
		//IL_0042: Expected O, but got F4
		//IL_004b: Expected O, but got Ref
		//IL_005e: Expected O, but got F4
		//IL_0067: Expected O, but got Ref
		//IL_007f: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980601]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ColorName = "Unnamed Color";
		Normal = (Color)normal.r;
		float num = default(float);
		Light = (Color)GetLightColor((Color)(&num)).r;
		Dark = (Color)GetDarkColor((Color)(&num)).r;
	}

	public DColor(string colorName)
	{
		//IL_0021: Expected O, but got I
		//IL_0033: Expected O, but got I
		//IL_0045: Expected O, but got I
		ColorName = colorName;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		Light = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12250]");
		Normal = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
		Dark = (Color)0;
	}

	public unsafe DColor(string colorName, Color normal)
	{
		//IL_001e: Expected O, but got F4
		//IL_0027: Expected O, but got Ref
		//IL_003a: Expected O, but got F4
		//IL_0043: Expected O, but got Ref
		//IL_005b: Expected O, but got F4
		ColorName = colorName;
		Normal = (Color)normal.r;
		float num = default(float);
		Light = (Color)GetLightColor((Color)(&num)).r;
		Dark = (Color)GetDarkColor((Color)(&num)).r;
	}

	public DColor(Color light, Color normal, Color dark)
	{
		//IL_0042: Expected O, but got F4
		//IL_0051: Expected O, but got F4
		//IL_0060: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980602]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ColorName = "Unnamed Color";
		Light = (Color)light.r;
		Dark = (Color)dark.r;
		Normal = (Color)normal.r;
	}

	public DColor(string colorName, Color light, Color normal, Color dark)
	{
		//IL_001e: Expected O, but got F4
		//IL_002d: Expected O, but got F4
		ColorName = colorName;
		Light = (Color)light.r;
		Normal = (Color)normal.r;
		object dark2 = default(object);
		Dark = (Color)dark2;
	}

	public DColor(DColor dColor)
	{
		ColorName = dColor.ColorName;
		Light = dColor.Light;
		Normal = dColor.Normal;
		Dark = dColor.Dark;
	}
}
