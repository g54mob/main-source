using Assets.Scripts.Input.Events;

namespace Assets.Scripts.UI
{
	public interface IInputHandler
	{
		void HandleInput(InputEvent e);

		void HandlePinch(PinchEvent e);

		void HandleScroll(MouseScrollEvent e);
	}
}
