using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class FullscreenButton : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private CanvasGroup tick;

		[SerializeField]
		private UpdateState state;

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
