namespace ObservableCollections
{
	public delegate void NotifyViewChangedEventHandler<T, TView>(in SynchronizedViewChangedEventArgs<T, TView> e);
}
