using UnityEngine.Events;

namespace MateoRyhr
{
	public class HoldableButtonInput : BasicInput
	{
		public UnityEvent OnIsPressed;

		public UnityEvent OnReleased;

		private bool _pressed;

		private void Update()
		{
			HandlePressed();
		}

		private void HandlePressed()
		{
			if (_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].IsPressed())
			{
				OnIsPressed?.Invoke();
				_pressed = true;
				return;
			}
			if (_pressed)
			{
				OnReleased?.Invoke();
			}
			_pressed = false;
		}
	}
}
