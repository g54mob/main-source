using UnityEngine;
using UnityEngine.Events;

namespace Placemaker.Ui
{
	public class ProgressBarButton : MonoBehaviour, UiMaster.IUiSetup
	{
		public float holdTime;

		[SerializeField]
		private UnityEvent onFull;

		[SerializeField]
		private CornerImage bar;

		public UpdateState pressed;

		private BaseButton baseButton;

		private bool pressedByMouse;

		private bool pressedByGamepad;

		private bool hasBeenInvoked;

		private float gamepadPressTime;

		private int gamepadPressFrame;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void GamepadPress()
		{
		}

		private void Update()
		{
		}
	}
}
