using System;
using System.Collections.Generic;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathenengineering.com/assets/steamworks/voice")]
	public class VoiceStream : MonoBehaviour
	{
		public AudioSource outputSource;

		public SampleRateMethod sampleRateMethod;

		[Range(11025f, 48000f)]
		public uint customSampleRate = 28000u;

		[Range(0f, 3f)]
		public float playbackDelay = 0.25f;

		private int sampleRate;

		private Queue<float> audioBuffer = new Queue<float>(48000);

		public double encodingTime;

		private void Start()
		{
			outputSource.loop = true;
			if (playbackDelay > 0f)
			{
				int num = (int)((float)((sampleRateMethod == SampleRateMethod.Optimal) ? ((int)SteamUser.GetVoiceOptimalSampleRate()) : ((sampleRateMethod == SampleRateMethod.Native) ? AudioSettings.outputSampleRate : ((int)customSampleRate))) * playbackDelay);
				for (int i = 0; i < num; i++)
				{
					audioBuffer.Enqueue(0f);
				}
			}
		}

		private void Update()
		{
			int num = ((sampleRateMethod == SampleRateMethod.Optimal) ? ((int)SteamUser.GetVoiceOptimalSampleRate()) : ((sampleRateMethod == SampleRateMethod.Native) ? AudioSettings.outputSampleRate : ((int)customSampleRate)));
			if (num != sampleRate)
			{
				sampleRate = num;
				outputSource.Stop();
				if (outputSource.clip != null)
				{
					UnityEngine.Object.Destroy(outputSource.clip);
				}
				outputSource.clip = AudioClip.Create("VOICE", sampleRate * 2, 1, sampleRate, stream: true, OnAudioRead);
				outputSource.Play();
			}
		}

		public void PlayVoiceData(byte[] buffer)
		{
			byte[] array = new byte[20000];
			uint resultsWrittenSize;
			EVoiceResult eVoiceResult = Voice.Client.DecompressVoice(buffer, array, out resultsWrittenSize, (uint)sampleRate);
			DateTime now = DateTime.Now;
			if (eVoiceResult == EVoiceResult.k_EVoiceResultBufferTooSmall)
			{
				array = new byte[resultsWrittenSize];
				eVoiceResult = Voice.Client.DecompressVoice(buffer, array, out resultsWrittenSize, (uint)sampleRate);
			}
			if (resultsWrittenSize != 0)
			{
				for (int i = 0; i < resultsWrittenSize; i += 2)
				{
					audioBuffer.Enqueue((float)(short)(array[i] | (array[i + 1] << 8)) / 32768f);
				}
				double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
				if (totalMilliseconds > encodingTime)
				{
					encodingTime = totalMilliseconds;
				}
			}
			else
			{
				Debug.LogWarning("Unknown result message: " + eVoiceResult);
			}
		}

		private void OnAudioRead(float[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (audioBuffer.Count > 0)
				{
					data[i] = audioBuffer.Dequeue();
				}
				else
				{
					data[i] = 0f;
				}
			}
		}
	}
}
