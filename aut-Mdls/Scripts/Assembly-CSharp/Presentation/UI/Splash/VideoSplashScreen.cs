using System.IO;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Video;

namespace Presentation.UI.Splash
{
	public class VideoSplashScreen : BaseSplashScreen
	{
		[Header("Video Splash")]
		[SerializeField]
		private EventReference _splashAudioEvent;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		private string _streamingAssetsPath;

		private EventInstance _splashAudioInstance;

		protected override void OnContentShowing()
		{
			base.OnContentShowing();
			_videoPlayer.url = Path.Combine(Application.streamingAssetsPath, _streamingAssetsPath);
			_videoPlayer.frame = 0L;
			_videoPlayer.prepareCompleted += OnVideoPrepared;
			_videoPlayer.Prepare();
		}

		protected override void SplashComplete()
		{
			_splashAudioInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			_splashAudioInstance.release();
			base.SplashComplete();
		}

		private void OnVideoPrepared(VideoPlayer vp)
		{
			_videoPlayer.frame = 0L;
			_splashAudioInstance = RuntimeManager.CreateInstance(_splashAudioEvent);
			_splashAudioInstance.setVolume(_masterVolume.Value);
			_videoPlayer.Play();
			_splashAudioInstance.start();
		}

		private void OnDisable()
		{
			_videoPlayer.prepareCompleted -= OnVideoPrepared;
			SplashComplete();
		}
	}
}
