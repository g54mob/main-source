using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Castle.Components.DictionaryAdapter
{
	[DebuggerDisplay("Count = {Count}, Adapter = {Adapter}")]
	[DebuggerTypeProxy(typeof(ListProjectionDebugView<>))]
	public class ListProjection<T> : IBindingList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IBindingListSource, ICancelAddNew, IRaiseItemChangedEvents, IBindingList, IList, ICollection, IEditableObject, IRevertibleChangeTracking, IChangeTracking, ICollectionProjection, ICollectionAdapterObserver<T>
	{
		private readonly ICollectionAdapter<T> adapter;

		private int addNewIndex = -1;

		private int addedIndex = -1;

		private int suspendLevel;

		private int changedIndex = -1;

		private PropertyChangedEventHandler propertyHandler;

		private static PropertyDescriptorCollection itemProperties;

		private const int NoIndex = -1;

		public int Count => adapter.Count;

		public IBindingList AsBindingList => this;

		public ICollectionAdapter<T> Adapter => adapter;

		public IEqualityComparer<T> Comparer => adapter.Comparer ?? EqualityComparer<T>.Default;

		bool IBindingList<T>.AllowEdit => true;

		bool IBindingList<T>.AllowNew => true;

		bool IBindingList<T>.AllowRemove => true;

		bool IBindingList<T>.SupportsChangeNotification => true;

		bool IBindingList<T>.SupportsSearching => false;

		bool IBindingList<T>.SupportsSorting => false;

		bool IBindingList<T>.IsSorted => false;

		System.ComponentModel.PropertyDescriptor IBindingList<T>.SortProperty => null;

		ListSortDirection IBindingList<T>.SortDirection => ListSortDirection.Ascending;

		bool IBindingList.AllowEdit => true;

		bool IBindingList.AllowNew => true;

		bool IBindingList.AllowRemove => true;

		bool IBindingList.SupportsChangeNotification => true;

		bool IBindingList.SupportsSearching => false;

		bool IBindingList.SupportsSorting => false;

		bool IBindingList.IsSorted => false;

		System.ComponentModel.PropertyDescriptor IBindingList.SortProperty => null;

		ListSortDirection IBindingList.SortDirection => ListSortDirection.Ascending;

		bool IRaiseItemChangedEvents.RaisesItemChangedEvents => true;

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		bool ICollection<T>.IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public T this[int index]
		{
			get
			{
				return adapter[index];
			}
			set
			{
				adapter[index] = value;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (T)value;
			}
		}

		public bool IsChanged
		{
			get
			{
				if (!adapter.HasSnapshot)
				{
					return false;
				}
				int count = Count;
				if (adapter.SnapshotCount != count)
				{
					return true;
				}
				IEqualityComparer<T> comparer = Comparer;
				for (int i = 0; i < count; i++)
				{
					T currentItem = adapter.GetCurrentItem(i);
					T snapshotItem = adapter.GetSnapshotItem(i);
					if (!comparer.Equals(currentItem, snapshotItem))
					{
						return true;
					}
					if (currentItem is IChangeTracking { IsChanged: not false })
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool EventsEnabled => suspendLevel == 0;

		public event ListChangedEventHandler ListChanged;

		public ListProjection(ICollectionAdapter<T> adapter)
		{
			if (adapter == null)
			{
				throw new ArgumentNullException("adapter");
			}
			this.adapter = adapter;
			adapter.Initialize(this);
		}

		public virtual bool Contains(T item)
		{
			return IndexOf(item) >= 0;
		}

		bool IList.Contains(object item)
		{
			return Contains((T)item);
		}

		public int IndexOf(T item)
		{
			int count = Count;
			IEqualityComparer<T> comparer = Comparer;
			for (int i = 0; i < count; i++)
			{
				if (comparer.Equals(this[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		int IList.IndexOf(object item)
		{
			return IndexOf((T)item);
		}

		public void CopyTo(T[] array, int index)
		{
			int count = Count;
			int num = 0;
			int num2 = index;
			while (num < count)
			{
				array[num2] = this[num];
				num++;
				num2++;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			CopyTo((T[])array, index);
		}

		public IEnumerator<T> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Replace(IEnumerable<T> items)
		{
			((ICollectionProjection)this).Replace((IEnumerable)items);
		}

		void ICollectionProjection.Replace(IEnumerable items)
		{
			SuspendEvents();
			try
			{
				Clear();
				foreach (T item in items)
				{
					Add(item);
				}
			}
			finally
			{
				ResumeEvents();
			}
		}

		protected virtual bool OnReplacing(T oldValue, T newValue)
		{
			return true;
		}

		bool ICollectionAdapterObserver<T>.OnReplacing(T oldValue, T newValue)
		{
			return OnReplacing(oldValue, newValue);
		}

		protected virtual void OnReplaced(T oldValue, T newValue, int index)
		{
			DetachPropertyChanged(oldValue);
			AttachPropertyChanged(newValue);
			NotifyListChanged(ListChangedType.ItemChanged, index);
		}

		void ICollectionAdapterObserver<T>.OnReplaced(T oldValue, T newValue, int index)
		{
			OnReplaced(oldValue, newValue, index);
		}

		public virtual T AddNew()
		{
			T result = adapter.AddNew();
			addNewIndex = addedIndex;
			return result;
		}

		object IBindingList.AddNew()
		{
			return AddNew();
		}

		public bool IsNew(int index)
		{
			if (index == addNewIndex)
			{
				return index >= 0;
			}
			return false;
		}

		public virtual void EndNew(int index)
		{
			if (IsNew(index))
			{
				addNewIndex = -1;
			}
		}

		public virtual void CancelNew(int index)
		{
			if (IsNew(index))
			{
				RemoveAt(addNewIndex);
				addNewIndex = -1;
			}
		}

		public virtual bool Add(T item)
		{
			return adapter.Add(item);
		}

		void ICollection<T>.Add(T item)
		{
			Add(item);
		}

		int IList.Add(object item)
		{
			Add((T)item);
			return addedIndex;
		}

		public void Insert(int index, T item)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			int count = Count;
			if (index > count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			EndNew(addNewIndex);
			if (index == count)
			{
				adapter.Add(item);
			}
			else
			{
				adapter.Insert(index, item);
			}
		}

		void IList.Insert(int index, object item)
		{
			Insert(index, (T)item);
		}

		protected virtual bool OnInserting(T value)
		{
			return true;
		}

		bool ICollectionAdapterObserver<T>.OnInserting(T value)
		{
			return OnInserting(value);
		}

		protected virtual void OnInserted(T newValue, int index)
		{
			addedIndex = index;
			AttachPropertyChanged(newValue);
			NotifyListChanged(ListChangedType.ItemAdded, index);
		}

		void ICollectionAdapterObserver<T>.OnInserted(T newValue, int index)
		{
			OnInserted(newValue, index);
		}

		public virtual bool Remove(T item)
		{
			int num = IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			RemoveAt(num);
			return true;
		}

		void IList.Remove(object value)
		{
			Remove((T)value);
		}

		public virtual void RemoveAt(int index)
		{
			EndNew(addNewIndex);
			adapter.Remove(index);
		}

		public virtual void Clear()
		{
			EndNew(addNewIndex);
			adapter.Clear();
			NotifyListReset();
		}

		void ICollectionProjection.ClearReferences()
		{
			adapter.ClearReferences();
		}

		protected virtual void OnRemoving(T oldValue)
		{
			DetachPropertyChanged(oldValue);
		}

		void ICollectionAdapterObserver<T>.OnRemoving(T oldValue)
		{
			OnRemoving(oldValue);
		}

		protected virtual void OnRemoved(T oldValue, int index)
		{
			NotifyListChanged(ListChangedType.ItemDeleted, index);
		}

		void ICollectionAdapterObserver<T>.OnRemoved(T oldValue, int index)
		{
			OnRemoved(oldValue, index);
		}

		public void BeginEdit()
		{
			if (!adapter.HasSnapshot)
			{
				adapter.SaveSnapshot();
			}
		}

		public void EndEdit()
		{
			adapter.DropSnapshot();
		}

		public void CancelEdit()
		{
			if (adapter.HasSnapshot)
			{
				adapter.LoadSnapshot();
				adapter.DropSnapshot();
				NotifyListReset();
			}
		}

		public void AcceptChanges()
		{
			BeginEdit();
		}

		public void RejectChanges()
		{
			CancelEdit();
		}

		private void AttachPropertyChanged(T value)
		{
			if (!typeof(T).GetTypeInfo().IsValueType && value is INotifyPropertyChanged notifyPropertyChanged)
			{
				if (propertyHandler == null)
				{
					propertyHandler = HandlePropertyChanged;
				}
				notifyPropertyChanged.PropertyChanged += propertyHandler;
			}
		}

		private void DetachPropertyChanged(T value)
		{
			if (!typeof(T).GetTypeInfo().IsValueType && value is INotifyPropertyChanged notifyPropertyChanged && propertyHandler != null)
			{
				notifyPropertyChanged.PropertyChanged -= propertyHandler;
			}
		}

		private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (EventsEnabled && CanHandle(sender, e) && TryGetChangedItem(sender, out var item) && TryGetChangedIndex(item))
			{
				System.ComponentModel.PropertyDescriptor changedProperty = GetChangedProperty(e);
				ListChangedEventArgs args = new ListChangedEventArgs(ListChangedType.ItemChanged, changedIndex, changedProperty);
				OnListChanged(args);
			}
		}

		private bool CanHandle(object sender, PropertyChangedEventArgs e)
		{
			if (sender == null || e == null || string.IsNullOrEmpty(e.PropertyName))
			{
				NotifyListReset();
				return false;
			}
			return true;
		}

		private bool TryGetChangedItem(object sender, out T item)
		{
			try
			{
				item = (T)sender;
				return true;
			}
			catch (InvalidCastException)
			{
				NotifyListReset();
				item = default(T);
				return false;
			}
		}

		private bool TryGetChangedIndex(T item)
		{
			if (changedIndex >= 0 && changedIndex < Count && Comparer.Equals(this[changedIndex], item))
			{
				return true;
			}
			changedIndex = IndexOf(item);
			if (changedIndex >= 0)
			{
				return true;
			}
			DetachPropertyChanged(item);
			NotifyListReset();
			return false;
		}

		private static System.ComponentModel.PropertyDescriptor GetChangedProperty(PropertyChangedEventArgs e)
		{
			if (itemProperties == null)
			{
				itemProperties = TypeDescriptor.GetProperties(typeof(T));
			}
			return itemProperties.Find(e.PropertyName, ignoreCase: true);
		}

		protected virtual void OnListChanged(ListChangedEventArgs args)
		{
			this.ListChanged?.Invoke(this, args);
		}

		protected void NotifyListChanged(ListChangedType type, int index)
		{
			if (EventsEnabled)
			{
				OnListChanged(new ListChangedEventArgs(type, index));
			}
		}

		protected void NotifyListReset()
		{
			if (EventsEnabled)
			{
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
			}
		}

		public void SuspendEvents()
		{
			suspendLevel++;
		}

		public bool ResumeEvents()
		{
			int num;
			if (suspendLevel != 0)
			{
				num = ((--suspendLevel == 0) ? 1 : 0);
				if (num == 0)
				{
					goto IL_0028;
				}
			}
			else
			{
				num = 1;
			}
			NotifyListReset();
			goto IL_0028;
			IL_0028:
			return (byte)num != 0;
		}

		void IBindingList<T>.AddIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}

		void IBindingList.AddIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}

		void IBindingList<T>.RemoveIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}

		void IBindingList.RemoveIndex(System.ComponentModel.PropertyDescriptor property)
		{
		}

		int IBindingList<T>.Find(System.ComponentModel.PropertyDescriptor property, object key)
		{
			throw new NotSupportedException();
		}

		int IBindingList.Find(System.ComponentModel.PropertyDescriptor property, object key)
		{
			throw new NotSupportedException();
		}

		void IBindingList<T>.ApplySort(System.ComponentModel.PropertyDescriptor property, ListSortDirection direction)
		{
			throw new NotSupportedException();
		}

		void IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor property, ListSortDirection direction)
		{
			throw new NotSupportedException();
		}

		void IBindingList<T>.RemoveSort()
		{
			throw new NotSupportedException();
		}

		void IBindingList.RemoveSort()
		{
			throw new NotSupportedException();
		}
	}
}
