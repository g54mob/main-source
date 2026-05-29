using System;
using System.Collections;
using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	public struct DictionaryEntryEnumerator : IEnumerator<DictionaryEntry>, IEnumerator, IDisposable
	{
		private Dictionary<object, object>.Enumerator enumerator;

		object IEnumerator.Current => null;

		public DictionaryEntry Current => default(DictionaryEntry);

		public object Key => null;

		public object Value => null;

		public DictionaryEntryEnumerator(Dictionary<object, object>.Enumerator original)
		{
			enumerator = default(Dictionary<object, object>.Enumerator);
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
