using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class PalettePicker : MonoBehaviour, PaletteMenu.IPaletteSetup, ButtonAudio.IButtonAudioModifier
	{
		[SerializeField]
		public Graphic fg;

		[SerializeField]
		public Graphic bg;

		[SerializeField]
		public UpdateState selectedState;

		public float pitch;

		void PaletteMenu.IPaletteSetup.OnSetup()
		{
		}

		public void OnClicked()
		{
		}

		void ButtonAudio.IButtonAudioModifier.ModifyAudioData(ref ButtonAudio.AudioData audioData, ButtonAudio.SoundType soundType)
		{
		}
	}
}
