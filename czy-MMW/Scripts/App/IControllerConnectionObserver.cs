public interface IControllerConnectionObserver
{
	void OnControllerConnected(IController controller);

	void OnControllerDisconnected(IController controller);
}
