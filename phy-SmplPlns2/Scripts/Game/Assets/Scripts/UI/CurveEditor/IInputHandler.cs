namespace Assets.Scripts.UI.CurveEditor
{
	public interface IInputHandler
	{
		void HandleInput(ClickEventArgs e);

		void HandlePinch(PinchEventArgs e);

		void HandleScroll(ScrollEventArgs e);
	}
}
