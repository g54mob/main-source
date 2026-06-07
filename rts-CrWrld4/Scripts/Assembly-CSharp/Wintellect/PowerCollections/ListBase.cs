using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public abstract class ListBase<T> : CollectionBase<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
	{
		public abstract override int Count { get; }

		public abstract T Item { get; set; }

		bool IList.IsFixedSize => false;

		bool IList.IsReadOnly => false;

		object IList.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract override void Clear();

		public abstract void Insert(int index, T item);

		public abstract void RemoveAt(int index);

		public override IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public override bool Contains(T item)
		{
			return false;
		}

		public override void Add(T item)
		{
		}

		public override bool Remove(T item)
		{
			return false;
		}

		public virtual void CopyTo(T[] array)
		{
		}

		public virtual void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
		}

		public new virtual IList<T> AsReadOnly()
		{
			return null;
		}

		public virtual T Find(Predicate<T> predicate)
		{
			return default(T);
		}

		public virtual bool TryFind(Predicate<T> predicate, out T foundItem)
		{
			foundItem = default(T);
			return false;
		}

		public virtual T FindLast(Predicate<T> predicate)
		{
			return default(T);
		}

		public virtual bool TryFindLast(Predicate<T> predicate, out T foundItem)
		{
			foundItem = default(T);
			return false;
		}

		public virtual int FindIndex(Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int FindIndex(int index, Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int FindIndex(int index, int count, Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int FindLastIndex(Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int FindLastIndex(int index, Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int FindLastIndex(int index, int count, Predicate<T> predicate)
		{
			return 0;
		}

		public virtual int IndexOf(T item)
		{
			return 0;
		}

		public virtual int IndexOf(T item, int index)
		{
			return 0;
		}

		public virtual int IndexOf(T item, int index, int count)
		{
			return 0;
		}

		public virtual int LastIndexOf(T item)
		{
			return 0;
		}

		public virtual int LastIndexOf(T item, int index)
		{
			return 0;
		}

		public virtual int LastIndexOf(T item, int index, int count)
		{
			return 0;
		}

		public virtual IList<T> Range(int start, int count)
		{
			return null;
		}

		private static T ConvertToItemType(string name, object value)
		{
			return default(T);
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

		void IList.RemoveAt(int index)
		{
		}
	}
}
