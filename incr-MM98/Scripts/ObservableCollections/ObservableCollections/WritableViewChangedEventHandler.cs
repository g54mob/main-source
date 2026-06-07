namespace ObservableCollections
{
	public delegate T WritableViewChangedEventHandler<T, TView>(TView newView, T originalValue, ref bool setValue);
}
