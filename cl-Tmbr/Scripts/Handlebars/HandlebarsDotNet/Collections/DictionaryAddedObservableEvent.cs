namespace HandlebarsDotNet.Collections
{
	internal class DictionaryAddedObservableEvent<TKey, TValue> : ObservableEvent<TValue>
	{
		public TKey Key { get; }

		public DictionaryAddedObservableEvent(TKey key, TValue value)
			: base(value)
		{
			Key = key;
		}
	}
}
