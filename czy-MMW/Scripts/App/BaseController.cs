using Factory;

public abstract class BaseController : IController
{
	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("RemappableController");

	[Dependency]
	protected PlayerActionController _playerActionController;

	[Dependency]
	protected IScope _scope;

	[Dependency]
	protected InputState _inputState;

	public abstract string DeviceName { get; }

	public virtual void OnControllerConnected()
	{
	}

	public virtual void OnControllerDisconnected()
	{
	}

	public virtual void RegisterInputActionsForApp(IScope appScope)
	{
	}

	public virtual void RegisterInputActionsForGame(IScope gameScope)
	{
	}

	public virtual void EnsureActionsAreRegistered(IScope scope)
	{
	}

	public virtual InputEventSource GetInputSource()
	{
		return InputEventSource.Generic;
	}
}
