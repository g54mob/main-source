using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class PinUiButton : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private CanvasGroup tick;

		[SerializeField]
		private UpdateState state;

		[SerializeField]
		private GameObject palettePinTarget;

		[SerializeField]
		private GameObject sideMenuPinTarget;

		[SerializeField]
		private GameObject undoRedoPinTarget;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_Toggle0()
		{
		}
	}
}
