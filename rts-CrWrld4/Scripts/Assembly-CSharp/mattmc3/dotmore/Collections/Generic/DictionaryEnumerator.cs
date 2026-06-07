using System;
using System.Collections;
using System.Collections.Generic;

namespace mattmc3.dotmore.Collections.Generic
{
	public class DictionaryEnumerator<TKey, TValue> : IDictionaryEnumerator, IEnumerator, IDisposable
	{
		private readonly IEnumerator<KeyValuePair<TKey, TValue>> _impl;

		public DictionaryEntry Entry => default(DictionaryEntry);

		public object Key => null;

		public object Value => null;

		public object Current => null;

		public void Dispose()
		{
		}

		public DictionaryEnumerator(IDictionary<TKey, TValue> value)
		{
		}

		public void Reset()
		{
		}

		public bool MoveNext()
		{
			return false;
		}
	}
}
