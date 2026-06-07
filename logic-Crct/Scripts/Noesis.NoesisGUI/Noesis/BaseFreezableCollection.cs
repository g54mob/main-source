using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class BaseFreezableCollection : Animatable, IList, ICollection, IEnumerable
	{
		public struct Enumerator : IEnumerator
		{
			private BaseFreezableCollection _collection;

			private int _index;

			object IEnumerator.Current => null;

			public object Current => null;

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public Enumerator(BaseFreezableCollection c)
			{
				_collection = null;
				_index = 0;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		bool IList.IsReadOnly => false;

		bool IList.IsFixedSize => false;

		int ICollection.Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public object this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsReadOnly => false;

		public int Count => 0;

		internal new static BaseFreezableCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal BaseFreezableCollection(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BaseFreezableCollection obj)
		{
			return default(HandleRef);
		}

		protected BaseFreezableCollection()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		int IList.Add(object value)
		{
			return 0;
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		void IList.Clear()
		{
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		void ICollection.CopyTo(Array array, int arrayIndex)
		{
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void CopyTo(Array array, int arrayIndex)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public void Clear()
		{
		}

		private void Set(int index, object item)
		{
		}

		public int Add(object item)
		{
			return 0;
		}

		public int IndexOf(object item)
		{
			return 0;
		}

		public void Insert(int index, object item)
		{
		}

		public bool Contains(object item)
		{
			return false;
		}

		public bool Remove(object item)
		{
			return false;
		}

		private IntPtr Get(int index)
		{
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
