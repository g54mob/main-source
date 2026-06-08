namespace Castle.Components.DictionaryAdapter.Xml
{
	public interface IRealizable<T> : IRealizableSource
	{
		bool IsReal { get; }

		T Value { get; }
	}
}
