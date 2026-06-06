using System;

namespace ObservableCollections
{
	[Obsolete("this interface is obsoleted. Use ISynchronizedViewFilter<T, TView> instead.")]
	public interface ISynchronizedViewFilter<T>
	{
		bool IsMatch(T value);
	}
	public interface ISynchronizedViewFilter<T, TView>
	{
		bool IsMatch(T value, TView view);
	}
}
