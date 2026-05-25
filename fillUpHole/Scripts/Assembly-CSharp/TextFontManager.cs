using System;
using TMPro;
using UnityEngine;

public class TextFontManager : MonoBehaviour
{
	public TMP_FontAsset PixelFont;

	public TMP_FontAsset NormalFont;

	public static bool IsNormalFont;

	public static TextFontManager Instance;

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
			else if (force)
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
}
