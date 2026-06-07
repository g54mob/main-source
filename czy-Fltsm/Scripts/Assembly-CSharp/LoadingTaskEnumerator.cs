using UnityEngine.Events;

public class LoadingTaskEnumerator : ILoadingTask
{
	private UnityAction<int> _callback;

	private int _index;

	public int Weight { get; private set; }

	public string DebugId => null;

	public LoadingTaskEnumerator(UnityAction<int> callback, int length)
	{
		_callback = callback;
		Weight = length;
		_index = 0;
	}

	public bool Run()
	{
		if (_index < Weight)
		{
			_callback(_index++);
			return true;
		}
		return false;
	}
}
