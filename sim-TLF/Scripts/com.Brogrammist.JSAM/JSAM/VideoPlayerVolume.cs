using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace JSAM
{
	public class VideoPlayerVolume : VolumeListener
	{
		[SerializeField]
		private VideoPlayer videoPlayer;

		[SerializeField]
		private RawImage videoImage;

		private void OnEnable()
		{
			if ((bool)videoPlayer)
			{
				videoPlayer.prepareCompleted += AttachAudioSource;
				if (videoPlayer.isPlaying)
				{
					Init();
				}
			}
		}

		private void OnDisable()
		{
			if ((bool)videoPlayer)
			{
				videoPlayer.prepareCompleted -= AttachAudioSource;
			}
			UnsubscribeFromAudioEvents();
		}

		private void AttachAudioSource(VideoPlayer source)
		{
			Init();
		}

		[ContextMenu("Init")]
		private void Init()
		{
			StartCoroutine(PlayRoutine());
		}

		private IEnumerator PlayRoutine()
		{
			videoPlayer.enabled = false;
			SubscribeToVolumeEvents();
			subscribedChannel = volumeChannel;
			videoPlayer.enabled = true;
			videoPlayer.prepareCompleted -= AttachAudioSource;
			videoPlayer.Prepare();
			yield return new WaitUntil(() => videoPlayer.isPrepared);
			videoPlayer.Play();
			videoPlayer.prepareCompleted += AttachAudioSource;
		}
	}
}
