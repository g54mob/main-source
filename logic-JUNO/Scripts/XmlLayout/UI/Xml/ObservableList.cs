using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UI.Xml
{
	public class ObservableList<T> : List<T>, IObservableList, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : class
	{
		public Dictionary<string, T> itemGuids = new Dictionary<string, T>();

		private Type _itemType;

		public string guid { get; set; }

		public new T this[int index]
		{
			get
			{
				if (base[index] is ObservableListItem)
				{
					return ObservableListItemProxy<T>.Create(base[index], this);
				}
				return base[index];
			}
			set
			{
				string gUID = GetGUID(base[index]);
				base[index] = value;
				itemGuids[gUID] = value;
				this.itemChanged(index, value, null);
			}
		}

		object IObservableList.this[int index]
		{
			get
			{
				if (base[index] is ObservableListItem || base[index] is Dictionary<string, string>)
				{
					return ObservableListItemProxy<T>.Create(base[index], this);
				}
				return base[index];
			}
			set
			{
				string gUID = GetGUID(base[index]);
				base[index] = (T)value;
				itemGuids[gUID] = (T)value;
				this.itemChanged(index, value, null);
			}
		}

		public Type itemType
		{
			get
			{
				if (_itemType == null)
				{
					_itemType = typeof(T);
				}
				return _itemType;
			}
		}

		public event Action<int, object, string> itemChanged = delegate
		{
		};

		public event Action<object> itemAdded = delegate
		{
		};

		public event Action<object> itemRemoved = delegate
		{
		};

		public ObservableList()
		{
			guid = Guid.NewGuid().ToString();
		}

		public new void Add(T item)
		{
			base.Add(item);
			AddGUID(item);
			this.itemAdded(item);
		}

		public new void Remove(T item)
		{
			this.itemRemoved(item);
			base.Remove(item);
			RemoveGUID(item);
		}

		public new void AddRange(IEnumerable<T> items)
		{
			List<T> list = items.ToList();
			base.AddRange((IEnumerable<T>)list);
			foreach (T item in list)
			{
				AddGUID(item);
			}
			list.ForEach(delegate(T item)
			{
				this.itemAdded(item);
			});
		}

		public void ReplaceItems(IEnumerable<T> items)
		{
			Clear();
			AddRange(items);
		}

		public new void RemoveRange(int index, int count)
		{
			List<T> list = new List<T>();
			for (int i = index; i < index + count; i++)
			{
				list.Add(this[i]);
			}
			base.RemoveRange(index, count);
			list.ForEach(delegate(T item)
			{
				this.itemRemoved(item);
			});
			foreach (T item in list)
			{
				RemoveGUID(item);
			}
		}

		public new void Clear()
		{
			List<T> list = this.ToList();
			base.Clear();
			list.ForEach(delegate(T item)
			{
				this.itemRemoved(item);
			});
			foreach (T item in list)
			{
				RemoveGUID(item);
			}
		}

		public new void Insert(int index, T item)
		{
			base.Insert(index, item);
			AddGUID(item);
			this.itemAdded(item);
		}

		public new void InsertRange(int index, IEnumerable<T> items)
		{
			base.InsertRange(index, items);
			foreach (T item in items)
			{
				this.itemAdded(item);
			}
		}

		public new void RemoveAll(Predicate<T> match)
		{
			List<T> list = this.Where((T item) => match(item)).ToList();
			base.RemoveAll(match);
			list.ForEach(delegate(T item)
			{
				this.itemRemoved(item);
			});
			foreach (T item in list)
			{
				RemoveGUID(item);
			}
		}

		public new void RemoveAt(int index)
		{
			T val = this[index];
			base.RemoveAt(index);
			this.itemRemoved(val);
			RemoveGUID(val);
		}

		public List<object> GetItems()
		{
			return ((IEnumerable<T>)this).Select((Func<T, object>)((T i) => i)).ToList();
		}

		private void AddGUID(T item)
		{
			itemGuids.Add(Guid.NewGuid().ToString(), item);
		}

		private void RemoveGUID(T item)
		{
			if (itemGuids.Any((KeyValuePair<string, T> f) => f.Value.Equals(item)))
			{
				itemGuids.Remove(itemGuids.First((KeyValuePair<string, T> f) => f.Value.Equals(item)).Key);
			}
		}

		public string GetGUID(object item)
		{
			if (!(item is T))
			{
				return null;
			}
			T castItem = (T)item;
			return itemGuids.FirstOrDefault((KeyValuePair<string, T> f) => f.Value.Equals(castItem)).Key;
		}

		public int GetIndexByGUID(string guid)
		{
			if (!itemGuids.ContainsKey(guid))
			{
				return -1;
			}
			T item = itemGuids[guid];
			return base.IndexOf(item);
		}

		public object GetItemByGUID(string guid)
		{
			if (!itemGuids.ContainsKey(guid))
			{
				return -1;
			}
			int indexByGUID = GetIndexByGUID(guid);
			return this[indexByGUID];
		}

		public void NotifyItemChanged(object item, string changedItem = null)
		{
			T val = (T)item;
			int arg = base.IndexOf(val);
			this.itemChanged(arg, val, changedItem);
		}

		public int IndexOf(object item)
		{
			T item2 = (T)item;
			return base.IndexOf(item2);
		}
	}
}
