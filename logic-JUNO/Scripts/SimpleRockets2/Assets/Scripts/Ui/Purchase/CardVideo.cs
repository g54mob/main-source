using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Purchase
{
	public class CardVideo
	{
		private XmlElement _element;

		private RawImage _rawImage;

		private XmlElement _thumbnail;

		public CardInfo.VideoInfo VideoInfo { get; }

		public CardVideo(CardDetails cardDetails, XmlElement videoElement, CardInfo.VideoInfo video)
		{
			CardVideo cardVideo = this;
			_element = videoElement;
			VideoInfo = video;
			videoElement.GetElementByInternalId<TextMeshProUGUI>("title").text = video.Title;
			_thumbnail = videoElement.GetElementByInternalId("thumbnail");
			_thumbnail.SetAndApplyAttribute("sprite", video.ThumbnailFile);
			XmlElement elementByInternalId = videoElement.GetElementByInternalId("video-image");
			elementByInternalId.AddOnClickEvent(delegate
			{
				cardDetails.OnVideoClicked(cardVideo);
			});
			_rawImage = elementByInternalId.GetComponent<RawImage>();
			_thumbnail.AddOnClickEvent(delegate
			{
				cardDetails.OnThumbnailClicked(cardVideo);
			});
			ShowMode(playMode: false);
		}

		public void OnStartedPlaying(RenderTexture texture)
		{
			ShowMode(playMode: true);
			_rawImage.texture = texture;
		}

		public void OnStoppedPlaying()
		{
			ShowMode(playMode: false);
			_rawImage.texture = null;
		}

		private void ShowMode(bool playMode)
		{
			foreach (XmlElement item in _element.GetChildElementsWithClass("play-mode"))
			{
				item.SetActive(playMode);
			}
			foreach (XmlElement item2 in _element.GetChildElementsWithClass("thumbnail-mode"))
			{
				item2.SetActive(!playMode);
			}
		}
	}
}
