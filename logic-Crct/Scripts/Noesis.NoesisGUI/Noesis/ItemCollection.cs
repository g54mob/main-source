using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ItemCollection : BaseComponent, IList, ICollection, IEnumerable
	{
		public struct Enumerator : IEnumerator
		{
			private ItemCollection _collection;

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

			public Enumerator(ItemCollection c)
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

		public bool CanFilter => false;

		public bool CanGroup => false;

		public bool CanSort => false;

		public object CurrentItem => null;

		public int CurrentPosition => 0;

		public bool IsCurrentAfterLast => false;

		public bool IsCurrentBeforeFirst => false;

		public bool IsEmpty => false;

		public int Count => 0;

		internal new static ItemCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ItemCollection(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ItemCollection obj)
		{
			return default(HandleRef);
		}

		protected ItemCollection()
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

		public object GetItemAt(int index)
		{
			return null;
		}

		private void CopyTo(Array array, int arrayIndex)
		{
		}

		public ItemCollection(ItemsControl itemsControl)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private void Set(int index, object item)
		{
		}

		public int Add(object item)
		{
			return 0;
		}

		public void Insert(int index, object item)
		{
		}

		public int IndexOf(object item)
		{
			return 0;
		}

		public bool Remove(object item)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(object item)
		{
			return false;
		}

		public bool MoveCurrentTo(object item)
		{
			return false;
		}

		public bool MoveCurrentToFirst()
		{
			return false;
		}

		public bool MoveCurrentToLast()
		{
			return false;
		}

		public bool MoveCurrentToNext()
		{
			return false;
		}

		public bool MoveCurrentToPosition(int position)
		{
			return false;
		}

		public bool MoveCurrentToPrevious()
		{
			return false;
		}

		public void Refresh()
		{
		}

		private IntPtr GetItemAtHelper(int index)
		{
			return (IntPtr)0;
		}
	}
}
