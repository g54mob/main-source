using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ToggleButton : UIBehaviour, UiMaster.IUiSetup, ButtonAudio.IButtonAudioModifier
	{
		public enum Function
		{
			Unclear = 0,
			InvertRotationX = 1,
			InvertRotationY = 2,
			HideUIMobile = 3,
			Fullscreen = 4,
			vSync = 5,
			antiAliasing = 6
		}

		private UiMaster master;

		[SerializeField]
		private UpdateState enabledState;

		[SerializeField]
		private GameObject tick;

		[SerializeField]
		private AudioClip onClip;

		[SerializeField]
		private AudioClip offClip;

		public Function function;

		public void OnStart(UiMaster master)
		{
		}

		public void OnSetup(UiMaster master)
		{
		}

		public void Toggle()
		{
		}

		public void ImportValue()
		{
		}

		void ButtonAudio.IButtonAudioModifier.ModifyAudioData(ref ButtonAudio.AudioData audioData, ButtonAudio.SoundType soundType)
		{
		}
	}
}
