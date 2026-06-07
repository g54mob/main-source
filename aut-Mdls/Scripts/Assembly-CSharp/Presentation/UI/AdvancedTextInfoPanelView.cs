using Events;
using Events.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class AdvancedTextInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private ShowAdvancedTextInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		private TextMeshProUGUI _text1;

		[SerializeField]
		private TextMeshProUGUI _text2;

		[SerializeField]
		private ContentSizeFitter _panelContentSizeFitter;

		[SerializeField]
		private ContentSizeFitter _contentSizeFitter1;

		[SerializeField]
		private ContentSizeFitter _contentSizeFitter2;

		[SerializeField]
		private float _defaultWidth = 530f;

		private AdvancedTextInfoPanelDto _textInfoPanelDto;

		private float _text1Size;

		private float _text2Size;

		protected override void Awake()
		{
			base.gameObject.SetActive(value: false);
			_showInfoPanelEvent.Register(base.Show);
			_hideInfoPanelEvent.Register(Hide);
			_text1Size = _text1.fontSize;
			_text2Size = _text2.fontSize;
		}

		protected override void OnDestroy()
		{
			_showInfoPanelEvent.UnRegister(base.Show);
			_hideInfoPanelEvent.UnRegister(Hide);
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			_textInfoPanelDto = dto as AdvancedTextInfoPanelDto;
			_text1.fontSize = ((_textInfoPanelDto.Text1Size > 0f) ? _textInfoPanelDto.Text1Size : _text1Size);
			_text2.fontSize = ((_textInfoPanelDto.Text2Size > 0f) ? _textInfoPanelDto.Text2Size : _text2Size);
			_text1.color = _textInfoPanelDto.Text1Color;
			_text2.color = _textInfoPanelDto.Text2Color;
			_text1.SetText(_textInfoPanelDto.Text1);
			_text2.SetText(_textInfoPanelDto.Text2);
			if (_textInfoPanelDto.EnableWrapping)
			{
				_panelContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				_contentSizeFitter1.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				_contentSizeFitter2.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				_panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _defaultWidth);
			}
			else
			{
				_panelContentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				_contentSizeFitter1.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				_contentSizeFitter2.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
			}
		}
	}
}
