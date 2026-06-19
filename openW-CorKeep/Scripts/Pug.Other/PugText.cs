using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PugText : UIComponentMonoBehaviour, IManagedLateUpdate
{
	[Serializable]
	public class StyleOverride
	{
		public SystemLanguage language;

		public PugTextStyle style;
	}

	private class EdPreview
	{
		public PugFont loadedFont;

		public TextManager.FontFace loadedFontFace;

		public string language;
	}

	[NonSerialized]
	public PugFont font;

	private TextMeshPro dynamicText;

	private MeshRenderer dynamicTextMeshRenderer;

	private static int outlineColorShaderID = Shader.PropertyToID("_OutlineColor");

	private static int leftOutlineShaderID = Shader.PropertyToID("_LeftOutline");

	private static int rightOutlineShaderID = Shader.PropertyToID("_RightOutline");

	private static int topOutlineShaderID = Shader.PropertyToID("_TopOutline");

	private static int bottomOutlineShaderID = Shader.PropertyToID("_BottomOutline");

	public bool renderOnStart;

	public bool keepEnabledOnStart;

	public bool alwaysUpdateDynamicTextPixelPos;

	[Tooltip("If field is set by user input in any way then the text will attempt its best to find a suitable font depending on the characters")]
	public bool isWrittenToByUser;

	public bool checkForProfanity;

	public bool isHidden;

	public bool trackDynamicTextCharacterEndPositions;

	public bool localize;

	public bool topAligned;

	private bool _needsProfanityCheck;

	public List<SystemLanguage> languagesToForceLatinFont;

	public bool localizePlaceholders = true;

	public bool dontResetEffectsOnRender;

	public bool hideInStreamerMode;

	public float maxWidth;

	[Multiline]
	[SerializeField]
	private string textString = "Core Keeper";

	public string textSuffix = "";

	public string[] formatFields = new string[0];

	[NonSerialized]
	public string displayedTextString = "";

	[NonSerialized]
	public int displayedTextStringLinesAmount;

	public Material overrideMaterial;

	public string offsetKey;

	public PugTextStyle style = new PugTextStyle();

	private PugTextStyle defaultStyle;

	private Material _sharedGlyphMaterial;

	private static TMP_SpriteAsset _spriteFontAsset;

	public List<StyleOverride> styleOverrides;

	[NonSerialized]
	public Rect dimensions;

	[NonSerialized]
	public List<SpriteRenderer> glyphs = new List<SpriteRenderer>();

	[NonSerialized]
	public List<Transform> glyphTransforms = new List<Transform>();

	[NonSerialized]
	public List<bool> glyphColorOverrides = new List<bool>();

	[NonSerialized]
	public List<Transform> pooledTransforms = new List<Transform>();

	[NonSerialized]
	public List<Vector3> localPositionBackups = new List<Vector3>();

	[NonSerialized]
	public List<Vector2> localCharacterEndPositions = new List<Vector2>();

	private PugTextEffect[] effects;

	public bool usePooledResources = true;

	private Transform nonpooledResourceRoot;

	[FormerlySerializedAs("addPostDisableSentinel")]
	public bool freeResourcesOnDisable;

	private bool usePauseSigns;

	private bool hasCalledAwake;

	private bool startCalled;

	private TextManager.DynamicFontInfo m_dynamicFontInfo;

	private bool _keepColorOnStart;

	private string prevLanguage;

	private string[] prevFormatFields;

	private int prevOrderInLayer;

	private float prevMaxWidth;

	private const string DYNAMIC_TEXT_NAME = "DynamicText";

	private static readonly Dictionary<PugText, EdPreview> _previews = new Dictionary<PugText, EdPreview>();

	private const string dynamicVersionBase = "<sprite=\"buttonfont_new\" name={0}>";

	public Color color
	{
		get
		{
			return style.color;
		}
		set
		{
			SetTempColor(value);
		}
	}

	public Color tmpColor { get; private set; }

	public bool isUsingDynamicText { get; private set; }

	public bool ShouldForceLatinFont()
	{
		foreach (SystemLanguage item in languagesToForceLatinFont)
		{
			if (LocalizationManager.GetLanguageFromCode(Manager.prefs.language) == item.ToString())
			{
				return true;
			}
		}
		return false;
	}

	public void SetText(string text)
	{
		_needsProfanityCheck = checkForProfanity && text != null && text.Length > 0 && textString != text;
		textString = text;
	}

	public string GetText()
	{
		return textString;
	}

	public int GetTextLength()
	{
		return textString?.Length ?? 0;
	}

	public void SetDefaultFont(TextManager.FontFace fontFace)
	{
		defaultStyle.fontFace = fontFace;
	}

	private void UpdateStyleOverrides()
	{
		bool flag = false;
		if (styleOverrides != null)
		{
			foreach (StyleOverride styleOverride in styleOverrides)
			{
				if (LocalizationManager.GetLanguageFromCode(Manager.prefs.language) == styleOverride.language.ToString())
				{
					style = styleOverride.style.GetCopy();
					flag = true;
					break;
				}
			}
		}
		if (LocalizationManager.IsRight2Left && defaultStyle.invertHorizontalAlignment)
		{
			if (defaultStyle.horizontalAlignment == PugTextStyle.HorizontalAlignment.left)
			{
				style.horizontalAlignment = PugTextStyle.HorizontalAlignment.right;
			}
			else if (defaultStyle.horizontalAlignment == PugTextStyle.HorizontalAlignment.right)
			{
				style.horizontalAlignment = PugTextStyle.HorizontalAlignment.left;
			}
		}
	}

	public bool TryGetGlyph(int index, out SpriteRenderer glyph)
	{
		if (Hint.Unlikely(index < 0 || index >= glyphs.Count))
		{
			glyph = null;
			return false;
		}
		glyph = glyphs[index];
		return true;
	}

	protected virtual void Awake()
	{
		if (!hasCalledAwake)
		{
			usePauseSigns = GetComponent<PugTextEffectEnunciateSyllables>() != null;
			defaultStyle = style.GetCopy();
			effects = GetComponents<PugTextEffect>();
			hasCalledAwake = true;
		}
	}

	private void Start()
	{
		if (!renderOnStart)
		{
			if (!keepEnabledOnStart)
			{
				base.gameObject.SetActive(value: false);
			}
			return;
		}
		Render();
		if (_keepColorOnStart)
		{
			SetTempColor(tmpColor);
		}
		startCalled = true;
	}

	private void OnDestroy()
	{
		if (_sharedGlyphMaterial != null)
		{
			UnityEngine.Object.Destroy(_sharedGlyphMaterial);
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (renderOnStart && startCalled && !HasCorrectGlyphs(textString))
		{
			Render();
		}
		RefreshDynamicFontMaterial();
		if (Application.isPlaying)
		{
			Manager.update.AddToLateUpdate(this);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (Application.isPlaying)
		{
			Manager.update.RemoveFromLateUpdate(this);
		}
		if (freeResourcesOnDisable)
		{
			Manager.text.glyphsAwaitingFree.AddRange(glyphs);
			glyphs.Clear();
			glyphTransforms.Clear();
			glyphColorOverrides.Clear();
			Manager.text.containersAwaitingFree.AddRange(pooledTransforms);
			pooledTransforms.Clear();
		}
	}

	public void DisableAutoInactivationOnStart()
	{
		keepEnabledOnStart = true;
	}

	public void ManagedLateUpdate()
	{
		if (effects != null && effects.Length != 0)
		{
			for (int i = 0; i < glyphTransforms.Count; i++)
			{
				Transform obj = glyphTransforms[i];
				obj.localPosition = localPositionBackups[i];
				obj.localRotation = Quaternion.identity;
				obj.localScale = Vector3.one;
			}
		}
		PugTextEffect[] array = effects;
		foreach (PugTextEffect pugTextEffect in array)
		{
			if (pugTextEffect.enabled)
			{
				pugTextEffect.PugTextEffectLateUpdate();
			}
		}
		if (alwaysUpdateDynamicTextPixelPos && isUsingDynamicText && dynamicText != null)
		{
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = Vector3.one;
			if (dynamicText.transform.localPosition.sqrMagnitude > 0.5f)
			{
				dynamicText.transform.localPosition = Vector3.zero;
			}
			base.transform.localScale = localScale;
		}
	}

	public void SetFont(TextManager.FontFace newFontFace)
	{
		if (!hasCalledAwake)
		{
			Awake();
		}
		if (isWrittenToByUser)
		{
			TextManager.FontInfo fontToUseForString = Manager.text.GetFontToUseForString(textString, newFontFace);
			if (fontToUseForString.hasPugFont)
			{
				SetPugFont(newFontFace, fontToUseForString.pugFont);
			}
			else
			{
				SetDynamicFont(fontToUseForString.dynamicFontInfo);
			}
		}
		else if (!ShouldForceLatinFont() && Manager.text.ShouldUseDynamicFont(newFontFace, localize))
		{
			TextManager.DynamicFontInfo dynamicFont = Manager.text.GetDynamicFont(style.fontFace);
			if (dynamicFont != null)
			{
				SetDynamicFont(dynamicFont);
			}
		}
		else
		{
			SetPugFont(newFontFace, Manager.text.GetFont(style.fontFace, !localize || ShouldForceLatinFont()));
		}
	}

	private void SetPugFont(TextManager.FontFace newFontFace, PugFont fontToUse)
	{
		isUsingDynamicText = false;
		style.fontFace = newFontFace;
		defaultStyle.fontFace = newFontFace;
		font = fontToUse;
	}

	private void SetDynamicFont(TextManager.DynamicFontInfo dynamicFont)
	{
		m_dynamicFontInfo = dynamicFont;
		if (dynamicText == null)
		{
			SetUpDynamicText();
		}
		isUsingDynamicText = true;
		dynamicText.font = dynamicFont.fontTMPro;
		dynamicText.fontSize = dynamicFont.fontTMPro.faceInfo.pointSize / 16f;
		dynamicText.lineSpacing = dynamicFont.lineSpacing;
		dynamicText.characterSpacing = dynamicFont.characterSpacing;
		dynamicText.lineSpacing = dynamicFont.lineSpacing;
		switch (style.maskInteraction)
		{
		case SpriteMaskInteraction.VisibleInsideMask:
			dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontVisibleInsideMaskMaterial;
			break;
		case SpriteMaskInteraction.VisibleOutsideMask:
			dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontVisibleOutsideMaskMaterial;
			break;
		case SpriteMaskInteraction.None:
			dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontMaterial;
			break;
		}
	}

	private void RefreshDynamicFontMaterial()
	{
		if (isUsingDynamicText && style != null)
		{
			TextManager.DynamicFontInfo dynamicFont = Manager.text.GetDynamicFont(style.fontFace, !localize);
			switch (style.maskInteraction)
			{
			case SpriteMaskInteraction.VisibleInsideMask:
				dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontVisibleInsideMaskMaterial;
				break;
			case SpriteMaskInteraction.VisibleOutsideMask:
				dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontVisibleOutsideMaskMaterial;
				break;
			case SpriteMaskInteraction.None:
				dynamicTextMeshRenderer.sharedMaterial = dynamicFont.fontMaterial;
				break;
			}
		}
	}

	public void SetOrderInLayer(int orderInLayer)
	{
		style.orderInLayer = orderInLayer;
		defaultStyle.orderInLayer = orderInLayer;
	}

	public void SetTempColor(Color color, bool keepColorOnStart = false)
	{
		_keepColorOnStart = keepColorOnStart;
		tmpColor = color;
		if (isUsingDynamicText)
		{
			dynamicText.color = color;
		}
		else
		{
			if (GetGlyphsColor() == color)
			{
				return;
			}
			for (int i = 0; i < glyphs.Count; i++)
			{
				SpriteRenderer spriteRenderer = glyphs[i];
				if (!style.supportColorTags || glyphColorOverrides.Count <= i || !glyphColorOverrides[i])
				{
					spriteRenderer.color = color;
				}
			}
		}
	}

	public void SetOutlineColor(Color color)
	{
		TryInitSharedGlyphMaterial();
		AssignSharedGlyphMaterial();
		style.outlineColor = color;
		UpdateOutlineColor();
	}

	public void SetOutlines(bool left, bool right, bool top, bool bottom)
	{
		TryInitSharedGlyphMaterial();
		AssignSharedGlyphMaterial();
		if (left)
		{
			style.outline |= PugTextStyle.Outline.left;
		}
		if (right)
		{
			style.outline |= PugTextStyle.Outline.right;
		}
		if (top)
		{
			style.outline |= PugTextStyle.Outline.top;
		}
		if (bottom)
		{
			style.outline |= PugTextStyle.Outline.bottom;
		}
		UpdateOutlineSides();
	}

	private void UpdateOutline()
	{
		if (style.UsesOutlines)
		{
			TryInitSharedGlyphMaterial();
			AssignSharedGlyphMaterial();
			UpdateOutlineColor();
			UpdateOutlineSides();
		}
	}

	private bool TryInitSharedGlyphMaterial()
	{
		if (_sharedGlyphMaterial != null)
		{
			return false;
		}
		Material source = ((overrideMaterial != null) ? overrideMaterial : Manager.text.defaultTextMaterial);
		_sharedGlyphMaterial = new Material(source);
		return true;
	}

	private void AssignSharedGlyphMaterial()
	{
		foreach (SpriteRenderer glyph in glyphs)
		{
			glyph.sharedMaterial = _sharedGlyphMaterial;
		}
	}

	private void UpdateOutlineColor()
	{
		foreach (SpriteRenderer glyph in glyphs)
		{
			glyph.sharedMaterial.SetVector(outlineColorShaderID, style.outlineColor);
		}
	}

	private void UpdateOutlineSides()
	{
		foreach (SpriteRenderer glyph in glyphs)
		{
			glyph.sharedMaterial.SetFloat(leftOutlineShaderID, style.outline.HasFlag(PugTextStyle.Outline.left) ? 1f : 0f);
			glyph.sharedMaterial.SetFloat(rightOutlineShaderID, style.outline.HasFlag(PugTextStyle.Outline.right) ? 1f : 0f);
			glyph.sharedMaterial.SetFloat(topOutlineShaderID, style.outline.HasFlag(PugTextStyle.Outline.top) ? 1f : 0f);
			glyph.sharedMaterial.SetFloat(bottomOutlineShaderID, style.outline.HasFlag(PugTextStyle.Outline.bottom) ? 1f : 0f);
		}
	}

	public Color GetGlyphsColor()
	{
		if (glyphs.Count > 0)
		{
			return glyphs[0].color;
		}
		return color;
	}

	public string ProcessText()
	{
		return ProcessText(textString, formatFields, localize, localizePlaceholders, hideInStreamerMode, style.capitalization, isHidden, textSuffix);
	}

	public string ProcessText(string str)
	{
		return ProcessText(str, formatFields, localize, localizePlaceholders, hideInStreamerMode, style.capitalization, isHidden, textSuffix);
	}

	public static string ProcessText(string str, string[] optionalFormatFields, bool shouldLocalize, bool shouldLocalizeFormatFields, bool shouldHideInStreamerMode = false, PugTextStyle.Capitalization capitalization = PugTextStyle.Capitalization.normal, bool isHidden = false, string suffix = null)
	{
		if (shouldHideInStreamerMode && isHidden)
		{
			return new string('*', str.Length);
		}
		if (shouldLocalize)
		{
			string text = "";
			if (Application.isPlaying)
			{
				text = LocalizationManager.GetTranslation(str);
			}
			str = ((text != null) ? text : ("missing: " + str));
		}
		if (optionalFormatFields != null && optionalFormatFields.Length != 0)
		{
			string[] array;
			if (shouldLocalizeFormatFields)
			{
				array = new string[optionalFormatFields.Length];
				for (int i = 0; i < optionalFormatFields.Length; i++)
				{
					string translation = LocalizationManager.GetTranslation(optionalFormatFields[i]);
					array[i] = ((translation != null) ? translation : "<missing>");
				}
			}
			else
			{
				array = optionalFormatFields;
			}
			try
			{
				string format = str;
				object[] args = array;
				str = string.Format(format, args);
			}
			catch (FormatException message)
			{
				Debug.LogWarning(message);
			}
		}
		switch (capitalization)
		{
		case PugTextStyle.Capitalization.lowercase:
			str = str.ToLower();
			break;
		case PugTextStyle.Capitalization.uppercase:
			str = str.ToUpper();
			break;
		}
		if (!string.IsNullOrWhiteSpace(suffix))
		{
			str += suffix;
		}
		return str;
	}

	private bool FormatFieldsAreDifferent()
	{
		if (prevFormatFields != null)
		{
			if (formatFields == null)
			{
				return true;
			}
			if (prevFormatFields.Length != formatFields.Length)
			{
				return true;
			}
			for (int i = 0; i < prevFormatFields.Length; i++)
			{
				if (prevFormatFields[i] != formatFields[i])
				{
					return true;
				}
			}
		}
		else if (formatFields != null)
		{
			return true;
		}
		return false;
	}

	public void Render(string text, bool rewindEffectAnims = false, bool force = false, bool activate = true)
	{
		if (!HasCorrectGlyphs(text) || rewindEffectAnims || force)
		{
			SetText(text);
			Render(rewindEffectAnims, activate);
		}
	}

	private bool HasCorrectGlyphs(string text)
	{
		if (prevLanguage == Manager.prefs.language && textString == text && !FormatFieldsAreDifferent() && prevOrderInLayer == style.orderInLayer && Math.Abs(prevMaxWidth - maxWidth) < Mathf.Epsilon)
		{
			return glyphs.Count > 0;
		}
		return false;
	}

	public void Render(bool rewindEffectAnims = true, bool activate = true)
	{
		prevOrderInLayer = style.orderInLayer;
		prevLanguage = Manager.prefs.language;
		prevMaxWidth = maxWidth;
		if (formatFields == null)
		{
			prevFormatFields = null;
		}
		else
		{
			if (prevFormatFields == null || prevFormatFields.Length != formatFields.Length)
			{
				prevFormatFields = new string[formatFields.Length];
			}
			formatFields.CopyTo(prevFormatFields, 0);
		}
		if (!hasCalledAwake)
		{
			Awake();
		}
		Clear(temporaryClear: true);
		if (dynamicText != null)
		{
			dynamicText.text = null;
		}
		UpdateStyleOverrides();
		SetFont(style.fontFace);
		if (string.IsNullOrEmpty(textString))
		{
			dimensions = Rect.zero;
			return;
		}
		displayedTextString = ProcessText();
		MarkUIComponentAsDirty();
		if (checkForProfanity && _needsProfanityCheck && !Manager.networking.OfflineSession)
		{
			_needsProfanityCheck = false;
			ParentalControlManager parentalControlManager = Manager.platform.parentalControlManager;
			if (parentalControlManager != null)
			{
				bool gotResult = false;
				parentalControlManager.RestrictInput(displayedTextString, delegate(string result)
				{
					gotResult = true;
					Clear(temporaryClear: true);
					displayedTextString = result;
					OnProfanityChecked(rewindEffectAnims, activate);
				});
				if (!gotResult)
				{
					displayedTextString = "...";
					OnProfanityChecked(rewindEffectAnims, activate);
				}
				return;
			}
		}
		OnProfanityChecked(rewindEffectAnims, activate);
	}

	private void OnProfanityChecked(bool rewindEffectAnims, bool activate)
	{
		if (isUsingDynamicText)
		{
			RenderDynamicText();
		}
		else if (usePooledResources)
		{
			font.Render(displayedTextString, this, style, null, Manager.text, localize, out displayedTextString, out displayedTextStringLinesAmount, maxWidth, usePauseSigns, overrideMaterial);
		}
		else
		{
			if (nonpooledResourceRoot != null)
			{
				UnityEngine.Object.Destroy(nonpooledResourceRoot.gameObject);
			}
			nonpooledResourceRoot = new GameObject("Non-pooled resources").transform;
			nonpooledResourceRoot.parent = base.transform;
			nonpooledResourceRoot.localPosition = Vector3.zero;
			font.Render(displayedTextString, null, style, nonpooledResourceRoot.transform, null, localize, out displayedTextString, out displayedTextStringLinesAmount, maxWidth, usePauseSigns, overrideMaterial);
		}
		if (activate && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
		localPositionBackups.Clear();
		for (int i = 0; i < glyphs.Count; i++)
		{
			localPositionBackups.Add(glyphs[i].transform.localPosition);
		}
		if (!dontResetEffectsOnRender)
		{
			ResetEffects(rewindEffectAnims);
		}
		UpdateOutline();
	}

	public void ResetEffects(bool rewind = true)
	{
		if (effects != null)
		{
			PugTextEffect[] array = effects;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ResetEffect(rewind);
			}
		}
	}

	public void Clear(bool temporaryClear = false, bool bypassSetActive = false)
	{
		TextManager text = Manager.text;
		foreach (Transform pooledTransform in pooledTransforms)
		{
			text.containerPool.Free(pooledTransform.gameObject);
		}
		pooledTransforms.Clear();
		foreach (SpriteRenderer glyph in glyphs)
		{
			text.glyphPool.Free(glyph.gameObject);
		}
		glyphs.Clear();
		glyphTransforms.Clear();
		glyphColorOverrides.Clear();
		displayedTextString = "";
		if (!temporaryClear)
		{
			ResetEffects();
			if (!bypassSetActive)
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private Vector2 GetPivot(TextAnchor anchor)
	{
		float num = 0.5f;
		return anchor switch
		{
			TextAnchor.UpperCenter => new Vector2(num, 1f), 
			TextAnchor.UpperRight => new Vector2(1f, 1f), 
			TextAnchor.MiddleLeft => new Vector2(0f, num), 
			TextAnchor.MiddleCenter => new Vector2(num, num), 
			TextAnchor.MiddleRight => new Vector2(1f, num), 
			TextAnchor.LowerLeft => new Vector2(0f, 0f), 
			TextAnchor.LowerCenter => new Vector2(num, 0f), 
			TextAnchor.LowerRight => new Vector2(1f, 0f), 
			_ => new Vector2(0f, 1f), 
		};
	}

	private void SetUpDynamicText()
	{
		if (!(dynamicText != null))
		{
			GameObject gameObject = new GameObject("DynamicText");
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.layer = base.gameObject.layer;
			dynamicText = gameObject.AddComponent<TextMeshPro>();
			(dynamicText.transform as RectTransform).pivot = GetPivot(GetDynamicTextAnchor());
			dynamicText.alignment = GetDynamicTextAlignment();
			dynamicText.isOrthographic = true;
			dynamicText.margin = new Vector4(0f, 0f, 0f, (0f - m_dynamicFontInfo.ascenderPadding) * 0.0625f);
			dynamicText.text = null;
			dynamicTextMeshRenderer = gameObject.GetComponent<MeshRenderer>();
		}
	}

	private void RenderDynamicText()
	{
		RectTransform rectTransform = dynamicText.transform as RectTransform;
		rectTransform.localScale = Vector3.one;
		rectTransform.localPosition = Vector3.zero;
		DrawDynamicDisplayedString();
		dynamicTextMeshRenderer.sortingLayerID = ((style.sortingLayer == int.MinValue) ? SortingLayer.NameToID("GUI") : style.sortingLayer);
		dynamicTextMeshRenderer.sortingOrder = style.orderInLayer;
		rectTransform.pivot = new Vector2(GetPivot(GetDynamicTextAnchor()).x, 0.5f);
		Vector2 sizeDelta = rectTransform.sizeDelta;
		sizeDelta.x = ((maxWidth > Mathf.Epsilon) ? maxWidth : 10000f);
		rectTransform.sizeDelta = sizeDelta;
		dynamicText.alignment = GetDynamicTextAlignment();
		dynamicText.enableWordWrapping = maxWidth > Mathf.Epsilon;
		dynamicText.ForceMeshUpdate(ignoreActiveState: true);
		displayedTextStringLinesAmount = ((dynamicText.textInfo == null) ? 1 : dynamicText.textInfo.lineCount);
		PugTextStyle.VerticalAlignment verticalAlignment = ((displayedTextStringLinesAmount <= 1) ? PugTextStyle.VerticalAlignment.center : style.verticalAlignment);
		Bounds textBounds = dynamicText.textBounds;
		textBounds.max += Vector3.up * m_dynamicFontInfo.ascenderPadding * 0.0625f;
		float num = (dynamicText.font.faceInfo.pointSize + m_dynamicFontInfo.ascenderPadding / 2f) / 2f;
		Vector3 zero = Vector3.zero;
		switch (verticalAlignment)
		{
		case PugTextStyle.VerticalAlignment.top:
			zero.y -= textBounds.size.y / 2f;
			zero.y += num * 0.0625f;
			break;
		case PugTextStyle.VerticalAlignment.bottom:
			zero.y += textBounds.size.y / 2f;
			zero.y -= num * 0.0625f;
			break;
		}
		rectTransform.localPosition += zero;
		textBounds.center += zero;
		if (!string.IsNullOrEmpty(offsetKey) && m_dynamicFontInfo.customOffsets.TryGetValue(offsetKey, out var value))
		{
			dynamicText.transform.localPosition += new Vector3(value.x, value.y, 0f) * 0.0625f;
		}
		dimensions = new Rect(textBounds.center - textBounds.size / 2f, textBounds.size);
		if (trackDynamicTextCharacterEndPositions)
		{
			localCharacterEndPositions.Clear();
			float num2 = 0f;
			for (int i = 0; i < displayedTextString.Length; i++)
			{
				TMP_TextInfo textInfo = dynamicText.GetTextInfo(displayedTextString.Substring(0, i + 1));
				if (textInfo.characterCount > 0)
				{
					float x = textInfo.characterInfo[textInfo.characterCount - 1].bottomRight.x - textInfo.characterInfo[0].bottomLeft.x;
					float y = textInfo.characterInfo[textInfo.characterCount - 1].bottomRight.y;
					if (num2 > y)
					{
						num2 = y;
					}
					float y2 = num2 - textInfo.characterInfo[0].bottomRight.y;
					localCharacterEndPositions.Add(new Vector2(x, y2));
				}
			}
		}
		dynamicText.color = color;
	}

	private void DrawDynamicDisplayedString()
	{
		if (usePauseSigns)
		{
			displayedTextString = displayedTextString.Replace("*", "");
			displayedTextString = displayedTextString.Replace("'", "");
		}
		dynamicText.text = displayedTextString;
	}

	private TextAnchor GetDynamicTextAnchor()
	{
		return style.horizontalAlignment switch
		{
			PugTextStyle.HorizontalAlignment.center => style.verticalAlignment switch
			{
				PugTextStyle.VerticalAlignment.center => TextAnchor.MiddleCenter, 
				PugTextStyle.VerticalAlignment.top => TextAnchor.UpperCenter, 
				PugTextStyle.VerticalAlignment.bottom => TextAnchor.LowerCenter, 
				_ => TextAnchor.MiddleCenter, 
			}, 
			PugTextStyle.HorizontalAlignment.left => style.verticalAlignment switch
			{
				PugTextStyle.VerticalAlignment.center => TextAnchor.MiddleLeft, 
				PugTextStyle.VerticalAlignment.top => TextAnchor.UpperLeft, 
				PugTextStyle.VerticalAlignment.bottom => TextAnchor.LowerLeft, 
				_ => TextAnchor.MiddleLeft, 
			}, 
			PugTextStyle.HorizontalAlignment.right => style.verticalAlignment switch
			{
				PugTextStyle.VerticalAlignment.center => TextAnchor.MiddleRight, 
				PugTextStyle.VerticalAlignment.top => TextAnchor.UpperRight, 
				PugTextStyle.VerticalAlignment.bottom => TextAnchor.LowerRight, 
				_ => TextAnchor.MiddleRight, 
			}, 
			_ => TextAnchor.MiddleCenter, 
		};
	}

	private TextAlignmentOptions GetDynamicTextAlignment()
	{
		return style.horizontalAlignment switch
		{
			PugTextStyle.HorizontalAlignment.center => TextAlignmentOptions.Center, 
			PugTextStyle.HorizontalAlignment.left => TextAlignmentOptions.Left, 
			PugTextStyle.HorizontalAlignment.right => TextAlignmentOptions.Right, 
			_ => TextAlignmentOptions.Center, 
		};
	}

	public static void RenderEditorPreview(PugText pugText, bool hasChanged)
	{
		if (Application.isPlaying)
		{
			pugText.Render(rewindEffectAnims: true, activate: false);
		}
	}

	private static void EditorClear(PugText pugText)
	{
		foreach (Transform item in pugText.transform)
		{
			UnityEngine.Object.DestroyImmediate(item.gameObject);
		}
	}

	public override void RenderUIComponent(bool force = false)
	{
		if (Dirty || force)
		{
			base.RenderUIComponent(force);
			RenderEditorPreview(this, hasChanged: true);
		}
	}

	public override float GetUIComponentRenderWidth()
	{
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>();
		float num = 0f;
		SpriteRenderer[] array = componentsInChildren;
		foreach (SpriteRenderer spriteRenderer in array)
		{
			float val = (spriteRenderer.transform.localPosition.x + spriteRenderer.sprite.bounds.size.x / 2f) * base.transform.localScale.x;
			num = Math.Max(num, val);
		}
		return num;
	}

	public override float GetUIComponentRenderHeight()
	{
		SpriteRenderer[] componentsInChildren = GetComponentsInChildren<SpriteRenderer>();
		float y = 0f;
		if (Application.isPlaying && LocalizationManager.CurrentLanguage == "Thai")
		{
			y = 0.9f * (float)displayedTextStringLinesAmount;
		}
		Transform transform = base.transform;
		float num = transform.position.y;
		float num2 = num;
		SpriteRenderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Bounds bounds = array[i].bounds;
			num = math.min(num, bounds.center.y - bounds.size.y / 2f);
			num2 = math.max(num2, bounds.center.y + bounds.size.y / 2f);
		}
		return math.max((num2 - num) * transform.localScale.y, y);
	}

	public override PivotPosition GetUIComponentPivotPosition()
	{
		return PivotPosition.MiddleLeft;
	}

	public static string GetButtonStringForThai(string buttonCharacter)
	{
		if (LocalizationManager.CurrentLanguage == "Thai")
		{
			if (buttonCharacter == null || buttonCharacter.Length != 1)
			{
				return buttonCharacter;
			}
			if (_spriteFontAsset == null)
			{
				_spriteFontAsset = Resources.Load<TMP_SpriteAsset>("Sprite Assets/buttonfont_new");
			}
			if (_spriteFontAsset.GetSpriteIndexFromName(buttonCharacter) == -1)
			{
				return buttonCharacter;
			}
			return $"<sprite=\"buttonfont_new\" name={buttonCharacter}>";
		}
		return buttonCharacter;
	}
}
