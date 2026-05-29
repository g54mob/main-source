using UnityEngine;

namespace Placemaker.Ui
{
	public class GamepadXboxDialog : MonoBehaviour, UiMaster.IUiSetup
	{
		private UiMaster master;

		public UpdateState openState;

		[SerializeField]
		private bool isCloseable;

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
