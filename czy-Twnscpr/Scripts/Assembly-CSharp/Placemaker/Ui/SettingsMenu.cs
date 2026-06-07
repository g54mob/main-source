using UnityEngine;

namespace Placemaker.Ui
{
	public class SettingsMenu : MonoBehaviour, UiMaster.IUiSetup, GenericMenuNavigator.INavigableMenu
	{
		private UiMaster master;

		public UpdateState openState;

		public GenericMenuNavigator navigator;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		public void Open()
		{
		}

		public void Close(bool openSideMenu)
		{
		}

		UpdateState GenericMenuNavigator.INavigableMenu.GetMainUpdateState()
		{
			return null;
		}
	}
}
