using UnityEngine;

namespace Placemaker.Ui
{
	public class WebLinkButton : MonoBehaviour, UiMaster.IUiSetup
	{
		public enum Link
		{
			Steam = 0,
			GoG = 1,
			NintendoSwitch = 2,
			AppStore = 3,
			GooglePlay = 4,
			EpicGamesStore = 5,
			XboxStore = 6
		}

		public Link link;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void OpenUrl(string str)
		{
		}
	}
}
