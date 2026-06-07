using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class SoundEffect : TAudioChannel
	{
		protected override float Volume => Singleton<AudioManager>.Instance.Volume.CurrentSoundEffects;

		protected override AudioMixerGroup AudioOutput => Settings.From<GeneralRepository>().Audio.soundEffectsMixer;

		public SoundEffect(Transform parent)
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
