namespace ObservableCollections
{
	internal class InlineCollectionEventDispatcher : ICollectionEventDispatcher
	{
		public static readonly ICollectionEventDispatcher Instance = new InlineCollectionEventDispatcher();

		private InlineCollectionEventDispatcher()
		{
		}

		public void Post(CollectionEventDispatcherEventArgs ev)
		{
			ev.Invoke();
		}
	}
}
