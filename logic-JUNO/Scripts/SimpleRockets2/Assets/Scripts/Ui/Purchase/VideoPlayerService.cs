using System;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Scripts.Ui.Purchase
{
	public class VideoPlayerService : IVideoPlayerService, IDisposable
	{
		private Action _onComplete;

		private VideoPlayer _videoPlayer;

		public RenderTexture RenderTexture { get; private set; }

		public VideoPlayerService(GameObject go, int width, int height)
		{
			_videoPlayer = go.AddComponent<VideoPlayer>();
			RenderTexture = new RenderTexture(width, height, 16);
			_videoPlayer.targetTexture = RenderTexture;
			_videoPlayer.loopPointReached += OnVideoPlayerLoopPointReached;
		}

		public void Dispose()
		{
			if (_videoPlayer != null)
			{
				_videoPlayer.loopPointReached -= OnVideoPlayerLoopPointReached;
				_videoPlayer.targetTexture = null;
			}
			if (RenderTexture != null)
			{
				RenderTexture.Release();
				UnityEngine.Object.Destroy(RenderTexture);
				RenderTexture = null;
			}
		}

		public void Play(string videoClipPath, Action onComplete)
		{
			if (_videoPlayer.isPlaying)
			{
				Stop();
			}
			_onComplete = onComplete;
			VideoClip clip = Game.Instance.ResourceLoader.Load<VideoClip>(videoClipPath);
			_videoPlayer.clip = clip;
			_videoPlayer.Play();
		}

		public void Stop()
		{
			_videoPlayer.Stop();
			ClearRenderTexture();
			_onComplete = null;
		}

		private void ClearRenderTexture()
		{
			Texture2D texture2D = new Texture2D(1, 1);
			texture2D.SetPixel(0, 0, Color.black);
			texture2D.Apply();
			Graphics.Blit(texture2D, RenderTexture);
			UnityEngine.Object.Destroy(texture2D);
		}

		private void OnVideoPlayerLoopPointReached(VideoPlayer source)
		{
			ClearRenderTexture();
			Action onComplete = _onComplete;
			_onComplete = null;
			onComplete?.Invoke();
		}
	}
}
