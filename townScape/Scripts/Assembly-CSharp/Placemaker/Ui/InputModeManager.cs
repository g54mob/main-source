using UnityEngine;

namespace Placemaker.Ui
{
	public class InputModeManager : MonoBehaviour, UiMaster.IUiSetup
	{
		public enum Mode
		{
			None = 0,
			Gamepad = 1,
			TouchAndMouse = 2
		}

		private UiMaster master;

		[SerializeField]
		private GameObject mouseBlocker;

		public UpdateState gamepadState;

		public UpdateState touchAndMouseState;

		public Mode mode;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}

		public void SetState(Mode newMode)
		{
		}
	}
}
