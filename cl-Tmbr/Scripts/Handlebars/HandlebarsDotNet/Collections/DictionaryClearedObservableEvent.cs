namespace HandlebarsDotNet.Collections
{
	internal class DictionaryClearedObservableEvent<TValue> : ObservableEvent<TValue>
	{
		public DictionaryClearedObservableEvent()
			: base(default(TValue))
		{
		}
	}
}
