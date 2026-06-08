namespace HandlebarsDotNet.Collections
{
	public class AddedObservableEvent<T> : ObservableEvent<T>
	{
		public AddedObservableEvent(T value)
			: base(value)
		{
		}
	}
}
