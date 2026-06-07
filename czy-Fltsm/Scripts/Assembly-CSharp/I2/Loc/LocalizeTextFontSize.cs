using UnityEngine.UI;

namespace I2.Loc
{
	internal class LocalizeTextFontSize : ILocalizeFontSizeBehaviour
	{
		private Text _text;

		private int _originalFontSize;

		private int _originalResizeTextMinSize;

		private int _originalResizeTextMaxSize;

		public LocalizeTextFontSize(Text text)
		{
			_text = text;
			_originalFontSize = text.fontSize;
			_originalResizeTextMinSize = text.resizeTextMinSize;
			_originalResizeTextMaxSize = text.resizeTextMaxSize;
		}

		public void ApplyOverride(LocalizeFontSize.Override fontSizeOverride)
		{
			if (_text.resizeTextForBestFit)
			{
				_text.resizeTextMinSize = fontSizeOverride.fontSizeMin;
				_text.resizeTextMaxSize = fontSizeOverride.fontSizeMax;
			}
			else
			{
				_text.fontSize = fontSizeOverride.fontSize;
			}
		}

		public void Restore()
		{
			if (_text.resizeTextForBestFit)
			{
				_text.resizeTextMinSize = _originalResizeTextMinSize;
				_text.resizeTextMaxSize = _originalResizeTextMaxSize;
			}
			else
			{
				_text.fontSize = _originalFontSize;
			}
		}
	}
}
