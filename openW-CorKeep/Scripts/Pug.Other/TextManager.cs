using System;
using System.Collections.Generic;
using System.Globalization;
using I2.Loc;
using Pug.UnityExtensions;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class TextManager : ManagerBase
{
	public enum FontFace
	{
		thinTiny = 16777344,
		thinSmall = 16777232,
		boldSmall = 67108880,
		thinMedium = 16777264,
		boldMedium = 67108912,
		boldLarge = 67108896,
		boldHuge = 67108928,
		score = 201326624,
		button = 134217744
	}

	[Serializable]
	public struct CustomOffset
	{
		public string key;

		public Vector2 value;
	}

	[Serializable]
	public class DynamicFontInfo
	{
		public Font font;

		public TMP_FontAsset fontTMPro;

		public Font unicodeFont;

		public float size;

		public float characterSpacing;

		public float lineSpacing;

		public float ascenderPadding;

		public int minFontPxSize;

		public int maxFontPxSize;

		public float letterSpacing;

		public Material fontMaterial;

		public Material fontVisibleInsideMaskMaterial;

		public Material fontVisibleOutsideMaskMaterial;

		[SerializeField]
		private List<CustomOffset> m_customOffsets;

		private Dictionary<string, Vector2> m_customOffsetLookup;

		public Dictionary<string, Vector2> customOffsets
		{
			get
			{
				if (m_customOffsetLookup == null)
				{
					m_customOffsetLookup = new Dictionary<string, Vector2>();
					if (m_customOffsets != null)
					{
						for (int i = 0; i < m_customOffsets.Count; i++)
						{
							m_customOffsetLookup.Add(m_customOffsets[i].key, m_customOffsets[i].value);
						}
					}
				}
				return m_customOffsetLookup;
			}
		}
	}

	public class FontInfo
	{
		public PugFont pugFont;

		public DynamicFontInfo dynamicFontInfo;

		public bool hasPugFont => pugFont != null;

		public bool hasDynamicFont => dynamicFontInfo != null;
	}

	public const int kInitialGlyphPoolSize = 2048;

	public const int kInitialLinePoolSize = 256;

	public const int kMaxLinePoolSize = 2048;

	public const int kInitialCoolTextPoolSize = 64;

	public const int specialMask = 134217728;

	public const int boldMask = 67108864;

	public const int thinMask = 16777216;

	public const int tinySizeMask = 128;

	public const int smallSizeMask = 16;

	public const int mediumSizeMask = 48;

	public const int largeSizeMask = 32;

	public const int hugeSizeMask = 64;

	public DebugText debugText;

	[Header("Latin fonts")]
	public PugFont thinTiny;

	public PugFont thinSmall;

	public PugFont boldSmall;

	public PugFont thinMedium;

	public PugFont boldMedium;

	public PugFont boldLarge;

	public PugFont boldHuge;

	public PugFont specialBoldLarge;

	[Header("Japanese fonts")]
	public PugFont japaneseFont;

	[Header("Chinese (Simplified andTraditional) fonts")]
	public PugFont chineseFont;

	[Header("Korean fonts")]
	public PugFont koreanFont;

	[Header("Thai fonts")]
	public DynamicFontInfo thaiFontSmallDynamic;

	[Header("Button font")]
	public PugFont buttonFont;

	[Header("Master glyph prefab")]
	public SpriteRenderer glyphPrefab;

	[Header("Master cool text prefab")]
	public PugCoolText coolTextPrefab;

	[NonSerialized]
	public PoolSystem coolTextPool;

	[NonSerialized]
	public PoolSystem glyphPool;

	[NonSerialized]
	public PoolSystem containerPool;

	[NonSerialized]
	public List<SpriteRenderer> glyphsAwaitingFree = new List<SpriteRenderer>();

	[NonSerialized]
	public List<Transform> containersAwaitingFree = new List<Transform>();

	[NonSerialized]
	public readonly List<float> preallocLineWidths = new List<float>(64);

	[NonSerialized]
	public readonly List<Transform> preallocLines = new List<Transform>(64);

	public List<Sprite> pugNumbersUpTo9;

	public List<Color> rarityTextColors;

	[SerializeField]
	private List<Color> modeColors;

	public Color goodColor;

	public Color badColor;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("TextManager.Init");

	public Material defaultTextMaterial { get; private set; }

	public Color GetModeColor(int modeBits)
	{
		if ((modeBits & 1) != 0)
		{
			return modeColors[1];
		}
		if ((modeBits & 2) != 0)
		{
			return modeColors[2];
		}
		if ((modeBits & 4) != 0)
		{
			return modeColors[3];
		}
		return modeColors[0];
	}

	public Color GetRarityColor(Rarity rarity)
	{
		int num = (int)(rarity + 1);
		if (num < rarityTextColors.Count)
		{
			return Manager.text.rarityTextColors[num];
		}
		Debug.LogError("rarity " + rarity.ToString() + " int value is larger than rarityTextColors amount " + Manager.text.rarityTextColors.Count);
		return Color.white;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			Init2();
			defaultTextMaterial = glyphPrefab.sharedMaterial;
			Manager.prefs.language = ValidateLanguage(Manager.prefs.language);
			return true;
		}
	}

	public void SetLanguageCode(string value)
	{
		LocalizationManager.CurrentLanguageCode = value;
	}

	private string ValidateLanguage(string newLanguage)
	{
		if (LocalizationManager.HasLanguage(LocalizationManager.GetLanguageFromCode(newLanguage, exactMatch: false), AllowDiscartingRegion: false))
		{
			return newLanguage;
		}
		newLanguage = PlatformGlue_Language.GetSystemPreferredLanguage();
		if (!LocalizationManager.HasLanguage(LocalizationManager.GetLanguageFromCode(newLanguage, exactMatch: false), AllowDiscartingRegion: false))
		{
			string text = LocalizationManager.GetAllLanguagesCode()[0];
			Debug.LogWarning(newLanguage + " has been disabled or removed, resetting to " + text);
			newLanguage = text;
		}
		return newLanguage;
	}

	private void OnLocalizationUpdate(LanguageSourceData source, bool data, string msg)
	{
		PugText[] array = UnityEngine.Object.FindObjectsOfType<PugText>();
		foreach (PugText pugText in array)
		{
			if (pugText.localize && pugText.GetComponent<PugTextEffectEnunciateSyllables>() == null)
			{
				Color glyphsColor = pugText.GetGlyphsColor();
				pugText.Render(rewindEffectAnims: false);
				pugText.SetTempColor(glyphsColor);
			}
		}
		RadicalMenu[] array2 = UnityEngine.Object.FindObjectsOfType<RadicalMenu>();
		foreach (RadicalMenu radicalMenu in array2)
		{
			if (radicalMenu.shouldRenderDescendants)
			{
				radicalMenu.RenderUIComponent();
				radicalMenu.RenderUIComponentOrphans();
			}
		}
	}

	public void Init2(bool bypassPool = false)
	{
		thinTiny.InitCodePoints();
		thinSmall.InitCodePoints();
		boldSmall.InitCodePoints();
		thinMedium.InitCodePoints();
		boldMedium.InitCodePoints();
		boldLarge.InitCodePoints();
		boldHuge.InitCodePoints();
		specialBoldLarge.InitCodePoints();
		japaneseFont.InitCodePoints();
		chineseFont.InitCodePoints();
		koreanFont.InitCodePoints();
		buttonFont.InitCodePoints();
		if (!bypassPool)
		{
			glyphPool = new PoolSystem(glyphPrefab.gameObject, typeof(SpriteRenderer), base.transform, autoEnable: true, 2048, 10240, 2048, "TextGlyph");
			GameObject gameObject = new GameObject("PugTextLine");
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			gameObject.hideFlags = HideFlags.DontSave;
			gameObject.SetActive(value: false);
			containerPool = new PoolSystem(gameObject.transform.gameObject, typeof(Transform), base.transform, autoEnable: true, 256, 2048, 256, "TextLine");
			coolTextPool = new PoolSystem(coolTextPrefab.gameObject, typeof(PugCoolText), base.transform, autoEnable: true, 64, 256, 64, "CoolText");
		}
	}

	public void SpawnScoreText(int score, Vector3 initialWorldPosition, Color blinkColorBase)
	{
		Color white = Color.white;
		PugCoolText pugCoolText = SpawnCoolText(score.ToString("N0", CultureInfo.InvariantCulture), initialWorldPosition + new Vector3(0f, PugRandom.GenerateUniform(-0.25f, 0.25f), 0f), white, FontFace.thinTiny, -35f, 16f, 2.4f, 0.08f, 0.4f, 1.5f, 25f, 0.3f, 0.2f, 1f);
		if (pugCoolText != null)
		{
			pugCoolText._blinkColor = new Color(blinkColorBase.r, blinkColorBase.g, blinkColorBase.b, 0.35f);
		}
	}

	public void SpawnAchievementText(string text, Vector3 initialWorldPosition, Color blinkColorBase)
	{
		Color white = Color.white;
		PugCoolText pugCoolText = SpawnCoolText(text, initialWorldPosition, white, FontFace.boldLarge, -15f, 12f, 3.2f, 0.12f, 1.4f, 1.5f, 25f, 0.3f, 0.2f, 1f);
		if (pugCoolText != null)
		{
			pugCoolText._blinkColor = new Color(blinkColorBase.r, blinkColorBase.g, blinkColorBase.b, 0.35f);
		}
	}

	public PugCoolText SpawnCoolText(string text, Vector3 worldPosition, Color color, FontFace fontFace = FontFace.score, float gravity = 0f, float initialVelocity = 0f, float lifetime = -1f, float fadeInTime = 0f, float fadeOutTime = 0f, float bounceIntensity = 0f, float blinkFrequency = -1f, float blinkSmoothness = 0.25f, float minBlinkTransparency = 0.5f, float minVelocity = -100f, float maxVelocity = 100f)
	{
		PugCoolText freeComponent = coolTextPool.GetFreeComponent<PugCoolText>();
		if (freeComponent == null)
		{
			return null;
		}
		freeComponent.ResetAndPlay(text, worldPosition, color, fontFace, gravity, lifetime, fadeInTime, fadeOutTime, useUnscaledTime: false, activate: true, render: true, initialVelocity, bounceIntensity, blinkFrequency, blinkSmoothness, minBlinkTransparency, minVelocity, maxVelocity);
		return freeComponent;
	}

	public PugFont GetChineseFont(FontFace fontFace)
	{
		return chineseFont;
	}

	public PugFont GetJapaneseFont(FontFace fontFace)
	{
		return japaneseFont;
	}

	public PugFont GetKoreanFont(FontFace fontFace)
	{
		return koreanFont;
	}

	public DynamicFontInfo GetThaiUnicodeFont(FontFace fontFace)
	{
		if (fontFace <= FontFace.thinMedium)
		{
			if (fontFace != FontFace.thinSmall && fontFace != FontFace.thinMedium)
			{
				return thaiFontSmallDynamic;
			}
		}
		else if (fontFace != FontFace.thinTiny && fontFace != FontFace.boldSmall)
		{
			_ = 67108912;
		}
		return thaiFontSmallDynamic;
	}

	public PugFont GetFont(FontFace fontFace, bool forceLatin = false)
	{
		PugFont pugFont = null;
		if (fontFace == FontFace.button)
		{
			return buttonFont;
		}
		if (!forceLatin)
		{
			switch (Manager.prefs.language)
			{
			case "ja":
				return japaneseFont;
			case "zh-CN":
			case "zh-TW":
			case "cn":
				return chineseFont;
			case "ko":
				return koreanFont;
			}
		}
		switch (fontFace)
		{
		case FontFace.thinTiny:
			pugFont = thinTiny;
			break;
		case FontFace.thinSmall:
			pugFont = thinSmall;
			break;
		case FontFace.boldSmall:
			pugFont = boldSmall;
			break;
		case FontFace.thinMedium:
			pugFont = thinMedium;
			break;
		case FontFace.boldMedium:
			pugFont = boldMedium;
			break;
		case FontFace.boldLarge:
			pugFont = boldLarge;
			break;
		case FontFace.boldHuge:
			pugFont = boldHuge;
			break;
		case FontFace.score:
			pugFont = specialBoldLarge;
			break;
		}
		if (pugFont == null)
		{
			Debug.LogError("Unknown font face: " + fontFace);
		}
		return pugFont;
	}

	public DynamicFontInfo GetDynamicFont(FontFace fontFace, bool forceLatin = false)
	{
		if (fontFace == FontFace.button)
		{
			return null;
		}
		return thaiFontSmallDynamic;
	}

	public bool ShouldUseDynamicFont(FontFace fontFace, bool localize)
	{
		if (!localize)
		{
			return false;
		}
		bool flag = false;
		flag = Manager.prefs.language == "th";
		if (flag)
		{
			flag = GetDynamicFont(fontFace, !localize) != null;
		}
		return flag;
	}

	public FontInfo GetFontToUseForString(string value, FontFace fontFace)
	{
		FontInfo fontInfo = new FontInfo();
		int num = 0;
		int length = value.Length;
		PugFont font = GetFont(FontFace.button);
		int matches = GetMatches(value, font);
		if (matches > num)
		{
			num = matches;
			fontInfo = new FontInfo
			{
				pugFont = font,
				dynamicFontInfo = null
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		PugFont font2 = GetFont(fontFace);
		int matches2 = GetMatches(value, font2);
		if (matches2 > num)
		{
			num = matches2;
			fontInfo = new FontInfo
			{
				pugFont = font2,
				dynamicFontInfo = null
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		PugFont pugFont = GetChineseFont(fontFace);
		int matches3 = GetMatches(value, pugFont);
		if (matches3 > num)
		{
			num = matches3;
			fontInfo = new FontInfo
			{
				pugFont = pugFont,
				dynamicFontInfo = null
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		PugFont pugFont2 = GetJapaneseFont(fontFace);
		int matches4 = GetMatches(value, pugFont2);
		if (matches4 > num)
		{
			num = matches4;
			fontInfo = new FontInfo
			{
				pugFont = pugFont2,
				dynamicFontInfo = null
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		PugFont pugFont3 = GetKoreanFont(fontFace);
		int matches5 = GetMatches(value, pugFont3);
		if (matches5 > num)
		{
			num = matches5;
			fontInfo = new FontInfo
			{
				pugFont = pugFont3,
				dynamicFontInfo = null
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		DynamicFontInfo thaiUnicodeFont = GetThaiUnicodeFont(fontFace);
		int matches6 = GetMatches(value, thaiUnicodeFont.unicodeFont);
		if (matches6 > num)
		{
			num = matches6;
			fontInfo = new FontInfo
			{
				pugFont = null,
				dynamicFontInfo = thaiUnicodeFont
			};
			if (num == length)
			{
				return fontInfo;
			}
		}
		if (!fontInfo.hasPugFont && !fontInfo.hasDynamicFont)
		{
			fontInfo = new FontInfo
			{
				pugFont = font2,
				dynamicFontInfo = null
			};
		}
		return fontInfo;
	}

	private int GetMatches(string value, PugFont pugFont)
	{
		int num = 0;
		foreach (char c in value)
		{
			if (c != ' ' && c != '\n' && pugFont.codePoints.TryGetValue(c, out var _))
			{
				num++;
			}
		}
		return num;
	}

	private int GetMatches(string value, Font font)
	{
		int num = 0;
		foreach (char c in value)
		{
			if (c != ' ' && c != '\n' && font.GetCharacterInfo(c, out var _))
			{
				num++;
			}
		}
		return num;
	}

	private void LateUpdate()
	{
		base.transform.localPosition = -Manager.camera.RenderOrigo;
		foreach (SpriteRenderer item in glyphsAwaitingFree)
		{
			if (item != null)
			{
				glyphPool.Free(item);
			}
			else
			{
				Debug.LogWarning("Glyph was destroyed while waiting to be freed.");
			}
		}
		glyphsAwaitingFree.Clear();
		foreach (Transform item2 in containersAwaitingFree)
		{
			if (item2 != null)
			{
				containerPool.Free(item2);
			}
			else
			{
				Debug.LogWarning("Container was destroyed while waiting to be freed.");
			}
		}
		containersAwaitingFree.Clear();
	}

	public void OnSceneUnload()
	{
		coolTextPool.FreeAll();
	}
}
