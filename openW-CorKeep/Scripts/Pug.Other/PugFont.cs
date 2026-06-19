using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "New Font", menuName = "Pug/UI/PugFont", order = 1)]
public class PugFont : ScriptableObject
{
	[Serializable]
	public class GlyphData
	{
		public RectInt rect;

		public byte[] kerning;

		[NonSerialized]
		public Sprite volatileSprite;
	}

	public Texture2D texture;

	public Vector2Int charDims = new Vector2Int(8, 8);

	public float pixelsPerUnit = 16f;

	public int charSpacing;

	public int spaceWidth = 5;

	public int lineSpacing = 1;

	public int emptyLineSpacing = 5;

	public bool proportionalFont = true;

	public bool allCaps;

	public bool enableKerning;

	private List<SpriteRenderer> currentWordNeededToReverse = new List<SpriteRenderer>();

	[NonSerialized]
	public static string latinCharset = "♥♡       ♦♢„“–” ⁰¹²³⁴⁵⁶⁷⁸⁹     ⚑☻!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~…ÀÁÂÃÄÅÇÈÉÊËÍÌÎÏÑÒÓÔÕÖØÙÚÛÜÆŒß¿¡\u00a0àáâãäåçèéêëíìîïñòóôõöøùúûüæœ©™  \u00b4ĞğıİŞşĄąŚśŻżźŁłćęńšČčŠŮůŽžŘřĚě ŇňÝýŤťĎď×ĆŹĘŃ’«»                юабцдефгхийклмнопярстчжвьызшэщуъЮАБЦДЕФГХИЙКЛМНОПЯРСТЧЖВЬЫЗШЭЩУЪЇїІіЄє—ЁёҐґŰűŲųĀāĊċĒēĠġĢģĦħÐðĪī ĮįĲĳĶķĹĺĻļĽľŅņŐőŔŕÞþȚțŪūŸÿ      ";

	[NonSerialized]
	public static string buttonCharset = "ⒶⒷⓍⓎ▤⊕⊖◐◑◒◓□◯△☓▯◖◗";

	[Multiline(10)]
	public string _customCharset;

	[Header("Cached metrics")]
	public GlyphData[] glyphData;

	[NonSerialized]
	public Dictionary<char, int> codePoints = new Dictionary<char, int>();

	private static readonly List<SpriteRenderer> preallocSRs = new List<SpriteRenderer>(128);

	public string charset
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(_customCharset))
			{
				return _customCharset;
			}
			return latinCharset;
		}
	}

	public bool hasMetrics
	{
		get
		{
			if (glyphData != null)
			{
				return glyphData.Length != 0;
			}
			return false;
		}
	}

	public Sprite GetGlyphSprite(char c)
	{
		return glyphData[codePoints[c]]?.volatileSprite;
	}

	public void InitCodePoints()
	{
		codePoints.Clear();
		for (int i = 0; i < Math.Min(glyphData.Length, charset.Length); i++)
		{
			if (charset[i] == ' ')
			{
				continue;
			}
			if (codePoints.ContainsKey(charset[i]))
			{
				if (charset[i] != '§')
				{
					Debug.LogWarning(base.name + ": Already defined glyph #" + i + " " + charset[i]);
				}
				continue;
			}
			RectInt rect = glyphData[i].rect;
			if (rect.size.x != 0 && rect.size.y != 0)
			{
				codePoints.Add(charset[i], i);
				Rect rect2 = new Rect(rect.position + new Vector2Int(0, 1), rect.size - new Vector2Int(0, 1));
				if (rect2.width + rect2.x + 2f < (float)texture.width)
				{
					rect2.width += 2f;
					rect2.x -= 1f;
				}
				else
				{
					Debug.LogError("You need to make the font texture " + texture.name + " 1 pixel wider to the right to support outlines.");
				}
				int num = (int)rect2.width / 2;
				int num2 = (int)rect2.height / 2;
				Vector2 pivot = new Vector2((float)num / rect2.width, (float)num2 / rect2.height);
				glyphData[i].volatileSprite = Sprite.Create(texture, rect2, pivot, pixelsPerUnit, 0u, SpriteMeshType.FullRect);
			}
		}
	}

	public Transform RenderNonPooled(string text, PugTextStyle style, Transform root, out string formattedString, out int displayedTextStringLinesAmount)
	{
		return Render(text, null, style, root, null, localized: false, out formattedString, out displayedTextStringLinesAmount);
	}

	public Transform Render(string text, PugText pooledObj, PugTextStyle style, Transform root, TextManager tm, bool localized, out string formattedString, out int displayedTextStringLinesAmount, float maxWidth = 0f, bool usePauseSigns = false, Material overrideMaterial = null)
	{
		formattedString = text;
		if (allCaps)
		{
			formattedString = formattedString.ToUpper();
		}
		if (maxWidth > 0f)
		{
			formattedString = AddNewLinesToLinesExceedingMaxWidth(formattedString, maxWidth, style, usePauseSigns);
		}
		bool flag = LocalizationManager.IsRight2Left && localized;
		int num = ((!flag) ? 1 : (-1));
		float num2 = (flag ? style.rightToLeftXOffset : 0f);
		currentWordNeededToReverse.Clear();
		float num3 = num2;
		float num4 = 0f;
		float num5 = charSpacing + style.extraCharSpacing;
		Transform transform = null;
		int num6 = 0;
		float num7 = 0f;
		int num8 = 0;
		if (root == null && pooledObj != null)
		{
			root = pooledObj.transform;
		}
		int layer = root.gameObject.layer;
		if (pooledObj != null)
		{
			pooledObj.localCharacterEndPositions.Clear();
		}
		List<float> list;
		List<Transform> list2;
		if (tm != null)
		{
			list = tm.preallocLineWidths;
			list2 = tm.preallocLines;
		}
		else
		{
			list = new List<float>();
			list2 = new List<Transform>();
		}
		int sortingLayerID = SortingLayerID.GUI;
		if (style.sortingLayer != int.MinValue)
		{
			sortingLayerID = style.sortingLayer;
		}
		Color color = style.color;
		bool flag2 = false;
		for (int i = 0; i < formattedString.Length; i++)
		{
			char c = formattedString[i];
			bool usedCharacterFromOtherLanguage = false;
			if (transform == null)
			{
				if ((bool)pooledObj)
				{
					transform = tm.containerPool.GetFreeComponent<Transform>();
					if (transform == null)
					{
						break;
					}
					pooledObj.pooledTransforms.Add(transform);
				}
				else
				{
					transform = new GameObject("RadicalText NonPooled Container").transform;
				}
				list2.Add(transform);
				transform.parent = root;
				transform.gameObject.layer = layer;
				Transform transform2 = transform.transform;
				transform2.SetLocalPositionAndRotation(new Vector2(0f, num4), Quaternion.identity);
				transform2.localScale = Vector3.one;
				num6 = 0;
			}
			SpriteRenderer spriteRenderer = null;
			if (c == ' ' || c == '\u00a0')
			{
				usedCharacterFromOtherLanguage = true;
				num3 += (float)num * ((float)(spaceWidth + style.extraSpaceWidth) / pixelsPerUnit);
			}
			else
			{
				if (c == '\r')
				{
					if (pooledObj != null)
					{
						pooledObj.localCharacterEndPositions.Add(new Vector2(num3, num4));
					}
					continue;
				}
				if (c == '\n')
				{
					if (Mathf.Abs(num3) > num7)
					{
						num7 = Mathf.Abs(num3);
					}
					list.Add(num3);
					num3 = num2;
					num4 = ((num6 <= 0) ? (num4 - (float)(emptyLineSpacing + style.extraEmptyLineSpacing) / pixelsPerUnit) : (num4 - (float)(charDims.y + (lineSpacing + style.extraLineSpacing)) / pixelsPerUnit));
					transform = null;
				}
				else
				{
					if (usePauseSigns && (c == '`' || c == '*'))
					{
						continue;
					}
					Color color2;
					if (style.supportColorTags && flag2 && IsEndOfColorCodeAtPosition(formattedString, i))
					{
						flag2 = false;
						color = style.color;
						i += 2;
					}
					else if (style.supportColorTags && TryGetColorFromHexAtPosition(formattedString, i, out color2))
					{
						color = color2;
						flag2 = true;
						i += 10;
					}
					else
					{
						GlyphData gd = null;
						int cp = 0;
						if (!GetGlyphData(c, out gd, style, out usedCharacterFromOtherLanguage, out cp))
						{
							continue;
						}
						if ((bool)pooledObj)
						{
							spriteRenderer = tm.glyphPool.GetFreeComponent<SpriteRenderer>();
							if (spriteRenderer == null)
							{
								break;
							}
							pooledObj.glyphs.Add(spriteRenderer);
							pooledObj.glyphTransforms.Add(spriteRenderer.transform);
							if (style.supportColorTags)
							{
								pooledObj.glyphColorOverrides.Add(flag2);
							}
						}
						else
						{
							spriteRenderer = new GameObject("Non-pooled glyph").AddComponent<SpriteRenderer>();
							spriteRenderer.gameObject.SetActive(value: true);
						}
						if (Application.isPlaying)
						{
							spriteRenderer.sharedMaterial = ((overrideMaterial != null) ? overrideMaterial : Manager.text.defaultTextMaterial);
						}
						if (num6 > 0)
						{
							num3 += (float)num * (num5 / pixelsPerUnit);
						}
						int num9 = gd.rect.width / 2;
						int num10 = gd.rect.width - num9;
						num3 += (float)num * ((float)num9 / pixelsPerUnit);
						if (enableKerning && num6 > 0 && num8 < glyphData.Length)
						{
							byte[] kerning = glyphData[num8].kerning;
							if (kerning != null && kerning.Length != 0 && cp < kerning.Length)
							{
								float num11 = (int)kerning[cp];
								if (num5 > Mathf.Epsilon)
								{
									num11 = Mathf.Round(num11 / num5 + 0.001f);
								}
								num3 -= (float)num * (num11 / pixelsPerUnit);
							}
						}
						spriteRenderer.enabled = true;
						spriteRenderer.sprite = gd.volatileSprite;
						spriteRenderer.color = color;
						spriteRenderer.gameObject.layer = layer;
						spriteRenderer.sortingLayerID = sortingLayerID;
						spriteRenderer.sortingOrder = style.orderInLayer;
						spriteRenderer.maskInteraction = style.maskInteraction;
						Transform transform3 = spriteRenderer.transform;
						transform3.parent = transform;
						transform3.SetLocalPositionAndRotation(new Vector3(num3, 0f), Quaternion.identity);
						transform3.localScale = Vector3.one;
						if (!style.forceMonospace)
						{
							num3 += (float)num * ((float)num10 / pixelsPerUnit);
						}
						num6++;
						num8 = cp;
					}
				}
			}
			if (flag)
			{
				if (usedCharacterFromOtherLanguage && spriteRenderer != null)
				{
					currentWordNeededToReverse.Add(spriteRenderer);
				}
				if (!usedCharacterFromOtherLanguage || i == formattedString.Length - 1)
				{
					if (currentWordNeededToReverse.Count > 1)
					{
						List<Vector3> list3 = new List<Vector3>();
						foreach (SpriteRenderer item in currentWordNeededToReverse)
						{
							list3.Add(item.transform.position);
						}
						int index = currentWordNeededToReverse.Count - 1;
						Vector3 position = currentWordNeededToReverse[index].transform.position;
						for (int j = 0; j < currentWordNeededToReverse.Count; j++)
						{
							position += ((j > 0) ? (list3[j - 1] - list3[j]) : Vector3.zero);
							currentWordNeededToReverse[j].transform.position = position;
						}
					}
					currentWordNeededToReverse.Clear();
				}
			}
			if (pooledObj != null)
			{
				pooledObj.localCharacterEndPositions.Add(new Vector2(num3, num4));
			}
		}
		if (Mathf.Abs(num3) > num7)
		{
			num7 = Mathf.Abs(num3);
		}
		list.Add(num3);
		Rect dimensions = default(Rect);
		if (style.verticalAlignment == PugTextStyle.VerticalAlignment.center)
		{
			float num12 = 0f - RoundToPixelPerfectPosition.RoundFloat(num4 * 0.5f);
			foreach (Transform item2 in list2)
			{
				Vector3 localPosition = item2.localPosition;
				localPosition.y += num12;
				item2.localPosition = localPosition;
			}
		}
		else if (style.verticalAlignment == PugTextStyle.VerticalAlignment.bottom)
		{
			float num13 = 0f - RoundToPixelPerfectPosition.RoundFloat(num4);
			foreach (Transform item3 in list2)
			{
				Vector3 localPosition2 = item3.localPosition;
				localPosition2.y += num13;
				item3.localPosition = localPosition2;
			}
		}
		if (style.horizontalAlignment == PugTextStyle.HorizontalAlignment.left)
		{
			dimensions.xMin = 0f + num2;
			dimensions.xMax = num7 + num2;
		}
		if (style.horizontalAlignment == PugTextStyle.HorizontalAlignment.center)
		{
			dimensions.xMin = RoundToPixelPerfectPosition.RoundFloat((0f - num7) / 2f) + num2;
			dimensions.xMax = RoundToPixelPerfectPosition.RoundFloat(dimensions.xMin + num7) + num2;
			for (int k = 0; k < list2.Count; k++)
			{
				Transform transform4 = list2[k];
				float num14 = list[k];
				float x = RoundToPixelPerfectPosition.RoundFloat((0f - num7) * 0.5f + (num7 - num14) * 0.5f);
				transform4.GetComponentsInChildren(preallocSRs);
				foreach (SpriteRenderer preallocSR in preallocSRs)
				{
					preallocSR.transform.localPosition += new Vector3(x, 0f, 0f);
				}
			}
		}
		else if (style.horizontalAlignment == PugTextStyle.HorizontalAlignment.right)
		{
			dimensions.xMin = 0f - num7 + num2;
			dimensions.xMax = 0f + num2;
			for (int l = 0; l < list2.Count; l++)
			{
				Transform transform5 = list2[l];
				float num15 = list[l];
				transform5.GetComponentsInChildren(preallocSRs);
				foreach (SpriteRenderer preallocSR2 in preallocSRs)
				{
					preallocSR2.transform.localPosition += new Vector3(num2 - num15, 0f, 0f);
				}
			}
		}
		if (list2.Count > 0)
		{
			dimensions.yMax = list2[0].localPosition.y + (float)charDims.y / pixelsPerUnit / 2f;
			dimensions.yMin = list2[list2.Count - 1].localPosition.y - (float)charDims.y / pixelsPerUnit / 2f;
		}
		if (pooledObj != null)
		{
			pooledObj.dimensions = dimensions;
		}
		displayedTextStringLinesAmount = list.Count;
		list.Clear();
		list2.Clear();
		preallocSRs.Clear();
		return root;
	}

	public static string ApplyColorTag(string original, Color color)
	{
		int num = Mathf.RoundToInt(color.r * 255f);
		int num2 = Mathf.RoundToInt(color.g * 255f);
		int num3 = Mathf.RoundToInt(color.b * 255f);
		int num4 = Mathf.RoundToInt(color.a * 255f);
		StringBuilder stringBuilder = Manager.memory.preallocatedStringBuilder ?? new StringBuilder(5);
		stringBuilder.Clear();
		if (LocalizationManager.CurrentLanguage == "Thai")
		{
			stringBuilder.Append("<color=#");
			stringBuilder.Append($"{num:X2}{num2:X2}{num3:X2}{num4:X2}");
			stringBuilder.Append(">");
			stringBuilder.Append(original);
			stringBuilder.Append("</color>");
		}
		else
		{
			stringBuilder.Append("[#");
			stringBuilder.Append($"{num:X2}{num2:X2}{num3:X2}{num4:X2}");
			stringBuilder.Append("]");
			stringBuilder.Append(original);
			stringBuilder.Append("[/]");
		}
		return stringBuilder.ToString();
	}

	private static bool HasColorFromHexAtPosition(string text, int position, out string substring)
	{
		substring = null;
		if (position + 11 > text.Length)
		{
			return false;
		}
		substring = text.Substring(position, 11);
		if (!Regex.IsMatch(substring, "^\\[#([0-9A-Fa-f]{8})\\]$"))
		{
			return false;
		}
		return true;
	}

	private static bool TryGetColorFromHexAtPosition(string text, int position, out Color color)
	{
		color = Color.white;
		if (!HasColorFromHexAtPosition(text, position, out var substring))
		{
			return false;
		}
		string text2 = substring.Substring(2, 8);
		byte b = Convert.ToByte(text2.Substring(0, 2), 16);
		byte b2 = Convert.ToByte(text2.Substring(2, 2), 16);
		byte b3 = Convert.ToByte(text2.Substring(4, 2), 16);
		byte b4 = Convert.ToByte(text2.Substring(6, 2), 16);
		color = new Color((float)(int)b / 255f, (float)(int)b2 / 255f, (float)(int)b3 / 255f, (float)(int)b4 / 255f);
		return true;
	}

	private static bool IsEndOfColorCodeAtPosition(string text, int position)
	{
		if (position + 3 > text.Length)
		{
			return false;
		}
		return text.Substring(position, 3) == "[/]";
	}

	private string AddNewLinesToLinesExceedingMaxWidth(string text, float maxWidth, PugTextStyle style, bool usePauseSigns = false)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		float num4 = charSpacing + style.extraCharSpacing;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		float num8 = 0f;
		bool wrapAtComma = style.wrapAtComma;
		bool flag = false;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			switch (c)
			{
			case ' ':
			{
				float num9 = (float)(spaceWidth + style.extraSpaceWidth) / pixelsPerUnit;
				num += num9;
				num2 = 0f;
				num3 = i + 1;
				continue;
			}
			case '\n':
				num6 = 0;
				num = 0f;
				num2 = 0f;
				num3 = i + 1;
				continue;
			case '\r':
				continue;
			}
			if (usePauseSigns && (c == '`' || c == '*'))
			{
				continue;
			}
			if (flag && IsEndOfColorCodeAtPosition(text, i))
			{
				flag = false;
				i += 2;
				continue;
			}
			if (HasColorFromHexAtPosition(text, i, out var _))
			{
				flag = true;
				i += 10;
				continue;
			}
			GlyphData gd = null;
			int cp = 0;
			if (!GetGlyphData(c, out gd, style, out var _, out cp))
			{
				continue;
			}
			float num10 = 0f;
			if (num6 > 0)
			{
				num10 += num4 / pixelsPerUnit;
			}
			int num11 = gd.rect.width / 2;
			int num12 = gd.rect.width - num11;
			num10 += (float)num11 / pixelsPerUnit;
			if (enableKerning && num6 > 0)
			{
				byte[] kerning = glyphData[num5].kerning;
				if (kerning != null && kerning.Length != 0)
				{
					float num13 = (int)kerning[cp];
					if (num4 > Mathf.Epsilon)
					{
						num13 = Mathf.Round(num13 / num4 + 0.001f);
					}
					num10 -= num13 / pixelsPerUnit;
				}
			}
			if (!style.forceMonospace)
			{
				num10 += (float)num12 / pixelsPerUnit;
			}
			if (i > 1 && text[i - 1] == '-' && text[i - 2] != ' ')
			{
				num2 = num10;
				num3 = i;
			}
			else
			{
				num2 += num10;
			}
			num += num10;
			num6++;
			num5 = cp;
			num8 += num10;
			if (num > maxWidth)
			{
				if (num2 > maxWidth)
				{
					text = text.Insert(i, "\n");
					num = num10;
					num2 = num10;
					i++;
				}
				else
				{
					if (num7 != 0 && wrapAtComma)
					{
						text = ((text[num7 + 1] == ' ') ? text.Remove(num7 + 1, 1).Insert(num7 + 1, "\n") : text.Insert(num7 + 1, "\n"));
					}
					else
					{
						text = ((text[num3 - 1] == ' ') ? text.Remove(num3 - 1, 1).Insert(num3 - 1, "\n") : text.Insert(num3, "\n"));
						i++;
					}
					num = num2;
				}
				num3 = i;
				num6 = 0;
				num7 = 0;
				num8 = 0f;
			}
			if (c == ',')
			{
				num8 = 0f;
				num7 = i;
			}
		}
		return text;
	}

	private bool GetGlyphData(char c, out GlyphData gd, PugTextStyle style, out bool usedCharacterFromOtherLanguage, out int cp)
	{
		gd = null;
		usedCharacterFromOtherLanguage = false;
		cp = 0;
		if (codePoints.TryGetValue(c, out cp))
		{
			gd = glyphData[cp];
		}
		else
		{
			bool flag = false;
			if (Application.isPlaying)
			{
				PugFont font = Manager.text.GetFont(style.fontFace);
				PugFont chineseFont = Manager.text.GetChineseFont(style.fontFace);
				PugFont japaneseFont = Manager.text.GetJapaneseFont(style.fontFace);
				PugFont koreanFont = Manager.text.GetKoreanFont(style.fontFace);
				PugFont font2 = Manager.text.GetFont(TextManager.FontFace.button);
				if (font2.codePoints.TryGetValue(c, out cp))
				{
					usedCharacterFromOtherLanguage = true;
					gd = font2.glyphData[cp];
				}
				else if (font.codePoints.TryGetValue(c, out cp))
				{
					usedCharacterFromOtherLanguage = true;
					gd = font.glyphData[cp];
				}
				else if (chineseFont.codePoints.TryGetValue(c, out cp))
				{
					usedCharacterFromOtherLanguage = true;
					gd = chineseFont.glyphData[cp];
				}
				else if (japaneseFont.codePoints.TryGetValue(c, out cp))
				{
					usedCharacterFromOtherLanguage = true;
					gd = japaneseFont.glyphData[cp];
				}
				else if (koreanFont.codePoints.TryGetValue(c, out cp))
				{
					usedCharacterFromOtherLanguage = true;
					gd = koreanFont.glyphData[cp];
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				Debug.LogWarning($"Font {base.name} missing glyph u{(int)c:x4} '{c}'");
				try
				{
					cp = codePoints['?'];
					gd = glyphData[cp];
				}
				catch (KeyNotFoundException)
				{
					Debug.LogWarning(base.name + ": placeholder character not found.");
					return false;
				}
			}
		}
		return true;
	}
}
