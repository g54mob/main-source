namespace ObservableCollections
{
	public interface ICollectionEventDispatcher
	{
		void Post(CollectionEventDispatcherEventArgs ev);
	}
}
