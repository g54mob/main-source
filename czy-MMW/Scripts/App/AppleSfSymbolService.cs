using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;

public class AppleSfSymbolService : IControllerButtonToSymbolService
{
	private enum SymbolWeight
	{
		Ultralight = 0,
		Thin = 1,
		Light = 2,
		Regular = 3,
		Medium = 4,
		Semibold = 5,
		Bold = 6,
		Heavy = 7,
		Black = 8
	}

	private const int MaxSpriteCount = 10;

	private const string SpriteSymbolPrefix = "appleSfSymbol";

	private const int GlyphPointSize = 64;

	private const float GlyphSpriteScale = 1.25f;

	private Dictionary<string, Texture2D> _symbolNameToGlyphTexture;

	private TMP_SpriteAsset[] _customSpriteAssets;

	private bool _hasInitialized;

	private int _currentSpriteIndex;

	private readonly DefaultControllerButtonToSymbolService _defaultControllerButtonToSymbolService = new DefaultControllerButtonToSymbolService();

	public bool HasMappings => true;

	private void Initialize()
	{
		NCSetSymbolStyle(64f, 3, fill: false, forceSquare: false, 1f, 1f, 1f);
		_symbolNameToGlyphTexture = new Dictionary<string, Texture2D>();
		_customSpriteAssets = new TMP_SpriteAsset[10];
		string defaultSpriteAssetPath = TMP_Settings.defaultSpriteAssetPath;
		for (int i = 0; i < 10; i++)
		{
			_customSpriteAssets[i] = Resources.Load<TMP_SpriteAsset>(defaultSpriteAssetPath + "appleSfSymbol" + i);
		}
	}

	public string GetTextMeshProSymbolTextForControllerButton(ControllerButton buttonType)
	{
		if (!_hasInitialized)
		{
			Initialize();
			_hasInitialized = true;
		}
		string glyphSymbolName = GetGlyphSymbolName(buttonType);
		if (glyphSymbolName == null)
		{
			return _defaultControllerButtonToSymbolService.GetTextMeshProSymbolTextForControllerButton(buttonType);
		}
		Texture2D texture2D;
		if (!_symbolNameToGlyphTexture.ContainsKey(glyphSymbolName))
		{
			texture2D = GetGlyph(glyphSymbolName);
			if (texture2D == null)
			{
				return _defaultControllerButtonToSymbolService.GetTextMeshProSymbolTextForControllerButton(buttonType);
			}
			_symbolNameToGlyphTexture.Add(glyphSymbolName, texture2D);
		}
		else
		{
			texture2D = _symbolNameToGlyphTexture[glyphSymbolName];
		}
		TMP_SpriteAsset obj = _customSpriteAssets[_currentSpriteIndex];
		obj.material.mainTexture = texture2D;
		TMP_SpriteGlyph tMP_SpriteGlyph = obj.spriteGlyphTable[0];
		GlyphRect glyphRect = tMP_SpriteGlyph.glyphRect;
		GlyphMetrics metrics = tMP_SpriteGlyph.metrics;
		metrics.width = (float)glyphRect.width * ((float)texture2D.width / (float)texture2D.height);
		metrics.height = glyphRect.height;
		metrics.horizontalBearingX = 0f;
		metrics.horizontalAdvance = metrics.width;
		metrics.horizontalBearingY = 0.75f * metrics.height;
		_customSpriteAssets[_currentSpriteIndex].spriteGlyphTable[0].metrics = metrics;
		_customSpriteAssets[_currentSpriteIndex].spriteGlyphTable[0].scale = 1.25f;
		string result = "<sprite=\"appleSfSymbol" + _currentSpriteIndex + "\" name=\"glyph\" tint>";
		_currentSpriteIndex++;
		if (_currentSpriteIndex >= _customSpriteAssets.Length)
		{
			_currentSpriteIndex = 0;
		}
		return result;
	}

	private static string GetGlyphSymbolName(ControllerButton buttonType)
	{
		string text = NCGetGlyphSymbolNameForInput((int)buttonType);
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		return null;
	}

	public static Texture2D GetGlyph(string name)
	{
		long num = NCGenerateGlyphForSymbolName(name);
		if (num <= 0)
		{
			return null;
		}
		Texture2D texture2D = new Texture2D(1, 1, TextureFormat.RGBA32, mipChain: true);
		byte[] array = new byte[num];
		if (!NCGetGeneratedGlyph(array))
		{
			return null;
		}
		texture2D.LoadImage(array, markNonReadable: false);
		return texture2D;
	}

	private static void NCSetSymbolStyle(float pointSize, int weight, bool fill, bool forceSquare, float red, float green, float blue)
	{
	}

	public static string NCGetGlyphSymbolNameForInput(int buttonType)
	{
		return null;
	}

	public static long NCGenerateGlyphForSymbolName(string symbolName)
	{
		return -1L;
	}

	private static bool NCGetGeneratedGlyph(byte[] imgBuffer)
	{
		return false;
	}
}
