using System;

namespace ObservableCollections
{
	internal class SynchronizedViewValueOnlyFilter<T, TView> : ISynchronizedViewFilter<T, TView>
	{
		private class NullViewFilter : ISynchronizedViewFilter<T, TView>
		{
			public bool IsMatch(T value, TView view)
			{
				return true;
			}
		}

		public SynchronizedViewValueOnlyFilter(Func<T, bool> isMatch)
		{
			_003CisMatch_003EP = isMatch;
			base._002Ector();
		}

		public bool IsMatch(T value, TView view)
		{
			return _003CisMatch_003EP(value);
		}
	}
}
