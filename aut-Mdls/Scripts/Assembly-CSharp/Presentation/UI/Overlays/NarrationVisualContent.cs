#define ENABLE_DEBUG_ERRORS
using Events.UI.Overlays;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils;

namespace Presentation.UI.Overlays
{
	public class NarrationVisualContent : MonoBehaviour
	{
		[SerializeField]
		private NarrationDialog _narrationDialog;

		[SerializeField]
		private GameObject _visualContent;

		[SerializeField]
		private Image _image;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		private void OnEnable()
		{
			_narrationDialog.OnNarrationStartShow += OnNarrationStart;
			_narrationDialog.OnNarrationHide += OnNarrationHide;
		}

		private void OnDisable()
		{
			_narrationDialog.OnNarrationStartShow -= OnNarrationStart;
			_narrationDialog.OnNarrationHide -= OnNarrationHide;
		}

		private void OnNarrationStart(NarrationDto dto)
		{
			TrySetImageContent(dto.ImageSprite);
			TrySetVideoContent(dto.VideoName);
		}

		private void OnNarrationHide()
		{
			_videoPlayer.prepareCompleted -= PlayVideo;
			_videoPlayer.Stop();
			_videoPlayer.gameObject.SetActive(value: false);
			_image.gameObject.SetActive(value: false);
			_visualContent.SetActive(value: false);
		}

		private void TrySetVideoContent(string videoName)
		{
			if (string.IsNullOrEmpty(videoName))
			{
				return;
			}
			if (!videoName.EndsWith(".mp4"))
			{
				this.LogError("Videofile >>" + videoName + "<< has to end in .mp4 !", "TrySetVideoContent", 52);
				return;
			}
			_videoPlayer.url = Application.streamingAssetsPath + "/Videos/" + videoName;
			_visualContent.SetActive(value: true);
			_videoPlayer.gameObject.SetActive(value: true);
			if (_videoPlayer.isPrepared)
			{
				PlayVideo(_videoPlayer);
				return;
			}
			_videoPlayer.prepareCompleted += PlayVideo;
			_videoPlayer.Prepare();
		}

		private void PlayVideo(VideoPlayer _)
		{
			_videoPlayer.Play();
		}

		private void TrySetImageContent(Sprite image)
		{
			if (!(image == null))
			{
				_visualContent.SetActive(value: true);
				_image.gameObject.SetActive(value: true);
				_image.sprite = image;
			}
		}
	}
}
