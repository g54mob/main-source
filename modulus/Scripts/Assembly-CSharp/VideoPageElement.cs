#define ENABLE_DEBUG_ERRORS
#define ENABLE_DEBUG_EXCEPTIONS
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils;

public class VideoPageElement : PageElement
{
	[SerializeField]
	private RawImage _rawImage;

	[SerializeField]
	private VideoPlayer _videoPlayer;

	public override void Setup(PageElementSO element)
	{
		if (!(element is VideoPageElementSO videoPageElementSO))
		{
			this.DevException("Setup called with wrong PageElementSO!", "Setup", 15);
			return;
		}
		if (!videoPageElementSO.VideoName.EndsWith(".mp4"))
		{
			this.LogError("Videofile >>" + videoPageElementSO.VideoName + "<< has to end in .mp4 !", "Setup", 20);
			return;
		}
		_videoPlayer.url = Application.streamingAssetsPath + "/Videos/Manual/" + videoPageElementSO.VideoName;
		RenderTexture renderTexture = new RenderTexture(1440, 810, 0);
		renderTexture.Create();
		_videoPlayer.targetTexture = renderTexture;
		_rawImage.texture = renderTexture;
		_videoPlayer.isLooping = true;
		_videoPlayer.playOnAwake = true;
		if (_videoPlayer.isPrepared)
		{
			_videoPlayer.Play();
			return;
		}
		_videoPlayer.prepareCompleted += PlayVideo;
		_videoPlayer.Prepare();
	}

	private void OnDestroy()
	{
		if (_videoPlayer.targetTexture != null)
		{
			_videoPlayer.targetTexture.Release();
			Object.Destroy(_videoPlayer.targetTexture);
		}
	}

	private void PlayVideo(VideoPlayer source)
	{
		_videoPlayer.Play();
	}
}
