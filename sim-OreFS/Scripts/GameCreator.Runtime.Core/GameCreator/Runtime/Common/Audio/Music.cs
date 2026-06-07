using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class Music : TAudioChannel
	{
		protected override float Volume => Singleton<AudioManager>.Instance.Volume.CurrentMusic;

		protected override AudioMixerGroup AudioOutput => Settings.From<GeneralRepository>().Audio.musicMixer;

		public Music(Transform parent)
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
