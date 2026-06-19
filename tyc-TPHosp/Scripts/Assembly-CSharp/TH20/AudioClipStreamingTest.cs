using System;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class AudioClipStreamingTest : MonoBehaviour
	{
		private const int cDurationSeconds = 300;

		private const int cSampleRate = 44100;

		private const int cNumSamplesPerChannel = 13230000;

		private const int cChannelCount = 1;

		private const float cSampleTimeIncr = 2.2675737E-05f;

		private AudioSource _audioSource;

		private AudioClip _audioClip;

		private bool _isPlaying;

		private float _playbackTime;

		public void Start()
		{
			_audioSource = base.gameObject.AddComponent<AudioSource>();
			_audioSource.spatialize = false;
			_audioSource.volume = 1f;
			StartPlaying();
		}

		public void Update()
		{
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.T))
			{
				if (!_isPlaying)
				{
					StartPlaying();
				}
				else
				{
					StopPlaying();
				}
			}
		}

		public void StartPlaying()
		{
			_isPlaying = true;
			_playbackTime = 0f;
			_audioClip = AudioClip.Create("TestStreamingClip", 13230000, 1, 44100, stream: true, StreamedAudioClipFillBufferCallback, null);
			_audioSource.clip = _audioClip;
			_audioSource.loop = true;
			_audioSource.time = 0f;
			_audioSource.Play();
		}

		public void StopPlaying()
		{
			_isPlaying = false;
			_audioSource.Stop();
			if (_audioClip != null)
			{
				UnityEngine.Object.Destroy(_audioClip);
				_audioClip = null;
			}
		}

		private void StreamedAudioClipFillBufferCallback(float[] dataToFill)
		{
			float num = Mathf.Pow(2f, Mathf.Floor(_playbackTime % 16f / 4f)) * 125f;
			float num2 = 1f / num;
			int num3 = 0;
			int num4 = dataToFill.Length;
			while (num3 < num4)
			{
				dataToFill[num3] = ((_playbackTime % 0.5f / 0.5f > 0.5f) ? Mathf.Sin(_playbackTime % num2 / num2 * 360f * ((float)Math.PI / 180f)) : 0f);
				num3++;
				_playbackTime += 2.2675737E-05f;
			}
		}
	}
}
