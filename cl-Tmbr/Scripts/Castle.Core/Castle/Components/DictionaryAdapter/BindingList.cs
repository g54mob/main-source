using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class BindingList<T> : IBindingList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IBindingListSource, ICancelAddNew, IRaiseItemChangedEvents, IList, ICollection
	{
		private readonly System.ComponentModel.BindingList<T> list;

		public System.ComponentModel.BindingList<T> InnerList => list;

		public IBindingList AsBindingList => list;

		public int Count => list.Count;

		bool ICollection<T>.IsReadOnly => ((ICollection<T>)list).IsReadOnly;

		bool IList.IsReadOnly => ((IList)list).IsReadOnly;

		bool IList.IsFixedSize => ((IList)list).IsFixedSize;

		bool ICollection.IsSynchronized => ((ICollection)list).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)list).SyncRoot;

		public bool AllowNew
		{
			get
			{
				return list.AllowNew;
			}
			set
			{
				list.AllowNew = value;
			}
		}

		public bool AllowEdit
		{
			get
			{
				return list.AllowEdit;
			}
			set
			{
				list.AllowEdit = value;
			}
		}

		public bool AllowRemove
		{
			get
			{
				return list.AllowRemove;
			}
			set
			{
				list.AllowRemove = value;
			}
		}

		public bool RaiseListChangedEvents
		{
			get
			{
				return list.RaiseListChangedEvents;
			}
			set
			{
				list.RaiseListChangedEvents = value;
			}
		}

		bool IRaiseItemChangedEvents.RaisesItemChangedEvents => ((IRaiseItemChangedEvents)list).RaisesItemChangedEvents;

		bool IBindingList<T>.SupportsChangeNotification => AsBindingList.SupportsChangeNotification;

		bool IBindingList<T>.SupportsSearching => AsBindingList.SupportsSearching;

		bool IBindingList<T>.SupportsSorting => AsBindingList.SupportsSorting;

		bool IBindingList<T>.IsSorted => AsBindingList.IsSorted;

		System.ComponentModel.PropertyDescriptor IBindingList<T>.SortProperty => AsBindingList.SortProperty;

		ListSortDirection IBindingList<T>.SortDirection => AsBindingList.SortDirection;

		public T this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return ((IList)list)[index];
			}
			set
			{
				((IList)list)[index] = value;
			}
		}

		public event AddingNewEventHandler AddingNew
		{
			add
			{
				list.AddingNew += value;
			}
			remove
			{
				list.AddingNew -= value;
			}
		}

		public event ListChangedEventHandler ListChanged
		{
			add
			{
				list.ListChanged += value;
			}
			remove
			{
				list.ListChanged -= value;
			}
		}

		public BindingList()
		{
			list = new System.ComponentModel.BindingList<T>();
		}

		public BindingList(IList<T> list)
		{
			this.list = new System.ComponentModel.BindingList<T>(list);
		}

		public BindingList(System.ComponentModel.BindingList<T> list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}
			this.list = list;
		}

		int IBindingList<T>.Find(System.ComponentModel.PropertyDescriptor property, object key)
		{
			return AsBindingList.Find(property, key);
		}

		void IBindingList<T>.AddIndex(System.ComponentModel.PropertyDescriptor property)
		{
			AsBindingList.AddIndex(property);
		}

		void IBindingList<T>.RemoveIndex(System.ComponentModel.PropertyDescriptor property)
		{
			AsBindingList.RemoveIndex(property);
		}

		void IBindingList<T>.ApplySort(System.ComponentModel.PropertyDescriptor property, ListSortDirection direction)
		{
			AsBindingList.ApplySort(property, direction);
		}

		void IBindingList<T>.RemoveSort()
		{
			AsBindingList.RemoveSort();
		}

		public bool Contains(T item)
		{
			return list.Contains(item);
		}

		bool IList.Contains(object value)
		{
			return ((IList)list).Contains(value);
		}

		public int IndexOf(T item)
		{
			return list.IndexOf(item);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)list).IndexOf(value);
		}

		public void CopyTo(T[] array, int index)
		{
			list.CopyTo(array, index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)list).CopyTo(array, index);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public T AddNew()
		{
			return list.AddNew();
		}

		public void CancelNew(int index)
		{
			list.CancelNew(index);
		}

		public void EndNew(int index)
		{
			list.EndNew(index);
		}

		public void Add(T item)
		{
			list.Add(item);
		}

		int IList.Add(object item)
		{
			return ((IList)list).Add(item);
		}

		public void Insert(int index, T item)
		{
			list.Insert(index, item);
		}

		void IList.Insert(int index, object item)
		{
			((IList)list).Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public bool Remove(T item)
		{
			return list.Remove(item);
		}

		void IList.Remove(object item)
		{
			((IList)list).Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		public void ResetBindings()
		{
			list.ResetBindings();
		}

		public void ResetItem(int index)
		{
			list.ResetItem(index);
		}
	}
}
