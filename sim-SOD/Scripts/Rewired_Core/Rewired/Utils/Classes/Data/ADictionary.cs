using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ADictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal struct Entry
		{
			public int hashCode;

			public int next;

			public TKey key;

			public TValue value;
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private ADictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

			private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

			private KeyValuePair<TKey, TValue> DNsUOSgZQrgrzaoVIbqmnEQQRth;

			private int woeAUThOnsHgFGJSJdSfOpWVSCFk;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(ADictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
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
				private ADictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

				private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

				private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

				private TKey FZltWgEXMLkLkxodbQDztGWHwm;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
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

			private ADictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			public int Count => 0;

			bool ICollection<TKey>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public KeyCollection(ADictionary<TKey, TValue> dictionary)
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
				private ADictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

				private int UiqTlfTDmspVHfYAHGRajoEyhDZA;

				private int JlrAzBENIRECxgCdFLuwrhGjahfJ;

				private TValue ARZexnbPCYiFlhWTcRqBZWJClNh;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(ADictionary<TKey, TValue> dictionary)
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

			private ADictionary<TKey, TValue> xEtYLjRlyaFxVFzULJXVkwKlXoN;

			public int Count => 0;

			bool ICollection<TValue>.IsReadOnly => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			public ValueCollection(ADictionary<TKey, TValue> dictionary)
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

		private const string AeJLPZCVlefhzdcdrhhZzLYCCHD = "Version";

		private const string GaxeyAycgzCedCvbFXMtPVuushE = "HashSize";

		private const string SbgEURWUQWeYEixCCVLqhiLPZkvr = "KeyValuePairs";

		private const string WSbTVSFUgCSsQEIbCWliMdYuSia = "Comparer";

		private int[] OFbTlHhNcoERTiuiZcTydEmyVKZC;

		internal Entry[] _entries;

		internal int _count;

		private int UzDCLPHgqxwDwXMIxioeAcIRYMw;

		private int MPcUQKZQnhWOuIkDcrkUPrsjCyX;

		private int zxMeVAqxRxQwKvZsFosVNqKdqLZ;

		private int tFTflVJIQKFEosqURRbKGwPsnly;

		private IEqualityComparer<TKey> oAwzJcqirSCBKhLGiewUfEvsJeyQ;

		private IEqualityComparer<TValue> AkreNYCjoIhBdHVNrCzBaToDMWGn;

		private KeyCollection zekuRYZTHMOsPDNCDbiHUFeRqnA;

		private ValueCollection OquwkIkLOngHmwmqrXKtMNUBoCY;

		private readonly object TyokAbDvOqKKlBSLmQdUiMlDedf;

		private static readonly bool wmpDETicSjOwVzdQWXiqGlgSqjZw;

		private static readonly bool QdPrfCoFgbemGRgyiqkRNhxlFSl;

		public int Count => 0;

		public int TotalCount => 0;

		public KeyCollection Keys => null;

		public ValueCollection Values => null;

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

		public TValue this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public int IndexOfFirst => 0;

		public int IndexOfLast => 0;

		ICollection<TKey> IDictionary<TKey, TValue>.Keys => null;

		ICollection<TValue> IDictionary<TKey, TValue>.Values => null;

		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

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

		public ADictionary()
		{
		}

		public ADictionary(IEqualityComparer<TKey> keyComparer)
		{
		}

		public ADictionary(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
		}

		public ADictionary(int capacity)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer)
		{
		}

		public ADictionary(int capacity, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer)
		{
		}

		public ADictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public void Clear()
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool ContainsValue(TValue value)
		{
			return false;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public TValue GetValueSafe(TKey key)
		{
			return default(TValue);
		}

		public int IndexOfKey(TKey key)
		{
			return 0;
		}

		public int IndexOfValue(TValue value)
		{
			return 0;
		}

		public bool IsValidAt(int index)
		{
			return false;
		}

		public TKey GetKeyAt(int index)
		{
			return default(TKey);
		}

		public TValue GetValueAt(int index)
		{
			return default(TValue);
		}

		public KeyValuePair<TKey, TValue> GetEntryAt(int index)
		{
			return default(KeyValuePair<TKey, TValue>);
		}

		public bool TryGetKeyAt(int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool TryGetValueAt(int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetNextIndex(ref int index)
		{
			return false;
		}

		public int GetNextIndex(int index)
		{
			return 0;
		}

		public bool GetNextKey(ref int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool GetNextValue(ref int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool GetPreviousIndex(ref int index)
		{
			return false;
		}

		public int GetPreviousIndex(int index)
		{
			return 0;
		}

		public bool GetPreviousKey(ref int index, out TKey key)
		{
			key = default(TKey);
			return false;
		}

		public bool GetPreviousValue(ref int index, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
		{
			entry = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		public bool RemoveAt(int index)
		{
			return false;
		}

		private void DFwIFzOHUCeicjzMEnXgduELPsr(KeyValuePair<TKey, TValue>[] P_0, int P_1)
		{
		}

		private void yevEaEOpxaTseresMwWwEaZGFmnj(int P_0)
		{
		}

		private void UueOYVdKhOcjqpWdALRbATjVwZi(TKey P_0, TValue P_1, bool P_2)
		{
		}

		private void iWlwwhvYsQuuNwiGnLdVXCxociHA()
		{
		}

		private void iWlwwhvYsQuuNwiGnLdVXCxociHA(int P_0, bool P_1)
		{
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return null;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
		{
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
		{
			return false;
		}

		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
		{
			return false;
		}

		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
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

		private static bool bwBulweDAdVWfPrxjSOArKZzrYR(object P_0)
		{
			return false;
		}

		private static void vtvaBVMtMrEcUiXEcxLMPCarPiIl<T>(object P_0, string P_1)
		{
		}
	}
}
