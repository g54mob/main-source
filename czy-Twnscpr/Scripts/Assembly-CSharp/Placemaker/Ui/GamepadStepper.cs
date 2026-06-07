using UnityEngine;

namespace Placemaker.Ui
{
	public class GamepadStepper : MonoBehaviour
	{
		public enum Mode
		{
			none = 0,
			left = 1,
			right = 2,
			up = 4,
			down = 8,
			horizontal = 3,
			vertical = 12,
			free = 15
		}

		[SerializeField]
		private UiMaster uiMaster;

		public Mode mode;

		private int steps;

		private Vector2 stepper;

		public bool stepLeft;

		public bool stepRight;

		public bool stepUp;

		public bool stepDown;

		public Vector2 stepVector;

		public Vector2 axis;

		private void Update()
		{
		}

		private void StartMoving()
		{
		}

		private void StopMoving()
		{
		}

		private void OnDisable()
		{
		}
	}
}
