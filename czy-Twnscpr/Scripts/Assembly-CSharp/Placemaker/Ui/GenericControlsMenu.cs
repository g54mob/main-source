using UnityEngine;

namespace Placemaker.Ui
{
	public class GenericControlsMenu : MonoBehaviour, UiMaster.IUiSetup, GenericMenuNavigator.INavigableMenu
	{
		private UiMaster master;

		public UpdateState openState;

		public UiMaster.MenuState menuState;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		public void Open()
		{
		}

		public void Close(bool openSettingsMenu)
		{
		}

		private void Update()
		{
		}

		private void UpdateControls()
		{
		}

		UpdateState GenericMenuNavigator.INavigableMenu.GetMainUpdateState()
		{
			return null;
		}
	}
}
