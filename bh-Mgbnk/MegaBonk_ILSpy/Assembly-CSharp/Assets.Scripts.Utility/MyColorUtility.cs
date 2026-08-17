using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Utility;

public static class MyColorUtility
{
	public const string white = "#ffffff";

	public static string positiveColorString;

	public static string negativeColorString;

	public static Color aegisColor;

	public static Color weakAegisColor;

	public static Color bleedColor;

	public static Color tier1Color;

	public static Color tier2Color;

	public static Color tier3Color;

	private static Dictionary<EStatCategory, Color> statCategoryColors;

	private static Color hasteColor;

	private static Color magnetColor;

	private static Color shieldColor;

	private static Color timeFreezeColor;

	private static Color healthColor;

	private static Color rageColor;

	private static Color stonksColor;

	private static Color newColor;

	private static Color commonColor;

	private static Color uncommonColor;

	private static Color rareColor;

	private static Color epicColor;

	private static Color legendaryColor;

	public static Color interactOutlineColor;

	public static Color interactDisabledOutlineColor;

	public static string requirementCompletedColor;

	public static string requirementMissingColor;

	public static Color evadeColor;

	public static Color evadePhantomColor;

	public static Color critMegaColor;

	public static Color bonkColor;

	public static Color poisonColor;

	public static Color fireColor;

	public static Color executeColor;

	public static Color echoColor;

	public static Color bloodmarkColor;

	private static Color warningRed;

	private static Color warningBlue;

	private static Color warningMagenta;

	private static Color warningWhite;

	private static Color warningYellow;

	private static Color easyColor;

	private static Color mediumColor;

	private static Color hardColor;

	private static Color cookedColor;

	private static Color rankTier1Color;

	private static Color rankTier2Color;

	private static Color rankTier3Color;

	private static Color rankTier4Color;

	private static Color rankTier5Color;

	private static Color rankTier6Color;

	public static void Init()
	{
	}

	public unsafe static Color GetStatCategoryColor(EStatCategory statCategory)
	{
		//IL_001f: Expected native int or pointer, but got O
		if (statCategoryColors != null)
		{
			Color color = ((Dictionary<System.Int32Enum, Color>)(object)statCategoryColors).get_Item((System.Int32Enum)statCategory);
			Color color2 = default(Color);
			float r = default(float);
			((Color*)(nint)color2)->r = r;
			return color2;
		}
		return (Color)new NullReferenceException();
	}

	private unsafe static Color StringToColor(string s)
	{
		//IL_0009: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->r = 0f;
		bool flag = ColorUtility.TryParseHtmlString(s, out *(Color*)color);
		return color;
	}

	public static Color PickupToColor(EPickup ePickup)
	{
		//IL_001d: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 41 Invalid \"Jump target not found in method: 0x1803C3A59\"");
		return (Color)(ePickup - 2);
	}

	public unsafe static Color RarityToColor(ERarity rarity)
	{
		//IL_0066: Expected F4, but got O
		//IL_0061: Expected native int or pointer, but got O
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		if (rarity <= ERarity.Legendary)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1+3C3C9C+rarity @ rdx (Assets.Scripts.Inventory__Items__Pickups.ERarity)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v45 @ rcx_v5 (should have been resolved before IL gen)");
		}
		Color color = default(Color);
		((Color*)(nint)color)->r = (float)commonColor;
		return color;
	}

	public unsafe static Color GetRarityColorBackground(ERarity rarity)
	{
		//IL_0049: Expected I, but got O
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00aa: Expected O, but got I
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0114: Expected O, but got I
		//IL_011c: Expected native int or pointer, but got O
		//IL_0150: Expected native int or pointer, but got O
		//IL_019c: Expected native int or pointer, but got O
		nint num = (nint)typeof(MyColorUtility);
		if (rarity <= ERarity.Legendary)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v1+3C3418+rarity @ rdx (Assets.Scripts.Inventory__Items__Pickups.ERarity)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ rcx_v7 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v4 (Il2CppClass<Assets.Scripts.Utility.MyColorUtility>)+B8]");
		nint num2 = 0;
		object obj3 = 0 - commonColor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+100]");
		object obj4 = -0;
		float num3 = (float)obj3 * 0.8f;
		float num4 = (float)obj4 * 0.8f;
		float r = num3 + (float)commonColor;
		float num5 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+100]");
		float b = num5 + 0f;
		Color color = default(Color);
		((Color*)(nint)color)->r = r;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+FC]");
		object obj5 = -0;
		((Color*)(nint)color)->b = b;
		float num6 = (float)obj5 * 0.8f;
		float num7 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+FC]");
		float g = num7 + 0f;
		((Color*)(nint)color)->g = g;
		float num8 = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+104]");
		float num9 = num8 - 0f;
		float num10 = num9 * 0.8f;
		float num11 = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v5 (Il2CppStaticFields<Assets.Scripts.Utility.MyColorUtility>)+104]");
		float a = num11 + 0f;
		((Color*)(nint)color)->a = a;
		return color;
	}

	public unsafe static Color GetRarityColorBackground(EItemRarity rarity)
	{
		//IL_0044: Expected I, but got O
		//IL_0106: Expected native int or pointer, but got O
		//IL_0113: Expected native int or pointer, but got O
		//IL_0120: Expected native int or pointer, but got O
		//IL_015e: Expected native int or pointer, but got O
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		while (true)
		{
			nint num = (nint)typeof(MyColorUtility);
			if (rarity > EItemRarity.Quest)
			{
				break;
			}
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v1+3C3160+rarity @ rdx (Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v86 @ rcx_v5 (should have been resolved before IL gen)");
		}
		float num2 = 0f - 0.5f;
		float num3 = 1f - 1f;
		float num4 = 0f - 0.5f;
		float num5 = num2 * 0.8f;
		float num6 = num3 * 0.8f;
		float num7 = num4 * 0.8f;
		float b = num5 + 0.5f;
		float a = num6 + 1f;
		float r = num7 + 0.5f;
		Color color = default(Color);
		((Color*)(nint)color)->b = b;
		((Color*)(nint)color)->a = a;
		((Color*)(nint)color)->r = r;
		float num8 = 0f - 0.5f;
		float num9 = num8 * 0.8f;
		float g = num9 + 0.5f;
		((Color*)(nint)color)->g = g;
		return color;
	}

	public unsafe static Color GetItemRarityColor(EItemRarity rarity)
	{
		//IL_003f: Expected native int or pointer, but got O
		//IL_004d: Expected native int or pointer, but got O
		//IL_005b: Expected native int or pointer, but got O
		//IL_008b: Expected native int or pointer, but got O
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		if (rarity <= EItemRarity.Quest)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1+3C2D10+rarity @ rdx (Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v45 @ rcx_v3 (should have been resolved before IL gen)");
		}
		Color color = default(Color);
		((Color*)(nint)color)->r = 0.5f;
		((Color*)(nint)color)->g = 0.5f;
		((Color*)(nint)color)->b = 0.5f;
		((Color*)(nint)color)->a = 1f;
		return color;
	}

	public unsafe static Color GetDamageEffectColor(EDamageEffect effect)
	{
		//IL_00bd: Expected O, but got I4
		//IL_0058: Expected O, but got Ref
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		object obj = effect - 1;
		if ((nint)obj <= 8)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v6+3C2A94+v31 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ rcx_v13 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
		object obj4 = default(object);
		string text = ((Enum)(&obj4)).ToString();
		string message = "Color not implemented for effect: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		CheckoutException ex = new CheckoutException(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public static string GetStatTextColor(bool isPositive)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831724E8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !isPositive;
		string result = "#ff3224";
		if (!flag)
		{
			result = "#24ff36";
		}
		return result;
	}

	public unsafe static Color GetRedToGreenGradient(float t)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0054: Expected F4, but got I4
		//IL_009e: Invalid comparison between I4 and F4
		//IL_0090: Expected F4, but got I4
		//IL_00ea: Expected native int or pointer, but got O
		float num = default(float);
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float h = num * (1f / 3f);
		Color color = default(Color);
		bool hdr = default(bool);
		((Color*)(nint)color)->r = Color.HSVToRGB(h, 1f, 1f, hdr).r;
		return color;
	}

	public unsafe static Color GetHealthBarColor(EHpBarColor color)
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0148: Expected native int or pointer, but got O
		//IL_015b: Expected native int or pointer, but got O
		//IL_0039: Expected O, but got I4
		//IL_0119: Expected native int or pointer, but got O
		//IL_0127: Expected native int or pointer, but got O
		//IL_0135: Expected native int or pointer, but got O
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_00ea: Expected native int or pointer, but got O
		//IL_00f8: Expected native int or pointer, but got O
		//IL_0106: Expected native int or pointer, but got O
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00c9: Expected native int or pointer, but got O
		//IL_00d7: Expected native int or pointer, but got O
		//IL_0088: Expected native int or pointer, but got O
		//IL_00b6: Expected native int or pointer, but got O
		Color color2 = default(Color);
		((Color*)(nint)color2)->a = 1f;
		bool flag = color == EHpBarColor.Red;
		if (!flag)
		{
			object obj = color - 1;
			if (flag)
			{
				((Color*)(nint)color2)->r = 1f;
				((Color*)(nint)color2)->g = 1f;
				((Color*)(nint)color2)->b = 1f;
				return color2;
			}
			object obj2 = obj - 1;
			if (flag)
			{
				((Color*)(nint)color2)->r = 1f;
				((Color*)(nint)color2)->g = 47f / 51f;
				((Color*)(nint)color2)->b = 0.015686275f;
				return color2;
			}
			object obj3 = obj2 - 1;
			if (flag)
			{
				((Color*)(nint)color2)->b = 1f;
				((Color*)(nint)color2)->r = 0f;
				return color2;
			}
			((Color*)(nint)color2)->r = 1f;
			if ((nint)obj3 == 1)
			{
				((Color*)(nint)color2)->b = 1f;
				return color2;
			}
		}
		else
		{
			((Color*)(nint)color2)->r = 1f;
		}
		((Color*)(nint)color2)->b = 0f;
		return color2;
	}

	public unsafe static Color GetWarningColor(EHpBarColor color)
	{
		//IL_0109: Expected F4, but got O
		//IL_0104: Expected native int or pointer, but got O
		//IL_0013: Expected O, but got I4
		//IL_00f6: Expected F4, but got O
		//IL_00f1: Expected native int or pointer, but got O
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_00e3: Expected F4, but got O
		//IL_00de: Expected native int or pointer, but got O
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00d0: Expected F4, but got O
		//IL_00cb: Expected native int or pointer, but got O
		//IL_00bd: Expected F4, but got O
		//IL_00b8: Expected native int or pointer, but got O
		bool flag = color == EHpBarColor.Red;
		Color color2 = default(Color);
		if (!flag)
		{
			object obj = color - 1;
			if (flag)
			{
				((Color*)(nint)color2)->r = (float)warningWhite;
				return color2;
			}
			object obj2 = obj - 1;
			if (flag)
			{
				((Color*)(nint)color2)->r = (float)warningYellow;
				return color2;
			}
			object obj3 = obj2 - 1;
			if (flag)
			{
				((Color*)(nint)color2)->r = (float)warningBlue;
				return color2;
			}
			if ((nint)obj3 == 1)
			{
				((Color*)(nint)color2)->r = (float)warningMagenta;
				return color2;
			}
		}
		((Color*)(nint)color2)->r = (float)warningRed;
		return color2;
	}

	public unsafe static Color GetTierColor(int tier)
	{
		//IL_00a1: Expected F4, but got O
		//IL_009c: Expected native int or pointer, but got O
		//IL_0013: Expected O, but got I4
		//IL_008e: Expected F4, but got O
		//IL_0089: Expected native int or pointer, but got O
		//IL_007b: Expected F4, but got O
		//IL_0076: Expected native int or pointer, but got O
		bool flag = tier == 0;
		Color color = default(Color);
		if (!flag)
		{
			object obj = tier - 1;
			if (flag)
			{
				((Color*)(nint)color)->r = (float)tier2Color;
				return color;
			}
			if ((nint)obj == 1)
			{
				((Color*)(nint)color)->r = (float)tier3Color;
				return color;
			}
		}
		((Color*)(nint)color)->r = (float)tier1Color;
		return color;
	}

	public static Color GetRankColor(int rank)
	{
		//IL_0038: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
		int num = rank >> 4;
		int num2 = num >> 31;
		Color result = (Color)(num + num2);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 40 Invalid \"Jump target not found in method: 0x1803C2EC3\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 44 Invalid \"Jump target not found in method: 0x1803C2D8D\"");
		return result;
	}

	public unsafe static Color DifficultyToColor(EAchievementDifficulty difficulty)
	{
		//IL_00ea: Expected F4, but got O
		//IL_00e5: Expected native int or pointer, but got O
		//IL_0013: Expected O, but got I4
		//IL_00d7: Expected F4, but got O
		//IL_00d2: Expected native int or pointer, but got O
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_00c4: Expected F4, but got O
		//IL_00bf: Expected native int or pointer, but got O
		//IL_00b1: Expected F4, but got O
		//IL_00ac: Expected native int or pointer, but got O
		//IL_009e: Expected F4, but got O
		//IL_0099: Expected native int or pointer, but got O
		bool flag = difficulty == EAchievementDifficulty.Easy;
		Color color = default(Color);
		if (!flag)
		{
			object obj = difficulty - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						((Color*)(nint)color)->r = (float)uncommonColor;
						return color;
					}
					((Color*)(nint)color)->r = (float)cookedColor;
					return color;
				}
				((Color*)(nint)color)->r = (float)hardColor;
				return color;
			}
			((Color*)(nint)color)->r = (float)mediumColor;
			return color;
		}
		((Color*)(nint)color)->r = (float)easyColor;
		return color;
	}

	public unsafe static Color GetHexToColor(string hex)
	{
		//IL_0009: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->r = 0f;
		bool flag = ColorUtility.TryParseHtmlString(hex, out *(Color*)color);
		return color;
	}

	public unsafe static string ColorToHex(Color color)
	{
		//IL_0009: Expected O, but got Ref
		object obj = default(object);
		return ColorUtility.ToHtmlStringRGBA((Color)(&obj));
	}

	unsafe static MyColorUtility()
	{
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Expected Ref, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Ref, but got Unknown
		//IL_0024: Expected O, but got I
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Ref, but got Unknown
		//IL_005b: Expected O, but got I
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Ref, but got Unknown
		//IL_0097: Expected O, but got I
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Ref, but got Unknown
		//IL_00ce: Expected O, but got I
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Ref, but got Unknown
		//IL_010a: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Ref, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Ref, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected Ref, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected Ref, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected Ref, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected Ref, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected Ref, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected Ref, but got Unknown
		//IL_03a5: Expected O, but got I
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected Ref, but got Unknown
		//IL_03e1: Expected O, but got I
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected Ref, but got Unknown
		//IL_0418: Expected O, but got I
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected Ref, but got Unknown
		//IL_0454: Expected O, but got I
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected Ref, but got Unknown
		//IL_048b: Expected O, but got I
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected Ref, but got Unknown
		//IL_04c7: Expected O, but got I
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected Ref, but got Unknown
		//IL_04fe: Expected O, but got I
		//IL_052c: Expected O, but got I
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected Ref, but got Unknown
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected Ref, but got Unknown
		//IL_0571: Expected O, but got I
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected Ref, but got Unknown
		//IL_05ad: Expected O, but got I
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Expected Ref, but got Unknown
		//IL_05e4: Expected O, but got I
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected Ref, but got Unknown
		//IL_0620: Expected O, but got I
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Expected Ref, but got Unknown
		//IL_0657: Expected O, but got I
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Expected Ref, but got Unknown
		//IL_0693: Expected O, but got I
		//IL_06bc: Expected O, but got I
		//IL_06e3: Expected I, but got O
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f1: Expected Ref, but got Unknown
		//IL_0711: Expected O, but got I4
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected Ref, but got Unknown
		//IL_0759: Expected O, but got I
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Expected Ref, but got Unknown
		//IL_0790: Expected O, but got I
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected Ref, but got Unknown
		//IL_07cc: Expected O, but got I
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Expected Ref, but got Unknown
		//IL_0803: Expected O, but got I
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected Ref, but got Unknown
		//IL_083f: Expected O, but got I
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected Ref, but got Unknown
		//IL_0876: Expected O, but got I
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected Ref, but got Unknown
		//IL_08b2: Expected O, but got I
		//IL_08d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Expected Ref, but got Unknown
		//IL_08e9: Expected O, but got I
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Expected Ref, but got Unknown
		//IL_0925: Expected O, but got I
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected Ref, but got Unknown
		//IL_095c: Expected O, but got I
		//IL_0982: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected Ref, but got Unknown
		//IL_0998: Expected O, but got I
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09be: Expected Ref, but got Unknown
		//IL_09cf: Expected O, but got I
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Expected Ref, but got Unknown
		//IL_0a0b: Expected O, but got I
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Expected Ref, but got Unknown
		//IL_0a42: Expected O, but got I
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected Ref, but got Unknown
		//IL_0a7e: Expected O, but got I
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Expected Ref, but got Unknown
		//IL_0ab5: Expected O, but got I
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Expected Ref, but got Unknown
		//IL_0af1: Expected O, but got I
		//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b17: Expected Ref, but got Unknown
		//IL_0b28: Expected O, but got I
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b53: Expected Ref, but got Unknown
		//IL_0b64: Expected O, but got I
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8a: Expected Ref, but got Unknown
		//IL_0b9b: Expected O, but got I
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Expected Ref, but got Unknown
		//IL_0bd7: Expected O, but got I
		//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Expected Ref, but got Unknown
		//IL_0c0e: Expected O, but got I
		//IL_0c3c: Expected O, but got I
		positiveColorString = "#30e363";
		negativeColorString = "#e33030";
		object obj = default(object);
		ref Color color = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag = ColorUtility.TryParseHtmlString("#ffcd29", out color);
		ref Color color2 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		aegisColor = (Color)0;
		_ = 0;
		bool flag2 = ColorUtility.TryParseHtmlString("#ffe694", out color2);
		ref Color color3 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		weakAegisColor = (Color)0;
		_ = 0;
		bool flag3 = ColorUtility.TryParseHtmlString("#a6001e", out color3);
		ref Color color4 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		bleedColor = (Color)0;
		_ = 0;
		bool flag4 = ColorUtility.TryParseHtmlString("#3EBE71", out color4);
		ref Color color5 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		tier1Color = (Color)0;
		_ = 0;
		bool flag5 = ColorUtility.TryParseHtmlString("#177FFF", out color5);
		ref Color color6 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		tier2Color = (Color)0;
		_ = 0;
		bool flag6 = ColorUtility.TryParseHtmlString("#FF8100", out color6);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		tier3Color = (Color)0;
		Dictionary<EStatCategory, Color> dictionary = new Dictionary<EStatCategory, Color>();
		ref Color color7 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag7 = ColorUtility.TryParseHtmlString("#FF4500", out color7);
		Color value = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)0, value);
		ref Color color8 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag8 = ColorUtility.TryParseHtmlString("#00CED1", out color8);
		Color value2 = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)1, value2);
		ref Color color9 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag9 = ColorUtility.TryParseHtmlString("#32CD32", out color9);
		Color value3 = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)2, value3);
		ref Color color10 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag10 = ColorUtility.TryParseHtmlString("#FFD700", out color10);
		Color value4 = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)3, value4);
		ref Color color11 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag11 = ColorUtility.TryParseHtmlString("#E50069", out color11);
		Color value5 = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)5, value5);
		ref Color color12 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag12 = ColorUtility.TryParseHtmlString("#4008FF", out color12);
		Color value6 = (Color)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		_ = 0;
		((Dictionary<System.Int32Enum, Color>)(object)dictionary).Add((System.Int32Enum)4, value6);
		statCategoryColors = dictionary;
		ref Color color13 = ref *(Color*)(obj - 16);
		_ = 0;
		bool flag13 = ColorUtility.TryParseHtmlString("#00B4FF", out color13);
		ref Color color14 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		hasteColor = (Color)0;
		_ = 0;
		bool flag14 = ColorUtility.TryParseHtmlString("#FF7F19", out color14);
		ref Color color15 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		magnetColor = (Color)0;
		_ = 0;
		bool flag15 = ColorUtility.TryParseHtmlString("#00FF41", out color15);
		ref Color color16 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		shieldColor = (Color)0;
		_ = 0;
		bool flag16 = ColorUtility.TryParseHtmlString("#00FF97", out color16);
		ref Color color17 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		timeFreezeColor = (Color)0;
		_ = 0;
		bool flag17 = ColorUtility.TryParseHtmlString("#FF1800", out color17);
		ref Color color18 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		healthColor = (Color)0;
		_ = 0;
		bool flag18 = ColorUtility.TryParseHtmlString("#FF42F0", out color18);
		ref Color color19 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rageColor = (Color)0;
		_ = 0;
		bool flag19 = ColorUtility.TryParseHtmlString("#FFF814", out color19);
		ref Color color20 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		stonksColor = (Color)0;
		_ = 0;
		bool flag20 = ColorUtility.TryParseHtmlString("#FFFFFF", out color20);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		newColor = (Color)0;
		_ = 0;
		bool flag21 = ColorUtility.TryParseHtmlString("#4dff97", out *(Color*)(obj - 16));
		ref Color color21 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		commonColor = (Color)0;
		_ = 0;
		bool flag22 = ColorUtility.TryParseHtmlString("#0ca7fa", out color21);
		ref Color color22 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		uncommonColor = (Color)0;
		_ = 0;
		bool flag23 = ColorUtility.TryParseHtmlString("#FF00F4", out color22);
		ref Color color23 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rareColor = (Color)0;
		_ = 0;
		bool flag24 = ColorUtility.TryParseHtmlString("#ff2929", out color23);
		ref Color color24 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		epicColor = (Color)0;
		_ = 0;
		bool flag25 = ColorUtility.TryParseHtmlString("#FFE300", out color24);
		ref Color color25 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		legendaryColor = (Color)0;
		_ = 0;
		bool flag26 = ColorUtility.TryParseHtmlString("#ffd745", out color25);
		ref Color color26 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		interactOutlineColor = (Color)0;
		_ = 0;
		bool flag27 = ColorUtility.TryParseHtmlString("#bd2222", out color26);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		interactDisabledOutlineColor = (Color)0;
		requirementCompletedColor = "#0ceb2d";
		requirementMissingColor = "#ff6a38";
		nint num = (nint)typeof(MyColorUtility);
		ref Color color27 = ref *(Color*)(obj - 16);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v77 (Il2CppClass<Assets.Scripts.Utility.MyColorUtility>)+B8]");
		nint num2 = 0;
		evadeColor = (Color)0;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		bool flag28 = ColorUtility.TryParseHtmlString("#f06bff", out color27);
		ref Color color28 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		evadePhantomColor = (Color)0;
		_ = 0;
		bool flag29 = ColorUtility.TryParseHtmlString("#ff6d12", out color28);
		ref Color color29 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		critMegaColor = (Color)0;
		_ = 0;
		bool flag30 = ColorUtility.TryParseHtmlString("#ff0055", out color29);
		ref Color color30 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		bonkColor = (Color)0;
		_ = 0;
		bool flag31 = ColorUtility.TryParseHtmlString("#d063ff", out color30);
		ref Color color31 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		poisonColor = (Color)0;
		_ = 0;
		bool flag32 = ColorUtility.TryParseHtmlString("#fc9d3d", out color31);
		ref Color color32 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		fireColor = (Color)0;
		_ = 0;
		bool flag33 = ColorUtility.TryParseHtmlString("#b50000", out color32);
		ref Color color33 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		executeColor = (Color)0;
		_ = 0;
		bool flag34 = ColorUtility.TryParseHtmlString("#42ff91", out color33);
		ref Color color34 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		echoColor = (Color)0;
		_ = 0;
		bool flag35 = ColorUtility.TryParseHtmlString("#ff0000", out color34);
		ref Color color35 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		bloodmarkColor = (Color)0;
		_ = 0;
		bool flag36 = ColorUtility.TryParseHtmlString("#FF0C00", out color35);
		ref Color color36 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		warningRed = (Color)0;
		_ = 0;
		bool flag37 = ColorUtility.TryParseHtmlString("#4275f5", out color36);
		ref Color color37 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		warningBlue = (Color)0;
		_ = 0;
		bool flag38 = ColorUtility.TryParseHtmlString("#d91cff", out color37);
		ref Color color38 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		warningMagenta = (Color)0;
		_ = 0;
		bool flag39 = ColorUtility.TryParseHtmlString("#ffffff", out color38);
		ref Color color39 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		warningWhite = (Color)0;
		_ = 0;
		bool flag40 = ColorUtility.TryParseHtmlString("#fff82b", out color39);
		ref Color color40 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		warningYellow = (Color)0;
		_ = 0;
		bool flag41 = ColorUtility.TryParseHtmlString("#CCFFD0", out color40);
		ref Color color41 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		easyColor = (Color)0;
		_ = 0;
		bool flag42 = ColorUtility.TryParseHtmlString("#009DFF", out color41);
		ref Color color42 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		mediumColor = (Color)0;
		_ = 0;
		bool flag43 = ColorUtility.TryParseHtmlString("#FF1027", out color42);
		ref Color color43 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		hardColor = (Color)0;
		_ = 0;
		bool flag44 = ColorUtility.TryParseHtmlString("#FFE000", out color43);
		ref Color color44 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		cookedColor = (Color)0;
		_ = 0;
		bool flag45 = ColorUtility.TryParseHtmlString("#E7E7E7", out color44);
		ref Color color45 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier1Color = (Color)0;
		_ = 0;
		bool flag46 = ColorUtility.TryParseHtmlString("#31FF6C", out color45);
		ref Color color46 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier2Color = (Color)0;
		_ = 0;
		bool flag47 = ColorUtility.TryParseHtmlString("#2AC8FF", out color46);
		ref Color color47 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier3Color = (Color)0;
		_ = 0;
		bool flag48 = ColorUtility.TryParseHtmlString("#FF25B5", out color47);
		ref Color color48 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier4Color = (Color)0;
		_ = 0;
		bool flag49 = ColorUtility.TryParseHtmlString("#FF3928", out color48);
		ref Color color49 = ref *(Color*)(obj - 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier5Color = (Color)0;
		_ = 0;
		bool flag50 = ColorUtility.TryParseHtmlString("#FFED28", out color49);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
		rankTier6Color = (Color)0;
	}
}
