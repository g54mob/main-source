using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MLCN_Localization;
using UnityEngine;

[Serializable]
public class AnomalyTag
{
	public static string[] anomalyOptions = new string[10] { "Hot", "Cold", "Strong", "Mild", "Icy", "Spicy", "Bloody", "Slimy", "Refreshing", "Energetic" };

	public static Color[] tagColors = new Color[10]
	{
		Color.white,
		Color.white,
		new Color(0.62f, 0.231f, 0.071f),
		new Color(1f, 0.627f, 0.31f),
		new Color(0.541f, 0.78f, 0.949f),
		new Color(0.941f, 0.294f, 0.098f),
		new Color(0.922f, 0.173f, 0.267f),
		new Color(0.376f, 0.851f, 0.522f),
		new Color(0.741f, 0.49f, 1f),
		new Color(1f, 0.953f, 0.49f)
	};

	public int anomalyFlags;

	private static AnomalyTag[] invalidCombinations = new AnomalyTag[3]
	{
		CreateByName("Hot"),
		CreateByName("Cold"),
		CreateByName(new string[2] { "Hot", "Cold" })
	};

	public static AnomalyTag GetAdditionalFittingTags(AnomalyTag excludeTags)
	{
		int num = -1;
		num -= excludeTags.anomalyFlags;
		return new AnomalyTag
		{
			anomalyFlags = num
		};
	}

	public int GetFlag()
	{
		return anomalyFlags;
	}

	public static Color GetTagColor(int mask)
	{
		List<int> indexList = GetIndexList(mask);
		List<Color> list = new List<Color>();
		for (int i = 0; i < indexList.Count; i++)
		{
			Color item = tagColors[indexList[i]];
			list.Add(item);
		}
		return CombineColors(list.ToArray());
	}

	public string GetFormattedTags()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			if (GetBit(anomalyFlags, i))
			{
				if (num == 0)
				{
					stringBuilder.Append(anomalyOptions[i]);
				}
				else
				{
					stringBuilder.Append(", " + anomalyOptions[i]);
				}
				num++;
			}
		}
		return stringBuilder.ToString();
	}

	public string GetFormattedLocalizedTags()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			if (GetBit(anomalyFlags, i))
			{
				if (num == 0)
				{
					stringBuilder.Append(LocalizationManager.GetLocalizedString(anomalyOptions[i], LocalizationDataTable.Tables.AnomalyTags));
				}
				else
				{
					stringBuilder.Append(", " + LocalizationManager.GetLocalizedString(anomalyOptions[i], LocalizationDataTable.Tables.AnomalyTags));
				}
				num++;
			}
		}
		return stringBuilder.ToString();
	}

	public static string[] GetAllTagsWithLocalization()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			list.Add(LocalizationManager.GetLocalizedString(anomalyOptions[i], LocalizationDataTable.Tables.AnomalyTags));
		}
		return list.ToArray();
	}

	public static List<int> GetIndexList(int mask)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			if (GetBit(mask, i))
			{
				list.Add(i);
			}
		}
		return list;
	}

	public static bool GetBit(int b, int bitNumber)
	{
		return (b & (1 << bitNumber)) != 0;
	}

	public static void SetBit(ref int value, bool bitval, int bitpos)
	{
		if (!bitval)
		{
			value &= ~(1 << bitpos);
		}
		else
		{
			value |= 1 << bitpos;
		}
	}

	public static bool HasTag(int value, string tagName)
	{
		int bitNumber = anomalyOptions.ToList().FindIndex((string x) => x.Equals(tagName));
		return GetBit(value, bitNumber);
	}

	public static bool HasAnySameBits(int sourceMask, int compareMask)
	{
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			if (GetBit(sourceMask, i) && GetBit(compareMask, i))
			{
				return true;
			}
		}
		return false;
	}

	public static int GetMaskIDByName(string name)
	{
		if (!anomalyOptions.ToList().Contains(name))
		{
			return 0;
		}
		int num = anomalyOptions.ToList().IndexOf(name);
		return 1 << num;
	}

	public static AnomalyTag CreateByName(string name)
	{
		if (!anomalyOptions.ToList().Contains(name))
		{
			return null;
		}
		int num = anomalyOptions.ToList().IndexOf(name);
		return new AnomalyTag
		{
			anomalyFlags = 1 << num
		};
	}

	public static AnomalyTag CreateByName(string[] names)
	{
		AnomalyTag anomalyTag = new AnomalyTag();
		for (int i = 0; i < anomalyOptions.Length; i++)
		{
			if (names.Contains(anomalyOptions[i]))
			{
				SetBit(ref anomalyTag.anomalyFlags, bitval: true, i);
			}
		}
		return anomalyTag;
	}

	public static bool IsInvalidCombination(int flavour)
	{
		bool result = false;
		if ((HasTag(flavour, "Hot") && HasTag(flavour, "Cold")) || (!HasTag(flavour, "Hot") && !HasTag(flavour, "Cold")))
		{
			return true;
		}
		for (int i = 0; i < invalidCombinations.Length; i++)
		{
			if (invalidCombinations[i].anomalyFlags == flavour)
			{
				return true;
			}
		}
		return result;
	}

	public static Color CombineColors(params Color[] aColors)
	{
		Color color = new Color(0f, 0f, 0f, 0f);
		foreach (Color color2 in aColors)
		{
			color += color2;
		}
		return color / aColors.Length;
	}

	public static Color TransformHSV(Color color, float H, float S, float V)
	{
		float num = V * S * Mathf.Cos(H * MathF.PI / 180f);
		float num2 = V * S * Mathf.Sin(H * MathF.PI / 180f);
		Color result = new Color
		{
			r = (0.299f * V + 0.701f * num + 0.168f * num2) * color.r + (0.587f * V - 0.587f * num + 0.33f * num2) * color.g + (0.114f * V - 0.114f * num - 0.497f * num2) * color.b,
			g = (0.299f * V - 0.299f * num - 0.328f * num2) * color.r + (0.587f * V + 0.413f * num + 0.035f * num2) * color.g + (0.114f * V - 0.114f * num + 0.292f * num2) * color.b,
			b = (0.299f * V - 0.3f * num + 1.25f * num2) * color.r + (0.587f * V - 0.588f * num - 1.05f * num2) * color.g + (0.114f * V + 0.886f * num - 0.203f * num2) * color.b,
			a = 1f
		};
		if (result.r < 0f)
		{
			result.r = 0f;
		}
		if (result.g < 0f)
		{
			result.g = 0f;
		}
		if (result.b < 0f)
		{
			result.b = 0f;
		}
		return result;
	}
}
