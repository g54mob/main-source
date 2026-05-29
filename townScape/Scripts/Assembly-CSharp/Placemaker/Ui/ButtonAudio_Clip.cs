using UnityEngine;

namespace Placemaker.Ui
{
	public class ButtonAudio_Clip : MonoBehaviour, ButtonAudio.IButtonAudioModifier
	{
		public AudioClip clip;

		public ButtonAudio.SoundType soundType;

		void ButtonAudio.IButtonAudioModifier.ModifyAudioData(ref ButtonAudio.AudioData audioData, ButtonAudio.SoundType soundType)
		{
		}
	}
}
