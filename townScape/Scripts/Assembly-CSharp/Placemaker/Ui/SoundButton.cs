using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class SoundButton : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private DistanceFieldSettings distanceField0;

		[SerializeField]
		private DistanceFieldSettings distanceField1;

		[SerializeField]
		private UpdateState soundState;

		public AudioMixer mixer;

		private const float floatToByte = 127f;

		private const float byteToFloat = 1f / 127f;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Toggle()
		{
		}

		public void Button_Slider(float value)
		{
		}

		public void UpdateVolume()
		{
		}
	}
}
