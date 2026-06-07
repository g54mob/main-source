using Data.Credits;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Credits
{
	public class CreditsSegment : CreditsBaseSegment
	{
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private Image _image;

		private string _titleLoca;

		private string _textLoca;

		protected override void UpdateTexts()
		{
			SetTitle();
			SetText();
		}

		private void SetTitle()
		{
			bool flag = !string.IsNullOrEmpty(_titleLoca);
			_titleText.gameObject.SetActive(flag);
			if (flag)
			{
				_titleText.text = LocalizationUtility.GetLocalizedText(_titleLoca);
			}
		}

		private void SetText()
		{
			bool flag = !string.IsNullOrEmpty(_textLoca);
			_text.gameObject.SetActive(flag);
			if (flag)
			{
				_text.text = LocalizationUtility.GetLocalizedText(_textLoca);
			}
		}

		public override void SetContent(CreditsSegmentData segmentData)
		{
			_titleLoca = segmentData.TitleLocaKey;
			_textLoca = segmentData.TextLocaKey;
			bool flag = segmentData.Image != null;
			_image.gameObject.SetActive(flag);
			if (flag)
			{
				_image.sprite = segmentData.Image;
			}
			UpdateTexts();
		}
	}
}
