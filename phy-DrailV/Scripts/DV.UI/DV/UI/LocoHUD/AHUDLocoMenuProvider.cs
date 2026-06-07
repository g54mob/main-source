using UnityEngine;

namespace DV.UI.LocoHUD
{
	public abstract class AHUDLocoMenuProvider : MonoBehaviour
	{
		public abstract void HandleButtonPress(HUDLocoMenu.ButtonType type);

		public abstract HUDLocoMenu.CouplingState GetCouplerState(bool right);

		public abstract bool IsHoseCockOpen(bool right);

		public abstract bool IsFullyCoupled(bool right);

		public abstract float GetAngle();

		public abstract Vector2 GetScreenCoords();

		public abstract bool GetButtonState(HUDLocoMenu.ButtonType type);

		public abstract bool IsButtonInteractable(HUDLocoMenu.ButtonType type);

		public abstract void CacheValues();
	}
}
