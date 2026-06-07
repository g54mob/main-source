using DG.Tweening;
using Events.UI.Overlays;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Presentation.UI.Overlays
{
	public class ModalDialogContentView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private TextMeshProUGUI _textField;

		[SerializeField]
		private TextMeshProUGUI _extraTextField;

		[SerializeField]
		private GameObject _mediaContent;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		private bool _hasVideo;

		private bool _hasImage;

		private ModalDialogContent _content;

		public void BuildContent(ModalDialogContent content)
		{
			_content = content;
			_canvasGroup.alpha = 0f;
			base.gameObject.SetActive(value: true);
			UpdateTexts();
			SetTextAlignment(content.TextAlignment);
			SetImageContent(content.ImageSprite);
			SetVideoContent(content.VideoName);
			_mediaContent.SetActive(_hasVideo || _hasImage);
			_rectTransform.ForceUpdateRectTransforms();
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
		}

		public void UpdateTexts()
		{
			if (_content != null)
			{
				if (!string.IsNullOrEmpty(_content.ExtraText))
				{
					_textField.SetText(_content.Text);
					_extraTextField.SetText(_content.ExtraText);
					_textField.gameObject.SetActive(value: true);
					_extraTextField.gameObject.SetActive(value: true);
				}
				else
				{
					_textField.SetText(string.Empty);
					_extraTextField.SetText(_content.Text);
					_textField.gameObject.SetActive(value: false);
					_extraTextField.gameObject.SetActive(value: true);
				}
				_rectTransform.ForceUpdateRectTransforms();
				LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
			}
		}

		public void Show(int direction = 0)
		{
			_rectTransform.DOKill();
			_canvasGroup.DOKill();
			if (_hasVideo)
			{
				PlayVideo();
			}
			if (direction == 0)
			{
				_canvasGroup.alpha = 1f;
				_rectTransform.anchoredPosition = Vector2.zero;
				return;
			}
			_canvasGroup.alpha = 0f;
			_rectTransform.anchoredPosition = Vector2.zero;
			_rectTransform.DOAnchorPosX(200f * (float)direction, 0.4f).From().SetEase(Ease.OutCubic);
			_canvasGroup.DOFade(1f, 0.3f);
		}

		public void Hide(int direction = 0)
		{
			_rectTransform.DOKill();
			_canvasGroup.DOKill();
			StopVideo();
			_canvasGroup.alpha = 0f;
			_rectTransform.anchoredPosition = Vector2.zero;
		}

		public void Reset()
		{
			base.gameObject.SetActive(value: false);
		}

		private void SetTextAlignment(TextAlignmentOptions alignment)
		{
			_textField.alignment = alignment;
			_extraTextField.alignment = alignment;
		}

		private void SetImageContent(Sprite imagesprite)
		{
			_hasImage = imagesprite != null;
			_image.gameObject.SetActive(_hasImage);
			if (_hasImage)
			{
				_image.sprite = imagesprite;
			}
		}

		private void SetVideoContent(string videoName)
		{
			_videoPlayer.gameObject.SetActive(value: false);
			_hasVideo = !string.IsNullOrEmpty(videoName);
			_videoPlayer.url = Application.streamingAssetsPath + "/Videos/" + videoName;
		}

		private void PlayVideo()
		{
			_videoPlayer.gameObject.SetActive(value: true);
		}

		private void StopVideo()
		{
			_videoPlayer.gameObject.SetActive(value: false);
		}
	}
}
