using TMPro;

namespace I2.Loc
{
	internal class LocalizeTextMeshProFontSize : ILocalizeFontSizeBehaviour
	{
		private TMP_Text _textMeshPro;

		private float _originalFontSize;

		private float _originalFontSizeMin;

		private float _originalFontSizeMax;

		public LocalizeTextMeshProFontSize(TMP_Text textMeshPro)
		{
			_textMeshPro = textMeshPro;
			_originalFontSize = textMeshPro.fontSize;
			_originalFontSizeMin = textMeshPro.fontSizeMin;
			_originalFontSizeMax = textMeshPro.fontSizeMax;
		}

		public void ApplyOverride(LocalizeFontSize.Override fontSizeOverride)
		{
			if (_textMeshPro.enableAutoSizing)
			{
				_textMeshPro.fontSizeMin = fontSizeOverride.fontSizeMin;
				_textMeshPro.fontSizeMax = fontSizeOverride.fontSizeMax;
			}
			else
			{
				_textMeshPro.fontSize = fontSizeOverride.fontSize;
			}
		}

		public void Restore()
		{
			if (_textMeshPro.enableAutoSizing)
			{
				_textMeshPro.fontSizeMin = _originalFontSizeMin;
				_textMeshPro.fontSizeMax = _originalFontSizeMax;
			}
			else
			{
				_textMeshPro.fontSize = _originalFontSize;
			}
		}
	}
}
