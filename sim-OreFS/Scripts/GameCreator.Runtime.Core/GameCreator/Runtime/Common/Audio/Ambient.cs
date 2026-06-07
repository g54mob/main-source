using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class Ambient : TAudioChannel
	{
		protected override float Volume => Singleton<AudioManager>.Instance.Volume.CurrentAmbient;

		protected override AudioMixerGroup AudioOutput => Settings.From<GeneralRepository>().Audio.ambientMixer;

		public Ambient(Transform parent)
			: base(parent)
		{
		}

		protected override AudioBuffer MakeAudioBuffer()
		{
			AudioBuffer audioBuffer = base.MakeAudioBuffer();
			audioBuffer.AudioSource.loop = true;
			return audioBuffer;
		}
	}
}
