using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct gbmkQGYQBJkQigAOkFyXtSPuJCC
		{
			public TKey lkHEnJmwsWSjrdUbGbVVNDNqFNN;

			public TValue vlnXqrXZUnXUpcXPRJmvOerSEWc;

			public gbmkQGYQBJkQigAOkFyXtSPuJCC(TKey key, TValue value)
			{
				lkHEnJmwsWSjrdUbGbVVNDNqFNN = default(TKey);
				vlnXqrXZUnXUpcXPRJmvOerSEWc = default(TValue);
			}

			public KeyValuePair<TKey, TValue> vfztmGFWQUqxPOnMiPWDXOZRXqr()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

			private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

			private KeyValuePair<TKey, TValue> DNsUOSgZQrgrzaoVIbqmnEQQRth;

			private int woeAUThOnsHgFGJSJdSfOpWVSCFk;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				xEtYLjRlyaFxVFzULJXVkwKlXoN = null;
				JlrAzBENIRECxgCdFLuwrhGjahfJ = 0;
				UiqTlfTDmspVHfYAHGRajoEyhDZA = 0;
				DNsUOSgZQrgrzaoVIbqmnEQQRth = default(KeyValuePair<TKey, TValue>);
				woeAUThOnsHgFGJSJdSfOpWVSCFk = 0;
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Dispose()
			{
			}

			void IEnumerator.Reset()
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private IndexedDictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

				private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

				private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

				private TKey FZltWgEXMLkLkxodbQDztGWHwm;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					xEtYLjRlyaFxVFzULJXVkwKlXoN = null;
					UiqTlfTDmspVHfYAHGRajoEyhDZA = 0;
					JlrAzBENIRECxgCdFLuwrhGjahfJ = 0;
					FZltWgEXMLkLkxodbQDztGWHwm = default(TKey);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					return false;
				}

				void IEnumerator.Reset()
				{
				}
			}

			private IndexedDictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			public int Count => 0;

			bool ICollection<TKey>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public KeyCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TKey[] array, int index)
			{
			}

			void ICollection<TKey>.Add(TKey item)
			{
			}

			void ICollection<TKey>.Clear()
			{
			}

			bool ICollection<TKey>.Contains(TKey item)
			{
				return false;
			}

			bool ICollection<TKey>.Remove(TKey item)
			{
				return false;
			}

			IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation(rename = false)]
			[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

				private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

				private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

				private TValue ARZexnbPCYiFlhWTcRqBZWJClNh;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					xEtYLjRlyaFxVFzULJXVkwKlXoN = null;
					UiqTlfTDmspVHfYAHGRajoEyhDZA = 0;
					JlrAzBENIRECxgCdFLuwrhGjahfJ = 0;
					ARZexnbPCYiFlhWTcRqBZWJClNh = default(TValue);
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					return false;
				}

				void IEnumerator.Reset()
				{
				}
			}

			private IndexedDictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			public int Count => 0;

			bool ICollection<TValue>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public ValueCollection(IndexedDictionary<TKey, TValue> dictionary)
			{
			}

			public Enumerator GetEnumerator()
			{
				return default(Enumerator);
			}

			public void CopyTo(TValue[] array, int index)
			{
			}

			void ICollection<TValue>.Add(TValue item)
			{
			}

			bool ICollection<TValue>.Remove(TValue item)
			{
				return false;
			}

			void ICollection<TValue>.Clear()
			{
			}

			bool ICollection<TValue>.Contains(TValue item)
			{
				return false;
			}

			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}
		}

		private static readonly bool wmpDETicSjOwVzdQWXiqGlgSqjZw;

		private static readonly bool QdPrfCoFgbemGRgyiqkRNhxlFSl;

		private IEqualityComparer<TKey> oAwzJcqirSCBKhLGiewUfEvsJeyQ;

		private IEqualityComparer<TValue> AkreNYCjoIhBdHVNrCzBaToDMWGn;

		private readonly AList<gbmkQGYQBJkQigAOkFyXtSPuJCC> ghjvRRSxZjjKYYSVAMGRedLeMik;

		private readonly ADictionary<TKey, int> MYbBhMnIysBCNCCuUPhrdrVHEluX;

		private bool riGtgATytBcNpneyPRpxbJYpDbu;

		public int Count => 0;

		public bool ContainsDuplicateKeys => false;

		public bool AllowDuplicateKeys
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TValue this[int index]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		TValue IDictionary<TKey, TValue>.this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		bool IDictionary.IsFixedSize => false;

		bool IDictionary.IsReadOnly => false;

		ICollection IDictionary.Keys => null;

		ICollection IDictionary.Values => null;

		object IDictionary.this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int index] => default(TValue);

		int IReadOnlyList.Count => 0;

		object IReadOnlyList.this[int index] => null;

		public IndexedDictionary()
		{
		}

		public IndexedDictionary(int capacity)
		{
		}

		public IndexedDictionary(bool allowDuplicateKeys)
		{
		}

		public IndexedDictionary(int capacity, bool allowDuplicateKeys)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public IndexedDictionary(IDictionary<TKey, TValue> dictionary, bool allowDuplicateKeys)
		{
		}

		public TValue GetValue(TKey key)
		{
			return default(TValue);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public TKey GetKeyAt(int index)
		{
			return default(TKey);
		}

		public KeyValuePair<TKey, TValue> GetEntry(TKey key)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void SetValue(TKey key, TValue value)
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public void RemoveValue(TValue value)
		{
		}

		public int RemoveAll(TValue value)
		{
			return 0;
		}

		public int IndexOfKey(TKey key)
		{
			return 0;
		}

		public int IndexOfValue(TValue value)
		{
			return 0;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void TrimExcess()
		{
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Add(object key, object value)
		{
		}

		bool IDictionary.Contains(object key)
		{
			return false;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		void IDictionary.Remove(object key)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		private int hCnOosPUtXhEHhRynNgjODfxbntK(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hCnOosPUtXhEHhRynNgjODfxbntK
			return this.hCnOosPUtXhEHhRynNgjODfxbntK(P_0);
		}

		private bool EAHuDdWDHMLtxbNfFAoKjNxuGDbd(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EAHuDdWDHMLtxbNfFAoKjNxuGDbd
			return this.EAHuDdWDHMLtxbNfFAoKjNxuGDbd(P_0);
		}

		private int ZQsExVDhltPpMEFySXEIeXRusbob(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZQsExVDhltPpMEFySXEIeXRusbob
			return this.ZQsExVDhltPpMEFySXEIeXRusbob(P_0);
		}

		private bool KKzQNNLhsOHpUKoENGOJAoteyj(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KKzQNNLhsOHpUKoENGOJAoteyj
			return this.KKzQNNLhsOHpUKoENGOJAoteyj(P_0);
		}
	}
}
