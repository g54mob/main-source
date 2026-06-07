using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Purchase
{
	public class CardDetails
	{
		private CardScript _card;

		private XmlElement _cardBackground;

		private float _cardWidthPercentage = 1f;

		private bool _contentCreated;

		private XmlElement _fullscreenVideo;

		private bool _fullscreenVideoEnabled;

		private RawImage _fullscreenVideoImage;

		private TextMeshProUGUI _fullscreenVideoTitle;

		private CardVideo _selectedVideo;

		private XmlElement _videoParent;

		private IVideoPlayerService _videoPlayerService;

		private List<CardVideo> _videos = new List<CardVideo>();

		private TweenerCore<float, float, FloatOptions> _widthTween;

		public bool AutoPlayEnabled { get; set; }

		public bool ShowDetails
		{
			get
			{
				return _card.Element.HasClass("details-view");
			}
			set
			{
				_widthTween?.Kill(complete: true);
				if (value)
				{
					_widthTween = DOTween.To(() => CardWidthPercentage, delegate(float x)
					{
						CardWidthPercentage = x;
					}, 3f, 0.25f).OnComplete(delegate
					{
						ShowContent();
					}).SetEase(Ease.OutBack);
					return;
				}
				EnableFullscreenVideo(enable: false);
				SelectedVideo = null;
				AnimateBuyAndCloseButtons(expand: false);
				_widthTween = DOTween.To(() => CardWidthPercentage, delegate(float x)
				{
					CardWidthPercentage = x;
				}, 1f, 0.1f).SetEase(Ease.OutCirc).SetDelay(0.1f)
					.OnStart(delegate
					{
						_card.Element.RemoveClass("details-view");
					});
			}
		}

		private float CardWidthPercentage
		{
			get
			{
				return _cardWidthPercentage;
			}
			set
			{
				_cardWidthPercentage = value;
				_cardBackground.SetAndApplyAttribute("width", $"{value * 100f:n0}%");
			}
		}

		private CardVideo SelectedVideo
		{
			get
			{
				return _selectedVideo;
			}
			set
			{
				if (_selectedVideo != null)
				{
					_selectedVideo.OnStoppedPlaying();
				}
				_selectedVideo = value;
				if (_selectedVideo != null)
				{
					_videoPlayerService.Play(_selectedVideo.VideoInfo.VideoFile, delegate
					{
						SelectNextVideo();
					});
					_selectedVideo.OnStartedPlaying(_videoPlayerService.RenderTexture);
					_fullscreenVideoImage.texture = _videoPlayerService.RenderTexture;
					_fullscreenVideoTitle.text = _selectedVideo.VideoInfo.Title;
				}
				else
				{
					EnableFullscreenVideo(enable: false);
					_fullscreenVideoTitle.text = string.Empty;
				}
			}
		}

		public CardDetails(CardScript cardScript, IVideoPlayerService videoPlayerService)
		{
			_videoPlayerService = videoPlayerService;
			_card = cardScript;
			_cardBackground = _card.Element.GetElementByInternalId("card-background");
			_fullscreenVideo = _card.Element.GetElementByInternalId("fullscreen-video");
			XmlElement elementByInternalId = _card.Element.GetElementByInternalId("fullscreen-video-image");
			elementByInternalId.AddOnClickEvent(delegate
			{
				OnFullscreenVideoClicked();
			});
			_card.Element.GetElementByInternalId("fullscreen-video-close-button").AddOnClickEvent(delegate
			{
				OnFullscreenVideoClicked();
			});
			_fullscreenVideoImage = elementByInternalId.GetComponent<RawImage>();
			_fullscreenVideoTitle = _card.Element.GetElementByInternalId<TextMeshProUGUI>("fullscreen-video-title");
			UpdateBuyText();
		}

		public void OnCloseClicked(PurchaseDialogScript purchaseDialogScript)
		{
			if (_fullscreenVideoEnabled)
			{
				EnableFullscreenVideo(enable: false);
			}
			else
			{
				purchaseDialogScript.DetailCard = null;
			}
		}

		public void OnThumbnailClicked(CardVideo cardVideo)
		{
			SelectedVideo = cardVideo;
			EnableFullscreenVideo(enable: true);
		}

		public void OnVideoClicked(CardVideo cardVideo)
		{
			EnableFullscreenVideo(enable: true);
		}

		public void UpdateBuyText()
		{
			TextMeshProUGUI elementByInternalId = _card.Element.GetElementByInternalId<TextMeshProUGUI>("buy-text");
			if (_card.IsPurchasing)
			{
				elementByInternalId.text = "LOADING";
			}
			else if (_card.IsPurchased)
			{
				elementByInternalId.text = "OWNED";
			}
			else
			{
				elementByInternalId.text = GetPriceText(_card.CardInfo.Price);
			}
		}

		private static string GetPriceText(string localizedPrice)
		{
			string result = localizedPrice;
			int num = localizedPrice.IndexOf(".");
			if (num > 0)
			{
				string text = localizedPrice.Substring(0, num);
				string text2 = localizedPrice.Substring(num);
				result = "<size=125%>" + text + "</size>" + text2;
			}
			return result;
		}

		private void AnimateBuyAndCloseButtons(bool expand)
		{
			XmlElement elementByInternalId = _card.Element.GetElementByInternalId("button-buy");
			XmlElement elementByInternalId2 = _card.Element.GetElementByInternalId("button-close");
			if (expand)
			{
				elementByInternalId2.rectTransform.anchoredPosition = Vector2.zero;
				elementByInternalId.rectTransform.anchoredPosition = Vector2.zero;
				elementByInternalId2.rectTransform.DOAnchorPos(new Vector2(-438f, 0f), 0.5f);
				elementByInternalId.rectTransform.DOAnchorPos(new Vector2(438f, 0f), 0.5f);
			}
			else
			{
				elementByInternalId2.rectTransform.DOAnchorPos(Vector2.zero, 0.25f);
				elementByInternalId.rectTransform.DOAnchorPos(Vector2.zero, 0.25f);
			}
		}

		private void EnableFullscreenVideo(bool enable)
		{
			if (_fullscreenVideoEnabled != enable)
			{
				_fullscreenVideoEnabled = enable;
				if (enable)
				{
					_fullscreenVideo.Show(recursiveCall: false, null, forceEvenIfVisible: true);
				}
				else
				{
					_fullscreenVideo.Hide(recursiveCall: false, null, forceEvenIfNotVisible: true);
				}
				_videoParent.SetActive(!enable);
			}
		}

		private void OnFullscreenVideoClicked()
		{
			EnableFullscreenVideo(enable: false);
		}

		private void SelectNextVideo()
		{
			if (AutoPlayEnabled)
			{
				int num = _videos.IndexOf(SelectedVideo) + 1;
				if (num >= 0 && num < _videos.Count)
				{
					SelectedVideo = _videos[num];
				}
				else
				{
					SelectedVideo = null;
				}
			}
			else
			{
				SelectedVideo = null;
			}
		}

		private void ShowContent()
		{
			_card.Element.AddClass("details-view");
			AnimateBuyAndCloseButtons(expand: true);
			if (!_contentCreated)
			{
				_contentCreated = true;
				if (_card.CardInfo.IsCompleteEdition)
				{
					XmlElement elementById = _card.Element.xmlLayoutInstance.GetElementById("complete-edition-template");
					XmlElement elementByInternalId = _card.Element.GetElementByInternalId("screenshot-parent");
					UiUtilities.CloneTemplate(elementById, elementByInternalId);
				}
				else if (_card.CardInfo.DetailFormat == CardInfo.DetailFormatType.SixVideos)
				{
					XmlElement elementById2 = _card.Element.xmlLayoutInstance.GetElementById("video-template");
					_videoParent = _card.Element.GetElementByInternalId("video-parent");
					foreach (CardInfo.VideoInfo video in _card.CardInfo.Videos)
					{
						XmlElement videoElement = UiUtilities.CloneTemplate(elementById2, _videoParent);
						_videos.Add(new CardVideo(this, videoElement, video));
					}
				}
				else if (_card.CardInfo.DetailFormat == CardInfo.DetailFormatType.ThreeScreenshots)
				{
					XmlElement elementById3 = _card.Element.xmlLayoutInstance.GetElementById("screenshot-template");
					XmlElement elementByInternalId2 = _card.Element.GetElementByInternalId("screenshot-parent");
					foreach (CardInfo.ScreenshotInfo screenshot in _card.CardInfo.Screenshots)
					{
						UiUtilities.CloneTemplate(elementById3, elementByInternalId2).GetElementByInternalId("screenshot").SetAndApplyAttribute("sprite", screenshot.ScreenshotFile);
					}
				}
			}
			SelectNextVideo();
		}
	}
}
