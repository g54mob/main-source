using Factory;

public interface IController
{
	void OnControllerConnected();

	void OnControllerDisconnected();

	void RegisterInputActionsForApp(IScope appScope);

	void RegisterInputActionsForGame(IScope gameScope);

	void EnsureActionsAreRegistered(IScope scope);

	InputEventSource GetInputSource();
}
