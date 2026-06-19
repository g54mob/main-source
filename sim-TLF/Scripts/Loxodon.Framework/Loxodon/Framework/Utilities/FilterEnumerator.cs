using System;
using System.Collections;
using System.Collections.Generic;

namespace Loxodon.Framework.Utilities
{
	[Obsolete("This type will be removed in version 3.0")]
	public class FilterEnumerator : IEnumerator
	{
		private IEnumerator enumerator;

		private Predicate<object> match;

		public object Current { get; private set; }

		public FilterEnumerator(IEnumerator enumerator, Predicate<object> match)
		{
			this.enumerator = enumerator;
			this.match = match;
		}

		public bool MoveNext()
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (match(current))
				{
					Current = current;
					return true;
				}
			}
			return false;
		}

		public void Reset()
		{
			enumerator.Reset();
		}
	}
	[Obsolete("This type will be removed in version 3.0")]
	public class FilterEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
	{
		private IEnumerator<T> enumerator;

		private Predicate<T> match;

		private bool disposedValue;

		public T Current { get; private set; }

		object IEnumerator.Current => Current;

		public FilterEnumerator(IEnumerator<T> enumerator, Predicate<T> match)
		{
			Current = default(T);
			this.enumerator = enumerator;
			this.match = match;
		}

		public bool MoveNext()
		{
			while (enumerator.MoveNext())
			{
				T current = enumerator.Current;
				if (match(current))
				{
					Current = current;
					return true;
				}
			}
			return false;
		}

		public void Reset()
		{
			enumerator.Reset();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				Reset();
				enumerator = null;
				match = null;
				disposedValue = true;
			}
		}

		~FilterEnumerator()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
