using TMPro;
using UnityEngine;

namespace Placemaker.Ui
{
	public class GamepadControlsRow : MonoBehaviour, UiMaster.IUiSetup
	{
		private UiMaster master;

		public string buttonName;

		public TMP_Text buttonText;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}
	}
}
