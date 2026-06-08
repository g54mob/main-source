namespace Castle.Components.DictionaryAdapter
{
	public interface ICollectionAdapterObserver<T>
	{
		bool OnInserting(T newValue);

		bool OnReplacing(T oldValue, T newValue);

		void OnRemoving(T oldValue);

		void OnInserted(T newValue, int index);

		void OnReplaced(T oldValue, T newValue, int index);

		void OnRemoved(T oldValue, int index);
	}
}
