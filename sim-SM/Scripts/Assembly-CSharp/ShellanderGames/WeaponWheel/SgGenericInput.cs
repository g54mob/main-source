using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public abstract class SgGenericInput : MonoBehaviour
	{
		[Tooltip("If true, the ToggleWeaponWheel must be pressed down to show weapon wheel. If false, the weapon wheel will toggle on button presses.")]
		public bool holdButtonToShow;

		[Tooltip("Hide weapon wheel when an item has been selected.")]
		public bool hideOnSelected;

		[Tooltip("Delay before weapon wheel can be displayed again after selecting (hold button mode only).")]
		public float showAgainCooldown;

		[Tooltip("Highlight slice when a keyboard digit is pressed.")]
		public bool highlightSliceOnDigitPress;

		[Tooltip("Select slice when a keyboard digit is pressed. Works even when the weapon wheel is invisible.")]
		public bool selectSliceOnDigitPress;

		[Tooltip("Changes which slice will be considered the first, the slice that will be selected when 1 is pressed. This can be a negative value.")]
		public int firstSliceOffset;

		[Tooltip("Confirm when gamepad button is released instead of when it's pressed")]
		public bool confirmOnButtonRelease;

		private SgWeaponWheel m_WeaponWheel;

		private float m_CurrentCooldown;

		private bool m_HasReleasedButtonAfterSelect;

		private Vector2 m_PrevStickValue;

		protected virtual bool IsToggleWheelButtonPressed => false;

		protected virtual bool WasToggleWheelButtonPressedNow => false;

		protected virtual bool WasGamepadConfirmButtonPressedNow => false;

		protected virtual bool WasGamepadConfirmButtonReleasedNow => false;

		protected virtual bool IsPointerActionEnabled => false;

		protected virtual Vector2 CurrentPointerValue => default(Vector2);

		protected virtual Vector2 CurrentStickValue => default(Vector2);

		protected virtual void Start()
		{
		}

		private void OnEvent(SgWeaponWheelEvent wheelEvent)
		{
		}

		public virtual void ResetComponent()
		{
		}

		protected virtual bool WasDigitPressedNow(int digit)
		{
			return false;
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
