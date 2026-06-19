using System;
using System.Collections;
using System.Collections.Generic;

namespace Loxodon.Framework.Utilities
{
	[Obsolete("This type will be removed in version 3.0")]
	public class TransformEnumerator : IEnumerator
	{
		private IEnumerator enumerator;

		private Converter<object, object> converter;

		public object Current { get; private set; }

		public TransformEnumerator(IEnumerator enumerator, Converter<object, object> converter)
		{
			this.enumerator = enumerator;
			this.converter = converter;
		}

		public bool MoveNext()
		{
			if (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				Current = converter(current);
				return true;
			}
			return false;
		}

		public void Reset()
		{
			enumerator.Reset();
		}
	}
	[Obsolete("This type will be removed in version 3.0")]
	public class TransformEnumerator<TInput, TOutput> : IEnumerator<TOutput>, IEnumerator, IDisposable
	{
		private IEnumerator<TInput> enumerator;

		private Converter<TInput, TOutput> converter;

		private bool disposedValue;

		public TOutput Current { get; private set; }

		object IEnumerator.Current => Current;

		public TransformEnumerator(IEnumerator<TInput> enumerator, Converter<TInput, TOutput> converter)
		{
			this.enumerator = enumerator;
			this.converter = converter;
		}

		public bool MoveNext()
		{
			if (enumerator.MoveNext())
			{
				TInput current = enumerator.Current;
				Current = converter(current);
				return true;
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
				converter = null;
				disposedValue = true;
			}
		}

		~TransformEnumerator()
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
