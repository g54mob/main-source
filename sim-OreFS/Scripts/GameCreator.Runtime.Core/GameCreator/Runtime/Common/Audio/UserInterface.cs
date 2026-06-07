using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class UserInterface : TAudioChannel
	{
		protected override float Volume => Singleton<AudioManager>.Instance.Volume.CurrentUI;

		protected override AudioMixerGroup AudioOutput => Settings.From<GeneralRepository>().Audio.userInterfaceMixer;

		public UserInterface(Transform parent)
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
