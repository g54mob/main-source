namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryBehavior
	{
		int ExecutionOrder { get; }

		IDictionaryBehavior Copy();
	}
}
