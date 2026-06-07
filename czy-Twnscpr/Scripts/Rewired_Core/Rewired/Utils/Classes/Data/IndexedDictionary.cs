using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class IndexedDictionary<TKey, TValue> : IEnumerable, IDictionary, ICollection, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
	{
		private struct rxDoWpauphDfsgVOmMopBdeBMLQ
		{
			public TKey kQodDuMAAeBazfvtQeWnifiLRRBv;

			public TValue goUQCKzJmFEdxabJRHcPmEGvlCq;

			public rxDoWpauphDfsgVOmMopBdeBMLQ(TKey key, TValue value)
			{
				kQodDuMAAeBazfvtQeWnifiLRRBv = default(TKey);
				goUQCKzJmFEdxabJRHcPmEGvlCq = default(TValue);
			}

			public KeyValuePair<TKey, TValue> iBCqFlnyeoPzVKzSqAepvfyiGJxa()
			{
				return default(KeyValuePair<TKey, TValue>);
			}
		}

		[Serializable]
		[CustomClassObfuscation]
		[CustomObfuscation]
		public struct Enumerator : IDisposable, IEnumerator, IDictionaryEnumerator, IEnumerator<KeyValuePair<TKey, TValue>>
		{
			internal const int DictEntry = 1;

			internal const int KeyValuePair = 2;

			private IndexedDictionary<TKey, TValue> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

			private int IMEPkinypdXGfEKhNFFETqbVnrl;

			private int NLVTHAlcYUOUXlkWNcQMDFfDJvH;

			private KeyValuePair<TKey, TValue> SvDJmbKfwTjjfajTMZMARNttaRfc;

			private int jqTaiekJSOtKTTKizhrBDrhlGyL;

			public KeyValuePair<TKey, TValue> Current => default(KeyValuePair<TKey, TValue>);

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(IndexedDictionary<TKey, TValue> dictionary, int getEnumeratorRetType)
			{
				iHWfZKxYOWmGDbHEFecrCgvIBgZ = null;
				IMEPkinypdXGfEKhNFFETqbVnrl = 0;
				NLVTHAlcYUOUXlkWNcQMDFfDJvH = 0;
				SvDJmbKfwTjjfajTMZMARNttaRfc = default(KeyValuePair<TKey, TValue>);
				jqTaiekJSOtKTTKizhrBDrhlGyL = 0;
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
		[CustomObfuscation]
		[CustomClassObfuscation]
		public sealed class KeyCollection : IEnumerable, ICollection, IEnumerable<TKey>, ICollection<TKey>
		{
			[Serializable]
			[CustomClassObfuscation]
			[CustomObfuscation]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TKey>
			{
				private IndexedDictionary<TKey, TValue> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

				private int NLVTHAlcYUOUXlkWNcQMDFfDJvH;

				private int IMEPkinypdXGfEKhNFFETqbVnrl;

				private TKey OYaFZjHaliepRNainuzhHLbxfakE;

				public TKey Current => default(TKey);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					iHWfZKxYOWmGDbHEFecrCgvIBgZ = null;
					NLVTHAlcYUOUXlkWNcQMDFfDJvH = 0;
					IMEPkinypdXGfEKhNFFETqbVnrl = 0;
					OYaFZjHaliepRNainuzhHLbxfakE = default(TKey);
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

			private IndexedDictionary<TKey, TValue> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

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
		[CustomClassObfuscation]
		[CustomObfuscation]
		public sealed class ValueCollection : IEnumerable, ICollection, ICollection<TValue>, IEnumerable<TValue>
		{
			[Serializable]
			[CustomObfuscation]
			[CustomClassObfuscation]
			public struct Enumerator : IDisposable, IEnumerator, IEnumerator<TValue>
			{
				private IndexedDictionary<TKey, TValue> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

				private int NLVTHAlcYUOUXlkWNcQMDFfDJvH;

				private int IMEPkinypdXGfEKhNFFETqbVnrl;

				private TValue DXwdVAVkmscKjxJZmVNxtgmlZFz;

				public TValue Current => default(TValue);

				object IEnumerator.Current => null;

				internal Enumerator(IndexedDictionary<TKey, TValue> dictionary)
				{
					iHWfZKxYOWmGDbHEFecrCgvIBgZ = null;
					NLVTHAlcYUOUXlkWNcQMDFfDJvH = 0;
					IMEPkinypdXGfEKhNFFETqbVnrl = 0;
					DXwdVAVkmscKjxJZmVNxtgmlZFz = default(TValue);
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

			private IndexedDictionary<TKey, TValue> iHWfZKxYOWmGDbHEFecrCgvIBgZ;

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

		private static readonly bool pAAoCeActFbTPhCbYNwMFPnplCT;

		private static readonly bool PlwJFlUIMBWhWLQuyAZbtNCMKAx;

		private IEqualityComparer<TKey> pwFlNNCaXuSUKxICyKJayAUFWao;

		private IEqualityComparer<TValue> PqYCplmqYcbGjBBNvtEbnfLmXGWE;

		private readonly AList<rxDoWpauphDfsgVOmMopBdeBMLQ> pBSJXwgNlTTyOSmIIhptQeyZcCmj;

		private readonly ADictionary<TKey, int> JsQfVzFoOCiXZMpcEdCZgJedqto;

		private bool qLjORvzgLtQolbeuVMQBHafIIjc;

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

		public TValue Item
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

		TValue IDictionary<TKey, TValue>.Item
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

		object IDictionary.Item
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

		TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Item => default(TValue);

		int IReadOnlyList.Count => 0;

		object IReadOnlyList.Item => null;

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

		private int yTYUgLxrFxVTVhEizVpHucCUald(TValue P_0)
		{
			return 0;
		}

		int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yTYUgLxrFxVTVhEizVpHucCUald
			return this.yTYUgLxrFxVTVhEizVpHucCUald(P_0);
		}

		private bool XQijwYqxWsgFrhtuFTzkXOFBHhn(TValue P_0)
		{
			return false;
		}

		bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XQijwYqxWsgFrhtuFTzkXOFBHhn
			return this.XQijwYqxWsgFrhtuFTzkXOFBHhn(P_0);
		}

		private int UDHAwBCJReSIZzeKhfwxWsJnoq(object P_0)
		{
			return 0;
		}

		int IReadOnlyList.IndexOf(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UDHAwBCJReSIZzeKhfwxWsJnoq
			return this.UDHAwBCJReSIZzeKhfwxWsJnoq(P_0);
		}

		private bool XqzfNgfvNAcZfkOiOwwuglJKCazA(object P_0)
		{
			return false;
		}

		bool IReadOnlyList.Contains(object P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XqzfNgfvNAcZfkOiOwwuglJKCazA
			return this.XqzfNgfvNAcZfkOiOwwuglJKCazA(P_0);
		}
	}
}
