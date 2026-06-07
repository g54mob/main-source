using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Audio;
using UnityEngine.Video;

namespace Gh
{
	public class VideoPlayerAudioProxy : MonoBehaviour
	{
		public string audioOutputName;

		[SerializeField]
		private VideoPlayer _videoPlayer;

		private bool _hasHadFirstRead;

		private AudioSampleProvider _sampleProvider;

		private uint _sampleRate;

		private List<ConcurrentQueue<float>> _channelSampleBuffer;

		private bool _enableLogging;

		private bool IsVideoPlaying { get; set; }

		public bool HasSoundFailed => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void OnVideoPrepared(VideoPlayer source)
		{
		}

		private void OnSampleOverflow(AudioSampleProvider provider, uint dropped)
		{
		}

		private void OnVideoStarted(VideoPlayer source)
		{
		}

		private void AudioFormatDelegate(uint playingID, AkAudioFormat audioFormat)
		{
		}

		private bool AudioSamplesDelegate(uint playingID, uint channelIndex, float[] samples)
		{
			return false;
		}

		private void OnVideoAudioSamplesAvailable(AudioSampleProvider provider, uint sampleFrameCount)
		{
		}

		private void OnDestroy()
		{
		}

		private void DebugLog(string message)
		{
		}
	}
}
