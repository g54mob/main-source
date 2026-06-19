using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TH20
{
	public class VideoCutsceneMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private RawImage _videoRawImage;

		private bool _loop;

		private RenderTexture _renderTexture;

		public bool IsPlaying => _videoPlayer.isPlaying;

		public VideoClip Clip => _videoPlayer.clip;

		public void Setup(VideoClip clip, bool loop)
		{
			if (_renderTexture != null)
			{
				if (_renderTexture.IsCreated())
				{
					_renderTexture.Release();
				}
				_renderTexture = null;
			}
			_renderTexture = new RenderTexture(1920, 1080, 0, RenderTextureFormat.ARGB32);
			_renderTexture.Create();
			_videoPlayer.renderMode = VideoRenderMode.RenderTexture;
			_videoPlayer.targetTexture = _renderTexture;
			_videoRawImage.texture = _renderTexture;
			_videoPlayer.clip = clip;
			_videoPlayer.isLooping = loop;
			_videoPlayer.Play();
		}

		protected override void Update()
		{
			base.Update();
			if (!_loop && !_videoPlayer.isPlaying)
			{
				if (_renderTexture != null)
				{
					_renderTexture.Release();
					_renderTexture = null;
				}
				CloseMenu();
			}
		}
	}
}
