using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class GridButtons : UIBehaviour, UiMaster.IUiSetup, ButtonAudio.IButtonAudioModifier
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private CanvasGroup tick0;

		[SerializeField]
		private UpdateState gridState0;

		[SerializeField]
		private UpdateState gridState1;

		[SerializeField]
		private AudioClip onClip;

		[SerializeField]
		private AudioClip offClip;

		public static int showGrid;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Toggle0()
		{
		}

		public void Button_Toggle1()
		{
		}

		void ButtonAudio.IButtonAudioModifier.ModifyAudioData(ref ButtonAudio.AudioData audioData, ButtonAudio.SoundType soundType)
		{
		}

		public void DisableGrid()
		{
		}
	}
}
