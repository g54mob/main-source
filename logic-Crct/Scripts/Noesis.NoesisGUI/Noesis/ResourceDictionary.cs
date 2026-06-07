using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ResourceDictionary : BaseDictionary, IDictionary, ICollection, IEnumerable
	{
		public class Enumerator : IDictionaryEnumerator, IEnumerator
		{
			private ResourceDictionary _owner;

			private IEnumerator _keysEnumerator;

			object IEnumerator.Current => null;

			DictionaryEntry IDictionaryEnumerator.Entry => default(DictionaryEntry);

			object IDictionaryEnumerator.Key => null;

			object IDictionaryEnumerator.Value => null;

			internal Enumerator(ResourceDictionary owner)
			{
			}

			bool IEnumerator.MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private class KeysData
		{
			public object[] Keys;

			public int Index;
		}

		private delegate void ResourceDictionaryEnumKeysCallback(int id, string key);

		private class ValuesCollection : ICollection, IEnumerable
		{
			public class Enumerator : IEnumerator
			{
				private ResourceDictionary _owner;

				private IEnumerator _keysEnumerator;

				object IEnumerator.Current => null;

				internal Enumerator(ResourceDictionary owner)
				{
				}

				bool IEnumerator.MoveNext()
				{
					return false;
				}

				void IEnumerator.Reset()
				{
				}
			}

			private ResourceDictionary _owner;

			int ICollection.Count => 0;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => null;

			internal ValuesCollection(ResourceDictionary owner)
			{
			}

			void ICollection.CopyTo(Array array, int index)
			{
			}

			public Enumerator GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static ResourceDictionaryEnumKeysCallback _enumKeys;

		private static Dictionary<int, KeysData> _keysData;

		public object this[object key]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ICollection Keys => null;

		public ICollection Values => null;

		object ICollection.SyncRoot => null;

		public bool IsFixedSize => false;

		public bool IsSynchronized => false;

		public ResourceDictionaryCollection MergedDictionaries => null;

		public Uri Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Count => 0;

		public bool IsReadOnly => false;

		internal new static ResourceDictionary CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ResourceDictionary(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ResourceDictionary obj)
		{
			return default(HandleRef);
		}

		public bool Contains(object key)
		{
			return false;
		}

		public void Add(object key, object value)
		{
		}

		public void Remove(object key)
		{
		}

		public Enumerator GetEnumerator()
		{
			return null;
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		private string GetValidKey(object key)
		{
			return null;
		}

		[PreserveSig]
		private static extern void ResourceDictionary_EnumKeys(HandleRef dictionary, int id, ResourceDictionaryEnumKeysCallback callback);

		[MonoPInvokeCallback(typeof(ResourceDictionaryEnumKeysCallback))]
		private static void OnEnumKeys(int id, string key)
		{
		}

		public void CopyTo(DictionaryEntry[] array, int index)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		public ResourceDictionary()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void Clear()
		{
		}

		private IntPtr GetValueHelper(string key)
		{
			return (IntPtr)0;
		}

		private void SetValueHelper(string key, object value)
		{
		}

		private bool ContainsHelper(string key)
		{
			return false;
		}

		private void AddHelper(string key, object value)
		{
		}

		private void RemoveHelper(string key)
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
