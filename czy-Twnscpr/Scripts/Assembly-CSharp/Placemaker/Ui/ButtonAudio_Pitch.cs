using UnityEngine;

namespace Placemaker.Ui
{
	public class ButtonAudio_Pitch : MonoBehaviour, ButtonAudio.IButtonAudioModifier
	{
		private enum Mode
		{
			Add = 0,
			Set = 1
		}

		public ButtonAudio.SoundType soundType;

		[Space]
		[SerializeField]
		private Mode mode;

		public float min;

		public float max;

		void ButtonAudio.IButtonAudioModifier.ModifyAudioData(ref ButtonAudio.AudioData audioData, ButtonAudio.SoundType soundType)
		{
		}
	}
}
