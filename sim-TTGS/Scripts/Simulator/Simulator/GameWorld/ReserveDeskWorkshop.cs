using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveDeskWorkshop : Workshop, IUIInputReceiver
	{
		public event Action OnInteracted;

		public override void OnControlledBy(Controller controller)
		{
			base.OnControlledBy(controller);
			this.OnInteracted?.Invoke();
		}

		protected override void OnControlledByPlayerPostBlend()
		{
			base.OnControlledByPlayerPostBlend();
			ReserveDesk_HUDPopupModule.Closed += OnPopupClosed;
			OpenPopup();
			void OpenPopup()
			{
				World.HUDPopup.Open(EHUDPopupModuleType.RESERVE);
				IUIInputReceiver.SetCurrent(this);
			}
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			if (controller.IsPlayer)
			{
				ReserveDesk_HUDPopupModule.Closed -= OnPopupClosed;
				IUIInputReceiver.SetCurrent(null);
			}
		}

		protected override bool CanQuitWorkshop()
		{
			return true;
		}

		protected override void OnQuitWorkshop()
		{
			base.OnQuitWorkshop();
			World.HUDPopup.CloseModule();
		}

		private void OnPopupClosed()
		{
			QuitWorkshop();
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
		}

		public void OnUIInput_Submit()
		{
		}

		public void OnUIInput_Space()
		{
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_GamepadNorthButton()
		{
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
			if (!InputManager.InputFieldFocused)
			{
				QuitWorkshop();
			}
		}
	}
}
