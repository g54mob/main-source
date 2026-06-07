using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	public class ButtonInputProcessor : MonoBehaviour
	{
		[Tooltip("How long you have to press a key down for it to register as a second key press")]
		public float tickRate;

		public float tickRateSideWays;

		public UnityEvent upAxisEvent;

		public UnityEvent downAxisEvent;

		public UnityEvent leftAxisEvent;

		public UnityEvent rightAxisEvent;

		public UnityEvent submitEvent;

		private float lastPressedUp;

		private float lastPressedDown;

		private float lastPressedLeft;

		private float lastPressedRight;

		private float lastPressedSubmit;

		private Vector2 axisInput;

		private void Update()
		{
		}

		private void ProcessAxisInput()
		{
		}

		public void OnNavigate(InputAction.CallbackContext context)
		{
		}

		private void OnNavigate(InputValue value)
		{
		}

		public void OnSubmit(InputAction.CallbackContext context)
		{
		}

		private void OnSubmit(InputValue value)
		{
		}

		private void AttemptUp()
		{
		}

		private void AttemptDown()
		{
		}

		private void AttemptLeft()
		{
		}

		private void AttemptRight()
		{
		}
	}
}
