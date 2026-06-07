using TMPro;
using UnityEngine;

namespace Events.UI.Overlays
{
	public class ModalDialogContent
	{
		public TextAlignmentOptions TextAlignment;

		private readonly string _titleKey;

		private readonly string _textKey;

		private readonly string _extraTextKey;

		public string Title { get; private set; }

		public string Text { get; private set; }

		public string ExtraText { get; private set; }

		public Sprite ImageSprite { get; private set; }

		public string VideoName { get; private set; }

		public ModalDialogContent(string textKey)
		{
			_titleKey = "";
			_textKey = textKey;
			_extraTextKey = "";
			UpdateTexts();
			TextAlignment = TextAlignmentOptions.Center;
		}

		public ModalDialogContent(string titleKey, string textKey)
		{
			_titleKey = titleKey;
			_textKey = textKey;
			_extraTextKey = "";
			UpdateTexts();
			TextAlignment = TextAlignmentOptions.Center;
		}

		public ModalDialogContent(string titleKey, string textKey, Sprite imageSprite, string extraTextKey = "")
		{
			_titleKey = titleKey;
			_textKey = textKey;
			_extraTextKey = extraTextKey;
			UpdateTexts();
			ImageSprite = imageSprite;
			TextAlignment = TextAlignmentOptions.Center;
		}

		public ModalDialogContent(string titleKey, string textKey, string videoName, Sprite imageSprite = null, string extraTextKey = "")
		{
			_titleKey = titleKey;
			_textKey = textKey;
			_extraTextKey = extraTextKey;
			UpdateTexts();
			VideoName = videoName;
			ImageSprite = imageSprite;
			TextAlignment = TextAlignmentOptions.Center;
		}

		public void UpdateTexts()
		{
			Title = (string.IsNullOrEmpty(_titleKey) ? "" : LocalizationUtility.GetLocalizedText(_titleKey));
			Text = LocalizationUtility.GetLocalizedText(_textKey);
			ExtraText = (string.IsNullOrEmpty(_extraTextKey) ? _extraTextKey : LocalizationUtility.GetLocalizedText(_extraTextKey));
		}
	}
}
