using Events;
using Events.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class TextInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private ShowInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private ContentSizeFitter _contentSizeFitter;

		[SerializeField]
		private float _defaultWidth = 530f;

		private TextInfoPanelDto _textInfoPanelDto;

		private float _fontSize;

		protected override void Awake()
		{
			base.gameObject.SetActive(value: false);
			_showInfoPanelEvent.Register(base.Show);
			_hideInfoPanelEvent.Register(Hide);
			_fontSize = _text.fontSize;
		}

		protected override void OnDestroy()
		{
			_showInfoPanelEvent.UnRegister(base.Show);
			_hideInfoPanelEvent.UnRegister(Hide);
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			_textInfoPanelDto = dto as TextInfoPanelDto;
			string text = (_textInfoPanelDto.LocalizeText ? LocalizationUtility.GetLocalizedText(_textInfoPanelDto.Text) : _textInfoPanelDto.Text);
			if (_textInfoPanelDto.HasReplacement)
			{
				_text.SetText(string.Format(text, _textInfoPanelDto.ReplacementText1, _textInfoPanelDto.ReplacementText2, _textInfoPanelDto.ReplacementText2));
			}
			else
			{
				_text.SetText(text);
			}
			if (_textInfoPanelDto.EnableWrapping)
			{
				_contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				_panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _defaultWidth);
			}
			else
			{
				_contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
			}
			_text.fontSize = ((_textInfoPanelDto.FontSize > 0) ? ((float)_textInfoPanelDto.FontSize) : _fontSize);
		}
	}
}
