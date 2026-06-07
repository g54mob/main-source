using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class Speech : TAudioChannel
	{
		protected override float Volume => Singleton<AudioManager>.Instance.Volume.CurrentSpeech;

		protected override AudioMixerGroup AudioOutput => Settings.From<GeneralRepository>().Audio.speechMixer;

		public Speech(Transform parent)
			: base(parent)
		{
		}

		protected override AudioBuffer MakeAudioBuffer()
		{
			AudioBuffer audioBuffer = base.MakeAudioBuffer();
			audioBuffer.AudioSource.loop = false;
			return audioBuffer;
		}
	}
}
