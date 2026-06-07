using System;
using TMPro;
using UnityEngine;

public class TextFontManager : MonoBehaviour
{
	public enum LanguageType
	{
		English = 0,
		Mandarin = 1
	}

	public TMP_FontAsset PixelFont;

	public TMP_FontAsset NormalFont;

	public TMP_FontAsset PixelChineseFont;

	public static bool IsNormalFont;

	public static TextFontManager Instance;

	private LanguageType _currentLanguage;

	public event Action OnFontChange;

	private void Awake()
	{
		Instance = this;
	}

	public static void UpdateFont(TMP_Text text, bool force = false)
	{
		if (Instance != null && text != null)
		{
			if (IsNormalFont)
			{
				text.font = Instance.NormalFont;
			}
			else if (Instance._currentLanguage == LanguageType.Mandarin)
			{
				text.font = Instance.PixelChineseFont;
			}
			else
			{
				text.font = Instance.PixelFont;
			}
		}
	}

	public static void UpdateFontType(bool isNormalFont)
	{
		if (Instance != null)
		{
			Instance.ChangeFontType(isNormalFont);
		}
	}

	public void ChangeFontType(bool isNormalFont)
	{
		if (IsNormalFont != isNormalFont)
		{
			IsNormalFont = isNormalFont;
			this.OnFontChange?.Invoke();
		}
	}

	public static LanguageType GetLanguage()
	{
		if (Instance != null)
		{
			return Instance._currentLanguage;
		}
		return LanguageType.English;
	}

	public static void UpdateLanguage(LanguageType language)
	{
		if (Instance != null)
		{
			Instance.ChangeLanguage(language);
		}
	}

	public void ChangeLanguage(LanguageType language)
	{
		if (_currentLanguage != language)
		{
			_currentLanguage = language;
			this.OnFontChange?.Invoke();
		}
	}
}
