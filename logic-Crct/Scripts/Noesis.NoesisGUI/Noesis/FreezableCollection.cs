using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FreezableCollection<T> : BaseFreezableCollection, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged where T : DependencyObject
	{
		private class SimpleMonitor : IDisposable
		{
			private int _busyCount;

			public bool Busy => false;

			public void Enter()
			{
			}

			public void Dispose()
			{
			}
		}

		public new struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private FreezableCollection<T> _collection;

			private int _index;

			object IEnumerator.Current => null;

			public T Current => null;

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

			public Enumerator(FreezableCollection<T> c)
			{
				_collection = null;
				_index = 0;
			}
		}

		private SimpleMonitor _monitor;

		public new T this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		int ICollection<T>.Count => 0;

		bool ICollection<T>.IsReadOnly => false;

		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected FreezableCollection()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal FreezableCollection(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FreezableCollection<T> obj)
		{
			return default(HandleRef);
		}

		public void Add(T item)
		{
		}

		public new void Clear()
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public void Insert(int index, T item)
		{
		}

		public bool Remove(T item)
		{
			return false;
		}

		public new void RemoveAt(int index)
		{
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
		}

		private IDisposable BlockReentrancy()
		{
			return null;
		}

		private void CheckReentrancy()
		{
		}

		int IList<T>.IndexOf(T item)
		{
			return 0;
		}

		void IList<T>.Insert(int index, T item)
		{
		}

		void IList<T>.RemoveAt(int index)
		{
		}

		void ICollection<T>.Add(T item)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Contains(T item)
		{
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
		}

		bool ICollection<T>.Remove(T item)
		{
			return false;
		}

		public new Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}
	}
}
