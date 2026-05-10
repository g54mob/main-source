using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public class SgWeaponWheelLegacyInput : SgGenericInput
	{
		public string confirmButtonName;

		public string toggleButtonName;

		public string gamepadXAxisName;

		public string gamepadYAxisName;

		private Vector2 m_CachedStickValue;

		protected override bool IsToggleWheelButtonPressed => false;

		protected override bool WasToggleWheelButtonPressedNow => false;

		protected override bool WasGamepadConfirmButtonPressedNow => false;

		protected override bool WasGamepadConfirmButtonReleasedNow => false;

		protected override bool IsPointerActionEnabled => false;

		protected override Vector2 CurrentPointerValue => default(Vector2);

		protected override Vector2 CurrentStickValue => default(Vector2);

		protected override bool WasDigitPressedNow(int digit)
		{
			return false;
		}
	}
}
