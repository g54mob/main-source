using System.Collections.Generic;
using I2.Loc;
using Sirenix.OdinInspector;

public class FontMgr : SerializedMonoBehaviour
{
	public static FontMgr I;

	public LanguageSourceAsset LocSrc;

	[NamedArray(typeof(FontId))]
	public string[] FontKeys;

	[NamedArray(typeof(FontId))]
	public string[] OutlinedMatKeys;

	public FontSet FontSetEFIGS;

	public Dictionary<string, FontSet> FontSetsByLanguage;

	public List<string> Languages;

	private void Awake()
	{
	}

	public void RefreshFonts()
	{
	}

	private void ApplyFontSet(int languageIdx, FontSet curSet)
	{
	}

	private void OnLanguageChanged()
	{
	}

	public bool IsPixelFont(FontType t)
	{
		return false;
	}

	public bool IsHighResFont(FontType t)
	{
		return false;
	}

	public bool DoesSupportFontSwitching()
	{
		return false;
	}

	public bool IsPixelFont()
	{
		return false;
	}

	public float GetFontSizeMultiplier()
	{
		return 0f;
	}
}
