using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class SelectionChangedEventArgs : RoutedEventArgs
	{
		private struct ListWrapper : IList, ICollection, IEnumerable
		{
			private struct ListWrapperEnumerator : IEnumerator
			{
				private ListWrapper _list;

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

				public ListWrapperEnumerator(ListWrapper l)
				{
					_list = default(ListWrapper);
					_index = 0;
				}
			}

			private SelectionChangedEventArgs _e;

			private int _listId;

			public bool IsFixedSize => false;

			public bool IsReadOnly => false;

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

			public int Count => 0;

			public bool IsSynchronized => false;

			public object SyncRoot => null;

			public ListWrapper(SelectionChangedEventArgs e, int listId)
			{
				_e = null;
				_listId = 0;
			}

			public int Add(object value)
			{
				return 0;
			}

			public void Clear()
			{
			}

			public bool Contains(object value)
			{
				return false;
			}

			public int IndexOf(object value)
			{
				return 0;
			}

			public void Insert(int index, object value)
			{
			}

			public void Remove(object value)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public void CopyTo(Array array, int index)
			{
			}

			public IEnumerator GetEnumerator()
			{
				return null;
			}
		}

		private HandleRef swigCPtr;

		public IList AddedItems => null;

		public IList RemovedItems => null;

		internal SelectionChangedEventArgs(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(SelectionChangedEventArgs obj)
		{
			return default(HandleRef);
		}

		~SelectionChangedEventArgs()
		{
		}

		public override void Dispose()
		{
		}

		internal new static void InvokeHandler(Delegate handler, IntPtr sender, IntPtr args)
		{
		}

		public SelectionChangedEventArgs(object source)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		private bool ContainsListHelper(int listId, object value)
		{
			return false;
		}

		private int IndexOfListHelper(int listId, object value)
		{
			return 0;
		}

		private object GetItemListHelper(int listId, int index)
		{
			return null;
		}

		private int CountListHelper(int listId)
		{
			return 0;
		}
	}
}
