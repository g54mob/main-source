using UnityEngine.Events;

public class LoadingTask : ILoadingTask
{
	private UnityAction _action;

	private bool _completed;

	public int Weight => 1;

	public string DebugId { get; private set; }

	public LoadingTask(UnityAction action, string debugId)
	{
		_action = action;
		DebugId = debugId;
		_completed = false;
	}

	public bool Run()
	{
		if (_completed)
		{
			return false;
		}
		_action();
		_completed = true;
		return true;
	}
}
