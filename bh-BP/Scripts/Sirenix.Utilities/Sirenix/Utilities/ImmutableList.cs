using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Sirenix.Utilities
{
	[Serializable]
	public sealed class ImmutableList : IImmutableList<object>, IImmutableList, IList, ICollection, IEnumerable, IList<object>, ICollection<object>, IEnumerable<object>
	{
		[CompilerGenerated]
		private sealed class _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CSystem_002DObject_003E_002DGetEnumerator_003Ed__25 : IEnumerator<object>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ImmutableList _003C_003E4__this;

			private IEnumerator _003C_003E7__wrap1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CSystem_002DObject_003E_002DGetEnumerator_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private IList innerList;

		public int Count => 0;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public bool IsSynchronized => false;

		public object SyncRoot => null;

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

		object IList<object>.this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object this[int index] => null;

		public ImmutableList(IList innerList)
		{
		}

		public bool Contains(object value)
		{
			return false;
		}

		public void CopyTo(object[] array, int arrayIndex)
		{
		}

		public void CopyTo(Array array, int index)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CSystem_002DObject_003E_002DGetEnumerator_003Ed__25))]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
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

		public int IndexOf(object value)
		{
			return 0;
		}

		void IList<object>.RemoveAt(int index)
		{
		}

		void IList<object>.Insert(int index, object item)
		{
		}

		void ICollection<object>.Add(object item)
		{
		}

		void ICollection<object>.Clear()
		{
		}

		bool ICollection<object>.Remove(object item)
		{
			return false;
		}
	}
	[Serializable]
	public sealed class ImmutableList<T> : IImmutableList<T>, IImmutableList, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>
	{
		[SerializeField]
		private IList<T> innerList;

		public int Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		public bool IsReadOnly => false;

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

		T IList<T>.this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public T this[int index] => default(T);

		public ImmutableList(IList<T> innerList)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		void ICollection<T>.Add(T item)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Remove(T item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			return false;
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

		void IList<T>.Insert(int index, T item)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		void IList<T>.RemoveAt(int index)
		{
		}
	}
	[Serializable]
	public sealed class ImmutableList<TList, TElement> : IImmutableList<TElement>, IImmutableList, IList, ICollection, IEnumerable, IList<TElement>, ICollection<TElement>, IEnumerable<TElement> where TList : IList<TElement>
	{
		private TList innerList;

		public int Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		public bool IsReadOnly => false;

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

		TElement IList<TElement>.this[int index]
		{
			get
			{
				return default(TElement);
			}
			set
			{
			}
		}

		public TElement this[int index] => default(TElement);

		public ImmutableList(TList innerList)
		{
		}

		public bool Contains(TElement item)
		{
			return false;
		}

		public void CopyTo(TElement[] array, int arrayIndex)
		{
		}

		public IEnumerator<TElement> GetEnumerator()
		{
			return null;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		void ICollection<TElement>.Add(TElement item)
		{
		}

		void ICollection<TElement>.Clear()
		{
		}

		bool ICollection<TElement>.Remove(TElement item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		void IList.Clear()
		{
		}

		bool IList.Contains(object value)
		{
			return false;
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

		void IList<TElement>.Insert(int index, TElement item)
		{
		}

		void IList.RemoveAt(int index)
		{
		}

		public int IndexOf(TElement item)
		{
			return 0;
		}

		void IList<TElement>.RemoveAt(int index)
		{
		}
	}
}
