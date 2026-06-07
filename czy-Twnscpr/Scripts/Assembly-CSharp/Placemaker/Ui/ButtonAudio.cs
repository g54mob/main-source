using UnityEngine;

namespace Placemaker.Ui
{
	public static class ButtonAudio
	{
		public struct AudioData
		{
			public AudioClip clip;

			public float pitch;

			public float volume;
		}

		public enum SoundType
		{
			disabled = 0,
			buttonDown = 1,
			click = 2,
			all = 3,
			gamepadSelected = 4,
			mouseOver = 5
		}

		public interface IButtonAudioModifier
		{
			void ModifyAudioData(ref AudioData audioData, SoundType soundType);
		}

		public static void Play(Transform t, SoundType soundType, float volume = 1f)
		{
		}
	}
}
