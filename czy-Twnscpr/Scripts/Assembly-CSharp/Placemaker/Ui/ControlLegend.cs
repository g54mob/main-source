using UnityEngine;

namespace Placemaker.Ui
{
	public class ControlLegend : MonoBehaviour, UiMaster.IUiSetup
	{
		private UiMaster master;

		public UpdateState openState;

		[SerializeField]
		private bool wasSideMenuOpen;

		[SerializeField]
		private bool wasSettingsMenuOpen;

		private bool firstFrame;

		public void Open()
		{
		}

		public void Close()
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}
	}
}
