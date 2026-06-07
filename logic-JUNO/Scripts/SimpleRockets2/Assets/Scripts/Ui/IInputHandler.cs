using ModApi.Input.Events;

namespace Assets.Scripts.Ui
{
	public interface IInputHandler
	{
		void HandleInput(ClickEventArgs e);

		void HandlePinch(PinchEventArgs e);

		void HandleScroll(ScrollEventArgs e);
	}
}
