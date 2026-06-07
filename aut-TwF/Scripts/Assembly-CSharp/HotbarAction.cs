public abstract class HotbarAction
{
	private object data;

	public object Data => data;

	protected HotbarAction(object data)
	{
		this.data = data;
	}

	public abstract bool DoAction();
}
