namespace Castle.Components.DictionaryAdapter
{
	public interface IDynamicValue
	{
		object GetValue();
	}
	public interface IDynamicValue<T> : IDynamicValue
	{
		T Value { get; }
	}
}
