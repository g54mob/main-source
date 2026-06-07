using System;

namespace ObservableCollections
{
	public class SynchronizedViewFilter<T, TView> : ISynchronizedViewFilter<T, TView>
	{
		private class NullViewFilter : ISynchronizedViewFilter<T, TView>
		{
			public bool IsMatch(T value, TView view)
			{
				return true;
			}
		}

		public static readonly ISynchronizedViewFilter<T, TView> Null = new NullViewFilter();

		public SynchronizedViewFilter(Func<T, TView, bool> isMatch)
		{
			_003CisMatch_003EP = isMatch;
			base._002Ector();
		}

		public bool IsMatch(T value, TView view)
		{
			return _003CisMatch_003EP(value, view);
		}
	}
}
