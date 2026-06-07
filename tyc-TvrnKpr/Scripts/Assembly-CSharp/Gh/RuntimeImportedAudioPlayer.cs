using System;
using System.Collections.Generic;
using NAudio.Wave;
using UnityEngine;

namespace Gh
{
	public class RuntimeImportedAudioPlayer : MonoBehaviour
	{
		public string outputEventName;

		public string fullFilePath;

		private AudioSource _audioSource;

		private AudioFileReader _audioFileReader;

		private object BufferLock;

		private int _currentSampleIndex;

		private List<List<float>> _channelSampleBuffer;

		public bool IsAudioPlaying { get; set; }

		private int SampleBufferSize => 0;

		[ContextMenu("Play Test Audio")]
		public void PlayTestAudio()
		{
		}

		public void PlayAudioFile(string filepath)
		{
		}

		private void CleanUpAudio()
		{
		}

		private void StartOutput()
		{
		}

		private void ImportAudioClip(Action finishedCallback)
		{
		}

		private void AudioFormatDelegate(uint playingID, AkAudioFormat audioFormat)
		{
		}

		private bool AudioSamplesDelegate(uint playingID, uint channelIndex, float[] samples)
		{
			return false;
		}

		private void Update()
		{
		}

		private void BufferSamples()
		{
		}
	}
}
