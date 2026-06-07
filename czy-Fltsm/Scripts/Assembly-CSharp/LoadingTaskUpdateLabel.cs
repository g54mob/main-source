public class LoadingTaskUpdateLabel : ILoadingTask
{
	private string _label;

	public int Weight => 0;

	public string DebugId => null;

	public LoadingTaskUpdateLabel(string label)
	{
		_label = label;
	}

	public bool Run()
	{
		new LoadingEvent(_label).Dispatch();
		return false;
	}
}
